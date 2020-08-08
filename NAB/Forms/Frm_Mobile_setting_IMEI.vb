Imports System.Data.SqlClient
Public Class Frm_Mobile_setting_IMEI
    Public str_type = "save"

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If String.IsNullOrEmpty(TextBox2.Text) Then
                MessageBox.Show("شناسه را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox2.Focus()
                Exit Sub
            End If

            Dim Query As String = ""

            If String.IsNullOrEmpty(str_type) Then
                Query = "Insert Into Mobile_Setting (S1,S2,S3,S4,S5,S6) VALUES (@S1,@S2,@S3,@S4,@S5,@S6)"
            Else
                Query = "Update Mobile_Setting SET S1=@S1,S2=@S2,S3=@S3,S4=@S4,S5=@S5,S6=@S6 WHERE S1=@OldS1"
            End If

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Query, ConectionBank)
                cmd.Parameters.AddWithValue("@S1", SqlDbType.NVarChar).Value = TextBox2.Text.Trim
                cmd.Parameters.AddWithValue("@S2", SqlDbType.NVarChar).Value = ChkS2.Checked
                cmd.Parameters.AddWithValue("@S3", SqlDbType.NVarChar).Value = ChkS3.Checked
                cmd.Parameters.AddWithValue("@S4", SqlDbType.NVarChar).Value = ChkS4.Checked
                cmd.Parameters.AddWithValue("@S5", SqlDbType.NVarChar).Value = ChkS5.Checked
                cmd.Parameters.AddWithValue("@S6", SqlDbType.NVarChar).Value = ChkS6.Checked
                If Not String.IsNullOrEmpty(str_type) Then cmd.Parameters.AddWithValue("@OldS1", SqlDbType.NVarChar).Value = str_type
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Mobile_setting_IMEI", "Button3_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class