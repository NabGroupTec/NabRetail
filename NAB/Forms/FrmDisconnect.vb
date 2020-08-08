Public Class FrmDisconnect

    Private Sub FrmDisconnect_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Application.DoEvents()
        If m_DCW.IsConnect Then
            Application.DoEvents()
            Me.Hide()
        End If
    End Sub

    Private Sub FrmDisconnect_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMain.Enabled = True
    End Sub

    Private Sub FrmDisconnect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnexit.Click
        Try
            QExit = True
            System.Windows.Forms.Application.Exit()
        Catch ex As Exception
            End
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            If Btnexit.Enabled = True Then Btnexit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmDisconnect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Application.DoEvents()
        If m_DCW.IsConnect Then
            Application.DoEvents()
            Me.Hide()
        Else
            Opacity = 100
            Application.DoEvents()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Beep()
        If m_DCW.IsConnect Then
            Me.Hide()
        End If
        Application.DoEvents()
    End Sub
End Class