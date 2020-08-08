Imports System.Data.SqlClient

Public Class FrmListShowKala
    Public Fill As String
    Public Sql_Str As String

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmListShowKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub GetData()
        Try
            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using Cmd As New SqlCommand(Sql_Str, ConectionBank)
                dt.Load(Cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListShowKala", "GetData")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmListShowKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        GetData()
        DGV.Columns(Fill).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class