Imports System.Data.SqlClient
Public Class DefineVisitor
    Dim edt As Integer
    Dim str_name, str_fam As String
    Dim ds As New DataSet
    Dim str As String = "select * from Define_Visitor"
    Dim dta As New SqlDataAdapter(str, DataSource)
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub Customer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdsave.Enabled = True Or cmdcan.Enabled = True Then
            bs.CancelEdit()
        End If
    End Sub

    Private Sub DefineUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Customer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F19")
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
            Access_Form = Get_Access_Form("F19")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineVisitor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub set_txtbind()
        Txtname.DataBindings.Add("text", bs, ".nam", True, DataSourceUpdateMode.OnValidation)
        TxtP.DataBindings.Add("text", bs, ".Mon", True, DataSourceUpdateMode.OnValidation)
        TxtPas.DataBindings.Add("text", bs, ".P", True, DataSourceUpdateMode.OnValidation)
        ChkActive.DataBindings.Add("CheckState", bs, ".Activ", True, DataSourceUpdateMode.OnValidation)
    End Sub
    Private Sub fill_dgv()
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

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
            dta.Fill(ds, "Define_Visitor")
            '''''''''''''''''''''''''''
            If Not ds.Tables("Define_Visitor").Columns.Contains("P") Then ds.Tables("Define_Visitor").Columns.Add("P", Type.GetType("System.String"))

            For i As Integer = 0 To ds.Tables("Define_Visitor").Rows.Count - 1
                ds.Tables("Define_Visitor").Rows(i).Item("P") = Sec.StringDecrypt(ds.Tables("Define_Visitor").Rows(i).Item("Pas"), key.CreateDecryptor)
            Next
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds.Tables("Define_Visitor").Columns("ID")
            ds.Tables("Define_Visitor").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_Visitor"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineVisitor", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub disable(ByVal flag As Boolean)
        Txtname.ReadOnly = flag
        TxtP.ReadOnly = flag
        Txtpas.ReadOnly = flag
        BN.Enabled = flag
        ChkActive.Enabled = Not flag
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
            MessageBox.Show("هيچ ویزیتوری براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد ویزیتور جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Dim nam As String = Txtname.Text
                bs.RemoveAt(bs.Position)
                dta.Update(ds, "Define_Visitor")
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف ویزیتور", "حذف", "حذف ویزیتور :" & nam, "")
                ds.AcceptChanges()
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("ویزیتور انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineVisitor", "cmddel_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub

    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        bs.CancelEdit()
        Me.RefreshBank()
        disable(True)
        cmdsave.Focus()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        disable(False)
        Try
            Me.RefreshBank()
            bs.AddNew()
            edt = 0
            TxtP.Text = ""
            ChkActive.Checked = True
            ChkActive.Checked = False
            TxtP.Text = "0"
            Txtname.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineVisitor", "cmdadd_Click")
            disable(True)
            Me.RefreshBank()
        End Try
    End Sub
    Private Function AreYouAdd(ByVal nam As String) As Boolean
        Dim T_ds As New DataSet
        Dim T_str As String = "select nam  from Define_Visitor"
        Dim T_dta As New SqlDataAdapter(T_str, DataSource)
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Visitor")
        Dim dr() As DataRow = T_ds.Tables("Define_Visitor").Select("nam ='" & nam & "'")
        If dr.Length <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouAddEdit(ByVal nam As String) As Boolean
        Dim T_ds As New DataSet
        Dim T_str As String = "select nam  from Define_Visitor"
        Dim T_dta As New SqlDataAdapter(T_str, DataSource)
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_Visitor")
        Dim dr() As DataRow = T_ds.Tables("Define_Visitor").Select("nam ='" & nam & "'")
        If dr.Length >= 1 Then
            If (dr(0).Item("nam") <> Txtname.Text) Or (dr(0).Item("nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            If Trim(Txtname.Text) = "" Then
                MessageBox.Show("نام ویزیتور را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtname.Focus()
                Exit Sub
            End If
            Txtname.Text = Txtname.Text.Trim
            '''''''''''''''''''''''''''''''''''''''''''''''
            If edt = 0 Then
                If Not Me.AreYouAdd(Txtname.Text) Then
                    MessageBox.Show("ویزیتور مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            ''''''''''''''''
            If edt = 1 Then
                If Not Me.AreYouAddEdit(Txtname.Text) Then
                    MessageBox.Show("ویزیتور مورد نظر تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            bs.Current("Pas") = Sec.StringEncrypt(Txtpas.Text, key.CreateEncryptor)

            Dim nam As String = Txtname.Text
            bs.EndEdit()
            dta.Update(ds, "Define_Visitor")
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف ویزیتور", If(edt = 0, "جدید", "ویرایش"), If(edt = 0, "ثبت ویزیتور : " & nam, If(str_name = Txtname.Text, "ویرایش ویزیتور : " & str_name, "ویرایش ویزیتور از : " & str_name & " به " & Txtname.Text.Trim)), "")
            DGV.Refresh()
            DGV.RefreshEdit()
            ds.AcceptChanges()
            Me.RefreshBank()
            If Fnew = False Then cmddel.Enabled = True
            disable(True)
            cmdsave.Focus()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("ویزیتور انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineVisitor", "cmdSave_Click")
            End If
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ ویزیتوری براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then TxtP.Focus()
        Me.GetKey(e)
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

    Private Sub TxtP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtP.KeyDown
        If e.KeyCode = Keys.Enter Then Txtpas.Focus()
        Me.GetKey(e)
    End Sub

    Private Sub TxtP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtP.KeyPress
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
    Private Sub RefreshBank()
        Try
            ds.Clear()
            dta.Fill(ds, "Define_Visitor")

            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            If Not ds.Tables("Define_Visitor").Columns.Contains("P") Then ds.Tables("Define_Visitor").Columns.Add("P", Type.GetType("System.String"))

            For i As Integer = 0 To ds.Tables("Define_Visitor").Rows.Count - 1
                ds.Tables("Define_Visitor").Rows(i).Item("P") = Sec.StringDecrypt(ds.Tables("Define_Visitor").Rows(i).Item("Pas"), key.CreateDecryptor)
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineVisitor", "RefreshBank")
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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Vizitor.htm")
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

    Private Sub RdoF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub RdoM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub RdoG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub TxtP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtP.TextChanged
        If Not (CheckDigit(Format$(TxtP.Text.Replace(",", "")))) Then
            TxtP.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtP.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtP.Text.Replace(",", ""))
            TxtP.Text = Format$(Val(str), "###,###,###")
        Else
            TxtP.Text = CDbl(TxtP.Text)
        End If
    End Sub

    Private Sub Txtpas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtpas.KeyDown
        If e.KeyCode = Keys.Enter Then ChkActive.Focus()
        Me.GetKey(e)
    End Sub

End Class