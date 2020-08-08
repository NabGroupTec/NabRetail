Imports System.Data.SqlClient

Public Class FrmReportInfoExit

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
            ChkExit.Checked = False
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

    Private Sub ChkExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkExit.CheckedChanged
        If ChkExit.Checked = True Then
            TxtExit.Enabled = True
            ChkTime.Checked = False
            ChkPart.Checked = False
            ChkVisitor.Checked = False
            ChkCar.Checked = False
            ChkReciver.Checked = False
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

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            ChkExit.Checked = False
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportInfoExit", "Get_Ostan")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportInfoExit", "Get_City")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportInfoExit", "Get_Part")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstan.KeyDown
        If CmbOstan.DroppedDown = False Then
            CmbOstan.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            If ChkCity.Checked = True Then
                CmbCity.Focus()
            Else
                BtnReport.Focus()
            End If
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
            If ChkP.Checked = True Then
                CmbPart.Focus()
            Else
                BtnReport.Focus()
            End If
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

    Private Sub ChkVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisitor.CheckedChanged
        If ChkVisitor.Checked = True Then
            ChkExit.Checked = False
            TxtVisitor.Enabled = True
            TxtVisitor.Focus()
        Else
            TxtVisitor.Enabled = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
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
            TxtCar.Enabled = True
            TxtCar.Focus()
        Else
            TxtCar.Enabled = False
            TxtCar.Text = ""
            TxtIdCar.Text = ""
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

    Private Sub ChkReciver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkReciver.CheckedChanged
        If ChkReciver.Checked = True Then
            ChkExit.Checked = False
            TxtReciver.Enabled = True
            TxtReciver.Focus()
        Else
            TxtReciver.Enabled = False
            TxtReciver.Text = ""
            TxtIdRecevier.Text = ""
        End If
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try
            If ChkExit.Checked = True Then
                If String.IsNullOrEmpty(TxtExit.Text) Then
                    MessageBox.Show("هیچ خروجی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtExit.Focus()
                    Exit Sub
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

            Dim StrExit As String = ""
            If ChkExit.Checked = True Then
                StrExit = " AND ExitFactor.Id=" & TxtExit.Text
            End If

            Dim Dat As String = ""
            Tmp_String1 = ""
            Tmp_String2 = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    Dat = " AND ( ExitFactor.D_date >=N'" & FarsiDate1.ThisText & "' AND ExitFactor.D_date <=N'" & FarsiDate2.ThisText & "')"
                    Tmp_String1 = FarsiDate1.ThisText
                    Tmp_String2 = FarsiDate2.ThisText
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    Dat = " AND ( ExitFactor.D_date >=N'" & FarsiDate1.ThisText & "')"
                    Tmp_String1 = FarsiDate1.ThisText
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    Dat = " AND ( ExitFactor.D_date <=N'" & FarsiDate2.ThisText & "')"
                    Tmp_String2 = FarsiDate2.ThisText
                End If
            End If

            Tmp_Namkala = ""
            Dim Part As String = ""
            If ChkPart.Checked = True Then
                Part = " IdOstan=" & CmbOstan.SelectedValue
                Tmp_Namkala = CmbOstan.Text
                Part &= If(ChkCity.Checked = True, " AND IdCity=" & CmbCity.SelectedValue, "")
                Part &= If(ChkP.Checked = True, " AND IdPart=" & CmbPart.SelectedValue, "")
                Part = " AND (" & Part & ")"
                Tmp_Namkala &= If(ChkCity.Checked = True, "،" & CmbCity.Text, "")
                Tmp_Namkala &= If(ChkP.Checked = True, "،" & CmbPart.Text, "")
            End If

            Dim StrVisit As String = ""
            Tmp_OneGroup = ""
            If ChkVisitor.Checked = True Then
                StrVisit = " AND IdVisitor=" & TxtIdVisitor.Text
                Tmp_OneGroup = TxtVisitor.Text
            End If

            Dim StrCar As String = ""
            Tmp_TwoGroup = ""
            If ChkCar.Checked = True Then
                StrCar = " AND IdCar=" & TxtIdCar.Text
                Tmp_TwoGroup = TxtCar.Text
            End If

            Dim StrReciver As String = ""
            TmpAddress = ""
            If ChkReciver.Checked = True Then
                StrReciver = " AND IdRecive=" & TxtIdRecevier.Text
                TmpAddress = TxtReciver.Text
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری خروجی", "تهيه گزارش", "", "")

            Using FrmP As New FrmPrint
                'FrmP.PrintSQl = "SELECT ExitId,D_date,WFactor,REPLACE(WFactor,'.','/') As SWFactor,AllMon,Pay,Kasri,Backkala,Discount,REPLACE(ROUND(CAST(Discount AS Float)*100/AllMon,2),'.','/') As SD_Discount,Cash,REPLACE(ROUND(CAST(Cash AS Float)*100/AllMon,2),'.','/') As SD_Cash,Chk,REPLACE(ROUND(CAST(Chk AS Float)*100/AllMon,2),'.','/') As SD_Chk,(AllMon -Pay) As Lend,REPLACE(ROUND(CAST((AllMon -Pay) AS Float)*100/AllMon,2),'.','/') As SD_Lend,IdFactor,CountKala FROM (SELECT ExitId ,D_date ,SUM(WFactor) As WFactor,SUM (AllMon) As AllMon,SUM (Pay ) As Pay,SUM (Kasri ) As Kasri,SUM (Backkala) As Backkala,SUM (Discount) As Discount,SUM (Cash) As Cash,SUM (Chk ) As Chk,COUNT (IdFactor) As IdFactor ,SUM (C_Fac ) As CountKala FROM (SELECT IdFactor ,ExitId ,D_date,(SELECT SUM(ROUND(ISNULL((WK_JOZ * Joz),0),2)) AS WFactor FROM (SELECT ROUND(ISNULL(SUM(JozCount),0),2) AS Joz,IdKala FROM  KalaFactorSell WHERE (IdFactor=ListExit.IdFactor)  GROUP BY IdKala)  AS ListKala INNER JOIN Define_Kala ON Define_Kala.Id =ListKala.IdKala ) AS WFactor,(SELECT ISNULL(SUM(KalaFactorSell.Mon),0) As Mon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdFactor =ListExit.IdFactor )As AllMon,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor ) + (SELECT ISNULL(SUM(Cash+MonHavaleh +MonPayChk+Discount +MonDec -MonAdd ),0) FROM ListFactorSell WHERE IdFactor= ListExit.IdFactor)+(SELECT ISNULL(SUM(DarsadMon),0)  FROM KalaFactorSell WHERE IdFactor =ListExit.IdFactor) As Pay,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =ListExit.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =ListExit.IdFactor)As Backkala,(SELECT (ISNULL(SUM(DarsadMon),0)+ISNULL(SUM(Discount),0) +ISNULL(SUM(MonDec),0)+(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) -ISNULL(SUM(MonAdd),0))  FROM KalaFactorSell INNER JOIN ListFactorSell ON ListFactorSell.IdFactor =KalaFactorSell.IdFactor  WHERE ListFactorSell.IdFactor =ListExit.IdFactor) As Discount,(SELECT ISNULL(SUM((Cash +MonHavaleh)),0) + (SELECT ISNULL((Cash+MonHavaleh),0) FROM ListFactorSell WHERE IdFactor= ListExit.IdFactor) As Cash FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As Cash,(SELECT ISNULL(SUM(MonPayChk),0)+ (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor= ListExit.IdFactor) As Chk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As Chk ,(SELECT COUNT(DISTINCT KalaFactorSell.IdKala) FROM KalaFactorSell WHERE IdFactor =ListExit.IdFactor) As C_Fac FROM (SELECT  DISTINCT   ListExitFactor.IdFactor, ExitFactor.Id As ExitId, ExitFactor.D_date, ListFactorSell.IdVisitor, Define_People.IdOstan, Define_People.IdCity,Define_People.IdPart FROM ListExitFactor INNER JOIN ExitFactor ON ListExitFactor.IdList = ExitFactor.Id INNER JOIN ListFactorSell ON ListExitFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) " & StrExit & Dat & Part & StrVisit & StrCar & StrReciver & ") As ListExit) As AllExit GROUP By ExitId ,D_date) As EndExit ORDER By ExitId"
                FrmP.PrintSQl = "SELECT ExitId,D_date,WFactor,REPLACE(WFactor,'.','/') As SWFactor,AllMon,Pay,Kasri,Backkala,Discount,REPLACE(ROUND(CAST(Discount AS Float)*100/AllMon,2),'.','/') As SD_Discount,Cash,REPLACE(ROUND(CAST(Cash AS Float)*100/AllMon,2),'.','/') As SD_Cash,Chk,REPLACE(ROUND(CAST(Chk AS Float)*100/AllMon,2),'.','/') As SD_Chk,(AllMon -Pay) As Lend,REPLACE(ROUND(CAST((AllMon -Pay) AS Float)*100/AllMon,2),'.','/') As SD_Lend,IdFactor,CountKala FROM (SELECT ExitId ,D_date ,SUM(WFactor) As WFactor,SUM (AllMon) As AllMon,SUM (Pay ) As Pay,SUM (Kasri ) As Kasri,SUM (Backkala) As Backkala,SUM (Discount) As Discount,SUM (Cash) As Cash,SUM (Chk ) As Chk,COUNT (IdFactor) As IdFactor ,SUM (C_Fac ) As CountKala FROM (SELECT IdFactor ,ExitId ,D_date,(SELECT SUM(ROUND(ISNULL((WK_JOZ * Joz),0),2)) AS WFactor FROM (SELECT ROUND(ISNULL(SUM(JozCount),0),2) AS Joz,IdKala FROM  KalaFactorSell WHERE (IdFactor=ListExit.IdFactor)  GROUP BY IdKala)  AS ListKala INNER JOIN Define_Kala ON Define_Kala.Id =ListKala.IdKala ) AS WFactor,(SELECT ISNULL(SUM(KalaFactorSell.Mon),0) As Mon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdFactor =ListExit.IdFactor )As AllMon,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor ) + (SELECT ISNULL(SUM(Cash+MonHavaleh +MonPayChk+Discount +MonDec -MonAdd ),0) FROM ListFactorSell WHERE IdFactor= ListExit.IdFactor)+(SELECT ISNULL(SUM(DarsadMon),0)  FROM KalaFactorSell WHERE IdFactor =ListExit.IdFactor) As Pay,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) As Kasri FROM KalaKasriFactor WHERE IdFactor =ListExit.IdFactor)As Kasri,(SELECT ISNULL(SUM(KalaFactorBackSell.Mon),0) As Backkala FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON ListFactorBackSell.IdFactor =KalaFactorBackSell.IdFactor  WHERE ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdFacSell =ListExit.IdFactor)As Backkala,(SELECT  CASE WHEN SUM(Discount)>0 THEN (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=ListExit.IdFactor)+ CASE WHEN SUM(Discount)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) WHEN SUM(Discount)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Discount)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Discount) ELSE 0 END ELSE (SELECT ISNULL((Discount),0) FROM ListFactorSell WHERE IdFactor=ListExit.IdFactor) END FROM (SELECT Id,Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =ListExit.IdName AND Get_Pay_Sanad.Discount >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Discount,(SELECT  CASE WHEN SUM(Cash +MonHavaleh)>0 THEN (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=ListExit.IdFactor) + CASE WHEN SUM(Cash +MonHavaleh)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) WHEN SUM(Cash +MonHavaleh)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(Cash +MonHavaleh)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(Cash +MonHavaleh) ELSE 0 END ELSE (SELECT ISNULL((Cash +MonHavaleh),0) FROM ListFactorSell WHERE IdFactor=ListExit.IdFactor) END FROM (SELECT Id,Cash ,MonHavaleh FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =ListExit.IdName AND (Cash>0 OR MonHavaleh>0)) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Cash,(SELECT  CASE WHEN SUM(MonPayChk)>0 THEN (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=ListExit.IdFactor) + CASE WHEN SUM(MonPayChk)=(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) WHEN SUM(MonPayChk)>(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN (SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) WHEN SUM(MonPayChk)<(SELECT ISNULL(SUM(Pay),0) FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor  AND IdSanad =MAX(ListGet.Id)) THEN SUM(MonPayChk) ELSE 0 END ELSE (SELECT ISNULL((MonPayChk),0) FROM ListFactorSell WHERE IdFactor=ListExit.IdFactor) END FROM (SELECT Id,MonPayChk FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Get_Pay_Sanad.Idname =ListExit.IdName AND MonPayChk >0) AS ListGet WHERE Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListExit.IdFactor) GROUP BY IdSanad) As ListSanad WHERE (C_Count=1) OR (SELECT (Discount+Cash+MonHavaleh+MonPayChk+MonSellChk) AS Kind FROM (SELECT  Discount=CASE WHEN Discount>0 THEN 1 ELSE 0 END,Cash=CASE WHEN Cash>0 THEN 1 ELSE 0 END,MonHavaleh=CASE WHEN MonHavaleh>0 THEN 1 ELSE 0 END,MonPayChk=CASE WHEN MonPayChk>0 THEN 1 ELSE 0 END ,MonSellChk=CASE WHEN MonSellChk>0 THEN 1 ELSE 0 END FROM Get_Pay_Sanad WHERE Id=ListGet.Id) AS ChkList)=1))As Chk,(SELECT COUNT(DISTINCT KalaFactorSell.IdKala) FROM KalaFactorSell WHERE IdFactor =ListExit.IdFactor) As C_Fac FROM (SELECT  DISTINCT   ListExitFactor.IdFactor, ExitFactor.Id As ExitId, ExitFactor.D_date,ListFactorSell.IdName,ListFactorSell.IdVisitor, Define_People.IdOstan, Define_People.IdCity,Define_People.IdPart FROM ListExitFactor INNER JOIN ExitFactor ON ListExitFactor.IdList = ExitFactor.Id INNER JOIN ListFactorSell ON ListExitFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) " & StrExit & Dat & Part & StrVisit & StrCar & StrReciver & ") As ListExit) As AllExit GROUP By ExitId ,D_date) As EndExit ORDER By ExitId"
                FrmP.CHoose = "DELAYEXIT"
                FrmP.ShowDialog()
            End Using

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportInfoExit", "BtnReport_Click")
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepKhroji.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then BtnReport_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmReportInfoExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then
            If ChkTaDate.Checked = True Then
                FarsiDate2.Focus()
            Else
                BtnReport.Focus()
            End If
        End If
    End Sub

    Private Sub FarsiDate2_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate2.KeyDowned
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub FrmReportInfoExit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F127")
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
    End Sub
End Class