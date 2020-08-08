Imports System.Data.SqlClient
Imports System.Transactions
Public Class DefineUTB
    Dim ds As New DataSet
    Dim str As String = "SELECT Define_UserRBox.IdUser, Define_User.Nam FROM Define_User INNER JOIN Define_UserRBox ON Define_User.Id =Define_UserRBox.IdUser"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_KDgv(CLng(DGV.Item("Cln_IdUser", e.RowIndex).Value))
        Catch ex As Exception
            DGV2.DataSource = Nothing
        End Try
    End Sub
    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
    Private Sub Fill_Dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_UserRBox")
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_UserRBox"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_KDgv(ByVal IdUser As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT Define_Box.Nam, Define_UserRPBox.Id, Define_UserRPBox.IdUser, Define_UserRPBox.IDB FROM Define_UserRPBox INNER JOIN Define_Box ON Define_Box.ID = Define_UserRPBox.IDB WHERE IdUser =" & IdUser & " Order By Nam "
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "Define_UserRPBox")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "Define_UserRPBox"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub DefineCostKala_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
    End Sub

    Private Sub DefineCostKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DefineCostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not UCase(NamUser) = "ADMIN" Then
            MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Me.Fill_Dgv()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_People").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        If AllowEdit < 0 Then
            MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf AllowEdit = 1 Then
            cmdadd.Enabled = False
            cmdedit.Enabled = False
            cmddel.Enabled = False
            BtnDelKala.Enabled = False
        End If
    End Sub
    Private Sub RefreshBank()
        Try
            Me.RefreshUser()
            DGV2.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "Define_UserRBox")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            Using FrmAdd As New AddEdit_UTB
                FrmAdd.EDIT = 0
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "cmdadd_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If DGV.RowCount <= 0 Or DGV2.RowCount <= 0 Then
            MessageBox.Show("سطری برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Try
            Using FrmAdd As New AddEdit_UTB
                FrmAdd.EDIT = 1
                TxtIdOstan = DGV.Item("Cln_IdUser", DGV.CurrentRow.Index).Value
                Tmp_OneGroup = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value
                Array.Resize(AllSelectKala, 0)
                For i As Integer = 0 To DGV2.RowCount - 1
                    Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                    AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV2.Item("Cln_People", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).Id = DGV2.Item("Cln_Id", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV2.Item("Cln_IdP", i).Value
                Next
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "cmdedit_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("کاربری برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد کاربر جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Me.DeleteUser(CLng(DGV.Item("Cln_IdUser", DGV.CurrentRow.Index).Value))
                Me.RefreshBank()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "cmddel_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DeleteUser(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM Define_UserRPBox WHERE IDUser=@Id;DELETE FROM Define_UserRBox WHERE IDUser=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کاربر و صندوق", "حذف کاربر", "کاربر :" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value, "")

            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("کاربر انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "DeleteUser")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Function RefreshUser() As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM Define_UserRBox WHERE IdUser  IN(SELECT  DISTINCT Define_UserRBox.IdUser FROM Define_UserRBox WHERE IdUser Not IN (SELECT  DISTINCT Define_UserRPBox.IdUser FROM Define_UserRPBox))", ConectionBank)
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "RefreshUser")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Function DeleteBox(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM Define_UserRPBox WHERE ID=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("صندوق انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "DeleteBox")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Function DeleteEndUser(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using CmdSelect As New SqlCommand("SELECT COUNT(*) FROM Define_UserRPBox WHERE IDUser=@IdUser", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id
                If CmdSelect.ExecuteScalar <= 0 Then
                    Using Cmd As New SqlCommand("DELETE FROM Define_UserRBox WHERE IDUser=@Id", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                ' MessageBox.Show("کالای انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "DeleteEndUser")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        Me.RefreshBank()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        Me.RefreshBank()
    End Sub

    Private Sub DGV2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV2.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnDelKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelKala.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("صندوقی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد صندوق جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Dim kalanam As String = DGV2.Item("Cln_People", DGV2.CurrentRow.Index).Value
                Dim citynam As String = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value

                Dim IdC As Long = CLng(DGV2.Item("Cln_IdF", DGV2.CurrentRow.Index).Value)
                If Me.DeleteBox(CLng(DGV2.Item("Cln_Id", DGV2.CurrentRow.Index).Value)) Then Me.DeleteEndUser(IdC)
                Me.RefreshBank()

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کاربر و صندوق", "حذف صندوق", "صندوق :" & kalanam & " مربوط به کاربر :" & citynam, "")

            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineUTB", "BtnDelKala_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "UseroBox.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnDelKala.Enabled = True Then Call BtnDelKala_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BN.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnDelKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnDelKala.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmdadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdadd.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmddel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmddel.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmdedit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdedit.KeyDown
        Me.GetKey(e)
    End Sub
End Class