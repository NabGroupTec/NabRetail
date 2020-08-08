Imports System.Data.SqlClient
Public Class FrmEditBox

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        Try

            If CDbl(DGV.Item("Cln_NewMandeh", e.RowIndex).Value) < 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_NewMandeh").Style.BackColor = Color.Pink
            ElseIf CDbl(DGV.Item("Cln_NewMandeh", e.RowIndex).Value) = 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_NewMandeh").Style.BackColor = Color.Yellow
            ElseIf CDbl(DGV.Item("Cln_NewMandeh", e.RowIndex).Value) > 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_NewMandeh").Style.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMonEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonEdit.TextChanged
        If CDbl(TxtMonEdit.Text.Trim) = 0 Then
            TxtMonEdit.BackColor = Color.Yellow
        ElseIf CDbl(TxtMonEdit.Text.Trim) > 0 Then
            TxtMonEdit.BackColor = Color.White
        ElseIf CDbl(TxtMonEdit.Text.Trim) < 0 Then
            TxtMonEdit.BackColor = Color.Pink
        End If
    End Sub

    Private Sub CalculateMon()
        Try
            TxtMonEdit.Text = 0
            For i As Integer = 0 To DGV.RowCount - 1
                TxtMonEdit.Text = CDbl(TxtMonEdit.Text) + CDbl(DGV.Item("Cln_NewMandeh", i).Value)
            Next
            If TxtMonEdit.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonEdit.Text.Replace(",", ""))
                TxtMonEdit.Text = Format$(Val(Str), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "CloseMali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmEditBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmEditBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        FillData()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub FillData()
        Try
            DGV.Rows.Clear()
            For i As Integer = 0 To Tmp_DtBox.Rows.Count - 1
                DGV.Rows.Add()
                DGV.Item("Cln_Id", DGV.RowCount - 1).Value = Tmp_DtBox.Rows(i).Item("Id")
                DGV.Item("Cln_Nam", DGV.RowCount - 1).Value = Tmp_DtBox.Rows(i).Item("Nam")
                DGV.Item("Cln_NewMandeh", DGV.RowCount - 1).Value = IIf(Tmp_DtBox.Rows(i).Item("NewMandeh") <> 0, FormatNumber(Tmp_DtBox.Rows(i).Item("NewMandeh"), 0), 0)
            Next
            CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditBox", "FillData")
            Me.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If DGV.Rows.Count <= 0 Then
                MessageBox.Show("صندوقی برای اصلاحیه وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(8)
                FrmDay.CmbSanad.Enabled = False
                FrmDay.GroupBox4.Enabled = False
                FrmDay.GroupBox5.Enabled = False
                FrmDay.ShowDialog()
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT id,Nam,discription,(MoeinBox +AllMoney) AS NewMandeh FROM (SELECT ID,discription,nam,(SELECT (SUM(bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =Define_Box.ID  AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =Define_Box.ID AND T=1) As Bes ) AS MoeinBox , ISNULL(Allmoney,0) AS AllMoney FROM Define_Box) As AllMoeinBox ORDER By NewMandeh", ConectionBank)

                Tmp_DtBox.Clear()
                Tmp_DtBox.Columns.Clear()

                Tmp_DtBox.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''
            FillData()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditBox", "Button2_Click")
            Me.Close()
        End Try
    End Sub
End Class