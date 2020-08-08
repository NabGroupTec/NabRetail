Public Class FrmEditRasChk

    Private Sub TxtPayDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayDate.KeyDowned
        If e.KeyCode = Keys.Enter Then Txtmon.Focus()
    End Sub

    Private Sub TxtPayDate_TextChanging(ByVal sender As Object, ByVal e As String) Handles TxtPayDate.TextChanging
        Try
            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                LDate.Text = ""
                LTime.Text = "0" & " روز "
            Else
                Dim StringDate As New NumberToString
                LDate.Text = StringDate.DateToPersianNonvertor(StringDate.PersianToDateConvertor(TxtPayDate.ThisText))
                LTime.Text = SUBDAY(TxtPayDate.ThisText, LOne.Text) & " روز "
            End If
        Catch ex As Exception
            LDate.Text = ""
        End Try
    End Sub

    Private Sub Txtmon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmon.KeyDown
        If e.KeyCode = Keys.Enter Then Button1.Focus()
    End Sub

    Private Sub Txtmon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmon.KeyPress
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

    Private Sub Txtmon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtmon.TextChanged
        If Not (CheckDigit(Format$(Txtmon.Text.Replace(",", "")))) Then
            Txtmon.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If Txtmon.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(Txtmon.Text.Replace(",", ""))
            Txtmon.Text = Format$(Val(str), "###,###,###")
        Else
            Txtmon.Text = CDbl(Txtmon.Text)
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Ledit.Text = "0"
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Ledit.Text = "1"
        Me.Close()
    End Sub

    Private Sub FrmEditRasChk_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtPayDate.Focus()
    End Sub

    Private Sub FrmEditRasChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmEditRasChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Ledit.Text = "0"
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnOk.Enabled = True Then BtnOk_Click(Nothing, Nothing)
        End If
    End Sub
End Class