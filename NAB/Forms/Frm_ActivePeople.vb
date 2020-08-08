Imports System.Data.SqlClient

Public Class Frm_ActivePeople
    Public Id As Long
    Dim ds As New DataSet
    Dim dta As New SqlDataAdapter()

    Private Sub fill_dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            dta = New SqlDataAdapter("SELECT Define_ActivePeople.Id,Define_ActivePeople.IdVisitor,Define_ActivePeople.Dat,Define_ActivePeople.IdName,Define_ActivePeople.IdUser,Define_ActivePeople.IdUserEdit,Define_ActivePeople.Disc,Define_People.Nam ,StatActive=CASE WHEN Define_ActivePeople.StateActive ='True' THEN N'غیر فعال' ELSE N'فعال' END,Visitor=CASE WHEN Define_ActivePeople.IdVisitor IS NULL THEN N'' ELSE (SELECT Nam FROM Define_Visitor WHERE Define_Visitor.Id=Define_ActivePeople.IdVisitor) END FROM Define_ActivePeople INNER JOIN Define_People ON Define_ActivePeople.IdName = Define_People.ID WHERE Define_ActivePeople.IdName=" & Id, DataSource)
            dta.Fill(ds, "Define_ActivePeople")
            DGV.AutoGenerateColumns = False
            DGV.DataSource = ds.Tables("Define_ActivePeople")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_ActivePeopleAddEdit", "fill_dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Using Frm As New Frm_ActivePeopleAddEdit
            Frm.TxtIdName.Text = Id
            Frm.ShowDialog()
        End Using
        fill_dgv()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Using Frm As New Frm_ActivePeopleAddEdit
            Frm.LIdName.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
            Frm.ShowDialog()
        End Using
        fill_dgv()
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("هيچ وضعیتی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fill_dgv()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("آيا مي خواهيد وضعیت جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

                Using CMD As New SqlCommand("DELETE FROM Define_ActivePeople WHERE Id=" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, ConectionBank)
                    CMD.ExecuteNonQuery()
                End Using
                SetActivePeople(DGV.Item("Cln_IdName", DGV.CurrentRow.Index).Value)
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                fill_dgv()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("وضعیت انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_ActivePeopleAddEdit", "cmddel_Click")
                End If
                fill_dgv()
            End Try
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "E.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            fill_dgv()
        End If
    End Sub

    Private Sub Frm_ActivePeople_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub Frm_ActivePeople_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        fill_dgv()
        DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class