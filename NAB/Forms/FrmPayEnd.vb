Imports System.Data.SqlClient
Public Class FrmPayEnd

    Dim edt As Integer
    Dim str_name As String
    Dim ds As New DataTable
    Public Str As String
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource

    Private Sub FrmOneAddTime_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnAdd.Focus()
    End Sub

    Private Sub FrmOneAddTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnSave.Enabled = True Or BtnCan.Enabled = True Then
            bs.CancelEdit()
            disable(True)
        End If
    End Sub

    Private Sub FrmOneAddTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmOneAddTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.fill_dgv()
        Me.set_txtbind()
        DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        disable(True)
    End Sub

    Private Sub set_txtbind()
        TxtIdFactor2.DataBindings.Add("text", bs, ".IdFactor", True, DataSourceUpdateMode.OnValidation)
        TxtMon.DataBindings.Add("Text", bs, ".Pay", True, DataSourceUpdateMode.OnValidation)
        TxtDisc.DataBindings.Add("text", bs, ".Disc", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub fill_dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            Dim ocb As New SqlCommandBuilder(dta)
            dta.UpdateCommand = ocb.GetUpdateCommand
            dta.InsertCommand = ocb.GetInsertCommand
            dta.DeleteCommand = ocb.GetDeleteCommand
            dta.Fill(ds)

            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            '            bs.DataMember = "Define_Box"
            DGV.DataSource = bs
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPayEnd", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub disable(ByVal flag As Boolean)
        TxtMon.ReadOnly = flag
        TxtDisc.ReadOnly = flag
        BtnSave.Enabled = Not flag
        BtnCan.Enabled = Not flag
        DGV.Enabled = flag
        BtnAdd.Enabled = flag
        If Fnew = True Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            BtnEdit.Enabled = flag
            BtnDel.Enabled = flag
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        disable(False)
        Try
            Me.RefreshBank()
            bs.AddNew()
            edt = 0
            TxtMon.Text = IIf(String.IsNullOrEmpty(TxtBedfactor.Text), 0, IIf(CDbl(TxtBedfactor.Text) > 0, TxtBedfactor.Text, 0))
            TxtMon.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPayEnd", "cmdadd_Click")
            disable(True)
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ مبلغی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDel.Enabled = False
            BtnEdit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disable(False)
        edt = 1
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ مبلغی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDel.Enabled = False
            BtnEdit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد مبلغ جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim dat As String = FormatNumber(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, 0)

                bs.RemoveAt(bs.Position)
                dta.Update(ds)

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "تسویه دستی", "حذف تسویه فاکتور:" & TxtIdFactor.Text & " با مبلغ:" & dat, "")

                ds.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("مبلغ انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPayEnd", "cmddel_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCan.Click
        bs.CancelEdit()
        Me.RefreshBank()
        disable(True)
    End Sub
    Private Sub RefreshBank()
        Try
            ds.Clear()
            dta.Fill(ds)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPayEnd", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtMon.Text) Then
                MessageBox.Show("مبلغ پرداختی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMon.Focus()
                Exit Sub
            End If

            If CDbl(TxtMon.Text) <= 0 Then
                MessageBox.Show("مبلغ پرداختی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMon.Focus()
                Exit Sub
            End If

            If CDbl(TxtMon.Text) > CDbl(TxtBedfactor.Text) Then
                If MessageBox.Show("مبلغ پرداختی بیشتر از بدهی فاکتور است آیا برای ادامه عملیات مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            TxtIdFactor2.Text = TxtIdFactor.Text
            bs.EndEdit()
            dta.Update(ds)

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "تسویه دستی", If(edt = 0, "ثبت تسویه فاکتور:" & TxtIdFactor.Text & " با مبلغ:" & TxtMon.Text, "ویرایش تسویه فاکتور:" & TxtIdFactor.Text & " با مبلغ:" & TxtMon.Text), "")

            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            disable(True)
            Me.RefreshBank()
            BtnDel.Enabled = True
            BtnAdd.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("مبلغ انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPayEnd", "cmdsave_Click")
            End If
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Bed.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnAdd.Enabled = True Then Call BtnAdd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnCan.Enabled = True Then Call BtnCan_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnAdd.Enabled = False Then
                bs.CancelEdit()
                disable(True)
            End If
            Me.RefreshBank()
        End If
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
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

    Private Sub TxtBedfactor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBedfactor.TextChanged
        If Not (CheckDigit(Format$(TxtBedfactor.Text.Replace(",", "")))) Then
            TxtBedfactor.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtBedfactor.Text.Length > 3 Then
            str = Format$(TxtBedfactor.Text.Replace(",", ""))
            TxtBedfactor.Text = Format$(Val(str), "###,###,###")
        Else
            TxtBedfactor.Text = CDbl(TxtBedfactor.Text)
        End If
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

End Class