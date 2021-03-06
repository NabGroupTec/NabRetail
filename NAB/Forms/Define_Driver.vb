Imports System.Data.SqlClient
Public Class Define_Driver
    Dim edt, Id_Country, Id_Ostan, Id_City, id_part As Integer
    Dim str_name, str_fam As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_O As New DataSet
    Dim str_O As String = "select * From Define_Driver"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    Dim bs_O As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_C As New DataSet
    Dim str_C As String = "select * From Define_Reciver"
    Dim dta_C As New SqlDataAdapter(str_C, DataSource)
    Dim bs_C As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_Car As New DataSet
    Dim str_Car As String = "select * From Define_Car"
    Dim dta_Car As New SqlDataAdapter(str_C, DataSource)
    Dim bs_Car As New BindingSource

    Private Sub set_txtbindCity()
        TxtNameCity.DataBindings.Add("text", bs_C, ".Nam", True, DataSourceUpdateMode.OnValidation)
        TxtTellCity.DataBindings.Add("text", bs_C, ".Tell", True, DataSourceUpdateMode.OnValidation)
        TxtDiscR.DataBindings.Add("text", bs_C, ".Disc", True, DataSourceUpdateMode.OnValidation)
    End Sub
  
    Private Sub set_txtbindOstan()
        TxtNameOstan.DataBindings.Add("text", bs_O, ".Nam", True, DataSourceUpdateMode.OnValidation)
        TxtTellOstan.DataBindings.Add("text", bs_O, ".Tell", True, DataSourceUpdateMode.OnValidation)
        TxtDiscD.DataBindings.Add("text", bs_O, ".Disc", True, DataSourceUpdateMode.OnValidation)
    End Sub

    Private Sub set_txtbindCar()
        TxtNameCar.DataBindings.Add("text", bs_Car, ".Nam", True, DataSourceUpdateMode.OnValidation)
        TxtDiscCar.DataBindings.Add("text", bs_Car, ".Disc", True, DataSourceUpdateMode.OnValidation)
        TxtPlak.DataBindings.Add("text", bs_Car, ".Plak", True, DataSourceUpdateMode.OnValidation)
        ChkWeight.DataBindings.Add("CheckState", bs_Car, ".Weight", True, DataSourceUpdateMode.OnValidation)
        TxtWeight.DataBindings.Add("text", bs_Car, ".WeightK", True, DataSourceUpdateMode.OnValidation)
        ChkSize.DataBindings.Add("CheckState", bs_Car, ".Size", True, DataSourceUpdateMode.OnValidation)
        Txtwidth.DataBindings.Add("text", bs_Car, ".WidthK", True, DataSourceUpdateMode.OnValidation)
        Txthight.DataBindings.Add("text", bs_Car, ".HightK", True, DataSourceUpdateMode.OnValidation)
        TxtTop.DataBindings.Add("text", bs_Car, ".TopK", True, DataSourceUpdateMode.OnValidation)
    End Sub

    Private Sub Fill_Driver()
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
            dta_O.Fill(ds_O, "Define_Driver")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_O.Tables("Define_Driver").Columns("Id")
            ds_O.Tables("Define_Driver").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV2.AutoGenerateColumns = False
            bs_O.DataSource = ds_O
            bs_O.DataMember = "Define_Driver"
            DGV2.DataSource = bs_O
            BN1.BindingSource = bs_O
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "Fill_Driver")
            disableOstan(True)
            Me.Close()
        End Try
    End Sub

    Private Sub Fill_Car()
        Try
            ds_Car.Clear()
            If Not dta_Car Is Nothing Then
                dta_Car.Dispose()
            End If
            dta_Car = New SqlDataAdapter(str_Car, DataSource)
            Dim ocb_Car As New SqlCommandBuilder(dta_Car)
            dta_Car.UpdateCommand = ocb_Car.GetUpdateCommand
            dta_Car.InsertCommand = ocb_Car.GetInsertCommand
            dta_Car.DeleteCommand = ocb_Car.GetDeleteCommand
            ds_Car.EnforceConstraints = False
            dta_Car.Fill(ds_Car, "Define_Car")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_Car.Tables("Define_Car").Columns("Id")
            ds_Car.Tables("Define_Car").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV1.AutoGenerateColumns = False
            bs_Car.DataSource = ds_Car
            bs_Car.DataMember = "Define_Car"
            DGV1.DataSource = bs_Car
            B3.BindingSource = bs_Car
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "Fill_Car")
            disableCar(True)
            Me.Close()
        End Try
    End Sub

    Private Sub Fill_Reciver()
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
            dta_C.Fill(ds_C, "Define_Reciver")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds_C.Tables("Define_Reciver").Columns("Id")
            ds_C.Tables("Define_Reciver").PrimaryKey = prvkey
            DGV3.AutoGenerateColumns = False
            bs_C.DataSource = ds_C
            bs_C.DataMember = "Define_Reciver"
            DGV3.DataSource = bs_C
            BN2.BindingSource = bs_C
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "Fill_Reciver")
            disableCity(True)
            Me.Close()
        End Try
    End Sub
    Private Sub disableOstan(ByVal flag As Boolean)
        TxtNameOstan.ReadOnly = flag
        TxtTellOstan.ReadOnly = flag
        TxtDiscD.ReadOnly = flag
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

    Private Sub disableCar(ByVal flag As Boolean)
        TxtNameCar.ReadOnly = flag
        TxtPlak.ReadOnly = flag
        TxtDiscCar.ReadOnly = flag
        Txthight.ReadOnly = flag
        TxtTop.ReadOnly = flag
        Txtwidth.ReadOnly = flag
        TxtWeight.ReadOnly = flag
        B3.Enabled = flag
        BtnSaveCar.Enabled = Not flag
        BtnCanCar.Enabled = Not flag
        ChkSize.Enabled = Not flag
        ChkWeight.Enabled = Not flag
        DGV1.Enabled = flag
        BtnAddCar.Enabled = flag
        If Fnew = False Then
            BtnEditCar.Enabled = flag
            BtnDelCar.Enabled = flag
        Else
            BtnEditCar.Enabled = False
            BtnDelCar.Enabled = False
        End If
        SetButton()
    End Sub

    Private Sub disableCity(ByVal flag As Boolean)
        TxtNameCity.ReadOnly = flag
        TxtTellCity.ReadOnly = flag
        TxtDiscR.ReadOnly = flag
        BN2.Enabled = flag
        BtnSaveCity.Enabled = Not flag
        BtnCanCity.Enabled = Not flag
        DGV3.Enabled = flag
        BtnAddCity.Enabled = flag
        If Fnew = False Then
            BtnEditCity.Enabled = flag
            BtnDelCity.Enabled = flag
        Else
            BtnEditCity.Enabled = False
            BtnDelCity.Enabled = False
        End If
        SetButton()
    End Sub
    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Tahvildar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(1).Focus = True Then
                If BtnAddOstan.Enabled = True Then Call BtnAddOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(0).Focus = True Then
                If BtnAddCity.Enabled = True Then Call BtnAddCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnAddCar.Enabled = True Then Call BtnAddCar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            If TabControl1.TabPages(1).Focus = True Then
                If BtnEditOstan.Enabled = True Then Call BtnEditOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(0).Focus = True Then
                If BtnEditCity.Enabled = True Then Call BtnEditCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnEditCar.Enabled = True Then Call BtnEditCar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If TabControl1.TabPages(1).Focus = True Then
                If BtnDelOstan.Enabled = True Then Call BtnDelOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(0).Focus = True Then
                If BtnDelCity.Enabled = True Then Call BtnDelCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnDelCar.Enabled = True Then Call BtnDelCar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If TabControl1.TabPages(1).Focus = True Then
                If BtnSaveOstan.Enabled = True Then Call BtnSaveOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(0).Focus = True Then
                If BtnSaveCity.Enabled = True Then Call BtnSaveCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnSaveCar.Enabled = True Then Call BtnSaveCar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            If TabControl1.TabPages(1).Focus = True Then
                If BtnCanOstan.Enabled = True Then Call BtnCanOstan_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(0).Focus = True Then
                If BtnCanCity.Enabled = True Then Call BtnCanCity_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If BtnCanCar.Enabled = True Then Call BtnCanCar_Click(Nothing, Nothing)
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

            If BtnAddCar.Enabled = False Then
                bs_Car.CancelEdit()
                disableCar(True)
            End If
            Me.RefreshBank()
        End If
    End Sub

    Private Sub DefineCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub Factory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F117")
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
        Me.Fill_Driver()
        Me.Fill_Reciver()
        Me.Fill_Car()
        Me.set_txtbindOstan()
        Me.set_txtbindCity()
        Me.set_txtbindCar()
        Me.disableOstan(True)
        Me.disableCity(True)
        Me.disableCar(True)
        DGV1.Columns("DataGridViewTextBoxColumn4").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Column2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_Namtell").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        SetButton()
    End Sub
    Private Sub SetButton()
        Try
            '''''''تحویلدار
            Access_Form = Get_Access_Form("F118")
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

            '''''''راننده
            Access_Form = Get_Access_Form("F119")
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

            '''''''وسیله حمل
            Access_Form = Get_Access_Form("F120")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnAddCar.Enabled = False
                    BtnDelCar.Enabled = False
                    BtnEditCar.Enabled = False
                    BtnCanCar.Enabled = False
                    BtnSaveCar.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnAddCar.Enabled = False
                        BtnDelCar.Enabled = False
                        BtnEditCar.Enabled = False
                        BtnCanCar.Enabled = False
                        BtnSaveCar.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnAddCar.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnDelCar.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnEditCar.Enabled = False
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
                BtnAddCar.Enabled = False

                BtnEditOstan.Enabled = False
                BtnEditCity.Enabled = False
                BtnEditCar.Enabled = False

                BtnDelOstan.Enabled = False
                BtnDelCity.Enabled = False
                BtnDelCar.Enabled = False

                BtnSaveOstan.Enabled = False
                BtnSaveCity.Enabled = False
                BtnSaveCar.Enabled = False

                BtnCanOstan.Enabled = False
                BtnCanCity.Enabled = False
                BtnCanCar.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "SetButton")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnAddOstan_Click")
            disableOstan(True)
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_Driver")
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
            MessageBox.Show("هيچ راننده ایی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد راننده جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNameOstan.Text
                bs_O.RemoveAt(bs_O.Position)
                dta_O.Update(ds_O, "Define_Driver")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف راننده", "حذف", "حذف راننده :" & nam, "")
                ds_O.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("راننده انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnDelOstan_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditOstan.Click
        If bs_O.Count <= 0 Then
            MessageBox.Show("هيچ راننده ایی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                MessageBox.Show("نام راننده را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNameOstan.Focus()
                Exit Sub
            End If

            If edt = 0 Then
                If Not Me.AreYouAddOstan(TxtNameOstan.Text) Then
                    MessageBox.Show("  نام راننده مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditOstan(TxtNameOstan.Text) Then
                    MessageBox.Show("نام راننده مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = TxtNameOstan.Text
            bs_O.EndEdit()
            dta_O.Update(ds_O, "Define_Driver")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف راننده", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت راننده : " & nam, If(str_name = TxtNameOstan.Text, "ویرایش راننده : " & str_name, "ویرایش راننده از : " & str_name & " به " & TxtNameOstan.Text.Trim)), "")
            DGV2.Refresh()
            DGV2.RefreshEdit()
            ds_O.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelOstan.Enabled = True
            disableOstan(True)
            BtnAddOstan.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("راننده انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableOstan(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnSaveOstan_Click")
            End If

            RefreshBank()
        End Try
    End Sub
    Private Function AreYouAddOstan(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Driver WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Driver")
        If T_ds.Tables("Define_Driver").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function AreYouAddCar(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Car WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Car")
        If T_ds.Tables("Define_Car").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function AreYouEditOstan(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Driver WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Driver")
        If T_ds.Tables("Define_Driver").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Driver").Rows(0).Item("Nam") <> TxtNameOstan.Text) Or (T_ds.Tables("Define_Driver").Rows(0).Item("Nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    
    Private Function AreYouEditCar(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Car WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Car")
        If T_ds.Tables("Define_Car").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Car").Rows(0).Item("Nam") <> TxtNameCar.Text) Or (T_ds.Tables("Define_Car").Rows(0).Item("Nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
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
        If e.KeyCode = Keys.Enter Then TxtDiscD.Focus()
    End Sub

    Private Sub BtnAddCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCity.Click
        disableCity(False)
        Try
            Me.RefreshBank()
            bs_C.AddNew()
            edt = 0
            TxtNameCity.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnAddCity_Click")
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
            MessageBox.Show("هيچ مامور توزیعی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelOstan.Enabled = False
            BtnEditOstan.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد مامور توزیع جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNameCity.Text
                bs_C.RemoveAt(bs_C.Position)
                dta_C.Update(ds_C, "Define_Reciver")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف مامور توزیع", "حذف", "حذف مامور توزیع :" & nam, "")
                ds_C.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("مامور توزیع انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnDelCity_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCity.Click
        If bs_C.Count <= 0 Then
            MessageBox.Show("هيچ مامور توزیعی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelCity.Enabled = False
            BtnEditCity.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disableCity(False)
        edt = 1
        str_name = Trim(TxtNameCity.Text)
    End Sub

    Private Sub BtnSaveCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveCity.Click
        Try

            If Trim(TxtNameCity.Text) = "" Then
                MessageBox.Show("نام مامور توزیع را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNameCity.Focus()
                Exit Sub
            End If
           
            If edt = 0 Then
                If Not Me.AreYouAddCity(TxtNameCity.Text) Then
                    MessageBox.Show("  نام مامور توزیع مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditCity(TxtNameCity.Text) Then
                    MessageBox.Show("نام مامور توزیع مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = TxtNameCity.Text
            bs_C.EndEdit()
            dta_C.Update(ds_C, "Define_Reciver")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف مامور توزیع", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت مامور توزیع : " & nam, If(str_name = TxtNameCity.Text, "ویرایش مامور توزیع : " & str_name, "ویرایش مامور توزیع از : " & str_name & " به " & TxtNameCity.Text.Trim)), "")
            DGV3.Refresh()
            DGV3.RefreshEdit()
            ds_C.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelCity.Enabled = True
            disableCity(True)
            BtnAddCity.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("مامور توزیع انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableCity(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnSaveCity_Click")
            End If

            RefreshBank()
        End Try
    End Sub

    Private Function AreYouAddCity(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Reciver WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Reciver")
        If T_ds.Tables("Define_Reciver").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function AreYouEditCity(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_Reciver WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Reciver")
        If T_ds.Tables("Define_Reciver").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Reciver").Rows(0).Item("Nam") <> TxtNameCity.Text) Or (T_ds.Tables("Define_Reciver").Rows(0).Item("Nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
   
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
        If e.KeyCode = Keys.Enter Then TxtDiscR.Focus()
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
            dta_O.Fill(ds_O, "Define_Driver")
            ds_C.Clear()
            dta_C.Fill(ds_C, "Define_Reciver")
            ds_Car.Clear()
            dta_Car.Fill(ds_Car, "Define_Car")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "RefreshBank")
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

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.RefreshBank()
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.RefreshBank()
    End Sub

    Private Sub TxtDiscR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscR.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSaveCity.Focus()
    End Sub

    Private Sub TxtPlak_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPlak.KeyDown
        If e.KeyCode = Keys.Enter Then ChkWeight.Focus()
    End Sub

    Private Sub TxtDiscD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscD.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSaveOstan.Focus()
    End Sub

    Private Sub ChkSize_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSize.GotFocus
        ChkSize.BackColor = Color.LightGray
    End Sub

    Private Sub ChkSize_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkSize.KeyDown
        If e.KeyCode = Keys.Enter Then Txtwidth.Focus()
    End Sub

    Private Sub ChkSize_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSize.LostFocus
        ChkSize.BackColor = Me.BackColor
    End Sub

    Private Sub Txtwidth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtwidth.KeyDown
        If e.KeyCode = Keys.Enter Then Txthight.Focus()
    End Sub

    Private Sub Txtwidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtwidth.KeyPress
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
            If InStr(Txtwidth.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub Txtwidth_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtwidth.LostFocus
        If BtnAddCar.Enabled = True Then Txtwidth.Text = Math.Round(CDbl(Txtwidth.Text), 2)
    End Sub

    Private Sub Txtwidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtwidth.TextChanged
        Try
            If ChkSize.Checked = False And BtnAddCar.Enabled = False Then
                Txtwidth.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(Txtwidth.Text)) Then
                Txtwidth.Text = 0
                Exit Sub
            End If
            If Not Txtwidth.Text.Trim.Contains(".") Then Txtwidth.Text = CDbl(Txtwidth.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txthight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txthight.KeyDown
        If e.KeyCode = Keys.Enter Then TxtTop.Focus()
    End Sub

    Private Sub Txthight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txthight.KeyPress
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
            If InStr(Txtwidth.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub Txthight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txthight.LostFocus
        If BtnAddCar.Enabled = True Then Txthight.Text = Math.Round(CDbl(Txthight.Text), 2)
    End Sub

    Private Sub Txthight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txthight.TextChanged
        Try
            If ChkSize.Checked = False And BtnAddCar.Enabled = False Then
                Txthight.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(Txthight.Text)) Then
                Txthight.Text = 0
                Exit Sub
            End If
            If Not Txthight.Text.Trim.Contains(".") Then Txthight.Text = CDbl(Txthight.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtTop_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTop.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSaveCar.Focus()
    End Sub

    Private Sub TxtTop_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTop.KeyPress
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
            If InStr(Txtwidth.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtTop_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTop.LostFocus
        If BtnAddCar.Enabled = True Then TxtTop.Text = Math.Round(CDbl(TxtTop.Text), 2)
    End Sub

    Private Sub TxtTop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTop.TextChanged
        Try
            If ChkSize.Checked = False And BtnAddCar.Enabled = False Then
                TxtTop.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtTop.Text)) Then
                TxtTop.Text = 0
                Exit Sub
            End If
            If Not TxtTop.Text.Trim.Contains(".") Then TxtTop.Text = CDbl(TxtTop.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAddCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCar.Click
        disableCar(False)
        Try
            Me.RefreshBank()
            bs_Car.AddNew()
            edt = 0
            TxtWeight.Text = 1
            Txtwidth.Text = 1
            Txthight.Text = 1
            TxtTop.Text = 1
            TxtWeight.Text = 0
            Txtwidth.Text = 0
            Txthight.Text = 0
            TxtTop.Text = 0
            ChkSize.Checked = True
            ChkWeight.Checked = True
            ChkSize.Checked = False
            ChkWeight.Checked = False
            TxtNameCar.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnAddCar_Click")
            disableCar(True)
            RefreshBank()
        End Try
    End Sub

    Private Sub BtnDelCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelCar.Click
        If bs_Car.Count <= 0 Then
            MessageBox.Show("هيچ وسیله حملی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelCar.Enabled = False
            BtnEditCar.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد وسیله حمل جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtNameCar.Text
                bs_Car.RemoveAt(bs_Car.Position)
                dta_Car.Update(ds_Car, "Define_Car")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف وسیله حمل", "حذف", "حذف وسیله حمل :" & nam, "")
                ds_Car.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("وسیله حمل انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnDelCar_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub BtnEditCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCar.Click
        If bs_Car.Count <= 0 Then
            MessageBox.Show("هيچ وسیله حملی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnDelCar.Enabled = False
            BtnEditCar.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disableCar(False)
        edt = 1
        str_name = Trim(TxtNameCar.Text)
    End Sub

    Private Sub BtnCanCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCanCar.Click
        bs_Car.CancelEdit()
        disableCar(True)
        Me.RefreshBank()
        BtnAddCar.Focus()
    End Sub

    Private Sub BtnSaveCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveCar.Click
        Try
            If Trim(TxtNameCar.Text) = "" Then
                MessageBox.Show("نام وسیله را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNameCar.Focus()
                Exit Sub
            End If

            If ChkSize.Checked = True Then
                If CDbl(Txtwidth.Text.Trim) <= 0 Then
                    MessageBox.Show("طول کالا را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txtwidth.Focus()
                    Exit Sub
                End If
                If CDbl(Txthight.Text.Trim) <= 0 Then
                    MessageBox.Show("عرض کالا را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txthight.Focus()
                    Exit Sub
                End If
                If CDbl(TxtTop.Text.Trim) <= 0 Then
                    MessageBox.Show("ارتفاع کالا را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtTop.Focus()
                    Exit Sub
                End If
            Else
                If CDbl(Txtwidth.Text.Trim) <> 0 Then
                    MessageBox.Show("طول کالا را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txtwidth.Focus()
                    Exit Sub
                End If
                If CDbl(Txthight.Text.Trim) <> 0 Then
                    MessageBox.Show("عرض کالا را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txthight.Focus()
                    Exit Sub
                End If
                If CDbl(TxtTop.Text.Trim) <> 0 Then
                    MessageBox.Show("ارتفاع کالا را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtTop.Focus()
                    Exit Sub
                End If
            End If


            If ChkWeight.Checked = True Then
                If CDbl(TxtWeight.Text.Trim) <= 0 Then
                    MessageBox.Show("تناژ قابل حمل را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWeight.Focus()
                    Exit Sub
                End If
            Else
                If CDbl(TxtWeight.Text.Trim) <> 0 Then
                    MessageBox.Show("تناژ قابل حمل را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWeight.Focus()
                    Exit Sub
                End If
            End If


            If edt = 0 Then
                If Not Me.AreYouAddCar(TxtNameCar.Text) Then
                    MessageBox.Show("  نام وسیله مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditCar(TxtNameCar.Text) Then
                    MessageBox.Show("نام وسیله مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = TxtNameCar.Text
            bs_Car.EndEdit()
            dta_Car.Update(ds_Car, "Define_Car")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف وسیله حمل", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت وسیله حمل : " & nam, If(str_name = TxtNameCar.Text, "ویرایش وسیله حمل : " & str_name, "ویرایش وسیله حمل از : " & str_name & " به " & TxtNameCar.Text.Trim)), "")
            DGV1.Refresh()
            DGV1.RefreshEdit()
            ds_Car.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then BtnDelCar.Enabled = True
            disableCar(True)
            BtnAddCar.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("وسیله حمل انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disableCar(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Driver", "BtnSaveCar_Click")
            End If
            RefreshBank()
        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            If DGV1.RowCount < 1000 Then
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            Else
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 50, e.RowBounds.Location.Y)
            End If
        End Using
    End Sub

    Private Sub TxtDiscCar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscCar.KeyDown
        If e.KeyCode = Keys.Enter Then ChkSize.Focus()
    End Sub

    Private Sub TxtNameCar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameCar.KeyDown
        If e.KeyCode = Keys.Enter Then TxtPlak.Focus()
    End Sub

    Private Sub TxtNameCar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameCar.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNameCar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNameCar.LostFocus
        If BtnAddCar.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = TxtNameCar.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        TxtNameCar.Text = str
    End Sub

    Private Sub TxtNameCar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNameCar.TextChanged
        TxtNameCar.Text = TxtNameCar.Text.Replace(",", "")
        TxtNameCar.Text = TxtNameCar.Text.Replace(";", "")
        TxtNameCar.Text = TxtNameCar.Text.Replace("'", "")
    End Sub

    Private Sub TxtWeight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtWeight.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscCar.Focus()
    End Sub

    Private Sub TxtWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWeight.KeyPress
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
            If InStr(Txtwidth.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub


    Private Sub TxtWeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtWeight.LostFocus
        If BtnAddCar.Enabled = True Then TxtWeight.Text = Math.Round(CDbl(TxtWeight.Text), 2)
    End Sub

    Private Sub TxtWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWeight.TextChanged
        Try
            If ChkWeight.Checked = False And BtnAddCar.Enabled = False Then
                TxtWeight.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtWeight.Text)) Then
                TxtWeight.Text = 0
                Exit Sub
            End If
            If Not TxtWeight.Text.Trim.Contains(".") Then TxtWeight.Text = CDbl(TxtWeight.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChkWeight_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkWeight.GotFocus
        ChkWeight.BackColor = Color.LightGray
    End Sub

    Private Sub ChkWeight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkWeight.KeyDown
        If e.KeyCode = Keys.Enter Then TxtWeight.Focus()
    End Sub

    Private Sub ChkWeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkWeight.LostFocus
        ChkWeight.BackColor = Me.BackColor
    End Sub
End Class