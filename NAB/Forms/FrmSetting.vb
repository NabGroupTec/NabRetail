Imports System.Data.SqlClient
Public Class FrmSetting

    Dim ds_Anbar As New DataTable
    Dim dta_Anbar As New SqlDataAdapter()

    Private Sub GetAnbarList()
        Try
            ds_Anbar.Clear()
            If Not dta_Anbar Is Nothing Then
                dta_Anbar.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_Anbar = New SqlDataAdapter("SELECT Id, Nam FROM  Define_Anbar", DataSource)
            dta_Anbar.Fill(ds_Anbar)
            CmbAnbar.DataSource = ds_Anbar
            CmbAnbar.DisplayMember = "Nam"
            CmbAnbar.ValueMember = "ID"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSetting", "GetAnbarList")
        End Try
    End Sub

    Private Sub FrmSetting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F125")
        If (Access_Form <> "-1") Then
            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
            End If
        End If

        If UCase(NamUser) = "ADMIN" Then
            ListV.Items.Add("ارزش افزوده")
        End If

        GetAnbarList()
        GetInfo()
        BtnSave.Enabled = False

        ListV.Focus()
        ListV.Items(0).Selected = True
    End Sub

    Private Sub GetInfo()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()

            Dim dtr As SqlDataReader = Nothing
            Using Cmd As New SqlCommand("SELECT TOP 1 FactorPaper,TypeFactor,FactorCount,AnbarCount,Get_Pay_Count,FilterKala,TypeKala,FilterP,TypeP,TypeAll,S1,Barcode,IdAnbar,KalaDup,Fish,S2,S3,S4,S5,S6,S7,S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S27 FROM SettingProgram WHERE IdUser=" & Id_User, ConectionBank)
                dtr = Cmd.ExecuteReader
            End Using
            If dtr.HasRows Then
                dtr.Read()
                CmbFactorPaper.Text = If(dtr("FactorPaper") > 2 Or dtr("FactorPaper") < 0, CmbFactorPaper.Items.Item(0), CmbFactorPaper.Items.Item(dtr("FactorPaper")))

                If (dtr("TypeFactor") > 7 Or dtr("TypeFactor") < 0) Then
                    CmbTypeFactor.Text = CmbTypeFactor.Items.Item(0)
                Else
                    Select Case dtr("TypeFactor")
                        'Case 0 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(0)
                        'Case 1 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(4)
                        'Case 2 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(3)
                        'Case 3 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(6)
                        'Case 4 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(5)
                        'Case 5 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(1)
                        'Case 6 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(2)
                        Case 0 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(0)
                        Case 1 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(5)
                        Case 2 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(4)
                        Case 3 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(7)
                        Case 4 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(6)
                        Case 5 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(1)
                        Case 6 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(2)
                        Case 7 : CmbTypeFactor.Text = CmbTypeFactor.Items.Item(3)
                    End Select
                End If

                NumFactor.Value = If(dtr("FactorCount") > 10 Or dtr("FactorCount") < 0, 1, dtr("FactorCount"))
                NumAnbar.Value = If(dtr("AnbarCount") > 10 Or dtr("AnbarCount") < 0, 1, dtr("AnbarCount"))
                NumGet_Pay.Value = If(dtr("Get_Pay_Count") > 10 Or dtr("Get_Pay_Count") < 0, 1, dtr("Get_Pay_Count"))
                CmbFilterKala.Text = If(dtr("FilterKala") > 6 Or dtr("FilterKala") < 0, CmbFilterKala.Items.Item(0), CmbFilterKala.Items.Item(dtr("FilterKala")))
                CmbTypeKala.Text = If(dtr("TypeKala") > 1 Or dtr("TypeKala") < 0, CmbTypeKala.Items.Item(0), CmbTypeKala.Items.Item(dtr("TypeKala")))
                CmbFilterP.Text = If(dtr("FilterP") > 9 Or dtr("FilterP") < 0, CmbFilterP.Items.Item(0), CmbFilterP.Items.Item(dtr("FilterP")))
                CmbTypeP.Text = If(dtr("TypeP") > 1 Or dtr("TypeP") < 0, CmbTypeP.Items.Item(0), CmbTypeP.Items.Item(dtr("TypeP")))
                CmbTypeAll.Text = If(dtr("TypeAll") > 1 Or dtr("TypeAll") < 0, CmbTypeAll.Items.Item(0), CmbTypeAll.Items.Item(dtr("TypeAll")))
                ChkBarcode.Checked = dtr("Barcode")
                ChkGroup.Checked = If(dtr("S1") Is DBNull.Value, False, If(dtr("S1") = 0, False, True))
                ChkCode.Checked = If(dtr("S2") Is DBNull.Value, False, If(dtr("S2") = 0, False, True))
                RdoAuto.Checked = If(dtr("S3") Is DBNull.Value, False, If(dtr("S3") = 0, False, True))
                RdoDasti.Checked = If(dtr("S4") Is DBNull.Value, False, If(dtr("S4") = 0, False, True))
                RdoBig.Checked = If(dtr("S5") Is DBNull.Value, True, If(dtr("S5") = 0, False, True))
                RdoSmall.Checked = If(dtr("S6") Is DBNull.Value, False, If(dtr("S6") = 0, False, True))
                ChkMojodyKala.Checked = If(dtr("S7") Is DBNull.Value, False, If(dtr("S7") = 0, False, True))
                ChkAnbar.Checked = If(dtr("IdAnbar") Is DBNull.Value, False, True)
                If Not dtr("IdAnbar") Is DBNull.Value Then CmbAnbar.SelectedValue = dtr("IdAnbar")
                ChkSum.Checked = dtr("KalaDup")
                ChKFish.Checked = dtr("Fish")
                If dtr("S12") Is DBNull.Value Or dtr("S12").Equals("0") Then
                    ChkAddBuy.Checked = False
                Else
                    ChkBuy.Checked = True
                    ChkAddBuy.Checked = True
                    TxtAddBuy.Text = dtr("S12")
                End If
                If dtr("S13") Is DBNull.Value Or dtr("S13").Equals("0") Then
                    ChkDecBuy.Checked = False
                Else
                    ChkBuy.Checked = True
                    ChkDecBuy.Checked = True
                    TxtDecBuy.Text = dtr("S13")
                End If
                If dtr("S14") Is DBNull.Value Or dtr("S14").Equals("0") Then
                    ChkAddFrosh.Checked = False
                Else
                    ChkFrosh.Checked = True
                    ChkAddFrosh.Checked = True
                    TxtAddFrosh.Text = dtr("S14")
                End If
                If dtr("S15") Is DBNull.Value Or dtr("S15").Equals("0") Then
                    ChkDecFrosh.Checked = False
                Else
                    ChkFrosh.Checked = True
                    ChkDecFrosh.Checked = True
                    TxtDecFrosh.Text = dtr("S15")
                End If
                If dtr("S16") Is DBNull.Value Or dtr("S16").Equals("0") Then
                    ChkAddBackBuy.Checked = False
                Else
                    ChkBackBuy.Checked = True
                    ChkAddBackBuy.Checked = True
                    TxtAddBackBuy.Text = dtr("S16")
                End If
                If dtr("S17") Is DBNull.Value Or dtr("S17").Equals("0") Then
                    ChkDecBackBuy.Checked = False
                Else
                    ChkBackBuy.Checked = True
                    ChkDecBackBuy.Checked = True
                    TxtDecBackBuy.Text = dtr("S17")
                End If
                If dtr("S18") Is DBNull.Value Or dtr("S18").Equals("0") Then
                    ChkAddBackFrosh.Checked = False
                Else
                    ChkBackSell.Checked = True
                    ChkAddBackFrosh.Checked = True
                    TxtAddBackFrosh.Text = dtr("S18")
                End If
                If dtr("S19") Is DBNull.Value Or dtr("S19").Equals("0") Then
                    ChkDecBackFrosh.Checked = False
                Else
                    ChkBackSell.Checked = True
                    ChkDecBackFrosh.Checked = True
                    TxtDecBackFrosh.Text = dtr("S19")
                End If
                If dtr("S20") Is DBNull.Value Or dtr("S20").Equals("0") Then
                    ChkAddService.Checked = False
                Else
                    ChkService.Checked = True
                    ChkAddService.Checked = True
                    TxtAddService.Text = dtr("S20")
                End If
                If dtr("S21") Is DBNull.Value Or dtr("S21").Equals("0") Then
                    ChkDecService.Checked = False
                Else
                    ChkService.Checked = True
                    ChkDecService.Checked = True
                    TxtDecService.Text = dtr("S21")
                End If

                If dtr("S27") Is DBNull.Value Then
                    ChkGetChk.Checked = True
                    ChkGetDay.Checked = True
                    ChkPayChk.Checked = True
                    ChkPayDay.Checked = True
                    ChkMessage.Checked = True
                Else
                    Dim str As String = dtr("S27")
                    '''''''''''''''''''''''''''''''''''''''''''
                    If str(0).ToString = "0" And str(1).ToString = "0" And str(2).ToString = "0" Then
                        ChkGetChk.Checked = False
                    Else
                        ChkGetChk.Checked = True

                        If str(0).ToString = "0" Then
                            ChkGetDay.Checked = False
                        Else
                            ChkGetDay.Checked = True
                        End If
                        If str(1).ToString = "0" Then
                            ChkGetOld.Checked = False
                        Else
                            ChkGetOld.Checked = True
                            NumGetOld.Value = str(1).ToString
                        End If
                        If str(2).ToString = "0" Then
                            ChkGetNew.Checked = False
                        Else
                            ChkGetNew.Checked = True
                            NumGetNew.Value = str(2).ToString
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''
                    If str(3).ToString = "0" And str(4).ToString = "0" And str(5).ToString = "0" Then
                        ChkPayChk.Checked = False
                    Else
                        ChkPayChk.Checked = True
                        If str(3).ToString = "0" Then
                            ChkPayDay.Checked = False
                        Else
                            ChkPayDay.Checked = True
                        End If
                        If str(4).ToString = "0" Then
                            ChkPayOld.Checked = False
                        Else
                            ChkPayOld.Checked = True
                            NumPayOld.Value = str(4).ToString
                        End If
                        If str(5).ToString = "0" Then
                            ChkPayNew.Checked = False
                        Else
                            ChkPayNew.Checked = True
                            NumPayNew.Value = str(5).ToString
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''
                    If str(6).ToString = "0" Then
                        ChkLF.Checked = False
                    Else
                        ChkLF.Checked = True
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''
                    If str(7).ToString = "0" Then
                        ChkHF.Checked = False
                    Else
                        ChkHF.Checked = True
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''
                    If str(8).ToString = "0" Then
                        ChkBedRate.Checked = False
                    Else
                        ChkBedRate.Checked = True
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''
                    If str(9).ToString = "0" Then
                        ChkBesRate.Checked = False
                    Else
                        ChkBesRate.Checked = True
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''
                    If str(10).ToString = "0" Then
                        ChkMessage.Checked = False
                    Else
                        ChkMessage.Checked = True
                    End If
                End If
                If ChkAddBuy.Checked = True And (String.IsNullOrEmpty(TxtAddBuy.Text) Or TxtAddBuy.Text = "0" Or TxtAddBuy.Text = "0.0") Then ChkAddBuy.Checked = False
                If ChkDecBuy.Checked = True And (String.IsNullOrEmpty(TxtDecBuy.Text) Or TxtDecBuy.Text = "0" Or TxtDecBuy.Text = "0.0") Then ChkDecBuy.Checked = False
                If ChkAddFrosh.Checked = True And (String.IsNullOrEmpty(TxtAddFrosh.Text) Or TxtAddFrosh.Text = "0" Or TxtAddFrosh.Text = "0.0") Then ChkAddFrosh.Checked = False
                If ChkDecFrosh.Checked = True And (String.IsNullOrEmpty(TxtDecFrosh.Text) Or TxtDecFrosh.Text = "0" Or TxtDecFrosh.Text = "0.0") Then ChkDecFrosh.Checked = False
                If ChkAddBackBuy.Checked = True And (String.IsNullOrEmpty(TxtAddBackBuy.Text) Or TxtAddBackBuy.Text = "0" Or TxtAddBackBuy.Text = "0.0") Then ChkAddBackBuy.Checked = False
                If ChkDecBackBuy.Checked = True And (String.IsNullOrEmpty(TxtDecBackBuy.Text) Or TxtDecBackBuy.Text = "0" Or TxtDecBackBuy.Text = "0.0") Then ChkDecBackBuy.Checked = False
                If ChkAddBackFrosh.Checked = True And (String.IsNullOrEmpty(TxtAddBackFrosh.Text) Or TxtAddBackFrosh.Text = "0" Or TxtAddBackFrosh.Text = "0.0") Then ChkAddBackFrosh.Checked = False
                If ChkDecBackFrosh.Checked = True And (String.IsNullOrEmpty(TxtDecBackFrosh.Text) Or TxtDecBackFrosh.Text = "0" Or TxtDecBackFrosh.Text = "0.0") Then ChkDecBackFrosh.Checked = False
                If ChkAddService.Checked = True And (String.IsNullOrEmpty(TxtAddService.Text) Or TxtAddService.Text = "0" Or TxtAddService.Text = "0.0") Then ChkAddService.Checked = False
                If ChkDecService.Checked = True And (String.IsNullOrEmpty(TxtDecService.Text) Or TxtDecService.Text = "0" Or TxtDecService.Text = "0.0") Then ChkDecService.Checked = False
                LEdit.Text = "1"
            Else
                CmbFactorPaper.Text = CmbFactorPaper.Items.Item(0)
                CmbTypeFactor.Text = CmbTypeFactor.Items.Item(0)
                NumFactor.Value = 1
                NumAnbar.Value = 1
                NumGet_Pay.Value = 1
                CmbFilterKala.Text = CmbFilterKala.Items.Item(0)
                CmbTypeKala.Text = CmbTypeKala.Items.Item(0)
                CmbFilterP.Text = CmbFilterP.Items.Item(0)
                CmbTypeP.Text = CmbTypeP.Items.Item(0)
                CmbTypeAll.Text = CmbTypeAll.Items.Item(0)
                ChkGroup.Checked = True
                ChkBarcode.Checked = False
                ChkCode.Checked = False
                RdoBig.Checked = True
                ChkMojodyKala.Checked = False
                LEdit.Text = "0"
                ChkBuy.Checked = False
                ChkBackBuy.Checked = False
                ChkFrosh.Checked = False
                ChkBackSell.Checked = False
                ChkService.Checked = False
                ChkGetChk.Checked = True
                ChkGetDay.Checked = True
                ChkPayChk.Checked = True
                ChkPayDay.Checked = True
                ChkMessage.Checked = True
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSetting", "GetInfo")
            Me.Close()
        End Try
    End Sub
    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub ListV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListV.SelectedIndexChanged
        If ListV.Items(0).Selected = True Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel5.Visible = False
        ElseIf ListV.Items(1).Selected = True Then
            Panel1.Visible = False
            Panel2.Visible = True
            Panel3.Visible = False
            Panel5.Visible = False
        ElseIf ListV.Items(2).Selected = True Then
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
            Panel5.Visible = False
        End If

        Try
            If ListV.Items(3).Selected = True Then
                Panel1.Visible = False
                Panel2.Visible = False
                Panel3.Visible = False
                Panel5.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbFactorPaper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbFactorPaper.KeyDown
        If CmbFactorPaper.DroppedDown = False Then CmbFactorPaper.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbTypeFactor.Focus()
    End Sub

    Private Sub CmbFactorPaper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFactorPaper.SelectedIndexChanged
        BtnSave.Enabled = True
        If CmbFactorPaper.Text = CmbFactorPaper.Items(0) Or CmbFactorPaper.Text = CmbFactorPaper.Items(1) Then
            RdoSmall.Enabled = True
        Else
            RdoSmall.Enabled = False
            RdoBig.Checked = True
        End If
    End Sub

    Private Sub CmbTypeFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTypeFactor.KeyDown
        If CmbTypeFactor.DroppedDown = False Then CmbTypeFactor.DroppedDown = True
        If e.KeyCode = Keys.Enter Then NumFactor.Focus()
    End Sub

    Private Sub CmbTypeFactor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTypeFactor.SelectedIndexChanged
        BtnSave.Enabled = True
        If CmbTypeFactor.Text = CmbTypeFactor.Items(7) Then
            CmbFactorPaper.Text = CmbFactorPaper.Items(1)
            CmbFactorPaper.Enabled = False
        ElseIf CmbTypeFactor.Text = CmbTypeFactor.Items(1) Or CmbTypeFactor.Text = CmbTypeFactor.Items(6) Or CmbTypeFactor.Text = CmbTypeFactor.Items(2) Or CmbTypeFactor.Text = CmbTypeFactor.Items(3) Then
            CmbFactorPaper.Text = CmbFactorPaper.Items(0)
            CmbFactorPaper.Enabled = False
        Else
            CmbFactorPaper.Enabled = True
        End If
    End Sub

    Private Sub NumFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumFactor.KeyDown
        If e.KeyCode = Keys.Enter Then NumAnbar.Focus()
    End Sub

    Private Sub NumFactor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumFactor.ValueChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub NumAnbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumAnbar.KeyDown
        If e.KeyCode = Keys.Enter Then NumGet_Pay.Focus()
    End Sub

    Private Sub NumAnbar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumAnbar.ValueChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub NumGet_Pay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumGet_Pay.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub NumGet_Pay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumGet_Pay.ValueChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CmbFilterKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbFilterKala.KeyDown
        If CmbFilterKala.DroppedDown = False Then CmbFilterKala.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbTypeKala.Focus()
    End Sub

    Private Sub CmbFilterKala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFilterKala.SelectedIndexChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CmbTypeKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTypeKala.KeyDown
        If CmbTypeKala.DroppedDown = False Then CmbTypeKala.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbFilterP.Focus()
    End Sub

    Private Sub CmbTypeKala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTypeKala.SelectedIndexChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CmbFilterP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbFilterP.KeyDown
        If CmbFilterP.DroppedDown = False Then CmbFilterP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbTypeP.Focus()
    End Sub

    Private Sub CmbFilterP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFilterP.SelectedIndexChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CmbTypeP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTypeP.KeyDown
        If CmbTypeP.DroppedDown = False Then CmbTypeP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbTypeAll.Focus()
    End Sub

    Private Sub CmbTypeP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTypeP.SelectedIndexChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CmbTypeAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTypeAll.KeyDown
        If CmbTypeAll.DroppedDown = False Then CmbTypeAll.DroppedDown = True
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub CmbTypeAll_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTypeAll.SelectedIndexChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkMojodyBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkMojodyBank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkMojodyAnbar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BtnSave.Enabled = True
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Setprog.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BtnSave.Focus()
            If ChkAnbar.Checked = True And String.IsNullOrEmpty(CmbAnbar.Text) Then
                MessageBox.Show("انبار پیش فرض را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ChkGetChk.Checked = True And ChkGetDay.Checked = False And ChkGetOld.Checked = False And ChkGetNew.Checked = False Then
                MessageBox.Show("گزینه های مربوط به چک دریافتی را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If ChkPayChk.Checked = True And ChkPayDay.Checked = False And ChkPayNew.Checked = False And ChkPayOld.Checked = False Then
                MessageBox.Show("گزینه های مربوط به چک پرداختی را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If UCase(NamUser) = "ADMIN" Then

                If ChkBuy.Checked = True Then
                    If ChkAddBuy.Checked = False And ChkDecBuy.Checked = False Then
                        MessageBox.Show("میزان اضافات یا کسورات مربوطه به خرید/خرید امانی را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkAddBuy.Checked = True And (String.IsNullOrEmpty(TxtAddBuy.Text) Or TxtAddBuy.Text = "0" Or TxtAddBuy.Text = "0.0") Then
                        MessageBox.Show("درصد اضافات خرید/خرید امانی را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkDecBuy.Checked = True And (String.IsNullOrEmpty(TxtDecBuy.Text) Or TxtDecBuy.Text = "0" Or TxtDecBuy.Text = "0.0") Then
                        MessageBox.Show("درصد کسورات خرید/خرید امانی را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If


                If ChkFrosh.Checked = True Then
                    If ChkAddFrosh.Checked = False And ChkDecFrosh.Checked = False Then
                        MessageBox.Show("میزان اضافات یا کسورات مربوطه به فروش/فروش امانی را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkAddFrosh.Checked = True And (String.IsNullOrEmpty(TxtAddFrosh.Text) Or TxtAddFrosh.Text = "0" Or TxtAddFrosh.Text = "0.0") Then
                        MessageBox.Show("درصد اضافات فروش/فروش امانی را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkDecFrosh.Checked = True And (String.IsNullOrEmpty(TxtDecFrosh.Text) Or TxtDecFrosh.Text = "0" Or TxtDecFrosh.Text = "0.0") Then
                        MessageBox.Show("درصد کسورات فروش/فروش امانی را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkBackBuy.Checked = True Then
                    If ChkAddBackBuy.Checked = False And ChkDecBackBuy.Checked = False Then
                        MessageBox.Show("میزان اضافات یا کسورات مربوطه به برگشت از خرید را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkAddBackBuy.Checked = True And (String.IsNullOrEmpty(TxtAddBackBuy.Text) Or TxtAddBackBuy.Text = "0" Or TxtAddBackBuy.Text = "0.0") Then
                        MessageBox.Show("درصد اضافات برگشت از خرید را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkDecBackBuy.Checked = True And (String.IsNullOrEmpty(TxtDecBackBuy.Text) Or TxtDecBackBuy.Text = "0" Or TxtDecBackBuy.Text = "0.0") Then
                        MessageBox.Show("درصد کسورات برگشت از خرید را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkBackSell.Checked = True Then
                    If ChkAddBackFrosh.Checked = False And ChkDecBackFrosh.Checked = False Then
                        MessageBox.Show("میزان اضافات یا کسورات مربوطه به برگشت از فروش را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkAddBackFrosh.Checked = True And (String.IsNullOrEmpty(TxtAddBackFrosh.Text) Or TxtAddBackFrosh.Text = "0" Or TxtAddBackFrosh.Text = "0.0") Then
                        MessageBox.Show("درصد اضافات برگشت از فروش را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkDecBackFrosh.Checked = True And (String.IsNullOrEmpty(TxtDecBackFrosh.Text) Or TxtDecBackFrosh.Text = "0" Or TxtDecBackFrosh.Text = "0.0") Then
                        MessageBox.Show("درصد کسورات برگشت از فروش را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkService.Checked = True Then
                    If ChkAddService.Checked = False And ChkDecService.Checked = False Then
                        MessageBox.Show("میزان اضافات یا کسورات مربوطه به خدمات را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkAddService.Checked = True And (String.IsNullOrEmpty(TxtAddService.Text) Or TxtAddService.Text = "0" Or TxtAddService.Text = "0.0") Then
                        MessageBox.Show("درصد اضافات خدمات را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If ChkDecService.Checked = True And (String.IsNullOrEmpty(TxtDecService.Text) Or TxtDecService.Text = "0" Or TxtDecService.Text = "0.0") Then
                        MessageBox.Show("درصد کسورات خدمات را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

            End If


            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Dim SqlStr As String = ""
            If LEdit.Text = "0" Then
                SqlStr = "INSERT INTO SettingProgram (FactorPaper,TypeFactor,FactorCount,AnbarCount,Get_Pay_Count,FilterKala,TypeKala,FilterP,TypeP,TypeAll,S1,IdUser,Barcode,IdAnbar,KalaDup,Fish,S2,S3,S4,S5,S6,S7,S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S27) VALUES(@FactorPaper,@TypeFactor,@FactorCount,@AnbarCount,@Get_Pay_Count,@FilterKala,@TypeKala,@FilterP,@TypeP,@TypeAll,@S1,@IdUser,@Barcode,@IdAnbar,@KalaDup,@Fish,@S2,@S3,@S4,@S5,@S6,@S7,@S12,@S13,@S14,@S15,@S16,@S17,@S18,@S19,@S20,@S21,@S27)"
            ElseIf LEdit.Text = "1" Then
                If UCase(NamUser) = "ADMIN" Then
                    SqlStr = "UPDATE SettingProgram SET FactorPaper=@FactorPaper,TypeFactor=@TypeFactor,FactorCount=@FactorCount,AnbarCount=@AnbarCount,Get_Pay_Count=@Get_Pay_Count,FilterKala=@FilterKala,TypeKala=@TypeKala,FilterP=@FilterP,TypeP=@TypeP,TypeAll=@TypeAll,S1=@S1,Barcode=@Barcode,IdAnbar=@IdAnbar,KalaDup=@KalaDup,Fish=@Fish,S2=@S2,S3=@S3,S4=@S4,S5=@S5,S6=@S6,S7=@S7,S12=@S12,S13=@S13,S14=@S14,S15=@S15,S16=@S16,S17=@S17,S18=@S18,S19=@S19,S20=@S20,S21=@S21,S27=@S27 WHERE IdUser=@IdUser"
                Else
                    SqlStr = "UPDATE SettingProgram SET FactorPaper=@FactorPaper,TypeFactor=@TypeFactor,FactorCount=@FactorCount,AnbarCount=@AnbarCount,Get_Pay_Count=@Get_Pay_Count,FilterKala=@FilterKala,TypeKala=@TypeKala,FilterP=@FilterP,TypeP=@TypeP,TypeAll=@TypeAll,S1=@S1,Barcode=@Barcode,IdAnbar=@IdAnbar,KalaDup=@KalaDup,Fish=@Fish,S2=@S2,S3=@S3,S4=@S4,S5=@S5,S6=@S6,S7=@S7,S27=@S27 WHERE IdUser=@IdUser"
                End If
            End If

            Using Cmd As New SqlCommand(SqlStr, ConectionBank)
                Cmd.Parameters.AddWithValue("@FactorPaper", SqlDbType.Int).Value = CmbFactorPaper.Items.IndexOf(CmbFactorPaper.Text)
                Select Case CmbTypeFactor.Items.IndexOf(CmbTypeFactor.Text)
                    'Case 0 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 0
                    'Case 1 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 5
                    'Case 2 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 6
                    'Case 3 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 2
                    'Case 4 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 1
                    'Case 5 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 4
                    'Case 6 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 3
                    Case 0 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 0
                    Case 1 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 5
                    Case 2 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 6
                    Case 3 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 7
                    Case 4 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 2
                    Case 5 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 1
                    Case 6 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 4
                    Case 7 : Cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 3
                End Select
                Cmd.Parameters.AddWithValue("@FactorCount", SqlDbType.Int).Value = NumFactor.Value
                Cmd.Parameters.AddWithValue("@AnbarCount", SqlDbType.Int).Value = NumAnbar.Value
                Cmd.Parameters.AddWithValue("@Get_Pay_Count", SqlDbType.Int).Value = NumGet_Pay.Value
                Cmd.Parameters.AddWithValue("@FilterKala", SqlDbType.Int).Value = CmbFilterKala.Items.IndexOf(CmbFilterKala.Text)
                Cmd.Parameters.AddWithValue("@TypeKala", SqlDbType.Int).Value = CmbTypeKala.Items.IndexOf(CmbTypeKala.Text)
                Cmd.Parameters.AddWithValue("@FilterP", SqlDbType.Int).Value = CmbFilterP.Items.IndexOf(CmbFilterP.Text)
                Cmd.Parameters.AddWithValue("@TypeP", SqlDbType.Int).Value = CmbTypeP.Items.IndexOf(CmbTypeP.Text)
                Cmd.Parameters.AddWithValue("@TypeAll", SqlDbType.Int).Value = CmbTypeAll.Items.IndexOf(CmbTypeAll.Text)
                Cmd.Parameters.AddWithValue("@Barcode", SqlDbType.Bit).Value = ChkBarcode.CheckState
                Cmd.Parameters.AddWithValue("@S1", SqlDbType.NVarChar).Value = If(ChkGroup.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = If(ChkAnbar.Checked = True, CmbAnbar.SelectedValue, DBNull.Value)
                Cmd.Parameters.AddWithValue("@KalaDup", SqlDbType.Bit).Value = ChkSum.CheckState
                Cmd.Parameters.AddWithValue("@Fish", SqlDbType.Bit).Value = ChKFish.CheckState
                Cmd.Parameters.AddWithValue("@S2", SqlDbType.NVarChar).Value = If(ChkCode.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@S3", SqlDbType.NVarChar).Value = If(RdoAuto.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@S4", SqlDbType.NVarChar).Value = If(RdoDasti.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@S5", SqlDbType.NVarChar).Value = If(RdoBig.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@S6", SqlDbType.NVarChar).Value = If(RdoSmall.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@S7", SqlDbType.NVarChar).Value = If(ChkMojodyKala.Checked = False, "0", "1")
                Cmd.Parameters.AddWithValue("@S27", SqlDbType.NVarChar).Value = GetInfoStr()
                If LEdit.Text = "0" Or UCase(NamUser) = "ADMIN" Then
                    Cmd.Parameters.AddWithValue("@S12", SqlDbType.NVarChar).Value = If(ChkAddBuy.Checked = False, "0", TxtAddBuy.Text)
                    Cmd.Parameters.AddWithValue("@S13", SqlDbType.NVarChar).Value = If(ChkDecBuy.Checked = False, "0", TxtDecBuy.Text)
                    Cmd.Parameters.AddWithValue("@S14", SqlDbType.NVarChar).Value = If(ChkAddFrosh.Checked = False, "0", TxtAddFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S15", SqlDbType.NVarChar).Value = If(ChkDecFrosh.Checked = False, "0", TxtDecFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S16", SqlDbType.NVarChar).Value = If(ChkAddBackBuy.Checked = False, "0", TxtAddBackBuy.Text)
                    Cmd.Parameters.AddWithValue("@S17", SqlDbType.NVarChar).Value = If(ChkDecBackBuy.Checked = False, "0", TxtDecBackBuy.Text)
                    Cmd.Parameters.AddWithValue("@S18", SqlDbType.NVarChar).Value = If(ChkAddBackFrosh.Checked = False, "0", TxtAddBackFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S19", SqlDbType.NVarChar).Value = If(ChkDecBackFrosh.Checked = False, "0", TxtDecBackFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S20", SqlDbType.NVarChar).Value = If(ChkAddService.Checked = False, "0", TxtAddService.Text)
                    Cmd.Parameters.AddWithValue("@S21", SqlDbType.NVarChar).Value = If(ChkDecService.Checked = False, "0", TxtDecService.Text)
                End If
                Cmd.ExecuteNonQuery()

            End Using

            If UCase(NamUser) = "ADMIN" Then
                Using Cmd As New SqlCommand("UPDATE SettingProgram SET S12=@S12,S13=@S13,S14=@S14,S15=@S15,S16=@S16,S17=@S17,S18=@S18,S19=@S19,S20=@S20,S21=@S21", ConectionBank)
                    Cmd.Parameters.AddWithValue("@S12", SqlDbType.NVarChar).Value = If(ChkAddBuy.Checked = False, "0", TxtAddBuy.Text)
                    Cmd.Parameters.AddWithValue("@S13", SqlDbType.NVarChar).Value = If(ChkDecBuy.Checked = False, "0", TxtDecBuy.Text)
                    Cmd.Parameters.AddWithValue("@S14", SqlDbType.NVarChar).Value = If(ChkAddFrosh.Checked = False, "0", TxtAddFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S15", SqlDbType.NVarChar).Value = If(ChkDecFrosh.Checked = False, "0", TxtDecFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S16", SqlDbType.NVarChar).Value = If(ChkAddBackBuy.Checked = False, "0", TxtAddBackBuy.Text)
                    Cmd.Parameters.AddWithValue("@S17", SqlDbType.NVarChar).Value = If(ChkDecBackBuy.Checked = False, "0", TxtDecBackBuy.Text)
                    Cmd.Parameters.AddWithValue("@S18", SqlDbType.NVarChar).Value = If(ChkAddBackFrosh.Checked = False, "0", TxtAddBackFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S19", SqlDbType.NVarChar).Value = If(ChkDecBackFrosh.Checked = False, "0", TxtDecBackFrosh.Text)
                    Cmd.Parameters.AddWithValue("@S20", SqlDbType.NVarChar).Value = If(ChkAddService.Checked = False, "0", TxtAddService.Text)
                    Cmd.Parameters.AddWithValue("@S21", SqlDbType.NVarChar).Value = If(ChkDecService.Checked = False, "0", TxtDecService.Text)
                    Cmd.ExecuteNonQuery()
                End Using
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تنظیمات", "ذخیره", "", "")

            Me.Close()
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSetting", "BtnSave_Click")
        End Try
    End Sub

    Private Function GetInfoStr() As String
        Try
            Dim str As String = ""
            str &= IIf(ChkGetDay.Checked = True, "1", "0")
            str &= IIf(ChkGetOld.Checked = True, NumGetOld.Value, "0")
            str &= IIf(ChkGetNew.Checked = True, NumGetNew.Value, "0")
            str &= IIf(ChkPayDay.Checked = True, "1", "0")
            str &= IIf(ChkPayOld.Checked = True, NumPayOld.Value, "0")
            str &= IIf(ChkPayNew.Checked = True, NumPayNew.Value, "0")
            str &= IIf(ChkLF.Checked = True, "1", "0")
            str &= IIf(ChkHF.Checked = True, "1", "0")
            str &= IIf(ChkBedRate.Checked = True, "1", "0")
            str &= IIf(ChkBesRate.Checked = True, "1", "0")
            str &= IIf(ChkMessage.Checked = True, "1", "0")
            Return str
        Catch ex As Exception
            Return "00000000000"
        End Try
    End Function

    Private Sub ChkMojodyAnbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        BtnSave.Enabled = True
        If ChkGroup.Checked = True Then
            ChkCode.Checked = False
        End If
    End Sub

    Private Sub ChkBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBarcode.CheckedChanged
        BtnSave.Enabled = True
        If ChkBarcode.Checked = True Then
            ChkAnbar.Enabled = True
            CmbAnbar.Enabled = True
            ChkSum.Enabled = True
            ChKFish.Enabled = True
            ChkCode.Checked = False
        Else
            ChKFish.Enabled = False
            ChKFish.Checked = False
            ChkSum.Enabled = False
            ChkSum.Checked = False
            ChkAnbar.Enabled = False
            ChkAnbar.Checked = False
            CmbAnbar.Enabled = False
        End If
    End Sub

    Private Sub ChkAnbar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnbar.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CmbAnbar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAnbar.SelectedIndexChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkSum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSum.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChKFish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKFish.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCode.CheckedChanged
        BtnSave.Enabled = True
        If ChkCode.Checked = True Then
            RdoAuto.Enabled = True
            RdoDasti.Enabled = True
            RdoAuto.Checked = True
            ChkGroup.Checked = False
        Else
            RdoAuto.Checked = False
            RdoDasti.Checked = False
            RdoAuto.Enabled = False
            RdoDasti.Enabled = False
        End If
    End Sub

    Private Sub RdoAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAuto.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub RdoDasti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDasti.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub RdoBig_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBig.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub RdoSmall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoSmall.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkMojodyKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMojodyKala.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBuy.CheckedChanged
        If ChkBuy.Checked = True Then
            ChkAddBuy.Enabled = True
            ChkDecBuy.Enabled = True
            ChkAddBuy.Checked = True
            ChkDecBuy.Checked = True
        Else
            ChkAddBuy.Enabled = False
            ChkDecBuy.Enabled = False
            ChkAddBuy.Checked = False
            ChkDecBuy.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFrosh.CheckedChanged
        If ChkFrosh.Checked = True Then
            ChkAddFrosh.Enabled = True
            ChkDecFrosh.Enabled = True
            ChkAddFrosh.Checked = True
            ChkDecFrosh.Checked = True
        Else
            ChkAddFrosh.Enabled = False
            ChkDecFrosh.Enabled = False
            ChkAddFrosh.Checked = False
            ChkDecFrosh.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkBackBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBackBuy.CheckedChanged
        If ChkBackBuy.Checked = True Then
            ChkAddBackBuy.Enabled = True
            ChkDecBackBuy.Enabled = True
            ChkAddBackBuy.Checked = True
            ChkDecBackBuy.Checked = True
        Else
            ChkAddBackBuy.Enabled = False
            ChkDecBackBuy.Enabled = False
            ChkAddBackBuy.Checked = False
            ChkDecBackBuy.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkBackSell_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBackSell.CheckedChanged
        If ChkBackSell.Checked = True Then
            ChkAddBackFrosh.Enabled = True
            ChkDecBackFrosh.Enabled = True
            ChkAddBackFrosh.Checked = True
            ChkDecBackFrosh.Checked = True
        Else
            ChkAddBackFrosh.Enabled = False
            ChkDecBackFrosh.Enabled = False
            ChkAddBackFrosh.Checked = False
            ChkDecBackFrosh.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkService_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkService.CheckedChanged
        If ChkService.Checked = True Then
            ChkAddService.Enabled = True
            ChkDecService.Enabled = True
            ChkAddService.Checked = True
            ChkDecService.Checked = True
        Else
            ChkAddService.Enabled = False
            ChkDecService.Enabled = False
            ChkAddService.Checked = False
            ChkDecService.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkAddBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAddBuy.CheckedChanged
        If ChkAddBuy.Checked = True Then
            TxtAddBuy.Enabled = True
            TxtAddBuy.Text = 0
        Else
            TxtAddBuy.Enabled = False
            TxtAddBuy.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkAddFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAddFrosh.CheckedChanged
        If ChkAddFrosh.Checked = True Then
            TxtAddFrosh.Enabled = True
            TxtAddFrosh.Text = 0
        Else
            TxtAddFrosh.Enabled = False
            TxtAddFrosh.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkAddBackBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAddBackBuy.CheckedChanged
        If ChkAddBackBuy.Checked = True Then
            TxtAddBackBuy.Enabled = True
            TxtAddBackBuy.Text = 0
        Else
            TxtAddBackBuy.Enabled = False
            TxtAddBackBuy.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkAddBackFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAddBackFrosh.CheckedChanged
        If ChkAddBackFrosh.Checked = True Then
            TxtAddBackFrosh.Enabled = True
            TxtAddBackFrosh.Text = 0
        Else
            TxtAddBackFrosh.Enabled = False
            TxtAddBackFrosh.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkAddService_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAddService.CheckedChanged
        If ChkAddService.Checked = True Then
            TxtAddService.Enabled = True
            TxtAddService.Text = 0
        Else
            TxtAddService.Enabled = False
            TxtAddService.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkDecBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDecBuy.CheckedChanged
        If ChkDecBuy.Checked = True Then
            TxtDecBuy.Enabled = True
            TxtDecBuy.Text = 0
        Else
            TxtDecBuy.Enabled = False
            TxtDecBuy.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkDecFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDecFrosh.CheckedChanged
        If ChkDecFrosh.Checked = True Then
            TxtDecFrosh.Enabled = True
            TxtDecFrosh.Text = 0
        Else
            TxtDecFrosh.Enabled = False
            TxtDecFrosh.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkDecBackBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDecBackBuy.CheckedChanged
        If ChkDecBackBuy.Checked = True Then
            TxtDecBackBuy.Enabled = True
            TxtDecBackBuy.Text = 0
        Else
            TxtDecBackBuy.Enabled = False
            TxtDecBackBuy.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkDecBackFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDecBackFrosh.CheckedChanged
        If ChkDecBackFrosh.Checked = True Then
            TxtDecBackFrosh.Enabled = True
            TxtDecBackFrosh.Text = 0
        Else
            TxtDecBackFrosh.Enabled = False
            TxtDecBackFrosh.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkDecService_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDecService.CheckedChanged
        If ChkDecService.Checked = True Then
            TxtDecService.Enabled = True
            TxtDecService.Text = 0
        Else
            TxtDecService.Enabled = False
            TxtDecService.Text = ""
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub TxtAddBuy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddBuy.KeyPress
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
            If InStr(TxtAddBuy.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtAddBuy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddBuy.LostFocus
        If CDbl(TxtAddBuy.Text) > 100 Then TxtAddBuy.Text = 100
        TxtAddBuy.Text = Math.Round(CDbl(TxtAddBuy.Text), 2)
    End Sub

    Private Sub TxtAddBuy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddBuy.TextChanged
        Try
            If Not (CheckDigit(TxtAddBuy.Text)) Then
                TxtAddBuy.Text = 0
                TxtAddBuy.SelectAll()
                Exit Sub
            End If

            If Not TxtAddBuy.Text.Trim.Contains(".") Then TxtAddBuy.Text = CDbl(TxtAddBuy.Text)
            If CDbl(TxtAddBuy.Text) > 100 Then TxtAddBuy.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtDecBuy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecBuy.KeyPress
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
            If InStr(TxtDecBuy.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDecBuy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecBuy.LostFocus
        If CDbl(TxtDecBuy.Text) > 100 Then TxtDecBuy.Text = 100
        TxtDecBuy.Text = Math.Round(CDbl(TxtDecBuy.Text), 2)
    End Sub

    Private Sub TxtDecBuy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecBuy.TextChanged
        Try
            If Not (CheckDigit(TxtDecBuy.Text)) Then
                TxtDecBuy.Text = 0
                TxtDecBuy.SelectAll()
                Exit Sub
            End If

            If Not TxtDecBuy.Text.Trim.Contains(".") Then TxtDecBuy.Text = CDbl(TxtDecBuy.Text)
            If CDbl(TxtDecBuy.Text) > 100 Then TxtDecBuy.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtAddFrosh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddFrosh.KeyPress
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
            If InStr(TxtAddFrosh.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtAddFrosh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddFrosh.LostFocus
        If CDbl(TxtAddFrosh.Text) > 100 Then TxtAddFrosh.Text = 100
        TxtAddFrosh.Text = Math.Round(CDbl(TxtAddFrosh.Text), 2)
    End Sub

    Private Sub TxtAddFrosh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddFrosh.TextChanged
        Try
            If Not (CheckDigit(TxtAddFrosh.Text)) Then
                TxtAddFrosh.Text = 0
                TxtAddFrosh.SelectAll()
                Exit Sub
            End If

            If Not TxtAddFrosh.Text.Trim.Contains(".") Then TxtAddFrosh.Text = CDbl(TxtAddFrosh.Text)
            If CDbl(TxtAddFrosh.Text) > 100 Then TxtAddFrosh.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtDecFrosh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecFrosh.KeyPress
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
            If InStr(TxtDecFrosh.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDecFrosh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecFrosh.LostFocus
        If CDbl(TxtDecFrosh.Text) > 100 Then TxtDecFrosh.Text = 100
        TxtDecFrosh.Text = Math.Round(CDbl(TxtDecFrosh.Text), 2)
    End Sub

    Private Sub TxtDecFrosh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecFrosh.TextChanged
        Try
            If Not (CheckDigit(TxtDecFrosh.Text)) Then
                TxtDecFrosh.Text = 0
                TxtDecFrosh.SelectAll()
                Exit Sub
            End If

            If Not TxtDecFrosh.Text.Trim.Contains(".") Then TxtDecFrosh.Text = CDbl(TxtDecFrosh.Text)
            If CDbl(TxtDecFrosh.Text) > 100 Then TxtDecFrosh.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtAddBackBuy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddBackBuy.KeyPress
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
            If InStr(TxtAddBackBuy.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtAddBackBuy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddBackBuy.LostFocus
        If CDbl(TxtAddBackBuy.Text) > 100 Then TxtAddBackBuy.Text = 100
        TxtAddBackBuy.Text = Math.Round(CDbl(TxtAddBackBuy.Text), 2)
    End Sub

    Private Sub TxtAddBackBuy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddBackBuy.TextChanged
        Try
            If Not (CheckDigit(TxtAddBackBuy.Text)) Then
                TxtAddBackBuy.Text = 0
                TxtAddBackBuy.SelectAll()
                Exit Sub
            End If

            If Not TxtAddBackBuy.Text.Trim.Contains(".") Then TxtAddBackBuy.Text = CDbl(TxtAddBackBuy.Text)
            If CDbl(TxtAddBackBuy.Text) > 100 Then TxtAddBackBuy.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtDecBackBuy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecBackBuy.KeyPress
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
            If InStr(TxtDecBackBuy.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDecBackBuy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecBackBuy.LostFocus
        If CDbl(TxtDecBackBuy.Text) > 100 Then TxtDecBackBuy.Text = 100
        TxtDecBackBuy.Text = Math.Round(CDbl(TxtDecBackBuy.Text), 2)
    End Sub

    Private Sub TxtDecBackBuy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecBackBuy.TextChanged
        Try
            If Not (CheckDigit(TxtDecBackBuy.Text)) Then
                TxtDecBackBuy.Text = 0
                TxtDecBackBuy.SelectAll()
                Exit Sub
            End If

            If Not TxtDecBackBuy.Text.Trim.Contains(".") Then TxtDecBackBuy.Text = CDbl(TxtDecBackBuy.Text)
            If CDbl(TxtDecBackBuy.Text) > 100 Then TxtDecBackBuy.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtAddBackFrosh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddBackFrosh.KeyPress
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
            If InStr(TxtAddBackFrosh.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtAddBackFrosh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddBackFrosh.LostFocus
        If CDbl(TxtAddBackFrosh.Text) > 100 Then TxtAddBackFrosh.Text = 100
        TxtAddBackFrosh.Text = Math.Round(CDbl(TxtAddBackFrosh.Text), 2)
    End Sub

    Private Sub TxtAddBackFrosh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddBackFrosh.TextChanged
        Try
            If Not (CheckDigit(TxtAddBackFrosh.Text)) Then
                TxtAddBackFrosh.Text = 0
                TxtAddBackFrosh.SelectAll()
                Exit Sub
            End If

            If Not TxtAddBackFrosh.Text.Trim.Contains(".") Then TxtAddBackFrosh.Text = CDbl(TxtAddBackFrosh.Text)
            If CDbl(TxtAddBackFrosh.Text) > 100 Then TxtAddBackFrosh.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtDecBackFrosh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecBackFrosh.KeyPress
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
            If InStr(TxtDecBackFrosh.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDecBackFrosh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecBackFrosh.LostFocus
        If CDbl(TxtDecBackFrosh.Text) > 100 Then TxtDecBackFrosh.Text = 100
        TxtDecBackFrosh.Text = Math.Round(CDbl(TxtDecBackFrosh.Text), 2)
    End Sub

    Private Sub TxtDecBackFrosh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecBackFrosh.TextChanged
        Try
            If Not (CheckDigit(TxtDecBackFrosh.Text)) Then
                TxtDecBackFrosh.Text = 0
                TxtDecBackFrosh.SelectAll()
                Exit Sub
            End If

            If Not TxtDecBackFrosh.Text.Trim.Contains(".") Then TxtDecBackFrosh.Text = CDbl(TxtDecBackFrosh.Text)
            If CDbl(TxtDecBackFrosh.Text) > 100 Then TxtDecBackFrosh.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtAddService_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddService.KeyPress
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
            If InStr(TxtAddService.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtAddService_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddService.LostFocus
        If CDbl(TxtAddService.Text) > 100 Then TxtAddService.Text = 100
        TxtAddService.Text = Math.Round(CDbl(TxtAddService.Text), 2)
    End Sub

    Private Sub TxtAddService_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddService.TextChanged
        Try
            If Not (CheckDigit(TxtAddService.Text)) Then
                TxtAddService.Text = 0
                TxtAddService.SelectAll()
                Exit Sub
            End If

            If Not TxtAddService.Text.Trim.Contains(".") Then TxtAddService.Text = CDbl(TxtAddService.Text)
            If CDbl(TxtAddService.Text) > 100 Then TxtAddService.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtDecService_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDecService.KeyPress
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
            If InStr(TxtDecService.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDecService_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDecService.LostFocus
        If CDbl(TxtDecService.Text) > 100 Then TxtDecService.Text = 100
        TxtDecService.Text = Math.Round(CDbl(TxtDecService.Text), 2)
    End Sub

    Private Sub TxtDecService_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDecService.TextChanged
        Try
            If Not (CheckDigit(TxtDecService.Text)) Then
                TxtDecService.Text = 0
                TxtDecService.SelectAll()
                Exit Sub
            End If

            If Not TxtDecService.Text.Trim.Contains(".") Then TxtDecService.Text = CDbl(TxtDecService.Text)
            If CDbl(TxtDecService.Text) > 100 Then TxtDecService.Text = 100
            BtnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChkGetChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGetChk.CheckedChanged
        If ChkGetChk.Checked = True Then
            ChkGetDay.Enabled = True
            ChkGetOld.Enabled = True
            NumGetOld.Enabled = True
            ChkGetNew.Enabled = True
            NumGetNew.Enabled = True
            ChkGetDay.Checked = True
        Else
            ChkGetDay.Enabled = False
            ChkGetOld.Enabled = False
            NumGetOld.Enabled = False
            ChkGetNew.Enabled = False
            NumGetNew.Enabled = False
            ChkGetDay.Checked = False
            ChkGetOld.Checked = False
            ChkGetNew.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkPayChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPayChk.CheckedChanged
        If ChkPayChk.Checked = True Then
            ChkPayDay.Enabled = True
            ChkPayNew.Enabled = True
            NumPayNew.Enabled = True
            ChkPayOld.Enabled = True
            NumPayOld.Enabled = True
            ChkPayDay.Checked = True
        Else
            ChkPayDay.Enabled = False
            ChkPayNew.Enabled = False
            NumPayNew.Enabled = False
            ChkPayOld.Enabled = False
            NumPayOld.Enabled = False
            ChkPayDay.Checked = False
            ChkPayNew.Checked = False
            ChkPayOld.Checked = False
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkGetDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGetDay.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkGetOld_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGetOld.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub NumGet_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumGetOld.ValueChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkPayDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPayDay.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkPayNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPayNew.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub NumPay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumPayNew.ValueChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkLF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLF.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkHF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkHF.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkBedRate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBedRate.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkBesRate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBesRate.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkMessage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMessage.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkGetNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGetNew.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub ChkPayOld_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPayOld.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub NumGetNew_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumGetNew.ValueChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub NumPayOld_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumPayOld.ValueChanged
        BtnSave.Enabled = True
    End Sub
End Class