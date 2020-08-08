Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmDiscountKala

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub TxtKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKala.KeyDown
        If e.KeyCode = Keys.Enter Then TxtGroup.Focus()
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try

            If e.ColumnIndex = 0 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV.RowCount - 1 Then
                        For i As Integer = 1 To 4
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If

            ElseIf e.ColumnIndex = 1 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV.RowCount - 1 Then
                        For i As Integer = 1 To 3
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If

            ElseIf e.ColumnIndex = 3 Then
                If Not (DGV.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    SendKeys.Send("+{TAB}")
                End If
            End If
        Catch ex As Exception

        End Try
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
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DKOL", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DJOZ", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_code", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_IdService", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = False
                    DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value = ""
                End If
        End Select
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try

            If DGV.CurrentCell.ColumnIndex = 3 Or DGV.CurrentCell.ColumnIndex = 4 Then
                If String.IsNullOrEmpty(TxtKala.Text) Or Trim(DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value) = "" Then
                    e.Handled = True
                    'DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = ""
                    'DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DKOL", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DJOZ", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_code", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_IdService", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = False
                    DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value = ""
                End If
            End If

            If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Then
                If String.IsNullOrEmpty(TxtKala.Text) Then
                    e.Handled = True
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DKOL", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DJOZ", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_code", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_IdService", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = False
                    DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value = ""
                End If
            End If
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 2 Then
            e.Handled = True
            If Not String.IsNullOrEmpty(TxtKala.Text) Then
                Dim frmlk As New Kala_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
                DGV.Focus()
                If Tmp_Namkala <> "" Then
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = Tmp_Namkala
                    DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value = IdKala
                    DGV.Item("Cln_IdService", DGV.CurrentRow.Index).Value = 0
                    DGV.Item("Cln_DKOL", DGV.CurrentRow.Index).Value = 0
                    DGV.Item("Cln_DJOZ", DGV.CurrentRow.Index).Value = 0
                    DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = DK
                    DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value = DK_KOL
                    DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value = DK_JOZ
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Selected = False
                    DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Selected = True
                Else
                    DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Selected = False
                    DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Selected = True
                End If
                Exit Sub
            End If
        End If
        ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزءکالا
        If DGV.CurrentCell.ColumnIndex = 0 Or DGV.CurrentCell.ColumnIndex = 1 Then
            If String.IsNullOrEmpty(TxtKala.Text) Then
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

        ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزء کالای جایزه

        If DGV.CurrentCell.ColumnIndex = 3 Or DGV.CurrentCell.ColumnIndex = 4 Then
            If String.IsNullOrEmpty(TxtKala.Text) Or Trim(DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value) = "" Then
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
    End Sub

    Private Sub TxtKala_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKala.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtKala.Focus()
        If Tmp_Namkala <> "" Then
            If CStr(IdKala) <> CStr(TxtIdkala.Text) And DGV.RowCount > 1 Then
                If MessageBox.Show("در صورت تغییر کالا تخفیفات انتخاب شده پاک خواهد شد آیا برای ادامه کار مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                DGV.Rows.Clear()
            End If
            TxtKala.Text = Tmp_Namkala
            TxtIdkala.Text = IdKala
            ChkDK.Checked = DK
            TxtKol.Text = DK_KOL
            TxtJoz.Text = DK_JOZ
        Else
            TxtKala.Text = ""
            TxtIdkala.Text = ""
            TxtKol.Text = ""
            TxtJoz.Text = ""
            ChkDK.Checked = False
            DGV.Rows.Clear()
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
            InfoDiscount(EDIT.Text)
        End If
    End Sub

    Private Sub InfoDiscount(ByVal Id As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Dim dtr As SqlDataReader = Nothing

            Using cmd As New SqlCommand("SELECT ListKala_Discount.Idkala,ListKala_Discount.AutoDiscount,ListKala_Discount.Coding, Define_Kala.Nam, Define_Kala.DK, Define_Kala.DK_KOL, Define_Kala.DK_JOZ FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id WHERE Idkala =" & Id, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                TxtIdkala.Text = dtr("Idkala")
                TxtKala.Text = dtr("Nam")
                TxtGroup.Text = dtr("Coding")
                TxtKol.Text = dtr("DK_KOL")
                TxtJoz.Text = dtr("DK_JOZ")
                ChkDK.Checked = dtr("DK")
                ChkDiscount.Checked = dtr("AutoDiscount")
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Me.Close()
            End If

            'TxtKala.Enabled = False

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            dtr = Nothing
            Using cmd As New SqlCommand("SELECT Kala_Discount.Joz, Kala_Discount.Kol, Kala_Discount.Idkala, Kala_Discount.IdService, Kala_Discount.JozCount, Kala_Discount.KolCount,Define_Kala.Nam, Define_Kala.DK, Define_Kala.DK_KOL, Define_Kala.DK_JOZ FROM Kala_Discount INNER JOIN Define_Kala ON Kala_Discount.Idkala = Define_Kala.Id WHERE IdKalaLink =" & Id & " UNION ALL SELECT   Kala_Discount.Joz, Kala_Discount.Kol, Kala_Discount.Idkala, Kala_Discount.IdService, Kala_Discount.JozCount, Kala_Discount.KolCount,Define_Service.Nam, DK='False', DK_KOL=1,DK_JOZ=1 FROM Kala_Discount INNER JOIN Define_Service ON Kala_Discount.IdService = Define_Service.Id WHERE IdKalaLink =" & Id, ConectionBank)
                dtr = cmd.ExecuteReader
            End Using
            If dtr.HasRows Then
                DGV.AllowUserToAddRows = False
                While dtr.Read
                    DGV.Rows.Add()
                    DGV.Item("Cln_KolCount", DGV.RowCount - 1).Value = dtr("KolCount")
                    DGV.Item("Cln_JozCount", DGV.RowCount - 1).Value = dtr("JozCount")
                    DGV.Item("Cln_Namkala", DGV.RowCount - 1).Value = dtr("Nam")
                    DGV.Item("Cln_DKOL", DGV.RowCount - 1).Value = dtr("Kol")
                    DGV.Item("Cln_DJOZ", DGV.RowCount - 1).Value = dtr("Joz")
                    DGV.Item("Cln_code", DGV.RowCount - 1).Value = If(dtr("IdKala") Is DBNull.Value, 0, dtr("IdKala"))
                    DGV.Item("Cln_IdService", DGV.RowCount - 1).Value = If(dtr("IdService") Is DBNull.Value, 0, dtr("IdService"))
                    DGV.Item("Cln_DK", DGV.RowCount - 1).Value = dtr("Dk")
                    DGV.Item("Cln_KOL", DGV.RowCount - 1).Value = dtr("DK_KOL")
                    DGV.Item("Cln_JOZ", DGV.RowCount - 1).Value = dtr("DK_JOZ")
                End While
                DGV.AllowUserToAddRows = True
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Me.Close()
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "InfoDiscount")
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
                MessageBox.Show("هیچ تخفیفی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2

                    If CStr(DGV.Item("Cln_KolCount", i).Value) = "" Then
                        MessageBox.Show(" به ازای کل سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDbl(DGV.Item("Cln_KolCount", i).Value) = 0 Then
                        MessageBox.Show(" به ازای کل سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If ChkDK.Checked = True Then
                        If CStr(DGV.Item("Cln_JozCount", i).Value) = "" Then
                            MessageBox.Show(" به ازای جزء سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If CDbl(DGV.Item("Cln_JozCount", i).Value) = 0 Then
                            MessageBox.Show(" به ازای جزء سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If

                    If DGV.Item("Cln_Namkala", i).Value = "" Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CStr(DGV.Item("Cln_DKol", i).Value) = "" Then
                        MessageBox.Show(" جایزه کل سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDbl(DGV.Item("Cln_DKol", i).Value) = 0 Then
                        MessageBox.Show(" جایزه کل سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CBool(DGV.Item("Cln_DJoz", i).Value) = True Then
                        If CStr(DGV.Item("Cln_DJoz", i).Value) = "" Then
                            MessageBox.Show(" جایزه جزء سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If CDbl(DGV.Item("Cln_DJoz", i).Value) = 0 Then
                            MessageBox.Show(" جایزه جزء سطر شماره" & "{ " & i + 1 & " }" & "  نا معتبر است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                Next i


                For i As Integer = 0 To DGV.RowCount - 2
                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_KolCount", i).Value.ToString = DGV.Item("Cln_KolCount", j).Value.ToString) And (DGV.Item("Cln_JozCount", i).Value.ToString = DGV.Item("Cln_JozCount", j).Value.ToString) And (If(DGV.Item("Cln_Code", j).Value.Equals(""), (DGV.Item("Cln_IdService", i).Value = DGV.Item("Cln_IdService", j).Value), (DGV.Item("Cln_Code", i).Value = DGV.Item("Cln_Code", j).Value))) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("تخفیفات سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i
            End If

            Me.Enabled = False
            If EDIT.Text = "0" Then
                If Me.SaveDiscount() = False Then
                    Me.Enabled = True
                    Exit Sub
                End If
            ElseIf EDIT.Text <> "0" Then
                If Me.EditDiscount() = False Then
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "BtnSave_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Function SaveDiscount() As Boolean

        If AreYouAddKala(CLng(TxtIdkala.Text)) Then
            MessageBox.Show("تخفیفات مربوط به کالای مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If Not AreYouAddGroup(TxtGroup.Text.Trim) Then
            Return False
        End If

        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO  ListKala_Discount (Idkala,Coding,AutoDiscount) VALUES(@Idkala,@Coding,@AutoDiscount) ", ConectionBank)
                Cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                Cmd.Parameters.AddWithValue("@Coding", SqlDbType.NVarChar).Value = TxtGroup.Text.Trim
                Cmd.Parameters.AddWithValue("@AutoDiscount", SqlDbType.Bit).Value = CBool(ChkDiscount.CheckState)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO  Kala_Discount (KolCount,JozCount,Idkala,IdService,Kol,Joz,IdKalaLink) VALUES(@KolCount,@JozCount,@Idkala,@IdService,@Kol,@Joz,@IdKalaLink)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_KolCount", i).Value)
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_JozCount", i).Value)
                    Cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = If(DGV.Item("Cln_Code", i).Value = 0, DBNull.Value, DGV.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = If(DGV.Item("Cln_IdService", i).Value = 0, DBNull.Value, DGV.Item("Cln_IdService", i).Value)
                    Cmd.Parameters.AddWithValue("@Kol", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_DKol", i).Value)
                    Cmd.Parameters.AddWithValue("@Joz", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_DJoz", i).Value)
                    Cmd.Parameters.AddWithValue("@IdKalaLink", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و جایزه", "جدید", "تعیین جایزه کالای :" & TxtKala.Text, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "SaveDiscount")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditDiscount() As Boolean
        If CLng(TxtIdkala.Text) <> CLng(EDIT.Text) Then
            If AreYouEditKala(CLng(TxtIdkala.Text), CLng(EDIT.Text)) Then
                MessageBox.Show("تخفیفات مربوط به کالای مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        If Not AreYouEditGroup(TxtGroup.Text.Trim) Then
            Return False
        End If

        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("UPDATE  ListKala_Discount  SET Idkala=@Idkala,Coding=@Coding,AutoDiscount=@AutoDiscount WHERE Idkala=@OldId", ConectionBank)
                Cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                Cmd.Parameters.AddWithValue("@OldId", SqlDbType.BigInt).Value = CLng(EDIT.Text)
                Cmd.Parameters.AddWithValue("@Coding", SqlDbType.NVarChar).Value = TxtGroup.Text.Trim
                Cmd.Parameters.AddWithValue("@AutoDiscount", SqlDbType.Bit).Value = CBool(ChkDiscount.CheckState)
                Cmd.ExecuteNonQuery()
            End Using

            Using cmd As New SqlCommand("DELETE FROM Kala_Discount WHERE IdKalaLink=" & CLng(TxtIdkala.Text), ConectionBank)
                cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO  Kala_Discount (KolCount,JozCount,Idkala,IdService,Kol,Joz,IdKalaLink) VALUES(@KolCount,@JozCount,@Idkala,@IdService,@Kol,@Joz,@IdKalaLink)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_KolCount", i).Value)
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_JozCount", i).Value)
                    Cmd.Parameters.AddWithValue("@Idkala", SqlDbType.BigInt).Value = If(DGV.Item("Cln_Code", i).Value = 0, DBNull.Value, DGV.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = If(DGV.Item("Cln_IdService", i).Value = 0, DBNull.Value, DGV.Item("Cln_IdService", i).Value)
                    Cmd.Parameters.AddWithValue("@Kol", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_DKol", i).Value)
                    Cmd.Parameters.AddWithValue("@Joz", SqlDbType.Float).Value = CDbl(DGV.Item("Cln_DJoz", i).Value)
                    Cmd.Parameters.AddWithValue("@IdKalaLink", SqlDbType.BigInt).Value = CLng(TxtIdkala.Text)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و جایزه", "ویرایش", If(Lname.Text = TxtKala.Text, "ویرایش جایزه کالای :" & TxtKala.Text, "ویرایش جایزه کالای :" & Lname.Text & " به  کالای " & TxtKala.Text), "")
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "EditDiscount")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function AreYouAddKala(ByVal IdKala As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT COUNT(IdKala) FROM ListKala_Discount WHERE Idkala=" & IdKala, ConectionBank)
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "AreYouAddKala")
            Return False
        End Try
    End Function

    Private Function AreYouAddGroup(ByVal Group As String) As Boolean
        Try
            If String.IsNullOrEmpty(Group) Then Return True
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim count_Group As Long = 0

            Using cmd As New SqlCommand("SELECT COUNT(Coding) FROM ListKala_Discount WHERE Coding=N'" & Group & "'", ConectionBank)
                count_Group = cmd.ExecuteScalar
            End Using

            If count_Group <= 0 Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            Else
                Dim onedtr As SqlDataReader = Nothing

                Using cmd As New SqlCommand("SELECT  TOP 1  Define_Kala.DK_JOZ, Define_Kala.DK_KOL, Define_Kala.DK FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id WHERE Coding =N'" & Group & "'", ConectionBank)
                    onedtr = cmd.ExecuteReader()
                End Using

                If onedtr.HasRows Then
                    onedtr.Read()
                    If CBool(ChkDK.Checked) = onedtr("DK") And CDbl(TxtKol.Text) = onedtr("DK_KOL") And CDbl(TxtJoz.Text) = onedtr("DK_JOZ") Then
                        onedtr = Nothing
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

                        Dim dt As New DataTable

                        Using cmd As New SqlCommand("SELECT Kala_Discount.KolCount, Kala_Discount.JozCount, Kala_Discount.Idkala, Kala_Discount.IdService, Kala_Discount.Kol, Kala_Discount.Joz FROM Kala_Discount INNER JOIN ListKala_Discount ON Kala_Discount.IdKalaLink = ListKala_Discount.Idkala WHERE IdKalaLink IN (SELECT  TOP 1  Define_Kala.Id  FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id WHERE Coding =N'" & Group & "')", ConectionBank)
                            dt.Load(cmd.ExecuteReader())
                        End Using
                        If dt.Rows.Count <= 0 Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            MessageBox.Show("تخفیفات تعریف شده با گروه مورد نظر همخوانی ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        Else
                            If dt.Rows.Count <> DGV.RowCount - 1 Then
                                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                MessageBox.Show("تخفیفات تعریف شده با گروه مورد نظر همخوانی ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return False
                            End If
                            For i As Integer = 0 To DGV.RowCount - 2
                                Dim row() As DataRow = Nothing
                                row = dt.Select("KolCount=" & CDbl(DGV.Item("Cln_KolCount", i).Value) & " AND JozCount=" & CDbl(DGV.Item("Cln_JozCount", i).Value) & " AND Kol=" & CDbl(DGV.Item("Cln_DKOL", i).Value) & " AND Joz=" & CDbl(DGV.Item("Cln_DJOZ", i).Value))
                                If row.Length > 0 Then
                                    Continue For
                                Else
                                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                    MessageBox.Show("تخفیفات تعریف شده با گروه مورد نظر همخوانی ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return False
                                End If
                            Next
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return True
                        End If
                    Else
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        MessageBox.Show("کالای مورد نظر به علت اختلاف در  کل و جزء کالا قابل تعریف در گروه مورد نظر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                End If
            End If
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "AreYouAddGroup")
            Return False
        End Try
    End Function

    Private Function AreYouEditGroup(ByVal Group As String) As Boolean
        Try
            If String.IsNullOrEmpty(Group) Then Return True
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim count_Group As Long = 0

            Using cmd As New SqlCommand("SELECT COUNT(Coding) FROM ListKala_Discount WHERE Coding=N'" & Group & "' AND IdKala<>" & CLng(EDIT.Text), ConectionBank)
                count_Group = cmd.ExecuteScalar
            End Using

            If count_Group <= 0 Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            Else
                Dim onedtr As SqlDataReader = Nothing

                Using cmd As New SqlCommand("SELECT  TOP 1  Define_Kala.DK_JOZ, Define_Kala.DK_KOL, Define_Kala.DK FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id WHERE Coding =N'" & Group & "'", ConectionBank)
                    onedtr = cmd.ExecuteReader()
                End Using

                If onedtr.HasRows Then
                    onedtr.Read()
                    If CBool(ChkDK.Checked) = onedtr("DK") And CDbl(TxtKol.Text) = onedtr("DK_KOL") And CDbl(TxtJoz.Text) = onedtr("DK_JOZ") Then
                        onedtr = Nothing
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

                        Dim dt As New DataTable

                        Using cmd As New SqlCommand("SELECT Kala_Discount.KolCount, Kala_Discount.JozCount, Kala_Discount.Idkala, Kala_Discount.IdService, Kala_Discount.Kol, Kala_Discount.Joz FROM Kala_Discount INNER JOIN ListKala_Discount ON Kala_Discount.IdKalaLink = ListKala_Discount.Idkala WHERE IdKalaLink IN (SELECT  TOP 1  Define_Kala.Id  FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id WHERE Coding =N'" & Group & "')", ConectionBank)
                            dt.Load(cmd.ExecuteReader())
                        End Using
                        If dt.Rows.Count <= 0 Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            MessageBox.Show("تخفیفات تعریف شده با گروه مورد نظر همخوانی ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        Else
                            If dt.Rows.Count <> DGV.RowCount - 1 Then
                                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                MessageBox.Show("تخفیفات تعریف شده با گروه مورد نظر همخوانی ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return False
                            End If
                            For i As Integer = 0 To DGV.RowCount - 2
                                Dim row() As DataRow = Nothing
                                row = dt.Select("KolCount=" & CDbl(DGV.Item("Cln_KolCount", i).Value) & " AND JozCount=" & CDbl(DGV.Item("Cln_JozCount", i).Value) & " AND Kol=" & CDbl(DGV.Item("Cln_DKOL", i).Value) & " AND Joz=" & CDbl(DGV.Item("Cln_DJOZ", i).Value))
                                If row.Length > 0 Then
                                    Continue For
                                Else
                                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                    MessageBox.Show("تخفیفات تعریف شده با گروه مورد نظر همخوانی ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return False
                                End If
                            Next
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return True
                        End If
                    Else
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        MessageBox.Show("کالای مورد نظر به علت اختلاف در  کل و جزء کالا قابل تعریف در گروه مورد نظر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                End If
            End If
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "AreYouAddGroup")
            Return False
        End Try
    End Function

    Private Function AreYouEditKala(ByVal NewIdKala As Long, ByVal OldIdKala As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT COUNT(IdKala) FROM ListKala_Discount WHERE Idkala =" & NewIdKala & " AND Idkala <>" & OldIdKala, ConectionBank)
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "AreYouEditKala")
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KalaVaJayeze.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnService.Enabled = True Then Call BtnService_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If String.IsNullOrEmpty(TxtKala.Text) Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV.CurrentCell.ColumnIndex = 3 Or DGV.CurrentCell.ColumnIndex = 4 Then
                If DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                    txt_dgv.Clear()
                    Exit Sub
                End If

                If DGV.Item("Cln_Namkala", DGV.CurrentRow.Index).Value = "" Then
                    txt_dgv.Clear()
                    Exit Sub
                End If
            End If

            If DGV.CurrentCell.ColumnIndex = 0 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                End If
                If ChkDK.Checked = False Then
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                Else
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(TxtKol.Text)) * CDbl(TxtJoz.Text), "###.##").ToString.Replace(".", "/")
                End If
                If DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
            ElseIf DGV.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
                End If
                If ChkDK.Checked = False Then
                    txt_dgv.Text = 0
                Else
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(TxtJoz.Text)) * CDbl(TxtKol.Text), "###.##").ToString.Replace(".", "/")
                End If
                If DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
            End If


            If DGV.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_DJoz", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_DJoz", DGV.CurrentRow.Index).Value = 0
                End If
                If CBool(DGV.Item("Cln_Dk", DGV.CurrentRow.Index).Value) = False Then
                    DGV.Item("Cln_DJoz", DGV.CurrentRow.Index).Value = 0
                Else
                    DGV.Item("Cln_DJoz", DGV.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV.Item("Cln_Kol", DGV.CurrentRow.Index).Value)) * CDbl(DGV.Item("Cln_Joz", DGV.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                End If
                If DGV.Item("Cln_DJoz", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_DJoz", DGV.CurrentRow.Index).Value = 0
            ElseIf DGV.CurrentCell.ColumnIndex = 4 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Value = 0
                End If
                If CBool(DGV.Item("Cln_Dk", DGV.CurrentRow.Index).Value) = False Then
                    txt_dgv.Text = 0
                Else
                    DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV.Item("Cln_Joz", DGV.CurrentRow.Index).Value)) * CDbl(DGV.Item("Cln_Kol", DGV.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                End If
                If DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_DKol", DGV.CurrentRow.Index).Value = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnService.Click
        Try
            If String.IsNullOrEmpty(TxtKala.Text) Then
                MessageBox.Show("قبل از انتخاب کالای خدماتی کالا را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtKala.Focus()
                Exit Sub
            End If

            Dim frmlk As New Service_List
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                DGV.AllowUserToAddRows = False
                DGV.Rows.Add()
                DGV.Item("Cln_Namkala", DGV.RowCount - 1).Value = Tmp_Namkala
                DGV.Item("Cln_Code", DGV.RowCount - 1).Value = 0
                DGV.Item("Cln_IdService", DGV.RowCount - 1).Value = IdKala
                DGV.Item("Cln_KolCount", DGV.RowCount - 1).Value = 0
                DGV.Item("Cln_JozCount", DGV.RowCount - 1).Value = 0
                DGV.Item("Cln_DKOL", DGV.RowCount - 1).Value = 0
                DGV.Item("Cln_DJOZ", DGV.RowCount - 1).Value = 0
                DGV.Item("Cln_DK", DGV.RowCount - 1).Value = False
                DGV.Item("Cln_KOL", DGV.RowCount - 1).Value = 1
                DGV.Item("Cln_JOZ", DGV.RowCount - 1).Value = 1
                DGV.AllowUserToAddRows = True
                DGV.Item("Cln_KolCount", DGV.RowCount - 2).Selected = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscountKala", "BtnService_Click")
        End Try
    End Sub

    Private Sub TxtGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then DGV.Focus()
    End Sub
End Class