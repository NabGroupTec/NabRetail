Imports System.Data.SqlClient
Imports System.Transactions
Public Class DefineCostKala
    Dim ROW As Integer
    Dim ds As New DataSet
    Dim str As String = "SELECT Define_CityCostkala.IdCity, Define_City.NamCI, Define_Ostan.NamO,Define_Ostan.Code FROM Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_CityCostkala ON Define_City.Code = Define_CityCostkala.IdCity ORDER BY Define_Ostan.NamO,Define_City.NamCI"
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
            Fill_KDgv(CLng(DGV.Item("Cln_IdCity", e.RowIndex).Value))
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
    Private Sub DeleteDuplicate()
        'Dim con As New SqlConnection(DataSource)
        'Try
        '    If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
        '    If con.State <> ConnectionState.Open Then con.Open()
        '    Dim dtr As SqlDataReader = Nothing
        '    Dim Id As String = "("

        '    Using cmd As New SqlCommand("SELECT IdCity,IdKala FROM (SELECT COUNT(*) AS C_Count, EndCost, CostBigKala, CostSmalKala, IdCity, IdKala FROM  Define_CostKala GROUP By IdCity, IdKala,EndCost, CostBigKala, CostSmalKala)AS ListKala WHERE C_Count >1", ConectionBank)
        '        dtr = cmd.ExecuteReader
        '    End Using

        '    If dtr.HasRows Then
        '        While dtr.Read
        '            Using cmd As New SqlCommand("SELECT TOP 1 Id FROM Define_CostKala WHERE IdKala =" & dtr("IdKala") & " ANd IdCity =" & dtr("IdCity") & " ORDER BY Id DESC", con)
        '                Id &= cmd.ExecuteScalar & ","
        '            End Using
        '        End While
        '        Id = Id.Substring(0, Id.Length - 2)
        '        Id &= ")"

        '        Using cmd As New SqlCommand("DELETE FROM Define_CostKala WHERE Id NOT IN " & Id, con)
        '            cmd.ExecuteNonQuery()
        '        End Using

        '    Else
        '        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        '        If con.State <> ConnectionState.Closed Then con.Close()
        '        Exit Sub
        '    End If

        '    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        '    If con.State <> ConnectionState.Closed Then con.Close()
        'Catch ex As Exception
        '    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        '    If con.State <> ConnectionState.Closed Then con.Close()
        '    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "DeleteDuplicate")
        'End Try
    End Sub
    Private Sub Fill_Dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_CityCostKala")
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_CityCostKala"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_KDgv(ByVal IdCity As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT Define_CostKala.Id, Define_CostKala.IdKala, Define_CostKala.IdCity, Define_CostKala.CostSmalKala, Define_CostKala.CostBigKala,Define_CostKala.EndCost, Define_Kala.Nam FROM Define_CostKala INNER JOIN Define_Kala ON Define_CostKala.IdKala = Define_Kala.Id  WHERE Define_CostKala.IdCity=" & IdCity & " ORDER BY Nam"
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "Define_CostKala")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "Define_CostKala"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "fill_Kdgv")
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
        Access_Form = Get_Access_Form("F123")
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
        Me.RefreshCity()
        Me.Fill_Dgv()
        DGV.Columns("Cln_City").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_Namkala").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub
    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F123")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmdedit.Enabled = False
                    cmddel.Enabled = False
                    BtnDelKala.Enabled = False
                    BtnEditCost.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmdedit.Enabled = False
                        cmddel.Enabled = False
                        BtnDelKala.Enabled = False
                        BtnEditCost.Enabled = False
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
                            BtnDelKala.Enabled = False
                        End If
                        If Access_Form.Substring(7, 1) = 0 Then
                            BtnEditCost.Enabled = False
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
                BtnDelKala.Enabled = False
                BtnEditCost.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "SetButton")
            Me.Close()
        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            Me.RefreshCity()
            DGV2.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "Define_CityCostKala")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            Using FrmAdd As New AddEdit_CostKala
                FrmAdd.EDIT = 0
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "cmdadd_Click")
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
            Using FrmAdd As New AddEdit_CostKala
                FrmAdd.ChkLimit.Enabled = False
                FrmAdd.EDIT = 1
                FrmAdd.LId.Text = DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value
                TxtIdOstan = DGV.Item("Cln_IdOstan", DGV.CurrentRow.Index).Value
                TxtIdCity = DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value
                Tmp_OneGroup = DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value
                Tmp_TwoGroup = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value
                Array.Resize(AllSelectKala, 0)
                For i As Integer = 0 To DGV2.RowCount - 1
                    Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                    AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV2.Item("Cln_NamKala", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).OneGroup = ""
                    AllSelectKala(AllSelectKala.Length - 1).TwoGroup = ""
                    AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV2.Item("Cln_IdKala", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).Id = DGV2.Item("Cln_Id", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).CostSkala = DGV2.Item("Cln_SCost", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).CostBkala = DGV2.Item("Cln_Bcost", i).Value
                    AllSelectKala(AllSelectKala.Length - 1).EndCost = DGV2.Item("Cln_EndCost", i).Value
                Next
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
            If ROW <= DGV.RowCount - 1 Then DGV.Item(0, ROW).Selected = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "cmdedit_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("شهرستانی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد شهرستان جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Me.DeleteCity(CLng(DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value))

                Me.RefreshBank()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "cmddel_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DeleteCity(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM Define_CostKala WHERE IDCity=@Id;DELETE FROM Define_CityCostKala WHERE IDCity=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت در شهرستان", "حذف شهرستان", "حذف قیمتهای شهرستان :" & DGV.Item("Cln_City", DGV.CurrentRow.Index).Value, "")
            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("شهرستان انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "DeleteCity")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function
    Private Function RefreshCity() As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM define_cityCostkala WHERE IdCity IN(SELECT distinct Define_CityCostkala.IdCity FROM Define_CityCostkala INNER JOIN Define_CostKala ON Define_CityCostkala.IdCity <> Define_CostKala.IdCity)", ConectionBank)
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "RefreshCity")
            End If
            Return False
        End Try
    End Function
    Private Function DeleteKala(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM Define_CostKala WHERE ID=@Id", ConectionBank)
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "DeleteKala")
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "DeleteEndCity")
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
                MessageBox.Show("کالایی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد کالای جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Dim kalanam As String = DGV2.Item("Cln_Namkala", DGV2.CurrentRow.Index).Value
                Dim CityNam As String = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value

                Dim IdC As Long = CLng(DGV2.Item("Cln_IdCity2", DGV2.CurrentRow.Index).Value)
                If Me.DeleteKala(CLng(DGV2.Item("Cln_Id", DGV2.CurrentRow.Index).Value)) Then Me.DeleteEndCity(IdC)
                Me.RefreshBank()

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه کالا و قیمت در شهرستان", "حذف قیمت", "حذف قیمت کالای :" & kalanam & " در شهرستان :" & Citynam, "")
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "BtnDelKala_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Kalaoghimat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnDelKala.Enabled = True Then Call BtnDelKala_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnEditCost.Enabled = True Then Call BtnEditCost_Click(Nothing, Nothing)
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

    Private Sub BtnEditCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCost.Click
        Try
            Using FrmEdit As New FrmEditCost
                FrmEdit.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "BtnEditCost_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnEditCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnEditCost.KeyDown
        Me.GetKey(e)
    End Sub
End Class