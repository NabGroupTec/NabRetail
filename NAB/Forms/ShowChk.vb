Imports System.Data.SqlClient
Public Class ShowChk
    Public StrSql As String
    Public SumStrSql As String

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
            If DGV1.Item("Cln_PayDate", e.RowIndex).Value = GetDate() Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value > GetDate() Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value < GetDate() Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ShowChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.Show_Chk()
        DGV1.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV1.Sort(DGV1.Columns("Cln_payDate"), System.ComponentModel.ListSortDirection.Ascending)

        DGV2.Columns("Cln_MonChk").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Sort(DGV2.Columns("Cln_Date"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
    Private Sub CalculateMon()
        Try
            Txtallmoney.Text = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_MoneyChk", i).Value)
            Next
            If Txtallmoney.Text.Length > 3 Then
                Dim Str As String = Format$(Txtallmoney.Text.Replace(",", ""))
                Txtallmoney.Text = Format$(Val(Str), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Show_Chk()
        Try
            Dim ds As New DataTable
            Dim dta As New SqlDataAdapter
            ds.Clear()
            If Not dta Is Nothing Then dta.Dispose()
            dta = New SqlDataAdapter(StrSql, DataSource)
            dta.Fill(ds)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = ds
            CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ShowChk", "Show_Chk")
        End Try
    End Sub

    Private Sub Show_CountChk()
        Try
            Dim ds_List As New DataTable
            Dim dta_List As New SqlDataAdapter
            ds_List.Clear()
            If Not dta_List Is Nothing Then dta_List.Dispose()
            dta_List = New SqlDataAdapter(SumStrSql, DataSource)
            dta_List.Fill(ds_List)
            If Not ds_List.Columns.Contains("Day") Then ds_List.Columns.Add("Day", Type.GetType("System.String"))
            For i As Integer = 0 To ds_List.Rows.Count - 1
                Dim DayStr As New NumberToString
                ds_List.Rows(i).Item("Day") = DayStr.PersianWeekDays(DayStr.PersianToDateConvertor(ds_List.Rows(i).Item("PayDate")))
            Next
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = ds_List
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ShowChk", "Show_CountChk")
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "State_Mali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnEditPay.Enabled = True Then Call BtnEditPay_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnEditPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditPay.Click
        Try
            If BtnEditPay.Text.Trim = "محاسبه مبلغ بر اساس تاریخ سررسید" Then
                If DGV1.RowCount <= 0 Then
                    MessageBox.Show("چکی جهت محاسبه وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Me.Enabled = False
                BtnEditPay.Text = "نمایش لیست چک به صورت کامل"
                ToolDisc.Text = "F2 نمایش لیست چک به صورت کامل"
                Me.Show_CountChk()
                DGV2.Visible = True
                DGV1.Visible = False
                Me.Enabled = True
            ElseIf BtnEditPay.Text.Trim = "نمایش لیست چک به صورت کامل" Then
                Me.Enabled = False
                BtnEditPay.Text = "محاسبه مبلغ بر اساس تاریخ سررسید"
                ToolDisc.Text = "F2 محاسبه مبلغ بر اساس تاریخ سررسید"
                Me.Show_Chk()
                DGV1.Visible = True
                DGV2.Visible = False
                Me.Enabled = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ShowChk", "BtnEditPay_Click")
            Me.Close()
        End Try
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

        Try
            If DGV2.Item("Cln_Date", e.RowIndex).Value = GetDate() Then
                DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DGV2.Item("Cln_Date", e.RowIndex).Value > GetDate() Then
                DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV2.Item("Cln_Date", e.RowIndex).Value < GetDate() Then
                DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV1.RowPrePaint
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
            If DGV1.Item("Cln_PayDate", e.RowIndex).Value = GetDate() Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value > GetDate() Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value < GetDate() Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV2_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV2.RowPrePaint
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

        Try
            If DGV2.Item("Cln_Date", e.RowIndex).Value = GetDate() Then
                DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DGV2.Item("Cln_Date", e.RowIndex).Value > GetDate() Then
                DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV2.Item("Cln_Date", e.RowIndex).Value < GetDate() Then
                DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class