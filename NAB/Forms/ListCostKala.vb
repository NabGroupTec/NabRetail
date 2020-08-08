Imports System.Data.SqlClient
Imports System.Transactions
Public Class ListCostKala
    Dim ROW As Integer
    Dim ds As New DataSet
    Dim str As String = "SELECT Define_CityCostkala.IdCity, Define_City.NamCI, Define_Ostan.NamO,Define_Ostan.Code FROM Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_CityCostkala ON Define_City.Code = Define_CityCostkala.IdCity ORDER BY Define_Ostan.NamO,Define_City.NamCI"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_KDgv(CLng(DGV.Item("Cln_IdCity", e.RowIndex).Value))
        Catch ex As Exception
            DGV2.DataSource = Nothing
        End Try
    End Sub
    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
    
    Private Sub Fill_Dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_CityCostKala")
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_CityCostKala"
            DGV.DataSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListCostKala", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_KDgv(ByVal IdCity As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT Define_CostKala.Id, Define_CostKala.IdKala, Define_CostKala.IdCity, Define_CostKala.CostSmalKala, Define_CostKala.CostBigKala,Define_CostKala.EndCost, Define_Kala.Nam,Define_OneGroup .NamOne ,Define_TwoGroup .NamTwo  FROM Define_CostKala INNER JOIN Define_Kala ON Define_CostKala.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala .IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala .IdCodeTwo  WHERE Define_CostKala.IdCity=" & IdCity & " ORDER BY Nam"
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "Define_CostKala")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "Define_CostKala"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListCostKala", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub DefineCostKala_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
    End Sub

    Private Sub DefineCostKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DefineCostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Array.Resize(AllSelectKala, 0)
        Me.Fill_Dgv()
        DGV.Columns("Cln_City").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_Namkala").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    
    Private Sub RefreshBank()
        Try
            DGV2.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "Define_CityCostKala")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListCostKala", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.RefreshBank()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.RefreshBank()
    End Sub

    Private Sub DGV2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV2.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSelect.Enabled = True Then Call BtnSelect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub BtnDelKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub cmdadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub cmddel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub cmdedit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub


    Private Sub BtnEditCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnSelect.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Array.Resize(AllSelectKala, 0)
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای انتخاب وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For i As Integer = 0 To DGV2.RowCount - 1
            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV2.Item("Cln_Idkala", i).Value
            AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV2.Item("Cln_OneGroup", i).Value
            AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV2.Item("Cln_TwoGroup", i).Value
            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV2.Item("Cln_Namkala", i).Value
            AllSelectKala(AllSelectKala.Length - 1).CostSkala = CDbl(DGV2.Item("Cln_SCost", i).Value)
            AllSelectKala(AllSelectKala.Length - 1).CostBkala = CDbl(DGV2.Item("Cln_BCost", i).Value)
            AllSelectKala(AllSelectKala.Length - 1).EndCost = CDbl(DGV2.Item("Cln_EndCost", i).Value)
        Next
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Array.Resize(AllSelectKala, 0)
        Me.Close()
    End Sub

    Private Sub BtnCancel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCancel.KeyDown
        Me.GetKey(e)
    End Sub
End Class