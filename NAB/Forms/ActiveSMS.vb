Public Class ActiveSMS

    Dim usd As Boolean
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If btnConnect.Enabled = False Then
                e.Cancel = True
                Exit Sub
            End If
            SMS = False
            axKylixSMS.Disconnect()
            axKylixSMS.Dispose()
        Catch ex As Exception
            Try
                SMS = False
                If Not axKylixSMS Is Nothing Then axKylixSMS.Dispose()
            Catch ey As Exception

            End Try
        End Try
    End Sub

    Private Sub ActiveSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F108")
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

        If SMS = False Then
            usd = False
            cmbMode.SelectedIndex = 0
            cmbProtocol.SelectedIndex = 0
            cboPort.Items.Clear()
            cboPort.Items.Add("انتخاب پورت")
            For i As Integer = 1 To 256
                cboPort.Items.Add("COM" & i.ToString)
            Next
            cboPort.SelectedIndex = 0
            cboBaudRate.Items.Clear()
            With cboBaudRate
                .Items.Add("انتخاب سرعت")
                .Items.Add("110")
                .Items.Add("300")
                .Items.Add("1200")
                .Items.Add("2400")
                .Items.Add("4800")
                .Items.Add("9600")
                .Items.Add("14400")
                .Items.Add("19200")
                .Items.Add("38400")
                .Items.Add("57600")
                .Items.Add("115200")
                .Items.Add("230400")
                .Items.Add("460800")
                .Items.Add("921600")
            End With
            cboBaudRate.SelectedIndex = 0
            Try
                If btnConnect.Enabled = True Then
                    NI1.Visible = False
                Else
                    NI1.Visible = True
                End If
                cbIsConcatenatedSMS.Checked = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            If cboPort.SelectedIndex = 0 Then
                MessageBox.Show("پورت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboPort.Focus()
                Exit Sub
            End If
            If cboBaudRate.SelectedIndex = 0 Then
                MessageBox.Show("سرعت پورت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboBaudRate.Focus()
                Exit Sub
            End If
            btnConnect.Enabled = False
            GroupBox1.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فعال سازی سرویس SMS", "اتصال", "", "")

            'axKylixSMS.RegisterName = "000000000000000"
            'axKylixSMS.RegisterCode = "000000000000000000000000000000000000000000"
            axKylixSMS.NeedLog = 1
            axKylixSMS.PINCode = PINCode.Text
            axKylixSMS.ConnectionMode = cmbMode.SelectedIndex + 1
            axKylixSMS.ConnectionProtocol = cmbProtocol.SelectedIndex + 1
            axKylixSMS.ConnectionParameter = cboPort.Items(cboPort.SelectedIndex) & "," & cboBaudRate.Items(cboBaudRate.SelectedIndex)
            If axKylixSMS.Connect() <> 1 Then
                axKylixSMS.GetLastError(1)
                btnConnect.Enabled = True
                GroupBox1.Enabled = True
                GroupBox2.Enabled = False
                GroupBox3.Enabled = False
                btnDisconnect.Enabled = False
                BtnWait.Enabled = False
                NI1.Visible = False
                SMS = False
                usd = False
            Else
                txtManufacture.Text = axKylixSMS.GetManufacturer()
                txtModel.Text = axKylixSMS.GetModel()
                txtIMEI.Text = axKylixSMS.GetIMEI()
                txtNetwork.Text = axKylixSMS.GetNetworkInfo()
                txtBattery.Text = axKylixSMS.GetBatteryLevel().ToString()
                txtSignal.Text = axKylixSMS.GetSignalLevel().ToString()
                txtFirmware.Text = axKylixSMS.GetFirmware()
                txtHardware.Text = axKylixSMS.GetHardware()
                txtTime.Text = axKylixSMS.GetTime()
                txtSMSCNumber.Text = axKylixSMS.GetSMSCNumber()
                Application.DoEvents()
                btnDisconnect.Enabled = True
                BtnWait.Enabled = True
                SMS = True
                GroupBox2.Enabled = True
                GroupBox3.Enabled = True
                NI1.Visible = True
                usd = False
                ' Me.GetSMSFolders()
                'btnReadAllSMS_Click(sender, e)
            End If
        Catch ex As Exception
            btnConnect.Enabled = True
            GroupBox1.Enabled = True
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            btnDisconnect.Enabled = False
            BtnWait.Enabled = True
            BtnWait.Enabled = False
            SMS = False
            NI1.Visible = False
            usd = False
        End Try
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        Try
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فعال سازی سرویس SMS", "قطع اتصال", "", "")
            axKylixSMS.Disconnect()
            txtManufacture.Clear()
            txtModel.Clear()
            txtIMEI.Clear()
            txtNetwork.Clear()
            txtBattery.Clear()
            txtSignal.Clear()
            txtFirmware.Clear()
            txtHardware.Clear()
            txtTime.Clear()
            txtSMSCNumber.Clear()
            cmbSMSFolder.Items.Clear()
            btnConnect.Enabled = True
            GroupBox1.Enabled = True
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            btnDisconnect.Enabled = False
            BtnWait.Enabled = False
            SMS = False
            NI1.Visible = False
            usd = False
        Catch ex As Exception
            SMS = False
            usd = False
            NI1.Dispose()
            Me.Close()
        End Try
    End Sub
    Public Function GetSMSFolders() As Integer

        Dim i As Integer
        Dim strFolderName As String
        cmbSMSFolder.Items.Clear()
        For i = 0 To 49
            strFolderName = axKylixSMS.GetSMSFolderInfo(i + 1)
            If (strFolderName <> "") Then
                cmbSMSFolder.Items.Add(strFolderName)
            End If
        Next
        If (i > 0) Then
            cmbSMSFolder.SelectedIndex = 0
            Return i
        End If
    End Function

    Private Sub cbRequestReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRequestReport.CheckedChanged
        axKylixSMS.RequestDeliveryReport = cbRequestReport.Checked.CompareTo(False)
    End Sub

    Private Sub cbIsConcatenatedSMS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIsConcatenatedSMS.CheckedChanged
        axKylixSMS.IsConcatenatedSMS = cbIsConcatenatedSMS.Checked.CompareTo(False)
    End Sub

    Private Sub cbAutoDeleteAllReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutoDeleteAllReport.CheckedChanged
        axKylixSMS.AutoDeleteAllReport = cbAutoDeleteAllReport.Checked.CompareTo(False)
    End Sub

    Private Sub cbAutoDeleteNewSMS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutoDeleteNewSMS.CheckedChanged
        axKylixSMS.AutoDeleteNewSMS = cbAutoDeleteNewSMS.Checked.CompareTo(False)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MessageBox.Show("گزینه های انتخاب جهت ارتباط با دستگاه" & vbCrLf & vbCrLf & vbCrLf & "اگر درایور دستگاه نصب شده باشد:  Physical/Virtual COM" & vbCrLf & vbCrLf & " برقراری ارتباط به وسیله مادون قرمز:  Infrared" & vbCrLf & vbCrLf & " برقراری ارتباط به وسیله بلوتوث:  Bluetooth" & vbCrLf & vbCrLf & " برقراری ارتباط به وسیله یو اس بی:  USB", "راهنمایی", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Show("گزینه های انتخاب پروتکل ارتباط با دستگاه" & vbCrLf & vbCrLf & vbCrLf & "اگر درایور دستگاه نصب شده باشد:  AT Command" & vbCrLf & vbCrLf & " اگر از گوشی استفاده میکنید و راه انداز نصب نیست:  Nokia FBUS" & vbCrLf & vbCrLf & " اگر از گوشی استفاده میکنید و راه انداز نصب نیست:  Nokia FBUS", "راهنمایی", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("شماره پورتی که دستگاه مورد نظر روی آن نصب شده است را انتخاب کنید" & vbCrLf & vbCrLf & "جهت پیدا کردن شماره پورت به مسیر زیر بروید" & vbCrLf & vbCrLf & "Device Manager\کلیک راست \مودم مورد نظر\Properties\Modem Tab\", "راهنمایی", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MessageBox.Show("سرعت پورتی که دستگاه مورد نظر با آن کار میکند" & vbCrLf & vbCrLf & "جهت پیدا کردن سرعت پورت به مسیر زیر بروید" & vbCrLf & vbCrLf & "Device Manager\کلیک راست \مودم مورد نظر\Properties\Modem Tab\", "راهنمایی", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MessageBox.Show("اگر از گوشی استفاده می کنید و پین کد آن فعال است آن را وارد کنید", "راهنمایی", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWait.Click
        usd = False
        SMS = True
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فعال سازی سرویس SMS", "حالت انتظار", "", "")
        Me.Hide()
    End Sub

    Private Sub axKylixSMS_NewDeliveryReport(ByVal sender As Object, ByVal e As AxKYLIXSMSLib._DKylixSMSEvents_NewDeliveryReportEvent) Handles axKylixSMS.NewDeliveryReport

        Dim strResult As String = ""
        If (e.status = 1) Then
            strResult = "پیام در مقصد مورد نظر دریافت شد " & vbCrLf & vbCrLf & "شماره گیرنده پیام :" & e.number
        ElseIf (e.status = 2) Then
            strResult = "پیام به مقصد نرسید " & vbCrLf & vbCrLf & "شماره گیرنده پیام :" & e.number
        Else
            strResult = "وضعیت پیام ارسال شده نامشخص است " & vbCrLf & vbCrLf & "شماره گیرنده پیام :" & e.number
        End If
        If DeleverSMS = True Then
            MessageBox.Show(strResult, "گزارش درخواست تحویل", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub NI1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NI1.Click
        Me.Show()
        Me.Focus()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ActiveSMS.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If btnConnect.Enabled = True Then btnConnect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If btnDisconnect.Enabled = True Then btnDisconnect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnWait.Enabled = True Then BtnWait_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If Button6.Enabled = True Then Button6_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If String.IsNullOrEmpty(TxtCode.Text) Then
                MessageBox.Show("کد درخواست خدمات سیم کارت مربوطه را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCode.Focus()
                Exit Sub
            End If

            If axKylixSMS.DialUSSD(TxtCode.Text.Trim) <> 1 Then
                MessageBox.Show("خطا در کد خدمات ارسالی " & vbCrLf & "Error in USSD : " & axKylixSMS.GetLastError(0).ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            usd = True
        Catch ex As Exception
            usd = False
        End Try
    End Sub

    Private Sub axKylixSMS_NewUSSD(ByVal sender As Object, ByVal e As AxKYLIXSMSLib._DKylixSMSEvents_NewUSSDEvent) Handles axKylixSMS.NewUSSD
        If usd = True Then
            MessageBox.Show(e.text, "خدمات سیم کارت", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        usd = False
    End Sub
End Class
