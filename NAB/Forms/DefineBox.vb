Imports System.Data.SqlClient
Public Class DefineBox
    Dim edt As Integer
    Dim str_name As String
    Dim ds As New DataSet
    Dim str As String = "select * from Define_Box"
    Dim dta As New SqlDataAdapter(Str, DataSource)
    Dim bs As New BindingSource

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txtallmoney.Visible = True Then
                Txtallmoney.Focus()
            Else
                Txtadd.Focus()
            End If
        End If
        Me.GetKey(e)
    End Sub

    Private Sub Txtadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtadd.KeyDown
        If e.KeyCode = Keys.Enter Then cmdsave.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Define_Box_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cmdadd.Focus()
    End Sub

    Private Sub Define_Box_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdsave.Enabled = True Or cmdcan.Enabled = True Then
            bs.CancelEdit()
            disable(True)
        End If
    End Sub

    Private Sub DefineBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Define_Box_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F36")
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
        Me.fill_dgv()
        Me.set_txtbind()
        DGV.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        disable(True)
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F36")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmddel.Enabled = False
                    cmdedit.Enabled = False
                    cmdcan.Enabled = False
                    cmdsave.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmddel.Enabled = False
                        cmdedit.Enabled = False
                        cmdcan.Enabled = False
                        cmdsave.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            cmdadd.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            cmddel.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            cmdedit.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                cmdadd.Enabled = False
                cmdedit.Enabled = False
                cmddel.Enabled = False
                cmdsave.Enabled = False
                cmdcan.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBox", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub set_txtbind()
        Txtname.DataBindings.Add("text", bs, ".nam", True, DataSourceUpdateMode.OnValidation)
        Txtadd.DataBindings.Add("text", bs, ".discription", True, DataSourceUpdateMode.OnValidation)
        Txtallmoney.DataBindings.Add("text", bs, ".AllMoney", True, DataSourceUpdateMode.OnValidation)
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
            ds.EnforceConstraints = False
            dta.Fill(ds, "Define_Box")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds.Tables("Define_Box").Columns("ID")
            ds.Tables("Define_Box").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_Box"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBox", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub disable(ByVal flag As Boolean)
        Txtname.ReadOnly = flag
        Txtadd.ReadOnly = flag
        Txtallmoney.ReadOnly = flag
        BN.Enabled = flag
        cmdsave.Enabled = Not flag
        cmdcan.Enabled = Not flag
        DGV.Enabled = flag
        cmdadd.Enabled = flag
        If Fnew = True Then
            cmdedit.Enabled = False
            cmddel.Enabled = False
        Else
            cmdedit.Enabled = flag
            cmddel.Enabled = flag
        End If
        SetButton()
    End Sub

    Private Sub cmddel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ صندوقی ای براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد صندوق جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = Txtname.Text
                bs.RemoveAt(bs.Position)
                dta.Update(ds, "Define_Box")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف صندوق", "حذف", "حذف صندوق :" & nam, "")
                ds.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("صندوق انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBox", "cmddel_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub cmdcan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        bs.CancelEdit()
        Me.RefreshBank()
        disable(True)
    End Sub

    Private Sub cmdadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        disable(False)
        Try
            Me.RefreshBank()
            bs.AddNew()
            edt = 0
            Txtallmoney.Text = 1
            Txtallmoney.Text = 0
            Txtname.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBox", "cmdadd_Click")
            disable(True)
            Me.RefreshBank()
        End Try

    End Sub
    Private Function AreYouAddBox(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Box WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Box")
        If T_ds.Tables("Define_Box").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditBox(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Box WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Box")
        If T_ds.Tables("Define_Box").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Box").Rows(0).Item("Nam") <> Txtname.Text) Or (T_ds.Tables("Define_Box").Rows(0).Item("Nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            If Trim(Txtname.Text) = "" Then
                MessageBox.Show("نام صندوق را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtname.Focus()
                Exit Sub
            End If
            If Trim(Txtallmoney.Text) = "" Then Txtallmoney.Text = 0
            If CDbl(Txtallmoney.Text < 0) Then
                MessageBox.Show("موجودی منفی قابل قبول نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtallmoney.Text = 0
                Txtallmoney.Focus()
                Exit Sub
            End If

            If edt = 0 Then
                If Not Me.AreYouAddBox(Txtname.Text.Trim) Then
                    MessageBox.Show("  صندوق مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditBox(Txtname.Text.Trim) Then
                    MessageBox.Show("صندوق مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = Txtname.Text
            bs.EndEdit()
            dta.Update(ds, "Define_Box")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف صندوق", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت صندوق : " & nam, If(str_name = Txtname.Text, "ویرایش صندوق : " & str_name, "ویرایش صندوق از : " & str_name & " به " & Txtname.Text.Trim)), "")
            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            Me.RefreshBank()
            cmddel.Enabled = True
            disable(True)
            cmdadd.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("صندوق انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBox", "cmdsave_Click")
            End If
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ صندوقی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disable(False)
        edt = 1
        str_name = Trim(Txtname.Text)
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub Txtadd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtadd.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtallmoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtallmoney.KeyDown
        If e.KeyCode = Keys.Enter Then Txtadd.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Txtallmoney_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtallmoney.KeyPress
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

    Private Sub Txtallmoney_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtallmoney.TextChanged
        If Not (CheckDigit(Format$(Txtallmoney.Text.Replace(",", "")))) Then
            Txtallmoney.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If Txtallmoney.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(Txtallmoney.Text.Replace(",", ""))
            Txtallmoney.Text = Format$(Val(str), "###,###,###")
        Else
            Txtallmoney.Text = CDbl(Txtallmoney.Text)
        End If
    End Sub

    Private Sub Txtname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtname.LostFocus
        If cmdadd.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = Txtname.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        Txtname.Text = str
    End Sub

    Private Sub RefreshBank()
        Try
            ds.Clear()
            dta.Fill(ds, "Define_Box")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBox", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        Me.RefreshBank()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        Me.RefreshBank()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Define_Box.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If cmdsave.Enabled = True Then Call cmdsave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If cmdcan.Enabled = True Then Call cmdcan_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If cmdadd.Enabled = False Then
                bs.CancelEdit()
                disable(True)
            End If
            Me.RefreshBank()
        End If
    End Sub

    Private Sub cmdadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdadd.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmdcan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdcan.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmddel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmddel.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmdedit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdedit.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmdsave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdsave.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN.KeyDown
        Me.GetKey(e)
    End Sub
End Class