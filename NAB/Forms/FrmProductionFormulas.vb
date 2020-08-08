Imports System.Data.SqlClient

Public Class FrmProductionFormulas
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl
    Public FCode As Integer
    Private Sub FrmProductionFormulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (FCode <> 0) Then
            GetInfo()
            txtDateStart.Text = GetDate()
        Else
            txtDateStart.Text = GetDate()
        End If
    End Sub
    Private Sub LoadMatherial()
        Dim DtMat As New DataTable
        Dim SqlCmd As New SqlCommand("SELECT dk.Id,dk.Nam,dv.Nam as  UnitName,dv.id as IdUnit FROM Define_Kala dk inner join Define_Vahed dv on dk.IdVahed=dv.Id ", ConectionBank)
        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
        DtMat.Load(SqlCmd.ExecuteReader())
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        ' DGVMaterials.DataSource = DtMat
    End Sub
    Private Sub DGVMaterials_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        'DGVFormulas.Rows.Add()
        'DGVFormulas.Item("Cln_IdKala", DGVFormulas.Rows.Count - 1).Value = DGVMaterials.CurrentRow.Cells("Cln_Id").Value.ToString()
        'DGVFormulas.Item("Cln_Sharh", DGVFormulas.Rows.Count - 1).Value = DGVMaterials.CurrentRow.Cells("Cln_MatName").Value.ToString()
        'DGVFormulas.Item("Cln_Unit", DGVFormulas.Rows.Count - 1).Value = DGVMaterials.CurrentRow.Cells("Cln_UnitName").Value.ToString()

    End Sub

    Private Sub DGVFormulas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGVFormulas.CellEndEdit
        Try
          
            If e.ColumnIndex = 2 Then
                If Not (DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then

                    SendKeys.Send("{TAB}")
                End If
            End If
            If e.ColumnIndex = 3 Then
                If Not (DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then

                    SendKeys.Send("{TAB}")
                End If
            End If
            If e.ColumnIndex = 4 Then
                If Not (DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then

                    SendKeys.Send("{TAB}")
                End If
          
            End If
            If e.ColumnIndex = 5 Then
                If Not (DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGVFormulas.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then

                    SendKeys.Send("+{TAB}")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CalcValue()
        Dim Masraf As Double = 0
        Dim Tavlid As Double = 0
        If (DGVFormulas.Rows.Count > 1) Then
            For index = 0 To DGVFormulas.Rows.Count - 1
                Masraf += CDbl(If(DGVFormulas.Rows(index).Cells(2).Value = Nothing, "0", DGVFormulas.Rows(index).Cells(2).Value.ToString()))
                Tavlid += CDbl(If(DGVFormulas.Rows(index).Cells(3).Value = Nothing, "0", DGVFormulas.Rows(index).Cells(3).Value.ToString()))
            Next
        End If
        txtCountTavazon.Text = Masraf.ToString()
        txtCountTavlid.Text = Tavlid.ToString()
    End Sub
    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGVFormulas.CurrentCell.ColumnIndex = 1 Then
            e.Handled = True
            Dim frmlk As New Kala_Anbar_List_M
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.ShowDialog()
            DGVFormulas.Focus()
            If Tmp_Namkala <> "" Then
                DGVFormulas.Item("Cln_Sharh", DGVFormulas.CurrentRow.Index).Value = Tmp_Namkala
                DGVFormulas.Item("Cln_IdKala", DGVFormulas.CurrentRow.Index).Value = IdKala
                DGVFormulas.Item("Cln_Unit", DGVFormulas.CurrentRow.Index).Value = TmpVahed
            End If
            DGVFormulas.RefreshEdit()
            CalcValue()
        End If
        If DGVFormulas.CurrentCell.ColumnIndex = 3 Then
            If Not String.IsNullOrEmpty(DGVFormulas.Item("Cln_Masraf", DGVFormulas.CurrentRow.Index).Value) Then
                Exit Sub
            Else
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
            End If
            CalcValue()
        End If
        If DGVFormulas.CurrentCell.ColumnIndex = 2 Then
            If Not String.IsNullOrEmpty(DGVFormulas.Item("Cln_Tavlid", DGVFormulas.CurrentRow.Index).Value) Then
                txt_dgv.Text = ""
                Exit Sub
            Else
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
            End If
            CalcValue()
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged

        If DGVFormulas.CurrentCell.ColumnIndex = 2 Then
            If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
            'If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
        End If
    End Sub
    Private Sub DGVFormulas_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVFormulas.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Keys.Delete
                e.Handled = True
                If (DGVFormulas.Rows.Count > 1) Then DGVFormulas.Rows.RemoveAt(DGVFormulas.CurrentRow.Index)
        End Select

    End Sub

    Private Sub DGVFormulas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGVFormulas.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub Save()
        Dim FId As Long
        If (DGVFormulas.Rows.Count > 0) Then
            Dim cmd As New SqlCommand("insert into FormulaMaster values (" & txtFormulNo.Text & ",'" & txtFormulName.Text & "'," & Id_User & ",'" & GetDate() & "');SELECT @@IDENTITY", ConectionBank)
            If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
            FId = cmd.ExecuteScalar()

            If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()
            For index = 0 To DGVFormulas.Rows.Count - 2
                Dim CmdDetails As New SqlCommand("insert into FormulaDetails values (" & FId & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_IdKala").Value = Nothing, "1", DGVFormulas.Rows(index).Cells("Cln_IdKala").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_IdVahed").Value = Nothing, "1", DGVFormulas.Rows(index).Cells("Cln_IdVahed").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_Masraf").Value = Nothing, "0", DGVFormulas.Rows(index).Cells("Cln_Masraf").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_Tavlid").Value = Nothing, "0", DGVFormulas.Rows(index).Cells("Cln_Tavlid").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_Stock").Value = Nothing, "1", DGVFormulas.Rows(index).Cells("Cln_Stock").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_EndPrice").Value = Nothing, "0", DGVFormulas.Rows(index).Cells("Cln_EndPrice").Value.ToString()) & ")", ConectionBank)
                If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
                CmdDetails.ExecuteNonQuery()
                If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()

            Next



        End If
    End Sub
    Private Sub Edit()
        If (DGVFormulas.Rows.Count > 0) Then
            Dim cmd As New SqlCommand("UPDATE  FormulaMaster SET  CodeFormul=" & txtFormulNo.Text & ",FormulName=N'" & txtFormulName.Text & "',IdUser=" & Id_User & ",D_Date=N'" & GetDate() & "'", ConectionBank)
            If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
            cmd.ExecuteNonQuery()
            If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()


            Dim CmdDelDetails As New SqlCommand("DELETE FROM FormulaDetails WHERE IdFormula=" & FCode & "", ConectionBank)
            If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
            CmdDelDetails.ExecuteNonQuery()
            If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()

            For index = 0 To DGVFormulas.Rows.Count - 2
                Dim CmdDetails As New SqlCommand("insert into FormulaDetails values (" & FCode & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_IdKala").Value = Nothing, "1", DGVFormulas.Rows(index).Cells("Cln_IdKala").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_IdVahed").Value = Nothing, "1", DGVFormulas.Rows(index).Cells("Cln_IdVahed").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_Masraf").Value = Nothing, "0", DGVFormulas.Rows(index).Cells("Cln_Masraf").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_Tavlid").Value = Nothing, "0", DGVFormulas.Rows(index).Cells("Cln_Tavlid").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_Stock").Value = Nothing, "1", DGVFormulas.Rows(index).Cells("Cln_Stock").Value.ToString()) & "," _
                                                 & If(DGVFormulas.Rows(index).Cells("Cln_EndPrice").Value = Nothing, "0", DGVFormulas.Rows(index).Cells("Cln_EndPrice").Value.ToString()) & ")", ConectionBank)
                If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
                CmdDetails.ExecuteNonQuery()
                If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()

            Next



        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If (FCode <> 0) Then
            Edit()
        Else
            Save()
        End If
        Close()
    End Sub

    Private Sub GetInfo()

        Dim cmd As New SqlCommand("select fd.Id,fd.IdKala,fd.IdAnbar,fd.IdFormula,fd.IdVahed,fd.Masraf,fd.Tavlid,dk.Nam,dv.Nam as Unit,da.nam as Stock,fd.EndPrice from FormulaMaster fm inner join FormulaDetails fd on fm.Id=fd.IdFormula inner join Define_Kala dk on fd.IdKala=dk.Id inner join Define_Vahed dv on fd.IdVahed=dv.id inner join Define_Anbar da on fd.IdAnbar=da.id where fd.IdFormula=" & FCode & " ", ConectionBank)
        If (ConectionBank.State <> ConnectionState.Open) Then ConectionBank.Open()
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader())
        DGVFormulas.AllowUserToAddRows = False
        For Each dr As DataRow In dt.Rows
            DGVFormulas.Rows.Add()
            DGVFormulas.Item("Cln_IdKala", DGVFormulas.RowCount - 1).Value = dr("IdKala")
            DGVFormulas.Item("Cln_Sharh", DGVFormulas.RowCount - 1).Value = dr("Nam")
            DGVFormulas.Item("Cln_Masraf", DGVFormulas.RowCount - 1).Value = dr("Masraf")
            DGVFormulas.Item("Cln_Tavlid", DGVFormulas.RowCount - 1).Value = dr("Tavlid")
            DGVFormulas.Item("Cln_IdVahed", DGVFormulas.RowCount - 1).Value = dr("IdVahed")
            DGVFormulas.Item("Cln_Unit", DGVFormulas.RowCount - 1).Value = dr("Unit")
            DGVFormulas.Item("Cln_Stock", DGVFormulas.RowCount - 1).Value = "1" ' dr("Stock")
            DGVFormulas.Item("Cln_EndPrice", DGVFormulas.RowCount - 1).Value = dr("EndPrice")
        Next
        DGVFormulas.AllowUserToAddRows = True
        If (ConectionBank.State <> ConnectionState.Closed) Then ConectionBank.Close()
        CalcValue()
    End Sub

    Private Sub FrmProductionFormulas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        GetKey(e)
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Define_kala.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtDateStart_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDateStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFormulNo.Focus()
        End If
    End Sub

    Private Sub txtFormulNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFormulNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            DGVFormulas.Focus()
        End If
    End Sub
End Class