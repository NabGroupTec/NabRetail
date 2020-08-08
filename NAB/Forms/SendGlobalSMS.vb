Imports System.Data.SqlClient
Public Class SendGlobalSMS

    Private Sub SendGlobalSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub FrmBeDBes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F110")
        If (Access_Form <> "-1") Then
            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    Chkbuyer.Checked = True
                    Chkseller.Checked = True
                    Chkother.Checked = True
                    Me.GetPeople()
                    DGV1.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            End If
        Else
            Chkbuyer.Checked = True
            Chkseller.Checked = True
            Chkother.Checked = True
            Me.GetPeople()
            DGV1.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    Private Sub GetPeople()
        Dim ds As New DataSet
        Dim dta As New SqlDataAdapter
        ds.Clear()
        If Chkother.Checked = False And Chkseller.Checked = False And Chkbuyer.Checked = False Then
            DGV1.DataSource = Nothing
            Exit Sub
        End If
        If Not dta Is Nothing Then dta.Dispose()
        Dim other As String = If(Chkother.Checked = True, "Other='True'", "")
        Dim buyer As String = If(Chkbuyer.Checked = True, "buyer='True'", "")
        Dim seller As String = If(Chkseller.Checked = True, "seller='True'", "")
        dta = New SqlDataAdapter("SELECT ID,Nam,ISNULL(Tell2,'') as Tell2,Seller,Buyer,Other,ISNULL(NamFac,'') AS NamFac FROM Define_People WHERE " & other & If(other = "", seller, If(seller = "", "", " OR " & seller)) & If(seller = "" And other = "", buyer, If(buyer = "", "", " OR " & buyer)) & " Order By Nam Asc;", DataSource)
        dta.Fill(ds)
        DGV1.AutoGenerateColumns = False
        DGV1.DataSource = ds.Tables(0)
        If DGV1.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV1.RowCount - 1
            DGV1.Item("Cln_Select", i).Value = True
        Next
        If DGV1.RowCount > 0 Then CheckBox3.Checked = True
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
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkbuyer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbuyer.CheckedChanged
        Me.GetPeople()
        If CheckBox1.Checked = True Then
            DelInvalidNumber()
        End If
    End Sub

    Private Sub Chkseller_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkseller.CheckedChanged
        Me.GetPeople()
        If CheckBox1.Checked = True Then
            DelInvalidNumber()
        End If
    End Sub

    Private Sub Chkother_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkother.CheckedChanged
        Me.GetPeople()
        If CheckBox1.Checked = True Then
            DelInvalidNumber()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SMS = False Then
            MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
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
            GroupBox6.Enabled = False
            GroupBox3.Enabled = False
            CheckBox1.Enabled = False
            CheckBox3.Enabled = False
            BtnP.Enabled = False
            Button2.Enabled = False
            Button1.Enabled = True
            DGV1.Columns("Cln_Select").ReadOnly = True
            '//////////////////////////////////
            For i As Integer = 0 To DGV1.RowCount - 1
                If SMS = False Or Button2.Enabled = True Then
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
                ElseIf DGV1.Item("Cln_Select", i).Value = False Then
                    Continue For
                Else
                    Application.DoEvents()
                    DGV1.Item("Cln_Name", i).Selected = True
                    Application.DoEvents()
                    Dim lSendReference As Long
                    ActiveSMS.axKylixSMS.RequestDeliveryReport = False
                    ActiveSMS.axKylixSMS.SendInterval = 2
                    ActiveSMS.axKylixSMS.SendRetryTimes = 2
                    ActiveSMS.axKylixSMS.SendTimeout = 28
                    ActiveSMS.axKylixSMS.SMSValidity = 6
                    lSendReference = ActiveSMS.axKylixSMS.SendSMS(DGV1.Item("cln_Tell", i).Value, If(ChkPeople.Checked = True, If(DGV1.Item("Cln_NamFac", i).Value Is DBNull.Value Or DGV1.Item("Cln_NamFac", i).Value = "", "مشتری گرامی ", DGV1.Item("Cln_NamFac", i).Value & " ") & DGV1.Item("Cln_Name", i).Value & " ", "") & TxtMessage.Text.Trim)
                    If (lSendReference < 1) Then
                        Continue For
                    Else
                        DGV1.Item("Cln_Send", i).Value = True
                    End If
                End If
            Next
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "عمومی SMS ارسال", "ارسال", "متن پیام:" & TxtMessage.Text, "")
            '//////////////////////////////////
            GroupBox6.Enabled = True
            GroupBox3.Enabled = True
            CheckBox1.Enabled = True
            CheckBox3.Enabled = True
            BtnP.Enabled = True
            Button2.Enabled = True
            Button1.Enabled = False
            DGV1.Columns("Cln_Select").ReadOnly = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendGlobalSMS", "Button2_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnP.Click
        Try
            Fnew = True
            Using FrmPeople As New DefinePeople
                FrmPeople.ShowDialog()
            End Using
            Fnew = False
            Me.GetPeople()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendGlobalSMS", "BtnP_Click")
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
                End If
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SendGlobalSMS", "DelInvalidNumber")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox5.Enabled = True
        GroupBox6.Enabled = True
        GroupBox3.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = False
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DGV1.RowCount <= 0 Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV1.RowCount > 1 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Id", i).Value = IdKala Then
                        DGV1.Item("Cln_Name", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV1.Item("Cln_Name", 0).Selected = True
                DGV1.Item("Cln_Name", 0).Selected = False
            End If
        End If
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PublicSMS.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnP.Enabled = True Then BtnP_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetPeople()
            If CheckBox1.Checked = True Then
                Me.DelInvalidNumber()
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If Button3.Enabled = True Then Button3_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If Button4.Enabled = True Then Button4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Using FrmAdVance As New People_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.Condition2 = "1"
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV1.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV1.Item("Cln_Id", i).Value Then DGV1.Item("Cln_Select", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV1.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub
End Class