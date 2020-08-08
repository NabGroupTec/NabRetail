Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmExitFactor
    Dim ds As New DataSet
    Dim str As String = "SELECT id,D_date,(SELECT Nam FROM Define_Driver WHERE Id=ExitList.IdDriver) AS Driver,(SELECT Nam FROM Define_Reciver  WHERE Id=ExitList.IdRecive) AS Reciver,(SELECT Nam FROM Define_Car  WHERE Id=ExitList.IdCar ) AS Car FROM (SELECT ID,IdCar,IdDriver,IdRecive,D_date FROM ExitFactor) As ExitList"
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
            Fill_KDgv(CLng(DGV.Item("Cln_Code", e.RowIndex).Value))
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
            dta.Fill(ds, "ExitFactor")
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "ExitFactor"
            DGV.DataSource = bs
            BN.BindingSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_KDgv(ByVal IdCity As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT ListExitFactor.IdFactor,ListExitFactor.Priority, Define_People.Nam, Define_Ostan.NamO, Define_City.NamCI,Define_Part.NamP FROM ListExitFactor INNER JOIN ListFactorSell ON ListExitFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_part ON Define_People.IdPart = Define_Part.Code  WHERE IdList =" & IdCity & " ORDER BY ListExitFactor.Priority"
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "ListExitFactor")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "ListExitFactor"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "fill_Kdgv")
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
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Access_Form = Get_Access_Form("F121")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "ورود", "", "")
                End If
            End If
        Else
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "ورود", "", "")
        End If

        Me.Fill_Dgv()
        SetButton()
        DGV.Sort(DGV.Columns("Cln_Code"), System.ComponentModel.ListSortDirection.Descending)
        DGV.Columns("Column2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F121")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmddel.Enabled = False
                    cmdedit.Enabled = False
                    BtnDelFactor.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmddel.Enabled = False
                        cmdedit.Enabled = False
                        BtnDelFactor.Enabled = False
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
                            BtnDelFactor.Enabled = False
                        End If

                        If Access_Form.Substring(7, 1) = 0 Then
                            BtnP.Enabled = False
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
                BtnDelFactor.Enabled = False
                BtnP.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub RefreshBank()
        Try
            DGV2.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "ExitFactor")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            LimitMojody()
            Using FrmAdd As New AddEdit_ExitFactor
                If LimitDate = True Then FrmAdd.TxtDate.Enabled = False
                FrmAdd.EDIT = 0
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "cmdadd_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If DGV.RowCount <= 0 Or DGV2.RowCount <= 0 Then
            MessageBox.Show("خروجی برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If

        If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "EDIT") = False Then
            MessageBox.Show(" ویرایش به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Try
            LimitMojody()
            Using FrmAdd As New AddEdit_ExitFactor
                If LimitDate = True Then FrmAdd.TxtDate.Enabled = False
                FrmAdd.EDIT = 1
                FrmAdd.LSanad.Text = CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value)
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "cmdedit_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("خروجی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "DEL") = False Then
                MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim str As String = MessageBox.Show("ايا مي خواهيد خروجی جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Me.DeleteExitFactor(CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value))

                Me.RefreshBank()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "cmddel_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DeleteExitFactor(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM ExitFactor WHERE ID=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "حذف خروجی", "حذف خروجی شماره :" & Id, "")

            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("خروجی انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "DeleteExitFactor")
            End If
            Me.RefreshBank()
            Return False
        End Try
    End Function
   
    Private Function DeleteFactor(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM ListExitFactor WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "حذف فاکتور", "حذف فاکتور شماره :" & Id, "")

            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("فاکتور انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "DeleteFactor")
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
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KhrojFact.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then Call cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnDelFactor.Enabled = True Then Call BtnDelFactor_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnP.Enabled = True Then Call BtnP_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F8 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F9 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F10 Then
            If BtnAllPrint.Enabled = True Then Call BtnAllPrint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F12 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnDelFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelFactor.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("فاکتوری برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "DEL") = False Then
                MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DGV2.RowCount = 1 Then
                MessageBox.Show("جهت حذف آخرین فاکتور از حذف خروجی استفاده کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد فاکتور جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                Me.DeleteFactor(CLng(DGV2.Item("Cln_IdFactor", DGV2.CurrentRow.Index).Value))
                Me.RefreshBank()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "cmddel_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnP.Click
        If DGV.RowCount <= 0 Or DGV2.RowCount <= 0 Then
            MessageBox.Show("خروجی برای تغییر ترتیب وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Try

            Using FrmAdd As New FrmPerority
                FrmAdd.LSanad.Text = CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value)
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "BtnP_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV.RowCount <= 0 Or DGV2.RowCount <= 0 Then
            MessageBox.Show("خروجی برای کنترل فاکتور وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Try
            Using FrmAdd As New FrmControMali
                FrmAdd.ChkExit.Checked = True
                FrmAdd.TxtExit.Text = CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value)
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "Button1_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DGV.RowCount <= 0 Or DGV2.RowCount <= 0 Then
            MessageBox.Show("خروجی برای جمع کالای فاکتور وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Exit Sub
        End If
        Try
            Using FrmAdd As New FrmSumKalaFactor
                FrmAdd.ChkExit.Checked = True
                FrmAdd.TxtExit.Text = CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value)
                FrmAdd.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "Button2_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnAllPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllPrint.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("خروجی برای چاپ متوالی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "چاپ متوالی", "چاپ متوالی خروجی شماره :" & CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value), "")

            Using frm As New ManageFactor
                frm.RdoExitFactor.Checked = True
                frm.TxtExit.Text = CLng(DGV.Item("Cln_Code", DGV.CurrentRow.Index).Value)

                frm.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "BtnAllPrint_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "ریز فاکتور", "نمایش ریز فاکتور :" & DGV2.Item("Cln_IdFactor", DGV2.CurrentRow.Index).Value, "")

            Using frmshow As New ShowFactor
                frmshow.LFactor.Text = DGV2.Item("Cln_IdFactor", DGV2.CurrentRow.Index).Value
                frmshow.LState.Text = 3
                frmshow.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmExitFactor", "Button3_Click")
        End Try
    End Sub

    Private Sub TxtId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtId.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtId.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub RdoFac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoFac.CheckedChanged
        If RdoFac.Checked = True Then
            LFac.Visible = True
            LExit.Visible = False
            TxtId.Clear()
            TxtId.Focus()
        End If
    End Sub

    Private Sub RdoExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoExit.CheckedChanged
        If RdoExit.Checked = True Then
            LFac.Visible = False
            LExit.Visible = True
            TxtId.Clear()
            TxtId.Focus()
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If String.IsNullOrEmpty(TxtId.Text) Then
            MessageBox.Show("شماره " & IIf(RdoExit.Checked = True, " خروجی ", " فاکتور ") & "را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtId.Focus()
            Exit Sub
        End If

        If RdoExit.Checked = True Then
            For i As Integer = 0 To DGV.RowCount - 1
                If CLng(DGV.Item("Cln_Code", i).Value) = CLng(TxtId.Text.Trim) Then
                    DGV.Item("Cln_Code", i).Selected = True
                    DGV.Rows(i).Selected = True
                    Exit Sub
                End If
            Next
            MessageBox.Show("خروجی مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If RdoFac.Checked = True Then
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Dim dtr As SqlDataReader = Nothing
            Using cmd As New SqlCommand("SELECT  ListExitFactor.IdFactor, ListExitFactor.IdList FROM ListExitFactor WHERE IdFactor =" & CLng(TxtId.Text), ConectionBank)
                dtr = cmd.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                For i As Integer = 0 To DGV.RowCount - 1
                    If CLng(DGV.Item("Cln_Code", i).Value) = dtr("IdList") Then
                        DGV.Item("Cln_Code", i).Selected = True
                        DGV.Rows(i).Selected = True
                        For j As Integer = 0 To DGV2.RowCount - 1
                            If CLng(DGV2.Item("Cln_IdFactor", j).Value) = dtr("IdFactor") Then
                                DGV2.Item("Cln_IdFactor", j).Selected = True
                                DGV2.Rows(j).Selected = True
                                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                                Exit Sub
                            End If
                        Next
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        Exit Sub
                    End If
                Next
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                MessageBox.Show("شماره فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub TxtId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtId.TextChanged

    End Sub
End Class