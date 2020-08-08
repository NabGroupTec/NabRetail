Imports System.Data.SqlClient
Public Class FrmPathPeople

    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Dim ds_User As New DataTable
    Dim dta_User As New SqlDataAdapter()

    Private Sub GetVisitorList()
        Try
            ds_User.Clear()
            If Not dta_User Is Nothing Then
                dta_User.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_User = New SqlDataAdapter("SELECT Id, Nam FROM  Define_Visitor", DataSource)
            dta_User.Fill(ds_User)
            CmbBox.DataSource = ds_User
            CmbBox.DisplayMember = "Nam"
            CmbBox.ValueMember = "ID"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportFroshVisitor", "GetVisitorList")
        End Try
    End Sub

    Private Sub GetGroup()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("SELECT Id, nam FROM Define_Group_P", DataSource)
            Dta.Fill(Ds, "Define_Group_P")
            DGV.AutoGenerateColumns = False
            DGV.DataSource = Ds.Tables("Define_Group_P")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPathPeople", "GetGroup")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        BtnSave.Focus()
        Try

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
                If ChkPart.Checked = True Then
                    If String.IsNullOrEmpty(CmbPart.Text) Then
                        MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CmbPart.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If ChkVisit.Checked = True Then
                If CmbBox.Text = "" Then
                    MessageBox.Show("ویزیتوری جهت تهیه گزارش انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbBox.Focus()
                    Exit Sub
                End If
            End If
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("محدوده تاریخ مشخص نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If ChkAzDate.Checked = True Then
                    If String.IsNullOrEmpty(FarsiDate1.ThisText) Then
                        MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkTaDate.Checked = True Then
                    If String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                        MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

            End If
            If DGV.RowCount <= 0 Then
                MessageBox.Show("گروه ویژه ایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Group As String = ""
            If ChkGroup.Checked = True Then
                Dim CountGroup As Long = 0
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Select", i).Value = True Then
                        Group &= "IdGroup=" & DGV.Item("Cln_IdP", i).Value & " OR "
                        CountGroup += 1
                    End If
                Next

                If CountGroup = DGV.RowCount Then
                    Group = ""
                ElseIf CountGroup <= 0 Then
                    MessageBox.Show("گروه ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Group = Group.Substring(0, Group.Length - 4)
                    Group = " AND (" & Group & ")"
                End If
            End If

            Dim Visitor As String = If(ChkVisit.Checked = True, " AND (IdVisitor=" & CmbBox.SelectedValue & ")", "")
            Dim Part As String = ""
            If ChkPart.Checked = True Then
                Part = " (IdPart=" & CmbPart.SelectedValue & ")"
            ElseIf ChkCity.Checked = True Then
                Part = " (IdCity=" & CmbCity.SelectedValue & ")"
            Else
                Part = " (IdOstan=" & CmbOstan.SelectedValue & ")"
            End If

            Dim dat As String = ""
            Dim Olddat As String = ""
            Dim NewDat As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
                    Olddat = " AND D_date >=N'" & Get3MonthOld(FarsiDate2.ThisText) & "' "
                    NewDat = " AND D_date <=N'" & FarsiDate2.ThisText & "' "
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
                    Olddat = " AND D_date >=N'" & Get3MonthOld(GetDate()) & "' "
                    NewDat = " AND D_date <=N'" & GetDate() & "' "
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
                    Olddat = " AND D_date >=N'" & Get3MonthOld(FarsiDate2.ThisText) & "' "
                    NewDat = " AND D_date <=N'" & FarsiDate2.ThisText & "' "
                End If
            Else
                Olddat = " AND D_date >=N'" & Get3MonthOld(GetDate()) & "' "
                NewDat = " AND D_date <=N'" & GetDate() & "' "
            End If

            Dim Sort As String = ""
            If Rdoname.Checked = True Then
                Sort = " ORDER BY Nam"
            ElseIf Rdodate.Checked = True Then
                Sort = " ORDER BY EndSell"
            ElseIf RdoAdd.Checked = True Then
                Sort = " ORDER BY Addres"
            End If

            Tmp_OneGroup = ""
            Tmp_Namkala = ""
            Tmp_String1 = ""
            Tmp_String2 = ""
            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مسیر مشتریان", "تهیه گزارش", If(ChkVisit.Checked = True, "مسیر مشتریان ویزیتور:" & CmbBox.Text, ""), "")

            Using FrmPrint As New FrmPrint
                Tmp_OneGroup = If(ChkVisit.Checked = True, CmbBox.Text, "")
                Tmp_Namkala = CmbOstan.Text & If(ChkCity.Checked = True, " ، " + CmbCity.Text, "") & If(ChkPart.Checked = True, " ، " + CmbPart.Text, "")
                Tmp_String1 = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                Tmp_String2 = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
                FrmPrint.PrintSQl = "SELECT ID,Nam ,Tell ,Addres ,GValueMon ,GroupNam ,Rate,(SELECT  ISNULL(SUM(MoneyChk),0) As GetChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0 and (Current_State =0 or Current_State =4)  AND (Current_IdPeople =ListP.ID OR IdPeople =ListP.ID)) As GetChk,(SELECT ISNULL(SUM(OnMoney+bed+bes),0) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =ListP.ID AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =ListP.ID AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=ListP.ID )As AllOneMoney )As One)AS Moein,(0.0) As DelayMon,(SELECT ISNULL(MAX(D_date),'') FROM  ListFactorSell WHERE (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3) AND IdName =ListP.ID) AS EndSell,(SELECT COUNT(IDfactor) As C_Fac FROM (SELECT IdFactor FROM (SELECT  IdFactor FROM  ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1)  AND ListFactorSell.IdName =ListP.ID " & Olddat & NewDat & ") As ListExit) AS EndList) AS C_Fac,(SELECT SUM (C_fac) As C_Kala FROM (SELECT (SELECT COUNT(DISTINCT KalaFactorSell.IdKala) FROM KalaFactorSell WHERE IdFactor =ListExit.IdFactor) As C_Fac FROM (SELECT  IdFactor FROM  ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1)  AND ListFactorSell.IdName =ListP.ID " & Olddat & NewDat & ") As ListExit) AS EndList)As C_Kala,(SELECT ISNULL(SUM(AllMon-kasri-backKala-Discount),0) As AllMon FROM (SELECT (SELECT ISNULL(SUM(KalaFactorSell.Mon),0) As Mon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdFactor =ListExit.IdFactor )As AllMon,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =ListExit.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =ListExit.IdFactor)As Backkala,(SELECT (ISNULL(SUM(DarsadMon),0)+ISNULL(SUM(Discount),0) +ISNULL(SUM(MonDec),0)+(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) -ISNULL(SUM(MonAdd),0))  FROM KalaFactorSell INNER JOIN ListFactorSell ON ListFactorSell.IdFactor =KalaFactorSell.IdFactor  WHERE ListFactorSell.IdFactor =ListExit.IdFactor) As Discount FROM (SELECT  IdFactor FROM  ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1)  AND ListFactorSell.IdName =ListP.ID " & Olddat & NewDat & ") As ListExit) AS EndList) As AllMon FROM (SELECT  ID,Nam,ISNULL(Tell1,'')+ '-' + ISNULL(Tell2,'') AS Tell,ISNULL([Address],'') As Addres ,GValueMon ,Rate,GroupNam=CASE WHEN ChkIdGroup='True' THEN (SELECT Nam FROM Define_Group_P WHERE Define_Group_P.Id =IdGroup)  ELSE N'' END FROM Define_People WHERE  " & Part & Group & " AND ID  IN (SELECT DISTINCT IdName FROM ListFactorSell WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 " & Visitor & dat & ")) As ListP " & Sort
                FrmPrint.CHoose = "PATHPEOPLE"
                FrmPrint.ShowDialog()
            End Using
            Me.Enabled = True

        Catch ex As Exception

        End Try
    End Sub
    Private Function Get3MonthOld(ByVal Dat As String) As String
        Try
            Dim Tmpdat As String = Dat
            For i As Integer = 1 To 3
                Tmpdat = DECMonth(Tmpdat)
            Next
            Return Tmpdat
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get3MonthOld")
            Return Dat
        End Try
    End Function
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepPathMoshtari.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSendSMS.Enabled = True Then BtnSendSMS_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmDaftarKol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_Ostan")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_City")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_Part")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstan.KeyDown
        If CmbOstan.DroppedDown = False Then
            CmbOstan.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbCity.Focus()
        End If
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
            Me.Get_City(CmbOstan.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCity.KeyDown
        If CmbCity.DroppedDown = False Then
            CmbCity.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbPart.Focus()
        End If
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        Try
            CmbPart.DataSource = Nothing
            Me.Get_Part(CmbOstan.SelectedValue, CmbCity.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbPart.KeyDown
        If CmbPart.DroppedDown = False Then
            CmbPart.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub FrmLastSell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F130")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
                Try
                    If Access_Form.Substring(3, 1) = 0 Then
                        BtnSendSMS.Enabled = False
                    End If
                Catch ex As Exception
                    BtnSendSMS.Enabled = False
                End Try
            End If
        End If
        Me.GetGroup()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        Me.GetVisitorList()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.Get_Ostan()
        CmbOstan_SelectedIndexChanged(Nothing, Nothing)
        CmbCity_SelectedIndexChanged(Nothing, Nothing)
        CmbOstan.Focus()
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
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

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If ChkGroup.Checked = False Then
            GroupBox7.Enabled = False
        Else
            GroupBox7.Enabled = True
        End If
    End Sub

    Private Sub ChkVisit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisit.CheckedChanged
        If ChkVisit.Checked = True Then
            CmbBox.Enabled = True
        Else
            CmbBox.Enabled = False
        End If
    End Sub

    Private Sub ChkCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCity.CheckedChanged
        If ChkCity.Checked = False Then
            ChkPart.Checked = False
            ChkPart.Enabled = False
        Else
            ChkPart.Enabled = True
        End If
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendSMS.Click
        If SMS = False Then
            MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        BtnSave.Focus()
        Try

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
                If ChkPart.Checked = True Then
                    If String.IsNullOrEmpty(CmbPart.Text) Then
                        MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CmbPart.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If ChkVisit.Checked = True Then
                If CmbBox.Text = "" Then
                    MessageBox.Show("ویزیتوری جهت تهیه گزارش انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbBox.Focus()
                    Exit Sub
                End If
            End If
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("محدوده تاریخ مشخص نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If ChkAzDate.Checked = True Then
                    If String.IsNullOrEmpty(FarsiDate1.ThisText) Then
                        MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkTaDate.Checked = True Then
                    If String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                        MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

            End If
            If DGV.RowCount <= 0 Then
                MessageBox.Show("گروه ویژه ایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Group As String = ""
            If ChkGroup.Checked = True Then
                Dim CountGroup As Long = 0
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Select", i).Value = True Then
                        Group &= "IdGroup=" & DGV.Item("Cln_IdP", i).Value & " OR "
                        CountGroup += 1
                    End If
                Next

                If CountGroup = DGV.RowCount Then
                    Group = ""
                ElseIf CountGroup <= 0 Then
                    MessageBox.Show("گروه ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Group = Group.Substring(0, Group.Length - 4)
                    Group = " AND (" & Group & ")"
                End If
            End If

            Dim Visitor As String = If(ChkVisit.Checked = True, " AND (IdVisitor=" & CmbBox.SelectedValue & ")", "")
            Dim Part As String = ""
            If ChkPart.Checked = True Then
                Part = " (IdPart=" & CmbPart.SelectedValue & ")"
            ElseIf ChkCity.Checked = True Then
                Part = " (IdCity=" & CmbCity.SelectedValue & ")"
            Else
                Part = " (IdOstan=" & CmbOstan.SelectedValue & ")"
            End If

            Dim dat As String = ""
            Dim Olddat As String = ""
            Dim NewDat As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
                    Olddat = " AND D_date >=N'" & Get3MonthOld(FarsiDate2.ThisText) & "' "
                    NewDat = " AND D_date <=N'" & FarsiDate2.ThisText & "' "
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
                    Olddat = " AND D_date >=N'" & Get3MonthOld(GetDate()) & "' "
                    NewDat = " AND D_date <=N'" & GetDate() & "' "
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
                    Olddat = " AND D_date >=N'" & Get3MonthOld(FarsiDate2.ThisText) & "' "
                    NewDat = " AND D_date <=N'" & FarsiDate2.ThisText & "' "
                End If
            Else
                Olddat = " AND D_date >=N'" & Get3MonthOld(GetDate()) & "' "
                NewDat = " AND D_date <=N'" & GetDate() & "' "
            End If

            Dim Sort As String = ""
            If Rdoname.Checked = True Then
                Sort = " ORDER BY Nam"
            ElseIf Rdodate.Checked = True Then
                Sort = " ORDER BY EndSell"
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مسیر مشتریان", "SMS ارسال", If(ChkVisit.Checked = True, "مسیر مشتریان ویزیتور:" & CmbBox.Text, ""), "")
            Using frms As New SendPathSMS
                frms.Query = "SELECT Nam ,Tell,(SELECT ISNULL(MAX(D_date),'') FROM  ListFactorSell WHERE (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3) AND IdName =ListP.ID) AS EndSell FROM (SELECT  ID,Nam,ISNULL(Tell2,'') AS Tell FROM Define_People WHERE  " & Part & Group & " AND ID  IN (SELECT DISTINCT IdName FROM ListFactorSell WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 " & Visitor & dat & ")) As ListP " & Sort
                frms.ShowDialog()
            End Using

        Catch ex As Exception

        End Try

    End Sub
End Class