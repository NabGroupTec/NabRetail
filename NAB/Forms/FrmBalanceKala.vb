Imports System.Data.SqlClient
Public Class FrmBalanceKala

    Private Sub FrmMojodyKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        BtnReport.Focus()
        If DGV.RowCount <= 0 Then
            MessageBox.Show("کالایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
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

        If ChkDay.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                MessageBox.Show("محدوده درصد ریسک اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Dim ListKala As String = ""
        Dim CountKala As Long = 0
        ListKala = " WHERE ( "
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListKala &= "Define_Kala.ID=" & DGV.Item("Cln_Id", i).Value & " OR "
                CountKala += 1
            End If
        Next
        If CountKala = DGV.RowCount Then
            ListKala = ""
        ElseIf CountKala <= 0 Then
            MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListKala = ListKala.Substring(0, ListKala.Length - 4)
            ListKala &= ")"
        End If


        Dim Dat As String = ""
        Dim DatM As String = ""

        Dim DatDay As String = ""
        Dim DatWeek As String = ""
        Dim DatMonth As String = ""
        Dim DatM3month As String = ""

        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                Dat = " AND ( D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
                DatM = " AND (D_Date<=N'" & FarsiDate2.ThisText & "')"
                SetDayMonth(DatDay, DatWeek, DatMonth, DatM3month, FarsiDate2.ThisText)
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                Dat = " AND ( D_date >=N'" & FarsiDate1.ThisText & "')"
                DatM = ""
                SetDayMonth(DatDay, DatWeek, DatMonth, DatM3month, GetDate())
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                Dat = " AND ( D_date <=N'" & FarsiDate2.ThisText & "')"
                DatM = " AND (D_Date<=N'" & FarsiDate2.ThisText & "')"
                SetDayMonth(DatDay, DatWeek, DatMonth, DatM3month, FarsiDate2.ThisText)
            End If
        Else
            SetDayMonth(DatDay, DatWeek, DatMonth, DatM3month, GetDate())
        End If
        Dim condition As String = ""
        If ChkZM.Checked = True Then
            condition = " WHERE ROUND(EndData.MKolCount,2)>0 AND ROUND(EndData.MJozCount,2)>0 "
        End If

        If ChkZT.Checked = True Then
            If ChkZM.Checked = False Then
                condition = " WHERE ROUND(EndData.KolCount,2)>0 AND ROUND(EndData.JozCount,2)>0 "
            Else
                condition &= " AND ROUND(EndData.KolCount,2)>0 AND ROUND(EndData.JozCount,2)>0 "
            End If
        End If
        If ChkTime.Checked = True Then
            Tmp_OneGroup = If(ChkAzDate.Checked = True, "از تاریخ : " & FarsiDate1.ThisText & "        ", "")
            Tmp_OneGroup &= If(ChkTaDate.Checked = True, "تا تاریخ : " & FarsiDate2.ThisText, "")
        Else
            Tmp_OneGroup = ""
        End If
        FrmPrint.Num1 = IIf(ChkAzMon.Checked = False, -1, TxtMon1.Text)
        FrmPrint.Num2 = IIf(ChkTaMon.Checked = False, -1, TxtMon2.Text)

        Dim sort As String = ""
        If RdoT.Checked = True Then
            sort = " ORDER BY KolCount"
        ElseIf RdoDarsad.Checked = True Then
            sort = " ORDER BY DarsadNum"
        ElseIf RdoMojody.Checked = True Then
            sort = " ORDER BY MKolCount"
        ElseIf Rdokala.Checked = True Then
            sort = " ORDER BY Nam"
        End If
        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تردد کالا", "چاپ گزارش", "", "")

        If ChkOrder.Checked = False Then
            FrmPrint.PrintSQl = "SELECT EndData.Nam,EndData.Id As GroupKala,REPLACE(CAST (ROUND(EndData.KolCount,2) AS Nvarchar(max)),'.','/') As KolStr ,REPLACE(CAST (ROUND(EndData.JozCount,2) AS Nvarchar(max)),'.','/') As JozStr ,REPLACE(CAST (ROUND(EndData.MKolCount ,2) AS Nvarchar(max)),'.','/') As MKolStr ,REPLACE(CAST (ROUND(EndData.MJozCount ,2) AS Nvarchar(max)),'.','/') As MJozStr,Darsad=Case WHEN ROUND(EndData.MKolCount,2) <=0 THEN '-' ELSE REPLACE(ROUND(ROUND(EndData.KolCount,2)*100/ROUND(EndData.MKolCount,2),2),'.','/') END,DarsadNum=Case WHEN ROUND(EndData.MKolCount,2) <=0 THEN 0 ELSE ROUND(ROUND(EndData.KolCount,2)*100/ROUND(EndData.MKolCount,2),2) END,MonFac AS AllMon FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllJozCount)JozCount ,(SELECT ISNULL(SUM(AllMonFac .MonFac ),0)  FROM (SELECT  ISNULL(SUM((KalaFactorBackSell.Mon-KalaFactorBackSell.DarsadMon )  * (-1)) ,0) AS MonFac FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT   ISNULL(SUM((KalaFactorSell.Mon-KalaFactorSell.DarsadMon ) ) ,0) AS MonFac FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllMonFac)MonFac,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id " & DatM & " ) AS AllKolCount)MKolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id " & DatM & " )  AS AllJozCount)MJozCount FROM (SELECT Define_Kala.Id,Define_Kala.Nam FROM Define_Kala  " & ListKala & ") AS AllKala )As EndData " & condition & sort
            FrmPrint.CHoose = "BALANCEKALA"
        Else
            If ChkMOrder.Checked = False Then
                FrmPrint.PrintSQl = "SELECT  KO=ROUND(CASE WHEN (EndData.MKolCount<EndData.KolCount AND EndData.KolCount>0 )  THEN EndData.KolCount-EndData.MKolCount ELSE 0 END,2),JO=ROUND(CASE WHEN (EndData.MJozCount<EndData.JozCount AND EndData.JozCount>0 )  THEN EndData.JozCount-EndData.MJozCount ELSE 0 END,2),EndData.Nam,EndData.Id As GroupKala,REPLACE(CAST (ROUND(EndData.KolCount,2) AS Nvarchar(max)),'.','/') As KolStr ,REPLACE(CAST (ROUND(EndData.JozCount,2) AS Nvarchar(max)),'.','/') As JozStr ,REPLACE(CAST (ROUND(EndData.MKolCount ,2) AS Nvarchar(max)),'.','/') As MKolStr ,REPLACE(CAST (ROUND(EndData.MJozCount ,2) AS Nvarchar(max)),'.','/') As MJozStr,REPLACE(CAST (ROUND(CASE WHEN (EndData.MKolCount<EndData.KolCount AND EndData.KolCount>0 )  THEN EndData.KolCount-EndData.MKolCount ELSE 0 END,2) AS Nvarchar(max)),'.','/') As KolOrder,REPLACE(CAST (ROUND(CASE WHEN (EndData.MJozCount<EndData.JozCount AND EndData.JozCount>0 )  THEN EndData.JozCount-EndData.MJozCount ELSE 0 END,2) AS Nvarchar(max)),'.','/') As JozOrder,MonFac AS AllMon,REPLACE(CAST (ROUND(EndData.KolCountDay,2) AS Nvarchar(max)),'.','/') As KolOrderDay,REPLACE(CAST (ROUND(EndData.JozCountDay,2) AS Nvarchar(max)),'.','/') As JozOrderDay,REPLACE(CAST (ROUND(EndData.KolCountWeek,2) AS Nvarchar(max)),'.','/') As KolOrderWeek,REPLACE(CAST (ROUND(EndData.JozCountWeek,2) AS Nvarchar(max)),'.','/') As JozOrderWeek,REPLACE(CAST (ROUND(EndData.KolCountMonth,2) AS Nvarchar(max)),'.','/') As KolOrderMonth,REPLACE(CAST (ROUND(EndData.JozCountMonth,2) AS Nvarchar(max)),'.','/') As JozOrderMonth,REPLACE(CAST (ROUND(EndData.KolCount3Month,2) AS Nvarchar(max)),'.','/') As KolOrder3Month,REPLACE(CAST (ROUND(EndData.JozCount3Month,2) AS Nvarchar(max)),'.','/') As JozOrder3Month,Darsad=Case WHEN ROUND(EndData.MKolCount,2) <=0 THEN '-' ELSE REPLACE(ROUND(ROUND(EndData.KolCount,2)*100/ROUND(EndData.MKolCount,2),2),'.','/') END,DarsadNum=Case WHEN ROUND(EndData.MKolCount,2) <=0 THEN 0 ELSE ROUND(ROUND(EndData.KolCount,2)*100/ROUND(EndData.MKolCount,2),2) END FROM (SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllJozCount)JozCount ,(SELECT ISNULL(SUM(AllMonFac .MonFac ),0)  FROM (SELECT  ISNULL(SUM((KalaFactorBackSell.Mon-KalaFactorBackSell.DarsadMon )  * (-1)) ,0) AS MonFac FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT   ISNULL(SUM((KalaFactorSell.Mon-KalaFactorSell.DarsadMon ) ) ,0) AS MonFac FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllMonFac)MonFac,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id " & DatM & " ) AS AllKolCount)MKolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id " & DatM & " )  AS AllJozCount)MJozCount,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatDay & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatDay & " ) AS AllKolCount)KolCountDay,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatDay & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatDay & " ) AS AllJozCount)JozCountDay,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatWeek & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatWeek & " ) AS AllKolCount)KolCountWeek,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatWeek & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatWeek & " ) AS AllJozCount)JozCountWeek,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatMonth & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatMonth & " ) AS AllKolCount)KolCountMonth,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatMonth & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatMonth & " ) AS AllJozCount)JozCountMonth,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatM3month & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatM3month & " ) AS AllKolCount)KolCount3month,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatM3month & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatM3month & " ) AS AllJozCount)JozCount3month FROM (SELECT Define_Kala.Id,Define_Kala.Nam FROM Define_Kala  " & ListKala & ") AS AllKala )As EndData " & condition & sort
                FrmPrint.CHoose = "BALANCEKALAORDER"
            Else
                Using frm As New FrmBalanceKalaM
                    frm.Query = "SELECT  KO=ROUND(CASE WHEN (EndData.MKolCount<EndData.KolCount AND EndData.KolCount>0 )  THEN EndData.KolCount-EndData.MKolCount ELSE 0 END,2),JO=ROUND(CASE WHEN (EndData.MJozCount<EndData.JozCount AND EndData.JozCount>0 )  THEN EndData.JozCount-EndData.MJozCount ELSE 0 END,2),EndData.Nam,EndData.Id As GroupKala,REPLACE(CAST (ROUND(EndData.KolCount,2) AS Nvarchar(max)),'.','/') As KolStr,REPLACE(CAST (ROUND(EndData.JozCount,2) AS Nvarchar(max)),'.','/') As JozStr,REPLACE(CAST (ROUND(EndData.MKolCount ,2) AS Nvarchar(max)),'.','/') As MKolStr,REPLACE(CAST (ROUND(EndData.MJozCount ,2) AS Nvarchar(max)),'.','/') As MJozStr,REPLACE(CAST (ROUND(CASE WHEN (EndData.MKolCount<EndData.KolCount AND EndData.KolCount>0 )  THEN EndData.KolCount-EndData.MKolCount ELSE 0 END,2) AS Nvarchar(max)),'.','/') As KolOrder,REPLACE(CAST (ROUND(CASE WHEN (EndData.MJozCount<EndData.JozCount AND EndData.JozCount>0 )  THEN EndData.JozCount-EndData.MJozCount ELSE 0 END,2) AS Nvarchar(max)),'.','/') As JozOrder,REPLACE(CAST (ROUND(EndData.KolCountWeek,2) AS Nvarchar(max)),'.','/') As KolOrderWeek,REPLACE(CAST (ROUND(EndData.JozCountWeek,2) AS Nvarchar(max)),'.','/') As JozOrderWeek,REPLACE(CAST (ROUND(EndData.KolCountMonth,2) AS Nvarchar(max)),'.','/') As KolOrderMonth,REPLACE(CAST (ROUND(EndData.JozCountMonth,2) AS Nvarchar(max)),'.','/') As JozOrderMonth,Darsad=Case WHEN ROUND(EndData.MKolCount,2) <=0 THEN '-' ELSE REPLACE(ROUND(ROUND(EndData.KolCount,2)*100/ROUND(EndData.MKolCount,2),2),'.','/') END,DarsadNum=Case WHEN ROUND(EndData.MKolCount,2) <=0 THEN 0 ELSE ROUND(ROUND(EndData.KolCount,2)*100/ROUND(EndData.MKolCount,2),2) END ,we,ISNULL(Fe,0) AS Fe,DK,DK_KOL,DK_JOZ FROM (SELECT  AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & Dat & " ) AS AllJozCount)JozCount ,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id " & DatM & " ) AS AllKolCount)MKolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id " & DatM & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id " & DatM & " )  AS AllJozCount)MJozCount,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatWeek & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatWeek & " ) AS AllKolCount)KolCountWeek,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatWeek & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatWeek & " ) AS AllJozCount)JozCountWeek,(SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.KolCount * (-1)),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatMonth & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatMonth & " ) AS AllKolCount)KolCountMonth,(SELECT ISNULL(SUM(AllJozCount.JozCount),0) FROM (SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount * (-1)),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  " & DatMonth & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  " & DatMonth & " ) AS AllJozCount)JozCountMonth,(SELECT TOP 1 ISNULL(Fe,0) AS Fe FROM KalaFactorBuy INNER JOIN ListFactorBuy  ON ListFactorBuy.IdFactor =KalaFactorBuy.IdFactor  WHERE IdKala =AllKala.Id " & DatM & " ORDER BY ID Desc) AS Fe FROM (SELECT Define_Kala.Id,Define_Kala.Nam,we=CASE WHEN WK ='True' THEN (CASE WHEN WK_JOZ >0 THEN WK_JOZ ELSE WK_KOL END) ELSE 0.0 END,DK,DK_KOL,DK_JOZ FROM Define_Kala " & ListKala & ") AS AllKala )As EndData " & condition & sort
                    frm.Num1 = IIf(ChkAzMon.Checked = False, -1, TxtMon1.Text)
                    frm.Num2 = IIf(ChkTaMon.Checked = False, -1, TxtMon2.Text)
                    frm.ShowDialog()
                    Me.Enabled = True
                End Using
                Exit Sub
            End If
        End If
        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub
    Private Sub SetDayMonth(ByRef DatDay As String, ByRef DatWeek As String, ByRef DatMonth As String, ByRef DatM3month As String, ByVal DatCal As String)
        DatDay = DECDAY(DatCal)
        DatDay = " AND ( D_date >=N'" & DatDay & "' AND D_date <=N'" & DatDay & "')"

        DatWeek = DatCal
        For i As Integer = 1 To 8
            DatWeek = DECDAY(DatWeek)
        Next
        DatWeek = " AND ( D_date >=N'" & DatWeek & "' AND D_date <=N'" & DECDAY(DatCal) & "')"

        DatMonth = DECMonth(DatCal)
        DatMonth = DECDAY(DatMonth)
        DatMonth = " AND ( D_date >=N'" & DatMonth & "' AND D_date <=N'" & DECDAY(DatCal) & "')"

        DatM3month = DatCal
        For i As Integer = 1 To 3
            DatM3month = DECMonth(DatM3month)
        Next
        DatM3month = " AND ( D_date >=N'" & DECDAY(DatM3month) & "' AND D_date <=N'" & DECDAY(DatCal) & "')"
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Taradod.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
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

    Private Sub FrmBalanceKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F68")
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
        Me.GetKala()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub GetKala()
        Try
            Dim dv As New DataView
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()

            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Define_Kala.Activ,Define_Kala.Id,Define_Kala.Nam , Define_OneGroup.NamOne +'-'+ Define_TwoGroup.NamTwo As GroupKala FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  Order by NamOne ,NamTwo ,Nam"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBalanceKala", "GetKala")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Id", i).Value = IdKala Then
                        DGV.Item("Cln_Nam", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item("Cln_Nam", 0).Selected = True
                DGV.Item("Cln_Nam", 0).Selected = False
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Using FrmAdVance As New Kala_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV.Item("Cln_Id", i).Value Then DGV.Item("Cln_Select", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
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
        If CBool(DGV.Item("Cln_Active", e.RowIndex).Value) = True Then
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub ChkDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDay.CheckedChanged
        If ChkDay.Checked = True Then
            ChkAzMon.Enabled = True
            ChkTaMon.Enabled = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            ChkAzMon.Checked = True
        Else
            ChkAzMon.Checked = False
            ChkTaMon.Checked = False
            ChkAzMon.Enabled = False
            ChkTaMon.Enabled = False
            TxtMon1.Enabled = False
            TxtMon2.Enabled = False
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
        End If
    End Sub

    Private Sub ChkAzMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMon.CheckedChanged
        If ChkAzMon.Checked = True Then
            TxtMon1.Text = "0"
            TxtMon1.Enabled = True
            TxtMon1.Focus()
            TxtMon1.SelectAll()
        Else
            TxtMon1.Text = "0"
            TxtMon1.Enabled = False
        End If
    End Sub

    Private Sub ChkTaMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMon.CheckedChanged
        If ChkTaMon.Checked = True Then
            TxtMon2.Text = "0"
            TxtMon2.Enabled = True
            TxtMon2.Focus()
            TxtMon2.SelectAll()
        Else
            TxtMon2.Text = "0"
            TxtMon2.Enabled = False
        End If
    End Sub

    Private Sub TxtMon1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon2.Focus()
    End Sub

    Private Sub TxtMon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon1.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Then
            If InStr(TxtMon1.Text, ".") = False Then
                e.Handled = False
            End If
        End If
        If e.KeyChar = "-" Then
            If InStr(TxtMon1.Text, "-") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtMon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon1.TextChanged
        Try
            If Not (CheckDigit(TxtMon1.Text)) Then
                TxtMon1.Text = 0
                Exit Sub
            End If
            If Not TxtMon1.Text.Trim.Contains(".") Then TxtMon1.Text = CDbl(TxtMon1.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtMon2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon2.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtMon2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon2.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Then
            If InStr(TxtMon1.Text, ".") = False Then
                e.Handled = False
            End If
        End If
        If e.KeyChar = "-" Then
            If InStr(TxtMon1.Text, "-") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtMon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon2.TextChanged
        Try
            If Not (CheckDigit(TxtMon2.Text)) Then
                TxtMon2.Text = 0
                Exit Sub
            End If
            If Not TxtMon2.Text.Trim.Contains(".") Then TxtMon2.Text = CDbl(TxtMon2.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChkOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOrder.CheckedChanged
        If ChkOrder.Checked = True Then
            ChkMOrder.Enabled = True
        Else
            ChkMOrder.Checked = False
            ChkMOrder.Enabled = False
        End If
    End Sub

    Private Sub ChkMOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMOrder.CheckedChanged
        If ChkMOrder.Checked = True Then
            ToolStripStatusLabel5.Text = "F2 تهیه گزارش"
            BtnReport.Text = "تهیه گزارش"
        Else
            ToolStripStatusLabel5.Text = "F2 چاپ گزارش"
            BtnReport.Text = "چاپ گزارش"
        End If
    End Sub
End Class