Imports System.Data.SqlClient
Public Class FrmChartPayChk

    Private Sub ChkAllp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllp.CheckedChanged
        If DGV2.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV2.RowCount - 1
            DGV2.Item("Cln_SelectP", i).Value = ChkAllp.Checked
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV2.RowCount <= 0 Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV2.RowCount > 1 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_IdP", i).Value = IdKala Then
                        DGV2.Item("Cln_NamP", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV2.Item("Cln_NamP", 0).Selected = True
                DGV2.Item("Cln_NamP", 0).Selected = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Using FrmAdVance As New People_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.Condition2 = "1"
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV2.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV2.Item("Cln_IdP", i).Value Then DGV2.Item("Cln_SelectP", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV2.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
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
            RdoPayDate.Enabled = True
            RdoGetDate.Enabled = True
            RdoPayDate.Checked = True
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
            RdoPayDate.Enabled = False
            RdoGetDate.Enabled = False
            RdoPayDate.Checked = False
            RdoGetDate.Checked = False
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

    Private Sub FrmReportGetChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmReportGetChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F148")
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
        Me.GetPeople()
        ChkAllp.Checked = True
        DGV2.Columns("Cln_NamP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub GetPeople()
        Try
            Dim dvP As New DataView
            Dim DsP As New DataSet
            Dim DtaP As New SqlDataAdapter()
            DsP.Clear()
            If Not DtaP Is Nothing Then
                DtaP.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Activ,Id,Nam FROM Define_People Order by Nam"
            DtaP = New SqlDataAdapter(sqlstr, DataSource)
            DtaP.Fill(DsP, "Define_People")
            DGV2.AutoGenerateColumns = False
            dvP = DsP.Tables("Define_People").DefaultView
            DGV2.DataSource = dvP
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmChartPayChk", "GetPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub ChkOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOther.CheckedChanged
        If ChkOther.Checked = True Then
            RdoAllChk.Enabled = True
            RdoAllChk.Checked = True
            RdoOnlyChk.Enabled = True
        Else
            RdoAllChk.Enabled = False
            RdoOnlyChk.Enabled = False
            RdoAllChk.Checked = False
            RdoOnlyChk.Checked = False
        End If
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        If DGV2.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        If CBool(DGV2.Item("Cln_ActiveP", e.RowIndex).Value) = True Then
            DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If Not (ChkOther.Checked = True And RdoOnlyChk.Checked = True) Then
                If DGV2.RowCount <= 0 Then
                    MessageBox.Show("طرف حسابی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkDar.Checked = False And ChkBargasht.Checked = False And ChkTazmini.Checked = False And ChkVosol.Checked = False Then
                MessageBox.Show("وضعیت اسناد دریافتی را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If ChkBank.Checked = True Then
                If String.IsNullOrEmpty(TxtBank.Text) Or String.IsNullOrEmpty(TxtIdBank.Text) Then
                    MessageBox.Show("بانک مورد نظر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''Set Condition
            Dim ListPeople As String = ""
            If Not (ChkOther.Checked = True And RdoOnlyChk.Checked = True) And Not (ChkPay.Checked = True And RdoOnlyChkPay.Checked = True) Then
                Dim CountPeople As Long = 0
                ListPeople = " AND ( "
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_SelectP", i).Value = True Then
                        ListPeople &= "Current_IdPeople =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                        CountPeople += 1
                    End If
                Next
                If CountPeople = DGV2.RowCount Then
                    If (ChkOther.Checked = True And RdoAllChk.Checked = True) And (ChkPay.Checked = True And RdoAllChkPay.Checked = True) Then
                        ListPeople = ""
                    ElseIf (ChkOther.Checked = True And RdoAllChk.Checked = True) And Not (ChkPay.Checked = True And RdoAllChkPay.Checked = True) Then
                        ListPeople = " AND (IdBank IS NOT NULL) "
                    ElseIf Not (ChkOther.Checked = True And RdoAllChk.Checked = True) And (ChkPay.Checked = True And RdoAllChkPay.Checked = True) Then
                        ListPeople = "  AND (Current_IdPeople IS NOT NULL)"
                    Else
                        ListPeople = " AND (Current_IdPeople IS NOT NULL) AND (IdBank IS NOT NULL) "
                    End If

                ElseIf CountPeople <= 0 Then
                    MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else

                    If (ChkOther.Checked = True And RdoAllChk.Checked = True) And (ChkPay.Checked = True And RdoAllChkPay.Checked = True) Then
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                    ElseIf (ChkOther.Checked = True And RdoAllChk.Checked = True) And Not (ChkPay.Checked = True And RdoAllChkPay.Checked = True) Then
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                        ListPeople &= " AND (IdBank IS NOT NULL) "
                    ElseIf Not (ChkOther.Checked = True And RdoAllChk.Checked = True) And (ChkPay.Checked = True And RdoAllChkPay.Checked = True) Then
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                        ListPeople &= "  AND (Current_IdPeople IS NOT NULL)"
                    Else
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                        ListPeople &= " AND (Current_IdPeople IS NOT NULL) AND (IdBank IS NOT NULL) "
                    End If
                End If
            Else
                If (ChkOther.Checked = True And RdoOnlyChk.Checked = True) Then
                    ListPeople = " AND (Current_IdPeople IS NULL) "
                ElseIf (ChkPay.Checked = True And RdoOnlyChkPay.Checked = True) Then
                    ListPeople = " AND  (IdBank IS NULL)"
                End If
            End If


            Dim Kind As String = "WHERE ( "
            If ChkDar.Checked = True Then
                Kind &= " Current_State=0 "
            End If
            If ChkBargasht.Checked = True Then
                If ChkDar.Checked = True Then
                    Kind &= " OR Current_State=2 "
                Else
                    Kind &= " Current_State=2 "
                End If
            End If
            If ChkTazmini.Checked = True Then
                If ChkDar.Checked = True Or ChkBargasht.Checked = True Then
                    Kind &= " OR Current_State=3 "
                Else
                    Kind &= " Current_State=3 "
                End If
            End If

            If ChkVosol.Checked = True Then
                If ChkDar.Checked = True Or ChkBargasht.Checked = True Or ChkTazmini.Checked = True Then
                    Kind &= " OR Current_State=1 "
                Else
                    Kind &= " Current_State=1 "
                End If
            End If
            Kind &= ")"
            '''''''''''''''''''''''''''''''''''
            Dim dat As String = ""
            If ChkTime.Checked = True Then
                If RdoPayDate.Checked = True Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dat = " AND (PayDate>=N'" & FarsiDate1.ThisText & "' AND PayDate <=N'" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dat = " AND (PayDate>=N'" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dat = " AND (PayDate <=N'" & FarsiDate2.ThisText & "')"
                    End If
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dat = " AND (GetDate>=N'" & FarsiDate1.ThisText & "' AND GetDate <=N'" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dat = " AND (GetDate>=N'" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dat = " AND (GetDate <=N'" & FarsiDate2.ThisText & "')"
                    End If
                End If
            End If


            Dim bank As String = ""

            If ChkBank.Checked = True Then
                bank = " AND (IdBank=" & TxtIdBank.Text & ")"
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "نمودار اسناد پرداختی", "تهیه گزارش", "", "")

            Using FS As New FrmPrint
                FS.Str1 = "نمودار اسناد پرداختی"

                FS.Str2 = "نوع چک: " & If(ChkBargasht.Checked = True And ChkDar.Checked = True And ChkTazmini.Checked = True And ChkVosol.Checked = True, "همه", If(ChkDar.Checked = True, "در جریان,", "") & If(ChkBargasht.Checked = True, "برگشتی,", "") & If(ChkVosol.Checked = True, "وصول شده,", "") & If(ChkTazmini.Checked = True, "تضمینی,", ""))
                FS.Str2 &= If(ChkBank.Checked = True, vbCrLf & "بانک:" & TxtBank.Text, "")



                FS.State = If(ChkAzDate.Checked = True, FarsiDate1.ThisText & If(RdoPayDate.Checked = True, "(سررسید)", "(صدور)"), "")
                FS.IdFactor = If(ChkTaDate.Checked = True, FarsiDate2.ThisText & If(RdoPayDate.Checked = True, "(سررسید)", "(صدور)"), "")

                If RdoDay.Checked = True Then
                    FS.CHoose = "CHART-DAYCHARGE"
                ElseIf RdoWeek.Checked = True Then
                    FS.CHoose = "CHART-WEEKCHARGE"
                ElseIf RdoMonth.Checked = True Then
                    FS.CHoose = "CHART-MONTHCHARGE"
                End If

                If RdoLine.Checked = True Then
                    FS.Lend = "LINE"
                ElseIf RdoPie.Checked = True Then
                    FS.Lend = "PIE"
                ElseIf RdoBar.Checked = True Then
                    FS.Lend = "BAR"
                End If

                If ChkTime.Checked = False Or (ChkTime.Checked = True And RdoPayDate.Checked = True) Then
                    FS.PrintSQl = "SELECT PayDate AS T,ISNULL(SUM(MoneyChk),0) As Mandeh FROM (SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell ,Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk  " & Kind & ListPeople & dat & bank & " GROUP BY PayDate ORDER BY PayDate"
                Else
                    FS.PrintSQl = "SELECT GetDate AS T,ISNULL(SUM(MoneyChk),0) As Mandeh FROM (SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell ,Chk_Id .Current_IdPeople ,Chk_Id.IdBank , NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =21) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =21) UNION ALL SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1)  AND (Chk_Get_Pay.Current_Type =14) UNION SELECT Tell=N'',Chk_Id .Current_IdPeople,Chk_Id.IdBank, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_Type =14)) As ListGetChk  " & Kind & ListPeople & dat & bank & " GROUP BY GetDate ORDER BY GetDate"
                End If

                FS.ShowDialog()
            End Using
            '/////////////////////////////////////////////
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmChartPayChk", "BtnOk_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepNSanadpay.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetPeople()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub RdoOnlyChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOnlyChk.CheckedChanged
        If RdoOnlyChk.Checked = True Then
            ChkAllp.Checked = False
            GroupBox5.Enabled = False
            ChkPay.Enabled = False
            ChkPay.Checked = False
        Else
            ChkAllp.Checked = True
            GroupBox5.Enabled = True
            ChkPay.Enabled = True
        End If
    End Sub

    Private Sub TxtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.LState.Text = "WHERE State=N'جاری'"
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtBank.Focus()
        If IdKala <> 0 Then
            TxtBank.Text = Tmp_Namkala
            TxtIdBank.Text = IdKala
        Else
            TxtBank.Text = ""
            TxtIdBank.Text = ""
        End If
    End Sub

    Private Sub ChkBank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBank.CheckedChanged
        If ChkBank.Checked = True Then
            TxtBank.Enabled = True
        Else
            TxtBank.Enabled = False
            TxtBank.Text = ""
            TxtIdBank.Text = ""
        End If
    End Sub

    Private Sub ChkPay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPay.CheckedChanged
        If ChkPay.Checked = True Then
            RdoAllChkPay.Enabled = True
            RdoOnlyChkPay.Enabled = True
            RdoAllChkPay.Checked = True
        Else
            RdoAllChkPay.Enabled = False
            RdoOnlyChkPay.Enabled = False
            RdoAllChkPay.Checked = False
            RdoOnlyChkPay.Checked = False
        End If
    End Sub

    Private Sub RdoOnlyChkPay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOnlyChkPay.CheckedChanged
        If RdoOnlyChkPay.Checked = True Then
            ChkAllp.Checked = False
            GroupBox5.Enabled = False
            ChkOther.Checked = False
            ChkOther.Enabled = False
            ChkBank.Checked = False
            ChkBank.Enabled = False
        Else
            ChkAllp.Checked = True
            GroupBox5.Enabled = True
            ChkPay.Enabled = True
            ChkOther.Enabled = True
            ChkBank.Enabled = True
        End If
    End Sub
End Class