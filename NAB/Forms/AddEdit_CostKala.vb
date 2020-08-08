Imports System.Data.SqlClient
Imports System.Transactions
Public Class AddEdit_CostKala
    Public EDIT, IdRow As Long
    Dim TmpArray() As KalaSelect = Nothing
    Dim ds_O As New DataSet
    Dim str_O As String = "select * From Define_Ostan"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_C As New DataSet
    Dim str_C As String = "select * From Define_City"
    Dim dta_C As New SqlDataAdapter(str_C, DataSource)

    Dim ext As Boolean

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try

            If ChkLimit.Checked = False Then
                If String.IsNullOrEmpty(TxtOstan.Text.Trim) Or CmbOstan.Text = "" Or CmbOstan.FindStringExact(CmbOstan.Text) = -1 Then
                    MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CmbOstan.Focus()
                    Exit Sub
                End If
                If String.IsNullOrEmpty(TxtCity.Text.Trim) Or CmbCity.Text = "" Or CmbCity.FindStringExact(CmbCity.Text) = -1 Then
                    MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CmbCity.Focus()
                    Exit Sub
                End If

                If TxtOstan.Text = "-1" Then
                    MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CmbOstan.Focus()
                    Exit Sub
                End If
                If TxtCity.Text = "-1" Then
                    MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CmbCity.Focus()
                    Exit Sub
                End If
            End If

            If DGV.Item("Cln_name", DGV.RowCount - 1).Value <> "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV.RowCount <= 1 Then
                MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2

                    If DGV.Item("Cln_name", i).Value = "" Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If CDbl(DGV.Item("Cln_Cost", i).Value.ToString) <= 0 And CDbl(DGV.Item("Cln_BCost", i).Value.ToString) <= 0 And CDbl(DGV.Item("Cln_EndCost", i).Value.ToString) <= 0 Then
                        MessageBox.Show(" قیمت خرده،عمده و یا مصرف کننده سطر شماره" & "{ " & i + 1 & " }" & "  اشتباه است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Next i
            End If
            ext = True
            If EDIT = 0 Then
                If SaveCost(If(ChkLimit.Checked = False, CLng(TxtCity.Text), 0)) Then Me.Close()
            ElseIf EDIT = 1 Then
                If EditCost(If(ChkLimit.Checked = False, CLng(TxtCity.Text), 0)) Then Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "BtnSave_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Function SaveCost(ByVal IdCity As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            If ChkLimit.Checked = False Then
                Using CmdSelect As New SqlCommand("SELECT Count(IdCity) FROM Define_CityCostkala WHERE IdCity=@IdCity", ConectionBank)
                    CmdSelect.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                    If CmdSelect.ExecuteScalar() <= 0 Then
                        Using Cmd As New SqlCommand("INSERT INTO Define_CityCostkala(IdCity) VALUES(@IdCity)", ConectionBank)
                            Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using

                Using Cmd As New SqlCommand("INSERT INTO Define_CostKala(IdKala,IdCity,CostSmalKala,CostBigKala,EndCost) VALUES(@IdKala,@IdCity,@CostSmalKala,@CostBigKala,@EndCost)", ConectionBank)
                    For i As Integer = 0 To DGV.RowCount - 2

                        Using CmdSelect2 As New SqlCommand("SELECT Count(Id) FROM Define_CostKala WHERE IdCity=@IdCity and IdKala=@IdKala", ConectionBank)
                            CmdSelect2.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                            CmdSelect2.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdKala", i).Value)

                            If CmdSelect2.ExecuteScalar() <= 0 Then
                                Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdKala", i).Value)
                                Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                                Cmd.Parameters.AddWithValue("@CostSmalKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Cost", i).Value)
                                Cmd.Parameters.AddWithValue("@CostBigKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_BCost", i).Value)
                                Cmd.Parameters.AddWithValue("@EndCost", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_EndCost", i).Value)
                                Cmd.ExecuteNonQuery()
                                Cmd.Parameters.Clear()
                            End If

                        End Using

                    Next i

                End Using

                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت در شهرستان", "جدید", If(ChkLimit.Checked = True, "بدون محدودیت شهرستان", "افزودن قیمت به شهرستان :" & CmbCity.Text), "")

                Return True
            Else
                Dim dt1 As New DataTable
                
                Using cmd1 As New SqlCommand("SELECT Code FROM Define_City WHERE Code NOT IN (SELECT IdCity FROM Define_CityCostkala)", ConectionBank)
                    dt1.Load(cmd1.ExecuteReader)
                End Using

                If dt1.Rows.Count > 0 Then
                    Using Cmd As New SqlCommand("INSERT INTO Define_CityCostkala(IdCity) VALUES(@IdCity)", ConectionBank)
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = dt1.Rows(i).Item("Code")
                            Cmd.ExecuteNonQuery()
                            Cmd.Parameters.Clear()
                        Next
                    End Using
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                dt1.Clear()
                Using cmd1 As New SqlCommand("SELECT Code FROM Define_City", ConectionBank)
                    dt1.Load(cmd1.ExecuteReader)
                End Using

                Using Cmd As New SqlCommand("INSERT INTO Define_CostKala(IdKala,IdCity,CostSmalKala,CostBigKala,EndCost) VALUES(@IdKala,@IdCity,@CostSmalKala,@CostBigKala,@EndCost)", ConectionBank)
                    For i As Integer = 0 To DGV.RowCount - 2
                        For j As Integer = 0 To dt1.Rows.Count - 1

                            Using CmdSelect2 As New SqlCommand("SELECT Count(Id) FROM Define_CostKala WHERE IdCity=@IdCity and IdKala=@IdKala", ConectionBank)
                                CmdSelect2.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = dt1.Rows(j).Item("Code")
                                CmdSelect2.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdKala", i).Value)

                                If CmdSelect2.ExecuteScalar() <= 0 Then
                                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdKala", i).Value)
                                    Cmd.Parameters.AddWithValue("@CostSmalKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Cost", i).Value)
                                    Cmd.Parameters.AddWithValue("@CostBigKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_BCost", i).Value)
                                    Cmd.Parameters.AddWithValue("@EndCost", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_EndCost", i).Value)
                                    Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = dt1.Rows(j).Item("Code")
                                    Cmd.ExecuteNonQuery()
                                    Cmd.Parameters.Clear()
                                End If

                            End Using

                        Next j
                    Next i
                End Using
                '''''''''''''''''''''''''''''''''''''''''''''''''''
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت در شهرستان", "جدید", If(ChkLimit.Checked = True, "بدون محدودیت شهرستان", "افزودن قیمت به شهرستان :" & CmbCity.Text), "")
                Return True
            End If
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "SaveCost")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Function EditCost(ByVal IdCity As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////


            Using CmdSelect As New SqlCommand("SELECT Count(IdCity) FROM Define_CityCostkala WHERE IdCity=@IdCity", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                Dim Result As Long = CmdSelect.ExecuteScalar
                If Result <= 0 Then
                    Using Cmd As New SqlCommand("INSERT INTO Define_CityCostkala(IdCity) VALUES(@IdCity)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Using Cmd As New SqlCommand("DELETE FROM Define_CostKala WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To TmpArray.Length - 1
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = TmpArray(i).Id
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            Using Cmd As New SqlCommand("INSERT INTO Define_CostKala(IdKala,IdCity,CostSmalKala,CostBigKala,EndCost) VALUES(@IdKala,@IdCity,@CostSmalKala,@CostBigKala,@EndCost)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2

                    Using CmdSelect2 As New SqlCommand("SELECT Count(Id) FROM Define_CostKala WHERE IdCity=@IdCity and IdKala=@IdKala", ConectionBank)
                        CmdSelect2.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                        CmdSelect2.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdKala", i).Value)

                        If CmdSelect2.ExecuteScalar() <= 0 Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdKala", i).Value)
                            Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = IdCity
                            Cmd.Parameters.AddWithValue("@CostSmalKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Cost", i).Value)
                            Cmd.Parameters.AddWithValue("@CostBigKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_BCost", i).Value)
                            Cmd.Parameters.AddWithValue("@EndCost", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_EndCost", i).Value)
                            Cmd.ExecuteNonQuery()
                            Cmd.Parameters.Clear()
                        End If

                    End Using

                Next i

            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت در شهرستان", "ویرایش", If(Tmp_TwoGroup = CmbCity.Text.Trim, "ویرایش قیمت شهرستان :" & CmbCity.Text.Trim, "ویرایش از شهرستان :" & Tmp_TwoGroup & " به " & CmbCity.Text), "")
            Return True
            
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "EditCost")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Sub Fill_Ostan()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_O = New SqlDataAdapter(str_O, DataSource)
            dta_O.Fill(ds_O, "Define_Ostan")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "Fill_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_City()
        Try
            ds_C.Clear()
            If Not dta_C Is Nothing Then
                dta_C.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_C = New SqlDataAdapter(str_C, DataSource)
            dta_C.Fill(ds_C, "Define_City")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "Fill_City")
            Me.Close()
        End Try
    End Sub
    
    Private Sub AddEdit_CostKala_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        CmbOstan.Focus()
    End Sub

    Private Sub AddEdit_CostKala_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DGV.RowCount > 1 And ext = False Then
            If MessageBox.Show("آیا برای خروج مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub AddEdit_CostKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub AddEdit_CostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.Fill_Ostan()
        Me.Fill_City()
        Me.FillOstan()
        If EDIT = 1 Then
            CmbOstan.Text = Tmp_OneGroup
            CmbCity.Text = Tmp_TwoGroup
            TxtOstan.Text = TxtIdOstan
            TxtCity.Text = TxtIdCity
            TxtOldCity.Text = TxtIdCity
            Try
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim dtr As SqlDataReader = Nothing
                Using cmd As New SqlCommand("SELECT Define_CostKala.Id, Define_CostKala.IdKala, Define_CostKala.IdCity, Define_CostKala.CostSmalKala, Define_CostKala.CostBigKala,Define_CostKala.EndCost, Define_Kala.Nam,Define_OneGroup.NamOne, Define_TwoGroup.NamTwo FROM Define_CostKala INNER JOIN Define_Kala ON Define_CostKala.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE Define_CostKala.IdCity=" & LId.Text & " ORDER BY NamOne,NamTwo,Nam", ConectionBank)
                    dtr = cmd.ExecuteReader
                End Using
                If dtr.HasRows Then
                    Array.Resize(TmpArray, 0)
                    DGV.Rows.Clear()
                    DGV.AllowUserToAddRows = False
                    While dtr.Read
                        DGV.Rows.Add()
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = dtr("Nam")
                        DGV.Item("Cln_Cost", DGV.RowCount - 1).Value = IIf(dtr("CostSmalKala") > 0, FormatNumber(dtr("CostSmalKala"), 0), 0)
                        DGV.Item("Cln_BCost", DGV.RowCount - 1).Value = IIf(dtr("CostBigKala") > 0, FormatNumber(dtr("CostBigKala"), 0), 0)
                        DGV.Item("Cln_EndCost", DGV.RowCount - 1).Value = IIf(dtr("EndCost") > 0, FormatNumber(dtr("EndCost"), 0), 0)
                        DGV.Item("Cln_Idkala", DGV.RowCount - 1).Value = dtr("IdKala")
                        DGV.Item("Cln_One", DGV.RowCount - 1).Value = dtr("NamOne")
                        DGV.Item("Cln_Two", DGV.RowCount - 1).Value = dtr("Namtwo")
                        DGV.Item("Cln_Id", DGV.RowCount - 1).Value = dtr("Id")
                        Array.Resize(TmpArray, TmpArray.Length + 1)
                        TmpArray(TmpArray.Length - 1).Id = dtr("Id")
                    End While
                    DGV.AllowUserToAddRows = True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Catch ex As Exception
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "AddEdit_CostKala_Load")
                Me.Close()
            End Try
        End If
        DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Focus()
        ext = False
    End Sub
    Private Sub RefreshBank()
        ds_O.Clear()
        dta_O.Fill(ds_O, "Define_Ostan")
        ds_C.Clear()
        dta_C.Fill(ds_C, "Define_City")
        Me.FillOstan()
    End Sub
    Private Sub FillOstan()
        CmbOstan.Items.Clear()
        CmbCity.Items.Clear()
        CmbOstan.Text = ""
        CmbCity.Text = ""
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbOstan.Items.Add(ds_O.Tables(0).Rows(i).Item("NamO"))
        Next
    End Sub
    Private Sub FillCity(ByVal idO As Long)
        CmbCity.Items.Clear()
        For i As Integer = 0 To ds_C.Tables(0).Rows.Count - 1
            If ds_C.Tables(0).Rows(i).Item("IdOstan") = idO Then
                CmbCity.Items.Add(ds_C.Tables(0).Rows(i).Item("NamCi"))
            End If
        Next
    End Sub
    Private Function GetIdOstan(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("NamO ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function
    Private Function GetIdCity(ByVal Nam As String, ByVal idO As String) As Long
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("NamCi ='" & Nam & "' AND IdOstan=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function

    Private Sub CmbOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstan.KeyDown
        If CmbOstan.DroppedDown = False Then
            CmbOstan.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbCity.Focus()
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbOstan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstan.LostFocus
        TxtOstan.Text = GetIdOstan(CmbOstan.Text)
        CmbCity.Items.Clear()
        For i As Integer = 0 To ds_C.Tables(0).Rows.Count - 1
            If ds_C.Tables(0).Rows(i).Item("IdOstan") = CLng(TxtOstan.Text) Then
                CmbCity.Items.Add(ds_C.Tables(0).Rows(i).Item("NamCI"))
            End If
        Next
        If CmbCity.FindStringExact(CmbCity.Text) = -1 Then CmbCity.Text = ""
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        TxtOstan.Text = GetIdOstan(CmbOstan.Text)
        Me.FillCity(If(String.IsNullOrEmpty(TxtOstan.Text), 0, CLng(TxtOstan.Text)))
    End Sub

    Private Sub CmbCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCity.KeyDown
        If CmbCity.DroppedDown = False Then
            CmbCity.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then DGV.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub CmbCity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCity.LostFocus
        If CmbCity.FindStringExact(CmbCity.Text) = -1 Then CmbCity.Text = ""
        TxtCity.Text = GetIdCity(CmbCity.Text, If(String.IsNullOrEmpty(TxtOstan.Text), 0, CLng(TxtOstan.Text)))
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        TxtCity.Text = GetIdCity(CmbCity.Text, If(String.IsNullOrEmpty(TxtOstan.Text), 0, CLng(TxtOstan.Text)))
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        If e.ColumnIndex = 1 Then
            If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                If e.RowIndex <> DGV.RowCount - 1 Then
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        ElseIf e.ColumnIndex = 2 Then
            If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                If e.RowIndex <> DGV.RowCount - 1 Then
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                    SendKeys.Send("+{TAB}")
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If

    End Sub

    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Keys.Delete
                e.Handled = True
                If DGV.CurrentRow.Index <> DGV.RowCount - 1 Then
                    DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
                Else
                    DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Cost", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_BCost", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_EndCost", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_One", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Two", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Idkala", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = 0
                End If
        End Select
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        Try
            If DGV.CurrentCell.ColumnIndex > 0 Then
                If DGV.RowCount - 1 = e.RowIndex + 1 Then
                    DGV.Item("Cln_Name", DGV.CurrentRow.Index).Selected = True
                Else
                    DGV.Item("Cln_Cost", e.RowIndex).Selected = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint

        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        
        Try
            If DGV.Item("cln_Name", e.RowIndex).Value <> "" Then
                If DGV.Item("cln_Cost", e.RowIndex).Value Is DBNull.Value Then
                    'Exit Sub
                ElseIf CLng(DGV.Item("cln_Cost", e.RowIndex).Value) = 0 Then
                    DGV.Rows(e.RowIndex).Cells(1).Style.BackColor = Color.Yellow
                ElseIf CLng(DGV.Item("cln_Cost", e.RowIndex).Value) < 0 Then
                    DGV.Rows(e.RowIndex).Cells(1).Style.BackColor = Color.Pink
                ElseIf CLng(DGV.Item("cln_Cost", e.RowIndex).Value) > 0 Then
                    DGV.Rows(e.RowIndex).Cells(1).Style.BackColor = DGV.Rows(e.RowIndex).Cells(0).Style.BackColor
                End If


                If DGV.Item("cln_BCost", e.RowIndex).Value Is DBNull.Value Then
                    'Exit Sub
                ElseIf CLng(DGV.Item("cln_BCost", e.RowIndex).Value) = 0 Then
                    DGV.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Yellow
                ElseIf CLng(DGV.Item("cln_BCost", e.RowIndex).Value) < 0 Then
                    DGV.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Pink
                ElseIf CLng(DGV.Item("cln_BCost", e.RowIndex).Value) > 0 Then
                    DGV.Rows(e.RowIndex).Cells(2).Style.BackColor = DGV.Rows(e.RowIndex).Cells(0).Style.BackColor
                End If

                If DGV.Item("Cln_EndCost", e.RowIndex).Value Is DBNull.Value Then
                    'Exit Sub
                ElseIf CLng(DGV.Item("Cln_EndCost", e.RowIndex).Value) = 0 Then
                    DGV.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.Yellow
                ElseIf CLng(DGV.Item("Cln_EndCost", e.RowIndex).Value) < 0 Then
                    DGV.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.Pink
                ElseIf CLng(DGV.Item("Cln_EndCost", e.RowIndex).Value) > 0 Then
                    DGV.Rows(e.RowIndex).Cells(3).Style.BackColor = DGV.Rows(e.RowIndex).Cells(0).Style.BackColor
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then e.Handled = True
            If DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = "" Then
                e.Handled = True
                DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_Cost", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_BCost", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_EndCost", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_One", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_Two", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_Idkala", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Using frmlk As New Kala_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
            End Using
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value = Tmp_Namkala
                DGV.Item("Cln_Cost", DGV.CurrentRow.Index).Value = 0
                DGV.Item("Cln_BCost", DGV.CurrentRow.Index).Value = 0
                DGV.Item("Cln_EndCost", DGV.CurrentRow.Index).Value = 0
                DGV.Item("Cln_Idkala", DGV.CurrentRow.Index).Value = IdKala
                DGV.Item("Cln_One", DGV.CurrentRow.Index).Value = Tmp_OneGroup
                DGV.Item("Cln_Two", DGV.CurrentRow.Index).Value = Tmp_TwoGroup
                DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = 0
                '''''''''''''''''''''''''''''''''''''''''''''''''
                DGV.Item("Cln_Name", DGV.CurrentRow.Index).Selected = False
                DGV.Item("Cln_Cost", DGV.CurrentRow.Index).Selected = True
            Else
                DGV.Item("Cln_Name", DGV.CurrentRow.Index).Selected = False
                DGV.Item("Cln_Cost", DGV.CurrentRow.Index).Selected = True
            End If
            Exit Sub
        End If

        If DGV.CurrentCell.ColumnIndex = 1 Or DGV.CurrentCell.ColumnIndex = 2 Or DGV.CurrentCell.ColumnIndex = 3 Then
            If DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value = "" Then
                e.Handled = True
                DGV.Item("Cln_Cost", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_BCost", DGV.CurrentRow.Index).Value = ""
                Exit Sub
            End If
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = (vbBack) Then
                e.Handled = False
            End If
            If e.KeyChar = (vbTab) Then
                e.Handled = False
            End If
        End If

    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value = "" Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV.CurrentCell.ColumnIndex = 1 Or DGV.CurrentCell.ColumnIndex = 2 Or DGV.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    Exit Sub
                End If
                If CDbl(txt_dgv.Text) <= 0 Then txt_dgv.Text = 0

                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه کالاهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        DGV.Rows.Clear()
    End Sub

    Private Sub BtnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdvance.Click
        Using FrmAdVance As New Kala_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    'DGV.Rows.Clear()
                    DGV.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV.Rows.Add()
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = AllSelectKala(i).Namekala
                        DGV.Item("Cln_Cost", DGV.RowCount - 1).Value = AllSelectKala(i).CostSkala
                        DGV.Item("Cln_BCost", DGV.RowCount - 1).Value = AllSelectKala(i).CostBkala
                        DGV.Item("Cln_EndCost", DGV.RowCount - 1).Value = AllSelectKala(i).EndCost
                        DGV.Item("Cln_Idkala", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                        DGV.Item("Cln_One", DGV.RowCount - 1).Value = AllSelectKala(i).OneGroup
                        DGV.Item("Cln_Two", DGV.RowCount - 1).Value = AllSelectKala(i).TwoGroup
                        DGV.Item("Cln_Id", DGV.RowCount - 1).Value = 0
                    Next
                    DGV.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
            Catch ex As Exception
                DGV.Rows.Clear()
                DGV.AllowUserToAddRows = True
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Kalaoghimat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnAdvance.Enabled = True Then Call BtnAdvance_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnSelect.Enabled = True Then Call BtnSelect_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnAdvance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAdvance.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnCancel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCancel.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnDel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnDel.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnSave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnSave.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Fnew = True
            Using FrmCity As New DefineCity
                FrmCity.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "Button1_Click")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Fnew = True
            Using FrmCity As New DefineCity
                FrmCity.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_CostKala", "Button1_Click")
        End Try
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Button2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button2.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ChkLimit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLimit.CheckedChanged
        If ChkLimit.Checked = True Then
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub ChkLimit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkLimit.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Using frm As New ListCostKala
            frm.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    DGV.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV.Rows.Add()
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = AllSelectKala(i).Namekala
                        DGV.Item("Cln_Cost", DGV.RowCount - 1).Value = AllSelectKala(i).CostSkala
                        DGV.Item("Cln_BCost", DGV.RowCount - 1).Value = AllSelectKala(i).CostBkala
                        DGV.Item("Cln_EndCost", DGV.RowCount - 1).Value = AllSelectKala(i).EndCost
                        DGV.Item("Cln_Idkala", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                        DGV.Item("Cln_One", DGV.RowCount - 1).Value = AllSelectKala(i).OneGroup
                        DGV.Item("Cln_Two", DGV.RowCount - 1).Value = AllSelectKala(i).TwoGroup
                        DGV.Item("Cln_Id", DGV.RowCount - 1).Value = 0
                    Next
                    DGV.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
            Catch ex As Exception
                DGV.Rows.Clear()
                DGV.AllowUserToAddRows = True
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Idkala", i).Value = IdKala Then
                        DGV.Item("Cln_Name", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item("Cln_Name", 0).Selected = True
                DGV.Item("Cln_Name", 0).Selected = False
            End If
        End If
    End Sub
End Class

