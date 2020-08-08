Imports System.Drawing
Public Class FrmSodBanki
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Agsat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnMohasebe.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnPrint.Enabled = True Then Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Button7_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If Button2.Enabled = True Then Button2_Click_1(Nothing, Nothing)
        End If
    End Sub
  
    Private Sub Only_Number_TextChange(ByVal MyTxtBox As TextBox, ByVal IsSplitWithComma As Boolean)
        If Not (CheckDigit(Format$(MyTxtBox.Text.Replace(",", "")))) Then
            MyTxtBox.Text = "1"
            Exit Sub
        End If
        If Not IsSplitWithComma Then Exit Sub
        Dim str As String
        If MyTxtBox.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(MyTxtBox.Text.Replace(",", ""))
            MyTxtBox.Text = Format$(Val(str), "###,###,###")
        Else
            MyTxtBox.Text = CDbl(MyTxtBox.Text)
        End If
    End Sub
    Private Sub Only_Number_Keypress(ByRef e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal MyTextBox As TextBox = Nothing, Optional ByVal IsMomaiezs As Boolean = False)
        e.Handled = True
        If IsMomaiezs Then
            If e.KeyChar = "." Then
                If InStr(MyTextBox.Text, ".") = False Then
                    e.KeyChar = "/"
                    e.Handled = False
                End If
            End If
        End If
        If e.KeyChar = Chr(&H8) Or IsNumeric(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TxtAsl.Text = "500000000"
        TxtModat.Text = "24"
        TxtFasele.Text = "1"
        TxtNerkh.Text = "21"
        TxtShomareGhest.Text = "24"
        ChkMohlat.Checked = False
    End Sub

    Private Sub TxtAsl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAsl.TextChanged
        Only_Number_TextChange(TxtAsl, True)
    End Sub
    Private Sub TxtAsl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAsl.KeyPress
        Only_Number_Keypress(e)
    End Sub
    Private Sub TxtGhest_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGhest.TextChanged
        Only_Number_TextChange(TxtGhest, True)
    End Sub
    Private Sub TxtGhest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAsl.KeyPress
        Only_Number_Keypress(e)
    End Sub
    Private Sub TxtR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtR.TextChanged
        Only_Number_TextChange(TxtR, True)
    End Sub
    Private Sub TxtR1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtR1.TextChanged
        Only_Number_TextChange(TxtR1, True)
    End Sub
    Private Sub TxtR2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtR2.TextChanged
        Only_Number_TextChange(TxtR2, True)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMohasebe.Click
        If TxtAsl.Text.Trim = "" Then
            MessageBox.Show("مبلغ تسهیلات را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtAsl.Focus()
            Exit Sub
        ElseIf TxtModat.Text.Trim = "" Then
            MessageBox.Show("مدت بازپرداخت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtModat.Focus()
            Exit Sub
        ElseIf TxtFasele.Text.Trim = "" Then
            MessageBox.Show("فاصله اقساط را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtFasele.Focus()
            Exit Sub
        ElseIf TxtNerkh.Text.Trim = "" Then
            MessageBox.Show("نرخ سود تسهیلات را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNerkh.Focus()
            Exit Sub
        End If
        TmpK = 0 : TmpA = 0 : TmpR1 = 0 : TmpR2 = 0 : TmpSoodAzGhest = 0 : TmpAslAzGhest = 0 : Tmp1 = 0 : Tmp2 = 0 : Tmp3 = 0
        TxtTedad.Text = K(CDbl(TxtModat.Text), CDbl(TxtFasele.Text))
        If ChkMohlat.Checked And TxtMohlat.Text.Trim <> "" Then
            TxtR1.Text = R1(CDbl(TxtAsl.Text), CDbl(TxtNerkh.Text), CDbl(TxtMohlat.Text))
        Else
            TxtR1.Text = 0
        End If
        TxtGhest.Text = A(CDbl(TxtAsl.Text), CDbl(TxtNerkh.Text), CDbl(TxtFasele.Text))
        TxtR2.Text = R2(CDbl(TxtAsl.Text))
        TxtR.Text = TmpR1 + TmpR2
        TxtSoodAzGhest.Text = SoodAzGhest(CDbl(TxtAsl.Text), CDbl(TxtShomareGhest.Text))
        TxtAslAzGhest.Text = AslAzGhest(CDbl(TxtAsl.Text), CDbl(TxtShomareGhest.Text))
    End Sub
    Private Sub TxtSoodAzGhest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSoodAzGhest.TextChanged
        Only_Number_TextChange(TxtSoodAzGhest, True)
    End Sub
    Private Sub TxtAslAzGhest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAslAzGhest.TextChanged
        Only_Number_TextChange(TxtAslAzGhest, True)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Call Button1_Click(Nothing, Nothing)
            Dim FPrint As New FrmPrint
            Dim rep As New Crp_Wam
            Dim ds As New DSWam
            For i = 0 To Val(TxtTedad.Text)
                ds.DT_Wam.AddDT_WamRow(TxtAsl.Text, TxtModat.Text + " ماه", TxtFasele.Text, TxtNerkh.Text, TxtMohlat.Text, TxtTedad.Text, TxtGhest.Text, TxtR1.Text, TxtR2.Text, TxtR.Text, i, SoodAzGhest(CDbl(TxtAsl.Text), i + 1))
            Next
            rep.SetDataSource(ds.Tables(0))
            FPrint.CRV.ReportSource = rep
            FPrint.CHoose = "SODBANK"
            FPrint.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ChkMohlat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMohlat.CheckedChanged
        TxtMohlat.Enabled = ChkMohlat.Checked
    End Sub
    Private Sub TxtModat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtModat.KeyPress
        Only_Number_Keypress(e)
    End Sub
    Private Sub TxtFasele_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFasele.KeyPress
        Only_Number_Keypress(e)
    End Sub
    Private Sub TxtNerkh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNerkh.KeyPress
        Only_Number_Keypress(e, TxtNerkh, True)
    End Sub
    Private Sub TxtShomareGhest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtShomareGhest.KeyPress
        Only_Number_Keypress(e)
    End Sub
    Private Sub TxtMohlat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMohlat.KeyPress
        Only_Number_Keypress(e)
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub TxtModat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtModat.TextChanged
        Only_Number_TextChange(TxtModat, False)
    End Sub
    Private Sub TxtFasele_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFasele.TextChanged
        Only_Number_TextChange(TxtFasele, False)
    End Sub
    Private Sub TxtNerkh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNerkh.TextChanged
        Only_Number_TextChange(TxtNerkh, False)
    End Sub
    Private Sub TxtShomareGhest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShomareGhest.TextChanged
        Only_Number_TextChange(TxtShomareGhest, False)
    End Sub
    Private Sub TxtMohlat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMohlat.TextChanged
        Only_Number_TextChange(TxtMohlat, False)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Frm_Wam_Formul.ShowDialog()
    End Sub

    Private Sub FrmSodBanki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next

    End Sub
End Class
