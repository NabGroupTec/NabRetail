Imports System.Data.SqlClient
Public Class FrmChartFroshCity

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
    Private Sub GetKala()
        Try
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
            DGV.DataSource = Ds.Tables("Define_Kala")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmChartFroshCity", "GetKala")
            Me.Close()
        End Try
    End Sub

    Private Sub GetCity()
        Try
            Dim DsP As New DataSet
            Dim DtaP As New SqlDataAdapter()
            DsP.Clear()
            If Not DtaP Is Nothing Then
                DtaP.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Define_City.Code As Id, Define_City.NamCI As Nam, Define_Ostan.NamO FROM Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan ORDER BY Define_Ostan.NamO"
            DtaP = New SqlDataAdapter(sqlstr, DataSource)
            DtaP.Fill(DsP, "Define_City")
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = DsP.Tables("Define_City")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmChartFroshCity", "GetCity")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmManageFrosh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmManageFrosh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F139")
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
        GetCity()
        GetKala()
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_NamP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If Kind_User = 0 Then
            ChkUser.Checked = True
            TxtUser.Text = NamUser
            TxtIdUser.Text = Id_User
            TxtUser.Enabled = False
            ChkUser.Enabled = False
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
        If CBool(DGV.Item("Cln_Active", e.RowIndex).Value) = True Then
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
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

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("کالایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("شهرستانی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If ChkGroup.Checked = True Then
            If String.IsNullOrEmpty(TxtGroup.Text) Or String.IsNullOrEmpty(TxtIdGroup.Text) Then
                MessageBox.Show("هیچ گروهی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtGroup.Focus()
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

        Dim ListKala As String = ""
        Dim namkala As String = "نام کالا :"
        Dim CountKala As Long = 0
        ListKala = " AND IdKala IN("
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListKala &= DGV.Item("Cln_Id", i).Value & ","
                namkala &= DGV.Item("Cln_Nam", i).Value & ","
                CountKala += 1
            End If
        Next
        If CountKala = DGV.RowCount Then
            ListKala = ""
            namkala = ""
        ElseIf CountKala <= 0 Then
            MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListKala = ListKala.Substring(0, ListKala.Length - 1)
            ListKala &= ")"
        End If

        Dim ListPeople As String = ""
        Dim TmpListPeople As String = ""
        Dim CountPeople As Long = 0
        Dim namOstan As String = ""
        Dim IdOstan As String = ""

        ListPeople = " WHERE ( "
        TmpListPeople = " WHERE ( "
        For i As Integer = 0 To DGV2.RowCount - 1
            If DGV2.Item("Cln_SelectP", i).Value = True Then
                ListPeople &= "Define_City.Code =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                TmpListPeople &= "IdCity =" & DGV2.Item("Cln_IdP", i).Value & " OR "

                namOstan = DGV2.Item("Cln_NamP", i).Value
                IdOstan = DGV2.Item("Cln_IdP", i).Value
                CountPeople += 1
            End If
        Next
        If CountPeople = DGV2.RowCount Then
            ListPeople = ""
            TmpListPeople = ""
        ElseIf CountPeople <= 0 Then
            MessageBox.Show("شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
            ListPeople &= ")"

            TmpListPeople = TmpListPeople.Substring(0, TmpListPeople.Length - 4)
            TmpListPeople &= ")"
        End If


        If CountPeople > 1 And ChkP.Checked = True Then
            MessageBox.Show("با فعال کردن محدودیت دوره ایی فقط یک شهرستان میتواند انتخاب شود", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            dat = " AND (D_date <=N'" & FarsiDate2.ThisText & "')"
        End If

        Dim Group As String = ""
        Dim namGroup As String = ""
        If ChkGroup.Checked = True Then
            Group = " (ChkIdGroup ='True' And IdGroup =" & TxtIdGroup.Text & ")"
            namGroup = "گروه ویژه:" & TxtGroup.Text
        End If

        Dim visitor As String = ""
        Dim Namvisitor As String = ""
        If ChkVisitor.Checked = True Then
            visitor = " AND IdVisitor=" & CLng(TxtIdVisitor.Text)
            Namvisitor = "ویزیتور:" & TxtVisitor.Text
        End If

        Dim User As String = ""
        Dim namUser As String = ""
        If ChkUser.Checked = True Then
            User = " AND IdUser=" & CLng(TxtIdUser.Text)
            namUser = "کاربر:" & TxtUser.Text
        End If

        namkala &= If(ChkPart.Checked = True, vbTab & "پارت : " & TxtPart.Text.Trim, "")
        namkala &= If(ChkUser.Checked = True, vbTab & namUser, "")
        namkala &= If(ChkVisitor.Checked = True, vbTab & Namvisitor, "")
        namkala &= If(ChkGroup.Checked = True, vbTab & namGroup, "")

        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "نمودار فروش(شهرستان)", "تهیه گزارش", "", "")

        If ChkP.Checked = False Then
            Using FS As New FrmPrint
                FS.Str1 = "نمودار فروش بر حسب شهرستان"
                FS.Str2 = namkala
                FS.State = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                FS.IdFactor = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
                If RdoLine.Checked = True Then
                    FS.Lend = "LINE"
                ElseIf RdoPie.Checked = True Then
                    FS.Lend = "PIE"
                ElseIf RdoBar.Checked = True Then
                    FS.Lend = "BAR"
                End If
                FS.PrintSQl = "Declare @tbl Table(IdName bigint,IdOstan BigInt) INSERT @tbl(IdName ,IdOstan ) (SELECT ID As Idname, IdCity AS IdOstan FROM  Define_People " & TmpListPeople & If(String.IsNullOrEmpty(TmpListPeople), If(String.IsNullOrEmpty(Group), "", " WHERE " & Group), If(String.IsNullOrEmpty(Group), "", " AND " & Group)) & ") SELECT T,Mandeh FROM(SELECT Ostan As T,Mandeh=(SELECT ISNULL(SUM(Frosh),0)FROM(SELECT ISNULL(SUM(" & If(RdoMon.Checked = True, "Mon", "KolCount") & "),0) as Frosh FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE  (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & If(ChkPart.Checked = True, " AND ListFactorSell .Part =" & TxtIdPart.Text.Trim, "") & ") AND IdName IN (SELECT IdName FROM @tbl  WHERE IdOstan =ListOstan.IdOstan) " & dat & ListKala & visitor & User & " UNION ALL " & If(ChkBack.Checked = False, " SELECT Frosh=(0) ", "SELECT Frosh=(SELECT ISNULL(SUM(" & If(RdoMon.Checked = True, "Mon", "KolCount") & "),0) as Frosh FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE  (ListFactorBackSell.Activ =1 " & If(ChkPart.Checked = True, " AND ListFactorBackSell .Part =" & TxtIdPart.Text.Trim, "") & ") AND IdName IN (SELECT IdName FROM @tbl  WHERE IdOstan =ListOstan.IdOstan)  " & dat & ListKala & visitor & User & ")* (-1)") & " UNION ALL " & If(ChkKasri.Checked = False, " SELECT Frosh=(0) ", " SELECT Frosh=(SELECT ISNULL(SUM(" & If(RdoMon.Checked = True, "Mon", "KolCount") & "),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor IN (SELECT IdFactor FROM  ListFactorSell WHERE " & If(ChkPart.Checked = True, " ListFactorSell .Part =" & TxtIdPart.Text.Trim & " AND ", "") & " IdName IN (SELECT IdName FROM @tbl  WHERE IdOstan =ListOstan.IdOstan) " & visitor & ") " & Replace(ListKala, "IdKala", "IDR") & dat & User & " )* (-1)") & " ) As ListFrosh) FROM (SELECT Define_City.NamCI AS Ostan,Define_City.Code As IdOstan FROM Define_City " & ListPeople & ") As ListOstan)AS EndList WHERE Mandeh>0 ORDER By Mandeh DESC"
                FS.CHoose = "CHARTFROSH-OSTAN"
                FS.ShowDialog()
            End Using
        Else
            Using FS As New FrmPrint
                FS.Str1 = "نمودار فروش بر حسب شهرستان"
                FS.Str2 = "نام شهرستان : " & namOstan & If(ChkPart.Checked = True, vbCrLf & "پارت : " & TxtPart.Text.Trim, "")


                FS.State = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                FS.IdFactor = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")

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

                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim dtr As SqlDataReader = Nothing
                Using cmd As New SqlCommand("SELECT ID FROM Define_People WHERE IdCity =" & IdOstan & If(String.IsNullOrEmpty(Group), "", " AND " & Group), ConectionBank)
                    dtr = cmd.ExecuteReader()
                End Using
                IdOstan = ""
                While dtr.Read
                    IdOstan &= dtr("ID") & ","
                End While
                IdOstan = IdOstan.Substring(0, IdOstan.Length - 1)
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                FS.PrintSQl = "SELECT T,ISNULL(SUM(Mandeh),0) AS Mandeh FROM (SELECT d_date As T," & If(RdoMon.Checked = True, "Mon", "KolCount") & " AS Mandeh FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE  (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 ) AND IdName IN (" & IdOstan & ") " & ListKala & dat & visitor & User & If(ChkBack.Checked = False, "", " UNION ALL SELECT d_date As T," & If(RdoMon.Checked = True, "Mon", "KolCount") & " * (-1) AS  Mandeh FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE  (ListFactorBackSell.Activ =1) AND IdName IN (" & IdOstan & ")  " & ListKala & dat & visitor & User) & If(ChkKasri.Checked = False, "", " UNION ALL SELECT D_date," & If(RdoMon.Checked = True, "Mon", "KolCount") & " * (-1) AS Mandeh  FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor IN (SELECT IdFactor FROM  ListFactorSell WHERE  IdName IN (" & IdOstan & ")" & visitor & ") " & ListKala.Replace("IdKala", "IdR") & dat & User) & ") ListDate GROUP BY T ORDER BY T"
                FS.ShowDialog()
            End Using
        End If
        Me.Enabled = True
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepNFCity.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
            Me.GetCity()
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnSeachCity.Enabled = True Then Call BtnSeachCity_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnSelect.Enabled = True Then Call BtnSelect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
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

    Private Sub BtnSeachCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeachCity.Click
        If DGV2.RowCount <= 0 Then Exit Sub
        Dim frmlk As New City_List
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

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Using FrmAdVance As New City_List
            FrmAdVance.ChkAll.Visible = True
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

    Private Sub ChkP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkP.CheckedChanged
        If ChkP.Checked = True Then
            RdoDay.Enabled = True
            RdoWeek.Enabled = True
            RdoMonth.Enabled = True
            RdoDay.Checked = True
        Else
            RdoDay.Enabled = False
            RdoWeek.Enabled = False
            RdoMonth.Enabled = False

            RdoDay.Checked = False
            RdoWeek.Checked = False
            RdoMonth.Checked = False
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

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If ChkGroup.Checked = True Then
            TxtGroup.Enabled = True
            TxtGroup.Focus()
        Else
            TxtGroup.Enabled = False
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

    Private Sub TxtGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
    End Sub

    Private Sub TxtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroup.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Group_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtGroup.Focus()
        If Tmp_Namkala <> "" Then
            TxtGroup.Text = Tmp_Namkala
            TxtIdGroup.Text = IdKala
        Else
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

End Class