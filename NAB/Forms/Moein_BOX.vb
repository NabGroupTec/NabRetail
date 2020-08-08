Imports System.Data.SqlClient
Public Class Moein_BOX
    Dim dt As New DataTable
    Structure ListMoein
        Dim Id As Long
        Dim IdUser As Long
        Dim d_date As String
        Dim Disc As String
        Dim BedMon As Double
        Dim BesMon As Double
        Dim T As String
        Dim Mandeh As Double
        Dim Type As Long
        Dim Number_Type As Long
        Dim Type_Sanad As Long
    End Structure

    Public AllMoein() As ListMoein

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
            ChkId.Checked = False
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

    Private Sub Moein_People_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtName.Focus()
    End Sub

    Private Sub Moein_People_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Moein_People_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F79")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
                If Access_Form.Substring(3, 1) = 0 Then
                    BtnReport.Enabled = False
                End If
            End If

        End If
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If Not String.IsNullOrEmpty(TxtIdName.Text.Trim) And Not String.IsNullOrEmpty(TxtName.Text.Trim) Then
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        If e.KeyCode = AscW(0) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        ElseIf e.KeyCode = AscW(1) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.DeepPink
        ElseIf e.KeyCode = AscW(2) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Magenta
        ElseIf e.KeyCode = AscW(3) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.BlueViolet
        ElseIf e.KeyCode = AscW(4) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.DarkTurquoise
        ElseIf e.KeyCode = AscW(5) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.SpringGreen
        ElseIf e.KeyCode = AscW(6) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Yellow
        ElseIf e.KeyCode = AscW(7) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Olive
        ElseIf e.KeyCode = AscW(8) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Orange
        ElseIf e.KeyCode = AscW(9) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Chocolate
        ElseIf e.KeyCode = Keys.Delete Then
            For i As Integer = 0 To DGV.RowCount - 1
                DGV.Rows(i).DefaultCellStyle.BackColor = Color.White
            Next
        End If
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

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Box_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            Me.Enabled = False
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala       
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetMoein(ByVal id As Long)
        Try
            Dim Sql_Str As String = ""
            If ChkTime.Checked = False And ChkId.Checked = False Then
                Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser FROM Moein_BOX WHERE IDBOX =" & id & "UNION SELECT id=0,d_date=N'',Disc=N'مانده اول دوره ', BedMon= AllMoney,BesMon=0, T=N'  ',Mandeh=0.0,IdUser=-1 from Define_BOX WHERE ID =" & id & " ORDER BY D_date ,Id "
            ElseIf ChkTime.Checked = True And ChkId.Checked = False Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END, T=N'  ',Mandeh=0.0,IdUser FROM Moein_Box WHERE IDBOX = " & id & " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION (SELECT id=0,d_date=N'',Disc=N' مانده اول دوره تا قبل از" & FarsiDate1.ThisText & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX = " & id & " AND T=0 AND D_Date<N'" & FarsiDate1.ThisText & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =" & id & "  AND T=1 AND D_Date<N'" & FarsiDate1.ThisText & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_BOX WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END, T=N'  ',Mandeh=0.0,IdUser FROM Moein_Box WHERE IDBOX = " & id & " AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION (SELECT id=0,d_date=N'',Disc=N'مانده اول دوره تا قبل از  " & FarsiDate1.ThisText & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX = " & id & " AND T=0 AND D_Date<N'" & FarsiDate1.ThisText & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =" & id & "  AND T=1 AND D_Date<N'" & FarsiDate1.ThisText & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_BOX WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END, T=N'  ',Mandeh=0.0,IdUser FROM Moein_Box WHERE IDBOX = " & id & " AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION SELECT id=0,d_date=N'',Disc=N' مانده اول دوره', BedMon= AllMoney,BesMon=0, T=N'  ',Mandeh=0.0,IdUser=-1 from Define_BOX WHERE ID =" & id & " ORDER BY D_date ,Id"
                End If
            ElseIf ChkTime.Checked = False And ChkId.Checked = True Then
                If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END, T=N'  ',Mandeh=0.0,IdUser FROM Moein_Box WHERE IDBOX = " & id & " AND (Id>=" & TxtId1.Text & " AND Id <=" & TxtId2.Text & ") UNION (SELECT id=0,d_date=N'',Disc=N' مانده اول دوره تا قبل از سند" & TxtId1.Text & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX = " & id & " AND T=0 AND Id<" & TxtId1.Text & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =" & id & "  AND T=1 AND Id<" & TxtId1.Text & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_BOX WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id"
                ElseIf ChkAzId.Checked = True And ChkTaId.Checked = False Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END, T=N'  ',Mandeh=0.0,IdUser FROM Moein_Box WHERE IDBOX = " & id & " AND (Id>=" & TxtId1.Text & ") UNION (SELECT id=0,d_date=N'',Disc=N'مانده اول دوره تا قبل از سند  " & TxtId1.Text & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX = " & id & " AND T=0 AND Id<" & TxtId1.Text & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =" & id & "  AND T=1 AND Id<" & TxtId1.Text & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_BOX WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id"
                ElseIf ChkAzId.Checked = False And ChkTaId.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END, T=N'  ',Mandeh=0.0,IdUser FROM Moein_Box WHERE IDBOX = " & id & " AND (Id<=" & TxtId2.Text & ") UNION SELECT id=0,d_date=N'',Disc=N' مانده اول دوره', BedMon= AllMoney,BesMon=0, T=N'  ',Mandeh=0.0,IdUser=-1 from Define_BOX WHERE ID =" & id & " ORDER BY D_date ,Id"
                End If
            End If
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand(Sql_Str, ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            dt.Columns("Mandeh").ReadOnly = False
            dt.Columns("BesMon").ReadOnly = False
            dt.Columns("BedMon").ReadOnly = False
            dt.Columns("T").ReadOnly = False

            'SetBedBesTableMoein(dt)
            If ChkOne.Checked = True Then
                dt.Rows(0).Item("BesMon") = 0
                dt.Rows(0).Item("BedMon") = 0
                dt.AcceptChanges()
                SetBedBesTableMoein(dt)
                dt.Rows(0).Delete()
                dt.AcceptChanges()
            Else
                SetBedBesTableMoein(dt)
            End If
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Moein_BOX", "SetMoein")
            Me.Close()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Box.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnMoein.Enabled = True Then Call BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Call BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub RefreshBank()
        Try
            If String.IsNullOrEmpty(TxtIdName.Text) Then Exit Sub
            Me.Enabled = False
            Me.SetMoein(TxtIdName.Text)
            Dim bed As Double = 0
            Dim bes As Double = 0
            For i As Integer = 0 To DGV.RowCount - 1
                bed += CDbl(DGV.Item("Cln_Bed", i).Value)
                bes += CDbl(DGV.Item("Cln_Bes", i).Value)
            Next
            TxtBed.Text = FormatNumber(bed, 0)
            TxtBes.Text = FormatNumber(bes, 0)
            Dim Res As Double = bed - bes
            If Res = 0 Then
                TxtMoein.Text = 0
                TxtMandeh.Text = 0
                TxtState.Text = "بی حساب"
                TxtT.Text = "بد"
            ElseIf Res > 0 Then
                TxtMoein.Text = FormatNumber(Res, 0)
                TxtMandeh.Text = FormatNumber(Res, 0)
                TxtState.Text = "بدهکار"
                TxtT.Text = "بد"
            ElseIf Res < 0 Then
                TxtMoein.Text = FormatNumber(Res * (-1), 0)
                TxtMandeh.Text = FormatNumber(Res * (-1), 0)
                TxtState.Text = "بستانکار"
                TxtT.Text = "بس"
            End If

            Me.Enabled = True
            If DGV.RowCount > 0 Then DGV.Item(0, DGV.RowCount - 1).Selected = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Moein_BOX", "RefreshBank")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub
    Private Sub BtnMoein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoein.Click
        If String.IsNullOrEmpty(TxtIdName.Text.Trim) Or String.IsNullOrEmpty(TxtName.Text.Trim) Then
            DGV.DataSource = Nothing
            MessageBox.Show("هیچ صندوقی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Enabled = True
            TxtName.Focus()
            Exit Sub
        End If
        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                DGV.DataSource = Nothing
                MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                ChkTaDate.Checked = True
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    DGV.DataSource = Nothing
                    MessageBox.Show(" محدوده زمانی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
        End If
        If ChkId.Checked = True Then
            If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                If (CDbl(TxtId1.Text) > CDbl(TxtId2.Text)) Then
                    MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
            If ChkAzId.Checked = False And ChkTaId.Checked = False Then
                MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If
            If (CDbl(TxtId1.Text) = 0 And CDbl(TxtId2.Text) = 0) Then
                MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If
        End If
        Me.RefreshBank()

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "معین صندوق", "نمایش معین", "نمایش معین صندوق :" & TxtName.Text, "")
    End Sub
    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If DGV.RowCount <= 0 Then
            TxtName.Focus()
            Exit Sub
        End If

        Array.Resize(AllMoein, 0)
        For i As Integer = 0 To DGV.RowCount - 1
            If Not (DGV.Rows(i).DefaultCellStyle.BackColor.Equals(Color.Empty) Or DGV.Rows(i).DefaultCellStyle.BackColor.Equals(Color.White)) Then
                Array.Resize(AllMoein, AllMoein.Length + 1)
                AllMoein(AllMoein.Length - 1).Id = DGV.Item("Cln_Sanad", i).Value
                AllMoein(AllMoein.Length - 1).IdUser = DGV.Item("Cln_IdUser", i).Value
                AllMoein(AllMoein.Length - 1).d_date = DGV.Item("Cln_Date", i).Value
                AllMoein(AllMoein.Length - 1).Disc = DGV.Item("Cln_Disc", i).Value
                AllMoein(AllMoein.Length - 1).BedMon = CDbl(DGV.Item("Cln_Bed", i).Value)
                AllMoein(AllMoein.Length - 1).BesMon = CDbl(DGV.Item("Cln_Bes", i).Value)
                AllMoein(AllMoein.Length - 1).T = DGV.Item("Cln_T", i).Value
                AllMoein(AllMoein.Length - 1).Mandeh = CDbl(DGV.Item("Cln_Mandeh", i).Value)
                'AllMoein(AllMoein.Length - 1).Type = DGV.Item("Cln_Type", i).Value
                'AllMoein(AllMoein.Length - 1).Number_Type = DGV.Item("Cln_NumberType", i).Value
                'AllMoein(AllMoein.Length - 1).Type_Sanad = DGV.Item("Cln_TypeSanad", i).Value
            End If
        Next

        If AllMoein.Length > 0 Then
            Tmp_Namkala = TxtName.Text.Trim
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            FrmPrint.Str2 = ""
            Dim Tmpdt As New DataTable
            Tmpdt.Clear()
            If Not Tmpdt.Columns.Contains("Id") Then Tmpdt.Columns.Add("Id", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("IdUser") Then Tmpdt.Columns.Add("IdUser", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("d_date") Then Tmpdt.Columns.Add("d_date", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Disc") Then Tmpdt.Columns.Add("Disc", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("BedMon") Then Tmpdt.Columns.Add("BedMon", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("BesMon") Then Tmpdt.Columns.Add("BesMon", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("T") Then Tmpdt.Columns.Add("T", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Mandeh") Then Tmpdt.Columns.Add("Mandeh", Type.GetType("System.Double"))
            'If Not Tmpdt.Columns.Contains("Type") Then Tmpdt.Columns.Add("Type", Type.GetType("System.Double"))
            'If Not Tmpdt.Columns.Contains("Number_Type") Then Tmpdt.Columns.Add("Number_Type", Type.GetType("System.Double"))
            'If Not Tmpdt.Columns.Contains("Type_Sanad") Then Tmpdt.Columns.Add("Type_Sanad", Type.GetType("System.Double"))

            Dim bed As Double = 0
            Dim bes As Double = 0

            For i As Integer = 0 To AllMoein.Length - 1
                Dim row As DataRow = Tmpdt.NewRow
                row.Item("Id") = AllMoein(i).Id
                row.Item("IdUser") = AllMoein(i).IdUser
                row.Item("d_date") = AllMoein(i).d_date
                row.Item("Disc") = AllMoein(i).Disc
                row.Item("BedMon") = AllMoein(i).BedMon
                row.Item("BesMon") = AllMoein(i).BesMon
                row.Item("T") = AllMoein(i).T
                row.Item("Mandeh") = AllMoein(i).Mandeh
                'row.Item("Type") = AllMoein(i).Type
                'row.Item("Number_Type") = AllMoein(i).Number_Type
                'row.Item("Type_Sanad") = AllMoein(i).Type_Sanad
                Tmpdt.Rows.Add(row)
                bed += AllMoein(i).BedMon
                bes += AllMoein(i).BesMon
            Next

            SetBedBesTableMoein(Tmpdt)
            Tmp_String1 = If((bed - bes) > 0, "بد", "بس")
            Tmp_Mon = If((bed - bes) > 0, (bed - bes), (bed - bes) * -1)

            FrmPrint.Str2 = "سندهای انتخابی"

            FrmPrint.DtMoeinBox = Tmpdt

        Else

            Tmp_Namkala = TxtName.Text.Trim
            Tmp_String1 = TxtT.Text
            Tmp_Mon = CDbl(TxtMandeh.Text)

            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""

            If ChkTime.Checked = True Then
                Tmp_OneGroup = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                Tmp_TwoGroup = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
            End If

            If ChkId.Checked = True Then
                Tmp_OneGroup = If(ChkAzId.Checked = True, TxtId1.Text, "")
                Tmp_TwoGroup = If(ChkTaId.Checked = True, TxtId2.Text, "")
            End If

            FrmPrint.DtMoeinBox = dt

        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "معین صندوق", "چاپ گزارش", "چاپ معین صندوق :" & TxtName.Text, "")
        FrmPrint.CHoose = "MOEINBOX"
        FrmPrint.ShowDialog()
    End Sub

    Private Sub ChkId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkId.CheckedChanged
        If ChkId.Checked = True Then
            ChkAzId.Enabled = True
            ChkTaId.Enabled = True
            TxtId1.Text = "0"
            TxtId2.Text = "0"
            ChkAzId.Checked = True
            ChkTaId.Checked = True
            ChkTime.Checked = False
            TxtId1.Focus()
        Else
            ChkAzId.Checked = False
            ChkTaId.Checked = False
            ChkAzId.Enabled = False
            ChkTaId.Enabled = False
            TxtId1.Enabled = False
            TxtId2.Enabled = False
            TxtId1.Text = "0"
            TxtId2.Text = "0"
        End If
    End Sub

    Private Sub ChkAzId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzId.CheckedChanged
        If ChkAzId.Checked = True Then
            TxtId1.Text = "0"
            TxtId1.Enabled = True
            TxtId1.Focus()
            TxtId1.SelectAll()
        Else
            TxtId1.Text = "0"
            TxtId1.Enabled = False
        End If
    End Sub

    Private Sub ChkTaId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaId.CheckedChanged
        If ChkTaId.Checked = True Then
            TxtId2.Text = "0"
            TxtId2.Enabled = True
            TxtId2.Focus()
            TxtId2.SelectAll()
        Else
            TxtId2.Text = "0"
            TxtId2.Enabled = False
        End If
    End Sub

    Private Sub TxtId1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtId1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtId2.Focus()
    End Sub

    Private Sub TxtId1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtId1.KeyPress
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

    Private Sub TxtId2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtId2.KeyPress
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

    Private Sub ChkOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOne.CheckedChanged
        Call BtnMoein_Click(Nothing, Nothing)
    End Sub
End Class