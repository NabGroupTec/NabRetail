Imports System.Data.SqlClient
Public Class FrmAllPrint
    
    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                DGV1.Item("Cln_Select", i).Value = ChkAll.Checked
            Next
        End If
    End Sub

    Private Sub FrmAllPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmAllPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV1.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ChkAll.Checked = True
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            BtnPrint.Focus()
            DGV1.EndEdit()
            BtnPrint.Enabled = False
            ChkAll.Enabled = False
            DGV1.Columns("Cln_Select").ReadOnly = True
            Dim Count_fac As Long = GetCountPrint("FACTOR")
            Dim count As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then
                    count += 1
                    If Factor(GetStateFactor(DGV1.Item("Cln_TypeFac", i).Value), DGV1.Item("Cln_Idf", i).Value, DGV1.Item("Cln_Lend", i).Value, Count_fac) = True Then
                        DGV1.Item("Cln_Print", i).Value = True
                        DGV1.Item("Cln_Select", i).Value = False
                        DGV1.Item("Cln_Print", i).Selected = True
                    End If
                End If
            Next
            If count > 0 Then
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "چاپ متوالی", "", "")
                MessageBox.Show("عملیات ارسال به چاپگر به پایان رسید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("فاکتوری برای چاپ انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            BtnPrint.Enabled = True
            ChkAll.Enabled = True
            DGV1.Columns("Cln_Select").ReadOnly = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAllPrint", "BtnPrint_Click")
            DGV1.Columns("Cln_Select").ReadOnly = False
        End Try
    End Sub
    Private Function Factor(ByVal state As String, ByVal Idfactor As Long, ByVal Lend As Double, ByVal Count_fac As Long) As Boolean
        Dim PrintSQL As String = ""
        Try
            If state = 0 Or state = 2 Then
                PrintSQL = "SELECT  KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.IdService,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBuy.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.IdService,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBuy.IdService  = Define_Service .ID  WHERE ListFactorBuy.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorBuy.Id"
            ElseIf state = 1 Then
                PrintSQL = "SELECT  KalaFactorBackBuy.Id,KalaFactorBackBuy.IdKala,KalaFactorBackBuy.IdService,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorBackBuy.Id,KalaFactorBackBuy.Idkala,KalaFactorBackBuy.IdService,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBackBuy.IdService  = Define_Service .ID  WHERE ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorBackBuy.Id "
            ElseIf state = 3 Or state = 5 Or state = 7 Then
                PrintSQL = "SELECT  KalaFactorSell.Id,KalaFactorSell.IdKala,KalaFactorSell.IdService,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorSell.Id,KalaFactorSell.Idkala,KalaFactorSell.IdService,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorSell.Id "
            ElseIf state = 4 Then
                PrintSQL = "SELECT  KalaFactorBackSell.Id,KalaFactorBackSell.IdKala,KalaFactorBackSell.IdService,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackSell.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorBackSell.Id,KalaFactorBackSell.IdKala,KalaFactorBackSell.IdService,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Service  ON KalaFactorBackSell.IdService  = Define_Service .ID  WHERE ListFactorBackSell.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorBackSell.Id "
            ElseIf state = 6 Then
                PrintSQL = "SELECT  KalaFactorDamage.Id,KalaFactorDamage.IdKala,IdService=0,KalaFactorDamage.KolCount, KalaFactorDamage.JozCount, KalaFactorDamage.Fe,DarsadDiscount=0,DarsadMon=0, KalaFactorDamage.Mon,KalaFactorDamage.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorDamage INNER JOIN KalaFactorDamage ON ListFactorDamage.IdFactor = KalaFactorDamage.IdFactor INNER JOIN Define_Kala ON KalaFactorDamage.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorDamage.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorDamage.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorDamage.Id"
            ElseIf state = 8 Then
                PrintSQL = "SELECT KalaFactorService.Id,IdKala=0,KalaFactorService.IdService ,KalaFactorService.KolCount, JozCount=0, KalaFactorService.Fe, KalaFactorService.DarsadDiscount, KalaFactorService.DarsadMon, KalaFactorService.Mon,KalaFactorService.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorService INNER JOIN KalaFactorService ON ListFactorService.IdFactor = KalaFactorService.IdFactor INNER JOIN Define_Service  ON KalaFactorService.IdService  = Define_Service .ID  WHERE ListFactorService.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorService.Id"
            End If
           
            ''''''''''''''''''''''''''''''''''
            Dim Dataret As New DataSetFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQL, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("کالاهای فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            Dim Kind As String = GetKindFactor()
            If state = "3" Then
                If Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim count As Long = 0
                    If Dataret.DataTable1.Rows.Count <= 20 Then
                        count = 20 - Dataret.DataTable1.Rows.Count
                    Else
                        count = 20 - (Dataret.DataTable1.Rows.Count Mod 20)
                    End If
                    Dim x() As Byte = Nothing
                    Dataret.DataTable1.Columns("Id").AllowDBNull = True
                    For i As Integer = 0 To count - 1
                        Dataret.DataTable1.AddDataTable1Row(0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", "", "", x, 0, 0, "", 0, 0, x, "", 0, 0, 0, "", 0, "0", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                    Next
                End If
            End If
            '//////////////////////////////////////////
            Dim QueryInfo As String = ""
            If state = "0" Or state = "2" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBuy WHERE  ListFactorBuy.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBuy.IdName AS CodeP,ListFactorBuy.MonAdd ,ListFactorBuy.MonDec ,ListFactorBuy.Discount ,ListFactorBuy.Cash ,ListFactorBuy.MonHavaleh ,(ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) AS MonPayChk , ListFactorBuy.D_date,ListFactorBuy.IdUser , ISNULL(ListFactorBuy.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBuy.IdVisitor,NamVisit='' FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBuy.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBuy.IdName AS CodeP,ListFactorBuy.MonAdd ,ListFactorBuy.MonDec ,ListFactorBuy.Discount ,ListFactorBuy.Cash ,ListFactorBuy.MonHavaleh ,(ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) AS MonPayChk ,ListFactorBuy.D_date,ListFactorBuy.IdUser, ListFactorBuy.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBuy .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBuy.IdFactor =" & CLng(Idfactor) & "  END"
            ElseIf state = "1" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackBuy WHERE  ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackBuy.IdName AS CodeP,ListFactorBackBuy.MonAdd ,ListFactorBackBuy.MonDec ,ListFactorBackBuy.Discount ,ListFactorBackBuy.Cash ,ListFactorBackBuy.MonHavaleh ,ListFactorBackBuy.MonPayChk , ListFactorBackBuy.D_date,ListFactorBackBuy.IdUser , ISNULL(ListFactorBackBuy.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBackBuy.IdVisitor,NamVisit='' FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackBuy.IdName AS CodeP,ListFactorBackBuy.MonAdd ,ListFactorBackBuy.MonDec ,ListFactorBackBuy.Discount ,ListFactorBackBuy.Cash ,ListFactorBackBuy.MonHavaleh ,ListFactorBackBuy.MonPayChk ,ListFactorBackBuy.D_date,ListFactorBackBuy.IdUser, ListFactorBackBuy.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBackBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackBuy .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & "  END"
            ElseIf state = "3" Or state = "5" Or state = "7" Then
                QueryInfo = "Declare @itbl table(DriverNam  Nvarchar(max),IdExit Nvarchar(max)) INSERT INTO @itbl SELECT Nam AS DriverNam,IdExit  FROM(SELECT ListExitFactor.IdFactor, ExitFactor.Id AS IdExit, ExitFactor.IdDriver FROM ListExitFactor INNER JOIN ExitFactor ON ListExitFactor.IdList = ExitFactor.Id WHERE ListExitFactor.IdFactor=" & CLng(Idfactor) & ") AS EFactor INNER JOIN Define_Driver ON EFactor.IdDriver =Define_Driver.Id If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT IdExit=(SELECT ISNULL(MAX(IdExit),'') FROM @itbl),DriverNam=(SELECT ISNULL(MAX(DriverNam),'') FROM @itbl),ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk , ListFactorSell.D_date,ListFactorSell.IdUser , ISNULL(ListFactorSell.Disc,'') AS Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorSell.IdVisitor,NamVisit='' FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorSell.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT IdExit=(SELECT ISNULL(MAX(IdExit),'') FROM @itbl),DriverNam=(SELECT ISNULL(MAX(DriverNam),'') FROM @itbl),ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk ,ListFactorSell.D_date,ListFactorSell.IdUser, ListFactorSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorSell.IdFactor =" & CLng(Idfactor) & " END"
            ElseIf state = "4" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackSell WHERE  ListFactorBackSell.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackSell.IdName AS CodeP,ListFactorBackSell.MonAdd ,ListFactorBackSell.MonDec ,ListFactorBackSell.Discount ,ListFactorBackSell.Cash ,ListFactorBackSell.MonHavaleh ,(ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk ) AS MonPayChk , ListFactorBackSell.D_date,ListFactorBackSell.IdUser , ISNULL(ListFactorBackSell.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBackSell.IdVisitor,NamVisit='' FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBackSell.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackSell.IdName AS CodeP,ListFactorBackSell.MonAdd ,ListFactorBackSell.MonDec ,ListFactorBackSell.Discount ,ListFactorBackSell.Cash ,ListFactorBackSell.MonHavaleh ,(ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk ) AS MonPayChk ,ListFactorBackSell.D_date,ListFactorBackSell.IdUser, ListFactorBackSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBackSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBackSell.IdFactor =" & CLng(Idfactor) & "  END"
            ElseIf state = "6" Then
                QueryInfo = "SELECT  IdExit=N'',DriverNam=N'',CodeP=0,MonAdd=0,MonDec=0,Discount=0,Cash=0,MonHavaleh=0,MonPayChk=0,ListFactorDamage.D_date,ListFactorDamage.IdUser ,ISNULL(ListFactorDamage.Disc,'') AS Disc, Nam='',[Address]='',Tell='',NamO='' ,NamCI='',NamP='' ,IdVisitor=0,NamVisit='' FROM ListFactorDamage WHERE ListFactorDamage.IdFactor =" & CLng(Idfactor)
            ElseIf state = "8" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorService WHERE  ListFactorService.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorService.IdName AS CodeP,ListFactorService.MonAdd ,ListFactorService.MonDec ,ListFactorService.Discount ,ListFactorService.Cash ,ListFactorService.MonHavaleh ,ListFactorService.MonPayChk , ListFactorService.D_date,ListFactorService.IdUser , ISNULL(ListFactorService.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorService.IdVisitor,NamVisit='' FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorService.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorService.IdName AS CodeP,ListFactorService.MonAdd ,ListFactorService.MonDec ,ListFactorService.Discount ,ListFactorService.Cash ,ListFactorService.MonHavaleh ,ListFactorService.MonPayChk ,ListFactorService.D_date,ListFactorService.IdUser, ListFactorService.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorService.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorService .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorService.IdFactor =" & CLng(Idfactor) & "  END"
            End If
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("اطلاعات فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("IdExit") = dtrInfo("IdExit")
                    Dataret.DataTable1.Rows(0).Item("DriverNam") = dtrInfo("DriverNam")
                    Dataret.DataTable1.Rows(0).Item("CodeP") = dtrInfo("CodeP")
                    Dataret.DataTable1.Rows(0).Item("d_Date") = dtrInfo("d_date")
                    Dataret.DataTable1.Rows(0).Item("IdFactor") = CLng(Idfactor)
                    Dataret.DataTable1.Rows(0).Item("People") = dtrInfo("Nam")
                    Dataret.DataTable1.Rows(0).Item("Ostan") = dtrInfo("NamO")
                    Dataret.DataTable1.Rows(0).Item("City") = dtrInfo("NamCI")
                    Dataret.DataTable1.Rows(0).Item("Part") = dtrInfo("NamP")
                    Dataret.DataTable1.Rows(0).Item("Address") = dtrInfo("Address")
                    Dataret.DataTable1.Rows(0).Item("Tell") = dtrInfo("Tell")
                    Dataret.DataTable1.Rows(0).Item("Visit") = dtrInfo("NamVisit")
                    Dataret.DataTable1.Rows(0).Item("Acount") = dtrInfo("IdUser")
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") = dtrInfo("Disc")
                    Dataret.DataTable1.Rows(0).Item("Cash") = dtrInfo("Cash")
                    Dataret.DataTable1.Rows(0).Item("DiscountC") = dtrInfo("Discount")
                    Dataret.DataTable1.Rows(0).Item("Chk") = dtrInfo("MonPayChk")
                    Dataret.DataTable1.Rows(0).Item("Add") = dtrInfo("MonAdd")
                    Dataret.DataTable1.Rows(0).Item("Dec") = dtrInfo("MonDec")
                    Dataret.DataTable1.Rows(0).Item("HBank") = dtrInfo("MonHavaleh")
                    Dataret.DataTable1.Rows(0).Item("Lend") = CDbl(Lend)
                    Dataret.DataTable1.Rows(0).Item("PayMon") = dtrInfo("MonAdd") - (dtrInfo("MonDec") + dtrInfo("Discount"))
                    Select Case CLng(state)
                        Case 0 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خرید"
                        Case 1 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "برگشت از خرید"
                        Case 2 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خرید امانی"
                        Case 3 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور فروش"
                        Case 4 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "برگشت از فروش"
                        Case 5 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور فروش امانی"
                        Case 6 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور ضایعات"
                        Case 7 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "پیش فاکتور"
                        Case 8 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خدمات"
                    End Select
                End If
            End Using
            dtrInfo.Close()
            Using SQLComanad As New SqlCommand("SELECT Top 1 CompanyName ,TelFax as CompanyTell,[Address] as CompanyAddress,Header ,Footer,CompanyImage   FROM Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("CompanyName") = dtrInfo("CompanyName")
                    Dataret.DataTable1.Rows(0).Item("CompanyAddress") = dtrInfo("CompanyAddress")
                    Dataret.DataTable1.Rows(0).Item("CompanyTell") = dtrInfo("CompanyTell")
                    Dataret.DataTable1.Rows(0).Item("Header") = dtrInfo("Header")
                    Dataret.DataTable1.Rows(0).Item("Footer") = dtrInfo("Footer")
                    Try
                        Dataret.DataTable1.Rows(0).Item("ImageFactor") = dtrInfo("CompanyImage")
                    Catch ex As Exception

                    End Try
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dtrInfo.Close()
            '///////////////////////////////////////////
            Dim MonRes As Double = 0
            Dim discount As Double = 0
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrDarsad") = Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("AllMoney") = Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                MonRes += Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                discount += Dataret.DataTable1.Rows(i).Item("DarsadMon")
                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    Dataret.DataTable1.Rows(i).Item("FeKol") = Dataret.DataTable1.Rows(i).Item("Fe")
                    'Dataret.DataTable1.Rows(i).Item("Fe") = 0
                Else
                    Dataret.DataTable1.Rows(i).Item("FeKol") = If(Dataret.DataTable1.Rows(i).Item("KolCount") <> 0, Dataret.DataTable1.Rows(i).Item("Mon") / Dataret.DataTable1.Rows(i).Item("KolCount"), 0)
                End If
                Dataret.DataTable1.Rows(i).Item("Vahed") &= " " & Dataret.DataTable1.Rows(i).Item("KalaDisc")
            Next
            Dataret.DataTable1.Rows(0).Item("PayMon") = MonRes + Dataret.DataTable1.Rows(0).Item("PayMon")

            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") = "توضیحات فاکتور : " & If(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc"))
            ''''''''''''''''''''''''MoeinFactor
            If CLng(state) <> 7 And CLng(state) <> 6 Then
                OldSanad = 0
                CurSanad = 0
                IdKala = 0
                SetMoeinPeopleVarible(CLng(Idfactor), CLng(state))
                Dataret.DataTable1.Rows(0).Item("OldMoein") = GetMoeinPeople(IdKala, OldSanad, Dataret.DataTable1.Rows(0).Item("d_Date"), CLng(state), CLng(Idfactor))
                Dataret.DataTable1.Rows(0).Item("Moein") = If(CLng(state) = 0 Or CLng(state) = 2 Or CLng(state) = 4, Dataret.DataTable1.Rows(0).Item("OldMoein") - Dataret.DataTable1.Rows(0).Item("PayMon") + Dataret.DataTable1.Rows(0).Item("Cash") + Dataret.DataTable1.Rows(0).Item("Chk") + Dataret.DataTable1.Rows(0).Item("HBank"), Dataret.DataTable1.Rows(0).Item("OldMoein") + Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("Cash") - Dataret.DataTable1.Rows(0).Item("Chk") - Dataret.DataTable1.Rows(0).Item("HBank"))
                Dim Tmpdate As String = GetOldTime(IdKala, OldSanad, Dataret.DataTable1.Rows(0).Item("d_Date"), CLng(state), CLng(Idfactor))
                If Not String.IsNullOrEmpty(Tmpdate) Then
                    Dim T As Long = SUBDAY(Dataret.DataTable1.Rows(0).Item("d_Date"), Tmpdate)
                    If Kind.Contains("A4ES3") Or Kind.Contains("A4ES4") Then
                        If T <> 0 Then
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = "مانده قبلی در تاریخ" & Tmpdate & " معادل" & T & " روز می باشد"
                        Else
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                        End If
                    Else
                        If T <> 0 Then
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") &= If(Not String.IsNullOrEmpty(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc")), " . ", "") & "مانده قبلی در تاریخ" & Tmpdate & " معادل" & T & " روز می باشد"
                        Else
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                        End If
                    End If
                Else
                    If Kind.Contains("A4ES3") Then
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = "مـانـده قــبــلـی"
                    Else
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                    End If
                End If
                If state = 3 Then
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") &= If(Not String.IsNullOrEmpty(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc")), " . ", "") & GetCashMonDisc(CLng(Idfactor))
                End If
                If Dataret.DataTable1.Rows(0).Item("Moein") < 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str((Dataret.DataTable1.Rows(0).Item("Moein") * -1)) & "-بستانکار"
                ElseIf Dataret.DataTable1.Rows(0).Item("Moein") = 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str(0) & "-بی حساب"
                ElseIf Dataret.DataTable1.Rows(0).Item("Moein") > 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("Moein")) & "-بدهکار"
                End If
            End If
            '//////////////////////////////////////////
            If (state = "3" Or state = "5") And (Kind.Contains("A4ES") Or Kind.Contains("A4ES2") Or Kind.Contains("A4ES4") Or Kind.Contains("EPSON100S") Or Kind.Contains("EPSON130S") Or Kind.Contains("A4ES3")) Then
                CallDiscountFactor(Dataret.DataTable1.Rows(0).Item("CodeP"), Dataret.DataTable1.Rows(0).Item("IdFactor"))
                Dim dec As Double = GetCashMonDisc2(CLng(Idfactor))
                Dataret.DataTable1.Rows(0).Item("CashDiscount") = Math.Round((TmpDarsad * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2)
                Dataret.DataTable1.Rows(0).Item("PelDiscount") = Math.Round((TmpDarsad1 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2)
                Dataret.DataTable1.Rows(0).Item("EndMon") = Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("PelDiscount") - Dataret.DataTable1.Rows(0).Item("CashDiscount")
                Dataret.DataTable1.Rows(0).Item("KindFrosh") = CallKindFactor(Dataret.DataTable1.Rows(0).Item("IdFactor"), Dataret.DataTable1.Rows(0).Item("d_Date"))
                If (Kind.Contains("A4ES2") Or Kind.Contains("A4ES3") Or Kind.Contains("A4ES4")) Then
                    If Kind.Contains("A4ES3") Or Kind.Contains("A4ES4") Then
                        CallDiscountChkFactor(Dataret.DataTable1.Rows(0).Item("CodeP"))
                        Dataret.DataTable1.Rows(0).Item("TChk1") = tc1
                        Dataret.DataTable1.Rows(0).Item("TChk2") = tc2
                        Dataret.DataTable1.Rows(0).Item("TChk3") = tc3
                        Dataret.DataTable1.Rows(0).Item("MonChk1") = If(TmpDarsad <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(0).Item("MonChk2") = If(TmpDarsad1 <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad1 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(0).Item("MonChk3") = If(TmpDarsad2 <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad2 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndCashMon") = Dataret.DataTable1.Rows(0).Item("EndMon") + Dataret.DataTable1.Rows(0).Item("OldMoein")
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk1Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk1") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk1") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk2Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk2") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk2") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk3Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk3") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk3") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                    End If
                    If Kind.Contains("A4ES4") Then
                        CallDiscountCardFactor(Dataret.DataTable1.Rows(0).Item("CodeP"), Dataret.DataTable1.Rows(0).Item("IdFactor"))
                        Dataret.DataTable1.Rows(0).Item("CardDiscount") = TmpDarsad
                        Dataret.DataTable1.Rows(0).Item("CardCash") = Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("CardDiscount")
                        SetEndMonKala(Dataret, Dataret.DataTable1.Rows(0).Item("CodeP"))
                    End If
                Else
                    SetEndMonKala(Dataret, Dataret.DataTable1.Rows(0).Item("CodeP"))
                End If
            Else
                Dataret.DataTable1.Rows(0).Item("CashDiscount") = 0
                Dataret.DataTable1.Rows(0).Item("PelDiscount") = 0
                Dataret.DataTable1.Rows(0).Item("EndMon") = Dataret.DataTable1.Rows(0).Item("PayMon")
                Dataret.DataTable1.Rows(0).Item("KindFrosh") = ""
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndCashMon") = 0
            End If
            '//////////////////////////////////////////
            Dim Ci As Integer = GetCountPrint("FACTOR")
            Dim J As Integer = 0

            If CLng(state) = 3 Or CLng(state) = 4 Or CLng(state) = 5 Then

                ''''''''''''''''''نوع فروشگاهی A4 کاغذ
                If Kind = "A4EFGKB" Then
                    Dim ret As New CRP_Factor_sell_A4EF_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Then
                    Dim ret As New CRP_Factor_sell_A4EF
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Then
                    Dim ret As New CRP_Factor_sell_A4EF_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی A4 کاغذ
                ElseIf Kind = "A4ETGKB" Then
                    Dim ret As New CRP_Factor_sell_A4ET_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGKS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKB" Then
                    Dim ret As New CRP_Factor_sell_A4ET
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGB" Then
                    Dim ret As New CRP_Factor_sell_A4ET_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع پخش سراسرس A4 کاغذ
                ElseIf Kind = "A4ESGKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESGKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESGB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESGS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                    ''''''''''''''''''نوع توزیعی 2 A4 کاغذ
                ElseIf Kind = "A4ES2GKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2GKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2KB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2KS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2GB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2GS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع توزیعی 3 A4 کاغذ
                ElseIf Kind = "A4ES3GKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3GKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3KB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3KS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3GB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3GS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع توزیعی 4 A4 کاغذ
                ElseIf Kind = "A4ES4GKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4GKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4KB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4KS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4GB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4GS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_sell_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_sell_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_sell_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع پخش سراسری EPSON100 کاغذ
                ElseIf Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                    ''''''''''''''''''نوع فاکتور آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    If CLng(state) = 3 Then
                        Dim ret As New CRP_Factor_sell_Epson100P
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع فروشگاهی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                End If
            ElseIf state = 0 Or state = 1 Or state = 2 Then
                ''''''''''''''''''نوع فروشگاهی A4 کاغذ
                If Kind = "A4EFGKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                ElseIf Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    '''''''''''''''''' نوع توزیعی و پخش سراسری و آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی و پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If
            ElseIf state = 7 Then
                ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و پخش سرایری و توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و پخش سراسری و توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If
            ElseIf state = 8 Then
                ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_Service_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_Service_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_Service_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_Service_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Or Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Service_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Or Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Service_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Service_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Service_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و پخش سرایری و توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100FGB" Or Kind = "EPSON100TGB" Or Kind = "EPSON100SGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Service_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Service_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next

                    ''''''''''''''''''نوع فروشگاهی و پخش سراسری و توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Or Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Service_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Service_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If

            ElseIf state = 6 Then
                '''''''''''''''''' نوع فروشگاهی و پخش سراسری و توزیعی 1,2,3,4 و فروشگاهی ساده A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Or Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_Damage_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Or Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Or Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Damage_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Or Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Or Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Damage_A4E_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Or Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی و پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If

            End If
            Application.DoEvents()
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "Factor")
            Return False
        End Try
    End Function
    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ManageFact.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnPrint.Enabled = True Then BtnPrint_Click(Nothing, Nothing)
        End If
    End Sub
End Class