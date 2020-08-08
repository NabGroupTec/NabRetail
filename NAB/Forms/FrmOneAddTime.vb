Imports System.Data.SqlClient
Public Class FrmOneAddTime

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
        FarsiDate1.DataBindings.Add("ThisText", bs, ".NewDate", True, DataSourceUpdateMode.OnValidation)
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmOneAddTime", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub disable(ByVal flag As Boolean)
        FarsiDate1.Enabled = Not flag
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
            FarsiDate1.ThisText = TxtEndDate.Text
            FarsiDate1.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmOneAddTime", "cmdadd_Click")
            disable(True)
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ وعده ایی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("هيچ وعده ایی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDel.Enabled = False
            BtnEdit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد وعده جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim dat As String = DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value
                bs.RemoveAt(bs.Position)
                dta.Update(ds)
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "تمدید وعده", "حذف وعده فاکتور:" & TxtIdFactor.Text & " با تاریخ:" & dat, "")

                ds.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("وعده انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmOneAddTime", "cmddel_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmOneAddTime", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(FarsiDate1.ThisText) Then
                MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FarsiDate1.Focus()
                Exit Sub
            End If

            If FarsiDate1.ThisText < TxtEndDate.Text Then
                If MessageBox.Show("تاریخ تمدید وعده قدیمی تر از تاریخ تسویه است آیا برای ادامه عملیات مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            TxtIdFactor2.Text = TxtIdFactor.Text
            bs.EndEdit()
            dta.Update(ds)

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "تمدید وعده", If(edt = 0, "ثبت وعده جدید فاکتور:" & TxtIdFactor.Text & " تا تاریخ:" & FarsiDate1.ThisText, "ویرایش وعده فاکتور:" & TxtIdFactor.Text & " تا تاریخ:" & FarsiDate1.ThisText), "")

            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            disable(True)
            Me.RefreshBank()
            BtnDel.Enabled = True
            BtnAdd.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("وعده انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmOneAddTime", "cmdsave_Click")
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

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
End Class