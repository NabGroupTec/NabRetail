Imports System.Data.SqlClient
Public Class DefineUser
    Dim edt As Integer
    Dim str_name, str_fam As String
    Dim ds As New DataSet
    Dim str As String = "select * from Define_User"
    Dim dta As New SqlDataAdapter(str, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub DefineUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Customer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not UCase(NamUser) = "ADMIN" Then
            MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Me.fill_dgv()
        DGV.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If AllowEdit < 0 Then
            MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf AllowEdit = 1 Then
            cmdadd.Enabled = False
            cmdedit.Enabled = False
            cmddel.Enabled = False
        End If
    End Sub
    Private Sub fill_dgv()
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_User")

            If Not ds.Tables("Define_User").Columns.Contains("P") Then ds.Tables("Define_User").Columns.Add("P", Type.GetType("System.String"))
            If Not ds.Tables("Define_User").Columns.Contains("LogIn") Then ds.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds.Tables("Define_User").Rows.Count - 1
                ds.Tables("Define_User").Rows(i).Item("P") = Sec.StringDecrypt(ds.Tables("Define_User").Rows(i).Item("Pas"), key.CreateDecryptor)
                ds.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next
            DGV.AutoGenerateColumns = False
            DGV.DataSource = ds.Tables("Define_User")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUser", "fill_dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("هيچ کاربری براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        If DGV.Item("Cln_LogIn", DGV.CurrentRow.Index).Value = True Then
            MessageBox.Show("کاربر انتخابی شما در شبکه حضور دارد و فعلا قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        If UCase(DGV.Item("cln_name", DGV.CurrentRow.Index).Value) = "ADMIN" Or CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) = 1 Then
            MessageBox.Show("کاربر انتخابی شما مدیر شبکه است و قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد کاربر جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = DGV.Item("cln_name", DGV.CurrentRow.Index).Value
                Me.Enabled = False
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using cmd As New SqlCommand("DELETE FROM Define_User WHERE Id=" & CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value), ConectionBank)
                    cmd.ExecuteNonQuery()
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف کاربر", "حذف", "حذف کاربر :" & nam, "")

                Me.RefreshBank()
                Me.Enabled = True
            Catch ex As Exception
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                If Err.Number = 5 Then
                    MessageBox.Show("کاربر انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUser", "cmddel_Click")
                End If
                Me.RefreshBank()
                Me.Enabled = True
            End Try
        End If
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            Using FrmUser As New Define_AddUser
                FrmUser.edt = 0
                FrmUser.ShowDialog()
                Me.RefreshBank()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUser", "cmdadd_Click")
            Me.RefreshBank()
        End Try
    End Sub
   
    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("هيچ کاربري براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If

        Try
            Using FrmUser As New Define_AddUser
                FrmUser.edt = CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value)
                FrmUser.Txtname.Text = DGV.Item("cln_name", DGV.CurrentRow.Index).Value
                FrmUser.str_name = DGV.Item("cln_name", DGV.CurrentRow.Index).Value
                FrmUser.TxtP.Text = DGV.Item("Cln_P", DGV.CurrentRow.Index).Value
                If UCase(DGV.Item("cln_name", DGV.CurrentRow.Index).Value) = "ADMIN" Or CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) = 1 Then FrmUser.Txtname.Enabled = False
                FrmUser.ShowDialog()
                Me.RefreshBank()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUser", "cmdedit_Click")
            Me.RefreshBank()
        End Try

    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub RefreshBank()
        Try
            ds.Clear()
            dta.Fill(ds, "Define_User")

            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            If Not ds.Tables("Define_User").Columns.Contains("P") Then ds.Tables("Define_User").Columns.Add("P", Type.GetType("System.String"))
            If Not ds.Tables("Define_User").Columns.Contains("LogIn") Then ds.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds.Tables("Define_User").Rows.Count - 1
                ds.Tables("Define_User").Rows(i).Item("P") = Sec.StringDecrypt(ds.Tables("Define_User").Rows(i).Item("Pas"), key.CreateDecryptor)
                ds.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUser", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "User.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

End Class