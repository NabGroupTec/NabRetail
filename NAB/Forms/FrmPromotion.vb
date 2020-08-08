Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmPromotion
    Structure IdList
        Dim Id As Long
    End Structure
    Dim IdArray() As IdList
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub TxtKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKala.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtGroup.Enabled = True Then
                TxtGroup.Focus()
            Else
                TxtFe.Focus()
            End If
        End If
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try

            If e.ColumnIndex = 0 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV.RowCount - 1 Then
                        For i As Integer = 1 To 3
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If

            ElseIf e.ColumnIndex = 1 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV.RowCount - 1 Then
                        For i As Integer = 1 To 2
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If

            ElseIf e.ColumnIndex = 2 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    SendKeys.Send("+{TAB}")
                End If
            End If
        Catch ex As Exception

        End Try
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
                    DGV.Item("Cln_Az", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Ta", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = ""
                End If
        End Select
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_Az", DGV.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try

            If DGV.CurrentCell.ColumnIndex = 2 Or DGV.CurrentCell.ColumnIndex = 3 Then
                If String.IsNullOrEmpty(TxtKala.Text) Or String.IsNullOrEmpty(TxtFe.Text) Or TxtKala.Text = "0" Then
                    e.Handled = True
                    DGV.Item("Cln_Az", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Ta", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = ""
                End If
            End If

            If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Then
                If String.IsNullOrEmpty(TxtKala.Text) Then
                    e.Handled = True
                    DGV.Item("Cln_Az", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Ta", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = ""
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Or DGV.CurrentCell.ColumnIndex = 3 Then
            If String.IsNullOrEmpty(TxtKala.Text) Then
                e.Handled = True
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
            If e.KeyChar = "." Then
                If InStr(txt_dgv.Text, "/") = False Then
                    e.Handled = False
                    e.KeyChar = "/"
                End If
            End If
            Exit Sub
        End If

        If DGV.CurrentCell.ColumnIndex = 2 Then
            If String.IsNullOrEmpty(TxtKala.Text) Then
                e.Handled = True
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

    Private Sub TxtKala_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKala.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtKala.Focus()
        If Tmp_Namkala <> "" Then
            If CStr(IdKala) <> CStr(TxtIdkala.Text) And DGV.RowCount > 1 Then
                If MessageBox.Show("در صورت تغییر کالا تخفیفات انتخاب شده پاک خواهد شد آیا برای ادامه کار مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                DGV.Rows.Clear()
            End If
            TxtKala.Text = Tmp_Namkala
            TxtIdkala.Text = IdKala
            ChkDK.Checked = DK
            TxtKol.Text = DK_KOL
            TxtJoz.Text = DK_JOZ
        Else
            TxtKala.Text = ""
            TxtIdkala.Text = ""
            TxtKol.Text = ""
            TxtJoz.Text = ""
            ChkDK.Checked = False
            DGV.Rows.Clear()
        End If
    End Sub

    Private Sub FrmDiscountKala_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtKala.Focus()
    End Sub

    Private Sub FrmDiscountKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmDiscountKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If EDIT.Text <> 0 Then
            DGV.AllowUserToAddRows = False
            For i As Integer = 0 To AllSelectKala.Length - 1
                DGV.Rows.Add()
                DGV.Item("Cln_Az", DGV.Rows.Count - 1).Value = AllSelectKala(i).OneGroup
                DGV.Item("Cln_Ta", DGV.Rows.Count - 1).Value = AllSelectKala(i).TwoGroup
                DGV.Item("Cln_Fe", DGV.Rows.Count - 1).Value = AllSelectKala(i).EndCost
                DGV.Item("Cln_Darsad", DGV.Rows.Count - 1).Value = AllSelectKala(i).Namekala
            Next
            DGV.AllowUserToAddRows = True
        Else
            TxtFe.Text = "0"
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtKala.Text.Trim) Or String.IsNullOrEmpty(TxtIdkala.Text) Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtKala.Focus()
                Exit Sub
            End If

            If ChkGroup.Checked = False Then
                If String.IsNullOrEmpty(TxtGroup.Text.Trim) Or String.IsNullOrEmpty(TxtIdGroup.Text) Then
                    MessageBox.Show("هیچ گروه ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtGroup.Focus()
                    Exit Sub
                End If
            End If

            If String.IsNullOrEmpty(TxtFe.Text.Trim) Or TxtFe.Text = "0" Then
                MessageBox.Show("قیمت پایه را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtFe.Focus()
                Exit Sub
            End If

            If DGV.RowCount <= 1 Then
                MessageBox.Show("هیچ قیمت ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2

                    If CStr(DGV.Item("Cln_Az", i).Value) = "" Then
                        MessageBox.Show(" تعداد از در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If CStr(DGV.Item("Cln_Ta", i).Value) = "" Then
                        MessageBox.Show(" تعداد تا در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDbl(DGV.Item("Cln_Az", i).Value) = 0 And CDbl(DGV.Item("Cln_Ta", i).Value) = 0 Then
                        MessageBox.Show(" تعداد از و تا در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDbl(DGV.Item("Cln_Az", i).Value) > CDbl(DGV.Item("Cln_Ta", i).Value) Then
                        MessageBox.Show(" تعداد از و تا در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CStr(DGV.Item("Cln_Fe", i).Value) = "" Then
                        MessageBox.Show(" قیمت در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDbl(DGV.Item("Cln_Fe", i).Value) < 0 Then
                        MessageBox.Show(" قیمت در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CStr(DGV.Item("Cln_Darsad", i).Value) = "" Then
                        MessageBox.Show(" درصد در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If CDbl(DGV.Item("Cln_Darsad", i).Value) < 0 Then
                        MessageBox.Show(" درصد در سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_Az", i).Value.ToString = DGV.Item("Cln_Az", j).Value.ToString) And (DGV.Item("Cln_Ta", i).Value.ToString = DGV.Item("Cln_Ta", j).Value.ToString) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("مقادیر سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i

                For i As Integer = 0 To DGV.RowCount - 2
                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_Az", i).Value.ToString = DGV.Item("Cln_Az", j).Value.ToString) And (DGV.Item("Cln_Ta", i).Value.ToString = DGV.Item("Cln_Ta", j).Value.ToString) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("مقادیر سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i
            End If

            Me.Enabled = False
            If EDIT.Text = "0" Then
                If ChkGroup.Checked = False Then
                    If AreYouAdd(TxtIdkala.Text, TxtIdGroup.Text) = False Then
                        MessageBox.Show("کالا و گروه مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        Exit Sub
                    End If
                End If

                If Me.SaveDiscount(CLng(TxtIdkala.Text), If(ChkGroup.Checked = False, CLng(TxtIdGroup.Text), 0)) Then Me.Close()

            ElseIf EDIT.Text <> "0" Then

                If AreYouEdit(TxtIdkala.Text, TxtIdGroup.Text) = False Then
                    MessageBox.Show("کالا و گروه مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If

                If Me.EditDiscount(CLng(TxtIdkala.Text), If(ChkGroup.Checked = False, CLng(TxtIdGroup.Text), 0)) Then Me.Close()
            End If
            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPromotion", "BtnSave_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Function AreYouAdd(ByVal Idkala As Long, ByVal IdGroup As Long) As Boolean
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using CmdSelect As New SqlCommand("SELECT COUNT (Id)  FROM DefinePromotion WHERE IdKala =@IdKala AND IdGroup =@IdGroup", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Idkala
                CmdSelect.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = IdGroup
                If CmdSelect.ExecuteScalar() <= 0 Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPromotion", "AreYouAdd")
            Return False
        End Try
    End Function

    Private Function AreYouEdit(ByVal Idkala As Long, ByVal IdGroup As Long) As Boolean
        Try
            If Idkala = CLng(Tmp_String1) And IdGroup = CLng(Tmp_String2) Then
                Return True
            End If

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using CmdSelect As New SqlCommand("SELECT COUNT (Id)  FROM DefinePromotion WHERE IdKala =@IdKala AND IdGroup =@IdGroup", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Idkala
                CmdSelect.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = IdGroup
                If CmdSelect.ExecuteScalar() <= 0 Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPromotion", "AreYouEdit")
            Return False
        End Try
    End Function

    Private Function SaveDiscount(ByVal Idkala As Long, ByVal IdGroup As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim id As Long = 0
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            If ChkGroup.Checked = False Then
                Using Cmd As New SqlCommand("INSERT INTO DefinePromotion(IdKala,IdGroup,Fe) VALUES(@IdKala,@IdGroup,@Fe);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Idkala
                    Cmd.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = IdGroup
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(TxtFe.Text)
                    id = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO DefineListPromotion(AzKala,TaKala,Fe,Darsad,IdLink) VALUES(@AzKala,@TaKala,@Fe,@Darsad,@IdLink)", ConectionBank)
                    For i As Integer = 0 To DGV.RowCount - 2
                        Cmd.Parameters.AddWithValue("@AzKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Az", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@TaKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Ta", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = id
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using

                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت ویژه", "جدید", "تعیین قیمت ویژه کالای :" & TxtKala.Text & If(ChkGroup.Checked = False, " در گروه " & TxtGroup.Text, ""), "")

                Return True
            Else
                Dim dt1 As New DataTable

                Using cmd1 As New SqlCommand("SELECT Id  FROM Define_Group_P  WHERE Id  NOT IN (SELECT DISTINCT IdGroup  FROM DefinePromotion WHERE IdKala =" & Idkala & ")", ConectionBank)
                    dt1.Load(cmd1.ExecuteReader)
                End Using

                Array.Resize(IdArray, 0)
                If dt1.Rows.Count > 0 Then
                    Using Cmd As New SqlCommand("INSERT INTO DefinePromotion(IdKala,IdGroup,Fe) VALUES(@IdKala,@IdGroup,@Fe);SELECT @@IDENTITY", ConectionBank)
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Idkala
                            Cmd.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = dt1.Rows(i).Item("Id")
                            Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(TxtFe.Text)
                            Array.Resize(IdArray, IdArray.Length + 1)
                            IdArray(IdArray.Length - 1).Id = Cmd.ExecuteScalar
                            Cmd.Parameters.Clear()
                        Next
                    End Using
                End If


                Using Cmd As New SqlCommand("INSERT INTO DefineListPromotion(AzKala,TaKala,Fe,Darsad,IdLink) VALUES(@AzKala,@TaKala,@Fe,@Darsad,@IdLink)", ConectionBank)
                    For j As Integer = 0 To IdArray.Length - 1
                        For i As Integer = 0 To DGV.RowCount - 2
                            Cmd.Parameters.AddWithValue("@AzKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Az", i).Value.ToString.Replace("/", "."))
                            Cmd.Parameters.AddWithValue("@TaKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Ta", i).Value.ToString.Replace("/", "."))
                            Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Fe", i).Value)
                            Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                            Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = IdArray(j).Id
                            Cmd.ExecuteNonQuery()
                            Cmd.Parameters.Clear()
                        Next i
                    Next j
                End Using
                '''''''''''''''''''''''''''''''''''''''''''''''''''
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت ویژه", "جدید", "تعیین قیمت ویژه کالای :" & TxtKala.Text & If(ChkGroup.Checked = False, " در گروه " & TxtGroup.Text, ""), "")

                Return True
            End If
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPromotion", "SaveCost")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditDiscount(ByVal Idkala As Long, ByVal IdGroup As Long) As Boolean
        
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            If IdGroup > 0 Then
                Using Cmd As New SqlCommand("UPDATE DefinePromotion SET IdKala=@IdKala,IdGroup=@IdGroup,Fe=@Fe WHERE Id=@Id", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Idkala
                    Cmd.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = IdGroup
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(TxtFe.Text)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(EDIT.Text)
                    Cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand("DELETE FROM DefineListPromotion WHERE IdLink=" & CLng(EDIT.Text), ConectionBank)
                    cmd.ExecuteNonQuery()
                End Using

                Using Cmd As New SqlCommand("INSERT INTO DefineListPromotion(AzKala,TaKala,Fe,Darsad,IdLink) VALUES(@AzKala,@TaKala,@Fe,@Darsad,@IdLink)", ConectionBank)
                    For i As Integer = 0 To DGV.RowCount - 2
                        Cmd.Parameters.AddWithValue("@AzKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Az", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@TaKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Ta", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = CLng(EDIT.Text)
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
            Else
                '/////////////////////////////////////////
                Using Cmd As New SqlCommand("UPDATE DefinePromotion SET IdKala=@IdKala,Fe=@Fe WHERE IdKala=@OldIdKala", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = Idkala
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(TxtFe.Text)
                    Cmd.Parameters.AddWithValue("@OldIdKala", SqlDbType.BigInt).Value = CLng(Tmp_String1)
                    Cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand("DELETE FROM DefineListPromotion WHERE IdLink IN(SELECT Id FROM DefinePromotion WHERE IdKala =" & CLng(Tmp_String1) & ")", ConectionBank)
                    cmd.ExecuteNonQuery()
                End Using

                Dim dt As New DataTable
                Using cmd As New SqlCommand("SELECT Id FROM DefinePromotion WHERE IdKala =" & CLng(Tmp_String1), ConectionBank)
                    dt.Load(cmd.ExecuteReader)
                End Using

                For j As Integer = 0 To dt.Rows.Count - 1
                    Using Cmd As New SqlCommand("INSERT INTO DefineListPromotion(AzKala,TaKala,Fe,Darsad,IdLink) VALUES(@AzKala,@TaKala,@Fe,@Darsad,@IdLink)", ConectionBank)
                        For i As Integer = 0 To DGV.RowCount - 2
                            Cmd.Parameters.AddWithValue("@AzKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Az", i).Value.ToString.Replace("/", "."))
                            Cmd.Parameters.AddWithValue("@TaKala", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Ta", i).Value.ToString.Replace("/", "."))
                            Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Fe", i).Value)
                            Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                            Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = dt.Rows(j).Item("Id")
                            Cmd.ExecuteNonQuery()
                            Cmd.Parameters.Clear()
                        Next i
                    End Using
                Next j

                '/////////////////////////////////////////
            End If

            sqltransaction.Commit()
            sqltransaction.Dispose()

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت ویژه", "ویرایش", If(Lname.Text = TxtKala.Text, "ویرایش قیمت ویژه کالای :" & TxtKala.Text & If(ChkGroup.Checked = False, " در گروه " & TxtGroup.Text, ""), "ویرایش قیمت ویژه کالای :" & Lname.Text & " به  کالای " & TxtKala.Text & If(ChkGroup.Checked = False, " در گروه " & TxtGroup.Text, "")), "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPromotion", "EditDiscount")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function


    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KalaVaSCost.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If String.IsNullOrEmpty(TxtKala.Text) Then
                txt_dgv.Clear()
                Exit Sub
            End If

            If DGV.CurrentCell.ColumnIndex = 2 Or DGV.CurrentCell.ColumnIndex = 3 Then
                If String.IsNullOrEmpty(TxtFe.Text) Or TxtFe.Text = "0" Then
                    txt_dgv.Clear()
                    Exit Sub
                End If
            End If

            If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                End If
            End If

            If DGV.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = 0
                End If
                DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = Format((100 - (txt_dgv.Text * 100 / CDbl(TxtFe.Text))), "###.##").ToString.Replace(".", "/")
                If DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value.Equals("") Then DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = 0
            ElseIf DGV.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = 0
                End If
                DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = Format((CDbl(TxtFe.Text) - (txt_dgv.Text * CDbl(TxtFe.Text) / 100)), "###,###")
                If DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value.Equals("") Then DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtFe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFe.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtFe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFe.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TxtFe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFe.TextChanged
        If Not (CheckDigit(Format$(TxtFe.Text.Replace(",", "")))) Then
            TxtFe.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtFe.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtFe.Text.Replace(",", ""))
            TxtFe.Text = Format$(Val(str), "###,###,###")
        Else
            TxtFe.Text = CDbl(TxtFe.Text)
        End If
        If DGV.RowCount > 1 Then
            For i As Integer = 0 To DGV.RowCount - 2
                DGV.Item("Cln_Fe", i).Value = Format((CDbl(TxtFe.Text) - (CDbl(DGV.Item("Cln_Darsad", i).Value) * CDbl(TxtFe.Text) / 100)), "###,###")
                If DGV.Item("Cln_Fe", i).Value.Equals("") Then DGV.Item("Cln_Fe", i).Value = 0
            Next
        End If
    End Sub

    Private Sub TxtGroup_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then TxtFe.Focus()
    End Sub

    Private Sub TxtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroup.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Group_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtGroup.Focus()
        If Tmp_Namkala <> "" Then
            TxtGroup.Text = Tmp_Namkala
            TxtIdGroup.Text = IdKala
        Else
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If ChkGroup.Checked = True Then
            TxtGroup.Enabled = False
        Else
            TxtGroup.Enabled = True
            TxtGroup.Focus()
        End If
    End Sub
End Class