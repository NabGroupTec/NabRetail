Imports System.Data.SqlClient
Public Class ReportFroshStateUser

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

    Private Sub ReportFroshAllUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ReportFroshAllUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F141")
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
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Me.GetUserList()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ChkAll.Checked = True
        If Kind_User = 0 Then
            GroupBox1.Enabled = False
            For i As Integer = 0 To DGV.RowCount - 1
                If DGV.Item("Cln_IdP", i).Value = Id_User Then
                    DGV.Item("Cln_Select", i).Value = True
                Else
                    DGV.Item("Cln_Select", i).Value = False
                End If
            Next
        End If
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("کاربری وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            If ChkGroup.Checked = True Then
                If String.IsNullOrEmpty(TxtGroup.Text) Or String.IsNullOrEmpty(TxtIdGroup.Text) Then
                    MessageBox.Show("هیچ گروهی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtGroup.Focus()
                    Exit Sub
                End If
            End If

            Dim ListUser As String = ""
            Dim CountUser As Long = 0
            ListUser = " WHERE ("
            For i As Integer = 0 To DGV.RowCount - 1
                If DGV.Item("Cln_Select", i).Value = True Then
                    ListUser &= "ID=" & DGV.Item("Cln_IdP", i).Value & " OR "
                    CountUser += 1
                End If
            Next

            If CountUser = DGV.RowCount Then
                ListUser = ""
            ElseIf CountUser <= 0 Then
                MessageBox.Show("کاربری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                ListUser = ListUser.Substring(0, ListUser.Length - 4)
                ListUser &= ")"
            End If

            Dim dat As String = ""
            Dim dat2 As String = ""
            Dim dat3 As String = ""
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
                dat2 = " AND (Chk_Get_Pay.[GetDate]>=N'" & FarsiDate1.ThisText & "' AND Chk_Get_Pay.[GetDate]<=N'" & FarsiDate2.ThisText & "')"
                dat3 = " WHERE (D_dat>=N'" & FarsiDate1.ThisText & "' AND D_dat<=N'" & FarsiDate2.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
                dat2 = " AND (Chk_Get_Pay.[GetDate]>=N'" & FarsiDate1.ThisText & "')"
                dat3 = " WHERE (D_dat>=N'" & FarsiDate1.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
                dat2 = " AND (Chk_Get_Pay.[GetDate]<=N'" & FarsiDate2.ThisText & "')"
                dat3 = " WHERE (D_dat<=N'" & FarsiDate2.ThisText & "')"
            Else
                dat = ""
                dat2 = ""
                dat3 = ""
            End If


            Dim group As String = ""
            Dim visit As String = ""

            If ChkGroup.Checked = True Then
                group = " (ChkIdGroup ='True' AND ("
                If Not TxtIdGroup.Text.Contains("-") Then
                    group &= "IdGroup =" & CLng(TxtIdGroup.Text) & "))"
                Else
                    Dim x() As String = TxtIdGroup.Text.Split("-")
                    For i As Integer = 0 To x.Length - 1
                        group &= "IdGroup =" & x(i) & " OR "
                    Next
                    group = group.Substring(0, group.Length - 3) & "))"
                End If
            End If

            If ChkActiv.Checked = True And ChkGroup.Checked = True Then
                visit = " AND IdName IN (SELECT ID FROM Define_People WHERE Activ ='False' AND " & group & ")"
            ElseIf ChkActiv.Checked = True And ChkGroup.Checked = False Then
                visit = " AND IdName IN (SELECT ID FROM Define_People WHERE Activ ='False')"
            ElseIf ChkActiv.Checked = False And ChkGroup.Checked = True Then
                visit = " AND IdName IN (SELECT ID FROM Define_People WHERE " & group & ")"
            End If

            If ChkTime.Checked = False Then
                FrmPrint.Str1 = ""
                FrmPrint.State = ""
            Else
                FrmPrint.Str1 = ""
                FrmPrint.State = ""
                If ChkAzDate.Checked = True Then FrmPrint.Str1 = FarsiDate1.ThisText
                If ChkTaDate.Checked = True Then FrmPrint.State = FarsiDate2.ThisText
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "عملکرد کاربران", "تهیه گزارش", "", "")

            FrmPrint.CHoose = "FROSHSTATEUSER"
            'FrmPrint.PrintSQl = "DECLARE @FroshK float SET @FroshK =(SELECT (Frosh.MonSell-Backfrosh.MonBack-Discount.Darsad) AS EndFrosh FROM (SELECT ISNULL(SUM(Mon),0) As MonSell FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3  " & dat & " )As Frosh,(SELECT ISNULL(SUM(Mon),0) As MonBack FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1  " & dat & " )As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1  " & dat & " And ListFactorSell.Stat =3 AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1  " & dat & " And ListFactorSell.Stat =3 AND Discount >0 )  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1  " & dat & "  AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1  " & dat & "  AND  Discount >0 )) AS AllDiscount) As Discount) SELECT Id,Nam,Frosh,Backfrosh,Discount,(Frosh-Backfrosh-Discount) AS EndFrosh,DarsadEndFrosh=CASE WHEN @FroshK<=0 THEN '0' ELSE REPLACE(ROUND((Frosh-Backfrosh-Discount)*100/@FroshK,2),'.','/') END,CountFactor,CountKala,REPLACE(SumRow ,'.','/') As SumRow,Row=CASE WHEN CountRow<=0 OR CountFactor<=0 THEN '0' ELSE REPLACE(CAST(ROUND(CAST(CountRow As Float) / CountFactor,2) AS Nvarchar(max)) ,'.','/') END,(0) As DelayFactor,(0) As MandehFactor,(0) As CVisit,AllMon,Pay,DiscountF,CASE  WHEN AllMon<>0 THEN REPLACE(ROUND(CAST(DiscountF AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Discount,Cash,CASE  WHEN AllMon<>0 THEN REPLACE(ROUND(CAST(Cash AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Cash,Chk,CASE  WHEN AllMon<>0 THEN REPLACE(ROUND(CAST(Chk AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Chk,(AllMon-Pay ) As lend,CASE  WHEN AllMon -Pay <>0 THEN REPLACE(ROUND(CAST((AllMon -Pay) AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Lend,GetChk,Pvisit,AllVisit=(SELECT COUNT(ID) FROM Define_People " & If(ChkActiv.Checked = True, "WHERE Activ ='False' AND", "WHERE") & " IdPart IN (SELECT DISTINCT IdPart FROM Define_People WHERE ID in(SELECT IdName FROM ListFactorSell WHERE IdUser =AllList.Id  " & dat & ")))  FROM (SELECT Id,Nam ,(SELECT ISNULL(SUM(Mon),0) FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 AND IdUser =ListUser.Id  " & dat & ")As Frosh,(SELECT ISNULL(SUM(Mon),0) FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1  AND IdUser =ListUser.Id  " & dat & ")As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdUser =ListUser.Id And ListFactorSell.Stat =3 AND DarsadMon >0  " & dat & ")  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdUser =ListUser.Id And ListFactorSell.Stat =3 AND Discount >0  " & dat & ")  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdUser =ListUser.Id  AND DarsadMon >0 " & dat & ")  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdUser =ListUser.Id  AND Discount >0  " & dat & ")) AS AllDiscount) As Discount,(SELECT SUM(CC) FROM (SELECT Count(IdFactor) AS CC FROM  ListFactorSell WHERE Activ =1 AND Stat =3 AND IdUser =ListUser.Id  " & dat & " UNION ALL SELECT Count(IdFactor) * -1 AS CC FROM  ListFactorbackSell WHERE Activ =1  AND IdUser =ListUser.Id  " & dat & ")AS AllCountFac) As CountFactor,(SELECT SUM(CK) FROM (SELECT COUNT(DISTINCT KalaFactorSell.IdKala) AS CK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdUser = ListUser.Id  " & dat & " )))AS AllCountKala)As CountKala,(SELECT SUM(RK) FROM (SELECT COUNT(KalaFactorSell.IdKala) AS RK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdUser = ListUser.Id  " & dat & " )))AS AllCountRo)As CountRow,(SELECT SUM(SR) FROM (SELECT ISNULL(SUM(KalaFactorSell.KolCount),0) AS SR FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdUser = ListUser.Id  " & dat & " )))AS AllSumRo)As SumRow,(SELECT ISNULL(SUM(KalaFactorSell.Mon),0) As Mon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 " & dat & " AND ListFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & " ))As AllMon,(SELECT ISNULL(SUM(pay),0) As pay FROM PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdUser=ListUser.Id) " & dat & ")) + (SELECT ISNULL(SUM(Cash+MonHavaleh +MonPayChk+Discount +MonDec -MonAdd ),0) As pay FROM ListFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & ") " & dat & " )+(SELECT ISNULL(SUM(DarsadMon),0) As pay  FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & ")) As Pay,(SELECT (ISNULL(SUM(DarsadMon),0)+ISNULL(SUM(Discount),0) +ISNULL(SUM(MonDec),0)+(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 " & dat & " AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & ")) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) -ISNULL(SUM(MonAdd),0))  FROM KalaFactorSell INNER JOIN ListFactorSell ON ListFactorSell.IdFactor =KalaFactorSell.IdFactor  WHERE ListFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & ") " & dat & ") As DiscountF,(SELECT ISNULL(SUM((Cash +MonHavaleh)),0) + (SELECT ISNULL(Sum(Cash+MonHavaleh),0) FROM ListFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & " ) " & dat & ") As Cash FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 " & dat & " AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & " )) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As Cash,(SELECT ISNULL(SUM(MonPayChk),0)+ (SELECT ISNULL(SUM(MonPayChk),0) FROM ListFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & " )) As Chk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 " & dat & " AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & " )) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As Chk ,(SELECT ISNULL(SUM(MoneyChk),0) As MonChk FROM (SELECT Current_State,Chk_Get_Pay.[GetDate],Chk_Get_Pay.ID,MoneyChk FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) " & dat2 & " ) As ListGetChk WHERE (Current_State=0  OR Current_State=4 ) AND ID IN (SELECT Id FROM Chk_Get_Pay WHERE (([Type]=3 Or [Type]=5) AND Kind=0 AND  Number_Type IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdUser =ListUser.Id)) Or ([Type]=12 AND Kind=0 AND Number_Type IN (SELECT Idsanad From PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdUser =ListUser.Id))))) As GetChk,(SELECT COUNT(DISTINCT ListFactorSell.IdName) As PVisit FROM  ListFactorSell  WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) " & dat & " AND IdUser=ListUser.Id) as Pvisit FROM (SELECT Nam, Id FROM Define_User  " & ListUser & ")AS ListUser) As AllList"

            FrmPrint.PrintSQl = "DECLARE @FroshK float SET @FroshK =(SELECT (Frosh.MonSell-Backfrosh.MonBack-Discount.Darsad) AS EndFrosh FROM (SELECT ISNULL(SUM(Mon),0) As MonSell FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3  " & dat & " )As Frosh,(SELECT ISNULL(SUM(Mon),0) As MonBack FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1  " & dat & " )As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1  " & dat & " And ListFactorSell.Stat =3 AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1  " & dat & " And ListFactorSell.Stat =3 AND Discount >0 )  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1  " & dat & "  AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1  " & dat & "  AND  Discount >0 )) AS AllDiscount) As Discount) SELECT Id,Nam,Frosh,Backfrosh,Discount,(Frosh-Backfrosh-Discount) AS EndFrosh,DarsadEndFrosh=CASE WHEN @FroshK<=0 THEN '0' ELSE REPLACE(ROUND((Frosh-Backfrosh-Discount)*100/@FroshK,2),'.','/') END,CountFactor,CountKala,REPLACE(SumRow ,'.','/') As SumRow,Row=CASE WHEN CountRow<=0 OR CountFactor<=0 THEN '0' ELSE REPLACE(CAST(ROUND(CAST(CountRow As Float) / CountFactor,2) AS Nvarchar(max)) ,'.','/') END,(0) As DelayFactor,(0) As MandehFactor,(0) As CVisit,AllMon,Pay,DiscountF,CASE  WHEN AllMon<>0 THEN REPLACE(ROUND(CAST(DiscountF AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Discount,Cash,CASE  WHEN AllMon<>0 THEN REPLACE(ROUND(CAST(Cash AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Cash,Chk,CASE  WHEN AllMon<>0 THEN REPLACE(ROUND(CAST(Chk AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Chk,(AllMon-Pay ) As lend,CASE  WHEN AllMon -Pay <>0 THEN REPLACE(ROUND(CAST((AllMon -Pay) AS Float)*100/AllMon,2),'.','/') ELSE '0' END As SD_Lend,GetChk,Pvisit,AllVisit=(SELECT COUNT(ID) FROM Define_People " & If(ChkActiv.Checked = True, "WHERE Activ ='False' AND", "WHERE") & " IdPart IN (SELECT DISTINCT IdPart FROM Define_People WHERE ID in(SELECT IdName FROM ListFactorSell WHERE IdUser =AllList.Id  " & dat & "))" & If(String.IsNullOrEmpty(group), "", " AND " & group) & ")  FROM (SELECT Id,Nam ,(SELECT ISNULL(SUM(Mon),0) FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 AND IdUser =ListUser.Id  " & dat & ")As Frosh,(SELECT ISNULL(SUM(Mon),0) FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1  AND IdUser =ListUser.Id  " & dat & ")As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdUser =ListUser.Id And ListFactorSell.Stat =3 AND DarsadMon >0  " & dat & ")  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdUser =ListUser.Id And ListFactorSell.Stat =3 AND Discount >0  " & dat & ")  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdUser =ListUser.Id  AND DarsadMon >0 " & dat & ")  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdUser =ListUser.Id  AND Discount >0  " & dat & ")) AS AllDiscount) As Discount,(SELECT SUM(CC) FROM (SELECT Count(IdFactor) AS CC FROM  ListFactorSell WHERE Activ =1 AND Stat =3 AND IdUser =ListUser.Id  " & dat & " UNION ALL SELECT Count(IdFactor) * -1 AS CC FROM  ListFactorbackSell WHERE Activ =1  AND IdUser =ListUser.Id  " & dat & ")AS AllCountFac) As CountFactor,(SELECT SUM(CK) FROM (SELECT COUNT(DISTINCT KalaFactorSell.IdKala) AS CK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdUser = ListUser.Id " & dat & "  )) UNION ALL SELECT COUNT(DISTINCT KalaFactorBackSell.IdKala) *-1 AS CK FROM KalaFactorBackSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorBackSell WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdUser = ListUser.Id " & dat & "  )))AS AllCountKala)As CountKala,(SELECT SUM(RK) FROM (SELECT COUNT(KalaFactorSell.IdKala) AS RK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdUser = ListUser.Id " & dat & ")) UNION ALL SELECT COUNT(KalaFactorBackSell.IdKala) * -1 AS RK FROM KalaFactorBackSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorBackSell WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdUser = ListUser.Id " & dat & ")))AS AllCountRo)As CountRow,(SELECT SUM(SR) FROM (SELECT ISNULL(SUM(KalaFactorSell.KolCount),0) AS SR FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdUser = ListUser.Id  " & dat & " )) UNION ALL SELECT ISNULL(SUM(KalaFactorBackSell.KolCount),0) * -1 AS SR FROM KalaFactorBackSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorBackSell WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdUser = ListUser.Id " & dat & " )))AS AllSumRo)As SumRow,(SELECT ISNULL(SUM(KalaFactorSell.Mon),0) As Mon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 " & dat & " AND ListFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & " ))As AllMon,(SELECT ISNULL(SUM(pay),0) As pay FROM PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdUser=ListUser.Id) " & dat & ")) + (SELECT ISNULL(SUM(Cash+MonHavaleh +MonPayChk+Discount +MonDec -MonAdd ),0) As pay FROM ListFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & ") " & dat & " )+(SELECT ISNULL(SUM(DarsadMon),0) As pay  FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id) " & dat & ")) As Pay,(SELECT (ISNULL(SUM(DarsadMon),0)+ISNULL(SUM(Discount),0) +ISNULL(SUM(MonDec),0) -ISNULL(SUM(MonAdd),0) +(SELECT ISNULL(SUM(Discount1),0) FROM (SELECT (SELECT  CASE WHEN SUM(Discount)>0 THEN CASE WHEN SUM(Discount)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) WHEN SUM(Discount)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Discount)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) ELSE 0 END ELSE 0 END FROM (SELECT Id,Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND Get_Pay_Sanad.Discount >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Discount1 FROM (SELECT IdFactor,IdName  FROM  ListFactorSell WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) AND IdUser =ListUser.Id " & dat & " )As AllFac) AS EndDFac) )  FROM KalaFactorSell INNER JOIN ListFactorSell ON ListFactorSell.IdFactor =KalaFactorSell.IdFactor  WHERE ListFactorSell.IdFactor IN (SELECT IdFactor  FROM ListFactorSell WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND IdUser=ListUser.Id)  " & dat & ")  " & dat & " ) As DiscountF,(SELECT ISNULL(SUM(Cash),0) FROM (SELECT (SELECT  CASE WHEN SUM(Cash +MonHavaleh)>0 THEN (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Cash +MonHavaleh)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) WHEN SUM(Cash +MonHavaleh)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Cash +MonHavaleh)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) ELSE 0 END ELSE (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Cash ,MonHavaleh FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND (Cash>0 OR MonHavaleh>0)) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Cash FROM (SELECT IdFactor,IdName FROM  ListFactorSell WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) AND IdUser =ListUser.Id " & dat & " )As AllFac) AS EndDFac) As Cash,(SELECT ISNULL(SUM(Chk),0) FROM (SELECT (SELECT  CASE WHEN SUM(MonPayChk)>0 THEN (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(MonPayChk)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) WHEN SUM(MonPayChk)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(MonPayChk)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) ELSE 0 END ELSE (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,MonPayChk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND MonPayChk >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Chk FROM (SELECT IdFactor,IdName FROM  ListFactorSell WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) AND IdUser =ListUser.Id " & dat & " )As AllFac) AS EndDFac) As Chk ,(SELECT ISNULL(SUM(MoneyChk),0) As MonChk FROM (SELECT Current_State,Chk_Get_Pay.[GetDate],Chk_Get_Pay.ID,MoneyChk FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) " & dat2 & " ) As ListGetChk WHERE (Current_State=0  OR Current_State=4 ) AND ID IN (SELECT Id FROM Chk_Get_Pay WHERE (([Type]=3 Or [Type]=5) AND Kind=0 AND  Number_Type IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdUser =ListUser.Id)) Or ([Type]=12 AND Kind=0 AND Number_Type IN (SELECT Idsanad From PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdUser =ListUser.Id))))) As GetChk,(SELECT COUNT(DISTINCT ListFactorSell.IdName) As PVisit FROM  ListFactorSell  WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) " & dat & " AND IdUser=ListUser.Id " & visit & ") as Pvisit FROM (SELECT Nam, Id FROM Define_User  " & ListUser & ")AS ListUser) As AllList"

            FrmPrint.Lend = "SELECT DISTINCT IdName,MIN(D_date) As D_Date FROM ListFactorSell WHERE (ListFactorSell.Stat =3 And ListFactorSell.Activ =1) AND IdName IN (SELECT ID FROM Define_People " & dat3 & ") GROUP BY IdName"
            FrmPrint.ShowDialog()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportFroshStateUser", "BtnOk_Click")
        End Try
    End Sub

    Private Sub GetUserList()
        Try
            Dim ds_User As New DataTable
            Dim dta_User As New SqlDataAdapter()

            ds_User.Clear()
            If Not dta_User Is Nothing Then
                dta_User.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_User = New SqlDataAdapter("SELECT Id, Nam  FROM Define_User", DataSource)
            dta_User.Fill(ds_User)
            DGV.DataSource = ds_User
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportFroshStateUser", "GetUserList")
        End Try
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepActionkarbar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetUserList()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If ChkGroup.Checked = True Then
            TxtGroup.Enabled = True
            Button1.Enabled = True
            TxtGroup.Focus()
        Else
            TxtGroup.Enabled = False
            Button1.Enabled = False
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

    Private Sub TxtGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
    End Sub

    Private Sub TxtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroup.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Group_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtGroup.Focus()
        If Tmp_Namkala <> "" Then
            TxtGroup.Text = Tmp_Namkala
            TxtIdGroup.Text = IdKala
        Else
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using FrmAdVance As New Group_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then

                    TxtGroup.Clear()
                    TxtIdGroup.Clear()

                    For i As Integer = 0 To AllSelectKala.Length - 1
                        TxtGroup.Text &= AllSelectKala(i).Namekala & " - "
                        TxtIdGroup.Text &= AllSelectKala(i).IdKala & "-"
                    Next
                    TxtGroup.Text = TxtGroup.Text.Substring(0, TxtGroup.Text.Length - 3)
                    TxtIdGroup.Text = TxtIdGroup.Text.Substring(0, TxtIdGroup.Text.Length - 1)
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
                TxtGroup.Clear()
                TxtIdGroup.Clear()
            End Try
        End Using
    End Sub
End Class