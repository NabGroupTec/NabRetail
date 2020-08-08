Imports System.Data.SqlClient
Public Class Factor_List2
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()
    Public str As String
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
    Private Sub GetFactor()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter(str, DataSource)
            Dta.Fill(Ds)
            CmbOstan.Items.Clear()
            CmbCity.Items.Clear()
            For i As Integer = 0 To Ds.Tables(0).Rows.Count - 1
                If CmbOstan.FindStringExact(Ds.Tables(0).Rows(i).Item("NamO")) = -1 Then
                    CmbOstan.Items.Add(Ds.Tables(0).Rows(i).Item("NamO"))
                End If
            Next
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables(0).DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Factor_List2", "GetFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub RefreshBank()
        Try
            Ds.Clear()
            Dta.Fill(Ds)
            TxtSearch.Text = ""
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Factor_List2", "RefreshBank")
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

    Private Sub TxtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSearch.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then

                If RdoAllKala.Checked = True Then
                    dv.RowFilter = ""
                ElseIf RdoOne.Checked = True Then
                    dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'"
                ElseIf RdoTwo.Checked = True Then
                    dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'"
                ElseIf RdoDate.Checked = True Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "'"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                        dv.RowFilter = ""
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAllKala.Checked = True Then
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim
                ElseIf RdoOne.Checked = True Then
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim & "  AND NamO Like '" & CmbOstan.Text.Trim & "%'"
                ElseIf RdoTwo.Checked = True Then
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim & "  AND NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'"
                ElseIf RdoDate.Checked = True Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "' AND IdFactor=" & TxtSearch.Text
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND IdFactor=" & TxtSearch.Text
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "' AND IdFactor=" & TxtSearch.Text
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                        dv.RowFilter = ""
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
        Me.GetFactor()
        IdKala = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        Tmp_String1 = ""
        Tmp_String2 = ""
        If ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If ChkAll.Visible = False Then
            If e.KeyCode = Keys.Escape Then
                IdKala = 0
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                Tmp_String1 = ""
                Tmp_String2 = ""
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        IdKala = CLng(DGV.Item("Cln_IdFac", DGV.CurrentRow.Index).Value.ToString)
                        Tmp_Namkala = DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value
                        Tmp_String1 = DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value
                        Tmp_String2 = DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value
                        TmpAddress = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value
                        Me.Close()
                    End If
                Catch ex As Exception
                    IdKala = 0
                    Tmp_Namkala = ""
                    Tmp_OneGroup = ""
                    Tmp_TwoGroup = ""
                    Tmp_String1 = ""
                    Tmp_String2 = ""
                    TmpAddress = ""
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
                                AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Name", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_Idfac", i).Value
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
            If BtnExit.Enabled = True Then Call BtnExit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            BtnOk.Focus()
            If ChkAll.Visible = False Then
                If DGV.RowCount > 0 Then
                    IdKala = CLng(DGV.Item("Cln_IdFac", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_Namkala = DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value
                    Tmp_String1 = DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value
                    Tmp_String2 = DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value
                    TmpAddress = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value
                End If
            ElseIf ChkAll.Visible = True Then

                If DGV.RowCount > 0 Then
                    Array.Resize(AllSelectKala, 0)
                    For i As Integer = 0 To DGV.RowCount - 1
                        If DGV.Item("Cln_Select", i).Value = True Then
                            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Name", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_Idfac", i).Value
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
            Tmp_String1 = ""
            Tmp_String2 = ""
            TmpAddress = ""
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
            Tmp_String1 = ""
            Tmp_String2 = ""
            TmpAddress = ""
        ElseIf ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        Me.Close()
    End Sub

    Private Sub RdoAval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtSearch.Focus()
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtSearch.Focus()
    End Sub

    Private Sub CmbOstan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstan.LostFocus
        Me.GetTwoGroup(CmbOstan.Text.Trim)
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'"
            Else
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND IdFactor =" & TxtSearch.Text.Trim
            End If
            Me.GetTwoGroup(CmbOstan.Text.Trim)
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub
    Private Sub GetTwoGroup(ByVal NamG As String)
        Try
            CmbCity.Items.Clear()
            If String.IsNullOrEmpty(NamG) Then Exit Sub
            Dim dr() As DataRow = Ds.Tables(0).Select("NamO='" & NamG & "'")
            If dr.Length > 0 Then
                For i As Integer = 0 To dr.Length - 1
                    If CmbCity.FindStringExact(dr(i).Item("NamCI")) = -1 Then
                        CmbCity.Items.Add(dr(i).Item("NamCI"))
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%'"
            Else
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%' AND IdFactor =" & TxtSearch.Text.Trim
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbOstan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstan.TextChanged
        Try
            dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND IdFactor =" & TxtSearch.Text.Trim
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbCity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCity.TextChanged
        Try
            dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%' AND IdFactor =" & TxtSearch.Text.Trim
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub RdoOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOne.CheckedChanged
        If RdoOne.Checked = True Then
            CmbOstan.Enabled = True
            CmbOstan.Focus()
            Try
                TxtSearch.Text = ""
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'"
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOstan.Text = ""
            CmbCity.Text = ""
            CmbOstan.Enabled = False
        End If
    End Sub

    Private Sub RdoTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTwo.CheckedChanged
        If RdoTwo.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbOstan.Focus()
            Try
                TxtSearch.Text = ""
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%'"
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOstan.Text = ""
            CmbCity.Text = ""
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
        End If
    End Sub

    Private Sub RdoDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDate.CheckedChanged
        If RdoDate.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                dv.RowFilter = ""
            End If
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub ChkAzDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkAzDate.Checked = True Then
            FarsiDate1.ThisText = GetDate()
            FarsiDate1.Enabled = True
            FarsiDate1.Focus()
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                dv.RowFilter = ""
            End If
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
        End If
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                dv.RowFilter = ""
            End If
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
        End If
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

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        If RdoDate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                dv.RowFilter = ""
            End If
        End If
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        If RdoDate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_Date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                dv.RowFilter = ""
            End If
        End If
    End Sub
End Class