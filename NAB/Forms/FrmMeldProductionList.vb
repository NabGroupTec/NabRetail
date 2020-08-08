Imports System.Data.SqlClient

Public Class FrmMeldProductionList
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim DsF As New DataSet
    Dim Dta As New SqlDataAdapter()
    Dim StrQuery As String
    Private Sub FrmMeldProductionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillGrid()
        LoadFormula()
    End Sub
    Private Sub LoadFormula()
        CmbFormula.Items.Clear()
        Try
            DsF.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("select id, FormulName from FormulaMaster", DataSource)
            Dta.Fill(DsF, "MeldProduction")
            Dim dt As New DataTable
            dt = Ds.Tables("FormulaMaster")
            CmbFormula.DataSource = dt
            CmbFormula.DisplayMember = "FormulName"
            CmbFormula.ValueMember = "id"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, Me.Name, "FillGrid")
            Me.Close()
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("select mp.Id,mp.FormulId,mp.CountTavlid,mp.IdUser,nam,mp.D_Date,fm.FormulName from MeldProduction mp inner join FormulaMaster fm on fm.Id=mp.FormulId inner join Define_User du on mp.iduser=du.id", DataSource)
            Dta.Fill(Ds, "MeldProduction")
            dgvFormulas.AutoGenerateColumns = False
            dv = Ds.Tables("MeldProduction").DefaultView
            dgvFormulas.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, Me.Name, "FillGrid")
            Me.Close()
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim Fp As New FrmProductionFormulas
        Fp.ShowDialog()
        '  FillGrid()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If (dgvFormulas.Rows.Count > 0) Then
            Dim Fp As New FrmMeldProduction

            Dim State As Integer = GetAreEditOrDelete(CInt(dgvFormulas.Item("Cln_Id", dgvFormulas.CurrentRow.Index).Value.ToString()))
            If (State > 0) Then
                MessageBox.Show("امکان ویرایش وجود ندارد")
                Exit Sub
            End If
            Fp.ShowDialog()
        End If
        ' FillGrid()
    End Sub

    Private Sub btnMeldProduct_Click(sender As Object, e As EventArgs) Handles btnMeldProduct.Click
        If dgvFormulas.Rows.Count > 0 Then
            Dim Fmp As New FrmMeldProduction

            Fmp.ShowDialog()
        End If
        FillGrid()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If (dgvFormulas.Rows.Count > 0) Then
            Dim State As Integer = GetAreEditOrDelete(CInt(dgvFormulas.Item("Cln_Id", dgvFormulas.CurrentRow.Index).Value.ToString()))
            If (State > 0) Then
                MessageBox.Show("امکان حذف وجود ندارد")
                Exit Sub
            End If
            Dim dr As New DialogResult
            dr = MessageBox.Show("آیا مایل به حذف این فرمول می باشید", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (dr = Windows.Forms.DialogResult.Yes) Then
                Dim CmdDelete As New SqlCommand("delete from MeldProduction where MeldProduction.Id=" & dgvFormulas.Item("Cln_Id", dgvFormulas.CurrentRow.Index).Value.ToString() & "", ConectionBank)
                If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
                CmdDelete.ExecuteNonQuery()
                If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()
            End If
        End If
        FillGrid()

    End Sub

    Private Sub txtSearche_TextChanged(sender As Object, e As EventArgs) Handles txtSearche.TextChanged
        Try
            If (String.IsNullOrEmpty(txtSearche.Text)) Then
                dv.RowFilter = ""
                Exit Sub
            End If
            If rdoFilterCodeFormul.Checked = True Then
                StrQuery = " CodeFormul =" & txtSearche.Text & ""
            ElseIf rdoFilterFormulName.Checked = True Then
                StrQuery = " FormulName Like '%" & txtSearche.Text & "%'"
            ElseIf rdoFormulDate.Checked = True Then
                StrQuery = " D_Date Like '%" & txtSearche.Text & "%'"
            Else
                StrQuery = ""
            End If
            dv.RowFilter = StrQuery
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, Me.Name, "txtSearche_TextChanged")
            Me.Close()
        End Try
    End Sub

End Class