Imports System.Data.SqlClient
Public Class FrmControMali
   
    Private Sub Txtmon1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFac1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtFac2.Focus()
    End Sub

    Private Sub Txtmon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFac1.KeyPress
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

    Private Sub Txtmon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFac1.TextChanged
        If Not (CheckDigitWithOutpoint(Format$(TxtFac1.Text.Replace(",", "")))) Then
            TxtFac1.Text = "0"
            Exit Sub
        End If
        TxtFac1.Text = CDbl(TxtFac1.Text)
    End Sub

    Private Sub Txtmon2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFac2.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub Txtmon2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFac2.KeyPress
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

    Private Sub Txtmon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFac2.TextChanged
        If Not (CheckDigitWithOutpoint(Format$(TxtFac2.Text.Replace(",", "")))) Then
            TxtFac2.Text = "0"
            Exit Sub
        End If
        TxtFac2.Text = CDbl(TxtFac2.Text)
    End Sub

    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_CtrlMali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmControMali_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub FrmControMali_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F100")
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

        ChkAzFactor.Enabled = False
        ChkTaFactor.Enabled = False
        TxtFac1.Enabled = False
        TxtFac2.Enabled = False
        TxtFac1.Text = 0
        TxtFac2.Text = 0
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If ChKfactor.Checked = True Then

            If ChkAzFactor.Checked = False And ChkTaFactor.Checked = False Then
                MessageBox.Show("هیچ محدوده فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkTaFactor.Checked = True
                Exit Sub
            End If

            If ChkAzFactor.Checked = True And ChkTaFactor.Checked = True Then
                If CDbl(TxtFac1.Text) > CDbl(TxtFac2.Text) Then
                    MessageBox.Show("شماره های فاکتور را بصورت صحیح وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If CDbl(TxtFac1.Text) = 0 And CDbl(TxtFac2.Text) = 0 Then
                    MessageBox.Show("شماره های فاکتور را بصورت صحیح وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkAzFactor.Checked = True And ChkTaFactor.Checked = False Then
                If CDbl(TxtFac1.Text) = 0 Then
                    MessageBox.Show("شماره فاکتور را بصورت صحیح وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If ChkAzFactor.Checked = False And ChkTaFactor.Checked = True Then
                If CDbl(TxtFac2.Text) = 0 Then
                    MessageBox.Show("شماره فاکتور را بصورت صحیح وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkTaDate.Checked = True
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    MessageBox.Show(" محدوده زمانی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If ChkPart.Checked = True Then
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
            End If
            If ChkP.Checked = True Then
                If String.IsNullOrEmpty(CmbPart.Text) Then
                    MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbPart.Focus()
                    Exit Sub
                End If
            End If
        End If

        If ChkUser.Checked = True Then
            If String.IsNullOrEmpty(TxtUser.Text) Or String.IsNullOrEmpty(TxtIdUser.Text) Then
                MessageBox.Show("کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtUser.Focus()
                Exit Sub
            End If
        End If

        If ChkVisitor.Checked = True Then
            If String.IsNullOrEmpty(TxtVisitor.Text) Or String.IsNullOrEmpty(TxtIdVisitor.Text) Then
                MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtVisitor.Focus()
                Exit Sub
            End If
        End If

        If ChkCar.Checked = True Then
            If String.IsNullOrEmpty(TxtCar.Text) Or String.IsNullOrEmpty(TxtIdCar.Text) Then
                MessageBox.Show("وسیله حمل را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCar.Focus()
                Exit Sub
            End If
        End If

        If ChkReciver.Checked = True Then
            If String.IsNullOrEmpty(TxtReciver.Text) Or String.IsNullOrEmpty(TxtIdRecevier.Text) Then
                MessageBox.Show("مامور توزیع را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtReciver.Focus()
                Exit Sub
            End If
        End If

        Tmp_String1 = ""
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        TmpAddress = ""
        TmpTell1 = ""
        TmpGroupName = ""
        TmpTell1 = ""

        If ChkExit.Checked = True Then
            If String.IsNullOrEmpty(TxtExit.Text) Then
                MessageBox.Show("هیچ خروجی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtExit.Focus()
                Exit Sub
            End If
            Tmp_String1 = TxtExit.Text
        End If

        '''''''''''''''''''''''
        Dim Part As String = ""
        If ChkPart.Checked = True Then
            Part = " Define_People.IdOstan=" & CmbOstan.SelectedValue
            Part &= If(ChkCity.Checked = True, " AND Define_People.IdCity=" & CmbCity.SelectedValue, "")
            Part &= If(ChkP.Checked = True, " AND Define_People.IdPart=" & CmbPart.SelectedValue, "")
            Part = " AND (" & Part & ")"
        End If

        Dim Fac As String = ""
        If ChKfactor.Checked = True Then
            If ChkAzFactor.Checked = True And ChkTaFactor.Checked = True Then
                Fac = " AND ( IdFactor >=" & CLng(TxtFac1.Text) & " AND IdFactor <=" & CLng(TxtFac2.Text) & ")"
            ElseIf ChkAzFactor.Checked = True And ChkTaFactor.Checked = False Then
                Fac = " AND ( IdFactor >=" & CLng(TxtFac1.Text) & ")"
            ElseIf ChkAzFactor.Checked = False And ChkTaFactor.Checked = True Then
                Fac = " AND ( IdFactor <=" & CLng(TxtFac2.Text) & ")"
            End If
        End If

        Dim Dat As String = ""
        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                Dat = " AND ( D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                Dat = " AND ( D_date >=N'" & FarsiDate1.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                Dat = " AND ( D_date <=N'" & FarsiDate2.ThisText & "')"
            End If
        End If
        Dim FacExit As String = ""
        If ChkExit.Checked = True Then
            FacExit = GetExitFac(TxtExit.Text)
            If FacExit = "-1" Then
                MessageBox.Show(" خروجی مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtExit.Focus()
                Exit Sub
            End If
        End If

        Dim visitor As String = ""
        If ChkVisitor.Checked = True Then
            visitor = " AND IdVisitor =" & TxtIdVisitor.Text
            Tmp_TwoGroup = TxtVisitor.Text
        Else
            Tmp_TwoGroup = ""
        End If


        Dim user As String = ""
        If ChkUser.Checked = True Then
            user = " AND IdUser =" & TxtIdUser.Text
            Tmp_String2 = TxtUser.Text
        Else
            Tmp_String2 = ""
        End If

        Dim StrCar As String = ""
        If ChkCar.Checked = True And ChkReciver.Checked = True Then
            StrCar = " AND ListFactorSell.IdFactor IN (SELECT ListExitFactor.IdFactor FROM ExitFactor INNER JOIN ListExitFactor ON ExitFactor.Id = ListExitFactor.IdList WHERE IdCar =" & TxtIdCar.Text & " AND IdRecive=" & TxtIdRecevier.Text & ")"
            TmpGroupName = TxtCar.Text.Trim
            TmpTell1 = TxtReciver.Text.Trim
        End If

        If ChkCar.Checked = True And ChkReciver.Checked = False Then
            StrCar = " AND ListFactorSell.IdFactor IN (SELECT ListExitFactor.IdFactor FROM ExitFactor INNER JOIN ListExitFactor ON ExitFactor.Id = ListExitFactor.IdList WHERE IdCar =" & TxtIdCar.Text & ")"
            TmpGroupName = TxtCar.Text.Trim
            TmpTell1 = ""
        End If

        If ChkCar.Checked = False And ChkReciver.Checked = True Then
            StrCar = " AND ListFactorSell.IdFactor IN (SELECT ListExitFactor.IdFactor FROM ExitFactor INNER JOIN ListExitFactor ON ExitFactor.Id = ListExitFactor.IdList WHERE IdRecive=" & TxtIdRecevier.Text & ")"
            TmpGroupName = ""
            TmpTell1 = TxtReciver.Text.Trim
        End If

        '''''''''''''''''''''''
        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تیم پخش", "تهيه گزارش", "", "")

        Using FPrint As New FrmPrint
            If ChkPayFac.Checked = False Then
                If ChkExit.Checked = True Then
                    FPrint.PrintSQl = "SELECT ListFactorSell.IdFactor,IdVisitor,IdName, Nam,ISNULL([Address],'') AS Adres,((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )+MonAdd -MonDec-Discount )  As MonFac ,((SELECT  ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )+Discount+MonDec-MonAdd )  As Discount,((SELECT  ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor ))  As AllMonFac FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  INNER JOIN ListExitFactor On ListFactorSell.IdFactor =ListExitFactor.IdFactor  WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & FacExit & user & visitor & " ORDER BY Priority"
                Else
                    FPrint.PrintSQl = "SELECT ListFactorSell.IdFactor,IdVisitor,IdName, Nam,ISNULL([Address],'') AS Adres,((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )+MonAdd -MonDec-Discount )  As MonFac ,((SELECT  ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )+Discount+MonDec-MonAdd )  As Discount,((SELECT  ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor ))  As AllMonFac FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & Part & Fac & Dat & user & visitor & StrCar & " ORDER BY IdFactor"
                End If
                FPrint.CHoose = "CONTROLFACTOR"
            Else
                If ChkExit.Checked = True Then
                    If ChkLend.Checked = False Then
                        FPrint.PrintSQl = "SELECT *,Lend=(MonFac-Pay-BackKala-Kasri) FROM(SELECT Priority,IdFactor,IdVisitor,IdName,Nam,Adres,AllMonFac,DarsadMon+Discount +MonDec -MonAdd AS Discount,(MonFac -MonDec +MonAdd-Discount) AS MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor ) + (SELECT ISNULL((Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllFac.IdFactor) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh WHERE IdFactor =AllFac.IdFactor) As Pay,(SELECT  CASE WHEN SUM(Discount)>0 THEN (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Discount)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) WHEN SUM(Discount)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Discount)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) ELSE 0 END ELSE (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND Get_Pay_Sanad.Discount >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Discount1,(SELECT  CASE WHEN SUM(Cash +MonHavaleh)>0 THEN (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Cash +MonHavaleh)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) WHEN SUM(Cash +MonHavaleh)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Cash +MonHavaleh)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) ELSE 0 END ELSE (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Cash ,MonHavaleh FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND (Cash>0 OR MonHavaleh>0)) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Cash,(SELECT  CASE WHEN SUM(MonPayChk)>0 THEN (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(MonPayChk)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) WHEN SUM(MonPayChk)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(MonPayChk)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) ELSE 0 END ELSE (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,MonPayChk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND MonPayChk >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Chk,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =AllFac.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon-KalaFactorBackSell.DarsadMon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =AllFac.IdFactor)As Backkala,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(PayDate) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As PayDate  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS PayDate,(SELECT CASE WHEN COUNT(*)<=1 THEN CAST(MAX(NumChk) AS Nvarchar(max)) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As NumChk  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS NumChk,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(N_Bank) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As N_Bank  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS N_Bank,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(Number_N) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As Number_N  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS Number_N FROM(SELECT ListFactorSell.IdFactor,IdVisitor,IdName,D_date, Nam,ISNULL([Address],'') AS Adres,Discount,MonAdd ,MonDec,Priority,(SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As MonFac,(SELECT  ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As AllMonFac,(SELECT  ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As DarsadMon FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN ListExitFactor On ListFactorSell.IdFactor =ListExitFactor.IdFactor WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & FacExit & user & visitor & " )As AllFac) As AllFacList  ORDER BY Priority"
                    Else
                        FPrint.PrintSQl = "SELECT *,Lend=(MonFac-Pay-BackKala-Kasri) FROM(SELECT Priority,IdFactor,IdVisitor,IdName,Nam,Adres,AllMonFac,DarsadMon+Discount +MonDec -MonAdd AS Discount,(MonFac -MonDec +MonAdd-Discount) AS MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor ) + (SELECT ISNULL((Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllFac.IdFactor) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh WHERE IdFactor =AllFac.IdFactor) As Pay,(SELECT  CASE WHEN SUM(Discount)>0 THEN (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Discount)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) WHEN SUM(Discount)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Discount)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) ELSE 0 END ELSE (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND Get_Pay_Sanad.Discount >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Discount1,(SELECT  CASE WHEN SUM(Cash +MonHavaleh)>0 THEN (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Cash +MonHavaleh)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) WHEN SUM(Cash +MonHavaleh)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Cash +MonHavaleh)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) ELSE 0 END ELSE (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Cash ,MonHavaleh FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND (Cash>0 OR MonHavaleh>0)) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Cash,(SELECT  CASE WHEN SUM(MonPayChk)>0 THEN (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(MonPayChk)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) WHEN SUM(MonPayChk)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(MonPayChk)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) ELSE 0 END ELSE (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,MonPayChk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND MonPayChk >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Chk,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =AllFac.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon-KalaFactorBackSell.DarsadMon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =AllFac.IdFactor)As Backkala,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(PayDate) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As PayDate  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS PayDate,(SELECT CASE WHEN COUNT(*)<=1 THEN CAST(MAX(NumChk) AS Nvarchar(max)) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As NumChk  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS NumChk,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(N_Bank) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As N_Bank  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS N_Bank,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(Number_N) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As Number_N  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS Number_N FROM(SELECT ListFactorSell.IdFactor,IdVisitor,IdName,D_date, Nam,ISNULL([Address],'') AS Adres,Discount,MonAdd ,MonDec,Priority,(SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As MonFac,(SELECT  ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As AllMonFac,(SELECT  ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As DarsadMon FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN ListExitFactor On ListFactorSell.IdFactor =ListExitFactor.IdFactor WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & FacExit & user & visitor & " )As AllFac) As AllFacList WHERE (MonFac-Pay-BackKala-Kasri)>0   ORDER BY Priority"
                    End If
                Else
                    If ChkLend.Checked = False Then
                        FPrint.PrintSQl = "SELECT *,Lend=(MonFac-Pay-BackKala-Kasri) FROM(SELECT IdFactor,IdVisitor,IdName,Nam,Adres,AllMonFac,DarsadMon+Discount +MonDec -MonAdd AS Discount,(MonFac -MonDec +MonAdd-Discount) AS MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor ) + (SELECT ISNULL((Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllFac.IdFactor) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh WHERE IdFactor =AllFac.IdFactor) As Pay,(SELECT  CASE WHEN SUM(Discount)>0 THEN (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Discount)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) WHEN SUM(Discount)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Discount)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) ELSE 0 END ELSE (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND Get_Pay_Sanad.Discount >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Discount1,(SELECT  CASE WHEN SUM(Cash +MonHavaleh)>0 THEN (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Cash +MonHavaleh)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) WHEN SUM(Cash +MonHavaleh)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Cash +MonHavaleh)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) ELSE 0 END ELSE (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Cash ,MonHavaleh FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND (Cash>0 OR MonHavaleh>0)) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Cash,(SELECT  CASE WHEN SUM(MonPayChk)>0 THEN (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(MonPayChk)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) WHEN SUM(MonPayChk)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(MonPayChk)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) ELSE 0 END ELSE (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,MonPayChk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND MonPayChk >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Chk,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =AllFac.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon-KalaFactorBackSell.DarsadMon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =AllFac.IdFactor)As Backkala,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(PayDate) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As PayDate  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS PayDate,(SELECT CASE WHEN COUNT(*)<=1 THEN CAST(MAX(NumChk) AS Nvarchar(max)) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As NumChk  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS NumChk,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(N_Bank) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As N_Bank  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS N_Bank,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(Number_N) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As Number_N  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS Number_N FROM(SELECT ListFactorSell.IdFactor,IdVisitor,IdName,D_date, Nam,ISNULL([Address],'') AS Adres,Discount,MonAdd ,MonDec,(SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As MonFac,(SELECT  ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As AllMonFac,(SELECT  ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As DarsadMon FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & Part & Fac & Dat & user & visitor & StrCar & " )As AllFac) As AllFacList  ORDER BY IdFactor"
                    Else
                        FPrint.PrintSQl = "SELECT *,Lend=(MonFac-Pay-BackKala-Kasri) FROM(SELECT IdFactor,IdVisitor,IdName,Nam,Adres,AllMonFac,DarsadMon+Discount +MonDec -MonAdd AS Discount,(MonFac -MonDec +MonAdd-Discount) AS MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor ) + (SELECT ISNULL((Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllFac.IdFactor) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh WHERE IdFactor =AllFac.IdFactor) As Pay,(SELECT  CASE WHEN SUM(Discount)>0 THEN (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Discount)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) WHEN SUM(Discount)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Discount)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) ELSE 0 END ELSE (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND Get_Pay_Sanad.Discount >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Discount1,(SELECT  CASE WHEN SUM(Cash +MonHavaleh)>0 THEN (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(Cash +MonHavaleh)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) WHEN SUM(Cash +MonHavaleh)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Cash +MonHavaleh)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) ELSE 0 END ELSE (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,Cash ,MonHavaleh FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND (Cash>0 OR MonHavaleh>0)) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Cash,(SELECT  CASE WHEN SUM(MonPayChk)>0 THEN (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) + CASE WHEN SUM(MonPayChk)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) WHEN SUM(MonPayChk)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(MonPayChk)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) ELSE 0 END ELSE (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=AllFac.IdFactor) END FROM (SELECT Id,MonPayChk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =AllFac.IdName AND MonPayChk >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Chk,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =AllFac.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon-KalaFactorBackSell.DarsadMon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =AllFac.IdFactor)As Backkala,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(PayDate) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As PayDate  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS PayDate,(SELECT CASE WHEN COUNT(*)<=1 THEN CAST(MAX(NumChk) AS Nvarchar(max)) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As NumChk  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS NumChk,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(N_Bank) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As N_Bank  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS N_Bank,(SELECT CASE WHEN COUNT(*)<=1 THEN MAX(Number_N) ELSE CAST(COUNT(*) AS nvarchar(max))+ N'فقره چک' END As Number_N  FROM (SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=3 AND Chk_Get_Pay.[Number_Type]=AllFac.IdFactor AND Chk_Get_Pay.Kind=0 UNION ALL SELECT PayDate,NumChk,N_Bank,Number_N FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.[Number_Type] IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE  IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =AllFac.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1))AS ListChk) AS Number_N FROM(SELECT ListFactorSell.IdFactor,IdVisitor,IdName,D_date, Nam,ISNULL([Address],'') AS Adres,Discount,MonAdd ,MonDec,(SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As MonFac,(SELECT  ISNULL(SUM(Mon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As AllMonFac,(SELECT  ISNULL(SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor )As DarsadMon FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & Part & Fac & Dat & user & visitor & StrCar & " )As AllFac) As AllFacList WHERE (MonFac-Pay-BackKala-Kasri)>0  ORDER BY IdFactor"
                    End If
                End If
                FPrint.CHoose = "CONTROLFACTOR2"
            End If
            FPrint.ShowDialog()
        End Using
        Me.Enabled = True
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            ChkExit.Checked = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            FarsiDate1.Focus()
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

    Private Sub ChKfactor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKfactor.CheckedChanged
        If ChKfactor.Checked = True Then
            ChkAzFactor.Enabled = True
            ChkTaFactor.Enabled = True
            ChkExit.Checked = False
            TxtFac1.Enabled = True
            TxtFac1.Text = 0
            TxtFac2.Enabled = True
            TxtFac2.Text = 0
            ChkAzFactor.Checked = True
            ChkTaFactor.Checked = True
            TxtFac1.Focus()
        Else
            ChkAzFactor.Enabled = False
            ChkTaFactor.Enabled = False
            TxtFac1.Enabled = False
            TxtFac1.Text = 0
            TxtFac2.Enabled = False
            TxtFac2.Text = 0
            ChkAzFactor.Checked = False
            ChkTaFactor.Checked = False
        End If
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then FarsiDate2.Focus()
    End Sub

    Private Sub ChkAzFactor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzFactor.CheckedChanged
        If ChkAzFactor.Checked = True Then
            TxtFac1.Enabled = True
        Else
            TxtFac1.Enabled = False
        End If
    End Sub

    Private Sub ChkTaFactor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaFactor.CheckedChanged
        If ChkTaFactor.Checked = True Then
            TxtFac2.Enabled = True
        Else
            TxtFac2.Enabled = False
        End If
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbPart.Enabled = True
            ChkExit.Checked = False
            Me.Get_Ostan()
            CmbOstan_SelectedIndexChanged(Nothing, Nothing)
            CmbCity_SelectedIndexChanged(Nothing, Nothing)
            CmbOstan.Focus()
        Else
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            CmbPart.Enabled = False
            CmbOstan.DataSource = Nothing
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
        End If
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
            BtnReport.Focus()
        End If
    End Sub

    Private Sub ChkExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkExit.CheckedChanged
        If ChkExit.Checked = True Then
            ChKfactor.Checked = False
            ChkTime.Checked = False
            ChkPart.Checked = False
            ChkCar.Checked = False
            ChkReciver.Checked = False
            TxtExit.Enabled = True
            TxtExit.Focus()
        Else
            TxtExit.Text = ""
            TxtExit.Enabled = False
        End If
    End Sub

    Private Sub TxtExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtExit.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExit.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Exit_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtExit.Focus()
        If Tmp_Namkala <> "" Then
            TxtExit.Text = Tmp_Namkala
        End If
    End Sub

    Private Sub TxtExit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExit.TextChanged
        If Not (CheckDigit(TxtExit.Text)) Then
            TxtExit.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub ChkPayFac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPayFac.CheckedChanged
        If ChkPayFac.Checked = True Then
            ChkLend.Enabled = True
        Else
            ChkLend.Enabled = False
            ChkLend.Checked = False
        End If
    End Sub

    Private Sub ChkUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkUser.CheckedChanged
        If ChkUser.Checked = True Then
            TxtUser.Enabled = True
            TxtUser.Focus()
        Else
            TxtUser.Enabled = False
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
    End Sub

    Private Sub ChkVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisitor.CheckedChanged
        If ChkVisitor.Checked = True Then
            TxtVisitor.Enabled = True
            TxtVisitor.Focus()
        Else
            TxtVisitor.Enabled = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New User_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
        End If
    End Sub
    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        If Tmp_Namkala <> "" Then
            TxtVisitor.Text = Tmp_Namkala
            TxtIdVisitor.Text = IdKala
        End If
    End Sub

    Private Sub ChkCar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCar.CheckedChanged
        If ChkCar.Checked = True Then
            ChkExit.Checked = False
            ChkExit.Checked = False
            TxtCar.Enabled = True
            TxtCar.Focus()
        Else
            TxtCar.Enabled = False
            TxtCar.Text = ""
            TxtIdCar.Text = ""
        End If
    End Sub

    Private Sub ChkReciver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkReciver.CheckedChanged
        If ChkReciver.Checked = True Then
            ChkExit.Checked = False
            ChkExit.Checked = False
            TxtReciver.Enabled = True
            TxtReciver.Focus()
        Else
            TxtReciver.Enabled = False
            TxtReciver.Text = ""
            TxtIdRecevier.Text = ""
        End If
    End Sub

    Private Sub TxtCar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCar.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtCar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Car_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtCar.Focus()
        If Tmp_Namkala <> "" Then
            TxtIdCar.Text = IdKala
            TxtCar.Text = Tmp_Namkala
        Else
            TxtIdCar.Text = ""
            TxtCar.Text = ""
        End If
    End Sub

    Private Sub TxtReciver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReciver.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtReciver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReciver.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Reciver_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtReciver.Focus()
        If Tmp_Namkala <> "" Then
            TxtIdRecevier.Text = IdKala
            TxtReciver.Text = Tmp_Namkala
        Else
            TxtIdRecevier.Text = ""
            TxtReciver.Text = ""
        End If
    End Sub
End Class