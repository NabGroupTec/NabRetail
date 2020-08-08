Imports System.Data.SqlClient
Public Class FrmManageFrosh

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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmManageFrosh", "GetKala")
            Me.Close()
        End Try
    End Sub

    Private Sub GetOstan()
        Try
            Dim DsP As New DataSet
            Dim DtaP As New SqlDataAdapter()
            DsP.Clear()
            If Not DtaP Is Nothing Then
                DtaP.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Code As Id, NamO As Nam FROM Define_Ostan"
            DtaP = New SqlDataAdapter(sqlstr, DataSource)
            DtaP.Fill(DsP, "Define_Ostan")
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = DsP.Tables("Define_Ostan")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmManageFrosh", "GetOstan")
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
        Access_Form = Get_Access_Form("F132")
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
        GetOstan()
        GetKala()
        GetGroup()
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_NamP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_NamG").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ChkAllGroup.Checked = True
        ChkAllp.Checked = True
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
            MessageBox.Show("استانی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Dim CountKala As Long = 0
        ListKala = " AND IdKala IN("
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListKala &= DGV.Item("Cln_Id", i).Value & ","
                CountKala += 1
            End If
        Next
        If CountKala = DGV.RowCount Then
            ListKala = ""
        ElseIf CountKala <= 0 Then
            MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListKala = ListKala.Substring(0, ListKala.Length - 1)
            ListKala &= ")"
        End If

        Dim ListPeople As String = ""
        Dim CountPeople As Long = 0
        ListPeople = " WHERE ( "
        For i As Integer = 0 To DGV2.RowCount - 1
            If DGV2.Item("Cln_SelectP", i).Value = True Then
                ListPeople &= "Define_Ostan.Code =" & DGV2.Item("Cln_IdP", i).Value & " OR "
                CountPeople += 1
            End If
        Next
        If CountPeople = DGV2.RowCount Then
            ListPeople = ""
        ElseIf CountPeople <= 0 Then
            MessageBox.Show("استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListPeople = ListPeople.Substring(0, ListPeople.Length - 4)
            ListPeople &= ")"
        End If

        Dim ListG As String = ""
        Dim ListG2 As String = ""
        Dim CountG As Long = 0
        ListG = " AND IdName IN (SELECT Id FROM Define_People WHERE ChkIdGroup ='True' AND ( "
        ListG2 = " AND ChkIdGroup ='True' AND ( "
        For i As Integer = 0 To DGV3.RowCount - 1
            If DGV3.Item("Cln_S", i).Value = True Then
                ListG &= "IdGroup=" & DGV3.Item("Cln_IdG", i).Value & " OR "
                ListG2 &= "IdGroup=" & DGV3.Item("Cln_IdG", i).Value & " OR "
                CountG += 1
            End If
        Next
        If CountG = DGV3.RowCount Then
            ListG = ""
            ListG2 = ""
        ElseIf CountG <= 0 Then
            MessageBox.Show("گروه ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            ListG = ListG.Substring(0, ListG.Length - 4)
            ListG &= "))"
            ListG2 = ListG2.Substring(0, ListG2.Length - 4)
            ListG2 &= ")"
        End If

        Dim visitor As String = ""
        If ChkVisitor.Checked = True Then
            visitor = " AND IdVisitor=" & CLng(TxtIdVisitor.Text)
        End If

        Dim User As String = ""
        If ChkUser.Checked = True Then
            User = " AND IdUser=" & CLng(TxtIdUser.Text)
        End If

        Dim dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date <=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            dat = " AND (D_date <=N'" & FarsiDate2.ThisText & "')"
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت بازار", "تهیه گزارش", If(ChkVisitor.Checked = True, "محدودیت ویزیتور:" & TxtVisitor.Text, "") & If(ChkUser.Checked = True, " محدودیت کاربر:" & TxtUser.Text, ""), "")

        Using FS As New FrmShowMFrosh
            FS.Query = "SELECT Ostan,City,Part,IdOstan,IdCity,IdPart,Frosh=(SELECT ISNULL(SUM(Frosh),0)FROM(SELECT ISNULL(SUM(Mon " & If(ChkDiscount.Checked = True, "-DarsadMon", "") & " ),0) as Frosh FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE  (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3) AND IdName IN (SELECT Id FROM Define_People WHERE IdPart =ListOstan.IdPart) " & ListG & dat & ListKala & visitor & User & " UNION ALL " & If(ChkBack.Checked = False, " SELECT Frosh=(0) ", "SELECT Frosh=(SELECT ISNULL(SUM(Mon" & If(ChkDiscount.Checked = True, "-DarsadMon", "") & "),0) as Frosh FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE  (ListFactorBackSell.Activ =1) AND IdName IN (SELECT Id FROM Define_People WHERE IdPart =ListOstan.IdPart)  " & ListG & dat & ListKala & visitor & User & ")* (-1)") & " UNION ALL " & If(ChkKasri.Checked = False, " SELECT Frosh=(0) ", " SELECT Frosh=(SELECT ISNULL(SUM(Mon" & If(ChkDiscount.Checked = True, "-DarsadMon", "") & "),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor IN (SELECT IdFactor FROM  ListFactorSell WHERE IdName IN (SELECT Id FROM Define_People WHERE IdPart =ListOstan.IdPart)" & ListG & visitor & User & ") " & Replace(ListKala, "IdKala", "IDR") & dat & " )* (-1)") & " ) As ListFrosh) FROM (SELECT Define_Ostan.NamO AS Ostan,Define_City.NamCI As City,Define_Part.NamP As Part,Define_Ostan.Code As IdOstan,Define_City.Code AS IdCity,Define_Part.Code AS IdPart FROM Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & ListPeople & ") As ListOstan"
            FS.PeopleQuery = "SELECT Nam,GroupNam,Frosh=(SELECT ISNULL(SUM(Frosh),0)FROM(SELECT ISNULL(SUM(Mon " & If(ChkDiscount.Checked = True, "-DarsadMon", "") & " ),0) as Frosh FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE  (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3) AND IdName=ListOstan.ID AND IdName IN (SELECT Id FROM Define_People WHERE IdPart =ListOstan.IdPart) " & dat & ListKala & visitor & User & " UNION ALL " & If(ChkBack.Checked = False, " SELECT Frosh=(0) ", "SELECT Frosh=(SELECT ISNULL(SUM(Mon" & If(ChkDiscount.Checked = True, "-DarsadMon", "") & "),0) as Frosh FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE  (ListFactorBackSell.Activ =1) AND IdName=ListOstan.ID AND IdName IN (SELECT Id FROM Define_People WHERE IdPart =ListOstan.IdPart)  " & dat & ListKala & visitor & User & ")* (-1)") & " UNION ALL " & If(ChkKasri.Checked = False, " SELECT Frosh=(0) ", " SELECT Frosh=(SELECT ISNULL(SUM(Mon" & If(ChkDiscount.Checked = True, "-DarsadMon", "") & "),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor IN (SELECT IdFactor FROM  ListFactorSell WHERE IdName IN (SELECT Id FROM Define_People WHERE IdPart =ListOstan.IdPart) AND IdName=ListOstan.ID " & visitor & User & " ) " & Replace(ListKala, "IdKala", "IDR") & dat & " )* (-1)") & " ) As ListFrosh) FROM (SELECT Define_People.ID, Define_People.Nam, Define_People.IdPart, Define_Group_P.nam AS GroupNam FROM  Define_People INNER JOIN Define_Group_P ON Define_People.IdGroup = Define_Group_P.Id WHERE "
            FS.PeopleQuery2 = ListG2
            Me.Enabled = False
            FS.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub

    Private Sub ChkAllGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllGroup.CheckedChanged
        If DGV3.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV3.RowCount - 1
            DGV3.Item("Cln_S", i).Value = ChkAllGroup.Checked
        Next
    End Sub
    Private Sub GetGroup()
        Try
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("SELECT Id, nam FROM Define_Group_P", DataSource)
            Dta.Fill(Ds, "Define_Group_P")
            DGV3.AutoGenerateColumns = False
            DGV3.DataSource = Ds.Tables("Define_Group_P")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmManageFrosh", "GetGroup")
            Me.Close()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepManageBazar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
            Me.GetGroup()
            Me.GetOstan()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
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

End Class