Imports System.Data.SqlClient
Public Class FrmChart_Charge


    Private Sub FrmOtherReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmOtherReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F134")
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
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()

        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate3.Enabled = False
        FarsiDate4.Enabled = False
        FarsiDate3.ThisText = GetDate()
        FarsiDate4.ThisText = GetDate()
        Me.GetCharge()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetCharge()
        Try
            Dim dv As New DataView
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            Dta = New SqlDataAdapter("SELECT  Define_Charge.nam, Define_Charge.ID, Define_OneCharge.NamOne FROM Define_Charge INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id", DataSource)
            Dta.Fill(Ds, "Define_Charge")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Charge").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReport_Charge", "GetCharge")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("هزینه ای وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("محدوده تاریخ مشخص نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If ChkAzDate.Checked = True Then
                If String.IsNullOrEmpty(FarsiDate3.ThisText) Then
                    MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If ChkTaDate.Checked = True Then
                If String.IsNullOrEmpty(FarsiDate4.ThisText) Then
                    MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate3.ThisText > FarsiDate4.ThisText Then
                    MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Else
            If String.IsNullOrEmpty(FarsiDate1.ThisText) Then
                MessageBox.Show("تاریخ مبدا را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FarsiDate1.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                MessageBox.Show("تاریخ مقصد را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FarsiDate2.Focus()
                Exit Sub
            End If

            If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FarsiDate1.Focus()
                Exit Sub
            End If

        End If

        Dim Dat As String = ""
        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                Dat = "(D_date>=N'" & FarsiDate3.ThisText & "' AND D_date<=N'" & FarsiDate4.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                Dat = "(D_date>=N'" & FarsiDate3.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                Dat = "(D_date<=N'" & FarsiDate4.ThisText & "')"
            End If
        End If

        Dim ListCharge As String = ""
        Dim ListCharge2 As String = ""
        Dim CountCharge As Long = 0
        ListCharge = " AND ("
        ListCharge2 = " WHERE ("
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListCharge &= "Define_Charge.ID=" & DGV.Item("Cln_Id", i).Value & " OR "
                ListCharge2 &= "Define_Charge.ID=" & DGV.Item("Cln_Id", i).Value & " OR "
                FrmPrint.Str2 = "نوع هزینه : " & DGV.Item("Cln_OneGroup", i).Value & " _ " & DGV.Item("Cln_Nam", i).Value
                CountCharge += 1
            End If
        Next

        If CountCharge = DGV.RowCount Then
            ListCharge = ""
            ListCharge2 = ""
            FrmPrint.Str2 = "نوع هزینه : ترکیبی"
        ElseIf CountCharge <= 0 Then
            MessageBox.Show("هزینه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListCharge = ListCharge.Substring(0, ListCharge.Length - 4)
            ListCharge &= ")"

            ListCharge2 = ListCharge2.Substring(0, ListCharge2.Length - 4)
            ListCharge2 &= ")"
            If CountCharge > 1 Then FrmPrint.Str2 = "نوع هزینه : ترکیبی"
        End If

        Me.Enabled = False

        FrmPrint.State = FarsiDate1.ThisText
        FrmPrint.IdFactor = FarsiDate2.ThisText
        If RdoLine.Checked = True Then
            FrmPrint.Lend = "LINE"
        ElseIf RdoPie.Checked = True Then
            FrmPrint.Lend = "PIE"
        ElseIf RdoBar.Checked = True Then
            FrmPrint.Lend = "BAR"
        End If

        If ChkTime.Checked = False Then
            If RdoDay.Checked = True Then
                FrmPrint.CHoose = "CHART-DAYCHARGE"
            ElseIf RdoWeek.Checked = True Then
                FrmPrint.CHoose = "CHART-WEEKCHARGE"
            ElseIf RdoMonth.Checked = True Then
                FrmPrint.CHoose = "CHART-MONTHCHARGE"
            End If
            FrmPrint.PrintSQl = "SELECT D_date As T,SUM(BedMon-BesMon) As Mandeh FROM (SELECT Define_Charge.ID,D_date,NamOne +'_'+nam  AS NamCharge,BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ),BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END ) FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1  AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & ListCharge & " UNION ALL SELECT  Define_Charge.ID,D_date,NamOne +'_'+nam  AS NamCharge,BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ),BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END )FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1  AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & ListCharge & " UNION ALL SELECT Define_Charge.ID,D_date,NamOne +'_'+nam  AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & ListCharge & " UNION All SELECT Define_Charge.ID,D_date,NamOne +'_'+nam  AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & ListCharge & ") As ListCharge GROUP BY D_date ORDER By D_date"
        Else
            FrmPrint.CHoose = "CHART-CHARGE"
            FrmPrint.PrintSQl = "SELECT NamCharge As T,(ISNULL(SUM(BedMon),0) -ISNULL(SUM(BesMon),0)) As Mandeh FROM (SELECT D_date,nam AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaFactorCharge INNER JOIN ListFactorCharge ON KalaFactorCharge.IdSanad = ListFactorCharge.Id INNER JOIN Define_Charge ON KalaFactorCharge.IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id " & ListCharge2 & If(String.IsNullOrEmpty(ListCharge2), If(String.IsNullOrEmpty(Dat), "", " WHERE " & Dat), If(String.IsNullOrEmpty(Dat), "", " AND " & Dat)) & " UNION All SELECT D_date,nam AS NamCharge,Mon As BedMon,BesMon=0 FROM  KalaOtherCharge  INNER JOIN ListOtherCharge  ON KalaOtherCharge .IdSanad = ListOtherCharge .Id INNER JOIN Define_Charge ON KalaOtherCharge .IdCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id " & ListCharge2 & If(String.IsNullOrEmpty(ListCharge2), If(String.IsNullOrEmpty(Dat), "", " WHERE " & Dat), If(String.IsNullOrEmpty(Dat), "", " AND " & Dat)) & " UNION ALL SELECT D_date ,nam  AS NamCharge, BedMon=(CASE WHEN Get_Pay_Amval.[State]=0 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Amval.[State]=1 THEN lend ELSE 0 END ) FROM Get_Pay_Amval INNER JOIN Define_Charge ON Get_Pay_Amval.LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 " & ListCharge & If(String.IsNullOrEmpty(Dat), "", " AND " & Dat) & "  UNION ALL SELECT D_date ,nam  AS NamCharge, BedMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=1 THEN lend ELSE 0 END ) ,BesMon=(CASE WHEN Get_Pay_Sarmayeh .[State]=0 THEN lend ELSE 0 END ) FROM Get_Pay_Sarmayeh  INNER JOIN Define_Charge ON Get_Pay_Sarmayeh .LendCharge = Define_Charge.ID INNER JOIN Define_OneCharge ON Define_Charge.IdOne = Define_OneCharge.Id WHERE (Lend >0 AND LendCharge IS NOT NULL) AND Active =1 " & ListCharge & If(String.IsNullOrEmpty(Dat), "", " AND " & Dat) & " )AS AllCharge GROUP By NamCharge  ORDER BY NamCharge"
        End If


        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "نمودار هزینه", "تهیه گزارش", "", "")

        FrmPrint.Str1 = "نمودار هزینه"
        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Charge_List
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
        Dim frmlk As New Charge_List
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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepNhazine.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetCharge()
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

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            GroupBox3.Enabled = False
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate3.Enabled = True
            FarsiDate3.ThisText = GetDate()
            FarsiDate4.Enabled = True
            FarsiDate4.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
        Else
            GroupBox3.Enabled = True
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate3.Enabled = False
            FarsiDate3.ThisText = GetDate()
            FarsiDate4.Enabled = False
            FarsiDate4.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub ChkAzDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkAzDate.Checked = True Then
            FarsiDate3.ThisText = GetDate()
            FarsiDate3.Enabled = True
            FarsiDate3.Focus()
        Else
            FarsiDate3.Enabled = False
            FarsiDate3.ThisText = GetDate()
        End If
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate4.ThisText = GetDate()
            FarsiDate4.Enabled = True
            FarsiDate4.Focus()
        Else
            FarsiDate4.Enabled = False
            FarsiDate4.ThisText = GetDate()
        End If
    End Sub
End Class