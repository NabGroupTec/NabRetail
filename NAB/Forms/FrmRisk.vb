Imports System.Data.SqlClient
Public Class FrmRisk


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
                        MessageBox.Show("هیچ منطقه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CmbPart.Focus()
                        Exit Sub
                    End If
                End If
            End If


            If ChkDay.Checked = True Then
                If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                    MessageBox.Show("محدوده درصد ریسک اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            '///////////////////////////////////////////////
            If ChKMon.Checked = True Then
                If ChkAzMon1.Checked = True And ChkTaMon1.Checked = True Then
                    If (CDbl(TxtMon3.Text) > CDbl(TxtMon4.Text)) Then
                        MessageBox.Show("محدوده مبلغ مانده اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If (CDbl(TxtMon3.Text) = 0 And CDbl(TxtMon4.Text) = 0) Then
                    MessageBox.Show("محدوده مبلغ مانده اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkGet.Checked = True Then
                If ChkAzMonGet.Checked = True And ChkTaMonGet.Checked = True Then
                    If (CDbl(TxtMonGet1.Text) > CDbl(TxtMonGet2.Text)) Then
                        MessageBox.Show("محدوده مبلغ اسناد دریافتی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If (CDbl(TxtMonGet1.Text) = 0 And CDbl(TxtMonGet2.Text) = 0) Then
                    MessageBox.Show("محدوده مبلغ اسناد دریافتی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkBedMon.Checked = True Then
                If ChkAzMonBed.Checked = True And ChkTaMonBed.Checked = True Then
                    If (CDbl(TxtMonBed1.Text) > CDbl(TxtMonBed2.Text)) Then
                        MessageBox.Show("محدوده مبلغ بدهکاری اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If (CDbl(TxtMonBed1.Text) = 0 And CDbl(TxtMonBed2.Text) = 0) Then
                    MessageBox.Show("محدوده مبلغ بدهکاری اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '///////////////////////////////////////////////
            Me.Enabled = False
            Using FrmPrint As New FrmPrint

                Dim Group As String = ""
                If ChkGroup.Checked = True Then
                    Group = " AND (ChkIdGroup ='True' AND IdGroup =" & TxtIdGroup.Text & ") "
                End If

                Dim Part As String = ""
                If ChkPart.Checked = True Then
                    Part = "Define_People.IdOstan=" & CmbOstan.SelectedValue
                    Part &= If(ChkCity.Checked = True, " AND Define_People.IdCity=" & CmbCity.SelectedValue, "")
                    Part &= If(ChkP.Checked = True, " AND Define_People.IdPart=" & CmbPart.SelectedValue, "")
                    Part = " AND (" & Part & ")"
                End If

                Dim Other As String = ""
                If ChKOther.Checked = True Then
                    Other = " AND (Other='False')"
                End If

                Dim Kind As String = ""
                If Not (Chkbed.Checked = True And ChkBes.Checked = True And Chkbe.Checked = True) Then
                    Kind = If(ChkBes.Checked = True, " Moein < 0 ", "")
                    Kind &= If(Chkbed.Checked = True, If(ChkBes.Checked = True, " OR Moein > 0", "  Moein > 0"), "")
                    Kind &= If(Chkbe.Checked = True, If(ChkBes.Checked = True Or Chkbed.Checked = True, " OR Moein = 0", " Moein = 0"), "")
                    Kind = "WHERE (" & Kind & ")"
                End If

                Dim Mandeh As String = ""
                If ChKMon.Checked = True Then
                    If ChkAzMon1.Checked = True And ChkTaMon1.Checked = True Then
                        Mandeh = " ( Moein >=" & CDbl(TxtMon3.Text) & " AND Moein <=" & CDbl(TxtMon4.Text) & ")"
                    ElseIf ChkAzMon1.Checked = True And ChkTaMon1.Checked = False Then
                        Mandeh = " ( Moein >=" & CDbl(TxtMon3.Text) & ")"
                    ElseIf ChkAzMon1.Checked = False And ChkTaMon1.Checked = True Then
                        Mandeh = " ( Moein <=" & CDbl(TxtMon4.Text) & ")"
                    End If
                    Mandeh = If(String.IsNullOrEmpty(Kind), " WHERE " & Mandeh, " AND " & Mandeh)
                End If

                Dim GetChk As String = ""
                If ChkGet.Checked = True Then
                    If ChkAzMonGet.Checked = True And ChkTaMonGet.Checked = True Then
                        GetChk = " ( GetChk >=" & CDbl(TxtMonGet1.Text) & " AND GetChk <=" & CDbl(TxtMonGet2.Text) & ")"
                    ElseIf ChkAzMonGet.Checked = True And ChkTaMonGet.Checked = False Then
                        GetChk = " ( GetChk >=" & CDbl(TxtMonGet1.Text) & ")"
                    ElseIf ChkAzMonGet.Checked = False And ChkTaMonGet.Checked = True Then
                        GetChk = " ( GetChk <=" & CDbl(TxtMonGet2.Text) & ")"
                    End If
                    GetChk = If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Mandeh), " WHERE " & GetChk, " AND " & GetChk)
                End If

                Dim MonBed As String = ""
                If ChkBedMon.Checked = True Then
                    If ChkAzMonBed.Checked = True And ChkTaMonBed.Checked = True Then
                        MonBed = " ( Bed >=" & CDbl(TxtMonBed1.Text) & " AND Bed <=" & CDbl(TxtMonBed2.Text) & ")"
                    ElseIf ChkAzMonBed.Checked = True And ChkTaMonBed.Checked = False Then
                        MonBed = " ( Bed >=" & CDbl(TxtMonBed1.Text) & ")"
                    ElseIf ChkAzMonBed.Checked = False And ChkTaMonBed.Checked = True Then
                        MonBed = " ( Bed <=" & CDbl(TxtMonBed2.Text) & ")"
                    End If
                    MonBed = If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Mandeh) And String.IsNullOrEmpty(GetChk), " WHERE " & MonBed, " AND " & MonBed)
                End If

                FrmPrint.Num1 = IIf(ChkAzMon.Checked = False, -1, TxtMon1.Text)
                FrmPrint.Num2 = IIf(ChkTaMon.Checked = False, -1, TxtMon2.Text)

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "درصد ریسک", "تهیه گزارش", "", "")

                FrmPrint.PrintSQl = "SELECT Nam,Fix ,Mobile ,Bed As BedMon,Bes As BesMon,T,ABS(Moein) as Mandeh ,GetChk,PayChk,Darsad=0.0 FROM(SELECT Nam,Tell1 As Fix ,Tell2 As Mobile ,Bed=CASE WHEN One >=0 THEN Bed +One ELSE Bed END ,Bes =CASE WHEN One <0 THEN Bes  +ABS(One) ELSE Bes END,T=Case WHEN (Bed-Bes+one)<0 THEN N'بس' ELSE N'بد' END,(Bed-Bes+one) as Moein ,GetChk,PayChk FROM (SELECT Nam,Tell1,Tell2,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =ListPeople.ID  AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0) AS BES FROM Moein_People WHERE IDPeople =ListPeople.ID  AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=ListPeople.ID )As AllOneMoney ) As One,(SELECT ISNULL(SUM(MoneyChk),0) As GetChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0 and (Current_State =0 or Current_State =4)  AND (Current_IdPeople =ListPeople.ID OR IdPeople =ListPeople.ID)) As GetChk,(SELECT ISNULL(SUM(MoneyChk),0) As PayChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =1 and (Current_State =0 )  AND Current_IdPeople =ListPeople.ID) As PayChk FROM (SELECT  Define_People.id,Define_People.Nam,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2 FROM  Define_People WHERE Activ ='False'  " & Part & Other & Group & ") As ListPeople) AS EndList ) As EndListRisk " & Kind & Mandeh & GetChk & MonBed
                FrmPrint.CHoose = "DARSADRISK"
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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "DarsadRisk.htm")
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
        Access_Form = Get_Access_Form("F122")
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
        If e.KeyChar = "." Then
            If InStr(TxtMon1.Text, ".") = False Then
                e.Handled = False
            End If
        End If
        If e.KeyChar = "-" Then
            If InStr(TxtMon1.Text, "-") = False Then
                e.Handled = False
            End If
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
        If e.KeyChar = "." Then
            If InStr(TxtMon2.Text, ".") = False Then
                e.Handled = False
            End If
        End If
        If e.KeyChar = "-" Then
            If InStr(TxtMon2.Text, "-") = False Then
                e.Handled = False
            End If
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
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
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

    Private Sub TxtMon1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMon1.LostFocus
        TxtMon1.Text = Math.Round(CDbl(TxtMon1.Text), 2)
    End Sub

    Private Sub TxtMon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon1.TextChanged
        Try
            If Not (CheckDigit(TxtMon1.Text)) Then
                TxtMon1.Text = 0
                Exit Sub
            End If
            If Not TxtMon1.Text.Trim.Contains(".") Then TxtMon1.Text = CDbl(TxtMon1.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtMon2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMon2.LostFocus
        TxtMon2.Text = Math.Round(CDbl(TxtMon2.Text), 2)
    End Sub

    Private Sub TxtMon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon2.TextChanged
        Try
            If Not (CheckDigit(TxtMon2.Text)) Then
                TxtMon2.Text = 0
                Exit Sub
            End If
            If Not TxtMon2.Text.Trim.Contains(".") Then TxtMon2.Text = CDbl(TxtMon2.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChKMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKMon.CheckedChanged
        If ChKMon.Checked = True Then
            ChkAzMon1.Enabled = True
            ChkTaMon1.Enabled = True
            TxtMon3.Text = "0"
            TxtMon4.Text = "0"
            ChkAzMon1.Checked = True
            ChkTaMon1.Checked = True
            TxtMon3.Focus()
        Else
            ChkAzMon1.Checked = False
            ChkTaMon1.Checked = False
            ChkAzMon1.Enabled = False
            ChkTaMon1.Enabled = False
            TxtMon3.Enabled = False
            TxtMon4.Enabled = False
            TxtMon3.Text = "0"
            TxtMon4.Text = "0"
        End If
    End Sub

    Private Sub ChkAzMon1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMon1.CheckedChanged
        If ChkAzMon1.Checked = True Then
            TxtMon3.Text = "0"
            TxtMon3.Enabled = True
            TxtMon3.Focus()
            TxtMon3.SelectAll()
        Else
            TxtMon3.Text = "0"
            TxtMon3.Enabled = False
        End If
    End Sub

    Private Sub ChkTaMon1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMon1.CheckedChanged
        If ChkTaMon1.Checked = True Then
            TxtMon4.Text = "0"
            TxtMon4.Enabled = True
            TxtMon4.Focus()
            TxtMon4.SelectAll()
        Else
            TxtMon4.Text = "0"
            TxtMon4.Enabled = False
        End If
    End Sub

    Private Sub TxtMon3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon3.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon4.Focus()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon3.KeyPress
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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon3.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon3.Text.Replace(",", "")))) Then
                TxtMon3.Text = "0"
                TxtMon3.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon3.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon3.Text.Replace(",", ""))
                TxtMon3.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon3.Text = CDbl(TxtMon3.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon4.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon2.Focus()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon4.KeyPress
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon4.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon4.Text.Replace(",", "")))) Then
                TxtMon4.Text = "0"
                TxtMon4.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon4.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon4.Text.Replace(",", ""))
                TxtMon4.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon4.Text = CDbl(TxtMon4.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkGet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGet.CheckedChanged
        If ChkGet.Checked = True Then
            ChkAzMonGet.Enabled = True
            ChkTaMonGet.Enabled = True
            TxtMonGet1.Text = "0"
            TxtMonGet2.Text = "0"
            ChkAzMonGet.Checked = True
            ChkTaMonGet.Checked = True
            TxtMonGet1.Focus()
        Else
            ChkAzMonGet.Checked = False
            ChkTaMonGet.Checked = False
            ChkAzMonGet.Enabled = False
            ChkTaMonGet.Enabled = False
            TxtMonGet1.Enabled = False
            TxtMonGet2.Enabled = False
            TxtMonGet1.Text = "0"
            TxtMonGet2.Text = "0"
        End If
    End Sub

    Private Sub ChkBedMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBedMon.CheckedChanged
        If ChkBedMon.Checked = True Then
            ChkAzMonBed.Enabled = True
            ChkTaMonBed.Enabled = True
            TxtMonBed1.Text = "0"
            TxtMonBed2.Text = "0"
            ChkAzMonBed.Checked = True
            ChkTaMonBed.Checked = True
            TxtMonBed1.Focus()
        Else
            ChkAzMonBed.Checked = False
            ChkTaMonBed.Checked = False
            ChkAzMonBed.Enabled = False
            ChkTaMonBed.Enabled = False
            TxtMonBed1.Enabled = False
            TxtMonBed2.Enabled = False
            TxtMonBed1.Text = "0"
            TxtMonBed2.Text = "0"
        End If
    End Sub

    Private Sub ChkAzMonGet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMonGet.CheckedChanged
        If ChkAzMonGet.Checked = True Then
            TxtMonGet1.Text = "0"
            TxtMonGet1.Enabled = True
            TxtMonGet1.Focus()
            TxtMonGet1.SelectAll()
        Else
            TxtMonGet1.Text = "0"
            TxtMonGet1.Enabled = False
        End If
    End Sub

    Private Sub ChkAzMonBed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMonBed.CheckedChanged
        If ChkAzMonBed.Checked = True Then
            TxtMonBed1.Text = "0"
            TxtMonBed1.Enabled = True
            TxtMonBed1.Focus()
            TxtMonBed1.SelectAll()
        Else
            TxtMonBed1.Text = "0"
            TxtMonBed1.Enabled = False
        End If
    End Sub

    Private Sub ChkTaMonGet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMonGet.CheckedChanged
        If ChkTaMonGet.Checked = True Then
            TxtMonGet2.Text = "0"
            TxtMonGet2.Enabled = True
            TxtMonGet2.Focus()
            TxtMonGet2.SelectAll()
        Else
            TxtMonGet2.Text = "0"
            TxtMonGet2.Enabled = False
        End If
    End Sub

    Private Sub ChkTaMonBed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMonBed.CheckedChanged
        If ChkTaMonBed.Checked = True Then
            TxtMonBed2.Text = "0"
            TxtMonBed2.Enabled = True
            TxtMonBed2.Focus()
            TxtMonBed2.SelectAll()
        Else
            TxtMonBed2.Text = "0"
            TxtMonBed2.Enabled = False
        End If
    End Sub

    Private Sub TxtMonGet1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonGet1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMonGet2.Focus()
    End Sub

    Private Sub TxtMonGet1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonGet1.KeyPress
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

    Private Sub TxtMonGet1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonGet1.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMonGet1.Text.Replace(",", "")))) Then
                TxtMonGet1.Text = "0"
                TxtMonGet1.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMonGet1.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMonGet1.Text.Replace(",", ""))
                TxtMonGet1.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMonGet1.Text = CDbl(TxtMonGet1.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMonBed1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonBed1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMonBed2.Focus()
    End Sub

    Private Sub TxtMonBed1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonBed1.KeyPress
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

    Private Sub TxtMonBed1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonBed1.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMonBed1.Text.Replace(",", "")))) Then
                TxtMonBed1.Text = "0"
                TxtMonBed1.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMonBed1.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMonBed1.Text.Replace(",", ""))
                TxtMonBed1.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMonBed1.Text = CDbl(TxtMonBed1.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMonGet2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonGet2.KeyPress
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

    Private Sub TxtMonGet2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonGet2.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMonGet2.Text.Replace(",", "")))) Then
                TxtMonGet2.Text = "0"
                TxtMonGet2.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMonGet2.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMonGet2.Text.Replace(",", ""))
                TxtMonGet2.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMonGet2.Text = CDbl(TxtMonGet2.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMonBed2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonBed2.KeyPress
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

    Private Sub TxtMonBed2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonBed2.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMonBed2.Text.Replace(",", "")))) Then
                TxtMonBed2.Text = "0"
                TxtMonBed2.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMonBed2.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMonBed2.Text.Replace(",", ""))
                TxtMonBed2.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMonBed2.Text = CDbl(TxtMonBed2.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class