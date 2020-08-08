Imports System.Data.SqlClient
Imports System.Transactions

Public Class Frm_Translate_BoxBank

    Private Sub CmbSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbSanad.KeyDown
        If CmbSanad.DroppedDown = False Then
            CmbSanad.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtPayDate.Focus()
        End If
    End Sub

    Private Sub TxtBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBox.KeyDown
        If e.KeyCode = Keys.Enter Then TxtBank.Focus()
    End Sub

    Private Sub TxtBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Box_List
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

    Private Sub TxtBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBank.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscT.Focus()
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

    Private Sub TxtPayDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtMonT.Focus()
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonT.KeyDown
        If e.KeyCode = Keys.Enter Then TxtBox.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Chk.Enabled = True Then
                Chk.Focus()
            Else
                BtnSave.Focus()
            End If
        End If
    End Sub

    Private Sub CmbSanad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSanad.SelectedIndexChanged
        If CmbSanad.Text = CmbSanad.Items(0) Then
            Chk.Enabled = False
            TxtNumChk.Enabled = False
        Else
            Chk.Enabled = True
            If Chk.Checked = True Then
                TxtNumChk.Enabled = True
            Else
                TxtNumChk.Enabled = False
            End If
        End If
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BankBox.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPayDate.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtMonT.Text) Or TxtMonT.Text = "0" Then
                MessageBox.Show("مبلغ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMonT.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtBox.Text) Or String.IsNullOrEmpty(TxtIdBox.Text) Then
                MessageBox.Show("صندوق را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBox.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtBank.Text) Or String.IsNullOrEmpty(TxtIdbank.Text) Then
                MessageBox.Show("بانک را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBank.Focus()
                Exit Sub
            End If
            If Chk.Enabled = True And Chk.Checked = True Then
                If String.IsNullOrEmpty(TxtNumChk.Text) Then
                    MessageBox.Show("شماره چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNumChk.Focus()
                    Exit Sub
                End If
            End If
            If LEdit.Text = "0" Then
                If Not Me.SaveSanad() Then Exit Sub
            ElseIf LEdit.Text = "1" Then
                If Not Me.EditSanad() Then Exit Sub
            End If
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Translate_Boxbank", "BtnSave_Click")
        End Try
    End Sub

    Private Function EditSanad() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("Update Sanad_Translate_BoxBank SET D_Date=@D_Date,IdBox=@IdBox,IdBank=@IdBank,Mon=@Mon,Stat=@Stat,Disc=@Disc,NumChk=@NumChk,IdUser=@IdUser WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@IDBox", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = If(CmbSanad.Text = CmbSanad.Items(0), 0, 1)
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscT.Text
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                If Chk.Checked = True And Chk.Enabled = True Then
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = CLng(TxtNumChk.Text)
                Else
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = DBNull.Value
                End If
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("UPDATE Moein_Bank SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IDBank=@IDBank,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf(CmbSanad.Text = CmbSanad.Items(0), "انتقال از صندوق به بانک بابت سند" & LSanad.Text & "-" & TxtDiscT.Text.Trim, "انتقال از بانک به صندوق بابت سند" & LSanad.Text & "-" & TxtDiscT.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = If(CmbSanad.Text = CmbSanad.Items(0), 0, 1)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LBankMoein.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("UPDATE Moein_Box SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdBox=@IdBox,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf(CmbSanad.Text = CmbSanad.Items(0), "انتقال از صندوق به بانک بابت سند" & LSanad.Text & "-" & TxtDiscT.Text.Trim, "انتقال از بانک به صندوق بابت سند" & LSanad.Text & "-" & TxtDiscT.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = If(CmbSanad.Text = CmbSanad.Items(0), 1, 0)
                Cmd.Parameters.AddWithValue("@IDBox", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LBoxMoein.Text)
                Cmd.ExecuteScalar()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات بانک و صندوق", "ویرایش", "ویرایش سند :" & CLng(LSanad.Text) & " نام بانک:" & TxtBank.Text & " نام صندوق:" & TxtBox.Text & " نوع انتقال:" & CmbSanad.Text & " مبلغ:" & TxtMonT.Text, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Translate_BoxBank", "EditSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function SaveSanad() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            Dim Idsanad As Long = 0
            Dim IdBank As Long = 0
            Dim IdBox As Long = 0

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO  Sanad_Translate_BoxBank(D_Date,IdBox,IdBank,Mon,Stat,Disc,IdBoxMoein,IdBankMoein,NumChk,IdUser) VALUES(@D_Date,@IdBox,@IdBank,@Mon,@Stat,@Disc,@IdBoxMoein,@IdBankMoein,@NumChk,@IdUser);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@IDBox", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = If(CmbSanad.Text = CmbSanad.Items(0), 0, 1)
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscT.Text
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                If Chk.Checked = True And Chk.Enabled = True Then
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = CLng(TxtNumChk.Text)
                Else
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = DBNull.Value
                End If
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Idsanad = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf(CmbSanad.Text = CmbSanad.Items(0), "انتقال از صندوق به بانک بابت سند" & Idsanad & "-" & TxtDiscT.Text.Trim, "انتقال از بانک به صندوق بابت سند" & Idsanad & "-" & TxtDiscT.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = If(CmbSanad.Text = CmbSanad.Items(0), 0, 1)
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdbank.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                IdBank = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtPayDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf(CmbSanad.Text = CmbSanad.Items(0), "انتقال از صندوق به بانک بابت سند" & Idsanad & "-" & TxtDiscT.Text.Trim, "انتقال از بانک به صندوق بابت سند" & Idsanad & "-" & TxtDiscT.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMonT.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = If(CmbSanad.Text = CmbSanad.Items(0), 1, 0)
                Cmd.Parameters.AddWithValue("@IDBox", SqlDbType.BigInt).Value = CLng(TxtIdBox.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                IdBox = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("UPDATE Sanad_Translate_BoxBank SET IdBoxMoein=@IdBoxMoein,IdBankMoein=@IdBankMoein WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IdBox
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IdBank
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Idsanad
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات بانک و صندوق", "جدید", "ثبت سند :" & Idsanad & " نام بانک:" & TxtBank.Text & " نام صندوق:" & TxtBox.Text & " نوع انتقال:" & CmbSanad.Text & " مبلغ:" & TxtMonT.Text, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Translate_BoxBank", "SaveSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub Frm_Translate_BoxBank_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtPayDate.Focus()
    End Sub

    Private Sub Frm_Translate_BoxBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub TxtMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonT.KeyPress
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

    Private Sub TxtMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonT.TextChanged
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

    Private Sub Chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk.CheckedChanged
        If Chk.Checked = True Then
            TxtNumChk.Enabled = True
            TxtNumChk.Focus()
        Else
            TxtNumChk.Enabled = False
        End If
    End Sub

    Private Sub TxtNumChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumChk.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
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

    Private Sub Chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtNumChk.Enabled = True Then
                TxtNumChk.Focus()
            Else
                BtnSave.Focus()
            End If
        End If
    End Sub

    Private Sub GetInfoSanad(ByVal id As Long)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT Typ= CASE Stat WHEN 0 THEN N'صندوق به بانک' WHEN 1 THEN N'بانک به صندوق' Else  N'نامشخص' End,Sanad_Translate_BoxBank.Id, Sanad_Translate_BoxBank.D_Date, Sanad_Translate_BoxBank.Mon,Sanad_Translate_BoxBank.IdBank,Sanad_Translate_BoxBank.IdBox ,Sanad_Translate_BoxBank.NumChk,Sanad_Translate_BoxBank.IdBankMoein ,Sanad_Translate_BoxBank.IdBoxMoein  , Sanad_Translate_BoxBank.Disc,Define_Bank.n_bank As BankName, Define_Box.nam As BoxName FROM Sanad_Translate_BoxBank INNER JOIN Define_Bank ON Sanad_Translate_BoxBank.IdBank = Define_Bank.ID INNER JOIN Define_Box ON Sanad_Translate_BoxBank.IdBox = Define_Box.ID WHERE Sanad_Translate_BoxBank.Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    CmbSanad.Text = dtr("Typ")
                    CmbSanad.Text = dtr("Typ")
                    TxtPayDate.ThisText = dtr("D_Date")
                    TxtMonT.Text = dtr("Mon")
                    TxtBox.Text = dtr("BoxName")
                    TxtIdBox.Text = dtr("IdBox")
                    TxtBank.Text = dtr("BankName")
                    TxtIdbank.Text = dtr("IdBank")
                    TxtDiscT.Text = dtr("Disc")
                    LBankMoein.Text = dtr("IdBankMoein")
                    LBoxMoein.Text = dtr("IdBoxMoein")
                    If Not (dtr("NumChk") Is DBNull.Value Or dtr("NumChk").Equals("")) Then
                        Chk.Checked = True
                        TxtNumChk.Text = dtr("NumChk")
                    End If
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If

            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Translate_BoxBank", "GetInfoSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub Frm_Translate_BoxBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If LEdit.Text = "1" Then
            Me.GetInfoSanad(LSanad.Text)
        End If
    End Sub
End Class