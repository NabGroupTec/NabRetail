Imports System.Data.SqlClient
Imports System.Transactions
Public Class Vosol_chk

    Friend WithEvents txt_dgv1 As New DataGridViewTextBoxEditingControl
    Friend WithEvents txt_dgv2 As New DataGridViewTextBoxEditingControl

    Private Sub Vosol_chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub Vosol_chk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LPrn.Text = 0
        GetInfoChk()
        DGV2.Columns("Cln_MonBox").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV1.Columns("Cln_MonBank").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub DGV2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellEndEdit
        TxtAllMoney.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                End If
            Next i
        End If

        If DGV2.RowCount > 0 Then
            For i As Integer = 0 To DGV2.RowCount - 2
                If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV2.EditingControlShowing
        txt_dgv2 = e.Control
    End Sub

    Private Sub DGV2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV2.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV2.CurrentRow.Index <> DGV2.RowCount - 1 Then
                        DGV2.Rows.RemoveAt(DGV2.CurrentRow.Index)
                    Else
                        DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_BoxId", DGV2.CurrentRow.Index).Value = ""
                    End If

                    TxtAllMoney.Text = "0"
                    If DGV1.RowCount > 0 Then
                        For i As Integer = 0 To DGV1.RowCount - 2
                            If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                                TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                            End If
                        Next i
                    End If

                    If DGV2.RowCount > 0 Then
                        For i As Integer = 0 To DGV2.RowCount - 2
                            If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                                TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                            End If
                        Next i
                    End If

                    If TxtAllMoney.Text.Length > 3 Then
                        Dim money As String = ""
                        money = TxtAllMoney.Text.Replace(",", "")
                        TxtAllMoney.Text = Format$(Val(money), "###,###,###")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV2_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.RowLeave
        If DGV2.CurrentCell.ColumnIndex > 0 Then DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Selected = True
        TxtAllMoney.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                End If
            Next i
        End If

        If DGV2.RowCount > 0 Then
            For i As Integer = 0 To DGV2.RowCount - 2
                If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        TxtAllMoney.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                End If
            Next i
        End If

        If DGV2.RowCount > 0 Then
            For i As Integer = 0 To DGV2.RowCount - 2
                If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        txt_dgv1 = e.Control
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_BankId", DGV1.CurrentRow.Index).Value = ""
                    End If

                    TxtAllMoney.Text = "0"
                    If DGV1.RowCount > 0 Then
                        For i As Integer = 0 To DGV1.RowCount - 2
                            If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                                TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                            End If
                        Next i
                    End If

                    If DGV2.RowCount > 0 Then
                        For i As Integer = 0 To DGV2.RowCount - 2
                            If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                                TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                            End If
                        Next i
                    End If

                    If TxtAllMoney.Text.Length > 3 Then
                        Dim money As String = ""
                        money = TxtAllMoney.Text.Replace(",", "")
                        TxtAllMoney.Text = Format$(Val(money), "###,###,###")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Selected = True
        TxtAllMoney.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                End If
            Next i
        End If

        If DGV2.RowCount > 0 Then
            For i As Integer = 0 To DGV2.RowCount - 2
                If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV2_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV2.UserDeletedRow
        Try
            If DGV2.CurrentCell.ColumnIndex > 0 Then DGV2.Item("Cln_Bank", DGV2.CurrentRow.Index).Selected = True

            TxtAllMoney.Text = "0"
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_MonBox", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBox", i).Value.ToString)
                    End If
                Next i
            End If

            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 2
                    If (CheckDigit(DGV2.Item("Cln_MonBank", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBank", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Try

            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_BoxName", DGV1.CurrentRow.Index).Selected = True

            TxtAllMoney.Text = "0"
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_MonBox", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBox", i).Value.ToString)
                    End If
                Next i
            End If

            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 2
                    If (CheckDigit(DGV2.Item("Cln_MonBank", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBank", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv1.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV1.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_BankId", DGV1.CurrentRow.Index).Value = ""
            End If
            If e.KeyCode = Keys.Space Then
                If DGV1.CurrentCell.ColumnIndex = 1 Then
                    If Not String.IsNullOrEmpty(TxtAllMoney.Text.Trim) Then
                        If CDbl(Txtchkmon.Text) - CDbl(TxtAllMoney.Text) > 0 Then
                            DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value = FormatNumber(CDbl(Txtchkmon.Text) - CDbl(TxtAllMoney.Text), 0)
                            IIf(String.IsNullOrEmpty(DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_MonBank", DGV1.CurrentRow.Index).Value)
                            SendKeys.Send("{ENTER}")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv1.KeyPress
        If DGV1.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Dim frmlk As New bank_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.LState.Text = ""
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.AllowUserToAddRows = False
                DGV1.Rows.Add()
                DGV1.AllowUserToAddRows = True
                DGV1.Item("Cln_Bank", DGV1.RowCount - 2).Value = Tmp_Namkala
                DGV1.Item("Cln_MonBank", DGV1.RowCount - 2).Value = 0
                DGV1.Item("Cln_BankId", DGV1.RowCount - 2).Value = IdKala
                DGV1.Item("Cln_Bank", DGV1.RowCount - 2).Selected = False
                DGV1.Item("Cln_MonBank", DGV1.RowCount - 2).Selected = True
            End If
            Exit Sub
        End If

        If DGV1.CurrentCell.ColumnIndex = 1 Then
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = "" Then
                e.Handled = True
                Exit Sub
            End If
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = (vbBack) Then
                e.Handled = False
            End If
            If e.KeyChar = (vbTab) Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub txt_dgv2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv2.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV2.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_BoxId", DGV2.CurrentRow.Index).Value = ""
            End If
            If e.KeyCode = Keys.Space Then
                If DGV2.CurrentCell.ColumnIndex = 1 Then
                    If Not String.IsNullOrEmpty(TxtAllMoney.Text.Trim) Then
                        If CDbl(Txtchkmon.Text) - CDbl(TxtAllMoney.Text) > 0 Then
                            DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value = FormatNumber(CDbl(Txtchkmon.Text) - CDbl(TxtAllMoney.Text), 0)
                            IIf(String.IsNullOrEmpty(DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value), 0, DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value)
                            SendKeys.Send("{ENTER}")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv2.KeyPress
        If DGV2.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Dim frmlk As New Box_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV2.Focus()
            If Tmp_Namkala <> "" Then
                DGV2.AllowUserToAddRows = False
                DGV2.Rows.Add()
                DGV2.AllowUserToAddRows = True

                DGV2.Item("Cln_BoxName", DGV2.RowCount - 2).Value = Tmp_Namkala
                DGV2.Item("Cln_MonBox", DGV2.RowCount - 2).Value = 0
                DGV2.Item("Cln_BoxId", DGV2.RowCount - 2).Value = IdKala
                DGV2.Item("Cln_BoxName", DGV2.RowCount - 2).Selected = False
                DGV2.Item("Cln_MonBox", DGV2.RowCount - 2).Selected = True
            End If
            Exit Sub
        End If

        If DGV2.CurrentCell.ColumnIndex = 1 Then
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = "" Then
                e.Handled = True
                Exit Sub
            End If
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = (vbBack) Then
                e.Handled = False
            End If
            If e.KeyChar = (vbTab) Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            Btnadd.Focus()
            DGV1.EndEdit()
            DGV2.EndEdit()
            If String.IsNullOrEmpty(TxtAllMoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ دریافتی صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CDbl(TxtAllMoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ دریافتی صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkBox1.Checked = True Then
                If Num.Value <= 0 Then
                    MessageBox.Show("مدت تاخیر را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If DGV1.Item("Cln_Bank", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت بانک در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_Bank", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If

            If DGV2.Item("Cln_BoxName", DGV2.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت صندوق در ردیف شماره " & "{" & DGV2.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV2.Item("Cln_BoxName", DGV2.RowCount - 1).Selected = True
                DGV2.Focus()
                Exit Sub
            End If

            For i As Integer = 0 To DGV1.RowCount - 2
                If String.IsNullOrEmpty(DGV1.Item("Cln_Bank", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_BankId", i).Value) Then
                    MessageBox.Show("نام بانک در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_Bank", i).Selected = True
                    Exit Sub
                End If
                If DGV1.Item("Cln_MonBank", i).Value <= 0 Then
                    MessageBox.Show("واریزی به بانک در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_MonBank", i).Selected = True
                    Exit Sub
                End If
                Dim count As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_BankId", i).Value = DGV1.Item("Cln_BankId", j).Value Then count += 1
                Next
                If count > 1 Then
                    MessageBox.Show("نام بانک در ردیف شماره " & "{" & i + 1 & "}" & "  تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next i

            For i As Integer = 0 To DGV2.RowCount - 2
                If String.IsNullOrEmpty(DGV2.Item("Cln_BoxName", i).Value) Or String.IsNullOrEmpty(DGV2.Item("Cln_BoxId", i).Value) Then
                    MessageBox.Show("نام صندوق در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV2.Focus()
                    DGV2.Item("Cln_BoxName", i).Selected = True
                    Exit Sub
                End If
                If DGV2.Item("Cln_MonBox", i).Value <= 0 Then
                    MessageBox.Show("واریزی به صندوق در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV2.Focus()
                    DGV2.Item("Cln_Monbox", i).Selected = True
                    Exit Sub
                End If
                Dim count As Long = 0
                For j As Integer = 0 To DGV2.RowCount - 2
                    If DGV2.Item("Cln_BoxId", i).Value = DGV2.Item("Cln_BoxId", j).Value Then count += 1
                Next
                If count > 1 Then
                    MessageBox.Show("نام صندوق در ردیف شماره " & "{" & i + 1 & "}" & "  تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next i

            Me.GetInfoChk()
            If CDbl(TxtAllMoney.Text) <> CDbl(Txtchkmon.Text) Then
                MessageBox.Show("مبلغ دریافتی با مبلغ چک برابر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If AreYouEditCheck(CLng(LId.Text)) = False Then
            'MessageBox.Show("چک در حال حاضر قابل وصول شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Exit Sub
            'End If
            Me.Enabled = False
            If VosolChk() Then
                LPrn.Text = "1"
                Dim str As String = " وصل به :"

                For i As Integer = 0 To DGV2.RowCount - 2
                    str &= DGV2.Item("Cln_BoxName", i).Value & " : " & DGV2.Item("Cln_MonBox", i).Value & " "
                Next

                For i As Integer = 0 To DGV1.RowCount - 2
                    str &= DGV1.Item("Cln_Bank", i).Value & " : " & DGV1.Item("Cln_MonBank", i).Value & " "
                Next

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "وصول چک دریافتی با سریال " & Txtidchk.Text & str, "")

                Me.Close()
            End If
            Me.Enabled = True
        Catch ex As Exception
            Me.Enabled = True
        End Try
    End Sub
    Private Function VosolChk() As Boolean
        
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Dim dt As New DataTable
            Using CMD As New SqlCommand("SELECT BoxMoein As Sanad,Typ='Box' FRom Sanad_ChangeChk WHERE IdChk =" & CLng(LId.Text) & " AND BoxMoein IS Not NULL UNION ALL SELECT BankMoein As Sanad,Typ='Bank' FRom Sanad_ChangeChk WHERE IdChk =" & CLng(LId.Text) & " AND BankMoein IS Not NULL UNION ALL SELECT PeopleMoein As Sanad,Typ='People' FRom Sanad_ChangeChk WHERE IdChk =" & CLng(LId.Text) & " AND PeopleMoein IS Not NULL", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            Using CMD As New SqlCommand("UPDATE Chk_Id SET IdBank=@IdBank WHERE Id=@Id", ConectionBank)
                CMD.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = DBNull.Value
                CMD.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LId.Text)
                CMD.ExecuteNonQuery()
            End Using

            If dt.Rows.Count > 0 Then
                Using CMD As New SqlCommand("DELETE FROM Sanad_ChangeChk WHERE IdChk=@IdChk", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = CLng(LId.Text)
                    CMD.ExecuteNonQuery()
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("DELETE FROM Moein_" & dt.Rows(i).Item("Typ") & " WHERE Id=@ID", ConectionBank)
                        CMD.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(i).Item("Sanad")
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                    End Using
                Next i
            End If

            If DGV1.RowCount > 1 Then
                Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@BoxMoein,@IdMoein,@PeopleMoein,@DelayChk)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDateV.Text
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "وصول چک به شماره " & Txtidchk.Text.Trim
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_MonBank", i).Value)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_BankId", i).Value)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = CLng(LId.Text)
                        Cmd.Parameters.AddWithValue("@BoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@PeopleMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = If(ChkBox1.Checked = True, Num.Value, 0)
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next
                End Using
            End If
            If DGV2.RowCount > 1 Then
                Using Cmd As New SqlCommand("INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@IdMoein,@BankMoein,@PeopleMoein,@DelayChk)", ConectionBank)
                    For i As Integer = 0 To DGV2.RowCount - 2
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDateV.Text
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "وصول چک به شماره " & Txtidchk.Text.Trim
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV2.Item("Cln_MonBox", i).Value)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@IDBox", SqlDbType.BigInt).Value = CLng(DGV2.Item("Cln_BoxId", i).Value)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = CLng(LId.Text)
                        Cmd.Parameters.AddWithValue("@BankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@PeopleMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = If(ChkBox1.Checked = True, Num.Value, 0)
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next
                End Using
            End If

            Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Current_State=@Current_State,IdUser=@IdUser WHERE Id=" & CLng(LId.Text), ConectionBank)
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@Id ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LId.Text)
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = TxtDateV.Text
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDiscBank.Text & " " & TxtDiscBox.Text
                Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر چک قابل وصول شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Vosol_chk", "VosolChk")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub txt_dgv1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv1.TextChanged
        Try
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv1.Clear()
                Exit Sub
            End If
            If DGV1.Item("Cln_Bank", DGV1.CurrentRow.Index).Value = "" Then
                txt_dgv1.Clear()
                Exit Sub
            End If
            If DGV1.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigitWithOutpoint(txt_dgv1.Text)) Then txt_dgv1.Text = 0
                If CDbl(txt_dgv1.Text) < 0 Then txt_dgv1.Text = 0
                If txt_dgv1.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv1.Text.Replace(",", ""))
                    txt_dgv1.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv1.Text = CDbl(txt_dgv1.Text)
                End If
            End If

            TxtAllMoney.Text = "0"
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                    End If
                Next i
            End If

            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 2
                    If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv2.TextChanged
        Try
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv2.Clear()
                Exit Sub
            End If
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = "" Then
                txt_dgv2.Clear()
                Exit Sub
            End If
            If DGV2.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigitWithOutpoint(txt_dgv2.Text)) Then txt_dgv2.Text = 0
                If CDbl(txt_dgv2.Text) < 0 Then txt_dgv2.Text = 0
                If txt_dgv2.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv2.Text.Replace(",", ""))
                    txt_dgv2.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv2.Text = CDbl(txt_dgv2.Text)
                End If
            End If

            TxtAllMoney.Text = "0"
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_MonBank", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV1.Item("Cln_MonBank", i).Value.ToString)
                    End If
                Next i
            End If

            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 2
                    If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetInfoChk()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT MoneyChk ,NumChk,PayDate  from Chk_Get_Pay WHERE Id=" & CLng(LId.Text), ConectionBank)
                Dim dtr As SqlDataReader = CMD.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    Txtidchk.Text = dtr("NumChk")
                    Txtdate.Text = dtr("PayDate")
                    If SUBDAY(dtr("Paydate"), TxtDateV.Text) < 0 Then
                        ChkBox1.Enabled = True
                        Num.Enabled = True
                        Num.Value = SUBDAY(dtr("Paydate"), GetDate) * (-1)
                        ChkBox1.Checked = True
                    Else
                        ChkBox1.Enabled = False
                        Num.Enabled = False
                        Num.Value = 0
                    End If
                    Txtchkmon.Text = FormatNumber(dtr("MoneyChk"), 0)
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    MessageBox.Show("چک مورد نظر در سیستم وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Vosol_chk", "GetInfoChk")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LPrn.Text = "0"
        Me.Close()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetChk.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnadd.Enabled = True Then Btnadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetInfoChk()
        End If
    End Sub

    Private Sub ChkBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBox1.CheckedChanged
        If String.IsNullOrEmpty(Txtdate.Text) Then Exit Sub
        If ChkBox1.Checked = True Then
            Num.Enabled = True
            Num.Value = SUBDAY(Txtdate.Text, GetDate) * (-1)
        Else
            Num.Enabled = False
            Num.Value = 0
        End If
    End Sub
End Class