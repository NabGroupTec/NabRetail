Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmAddDecBank
    Dim dt As New DataTable
    Private Sub TxtBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBox.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMonT.Focus()
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtBox.Focus()
        If Tmp_Namkala <> "" Then
            TxtBox.Text = Tmp_Namkala
            TxtIdBox.Text = IdKala
        End If
    End Sub

    Private Sub TxtMonT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonT.KeyDown
        If e.KeyCode = Keys.Enter Then TxtPayDate.Focus()
    End Sub

    Private Sub TxtMonT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonT.KeyPress
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

    Private Sub TxtMonT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonT.TextChanged
        If Not (CheckDigit(Format$(TxtMonT.Text.Replace(",", "")))) Then
            TxtMonT.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtMonT.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtMonT.Text.Replace(",", ""))
            TxtMonT.Text = Format$(Val(str), "###,###,###")
        Else
            TxtMonT.Text = CDbl(TxtMonT.Text)
        End If
    End Sub

    Private Sub TxtPayDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtDiscT.Focus()
    End Sub

    Private Sub TxtDiscT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscT.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtBox.Text) Or String.IsNullOrEmpty(TxtIdBox.Text) Then
                MessageBox.Show("بانک را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBox.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtMonT.Text) Or TxtMonT.Text = "0" Then
                MessageBox.Show("مبلغ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMonT.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPayDate.Focus()
                Exit Sub
            End If

            If LEdit.Text = "0" Then
                If Not Me.SaveSanad() Then Exit Sub
            ElseIf LEdit.Text = "1" Then
                If Not Me.EditSanad() Then Exit Sub
            End If
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAddDecBank", "BtnSave_Click")
        End Try
    End Sub
    Private Function SaveSanad() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            Dim Idsanad As Long = 0
            Dim IdBox As Long = 0

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO  Sanad_AddDecBank(D_Date,IdBank,Mon,Disc,IDsanadBank,IdUser,Flag) VALUES(@D_Date,@IdBank,@Mon,@Disc,@IDsanadBank,@IdUser,@Flag);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscT.Text
                Cmd.Parameters.AddWithValue("@IDsanadBank", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Flag", SqlDbType.Int).Value = If(RdoAdd.Checked = True, 0, 1)
                Idsanad = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IdBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf(RdoAdd.Checked = True, "اضافات بانک بابت سند" & Idsanad & "-" & TxtDiscT.Text.Trim, "کسورات بانک بابت سند" & Idsanad & "-" & TxtDiscT.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = If(RdoAdd.Checked = True, 0, 1)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                IdBox = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("UPDATE Sanad_AddDecBank SET IDsanadBank=@IDsanadBank WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@IDsanadBank", SqlDbType.BigInt).Value = IdBox
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Idsanad
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اضافات و کسورات بانک", "جدید", "ثبت سند :" & Idsanad & " نام بانک:" & TxtBox.Text & " نوع سند:" & If(RdoAdd.Checked = True, "اضافات", "کسورات") & " مبلغ:" & TxtMonT.Text, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAddDecBank", "SaveSanad")
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

            Using Cmd As New SqlCommand("UPDATE   Sanad_AddDecBank SET D_Date=@D_Date,IdBank=@IdBank,Mon=@Mon,Disc=@Disc,IdUser=@IdUser,Flag=@Flag WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscT.Text
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Flag", SqlDbType.Int).Value = If(RdoAdd.Checked = True, 0, 1)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("UPDATE Moein_Bank SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdBank=@IdBank,IdUser=@IdUser WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf(RdoAdd.Checked = True, "اضافات بانک بابت سند" & CLng(LSanad.Text) & "-" & TxtDiscT.Text.Trim, "کسورات بانک بابت سند" & CLng(LSanad.Text) & "-" & TxtDiscT.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = If(RdoAdd.Checked = True, 0, 1)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(0).Item("IDsanadBank")
                Cmd.ExecuteNonQuery()
            End Using


            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اضافات و کسورات بانک", "ویرایش", "ویرایش سند :" & CLng(LSanad.Text) & " نام بانک:" & TxtBox.Text & " نوع سند:" & If(RdoAdd.Checked = True, "اضافات", "کسورات") & " مبلغ:" & TxtMonT.Text, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAddDecBank", "EditSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub GetInfoSanad(ByVal id As Long)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT  Sanad_AddDecBank.Id,Sanad_AddDecBank.IdBank ,Sanad_AddDecBank.IDsanadBank , Sanad_AddDecBank.Mon, Sanad_AddDecBank.D_Date, Sanad_AddDecBank.Disc, Define_Bank.n_bank As Nam, Sanad_AddDecBank.Flag FROM  Sanad_AddDecBank INNER JOIN Define_Bank ON Sanad_AddDecBank.IdBank = Define_Bank.ID WHERE Sanad_AddDecBank.Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                dt.Load(Cmd.ExecuteReader)
                If dt.Rows.Count > 0 Then
                    TxtPayDate.ThisText = dt.Rows(0).Item("D_Date")
                    TxtMonT.Text = dt.Rows(0).Item("Mon")
                    TxtBox.Text = dt.Rows(0).Item("Nam")
                    TxtIdBox.Text = dt.Rows(0).Item("IdBank")
                    TxtDiscT.Text = dt.Rows(0).Item("Disc")
                    If dt.Rows(0).Item("Flag") = 0 Then
                        RdoAdd.Checked = True
                    Else
                        RdoDec.Checked = True
                    End If
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAddDecBank", "GetInfoSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub FrmAddDecBox_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtBox.Focus()
    End Sub

    Private Sub FrmAddDecBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmAddDecBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If LEdit.Text = "1" Then Me.GetInfoSanad(LSanad.Text)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AddDecBank.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub
End Class