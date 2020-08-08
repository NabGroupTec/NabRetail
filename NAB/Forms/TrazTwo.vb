Imports System.Data.SqlClient
Public Class TrazTwo
    Dim SqlQuery As String = "SELECT GetChk,PayChk,MoeinBox,MoeinBank,BedMandeh ,BesMandeh,Kala ,Amval,ABS(Sarmayeh) AS Sarmayeh FROM (SELECT  ISNULL(SUM(MoneyChk),0) AS GetChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)) AS V1,(SELECT  ISNULL(SUM(MoneyChk),0) AS PayChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind) ) AS V2,(SELECT (SUM(OnMoney+bed+bes))AS MoeinBox FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE  T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE  T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_box )As AllOneMoney )As One) AS V3,(SELECT (SUM(OnMoney+bed+bes))AS MoeinBank FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoneyBank .Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank)As AllOneMoneyBank )As One1) As V4,(SELECT ISNULL(SUM(Mandeh),0) As BedMandeh   FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol  WHERE Mandeh>=0) AS V5,(SELECT ABS(ISNULL(SUM(Mandeh),0)) As BesMandeh  FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol WHERE Mandeh<0) AS V6,(SELECT ISNULL(SUM(AllMon),0) AS Kala FROM(SELECT AllMon=CASE WHEN JozCount=0 THEN ROUND(KolCount*Fe,0) ELSE ROUND(JozCount*Fe,0) END  FROM (SELECT id,KolCount ,JozCount,Fe=(SELECT ROUND(Mon/(CASE WHEN JozCount=0 AND KolCount=0 THEN 1 WHEN JozCount=0 AND KolCount<>0 THEN KolCount  ELSE JozCount END),0) AS EndCostKala  FROM (SELECT ISNULL(SUM(KolCount),0) AS KolCount, ISNULL(SUM(JozCount),0) As JozCount, ISNULL(SUM(Mon),0) AS Mon FROM (SELECT TOP 2 KolCount, JozCount,Mon,DarsadMon FROM (SELECT  KolCount, JozCount, DarsadMon, Mon, D_date FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND Mon >0 AND IdKala =AllKalanfe.id) UNION ALL SELECT  Count_Kol as KolCount,Count_Joz as JozCount,DarsadMon=0,Mon ,D_date   FROM Define_PrimaryKala WHERE (Mon >0 AND IdKala =AllKalanfe.id))AS CostKala ORDER BY D_date DESC) AS Edata) As E2Data) FROM (SELECT id ,ROUND(KolCount,2) AS KolCount ,ROUND(JozCount,2) As JozCount   FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount)JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  ) AS AllKala )As EndData  )As AllKalaNfe ) AS AllKalaFe ) AS EndList) AS V7,(SELECT ISNULL(SUM(BedMon-BesMon),0) As Amval  FROM (SELECT  D_date,BedMon=CASE Get_Pay_Amval.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Amval.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Amval  INNER JOIN Define_Amval ON Get_Pay_Amval .IdAmval  = Define_Amval .ID INNER JOIN Define_OneAmval  ON Define_Amval .IdOne = Define_OneAmval .Id  UNION ALL SELECT D_date=N'',BedMon=AllMoney, BesMon= 0  FROM Define_Amval INNER JOIN Define_OneAmval ON Define_Amval .IdOne =Define_OneAmval.Id  )AS AllCharge ) AS V8,(SELECT ISNULL(SUM(BedMon-BesMon),0) As Sarmayeh   FROM (SELECT  D_date,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id  UNION ALL SELECT D_date=N'',BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id  )AS AllCharge) As V9"
    Private Sub TrazOne_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Button1.Focus()
    End Sub

    Private Sub TrazOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RefreshBank()
        Try
            SqlQuery = "SELECT GetChk,PayChk,MoeinBox,MoeinBank,BedMandeh ,BesMandeh,Kala ,Amval,ABS(Sarmayeh) AS Sarmayeh FROM (SELECT  ISNULL(SUM(MoneyChk),0) AS GetChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)) AS V1,(SELECT  ISNULL(SUM(MoneyChk),0) AS PayChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind) ) AS V2,(SELECT (SUM(OnMoney+bed+bes))AS MoeinBox FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE  T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE  T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_box )As AllOneMoney )As One) AS V3,(SELECT (SUM(OnMoney+bed+bes))AS MoeinBank FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoneyBank .Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank)As AllOneMoneyBank )As One1) As V4,(SELECT ISNULL(SUM(Mandeh),0) As BedMandeh   FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol  WHERE Mandeh>=0) AS V5,(SELECT ABS(ISNULL(SUM(Mandeh),0)) As BesMandeh  FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol WHERE Mandeh<0) AS V6,(SELECT ISNULL(SUM(AllMon),0) AS Kala FROM(SELECT AllMon=CASE WHEN JozCount=0 THEN ROUND(KolCount*Fe,0) ELSE ROUND(JozCount*Fe,0) END  FROM (SELECT id,KolCount ,JozCount,Fe=(SELECT ROUND(Mon/(CASE WHEN JozCount=0 AND KolCount=0 THEN 1 WHEN JozCount=0 AND KolCount<>0 THEN KolCount  ELSE JozCount END),0) AS EndCostKala  FROM (SELECT ISNULL(SUM(KolCount),0) AS KolCount, ISNULL(SUM(JozCount),0) As JozCount, ISNULL(SUM(Mon),0) AS Mon FROM (SELECT TOP 2 KolCount, JozCount,Mon,DarsadMon FROM (SELECT  KolCount, JozCount, DarsadMon, Mon, D_date FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (Stat =0 and ListFactorBuy.Activ =1 AND Mon >0 AND IdKala =AllKalanfe.id) UNION ALL SELECT  Count_Kol as KolCount,Count_Joz as JozCount,DarsadMon=0,Mon ,D_date   FROM Define_PrimaryKala WHERE (Mon >0 AND IdKala =AllKalanfe.id))AS CostKala ORDER BY D_date DESC) AS Edata) As E2Data) FROM (SELECT id ,ROUND(KolCount,2) AS KolCount ,ROUND(JozCount,2) As JozCount   FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount)JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  ) AS AllKala )As EndData  )As AllKalaNfe ) AS AllKalaFe ) AS EndList) AS V7,(SELECT ISNULL(SUM(BedMon-BesMon),0) As Amval  FROM (SELECT  D_date,BedMon=CASE Get_Pay_Amval.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Amval.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Amval  INNER JOIN Define_Amval ON Get_Pay_Amval .IdAmval  = Define_Amval .ID INNER JOIN Define_OneAmval  ON Define_Amval .IdOne = Define_OneAmval .Id  UNION ALL SELECT D_date=N'',BedMon=AllMoney, BesMon= 0  FROM Define_Amval INNER JOIN Define_OneAmval ON Define_Amval .IdOne =Define_OneAmval.Id  )AS AllCharge ) AS V8,(SELECT ISNULL(SUM(BedMon-BesMon),0) As Sarmayeh   FROM (SELECT  D_date,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id  UNION ALL SELECT D_date=N'',BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id  )AS AllCharge) As V9"
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT (SUM(OnMoney+bed+bes))AS MoeinBox FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE  T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE  T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_box )As AllOneMoney )As One", ConectionBank)
                Cmd.CommandTimeout = 0
                TxtBox.Text = Cmd.ExecuteScalar()
            End Using

            Using Cmd As New SqlCommand("SELECT (SUM(OnMoney+bed+bes))AS MoeinBank FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoneyBank .Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank)As AllOneMoneyBank )As One1", ConectionBank)
                Cmd.CommandTimeout = 0
                TxtBank.Text = Cmd.ExecuteScalar() 'dtr("MoeinBank")
            End Using

            Using Cmd As New SqlCommand("SELECT  ISNULL(SUM(MoneyChk),0) AS GetChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtget.Text = Cmd.ExecuteScalar() 'dtr("GetChk")
            End Using

            Using Cmd As New SqlCommand("SELECT ISNULL(SUM(Mandeh),0) As BedMandeh   FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol  WHERE Mandeh>=0", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtbed.Text = Cmd.ExecuteScalar() 'dtr("BedMandeh")
            End Using

            Using Cmd As New SqlCommand("SELECT ISNULL(SUM(ROUND(Fe*(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),0)),0) AS Kala FROM (SELECT id,DK,KolCount,JozCount,Fe=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 ELSE dbo.GetCostCharge(id,(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') END FROM (SELECT id,DK,KolCount,JozCount FROM (SELECT id,DK,ROUND(KolCount,2) AS KolCount,ROUND(JozCount,2) As JozCount FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount)JozCount FROM (SELECT Define_Kala.Id,Define_Kala.DK FROM Define_Kala ) AS AllKala )As EndData )As AllKalaNfe ) AS AllKalaFe) AS AllKalaFe2", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtkala.Text = Cmd.ExecuteScalar() ' dtr("Kala")
            End Using

            Using Cmd As New SqlCommand("SELECT ISNULL(SUM(BedMon-BesMon),0) As Amval  FROM (SELECT  D_date,BedMon=CASE Get_Pay_Amval.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Amval.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Amval  INNER JOIN Define_Amval ON Get_Pay_Amval .IdAmval  = Define_Amval .ID INNER JOIN Define_OneAmval  ON Define_Amval .IdOne = Define_OneAmval .Id  UNION ALL SELECT D_date=N'',BedMon=AllMoney, BesMon= 0  FROM Define_Amval INNER JOIN Define_OneAmval ON Define_Amval .IdOne =Define_OneAmval.Id  )AS AllCharge", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtamval.Text = Cmd.ExecuteScalar() ' dtr("Amval")
            End Using

            Using Cmd As New SqlCommand("SELECT  ISNULL(SUM(MoneyChk),0) AS PayChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind)", ConectionBank)
                Cmd.CommandTimeout = 0
                TxtPay.Text = Cmd.ExecuteScalar() 'dtr("PayChk")
            End Using


            Using Cmd As New SqlCommand("SELECT ABS(ISNULL(SUM(Mandeh),0)) As BesMandeh  FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol WHERE Mandeh<0", ConectionBank)
                Cmd.CommandTimeout = 0
                TxtBes.Text = Cmd.ExecuteScalar() 'dtr("BesMandeh")
            End Using

            Using Cmd As New SqlCommand("SELECT ISNULL(SUM(BedMon-BesMon),0) As Sarmayeh   FROM (SELECT  D_date,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END   FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id  UNION ALL SELECT D_date=N'',BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id  )AS AllCharge", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtsarmaeh.Text = Cmd.ExecuteScalar() * (-1) 'dtr("Sarmayeh")
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Txtdara.Text = CDbl(TxtBox.Text) + CDbl(TxtBank.Text) + CDbl(Txtget.Text) + CDbl(Txtbed.Text) + CDbl(Txtkala.Text) + CDbl(Txtamval.Text) 'dtr("MoeinBox") + dtr("MoeinBank") + dtr("GetChk") + dtr("BedMandeh") + dtr("Kala") + dtr("Amval")
            Txtparda.Text = CDbl(TxtPay.Text) + CDbl(TxtBes.Text) + CDbl(Txtsarmaeh.Text) 'dtr("PayChk") + dtr("BesMandeh") + dtr("Sarmayeh")
            TxtSod.Text = CDbl(Txtdara.Text) - CDbl(Txtparda.Text)
            Txtparda.Text = CDbl(Txtparda.Text) + CDbl(TxtSod.Text)
            Txttraz.Text = CDbl(Txtdara.Text) - CDbl(Txtparda.Text)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "RefreshBank")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    ' Private Sub RefreshBank()
    '    Try
    '       Me.Enabled = False
    'Dim ds As New DataTable
    'Dim dta As New SqlDataAdapter
    '       dta = New SqlDataAdapter(SqlQuery, DataSource)
    '       dta.Fill(ds)
    '
    '           If ds.Rows.Count > 0 Then
    '              TxtBox.Text = ds.Rows(0).Item("MoeinBox")
    '             TxtBank.Text = ds.Rows(0).Item("MoeinBank")
    '            Txtget.Text = ds.Rows(0).Item("GetChk")
    '           Txtbed.Text = ds.Rows(0).Item("BedMandeh")
    '          Txtkala.Text = ds.Rows(0).Item("Kala")
    '         Txtamval.Text = ds.Rows(0).Item("Amval")
    '        TxtPay.Text = ds.Rows(0).Item("PayChk")
    '       TxtBes.Text = ds.Rows(0).Item("BesMandeh")
    '      Txtsarmaeh.Text = ds.Rows(0).Item("Sarmayeh")
    '     Txtdara.Text = ds.Rows(0).Item("MoeinBox") + ds.Rows(0).Item("MoeinBank") + ds.Rows(0).Item("GetChk") + ds.Rows(0).Item("BedMandeh") + ds.Rows(0).Item("Kala") + ds.Rows(0).Item("Amval")
    '              TxtSod.Text = CDbl(Txtdara.Text) - (ds.Rows(0).Item("PayChk") + ds.Rows(0).Item("BesMandeh") + ds.Rows(0).Item("Sarmayeh"))
    '             Txtparda.Text = ds.Rows(0).Item("PayChk") + ds.Rows(0).Item("BesMandeh") + ds.Rows(0).Item("Sarmayeh") + CDbl(TxtSod.Text)
    '            Txttraz.Text = CDbl(Txtdara.Text) - CDbl(Txtparda.Text)
    '       Else
    '          Me.Close()
    '     End If
    '    Me.Enabled = True
    '    Catch ex As Exception
    '       GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "RefreshBank")
    '      Me.Enabled = True
    ''     Me.Close()
    '     End Try
    ' End Sub

    Private Sub TxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBox.TextChanged
        If Not (CheckDigit(TxtBox.Text.Replace(",", ""))) Then
            TxtBox.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBox.Text.Length > 3 Then
            str = Format$(TxtBox.Text.Replace(",", ""))
            TxtBox.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtBank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBank.TextChanged
        If Not (CheckDigit(TxtBank.Text.Replace(",", ""))) Then
            TxtBank.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBank.Text.Length > 3 Then
            str = Format$(TxtBank.Text.Replace(",", ""))
            TxtBank.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtget_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtget.TextChanged
        If Not (CheckDigit(Txtget.Text.Replace(",", ""))) Then
            Txtget.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtget.Text.Length > 3 Then
            str = Format$(Txtget.Text.Replace(",", ""))
            Txtget.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtLastb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtbed.TextChanged
        If Not (CheckDigit(Txtbed.Text.Replace(",", ""))) Then
            Txtbed.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtbed.Text.Length > 3 Then
            str = Format$(Txtbed.Text.Replace(",", ""))
            Txtbed.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPay.TextChanged
        If Not (CheckDigit(TxtPay.Text.Replace(",", ""))) Then
            TxtPay.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtPay.Text.Length > 3 Then
            str = Format$(TxtPay.Text.Replace(",", ""))
            TxtPay.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtLastBes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBes.TextChanged
        If Not (CheckDigit(TxtBes.Text.Replace(",", ""))) Then
            TxtBes.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBes.Text.Length > 3 Then
            str = Format$(TxtBes.Text.Replace(",", ""))
            TxtBes.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtdara_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdara.TextChanged
        If Not (CheckDigit(Txtdara.Text.Replace(",", ""))) Then
            Txtdara.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtdara.Text.Length > 3 Then
            str = Format$(Txtdara.Text.Replace(",", ""))
            Txtdara.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtparda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtparda.TextChanged
        If Not (CheckDigit(Txtparda.Text.Replace(",", ""))) Then
            Txtparda.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtparda.Text.Length > 3 Then
            str = Format$(Txtparda.Text.Replace(",", ""))
            Txtparda.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txttraz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txttraz.TextChanged
        If Not (CheckDigit(Txttraz.Text.Replace(",", ""))) Then
            Txttraz.Text = 0
            If CDbl(Txttraz.Text.Trim) = 0 Then
                Txttraz.BackColor = Color.Yellow
            ElseIf CDbl(Txttraz.Text.Trim) > 0 Then
                Txttraz.BackColor = Color.White
            ElseIf CDbl(Txttraz.Text.Trim) < 0 Then
                Txttraz.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        Dim str As String
        If Txttraz.Text.Length > 3 Then
            str = Format$(Txttraz.Text.Replace(",", ""))
            Txttraz.Text = Format$(Val(str), "###,###,###")
        End If
        If CDbl(Txttraz.Text.Trim) = 0 Then
            Txttraz.BackColor = Color.Yellow
        ElseIf CDbl(Txttraz.Text.Trim) > 0 Then
            Txttraz.BackColor = Color.White
        ElseIf CDbl(Txttraz.Text.Trim) < 0 Then
            Txttraz.BackColor = Color.Pink
        End If
    End Sub

    Private Sub Txtkala_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtkala.TextChanged
        If Not (CheckDigit(Txtkala.Text.Replace(",", ""))) Then
            Txtkala.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtkala.Text.Length > 3 Then
            str = Format$(Txtkala.Text.Replace(",", ""))
            Txtkala.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtamval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtamval.TextChanged
        If Not (CheckDigit(Txtamval.Text.Replace(",", ""))) Then
            Txtamval.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtamval.Text.Length > 3 Then
            str = Format$(Txtamval.Text.Replace(",", ""))
            Txtamval.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtsarmaeh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsarmaeh.TextChanged
        If Not (CheckDigit(Txtsarmaeh.Text.Replace(",", ""))) Then
            Txtsarmaeh.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtsarmaeh.Text.Length > 3 Then
            str = Format$(Txtsarmaeh.Text.Replace(",", ""))
            Txtsarmaeh.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Me.Enabled = False
            Using FrmMoein As New FrmDaftarKol
                FrmMoein.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button5_Click")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Me.Enabled = False
            Using FrmMoein As New FrmDaftarKol
                FrmMoein.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button5_Click")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmMojodyBox
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button2_Click")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmMojodyBank
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button3_Click")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmReportGetChk
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button4_Click")
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmReportPayChk
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button8_Click")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmMojodyMoneyKala
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button6_Click")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmReport_Amval
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button7_Click")
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Me.Enabled = False
            Using FrmDay As New FrmReport_Sarmaeh
                FrmDay.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazTwo", "Button10_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_TarazTwo.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Enabled = False
        Button1.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز T", "چاپ تراز", "", "")

        Using FrmPrint As New FrmPrint
            FrmPrint.Num1 = CDbl(TxtBox.Text)
            FrmPrint.Num2 = CDbl(TxtBank.Text)
            FrmPrint.Num3 = CDbl(Txtget.Text)
            FrmPrint.Num4 = CDbl(Txtbed.Text)
            FrmPrint.Num5 = CDbl(Txtkala.Text)
            FrmPrint.Num6 = CDbl(Txtamval.Text)
            FrmPrint.Num7 = CDbl(TxtPay.Text)
            FrmPrint.Num8 = CDbl(TxtBes.Text)
            FrmPrint.Num9 = CDbl(Txtsarmaeh.Text)
            FrmPrint.Num10 = CDbl(Txtdara.Text)
            FrmPrint.Num11 = CDbl(Txtparda.Text)
            FrmPrint.Num12 = CDbl(Txttraz.Text)
            FrmPrint.Num13 = CDbl(TxtSod.Text)
            FrmPrint.CHoose = "TRAZTWO"
            FrmPrint.ShowDialog()
        End Using
        GroupBox1.Enabled = True
        Button1.Enabled = True
    End Sub

    Private Sub TrazTwo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز T", "ورود", "", "")
                End If
            End If
        Else
            Me.RefreshBank()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز T", "ورود", "", "")
        End If
    End Sub

    Private Sub TxtSod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSod.TextChanged
        If Not (CheckDigit(TxtSod.Text.Replace(",", ""))) Then
            TxtSod.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtSod.Text.Length > 3 Then
            str = Format$(TxtSod.Text.Replace(",", ""))
            TxtSod.Text = Format$(Val(str), "###,###,###")
        End If
        If CDbl(TxtSod.Text.Trim) = 0 Then
            TxtSod.BackColor = Color.Yellow
        ElseIf CDbl(TxtSod.Text.Trim) > 0 Then
            TxtSod.BackColor = Color.White
        ElseIf CDbl(TxtSod.Text.Trim) < 0 Then
            TxtSod.BackColor = Color.Pink
        End If
    End Sub
End Class