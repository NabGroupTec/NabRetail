Imports System.Data.SqlClient
Imports System.Transactions

Public Class FrmKasriFactor
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Try

            If e.ColumnIndex = 2 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If DGV1.Item("Cln_DK", e.RowIndex).Value = True Then
                            For i As Integer = 1 To 7
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 8
                                SendKeys.Send("+{TAB}")
                            Next
                        End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 3 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        For i As Integer = 1 To 5
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 5 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        For i As Integer = 1 To 2
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
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
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                        DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_KolCount1", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JozCount1", DGV1.CurrentRow.Index).Value = ""
                    End If
                    If DGV1.RowCount > 0 Then
                        Txtallmoney.Text = "0"
                        TxtMonFac.Text = "0"
                        For i As Integer = 0 To DGV1.RowCount - 2
                            If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                                Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                            End If
                            If (CheckDigit(DGV1.Item("Cln_DarsadMon", i).Value)) Then
                                TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value.ToString)
                            End If
                        Next i
                        If Txtallmoney.Text.Length > 3 Then
                            Dim money As String = ""
                            money = Txtallmoney.Text.Replace(",", "")
                            Txtallmoney.Text = Format$(Val(money), "###,###,###")
                        End If
                        If TxtMonFac.Text.Length > 3 Then
                            Dim money As String = ""
                            money = TxtMonFac.Text.Replace(",", "")
                            TxtMonFac.Text = Format$(Val(money), "###,###,###")
                        End If
                    Else
                        Txtallmoney.Text = "0"
                        TxtMonFac.Text = "0"
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
        CalculateMoney()
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub TxtIDFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIDFac.KeyDown
        If e.KeyCode = Keys.Enter Then FarsiDate1.Focus()
    End Sub

    Private Sub TxtIDFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIDFac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Factor_List
        frmlk.str = "SELECT ListFactorSell.IdFactor, ListFactorSell.D_date,ListFactorSell.IdName, Define_People.Nam FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtIDFac.Focus()
        If IdKala <> 0 Then
            If TxtIDFac.Text <> CStr(IdKala) Then
                If DGV1.RowCount - 1 > 0 Then
                    If MessageBox.Show("در صورت تغییر شماره فاکتور کالاهای تعیین شده حذف خواهد شد آیا برای ادامه کار مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        EmptyGridKala()
                    Else
                        e.Handled = True
                        Exit Sub
                    End If
                End If
            End If
            TxtDate.Text = Tmp_String1
            TxtPeople.Text = Tmp_Namkala
            TxtIdName.Text = Tmp_String2
            TxtIDFac.Text = IdKala
        End If
    End Sub

    Private Sub EmptyGridKala()
        If DGV1.RowCount > 1 Then
            DGV1.Item("Cln_Name", 0).Selected = True
            For i As Integer = DGV1.RowCount - 2 To 0 Step -1
                DGV1.Rows.RemoveAt(i)
            Next
        Else
            DGV1.Item("Cln_type", 0).Value = ""
            DGV1.Item("Cln_name", 0).Value = ""
            DGV1.Item("Cln_KolCount", 0).Value = ""
            DGV1.Item("Cln_JozCount", 0).Value = ""
            DGV1.Item("Cln_Fe", 0).Value = ""
            DGV1.Item("Cln_Darsad", 0).Value = ""
            DGV1.Item("Cln_DarsadMon", 0).Value = ""
            DGV1.Item("Cln_Money", 0).Value = ""
            DGV1.Item("Cln_Disc", 0).Value = ""
            DGV1.Item("Cln_code", 0).Value = ""
            DGV1.Item("Cln_DK", 0).Value = False
            DGV1.Item("Cln_KOL", 0).Value = ""
            DGV1.Item("Cln_JOZ", 0).Value = ""
        End If
        Txtallmoney.Text = "0"
        TxtMonFac.Text = "0"
    End Sub

    Private Sub CalculateMoney()
        Dim allmoney As Double = 0
        Dim alldarsad As Double = 0
        For i As Integer = 0 To DGV1.Rows.Count - 2
            allmoney += CDbl(DGV1.Item("cln_Money", i).Value)
            alldarsad += CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
        Next
        If alldarsad.ToString.Length > 3 Then
            TxtMonFac.Text = Format(alldarsad, "###,###")
        Else
            TxtMonFac.Text = alldarsad
        End If

        If allmoney.ToString.Length > 3 Then
            Txtallmoney.Text = Format(allmoney, "###,###")
        Else
            Txtallmoney.Text = allmoney
        End If
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
            If DGV1.RowCount > 0 Then
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                        Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                    End If
                    If (CheckDigit(DGV1.Item("Cln_DarsadMon", i).Value)) Then
                        TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value.ToString)
                    End If
                Next i
                If Txtallmoney.Text.Length > 3 Then
                    Dim money As String = ""
                    money = Txtallmoney.Text.Replace(",", "")
                    Txtallmoney.Text = Format$(Val(money), "###,###,###")
                End If
                If TxtMonFac.Text.Length > 3 Then
                    Dim money As String = ""
                    money = TxtMonFac.Text.Replace(",", "")
                    TxtMonFac.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV1.CurrentCell.ColumnIndex = 1 Or DGV1.CurrentCell.ColumnIndex = 7 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_KolCount1", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JozCount1", DGV1.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalDarsad()
        Try
            If DGV1.Item("cln_name", DGV1.CurrentRow.Index).Value <> "" Then
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("cln_Money", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value) / 100, "###,###")
            End If
        Catch ex As Exception
            DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = 0
            DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = 0
        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            If String.IsNullOrEmpty(TxtIDFac.Text) Then
                e.Handled = True
                MessageBox.Show("قبل از انتخاب کالا شماره فاکتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtIDFac.Focus()
                Exit Sub
            End If
            ''''''''''''گرفتن نام کالا
            If DGV1.CurrentCell.ColumnIndex = 1 Then
                e.Handled = True
                Dim frmlk As New List_Kala_Factor
                frmlk.LFactor.Text = TxtIDFac.Text
                frmlk.ShowDialog()
                DGV1.Focus()
                If Tmp_Namkala <> "" Then
                    DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = Tmp_OneGroup
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                    DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(Tmp_String1) Or Tmp_String1 = "0", 0, FormatNumber(Tmp_String1, 0))
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = IIf(Tmp_Mon = 0, 0, FormatNumber(Tmp_Mon, 0))
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = IdKala
                    DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = DK
                    DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = DK_KOL
                    DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = DK_JOZ
                    DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(Tmp_String2) Or Tmp_String2 = "0", 0, FormatNumber(Tmp_String2, 0))
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(TmpTell1) Or TmpTell1 = "0", 0, Replace(TmpTell1, ".", "/"))
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(TmpTell2) Or TmpTell2 = "0", 0, Replace(TmpTell2, ".", "/"))
                    DGV1.Item("Cln_KolCount1", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(TmpTell1) Or TmpTell1 = "0", 0, Replace(TmpTell1, ".", "/"))
                    DGV1.Item("Cln_JozCount1", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(TmpTell2) Or TmpTell2 = "0", 0, Replace(TmpTell2, ".", "/"))
                    DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = IIf(String.IsNullOrEmpty(Tmp_TwoGroup) Or Tmp_TwoGroup = "0", 0, Replace(Tmp_TwoGroup, ".", "/"))
                End If
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Selected = True
                CalDarsad()
                CalculateMoney()
            End If

            ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزء
            If DGV1.CurrentCell.ColumnIndex = 3 Or DGV1.CurrentCell.ColumnIndex = 2 Or DGV1.CurrentCell.ColumnIndex = 5 Then
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then
                    e.Handled = True
                    Exit Sub
                End If
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
            '''''''''''کنترل شرح
            If DGV1.CurrentCell.ColumnIndex = 8 Then
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Me.CalDarsad()
                Exit Sub
            End If
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value = "" Then
                txt_dgv.Clear()
                Me.CalDarsad()
                Exit Sub
            End If
            If DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
            ElseIf DGV1.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) <= 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_KolCOUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
            ElseIf DGV1.CurrentCell.ColumnIndex = 5 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) > 100 Then txt_dgv.Text = 100
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("cln_Money", DGV1.CurrentRow.Index).Value) * CDbl(txt_dgv.Text) / 100, "###,###")
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)

                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
            End If

            If DGV1.RowCount > 0 Then
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                        Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                    End If
                    If (CheckDigit(DGV1.Item("Cln_DarsadMon", i).Value)) Then
                        TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value.ToString)
                    End If
                Next i
                If Txtallmoney.Text.Length > 3 Then
                    Dim money As String = ""
                    money = Txtallmoney.Text.Replace(",", "")
                    Txtallmoney.Text = Format$(Val(money), "###,###,###")
                End If
                If TxtMonFac.Text.Length > 3 Then
                    Dim money As String = ""
                    money = TxtMonFac.Text.Replace(",", "")
                    TxtMonFac.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmKasriFactor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If LEdit.Text = "0" Then
            TxtIDFac.Focus()
        Else
            DGV1.Focus()
        End If
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
    End Sub

    Private Sub FrmKasriFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmKasriFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If LEdit.Text = "0" Then
            FarsiDate1.ThisText = GetDate()
        Else
            Me.ShowKalafactor()
            TxtIDFac.Enabled = False
        End If
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BtnSave.Focus()
            DGV1.EndEdit()
            Me.CalculateAllRowMoney()
            Me.Enabled = False
            '''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(FarsiDate1.ThisText.Trim) Or FarsiDate1.ThisText.Trim = "" Then
                MessageBox.Show("تاریخ ثبت کسری فاکتور را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                FarsiDate1.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtIDFac.Text.Trim) Then
                MessageBox.Show("شماره فاکتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                TxtIDFac.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                Me.Enabled = True
                DGV1.Focus()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Exit Sub
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        DGV1.Focus()
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Me.Enabled = False
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                End If

                Dim count_Kala As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                        count_Kala += 1
                    End If
                Next
                If count_Kala > 1 Then
                    MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    DGV1.Focus()
                    DGV1.Item("cln_name", i).Selected = True
                    Exit Sub
                End If

                If CDbl(Replace(DGV1.Item("Cln_KolCount", i).Value, "/", ".")) > CDbl(Replace(DGV1.Item("Cln_KolCount1", i).Value, "/", ".")) Then
                    MessageBox.Show("تعداد کل ، کالای سطر شماره" & i + 1 & " بیشتر از فروش است لطفا آن را اصلاح کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    DGV1.Focus()
                    DGV1.Item("Cln_KolCount", i).Selected = True
                    Exit Sub
                End If

                If CDbl(Replace(DGV1.Item("Cln_JozCount", i).Value, "/", ".")) > CDbl(Replace(DGV1.Item("Cln_JozCount1", i).Value, "/", ".")) Then
                    MessageBox.Show("نسبت جزء ، کالای سطر شماره" & i + 1 & " بیشتر از فروش است لطفا آن را اصلاح کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    DGV1.Focus()
                    DGV1.Item("Cln_JozCount", i).Selected = True
                    Exit Sub
                End If


            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''
            If LEdit.Text = "0" Then
                If Not Me.SaveKasriFactor() Then
                    Me.Enabled = True
                    Exit Sub
                End If
            Else
                If Not Me.EditKasriFactor() Then
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKasriFactor", "BtnSave_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Function SaveKasriFactor() As Boolean
        Dim IdSanad As Long = 0
        Dim CFac As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT COUNT(IdFactor) FROM ListKasriFactor WHERE IdFactor=" & TxtIDFac.Text, ConectionBank)
                CFac = cmd.ExecuteScalar
                If CFac >= 1 Then
                    sqltransaction.Dispose()
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    MessageBox.Show("کسری مربوط به فاکتور مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End Using
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            If CDbl(Txtallmoney.Text) - CDbl(TxtMonFac.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = FarsiDate1.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " کسری فاکتور فروش " & TxtIDFac.Text & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", " - " & TxtDisc.Text)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text) - CDbl(TxtMonFac.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 22
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(TxtIDFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 1
                    IdSanad = Cmd.ExecuteScalar
                End Using
            End If

            Using Cmd As New SqlCommand("INSERT INTO ListKasriFactor (Idfactor,IdUser,Disc,IdSanad,D_date) VALUES(@Idfactor,@IdUser,@Disc,@IdSanad,@D_date)", ConectionBank)
                Cmd.Parameters.AddWithValue("@Idfactor", SqlDbType.BigInt).Value = TxtIDFac.Text
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = FarsiDate1.ThisText
                Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = IIf(IdSanad = 0, DBNull.Value, IdSanad)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO KalaKasriFactor (IdFactor,IdR,KolCount,JozCount,KalaDisc,Fe,Mon,DarsadMon,DarsadDiscount,EndKol,EndJoz) VALUES(@IdFactor,@IdR,@KolCount,@JozCount,@KalaDisc,@Fe,@Mon,@DarsadMon,@DarsadDiscount,@EndKol,@EndJoz)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = TxtIDFac.Text
                    Cmd.Parameters.AddWithValue("@IdR", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                    Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                    Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                    Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                    Cmd.Parameters.AddWithValue("@EndKol", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount1", i).Value)
                    Cmd.Parameters.AddWithValue("@EndJoz", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount1", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "کسری فاکتور", "جدید", " ثبت کسری فاکتور فروش : " & TxtIDFac.Text & "تعداد اقلام کالا:" & DGV1.RowCount - 1 & "جمع مبلغ کسری: " & Txtallmoney.Text, "")
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات کسری فاکتور قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKasriFactor", "SaveKasriFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function EditKasriFactor() As Boolean
        Dim IdSanad As Long = 0
        Dim CFac As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            If CDbl(Txtallmoney.Text) - CDbl(TxtMonFac.Text) > 0 Then
                If String.IsNullOrEmpty(LSanad.Text) Then
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = FarsiDate1.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " کسری فاکتور فروش " & TxtIDFac.Text & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", " - " & TxtDisc.Text)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text) - CDbl(TxtMonFac.Text)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 22
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(TxtIDFac.Text)
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 1
                        IdSanad = Cmd.ExecuteScalar
                    End Using
                Else
                    Using Cmd As New SqlCommand("Update Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=" & CLng(LSanad.Text), ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = FarsiDate1.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " کسری فاکتور فروش " & TxtIDFac.Text & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", " - " & TxtDisc.Text)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text) - CDbl(TxtMonFac.Text)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 22
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(TxtIDFac.Text)
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                        IdSanad = CLng(LSanad.Text)
                    End Using
                End If
            End If

            Using Cmd As New SqlCommand("UPDATE  ListKasriFactor SET  IdUser=@IdUser,Disc=@Disc,IdSanad=@IdSanad,D_date=@D_date WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@Idfactor", SqlDbType.BigInt).Value = TxtIDFac.Text
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = FarsiDate1.ThisText
                Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = IIf(IdSanad = 0, DBNull.Value, IdSanad)
                Cmd.ExecuteNonQuery()
            End Using

            If Not (CDbl(Txtallmoney.Text) - CDbl(TxtMonFac.Text) > 0) Then
                Using Cmd As New SqlCommand("DELETE FROM  Moein_People  WHERE Id=" & CLng(LSanad.Text), ConectionBank)
                    Cmd.ExecuteNonQuery()
                End Using
            End If

            Using Cmd As New SqlCommand("DELETE FROM  KalaKasriFactor  WHERE IdFactor=" & CLng(LFac.Text), ConectionBank)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO KalaKasriFactor (IdFactor,IdR,KolCount,JozCount,KalaDisc,Fe,Mon,DarsadMon,DarsadDiscount,EndKol,EndJoz) VALUES(@IdFactor,@IdR,@KolCount,@JozCount,@KalaDisc,@Fe,@Mon,@DarsadMon,@DarsadDiscount,@EndKol,@EndJoz)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = TxtIDFac.Text
                    Cmd.Parameters.AddWithValue("@IdR", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                    Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                    Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                    Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                    Cmd.Parameters.AddWithValue("@EndKol", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount1", i).Value)
                    Cmd.Parameters.AddWithValue("@EndJoz", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount1", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "کسری فاکتور", "ویرایش", If(LFac.Text <> TxtIDFac.Text, " ویرایش کسری فاکتور فروش : " & LFac.Text & "به فاکتور:" & TxtIDFac.Text & "تعداد اقلام کالا:" & DGV1.RowCount - 1 & "جمع مبلغ کسری: " & Txtallmoney.Text, " ویرایش کسری فاکتور فروش : " & TxtIDFac.Text & "تعداد اقلام کالا:" & DGV1.RowCount - 1 & "جمع مبلغ کسری: " & Txtallmoney.Text), "")
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات کسری فاکتور قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKasriFactor", "EditKasriFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "DecFactor.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CalculateAllRowMoney()
        Try

            Dim allmoney As Double = 0
            Dim alldarsad As Double = 0
            For i As Integer = 0 To DGV1.Rows.Count - 2
                '///////////////////////////////////////////////

                If DGV1.Item("Cln_DK", i).Value = False Then
                    DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_Fe", i).Value) * If(String.IsNullOrEmpty(DGV1.Item("Cln_KolCOUNT", i).Value), 0, CDbl(DGV1.Item("Cln_KolCOUNT", i).Value)), "###,###")
                Else
                    DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_Fe", i).Value) * If(String.IsNullOrEmpty(DGV1.Item("Cln_JozCOUNT", i).Value), 0, CDbl(DGV1.Item("Cln_JozCOUNT", i).Value)), "###,###")
                End If
                DGV1.Item("Cln_Money", i).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", i).Value), 0, DGV1.Item("Cln_Money", i).Value)
                DGV1.Item("Cln_DarsadMon", i).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", i).Value), 0, DGV1.Item("Cln_DarsadMon", i).Value)

                '////////////////////////////////////////////////
                allmoney += CDbl(DGV1.Item("cln_Money", i).Value)
                alldarsad += CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
            Next
            If alldarsad.ToString.Length > 3 Then
                TxtMonFac.Text = Format(alldarsad, "###,###")
            Else
                TxtMonFac.Text = alldarsad
            End If

            If allmoney.ToString.Length > 3 Then
                Txtallmoney.Text = Format(allmoney, "###,###")
            Else
                Txtallmoney.Text = allmoney
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub
    Private Sub ShowKalafactor()
        Try
            Dim QueryKala As String = ""
            Dim QueryInfo As String = ""

            QueryKala = "SELECT KalaKasriFactor.EndJoz, KalaKasriFactor.EndKol, KalaKasriFactor.KolCount, KalaKasriFactor.JozCount, KalaKasriFactor.KalaDisc, KalaKasriFactor.Fe,KalaKasriFactor.Mon, KalaKasriFactor.DarsadMon, KalaKasriFactor.DarsadDiscount, KalaKasriFactor.IdR, Define_Kala.DK, Define_Kala.DK_KOL,Define_Kala.DK_JOZ, Define_Kala.Nam, Define_OneGroup.NamOne + '-'+ Define_TwoGroup.NamTwo As GroupKala FROM KalaKasriFactor INNER JOIN Define_Kala ON KalaKasriFactor.IdR = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE KalaKasriFactor.IdFactor =" & CLng(LFac.Text)
            QueryInfo = "SELECT  ListKasriFactor.D_date, ListKasriFactor.Disc, ListKasriFactor.IdSanad, Define_People.Nam, ListFactorSell.D_date AS D_date_F,ListFactorSell.IdName FROM  ListKasriFactor INNER JOIN ListFactorSell ON ListKasriFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE  ListKasriFactor.IdFactor =" & CLng(LFac.Text)
           
            Dim dtrInfo As SqlDataReader = Nothing
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    dtrInfo.Read()
                    TxtIDFac.Text = LFac.Text
                    TxtDate.Text = dtrInfo("D_Date_F")
                    TxtPeople.Text = dtrInfo("Nam")
                    TxtIdName.Text = dtrInfo("IdName")
                    TxtDisc.Text = If(dtrInfo("Disc") Is DBNull.Value, "", dtrInfo("Disc"))
                    LSanad.Text = If(dtrInfo("IdSanad") Is DBNull.Value, "", dtrInfo("IdSanad"))
                    FarsiDate1.ThisText = dtrInfo("D_Date")
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()



            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryKala, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    DGV1.AllowUserToAddRows = False
                    While dtrInfo.Read
                        DGV1.Rows.Add()
                        DGV1.Item("Cln_Type", DGV1.RowCount - 1).Value = dtrInfo("GroupKala")
                        DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value = dtrInfo("Nam")
                        DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = dtrInfo("KolCount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = dtrInfo("JozCount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = If(dtrInfo("Fe").ToString.Length > 3, Format(dtrInfo("Fe"), "###,###"), dtrInfo("Fe"))
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = dtrInfo("DarsadDiscount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = If(dtrInfo("DarsadMon").ToString.Length > 3, Format(dtrInfo("DarsadMon"), "###,###"), dtrInfo("DarsadMon"))
                        DGV1.Item("cln_Money", DGV1.RowCount - 1).Value = If(dtrInfo("Mon").ToString.Length > 3, Format(dtrInfo("Mon"), "###,###"), dtrInfo("Mon"))
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = If(dtrInfo("KalaDisc") Is DBNull.Value, "", dtrInfo("KalaDisc"))
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = dtrInfo("IdR")
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dtrInfo("DK")
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dtrInfo("DK_KOL")
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dtrInfo("DK_JOZ")
                        DGV1.Item("Cln_KolCount1", DGV1.RowCount - 1).Value = dtrInfo("EndKol")
                        DGV1.Item("Cln_JozCount1", DGV1.RowCount - 1).Value = dtrInfo("EndJoz")
                    End While
                    DGV1.AllowUserToAddRows = True
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.CalculateMoney()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKasriFactor", "ShowKalaFactor")
            Me.Close()
        End Try
    End Sub

End Class