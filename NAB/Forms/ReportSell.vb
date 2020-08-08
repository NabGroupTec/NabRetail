Imports System.Data.SqlClient
Public Class ReportSell

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
        Access_Form = Get_Access_Form("F71")
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
        RdoPeople.Enabled = False
        RdoListKala.Enabled = False
        RdoGroup.Enabled = False
        RdoPeople.Checked = False
        RdoListKala.Checked = False
        RdoPeopleGroup.Enabled = False
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
            sqlstr = "SELECT Define_Kala.Activ,Define_Kala.Id,Define_Kala.Nam , Define_OneGroup.NamOne +'-'+ Define_TwoGroup.NamTwo As GroupKala FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  Order by NamOne ,NamTwo ,Nam"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportSell", "GetKala")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportSell", "GetPeople")
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

        If ChkVisitor.Checked = True Then
            If String.IsNullOrEmpty(TxtVisitor.Text) Or String.IsNullOrEmpty(TxtIdVisitor.Text) Then
                MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtVisitor.Focus()
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

        If ChkAnbar.Checked = True Then
            If String.IsNullOrEmpty(TxtAnbarNam.Text) Or String.IsNullOrEmpty(TxtIdAnbar.Text) Then
                MessageBox.Show("انبار را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtAnbarNam.Focus()
                Exit Sub
            End If
        End If

        Dim dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            dat = " AND (D_date <=N'" & FarsiDate2.ThisText & "')"
        End If

        Dim Part As String = ""
        If ChkPart.Checked = True Then
            Part = " AND ListFactorSell.Part =" & TxtIdPart.Text & " "
        End If
        Dim anbar As String = ""
        If ChkAnbar.Checked = True Then
            anbar = " AND  KalaFactorSell.IdAnbar =" & TxtIdAnbar.Text
        End If
        Dim ListKala As String = ""
        Dim CountKala As Long = 0
        ListKala = " AND ( "
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListKala &= "IDKala=" & DGV.Item("Cln_Id", i).Value & " OR "
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

        Dim visitor As String = ""
        If ChkVisitor.Checked = True Then
            visitor = " AND IdVisitor=" & CLng(TxtIdVisitor.Text)
        End If

        Dim User As String = ""
        If ChkUser.Checked = True Then
            User = " AND IdUser=" & CLng(TxtIdUser.Text)
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

        If ChkPart.Checked = False Then
            FrmPrint.Lend = ""
        Else
            FrmPrint.Lend = TxtPart.Text
        End If

        If ChkTime.Checked = False Then
            FrmPrint.Str1 = ""
            FrmPrint.State = ""
        Else
            If ChkAzDate.Checked = True Then FrmPrint.Str1 = FarsiDate1.ThisText
            If ChkTaDate.Checked = True Then FrmPrint.State = FarsiDate2.ThisText
        End If
        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فروش کالا", "تهیه گزارش", "", "")

        If ChkAmani.Checked = False And ChkSum.Checked = False Then
            ' Dim str As String = "SELECT  KalaFactorSell.IdFactor, CAST (KolCount AS NvarChar(max)) As KolCount,CAST (JozCount AS NvarChar(max)) As JozCount,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP,Define_Anbar.nam  As Anbar FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Anbar ON Define_Anbar.ID =KalaFactorSell .IdAnbar WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & Sort
            FrmPrint.PrintSQl = "SELECT  KalaFactorSell.IdFactor, CAST (KolCount AS NvarChar(max)) As KolCount,CAST (JozCount AS NvarChar(max)) As JozCount,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP,Define_Anbar.nam  As Anbar FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Anbar ON Define_Anbar.ID =KalaFactorSell .IdAnbar WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & Sort
            FrmPrint.CHoose = "REPORTSELL"
        ElseIf ChkAmani.Checked = False And ChkSum.Checked = True Then
            If RdoPeople.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon,KalaNam ,GroupKala ,NamP  FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY NamP ,KalaNam ,GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTSELL"
            ElseIf RdoPeopleGroup.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon ,GroupKala ,NamP  FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY NamP ,GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTSELLPGROUP"
            ElseIf RdoListKala.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon,KalaNam ,GroupKala   FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY KalaNam ,GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTSELLKALA"
            ElseIf RdoGroup.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon ,GroupKala   FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTSELLGROUP"
            End If

        ElseIf ChkAmani.Checked = True And ChkSum.Checked = False Then
            FrmPrint.PrintSQl = "SELECT  KalaFactorSell.IdFactor, CAST (KolCount AS NvarChar(max)) As KolCount,CAST (JozCount AS NvarChar(max)) As JozCount,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP,Define_Anbar.nam  As Anbar FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Anbar ON Define_Anbar.ID =KalaFactorSell .IdAnbar  WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & Sort
            FrmPrint.CHoose = "REPORTASELL"
        ElseIf ChkAmani.Checked = True And ChkSum.Checked = True Then
            If RdoPeople.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon,KalaNam ,GroupKala ,NamP  FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY NamP ,KalaNam ,GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTASELL"
            ElseIf RdoPeopleGroup.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon ,GroupKala ,NamP  FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY NamP ,GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTSELLPGROUP"
            ElseIf RdoListKala.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon,KalaNam ,GroupKala  FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY KalaNam ,GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTASELLKALA"
            ElseIf RdoGroup.Checked = True Then
                FrmPrint.PrintSQl = "SELECT Cast (ISNULL(SUM(kolCount),0) As Nvarchar(max))As KolCount ,Cast (ISNULL(SUM(JozCount ),0)  As Nvarchar(Max)) As JozCount,ISNULL(AVG(Fe),0) As Fe,ISNULL(SUM(DarsadMon),0) As DarsadMon,ISNULL(SUM(Mon),0) As Mon ,GroupKala  FROM (SELECT   KolCount,JozCount ,Fe,DarsadMon, Mon,D_date, Define_Kala.Nam As KalaNam, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_People.Nam AS NamP FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5" & anbar & ListPeople & ListKala & dat & Part & visitor & User & If(Chkdiscount.Checked = False, "", " AND DarsadDiscount>=100 ") & ") As AllKaka GROUP BY GroupKala " & Sort
                FrmPrint.CHoose = "SUMREPORTASELLGROUP"
            End If
        End If
        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Sell.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
            Me.GetPeople()
        ElseIf e.KeyCode = Keys.F6 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
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
            RdoPeopleGroup.Enabled = True
            Rdodate.Enabled = False
            RdoMon.Checked = True
            RdoPeople.Enabled = True
            RdoGroup.Enabled = True
            RdoListKala.Enabled = True
            RdoPeople.Checked = True
        Else
            RdoPeopleGroup.Enabled = False
            Rdodate.Enabled = True
            RdoPeople.Enabled = False
            RdoListKala.Enabled = False
            RdoPeople.Checked = False
            RdoGroup.Enabled = False
            RdoGroup.Checked = False
            RdoListKala.Checked = False
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Using FrmAdVance As New Kala_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
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
        End Using
    End Sub

    Private Sub RdoListKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoListKala.CheckedChanged
        If RdoListKala.Checked = True Then
            RdoP.Enabled = False
            If RdoP.Checked = True Then RdoMon.Checked = True
        Else
            RdoP.Enabled = True
        End If
    End Sub

    Private Sub RdoGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoGroup.CheckedChanged
        If RdoGroup.Checked = True Then
            RdoP.Enabled = False
            RdoKala.Enabled = False
            RdoMon.Checked = True
        Else
            RdoP.Enabled = True
            RdoKala.Enabled = True
        End If
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

    Private Sub RdoPeopleGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoPeopleGroup.CheckedChanged
        If RdoPeopleGroup.Checked = True Then
            RdoKala.Enabled = False
            RdoMon.Checked = True
        Else
            RdoKala.Enabled = True
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

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
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

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
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

    Private Sub TxtAnbarNam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAnbarNam.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Anbar_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtAnbarNam.Focus()
        If Tmp_Namkala <> "" Then
            TxtIdAnbar.Text = IdKala
            TxtAnbarNam.Text = Tmp_Namkala
        Else
            TxtIdAnbar.Text = ""
            TxtAnbarNam.Text = ""
        End If
    End Sub

    Private Sub ChkAnbar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnbar.CheckedChanged
        If ChkAnbar.Checked = True Then
            TxtAnbarNam.Enabled = True
            TxtAnbarNam.Focus()
        Else
            TxtAnbarNam.Enabled = False
            TxtAnbarNam.Text = ""
            TxtIdAnbar.Text = ""
        End If
    End Sub
End Class