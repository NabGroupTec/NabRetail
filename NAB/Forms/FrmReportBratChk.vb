Imports System.Data.SqlClient
Public Class FrmReportBratChk

    Private Sub FrmReportBratChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmReportBratChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F92")
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
        Me.GetBank()
        ChkAllp.Checked = True
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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
    Private Sub GetBank()
        Try
            Dim dv As New DataView
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("SELECT ID,N_bank,Number_N,State FROM Define_Bank", DataSource)
            Dta.Fill(Ds, "Define_Bank")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Bank").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "bank_List", "GetBank")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub ChkAllp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllp.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAllp.Checked
        Next
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
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

        Dim Sort As String = ""
        If RdoDate.Checked = True Then
            Sort = " ORDER BY PayDate"
        ElseIf RdoMon.Checked = True Then
            Sort = " ORDER BY MoneyChk"
        ElseIf RdoPeople.Checked = True Then
            Sort = " ORDER BY Nam"
        End If

        Dim ListPeople As String = ""
        Dim CountPeople As Long = 0
        ListPeople = " WHERE ( "

        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListPeople &= "IdBank =" & DGV.Item("Cln_IdP", i).Value & " OR "
                CountPeople += 1
            End If
        Next

        If CountPeople = DGV.RowCount Then
            ListPeople = ""
        ElseIf CountPeople <= 0 Then
            MessageBox.Show("بانکی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
            ListPeople &= ")"
        End If

        Dim dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            dat = " AND (PayDate>=N'" & FarsiDate1.ThisText & "' AND PayDate <=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            dat = " AND (PayDate>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            dat = " AND (PayDate <=N'" & FarsiDate2.ThisText & "')"
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

        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اسناد براتی", "تهیه گزارش", "", "")

        FrmPrint.PrintSQl = "SELECT BratDate,PayDate ,MoneyChk ,NumChk ,ListBratChk.Shobeh ,ListBratChk.N_Bank ,ListBratChk.Number_N ,ListBratChk.Nam ,Define_Bank .n_bank AS Bank,Define_Bank.shobeh AS Sho ,Define_Bank.number_n AS Num FROM (SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION ALL SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4) UNION All SELECT Chk_Id .D_date AS BratDate ,Chk_Id .IdBank,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =4)) As ListBratChk INNER JOIN Define_Bank ON Define_Bank.ID =ListBratChk.IdBank " & ListPeople & dat & Mon & Sort
        FrmPrint.CHoose = "REPORTBRATCHK"
        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_IdP", i).Value = IdKala Then
                        DGV.Item("Cln_Nam", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item("Cln_Nam", 0).Selected = True
                DGV.Item("Cln_Nam", 0).Selected = False
            End If
        End If
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_BaratChk.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetBank()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class