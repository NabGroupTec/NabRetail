Imports System.Data.SqlClient
Public Class Traz4Column
    Dim Dt As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز چهار ستونی", "چاپ تراز", "", "")
        FrmPrint.DtTraz = Dt
        FrmPrint.CHoose = "TRAZ4"
        FrmPrint.ShowDialog()
    End Sub

    Private Sub Traz4Column_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Taraz.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub
    Private Sub RefreshBank()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            '////////////////////////////////////////
            Dt.Clear()
            Dim str(5) As String
            Dim itm As ListViewItem
            ListTraz.Items.Clear()
            '''''''''''''''''''''دارایی ها
            Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'موجودی صندوق',BedMon=OnMoney+Bed ,BesMon=bes * (-1),BedAllMon=Case WHEN (OnMoney+bed+bes)>0 THEN (OnMoney+bed+bes) ELSE 0 END ,BesAllMon=Case WHEN (OnMoney+bed+bes)<0 THEN (OnMoney+bed+bes)*(-1) ELSE 0 END  FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE  T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE  T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_box )As AllOneMoney )As One UNION ALL SELECT K=0,d=1,Nam,(Bed+AllMoney) As BedMon,Bes As BesMon,BedAllMon=Case WHEN (Bed+AllMoney-bes)>0 THEN (Bed+AllMoney-bes) ELSE 0 END ,BesAllMon=Case WHEN (Bed+AllMoney-bes)<0 THEN (Bed+AllMoney-bes) * (-1) ELSE 0 END FROM (SELECT nam,(SELECT SUM(bed)AS bed FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=0) AS Bed ) AS Bed,(SELECT SUM(bes)AS bes FROM (SELECT ISNULL(SUM(MON),0) AS BES FROM Moein_BOX WHERE IDBOX =Define_Box.ID AND T=1) As Bes ) AS Bes , ISNULL(Allmoney,0) AS AllMoney FROM Define_Box) AS LowBox", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'موجودی بانکها',BedMon=OnMoney+Bed ,BesMon=bes * (-1),BedAllMon=Case WHEN (OnMoney+bed+bes)>0 THEN (OnMoney+bed+bes) ELSE 0 END ,BesAllMon=Case WHEN (OnMoney+bed+bes)<0 THEN (OnMoney+bed+bes)*(-1) ELSE 0 END  FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE  T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE  T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank )As AllOneMoney )As One UNION ALL SELECT K=0,d=1,Nam,(Bed+AllMoney) As BedMon,Bes As BesMon,BedAllMon=Case WHEN (Bed+AllMoney-bes)>0 THEN (Bed+AllMoney-bes) ELSE 0 END ,BesAllMon=Case WHEN (Bed+AllMoney-bes)<0 THEN (Bed+AllMoney-bes) * (-1) ELSE 0 END FROM (SELECT n_bank As Nam,(SELECT SUM(bed)AS bed FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBANK =Define_Bank.ID  AND T=0) AS Bed ) AS Bed,(SELECT SUM(bes)AS bes FROM (SELECT ISNULL(SUM(MON),0) AS BES FROM Moein_Bank WHERE IDBANK =Define_Bank.ID AND T=1) As Bes ) AS Bes , ISNULL(Allmoney,0) AS AllMoney FROM Define_Bank) AS LowBox", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'اسناد دریافتی',BedMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END ,BesMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END,BedAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END ,BesAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4) UNION ALL SELECT K=0,D=1,Nam=N'در جریان وصول',BedMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END ,BesMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END,BedAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END ,BesAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 ) UNION ALL SELECT K=0,D=1,Nam=N'برات',BedMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END ,BesMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END,BedAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END ,BesAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =4 )", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'بدهکاران',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon ,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM (SELECT Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE BedMon -BesMon>0 UNION ALL SELECT K=0,D=1,Nam=N'اشخاص سایر',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='False' AND Seller='False' AND Other='True') AND (BedMon -BesMon>0) UNION ALL SELECT K=0,D=1,Nam=N'اشخاص خریدار',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='True' AND Seller='False' AND Other='False') AND (BedMon -BesMon>0) UNION ALL SELECT K=0,D=1,Nam=N'اشخاص فروشنده',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='False' AND Seller='True' AND Other='False') AND (BedMon -BesMon>0) UNION ALL SELECT K=0,D=1,Nam=N'اشخاص خریدار/فروشنده',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='True' AND Seller='True' AND Other='False') AND (BedMon -BesMon>0)", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using
            'محاسبه بر حسب دو قیمت خرید اخر
            'Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'موجودی کالا',BedMon=Case WHEN ISNULL(SUM(AllMon),0) >=0 THEN ISNULL(SUM(AllMon),0) ELSE 0 END ,BesMon=Case WHEN ISNULL(SUM(AllMon),0) <0 THEN ISNULL(SUM(AllMon),0) * (-1) ELSE 0 END ,BedAllMon=Case WHEN ISNULL(SUM(AllMon),0) >=0 THEN ISNULL(SUM(AllMon),0) ELSE 0 END ,BesAllMon=Case WHEN ISNULL(SUM(AllMon),0) <0 THEN ISNULL(SUM(AllMon),0) * (-1) ELSE 0 END FROM(SELECT AllMon=CASE WHEN JozCount=0 THEN ROUND(KolCount*Fe,0) ELSE ROUND(JozCount*Fe,0) END  FROM (SELECT id,KolCount ,JozCount,Fe=(SELECT ROUND(Mon/(CASE WHEN JozCount=0 AND KolCount=0 THEN 1 WHEN JozCount=0 AND KolCount<>0 THEN KolCount  ELSE JozCount END),0) AS EndCostKala  FROM (SELECT ISNULL(SUM(KolCount),0) AS KolCount, ISNULL(SUM(JozCount),0) As JozCount, ISNULL(SUM(Mon),0) AS Mon FROM (SELECT TOP 2 KolCount, JozCount,Mon,DarsadMon FROM (SELECT  KolCount, JozCount, DarsadMon, Mon, D_date FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND Mon >0 AND IdKala =AllKalanfe.id) UNION ALL SELECT  Count_Kol as KolCount,Count_Joz as JozCount,DarsadMon=0,Mon ,D_date   FROM Define_PrimaryKala WHERE (Mon >0 AND IdKala =AllKalanfe.id))AS CostKala ORDER BY D_date DESC) AS Edata) As E2Data) FROM (SELECT id ,ROUND(KolCount,2) AS KolCount ,ROUND(JozCount,2) As JozCount   FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount)JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) AS AllKala )As EndData  )As AllKalaNfe ) AS AllKalaFe ) AS EndList", ConectionBank)
            '    Cmd.CommandTimeout = 0
            '    Dt.Load(Cmd.ExecuteReader)
            'End Using

            Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'موجودی کالا',BedMon=Case WHEN ISNULL(SUM(AllMon),0) >=0 THEN ISNULL(SUM(AllMon),0) ELSE 0 END,BesMon=Case WHEN ISNULL(SUM(AllMon),0) <0 THEN ISNULL(SUM(AllMon),0) * (-1) ELSE 0 END,BedAllMon=Case WHEN ISNULL(SUM(AllMon),0) >=0 THEN ISNULL(SUM(AllMon),0) ELSE 0 END ,BesAllMon=Case WHEN ISNULL(SUM(AllMon),0) <0 THEN ISNULL(SUM(AllMon),0) * (-1) ELSE 0 END FROM (SELECT AllMon=ROUND(Fe*(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),0) FROM (SELECT id,DK,KolCount,JozCount,Fe=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 ELSE dbo.GetCostCharge(id,(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') END FROM (SELECT id,DK,ROUND(KolCount,2) AS KolCount,ROUND(JozCount,2) As JozCount FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount)JozCount FROM (SELECT Define_Kala.Id,Define_Kala.DK FROM Define_Kala ) AS AllKala )As EndData  )As AllKalaNfe ) AS AllKalaFe ) AS EndList", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Using Cmd As New SqlCommand("SELECT K=0,D=0,Nam=N'اموال',BedMon=ISNULL(SUM(BedMon),0),BesMon=ISNULL(SUM(BesMon),0),BedAllMon=CASE WHEN ISNULL(SUM(BedMon-BesMon),0)>=0 THEN ISNULL(SUM(BedMon-BesMon),0) ELSE 0 END,BesAllMon=CASE WHEN ISNULL(SUM(BedMon-BesMon),0)<0 THEN ISNULL(SUM(BedMon-BesMon),0) * (-1) ELSE 0 END FROM (SELECT  D_date,BedMon=CASE Get_Pay_Amval.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Amval.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Amval  INNER JOIN Define_Amval ON Get_Pay_Amval .IdAmval  = Define_Amval .ID INNER JOIN Define_OneAmval  ON Define_Amval .IdOne = Define_OneAmval .Id  UNION ALL SELECT D_date=N'',BedMon=AllMoney, BesMon= 0  FROM Define_Amval INNER JOIN Define_OneAmval ON Define_Amval .IdOne =Define_OneAmval.Id  )AS AllCharge UNION ALL SELECT K=0,D=1,Nam,BedMon,BesMon,BedAllMon=CASE WHEN ISNULL(BedMon-BesMon,0)>=0 THEN ISNULL(BedMon-BesMon,0) ELSE 0 END,BesAllMon=CASE WHEN ISNULL(BedMon-BesMon,0)<0 THEN ISNULL(BedMon-BesMon,0) * (-1) ELSE 0 END FROM (SELECT Nam,ISNULL (SUM(BedMon),0) As BedMon,ISNULL (SUM(BesMon),0) As BesMon FROM (SELECT Define_Amval .nam , BedMon=CASE Get_Pay_Amval.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Amval.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Amval  INNER JOIN Define_Amval ON Get_Pay_Amval .IdAmval  = Define_Amval .ID INNER JOIN Define_OneAmval  ON Define_Amval .IdOne = Define_OneAmval .Id  UNION ALL SELECT Define_Amval .nam, BedMon=AllMoney, BesMon= 0  FROM Define_Amval INNER JOIN Define_OneAmval ON Define_Amval .IdOne =Define_OneAmval.Id )As ListAmval GROUP By nam )As ListA", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Dim row As DataRow = Nothing
            row = Dt.NewRow
            row.Item("K") = 2
            row.Item("D") = 0
            row.Item("Nam") = "جمع کل دارایی ها"
            Dim ResBed As Double = 0
            Dim ResBes As Double = 0
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("D") = 0 And Dt.Rows(i).Item("K") = 0 Then
                    ResBed += Dt.Rows(i).Item("BedMon")
                    ResBes += Dt.Rows(i).Item("BesMon")
                End If
            Next
            row.Item("BedMon") = ResBed
            row.Item("BesMon") = ResBes

            row.Item("BedAllMon") = If(row.Item("BedMon") - row.Item("BesMon") >= 0, (row.Item("BedMon") - row.Item("BesMon")), 0)
            row.Item("BesAllMon") = If(row.Item("BedMon") - row.Item("BesMon") < 0, (row.Item("BedMon") - row.Item("BesMon")) * (-1), 0)
            Dt.Rows.Add(row)

            '''''''''''''''''''''''''''بدهی و سرمایه
            Using Cmd As New SqlCommand("SELECT K=1,D=0,Nam=N'اسناد پرداختی',BedMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0) * (-1) ELSE 0 END ,BesMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0)  ELSE 0 END,BedAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)<0 THEN ISNULL(SUM(MoneyChk),0)* (-1) ELSE 0 END ,BesAllMon=CASE WHEN  ISNULL(SUM(MoneyChk),0)>=0 THEN ISNULL(SUM(MoneyChk),0) ELSE 0 END FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind)", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Using Cmd As New SqlCommand("SELECT K=1,D=0,Nam=N'بستانکاران',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon ,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM (SELECT Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE BedMon -BesMon<0 UNION ALL SELECT K=1,D=1,Nam=N'اشخاص سایر',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='False' AND Seller='False' AND Other='True') AND (BedMon -BesMon<0) UNION ALL SELECT K=1,D=1,Nam=N'اشخاص خریدار',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='True' AND Seller='False' AND Other='False') AND (BedMon -BesMon<0) UNION ALL SELECT K=1,D=1,Nam=N'اشخاص فروشنده',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='False' AND Seller='True' AND Other='False') AND (BedMon -BesMon<0) UNION ALL SELECT K=1,D=1,Nam=N'اشخاص خریدار/فروشنده',ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon,BedAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)>=0  THEN ISNULL(SUM(BedMon -BesMon),0) ELSE 0 END ,BesAllMon=Case When ISNULL(SUM(BedMon -BesMon),0)<0  THEN ISNULL(SUM(BedMon -BesMon),0) * (-1) ELSE 0 END FROM(SELECT  Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol WHERE (Buyer='True' AND Seller='True' AND Other='False') AND (BedMon -BesMon<0)", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            Using Cmd As New SqlCommand("SELECT K=1,D=0 ,Nam=N'سرمایه گذاران' ,ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon ,BedAllMon=CASE WHEN ISNULL(SUM(BedMon-BesMon),0)>=0 THEN ISNULL(SUM(BedMon-BesMon),0) ELSE 0 END ,BesAllMon=CASE WHEN ISNULL(SUM(BedMon-BesMon),0)<0 THEN ISNULL(SUM(BedMon-BesMon),0) * (-1) ELSE 0 END FROM (SELECT  D_date,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id  UNION ALL SELECT D_date=N'',BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id  )AS AllCharge UNION ALL SELECT K=1,D=1,Nam,BedMon=ISNULL(SUM(BedMon),0),BesMon=ISNULL(SUM(BesMon),0),BedAllMon=CASE WHEN ISNULL(SUM(BedMon-BesMon),0)>=0 THEN ISNULL(SUM(BedMon-BesMon),0) ELSE 0 END,BesAllMon=CASE WHEN ISNULL(SUM(BedMon-BesMon),0)<0 THEN ISNULL(SUM(BedMon-BesMon),0) * (-1) ELSE 0 END FROM (SELECT Define_Sarmayeh.nam , BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id UNION ALL SELECT Define_Sarmayeh.nam , BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id ) As ListS GROUP BY nam ", ConectionBank)
                Cmd.CommandTimeout = 0
                Dt.Load(Cmd.ExecuteReader)
            End Using

            row = Nothing
            row = Dt.NewRow
            row.Item("K") = 3
            row.Item("D") = 0
            row.Item("Nam") = "جمع کل بدهی ها"
            ResBed = 0
            ResBes = 0
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("D") = 0 And Dt.Rows(i).Item("K") = 1 Then
                    ResBed += Dt.Rows(i).Item("BedMon")
                    ResBes += Dt.Rows(i).Item("BesMon")
                End If
            Next
            row.Item("BedMon") = ResBed
            row.Item("BesMon") = ResBes

            row.Item("BedAllMon") = If(row.Item("BedMon") - row.Item("BesMon") >= 0, (row.Item("BedMon") - row.Item("BesMon")), 0)
            row.Item("BesAllMon") = If(row.Item("BedMon") - row.Item("BesMon") < 0, (row.Item("BedMon") - row.Item("BesMon")) * (-1), 0)
            Dt.Rows.Add(row)


            row = Nothing
            row = Dt.NewRow
            row.Item("K") = 4
            row.Item("D") = 0
            row.Item("Nam") = "سود و زیان ناویژه"
            ResBed = 0
            ResBes = 0
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("D") = 0 And (Dt.Rows(i).Item("K") = 2 Or Dt.Rows(i).Item("K") = 3) Then
                    ResBed += Dt.Rows(i).Item("BedMon")
                    ResBes += Dt.Rows(i).Item("BesMon")
                End If
            Next
            row.Item("BedMon") = ResBed
            row.Item("BesMon") = ResBes

            row.Item("BedAllMon") = If(row.Item("BedMon") - row.Item("BesMon") < 0, (row.Item("BedMon") - row.Item("BesMon")) * (-1), 0)
            row.Item("BesAllMon") = If(row.Item("BedMon") - row.Item("BesMon") >= 0, (row.Item("BedMon") - row.Item("BesMon")), 0)
            Dt.Rows.Add(row)

            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("D") = 0 And Dt.Rows(i).Item("K") = 3 Then
                    Dt.Columns("BedMon").ReadOnly = False
                    Dt.Columns("BesMon").ReadOnly = False
                    Dt.Columns("BedAllMon").ReadOnly = False
                    Dt.Columns("BesAllMon").ReadOnly = False
                    Dt.Rows(i).Item("BedMon") += ResBes ' If(ResBed - ResBes < 0, Dt.Rows(i).Item("BedMon") - ResBed, Dt.Rows(i).Item("BedMon") + ResBed)
                    Dt.Rows(i).Item("BesMon") += ResBed 'If(ResBed - ResBes < 0, Dt.Rows(i).Item("BesMon") - ResBes, Dt.Rows(i).Item("BesMon") + ResBes)
                    Dt.Rows(i).Item("BedAllMon") = If(Dt.Rows(i).Item("BedMon") - Dt.Rows(i).Item("BesMon") >= 0, (Dt.Rows(i).Item("BedMon") - Dt.Rows(i).Item("BesMon")), 0)
                    Dt.Rows(i).Item("BesAllMon") = If(Dt.Rows(i).Item("BedMon") - Dt.Rows(i).Item("BesMon") < 0, (Dt.Rows(i).Item("BedMon") - Dt.Rows(i).Item("BesMon")) * (-1), 0)
                    Dt.AcceptChanges()
                    Exit For
                End If
            Next
            ''''''''''''''''''''''''''''''''''''
            row = Nothing
            row = Dt.NewRow
            row.Item("K") = 5
            row.Item("D") = 0
            row.Item("Nam") = "وضعیت تراز"
            ResBed = 0
            ResBes = 0
            Dim ResAllBed As Double = 0
            Dim ResAllBes As Double = 0
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("D") = 0 And (Dt.Rows(i).Item("K") = 2 Or Dt.Rows(i).Item("K") = 3) Then
                    ResBed += Dt.Rows(i).Item("BedMon")
                    ResBes += Dt.Rows(i).Item("BesMon")
                    ResAllBed += Dt.Rows(i).Item("BedAllMon")
                    ResAllBes += Dt.Rows(i).Item("BesAllMon")
                End If

                'If Dt.Rows(i).Item("D") = 0 And Dt.Rows(i).Item("K") = 4 Then
                '    ResBed += Dt.Rows(i).Item("BedAllMon")
                '    ResBes += Dt.Rows(i).Item("BesAllMon")
                '    ResAllBed += Dt.Rows(i).Item("BedAllMon")
                '    ResAllBes += Dt.Rows(i).Item("BesAllMon")
                'End If
            Next
            row.Item("BedMon") = ResBed
            row.Item("BesMon") = ResBes

            row.Item("BedAllMon") = ResAllBed
            row.Item("BesAllMon") = ResAllBes
            Dt.Rows.Add(row)

            '''''''''''''''''''''''''''''''''
            Dt.Columns("Nam").ReadOnly = False
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("D") = 0 Then
                    str(0) = Dt.Rows(i).Item("Nam")
                Else
                    str(0) = "                      " & Dt.Rows(i).Item("Nam")
                    Dt.Rows(i).Item("Nam") = "                         " & Dt.Rows(i).Item("Nam")
                End If
                str(1) = If(Dt.Rows(i).Item("BedMon").ToString.Length < 3, Dt.Rows(i).Item("BedMon"), FormatNumber(Dt.Rows(i).Item("BedMon"), 0))
                str(2) = If(Dt.Rows(i).Item("BesMon").ToString.Length < 3, Dt.Rows(i).Item("BesMon"), FormatNumber(Dt.Rows(i).Item("BesMon"), 0))
                str(3) = If(Dt.Rows(i).Item("BedAllMon").ToString.Length < 3, Dt.Rows(i).Item("BedAllMon"), FormatNumber(Dt.Rows(i).Item("BedAllMon"), 0))
                str(4) = If(Dt.Rows(i).Item("BesAllMon").ToString.Length < 3, Dt.Rows(i).Item("BesAllMon"), FormatNumber(Dt.Rows(i).Item("BesAllMon"), 0))
                itm = New ListViewItem(str)
                ListTraz.Items.Add(itm)

                If Dt.Rows(i).Item("K") = 0 Or Dt.Rows(i).Item("K") = 1 Then
                    If Dt.Rows(i).Item("D") = 0 Then
                        ListTraz.Items(i).ForeColor = Color.Blue
                    ElseIf Dt.Rows(i).Item("D") = 1 Then
                        ListTraz.Items(i).ForeColor = Color.Black
                    End If
                ElseIf Dt.Rows(i).Item("K") = 2 Then
                    ListTraz.Items(i).ForeColor = Color.DarkGreen
                    ListTraz.Items(i).BackColor = Color.LightGray
                ElseIf Dt.Rows(i).Item("K") = 3 Then
                    ListTraz.Items(i).ForeColor = Color.DarkGreen
                    ListTraz.Items(i).BackColor = Color.LightGray
                ElseIf Dt.Rows(i).Item("K") = 4 Then
                    ListTraz.Items(i).ForeColor = Color.DarkGreen
                    ListTraz.Items(i).BackColor = Color.LightGray
                ElseIf Dt.Rows(i).Item("K") = 5 Then
                    ListTraz.Items(i).ForeColor = Color.DarkRed
                    ListTraz.Items(i).BackColor = Color.SpringGreen
                End If
            Next

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Traz2Column", "RefreshBank")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub Traz4Column_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F98")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    If Access_Form.Substring(3, 1) = 0 Then
                        Button1.Enabled = False
                    End If
                    Me.RefreshBank()
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز چهار ستونی", "ورود", "", "")
                End If
            End If
        Else
            Me.RefreshBank()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز چهار ستونی", "ورود", "", "")
        End If
    End Sub
End Class