Imports System.Data.SqlClient
Public Class FrmBalanceKalaM
    Public Query As String
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl
    Public Num1, Num2 As Double

    Private Sub ShowBalanceKala()
        Dim dt As New DataTable
        Dim dv As DataView
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(Query, ConectionBank)
                SQLComanad.CommandTimeout = 0
                dt.Load(SQLComanad.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                dv = dt.DefaultView
                If Num1 <> -1 Or Num2 <> -1 Then
                    If Num1 <> -1 And Num2 <> -1 Then
                        dv.RowFilter = "DarsadNum>=" & CDbl(Num1) & " AND DarsadNum<=" & CDbl(Num2)
                        dv.Sort = "DarsadNum"
                    ElseIf Num1 <> -1 And Num2 = -1 Then
                        dv.RowFilter = "DarsadNum>=" & CDbl(Num1)
                        dv.Sort = "DarsadNum"
                    ElseIf Num1 = -1 And Num2 <> -1 Then
                        dv.RowFilter = "DarsadNum<=" & CDbl(Num2)
                        dv.Sort = "DarsadNum"
                    Else
                        dv.RowFilter = ""
                    End If
                End If
                If dv.Count > 0 Then
                    For i As Integer = 0 To dv.Count - 1
                        DGV1.Rows.Add()
                        DGV1.Item("Cln_Id", DGV1.RowCount - 1).Value = dv.Item(i).Item("GroupKala")
                        DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value = dv.Item(i).Item("Nam")
                        DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = dv.Item(i).Item("MKolStr")
                        DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = dv.Item(i).Item("MJozStr")
                        DGV1.Item("Cln_tKol", DGV1.RowCount - 1).Value = dv.Item(i).Item("KolStr")
                        DGV1.Item("Cln_tJoz", DGV1.RowCount - 1).Value = dv.Item(i).Item("JozStr")
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = dv.Item(i).Item("Darsad")
                        DGV1.Item("Cln_t1Kol", DGV1.RowCount - 1).Value = dv.Item(i).Item("KolOrderWeek")
                        DGV1.Item("Cln_t1Joz", DGV1.RowCount - 1).Value = dv.Item(i).Item("JozOrderWeek")
                        DGV1.Item("Cln_t1mKol", DGV1.RowCount - 1).Value = dv.Item(i).Item("KolOrderMonth")
                        DGV1.Item("Cln_t1mJoz", DGV1.RowCount - 1).Value = dv.Item(i).Item("JozOrderMonth")
                        DGV1.Item("Cln_OrderKol", DGV1.RowCount - 1).Value = dv.Item(i).Item("KO").ToString.Replace(".", "/")
                        DGV1.Item("Cln_OrderJoz", DGV1.RowCount - 1).Value = dv.Item(i).Item("JO").ToString.Replace(".", "/")
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dv.Item(i).Item("DK")
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dv.Item(i).Item("DK_KOL")
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dv.Item(i).Item("DK_JOZ")
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = dv.Item(i).Item("Fe")
                        DGV1.Item("Cln_W", DGV1.RowCount - 1).Value = dv.Item(i).Item("we")
                        DGV1.Item("Cln_Ton", DGV1.RowCount - 1).Value = If(dv.Item(i).Item("DK") = True, (dv.Item(i).Item("JO") * dv.Item(i).Item("we")).ToString.Replace(".", "/"), (dv.Item(i).Item("KO") * dv.Item(i).Item("we")).ToString.Replace(".", "/"))
                        DGV1.Item("Cln_Mon", DGV1.RowCount - 1).Value = If(dv.Item(i).Item("DK") = True, If(dv.Item(i).Item("JO") * dv.Item(i).Item("Fe") > 0, FormatNumber(dv.Item(i).Item("JO") * dv.Item(i).Item("Fe"), 0), dv.Item(i).Item("JO") * dv.Item(i).Item("Fe")), If(dv.Item(i).Item("KO") * dv.Item(i).Item("Fe") > 0, FormatNumber(dv.Item(i).Item("KO") * dv.Item(i).Item("Fe"), 0), dv.Item(i).Item("KO") * dv.Item(i).Item("Fe")))
                    Next
                Else
                    MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBalanceKalaM", "ShowBalanceKala")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmBalanceKalaM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmBalanceKalaM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV1.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ShowBalanceKala()

        CalculateAllRowMoney()
    End Sub

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        CalculateAllRowMoney()
    End Sub

    Private Sub DGV1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    CalculateAllRowMoney()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        Try
            If DGV1.CurrentCell.ColumnIndex <> 11 Then DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            '''''''''''''''''''''''''''''''''''کنترل فی
            If DGV1.CurrentCell.ColumnIndex = 13 Then
                If Char.IsNumber(e.KeyChar) = False Then
                    e.Handled = True
                End If
                If e.KeyChar = (vbBack) Then
                    e.Handled = False
                End If
                If e.KeyChar = (vbTab) Then
                    e.Handled = False
                End If
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزء
            If DGV1.CurrentCell.ColumnIndex = 11 Or DGV1.CurrentCell.ColumnIndex = 12 Then
                If Char.IsNumber(e.KeyChar) = False Then
                    e.Handled = True
                End If
                If e.KeyChar = (vbBack) Then
                    e.Handled = False
                End If
                If e.KeyChar = (vbTab) Then
                    e.Handled = False
                End If
                If e.KeyChar = "." Then
                    If InStr(txt_dgv.Text, "/") = False Then
                        e.Handled = False
                        e.KeyChar = "/"
                    End If
                End If
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV1.CurrentCell.ColumnIndex = 13 Then
                If Not (CheckDigitWithOutpoint(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value), "###,###")
                End If
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value)
            ElseIf DGV1.CurrentCell.ColumnIndex = 11 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = Format((CDbl(txt_dgv.Text)) * CDbl(DGV1.Item("Cln_W", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                Else
                    DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    If String.IsNullOrEmpty(DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value) Then DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                    If DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0

                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_W", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                End If

                Try
                    If DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = 0
                End Try

                Try
                    If DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_OrderJoz", DGV1.CurrentRow.Index).Value = 0
                End Try
               
            ElseIf DGV1.CurrentCell.ColumnIndex = 12 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value), "###,###")
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_W", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                Else
                    DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                    DGV1.Item("Cln_ton", DGV1.CurrentRow.Index).Value = Format((CDbl(txt_dgv.Text)) * CDbl(DGV1.Item("Cln_W", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                End If
                'DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value)

                Try
                    If DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_Mon", DGV1.CurrentRow.Index).Value = 0
                End Try

                Try
                    If DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value = 0

                Catch ex As Exception
                    DGV1.Item("Cln_OrderKol", DGV1.CurrentRow.Index).Value = 0
                End Try

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalculateAllRowMoney()
        Try
            Dim AllMon As Double = 0
            Dim W As Double = 0
            Dim OrderKol As Double = 0
            Dim OrderJoz As Double = 0

            TxtAllMon.Text = 0
            TxtW.Text = 0
            TxtOrderKol.Text = 0
            TxtOrderJoz.Text = 0

            For i As Integer = 0 To DGV1.Rows.Count - 1
                If DGV1.Item("Cln_DK", i).Value = False Then
                    DGV1.Item("Cln_Mon", i).Value = Format(CDbl(DGV1.Item("Cln_Fe", i).Value) * If(String.IsNullOrEmpty(DGV1.Item("Cln_OrderKol", i).Value), 0, CDbl(DGV1.Item("Cln_OrderKol", i).Value)), "###,###")
                    DGV1.Item("Cln_ton", i).Value = Format(CDbl(DGV1.Item("Cln_OrderKol", i).Value) * CDbl(DGV1.Item("Cln_W", i).Value), "###.##").ToString.Replace(".", "/")
                Else
                    DGV1.Item("Cln_Mon", i).Value = Format(CDbl(DGV1.Item("Cln_Fe", i).Value) * If(String.IsNullOrEmpty(DGV1.Item("Cln_OrderJoz", i).Value), 0, CDbl(DGV1.Item("Cln_OrderJoz", i).Value)), "###,###")
                    DGV1.Item("Cln_ton", i).Value = Format(CDbl(DGV1.Item("Cln_OrderJoz", i).Value) * CDbl(DGV1.Item("Cln_W", i).Value), "###.##").ToString.Replace(".", "/")
                End If
                If DGV1.Item("Cln_Mon", i).Value = "" Then DGV1.Item("Cln_Mon", i).Value = 0
                If DGV1.Item("Cln_ton", i).Value = "" Then DGV1.Item("Cln_ton", i).Value = 0

                AllMon += CDbl(DGV1.Item("Cln_Mon", i).Value)
                W += CDbl(DGV1.Item("Cln_ton", i).Value.ToString.Replace("/", "."))
                OrderKol += CDbl(DGV1.Item("Cln_OrderKol", i).Value.ToString.Replace("/", "."))
                OrderJoz += CDbl(DGV1.Item("Cln_OrderJoz", i).Value.ToString.Replace("/", "."))
            Next

            TxtAllMon.Text = IIf(AllMon > 0, FormatNumber(AllMon, 0), 0)
            TxtW.Text = IIf(W <> 0, W.ToString.Replace(".", "/"), 0)
            TxtOrderKol.Text = IIf(OrderKol <> 0, OrderKol.ToString.Replace(".", "/"), 0)
            TxtOrderJoz.Text = IIf(OrderJoz <> 0, OrderJoz.ToString.Replace(".", "/"), 0)
        Catch ex As Exception
            TxtAllMon.Text = 0
            TxtW.Text = 0
            TxtOrderKol.Text = 0
            TxtOrderJoz.Text = 0
        End Try
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        DGV1.RefreshEdit()
        BtnReport.Focus()

        If DGV1.RowCount <= 0 Then
            MessageBox.Show("گزارشی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Array.Resize(ListOrderManual, 0)
        Dim SumMkolStr As Double = 0
        Dim SumMJozStr As Double = 0
        Dim SumKolStr As Double = 0
        Dim SumJozStr As Double = 0
        Dim SumKolOrderDay As Double = 0
        Dim SumKolOrderWeek As Double = 0
        Dim SumJozOrderWeek As Double = 0
        Dim SumKolOrderMonth As Double = 0
        Dim SumJozOrderMonth As Double = 0
        Dim SumKolOrder As Double = 0
        Dim SumJozOrder As Double = 0
        Dim SumDarsad As Double = 0

        For i As Integer = 0 To DGV1.RowCount - 1
            Array.Resize(ListOrderManual, ListOrderManual.Length + 1)
            ListOrderManual(ListOrderManual.Length - 1).GroupKala = DGV1.Item("Cln_Id", i).Value
            ListOrderManual(ListOrderManual.Length - 1).Nam = DGV1.Item("Cln_Name", i).Value
            ListOrderManual(ListOrderManual.Length - 1).MKolStr = DGV1.Item("Cln_KolCount", i).Value
            ListOrderManual(ListOrderManual.Length - 1).MJozStr = DGV1.Item("Cln_JozCount", i).Value
            ListOrderManual(ListOrderManual.Length - 1).KolStr = DGV1.Item("Cln_tKol", i).Value
            ListOrderManual(ListOrderManual.Length - 1).JozStr = DGV1.Item("Cln_tJoz", i).Value
            ListOrderManual(ListOrderManual.Length - 1).Darsad = DGV1.Item("Cln_Darsad", i).Value
            ListOrderManual(ListOrderManual.Length - 1).KolOrderWeek = DGV1.Item("Cln_t1Kol", i).Value
            ListOrderManual(ListOrderManual.Length - 1).JozOrderWeek = DGV1.Item("Cln_t1Joz", i).Value
            ListOrderManual(ListOrderManual.Length - 1).KolOrderMonth = DGV1.Item("Cln_t1mKol", i).Value
            ListOrderManual(ListOrderManual.Length - 1).JozOrderMonth = DGV1.Item("Cln_t1mJoz", i).Value
            ListOrderManual(ListOrderManual.Length - 1).KolOrder = DGV1.Item("Cln_OrderKol", i).Value
            ListOrderManual(ListOrderManual.Length - 1).JozOrder = DGV1.Item("Cln_OrderJoz", i).Value
            ListOrderManual(ListOrderManual.Length - 1).KolOrderDay = DGV1.Item("Cln_Ton", i).Value
            ListOrderManual(ListOrderManual.Length - 1).Fe = DGV1.Item("Cln_Fe", i).Value
            ListOrderManual(ListOrderManual.Length - 1).AllMon = DGV1.Item("Cln_Mon", i).Value

            SumMkolStr += CDbl(DGV1.Item("Cln_KolCount", i).Value.ToString.Replace("/", "."))
            SumMJozStr += CDbl(DGV1.Item("Cln_JozCount", i).Value.ToString.Replace("/", "."))
            SumKolStr += CDbl(DGV1.Item("Cln_tKol", i).Value.ToString.Replace("/", "."))
            SumJozStr += CDbl(DGV1.Item("Cln_tJoz", i).Value.ToString.Replace("/", "."))
            SumKolOrderDay += CDbl(DGV1.Item("Cln_Ton", i).Value.ToString.Replace("/", "."))
            SumKolOrderWeek += CDbl(DGV1.Item("Cln_t1Kol", i).Value.ToString.Replace("/", "."))
            SumJozOrderWeek += CDbl(DGV1.Item("Cln_t1Joz", i).Value.ToString.Replace("/", "."))
            SumKolOrderMonth += CDbl(DGV1.Item("Cln_t1mKol", i).Value.ToString.Replace("/", "."))
            SumJozOrderMonth += CDbl(DGV1.Item("Cln_t1mJoz", i).Value.ToString.Replace("/", "."))
            SumKolOrder += CDbl(DGV1.Item("Cln_OrderKol", i).Value.ToString.Replace("/", "."))
            SumJozOrder += CDbl(DGV1.Item("Cln_OrderJoz", i).Value.ToString.Replace("/", "."))
            SumDarsad += If(DGV1.Item("Cln_Darsad", i).Value.ToString <> "-", CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", ".")), 0)
        Next
        ListOrderManual(0).SumMKolStr = SumMkolStr.ToString.Replace(".", "/")
        ListOrderManual(0).SumMJozStr = SumMJozStr.ToString.Replace(".", "/")
        ListOrderManual(0).SumKolStr = SumKolStr.ToString.Replace(".", "/")
        ListOrderManual(0).SumJozStr = SumJozStr.ToString.Replace(".", "/")
        ListOrderManual(0).SumDarsad = SumDarsad.ToString.Replace(".", "/")
        ListOrderManual(0).SumKolOrderWeek = SumKolOrderWeek.ToString.Replace(".", "/")
        ListOrderManual(0).SumJozOrderWeek = SumJozOrderWeek.ToString.Replace(".", "/")
        ListOrderManual(0).SumKolOrderMonth = SumKolOrderMonth.ToString.Replace(".", "/")
        ListOrderManual(0).SumJozOrderMonth = SumJozOrderMonth.ToString.Replace(".", "/")
        ListOrderManual(0).SumKolOrder = SumKolOrder.ToString.Replace(".", "/")
        ListOrderManual(0).SumJozOrder = SumJozOrder.ToString.Replace(".", "/")
        ListOrderManual(0).SumKolOrderDay = SumKolOrderDay.ToString.Replace(".", "/")

        FrmPrint.CHoose = "BALANCEKALAORDERM"
        FrmPrint.ShowDialog()
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Taradod.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then BtnReport_Click(Nothing, Nothing)
        End If
    End Sub
End Class