Imports System.Data.SqlClient
Imports System.Transactions

Public Class Kala_OneTime
    Dim ds As New DataSet
    Dim str As String = "SELECT  Define_Anbar.nam As Anbar, Define_PrimaryKala.*, Define_Kala.Nam AS NamKala FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id"
    Dim Editstr As String = "SELECT Define_EditKala.Idkala,REPLACE(Define_EditKala.OKol,'.','/') AS OKol, REPLACE(Define_EditKala.OJoz,'.','/') AS OJoz, REPLACE(Define_EditKala.TKol,'.','/') AS TKol, REPLACE(Define_EditKala.TJoz,'.','/') AS TJoz, Define_Kala.Nam AS Namkala,Define_Anbar.nam AS NamAnbar FROM Define_EditKala INNER JOIN Define_Kala ON Define_EditKala.Idkala = Define_Kala.Id INNER JOIN Define_Anbar ON Define_EditKala.IdAnbar = Define_Anbar.ID"
    Dim dta As New SqlDataAdapter
    Dim dt As New DataTable
    '''''''''''''''''''''''''''''''''''''''''''''''''''
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub Kala_OneTime_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DGV1.Focus()
    End Sub

    Private Sub Kala_OneTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DGV1.RowCount > 1 Then
            If MessageBox.Show("کالاهای وارد شده در بخش ثبت موجودی اول دوره ذخیره نشده است آیا برای خروج مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub Kala_OneTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub A_Kala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F12")
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
        Txtallmoney.Text = 0
        TxtKalaDate.ThisText = GetDate()
        Me.GetKala()
        Me.GetEditKala()
        Me.Calculate()
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_Name1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("DataGridViewTextBoxColumn4").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F12")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    Btnsave.Enabled = False
                    Button1.Enabled = False
                    Button3.Enabled = False
                    BtnPrint.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        Btnsave.Enabled = False
                        Button1.Enabled = False
                        Button3.Enabled = False
                        BtnPrint.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            Btnsave.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            Button1.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            Button3.Enabled = False
                        End If
                        Try
                            If Access_Form.Substring(6, 1) = 0 Then
                                BtnPrint.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnPrint.Enabled = False
                        End Try
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                Btnsave.Enabled = False
                Button2.Enabled = False
                Btnnew.Enabled = False
                Button1.Enabled = False
                Button3.Enabled = False

            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub Btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnnew.Click
        If MessageBox.Show("آيا براي حذف همه کالاهای مورد نظر مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Try
            Me.EmptyGridKala()
            Txtallmoney.Text = "0"
            DGV1.Focus()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "Btnnew_Click")
        End Try
    End Sub
    Private Sub EmptyGridKala()
        If DGV1.RowCount > 1 Then
            DGV1.Item("Cln_Name", 0).Selected = True
            For i As Integer = DGV1.RowCount - 2 To 0 Step -1
                DGV1.Rows.RemoveAt(i)
            Next
        Else
            DGV1.Item("Cln_name", 0).Value = ""
            DGV1.Item("Cln_Count", 0).Value = ""
            DGV1.Item("Cln_Buy", 0).Value = ""
            DGV1.Item("Cln_Money", 0).Value = ""
            DGV1.Item("Cln_b", 0).Value = ""
            DGV1.Item("Cln_type", 0).Value = ""
            DGV1.Item("Cln_code", 0).Value = ""
            DGV1.Item("Cln_Anbar", 0).Value = ""
            DGV1.Item("Cln_CodeAnbar", 0).Value = ""
            DGV1.Item("Cln_DK", 0).Value = False
            DGV1.Item("Cln_KOL", 0).Value = ""
            DGV1.Item("Cln_JOZ", 0).Value = ""
        End If
    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Try
            DGV1.CommitEdit(DataGridViewDataErrorContexts.RowDeletion)
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            ''''''''''''''''''''''''''''''''''''''''''''
            If CDbl(Txtallmoney.Text.ToString) <= 0 Then
                MessageBox.Show("جمع كل مبلغ صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV1.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtKalaDate.ThisText) Then
                MessageBox.Show("لطفا تاریخ ورود کالا را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtKalaDate.Focus()
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''
            If DGV1.RowCount > 1 Then
                For i As Integer = 0 To DGV1.RowCount - 2
                    If Trim(DGV1.Item("Cln_Name", i).Value) = "" Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If Trim(DGV1.Item("Cln_Money", i).Value) = "" Then
                        MessageBox.Show(" جمع مبلغ سطر شماره" & "{ " & i + 1 & " }" & "  صفر است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDbl(DGV1.Item("Cln_Money", i).Value.ToString) <= 0 Then
                        MessageBox.Show(" جمع مبلغ سطر شماره" & "{ " & i + 1 & " }" & "  صفر است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If Trim(DGV1.Item("Cln_Code", i).Value) = "" Then
                        MessageBox.Show(" کالای سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_Code", i).Value <= 0 Then
                        MessageBox.Show(" کالای سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                   
                    If Trim(DGV1.Item("Cln_CodeAnbar", i).Value) = "" Then
                        MessageBox.Show(" انبار سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_CodeAnbar", i).Value <= 0 Then
                        MessageBox.Show(" انبار سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                Next i
            End If
            GroupBox3.Enabled = False
            Btnnew.Enabled = False
            Button2.Enabled = False
            Btnsave.Enabled = False
            If Me.SaveKala Then
                Me.EmptyGridKala()
                Txtallmoney.Text = "0"
                MessageBox.Show("کالاهای انتخابی با موفقیت ذخیره شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Me.RefreshBank()
            End If
            GroupBox3.Enabled = True
            Btnnew.Enabled = True
            Button2.Enabled = True
            Btnsave.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "Btnsave_Click")
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

            Using Cmd As New SqlCommand("INSERT INTO Define_PrimaryKala(IdKala,IdAnbar,Count_Kol,Count_Joz,Fe,Mon,D_Date,IdUser) VALUES(@IdKala,@IdAnbar,@Count_Kol,@Count_Joz,@Fe,@Mon,@D_Date,@IdUser)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                    Cmd.Parameters.AddWithValue("@Count_Kol", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Count", i).Value)
                    Cmd.Parameters.AddWithValue("@Count_Joz", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_B", i).Value)
                    Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Buy", i).Value)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Money", i).Value)
                    Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = TxtKalaDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
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
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "ذخیره", "تعداد اقلام :" & DGV1.RowCount & " جمع مبلغ:" & Txtallmoney.Text, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا کالاها را وارد کنید و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "SaveKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function OkEnd() As Boolean
        Try
            Using Cmd As New SqlCommand("SELECT DK FROM Define_Kala WHERE Id=@ID", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                    If CBool(Cmd.ExecuteScalar()) <> CBool(DGV1.Item("Cln_DK", i).Value) Then
                        DGV1.Item("Cln_Name", i).Selected = True
                        Return False
                    End If
                    Cmd.Parameters.Clear()
                Next i
                Return True
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "OkEnd")
            Return False
        End Try
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("کالایی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            If MessageBox.Show("آیا برای عملیات حذف کالا مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            LimitMojody()

            Dim nam As String = DGV2.Item("Cln_Name1", DGV2.CurrentRow.Index).Value
            Dim mon As String = FormatNumber(DGV2.Item("Cln_Mon1", DGV2.CurrentRow.Index).Value, 0)


            If Not AreYouNativeKalaAnbar(CLng(DGV2.Item("Cln_Id", DGV2.CurrentRow.Index).Value), CDbl(DGV2.Item("Cln_CountKol", DGV2.CurrentRow.Index).Value), CDbl(DGV2.Item("Cln_CountJoz", DGV2.CurrentRow.Index).Value), CLng(DGV2.Item("Cln_idanbar1", DGV2.CurrentRow.Index).Value)) Then
                If MAnbar = True Then
                    If MessageBox.Show("کالای سطر شماره" & DGV2.CurrentRow.Index + 1 & " کمتر از موجودی انبار است آیا برای حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                Else
                    MessageBox.Show("کالای سطر شماره" & DGV2.CurrentRow.Index + 1 & " کمتر از موجودی انبار است و قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If


            If Me.DeleteKala(CLng(DGV2.Item("Cln_Id", DGV2.CurrentRow.Index).Value)) Then
                Me.RefreshBank()
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "حذف", "حذف موجودی اول دوره کالای :" & nam & " با مبلغ " & mon, "")
                MessageBox.Show("کالای انتخابی با موفقیت حذف شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "Button1_Click")
        End Try
    End Sub
    Private Function DeleteKala(ByVal Id As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("DELETE FROM Define_PrimaryKala WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل حذف شدن نیست لطفا دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "DeleteKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
        If DGV1.RowCount > 0 Then
            Txtallmoney.Text = "0"
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                    Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                End If
            Next i
            If Txtallmoney.Text.Length > 3 Then
                Dim money As String = ""
                money = Txtallmoney.Text.Replace(",", "")
                Txtallmoney.Text = Format$(Val(money), "###,###,###")
            End If
        Else
            Txtallmoney.Text = "0"
        End If
    End Sub

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
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_COUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value), "###,###")
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
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
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_COUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Buy", DGV1.CurrentRow.Index).Value), "###,###")
                End If
            End If
            If DGV1.RowCount > 0 Then
                Txtallmoney.Text = "0"
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                        Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                    End If
                Next i
                If Txtallmoney.Text.Length > 3 Then
                    Dim money As String = ""
                    money = Txtallmoney.Text.Replace(",", "")
                    Txtallmoney.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                Txtallmoney.Text = "0"
            End If
        Catch ex As Exception

        End Try
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
                    If DGV1.RowCount > 0 Then
                        Txtallmoney.Text = "0"
                        For i As Integer = 0 To DGV1.RowCount - 2
                            If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                                Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                            End If
                        Next i
                        If Txtallmoney.Text.Length > 3 Then
                            Dim money As String = ""
                            money = Txtallmoney.Text.Replace(",", "")
                            Txtallmoney.Text = Format$(Val(money), "###,###,###")
                        End If
                    Else
                        Txtallmoney.Text = "0"
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV1_RowPostPaint1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 5)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        If DGV1.Item("Cln_DK", e.RowIndex).Value = False Then
            DGV1.Rows(e.RowIndex).Cells("Cln_b").Style.BackColor = Color.Gainsboro
        Else
            DGV1.Rows(e.RowIndex).Cells("Cln_b").Style.BackColor = Nothing
        End If
    End Sub

    Private Sub DGV1_UserDeletedRow1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
        If DGV1.RowCount > 0 Then
            Txtallmoney.Text = "0"
            For i As Integer = 0 To DGV1.RowCount - 2
                If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                    Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                End If
            Next i
            If Txtallmoney.Text.Length > 3 Then
                Dim money As String = ""
                money = Txtallmoney.Text.Replace(",", "")
                Txtallmoney.Text = Format$(Val(money), "###,###,###")
            End If
        Else
            Txtallmoney.Text = "0"
        End If
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        If DGV2.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub
    Private Sub GetKala()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_PrimaryKala")
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = ds.Tables("Define_PrimaryKala")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "GetKala")
            Me.Close()
        End Try
    End Sub
    Private Sub GetEditKala()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Editstr, ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV3.AutoGenerateColumns = False
            DGV3.DataSource = dt
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "GetEditKala")
            Me.Close()
        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            DGV2.AutoGenerateColumns = False
            ds.Clear()
            dta.Fill(ds, "Define_PrimaryKala")
            SetButton()
            Me.Calculate()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "RefreshBank")
        End Try
    End Sub
    Private Sub Calculate()
        Txtallmon1.Text = 0
        Dim result As Double = 0
        For i As Integer = 0 To DGV2.RowCount - 1
            result += CDbl(DGV2.Item("Cln_Mon1", i).Value)
        Next
        Txtallmon1.Text = Format$(result, "###,###")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Fnew = True
            Using Frmkala As New DefineKala
                Frmkala.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "Button2_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Kala_aval.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(0).Focus = True Then
                If Btnsave.Enabled = True Then Call Btnsave_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If Button4.Enabled = True Then Call Button4_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            If TabControl1.TabPages(0).Focus = True Then
                If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If TabControl1.TabPages(0).Focus = True Then
                If Btnnew.Enabled = True Then Call Btnnew_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If TabControl1.TabPages(1).Focus = True Then
                If BtnPrint.Enabled = True Then Call BtnPrint_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("کالایی برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Using FrmEditkala As New EditKala_OneTime
                FrmEditkala.LID.Text = CLng(DGV2.Item("Cln_Id", DGV2.CurrentRow.Index).Value)

                Tmp_String1 = DGV2.Item("Cln_Name1", DGV2.CurrentRow.Index).Value
                Tmp_String2 = FormatNumber(DGV2.Item("Cln_Mon1", DGV2.CurrentRow.Index).Value, 0)

                FrmEditkala.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_OneTime", "Button3_Click")
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV2.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV2.RowCount > 1 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_Idkala1", i).Value = IdKala Then
                        DGV2.Item("Cln_Name1", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV2.Item(3, 0).Selected = True
                DGV2.Item(3, 0).Selected = False
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id "
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبکدکالاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبکدکالاToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY IdKala"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبتاریخToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبتاریخToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY D_date"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبنامکالاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبنامکالاToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY Define_Kala.Nam"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبتعدادکلToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبتعدادکلToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY Count_Kol"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبتعدادجزءToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبتعدادجزءToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY Count_Joz"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبنامانبارToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبنامانبارToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY Define_Anbar.nam"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub چاپبرحسبجمعکلمبلغToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles چاپبرحسبجمعکلمبلغToolStripMenuItem.Click
        If DGV2.RowCount <= 0 Then
            MessageBox.Show("کالایی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اول دوره کالا", "چاپ لیست", "", "")

        Using frmp As New FrmPrint
            frmp.CHoose = "KALAONE"
            frmp.PrintSQl = "SELECT  Define_Anbar.nam  AS NamAnbar, Define_Kala.Nam , Count_Joz AS JozStr ,Count_Kol As KolStr ,D_date AS GroupKala ,Fe ,IdKala AS MKolStr ,Mon As AllMon  FROM Define_Anbar INNER JOIN Define_PrimaryKala ON Define_Anbar.ID = Define_PrimaryKala.IdAnbar INNER JOIN Define_Kala ON Define_PrimaryKala.IdKala = Define_Kala.Id ORDER BY Mon"
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        If DGV3.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If DGV3.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV3.RowCount > 1 Then
                For i As Integer = 0 To DGV3.RowCount - 1
                    If DGV3.Item("DataGridViewTextBoxColumn2", i).Value = IdKala Then
                        DGV3.Item("DataGridViewTextBoxColumn4", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV3.Item(1, 0).Selected = True
                DGV3.Item(1, 0).Selected = False
            End If
        End If
    End Sub
End Class