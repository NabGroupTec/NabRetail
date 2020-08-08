Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmMeldProduction

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl
    Private Sub DGV1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        txt_dgv = e.Control
    End Sub


    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Use", DGV1.CurrentRow.Index).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using


        If DGV1.Item("Cln_Fe", e.RowIndex).Value = "مصرفی" Then
            DGV1.Rows(e.RowIndex).Cells("Cln_Use").Style.BackColor = Color.Gainsboro
        Else
            DGV1.Rows(e.RowIndex).Cells("Cln_Use").Style.BackColor = Nothing
        End If

    End Sub


    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
    End Sub


    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then
            DGV1.Focus()
        End If
    End Sub

    Private Sub FrmMeldProduction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmMeldProduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next

        TxtDate.ThisText = GetDate()

        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '''''''''''''''''''

        ' If LEdit.Text <> "0" Then Me.ShowKalafactor()

        If AllowEdit < 0 Then
            MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf AllowEdit = 1 Then
            BtnSave.Enabled = False
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Factor_buy.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)

        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try

            BtnSave.Focus()
            DGV1.EndEdit()

            If Not (String.IsNullOrEmpty(Trial)) Then
                If GetDate() > Trial Or TxtDate.ThisText > Trial Then
                    MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End
                End If
            End If


            DiscFactor = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", " " & TxtDisc.Text.Trim)

            If Not ValidBuy() Then
                Me.Enabled = True
                Exit Sub
            End If

            If LEdit.Text = "0" Then
                If SaveFactor() Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اجرای تولید", "ثبت", " نام فرمول: " & TxtSanad.Text.Trim, "")
                    Me.Close()
                End If
            ElseIf LEdit.Text = "1" Then
                If EditFactor() Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اجرای تولید", "ویرایش", "  نام فرمول " & TxtSanad.Text, "")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMeldProduction", "BtnSave_Click")
        End Try
    End Sub
    Private Function EditFactor() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim ListName As String = ""

        Try

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("UPDATE FormulaMaster SET CodeFormul=@CodeFormul,FormulName=@FormulName,D_Date=@D_Date WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@CodeFormul", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@FormulName", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("DELETE FROM FormulaDetails WHERE IdFormula=@IdFormula", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFormula", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO FormulaDetails (IdFormula,IdKala,KolCount,JozCount,Darsad,Kind,IdAnbar,KalaDisc) VALUES(@IdFormula,@IdKala,@KolCount,@JozCount,@Darsad,@Kind,@IdAnbar,@KalaDisc)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdFormula", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value.ToString.Replace("/", "."))
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value.ToString.Replace("/", "."))
                    Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                    Cmd.Parameters.AddWithValue("@Kind", SqlDbType.Int).Value = If(DGV1.Item("Cln_Fe", i).Value = "" Or DGV1.Item("Cln_Fe", i).Value = "مصرفی", 0, 1)
                    Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                    Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فرمول تولید قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMeldProduction", "EditFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function SaveFactor() As Long
        Dim sqltransaction As New CommittableTransaction
        Dim IdFac As Long = 0
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO FormulaMaster (CodeFormul,FormulName,IdUser,D_Date) VALUES(@CodeFormul,@FormulName,@IdUser,@D_Date);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@CodeFormul", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@FormulName", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                IdFac = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("INSERT INTO FormulaDetails (IdFormula,IdKala,KolCount,JozCount,Darsad,Kind,IdAnbar,KalaDisc) VALUES(@IdFormula,@IdKala,@KolCount,@JozCount,@Darsad,@Kind,@IdAnbar,@KalaDisc)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdFormula", SqlDbType.BigInt).Value = IdFac
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value.ToString.Replace("/", "."))
                    Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value.ToString.Replace("/", "."))
                    Cmd.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                    Cmd.Parameters.AddWithValue("@Kind", SqlDbType.Int).Value = If(DGV1.Item("Cln_Fe", i).Value = "" Or DGV1.Item("Cln_Fe", i).Value = "مصرفی", 0, 1)
                    Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                    Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return IdFac

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فرمول تولید قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMeldProduction", "SaveFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Private Sub EmptyGridKala()
        For i As Integer = DGV1.RowCount - 1 To 0 Step -1
            DGV1.Rows.RemoveAt(i)
        Next
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Use", DGV1.CurrentRow.Index).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            ''''''''''''''''''''''''''''''''''کنترل میزان تولید
            If DGV1.CurrentCell.ColumnIndex = 8 Then
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
            If DGV1.CurrentCell.ColumnIndex = 8 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    'DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    'DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidBuy() As Boolean
        Try
            DGV1.EndEdit()
            DGV1.RefreshEdit()

            If String.IsNullOrEmpty(TxtSanad.Text.Trim) Then
                MessageBox.Show(" فرمول را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtSanad.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText.Trim) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Return False
            End If
            If DGV1.RowCount < 1 Then
                MessageBox.Show("فرمول را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtSanad.Focus()
                Return False
            End If

            Dim Darsad As Double = 0
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

                If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                    MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_Anbar", i).Selected = True
                    Return False
                End If

                If DGV1.Item("Cln_Fe", i).Value = "" Then
                    MessageBox.Show("کاربرد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_Fe", i).Selected = True
                    Return False
                End If

                If DGV1.Item("Cln_Fe", i).Value = "تولیدی" And CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", ".")) <= 0 Then
                    MessageBox.Show("درصد مشارکت در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_Darsad", i).Selected = True
                    Return False
                End If


                Dim count_Kala As Long = 0
                Dim Counsom As Long = 0
                Dim Product As Long = 0


                If DGV1.Item("Cln_Fe", i).Value = "تولیدی" Then
                    Darsad += CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))
                End If
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                        count_Kala += 1
                    End If

                    If DGV1.Item("Cln_Fe", j).Value = "تولیدی" Then
                        Product += 1
                    End If

                    If DGV1.Item("Cln_Fe", j).Value = "مصرفی" Then
                        Counsom += 1
                    End If

                Next
                If count_Kala > 1 Then
                    MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Counsom <= 0 Then
                    MessageBox.Show("فرمول باید حداقل یک ردیف مصرفی داشته باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Product <= 0 Then
                    MessageBox.Show("فرمول باید حداقل یک ردیف تولیدی داشته باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Next

            If Darsad <> 100 Then
                MessageBox.Show("درصد مشارکت فرمول باید برابر با 100 باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMeldProduction", "ValidBuy")
            Return False
        End Try
    End Function

    Private Sub ShowKalafactor()
        Try
            Dim QueryKala As String = ""
            Dim QueryInfo As String = ""

            QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,FormulaDetails.Id,FormulaDetails.IdKala ,FormulaDetails.IdAnbar ,FormulaDetails.KolCount ,FormulaDetails.JozCount ,FormulaDetails.IdKala,Kind=CASE WHEN FormulaDetails.Kind=0 THEN N'مصرفی' ELSE N'تولیدی' END,FormulaDetails.Darsad,FormulaDetails.KalaDisc ,Define_Kala.Nam as NamKala ,Define_Anbar.nam AS NamAnbar,Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala ,Define_Vahed .Nam As Vahed FROM  FormulaDetails  INNER JOIN Define_Kala ON FormulaDetails.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON FormulaDetails.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE FormulaDetails.IdFormula = " & CLng(LIdFac.Text) & " ORDER BY FormulaDetails.Id"
            QueryInfo = "SELECT CodeFormul,FormulName,D_Date FROM FormulaMaster WHERE Id=" & CLng(LIdFac.Text)


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
                        DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = dtrInfo("Vahed")
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = dtrInfo("Kind")
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = dtrInfo("Darsad").ToString.Replace(".", "/")
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = dtrInfo("NamAnbar")
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = dtrInfo("KalaDisc")
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = dtrInfo("IdKala")
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = dtrInfo("IdAnbar")
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dtrInfo("DK")
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dtrInfo("DK_KOL")
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dtrInfo("DK_JOZ")

                        If dtrInfo("Kind") = "" Or dtrInfo("Kind") = "مصرفی" Then
                            DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Darsad").Style.BackColor = Color.Gainsboro
                            DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Fe").Style.BackColor = Color.Pink
                        ElseIf dtrInfo("Kind") = "تولیدی" Then
                            DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Darsad").Style.BackColor = Nothing
                            DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Fe").Style.BackColor = Color.SpringGreen
                        End If

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
                    TxtSanad.Text = If(dtrInfo("FormulName") Is DBNull.Value, "", dtrInfo("FormulName"))
                    TxtDisc.Text = If(dtrInfo("CodeFormul") Is DBNull.Value, "", dtrInfo("CodeFormul"))
                    TxtDate.ThisText = dtrInfo("D_Date")
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMeldProduction", "ShowKalaFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub ShowFormul()
        Try
            Me.EmptyGridKala()

            Dim QueryKala As String = ""

            QueryKala = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,FormulaDetails.Id,FormulaDetails.IdKala ,FormulaDetails.IdAnbar ,FormulaDetails.KolCount ,FormulaDetails.JozCount ,FormulaDetails.IdKala,Kind=CASE WHEN FormulaDetails.Kind=0 THEN N'مصرفی' ELSE N'تولیدی' END,FormulaDetails.Darsad,FormulaDetails.KalaDisc ,Define_Kala.Nam as NamKala ,Define_Anbar.nam AS NamAnbar,Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala ,Define_Vahed .Nam As Vahed FROM  FormulaDetails  INNER JOIN Define_Kala ON FormulaDetails.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON FormulaDetails.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE FormulaDetails.IdFormula = " & CLng(TxtId.Text) & " ORDER BY FormulaDetails.Id"

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
                        DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = dtrInfo("Vahed")
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = dtrInfo("Kind")
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = dtrInfo("Darsad").ToString.Replace(".", "/")
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = dtrInfo("NamAnbar")
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = dtrInfo("IdKala")
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = dtrInfo("IdAnbar")
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dtrInfo("DK")
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dtrInfo("DK_KOL")
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dtrInfo("DK_JOZ")
                        DGV1.Item("Cln_Use", DGV1.RowCount - 1).Value = 0
                        If dtrInfo("Kind") = "" Or dtrInfo("Kind") = "مصرفی" Then
                            DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Fe").Style.BackColor = Color.Pink
                        ElseIf dtrInfo("Kind") = "تولیدی" Then
                            DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Fe").Style.BackColor = Color.SpringGreen
                        End If

                    End While
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMeldProduction", "ShowFormul")
            Me.Close()
        End Try
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
    End Sub

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter

        If DGV1.Item("Cln_Fe", e.RowIndex).Value = "" Or DGV1.Item("Cln_Fe", e.RowIndex).Value = "مصرفی" Then
            DGV1.Columns("Cln_Use").ReadOnly = True
        Else
            DGV1.Columns("Cln_Darsad").ReadOnly = False
        End If

    End Sub

    Private Sub TxtSanad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSanad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub

        Using frm As New FrmFormulasSearch
            frm.ShowDialog()
            e.Handled = True
            TxtSanad.Focus()
        End Using

        If Tmp_Namkala <> "" Then
            TxtSanad.Text = Tmp_Namkala
            TxtId.Text = IdKala

            Me.ShowFormul()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class