Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmAnbarToAnbar
    Dim dv As New DataView
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            LimitMojody()
            Using FrmAnbar As New FrmNewAnbarToAnbar
                If LimitDate = True Then FrmAnbar.TxtKalaDate.Enabled = False
                FrmAnbar.TxtKalaDate.ThisText = GetDate()
                FrmAnbar.ShowDialog()
            End Using
            Me.GetList()
            Me.SetFilter()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "cmdadd_Click")
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("کالایی برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GetList()
                Exit Sub
            End If

            
            If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "EDIT") = False Then
                MessageBox.Show(" ویرایش به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            LimitMojody()
            Using Frmedit As New FrmNewAnbarToAnbar
                If LimitDate = True Then Frmedit.TxtKalaDate.Enabled = False
                Frmedit.LSanad.Text = CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value)
                Frmedit.ShowDialog()
            End Using
            Me.GetList()
            Me.SetFilter()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "cmdedit_Click")
            Me.GetList()
        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("کالایی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GetList()
                Me.SetFilter()
                Exit Sub
            End If
            
            If LimitWork(DGV.Item("Cln_Date", DGV.CurrentRow.Index).Value, "DEL") = False Then
                MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim str As String = MessageBox.Show("ايا مي خواهيد کالای جاري حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then

                '////////////////////////////////////////////////
                LimitMojody()
                If Not AreYouNativeKalaAnbar(CLng(DGV.Item("Cln_code", DGV.CurrentRow.Index).Value), CDbl(DGV.Item("Cln_Kol", DGV.CurrentRow.Index).Value), CDbl(DGV.Item("Cln_Joz", DGV.CurrentRow.Index).Value), CLng(DGV.Item("Cln_CodeAnbar", DGV.CurrentRow.Index).Value)) Then
                    If MAnbar = True Then
                        If MessageBox.Show("کالای سطر شماره" & DGV.CurrentRow.Index + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                    Else
                        MessageBox.Show("کالای سطر شماره" & DGV.CurrentRow.Index + 1 & " کمتر از موجودی انبار است و قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                '////////////////////////////////////////////////
                Me.DeleteKala(CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value))
                Me.GetList()
                Me.SetFilter()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "cmddel_Click")
            Me.GetList()
        End Try
    End Sub

    Private Function DeleteKala(ByVal Id As Long) As Boolean
        Dim SqlTrans As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(SqlTrans)
            Using Cmd As New SqlCommand("DELETE FROM Tranlate_Anbar WHERE ID=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.ExecuteNonQuery()
            End Using

            SqlTrans.Commit()
            SqlTrans.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات انبار", "حذف", "حذف سند:" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value & " انبار مبدا:" & DGV.Item("Cln_OneAnbar", DGV.CurrentRow.Index).Value & " انبار مقصد:" & DGV.Item("Cln_TwoAnbar", DGV.CurrentRow.Index).Value & " نام کالا:" & DGV.Item("Cln_namkala", DGV.CurrentRow.Index).Value & " تعداد کل:" & DGV.Item("Cln_Kol", DGV.CurrentRow.Index).Value & " تعداد جزء:" & DGV.Item("Cln_Joz", DGV.CurrentRow.Index).Value, "")

            Return True

        Catch ex As Exception
            SqlTrans.Rollback()
            SqlTrans.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("کالای انتخابی شما قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "DeleteKala")
            End If
            Me.GetList()
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AnbarToAnbar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If cmddel.Enabled = True Then cmddel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetList()
            Me.SetFilter()
            SetButton()
        ElseIf e.KeyCode = Keys.F6 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetFilter()
        If RdoDay.Checked = True Then
            Try
                dv.RowFilter = "D_date='" & GetDate() & "'"
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        ElseIf RdoAll.Checked = True Then
            Try
                dv.RowFilter = ""
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        ElseIf RdoId.Checked = True Then
            TxtSanad.Enabled = True
            Try
                dv.RowFilter = "Id=" & TxtSanad.Text.Trim
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        ElseIf RdoTime.Checked = True Then
            Try
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                Else
                    dv.RowFilter = ""
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub

    Private Sub FrmAnbarToAnbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmAnbarToAnbar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        Access_Form = Get_Access_Form("F59")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات انبار", "ورود", "", "")
                End If
            End If
        Else
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات انبار", "ورود", "", "")
        End If

        Me.GetList()
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        RdoDay.Checked = True
        DGV.Columns("Cln_namkala").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F59")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    cmdadd.Enabled = False
                    cmddel.Enabled = False
                    cmdedit.Enabled = False
                    Button1.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        cmdadd.Enabled = False
                        cmddel.Enabled = False
                        cmdedit.Enabled = False
                        Button1.Enabled = False
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
                        If Access_Form.Substring(6, 1) = 0 Then
                            Button1.Enabled = False
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub
    Private Sub GetList()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Alldata.Id,Kol,Joz,Disc ,D_date,idkala,IdTwoAnbar,NamKala ,OneAnbar ,Define_Anbar .nam as TwoAnbar FROM (SELECT Tranlate_Anbar.IdKala,Tranlate_Anbar.Id, Tranlate_Anbar.Kol, Tranlate_Anbar.Joz, Tranlate_Anbar.Disc, Tranlate_Anbar.D_date, Define_OneGroup.NamOne +'-'+ Define_TwoGroup.NamTwo +'-'+ Define_Kala.Nam As NamKala,Define_Anbar .nam As OneAnbar,Tranlate_Anbar .IdTwoAnbar FROM  Tranlate_Anbar INNER JOIN Define_Kala ON Tranlate_Anbar.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Anbar On Define_Anbar .ID =Tranlate_Anbar .IdOneAnbar)As AllData INNER JOIN Define_Anbar ON Define_Anbar .ID =AllData .IdTwoAnbar", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "GetList")
            Me.Close()
        End Try
    End Sub

    Private Sub RdoDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDay.CheckedChanged
        If RdoDay.Checked = True Then
            Try
                dv.RowFilter = "D_date='" & GetDate() & "'"
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            Try
                dv.RowFilter = ""
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub

    Private Sub RdoId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoId.CheckedChanged
        If RdoId.Checked = True Then
            TxtSanad.Enabled = True
            TxtSanad.Focus()
            Try
                dv.RowFilter = "Id=" & TxtSanad.Text.Trim
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSanad.Enabled = False
        End If
    End Sub

    Private Sub TxtSanad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSanad.KeyPress
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

    Private Sub TxtSanad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSanad.TextChanged
        If RdoId.Checked = False Then Exit Sub
        Try
            If Not (CheckDigit(TxtSanad.Text)) Then
                TxtSanad.Text = "0"
                TxtSanad.SelectAll()
                Exit Sub
            End If
            TxtSanad.Text = CDbl(TxtSanad.Text)
            dv.RowFilter = "Id=" & TxtSanad.Text.Trim
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub RdoTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTime.CheckedChanged
        If RdoTime.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            Try
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
                Else
                    dv.RowFilter = ""
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub ChkAzDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkAzDate.Checked = True Then
            FarsiDate1.ThisText = GetDate()
            FarsiDate1.Enabled = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
        End If
        Try
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
            Else
                dv.RowFilter = ""
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
        End If
        Try
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
            Else
                dv.RowFilter = ""
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        Try
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
            Else
                dv.RowFilter = ""
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        Try
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "'"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dv.RowFilter = "D_date>='" & FarsiDate1.ThisText & "'"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dv.RowFilter = "D_date<='" & FarsiDate2.ThisText & "'"
            Else
                dv.RowFilter = ""
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("گزارشی جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Array.Resize(ListDelayPrintArray, 0)
            For i As Integer = 0 To DGV.RowCount - 1
                Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).IdFactor = DGV.Item("Cln_Id", i).Value
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).nam = DGV.Item("Cln_Date", i).Value
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell1 = DGV.Item("Cln_OneAnbar", i).Value.ToString
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell2 = DGV.Item("Cln_TwoAnbar", i).Value.ToString
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).D_Date = DGV.Item("Cln_namkala", i).Value
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).EndDate = DGV.Item("Cln_Kol", i).Value.ToString.Replace(".", "/")
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Disc = DGV.Item("Cln_Disc", i).Value.ToString
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = DGV.Item("Cln_Joz", i).Value.ToString.Replace(".", "/")
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Rate = 0
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Remain = 0
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).TimeRemain = 0
            Next
            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "انتقالات انبار", "چاپ لیست", "", "")

            FrmPrint.CHoose = "TRANSALTEANBAR"
            FrmPrint.ShowDialog()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmAnbarToAnbar", "Button1_Click")
            Me.Enabled = True
        End Try
    End Sub
End Class