Public Class SeneSMS

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            If SMS = False Then
                MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtMessage.Text.Trim) Then
                MessageBox.Show("هیچ متنی جهت ارسال وجود ندارد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMessage.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtNumber.Text.Trim) Then
                MessageBox.Show("شماره گیرنده پیام را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNumber.Focus()
                Exit Sub
            End If
            btnConnect.Enabled = False
            TxtMessage.Enabled = False
            TxtNumber.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اختصاصی SMS ارسال", "ارسال", "ارسال به شماره :" & TxtNumber.Text & "متن پیام:" & TxtMessage.Text, "")

            Dim lSendReference As Long
            ActiveSMS.axKylixSMS.RequestDeliveryReport = cbRequestReport.Checked.CompareTo(False)
            ActiveSMS.axKylixSMS.SendInterval = 2
            ActiveSMS.axKylixSMS.SendRetryTimes = 2
            ActiveSMS.axKylixSMS.SendTimeout = 28
            ActiveSMS.axKylixSMS.SMSValidity = 6
            lSendReference = ActiveSMS.axKylixSMS.SendSMS(TxtNumber.Text.Trim, TxtMessage.Text.Trim)
            If (lSendReference < 1) Then
                ActiveSMS.axKylixSMS.GetLastError(1)
                btnConnect.Enabled = True
                TxtMessage.Enabled = True
                TxtNumber.Enabled = True
            Else
                MessageBox.Show("پیام با موفقیت ارسال شد ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnConnect.Enabled = True
                TxtMessage.Enabled = True
                TxtNumber.Enabled = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SeneSMS", "btnConnect_Click")
            btnConnect.Enabled = True
            TxtMessage.Enabled = True
            TxtNumber.Enabled = True
        End Try
    End Sub

    Private Sub TxtNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumber.KeyPress
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

    Private Sub cbRequestReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRequestReport.CheckedChanged
        ActiveSMS.axKylixSMS.RequestDeliveryReport = cbRequestReport.Checked.CompareTo(False)
        DeleverSMS = cbRequestReport.Checked.CompareTo(False)
    End Sub

    Private Sub SeneSMS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnConnect.Enabled = False Then
            e.Cancel = True
            Exit Sub
        End If
        DeleverSMS = False
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PrivateSMS.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If btnConnect.Enabled = True Then btnConnect_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SeneSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub SeneSMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F109")
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
End Class