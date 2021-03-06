Imports System.Data.SqlClient
Public Class DefineCity
    Dim edt, Id_Country, Id_Ostan, Id_City, id_part As Integer
    Dim str_name, str_fam As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_O As New DataSet
    Dim str_O As String = "select * From Define_Ostan"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    Dim bs_O As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_C As New DataSet
    Dim str_C As String = "select * From Define_City"
    Dim dta_C As New SqlDataAdapter(str_C, DataSource)
    Dim bs_C As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_P As New DataSet
    Dim str_P As String = "select * From Define_Part"
    Dim dta_P As New SqlDataAdapter(str_P, DataSource)
    Dim bs_P As New BindingSource

    Private Sub set_txtbindCity()
        TxtNameCity.DataBindings.Add("text", bs_C, ".NamCi", True, DataSourceUpdateMode.OnValidation)
        TxtTellCity.DataBindings.Add("text", bs_C, ".TellCi", True, DataSourceUpdateMode.OnValidation)
        TxtOstanId.DataBindings.Add("text", bs_C, ".IdOstan", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub set_txtbindPart()
        TxtNameP.DataBindings.Add("text", bs_P, ".NamP", True, DataSourceUpdateMode.OnValidation)
        TxtAddP.DataBindings.Add("text", bs_P, ".AddP", True, DataSourceUpdateMode.OnValidation)
        TxtOstanP.DataBindings.Add("text", bs_P, ".IdOstan", True, DataSourceUpdateMode.OnValidation)
        TxtCityP.DataBindings.Add("text", bs_P, ".IdCity", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub set_txtbindOstan()
        TxtNameOstan.DataBindings.Add("text", bs_O, ".NamO", True, DataSourceUpdateMode.OnValidation)
        TxtTellOstan.DataBindings.Add("text", bs_O, ".TellO", True, DataSourceUpdateMode.OnValidation)
    End Sub

    Private Sub Fill_Ostan()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            dta_O = New SqlDataAdapter(str_O, DataSource)
            Dim ocb_o As New SqlCommandBuilder(dta_O)
            dta_O.UpdateCommand = ocb_o.GetUpdateCommand
            dta_O.InsertCommand = ocb_o.GetInsertCommand
            dta_O.DeleteCommand = ocb_o.GetDeleteCommand
            ds_O.EnforceConstraints = False
            dta_O.Fill(ds_O, "Define_Ostan")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_O.Tables("Define_Ostan").Columns("Code")
            ds_O.Tables("Define_Ostan").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV2.AutoGenerateColumns = False
            bs_O.DataSource = ds_O
            bs_O.DataMember = "Define_Ostan"
            DGV2.DataSource = bs_O
            BN1.BindingSource = bs_O
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "Fill_Ostan")
            disableOstan(True)
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_City()
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
            dta_C.Fill(ds_C, "Define_City")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_C.Tables("Define_City").Columns("Code")
            ds_C.Tables("Define_City").PrimaryKey = prvkey
            ''''''''''''''''''''''''''''
            ds_C.Tables("Define_City").Columns.Add("OstanName", System.Type.GetType("System.String"))
            Me.Set_Tmp_Ostan()
            ''''''''''''''''''''''''''''
            DGV3.AutoGenerateColumns = False
            bs_C.DataSource = ds_C
            bs_C.DataMember = "Define_City"
            DGV3.DataSource = bs_C
            BN2.BindingSource = bs_C
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "Fill_City")
            disableCity(True)
            Me.Close()
        End Try
    End Sub
    Private Sub Set_Tmp_Ostan()
        Dim T_str As String = "SELECT Define_City.Code, Define_Ostan.NamO FROM Define_City INNER JOIN Define_Ostan ON Define_City.IdOstan = Define_Ostan.Code"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_City")
        If T_ds.Tables("Define_City").Rows.Count <= 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To ds_C.Tables("Define_City").Rows.Count - 1
            Dim dr() As DataRow = T_ds.Tables(0).Select("Code=" & ds_C.Tables("Define_City").Rows(i).Item("Code"))
            If dr.Length > 0 Then
                ds_C.Tables("Define_City").Rows(i).Item("OstanName") = dr(0).Item("NamO")
            End If
        Next
    End Sub
    Private Sub Set_Tmp_Ostan_City()
        Dim T_str As String = "SELECT Define_Part.Code, Define_Ostan.NamO, Define_City.NamCI FROM Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Part")
        If T_ds.Tables("Define_Part").Rows.Count <= 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To ds_P.Tables("Define_Part").Rows.Count - 1
            Dim dr() As DataRow = T_ds.Tables(0).Select("Code=" & ds_P.Tables("Define_Part").Rows(i).Item("Code"))
            If dr.Length > 0 Then
                ds_P.Tables("Define_Part").Rows(i).Item("OstanName") = dr(0).Item("NamO")
                ds_P.Tables("Define_Part").Rows(i).Item("CityName") = dr(0).Item("NamCI")
            End If
        Next
    End Sub
    Private Sub Fill_Part()
        Try
            ds_P.Clear()
            If Not dta_P Is Nothing Then
                dta_P.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_P = New SqlDataAdapter(str_P, DataSource)
            Dim ocb_p As New SqlCommandBuilder(dta_P)
            dta_P.UpdateCommand = ocb_p.GetUpdateCommand
            dta_P.InsertCommand = ocb_p.GetInsertCommand
            dta_P.DeleteCommand = ocb_p.GetDeleteCommand
            ds_P.EnforceConstraints = False
            dta_P.Fill(ds_P, "Define_Part")
            '''''''''''''''''''''''''''
            ds_P.Tables("Define_Part").Columns.Add("OstanName", System.Type.GetType("System.String"))
            ds_P.Tables("Define_Part").Columns.Add("CityName", System.Type.GetType("System.String"))
            Me.Set_Tmp_Ostan_City()
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_P.Tables("Define_Part").Columns("Code")
            ds_P.Tables("Define_Part").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV4.AutoGenerateColumns = False
            bs_P.DataSource = ds_P
            bs_P.DataMember = "Define_Part"
            DGV4.DataSource = bs_P
            BN3.BindingSource = bs_P
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "Fill_Part")
            disablePart(True)
            Me.Close()
        End Try
    End Sub

    Private Sub disableOstan(ByVal flag As Boolean)
        TxtNameOstan.ReadOnly = flag
        TxtTellOstan.ReadOnly = flag
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
    Private Sub disableCity(ByVal flag As Boolean)
        TxtNameCity.ReadOnly = flag
        TxtTellCity.ReadOnly = flag
        BN2.Enabled = flag
        BtnSaveCity.Enabled = Not flag
        BtnCanCity.Enabled = Not flag
        DGV3.Enabled = flag
        BtnAddCity.Enabled = flag
        CmbOstanId.Enabled = Not flag
        If Fnew = False Then
            BtnEditCity.Enabled = flag
            BtnDelCity.Enabled = flag
        Else
            BtnEditCity.Enabled = False
            BtnDelCity.Enabled = False
        End If
        SetButton()
    End Sub
    Private Sub disablePart(ByVal flag As Boolean)
        TxtNameP.ReadOnly = flag
        TxtAddP.ReadOnly = flag
        BN3.Enabled = flag
        BtnSaveP.Enabled = Not flag
        BtnCanP.Enabled = Not flag
        DGV4.Enabled = flag
        BtnAddP.Enabled = flag
        CmbOstanP.Enabled = Not flag
        CmbCityP.Enabled = Not flag
        If Fnew = False Then
            BtnDelP.Enabled = flag
            BtnEditP.Enabled = flag
        Else
            BtnDelP.Enabled = False
            BtnEditP.Enabled = False
        End If
        SetButton()
    End Sub
    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "City.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnAddOstan.Enabled = True Then Call BtnAddOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnAddCity.Enabled = True Then Call BtnAddCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnAddP.Enabled = True Then Call BtnAddP_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnEditOstan.Enabled = True Then Call BtnEditOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnEditCity.Enabled = True Then Call BtnEditCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnEditP.Enabled = True Then Call BtnEditP_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnDelOstan.Enabled = True Then Call BtnDelOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnDelCity.Enabled = True Then Call BtnDelCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnDelP.Enabled = True Then Call BtnDelP_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnSaveOstan.Enabled = True Then Call BtnSaveOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnSaveCity.Enabled = True Then Call BtnSaveCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnSaveP.Enabled = True Then Call BtnSaveP_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnCanOstan.Enabled = True Then Call BtnCanOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnCanCity.Enabled = True Then Call BtnCanCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnCanP.Enabled = True Then Call BtnCanP_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnAddOstan.Enabled = False Then
                bs_O.CancelEdit()
                disableOstan(True)
            End If

            If BtnAddCity.Enabled = False Then
                bs_C.CancelEdit()
                disableCity(True)
            End If

            If BtnAddP.Enabled = False Then
                bs_P.CancelEdit()
                disablePart(True)
            End If

            Me.RefreshBank()
        End If
    End Sub

    Private Sub DefineCity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.RepairCity()
    End Sub

    Private Sub DefineCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub Factory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F3")
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
        Me.Fill_Ostan()
        Me.Fill_City()
        Me.Fill_Part()
        Me.FillOstan()
        Me.set_txtbindOstan()
        Me.set_txtbindCity()
        Me.set_txtbindPart()
        Me.disableOstan(True)
        Me.disableCity(True)
        Me.disablePart(True)
        DGV2.Columns("Cln_NameOstan").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_NamCity").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV4.Columns("Cln_AddressP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If DGV2.RowCount > 0 Then
            DGV2.Rows(0).Selected = True
        End If
        If DGV3.RowCount > 0 Then
            DGV3.Rows(0).Selected = True
        End If
        If DGV4.RowCount > 0 Then
            DGV4.Rows(0).Selected = True
        End If
        SetButton()
    End Sub
    Private Sub SetButton()
        Try
            '''''''Ostan
            Access_Form = Get_Access_Form("F4")
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

            '''''''City
            Access_Form = Get_Access_Form("F5")
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
            '''''''Part
            Access_Form = Get_Access_Form("F6")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnAddP.Enabled = False
                    BtnDelP.Enabled = False
                    BtnEditP.Enabled = False
                    BtnCanP.Enabled = False
                    BtnSaveP.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnAddP.Enabled = False
                        BtnDelP.Enabled = False
                        BtnEditP.Enabled = False
                        BtnCanP.Enabled = False
                        BtnSaveP.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnAddP.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnDelP.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnEditP.Enabled = False
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
                BtnAddP.Enabled = False

                BtnEditOstan.Enabled = False
                BtnEditCity.Enabled = False
                BtnEditP.Enabled = False

                BtnDelOstan.Enabled = False
                BtnDelCity.Enabled = False
                BtnDelP.Enabled = False

                BtnSaveOstan.Enabled = False
                BtnSaveCity.Enabled = False
                BtnSaveP.Enabled = False

                BtnCanOstan.Enabled = False
                BtnCanCity.Enabled = False
                BtnCanP.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "SetButton")
            Me.Close()
        End Try
    End Sub
    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameOstan.KeyDown
        If e.KeyCode = Keys.Enter Then TxtTellOstan.Focus()
    End Sub

    Private Sub TxtNameOstan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameOstan.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameOstan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNameOstan.LostFocus
        If BtnAddOstan.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = TxtNameOstan.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        TxtNameOstan.Text = str
    End Sub

    Private Sub TxtNameOstan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNameOstan.TextChanged
        TxtNameOstan.Text = TxtNameOstan.Text.Replace(",", "")
        TxtNameOstan.Text = TxtNameOstan.Text.Replace(";", "")
        TxtNameOstan.Text = TxtNameOstan.Text.Replace("'", "")
    End Sub

    Private Sub BtnAddOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOstan.Click
        disableOstan(False)
        Try
            Me.RefreshBank()
            bs_O.AddNew()
            edt = 0
            TxtNameOstan.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnAddOstan_Click")
            disableOstan(True)
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_Ostan")
        End Try
    End Sub

    Private Sub BtnCanOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCanOstan.Click
        bs_O.CancelEdit()
        disableOstan(True)
        Me.RefreshBank()
        BtnAddOstan.Focus()
    End Sub

    Private Sub BtnDelOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelOstan.Click
        If bs_O.Count <= 0 Then
            MessageBox.Show("هيچ استانی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد استان جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNameOstan.Text
                bs_O.RemoveAt(bs_O.Position)
                dta_O.Update(ds_O, "Define_Ostan")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف استان", "حذف", "حذف استان :" & nam, "")
                ds_O.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("استان انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnDelOstan_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditOstan.Click
        If bs_O.Count <= 0 Then
            MessageBox.Show("هيچ استانی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disableOstan(False)
        edt = 1
        str_name = Trim(TxtNameOstan.Text)
    End Sub

    Private Sub BtnSaveOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveOstan.Click
        Try

            If Trim(TxtNameOstan.Text) = "" Then
                MessageBox.Show("نام استان را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNameOstan.Focus()
                Exit Sub
            End If
            If edt = 0 Then
                If Not Me.AreYouAddOstan(TxtNameOstan.Text) Then
                    MessageBox.Show("  نام استان مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditOstan(TxtNameOstan.Text) Then
                    MessageBox.Show("نام استان مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            bs_O.EndEdit()
            dta_O.Update(ds_O, "Define_Ostan")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف استان", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت استان : " & TxtNameOstan.Text.Trim, "ویرایش استان از : " & str_name & " به " & TxtNameOstan.Text.Trim), "")
            DGV2.Refresh()
            DGV2.RefreshEdit()
            ds_O.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelOstan.Enabled = True
            disableOstan(True)
            BtnAddOstan.Focus()
            FillOstan()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("استان انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableOstan(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnSaveOstan_Click")
            End If

            RefreshBank()
        End Try
    End Sub
    Private Function AreYouAddOstan(ByVal nam As String) As Boolean
        Dim T_str As String = "select NamO  from Define_Ostan WHERE NamO=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Ostan")
        If T_ds.Tables("Define_Ostan").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditOstan(ByVal nam As String) As Boolean
        Dim T_str As String = "select NamO  from Define_Ostan WHERE NamO=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Ostan")
        If T_ds.Tables("Define_Ostan").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Ostan").Rows(0).Item("NamO") <> TxtNameOstan.Text) Or (T_ds.Tables("Define_Ostan").Rows(0).Item("NamO") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub FillOstan()
        CmbOstanId.Items.Clear()
        CmbOstanP.Items.Clear()
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbOstanId.Items.Add(ds_O.Tables(0).Rows(i).Item("NamO"))
            CmbOstanP.Items.Add(ds_O.Tables(0).Rows(i).Item("NamO"))
        Next
    End Sub
    Private Sub FillCity(ByVal idO As Long)
        CmbCityP.Items.Clear()
        CmbCityP.Text = ""
        For i As Integer = 0 To ds_C.Tables(0).Rows.Count - 1
            If ds_C.Tables(0).Rows(i).Item("IdOstan") = idO Then
                CmbCityP.Items.Add(ds_C.Tables(0).Rows(i).Item("NamCi"))
            End If
        Next
    End Sub
    Private Function GetIdOstan(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("NamO ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function
    Private Function GetIdCity(ByVal Nam As String, ByVal idO As String) As Long
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("NamCi ='" & Nam & "' AND IdOstan=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function

    Private Function GetNamOstan(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamO")
        Else
            Return ""
        End If
    End Function
    Private Function GetNamCity(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamCi")
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

    Private Sub TxtTellOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTellOstan.KeyDown
        If e.KeyCode = Keys.Enter Then
            If BtnSaveOstan.Enabled Then
                BtnSaveOstan.Focus()
            Else
                BtnAddOstan.Focus()
            End If
        End If

    End Sub

    Private Sub BtnAddCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCity.Click
        disableCity(False)
        Try
            Me.RefreshBank()
            bs_C.AddNew()
            edt = 0
            CmbOstanId.Focus()
            CmbOstanId.Text = ""
            TxtOstanId.Text = GetIdOstan(CmbOstanId.Text)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnAddCity_Click")
            disableCity(True)
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnCanCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCanCity.Click
        bs_C.CancelEdit()
        disableCity(True)
        Me.RefreshBank()
        BtnAddCity.Focus()
    End Sub

    Private Sub BtnDelCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelCity.Click
        If bs_C.Count <= 0 Then
            MessageBox.Show("هيچ شهرستانی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد شهرستان جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNameCity.Text
                bs_C.RemoveAt(bs_C.Position)
                dta_C.Update(ds_C, "Define_City")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف شهرستان", "حذف", "حذف شهرستان :" & nam, "")
                ds_C.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("شهرستان انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnDelCity_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCity.Click
        If bs_C.Count <= 0 Then
            MessageBox.Show("هيچ شهرستانی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelCity.Enabled = False
            BtnEditCity.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disableCity(False)
        edt = 1
        str_name = Trim(TxtNameCity.Text)
        Id_City = Trim(TxtOstanId.Text)
    End Sub

    Private Sub BtnSaveCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveCity.Click
        Try

            TxtOstanId.Text = GetIdOstan(CmbOstanId.Text)
            If Trim(TxtNameCity.Text) = "" Then
                MessageBox.Show("نام شهرستان را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNameCity.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtOstanId.Text.Trim) Or CmbOstanId.Text = "" Or CmbOstanId.FindStringExact(CmbOstanId.Text) = -1 Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanId.Focus()
                Exit Sub
            End If
            If TxtOstanId.Text = "-1" Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanId.Focus()
                Exit Sub
            End If
            If edt = 0 Then
                If Not Me.AreYouAddCity(TxtNameCity.Text, CLng(TxtOstanId.Text)) Then
                    MessageBox.Show("  نام شهرستان مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditCity(TxtNameCity.Text, CLng(TxtOstanId.Text)) Then
                    MessageBox.Show("نام شهرستان مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If Not SetOstan(DGV3.Item("Cln_CodeCity", DGV3.CurrentRow.Index).Value, Id_City, CLng(TxtOstanId.Text)) Then Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            bs_C.EndEdit()
            dta_C.Update(ds_C, "Define_City")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف شهرستان", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت شهرستان : " & TxtNameCity.Text.Trim, "ویرایش شهرستان از : " & str_name & " به " & TxtNameCity.Text.Trim), "")
            DGV3.Refresh()
            DGV3.RefreshEdit()
            ds_C.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelCity.Enabled = True
            disableCity(True)
            BtnAddCity.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("استان انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableCity(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnSaveCity_Click")
            End If

            RefreshBank()
        End Try
    End Sub

    Private Function SetOstan(ByVal IdCity As Long, ByVal OldOstan As Long, ByVal NewOstan As Long) As Boolean
        Try
            If OldOstan = NewOstan Then Return True
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE  Define_Part SET IdOstan=" & NewOstan & " WHERE IdOstan=" & OldOstan & " AND IdCity=" & IdCity & ";UPDATE  Define_People  SET IdOstan=" & NewOstan & " WHERE IdOstan=" & OldOstan & " AND IdCity=" & IdCity, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "SetOstan")
            Return False
        End Try
    End Function

    Private Function Set_Ostan_City(ByVal OldPart As Long, ByVal OldOstan As Long, ByVal NewOstan As Long, ByVal OldCity As Long, ByVal NewCity As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            'If OldOstan <> NewOstan Then
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE  Define_People  SET IdOstan=" & NewOstan & ",IdCity=" & NewCity & " WHERE IdOstan=" & OldOstan & " AND IdCity=" & OldCity & " AND IdPart=" & OldPart, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            'End If

            'If OldCity <> NewCity Then
            'Using cmd As New SqlCommand("UPDATE  Define_People  SET IdCity=" & NewCity & " WHERE IdCity=" & OldCity, ConectionBank)
            'cmd.ExecuteNonQuery()
            'End Using
            'End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "Set_Ostan_City")
            Return False
        End Try
    End Function

    Private Function AreYouAddCity(ByVal nam As String, ByVal IdOstan As Long) As Boolean
        Dim T_str As String = "select NamCI  from Define_City WHERE NamCI=N'" & nam & "' AND IdOstan=" & IdOstan
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_City")
        If T_ds.Tables("Define_City").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouAddPart(ByVal nam As String, ByVal IdCity As Long, ByVal IdOstan As Long) As Boolean
        Dim T_str As String = "select NamP,IdOstan,IdCity  from Define_Part WHERE NamP=N'" & nam & "' AND IdOstan=" & IdOstan & "AND IdCity=" & IdCity
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Part")
        If T_ds.Tables("Define_Part").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditPart(ByVal nam As String, ByVal idCity As Long, ByVal idOstan As Long) As Boolean
        Dim T_str As String = "select NamP,IdOstan,IdCity  from Define_Part WHERE NamP=N'" & nam & "' AND IdOstan=" & idOstan & "AND IdCity=" & idCity
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Part")
        If T_ds.Tables("Define_Part").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Part").Rows(0).Item("NamP") <> TxtNameP.Text.Trim) Or (T_ds.Tables("Define_Part").Rows(0).Item("NamP") = str_name) And ((T_ds.Tables("Define_Part").Rows(0).Item("IdOstan") <> TxtOstanP.Text.Trim) Or (T_ds.Tables("Define_Part").Rows(0).Item("IdOstan") = Id_Ostan)) And ((T_ds.Tables("Define_Part").Rows(0).Item("IdCity") <> TxtCityP.Text.Trim) Or (T_ds.Tables("Define_Part").Rows(0).Item("IdCity") = Id_City)) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Function AreYouEditCity(ByVal nam As String, ByVal idostan As Long) As Boolean
        Dim T_str As String = "select NamCI,IdOstan  from Define_City WHERE NamCI=N'" & nam & "' AND IdOstan=" & idostan
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_City")
        If T_ds.Tables("Define_City").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_City").Rows(0).Item("NamCI") <> TxtNameCity.Text) Or (T_ds.Tables("Define_City").Rows(0).Item("NamCI") = str_name) And ((T_ds.Tables("Define_City").Rows(0).Item("IdOstan") <> TxtOstanId.Text) Or (T_ds.Tables("Define_City").Rows(0).Item("IdOstan") = Id_City)) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub CmbOstanId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstanId.KeyDown
        If CmbOstanId.DroppedDown = False Then
            CmbOstanId.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtNameCity.Focus()
        End If
    End Sub

    Private Sub CmbOstanId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstanId.LostFocus
        TxtOstanId.Text = GetIdOstan(CmbOstanId.Text)
    End Sub

    Private Sub CmbCityId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstanId.SelectedIndexChanged
        TxtOstanId.Text = GetIdOstan(CmbOstanId.Text)
    End Sub

    Private Sub TxtNameCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameCity.KeyDown
        If e.KeyCode = Keys.Enter Then TxtTellCity.Focus()
    End Sub

    Private Sub TxtNameCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameCity.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameCity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNameCity.LostFocus
        If BtnAddCity.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = TxtNameCity.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        TxtNameCity.Text = str
    End Sub

    Private Sub TxtNameCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNameCity.TextChanged
        TxtNameCity.Text = TxtNameCity.Text.Replace(",", "")
        TxtNameCity.Text = TxtNameCity.Text.Replace(";", "")
        TxtNameCity.Text = TxtNameCity.Text.Replace("'", "")
    End Sub

    Private Sub TxtTellCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTellCity.KeyDown
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

    Private Sub TxtNameP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameP.KeyDown
        If e.KeyCode = Keys.Enter Then TxtAddP.Focus()
    End Sub

    Private Sub TxtNameP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameP.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNameP.LostFocus
        If BtnAddP.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = TxtNameP.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        TxtNameP.Text = str
    End Sub

    Private Sub TxtNameP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNameP.TextChanged
        TxtNameP.Text = TxtNameP.Text.Replace(",", "")
        TxtNameP.Text = TxtNameP.Text.Replace(";", "")
        TxtNameP.Text = TxtNameP.Text.Replace("'", "")
    End Sub

    Private Sub TxtAddP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAddP.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSaveP.Focus()
    End Sub

    Private Sub CmbOstanP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstanP.KeyDown
        If CmbOstanP.DroppedDown = False Then
            CmbOstanP.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbCityP.Focus()
        End If
    End Sub

    Private Sub CmbOstanP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstanP.LostFocus
        If BtnAddP.Enabled = False Then
            TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
            CmbCityP.Items.Clear()
            For i As Integer = 0 To ds_C.Tables(0).Rows.Count - 1
                If ds_C.Tables(0).Rows(i).Item("IdOstan") = CLng(TxtOstanP.Text) Then
                    CmbCityP.Items.Add(ds_C.Tables(0).Rows(i).Item("NamCI"))
                End If
            Next
            If CmbCityP.FindStringExact(CmbCityP.Text) = -1 Then CmbCityP.Text = ""
        End If
    End Sub

    Private Sub CmbOstanP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstanP.SelectedIndexChanged
        TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
        Me.FillCity(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
    End Sub

    Private Sub BtnAddP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddP.Click
        disablePart(False)
        Try
            Me.RefreshBank()
            bs_P.AddNew()
            edt = 0
            CmbOstanP.Focus()
            TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnAddP_Click")
            disablePart(True)
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnDelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelP.Click
        If bs_P.Count <= 0 Then
            MessageBox.Show("هيچ مسیری براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelP.Enabled = False
            BtnEditP.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد مسیر جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNameP.Text
                bs_P.RemoveAt(bs_P.Position)
                dta_P.Update(ds_P, "Define_Part")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف مسیر", "حذف", "حذف مسیر :" & nam, "")
                ds_P.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("منطقه انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnDelP_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub
    Private Function AreYouDeleteP(ByVal id As Long) As Boolean
        Try
            Dim ds_T As New DataSet
            Dim str_T As String = "select Count(IdPart) from Define_People WHERE IdPart=" & id
            Dim dta_T As New SqlDataAdapter(str_T, DataSource)
            ds_T.Clear()
            If Not dta_T Is Nothing Then
                dta_T.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_T = New SqlDataAdapter(str_T, DataSource)
            dta_T.Fill(ds_T, "Define_People")
            If ds_T.Tables("Define_People").Rows(0).Item(0) Is DBNull.Value Then
                Return True
            ElseIf ds_T.Tables("Define_People").Rows(0).Item(0) = 0 Then
                Return True
            ElseIf ds_T.Tables("Define_People").Rows(0).Item(0) > 0 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub BtnCanP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCanP.Click
        bs_P.CancelEdit()
        disablePart(True)
        Me.RefreshBank()
        BtnAddP.Focus()
    End Sub

    Private Sub BtnEditP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditP.Click
        If bs_P.Count <= 0 Then
            MessageBox.Show("هيچ مسیری برای ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelP.Enabled = False
            BtnEditP.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disablePart(False)
        edt = 1
        str_name = Trim(TxtNameP.Text)
        Id_Ostan = Trim(TxtOstanP.Text)
        Id_City = Trim(TxtCityP.Text)
    End Sub

    Private Sub CmbCityP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCityP.KeyDown
        If CmbCityP.DroppedDown = False Then
            CmbCityP.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtNameP.Focus()
        End If
    End Sub

    Private Sub CmbCityP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCityP.LostFocus
        If CmbCityP.FindStringExact(CmbCityP.Text) = -1 Then CmbCityP.Text = ""
        TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
    End Sub

    Private Sub CmbCityP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCityP.SelectedIndexChanged
        TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
    End Sub

    Private Sub BtnSaveP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveP.Click
        Try

            TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
            TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
            If Trim(TxtNameP.Text) = "" Then
                MessageBox.Show("نام مسیر را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNameP.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtOstanP.Text.Trim) Or CmbOstanP.Text = "" Or CmbOstanP.FindStringExact(CmbOstanP.Text) = -1 Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCityP.Text.Trim) Or CmbCityP.Text = "" Or CmbCityP.FindStringExact(CmbCityP.Text) = -1 Then
                MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCityP.Focus()
                Exit Sub
            End If

            If TxtOstanP.Text = "-1" Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanP.Focus()
                Exit Sub
            End If
            If TxtCityP.Text = "-1" Then
                MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCityP.Focus()
                Exit Sub
            End If
            If edt = 0 Then
                If Not Me.AreYouAddPart(TxtNameP.Text, CLng(TxtCityP.Text), CLng(TxtOstanP.Text)) Then
                    MessageBox.Show("  نام مسیر مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditPart(TxtNameP.Text, CLng(TxtCityP.Text), CLng(TxtOstanP.Text)) Then
                    MessageBox.Show("نام مسیر مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not Set_Ostan_City(DGV4.Item("Cln_CodeP", DGV4.CurrentRow.Index).Value, Id_Ostan, CLng(TxtOstanP.Text), Id_City, CLng(TxtCityP.Text)) Then Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            bs_P.EndEdit()
            dta_P.Update(ds_P, "Define_Part")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف مسیر", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت مسیر : " & TxtNameP.Text.Trim, "ویرایش مسیر از : " & str_name & " به " & TxtNameP.Text.Trim), "")
            DGV4.Refresh()
            DGV4.RefreshEdit()
            ds_P.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelP.Enabled = True
            disablePart(True)
            BtnAddP.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("استان یا شهرستان انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disablePart(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "BtnSaveP_Click")
            End If
            RefreshBank()
        End Try
    End Sub

    Private Sub DGV4_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV4.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV4.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV4.DefaultCellStyle.Font, b, DGV4.Size.Width - 40, 6)
            If DGV4.RowCount < 1000 Then
                e.Graphics.DrawString(e.RowIndex + 1, DGV4.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV4.Size.Width - 40, e.RowBounds.Location.Y)
            Else
                e.Graphics.DrawString(e.RowIndex + 1, DGV4.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV4.Size.Width - 50, e.RowBounds.Location.Y)
            End If
        End Using
    End Sub

    Private Function GetIdPart(ByVal Nam As String, ByVal idO As String, ByVal idCi As String) As Long
        Dim dr() As DataRow
        dr = ds_P.Tables(0).Select("NamP ='" & Nam & "' AND IdCity=" & idCi & " AND IdOstan=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function

    Private Function GetNamPart(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_P.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamP")
        Else
            Return ""
        End If
    End Function
    Private Sub RefreshBank()
        Try
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_Ostan")
            ds_C.Clear()
            dta_C.Fill(ds_C, "Define_City")
            Me.Set_Tmp_Ostan()
            ds_P.Clear()
            dta_P.Fill(ds_P, "Define_Part")
            Me.Set_Tmp_Ostan_City()
            FillOstan()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCity", "RefreshBank")
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

    Private Sub TxtOstanId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOstanId.TextChanged
        Try
            'If BtnAddCity.Enabled = True Then
            CmbOstanId.Text = Me.GetNamOstan(TxtOstanId.Text)
            'End If
        Catch ex As Exception
            'CmbOstanId.Text = ""
        End Try
    End Sub

    Private Sub TxtOstanP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOstanP.TextChanged
        Try
            '    If BtnAddP.Enabled = True Then
            CmbOstanP.Text = Me.GetNamOstan(TxtOstanP.Text)
            CmbCityP.Text = Me.GetNamCity(TxtCityP.Text)
            'End If
        Catch ex As Exception
            ' CmbOstanP.Text = ""
            'CmbCityP.Text = ""
        End Try
    End Sub

    Private Sub TxtCityP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCityP.TextChanged
        Try
            'If BtnAddP.Enabled = True Then
            CmbOstanP.Text = Me.GetNamOstan(TxtOstanP.Text)
            CmbCityP.Text = Me.GetNamCity(TxtCityP.Text)
            'End If
        Catch ex As Exception
            'CmbOstanP.Text = ""
            'CmbCityP.Text = ""
        End Try
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
       Me.RefreshBank()
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
       Me.RefreshBank()
    End Sub
   
    Private Sub BN1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN1.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub BN2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN2.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub BN3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN3.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub RepairCity()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("Update Define_Part SET IdOstan=(SELECT IdOstan FROM Define_City WHERE Define_City.Code =Define_Part.IdCity)", ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SqlCommand("UPDATE Define_People SET IdOstan=(SELECT IdOstan FROM Define_Part WHERE Define_Part.Code =Define_People.IdPart),IdCity=(SELECT IdCity FROM Define_Part WHERE Define_Part.Code =Define_People.IdPart )", ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroup", "RepairCity")
        End Try
    End Sub
End Class