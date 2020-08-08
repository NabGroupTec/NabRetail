Imports System.Data.SqlClient
Public Class Moein_KalaPeople

    Dim dt As New DataTable
    Dim NewDt As New DataTable
    Dim DtName As New DataTable
    Structure ListMoein
        Dim d_date As String
        Dim Disc As String
        Dim Kol As String
        Dim Joz As String
        Dim Fe As Double
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
        CmbMoein.Focus()
    End Sub

    Private Sub Moein_People_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Moein_People_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F78")
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
        ToolChk.Visible = False
        ToolFactor.Visible = False

        If Not DtName.Columns.Contains("Id") Then DtName.Columns.Add("Id", System.Type.GetType("System.String"))
        If Not DtName.Columns.Contains("Name") Then DtName.Columns.Add("Name", System.Type.GetType("System.String"))
        If Not DtName.Columns.Contains("NamFac") Then DtName.Columns.Add("NamFac", System.Type.GetType("System.String"))
        If Not DtName.Columns.Contains("Address") Then DtName.Columns.Add("Address", System.Type.GetType("System.String"))
        If Not DtName.Columns.Contains("Tell") Then DtName.Columns.Add("Tell", System.Type.GetType("System.String"))
        If Not DtName.Columns.Contains("Mobile") Then DtName.Columns.Add("Mobile", System.Type.GetType("System.String"))
        If Not DtName.Columns.Contains("City") Then DtName.Columns.Add("City", System.Type.GetType("System.String"))

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

    Private Sub DGV_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowEnter
        Try
            Me.SetButton(DGV.Item("Cln_Type", e.RowIndex).Value, DGV.Item("Cln_TypeSanad", e.RowIndex).Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetButton(ByVal Type As Long, ByVal Type_Sanad As Long)
        Try
            Toolfactor.Visible = False
            ToolChk.Visible = False
            If (Type >= 0 And Type <= 8) And Type_Sanad = 0 Then Toolfactor.Visible = True
            If Type_Sanad = 7 Then ToolChk.Visible = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Moein_People", "SetButton")
        End Try
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
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            Me.Enabled = False
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            TxtCode.Text = IdKala
            TxtNamFac.Text = Tmp_String1
            TxtAddress.Text = If(String.IsNullOrEmpty(TmpAddress), Tmp_TwoGroup, Tmp_TwoGroup & "  " & TmpAddress)
            TxtTell.Text = If(String.IsNullOrEmpty(TmpTell1), "", TmpTell1)
            TxtMobile.Text = If(String.IsNullOrEmpty(TmpTell2), "", TmpTell2)
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetMoein(ByVal id As Long)
        Try
            Dim Sql_Str As String = ""
            If ChkTime.Checked = False And ChkId.Checked = False Then
                Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " UNION SELECT id=0,d_date=N'',Disc=N'مانده اول دوره', BedMon=Case When [State]=N'بدهکار' THEN AllMoney When [State]=N'بستانکار' THEN 0 Else 0 END,BesMon=Case When [State]=N'بدهکار' THEN 0 When [State]=N'بستانکار' THEN AllMoney Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 from Define_People WHERE ID =" & id & " ORDER BY D_date ,Id ,Type_Sanad "
            ElseIf ChkTime.Checked = True And ChkId.Checked = False Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION (SELECT id=0,d_date=N'',Disc=N'مانده اول دوره تا قبل از" & FarsiDate1.ThisText & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & id & " AND T=0 AND D_Date<'" & FarsiDate1.ThisText & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & id & " AND T=1 AND D_Date<'" & FarsiDate1.ThisText & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id ,Type_Sanad"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " AND (D_date>=N'" & FarsiDate1.ThisText & "')UNION (SELECT id=0,d_date=N'',Disc=N'مانده اول دوره تا قبل از" & FarsiDate1.ThisText & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & id & " AND T=0 AND D_Date<'" & FarsiDate1.ThisText & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & id & " AND T=1 AND D_Date<'" & FarsiDate1.ThisText & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id ,Type_Sanad"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION SELECT id=0,d_date=N'',Disc=N'مانده اول دوره', BedMon=Case When [State]=N'بدهکار' THEN AllMoney When [State]=N'بستانکار' THEN 0 Else 0 END,BesMon=Case When [State]=N'بدهکار' THEN 0 When [State]=N'بستانکار' THEN AllMoney Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 from Define_People WHERE ID =" & id & " ORDER BY D_date ,Id ,Type_Sanad "
                End If
            ElseIf ChkTime.Checked = False And ChkId.Checked = True Then
                If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " AND (Id>=" & TxtId1.Text & " AND Id <=" & TxtId2.Text & ") UNION (SELECT id=0,d_date=N'',Disc=N'مانده اول دوره تا قبل از سند" & TxtId1.Text & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & id & " AND T=0 AND Id<" & TxtId1.Text & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & id & " AND T=1 AND Id<" & TxtId1.Text & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id ,Type_Sanad"
                ElseIf ChkAzId.Checked = True And ChkTaId.Checked = False Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " AND (Id>=" & TxtId1.Text & ")UNION (SELECT id=0,d_date=N'',Disc=N'مانده اول دوره تا قبل از سند" & TxtId1.Text & "', BedMon=Case When AllMoein.Moein>=0 THEN AllMoein.Moein Else 0 END,BesMon=Case When AllMoein.Moein<0 THEN AllMoein.Moein*(-1) Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 FROM (SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & id & " AND T=0 AND Id<" & TxtId1.Text & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & id & " AND T=1 AND Id<" & TxtId1.Text & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & id & " )As AllOneMoney )As One)AllMoein) ORDER BY D_date ,Id ,Type_Sanad"
                ElseIf ChkAzId.Checked = False And ChkTaId.Checked = True Then
                    Sql_Str = "SELECT Id , D_date, disc, BedMon=Case When T=0 THEN mon Else 0 END, BesMon=Case When T=1 THEN mon Else 0 END,T=N'  ',Mandeh=0.0,IdUser, [Type], Number_Type, Type_Sanad FROM Moein_People WHERE IDPeople =" & id & " AND (Id <=" & TxtId2.Text & ") UNION SELECT id=0,d_date=N'',Disc=N'مانده اول دوره', BedMon=Case When [State]=N'بدهکار' THEN AllMoney When [State]=N'بستانکار' THEN 0 Else 0 END,BesMon=Case When [State]=N'بدهکار' THEN 0 When [State]=N'بستانکار' THEN AllMoney Else 0 END,T=N'  ',Mandeh=0.0,IdUser=-1,[TYPE]=-1,Number_Type=-1,Type_Sanad=-1 from Define_People WHERE ID =" & id & " ORDER BY D_date ,Id ,Type_Sanad "
                End If
            End If
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand(Sql_Str, ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            '''''''''''''''''''''''''''''' Create new DataTable
            NewDt.Clear()
            NewDt.Columns.Clear()
            NewDt.Columns.Add("Id", Type.GetType("System.String"))
            NewDt.Columns.Add("D_date", Type.GetType("System.String"))
            NewDt.Columns.Add("Disc", Type.GetType("System.String"))
            NewDt.Columns.Add("Kol", Type.GetType("System.String"))
            NewDt.Columns.Add("Joz", Type.GetType("System.String"))
            NewDt.Columns.Add("Fe", Type.GetType("System.Double"))
            NewDt.Columns.Add("BedMon", Type.GetType("System.Double"))
            NewDt.Columns.Add("BesMon", Type.GetType("System.Double"))
            NewDt.Columns.Add("T", Type.GetType("System.String"))
            NewDt.Columns.Add("Mandeh", Type.GetType("System.Double"))
            NewDt.Columns.Add("Type", Type.GetType("System.Double"))
            NewDt.Columns.Add("Number_Type", Type.GetType("System.Double"))
            NewDt.Columns.Add("Type_Sanad", Type.GetType("System.Double"))
            ''''''''''''''''''''''''''''''' Fill new DataTable
            For i As Integer = 0 To dt.Rows.Count - 1
                If ((dt.Rows(i).Item("Type") >= 0 And dt.Rows(i).Item("Type") <= 8) And dt.Rows(i).Item("Type_Sanad") = 0) Then
                    Me.SetKalaMoein(NewDt, dt.Rows(i).Item("Id"), dt.Rows(i).Item("Disc"), dt.Rows(i).Item("D_Date"), dt.Rows(i).Item("Type"), dt.Rows(i).Item("Number_Type"), dt.Rows(i).Item("Type_Sanad"), If(dt.Rows(i).Item("BedMon") = 0, dt.Rows(i).Item("BesMon"), dt.Rows(i).Item("BedMon")))
                Else
                    Dim row As DataRow = NewDt.NewRow
                    row.Item("Id") = dt.Rows(i).Item("Id")
                    row.Item("D_date") = dt.Rows(i).Item("D_date")
                    row.Item("Disc") = dt.Rows(i).Item("Disc")
                    row.Item("Kol") = 0
                    row.Item("Joz") = 0
                    row.Item("Fe") = 0
                    row.Item("BedMon") = dt.Rows(i).Item("BedMon")
                    row.Item("BesMon") = dt.Rows(i).Item("BesMon")
                    row.Item("T") = ""
                    row.Item("Mandeh") = 0
                    row.Item("Type") = dt.Rows(i).Item("Type")
                    row.Item("Number_Type") = dt.Rows(i).Item("Number_Type")
                    row.Item("Type_Sanad") = dt.Rows(i).Item("Type_Sanad")
                    NewDt.Rows.Add(row)
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''
            If ChkOne.Checked = True Then
                NewDt.Columns("BesMon").ReadOnly = False
                NewDt.Columns("BedMon").ReadOnly = False
                NewDt.Rows(0).Item("BesMon") = 0
                NewDt.Rows(0).Item("BedMon") = 0
                NewDt.AcceptChanges()
                SetBedBesTableMoein(NewDt)
                NewDt.Rows(0).Delete()
                NewDt.AcceptChanges()
            Else
                SetBedBesTableMoein(NewDt)
            End If
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            DGV.DataSource = NewDt
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Moein_KalaPeople", "SetMoein")
            Me.Close()
        End Try
    End Sub

    Private Sub SetKalaMoein(ByRef NewDt As DataTable, ByVal Id As Long, ByVal disc As String, ByVal D_date As String, ByVal Type As Long, ByVal Number_Type As Long, ByVal Type_Sanad As Long, ByVal Mon As Double)
        Try
            Dim row As DataRow = NewDt.NewRow
            row.Item("Id") = Id
            row.Item("D_date") = D_date
            row.Item("Disc") = disc + "  جمع فاکتور : " & FormatNumber(Mon, 0)
            row.Item("Kol") = 0
            row.Item("Joz") = 0
            row.Item("Fe") = 0
            row.Item("BedMon") = 0
            row.Item("BesMon") = 0
            row.Item("T") = ""
            row.Item("Mandeh") = 0
            row.Item("Type") = Type
            row.Item("Number_Type") = Number_Type
            row.Item("Type_Sanad") = Type_Sanad
            NewDt.Rows.Add(row)
            Dim ListName As String = GetTableNameFactor(Type, "LIST")
            Dim KalaName As String = GetTableNameFactor(Type, "KALA")
            Dim str_sql As String = ""

            If Type = 8 Then
                str_sql = "SELECT  KolCount, JozCount=0, Fe, Mon, N'کالای خدماتی -' + nam + ISNULL(' - ' + kaladisc,'') As NamKala FROM  KalaFactorService  INNER JOIN Define_Service ON KalaFactorService .IdService = Define_Service.ID WHERE IdFactor =" & Number_Type
            Else
                str_sql = "SELECT KolCount,JozCount,Fe,Mon, NamOne +'-'+ NamTwo+ ' - ' + Nam + ISNULL(' - ' + kaladisc,'') As NamKala FROM " & KalaName & " INNER JOIN Define_Kala ON " & KalaName & ".IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE IdFactor =" & Number_Type & " UNION All SELECT  KolCount, JozCount, Fe, Mon, N'کالای خدماتی -' + nam + ISNULL(' - ' + kaladisc,'') As NamKala FROM  " & KalaName & " INNER JOIN Define_Service ON " & KalaName & ".IdService = Define_Service.ID WHERE IdFactor =" & Number_Type
            End If
            Dim TmpDt As New DataTable
            Using Cmd As New SqlCommand(str_sql, ConectionBank)
                TmpDt.Load(Cmd.ExecuteReader)
            End Using
            If TmpDt.Rows.Count > 0 Then
                For i As Integer = 0 To TmpDt.Rows.Count - 1
                    Dim Tmprow As DataRow = NewDt.NewRow
                    Tmprow.Item("Id") = ""
                    Tmprow.Item("D_date") = ""
                    Tmprow.Item("Disc") = TmpDt.Rows(i).Item("NamKala")
                    Tmprow.Item("Kol") = TmpDt.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    Tmprow.Item("Joz") = TmpDt.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    Tmprow.Item("Fe") = TmpDt.Rows(i).Item("Fe")
                    Tmprow.Item("BedMon") = If(Type = 1 Or Type = 3 Or Type = 8, TmpDt.Rows(i).Item("Mon"), 0)
                    Tmprow.Item("BesMon") = If(Type = 0 Or Type = 4, TmpDt.Rows(i).Item("Mon"), 0)
                    Tmprow.Item("T") = ""
                    Tmprow.Item("Mandeh") = 0
                    Tmprow.Item("Type") = Type
                    Tmprow.Item("Number_Type") = Number_Type
                    Tmprow.Item("Type_Sanad") = Type_Sanad
                    NewDt.Rows.Add(Tmprow)
                Next i
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Moein_KalaPeople", "SetKalaMoein")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_MoeinKalai.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnMoein.Enabled = True Then Call BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Call BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F6 Then
            If DGV.RowCount > 0 Then
                If (DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value >= 0 And DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value <= 8) And DGV.Item("Cln_TypeSanad", DGV.CurrentRow.Index).Value = 0 Then
                    Using frmshow As New ShowFactor
                        frmshow.LFactor.Text = DGV.Item("Cln_NumberType", DGV.CurrentRow.Index).Value
                        frmshow.LState.Text = DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value
                        frmshow.ShowDialog()
                    End Using
                End If
                If DGV.Item("Cln_TypeSanad", DGV.CurrentRow.Index).Value = 7 Then
                    Using frmshow As New ShowChk
                        frmshow.StrSql = "SELECT  Id,[GetDate], PayDate, MoneyChk, NumChk, Disc, Stat=Case Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END ,Nam=Case  WHEN Current_Type=14 THEN N'اموال' WHEN Current_Type=15 THEN N'درآمد' WHEN Current_Type=16 THEN N'هزینه متفرقه' WHEN Current_Type=17 THEN N'هزینه ف.خرید' WHEN Current_Type=18 THEN N'صندوق' WHEN Current_Type=19 THEN N'امور چک' WHEN Current_Type=20 THEN N'بانک به بانک' WHEN Current_Type<=13 THEN (SELECT Nam FROM Define_People WHERE Id=(SELECT  Current_IdPeople  FROM Chk_Id WHERE Chk_Id.Id=Chk_Get_Pay.ID ) ) ELSE N'نا مشخص' END  FROM  Chk_Get_Pay WHERE ([Type] =" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & " OR Current_Type =" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & ") AND (Number_Type =" & DGV.Item("Cln_NumberType", DGV.CurrentRow.Index).Value & " Or Current_Number_Type =" & DGV.Item("Cln_NumberType", DGV.CurrentRow.Index).Value & ") And Activ =1"
                        frmshow.SumStrSql = "SELECT  PayDate,COUNT(*) AS C_Count, ISNULL(SUM(MoneyChk),0) As MoneyChk FROM  Chk_Get_Pay WHERE ([Type] =" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & " OR Current_Type =" & DGV.Item("Cln_Type", DGV.CurrentRow.Index).Value & ") AND (Number_Type =" & DGV.Item("Cln_NumberType", DGV.CurrentRow.Index).Value & " Or Current_Number_Type =" & DGV.Item("Cln_NumberType", DGV.CurrentRow.Index).Value & ") And Activ =1 GROUP By PayDate"
                        frmshow.ShowDialog()
                    End Using
                End If
            End If
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Moein_KalaPeople", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnMoein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoein.Click
        If String.IsNullOrEmpty(TxtIdName.Text.Trim) Or String.IsNullOrEmpty(TxtName.Text.Trim) Then
            MessageBox.Show("هیچ طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Enabled = True
            TxtName.Focus()
            Exit Sub
        End If
        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                ChkTaDate.Checked = True
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
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
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "معین مالی کالایی", "نمایش معین", "نمایش معین مالی کالایی طرف حساب :" & TxtName.Text, "")
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
                AllMoein(AllMoein.Length - 1).d_date = DGV.Item("Cln_Date", i).Value
                AllMoein(AllMoein.Length - 1).Disc = DGV.Item("Cln_Disc", i).Value
                AllMoein(AllMoein.Length - 1).Kol = DGV.Item("Cln_Kol", i).Value
                AllMoein(AllMoein.Length - 1).Joz = DGV.Item("Cln_Joz", i).Value
                AllMoein(AllMoein.Length - 1).Fe = CDbl(DGV.Item("Cln_Fe", i).Value)
                AllMoein(AllMoein.Length - 1).BedMon = CDbl(DGV.Item("Cln_Bed", i).Value)
                AllMoein(AllMoein.Length - 1).BesMon = CDbl(DGV.Item("Cln_Bes", i).Value)
                AllMoein(AllMoein.Length - 1).T = DGV.Item("Cln_T", i).Value
                AllMoein(AllMoein.Length - 1).Mandeh = CDbl(DGV.Item("Cln_Mandeh", i).Value)
                AllMoein(AllMoein.Length - 1).Type = DGV.Item("Cln_Type", i).Value
                AllMoein(AllMoein.Length - 1).Number_Type = DGV.Item("Cln_NumberType", i).Value
                AllMoein(AllMoein.Length - 1).Type_Sanad = DGV.Item("Cln_TypeSanad", i).Value
            End If
        Next

        If AllMoein.Length > 0 Then
            Tmp_Namkala = TxtNamFac.Text + " " + TxtName.Text.Trim

            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            FrmPrint.Str2 = ""
            Dim Tmpdt As New DataTable
            Tmpdt.Clear()
            If Not Tmpdt.Columns.Contains("d_date") Then Tmpdt.Columns.Add("d_date", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Disc") Then Tmpdt.Columns.Add("Disc", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Kol") Then Tmpdt.Columns.Add("Kol", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Joz") Then Tmpdt.Columns.Add("Joz", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Fe") Then Tmpdt.Columns.Add("Fe", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("BedMon") Then Tmpdt.Columns.Add("BedMon", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("BesMon") Then Tmpdt.Columns.Add("BesMon", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("T") Then Tmpdt.Columns.Add("T", Type.GetType("System.String"))
            If Not Tmpdt.Columns.Contains("Mandeh") Then Tmpdt.Columns.Add("Mandeh", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("Type") Then Tmpdt.Columns.Add("Type", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("Number_Type") Then Tmpdt.Columns.Add("Number_Type", Type.GetType("System.Double"))
            If Not Tmpdt.Columns.Contains("Type_Sanad") Then Tmpdt.Columns.Add("Type_Sanad", Type.GetType("System.Double"))

            Dim bed As Double = 0
            Dim bes As Double = 0

            For i As Integer = 0 To AllMoein.Length - 1
                Dim row As DataRow = Tmpdt.NewRow
                row.Item("d_date") = AllMoein(i).d_date
                row.Item("Disc") = AllMoein(i).Disc
                row.Item("Kol") = AllMoein(i).Kol
                row.Item("Joz") = AllMoein(i).Joz
                row.Item("Fe") = AllMoein(i).Fe
                row.Item("BedMon") = AllMoein(i).BedMon
                row.Item("BesMon") = AllMoein(i).BesMon
                row.Item("T") = AllMoein(i).T
                row.Item("Mandeh") = AllMoein(i).Mandeh
                row.Item("Type") = AllMoein(i).Type
                row.Item("Number_Type") = AllMoein(i).Number_Type
                row.Item("Type_Sanad") = AllMoein(i).Type_Sanad
                Tmpdt.Rows.Add(row)
                bed += AllMoein(i).BedMon
                bes += AllMoein(i).BesMon
            Next

            SetBedBesTableMoein(Tmpdt)
            Tmp_String1 = If((bed - bes) > 0, "بد", "بس")
            Tmp_Mon = If((bed - bes) > 0, (bed - bes), (bed - bes) * -1)

            FrmPrint.Str2 = "سندهای انتخابی"

            FrmPrint.DtMoeinKalaPeople = Tmpdt

        Else
            Tmp_Namkala = TxtNamFac.Text + " " + TxtName.Text.Trim
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

            FrmPrint.DtMoeinKalaPeople = NewDt
        End If

        FrmPrint.IdFactor = If(String.IsNullOrEmpty(TxtMobile.Text), "", TxtMobile.Text.Trim) & If(String.IsNullOrEmpty(TxtTell.Text), "", " " & TxtTell.Text.Trim)
        FrmPrint.Lend = If(String.IsNullOrEmpty(TxtAddress.Text), "", TxtAddress.Text.Trim)

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "معین مالی کالایی", "چاپ گزارش", "چاپ معین مالی کالایی طرف حساب :" & TxtName.Text, "")
        FrmPrint.CHoose = "MOEINKALAPEOPLE"
        FrmPrint.ShowDialog()
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged

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

    Private Sub ChkFac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call BtnMoein_Click(Nothing, Nothing)
    End Sub

    Private Sub ChkOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOne.CheckedChanged
        Call BtnMoein_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using FrmAdVance As New People_List
            Me.Enabled = False
            Array.Resize(AllSelectKala, 0)
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.Condition2 = "1"
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For j As Integer = 0 To AllSelectKala.Length - 1
                        Dim row() As DataRow = DtName.Select("Id=" & AllSelectKala(j).IdKala)
                        If row.Length <= 0 Then
                            Dim newrow As DataRow = DtName.NewRow
                            newrow("Id") = AllSelectKala(j).IdKala
                            newrow("Name") = AllSelectKala(j).Namekala
                            newrow("NamFac") = AllSelectKala(j).str1
                            newrow("Address") = AllSelectKala(j).str2
                            newrow("Tell") = AllSelectKala(j).str3
                            newrow("Mobile") = AllSelectKala(j).str4
                            newrow("City") = AllSelectKala(j).TwoGroup
                            DtName.Rows.Add(newrow)
                        End If
                    Next
                End If

                CmbMoein.DataSource = DtName
                CmbMoein.DisplayMember = "Name"
                CmbMoein.ValueMember = "Id"
                Me.Enabled = True
                Call CmbMoein_SelectedIndexChanged(Nothing, Nothing)
                CmbMoein.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
                Me.Enabled = True
                CmbMoein.Focus()
            End Try
        End Using
    End Sub

    Private Sub CmbMoein_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbMoein.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub CmbMoein_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbMoein.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        e.Handled = True
        CmbMoein.Focus()
        If Tmp_Namkala <> "" Then
            Me.Enabled = False
            TxtName.Text = Tmp_Namkala
            CmbMoein.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            TxtCode.Text = IdKala
            TxtNamFac.Text = Tmp_String1
            TxtAddress.Text = If(String.IsNullOrEmpty(TmpAddress), Tmp_TwoGroup, Tmp_TwoGroup & "  " & TmpAddress)
            TxtTell.Text = If(String.IsNullOrEmpty(TmpTell1), "", TmpTell1)
            TxtMobile.Text = If(String.IsNullOrEmpty(TmpTell2), "", TmpTell2)
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CmbMoein_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMoein.SelectedIndexChanged
        Try
            Dim row() As DataRow = DtName.Select("Id=" & CmbMoein.SelectedValue)
            If row.Length > 0 Then
                TxtName.Text = row(0).Item("Name")
                TxtIdName.Text = row(0).Item("Id")
                TxtCode.Text = row(0).Item("Id")
                TxtNamFac.Text = row(0).Item("NamFac")
                TxtAddress.Text = If(String.IsNullOrEmpty(row(0).Item("Address")), row(0).Item("City"), row(0).Item("City") & "  " & row(0).Item("Address"))
                TxtTell.Text = If(String.IsNullOrEmpty(row(0).Item("Tell")), "", row(0).Item("Tell"))
                TxtMobile.Text = If(String.IsNullOrEmpty(row(0).Item("Mobile")), "", row(0).Item("Mobile"))
                Call BtnMoein_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class