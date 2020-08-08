Imports System.Data.SqlClient
Imports System.Transactions

Public Class EditKala_OneTime
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub Kala_OneTime_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DGV1.Focus()
    End Sub

    Private Sub Kala_OneTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnnew.Click
        Me.Close()
    End Sub
    
    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Try
            DGV1.CommitEdit(DataGridViewDataErrorContexts.RowDeletion)
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("کالایی برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Trim(DGV1.Item("Cln_Name", 0).Value) = "" Or Trim(DGV1.Item("Cln_anbar", 0).Value) = "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & 1 & " }" & "  معلوم نيست لطفا مقدار آن را مشخص کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Trim(DGV1.Item("Cln_Money", 0).Value) = "" Then
                MessageBox.Show(" جمع مبلغ سطر شماره" & "{ " & 1 & " }" & "  صفر است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If CDbl(DGV1.Item("Cln_Money", 0).Value.ToString) <= 0 Then
                MessageBox.Show(" جمع مبلغ سطر شماره" & "{ " & 1 & " }" & "  صفر است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Trim(DGV1.Item("Cln_Code", 0).Value) = "" Then
                MessageBox.Show(" کالای سطر شماره" & "{ " & 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", 0).Value <= 0 Then
                MessageBox.Show(" کالای سطر شماره" & "{ " & 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Trim(DGV1.Item("Cln_CodeAnbar", 0).Value) = "" Then
                MessageBox.Show(" انبار سطر شماره" & "{ " & 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_CodeAnbar", 0).Value <= 0 Then
                MessageBox.Show(" انبار سطر شماره" & "{ " & 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtKalaDate.ThisText) Then
                MessageBox.Show("لطفا تاریخ ورود کالا را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtKalaDate.Focus()
                Exit Sub
            End If

            LimitMojody()

            If CLng(LIdAnbar.Text) = CLng(DGV1.Item("Cln_CodeAnbar", 0).Value) And CLng(LIdkala.Text) = CLng(DGV1.Item("Cln_code", 0).Value) Then
                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", 0).Value), CDbl(DGV1.Item("Cln_Count", 0).Value) - CDbl(LKol.Text), CDbl(DGV1.Item("Cln_b", 0).Value) - CDbl(LJoz.Text), CLng(DGV1.Item("Cln_CodeAnbar", 0).Value)) Then
                    If MAnbar = True Then
                        If MessageBox.Show("کالا کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    Else
                        MessageBox.Show("کالا کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            Else
                If Not AreYouNativeKalaAnbar(CLng(LIdkala.Text), CDbl(LKol.Text), CDbl(LJoz.Text), CLng(LIdAnbar.Text)) Then
                    If MAnbar = True Then
                        If MessageBox.Show("کالای قبلی کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    Else
                        MessageBox.Show("کالای قبلی کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", 0).Value), CDbl(DGV1.Item("Cln_Count", 0).Value), CDbl(DGV1.Item("Cln_b", 0).Value), CLng(DGV1.Item("Cln_CodeAnbar", 0).Value)) Then
                    If MAnbar = True Then
                        If MessageBox.Show("کالای جدید کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    Else
                        MessageBox.Show("کالای جدید کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If

            If Me.SaveKala Then
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "EditKala_OneTime", "Btnsave_Click")
        End Try
    End Sub

    Private Sub DGV1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        txt_dgv = e.Control
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 41, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 41, e.RowBounds.Location.Y)
        End Using
    End Sub
    Private Function SaveKala() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("UPDATE  Define_PrimaryKala SET IdKala=@IdKala,IdAnbar=@IdAnbar,Count_Kol=@Count_Kol,Count_Joz=@Count_Joz,Fe=@Fe,Mon=@Mon,D_date=@D_date,IdUser=@IdUser WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", 0).Value)
                Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", 0).Value)
                Cmd.Parameters.AddWithValue("@Count_Kol", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Count", 0).Value)
                Cmd.Parameters.AddWithValue("@Count_Joz", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_B", 0).Value)
                Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Buy", 0).Value)
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Money", 0).Value)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.BigInt).Value = TxtKalaDate.ThisText
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = CLng(LID.Text)
                Cmd.Parameters.AddWithValue("@IDUser", SqlDbType.BigInt).Value = Id_User
                Cmd.ExecuteNonQuery()
            End Using
            If OkEnd() = False Then
                sqltransaction.Rollback()
                sqltransaction.Dispose()
                MessageBox.Show(" تعریف دو واحده بودن کالای مورد نظر تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "ویرایش", If(DGV1.Item("cln_name", 0).Value = Tmp_String1 And DGV1.Item("cln_Money", 0).Value = CDbl(Tmp_String2), "ویرایش کالای اول دوره :" & DGV1.Item("cln_name", 0).Value, "ویرایش کالای اول دوره از :" & Tmp_String1 & " با مبلغ" & Tmp_String2 & " به کالای " & DGV1.Item("cln_name", 0).Value & " با مبلغ" & FormatNumber(DGV1.Item("cln_Money", 0).Value, 0)), "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "EditKala_OneTime", "SaveKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function OkEnd() As Boolean
        Try
            Using Cmd As New SqlCommand("SELECT DK FROM Define_Kala WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", 0).Value)
                If CBool(Cmd.ExecuteScalar()) <> CBool(DGV1.Item("Cln_DK", 0).Value) Then
                    DGV1.Item("Cln_Name", 0).Selected = True
                    Return False
                End If
                Cmd.Parameters.Clear()
                Return True
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "EditKala_OneTime", "OkEnd")
            Return False
        End Try
    End Function
    
    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Try
            If e.ColumnIndex = 2 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If DGV1.Item("Cln_DK", e.RowIndex).Value = True Then
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                        Else
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                            SendKeys.Send("+{TAB}")
                        End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 3 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        SendKeys.Send("+{TAB}")
                        SendKeys.Send("+{TAB}")
                        SendKeys.Send("+{TAB}")
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 4 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        SendKeys.Send("+{TAB}")
                        SendKeys.Send("+{TAB}")
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_EditingControlShowing1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                e.Handled = True
                Exit Sub
            End If
            If Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV1.CurrentCell.ColumnIndex = 1 Then
            e.Handled = True
            Dim frmlk As New Kala_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = 0
                DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value = 0
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = 0
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = IdKala
                DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = Tmp_OneGroup + " - " + Tmp_TwoGroup
                DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = DK
                DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = DK_KOL
                DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = DK_JOZ
                '''''''''''''''''''''''''''''''''''''''''''''''''
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Selected = True
            Else
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Selected = True
            End If
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If DGV1.CurrentCell.ColumnIndex = 5 Then
            e.Handled = True
            If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then Exit Sub
            Dim frmlk As New Anbar_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = IdKala
                Try
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index + 1).Selected = True
                Catch ex As Exception
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Selected = True
                End Try
            Else
                Try
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index + 1).Selected = True
                Catch ex As Exception
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Selected = True
                End Try
            End If
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If DGV1.CurrentCell.ColumnIndex = 4 Then
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
        End If
        If DGV1.CurrentCell.ColumnIndex = 3 Then
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
        End If
        If DGV1.CurrentCell.ColumnIndex = 2 Then
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
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value = "" Then
                txt_dgv.Clear()
                Exit Sub
            End If

            If DGV1.CurrentCell.ColumnIndex = 4 Then
                If Not (CheckDigitWithOutpoint(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) <= 0 Then txt_dgv.Text = 0
                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_COUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value), "###,###")
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                ' txt_dgv.Text = CDbl(txt_dgv.Text)

                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    If String.IsNullOrEmpty(DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value) Then DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value), "###,###")
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) <= 0 Then txt_dgv.Text = 0
                ' txt_dgv.Text = CDbl(txt_dgv.Text)

                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_COUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value), "###,###")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{Tab}")
        End Select
    End Sub

    Private Sub DGV1_RowPostPaint1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 5)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        If DGV1.Item("Cln_DK", e.RowIndex).Value = False Then
            DGV1.Rows(e.RowIndex).Cells("Cln_b").Style.BackColor = Color.LightGray
        Else
            DGV1.Rows(e.RowIndex).Cells("Cln_b").Style.BackColor = Color.White
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Fnew = True
            Using Frmkala As New DefineKala
                Frmkala.ShowDialog()
            End Using
            Fnew = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "Button2_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnsave.Enabled = True Then Call Btnsave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
        If Btnnew.Enabled = True Then Call Btnnew_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub GetKala()
        Try
            Dim ds As New DataSet
            Dim str As String = "SELECT  Define_Anbar.nam As Anbar, Define_PrimaryKala.*, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo As GroupKala, Define_Kala.Nam AS NamKala,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE Define_PrimaryKala.Id=" & CLng(LID.Text)
            Dim dta As New SqlDataAdapter
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_PrimaryKala")
            DGV1.AutoGenerateColumns = False
            If ds.Tables("Define_PrimaryKala").Rows.Count > 0 Then
                DGV1.Rows.Add()
                DGV1.Item("Cln_name", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("Namkala")
                DGV1.Item("Cln_Count", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("Count_Kol").ToString.Replace(".", "/")
                DGV1.Item("Cln_Buy", 0).Value = FormatNumber(ds.Tables("Define_PrimaryKala").Rows(0).Item("FE"), 0)
                DGV1.Item("Cln_Money", 0).Value = Format$(ds.Tables("Define_PrimaryKala").Rows(0).Item("Mon"), "###,###")
                DGV1.Item("Cln_b", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("Count_Joz").ToString.Replace(".", "/")
                DGV1.Item("Cln_code", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("IdKala")

                DGV1.Item("cln_type", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("GroupKala")
                DGV1.Item("Cln_DK", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("DK")
                DGV1.Item("Cln_KOL", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("DK_KOL")
                DGV1.Item("Cln_JOZ", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("DK_JOZ")
                DGV1.Item("Cln_Anbar", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("Anbar")
                DGV1.Item("Cln_CodeAnbar", 0).Value = ds.Tables("Define_PrimaryKala").Rows(0).Item("IdAnbar")
                TxtKalaDate.ThisText = ds.Tables("Define_PrimaryKala").Rows(0).Item("D_date")

                LIdkala.Text = ds.Tables("Define_PrimaryKala").Rows(0).Item("IdKala")
                LKol.Text = ds.Tables("Define_PrimaryKala").Rows(0).Item("Count_Kol")
                LJoz.Text = ds.Tables("Define_PrimaryKala").Rows(0).Item("Count_Joz")
                LIdAnbar.Text = ds.Tables("Define_PrimaryKala").Rows(0).Item("IdAnbar")
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "EditKala_OneTime", "GetKala")
            Me.Close()
        End Try
    End Sub

    Private Sub EditKala_OneTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetKala()
    End Sub

End Class