Imports System.Data.SqlClient
Public Class FrmDaftarDay

   


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("محدوده تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        Me.Enabled = False

        If ChkSanad.Checked = False Then
            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    condition = " (D_Date >='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    condition = " (D_Date >='" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    condition = " (D_Date <='" & FarsiDate2.ThisText & "')"
                Else
                    MessageBox.Show("شرط تاریخ نامشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Dim C0 As String = If(Chk0.Checked = False, "", "SELECT  D_date,Nam,Disc,MonFac,Kind,Cash,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd,MonDec,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N'ف . خرید ' + CAST(ListFactorBuy.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor) AS MonFac,Kind=0,Cash,(MonPayChk+MonSellChk) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor) As Discount,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE  (ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0)" & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " ) AS List UNION ALL ")
            Dim C1 As String = If(Chk1.Checked = False, "", "SELECT  D_date,Nam,Disc,MonFac,Kind,Cash,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd,MonDec,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N' ف. خرید امانی ' + CAST(ListFactorBuy.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor) AS MonFac,Kind=1,Cash,(MonPayChk+MonSellChk) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =ListFactorBuy.IdFactor) As Discount,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE  (ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2)" & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & ") AS List UNION ALL ")
            Dim C2 As String = If(Chk2.Checked = False, "", "SELECT  D_date,Nam,Disc,MonFac,Kind,Cash,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd,MonDec,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N' ف. برگشت از خرید ' + CAST(ListFactorBackBuy.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBackBuy WHERE KalaFactorBackBuy.IdFactor =ListFactorBackBuy.IdFactor) AS MonFac,Kind=2,Cash,(MonPayChk) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorBackBuy WHERE KalaFactorBackBuy.IdFactor =ListFactorBackBuy.IdFactor) As Discount,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE  (ListFactorBackBuy.Activ =1) " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " ) AS List UNION ALL ")
            Dim C3 As String = If(Chk3.Checked = False, "", "SELECT  D_date,Nam ,Disc ,MonFac ,Kind ,Cash ,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd ,MonDec,MonHavaleh ,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N' ف. فروش ' + CAST(ListFactorSell.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE KalaFactorSell.IdFactor =ListFactorSell.IdFactor) AS MonFac ,Kind=3,Cash,(MonPayChk) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE KalaFactorSell.IdFactor =ListFactorSell.IdFactor) As Discount ,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE  (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 ) " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " ) AS List UNION ALL ")
            Dim C4 As String = If(Chk4.Checked = False, "", "SELECT  D_date,Nam ,Disc ,MonFac ,Kind ,Cash ,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd ,MonDec,MonHavaleh ,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N' ف. فروش امانی ' + CAST(ListFactorSell.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE KalaFactorSell.IdFactor =ListFactorSell.IdFactor) AS MonFac ,Kind=4,Cash,(MonPayChk) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE KalaFactorSell.IdFactor =ListFactorSell.IdFactor) As Discount ,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE  (ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 ) " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " ) AS List UNION ALL ")
            Dim C5 As String = If(Chk5.Checked = False, "", "SELECT  D_date,Nam,Disc,MonFac,Kind,Cash,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd,MonDec,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N' ف. برگشت از فروش ' + CAST(ListFactorBackSell.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBackSell WHERE KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor) AS MonFac,Kind=5,Cash,(MonPayChk+MonSellChk ) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorBackSell WHERE KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor) As Discount,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE  (ListFactorBackSell.Activ =1 ) " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " ) AS List UNION ALL ")
            Dim C6 As String = If(Chk6.Checked = False, "", "SELECT  D_date,Nam,Disc,MonFac,Kind,Cash,Chk,Lend=CASE WHEN ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) <0 THEN 0 ELSE ((MonFac+MonAdd -MonDec) -Discount- Cash -Chk - MonHavaleh) END,Discount,MonAdd ,MonDec ,MonHavaleh ,ISNULL(IdBankHavaleh,0) AS IdBank FROM (SELECT D_date,Nam,N' ف. خدمات ' + CAST(ListFactorService.IdFactor AS Nvarchar(max)) + N' اشخاص- ' + Nam AS Disc,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorService WHERE KalaFactorService.IdFactor =ListFactorService.IdFactor) AS MonFac,Kind=6,Cash,(MonPayChk) As Chk,Discount + (SELECT ISNULL(SUM(DarsadMon),0) FROM KalaFactorService WHERE KalaFactorService.IdFactor =ListFactorService.IdFactor) As Discount,MonDec,MonAdd,MonHavaleh,IdBankHavaleh FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE  (ListFactorService.Activ =1 ) " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " ) AS List UNION ALL ")
            Dim C7 As String = If(Chk7.Checked = False, "", "SELECT  D_date,Nam,N'دریافت از طرف حساب ' +  Cast(Get_Pay_Sanad.ID As nvarchar(max))  + N' اشخاص- ' + Nam As Disc ,(Cash +Discount +MonHavaleh +MonSellChk +MonPayChk ) As MonFac,Kind=7,Cash,(MonSellChk + MonPayChk) As Chk,Lend=0,Discount,MonAdd=0,MonDec=0,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.IdName = Define_People.ID WHERE Get_Pay_Sanad.Active =1 AND Get_Pay_Sanad.[State]=0 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C8 As String = If(Chk8.Checked = False, "", "SELECT  D_date,Nam,N'پرداخت به طرف حساب ' +  Cast(Get_Pay_Sanad.ID As nvarchar(max))  + N' اشخاص- ' + Nam As Disc ,(Cash +Discount +MonHavaleh +MonSellChk +MonPayChk ) As MonFac,Kind=8,Cash,(MonSellChk + MonPayChk) As Chk,Lend=0,Discount,MonAdd=0,MonDec=0,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.IdName = Define_People.ID WHERE Get_Pay_Sanad.Active =1 AND Get_Pay_Sanad.[State]=1 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C9 As String = If(Chk9.Checked = False, "", "SELECT  D_date,Nam,N'طرف حساب به طرف حساب  ' + CAST(Allsanad.Id AS nvarchar(max)) + N' اشخاص- ' + Allsanad.BedNam  As Disc ,Mon As MonFac,Kind=9,Mon As Cash,Chk=0,Lend=0,Discount=0,MonAdd=0,MonDec=0,MonHavaleh=0,IdBank=0 FROM (SELECT Sanad_PTP.Id,Sanad_PTP.IdNameBes , Sanad_PTP.D_date, Sanad_PTP.Mon, Define_People.Nam As BedNam FROM Sanad_PTP INNER JOIN Define_People ON Sanad_PTP.IdNameBed = Define_People.ID " & If(String.IsNullOrEmpty(condition), "", " WHERE " & condition) & ")AS AllSanad INNER JOIN Define_People ON AllSanad .IdNameBes  = Define_People.ID UNION ALL ")
            Dim C10 As String = If(Chk10.Checked = False, "", "SELECT D_date,N'هزینه ف . خرید ' AS Nam,N'هزینه ف . خرید ' + CAST(IdFactor As nvarchar(max)) as Disc,(Cash +Discount+MonHavaleh+MonPayChk + MonSellChk+Lend ) AS MonFac,Kind=10,Cash,(MonPayChk + MonSellChk) AS Chk,Lend,Discount,MonAdd=0,MonDec=0,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM  ListFactorCharge  WHERE Activ =1 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C11 As String = If(Chk11.Checked = False, "", "SELECT D_date,N'هزینه متفرقه ' AS Nam,N'هزینه متفرقه ' + CAST(Id As nvarchar(max)) as Disc,(Cash +Discount+MonHavaleh+MonPayChk + MonSellChk+Lend ) AS MonFac,Kind=11,Cash,(MonPayChk + MonSellChk) AS Chk,Lend,Discount,MonAdd=0,MonDec=0,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM  ListOtherCharge WHERE Activ =1 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C12 As String = If(Chk12.Checked = False, "", "SELECT D_date,NamOne + '-' + nam  As Nam,N'درآمد- ' + NamOne + '-' + nam  + '  ' + CAST(Get_Daramad.Id As Nvarchar(max)) AS Disc ,(Cash+MonHavaleh +MonPayChk +Lend )MonFac,Kind=12,Cash,MonPayChk AS Chk,Lend,Discount=0,MonAdd=0,MonDec=0,MonHavaleh,ISNULL(IdBankHavaleh,0) AS IdBank FROM Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id WHERE Active=1 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C1314 As String = If(Chk1314.Checked = False, "", "SELECT D_date,Define_OneAmval.NamOne +'-'+ Define_Amval.nam AS Nam ,Disc=CASE Get_Pay_Amval.[State] WHEN 0 THEN N'افزایش اموال' ELSE N'کاهش اموال' END  + '  ' +  Define_OneAmval.NamOne +'-'+ Define_Amval.nam  + '   '  +  CAST(Get_Pay_Amval.Id As nvarchar(max)),(Cash+MonHavaleh+MonPayChk+ MonSellChk+Lend) As MonFac ,Kind=CASE Get_Pay_Amval.[State] WHEN 0 THEN 13 ELSE 14 END ,Cash,(MonPayChk+ MonSellChk) As Chk,Lend,Discount=0,MonAdd=0,MonDec=0,MonHavaleh,ISNULL(IdBankHavaleh,0) as IdBank FROM  Get_Pay_Amval INNER JOIN Define_Amval ON Get_Pay_Amval.IdAmval = Define_Amval.ID INNER JOIN Define_OneAmval ON Define_Amval.IdOne = Define_OneAmval.Id WHERE Get_Pay_Amval.Active =1 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C1516 As String = If(Chk1516.Checked = False, "", "SELECT D_date,Define_OneSarmayeh.NamOne+'-'+Define_Sarmayeh.nam AS Nam ,Disc=CASE Get_Pay_Sarmayeh.[State] WHEN 0 THEN N'برداشت سرمایه' ELSE N'افزایش سرمایه' END  + '  ' +  Define_OneSarmayeh.NamOne+'-'+Define_Sarmayeh.nam  + '   '  +  CAST(Get_Pay_Sarmayeh.Id As nvarchar(max)),(Cash+MonHavaleh+MonPayChk+ MonSellChk+Lend) As MonFac,Kind=CASE Get_Pay_Sarmayeh.[State] WHEN 0 THEN 16 ELSE 15 END,Cash,(MonPayChk+ MonSellChk) As Chk,Lend,Discount=0,MonAdd=0,MonDec=0,MonHavaleh ,ISNULL(IdBankHavaleh,0) as IdBank FROM Get_Pay_Sarmayeh INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh.IdSarmayeh = Define_Sarmayeh.ID INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh.IdOne = Define_OneSarmayeh.Id WHERE Get_Pay_Sarmayeh.Active =1 " & If(String.IsNullOrEmpty(condition), "", " AND " & condition) & " UNION ALL ")
            Dim C1718 As String = If(Chk1718.Checked = False, "", "SELECT D_Date,Nam= CASE Stat WHEN 0 THEN Define_Bank.n_bank WHEN 1 THEN Define_Box.nam  End ,Disc= CASE Stat WHEN 0 THEN N'صندوق به بانک'  WHEN 1 THEN N'بانک به صندوق'  End + '  '  + CAST(Sanad_Translate_BoxBank.Id AS nvarchar(max)) + ' - ' + CASE Stat WHEN 0 THEN Define_Box.nam WHEN 1 THEN Define_Bank.n_bank  End ,Mon As MonFac,Kind=CASE Stat WHEN 0 THEN 17 WHEN 1 THEN 18  End ,Mon As Cash,Chk=0,Lend=0,Discount=0,MonAdd=0,MonDec=0,MonHavaleh=0,IdBank=0 FROM Sanad_Translate_BoxBank INNER JOIN Define_Bank ON Sanad_Translate_BoxBank.IdBank = Define_Bank.ID INNER JOIN Define_Box ON Sanad_Translate_BoxBank.IdBox = Define_Box.ID " & If(String.IsNullOrEmpty(condition), "", " WHERE " & condition) & " UNION ALL ")
            Dim C23 As String = If(Chk23.Checked = False, "", "SELECT D_date,N'بابنک به بانک' As Nam,N'بانک به بانک- ' + Define_Bank.n_bank As Disc,Mon As MonFac,Kind=23,Cash=0,Chk=0,Lend=0,Discount=0,MonAdd=0,MonDec=0,MonHavaleh=0,Sanad_BankTBank_Bes.Id As IdBank FROM Sanad_BankTBank_Bes INNER JOIN Define_Bank ON Sanad_BankTBank_Bes.IdBankBes = Define_Bank.ID " & If(String.IsNullOrEmpty(condition), "", " WHERE " & condition) & " UNION ALL ")
            Dim C24 As String = If(Chk24.Checked = False, "", "SELECT D_date,Nam ,N'صندوق به صندوق '+ CAST(AllSanad.id As nvarchar(max)) + ' - ' + Allsanad.BedNam  As Disc,Mon  As MonFac,Kind=24,Cash=0,Chk=0,Lend=0,Discount=0,MonAdd=0,MonDec=0,MonHavaleh=0,IdBank=0 FROM (SELECT   Sanad_BOXTBOX.Id,Sanad_BOXTBOX.IdNameBes  , Sanad_BOXTBOX.Disc, Sanad_BOXTBOX.D_date, Sanad_BOXTBOX.Mon, Define_Box.Nam As BedNam FROM Sanad_BOXTBOX INNER JOIN Define_Box ON Sanad_BOXTBOX.IdNameBed = Define_Box.ID)AS AllSanad INNER JOIN Define_Box ON AllSanad .IdNameBes  = Define_Box.ID " & If(String.IsNullOrEmpty(condition), "", " WHERE " & condition) & " UNION ALL ")

            Dim sql As String = C0 & C1 & C2 & C3 & C4 & C5 & C6 & C7 & C8 & C9 & C10 & C11 & C12 & C1314 & C1516 & C1718 & C23 & C24

            If String.IsNullOrEmpty(sql) Then
                MessageBox.Show("نوع سند را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            sql = sql.Substring(0, sql.Length - 10)
            sql = "SELECT * FROM ( " & sql & " ) As EndList ORDER BY D_Date,Kind"
            Dim TmpDt As New DataTable
            TmpDt.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand(sql, ConectionBank)
                TmpDt.Load(cmd.ExecuteReader)
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If TmpDt.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If

            Dim Dt As New DataTable
            Dt.Clear()
            Dt.Columns.Clear()
            Dt.Columns.Add("D_Date", System.Type.GetType("System.String"))
            Dt.Columns.Add("Disc", System.Type.GetType("System.String"))
            Dt.Columns.Add("Bed", System.Type.GetType("System.Double"))
            Dt.Columns.Add("Bes", System.Type.GetType("System.Double"))

            For i As Long = 0 To TmpDt.Rows.Count - 1
                Me.SetDt(Dt, TmpDt, i)
            Next

            ''''''''''''''''''''''''''''''
            FrmPrint.DtDaftarDay = Dt
            If ChkTime.Checked = False Then
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
            Else
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                Tmp_OneGroup = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                Tmp_TwoGroup = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دفتر روزانه", "تهیه گزارش", "", "")

            FrmPrint.CHoose = "DAFTARDAY"
            FrmPrint.ShowDialog()
        Else
            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    condition = " AND (D_Date >='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    condition = " AND (D_Date >='" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    condition = " AND (D_Date <='" & FarsiDate2.ThisText & "')"
                Else
                    MessageBox.Show("شرط تاریخ نامشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim str As String = ""
            str = "SELECT P=0,row=0,ID,Disc ,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT Id,N'نقدوبانک/'+ nam AS Disc,Mon=(MoeinBox)  FROM (SELECT ID,nam,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=0 " & condition & ") AS Bed) AS MoeinBox FROM Define_Box) As AllMoeinBox) AS ListBox  WHERE MON>0 UNION ALL SELECT P=0,row=1,IDBox AS Id,'                      ' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_Box WHERE T=0 " & condition & " UNION ALL SELECT P=1,row=0,ID,Disc ,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT Id,N'نقدوبانک/'+ nam AS Disc,Mon=(MoeinBox)  FROM (SELECT ID,nam,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=1 " & condition & ") AS Bed) AS MoeinBox FROM Define_Box) As AllMoeinBox) AS ListBox  WHERE MON>0 UNION ALL SELECT P=1,row=1,IDBox AS Id,'                      ' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_Box WHERE T=1 " & condition & " UNION ALL SELECT P=0,row=0,ID,Disc ,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT Id,N'نقدوبانک/بانک/'+ nam AS Disc,Mon=(MoeinBox)  FROM (SELECT ID,n_bank As nam,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBank =Define_Bank.ID  AND T=0 " & condition & ") AS Bed) AS MoeinBox FROM Define_Bank) As AllMoeinBank) AS ListBank  WHERE MON>0 UNION ALL SELECT P=0,row=1,IDBank  AS Id,'                      ' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_Bank WHERE T=0 " & condition & " UNION ALL SELECT P=1,row=0,ID,Disc ,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT Id,N'نقدوبانک/بانک/'+ nam AS Disc,Mon=(MoeinBox)  FROM (SELECT ID,n_bank As nam,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBank =Define_Bank.ID  AND T=1 " & condition & ") AS Bed) AS MoeinBox FROM Define_Bank) As AllMoeinBank) AS ListBank  WHERE MON>0 UNION ALL SELECT P=1,row=1,IDBank  AS Id,'                      ' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_Bank WHERE T=1 " & condition & " UNION ALL SELECT P=0,row=0,ID=5000,N'حسابهای دریافتنی/اشخاص سایر' As Disc,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='True' AND Seller ='False' AND Buyer ='False') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=0,row=1,5000 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='True' AND Seller ='False' AND Buyer ='False') " & condition & " UNION ALL SELECT P=0,row=0,ID=5001,N'حسابهای دریافتنی/اشخاص خریدار' As Disc,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='False' AND Seller ='False' AND Buyer ='True') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=0,row=1,5001 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='False' AND Seller ='False' AND Buyer ='True') " & condition & " UNION ALL SELECT P=0,row=0,ID=5002,N'حسابهای دریافتنی/اشخاص فروشنده' As Disc,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='False') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=0,row=1,5002 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='False') " & condition & " UNION ALL SELECT P=0,row=0,ID=5003,N'حسابهای دریافتنی/اشخاص خریدار-فروشنده' As Disc,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='True') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=0,row=1,5003 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=0 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='True') " & condition & " UNION ALL SELECT P=1,row=0,ID=5000,N'حسابهای دریافتنی/اشخاص سایر' As Disc,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='True' AND Seller ='False' AND Buyer ='False') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=1,row=1,5000 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='True' AND Seller ='False' AND Buyer ='False') " & condition & " UNION ALL SELECT P=1,row=0,ID=5001,N'حسابهای دریافتنی/اشخاص خریدار' As Disc,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='False' AND Seller ='False' AND Buyer ='True') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=1,row=1,5001 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='False' AND Seller ='False' AND Buyer ='True') " & condition & " UNION ALL SELECT P=1,row=0,ID=5002,N'حسابهای دریافتنی/اشخاص فروشنده' As Disc,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='False') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=1,row=1,5002 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='False') " & condition & " UNION ALL SELECT P=1,row=0,ID=5003,N'حسابهای دریافتنی/اشخاص خریدار-فروشنده' As Disc,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT ISNULL(SUM(MoeinPeople),0) AS Mon FROM (SELECT ID,(SELECT (SUM(bed))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople  =Define_People.ID  AND T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) " & condition & ") AS Bed) AS MoeinPeople FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='True') AS ListP) As ListMoeinP WHERE MON>0 UNION ALL SELECT P=1,row=1,5003 AS Id,'                      ' + nam + '-' + disc,mon AS Fe,BedMon=0,BesMon=0 FROM Moein_People INNER JOIN Define_People ON Define_People.ID =Moein_People.IDPeople  WHERE T=1 AND ([Type_Sanad] >=5  AND NOT([Type_Sanad] =7 )) AND IDPeople IN (SELECT Id FROM Define_People WHERE Other ='False' AND Seller ='True' AND Buyer ='True') " & condition & " UNION ALL SELECT P=0,row=0,5004 AS ID,N'اسناد دریافتی/چکهای نزد صندوق' AS Disc ,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT ISNULL(SUM(MoneyChk),0) AS Mon FROM (SELECT Chk_Id .IdPeople, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1) ) As ListGetChk  WHERE (  Current_State=0 ) " & Replace(condition, "D_Date", "GetDate") & ") AS ListChk WHERE Mon>0 UNION ALL SELECT P=0,row=1,5004 AS ID,'                      ' + Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT Chk_Id .IdPeople, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 ) AND (Chk_Get_Pay.Activ =1) ) As ListGetChk  WHERE (  Current_State=0 ) " & Replace(condition, "D_Date", "GetDate") & " UNION ALL SELECT P=0,row=0,5005 AS ID,N'اسناد دریافتی/اسناد نزد بانک' AS Disc ,Fe=0,BedMon=MON ,BesMon=0 FROM(SELECT ISNULL(SUM(MoneyChk),0) AS Mon FROM (SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION ALL SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate ,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4)) As ListBratChk INNER JOIN Define_Bank ON Define_Bank.ID =ListBratChk.IdBank  " & Replace(condition, "D_Date", "BratDate") & ") AS ListBrat WHERE MON>0 UNION ALL SELECT P=0,row=1,5005 AS ID,'                      ' + ListBratChk.Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) + N' نزد بانک:' + Define_Bank .n_bank + ' ' + ListBratChk.Number_N AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION ALL SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate ,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4)) As ListBratChk INNER JOIN Define_Bank ON Define_Bank.ID =ListBratChk.IdBank  " & Replace(condition, "D_Date", "BratDate") & " UNION ALL SELECT P=1,row=0,5006 AS ID,N'اسناد دریافتی/چکهای نزد صندوق' AS Disc ,Fe=0,BedMon=0 ,BesMon=MON FROM (SELECT ISNULL(SUM(MOn),0) As Mon FROM( SELECT MoneyChk  As Mon FROM (SELECT Chk_Id .IdPeople, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)) As ListGetChk  WHERE (  Current_State=0 ) " & Replace(condition, "D_Date", "GetDate") & " UNION ALL SELECT MoneyChk  As Mon FROM (SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION ALL SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate ,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4)) As ListBratChk INNER JOIN Define_Bank ON Define_Bank.ID =ListBratChk.IdBank  " & Replace(condition, "D_Date", "BratDate") & " UNION ALL SELECT MoneyChk  As Mon FROM (SELECT MoneyChk ,Nam ,PayDate ,NumChk FROM (SELECT MoneyChk ,Nam ,PayDate ,NumChk ,V_date=(SELECT TOP 1 D_Date FROM Chk_State WHERE Id=ListGetChk.ID AND Current_State=1 ORDER BY D_Date DESC) FROM (SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) " & _
                  "UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)) As ListGetChk  WHERE (  Current_State=1 ) ) AS VosoChk WHERE MoneyChk >0 " & Replace(condition, "D_Date", "V_Date") & ") As ListVChk) AS SumListChk) As EndList WHERE MON>0 UNION ALL SELECT P=1,row=1,5006 AS ID,'                      ' + Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT Chk_Id .IdPeople, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)) As ListGetChk  WHERE (  Current_State=0 ) " & Replace(condition, "D_Date", "GetDate") & " UNION ALL SELECT P=1,row=1,5006 AS ID,'                      ' + ListBratChk.Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) + N' نزد بانک:' + Define_Bank .n_bank + ' ' + ListBratChk.Number_N AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION ALL SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate ,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4)) As ListBratChk INNER JOIN Define_Bank ON Define_Bank.ID =ListBratChk.IdBank  " & Replace(condition, "D_Date", "BratDate") & " UNION ALL SELECT P=1,row=1,5006 AS ID,'                      ' + Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT MoneyChk ,Nam ,PayDate ,NumChk FROM (SELECT MoneyChk ,Nam ,PayDate ,NumChk ,V_date=(SELECT TOP 1 D_Date FROM Chk_State WHERE Id=ListGetChk.ID AND Current_State=1 ORDER BY D_Date DESC) FROM (SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION All SELECT Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0  AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)) As ListGetChk  WHERE (  Current_State=1 ) ) AS VosoChk WHERE MoneyChk >0 " & Replace(condition, "D_Date", "V_Date") & ") As ListVChk UNION ALL SELECT P=0,row=0,5007 AS ID,N'اسناد پرداختی' AS Disc ,Fe=0,BedMon=0 ,BesMon=MON FROM(SELECT ISNULL(SUM(MoneyChk),0) AS MON FROM (SELECT MoneyChk FROM (SELECT Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk  WHERE (  Current_State=0 ) AND (IdBank IS NOT NULL) " & Replace(condition, "D_Date", "GetDate") & ") AS EndMonPayChk) AS EndMonPayChk2 WHERE MON>0 UNION ALL SELECT P=0,row=1,5007 AS ID,'                      ' + Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk  WHERE (  Current_State=0 ) AND (IdBank IS NOT NULL)  " & Replace(condition, "D_Date", "GetDate") & " UNION ALL SELECT P=1,row=0,5007 AS ID,N'اسناد پرداختی' AS Disc ,Fe=0,BedMon=Mon ,BesMon=0 FROM(SELECT ISNULL(SUM(MoneyChk),0) AS MON FROM (SELECT MoneyChk FROM (SELECT Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk  WHERE (  Current_State=0 ) AND (IdBank IS NOT NULL)  " & Replace(condition, "D_Date", "GetDate") & " UNION ALL SELECT MoneyChk FROM (SELECT PayDate ,MoneyChk ,NumChk ,Nam,V_date=(SELECT TOP 1 D_Date FROM Chk_State WHERE Id=ListGetChk.ID AND Current_State=1 ORDER BY D_Date DESC)  FROM (SELECT Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk WHERE (  Current_State=1 ) AND (IdBank IS NOT NULL)) AS ENdLPChk WHERE MoneyChk >0 " & Replace(condition, "D_Date", "V_Date") & ") AS EndMonPayChk) AS EndMonPayChk2 WHERE MON>0 UNION ALL SELECT P=1,row=1,5007 AS ID,'                      ' + Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0  THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval ON Chk_Id.IdAmval = Define_Amval.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk  WHERE (  Current_State=0 ) AND (IdBank IS NOT NULL)  " & Replace(condition, "D_Date", "GetDate") & " UNION ALL SELECT P=1,row=1,5007 AS ID,'                      ' + Nam + N' تاریخ:' + PayDate + N' سریال:' + CAST(NumChk AS Nvarchar(MAX)) AS Disc ,Fe=MoneyChk,BedMon=0 ,BesMon=0 FROM (SELECT PayDate ,MoneyChk ,NumChk ,Nam,V_date=(SELECT TOP 1 D_Date FROM Chk_State WHERE Id=ListGetChk.ID AND Current_State=1 ORDER BY D_Date DESC)  FROM (SELECT Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk WHERE (  Current_State=1 ) AND (IdBank IS NOT NULL)) AS ENdLPChk WHERE MoneyChk >0 " & Replace(condition, "D_Date", "V_Date") & " UNION ALL SELECT P=0,row=0,5008 AS ID,N'هزینه' AS Disc ,Fe=0,BedMon=MON ,BesMon=0 FROM (SELECT ISNULL(SUM(Bedmon-BesMon),0) AS MON FROM (SELECT D_date,N'هزینه ف.خرید'+' '+ CAST(IdFactor AS nvarchar(Max))+ ' - '+ NamOne +'_'+nam + ISNULL(CASE WHEN (CDisc IS NULL OR CDisc =N'') THEN +' - '+Disc ELSE +' - '+ CDisc END,'') AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE Mon>0 " & condition & " UNION All SELECT D_date,N'هزینه متفرقه'+ ' - '+ NamOne +'_'+nam + ISNULL(CASE WHEN (CDisc IS NULL OR CDisc =N'') THEN +' - '+Disc ELSE +' - '+ CDisc END,'') AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE Mon>0 " & condition & " UNION ALL SELECT D_date , (CASE WHEN Get_Pay_Amval.[State]=0 THEN N'افزایش اموال ' ELSE N'کاهش اموال ' END ) + NamOne +'_'+nam  AS NamCharge, BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END ) FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 " & condition & " UNION ALL SELECT D_date , (CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN N'برداشت سرمایه ' ELSE N'افزایش سرمایه ' END ) + NamOne +'_'+nam  AS NamCharge, BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END ) FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 " & condition & ") AS ListCharge) AS ENDListCharge WHERE MON>0 UNION ALL SELECT P=0,row=1,5008 AS ID,NamCharge AS Disc ,Fe=BedMon-BesMon,BedMon=0,BesMon=0 FROM ( SELECT D_date,N'هزینه ف.خرید'+' '+ CAST(IdFactor AS nvarchar(Max))+ ' - '+ NamOne +'_'+nam + ISNULL(CASE WHEN (CDisc IS NULL OR CDisc =N'') THEN +' - '+Disc ELSE +' - '+ CDisc END,'') AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE Mon>0 " & condition & " UNION All SELECT D_date,N'هزینه متفرقه'+ ' - '+ NamOne +'_'+nam + ISNULL(CASE WHEN (CDisc IS NULL OR CDisc =N'') THEN +' - '+Disc ELSE +' - '+ CDisc END,'') AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE Mon>0 " & condition & " UNION ALL SELECT D_date , (CASE WHEN Get_Pay_Amval.[State]=0 THEN N'افزایش اموال ' ELSE N'کاهش اموال ' END ) + NamOne +'_'+nam  AS NamCharge, BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END ) FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 " & condition & " UNION ALL SELECT D_date , (CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN N'برداشت سرمایه ' ELSE N'افزایش سرمایه ' END ) + NamOne +'_'+nam  AS NamCharge, BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END ) FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 " & condition & ") AS ListCharge WHERE BedMon-BesMon>0 UNION ALL SELECT P=1,row=0,5009 AS ID,N'درآمد' AS Disc ,Fe=0 ,BedMon=0,BesMon=Mon FROM (SELECT ISNULL(SUM(BesMon),0) AS Mon FROM(SELECT  D_date,NamOne + '-' + Nam + ISNULL('  ' + AllDisc,'') As Namcharge,BedMon=0 ,(Cash+ MonHavaleh+ MonPayChk+ Lend) AS BesMon,T=N'بس' ,Mandeh=0 FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id  WHERE (Cash+ MonHavaleh+ MonPayChk+ Lend)>0 " & condition & ") AS ListDaramad) AS ListD WHERE Mon>0 UNION ALL SELECT P=1,row=1,5009 AS ID,NamCharge AS Disc ,Fe=BesMon-BedMon,BedMon=0,BesMon=0 FROM (SELECT  D_date,NamOne + '-' + Nam + ISNULL('  ' + AllDisc,'') As Namcharge,BedMon=0 ,(Cash+ MonHavaleh+ MonPayChk+ Lend) AS BesMon,T=N'بس' ,Mandeh=0 FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id  WHERE (Cash+ MonHavaleh+ MonPayChk+ Lend)>0 " & condition & ") AS ListDaramad WHERE BesMon-BedMon>0 ORDER BY P,ID ,row"
            Using cmd As New SqlCommand(str, ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If

            FrmPrint.DtDaftarDay = dt
            If ChkTime.Checked = False Then
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
            Else
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                Tmp_OneGroup = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                Tmp_TwoGroup = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دفتر روزانه", "تهیه گزارش", "", "")

            FrmPrint.CHoose = "DAFTARDAYSANAD"
            FrmPrint.ShowDialog()
        End If

        Me.Enabled = True
    End Sub
    
    Private Sub SetDt(ByRef Dt As DataTable, ByRef TmpDt As DataTable, ByVal i As Long)
        If TmpDt.Rows(i).Item("Kind") >= 0 And TmpDt.Rows(i).Item("Kind") <= 6 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("MonFac"), 0)
            row1("Bes") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("MonFac"), 0)
            Dt.Rows.Add(row1)

            If TmpDt.Rows(i).Item("MonAdd") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          اضافات"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("MonAdd"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("MonAdd"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("MonDec") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          کسورات"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("MonDec"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("MonDec"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Discount") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          تخفیفات"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("Discount"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("Discount"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Cash") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          صندوق"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("Cash"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("Cash"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("MonHavaleh") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          حواله بانکی - " & GetNamBank(TmpDt.Rows(i).Item("IdBank"))
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("MonHavaleh"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("MonHavaleh"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Chk") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, "          اسناد دریافتی", "          اسناد پرداختی")
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("Chk"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("Chk"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Lend") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          نسیه"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, TmpDt.Rows(i).Item("Lend"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, TmpDt.Rows(i).Item("Lend"), 0)
                Dt.Rows.Add(row)
            End If

            If (TmpDt.Rows(i).Item("MonFac") + TmpDt.Rows(i).Item("MonAdd") - TmpDt.Rows(i).Item("MonDec") - TmpDt.Rows(i).Item("Discount") - TmpDt.Rows(i).Item("Cash") - TmpDt.Rows(i).Item("Chk") - TmpDt.Rows(i).Item("MonHavaleh") - TmpDt.Rows(i).Item("Lend")) <> 0 Then
                Dim row As DataRow = Dt.NewRow
                Dim res As Double = Math.Abs(TmpDt.Rows(i).Item("MonFac") + TmpDt.Rows(i).Item("MonAdd") - TmpDt.Rows(i).Item("MonDec") - TmpDt.Rows(i).Item("Discount") - TmpDt.Rows(i).Item("Cash") - TmpDt.Rows(i).Item("Chk") - TmpDt.Rows(i).Item("MonHavaleh") - TmpDt.Rows(i).Item("Lend"))
                row("D_date") = ""
                row("Disc") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, "          حساب بستانکاری", "          حساب بدهکاری")
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 0 Or TmpDt.Rows(i).Item("Kind") = 1 Or TmpDt.Rows(i).Item("Kind") = 5, res, 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 3 Or TmpDt.Rows(i).Item("Kind") = 4 Or TmpDt.Rows(i).Item("Kind") = 2 Or TmpDt.Rows(i).Item("Kind") = 6, res, 0)
                Dt.Rows.Add(row)
            End If

        ElseIf TmpDt.Rows(i).Item("Kind") >= 7 And TmpDt.Rows(i).Item("Kind") <= 8 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = If(TmpDt.Rows(i).Item("Kind") = 8, TmpDt.Rows(i).Item("MonFac"), 0)
            row1("Bes") = If(TmpDt.Rows(i).Item("Kind") = 7, TmpDt.Rows(i).Item("MonFac"), 0)
            Dt.Rows.Add(row1)

            If TmpDt.Rows(i).Item("Discount") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          تخفیفات"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 7, TmpDt.Rows(i).Item("Discount"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 8, TmpDt.Rows(i).Item("Discount"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Cash") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          صندوق"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 7, TmpDt.Rows(i).Item("Cash"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 8, TmpDt.Rows(i).Item("Cash"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("MonHavaleh") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          حواله بانکی - " & GetNamBank(TmpDt.Rows(i).Item("IdBank"))
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 7, TmpDt.Rows(i).Item("MonHavaleh"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 8, TmpDt.Rows(i).Item("MonHavaleh"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Chk") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = If(TmpDt.Rows(i).Item("Kind") = 7, "          اسناد دریافتی", "          اسناد پرداختی")
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 7, TmpDt.Rows(i).Item("Chk"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 8, TmpDt.Rows(i).Item("Chk"), 0)
                Dt.Rows.Add(row)
            End If

        ElseIf TmpDt.Rows(i).Item("Kind") = 9 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = TmpDt.Rows(i).Item("MonFac")
            row1("Bes") = 0
            Dt.Rows.Add(row1)

            Dim row As DataRow = Dt.NewRow
            row("D_date") = ""
            row("Disc") = "          اشخاص بستانکار " & TmpDt.Rows(i).Item("nam")
            row("Bed") = 0
            row("Bes") = TmpDt.Rows(i).Item("MonFac")
            Dt.Rows.Add(row)


        ElseIf TmpDt.Rows(i).Item("Kind") >= 10 And TmpDt.Rows(i).Item("Kind") <= 11 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = TmpDt.Rows(i).Item("MonFac")
            row1("Bes") = 0
            Dt.Rows.Add(row1)

            If TmpDt.Rows(i).Item("Discount") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          تخفیفات"
                row("Bed") = 0
                row("Bes") = TmpDt.Rows(i).Item("Discount")
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Cash") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          صندوق"
                row("Bed") = 0
                row("Bes") = TmpDt.Rows(i).Item("Cash")
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("MonHavaleh") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          حواله بانکی - " & GetNamBank(TmpDt.Rows(i).Item("IdBank"))
                row("Bed") = 0
                row("Bes") = TmpDt.Rows(i).Item("MonHavaleh")
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Chk") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          اسناد پرداختی"
                row("Bed") = 0
                row("Bes") = TmpDt.Rows(i).Item("Chk")
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Lend") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          نسیه"
                row("Bed") = 0
                row("Bes") = TmpDt.Rows(i).Item("Lend")
                Dt.Rows.Add(row)
            End If

        ElseIf TmpDt.Rows(i).Item("Kind") = 12 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = 0
            row1("Bes") = TmpDt.Rows(i).Item("MonFac")
            Dt.Rows.Add(row1)

            If TmpDt.Rows(i).Item("Discount") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          تخفیفات"
                row("Bed") = TmpDt.Rows(i).Item("Discount")
                row("Bes") = 0
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Cash") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          صندوق"
                row("Bed") = TmpDt.Rows(i).Item("Cash")
                row("Bes") = 0
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("MonHavaleh") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          حواله بانکی - " & GetNamBank(TmpDt.Rows(i).Item("IdBank"))
                row("Bed") = TmpDt.Rows(i).Item("MonHavaleh")
                row("Bes") = 0
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Chk") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          اسناد دریافتی"
                row("Bed") = TmpDt.Rows(i).Item("Chk")
                row("Bes") = 0
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Lend") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          نسیه"
                row("Bed") = TmpDt.Rows(i).Item("Lend")
                row("Bes") = 0
                Dt.Rows.Add(row)
            End If

        ElseIf TmpDt.Rows(i).Item("Kind") >= 13 And TmpDt.Rows(i).Item("Kind") <= 14 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = If(TmpDt.Rows(i).Item("Kind") = 13, TmpDt.Rows(i).Item("MonFac"), 0)
            row1("Bes") = If(TmpDt.Rows(i).Item("Kind") = 14, TmpDt.Rows(i).Item("MonFac"), 0)
            Dt.Rows.Add(row1)


            If TmpDt.Rows(i).Item("Cash") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          صندوق"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 14, TmpDt.Rows(i).Item("Cash"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 13, TmpDt.Rows(i).Item("Cash"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("MonHavaleh") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          حواله بانکی - " & GetNamBank(TmpDt.Rows(i).Item("IdBank"))
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 14, TmpDt.Rows(i).Item("MonHavaleh"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 13, TmpDt.Rows(i).Item("MonHavaleh"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Chk") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = If(TmpDt.Rows(i).Item("Kind") = 13, "          اسناد پرداختی", "          اسناد دریافتی")
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 14, TmpDt.Rows(i).Item("Chk"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 13, TmpDt.Rows(i).Item("Chk"), 0)
                Dt.Rows.Add(row)
            End If


            If TmpDt.Rows(i).Item("Lend") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          نسیه"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 14, TmpDt.Rows(i).Item("Lend"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 13, TmpDt.Rows(i).Item("Lend"), 0)
                Dt.Rows.Add(row)
            End If

        ElseIf TmpDt.Rows(i).Item("Kind") >= 15 And TmpDt.Rows(i).Item("Kind") <= 16 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = If(TmpDt.Rows(i).Item("Kind") = 16, TmpDt.Rows(i).Item("MonFac"), 0)
            row1("Bes") = If(TmpDt.Rows(i).Item("Kind") = 15, TmpDt.Rows(i).Item("MonFac"), 0)
            Dt.Rows.Add(row1)

            If TmpDt.Rows(i).Item("Cash") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          صندوق"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 15, TmpDt.Rows(i).Item("Cash"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 16, TmpDt.Rows(i).Item("Cash"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Chk") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = If(TmpDt.Rows(i).Item("Kind") = 16, "          اسناد پرداختی", "          اسناد دریافتی")
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 15, TmpDt.Rows(i).Item("Chk"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 16, TmpDt.Rows(i).Item("Chk"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Discount") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          تخفیفات"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 15, TmpDt.Rows(i).Item("Discount"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 16, TmpDt.Rows(i).Item("Discount"), 0)
                Dt.Rows.Add(row)
            End If

            If TmpDt.Rows(i).Item("Lend") > 0 Then
                Dim row As DataRow = Dt.NewRow
                row("D_date") = ""
                row("Disc") = "          نسیه"
                row("Bed") = If(TmpDt.Rows(i).Item("Kind") = 15, TmpDt.Rows(i).Item("Lend"), 0)
                row("Bes") = If(TmpDt.Rows(i).Item("Kind") = 16, TmpDt.Rows(i).Item("Lend"), 0)
                Dt.Rows.Add(row)
            End If

        ElseIf (TmpDt.Rows(i).Item("Kind") >= 17 And TmpDt.Rows(i).Item("Kind") <= 18) Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = 0
            row1("Bes") = TmpDt.Rows(i).Item("MonFac")
            Dt.Rows.Add(row1)

            Dim row As DataRow = Dt.NewRow
            row("D_date") = ""
            row("Disc") = "          اشخاص بدهکار " & TmpDt.Rows(i).Item("nam")
            row("Bed") = TmpDt.Rows(i).Item("MonFac")
            row("Bes") = 0
            Dt.Rows.Add(row)

        ElseIf TmpDt.Rows(i).Item("Kind") = 23 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = 0
            row1("Bes") = TmpDt.Rows(i).Item("MonFac")
            Dt.Rows.Add(row1)
            Dim dtr As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT Sanad_BankTBank_Bed.Mon, Define_Bank.n_bank FROM Sanad_BankTBank_Bed INNER JOIN Define_Bank ON Sanad_BankTBank_Bed.IdBankBed = Define_Bank.ID WHERE Sanad_BankTBank_Bed.Id =" & TmpDt.Rows(i).Item("IdBank"), ConectionBank)
                dtr = CMD.ExecuteReader
            End Using
            If dtr.HasRows Then
                While dtr.Read()

                    Dim row As DataRow = Dt.NewRow
                    row("D_date") = ""
                    row("Disc") = "          بانک بدهکار " & dtr("n_bank")
                    row("Bed") = dtr("Mon")
                    row("Bes") = 0
                    Dt.Rows.Add(row)

                End While
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dtr.Close()
        ElseIf TmpDt.Rows(i).Item("Kind") = 24 Then

            Dim row1 As DataRow = Dt.NewRow
            row1("D_date") = TmpDt.Rows(i).Item("D_date")
            row1("Disc") = TmpDt.Rows(i).Item("Disc")
            row1("Bed") = 0
            row1("Bes") = TmpDt.Rows(i).Item("MonFac")
            Dt.Rows.Add(row1)

            Dim row As DataRow = Dt.NewRow
            row("D_date") = ""
            row("Disc") = "          صندوق بدهکار " & TmpDt.Rows(i).Item("nam")
            row("Bed") = TmpDt.Rows(i).Item("MonFac")
            row("Bes") = 0
            Dt.Rows.Add(row)

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

    Private Sub FrmDaftarDay_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Button1.Focus()
    End Sub

    Private Sub FrmDaftarDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmDaftarDay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F84")
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
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_DayWork.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ChkSanad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSanad.CheckedChanged
        If ChkSanad.Checked = True Then
            GroupBox2.Enabled = False
        Else
            GroupBox2.Enabled = True
        End If
    End Sub
End Class