Imports System.Data.SqlClient
Public Class FrmDelayFactor
    Dim GetDs As New DataTable
    Dim GetDta As New SqlDataAdapter
    Dim GetDV As New DataView

    Private Sub FrmDelayFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub
    Private Sub FrmDelayFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F104")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    ' ListDelay(If(RdoBed.Checked = True, 0, 1))
                    DGV1.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    SetButton()
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "ورود", "", "")
                    CalculateMon()
                End If
            End If
        Else
            ' ListDelay(If(RdoBed.Checked = True, 0, 1))
            DGV1.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            SetButton()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "ورود", "", "")
            CalculateMon()
        End If

    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F104")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnAddTime.Enabled = False
                    Button1.Enabled = False
                    BtnEditDisc.Enabled = False
                    BtnPrint.Enabled = False
                    BtnSendSMS.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        BtnAddTime.Enabled = False
                        Button1.Enabled = False
                        BtnEditDisc.Enabled = False
                        BtnPrint.Enabled = False
                        BtnSendSMS.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnAddTime.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            Button1.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            BtnEditDisc.Enabled = False
                        End If
                        If Access_Form.Substring(6, 1) = 0 Then
                            BtnPrint.Enabled = False
                        End If
                        Try
                            If Access_Form.Substring(7, 1) = 0 Then
                                BtnSendSMS.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnSendSMS.Enabled = False
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        Try
            If DGV1.Item("Cln_TimeRemain", e.RowIndex).Value = 0 And DGV1.Item("Cln_Remain", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DGV1.Item("Cln_TimeRemain", e.RowIndex).Value > 0 And DGV1.Item("Cln_Remain", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("Cln_TimeRemain", e.RowIndex).Value < 0 And DGV1.Item("Cln_Remain", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            Else
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.SpringGreen
            End If

            If DGV1.Item("Cln_Rate", e.RowIndex).Value > DGV1.Item("Cln_Delay", e.RowIndex).Value Then
                DGV1.Rows(e.RowIndex).Cells("Cln_Rate").Style.BackColor = Color.Gray
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ListDelay(ByVal state As Integer)
        Try
            Me.Enabled = False
            GetDs.Clear()
            If Not GetDs Is Nothing Then
                GetDs.Dispose()
            End If
            DGV1.DataSource = Nothing
            '''''''''''''''''''''''''''
            If state = 0 Then
                GetDta = New SqlDataAdapter("SELECT KindFrosh=CASE WHEN KindFrosh=0 THEN N'نقدی' WHEN KindFrosh=1 THEN N'چک' WHEN KindFrosh=2 THEN N'نسیه' WHEN KindFrosh=3 THEN N'ترکیبی' ELSE '' END,IdFactor,IdName,IdUser,IdVisitor,Nam,Define_People.Rate AS Delay,Define_People.IdOstan,Define_People.IdCity,Define_People.IdPart,ISNULL(Tell1,'') AS Tell1,ISNULL(Address ,'') AS addres ,ISNULL(Tell2,'') As Tell2 ,EndData.Rate,MaxNewDate,d_date ,MonFac ,Pay ,(MonFac -Pay ) AS Remain ,Disc FROM (SELECT IdFactor,KindFrosh,IdName,IdUser,IdVisitor ,Rate,Disc,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec)-(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,Wanted_Frosh.Disc,d_date,IdName,IdUser,IdVisitor,KindFrosh FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor " & If(Kind_User = 0, " WHERE IdUser=" & Id_User, "") & " ) As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName Order by IdFactor", DataSource)
            Else
                GetDta = New SqlDataAdapter("SELECT KindFrosh='',IdFactor,IdName,IdUser,IdVisitor,Nam,Define_People.Rate AS Delay,Define_People.IdOstan,Define_People.IdCity,Define_People.IdPart,ISNULL(Tell1,'') AS Tell1,ISNULL(Address ,'') AS addres ,ISNULL(Tell2,'') As Tell2 ,EndData.Rate,MaxNewDate,d_date ,MonFac ,Pay ,(MonFac -Pay ) AS Remain ,Disc FROM (SELECT IdFactor,IdName,IdUser,IdVisitor ,Rate,Disc,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorBuy  WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorBuy  WHERE ListFactorBuy.IdFactor  =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitKharid WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitKharid  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk+MonSellChk),0)   FROM ListFactorBuy WHERE IdFactor= AllTime.IdFactor ) As Pay,(SELECT ISNULL(MAX(NewDate),'') FROM TimeKharid WHERE TimeKharid.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Kharid.IdFactor, Wanted_Kharid.Rate,Wanted_Kharid.Disc,d_date,IdName,IdUser,IdVisitor FROM  Wanted_Kharid INNER JOIN ListFactorBuy ON Wanted_Kharid.IdFactor = ListFactorBuy.IdFactor " & If(Kind_User = 0, " WHERE IdUser=" & Id_User, "") & ") As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName Order by IdFactor", DataSource)
            End If
            GetDta.Fill(GetDs)
            If Not GetDs.Columns.Contains("EndDate") Then GetDs.Columns.Add("EndDate", Type.GetType("System.String"))
            If Not GetDs.Columns.Contains("TimeRemain") Then GetDs.Columns.Add("TimeRemain", Type.GetType("System.Int32"))
            If Not GetDs.Columns.Contains("NumDay") Then GetDs.Columns.Add("NumDay", Type.GetType("System.Int32"))

            For i As Integer = 0 To GetDs.Rows.Count - 1
                GetDs.Rows(i).Item("EndDate") = CalDate(GetDs.Rows(i).Item("D_date"), GetDs.Rows(i).Item("Rate"), GetDs.Rows(i).Item("MaxNewDate"))
                GetDs.Rows(i).Item("Rate") = SUBDAY(GetDs.Rows(i).Item("EndDate"), GetDs.Rows(i).Item("D_date"))

                If GetDs.Rows(i).Item("Remain") <= 0 Then
                    GetDs.Rows(i).Item("TimeRemain") = GetDs.Rows(i).Item("Delay") - GetDs.Rows(i).Item("Rate")
                Else
                    GetDs.Rows(i).Item("TimeRemain") = SUBDAY(GetDs.Rows(i).Item("EndDate"), GetDate())
                End If

                GetDs.Rows(i).Item("NumDay") = GetDs.Rows(i).Item("TimeRemain") - GetDs.Rows(i).Item("Rate")
            Next
            DGV1.AutoGenerateColumns = False
            GetDV = GetDs.DefaultView
            Me.SetFilter()
            DGV1.DataSource = GetDV
            ChkSelect.Checked = False
            CalculateMon()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "ListDelay")
            Me.Close()
        End Try
    End Sub
    Private Sub SetFilter()
        If CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False Then
            GetDV.RowFilter = "TimeRemain=0 AND TimeRemain>0  AND TimeRemain<0"
            Exit Sub
        End If
        Dim Filter1 As String = "(" & If(CheckBox1.Checked = True, " TimeRemain=0 ", "") & If(CheckBox2.Checked = True, If(CheckBox1.Checked = True, " OR TimeRemain<0 ", " TimeRemain<0 "), "") & If(CheckBox3.Checked = True, If(CheckBox1.Checked = True Or CheckBox2.Checked = True, " OR TimeRemain>0 ", " TimeRemain>0 "), "") & ")"

        If ChkPart.Checked = True Then
            Try
                If ChkP.Checked = True And Not String.IsNullOrEmpty(CmbPart.SelectedValue) Then
                    Filter1 &= " AND IdPart=" & CmbPart.SelectedValue
                ElseIf ChkCity.Checked = True And Not String.IsNullOrEmpty(CmbCity.SelectedValue) Then
                    Filter1 &= " AND IdCity=" & CmbCity.SelectedValue
                ElseIf Not String.IsNullOrEmpty(CmbOstan.SelectedValue) Then
                    Filter1 &= " AND IdOstan=" & CmbOstan.SelectedValue
                End If
            Catch ex As Exception

            End Try
        End If

        Dim Filter2 As String = ""

        If RdoAll.Checked = True Then
            Filter2 = ""
        ElseIf RdoPeople.Checked = True Then
            Filter2 = " AND IdName=" & IIf(String.IsNullOrEmpty(TxtIdName.Text), 0, TxtIdName.Text)
        ElseIf RdoUser.Checked = True Then
            Filter2 = " AND IdUser=" & IIf(String.IsNullOrEmpty(TxtIdUser.Text), 0, TxtIdUser.Text)
        ElseIf RdoVisitor.Checked = True Then
            If TxtIdVisitor.Text.Contains(",") Then
                Dim x() As String
                Dim Con As String = ""
                x = TxtIdVisitor.Text.Split(",")

                For i As Integer = 0 To x.Length - 1
                    If Not String.IsNullOrEmpty(x(i)) Then Con &= "IdVisitor =" & x(i) & " OR "
                Next

                If Not String.IsNullOrEmpty(Con) Then Con = " AND " & Con.Substring(0, Con.Length - 3)
                Filter2 = Con
            Else
                Filter2 = " AND IdVisitor=" & IIf(String.IsNullOrEmpty(TxtIdVisitor.Text), 0, TxtIdVisitor.Text)
            End If
        ElseIf RdoDate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                Filter2 = " AND (D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                Filter2 = " AND (D_Date>='" & FarsiDate1.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                Filter2 = " AND (D_Date<='" & FarsiDate2.ThisText & "')"
            Else
                Filter2 = ""
            End If
        ElseIf RdoEndDate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                Filter2 = " AND (EndDate>='" & FarsiDate1.ThisText & "' AND EndDate<='" & FarsiDate2.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                Filter2 = " AND (EndDate>='" & FarsiDate1.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                Filter2 = " AND (EndDate<='" & FarsiDate2.ThisText & "')"
            Else
                Filter2 = ""
            End If
        End If

        Dim Filter3 As String = ""

        If RdoBed.Checked = True And ChkKind.Checked = True Then
            Filter3 = " AND KindFrosh='" & CmbFrosh.Text.Trim & "'"
        End If

        If ChkShow.Checked = True Then
            If ChkOnly.Checked = False Then
                GetDV.RowFilter = Filter1 & Filter2 & Filter3
            Else
                GetDV.RowFilter = "Remain<=0 AND" & Filter1 & Filter2 & Filter3
            End If
        Else
            GetDV.RowFilter = "Remain>0 AND" & Filter1 & Filter2 & Filter3
        End If
        CalculateMon()
    End Sub
    Private Sub CalculateMon()
        TxtAllmoney.Text = "0"
        TxtRas.Text = "0"

        Dim mon As Double = 0
        Dim allmon As Double = 0

        For i As Integer = 0 To DGV1.RowCount - 1
            If CDbl(DGV1.Item("Cln_Remain", i).Value) > 0 Then
                mon += CDbl(DGV1.Item("Cln_Remain", i).Value)
                allmon += (CDbl(DGV1.Item("Cln_Remain", i).Value) * CDbl(DGV1.Item("Cln_NumDay", i).Value))
            End If
        Next
        TxtAllmoney.Text = FormatNumber(mon, 0)
        If mon > 0 Then TxtRas.Text = Math.Round(allmon / mon, 2).ToString.Replace(".", "/")
    End Sub
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

    Private Sub RdoBed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBed.CheckedChanged
        If RdoBed.Checked = True Then
            ListDelay(If(RdoBed.Checked = True, 0, 1))
            Try
                DGV1.Columns("Cln_KindFrosh").Visible = True
            Catch ex As Exception

            End Try
            ChkKind.Visible = True
            CmbFrosh.Visible = True
        End If
    End Sub

    Private Sub RdoBes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBes.CheckedChanged
        If RdoBes.Checked = True Then
            ListDelay(If(RdoBed.Checked = True, 0, 1))
            Try
                DGV1.Columns("Cln_KindFrosh").Visible = False
            Catch ex As Exception

            End Try
            ChkKind.Visible = False
            CmbFrosh.Visible = False
        End If
    End Sub

    Private Sub ChkShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShow.CheckedChanged
        If ChkShow.Checked = True Then
            ChkOnly.Enabled = True
        Else
            ChkOnly.Enabled = False
            ChkOnly.Checked = False
        End If
        Me.SetFilter()
    End Sub

    Private Sub ChkSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelect.CheckedChanged
        If DGV1.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV1.RowCount - 1
            DGV1.Item("Cln_Select", i).Value = ChkSelect.Checked
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Me.SetFilter()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Me.SetFilter()
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Me.SetFilter()
    End Sub

    Private Sub BtnMoein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoein.Click
        If DGV1.RowCount <= 0 Then
            MessageBox.Show("طرف حسابی برای نمایش معین وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Using moeinPeople As New Moein_People
            Me.Enabled = False
            moeinPeople.TxtName.Text = DGV1.Item("Cln_Nam", DGV1.CurrentRow.Index).Value
            moeinPeople.TxtIdName.Text = DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value
            moeinPeople.TxtMobile.Text = DGV1.Item("Cln_Tell2", DGV1.CurrentRow.Index).Value
            moeinPeople.TxtTell.Text = DGV1.Item("Cln_Tell1", DGV1.CurrentRow.Index).Value
            moeinPeople.TxtAddress.Text = GetAddressWithCity(DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value)
            moeinPeople.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            GroupBox5.Enabled = False
        Else
            GroupBox5.Enabled = True
        End If
        SetFilter()
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            Me.Enabled = False
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            Me.Enabled = True
        End If
    End Sub

    Private Sub RdoPeople_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoPeople.CheckedChanged
        If RdoPeople.Checked = True Then
            LPeople.Visible = True
            TxtName.Visible = True
            TxtName.Focus()
        Else
            LPeople.Visible = False
            TxtName.Visible = False
            TxtName.Text = ""
            TxtIdName.Text = ""
        End If
        SetFilter()
    End Sub

    Private Sub RdoDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDate.CheckedChanged
        If RdoDate.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            ChkAzDate.Visible = True
            FarsiDate1.Visible = True
            ChkTaDate.Visible = True
            FarsiDate2.Visible = True
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
            ChkAzDate.Visible = False
            FarsiDate1.Visible = False
            ChkTaDate.Visible = False
            FarsiDate2.Visible = False
        End If
        SetFilter()
    End Sub

    Private Sub RdoEndDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoEndDate.CheckedChanged
        If RdoEndDate.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            ChkAzDate.Visible = True
            FarsiDate1.Visible = True
            ChkTaDate.Visible = True
            FarsiDate2.Visible = True
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
            ChkAzDate.Visible = False
            FarsiDate1.Visible = False
            ChkTaDate.Visible = False
            FarsiDate2.Visible = False
        End If
        SetFilter()
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
        SetFilter()
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
        SetFilter()
    End Sub

    Private Sub TxtIdName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdName.TextChanged
        If RdoPeople.Checked = True Then Me.SetFilter()
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        SetFilter()
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        SetFilter()
    End Sub

    Private Sub ChkOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOnly.CheckedChanged
        If ChkOnly.Checked = True Then
            BtnAddTime.Enabled = False
        Else
            BtnAddTime.Enabled = True
        End If

        Me.SetFilter()
    End Sub

    Private Sub DGV1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV1.RowPrePaint
        Try
            If DGV1.RowCount < 1000 Then
                Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                    e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                    e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
                End Using
            Else
                Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                    e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                    e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
                End Using
            End If
            If DGV1.Item("Cln_TimeRemain", e.RowIndex).Value = 0 And DGV1.Item("Cln_Remain", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DGV1.Item("Cln_TimeRemain", e.RowIndex).Value > 0 And DGV1.Item("Cln_Remain", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("Cln_TimeRemain", e.RowIndex).Value < 0 And DGV1.Item("Cln_Remain", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            Else
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.SpringGreen
            End If

            If DGV1.Item("Cln_Rate", e.RowIndex).Value > DGV1.Item("Cln_Delay", e.RowIndex).Value Then
                DGV1.Rows(e.RowIndex).Cells("Cln_Rate").Style.BackColor = Color.Gray
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDayWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDayWork.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(If(RdoBed.Checked = True, 0, 1))
                FrmDay.LCal.Text = DGV1.Item("Cln_Nam", DGV1.CurrentRow.Index).Value
                FrmDay.ShowDialog()
                Me.Enabled = False
                ListDelay(If(RdoBed.Checked = True, 0, 1))
                Me.Enabled = True
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "BtnDayWork_Click")
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Bed.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnAddTime.Enabled = True Then BtnAddTime_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDayWork.Enabled = True Then BtnDayWork_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnMoein.Enabled = True Then BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.Enabled = False
            ListDelay(If(RdoBed.Checked = True, 0, 1))
            Me.Enabled = True
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnEditDisc.Enabled = True Then BtnEditDisc_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F8 Then
            If BtnPrint.Enabled = True Then BtnPrint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F9 Then
            If BtnSendSMS.Enabled = True Then BtnSendSMS_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnAddTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddTime.Click
        If DGV1.RowCount <= 0 Then
            MessageBox.Show("هیچ وعده ای وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Enabled = False
            ListDelay(If(RdoBed.Checked = True, 0, 1))
            Me.Enabled = True
            Exit Sub
        End If
        BtnAddTime.Focus()
        DGV1.EndEdit()
        Dim count As Long = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Item("Cln_Select", i).Value = True Then
                count += 1
                If DGV1.Item("Cln_Remain", i).Value <= 0 Then
                    MessageBox.Show("جهت انجام تمدید وعده نبایستی از فاکتورهای تسویه شده استفاده کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Next
        If count <= 0 Then
            MessageBox.Show("هیچ وعده ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Item("Cln_Select", i).Value = True Then

                Using NewFrm As New FrmOneAddTime
                    NewFrm.TxtEndDate.Text = DGV1.Item("Cln_EndDate", i).Value
                    NewFrm.TxtName.Text = DGV1.Item("Cln_Nam", i).Value
                    NewFrm.TxtIdFactor.Text = DGV1.Item("Cln_ID", i).Value
                    NewFrm.Str = If(RdoBed.Checked = True, "SELECT * FROM TimeFrosh WHERE IdFactor=" & DGV1.Item("Cln_ID", i).Value, "SELECT * FROM TimeKharid WHERE IdFactor=" & DGV1.Item("Cln_ID", i).Value)
                    NewFrm.ShowDialog()
                End Using
            End If
        Next

        Me.Enabled = False
        ListDelay(If(RdoBed.Checked = True, 0, 1))
        Me.Enabled = True
    End Sub

    Private Sub BtnEditDisc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditDisc.Click
        Try
            BtnEditDisc.Focus()
            DGV1.EndEdit()
            Dim c As Integer = 0
            Dim Id As Long = 0
            Dim Disc As String = ""
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Select", i).Value = True Then
                        c += 1
                        Id = DGV1.Item("Cln_ID", i).Value
                        Disc = If(DGV1.Item("Cln_Disc", i).Value Is DBNull.Value, "", DGV1.Item("Cln_Disc", i).Value)
                    End If
                Next
                If c = 0 Then
                    MessageBox.Show("هیچ وعده ای جهت اصلاح توضیحات انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If c > 1 Then
                    MessageBox.Show("جهت اصلاح توضیحات بایستی فقط یک وعده انتخاب شده باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("هیچ وعده ای جهت اصلاح توضیحات وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Using FPrint As New FrmDisc
                FPrint.LState.Text = If(RdoBed.Checked = True, "Wanted_Frosh", "Wanted_Kharid")
                FPrint.LIdChk.Text = Id
                FPrint.TxtDisc.Text = Disc
                FPrint.ShowDialog()
                If FPrint.LAdd.Text = "0" Then
                    Me.Enabled = True
                    Exit Sub
                End If
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "اصلاح توضیحات", "اصلاح توضیحات وعده فاکتور:" & Id, "")
            End Using
            ListDelay(If(RdoBed.Checked = True, 0, 1))
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "BtnEditDisc_Click")
            Me.Enabled = True
        End Try
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
        Else
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
    End Sub

    Private Sub RdoUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoUser.CheckedChanged
        If RdoUser.Checked = True Then
            LUser.Visible = True
            TxtUser.Visible = True
            TxtUser.Focus()
        Else
            LUser.Visible = False
            TxtUser.Visible = False
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
        SetFilter()
    End Sub

    Private Sub TxtIdUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdUser.TextChanged
        If RdoUser.Checked = True Then Me.SetFilter()
    End Sub

    Private Sub RdoVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoVisitor.CheckedChanged
        If RdoVisitor.Checked = True Then
            Lvisitor.Visible = True
            TxtVisitor.Visible = True
            TxtVisitor.Focus()
        Else
            Lvisitor.Visible = False
            TxtVisitor.Visible = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
        SetFilter()
    End Sub

    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.ChkAll.Visible = True
        frmlk.DGV.Columns("Cln_select").Visible = True
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        Try
            If AllSelectKala.Length > 0 Then
                Dim Id As String = ""
                Dim Nam As String = ""
                For j As Integer = 0 To AllSelectKala.Length - 1
                    Nam &= AllSelectKala(j).Namekala & If(j = AllSelectKala.Length - 1, "", ",")
                    Id &= AllSelectKala(j).IdKala & If(j = AllSelectKala.Length - 1, "", ",")
                Next
                TxtVisitor.Text = Nam
                TxtIdVisitor.Text = Id
                Array.Resize(AllSelectKala, 0)
            Else
                TxtVisitor.Text = ""
                TxtIdVisitor.Text = ""
            End If
        Catch ex As Exception
            Array.Resize(AllSelectKala, 0)
        End Try

    End Sub

    Private Sub TxtIdVisitor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdVisitor.TextChanged
        If RdoVisitor.Checked = True Then Me.SetFilter()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("وعده ای جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            BtnPrint.Focus()
            DGV1.EndEdit()
            Me.Enabled = False
            Array.Resize(ListDelayPrintArray, 0)
            Dim MonMoein As Double = 0
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then
                    Dim moein As Double = GetMoeinPeople(DGV1.Item("Cln_IdName", i).Value)
                    flag = False
                    For j As Integer = 0 To ListDelayPrintArray.Length - 1
                        If DGV1.Item("Cln_IdName", i).Value = ListDelayPrintArray(j).Tmp Then
                            flag = True
                            Exit For
                        End If
                    Next
                    If flag = False Then MonMoein += moein
                    Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).IdFactor = DGV1.Item("Cln_Id", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tmp = DGV1.Item("Cln_IdName", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).nam = DGV1.Item("Cln_Nam", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell1 = DGV1.Item("Cln_Tell1", i).Value.ToString
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell2 = DGV1.Item("Cln_Tell2", i).Value.ToString
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).D_Date = DGV1.Item("Cln_Date", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).EndDate = DGV1.Item("Cln_EndDate", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).TimeRemain = DGV1.Item("Cln_TimeRemain", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Remain = CDbl(DGV1.Item("Cln_Remain", i).Value)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Disc = DGV1.Item("Cln_Address", i).Value.ToString
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Rate = DGV1.Item("Cln_Rate", i).Value

                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tmp2 = DGV1.Item("Cln_NumDay", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).KindFrosh = DGV1.Item("Cln_KindFrosh", i).Value

                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Mandeh = If(moein < 0, moein * (-1), moein)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).T = If(moein < 0, "بس", "بد")
                    If RdoAll.Checked = True Or RdoDate.Checked = True Or RdoEndDate.Checked = True Then
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Kind = "گزارش وعده های " & If(RdoBed.Checked = True, "بدهکاران ", "بستانکاران ")
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = ""
                    ElseIf RdoPeople.Checked = True Then
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Kind = "گزارش وعده های " & If(RdoBed.Checked = True, "بدهکاران ", "بستانکاران ") & "بر اساس طرف حساب"
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = "طرف حساب : " & TxtName.Text
                    ElseIf RdoUser.Checked = True Then
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Kind = "گزارش وعده های " & If(RdoBed.Checked = True, "بدهکاران ", "بستانکاران ") & "بر اساس کاربر"
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = "کاربر : " & TxtUser.Text
                    ElseIf RdoVisitor.Checked = True Then
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Kind = "گزارش وعده های " & If(RdoBed.Checked = True, "بدهکاران ", "بستانکاران ") & "بر اساس ویزیتور"
                        ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = "ویزیتور : " & TxtVisitor.Text
                    End If
                End If
            Next
            Me.Enabled = True
            If ListDelayPrintArray.Length <= 0 Then
                MessageBox.Show("وعده ای جهت چاپ انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "چاپ", "", "")
            If RdoBed.Checked = True Then
                FrmPrint.CHoose = "DELAYPRINT"
            Else
                FrmPrint.CHoose = "DELAYPRINT2"
            End If
            Tmp_Mon = MonMoein
            FrmPrint.ShowDialog()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "BtnPrint_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If DGV1.RowCount <= 0 Then
            MessageBox.Show("هیچ وعده ای وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Enabled = False
            ListDelay(If(RdoBed.Checked = True, 0, 1))
            Me.Enabled = True
            Exit Sub
        End If
        Button1.Focus()
        DGV1.EndEdit()
        Dim count As Long = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Item("Cln_Select", i).Value = True Then
                count += 1
            End If
        Next
        If count <= 0 Then
            MessageBox.Show("هیچ وعده ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Item("Cln_Select", i).Value = True Then

                Using NewFrm As New FrmPayEnd
                    NewFrm.TxtEndDate.Text = DGV1.Item("Cln_EndDate", i).Value
                    NewFrm.TxtName.Text = DGV1.Item("Cln_Nam", i).Value
                    NewFrm.TxtBedfactor.Text = FormatNumber(CDbl(DGV1.Item("Cln_Remain", i).Value), 0)
                    NewFrm.TxtIdFactor.Text = DGV1.Item("Cln_ID", i).Value
                    NewFrm.Str = If(RdoBed.Checked = True, "SELECT * FROM AddPayLimitFrosh WHERE IdFactor=" & DGV1.Item("Cln_ID", i).Value, "SELECT * FROM AddPayLimitKharid WHERE IdFactor=" & DGV1.Item("Cln_ID", i).Value)
                    NewFrm.ShowDialog()
                End Using
            End If
        Next

        Me.Enabled = False
        ListDelay(If(RdoBed.Checked = True, 0, 1))
        Me.Enabled = True
    End Sub

    Private Sub BtnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendSMS.Click
        If SMS = False Then
            MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Array.Resize(ListDelayPrintArray, 0)

        If DGV1.RowCount > 0 Then
            Dim c As Integer = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then
                    Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).nam = DGV1.Item("Cln_Nam", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).IdFactor = DGV1.Item("Cln_ID", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell1 = DGV1.Item("Cln_Tell2", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Mandeh = CDbl(DGV1.Item("Cln_Remain", i).Value)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Rate = DGV1.Item("Cln_TimeRemain", i).Value
                    c += 1
                End If
            Next
            If c <= 0 Then
                MessageBox.Show("هیچ وعده ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            MessageBox.Show("هیچ وعده ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری وعده", "SMS ارسال", "", "")
        Using FrmT As New SendAllSMSTime
            FrmT.ShowDialog()
        End Using
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbPart.Enabled = True
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
        SetFilter()
    End Sub

    Private Sub ChkCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCity.CheckedChanged
        If ChkCity.Checked = True Then
            ChkP.Enabled = True
        Else
            ChkP.Checked = False
            ChkP.Enabled = False
        End If
        SetFilter()
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "Get_Ostan")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "Get_City")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayFactor", "Get_Part")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
            Me.Get_City(CmbOstan.SelectedValue)
        Catch ex As Exception
            Exit Sub
        End Try
        SetFilter()
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        Try
            CmbPart.DataSource = Nothing
            Me.Get_Part(CmbOstan.SelectedValue, CmbCity.SelectedValue)
        Catch ex As Exception
            Exit Sub
        End Try
        SetFilter()
    End Sub

    Private Sub ChkP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkP.CheckedChanged
        SetFilter()
    End Sub

    Private Sub CmbPart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPart.SelectedIndexChanged
        SetFilter()
    End Sub

    Private Sub ChkKind_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkKind.CheckedChanged
        If ChkKind.Checked = True Then
            CmbFrosh.Enabled = True
            If CmbFrosh.Text = "" Then CmbFrosh.Text = CmbFrosh.Items(0)
            SetFilter()
        Else
            CmbFrosh.Enabled = False
            SetFilter()
        End If
    End Sub

    Private Sub CmbFrosh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFrosh.SelectedIndexChanged
        If ChkKind.Checked = True Then
            SetFilter()
        End If
    End Sub
End Class