Public Class FrmHavalehBank

    Private Sub TxtBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBank.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then TxtMon.Focus()
    End Sub

    Private Sub TxtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.LState.Text = ""
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtBank.Focus()
        If IdKala <> 0 Then
            TxtBank.Text = Tmp_Namkala
            TxtIdBank.Text = IdKala
        Else
            TxtBank.Text = ""
            TxtIdBank.Text = ""
        End If
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub TxtMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon.KeyPress
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

    Private Sub TxtMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon.Text.Replace(",", "")))) Then
                TxtMon.Text = "0"
                TxtMon.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon.Text.Replace(",", ""))
                TxtMon.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon.Text = CDbl(TxtMon.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        LAdd.Text = "0"
        Me.Close()
    End Sub

    Private Sub FrmHavalehBank_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtBank.Focus()
    End Sub

    Private Sub FrmHavalehBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmHavalehBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LAdd.Text = "0"
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If String.IsNullOrEmpty(TxtBank.Text.Trim) Or String.IsNullOrEmpty(TxtIdBank.Text.Trim) Then
            MessageBox.Show("بانک را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBank.Focus()
            Exit Sub
        End If
        If CDbl(TxtMon.Text.Trim) <= 0 Then
            MessageBox.Show("مبلغ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMon.Focus()
            Exit Sub
        End If
        LAdd.Text = "1"
        Me.Close()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetMoney.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub
End Class