Imports System.Data.SqlClient
Public Class ReportsodKha
    
    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_SodKhales.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ReportsodKha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    
    Private Sub Calculate()
        Try
            Txttraz.Text = ((CDbl(TxtNsod.Text) - CDbl(TxtH.Text) - CDbl(TxtHFac.Text) - CDbl(Txtdec.Text) + CDbl(Txtdramad.Text) + CDbl(TxtHDaramad.Text) + CDbl(Txtadd.Text)))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPM.TextChanged
        If Not (CheckDigit(TxtPM.Text.Replace(",", ""))) Then
            TxtPM.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtPM.Text.Length > 3 Then
            str = Format$(TxtPM.Text.Replace(",", ""))
            TxtPM.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtKHM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKHM.TextChanged
        If Not (CheckDigit(TxtKHM.Text.Replace(",", ""))) Then
            TxtKHM.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtKHM.Text.Length > 3 Then
            str = Format$(TxtKHM.Text.Replace(",", ""))
            TxtKHM.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtBFM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBFM.TextChanged
        If Not (CheckDigit(TxtBFM.Text.Replace(",", ""))) Then
            TxtBFM.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBFM.Text.Length > 3 Then
            str = Format$(TxtBFM.Text.Replace(",", ""))
            TxtBFM.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEnd.TextChanged
        If Not (CheckDigit(TxtEnd.Text.Replace(",", ""))) Then
            TxtEnd.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtEnd.Text.Length > 3 Then
            str = Format$(TxtEnd.Text.Replace(",", ""))
            TxtEnd.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtZ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtZ.TextChanged
        If Not (CheckDigit(TxtZ.Text.Replace(",", ""))) Then
            TxtZ.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtZ.Text.Length > 3 Then
            str = Format$(TxtZ.Text.Replace(",", ""))
            TxtZ.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtFM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFM.TextChanged
        If Not (CheckDigit(TxtFM.Text.Replace(",", ""))) Then
            TxtFM.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtFM.Text.Length > 3 Then
            str = Format$(TxtFM.Text.Replace(",", ""))
            TxtFM.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtBBM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBBM.TextChanged
        If Not (CheckDigit(TxtBBM.Text.Replace(",", ""))) Then
            TxtBBM.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBBM.Text.Length > 3 Then
            str = Format$(TxtBBM.Text.Replace(",", ""))
            TxtBBM.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtdramad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdramad.TextChanged
        If Not (CheckDigit(Txtdramad.Text.Replace(",", ""))) Then
            Txtdramad.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtdramad.Text.Length > 3 Then
            str = Format$(Txtdramad.Text.Replace(",", ""))
            Txtdramad.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtNsod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNsod.TextChanged
        If Not (CheckDigit(TxtNsod.Text.Replace(",", ""))) Then
            TxtNsod.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtNsod.Text.Length > 3 Then
            str = Format$(TxtNsod.Text.Replace(",", ""))
            TxtNsod.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtH.TextChanged
        If Not (CheckDigit(TxtH.Text.Replace(",", ""))) Then
            TxtH.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtH.Text.Length > 3 Then
            str = Format$(TxtH.Text.Replace(",", ""))
            TxtH.Text = Format$(Val(str), "###,###,###")
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

    Private Sub Txtadd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtadd.TextChanged
        If Not (CheckDigit(Txtadd.Text.Replace(",", ""))) Then
            Txtadd.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtadd.Text.Length > 3 Then
            str = Format$(Txtadd.Text.Replace(",", ""))
            Txtadd.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtdec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdec.TextChanged
        If Not (CheckDigit(Txtdec.Text.Replace(",", ""))) Then
            Txtdec.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtdec.Text.Length > 3 Then
            str = Format$(Txtdec.Text.Replace(",", ""))
            Txtdec.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub ReportsodKha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F97")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
                If Access_Form.Substring(3, 1) = 0 Then
                    Button1.Enabled = False
                End If
            End If

        End If
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        TxtPart.Enabled = False
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkPart.Checked = False
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
        Button1.Enabled = False
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
        Button1.Enabled = False
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
        Button1.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

        If ChkPart.Checked = True Then
            If String.IsNullOrEmpty(TxtPart.Text.Trim) Or String.IsNullOrEmpty(TxtIdPart.Text.Trim) Then
                MessageBox.Show("پارت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPart.Focus()
                Exit Sub
            End If
        End If

        Dim Sod As String = ""
        Me.Enabled = False
        If ChkPart.Checked = False Then
            If ChkTime.Checked = False Then
                Sod = "SELECT (SELECT (ISNULL(SUM(BedMon),0) -ISNULL(SUM(BesMon),0)) As BesMon  FROM (SELECT Mon As BedMon,BesMon=0.0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  UNION All SELECT Mon As BedMon,BesMon=0.0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END )    FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1  UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END )   FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 )AS AllCharge )As ListCharge,(SELECT ISNULL(SUM(Mon),0) As BB FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =1 UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =1 UNION ALL  SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBuy WHERE Activ =1 AND (Stat =0 or Stat =2) UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorService WHERE Activ =1 UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1)As ListA) As ListBB,(SELECT ISNULL(SUM(Mon),0) As AA FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =0 UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =0 UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListAA FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) UNION ALL SELECT  ISNULL(SUM(MonDec),0) As AA FROM ListFactorBuy  WHERE Activ =1 AND (Stat =0 or Stat =2) UNION ALL SELECT  ISNULL(SUM(MonAdd ),0) As AA FROM ListFactorService   WHERE Activ =1 UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1)As ListA) As ListAA,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell .IdFactor = ListFactorSell .IdFactor WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorSell  WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy  ON KalaFactorBackBuy .IdFactor = ListFactorBackBuy .IdFactor WHERE  ListFactorBackBuy .Activ =1 UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorBackBuy  WHERE  ListFactorBackBuy .Activ =1 UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =0 AND Active =1 UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE  ListFactorService.Activ =1 UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorService WHERE  ListFactorService.Activ =1) As DiscountF) As DiscountFrosh,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorBuy WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell .Activ =1 UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorBackSell  WHERE  ListFactorBackSell .Activ =1 UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =1 AND Active =1 UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorCharge WHERE Activ =1 UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListOtherCharge  WHERE Activ =1 ) As DiscountK) As DiscountKharid,(SELECT ISNULL(SUM(Daramad),0) As Daramad FROM (SELECT  ISNULL(SUM(Cash+ MonHavaleh+ MonPayChk+ Lend),0) As Daramad FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id UNION ALL SELECT ISNULL(SUM(KalaFactorService.Mon),0) Daramad FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1) As Daramad ) AS Daramad ,SUM(OneKala) As OneKala ,SUM(Kharid) As Kharid ,SUM(Frosh) As Frosh ,SUM(Damage) As Damage ,SUM(BackFrosh) As BackFrosh ,SUM(BackKharid) As BackKharid ,SUM(EndKala) As EndKala ,SUM((Frosh-BackFrosh)-(((Kharid +OneKala)-BackKharid )-EndKala )) As SodKala FROM (SELECT Id ,OneKala  ,Kharid ,Frosh ,Damage ,BackFrosh ,BackKharid,EndKala=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(ROUND(KolCount,2) * dbo.GetCost(id,ROUND(KolCount,2),'KOL','','','False'),0) ELSE ROUND(ROUND(JozCount,2) * dbo.GetCost(id,ROUND(JozCount,2) ,'JOZ','','','False'),0) END FROM (SELECT Id,(SELECT  ISNULL(SUM(Mon),0) FROM  Define_PrimaryKala WHERE IdKala =AllKala .Id ) As OneKala,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE KalaFactorBuy.IdKala =AllKala .Id AND  ListFactorBuy.Stat =0 and ListFactorBuy.Activ =1) As Kharid,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE KalaFactorSell.IdKala =AllKala .Id AND  ListFactorSell.Stat =3 and ListFactorSell.Activ =1) As Frosh,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorDamage  INNER JOIN ListFactorDamage  ON KalaFactorDamage .IdFactor = ListFactorDamage .IdFactor WHERE KalaFactorDamage .IdKala =AllKala .Id  and ListFactorDamage .Activ =1) As Damage,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackSell   INNER JOIN ListFactorBackSell  ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE KalaFactorBackSell.IdKala =AllKala .Id AND  ListFactorBackSell.Stat =4 and ListFactorBackSell.Activ =1) As BackFrosh,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE KalaFactorBackBuy.IdKala =AllKala .Id  And ListFactorBackBuy.Activ =1) As BackKharid,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount) As KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount) AS JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) As AllKala) As Allinfo)As Sod"
            Else
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    Sod = "SELECT (SELECT (ISNULL(SUM(BedMon),0) -ISNULL(SUM(BesMon),0)) As BesMon  FROM (SELECT Mon As BedMon,BesMon=0.0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE (D_date  >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION All SELECT Mon As BedMon,BesMon=0.0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END )    FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1  AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END )   FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "'))AS AllCharge ) As ListCharge,(SELECT ISNULL(SUM(Mon),0) As BB FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBuy WHERE Activ =1 AND (Stat =0 or Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorService WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "'))As ListA) As ListBB,(SELECT ISNULL(SUM(Mon),0) As AA FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =0 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =0 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListAA FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As AA FROM ListFactorBuy  WHERE Activ =1 AND (Stat =0 or Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL  SELECT  ISNULL(SUM(MonAdd ),0) As AA FROM ListFactorService   WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "'))As ListA) As ListAA,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell .IdFactor = ListFactorSell .IdFactor WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorSell WHERE  ListFactorSell.Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy  ON KalaFactorBackBuy .IdFactor = ListFactorBackBuy .IdFactor WHERE  ListFactorBackBuy .Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorBackBuy  WHERE  ListFactorBackBuy .Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =0 AND Active =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE  ListFactorService.Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorService WHERE  ListFactorService.Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As DiscountF) As DiscountFrosh,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorBuy WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell .Activ =1  AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM  ListFactorBackSell WHERE ListFactorBackSell.Activ =1  AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =1 AND Active =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorCharge WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListOtherCharge  WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') ) As DiscountK) As DiscountKharid,(SELECT ISNULL(SUM(Daramad),0) As Daramad FROM (SELECT  ISNULL(SUM(Cash+ MonHavaleh+ MonPayChk+ Lend),0) As Daramad FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id WHERE (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(KalaFactorService.Mon),0) Daramad FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As Daramad ) AS Daramad,SUM(OneKala) As OneKala ,SUM(Kharid) As Kharid ,SUM(Frosh) As Frosh ,SUM(Damage) As Damage ,SUM(BackFrosh) As BackFrosh ,SUM(BackKharid) As BackKharid ,SUM(EndKala) As EndKala ,SUM((Frosh-BackFrosh)-(((Kharid +OneKala)-BackKharid )-EndKala )) As SodKala FROM (SELECT Id ,OneKala  ,Kharid ,Frosh ,Damage ,BackFrosh ,BackKharid,EndKala=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(ROUND(KolCount,2) * dbo.GetCost(id,ROUND(KolCount,2),'KOL','','" & FarsiDate2.ThisText & "','False'),0) ELSE ROUND(ROUND(JozCount,2) * dbo.GetCost(id,ROUND(JozCount,2) ,'JOZ','','" & FarsiDate2.ThisText & "','False'),0) END FROM (SELECT Id,(SELECT (EndKala +EndKala2 ) FROM (SELECT Id,EndKala=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(ROUND(KolCount,2) * dbo.GetCost(id,ROUND(KolCount,2),'KOL','" & FarsiDate1.ThisText & "','','False'),0) ELSE ROUND(ROUND(JozCount,2) * dbo.GetCost(id,ROUND(JozCount,2) ,'JOZ','" & FarsiDate1.ThisText & "','','False'),0) END,(SELECT  ISNULL(SUM(Mon),0) FROM  Define_PrimaryKala WHERE IdKala =Allinfo2.Id AND(D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "'))As EndKala2 FROM (SELECT Id,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')) AS AllKolCount) As KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')) AS AllJozCount) AS JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) As AllKala2) As Allinfo2) As Allinfo3 WHERE Id=AllKala .Id ) As OneKala,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE KalaFactorBuy.IdKala =AllKala .Id AND  ListFactorBuy.Stat =0 and ListFactorBuy.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As Kharid,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE KalaFactorSell.IdKala =AllKala .Id AND  ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As Frosh,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorDamage  INNER JOIN ListFactorDamage  ON KalaFactorDamage .IdFactor = ListFactorDamage .IdFactor WHERE KalaFactorDamage .IdKala =AllKala .Id  and ListFactorDamage .Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As Damage,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackSell   INNER JOIN ListFactorBackSell  ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE KalaFactorBackSell.IdKala =AllKala .Id AND  ListFactorBackSell.Stat =4 and ListFactorBackSell.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As BackFrosh,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE KalaFactorBackBuy.IdKala =AllKala .Id  And ListFactorBackBuy.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')) As BackKharid,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "')) AS AllKolCount) As KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id AND (D_date <=N'" & FarsiDate2.ThisText & "')) AS AllJozCount) AS JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) As AllKala) As Allinfo)As Sod "
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    Sod = "SELECT (SELECT (ISNULL(SUM(BedMon),0) -ISNULL(SUM(BesMon),0)) As BesMon  FROM (SELECT Mon As BedMon,BesMon=0.0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE (D_date  >=N'" & FarsiDate1.ThisText & "') UNION All SELECT Mon As BedMon,BesMon=0.0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END )    FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1  AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END )   FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 AND (D_date >=N'" & FarsiDate1.ThisText & "'))AS AllCharge ) As ListCharge,(SELECT ISNULL(SUM(Mon),0) As BB FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBuy WHERE Activ =1 AND (Stat =0 or Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorService WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "'))As ListA) As ListBB,(SELECT ISNULL(SUM(Mon),0) As AA FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =0 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =0 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListAA FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As AA FROM ListFactorBuy  WHERE Activ =1 AND (Stat =0 or Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd ),0) As AA FROM ListFactorService   WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "'))As ListA) As ListAA,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell .IdFactor = ListFactorSell .IdFactor WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorSell WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy  ON KalaFactorBackBuy .IdFactor = ListFactorBackBuy .IdFactor WHERE  ListFactorBackBuy .Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorBackBuy WHERE  ListFactorBackBuy .Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =0 AND Active =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE  ListFactorService.Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorService WHERE  ListFactorService.Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "')) As DiscountF) As DiscountFrosh,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorBuy WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell .Activ =1  AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorBackSell WHERE ListFactorBackSell .Activ =1  AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =1 AND Active =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorCharge WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListOtherCharge  WHERE Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "') ) As DiscountK) As DiscountKharid,(SELECT ISNULL(SUM(Daramad),0) As Daramad FROM (SELECT  ISNULL(SUM(Cash+ MonHavaleh+ MonPayChk+ Lend),0) As Daramad FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id WHERE (D_date >=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT ISNULL(SUM(KalaFactorService.Mon),0) Daramad FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1 AND (D_date >=N'" & FarsiDate1.ThisText & "')) As Daramad ) AS Daramad,SUM(OneKala) As OneKala ,SUM(Kharid) As Kharid ,SUM(Frosh) As Frosh ,SUM(Damage) As Damage ,SUM(BackFrosh) As BackFrosh ,SUM(BackKharid) As BackKharid ,SUM(EndKala) As EndKala ,SUM((Frosh-BackFrosh)-(((Kharid +OneKala)-BackKharid )-EndKala )) As SodKala FROM (SELECT Id ,OneKala  ,Kharid ,Frosh ,Damage ,BackFrosh ,BackKharid,EndKala=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(ROUND(KolCount,2) * dbo.GetCost(id,ROUND(KolCount,2),'KOL','','','False'),0) ELSE ROUND(ROUND(JozCount,2) * dbo.GetCost(id,ROUND(JozCount,2),'JOZ','','','False'),0) END FROM (SELECT Id,(SELECT (EndKala +EndKala2 ) FROM (SELECT Id,EndKala=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(ROUND(KolCount,2) * dbo.GetCost(id,ROUND(KolCount,2),'KOL','" & FarsiDate1.ThisText & "','','False'),0) ELSE ROUND(ROUND(JozCount,2) * dbo.GetCost(id,ROUND(JozCount,2),'JOZ','" & FarsiDate1.ThisText & "','','False'),0) END,(SELECT  ISNULL(SUM(Mon),0) FROM  Define_PrimaryKala WHERE IdKala =Allinfo2.Id AND(D_date >=N'" & FarsiDate1.ThisText & "'))As EndKala2 FROM (SELECT Id,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala2.Id AND (D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')) AS AllKolCount) As KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala2.Id AND (D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala2.Id AND(D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala2.Id AND (D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala2.Id AND (D_date <N'" & FarsiDate1.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala2.Id AND (D_date <N'" & FarsiDate1.ThisText & "')) AS AllJozCount) AS JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) As AllKala2) As Allinfo2) As Allinfo3 WHERE Id=AllKala .Id ) As OneKala,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE KalaFactorBuy.IdKala =AllKala .Id AND  ListFactorBuy.Stat =0 and ListFactorBuy.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "')) As Kharid,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE KalaFactorSell.IdKala =AllKala .Id AND  ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "')) As Frosh,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorDamage  INNER JOIN ListFactorDamage  ON KalaFactorDamage .IdFactor = ListFactorDamage .IdFactor WHERE KalaFactorDamage .IdKala =AllKala .Id  and ListFactorDamage .Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "')) As Damage,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackSell   INNER JOIN ListFactorBackSell  ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE KalaFactorBackSell.IdKala =AllKala .Id AND  ListFactorBackSell.Stat =4 and ListFactorBackSell.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "')) As BackFrosh,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE KalaFactorBackBuy.IdKala =AllKala .Id  And ListFactorBackBuy.Activ =1 AND(D_date >=N'" & FarsiDate1.ThisText & "')) As BackKharid,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id ) AS AllKolCount) As KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id  UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id ) AS AllJozCount) AS JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) As AllKala) As Allinfo)As Sod "
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    Sod = "SELECT (SELECT (ISNULL(SUM(BedMon),0) -ISNULL(SUM(BesMon),0)) As BesMon  FROM (SELECT Mon As BedMon,BesMon=0.0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE (D_date  <=N'" & FarsiDate2.ThisText & "') UNION All SELECT Mon As BedMon,BesMon=0.0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id  WHERE (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END )    FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1  AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END )   FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 AND (D_date <=N'" & FarsiDate2.ThisText & "'))AS AllCharge )As ListCharge,(SELECT ISNULL(SUM(Mon),0) As BB FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBuy WHERE Activ =1 AND (Stat =0 or Stat =2) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorService WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "'))As ListA) As ListBB,(SELECT ISNULL(SUM(Mon),0) As AA FROM (SELECT ISNULL(SUM(Mon),0) AS Mon FROM Sanad_AddDecBox WHERE Flag =0 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Mon),0) As Mon FROM Sanad_AddDecBank WHERE Flag =0 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListAA FROM ListFactorSell WHERE Activ =1 AND (Stat =3 or Stat =5) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As AA FROM ListFactorBuy  WHERE Activ =1 AND (Stat =0 or Stat =2) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd ),0) As AA FROM ListFactorService   WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorBackSell WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBackBuy WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "'))As ListA) As ListAA,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell .IdFactor = ListFactorSell .IdFactor WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorSell WHERE  ListFactorSell .Activ =1 AND (ListFactorSell .Stat =3 OR ListFactorSell .Stat =5) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy  ON KalaFactorBackBuy .IdFactor = ListFactorBackBuy .IdFactor WHERE  ListFactorBackBuy .Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorBackBuy WHERE  ListFactorBackBuy .Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =0 AND Active =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE  ListFactorService.Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorService WHERE  ListFactorService.Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "')) As DiscountF) As DiscountFrosh,(SELECT SUM(Discount) FROM (SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorBuy WHERE  ListFactorBuy.Activ =1 AND (ListFactorBuy.Stat =0 OR ListFactorBuy.Stat =2) AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(DarsadMon),0) As Discount FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell .Activ =1  AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorBackSell WHERE ListFactorBackSell .Activ =1  AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT  ISNULL(SUM(Discount),0) AS Discount FROM  Get_Pay_Sanad WHERE [State] =1 AND Active =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListFactorCharge WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(Discount),0) As Discount FROM ListOtherCharge  WHERE Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "') ) As DiscountK) As DiscountKharid,(SELECT ISNULL(SUM(Daramad),0) As Daramad FROM (SELECT  ISNULL(SUM(Cash+ MonHavaleh+ MonPayChk+ Lend),0) As Daramad FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID INNER JOIN Define_OneDaramad ON Define_Daramad.IdOne = Define_OneDaramad.Id WHERE (D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT ISNULL(SUM(KalaFactorService.Mon),0) Daramad FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1 AND (D_date <=N'" & FarsiDate2.ThisText & "')) As Daramad ) AS Daramad,SUM(OneKala) As OneKala ,SUM(Kharid) As Kharid ,SUM(Frosh) As Frosh ,SUM(Damage) As Damage ,SUM(BackFrosh) As BackFrosh ,SUM(BackKharid) As BackKharid ,SUM(EndKala) As EndKala ,SUM((Frosh-BackFrosh)-(((Kharid +OneKala)-BackKharid )-EndKala )) As SodKala FROM (SELECT Id ,OneKala  ,Kharid ,Frosh ,Damage ,BackFrosh ,BackKharid,EndKala=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(ROUND(KolCount,2) * dbo.GetCost(id,ROUND(KolCount,2),'KOL','','" & FarsiDate2.ThisText & "','False'),0) ELSE ROUND(ROUND(JozCount,2) * dbo.GetCost(id,ROUND(JozCount,2),'JOZ','','" & FarsiDate2.ThisText & "','False'),0) END FROM (SELECT Id,(SELECT  ISNULL(SUM(Mon),0) FROM  Define_PrimaryKala WHERE IdKala =AllKala .Id AND(D_date <=N'" & FarsiDate2.ThisText & "')) As OneKala,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE KalaFactorBuy.IdKala =AllKala .Id AND  ListFactorBuy.Stat =0 and ListFactorBuy.Activ =1 AND(D_date <=N'" & FarsiDate2.ThisText & "')) As Kharid,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "- DarsadMon)") & ",0) FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE KalaFactorSell.IdKala =AllKala .Id AND  ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND(D_date <=N'" & FarsiDate2.ThisText & "')) As Frosh,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorDamage  INNER JOIN ListFactorDamage  ON KalaFactorDamage .IdFactor = ListFactorDamage .IdFactor WHERE KalaFactorDamage .IdKala =AllKala .Id  and ListFactorDamage .Activ =1 AND(D_date <=N'" & FarsiDate2.ThisText & "')) As Damage,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackSell   INNER JOIN ListFactorBackSell  ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE KalaFactorBackSell.IdKala =AllKala .Id AND  ListFactorBackSell.Stat =4 and ListFactorBackSell.Activ =1 AND(D_date <=N'" & FarsiDate2.ThisText & "')) As BackFrosh,(SELECT  ISNULL(SUM(Mon" & If(ChkDiscount.Checked = False, ")", "+ DarsadMon)") & ",0) FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE KalaFactorBackBuy.IdKala =AllKala .Id  And ListFactorBackBuy.Activ =1 AND(D_date <=N'" & FarsiDate2.ThisText & "')) As BackKharid,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "')) AS AllKolCount) As KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id AND( D_date <=N'" & FarsiDate2.ThisText & "')) AS AllJozCount) AS JozCount FROM (SELECT Define_Kala.Id FROM Define_Kala ) As AllKala) As Allinfo)As Sod "
                End If
            End If
        Else
            Sod = "SELECT OneKala=0,Damage,Kharid,Frosh,BackFrosh,BackKharid,EndKala,((Frosh-BackFrosh)-(((Kharid)-BackKharid)-EndKala)) As SodKala,Daramad,DiscountKharid,DiscountFrosh,ListAA ,ListBB,ListCharge FROM (SELECT ISNULL(SUM(KalaFactorDamage.Mon),0) As Damage FROM  KalaFactorDamage  INNER JOIN ListFactorDamage  ON KalaFactorDamage .IdFactor = ListFactorDamage .IdFactor WHERE ListFactorDamage .Activ =1 AND ListFactorDamage .Part =" & TxtIdPart.Text & ") As Damage,(SELECT ISNULL(SUM(KalaFactorBuy.Mon),0) As Kharid FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Part =" & TxtIdPart.Text & ") As Kharid,(SELECT ISNULL(SUM(KalaFactorSell.Mon),0) As Frosh FROM  KalaFactorSell   INNER JOIN ListFactorSell  ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Part =" & TxtIdPart.Text & ") As Frosh,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon),0) As BackFrosh FROM  KalaFactorBackSell   INNER JOIN ListFactorBackSell  ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.Part =" & TxtIdPart.Text & ") As BackFrosh,(SELECT ISNULL(SUM(KalaFactorBackBuy.Mon),0) As BackKharid FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE ListFactorBackBuy.Activ =1 AND ListFactorBackBuy.Part =" & TxtIdPart.Text & ") As BackKharid,(SELECT ISNULL (SUM(Mon),0) As Endkala FROM (SELECT Mon=Case WHEN JozCount >0 THEN JozCount * Fe ELSE KolCount *Fe END FROM(SELECT Fe,(SELECT ISNULL(SUM(Kolcount),0) As KolCount FROM (SELECT ISNULL(SUM(KalaFactorBuy.KolCount),0) As KolCount FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 AND ListFactorBuy.Part =" & TxtIdPart.Text & " AND KalaFactorBuy.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorBackSell.KolCount),0) As KolCount FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell.Activ =1  AND ListFactorBackSell.Part =" & TxtIdPart.Text & " AND KalaFactorBackSell.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorSell.KolCount),0) * (-1) As KolCount FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE  ListFactorSell.Activ =1  AND ListFactorSell.Part =" & TxtIdPart.Text & " AND ListFactorSell.Stat =3 AND KalaFactorSell.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorBackBuy.KolCount),0) * (-1) As KolCount FROM KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE  ListFactorBackBuy.Activ =1  AND ListFactorBackBuy.Part =" & TxtIdPart.Text & " AND KalaFactorBackBuy.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorDamage.KolCount),0) * (-1) As KolCount FROM KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE  ListFactorDamage.Activ =1  AND ListFactorDamage.Part =" & TxtIdPart.Text & " AND KalaFactorDamage.IdKala =ListPart.IdKala) As EndKol) As KolCount,(SELECT ISNULL(SUM(JozCount),0) As JozCount FROM (SELECT ISNULL(SUM(KalaFactorBuy.JozCount),0) As JozCount FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 AND ListFactorBuy.Part =" & TxtIdPart.Text & " AND KalaFactorBuy.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorBackSell.JozCount),0) As JozCount FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell.Activ =1  AND ListFactorBackSell.Part =" & TxtIdPart.Text & " AND KalaFactorBackSell.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorSell.JozCount),0) * (-1) As JozCount FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE  ListFactorSell.Activ =1  AND ListFactorSell.Part =" & TxtIdPart.Text & " AND ListFactorSell.Stat =3 AND KalaFactorSell.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorBackBuy.JozCount),0) * (-1) As JozCount FROM KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE  ListFactorBackBuy.Activ =1  AND ListFactorBackBuy.Part =" & TxtIdPart.Text & " AND KalaFactorBackBuy.IdKala =ListPart.IdKala UNION ALL SELECT ISNULL(SUM(KalaFactorDamage.JozCount),0) * (-1) As JozCount FROM KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE  ListFactorDamage.Activ =1  AND ListFactorDamage.Part =" & TxtIdPart.Text & " AND KalaFactorDamage.IdKala =ListPart.IdKala) As EndJoz) As JozCount FROM (SELECT IdKala,ISNULL(SUM(Fe),0) As Fe FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 AND ListFactorBuy.Part =" & TxtIdPart.Text & " Group By IdKala) As ListPart) AS EndList) As EndMon) As Endkala,(SELECT ISNULL(SUM(KalaFactorService.Mon),0) As Daramad FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1 AND ListFactorService.Part =" & TxtIdPart.Text & ") As Daramad,(SELECT ISNULL(SUM(DiscountKharid),0) As DiscountKharid FROM (SELECT  ISNULL(SUM(KalaFactorBuy.DarsadMon ),0) As DiscountKharid FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 AND ListFactorBuy.Part =" & TxtIdPart.Text & " UNION ALL SELECT  ISNULL(SUM(ListFactorBuy .Discount  ),0) As DiscountKharid FROM  listFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 AND ListFactorBuy.Part =" & TxtIdPart.Text & " UNION ALL SELECT  ISNULL(SUM(Discount),0)/(SELECT CASE COUNT(IdSanad) WHEN 0 THEN 1 ELSE COUNT(IdSanad) END   FROM PayLimitKharid WHERE IdFactor IN(SELECT Idfactor FROM ListFactorBuy WHERE Part=" & TxtIdPart.Text & " AND Stat =0 AND Activ =1)) As DiscountKharid FROM  Get_Pay_Sanad WHERE Active =1 AND Discount >0 AND [State] =1 AND Id IN(SELECT IdSanad  FROM PayLimitKharid WHERE IdFactor IN(SELECT Idfactor FROM ListFactorBuy WHERE Part=" & TxtIdPart.Text & " AND Stat =0 AND Activ =1)) UNION ALL SELECT  ISNULL(SUM(Discount),0) AS DiscountKharid FROM  ListFactorCharge WHERE Activ =1 AND Discount >0 ANd IdFactor IN (SELECT Idfactor FROM ListFactorBuy WHERE Part=" & TxtIdPart.Text & " AND Stat =0 AND Activ =1)) AS AllDiscountKharid)As EndDiscountKharid,(SELECT ISNULL(SUM(DiscountFrosh),0) As DiscountFrosh FROM (SELECT  ISNULL(SUM(KalaFactorSell.DarsadMon),0) As DiscountFrosh FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Part =" & TxtIdPart.Text & " AND ListFactorSell.Stat  =3 AND ListFactorSell.Activ =1 UNION ALL SELECT  ISNULL(SUM(ListFactorSell.Discount),0) As DiscountFrosh FROM  ListFactorSell  WHERE ListFactorSell.Activ =1 AND ListFactorSell.Part =" & TxtIdPart.Text & " AND ListFactorSell.Stat  =3 AND ListFactorSell.Activ =1 UNION ALL SELECT  ISNULL(SUM(Discount),0)/(SELECT CASE COUNT(IdSanad) WHEN 0 THEN 1 ELSE COUNT(IdSanad) END   FROM PayLimitFrosh WHERE IdFactor IN(SELECT Idfactor FROM ListFactorSell WHERE Part=" & TxtIdPart.Text & " AND Stat  =3 AND Activ =1)) As DiscountFrosh FROM  Get_Pay_Sanad WHERE Active =1 AND Discount >0 AND [State] =1 AND Id IN(SELECT IdSanad  FROM PayLimitFrosh WHERE IdFactor IN(SELECT Idfactor FROM ListFactorSell WHERE Part=" & TxtIdPart.Text & " AND Stat  =3 AND Activ =1)) UNION ALL SELECT  ISNULL(SUM(KalaFactorService.DarsadMon),0) As DiscountFrosh FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1 AND ListFactorService.Part =" & TxtIdPart.Text & " AND ListFactorService .Activ =1 UNION ALL SELECT  ISNULL(SUM(ListFactorService.Discount),0) As DiscountFrosh FROM  ListFactorService  WHERE ListFactorService.Activ =1 AND ListFactorService.Part =" & TxtIdPart.Text & " AND ListFactorService.Activ =1 ) AS AllDiscountFrosh)As EndDiscountFrosh,(SELECT ISNULL(SUM(ListAA),0) As ListAA FROM (SELECT  ISNULL(SUM(MonAdd),0) As ListAA FROM ListFactorSell WHERE Activ =1 AND Stat =3 and Part=" & TxtIdPart.Text & " UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListAA FROM ListFactorBuy  WHERE Activ =1 AND Stat =0 and Part=" & TxtIdPart.Text & " UNION ALL SELECT  ISNULL(SUM(MonAdd ),0) As ListAA FROM ListFactorService   WHERE Activ =1  and Part=" & TxtIdPart.Text & ") As listAddMon)As EndlistAddMon,(SELECT ISNULL(SUM(ListBB),0) As ListBB FROM (SELECT  ISNULL(SUM(MonAdd),0) As ListBB FROM ListFactorBuy WHERE Activ =1 AND Stat =0 and Part=" & TxtIdPart.Text & " UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorSell  WHERE Activ =1 AND Stat =3 and Part=" & TxtIdPart.Text & " UNION ALL SELECT  ISNULL(SUM(MonDec),0) As ListBB FROM ListFactorService   WHERE Activ =1  and Part=" & TxtIdPart.Text & ") As listDecMon) AS EndlistDecMon,(SELECT ISNULL(SUM(KalaFactorCharge.Mon),0) As ListCharge FROM ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE ListFactorCharge .IdFactor IN (SELECT IdFactor FROM ListFactorBuy  WHERE Activ =1 AND Stat =0 and Part=" & TxtIdPart.Text & ")) As EndListCharge"
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود و زیان خالص", "سود و زیان", "", "")

        Me.Sod(Sod)
        Me.Calculate()
        Me.Enabled = True
        Button1.Enabled = True
    End Sub
    Private Sub Sod(ByVal Sod As String)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand(Sod, ConectionBank)
                CMD.CommandTimeout = 0
                dtr = CMD.ExecuteReader()
            End Using
            If dtr.HasRows Then
                dtr.Read()
                TxtPM.Text = If(dtr("OneKala") Is DBNull.Value, 0, dtr("OneKala"))
                TxtZ.Text = If(dtr("Damage") Is DBNull.Value, 0, dtr("Damage"))
                TxtKHM.Text = If(dtr("Kharid") Is DBNull.Value, 0, dtr("Kharid"))
                TxtFM.Text = If(dtr("Frosh") Is DBNull.Value, 0, dtr("Frosh"))
                TxtBFM.Text = If(dtr("BackFrosh") Is DBNull.Value, 0, dtr("BackFrosh"))
                TxtBBM.Text = If(dtr("BackKharid") Is DBNull.Value, 0, dtr("BackKharid"))
                TxtEnd.Text = If(dtr("EndKala") Is DBNull.Value, 0, dtr("EndKala"))
                TxtNsod.Text = If(dtr("SodKala") Is DBNull.Value, 0, dtr("SodKala"))
                Txtdramad.Text = If(dtr("Daramad") Is DBNull.Value, 0, dtr("Daramad"))
                TxtHDaramad.Text = If(dtr("DiscountKharid") Is DBNull.Value, 0, dtr("DiscountKharid"))
                TxtHFac.Text = If(dtr("DiscountFrosh") Is DBNull.Value, 0, dtr("DiscountFrosh"))
                Txtadd.Text = If(dtr("ListAA") Is DBNull.Value, 0, dtr("ListAA"))
                Txtdec.Text = If(dtr("ListBB") Is DBNull.Value, 0, dtr("ListBB"))
                TxtH.Text = If(dtr("ListCharge") Is DBNull.Value, 0, dtr("ListCharge"))
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportsodKha", "Sod")
        End Try
    End Sub

    Private Sub TxtHDaramad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHDaramad.TextChanged
        If Not (CheckDigit(TxtHDaramad.Text.Replace(",", ""))) Then
            TxtHDaramad.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtHDaramad.Text.Length > 3 Then
            str = Format$(TxtHDaramad.Text.Replace(",", ""))
            TxtHDaramad.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtHFac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHFac.TextChanged
        If Not (CheckDigit(TxtHFac.Text.Replace(",", ""))) Then
            TxtHFac.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtHFac.Text.Length > 3 Then
            str = Format$(TxtHFac.Text.Replace(",", ""))
            TxtHFac.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Enabled = False
        Using FrmPrint As New FrmPrint
            FrmPrint.Num1 = CDbl(Txttraz.Text)
            FrmPrint.Num2 = CDbl(Txtdec.Text)
            FrmPrint.Num3 = CDbl(Txtadd.Text)
            FrmPrint.Num4 = CDbl(TxtHFac.Text)
            FrmPrint.Num5 = CDbl(TxtHDaramad.Text)
            FrmPrint.Num6 = CDbl(TxtH.Text)
            FrmPrint.Num7 = CDbl(Txtdramad.Text)
            FrmPrint.Num8 = CDbl(TxtNsod.Text)
            FrmPrint.Num9 = CDbl(TxtEnd.Text)
            FrmPrint.Num10 = CDbl(TxtBBM.Text)
            FrmPrint.Num11 = CDbl(TxtBFM.Text)
            FrmPrint.Num12 = CDbl(TxtFM.Text)
            FrmPrint.Num13 = CDbl(TxtKHM.Text)
            FrmPrint.Num14 = CDbl(TxtZ.Text)
            FrmPrint.Num15 = CDbl(TxtPM.Text)

            Tmp_String1 = ""
            If ChkTime.Checked = True Then
                Tmp_String1 = If(ChkAzDate.Checked = True, "از تاریخ: " & FarsiDate1.ThisText, "")
                Tmp_String1 &= If(ChkTaDate.Checked = True, "     تا تاریخ: " & FarsiDate2.ThisText, "")
            End If

            If ChkPart.Checked = True Then
                Tmp_String1 &= If(ChkTime.Checked = False, "پارت:  " & TxtPart.Text, "         پارت:  " & TxtPart.Text)
            End If


            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود و زیان خالص", "چاپ گزارش", "", "")
            FrmPrint.CHoose = "SODKHALES"
            FrmPrint.ShowDialog()
        End Using
        Me.Enabled = True
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            ChkTime.Checked = False
            TxtPart.Enabled = True
            TxtPart.Focus()
        Else
            TxtPart.Enabled = False
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
        Button1.Enabled = False
    End Sub

    Private Sub TxtPart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPart.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Part_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtPart.Focus()
        If Tmp_Namkala <> "" Then
            TxtPart.Text = Tmp_Namkala
            TxtIdPart.Text = IdKala
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

    Private Sub TxtPart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPart.TextChanged
        Button1.Enabled = False
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        Button1.Enabled = False
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        Button1.Enabled = False
    End Sub
End Class