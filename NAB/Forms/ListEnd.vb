Imports System.Data.SqlClient

Public Class ListEnd

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Llist.Text = "P" Then
                Array.Resize(FactorArray, 0)
                For i As Integer = 0 To DGV.Rows.Count - 1
                    Array.Resize(FactorArray, FactorArray.Length + 1)
                    FactorArray(FactorArray.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
                    FactorArray(FactorArray.Length - 1).Disc = DGV.Item("Cln_Name", i).Value
                Next
            Else
                Array.Resize(SFactorArray, 0)
                For i As Integer = 0 To DGV.Rows.Count - 1
                    Array.Resize(SFactorArray, SFactorArray.Length + 1)
                    SFactorArray(SFactorArray.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
                    SFactorArray(SFactorArray.Length - 1).NamKala = DGV.Item("Cln_Name", i).Value
                Next
            End If
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListEnd", "BtnSave_Click")
        End Try
    End Sub
   
    Private Sub AddEdit_CostKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Keys.Delete
                e.Handled = True
                DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        End Select
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه لیست موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        DGV.Rows.Clear()
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "CloseMali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListEnd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Llist.Text = "P" Then
            For i As Integer = 0 To FactorArray.Length - 1
                DGV.Rows.Add()
                DGV.Item("Cln_Name", DGV.RowCount - 1).Value = FactorArray(i).Disc
                DGV.Item("Cln_IdP", DGV.RowCount - 1).Value = FactorArray(i).IdKala
            Next
        ElseIf Llist.Text = "K" Then
            For i As Integer = 0 To SFactorArray.Length - 1
                DGV.Rows.Add()
                DGV.Item("Cln_Name", DGV.RowCount - 1).Value = SFactorArray(i).NamKala
                DGV.Item("Cln_IdP", DGV.RowCount - 1).Value = SFactorArray(i).IdKala
            Next
        End If
        DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class

