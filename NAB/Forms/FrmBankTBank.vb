Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmBankTBank
    Dim dt As New DataTable
    Dim dtBank As New DataTable
    Friend WithEvents txt_dgv1 As New DataGridViewTextBoxEditingControl

    Private Sub FrmBankTBank_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtBank.Focus()
    End Sub

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        TxtAllMoney.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        txt_dgv1 = e.Control
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_BankId", DGV1.CurrentRow.Index).Value = ""
                    End If

                    TxtAllMoney.Text = "0"
                    If DGV1.RowCount > 0 Then
                        For i As Integer = 0 To DGV1.RowCount - 2
                            If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                                TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                            End If
                        Next i
                    End If

                    If TxtAllMoney.Text.Length > 3 Then
                        Dim money As String = ""
                        money = TxtAllMoney.Text.Replace(",", "")
                        TxtAllMoney.Text = Format$(Val(money), "###,###,###")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Selected = True
        TxtAllMoney.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Try

            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_BoxName", DGV1.CurrentRow.Index).Selected = True

            TxtAllMoney.Text = "0"
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_MonBox", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBox", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv1.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV1.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_BankId", DGV1.CurrentRow.Index).Value = ""
            End If
            If e.KeyCode = Keys.Space Then
                If DGV1.CurrentCell.ColumnIndex = 1 Then
                    If Not String.IsNullOrEmpty(TxtAllMoney.Text.Trim) Then
                        If CDbl(Txtchkmon.Text) - CDbl(TxtAllMoney.Text) > 0 Then
                            DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value = FormatNumber(CDbl(Txtchkmon.Text) - CDbl(TxtAllMoney.Text), 0)
                            SendKeys.Send("{ENTER}")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv1.KeyPress
        If DGV1.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Dim frmlk As New bank_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.LState.Text = ""
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.AllowUserToAddRows = False
                DGV1.Rows.Add()
                DGV1.AllowUserToAddRows = True
                DGV1.Item("Cln_Bank", DGV1.RowCount - 2).Value = Tmp_Namkala
                DGV1.Item("Cln_MonBank", DGV1.RowCount - 2).Value = 0
                DGV1.Item("Cln_BankId", DGV1.RowCount - 2).Value = IdKala
                DGV1.Item("Cln_Bank", DGV1.RowCount - 2).Selected = False
                DGV1.Item("Cln_MonBank", DGV1.RowCount - 2).Selected = True
            End If
            Exit Sub
        End If

        If DGV1.CurrentCell.ColumnIndex = 1 Then
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = "" Then
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

        If DGV1.CurrentCell.ColumnIndex = 3 Then
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = "" Then
                e.Handled = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_dgv1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv1.TextChanged
        Try
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv1.Clear()
                Exit Sub
            End If
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = "" Then
                txt_dgv1.Clear()
                Exit Sub
            End If
            If DGV1.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigit(txt_dgv1.Text)) Then txt_dgv1.Text = 0
                If CDbl(txt_dgv1.Text) < 0 Then txt_dgv1.Text = 0

                If txt_dgv1.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv1.Text.Replace(",", ""))
                    txt_dgv1.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv1.Text = CDbl(txt_dgv1.Text)
                End If
            End If

            TxtAllMoney.Text = "0"
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBank.KeyDown
        If e.KeyCode = Keys.Enter Then Txtchkmon.Focus()
    End Sub

    Private Sub TxtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.LState.Text = ""
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtBank.Focus()
        If IdKala <> 0 Then
            TxtBank.Text = Tmp_Namkala
            TxtIdbank.Text = IdKala
        End If
    End Sub

    Private Sub Txtchkmon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtchkmon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscBank.Focus()
    End Sub

    Private Sub TxtDiscBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscBank.KeyDown
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
    End Sub

    Private Sub TxtNumChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumChk.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscBank.Focus()
    End Sub

    Private Sub TxtAllMoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAllMoney.KeyDown
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
    End Sub

    Private Sub Txtchkmon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtchkmon.KeyPress
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

    Private Sub Txtchkmon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtchkmon.TextChanged
        If Not (CheckDigit(Format$(Txtchkmon.Text.Replace(",", "")))) Then
            Txtchkmon.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If Txtchkmon.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(Txtchkmon.Text.Replace(",", ""))
            Txtchkmon.Text = Format$(Val(str), "###,###,###")
        Else
            Txtchkmon.Text = CDbl(Txtchkmon.Text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try

            If String.IsNullOrEmpty(TxtBank.Text) Or String.IsNullOrEmpty(TxtIdbank.Text) Then
                MessageBox.Show("بانک بستانکار را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBank.Focus()
                Exit Sub
            End If

            If CDbl(Txtchkmon.Text) <= 0 Then
                MessageBox.Show("مبلغ انتقال را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Txtchkmon.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                MessageBox.Show("تاریخ انتقال را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPayDate.Focus()
                Exit Sub
            End If

            If Chk.Checked = True Then
                If String.IsNullOrEmpty(TxtNumChk.Text) Then
                    MessageBox.Show("شماره چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNumChk.Focus()
                    Exit Sub
                End If
            End If

            If CDbl(TxtAllMoney.Text) <= 0 Then
                MessageBox.Show("جمع بانک بدهکار صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Exit Sub
            End If

            If CDbl(TxtAllMoney.Text) < CDbl(Txtchkmon.Text) Then
                MessageBox.Show("جمع مبلغ کمتر از مبلغ انتقال است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Exit Sub
            End If

            If CDbl(TxtAllMoney.Text) > CDbl(Txtchkmon.Text) Then
                MessageBox.Show("جمع مبلغ بیشتر از مبلغ انتقال است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Exit Sub
            End If

            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If DGV1.Item("Cln_Bank", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت بانک در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_Bank", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If
            For i As Integer = 0 To DGV1.RowCount - 2
                If String.IsNullOrEmpty(DGV1.Item("Cln_Bank", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_BankId", i).Value) Then
                    MessageBox.Show("نام بانک در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_Bank", i).Selected = True
                    Exit Sub
                End If
                If DGV1.Item("Cln_MonBank", i).Value <= 0 Then
                    MessageBox.Show("واریزی به بانک در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_MonBank", i).Selected = True
                    Exit Sub
                End If
                Dim count As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_BankId", i).Value = DGV1.Item("Cln_BankId", j).Value Then count += 1
                    If DGV1.Item("Cln_BankId", i).Value = CLng(TxtIdbank.Text) Then
                        MessageBox.Show("اجازه استفاده از بانک سطر شماره " & "{" & i + 1 & "}" & "  را در لیست بدهکار ندارید زیرا به عنوان بستانکار انتخاب شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_MonBank", i).Selected = True
                        Exit Sub
                    End If
                Next
                If count > 1 Then
                    MessageBox.Show("نام بانک در ردیف شماره " & "{" & i + 1 & "}" & "  تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next i

            If LEdit.Text = "0" Then
                If Me.SaveSanad() Then Me.Close()
            Else
                If Me.EditSanad() Then Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBankTBank", "Btnadd_Click")
        End Try
    End Sub

    Private Function SaveSanad() As Boolean
        Dim IdSanad As Long = 0
        Dim Idbank As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '''''''''''''''''''Sanad Bes
            Using Cmd As New SqlCommand("INSERT Sanad_BankTBank_Bes (D_date,Disc,Mon,IdBankBes,IdSanadBes,NumChk,IdUser) VALUES(@D_date,@Disc,@Mon,@IdBankBes,@IdSanadBes,@NumChk,@IdUser);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscBank.Text.Trim
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtchkmon.Text)
                Cmd.Parameters.AddWithValue("@IdBankBes", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadBes", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = IIf(Chk.Checked = True, TxtNumChk.Text, DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                IdSanad = Cmd.ExecuteScalar()
            End Using
            Using Cmd As New SqlCommand("INSERT INTO Moein_Bank (D_date,disc,mon,T,IdBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "بانک به بانک بابت سند " & IdSanad & If(String.IsNullOrEmpty(TxtDiscBank.Text), "", " - " & TxtDiscBank.Text)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtchkmon.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Idbank = Cmd.ExecuteScalar
            End Using
            Using Cmd As New SqlCommand("UPDATE Sanad_BankTBank_Bes SET IdSanadBes=@IdSanadBes WHERE Id=" & IdSanad, ConectionBank)
                Cmd.Parameters.AddWithValue("@IdSanadBes", SqlDbType.Int).Value = Idbank
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Moein_Bank (D_date,disc,mon,T,IdBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBank,@IdUser);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY); INSERT INTO Sanad_BankTBank_Bed (Id,IdBankBed,Mon,IdSanadBed,Disc) VALUES (@Id,@IDBank,@Mon,@IdMoein,@Disc1)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "بانک به بانک بابت سند " & IdSanad & IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", " - " & DGV1.Item("Cln_Disc", i).Value)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_MonBank", i).Value)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_BankId", i).Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = IdSanad
                    Cmd.Parameters.AddWithValue("@Disc1", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            Dim str As String = ""
            For i As Integer = 0 To DGV1.RowCount - 2
                str &= "  بدهکار :" & DGV1.Item("Cln_Bank", i).Value & " مبلغ بدهکار:" & FormatNumber(DGV1.Item("Cln_MonBank", i).Value, 0)
            Next

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بانک به بانک", "جدید", "ثبت سند :" & IdSanad & " بستانکار:" & TxtBank.Text & " مبلغ بستانکار: " & Txtchkmon.Text & str, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBankTBank", "SaveSanad")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditSanad() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '''''''''''''''''''Sanad Bes
            Using Cmd As New SqlCommand("UPDATE Sanad_BankTBank_Bes SET  D_date=@D_date,Disc=@Disc,Mon=@Mon,IdBankBes=@IdBankBes,NumChk=@NumChk,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscBank.Text.Trim
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtchkmon.Text)
                Cmd.Parameters.AddWithValue("@IdBankBes", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = IIf(Chk.Checked = True, TxtNumChk.Text, DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using
            Using Cmd As New SqlCommand("UPDATE  Moein_Bank SET D_date=@D_date,disc=@disc,mon=@mon,IdBank=@IdBank,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "بانک به بانک بابت سند " & CLng(LSanad.Text) & If(String.IsNullOrEmpty(TxtDiscBank.Text), "", " - " & TxtDiscBank.Text)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtchkmon.Text)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = dt.Rows(0).Item("IdSanadBes")
                Cmd.ExecuteNonQuery()
            End Using
            

            Using Cmd As New SqlCommand("DELETE FROM Sanad_BankTBank_Bed WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using
            Using Cmd As New SqlCommand("DELETE FROM Moein_Bank WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To dtBank.Rows.Count - 1
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = dtBank.Rows(i).Item("IdSanadBed")
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Moein_Bank (D_date,disc,mon,T,IdBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBank,@IdUser);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY); INSERT INTO Sanad_BankTBank_Bed (Id,IdBankBed,Mon,IdSanadBed,Disc) VALUES (@Id,@IDBank,@Mon,@IdMoein,@Disc1)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "بانک به بانک بابت سند " & CLng(LSanad.Text) & IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", " - " & DGV1.Item("Cln_Disc", i).Value)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_MonBank", i).Value)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_BankId", i).Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                    Cmd.Parameters.AddWithValue("@Disc1", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            Dim str As String = ""
            For i As Integer = 0 To DGV1.RowCount - 2
                str &= "  بدهکار :" & DGV1.Item("Cln_Bank", i).Value & " مبلغ بدهکار:" & FormatNumber(DGV1.Item("Cln_MonBank", i).Value, 0)
            Next

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بانک به بانک", "ویرایش", "ویرایش سند :" & CLng(LSanad.Text) & " بستانکار:" & TxtBank.Text & " مبلغ بستانکار: " & Txtchkmon.Text & str, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBankTBank", "EditSanad")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub GetInfoSanad(ByVal id As Long)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT  Sanad_BankTBank_Bes.IdBankBes, Sanad_BankTBank_Bes.Disc, Sanad_BankTBank_Bes.D_date, Sanad_BankTBank_Bes.Mon, Sanad_BankTBank_Bes.NumChk, Sanad_BankTBank_Bes.IdSanadBes, Define_Bank.n_bank FROM Sanad_BankTBank_Bes INNER JOIN Define_Bank ON Sanad_BankTBank_Bes.IdBankBes = Define_Bank.ID WHERE Sanad_BankTBank_Bes.Id =@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                dt.Load(Cmd.ExecuteReader)
                If dt.Rows.Count > 0 Then
                    TxtPayDate.ThisText = dt.Rows(0).Item("D_Date")
                    TxtBank.Text = dt.Rows(0).Item("n_bank")
                    TxtIdbank.Text = dt.Rows(0).Item("IdBankBes")
                    Txtchkmon.Text = dt.Rows(0).Item("Mon")
                    TxtDiscBank.Text = dt.Rows(0).Item("Disc")
                    If dt.Rows(0).Item("NumChk") Is DBNull.Value Then
                        Chk.Checked = False
                        TxtNumChk.Text = ""
                        TxtNumChk.Enabled = False
                    Else
                        Chk.Checked = True
                        TxtNumChk.Enabled = True
                        TxtNumChk.Text = dt.Rows(0).Item("NumChk")
                    End If
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using

            Using Cmd As New SqlCommand("SELECT Sanad_BankTBank_Bed.Disc, Sanad_BankTBank_Bed.IdSanadBed, Sanad_BankTBank_Bed.Mon, Sanad_BankTBank_Bed.IdBankBed,Define_Bank.n_bank FROM Sanad_BankTBank_Bed INNER JOIN Define_Bank ON Sanad_BankTBank_Bed.IdBankBed = Define_Bank.ID WHERE Sanad_BankTBank_Bed.Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                dtBank.Load(Cmd.ExecuteReader)
                If dtBank.Rows.Count > 0 Then
                    Dim sum As Double = 0
                    DGV1.AllowUserToAddRows = False
                    For i As Integer = 0 To dtBank.Rows.Count - 1
                        DGV1.Rows.Add()
                        DGV1.Item("Cln_Bank", DGV1.RowCount - 1).Value = dtBank.Rows(i).Item("n_bank")
                        DGV1.Item("Cln_MonBank", DGV1.RowCount - 1).Value = FormatNumber(dtBank.Rows(i).Item("Mon"), 0)
                        sum += dtBank.Rows(i).Item("Mon")
                        DGV1.Item("Cln_BankId", DGV1.RowCount - 1).Value = dtBank.Rows(i).Item("IdBankBed")
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = dtBank.Rows(i).Item("Disc")
                    Next
                    TxtAllMoney.Text = FormatNumber(sum, 0)
                    DGV1.AllowUserToAddRows = True
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using


        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBankTBank", "GetInfoSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub Chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk.CheckedChanged
        If Chk.Checked = True Then
            TxtNumChk.Enabled = True
            TxtNumChk.Focus()
        Else
            TxtNumChk.Enabled = False
        End If
    End Sub

    Private Sub TxtNumChk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumChk.KeyPress
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

    Private Sub TxtNumChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumChk.TextChanged
        If Not (CheckDigit(Format$(TxtNumChk.Text.Replace(",", "")))) Then
            TxtNumChk.Text = "0"
            Exit Sub
        End If
        TxtNumChk.Text = CDbl(TxtNumChk.Text)
    End Sub

    Private Sub FrmBankTBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmBankTBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        TxtNumChk.Enabled = False
        If LEdit.Text = "1" Then Me.GetInfoSanad(CLng(LSanad.Text))
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BankBeBank.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnadd.Enabled = True Then Btnadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub
End Class