Imports System.Data.SqlClient
Public Class RepairSanad

    Private Sub RepairSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RepairSanad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not UCase(NamUser) = "ADMIN" Then
            MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            Dim ds_U As New DataSet
            Dim dta_U As New SqlDataAdapter
            ds_U.Clear()
            If Not dta_U Is Nothing Then dta_U.Dispose()
            dta_U = New SqlDataAdapter("SELECT * FROM Define_User", DataSource)
            dta_U.Fill(ds_U, "Define_User")
            ds_U.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds_U.Tables("Define_User").Rows.Count - 1
                ds_U.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds_U.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next

            Dim rowLogIn() As DataRow = ds_U.Tables("Define_User").Select("LogIn>=" & 1)
            Tmp_Mon = rowLogIn.Length

            If Tmp_Mon > 1 Then
                MessageBox.Show("  وارد سیستم شده باشد  Admin  جهت بازسازی اسناد نباید هیچ کاربری به غیر از ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Me.DeleteSpamData()
                Me.GetMoein()
                Me.GetNoEdit()
                Me.GetChk()
                DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV2.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV3.Columns("Cln_NumChk").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rebulid.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(0).Focus = True Then
                If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            If TabControl1.TabPages(0).Focus = True Then
                Me.GetMoein()
            ElseIf TabControl1.TabPages(1).Focus = True Then
                Me.GetNoEdit()
            ElseIf TabControl1.TabPages(2).Focus = True Then
                Me.GetChk()
            End If
        End If
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("اسنادی برای بازسازی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("آیا برای بازسازی اسناد مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub


            Tmp_Mon = 0
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            Dim ds_U As New DataSet
            Dim dta_U As New SqlDataAdapter
            ds_U.Clear()
            If Not dta_U Is Nothing Then dta_U.Dispose()
            dta_U = New SqlDataAdapter("SELECT * FROM Define_User", DataSource)
            dta_U.Fill(ds_U, "Define_User")
            ds_U.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds_U.Tables("Define_User").Rows.Count - 1
                ds_U.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds_U.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next

            Dim rowLogIn() As DataRow = ds_U.Tables("Define_User").Select("LogIn>=" & 1)
            Tmp_Mon = rowLogIn.Length


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            If Tmp_Mon > 1 Then
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                SqlConnection.ClearPool(ConectionBank)
                MessageBox.Show("  وارد سیستم شده باشد  Admin  جهت بازسازی اسناد نباید هیچ کاربری به غیر از ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Enabled = False

                Using CMD As New SqlCommand("UPDATE ListFactorSell SET EditFlag=1;UPDATE ListFactorBuy SET EditFlag=1;UPDATE ListFactorBackBuy SET EditFlag=1;UPDATE ListFactorBackSell SET EditFlag=1;UPDATE ListFactorService SET EditFlag=1;UPDATE ListFactorDamage SET EditFlag=1", ConectionBank)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                Using CMD As New SqlCommand("UPDATE Get_Pay_Sanad SET EditFlag =1;;UPDATE ListOtherCharge SET EditFlag=1;UPDATE ListFactorCharge SET EditFlag=1;Update Get_Pay_Amval Set EditFlag =1;Update Get_Pay_Sarmayeh  Set EditFlag =1;Update Get_Daramad  Set EditFlag =1;Update ListEditMoein Set EditFlag =1", ConectionBank)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                SqlConnection.ClearPool(ConectionBank)

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بازسازی اسناد", "بازسازی", "", "")

                Me.GetNoEdit()

                MessageBox.Show("عملیات بازسازی اسناد با موفقیت به پایان رسید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
            End If

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            SqlConnection.ClearPool(ConectionBank)
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "BtnReport_Click")
            Me.Enabled = True
        End Try
    End Sub
    Private Sub GetMoein()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable

            Using CMD As New SqlCommand("SELECT St=N'معین طرف حساب',StNum=0,Moein_People.Id,D_date,Define_People.Nam ,disc,BedMon=CASE WHEN T=0 THEN mon ELSE 0 END,BesMon=CASE WHEN T=1 THEN mon ELSE 0 END FROM Moein_People INNER JOIN Define_People ON Define_People.ID=Moein_People.IDPeople WHERE Number_Type =0 UNION ALL SELECT St=N'معین صندوق',StNum=1,Moein_Box.Id,D_date,Define_Box.Nam,disc,BedMon=CASE WHEN T=0 THEN mon ELSE 0 END,BesMon=CASE WHEN T=1 THEN mon ELSE 0 END FROM Moein_Box INNER JOIN Define_Box ON Define_Box.ID=Moein_Box.IDBox WHERE Moein_Box .Id NOT IN (SELECT IdBox FROM(SELECT IdBox FROM ListFactorSell WHERE Activ =1 AND IdSanadCash IS NOT NULL UNION SELECT IdBox FROM ListFactorBackSell WHERE Activ =1 AND IdSanadCash IS NOT NULL UNION SELECT IdBox FROM ListFactorBuy WHERE Activ =1 AND IdSanadCash IS NOT NULL UNION SELECT IdBox FROM ListFactorBackBuy WHERE Activ =1 AND IdSanadCash IS NOT NULL UNION SELECT IdBox FROM ListFactorService WHERE Activ =1 AND IdSanadCash IS NOT NULL UNION SELECT IdBoxMoein As IdBox FROM Get_Pay_Sanad  WHERE Active =1 AND IdBoxMoein IS NOT NULL UNION SELECT IdBoxMoein FROM ListFactorCharge  WHERE Activ =1 AND IdBoxMoein IS NOT NULL UNION SELECT IdBoxMoein  FROM ListOtherCharge  WHERE Activ =1 AND IdBoxMoein IS NOT NULL UNION SELECT IdBoxMoein As IdBox FROM Get_Pay_Amval WHERE Active =1 AND IdBoxMoein IS NOT NULL UNION SELECT IdBoxMoein As IdBox FROM Get_Pay_Sarmayeh WHERE Active =1 AND IdBoxMoein IS NOT NULL UNION SELECT IdBoxMoein As IdBox FROM Get_Daramad WHERE Active =1 AND IdBoxMoein IS NOT NULL UNION SELECT IDsanadBox As IdBox FROM Sanad_AddDecBox UNION SELECT IdSanadBed As IdBox FROM Sanad_BOXTBOX UNION SELECT IdSanadBes As IdBox FROM Sanad_BOXTBOX UNION  SELECT IdBoxMoein As IdBox FROM Sanad_Translate_BoxBank UNION SELECT BoxMoein As IdBox FROM Sanad_ChangeChk WHERE BoxMoein IS NOT NULL) AS ListBox) UNION ALL SELECT St=N'معین بانک',StNum=2,Moein_Bank.Id,D_date,Define_Bank.Nam,disc,BedMon=CASE WHEN T=0 THEN mon ELSE 0 END,BesMon=CASE WHEN T=1 THEN mon ELSE 0 END FROM Moein_Bank INNER JOIN Define_Bank ON Define_Bank.ID=Moein_Bank.IDBank WHERE Moein_Bank.Id NOT IN (SELECT IdBanK FROM(SELECT IdBanK As IdBank FROM ListFactorSell WHERE Activ =1 AND IdBanK IS NOT NULL UNION SELECT IdBanK As IdBank FROM ListFactorBackSell WHERE Activ =1 AND IdBanK IS NOT NULL UNION SELECT IdBanK As IdBank FROM ListFactorBuy WHERE Activ =1 AND IdBanK IS NOT NULL UNION SELECT IdBanK As IdBank FROM ListFactorBackBuy WHERE Activ =1 AND IdBanK IS NOT NULL UNION SELECT IdBanK As IdBank FROM ListFactorService WHERE Activ =1 AND IdBanK IS NOT NULL UNION SELECT IdBankMoein As IdBank FROM Get_Pay_Sanad  WHERE Active =1 AND IdBankMoein IS NOT NULL UNION SELECT IdBankMoein As IdBank FROM ListFactorCharge  WHERE Activ =1 AND IdBankMoein IS NOT NULL UNION SELECT IdBankMoein As IdBank FROM ListOtherCharge  WHERE Activ =1 AND IdBankMoein IS NOT NULL UNION SELECT IdBankMoein As IdBank FROM Get_Pay_Amval WHERE Active =1 AND IdBankMoein IS NOT NULL UNION SELECT IdBankMoein As IdBank FROM Get_Pay_Sarmayeh WHERE Active =1 AND IdBankMoein IS NOT NULL UNION SELECT IdBankMoein As IdBank FROM Get_Daramad WHERE Active =1 AND IdBankMoein IS NOT NULL UNION SELECT IDsanadBank As IdBank FROM Sanad_AddDecBank UNION SELECT IdSanadBes As IdBank FROM Sanad_BankTBank_Bes UNION SELECT IdSanadBed As IdBank FROM Sanad_BankTBank_Bed UNION SELECT IdBankMoein As IdBank FROM Sanad_Translate_BoxBank UNION SELECT BankMoein As IdBank FROM Sanad_ChangeChk WHERE BankMoein IS NOT NULL) As Listbank) ORDER BY StNum ,D_date ,Id", ConectionBank)
                CMD.CommandTimeout = 0
                dt.Load(CMD.ExecuteReader)
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "GetMoein")
        End Try
    End Sub

    Private Sub GetNoEdit()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable

            Using CMD As New SqlCommand("SELECT St=0,StNum=CASE WHEN ListFactorSell.Stat =3 Then N'فاکتور فروش' WHEN ListFactorSell.Stat =5 Then N'فاکتور فروش امانی' WHEN ListFactorSell.Stat =7 Then N'پیش فاکتور فروش' END,IdFactor AS Id,D_date,Define_People.Nam FROM ListFactorSell INNER JOIN Define_People ON Define_People.ID =ListFactorSell.IdName WHERE ListFactorSell.Activ =1 AND EditFlag =0 UNION ALL SELECT St=1,StNum=N'برگشت از فروش',IdFactor AS Id,D_date,Define_People.Nam FROM ListFactorBackSell INNER JOIN Define_People ON Define_People.ID =ListFactorBackSell.IdName WHERE ListFactorBackSell.Activ =1 AND EditFlag =0 UNION ALL SELECT St=2,StNum=CASE WHEN ListFactorBuy.Stat =0 Then N'فاکتور خرید' WHEN ListFactorBuy.Stat =2 Then N'فاکتور خرید امانی' END,IdFactor AS Id,D_date,Define_People.Nam FROM ListFactorBuy INNER JOIN Define_People ON Define_People.ID =ListFactorBuy.IdName WHERE ListFactorBuy.Activ =1 AND EditFlag =0 UNION ALL SELECT St=3,StNum=N'برگشت از خرید',IdFactor AS Id,D_date,Define_People.Nam FROM ListFactorBackBuy INNER JOIN Define_People ON Define_People.ID =ListFactorBackBuy.IdName WHERE ListFactorBackBuy.Activ =1 AND EditFlag =0 UNION ALL SELECT St=4,StNum=N'فاکتور خدمات',IdFactor AS Id,D_date,Define_People.Nam FROM ListFactorService INNER JOIN Define_People ON Define_People.ID =ListFactorService.IdName WHERE ListFactorService.Activ =1 AND EditFlag =0 UNION ALL SELECT St=5,StNum=N'فاکتور ضایعات',IdFactor AS Id,D_date,Nam=N'ضایعات' FROM ListFactorDamage WHERE ListFactorDamage.Activ =1 AND EditFlag =0 UNION ALL SELECT St=6,StNum=CASE WHEN Get_Pay_Sanad.[State] =0 Then N'دریافت از طرف حساب' WHEN Get_Pay_Sanad.[State] =1 Then N'پرداخت به طرف حساب' END,Get_Pay_Sanad.Id,D_date,Define_People.Nam FROM Get_Pay_Sanad INNER JOIN Define_People ON Define_People.ID =Get_Pay_Sanad.IdName WHERE Get_Pay_Sanad.Active =1 AND EditFlag =0 UNION ALL SELECT St=7,StNum=N'هزینه',Id,D_date,Nam=N'هزینه' FROM ListOtherCharge WHERE ListOtherCharge.Activ =1 AND EditFlag =0 UNION ALL SELECT St=8,StNum=N'هزینه فاکتور خرید',Id,D_date,Nam=N'فاکتور شماره ' + CAST(ListFactorCharge.IdFactor AS Nvarchar(max))  FROM ListFactorCharge WHERE ListFactorCharge.Activ =1 AND EditFlag =0 UNION ALL SELECT St=9,StNum=N'اموال',Get_Pay_Amval.Id,D_date,Define_Amval.Nam  FROM Get_Pay_Amval INNER JOIN Define_Amval ON Define_Amval.ID =Get_Pay_Amval.IdAmval  WHERE Get_Pay_Amval.Active  =1 AND EditFlag =0 UNION ALL SELECT St=10,StNum=N'سرمایه',Get_Pay_Sarmayeh.Id,D_date,Define_Sarmayeh.Nam  FROM Get_Pay_Sarmayeh INNER JOIN Define_Sarmayeh ON Define_Sarmayeh.ID =Get_Pay_Sarmayeh.IdSarmayeh  WHERE Get_Pay_Sarmayeh.Active  =1 AND EditFlag =0 UNION ALL SELECT St=11,StNum=N'درآمد',Get_Daramad.Id,D_date,Define_Daramad.Nam  FROM Get_Daramad INNER JOIN Define_Daramad ON Define_Daramad.ID =Get_Daramad.IdDaramad WHERE Get_Daramad.Active  =1 AND EditFlag =0 UNION ALL SELECT St=12,StNum=N'اصلاحیه طرف حساب',ListEditMoein.Id,D_date,Nam=N'اصلاحیه طرف حساب'  FROM ListEditMoein WHERE EditFlag =0", ConectionBank)
                CMD.CommandTimeout = 0
                dt.Load(CMD.ExecuteReader)
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = dt
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "GetNoEdit")
        End Try
    End Sub

    Private Sub DeleteSpamData()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("DELETE FROM Get_Pay_Sanad WHERE Idname IS NULL;DELETE FROM Get_Daramad WHERE IdDaramad IS NULL;DELETE FROM Get_Pay_Amval WHERE IdAmval IS NULL;DELETE FROM Get_Pay_Sarmayeh WHERE IdSarmayeh IS NULL;DELETE FROM ListOtherCharge WHERE Activ =0;DELETE FROM ListFactorCharge WHERE Activ =0;DELETE FROM ListFactorSell WHERE Activ =0;DELETE FROM ListFactorBackSell WHERE Activ =0;DELETE FROM ListFactorBuy WHERE Activ =0;DELETE FROM ListFactorBackBuy WHERE Activ =0;DELETE FROM ListFactorDamage WHERE Activ =0;DELETE FROM ListFactorService WHERE Activ =0;Declare @tbl Table(ID bigint);INSERT INTO @tbl SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=11 AND Number_Type=0 UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=12 AND Number_Type NOT IN (SELECT Get_Pay_Sanad.Id FROM Get_Pay_Sanad) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=21 AND Number_Type NOT IN (SELECT Get_Pay_Sarmayeh.Id FROM Get_Pay_Sarmayeh) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=14 AND Number_Type NOT IN (SELECT Get_Pay_Amval.Id FROM Get_Pay_Amval) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=15 AND Number_Type NOT IN (SELECT Get_Daramad.Id FROM Get_Daramad) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=16 AND Number_Type NOT IN (SELECT ListOtherCharge.Id FROM ListOtherCharge) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=17 AND Number_Type NOT IN (SELECT ListFactorCharge.Id FROM ListFactorCharge) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND ([Type]=0 OR [Type]=2) AND Number_Type NOT IN (SELECT ListFactorBuy.IdFactor FROM ListFactorBuy) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND ([Type]=3 OR [Type]=5) AND Number_Type NOT IN (SELECT ListFactorSell.IdFactor FROM ListFactorSell) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=1 AND Number_Type NOT IN (SELECT ListFactorBackBuy.IdFactor FROM ListFactorBackBuy) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=4 AND Number_Type NOT IN (SELECT ListFactorBackSell.IdFactor FROM ListFactorBackSell) UNION SELECT ID FROM Chk_Get_Pay WHERE (Kind =Current_Kind) AND Activ =0 AND [Type]=8 AND Number_Type NOT IN (SELECT ListFactorService.IdFactor FROM ListFactorService);DELETE FROM Chk_State WHERE Chk_State.Id IN (SELECT ID FROM @tbl);DELETE FROM Chk_Id WHERE Chk_Id.Id IN (SELECT ID FROM @tbl);DELETE FROM Chk_Get_Pay WHERE Chk_Get_Pay.Id IN (SELECT ID FROM @tbl)", ConectionBank)
                CMD.CommandTimeout = 0
                CMD.ExecuteReader()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "DeleteSpamData")
        End Try
    End Sub

    Private Sub GetChk()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable

            Using CMD As New SqlCommand("SELECT ST=CASE WHEN (Kind =0 AND Current_Kind =0) THEN N'اسناد دریافتی' WHEN (Kind =1 AND Current_Kind =1) THEN N'اسناد پرداختی' WHEN (Kind =0 AND Current_Kind =1) THEN N'اسناد خرج شده' END,ID,[GetDate],PayDate,MoneyChk,NumChk,N_Bank =CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =0 AND Current_Kind =1) THEN N_Bank WHEN (Kind =1 AND Current_Kind =1) THEN (SELECT n_bank FROM Define_Bank WHERE Define_Bank.ID =(SELECT TOP 1 IdBank FROM Chk_Id WHERE Chk_Id.Id=Chk_Get_Pay.ID) ) END FROM Chk_Get_Pay WHERE [Activ]=0 UNION SELECT ST=N'اسناد خرج شده',ID,[GetDate],PayDate,MoneyChk,NumChk,N_Bank FROM Chk_Get_Pay WHERE ID IN(SELECT Id FROM(SELECT  Chk_Get_Pay.ID,IdOne=CASE WHEN Current_type<=12 THEN Current_IdPeople WHEN Current_type=14 THEN IdAmval WHEN Current_type=21 THEN Idsarmayeh END,IdTwo=CASE WHEN Current_type=14 THEN (SELECT Get_Pay_Amval.IdAmval FROM Get_Pay_Amval WHERE Get_Pay_Amval.Id =Current_Number_Type) WHEN Current_type=21 THEN (SELECT Get_Pay_Sarmayeh.IdSarmayeh FROM Get_Pay_Sarmayeh WHERE Get_Pay_Sarmayeh.Id =Current_Number_Type) WHEN (Current_type=0 OR Current_type=2) THEN (SELECT IdName FROM ListFactorBuy  WHERE IdFactor =Current_Number_Type) WHEN (Current_type=4) THEN (SELECT IdName FROM ListFactorBackbuy WHERE IdFactor =Current_Number_Type) WHEN Current_type=12 THEN (SELECT Get_Pay_Sanad.Idname FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.Id =Current_Number_Type) END FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Kind=0 AND Current_Kind =1 AND Activ =1 AND (Current_type<=12 OR Current_type=14 OR Current_type=21)) AS ListSellChk WHERE IdOne <>IdTwo) ORDER BY ST", ConectionBank)
                CMD.CommandTimeout = 0
                dt.Load(CMD.ExecuteReader)
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            DGV3.AutoGenerateColumns = False
            DGV3.DataSource = dt
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "GetChk")
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("مغایرتی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("آیا برای حذف مغایرت ها مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Me.Enabled = False

            Dim MoeinP As String = ""
            Dim MoeinBox As String = ""
            Dim Moeinbank As String = ""
            Dim query As String = ""

            For i As Integer = 0 To DGV.RowCount - 1
                If DGV.Item("Cln_StNum", i).Value = 0 Then
                    MoeinP &= If(String.IsNullOrEmpty(MoeinP), "", ",") & DGV.Item("Cln_Sanad", i).Value
                ElseIf DGV.Item("Cln_StNum", i).Value = 1 Then
                    MoeinBox &= If(String.IsNullOrEmpty(MoeinBox), "", ",") & DGV.Item("Cln_Sanad", i).Value
                ElseIf DGV.Item("Cln_StNum", i).Value = 2 Then
                    Moeinbank &= If(String.IsNullOrEmpty(Moeinbank), "", ",") & DGV.Item("Cln_Sanad", i).Value
                End If
            Next

            query = If(String.IsNullOrEmpty(MoeinP), "", "DELETE FROM Moein_People WHERE Id IN (" & MoeinP & ");") & If(String.IsNullOrEmpty(MoeinBox), "", "DELETE FROM Moein_Box WHERE Id IN (" & MoeinBox & ");") & If(String.IsNullOrEmpty(Moeinbank), "", "DELETE FROM Moein_Bank WHERE Id IN (" & Moeinbank & ");")


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(query, ConectionBank)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بازسازی اسناد", "حذف مغایرت اسناد معین", "", "")

            Me.GetMoein()

            MessageBox.Show("عملیات حذف مغایرت اسناد معین با موفقیت به پایان رسید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Enabled = True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "Button3_Click")
            Me.Enabled = True
        End Try
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
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        If DGV3.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV3.RowCount <= 0 Then
                MessageBox.Show("مغایرتی برای اصلاح وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("آیا برای اصلاح مغایرت ها مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Tmp_Mon = 0
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            Dim ds_U As New DataSet
            Dim dta_U As New SqlDataAdapter
            ds_U.Clear()
            If Not dta_U Is Nothing Then dta_U.Dispose()
            dta_U = New SqlDataAdapter("SELECT * FROM Define_User", DataSource)
            dta_U.Fill(ds_U, "Define_User")
            ds_U.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds_U.Tables("Define_User").Rows.Count - 1
                ds_U.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds_U.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next

            Dim rowLogIn() As DataRow = ds_U.Tables("Define_User").Select("LogIn>=" & 1)
            Tmp_Mon = rowLogIn.Length


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            If Tmp_Mon > 1 Then
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                SqlConnection.ClearPool(ConectionBank)
                MessageBox.Show("  وارد سیستم شده باشد  Admin  جهت اصلاح مغایرت چک نباید هیچ کاربری به غیر از ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Enabled = False

                'Using CMD As New SqlCommand("DECLARE @tbl TABLE(ID Bigint);INSERT INTO @tbl(ID) (SELECT ID FROM Chk_Get_Pay WHERE Kind =0 AND Current_Kind =1 AND Activ =0);UPDATE Chk_Get_Pay SET Current_Kind =0,Activ =1,Current_Type =[Type],Current_Type_Chk =Type_Chk,Current_Number_Type=Number_Type WHERE ID IN (SELECT Id FROM @tbl);UPDATE Chk_Id SET Current_IdPeople =IdPeople WHERE Id IN (SELECT Id FROM @tbl)", ConectionBank)
                Using CMD As New SqlCommand("DECLARE @tbl TABLE(ID Bigint);INSERT INTO @tbl(ID) (SELECT ID FROM Chk_Get_Pay WHERE Kind =0 AND Current_Kind =1 AND Activ =0);UPDATE Chk_Get_Pay SET Current_Kind =0,Activ =1,Current_Type =[Type],Current_Type_Chk =Type_Chk,Current_Number_Type=Number_Type WHERE ID IN (SELECT Id FROM @tbl);UPDATE Chk_Id SET Current_IdPeople =IdPeople WHERE Id IN (SELECT Id FROM @tbl);DECLARE @i BigInt=1;DECLARE @cnt BigInt=0;DECLARE @ID BigInt=0;DECLARE @CT BigInt=0;DECLARE @IT BigInt=0;DECLARE @SellTbl TABLE (Row BIGINT,ID BIGINT,Current_Type BIGINT,IdTwo BIGINT);INSERT INTO @SellTbl SELECT ROW_NUMBER() OVER(ORDER BY ID) AS 'Row',ID,Current_Type,IdTwo FROM (SELECT  Chk_Get_Pay.ID,IdOne=CASE WHEN Current_type<=12 THEN Current_IdPeople WHEN Current_type=14 THEN IdAmval WHEN Current_type=21 THEN Idsarmayeh END,IdTwo=CASE WHEN Current_type=14 THEN (SELECT Get_Pay_Amval.IdAmval FROM Get_Pay_Amval WHERE Get_Pay_Amval.Id =Current_Number_Type) WHEN Current_type=21 THEN (SELECT Get_Pay_Sarmayeh.IdSarmayeh FROM Get_Pay_Sarmayeh WHERE Get_Pay_Sarmayeh.Id =Current_Number_Type) WHEN (Current_type=0 OR Current_type=2) THEN (SELECT IdName FROM ListFactorBuy  WHERE IdFactor =Current_Number_Type) WHEN (Current_type=4) THEN (SELECT IdName FROM ListFactorBackbuy WHERE IdFactor =Current_Number_Type) WHEN Current_type=12 THEN (SELECT Get_Pay_Sanad.Idname FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.Id =Current_Number_Type) END,Current_Type,Current_Number_Type FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Kind=0 AND Current_Kind =1 AND Activ =1 AND (Current_type<=12 OR Current_type=14 OR Current_type=21)) AS ListSellChk WHERE IdOne <>IdTwo ;SET @cnt =(SELECT COUNT(ID) FROM @SellTbl);WHILE @i <=@cnt BEGIN SET @ID=(SELECT ID FROM @SellTbl WHERE Row =@i) SET @CT=(SELECT Current_Type FROM @SellTbl WHERE Row =@i) SET @IT=(SELECT IdTwo FROM @SellTbl WHERE Row =@i) IF (@CT<=12)BEGIN UPDATE Chk_Id SET Current_IdPeople =@IT  WHERE Chk_Id.Id =@ID END ELSE IF (@CT=14) BEGIN UPDATE Chk_Id SET IdAmval =@IT WHERE Chk_Id.Id =@ID END ELSE IF (@CT=21) BEGIN UPDATE Chk_Id SET Idsarmayeh =@IT WHERE Chk_Id.Id =@ID END UPDATE Moein_People SET IDPeople =@IT WHERE T=1 AND ID IN (SELECT PeopleMoein FROM Sanad_ChangeChk  WHERE IdChk =@ID) SET @i=@i+1 END", ConectionBank)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بازسازی اسناد", "اصلاح مغایرت چک", "", "")
                Me.GetChk()
                MessageBox.Show("عملیات اصلاح مغایرت چک با موفقیت به پایان رسید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RepairSanad", "Button1_Click")
            Me.Enabled = True
        End Try
    End Sub
End Class