Imports System.Data.SqlClient
Public Class FrmShowRate
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmShowRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
    Private Sub GetData()
        Try
            If String.IsNullOrEmpty(LSanad.Text) Or String.IsNullOrEmpty(LTable.Text) Then
                Me.Close()
            End If
            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT IdFactor,Pay FROM " & LTable.Text & " WHERE IdSanad=" & LSanad.Text, ConectionBank)
                dt.Load(Cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt
            CalculateMon()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowRate", "GetData")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmShowRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        GetData()
    End Sub
    Private Sub CalculateMon()
        TxtAllmoney.Text = "0"
        Dim mon As Double = 0
        For i As Integer = 0 To DGV.RowCount - 1
            mon += CDbl(DGV.Item("Cln_BCost", i).Value)
        Next
        TxtAllmoney.Text = FormatNumber(mon, 0)
    End Sub
End Class