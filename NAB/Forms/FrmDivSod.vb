Public Class FrmDivSod
    Dim darsad As Long = 0

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "12.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmDivSod_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtDar.Focus()
    End Sub

    Private Sub FrmDivSod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If CDbl(TxtMon.Text) = 0 Then
            MessageBox.Show("مبلغی تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMon.Focus()
            Exit Sub
        End If

        If CDbl(TxtSarmayeh.Text) >= 0 Then
            If CDbl(TxtMon.Text) > CDbl(TxtSarmayeh.Text) Then
                MessageBox.Show("سهم سرمایه گذار بیشتر از کل سود و زیان است لطفاآن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMon.Focus()
                Exit Sub
            End If
        Else
            If CDbl(TxtMon.Text) < CDbl(TxtSarmayeh.Text) Then
                MessageBox.Show("سهم سرمایه گذار بیشتر از کل سود و زیان است لطفاآن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMon.Focus()
                Exit Sub
            End If
        End If

        If CDbl(TxtSarmayeh.Text) > 0 And CDbl(TxtMon.Text) < 0 Then
            MessageBox.Show("سهم سرمایه گذار اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMon.Focus()
            Exit Sub
        End If

        If CDbl(TxtSarmayeh.Text) < 0 And CDbl(TxtMon.Text) > 0 Then
            MessageBox.Show("سهم سرمایه گذار اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMon.Focus()
            Exit Sub
        End If

        LAdd.Text = "0"
        TxtMon.Text = CDbl(TxtMon.Text) * (-1)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TxtDar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDar.GotFocus
        darsad = 0
        TxtDar.SelectAll()
    End Sub

    Private Sub TxtDar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDar.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon.Focus()
    End Sub

    Private Sub TxtDar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDar.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Then
            If InStr(TxtDar.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDar.LostFocus
        If CDbl(TxtDar.Text) > 100 Then TxtDar.Text = 100
        TxtDar.Text = Math.Round(CDbl(TxtDar.Text), 2)
    End Sub

    Private Sub TxtDar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDar.TextChanged
        If darsad = 0 Then
            Try
                If Not (CheckDigit(TxtDar.Text)) Then
                    TxtDar.Text = 0
                    TxtMon.Text = 0
                    TxtDar.SelectAll()
                    Exit Sub
                End If
                If Not TxtDar.Text.Trim.Contains(".") Then TxtDar.Text = CDbl(TxtDar.Text)
                If CDbl(TxtDar.Text) > 100 Then TxtDar.Text = 100
                TxtMon.Text = Format((CDbl(TxtDar.Text) * CDbl(TxtSarmayeh.Text) / 100), "###,###")
                If String.IsNullOrEmpty(TxtMon.Text.Trim) Then TxtMon.Text = "0"
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMon.GotFocus
        darsad = 1
        TxtMon.SelectAll()
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
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
        If e.KeyChar = "-" Then
            If InStr(TxtMon.Text, "-") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtMon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMon.LostFocus
        If CDbl(TxtDar.Text) > 100 Then TxtDar.Text = 100
        TxtDar.Text = Math.Round(CDbl(TxtDar.Text), 2)
    End Sub

    Private Sub TxtMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon.TextChanged
        If darsad = 1 Then
            Try
                If Not (CheckDigit(Format$(TxtMon.Text.Replace(",", "")))) Then
                    TxtMon.Text = "0"
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
                '//////////////
                If Not TxtDar.Text.Trim.Contains(".") Then TxtDar.Text = CDbl(TxtDar.Text)
                Dim tmp As Double = ((CDbl(TxtMon.Text) * 100) / CDbl(TxtSarmayeh.Text))
                TxtDar.Text = Math.Round(tmp, 2)
                If CDbl(TxtDar.Text) > 100 Then TxtDar.Text = 100

                If CDbl(TxtSarmayeh.Text) >= 0 Then
                    If CDbl(TxtMon.Text) > CDbl(TxtSarmayeh.Text) Then TxtMon.Text = TxtSarmayeh.Text
                Else
                    If CDbl(TxtMon.Text) < CDbl(TxtSarmayeh.Text) Then TxtMon.Text = TxtSarmayeh.Text
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub FrmDivSod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next

    End Sub
End Class