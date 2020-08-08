Imports System.Data.SqlClient
Public Class ReportService

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

    Private Sub FrmSodNKhales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmSodNKhales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F74")
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
        Me.GetKala()
        Me.GetPeople()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_NamP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetKala()
        Try
            Dim dv As New DataView
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()

            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT ID, nam FROM Define_Service  Order by Nam"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Service")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Service").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportService", "GetKala")
            Me.Close()
        End Try
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportService", "GetPeople")
            Me.Close()
        End Try
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
        If CBool(DGV.Item("Cln_Active", e.RowIndex).Value) = True Then
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("کالایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("طرف حسابی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If ChkPart.Checked = True Then
            If String.IsNullOrEmpty(TxtIdPart.Text) Or String.IsNullOrEmpty(TxtPart.Text) Then
                MessageBox.Show("پارت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Dim Part As String = ""
        If ChkPart.Checked = True Then
            Part = " AND ListFactorService.Part =" & TxtIdPart.Text & " "
        End If

        Dim dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            dat = " AND (D_date <=N'" & FarsiDate2.ThisText & "')"
        End If
        Dim ListKala As String = ""
        Dim CountKala As Long = 0
        ListKala = " AND ( "
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListKala &= "IdService=" & DGV.Item("Cln_Id", i).Value & " OR "
                CountKala += 1
            End If
        Next
        If CountKala = DGV.RowCount Then
            ListKala = ""
        ElseIf CountKala <= 0 Then
            MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListKala = ListKala.Substring(0, ListKala.Length - 4)
            ListKala &= ")"
        End If

        Dim ListPeople As String = ""
        Dim CountPeople As Long = 0
        ListPeople = " AND ( "
        For i As Integer = 0 To DGV2.RowCount - 1
            If DGV2.Item("Cln_SelectP", i).Value = True Then
                ListPeople &= "Define_People.ID =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                CountPeople += 1
            End If
        Next
        If CountPeople = DGV2.RowCount Then
            ListPeople = ""
        ElseIf CountPeople <= 0 Then
            MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
            ListPeople &= ")"
        End If
        Dim Sort As String = ""
        If Rdodate.Checked = True Then
            Sort = " ORDER BY D_Date"
        ElseIf RdoMon.Checked = True Then
            Sort = " ORDER BY Mon"
        ElseIf RdoP.Checked = True Then
            Sort = " ORDER BY NamP"
        ElseIf RdoKala.Checked = True Then
            Sort = " ORDER BY GroupKala,KalaNam"
        End If
        If ChkTime.Checked = False Then
            FrmPrint.Str1 = ""
            FrmPrint.State = ""
        Else
            If ChkAzDate.Checked = True Then FrmPrint.Str1 = FarsiDate1.ThisText
            If ChkTaDate.Checked = True Then FrmPrint.State = FarsiDate2.ThisText
        End If

        If ChkPart.Checked = False Then
            FrmPrint.Lend = ""
        Else
            FrmPrint.Lend = TxtPart.Text
        End If

        Me.Enabled = False
        If ChkSum.Checked = False Then
            FrmPrint.PrintSQl = "SELECT  KalaFactorService.IdFactor, CAST (KolCount AS NvarChar(max)) As KolCount,Fe,DarsadMon, Mon,D_date, Define_Service.Nam As KalaNam, N'کالای خدماتی' As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorService INNER JOIN ListFactorService ON KalaFactorService.IdFactor = ListFactorService.IdFactor INNER JOIN Define_Service ON KalaFactorService.IdService = Define_Service.Id  INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & ListPeople & ListKala & dat & Part & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & Sort
            FrmPrint.CHoose = "REPORTSERVICE"
        ElseIf ChkSum.Checked = True Then
            FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon,KalaNam ,GroupKala ,NamP  FROM (SELECT   KolCount ,Fe,DarsadMon, Mon,D_date, Define_Service.Nam As KalaNam, N'کالای خدماتی' As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorService INNER JOIN ListFactorService ON KalaFactorService.IdFactor = ListFactorService.IdFactor INNER JOIN Define_Service ON KalaFactorService.IdService = Define_Service.Id  INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & ListPeople & ListKala & dat & Part & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY NamP ,KalaNam ,GroupKala " & Sort
            FrmPrint.CHoose = "SUMREPORTSERVICE"
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خدمات", "تهیه گزارش", "", "")

        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Service_List
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Id", i).Value = IdKala Then
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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Khadamat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
            Me.GetPeople()
        ElseIf e.KeyCode = Keys.F7 Then
            If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
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

    Private Sub ChkAllp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllp.CheckedChanged
        If DGV2.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV2.RowCount - 1
            DGV2.Item("Cln_SelectP", i).Value = ChkAllp.Checked
        Next
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

    Private Sub ChkSum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSum.CheckedChanged
        If ChkSum.Checked = True Then
            Rdodate.Enabled = False
            RdoMon.Checked = True
        Else
            Rdodate.Enabled = True
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

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            TxtPart.Enabled = True
            TxtPart.Focus()
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
            TxtPart.Enabled = False
        End If
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
End Class