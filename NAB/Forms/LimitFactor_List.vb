Imports System.Data.SqlClient
Public Class LimitFactor_List
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()
    Public StrSQL As String
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

        If CDbl(DGV.Item("cln_Remain", e.RowIndex).Value) <= 0 Then
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.SpringGreen
            If CDbl(DGV.Item("cln_Remain", e.RowIndex).Value) < 0 Then DGV.Rows(e.RowIndex).Cells("cln_Remain").Style.BackColor = Color.Yellow
        Else
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub
    Private Sub GetFactor()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter(StrSQL, DataSource)
            Dta.Fill(Ds)
            If Not Ds.Tables(0).Columns.Contains("Delay") Then Ds.Tables(0).Columns.Add("Delay", Type.GetType("System.Double"))
            For i As Integer = 0 To Ds.Tables(0).Rows.Count - 1

                Dim newDate As String = Ds.Tables(0).Rows(i).Item("D_date")

                Dim rate As Long = SUBDAY(CalDate(Ds.Tables(0).Rows(i).Item("D_date"), Ds.Tables(0).Rows(i).Item("Rate"), Ds.Tables(0).Rows(i).Item("MaxNewDate")), Ds.Tables(0).Rows(i).Item("D_date"))
                Ds.Tables(0).Rows(i).Item("Rate") = rate
                For j As Integer = 0 To rate - 1
                    newDate = ADDDAY(newDate)
                Next
                Ds.Tables(0).Rows(i).Item("Delay") = SUBDAY(newDate, GetDate())

            Next
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables(0).DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LimitFactor_List", "GetFactor")
            Me.Close()
        End Try
    End Sub

    Private Function CalDate(ByVal Dat As String, ByVal Count As Long, ByVal NewDat As String) As String
        Try
            For i As Integer = 1 To Count
                Dat = ADDDAY(Dat)
            Next
            If String.IsNullOrEmpty(NewDat) Then
                Return Dat
            Else
                If Dat >= NewDat Then
                    Return Dat
                Else
                    Return NewDat
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub RefreshBank()
        Try
            Ds.Clear()
            Dta.Fill(Ds)
            For i As Integer = 0 To Ds.Tables(0).Rows.Count - 1
                Dim newDate As String = Ds.Tables(0).Rows(i).Item("D_date")
                For j As Integer = 0 To Ds.Tables(0).Rows(i).Item("Rate") - 1
                    newDate = ADDDAY(newDate)
                Next
                Ds.Tables(0).Rows(i).Item("Delay") = SUBDAY(newDate, GetDate())
            Next
            TxtSearch.Text = ""
            CalCulateMoney()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LimitFactor_List", "RefreshBank")
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
                If ChkShow.Checked = True Then
                    dv.RowFilter = ""
                Else
                    dv.RowFilter = "Remain>0"
                End If
                CalCulateMoney()
            Else
                If ChkShow.Checked = True Then
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim
                Else
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim & " AND Remain>0"
                End If
                CalCulateMoney()
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            If ChkShow.Checked = True Then
                dv.RowFilter = ""
            Else
                dv.RowFilter = "Remain>0"
            End If
            CalCulateMoney()
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
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetFactor()
        CalCulateMoney()
        IdKala = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        Tmp_Mon = 0
        If ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        DGV.Columns("Cln_Remain").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetMoney.htm")
        If ChkAll.Visible = False Then
            If e.KeyCode = Keys.Escape Then
                IdKala = 0
                Tmp_Mon = 0
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        IdKala = CLng(DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString)
                        Tmp_Mon = CDbl(DGV.Item("Cln_Remain", DGV.CurrentRow.Index).Value)
                        Me.Close()
                    End If
                Catch ex As Exception
                    IdKala = 0
                    Tmp_Mon = 0
                    Tmp_Namkala = ""
                    Tmp_OneGroup = ""
                    Tmp_TwoGroup = ""
                    Me.Close()
                End Try
            End If
        ElseIf ChkAll.Visible = True Then
            If e.KeyCode = Keys.Escape Then
                Array.Resize(AllSelectKala, 0)
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        Array.Resize(AllSelectKala, 0)
                        For i As Integer = 0 To DGV.RowCount - 1
                            If DGV.Item("Cln_Select", i).Value = True Then
                                Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                                AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
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

    Private Sub BtnExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnExit.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub RdoAval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If ChkAll.Visible = False Then
                If DGV.RowCount > 0 Then
                    IdKala = CLng(DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_Mon = CDbl(DGV.Item("Cln_Remain", DGV.CurrentRow.Index).Value)
                End If
            ElseIf ChkAll.Visible = True Then

                If DGV.RowCount > 0 Then
                    Array.Resize(AllSelectKala, 0)
                    For i As Integer = 0 To DGV.RowCount - 1
                        If DGV.Item("Cln_Select", i).Value = True Then
                            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
                        End If
                    Next
                    Me.Close()
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            Tmp_Mon = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            Array.Resize(AllSelectKala, 0)
            Me.Close()
        End Try
    End Sub

    Private Sub CalCulateMoney()
        Try
            Dim res As Double = 0
            For i As Integer = 0 To DGV.RowCount - 1
                res += CDbl(DGV.Item("Cln_Remain", i).Value)
            Next
            If res = 0 Then
                TxtRemain.Text = "0"
            Else
                TxtRemain.Text = FormatNumber(res, 0)
            End If
        Catch ex As Exception
            TxtRemain.Text = "0"
        End Try
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        If ChkAll.Visible = False Then
            IdKala = 0
            Tmp_Mon = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
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

    Private Sub ChkAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkAll.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnNewP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub ChkShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShow.CheckedChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                If ChkShow.Checked = True Then
                    dv.RowFilter = ""
                Else
                    dv.RowFilter = "Remain>0"
                End If
                CalCulateMoney()
            Else
                If ChkShow.Checked = True Then
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim
                Else
                    dv.RowFilter = "IdFactor = " & TxtSearch.Text.Trim & " AND Remain>0"
                End If
                CalCulateMoney()
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            If ChkShow.Checked = True Then
                dv.RowFilter = ""
            Else
                dv.RowFilter = "Remain>0"
            End If
            CalCulateMoney()
        End Try
    End Sub

    Private Sub ChkShow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkShow.KeyDown
        Me.GetKey(e)
    End Sub
End Class