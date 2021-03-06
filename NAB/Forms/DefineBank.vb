Imports System.Data.SqlClient
Public Class DefineBank
    Dim edt As Integer
    Dim str_name, str_fam, str_state As String
    Dim ds As New DataSet
    Dim str As String = "select * from Define_Bank "
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then Txtnam.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtshobeh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtshobeh.KeyDown
        If e.KeyCode = Keys.Enter Then Txtnumber.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Txtnumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtnumber.KeyDown
        If e.KeyCode = Keys.Enter Then Txttell.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub Txttell_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txttell.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txtallmoney.Visible = True Then
                Txtallmoney.Focus()
            Else
                CmbState.Focus()
            End If
        End If
        Me.GetKey(e)
    End Sub

    Private Sub Define_Bank_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cmdadd.Focus()
    End Sub

    Private Sub Bank_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdsave.Enabled = True Or cmdcan.Enabled = True Then
            bs.CancelEdit()
            disable(True)
        End If
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
    End Sub

    Private Sub Define_Bank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub Bank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F35")
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
        disable(True)
        SetButton()
        ''''''''''''''''''''''''''
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F35")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub set_txtbind()
        Txtname.DataBindings.Add("text", bs, ".n_bank", True, DataSourceUpdateMode.OnValidation)
        Txtshobeh.DataBindings.Add("text", bs, ".shobeh", True, DataSourceUpdateMode.OnValidation)
        Txtadd.DataBindings.Add("text", bs, ".address", True, DataSourceUpdateMode.OnValidation)
        Txttell.DataBindings.Add("text", bs, ".tell", True, DataSourceUpdateMode.OnValidation)
        Txtnumber.DataBindings.Add("text", bs, ".number_n", True, DataSourceUpdateMode.OnValidation)
        Txtnam.DataBindings.Add("text", bs, ".nam", True, DataSourceUpdateMode.OnValidation)
        Txtallmoney.DataBindings.Add("text", bs, ".AllMoney", True, DataSourceUpdateMode.OnValidation)
        CmbState.DataBindings.Add("text", bs, ".State", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub fill_dgv()

        Try

            '''''''''''''''''''''''''''
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            dta = New SqlDataAdapter(str, ConectionBank)
            Dim ocb As New SqlCommandBuilder(dta)
            dta.UpdateCommand = ocb.GetUpdateCommand
            dta.InsertCommand = ocb.GetInsertCommand
            dta.DeleteCommand = ocb.GetDeleteCommand
            ds.EnforceConstraints = False
            dta.Fill(ds, "Define_Bank")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds.Tables("Define_Bank").Columns("ID")
            ds.Tables("Define_Bank").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_Bank"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "fill_dgv")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub disable(ByVal flag As Boolean)
        CmbState.Enabled = Not flag
        Txtname.ReadOnly = flag
        Txtshobeh.ReadOnly = flag
        Txtadd.ReadOnly = flag
        Txttell.ReadOnly = flag
        Txtnam.ReadOnly = flag
        Txtnumber.ReadOnly = flag
        Txtallmoney.ReadOnly = flag
        BN.Enabled = flag
        cmdsave.Enabled = Not flag
        cmdcan.Enabled = Not flag
        DGV.Enabled = flag
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
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ بانكي براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد بانكي جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = Txtname.Text
                bs.RemoveAt(bs.Position)
                dta.Update(ds, "Define_Bank")
                Me.TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف بانک", "حذف", "حذف بانک :" & nam, "")
                ds.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("بانک انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "cmddel_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub
    Private Function DelChk(ByVal idbank As Long) As Boolean
        Try
            Dim StrSelect As String = ""
            Dim Cmddel As SqlClient.SqlCommand
            StrSelect = "DELETE  FROM Define_Chk WHERE Id=" & idbank
            Cmddel = New SqlClient.SqlCommand(StrSelect, ConectionBank)
            ConectionBank.Open()
            Cmddel.ExecuteNonQuery()
            ConectionBank.Close()
            Return True
        Catch ex As Exception
            ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        bs.CancelEdit()
        Me.RefreshBank()
        disable(True)
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        disable(False)
        Try
            Me.RefreshBank()
            bs.AddNew()
            edt = 0
            Txtname.Focus()
            CmbState.Text = ""
            CmbState.Text = CmbState.Items(0).ToString
            Txtallmoney.Text = 1
            Txtallmoney.Text = 0
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "cmdadd_Click")
            disable(True)
            Me.RefreshBank()
        End Try

    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            If Trim(Txtname.Text) = "" Then
                MessageBox.Show("نام بانك را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtname.Focus()
                Exit Sub
            End If
            If Trim(Txtnam.Text) = "" Then
                MessageBox.Show("نام صاحب حساب را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtnam.Focus()
                Exit Sub
            End If
            If Trim(Txtshobeh.Text) = "" Then
                MessageBox.Show("كد شعبه را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtshobeh.Focus()
                Exit Sub
            End If
            If Trim(Txtnumber.Text) = "" Then
                MessageBox.Show("شماره حساب را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtnumber.Focus()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            If Trim(Txtallmoney.Text) = "" Then Txtallmoney.Text = 0
            If CDbl(Txtallmoney.Text < 0) Then
                MessageBox.Show("موجودی منفی قابل قبول نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtallmoney.Text = 0
                Txtallmoney.Focus()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            If edt = 0 Then
                If Not Me.AreYouAddBank(Txtname.Text.Trim, Txtnumber.Text.Trim) Then
                    MessageBox.Show("  بانک مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouEditBank(Txtname.Text.Trim, Txtnumber.Text.Trim) Then
                    MessageBox.Show("بانک مورد نظر تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If str_state = "جاری" And CmbState.Text = "پس انداز" Then
                    If GetCountCheckUsed(DGV.Item("Column4", DGV.CurrentRow.Index).Value) > 0 Then
                        MessageBox.Show("از شماره حساب مورد نظر چک صادر شده است و قابل تغییر به پس انداز نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If GetCountListCheckUsed(DGV.Item("Column4", DGV.CurrentRow.Index).Value) > 0 Then
                        MessageBox.Show("برای شماره حساب مورد نظر  دسته چک صادر شده است و قابل تغییر به پس انداز نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''
            If Txtallmoney.Visible = False Then Txtallmoney.Text = 0
            Dim nam As String = Txtname.Text
            bs.EndEdit()
            dta.Update(ds, "Define_Bank")
            If edt = 0 And CmbState.Text = "جاری" Then
                If MessageBox.Show("آیا برای حساب بانکی دسته چک صادر می کنید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim Id As Long = GetCurrentId()
                    If Id > 0 Then
                        Dim frmchk As New SetChkBank
                        frmchk.LID.Text = Id
                        frmchk.Ledit.Text = 0
                        frmchk.ShowDialog()
                    Else
                        MessageBox.Show(" دسته چک صادر نشد بعدا اقدام کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

            Me.TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف بانک", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت بانک : " & nam, If(str_name = Txtname.Text, "ویرایش بانک : " & str_name, "ویرایش بانک از : " & str_name & " به " & Txtname.Text.Trim)), "")

            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            disable(True)
            Me.RefreshBank()
            If Fnew = False Then cmddel.Enabled = True
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("بانک انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "cmdsave_Click")
            End If
            Me.RefreshBank()
        End Try
    End Sub
   
    Private Function GetCurrentId() As Long
        Try
            Using Cmd As New SqlCommand("Select ISNULL(@@IDENTITY,0)", ConectionBank)
                Return Cmd.ExecuteScalar
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "GetCurrentId")
            Return 0
        End Try
    End Function
    Private Function GetCountCheckUsed(ByVal id As Long) As Long
        Try
            Using Cmd As New SqlCommand("SELECT COUNT(Chk_Get_Pay.ID) FROM Chk_Id INNER JOIN Chk_Get_Pay ON Chk_Id.Id = Chk_Get_Pay.ID WHERE Chk_Id.IDBank=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                Return Cmd.ExecuteScalar
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "GetCountCheckUsed")
            Return -1
        End Try
    End Function
    Private Function GetCountListCheckUsed(ByVal id As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT COUNT(Define_Chk.ID) FROM Define_Chk  WHERE Define_Chk.ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                Return Cmd.ExecuteScalar
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "GetCountListCheckUsed")
            Return -1
        End Try
    End Function
    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ بانكي براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        disable(False)
        edt = 1
        str_name = Trim(Txtname.Text)
        str_fam = Trim(Txtnumber.Text)
        str_state = Trim(CmbState.Text)
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

    Private Sub Txtnumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtnumber.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtadd.KeyDown
        If e.KeyCode = Keys.Enter Then cmdsave.Focus()
        Me.GetKey(e)
    End Sub
    Private Sub Txtnam_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtnam.KeyDown
        If e.KeyCode = Keys.Enter Then Txtshobeh.Focus()
        Me.GetKey(e)
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

    Private Sub Txtnam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtnam.LostFocus
        If cmdadd.Enabled = True Then Exit Sub
        Dim str As String = ""
        str = Txtnam.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        Txtnam.Text = str
    End Sub

    Private Sub Txtallmoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtallmoney.KeyDown
        If e.KeyCode = Keys.Enter Then CmbState.Focus()
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
        If e.KeyCode = Keys.Enter Then Txtadd.Focus()
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If CmbState.DroppedDown = False Then CmbState.DroppedDown = True
        End If
        Me.GetKey(e)
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Define_Bank.htm")
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
    Private Sub RefreshBank()
        Try
            ds.Clear()
            dta.Fill(ds, "Define_Bank")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "RefreshBank")
            Me.Close()
        End Try
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

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        Me.RefreshBank()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        Me.RefreshBank()
    End Sub
    Private Function AreYouAddBank(ByVal nam As String, ByVal num As String) As Boolean
        Dim T_str As String = "select n_bank,number_n  from Define_Bank WHERE n_bank=N'" & nam & "' AND number_n=N'" & num & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Bank")
        If T_ds.Tables("Define_Bank").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditBank(ByVal nam As String, ByVal num As String) As Boolean
        Dim T_str As String = "select n_bank,number_n,[State]  from Define_Bank WHERE n_bank=N'" & nam & "' AND number_n=N'" & num & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Bank")
        If T_ds.Tables("Define_Bank").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_Bank").Rows(0).Item("n_bank") <> Txtname.Text) Or (T_ds.Tables("Define_Bank").Rows(0).Item("n_bank") = str_name) And ((T_ds.Tables("Define_Bank").Rows(0).Item("number_n") <> Txtnumber.Text) Or (T_ds.Tables("Define_Bank").Rows(0).Item("number_n") = str_fam)) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub TraceUser(ByVal IdUser As Long, ByVal D_Date As String, ByVal T_time As String, ByVal Form As String, ByVal Action As String, ByVal Disc As String, ByVal SystemDisc As String)
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("INSERT INTO TraceUser (IdUser,D_Date,T_Time,Form,[Action],Disc,SystemDisc) VALUES (@IdUser,@D_Date,@T_Time,@Form,@Action,@Disc,@SystemDisc)", ConectionBank)
                cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                cmd.Parameters.AddWithValue("@D_Date", SqlDbType.VarBinary).Value = Sec.StringEncrypt(D_Date, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@T_Time", SqlDbType.VarBinary).Value = Sec.StringEncrypt(T_time, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Form", SqlDbType.VarBinary).Value = Sec.StringEncrypt(Form, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Action", SqlDbType.VarBinary).Value = Sec.StringEncrypt(Action, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Disc", SqlDbType.VarBinary).Value = If(String.IsNullOrEmpty(Disc), System.Data.SqlTypes.SqlBinary.Null, Sec.StringEncrypt(Disc, key.CreateEncryptor))
                cmd.Parameters.AddWithValue("@SystemDisc", SqlDbType.VarBinary).Value = If(String.IsNullOrEmpty(SystemDisc), System.Data.SqlTypes.SqlBinary.Null, Sec.StringEncrypt(SystemDisc, key.CreateEncryptor))
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineBank", "TraceUser")
        End Try

    End Sub

End Class