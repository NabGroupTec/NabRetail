Imports System.Data.SqlClient
Public Class SendAllSMSTime
    Dim namcompany As String = ""
    Public Query As String

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        If e.KeyCode = Keys.Delete And DGV1.RowCount > 0 And Button1.Enabled = True Then DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
    End Sub
    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 5)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        Try
            If DGV1.Item("cln_Tell", e.RowIndex).Value Is DBNull.Value Then
                DGV1.Rows(e.RowIndex).Cells("cln_Tell").Style.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Tell", e.RowIndex).Value = "" Then
                DGV1.Rows(e.RowIndex).Cells("cln_Tell").Style.BackColor = Color.Pink
            ElseIf Not IsNumeric(DGV1.Item("cln_Tell", e.RowIndex).Value) Then
                DGV1.Rows(e.RowIndex).Cells("cln_Tell").Style.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Tell", e.RowIndex).Value = "0" Then
                DGV1.Rows(e.RowIndex).Cells("cln_Tell").Style.BackColor = Color.Pink
            End If

            If DGV1.Item("cln_Select", e.RowIndex).Value = True Then
                DGV1.Rows(e.RowIndex).Cells("cln_Select").Style.BackColor = Color.SpringGreen
            Else
                DGV1.Rows(e.RowIndex).Cells("cln_Select").Style.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SendAllSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub SendAllSMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        namcompany = GetNamCompany()
        Filldata()
        ChkInvalid.Checked = True
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub Filldata()
        Try
            DGV1.Rows.Clear()
            For i As Integer = 0 To ListDelayPrintArray.Length - 1
                DGV1.Rows.Add()
                DGV1.Item("cln_name", DGV1.RowCount - 1).Value = ListDelayPrintArray(i).nam
                DGV1.Item("cln_state", DGV1.RowCount - 1).Value = ListDelayPrintArray(i).IdFactor
                DGV1.Item("cln_tell", DGV1.RowCount - 1).Value = ListDelayPrintArray(i).Tell1
                DGV1.Item("cln_mon", DGV1.RowCount - 1).Value = ListDelayPrintArray(i).Mandeh
                DGV1.Item("Cln_Delay", DGV1.RowCount - 1).Value = ListDelayPrintArray(i).Rate
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendAllSMSTime", "Filldata")
            Me.Close()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV1.RowCount <= 0 Then
            MessageBox.Show("اطلاعاتی برای ارسال وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        For i As Integer = 0 To DGV1.RowCount - 1
            DGV1.Item("cln_Select", i).Value = False
        Next
        Try
            DeleverSMS = False
            Button1.Enabled = False
            ChkInvalid.Enabled = False
            DGV1.AllowUserToDeleteRows = False
            Button2.Enabled = True
            For i As Integer = 0 To DGV1.RowCount - 1
                DGV1.Item("cln_Select", i).Selected = True
                DGV1.Rows(i).Selected = True
                Application.DoEvents()

                If Button1.Enabled = True Then
                    Exit For
                End If
                If DGV1.Item("cln_Tell", i).Value Is DBNull.Value Then
                    Continue For
                ElseIf DGV1.Item("cln_Tell", i).Value = "" Then
                    Continue For
                ElseIf Not IsNumeric(DGV1.Item("cln_Tell", i).Value) Then
                    Continue For
                Else
                    '////////////////Send Message
                    Dim lSendReference As Long
                    ActiveSMS.axKylixSMS.RequestDeliveryReport = False
                    ActiveSMS.axKylixSMS.SendInterval = 2
                    ActiveSMS.axKylixSMS.SendRetryTimes = 2
                    ActiveSMS.axKylixSMS.SendTimeout = 28
                    ActiveSMS.axKylixSMS.SMSValidity = 6
                    lSendReference = ActiveSMS.axKylixSMS.SendSMS(DGV1.Item("cln_tell", i).Value, GetMessage(DGV1.Item("cln_name", i).Value, DGV1.Item("cln_Mon", i).Value, DGV1.Item("cln_State", i).Value, DGV1.Item("Cln_Delay", i).Value))
                    If (lSendReference < 1) Then
                        Continue For
                    Else
                        DGV1.Item("cln_Select", i).Value = True
                    End If
                End If
                Application.DoEvents()
                '////////////////
            Next
            Button1.Enabled = True
            ChkInvalid.Enabled = True
            DGV1.AllowUserToDeleteRows = True
            Button2.Enabled = False
            MessageBox.Show("ارسال اطلاعات به اتمام رسید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendAllSMSTime", "Button1_Click")
            Button1.Enabled = True
            ChkInvalid.Enabled = True
            DGV1.AllowUserToDeleteRows = True
            Button2.Enabled = False
        End Try
    End Sub

    Private Function GetMessage(ByVal nam As String, ByVal Mon As Double, ByVal Fac As Long, ByVal day As Long) As String
        Dim str As String = ""
        If day = 0 Then
            str = " وعده فاکتور " & Fac & "به مبلغ" & IIf(Mon <> 0, FormatNumber(Mon, 0), 0) & "به اتمام رسیده است " & " از طرف:" & namcompany
        ElseIf day > 0 Then
            str = day & " روز از وعده فاکتور " & Fac & "به مبلغ" & IIf(Mon <> 0, FormatNumber(Mon, 0), 0) & "مانده است " & " از طرف:" & namcompany
        ElseIf day < 0 Then
            str = day * (-1) & " روز از وعده فاکتور " & Fac & "به مبلغ" & IIf(Mon <> 0, FormatNumber(Mon, 0), 0) & "گذشته است " & " از طرف:" & namcompany
        End If
        Return str
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.DoEvents()
        Button1.Enabled = True
        ChkInvalid.Enabled = True
        DGV1.AllowUserToDeleteRows = True
        Button2.Enabled = False
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Bed.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ChkInvalid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInvalid.CheckedChanged
        If ChkInvalid.Checked = False Then
            Me.Filldata()
        Else
            Me.DelInvalidNumber()
        End If
    End Sub

    Private Sub DelInvalidNumber()
        Try
            For i As Integer = DGV1.RowCount - 1 To 0 Step -1
                If DGV1.Item("cln_Tell", i).Value Is DBNull.Value Then
                    DGV1.Rows.RemoveAt(i)
                ElseIf Trim(DGV1.Item("cln_Tell", i).Value) = "" Then
                    DGV1.Rows.RemoveAt(i)
                ElseIf Not IsNumeric(DGV1.Item("cln_Tell", i).Value) Then
                    DGV1.Rows.RemoveAt(i)
                ElseIf Trim(DGV1.Item("cln_Tell", i).Value).Contains(" ") Then
                    DGV1.Rows.RemoveAt(i)
                ElseIf DGV1.Item("cln_Tell", i).Value = "0" Then
                    DGV1.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendAllSMSTime", "DelInvalidNumber")
        End Try
    End Sub

End Class