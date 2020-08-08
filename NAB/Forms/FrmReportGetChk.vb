Imports System.Data.SqlClient
Public Class FrmReportGetChk

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

    Private Sub ChKMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKMon.CheckedChanged
        If ChKMon.Checked = True Then
            ChkAzMon.Enabled = True
            ChkTaMon.Enabled = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            TxtMon1.Focus()
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
    End Sub

    Private Sub TxtMon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon1.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon1.Text.Replace(",", "")))) Then
                TxtMon1.Text = "0"
                TxtMon1.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon1.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon1.Text.Replace(",", ""))
                TxtMon1.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon1.Text = CDbl(TxtMon1.Text)
            End If
        Catch ex As Exception

        End Try
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
    End Sub

    Private Sub TxtMon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon2.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon2.Text.Replace(",", "")))) Then
                TxtMon2.Text = "0"
                TxtMon2.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon2.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon2.Text.Replace(",", ""))
                TxtMon2.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon2.Text = CDbl(TxtMon2.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmReportGetChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmReportGetChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F90")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
                Try
                    If Access_Form.Substring(3, 1) = 0 Then
                        BtnSendSMS.Enabled = False
                    End If
                Catch ex As Exception
                    BtnSendSMS.Enabled = False
                End Try
                
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportGetChk", "GetPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub ChkOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOther.CheckedChanged
        If ChkOther.Checked = True Then
            RdoAllChk.Enabled = True
            RdoOnlyChk.Enabled = True
            RdoAllChk.Checked = True
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

            If ChkDar.Checked = False And ChkBargasht.Checked = False And ChkBrat.Checked = False And ChkTazmini.Checked = False And ChkVosol.Checked = False Then
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

            If ChKMon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    If (CDbl(TxtMon1.Text) > CDbl(TxtMon2.Text)) Then
                        MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If (CDbl(TxtMon1.Text) = 0 And CDbl(TxtMon2.Text) = 0) Then
                    MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
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

            '''''''''''''''''''''''''''Set Condition
            Dim ListPeople As String = ""
            If Not (ChkOther.Checked = True And RdoOnlyChk.Checked = True) Then
                Dim CountPeople As Long = 0
                ListPeople = " AND ( "
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_SelectP", i).Value = True Then
                        ListPeople &= "IdPeople =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                        CountPeople += 1
                    End If
                Next
                If CountPeople = DGV2.RowCount Then
                    If ChkOther.Checked = True And RdoAllChk.Checked = True Then
                        ListPeople = ""
                    Else
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                    End If

                ElseIf CountPeople <= 0 Then
                    MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    If ChkOther.Checked = True And RdoAllChk.Checked = True Then
                        ListPeople &= " IdPeople IS NULL OR "
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                    Else
                        ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                        ListPeople &= ")"
                    End If
                End If
            Else
                ListPeople = " AND (IdPeople IS NULL)"
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
            If ChkBrat.Checked = True Then
                If ChkDar.Checked = True Or ChkBargasht.Checked = True Or ChkTazmini.Checked = True Then
                    Kind &= " OR Current_State=4 "
                Else
                    Kind &= " Current_State=4 "
                End If
            End If
            If ChkVosol.Checked = True Then
                If ChkDar.Checked = True Or ChkBargasht.Checked = True Or ChkTazmini.Checked = True Or ChkBrat.Checked = True Then
                    Kind &= " OR Current_State=1 "
                Else
                    Kind &= " Current_State=1 "
                End If
            End If
            Kind &= ")"
            '''''''''''''''''''''''''''''''''''
            Dim Sort As String = ""
            If RdoDate.Checked = True Then
                Sort = " ORDER BY PayDate"
            ElseIf RdoMon.Checked = True Then
                Sort = " ORDER BY MoneyChk"
            ElseIf RdoPeople.Checked = True Then
                Sort = " ORDER BY Nam"
            End If

            Dim dat As String = ""
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
            

            Dim Mon As String = ""
            If ChKMon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    Mon = " AND ( MoneyChk >=" & CDbl(TxtMon1.Text) & " AND MoneyChk <=" & CDbl(TxtMon2.Text) & ")"
                ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                    Mon = " AND ( MoneyChk >=" & CDbl(TxtMon1.Text) & ")"
                ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                    Mon = " AND ( MoneyChk <=" & CDbl(TxtMon2.Text) & ")"
                End If
            End If
            Dim visitor As String = ""
            If ChkVisitor.Checked = True Then
                visitor = " AND ID IN (SELECT Id FROM Chk_Get_Pay WHERE (([Type]=3 Or [Type]=5) AND Kind=0 AND  Number_Type IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdVisitor =" & TxtIdVisitor.Text & ")) Or ([Type]=12 AND Kind=0 AND Number_Type IN (SELECT Idsanad From PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdVisitor =" & TxtIdVisitor.Text & "))))"
            End If

            Dim user As String = ""
            If ChkUser.Checked = True Then
                user = " AND ID IN (SELECT ID FROM Chk_Get_Pay WHERE IdUser=" & TxtIdUser.Text & ")"
            End If

            Me.Enabled = False
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اسناد دریافتی", "تهیه گزارش", "", "")

            FrmPrint.PrintSQl = "SELECT Tell,NumState AS StateChk ,[GetDate],ID,PayDate,MoneyChk As Mon,NumChk,Shobeh,N_Bank As Bank,Number_N As NumBank,Nam FROM (SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell ,Chk_Id .IdPeople, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Tell=N'',Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Tell=N'',Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Tell=N'',Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) ) As ListGetChk  " & Kind & ListPeople & dat & Mon & visitor & user & Sort
            FrmPrint.CHoose = "REPORTGETCHK"
            FrmPrint.Str1 = "گزارش اسناد دریافتی"
            FrmPrint.ShowDialog()
            Me.Enabled = True

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportGetChk", "BtnOk_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_GetChk.htm")
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
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnSendSMS.Enabled = True Then Call BtnSendSMS_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub RdoOnlyChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOnlyChk.CheckedChanged
        If RdoOnlyChk.Checked = True Then
            ChkAllp.Checked = False
            GroupBox5.Enabled = False
        Else
            ChkAllp.Checked = True
            GroupBox5.Enabled = True
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

    Private Sub BtnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendSMS.Click
        If SMS = False Then
            MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ChkTazmini.Checked = True Then
            MessageBox.Show("نباید از چکهای تضمینی استفاده شود SMS جهت ارسال", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not (ChkOther.Checked = True And RdoOnlyChk.Checked = True) Then
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("طرف حسابی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If ChkDar.Checked = False And ChkBargasht.Checked = False And ChkBrat.Checked = False And ChkTazmini.Checked = False And ChkVosol.Checked = False Then
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

        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                If (CDbl(TxtMon1.Text) > CDbl(TxtMon2.Text)) Then
                    MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If (CDbl(TxtMon1.Text) = 0 And CDbl(TxtMon2.Text) = 0) Then
                MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
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

        '''''''''''''''''''''''''''Set Condition
        Dim ListPeople As String = ""
        If Not (ChkOther.Checked = True And RdoOnlyChk.Checked = True) Then
            Dim CountPeople As Long = 0
            ListPeople = " AND ( "
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Item("Cln_SelectP", i).Value = True Then
                    ListPeople &= "IdPeople =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                    CountPeople += 1
                End If
            Next
            If CountPeople = DGV2.RowCount Then
                If ChkOther.Checked = True And RdoAllChk.Checked = True Then
                    ListPeople = ""
                Else
                    ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                    ListPeople &= ")"
                End If

            ElseIf CountPeople <= 0 Then
                MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If ChkOther.Checked = True And RdoAllChk.Checked = True Then
                    ListPeople &= " IdPeople IS NULL OR "
                    ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                    ListPeople &= ")"
                Else
                    ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
                    ListPeople &= ")"
                End If
            End If
        Else
            ListPeople = " AND (IdPeople IS NULL)"
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
        If ChkBrat.Checked = True Then
            If ChkDar.Checked = True Or ChkBargasht.Checked = True Or ChkTazmini.Checked = True Then
                Kind &= " OR Current_State=4 "
            Else
                Kind &= " Current_State=4 "
            End If
        End If
        If ChkVosol.Checked = True Then
            If ChkDar.Checked = True Or ChkBargasht.Checked = True Or ChkTazmini.Checked = True Or ChkBrat.Checked = True Then
                Kind &= " OR Current_State=1 "
            Else
                Kind &= " Current_State=1 "
            End If
        End If
        Kind &= ")"
        '''''''''''''''''''''''''''''''''''
        Dim Sort As String = ""
        If RdoDate.Checked = True Then
            Sort = " ORDER BY PayDate"
        ElseIf RdoMon.Checked = True Then
            Sort = " ORDER BY MoneyChk"
        ElseIf RdoPeople.Checked = True Then
            Sort = " ORDER BY Nam"
        End If

        Dim dat As String = ""
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


        Dim Mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                Mon = " AND ( MoneyChk >=" & CDbl(TxtMon1.Text) & " AND MoneyChk <=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                Mon = " AND ( MoneyChk >=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                Mon = " AND ( MoneyChk <=" & CDbl(TxtMon2.Text) & ")"
            End If
        End If
        Dim visitor As String = ""
        If ChkVisitor.Checked = True Then
            visitor = " AND ID IN (SELECT Id FROM Chk_Get_Pay WHERE (([Type]=3 Or [Type]=5) AND Kind=0 AND  Number_Type IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdVisitor =" & TxtIdVisitor.Text & ")) Or ([Type]=12 AND Kind=0 AND Number_Type IN (SELECT Idsanad From PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdVisitor =" & TxtIdVisitor.Text & "))))"
        End If

        Dim user As String = ""
        If ChkUser.Checked = True Then
            user = " AND ID IN (SELECT Id FROM Chk_Get_Pay WHERE (([Type]<=10 ) AND Kind=0 AND Number_Type IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdUser =" & TxtIdUser.Text & ")) Or ([Type]=12 AND Kind =0 AND Number_Type IN (SELECT Idsanad From PayLimitFrosh WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE Activ =1 AND IdUser =" & TxtIdUser.Text & "))))"
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اسناد دریافتی", "SMS ارسال", "", "")

        Using FrmT As New SendAllSMSChk
            FrmT.Query = "SELECT Tell,NumState AS StateChk ,PayDate,MoneyChk As Mon,NumChk,Nam FROM (SELECT ISNULL(Define_People.Tell2,'') As Tell ,Chk_Id .IdPeople, NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) UNION ALL SELECT Tell=N'',Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Tell=N'',Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1)  UNION All SELECT Tell=N'',Chk_Id .IdPeople,NumState=CASE Current_State WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی'  WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END,Current_State,Current_Number_Type,Chk_Get_Pay.GetDate,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) ) As ListGetChk  " & Kind & ListPeople & dat & Mon & visitor & user & Sort
            FrmT.ShowDialog()
        End Using

    End Sub

    Private Sub TxtUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUser.TextChanged

    End Sub

    Private Sub TxtVisitor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVisitor.TextChanged

    End Sub
End Class