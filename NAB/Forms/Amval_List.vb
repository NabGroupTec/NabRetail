Imports System.Data.SqlClient
Public Class Amval_List
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()
    Public Condition As String

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)

    End Sub
    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
    Private Sub GetAmval()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("SELECT  Define_Amval .nam, Define_Amval .ID, Define_Amval .IdCodeTwo, Define_Amval .IdOne, Define_OneAmval .NamOne FROM  Define_Amval  INNER JOIN  Define_OneAmval  ON Define_Amval .IdOne = Define_OneAmval .Id", DataSource)
            Dta.Fill(Ds, "Define_Amval")
            CmbOstan.Items.Clear()
            For i As Integer = 0 To Ds.Tables("Define_Amval").Rows.Count - 1
                If CmbOstan.FindStringExact(Ds.Tables("Define_Amval").Rows(i).Item("NamOne")) = -1 Then
                    CmbOstan.Items.Add(Ds.Tables("Define_Amval").Rows(i).Item("NamOne"))
                End If
            Next
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Amval").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Amval_List", "GetAmval")
            Me.Close()
        End Try
    End Sub

    Private Sub RefreshBank()
        Try
            Ds.Clear()
            Dta.Fill(Ds, "Define_Amval")
            CmbOstan.Items.Clear()
            CmbOstan.Text = ""
            TxtSearch.Text = ""
            For i As Integer = 0 To Ds.Tables("Define_Amval").Rows.Count - 1
                If CmbOstan.FindStringExact(Ds.Tables("Define_Amval").Rows(i).Item("NamOne")) = -1 Then
                    CmbOstan.Items.Add(Ds.Tables("Define_Amval").Rows(i).Item("NamOne"))
                End If
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Amval_List", "RefreshBank")
        End Try
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Down And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = DGV.Rows.Count - 1 Then
                DGV.Item(0, 0).Selected = True
                e.Handled = True
            Else
                DGV.Item(0, DGV.CurrentRow.Index + 1).Selected = True
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Up And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = 0 Then
                DGV.Item(0, DGV.Rows.Count - 1).Selected = True
                e.Handled = True
            Else
                DGV.Item(0, DGV.CurrentRow.Index - 1).Selected = True
                e.Handled = True
            End If
        End If
        Me.GetKey(e)
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamOne Like '" & CmbOstan.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "IdCodeTwo Like '" & TxtCode.Text.Trim & "%'"
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamOne Like '%" & CmbOstan.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "IdCodeTwo Like '%" & TxtCode.Text.Trim & "%'"
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamOne Like '" & CmbOstan.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND IdCodeTwo Like '" & TxtCode.Text.Trim & "%'"
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamOne Like '%" & CmbOstan.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND IdCodeTwo Like '%" & CmbOstan.Text.Trim & "%'"
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
        If DGV.RowCount > 1 And TxtSearch.Text <> "" Then
            Dim txtdgv, txtk As String
            For i As Integer = 0 To DGV.RowCount - 1
                txtdgv = DGV.Item(0, i).Value.ToString
                txtk = TxtSearch.Text
                If txtdgv.Contains(TxtSearch.Text.Trim) And txtdgv(0).ToString = txtk(0).ToString Then
                    DGV.Item(0, i).Selected = True
                    Exit Sub
                End If
            Next
            DGV.Item(0, 0).Selected = True
            DGV.Item(0, 0).Selected = False
        End If
    End Sub

    Private Sub Kala_List_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtSearch.Focus()
        SendKeys.Send("{End}")
        Dim ss As String = TxtSearch.Text.Trim
        TxtSearch.Text = ""
        TxtSearch.Text = ss
    End Sub

    Private Sub Kala_List_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Kala_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetAmval()
        IdKala = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        TmpAddress = ""
        TmpTell1 = ""
        TmpTell2 = ""
        If ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Dim tmp As String = TxtSearch.Text

        Dim def As String = GetDefault("ALL")
        Try
            Select Case def
                Case "0" : RdoAval.Checked = True
                Case "1" : RdoAll.Checked = True
            End Select
            TxtSearch.Text = tmp
            SendKeys.Send("{END}")
        Catch ex As Exception
            RdoAval.Checked = True
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If ChkAll.Visible = False Then
            If e.KeyCode = Keys.Escape Then
                IdKala = 0
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                TmpAddress = ""
                TmpTell1 = ""
                TmpTell2 = ""
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        IdKala = CLng(DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value.ToString)
                        Tmp_Namkala = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString
                        Tmp_OneGroup = DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString
                        Tmp_TwoGroup = If(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString Is DBNull.Value, "", DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString)
                        Me.Close()
                    End If
                Catch ex As Exception
                    IdKala = 0
                    Tmp_Namkala = ""
                    Tmp_OneGroup = ""
                    Tmp_TwoGroup = ""
                    TmpAddress = ""
                    TmpTell1 = ""
                    TmpTell2 = ""
                    Me.Close()
                End Try
            End If
        ElseIf ChkAll.Visible = True Then
            If e.KeyCode = Keys.Escape Then
                Array.Resize(AllSelectKala, 0)
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        Array.Resize(AllSelectKala, 0)
                        For i As Integer = 0 To DGV.RowCount - 1
                            If DGV.Item("Cln_Select", i).Value = True Then
                                Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                                AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).OneGroup = ""
                                AllSelectKala(AllSelectKala.Length - 1).TwoGroup = ""
                                AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).CostSkala = 0
                                AllSelectKala(AllSelectKala.Length - 1).CostBkala = 0
                            End If
                        Next
                    End If
                    Me.Close()
                Catch ex As Exception
                    Array.Resize(AllSelectKala, 0)
                    Me.Close()
                End Try
            End If
        End If
        If e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnNewP.Enabled = True Then Call BtnNewP_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnExit.Enabled = True Then Call BtnExit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BtnExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnExit.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAll.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAval.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If ChkAll.Visible = False Then
                If DGV.RowCount > 0 Then
                    IdKala = CLng(DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_Namkala = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString
                    Tmp_OneGroup = If(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString Is DBNull.Value, "", DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_TwoGroup = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value.ToString
                End If
            ElseIf ChkAll.Visible = True Then

                If DGV.RowCount > 0 Then
                    Array.Resize(AllSelectKala, 0)
                    For i As Integer = 0 To DGV.RowCount - 1
                        If DGV.Item("Cln_Select", i).Value = True Then
                            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).OneGroup = ""
                            AllSelectKala(AllSelectKala.Length - 1).TwoGroup = ""
                            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).CostSkala = 0
                            AllSelectKala(AllSelectKala.Length - 1).CostBkala = 0
                        End If
                    Next
                    Me.Close()
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpAddress = ""
            TmpTell1 = ""
            TmpTell2 = ""
            Array.Resize(AllSelectKala, 0)
            Me.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        If ChkAll.Visible = False Then
            IdKala = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpAddress = ""
            TmpTell1 = ""
            TmpTell2 = ""
        ElseIf ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        Me.Close()
    End Sub

    Private Sub RdoOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOne.CheckedChanged
        If RdoOne.Checked = True Then
            CmbOstan.Enabled = True
            CmbOstan.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "NamOne Like '" & CmbOstan.Text.Trim & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "NamOne Like '%" & CmbOstan.Text.Trim & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOstan.Text = ""
            TxtCode.Text = ""
            CmbOstan.Enabled = False
        End If
    End Sub

    Private Sub RdoAllKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAllKala.CheckedChanged
        If RdoAllKala.Checked = True Then
            CmbOstan.Enabled = False
            TxtCode.Enabled = False
            TxtSearch.Focus()
            Try
                TxtSearch.Text = ""
                dv.RowFilter = ""
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub

    Private Sub RdoAval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAval.CheckedChanged
        TxtSearch.Focus()
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        TxtSearch.Focus()
    End Sub

    Private Sub CmbOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstan.KeyDown
        If CmbOstan.DroppedDown = False Then
            CmbOstan.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtCode.Focus()
            Exit Sub
        End If
        Me.GetKey(e)
    End Sub

    Private Sub RdoAllKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAllKala.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoOne.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoTwo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub


    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If ChkAll.Checked = True Then
            For i As Integer = 0 To DGV.RowCount - 1
                DGV.Item("Cln_Select", i).Value = True
            Next
        ElseIf ChkAll.Checked = False Then
            For i As Integer = 0 To DGV.RowCount - 1
                DGV.Item("Cln_Select", i).Value = False
            Next
        End If
    End Sub

    Private Sub ChkAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkAll.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnNewP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewP.Click
        Try
            Fnew = True
            Using FrmPeople As New DefineAmval
                FrmPeople.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Amval_List", "BtnNewP_Click")
        End Try
    End Sub

    Private Sub BtnNewP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnNewP.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCode.CheckedChanged
        If RdoCode.Checked = True Then
            TxtCode.Enabled = True
            TxtCode.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "IdCodeTwo Like '" & TxtCode.Text & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "IdCodeTwo Like '%" & TxtCode.Text & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOstan.Text = ""
            TxtCode.Text = ""
            TxtCode.Enabled = False
        End If
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOstan.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOstan.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbOstan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstan.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOstan.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOstan.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub TxtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "IdCodeTwo Like '" & TxtCode.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "IdCodeTwo Like '%" & TxtCode.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub
End Class