Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmListPromotion
    Dim ROW As Integer
    Dim ds As New DataSet
    Dim str As String = "SELECT DefinePromotion.Id,DefinePromotion.IdGroup, DefinePromotion.Fe, Define_Group_P.nam As GroupNam, Define_Kala.Nam AS NamKala, DefinePromotion.IdKala FROM DefinePromotion INNER JOIN Define_Kala ON DefinePromotion.IdKala = Define_Kala.Id INNER JOIN Define_Group_P ON DefinePromotion.IdGroup = Define_Group_P.Id"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource

    Private Sub DGV_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_KDgv(CLng(DGV.Item("Cln_Id", e.RowIndex).Value))
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
            dta.Fill(ds, "DefinePromotion")
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "DefinePromotion"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_KDgv(ByVal IdCity As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT Darsad, Fe, TaKala, AzKala, Id FROM DefineListPromotion WHERE IdLink=" & IdCity
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "DefineListPromotion")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "DefineListPromotion"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub DefineCostKala_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
    End Sub

    Private Sub FrmListPromotion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub


    Private Sub DefineCostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F126")
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
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub
    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F126")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmdedit.Enabled = False
                    cmddel.Enabled = False
                    BtnPrint.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmdedit.Enabled = False
                        cmddel.Enabled = False
                        BtnPrint.Enabled = False
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
                        If Access_Form.Substring(6, 1) = 0 Then
                            BtnPrint.Enabled = False
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "SetButton")
            Me.Close()
        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            DGV2.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "DefinePromotion")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            Using FrmAdd As New FrmPromotion
                FrmAdd.EDIT.Text = "0"
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "cmdadd_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If DGV.RowCount <= 0 Or DGV2.RowCount <= 0 Then
            MessageBox.Show("سطری برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        ROW = DGV.CurrentRow.Index
        Try
            Using FrmAdd As New FrmPromotion
                ' FrmAdd.ChkGroup.Enabled = False
                FrmAdd.EDIT.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                FrmAdd.TxtIdkala.Text = DGV.Item("Cln_IdKala", DGV.CurrentRow.Index).Value
                FrmAdd.TxtIdGroup.Text = DGV.Item("Cln_IdGroup", DGV.CurrentRow.Index).Value
                Tmp_String1 = DGV.Item("Cln_IdKala", DGV.CurrentRow.Index).Value
                Tmp_String2 = DGV.Item("Cln_IdGroup", DGV.CurrentRow.Index).Value
                FrmAdd.TxtKala.Text = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value
                FrmAdd.Lname.Text = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value
                FrmAdd.TxtFe.Text = CDbl(DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value)
                FrmAdd.TxtGroup.Text = DGV.Item("Cln_Group", DGV.CurrentRow.Index).Value
                Array.Resize(AllSelectKala, 0)
                For i As Integer = 0 To DGV2.RowCount - 1
                    Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                    AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV2.Item("Cln_Az", i).Value.ToString.Replace(".", "/")
                    AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV2.Item("Cln_Ta", i).Value.ToString.Replace(".", "/")
                    AllSelectKala(AllSelectKala.Length - 1).EndCost = CDbl(DGV2.Item("Cln_Fe2", i).Value)
                    AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV2.Item("Cln_Darsad", i).Value.ToString.Replace(".", "/")
                Next
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
            If ROW <= DGV.RowCount - 1 Then DGV.Item(0, ROW).Selected = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "cmdedit_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("کالایی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد کالای جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Me.DeleteCity(CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value))
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت ویژه", "حذف", "حذف قیمت کالای :" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " در گروه " & DGV.Item("Cln_Group", DGV.CurrentRow.Index).Value, "")
                Me.RefreshBank()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "cmddel_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DeleteCity(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM DefinePromotion WHERE ID=@Id", ConectionBank)
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
                MessageBox.Show("کالای انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "DeleteCity")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function


    Private Function DeleteEndCity(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using CmdSelect As New SqlCommand("SELECT COUNT(*) FROM Define_CostKala WHERE IDCity=@IdCity", ConectionBank)
                CmdSelect.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = Id
                If CmdSelect.ExecuteScalar <= 0 Then
                    Using Cmd As New SqlCommand("DELETE FROM Define_CityCostKala WHERE IDCity=@Id", ConectionBank)
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListPromotion", "DeleteEndCity")
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

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KalaVaSCost.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnPrint.Enabled = True Then Call BtnPrint_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت ویژه", "چاپ", "چاپ قیمت کالای :" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value & " در گروه " & DGV.Item("Cln_Group", DGV.CurrentRow.Index).Value, "")
        Using frmp As New FrmPrint
            frmp.PrintSQl = "SELECT DefinePromotion.IdKala, DefinePromotion.Fe, REPLACE(DefineListPromotion.AzKala,'.','/') As Az, REPLACE(DefineListPromotion.TaKala,'.','/') As Ta, DefineListPromotion.Fe AS Fe2,REPLACE(DefineListPromotion.Darsad,'.','/') As Darsad, Define_Kala.Nam As Namkala, Define_Group_P.nam AS NamGroup FROM DefinePromotion INNER JOIN DefineListPromotion ON DefinePromotion.Id = DefineListPromotion.IdLink INNER JOIN Define_Kala ON DefinePromotion.IdKala = Define_Kala.Id INNER JOIN Define_Group_P ON DefinePromotion.IdGroup = Define_Group_P.Id WHERE DefinePromotion.Id=" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
            frmp.CHoose = "SCOST"
            frmp.ShowDialog()
        End Using
    End Sub
End Class