Imports System.Data.SqlClient
Public Class FrmMojodyBox

    Private Sub FrmMojodyBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmMojodyBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F80")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی صندوق", "ورود", "", "")
                End If
                If Access_Form.Substring(3, 1) = 0 Then
                    BtnReport.Enabled = False
                End If
            End If
        Else
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی صندوق", "ورود", "", "")
        End If
        Me.Show_AllBox()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub Show_AllBox()
        Try
            Dim ds_List As New DataTable
            Dim dta_List As New SqlDataAdapter
            ds_List.Clear()
            If Not dta_List Is Nothing Then dta_List.Dispose()
            dta_List = New SqlDataAdapter("SELECT id,Nam,mandeh=Case WHEN (MoeinBox +AllMoney)<0 THEN (MoeinBox +AllMoney) * -1 ELSE (MoeinBox +AllMoney) END  ,T=Case WHEN  MoeinBox + AllMoney >=0 THEN N'بد' ELSE N'بس' END  FROM (SELECT ID,nam,(SELECT (SUM(bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =Define_Box.ID AND T=1) As Bes ) AS MoeinBox , ISNULL(Allmoney,0) AS AllMoney FROM Define_Box) As AllMoeinBox ORDER By mandeh", DataSource)
            dta_List.Fill(ds_List)
            DGV.AutoGenerateColumns = False
            DGV.DataSource = ds_List
            CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMojodyBox", "Show_AllBox")
        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        Try
            If DGV.Item("Cln_T", e.RowIndex).Value = "بد" Then
                DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV.Item("Cln_T", e.RowIndex).Value = "بس" Then
                DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_mojodiBox.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.Show_AllBox()
        End If
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Me.Show_AllBox()
        If DGV.RowCount <= 0 Then
            MessageBox.Show("گزارشی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی صندوق", "تهیه گزارش", "", "")

        Using FPrint As New FrmPrint
            Me.Enabled = False
            FPrint.PrintSQl = "SELECT Nam,mandeh=Case WHEN (MoeinBox +AllMoney)<0 THEN (MoeinBox +AllMoney) * -1 ELSE (MoeinBox +AllMoney) END  ,T=Case WHEN  MoeinBox + AllMoney >=0 THEN N'بد' ELSE N'بس' END  FROM (SELECT ID,nam,(SELECT (SUM(bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =Define_Box.ID AND T=1) As Bes ) AS MoeinBox , ISNULL(Allmoney,0) AS AllMoney FROM Define_Box) As AllMoeinBox ORDER By mandeh"
            FPrint.CHoose = "MOJODYBOX"
            FPrint.Str1 = If(CDbl(TxtMonBox.Text) >= 0, CDbl(TxtMonBox.Text), CDbl(TxtMonBox.Text) * -1)
            FPrint.State = If(CDbl(TxtMonBox.Text) >= 0, "بد", "بس")
            FPrint.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("صندوقی برای نمایش معین وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Show_AllBox()
            Exit Sub
        End If
        Using moeinBox As New Moein_BOX
            Me.Enabled = False
            moeinBox.TxtName.Text = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value
            moeinBox.TxtIdName.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
            moeinBox.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub
    Private Sub CalculateMon()
        Try
            TxtMonBox.Text = 0
            For i As Integer = 0 To DGV.RowCount - 1
                TxtMonBox.Text = CDbl(TxtMonBox.Text) + If(DGV.Item("Cln_T", i).Value = "بد", CDbl(DGV.Item("Cln_MonBax", i).Value), CDbl(DGV.Item("Cln_MonBax", i).Value) * -1)
            Next
            If TxtMonBox.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonBox.Text.Replace(",", ""))
                TxtMonBox.Text = Format$(Val(Str), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMonBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonBox.TextChanged
        If CDbl(TxtMonBox.Text.Trim) = 0 Then
            TxtMonBox.BackColor = Color.Yellow
        ElseIf CDbl(TxtMonBox.Text.Trim) > 0 Then
            TxtMonBox.BackColor = Color.White
        ElseIf CDbl(TxtMonBox.Text.Trim) < 0 Then
            TxtMonBox.BackColor = Color.Pink
        End If
    End Sub
End Class