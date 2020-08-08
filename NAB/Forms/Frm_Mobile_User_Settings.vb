Imports System.Data.SqlClient

Public Class Frm_Mobile_User_Settings

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("update DB_Info set NumberOfUser=@NumberOfUSer", ConectionBank)
                cmd.Parameters.AddWithValue("@NumberOfUSer", SqlDbType.VarBinary).Value = Sec.StringEncrypt(NumValue.Value, key.CreateEncryptor)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Mobile_User_Settings", "Button1_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class