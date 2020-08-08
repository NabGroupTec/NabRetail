Imports System.Data.SqlClient
Public Class FrmDaftarKolManual
    Public Sql As String

    Private Sub FrmDaftarKolManual_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub FrmDaftarKolManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetDaftarKol()
        Try : DGV.Columns("Cln_Ad").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : Catch ex As Exception : End Try
    End Sub

    Private Sub GetDaftarKol()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable
            Using cmd As New SqlCommand(Sql, ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt

            Dim bed As Double = 0
            Dim bes As Double = 0
            For i As Integer = 0 To DGV.RowCount - 1
                bed += CDbl(DGV.Item("Cln_Bed", i).Value)
                bes += CDbl(DGV.Item("Cln_Bes", i).Value)
            Next
            TxtBed.Text = FormatNumber(bed, 0)
            TxtBes.Text = FormatNumber(bes, 0)

            Dim Res As Double = bed - bes
            If Res = 0 Then
                TxtT.Text = "بد"
                TxtMandeh.Text = 0
            ElseIf Res > 0 Then
                TxtT.Text = "بد"
                TxtMandeh.Text = FormatNumber(Res, 0)
            ElseIf Res < 0 Then
                TxtT.Text = "بس"
                TxtMandeh.Text = FormatNumber(Res * (-1), 0)
            End If

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKolManual", "GetDaftarKol")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnMoein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoein.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("طرف حسابی برای نمایش معین وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Using moeinPeople As New Moein_People
            Me.Enabled = False
            moeinPeople.TxtName.Text = DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value
            moeinPeople.TxtIdName.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
            moeinPeople.TxtMobile.Text = DGV.Item("Cln_Mobile", DGV.CurrentRow.Index).Value
            moeinPeople.TxtTell.Text = DGV.Item("Cln_Tell", DGV.CurrentRow.Index).Value
            moeinPeople.TxtAddress.Text = DGV.Item("Cln_Ad", DGV.CurrentRow.Index).Value
            moeinPeople.ShowDialog()
            Me.Enabled = True
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_MoeinKol.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnMoein.Enabled = True Then BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetDaftarKol()
        End If
    End Sub

    Private Sub DGV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        If BtnMoein.Enabled = True Then BtnMoein_Click(Nothing, Nothing)
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Id", i).Value = IdKala Then
                        DGV.Item("Cln_Name", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item("Cln_Name", 0).Selected = True
                DGV.Item("Cln_Name", 0).Selected = False
            End If
        End If
    End Sub
End Class