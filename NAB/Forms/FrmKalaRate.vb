Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmKalaRate

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub TxtKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKala.KeyDown
        If e.KeyCode = Keys.Enter Then TxtBRate.Focus()
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
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Rate", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value = ""
                End If
        End Select
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_NamKala", DGV.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Dim frmlk As New Group_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.ShowDialog()
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = Tmp_Namkala
                DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value = IdKala
                DGV.Item("Cln_Rate", DGV.CurrentRow.Index).Value = 0

                DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Selected = False
                DGV.Item("Cln_Rate", DGV.CurrentRow.Index).Selected = True
            Else
                DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Selected = True
            End If
            Exit Sub
        End If

        ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزءکالا
        If DGV.CurrentCell.ColumnIndex = 1 Then
            If DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = "" Then
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

    Private Sub FrmDiscountKala_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtKala.Focus()
    End Sub

    Private Sub FrmDiscountKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmDiscountKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV.Columns("Cln_Namkala").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If EDIT.Text <> "0" Then
            InfoRate(EDIT.Text)
        End If
    End Sub

    Private Sub InfoRate(ByVal Id As Long)
        Try
            Dim dtr As SqlDataReader = Nothing

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT Define_ListKalaRate.Rate,Define_ListKalaRate.IdGroup, Define_Group_P.nam FROM Define_ListKalaRate INNER JOIN Define_Group_P ON Define_ListKalaRate.IdGroup = Define_Group_P.Id WHERE   Define_ListKalaRate.IdKalaLink=" & Id, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using
            If dtr.HasRows Then
                DGV.AllowUserToAddRows = False
                While dtr.Read
                    DGV.Rows.Add()
                    DGV.Item("Cln_Namkala", DGV.RowCount - 1).Value = dtr("nam")
                    DGV.Item("Cln_Rate", DGV.RowCount - 1).Value = dtr("Rate")
                    DGV.Item("Cln_Code", DGV.RowCount - 1).Value = dtr("IdGroup")
                End While
                DGV.AllowUserToAddRows = True
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Me.Close()
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKalaRate", "InfoRate")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        End Try
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

            If DGV.Item("Cln_Namkala", DGV.RowCount - 1).Value <> "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV.RowCount <= 1 Then
                MessageBox.Show("هیچ گروه ویژه ایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2
                    If DGV.Item("Cln_Namkala", i).Value = "" Or DGV.Item("Cln_Namkala", i).Value Is DBNull.Value Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                Next i
                '''''''''''''''''''''''''''''''''''''''
                For i As Integer = 0 To DGV.RowCount - 2
                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_Code", i).Value.ToString = DGV.Item("Cln_Code", j).Value.ToString) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("گروه ویژه سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i
            End If

            Me.Enabled = False
            If EDIT.Text = "0" Then
                If Me.SaveKala() = False Then
                    Me.Enabled = True
                    Exit Sub
                End If
            ElseIf EDIT.Text <> "0" Then
                If Me.EditKala() = False Then
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKalaRate", "BtnSave_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Function SaveKala() As Boolean

        If AreYouAddKala(CLng(TxtIdkala.Text)) Then
            MessageBox.Show("وعده تسویه مربوط به کالای مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO  Define_KalaRate (Idkala,BRate) VALUES(@Idkala,@BRate) ", ConectionBank)
                Cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                Cmd.Parameters.AddWithValue("@BRate", SqlDbType.BigInt).Value = CLng(TxtBRate.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO  Define_ListKalaRate (IdGroup,Rate,IdKalaLink) VALUES(@IdGroup,@Rate,@IdKalaLink)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdGroup", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@Rate", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_Rate", i).Value)
                    Cmd.Parameters.AddWithValue("@IdKalaLink", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و وعده تسویه", "جدید", "تعیین وعده تسویه کالای :" & TxtKala.Text, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKalaRate", "SaveKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditKala() As Boolean
        If CLng(TxtIdkala.Text) <> CLng(EDIT.Text) Then
            If AreYouEditKala(CLng(TxtIdkala.Text), CLng(EDIT.Text)) Then
                MessageBox.Show("وعده تسویه مربوط به کالای مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("UPDATE  Define_KalaRate  SET Idkala=@Idkala,BRate=@BRate WHERE Idkala=@OldId", ConectionBank)
                Cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                Cmd.Parameters.AddWithValue("@BRate", SqlDbType.BigInt).Value = CLng(TxtBRate.Text)
                Cmd.Parameters.AddWithValue("@OldId", SqlDbType.BigInt).Value = CLng(EDIT.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using cmd As New SqlCommand("DELETE FROM Define_ListKalaRate WHERE IdKalaLink=" & CLng(TxtIdkala.Text), ConectionBank)
                cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO  Define_ListKalaRate (IdGroup,Rate,IdKalaLink) VALUES(@IdGroup,@Rate,@IdKalaLink)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdGroup", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@Rate", SqlDbType.BigInt).Value = CDbl(DGV.Item("Cln_Rate", i).Value)
                    Cmd.Parameters.AddWithValue("@IdKalaLink", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و وعده تسویه", "ویرایش", If(Lname.Text = TxtKala.Text, "ویرایش وعده تسویه کالای :" & TxtKala.Text, "ویرایش وعده تسویه کالای :" & Lname.Text & " به  کالای " & TxtKala.Text), "")
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKalaRate", "EditKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function AreYouAddKala(ByVal IdKala As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT COUNT(IdKala) FROM Define_KalaRate WHERE Idkala=" & IdKala, ConectionBank)
                If cmd.ExecuteScalar > 0 Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End Using

        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKalaRate", "AreYouAddKala")
            Return False
        End Try
    End Function

    Private Function AreYouEditKala(ByVal NewIdKala As Long, ByVal OldIdKala As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT COUNT(IdKala) FROM Define_KalaRate WHERE Idkala =" & NewIdKala & " AND Idkala <>" & OldIdKala, ConectionBank)
                If cmd.ExecuteScalar > 0 Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End Using

        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmKalaRate", "AreYouEditKala")
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "VadeTasvieVaKala.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            Try
                Using FrmD As New FrmDisc
                    FrmD.ShowDialog()
                    If String.IsNullOrEmpty(FrmD.TxtDisc.Text.Trim) Then Exit Sub
                    If Not IsNumeric(FrmD.TxtDisc.Text) Then
                        MessageBox.Show("مقدار وارد شده نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    For i As Integer = 0 To DGV.RowCount - 1
                        DGV.Item("Cln_Rate", i).Value = CLng(FrmD.TxtDisc.Text)
                    Next
                End Using
            Catch ex As Exception
                MessageBox.Show("مقدار وارد شده نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
          
            If DGV.CurrentCell.ColumnIndex = 1 Or DGV.CurrentCell.ColumnIndex = 2 Then
                If DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                    txt_dgv.Clear()
                    Exit Sub
                End If

                If DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = "" Then
                    txt_dgv.Clear()
                    Exit Sub
                End If
            End If

            If DGV.CurrentCell.ColumnIndex = 1 Or DGV.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using FrmAdVance As New Group_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    DGV.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV.Rows.Add()
                        DGV.Item("Cln_NamKala", DGV.RowCount - 1).Value = AllSelectKala(i).Namekala
                        DGV.Item("Cln_Code", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                        DGV.Item("Cln_Rate", DGV.RowCount - 1).Value = 0
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

    Private Sub TxtBRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBRate.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub

    Private Sub TxtBRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBRate.KeyPress
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
End Class