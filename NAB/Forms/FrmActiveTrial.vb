Imports System.IO
Public Class FrmActiveTrial

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            OP.ShowDialog()
            If OP.FileName.ToString <> "" Then
                OP.FileName.ToString()

                If Not (File.Exists(UCase(OP.FileName.ToString()))) Then
                    MessageBox.Show("فایل مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Dim str As String = ""
                    str = File.ReadAllText(OP.FileName.ToString())
                    If Not String.IsNullOrEmpty(str) Then
                        TxtDay.Text = Trim(str)
                    End If
                End If

            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmActiveTrial", "Button3_Click")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RdoTime.Checked = True Then
            If String.IsNullOrEmpty(TxtDay.Text) Then
                MessageBox.Show("سریال فعال سازی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CheckSerial() = False Then Exit Sub
        End If
        If RdoLock.Checked = True Then
            My.Settings("Trial") = ""
            My.Settings.Save()
        Else
            My.Settings("Trial") = TxtDay.Text.Trim
            My.Settings.Save()
        End If
        Me.Close()
    End Sub

    Private Function CheckSerial() As Boolean
        Dim x() As String = TxtDay.Text.Split("-")
        If Not (x.Length <> 3) Then
            x(0) = x(0).Substring(0, x(0).Length - 1)
            x(1) = x(1).Substring(0, x(1).Length - 1)
            x(2) = x(2).Substring(0, x(2).Length - 1)
            Dim dat As String = GetMD5Open(StrToByteArray(x(1))) & "/" & GetMD5Open(StrToByteArray(x(2))) & "/" & GetMD5Open(StrToByteArray(x(0)))
            If CheckDate(dat) = False Then
                MessageBox.Show("شماره سریال نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return False
            Else
                If dat < GetDate() Then
                    MessageBox.Show("شماره سریال منسوخ شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return False
                Else
                    Return True
                End If
            End If
        Else
            MessageBox.Show("شماره سریال نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End If
    End Function

    Private Function GetMD5Open(ByVal strToOpen As Byte()) As String
        Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
        Dim Sec As New Security()
        key.IV = Sec.Kiv
        key.Key = Sec.Kkey
        Return Sec.StringDecrypt(strToOpen, key.CreateDecryptor)
    End Function

    Private Function StrToByteArray(ByVal str As String) As Byte()
        Dim x() As String = str.Split(".")
        Dim x1(x.Length - 1) As Byte
        Try
            For i As Integer = 0 To x.Length - 1
                x1(i) = CByte(x(i))
            Next
            Return x1
        Catch ex As Exception
            MessageBox.Show("شماره سریال نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return x1
        End Try
    End Function

    Private Sub TxtDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDay.KeyPress
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

    Private Sub FrmActiveTrial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F2 Then Call Button3_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F3 Then Call Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmActiveTrial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        RdoTime.Checked = True
    End Sub

    Private Sub RdoTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTime.CheckedChanged
        If RdoTime.Checked = True Then
            TxtDay.Clear()
            Button3.Enabled = True
        Else
            TxtDay.Clear()
            Button3.Enabled = False
        End If
    End Sub

    Private Sub RdoLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoLock.CheckedChanged
        If RdoLock.Checked = True Then
            TxtDay.Clear()
            Button3.Enabled = False
        Else
            TxtDay.Clear()
            Button3.Enabled = True
        End If
    End Sub
End Class