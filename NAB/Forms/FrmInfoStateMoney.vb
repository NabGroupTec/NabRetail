Imports System.Data.SqlClient
Public Class FrmInfoStateMoney
    Dim t As Long = 0
    Private Sub FrmInfoStateMoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "State_Mali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmInfoChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F93")
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
        ChkAz.Enabled = False
        ChkTa.Enabled = False
        Txt_Date1.Enabled = False
        Txt_Date1.ThisText = GetDate()
        Txt_Date.Enabled = False
        Txt_Date.ThisText = GetDate()
        ChkAz.Checked = False
        ChkTa.Checked = False
        Call Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAz.Checked = False And ChkTa.Checked = False Then
                    MessageBox.Show("محدوده تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    If Txt_Date.ThisText > Txt_Date1.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    condition = " AND (PayDate >=N'" & Txt_Date.ThisText & "' AND PayDate<=N'" & Txt_Date1.ThisText & "')"
                ElseIf ChkAz.Checked = True And ChkTa.Checked = False Then
                    condition = " AND (PayDate >=N'" & Txt_Date.ThisText & "')"
                ElseIf ChkAz.Checked = False And ChkTa.Checked = True Then
                    condition = " AND (PayDate <=N'" & Txt_Date1.ThisText & "')"
                Else
                    MessageBox.Show("شرط تاریخ نامشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            Me.Enabled = False
            Dim Tb As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using Cmd As New SqlCommand("SELECT CountGet,GetChk,CountPay,PayChk,MoeinBox,MoeinBank FROM (SELECT COUNT(*) As CountGet, ISNULL(SUM(MoneyChk),0) AS GetChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)" & condition & ") AS V1,(SELECT COUNT(*)As CountPay,ISNULL(SUM(MoneyChk),0) AS PayChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind) " & condition & ") AS V2,(SELECT (SUM(OnMoney+bed+bes))AS MoeinBox FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE  T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE  T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_box )As AllOneMoney )As One) AS V3,(SELECT (SUM(OnMoney+bed+bes))AS MoeinBank FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoneyBank .Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank)As AllOneMoneyBank )As One1) As V4", ConectionBank)
                Tb.Load(Cmd.ExecuteReader)
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Tb.Rows.Count > 0 Then
                TxtCountGet.Text = Tb.Rows(0).Item("CountGet")
                TxtCountPay.Text = Tb.Rows(0).Item("CountPay")
                TxtMonGet.Text = Tb.Rows(0).Item("GetChk")
                TxtMonPay.Text = Tb.Rows(0).Item("PayChk")
                TxtBox.Text = Tb.Rows(0).Item("MoeinBox")
                TxtBank.Text = Tb.Rows(0).Item("MoeinBank")
            Else
                TxtCountGet.Text = "0"
                TxtCountPay.Text = "0"
                TxtMonGet.Text = "0"
                TxtMonPay.Text = "0"
                TxtBox.Text = "0"
                TxtBank.Text = "0"
            End If

            TxtDelayGet.Text = Me.GetDelay()
            TxtDelayPay.Text = Me.PayDelay()

            If Chkdelay.Checked = False Then
                TxtDiff.Text = (CDbl(TxtMonGet.Text) + CDbl(TxtBox.Text) + CDbl(TxtBank.Text)) - CDbl(TxtMonPay.Text)
            Else
                TxtDiff.Text = (CDbl(TxtMonGet.Text) + CDbl(TxtBox.Text) + CDbl(TxtBank.Text) + CDbl(TxtDelayGet.Text)) - (CDbl(TxtMonPay.Text) + CDbl(TxtDelayPay.Text))
            End If

            If t = 0 Then TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اطلاع رسانی مالی", "تهیه گزارش", "", "")

            Me.Enabled = True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmInfoStateMoney", "Button2_Click")
            Me.Close()
        End Try
    End Sub

    Private Function GetDelay() As Double
        Try
            Dim TbGet As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using Cmd As New SqlCommand("SELECT d_date ,EndData.Rate,MaxNewDate,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,Rate,d_date,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor ) As AllTime) As EndData WHERE (MonFac -Pay )>0", ConectionBank)
                TbGet.Load(Cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Not TbGet.Columns.Contains("EndDate") Then TbGet.Columns.Add("EndDate", Type.GetType("System.String"))
            For i As Integer = 0 To TbGet.Rows.Count - 1
                TbGet.Rows(i).Item("EndDate") = CalDate(TbGet.Rows(i).Item("D_date"), TbGet.Rows(i).Item("Rate"), TbGet.Rows(i).Item("MaxNewDate"))
            Next

            Dim row() As DataRow = Nothing

            If ChkTime.Checked = True Then
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    row = TbGet.Select("EndDate>='" & Txt_Date.ThisText & "' AND EndDate<='" & Txt_Date1.ThisText & "'")
                ElseIf ChkAz.Checked = True And ChkTa.Checked = False Then
                    row = TbGet.Select("EndDate>='" & Txt_Date.ThisText & "'")
                ElseIf ChkAz.Checked = False And ChkTa.Checked = True Then
                    row = TbGet.Select("EndDate<='" & Txt_Date1.ThisText & "'")
                End If
            Else
                row = TbGet.Select("Remain>0")
            End If
            If row.Length > 0 Then
                Dim res As Double = 0
                For i As Integer = 0 To row.Length - 1
                    res += row(i).Item("Remain")
                Next
                Return res
            Else
                Return 0
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmInfoStateMoney", "GetDelay")
            Return 0
        End Try
    End Function

    Private Function PayDelay() As Double
        Try
            Dim TbGet As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using Cmd As New SqlCommand("SELECT  EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,Rate,d_date,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorBuy  WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorBuy  WHERE ListFactorBuy.IdFactor  =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitKharid WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitKharid  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk+MonSellChk),0)   FROM ListFactorBuy WHERE IdFactor= AllTime.IdFactor ) As Pay,(SELECT ISNULL(MAX(NewDate),'') FROM TimeKharid WHERE TimeKharid.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Kharid.IdFactor, Wanted_Kharid.Rate,d_date FROM  Wanted_Kharid INNER JOIN ListFactorBuy ON Wanted_Kharid.IdFactor = ListFactorBuy.IdFactor ) As AllTime) As EndData WHERE (MonFac -Pay )>0", ConectionBank)
                TbGet.Load(Cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Not TbGet.Columns.Contains("EndDate") Then TbGet.Columns.Add("EndDate", Type.GetType("System.String"))
            For i As Integer = 0 To TbGet.Rows.Count - 1
                TbGet.Rows(i).Item("EndDate") = CalDate(TbGet.Rows(i).Item("D_date"), TbGet.Rows(i).Item("Rate"), TbGet.Rows(i).Item("MaxNewDate"))
            Next

            Dim row() As DataRow = Nothing

            If ChkTime.Checked = True Then
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    row = TbGet.Select("EndDate>='" & Txt_Date.ThisText & "' AND EndDate<='" & Txt_Date1.ThisText & "'")
                ElseIf ChkAz.Checked = True And ChkTa.Checked = False Then
                    row = TbGet.Select("EndDate>='" & Txt_Date.ThisText & "'")
                ElseIf ChkAz.Checked = False And ChkTa.Checked = True Then
                    row = TbGet.Select("EndDate<='" & Txt_Date1.ThisText & "'")
                End If
            Else
                row = TbGet.Select("Remain>0")
            End If
            If row.Length > 0 Then
                Dim res As Double = 0
                For i As Integer = 0 To row.Length - 1
                    res += row(i).Item("Remain")
                Next
                Return res
            Else
                Return 0
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmInfoStateMoney", "PayDelay")
            Return 0
        End Try
    End Function

    Private Function CalDate(ByVal Dat As String, ByVal Count As Long, ByVal NewDat As String) As String
        Try
            For i As Integer = 1 To Count
                Dat = ADDDAY(Dat)
            Next
            If String.IsNullOrEmpty(NewDat) Then
                Return Dat
            Else
                If Dat >= NewDat Then
                    Return Dat
                Else
                    Return NewDat
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub TxtDiff_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiff.TextChanged
        If Not (CheckDigit(TxtDiff.Text.Replace(",", ""))) Then
            TxtDiff.Text = 0
            If CDbl(TxtDiff.Text.Trim) = 0 Then
                TxtDiff.BackColor = Color.Yellow
            ElseIf CDbl(TxtDiff.Text.Trim) > 0 Then
                TxtDiff.BackColor = Color.White
            ElseIf CDbl(TxtDiff.Text.Trim) < 0 Then
                TxtDiff.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        Dim str As String
        If TxtDiff.Text.Length > 3 Then
            str = Format$(TxtDiff.Text.Replace(",", ""))
            TxtDiff.Text = Format$(Val(str), "###,###,###")
        End If
        If CDbl(TxtDiff.Text.Trim) = 0 Then
            TxtDiff.BackColor = Color.Yellow
        ElseIf CDbl(TxtDiff.Text.Trim) > 0 Then
            TxtDiff.BackColor = Color.White
        ElseIf CDbl(TxtDiff.Text.Trim) < 0 Then
            TxtDiff.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtMonGet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonGet.TextChanged
        If Not (CheckDigit(TxtMonGet.Text.Replace(",", ""))) Then
            TxtMonGet.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtMonGet.Text.Length > 3 Then
            str = Format$(TxtMonGet.Text.Replace(",", ""))
            TxtMonGet.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtMonPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonPay.TextChanged
        If Not (CheckDigit(TxtMonPay.Text.Replace(",", ""))) Then
            TxtMonPay.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtMonPay.Text.Length > 3 Then
            str = Format$(TxtMonPay.Text.Replace(",", ""))
            TxtMonPay.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        t = 1
        Call Button2_Click(sender, e)
        t = 0
        If CLng(TxtCountGet.Text) <= 0 Then
            MessageBox.Show("هیچ چک دریافتی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اطلاع رسانی مالی", "لیست چک دریافتی", "", "")

        Using Frmlist As New ShowChk

            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAz.Checked = False And ChkTa.Checked = False Then
                    Exit Sub
                End If
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    If Txt_Date.ThisText > Txt_Date1.ThisText Then
                        Exit Sub
                    End If
                End If
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    condition = " AND (PayDate >=N'" & Txt_Date.ThisText & "' AND PayDate<=N'" & Txt_Date1.ThisText & "')"
                ElseIf ChkAz.Checked = True And ChkTa.Checked = False Then
                    condition = " AND (PayDate >=N'" & Txt_Date.ThisText & "')"
                ElseIf ChkAz.Checked = False And ChkTa.Checked = True Then
                    condition = " AND (PayDate <=N'" & Txt_Date1.ThisText & "')"
                Else
                    Exit Sub
                End If
            End If
            Me.Enabled = False
            Dim Tb As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Frmlist.StrSql = "SELECT id,[GetDate],PayDate ,MoneyChk,NumChk ,Disc, Stat=Case Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END ,Nam=Case  WHEN Current_Type=14 THEN N'اموال' WHEN Current_Type=15 THEN N'درآمد' WHEN Current_Type=16 THEN N'هزینه متفرقه' WHEN Current_Type=17 THEN N'هزینه ف.خرید' WHEN Current_Type=18 THEN N'صندوق' WHEN Current_Type=19 THEN N'امور چک' WHEN Current_Type=20 THEN N'بانک به بانک' WHEN Current_Type<=13 THEN (SELECT Nam FROM Define_People WHERE Id=(SELECT  Current_IdPeople  FROM Chk_Id WHERE Chk_Id.Id=Chk_Get_Pay.ID ) ) ELSE N'نا مشخص' END  FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)" & condition
            Frmlist.SumStrSql = "SELECT PayDate,COUNT(*) AS C_Count ,ISNULL(SUM(MoneyChk),0) As MoneyChk   FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)" & condition & " GROUP BY PayDate"
            Me.Enabled = False
            Frmlist.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        t = 1
        Call Button2_Click(sender, e)
        t = 0
        If CLng(TxtCountPay.Text) <= 0 Then
            MessageBox.Show("هیچ چک پرداختی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اطلاع رسانی مالی", "لیست چک پرداختی", "", "")

        Using Frmlist As New ShowChk

            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAz.Checked = False And ChkTa.Checked = False Then
                    Exit Sub
                End If
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    If Txt_Date.ThisText > Txt_Date1.ThisText Then
                        Exit Sub
                    End If
                End If
                If ChkAz.Checked = True And ChkTa.Checked = True Then
                    condition = " AND (PayDate >=N'" & Txt_Date.ThisText & "' AND PayDate<=N'" & Txt_Date1.ThisText & "')"
                ElseIf ChkAz.Checked = True And ChkTa.Checked = False Then
                    condition = " AND (PayDate >=N'" & Txt_Date.ThisText & "')"
                ElseIf ChkAz.Checked = False And ChkTa.Checked = True Then
                    condition = " AND (PayDate <=N'" & Txt_Date1.ThisText & "')"
                Else
                    Exit Sub
                End If
            End If
            Me.Enabled = False
            Dim Tb As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Frmlist.StrSql = "SELECT id,[GetDate],PayDate ,MoneyChk,NumChk ,Disc, Stat=Case Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END ,Nam=Case  WHEN Current_Type=14 THEN N'اموال' WHEN Current_Type=15 THEN N'درآمد' WHEN Current_Type=16 THEN N'هزینه متفرقه' WHEN Current_Type=17 THEN N'هزینه ف.خرید' WHEN Current_Type=18 THEN N'صندوق' WHEN Current_Type=19 THEN N'امور چک' WHEN Current_Type=20 THEN N'بانک به بانک' WHEN Current_Type<=13 THEN (SELECT Nam FROM Define_People WHERE Id=(SELECT  Current_IdPeople  FROM Chk_Id WHERE Chk_Id.Id=Chk_Get_Pay.ID ) ) ELSE N'نا مشخص' END  FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind) " & condition
            Frmlist.SumStrSql = "SELECT PayDate,COUNT(*) AS C_Count ,ISNULL(SUM(MoneyChk),0) As MoneyChk   FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind)" & condition & " GROUP BY PayDate"
            Me.Enabled = False
            Frmlist.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        t = 1
        Using FrmBox As New FrmMojodyBox
            Me.Enabled = False
            FrmBox.ShowDialog()
            Me.Enabled = True
        End Using
        t = 0
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        t = 1
        Using FrmBank As New FrmMojodyBank
            Me.Enabled = False
            FrmBank.ShowDialog()
            Me.Enabled = True
        End Using
        t = 0
    End Sub
   
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

    Private Sub ChkAz_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAz.CheckedChanged
        If ChkAz.Checked = True Then
            Txt_Date.ThisText = GetDate()
            Txt_Date.Enabled = True
            Txt_Date.Focus()
        Else
            Txt_Date.Enabled = False
            Txt_Date.ThisText = GetDate()
        End If
    End Sub

    Private Sub ChkTa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTa.CheckedChanged
        If ChkTa.Checked = True Then
            Txt_Date1.ThisText = GetDate()
            Txt_Date1.Enabled = True
            Txt_Date1.Focus()
        Else
            Txt_Date1.Enabled = False
            Txt_Date1.ThisText = GetDate()
        End If
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkAz.Enabled = True
            ChkTa.Enabled = True
            Txt_Date.Enabled = True
            Txt_Date.ThisText = GetDate()
            Txt_Date1.Enabled = True
            Txt_Date1.ThisText = GetDate()
            ChkAz.Checked = True
            ChkTa.Checked = True
        Else
            ChkAz.Enabled = False
            ChkTa.Enabled = False
            Txt_Date1.Enabled = False
            Txt_Date1.ThisText = GetDate()
            Txt_Date.Enabled = False
            Txt_Date.ThisText = GetDate()
            ChkAz.Checked = False
            ChkTa.Checked = False
        End If
    End Sub

    Private Sub TxtDelayGet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDelayGet.TextChanged
        If Not (CheckDigit(TxtDelayGet.Text.Replace(",", ""))) Then
            TxtDelayGet.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtDelayGet.Text.Length > 3 Then
            str = Format$(TxtDelayGet.Text.Replace(",", ""))
            TxtDelayGet.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtDelayPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDelayPay.TextChanged
        If Not (CheckDigit(TxtDelayPay.Text.Replace(",", ""))) Then
            TxtDelayPay.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtDelayPay.Text.Length > 3 Then
            str = Format$(TxtDelayPay.Text.Replace(",", ""))
            TxtDelayPay.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Chkdelay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkdelay.CheckedChanged
        If Chkdelay.Checked = False Then
            TxtDiff.Text = (CDbl(TxtMonGet.Text) + CDbl(TxtBox.Text) + CDbl(TxtBank.Text)) - CDbl(TxtMonPay.Text)
        Else
            TxtDiff.Text = (CDbl(TxtMonGet.Text) + CDbl(TxtBox.Text) + CDbl(TxtBank.Text) + CDbl(TxtDelayGet.Text)) - (CDbl(TxtMonPay.Text) + CDbl(TxtDelayPay.Text))
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        t = 1
        Me.Enabled = False
        Using frm As New FrmDelayFactor
            frm.RdoBed.Checked = True
            If ChkTime.Checked = False Then
                frm.RdoAll.Checked = True
            Else
                frm.RdoEndDate.Checked = True

                If ChkAz.Checked = True Then
                    frm.ChkAzDate.Checked = True
                    frm.FarsiDate1.ThisText = Txt_Date.ThisText
                End If

                If ChkTa.Checked = True Then
                    frm.ChkTaDate.Checked = True
                    frm.FarsiDate2.ThisText = Txt_Date1.ThisText
                End If

            End If

            frm.ShowDialog()
        End Using
        t = 0
        Me.Enabled = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        t = 1
        Me.Enabled = False
        Using frm As New FrmDelayFactor
            frm.RdoBes.Checked = True
            If ChkTime.Checked = False Then
                frm.RdoAll.Checked = True
            Else
                frm.RdoEndDate.Checked = True

                If ChkAz.Checked = True Then
                    frm.ChkAzDate.Checked = True
                    frm.FarsiDate1.ThisText = Txt_Date.ThisText
                End If

                If ChkTa.Checked = True Then
                    frm.ChkTaDate.Checked = True
                    frm.FarsiDate2.ThisText = Txt_Date1.ThisText
                End If

            End If
            frm.ShowDialog()
        End Using
        t = 0
        Me.Enabled = True
    End Sub
End Class