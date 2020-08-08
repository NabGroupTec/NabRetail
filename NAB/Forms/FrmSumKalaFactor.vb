Imports System.Data.SqlClient
Public Class FrmSumKalaFactor

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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_SumFact.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
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
        Access_Form = Get_Access_Form("F103")
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
        DGV.Columns("Cln_People").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If ChkExit.Checked = True Then BtnReport_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try
            DGV.DataSource = Nothing
            Button1.Enabled = False
            ChkAll.Checked = False
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

            If ChkExit.Checked = True Then
                If String.IsNullOrEmpty(TxtExit.Text) Then
                    MessageBox.Show("هیچ خروجی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtExit.Focus()
                    Exit Sub
                End If
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
            '''''''''''''''''''''''
            Me.Enabled = False
            Dim Dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            If ChkExit.Checked = False Then
                If RdoFrosh.Checked = True Then
                    Using CMD As New SqlCommand("SELECT IdFactor,D_date, Nam FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & Part & Fac & Dat & " ORDER BY IdFactor", ConectionBank)
                        Dt.Load(CMD.ExecuteReader)
                    End Using
                ElseIf RdoBack.Checked = True Then
                    Using CMD As New SqlCommand("SELECT IdFactor,D_date, Nam FROM  ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID  WHERE(ListFactorBackSell.Activ = 1) " & Part & Fac & Dat & " ORDER BY IdFactor", ConectionBank)
                        Dt.Load(CMD.ExecuteReader)
                    End Using
                End If
            Else
                If RdoFrosh.Checked = True Then
                    Using CMD As New SqlCommand("SELECT ListFactorSell.IdFactor,D_date,Nam FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN ListExitFactor ON  ListFactorSell.IdFactor =ListExitFactor.IdFactor WHERE(ListFactorSell.Activ = 1 And ListFactorSell.Stat = 3) " & FacExit & " ORDER BY Priority", ConectionBank)
                        Dt.Load(CMD.ExecuteReader)
                    End Using
                ElseIf RdoBack.Checked = True Then
                    Using CMD As New SqlCommand("SELECT ListFactorBackSell.IdFactor,D_date,Nam FROM  ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN ListExitFactor ON  ListFactorBackSell.IdFacSell =ListExitFactor.IdFactor WHERE (ListFactorBackSell.Activ = 1) " & FacExit.Replace("ListFactorSell.IdFactor", "ListFactorBackSell.IdFacSell") & " ORDER BY Priority", ConectionBank)
                        Dt.Load(CMD.ExecuteReader)
                    End Using
                End If

            End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.AutoGenerateColumns = False
            DGV.DataSource = Dt
            If DGV.RowCount > 0 Then
                Button1.Enabled = True
                ChkAll.Checked = True
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "جمع کالای فاکتور", "لیست فاکتور", "", "")

            Me.Enabled = True

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSumKalaFactor", "BtnReport_Click")
            Me.Enabled = True
        End Try
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSumKalaFactor", "Get_Ostan")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSumKalaFactor", "Get_City")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSumKalaFactor", "Get_Part")
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

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV.Rows.Count <= 0 Then
                MessageBox.Show("هیچ فاکتوری جهت تهیه گزارش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim count As Long = 0
            Dim tmp As String = ""
            For i As Integer = 0 To DGV.RowCount - 1
                If DGV.Item("Cln_Select", i).Value = True Then
                    tmp &= "IdFactor=" & DGV.Item("Cln_Fac", i).Value & " OR "
                    count += 1
                End If
            Next

            If count <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(tmp) Then
                tmp = " WHERE (" & tmp
                tmp = tmp.Substring(0, tmp.Length - 3)
                tmp = tmp & ")"
            End If

            If ChkExit.Checked = True Then
                Tmp_String1 = TxtExit.Text.Trim
            Else
                Tmp_String1 = ""
            End If

            Dim sort As String = ""
            If RdoGroup.Checked = True Then
                sort = " ORDER BY IdKala"
            ElseIf RdoKala.Checked = True Then
                sort = " ORDER BY Nam"
            End If
            Me.Enabled = False
            Tmp_OneGroup = ""
            Tmp_String2 = ""
            Using FPrint As New FrmPrint
                Dim Counter As Long = 0
                For j As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Select", j).Value = True Then
                        Counter += 1
                        Tmp_OneGroup &= DGV.Item("Cln_Fac", j).Value & "-"
                    End If
                Next
                Tmp_String2 = Tmp_OneGroup

                If RdoFrosh.Checked = True Then
                    Tmp_OneGroup = "تعداد فاکتورفروش : " & If(Counter <= 0, DGV.RowCount, Counter) & "    لیست فاکتورفروش:( " & Tmp_OneGroup.Substring(0, Tmp_OneGroup.Length - 1) & ")"
                ElseIf RdoBack.Checked = True Then
                    Tmp_OneGroup = "تعداد فاکتوربرگشتی : " & If(Counter <= 0, DGV.RowCount, Counter) & "    لیست فاکتوربرگشتی:( " & Tmp_OneGroup.Substring(0, Tmp_OneGroup.Length - 1) & ")"
                End If

                If RdoFrosh.Checked = True Then
                    FPrint.PrintSQl = "SELECT kol,Joz,ListKala.Nam,Vahed,IdKala,REPLACE(ROUND(ISNULL((WK_JOZ * (CASE WHEN Joz>0 THEN Joz ELSE Kol END)),0),2),'.','/') AS Wgt,ListKala.DK,ListKala.DK_KOL,ListKala.DK_JOZ  FROM (SELECT ROUND(ISNULL(SUM(KolCount),0),2) AS Kol,ROUND(ISNULL(SUM(JozCount),0),2) AS Joz,IdKala,Define_Vahed.Nam As Vahed,Define_Kala.Nam,Define_Kala.DK,Define_Kala.DK_KOL,Define_Kala.DK_JOZ  FROM  KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Vahed ON Define_Vahed.Id =Define_Kala.IdVahed " & tmp & "  GROUP BY IdKala ,Define_Kala.Nam,Define_Vahed.Nam,Define_Kala.DK,Define_Kala.DK_KOL,Define_Kala.DK_JOZ)  AS ListKala INNER JOIN Define_Kala ON Define_Kala.Id =ListKala.IdKala" & sort
                    FPrint.Lend = "F"
                Else
                    FPrint.PrintSQl = "SELECT kol,Joz,ListKala.Nam,Vahed,IdKala,REPLACE(ROUND(ISNULL((WK_JOZ * (CASE WHEN Joz>0 THEN Joz ELSE Kol END)),0),2),'.','/') AS Wgt,ListKala.DK,ListKala.DK_KOL,ListKala.DK_JOZ  FROM (SELECT ROUND(ISNULL(SUM(KolCount),0),2) AS Kol,ROUND(ISNULL(SUM(JozCount),0),2) AS Joz,IdKala,Define_Vahed.Nam As Vahed,Define_Kala.Nam,Define_Kala.DK,Define_Kala.DK_KOL,Define_Kala.DK_JOZ  FROM  KalaFactorBackSell INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Vahed ON Define_Vahed.Id =Define_Kala.IdVahed " & tmp & "  GROUP BY IdKala ,Define_Kala.Nam,Define_Vahed.Nam,Define_Kala.DK,Define_Kala.DK_KOL,Define_Kala.DK_JOZ)  AS ListKala INNER JOIN Define_Kala ON Define_Kala.Id =ListKala.IdKala" & sort
                    FPrint.Lend = "K"
                End If

                If ChkW.Checked = True Then
                    FPrint.CHoose = "SUMFACTOR"
                Else
                    FPrint.CHoose = "SUMFACTOR2"
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "جمع کالای فاکتور", "تهیه گزارش", "", "")

                FPrint.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSumKalaFactor", "Button1_Click")
        End Try
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub ChkExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkExit.CheckedChanged
        If ChkExit.Checked = True Then
            ChKfactor.Checked = False
            ChkTime.Checked = False
            ChkPart.Checked = False
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

    Private Sub RdoBack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBack.CheckedChanged
        If RdoBack.Checked = True Then
            DGV.DataSource = Nothing
            Button1.Enabled = False
            GroupBox4.Text = "لیست فاکتور برگشت از فروش"
        End If
    End Sub

    Private Sub RdoFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoFrosh.CheckedChanged
        If RdoFrosh.Checked = True Then
            DGV.DataSource = Nothing
            Button1.Enabled = False
            GroupBox4.Text = "لیست فاکتور فروش"
        End If
    End Sub
End Class