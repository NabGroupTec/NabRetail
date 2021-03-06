Imports System.Data.SqlClient
Public Class DefinePeople
    Dim row As Integer
    Dim edt As Integer
    Dim str_name As String
    Dim ds As New DataSet
    Dim str As String = "select * from Define_People"
    Dim dta As New SqlDataAdapter(str, DataSource)
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_O As New DataSet
    Dim str_O As String = "select Code,NamO From Define_Ostan"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_C As New DataSet
    Dim str_C As String = "select Code,NamCI,Idostan From Define_City"
    Dim dta_C As New SqlDataAdapter(str_C, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_P As New DataSet
    Dim str_P As String = "select Code,NamP,IdOstan,IdCity From Define_Part"
    Dim dta_P As New SqlDataAdapter(str_P, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_G As New DataSet
    Dim str_G As String = "select Id,Nam From Define_Group_P"
    Dim dta_G As New SqlDataAdapter(str_G, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub RefreshBank()
        Try
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_Ostan")
            ds_C.Clear()
            dta_C.Fill(ds_C, "Define_City")
            ds_P.Clear()
            dta_P.Fill(ds_P, "Define_Part")
            ds_G.Clear()
            dta_G.Fill(ds_G, "Define_Group_P")
            ds.Clear()
            dta.Fill(ds, "Define_People")
            Me.FillOstan()
            Me.FillGroup()
            Me.Set_Ostan_City_Part()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "RefreshBank")
            Me.Close()
        End Try
    End Sub
    Private Sub set_txtbind()
        Txtname.DataBindings.Add("text", bs, ".nam", True, DataSourceUpdateMode.OnValidation)
        Txtadd.DataBindings.Add("text", bs, ".address", True, DataSourceUpdateMode.OnValidation)
        Txttell1.DataBindings.Add("text", bs, ".tell1", True, DataSourceUpdateMode.OnValidation)
        Txttell2.DataBindings.Add("text", bs, ".tell2", True, DataSourceUpdateMode.OnValidation)
        Txtallmoney.DataBindings.Add("text", bs, ".allmoney", True, DataSourceUpdateMode.OnValidation)
        Txtfax.DataBindings.Add("text", bs, ".fax", True, DataSourceUpdateMode.OnValidation)
        Txtdelay.DataBindings.Add("text", bs, ".Rate", True, DataSourceUpdateMode.OnValidation)
        TxtMoney.DataBindings.Add("text", bs, ".GValueMon", True, DataSourceUpdateMode.OnValidation)
        Txtfac.DataBindings.Add("text", bs, ".NamFac", True, DataSourceUpdateMode.OnValidation)
        Txtco.DataBindings.Add("text", bs, ".NamCo", True, DataSourceUpdateMode.OnValidation)
        CmbState.DataBindings.Add("text", bs, ".State", True, DataSourceUpdateMode.OnValidation)
        Chkbuyer.DataBindings.Add("CheckState", bs, ".Buyer", True, DataSourceUpdateMode.OnValidation)
        Chkseller.DataBindings.Add("CheckState", bs, ".Seller", True, DataSourceUpdateMode.OnValidation)
        Chkother.DataBindings.Add("CheckState", bs, ".Other", True, DataSourceUpdateMode.OnValidation)
        ChkMon.DataBindings.Add("CheckState", bs, ".GValue", True, DataSourceUpdateMode.OnValidation)
        TxtOstanP.DataBindings.Add("text", bs, ".IdOstan", True, DataSourceUpdateMode.OnValidation)
        TxtCityP.DataBindings.Add("text", bs, ".IdCity", True, DataSourceUpdateMode.OnValidation)
        TxtPartP.DataBindings.Add("text", bs, ".IdPart", True, DataSourceUpdateMode.OnValidation)
        ChkActive.DataBindings.Add("CheckState", bs, ".Activ", True, DataSourceUpdateMode.OnValidation)
        ChkGroup.DataBindings.Add("CheckState", bs, ".ChkIdGroup", True, DataSourceUpdateMode.OnValidation)
        TxtGroup.DataBindings.Add("text", bs, ".IdGroup", True, DataSourceUpdateMode.OnValidation)
        CmbOstanP.DataBindings.Add("text", bs, ".Ostan", True, DataSourceUpdateMode.OnValidation)
        CmbCityP.DataBindings.Add("text", bs, ".City", True, DataSourceUpdateMode.OnValidation)
        CmbPartP.DataBindings.Add("text", bs, ".Part", True, DataSourceUpdateMode.OnValidation)
        TxtDate.DataBindings.Add("Thistext", bs, ".D_dat", True, DataSourceUpdateMode.OnValidation)
        TxtCode.DataBindings.Add("text", bs, ".MCode", True, DataSourceUpdateMode.OnValidation)
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
            dta.Fill(ds, "Define_People")
            ds.Tables("Define_People").Columns.Add("Ostan", System.Type.GetType("System.String"))
            ds.Tables("Define_People").Columns.Add("City", System.Type.GetType("System.String"))
            ds.Tables("Define_People").Columns.Add("Part", System.Type.GetType("System.String"))
            Me.Set_Ostan_City_Part()
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds.Tables("Define_People").Columns("ID")
            ds.Tables("Define_People").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_People"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "fill_dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub Set_Ostan_City_Part()
        Dim T_str As String = "SELECT     Define_People.ID , NamO, NamCI, NamP FROM  Define_People INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_People")
        If T_ds.Tables("Define_People").Rows.Count <= 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To ds.Tables("Define_People").Rows.Count - 1
            Dim dr() As DataRow = T_ds.Tables(0).Select("Id=" & ds.Tables("Define_People").Rows(i).Item("ID"))
            If dr.Length > 0 Then
                ds.Tables("Define_People").Rows(i).Item("Ostan") = dr(0).Item("NamO")
                ds.Tables("Define_People").Rows(i).Item("City") = dr(0).Item("NamCI")
                ds.Tables("Define_People").Rows(i).Item("Part") = dr(0).Item("NamP")
            End If
        Next
    End Sub

    Private Sub disable(ByVal flag As Boolean)
        Ls.Enabled = flag
        TxtS.Enabled = flag
        Txtname.ReadOnly = flag
        Txtfax.ReadOnly = flag
        Txtadd.ReadOnly = flag
        Txttell1.ReadOnly = flag
        Txttell2.ReadOnly = flag
        Txtallmoney.ReadOnly = flag
        Txtdelay.ReadOnly = flag
        TxtMoney.ReadOnly = flag
        Txtfac.ReadOnly = flag
        Txtco.ReadOnly = flag
        TxtCode.ReadOnly = flag
        ChkMon.Enabled = Not flag
        CmbState.Enabled = Not flag
        TxtDate.Enabled = Not flag
        Button1.Enabled = Not flag
        Button2.Enabled = Not flag
        Chkbuyer.Enabled = Not flag
        Chkseller.Enabled = Not flag
        Chkother.Enabled = Not flag
        'ChkActive.Enabled = Not flag
        ChkGroup.Enabled = Not flag
        BN.Enabled = flag
        cmdsave.Enabled = Not flag
        cmdcan.Enabled = Not flag
        DGV.Enabled = flag
        cmdadd.Enabled = flag
        BtnActive.Enabled = flag
        BtnPrint.Enabled = flag
        ChkSelect.Enabled = flag
        cmdedit.Enabled = flag
        cmddel.Enabled = flag
        CmbGroup.Enabled = Not flag
        CmbOstanP.Enabled = Not flag
        CmbCityP.Enabled = Not flag
        CmbPartP.Enabled = Not flag
        If Fnew = False Then
            cmdedit.Enabled = flag
            cmddel.Enabled = flag
        Else
            cmdedit.Enabled = False
            cmddel.Enabled = False
        End If
        SetButton()
    End Sub

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then Txttell1.Focus()
        getkey(e)
    End Sub

    Private Sub Txttell1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txttell1.KeyDown
        If e.KeyCode = Keys.Enter Then Txtfax.Focus()
        getkey(e)
    End Sub

    Private Sub Txttell2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txttell2.KeyDown
        If e.KeyCode = Keys.Enter Then Txtfac.Focus()
        getkey(e)
    End Sub

    Private Sub Txtfax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtfax.KeyDown
        If e.KeyCode = Keys.Enter Then Txttell2.Focus()
        getkey(e)
    End Sub

    Private Sub Txtadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtadd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Chkbuyer.Focus()
        End If
        getkey(e)
    End Sub

    Private Sub Define_People_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cmdadd.Focus()
    End Sub

    Private Sub Factory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdsave.Enabled = True Or cmdcan.Enabled = True Then
            bs.CancelEdit()
            disable(True)
        End If

        Me.RepairIdGroup()
    End Sub
    Private Sub Fill_Ostan()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            dta_O = New SqlDataAdapter(str_O, DataSource)
            dta_O.Fill(ds_O, "Define_Ostan")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "Fill_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_City()
        Try
            ds_C.Clear()
            If Not dta_C Is Nothing Then
                dta_C.Dispose()
            End If
            dta_C = New SqlDataAdapter(str_C, DataSource)
            dta_C.Fill(ds_C, "Define_City")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "Fill_City")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_Part()
        Try
            ds_P.Clear()
            If Not dta_P Is Nothing Then
                dta_P.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_P = New SqlDataAdapter(str_P, DataSource)
            dta_P.Fill(ds_P, "Define_Part")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "Fill_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_Group()
        Try
            ds_G.Clear()
            If Not dta_G Is Nothing Then
                dta_G.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_G = New SqlDataAdapter(str_G, DataSource)
            dta_G.Fill(ds_G, "Define_Group_P")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "Fill_Group")
            Me.Close()
        End Try
    End Sub
    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "TarfHesab.htm")
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
        ElseIf e.KeyCode = Keys.F8 Then
            If BtnPrint.Enabled = True Then Call BtnPrint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F9 Then
            If BtnActive.Enabled = True Then Call BtnActive_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If cmdadd.Enabled = False Then
                bs.CancelEdit()
                disable(True)
            End If
            Me.RefreshBank()
        End If
    End Sub

    Private Sub Define_Define_People_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub Factory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Access_Form = Get_Access_Form("F37")
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
        row = 0
        Me.Fill_Ostan()
        Me.Fill_City()
        Me.Fill_Part()
        Me.Fill_Group()
        Me.fill_dgv()
        Me.set_txtbind()
        Me.FillOstan()
        Me.FillGroup()
        DGV.Sort(DGV.Columns("cln_name"), System.ComponentModel.ListSortDirection.Ascending)
        disable(True)
        If DGV.RowCount > 0 Then
            DGV.Rows(0).Selected = True
        End If
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F37")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmddel.Enabled = False
                    cmdedit.Enabled = False
                    cmdcan.Enabled = False
                    cmdsave.Enabled = False
                    BtnActive.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmddel.Enabled = False
                        cmdedit.Enabled = False
                        cmdcan.Enabled = False
                        cmdsave.Enabled = False
                        BtnActive.Enabled = False
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
                        Try
                            If Access_Form.Substring(6, 1) = 0 Then
                                BtnPrint.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnPrint.Enabled = False
                        End Try

                        Try
                            If Access_Form.Substring(7, 1) = 0 Then
                                BtnActive.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnActive.Enabled = False
                        End Try
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
                BtnActive.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ طرف حسابی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد طرف حساب جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = DGV.Item("cln_name", DGV.CurrentRow.Index).Value
                bs.RemoveAt(bs.Position)
                dta.Update(ds, "Define_People")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف طرف حساب", "حذف", "حذف طرف حساب :" & nam, "")
                ds.AcceptChanges()
                RefreshBank()
                If row <= DGV.RowCount - 1 Then DGV.Item("Cln_Id", row).Selected = True
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("طرف حساب انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "cmddel_Click")
                End If
                RefreshBank()
                If row <= DGV.RowCount - 1 Then DGV.Item("Cln_Id", row).Selected = True
            End Try
        End If
    End Sub
    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        Try
            bs.CancelEdit()
            disable(True)
            RefreshBank()
            cmdadd.Focus()
            If row <= DGV.RowCount - 1 Then DGV.Item("Cln_Id", row).Selected = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "cmdcan_Click")
            RefreshBank()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            RefreshBank()
            bs.AddNew()
            disable(False)
            edt = 0
            Txtallmoney.Text = 1
            Txtallmoney.Text = 0
            Txtdelay.Text = 1
            Txtdelay.Text = 0
            TxtMoney.Text = 1
            TxtMoney.Text = 0
            CmbState.Text = ""
            CmbState.Text = CmbState.Items(2).ToString
            Chkbuyer.Checked = False
            Chkseller.Checked = False
            Chkother.Checked = False
            ChkMon.Checked = False
            ChkActive.Checked = False
            ChkGroup.Checked = False
            ChkGroup.Checked = True
            TxtOstanP.Text = 0
            TxtCityP.Text = 0
            TxtPartP.Text = 0
            TxtGroup.Text = 0
            TxtDate.ThisText = GetDate()
            FillOstan()
            FillCity(0)
            FillPart(0, 0)
            Txtname.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "cmdadd_Click")
            disable(True)
            RefreshBank()
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            If Trim(Txtname.Text) = "" Then
                MessageBox.Show("نام طرف حساب را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtname.Focus()
                Exit Sub
            End If
            If Chkbuyer.Checked = False And Chkseller.Checked = False And Chkother.Checked = False Then
                MessageBox.Show("لطفا يكي از گزينه هاي خريدار،فروشنده یا سایر را انتخاب كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Chkbuyer.Focus()
                Exit Sub
            End If
            If (CmbState.Text = "بدهکار" Or CmbState.Text = "بستانکار") And (Txtallmoney.Text = 0) Then
                MessageBox.Show("در صورت انتخاب وضعیت به صورت بدهکار یا بستانکار باید مبلغ اول دوره را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtallmoney.Focus()
                Exit Sub
            End If
            If (CmbState.Text = "بی حساب") And (Txtallmoney.Text <> 0) Then
                MessageBox.Show("در صورت انتخاب وضعیت به صورت بی حساب باید مبلغ اول دوره صفر باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtallmoney.Text = 0
                Txtallmoney.Focus()
                Exit Sub
            End If
            If CDbl(TxtMoney.Text < 0) Then
                MessageBox.Show("اعتبار منفی قابل قبول نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtMoney.Text = 0
                TxtMoney.Focus()
                Exit Sub
            End If
            If CDbl(Txtdelay.Text < 0) Then
                MessageBox.Show("مدت وعده منفی قابل قبول نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtdelay.Text = 0
                Txtdelay.Focus()
                Exit Sub
            End If

            ChkGroup.Checked = True
            TxtGroup.Text = GetIdGroup(CmbGroup.Text)
            TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
            TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
            TxtPartP.Text = GetIdPart(CmbPartP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
            If String.IsNullOrEmpty(TxtOstanP.Text.Trim) Or CmbOstanP.Text = "" Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCityP.Text.Trim) Or CmbCityP.Text = "" Then
                MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCityP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtPartP.Text.Trim) Or CmbPartP.Text = "" Then
                MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbPartP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtGroup.Text.Trim) Or CmbGroup.Text = "" Then
                MessageBox.Show("هیچ گروه ویژه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbGroup.Focus()
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
            If TxtPartP.Text = "-1" Then
                MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbPartP.Focus()
                Exit Sub
            End If
            If TxtGroup.Text = "-1" Then
                MessageBox.Show("هیچ گروه ویژه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbGroup.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText) Or TxtDate.ThisText = "" Then
                MessageBox.Show("تاریخ معرفی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDate.Focus()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            If edt = 0 Then
                If Not Me.AreYouAddP(Txtname.Text.Trim) Then
                    MessageBox.Show("  نام طرف حساب مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditP(Txtname.Text) Then
                    MessageBox.Show("نام طرف حساب مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Dim nam As String = Txtname.Text
            bs.EndEdit()
            dta.Update(ds, "Define_People")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف طرف حساب", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت طرف حساب : " & nam, If(str_name = Txtname.Text, "ویرایش طرف حساب : " & str_name, "ویرایش طرف حساب از : " & str_name & " به " & Txtname.Text.Trim)), "")
            If edt = 1 Then SetActivePeople(DGV.Item("Cln_Id", row).Value)
            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            RefreshBank()
            If Fnew = False Then cmddel.Enabled = True
            disable(True)
            cmdadd.Focus()
            ChkSelect.Checked = False
            If row <= DGV.RowCount - 1 Then DGV.Item("Cln_Id", row).Selected = True
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("طرف حساب انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disable(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "cmdsave_Click")
            End If
            RefreshBank()
        End Try
    End Sub

    Private Function AreYouAddP(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_People WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_People")
        If T_ds.Tables("Define_People").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditP(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_People WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_People")
        If T_ds.Tables("Define_People").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_People").Rows(0).Item("Nam") <> Txtname.Text) Or (T_ds.Tables("Define_People").Rows(0).Item("Nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ طرف حسابی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            RefreshBank()
            Exit Sub
        End If
        row = DGV.CurrentRow.Index
        disable(False)
        edt = 1
        str_name = Trim(Txtname.Text)
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        getkey(e)
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
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
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

    Private Sub Chkbuyer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbuyer.GotFocus
        Chkbuyer.BackColor = Color.LightGray
    End Sub

    Private Sub Chkbuyer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkbuyer.KeyDown
        If e.KeyCode = Keys.Enter Then Chkseller.Focus()
        getkey(e)
    End Sub

    Private Sub Chkbuyer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbuyer.LostFocus
        Chkbuyer.BackColor = Me.BackColor
    End Sub

    Private Sub Chkseller_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkseller.GotFocus
        Chkseller.BackColor = Color.LightGray
    End Sub

    Private Sub Chkseller_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkseller.LostFocus
        Chkseller.BackColor = Me.BackColor
    End Sub

    Private Sub Chkseller_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkseller.KeyDown
        If e.KeyCode = Keys.Enter Then Chkother.Focus()
        getkey(e)
    End Sub

    Private Sub Txtallmoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtallmoney.KeyDown
        If e.KeyCode = Keys.Enter Then CmbOstanP.Focus()
        getkey(e)
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

    Private Sub Txtallmoney_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtallmoney.TextChanged
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

    Private Sub CmbState_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbState.GotFocus
        If CmbState.DroppedDown = False Then CmbState.DroppedDown = True
    End Sub
    Private Sub CmbState_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbState.KeyDown
        If e.KeyCode = Keys.Enter Then Txtallmoney.Focus()
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If CmbState.DroppedDown = False Then CmbState.DroppedDown = True
        End If
        getkey(e)
    End Sub

    Private Sub Txtdelay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtdelay.KeyDown
        If e.KeyCode = Keys.Enter Then ChkMon.Focus()
        getkey(e)
    End Sub

    Private Sub Txtdelay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdelay.KeyPress
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

    Private Sub Txtdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdelay.TextChanged
        If Not (CheckDigit(Format$(Txtdelay.Text))) Then Txtdelay.Text = "0"
    End Sub

    Private Sub TxtMoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMoney.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtadd.Focus()
        End If
        getkey(e)
    End Sub

    Private Sub TxtMoney_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoney.KeyPress
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

    Private Sub TxtMoney_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoney.TextChanged
        If Not (CheckDigit(Format$(TxtMoney.Text.Replace(",", "")))) Then
            TxtMoney.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtMoney.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtMoney.Text.Replace(",", ""))
            TxtMoney.Text = Format$(Val(str), "###,###,###")
        Else
            TxtMoney.Text = CDbl(TxtMoney.Text)
        End If
    End Sub

    Private Sub ChkMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMon.GotFocus
        ChkMon.BackColor = Color.LightGray
    End Sub

    Private Sub ChkMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMoney.Focus()
        getkey(e)
    End Sub

    Private Sub ChkMon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMon.LostFocus
        ChkMon.BackColor = Me.BackColor
    End Sub

    Private Sub Chkother_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkother.GotFocus
        Chkother.BackColor = Color.LightGray
    End Sub

    Private Sub Chkother_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkother.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CmbState.Visible = True Then
                CmbState.Focus()
            Else
                cmdsave.Focus()
            End If
        End If
        getkey(e)
    End Sub

    Private Sub Chkother_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkother.LostFocus
        Chkother.BackColor = Me.BackColor
    End Sub

    Private Sub Chkother_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkother.CheckedChanged
        If Chkother.Checked = True Then
            Chkseller.Checked = False
            Chkbuyer.Checked = False
        End If
    End Sub

    Private Sub Chkseller_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkseller.CheckedChanged
        If Chkseller.Checked = True Then
            Chkother.Checked = False
        End If
    End Sub

    Private Sub Chkbuyer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbuyer.CheckedChanged
        If Chkbuyer.Checked = True Then
            Chkother.Checked = False
        End If
    End Sub

    Private Sub Txtfac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtfac.KeyDown
        If e.KeyCode = Keys.Enter Then Txtco.Focus()
        getkey(e)
    End Sub

    Private Sub Txtco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtco.KeyDown
        If e.KeyCode = Keys.Enter Then Txtdelay.Focus()
        getkey(e)
    End Sub

    Private Sub TxtS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtS.KeyDown
        If e.KeyCode = Keys.Down And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = DGV.Rows.Count - 1 Then
                DGV.Item("Cln_Name", 0).Selected = True
                e.Handled = True
            Else
                DGV.Item("Cln_Name", DGV.CurrentRow.Index + 1).Selected = True
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Up And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = 0 Then
                DGV.Item("Cln_Name", DGV.Rows.Count - 1).Selected = True
                e.Handled = True
            Else
                DGV.Item("Cln_Name", DGV.CurrentRow.Index - 1).Selected = True
                e.Handled = True
            End If
        End If
        '//////////////////////////////////////////////////////////
        If e.KeyCode = Keys.Enter Then
            If DGV.RowCount > 1 And TxtS.Text <> "" Then
                Dim txtdgv, txtk As String
                For i As Integer = 0 To DGV.RowCount - 1
                    txtdgv = DGV.Item("Cln_Name", i).Value.ToString
                    txtk = TxtS.Text
                    If txtdgv.Contains(TxtS.Text.Trim) And txtdgv(0).ToString = txtk(0).ToString Then
                        DGV.Item("Cln_Name", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item("Cln_Name", 0).Selected = True
                DGV.Item("Cln_Name", 0).Selected = False
            End If
        End If
        getkey(e)
    End Sub

    Private Sub TxtS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = False
        frmlk.ShowDialog()
        e.Handled = True
        TxtS.Focus()
        If Tmp_Namkala <> "" Then
            TxtS.Text = Tmp_Namkala
        Else
            TxtS.Text = ""
        End If
    End Sub

    Private Sub TxtS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtS.TextChanged
        If DGV.RowCount > 1 And TxtS.Text <> "" Then
            Dim txtdgv, txtk As String
            For i As Integer = 0 To DGV.RowCount - 1
                txtdgv = DGV.Item("Cln_Name", i).Value.ToString
                txtk = TxtS.Text
                If txtdgv.Contains(TxtS.Text.Trim) And txtdgv(0).ToString = txtk(0).ToString Then
                    DGV.Item("Cln_Name", i).Selected = True
                    Exit Sub
                End If
            Next
            DGV.Item("Cln_Name", 0).Selected = True
            DGV.Item("Cln_Name", 0).Selected = False
        End If
    End Sub

    Private Sub CmbOstanP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstanP.KeyDown
        If CmbOstanP.DroppedDown = False Then CmbOstanP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbCityP.Focus()
        getkey(e)
    End Sub

    Private Sub CmbOstanP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstanP.SelectedIndexChanged
        TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
        Me.FillCity(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
        Me.FillPart(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
    End Sub
    Private Sub FillOstan()
        CmbOstanP.Items.Clear()
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbOstanP.Items.Add(ds_O.Tables(0).Rows(i).Item("NamO"))
        Next
    End Sub
    Private Sub FillGroup()
        CmbGroup.Items.Clear()
        For i As Integer = 0 To ds_G.Tables(0).Rows.Count - 1
            CmbGroup.Items.Add(ds_G.Tables(0).Rows(i).Item("Nam"))
        Next
    End Sub
    Private Sub FillCity(ByVal idO As Long)
        CmbCityP.Items.Clear()
        For i As Integer = 0 To ds_C.Tables(0).Rows.Count - 1
            If ds_C.Tables(0).Rows(i).Item("IdOstan") = idO Then
                CmbCityP.Items.Add(ds_C.Tables(0).Rows(i).Item("NamCi"))
            End If
        Next
    End Sub
    Private Function GetIdGroup(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_G.Tables(0).Select("Nam ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("ID")
        Else
            Return -1
        End If
    End Function
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
    Private Sub FillPart(ByVal idO As Long, ByVal idCi As Long)
        CmbPartP.Items.Clear()
        For i As Integer = 0 To ds_P.Tables(0).Rows.Count - 1
            If ds_P.Tables(0).Rows(i).Item("IdOstan") = idO And ds_P.Tables(0).Rows(i).Item("IdCity") = idCi Then
                CmbPartP.Items.Add(ds_P.Tables(0).Rows(i).Item("NamP"))
            End If
        Next
    End Sub

    Private Sub CmbCityP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCityP.KeyDown
        If CmbCityP.DroppedDown = False Then CmbCityP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbPartP.Focus()
        getkey(e)
    End Sub

    Private Sub CmbCityP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCityP.SelectedIndexChanged
        TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
        Me.FillPart(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
    End Sub

    Private Sub CmbPartP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbPartP.KeyDown
        If CmbPartP.DroppedDown = False Then CmbPartP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then ChkGroup.Focus()
        getkey(e)
    End Sub

    Private Sub CmbPartP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPartP.SelectedIndexChanged
        TxtPartP.Text = GetIdPart(CmbPartP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
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

    Private Sub DGV_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV.SelectionChanged
        Try
            If cmdadd.Enabled = True Then
                CmbOstanP.Text = Me.GetNamOstan(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value)
                CmbCityP.Text = Me.GetNamCity(DGV.Item("Cln_City", DGV.CurrentRow.Index).Value)
                CmbPartP.Text = Me.GetNamPart(DGV.Item("Cln_Part", DGV.CurrentRow.Index).Value)
                CmbGroup.Text = Me.GetNamGroup(DGV.Item("Cln_Group", DGV.CurrentRow.Index).Value)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetNamPart(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_P.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamP")
        Else
            Return ""
        End If
    End Function
    Private Function GetNamGroup(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_G.Tables(0).Select("ID =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("Nam")
        Else
            Return ""
        End If
    End Function

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        RefreshBank()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        RefreshBank()
    End Sub

    Private Sub CmbState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbState.SelectedIndexChanged

    End Sub

    Private Sub BN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub cmdadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdadd.KeyDown
        getkey(e)
    End Sub

    Private Sub cmdcan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdcan.KeyDown
        getkey(e)
    End Sub

    Private Sub cmddel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmddel.KeyDown
        getkey(e)
    End Sub

    Private Sub cmdedit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdedit.KeyDown
        getkey(e)
    End Sub

    Private Sub cmdsave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdsave.KeyDown
        getkey(e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Fnew = True
            Using FrmCity As New DefineCity
                FrmCity.ShowDialog()
            End Using
            Fnew = False
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_Ostan")
            ds_C.Clear()
            dta_C.Fill(ds_C, "Define_City")
            ds_P.Clear()
            dta_P.Fill(ds_P, "Define_Part")
            Me.FillOstan()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "Button1_Click")
        End Try
    End Sub

    Private Sub ChkActive_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkActive.GotFocus
        ChkActive.BackColor = Color.LightGray
    End Sub

    Private Sub ChkActive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkActive.KeyDown
        If e.KeyCode = Keys.Enter Then CmbGroup.Focus()
        getkey(e)
    End Sub

    Private Sub ChkActive_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkActive.LostFocus
        ChkActive.BackColor = Me.BackColor
    End Sub

    Private Sub ChkGroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGroup.GotFocus
        ChkGroup.BackColor = Color.LightGray
    End Sub

    Private Sub ChkGroup_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGroup.LostFocus
        ChkGroup.BackColor = Me.BackColor
    End Sub

    Private Sub ChkGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkGroup.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CmbGroup.Enabled = False Then
                cmdsave.Focus()
            Else
                CmbGroup.Focus()
            End If
        End If
        getkey(e)
    End Sub

    Private Sub CmbGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbGroup.KeyDown
        If CmbGroup.DroppedDown = False Then CmbGroup.DroppedDown = True
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
        getkey(e)
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        getkey(e)
    End Sub

    Private Sub Button2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button2.KeyDown
        getkey(e)
    End Sub

    Private Sub CmbGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbGroup.SelectedIndexChanged
        TxtGroup.Text = GetIdGroup(CmbGroup.Text)
    End Sub

    Private Sub TxtOstanP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOstanP.TextChanged
        'If Not String.IsNullOrEmpty(TxtOstanP.Text.Trim) And cmdadd.Enabled = True Then CmbOstanP.Text = Me.GetNamOstan(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value)
        Try
            'CmbOstanP.Text = Me.GetNamOstan(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value)
            CmbOstanP.Text = Me.GetNamOstan(TxtOstanP.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPartP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPartP.TextChanged
        'If Not String.IsNullOrEmpty(TxtPartP.Text.Trim) And cmdadd.Enabled = True Then CmbPartP.Text = Me.GetNamPart(DGV.Item("Cln_Part", DGV.CurrentRow.Index).Value)
        Try
            'CmbPartP.Text = Me.GetNamPart(DGV.Item("Cln_Part", DGV.CurrentRow.Index).Value)
            CmbPartP.Text = Me.GetNamPart(TxtPartP.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCityP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCityP.TextChanged
        'If Not String.IsNullOrEmpty(TxtCityP.Text.Trim) And cmdadd.Enabled = True Then CmbCityP.Text = Me.GetNamCity(DGV.Item("Cln_City", DGV.CurrentRow.Index).Value)
        Try
            'CmbCityP.Text = Me.GetNamCity(DGV.Item("Cln_City", DGV.CurrentRow.Index).Value)
            CmbCityP.Text = Me.GetNamCity(TxtCityP.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGroup.TextChanged
        Try
            'If Not String.IsNullOrEmpty(TxtGroup.Text.Trim) And cmdadd.Enabled = True Then
            CmbGroup.Text = Me.GetNamGroup(TxtGroup.Text)
            'End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Fnew = True
            Using FrmPeople As New DefineGroupP
                FrmPeople.ShowDialog()
            End Using
            Fnew = False
            Me.Fill_Group()
            Me.FillGroup()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "Button2_Click")
        End Try
    End Sub

    Private Sub ChkSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelect.CheckedChanged
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkSelect.Checked
        Next
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            DGV.EndEdit()
            BtnPrint.Focus()
            Dim ListP As String = " WHERE ("
            Dim cnt As Long = 0
            For i As Integer = 0 To DGV.RowCount - 1
                If DGV.Item("Cln_Select", i).Value = True Then
                    ListP &= " Define_People.ID=" & DGV.Item("Cln_Id", i).Value & " OR "
                    cnt += 1
                End If
            Next

            If cnt <= 0 Then
                MessageBox.Show("طرف حسابی برای چاپ انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf cnt = DGV.RowCount Then
                ListP = ""
            Else
                ListP = ListP.Substring(0, ListP.Length - 4)
                ListP &= ")"
            End If
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف طرف حساب", "چاپ لیست", "", "")
            FrmPrint.PrintSQl = "SELECT Define_People.ID, Define_People.Nam, Define_People.Tell1 As Fix, Define_People.Tell2 As Mobile, Define_People.[Address], Define_Ostan.NamO As Ostan, Define_City.NamCI As City,Define_Part.NamP As Part ,SGroup =Case ChkIdGroup WHEN 'False' THEN N'' ELSE (SELECT nam FROM Define_Group_P WHERE Id =Define_People.IdGroup ) END FROM Define_People INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan AND Define_Part.IdCity = Define_City.Code " & ListP & " ORDER By ID"
            FrmPrint.CHoose = "LISTPEOPLE"
            FrmPrint.ShowDialog()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "BtnPrint_Click")
        End Try
    End Sub

    Private Sub BtnPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnPrint.KeyDown
        getkey(e)
    End Sub

    Private Sub ChkSelect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkSelect.KeyDown
        getkey(e)
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtCode.Focus()
        getkey(e)
    End Sub

    Private Sub BtnActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActive.Click
        row = DGV.CurrentRow.Index
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف طرف حساب", "فعال سازی", " طرف حساب :" & Txtname.Text, "")

        Using Frm As New Frm_ActivePeople
            Frm.Id = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
            Frm.ShowDialog()
        End Using
        RefreshBank()
        If row <= DGV.RowCount - 1 Then DGV.Item("Cln_Id", row).Selected = True
    End Sub

    Private Sub BtnActive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnActive.KeyDown
        getkey(e)
    End Sub

    Private Sub TxtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then cmdsave.Focus()
        getkey(e)
    End Sub

    Private Sub RepairIdGroup()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE Define_People SET ChkIdGroup='True' WHERE ChkIdGroup='False'", ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefinePeople", "RepairIdGroup")
        End Try
    End Sub

End Class