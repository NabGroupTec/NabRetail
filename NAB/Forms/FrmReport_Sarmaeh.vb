Imports System.Data.SqlClient
Public Class FrmReport_Sarmaeh

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

    Private Sub FrmOtherReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmOtherReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F88")
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
        Me.GetSarmayeh()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetSarmayeh()
        Try
            Dim dv As New DataView
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            Dta = New SqlDataAdapter("SELECT  Define_Sarmayeh.nam, Define_Sarmayeh.ID, Define_OneSarmayeh.NamOne FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh.IdOne = Define_OneSarmayeh.Id", DataSource)
            Dta.Fill(Ds, "Define_Sarmayeh")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Sarmayeh").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReport_Sarmayeh", "GetSarmayeh")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("سرمایه ای وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        Dim ListCharge As String = ""
        Dim CountCharge As Long = 0
        ListCharge = " WHERE ("
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListCharge &= "Define_Sarmayeh.ID=" & DGV.Item("Cln_Id", i).Value & " OR "
                CountCharge += 1
            End If
        Next

        If CountCharge = DGV.RowCount Then
            ListCharge = ""
        ElseIf CountCharge <= 0 Then
            MessageBox.Show("سرمایه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListCharge = ListCharge.Substring(0, ListCharge.Length - 4)
            ListCharge &= ")"
        End If

        Dim Dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            Dat = "(D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            Dat = "(D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            Dat = "(D_date<=N'" & FarsiDate2.ThisText & "')"
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
        If ChkMonAll.Checked = False Then
            FrmPrint.PrintSQl = "SELECT  D_date,NamOne + '-' + Nam + ISNULL('  ' + AllDisc,'') As Namcharge,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0.0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0.0 END ,T=N'  ' ,Mandeh=0.0  FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id " & ListCharge & If(String.IsNullOrEmpty(ListCharge), If(String.IsNullOrEmpty(Dat), "", " WHERE " & Dat), If(String.IsNullOrEmpty(Dat), "", " AND " & Dat)) & "UNION ALL SELECT D_date=N'',Namcharge=N'سرمایه اول دوره ' + nam ,BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END,T=N'  ', Mandeh=0.0 FROM Define_Sarmayeh " & ListCharge & " ORDER BY D_date"
            FrmPrint.CHoose = "SARMAYEH"
        Else
            If RdoTwo.Checked = True Then
                FrmPrint.PrintSQl = "SELECT NamCharge ,ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon ,T ,ISNULL(SUM(Mandeh),0) As Mandeh  FROM (SELECT  D_date,NamOne + '-' + Nam  As Namcharge,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0.0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0.0 END ,T=N'  ' ,Mandeh=0.0  FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id " & ListCharge & If(String.IsNullOrEmpty(ListCharge), If(String.IsNullOrEmpty(Dat), "", " WHERE " & Dat), If(String.IsNullOrEmpty(Dat), "", " AND " & Dat)) & " UNION ALL SELECT D_date=N'',NamOne + '-' + Nam  As Namcharge ,BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END,T=N'  ', Mandeh=0.0 FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id " & ListCharge & "  )AS AllCharge GROUP By NamCharge ,T ORDER BY NamCharge"
            Else
                FrmPrint.PrintSQl = "SELECT NamCharge ,ISNULL(SUM(BedMon),0) As BedMon ,ISNULL(SUM(BesMon),0) As BesMon ,T ,ISNULL(SUM(Mandeh),0) As Mandeh  FROM (SELECT  D_date,NamOne  As Namcharge,BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0.0 END , BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0.0 END ,T=N'  ' ,Mandeh=0.0  FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id " & ListCharge & If(String.IsNullOrEmpty(ListCharge), If(String.IsNullOrEmpty(Dat), "", " WHERE " & Dat), If(String.IsNullOrEmpty(Dat), "", " AND " & Dat)) & " UNION ALL SELECT D_date=N'',NamOne  As Namcharge ,BedMon=CASE Define_Sarmayeh .STAT WHEN N'بدهکار' THEN AllMoney ELSE 0 END, BesMon=CASE Define_Sarmayeh .STAT WHEN N'بستانکار' THEN AllMoney ELSE 0 END,T=N'  ', Mandeh=0.0 FROM Define_Sarmayeh INNER JOIN Define_OneSarmayeh ON Define_Sarmayeh .IdOne =Define_OneSarmayeh.Id " & ListCharge & "  )AS AllCharge GROUP By NamCharge ,T ORDER BY NamCharge"
            End If
            FrmPrint.CHoose = "SUMSARMAYEH"
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سرمایه", "تهیه گزارش", "", "")

        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Sarmayeh_List
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Id", i).Value = IdKala Then
                        DGV.Item("Cln_Nam", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item(0, 0).Selected = True
                DGV.Item(0, 0).Selected = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Sarmayeh_List
        frmlk.ChkAll.Visible = True
        frmlk.DGV.Columns("Cln_select").Visible = True
        frmlk.ShowDialog()

        Try
            If AllSelectKala.Length > 0 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    For j As Integer = 0 To AllSelectKala.Length - 1
                        If AllSelectKala(j).IdKala = DGV.Item("Cln_Id", i).Value Then DGV.Item("Cln_Select", i).Value = True
                    Next
                Next
                Array.Resize(AllSelectKala, 0)
            End If
            DGV.Focus()
        Catch ex As Exception
            Array.Resize(AllSelectKala, 0)
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Sarmaye.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetSarmayeh()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub ChkMonAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMonAll.CheckedChanged
        If ChkMonAll.Checked = True Then
            RdoOne.Enabled = True
            RdoTwo.Enabled = True
            RdoTwo.Checked = True
        Else
            RdoOne.Enabled = False
            RdoTwo.Enabled = False
            RdoOne.Checked = False
            RdoTwo.Checked = False
        End If
    End Sub
End Class