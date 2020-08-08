Imports System.Data.SqlClient
Public Class FrmEndAccounting
    Dim Box, Bank, Amval, Sarmayeh, Kala As Boolean

    Private Sub FrmEndAccounting_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtNewPeriod.Focus()
    End Sub

    Private Sub FrmEndAccounting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmEndAccounting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
        Dim Sec As New Security()
        key.IV = Sec.Kiv
        key.Key = Sec.Kkey
        Dim ds_U As New DataSet
        Dim dta_U As New SqlDataAdapter
        ds_U.Clear()
        If Not dta_U Is Nothing Then dta_U.Dispose()
        dta_U = New SqlDataAdapter("SELECT Id,Nam,UserLogIn FROM Define_User", DataSource)
        dta_U.Fill(ds_U, "Define_User")
        ds_U.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

        For i As Integer = 0 To ds_U.Tables("Define_User").Rows.Count - 1
            ds_U.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds_U.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
        Next

        Dim rowLogIn() As DataRow = ds_U.Tables("Define_User").Select("LogIn>=" & 1)
        Tmp_Mon = rowLogIn.Length

        If Tmp_Mon > 1 Then
            MessageBox.Show("وارد سیستم شده باشد  Admin  جهت بستن دوره مالی نباید هیچ کاربری به غیر از ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

        TxtAccount.Text = Nam_Account
        TxtOldPeriod.Text = Nam_Period
        DiffMon()

        If Box = True Then
            PicBox.Image = My.Resources.Succed
        ElseIf Box = False Then
            PicBox.Image = My.Resources._Error
        End If

        If Bank = True Then
            PicBank.Image = My.Resources.Succed
        ElseIf Bank = False Then
            PicBank.Image = My.Resources._Error
        End If

        If Amval = True Then
            Picamval.Image = My.Resources.Succed
        ElseIf Amval = False Then
            Picamval.Image = My.Resources._Error
        End If

        If Sarmayeh = True Then
            PicSarmayeh.Image = My.Resources.Succed
        ElseIf Sarmayeh = False Then
            PicSarmayeh.Image = My.Resources._Error
        End If

        If Kala = True Then
            PicKala.Image = My.Resources.Succed
        ElseIf Kala = False Then
            PicKala.Image = My.Resources._Error
        End If

        Array.Resize(FactorArray, 0)
        Array.Resize(SFactorArray, 0)
        Array.Resize(ListEditKala, 0)
        If AllowEdit < 0 Then
            MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf AllowEdit = 1 Then
            BtnSave.Enabled = False
        End If
    End Sub
    Private Sub DiffMon()
        Try
            Box = True
            Bank = True
            Amval = True
            Sarmayeh = True
            Kala = True
            ''''''''''''''''''''''''''''''''''''''''''
            Tmp_DtBox.Clear()
            Tmp_DtBox.Columns.Clear()
            '''''''''''
            Tmp_DtBank.Clear()
            Tmp_DtBank.Columns.Clear()
            '''''''''''
            Tmp_DtAmval.Clear()
            Tmp_DtAmval.Columns.Clear()
            '''''''''''
            Tmp_DtSarmayeh.Clear()
            Tmp_DtSarmayeh.Columns.Clear()
            '''''''''''
            Tmp_DtKala.Clear()
            Tmp_DtKala.Columns.Clear()
            '''''''''''
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT id,Nam,discription,(MoeinBox +AllMoney) AS NewMandeh FROM (SELECT ID,discription,nam,(SELECT (SUM(bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =Define_Box.ID AND T=1) As Bes ) AS MoeinBox , ISNULL(Allmoney,0) AS AllMoney FROM Define_Box) As AllMoeinBox ORDER By NewMandeh", ConectionBank)
                cmd.CommandTimeout = 0
                Tmp_DtBox.Load(cmd.ExecuteReader)
                Tmp_DtBox.Columns("NewMandeh").ReadOnly = False
                For i As Integer = 0 To Tmp_DtBox.Rows.Count - 1
                    If Tmp_DtBox.Rows(i).Item("NewMandeh") < 0 Then Box = False
                Next
            End Using

            Using cmd As New SqlCommand("SELECT id,NamP,Nam,shobeh,tell,[address],[State],number_n,(MoeinBank +AllMoney) AS NewMandeh FROM (SELECT ID,nam AS NamP,shobeh,tell,[address],[State],n_bank AS Nam,number_n,(SELECT (SUM(bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBank =Define_Bank .ID AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE IDBank =Define_Bank .ID AND T=1) As Bes ) AS MoeinBank , ISNULL(Allmoney,0) AS AllMoney FROM Define_Bank) As AllMoeinBank ORDER By NewMandeh", ConectionBank)
                cmd.CommandTimeout = 0
                Tmp_DtBank.Load(cmd.ExecuteReader)
                Tmp_DtBank.Columns("NewMandeh").ReadOnly = False
                For i As Integer = 0 To Tmp_DtBank.Rows.Count - 1
                    If Tmp_DtBank.Rows(i).Item("NewMandeh") < 0 Then Bank = False
                Next
            End Using

            Using cmd As New SqlCommand("SELECT Id,IdOne,IdCodeTwo,discription,NamCharge AS Nam ,(ISNULL(SUM(BedMon),0) - ISNULL(SUM(BesMon),0)) AS Mandeh,(ISNULL(SUM(BedMon),0) - ISNULL(SUM(BesMon),0)) AS NewMandeh  FROM (SELECT Define_Amval.ID,IdOne,IdCodeTwo,discription,Nam  As Namcharge,BedMon=CASE Get_Pay_Amval.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Amval.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END FROM  Get_Pay_Amval INNER JOIN Define_Amval ON Get_Pay_Amval.IdAmval = Define_Amval.ID INNER JOIN Define_OneAmval ON Define_Amval.IdOne = Define_OneAmval .Id  UNION ALL SELECT Define_Amval.ID,IdOne,IdCodeTwo,discription,Nam  As Namcharge ,BedMon=AllMoney, BesMon= 0 FROM Define_Amval INNER JOIN Define_OneAmval ON Define_Amval.IdOne =Define_OneAmval.Id)AS AllCharge GROUP By Id,NamCharge,IdOne,IdCodeTwo,discription ORDER BY NamCharge", ConectionBank)
                cmd.CommandTimeout = 0
                Tmp_DtAmval.Load(cmd.ExecuteReader)
                Tmp_DtAmval.Columns("NewMandeh").ReadOnly = False
                For i As Integer = 0 To Tmp_DtAmval.Rows.Count - 1
                    If Tmp_DtAmval.Rows(i).Item("NewMandeh") < 0 Then Amval = False
                Next
            End Using

            Using cmd As New SqlCommand("SELECT Id,IdCodeTwo,IdOne,discription,NamCharge As Nam ,(ISNULL(SUM(BedMon),0) - ISNULL(SUM(BesMon),0)) As Mandeh,(ISNULL(SUM(BedMon),0) - ISNULL(SUM(BesMon),0)) As NewMandeh  FROM (SELECT Define_Sarmayeh.ID,IdCodeTwo,IdOne,discription,Nam  As Namcharge,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh + MonPayChk+ MonsellChk+ Lend) ELSE 0 END FROM Get_Pay_Sarmayeh INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh.IdSarmayeh = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id  UNION ALL SELECT Define_Sarmayeh.ID,IdCodeTwo,IdOne,discription,Nam  As Namcharge ,BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id)AS AllCharge GROUP By NamCharge,ID,IdCodeTwo,IdOne,discription ORDER BY NamCharge", ConectionBank)
                cmd.CommandTimeout = 0
                Tmp_DtSarmayeh.Load(cmd.ExecuteReader)
                Tmp_DtSarmayeh.Columns("NewMandeh").ReadOnly = False
                Sarmayeh = True
            End Using

            Using cmd As New SqlCommand("SELECT * FROM (SELECT Activ,Id,Idanbar,DK,DK_KOL,DK_JOZ,Nam,NamAnbar ,KolCount,JozCount,Fe,AllMon = ROUND(Fe*(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),0) FROM (SELECT IdAnbar,Activ,Id,DK,DK_KOL ,DK_JOZ,Nam,NamAnbar,KolCount,JozCount,Fe=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 ELSE dbo.GetCost(id,(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') END FROM (SELECT * FROM (SELECT AllKalaAnbar.*,(SELECT ROUND(ISNULL(SUM(AllKolCount.KolCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar) AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(AllJozCount.JozCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar) AS AllJozCount)JozCount FROM (SELECT AllKala.*,Define_Anbar.nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Id,Define_Kala.Nam,Define_Kala.Activ,Define_Kala.DK,Define_Kala.DK_KOL,Define_Kala.DK_JOZ FROM Define_Kala ) AS AllKala ,Define_Anbar ) As AllKalaAnbar) As AllAnbar) As AllAnbar2 ) As AllAnbar3) As AllAnbar4 Order by AllMon", ConectionBank)
                cmd.CommandTimeout = 0
                Tmp_DtKala.Load(cmd.ExecuteReader)
                Tmp_DtKala.Columns("KolCount").ReadOnly = False
                Tmp_DtKala.Columns("JozCount").ReadOnly = False
                Tmp_DtKala.Columns("Fe").ReadOnly = False
                Tmp_DtKala.Columns("AllMon").ReadOnly = False
                For i As Integer = 0 To Tmp_DtKala.Rows.Count - 1
                    If Tmp_DtKala.Rows(i).Item("AllMon") < 0 Then Kala = False
                    If (Tmp_DtKala.Rows(i).Item("KolCount") > 0 Or Tmp_DtKala.Rows(i).Item("JozCount") > 0) And Tmp_DtKala.Rows(i).Item("Fe") <= 0 Then Kala = False
                    If (Tmp_DtKala.Rows(i).Item("KolCount") <= 0 And Tmp_DtKala.Rows(i).Item("JozCount") > 0) Then Kala = False
                    If (Tmp_DtKala.Rows(i).Item("KolCount") > 0 And Tmp_DtKala.Rows(i).Item("JozCount") <= 0 And Tmp_DtKala.Rows(i).Item("DK") = True) Then Kala = False
                Next
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEndAccounting", "DiffMon")
            Box = False
            Bank = False
            Amval = False
            Sarmayeh = False
            Kala = False
        End Try
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Box = False Or Bank = False Or Amval = False Or Sarmayeh = False Or Kala = False Then
            MessageBox.Show("قبل از بستن دوره مالی مغایرت ها را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtNewPeriod.Text) Then
            MessageBox.Show("نام دوره مالی جدید را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtNewPeriod.Focus()
            Exit Sub
        End If

        If Not AreYouAddAccounting(TxtNewPeriod.Text, Id_Account) Then
            MessageBox.Show("نام دوره مالی مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtNewPeriod.Focus()
            Exit Sub
        End If

        If BtnSearchpeople.Enabled = True And FactorArray.Length <= 0 Then
            MessageBox.Show("هیچ طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnSearchpeople.Focus()
            Exit Sub
        End If

        If BtnKala.Enabled = True And SFactorArray.Length <= 0 Then
            MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnKala.Focus()
            Exit Sub
        End If

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
            MessageBox.Show("وارد سیستم شده باشد  Admin  جهت بستن دوره مالی نباید هیچ کاربری به غیر از ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("آیا برای بستن دوره مالی مطمئن هستید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بستن دوره مالی", "بستن دوره مالی", "", "")

        Using FrmAc As New FrmActionEnd
            If ChkDelPeople.Checked = True Then
                If CmbPeople.Text = CmbPeople.Items(0) Then
                    FrmAc.People = 0
                ElseIf CmbPeople.Text = CmbPeople.Items(1) Then
                    FrmAc.People = 1
                ElseIf CmbPeople.Text = CmbPeople.Items(2) Then
                    FrmAc.People = 2
                ElseIf CmbPeople.Text = CmbPeople.Items(3) Then
                    FrmAc.People = 3
                End If
            Else
                FrmAc.People = -1
            End If
            '''''''''''''''''''''''''''''''''''''''
            If ChkKala.Checked = True Then
                If CmbKala.Text = CmbKala.Items(0) Then
                    FrmAc.kala = 0
                ElseIf CmbKala.Text = CmbKala.Items(1) Then
                    FrmAc.kala = 1
                ElseIf CmbKala.Text = CmbKala.Items(2) Then
                    FrmAc.kala = 2
                ElseIf CmbKala.Text = CmbKala.Items(3) Then
                    FrmAc.kala = 3
                End If
            Else
                FrmAc.kala = -1
            End If
            FrmAc.LNam.Text = TxtNewPeriod.Text.Trim
            FrmAc.ShowDialog()
        End Using
    End Sub

    Private Function AreYouAddAccounting(ByVal PeriodName As String, ByVal id As Long) As Boolean
        Dim DataSource2 As String = "Data Source=127.0.0.1;Initial Catalog=Manage_Nab;User ID=Nab_User;Password=q1w2e3r4t5;Connection Timeout=0"
        Dim ConectionBank2 As New SqlClient.SqlConnection(DataSource2)
        Try

            If ConectionBank2.State = ConnectionState.Closed Then ConectionBank2.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT COUNT(List_Period.PeriodName) FROM List_Accounting INNER JOIN List_Period ON List_Accounting.Id = List_Period.Id WHERE List_Accounting.Id =" & id & " AND List_Period.PeriodName=N'" & PeriodName & "'", ConectionBank2)
                Dim count As Long = Cmd.ExecuteScalar
                If ConectionBank2.State = ConnectionState.Open Then ConectionBank2.Close()
                If count <> 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEndAccounting", "AreYouAddAccounting")
            If ConectionBank2.State = ConnectionState.Open Then ConectionBank2.Close()
            Return False
        End Try
    End Function

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Using FrmBox As New FrmEditBox
            FrmBox.ShowDialog()
            Box = True
            For i As Integer = 0 To Tmp_DtBox.Rows.Count - 1
                If Tmp_DtBox.Rows(i).Item("NewMandeh") < 0 Then Box = False
            Next
            If Box = True Then
                PicBox.Image = My.Resources.Succed
            ElseIf Box = False Then
                PicBox.Image = My.Resources._Error
            End If
        End Using
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Using FrmBank As New FrmEditBank
            FrmBank.ShowDialog()
            Bank = True
            For i As Integer = 0 To Tmp_DtBank.Rows.Count - 1
                If Tmp_DtBank.Rows(i).Item("NewMandeh") < 0 Then Bank = False
            Next
            If Bank = True Then
                PicBank.Image = My.Resources.Succed
            ElseIf Bank = False Then
                PicBank.Image = My.Resources._Error
            End If
        End Using
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Using FrmAmval As New FrmEditAmval
            FrmAmval.ShowDialog()
            Amval = True
            For i As Integer = 0 To Tmp_DtAmval.Rows.Count - 1
                If Tmp_DtAmval.Rows(i).Item("NewMandeh") < 0 Then Amval = False
            Next
            If Amval = True Then
                Picamval.Image = My.Resources.Succed
            ElseIf Amval = False Then
                Picamval.Image = My.Resources._Error
            End If
        End Using
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Using Frmsarmayeh As New FrmEditSarmayeh
            Frmsarmayeh.ShowDialog()
            Sarmayeh = True
            If Sarmayeh = True Then
                PicSarmayeh.Image = My.Resources.Succed
            ElseIf Sarmayeh = False Then
                PicSarmayeh.Image = My.Resources._Error
            End If
        End Using
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Using Frmkala As New FrmEditKala
            Frmkala.ShowDialog()
            Kala = True
            For i As Integer = 0 To Tmp_DtKala.Rows.Count - 1
                If Tmp_DtKala.Rows(i).Item("AllMon") < 0 Then Kala = False
                If (Tmp_DtKala.Rows(i).Item("KolCount") > 0 Or Tmp_DtKala.Rows(i).Item("JozCount") > 0) And Tmp_DtKala.Rows(i).Item("Fe") <= 0 Then Kala = False
                If (Tmp_DtKala.Rows(i).Item("KolCount") <= 0 And Tmp_DtKala.Rows(i).Item("JozCount") > 0) Then Kala = False
                If (Tmp_DtKala.Rows(i).Item("KolCount") > 0 And Tmp_DtKala.Rows(i).Item("JozCount") <= 0 And Tmp_DtKala.Rows(i).Item("DK") = True) Then Kala = False
            Next
            If Kala = True Then
                PicKala.Image = My.Resources.Succed
            ElseIf Kala = False Then
                PicKala.Image = My.Resources._Error
            End If
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "CloseMali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnTraz.Enabled = True Then Call BtnTraz_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnTraz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTraz.Click

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "بستن دوره مالی", "تراز اختتامیه", "", "")

        Using FrmTraz As New TrazEnd
            FrmTraz.ShowDialog()
        End Using
    End Sub

    Private Sub ChkDelPeople_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDelPeople.CheckedChanged
        If ChkDelPeople.Checked = True Then
            CmbPeople.Enabled = True
            CmbPeople.Text = CmbPeople.Items(0)
        Else
            CmbPeople.Enabled = False
            BtnSearchpeople.Enabled = False
            ListSearchpeople.Enabled = False
        End If
    End Sub

    Private Sub CmbPeople_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPeople.SelectedIndexChanged
        If CmbPeople.Text = CmbPeople.Items(3) Then
            BtnSearchpeople.Enabled = True
            ListSearchpeople.Enabled = True
        Else
            BtnSearchpeople.Enabled = False
            ListSearchpeople.Enabled = False
        End If
    End Sub

    Private Sub ChkKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkKala.CheckedChanged
        If ChkKala.Checked = True Then
            CmbKala.Enabled = True
            CmbKala.Text = CmbKala.Items(0)
        Else
            CmbKala.Enabled = False
            BtnKala.Enabled = False
            ListKala.Enabled = False
        End If
    End Sub

    Private Sub BtnSearchpeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchpeople.Click
        Dim flag As Boolean = True
        Using FrmAdVance As New PeopleMoein_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        flag = True
                        For j As Integer = 0 To FactorArray.Length - 1
                            If AllSelectKala(i).IdKala = FactorArray(j).IdKala Then
                                flag = False
                            End If
                        Next
                        If flag = True Then
                            Array.Resize(FactorArray, FactorArray.Length + 1)
                            FactorArray(FactorArray.Length - 1).IdKala = AllSelectKala(i).IdKala
                            FactorArray(FactorArray.Length - 1).Disc = AllSelectKala(i).Namekala
                        End If
                    Next
                End If
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub BtnKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKala.Click
        Dim flag As Boolean = True
        Using FrmAdVance As New Kala_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.ChkActive.Checked = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        flag = True
                        For j As Integer = 0 To SFactorArray.Length - 1
                            If AllSelectKala(i).IdKala = SFactorArray(j).IdKala Then
                                flag = False
                            End If
                        Next

                        If flag = True Then
                            Array.Resize(SFactorArray, SFactorArray.Length + 1)
                            SFactorArray(SFactorArray.Length - 1).IdKala = AllSelectKala(i).IdKala
                            SFactorArray(SFactorArray.Length - 1).NamKala = AllSelectKala(i).Namekala
                        End If
                    Next
                End If
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub CmbKala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbKala.SelectedIndexChanged
        If CmbKala.Text = CmbKala.Items(3) Then
            BtnKala.Enabled = True
            ListKala.Enabled = True
        Else
            BtnKala.Enabled = False
            ListKala.Enabled = False
        End If
    End Sub

    Private Sub ListSearchpeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSearchpeople.Click
        Using frmlist As New ListEnd
            frmlist.Text = "لیست طرف حساب"
            frmlist.GroupBox2.Text = "لیست طرف حساب"
            frmlist.DGV.Columns("Cln_Name").HeaderText = "نام طرف حساب"
            frmlist.Llist.Text = "P"
            frmlist.ShowDialog()
        End Using
    End Sub

    Private Sub ListKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListKala.Click
        Using frmlist As New ListEnd
            frmlist.Text = "لیست کالا"
            frmlist.GroupBox2.Text = "لیست کالا"
            frmlist.DGV.Columns("Cln_Name").HeaderText = "نام کالا"
            frmlist.Llist.Text = "K"
            frmlist.ShowDialog()
        End Using
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Using FrmDay As New FrmGetPay
            FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(13)
            FrmDay.CmbSanad.Enabled = False
            FrmDay.GroupBox4.Enabled = False
            FrmDay.GroupBox5.Enabled = False
            FrmDay.ShowDialog()
        End Using
    End Sub
End Class