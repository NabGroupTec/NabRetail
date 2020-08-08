Imports System.Data.SqlClient
Imports System.Transactions
Public Class AddEdit_UTB
    Public EDIT, IdRow As Long
    Dim TmpArray() As KalaSelect = Nothing
    Dim ds_O As New DataSet
    Dim str_O As String = "select Id,Nam From Define_User WHERE (Id<>1 OR Nam<>'Admin' OR Nam<>'admin')"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtUser.Text.Trim) Or CmbUser.Text = "" Or CmbUser.FindStringExact(CmbUser.Text) = -1 Then
                MessageBox.Show("هیچ کاربری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbUser.Focus()
                Exit Sub
            End If

            If TxtUser.Text = "-1" Then
                MessageBox.Show("هیچ کاربری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbUser.Focus()
                Exit Sub
            End If

            If DGV.Item("Cln_name", DGV.RowCount - 1).Value <> "" Then
                MessageBox.Show(" وضعيت سطر شماره" & "{ " & DGV.RowCount & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV.RowCount <= 1 Then
                MessageBox.Show("صندوقی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For i As Integer = 0 To DGV.RowCount - 2

                    If DGV.Item("Cln_name", i).Value = "" Then
                        MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    Dim count As Integer = 0
                    For j As Integer = 0 To DGV.RowCount - 2
                        If (DGV.Item("Cln_IdP", i).Value.ToString = DGV.Item("Cln_IdP", j).Value.ToString) And (DGV.Item("Cln_IdP", i).Value.ToString = DGV.Item("Cln_IdP", j).Value.ToString) Then
                            count += 1
                        End If
                        If count > 1 Then
                            MessageBox.Show("نام صندوق سطر شماره  " & "{" & i + 1 & "}" & " تكراري است لطفا ان را اصلاح نماييد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Next j
                Next i
            End If
            If EDIT = 0 Then
                If CheckPeopleRepeate(CLng(TxtUser.Text)) Then
                    If SavePeople(CLng(TxtUser.Text)) Then Me.Close()
                End If
            ElseIf EDIT = 1 Then
                ' If CheckPeopleRepeateEdit(CLng(TxtUser.Text)) Then
                If EditPeople(CLng(TxtUser.Text)) Then Me.Close()
                ' End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "BtnSave_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function CheckPeopleRepeate(ByVal IdUser As Long) As Boolean
        Try
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter
            Dim Str As String = "SELECT Id,IdUser,IDB FROM Define_UserRPBox"
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter(Str, DataSource)
            Dta.Fill(Ds, "Define_UserRPBox")
            For i As Integer = 0 To DGV.RowCount - 2
                Dim dr() As DataRow = Ds.Tables("Define_UserRPBox").Select("IdUser=" & IdUser & " AND IDB=" & DGV.Item("Cln_IdP", i).Value)
                If dr.Length > 0 Then
                    MessageBox.Show(" صندوق سطر شماره  " & "{" & i + 1 & "}" & " قبلا برای این کاربر ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "CheckPeopleRepeate")
            Return False
        End Try

    End Function
    Private Function CheckPeopleRepeateEdit(ByVal IdUser As Long) As Boolean
        Try
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter
            Dim Str As String = "SELECT Id,IdUser,IDB FROM Define_UserRPBox"
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter(Str, DataSource)
            Dta.Fill(Ds, "Define_UserRPBox")
            For i As Integer = 0 To DGV.RowCount - 2
                Dim dr() As DataRow = Ds.Tables("Define_UserRPBox").Select("IdUser=" & IdUser & " AND IDB=" & DGV.Item("Cln_IdP", i).Value)
                If dr.Length > 0 Then
                    MessageBox.Show(" صندوق سطر شماره  " & "{" & i + 1 & "}" & " قبلا برای این کاربر ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "CheckPeopleRepeate")
            Return False
        End Try

    End Function
    Private Function SavePeople(ByVal IdUser As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using CmdSelect As New SqlCommand("SELECT Count(IdUser) FROM Define_UserRBox WHERE IdUser=@IdUser", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                If CmdSelect.ExecuteScalar() <= 0 Then
                    Using Cmd As New SqlCommand("INSERT INTO Define_UserRBox(IdUser) VALUES(@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using


            Using Cmd As New SqlCommand("INSERT INTO Define_UserRPBox(IdUser,IdB) VALUES(@IdUser,@IdB)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdB", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کاربر و صندوق ", "جدید", " کاربر :" & CmbUser.Text, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "SavePeople")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Function EditPeople(ByVal IdUser As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using CmdSelect As New SqlCommand("SELECT Count(IdUser) FROM Define_UserRBox WHERE IdUser=@IdUser", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                Dim Result As Long = CmdSelect.ExecuteScalar
                If Result <= 0 Then
                    Using Cmd As New SqlCommand("INSERT INTO Define_UserRBox(IdUser) VALUES(@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Using Cmd As New SqlCommand("DELETE FROM Define_UserRPBox WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To TmpArray.Length - 1
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = TmpArray(i).Id
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            Using Cmd As New SqlCommand("INSERT INTO Define_UserRPBox(IdUser,IdB) VALUES(@IdUser,@IdB)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdB", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdP", i).Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کاربر و صندوق ", "ویرایش", If(Tmp_OneGroup = CmbUser.Text.Trim, "ویرایش کاربر :" & CmbUser.Text.Trim, "ویرایش از کاربر :" & Tmp_OneGroup & " به " & CmbUser.Text), "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "EditPeople")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Sub Fill_User()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_O = New SqlDataAdapter(str_O, DataSource)
            dta_O.Fill(ds_O, "Define_User")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "Fill_User")
            Me.Close()
        End Try
    End Sub

    Private Sub AddEdit_CostKala_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        CmbUser.Focus()
    End Sub

    Private Sub AddEdit_CostKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub AddEdit_CostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.Fill_User()
        Me.FillUser()
        If EDIT = 1 Then
            CmbUser.Text = Tmp_OneGroup
            TxtUser.Text = TxtIdOstan
            Try
                If AllSelectKala.Length > 0 Then
                    Array.Resize(TmpArray, 0)
                    DGV.Rows.Clear()
                    DGV.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV.Rows.Add()
                        DGV.Item("Cln_Name", DGV.RowCount - 1).Value = AllSelectKala(i).Namekala
                        DGV.Item("Cln_IdP", DGV.RowCount - 1).Value = AllSelectKala(i).IdKala
                        DGV.Item("Cln_Id", DGV.RowCount - 1).Value = AllSelectKala(i).Id
                        Array.Resize(TmpArray, TmpArray.Length + 1)
                        TmpArray(TmpArray.Length - 1).Id = AllSelectKala(i).Id
                    Next
                    DGV.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGV.Focus()
            Catch ex As Exception
                Me.Close()
            End Try
        End If
    End Sub
    Private Sub RefreshBank()
        ds_O.Clear()
        dta_O.Fill(ds_O, "Define_User")
        Me.FillUser()
    End Sub
    Private Sub FillUser()
        CmbUser.Items.Clear()
        CmbUser.Text = ""
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbUser.Items.Add(ds_O.Tables(0).Rows(i).Item("Nam"))
        Next
    End Sub

    Private Function GetIdUser(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("Nam ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("Id")
        Else
            Return -1
        End If
    End Function

    Private Sub CmbUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbUser.KeyDown
        If CmbUser.DroppedDown = False Then
            CmbUser.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            DGV.Focus()
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbUser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbUser.LostFocus
        TxtUser.Text = GetIdUser(CmbUser.Text)
    End Sub

    Private Sub CmbUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbUser.SelectedIndexChanged
        TxtUser.Text = GetIdUser(CmbUser.Text)
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
                    DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value = ""
                    DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = ""
                End If
        End Select
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 38, 5)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 38, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = "" Then
            e.Handled = True
            DGV.Item("Cln_name", DGV.CurrentRow.Index).Value = ""
            DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value = ""
            DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value = ""
        End If
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        If DGV.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Using frmlk As New Box_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
            End Using
            DGV.Focus()
            If Tmp_Namkala <> "" Then
                DGV.AllowUserToAddRows = False
                DGV.Rows.Add()
                DGV.Item("Cln_Name", DGV.RowCount - 1).Value = Tmp_Namkala
                DGV.Item("Cln_IdP", DGV.RowCount - 1).Value = IdKala
                DGV.Item("Cln_Id", DGV.RowCount - 1).Value = 0
                DGV.AllowUserToAddRows = True
                DGV.Item("Cln_Name", DGV.RowCount - 1).Selected = True
            Else
                DGV.Item("Cln_Name", DGV.RowCount - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه صندوقهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        DGV.Rows.Clear()
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "UseroBox.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then Call BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BtnAdvance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub BtnCancel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCancel.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnDel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnDel.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnSave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnSave.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Fnew = True
            Using FrmUser As New DefineUser
                FrmUser.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "AddEdit_UTB", "Button1_Click")
        End Try
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        Me.GetKey(e)
    End Sub
End Class

