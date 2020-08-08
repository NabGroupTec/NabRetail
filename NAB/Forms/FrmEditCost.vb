Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmEditCost

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub TxtSmall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSmall.KeyDown
        If e.KeyCode = Keys.Enter Then TxtBig.Focus()
    End Sub

    Private Sub TxtSmall_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSmall.KeyPress
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

    Private Sub TxtSmall_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSmall.TextChanged
        If Not (CheckDigit(Format$(TxtSmall.Text.Replace(",", "")))) Then
            TxtSmall.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtSmall.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtSmall.Text.Replace(",", ""))
            TxtSmall.Text = Format$(Val(str), "###,###,###")
        Else
            TxtSmall.Text = CDbl(TxtSmall.Text)
        End If
    End Sub

    Private Sub TxtBig_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBig.KeyDown
        If e.KeyCode = Keys.Enter Then TxtEndCost.Focus()
    End Sub

    Private Sub TxtBig_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBig.KeyPress
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

    Private Sub TxtBig_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBig.TextChanged
        If Not (CheckDigit(Format$(TxtBig.Text.Replace(",", "")))) Then
            TxtBig.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtBig.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtBig.Text.Replace(",", ""))
            TxtBig.Text = Format$(Val(str), "###,###,###")
        Else
            TxtBig.Text = CDbl(TxtBig.Text)
        End If
    End Sub

    Private Sub TxtKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKala.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSmall.Focus()
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
                    DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_City", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_IdOstan", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value = ""
                End If
        End Select
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then e.Handled = True
            If DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value = "" Then
                e.Handled = True
                DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_City", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_IdOstan", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 1 Then
            e.Handled = True
            Using frmlk As New City_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
            End Using
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                DGV.AllowUserToAddRows = False
                DGV.Rows.Add()
                DGV.Item("Cln_City", DGV.RowCount - 1).Value = Tmp_Namkala
                DGV.Item("Cln_IdCity", DGV.RowCount - 1).Value = IdKala

                DGV.Item("Cln_Ostan", DGV.RowCount - 1).Value = Tmp_OneGroup
                DGV.Item("Cln_IdOstan", DGV.RowCount - 1).Value = CLng(Tmp_Mon)
                DGV.AllowUserToAddRows = True
                DGV.Item("Cln_City", DGV.RowCount - 1).Selected = True
            Else
                DGV.Item("Cln_City", DGV.RowCount - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub TxtKala_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKala.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtKala.Focus()
        If Tmp_Namkala <> "" Then
            TxtKala.Text = Tmp_Namkala
            TxtIdkala.Text = IdKala
        Else
            TxtKala.Text = ""
            TxtIdkala.Text = ""
        End If
    End Sub

    Private Sub FrmEditCost_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtKala.Focus()
    End Sub

    Private Sub FrmEditCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmEditCost_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV.Columns("Cln_City").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه شهرستانهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        DGV.Rows.Clear()
    End Sub

    Private Sub BtnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdvance.Click
        Using FrmAdVance As New City_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    DGV.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV.Rows.Add()
                        DGV.Item("Cln_City", DGV.RowCount - 1).Value = AllSelectKala(i).Namekala
                        DGV.Item("Cln_Ostan", DGV.RowCount - 1).Value = AllSelectKala(i).OneGroup
                        DGV.Item("Cln_IdCity", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                        DGV.Item("Cln_IdOstan", DGV.RowCount - 1).Value = AllSelectKala(i).Id
                    Next
                    DGV.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
            Catch ex As Exception
                DGV.Rows.Clear()
                DGV.AllowUserToAddRows = True
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtKala.Text.Trim) Or String.IsNullOrEmpty(TxtIdkala.Text) Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtKala.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtSmall.Text.Trim) Then
                MessageBox.Show("قیمت خرده را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtSmall.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtBig.Text.Trim) Then
                MessageBox.Show("قیمت عمده را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtBig.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtEndCost.Text.Trim) Then
                MessageBox.Show("قیمت مصرف کننده را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtEndCost.Focus()
                Exit Sub
            End If

            If CDbl(TxtEndCost.Text) <= 0 And CDbl(TxtSmall.Text) <= 0 And CDbl(TxtBig.Text) <= 0 Then
                MessageBox.Show("قیمت خرده،عمده و یا مصرف کننده را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBig.Focus()
                Exit Sub
            End If

            If DGV.Item("Cln_Ostan", DGV.RowCount - 1).Value <> "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV.RowCount <= 1 Then
                MessageBox.Show("شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2

                    If DGV.Item("Cln_Ostan", i).Value = "" OR DGV.Item("Cln_City", i).Value = "" Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_IdCity", i).Value.ToString = DGV.Item("Cln_IdCity", j).Value.ToString) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("نام شهرستان سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i
            End If

            Me.Enabled = False

            If Me.SaveCost() = False Then
                Me.Enabled = True
                Exit Sub
            End If

            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditCost", "BtnSave_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Function SaveCost() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("Update Define_CostKala SET CostSmalKala=@CostSmalKala,CostBigKala=@CostBigKala,EndCost=@EndCost WHERE IdKala=@IdKala AND IdCity=@IdCity", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                    Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdCity", i).Value)
                    Cmd.Parameters.AddWithValue("@CostSmalKala", SqlDbType.BigInt).Value = CDbl(TxtSmall.Text)
                    Cmd.Parameters.AddWithValue("@CostBigKala", SqlDbType.BigInt).Value = CDbl(TxtBig.Text)
                    Cmd.Parameters.AddWithValue("@EndCost", SqlDbType.BigInt).Value = CDbl(TxtEndCost.Text)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            If ChkAddNew.Checked = True Then
                Dim dt1 As New DataTable
                Dim dt2 As New DataTable
                Dim row1() As DataRow = Nothing
                Dim row2() As DataRow = Nothing

                Using cmd1 As New SqlCommand("SELECT DISTINCT IdKala,IdCity FROM Define_CostKala", ConectionBank)
                    dt1.Load(cmd1.ExecuteReader)
                End Using

                Using cmd2 As New SqlCommand("SELECT IdCity FROM Define_CityCostkala", ConectionBank)
                    dt2.Load(cmd2.ExecuteReader)
                End Using

                For i As Integer = 0 To DGV.RowCount - 2
                    row1 = Nothing
                    row2 = Nothing
                    row1 = dt1.Select("IdKala=" & CLng(TxtIdkala.Text) & " AND IdCity=" & CLng(DGV.Item("Cln_IdCity", i).Value))
                    If row1.Length <= 0 Then
                        row2 = dt2.Select("IdCity=" & CLng(DGV.Item("Cln_IdCity", i).Value))
                        If row2.Length <= 0 Then
                            Using Cmd As New SqlCommand("INSERT INTO Define_CityCostkala(IdCity) VALUES(@IdCity)", ConectionBank)
                                Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdCity", i).Value)
                                Cmd.ExecuteNonQuery()
                            End Using
                            Using Cmd As New SqlCommand("INSERT INTO Define_CostKala(IdKala,IdCity,CostSmalKala,CostBigKala,EndCost) VALUES(@IdKala,@IdCity,@CostSmalKala,@CostBigKala,@EndCost)", ConectionBank)
                                Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                                Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdCity", i).Value)
                                Cmd.Parameters.AddWithValue("@CostSmalKala", SqlDbType.BigInt).Value = CDbl(TxtSmall.Text)
                                Cmd.Parameters.AddWithValue("@CostBigKala", SqlDbType.BigInt).Value = CDbl(TxtBig.Text)
                                Cmd.Parameters.AddWithValue("@EndCost", SqlDbType.BigInt).Value = CDbl(TxtEndCost.Text)
                                Cmd.ExecuteNonQuery()
                            End Using
                        Else
                            Using Cmd As New SqlCommand("INSERT INTO Define_CostKala (CostSmalKala,CostBigKala,EndCost,IdKala,IdCity) VALUES (@CostSmalKala,@CostBigKala,@EndCost,@IdKala,@IdCity)", ConectionBank)
                                Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                                Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdCity", i).Value)
                                Cmd.Parameters.AddWithValue("@CostSmalKala", SqlDbType.BigInt).Value = CDbl(TxtSmall.Text)
                                Cmd.Parameters.AddWithValue("@CostBigKala", SqlDbType.BigInt).Value = CDbl(TxtBig.Text)
                                Cmd.Parameters.AddWithValue("@EndCost", SqlDbType.BigInt).Value = CDbl(TxtEndCost.Text)
                                Cmd.ExecuteNonQuery()
                            End Using
                        End If
                    Else
                        Continue For
                    End If
                Next
            End If
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت در شهرستان", "تغییر قیمت", " تغییر قیمت کالای :" & TxtKala.Text, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditCost", "SaveCost")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Kalaoghimat.htm")
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

    Private Sub TxtEndCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEndCost.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtEndCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEndCost.KeyPress
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

    Private Sub TxtEndCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEndCost.TextChanged
        If Not (CheckDigit(Format$(TxtEndCost.Text.Replace(",", "")))) Then
            TxtEndCost.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtEndCost.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtEndCost.Text.Replace(",", ""))
            TxtEndCost.Text = Format$(Val(str), "###,###,###")
        Else
            TxtEndCost.Text = CDbl(TxtEndCost.Text)
        End If
    End Sub
End Class