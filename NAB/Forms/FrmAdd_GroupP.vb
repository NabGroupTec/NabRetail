Imports System.Data.SqlClient
Imports System.Transactions

Public Class FrmAdd_GroupP
    Public str_name As String
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub FrmAdd_GroupP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Txtname.Focus()
    End Sub

    Private Sub FrmAdd_GroupP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmAdd_GroupP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If LEdit.Text = "0" Then
            TxtCash1.Text = "0"
            TxtCash2.Text = "0"
            TxtCash3.Text = "0"
            TxtCash4.Text = "0"
            TxtCash5.Text = "0"
            TxtCash6.Text = "0"
            TxtDCash1.Text = "0"
            TxtDCash2.Text = "0"
            TxtDCash3.Text = "0"
            TxtCashP1.Text = "0"
            TxtCashP2.Text = "0"
            TxtCashP3.Text = "0"
            TxtCashP4.Text = "0"
            TxtCashP5.Text = "0"
            TxtCashP6.Text = "0"
            TxtDP1.Text = "0"
            TxtDP2.Text = "0"
            TxtDP3.Text = "0"
            TxtMon.Text = "0"
            TxtChk1.Text = "0"
            TxtChk2.Text = "0"
            TxtChk3.Text = "0"
            TxtChk4.Text = "0"
            TxtChk5.Text = "0"
            TxtChk6.Text = "0"
            TxtDChk1.Text = "0"
            TxtDChk2.Text = "0"
            TxtDChk3.Text = "0"
            TxtDCard.Text = "0"
            ChkCash.Checked = True
            ChKHajm.Checked = True
            ChkKala.Checked = True
            ChkPeople.Enabled = False
            TxtMon.Enabled = False
            CmbCost.Text = CmbCost.Items(1)
        Else
            Me.InfoGroup(CLng(LEdit.Text))
        End If
        DGV.Columns("cln_ta").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetLevel()
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash2.Focus()
    End Sub

    Private Sub TxtMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash1.KeyPress
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

    Private Sub TxtCash1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash1.TextChanged
        If Not (CheckDigit(Format$(TxtCash1.Text.Replace(",", "")))) Then
            TxtCash1.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash1.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash1.Text.Replace(",", ""))
            TxtCash1.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash1.Text = CDbl(TxtCash1.Text)
        End If
        SetLevel()
    End Sub


    Private Sub TxtDCash1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDCash1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash3.Focus()
    End Sub

    Private Sub TxtDCash1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDCash1.KeyPress
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
            If InStr(TxtDCash1.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDCash1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDCash1.LostFocus
        If CDbl(TxtDCash1.Text) > 100 Then TxtDCash1.Text = 100
        TxtDCash1.Text = Math.Round(CDbl(TxtDCash1.Text), 2)
    End Sub

    Private Sub Txtcash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDCash1.TextChanged
        Try
            If Not (CheckDigit(TxtDCash1.Text)) Then
                TxtDCash1.Text = 0
                Exit Sub
            End If
            If Not TxtDCash1.Text.Trim.Contains(".") Then TxtDCash1.Text = CDbl(TxtDCash1.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash1.Focus()
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try
            If e.ColumnIndex = 0 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV.RowCount - 1 Then
                        SendKeys.Send("+{TAB}")
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 1 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV.RowCount - 1 Then
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV.CurrentRow.Index <> DGV.RowCount - 1 Then
                        DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
                    Else
                        DGV.Item("Cln_Az", DGV.CurrentRow.Index).Value = ""
                        DGV.Item("Cln_Ta", DGV.CurrentRow.Index).Value = ""
                        DGV.Item("Cln_Darsad", DGV.CurrentRow.Index).Value = ""
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        Try
            If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_Az", DGV.CurrentRow.Index).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub


    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Then
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = (vbBack) Then
                e.Handled = False
            End If
            If e.KeyChar = (vbTab) Then
                e.Handled = False
            End If
            Exit Sub
        End If

        If DGV.CurrentCell.ColumnIndex = 2 Then
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
                If InStr(txt_dgv.Text, "/") = False Then
                    e.Handled = False
                    e.KeyChar = "/"
                End If
            End If
            Exit Sub
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigitWithOutpoint(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If
            ElseIf DGV.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) > 100 Then txt_dgv.Text = 100
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        Me.Close()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GroupVije.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdcan.Enabled = True Then cmdcan_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try

            If String.IsNullOrEmpty(Txtname.Text.Trim) Then
                MessageBox.Show("نام گروه را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtname.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtCash1.Text) Or String.IsNullOrEmpty(TxtCash2.Text) Or String.IsNullOrEmpty(TxtDCash1.Text) Then
                MessageBox.Show("مقادیر تخفیف نقدی سطح یک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCash3.Text) Or String.IsNullOrEmpty(TxtCash4.Text) Or String.IsNullOrEmpty(TxtDCash2.Text) Then
                MessageBox.Show("مقادیر تخفیف نقدی سطح دوم نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCash5.Text) Or String.IsNullOrEmpty(TxtCash6.Text) Or String.IsNullOrEmpty(TxtDCash3.Text) Then
                MessageBox.Show("مقادیر تخفیف نقدی سطح سوم نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(TxtCashP1.Text) Or String.IsNullOrEmpty(TxtCashP2.Text) Or String.IsNullOrEmpty(TxtDP1.Text) Then
                MessageBox.Show("مقادیر تخفیف پله ای سطح یک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCashP3.Text) Or String.IsNullOrEmpty(TxtCashP4.Text) Or String.IsNullOrEmpty(TxtDP2.Text) Then
                MessageBox.Show("مقادیر تخفیف پله ای سطح دوم نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCashP5.Text) Or String.IsNullOrEmpty(TxtCashP6.Text) Or String.IsNullOrEmpty(TxtDP3.Text) Then
                MessageBox.Show("مقادیر تخفیف پله ای سطح سوم نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(TxtChk1.Text) Or String.IsNullOrEmpty(TxtChk2.Text) Or String.IsNullOrEmpty(TxtDChk1.Text) Then
                MessageBox.Show("مقادیر تخفیف تسویه چک سطح یک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtChk3.Text) Or String.IsNullOrEmpty(TxtChk4.Text) Or String.IsNullOrEmpty(TxtDChk2.Text) Then
                MessageBox.Show("مقادیر تخفیف تسویه چک سطح دوم نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtChk5.Text) Or String.IsNullOrEmpty(TxtChk6.Text) Or String.IsNullOrEmpty(TxtDChk3.Text) Then
                MessageBox.Show("مقادیر تخفیف تسویه چک سطح سوم نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtDCard.Text) Then
                MessageBox.Show("مقادیر تخفیفات کارتخوان نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '//////////////////////////////////////////////////////////////////////////////
            If CDbl(TxtCash1.Text) <> 0 Or CDbl(TxtCash2.Text) <> 0 Or CDbl(TxtDCash1.Text) <> 0 Then
                If (TxtCash1.Enabled = True And CDbl(TxtCash1.Text) <= 0) Or (TxtCash2.Enabled = True And CDbl(TxtCash2.Text) <= 0) Or (TxtDCash1.Enabled = True And CDbl(TxtDCash1.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف نقدی سطح یک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtCash1.Text) > CDbl(TxtCash2.Text) Then
                    MessageBox.Show("مبلغ تخفیف نقدی سطح یک اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCash2.Focus()
                    Exit Sub
                End If
            End If
            If CDbl(TxtCash3.Text) <> 0 Or CDbl(TxtCash4.Text) <> 0 Or CDbl(TxtDCash2.Text) <> 0 Then
                If (TxtCash3.Enabled = True And CDbl(TxtCash3.Text) <= 0) Or (TxtCash4.Enabled = True And CDbl(TxtCash4.Text) <= 0) Or (TxtDCash2.Enabled = True And CDbl(TxtDCash2.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف نقدی سطح دوم را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtCash3.Text) > CDbl(TxtCash4.Text) Then
                    MessageBox.Show("مبلغ تخفیف نقدی سطح دوم اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCash4.Focus()
                    Exit Sub
                End If
                If CDbl(TxtCash2.Text) >= CDbl(TxtCash3.Text) Then
                    MessageBox.Show("مبلغ تخفیف نقدی سطح دوم با سطح یک مطابقت ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCash3.Focus()
                    Exit Sub
                End If
            End If
            If CDbl(TxtCash5.Text) <> 0 Or CDbl(TxtCash6.Text) <> 0 Or CDbl(TxtDCash3.Text) <> 0 Then
                If (TxtCash5.Enabled = True And CDbl(TxtCash5.Text) <= 0) Or (TxtCash6.Enabled = True And CDbl(TxtCash6.Text) <= 0) Or (TxtDCash3.Enabled = True And CDbl(TxtDCash3.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف نقدی سطح سوم را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtCash5.Text) > CDbl(TxtCash6.Text) Then
                    MessageBox.Show("مبلغ تخفیف نقدی سطح سوم اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCash6.Focus()
                    Exit Sub
                End If
                If CDbl(TxtCash4.Text) >= CDbl(TxtCash5.Text) Then
                    MessageBox.Show("مبلغ تخفیف نقدی سطح سوم با سطح دوم مطابقت ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCash5.Focus()
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''
            If CDbl(TxtCashP1.Text) <> 0 Or CDbl(TxtCashP2.Text) <> 0 Or CDbl(TxtDP1.Text) <> 0 Then
                If (TxtCashP1.Enabled = True And CDbl(TxtCashP1.Text) <= 0) Or (TxtCashP2.Enabled = True And CDbl(TxtCashP2.Text) <= 0) Or (TxtDP1.Enabled = True And CDbl(TxtDP1.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف پله ای سطح یک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtCashP1.Text) > CDbl(TxtCashP2.Text) Then
                    MessageBox.Show("مبلغ تخفیف پله ای سطح یک اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCashP2.Focus()
                    Exit Sub
                End If
            End If

            If CDbl(TxtCashP3.Text) <> 0 Or CDbl(TxtCashP4.Text) <> 0 Or CDbl(TxtDP2.Text) <> 0 Then
                If (TxtCashP3.Enabled = True And CDbl(TxtCashP3.Text) <= 0) Or (TxtCashP4.Enabled = True And CDbl(TxtCashP4.Text) <= 0) Or (TxtDP2.Enabled = True And CDbl(TxtDP2.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف پله ای سطح دوم را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtCashP3.Text) > CDbl(TxtCashP4.Text) Then
                    MessageBox.Show("مبلغ تخفیف پله ای سطح دوم اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCashP4.Focus()
                    Exit Sub
                End If
                If CDbl(TxtCashP2.Text) >= CDbl(TxtCashP3.Text) Then
                    MessageBox.Show("مبلغ تخفیف پله ای سطح دوم با سطح یک مطابقت ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCashP3.Focus()
                    Exit Sub
                End If
            End If

            If CDbl(TxtCashP5.Text) <> 0 Or CDbl(TxtCashP6.Text) <> 0 Or CDbl(TxtDP3.Text) <> 0 Then
                If String.IsNullOrEmpty(TxtCashP5.Text) Or String.IsNullOrEmpty(TxtCashP6.Text) Or String.IsNullOrEmpty(TxtDP3.Text) Then
                    MessageBox.Show("مقادیر تخفیف پله ای سطح سوم را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtCashP5.Text) > CDbl(TxtCashP6.Text) Then
                    MessageBox.Show("مبلغ تخفیف پله ای سطح سوم اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCashP6.Focus()
                    Exit Sub
                End If
                If CDbl(TxtCashP4.Text) >= CDbl(TxtCashP5.Text) Then
                    MessageBox.Show("مبلغ تخفیف پله ای سطح سوم با سطح دوم مطابقت ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtCashP5.Focus()
                    Exit Sub
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CDbl(TxtChk1.Text) <> 0 Or CDbl(TxtChk2.Text) <> 0 Or CDbl(TxtDChk1.Text) <> 0 Then
                If (TxtChk1.Enabled = True And CDbl(TxtChk1.Text) <= 0) Or (TxtChk2.Enabled = True And CDbl(TxtChk2.Text) <= 0) Or (TxtDChk1.Enabled = True And CDbl(TxtDChk1.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف تسویه چک سطح یک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtChk1.Text) > CDbl(TxtChk2.Text) Then
                    MessageBox.Show("مبلغ تخفیف تسویه چک سطح یک اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtChk2.Focus()
                    Exit Sub
                End If
            End If
            If CDbl(TxtChk3.Text) <> 0 Or CDbl(TxtChk4.Text) <> 0 Or CDbl(TxtDChk2.Text) <> 0 Then
                If (TxtChk3.Enabled = True And CDbl(TxtChk3.Text) <= 0) Or (TxtChk4.Enabled = True And CDbl(TxtChk4.Text) <= 0) Or (TxtDChk2.Enabled = True And CDbl(TxtDChk2.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف تسویه چک سطح دوم را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtChk3.Text) > CDbl(TxtChk4.Text) Then
                    MessageBox.Show("مبلغ تخفیف تسویه چک سطح دوم اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtChk4.Focus()
                    Exit Sub
                End If
                If CDbl(TxtChk2.Text) >= CDbl(TxtChk3.Text) Then
                    MessageBox.Show("مبلغ تخفیف تسویه چک سطح دوم با سطح یک مطابقت ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtChk3.Focus()
                    Exit Sub
                End If
            End If
            If CDbl(TxtChk5.Text) <> 0 Or CDbl(TxtChk6.Text) <> 0 Or CDbl(TxtDChk3.Text) <> 0 Then
                If (TxtChk5.Enabled = True And CDbl(TxtChk5.Text) <= 0) Or (TxtChk6.Enabled = True And CDbl(TxtChk6.Text) <= 0) Or (TxtDChk3.Enabled = True And CDbl(TxtDChk3.Text) <= 0) Then
                    MessageBox.Show("مقادیر تخفیف تسویه چک سطح سوم را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If CDbl(TxtChk5.Text) > CDbl(TxtChk6.Text) Then
                    MessageBox.Show("مبلغ تخفیف تسویه چک سطح سوم اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtChk6.Focus()
                    Exit Sub
                End If
                If CDbl(TxtChk4.Text) >= CDbl(TxtChk5.Text) Then
                    MessageBox.Show("مبلغ تخفیف تسویه چک سطح سوم با سطح دوم مطابقت ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtChk5.Focus()
                    Exit Sub
                End If
            End If

            If ChkValue.Checked = True And CDbl(TxtMon.Text) <= 0 Then
                MessageBox.Show("مبلغ سطح اعتبار گروهی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtMon.Focus()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            For i As Integer = 0 To DGV.RowCount - 2
                If DGV.Item("Cln_Az", i).Value = "" Or DGV.Item("Cln_Az", i).Value = "0" Then
                    MessageBox.Show("از مبلغ در ردیف شماره " & "{" & i + 1 & "}" & "نا معتبر است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If DGV.Item("Cln_ta", i).Value = "" Or DGV.Item("Cln_ta", i).Value = "0" Then
                    MessageBox.Show("تا مبلغ در ردیف شماره " & "{" & i + 1 & "}" & "نا معتبر است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If DGV.Item("Cln_Darsad", i).Value = "" Or DGV.Item("Cln_Darsad", i).Value = "0" Then
                    MessageBox.Show("درصد در ردیف شماره " & "{" & i + 1 & "}" & "نا معتبر است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If CDbl(DGV.Item("Cln_Az", i).Value) > (DGV.Item("Cln_ta", i).Value) Then
                    MessageBox.Show("مقادیر از مبلغ تا مبلغ در ردیف شماره " & "{" & i + 1 & "}" & "نا معتبر است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim count As Integer = 0
                For j As Integer = 0 To DGV.RowCount - 2
                    If (DGV.Item("Cln_Az", i).Value.ToString = DGV.Item("Cln_Az", j).Value.ToString) And (DGV.Item("Cln_ta", i).Value.ToString = DGV.Item("Cln_ta", j).Value.ToString) Then
                        count += 1
                    End If
                    If count > 1 Then
                        MessageBox.Show("تخفیفات سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Next j
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''

            If LEdit.Text = "0" Then
                If Not Me.AreYouAddBank(Txtname.Text.Trim) Then
                    MessageBox.Show("  گروه مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If SaveCost() Then Me.Close()
            End If

            ''''''''''''''''
            If LEdit.Text <> "0" Then
                If Not Me.AreYouEditBank(Txtname.Text.Trim) Then
                    MessageBox.Show("گروه مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If EditCost() Then Me.Close()
            End If

        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("گروه انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "cmdsave_Click")
            End If

        End Try
    End Sub

    Private Function SaveCost() As Boolean
        Me.Enabled = False
        Dim id As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("INSERT INTO Define_Group_P(nam,Cash1,Cash2,Cash3,Cash4,Cash5,Cash6,CashP1,CashP2,CashP3,CashP4,CashP5,CashP6,DCash1,DCash2,DCash3,DP1,DP2,DP3,Hajm,KalaCash,HKalaCash,KindCost,GroupValue,GroupValueMon,GroupPeople,Chk1,Chk2,Chk3,Chk4,Chk5,Chk6,DChk1,DChk2,DChk3,DCard) VALUES(@nam,@Cash1,@Cash2,@Cash3,@Cash4,@Cash5,@Cash6,@CashP1,@CashP2,@CashP3,@CashP4,@CashP5,@CashP6,@DCash1,@DCash2,@DCash3,@DP1,@DP2,@DP3,@Hajm,@KalaCash,@HKalaCash,@KindCost,@GroupValue,@GroupValueMon,@GroupPeople,@Chk1,@Chk2,@Chk3,@Chk4,@Chk5,@Chk6,@DChk1,@DChk2,@DChk3,@DCard);SELECT @@IDENTITY ", ConectionBank)
                Cmd.Parameters.AddWithValue("@nam", SqlDbType.NVarChar).Value = Txtname.Text.Trim
                Cmd.Parameters.AddWithValue("@Cash1", SqlDbType.BigInt).Value = CDbl(TxtCash1.Text)
                Cmd.Parameters.AddWithValue("@Cash2", SqlDbType.BigInt).Value = CDbl(TxtCash2.Text)
                Cmd.Parameters.AddWithValue("@Cash3", SqlDbType.BigInt).Value = CDbl(TxtCash3.Text)
                Cmd.Parameters.AddWithValue("@Cash4", SqlDbType.BigInt).Value = CDbl(TxtCash4.Text)
                Cmd.Parameters.AddWithValue("@Cash5", SqlDbType.BigInt).Value = CDbl(TxtCash5.Text)
                Cmd.Parameters.AddWithValue("@Cash6", SqlDbType.BigInt).Value = CDbl(TxtCash6.Text)
                Cmd.Parameters.AddWithValue("@CashP1", SqlDbType.BigInt).Value = CDbl(TxtCashP1.Text)
                Cmd.Parameters.AddWithValue("@CashP2", SqlDbType.BigInt).Value = CDbl(TxtCashP2.Text)
                Cmd.Parameters.AddWithValue("@CashP3", SqlDbType.BigInt).Value = CDbl(TxtCashP3.Text)
                Cmd.Parameters.AddWithValue("@CashP4", SqlDbType.BigInt).Value = CDbl(TxtCashP4.Text)
                Cmd.Parameters.AddWithValue("@CashP5", SqlDbType.BigInt).Value = CDbl(TxtCashP5.Text)
                Cmd.Parameters.AddWithValue("@CashP6", SqlDbType.BigInt).Value = CDbl(TxtCashP6.Text)
                Cmd.Parameters.AddWithValue("@DCash1", SqlDbType.Float).Value = CDbl(TxtDCash1.Text)
                Cmd.Parameters.AddWithValue("@DCash2", SqlDbType.Float).Value = CDbl(TxtDCash2.Text)
                Cmd.Parameters.AddWithValue("@DCash3", SqlDbType.Float).Value = CDbl(TxtDCash3.Text)
                Cmd.Parameters.AddWithValue("@DP1", SqlDbType.Float).Value = CDbl(TxtDP1.Text)
                Cmd.Parameters.AddWithValue("@DP2", SqlDbType.Float).Value = CDbl(TxtDP2.Text)
                Cmd.Parameters.AddWithValue("@DP3", SqlDbType.Float).Value = CDbl(TxtDP3.Text)
                Cmd.Parameters.AddWithValue("@Chk1", SqlDbType.BigInt).Value = CDbl(TxtChk1.Text)
                Cmd.Parameters.AddWithValue("@Chk2", SqlDbType.BigInt).Value = CDbl(TxtChk2.Text)
                Cmd.Parameters.AddWithValue("@Chk3", SqlDbType.BigInt).Value = CDbl(TxtChk3.Text)
                Cmd.Parameters.AddWithValue("@Chk4", SqlDbType.BigInt).Value = CDbl(TxtChk4.Text)
                Cmd.Parameters.AddWithValue("@Chk5", SqlDbType.BigInt).Value = CDbl(TxtChk5.Text)
                Cmd.Parameters.AddWithValue("@Chk6", SqlDbType.BigInt).Value = CDbl(TxtChk6.Text)
                Cmd.Parameters.AddWithValue("@DChk1", SqlDbType.Float).Value = CDbl(TxtDChk1.Text)
                Cmd.Parameters.AddWithValue("@DChk2", SqlDbType.Float).Value = CDbl(TxtDChk2.Text)
                Cmd.Parameters.AddWithValue("@DChk3", SqlDbType.Float).Value = CDbl(TxtDChk3.Text)
                Cmd.Parameters.AddWithValue("@Hajm", SqlDbType.Bit).Value = CBool(ChKHajm.CheckState)
                Cmd.Parameters.AddWithValue("@KalaCash", SqlDbType.Bit).Value = CBool(ChkCash.CheckState)
                Cmd.Parameters.AddWithValue("@HKalaCash", SqlDbType.Bit).Value = CBool(ChkKala.CheckState)
                Cmd.Parameters.AddWithValue("@KindCost", SqlDbType.Int).Value = If(CmbCost.Text = CmbCost.Items(0), 0, If(CmbCost.Text = CmbCost.Items(1), 1, 2))
                Cmd.Parameters.AddWithValue("@GroupValue", SqlDbType.Bit).Value = CBool(ChkValue.CheckState)
                Cmd.Parameters.AddWithValue("@GroupPeople", SqlDbType.Bit).Value = CBool(ChkPeople.CheckState)
                Cmd.Parameters.AddWithValue("@GroupValueMon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@DCard", SqlDbType.Float).Value = CDbl(TxtDCard.Text)
                id = Cmd.ExecuteScalar()
            End Using

            If DGV.RowCount > 1 Then
                Using Cmd As New SqlCommand("INSERT INTO Define_List_Group_P(AzMon,TaMon,Darsad,LinkId) VALUES(@AzMon,@TaMon,@Darsad,@LinkId)", ConectionBank)
                    For i As Integer = 0 To DGV.RowCount - 2
                        Cmd.Parameters.AddWithValue("@AzMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Az", i).Value)
                        Cmd.Parameters.AddWithValue("@TaMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_ta", i).Value)
                        Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@LinkId", SqlDbType.BigInt).Value = id
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
            End If

            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه های ویژه", "جدید", "ثبت گروه ویژه : " & Txtname.Text.Trim, "")
            Me.Enabled = True
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "SaveCost")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Enabled = True
            Return False
        End Try
    End Function

    Private Function EditCost() As Boolean
        Me.Enabled = False
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("UPDATE Define_Group_P SET nam=@nam,Cash1=@Cash1,Cash2=@Cash2,Cash3=@Cash3,Cash4=@Cash4,Cash5=@Cash5,Cash6=@Cash6,CashP1=@CashP1,CashP2=@CashP2,CashP3=@CashP3,CashP4=@CashP4,CashP5=@CashP5,CashP6=@CashP6,DCash1=@DCash1,DCash2=@DCash2,DCash3=@DCash3,DP1=@DP1,DP2=@DP2,DP3=@DP3,Hajm=@Hajm,KalaCash=@KalaCash,HKalaCash=@HKalaCash,KindCost=@KindCost,GroupValue=@GroupValue,GroupValueMon=@GroupValueMon,GroupPeople=@GroupPeople,Chk1=@Chk1,Chk2=@Chk2,Chk3=@Chk3,Chk4=@Chk4,Chk5=@Chk5,Chk6=@Chk6,DChk1=@DChk1,DChk2=@DChk2,DChk3=@DChk3,DCard=@DCard WHERE Id=" & CLng(LEdit.Text), ConectionBank)
                Cmd.Parameters.AddWithValue("@nam", SqlDbType.NVarChar).Value = Txtname.Text.Trim
                Cmd.Parameters.AddWithValue("@Cash1", SqlDbType.BigInt).Value = CDbl(TxtCash1.Text)
                Cmd.Parameters.AddWithValue("@Cash2", SqlDbType.BigInt).Value = CDbl(TxtCash2.Text)
                Cmd.Parameters.AddWithValue("@Cash3", SqlDbType.BigInt).Value = CDbl(TxtCash3.Text)
                Cmd.Parameters.AddWithValue("@Cash4", SqlDbType.BigInt).Value = CDbl(TxtCash4.Text)
                Cmd.Parameters.AddWithValue("@Cash5", SqlDbType.BigInt).Value = CDbl(TxtCash5.Text)
                Cmd.Parameters.AddWithValue("@Cash6", SqlDbType.BigInt).Value = CDbl(TxtCash6.Text)
                Cmd.Parameters.AddWithValue("@CashP1", SqlDbType.BigInt).Value = CDbl(TxtCashP1.Text)
                Cmd.Parameters.AddWithValue("@CashP2", SqlDbType.BigInt).Value = CDbl(TxtCashP2.Text)
                Cmd.Parameters.AddWithValue("@CashP3", SqlDbType.BigInt).Value = CDbl(TxtCashP3.Text)
                Cmd.Parameters.AddWithValue("@CashP4", SqlDbType.BigInt).Value = CDbl(TxtCashP4.Text)
                Cmd.Parameters.AddWithValue("@CashP5", SqlDbType.BigInt).Value = CDbl(TxtCashP5.Text)
                Cmd.Parameters.AddWithValue("@CashP6", SqlDbType.BigInt).Value = CDbl(TxtCashP6.Text)
                Cmd.Parameters.AddWithValue("@DCash1", SqlDbType.Float).Value = CDbl(TxtDCash1.Text)
                Cmd.Parameters.AddWithValue("@DCash2", SqlDbType.Float).Value = CDbl(TxtDCash2.Text)
                Cmd.Parameters.AddWithValue("@DCash3", SqlDbType.Float).Value = CDbl(TxtDCash3.Text)
                Cmd.Parameters.AddWithValue("@DP1", SqlDbType.Float).Value = CDbl(TxtDP1.Text)
                Cmd.Parameters.AddWithValue("@DP2", SqlDbType.Float).Value = CDbl(TxtDP2.Text)
                Cmd.Parameters.AddWithValue("@DP3", SqlDbType.Float).Value = CDbl(TxtDP3.Text)
                Cmd.Parameters.AddWithValue("@Chk1", SqlDbType.BigInt).Value = CDbl(TxtChk1.Text)
                Cmd.Parameters.AddWithValue("@Chk2", SqlDbType.BigInt).Value = CDbl(TxtChk2.Text)
                Cmd.Parameters.AddWithValue("@Chk3", SqlDbType.BigInt).Value = CDbl(TxtChk3.Text)
                Cmd.Parameters.AddWithValue("@Chk4", SqlDbType.BigInt).Value = CDbl(TxtChk4.Text)
                Cmd.Parameters.AddWithValue("@Chk5", SqlDbType.BigInt).Value = CDbl(TxtChk5.Text)
                Cmd.Parameters.AddWithValue("@Chk6", SqlDbType.BigInt).Value = CDbl(TxtChk6.Text)
                Cmd.Parameters.AddWithValue("@DChk1", SqlDbType.Float).Value = CDbl(TxtDChk1.Text)
                Cmd.Parameters.AddWithValue("@DChk2", SqlDbType.Float).Value = CDbl(TxtDChk2.Text)
                Cmd.Parameters.AddWithValue("@DChk3", SqlDbType.Float).Value = CDbl(TxtDChk3.Text)
                Cmd.Parameters.AddWithValue("@Hajm", SqlDbType.Bit).Value = CBool(ChKHajm.CheckState)
                Cmd.Parameters.AddWithValue("@KalaCash", SqlDbType.Bit).Value = CBool(ChkCash.CheckState)
                Cmd.Parameters.AddWithValue("@HKalaCash", SqlDbType.Bit).Value = CBool(ChkKala.CheckState)
                Cmd.Parameters.AddWithValue("@KindCost", SqlDbType.Int).Value = If(CmbCost.Text = CmbCost.Items(0), 0, If(CmbCost.Text = CmbCost.Items(1), 1, 2))
                Cmd.Parameters.AddWithValue("@GroupValue", SqlDbType.Bit).Value = CBool(ChkValue.CheckState)
                Cmd.Parameters.AddWithValue("@GroupPeople", SqlDbType.Bit).Value = CBool(ChkPeople.CheckState)
                Cmd.Parameters.AddWithValue("@GroupValueMon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@DCard", SqlDbType.Float).Value = CDbl(TxtDCard.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("DELETE FROM Define_List_Group_P  WHERE LinkId=" & CLng(LEdit.Text), ConectionBank)
                Cmd.ExecuteNonQuery()
            End Using

            If DGV.RowCount > 1 Then
                Using Cmd As New SqlCommand("INSERT INTO Define_List_Group_P(AzMon,TaMon,Darsad,LinkId) VALUES(@AzMon,@TaMon,@Darsad,@LinkId)", ConectionBank)
                    For i As Integer = 0 To DGV.RowCount - 2
                        Cmd.Parameters.AddWithValue("@AzMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Az", i).Value)
                        Cmd.Parameters.AddWithValue("@TaMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_ta", i).Value)
                        Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                        Cmd.Parameters.AddWithValue("@LinkId", SqlDbType.BigInt).Value = CLng(LEdit.Text)
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
            End If

            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه های ویژه", "ویرایش", "ویرایش گروه ویژه از : " & str_name & " به " & Txtname.Text.Trim, "")

            Me.Enabled = True
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "SaveCost")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Enabled = True
            Return False
        End Try
    End Function

    Private Function AreYouAddBank(ByVal nam As String) As Boolean
        Dim T_str As String = "select nam  from Define_Group_P WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Group_P")
        If T_ds.Tables("Define_Group_P").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditBank(ByVal nam As String) As Boolean
        Dim T_str As String = "select nam  from Define_Group_P WHERE nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Group_P")
        If T_ds.Tables("Define_Group_P").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Group_P").Rows(0).Item("nam") <> Txtname.Text) Or (T_ds.Tables("Define_Group_P").Rows(0).Item("nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub InfoGroup(ByVal Id As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Dim dtr As SqlDataReader = Nothing

            Using cmd As New SqlCommand("SELECT nam,Cash1,Cash2,Cash3,Cash4,Cash5,Cash6,CashP1,CashP2,CashP3,CashP4,CashP5,CashP6,DCash1,DCash2,DCash3,DP1,DP2,DP3,Hajm,KalaCash,HKalaCash,KindCost,GroupValue,GroupValueMon,GroupPeople,[Chk1],[Chk2],[Chk3],[Chk4],[Chk5],[Chk6],[DChk1],[DChk2],[DChk3],[DCard] FROM Define_Group_P WHERE Id =" & Id, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                Txtname.Text = dtr("nam")
                TxtCash1.Text = dtr("Cash1")
                TxtCash2.Text = dtr("Cash2")
                TxtCash3.Text = dtr("Cash3")
                TxtCash4.Text = dtr("Cash4")
                TxtCash5.Text = dtr("Cash5")
                TxtCash6.Text = dtr("Cash6")
                TxtDCash1.Text = dtr("DCash1")
                TxtDCash2.Text = dtr("DCash2")
                TxtDCash3.Text = dtr("DCash3")
                TxtCashP1.Text = dtr("CashP1")
                TxtCashP2.Text = dtr("CashP2")
                TxtCashP3.Text = dtr("CashP3")
                TxtCashP4.Text = dtr("CashP4")
                TxtCashP5.Text = dtr("CashP5")
                TxtCashP6.Text = dtr("CashP6")
                TxtMon.Text = dtr("GroupValueMon")
                TxtDP1.Text = dtr("DP1")
                TxtDP2.Text = dtr("DP2")
                TxtDP3.Text = dtr("DP3")
                TxtChk1.Text = dtr("Chk1")
                TxtChk2.Text = dtr("Chk2")
                TxtChk3.Text = dtr("Chk3")
                TxtChk4.Text = dtr("Chk4")
                TxtChk5.Text = dtr("Chk5")
                TxtChk6.Text = dtr("Chk6")
                TxtDChk1.Text = dtr("DChk1")
                TxtDChk2.Text = dtr("DChk2")
                TxtDChk3.Text = dtr("DChk3")
                TxtDCard.Text = dtr("DCard")
                ChKHajm.Checked = dtr("Hajm")
                ChkCash.Checked = dtr("KalaCash")
                ChkKala.Checked = dtr("HKalaCash")
                ChkValue.Checked = dtr("GroupValue")
                ChkPeople.Checked = dtr("GroupPeople")
                CmbCost.Text = CmbCost.Items(dtr("KindCost"))
                If ChkPeople.Checked = True Then ChkPeople.Enabled = True
                If ChkValue.Checked = True Then
                    TxtMon.Enabled = True
                Else
                    TxtMon.Enabled = False
                End If
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Me.Close()
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            dtr = Nothing
            Using cmd As New SqlCommand("SELECT AzMon, TaMon, Darsad FROM Define_List_Group_P WHERE LinkId =" & Id, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using
            If dtr.HasRows Then
                DGV.AllowUserToAddRows = False
                While dtr.Read
                    DGV.Rows.Add()
                    DGV.Item("Cln_Az", DGV.RowCount - 1).Value = FormatNumber(dtr("AzMon"), 0)
                    DGV.Item("Cln_ta", DGV.RowCount - 1).Value = FormatNumber(dtr("TaMon"), 0)
                    DGV.Item("Cln_Darsad", DGV.RowCount - 1).Value = Replace(dtr("Darsad"), ".", "/")
                End While
                DGV.AllowUserToAddRows = True
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAdd_GroupP", "InfoGroup")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub TxtCash2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash2.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDCash1.Focus()
    End Sub

    Private Sub TxtCash2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash2.KeyPress
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

    Private Sub TxtCash2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash2.TextChanged
        If Not (CheckDigit(Format$(TxtCash2.Text.Replace(",", "")))) Then
            TxtCash2.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash2.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash2.Text.Replace(",", ""))
            TxtCash2.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash2.Text = CDbl(TxtCash2.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCash3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash3.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash4.Focus()
    End Sub

    Private Sub TxtCash3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash3.KeyPress
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

    Private Sub TxtCash3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash3.TextChanged
        If Not (CheckDigit(Format$(TxtCash3.Text.Replace(",", "")))) Then
            TxtCash3.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash3.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash3.Text.Replace(",", ""))
            TxtCash3.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash3.Text = CDbl(TxtCash3.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCash4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash4.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDCash2.Focus()
    End Sub

    Private Sub TxtCash4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash4.KeyPress
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

    Private Sub TxtCash4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash4.TextChanged
        If Not (CheckDigit(Format$(TxtCash4.Text.Replace(",", "")))) Then
            TxtCash4.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash4.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash4.Text.Replace(",", ""))
            TxtCash4.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash4.Text = CDbl(TxtCash4.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCash5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash5.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash6.Focus()
    End Sub

    Private Sub TxtCash5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash5.KeyPress
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

    Private Sub TxtCash5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash5.TextChanged
        If Not (CheckDigit(Format$(TxtCash5.Text.Replace(",", "")))) Then
            TxtCash5.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash5.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash5.Text.Replace(",", ""))
            TxtCash5.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash5.Text = CDbl(TxtCash5.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCash6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash6.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDCash3.Focus()
    End Sub

    Private Sub TxtCash6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash6.KeyPress
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

    Private Sub TxtCash6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash6.TextChanged
        If Not (CheckDigit(Format$(TxtCash6.Text.Replace(",", "")))) Then
            TxtCash6.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash6.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash6.Text.Replace(",", ""))
            TxtCash6.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash6.Text = CDbl(TxtCash6.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCashP1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashP1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCashP2.Focus()
    End Sub

    Private Sub TxtCashP1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCashP1.KeyPress
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

    Private Sub TxtCashP1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP1.TextChanged
        If Not (CheckDigit(Format$(TxtCashP1.Text.Replace(",", "")))) Then
            TxtCashP1.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP1.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP1.Text.Replace(",", ""))
            TxtCashP1.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP1.Text = CDbl(TxtCashP1.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCashP2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashP2.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDP1.Focus()
    End Sub

    Private Sub TxtCashP2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCashP2.KeyPress
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

    Private Sub TxtCashP2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP2.TextChanged
        If Not (CheckDigit(Format$(TxtCashP2.Text.Replace(",", "")))) Then
            TxtCashP2.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP2.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP2.Text.Replace(",", ""))
            TxtCashP2.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP2.Text = CDbl(TxtCashP2.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCashP3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashP3.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCashP4.Focus()
    End Sub

    Private Sub TxtCashP3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCashP3.KeyPress
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

    Private Sub TxtCashP3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP3.TextChanged
        If Not (CheckDigit(Format$(TxtCashP3.Text.Replace(",", "")))) Then
            TxtCashP3.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP3.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP3.Text.Replace(",", ""))
            TxtCashP3.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP3.Text = CDbl(TxtCashP3.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCashP4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashP4.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDP2.Focus()
    End Sub

    Private Sub TxtCashP4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCashP4.KeyPress
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

    Private Sub TxtCashP4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP4.TextChanged
        If Not (CheckDigit(Format$(TxtCashP4.Text.Replace(",", "")))) Then
            TxtCashP4.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP4.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP4.Text.Replace(",", ""))
            TxtCashP4.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP4.Text = CDbl(TxtCashP4.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCashP5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashP5.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCashP6.Focus()
    End Sub

    Private Sub TxtCashP5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCashP5.KeyPress
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

    Private Sub TxtCashP5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP5.TextChanged
        If Not (CheckDigit(Format$(TxtCashP5.Text.Replace(",", "")))) Then
            TxtCashP5.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP5.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP5.Text.Replace(",", ""))
            TxtCashP5.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP5.Text = CDbl(TxtCashP5.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtCashP6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashP6.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDP3.Focus()
    End Sub

    Private Sub TxtCashP6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCashP6.KeyPress
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

    Private Sub TxtCashP6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP6.TextChanged
        If Not (CheckDigit(Format$(TxtCashP6.Text.Replace(",", "")))) Then
            TxtCashP6.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP6.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP6.Text.Replace(",", ""))
            TxtCashP6.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP6.Text = CDbl(TxtCashP6.Text)
        End If
        SetLevel()
    End Sub

    Private Sub TxtDCash2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDCash2.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash5.Focus()
    End Sub

    Private Sub TxtDCash2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDCash2.KeyPress
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
            If InStr(TxtDCash2.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDCash2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDCash2.LostFocus
        If CDbl(TxtDCash2.Text) > 100 Then TxtDCash2.Text = 100
        TxtDCash2.Text = Math.Round(CDbl(TxtDCash2.Text), 2)
    End Sub

    Private Sub TxtDCash2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDCash2.TextChanged
        Try
            If Not (CheckDigit(TxtDCash2.Text)) Then
                TxtDCash2.Text = 0
                Exit Sub
            End If
            If Not TxtDCash2.Text.Trim.Contains(".") Then TxtDCash2.Text = CDbl(TxtDCash2.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub TxtDCash3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDCash3.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCashP1.Focus()
    End Sub

    Private Sub TxtDCash3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDCash3.KeyPress
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
            If InStr(TxtDCash3.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDCash3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDCash3.LostFocus
        If CDbl(TxtDCash3.Text) > 100 Then TxtDCash3.Text = 100
        TxtDCash3.Text = Math.Round(CDbl(TxtDCash3.Text), 2)
    End Sub

    Private Sub TxtDCash3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDCash3.TextChanged
        Try
            If Not (CheckDigit(TxtDCash3.Text)) Then
                TxtDCash3.Text = 0
                Exit Sub
            End If
            If Not TxtDCash3.Text.Trim.Contains(".") Then TxtDCash3.Text = CDbl(TxtDCash3.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub TxtDP1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDP1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCashP3.Focus()
    End Sub

    Private Sub TxtDP1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDP1.KeyPress
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
            If InStr(TxtDP1.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDP1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDP1.LostFocus
        If CDbl(TxtDP1.Text) > 100 Then TxtDP1.Text = 100
        TxtDP1.Text = Math.Round(CDbl(TxtDP1.Text), 2)
    End Sub

    Private Sub TxtDP1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDP1.TextChanged
        Try
            If Not (CheckDigit(TxtDP1.Text)) Then
                TxtDP1.Text = 0
                Exit Sub
            End If
            If Not TxtDP1.Text.Trim.Contains(".") Then TxtDP1.Text = CDbl(TxtDP1.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub TxtDP2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDP2.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCashP5.Focus()
    End Sub

    Private Sub TxtDP2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDP2.KeyPress
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
            If InStr(TxtDP2.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDP2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDP2.LostFocus
        If CDbl(TxtDP2.Text) > 100 Then TxtDP2.Text = 100
        TxtDP2.Text = Math.Round(CDbl(TxtDP2.Text), 2)
    End Sub

    Private Sub TxtDP2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDP2.TextChanged
        Try
            If Not (CheckDigit(TxtDP2.Text)) Then
                TxtDP2.Text = 0
                Exit Sub
            End If
            If Not TxtDP2.Text.Trim.Contains(".") Then TxtDP2.Text = CDbl(TxtDP2.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub TxtDP3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDP3.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk1.Focus()
    End Sub

    Private Sub TxtDP3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDP3.KeyPress
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
            If InStr(TxtDP3.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDP3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDP3.LostFocus
        If CDbl(TxtDP3.Text) > 100 Then TxtDP3.Text = 100
        TxtDP3.Text = Math.Round(CDbl(TxtDP3.Text), 2)
    End Sub

    Private Sub TxtDP3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDP3.TextChanged
        Try
            If Not (CheckDigit(TxtDP3.Text)) Then
                TxtDP3.Text = 0
                Exit Sub
            End If
            If Not TxtDP3.Text.Trim.Contains(".") Then TxtDP3.Text = CDbl(TxtDP3.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub
    Private Sub SetLevel()
        If TxtCash1.Text <> "0" And TxtCash2.Text <> "0" And TxtDCash1.Text <> "0" Then
            TxtCash3.Enabled = True
            TxtCash4.Enabled = True
            TxtDCash2.Enabled = True
        Else
            TxtCash3.Text = "0"
            TxtCash4.Text = "0"
            TxtDCash2.Text = "0"
            TxtCash3.Enabled = False
            TxtCash4.Enabled = False
            TxtDCash2.Enabled = False
        End If

        If TxtCash3.Text <> "0" And TxtCash4.Text <> "0" And TxtDCash2.Text <> "0" Then
            TxtCash5.Enabled = True
            TxtCash6.Enabled = True
            TxtDCash3.Enabled = True
        Else
            TxtCash5.Text = "0"
            TxtCash6.Text = "0"
            TxtDCash3.Text = "0"
            TxtCash5.Enabled = False
            TxtCash6.Enabled = False
            TxtDCash3.Enabled = False
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If TxtCashP1.Text <> "0" And TxtCashP2.Text <> "0" And TxtDP1.Text <> "0" Then
            TxtCashP3.Enabled = True
            TxtCashP4.Enabled = True
            TxtDP2.Enabled = True
        Else
            TxtCashP3.Text = "0"
            TxtCashP4.Text = "0"
            TxtDP2.Text = "0"
            TxtCashP3.Enabled = False
            TxtCashP4.Enabled = False
            TxtDP2.Enabled = False
        End If

        If TxtCashP3.Text <> "0" And TxtCashP4.Text <> "0" And TxtDP2.Text <> "0" Then
            TxtCashP5.Enabled = True
            TxtCashP6.Enabled = True
            TxtDP3.Enabled = True
        Else
            TxtCashP5.Text = "0"
            TxtCashP6.Text = "0"
            TxtDP3.Text = "0"
            TxtCashP5.Enabled = False
            TxtCashP6.Enabled = False
            TxtDP3.Enabled = False
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If TxtChk1.Text <> "0" And TxtChk2.Text <> "0" And TxtDChk1.Text <> "0" Then
            TxtChk3.Enabled = True
            TxtChk4.Enabled = True
            TxtDChk2.Enabled = True
        Else
            TxtChk3.Text = "0"
            TxtChk4.Text = "0"
            TxtDChk2.Text = "0"
            TxtChk3.Enabled = False
            TxtChk4.Enabled = False
            TxtDChk2.Enabled = False
        End If

        If TxtChk3.Text <> "0" And TxtChk4.Text <> "0" And TxtDChk2.Text <> "0" Then
            TxtChk5.Enabled = True
            TxtChk6.Enabled = True
            TxtDChk3.Enabled = True
        Else
            TxtChk5.Text = "0"
            TxtChk6.Text = "0"
            TxtDChk3.Text = "0"
            TxtChk5.Enabled = False
            TxtChk6.Enabled = False
            TxtDChk3.Enabled = False
        End If
    End Sub

    Private Sub TxtMon_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon.KeyPress
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
        If Not (CheckDigit(Format$(TxtMon.Text.Replace(",", "")))) Then
            TxtMon.Text = "0"
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
    End Sub

    Private Sub ChkValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkValue.CheckedChanged
        If ChkValue.Checked = True Then
            TxtMon.Enabled = True
            TxtMon.Focus()
            ChkPeople.Enabled = True
        Else
            TxtMon.Text = 0
            TxtMon.Enabled = False
            ChkPeople.Checked = False
            ChkPeople.Enabled = False
        End If
    End Sub

    Private Sub TxtChk1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk2.Focus()
    End Sub

    Private Sub TxtChk1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk1.KeyPress
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

    Private Sub TxtChk1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk1.TextChanged
        If Not (CheckDigit(TxtChk1.Text)) Then
            TxtChk1.Text = "0"
            Exit Sub
        End If
        TxtChk1.Text = CDbl(TxtChk1.Text)
        SetLevel()
    End Sub

    Private Sub TxtChk2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk2.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDChk1.Focus()
    End Sub

    Private Sub TxtChk2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk2.KeyPress
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

    Private Sub TxtChk2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk2.TextChanged
        If Not (CheckDigit(TxtChk2.Text)) Then
            TxtChk2.Text = "0"
            Exit Sub
        End If
        TxtChk2.Text = CDbl(TxtChk2.Text)
        SetLevel()
    End Sub

    Private Sub TxtDChk1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDChk1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk3.Focus()
    End Sub

    Private Sub TxtDChk1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDChk1.KeyPress
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
            If InStr(TxtDChk1.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDChk1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDChk1.LostFocus
        If CDbl(TxtDChk1.Text) > 100 Then TxtDChk1.Text = 100
        TxtDChk1.Text = Math.Round(CDbl(TxtDChk1.Text), 2)
    End Sub

    Private Sub TxtDChk1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDChk1.TextChanged
        Try
            If Not (CheckDigit(TxtDChk1.Text)) Then
                TxtDChk1.Text = 0
                Exit Sub
            End If
            If Not TxtDChk1.Text.Trim.Contains(".") Then TxtDChk1.Text = CDbl(TxtDChk1.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub TxtChk3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk3.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk4.Focus()
    End Sub

    Private Sub TxtChk3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk3.KeyPress
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

    Private Sub TxtChk3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk3.TextChanged
        If Not (CheckDigit(TxtChk3.Text)) Then
            TxtChk3.Text = "0"
            Exit Sub
        End If
        TxtChk3.Text = CDbl(TxtChk3.Text)
        SetLevel()
    End Sub

    Private Sub TxtChk4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk4.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDChk2.Focus()
    End Sub

    Private Sub TxtChk4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk4.KeyPress
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

    Private Sub TxtChk4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk4.TextChanged
        If Not (CheckDigit(TxtChk4.Text)) Then
            TxtChk4.Text = "0"
            Exit Sub
        End If
        TxtChk4.Text = CDbl(TxtChk4.Text)
        SetLevel()
    End Sub

    Private Sub TxtChk5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk5.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk6.Focus()
    End Sub

    Private Sub TxtChk5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk5.KeyPress
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

    Private Sub TxtChk5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk5.TextChanged
        If Not (CheckDigit(TxtChk5.Text)) Then
            TxtChk5.Text = "0"
            Exit Sub
        End If
        TxtChk5.Text = CDbl(TxtChk5.Text)
        SetLevel()
    End Sub

    Private Sub TxtDChk2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDChk2.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk5.Focus()
    End Sub

    Private Sub TxtDChk2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDChk2.KeyPress
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
            If InStr(TxtDChk2.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDChk2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDChk2.LostFocus
        If CDbl(TxtDChk2.Text) > 100 Then TxtDChk2.Text = 100
        TxtDChk2.Text = Math.Round(CDbl(TxtDChk2.Text), 2)
    End Sub

    Private Sub TxtDChk2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDChk2.TextChanged
        Try
            If Not (CheckDigit(TxtDChk2.Text)) Then
                TxtDChk2.Text = 0
                Exit Sub
            End If
            If Not TxtDChk2.Text.Trim.Contains(".") Then TxtDChk2.Text = CDbl(TxtDChk2.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub TxtChk6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk6.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDChk3.Focus()
    End Sub

    Private Sub TxtChk6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk6.KeyPress
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

    Private Sub TxtChk6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk6.TextChanged
        If Not (CheckDigit(TxtChk6.Text)) Then
            TxtChk6.Text = "0"
            Exit Sub
        End If
        TxtChk6.Text = CDbl(TxtChk6.Text)
        SetLevel()
    End Sub

    Private Sub TxtDChk3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDChk3.KeyDown
        If e.KeyCode = Keys.Enter Then CmbCost.Focus()
    End Sub

    Private Sub TxtDChk3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDChk3.KeyPress
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
            If InStr(TxtDChk3.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDChk3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDChk3.LostFocus
        If CDbl(TxtDChk3.Text) > 100 Then TxtDChk3.Text = 100
        TxtDChk3.Text = Math.Round(CDbl(TxtDChk3.Text), 2)
    End Sub

    Private Sub TxtDChk3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDChk3.TextChanged
        Try
            If Not (CheckDigit(TxtDChk3.Text)) Then
                TxtDChk3.Text = 0
                Exit Sub
            End If
            If Not TxtDChk3.Text.Trim.Contains(".") Then TxtDChk3.Text = CDbl(TxtDChk3.Text)
        Catch ex As Exception
        End Try
        SetLevel()
    End Sub

    Private Sub CmbCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCost.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDCard.Focus()
    End Sub

    Private Sub TxtDCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDCard.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtDCard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDCard.KeyPress
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
            If InStr(TxtDChk3.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDCard_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDCard.LostFocus
        If CDbl(TxtDCard.Text) > 100 Then TxtDCard.Text = 100
        TxtDCard.Text = Math.Round(CDbl(TxtDCard.Text), 2)
    End Sub

    Private Sub TxtDCard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDCard.TextChanged
        Try
            If Not (CheckDigit(TxtDCard.Text)) Then
                TxtDCard.Text = 0
                Exit Sub
            End If
            If Not TxtDCard.Text.Trim.Contains(".") Then TxtDCard.Text = CDbl(TxtDCard.Text)
        Catch ex As Exception
        End Try
    End Sub
End Class