Imports System.Data.SqlClient
Imports System.Transactions
Public Class Manage_Chk_Bank
    Dim rwcnt As Integer
    Dim ds_bank As New DataSet
    Dim dta_bank As New SqlDataAdapter()

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        Try
            DGV2.DataSource = Nothing
            If DGV1.RowCount = rwcnt Then
                If DGV1.RowCount <= 0 Then Exit Sub
                If Not String.IsNullOrEmpty(TxtIdBank.Text.Trim) Then
                    GroupBox3.Enabled = False

                    Dim ds_Chk As New DataSet
                    ds_Chk.Clear()
                    Dim dta_chk As New SqlDataAdapter
                    If Not dta_chk Is Nothing Then dta_chk.Dispose()
                    dta_chk = New SqlDataAdapter("SELECT Chk_Get_Pay.NumChk,Chk_Id.IdBank,Chk_Get_Pay.Current_State,[State]= CASE Chk_Get_Pay.Current_State WHEN 0 Then N'در جریان وصول' WHEN 1 Then N'وصول شده' WHEN 2 Then N'برگشتی' WHEN 3 Then N'تضمینی' WHEN 4 Then N'برات' ELSE N'نا مشخص' END FROM Chk_Id INNER JOIN Chk_Get_Pay ON Chk_Id.Id = Chk_Get_Pay.ID WHERE (Current_Kind =1 AND Kind =1)  AND (IdBank =" & CLng(TxtIdBank.Text) & ") AND (NumChk Between " & DGV1.Item("Cln_num1", e.RowIndex).Value & " and " & DGV1.Item("Cln_num2", e.RowIndex).Value & ") UNION SELECT Lasheh_Chk.NumChk, Define_Chk.ID As IdBank,Current_State=-2,[State]=N'لاشه' FROM Define_Chk INNER JOIN Lasheh_Chk ON Define_Chk.Aid = Lasheh_Chk.Id WHERE (Define_Chk.ID =" & CLng(TxtIdBank.Text) & ") AND (NumChk Between " & DGV1.Item("Cln_num1", e.RowIndex).Value & " and " & DGV1.Item("Cln_num2", e.RowIndex).Value & ") UNION ALL SELECT  NumChk,IdBank,Current_State=1,[State]=N'وصول شده' FROM Sanad_Translate_BoxBank WHERE NUMCHK Is NOt NULL AND Stat=1 AND IdBank =" & CLng(TxtIdBank.Text) & " AND (NumChk Between " & DGV1.Item("Cln_num1", e.RowIndex).Value & " and " & DGV1.Item("Cln_num2", e.RowIndex).Value & ") UNION ALL SELECT NumChk,IdBankBes As IdBank,Current_State=1,[State]=N'وصول شده' FROM Sanad_BankTBank_Bes WHERE NUMCHK Is NOt NULL AND IdBankBes =" & CLng(TxtIdBank.Text) & " AND (NumChk Between " & DGV1.Item("Cln_num1", e.RowIndex).Value & " and " & DGV1.Item("Cln_num2", e.RowIndex).Value & ")", DataSource)
                    dta_chk.Fill(ds_Chk)


                    For i As Long = DGV1.Item("Cln_num1", e.RowIndex).Value To DGV1.Item("Cln_num2", e.RowIndex).Value
                        Dim dr() As DataRow = ds_Chk.Tables(0).Select("NumChk=" & i)
                        If dr.Length <= 0 Then
                            Dim row As DataRow = ds_Chk.Tables(0).NewRow
                            row.Item("NumChk") = i
                            row.Item("IdBank") = CLng(TxtIdBank.Text)
                            row.Item("Current_State") = -1
                            row.Item("State") = "استفاده نشده"
                            ds_Chk.Tables(0).Rows.Add(row)
                        End If
                    Next i


                    DGV2.AutoGenerateColumns = False
                    Dim dv As DataView = ds_Chk.Tables(0).DefaultView
                    dv.Sort = "NumChk"
                    DGV2.DataSource = dv
                End If
                GroupBox3.Enabled = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "DGV1_RowEnter")
            GroupBox3.Enabled = True
        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 41, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 41, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 41, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 41, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Function GetChkById(ByVal Id As Long) As Boolean
        Try
            Dim t_ds As New DataSet
            Dim str As String = "SELECT * FROM Define_Chk WHERE  id=" & Id
            Dim t_dta As New SqlDataAdapter(str, DataSource)
            '''''''''''''''''''''''''''
            rwcnt = 0
            t_ds.Clear()
            If Not t_dta Is Nothing Then
                t_dta.Dispose()
            End If
            t_dta = New SqlDataAdapter(str, DataSource)
            t_dta.Fill(t_ds)
            '''''''''''''''''''''''''''''''''''''''''''
            rwcnt = t_ds.Tables(0).Rows.Count
            If t_ds.Tables(0).Rows.Count <= 0 Then
                DGV1.DataSource = Nothing
                DGV2.Rows.Clear()
                Return False
            End If
            '''''''''''''''''''''''''''
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = t_ds.Tables(0)
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "GetChkById")
            Return False
        End Try
        
    End Function

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            If String.IsNullOrEmpty(TxtIdBank.Text.Trim) Then
                MessageBox.Show("هیچ بانکی جهت اخذ دسته چک جدید انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBank.Focus()
                Exit Sub
            End If

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Dim frmchk As New SetChkBank
            frmchk.LName.Text = TxtBank.Text
            frmchk.Ledit.Text = 0
            frmchk.LID.Text = TxtIdBank.Text
            frmchk.ShowDialog()
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "BtnNew_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ دسته چکی برای ویرایش انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            If Me.GetCountstateForDel(DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_IdBank", DGV1.CurrentRow.Index).Value) > 0 Then
                MessageBox.Show("دسته چک مورد نظر استفاده شده است و عملیات ویرایش بر روی آن قابل انجام نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using frmchk As New SetChkBank
                frmchk.LName.Text = TxtBank.Text
                frmchk.Ledit.Text = DGV1.Item("Cln_id", DGV1.CurrentRow.Index).Value
                frmchk.LID.Text = DGV1.Item("Cln_IdBank", DGV1.CurrentRow.Index).Value
                frmchk.Txtmon1.Text = DGV1.Item("Cln_Num1", DGV1.CurrentRow.Index).Value
                frmchk.Txtmon2.Text = DGV1.Item("Cln_Num2", DGV1.CurrentRow.Index).Value
                frmchk.Cmbtype.Text = DGV1.Item("Cln_state", DGV1.CurrentRow.Index).Value
                frmchk.ShowDialog()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "BtnEdit_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ دسته چکی برای حذف انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            If Me.GetCountstateForDel(DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_IdBank", DGV1.CurrentRow.Index).Value) > 0 Then
                MessageBox.Show("دسته چک مورد نظر استفاده شده است و عملیات حذف بر روی آن قابل انجام نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            If MessageBox.Show("آیا برای حذف دسته چک مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Dim nam As String = TxtBank.Text
            Me.DelChk(DGV1.Item("Cln_id", DGV1.CurrentRow.Index).Value)
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف دسته چک", "حذف", "حذف دسته چک بانک :" & nam & " از شماره : " & DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value & " تا " & DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value, "")
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "BtnDel_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DelChk(ByVal idb As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using Cmd As New SqlCommand("DELETE  FROM Define_Chk WHERE Define_Chk.Aid=@idb", ConectionBank)
                Cmd.Parameters.AddWithValue("@idb", SqlDbType.BigInt).Value = idb
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
                MessageBox.Show("دسته چک انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "DelChk")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub BtnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnList.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("هیچ دسته چکی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            GroupBox1.Enabled = False
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            ''''''''''''''''''''''''''''''
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف دسته چک", "چاپ لیست", "چاپ از دسته چک :" & DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value & "-" & DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value, "")
            '''''''''''''''''''''''''''''''''''
            Using FrmPrint As New FrmPrint
                FrmPrint.PrintSQl = "SELECT Chk_Get_Pay.NumChk,Chk_Get_Pay.PayDate ,Chk_Get_Pay.MoneyChk ,[State]= CASE Chk_Get_Pay.Current_State WHEN 0 Then N'در جریان وصول' WHEN 1 Then N'وصول شده' WHEN 2 Then N'برگشتی' WHEN 3 Then N'تضمینی' WHEN 4 Then N'برات' ELSE N'نا مشخص' END ,Name=Case WHEN Chk_Get_Pay.Current_Type <=12 Then (Select Nam FROM Define_People WHERE Id=Chk_Id.Current_IdPeople ) WHEN Chk_Get_Pay.Current_Type =13 Then N'سرمایه' WHEN Chk_Get_Pay.Current_Type =14 Then N'اموال' WHEN Chk_Get_Pay.Current_Type =15 Then N'درآمد' WHEN Chk_Get_Pay.Current_Type =16 Then N'هزینه' WHEN Chk_Get_Pay.Current_Type =17 Then N'صندوق' WHEN Chk_Get_Pay.Current_Type =18 Then N'بانک به بانک' END FROM Chk_Id INNER JOIN Chk_Get_Pay ON Chk_Id.Id = Chk_Get_Pay.ID WHERE (Current_Kind =1 AND Kind =1)  AND (IdBank =" & CLng(TxtIdBank.Text) & ") AND (NumChk Between " & DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value & " and " & DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value & ") UNION SELECT Lasheh_Chk.NumChk,PayDate=N'',MoneyChk=0,[State]=N'لاشه',Name=N'' FROM Define_Chk INNER JOIN Lasheh_Chk ON Define_Chk.Aid = Lasheh_Chk.Id WHERE (Define_Chk.ID =" & CLng(TxtIdBank.Text) & ") AND (NumChk Between " & DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value & " and " & DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value & ") UNION ALL SELECT NumChk,D_Date As PayDate,Mon AS MoneyChk,[State]=N'وصول شده',Name=N'انتقالات بانک و صندوق' FROM Sanad_Translate_BoxBank WHERE NUMCHK Is NOt NULL AND Stat=1 AND IdBank =" & CLng(TxtIdBank.Text) & " AND (NumChk Between " & DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value & " and " & DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value & ") UNION ALL SELECT NumChk,D_Date As PayDate,Mon AS MoneyChk,[State]=N'وصول شده',Name=N'بانک به بانک' FROM Sanad_BankTBank_Bes WHERE NUMCHK Is NOt NULL AND IdBankBes =" & CLng(TxtIdBank.Text) & " AND (NumChk Between " & DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value & " and " & DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value & ")"
                FrmPrint.CHoose = "SODORCHK"
                FrmPrint.Num1 = DGV1.Item("Cln_num1", DGV1.CurrentRow.Index).Value
                FrmPrint.Num2 = DGV1.Item("Cln_num2", DGV1.CurrentRow.Index).Value
                FrmPrint.Str1 = TxtDisc.Text.Trim
                FrmPrint.ShowDialog()
            End Using
            ''''''''''''''''''''''''''''''
            GroupBox1.Enabled = True
            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "BtnList_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChange.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("هیچ دسته چکی برای تغییر وضعیت وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Me.GetCountstate(DGV2.Item("Cln_num", DGV2.CurrentRow.Index).Value, DGV1.Item("Cln_IdBank", DGV1.CurrentRow.Index).Value) > 0 Then
                MessageBox.Show("شماره چک مورد نظر استفاده شده است و عملیات تغییر وضعیت بر روی آن قابل انجام نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim St As Long = -2
            If Me.GetStateLasheh(DGV2.Item("Cln_num", DGV2.CurrentRow.Index).Value, DGV1.Item("Cln_IdBank", DGV1.CurrentRow.Index).Value) > 0 Then
                St = -2
            Else
                St = -1
            End If
            If St = -1 Then
                Dim nam As String = DGV2.Item("Cln_num", DGV2.CurrentRow.Index).Value
                If MessageBox.Show("آیا برای تغییر وضعیت شماره چک مورد نظر به وضعیت لاشه چک مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                Me.ChangeChk(DGV2.Item("Cln_num", DGV2.CurrentRow.Index).Value, DGV1.Item("Cln_id", DGV1.CurrentRow.Index).Value, -1)
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف دسته چک", "تغییر وضعیت", "تغییر به لاشه :" & nam, "")
            ElseIf St = -2 Then
                Dim nam As String = DGV2.Item("Cln_num", DGV2.CurrentRow.Index).Value
                If MessageBox.Show("آیا برای تغییر وضعیت شماره چک مورد نظر به وضعیت استفاده نشده مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                Me.ChangeChk(DGV2.Item("Cln_num", DGV2.CurrentRow.Index).Value, DGV1.Item("Cln_id", DGV1.CurrentRow.Index).Value, -2)
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف دسته چک", "تغییر وضعیت", "تغییر به استفاده نشده :" & nam, "")
            End If
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "BtnChange_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function GetCountstate(ByVal NumChk As Double, ByVal Idbank As Long) As Long
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT COUNT(Chk_Get_Pay.NumChk) as CountChk FROM Chk_Id INNER JOIN Chk_Get_Pay ON Chk_Id.Id = Chk_Get_Pay.ID WHERE (Current_Kind =1 AND Kind =1)  AND (IdBank =" & Idbank & ") AND (NumChk= " & NumChk & ")", ConectionBank)
                Dim Res As Long = 1
                Res = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "GetCountstate")
            Return 1
        End Try
    End Function
    Private Function GetCountstateForDel(ByVal NumChk1 As Double, ByVal NumChk2 As Double, ByVal Idbank As Long) As Long
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT COUNT(Chk_Get_Pay.NumChk) as CountChk FROM Chk_Id INNER JOIN Chk_Get_Pay ON Chk_Id.Id = Chk_Get_Pay.ID WHERE (Current_Kind =1 AND Kind =1)  AND (IdBank =" & Idbank & ") AND (NumChk Between " & NumChk1 & " AND " & NumChk2 & ")", ConectionBank)
                Dim Res As Long = 1
                Res = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "GetCountstateForDel")
            Return 1
        End Try
    End Function
    Private Function GetStateLasheh(ByVal NumChk As Double, ByVal Idbank As Long) As Long
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT  COUNT(Lasheh_Chk.NumChk)As CountLasheh FROM Define_Chk INNER JOIN Lasheh_Chk ON Define_Chk.Aid = Lasheh_Chk.Id WHERE (Define_Chk.ID =" & Idbank & ") AND (NumChk= " & NumChk & ")", ConectionBank)
                Dim Res As Long = 1
                Res = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "GetStateLasheh")
            Return 1
        End Try
    End Function
    Private Sub RefreshBank()
        Try
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            If Not String.IsNullOrEmpty(TxtIdBank.Text) Then
                TxtBank.Focus()
                GetListChk(TxtIdBank.Text)
                DGV1.Focus()
            End If
            SetButton()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "RefreshBank")
            Me.Close()
        End Try
    End Sub
    Private Function ChangeChk(ByVal numchk As Double, ByVal idb As Long, ByVal Type As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            If Type = -1 Then
                Using Cmd As New SqlCommand("INSERT INTO Lasheh_Chk(id,NumChk) VALUES (@id,@NumChk)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@id", SqlDbType.BigInt).Value = idb
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = numchk
                    Cmd.ExecuteNonQuery()
                End Using
            ElseIf Type = -2 Then
                Using Cmd As New SqlCommand("DELETE  FROM Lasheh_Chk WHERE ((Lasheh_Chk.id=@id) And (Lasheh_Chk.NumChk=@NumChk))", ConectionBank)
                    Cmd.Parameters.AddWithValue("@id", SqlDbType.BigInt).Value = idb
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = numchk
                    Cmd.ExecuteNonQuery()
                End Using
            End If

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("شماره چک انتخابی شما در حال حاضر قابل تغییر وضعیت دادن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "ChangeChk")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub TxtBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBank.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
    End Sub
    Private Sub TxtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBank.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
            Dim frmlk As New bank_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.LState.Text = "WHERE State=N'جاری'"
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            e.Handled = True
            TxtBank.Focus()

            TxtBank.Text = ""
            TxtIdBank.Text = ""
            TxtDisc.Text = ""
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            If IdKala <> 0 Then
                TxtBank.Text = Tmp_Namkala
                TxtIdBank.Text = IdKala
                Me.GetListChk(IdKala)
                DGV1.Focus()
                TxtDisc.Text = Tmp_Namkala & "    ، شماره حساب     " & Tmp_OneGroup & "    ، شعبه     " & Tmp_TwoGroup
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetListChk(ByVal Id As Long)
        Try
            rwcnt = 0
            ds_bank.Clear()
            If Not dta_bank Is Nothing Then dta_bank.Dispose()
            dta_bank = New SqlDataAdapter("SELECT * FROM Define_Chk WHERE ID=" & Id, DataSource)
            dta_bank.Fill(ds_bank)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = ds_bank.Tables(0)
            rwcnt = ds_bank.Tables(0).Rows.Count
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "GetListChk")
            rwcnt = 0
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BargeChk_2.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnNew.Enabled = True Then Call BtnNew_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnChange.Enabled = True Then Call BtnChange_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnList.Enabled = True Then Call BtnList_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Manage_Chk_Bank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Manage_Chk_Bank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F33")
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
        DGV1.Columns("Cln_state").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("cln_type").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F33")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnNew.Enabled = False
                    BtnDel.Enabled = False
                    BtnEdit.Enabled = False
                    BtnChange.Enabled = False
                    BtnList.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        BtnNew.Enabled = False
                        BtnDel.Enabled = False
                        BtnEdit.Enabled = False
                        BtnChange.Enabled = False
                        BtnList.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnNew.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            BtnDel.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            BtnEdit.Enabled = False
                        End If
                        If Access_Form.Substring(6, 1) = 0 Then
                            BtnChange.Enabled = False
                        End If
                        If Access_Form.Substring(7, 1) = 0 Then
                            BtnList.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnNew.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                BtnChange.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub TxtBank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBank.TextChanged

    End Sub
End Class