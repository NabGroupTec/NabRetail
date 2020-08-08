Imports System.Windows.Forms

Public Class Dialog1
    Public EnterValue As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(TxtPeriod.Text.Trim) Then
            MessageBox.Show("کلمه فعال سازی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Not (TxtPeriod.Text.Trim = ChrW(83) & ChrW(75) & ChrW(89) & ChrW(32) & ChrW(66) & ChrW(76) & ChrW(85) & ChrW(69)) Then
            MessageBox.Show("کلمه فعال سازی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtPeriod.Focus()
        Else
            If String.IsNullOrEmpty(EnterValue) Then
                Using frm As New FrmActiveTrial
                    frm.ShowDialog()
                End Using
            Else
                Using frm_u As New Frm_Mobile_User_Settings
                    frm_u.LblNumberOfCurrentUser.Text = EnterValue
                    frm_u.ShowDialog()
                End Using
            End If
            Me.Close()
        End If
    End Sub

    Private Sub TxtPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPeriod.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnOk_Click(Nothing, Nothing)
    End Sub

    Private Sub Dialog1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then Call BtnOk_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F3 Then Call Button1_Click(Nothing, Nothing)
        If e.KeyCode = Keys.Escape Then Call Button1_Click(Nothing, Nothing)
    End Sub
End Class
