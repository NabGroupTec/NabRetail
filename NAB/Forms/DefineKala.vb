Imports System.Data.SqlClient
Public Class DefineKala
    Dim row As Integer
    Dim edt, Id_One, Id_Two As Long
    Dim str_name, str_BarCode As String
    Dim state As Boolean
    Dim ds As New DataSet
    Dim str As String = "select * from Define_Kala"
    Dim dta As New SqlDataAdapter(str, DataSource)
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_O As New DataSet
    Dim str_O As String = "select * From Define_OneGroup"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_T As New DataSet
    Dim str_T As String = "select * From Define_TwoGroup"
    Dim dta_T As New SqlDataAdapter(str_T, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_V As New DataSet
    Dim str_V As String = "select * From Define_Vahed"
    Dim dta_V As New SqlDataAdapter(str_V, DataSource)
    Private Sub Set_One_Two_Group()
        Dim T_str As String = "SELECT Define_Kala.Id, Define_TwoGroup.NamTwo, Define_OneGroup.NamOne,Define_Vahed.Nam FROM Define_Kala INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id AND Define_TwoGroup.IdOne = Define_OneGroup.Id INNER JOIN Define_Vahed ON Define_Vahed.id=Define_Kala.IdVahed" 'WHERE Define_Kala.Activ ='False'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Kala")
        If T_ds.Tables("Define_Kala").Rows.Count <= 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To ds.Tables("Define_Kala").Rows.Count - 1
            Dim dr() As DataRow = T_ds.Tables(0).Select("Id=" & ds.Tables("Define_Kala").Rows(i).Item("ID"))
            If dr.Length > 0 Then
                ds.Tables("Define_Kala").Rows(i).Item("OneGroup") = dr(0).Item("NamOne")
                ds.Tables("Define_Kala").Rows(i).Item("TwoGroup") = dr(0).Item("NamTwo")
                ds.Tables("Define_Kala").Rows(i).Item("Vahed") = dr(0).Item("Nam")
            End If
        Next
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
            dta.Fill(ds, "Define_Kala")
            ds.Tables("Define_Kala").Columns.Add("OneGroup", System.Type.GetType("System.String"))
            ds.Tables("Define_Kala").Columns.Add("TwoGroup", System.Type.GetType("System.String"))
            ds.Tables("Define_Kala").Columns.Add("Vahed", System.Type.GetType("System.String"))
            Me.Set_One_Two_Group()
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds.Tables("Define_Kala").Columns("ID")
            ds.Tables("Define_Kala").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_Kala"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_One()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            dta_O = New SqlDataAdapter(str_O, DataSource)
            dta_O.Fill(ds_O, "Define_OneGroup")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "Fill_One")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_two()
        Try
            ds_T.Clear()
            If Not dta_T Is Nothing Then
                dta_T.Dispose()
            End If
            dta_T = New SqlDataAdapter(str_T, DataSource)
            dta_T.Fill(ds_T, "Define_TwoGroup")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "Fill_two")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_Vahed()
        Try
            ds_V.Clear()
            If Not dta_V Is Nothing Then
                dta_V.Dispose()
            End If
            dta_V = New SqlDataAdapter(str_V, DataSource)
            dta_V.Fill(ds_V, "Define_Vahed")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "Fill_Vahed")
            Me.Close()
        End Try
    End Sub
    Private Sub FillOne()
        CmbOne.Items.Clear()
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbOne.Items.Add(ds_O.Tables(0).Rows(i).Item("NamOne"))
        Next
    End Sub
    Private Sub FillVahed()
        CmbVahed.Items.Clear()
        For i As Integer = 0 To ds_V.Tables(0).Rows.Count - 1
            CmbVahed.Items.Add(ds_V.Tables(0).Rows(i).Item("Nam"))
        Next
    End Sub
    Private Sub FillTwo(ByVal idO As Long)
        CmbTwo.Items.Clear()
        CmbTwo.Text = ""
        For i As Integer = 0 To ds_T.Tables(0).Rows.Count - 1
            If ds_T.Tables(0).Rows(i).Item("IdOne") = idO Then
                CmbTwo.Items.Add(ds_T.Tables(0).Rows(i).Item("NamTwo"))
            End If
        Next
    End Sub
    Private Sub RefreshBank()
        Try
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_OneGroup")
            ds_T.Clear()
            dta_T.Fill(ds_T, "Define_TwoGroup")
            ds_V.Clear()
            dta_V.Fill(ds_V, "Define_Vahed")
            ds.Clear()
            dta.Fill(ds, "Define_Kala")
            Me.FillOne()
            Me.FillVahed()
            Me.Set_One_Two_Group()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "RefreshBank")
            Me.Close()
        End Try
    End Sub
    Private Sub Set_Txtbind()
        TxtId.DataBindings.Add("text", bs, ".Id", True, DataSourceUpdateMode.OnValidation)
        TxtOne.DataBindings.Add("text", bs, ".IdCodeOne", True, DataSourceUpdateMode.OnValidation)
        TxtTwo.DataBindings.Add("text", bs, ".IdCodeTwo", True, DataSourceUpdateMode.OnValidation)
        TxtVahed.DataBindings.Add("text", bs, ".IdVahed", True, DataSourceUpdateMode.OnValidation)
        TxtName.DataBindings.Add("text", bs, ".Nam", True, DataSourceUpdateMode.OnValidation)
        TxtDate.DataBindings.Add("text", bs, ".Ex_date", True, DataSourceUpdateMode.OnValidation)
        TxtBarCode.DataBindings.Add("text", bs, ".BarCode", True, DataSourceUpdateMode.OnValidation)
        ChkTwoKala.DataBindings.Add("CheckState", bs, ".DK", True, DataSourceUpdateMode.OnValidation)
        TxtKol.DataBindings.Add("text", bs, ".DK_KOL", True, DataSourceUpdateMode.OnValidation)
        TxtJoz.DataBindings.Add("text", bs, ".DK_JOZ", True, DataSourceUpdateMode.OnValidation)
        ChkWKala.DataBindings.Add("CheckState", bs, ".WK", True, DataSourceUpdateMode.OnValidation)
        TxtWKol.DataBindings.Add("text", bs, ".WK_KOL", True, DataSourceUpdateMode.OnValidation)
        TxtWJoz.DataBindings.Add("text", bs, ".WK_JOZ", True, DataSourceUpdateMode.OnValidation)
        ChkLowF.DataBindings.Add("CheckState", bs, ".LF", True, DataSourceUpdateMode.OnValidation)
        TxtLowF.DataBindings.Add("text", bs, ".LF_Value", True, DataSourceUpdateMode.OnValidation)
        ChkHighF.DataBindings.Add("CheckState", bs, ".HF", True, DataSourceUpdateMode.OnValidation)
        TxtHighF.DataBindings.Add("text", bs, ".HF_Value", True, DataSourceUpdateMode.OnValidation)
        ChkActive.DataBindings.Add("CheckState", bs, ".Activ", True, DataSourceUpdateMode.OnValidation)
        CmbOne.DataBindings.Add("text", bs, ".OneGroup", True, DataSourceUpdateMode.OnValidation)
        CmbTwo.DataBindings.Add("text", bs, ".TwoGroup", True, DataSourceUpdateMode.OnValidation)
        CmbVahed.DataBindings.Add("text", bs, ".Vahed", True, DataSourceUpdateMode.OnValidation)
        ChkSize.DataBindings.Add("CheckState", bs, ".Size", True, DataSourceUpdateMode.OnValidation)
        Txtwidth.DataBindings.Add("text", bs, ".WidthKala", True, DataSourceUpdateMode.OnValidation)
        Txthight.DataBindings.Add("text", bs, ".HightKala", True, DataSourceUpdateMode.OnValidation)
        TxtTop.DataBindings.Add("text", bs, ".TopKala", True, DataSourceUpdateMode.OnValidation)
        ChkCashing.DataBindings.Add("CheckState", bs, ".Cashing", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub disable(ByVal flag As Boolean)
        TxtName.ReadOnly = flag
        TxtBarCode.ReadOnly = flag
        TxtDate.ReadOnly = flag
        TxtKol.ReadOnly = flag
        TxtJoz.ReadOnly = flag
        TxtWKol.ReadOnly = flag
        TxtWJoz.ReadOnly = flag
        TxtLowF.ReadOnly = flag
        TxtHighF.ReadOnly = flag
        Txthight.ReadOnly = flag
        TxtTop.ReadOnly = flag
        Txtwidth.ReadOnly = flag
        DGV.Enabled = flag
        TxtS.Enabled = flag
        BN.Enabled = flag
        BtnOne.Enabled = Not flag
        BtnTwo.Enabled = Not flag
        BtnVahed.Enabled = Not flag
        CmbOne.Enabled = Not flag
        CmbTwo.Enabled = Not flag
        CmbVahed.Enabled = Not flag
        ChkLowF.Enabled = Not flag
        ChkHighF.Enabled = Not flag
        ChkTwoKala.Enabled = Not flag
        ChkActive.Enabled = Not flag
        ChkWKala.Enabled = Not flag
        ChkSize.Enabled = Not flag
        ChkCashing.Enabled = Not flag
        cmdsave.Enabled = Not flag
        cmdcan.Enabled = Not flag
        cmdadd.Enabled = flag
        If Fnew = False Then
            cmdedit.Enabled = flag
            cmddel.Enabled = flag
        Else
            cmdedit.Enabled = False
            cmddel.Enabled = False
        End If
        SetButton()
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
    Private Function GetIdVahed(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_V.Tables(0).Select("Nam ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("Id")
        Else
            Return -1
        End If
    End Function
    Private Function GetIdTwo(ByVal Nam As String, ByVal idO As String) As Long
        Dim dr() As DataRow
        dr = ds_T.Tables(0).Select("NamTwo ='" & Nam & "' AND IdOne=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("ID")
        Else
            Return -1
        End If
    End Function

    Private Sub TxtDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDown
        If e.KeyCode = Keys.Enter Then TxtBarCode.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtKol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKol.KeyDown
        If e.KeyCode = Keys.Enter Then TxtJoz.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtKol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKol.KeyPress
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

    Private Sub TxtKol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKol.TextChanged
        If ChkTwoKala.Checked = False And cmdadd.Enabled = False Then
            TxtKol.Text = 0
            Exit Sub
        End If
        If Not (CheckDigit(Format$(TxtKol.Text.Replace(",", "")))) Then
            TxtKol.Text = "0"
            Exit Sub
        End If
        TxtKol.Text = CDbl(TxtKol.Text)
    End Sub

    Private Sub TxtWKol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtWKol.KeyDown
        If e.KeyCode = Keys.Enter Then TxtWJoz.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtWKol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWKol.KeyPress
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
            If InStr(TxtWKol.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtWJoz_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtWJoz.KeyDown
        If e.KeyCode = Keys.Enter Then ChkLowF.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtWJoz_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWJoz.KeyPress
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
            If InStr(TxtWJoz.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtLowF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLowF.KeyDown
        If e.KeyCode = Keys.Enter Then ChkHighF.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtLowF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLowF.KeyPress
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
            If InStr(TxtLowF.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtHighF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHighF.KeyDown
        If e.KeyCode = Keys.Enter Then ChkSize.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtHighF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHighF.KeyPress
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
            If InStr(TxtHighF.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtJoz_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJoz.KeyDown
        If e.KeyCode = Keys.Enter Then ChkWKala.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtJoz_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtJoz.KeyPress
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
            If InStr(TxtWJoz.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtJoz_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtJoz.LostFocus
        TxtJoz.Text = Math.Round(CDbl(TxtJoz.Text), 3)
    End Sub

    Private Sub TxtJoz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtJoz.TextChanged
        Try
            If ChkTwoKala.Checked = False And cmdadd.Enabled = False Then
                TxtJoz.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtJoz.Text)) Then
                TxtJoz.Text = 0
                Exit Sub
            End If
            If Not TxtJoz.Text.Trim.Contains(".") Then TxtJoz.Text = CDbl(TxtJoz.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DefineKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DefineKala_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F13")
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
        Me.Fill_One()
        Me.Fill_two()
        Me.Fill_Vahed()
        Me.fill_dgv()
        Me.Set_Txtbind()
        Me.FillOne()
        Me.FillVahed()
        disable(True)
        DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If DGV.RowCount > 0 Then
            DGV.Rows(0).Selected = False
            DGV.Rows(0).Selected = True
        End If
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F13")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOne.KeyDown
        If CmbOne.DroppedDown = False Then
            CmbOne.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbTwo.Focus()
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbOne_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOne.LostFocus
        If cmdadd.Enabled = False Then
            TxtOne.Text = GetIdOne(CmbOne.Text)
            CmbTwo.Items.Clear()
            For i As Integer = 0 To ds_T.Tables(0).Rows.Count - 1
                If ds_T.Tables(0).Rows(i).Item("IdOne") = CLng(TxtOne.Text) Then
                    CmbTwo.Items.Add(ds_T.Tables(0).Rows(i).Item("NamTwo"))
                End If
            Next
            If CmbTwo.FindStringExact(CmbTwo.Text) = -1 Then CmbTwo.Text = ""
        End If
    End Sub

    Private Sub CmbOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOne.SelectedIndexChanged
        TxtOne.Text = GetIdOne(CmbOne.Text)
        Me.FillTwo(If(String.IsNullOrEmpty(TxtOne.Text), 0, CLng(TxtOne.Text)))
    End Sub

    Private Sub CmbTwo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTwo.KeyDown
        If CmbTwo.DroppedDown = False Then
            CmbTwo.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbVahed.Focus()
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbTwo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTwo.LostFocus
        If cmdadd.Enabled = False Then
            If CmbTwo.FindStringExact(CmbTwo.Text) = -1 Then CmbTwo.Text = ""
            TxtTwo.Text = GetIdTwo(CmbTwo.Text, If(String.IsNullOrEmpty(TxtOne.Text), 0, CLng(TxtOne.Text)))
        End If
    End Sub

    Private Sub CmbTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTwo.SelectedIndexChanged
        TxtTwo.Text = GetIdTwo(CmbTwo.Text, If(String.IsNullOrEmpty(TxtOne.Text), 0, CLng(TxtOne.Text)))
    End Sub

    Private Sub CmbVahed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbVahed.KeyDown
        If CmbVahed.DroppedDown = False Then
            CmbVahed.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtName.Focus()
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbVahed_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbVahed.LostFocus
        If cmdadd.Enabled = False Then
            TxtVahed.Text = GetIdVahed(CmbVahed.Text)
        End If
    End Sub

    Private Sub CmbVahed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbVahed.SelectedIndexChanged
        TxtVahed.Text = GetIdVahed(CmbVahed.Text)
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        disable(False)
        Try
            RefreshBank()
            bs.AddNew()
            edt = 0
            '''''''''''''''''''''''''''''''''
            TxtDate.Text = 1
            TxtKol.Text = 1
            TxtJoz.Text = 1
            TxtWKol.Text = 1
            TxtWJoz.Text = 1
            TxtLowF.Text = 1
            TxtHighF.Text = 1
            Txtwidth.Text = 1
            Txthight.Text = 1
            TxtTop.Text = 1
            '''''''''''''''''''''''''''''''''
            TxtDate.Text = ""
            TxtKol.Text = 0
            TxtJoz.Text = 0
            TxtWKol.Text = 0
            TxtWJoz.Text = 0
            TxtLowF.Text = 0
            TxtHighF.Text = 0
            Txtwidth.Text = 0
            Txthight.Text = 0
            TxtTop.Text = 0
            '''''''''''''''''''''''''''''''''
            TxtBarCode.Text = ""
            '''''''''''''''''''''''''''''''''
            ChkTwoKala.Checked = True
            ChkWKala.Checked = True
            ChkLowF.Checked = True
            ChkHighF.Checked = True
            ChkActive.Checked = True
            ChkSize.Checked = True
            ChkCashing.Checked = True
            '''''''''''''''''''''''''''''''''
            ChkTwoKala.Checked = False
            ChkWKala.Checked = False
            ChkLowF.Checked = False
            ChkHighF.Checked = False
            ChkActive.Checked = False
            ChkSize.Checked = False
            ChkCashing.Checked = False
            '''''''''''''''''''''''''''''''''
            TxtOne.Text = GetIdOne(CmbOne.Text.Trim)
            TxtTwo.Text = GetIdTwo(CmbTwo.Text.Trim, If(String.IsNullOrEmpty(TxtOne.Text.Trim), 0, CLng(TxtOne.Text.Trim)))
            TxtVahed.Text = GetIdVahed(CmbVahed.Text.Trim)
            CmbOne.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "cmdadd_Click")
            disable(True)
            RefreshBank()
        End Try
    End Sub

    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        Try
            bs.CancelEdit()
            disable(True)
            RefreshBank()
            cmdadd.Focus()
            If row <= DGV.RowCount - 1 Then DGV.Item("Cln_One", row).Selected = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "cmdcan_Click")
            RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ کالایی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            RefreshBank()
            Exit Sub
        End If
        disable(False)
        edt = 1
        str_name = Trim(TxtName.Text)
        Id_One = Trim(TxtOne.Text)
        Id_Two = Trim(TxtTwo.Text)
        str_BarCode = Trim(TxtBarCode.Text)
        state = ChkTwoKala.Checked
        If Me.GetKindKala(CLng(TxtId.Text)) <> 0 Then
            ChkTwoKala.Enabled = False
            TxtKol.ReadOnly = True
            TxtJoz.ReadOnly = True
        End If
        row = DGV.CurrentRow.Index
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ کالایی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد کالای جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = TxtName.Text
                bs.RemoveAt(bs.Position)
                dta.Update(ds, "Define_Kala")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف کالا", "حذف", "حذف کالا :" & nam, "")
                ds.AcceptChanges()
                RefreshBank()
                If row <= DGV.RowCount - 1 Then DGV.Item("Cln_One", row).Selected = True
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("کالای انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "cmddel_Click")
                End If
                RefreshBank()
                If row <= DGV.RowCount - 1 Then DGV.Item("Cln_One", row).Selected = True
            End Try
        End If
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            TxtVahed.Text = GetIdVahed(CmbVahed.Text)
            TxtOne.Text = GetIdOne(CmbOne.Text)
            TxtTwo.Text = GetIdTwo(CmbTwo.Text, If(String.IsNullOrEmpty(TxtOne.Text), 0, CLng(TxtOne.Text)))
            If Trim(TxtName.Text.Trim) = "" Then
                MessageBox.Show("نام کالا را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtName.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtOne.Text.Trim) Or CmbOne.Text = "" Or CmbOne.FindStringExact(CmbOne.Text) = -1 Then
                MessageBox.Show(" گروه اصلی را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOne.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtTwo.Text.Trim) Or CmbTwo.Text = "" Or CmbTwo.FindStringExact(CmbTwo.Text) = -1 Then
                MessageBox.Show("گروه فرعی را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbTwo.Focus()
                Exit Sub
            End If

            If TxtOne.Text = "-1" Then
                MessageBox.Show("گروه اصلی را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOne.Focus()
                Exit Sub
            End If
            If TxtTwo.Text = "-1" Then
                MessageBox.Show("گروه فرعی را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbTwo.Focus()
                Exit Sub
            End If
            If TxtVahed.Text = "-1" Then
                MessageBox.Show("واحد را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbVahed.Focus()
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''
            If ChkTwoKala.Checked = True Then
                If CDbl(TxtJoz.Text.Trim) = 0 Then
                    MessageBox.Show("نسبت جزء را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtJoz.Focus()
                    Exit Sub
                End If
                If CDbl(TxtKol.Text.Trim) = 0 Then
                    MessageBox.Show("نسبت کل را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtKol.Focus()
                    Exit Sub
                End If
                'If CDbl(TxtJoz.Text.Trim) < CDbl(TxtKol.Text.Trim) Then
                'MessageBox.Show("نسبت جزء کوچکتر از نسبت کل است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'TxtJoz.Focus()
                'Exit Sub
                'End If
            Else
                If CDbl(TxtJoz.Text.Trim) <> 0 Then
                    MessageBox.Show("نسبت جزء را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtJoz.Focus()
                    Exit Sub
                End If
                If CDbl(TxtKol.Text.Trim) <> 0 Then
                    MessageBox.Show("نسبت کل را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtKol.Focus()
                    Exit Sub
                End If
            End If
            ''''''''''''''''''''''''''''''
            If ChkWKala.Checked = True Then
                If CDbl(TxtWJoz.Text.Trim) = 0 Then
                    MessageBox.Show("وزن جزء را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWJoz.Focus()
                    Exit Sub
                End If
                If CDbl(TxtWKol.Text.Trim) = 0 Then
                    MessageBox.Show("وزن کل را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWKol.Focus()
                    Exit Sub
                End If
                If CDbl(TxtWJoz.Text.Trim) > CDbl(TxtWKol.Text.Trim) Then
                    MessageBox.Show("وزن کل کوچکتر از وزن جزء است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWKol.Focus()
                    Exit Sub
                End If
            Else
                If CDbl(TxtWJoz.Text.Trim) <> 0 Then
                    MessageBox.Show("وزن جزء را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWJoz.Focus()
                    Exit Sub
                End If
                If CDbl(TxtWKol.Text.Trim) <> 0 Then
                    MessageBox.Show("وزن کل را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TxtWKol.Focus()
                    Exit Sub
                End If
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

            If edt = 0 Then
                If Not Me.AreYouAddKala(TxtName.Text, CLng(TxtTwo.Text), CLng(TxtOne.Text)) Then
                    MessageBox.Show("  نام کالای مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not String.IsNullOrEmpty(TxtBarCode.Text.Trim) Then
                    If Not Me.AreYouAddBarCode(TxtBarCode.Text) Then
                        MessageBox.Show("  بار کد مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If ChkTwoKala.Enabled = True Then
                    If Me.GetKindKala(CLng(TxtId.Text)) <> 0 Then
                        ChkTwoKala.Checked = state
                        ChkTwoKala.Enabled = False
                    End If
                End If
                If Not Me.AreYouEditKala(TxtName.Text, CLng(TxtTwo.Text), CLng(TxtOne.Text)) Then
                    MessageBox.Show("نام کالای مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not String.IsNullOrEmpty(TxtBarCode.Text.Trim) Then
                    If Not Me.AreYouEditBarCode(TxtBarCode.Text) Then
                        MessageBox.Show("بار کد مورد نظر تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim nam As String = TxtName.Text
            bs.EndEdit()
            dta.Update(ds, "Define_Kala")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف کالا", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت کالا : " & nam, If(str_name = TxtName.Text, "ویرایش کالا : " & str_name, "ویرایش کالا از : " & str_name & " به " & TxtName.Text.Trim)), "")
            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then cmddel.Enabled = True
            disable(True)
            cmdadd.Focus()
            If row <= DGV.RowCount - 1 Then DGV.Item("Cln_One", row).Selected = True
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("گروه اصلی یا فرعی یا واحد انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disable(True)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "cmdsave_Click")
            End If
            RefreshBank()
        End Try
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtBarCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBarCode.GotFocus
        'Try
        '    Dim myCulture As New Globalization.CultureInfo("en-us")
        '    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub TxtBarCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBarCode.KeyDown
        If e.KeyCode = Keys.Enter Then ChkTwoKala.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkTwoKala_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTwoKala.GotFocus
        ChkTwoKala.BackColor = Color.LightGray
    End Sub

    Private Sub ChkTwoKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkTwoKala.KeyDown
        If e.KeyCode = Keys.Enter Then TxtKol.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkWKala_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkWKala.GotFocus
        ChkWKala.BackColor = Color.LightGray
    End Sub

    Private Sub ChkWKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkWKala.KeyDown
        If e.KeyCode = Keys.Enter Then TxtWKol.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkLowF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLowF.GotFocus
        ChkLowF.BackColor = Color.LightGray
    End Sub

    Private Sub ChkLowF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkLowF.KeyDown
        If e.KeyCode = Keys.Enter Then TxtLowF.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkHighF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkHighF.GotFocus
        ChkHighF.BackColor = Color.LightGray
    End Sub

    Private Sub ChkHighF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkHighF.KeyDown
        If e.KeyCode = Keys.Enter Then TxtHighF.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkTwoKala_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTwoKala.LostFocus
        ChkTwoKala.BackColor = Me.BackColor
    End Sub

    Private Sub ChkWKala_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkWKala.LostFocus
        ChkWKala.BackColor = Me.BackColor
    End Sub

    Private Sub ChkLowF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLowF.LostFocus
        ChkLowF.BackColor = Me.BackColor
    End Sub

    Private Sub ChkHighF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkHighF.LostFocus
        ChkHighF.BackColor = Me.BackColor
    End Sub

    Private Sub TxtBarCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBarCode.LostFocus
        'Try
        '    Dim myCulture As New Globalization.CultureInfo("fa-IR")
        '    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.RefreshBank()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.RefreshBank()
    End Sub
    Private Function AreYouAddKala(ByVal nam As String, ByVal IdTwo As Long, ByVal IdOne As Long) As Boolean
        Dim T_str As String = "select Nam,IdCodeOne,IdCodeTwo  from Define_Kala WHERE Nam=N'" & nam & "' AND IdCodeOne=" & IdOne & "AND IdCodeTwo=" & IdTwo
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Kala")
        If T_ds.Tables("Define_Kala").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouAddBarCode(ByVal BarNam As String) As Boolean
        Dim T_str As String = "select BarCode  from Define_Kala WHERE BarCode=N'" & BarNam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Kala")
        If T_ds.Tables("Define_Kala").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditBarCode(ByVal BarNam As String) As Boolean
        Dim T_str As String = "select BarCode  from Define_Kala WHERE BarCode=N'" & BarNam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Kala")
        If T_ds.Tables("Define_Kala").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Kala").Rows(0).Item("BarCode") <> TxtBarCode.Text.Trim) Or (T_ds.Tables("Define_Kala").Rows(0).Item("BarCode") = str_BarCode) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Function AreYouEditKala(ByVal nam As String, ByVal idTwo As Long, ByVal idOne As Long) As Boolean
        Dim T_str As String = "select Nam,IdCodeOne,IdCodeTwo  from Define_Kala WHERE Nam=N'" & nam & "' AND IdCodeOne=" & idOne & "AND IdCodeTwo=" & idTwo
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Kala")
        If T_ds.Tables("Define_Kala").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Kala").Rows(0).Item("Nam") <> TxtName.Text.Trim) Or (T_ds.Tables("Define_Kala").Rows(0).Item("Nam") = str_name) And ((T_ds.Tables("Define_Kala").Rows(0).Item("IdCodeOne") <> TxtOne.Text.Trim) Or (T_ds.Tables("Define_Kala").Rows(0).Item("IdCodeOne") = Id_One)) And ((T_ds.Tables("Define_Kala").Rows(0).Item("IdCodeTwo") <> TxtTwo.Text.Trim) Or (T_ds.Tables("Define_Kala").Rows(0).Item("IdCodeTwo") = Id_Two)) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub TxtTwo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTwo.TextChanged
        Try
            If cmdadd.Enabled = True Then
                CmbOne.Text = Me.GetNamOne(TxtOne.Text)
                CmbTwo.Text = Me.GetNamTwo(TxtTwo.Text)
            End If
        Catch ex As Exception
            CmbOne.Text = ""
            CmbTwo.Text = ""
        End Try
    End Sub
    Private Function GetNamOne(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("Id =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamOne")
        Else
            Return ""
        End If
    End Function
    Private Function GetNamTwo(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_T.Tables(0).Select("Id =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamTwo")
        Else
            Return ""
        End If
    End Function
    Private Function GetNamVahed(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_V.Tables(0).Select("Id =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("Nam")
        Else
            Return ""
        End If
    End Function

    Private Sub TxtVahed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVahed.TextChanged
        Try
            If cmdadd.Enabled = True Then
                CmbVahed.Text = Me.GetNamVahed(TxtVahed.Text)
            End If
        Catch ex As Exception
            CmbVahed.Text = ""
        End Try
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
        Me.GetKey(e)
    End Sub

    Private Sub TxtS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewKala.Enabled = False
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
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Define_kala.htm")
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

    Private Sub BN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN.KeyDown
        Me.GetKey(e)
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

    Private Sub ChkActive_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkActive.GotFocus
        ChkActive.BackColor = Color.LightGray
    End Sub

    Private Sub ChkActive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkActive.KeyDown
        If e.KeyCode = Keys.Enter Then cmdsave.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkActive_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkActive.LostFocus
        ChkActive.BackColor = Me.BackColor
    End Sub

    Private Sub BtnOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOne.Click
        Try
            Fnew = True
            Using FrmGroup As New DefineGroup
                FrmGroup.ShowDialog()
            End Using
            Me.Fill_One()
            Me.Fill_two()
            Me.FillOne()
            Fnew = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Kala", "BtnOne_Click")
        End Try
    End Sub

    Private Sub BtnOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOne.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTwo.Click
        Try
            Fnew = True
            Using FrmGroup As New DefineGroup
                FrmGroup.ShowDialog()
            End Using
            Me.Fill_One()
            Me.Fill_two()
            Me.FillOne()
            Fnew = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Kala", "BtnTwo_Click")
        End Try
    End Sub

    Private Sub BtnTwo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnTwo.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnVahed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVahed.Click
        Try
            Fnew = True
            Using FrmVahed As New DefineDefine_Vahed
                FrmVahed.ShowDialog()
            End Using
            Me.Fill_Vahed()
            Me.FillVahed()
            Fnew = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_Kala", "BtnVahed_Click")
        End Try
    End Sub

    Private Sub BtnVahed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnVahed.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub TxtWKol_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtWKol.LostFocus
        TxtWKol.Text = Math.Round(CDbl(TxtWKol.Text), 3)
    End Sub

    Private Sub TxtWJoz_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtWJoz.LostFocus
        TxtWJoz.Text = Math.Round(CDbl(TxtWJoz.Text), 3)
    End Sub
    Public Function GetKindKala(ByVal Id As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT SUM(AllData.idk) As Idk FROM (SELECT  Count(IdKala) As IdK FROM  Define_PrimaryKala WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  KalaFactorBackBuy WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  KalaFactorBackSell WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  KalaFactorBuy WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  KalaFactorDamage WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  KalaFactorSell WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  Tranlate_Anbar WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  ListKala_Discount WHERE IdKala =" & Id & " UNION ALL SELECT  Count(IdKala) As IdK FROM  Kala_Discount WHERE IdKala =" & Id & ") As AllData", ConectionBank)
                Dim str As Long = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineKala", "GetKindKala")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Private Sub ChkSize_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSize.GotFocus
        ChkSize.BackColor = Color.LightGray
    End Sub

    Private Sub ChkSize_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkSize.KeyDown
        If e.KeyCode = Keys.Enter Then Txtwidth.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Txtwidth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtwidth.KeyDown
        If e.KeyCode = Keys.Enter Then Txthight.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Txthight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txthight.KeyDown
        If e.KeyCode = Keys.Enter Then TxtTop.Focus()
        Me.GetKey(e)
    End Sub
    Private Sub TxtTop_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTop.KeyDown
        If e.KeyCode = Keys.Enter Then ChkCashing.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkCashing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCashing.GotFocus
        ChkCashing.BackColor = Color.LightGray
    End Sub

    Private Sub ChkCashing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkCashing.KeyDown
        If e.KeyCode = Keys.Enter Then ChkActive.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub ChkSize_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSize.LostFocus
        ChkSize.BackColor = Me.BackColor
    End Sub

    Private Sub ChkCashing_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCashing.LostFocus
        ChkCashing.BackColor = Me.BackColor
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
        Txtwidth.Text = Math.Round(CDbl(Txtwidth.Text), 3)
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
            If InStr(Txthight.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub Txthight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txthight.LostFocus
        Txthight.Text = Math.Round(CDbl(Txthight.Text), 3)
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
            If InStr(TxtTop.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtTop_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTop.LostFocus
        TxtTop.Text = Math.Round(CDbl(TxtTop.Text), 3)
    End Sub

    Private Sub TxtWKol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWKol.TextChanged
        Try
            If ChkWKala.Checked = False And cmdadd.Enabled = False Then
                TxtWKol.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtWKol.Text)) Then
                TxtWKol.Text = 0
                Exit Sub
            End If
            If Not TxtWKol.Text.Trim.Contains(".") Then TxtWKol.Text = CDbl(TxtWKol.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtWJoz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWJoz.TextChanged
        Try
            If ChkWKala.Checked = False And cmdadd.Enabled = False Then
                TxtWJoz.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtWJoz.Text)) Then
                TxtWJoz.Text = 0
                Exit Sub
            End If
            If Not TxtWJoz.Text.Trim.Contains(".") Then TxtWJoz.Text = CDbl(TxtWJoz.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txtwidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtwidth.TextChanged
        Try
            If ChkSize.Checked = False And cmdadd.Enabled = False Then
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

    Private Sub Txthight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txthight.TextChanged
        Try
            If ChkSize.Checked = False And cmdadd.Enabled = False Then
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

    Private Sub TxtTop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTop.TextChanged
        Try
            If ChkSize.Checked = False And cmdadd.Enabled = False Then
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

    Private Sub TxtLowF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLowF.LostFocus
        TxtLowF.Text = Math.Round(CDbl(TxtLowF.Text), 3)
    End Sub

    Private Sub TxtLowF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLowF.TextChanged
        Try
            If ChkLowF.Checked = False And cmdadd.Enabled = False Then
                TxtLowF.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtLowF.Text)) Then
                TxtLowF.Text = 0
                Exit Sub
            End If
            If Not TxtLowF.Text.Trim.Contains(".") Then TxtLowF.Text = CDbl(TxtLowF.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtHighF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHighF.LostFocus
        TxtHighF.Text = Math.Round(CDbl(TxtHighF.Text), 3)
    End Sub

    Private Sub TxtHighF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHighF.TextChanged
        Try
            If ChkHighF.Checked = False And cmdadd.Enabled = False Then
                TxtHighF.Text = 0
                Exit Sub
            End If
            If Not (CheckDigit(TxtHighF.Text)) Then
                TxtHighF.Text = 0
                Exit Sub
            End If
            If Not TxtHighF.Text.Trim.Contains(".") Then TxtHighF.Text = CDbl(TxtHighF.Text)
        Catch ex As Exception
        End Try
    End Sub
End Class