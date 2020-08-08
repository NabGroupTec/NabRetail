Imports System.Data.SqlClient
Public Class GroupTwo_List
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
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
    Private Sub GetKala()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dim sqlstr As String = ""

            sqlstr = "SELECT Define_OneGroup.Id As IdOne, Define_OneGroup.NamOne,Define_OneGroup.IdCodeOne, Define_TwoGroup.Id AS IdTwo, Define_TwoGroup.NamTwo,Define_TwoGroup.IdCodeTwo FROM Define_OneGroup INNER JOIN Define_TwoGroup ON Define_OneGroup.Id = Define_TwoGroup.IdOne Order By NamOne ,NamTwo"

            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            CmbOne.Items.Clear()
            For i As Integer = 0 To Ds.Tables("Define_Kala").Rows.Count - 1
                If CmbOne.FindStringExact(Ds.Tables("Define_Kala").Rows(i).Item("NamOne")) = -1 Then
                    CmbOne.Items.Add(Ds.Tables("Define_Kala").Rows(i).Item("NamOne"))
                End If
            Next
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GroupTwo_List", "GetKala")
            Me.Close()
        End Try
    End Sub
   
    Private Sub RefreshBank()
        Try
            Me.GetKala()
            TxtSearch.Text = ""
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GroupTwo_List", "RefreshBank")
        End Try
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Down And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = DGV.Rows.Count - 1 Then
                DGV.Item(1, 0).Selected = True
                e.Handled = True
            Else
                DGV.Item(1, DGV.CurrentRow.Index + 1).Selected = True
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Up And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = 0 Then
                DGV.Item(1, DGV.Rows.Count - 1).Selected = True
                e.Handled = True
            Else
                DGV.Item(1, DGV.CurrentRow.Index - 1).Selected = True
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
                    ElseIf RdoCodeOne.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoCodeTwo.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%'"
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoCodeOne.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoCodeTwo.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%'"
                    End If
                End If
                DGV.Sort(DGV.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "NamTwo Like '" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoCodeOne.Checked = True Then
                        dv.RowFilter = "IdCodeOne ='" & TxtSearch.Text.Trim & "'"
                    ElseIf RdoCodeTwo.Checked = True Then
                        dv.RowFilter = "IdCodeTwo ='" & TxtSearch.Text.Trim & "'"
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamTwo Like '" & TxtSearch.Text.Trim & "%'  AND NamOne Like '" & CmbOne.Text.Trim & "%'"
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "NamTwo Like '%" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoCodeOne.Checked = True Then
                        dv.RowFilter = "IdCodeOne ='%" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoCodeTwo.Checked = True Then
                        dv.RowFilter = "IdCodeTwo ='%" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamTwo Like '%" & TxtSearch.Text.Trim & "%'  AND NamOne Like '%" & CmbOne.Text.Trim & "%'"
                    End If
                End If
                DGV.Sort(DGV.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
        If DGV.RowCount > 1 And TxtSearch.Text <> "" Then
            Dim txtdgv, txtk As String
            For i As Integer = 0 To DGV.RowCount - 1
                txtdgv = DGV.Item(1, i).Value.ToString
                txtk = TxtSearch.Text
                If txtdgv.Contains(TxtSearch.Text.Trim) And txtdgv(0).ToString = txtk(0).ToString Then
                    DGV.Item(1, i).Selected = True
                    Exit Sub
                End If
            Next
            DGV.Item(1, 0).Selected = True
            DGV.Item(1, 0).Selected = False
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
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetKala()
        IdKala = 0
        DK = False
        DK_JOZ = 0
        DK_KOL = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        TmpVahed = ""
        If ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        DGV.Columns("Cln_TwoGroup").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Dim tmp As String = TxtSearch.Text
        Dim def As String = GetDefault("KALA")
        Try
            Select Case def.Substring(0, 1)
                Case "0" : RdoAllKala.Checked = True
                Case "1" : RdoCodeOne.Checked = True
                Case "2" : RdoCodeTwo.Checked = True
                Case "3" : RdoOne.Checked = True
                Case "4" : RdoOne.Checked = True
                Case "5" : RdoAllKala.Checked = True
            End Select
            Select Case def.Substring(1, 1)
                Case "0" : RdoAval.Checked = True
                Case "1" : RdoAll.Checked = True
            End Select
            TxtSearch.Text = tmp
            SendKeys.Send("{END}")
        Catch ex As Exception
            RdoAllKala.Checked = True
            RdoAval.Checked = True
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If ChkAll.Visible = False Then
            If e.KeyCode = Keys.Escape Then
                IdKala = 0
                DK = False
                DK_JOZ = 0
                DK_KOL = 0
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                TmpVahed = ""
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        IdKala = CLng(DGV.Item("Cln_IdKala", DGV.CurrentRow.Index).Value.ToString)
                        Tmp_Namkala = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString + "-" + DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                        Tmp_OneGroup = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString
                        Tmp_TwoGroup = DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                        Me.Close()
                    End If
                Catch ex As Exception
                    IdKala = 0
                    DK = False
                    DK_JOZ = 0
                    DK_KOL = 0
                    Tmp_Namkala = ""
                    Tmp_OneGroup = ""
                    Tmp_TwoGroup = ""
                    TmpVahed = ""
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
                                AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString + "-" + DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                                AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV.Item("Cln_OneGroup", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV.Item("Cln_TwoGroup", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdKala", i).Value
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
            If BtnNewKala.Enabled = True Then Call BtnNewKala_Click(Nothing, Nothing)
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
                    IdKala = CLng(DGV.Item("Cln_IdKala", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_Namkala = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString + "-" + DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                    Tmp_OneGroup = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString
                    Tmp_TwoGroup = DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                End If
            ElseIf ChkAll.Visible = True Then

                If DGV.RowCount > 0 Then
                    Array.Resize(AllSelectKala, 0)
                    For i As Integer = 0 To DGV.RowCount - 1
                        If DGV.Item("Cln_Select", i).Value = True Then
                            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString + "-" + DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                            AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV.Item("Cln_OneGroup", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV.Item("Cln_TwoGroup", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdKala", i).Value
                        End If
                    Next
                    Me.Close()
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            DK = False
            DK_JOZ = 0
            DK_KOL = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpVahed = ""
            Array.Resize(AllSelectKala, 0)
            Me.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        If ChkAll.Visible = False Then
            IdKala = 0
            DK = False
            DK_JOZ = 0
            DK_KOL = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpVahed = ""
        ElseIf ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        Me.Close()
    End Sub

    Private Sub RdoOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOne.CheckedChanged
        If RdoOne.Checked = True Then
            CmbOne.Enabled = True
            CmbOne.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOne.Text = ""
            CmbOne.Enabled = False
        End If
    End Sub

    Private Sub RdoAllKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAllKala.CheckedChanged
        If RdoAllKala.Checked = True Then
            CmbOne.Enabled = False
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

    Private Sub CmbOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOne.KeyDown
        If CmbOne.DroppedDown = False Then
            CmbOne.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtSearch.Focus()
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

    Private Sub CmbOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOne.SelectedIndexChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%' AND NamTwo Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub


    Private Sub CmbOne_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOne.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%' AND NamTwo Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
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

    Private Sub BtnNewKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewKala.Click
        Try
            Fnew = True
            Using Frmkala As New DefineGroup
                Frmkala.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GroupTwo_List", "BtnNewKala_Click")
        End Try
    End Sub

    Private Sub BtnNewKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnNewKala.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoCodeOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCodeOne.CheckedChanged
        If RdoCodeOne.Checked = True Then
            CmbOne.Enabled = False
            TxtSearch.Focus()
            Try
                TxtSearch.Text = ""
                dv.RowFilter = ""
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub

    Private Sub RdoCodeTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCodeTwo.CheckedChanged
        If RdoCodeTwo.Checked = True Then
            CmbOne.Enabled = False
            TxtSearch.Focus()
            Try
                TxtSearch.Text = ""
                dv.RowFilter = ""
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub
End Class