Imports System.Data.SqlClient

Public Class Frm_Mobile_Imei

    Private Sub Frm_Mobile_Imei_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt And e.Control And e.Shift And e.KeyCode = Keys.F11 Then
            Using frm_u As New Dialog1
                frm_u.EnterValue = LblNumberOfCurrentUser.Text
                frm_u.ShowDialog()
            End Using
            Sel_all()
        End If
    End Sub

    Private Sub Frm_All_Mobile_Imei_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not UCase(NamUser) = "ADMIN" Then
            MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            Sel_all()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count >= Convert.ToInt16(LblNumberOfCurrentUser.Text) Then
            Button1.Enabled = False
            Exit Sub
        End If

        Using Frm_S As New Frm_Mobile_setting_IMEI
            Frm_S.str_type = ""
            Frm_S.ShowDialog()
        End Using
        Sel_all()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If DataGridView1.RowCount <= 0 Then
                MessageBox.Show("گزینه ایی برای حذف انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("آیا می خواهید این دستگاه حذف گردد؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then Exit Sub
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("Delete From  Mobile_Setting  where s1=@S1", ConectionBank)
                cmd.Parameters.AddWithValue("@S1", SqlDbType.NVarChar).Value = DataGridView1.Item("Cln_S1", DataGridView1.CurrentRow.Index).Value
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Sel_all()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Mobile_Imei", "Button3_Click")
            Sel_all()
        End Try
    End Sub
    Private Sub Sel_all()
        Try
            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("Select S1,CAST(S2 AS Bit) AS S2,CAST(S3 AS Bit) AS S3,CAST(S4 AS Bit) AS S4,CAST(S5 AS Bit) AS S5,CAST(S6 AS Bit) AS S6 From Mobile_Setting", ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            DataGridView1.DataSource = dt

            Dim dtUser As New DataTable
            Using cmd As New SqlCommand("SELECT NumberOfUser FROM DB_Info", ConectionBank)
                cmd.CommandTimeout = 0
                dtUser.Load(cmd.ExecuteReader)
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()


            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            If dtUser.Rows(0)(0) Is DBNull.Value Then
                LblNumberOfCurrentUser.Text = 0
            Else
                LblNumberOfCurrentUser.Text = Sec.StringDecrypt(dtUser.Rows(0)(0), key.CreateDecryptor)
            End If

            If DataGridView1.Rows.Count <= Convert.ToInt16(LblNumberOfCurrentUser.Text) Then Button1.Enabled = True

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Mobile_Imei", "Sel_all")
            Me.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If DataGridView1.RowCount <= 0 Then
                MessageBox.Show("گزینه ایی برای ویرایش انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using Frm_S As New Frm_Mobile_setting_IMEI
                Frm_S.str_type = DataGridView1.Item("Cln_S1", DataGridView1.CurrentRow.Index).Value
                Frm_S.TextBox2.Text = DataGridView1.Item("Cln_S1", DataGridView1.CurrentRow.Index).Value
                Frm_S.ChkS2.Checked = DataGridView1.Item("Cln_S2", DataGridView1.CurrentRow.Index).Value
                Frm_S.ChkS3.Checked = DataGridView1.Item("Cln_S3", DataGridView1.CurrentRow.Index).Value
                Frm_S.ChkS4.Checked = DataGridView1.Item("Cln_S4", DataGridView1.CurrentRow.Index).Value
                Frm_S.ChkS5.Checked = DataGridView1.Item("Cln_S5", DataGridView1.CurrentRow.Index).Value
                Frm_S.ChkS6.Checked = DataGridView1.Item("Cln_S6", DataGridView1.CurrentRow.Index).Value
                Frm_S.ShowDialog()
            End Using
            Sel_all()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Mobile_Imei", "Button2_Click")
            Me.Close()
        End Try
    End Sub
End Class