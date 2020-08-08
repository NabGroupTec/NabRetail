Public Class FrmRasChk

    Private Sub Txtmon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmon.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
    End Sub

    Private Sub Txtmon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmon.KeyPress
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

    Private Sub Txtmon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtmon.TextChanged
        If Not (CheckDigit(Format$(Txtmon.Text.Replace(",", "")))) Then
            Txtmon.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If Txtmon.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(Txtmon.Text.Replace(",", ""))
            Txtmon.Text = Format$(Val(str), "###,###,###")
        Else
            Txtmon.Text = CDbl(Txtmon.Text)
        End If
    End Sub

    Private Sub TxtPayDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayDate.KeyDowned
        If e.KeyCode = Keys.Enter Then Txtmon.Focus()
    End Sub

    Private Sub TxtPayDate_TextChanging(ByVal sender As Object, ByVal e As String) Handles TxtPayDate.TextChanging
        Try
            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                LDate.Text = ""
                LTime.Text = "0" & " روز "
            Else
                Dim StringDate As New NumberToString
                LDate.Text = StringDate.DateToPersianNonvertor(StringDate.PersianToDateConvertor(TxtPayDate.ThisText))
                LTime.Text = SUBDAY(TxtPayDate.ThisText, FarsiDate1.ThisText) & " روز "
            End If
        Catch ex As Exception
            LDate.Text = ""
        End Try
    End Sub

    Private Sub LTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTime.Click
        Try
            Dim res As Long = 0
            res = CLng(LTime.Text.Trim.Replace("روز", ""))
            If res > 0 Then
                LTime.ForeColor = Color.Black
            ElseIf res < 0 Then
                LTime.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmRasChk_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtPayDate.Focus()
    End Sub

    Private Sub FrmRasChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmRasChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV1.Columns("Cln_Mon").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TxtPayDate.ThisText = GetDate()
        FarsiDate1.ThisText = GetDate()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        If String.IsNullOrEmpty(FarsiDate1.ThisText) Or FarsiDate1.ThisText = "" Then
            MessageBox.Show("تاریخ مبداء را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FarsiDate1.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtPayDate.ThisText) Or TxtPayDate.ThisText = "" Then
            MessageBox.Show("سر رسید را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtPayDate.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(Txtmon.Text) Or Txtmon.Text = "0" Then
            MessageBox.Show("مبلغ چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Txtmon.Focus()
            Exit Sub
        End If

        DGV1.Rows.Add()
        DGV1.Item("Cln_Date", DGV1.RowCount - 1).Value = TxtPayDate.ThisText
        DGV1.Item("Cln_day", DGV1.RowCount - 1).Value = If(SUBDAY(TxtPayDate.ThisText, FarsiDate1.ThisText) = 0, 1, SUBDAY(TxtPayDate.ThisText, FarsiDate1.ThisText))
        DGV1.Item("Cln_Mon", DGV1.RowCount - 1).Value = CDbl(Txtmon.Text)

        Me.RasChk()
        TxtPayDate.ThisText = GetDate()
        Txtmon.Text = 0
        TxtPayDate.Focus()
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        If DGV1.RowCount > 0 Then
            If e.KeyCode = Keys.Delete Then
                DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                Me.RasChk()
            End If
        End If
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub TxtAllMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAllMon.TextChanged
        If Not (CheckDigit(Format$(TxtAllMon.Text.Replace(",", "")))) Then
            TxtAllMon.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtAllMon.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtAllMon.Text.Replace(",", ""))
            TxtAllMon.Text = Format$(Val(str), "###,###,###")
        Else
            TxtAllMon.Text = CDbl(TxtAllMon.Text)
        End If
    End Sub
    Private Sub RasChk()
        Try

            Dim MonChk As Double = 0
            Dim AllMonChk As Double = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                MonChk += CDbl(DGV1.Item("Cln_Mon", i).Value)
                AllMonChk += CDbl(DGV1.Item("Cln_Mon", i).Value) * CLng(DGV1.Item("Cln_day", i).Value)
            Next
            TxtAllMon.Text = IIf(MonChk = 0, 0, FormatNumber(MonChk, 0))
            TxtRasChk.Text = Replace(Format$(AllMonChk / MonChk, "###.##"), ".", "/")
            If UCase(TxtRasChk.Text) = "NAN" Then TxtRasChk.Text = 0

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmRasChk", "RasChk")
        End Try
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Me.RasChk()
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Raes.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnEdit.Enabled = True Then BtnEdit_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtPayDate.Focus()
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                DGV1.Item("Cln_day", i).Value = If(SUBDAY(DGV1.Item("Cln_Date", i).Value, FarsiDate1.ThisText) = 0, 1, SUBDAY(DGV1.Item("Cln_Date", i).Value, FarsiDate1.ThisText))
            Next
            Me.RasChk()
        End If

        Try
            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                LDate.Text = ""
                LTime.Text = "0" & " روز "
            Else
                Dim StringDate As New NumberToString
                LDate.Text = StringDate.DateToPersianNonvertor(StringDate.PersianToDateConvertor(TxtPayDate.ThisText))
                LTime.Text = SUBDAY(TxtPayDate.ThisText, FarsiDate1.ThisText) & " روز "
            End If
        Catch ex As Exception
            LDate.Text = ""
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("چکی برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Using FrmEdit As New FrmEditRasChk
                FrmEdit.TxtPayDate.ThisText = DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value
                FrmEdit.Txtmon.Text = DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value
                FrmEdit.LOne.Text = FarsiDate1.ThisText
                FrmEdit.LTime.Text = DGV1.Item("Cln_day", DGV1.CurrentRow.Index).Value & " روز "
                FrmEdit.ShowDialog()
                If FrmEdit.Ledit.Text = "0" Then Exit Sub
                DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value = FrmEdit.TxtPayDate.ThisText
                DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = FrmEdit.Txtmon.Text
                DGV1.Item("Cln_day", DGV1.CurrentRow.Index).Value = If(SUBDAY(DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value, FarsiDate1.ThisText) = 0, 1, SUBDAY(DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value, FarsiDate1.ThisText))
                Me.RasChk()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmRasChk", "BtnEdit_Click")
        End Try
    End Sub

End Class