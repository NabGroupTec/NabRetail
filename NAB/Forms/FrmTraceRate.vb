Imports System.Data.SqlClient
Public Class FrmTraceRate

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            TxtGroup.Text = Tmp_OneGroup + "-" + Tmp_TwoGroup
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

    Private Sub FrmTraceRate_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtName.Focus()
    End Sub

    Private Sub FrmTraceRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmTraceRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F152")
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
        Me.GetPeople()
        DGV2.Columns("Cln_NamP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ChkAllp.Checked = True
    End Sub

    Private Sub GetPeople()
        Try
            Dim dvP As New DataView
            Dim DsP As New DataSet
            Dim DtaP As New SqlDataAdapter()
            DsP.Clear()
            If Not DtaP Is Nothing Then
                DtaP.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Activ,Id,Nam FROM Define_People Order by Nam"
            DtaP = New SqlDataAdapter(sqlstr, DataSource)
            DtaP.Fill(DsP, "Define_People")
            DGV2.AutoGenerateColumns = False
            dvP = DsP.Tables("Define_People").DefaultView
            DGV2.DataSource = dvP
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmTraceRate", "GetPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try
            If String.IsNullOrEmpty(TxtIdName.Text.Trim) Or String.IsNullOrEmpty(TxtName.Text.Trim) Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
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

            If ChkVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtVisitor.Text) Or String.IsNullOrEmpty(TxtIdVisitor.Text) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtVisitor.Focus()
                    Exit Sub
                End If
            End If

            If ChkUser.Checked = True Then
                If String.IsNullOrEmpty(TxtUser.Text) Or String.IsNullOrEmpty(TxtIdUser.Text) Then
                    MessageBox.Show("کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtUser.Focus()
                    Exit Sub
                End If
            End If

            Dim ListPeople As String = ""
            Dim CountPeople As Long = 0
            ListPeople = " AND ( "
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Item("Cln_SelectP", i).Value = True Then
                    ListPeople &= "IdName =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                    CountPeople += 1
                End If
            Next
            If CountPeople = DGV2.RowCount Then
                ListPeople = ""
            ElseIf CountPeople <= 0 Then
                MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                ListPeople &= ")"
            End If



            Tmp_String1 = ""
            Tmp_String2 = ""
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpAddress = ""
            TmpGroupName = ""
            TmpTell1 = ""

            Tmp_Namkala = TxtName.Text
            Tmp_OneGroup = TxtGroup.Text
            Dim dat As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dat = " AND ( D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
                    Tmp_String1 = FarsiDate1.ThisText
                    Tmp_String2 = FarsiDate2.ThisText
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dat = " AND ( D_date >=N'" & FarsiDate1.ThisText & "')"
                    Tmp_String1 = FarsiDate1.ThisText
                    Tmp_String2 = ""
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dat = " AND ( D_date <=N'" & FarsiDate2.ThisText & "')"
                    Tmp_String1 = ""
                    Tmp_String2 = FarsiDate2.ThisText
                End If
            End If

            Dim visitor As String = ""
            If ChkVisitor.Checked = True Then
                visitor = " AND IdVisitor=" & CLng(TxtIdVisitor.Text)
                Tmp_TwoGroup = TxtVisitor.Text.Trim
            End If

            Dim User As String = ""
            If ChkUser.Checked = True Then
                User = " AND IdUser=" & CLng(TxtIdUser.Text)
                TmpAddress = TxtUser.Text.Trim
            End If

            If RdoDate.Checked = True Then
                TmpGroupName = "D_date"
            ElseIf RdoFactor.Checked = True Then
                TmpGroupName = "IdFactor"
            ElseIf RdoP.Checked = True Then
                TmpGroupName = "Nam"
            ElseIf RdoMon.Checked = True Then
                TmpGroupName = "Mon"
            ElseIf RdoEndDate.Checked = True Then
                TmpGroupName = "EndDate"
            ElseIf RdoRas.Checked = True Then
                TmpGroupName = "TRas"
            End If
            If CheckBox1.Checked = True Then
                If ComboBox1.Text = ComboBox1.Items(0) Then
                    TmpTell1 = "EndDate<>''"
                ElseIf ComboBox1.Text = ComboBox1.Items(1) Then
                    TmpTell1 = "EndDate=''"
                End If
            End If
            Me.Enabled = False
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "وعده تسویه کالا", "تهیه گزارش", "نمایش وعده تسویه کالای :" & TxtName.Text, "")
            Using FPrint As New FrmPrint
                FPrint.PrintSQl = "SELECT D_date,IdFactor,IdVisitor,IdUser,Nam,NamU=CASE WHEN IdUser IS NULL THEN N'فاکتورهای بدون کاربر' ELSE (SELECT Nam FROM Define_User WHERE Id=IdUser) END,NamV=CASE WHEN IdVisitor IS NULL THEN N'فاکتورهای بدون ویزیتور' ELSE (SELECT Nam FROM Define_Visitor WHERE Id=IdVisitor) END ,Mon ,Stat=CASE WHEN EndPay>=Mon THEN N'تسویه' ELSE N'عدم تسویه' END,EndDate=CASE WHEN EndPay>=Mon THEN ISNULL(dbo.RateFactor(" & TxtIdName.Text & ",IdFactor,Mon,'DAT'),N'') ELSE N'' END,CountRate=CASE WHEN EndPay>=Mon THEN ISNULL(dbo.RateFactor(" & TxtIdName.Text & ",IdFactor,Mon,'ROW'),0) ELSE 0 END ,RasRate=CASE WHEN EndPay>=Mon THEN ISNULL(dbo.RateFactor(" & TxtIdName.Text & ",IdFactor,Mon,'RAS'),N'') ELSE N'' END FROM (SELECT ListFactor.D_date,ListFactor.IdFactor,ListFactor.Nam,ListFactor.IdVisitor ,ListFactor.IdUser ,SUM(ListFactor.MON-ListFactor.DarsadMon) As Mon,EndPay=ROUND(ISNULL(dbo.RateFactor(" & TxtIdName.Text & ",ListFactor.IdFactor,SUM(ListFactor.MON-ListFactor.DarsadMon),'PAY'),0),0) FROM (SELECT KalaFactorSell.Mon,KalaFactorSell.DarsadMon,ListFactorSell.IdFactor,ListFactorSell.D_date,Define_People.Nam ,ListFactorSell.IdVisitor,ListFactorSell.IdUser  FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE KalaFactorSell .IdKala =" & TxtIdName.Text & " AND ListFactorSell.Activ =1 AND ListFactorSell.Stat =3  " & dat & visitor & User & ListPeople & ") AS ListFactor GROUP BY IdFactor,D_date,Nam,IdVisitor,IdUser) AS ListEndRate"
                If ChkAllUser.Checked = False And ChkAllVisitor.Checked = False Then
                    FPrint.CHoose = "RATEFACTOR"
                ElseIf ChkAllVisitor.Checked = True Then
                    FPrint.CHoose = "RATEFACTORVISITOR"
                ElseIf ChkAllUser.Checked = True Then
                    FPrint.CHoose = "RATEFACTORUSER"
                End If
                FPrint.ShowDialog()
            End Using
            Me.Enabled = True

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmTraceRate", "BtnReport_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "vadetasviekala1.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChkUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkUser.CheckedChanged
        If ChkUser.Checked = True Then
            TxtUser.Enabled = True
            TxtUser.Focus()
        Else
            TxtUser.Enabled = False
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
    End Sub

    Private Sub ChkVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisitor.CheckedChanged
        If ChkVisitor.Checked = True Then
            TxtVisitor.Enabled = True
            TxtVisitor.Focus()
        Else
            TxtVisitor.Enabled = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        If Tmp_Namkala <> "" Then
            TxtVisitor.Text = Tmp_Namkala
            TxtIdVisitor.Text = IdKala
        End If
    End Sub

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New User_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
        End If
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then FarsiDate2.Focus()
    End Sub

    Private Sub FarsiDate2_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate2.KeyDowned
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV2.RowCount <= 0 Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV2.RowCount > 1 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_IdP", i).Value = IdKala Then
                        DGV2.Item("Cln_NamP", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV2.Item("Cln_NamP", 0).Selected = True
                DGV2.Item("Cln_NamP", 0).Selected = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Using FrmAdVance As New People_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.Condition2 = "1"
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV2.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV2.Item("Cln_IdP", i).Value Then DGV2.Item("Cln_SelectP", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV2.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub ChkAllp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllp.CheckedChanged
        If DGV2.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV2.RowCount - 1
            DGV2.Item("Cln_SelectP", i).Value = ChkAllp.Checked
        Next
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        If DGV2.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        If CBool(DGV2.Item("Cln_ActiveP", e.RowIndex).Value) = True Then
            DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ComboBox1.Enabled = True
            If String.IsNullOrEmpty(ComboBox1.Text) Then
                ComboBox1.Text = ComboBox1.Items(0)
            End If
        Else
            ComboBox1.Enabled = False
        End If
    End Sub

    Private Sub ChkAllVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllVisitor.CheckedChanged
        If ChkAllVisitor.Checked = True Then
            ChkVisitor.Checked = False
            ChkVisitor.Enabled = False
            ChkAllUser.Checked = False
            ChkAllUser.Enabled = False

            RdoDate.Enabled = False
            RdoFactor.Enabled = False
            RdoP.Enabled = False
            RdoEndDate.Enabled = False
            If RdoDate.Checked = True Or RdoFactor.Checked = True Or RdoP.Checked = True Or RdoEndDate.Checked = True Then
                RdoRas.Checked = True
            End If
        Else
            ChkVisitor.Enabled = True
            ChkAllUser.Enabled = True

            RdoDate.Enabled = True
            RdoFactor.Enabled = True
            RdoP.Enabled = True
            RdoEndDate.Enabled = True
        End If
    End Sub

    Private Sub ChkAllUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllUser.CheckedChanged
        If ChkAllUser.Checked = True Then
            ChkUser.Checked = False
            ChkUser.Enabled = False
            ChkAllVisitor.Checked = False
            ChkAllVisitor.Enabled = False
            RdoDate.Enabled = False
            RdoFactor.Enabled = False
            RdoP.Enabled = False
            RdoEndDate.Enabled = False
            If RdoDate.Checked = True Or RdoFactor.Checked = True Or RdoP.Checked = True Or RdoEndDate.Checked = True Then
                RdoRas.Checked = True
            End If
        Else
            ChkUser.Enabled = True
            ChkAllVisitor.Enabled = True
            RdoDate.Enabled = True
            RdoFactor.Enabled = True
            RdoP.Enabled = True
            RdoEndDate.Enabled = True
        End If
    End Sub
End Class