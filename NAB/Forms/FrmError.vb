Imports System.Windows.Forms
Imports System.IO

Public Class FrmError

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnexit.Click
        Me.Close()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmError_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sw As StreamWriter = Nothing
        Try
            SF.FileName = "Err_" & GetDate().Replace("/", "-") & "  " & Date.Now.ToLongTimeString.Replace(":", "-")

            If SF.ShowDialog = DialogResult.OK Then
                sw = New StreamWriter(SF.FileName, False, System.Text.Encoding.UTF8, 1)
                sw.Write(TxtError.Text)
                sw.Close()
            End If
            MessageBox.Show("گزارش خطا با موفقیت ذخیره شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("گزارش خطا ذخیره نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Not (sw Is Nothing) Then
                sw.Close()
            End If
        End Try
    End Sub

    Private Sub FrmError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
    End Sub
End Class
