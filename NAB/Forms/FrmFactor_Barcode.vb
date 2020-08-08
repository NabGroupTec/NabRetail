Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmFactor_Barcode
    Dim state, Idfactor, lend, PrintSQl As String
    Dim q, SCost, dkALA, KalDup, Fish, Mojody As Boolean
    Structure Kasri
        Dim IdKala As Long
        Dim Fe As Double
    End Structure
    Structure KalaDiscount
        Dim Idkala As Double
        Dim Kol As Double
        Dim joz As Double
        Dim Coding As String
        Dim CodeAnbar As Long
        Dim anbar As String
    End Structure
    Public Alldiscount(), Alldiscount2() As KalaDiscount
    Dim ListKasri() As Kasri
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

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
    Private Sub CalculateKalaBarcode(ByVal Barcode As String)
        Try
            If String.IsNullOrEmpty(Barcode.Trim) Then
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                If DGV1.RowCount > 1 Then
                    DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    DGV1.Item("Cln_Name", DGV1.RowCount - 1).Selected = True
                End If
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            Else
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim dtr As SqlDataReader = Nothing
                Using CMD As New SqlCommand("SELECT Idkala,namKala,DK,DK_KOL,DK_JOZ,GroupKala,Vahed,IdAnbar,Define_Anbar.nam As NamAnbar FROM (SELECT TOP 1 Define_Kala.Id As Idkala,Define_Kala.Nam As namKala,Define_Kala.DK,Define_Kala.DK_KOL,Define_Kala.DK_JOZ,Define_OneGroup.NamOne + '-'+ Define_TwoGroup.NamTwo As GroupKala,Define_Vahed.Nam AS Vahed ,IdAnbar= CASE WHEN (SELECT IdAnbar FROM SettingProgram WHERE IdUser =" & Id_User & ") IS NULL THEN (SELECT Top 1 Id  FROM Define_Anbar) ELSE (SELECT IdAnbar FROM SettingProgram  WHERE IdUser =" & Id_User & ") END FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed ON Define_Kala.IdVahed = Define_Vahed.Id WHERE Define_Kala.BarCode =N'" & Barcode & "') As ListKala INNER JOIN Define_Anbar On Define_Anbar.ID =Listkala.IdAnbar ", ConectionBank)
                    dtr = CMD.ExecuteReader
                End Using
                If dtr.HasRows Then
                    dtr.Read()
                    '////////////////////////////////////////////
                    If KalDup = True Then
                        Dim intcount As Integer = 0
                        For Each Row As DataGridViewRow In DGV1.Rows
                            If DGV1.Rows(intcount).Cells("Cln_code").Value = dtr("Idkala") And DGV1.Rows(intcount).Cells("cln_type").Value <> "کالای خدماتی" Then
                                DGV1.Item("Cln_KolCount", intcount).Value = (CDbl(DGV1.Item("Cln_KolCount", intcount).Value) + If(dtr("DK_KOL") <= 0, 1, dtr("DK_KOL"))).ToString.Replace(".", "/")
                                DGV1.Item("Cln_JozCount", intcount).Value = (CDbl(DGV1.Item("Cln_JozCount", intcount).Value) + dtr("DK_JOZ")).ToString.Replace(".", "/")
                                If DGV1.RowCount > 1 Then DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                                CalculateAllRowMoney()
                                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                                Exit Sub
                            Else
                                intcount += 1
                            End If
                        Next Row
                    End If
                    '////////////////////////////////////////////
                    DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = dtr("GroupKala")
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = dtr("namKala")
                    DGV1.Item("Cln_vahed", DGV1.CurrentRow.Index).Value = dtr("Vahed")
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = dtr("NamAnbar")
                    DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = dtr("Idkala")
                    DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = dtr("IdAnbar")
                    DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = dtr("DK")
                    DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = dtr("DK_KOL")
                    DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = dtr("DK_JOZ")
                    If dtr("DK") = False Then
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 1
                        DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                    Else
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = dtr("DK_KOL").ToString.Replace(".", "/")
                        DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = dtr("DK_JOZ").ToString.Replace(".", "/")
                    End If
                    DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = 0
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    If CmbFac.Text = CmbFac.Items.Item(3) Then
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = FormatNumber(GetCostFrosh_Barcode(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value, IIf(String.IsNullOrEmpty(TxtIdCityFac.Text), 0, TxtIdCityFac.Text), IIf(String.IsNullOrEmpty(TxtIdPeople.Text), 0, TxtIdPeople.Text)), 0)
                        IIf(String.IsNullOrEmpty(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value)
                    ElseIf CmbFac.Text = CmbFac.Items.Item(0) Then
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = GetCostKharid(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value)
                        IIf(String.IsNullOrEmpty(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value)
                    Else
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = 0
                    End If
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                    DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                    If DGV1.RowCount > 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                        DGV1.Item("Cln_Name", DGV1.RowCount - 1).Selected = True
                    End If
                    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
                End If
                DGV1.RefreshEdit()
                CalculateAllRowMoney()
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        End Try
    End Sub
    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Try
            ''''''''''''''''''''محاسبه کالا بر حسب بارکد
            If DGV1.CurrentCell.ColumnIndex = 1 And CmbFac.Text <> CmbFac.Items.Item(8) Then
                If LEdit.Text <> "0" Then

                    If CmbFac.Text = CmbFac.Items(0) Or CmbFac.Text = CmbFac.Items(4) Then
                        If Not (DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then
                            If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value), CLng(DGV1.Item("Cln_OldAnbar", DGV1.CurrentRow.Index).Value)) Then
                                If MAnbar = True Then
                                    If MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                                Else
                                    MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار است و قابل تغییر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If

                Me.CalculateKalaBarcode(If(DGV1.Item("cln_name", DGV1.CurrentRow.Index).Value Is DBNull.Value, "", DGV1.Item("cln_name", DGV1.CurrentRow.Index).Value))
            End If

            If e.ColumnIndex = 2 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If DGV1.Item("Cln_DK", e.RowIndex).Value = True Then
                            For i As Integer = 1 To 9
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 7
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
                        For i As Integer = 1 To 7
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 5 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If CmbFac.Text = CmbFac.Items.Item(6) Then
                            For i As Integer = 1 To 4
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 6
                                SendKeys.Send("+{TAB}")
                            Next
                        End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 6 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If CmbFac.Text = CmbFac.Items.Item(8) Or (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                            For i As Integer = 1 To 2
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 4
                                SendKeys.Send("+{TAB}")
                            Next
                        End If
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

    Private Sub DGV1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.GotFocus
        'Dim myCulture As New Globalization.CultureInfo("en-us")
        'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
    End Sub
    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If LEdit.Text = "1" And LState.Text = "3" And ListKasri.Length > 0 Then
                        For i As Integer = 0 To ListKasri.Length - 1
                            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value = ListKasri(i).IdKala And CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value) = ListKasri(i).Fe Then
                                Exit Sub
                            End If
                        Next
                    End If
                    '//////////////////////////////////////////////////////////////////

                    If LEdit.Text <> "0" Then

                        If CmbFac.Text = CmbFac.Items(0) Or CmbFac.Text = CmbFac.Items(4) Then
                            If Not (DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then

                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value), CLng(DGV1.Item("Cln_OldAnbar", DGV1.CurrentRow.Index).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار است و قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    End If

                    '//////////////////////////////////////////////////////////////////

                    If CmbFac.Text = CmbFac.Items.Item(3) Then BtnKalaDiscount.Enabled = True
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                        DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
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

    Private Sub DGV1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.LostFocus
        'Dim myCulture As New Globalization.CultureInfo("fa-IR")
        'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
    End Sub

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        If LEdit.Text = "1" And LState.Text = "3" And ListKasri.Length > 0 Then
            For i As Integer = 0 To ListKasri.Length - 1
                If DGV1.Item("Cln_Code", e.RowIndex).Value = ListKasri(i).IdKala And CDbl(DGV1.Item("Cln_Fe", e.RowIndex).Value) = ListKasri(i).Fe Then
                    DGV1.Columns("Cln_Name").ReadOnly = True
                    DGV1.Columns("Cln_KolCount").ReadOnly = True
                    DGV1.Columns("Cln_JozCount").ReadOnly = True
                    DGV1.Columns("Cln_Fe").ReadOnly = True
                    DGV1.Columns("Cln_Darsad").ReadOnly = True
                    DGV1.Columns("Cln_Anbar").ReadOnly = True
                    DGV1.Columns("Cln_Disc").ReadOnly = True
                    Exit Sub
                End If
            Next
            DGV1.Columns("Cln_Name").ReadOnly = False
            DGV1.Columns("Cln_KolCount").ReadOnly = False
            DGV1.Columns("Cln_JozCount").ReadOnly = False
            DGV1.Columns("Cln_Fe").ReadOnly = False
            DGV1.Columns("Cln_Darsad").ReadOnly = False
            DGV1.Columns("Cln_Anbar").ReadOnly = False
            DGV1.Columns("Cln_Disc").ReadOnly = False
        End If
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
            CalculateMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using

        If ListKasri.Length <= 0 Then
            If CDbl(DGV1.Item("Cln_Darsad", e.RowIndex).Value) >= 100 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.SpringGreen
            Else
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Nothing
                DGV1.Rows(e.RowIndex).Cells("cln_type").Style.BackColor = Color.Gainsboro
                DGV1.Rows(e.RowIndex).Cells("Cln_Vahed").Style.BackColor = Color.Gainsboro
                DGV1.Rows(e.RowIndex).Cells("Cln_DarsadMon").Style.BackColor = Color.Gainsboro
                DGV1.Rows(e.RowIndex).Cells("cln_Money").Style.BackColor = Color.Gainsboro
            End If
        End If

        If DGV1.Item("Cln_DK", e.RowIndex).Value = False Then
            DGV1.Rows(e.RowIndex).Cells("Cln_JozCount").Style.BackColor = Color.Gainsboro
        Else
            DGV1.Rows(e.RowIndex).Cells("Cln_JozCount").Style.BackColor = Nothing
        End If
        If DGV1.Item("cln_type", e.RowIndex).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", e.RowIndex).Value = "خدمات" Then
            DGV1.Rows(e.RowIndex).Cells("Cln_Anbar").Style.BackColor = Color.Gainsboro
        Else
            DGV1.Rows(e.RowIndex).Cells("Cln_Anbar").Style.BackColor = Nothing
        End If
    End Sub

    Private Sub CmbFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbFac.KeyDown
        If CmbFac.DroppedDown = False Then
            CmbFac.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtDate.Focus()
        End If
    End Sub

    Private Sub CmbFac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFac.SelectedIndexChanged
        ChkFrosh.Visible = False
        TxtIdFactor.Visible = False
        BtnDiscount.Enabled = False
        BtnDiscount.Visible = False
        BtnSback.Enabled = False
        BtnSback.Visible = False
        BtnSCost.Enabled = False
        BtnSCost.Visible = False
        BtnKalaDiscount.Enabled = False
        BtnKalaDiscount.Visible = False
        Tooldiscount.Visible = False
        ToolSBack.Visible = False
        ToolSCost.Visible = False
        BtnServiceKala.Enabled = True
        BtnServiceKala.Visible = True
        Toolotherkala.Visible = True
        ToolKalaDiscount.Visible = False
        ChkPart.Checked = False
        TxtPart.Text = ""
        TxtIdPart.Text = ""
        TxtPart.Enabled = False
        If CmbFac.Text = CmbFac.Items.Item(6) Then
            BtnServiceKala.Enabled = False
            BtnServiceKala.Visible = False
            Toolotherkala.Visible = False
            ChkVisitor.Checked = False
            ChkVisitor.Enabled = False
            TxtVisitor.Enabled = False
            TxtName.Enabled = False
            TxtName.Clear()
            TxtIdPeople.Clear()
            LDisc.Text = ""
            DGV1.Columns("Cln_Darsad").ReadOnly = True
            DGV1.Columns("Cln_Darsad").DefaultCellStyle.BackColor = Color.Gainsboro
            DGV1.Columns("Cln_anbar").ReadOnly = False
            DGV1.Columns("Cln_anbar").DefaultCellStyle.BackColor = Nothing
            For i As Integer = 0 To DGV1.RowCount - 2
                DGV1.Item("Cln_Darsad", i).Value = 0
                DGV1.Item("Cln_DarsadMon", i).Value = 0
            Next
            TxtMonFac.Text = "0"
        Else
            If CmbFac.Text = CmbFac.Items.Item(8) Then
                DGV1.Columns("Cln_anbar").ReadOnly = True
                DGV1.Columns("Cln_anbar").DefaultCellStyle.BackColor = Color.Gainsboro
                For i As Integer = 0 To DGV1.RowCount - 1
                    DGV1.Item("Cln_anbar", i).Value = ""
                    DGV1.Item("Cln_CodeAnbar", i).Value = ""
                Next
            Else
                DGV1.Columns("Cln_anbar").ReadOnly = False
                DGV1.Columns("Cln_anbar").DefaultCellStyle.BackColor = Nothing
            End If
            If CmbFac.Text = CmbFac.Items.Item(3) Or CmbFac.Text = CmbFac.Items.Item(4) Or CmbFac.Text = CmbFac.Items.Item(5) Or CmbFac.Text = CmbFac.Items.Item(7) Then
                ChkVisitor.Enabled = True
            Else
                ChkVisitor.Enabled = False
                TxtVisitor.Enabled = False
            End If
            If CmbFac.Text = CmbFac.Items.Item(3) Then
                BtnDiscount.Enabled = True
                BtnKalaDiscount.Enabled = True
                BtnSCost.Enabled = True
                BtnDiscount.Visible = True
                BtnSCost.Visible = True
                Tooldiscount.Visible = True
                ToolSCost.Visible = True
                BtnKalaDiscount.Visible = True
                BtnSback.Enabled = False
                BtnSback.Visible = False
                ToolSBack.Visible = False
                ToolKalaDiscount.Visible = True
            ElseIf CmbFac.Text = CmbFac.Items.Item(4) Then
                BtnDiscount.Enabled = False
                BtnKalaDiscount.Enabled = False
                BtnDiscount.Visible = False
                Tooldiscount.Visible = False
                BtnSback.Enabled = True
                BtnSback.Visible = True
                ToolSBack.Visible = True
                ToolKalaDiscount.Visible = False
                ChkFrosh.Visible = True
                TxtIdFactor.Visible = True
            End If
            TxtName.Enabled = True
            BtnServiceKala.Enabled = True
            TxtName.Clear()
            TxtIdPeople.Clear()
            LDisc.Text = ""
            DGV1.Columns("Cln_Darsad").ReadOnly = False
            DGV1.Columns("Cln_Darsad").DefaultCellStyle.BackColor = Nothing
        End If

        If LEdit.Text = "0" Then
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnSave.Enabled = False
                Else
                    BtnSave.Enabled = True
                    If CmbFac.Text = CmbFac.Items.Item(0) And Access_Form.Substring(3, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(1) And Access_Form.Substring(4, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(2) And Access_Form.Substring(5, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(3) And Access_Form.Substring(6, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(4) And Access_Form.Substring(7, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(5) And Access_Form.Substring(8, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(6) And Access_Form.Substring(9, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(7) And Access_Form.Substring(10, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(8) And Access_Form.Substring(11, 1) = 0 Then BtnSave.Enabled = False
                End If
            End If
        End If

        Me.CheckLimit()
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If TxtName.Enabled = True Then
            If e.KeyCode = Keys.Enter Then TxtName.Focus()
        Else
            If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
        End If
    End Sub

    Private Sub TxtPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPart.KeyDown
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChkPart.Focus()
        End If
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then
            DGV1.Focus()
        End If
    End Sub

    Private Sub FrmFactor_Barcode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' DGV1.Focus()
    End Sub

    Private Sub FrmFactor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DGV1.RowCount > 1 And LEdit.Text = "0" Then
            If MessageBox.Show("کالاهای وارد شده ثبت نشده است آیا برای خروج مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub FrmFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Rate = 0
        q = False
        Array.Resize(ListKasri, 0)
        If LEdit.Text = "0" Then
            Access_Form = Get_Access_Form("F39")
            If (Access_Form <> "-1") Then

                If String.IsNullOrEmpty(Access_Form) Then
                    MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                        MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Me.Close()
                    End If
                End If

            End If
            TxtDate.ThisText = GetDate()
            TxtName.Text = ""
            TxtVisitor.Enabled = False
            Me.GetLastCustomer()
        Else
            Me.ShowKalafactor()
        End If
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If LEdit.Text = "0" Then
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnSave.Enabled = False
                Else
                    BtnSave.Enabled = True
                    If CmbFac.Text = CmbFac.Items.Item(0) And Access_Form.Substring(3, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(1) And Access_Form.Substring(4, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(2) And Access_Form.Substring(5, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(3) And Access_Form.Substring(6, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(4) And Access_Form.Substring(7, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(5) And Access_Form.Substring(8, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(6) And Access_Form.Substring(9, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(7) And Access_Form.Substring(10, 1) = 0 Then BtnSave.Enabled = False
                    If CmbFac.Text = CmbFac.Items.Item(8) And Access_Form.Substring(11, 1) = 0 Then BtnSave.Enabled = False
                End If
            End If
        End If

        If LEdit.Text = "1" And LState.Text = "3" And ListKasri.Length > 0 Then
            For i As Integer = 0 To ListKasri.Length - 1
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_Code", j).Value = ListKasri(i).IdKala And CDbl(DGV1.Item("Cln_Fe", j).Value) = ListKasri(i).Fe Then
                        DGV1.Rows(j).DefaultCellStyle.BackColor = Color.LightGray
                    End If
                Next
            Next
            TxtName.Enabled = False
        End If
        Me.AreKalaDup()
        Mojody = AreShowMojody()
        LimitMojody()
        Me.CheckLimit()
    End Sub
    Private Sub GetLastCustomer()
        Try

            Dim Dataret As New DataTable
            Dataret.Clear()
            Using dbDA As New System.Data.SqlClient.SqlDataAdapter("SELECT TOP 1 Define_People.IdCity,Define_People.Nam, ListFactorSell.IdName,ListFactorSell.IdFactor FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID ORDER BY IdFactor DESC", DataSource)
                dbDA.Fill(Dataret)
            End Using
            If Dataret.Rows.Count > 0 Then
                TxtName.Text = Dataret.Rows(0).Item("Nam")
                TxtIdPeople.Text = Dataret.Rows(0).Item("IdName")
                TxtIdCityFac.Text = Dataret.Rows(0).Item("IdCity")
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "GetLastCustomer")
        End Try
    End Sub
    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        If CmbFac.Text = CmbFac.Items.Item(0) Or CmbFac.Text = CmbFac.Items.Item(1) Or CmbFac.Text = CmbFac.Items.Item(2) Then
            frmlk.Condition = " AND Seller=N'TRUE'"
        ElseIf CmbFac.Text = CmbFac.Items.Item(3) Or CmbFac.Text = CmbFac.Items.Item(4) Or CmbFac.Text = CmbFac.Items.Item(5) Or CmbFac.Text = CmbFac.Items.Item(7) Then
            frmlk.Condition = " AND Buyer=N'TRUE'"
        End If
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            TxtName.Text = Tmp_Namkala
            TxtIdPeople.Text = IdKala
            TxtIdCityFac.Text = Tmp_String2
            TxtCity.Text = Tmp_OneGroup + " - " + Tmp_TwoGroup
            LDisc.Text = If(String.IsNullOrEmpty(TmpTell1) And String.IsNullOrEmpty(TmpTell2), "", "تلفن:" & TmpTell1 & "  " & TmpTell2) & If(String.IsNullOrEmpty(TmpAddress), "", "  آدرس:" & TmpAddress)
            If CmbFac.Text = CmbFac.Items.Item(3) Or CmbFac.Text = CmbFac.Items.Item(4) Or CmbFac.Text = CmbFac.Items.Item(5) Or CmbFac.Text = CmbFac.Items.Item(7) Then Me.GetInfoVisitor(IdKala)
        Else
            TxtName.Text = ""
            TxtIdPeople.Text = ""
            LDisc.Text = ""
            TxtIdCityFac.Text = ""
        End If
    End Sub

    Private Sub GetInfoVisitor(ByVal idp As Long)
        Try
            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT IdVisitor,Nam FROM (SELECT TOP 1 IdVisitor FROM ListFactorSell WHERE IdName =" & idp & " AND IdVisitor IS NOT NULL ORDER BY IdFactor DESC) AS EndList INNER JOIN Define_Visitor ON Define_Visitor .Id =EndList.IdVisitor ", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using

            If dt.Rows.Count > 0 Then
                ChkVisitor.Checked = True
                TxtVisitor.Text = dt.Rows(0).Item("Nam")
                TxtIdVisitor.Text = dt.Rows(0).Item("IdVisitor")
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "GetInfoVisitor")
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            If CmbFac.Text = CmbFac.Items.Item(0) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Factor_buy.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(1) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BackBuy.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(2) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BuyAmani.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(3) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Factor_Sell.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(4) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BackFrosh.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(5) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "FroshAmani.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(6) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Zaye.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(7) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PishFactor.htm")
            ElseIf CmbFac.Text = CmbFac.Items.Item(8) Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KhadamatFAct.htm")
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then Call BtnCancle_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnServiceKala.Enabled = True Then Call BtnServiceKala_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnSelectKala.Enabled = True Then Call BtnSelectKala_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If CmbFac.Text = CmbFac.Items(6) Then
                MessageBox.Show("سابقه کالا به طرف حساب در فاکتور ضایعات قابل استفاده نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("هیچ طرف حسابی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FileCustomer
                FCustomer.LState.Text = GetStateFactor(CmbFac.Text)
                FCustomer.Lidname.Text = CLng(TxtIdPeople.Text)
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.CmbFac.Text = CmbFac.Text
                If CmbFac.Text = CmbFac.Items(8) Or (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                    FCustomer.LKala.Text = "SERVICE"
                    FCustomer.CmbFac.Enabled = False
                End If
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F7 Then
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FileAllCustomer
                FCustomer.LState.Text = GetStateFactor(CmbFac.Text)
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.CmbFac.Text = If(CmbFac.Text = CmbFac.Items(6), "خرید", CmbFac.Text)
                If CmbFac.Text = CmbFac.Items(8) Or (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                    FCustomer.LKala.Text = "SERVICE"
                    FCustomer.CmbFac.Enabled = False
                End If
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F8 Then
            If CmbFac.Text = CmbFac.Items(6) Then
                MessageBox.Show("رابطه قیمت کالا در شهرستان در فاکتور ضایعات قابل استفاده نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Or String.IsNullOrEmpty(TxtIdCityFac.Text.Trim) Then
                MessageBox.Show("هیچ طرف حسابی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                MessageBox.Show("کالای خدماتی جهت گزارش رابطه قیمت کالا در شهرستان مجاز نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FrmKalaCostRelation
                FCustomer.LCity.Text = TxtCity.Text
                FCustomer.LIdCity.Text = TxtIdCityFac.Text
                FCustomer.LKala.Text = DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value & "-" & DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value
                FCustomer.LIdKala.Text = DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F9 Then
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش قیمت تمام شده کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش قیمت تمام شده کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش قیمت تمام شده کالاانتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FrmEndCostKala
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F10 Then
            If BtnDiscount.Enabled = True And BtnDiscount.Visible = True Then Call BtnDiscount_Click(Nothing, Nothing)
            If BtnSback.Enabled = True And BtnSback.Visible = True Then Call BtnSback_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            If BtnKalaDiscount.Enabled = True And BtnKalaDiscount.Visible = True Then Call BtnKalaDiscount_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F12 Then
            If BtnSCost.Enabled = True And BtnSCost.Visible = True Then Call BtnSCost_Click(Nothing, Nothing)
        End If
    End Sub
    Private Function OkEnd() As Boolean
        Try
            Using Cmd As New SqlCommand("SELECT DK FROM Define_Kala WHERE Id=@ID", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                        If CBool(Cmd.ExecuteScalar()) <> CBool(DGV1.Item("Cln_DK", i).Value) Then
                            DGV1.Item("Cln_Name", i).Selected = True
                            Return False
                        End If
                        Cmd.Parameters.Clear()
                    End If
                Next i
                Return True
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "OkEnd")
            Return False
        End Try
    End Function
    Private Sub SaveOperation()
        Try
            CalculateAllRowMoney()
            Me.Enabled = False
            If CmbFac.Text = CmbFac.Items.Item(0) Or CmbFac.Text = CmbFac.Items.Item(2) Then
                If Not ValidBuy() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Using FrmPay As New PayFactor_Buy_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    Dim IdFac As Long = Me.SaveFactor(If(CmbFac.Text = CmbFac.Items.Item(0), 0, 2))
                    If IdFac = -1 Then
                        Me.Enabled = True
                        Exit Sub
                    End If
                    Idfactor = IdFac
                    Tmp_String1 = TxtDate.ThisText

                    Rate = RasKalaFac("K", CLng(TxtIdPeople.Text), GetIdGroup(CLng(TxtIdPeople.Text)))
                    state = If(CmbFac.Text = CmbFac.Items.Item(0), 0, 2)
                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = 0
                    FrmPay.TxtLend.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LIdFac.Text = IdFac
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.LState.Text = If(CmbFac.Text = CmbFac.Items.Item(0), 0, 2)
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtSellChk.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.LEdit.Text = "0"
                    FrmPay.ShowDialog()
                    If FrmPay.LOk.Text = "0" Then
                        RoolBackFactor(IdFac, If(CmbFac.Text = CmbFac.Items.Item(0), 0, 2))
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), If(CmbFac.Text = CmbFac.Items.Item(0), "فاکتور خرید", "فاکتور خرید امانی"), "انصراف", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")
                        Me.Enabled = True
                        Exit Sub
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), If(CmbFac.Text = CmbFac.Items.Item(0), "فاکتور خرید", "فاکتور خرید امانی"), "ثبت", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                    If FrmPay.ChkFactor.Checked = True Then
                        Factor()
                    End If
                    If FrmPay.ChkResid.Checked = True Then
                        ResedAnbar()
                    End If
                    'TxtName.Clear()
                    'TxtIdPeople.Clear()
                    'ChkVisitor.Checked = False
                    'TxtVisitor.Clear()
                    'TxtIdVisitor.Clear()
                    ChkPart.Checked = False
                    TxtIdPart.Clear()
                    TxtPart.Clear()
                    TxtSanad.Clear()
                    Me.EmptyGridKala()
                    Txtallmoney.Text = "0"
                    TxtMonFac.Text = "0"
                    LDisc.Text = ""
                    TxtDisc.Clear()
                    MessageBox.Show("فاکتور " & If(CmbFac.Text = CmbFac.Items.Item(0), " خرید ", " خرید امانی ") & "به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtName.Focus()
                End Using
            ElseIf CmbFac.Text = CmbFac.Items.Item(1) Or CmbFac.Text = CmbFac.Items.Item(3) Or CmbFac.Text = CmbFac.Items.Item(5) Then
                If Not ValidSell() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                ''''''''''''''''''''''''''''''

                If CmbFac.Text = CmbFac.Items.Item(3) And SCost = True And AreQustionForSCost() Then
                    If MessageBox.Show("آیا میخواهید قیمت ویژه به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Call BtnSCost_Click(Nothing, Nothing)
                        DGV1.EndEdit()
                    End If
                End If

                If CmbFac.Text = CmbFac.Items.Item(3) And q = True And AreQustionForDiscount() Then
                    If MessageBox.Show("آیا میخواهید تخفیف حجمی به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Call BtnDiscount_Click(Nothing, Nothing)
                        DGV1.EndEdit()
                    End If
                End If

                If CmbFac.Text = CmbFac.Items.Item(3) And dkALA = True And AreQustionForDiscountKala() Then
                    If MessageBox.Show("آیا میخواهید جایزه به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Call BtnKalaDiscount_Click(Nothing, Nothing)
                        DGV1.EndEdit()
                    End If
                End If

                Me.CalculateAllRowMoney()

                ''''''''''''''''''''''''''''''
                Using FrmPay As New PayFactor_Sell_Amani

                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    Dim state1 As Long = 0
                    If CmbFac.Text = CmbFac.Items.Item(1) Then
                        state1 = 1
                    ElseIf CmbFac.Text = CmbFac.Items.Item(3) Then
                        state1 = 3
                    ElseIf CmbFac.Text = CmbFac.Items.Item(5) Then
                        state1 = 5
                    End If
                    Dim IdFac As Long = Me.SaveFactor(state1)
                    If IdFac = -1 Then
                        Me.Enabled = True
                        Exit Sub
                    End If
                    Idfactor = IdFac
                    Tmp_String1 = TxtDate.ThisText

                    If state1 = 3 Or state1 = 5 Then Rate = RasKalaFac("F", CLng(TxtIdPeople.Text), GetIdGroup(CLng(TxtIdPeople.Text)))

                    If CmbFac.Text = CmbFac.Items.Item(1) Then
                        state = 1
                    ElseIf CmbFac.Text = CmbFac.Items.Item(3) Then
                        state = 3
                    ElseIf CmbFac.Text = CmbFac.Items.Item(5) Then
                        state = 5
                    End If
                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = 0
                    FrmPay.TxtLend.Text = 0 'CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LIdFac.Text = IdFac
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.LState.Text = state
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.LEdit.Text = "0"
                    If CmbFac.Text = CmbFac.Items.Item(3) Then FrmPay.ChkFish.Checked = Fish
                    FrmPay.ShowDialog()
                    lend = CDbl(FrmPay.TxtLend.Text)

                    Dim str As String = ""
                    If state = 1 Then
                        str = "برگشت از خرید"
                    ElseIf state = 3 Then
                        str = "فروش"
                    ElseIf state = 5 Then
                        str = "فروش امانی"
                    End If

                    If FrmPay.LOk.Text = "0" Then
                        RoolBackFactor(IdFac, state)
                        If state = 1 Then
                            str = "برگشت از خرید"
                        ElseIf state = 3 Then
                            str = "فروش"
                        ElseIf state = 5 Then
                            str = "فروش امانی"
                        End If
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), " فاکتور " & str, "انصراف", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")
                        Me.Enabled = True
                        Exit Sub
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), " فاکتور " & str, "ثبت", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                    If FrmPay.ChkFactor.Checked = True Then
                        Factor()
                    End If
                    If FrmPay.ChkResid.Checked = True Then
                        ResedAnbar()
                    End If
                    If FrmPay.ChkFish.Checked = True Then
                        FactorFish()
                    End If
                    'TxtName.Clear()
                    'TxtIdPeople.Clear()
                    'ChkVisitor.Checked = False
                    'TxtVisitor.Clear()
                    'TxtIdVisitor.Clear()
                    ChkPart.Checked = False
                    TxtIdPart.Clear()
                    TxtPart.Clear()
                    TxtSanad.Clear()
                    TxtDisc.Clear()
                    Me.EmptyGridKala()
                    Txtallmoney.Text = "0"
                    TxtMonFac.Text = "0"
                    LDisc.Text = ""
                    Dim strfac As String = ""
                    If state = 1 Then
                        strfac = "برگشت از خرید"
                    ElseIf state = 3 Then
                        strfac = "فروش"
                    ElseIf state = 5 Then
                        strfac = "فروش امانی"
                    End If

                    ' MessageBox.Show("فاکتور " & strfac & " به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("cln_name", 0).Selected = True
                End Using

            ElseIf CmbFac.Text = CmbFac.Items.Item(4) Then
                If Not ValidBuy() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Using FrmPay As New PayFactor_Buy_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    Dim IdFac As Long = Me.SaveFactor(4)
                    If IdFac = -1 Then
                        Me.Enabled = True
                        Exit Sub
                    End If
                    Idfactor = IdFac
                    Tmp_String1 = TxtDate.ThisText

                    state = 4
                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = 0
                    FrmPay.TxtLend.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtEndMon.Text =CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LIdFac.Text = IdFac
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.LState.Text = 4
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtSellChk.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.LEdit.Text = "0"
                    FrmPay.ShowDialog()
                    lend = CDbl(FrmPay.TxtLend.Text)
                    If FrmPay.LOk.Text = "0" Then
                        RoolBackFactor(IdFac, 4)
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فاکتور برگشت از فروش", "انصراف", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")
                        Me.Enabled = True
                        Exit Sub
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فاکتور برگشت از فروش", "ثبت", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                    If FrmPay.ChkFactor.Checked = True Then
                        Factor()
                    End If
                    If FrmPay.ChkResid.Checked = True Then
                        ResedAnbar()
                    End If
                    'TxtName.Clear()
                    'TxtIdPeople.Clear()
                    'ChkVisitor.Checked = False
                    'TxtVisitor.Clear()
                    'TxtIdVisitor.Clear()
                    ChkPart.Checked = False
                    ChkFrosh.Checked = False
                    TxtIdPart.Clear()
                    TxtPart.Clear()
                    TxtSanad.Clear()
                    Me.EmptyGridKala()
                    Txtallmoney.Text = "0"
                    TxtMonFac.Text = "0"
                    LDisc.Text = ""
                    TxtDisc.Clear()
                    MessageBox.Show("فاکتور برگشت از فروش به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtName.Focus()
                End Using
            ElseIf CmbFac.Text = CmbFac.Items.Item(6) Then
                If Not ValidDamage() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Dim IdFac As Long = Me.SaveFactor(6)
                If IdFac = -1 Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Idfactor = IdFac
                Tmp_String1 = TxtDate.ThisText

                state = 6

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فاکتور ضایعات ", "ثبت", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                'TxtName.Clear()
                'TxtIdPeople.Clear()
                'ChkVisitor.Checked = False
                'TxtVisitor.Clear()
                'TxtIdVisitor.Clear()
                ChkPart.Checked = False
                TxtIdPart.Clear()
                TxtPart.Clear()
                TxtSanad.Clear()
                TxtDisc.Clear()
                Me.EmptyGridKala()
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                LDisc.Text = ""

                MessageBox.Show("فاکتور ضایعات به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf CmbFac.Text = CmbFac.Items.Item(7) Then
                If Not ValidSell() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Dim IdFac As Long = Me.SaveFactor(7)
                If IdFac = -1 Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Idfactor = IdFac
                Tmp_String1 = TxtDate.ThisText

                state = 7
                If MessageBox.Show("آیا میخواهید پیش فاکتور مورد نظر را چاپ کنید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Factor()
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "پیش فاکتور فروش", "ثبت", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                'TxtName.Clear()
                'TxtIdPeople.Clear()
                'ChkVisitor.Checked = False
                'TxtVisitor.Clear()
                'TxtIdVisitor.Clear()
                ChkPart.Checked = False
                TxtIdPart.Clear()
                TxtPart.Clear()
                TxtSanad.Clear()
                Me.EmptyGridKala()
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                LDisc.Text = ""
                TxtDisc.Clear()

                MessageBox.Show("پیش فاکتور فروش به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
            ElseIf CmbFac.Text = CmbFac.Items.Item(8) Then
                If Not ValidService() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Using FrmPay As New PayFactor_Sell_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    Dim IdFac As Long = Me.SaveFactor(8)
                    If IdFac = -1 Then
                        Me.Enabled = True
                        Exit Sub
                    End If
                    Idfactor = IdFac
                    Tmp_String1 = TxtDate.ThisText

                    state = 8
                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = 0
                    FrmPay.TxtLend.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LIdFac.Text = IdFac
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.LState.Text = 8
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.LEdit.Text = "0"
                    FrmPay.ShowDialog()
                    If FrmPay.LOk.Text = "0" Then
                        RoolBackFactor(IdFac, 8)
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فاکتور خدمات", "انصراف", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")
                        Me.Enabled = True
                        Exit Sub
                    End If
                    lend = CDbl(FrmPay.TxtLend.Text)

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فاکتور خدمات", "ثبت", " شماره فاکتور: " & IdFac & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")
                    If FrmPay.ChkFactor.Checked = True Then
                        Factor()
                    End If
                    If FrmPay.ChkResid.Checked = True Then
                        ResedAnbar()
                    End If
                    If FrmPay.ChkFish.Checked = True Then
                        FactorFish()
                    End If
                    'TxtName.Clear()
                    'TxtIdPeople.Clear()
                    'ChkVisitor.Checked = False
                    'TxtVisitor.Clear()
                    'TxtIdVisitor.Clear()
                    ChkPart.Checked = False
                    TxtIdPart.Clear()
                    TxtPart.Clear()
                    TxtSanad.Clear()
                    Me.EmptyGridKala()
                    Txtallmoney.Text = "0"
                    TxtMonFac.Text = "0"
                    LDisc.Text = ""
                    TxtDisc.Clear()
                    MessageBox.Show("فاکتور خدمات به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtName.Focus()
                End Using
            End If
            Me.Enabled = True
            Application.DoEvents()
            'SendKeys.Send("{ENTER}")
            ' TxtName.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "SaveOperation")
            Me.Enabled = True
        End Try
    End Sub

    Private Function SetKalaFacArray() As Boolean
        Try
            Array.Resize(FactorArray, 0)
            Array.Resize(FactorArray, DGV1.RowCount - 1)
            For i As Integer = 0 To DGV1.RowCount - 2
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then
                    FactorArray(i).IdService = CLng(DGV1.Item("Cln_Code", i).Value)
                    FactorArray(i).IdKala = 0
                    FactorArray(i).CodeAnbar = 0
                Else
                    FactorArray(i).IdService = 0
                    FactorArray(i).IdKala = CLng(DGV1.Item("Cln_Code", i).Value)
                    FactorArray(i).CodeAnbar = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                End If
                FactorArray(i).KolCount = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                FactorArray(i).JozCount = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                FactorArray(i).Fe = CDbl(DGV1.Item("Cln_Fe", i).Value)
                FactorArray(i).DarsadDiscount = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                FactorArray(i).DarsadMon = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                FactorArray(i).Mon = CDbl(DGV1.Item("cln_Money", i).Value)
                FactorArray(i).Disc = If(DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value), "", DGV1.Item("Cln_Disc", i).Value)
                FactorArray(i).DK = CBool(DGV1.Item("Cln_DK", i).Value)
                FactorArray(i).DK_KOL = CDbl(DGV1.Item("Cln_KOL", i).Value)
                FactorArray(i).DK_JOZ = CDbl(DGV1.Item("Cln_JOZ", i).Value)
            Next
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "SetKalaFacArray")
            Return False
        End Try
    End Function
    Private Function SetInfoFacArray() As Boolean
        Try
            Array.Resize(InfoFactorArray, 0)
            Array.Resize(InfoFactorArray, 1)
            InfoFactorArray(0).D_date = TxtDate.ThisText
            InfoFactorArray(0).IdName = If(String.IsNullOrEmpty(TxtIdPeople.Text), 0, CLng(TxtIdPeople.Text))
            InfoFactorArray(0).IdVisitor = If(ChkVisitor.Checked = False, 0, CLng(TxtIdVisitor.Text))
            InfoFactorArray(0).IdPart = If(ChkPart.Checked = False, 0, CLng(TxtIdPart.Text))
            InfoFactorArray(0).Sanad = TxtSanad.Text
            InfoFactorArray(0).Disc = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text)
            If ChkFrosh.Visible = True And ChkFrosh.Checked = True Then
                InfoFactorArray(0).IdFactor = TxtIdFactor.Text
            Else
                InfoFactorArray(0).IdFactor = 0
            End If
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "SetInfoFacArray")
            Return False
        End Try
    End Function

    Private Function RasKalaFac(ByVal Kind As String, ByVal IdP As Long, ByVal IdG As Long) As Long
        Try
            Dim str(DGV1.RowCount - 2) As String
            Dim Query As String = ""
            Dim Rate As Long = 0


            For i As Integer = 0 To DGV1.RowCount - 2
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then
                    If Kind = "F" Then
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT Rate FROM  Define_ListKalaRate WHERE IdKalaLink =0 AND IdGroup =0) AS ListRate"
                    Else
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT BRate AS Rate FROM  Define_KalaRate WHERE IdKala =0) AS ListRate"
                    End If
                Else
                    If Kind = "F" Then
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT Rate FROM  Define_ListKalaRate WHERE IdKalaLink =" & CLng(DGV1.Item("Cln_Code", i).Value) & " AND IdGroup =" & IdG & ") AS ListRate"
                    Else
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT BRate AS Rate FROM  Define_KalaRate WHERE IdKala =" & CLng(DGV1.Item("Cln_Code", i).Value) & ") AS ListRate"
                    End If
                End If
            Next
            Query = "SELECT ISNULL(SUM(AllMon),0)/ISNULL(SUM(Mon),0) AS Rate FROM("
            For i As Integer = 0 To str.Length - 1
                Query &= str(i) & " UNION ALL "
            Next


            Query = Query.Substring(0, Query.Length - 12) & " ) AS ListMon "


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Query, ConectionBank)
                Rate = cmd.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return Rate
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "RasKalaFac")
            Return 0
        End Try
    End Function

    Private Sub EditOperation()
        Me.Enabled = False
        CalculateAllRowMoney()
        If LState.Text <> "6" And LState.Text <> "7" Then

            If LState.Text = "0" Or LState.Text = "2" Then
                If Not ValidBuy() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                If Not (SetKalaFacArray() And SetInfoFacArray()) Then Exit Sub
                Rate = RasKalaFac("K", CLng(TxtIdPeople.Text), GetIdGroup(CLng(TxtIdPeople.Text)))
                Using FrmPay As New PayFactor_Buy_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = Txtallmoney.Text.Trim
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LIdFac.Text = CLng(LIdFac.Text)
                    FrmPay.LState.Text = CLng(LState.Text)
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtSellChk.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.TxtLend.Text = "0"
                    FrmPay.LEdit.Text = "1"
                    FrmPay.ShowDialog()
                    If FrmPay.LOk.Text = "0" Then
                        Me.Enabled = True
                        Exit Sub
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ویرایش فاکتور", "  فاکتور " & If(LState.Text = "0", "خرید", "خرید امانی") & ": " & CLng(LIdFac.Text) & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                    Me.Close()
                End Using
            ElseIf LState.Text = "1" Or LState.Text = "3" Or LState.Text = "5" Then
                If Not ValidSell() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                ''''''''''''''''''''''''''''''
                If CmbFac.Text = CmbFac.Items.Item(3) And SCost = True And AreQustionForSCost() Then
                    If MessageBox.Show("آیا میخواهید قیمت ویژه به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Call BtnSCost_Click(Nothing, Nothing)
                        DGV1.EndEdit()
                    End If
                End If

                If CmbFac.Text = CmbFac.Items.Item(3) And q = True And AreQustionForDiscount() Then
                    If MessageBox.Show("آیا میخواهید تخفیف حجمی به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Call BtnDiscount_Click(Nothing, Nothing)
                        DGV1.EndEdit()
                    End If
                End If

                If CmbFac.Text = CmbFac.Items.Item(3) And dkALA = True And AreQustionForDiscountKala() Then
                    If MessageBox.Show("آیا میخواهید جایزه به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Call BtnKalaDiscount_Click(Nothing, Nothing)
                        DGV1.EndEdit()
                    End If
                End If
                ''''''''''''''''''''''''''''''

                If Not (SetKalaFacArray() And SetInfoFacArray()) Then Exit Sub
                If LState.Text = "3" Or LState.Text = "5" Then Rate = RasKalaFac("F", CLng(TxtIdPeople.Text), GetIdGroup(CLng(TxtIdPeople.Text)))
                Using FrmPay As New PayFactor_Sell_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = Txtallmoney.Text.Trim
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LIdFac.Text = CLng(LIdFac.Text)
                    FrmPay.LState.Text = CLng(LState.Text)
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.TxtLend.Text = "0"
                    FrmPay.LEdit.Text = "1"
                    FrmPay.ShowDialog()
                    If FrmPay.LOk.Text = "0" Then
                        Me.Enabled = True
                        Exit Sub
                    End If

                    Dim str As String = ""

                    If LState.Text = "1" Then
                        str = "برگشت از خرید"
                    ElseIf LState.Text = "3" Then
                        str = "فروش"
                    ElseIf LState.Text = "5" Then
                        str = "فروش امانی"
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ویرایش فاکتور", "  فاکتور " & str & ": " & CLng(LIdFac.Text) & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                    Me.Close()
                End Using
            ElseIf LState.Text = "4" Then
                If Not ValidBuy() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                If Not (SetKalaFacArray() And SetInfoFacArray()) Then Exit Sub
                Using FrmPay As New PayFactor_Buy_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = Txtallmoney.Text.Trim
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LIdFac.Text = CLng(LIdFac.Text)
                    FrmPay.LState.Text = CLng(LState.Text)
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtSellChk.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.TxtLend.Text = "0"
                    FrmPay.LEdit.Text = "1"
                    FrmPay.ShowDialog()
                    If FrmPay.LOk.Text = "0" Then
                        Me.Enabled = True
                        Exit Sub
                    End If
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ویرایش فاکتور", " فاکتور برگشت از فروش : " & CLng(LIdFac.Text) & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")
                    Me.Close()
                End Using
            ElseIf LState.Text = "8" Then
                If Not ValidService() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                If Not (SetKalaFacArray() And SetInfoFacArray()) Then Exit Sub
                Using FrmPay As New PayFactor_Sell_Amani
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = Txtallmoney.Text.Trim
                    FrmPay.TxtEndMon.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LIdFac.Text = CLng(LIdFac.Text)
                    FrmPay.LState.Text = CLng(LState.Text)
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.TxtLend.Text = "0"
                    FrmPay.LEdit.Text = "1"
                    FrmPay.ShowDialog()
                    If FrmPay.LOk.Text = "0" Then
                        Me.Enabled = True
                        Exit Sub
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ویرایش فاکتور", " فاکتور خدمات : " & CLng(LIdFac.Text) & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

                    Me.Close()
                End Using
            End If
        ElseIf LState.Text = "6" Then
            If Not ValidDamage() Then
                Me.Enabled = True
                Exit Sub
            End If
            If Me.EditFactor(6) = False Then
                Me.Enabled = True
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ویرایش فاکتور", " فاکتور ضایعات : " & CLng(LIdFac.Text) & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

            Me.Close()
        ElseIf LState.Text = "7" Then
            If Not ValidSell() Then
                Me.Enabled = True
                Exit Sub
            End If
            If Me.EditFactor(7) = False Then
                Me.Enabled = True
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ویرایش فاکتور", " پیش فاکتور : " & CLng(LIdFac.Text) & " تعداد اقلام کالا: " & DGV1.RowCount - 1 & " جمع کل فاکتور: " & Txtallmoney.Text, "")

            Me.Close()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If S32 = False And CmbFac.Text = CmbFac.Items.Item(3) Then
            If (GetMoeinPeople(CLng(TxtIdPeople.Text))) > 0 Then
                MessageBox.Show("کاربر گرامی اجازه صدور فاکتور برای مشتریانی بدهکار وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        BtnSave.Focus()
        DGV1.EndEdit()

        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Or TxtDate.ThisText > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        If BtnDiscount.Enabled = True Then
            q = True
        Else
            q = False
        End If

        If BtnSCost.Enabled = True Then
            SCost = True
        Else
            SCost = False
        End If

        If BtnKalaDiscount.Enabled = True Then
            dkALA = True
        Else
            dkALA = False
        End If

        DiscFactor = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", " " & TxtDisc.Text.Trim)
        If LEdit.Text = "0" Then
            Me.SaveOperation()
        ElseIf LEdit.Text = "1" Then
            Me.EditOperation()
        End If

        Me.CheckLimit()
    End Sub
    Private Function EditFactor(ByVal state As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim ListName As String = ""
        Dim KalaName As String = ""
        ListName = GetTableNameFactor(state, "LIST")
        KalaName = GetTableNameFactor(state, "KALA")
        Try
            If state = 7 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                Using Cmd As New SqlCommand("UPDATE " & ListName & " SET D_date=@D_date,IdName=@IdName,IdUser=@IdUser,Part=@Part,Sanad=@Sanad,IdVisitor=@IdVisitor WHERE IdFactor=" & CLng(LIdFac.Text), ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("DELETE FROM  " & KalaName & " WHERE IdFactor=@IdFactor", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2
                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            ElseIf state = 6 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////

                Using Cmd As New SqlCommand("UPDATE  " & ListName & " SET D_date=@D_date,Part=@Part,Sanad=@Sanad,IdUser=@IdUser,Disc=@Disc WHERE IdFactor=" & CLng(LIdFac.Text), ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("DELETE FROM  " & KalaName & " WHERE IdFactor=@IdFactor", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,KolCount,JozCount,Fe,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@KolCount,@JozCount,@Fe,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2
                        Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                        Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            End If
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فاکتور قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "EditFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function SaveFactor(ByVal state As Long) As Long
        Dim sqltransaction As New CommittableTransaction
        Dim IdFac As Long = 0
        Dim ListName As String = ""
        Dim KalaName As String = ""
        If state = 0 Or state = 2 Then
            ListName = "ListFactorBuy"
            KalaName = "KalaFactorBuy"
        ElseIf state = 1 Then
            ListName = "ListFactorBackBuy"
            KalaName = "KalaFactorBackBuy"
        ElseIf state = 3 Or state = 5 Or state = 7 Then
            ListName = "ListFactorSell"
            KalaName = "KalaFactorSell"
        ElseIf state = 4 Then
            ListName = "ListFactorBackSell"
            KalaName = "KalaFactorBackSell"
        ElseIf state = 6 Then
            ListName = "ListFactorDamage"
            KalaName = "KalaFactorDamage"
        ElseIf state = 8 Then
            ListName = "ListFactorService"
            KalaName = "KalaFactorService"
        End If
        Try
            If state = 0 Or state = 2 Or state = 4 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////
                Dim query As String = ""

                If state = 0 Or state = 2 Then
                    query = "INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,Stat,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonSellChk,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@Stat,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonSellChk,@MonPayChk,@EditFlag);SELECT @@IDENTITY"
                ElseIf state = 4 Then
                    query = "INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,Stat,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonSellChk,MonPayChk,EditFlag,IdFacSell) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@Stat,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonSellChk,@MonPayChk,@EditFlag,@IdFacSell);SELECT @@IDENTITY"
                End If

                Using Cmd As New SqlCommand(query, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = state
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 0
                    If state = 4 Then Cmd.Parameters.AddWithValue("@IdFacSell", SqlDbType.BigInt).Value = IIf(ChkFrosh.Checked = True, TxtIdFactor.Text, DBNull.Value)
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2

                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If

                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            ElseIf state = 3 Or state = 5 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////
                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,Stat,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@Stat,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonPayChk,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = state
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 0
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2

                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If

                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            ElseIf state = 1 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////
                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonPayChk,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 0
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2

                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If

                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            ElseIf state = 7 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////

                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,Stat,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@Stat,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonPayChk,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = state
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2

                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If

                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            ElseIf state = 6 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////

                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,Part,Sanad,IdUser,Disc,Activ,EditFlag) VALUES(@D_date,@Part,@Sanad,@IdUser,@Disc,@Activ,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,KolCount,JozCount,Fe,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@KolCount,@JozCount,@Fe,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2
                        Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                        Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            ElseIf state = 8 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////
                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonPayChk,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 0
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdService,KolCount,Fe,DarsadDiscount,DarsadMon,Mon,KalaDisc,Activ) VALUES(@IdFactor,@IdService,@KolCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2
                        Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            End If
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فاکتور قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "SaveFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function
    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Try
            If LEdit.Text = "0" Then
                If MessageBox.Show("آیا برای لغو فاکتور مورد نظر مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                TxtName.Clear()
                LDisc.Text = ""
                TxtIdPeople.Clear()
                ChkVisitor.Checked = False
                TxtVisitor.Clear()
                TxtIdVisitor.Clear()
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                ChkPart.Checked = False
                TxtPart.Clear()
                TxtIdPart.Clear()
                TxtSanad.Clear()
                Me.EmptyGridKala()
            Else
                MessageBox.Show("در حالت ویرایش فاکتور امکان لغو کل فاکتور امکانپذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
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
            DGV1.Item("Cln_Vahed", 0).Value = ""
            DGV1.Item("Cln_Fe", 0).Value = ""
            DGV1.Item("Cln_Darsad", 0).Value = ""
            DGV1.Item("Cln_DarsadMon", 0).Value = ""
            DGV1.Item("Cln_Anbar", 0).Value = ""
            DGV1.Item("Cln_Money", 0).Value = ""
            DGV1.Item("Cln_Disc", 0).Value = ""
            DGV1.Item("Cln_code", 0).Value = ""
            DGV1.Item("Cln_CodeAnbar", 0).Value = ""
            DGV1.Item("Cln_DK", 0).Value = False
            DGV1.Item("Cln_KOL", 0).Value = ""
            DGV1.Item("Cln_JOZ", 0).Value = ""
        End If
        Txtallmoney.Text = "0"
        TxtMonFac.Text = "0"
    End Sub
    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV1.CurrentCell.ColumnIndex = 8 Then
                    e.Handled = True
                    Exit Sub
                End If
                If CmbFac.Text = CmbFac.Items.Item(3) Then
                    BtnDiscount.Enabled = True
                    BtnSCost.Enabled = True
                    BtnKalaDiscount.Enabled = True
                End If
            End If
            If Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "" Then
                If DGV1.CurrentCell.ColumnIndex <> 1 Then
                    e.Handled = True
                    DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                    DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True

            If CmbFac.Text = CmbFac.Items.Item(3) Then
                BtnDiscount.Enabled = True
                BtnSCost.Enabled = True
                BtnKalaDiscount.Enabled = True
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

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            ''''''''''''گرفتن نام کالا
            If DGV1.CurrentCell.ColumnIndex = 1 Then
                If CmbFac.Text = CmbFac.Items.Item(8) Then
                    e.Handled = True
                    Dim frmlk As New Service_List
                    frmlk.BtnNewP.Enabled = True
                    frmlk.ShowDialog()
                    DGV1.Focus()
                    If Tmp_Namkala <> "" Then
                        DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی"
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                        DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                        DGV1.Item("Cln_vahed", DGV1.CurrentRow.Index).Value = "خدمات"
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = 0
                        DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = 0
                        DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = 0
                        DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                        DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = IdKala
                        DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                        DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = 1
                        DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = 1
                        DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Anbar").Style.BackColor = Color.Gainsboro
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Selected = True
                    End If
                    DGV1.RefreshEdit()
                    CalDarsad()
                    CalculateMoney()
                End If
            End If
            '''''''''''''''''''''''''''گرفتن نام انبار
            If DGV1.CurrentCell.ColumnIndex = 8 Then
                e.Handled = True
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then Exit Sub
                If DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات" Then Exit Sub
                If CmbFac.Text = CmbFac.Items.Item(8) Then Exit Sub
                Dim frmlk As New Anbar_Kala_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.LIdKala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                frmlk.Txtkala.Text = DGV1.Item("Cln_Type", DGV1.CurrentRow.Index).Value & " - " & DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value
                frmlk.ShowDialog()
                DGV1.Focus()
                If Tmp_Namkala <> "" Then
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                    DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = IdKala
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_disc", DGV1.CurrentRow.Index).Selected = True
                Else
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_disc", DGV1.CurrentRow.Index).Selected = True
                End If
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''کنترل فی
            If DGV1.CurrentCell.ColumnIndex = 5 Then
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
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزء
            If DGV1.CurrentCell.ColumnIndex = 3 Or DGV1.CurrentCell.ColumnIndex = 2 Or DGV1.CurrentCell.ColumnIndex = 6 Then
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
            If DGV1.CurrentCell.ColumnIndex = 10 Then
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
            If DGV1.CurrentCell.ColumnIndex <> 1 Then
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
            End If
            If DGV1.CurrentCell.ColumnIndex = 5 Then
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
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_KolCOUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value), "###,###")
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                If CmbFac.Text = CmbFac.Items.Item(3) Then BtnDiscount.Enabled = True
            ElseIf DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value) Then DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                    If DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                Try
                    If DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End Try
                If CmbFac.Text = CmbFac.Items.Item(3) Then
                    BtnDiscount.Enabled = True
                    BtnSCost.Enabled = True
                    BtnKalaDiscount.Enabled = True
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
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
                Try
                    If DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                    ' If DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End Try
                If CmbFac.Text = CmbFac.Items.Item(3) Then
                    BtnDiscount.Enabled = True
                    BtnSCost.Enabled = True
                    BtnKalaDiscount.Enabled = True
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 6 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) > 100 Then txt_dgv.Text = 100
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("cln_Money", DGV1.CurrentRow.Index).Value) * CDbl(txt_dgv.Text) / 100, "###,###")
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)

                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                If CmbFac.Text = CmbFac.Items.Item(3) Then BtnDiscount.Enabled = True
            ElseIf DGV1.CurrentCell.ColumnIndex = 8 Then
                If DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات" Then
                    txt_dgv.Clear()
                End If
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

    Private Sub ChkVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisitor.CheckedChanged
        If ChkVisitor.Checked = True Then
            TxtVisitor.Enabled = True
        Else
            TxtVisitor.Enabled = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub ChkVisitor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkVisitor.GotFocus
        ChkVisitor.BackColor = Color.LightGray
    End Sub

    Private Sub ChkVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ChkVisitor.Checked = False Then
                If ChkFrosh.Visible = True Then
                    ChkFrosh.Focus()
                Else
                    TxtSanad.Focus()
                End If
            Else
                TxtVisitor.Focus()
            End If
        End If
    End Sub

    Private Sub ChkVisitor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkVisitor.LostFocus
        ChkVisitor.BackColor = Me.BackColor
    End Sub

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then
            If ChkFrosh.Visible = True Then
                ChkFrosh.Focus()
            Else
                TxtSanad.Focus()
            End If
        End If
    End Sub

    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        If Tmp_Namkala <> "" Then
            TxtVisitor.Text = Tmp_Namkala
            TxtIdVisitor.Text = IdKala
        Else
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub BtnServiceKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnServiceKala.Click
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Try
            Dim frmlk As New Service_List
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.AllowUserToAddRows = False
                DGV1.Rows.Add()
                DGV1.Item("cln_type", DGV1.RowCount - 1).Value = "کالای خدماتی"
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = Tmp_Namkala
                DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_vahed", DGV1.RowCount - 1).Value = "خدمات"
                DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = ""
                DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = ""
                DGV1.Item("Cln_code", DGV1.RowCount - 1).Value = IdKala
                DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = False
                DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = 1
                DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = 1
                DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Anbar").Style.BackColor = Color.Gainsboro
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = False
                DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Selected = True
                DGV1.AllowUserToAddRows = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "BtnServiceKala_Click")
        End Try
    End Sub
    Private Function ValidBuy() As Boolean
        Try
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtName.Text.Trim) Or String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("طرف حساب را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText.Trim) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Return False
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Return False
            End If
            If CmbFac.Text = CmbFac.Items(4) Then
                If ChkFrosh.Checked = True And String.IsNullOrEmpty(TxtIdFactor.Text) Then
                    MessageBox.Show("شماره فاکتور فروش را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtIdFactor.Focus()
                    Return False
                End If
            End If

            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value < 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Return False
                    End If

                    If LEdit.Text = "0" Then
                        If CmbFac.Text = CmbFac.Items(1) Or CmbFac.Text = CmbFac.Items(3) Or CmbFac.Text = CmbFac.Items(6) Then
                            If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                If MAnbar = True Then
                                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                Else
                                    MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return False
                                End If
                            End If
                        End If
                    Else
                        If CmbFac.Text = CmbFac.Items(1) Or CmbFac.Text = CmbFac.Items(3) Or CmbFac.Text = CmbFac.Items(6) Then
                            If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", i).Value Is DBNull.Value) Then
                                If CLng(DGV1.Item("Cln_OldAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value) - CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value) - CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                Else
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If CmbFac.Text = CmbFac.Items(0) Or CmbFac.Text = CmbFac.Items(4) Then
                        If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", i).Value Is DBNull.Value) Then
                            If CLng(DGV1.Item("Cln_OldAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value - CDbl(DGV1.Item("Cln_KolCount", i).Value)), CDbl(DGV1.Item("Cln_OldJoz", i).Value) - CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                ''''''''''''''''''''''''''''''''''''''''
                If CmbFac.Text = CmbFac.Items(4) Then
                    If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                        If Not AreYouBackKala(CLng(DGV1.Item("Cln_code", i).Value), CLng(TxtIdPeople.Text)) Then
                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " به طرف حساب مربوطه فروخته نشده است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                        End If
                    End If
                    If ChkFrosh.Checked = True And Not String.IsNullOrEmpty(TxtIdFactor.Text) Then
                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            If Not AreYouExistKalaInFactor(TxtIdFactor.Text, CLng(DGV1.Item("Cln_code", i).Value)) Then
                                MessageBox.Show("کالا در ردیف شماره " & "{" & i + 1 & "}" & "  در فاکتور فروش مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return False
                            End If
                        End If
                    End If
                End If
                ''''''''''''''''''''''''''''''''''''''''

                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If

                Next
                If count_Kala > 1 Then
                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
                If count_Service > 1 Then
                    If MessageBox.Show("کالای خدماتی سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
            Next
            If CmbFac.Text = CmbFac.Items(4) And ChkFrosh.Checked = True And Not String.IsNullOrEmpty(TxtIdFactor.Text) And LEdit.Text = "0" Then
                If Not AreYouBackFac(CLng(TxtIdFactor.Text)) Then
                    If MessageBox.Show("فاکتور برگشت مربوط به فروش مورد نظر قبلا ثبت شده است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
            End If

            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "ValidBuy")
            Return False
        End Try
    End Function
    Private Function AreYouBackFac(ByVal IdFac As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT COUNT(IdFacSell) FROM ListFactorBackSell WHERE  Activ =1 AND IdFacSell =" & IdFac, ConectionBank)
                If cmd.ExecuteScalar > 0 Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                End If
            End Using

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreYouBackFac")
            Return False
        End Try
    End Function
    Private Function ValidSell() As Boolean
        Try
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtName.Text.Trim) Or String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("طرف حساب را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Return False
            End If
            If ChkVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtVisitor.Text.Trim) Or String.IsNullOrEmpty(TxtIdVisitor.Text.Trim) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtVisitor.Focus()
                    Return False
                End If
            End If
            If ChkPart.Checked = True Then
                If String.IsNullOrEmpty(TxtPart.Text.Trim) Or String.IsNullOrEmpty(TxtIdPart.Text.Trim) Then
                    MessageBox.Show("پارت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPart.Focus()
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText.Trim) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Return False
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Return False
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value < 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Return False
                    End If
                    If (CDbl(DGV1.Item("Cln_Fe", i).Value) - (CDbl(DGV1.Item("Cln_DarsadMon", i).Value) / (If(CDbl(DGV1.Item("Cln_JozCount", i).Value) <= 0, CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value))))) < GetCostKalaWithDiscount(CLng(DGV1.Item("Cln_code", i).Value), (If(CDbl(DGV1.Item("Cln_JozCount", i).Value) <= 0, CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value))), (If(CDbl(DGV1.Item("Cln_JozCount", i).Value) <= 0, "KOL", "JOZ")), "", "", "True") Then
                        If MessageBox.Show("بهای فروش کالای سطر شماره" & i + 1 & " کمتر از بهای تمام شده است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                    End If

                    If LEdit.Text = "0" Then
                        If CmbFac.Text = CmbFac.Items(1) Or CmbFac.Text = CmbFac.Items(3) Or CmbFac.Text = CmbFac.Items(6) Then
                            If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                If MAnbar = True Then
                                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                Else
                                    MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return False
                                End If
                            End If
                        End If
                    Else
                        If CmbFac.Text = CmbFac.Items(1) Or CmbFac.Text = CmbFac.Items(3) Or CmbFac.Text = CmbFac.Items(6) Then
                            If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", i).Value Is DBNull.Value) Then
                                If CLng(DGV1.Item("Cln_OldAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value) - CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value) - CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                Else
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If CmbFac.Text = CmbFac.Items(0) Or CmbFac.Text = CmbFac.Items(4) Then
                        If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", i).Value Is DBNull.Value) Then
                            If CLng(DGV1.Item("Cln_OldAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value - CDbl(DGV1.Item("Cln_KolCount", i).Value)), CDbl(DGV1.Item("Cln_OldJoz", i).Value) - CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If
                Next

                If count_Kala > 1 Then
                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
                If count_Service > 1 Then
                    If MessageBox.Show("کالای خدماتی سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
            Next
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "ValidSell")
            Return False
        End Try
    End Function
    Private Function ValidService() As Boolean
        Try
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtName.Text.Trim) Or String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("طرف حساب را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Return False
            End If
            If ChkVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtVisitor.Text.Trim) Or String.IsNullOrEmpty(TxtIdVisitor.Text.Trim) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtVisitor.Focus()
                    Return False
                End If
            End If
            If ChkPart.Checked = True Then
                If String.IsNullOrEmpty(TxtPart.Text.Trim) Or String.IsNullOrEmpty(TxtIdPart.Text.Trim) Then
                    MessageBox.Show("پارت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPart.Focus()
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText.Trim) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Return False
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Return False
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    MessageBox.Show("نوع کالا در ردیف شماره " & "{" & i + 1 & "}" & "  از نوع کالای غیر خدماتی است که در فاکتور خدمات قابل قبول نیست لطفا آن را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If

                Next
                If count_Kala > 1 Then
                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
                If count_Service > 1 Then
                    If MessageBox.Show("کالای خدماتی سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
            Next

            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "ValidService")
            Return False
        End Try
    End Function
    Private Function ValidDamage() As Boolean
        Try
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            If String.IsNullOrEmpty(TxtDate.ThisText.Trim) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Return False
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Return False
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value < 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Return False
                    End If

                    If LEdit.Text = "0" Then
                        If CmbFac.Text = CmbFac.Items(1) Or CmbFac.Text = CmbFac.Items(3) Or CmbFac.Text = CmbFac.Items(6) Then
                            If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                If MAnbar = True Then
                                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                Else
                                    MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return False
                                End If
                            End If
                        End If
                    Else
                        If CmbFac.Text = CmbFac.Items(1) Or CmbFac.Text = CmbFac.Items(3) Or CmbFac.Text = CmbFac.Items(6) Then
                            If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", i).Value Is DBNull.Value) Then
                                If CLng(DGV1.Item("Cln_OldAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value) - CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value) - CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                Else
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                        If MAnbar = True Then
                                            If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                        Else
                                            MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If CmbFac.Text = CmbFac.Items(0) Or CmbFac.Text = CmbFac.Items(4) Then
                        If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", i).Value Is DBNull.Value) Then
                            If CLng(DGV1.Item("Cln_OldAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value - CDbl(DGV1.Item("Cln_KolCount", i).Value)), CDbl(DGV1.Item("Cln_OldJoz", i).Value) - CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار قبلی است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then
                    MessageBox.Show("نوع کالا در ردیف شماره " & "{" & i + 1 & "}" & "  از نوع کالای خدماتی است که در ضایعات قابل قبول نیست لطفا آن را حذف کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                        count_Kala += 1
                    End If
                Next
                If count_Kala > 1 Then
                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                End If
            Next
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "ValidDamage")
            Return False
        End Try
    End Function
    Private Sub ShowKalafactor()
        Try
            Dim QueryKala As String = ""
            Dim QueryInfo As String = ""
            If LState.Text = "0" Or LState.Text = "2" Then
                QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,KalaFactorBuy.Id,KalaFactorBuy.IdKala ,KalaFactorBuy.IdAnbar , KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala , Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBuy.IdFactor =" & CLng(LIdFac.Text) & " UNION ALL SELECT DK='False',DK_KOL=0,DK_JOZ=0,KalaFactorBuy.Id,KalaFactorBuy.IdService as Idkala,KalaFactorBuy.IdAnbar , KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBuy.IdService  = Define_Service .ID  WHERE ListFactorBuy.IdFactor =" & CLng(LIdFac.Text) & " ORDER BY KalaFactorBuy.Id"
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBuy WHERE  ListFactorBuy.IdFactor =" & CLng(LIdFac.Text) & ")  Is NULL BEGIN SELECT  ListFactorBuy.D_date, ListFactorBuy.IdName, ListFactorBuy.Part, ListFactorBuy.Sanad, ListFactorBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorBuy.IdVisitor FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE   ListFactorBuy.IdFactor =" & CLng(LIdFac.Text) & "  END ELSE BEGIN SELECT  ListFactorBuy.D_date, ListFactorBuy.IdName, ListFactorBuy.Part, ListFactorBuy.Sanad, ListFactorBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBuy .IdVisitor =Define_Visitor .Id  WHERE  ListFactorBuy.IdFactor =" & CLng(LIdFac.Text) & "  END"
            ElseIf LState.Text = "1" Then
                QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,KalaFactorBackBuy.Id,KalaFactorBackBuy.IdKala ,KalaFactorBackBuy.IdAnbar ,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackBuy.IdFactor =" & CLng(LIdFac.Text) & " UNION ALL SELECT DK='False',DK_KOL=0,DK_JOZ=0,KalaFactorBackBuy.Id,KalaFactorBackBuy.IdService as Idkala,KalaFactorBackBuy.IdAnbar ,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBackBuy.IdService  = Define_Service .ID  WHERE ListFactorBackBuy.IdFactor =" & CLng(LIdFac.Text) & " ORDER BY KalaFactorBackBuy.Id"
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackBuy WHERE  ListFactorBackBuy.IdFactor =" & CLng(LIdFac.Text) & ")  Is NULL BEGIN SELECT  ListFactorBackBuy.D_date, ListFactorBackBuy.IdName, ListFactorBackBuy.Part, ListFactorBackBuy.Sanad, ListFactorBackBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorBackBuy.IdVisitor FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE   ListFactorBackBuy.IdFactor =" & CLng(LIdFac.Text) & "  END ELSE BEGIN SELECT  ListFactorBackBuy.D_date, ListFactorBackBuy.IdName, ListFactorBackBuy.Part, ListFactorBackBuy.Sanad, ListFactorBackBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorBackBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackBuy .IdVisitor =Define_Visitor .Id  WHERE  ListFactorBackBuy.IdFactor =" & CLng(LIdFac.Text) & "  END"
            ElseIf LState.Text = "3" Or LState.Text = "5" Or LState.Text = "7" Then
                QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,KalaFactorSell.Id,KalaFactorSell.IdKala ,KalaFactorSell.IdAnbar ,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & " UNION ALL SELECT DK='False',DK_KOL=0,DK_JOZ=0,KalaFactorSell.Id,KalaFactorSell.IdService as Idkala,KalaFactorSell.IdAnbar ,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & " ORDER BY KalaFactorSell.Id"
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & ")  Is NULL BEGIN SELECT  ListFactorSell.D_date, ListFactorSell.IdName, ListFactorSell.Part, ListFactorSell.Sanad, ListFactorSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorSell.IdVisitor FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE   ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & "  END ELSE BEGIN SELECT  ListFactorSell.D_date, ListFactorSell.IdName, ListFactorSell.Part, ListFactorSell.Sanad, ListFactorSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  WHERE  ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & "  END"
            ElseIf LState.Text = "4" Then
                QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,KalaFactorBackSell.Id,KalaFactorBackSell.IdKala ,KalaFactorBackSell.IdAnbar ,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackSell.IdFactor =" & CLng(LIdFac.Text) & " UNION ALL SELECT DK='False',DK_KOL=0,DK_JOZ=0,KalaFactorBackSell.Id,KalaFactorBackSell.IdService as Idkala,KalaFactorBackSell.IdAnbar ,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Service  ON KalaFactorBackSell.IdService  = Define_Service .ID  WHERE ListFactorBackSell.IdFactor =" & CLng(LIdFac.Text) & " ORDER BY KalaFactorBackSell.Id"
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackSell WHERE  ListFactorBackSell.IdFactor =" & CLng(LIdFac.Text) & ")  Is NULL BEGIN SELECT  ListFactorBackSell.IdFacSell,ListFactorBackSell.D_date, ListFactorBackSell.IdName, ListFactorBackSell.Part, ListFactorBackSell.Sanad, ListFactorBackSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorBackSell.IdVisitor FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE   ListFactorBackSell.IdFactor =" & CLng(LIdFac.Text) & "  END ELSE BEGIN SELECT  ListFactorBackSell.IdFacSell,ListFactorBackSell.D_date, ListFactorBackSell.IdName, ListFactorBackSell.Part, ListFactorBackSell.Sanad, ListFactorBackSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorBackSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackSell .IdVisitor =Define_Visitor .Id  WHERE  ListFactorBackSell.IdFactor =" & CLng(LIdFac.Text) & "  END"
            ElseIf LState.Text = "6" Then
                QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,KalaFactorDamage.Id,KalaFactorDamage.IdKala ,KalaFactorDamage.IdAnbar ,KalaFactorDamage.KolCount, KalaFactorDamage.JozCount, KalaFactorDamage.Fe, DarsadDiscount=0,DarsadMon=0, KalaFactorDamage.Mon,KalaFactorDamage.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorDamage INNER JOIN KalaFactorDamage ON ListFactorDamage.IdFactor = KalaFactorDamage.IdFactor INNER JOIN Define_Kala ON KalaFactorDamage.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorDamage.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorDamage.IdFactor =" & CLng(LIdFac.Text) & " ORDER BY KalaFactorDamage.Id"
                QueryInfo = "SELECT  IdVisitor=NULL,Idname=NULL,[Address]=NULL,ListFactorDamage.D_date, ListFactorDamage.Part, ListFactorDamage.Sanad, ListFactorDamage.Disc,Tell1='',Tell2='' FROM ListFactorDamage  WHERE   ListFactorDamage.IdFactor =" & CLng(LIdFac.Text)
            ElseIf LState.Text = "8" Then
                QueryKala = "SELECT DK='False' ,DK_KOL=0 ,DK_JOZ=0,KalaFactorService.Id,KalaFactorService.IdService As IdKala,IdAnbar='' ,KalaFactorService.KolCount, JozCount=0, KalaFactorService.Fe, KalaFactorService.DarsadDiscount, KalaFactorService.DarsadMon, KalaFactorService.Mon,KalaFactorService.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorService INNER JOIN KalaFactorService ON ListFactorService.IdFactor = KalaFactorService.IdFactor INNER JOIN Define_Service  ON KalaFactorService.IdService  = Define_Service .ID   WHERE ListFactorService.IdFactor =" & CLng(LIdFac.Text) & " ORDER BY KalaFactorService.Id"
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorService WHERE  ListFactorService.IdFactor =" & CLng(LIdFac.Text) & ")  Is NULL BEGIN SELECT  ListFactorService.D_date, ListFactorService.IdName, ListFactorService.Part, ListFactorService.Sanad, ListFactorService.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorService.IdVisitor FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE   ListFactorService.IdFactor =" & CLng(LIdFac.Text) & "  END ELSE BEGIN SELECT  ListFactorService.D_date, ListFactorService.IdName, ListFactorService.Part, ListFactorService.Sanad, ListFactorService.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorService.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorService .IdVisitor =Define_Visitor .Id  WHERE  ListFactorService.IdFactor =" & CLng(LIdFac.Text) & "  END"
            End If
            Dim dtrInfo As SqlDataReader = Nothing
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
                        DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value = dtrInfo("namKala")
                        DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = dtrInfo("KolCount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = dtrInfo("JozCount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_OldKol", DGV1.RowCount - 1).Value = dtrInfo("KolCount")
                        DGV1.Item("Cln_OldJoz", DGV1.RowCount - 1).Value = dtrInfo("JozCount")
                        DGV1.Item("Cln_OldAnbar", DGV1.RowCount - 1).Value = dtrInfo("IdAnbar")
                        DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = dtrInfo("Vahed")
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = If(dtrInfo("Fe").ToString.Length > 3, Format(dtrInfo("Fe"), "###,###"), dtrInfo("Fe"))
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = dtrInfo("DarsadDiscount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = If(dtrInfo("DarsadMon").ToString.Length > 3, Format(dtrInfo("DarsadMon"), "###,###"), dtrInfo("DarsadMon"))
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = dtrInfo("NamAnbar")
                        DGV1.Item("cln_Money", DGV1.RowCount - 1).Value = If(dtrInfo("Mon").ToString.Length > 3, Format(dtrInfo("Mon"), "###,###"), dtrInfo("Mon"))
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = dtrInfo("KalaDisc")
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = dtrInfo("IdKala")
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = dtrInfo("IdAnbar")
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dtrInfo("DK")
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dtrInfo("DK_KOL")
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dtrInfo("DK_JOZ")
                    End While
                    DGV1.AllowUserToAddRows = True
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            '////////////////////////////
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    dtrInfo.Read()
                    TxtSanad.Text = If(dtrInfo("Sanad") Is DBNull.Value, "", dtrInfo("Sanad"))
                    TxtDisc.Text = If(dtrInfo("Disc") Is DBNull.Value, "", dtrInfo("Disc"))
                    LDisc.Text = IIf(String.IsNullOrEmpty(dtrInfo("Tell1")) And String.IsNullOrEmpty(dtrInfo("Tell2")), "", "تلفن: " & dtrInfo("Tell1") & "-" & dtrInfo("Tell2")) & "  " & If(dtrInfo("Address") Is DBNull.Value, "", dtrInfo("Address"))
                    TxtDate.ThisText = dtrInfo("D_Date")
                    If Not (dtrInfo("IdVisitor") Is DBNull.Value) Then
                        TxtIdVisitor.Text = dtrInfo("IdVisitor")
                        TxtVisitor.Text = dtrInfo("NamVisit")
                        ChkVisitor.Checked = True
                    Else
                        TxtIdVisitor.Text = ""
                        TxtVisitor.Text = ""
                        ChkVisitor.Checked = False
                        TxtVisitor.Enabled = False
                    End If

                    If Not (dtrInfo("Part") Is DBNull.Value) Then
                        TxtIdPart.Text = Tmp_String2
                        TxtPart.Text = Tmp_String1
                        ChkPart.Checked = True
                    Else
                        TxtIdPart.Text = ""
                        TxtPart.Text = ""
                        ChkPart.Checked = False
                        ChkPart.Enabled = False
                    End If

                    If Not (dtrInfo("Idname") Is DBNull.Value) Then
                        TxtName.Text = dtrInfo("Nam")
                        TxtIdPeople.Text = dtrInfo("Idname")
                        TxtIdCityFac.Text = dtrInfo("IdCity")
                    End If
                    If LState.Text = "4" Then
                        If Not (dtrInfo("IdFacSell") Is DBNull.Value) Then
                            ChkFrosh.Checked = True
                            TxtIdFactor.Text = dtrInfo("IdFacSell")
                        End If
                    End If
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.CalculateMoney()
            If LState.Text = "3" Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using cmd As New SqlCommand("SELECT IdR, Fe FROM KalaKasriFactor WHERE IdFactor =" & CLng(LIdFac.Text) & " UNION SELECT IdKala AS IdR, Fe FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell .IdFactor WHERE ListFactorBackSell.IdFacSell =" & CLng(LIdFac.Text) & " AND  ListFactorBackSell.Activ =1", ConectionBank)
                    dtrInfo = cmd.ExecuteReader
                End Using
                If dtrInfo.HasRows Then
                    While dtrInfo.Read
                        Array.Resize(ListKasri, ListKasri.Length + 1)
                        ListKasri(ListKasri.Length - 1).IdKala = dtrInfo("IdR")
                        ListKasri(ListKasri.Length - 1).Fe = dtrInfo("Fe")
                    End While
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "ShowKalaFactor")
            Me.Close()
        End Try
    End Sub
    Private Sub CalculateMoney()
        Dim allmoney As Double = 0
        Dim alldarsad As Double = 0
        For i As Integer = 0 To DGV1.Rows.Count - 2
            allmoney += If(DGV1.Item("cln_Money", i).Value Is DBNull.Value Or DGV1.Item("cln_Money", i).Value.ToString.Equals(""), 0, CDbl(DGV1.Item("cln_Money", i).Value))
            alldarsad += If(DGV1.Item("Cln_DarsadMon", i).Value Is DBNull.Value Or DGV1.Item("Cln_DarsadMon", i).Value.Equals(""), 0, CDbl(DGV1.Item("Cln_DarsadMon", i).Value))
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

                DGV1.Item("Cln_DarsadMon", i).Value = Format(CDbl(DGV1.Item("cln_Money", i).Value) * (CDbl(DGV1.Item("Cln_Darsad", i).Value) / 100), "###,###")

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

    Private Sub Factor()
        Try
            If state = 0 Or state = 2 Then
                PrintSQl = "SELECT  KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.IdService,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBuy.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.IdService,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBuy.IdService  = Define_Service .ID  WHERE ListFactorBuy.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorBuy.Id"
            ElseIf state = 1 Then
                PrintSQl = "SELECT  KalaFactorBackBuy.Id,KalaFactorBackBuy.IdKala,KalaFactorBackBuy.IdService,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorBackBuy.Id,KalaFactorBackBuy.Idkala,KalaFactorBackBuy.IdService,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBackBuy.IdService  = Define_Service .ID  WHERE ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorBackBuy.Id "
            ElseIf state = 3 Or state = 5 Or state = 7 Then
                PrintSQl = "SELECT  KalaFactorSell.Id,KalaFactorSell.IdKala,KalaFactorSell.IdService,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorSell.Id,KalaFactorSell.Idkala,KalaFactorSell.IdService,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorSell.Id "
            ElseIf state = 4 Then
                PrintSQl = "SELECT  KalaFactorBackSell.Id,KalaFactorBackSell.IdKala,KalaFactorBackSell.IdService,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackSell.IdFactor =" & CLng(Idfactor) & " UNION ALL SELECT KalaFactorBackSell.Id,KalaFactorBackSell.IdKala,KalaFactorBackSell.IdService,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Service  ON KalaFactorBackSell.IdService  = Define_Service .ID  WHERE ListFactorBackSell.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorBackSell.Id "
            ElseIf state = 8 Then
                PrintSQl = "SELECT KalaFactorService.Id,IdKala=0,KalaFactorService.IdService ,KalaFactorService.KolCount, JozCount=0, KalaFactorService.Fe, KalaFactorService.DarsadDiscount, KalaFactorService.DarsadMon, KalaFactorService.Mon,KalaFactorService.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorService INNER JOIN KalaFactorService ON ListFactorService.IdFactor = KalaFactorService.IdFactor INNER JOIN Define_Service  ON KalaFactorService.IdService  = Define_Service .ID  WHERE ListFactorService.IdFactor =" & CLng(Idfactor) & " Order By KalaFactorService.Id"
            End If
            Dim Dataret As New DataSetFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("کالاهای فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            Dim Kind As String = GetKindFactor()
            If state = "3" Then
                If Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim count As Long = 0
                    If Dataret.DataTable1.Rows.Count <= 20 Then
                        count = 20 - Dataret.DataTable1.Rows.Count
                    Else
                        count = 20 - (Dataret.DataTable1.Rows.Count Mod 20)
                    End If
                    Dim x() As Byte = Nothing
                    Dataret.DataTable1.Columns("Id").AllowDBNull = True
                    For i As Integer = 0 To count - 1
                        Dataret.DataTable1.AddDataTable1Row(0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", "", "", x, 0, 0, "", 0, 0, x, "", 0, 0, 0, "", 0, "0", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                    Next
                End If
            End If
            '//////////////////////////////////////////
            Dim QueryInfo As String = ""
            If state = "0" Or state = "2" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBuy WHERE  ListFactorBuy.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBuy.IdName AS CodeP,ListFactorBuy.MonAdd ,ListFactorBuy.MonDec ,ListFactorBuy.Discount ,ListFactorBuy.Cash ,ListFactorBuy.MonHavaleh ,(ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) AS MonPayChk , ListFactorBuy.D_date,ListFactorBuy.IdUser , ISNULL(ListFactorBuy.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBuy.IdVisitor,NamVisit='' FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBuy.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBuy.IdName AS CodeP,ListFactorBuy.MonAdd ,ListFactorBuy.MonDec ,ListFactorBuy.Discount ,ListFactorBuy.Cash ,ListFactorBuy.MonHavaleh ,(ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) AS MonPayChk ,ListFactorBuy.D_date,ListFactorBuy.IdUser, ListFactorBuy.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBuy .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBuy.IdFactor =" & CLng(Idfactor) & "  END"
            ElseIf state = "1" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackBuy WHERE  ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackBuy.IdName AS CodeP,ListFactorBackBuy.MonAdd ,ListFactorBackBuy.MonDec ,ListFactorBackBuy.Discount ,ListFactorBackBuy.Cash ,ListFactorBackBuy.MonHavaleh ,ListFactorBackBuy.MonPayChk , ListFactorBackBuy.D_date,ListFactorBackBuy.IdUser , ISNULL(ListFactorBackBuy.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBackBuy.IdVisitor,NamVisit='' FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackBuy.IdName AS CodeP,ListFactorBackBuy.MonAdd ,ListFactorBackBuy.MonDec ,ListFactorBackBuy.Discount ,ListFactorBackBuy.Cash ,ListFactorBackBuy.MonHavaleh ,ListFactorBackBuy.MonPayChk ,ListFactorBackBuy.D_date,ListFactorBackBuy.IdUser, ListFactorBackBuy.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBackBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackBuy .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & "  END"
            ElseIf state = "3" Or state = "5" Or state = "7" Then
                QueryInfo = "Declare @itbl table(DriverNam  Nvarchar(max),IdExit Nvarchar(max)) INSERT INTO @itbl SELECT Nam AS DriverNam,IdExit  FROM(SELECT ListExitFactor.IdFactor, ExitFactor.Id AS IdExit, ExitFactor.IdDriver FROM ListExitFactor INNER JOIN ExitFactor ON ListExitFactor.IdList = ExitFactor.Id WHERE ListExitFactor.IdFactor=" & CLng(Idfactor) & ") AS EFactor INNER JOIN Define_Driver ON EFactor.IdDriver =Define_Driver.Id If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT IdExit=(SELECT ISNULL(MAX(IdExit),'') FROM @itbl),DriverNam=(SELECT ISNULL(MAX(DriverNam),'') FROM @itbl),ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk , ListFactorSell.D_date,ListFactorSell.IdUser , ISNULL(ListFactorSell.Disc,'') AS Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorSell.IdVisitor,NamVisit='' FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorSell.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT IdExit=(SELECT ISNULL(MAX(IdExit),'') FROM @itbl),DriverNam=(SELECT ISNULL(MAX(DriverNam),'') FROM @itbl),ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk ,ListFactorSell.D_date,ListFactorSell.IdUser, ListFactorSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorSell.IdFactor =" & CLng(Idfactor) & " END"
            ElseIf state = "4" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackSell WHERE  ListFactorBackSell.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackSell.IdName AS CodeP,ListFactorBackSell.MonAdd ,ListFactorBackSell.MonDec ,ListFactorBackSell.Discount ,ListFactorBackSell.Cash ,ListFactorBackSell.MonHavaleh ,(ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk ) AS MonPayChk , ListFactorBackSell.D_date,ListFactorBackSell.IdUser , ISNULL(ListFactorBackSell.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBackSell.IdVisitor,NamVisit='' FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBackSell.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackSell.IdName AS CodeP,ListFactorBackSell.MonAdd ,ListFactorBackSell.MonDec ,ListFactorBackSell.Discount ,ListFactorBackSell.Cash ,ListFactorBackSell.MonHavaleh ,(ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk ) AS MonPayChk ,ListFactorBackSell.D_date,ListFactorBackSell.IdUser, ListFactorBackSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBackSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBackSell.IdFactor =" & CLng(Idfactor) & "  END"
            ElseIf state = "6" Then
                QueryInfo = "SELECT  IdExit=N'',DriverNam=N'',CodeP=0,MonAdd=0,MonDec=0,Discount=0,Cash=0,MonHavaleh=0,MonPayChk=0,ListFactorDamage.D_date,ListFactorDamage.IdUser ,ISNULL(ListFactorDamage.Disc,'') AS Disc, Nam='',[Address]='',Tell='',NamO='' ,NamCI='',NamP='' ,IdVisitor=0,NamVisit='' FROM ListFactorDamage WHERE ListFactorDamage.IdFactor =" & CLng(Idfactor)
            ElseIf state = "8" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorService WHERE  ListFactorService.IdFactor =" & CLng(Idfactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorService.IdName AS CodeP,ListFactorService.MonAdd ,ListFactorService.MonDec ,ListFactorService.Discount ,ListFactorService.Cash ,ListFactorService.MonHavaleh ,ListFactorService.MonPayChk , ListFactorService.D_date,ListFactorService.IdUser , ISNULL(ListFactorService.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorService.IdVisitor,NamVisit='' FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorService.IdFactor =" & CLng(Idfactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorService.IdName AS CodeP,ListFactorService.MonAdd ,ListFactorService.MonDec ,ListFactorService.Discount ,ListFactorService.Cash ,ListFactorService.MonHavaleh ,ListFactorService.MonPayChk ,ListFactorService.D_date,ListFactorService.IdUser, ListFactorService.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorService.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorService .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorService.IdFactor =" & CLng(Idfactor) & "  END"
            End If
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("اطلاعات فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("IdExit") = dtrInfo("IdExit")
                    Dataret.DataTable1.Rows(0).Item("DriverNam") = dtrInfo("DriverNam")
                    Dataret.DataTable1.Rows(0).Item("CodeP") = dtrInfo("CodeP")
                    Dataret.DataTable1.Rows(0).Item("d_Date") = dtrInfo("d_date")
                    Dataret.DataTable1.Rows(0).Item("IdFactor") = CLng(Idfactor)
                    Dataret.DataTable1.Rows(0).Item("People") = dtrInfo("Nam")
                    Dataret.DataTable1.Rows(0).Item("Ostan") = dtrInfo("NamO")
                    Dataret.DataTable1.Rows(0).Item("City") = dtrInfo("NamCI")
                    Dataret.DataTable1.Rows(0).Item("Part") = dtrInfo("NamP")
                    Dataret.DataTable1.Rows(0).Item("Address") = dtrInfo("Address")
                    Dataret.DataTable1.Rows(0).Item("Tell") = dtrInfo("Tell")
                    Dataret.DataTable1.Rows(0).Item("Visit") = dtrInfo("NamVisit")
                    Dataret.DataTable1.Rows(0).Item("Acount") = dtrInfo("IdUser")
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") = dtrInfo("Disc")
                    Dataret.DataTable1.Rows(0).Item("Cash") = dtrInfo("Cash")
                    Dataret.DataTable1.Rows(0).Item("DiscountC") = dtrInfo("Discount")
                    Dataret.DataTable1.Rows(0).Item("Chk") = dtrInfo("MonPayChk")
                    Dataret.DataTable1.Rows(0).Item("Add") = dtrInfo("MonAdd")
                    Dataret.DataTable1.Rows(0).Item("Dec") = dtrInfo("MonDec")
                    Dataret.DataTable1.Rows(0).Item("HBank") = dtrInfo("MonHavaleh")
                    Dataret.DataTable1.Rows(0).Item("Lend") = CDbl(lend)
                    Dataret.DataTable1.Rows(0).Item("PayMon") = dtrInfo("MonAdd") - (dtrInfo("MonDec") + dtrInfo("Discount"))
                    Select Case CLng(state)
                        Case 0 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خرید"
                        Case 1 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "برگشت از خرید"
                        Case 2 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خرید امانی"
                        Case 3 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور فروش"
                        Case 4 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "برگشت از فروش"
                        Case 5 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور فروش امانی"
                        Case 6 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور ضایعات"
                        Case 7 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "پیش فاکتور"
                        Case 8 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خدمات"
                    End Select
                End If
            End Using
            dtrInfo.Close()
            Using SQLComanad As New SqlCommand("SELECT Top 1 CompanyName ,TelFax as CompanyTell,[Address] as CompanyAddress,Header ,Footer,CompanyImage  FROM Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                SQLComanad.CommandTimeout = 0
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("CompanyName") = dtrInfo("CompanyName")
                    Dataret.DataTable1.Rows(0).Item("CompanyAddress") = dtrInfo("CompanyAddress")
                    Dataret.DataTable1.Rows(0).Item("CompanyTell") = dtrInfo("CompanyTell")
                    Dataret.DataTable1.Rows(0).Item("Header") = dtrInfo("Header")
                    Dataret.DataTable1.Rows(0).Item("Footer") = dtrInfo("Footer")
                    Try
                        Dataret.DataTable1.Rows(0).Item("ImageFactor") = dtrInfo("CompanyImage")
                    Catch ex As Exception

                    End Try
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dtrInfo.Close()
            '///////////////////////////////////////////////////
            Dim MonRes As Double = 0
            Dim discount As Double = 0
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrDarsad") = Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("AllMoney") = Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                MonRes += Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                discount += Dataret.DataTable1.Rows(i).Item("DarsadMon")
                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    Dataret.DataTable1.Rows(i).Item("FeKol") = Dataret.DataTable1.Rows(i).Item("Fe")
                    'Dataret.DataTable1.Rows(i).Item("Fe") = 0
                Else
                    Dataret.DataTable1.Rows(i).Item("FeKol") = If(Dataret.DataTable1.Rows(i).Item("KolCount") <> 0, Dataret.DataTable1.Rows(i).Item("Mon") / Dataret.DataTable1.Rows(i).Item("KolCount"), 0)
                End If
                Dataret.DataTable1.Rows(i).Item("Vahed") &= " " & Dataret.DataTable1.Rows(i).Item("KalaDisc")
            Next
            Dataret.DataTable1.Rows(0).Item("PayMon") = MonRes + Dataret.DataTable1.Rows(0).Item("PayMon")

            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") = "توضیحات فاکتور : " & If(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc"))
            ''''''''''''''''''''''''MoeinFactor
            If CLng(state) <> 7 And CLng(state) <> 6 Then
                OldSanad = 0
                CurSanad = 0
                IdKala = 0
                SetMoeinPeopleVarible(CLng(Idfactor), CLng(state))
                Dataret.DataTable1.Rows(0).Item("OldMoein") = GetMoeinPeople(IdKala, OldSanad, Dataret.DataTable1.Rows(0).Item("d_Date"), CLng(state), CLng(Idfactor))
                Dataret.DataTable1.Rows(0).Item("Moein") = If(CLng(state) = 0 Or CLng(state) = 2 Or CLng(state) = 4, Dataret.DataTable1.Rows(0).Item("OldMoein") - Dataret.DataTable1.Rows(0).Item("PayMon") + Dataret.DataTable1.Rows(0).Item("Cash") + Dataret.DataTable1.Rows(0).Item("Chk") + Dataret.DataTable1.Rows(0).Item("HBank"), Dataret.DataTable1.Rows(0).Item("OldMoein") + Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("Cash") - Dataret.DataTable1.Rows(0).Item("Chk") - Dataret.DataTable1.Rows(0).Item("HBank"))
                Dim Tmpdate As String = GetOldTime(IdKala, OldSanad, Dataret.DataTable1.Rows(0).Item("d_Date"), CLng(state), CLng(Idfactor))
                If Not String.IsNullOrEmpty(Tmpdate) Then
                    Dim T As Long = SUBDAY(Dataret.DataTable1.Rows(0).Item("d_Date"), Tmpdate)
                    If Kind.Contains("A4ES3") Or Kind.Contains("A4ES4") Then
                        If T <> 0 Then
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = "مانده قبلی در تاریخ" & Tmpdate & " معادل" & T & " روز می باشد"
                        Else
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                        End If
                    Else
                        If T <> 0 Then
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") &= If(Not String.IsNullOrEmpty(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc")), " . ", "") & "مانده قبلی در تاریخ" & Tmpdate & " معادل" & T & " روز می باشد"
                        Else
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                        End If
                    End If
                Else
                    If Kind.Contains("A4ES3") Then
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = "مـانـده قــبــلـی"
                    Else
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                    End If
                End If
                If state = 3 Then
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") &= If(Not String.IsNullOrEmpty(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc")), " . ", "") & GetCashMonDisc(CLng(Idfactor))
                End If
                If Dataret.DataTable1.Rows(0).Item("Moein") < 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str((Dataret.DataTable1.Rows(0).Item("Moein") * -1)) & "-بستانکار"
                ElseIf Dataret.DataTable1.Rows(0).Item("Moein") = 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str(0) & "-بی حساب"
                ElseIf Dataret.DataTable1.Rows(0).Item("Moein") > 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("Moein")) & "-بدهکار"
                End If
            End If
            '//////////////////////////////////////////
            If (state = "3" Or state = "5") And (Kind.Contains("A4ES") Or Kind.Contains("A4ES2") Or Kind.Contains("A4ES4") Or Kind.Contains("EPSON100S") Or Kind.Contains("EPSON130S") Or Kind.Contains("A4ES3")) Then
                CallDiscountFactor(Dataret.DataTable1.Rows(0).Item("CodeP"), Dataret.DataTable1.Rows(0).Item("IdFactor"))
                Dim dec As Double = GetCashMonDisc2(CLng(Idfactor))
                Dataret.DataTable1.Rows(0).Item("CashDiscount") = Math.Round((TmpDarsad * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2)
                Dataret.DataTable1.Rows(0).Item("PelDiscount") = Math.Round((TmpDarsad1 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2)
                Dataret.DataTable1.Rows(0).Item("EndMon") = Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("PelDiscount") - Dataret.DataTable1.Rows(0).Item("CashDiscount")
                Dataret.DataTable1.Rows(0).Item("KindFrosh") = CallKindFactor(Dataret.DataTable1.Rows(0).Item("IdFactor"), Dataret.DataTable1.Rows(0).Item("d_Date"))
                If (Kind.Contains("A4ES2") Or Kind.Contains("A4ES3") Or Kind.Contains("A4ES4")) Then
                    If Kind.Contains("A4ES3") Or Kind.Contains("A4ES4") Then
                        CallDiscountChkFactor(Dataret.DataTable1.Rows(0).Item("CodeP"))
                        Dataret.DataTable1.Rows(0).Item("TChk1") = tc1
                        Dataret.DataTable1.Rows(0).Item("TChk2") = tc2
                        Dataret.DataTable1.Rows(0).Item("TChk3") = tc3
                        Dataret.DataTable1.Rows(0).Item("MonChk1") = If(TmpDarsad <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(0).Item("MonChk2") = If(TmpDarsad1 <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad1 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(0).Item("MonChk3") = If(TmpDarsad2 <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad2 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndCashMon") = Dataret.DataTable1.Rows(0).Item("EndMon") + Dataret.DataTable1.Rows(0).Item("OldMoein")
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk1Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk1") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk1") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk2Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk2") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk2") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk3Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk3") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk3") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                    End If
                    If Kind.Contains("A4ES4") Then
                        CallDiscountCardFactor(Dataret.DataTable1.Rows(0).Item("CodeP"), Dataret.DataTable1.Rows(0).Item("IdFactor"))
                        Dataret.DataTable1.Rows(0).Item("CardDiscount") = TmpDarsad
                        Dataret.DataTable1.Rows(0).Item("CardCash") = Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("CardDiscount")
                        SetEndMonKala(Dataret, Dataret.DataTable1.Rows(0).Item("CodeP"))
                    End If
                Else
                    SetEndMonKala(Dataret, Dataret.DataTable1.Rows(0).Item("CodeP"))
                End If
            Else
                Dataret.DataTable1.Rows(0).Item("CashDiscount") = 0
                Dataret.DataTable1.Rows(0).Item("PelDiscount") = 0
                Dataret.DataTable1.Rows(0).Item("EndMon") = Dataret.DataTable1.Rows(0).Item("PayMon")
                Dataret.DataTable1.Rows(0).Item("KindFrosh") = ""
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndCashMon") = 0
            End If

            '//////////////////////////////////////////
            Dim Ci As Integer = GetCountPrint("FACTOR")
            Dim J As Integer = 0

            If CLng(state) = 3 Or CLng(state) = 4 Or CLng(state) = 5 Then

                ''''''''''''''''''نوع فروشگاهی A4 کاغذ
                If Kind = "A4EFGKB" Then
                    Dim ret As New CRP_Factor_sell_A4EF_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Then
                    Dim ret As New CRP_Factor_sell_A4EF
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Then
                    Dim ret As New CRP_Factor_sell_A4EF_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی A4 کاغذ
                ElseIf Kind = "A4ETGKB" Then
                    Dim ret As New CRP_Factor_sell_A4ET_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGKS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKB" Then
                    Dim ret As New CRP_Factor_sell_A4ET
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGB" Then
                    Dim ret As New CRP_Factor_sell_A4ET_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع پخش سراسرس A4 کاغذ
                ElseIf Kind = "A4ESGKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESGKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESGB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ESGS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                    ''''''''''''''''''نوع توزیعی 2 A4 کاغذ
                ElseIf Kind = "A4ES2GKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2GKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2KB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2KS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2GB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES2GS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع توزیعی 3 A4 کاغذ
                ElseIf Kind = "A4ES3GKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3GKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3KB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3KS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3GB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES3GS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع توزیعی 4 A4 کاغذ
                ElseIf Kind = "A4ES4GKB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4GKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4KB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4KS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4GB" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "A4ES4GS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_sell_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_sell_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_sell_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع پخش سراسری EPSON100 کاغذ
                ElseIf Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                    ''''''''''''''''''نوع فاکتور آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    If CLng(state) = 3 Then
                        Dim ret As New CRP_Factor_sell_Epson100P
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If

                    ''''''''''''''''''نوع فروشگاهی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                ElseIf Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    If CLng(state) = 3 Or CLng(state) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        For J = 1 To Ci
                            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                        Next
                    End If
                End If
            ElseIf state = 0 Or state = 1 Or state = 2 Then
                ''''''''''''''''''نوع فروشگاهی A4 کاغذ
                If Kind = "A4EFGKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                ElseIf Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    '''''''''''''''''' نوع توزیعی و پخش سراسری و آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی و پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If
            ElseIf state = 7 Then
                ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و پخش سرایری و توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و پخش سراسری و توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If
            ElseIf state = 8 Then
                ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_Service_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_Service_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_Service_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_Service_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Or Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Service_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELGKS" Or Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Service_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Service_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Service_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و پخش سرایری و توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100FGB" Or Kind = "EPSON100TGB" Or Kind = "EPSON100SGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Service_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Service_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next

                    ''''''''''''''''''نوع فروشگاهی و پخش سراسری و توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Or Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Service_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Service_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If

            ElseIf state = 6 Then
                '''''''''''''''''' نوع فروشگاهی و پخش سراسری و توزیعی 1,2,3,4 و فروشگاهی ساده A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Or Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_Damage_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Or Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Or Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Damage_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Or Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Or Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Damage_A4E_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Or Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                    ''''''''''''''''''نوع توزیعی و پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    For J = 1 To Ci
                        ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
                    Next
                End If

            End If
            Application.DoEvents()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "Factor")
        End Try
    End Sub
    Private Sub ResedAnbar()
        Try
            If state = 0 Then
                PrintSQl = "SELECT  KalaFactorBuy.KolCount, KalaFactorBuy.JozCount,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorBuy .IdName WHERE ListFactorBuy.IdFactor =" & CLng(Idfactor) & " Order By NamKala "
            ElseIf state = 1 Then
                PrintSQl = "SELECT  KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorBackBuy .IdName WHERE ListFactorBackBuy.IdFactor =" & CLng(Idfactor) & " Order By NamKala "
            ElseIf state = 3 Then
                PrintSQl = "SELECT  KalaFactorSell.KolCount, KalaFactorSell.JozCount,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorSell.IdName WHERE ListFactorSell.IdFactor =" & CLng(Idfactor) & " Order By NamKala "
            ElseIf state = 4 Then
                PrintSQl = "SELECT  KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorBackSell.IdName WHERE ListFactorBackSell.IdFactor =" & CLng(Idfactor) & " Order By NamKala "
            End If

            Dim Dataret As New DataSetAnbar
            Dataret.Clear()
            Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
                dbDA.Fill(Dataret.DataTable1)
                Application.DoEvents()
            End Using
            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            Dataret.DataTable1.Rows(0).Item("IdFactor") = CLng(Idfactor)
            Dataret.DataTable1.Rows(0).Item("D_date") = TxtDate.ThisText
            Dataret.DataTable1.Rows(0).Item("TypeFac") = CmbFac.Text
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("Vahed") &= " " & Dataret.DataTable1.Rows(i).Item("KalaDisc")
            Next
            Dim ret As New CRP_Resid_Anbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            ret.PrintToPrinter(GetCountPrint("ANBAR"), False, 1, Integer.MaxValue)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "ResedAnbar")
        End Try
    End Sub
    Private Sub FactorFish()
        Try
            PrintSQl = String.Format("SELECT  PeopleMon=(SELECT ISNULL(EndCost,0) FROM [Define_CostKala] INNER JOIN Define_CityCostkala ON Define_CityCostkala.IdCity =[Define_CostKala].IdCity WHERE IdKala =KalaFactorSell.IdKala  AND Define_CityCostkala.IdCity =(SELECT IdCity FROM Define_People WHERE Id=ListFactorSell.IdName)),KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor ={0} UNION ALL SELECT PeopleMon=0,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor ={1} Order By NamKala ", CLng(Idfactor), CLng(Idfactor))
            Dim Dataret As New DataSetFactor
            Dataret.Clear()
            Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
                dbDA.Fill(Dataret.DataTable1)
                Application.DoEvents()
            End Using
            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            Dim dtrInfo As SqlDataReader
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim QueryInfo As String = ""
            If state = "3" Or state = "5" Then
                QueryInfo = String.Format("If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor ={0})  Is NULL BEGIN SELECT  ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk , ListFactorSell.D_date,ListFactorSell.IdUser , ISNULL(ListFactorSell.Disc,'') AS Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorSell.IdVisitor,NamVisit='' FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorSell.IdFactor ={1}  END ELSE BEGIN SELECT  ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk ,ListFactorSell.D_date,ListFactorSell.IdUser, ListFactorSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorSell.IdFactor ={2}  END", CLng(Idfactor), CLng(Idfactor), CLng(Idfactor))
            End If

            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("اطلاعات فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("DiscountC") = dtrInfo("Discount")
                    Dataret.DataTable1.Rows(0).Item("Add") = dtrInfo("MonAdd")
                    Dataret.DataTable1.Rows(0).Item("Dec") = dtrInfo("MonDec")
                    Dataret.DataTable1.Rows(0).Item("PayMon") = dtrInfo("MonAdd") - (dtrInfo("MonDec") + dtrInfo("Discount"))
                End If
            End Using
            dtrInfo.Close()

            Using SQLComanad As New SqlCommand("SELECT Top 1 CompanyName FROM Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                SQLComanad.CommandTimeout = 0
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("CompanyName") = dtrInfo("CompanyName")
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dtrInfo.Close()

            Dataret.DataTable1.Rows(0).Item("IdFactor") = Idfactor
            Dataret.DataTable1.Rows(0).Item("D_date") = Tmp_String1
            Dim MonRes As Double = 0
            Dim MonEND As Double = 0
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = If(Dataret.DataTable1.Rows(i).Item("JozCount") <> 0, Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/"), Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/"))
                MonRes += Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                Dataret.DataTable1.Rows(0).Item("DiscountC") += Dataret.DataTable1.Rows(i).Item("DarsadMon")
                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    Dataret.DataTable1.Rows(i).Item("FeKol") = Dataret.DataTable1.Rows(i).Item("Fe")
                    Dataret.DataTable1.Rows(i).Item("Fe") = Dataret.DataTable1.Rows(i).Item("Fe")
                Else
                    Dataret.DataTable1.Rows(i).Item("FeKol") = If(Dataret.DataTable1.Rows(i).Item("KolCount") <> 0, Dataret.DataTable1.Rows(i).Item("Mon") / Dataret.DataTable1.Rows(i).Item("KolCount"), 0)
                End If

                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    MonEND += CDbl(Dataret.DataTable1.Rows(i).Item("StrKol").ToString.Replace("/", ".")) * If(Dataret.DataTable1.Rows(i).Item("PeopleMon") Is DBNull.Value, Dataret.DataTable1.Rows(i).Item("Fe"), CDbl(Dataret.DataTable1.Rows(i).Item("PeopleMon")))
                Else
                    MonEND += CDbl(Dataret.DataTable1.Rows(i).Item("StrJoz").ToString.Replace("/", ".")) * If(Dataret.DataTable1.Rows(i).Item("PeopleMon") Is DBNull.Value, Dataret.DataTable1.Rows(i).Item("Fe"), CDbl(Dataret.DataTable1.Rows(i).Item("PeopleMon")))
                End If
            Next
            Dataret.DataTable1.Rows(0).Item("PayMon") = MonRes + Dataret.DataTable1.Rows(0).Item("PayMon")
            Dataret.DataTable1.Rows(0).Item("ENDMon") = MonEND
            Dim ret As New CRP_Factor_Fishprinter
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "FactorFish")
        End Try
    End Sub

    Private Sub GetMojodyKalaAnbar(ByVal Id As Long, ByVal IdAnar As Long, ByVal row As Integer)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            'Using Cmd As New SqlCommand("SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllJozCount)JozCount FROM (SELECT ID FROM Define_Anbar WHERE Id=" & IdAnar & ") AS AllKala", ConectionBank)
            Using Cmd As New SqlCommand("SELECT AllKala.*,(SELECT ROUND(ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0),2) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllJozCount)JozCount FROM (SELECT ID FROM Define_Anbar WHERE Id=" & IdAnar & ") AS AllKala", ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    DGV1.Item("Cln_KolCount", row).Value = IIf(dtr("KolCount") > 0, dtr("KolCount").ToString.Replace(".", "/"), 0)
                    DGV1.Item("Cln_JozCount", row).Value = IIf(dtr("JozCount") > 0, dtr("JozCount").ToString.Replace(".", "/"), 0)
                Else
                    DGV1.Item("Cln_KolCount", row).Value = 0
                    DGV1.Item("Cln_JozCount", row).Value = 0
                End If
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "GetMojodyKalaAnbar")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            DGV1.Item("Cln_KolCount", row).Value = 0
            DGV1.Item("Cln_JozCount", row).Value = 0
        End Try
    End Sub

    Private Sub RefreshMoney(ByVal i As Integer)
        Try
            If DGV1.Item("Cln_DK", i).Value = False Then
                DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_KOL", i).Value) * CDbl(DGV1.Item("Cln_Fe", i).Value), "###,###")
            Else
                DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_JozCount", i).Value) * CDbl(DGV1.Item("Cln_Fe", i).Value), "###,###")
            End If
            Me.CalDarsad()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "RefreshMoney")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            DGV1.Item("Cln_Money", i).Value = 0
        End Try
    End Sub

    Private Sub DGV1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV1.UserDeletingRow
        If LEdit.Text = "1" And LState.Text = "3" And ListKasri.Length > 0 Then
            For i As Integer = 0 To ListKasri.Length - 1
                If DGV1.Item("Cln_Code", e.Row.Index).Value = ListKasri(i).IdKala And CDbl(DGV1.Item("Cln_Fe", e.Row.Index).Value) = ListKasri(i).Fe Then
                    e.Cancel = True
                End If
            Next
        End If

        '//////////////////////////////////////////////////////////////////

        If LEdit.Text <> "0" Then

            If CmbFac.Text = CmbFac.Items(0) Or CmbFac.Text = CmbFac.Items(4) Then
                If Not (DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldAnbar", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then

                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value), CLng(DGV1.Item("Cln_OldAnbar", DGV1.CurrentRow.Index).Value)) Then
                        If MAnbar = True Then
                            If MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then e.Cancel = True
                        Else
                            MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار است و قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        End If

        '//////////////////////////////////////////////////////////////////
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            TxtPart.Enabled = True
            TxtPart.Focus()
        Else
            TxtPart.Enabled = False
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

    Private Sub ChkPart_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPart.GotFocus
        ChkPart.BackColor = Color.LightGray
    End Sub

    Private Sub ChkPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkPart.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ChkPart.Checked = True Then
                TxtPart.Focus()
            Else
                DGV1.Focus()
            End If
        End If
    End Sub

    Private Sub ChkPart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPart.LostFocus
        ChkPart.BackColor = Me.BackColor
    End Sub

    Private Sub TxtPart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPart.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Part_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtPart.Focus()
        If Tmp_Namkala <> "" Then
            TxtPart.Text = Tmp_Namkala
            TxtIdPart.Text = IdKala
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

    Private Sub BtnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscount.Click
        Try
            If CmbFac.Text <> CmbFac.Items.Item(3) Then
                BtnDiscount.Enabled = False
                Exit Sub
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If String.IsNullOrEmpty(TxtIdPeople.Text) Then
                MessageBox.Show("طرف حسابی جهت اعمال تخفیف حجمی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If

            If AreYouExistGroup(TxtIdPeople.Text) = False Then
                MessageBox.Show("گروه ویژه ایی برای طرف حساب مورد نظر انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            AutomaticDiscount(TxtIdPeople.Text, CDbl(Txtallmoney.Text))
            If TmpDarsad <= 0 Then
                MessageBox.Show(" تخفیفات حجمی به طرف حساب مورد نظر تعلق نمی گیرد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For i As Integer = 0 To DGV1.RowCount - 2
                Try
                    If CDbl(DGV1.Item("cln_Money", i).Value) > 0 And CDbl(DGV1.Item("Cln_Darsad", i).Value) < 100 Then
                        If Cash = True Then
                            If KalaCash(DGV1.Item("Cln_Code", i).Value, GetIdGroup(TxtIdPeople.Text)) = True Then Continue For
                            DGV1.Item("Cln_Darsad", i).Value = Replace(TmpDarsad + If(flagV > 0, CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", ".")), 0), ".", "/")
                            DGV1.Item("Cln_DarsadMon", i).Value = Format(CDbl(DGV1.Item("cln_Money", i).Value) * (CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))) / 100, "###,###")
                        Else
                            KalaCash(DGV1.Item("Cln_Code", i).Value, GetIdGroup(TxtIdPeople.Text))
                            DGV1.Item("Cln_Darsad", i).Value = Replace(TmpDarsad + If(flagV > 0, CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", ".")), 0), ".", "/")
                            DGV1.Item("Cln_DarsadMon", i).Value = Format(CDbl(DGV1.Item("cln_Money", i).Value) * (CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))) / 100, "###,###")
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next
            CalculateAllRowMoney()
            BtnDiscount.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "BtnDiscount_Click")
        End Try
    End Sub

    Private Sub TxtIdPeople_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdPeople.TextChanged
        If CmbFac.Text = CmbFac.Items.Item(3) Then BtnDiscount.Enabled = True
    End Sub
    Private Function AreQustionForDiscount() As Boolean
        Try
            If String.IsNullOrEmpty(TxtIdPeople.Text) Then
                Return False
            End If

            If AreYouExistGroup(TxtIdPeople.Text) = False Then
                Return False
            End If

            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            AutomaticDiscount(TxtIdPeople.Text, CDbl(Txtallmoney.Text))
            If TmpDarsad <= 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreQustionForDiscount")
            Return False
        End Try
    End Function

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub BtnSback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSback.Click
        Try
            Using frmsback As New SFactor_List
                frmsback.ShowDialog()
                If SFactorArray.Length > 0 Then
                    TxtName.Text = frmsback.TxtPeople.Text
                    TxtIdPeople.Text = frmsback.TxtIdName.Text
                    ChkFrosh.Checked = True
                    TxtIdFactor.Text = frmsback.TxtIDFac.Text
                    If Not String.IsNullOrEmpty(frmsback.TxtIdVisitor.Text) Then
                        ChkVisitor.Checked = True
                        TxtIdVisitor.Text = frmsback.TxtIdVisitor.Text
                        TxtVisitor.Text = GetNamVisitor(frmsback.TxtIdVisitor.Text)
                    Else
                        ChkVisitor.Checked = False
                    End If
                    DGV1.AllowUserToAddRows = False
                    For i As Integer = 0 To SFactorArray.Length - 1
                        DGV1.Rows.Add()
                        DGV1.Item("cln_type", DGV1.RowCount - 1).Value = SFactorArray(i).GroupKala
                        DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = SFactorArray(i).NamKala
                        DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = Replace(SFactorArray(i).KolCount, ".", "/")
                        DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = Replace(SFactorArray(i).JozCount, ".", "/")
                        DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = SFactorArray(i).NamVahed
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = IIf(SFactorArray(i).Fe <= 0, 0, FormatNumber(SFactorArray(i).Fe, 0))
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = Replace(SFactorArray(i).DarsadDiscount, ".", "/")
                        DGV1.Item("Cln_DarsadMon", i).Value = IIf(SFactorArray(i).DarsadMon <= 0, 0, FormatNumber(SFactorArray(i).DarsadMon, 0))
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = SFactorArray(i).NamAnbar
                        DGV1.Item("cln_Money", DGV1.RowCount - 1).Value = IIf(SFactorArray(i).Mon <= 0, 0, FormatNumber(SFactorArray(i).Mon, 0))
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = SFactorArray(i).DK
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = SFactorArray(i).DK_KOL
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = SFactorArray(i).DK_JOZ
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = SFactorArray(i).IdKala
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = SFactorArray(i).CodeAnbar
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = ""
                    Next
                    DGV1.AllowUserToAddRows = True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "BtnSback_Click")
        End Try
    End Sub

    Private Sub BtnKalaDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKalaDiscount.Click
        Try
            If CmbFac.Text <> CmbFac.Items.Item(3) Then
                BtnKalaDiscount.Enabled = False
                Exit Sub
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Exit Sub
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Exit Sub
                    End If
                End If
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If
                Next
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Array.Resize(Alldiscount, 0)
            Array.Resize(Alldiscount2, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If CDbl(DGV1.Item("Cln_Fe", i).Value) > 0 And CDbl(DGV1.Item("Cln_Darsad", i).Value) < 100 And Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then

                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).joz += CDbl(DGV1.Item("Cln_JozCount", i).Value)
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).joz = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).CodeAnbar = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Alldiscount(Alldiscount.Length - 1).anbar = DGV1.Item("Cln_Anbar", i).Value
                        Alldiscount(Alldiscount.Length - 1).Coding = GetCoding(CLng(DGV1.Item("Cln_Code", i).Value))
                    End If
                End If
            Next

            flag = False

            For i As Integer = 0 To Alldiscount.Count - 1


                For ai As Integer = 0 To Alldiscount2.Length - 1
                    If (Alldiscount2(ai).Coding = Alldiscount(i).Coding) And (Alldiscount2(ai).Coding <> "" And Alldiscount(i).Coding <> "") Then
                        Alldiscount2(ai).joz += Alldiscount(i).joz
                        Alldiscount2(ai).Kol += Alldiscount(i).Kol
                        flag = True
                        Exit For
                    End If
                    flag = False
                Next
                If flag = False Then
                    Array.Resize(Alldiscount2, Alldiscount2.Length + 1)
                    Alldiscount2(Alldiscount2.Length - 1).Idkala = Alldiscount(i).Idkala
                    Alldiscount2(Alldiscount2.Length - 1).joz = Alldiscount(i).joz
                    Alldiscount2(Alldiscount2.Length - 1).Kol = Alldiscount(i).Kol
                    Alldiscount2(Alldiscount2.Length - 1).CodeAnbar = Alldiscount(i).CodeAnbar
                    Alldiscount2(Alldiscount2.Length - 1).anbar = Alldiscount(i).anbar
                    Alldiscount2(Alldiscount2.Length - 1).Coding = Alldiscount(i).Coding
                End If
            Next
            CalKalaDiscount(Alldiscount2)
            CalculateAllRowMoney()
            BtnKalaDiscount.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "BtnKalaDiscount_Click")
        End Try
    End Sub

    Private Function AreQustionForDiscountKala() As Boolean
        Try
            Array.Resize(Alldiscount, 0)
            Array.Resize(Alldiscount2, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If CDbl(DGV1.Item("Cln_Fe", i).Value) > 0 And CDbl(DGV1.Item("Cln_Darsad", i).Value) < 100 And Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then

                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).joz += CDbl(DGV1.Item("Cln_JozCount", i).Value)
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).joz = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).CodeAnbar = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Alldiscount(Alldiscount.Length - 1).anbar = DGV1.Item("Cln_Anbar", i).Value
                        Alldiscount(Alldiscount.Length - 1).Coding = GetCoding(CLng(DGV1.Item("Cln_Code", i).Value))
                    End If
                End If
            Next

            flag = False

            For i As Integer = 0 To Alldiscount.Count - 1

                For ai As Integer = 0 To Alldiscount2.Length - 1
                    If (Alldiscount2(ai).Coding = Alldiscount(i).Coding) And (Alldiscount2(ai).Coding <> "" And Alldiscount(i).Coding <> "") Then
                        Alldiscount2(ai).joz += Alldiscount(i).joz
                        Alldiscount2(ai).Kol += Alldiscount(i).Kol
                        flag = True
                        Exit For
                    End If
                    flag = False
                Next
                If flag = False Then
                    Array.Resize(Alldiscount2, Alldiscount2.Length + 1)
                    Alldiscount2(Alldiscount2.Length - 1).Idkala = Alldiscount(i).Idkala
                    Alldiscount2(Alldiscount2.Length - 1).joz = Alldiscount(i).joz
                    Alldiscount2(Alldiscount2.Length - 1).Kol = Alldiscount(i).Kol
                    Alldiscount2(Alldiscount2.Length - 1).CodeAnbar = Alldiscount(i).CodeAnbar
                    Alldiscount2(Alldiscount2.Length - 1).anbar = Alldiscount(i).anbar
                    Alldiscount2(Alldiscount2.Length - 1).Coding = Alldiscount(i).Coding
                End If
            Next
            Return AreCalKalaDiscount(Alldiscount2)
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreQustionForDiscountKala")
            Return False
        End Try
    End Function
    Private Function GetCoding(ByVal Id As Long) As String
        Try
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using cmd As New SqlCommand("SELECT  ISNULL(Coding,'') As Coding FROM ListKala_Discount WHERE Idkala =" & Id, ConectionBank)
                dtr = cmd.ExecuteReader()
            End Using
            If dtr.HasRows Then
                dtr.Read()
                Dim str As String = ""
                str = dtr("Coding")
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return str
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return ""
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "GetCoding")
            Return ""
        End Try
    End Function
    Private Sub CalKalaDiscount(ByVal ListDiscount() As KalaDiscount)
        Try
            Dim dt As New DataTable
            Dim AFlag As Boolean = False
            For i As Integer = 0 To ListDiscount.Length - 1
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                dt.Clear()
                AFlag = False
                Using cmd As New SqlCommand("SELECT AutoDiscount FROM ListKala_Discount WHERE Idkala =" & ListDiscount(i).Idkala, ConectionBank)
                    AFlag = CBool(cmd.ExecuteScalar)
                End Using

                If AFlag = False Then
                    Using cmd As New SqlCommand("SELECT C_Count=1,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MAX(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                Else
                    Using cmd As New SqlCommand("SELECT C_Count=CASE WHEN KolCount<=" & ListDiscount(i).Kol & " THEN " & ListDiscount(i).Kol & "/KolCount ELSE 0 END,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MIN(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                End If

                If dt.Rows.Count <= 0 Then Continue For
                For j As Integer = 0 To dt.Rows.Count - 1

                    DGV1.AllowUserToAddRows = False
                    DGV1.Rows.Add()
                    '''''''''''''''''''''''''''''''''''
                    DGV1.Item("Cln_type", DGV1.RowCount - 1).Value = dt.Rows(j).Item("GroupKala")
                    DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = dt.Rows(j).Item("NamKala")
                    DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = Replace(dt.Rows(j).Item("Kol") * Fix(dt.Rows(j).Item("C_Count")), ".", "/")
                    DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = Replace(dt.Rows(j).Item("Joz") * Fix(dt.Rows(j).Item("C_Count")), ".", "/")
                    DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = dt.Rows(j).Item("NamVahed")
                    DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = 100

                    If dt.Rows(j).Item("anbar") = 1 Then
                        Dim fe As Double = 0
                        fe = GetCostFrosh_Barcode(dt.Rows(j).Item("IdKala"), IIf(String.IsNullOrEmpty(TxtIdCityFac.Text), 0, TxtIdCityFac.Text), IIf(String.IsNullOrEmpty(TxtIdPeople.Text), 0, TxtIdPeople.Text))
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = IIf(fe > 0, FormatNumber(fe, 0), 0)
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = If(dt.Rows(j).Item("Joz") > 0, FormatNumber(fe * (dt.Rows(j).Item("Joz") * Fix(dt.Rows(j).Item("C_Count"))), 0), FormatNumber(fe * (dt.Rows(j).Item("Kol") * Fix(dt.Rows(j).Item("C_Count"))), 0))
                        DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = If(dt.Rows(j).Item("Joz") > 0, FormatNumber(fe * (dt.Rows(j).Item("Joz") * Fix(dt.Rows(j).Item("C_Count"))), 0), FormatNumber(fe * (dt.Rows(j).Item("Kol") * Fix(dt.Rows(j).Item("C_Count"))), 0))
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = ListDiscount(i).anbar
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = ListDiscount(i).CodeAnbar
                    Else
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = 0
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = 100
                        DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = 0
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = ""
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = ""
                    End If

                    DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = "جایزه"
                    DGV1.Item("Cln_code", DGV1.RowCount - 1).Value = dt.Rows(j).Item("IdKala")
                    DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dt.Rows(j).Item("DK")
                    DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dt.Rows(j).Item("DK_KOL")
                    DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dt.Rows(j).Item("DK_JOZ")
                    '''''''''''''''''''''''''''''''''''
                    DGV1.AllowUserToAddRows = True
                Next j
            Next i
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "CalKalaDiscount")
        End Try
    End Sub

    Private Function AreCalKalaDiscount(ByVal ListDiscount() As KalaDiscount) As Boolean
        Try
            Dim dt As New DataTable
            Dim AFlag As Boolean = False
            For i As Integer = 0 To ListDiscount.Length - 1
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                dt.Clear()
                AFlag = False
                Using cmd As New SqlCommand("SELECT AutoDiscount FROM ListKala_Discount WHERE Idkala =" & ListDiscount(i).Idkala, ConectionBank)
                    AFlag = CBool(cmd.ExecuteScalar)
                End Using

                If AFlag = False Then
                    Using cmd As New SqlCommand("SELECT C_Count=1,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MAX(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                Else
                    Using cmd As New SqlCommand("SELECT C_Count=CASE WHEN KolCount<=" & ListDiscount(i).Kol & " THEN " & ListDiscount(i).Kol & "/KolCount ELSE 0 END,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MIN(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                End If

                If dt.Rows.Count <= 0 Then
                    Continue For
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                End If
            Next i

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return False
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreCalKalaDiscount")
            Return False
        End Try
    End Function

    Private Sub ChkFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFrosh.CheckedChanged
        If ChkFrosh.Checked = True Then
            TxtIdFactor.Enabled = True
            TxtIdFactor.Focus()
        Else
            TxtIdFactor.Enabled = False
            TxtIdFactor.Text = ""
        End If
    End Sub

    Private Sub TxtIdFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdFactor.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Back Then e.Handled = True
    End Sub

    Private Sub TxtIdFactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdFactor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Factor_List
        frmlk.str = "SELECT ListFactorSell.IdFactor, ListFactorSell.D_date,ListFactorSell.IdName, Define_People.Nam FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtIdFactor.Focus()
        If IdKala <> 0 Then
            TxtIdFactor.Text = IdKala
        End If
    End Sub

    Private Sub ChkFrosh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFrosh.GotFocus
        ChkFrosh.BackColor = Color.LightGray
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged

    End Sub

    Private Sub ChkFrosh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkFrosh.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtIdFactor.Enabled = True Then
                TxtIdFactor.Focus()
            Else
                TxtSanad.Focus()
            End If
        End If
    End Sub

    Private Sub ChkFrosh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFrosh.LostFocus
        ChkFrosh.BackColor = Me.BackColor
    End Sub

    Private Sub BtnSCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSCost.Click
        Try
            If CmbFac.Text <> CmbFac.Items.Item(3) Then
                BtnKalaDiscount.Enabled = False
                Exit Sub
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If String.IsNullOrEmpty(TxtIdPeople.Text) Then
                MessageBox.Show("طرف حسابی جهت اعمال قیمت ویژه انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If

            If AreYouExistGroup(TxtIdPeople.Text) = False Then
                MessageBox.Show("گروه ویژه ایی برای طرف حساب مورد نظر انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Exit Sub
            End If

            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Exit Sub
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Exit Sub
                    End If
                End If
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If
                Next
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Array.Resize(Alldiscount, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    End If
                End If
            Next
            CalScost(Alldiscount, GetIdGroup(TxtIdPeople.Text))
            CalculateAllRowMoney()
            BtnSCost.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "BtnSCost_Click")
        End Try
    End Sub

    Private Function AreQustionForSCost() As Boolean
        Try
            Array.Resize(Alldiscount, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    End If
                End If
            Next
            Return AreCalScost(Alldiscount, GetIdGroup(TxtIdPeople.Text))
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreQustionForSCost")
            Return False
        End Try
    End Function
    Private Sub CalScost(ByVal ListDiscount() As KalaDiscount, ByVal IdGroup As Long)
        Try
            Dim Fe As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            For i As Integer = 0 To ListDiscount.Length - 1
                Fe.Clear()
                Using cmd As New SqlCommand("SELECT ISNULL (MAX(FeKol ),0) as Fe ,ISNULL (MAX(Darsad ),0) as Darsad FROM (SELECT TOP 1 DefineListPromotion.Darsad  ,DefinePromotion.Fe AS FeKol FROM DefineListPromotion INNER JOIN DefinePromotion ON DefineListPromotion.IdLink = DefinePromotion.Id WHERE IdGroup =" & IdGroup & " AND IdKala =" & ListDiscount(i).Idkala & " AND AzKala <=" & ListDiscount(i).Kol & " AND TaKala >=" & ListDiscount(i).Kol & " ORDER BY TaKala DESC ) AS SCost", ConectionBank)
                    Fe.Load(cmd.ExecuteReader)
                End Using
                If Fe.Rows.Count <= 0 Then Continue For
                For j As Integer = 0 To DGV1.RowCount - 2
                    If Not (DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات") Then
                        If DGV1.Item("Cln_Code", j).Value = ListDiscount(i).Idkala Then
                            If Fe.Rows(0).Item("Fe") = 0 And Fe.Rows(0).Item("Darsad") = 0 Then Continue For
                            DGV1.Item("Cln_Fe", j).Value = IIf(Fe.Rows(0).Item("Fe") = 0, 0, FormatNumber(Fe.Rows(0).Item("Fe"), 0))
                            DGV1.Item("Cln_Darsad", j).Value = Fe.Rows(0).Item("Darsad").ToString.Replace(".", "/")
                        End If
                    End If
                Next
            Next i
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "CalSCost")
        End Try
    End Sub
    Private Function AreCalScost(ByVal ListDiscount() As KalaDiscount, ByVal IdGroup As Long) As Boolean
        Try
            Dim Fe As Double = 0
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            For i As Integer = 0 To ListDiscount.Length - 1
                Fe = -1
                Using cmd As New SqlCommand("SELECT ISNULL (SUM(Fe),-1) as Fe FROM (SELECT TOP 1 DefineListPromotion.Fe FROM DefineListPromotion INNER JOIN DefinePromotion ON DefineListPromotion.IdLink = DefinePromotion.Id WHERE IdGroup =" & IdGroup & " AND IdKala =" & ListDiscount(i).Idkala & " AND AzKala <=" & ListDiscount(i).Kol & " AND TaKala >=" & ListDiscount(i).Kol & " ORDER BY TaKala DESC ) AS SCost", ConectionBank)
                    Fe = cmd.ExecuteScalar
                End Using
                If Fe <= -1 Then
                    Continue For
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                End If

            Next i
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return False
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreCalScost")
            Return False
        End Try
    End Function

    Private Sub BtnSelectKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectKala.Click
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        If Mojody = False Then
            Dim frmlk As New Kala_Anbar_List
            frmlk.TxtSearch.Text = ""
            'Dim myCulture As New Globalization.CultureInfo("fa-IR")
            'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
            frmlk.ShowDialog()
            'myCulture = New Globalization.CultureInfo("en-us")
            'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
        Else
            Dim frmlk As New Kala_Anbar_List_M
            frmlk.TxtSearch.Text = ""
            'Dim myCulture As New Globalization.CultureInfo("fa-IR")
            'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
            frmlk.ShowDialog()
            'myCulture = New Globalization.CultureInfo("en-us")
            'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
        End If

        DGV1.Focus()
        If Tmp_Namkala <> "" Then

            If KalDup = True Then
                Dim intcount As Integer = 0
                For Each Row As DataGridViewRow In DGV1.Rows
                    If DGV1.Rows(intcount).Cells("Cln_code").Value = IdKala And DGV1.Rows(intcount).Cells("cln_type").Value <> "کالای خدماتی" Then
                        DGV1.Item("Cln_KolCount", intcount).Value = (CDbl(DGV1.Item("Cln_KolCount", intcount).Value) + If(DK_KOL <= 0, 1, DK_KOL)).ToString.Replace(".", "/")
                        DGV1.Item("Cln_JozCount", intcount).Value = (CDbl(DGV1.Item("Cln_JozCount", intcount).Value) + DK_JOZ).ToString.Replace(".", "/")
                        CalculateAllRowMoney()
                        DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                        Exit Sub
                    Else
                        intcount += 1
                    End If
                Next Row
            End If

            DGV1.AllowUserToAddRows = False
            DGV1.Rows.Add()
            DGV1.Item("cln_type", DGV1.RowCount - 1).Value = Tmp_OneGroup + " - " + Tmp_TwoGroup
            DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = Tmp_Namkala
            DGV1.Item("Cln_vahed", DGV1.RowCount - 1).Value = TmpVahed
            DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = 0
            DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = 0
            DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = namAnbar
            DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = 0
            DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = ""
            DGV1.Item("Cln_code", DGV1.RowCount - 1).Value = IdKala
            DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = Idanbar
            DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = DK
            DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = DK_KOL
            DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = DK_JOZ
            If CmbFac.Text = CmbFac.Items.Item(3) Then
                DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = FormatNumber(GetCostFrosh_Barcode(IdKala, IIf(String.IsNullOrEmpty(TxtIdCityFac.Text), 0, TxtIdCityFac.Text), IIf(String.IsNullOrEmpty(TxtIdPeople.Text), 0, TxtIdPeople.Text)), 0)
                IIf(String.IsNullOrEmpty(DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value), 0, DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value)
            ElseIf CmbFac.Text = CmbFac.Items.Item(0) Then
                DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = GetCostKharid(IdKala)
                IIf(String.IsNullOrEmpty(DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value), 0, DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value)
            Else
                DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = 0
            End If
            If CmbFac.Text = CmbFac.Items.Item(3) Then
                DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = If(DK_KOL <= 0, 1, DK_KOL)
                DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = DK_JOZ
            Else
                DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = 0
            End If
            DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = False
            DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Selected = True
            DGV1.AllowUserToAddRows = True
            DGV1.Focus()
            DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
            CalculateAllRowMoney()
        End If
    End Sub
    Private Sub AreKalaDup()
        Try
            Dim Kala As Boolean = False
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Using cmd As New SqlCommand("SELECT KalaDup,Fish FROM SettingProgram WHERE IdUser =" & Id_User, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                KalDup = dtr("KalaDup")
                Fish = dtr("Fish")
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor_Barcode", "AreKalaDup")
        End Try
    End Sub

    Private Sub CheckLimit()
        If LimitDate = True Then TxtDate.Enabled = False
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If LimitMonFac = True Then
            DGV1.Columns("Cln_Fe").ReadOnly = True
            DGV1.Columns("Cln_Fe").DefaultCellStyle.BackColor = Color.Gainsboro
        Else
            DGV1.Columns("Cln_Fe").ReadOnly = False
            DGV1.Columns("Cln_Fe").DefaultCellStyle.BackColor = Nothing
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If LimitHajm = True Then
            DGV1.Columns("Cln_Darsad").ReadOnly = True
            DGV1.Columns("Cln_Darsad").DefaultCellStyle.BackColor = Color.Gainsboro
        Else
            If CmbFac.Text <> CmbFac.Items.Item(6) Then
                DGV1.Columns("Cln_Darsad").ReadOnly = False
                DGV1.Columns("Cln_Darsad").DefaultCellStyle.BackColor = Nothing
            End If
        End If
    End Sub
End Class