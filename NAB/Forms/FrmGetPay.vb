Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmGetPay
    Dim dv As New DataView
    Dim RowCountbank As Long = 0
    Dim PrintSQl As String
    Private Sub ChkAzDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkTime.Checked = False Then Exit Sub

        If ChkAzDate.Checked = True Then
            FarsiDate1.ThisText = GetDate()
            FarsiDate1.Enabled = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
        End If
        Try
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If
            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If
            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        End Try
        Me.calculate()
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTime.Checked = False Then Exit Sub

        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
        End If
        Try
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If

            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If

            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        End Try
        Me.calculate()
    End Sub

    Private Sub FrmGetPay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmGetPay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F44")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
            End If

        End If
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()

        If String.IsNullOrEmpty(LCal.Text) Then
            RdoDay.Checked = True
        Else
            RdoP.Checked = True
            TxtName.Text = LCal.Text
        End If
        DGV2.Columns("Cln_BedBank").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV4.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            cmdadd.Enabled = True
            cmddel.Enabled = True
            cmdedit.Enabled = True
            cmdprint.Enabled = True
            Dim F As String = ""
            If CmbSanad.Text = CmbSanad.Items(0) Then
                F = "F45"
            ElseIf CmbSanad.Text = CmbSanad.Items(1) Then
                F = "F46"
            ElseIf CmbSanad.Text = CmbSanad.Items(2) Then
                F = "F47"
            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                F = "F48"
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                F = "F49"
            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                F = "F50"
            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                F = "F51"
            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                F = "F52"
            ElseIf CmbSanad.Text = CmbSanad.Items(8) Then
                F = "F53"
            ElseIf CmbSanad.Text = CmbSanad.Items(9) Then
                F = "F54"
            ElseIf CmbSanad.Text = CmbSanad.Items(10) Then
                F = "F55"
            ElseIf CmbSanad.Text = CmbSanad.Items(11) Then
                F = "F56"
            ElseIf CmbSanad.Text = CmbSanad.Items(12) Then
                F = "F57"
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                F = "F151"
            End If

            Access_Form = Get_Access_Form(F)
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmddel.Enabled = False
                    cmdedit.Enabled = False
                    cmdprint.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmddel.Enabled = False
                        cmdedit.Enabled = False
                        cmdprint.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            cmdadd.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            cmddel.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            cmdedit.Enabled = False
                        End If
                        If F = "F45" Or F = "F46" Or F = "F47" Or F = "F48" Or F = "F49" Or F = "F50" Then
                            If Access_Form.Substring(4, 1) = 0 Then
                                cmdprint.Enabled = False
                            End If
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                cmdadd.Enabled = False
                cmddel.Enabled = False
                cmdedit.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
        If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then
            If DGV.Item("Cln_Rate", e.RowIndex).Value > 0 Then
                DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            ElseIf DGV.Item("Cln_Rate", e.RowIndex).Value < 0 Then
                DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
            End If
        End If
    End Sub

    Private Sub TxtSanad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSanad.KeyPress
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

    Private Sub TxtSanad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSanad.TextChanged
        If RdoId.Checked = False Then Exit Sub

        Try
            If Not (CheckDigit(TxtSanad.Text)) Then
                TxtSanad.Text = "0"
                TxtSanad.SelectAll()
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Exit Sub
            End If
            TxtSanad.Text = CDbl(TxtSanad.Text)
            dv.RowFilter = "Id=" & TxtSanad.Text.Trim
            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            dv.RowFilter = ""
            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        End Try
        Me.calculate()
    End Sub
    Private Sub SetDgvColumns()
        Try
            DGV.Visible = False
            DGV2.Visible = False
            DGV3.Visible = False
            DGV4.Visible = False
            DGV5.Visible = False
            DGV.Columns.Clear()
            DGV3.Columns.Clear()
            DGV2.DataSource = Nothing
            DGV5.DataSource = Nothing

            TxtDiscount.Visible = False
            TxtCash.Visible = False
            TxtChk.Visible = False
            Txthavleh.Visible = False
            '''''''''''''''''''''''''''''
            TxtMon.Visible = False
            '''''''''''''''''''''''''''''
            TxtDiscountK.Visible = False
            TxtCashK.Visible = False
            TxtChkK.Visible = False
            TxthavlehK.Visible = False
            TxtLend.Visible = False
            '''''''''''''''''''''''''''''
            TxtDiscountH.Visible = False
            TxtCashH.Visible = False
            TxtChkH.Visible = False
            TxthavlehH.Visible = False
            TxtLendH.Visible = False
            '''''''''''''''''''''''''''''
            TxtCashD.Visible = False
            TxtChkD.Visible = False
            TxthavlehD.Visible = False
            TxtLendD.Visible = False
            '''''''''''''''''''''''''''''
            TxtCashA.Visible = False
            TxtChkA.Visible = False
            TxthavlehA.Visible = False
            TxtLendA.Visible = False
            '''''''''''''''''''''''''''''

            If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Sanad", "س.دفتری")
                DGV.Columns("Cln_Sanad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Sanad").Width = 55
                DGV.Columns("Cln_Sanad").ReadOnly = True
                DGV.Columns("Cln_Sanad").DataPropertyName = "Sanad"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_People", "طرف حساب")
                DGV.Columns("Cln_People").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_People").ReadOnly = True
                DGV.Columns("Cln_People").Width = 130
                DGV.Columns("Cln_People").DataPropertyName = "Nam"
                '
                DGV.Columns.Add("Cln_Discount", "تخفیف")
                DGV.Columns("Cln_Discount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Discount").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Discount").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Discount").ReadOnly = True
                DGV.Columns("Cln_Discount").Width = 80
                DGV.Columns("Cln_Discount").DataPropertyName = "Discount"
                '
                DGV.Columns.Add("Cln_Cash", "نقد")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 90
                DGV.Columns("Cln_Cash").DataPropertyName = "Cash"
                '
                DGV.Columns.Add("Cln_Chk", "چک")
                DGV.Columns("Cln_Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Chk").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Chk").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Chk").ReadOnly = True
                DGV.Columns("Cln_Chk").Width = 90
                DGV.Columns("Cln_Chk").DataPropertyName = "Chk"
                '
                DGV.Columns.Add("Cln_Havaleh", "حواله بانکی")
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Havaleh").ReadOnly = True
                DGV.Columns("Cln_Havaleh").Width = 90
                DGV.Columns("Cln_Havaleh").DataPropertyName = "MonHavaleh"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "AllDisc"
                '
                DGV.Columns.Add("Cln_Rate", "ارتباط")
                DGV.Columns("Cln_Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Rate").ReadOnly = True
                DGV.Columns("Cln_Rate").Width = 45
                DGV.Columns("Cln_Rate").Visible = False
                DGV.Columns("Cln_Rate").DataPropertyName = "Rate"

                DGV.Visible = True
                TxtDiscount.Visible = True
                TxtCash.Visible = True
                TxtChk.Visible = True
                Txthavleh.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(2) Then
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Bed", "بدهکار")
                DGV.Columns("Cln_Bed").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Bed").ReadOnly = True
                DGV.Columns("Cln_Bed").Width = 130
                DGV.Columns("Cln_Bed").DataPropertyName = "BedNam"
                '
                DGV.Columns.Add("Cln_Bes", "بستانکار")
                DGV.Columns("Cln_Bes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Bes").ReadOnly = True
                DGV.Columns("Cln_Bes").Width = 130
                DGV.Columns("Cln_Bes").DataPropertyName = "BesNam"
                '
                DGV.Columns.Add("Cln_Cash", "مبلغ انتقال")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 110
                DGV.Columns("Cln_Cash").DataPropertyName = "Mon"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "Disc"

                DGV.Visible = True
                TxtMon.Visible = True

            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Sanad", "س.دفتری")
                DGV.Columns("Cln_Sanad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Sanad").ReadOnly = True
                DGV.Columns("Cln_Sanad").Width = 60
                DGV.Columns("Cln_Sanad").DataPropertyName = "Sanad"
                '
                DGV.Columns.Add("Cln_Idfac", "فاکتور")
                DGV.Columns("Cln_Idfac").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Idfac").ReadOnly = True
                DGV.Columns("Cln_Idfac").Width = 45
                DGV.Columns("Cln_Idfac").DataPropertyName = "IdFactor"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Discount", "تخفیف")
                DGV.Columns("Cln_Discount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Discount").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Discount").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Discount").ReadOnly = True
                DGV.Columns("Cln_Discount").Width = 80
                DGV.Columns("Cln_Discount").DataPropertyName = "Discount"
                '
                DGV.Columns.Add("Cln_Cash", "نقد")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 90
                DGV.Columns("Cln_Cash").DataPropertyName = "Cash"
                '
                DGV.Columns.Add("Cln_Chk", "چک")
                DGV.Columns("Cln_Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Chk").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Chk").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Chk").ReadOnly = True
                DGV.Columns("Cln_Chk").Width = 90
                DGV.Columns("Cln_Chk").DataPropertyName = "Chk"
                '
                DGV.Columns.Add("Cln_Havaleh", "حواله بانکی")
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Havaleh").ReadOnly = True
                DGV.Columns("Cln_Havaleh").Width = 90
                DGV.Columns("Cln_Havaleh").DataPropertyName = "MonHavaleh"
                '
                DGV.Columns.Add("Cln_Lend", "نسیه")
                DGV.Columns("Cln_Lend").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Lend").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Lend").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Lend").ReadOnly = True
                DGV.Columns("Cln_Lend").Width = 90
                DGV.Columns("Cln_Lend").DataPropertyName = "Lend"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "AllDisc"
                DGV.Visible = True

                TxtDiscountK.Visible = True
                TxtCashK.Visible = True
                TxtChkK.Visible = True
                TxthavlehK.Visible = True
                TxtLend.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Sanad", "س.دفتری")
                DGV.Columns("Cln_Sanad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Sanad").ReadOnly = True
                DGV.Columns("Cln_Sanad").Width = 60
                DGV.Columns("Cln_Sanad").DataPropertyName = "Sanad"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Discount", "تخفیف")
                DGV.Columns("Cln_Discount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Discount").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Discount").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Discount").ReadOnly = True
                DGV.Columns("Cln_Discount").Width = 80
                DGV.Columns("Cln_Discount").DataPropertyName = "Discount"
                '
                DGV.Columns.Add("Cln_Cash", "نقد")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 90
                DGV.Columns("Cln_Cash").DataPropertyName = "Cash"
                '
                DGV.Columns.Add("Cln_Chk", "چک")
                DGV.Columns("Cln_Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Chk").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Chk").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Chk").ReadOnly = True
                DGV.Columns("Cln_Chk").Width = 90
                DGV.Columns("Cln_Chk").DataPropertyName = "Chk"
                '
                DGV.Columns.Add("Cln_Havaleh", "حواله بانکی")
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Havaleh").ReadOnly = True
                DGV.Columns("Cln_Havaleh").Width = 90
                DGV.Columns("Cln_Havaleh").DataPropertyName = "MonHavaleh"
                '
                DGV.Columns.Add("Cln_Lend", "نسیه")
                DGV.Columns("Cln_Lend").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Lend").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Lend").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Lend").ReadOnly = True
                DGV.Columns("Cln_Lend").Width = 90
                DGV.Columns("Cln_Lend").DataPropertyName = "Lend"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "AllDisc"
                DGV.Visible = True

                TxtDiscountH.Visible = True
                TxtCashH.Visible = True
                TxtChkH.Visible = True
                TxthavlehH.Visible = True
                TxtLendH.Visible = True

            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Nam", "نام درآمد")
                DGV.Columns("Cln_Nam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Nam").ReadOnly = True
                DGV.Columns("Cln_Nam").Width = 160
                DGV.Columns("Cln_Nam").DataPropertyName = "Nam"
                '
                DGV.Columns.Add("Cln_Cash", "نقد")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 90
                DGV.Columns("Cln_Cash").DataPropertyName = "Cash"
                '
                DGV.Columns.Add("Cln_Chk", "چک")
                DGV.Columns("Cln_Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Chk").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Chk").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Chk").ReadOnly = True
                DGV.Columns("Cln_Chk").Width = 90
                DGV.Columns("Cln_Chk").DataPropertyName = "Chk"
                '
                DGV.Columns.Add("Cln_Havaleh", "حواله بانکی")
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Havaleh").ReadOnly = True
                DGV.Columns("Cln_Havaleh").Width = 90
                DGV.Columns("Cln_Havaleh").DataPropertyName = "MonHavaleh"
                '
                DGV.Columns.Add("Cln_Lend", "نسیه")
                DGV.Columns("Cln_Lend").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Lend").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Lend").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Lend").ReadOnly = True
                DGV.Columns("Cln_Lend").Width = 90
                DGV.Columns("Cln_Lend").DataPropertyName = "Lend"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "AllDisc"
                DGV.Visible = True

                TxtCashD.Visible = True
                TxtChkD.Visible = True
                TxthavlehD.Visible = True
                TxtLendD.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Nam", "نام اموال")
                DGV.Columns("Cln_Nam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Nam").ReadOnly = True
                DGV.Columns("Cln_Nam").Width = 130
                DGV.Columns("Cln_Nam").DataPropertyName = "Nam"
                '
                DGV.Columns.Add("Cln_Cash", "نقد")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 90
                DGV.Columns("Cln_Cash").DataPropertyName = "Cash"
                '
                DGV.Columns.Add("Cln_Chk", "چک")
                DGV.Columns("Cln_Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Chk").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Chk").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Chk").ReadOnly = True
                DGV.Columns("Cln_Chk").Width = 90
                DGV.Columns("Cln_Chk").DataPropertyName = "Chk"
                '
                DGV.Columns.Add("Cln_Havaleh", "حواله بانکی")
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Havaleh").ReadOnly = True
                DGV.Columns("Cln_Havaleh").Width = 90
                DGV.Columns("Cln_Havaleh").DataPropertyName = "MonHavaleh"
                '
                DGV.Columns.Add("Cln_Lend", "نسیه")
                DGV.Columns("Cln_Lend").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Lend").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Lend").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Lend").ReadOnly = True
                DGV.Columns("Cln_Lend").Width = 90
                DGV.Columns("Cln_Lend").DataPropertyName = "Lend"
                '
                DGV.Columns.Add("Cln_Stat", "نوع پرداخت")
                DGV.Columns("Cln_Stat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Stat").ReadOnly = True
                DGV.Columns("Cln_Stat").Width = 90
                DGV.Columns("Cln_Stat").DataPropertyName = "Stat"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "AllDisc"
                DGV.Visible = True

                TxtCashA.Visible = True
                TxtChkA.Visible = True
                TxthavlehA.Visible = True
                TxtLendA.Visible = True

            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Nam", "نام سرمایه")
                DGV.Columns("Cln_Nam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Nam").ReadOnly = True
                DGV.Columns("Cln_Nam").Width = 130
                DGV.Columns("Cln_Nam").DataPropertyName = "Nam"
                '
                DGV.Columns.Add("Cln_Cash", "نقد")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 90
                DGV.Columns("Cln_Cash").DataPropertyName = "Cash"
                '
                DGV.Columns.Add("Cln_Chk", "چک")
                DGV.Columns("Cln_Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Chk").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Chk").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Chk").ReadOnly = True
                DGV.Columns("Cln_Chk").Width = 90
                DGV.Columns("Cln_Chk").DataPropertyName = "Chk"
                '
                DGV.Columns.Add("Cln_Havaleh", "حواله بانکی")
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Havaleh").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Havaleh").ReadOnly = True
                DGV.Columns("Cln_Havaleh").Width = 90
                DGV.Columns("Cln_Havaleh").DataPropertyName = "MonHavaleh"
                '
                DGV.Columns.Add("Cln_Lend", "نسیه")
                DGV.Columns("Cln_Lend").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Lend").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Lend").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Lend").ReadOnly = True
                DGV.Columns("Cln_Lend").Width = 90
                DGV.Columns("Cln_Lend").DataPropertyName = "Lend"
                '
                DGV.Columns.Add("Cln_Stat", "نوع پرداخت")
                DGV.Columns("Cln_Stat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Stat").ReadOnly = True
                DGV.Columns("Cln_Stat").Width = 90
                DGV.Columns("Cln_Stat").DataPropertyName = "Stat"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "AllDisc"
                DGV.Visible = True

                TxtCashA.Visible = True
                TxtChkA.Visible = True
                TxthavlehA.Visible = True
                TxtLendA.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(8) Then
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Nam", "نام صندوق")
                DGV.Columns("Cln_Nam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Nam").ReadOnly = True
                DGV.Columns("Cln_Nam").Width = 130
                DGV.Columns("Cln_Nam").DataPropertyName = "Nam"
                '
                DGV.Columns.Add("Cln_Type", "نوع سند")
                DGV.Columns("Cln_Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Type").ReadOnly = True
                DGV.Columns("Cln_Type").Width = 130
                DGV.Columns("Cln_Type").DataPropertyName = "Typ"
                '
                DGV.Columns.Add("Cln_Cash", "مبلغ")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 110
                DGV.Columns("Cln_Cash").DataPropertyName = "Mon"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "Disc"
                DGV.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(9) Then
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Bed", "صندوق بدهکار")
                DGV.Columns("Cln_Bed").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Bed").ReadOnly = True
                DGV.Columns("Cln_Bed").Width = 130
                DGV.Columns("Cln_Bed").DataPropertyName = "BedNam"
                '
                DGV.Columns.Add("Cln_Bes", "صندوق بستانکار")
                DGV.Columns("Cln_Bes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Bes").ReadOnly = True
                DGV.Columns("Cln_Bes").Width = 130
                DGV.Columns("Cln_Bes").DataPropertyName = "BesNam"
                '
                DGV.Columns.Add("Cln_Cash", "مبلغ انتقال")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 110
                DGV.Columns("Cln_Cash").DataPropertyName = "Mon"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "Disc"
                DGV.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(10) Then
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Nam", "نام بانک")
                DGV.Columns("Cln_Nam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Nam").ReadOnly = True
                DGV.Columns("Cln_Nam").Width = 130
                DGV.Columns("Cln_Nam").DataPropertyName = "Nam"
                '
                DGV.Columns.Add("Cln_Type", "نوع سند")
                DGV.Columns("Cln_Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Type").ReadOnly = True
                DGV.Columns("Cln_Type").Width = 130
                DGV.Columns("Cln_Type").DataPropertyName = "Typ"
                '
                DGV.Columns.Add("Cln_Cash", "مبلغ")
                DGV.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Cash").ReadOnly = True
                DGV.Columns("Cln_Cash").Width = 110
                DGV.Columns("Cln_Cash").DataPropertyName = "Mon"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "Disc"
                DGV.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(11) Then
                DGV3.Columns.Add("Cln_Id", "سند")
                DGV3.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV3.Columns("Cln_Id").ReadOnly = True
                DGV3.Columns("Cln_Id").Width = 45
                DGV3.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV3.Columns.Add("Cln_IdUser", "کاربر")
                DGV3.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV3.Columns("Cln_IdUser").ReadOnly = True
                DGV3.Columns("Cln_IdUser").Width = 45
                DGV3.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV3.Columns.Add("Cln_Date", "تاریخ")
                DGV3.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV3.Columns("Cln_Date").ReadOnly = True
                DGV3.Columns("Cln_Date").Width = 75
                DGV3.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV3.Columns.Add("Cln_Nam", "بانک بستانکار")
                DGV3.Columns("Cln_Nam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV3.Columns("Cln_Nam").ReadOnly = True
                DGV3.Columns("Cln_Nam").Width = 130
                DGV3.Columns("Cln_Nam").DataPropertyName = "Nam"
                '
                DGV3.Columns.Add("Cln_Cash", "مبلغ بستانکاری")
                DGV3.Columns("Cln_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV3.Columns("Cln_Cash").DefaultCellStyle.Format = "N0"
                DGV3.Columns("Cln_Cash").DefaultCellStyle.NullValue = "0"
                DGV3.Columns("Cln_Cash").ReadOnly = True
                DGV3.Columns("Cln_Cash").Width = 110
                DGV3.Columns("Cln_Cash").DataPropertyName = "Mon"
                '
                DGV3.Columns.Add("Cln_Disc", "توضیحات")
                DGV3.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV3.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV3.Columns("Cln_Disc").ReadOnly = True
                DGV3.Columns("Cln_Disc").DataPropertyName = "Disc"
                DGV2.Visible = True
                DGV3.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(12) Then
                '
                DGV.Columns.Add("Cln_Id", "سند")
                DGV.Columns("Cln_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Id").ReadOnly = True
                DGV.Columns("Cln_Id").Width = 45
                DGV.Columns("Cln_Id").DataPropertyName = "Id"
                '
                DGV.Columns.Add("Cln_IdUser", "کاربر")
                DGV.Columns("Cln_IdUser").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_IdUser").ReadOnly = True
                DGV.Columns("Cln_IdUser").Width = 45
                DGV.Columns("Cln_IdUser").DataPropertyName = "IdUser"
                '
                DGV.Columns.Add("Cln_Date", "تاریخ")
                DGV.Columns("Cln_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Date").ReadOnly = True
                DGV.Columns("Cln_Date").Width = 75
                DGV.Columns("Cln_Date").DataPropertyName = "D_Date"
                '
                DGV.Columns.Add("Cln_Box", "صندوق")
                DGV.Columns("Cln_Box").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Box").ReadOnly = True
                DGV.Columns("Cln_Box").Width = 150
                DGV.Columns("Cln_Box").DataPropertyName = "BoxName"
                '
                DGV.Columns.Add("Cln_Bank", "بانک")
                DGV.Columns("Cln_Bank").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Bank").ReadOnly = True
                DGV.Columns("Cln_Bank").Width = 150
                DGV.Columns("Cln_Bank").DataPropertyName = "BankName"
                '
                DGV.Columns.Add("Cln_Mon", "مبلغ")
                DGV.Columns("Cln_Mon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV.Columns("Cln_Mon").DefaultCellStyle.Format = "N0"
                DGV.Columns("Cln_Mon").DefaultCellStyle.NullValue = "0"
                DGV.Columns("Cln_Mon").ReadOnly = True
                DGV.Columns("Cln_Mon").Width = 90
                DGV.Columns("Cln_Mon").DataPropertyName = "Mon"
                '
                DGV.Columns.Add("Cln_Type", "نوع انتقال")
                DGV.Columns("Cln_Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Type").ReadOnly = True
                DGV.Columns("Cln_Bank").Width = 120
                DGV.Columns("Cln_Type").DataPropertyName = "Typ"
                '
                DGV.Columns.Add("Cln_Disc", "توضیحات")
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Columns("Cln_Disc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGV.Columns("Cln_Disc").ReadOnly = True
                DGV.Columns("Cln_Disc").DataPropertyName = "Disc"
                DGV.Visible = True
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                DGV4.Visible = True
                DGV5.Visible = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "SetDgvColumns")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbSanad.KeyDown
        If CmbSanad.DroppedDown = False Then
            CmbSanad.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            cmdadd.Focus()
        End If
    End Sub

    Private Sub CmbSanad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSanad.SelectedIndexChanged
        If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then
            RdoP.Enabled = True
            ToolRate.Visible = True
            ToolListRate.Visible = True
            ToolRateNo.Visible = True
        Else
            If RdoP.Checked = True Then RdoDay.Checked = True
            RdoP.Enabled = False
            ToolRate.Visible = False
            ToolListRate.Visible = False
            ToolRateNo.Visible = False
        End If

        If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Or CmbSanad.Text = CmbSanad.Items(2) Or CmbSanad.Text = CmbSanad.Items(3) Or CmbSanad.Text = CmbSanad.Items(4) Or CmbSanad.Text = CmbSanad.Items(5) Then
            ToolPrint.Visible = True
            cmdprint.Enabled = True
            cmdprint.Visible = True
        Else
            ToolPrint.Visible = False
            cmdprint.Enabled = False
            cmdprint.Visible = False
        End If

        Me.SetDgvColumns()
        Me.RefreshBank()
        Me.SetFilter()
        Try
            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
        End Try

    End Sub

    
    Private Sub PrintGetpay(ByVal Id As Long)
        Try
            PrintSQl = "SELECT Get_Pay_Sanad.[State],Get_Pay_Sanad.Id As IdSanad, D_date,Discount, Cash, MonHavaleh As Havaleh,(MonPayChk+MonSellChk) As Chk, AllDisc As Disc, ISNULL(Define_People.NamFac,'')+ ' ' +   Define_People.Nam As Nam, (ISNULL(Define_People.Tell1,'')+ ISNULL(+'-' +Define_People.Tell2,'')) AS Tell, Define_People.[Address] As Addres ,(Cash+Discount+MonHavaleh+MonPayChk+MonSellChk)As AllMon,(SELECT TOP (1) ISNULL(Max(CompanyName),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyNam,(SELECT TOP (1) ISNULL(Max(Header ),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As HeaderText,(SELECT TOP 1 [Address]+'  '+ TelFax FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyOnfo,(SELECT TOP (1) CompanyImage FROM  Define_Company WHERE IdUser=" & Id_User & ")As ImageFactor FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.IdName = Define_People.ID WHERE Get_Pay_Sanad.Id =" & Id
            Dim Dataret As New DataSetGetPay
            Dataret.Clear()
            Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
                dbDA.Fill(Dataret.DataTable1)
                Application.DoEvents()
            End Using
            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            If Not Dataret.DataTable1.Columns.Contains("TypeSanad") Then Dataret.DataTable1.Columns.Add("TypeSanad", Type.GetType("System.String"))
            If Not Dataret.DataTable1.Columns.Contains("DiscMon") Then Dataret.DataTable1.Columns.Add("DiscMon", Type.GetType("System.String"))
            If Not Dataret.DataTable1.Columns.Contains("OldMoein") Then Dataret.DataTable1.Columns.Add("OldMoein", Type.GetType("System.Double"))
            If Not Dataret.DataTable1.Columns.Contains("NewMoein") Then Dataret.DataTable1.Columns.Add("NewMoein", Type.GetType("System.Double"))
            '''''''''''''''''''''''''''''''''''''
            Dataret.DataTable1.Rows(0).Item("TypeSanad") = If(Dataret.DataTable1.Rows(0).Item("State") = 0, "رسید دریافت از طرف حساب", "رسید پرداخت به طرف حساب")
            Dim s As New NumberToString
            Dataret.DataTable1.Rows(0).Item("DiscMon") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("AllMon"))
            Dataret.DataTable1.Rows(0).Item("Disc") = "توضیحات : " & If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc"))
            '//////////////////////////////////////////
            OldSanad = 0
            CurSanad = 0
            IdKala = 0
            SetMoeinPeopleVaribleGetpay(Id)
            Dataret.DataTable1.Rows(0).Item("OldMoein") = GetMoeinPeople(IdKala, OldSanad)
            Dataret.DataTable1.Rows(0).Item("NewMoein") = GetMoeinPeople(IdKala, CurSanad + 1)

            If Dataret.DataTable1.Rows(0).Item("Chk") <= 0 Then
                Dim ret As New CRP_Resid_Pardakht_TarrafHesab
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Dim i As Integer = GetCountPrint("GETPAY")
                Dim j As Integer = 0
                For j = 1 To i
                    ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                Next
                Application.DoEvents()
            Else
                If Dataret.DataTable1.Rows(0).Item("State") = 0 Then
                    Dim dt As New DataTable
                    If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                    Using cmd As New SqlCommand("SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N As ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.[Number_Type]=" & Dataret.DataTable1.Rows(0).Item("IdSanad") & " AND Chk_Get_Pay.Kind=0", ConectionBank)
                        cmd.CommandTimeout = 0
                        dt.Load(cmd.ExecuteReader)
                    End Using
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Dataret.DataTable1.Rows(0).Item("ChkDate") = dt.Rows(0).Item("ChkDate")
                    Dataret.DataTable1.Rows(0).Item("ChkS") = dt.Rows(0).Item("ChkS")
                    Dataret.DataTable1.Rows(0).Item("ChkMon") = dt.Rows(0).Item("ChkMon")
                    Dataret.DataTable1.Rows(0).Item("ChkBank") = dt.Rows(0).Item("ChkBank")
                    Dataret.DataTable1.Rows(0).Item("ChkNum") = dt.Rows(0).Item("ChkNum")
                    Dataret.DataTable1.Rows(0).Item("shobeh") = dt.Rows(0).Item("shobeh")
                    For m As Integer = 1 To dt.Rows.Count - 1
                        Dataret.DataTable1.AddDataTable1Row(If(Dataret.DataTable1.Rows(0).Item("CompanyOnfo") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyOnfo")), If(Dataret.DataTable1.Rows(0).Item("CompanyNam") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyNam")), If(Dataret.DataTable1.Rows(0).Item("HeaderText") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("HeaderText")), Dataret.DataTable1.Rows(0).Item("D_date"), Dataret.DataTable1.Rows(0).Item("IdSanad"), Dataret.DataTable1.Rows(0).Item("TypeSanad"), Dataret.DataTable1.Rows(0).Item("Nam"), If(Dataret.DataTable1.Rows(0).Item("Tell") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Tell")), If(Dataret.DataTable1.Rows(0).Item("Addres") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Addres")), Dataret.DataTable1.Rows(0).Item("AllMon"), Dataret.DataTable1.Rows(0).Item("DiscMon"), Dataret.DataTable1.Rows(0).Item("Cash"), Dataret.DataTable1.Rows(0).Item("Chk"), Dataret.DataTable1.Rows(0).Item("Havaleh"), Dataret.DataTable1.Rows(0).Item("Discount"), Dataret.DataTable1.Rows(0).Item("OldMoein"), Dataret.DataTable1.Rows(0).Item("NewMoein"), If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc")), Dataret.DataTable1.Rows(0).Item("ImageFactor"), dt.Rows(m).Item("ChkDate"), dt.Rows(m).Item("Chks"), dt.Rows(m).Item("ChkMon"), dt.Rows(m).Item("ChkBank"), dt.Rows(m).Item("ChkNum"), Dataret.DataTable1.Rows(0).Item("State"), dt.Rows(m).Item("shobeh"))
                    Next
                Else
                    Dim dt As New DataTable
                    If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                    Using cmd As New SqlCommand("SELECT DISTINCT * FROM(SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,Define_Bank.N_Bank As ChkBank,Define_Bank.Number_N AS ChkNum,Define_Bank.Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.[Number_Type]=" & Dataret.DataTable1.Rows(0).Item("IdSanad") & " AND Chk_Get_Pay.Kind=1 UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .Idsarmayeh  ELSE (SELECT Idsarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=Number_Type ) END )  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ")) UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .IdAmval ELSE (SELECT IdAmval FROM Get_Pay_Amval WHERE Id=Number_Type) END ) = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION All SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .Idsarmayeh  ELSE (SELECT Idsarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=Number_Type ) END ) = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ")))) As AllChk", ConectionBank)
                        cmd.CommandTimeout = 0
                        dt.Load(cmd.ExecuteReader)
                    End Using
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Dataret.DataTable1.Rows(0).Item("ChkDate") = dt.Rows(0).Item("ChkDate")
                    Dataret.DataTable1.Rows(0).Item("ChkS") = dt.Rows(0).Item("ChkS")
                    Dataret.DataTable1.Rows(0).Item("ChkMon") = dt.Rows(0).Item("ChkMon")
                    Dataret.DataTable1.Rows(0).Item("ChkBank") = dt.Rows(0).Item("ChkBank")
                    Dataret.DataTable1.Rows(0).Item("ChkNum") = dt.Rows(0).Item("ChkNum")
                    Dataret.DataTable1.Rows(0).Item("shobeh") = dt.Rows(0).Item("shobeh")
                    For m As Integer = 1 To dt.Rows.Count - 1
                        Dataret.DataTable1.AddDataTable1Row(If(Dataret.DataTable1.Rows(0).Item("CompanyOnfo") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyOnfo")), If(Dataret.DataTable1.Rows(0).Item("CompanyNam") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyNam")), If(Dataret.DataTable1.Rows(0).Item("HeaderText") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("HeaderText")), Dataret.DataTable1.Rows(0).Item("D_date"), Dataret.DataTable1.Rows(0).Item("IdSanad"), Dataret.DataTable1.Rows(0).Item("TypeSanad"), Dataret.DataTable1.Rows(0).Item("Nam"), If(Dataret.DataTable1.Rows(0).Item("Tell") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Tell")), If(Dataret.DataTable1.Rows(0).Item("Addres") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Addres")), Dataret.DataTable1.Rows(0).Item("AllMon"), Dataret.DataTable1.Rows(0).Item("DiscMon"), Dataret.DataTable1.Rows(0).Item("Cash"), Dataret.DataTable1.Rows(0).Item("Chk"), Dataret.DataTable1.Rows(0).Item("Havaleh"), Dataret.DataTable1.Rows(0).Item("Discount"), Dataret.DataTable1.Rows(0).Item("OldMoein"), Dataret.DataTable1.Rows(0).Item("NewMoein"), If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc")), Dataret.DataTable1.Rows(0).Item("ImageFactor"), dt.Rows(m).Item("ChkDate"), dt.Rows(m).Item("Chks"), dt.Rows(m).Item("ChkMon"), dt.Rows(m).Item("ChkBank"), dt.Rows(m).Item("ChkNum"), Dataret.DataTable1.Rows(0).Item("State"), dt.Rows(m).Item("shobeh"))
                    Next
                End If

                Dim ret As New CRP_Resid_Pardakht_TarrafHesab2
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Dim i As Integer = GetCountPrint("GETPAY")
                Dim j As Integer = 0
                For j = 1 To i
                    ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                Next
                Application.DoEvents()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "PrintGetpay")
        End Try
    End Sub
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Me.Enabled = False
        LimitMojody()
        Try
            If CmbSanad.Text = CmbSanad.Items(0) Then
                Using FGet As New GetMoney
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtDiscountC.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "0"
                    FGet.LLimit.Text = "0"
                    Array.Resize(LimitListArray, 0)
                    FGet.ShowDialog()
                    If FGet.ChkFactor.Checked = True Then PrintGetpay(FGet.LIdFac.Text)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(1) Then
                Using FPay As New PayMoney
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.TxtCash.Text = 0
                    FPay.TxtDiscountC.Text = 0
                    FPay.Txtbank.Text = 0
                    FPay.TxtChk.Text = 0
                    FPay.TxtSellChk.Text = 0
                    FPay.LMandeh.Text = 0
                    FPay.TxtDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.LLimit.Text = "0"
                    Array.Resize(LimitListArray, 0)
                    FPay.ShowDialog()
                    If FPay.ChkFactor.Checked = True Then PrintGetpay(FPay.LIdFac.Text)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(2) Then
                Using FPay As New FrmSanadPTP
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.TxtMon.Text = 0
                    FPay.TxtDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                Using FPay As New Frm_Charge_Factor
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.TxtAllMoney.Text = 0
                    FPay.Ledit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                Using FPay As New Frm_Charge_Other
                    FPay.TxtAllMoney.Text = 0
                    FPay.Ledit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                Using FGet As New GetDaramad
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtLend.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "0"
                    FGet.TxtNamP.Enabled = False
                    FGet.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                Using FGet As New Get_Pay_Amval
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtLend.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.TxtSellChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "0"
                    FGet.Txtname.Enabled = False
                    FGet.TxtCharge.Enabled = False
                    FGet.RdoName.Enabled = False
                    FGet.RdoCharge.Enabled = False
                    FGet.RdoDec.Checked = True
                    FGet.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                Using FGet As New Get_Pay_Sarmayeh
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtLend.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.TxtSellChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "0"
                    FGet.Txtname.Enabled = False
                    FGet.TxtCharge.Enabled = False
                    FGet.RdoName.Enabled = False
                    FGet.RdoCharge.Enabled = False
                    FGet.RdoDec.Checked = True
                    FGet.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(8) Then
                Using FPay As New FrmAddDecBox
                    If LimitDate = True Then FPay.TxtPayDate.Enabled = False
                    FPay.RdoAdd.Checked = True
                    FPay.TxtMonT.Text = 0
                    FPay.TxtPayDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(9) Then
                Using FPay As New FrmSanadBoxTBox
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.TxtMon.Text = 0
                    FPay.TxtDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(10) Then
                Using FPay As New FrmAddDecBank
                    If LimitDate = True Then FPay.TxtPayDate.Enabled = False
                    FPay.RdoAdd.Checked = True
                    FPay.TxtMonT.Text = 0
                    FPay.TxtPayDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(11) Then
                Using FPay As New FrmBankTBank
                    If LimitDate = True Then FPay.TxtPayDate.Enabled = False
                    FPay.TxtAllMoney.Text = 0
                    FPay.Txtchkmon.Text = 0
                    FPay.TxtPayDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(12) Then
                Using FPay As New Frm_Translate_BoxBank
                    If LimitDate = True Then FPay.TxtPayDate.Enabled = False
                    FPay.CmbSanad.Text = FPay.CmbSanad.Items(0)
                    FPay.TxtMonT.Text = 0
                    FPay.TxtPayDate.ThisText = GetDate()
                    FPay.LEdit.Text = "0"
                    FPay.ShowDialog()
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                Using FPay As New FrmEditMoein
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.ShowDialog()
                End Using
            End If
            Me.RefreshBank()
            Me.SetFilter()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "cmdadd_Click")
            Me.Enabled = True
            Me.SetFilter()
        End Try
    End Sub
    Private Sub GetMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Rate=CASE WHEN TRate =0 THEN 0 WHEN (Discount +Cash +MonHavaleh +Chk)=TRate THEN 1 ELSE -1 END,Nam,Id,IdUser,D_date,Discount,Cash,MonHavaleh,Chk,AllDisc,Sanad FROM (SELECT (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdSanad =Get_Pay_Sanad.Id )As TRate,Define_People.Nam,Get_Pay_Sanad.Id,Get_Pay_Sanad.IdUser,Get_Pay_Sanad.D_date,Get_Pay_Sanad.Discount,Get_Pay_Sanad.Cash,Get_Pay_Sanad.MonHavaleh,Get_Pay_Sanad.MonPayChk As Chk,Get_Pay_Sanad.AllDisc,Get_Pay_Sanad.Sanad FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.IdName = Define_People.ID WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 " & If(Kind_User = 0, " AND IdUser=" & Id_User, "") & ") AS ListGetMon", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "GetMoney")
            Me.Close()
        End Try
    End Sub
    Private Sub DaramadMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Get_Daramad.Id,Get_Daramad.IdUser, D_date, Cash, MonHavaleh, MonPayChk AS Chk, Lend, AllDisc,NamOne + '-' + nam As Nam FROM Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id WHERE Active=1" & If(Kind_User = 0, " AND IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "DaramadMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub EditMoeinMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Id, IdUser, D_Date, Mon, Disc,Kind=CASE WHEN IdCharge Is NOT NULL THEN N'هزینه' ELSE N'درآمد' END FROM  ListEditMoein" & If(Kind_User = 0, " WHERE IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV4.DataSource = Nothing
            DGV5.DataSource = Nothing
            DGV4.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV4.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "EditMoeinMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub SarmayehMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Stat=CASE Get_Pay_Sarmayeh.[State] WHEN 0 THEN N'برداشت سرمایه' ELSE N'افزایش سرمایه' END ,Get_Pay_Sarmayeh.Id,Get_Pay_Sarmayeh.IdUser, D_date, Cash, MonHavaleh, (MonPayChk+ MonSellChk) As Chk, AllDisc, Lend, Define_OneSarmayeh.NamOne+'-'+Define_Sarmayeh.nam AS nam FROM  Get_Pay_Sarmayeh INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh.IdSarmayeh = Define_Sarmayeh.ID INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh.IdOne = Define_OneSarmayeh.Id WHERE Get_Pay_Sarmayeh.Active =1" & If(Kind_User = 0, " AND IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "SarmayehMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub AmvalMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Stat=CASE Get_Pay_Amval.[State] WHEN 0 THEN N'افزایش اموال' ELSE N'کاهش اموال' END ,Get_Pay_Amval.Id,Get_Pay_Amval.IdUser, D_date, Cash, MonHavaleh, (MonPayChk+ MonSellChk) As Chk, AllDisc, Lend, Define_OneAmval.NamOne +'-'+ Define_Amval.nam AS nam FROM  Get_Pay_Amval INNER JOIN Define_Amval ON Get_Pay_Amval.IdAmval = Define_Amval.ID INNER JOIN Define_OneAmval ON Define_Amval.IdOne = Define_OneAmval.Id WHERE Get_Pay_Amval.Active =1" & If(Kind_User = 0, " AND IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "AmvalMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub PayMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Rate=CASE WHEN TRate =0 THEN 0 WHEN (Discount +Cash +MonHavaleh +Chk)=TRate THEN 1 ELSE -1 END ,Nam,Id,IdUser,D_date,Discount,Cash,MonHavaleh,Chk,AllDisc,Sanad FROM (SELECT (SELECT ISNULL(SUM(Pay),0) FROM PayLimitKharid WHERE IdSanad =Get_Pay_Sanad.Id )As TRate,Define_People.Nam,Get_Pay_Sanad.Id,Get_Pay_Sanad.IdUser,Get_Pay_Sanad.D_date,Get_Pay_Sanad.Discount,Get_Pay_Sanad.Cash,Get_Pay_Sanad.MonHavaleh,(Get_Pay_Sanad.MonPayChk+Get_Pay_Sanad.MonSellChk) As Chk,Get_Pay_Sanad.AllDisc,Get_Pay_Sanad.Sanad FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.IdName = Define_People.ID WHERE Get_Pay_Sanad.[State] =1 AND Get_Pay_Sanad.Active  =1 " & If(Kind_User = 0, " AND IdUser=" & Id_User, "") & ") AS ListPayMoney", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "PayMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub PTPMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Allsanad.Id,Allsanad.IdUser,Allsanad.D_date ,Allsanad.Disc ,Allsanad.Mon ,Allsanad.BedNam ,nam As BesNam  FROM (SELECT   Sanad_PTP.Id,Sanad_PTP.IdUser,Sanad_PTP.IdNameBes  , Sanad_PTP.Disc, Sanad_PTP.D_date, Sanad_PTP.Mon, Define_People.Nam As BedNam FROM Sanad_PTP INNER JOIN Define_People ON Sanad_PTP.IdNameBed = Define_People.ID " & If(Kind_User = 0, " WHERE IdUser=" & Id_User, "") & ")AS AllSanad INNER JOIN Define_People ON AllSanad .IdNameBes  = Define_People.ID", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "PTPMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub AddDecBoxMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Sanad_AddDecBox.Id,Sanad_AddDecBox.IdUser, Sanad_AddDecBox.Mon, Sanad_AddDecBox.D_Date, Sanad_AddDecBox.Disc, Define_Box.nam, TYP=Case Sanad_AddDecBox.Flag WHEN 0 THEN N'اضافات' ELSE N'کسورات' END FROM  Sanad_AddDecBox INNER JOIN Define_Box ON Sanad_AddDecBox.IdBox = Define_Box.ID" & If(Kind_User = 0, " WHERE IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "AddDecBoxMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub AddDecBankMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Sanad_AddDecBank.Id,Sanad_AddDecBank.IdUser, Sanad_AddDecBank.Mon, Sanad_AddDecBank.D_Date, Sanad_AddDecBank.Disc, Define_Bank.n_bank as Nam, TYP=Case Sanad_AddDecBank.Flag WHEN 0 THEN N'اضافات' ELSE N'کسورات' END FROM  Sanad_AddDecBank INNER JOIN Define_Bank ON Sanad_AddDecBank.IdBank = Define_Bank.ID" & If(Kind_User = 0, " WHERE IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "AddDecBankMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub BankToBankMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Sanad_BankTBank_Bes.Mon, Sanad_BankTBank_Bes.D_date, Sanad_BankTBank_Bes.Disc, Sanad_BankTBank_Bes.Id,Sanad_BankTBank_Bes.IdUser, Define_Bank.n_bank As Nam FROM Sanad_BankTBank_Bes INNER JOIN Define_Bank ON Sanad_BankTBank_Bes.IdBankBes = Define_Bank.ID" & If(Kind_User = 0, " WHERE IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV3.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV3.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            'RowCountbank = dv.Count
            DGV3.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "BankToBankMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub BoxTBoxMoney()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Allsanad.Id,Allsanad.IdUser,Allsanad.D_date ,Allsanad.Disc ,Allsanad.Mon ,Allsanad.BedNam ,nam As BesNam  FROM (SELECT   Sanad_BOXTBOX.Id,Sanad_BOXTBOX.IdUser,Sanad_BOXTBOX.IdNameBes  , Sanad_BOXTBOX.Disc, Sanad_BOXTBOX.D_date, Sanad_BOXTBOX.Mon, Define_Box.Nam As BedNam FROM Sanad_BOXTBOX INNER JOIN Define_Box ON Sanad_BOXTBOX.IdNameBed = Define_Box.ID)AS AllSanad INNER JOIN Define_Box ON AllSanad .IdNameBes  = Define_Box.ID" & If(Kind_User = 0, " WHERE IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "BoxTBoxMoney")
            Me.Close()
        End Try
    End Sub

    Private Sub TranslateBox_bank()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Typ= CASE Stat WHEN 0 THEN N'صندوق به بانک' WHEN 1 THEN N'بانک به صندوق' Else  N'نامشخص' End,Sanad_Translate_BoxBank.Id,Sanad_Translate_BoxBank.IdUser,Sanad_Translate_BoxBank.Id, Sanad_Translate_BoxBank.D_Date, Sanad_Translate_BoxBank.Mon, Sanad_Translate_BoxBank.Disc,Define_Bank.n_bank As BankName, Define_Box.nam As BoxName FROM Sanad_Translate_BoxBank INNER JOIN Define_Bank ON Sanad_Translate_BoxBank.IdBank = Define_Bank.ID INNER JOIN Define_Box ON Sanad_Translate_BoxBank.IdBox = Define_Box.ID" & If(Kind_User = 0, " WHERE IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "TranslateBox_bank")
            Me.Close()
        End Try
    End Sub
    Private Sub OtherCharge()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Id,IdUser, D_date, Disc As AllDisc, Discount, Cash, MonHavaleh, (MonPayChk + MonSellChk) AS Chk, Lend,Sanad FROM  ListOtherCharge WHERE Activ =1" & If(Kind_User = 0, " AND IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "OtherCharge")
            Me.Close()
        End Try
    End Sub
    Private Sub FactorCharge()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Id,IdUser,IdFactor , D_date, Disc As AllDisc, Discount, Cash, MonHavaleh, (MonPayChk + MonSellChk) AS Chk, Lend,Sanad FROM  ListFactorCharge  WHERE Activ =1" & If(Kind_User = 0, " AND IdUser=" & Id_User, ""), ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "FactorCharge")
            Me.Close()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If CmbSanad.Text = CmbSanad.Items(0) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetMoney.htm")
            If CmbSanad.Text = CmbSanad.Items(1) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PayMoney.htm")
            If CmbSanad.Text = CmbSanad.Items(2) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PToP.htm")
            If CmbSanad.Text = CmbSanad.Items(3) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Charge_Buy.htm")
            If CmbSanad.Text = CmbSanad.Items(4) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Charge_Other.htm")
            If CmbSanad.Text = CmbSanad.Items(5) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Daramad.htm")
            If CmbSanad.Text = CmbSanad.Items(6) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Amval.htm")
            If CmbSanad.Text = CmbSanad.Items(7) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Sarmaye.htm")
            If CmbSanad.Text = CmbSanad.Items(8) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AddDecBox.htm")
            If CmbSanad.Text = CmbSanad.Items(9) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BoxToBox.htm")
            If CmbSanad.Text = CmbSanad.Items(10) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AddDecBank.htm")
            If CmbSanad.Text = CmbSanad.Items(11) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BankBeBank.htm")
            If CmbSanad.Text = CmbSanad.Items(12) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BankBox.htm")
            If CmbSanad.Text = CmbSanad.Items(13) Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AslaheTarafHesab.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.Enabled = False
            Me.RefreshBank()
            Me.SetFilter()
            Me.Enabled = True
        ElseIf e.KeyCode = Keys.F6 Then
            If cmdprint.Enabled = True Then cmdprint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then
                If DGV.RowCount > 0 Then
                    If DGV.Item("Cln_Rate", DGV.CurrentRow.Index).Value <> 0 Then
                        Using FrmList As New FrmShowRate
                            FrmList.LSanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                            FrmList.LTable.Text = If(CmbSanad.Text = CmbSanad.Items(0), "PayLimitFrosh", "PayLimitKharid")
                            FrmList.ShowDialog()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Try
            LimitMojody()

            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                If DGV.RowCount <= 0 Then
                    MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "EDIT") = False Then
                    MessageBox.Show(" ویرایش به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    If DGV3.RowCount <= 0 Then
                        MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If LimitWork(DGV3.Item("Cln_Date", DGV3.CurrentRow.Index).Value, "EDIT") = False Then
                        MessageBox.Show(" ویرایش به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If CmbSanad.Text = CmbSanad.Items(13) Then
                    If DGV4.RowCount <= 0 Then
                        MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If


                    If LimitWork(DGV4.Item("Cln_Date", DGV4.CurrentRow.Index).Value, "EDIT") = False Then
                        MessageBox.Show(" ویرایش به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If


            If CmbSanad.Text = CmbSanad.Items(2) Then
                Using FBB As New FrmSanadPTP
                    If LimitDate = True Then FBB.TxtDate.Enabled = False
                    FBB.LEdit.Text = "1"
                    FBB.LIdSanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FBB.ShowDialog()
                End Using
                Application.DoEvents()
                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(8) Then
                Using FBB As New FrmAddDecBox
                    If LimitDate = True Then FBB.TxtPayDate.Enabled = False
                    FBB.LEdit.Text = "1"
                    FBB.LSanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FBB.ShowDialog()
                End Using
                Application.DoEvents()
                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(9) Then
                Using FBB As New FrmSanadBoxTBox
                    If LimitDate = True Then FBB.TxtDate.Enabled = False
                    FBB.LEdit.Text = "1"
                    FBB.LIdSanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FBB.ShowDialog()
                End Using
                Application.DoEvents()
                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(10) Then
                Using FBB As New FrmAddDecBank
                    If LimitDate = True Then FBB.TxtPayDate.Enabled = False
                    FBB.LEdit.Text = "1"
                    FBB.LSanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FBB.ShowDialog()
                End Using
                Application.DoEvents()
                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(11) Then
                Using FBB As New FrmBankTBank
                    If LimitDate = True Then FBB.TxtPayDate.Enabled = False
                    FBB.LEdit.Text = "1"
                    FBB.LSanad.Text = DGV3.Item("Cln_Id", DGV3.CurrentRow.Index).Value
                    FBB.ShowDialog()
                End Using
                Application.DoEvents()
                Me.RefreshBank()
                Me.SetFilter()
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Me.Enabled = True
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(12) Then
                Using FBB As New Frm_Translate_BoxBank
                    If LimitDate = True Then FBB.TxtPayDate.Enabled = False
                    FBB.LEdit.Text = "1"
                    FBB.LSanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FBB.ShowDialog()
                End Using
                Application.DoEvents()
                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True
                Exit Sub
            End If

            Dim state As Long = 0
            If CmbSanad.Text = CmbSanad.Items(0) Then
                state = 0
            ElseIf CmbSanad.Text = CmbSanad.Items(1) Then
                state = 1
            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                state = 3
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                state = 4
            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                state = 5
            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                state = 6
            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                state = 7
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                state = 13
            End If
            '''''''''''''
            If state = 4 Or state = 5 Then
                If AreYouEditMoein(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, state) <> 0 Then
                    MessageBox.Show("سند مورد نظر در بخش اصلاحیه طرف حساب صادر شده است جهت ویرایش به آن قسمت مراجعه کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If Not AreYouEditSanad(If(state = 13, DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value, DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value), state) Then
                MessageBox.Show("سند مورد نظر در حال بروز رسانی می باشد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If state = 4 Or state = 3 Then
                If Not SetEditFlagOtherCharge(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 0, state) Then
                    MessageBox.Show("سند مورد نظر به حالت ویرایش تغییر وضعیت نمی دهد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                If Not SetEditFlagSanad(If(state = 13, DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value, DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value), 0, state) Then
                    MessageBox.Show("سند مورد نظر به حالت ویرایش تغییر وضعیت نمی دهد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Fnew = False
            ''''''''''''''''''''''''''
            Me.Enabled = False
            If CmbSanad.Text = CmbSanad.Items(0) Then
                Using FGet As New GetMoney
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtDiscountC.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "1"
                    FGet.LLimit.Text = "0"
                    FGet.LIdFac.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    Array.Resize(LimitListArray, 0)
                    FGet.ChkFactor.Enabled = False
                    FGet.ShowDialog()
                    SetEditFlagSanad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 0)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(1) Then
                Using FPay As New PayMoney
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.TxtCash.Text = 0
                    FPay.TxtDiscountC.Text = 0
                    FPay.Txtbank.Text = 0
                    FPay.TxtChk.Text = 0
                    FPay.TxtSellChk.Text = 0
                    FPay.LMandeh.Text = 0
                    FPay.TxtDate.ThisText = GetDate()
                    FPay.LEdit.Text = "1"
                    FPay.LLimit.Text = "0"
                    FPay.LIdFac.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    Array.Resize(LimitListArray, 0)
                    FPay.ChkFactor.Enabled = False
                    FPay.ShowDialog()
                    SetEditFlagSanad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 1)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                Using FPay As New Frm_Charge_Factor
                    If LimitDate = True Then FPay.TxtDate.Enabled = False
                    FPay.Ledit.Text = "1"
                    FPay.Lsanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FPay.TxtDisc.Text = DGV.Item("Cln_Disc", DGV.CurrentRow.Index).Value
                    FPay.TxtSanad.Text = If(DGV.Item("Cln_Sanad", DGV.CurrentRow.Index).Value Is DBNull.Value, "", DGV.Item("Cln_Sanad", DGV.CurrentRow.Index).Value)
                    FPay.ShowDialog()
                    SetEditFlagOtherCharge(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 3)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                Using FPay As New Frm_Charge_Other
                    FPay.Ledit.Text = "1"
                    FPay.Lsanad.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FPay.TxtDisc.Text = DGV.Item("Cln_Disc", DGV.CurrentRow.Index).Value
                    FPay.TxtSanad.Text = If(DGV.Item("Cln_Sanad", DGV.CurrentRow.Index).Value Is DBNull.Value, "", DGV.Item("Cln_Sanad", DGV.CurrentRow.Index).Value)
                    FPay.ShowDialog()
                    SetEditFlagOtherCharge(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 4)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                Using FGet As New GetDaramad
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtLend.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "1"
                    FGet.LIdFac.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FGet.ShowDialog()
                    SetEditFlagSanad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 5)
                End Using

            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                Using FGet As New Get_Pay_Amval
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtLend.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "1"
                    FGet.LIdFac.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FGet.ShowDialog()
                    SetEditFlagSanad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 6)
                End Using

            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                Using FGet As New Get_Pay_Sarmayeh
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.TxtCash.Text = 0
                    FGet.TxtLend.Text = 0
                    FGet.Txtbank.Text = 0
                    FGet.TxtChk.Text = 0
                    FGet.LMandeh.Text = 0
                    FGet.TxtDate.ThisText = GetDate()
                    FGet.LEdit.Text = "1"
                    FGet.LIdFac.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                    FGet.ShowDialog()
                    SetEditFlagSanad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 1, 7)
                End Using
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                Using FGet As New FrmEditMoein
                    If LimitDate = True Then FGet.TxtDate.Enabled = False
                    FGet.LEdit.Text = "1"
                    FGet.LSanad.Text = DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value
                    FGet.ShowDialog()
                    SetEditFlagSanad(DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value, 1, 13)
                End Using
            End If
            Application.DoEvents()
            Me.RefreshBank()
            Me.SetFilter()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "cmdedit_Click")
            Me.Enabled = True
            Me.SetFilter()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Try
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                If DGV.RowCount <= 0 Then
                    MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "DEL") = False Then
                    MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    If DGV3.RowCount <= 0 Then
                        MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If LimitWork(DGV3.Item("Cln_Date", DGV3.CurrentRow.Index).Value, "DEL") = False Then
                        MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If CmbSanad.Text = CmbSanad.Items(13) Then
                    If DGV4.RowCount <= 0 Then
                        MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If LimitWork(DGV4.Item("Cln_Date", DGV4.CurrentRow.Index).Value, "DEL") = False Then
                        MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If

            If CmbSanad.Text = CmbSanad.Items(4) Or CmbSanad.Text = CmbSanad.Items(5) Then
                If AreYouEditMoein(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, If(CmbSanad.Text = CmbSanad.Items(4), 4, 5)) <> 0 Then
                    MessageBox.Show("سند مورد نظر در بخش اصلاحیه طرف حساب صادر شده است جهت حذف به آن قسمت مراجعه کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If MessageBox.Show("آیا برای حذف سند مورد نظر مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            ''''''''''''''
            If CmbSanad.Text = CmbSanad.Items(2) Then
                Me.Enabled = False
                If Not Del_PTP(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Enabled = True
                Me.RefreshBank()
                Me.SetFilter()
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(8) Then
                Me.Enabled = False
                If Not Del_AddDecBox(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Enabled = True
                Me.RefreshBank()
                Me.SetFilter()
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(9) Then
                Me.Enabled = False
                If Not Del_BoxTBox(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Enabled = True
                Me.RefreshBank()
                Me.SetFilter()
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(10) Then
                Me.Enabled = False
                If Not Del_AddDecBank(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Enabled = True
                Me.RefreshBank()
                Me.SetFilter()
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(11) Then
                Me.Enabled = False
                If Not Del_BankTBank(DGV3.Item("Cln_Id", DGV3.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Enabled = True
                Me.RefreshBank()
                Me.SetFilter()
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Exit Sub
            End If

            If CmbSanad.Text = CmbSanad.Items(12) Then
                Me.Enabled = False
                If Not Del_TranlateBoxBank(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Enabled = True
                Me.RefreshBank()
                Me.SetFilter()
                Exit Sub
            End If
            ''''''''''''''''''''

            Dim state As Long = 0
            If CmbSanad.Text = CmbSanad.Items(0) Then
                state = 0
            ElseIf CmbSanad.Text = CmbSanad.Items(1) Then
                state = 1
            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                state = 3
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                state = 4
            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                state = 5
            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                state = 6
            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                state = 7
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                state = 13
            End If
            '''''''''''''
            If Not AreYouEditSanad(If(state = 13, DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value, DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value), state) Then
                MessageBox.Show("سند مورد نظر در حال بروز رسانی می باشد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If state = 0 Or state = 1 Then
                If state = 0 Then
                    If Not AreYouDeleteCheckFactor(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 12) Then
                        MessageBox.Show("چکهای مربوط به سند مورد نظر استفاده شده است و سند قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If state = 1 Then
                    If Not AreYouDeleteCheckFactor(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 121) Then
                        MessageBox.Show("چکهای مربوط به سند مورد نظر استفاده شده است و سند قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                Me.Enabled = False

                If Not DelSanad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 12) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), If(state = 0, "دریافت از طرف حساب", "پرداخت به طرف حساب"), "حذف", "حذف سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " طرف حساب:" & DGV.Item("Cln_People", DGV.CurrentRow.Index).Value & " جمع مبلغ:" & FormatNumber(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0) & If(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value > 0, " تخفیف:" & FormatNumber(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value > 0, " نقد:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value > 0, " چک:" & FormatNumber(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value > 0, " حواله:" & FormatNumber(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0), ""), "")

                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True

            ElseIf state = 4 Or state = 3 Then

                If Not AreYouDeleteCharge(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, If(state = 4, 16, 17)) Then
                    MessageBox.Show("چکهای مربوط به سند مورد نظر استفاده شده است و سند قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Me.Enabled = False
                If Not DelSanadCharge(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, If(state = 4, 16, 17)) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                If state = 3 Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "هزینه فاکتور خرید", "حذف", "حذف سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " فاکتور:" & DGV.Item("Cln_IdFac", DGV.CurrentRow.Index).Value & " جمع مبلغ:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value, 0) & If(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value > 0, " تخفیف:" & FormatNumber(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value > 0, " نقد:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value > 0, " چک:" & FormatNumber(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value > 0, " حواله:" & FormatNumber(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value > 0, " نسیه:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value, 0), ""), "")
                ElseIf state = 4 Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "هزینه متفرقه", "حذف", "حذف سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " جمع مبلغ:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value, 0) & If(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value > 0, " تخفیف:" & FormatNumber(DGV.Item("Cln_Discount", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value > 0, " نقد:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value > 0, " چک:" & FormatNumber(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value > 0, " حواله:" & FormatNumber(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value > 0, " نسیه:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value, 0), ""), "")
                End If

                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True

            ElseIf state = 5 Then
                If Not AreYouDeleteCheckFactor(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 15) Then
                    MessageBox.Show("چکهای مربوط به سند مورد نظر استفاده شده است و سند قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Me.Enabled = False
                If Not DelDramad(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, 15) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "درآمد", "حذف", "حذف سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " نام درآمد:" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " جمع مبلغ:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0) & If(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value > 0, " نقد:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value > 0, " چک:" & FormatNumber(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value > 0, " حواله:" & FormatNumber(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value > 0, " نسیه:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value, 0), ""), "")

                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True

            ElseIf state = 6 Then
                If Not AreYouDeleteCheckAmval(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("چکهای مربوط به سند مورد نظر استفاده شده است و سند قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Me.Enabled = False
                If Not DelAmval(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اموال", "حذف", "حذف سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " نام اموال:" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " جمع مبلغ:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0) & If(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value > 0, " نقد:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value > 0, " چک:" & FormatNumber(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value > 0, " حواله:" & FormatNumber(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value > 0, " نسیه:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value, 0), "") & " نوع پرداخت:" & DGV.Item("Cln_Stat", DGV.CurrentRow.Index).Value, "")

                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True

            ElseIf state = 7 Then
                If Not AreYouDeleteCheckSarmayeh(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("چکهای مربوط به سند مورد نظر استفاده شده است و سند قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Me.Enabled = False
                If Not DelSarmayeh(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سرمایه", "حذف", "حذف سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " نام سرمایه:" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " جمع مبلغ:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value + DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0) & If(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value > 0, " نقد:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value > 0, " چک:" & FormatNumber(DGV.Item("Cln_Chk", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value > 0, " حواله:" & FormatNumber(DGV.Item("Cln_Havaleh", DGV.CurrentRow.Index).Value, 0), "") & If(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value > 0, " نسیه:" & FormatNumber(DGV.Item("Cln_Lend", DGV.CurrentRow.Index).Value, 0), "") & " نوع پرداخت:" & DGV.Item("Cln_Stat", DGV.CurrentRow.Index).Value, "")

                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True
            ElseIf state = 13 Then
                Me.Enabled = False
                If Not DelEditMoein(DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value) Then
                    MessageBox.Show("سند مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اصلاحیه طرف حساب", "حذف", "حذف اصلاحیه :" & DGV4.Item("Cln_Id", DGV4.CurrentRow.Index).Value, "")

                Me.RefreshBank()
                Me.SetFilter()
                Me.Enabled = True

            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "cmddel_Click")
            Me.Enabled = True
            Me.SetFilter()
        End Try
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Try
            If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Or CmbSanad.Text = CmbSanad.Items(2) Or CmbSanad.Text = CmbSanad.Items(3) Or CmbSanad.Text = CmbSanad.Items(4) Or CmbSanad.Text = CmbSanad.Items(5) Then
                If DGV.RowCount <= 0 Then
                    MessageBox.Show("سندی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Me.Enabled = False
                If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), If(CmbSanad.Text = CmbSanad.Items(0), "دریافت از طرف حساب", "پرداخت به طرف حساب"), "چاپ رسید", "چاپ سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, "")

                    Using FrmPrint As New FrmPrint
                        FrmPrint.PrintSQl = "SELECT Get_Pay_Sanad.[State],Get_Pay_Sanad.Id As IdSanad, D_date,Discount, Cash, MonHavaleh As Havaleh,(MonPayChk+MonSellChk) As Chk, AllDisc As Disc, ISNULL(Define_People.NamFac,'')+ ' ' +   Define_People.Nam As Nam, (ISNULL(Define_People.Tell1,'')+ ISNULL(+'-' +Define_People.Tell2,'')) AS Tell, Define_People.[Address] As Addres ,(Cash+Discount+MonHavaleh+MonPayChk+MonSellChk)As AllMon,(SELECT TOP (1) ISNULL(Max(CompanyName),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyNam,(SELECT TOP (1) ISNULL(Max(Header ),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As HeaderText,(SELECT TOP 1 ISNULL([Address],'')+'  '+ ISNULL(TelFax,'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyOnfo,(SELECT TOP (1) CompanyImage FROM  Define_Company WHERE IdUser=" & Id_User & ")As ImageFactor FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.IdName = Define_People.ID WHERE Get_Pay_Sanad.Id =" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                        FrmPrint.CHoose = "RESEDGETPAY"
                        FrmPrint.ShowDialog()
                    End Using
                End If
                If CmbSanad.Text = CmbSanad.Items(2) Then

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "طرف حساب به طرف حساب", "چاپ رسید", "چاپ سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, "")

                    Using FrmPrint As New FrmPrint
                        FrmPrint.PrintSQl = "SELECT Allsanad.Id As IdSanad,Allsanad.D_date ,Allsanad.Disc ,Allsanad.Mon AS AllMon,Allsanad.BedNam ,ISNULL(Define_People.NamFac,'')+ ' ' +   Define_People.Nam As BesNam,(SELECT TOP (1) ISNULL(Max(CompanyName),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyNam,(SELECT TOP (1) ISNULL(Max(Header ),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As HeaderText,(SELECT TOP (1) ISNULL([Address],'')+'  '+ ISNULL(TelFax,'')FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyInfo ,(SELECT TOP (1) CompanyImage FROM  Define_Company WHERE IdUser=" & Id_User & ")As ImageFactor FROM (SELECT   Sanad_PTP.Id,Sanad_PTP.IdNameBes  , Sanad_PTP.Disc, Sanad_PTP.D_date, Sanad_PTP.Mon, ISNULL(Define_People.NamFac,'')+ ' ' +   Define_People.Nam As BedNam FROM Sanad_PTP INNER JOIN Define_People ON Sanad_PTP.IdNameBed = Define_People.ID WHERE Sanad_PTP.Id=" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & ")AS AllSanad INNER JOIN Define_People ON AllSanad .IdNameBes  = Define_People.ID"
                        FrmPrint.CHoose = "RESEDPTP"
                        FrmPrint.ShowDialog()
                    End Using
                End If

                If CmbSanad.Text = CmbSanad.Items(3) Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "هزینه فاکتور خرید", "چاپ رسید", "چاپ سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, "")
                    Using FrmPrint As New FrmPrint
                        FrmPrint.PrintSQl = "SELECT  KalaFactorCharge.Mon AS ChkMon,KalaFactorCharge.CDisc AS shobeh,Define_Charge.nam As Addres,Define_OneCharge.NamOne As Tell,ListFactorCharge.Id As IdSanad,IdFactor As Nam,D_date,Disc,Discount,Cash,MonHavaleh As Havaleh,(MonPayChk + MonSellChk) AS Chk,Lend As OldMoein,(Discount +Lend +Cash +MonHavaleh +MonPayChk + MonSellChk) As AllMon,(SELECT TOP (1) ISNULL(Max(CompanyName),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyNam,(SELECT TOP (1) ISNULL(Max(Header ),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As HeaderText,(SELECT TOP 1 ISNULL([Address],'')+'  '+ ISNULL(TelFax,'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyOnfo,(SELECT TOP (1) CompanyImage FROM  Define_Company WHERE IdUser=" & Id_User & ")As ImageFactor FROM  ListFactorCharge,KalaFactorCharge INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_OneCharge.Id =Define_Charge.IdOne WHERE KalaFactorCharge.IdSanad =" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " AND ListFactorCharge.Id=" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                        FrmPrint.CHoose = "RESEDKHARIDCHARGE"
                        FrmPrint.ShowDialog()
                    End Using
                End If

                If CmbSanad.Text = CmbSanad.Items(4) Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "هزینه", "چاپ رسید", "چاپ سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, "")
                    Using FrmPrint As New FrmPrint
                        FrmPrint.PrintSQl = "SELECT  KalaOtherCharge.Mon AS ChkMon,KalaOtherCharge.CDisc AS shobeh,Define_Charge.nam As Addres,Define_OneCharge.NamOne As Tell,ListOtherCharge.Id As IdSanad,D_date,Disc,Discount,Cash,MonHavaleh As Havaleh,(MonPayChk + MonSellChk) AS Chk,Lend As OldMoein,(Discount +Lend +Cash +MonHavaleh +MonPayChk + MonSellChk) As AllMon,(SELECT TOP (1) ISNULL(Max(CompanyName),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyNam,(SELECT TOP (1) ISNULL(Max(Header ),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As HeaderText,(SELECT TOP 1 ISNULL([Address],'')+'  '+ ISNULL(TelFax,'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyOnfo,(SELECT TOP (1) CompanyImage FROM  Define_Company WHERE IdUser=" & Id_User & ")As ImageFactor FROM  ListOtherCharge,KalaOtherCharge INNER JOIN Define_Charge ON KalaOtherCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_OneCharge.Id =Define_Charge.IdOne WHERE KalaOtherCharge.IdSanad =" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " AND ListOtherCharge.Id=" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                        FrmPrint.CHoose = "RESEDOTHERCHARGE"
                        FrmPrint.ShowDialog()
                    End Using
                End If

                If CmbSanad.Text = CmbSanad.Items(5) Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "درآمد", "چاپ رسید", "چاپ سند :" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, "")
                    Using FrmPrint As New FrmPrint
                        FrmPrint.PrintSQl = "SELECT Get_Daramad.Id As IdSanad,D_date,Lend as Discount,Cash,MonHavaleh As Havaleh,(MonPayChk) As Chk,AllDisc As Disc,Define_Daramad .nam As Nam,(Cash+lend+MonHavaleh+MonPayChk)As AllMon,(SELECT TOP (1) ISNULL(Max(CompanyName),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyNam,(SELECT TOP (1) ISNULL(Max(Header ),'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As HeaderText,(SELECT TOP 1 ISNULL([Address],'')+'  '+ ISNULL(TelFax,'') FROM  Define_Company WHERE IdUser=" & Id_User & ")As CompanyOnfo,(SELECT TOP (1) CompanyImage FROM  Define_Company WHERE IdUser=" & Id_User & ")As ImageFactor FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad .ID WHERE Get_Daramad.Id =" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                        FrmPrint.CHoose = "RESEDDARAMAD"
                        FrmPrint.ShowDialog()
                    End Using
                End If

                Me.Enabled = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "cmdprint_Click")
            Me.Enabled = True
        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            If CmbSanad.Text = CmbSanad.Items(0) Then 
                Me.GetMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(1) Then
                Me.PayMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(2) Then
                Me.PTPMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
                Me.FactorCharge()
            ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
                Me.OtherCharge()
            ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
                Me.DaramadMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(6) Then
                Me.AmvalMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(7) Then
                Me.SarmayehMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(8) Then
                Me.AddDecBoxMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(9) Then
                Me.BoxTBoxMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(10) Then
                Me.AddDecBankMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(11) Then
                Me.BankToBankMoney()
            ElseIf CmbSanad.Text = CmbSanad.Items(12) Then
                Me.TranslateBox_bank()
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                EditMoeinMoney()
            End If
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
            SetButton()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RdoDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDay.CheckedChanged
        If RdoDay.Checked = True Then
            ChkTime.Checked = False
            ChkTime.Enabled = False

            Try
                dv.RowFilter = "D_date='" & GetDate() & "'"
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            Catch ex As Exception
                dv.RowFilter = ""
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            End Try

            Me.calculate()
        End If
    End Sub

    Private Sub RdoId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoId.CheckedChanged
        If RdoId.Checked = True Then
            ChkTime.Checked = False
            ChkTime.Enabled = False

            TxtSanad.Enabled = True
            TxtSanad.Focus()
            Try
                dv.RowFilter = "Id=" & TxtSanad.Text.Trim
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            Catch ex As Exception
                dv.RowFilter = ""
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            End Try

            Me.calculate()
        Else
            TxtSanad.Enabled = False
        End If

    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        If ChkAzDate.Checked = False Then Exit Sub

        Try
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If

            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If

            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        End Try
        Me.calculate()
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        If ChkTaDate.Checked = False Then Exit Sub
        Try
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If

            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            If RdoP.Checked = True Then
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If

            If RdoAll.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                Else
                    dv.RowFilter = ""
                End If
            End If

            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        End Try
        Me.calculate()
    End Sub
    Private Sub SetFilter()
        If RdoDay.Checked = True Then
            Try
                dv.RowFilter = "D_date='" & GetDate() & "'"
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            Catch ex As Exception
                dv.RowFilter = ""
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            End Try
        ElseIf RdoAll.Checked = True Then
            Try
                If ChkTime.Checked = False Then
                    dv.RowFilter = ""
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    Else
                        dv.RowFilter = ""
                    End If
                End If

                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            Catch ex As Exception
                If ChkTime.Checked = False Then
                    dv.RowFilter = ""
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    Else
                        dv.RowFilter = ""
                    End If
                End If

                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            End Try
        ElseIf RdoId.Checked = True Then
            TxtSanad.Enabled = True
            Try
                dv.RowFilter = "Id=" & TxtSanad.Text.Trim
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            Catch ex As Exception
                dv.RowFilter = ""
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            End Try
        ElseIf RdoP.Checked = True Then
            TxtName.Enabled = True
            Try
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkTime.Checked = False Then
                        dv.RowFilter = ""
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                Else
                    If ChkTime.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                End If
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            Catch ex As Exception
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkTime.Checked = False Then
                        dv.RowFilter = ""
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                Else
                    If ChkTime.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                End If
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            End Try
        End If
        Me.calculate()
    End Sub

    Public Function Del_TranlateBoxBank(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dta = New SqlDataAdapter("SELECT  IdBankMoein,IdBoxMoein FROM  Sanad_Translate_BoxBank WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)
            Using Cmd As New SqlCommand("DELETE FROM Sanad_Translate_BoxBank WHERE Id=@Id;DELETE FROM Moein_Bank WHERE Id=@IdBank;DELETE FROM Moein_Box WHERE Id=@IdBox", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = If(ds.Rows.Count > 0, ds.Rows(0).Item("IdBankMoein"), DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = If(ds.Rows.Count > 0, ds.Rows(0).Item("IdBoxMoein"), DBNull.Value)
                Cmd.ExecuteNonQuery()
            End Using
            
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات بانک و صندوق", "حذف", "حذف سند :" & IdFac & " نام بانک:" & DGV.Item("Cln_Bank", DGV.CurrentRow.Index).Value & " نام صندوق:" & DGV.Item("Cln_Box", DGV.CurrentRow.Index).Value & " نوع انتقال:" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & " مبلغ:" & FormatNumber(DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value, 0), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "Del_TranlateBoxBank")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function Del_PTP(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dta = New SqlDataAdapter("SELECT  IdSanadBed,IdSanadBes FROM  Sanad_PTP WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)

            Using Cmd As New SqlCommand("DELETE FROM Sanad_PTP WHERE Id=@Id;DELETE FROM Moein_People WHERE Id=@Id1 OR Id=@Id2", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdSanadBed")
                Cmd.Parameters.AddWithValue("@Id2", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdSanadBes")
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "طرف حساب به طرف حساب", "حذف", "حذف سند :" & IdFac & " بدهکار:" & DGV.Item("Cln_Bed", DGV.CurrentRow.Index).Value & " بستانکار:" & DGV.Item("Cln_Bes", DGV.CurrentRow.Index).Value & " مبلغ انتقال:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "Del_PTP")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function Del_BoxTBox(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dta = New SqlDataAdapter("SELECT  IdSanadBed,IdSanadBes FROM  Sanad_BOXTBOX WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)

            Using Cmd As New SqlCommand("DELETE FROM Sanad_BOXTBOX WHERE Id=@Id;DELETE FROM Moein_Box WHERE Id=@Id1 OR Id=@Id2", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdSanadBed")
                Cmd.Parameters.AddWithValue("@Id2", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdSanadBes")
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "صندوق به صندوق", "حذف", "حذف سند :" & IdFac & " بدهکار:" & DGV.Item("Cln_Bed", DGV.CurrentRow.Index).Value & " بستانکار:" & DGV.Item("Cln_Bes", DGV.CurrentRow.Index).Value & " مبلغ انتقال:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "Del_BoxTBox")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function Del_AddDecBox(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dta = New SqlDataAdapter("SELECT  IDsanadBox FROM  Sanad_AddDecBox WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)

            Using Cmd As New SqlCommand("DELETE FROM Sanad_AddDecBox WHERE Id=@Id;DELETE FROM Moein_Box WHERE Id=@Id1", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdSanadBox")
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اضافات و کسورات صندوق", "حذف", "حذف سند :" & IdFac & " نام صندوق:" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " نوع سند:" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & " مبلغ:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "Del_AddDecBox")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function Del_AddDecBank(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dta = New SqlDataAdapter("SELECT  IDsanadBank FROM  Sanad_AddDecBank WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)

            Using Cmd As New SqlCommand("DELETE FROM Sanad_AddDecBank WHERE Id=@Id;DELETE FROM Moein_Bank WHERE Id=@Id1", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdSanadBank")
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اضافات و کسورات بانک", "حذف", "حذف سند :" & IdFac & " نام بانک:" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " نوع سند:" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & " مبلغ:" & FormatNumber(DGV.Item("Cln_Cash", DGV.CurrentRow.Index).Value, 0), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "Del_AddDecBank")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function Del_BankTBank(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dta = New SqlDataAdapter("SELECT IdSanadBes As Ids FROM Sanad_BankTBank_Bes WHERE Id=" & IdFac & " UNION ALL SELECT IdSanadBed As Ids FROM Sanad_BankTBank_Bed WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)

            Using Cmd As New SqlCommand("DELETE FROM Sanad_BankTBank_Bes WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("DELETE FROM Moein_Bank WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To ds.Rows.Count - 1
                    Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = ds.Rows(i).Item("Ids")
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            Dim str As String = ""
            For i As Integer = 0 To DGV2.RowCount - 1
                str &= "  بدهکار :" & DGV2.Item("Cln_BedBank", i).Value & " مبلغ بدهکار: " & FormatNumber(DGV2.Item("Cln_MonBed", i).Value, 0)
            Next

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بانک به بانک", "حذف", "حذف سند :" & IdFac & " بستانکار:" & DGV3.Item("Cln_nam", DGV3.CurrentRow.Index).Value & " مبلغ بستانکار: " & FormatNumber(DGV3.Item("Cln_Cash", DGV3.CurrentRow.Index).Value, 0) & str, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "Del_BankTBank")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function DelEditMoein(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dt As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ds.Clear()
            dt.Clear()

            dta = New SqlDataAdapter("SELECT IdMoein FROM ListEditPMoein WHERE IdLink=" & IdFac, ConectionBank)
            dta.Fill(ds)

            dta = New SqlDataAdapter("SELECT Kind=CASE WHEN IdSCharge IS NOT NULL THEN 'CHARGE' ELSE 'DARAMAD' END,IdS=CASE WHEN IdSCharge IS NOT NULL THEN IdSCharge ELSE IdSDaramad END FROM ListEditMoein WHERE Id =" & IdFac, ConectionBank)
            dta.Fill(dt)

            Using Cmd As New SqlCommand("DELETE FROM ListEditMoein WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To ds.Rows.Count - 1
                    Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = ds.Rows(i).Item("IdMoein")
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            Using Cmd As New SqlCommand("DELETE FROM " & If(dt.Rows(0).Item("Kind") = "CHARGE", "ListOtherCharge", "Get_Daramad") & " WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(0).Item("IdS")
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اصلاحیه طرف حساب", "حذف", "حذف اصلاحیه :" & IdFac, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "DelEditMoein")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV3_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.RowEnter
        Try
            'If RowCountbank = DGV3.RowCount Then
            DGV2.DataSource = Nothing
            If DGV3.RowCount <= 0 Then
                Exit Sub
            End If
            Dim dt_Tmp As New DataTable
            dt_Tmp.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Sanad_BankTBank_Bed.Mon, Define_Bank.n_bank FROM Sanad_BankTBank_Bed INNER JOIN Define_Bank ON Sanad_BankTBank_Bed.IdBankBed = Define_Bank.ID WHERE Sanad_BankTBank_Bed.Id =" & CLng(DGV3.Item("Cln_Id", e.RowIndex).Value), ConectionBank)
                dt_Tmp.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = dt_Tmp
            '  End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "DGV3_RowEnter")
        End Try
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub RdoP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoP.CheckedChanged
        If RdoP.Checked = True Then

            ChkTime.Enabled = True

            TxtName.Enabled = True
            TxtName.Focus()
            Try
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkTime.Checked = False Then
                        dv.RowFilter = ""
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                Else
                    If ChkTime.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                End If

                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            Catch ex As Exception
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    If ChkTime.Checked = False Then
                        dv.RowFilter = ""
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                Else
                    If ChkTime.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                End If

                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            End Try

            Me.calculate()
        Else
            TxtName.Text = ""
            TxtName.Enabled = False
        End If
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
        End If
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        If RdoP.Checked = False Then Exit Sub
        Try

            If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                If ChkTime.Checked = False Then
                    dv.RowFilter = ""
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            Else
                If ChkTime.Checked = False Then
                    dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If


            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        Catch ex As Exception
            If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                If ChkTime.Checked = False Then
                    dv.RowFilter = ""
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            Else
                If ChkTime.Checked = False Then
                    dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
            End If


            If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
            If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If CmbSanad.Text = CmbSanad.Items(11) Then
                    DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                    DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If
        End Try

        Me.calculate()
    End Sub

    Private Sub DGV4_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV4.RowEnter
        Try
            DGV5.DataSource = Nothing
            If DGV4.RowCount <= 0 Then
                DGV5.DataSource = Nothing
                Exit Sub
            End If
            Dim dt_Tmp As New DataTable
            dt_Tmp.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Define_People.Nam, ListEditPMoein.Emon FROM ListEditPMoein INNER JOIN Define_People ON ListEditPMoein.IdP = Define_People.ID WHERE IdLink =" & CLng(DGV4.Item("Cln_Id", e.RowIndex).Value), ConectionBank)
                dt_Tmp.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV5.AutoGenerateColumns = False
            DGV5.DataSource = dt_Tmp
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmGetPay", "DGV4_RowEnter")
        End Try
    End Sub

    Private Sub DGV4_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV4.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV4.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV4.DefaultCellStyle.Font, b, DGV4.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV4.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV4.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV5_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV5.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV5.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV5.DefaultCellStyle.Font, b, DGV5.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV5.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV5.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            Try
                If RdoP.Checked = True Then
                    If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        Else
                            dv.RowFilter = ""
                        End If
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                End If

                If RdoAll.Checked = True Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    Else
                        dv.RowFilter = ""
                    End If
                End If

                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            Catch ex As Exception
                If RdoP.Checked = True Then
                    If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        Else
                            dv.RowFilter = ""
                        End If
                    Else
                        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date>='" & FarsiDate1.ThisText & "')"
                        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                            dv.RowFilter = "Nam='" & TxtName.Text.Trim & "' AND (D_date<='" & FarsiDate2.ThisText & "')"
                        Else
                            dv.RowFilter = ""
                        End If
                    End If
                End If

                If RdoAll.Checked = True Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    Else
                        dv.RowFilter = ""
                    End If
                End If
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
            End Try
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
            If RdoAll.Checked = True Then
                Call RdoAll_CheckedChanged(Nothing, Nothing)
            ElseIf RdoP.Checked = True Then
                Call RdoP_CheckedChanged(Nothing, Nothing)
            End If
            Me.calculate()
        End If
        If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
            DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        Else
            If CmbSanad.Text = CmbSanad.Items(11) Then
                DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If


    End Sub

    Private Sub DGV_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV.RowPrePaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
        If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then
            If DGV.Item("Cln_Rate", e.RowIndex).Value > 0 Then
                DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            ElseIf DGV.Item("Cln_Rate", e.RowIndex).Value < 0 Then
                DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
            End If
        End If
    End Sub
    Private Sub calculate()
        If RdoDay.Checked = False And RdoP.Checked = False And RdoId.Checked = False And RdoAll.Checked = False And ChkTime.Checked = False Then Exit Sub

        Dim discount As Double = 0
        Dim cash As Double = 0
        Dim chk As Double = 0
        Dim havaleh As Double = 0
        Dim lend As Double = 0

        If CmbSanad.Text = CmbSanad.Items(0) Or CmbSanad.Text = CmbSanad.Items(1) Then
            For i As Integer = 0 To DGV.RowCount - 1
                discount += CDbl(DGV.Item("Cln_Discount", i).Value)
                cash += CDbl(DGV.Item("Cln_Cash", i).Value)
                chk += CDbl(DGV.Item("Cln_Chk", i).Value)
                havaleh += CDbl(DGV.Item("Cln_Havaleh", i).Value)
            Next
            TxtDiscount.Text = IIf(discount = 0, 0, FormatNumber(discount, 0))
            TxtCash.Text = IIf(cash = 0, 0, FormatNumber(cash, 0))
            TxtChk.Text = IIf(chk = 0, 0, FormatNumber(chk, 0))
            Txthavleh.Text = IIf(havaleh = 0, 0, FormatNumber(havaleh, 0))
            TxtLend.Text = IIf(lend = 0, 0, FormatNumber(lend, 0))
        ElseIf CmbSanad.Text = CmbSanad.Items(2) Then
            For i As Integer = 0 To DGV.RowCount - 1
                cash += CDbl(DGV.Item("Cln_Cash", i).Value)
            Next
            TxtMon.Text = IIf(cash = 0, 0, FormatNumber(cash, 0))
        ElseIf CmbSanad.Text = CmbSanad.Items(3) Then
            For i As Integer = 0 To DGV.RowCount - 1
                discount += CDbl(DGV.Item("Cln_Discount", i).Value)
                cash += CDbl(DGV.Item("Cln_Cash", i).Value)
                chk += CDbl(DGV.Item("Cln_Chk", i).Value)
                havaleh += CDbl(DGV.Item("Cln_Havaleh", i).Value)
                lend += CDbl(DGV.Item("Cln_lend", i).Value)
            Next
            TxtDiscountK.Text = IIf(discount = 0, 0, FormatNumber(discount, 0))
            TxtCashK.Text = IIf(cash = 0, 0, FormatNumber(cash, 0))
            TxtChkK.Text = IIf(chk = 0, 0, FormatNumber(chk, 0))
            TxthavlehK.Text = IIf(havaleh = 0, 0, FormatNumber(havaleh, 0))
            TxtLend.Text = IIf(lend = 0, 0, FormatNumber(lend, 0))
        ElseIf CmbSanad.Text = CmbSanad.Items(4) Then
            For i As Integer = 0 To DGV.RowCount - 1
                discount += CDbl(DGV.Item("Cln_Discount", i).Value)
                cash += CDbl(DGV.Item("Cln_Cash", i).Value)
                chk += CDbl(DGV.Item("Cln_Chk", i).Value)
                havaleh += CDbl(DGV.Item("Cln_Havaleh", i).Value)
                lend += CDbl(DGV.Item("Cln_lend", i).Value)
            Next
            TxtDiscountH.Text = IIf(discount = 0, 0, FormatNumber(discount, 0))
            TxtCashH.Text = IIf(cash = 0, 0, FormatNumber(cash, 0))
            TxtChkH.Text = IIf(chk = 0, 0, FormatNumber(chk, 0))
            TxthavlehH.Text = IIf(havaleh = 0, 0, FormatNumber(havaleh, 0))
            TxtLendH.Text = IIf(lend = 0, 0, FormatNumber(lend, 0))
        ElseIf CmbSanad.Text = CmbSanad.Items(5) Then
            For i As Integer = 0 To DGV.RowCount - 1
                cash += CDbl(DGV.Item("Cln_Cash", i).Value)
                chk += CDbl(DGV.Item("Cln_Chk", i).Value)
                havaleh += CDbl(DGV.Item("Cln_Havaleh", i).Value)
                lend += CDbl(DGV.Item("Cln_lend", i).Value)
            Next
            TxtCashD.Text = IIf(cash = 0, 0, FormatNumber(cash, 0))
            TxtChkD.Text = IIf(chk = 0, 0, FormatNumber(chk, 0))
            TxthavlehD.Text = IIf(havaleh = 0, 0, FormatNumber(havaleh, 0))
            TxtLendD.Text = IIf(lend = 0, 0, FormatNumber(lend, 0))
        ElseIf CmbSanad.Text = CmbSanad.Items(6) Or CmbSanad.Text = CmbSanad.Items(7) Then
            For i As Integer = 0 To DGV.RowCount - 1
                cash += CDbl(DGV.Item("Cln_Cash", i).Value)
                chk += CDbl(DGV.Item("Cln_Chk", i).Value)
                havaleh += CDbl(DGV.Item("Cln_Havaleh", i).Value)
                lend += CDbl(DGV.Item("Cln_lend", i).Value)
            Next
            TxtCashA.Text = IIf(cash = 0, 0, FormatNumber(cash, 0))
            TxtChkA.Text = IIf(chk = 0, 0, FormatNumber(chk, 0))
            TxthavlehA.Text = IIf(havaleh = 0, 0, FormatNumber(havaleh, 0))
            TxtLendA.Text = IIf(lend = 0, 0, FormatNumber(lend, 0))
        End If
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            ChkTime.Enabled = True

            Try
                If ChkTime.Checked = False Then
                    dv.RowFilter = ""
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    Else
                        dv.RowFilter = ""
                    End If
                End If

                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text = CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    ElseIf CmbSanad.Text = CmbSanad.Items(13) Then
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            Catch ex As Exception
                If ChkTime.Checked = False Then
                    dv.RowFilter = ""
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                        If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                    Else
                        dv.RowFilter = ""
                    End If
                End If
                If DGV3.RowCount <= 0 Then DGV2.DataSource = Nothing
                If DGV4.RowCount <= 0 Then DGV5.DataSource = Nothing
                If CmbSanad.Text <> CmbSanad.Items(11) And CmbSanad.Text <> CmbSanad.Items(13) Then
                    DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    If CmbSanad.Text <> CmbSanad.Items(11) Then
                        DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    Else
                        DGV4.Sort(DGV4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End If
                End If
            End Try

            Me.calculate()
        End If
    End Sub
End Class