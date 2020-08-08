Imports System.Data.SqlClient
Public Class FrmMessageCenter
    Dim dt As New DataTable
    Dim dv As DataView

    Private Sub FrmMessageCenter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmMessageCenter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F153")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    Try
                        If Access_Form.Substring(2, 1) = 0 Then
                            Button1.Enabled = False
                        End If
                    Catch ex As Exception
                        Button1.Enabled = False
                    End Try

                    Try
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnDell.Enabled = False
                        End If
                    Catch ex As Exception
                        BtnDell.Enabled = False
                    End Try

                    Try
                        If Access_Form.Substring(4, 1) = 0 Then
                            BtnNew.Enabled = False
                        End If
                    Catch ex As Exception
                        BtnNew.Enabled = False
                    End Try

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مرکز پیام", "ورود", "", "")
                End If
            End If
        Else
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مرکز پیام", "ورود", "", "")
        End If

        ListV.Focus()
        ListV.Items(0).Selected = True
        DGV1.Columns("Cln_Subject").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            Using frm As New FrmMessage
                frm.Edit = 0
                frm.Kind = 1
                frm.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessageCenter", "BtnNew_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub ReadInBox()
        Try
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT [Id],[Sender_IdUser],[Sender_IdVisitor],Sender_Nam=(CASE WHEN (Sender_IdUser IS NOT NULL) THEN (SELECT Define_User.Nam FROM Define_User WHERE Define_User.id=Sender_IdUser ) ELSE (SELECT Define_Visitor.Nam FROM Define_Visitor WHERE Define_Visitor.id=Sender_IdVisitor)END),[Reciver_IdUser],[Reciver_IdVisitor],Reciver_Nam=(CASE WHEN (Reciver_IdUser IS NOT NULL) THEN (SELECT Define_User.Nam FROM Define_User WHERE Define_User.id=Reciver_IdUser ) ELSE (SELECT Define_Visitor.Nam FROM Define_Visitor WHERE Define_Visitor.id=Reciver_IdVisitor)END),[Subject],[Message],[C_Date],[R_Date],[Chk],[Kind],[Response],[RChk] FROM MessageCenter WHERE Reciver_IdUser =" & Id_User & " AND R_Date <='" & GetDate() & "'", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dv = dt.DefaultView
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessageCenter", "ReadInBox")
            Me.Close()
        End Try
    End Sub

    Private Sub ReadOutBox()
        Try
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT [Id],[Sender_IdUser],[Sender_IdVisitor],Sender_Nam=(CASE WHEN (Sender_IdUser IS NOT NULL) THEN (SELECT Define_User.Nam FROM Define_User WHERE Define_User.id=Sender_IdUser ) ELSE (SELECT Define_Visitor.Nam FROM Define_Visitor WHERE Define_Visitor.id=Sender_IdVisitor)END),[Reciver_IdUser],[Reciver_IdVisitor],Reciver_Nam=(CASE WHEN (Reciver_IdUser IS NOT NULL) THEN (SELECT Define_User.Nam FROM Define_User WHERE Define_User.id=Reciver_IdUser ) ELSE (SELECT Define_Visitor.Nam FROM Define_Visitor WHERE Define_Visitor.id=Reciver_IdVisitor)END),[Subject],[Message],[C_Date],[R_Date],[Chk],[Kind],[Response],[RChk] FROM MessageCenter WHERE Sender_IdUser =" & Id_User, ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dv = dt.DefaultView
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessageCenter", "ReadOutBox")
            Me.Close()
        End Try
    End Sub

    Private Sub ListV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListV.SelectedIndexChanged
        Me.RefreshBank()
    End Sub

    Private Sub DGV1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.DoubleClick
        If DGV1.RowCount <= 0 Then Exit Sub
        Call Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        
        If DGV1.Item("Cln_Read", e.RowIndex).Value = False Then
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gainsboro
        Else
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End If
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV1.RowCount <= 0 Then
            MessageBox.Show("پیامی برای " & Button1.Text & " وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Try
            Using frm As New FrmMessage
                With frm
                    .Button1.Enabled = False
                    .Button4.Enabled = False

                    .TxtUser.ReadOnly = True
                    .TxtVisitor.ReadOnly = True

                    .ChkNum.Enabled = False
                    .ChkResponse.Enabled = False

                    If ListV.Items(0).Selected = True Or (ListV.Items(1).Selected = True And DGV1.Item("Cln_Read", DGV1.CurrentRow.Index).Value = True) Then
                        .Button5.Visible = False
                        .Button6.Visible = False

                        .Button5.Enabled = False
                        .Button6.Enabled = False

                        .TxtDateRecive.Enabled = False
                        .TxtDateSend.Enabled = False

                        .TxtSubject.ReadOnly = True
                        .TxtMessage.ReadOnly = True
                        .TxtResponse.ReadOnly = True

                        .ToolCancel.Visible = False
                        .ToolSend.Visible = False

                        .Kind = 0
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مرکز پیام", "نمایش", "نمایش پیام شماره " & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value, "")
                    ElseIf ListV.Items(1).Selected = True Then
                        .Kind = 1
                    End If

                    .Edit = DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value

                    .TxtDateSend.ThisText = DGV1.Item("Cln_Dat", DGV1.CurrentRow.Index).Value
                    .TxtDateRecive.ThisText = DGV1.Item("Cln_RDate", DGV1.CurrentRow.Index).Value

                    If Not DGV1.Item("Reciver_IdVisitor", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                        .TxtVisitor.Text = DGV1.Item("Cln_Reciver", DGV1.CurrentRow.Index).Value
                        .TxtIdVisitor.Text = DGV1.Item("Reciver_IdVisitor", DGV1.CurrentRow.Index).Value
                    Else
                        .TxtVisitor.Text = ""
                        .TxtIdVisitor.Text = ""
                    End If

                    If Not DGV1.Item("Reciver_IdUser", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                        .TxtUser.Text = DGV1.Item("Cln_Reciver", DGV1.CurrentRow.Index).Value
                        .TxtIdUser.Text = DGV1.Item("Reciver_IdUser", DGV1.CurrentRow.Index).Value
                    Else
                        .TxtUser.Text = ""
                        .TxtIdUser.Text = ""
                    End If

                    If Not DGV1.Item("Response", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                        .ChkNum.Checked = True
                        .TxtResponse.Text = DGV1.Item("Response", DGV1.CurrentRow.Index).Value
                    Else
                        .TxtResponse.Text = ""
                        .ChkNum.Checked = False
                    End If

                    .ChkResponse.Checked = DGV1.Item("RChk", DGV1.CurrentRow.Index).Value
                    .TxtSubject.Text = DGV1.Item("Cln_Subject", DGV1.CurrentRow.Index).Value
                    .TxtMessage.Text = DGV1.Item("Cln_Message", DGV1.CurrentRow.Index).Value
                    .ShowDialog()
                End With
               
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessageCenter", "BtnNew_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "MsgCenter.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True And Button1.Visible = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnDell.Enabled = True And BtnDell.Visible = True Then BtnDell_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnNew.Enabled = True And BtnNew.Visible = True Then BtnNew_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
           Me.RefreshBank()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnDell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDell.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("پیامی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            If MessageBox.Show("آیا برای حذف پیام مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.DellMessage()
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessageCenter", "BtnDell_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub DellMessage()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("DELETE FROM MessageCenter WHERE Id=" & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مرکز پیام", "حذف", "حذف پیام شماره " & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value, "")
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            If Err.Number = 5 Then
                MessageBox.Show("پیام قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMessageCenter", "DellMessage")
            End If
        End Try
    End Sub

    Private Sub RefreshBank()
        If ListV.Items(0).Selected = True Then
            Button1.Text = "نمایش"
            ToolEdit.Text = "F2 " & Button1.Text
            BtnNew.Visible = False
            ToolNew.Visible = False
            Me.ReadInBox()
        ElseIf ListV.Items(1).Selected = True Then
            Button1.Text = "ویرایش"
            ToolEdit.Text = "F2 " & Button1.Text
            BtnNew.Visible = True
            ToolNew.Visible = True
            Me.ReadOutBox()
        End If
    End Sub
End Class