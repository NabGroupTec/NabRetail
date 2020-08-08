Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmNewAnbarToAnbar

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Try
            If String.IsNullOrEmpty(TxtKalaDate.ThisText) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtKalaDate.Focus()
                Exit Sub
            End If
            '/////////////////////////////////////////////////////////
            DGV1.CommitEdit(DataGridViewDataErrorContexts.RowDeletion)
            DGV1.EndEdit()
            DGV1.RefreshEdit()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(LSanad.Text) Then
                If DGV1.Rows.Count <= 1 Then
                    MessageBox.Show("اطلاعاتی جهت ثبت وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value <> "" Then
                    MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV1.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If String.IsNullOrEmpty(TxtKalaDate.ThisText) Then
                MessageBox.Show("لطفا تاریخ ورود کالا را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtKalaDate.Focus()
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(LSanad.Text) Then
                If DGV1.RowCount > 1 Then
                    For i As Integer = 0 To DGV1.RowCount - 2
                        If Trim(DGV1.Item("Cln_Name", i).Value) = "" Or Trim(DGV1.Item("Cln_Oneanbar", i).Value) = "" Or Trim(DGV1.Item("Cln_Twoanbar", i).Value) = "" Then
                            MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                        If Trim(DGV1.Item("Cln_CodeOneAnbar", i).Value) = "" Then
                            MessageBox.Show(" انبار مبدا سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If Trim(DGV1.Item("Cln_CodeTwoAnbar", i).Value) = "" Then
                            MessageBox.Show(" انبار مقصد سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_CodeOneAnbar", i).Value <= 0 Then
                            MessageBox.Show(" انبار مبدا سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        If DGV1.Item("Cln_CodeTwoAnbar", i).Value <= 0 Then
                            MessageBox.Show(" انبار مقصد سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_CodeOneAnbar", i).Value = DGV1.Item("Cln_CodeTwoAnbar", i).Value Then
                            MessageBox.Show(" انبار های  سطر شماره" & "{ " & i + 1 & " }" & "  یکسان است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_Count", i).Value <= 0 Then
                            MessageBox.Show(" تعداد سطر شماره" & "{ " & i + 1 & " }" & "  اشتباه است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        If DGV1.Item("Cln_DK", i).Value = True Then
                            If DGV1.Item("Cln_b", i).Value <= 0 Then
                                MessageBox.Show(" نسبت جزء سطر شماره" & "{ " & i + 1 & " }" & "  اشتباه است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If

                        '/////////////////////////////////////
                        LimitMojody()

                        If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_Count", i).Value), CDbl(DGV1.Item("Cln_b", i).Value), CLng(DGV1.Item("Cln_CodeOneAnbar", i).Value)) Then
                            If MAnbar = True Then
                                If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                            Else
                                MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If

                        '/////////////////////////////////////
                    Next i
                End If
            Else
                If DGV1.RowCount > 0 Then
                    For i As Integer = 0 To DGV1.RowCount - 1
                        If Trim(DGV1.Item("Cln_Name", i).Value) = "" Or Trim(DGV1.Item("Cln_Oneanbar", i).Value) = "" Or Trim(DGV1.Item("Cln_Twoanbar", i).Value) = "" Then
                            MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                        If Trim(DGV1.Item("Cln_CodeOneAnbar", i).Value) = "" Then
                            MessageBox.Show(" انبار مبدا سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If Trim(DGV1.Item("Cln_CodeTwoAnbar", i).Value) = "" Then
                            MessageBox.Show(" انبار مقصد سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_CodeOneAnbar", i).Value <= 0 Then
                            MessageBox.Show(" انبار مبدا سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        If DGV1.Item("Cln_CodeTwoAnbar", i).Value <= 0 Then
                            MessageBox.Show(" انبار مقصد سطر شماره" & "{ " & i + 1 & " }" & "  نامشخص است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_CodeOneAnbar", i).Value = DGV1.Item("Cln_CodeTwoAnbar", i).Value Then
                            MessageBox.Show(" انبار های  سطر شماره" & "{ " & i + 1 & " }" & "  یکسان است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_Count", i).Value <= 0 Then
                            MessageBox.Show(" تعداد سطر شماره" & "{ " & i + 1 & " }" & "  اشتباه است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        If DGV1.Item("Cln_DK", i).Value = True Then
                            If DGV1.Item("Cln_b", i).Value <= 0 Then
                                MessageBox.Show(" نسبت جزء سطر شماره" & "{ " & i + 1 & " }" & "  اشتباه است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If

                        '/////////////////////////////////////
                        LimitMojody()

                        If Not (DGV1.Item("Cln_OldKol", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", i).Value Is DBNull.Value Or DGV1.Item("Cln_OldOneAnbar", i).Value Is DBNull.Value) Then
                            If CLng(DGV1.Item("Cln_OldOneAnbar", i).Value) = CLng(DGV1.Item("Cln_CodeOneAnbar", i).Value) Then
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_Count", i).Value) - CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_b", i).Value) - CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_CodeOneAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If
                                End If
                            Else
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_OldKol", i).Value), CDbl(DGV1.Item("Cln_OldJoz", i).Value), CLng(DGV1.Item("Cln_OldOneAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If
                                End If
                                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_Count", i).Value), CDbl(DGV1.Item("Cln_b", i).Value), CLng(DGV1.Item("Cln_CodeOneAnbar", i).Value)) Then
                                    If MAnbar = True Then
                                        If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                                    Else
                                        MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Else
                            If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_Count", i).Value), CDbl(DGV1.Item("Cln_b", i).Value), CLng(DGV1.Item("Cln_CodeOneAnbar", i).Value)) Then
                                If MAnbar = True Then
                                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                                Else
                                    MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار مبداء است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If
                            End If
                        End If
                        '/////////////////////////////////////

                    Next i
                End If
            End If
            '/////////////////////////////////////////////////////////
            If String.IsNullOrEmpty(LSanad.Text) Then
                If Me.SaveKala Then Me.Close()
            Else
                If Me.EditKala Then Me.Close()
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmNewAnbarToAnbar", "Btnsave_Click")
        End Try
    End Sub

    Private Function SaveKala() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Dim sanad As Long = 0

            Array.Resize(ListDelayPrintArray, 0)

            Using Cmd As New SqlCommand("INSERT Tranlate_Anbar (IdOneAnbar,IdTwoAnbar,IdKala,Kol,Joz,Disc,D_date,IdUser) VALUES(@IdOneAnbar,@IdTwoAnbar,@IdKala,@Kol,@Joz,@Disc,@D_date,@IdUser);SELECT @@IDENTITY ", ConectionBank)
                For i As Integer = 0 To DGV1.Rows.Count - 2
                    Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                    Cmd.Parameters.AddWithValue("@IdOneAnbar", SqlDbType.BigInt).Value = DGV1.Item("Cln_CodeOneAnbar", i).Value
                    Cmd.Parameters.AddWithValue("@IdTwoAnbar", SqlDbType.BigInt).Value = DGV1.Item("Cln_CodeTwoAnbar", i).Value
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DGV1.Item("Cln_code", i).Value
                    Cmd.Parameters.AddWithValue("@Kol", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Count", i).Value)
                    Cmd.Parameters.AddWithValue("@Joz", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_b", i).Value)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtKalaDate.ThisText
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)

                    ListDelayPrintArray(i).IdFactor = Cmd.ExecuteScalar
                    ListDelayPrintArray(i).D_Date = DGV1.Item("Cln_OneAnbar", i).Value
                    ListDelayPrintArray(i).Darsad = DGV1.Item("Cln_TwoAnbar", i).Value
                    ListDelayPrintArray(i).Disc = DGV1.Item("Cln_name", i).Value
                    ListDelayPrintArray(i).EndDate = DGV1.Item("Cln_count", i).Value
                    ListDelayPrintArray(i).Kind = DGV1.Item("Cln_b", i).Value
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            For i As Integer = 0 To ListDelayPrintArray.Length - 1
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات انبار", "جدید", "ثبت سند:" & ListDelayPrintArray(i).IdFactor & " انبار مبدا:" & ListDelayPrintArray(i).D_Date & " انبار مقصد:" & ListDelayPrintArray(i).Darsad & " نام کالا:" & ListDelayPrintArray(i).Disc & " تعداد کل:" & ListDelayPrintArray(i).EndDate & " تعداد جزء:" & ListDelayPrintArray(i).Kind, "")
            Next
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmNewAnbarToAnbar", "SaveKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditKala() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("UPDATE  Tranlate_Anbar SET IdOneAnbar=@IdOneAnbar,IdTwoAnbar=@IdTwoAnbar,IdKala=@IdKala,Kol=@Kol,Joz=@Joz,Disc=@Disc,D_date=@D_date,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdOneAnbar", SqlDbType.BigInt).Value = DGV1.Item("Cln_CodeOneAnbar", 0).Value
                Cmd.Parameters.AddWithValue("@IdTwoAnbar", SqlDbType.BigInt).Value = DGV1.Item("Cln_CodeTwoAnbar", 0).Value
                Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DGV1.Item("Cln_code", 0).Value
                Cmd.Parameters.AddWithValue("@Kol", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Count", 0).Value)
                Cmd.Parameters.AddWithValue("@Joz", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_b", 0).Value)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", 0).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", 0).Value)), "", DGV1.Item("Cln_Disc", 0).Value)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtKalaDate.ThisText
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات انبار", "ویرایش", "ویرایش سند:" & CLng(LSanad.Text) & " انبار مبدا:" & DGV1.Item("Cln_OneAnbar", DGV1.CurrentRow.Index).Value & " انبار مقصد:" & DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Value & " نام کالا:" & DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value & " تعداد کل:" & DGV1.Item("Cln_count", DGV1.CurrentRow.Index).Value & " تعداد جزء:" & DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmNewAnbarToAnbar", "EditKala")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AnbarToAnbar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnsave.Enabled = True Then Call Btnsave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmNewAnbarToAnbar2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DGV1.Focus()
    End Sub

    Private Sub FrmNewAnbarToAnbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub GetInfoSanad(ByVal id As Long)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT Alldata.Id,Kol,Joz,Disc ,D_date,NamKala,NamOne +'-'+ NamTwo As GroupKala ,OneAnbar ,Define_Anbar .nam as TwoAnbar,IdoneAnbar,IdTwoAnbar,IdKala,DK,DK_KOL,DK_JOZ   FROM (SELECT  Tranlate_Anbar.Id,Tranlate_Anbar.IdKala ,Tranlate_Anbar.IdOneAnbar , Tranlate_Anbar.Kol, Tranlate_Anbar.Joz, Tranlate_Anbar.Disc, Tranlate_Anbar.D_date, Define_Kala.Nam  As NamKala,Define_OneGroup.NamOne, Define_TwoGroup.NamTwo,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Anbar .nam As OneAnbar,Tranlate_Anbar .IdTwoAnbar FROM  Tranlate_Anbar INNER JOIN Define_Kala ON Tranlate_Anbar.IdKala = Define_Kala.Id  INNER JOIN Define_Anbar On Define_Anbar .ID =Tranlate_Anbar .IdOneAnbar INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne )As AllData INNER JOIN Define_Anbar ON Define_Anbar .ID =AllData .IdTwoAnbar WHERE Alldata.Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    TxtKalaDate.ThisText = dtr("D_Date")
                    DGV1.Rows.Add()
                    DGV1.Item("Cln_name", DGV1.Rows.Count - 1).Value = dtr("NamKala")
                    DGV1.Item("Cln_Count", DGV1.Rows.Count - 1).Value = dtr("Kol")
                    DGV1.Item("Cln_Disc", DGV1.Rows.Count - 1).Value = dtr("Disc")
                    DGV1.Item("Cln_b", DGV1.Rows.Count - 1).Value = dtr("Joz")
                    DGV1.Item("Cln_type", DGV1.Rows.Count - 1).Value = dtr("GroupKala")
                    DGV1.Item("Cln_code", DGV1.Rows.Count - 1).Value = dtr("IdKala")
                    DGV1.Item("Cln_OneAnbar", DGV1.Rows.Count - 1).Value = dtr("OneAnbar")
                    DGV1.Item("Cln_TwoAnbar", DGV1.Rows.Count - 1).Value = dtr("TwoAnbar")
                    DGV1.Item("Cln_CodeOneAnbar", DGV1.Rows.Count - 1).Value = dtr("IdOneAnbar")
                    DGV1.Item("Cln_CodeTwoAnbar", DGV1.Rows.Count - 1).Value = dtr("IdTwoAnbar")
                    DGV1.Item("Cln_DK", DGV1.Rows.Count - 1).Value = dtr("DK")
                    DGV1.Item("Cln_KOL", DGV1.Rows.Count - 1).Value = dtr("DK_KOL")
                    DGV1.Item("Cln_JOZ", DGV1.Rows.Count - 1).Value = dtr("DK_JOZ")

                    DGV1.Item("Cln_OldKol", DGV1.Rows.Count - 1).Value = dtr("Kol")
                    DGV1.Item("Cln_OldJoz", DGV1.Rows.Count - 1).Value = dtr("Joz")
                    DGV1.Item("Cln_OldOneAnbar", DGV1.Rows.Count - 1).Value = dtr("IdOneAnbar")
                    DGV1.Item("Cln_OldTwoAnbar", DGV1.Rows.Count - 1).Value = dtr("IdTwoAnbar")

                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If

            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmNewAnbarToAnbar", "GetInfoSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub FrmNewAnbarToAnbar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not String.IsNullOrEmpty(LSanad.Text.Trim) Then
            Me.GetInfoSanad(CLng(LSanad.Text))
        Else
            DGV1.AllowUserToAddRows = True
            DGV1.AllowUserToDeleteRows = True
        End If
        DGV1.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Try

            If e.ColumnIndex = 2 Then
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
                    If Not String.IsNullOrEmpty(LSanad.Text) Then Exit Sub
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_OneAnbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_CodeOneAnbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_CodeTwoAnbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                        DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
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

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
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
                DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_OneAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeOneAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeTwoAnbar", DGV1.CurrentRow.Index).Value = ""
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
            If Not String.IsNullOrEmpty(LSanad.Text) Then
                LimitMojody()
                If Not (DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldTwoAnbar", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then

                    If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value), CLng(DGV1.Item("Cln_OldTwoAnbar", DGV1.CurrentRow.Index).Value)) Then
                        If MAnbar = True Then
                            If MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار مقصد است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                        Else
                            MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار مقصد است و قابل تغییر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                End If
            End If
            Dim frmlk As New Kala_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = 0
                DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = 0
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = Tmp_OneGroup + " - " + Tmp_TwoGroup
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = IdKala
                DGV1.Item("Cln_OneAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeOneAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeTwoAnbar", DGV1.CurrentRow.Index).Value = ""
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
        If DGV1.CurrentCell.ColumnIndex = 4 Then
            e.Handled = True
            If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then Exit Sub
            Dim frmlk As New Anbar_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.Item("Cln_OneAnbar", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                DGV1.Item("Cln_CodeOneAnbar", DGV1.CurrentRow.Index).Value = IdKala
                Try
                    DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Selected = True
                Catch ex As Exception

                End Try
            Else
                Try
                    DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Selected = True
                Catch ex As Exception

                End Try
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
                DGV1.Item("Cln_TwoAnbar", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                DGV1.Item("Cln_CodeTwoAnbar", DGV1.CurrentRow.Index).Value = IdKala
                Try
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Selected = True
                Catch ex As Exception

                End Try
            Else
                Try
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Selected = True
                Catch ex As Exception

                End Try
            End If
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If DGV1.CurrentCell.ColumnIndex = 3 Then
            If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Or DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
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

        If DGV1.CurrentCell.ColumnIndex = 6 Then
            If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then
                e.Handled = True
                Exit Sub
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

            If DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = True Then
                    DGV1.Item("Cln_b", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) <= 0 Then txt_dgv.Text = 0
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = True Then
                    DGV1.Item("Cln_Count", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV1.UserDeletingRow
        If Not String.IsNullOrEmpty(LSanad.Text) Then
            LimitMojody()
            If Not (DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value Is DBNull.Value Or DGV1.Item("Cln_OldTwoAnbar", DGV1.CurrentRow.Index).Value Is DBNull.Value) Then
                If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldKol", DGV1.CurrentRow.Index).Value), CDbl(DGV1.Item("Cln_OldJoz", DGV1.CurrentRow.Index).Value), CLng(DGV1.Item("Cln_OldTwoAnbar", DGV1.CurrentRow.Index).Value)) Then
                    If MAnbar = True Then
                        If MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار مقصد است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then e.Cancel = True
                    Else
                        MessageBox.Show("کالای سطر شماره" & DGV1.CurrentRow.Index + 1 & " کمتر از موجودی انبار مقصد است و قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
End Class