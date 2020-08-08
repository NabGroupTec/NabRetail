Imports System.Data.SqlClient
Imports System.Transactions
Public Class AddEdit_ExitFactor
    Public EDIT, IdRow As Long
    Dim TmpArray() As KalaSelect = Nothing

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try

            If String.IsNullOrEmpty(TxtDate.ThisText) Then
                MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value <> "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV.RowCount <= 1 Then
                MessageBox.Show("فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2

                    If CStr(DGV.Item("Cln_IdFactor", i).Value) = "" Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_IdFactor", i).Value = DGV.Item("Cln_IdFactor", j).Value) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("شماره فاکتور سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i
            End If
            Me.Enabled = False
            If EDIT = 0 Then
                If SaveList() Then Me.Close()
            ElseIf EDIT = 1 Then
                If EditList() Then Me.Close()
            End If
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_ExitFactor", "BtnSave_Click")
        End Try
    End Sub

    Private Function SaveList() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            Dim Idlist As Long = 0
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("INSERT INTO ExitFactor(D_date,Disc,IdUser,IdRecive,IdDriver,IdCar) VALUES(@D_date,@Disc,@IdUser,@IdRecive,@IdDriver,@IdCar);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@IdRecive", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtReciver.Text) Or String.IsNullOrEmpty(TxtIdRecevier.Text), DBNull.Value, TxtIdRecevier.Text)
                Cmd.Parameters.AddWithValue("@IdDriver", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtDriver.Text) Or String.IsNullOrEmpty(TxtIdDriver.Text), DBNull.Value, TxtIdDriver.Text)
                Cmd.Parameters.AddWithValue("@IdCar", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtCar.Text) Or String.IsNullOrEmpty(TxtIdCar.Text), DBNull.Value, TxtIdCar.Text)
                Idlist = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("INSERT INTO ListExitFactor(IdList,IdFactor,Priority) VALUES(@IdList,@IdFactor,@Priority)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdList", SqlDbType.BigInt).Value = Idlist
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdFactor", i).Value)
                    Cmd.Parameters.AddWithValue("@Priority", SqlDbType.BigInt).Value = i + 1
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "جدید", "ثبت خروجی به شماره :" & Idlist & " تعداد فاکتور:" & DGV.RowCount - 1, "")

            MessageBox.Show("خروجی   " & "به شماره " & Idlist & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست.از فاکتورهایی که قبلا ثبت شده است استفاده نکنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_ExitFactor", "SaveList")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function EditList() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("UPDATE ExitFactor SET D_date=@D_date,Disc=@Disc,IdUser=@IdUser,IdRecive=@IdRecive,IdDriver=@IdDriver,IdCar=@IdCar WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@IdRecive", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtReciver.Text) Or String.IsNullOrEmpty(TxtIdRecevier.Text), DBNull.Value, TxtIdRecevier.Text)
                Cmd.Parameters.AddWithValue("@IdDriver", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtDriver.Text) Or String.IsNullOrEmpty(TxtIdDriver.Text), DBNull.Value, TxtIdDriver.Text)
                Cmd.Parameters.AddWithValue("@IdCar", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtCar.Text) Or String.IsNullOrEmpty(TxtIdCar.Text), DBNull.Value, TxtIdCar.Text)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("DELETE FROM ListExitFactor WHERE IdList=@IdList", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdList", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO ListExitFactor(IdList,IdFactor,Priority) VALUES(@IdList,@IdFactor,@Priority)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdList", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdFactor", i).Value)
                    Cmd.Parameters.AddWithValue("@Priority", SqlDbType.BigInt).Value = i + 1
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "ویرایش", "ویرایش خروجی به شماره :" & CLng(LSanad.Text) & " تعداد فاکتور:" & DGV.RowCount - 1, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست.از فاکتورهایی که قبلا ثبت شده است استفاده نکنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_ExitFactor", "EditList")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub AddEdit_ExitFactor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtDate.Focus()
    End Sub

    Private Sub AddEdit_ExitFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub AddEdit_CostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If EDIT = 1 Then
            ShowInfoExitFactor()
        Else
            TxtDate.ThisText = GetDate()
        End If
        DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Focus()
    End Sub
   
    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub ShowInfoExitFactor()
        Try

            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand("SELECT ListExitFactor.IdFactor,ListExitFactor.Priority,Define_People.Nam FROM ListExitFactor INNER JOIN ListFactorSell ON ListExitFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE IdList =" & CLng(LSanad.Text) & " ORDER BY ListExitFactor.Priority", ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    DGV.AllowUserToAddRows = False
                    While dtrInfo.Read
                        DGV.Rows.Add()
                        DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value = dtrInfo("IdFactor")
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = dtrInfo("Nam")
                    End While
                    DGV.AllowUserToAddRows = True
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            '////////////////////////////
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand("SELECT id,IdCar ,IdDriver ,IdRecive,Disc,D_date ,(SELECT Nam FROM Define_Driver WHERE Id=ExitList.IdDriver) AS Driver,(SELECT Nam FROM Define_Reciver  WHERE Id=ExitList.IdRecive) AS Reciver,(SELECT Nam FROM Define_Car  WHERE Id=ExitList.IdCar ) AS Car FROM (SELECT ID,IdCar ,IdDriver,IdRecive,Disc,D_date  FROM ExitFactor) As ExitList WHERE Id=" & CLng(LSanad.Text), ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    dtrInfo.Read()

                    TxtDate.ThisText = dtrInfo("D_Date")
                    TxtDisc.Text = If(dtrInfo("Disc") Is DBNull.Value, "", dtrInfo("Disc"))

                    TxtDriver.Text = If(dtrInfo("Driver") Is DBNull.Value, "", dtrInfo("Driver"))
                    TxtIdDriver.Text = If(dtrInfo("IdDriver") Is DBNull.Value, "", dtrInfo("IdDriver"))

                    TxtReciver.Text = If(dtrInfo("Reciver") Is DBNull.Value, "", dtrInfo("Reciver"))
                    TxtIdRecevier.Text = If(dtrInfo("IdRecive") Is DBNull.Value, "", dtrInfo("IdRecive"))

                    TxtCar.Text = If(dtrInfo("Car") Is DBNull.Value, "", dtrInfo("Car"))
                    TxtIdCar.Text = If(dtrInfo("IdCar") Is DBNull.Value, "", dtrInfo("IdCar"))

                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "ShowKalaFactor")
            Me.Close()
        End Try
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
                    DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_One", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Two", DGV.CurrentRow.Index).Value = ""
                End If
        End Select
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        Try
            If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then e.Handled = True
            If DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = "" Then
                e.Handled = True
                DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Using frmlk As New Factor_List
                frmlk.str = "SELECT IdFactor, D_date, Nam, IdName  FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE ListFactorSell.Activ =1 And ListFactorSell.Stat =3 AND IdFactor NOT IN (SELECT IdFactor FROM ListExitFactor ) ORDER BY IdFactor"
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
            End Using
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                DGV.AllowUserToAddRows = False
                DGV.Rows.Add()
                DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value = IdKala
                DGV.Item("Cln_Name", DGV.RowCount - 1).Value = Tmp_Namkala
                DGV.AllowUserToAddRows = True
                DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Selected = True
            Else
                DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Selected = True
            End If
            Exit Sub
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
            If DGV.CurrentCell.ColumnIndex = 1 Or DGV.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    Exit Sub
                End If
                If CDbl(txt_dgv.Text) <= 0 Then txt_dgv.Text = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه فاکتورهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        DGV.Rows.Clear()
    End Sub

    Private Sub BtnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdvance.Click
        Using FrmAdVance As New Factor_List2
            FrmAdVance.str = "SELECT ListFactorSell.IdFactor, ListFactorSell.D_date, Define_People.Nam, Define_Ostan.NamO, Define_City.NamCI,Define_Part.NamP FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_part ON Define_People.IdPart = Define_Part.Code WHERE ListFactorSell.Activ =1 And ListFactorSell.Stat =3 AND IdFactor NOT IN (SELECT IdFactor FROM ListExitFactor ) ORDER BY IdFactor"
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
                        DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                    Next
                    DGV.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
                If DGV.RowCount > 0 Then DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Selected = True
            Catch ex As Exception
                DGV.Rows.Clear()
                DGV.AllowUserToAddRows = True
                Array.Resize(AllSelectKala, 0)
                Me.Enabled = True
            End Try
        End Using
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KhrojFact.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnAdvance.Enabled = True Then Call BtnAdvance_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtDriver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDriver.KeyDown
        If e.KeyCode = Keys.Enter Then TxtReciver.Focus()
    End Sub

    Private Sub TxtDriver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDriver.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Driver_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtDriver.Focus()
        If Tmp_Namkala <> "" Then
            TxtIdDriver.Text = IdKala
            TxtDriver.Text = Tmp_Namkala
        Else
            TxtIdDriver.Text = ""
            TxtDriver.Text = ""
        End If
    End Sub

    Private Sub TxtReciver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReciver.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCar.Focus()
    End Sub

    Private Sub TxtReciver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReciver.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Reciver_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtReciver.Focus()
        If Tmp_Namkala <> "" Then
            TxtIdRecevier.Text = IdKala
            TxtReciver.Text = Tmp_Namkala
        Else
            TxtIdRecevier.Text = ""
            TxtReciver.Text = ""
        End If
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtDriver.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtCar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCar.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtCar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Car_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtCar.Focus()
        If Tmp_Namkala <> "" Then
            TxtIdCar.Text = IdKala
            TxtCar.Text = Tmp_Namkala
        Else
            TxtIdCar.Text = ""
            TxtCar.Text = ""
        End If
    End Sub
End Class

