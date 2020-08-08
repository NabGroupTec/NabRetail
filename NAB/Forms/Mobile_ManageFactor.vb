Imports System.Data.SqlClient
Public Class Mobile_ManageFactor
    Dim ds As New DataTable
    Dim dv As New DataView
    Private Sub GetFactor()
        Try
            ds.Clear()
            Dim query As String = SetQuery()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(query, ConectionBank)
                cmd.CommandTimeout = 0
                ds.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV1.AutoGenerateColumns = False
            dv = ds.DefaultView
            dv.Sort = "IdFactor"
            DGV1.DataSource = dv
            Dim ok As Long = 0
            Dim rad As Long = 0
            Dim dar As Long = 0
            Dim pish As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Confirm", i).Value = 0 Then
                    dar += 1
                ElseIf DGV1.Item("Confirm", i).Value = 1 Then
                    rad += 1
                ElseIf DGV1.Item("Confirm", i).Value = 2 Then
                    ok += 1
                ElseIf DGV1.Item("Confirm", i).Value = 3 Then
                    pish += 1
                End If
            Next
            TxtDar.Text = dar
            TxtRad.Text = rad
            TxtOk.Text = ok
            TxtPish.Text = pish
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "GetFactor")
        End Try
    End Sub
    Private Function SetQuery() As String
        Try
            Dim condition As String = ""
            Dim conDate As String = ""
            Dim conDate2 As String = ""

           If Rdoid.Checked = True Then
                condition = " WHERE (IdFactor=" & CLng(TxtIdFac.Text) & ")"
            ElseIf RdoMobileCode.Checked = True Then
                condition = " WHERE (IdSell=" & CLng(TxtIdFac.Text) & ")"
            ElseIf RdoDelay.Checked = True Then
                condition = " WHERE (Mobile_ListFactorSell.Rate=" & CLng(TxtIdFac.Text) & ")"
            ElseIf Rdonam.Checked = True Then
                condition = " WHERE (Mobile_ListFactorSell.IdName=" & CLng(TxtIdName.Text) & ")"
            ElseIf RdoVisit.Checked = True Then
                condition = " WHERE (Mobile_ListFactorSell.IdVisitor=" & TxtIdVisit.Text & ")"
            ElseIf RdoKind.Checked = True Then
                condition = " WHERE (Kind=" & If(CmbKind.Text = CmbKind.Items.Item(0), 0, If(CmbKind.Text = CmbKind.Items.Item(1), 1, If(CmbKind.Text = CmbKind.Items.Item(2), 2, 3))) & ")"


            ElseIf RdoState.Checked = True Then
                If CmbConfirm.Text = CmbConfirm.Items.Item(0) Then
                    condition = " WHERE (Confirm =0)"
                ElseIf CmbConfirm.Text = CmbConfirm.Items.Item(1) Then
                    condition = " WHERE (Confirm =1)"
                ElseIf CmbConfirm.Text = CmbConfirm.Items.Item(2) Then
                    condition = " WHERE (Confirm =2)"
                ElseIf CmbConfirm.Text = CmbConfirm.Items.Item(3) Then
                    condition = " WHERE (Confirm =3)"
                End If
            End If

            If ChkDate.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    conDate = " (D_Date>=N'" & FarsiDate1.ThisText & "' AND D_Date<=N'" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    conDate = " (D_Date>=N'" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    conDate = " (D_Date<=N'" & FarsiDate2.ThisText & "')"
                End If

                If String.IsNullOrEmpty(condition) Then
                    conDate = " WHERE " & conDate
                Else
                    conDate = " AND " & conDate
                End If
            End If

            If ChkDate.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    conDate2 = " (Mobile_ListFactorSell.D_Date>=N'" & FarsiDate1.ThisText & "' AND Mobile_ListFactorSell.D_Date<=N'" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    conDate2 = " (Mobile_ListFactorSell.D_Date>=N'" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    conDate2 = " (Mobile_ListFactorSell.D_Date<=N'" & FarsiDate2.ThisText & "')"
                End If

                If String.IsNullOrEmpty(condition) Then
                    conDate2 = " WHERE " & conDate2
                Else
                    conDate2 = " AND " & conDate2
                End If
            End If

            Dim Part As String = ""
            If ChkPart.Checked = True Then
                Part = "IdOstan=" & CmbOstan.SelectedValue
                Part &= If(ChkCity.Checked = True, " AND IdCity=" & CmbCity.SelectedValue, "")
                Part &= If(ChkP.Checked = True, " AND IdPart=" & CmbPart.SelectedValue, "")
                If String.IsNullOrEmpty(condition) And String.IsNullOrEmpty(conDate) And String.IsNullOrEmpty(conDate2) Then
                    Part = " WHERE (" & Part & ")"
                Else
                    Part = " AND (" & Part & ")"
                End If
            End If

            Return "SELECT  IdFactor,D_date,T_time,IdName,IdVisitor,IdUser,Confirm,Mobile_ListFactorSell.Rate,Kind,Disc,IdSell,Define_People.Nam,NamKind=Case WHEN Kind=0 THEN N'نقد' WHEN Kind=1 THEN N'چک' WHEN Kind =2 THEN N'نسیه' ELSE N'ترکیبی' END,NamConfirm=CASE WHEN Confirm =2 THEN N'تایید' WHEN Confirm =1 THEN N'رد' WHEN Confirm=0 THEN N'در جریان' WHEN Confirm=3 THEN N'پیش فاکتور' ELSE N'نامشخص' END ,IdNewPeople,City=(SELECT Define_City.NamCI FROM Define_City WHERE Define_City.Code =Define_People.IdCity),Part=(SELECT Define_Part.NamP  FROM Define_Part WHERE Define_part.Code=Define_People.IdPart) FROM Mobile_ListFactorSell INNER JOIN Define_People ON Mobile_ListFactorSell.IdName = Define_People.ID " & condition & conDate & Part & " UNION ALL SELECT IdFactor,Mobile_ListFactorSell.D_date,Mobile_ListFactorSell.T_time,IdName,Mobile_ListFactorSell.IdVisitor,Mobile_ListFactorSell.IdUser,Confirm,Mobile_ListFactorSell.Rate,Kind,Disc,IdSell,Mobile_NewPeople.Nam,NamKind=Case WHEN Kind=0 THEN N'نقد' WHEN Kind=1 THEN N'چک' WHEN Kind =2 THEN N'نسیه' ELSE N'ترکیبی' END,NamConfirm=CASE WHEN Confirm =2 THEN N'تایید' WHEN Confirm =1 THEN N'رد' WHEN Confirm=0 THEN N'در جریان' WHEN Confirm=3 THEN N'پیش فاکتور' ELSE N'نامشخص' END ,IdNewPeople,City=(SELECT Define_City.NamCI FROM Define_City WHERE Define_City.Code =Mobile_NewPeople.IdCity),Part=(SELECT Define_Part.NamP  FROM Define_Part WHERE Define_part.Code=Mobile_NewPeople.IdPart)  FROM Mobile_ListFactorSell INNER JOIN Mobile_NewPeople ON Mobile_ListFactorSell.IdNewPeople = Mobile_NewPeople.ID " & condition & conDate2 & Part
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "SetQuery")
            Me.Close()
            Return ""
        End Try
    End Function

    Private Function AreYouDeleteMobileFac(ByVal Id As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT [Confirm] FROM Mobile_ListFactorSell WHERE IdFactor =" & Id, ConectionBank)
                Dim State As Object
                State = cmd.ExecuteScalar
                If State Is DBNull.Value Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                Else
                    If State = 2 Then
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        MessageBox.Show("فاکتور مورد نظر تایید شده است و قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    ElseIf State = 3 Then
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        MessageBox.Show("فاکتور مورد نظر به پیش فاکتور تبدیل شده است و قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    Else
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        Return True
                    End If
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "AreYouDeleteMobileFac")
            Return False
        End Try
    End Function

    Private Sub DeleteMobileFac(ByVal Id As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("DELETE FROM Mobile_ListFactorSell WHERE IdFactor=" & Id, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور موبایل", "حذف", "حذف فاکتور موبایل :" & Id, "")

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "DeleteMobileFac")
        End Try
    End Sub

    Private Sub ManageFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub ManageFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Access_Form = Get_Access_Form("F143")
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
        DGV1.Columns("Cln_disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
        ChkDate.Checked = True
        Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F143")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnDel.Enabled = False
                    Btn_Showfactor.Enabled = False
                    BtnChange.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        BtnDel.Enabled = False
                        Btn_Showfactor.Enabled = False
                        BtnChange.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnDel.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            Btn_Showfactor.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 And Access_Form.Substring(6, 1) = 0 And Access_Form.Substring(7, 1) = 0 And Access_Form.Substring(8, 1) = 0 Then
                            BtnChange.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnChange.Enabled = False
                BtnDel.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "SetButton")
            Me.Close()
        End Try
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
                    MessageBox.Show("موبایل کد را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtIdFac.Focus()
                    Exit Sub
                End If
            End If

            If RdoMobileCode.Checked = True Then
                If String.IsNullOrEmpty(TxtIdFac.Text) Then
                    MessageBox.Show("شماره فاکتور را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtIdFac.Focus()
                    Exit Sub
                End If
            End If

            If RdoDelay.Checked = True Then
                If String.IsNullOrEmpty(TxtIdFac.Text) Then
                    MessageBox.Show("وعده را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            If RdoKind.Checked = True Then
                If String.IsNullOrEmpty(CmbKind.Text) Then
                    MessageBox.Show("نوع تسویه را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbKind.Focus()
                    Exit Sub
                End If
            End If

            If RdoState.Checked = True Then
                If String.IsNullOrEmpty(CmbConfirm.Text) Then
                    MessageBox.Show("نوع وضعیت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbConfirm.Focus()
                    Exit Sub
                End If
            End If

            If ChkDate.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("محدوده تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkAzDate.Checked = True
                    Exit Sub
                End If
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        FarsiDate1.Focus()
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(FarsiDate1.ThisText) Or String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                        MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If

            If ChkPart.Checked = True Then
                If String.IsNullOrEmpty(CmbOstan.Text) Then
                    MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbOstan.Focus()
                    Exit Sub
                End If
                If ChkCity.Checked = True Then
                    If String.IsNullOrEmpty(CmbCity.Text) Then
                        MessageBox.Show("هیچ شهری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CmbCity.Focus()
                        Exit Sub
                    End If
                End If
                If ChkP.Checked = True Then
                    If String.IsNullOrEmpty(CmbPart.Text) Then
                        MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CmbPart.Focus()
                        Exit Sub
                    End If
                End If
            End If


            Me.Enabled = False
            Me.GetFactor()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "BtnShow_Click")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub Rdoid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdoid.CheckedChanged
        If Rdoid.Checked = True Then
            LFactor.Visible = True
            TxtIdFac.Clear()
            TxtIdFac.Visible = True
            ChkDate.Checked = False
            ChkDate.Enabled = False
            TxtIdFac.Focus()
        Else
            ChkDate.Enabled = True
            LFactor.Visible = False
            TxtIdFac.Visible = False
        End If
    End Sub

    Private Sub Rdonam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdonam.CheckedChanged
        If Rdonam.Checked = True Then
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
            Call BtnShow_Click(Nothing, Nothing)
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

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then
            If FarsiDate2.Enabled = True Then
                FarsiDate2.Focus()
            Else
                Call BtnShow_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub FarsiDate2_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate2.KeyDowned
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

        If Not (DGV1.Item("Cln_IdNewPeople", e.RowIndex).Value Is DBNull.Value) Then
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
        End If

    End Sub

    Private Sub Btn_Showfactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Showfactor.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور موبایل", "ریز فاکتور", "نمایش ریز فاکتور موبایل " & ":" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")

            Using frmshow As New Mobile_ShowFactor
                frmshow.LState.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                frmshow.LFactor.Text = If(DGV1.Item("Cln_IdSell", DGV1.CurrentRow.Index).Value Is DBNull.Value, 0, DGV1.Item("Cln_IdSell", DGV1.CurrentRow.Index).Value)
                frmshow.LIdName.Text = If(DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value Is DBNull.Value, 0, DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value)
                frmshow.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "Btn_Showfactor_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "FactMobail.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnDel.Enabled = True And BtnDel.Visible = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Btn_Showfactor.Enabled = True And Btn_Showfactor.Visible = True Then Call Btn_Showfactor_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnChange.Enabled = True And BtnChange.Visible = True Then Call BtnChange_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnShow.Enabled = True And BtnShow.Visible = True Then Call BtnShow_Click(Nothing, Nothing)
            SetButton()
        ElseIf e.KeyCode = Keys.F6 Then
            Try
                If DGV1.RowCount <= 0 Then
                    MessageBox.Show("هیچ طرف حسابی جهت نمایش وضعیت مالی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not (DGV1.Item("Cln_IdNewPeople", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then
                    MessageBox.Show("طرف حساب مربوطه تایید نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Me.Enabled = False
                Using FValue As New FrmValue
                    FValue.LCode.Text = DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value
                    FValue.ShowDialog()
                End Using
                Me.Enabled = True
            Catch ex As Exception
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "GetKey(F6)")
                Me.Enabled = True
            End Try
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Dim day As Long = LimitWork("Del")
            'If day > 0 Then
            '    If SUBDAY(GetDate, DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value) >= day Then
            '        MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Exit Sub
            '    End If
            'End If

            If Not Me.AreYouDeleteMobileFac(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value) Then Exit Sub
            If MessageBox.Show("آیا برای حذف فاکتور مورد نظر مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Me.DeleteMobileFac(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value)
            Call BtnShow_Click(Nothing, Nothing)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "BtnDel_Click")
        End Try
    End Sub

    Private Sub BtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChange.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not (DGV1.Item("Cln_IdNewPeople", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then
                MessageBox.Show("طرف حساب فاکتور مربوطه تایید نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not StateMobileFac(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value) Then Exit Sub

            Using FrmCState As New ConvertStateFactor
                Tmp1 = DGV1.Item("Kind", DGV1.CurrentRow.Index).Value
                Tmp2 = If(DGV1.Item("Cln_Rate", DGV1.CurrentRow.Index).Value Is DBNull.Value, 0, DGV1.Item("Cln_Rate", DGV1.CurrentRow.Index).Value)
                FrmCState.LState.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                FrmCState.ShowDialog()
            End Using

            Call BtnShow_Click(Nothing, Nothing)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "BtnEdit_Click")
        End Try
    End Sub

    Private Sub SetButton(ByVal Id As Long)
        Try
            Me.SetButton()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ManageFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub RdoVisit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoVisit.CheckedChanged
        If RdoVisit.Checked = True Then
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
            Call BtnShow_Click(Nothing, Nothing)
        Else
            TxtNameVisit.Text = ""
            TxtIdVisit.Text = ""
        End If
    End Sub

    Private Sub ChkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDate.CheckedChanged
        If ChkDate.Checked = True Then
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Enabled = True
            ChkAzDate.Checked = True
            ChkTaDate.Enabled = True
            ChkTaDate.Checked = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate2.Enabled = False
            ChkAzDate.Enabled = False
            ChkAzDate.Checked = False
            ChkTaDate.Enabled = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub RdoKind_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoKind.CheckedChanged
        If RdoKind.Checked = True Then
            LKind.Visible = True
            CmbKind.Visible = True
            CmbKind.Focus()
            CmbKind.Text = CmbKind.Items.Item(0)
        Else
            LKind.Visible = False
            CmbKind.Visible = False
        End If
    End Sub

    Private Sub RdoMobileCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoMobileCode.CheckedChanged
        If RdoMobileCode.Checked = True Then
            LFactor.Visible = True
            TxtIdFac.Clear()
            TxtIdFac.Visible = True
            ChkDate.Checked = False
            ChkDate.Enabled = False
            TxtIdFac.Focus()
        Else
            ChkDate.Enabled = True
            LFactor.Visible = False
            TxtIdFac.Visible = False
        End If
    End Sub

    Private Sub RdoState_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoState.CheckedChanged
        If RdoState.Checked = True Then
            LConfirm.Visible = True
            CmbConfirm.Visible = True
            CmbConfirm.Focus()
            CmbConfirm.Text = CmbConfirm.Items.Item(0)
        Else
            LConfirm.Visible = False
            CmbConfirm.Visible = False
        End If
    End Sub

    Private Sub RdoDelay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDelay.CheckedChanged
        If RdoDelay.Checked = True Then
            LFactor.Visible = True
            TxtIdFac.Clear()
            TxtIdFac.Visible = True
            TxtIdFac.Focus()
        Else
            LFactor.Visible = False
            TxtIdFac.Visible = False
        End If
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbPart.Enabled = True
            Me.Get_Ostan()
            CmbOstan_SelectedIndexChanged(Nothing, Nothing)
            CmbCity_SelectedIndexChanged(Nothing, Nothing)
            CmbOstan.Focus()
        Else
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            CmbPart.Enabled = False
            CmbOstan.DataSource = Nothing
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
        End If
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
            Me.Get_City(CmbOstan.SelectedValue)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        Try
            CmbPart.DataSource = Nothing
            Me.Get_Part(CmbOstan.SelectedValue, CmbCity.SelectedValue)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ChkCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCity.CheckedChanged
        If ChkCity.Checked = True Then
            ChkP.Enabled = True
        Else
            ChkP.Checked = False
            ChkP.Enabled = False
        End If
    End Sub

    Private Sub Get_Ostan()
        Try
            Dim Ds_O As New DataTable
            Dim Dta_O As New SqlDataAdapter
            If Not Dta_O Is Nothing Then Dta_O.Dispose()
            Dta_O = New SqlDataAdapter("SELECT Code,NamO FROM Define_Ostan", DataSource)
            Dta_O.Fill(Ds_O)
            CmbOstan.DataSource = Ds_O
            CmbOstan.DisplayMember = "NamO"
            CmbOstan.ValueMember = "Code"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "Get_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Get_City(ByVal Id As Long)
        Try
            Dim Ds_C As New DataTable
            Dim Dta_C As New SqlDataAdapter
            If Not Dta_C Is Nothing Then Dta_C.Dispose()
            Dta_C = New SqlDataAdapter("SELECT Code,NamCi FROM Define_City WHERE IdOstan=" & Id, DataSource)
            Dta_C.Fill(Ds_C)
            CmbCity.DataSource = Ds_C
            CmbCity.DisplayMember = "NamCi"
            CmbCity.ValueMember = "Code"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "Get_City")
            Me.Close()
        End Try
    End Sub
    Private Sub Get_Part(ByVal IdOstan As Long, ByVal IdCity As Long)
        Try
            Dim Ds_P As New DataTable
            Dim Dta_P As New SqlDataAdapter
            If Not Dta_P Is Nothing Then Dta_P.Dispose()
            Dta_P = New SqlDataAdapter("SELECT Code,NamP FROM Define_Part WHERE IdOstan=" & IdOstan & " AND IdCity=" & IdCity, DataSource)
            Dta_P.Fill(Ds_P)
            CmbPart.DataSource = Ds_P
            CmbPart.DisplayMember = "NamP"
            CmbPart.ValueMember = "Code"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "Get_Part")
            Me.Close()
        End Try
    End Sub

End Class