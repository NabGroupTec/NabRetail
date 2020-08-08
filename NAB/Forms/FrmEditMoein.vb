Imports System.Data.SqlClient
Imports System.Transactions

Public Class FrmEditMoein
    Public StrSql As String
    Dim Iddaramad, IdCharge As Long

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub TxtCharge_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCharge.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub
    Private Sub TxtCharge_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCharge.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If RdoCharge.Checked = True Then
            Dim frmlk As New Charge_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            e.Handled = True
            TxtCharge.Focus()
            If Tmp_Namkala <> "" Then
                TxtCharge.Text = Tmp_Namkala
                TxtIdCharge.Text = IdKala
            Else
                TxtCharge.Text = ""
                TxtIdCharge.Text = ""
            End If
        ElseIf RdoDaramad.Checked = True Then
            Dim frmlk As New Daramad_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            e.Handled = True
            TxtCharge.Focus()
            If Tmp_Namkala <> "" Then
                TxtCharge.Text = Tmp_Namkala
                TxtIdCharge.Text = IdKala
            Else
                TxtCharge.Text = ""
                TxtIdCharge.Text = ""
            End If
        End If
    End Sub

    Private Sub FrmEditMoein_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtCharge.Focus()
    End Sub

    Private Sub FrmEditMoein_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmEditMoein_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If String.IsNullOrEmpty(LEdit.Text) Then
            TxtDate.ThisText = GetDate()
            RdoCharge.Checked = True
        Else
            ShowEditMoein()
        End If
        DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه طرف حسابهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        DGV.Rows.Clear()
    End Sub

    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{Tab}")
            Case Keys.Delete
                e.Handled = True
                If DGV.CurrentRow.Index <> DGV.RowCount - 1 Then
                    DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
                Else
                    DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_moein", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Edit", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = ""
                End If
                Me.CalculateMoney()
        End Select
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        Try
            If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_Name", DGV.CurrentRow.Index).Selected = True
            CalculateMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = "" Then
            e.Handled = True
            DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = ""
            DGV.Item("Cln_moein", DGV.CurrentRow.Index).Value = ""
            DGV.Item("Cln_Edit", DGV.CurrentRow.Index).Value = ""
            DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value = ""
            DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = ""
            Exit Sub
        End If

        If e.KeyCode = Keys.Space Then
            If DGV.CurrentCell.ColumnIndex = 2 And DGV.Item("Cln_name", DGV.CurrentRow.Index).Value <> "" Then
                DGV.Item("Cln_Edit", DGV.CurrentRow.Index).Value = IIf(CDbl(DGV.Item("Cln_moein", DGV.CurrentRow.Index).Value) < 0, FormatNumber(CDbl(DGV.Item("Cln_moein", DGV.CurrentRow.Index).Value) * -1, 0), FormatNumber(CDbl(DGV.Item("Cln_moein", DGV.CurrentRow.Index).Value), 0))
                SendKeys.Send("{ENTER}")
            End If
        End If
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Using frmlk As New People_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
            End Using
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                Dim moein As Double = GetMoeinPeople(IdKala)
                DGV.AllowUserToAddRows = False
                DGV.Rows.Add()
                DGV.AllowUserToAddRows = True
                DGV.Item("Cln_Name", DGV.RowCount - 2).Value = Tmp_Namkala
                DGV.Item("Cln_IdP", DGV.RowCount - 2).Value = IdKala
                DGV.Item("Cln_moein", DGV.RowCount - 2).Value = IIf(moein <> 0, FormatNumber(moein, 0), moein)
                DGV.Item("Cln_Edit", DGV.RowCount - 2).Value = IIf(moein >= 0, DGV.Item("Cln_moein", DGV.RowCount - 2).Value, FormatNumber(moein * (-1), 0))
                DGV.Item("Cln_Id", DGV.RowCount - 2).Value = 0
                DGV.Item("Cln_Name", DGV.RowCount - 2).Selected = False
                DGV.Item("cln_Edit", DGV.RowCount - 2).Selected = True
            Else
                DGV.Item("Cln_Name", DGV.CurrentRow.Index).Selected = True
            End If
        End If

        If DGV.CurrentCell.ColumnIndex = 2 Then
            If DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value = "" Then
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
        End If
    End Sub

    Private Sub CalculateMoney()
        Dim allmoney As Double = 0
        For i As Integer = 0 To DGV.Rows.Count - 2
            allmoney += If(DGV.Item("cln_Edit", i).Value Is DBNull.Value Or DGV.Item("cln_Edit", i).Value.ToString.Equals(""), 0, CDbl(DGV.Item("cln_Edit", i).Value))
        Next
        If allmoney.ToString.Length > 3 Then
            Txtallmoney.Text = Format(allmoney, "###,###")
        Else
            Txtallmoney.Text = allmoney
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value = "" Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    Exit Sub
                End If

                If txt_dgv.Text < 0 Then txt_dgv.Text = CDbl(txt_dgv.Text) * -1

                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdvance.Click
        Using FrmAdVance As New PeopleMoein_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    DGV.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV.Rows.Add()
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = AllSelectKala(i).Namekala
                        DGV.Item("cln_moein", DGV.RowCount - 1).Value = IIf(AllSelectKala(i).CostSkala = 0, 0, FormatNumber(Math.Abs(AllSelectKala(i).CostSkala), 0))
                        DGV.Item("cln_Edit", DGV.RowCount - 1).Value = IIf(AllSelectKala(i).CostSkala = 0, 0, FormatNumber(Math.Abs(AllSelectKala(i).CostSkala), 0))
                        DGV.Item("Cln_IdP", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                    Next
                    DGV.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
                Me.CalculateMoney()
            Catch ex As Exception
                DGV.Rows.Clear()
                DGV.AllowUserToAddRows = True
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub RdoCharge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCharge.CheckedChanged
        If RdoCharge.Checked = True Then
            LName.Text = "نام هزینه"
            TxtCharge.Text = ""
            TxtIdCharge.Text = ""
            TxtCharge.Focus()
        End If
    End Sub

    Private Sub RdoDaramad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDaramad.CheckedChanged
        If RdoDaramad.Checked = True Then
            LName.Text = "نام درآمد"
            TxtCharge.Text = ""
            TxtIdCharge.Text = ""
            TxtCharge.Focus()
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AslaheTarafHesab.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnAdvance.Enabled = True Then Call BtnAdvance_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If String.IsNullOrEmpty(TxtDate.ThisText) Then
            MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtDate.Focus()
            Exit Sub
        End If

        If RdoCharge.Checked = True Then
            If String.IsNullOrEmpty(TxtCharge.Text.Trim) Then
                MessageBox.Show("نوع هزینه را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCharge.Focus()
                Exit Sub
            End If
        End If

        If RdoDaramad.Checked = True Then
            If String.IsNullOrEmpty(TxtCharge.Text.Trim) Then
                MessageBox.Show("نوع درآمد را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCharge.Focus()
                Exit Sub
            End If
        End If

        If DGV.Item("Cln_name", DGV.RowCount - 1).Value <> "" Then
            MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If DGV.RowCount <= 1 Then
            MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            For i As Integer = 0 To DGV.RowCount - 2

                If DGV.Item("Cln_name", i).Value = "" Then
                    MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If CDbl(DGV.Item("cln_Edit", i).Value.ToString) <= 0 Then
                    MessageBox.Show(" مبلغ اصلاحیه سطر شماره" & "{ " & i + 1 & " }" & "  وارد كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next i
        End If


        For i As Integer = 0 To DGV.RowCount - 2
            Dim count As Integer = 0
            For j As Integer = 0 To DGV.RowCount - 2
                If (DGV.Item("Cln_IdP", i).Value.ToString = DGV.Item("Cln_IdP", j).Value.ToString) Then
                    count += 1
                End If
                If count > 1 Then
                    MessageBox.Show("نام طرف حساب سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا آن را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next j
        Next i
        If String.IsNullOrEmpty(LEdit.Text) Then
            Me.SaveCharge()
        ElseIf LEdit.Text = "1" Then
            Me.EditCharge()
        End If
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub SaveCharge()
        Dim sqltransaction As New CommittableTransaction
        Dim IdFac As Long = 0
        Dim Idlend As Long = 0
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '''''''''''''''''''''''''''''''''''''''ثبت هزینه
            If RdoCharge.Checked = True Then
                Using Cmd As New SqlCommand("INSERT INTO  ListOtherCharge (D_date,IdUser,Disc,Activ,Discount,Cash,MonHavaleh,MonSellChk,MonPayChk,Lend,EditFlag,Sanad) VALUES(@D_date,@IdUser,@Disc,@Activ,@Discount,@Cash,@MonHavaleh,@MonSellChk,@MonPayChk,@Lend,@EditFlag,@Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "اصلاحیه" & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", "-" & TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = ""
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO KalaOtherCharge (IdSanad,IdCharge,Mon,CDisc) VALUES(@IdSanad,@IdCharge,@Mon,@CDisc)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = IdFac
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@CDisc", SqlDbType.NVarChar).Value = "اصلاحیه" & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", "-" & TxtDisc.Text.Trim)
                    Cmd.ExecuteNonQuery()
                End Using

                ''/////////////////////////////////////////////////
                Using Cmd As New SqlCommand("INSERT INTO  ListEditMoein (D_date,IdUser,IdCharge,IdDaramad,Disc,mon,IdSCharge,IdSDaramad,EditFlag) VALUES(@D_date,@IdUser,@IdCharge,@IdDaramad,@Disc,@mon,@IdSCharge,@IdSDaramad,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@IdSCharge", SqlDbType.BigInt).Value = IdFac
                    Cmd.Parameters.AddWithValue("@IdSDaramad", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                    IdFac = Cmd.ExecuteScalar
                End Using

                For i As Integer = 0 To DGV.RowCount - 2
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "اصلاحیه شماره  " & IdFac & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 16
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                        Idlend = Cmd.ExecuteScalar
                    End Using
                    Using Cmd As New SqlCommand("INSERT INTO ListEditPMoein (IdP,EMon,IdMoein,IdLink) VALUES(@IdP,@EMon,@IdMoein,@IdLink)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdP", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@EMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdMoein", SqlDbType.BigInt).Value = Idlend
                        Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = IdFac
                        Cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
            '''''''''''''''''''''''''''''''''''''''ثبت درآمد
            If RdoDaramad.Checked = True Then
                Using Cmd As New SqlCommand("INSERT Get_Daramad (D_date,Idname,IdUser,Active,EditFlag,Cash,MonHavaleh,IdBankHavaleh,DiscHavaleh,MonPayChk,DiscChk,Lend,IdSanadLend,DiscLend,IdBoxMoein,IdBox,IdBankMoein,AllDisc,DiscCash,IdDaramad) VALUES(@D_date,@Idname,@IdUser,@Active,@EditFlag,@Cash,@MonHavaleh,@IdBankHavaleh,@DiscHavaleh,@MonPayChk,@DiscChk,@Lend,@IdSanadLend,@DiscLend,@IdBoxMoein,@IdBox,@IdBankMoein,@AllDisc,@DiscCash,@IdDaramad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Idname", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = "اصلاحیه" & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", "-" & TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    IdFac = Cmd.ExecuteScalar
                End Using
                ''''
                ''/////////////////////////////////////////////////
                Using Cmd As New SqlCommand("INSERT INTO  ListEditMoein (D_date,IdUser,IdCharge,IdDaramad,Disc,mon,IdSCharge,IdSDaramad,EditFlag) VALUES(@D_date,@IdUser,@IdCharge,@IdDaramad,@Disc,@mon,@IdSCharge,@IdSDaramad,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@IdSCharge", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdSDaramad", SqlDbType.BigInt).Value = IdFac
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                    IdFac = Cmd.ExecuteScalar
                End Using

                For i As Integer = 0 To DGV.RowCount - 2
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "اصلاحیه شماره  " & IdFac & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 15
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                        Idlend = Cmd.ExecuteScalar
                    End Using
                    Using Cmd As New SqlCommand("INSERT INTO ListEditPMoein (IdP,EMon,IdMoein,IdLink) VALUES(@IdP,@EMon,@IdMoein,@IdLink)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdP", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@EMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdMoein", SqlDbType.BigInt).Value = Idlend
                        Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = IdFac
                        Cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اصلاحیه طرف حساب", "ثبت", "ثبت اصلاحیه :" & IdFac, "")
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditMoein", "SaveCharge")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
        End Try
    End Sub

    Private Sub EditCharge()
        Dim sqltransaction As New CommittableTransaction
        Dim IdFac As Long = 0
        Dim Idlend As Long = 0
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '''''''''''''''''''''''''''''''''''''''ویرایش هزینه
            If RdoCharge.Checked = True Then
                Using Cmd As New SqlCommand("UPDATE ListOtherCharge SET  D_date=@D_date,IdUser=@IdUser,Disc=@Disc,Lend=@Lend WHERE Id=@Id", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "اصلاحیه" & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", "-" & TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = IdCharge
                    Cmd.ExecuteNonQuery()
                End Using

                Using Cmd As New SqlCommand("UPDATE KalaOtherCharge SET IdCharge=@IdCharge,Mon=@Mon,CDisc=@CDisc  WHERE IdSanad=@IdSanad", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = IdCharge
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@CDisc", SqlDbType.NVarChar).Value = "اصلاحیه" & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", "-" & TxtDisc.Text.Trim)
                    Cmd.ExecuteNonQuery()
                End Using

                ''/////////////////////////////////////////////////
                Using Cmd As New SqlCommand("Update ListEditMoein SET D_date=@D_date,IdUser=@IdUser,IdCharge=@IdCharge,IdDaramad=@IdDaramad,Disc=@Disc,mon=@mon,EditFlag=@EditFlag WHERE Id=@Id", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CDbl(LSanad.Text)
                    Cmd.ExecuteNonQuery()
                End Using

                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE Id IN (SELECT IdMoein FROM ListEditPMoein WHERE IdLink =" & CLng(LSanad.Text) & ");DELETE FROM ListEditPMoein WHERE IdLink=" & CLng(LSanad.Text), ConectionBank)
                    Cmd.ExecuteNonQuery()
                End Using

                For i As Integer = 0 To DGV.RowCount - 2
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "اصلاحیه شماره  " & LSanad.Text & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 16
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                        Idlend = Cmd.ExecuteScalar
                    End Using
                    Using Cmd As New SqlCommand("INSERT INTO ListEditPMoein (IdP,EMon,IdMoein,IdLink) VALUES(@IdP,@EMon,@IdMoein,@IdLink)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdP", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@EMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdMoein", SqlDbType.BigInt).Value = Idlend
                        Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
            '''''''''''''''''''''''''''''''''''''''ثبت درآمد
            If RdoDaramad.Checked = True Then
                Using Cmd As New SqlCommand("UPDATE Get_Daramad SET D_date=@D_date,IdUser=@IdUser,Lend=@Lend,AllDisc=@AllDisc,IdDaramad=@IdDaramad WHERE Id=@Id", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = "اصلاحیه" & If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", "-" & TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Iddaramad
                    Cmd.ExecuteNonQuery()
                End Using
                ''''
                ''/////////////////////////////////////////////////

                Using Cmd As New SqlCommand("Update ListEditMoein SET D_date=@D_date,IdUser=@IdUser,IdCharge=@IdCharge,IdDaramad=@IdDaramad,Disc=@Disc,mon=@mon,EditFlag=@EditFlag WHERE Id=@Id", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdCharge.Text)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CDbl(LSanad.Text)
                    Cmd.ExecuteNonQuery()
                End Using

                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE Id IN (SELECT IdMoein FROM ListEditPMoein WHERE IdLink =" & CLng(LSanad.Text) & ");DELETE FROM ListEditPMoein WHERE IdLink=" & CLng(LSanad.Text), ConectionBank)
                    Cmd.ExecuteNonQuery()
                End Using

                For i As Integer = 0 To DGV.RowCount - 2
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "اصلاحیه شماره  " & LSanad.Text & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 15
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                        Idlend = Cmd.ExecuteScalar
                    End Using
                    Using Cmd As New SqlCommand("INSERT INTO ListEditPMoein (IdP,EMon,IdMoein,IdLink) VALUES(@IdP,@EMon,@IdMoein,@IdLink)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdP", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@EMon", SqlDbType.BigInt).Value = CDbl(DGV.Item("cln_Edit", i).Value.ToString)
                        Cmd.Parameters.AddWithValue("@IdMoein", SqlDbType.BigInt).Value = Idlend
                        Cmd.Parameters.AddWithValue("@IdLink", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اصلاحیه طرف حساب", "ویرایش", "ویرایش اصلاحیه :" & LSanad.Text, "")
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditMoein", "EditCharge")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
        End Try
    End Sub
    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtCharge.Focus()
    End Sub
    Private Sub ShowEditMoein()
        Try
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using SQLComanad As New SqlCommand("SELECT D_Date,Disc,IdSCharge,IdSDaramad,IdCharge ,IdDaramad,NamCharge=(Select nam FROM Define_Charge WHERE Define_Charge.ID =IdCharge),NamDaramad=(Select nam FROM Define_Daramad WHERE Define_Daramad.ID =IdDaramad) FROM ListEditMoein WHERE Id =" & CLng(LSanad.Text), ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
            End Using

            If Not dtrInfo.HasRows Then
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Me.Close()
            Else
                dtrInfo.Read()

                TxtDate.ThisText = dtrInfo("D_Date")
                TxtDisc.Text = If(dtrInfo("Disc") Is DBNull.Value, "", dtrInfo("Disc"))

                If Not (dtrInfo("IdCharge") Is DBNull.Value) Then
                    RdoCharge.Checked = True
                    TxtIdCharge.Text = dtrInfo("IdCharge")
                    TxtCharge.Text = dtrInfo("NamCharge")
                    IdCharge = dtrInfo("IdSCharge")
                    Iddaramad = 0
                End If

                If Not (dtrInfo("IdDaramad") Is DBNull.Value) Then
                    RdoDaramad.Checked = True
                    TxtIdCharge.Text = dtrInfo("IdDaramad")
                    TxtCharge.Text = dtrInfo("NamDaramad")
                    IdCharge = 0
                    Iddaramad = dtrInfo("IdSDaramad")
                End If
            End If

            dtrInfo.Close()

            Using SQLComanad As New SqlCommand("SELECT ListEditPMoein.IdP, ListEditPMoein.Emon, Define_People.Nam FROM ListEditPMoein INNER JOIN Define_People ON ListEditPMoein.IdP = Define_People.ID WHERE IdLink =" & CLng(LSanad.Text), ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    DGV.AllowUserToAddRows = False
                    While dtrInfo.Read
                        DGV.Rows.Add()
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = dtrInfo("Nam")
                        DGV.Item("Cln_moein", DGV.RowCount - 1).Value = ""
                        DGV.Item("Cln_Edit", DGV.RowCount - 1).Value = FormatNumber(dtrInfo("Emon"), 0)
                        DGV.Item("Cln_IdP", DGV.RowCount - 1).Value = dtrInfo("IdP")
                    End While
                    DGV.AllowUserToAddRows = True
                End If
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If RdoCharge.Checked = True Then
                For i As Integer = 0 To DGV.RowCount - 2
                    DGV.Item("Cln_moein", i).Value = FormatNumber(GetMoeinPeopleDate(DGV.Item("Cln_IdP", i).Value, TxtDate.ThisText, "=") + CDbl(DGV.Item("Cln_Edit", i).Value), 0)
                    If String.IsNullOrEmpty(DGV.Item("Cln_moein", i).Value) Then DGV.Item("Cln_moein", i).Value = 0
                Next
            End If

            If RdoDaramad.Checked = True Then
                For i As Integer = 0 To DGV.RowCount - 2
                    DGV.Item("Cln_moein", i).Value = FormatNumber(GetMoeinPeopleDate(DGV.Item("Cln_IdP", i).Value, TxtDate.ThisText, "=") - CDbl(DGV.Item("Cln_Edit", i).Value), 0)
                    If String.IsNullOrEmpty(DGV.Item("Cln_moein", i).Value) Then DGV.Item("Cln_moein", i).Value = 0
                Next
            End If

            RdoCharge.Enabled = False
            RdoDaramad.Enabled = False

            CalculateMoney()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditMoein", "ShowEditMoein")
            Me.Close()
        End Try
    End Sub
End Class