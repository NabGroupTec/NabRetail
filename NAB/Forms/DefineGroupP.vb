Imports System.Data.SqlClient
Public Class DefineGroupP
    Dim edt As Integer
    Dim str_name, str_fam, str_state As String
    Dim ds As New DataSet
    Dim str As String = "select * from Define_Group_P"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource
    Private Sub Define_Group_P_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cmdadd.Focus()
    End Sub

    Private Sub Define_Group_P_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub Bank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F7")
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
        Me.fill_dgv()
        DGV.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
        ''''''''''''''''''''''''''
    End Sub
    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F7")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmddel.Enabled = False
                    cmdedit.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmddel.Enabled = False
                        cmdedit.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            cmdadd.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            cmddel.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            cmdedit.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                cmdadd.Enabled = False
                cmddel.Enabled = False
                cmdedit.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub fill_dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_Group_P")
            '''''''''''''''''''''''''''
            Dim prvkey(1) As DataColumn
            prvkey(0) = ds.Tables("Define_Group_P").Columns("ID")
            ds.Tables("Define_Group_P").PrimaryKey = prvkey
            '''''''''''''''''''''''''''
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "Define_Group_P"
            DGV.DataSource = bs
            TxtCash1.DataBindings.Add("text", bs, ".Cash1", True, DataSourceUpdateMode.OnValidation)
            TxtCash2.DataBindings.Add("text", bs, ".Cash2", True, DataSourceUpdateMode.OnValidation)
            TxtCash3.DataBindings.Add("text", bs, ".Cash3", True, DataSourceUpdateMode.OnValidation)
            TxtCash4.DataBindings.Add("text", bs, ".Cash4", True, DataSourceUpdateMode.OnValidation)
            TxtCash5.DataBindings.Add("text", bs, ".Cash5", True, DataSourceUpdateMode.OnValidation)
            TxtCash6.DataBindings.Add("text", bs, ".Cash6", True, DataSourceUpdateMode.OnValidation)
            TxtCashP1.DataBindings.Add("text", bs, ".CashP1", True, DataSourceUpdateMode.OnValidation)
            TxtCashP2.DataBindings.Add("text", bs, ".CashP2", True, DataSourceUpdateMode.OnValidation)
            TxtCashP3.DataBindings.Add("text", bs, ".CashP3", True, DataSourceUpdateMode.OnValidation)
            TxtCashP4.DataBindings.Add("text", bs, ".CashP4", True, DataSourceUpdateMode.OnValidation)
            TxtCashP5.DataBindings.Add("text", bs, ".CashP5", True, DataSourceUpdateMode.OnValidation)
            TxtCashP6.DataBindings.Add("text", bs, ".CashP6", True, DataSourceUpdateMode.OnValidation)
            TxtDCash1.DataBindings.Add("text", bs, ".DCash1", True, DataSourceUpdateMode.OnValidation)
            TxtDCash2.DataBindings.Add("text", bs, ".DCash2", True, DataSourceUpdateMode.OnValidation)
            TxtDCash3.DataBindings.Add("text", bs, ".DCash3", True, DataSourceUpdateMode.OnValidation)
            TxtDP1.DataBindings.Add("text", bs, ".DP1", True, DataSourceUpdateMode.OnValidation)
            TxtDP2.DataBindings.Add("text", bs, ".DP2", True, DataSourceUpdateMode.OnValidation)
            TxtDP3.DataBindings.Add("text", bs, ".DP3", True, DataSourceUpdateMode.OnValidation)
            TxtChk1.DataBindings.Add("text", bs, ".Chk1", True, DataSourceUpdateMode.OnValidation)
            TxtChk2.DataBindings.Add("text", bs, ".Chk2", True, DataSourceUpdateMode.OnValidation)
            TxtChk3.DataBindings.Add("text", bs, ".Chk3", True, DataSourceUpdateMode.OnValidation)
            TxtChk4.DataBindings.Add("text", bs, ".Chk4", True, DataSourceUpdateMode.OnValidation)
            TxtChk5.DataBindings.Add("text", bs, ".Chk5", True, DataSourceUpdateMode.OnValidation)
            TxtChk6.DataBindings.Add("text", bs, ".Chk6", True, DataSourceUpdateMode.OnValidation)
            TxtDChk1.DataBindings.Add("text", bs, ".DChk1", True, DataSourceUpdateMode.OnValidation)
            TxtDChk2.DataBindings.Add("text", bs, ".DChk2", True, DataSourceUpdateMode.OnValidation)
            TxtDChk3.DataBindings.Add("text", bs, ".DChk3", True, DataSourceUpdateMode.OnValidation)
            ChKHajm.DataBindings.Add("CheckState", bs, ".Hajm", True, DataSourceUpdateMode.OnValidation)
            ChkCash.DataBindings.Add("CheckState", bs, ".KalaCash", True, DataSourceUpdateMode.OnValidation)
            ChkKala.DataBindings.Add("CheckState", bs, ".HKalaCash", True, DataSourceUpdateMode.OnValidation)
            TxtCost.DataBindings.Add("text", bs, ".KindCost", True, DataSourceUpdateMode.OnValidation)
            ChkValue.DataBindings.Add("CheckState", bs, ".GroupValue", True, DataSourceUpdateMode.OnValidation)
            ChkPeople.DataBindings.Add("CheckState", bs, ".GroupPeople", True, DataSourceUpdateMode.OnValidation)
            TxtMon.DataBindings.Add("text", bs, ".GroupValueMon", True, DataSourceUpdateMode.OnValidation)
            TxtDCard.DataBindings.Add("text", bs, ".DCard", True, DataSourceUpdateMode.OnValidation)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "fill_dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ گروهی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmddel.Enabled = False
            cmdedit.Enabled = False
            Me.RefreshBank()
            Exit Sub
        End If
        Dim str As String = MessageBox.Show("ايا مي خواهيد گروه جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If str = 6 Then
            Try
                Me.DeleteGroup(CLng(DGV.Item("Column4", DGV.CurrentRow.Index).Value))
                Me.RefreshBank()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MessageBox.Show("گروه انتخابی شما قابل حذف نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "cmddel_Click")
                End If
                Me.RefreshBank()
            End Try
        End If
    End Sub
    Private Function DeleteGroup(ByVal Id As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()

            Using Cmd As New SqlCommand("DELETE FROM Define_Group_P WHERE ID=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف گروه های ویژه", "حذف", "حذف گروه ویژه : " & DGV.Item("Cln_Name", DGV.CurrentRow.Index).Value, "")

            Return True

        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("گروه انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineCostKala", "DeleteCity")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If bs.Count <= 0 Then
            MessageBox.Show("هيچ گروهی براي ويرايش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Using Frm As New FrmAdd_GroupP
            Frm.LEdit.Text = DGV.Item("Column4", DGV.CurrentRow.Index).Value
            Frm.str_name = DGV.Item("cln_name", DGV.CurrentRow.Index).Value
            Frm.ShowDialog()
            Me.RefreshBank()
        End Using
    End Sub

    Private Sub DGV_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_KDgv(CLng(DGV.Item("Column4", e.RowIndex).Value))
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

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GroupVije.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub
    Private Sub RefreshBank()
        Try
            ds.Clear()
            dta.Fill(ds, "Define_Group_P")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "RefreshBank")
            Me.Close()
        End Try
    End Sub


    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        Me.RefreshBank()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        Me.RefreshBank()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Using Frm As New FrmAdd_GroupP
            Frm.LEdit.Text = "0"
            Frm.ShowDialog()
            Me.RefreshBank()
        End Using
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub Fill_KDgv(ByVal Id As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT AzMon,TaMon,Darsad FROM Define_List_Group_P WHERE Linkid=" & Id
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "Define_List_Group_P")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "Define_List_Group_P"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "DefineGroupP", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub TxtCash2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash2.TextChanged
        If Not (CheckDigit(Format$(TxtCash2.Text.Replace(",", "")))) Then
            TxtCash2.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash2.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash2.Text.Replace(",", ""))
            TxtCash2.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash2.Text = CDbl(TxtCash2.Text)
        End If
    End Sub

    Private Sub TxtCash1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash1.TextChanged
        If Not (CheckDigit(Format$(TxtCash1.Text.Replace(",", "")))) Then
            TxtCash1.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash1.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash1.Text.Replace(",", ""))
            TxtCash1.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash1.Text = CDbl(TxtCash1.Text)
        End If
    End Sub

    Private Sub TxtCash3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash3.TextChanged
        If Not (CheckDigit(Format$(TxtCash3.Text.Replace(",", "")))) Then
            TxtCash3.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash3.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash3.Text.Replace(",", ""))
            TxtCash3.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash3.Text = CDbl(TxtCash3.Text)
        End If
    End Sub

    Private Sub TxtCash4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash4.TextChanged
        If Not (CheckDigit(Format$(TxtCash4.Text.Replace(",", "")))) Then
            TxtCash4.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash4.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash4.Text.Replace(",", ""))
            TxtCash4.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash4.Text = CDbl(TxtCash4.Text)
        End If
    End Sub

    Private Sub TxtCash5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash5.TextChanged
        If Not (CheckDigit(Format$(TxtCash5.Text.Replace(",", "")))) Then
            TxtCash5.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash5.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash5.Text.Replace(",", ""))
            TxtCash5.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash5.Text = CDbl(TxtCash5.Text)
        End If
    End Sub

    Private Sub TxtCash6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash6.TextChanged
        If Not (CheckDigit(Format$(TxtCash6.Text.Replace(",", "")))) Then
            TxtCash6.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCash6.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash6.Text.Replace(",", ""))
            TxtCash6.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash6.Text = CDbl(TxtCash6.Text)
        End If
    End Sub

    Private Sub TxtCashP1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP1.TextChanged
        If Not (CheckDigit(Format$(TxtCashP1.Text.Replace(",", "")))) Then
            TxtCashP1.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP1.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP1.Text.Replace(",", ""))
            TxtCashP1.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP1.Text = CDbl(TxtCashP1.Text)
        End If
    End Sub

    Private Sub TxtCashP2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP2.TextChanged
        If Not (CheckDigit(Format$(TxtCashP2.Text.Replace(",", "")))) Then
            TxtCashP2.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP2.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP2.Text.Replace(",", ""))
            TxtCashP2.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP2.Text = CDbl(TxtCashP2.Text)
        End If
    End Sub

    Private Sub TxtCashP3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP3.TextChanged
        If Not (CheckDigit(Format$(TxtCashP3.Text.Replace(",", "")))) Then
            TxtCashP3.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP3.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP3.Text.Replace(",", ""))
            TxtCashP3.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP3.Text = CDbl(TxtCashP3.Text)
        End If
    End Sub

    Private Sub TxtCashP4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP4.TextChanged
        If Not (CheckDigit(Format$(TxtCashP4.Text.Replace(",", "")))) Then
            TxtCashP4.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP4.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP4.Text.Replace(",", ""))
            TxtCashP4.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP4.Text = CDbl(TxtCashP4.Text)
        End If
    End Sub

    Private Sub TxtCashP5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP5.TextChanged
        If Not (CheckDigit(Format$(TxtCashP5.Text.Replace(",", "")))) Then
            TxtCashP5.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP5.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP5.Text.Replace(",", ""))
            TxtCashP5.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP5.Text = CDbl(TxtCashP5.Text)
        End If
    End Sub

    Private Sub TxtCashP6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCashP6.TextChanged
        If Not (CheckDigit(Format$(TxtCashP6.Text.Replace(",", "")))) Then
            TxtCashP6.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtCashP6.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCashP6.Text.Replace(",", ""))
            TxtCashP6.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCashP6.Text = CDbl(TxtCashP6.Text)
        End If
    End Sub

    Private Sub TxtCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCost.TextChanged
        If TxtCost.Text = "0" Then
            TxtCost2.Text = "خرده"
        ElseIf TxtCost.Text = "1" Then
            TxtCost2.Text = "عمده"
        ElseIf TxtCost.Text = "2" Then
            TxtCost2.Text = "مصرف کننده"
        End If
    End Sub

    Private Sub TxtMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon.TextChanged
        If Not (CheckDigit(Format$(TxtMon.Text.Replace(",", "")))) Then
            TxtMon.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtMon.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtMon.Text.Replace(",", ""))
            TxtMon.Text = Format$(Val(str), "###,###,###")
        Else
            TxtMon.Text = CDbl(TxtMon.Text)
        End If
    End Sub
End Class