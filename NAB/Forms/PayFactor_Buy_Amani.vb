Imports System.Data.SqlClient
Imports System.Transactions
Public Class PayFactor_Buy_Amani
    Dim darsad As Long = 0
    Dim ds_Box As New DataSet
    Dim dta_Box As New SqlDataAdapter()
    Dim dt As New DataTable

    Private Sub PayFactor_Buy_Amani_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtDecDarsad.Focus()
    End Sub

    Private Sub PayFactor_Buy_Amani_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnCancle.Enabled = False And LOk.Text = "0" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub PayFactor_Buy_Amani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub TxtDecDarsad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecDarsad.GotFocus
        darsad = 0
        TxtDecDarsad.SelectAll()
    End Sub

    Private Sub TxtDecDarsad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDecDarsad.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDecMon.Focus()
    End Sub

    Private Sub TxtDecDarsad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecDarsad.KeyPress
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
            If InStr(TxtDecDarsad.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDecDarsad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecDarsad.LostFocus
        If CDbl(TxtDecDarsad.Text) > 100 Then TxtDecDarsad.Text = 100
        TxtDecDarsad.Text = Math.Round(CDbl(TxtDecDarsad.Text), 2)
    End Sub

    Private Sub TxtDecDarsad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecDarsad.TextChanged
        If darsad = 0 Then
            Try
                If Not (CheckDigit(TxtDecDarsad.Text)) Then
                    TxtDecDarsad.Text = 0
                    TxtDecMon.Text = 0
                    TxtDecDarsad.SelectAll()
                    Exit Sub
                End If
                If Not TxtDecDarsad.Text.Trim.Contains(".") Then TxtDecDarsad.Text = CDbl(TxtDecDarsad.Text)
                If CDbl(TxtDecDarsad.Text) > 100 Then TxtDecDarsad.Text = 100
                TxtDecMon.Text = Format((CDbl(TxtDecDarsad.Text) * CDbl(TxtFacMon.Text) / 100), "###,###")
                If String.IsNullOrEmpty(TxtDecMon.Text.Trim) Then TxtDecMon.Text = "0"
                Me.CalCulateMon()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtAddDarsad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddDarsad.GotFocus
        darsad = 0
        TxtAddDarsad.SelectAll()
    End Sub

    Private Sub TxtAddDarsad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAddDarsad.KeyDown
        If e.KeyCode = Keys.Enter Then TxtAddMon.Focus()
    End Sub

    Private Sub TxtAddDarsad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddDarsad.KeyPress
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
            If InStr(TxtAddDarsad.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtAddDarsad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddDarsad.LostFocus
        If CDbl(TxtAddDarsad.Text) > 100 Then TxtAddDarsad.Text = 100
        TxtAddDarsad.Text = Math.Round(CDbl(TxtAddDarsad.Text), 2)
    End Sub

    Private Sub TxtAddDarsad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddDarsad.TextChanged
        If darsad = 0 Then
            Try
                If Not (CheckDigit(TxtAddDarsad.Text)) Then
                    TxtAddDarsad.Text = 0
                    TxtAddMon.Text = 0
                    TxtAddDarsad.SelectAll()
                    Exit Sub
                End If
                If Not TxtAddDarsad.Text.Trim.Contains(".") Then TxtAddDarsad.Text = CDbl(TxtAddDarsad.Text)
                If CDbl(TxtAddDarsad.Text) > 100 Then TxtAddDarsad.Text = 100
                TxtAddMon.Text = Format((CDbl(TxtAddDarsad.Text) * CDbl(TxtFacMon.Text) / 100), "###,###")
                If String.IsNullOrEmpty(TxtAddMon.Text.Trim) Then TxtAddMon.Text = "0"
                Me.CalCulateMon()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtDiscountC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountC.GotFocus
        darsad = 1
        TxtDiscountC.SelectAll()
    End Sub

    Private Sub TxtDiscountC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscountC.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then
                TxtDiscountC.Text += CDbl(LMandeh.Text)
            ElseIf CDbl(LMandeh.Text) = 0 And CDbl(TxtLend.Text) > 0 Then
                TxtDiscountC.Text += CDbl(TxtLend.Text)
                TxtLend.Text = 0
            End If
        End If
    End Sub

    Private Sub TxtDiscountC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDiscountC.KeyPress
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

    Private Sub TxtDiscountC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountC.LostFocus
        If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
        TxtDarDisC.Text = Math.Round(CDbl(TxtDarDisC.Text), 2)
    End Sub

    Private Sub TxtDiscountC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountC.TextChanged
        If darsad = 1 Then
            Try
                If Not (CheckDigit(Format$(TxtDiscountC.Text.Replace(",", "")))) Then
                    TxtDiscountC.Text = "0"
                    TxtDarDisC.Text = "0"
                    TxtDiscountC.SelectAll()
                    Exit Sub
                End If
                Dim str As String
                If TxtDiscountC.Text.Length > 3 Then
                    SendKeys.Send("{end}")
                    str = Format$(TxtDiscountC.Text.Replace(",", ""))
                    TxtDiscountC.Text = Format$(Val(str), "###,###,###")
                Else
                    TxtDiscountC.Text = CDbl(TxtDiscountC.Text)
                End If
                '//////////////
                If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)
                Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / CDbl(TxtEndMon.Text))
                TxtDarDisC.Text = Math.Round(tmp, 2)
                If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
                If CDbl(TxtDiscountC.Text) > CDbl(TxtEndMon.Text) Then TxtDiscountC.Text = TxtEndMon.Text
                '//////////////
                Me.CalCulateMon()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCash.GotFocus
        TxtCash.SelectAll()
    End Sub

    Private Sub TxtCash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash.KeyDown
        If e.KeyCode = Keys.Enter Then Txtbank.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then
                TxtCash.Text += CDbl(LMandeh.Text)
            ElseIf CDbl(LMandeh.Text) = 0 And CDbl(TxtLend.Text) > 0 Then
                TxtCash.Text += CDbl(TxtLend.Text)
                TxtLend.Text = 0
            End If
        End If
    End Sub

    Private Sub TxtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash.KeyPress
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

    Private Sub TxtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtCash.Text.Replace(",", "")))) Then
                TxtCash.Text = "0"
                TxtCash.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtCash.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtCash.Text.Replace(",", ""))
                TxtCash.Text = Format$(Val(str), "###,###,###")
            Else
                TxtCash.Text = CDbl(TxtCash.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtLend_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLend.GotFocus
        TxtLend.SelectAll()
    End Sub

    Private Sub TxtLend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLend.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then TxtLend.Text += CDbl(LMandeh.Text)
        End If
    End Sub

    Private Sub TxtLend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLend.KeyPress
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

    Private Sub TxtLend_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLend.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtLend.Text.Replace(",", "")))) Then
                TxtLend.Text = "0"
                TxtLend.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtLend.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtLend.Text.Replace(",", ""))
                TxtLend.Text = Format$(Val(str), "###,###,###")
            Else
                TxtLend.Text = CDbl(TxtLend.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDiscountH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountH.GotFocus
        TxtDiscountH.SelectAll()
    End Sub

    Private Sub TxtDiscountH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscountH.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDarDisC.Focus()
    End Sub

    Private Sub TxtDiscountH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountH.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtDiscountH.Text.Replace(",", "")))) Then
                TxtDiscountH.Text = "0"
                TxtDarDisH.Text = "0"
                TxtDiscountH.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtDiscountH.Text.Length > 3 Then
                str = Format$(TxtDiscountH.Text.Replace(",", ""))
                TxtDiscountH.Text = Format$(Val(str), "###,###,###")
            Else
                TxtDiscountH.Text = CDbl(TxtDiscountH.Text)
            End If

            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDecMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecMon.GotFocus
        darsad = 1
        TxtDecMon.SelectAll()
    End Sub

    Private Sub TxtDecMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDecMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtAddDarsad.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then
                TxtDecMon.Text += CDbl(LMandeh.Text)
            ElseIf CDbl(LMandeh.Text) = 0 And CDbl(TxtLend.Text) > 0 Then
                TxtDecMon.Text += CDbl(TxtLend.Text)
                TxtLend.Text = 0
            End If
        End If
    End Sub

    Private Sub TxtDecMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecMon.KeyPress
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

    Private Sub TxtDecMon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecMon.LostFocus
        If CDbl(TxtDecDarsad.Text) > 100 Then TxtDecDarsad.Text = 100
        TxtDecDarsad.Text = Math.Round(CDbl(TxtDecDarsad.Text), 2)
    End Sub

    Private Sub TxtDecMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecMon.TextChanged
        If darsad = 1 Then
            Try
                If Not (CheckDigit(Format$(TxtDecMon.Text.Replace(",", "")))) Then
                    TxtDecMon.Text = "0"
                    TxtDecDarsad.Text = "0"
                    TxtDecMon.SelectAll()
                    Exit Sub
                End If
                Dim str As String
                If TxtDecMon.Text.Length > 3 Then
                    SendKeys.Send("{end}")
                    str = Format$(TxtDecMon.Text.Replace(",", ""))
                    TxtDecMon.Text = Format$(Val(str), "###,###,###")
                Else
                    TxtDecMon.Text = CDbl(TxtDecMon.Text)
                End If
                '//////////////
                If Not TxtDecDarsad.Text.Trim.Contains(".") Then TxtDecDarsad.Text = CDbl(TxtDecDarsad.Text)
                Dim tmp As Double = ((CDbl(TxtDecMon.Text) * 100) / CDbl(TxtFacMon.Text))
                TxtDecDarsad.Text = Math.Round(tmp, 2)
                If CDbl(TxtDecDarsad.Text) > 100 Then TxtDecDarsad.Text = 100
                If CDbl(TxtDecMon.Text) > CDbl(TxtFacMon.Text) Then TxtDecMon.Text = TxtFacMon.Text
                '//////////////
                Me.CalCulateMon()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtAddMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddMon.GotFocus
        darsad = 1
        TxtAddMon.SelectAll()
    End Sub

    Private Sub TxtAddMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAddMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDarDisH.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then
                TxtAddMon.Text += CDbl(LMandeh.Text)
            ElseIf CDbl(LMandeh.Text) = 0 And CDbl(TxtLend.Text) > 0 Then
                TxtAddMon.Text += CDbl(TxtLend.Text)
                TxtLend.Text = 0
            End If
        End If
    End Sub

    Private Sub TxtAddMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddMon.KeyPress
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

    Private Sub TxtAddMon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddMon.LostFocus
        If CDbl(TxtAddDarsad.Text) > 100 Then TxtAddDarsad.Text = 100
        TxtAddDarsad.Text = Math.Round(CDbl(TxtAddDarsad.Text), 2)
    End Sub

    Private Sub TxtAddMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddMon.TextChanged
        If darsad = 1 Then
            Try
                If Not (CheckDigit(Format$(TxtAddMon.Text.Replace(",", "")))) Then
                    TxtAddMon.Text = "0"
                    TxtAddDarsad.Text = "0"
                    TxtAddMon.SelectAll()
                    Exit Sub
                End If
                Dim str As String
                If TxtAddMon.Text.Length > 3 Then
                    SendKeys.Send("{end}")
                    str = Format$(TxtAddMon.Text.Replace(",", ""))
                    TxtAddMon.Text = Format$(Val(str), "###,###,###")
                Else
                    TxtAddMon.Text = CDbl(TxtAddMon.Text)
                End If
                '//////////////
                If Not TxtAddDarsad.Text.Trim.Contains(".") Then TxtAddDarsad.Text = CDbl(TxtAddDarsad.Text)
                Dim tmp As Double = ((CDbl(TxtAddMon.Text) * 100) / CDbl(TxtFacMon.Text))
                TxtAddDarsad.Text = Math.Round(tmp, 2)
                If CDbl(TxtAddDarsad.Text) > 100 Then TxtAddDarsad.Text = 100
                If CDbl(TxtAddMon.Text) > CDbl(TxtFacMon.Text) Then TxtAddMon.Text = TxtFacMon.Text
                '//////////////
                Me.CalCulateMon()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Txtbank_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbank.GotFocus
        Txtbank.SelectAll()
    End Sub

    Private Sub Txtbank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbank.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSellChk.Focus()
        If e.KeyCode = Keys.Delete Then
            Txtbank.Text = "0"
            TxtbankName.Clear()
            TxtDiscbank.Clear()
            TxtIdBank.Clear()
        End If
    End Sub

    Private Sub Txtbank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtbank.TextChanged
        Try
            If Not (CheckDigit(Format$(Txtbank.Text.Replace(",", "")))) Then
                Txtbank.Text = "0"
                Txtbank.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If Txtbank.Text.Length > 3 Then
                str = Format$(Txtbank.Text.Replace(",", ""))
                Txtbank.Text = Format$(Val(str), "###,###,###")
            Else
                Txtbank.Text = CDbl(Txtbank.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSellChk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSellChk.GotFocus
        TxtSellChk.SelectAll()
    End Sub

    Private Sub TxtSellChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSellChk.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk.Focus()
    End Sub

    Private Sub TxtSellChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSellChk.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtSellChk.Text.Replace(",", "")))) Then
                TxtSellChk.Text = "0"
                TxtSellChk.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtSellChk.Text.Length > 3 Then
                str = Format$(TxtSellChk.Text.Replace(",", ""))
                TxtSellChk.Text = Format$(Val(str), "###,###,###")
            Else
                TxtSellChk.Text = CDbl(TxtSellChk.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtChk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtChk.GotFocus
        TxtChk.SelectAll()
    End Sub

    Private Sub TxtChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk.KeyDown
        If e.KeyCode = Keys.Enter Then TxtLend.Focus()
    End Sub

    Private Sub TxtChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtChk.Text.Replace(",", "")))) Then
                TxtChk.Text = "0"
                TxtChk.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtChk.Text.Length > 3 Then
                str = Format$(TxtChk.Text.Replace(",", ""))
                TxtChk.Text = Format$(Val(str), "###,###,###")
            Else
                TxtChk.Text = CDbl(TxtChk.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalCulateMon()
        Try
            TxtEndMon.Text = CDbl(TxtFacMon.Text) + CDbl(TxtAddMon.Text) - CDbl(TxtDecMon.Text) - CDbl(TxtDiscountH.Text)
            LMandeh.Text = CDbl(TxtEndMon.Text) - CDbl(TxtDiscountC.Text) - CDbl(TxtCash.Text) - CDbl(Txtbank.Text) - CDbl(TxtSellChk.Text) - CDbl(TxtChk.Text) - CDbl(TxtLend.Text)
            If CDbl(TxtDiscountC.Text) > 0 Then
                If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)
                Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / CDbl(TxtEndMon.Text))
                TxtDarDisC.Text = Math.Round(tmp, 2)
                If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
                If CDbl(TxtDiscountC.Text) > CDbl(TxtEndMon.Text) Then TxtDiscountC.Text = TxtEndMon.Text
            End If

            If CDbl(TxtDiscountH.Text) > 0 Then
                If Not TxtDarDisH.Text.Trim.Contains(".") Then TxtDarDisH.Text = CDbl(TxtDarDisH.Text)
                Dim tmp As Double = ((CDbl(TxtDiscountH.Text) * 100) / CDbl(TxtEndMon.Text))
                TxtDarDisH.Text = Math.Round(tmp, 2)
                If CDbl(TxtDarDisH.Text) > 100 Then TxtDarDisH.Text = 100
            End If

            If CDbl(LMandeh.Text) <> 0 Then
                TxtLend.Text = If(CDbl(TxtLend.Text) + CDbl(LMandeh.Text) > 0, CDbl(TxtLend.Text) + CDbl(LMandeh.Text), 0)
            End If
            LMandeh.Text = CDbl(TxtEndMon.Text) - CDbl(TxtDiscountC.Text) - CDbl(TxtCash.Text) - CDbl(Txtbank.Text) - CDbl(TxtSellChk.Text) - CDbl(TxtChk.Text) - CDbl(TxtLend.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtEndMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEndMon.GotFocus
        TxtEndMon.SelectAll()
    End Sub

    Private Sub TxtEndMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEndMon.TextChanged
        If Not (CheckDigit(Format$(TxtEndMon.Text.Replace(",", "")))) Then
            TxtEndMon.Text = "0"
            TxtEndMon.SelectAll()
            Exit Sub
        End If
        Dim str As String
        If TxtEndMon.Text.Length > 3 Then
            str = Format$(TxtEndMon.Text.Replace(",", ""))
            TxtEndMon.Text = Format$(Val(str), "###,###,###")
        Else
            TxtEndMon.Text = CDbl(TxtEndMon.Text)
        End If
    End Sub

    Private Sub LMandeh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LMandeh.TextChanged
        Dim str As String
        If LMandeh.Text.Length > 3 Then
            str = Format$(LMandeh.Text.Replace(",", ""))
            LMandeh.Text = Format$(Val(str), "###,###,###")
        Else
            LMandeh.Text = CDbl(LMandeh.Text)
        End If
    End Sub

    Private Sub TxtDarDisC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarDisC.GotFocus
        darsad = 0
        TxtDarDisC.SelectAll()
    End Sub

    Private Sub TxtDarDisC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDarDisC.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscountC.Focus()
    End Sub

    Private Sub TxtDarDisC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDarDisC.KeyPress
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
            If InStr(TxtDarDisC.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDarDisC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarDisC.LostFocus
        If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
        TxtDarDisC.Text = Math.Round(CDbl(TxtDarDisC.Text), 2)
    End Sub

    Private Sub TxtDarDisC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDarDisC.TextChanged
        If darsad = 0 Then
            Try
                If Not (CheckDigit(TxtDarDisC.Text)) Then
                    TxtDarDisC.Text = 0
                    TxtDiscountC.Text = 0
                    TxtDarDisC.SelectAll()
                    Exit Sub
                End If
                If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)
                If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
                TxtDiscountC.Text = Format((CDbl(TxtDarDisC.Text) * CDbl(TxtEndMon.Text) / 100), "###,###")
                If String.IsNullOrEmpty(TxtDiscountC.Text.Trim) Then TxtDiscountC.Text = "0"
                Dim dar As String = TxtDarDisC.Text 
                If dar(dar.Length -1)<>"." Then me.CalCulateMon()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnHavaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHavaleh.Click
        Try
            Using FrmHavale As New FrmHavalehBank
                If CDbl(Txtbank.Text) > 0 Then
                    FrmHavale.TxtBank.Text = TxtbankName.Text.Trim
                    FrmHavale.TxtIdBank.Text = TxtIdBank.Text.Trim
                    FrmHavale.TxtMon.Text = CDbl(Txtbank.Text)
                Else
                    FrmHavale.TxtMon.Text = "0"
                End If
                FrmHavale.ShowDialog()
                If FrmHavale.LAdd.Text = "0" Then Exit Sub
                TxtbankName.Text = FrmHavale.TxtBank.Text
                TxtIdBank.Text = FrmHavale.TxtIdBank.Text
                Txtbank.Text = CDbl(FrmHavale.TxtMon.Text)
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnHavaleh_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Factor_buy.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If CDbl(LMandeh.Text) > 0 Then
                MessageBox.Show("وضعيت نحوي پرداخت كل مبلغ تعيين نشده است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtLend.Focus()
                Exit Sub
            End If
            If CDbl(LMandeh.Text) < 0 And CDbl(TxtLend.Text) > 0 Then
                MessageBox.Show("مبلغ نسیه اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtLend.Focus()
                Exit Sub
            End If
            If CDbl(TxtLend.Text) <= 0 And ChKLend.Checked = True Then
                MessageBox.Show("جهت استفاده از نسیه زمانی باید مبلغ نسیه وجود داشته باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtLend.Focus()
                Exit Sub
            End If
            If ChKLend.Checked = True Then
                If CLng(TxtTime.Text) < 0 Then
                    MessageBox.Show("جهت استفاده از نسیه زمانی عدد بزرگتر از صفر را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtDate.ThisText = LDate.Text
                    TxtTime.Text = "0"
                    TxtTime.Focus()
                    Exit Sub
                End If
            End If
            If CDbl(TxtCash.Text) > 0 And CmbBox.Text = "" Then
                MessageBox.Show("صندوقی جهت برداشت نقدی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbBox.Focus()
                Exit Sub
            End If
            If LEdit.Text = "0" Then
                If Savepay() Then
                    LOk.Text = "1"
                    Me.Close()
                End If
            Else
                If Editpay() Then
                    LOk.Text = "1"
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnSave_Click")
        End Try
    End Sub
    Private Function Savepay() As Boolean
        Dim IdDec As Long = 0
        Dim IdAdd As Long = 0
        Dim IdDisH As Long = 0
        Dim IdDisC As Long = 0
        Dim IdCashBox As Long = 0
        Dim IdCashMoein As Long = 0
        Dim IdBank As Long = 0
        Dim IdBankMoein As Long = 0
        Dim IdChk As Long = 0
        Dim Idfactor As Long = 0
        Dim ListName As String = ""
        Dim KalaName As String = ""
        If LState.Text = "0" Or LState.Text = "2" Then
            ListName = "ListFactorBuy"
            KalaName = "KalaFactorBuy"
        ElseIf LState.Text = "4" Then
            ListName = "ListFactorBackSell"
            KalaName = "KalaFactorBackSell"
        ElseIf LState.Text = "6" Then
            ListName = "ListFactorDamage"
            KalaName = "KalaFactorDamage"
        End If
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '//////////////////////////////////////////
            '''''''''''''''''''''''''''''Moein_Box
            If CDbl(TxtCash.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت بابت ف.برگشت از فروش " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت بابت  " & If(LState.Text = "0", " ف.خرید", " ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = CmbBox.SelectedValue
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdCashBox = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''''''''''''''''Moein_Bank
            If CDbl(Txtbank.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " پرداخت بابت ف.برگشت از فروش " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت بابت  " & If(LState.Text = "0", " ف.خرید", " ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdBank = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''''''''''''''''Moein_People
            ''''''''''''''''Factor
            If LState.Text <> "2" Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & DiscFactor
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " ف.خرید", " ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & DiscFactor
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtFacMon.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 0
                    Idfactor = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''DecMon
            If CDbl(TxtDecMon.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ کسورات ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DecMon.Text), "", " - " & TxtDisc_DecMon.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ کسورات ف.خرید", " مبلغ کسورات ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DecMon.Text), "", " - " & TxtDisc_DecMon.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDecMon.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 1
                    IdDec = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''AddMon
            If CDbl(TxtAddMon.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ اضافات ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_AddMon.Text), "", " - " & TxtDisc_AddMon.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ اضافات ف.خرید", " مبلغ اضافات ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_AddMon.Text), "", " - " & TxtDisc_AddMon.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtAddMon.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 2
                    IdAdd = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''DiscountH
            If CDbl(TxtDiscountH.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ تخفیف حجمی ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisH.Text), "", " - " & TxtDisc_DisH.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ تخفیف حجمی ف.خرید", " مبلغ تخفیف حجمی ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisH.Text), "", " - " & TxtDisc_DisH.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDiscountH.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 3
                    IdDisH = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''DiscountC
            If CDbl(TxtDiscountC.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ تخفیف نقدی ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisC.Text), "", " - " & TxtDisc_DisC.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ تخفیف نقدی ف.خرید", " مبلغ تخفیف نقدی ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisC.Text), "", " - " & TxtDisc_DisC.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 4
                    IdDisC = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''Cash
            If CDbl(TxtCash.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ نقد ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ نقد ف.خرید", " مبلغ نقد ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 5
                    IdCashMoein = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''Havaleh
            If CDbl(Txtbank.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ حواله بانکی ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ حواله بانکی ف.خرید", " مبلغ حواله بانکی ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 6
                    IdBankMoein = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''Chk
            If CDbl(TxtSellChk.Text) > 0 Or CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ چک ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_SellChk.Text), "", " - " & TxtDisc_SellChk.Text.Trim) & If(String.IsNullOrEmpty(TxtDisc_Chk.Text), "", " - " & TxtDisc_Chk.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ چک ف.خرید", " مبلغ چک ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_SellChk.Text), "", " - " & TxtDisc_SellChk.Text.Trim) & If(String.IsNullOrEmpty(TxtDisc_Chk.Text), "", " - " & TxtDisc_Chk.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtChk.Text) + CDbl(TxtSellChk.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 7
                    IdChk = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''ListFacotr
            Using Cmd As New SqlCommand("Update " & ListName & " SET Activ=@Activ,EditFlag=@EditFlag,IdSanadFactor=@IdSanadFactor,MonAdd=@MonAdd,DiscAdd=@DiscAdd,IdSanadAdd=@IdSanadAdd,MonDec=@MonDec,DiscDec=@DiscDec,IdSanadDec=@IdSanadDec,IdSanadDiscountH=@IdSanadDiscountH,IdSanadDiscountC=@IdSanadDiscountC,DiscDisH=@DiscDisH,DiscDisC=@DiscDisC,Discount=@Discount,Cash=@Cash,IdSanadCash=@IdSanadCash,IdBox=@IdBox,DiscCash=@DiscCash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,IdSanadHavaleh=@IdSanadHavaleh,IdBank=@IdBank,MonSellChk=@MonSellChk,MonPayChk=@MonPayChk,IdSanadChk=@IdSanadChk,DiscSellChk=@DiscSellChk,DiscChk=@DiscChk WHERE IdFactor=@IdFactor;UPDATE " & KalaName & " SET Activ=@Activ WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@IdSanadFactor", SqlDbType.BigInt).Value = IIf(Idfactor = 0, DBNull.Value, Idfactor)
                Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = CDbl(TxtAddMon.Text)
                Cmd.Parameters.AddWithValue("@DiscAdd", SqlDbType.NVarChar).Value = TxtDisc_AddMon.Text
                Cmd.Parameters.AddWithValue("@IdSanadAdd", SqlDbType.BigInt).Value = IIf(IdAdd = 0, DBNull.Value, IdAdd)
                Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = CDbl(TxtDecMon.Text)
                Cmd.Parameters.AddWithValue("@DiscDec", SqlDbType.NVarChar).Value = TxtDisc_DecMon.Text
                Cmd.Parameters.AddWithValue("@IdSanadDec", SqlDbType.BigInt).Value = IIf(IdDec = 0, DBNull.Value, IdDec)
                Cmd.Parameters.AddWithValue("@IdSanadDiscountH", SqlDbType.BigInt).Value = IIf(IdDisH = 0, DBNull.Value, IdDisH)
                Cmd.Parameters.AddWithValue("@IdSanadDiscountC", SqlDbType.BigInt).Value = IIf(IdDisC = 0, DBNull.Value, IdDisC)
                Cmd.Parameters.AddWithValue("@DiscDisH", SqlDbType.NVarChar).Value = TxtDisc_DisH.Text
                Cmd.Parameters.AddWithValue("@DiscDisC", SqlDbType.NVarChar).Value = TxtDisc_DisC.Text
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@IdSanadCash", SqlDbType.BigInt).Value = IIf(IdCashMoein = 0, DBNull.Value, IdCashMoein)
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdBank.Text), DBNull.Value, TxtIdBank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadHavaleh", SqlDbType.BigInt).Value = IIf(IdBankMoein = 0, DBNull.Value, IdBankMoein)
                Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text.Trim
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = CDbl(TxtSellChk.Text)
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@IdSanadChk", SqlDbType.BigInt).Value = IIf(IdChk = 0, DBNull.Value, IdChk)
                Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = TxtDisc_SellChk.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text.Trim
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''Lend
            If ChKLend.Checked = True Then
                Using Cmd As New SqlCommand("INSERT Wanted_Kharid (IdFactor,Rate) VALUES(@IdFactor,@Rate)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = LIdFac.Text
                    Cmd.Parameters.AddWithValue("@Rate", SqlDbType.BigInt).Value = TxtTime.Text
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =" & LState.Text & " ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            If CDbl(TxtSellChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =" & LState.Text & " ) AND (Current_Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات پرداختی فاکتور قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "Savepay")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function Editpay() As Boolean
        Dim IdDec As Long = 0
        Dim IdAdd As Long = 0
        Dim IdDisH As Long = 0
        Dim IdDisC As Long = 0
        Dim IdCashBox As Long = 0
        Dim IdCashMoein As Long = 0
        Dim IdBank As Long = 0
        Dim IdBankMoein As Long = 0
        Dim IdChk As Long = 0
        Dim Idfactor As Long = 0
        Dim ListName As String = ""
        Dim KalaName As String = ""
        If LState.Text = "0" Or LState.Text = "2" Then
            ListName = "ListFactorBuy"
            KalaName = "KalaFactorBuy"
        ElseIf LState.Text = "4" Then
            ListName = "ListFactorBackSell"
            KalaName = "KalaFactorBackSell"
        ElseIf LState.Text = "6" Then
            ListName = "ListFactorDamage"
            KalaName = "KalaFactorDamage"
        End If
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '//////////////////////////////////////////
            '''''''''''''''''''''''''''''Moein_Box
            Dim TmpId As String = If(dt.Rows(0).Item("IdBox") Is DBNull.Value, "", dt.Rows(0).Item("IdBox"))
            If CDbl(TxtCash.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_Box SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdBox=@IdBox,IdUser=@IdUser WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت بابت ف.برگشت از فروش " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت بابت  " & If(LState.Text = "0", " ف.خرید", " ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = CmbBox.SelectedValue
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    If String.IsNullOrEmpty(TmpId) Then
                        IdCashBox = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdCashBox = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdBox=@IdBox WHERE IdFactor=@IdFactor;DELETE FROM  Moein_Box WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''''''''''''''''Moein_Bank
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdBank") Is DBNull.Value, "", dt.Rows(0).Item("IdBank"))
            If CDbl(Txtbank.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_Bank  SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IDBank=@IDBank,IdUser=@IdUser WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " پرداخت بابت ف.برگشت از فروش " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت بابت  " & If(LState.Text = "0", " ف.خرید", " ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    If String.IsNullOrEmpty(TmpId) Then
                        IdBank = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdBank = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdBank=@IdBank WHERE IdFactor=@IdFactor;DELETE FROM  Moein_Bank WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''''''''''''''''Moein_People
            ''''''''''''''''Factor
            If LState.Text <> "2" Then
                Using Cmd As New SqlCommand("UPDATE Moein_People  SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & DiscFactor
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " ف.خرید", " ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & DiscFactor
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtFacMon.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = dt.Rows(0).Item("IdSanadFactor")
                    Cmd.ExecuteNonQuery()
                    Idfactor = If(dt.Rows(0).Item("IdSanadFactor") Is DBNull.Value, 0, dt.Rows(0).Item("IdSanadFactor"))
                End Using
            End If
            ''''''''''''''''DecMon
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadDec") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadDec"))
            If CDbl(TxtDecMon.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@ID"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ کسورات ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DecMon.Text), "", " - " & TxtDisc_DecMon.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ کسورات ف.خرید", " مبلغ کسورات ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DecMon.Text), "", " - " & TxtDisc_DecMon.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDecMon.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 1
                    If String.IsNullOrEmpty(TmpId) Then
                        IdDec = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdDec = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadDec=@IdSanadDec WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadDec", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''AddMon
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadAdd") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadAdd"))
            If CDbl(TxtAddMon.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ اضافات ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_AddMon.Text), "", " - " & TxtDisc_AddMon.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ اضافات ف.خرید", " مبلغ اضافات ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_AddMon.Text), "", " - " & TxtDisc_AddMon.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtAddMon.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 2
                    If String.IsNullOrEmpty(TmpId) Then
                        IdAdd = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdAdd = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadAdd=@IdSanadAdd WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadAdd", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''DiscountH
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadDiscountH") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadDiscountH"))
            If CDbl(TxtDiscountH.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ تخفیف حجمی ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisH.Text), "", " - " & TxtDisc_DisH.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ تخفیف حجمی ف.خرید", " مبلغ تخفیف حجمی ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisH.Text), "", " - " & TxtDisc_DisH.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDiscountH.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 3
                    If String.IsNullOrEmpty(TmpId) Then
                        IdDisH = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdDisH = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadDiscountH=@IdSanadDiscountH WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadDiscountH", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''DiscountC
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadDiscountC") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadDiscountC"))
            If CDbl(TxtDiscountC.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ تخفیف نقدی ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisC.Text), "", " - " & TxtDisc_DisC.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ تخفیف نقدی ف.خرید", " مبلغ تخفیف نقدی ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_DisC.Text), "", " - " & TxtDisc_DisC.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 4
                    If String.IsNullOrEmpty(TmpId) Then
                        IdDisC = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdDisC = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadDiscountC=@IdSanadDiscountC WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadDiscountC", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''Cash
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadCash") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadCash"))
            If CDbl(TxtCash.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ نقد ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ نقد ف.خرید", " مبلغ نقد ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 5
                    If String.IsNullOrEmpty(TmpId) Then
                        IdCashMoein = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdCashMoein = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadCash=@IdSanadCash WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadCash", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''Havaleh
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadHavaleh") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadHavaleh"))
            If CDbl(Txtbank.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ حواله بانکی ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ حواله بانکی ف.خرید", " مبلغ حواله بانکی ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 6
                    If String.IsNullOrEmpty(TmpId) Then
                        IdBankMoein = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdBankMoein = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadHavaleh=@IdSanadHavaleh WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadHavaleh", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''Chk
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadChk") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadChk"))
            If CDbl(TxtSellChk.Text) > 0 Or CDbl(TxtChk.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = LDate.Text
                    If LState.Text = "4" Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ چک ف.برگشت از فروش" & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_SellChk.Text), "", " - " & TxtDisc_SellChk.Text.Trim) & If(String.IsNullOrEmpty(TxtDisc_Chk.Text), "", " - " & TxtDisc_Chk.Text.Trim)
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(LState.Text = "0", " مبلغ چک ف.خرید", " مبلغ چک ف.خرید امانی") & LIdFac.Text & If(String.IsNullOrEmpty(LHandNumber.Text.Trim), "", " شماره دستی " & LHandNumber.Text) & If(String.IsNullOrEmpty(TxtDisc_SellChk.Text), "", " - " & TxtDisc_SellChk.Text.Trim) & If(String.IsNullOrEmpty(TxtDisc_Chk.Text), "", " - " & TxtDisc_Chk.Text.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtChk.Text) + CDbl(TxtSellChk.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(LIdname.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 7
                    If String.IsNullOrEmpty(TmpId) Then
                        IdChk = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdChk = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE " & ListName & " SET IdSanadChk=@IdSanadChk WHERE IdFactor=@IdFactor;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadChk", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''ListFacotr
            Dim query As String = ""
            If LState.Text = "4" Then
                query = "Update " & ListName & " SET D_date=@D_date,IdName=@IdName,Part=@Part,Sanad=@Sanad,IdVisitor=@IdVisitor,IdUser=@IdUser,Disc=@Disc,IdSanadFactor=@IdSanadFactor,MonAdd=@MonAdd,DiscAdd=@DiscAdd,IdSanadAdd=@IdSanadAdd,MonDec=@MonDec,DiscDec=@DiscDec,IdSanadDec=@IdSanadDec,IdSanadDiscountH=@IdSanadDiscountH,IdSanadDiscountC=@IdSanadDiscountC,DiscDisH=@DiscDisH,DiscDisC=@DiscDisC,Discount=@Discount,Cash=@Cash,IdSanadCash=@IdSanadCash,IdBox=@IdBox,DiscCash=@DiscCash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,IdSanadHavaleh=@IdSanadHavaleh,IdBank=@IdBank,MonPayChk=@MonPayChk,MonSellChk=@MonSellChk,IdSanadChk=@IdSanadChk,DiscChk=@DiscChk,IdFacSell=@IdFacSell WHERE IdFactor=@IdFactor"
            Else
                query = "Update " & ListName & " SET D_date=@D_date,IdName=@IdName,Part=@Part,Sanad=@Sanad,IdVisitor=@IdVisitor,IdUser=@IdUser,Disc=@Disc,IdSanadFactor=@IdSanadFactor,MonAdd=@MonAdd,DiscAdd=@DiscAdd,IdSanadAdd=@IdSanadAdd,MonDec=@MonDec,DiscDec=@DiscDec,IdSanadDec=@IdSanadDec,IdSanadDiscountH=@IdSanadDiscountH,IdSanadDiscountC=@IdSanadDiscountC,DiscDisH=@DiscDisH,DiscDisC=@DiscDisC,Discount=@Discount,Cash=@Cash,IdSanadCash=@IdSanadCash,IdBox=@IdBox,DiscCash=@DiscCash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,IdSanadHavaleh=@IdSanadHavaleh,IdBank=@IdBank,MonPayChk=@MonPayChk,MonSellChk=@MonSellChk,IdSanadChk=@IdSanadChk,DiscChk=@DiscChk WHERE IdFactor=@IdFactor"
            End If
            Using Cmd As New SqlCommand(query, ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = InfoFactorArray(0).D_date
                Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(InfoFactorArray(0).IdPart = 0, DBNull.Value, InfoFactorArray(0).IdPart)
                Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = InfoFactorArray(0).Sanad
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = InfoFactorArray(0).Disc
                Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(InfoFactorArray(0).IdName = 0, DBNull.Value, InfoFactorArray(0).IdName)
                Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(InfoFactorArray(0).IdVisitor = 0, DBNull.Value, InfoFactorArray(0).IdVisitor)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@IdSanadFactor", SqlDbType.BigInt).Value = IIf(Idfactor = 0, DBNull.Value, Idfactor)
                Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = CDbl(TxtAddMon.Text)
                Cmd.Parameters.AddWithValue("@DiscAdd", SqlDbType.NVarChar).Value = TxtDisc_AddMon.Text
                Cmd.Parameters.AddWithValue("@IdSanadAdd", SqlDbType.BigInt).Value = IIf(IdAdd = 0, DBNull.Value, IdAdd)
                Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = CDbl(TxtDecMon.Text)
                Cmd.Parameters.AddWithValue("@DiscDec", SqlDbType.NVarChar).Value = TxtDisc_DecMon.Text
                Cmd.Parameters.AddWithValue("@IdSanadDec", SqlDbType.BigInt).Value = IIf(IdDec = 0, DBNull.Value, IdDec)
                Cmd.Parameters.AddWithValue("@IdSanadDiscountH", SqlDbType.BigInt).Value = IIf(IdDisH = 0, DBNull.Value, IdDisH)
                Cmd.Parameters.AddWithValue("@IdSanadDiscountC", SqlDbType.BigInt).Value = IIf(IdDisC = 0, DBNull.Value, IdDisC)
                Cmd.Parameters.AddWithValue("@DiscDisH", SqlDbType.NVarChar).Value = TxtDisc_DisH.Text
                Cmd.Parameters.AddWithValue("@DiscDisC", SqlDbType.NVarChar).Value = TxtDisc_DisC.Text
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@IdSanadCash", SqlDbType.BigInt).Value = IIf(IdCashMoein = 0, DBNull.Value, IdCashMoein)
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdBank.Text), DBNull.Value, TxtIdBank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadHavaleh", SqlDbType.BigInt).Value = IIf(IdBankMoein = 0, DBNull.Value, IdBankMoein)
                Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text.Trim
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = CDbl(TxtSellChk.Text)
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@IdSanadChk", SqlDbType.BigInt).Value = IIf(IdChk = 0, DBNull.Value, IdChk)
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text.Trim
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                If LState.Text = "4" Then Cmd.Parameters.AddWithValue("@IdFacSell", SqlDbType.BigInt).Value = IIf(InfoFactorArray(0).IdFactor = 0, DBNull.Value, InfoFactorArray(0).IdFactor)
                Cmd.ExecuteNonQuery()
            End Using
            Using Cmd As New SqlCommand("DELETE FROM " & KalaName & " WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            TmpId = "INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)"
            Using Cmd As New SqlCommand(TmpId, ConectionBank)
                For i As Integer = 0 To FactorArray.Length - 1
                    If FactorArray(i).IdKala <> 0 Then
                        Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = FactorArray(i).IdKala
                        Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = FactorArray(i).CodeAnbar
                    Else
                        Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = FactorArray(i).IdService
                        Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                    End If
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = FactorArray(i).KolCount
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = FactorArray(i).JozCount
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = FactorArray(i).Fe
                    Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = FactorArray(i).DarsadDiscount
                    Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = FactorArray(i).DarsadMon
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = FactorArray(i).Mon
                    Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = If(FactorArray(i).Disc Is DBNull.Value Or String.IsNullOrEmpty(FactorArray(i).Disc), "", FactorArray(i).Disc)
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using
            ''''''''''''''''Lend
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("Rate") Is DBNull.Value, "", dt.Rows(0).Item("Rate"))
            If ChKLend.Checked = True Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Wanted_Kharid (IdFactor,Rate) VALUES(@IdFactor,@Rate)"
                Else
                    StrTmp = "UPDATE Wanted_Kharid  SET Rate=@Rate WHERE IdFactor=@IdFactor"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = LIdFac.Text
                    Cmd.Parameters.AddWithValue("@Rate", SqlDbType.BigInt).Value = TxtTime.Text
                    Cmd.ExecuteNonQuery()
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("Delete FROM Wanted_Kharid WHERE IdFactor=@IdFactor;Delete FROM PayLimitKharid WHERE IdFactor=@IdFactor", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Or CDbl(TxtSellChk.Text) > 0 Then
                If CDbl(TxtChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =" & LState.Text & " ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
                If CDbl(TxtSellChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =" & LState.Text & " ) AND (Current_Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If

                Using Cmd As New SqlCommand("UPDATE Chk_Id SET IdPeople =" & LIdname.Text & " WHERE Id IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Type] =" & LState.Text & " ) AND (Number_Type = " & LIdFac.Text & "));UPDATE Chk_Id SET Current_IdPeople  =" & LIdname.Text & " WHERE Id IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Current_Type] =" & LState.Text & " ) AND (Current_Number_Type = " & LIdFac.Text & "))", ConectionBank)
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات پرداختی فاکتور قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "Editpay")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Try
            LOk.Text = "0"
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnCancle_Click")
        End Try
    End Sub

    Private Sub BtnSodor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSodor.Click
        Try
            Using FrmSodor As New Sodor_Check
                FrmSodor.LName.Text = LName.Text
                FrmSodor.LIdname.Text = LIdname.Text
                FrmSodor.LFac.Text = LIdFac.Text
                FrmSodor.LState.Text = LState.Text
                FrmSodor.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtChk.Text = FrmSodor.TxtallmoneyPay.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnSodor_Click")
        End Try
    End Sub

    Private Sub PayFactor_Buy_Amani_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LOk.Text = "0"
        Me.GetBoxList()
        If LEdit.Text = "1" Then
            ChkFactor.Visible = False
            ChkResid.Visible = False
            Me.GetInfo()
        Else
            ChKLend.Checked = False
            TxtTime.Enabled = False
            TxtDate.Enabled = False
            Me.Limit()
            GetMalyat(LState.Text)
            'TxtLend.Text = TxtEndMon.Text
            Me.CalCulateMon()
        End If
        If LState.Text <> "0" Then
            ChKLend.Enabled = False
            ChKLend.Checked = False
        End If

    End Sub

    Private Sub GetBoxList()
        Try
            ds_Box.Clear()
            If Not dta_Box Is Nothing Then
                dta_Box.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_Box = New SqlDataAdapter("If (SELECT COUNT(IdUser) FROM Define_UserRBox WHERE IdUser =" & Id_User & ")>0 SELECT Define_Box.nam, Define_Box.ID FROM Define_Box INNER JOIN Define_UserRPBox ON Define_Box.ID = Define_UserRPBox.IDB WHERE Define_Box.Id in (SELECT IDB  FROM Define_UserRPBox  WHERE IdUser =" & Id_User & ") AND IdUser =" & Id_User & " ORDER BY Define_UserRPBox.Id  else SELECT ID,nam FROM Define_Box", DataSource)
            dta_Box.Fill(ds_Box, "Define_BOX")
            CmbBox.DataSource = ds_Box.Tables("Define_BOX")
            CmbBox.DisplayMember = "Nam"
            CmbBox.ValueMember = "ID"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "GetBoxList")
        End Try
    End Sub

    Private Sub GetInfo()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT MonAdd,IdSanadAdd ,mondec,idsanaddec,IdsanadDiscountH,discount,idsanaddiscountc,cash,idsanadcash,monhavaleh,idbankHavaleh,discHavaleh,MonPayChk,idsanadChk,idsanadHavaleh,DiscAdd,DiscDec,DiscDish,discdisc,DiscChk,discCash,IdBox,IdBank,IdSanadFactor,MonSellChk,DiscSellChk,  (SELECT Rate FROM Wanted_Kharid WHERE IdFactor =" & CLng(LIdFac.Text) & ")As Rate FROM " & GetTableNameFactor(CLng(LState.Text), "LIST") & " WHERE IdFactor =" & CLng(LIdFac.Text), ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                dt.Load(Cmd.ExecuteReader)
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                If dt.Rows.Count > 0 Then
                    darsad = 1
                    TxtDecMon.Text = dt.Rows(0).Item("MonDec")
                    TxtDisc_DecMon.Text = dt.Rows(0).Item("DiscDec")

                    TxtAddMon.Text = dt.Rows(0).Item("MonAdd")
                    TxtDisc_AddMon.Text = dt.Rows(0).Item("DiscAdd")

                    TxtDisc_DisH.Text = dt.Rows(0).Item("DiscDisH")

                    TxtDiscountC.Text = dt.Rows(0).Item("DisCount")
                    TxtDisc_DisC.Text = dt.Rows(0).Item("DiscDisC")

                    TxtCash.Text = dt.Rows(0).Item("Cash")
                    TxtDisc_Cash.Text = dt.Rows(0).Item("DiscCash")

                    Txtbank.Text = dt.Rows(0).Item("MonHavaleh")
                    TxtDiscbank.Text = dt.Rows(0).Item("DiscHavaleh")
                    TxtIdBank.Text = If(dt.Rows(0).Item("IdBankHavaleh") Is DBNull.Value, "", dt.Rows(0).Item("IdBankHavaleh"))
                    If Not (dt.Rows(0).Item("IdBankHavaleh") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("IdBankHavaleh")) <> "" Then
                            TxtbankName.Text = GetNamBank(dt.Rows(0).Item("IdBankHavaleh"))
                        End If
                    End If

                    TxtChk.Text = dt.Rows(0).Item("MonPayChk")
                    TxtDisc_Chk.Text = dt.Rows(0).Item("DiscChk")

                    TxtSellChk.Text = dt.Rows(0).Item("MonSellChk")
                    TxtDisc_SellChk.Text = dt.Rows(0).Item("DiscSellChk")

                    If Not (dt.Rows(0).Item("IdBox") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("IdBox")) <> "" Then
                            CmbBox.SelectedValue = GetIdBox(dt.Rows(0).Item("IdBox"))
                        End If
                    End If

                    If Not (dt.Rows(0).Item("Rate") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("Rate")) <> "" Then
                            ChKLend.Checked = True
                            TxtTime.Text = dt.Rows(0).Item("Rate")
                            TxtDate.Enabled = True
                        End If
                    Else
                        ChKLend.Checked = False
                        TxtTime.Enabled = False
                        TxtDate.Enabled = False
                    End If


                    Me.CalCulateMon()
                    If CDbl(LMandeh.Text) > 0 Then
                        TxtLend.Text = LMandeh.Text
                        Me.CalCulateMon()
                    End If
                Else
                    MessageBox.Show("صورتحساب فاکتور مورد نظر پیدا نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "GetInfo")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try

    End Sub
    Private Sub BtnFroshChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFroshChk.Click
        Try
            Using FrmFrosh As New Frosh_Check
                FrmFrosh.LName.Text = LName.Text
                FrmFrosh.LIdname.Text = LIdname.Text
                FrmFrosh.LFac.Text = LIdFac.Text
                FrmFrosh.LState.Text = LState.Text
                FrmFrosh.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtSellChk.Text = FrmFrosh.TxtallmoneyPay.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnFroshChk_Click")
        End Try
    End Sub

    Private Sub BtnDiscDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscDec.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_DecMon.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_DecMon.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscDec_Click")
        End Try
    End Sub

    Private Sub BtnDiscAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscAdd.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_AddMon.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_AddMon.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscAdd_Click")
        End Try
    End Sub

    Private Sub BtnDiscDisH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscDisH.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_DisH.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_DisH.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscDisH_Click")
        End Try
    End Sub

    Private Sub BtnDiscDisC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscDisC.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_DisC.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_DisC.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscDisC_Click")
        End Try
    End Sub

    Private Sub BtnDiscCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscCash.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_Cash.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_Cash.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscCash_Click")
        End Try
    End Sub

    Private Sub BtnDiscHavaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscHavaleh.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDiscbank.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDiscbank.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscHavaleh_Click")
        End Try
    End Sub

    Private Sub BtnDisc_SellChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisc_SellChk.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_SellChk.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_SellChk.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDisc_SellChk_Click")
        End Try
    End Sub

    Private Sub BtnDiscChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscChk.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_Chk.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_Chk.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnDiscChk_Click")
        End Try
    End Sub

    Private Sub ChKLend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKLend.CheckedChanged
        If ChKLend.Checked = True Then
            TxtTime.Enabled = True
            TxtDate.Enabled = True
            If LEdit.Text = "0" Then
                TxtTime.Text = Rate
            Else
                If Not (dt.Rows(0).Item("Rate") Is DBNull.Value) Then
                    TxtTime.Text = dt.Rows(0).Item("Rate")
                Else
                    TxtTime.Text = Rate
                End If
            End If
        Else
            TxtTime.Enabled = False
            TxtDate.Enabled = False
            TxtTime.Clear()
            TxtDate.ThisText = ""
        End If
    End Sub

    Private Sub BtnBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBox.Click
        Try
            Fnew = True
            Using FrmBox As New DefineBox
                FrmBox.ShowDialog()
            End Using
            Fnew = False
            Me.GetBoxList()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "BtnBox_Click")
        End Try
    End Sub

    Private Sub TxtTime_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTime.GotFocus
        TxtTime.SelectAll()
    End Sub

    Private Sub TxtTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTime.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub TxtTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTime.KeyPress
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

    Private Sub TxtTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTime.TextChanged
        Try
            If TxtTime.Enabled = True And ChKLend.Checked = True Then
                If Not String.IsNullOrEmpty(TxtTime.Text.Trim) Then
                    Dim dat As String = LDate.Text
                    For i As Integer = 1 To CInt(TxtTime.Text.Trim)
                        dat = ADDDAY(dat)
                    Next
                    TxtDate.ThisText = dat
                Else
                    TxtTime.Text = "0"
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Sell_Amani", "TxtTime_TextChanged")
            TxtDate.ThisText = LDate.Text
        End Try
    End Sub

    Private Sub TxtDate_TextChanging(ByVal sender As Object, ByVal e As String) Handles TxtDate.TextChanging
        Try
            If TxtDate.ThisText = "" Then
                TxtDate.ThisText = LDate.Text
                TxtTime.Text = "0"
            End If
            TxtTime.Text = SUBDAY(TxtDate.ThisText, LDate.Text)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "TxtDate_TextChanging")
            TxtDate.ThisText = LDate.Text
            TxtTime.Text = "0"
        End Try
    End Sub

    Private Sub TxtDarDisH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarDisH.GotFocus
        TxtDarDisH.SelectAll()
    End Sub

    Private Sub TxtFacMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFacMon.GotFocus
        TxtFacMon.SelectAll()
    End Sub

    Private Sub TxtDarDisH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDarDisH.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscountH.Focus()
    End Sub

    Private Sub CmbBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBox.KeyDown
        If CmbBox.DroppedDown = False Then
            CmbBox.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            If TxtTime.Enabled = True Then
                TxtTime.Focus()
            Else
                BtnSave.Focus()
            End If
        End If
    End Sub

    Private Sub ChKLend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChKLend.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtTime.Enabled = True Then
                TxtTime.Focus()
            Else
                BtnSave.Focus()
            End If
        End If
    End Sub
    Private Sub Limit()
        If Rate > 0 Then
            ChKLend.Checked = True
        End If
    End Sub
    Private Sub GetMalyat(ByVal St As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Dim con As String = ""
            If St = 0 Or St = 2 Then
                con = "S12 AS Ad, S13 As Dc"
            ElseIf St = 3 Or St = 5 Then
                con = "S14 AS Ad, S15 As Dc"
            ElseIf St = 1 Then
                con = "S16 AS Ad, S17 As Dc"
            ElseIf St = 4 Then
                con = "S18 AS Ad, S19 As Dc"
            ElseIf St = 8 Then
                con = "S20 AS Ad, S21 As Dc"
            End If
            Using cmd As New SqlCommand("SELECT  " & con & " FROM  SettingProgram WHERE IdUser =" & Id_User, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                TxtAddDarsad.Text = If(dtr("Ad") Is DBNull.Value, 0, dtr("Ad"))
                TxtDecDarsad.Text = If(dtr("Dc") Is DBNull.Value, 0, dtr("Dc"))
            End If

            dtr.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayFactor_Buy_Amani", "GetMalyat")
            TxtAddDarsad.Text = 0
            TxtDecDarsad.Text = 0
        End Try
    End Sub
End Class