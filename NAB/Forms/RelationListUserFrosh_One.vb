Imports System.Data.SqlClient
Imports System.Transactions
Public Class RelationListUserFrosh_One

    Dim ds As New DataSet
    Dim str As String = "SELECT  ListUser_OG.IdUser, Define_User.Nam FROM ListUser_OG INNER JOIN Define_User ON ListUser_OG.IdUser = Define_User.Id"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource

    Dim dsD As New DataSet
    Dim strD As String = ""
    Dim dtaD As New SqlDataAdapter()
    Dim bsD As New BindingSource

    Dim dsO As New DataSet
    Dim strO As String = ""
    Dim dtaO As New SqlDataAdapter()
    Dim bsO As New BindingSource

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_DDgv(CLng(DGV1.Item("Cln_Code", e.RowIndex).Value))
        Catch ex As Exception
            DGV2.DataSource = Nothing
        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV3_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.RowEnter
        Try
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV4.DataSource = Nothing
            Fill_KDgv(CLng(DGV3.Item("Cln_IdVisit", e.RowIndex).Value))
            Fill_ODgv(CLng(DGV3.Item("Cln_IdVisit", e.RowIndex).Value))
        Catch ex As Exception
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV4.DataSource = Nothing
        End Try
    End Sub

    Private Sub Fill_KDgv(ByVal Idvisit As Long)
        Try
            DGV1.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT REPLACE(ListkalaU_OG.Kala,'.','/') As Kala , ListkalaU_OG.Mon,ListkalaU_OG.IdKala,ListkalaU_OG.Id,Define_OneGroup .NamOne As nam FROM ListkalaU_OG INNER JOIN Define_OneGroup  ON ListkalaU_OG.Idkala = Define_OneGroup.Id WHERE IdLinkUser =" & Idvisit
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "ListkalaU_OG")
            DGV1.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "ListkalaU_OG"
            DGV1.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub Fill_DDgv(ByVal Idvisit As Long)
        Try
            DGV2.DataSource = Nothing
            dsD.Clear()
            strD = "SELECT REPLACE(ListDarsadU_OG.Frosh,'.','/') As Frosh, REPLACE(ListDarsadU_OG.Darsad,'.','/') AS Darsad, Define_Group_P.nam FROM ListDarsadU_OG INNER JOIN Define_Group_P ON ListDarsadU_OG.IdGroup = Define_Group_P.Id WHERE IdlinkKala =" & Idvisit
            If Not dtaD Is Nothing Then
                dtaD.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaD = New SqlDataAdapter(strD, DataSource)
            dtaD.Fill(dsD, "ListDarsadU_OG")
            DGV2.AutoGenerateColumns = False
            bsD.DataSource = dsD
            bsD.DataMember = "ListDarsadU_OG"
            DGV2.DataSource = bsD
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "fill_Ddgv")
            Me.Close()
        End Try
    End Sub

    Private Sub Fill_ODgv(ByVal Idvisit As Long)
        Try
            DGV4.DataSource = Nothing
            dsO.Clear()
            strO = "SELECT  REPLACE(ListOrderDarsadU_OG.Darsad,'.','/') As Darsad, Define_Group_P.nam FROM ListOrderDarsadU_OG INNER JOIN Define_Group_P ON ListOrderDarsadU_OG.IdGroup = Define_Group_P.Id WHERE IdLinkUser =" & Idvisit
            If Not dtaO Is Nothing Then
                dtaO.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaO = New SqlDataAdapter(strO, DataSource)
            dtaO.Fill(dsO, "ListOrderDarsadU_OG")
            DGV4.AutoGenerateColumns = False
            bsO.DataSource = dsO
            bsO.DataMember = "ListOrderDarsadU_OG"
            DGV4.DataSource = bsO
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "Fill_ODgv")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub RelationListVisitorFrosh_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
    End Sub

    Private Sub RelationListVisitorFrosh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RelationListVisitorFrosh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F149")
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
        Me.Fill_Dgv()
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_NameV").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV4.Columns("Cln_Group2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub
    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F149")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmdedit.Enabled = False
                    cmddel.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmdedit.Enabled = False
                        cmddel.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            cmdadd.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            cmdedit.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            cmddel.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                cmdadd.Enabled = False
                cmdedit.Enabled = False
                cmddel.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "SetButton")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_Dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "ListUser_OG")
            DGV3.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "ListUser_OG"
            DGV3.DataSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV4.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "ListUser_OG")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            Using FrmAdd As New RelationUserFrosh_One
                FrmAdd.EDIT = 0
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "cmdadd_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            If DGV3.RowCount <= 0 Then
                MessageBox.Show("کاربری برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            Using FrmAdd As New RelationUserFrosh_One
                FrmAdd.EDIT = DGV3.Item("Cln_IdVisit", DGV3.CurrentRow.Index).Value
                FrmAdd.TxtIdVisitor.Text = DGV3.Item("Cln_IdVisit", DGV3.CurrentRow.Index).Value
                FrmAdd.TxtVisitor.Text = DGV3.Item("Cln_NameV", DGV3.CurrentRow.Index).Value
                Tmp_String1 = DGV3.Item("Cln_NameV", DGV3.CurrentRow.Index).Value
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "cmdadd_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If DGV3.RowCount <= 0 Then
                MessageBox.Show("کاربری برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد کاربر جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Dim nam As String = DGV3.Item("Cln_NameV", DGV3.CurrentRow.Index).Value
                Me.DeleteUser(CLng(DGV3.Item("Cln_IdVisit", DGV3.CurrentRow.Index).Value))
                Me.RefreshBank()
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کاربر و فروش هدف-گروه اصلی", "حذف", "حذف فروش هدف کاربر :" & nam, "")
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "cmddel_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DeleteUser(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM ListUser_OG WHERE IdUser=@IdUser", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id
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
                MessageBox.Show("کاربر انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationListUserFrosh_One", "DeleteUser")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ByAsliKalaUser.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then cmddel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DGV4_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV4.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV4.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV4.DefaultCellStyle.Font, b, DGV4.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV4.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV4.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
End Class