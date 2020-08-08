Imports System.Data.SqlClient
Public Class SendPathSMS
    Public Query, namcompany As String

    Private Sub SendGlobalSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmBeDBes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetPeople()
        namcompany = GetNamCompany()
        CheckBox1.Checked = True
        DGV1.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetPeople()
        Dim ds As New DataSet
        Dim dta As New SqlDataAdapter
        ds.Clear()
       
        If Not dta Is Nothing Then dta.Dispose()
        dta = New SqlDataAdapter(Query, DataSource)
        dta.Fill(ds)
        DGV1.AutoGenerateColumns = False
        DGV1.DataSource = ds.Tables(0)

        If DGV1.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV1.RowCount - 1
            DGV1.Item("Cln_Select", i).Value = True
        Next

        If DGV1.RowCount > 0 Then CheckBox3.Checked = True
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        If e.KeyCode = Keys.Delete And DGV1.RowCount > 0 And Button2.Enabled = True Then DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        Try
            If DGV1.Item("cln_Tell", e.RowIndex).Value Is DBNull.Value Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Tell", e.RowIndex).Value = "" Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf Not IsNumeric(DGV1.Item("cln_Tell", e.RowIndex).Value) Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf Trim(DGV1.Item("cln_Tell", e.RowIndex).Value).Contains(" ") Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf Trim(DGV1.Item("cln_Tell", e.RowIndex).Value) = "0" Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbuyer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.GetPeople()
        If CheckBox1.Checked = True Then
            DelInvalidNumber()
        End If
    End Sub

    Private Sub Chkseller_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.GetPeople()
        If CheckBox1.Checked = True Then
            DelInvalidNumber()
        End If
    End Sub

    Private Sub Chkother_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.GetPeople()
        If CheckBox1.Checked = True Then
            DelInvalidNumber()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(TxtMessage.Text.Trim) Then
            MessageBox.Show("هیچ متنی جهت ارسال وجود ندارد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMessage.Focus()
            Exit Sub
        End If
        Try
            Dim c As Integer = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then c += 1
            Next
            If c <= 0 Then
                MessageBox.Show("هیچ طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            GroupBox3.Enabled = False
            Button2.Enabled = False
            Button1.Enabled = True
            DGV1.Columns("Cln_Select").ReadOnly = True
            '//////////////////////////////////
            For i As Integer = 0 To DGV1.RowCount - 1
                If Button2.Enabled = True Then
                    Exit For
                End If
                If DGV1.Item("cln_Tell", i).Value Is DBNull.Value Then
                    Continue For
                ElseIf Trim(DGV1.Item("cln_Tell", i).Value) = "" Then
                    Continue For
                ElseIf Not IsNumeric(DGV1.Item("cln_Tell", i).Value) Then
                    Continue For
                ElseIf Trim(DGV1.Item("cln_Tell", i).Value).Contains(" ") Then
                    Continue For
                ElseIf Trim(DGV1.Item("cln_Tell", i).Value) = "0" Then
                    Continue For
                ElseIf DGV1.Item("Cln_Select", i).Value = False Then
                    Continue For
                Else
                    DGV1.Item("Cln_Name", i).Selected = True
                    DGV1.Rows(i).Selected = True
                    Application.DoEvents()

                    Dim lSendReference As Long
                    ActiveSMS.axKylixSMS.RequestDeliveryReport = False
                    ActiveSMS.axKylixSMS.SendInterval = 2
                    ActiveSMS.axKylixSMS.SendRetryTimes = 2
                    ActiveSMS.axKylixSMS.SendTimeout = 28
                    ActiveSMS.axKylixSMS.SMSValidity = 6
                    lSendReference = ActiveSMS.axKylixSMS.SendSMS(DGV1.Item("cln_Tell", i).Value, TxtMessage.Text.Trim & If(CheckBox2.Checked = True, " تاریخ آخرین خرید:" & DGV1.Item("Cln_date", i).Value & ".", "") & If(CheckBox4.Checked = True, " از طرف:" & namcompany, ""))
                    If (lSendReference < 1) Then
                        Continue For
                    Else
                        DGV1.Item("Cln_Send", i).Value = True
                    End If
                End If
            Next
            '//////////////////////////////////
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
            GroupBox3.Enabled = True
            Button2.Enabled = True
            Button1.Enabled = False
            DGV1.Columns("Cln_Select").ReadOnly = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendPathSMS", "Button2_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Me.GetPeople()
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
                ElseIf Trim(DGV1.Item("cln_Tell", i).Value) = "0" Then
                    DGV1.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendPathSMS", "DelInvalidNumber")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
        GroupBox3.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = False
        DGV1.Columns("Cln_Select").ReadOnly = True
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If DGV1.RowCount <= 0 Then Exit Sub
        If CheckBox3.Checked = True Then
            For i As Integer = 0 To DGV1.RowCount - 1
                DGV1.Item("Cln_Select", i).Value = True
            Next
        Else
            For i As Integer = 0 To DGV1.RowCount - 1
                DGV1.Item("Cln_Select", i).Value = False
            Next
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "12.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

End Class