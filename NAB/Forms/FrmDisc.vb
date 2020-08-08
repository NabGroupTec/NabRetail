Imports System.Data.SqlClient
Public Class FrmDisc

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        LAdd.Text = "0"
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            LAdd.Text = "1"
            If String.IsNullOrEmpty(LIdChk.Text) Then
                Me.Close()
            Else
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim sql As String = ""
                If LState.Text = "CHK" Then
                    sql = "UPDATE Chk_Get_Pay SET Disc=N'" & TxtDisc.Text.Trim & "' WHERE Id =" & CLng(LIdChk.Text)
                ElseIf LState.Text = "Wanted_Frosh" Then
                    sql = "UPDATE Wanted_Frosh SET Disc=N'" & TxtDisc.Text.Trim & "' WHERE IdFactor =" & CLng(LIdChk.Text)
                ElseIf LState.Text = "Wanted_Kharid" Then
                    sql = "UPDATE Wanted_Kharid SET Disc=N'" & TxtDisc.Text.Trim & "' WHERE IdFactor =" & CLng(LIdChk.Text)
                End If
                Using CMD As New SqlCommand(sql, ConectionBank)
                    CMD.ExecuteNonQuery()
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDisc", "BtnSave_Click")
            Me.Close()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmDisc_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtDisc.Focus()
    End Sub

    Private Sub FrmDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmDisc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LAdd.Text = "0"
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub
End Class