Imports System.Data.SqlClient
Public Class DefineGroup
    Dim edt, Id_Country, Id_Ostan, Id_City, id_part As Integer
    Dim str_name, str_fam As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_O As New DataSet
    Dim str_O As String = "select * From Define_OneGroup"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    Dim bs_O As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_C As New DataSet
    Dim str_C As String = "select * From Define_TwoGroup"
    Dim dta_C As New SqlDataAdapter(str_C, DataSource)
    Dim bs_C As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub set_txtbindTwo()
        TxtNamTwo.DataBindings.Add("text", bs_C, ".NamTwo", True, DataSourceUpdateMode.OnValidation)
        TxtIdTwo.DataBindings.Add("text", bs_C, ".IdCodeTwo", True, DataSourceUpdateMode.OnValidation)
        TxtOneId.DataBindings.Add("text", bs_C, ".IdOne", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub set_txtbindOne()
        TxtNamOne.DataBindings.Add("text", bs_O, ".NamOne", True, DataSourceUpdateMode.OnValidation)
        TxtIdOne.DataBindings.Add("text", bs_O, ".IdCodeOne", True, DataSourceUpdateMode.OnValidation)
    End Sub

    Private Sub Fill_OneGroup()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_O = New SqlDataAdapter(str_O, DataSource)
            Dim ocb_o As New SqlCommandBuilder(dta_O)
            dta_O.UpdateCommand = ocb_o.GetUpdateCommand
            dta_O.InsertCommand = ocb_o.GetInsertCommand
            dta_O.DeleteCommand = ocb_o.GetDeleteCommand
            ds_O.EnforceConstraints = False
            dta_O.Fill(ds_O, "Define_OneGroup")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_O.Tables("Define_OneGroup").Columns("Id")
            ds_O.Tables("Define_OneGroup").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV2.AutoGenerateColumns = False
            bs_O.DataSource = ds_O
            bs_O.DataMember = "Define_OneGroup"
            DGV2.DataSource = bs_O
            BN1.BindingSource = bs_O
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "Fill_OneGroup")
            disableOneGroup(True)
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_TwoGroup()
        Try
            ds_C.Clear()
            If Not dta_C Is Nothing Then
                dta_C.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_C = New SqlDataAdapter(str_C, DataSource)
            Dim ocb_c As New SqlCommandBuilder(dta_C)
            dta_C.UpdateCommand = ocb_c.GetUpdateCommand
            dta_C.InsertCommand = ocb_c.GetInsertCommand
            dta_C.DeleteCommand = ocb_c.GetDeleteCommand
            ds_C.EnforceConstraints = False
            dta_C.Fill(ds_C, "Define_TwoGroup")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_C.Tables("Define_TwoGroup").Columns("Id")
            ds_C.Tables("Define_TwoGroup").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV3.AutoGenerateColumns = False
            bs_C.DataSource = ds_C
            bs_C.DataMember = "Define_TwoGroup"
            DGV3.DataSource = bs_C
            BN2.BindingSource = bs_C
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "Fill_TwoGroup")
            disableTwoGroup(True)
            Me.Close()
        End Try
    End Sub

    Private Sub disableOneGroup(ByVal flag As Boolean)
        TxtNamOne.ReadOnly = flag
        TxtIdOne.ReadOnly = flag
        BN1.Enabled = flag
        BtnSaveOstan.Enabled = Not flag
        BtnCanOstan.Enabled = Not flag
        DGV2.Enabled = flag
        BtnAddOstan.Enabled = flag
        If Fnew = False Then
            BtnEditOstan.Enabled = flag
            BtnDelOstan.Enabled = flag
        Else
            BtnEditOstan.Enabled = False
            BtnDelOstan.Enabled = False
        End If
        SetButton()
    End Sub
    Private Sub disableTwoGroup(ByVal flag As Boolean)
        TxtNamTwo.ReadOnly = flag
        TxtIdTwo.ReadOnly = flag
        BN2.Enabled = flag
        BtnSaveCity.Enabled = Not flag
        BtnCanCity.Enabled = Not flag
        DGV3.Enabled = flag
        BtnAddCity.Enabled = flag
        BtnEditCity.Enabled = flag
        CmbOneId.Enabled = Not flag
        If Fnew = False Then
            BtnDelCity.Enabled = flag
            BtnEditCity.Enabled = flag
        Else
            BtnDelCity.Enabled = False
            BtnEditCity.Enabled = False
        End If
        SetButton()
    End Sub
    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Group.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnAddOstan.Enabled = True Then Call BtnAddOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnAddCity.Enabled = True Then Call BtnAddCity_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnEditOstan.Enabled = True Then Call BtnEditOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnEditCity.Enabled = True Then Call BtnEditCity_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnDelOstan.Enabled = True Then Call BtnDelOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnDelCity.Enabled = True Then Call BtnDelCity_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnSaveOstan.Enabled = True Then Call BtnSaveOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnSaveCity.Enabled = True Then Call BtnSaveCity_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnCanOstan.Enabled = True Then Call BtnCanOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnCanCity.Enabled = True Then Call BtnCanCity_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnAddOstan.Enabled = False Then
                bs_O.CancelEdit()
                disableOneGroup(True)
            End If

            If BtnAddCity.Enabled = False Then
                bs_C.CancelEdit()
                disableTwoGroup(True)
            End If
            Me.RefreshBank()
            End If
    End Sub

    Private Sub DefineGroup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RepairGroupKala()
    End Sub

    Private Sub DefineCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub Factory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F15")
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

        Me.Fill_OneGroup()
        Me.Fill_TwoGroup()
        Me.FillOneGroup()
        Me.set_txtbindOne()
        Me.set_txtbindTwo()
        Me.disableOneGroup(True)
        Me.disableTwoGroup(True)
        DGV2.Columns("Cln_NameOstan").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_NamCity").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If DGV2.RowCount > 0 Then
            DGV2.Rows(0).Selected = True
        End If
        If DGV3.RowCount > 0 Then
            DGV3.Rows(0).Selected = True
        End If
        Me.SetButton()
    End Sub

    Private Sub SetButton()
        Try
            '''''''OneGrouup
            Access_Form = Get_Access_Form("F16")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnAddOstan.Enabled = False
                    BtnDelOstan.Enabled = False
                    BtnEditOstan.Enabled = False
                    BtnCanOstan.Enabled = False
                    BtnSaveOstan.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnAddOstan.Enabled = False
                        BtnDelOstan.Enabled = False
                        BtnEditOstan.Enabled = False
                        BtnCanOstan.Enabled = False
                        BtnSaveOstan.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnAddOstan.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnDelOstan.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnEditOstan.Enabled = False
                        End If
                    End If
                End If
            End If

            '''''''TwoGroup
            Access_Form = Get_Access_Form("F17")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnAddCity.Enabled = False
                    BtnDelCity.Enabled = False
                    BtnEditCity.Enabled = False
                    BtnCanCity.Enabled = False
                    BtnSaveCity.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnAddCity.Enabled = False
                        BtnDelCity.Enabled = False
                        BtnEditCity.Enabled = False
                        BtnCanCity.Enabled = False
                        BtnSaveCity.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnAddCity.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnDelCity.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnEditCity.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnAddOstan.Enabled = False
                BtnAddCity.Enabled = False

                BtnEditOstan.Enabled = False
                BtnEditCity.Enabled = False

                BtnDelOstan.Enabled = False
                BtnDelCity.Enabled = False

                BtnSaveOstan.Enabled = False
                BtnSaveCity.Enabled = False

                BtnCanOstan.Enabled = False
                BtnCanCity.Enabled = False

            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNamOne.KeyDown
        If e.KeyCode = Keys.Enter Then TxtIdOne.Focus()
    End Sub

    Private Sub TxtNameOstan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamOne.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameOstan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNamOne.LostFocus
        If BtnAddOstan.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = TxtNamOne.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        TxtNamOne.Text = str
    End Sub

    Private Sub TxtNameOstan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamOne.TextChanged
        TxtNamOne.Text = TxtNamOne.Text.Replace(",", "")
        TxtNamOne.Text = TxtNamOne.Text.Replace(";", "")
        TxtNamOne.Text = TxtNamOne.Text.Replace("'", "")
    End Sub

    Private Sub BtnAddOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOstan.Click
        disableOneGroup(False)
        Try
            Me.RefreshBank()
            bs_O.AddNew()
            edt = 0
            TxtNamOne.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "BtnAddOstan_Click")
            disableOneGroup(True)
        End Try
    End Sub

    Private Sub BtnCanOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCanOstan.Click
        bs_O.CancelEdit()
        disableOneGroup(True)
        Me.RefreshBank()
        BtnAddOstan.Focus()
    End Sub

    Private Sub BtnDelOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelOstan.Click
        If bs_O.Count <= 0 Then
            MessageBox.Show("هيچ گروهی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد گروه جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNamOne.Text
                bs_O.RemoveAt(bs_O.Position)
                dta_O.Update(ds_O, "Define_OneGroup")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه کالا-گروه اصلی", "حذف", "حذف گروه کالا-گروه اصلی :" & nam, "")
                ds_O.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("گروه انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "BtnDelOstan_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditOstan.Click
        If bs_O.Count <= 0 Then
            MessageBox.Show("هيچ گروهی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disableOneGroup(False)
        edt = 1
        str_name = Trim(TxtNamOne.Text)
    End Sub

    Private Sub BtnSaveOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveOstan.Click
        Try

            If Trim(TxtNamOne.Text) = "" Then
                MessageBox.Show("نام گروه را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNamOne.Focus()
                Exit Sub
            End If
            If edt = 0 Then
                If Not Me.AreYouAddOne(TxtNamOne.Text) Then
                    MessageBox.Show("  نام گروه مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditOne(TxtNamOne.Text) Then
                    MessageBox.Show("نام گروه مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = TxtNamOne.Text
            bs_O.EndEdit()
            dta_O.Update(ds_O, "Define_OneGroup")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه کالا-گروه اصلی", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت گروه کالا-گروه اصلی : " & nam, If(str_name = TxtNamOne.Text, "ویرایش گروه کالا-گروه اصلی : " & str_name, "ویرایش گروه کالا-گروه اصلی از : " & str_name & " به " & TxtNamOne.Text.Trim)), "")
            DGV2.Refresh()
            DGV2.RefreshEdit()
            ds_O.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelOstan.Enabled = True
            disableOneGroup(True)
            BtnAddOstan.Focus()
            FillOneGroup()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("گروه انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableOneGroup(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "BtnSaveOstan_Click")
            End If

            RefreshBank()
        End Try
    End Sub
    Private Function AreYouAddOne(ByVal nam As String) As Boolean
        Dim T_str As String = "select NamOne  from Define_OneGroup WHERE NamOne=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_OneGroup")
        If T_ds.Tables("Define_OneGroup").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditOne(ByVal nam As String) As Boolean
        Dim T_str As String = "select NamOne  from Define_OneGroup WHERE NamOne=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_OneGroup")
        If T_ds.Tables("Define_OneGroup").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_OneGroup").Rows(0).Item("NamOne") <> TxtNamOne.Text) Or (T_ds.Tables("Define_OneGroup").Rows(0).Item("NamOne") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub FillOneGroup()
        CmbOneId.Items.Clear()
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbOneId.Items.Add(ds_O.Tables(0).Rows(i).Item("NamOne"))
        Next
    End Sub

    Private Function GetIdOne(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("NamOne ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("Id")
        Else
            Return -1
        End If
    End Function
    Private Function GetIdTwo(ByVal Nam As String, ByVal idO As String) As Long
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("NamTwo ='" & Nam & "' AND IdOne=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("ID")
        Else
            Return -1
        End If
    End Function

    Private Function GetNamOne(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("ID =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamOne")
        Else
            Return ""
        End If
    End Function
    Private Function GetNamTwo(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("ID =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamTwo")
        Else
            Return ""
        End If
    End Function

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            If DGV2.RowCount < 1000 Then
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
            Else
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 50, e.RowBounds.Location.Y)
            End If
        End Using
    End Sub

    Private Sub TxtTellOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdOne.KeyDown
        If e.KeyCode = Keys.Enter Then
            If BtnSaveOstan.Enabled Then
                BtnSaveOstan.Focus()
            Else
                BtnAddOstan.Focus()
            End If
        End If

    End Sub

    Private Sub BtnAddCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCity.Click
        disableTwoGroup(False)
        Try
            Me.RefreshBank()
            bs_C.AddNew()
            edt = 0
            CmbOneId.Focus()
            TxtOneId.Text = GetIdOne(CmbOneId.Text)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "BtnAddCity_Click")
            disableTwoGroup(True)
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnCanCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCanCity.Click
        bs_C.CancelEdit()
        disableTwoGroup(True)
        Me.RefreshBank()
        BtnAddCity.Focus()
    End Sub

    Private Sub BtnDelCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelCity.Click
        If bs_C.Count <= 0 Then
            MessageBox.Show("هيچ گروهی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد گروه جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNamTwo.Text
                bs_C.RemoveAt(bs_C.Position)
                dta_C.Update(ds_C, "Define_TwoGroup")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه کالا-گروه فرعی", "حذف", "حذف گروه کالا-گروه فرعی :" & nam, "")
                ds_C.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("گروه انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "BtnDelCity_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCity.Click
        If bs_C.Count <= 0 Then
            MessageBox.Show("هيچ گروهی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelCity.Enabled = False
            BtnEditCity.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disableTwoGroup(False)
        edt = 1
        str_name = Trim(TxtNamTwo.Text)
        Id_City = Trim(TxtOneId.Text)
    End Sub

    Private Sub BtnSaveCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveCity.Click
        Try

            TxtOneId.Text = GetIdOne(CmbOneId.Text)
            If Trim(TxtNamTwo.Text) = "" Then
                MessageBox.Show("نام گروه را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNamTwo.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtOneId.Text.Trim) Or CmbOneId.Text = "" Or CmbOneId.FindStringExact(CmbOneId.Text) = -1 Then
                MessageBox.Show("هیچ گروه اصلی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOneId.Focus()
                Exit Sub
            End If
            If TxtOneId.Text = "-1" Then
                MessageBox.Show("هیچ گروه اصلی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOneId.Focus()
                Exit Sub
            End If
            If edt = 0 Then
                If Not Me.AreYouAddTwo(TxtNamTwo.Text, CLng(TxtOneId.Text)) Then
                    MessageBox.Show("  نام گروه مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditTwo(TxtNamTwo.Text, CLng(TxtOneId.Text)) Then
                    MessageBox.Show("نام گروه مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not SetGroup(Id_City, CLng(TxtOneId.Text), DGV3.Item("Cln_CodeCity", DGV3.CurrentRow.Index).Value) Then Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = TxtNamTwo.Text
            bs_C.EndEdit()
            dta_C.Update(ds_C, "Define_TwoGroup")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه کالا-گروه فرعی", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت گروه کالا-گروه فرعی : " & nam, If(str_name = TxtNamTwo.Text, "ویرایش گروه کالا-گروه فرعی : " & str_name, "ویرایش گروه کالا-گروه فرعی از : " & str_name & " به " & TxtNamTwo.Text.Trim)), "")
            DGV3.Refresh()
            DGV3.RefreshEdit()
            ds_C.AcceptChanges()
            Me.RefreshBank()

            If Fnew = False Then BtnDelCity.Enabled = True
            disableTwoGroup(True)
            BtnAddCity.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("گروه انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableTwoGroup(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "BtnSaveCity_Click")
            End If

            RefreshBank()
        End Try
    End Sub
    Private Function AreYouAddTwo(ByVal nam As String, ByVal IdOne As Long) As Boolean
        Dim T_str As String = "select NamTwo  from Define_TwoGroup WHERE NamTwo=N'" & nam & "' AND IdOne=" & IdOne
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_TwoGroup")
        If T_ds.Tables("Define_TwoGroup").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function AreYouEditTwo(ByVal nam As String, ByVal idone As Long) As Boolean
        Dim T_str As String = "select NamTwo,IdOne  from Define_TwoGroup WHERE NamTwo=N'" & nam & "' AND IdOne=" & idone
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_TwoGroup")
        If T_ds.Tables("Define_TwoGroup").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_TwoGroup").Rows(0).Item("NamTwo") <> TxtNamTwo.Text) Or (T_ds.Tables("Define_TwoGroup").Rows(0).Item("NamTwo") = str_name) And ((T_ds.Tables("Define_TwoGroup").Rows(0).Item("IdOne") <> TxtOneId.Text) Or (T_ds.Tables("Define_TwoGroup").Rows(0).Item("IdOne") = Id_City)) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub CmbOstanId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOneId.KeyDown
        If CmbOneId.DroppedDown = False Then
            CmbOneId.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtNamTwo.Focus()
        End If
    End Sub

    Private Sub CmbCityId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOneId.SelectedIndexChanged
        TxtOneId.Text = GetIdOne(CmbOneId.Text)
    End Sub

    Private Sub TxtNameCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNamTwo.KeyDown
        If e.KeyCode = Keys.Enter Then TxtIdTwo.Focus()
    End Sub

    Private Sub TxtNameCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamTwo.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameCity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNamTwo.LostFocus
        If BtnAddCity.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = TxtNamTwo.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        TxtNamTwo.Text = str
    End Sub

    Private Sub TxtNameCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamTwo.TextChanged
        TxtNamTwo.Text = TxtNamTwo.Text.Replace(",", "")
        TxtNamTwo.Text = TxtNamTwo.Text.Replace(";", "")
        TxtNamTwo.Text = TxtNamTwo.Text.Replace("'", "")
    End Sub

    Private Sub TxtTellCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdTwo.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSaveCity.Focus()
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
            If DGV3.RowCount < 1000 Then
                e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
            Else
                e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 50, e.RowBounds.Location.Y)
            End If
        End Using
    End Sub

    Private Sub TxtNameP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub RefreshBank()
        Try
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_OneGroup")
            ds_C.Clear()
            dta_C.Fill(ds_C, "Define_TwoGroup")
            FillOneGroup()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "RefreshBank")
            Me.Close()
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.RefreshBank()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.RefreshBank()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Me.RefreshBank()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.RefreshBank()
    End Sub

    Private Sub TxtOstanId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOneId.TextChanged
        Try
            'If BtnAddCity.Enabled = True Then
            CmbOneId.Text = Me.GetNamOne(TxtOneId.Text)
            'End If
        Catch ex As Exception
            'CmbOneId.Text = ""
        End Try
    End Sub
    Private Function SetGroup(ByVal OldGroup As Long, ByVal NewGroup As Long, ByVal IdKala As Long) As Boolean
        Try
            If OldGroup = NewGroup Then Return True
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE  Define_Kala  SET IdCodeOne=" & NewGroup & " WHERE  IdCodeTwo=" & IdKala, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "SetGroup")
            Return False
        End Try
    End Function

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.RefreshBank()
    End Sub

    Private Sub BN1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN1.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub BN2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN2.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub BN3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.getkey(e)
    End Sub

    Private Sub TxtIdOne_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdOne.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtIdTwo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdTwo.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtIdTwo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdTwo.TextChanged
        If TxtIdTwo.Text.Contains("+") Then TxtIdTwo.Text = TxtIdTwo.Text.Replace("+", "")
    End Sub

    Private Sub TxtIdOne_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdOne.TextChanged
        If TxtIdOne.Text.Contains("+") Then TxtIdOne.Text = TxtIdOne.Text.Replace("+", "")
    End Sub
    Private Sub RepairGroupKala()
        Try

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable
            Using cmd As New SqlCommand("SELECT Id,IdCodetwo,IdCode=(SELECT  IdOne FROM  Define_TwoGroup WHERE Id=Define_Kala.IdCodeTwo ) FROM Define_Kala", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using

            For i As Integer = 0 To dt.Rows.Count - 1
                Using cmd As New SqlCommand("UPDATE Define_Kala SET IdCodeOne=" & dt.Rows(i).Item("IdCode") & " WHERE Id=" & dt.Rows(i).Item("Id"), ConectionBank)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "RepairGroupKala")
        End Try
    End Sub

End Class