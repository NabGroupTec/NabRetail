Imports System.Data.SqlClient
Imports System.Transactions

Public Class FrmMessage
    Public Edit As Integer
    Public Kind As Integer

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then TxtVisitor.Focus()
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or TxtUser.ReadOnly = True Then Exit Sub
        Dim frmlk As New User_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
        End If
    End Sub

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSubject.Focus()
    End Sub

    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or TxtVisitor.ReadOnly = True Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        If Tmp_Namkala <> "" Then
            TxtVisitor.Text = Tmp_Namkala
            TxtIdVisitor.Text = IdKala
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using FrmAdVance As New User_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then

                    TxtUser.Clear()
                    TxtIdUser.Clear()

                    For i As Integer = 0 To AllSelectKala.Length - 1
                        TxtUser.Text &= AllSelectKala(i).Namekala & " - "
                        TxtIdUser.Text &= AllSelectKala(i).IdKala & "-"
                    Next
                    TxtUser.Text = TxtUser.Text.Substring(0, TxtUser.Text.Length - 3)
                    TxtIdUser.Text = TxtIdUser.Text.Substring(0, TxtIdUser.Text.Length - 1)
                    Array.Resize(AllSelectKala, 0)
                End If
                TxtUser.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
                TxtUser.Clear()
                TxtIdUser.Clear()
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Using FrmAdVance As New Visitor_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then

                    TxtVisitor.Clear()
                    TxtIdVisitor.Clear()

                    For i As Integer = 0 To AllSelectKala.Length - 1
                        TxtVisitor.Text &= AllSelectKala(i).Namekala & " - "
                        TxtIdVisitor.Text &= AllSelectKala(i).IdKala & "-"
                    Next
                    TxtVisitor.Text = TxtVisitor.Text.Substring(0, TxtVisitor.Text.Length - 3)
                    TxtIdVisitor.Text = TxtIdVisitor.Text.Substring(0, TxtIdVisitor.Text.Length - 1)
                    Array.Resize(AllSelectKala, 0)
                End If
                TxtVisitor.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
                TxtVisitor.Clear()
                TxtIdVisitor.Clear()
            End Try
        End Using
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If String.IsNullOrEmpty(TxtDateSend.ThisText) Then
            MessageBox.Show("تاریخ ارسال نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtDateSend.ThisText = GetDate()
            TxtDateSend.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtDateRecive.ThisText) Then
            MessageBox.Show("تاریخ دریافت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtDateRecive.ThisText = GetDate()
            TxtDateRecive.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtIdUser.Text.Trim) And String.IsNullOrEmpty(TxtIdVisitor.Text.Trim) Then
            MessageBox.Show("گیرنده را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtUser.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtSubject.Text.Trim) Then
            MessageBox.Show("عنوان را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtSubject.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtMessage.Text.Trim) Then
            MessageBox.Show("متن پیام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMessage.Focus()
            Exit Sub
        End If

        If Edit = 0 Then
            Me.SaveMessage()
        Else
            Me.EditMessage()
        End If
        Me.Close()
    End Sub
    Private Sub SaveMessage()
        Dim sqltransaction As New CommittableTransaction

        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTransaction)

            Using cmd As New SqlCommand("INSERT INTO  MessageCenter(Sender_IdUser,Sender_IdVisitor,Reciver_IdUser,Reciver_IdVisitor,Subject,Message,C_Date,R_Date,Chk,Kind,Response,RChk) VALUES (@Sender_IdUser,@Sender_IdVisitor,@Reciver_IdUser,@Reciver_IdVisitor,@Subject,@Message,@C_Date,@R_Date,@Chk,@Kind,@Response,@RChk)", ConectionBank)

                If Not String.IsNullOrEmpty(TxtIdUser.Text.Trim) Then
                    Dim user() As String = TxtIdUser.Text.Split("-")
                    For i As Integer = 0 To user.Length - 1
                        cmd.Parameters.AddWithValue("@Sender_IdUser", SqlDbType.BigInt).Value = Id_User
                        cmd.Parameters.AddWithValue("@Sender_IdVisitor", SqlDbType.BigInt).Value = DBNull.Value
                        cmd.Parameters.AddWithValue("@Reciver_IdUser", SqlDbType.BigInt).Value = user(i)
                        cmd.Parameters.AddWithValue("@Reciver_IdVisitor", SqlDbType.BigInt).Value = DBNull.Value
                        cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = TxtSubject.Text.Trim
                        cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = TxtMessage.Text.Trim
                        cmd.Parameters.AddWithValue("@C_Date", SqlDbType.NVarChar).Value = TxtDateSend.ThisText
                        cmd.Parameters.AddWithValue("@R_Date", SqlDbType.NVarChar).Value = TxtDateRecive.ThisText
                        cmd.Parameters.AddWithValue("@Kind", SqlDbType.Int).Value = Kind
                        cmd.Parameters.AddWithValue("@Chk", SqlDbType.Bit).Value = False
                        cmd.Parameters.AddWithValue("@Response", SqlDbType.BigInt).Value = IIf(ChkNum.Checked = True, TxtResponse.Text, DBNull.Value)
                        cmd.Parameters.AddWithValue("@RChk", SqlDbType.Bit).Value = If(ChkResponse.Checked = True, True, False)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    Next i
                End If

                If Not String.IsNullOrEmpty(TxtIdVisitor.Text.Trim) Then
                    Dim Visitor() As String = TxtIdVisitor.Text.Split("-")
                    For i As Integer = 0 To Visitor.Length - 1
                        cmd.Parameters.AddWithValue("@Sender_IdUser", SqlDbType.BigInt).Value = Id_User
                        cmd.Parameters.AddWithValue("@Sender_IdVisitor", SqlDbType.BigInt).Value = DBNull.Value
                        cmd.Parameters.AddWithValue("@Reciver_IdUser", SqlDbType.BigInt).Value = DBNull.Value
                        cmd.Parameters.AddWithValue("@Reciver_IdVisitor", SqlDbType.BigInt).Value = Visitor(i)
                        cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = TxtSubject.Text.Trim
                        cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = TxtMessage.Text.Trim
                        cmd.Parameters.AddWithValue("@C_Date", SqlDbType.NVarChar).Value = TxtDateSend.ThisText
                        cmd.Parameters.AddWithValue("@R_Date", SqlDbType.NVarChar).Value = TxtDateRecive.ThisText
                        cmd.Parameters.AddWithValue("@Kind", SqlDbType.Int).Value = Kind
                        cmd.Parameters.AddWithValue("@Chk", SqlDbType.Bit).Value = False
                        cmd.Parameters.AddWithValue("@Response", SqlDbType.BigInt).Value = IIf(ChkNum.Checked = True, TxtResponse.Text, DBNull.Value)
                        cmd.Parameters.AddWithValue("@RChk", SqlDbType.Bit).Value = If(ChkResponse.Checked = True, True, False)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    Next i
                End If

            End Using

            SqlTransaction.Commit()
            SqlTransaction.Dispose()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مرکز پیام", "جدید", " پیام جدید با عنوان " & TxtSubject.Text.Trim, "")
        Catch ex As Exception
            SqlTransaction.Rollback()
            SqlTransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات پیام قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessage", "SaveMessage")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
        End Try
    End Sub

    Private Sub EditMessage()
        Dim sqltransaction As New CommittableTransaction

        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using cmd As New SqlCommand("Update  MessageCenter SET Subject=@Subject,Message=@Message,R_Date=@R_Date,Response=@Response,RChk=@RChk WHERE Id=@Id", ConectionBank)
                cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = TxtSubject.Text.Trim
                cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = TxtMessage.Text.Trim
                cmd.Parameters.AddWithValue("@R_Date", SqlDbType.NVarChar).Value = TxtDateRecive.ThisText
                cmd.Parameters.AddWithValue("@Response", SqlDbType.BigInt).Value = IIf(ChkNum.Checked = True, TxtResponse.Text, DBNull.Value)
                cmd.Parameters.AddWithValue("@RChk", SqlDbType.Bit).Value = If(ChkResponse.Checked = True, True, False)
                cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Edit
                cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مرکز پیام", "ویرایش", " ویرایش پیام شماره " & Edit, "")
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات پیام قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessage", "EditMessage")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
        End Try
    End Sub

    Private Sub ReadMessage()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE  MessageCenter SET Chk='True' WHERE Id=" & Edit, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            If Err.Number = 5 Then
                MessageBox.Show("پیام به حالت خوانده شده تغییر وضعیت نمی دهد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessage", "ReadMessage")
            End If
        End Try
    End Sub

    Private Sub FrmMessage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmMessage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Edit = 0 Then
            TxtDateSend.ThisText = GetDate()
            TxtDateSend.Enabled = False
            TxtDateRecive.ThisText = GetDate()
        Else
            TxtDateSend.Enabled = False
            If Kind = 0 Then
                Me.ReadMessage()
            End If
        End If
    End Sub

    Private Sub TxtDateSend_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDateSend.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtDateRecive.Focus()
    End Sub

    Private Sub TxtDateRecive_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDateRecive.KeyDowned
        If e.KeyCode = Keys.Enter Then ChkNum.Focus()
    End Sub

    Private Sub TxtSubject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSubject.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMessage.Focus()
    End Sub

    Private Sub ChkResponse_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkResponse.GotFocus
        ChkResponse.BackColor = Color.LightGray
    End Sub

    Private Sub ChkResponse_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkResponse.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtUser.Enabled = True Then
                TxtUser.Focus()
            ElseIf TxtVisitor.Enabled = True Then
                TxtVisitor.Focus()
            Else
                TxtSubject.Focus()
            End If
        End If
    End Sub

    Private Sub ChkResponse_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkResponse.LostFocus
        ChkResponse.BackColor = Me.BackColor
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "MsgCenter.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button5.Enabled = True Then Button5_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button6.Enabled = True Then Button6_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChkNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkNum.CheckedChanged
        If Kind = 0 And Edit > 0 Then Exit Sub
        If ChkNum.Checked = True Then
            ChkResponse.Checked = False
            ChkResponse.Enabled = False
            TxtUser.Text = ""
            TxtUser.ReadOnly = True
            TxtVisitor.ReadOnly = True
            TxtVisitor.Text = ""
            TxtIdUser.Text = ""
            TxtIdVisitor.Text = ""
            Button1.Enabled = False
            Button4.Enabled = False

            TxtResponse.Enabled = True
            TxtResponse.Focus()
        Else
            ChkResponse.Enabled = True
            TxtResponse.Text = ""
            TxtResponse.Enabled = False
            Button1.Enabled = True
            Button4.Enabled = True
            TxtUser.ReadOnly = False
            TxtVisitor.ReadOnly = False
        End If
    End Sub

    Private Sub ChkResponse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkResponse.CheckedChanged
        If ChkResponse.Checked = True Then
            ChkNum.Checked = False
            ChkNum.Enabled = False
        Else
            ChkNum.Enabled = True
        End If
    End Sub

    Private Sub ChkNum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNum.GotFocus
        ChkNum.BackColor = Color.LightGray
    End Sub

    Private Sub ChkNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ChkNum.Checked = True Then
                TxtResponse.Focus()
            Else
                ChkResponse.Focus()
            End If
        End If
    End Sub

    Private Sub ChkNum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNum.LostFocus
        ChkNum.BackColor = Me.BackColor
    End Sub

    Private Sub TxtResponse_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtResponse.KeyDown
        If e.KeyCode = Keys.Enter Then ChkResponse.Focus()
    End Sub

    Private Sub TxtResponse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtResponse.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or TxtResponse.Enabled = False Or TxtResponse.ReadOnly = True Then Exit Sub
        Dim frmlk As New Message_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtResponse.Focus()
        If IdKala <> 0 Then
            TxtResponse.Text = IdKala
            If Tmp_Namkala = "U" Then
                TxtUser.Text = Tmp_TwoGroup
                TxtIdUser.Text = Tmp_OneGroup
            Else
                TxtVisitor.Text = Tmp_TwoGroup
                TxtIdVisitor.Text = Tmp_OneGroup
            End If
        End If
    End Sub
End Class