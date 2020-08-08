Imports System.Data.SqlClient
Public Class SodFactor
    Dim ds As New DataTable
    Dim dta As New SqlDataAdapter
    Dim dv As New DataView
    Private Sub GetFactor()
        Try
            ds.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(SetQuery, ConectionBank)
                cmd.CommandTimeout = 0
                ds.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV1.AutoGenerateColumns = False
            dv = ds.DefaultView
            DGV1.DataSource = dv
            Me.Calculate()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "GetFactor")
        End Try
    End Sub
    Private Function SetQuery() As String
        Try
            Dim condition As String = ""
            If Rdoid.Checked = True Then
                condition = " AND (IdFactor=" & CLng(TxtIdFac.Text) & ")"
            ElseIf Rdonam.Checked = True Then
                condition = " AND (IdName=" & CLng(TxtIdName.Text) & ")"
            ElseIf RdoVisit.Checked = True Then
                condition = " AND (IdVisitor=" & TxtIdVisit.Text & ")"
            ElseIf RdoUser.Checked = True Then
                condition = " AND (IdUser=" & TxtIdUser.Text & ")"
            ElseIf RdoCity.Checked = True Then
                condition = " AND (Code=" & TxtIdCity.Text & ")"
            End If

            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    condition &= " AND (D_Date>=N'" & FarsiDate1.ThisText & "' AND D_Date<=N'" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    condition &= " AND (D_Date>=N'" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    condition &= " AND (D_Date<=N'" & FarsiDate2.ThisText & "')"
                End If
            End If

            Return "SELECT IdFactor ,D_date ,Nam ,MonFac ,NSod ,Discount ,(NSod - Discount ) As Sod FROM (SELECT  IdFactor ,D_date,Nam ,(SELECT ISNULL(SUM(Mon),0) AS MonFac FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor ) As MonFac ,(SELECT ISNULL(SUM(Discount),0) AS Discount FROM (SELECT  ISNULL(SUM(DarsadMon ),0) AS Discount FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ((Discount +MonDec)-MonAdd)   FROM ListFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListFactor.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As ListDiscount) As Discount ,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'F',ListFactor.d_Date,'False')) AS NSod  FROM (SELECT IdFactor, D_date, Nam, Code FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1)" & condition & ") As ListFactor) As EndList ORDER BY D_date ,IdFactor"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "SetQuery")
            Me.Close()
            Return ""
        End Try
    End Function

    Private Sub ManageFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub ManageFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F95")
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
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        DGV1.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F95")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnShow.Enabled = False
                    Btn_Showfactor.Enabled = False
                    BtnEdit.Enabled = False
                    Button1.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        BtnShow.Enabled = False
                        Btn_Showfactor.Enabled = False
                        BtnEdit.Enabled = False
                        Button1.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            Btn_Showfactor.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            BtnEdit.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            Button1.Enabled = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub TxtIdFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdFac.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtIdFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdFac.KeyPress
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

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Try

            If Rdoid.Checked = True Then
                If String.IsNullOrEmpty(TxtIdFac.Text) Then
                    MessageBox.Show("شماره فاکتور را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtIdFac.Focus()
                    Exit Sub
                End If
            End If
            If Rdonam.Checked = True Then
                If String.IsNullOrEmpty(Txtname.Text) Or String.IsNullOrEmpty(TxtIdName.Text) Then
                    MessageBox.Show("طرف حساب را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Txtname.Focus()
                    Exit Sub
                End If
            End If
            If RdoVisit.Checked = True Then
                If String.IsNullOrEmpty(TxtNameVisit.Text) Or String.IsNullOrEmpty(TxtIdVisit.Text) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNameVisit.Focus()
                    Exit Sub
                End If
            End If

            If RdoUser.Checked = True Then
                If String.IsNullOrEmpty(TxtUser.Text) Or String.IsNullOrEmpty(TxtIdUser.Text) Then
                    MessageBox.Show("کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtUser.Focus()
                    Exit Sub
                End If
            End If

            If RdoCity.Checked = True Then
                If String.IsNullOrEmpty(TxtCity.Text) Or String.IsNullOrEmpty(TxtIdCity.Text) Then
                    MessageBox.Show("شهرستان را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCity.Focus()
                    Exit Sub
                End If
            End If

            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkTaDate.Checked = True
                    Exit Sub
                End If
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show(" محدوده زمانی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
           
            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود فاکتور", "محاسبه سود", "", "")

            Me.GetFactor()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "BtnShow_Click")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub Rdoid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdoid.CheckedChanged
        If Rdoid.Checked = True Then
            GroupBox3.Enabled = True
            ChkTime.Checked = False
            ChkTime.Enabled = False
            LFactor.Visible = True
            TxtIdFac.Clear()
            TxtIdFac.Visible = True
            TxtIdFac.Focus()
        Else
            LFactor.Visible = False
            TxtIdFac.Visible = False
        End If
    End Sub

    Private Sub Rdonam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdonam.CheckedChanged
        If Rdonam.Checked = True Then
            GroupBox3.Enabled = True
            ChkTime.Enabled = True
            Lname.Visible = True
            Txtname.Visible = True
            Lname.Visible = True
            Txtname.Clear()
            TxtIdName.Clear()
            Txtname.Focus()
        Else
            Lname.Visible = False
            Txtname.Visible = False
            Lname.Visible = False
        End If
    End Sub

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        Txtname.Focus()
        If Tmp_Namkala <> "" Then
            Txtname.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
        Else
            Txtname.Text = ""
            TxtIdName.Text = ""
        End If
    End Sub

    Private Sub TxtPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        Try
            If DGV1.Item("cln_Sod", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value < 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value = 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Showfactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Showfactor.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود فاکتور", "ریز فاکتور", "نمایش ریز فاکتور فروش:" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")

            Using frmshow As New ShowFactor
                frmshow.LFactor.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                frmshow.LState.Text = 3
                frmshow.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "Btn_Showfactor_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_SodFactor.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnShow.Enabled = True Then Call BtnShow_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Btn_Showfactor.Enabled = True Then Call Btn_Showfactor_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnShow.Enabled = True Then Call BtnShow_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Not AreYouEditFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, 3) Then
                MessageBox.Show("فاکتور مورد نظر در حال بروز رسانی می باشد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Not SetEditFlagFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, 3, 0) Then
                MessageBox.Show("فاکتور مورد نظر به حالت ویرایش تغییر وضعیت نمی دهد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Fnew = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود فاکتور", "ویرایش فاکتور", "ویرایش فاکتور فروش:" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")

            Using FrmFactor As New FrmFactor
                FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(3)
                FrmFactor.CmbFac.Enabled = False
                FrmFactor.LEdit.Text = "1"
                FrmFactor.LIdFac.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                FrmFactor.LState.Text = 3
                If Not AreYouDeleteCheckFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, 3) Then
                    FrmFactor.TxtName.Enabled = False
                End If
                If AreYouExsitRelation(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, 3) Then
                    FrmFactor.TxtName.Enabled = False
                End If
                FrmFactor.ShowDialog()
                SetEditFlagFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, 3, 1)
            End Using
            Application.DoEvents()
            Call BtnShow_Click(Nothing, Nothing)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "BtnEdit_Click")
        End Try
    End Sub

    Private Sub RdoVisit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoVisit.CheckedChanged
        If RdoVisit.Checked = True Then
            GroupBox3.Enabled = True
            ChkTime.Enabled = True
            LVisit.Visible = True
            TxtNameVisit.Visible = True
            TxtNameVisit.Clear()
            TxtIdVisit.Clear()
            TxtNameVisit.Focus()
        Else
            LVisit.Visible = False
            TxtNameVisit.Visible = False
        End If
    End Sub

    Private Sub TxtNameVisit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameVisit.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtNameVisit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameVisit.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtNameVisit.Focus()
        If Tmp_Namkala <> "" Then
            TxtNameVisit.Text = Tmp_Namkala
            TxtIdVisit.Text = IdKala
        Else
            TxtNameVisit.Text = ""
            TxtIdVisit.Text = ""
        End If
    End Sub

    Private Sub RdoUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoUser.CheckedChanged
        If RdoUser.Checked = True Then
            GroupBox3.Enabled = True
            ChkTime.Enabled = True
            LUser.Visible = True
            TxtUser.Visible = True
            TxtUser.Clear()
            TxtIdUser.Clear()
            TxtUser.Focus()
        Else
            LUser.Visible = False
            TxtUser.Visible = False
        End If
    End Sub

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New user_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
        Else
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            GroupBox3.Enabled = False
            ChkTime.Enabled = True
        End If
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub ChkAzDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkAzDate.Checked = True Then
            FarsiDate1.ThisText = GetDate()
            FarsiDate1.Enabled = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
        End If
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
        End If
    End Sub
    Private Sub Calculate()
        Try
            Dim Sod As Double = 0
            Dim Discount As Double = 0
            Dim NSod As Double = 0
            Dim MonFac As Double = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                Sod += CDbl(DGV1.Item("Cln_Sod", i).Value)
                Discount += CDbl(DGV1.Item("Cln_Discount", i).Value)
                NSod += CDbl(DGV1.Item("Cln_NSod", i).Value)
                MonFac += CDbl(DGV1.Item("Cln_MonFac", i).Value)
            Next
            TxtSod.Text = FormatNumber(Sod, 0)
            TxtDiscount.Text = FormatNumber(Discount, 0)
            TxtNSod.Text = FormatNumber(NSod, 0)
            TxtMonFac.Text = FormatNumber(MonFac, 0)
        Catch ex As Exception
            TxtSod.Text = 0
            TxtDiscount.Text = 0
            TxtNSod.Text = 0
            TxtMonFac.Text = 0
        End Try
    End Sub

    Private Sub TxtMonFac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonFac.TextChanged
        If Not (CheckDigit(TxtMonFac.Text.Replace(",", ""))) Then
            TxtMonFac.Text = 0
            If CDbl(TxtMonFac.Text.Trim) = 0 Then
                TxtMonFac.BackColor = Color.Yellow
            ElseIf CDbl(TxtMonFac.Text.Trim) > 0 Then
                TxtMonFac.BackColor = Color.White
            ElseIf CDbl(TxtMonFac.Text.Trim) < 0 Then
                TxtMonFac.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtMonFac.Text.Trim) = 0 Then
            TxtMonFac.BackColor = Color.Yellow
        ElseIf CDbl(TxtMonFac.Text.Trim) > 0 Then
            TxtMonFac.BackColor = Color.White
        ElseIf CDbl(TxtMonFac.Text.Trim) < 0 Then
            TxtMonFac.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtNSod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNSod.TextChanged
        If Not (CheckDigit(TxtNSod.Text.Replace(",", ""))) Then
            TxtNSod.Text = 0
            If CDbl(TxtNSod.Text.Trim) = 0 Then
                TxtNSod.BackColor = Color.Yellow
            ElseIf CDbl(TxtNSod.Text.Trim) > 0 Then
                TxtNSod.BackColor = Color.White
            ElseIf CDbl(TxtNSod.Text.Trim) < 0 Then
                TxtNSod.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtNSod.Text.Trim) = 0 Then
            TxtNSod.BackColor = Color.Yellow
        ElseIf CDbl(TxtNSod.Text.Trim) > 0 Then
            TxtNSod.BackColor = Color.White
        ElseIf CDbl(TxtNSod.Text.Trim) < 0 Then
            TxtNSod.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscount.TextChanged
        If Not (CheckDigit(TxtDiscount.Text.Replace(",", ""))) Then
            TxtDiscount.Text = 0
            If CDbl(TxtDiscount.Text.Trim) = 0 Then
                TxtDiscount.BackColor = Color.Yellow
            ElseIf CDbl(TxtDiscount.Text.Trim) > 0 Then
                TxtDiscount.BackColor = Color.White
            ElseIf CDbl(TxtDiscount.Text.Trim) < 0 Then
                TxtDiscount.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtDiscount.Text.Trim) = 0 Then
            TxtDiscount.BackColor = Color.Yellow
        ElseIf CDbl(TxtDiscount.Text.Trim) > 0 Then
            TxtDiscount.BackColor = Color.White
        ElseIf CDbl(TxtDiscount.Text.Trim) < 0 Then
            TxtDiscount.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtSod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSod.TextChanged
        If Not (CheckDigit(TxtSod.Text.Replace(",", ""))) Then
            TxtSod.Text = 0
            If CDbl(TxtSod.Text.Trim) = 0 Then
                TxtSod.BackColor = Color.Yellow
            ElseIf CDbl(TxtSod.Text.Trim) > 0 Then
                TxtSod.BackColor = Color.White
            ElseIf CDbl(TxtSod.Text.Trim) < 0 Then
                TxtSod.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtSod.Text.Trim) = 0 Then
            TxtSod.BackColor = Color.Yellow
        ElseIf CDbl(TxtSod.Text.Trim) > 0 Then
            TxtSod.BackColor = Color.White
        ElseIf CDbl(TxtSod.Text.Trim) < 0 Then
            TxtSod.BackColor = Color.Pink
        End If
    End Sub

    Private Sub RdoCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCity.CheckedChanged
        If RdoCity.Checked = True Then
            GroupBox3.Enabled = True
            ChkTime.Enabled = True
            LCity.Visible = True
            TxtCity.Visible = True
            TxtCity.Clear()
            TxtIdCity.Clear()
            TxtCity.Focus()
        Else
            LCity.Visible = False
            TxtCity.Visible = False
        End If
    End Sub

    Private Sub TxtCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCity.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCity.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New City_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtCity.Focus()
        If Tmp_Namkala <> "" Then
            TxtCity.Text = Tmp_Namkala
            TxtIdCity.Text = IdKala
        Else
            TxtCity.Text = ""
            TxtIdCity.Text = ""
        End If
    End Sub

    Private Sub DGV1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV1.RowPrePaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        Try
            If DGV1.Item("cln_Sod", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value < 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value = 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("گزارشی جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Array.Resize(ListDelayPrintArray, 0)
            For i As Integer = 0 To DGV1.RowCount - 1
                Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).IdFactor = DGV1.Item("Cln_Idf", i).Value
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).nam = DGV1.Item("Cln_Date", i).Value
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell1 = DGV1.Item("Column1", i).Value.ToString
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tmp = CDbl(DGV1.Item("Cln_MonFac", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).D_Date = ""
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).EndDate = ""
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Disc = ""
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = ""
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Rate = CDbl(DGV1.Item("Cln_Nsod", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Remain = CDbl(DGV1.Item("Cln_Discount", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).TimeRemain = CDbl(DGV1.Item("cln_Sod", i).Value)
            Next
            Me.Enabled = False
            If MessageBox.Show("آیا سود فاکتور در چاپ تاثیر داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                FrmPrint.CHoose = "SODPRINT1"
            Else
                FrmPrint.CHoose = "SODPRINT2"
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود فاکتور", "چاپ لیست", "", "")

            FrmPrint.ShowDialog()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor", "Button1_Click")
            Me.Enabled = True
        End Try
    End Sub
End Class