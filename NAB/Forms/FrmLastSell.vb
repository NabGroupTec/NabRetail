Imports System.Data.SqlClient
Public Class FrmLastSell
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Chkbed.Checked = False And ChkBes.Checked = False And Chkbe.Checked = False Then
                MessageBox.Show("جهت تهیه گزارش باید حداقل یکی از گزینه های 'ماهیت طرف حساب'را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Chkbed.Checked = True
                Exit Sub
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


            If ChkDay.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    If (CDbl(TxtMon1.Text) > CDbl(TxtMon2.Text)) Then
                        MessageBox.Show("محدوده عدم خرید اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                    MessageBox.Show("محدوده عدم خرید اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If (CDbl(TxtMon1.Text) = 0 And CDbl(TxtMon2.Text) = 0) Then
                    MessageBox.Show("محدوده عدم خرید اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If DGV.RowCount <= 0 Then
                MessageBox.Show("گروه ویژه ایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Group As String = ""
            If CheckBox1.Checked = True Then
                Dim CountGroup As Long = 0
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Select", i).Value = True Then
                        Group &= "IdGroup=" & DGV.Item("Cln_IdP", i).Value & " OR "
                        CountGroup += 1
                    End If
                Next

                If CountGroup = DGV.RowCount Then
                    Group = ""
                ElseIf CountGroup <= 0 Then
                    MessageBox.Show("گروه ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Group = Group.Substring(0, Group.Length - 4)
                    Group = " AND (ChkIdGroup ='True' AND (" & Group & "))"
                End If
            End If

            Me.Enabled = False
            Using FrmPrint As New FrmPrint

                Dim Sort As String = ""
                If Rdopay.Checked = True Then
                    Sort = " ORDER BY T,Moein"
                ElseIf Rdoname.Checked = True Then
                    Sort = " ORDER BY Nam"
                ElseIf Rdodate.Checked = True Then
                    Sort = " ORDER BY EndSell"
                End If

                Dim Other As String = ""
                If ChKOther.Checked = True Then
                    Other = " AND (Other='False')"
                End If

                Dim Nul As String = ""
                If ChkNoDate.Checked = True Then
                    Nul = " WHERE EndSell Is  NOT NULL "
                End If

                Dim Part As String = ""
                If ChkPart.Checked = True Then
                    Part = "Define_People.IdOstan=" & CmbOstan.SelectedValue
                    Part &= If(ChkCity.Checked = True, " AND Define_People.IdCity=" & CmbCity.SelectedValue, "")
                    Part &= If(ChkP.Checked = True, " AND Define_People.IdPart=" & CmbPart.SelectedValue, "")
                    Part = " AND (" & Part & ")"
                End If

                Dim Kind As String = ""
                If Not (Chkbed.Checked = True And ChkBes.Checked = True And Chkbe.Checked = True) Then
                    Kind = If(ChkBes.Checked = True, "(EndList.Moein<0)", "")
                    Kind &= If(Chkbed.Checked = True, If(ChkBes.Checked = True, " OR (EndList.Moein>0)", "  (EndList.Moein>0)"), "")
                    Kind &= If(Chkbe.Checked = True, If(ChkBes.Checked = True Or Chkbed.Checked = True, " OR (EndList.Moein=0)", " (EndList.Moein=0)"), "")
                    Kind = If(String.IsNullOrEmpty(Nul), "WHERE (" & Kind & ")", " AND (" & Kind & ")")
                End If

                FrmPrint.Num1 = IIf(ChkAzMon.Checked = False, -1, TxtMon1.Text)
                FrmPrint.Num2 = IIf(ChkTaMon.Checked = False, -1, TxtMon2.Text)

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیگیری فروش", "تهيه گزارش", "", "")

                FrmPrint.PrintSQl = "SELECT Nam,GroupNam As Kind,Tell1 As Fix ,Tell2 As Mobile ,Addres ,Rate As BedMon ,EndSell As D_Date ,ABS(Moein) AS Mandeh,T=CASE WHEN EndList.Moein>=0 THEN N'بد' ELSE N'بس' END  FROM (SELECT Nam,GroupNam,Tell1 ,Tell2 ,Addres ,Rate,(SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =ListPeople.ID  AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =ListPeople.ID AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=ListPeople.ID )As AllOneMoney )As One) AS Moein,(SELECT MAX(D_date) FROM  ListFactorSell WHERE (ListFactorSell.Activ =1 AND ListFactorSell.Stat =3) AND IdName =ListPeople.ID) AS EndSell FROM(SELECT  Define_People.id,GroupNam=CASE WHEN Define_People.ChkIdGroup='True' THEN (SELECT nam FROM Define_Group_P WHERE Define_Group_P.Id =Define_People.IdGroup) ELSE '' END,Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Tell1, ISNULL(Define_People.Tell2,'') AS Tell2,Define_Ostan.NamO + ' ' + Define_City.NamCI + ' ' + Define_Part.NamP  + ISNULL(' - ' + Define_People.[Address],'') As Addres,Rate FROM  Define_People INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity WHERE Define_People.Id<>0 " & If(ChkActive.Checked = True, " AND Activ ='False' ", "") & Part & Other & Group & ") As ListPeople) AS EndList " & Nul & Kind & Sort
                If ChkNoMoein.Checked = False Then
                    FrmPrint.CHoose = "ENDSELL"
                Else
                    FrmPrint.CHoose = "NOENDSELL"
                End If

                FrmPrint.ShowDialog()
            End Using
            Me.Enabled = True

        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_manage.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmDaftarKol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbPart.Enabled = True
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_Ostan")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_City")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_Part")
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
            BtnSave.Focus()
        End If
    End Sub

    

    Private Sub ChkDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDay.CheckedChanged
        If ChkDay.Checked = True Then
            ChkAzMon.Enabled = True
            ChkTaMon.Enabled = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            ChkAzMon.Checked = True
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

    Private Sub FrmLastSell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F105")
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
        Me.GetGroup()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub GetGroup()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("SELECT Id, nam FROM Define_Group_P", DataSource)
            Dta.Fill(Ds, "Define_Group_P")
            DGV.AutoGenerateColumns = False
            DGV.DataSource = Ds.Tables("Define_Group_P")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmLastSell", "GetGroup")
            Me.Close()
        End Try
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            GroupBox5.Enabled = False
        Else
            GroupBox5.Enabled = True
        End If
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
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
End Class