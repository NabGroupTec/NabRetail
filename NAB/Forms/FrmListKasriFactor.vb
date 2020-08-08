Imports System.Data.SqlClient
Imports System.Transactions

Public Class FrmListKasriFactor
    Dim dv As DataView

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            Using NewFrm As New FrmKasriFactor
                NewFrm.LEdit.Text = "0"
                NewFrm.ShowDialog()
            End Using
            GetKasriList()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "BtnAdd_Click")
        End Try
    End Sub

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        Try
            DGV2.DataSource = Nothing
            If DGV1.RowCount <= 0 Then
                Exit Sub
            End If
            Dim dt_Tmp As New DataTable
            dt_Tmp.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  Define_Kala.Nam,Replace(KalaKasriFactor.KolCount,'.','/') As KolCount, Replace(KalaKasriFactor.JozCount,'.','/') As JozCount,KalaKasriFactor.Fe ,KalaKasriFactor.DarsadDiscount ,KalaKasriFactor.DarsadMon ,KalaKasriFactor.Mon , KalaKasriFactor.KalaDisc FROM  KalaKasriFactor INNER JOIN Define_Kala ON KalaKasriFactor.IdR = Define_Kala.Id WHERE IdFactor =" & CLng(DGV1.Item("Cln_IdFactor", e.RowIndex).Value), ConectionBank)
                dt_Tmp.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = dt_Tmp
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "DGV1_RowEnter")
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

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "DecFactor.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnAdd.Enabled = True Then BtnAdd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnEdit.Enabled = True Then BtnEdit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKasriList()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("کسری فاکتور برای ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GetKasriList()
                Exit Sub
            End If

            Using FrmEdit As New FrmKasriFactor
                FrmEdit.LEdit.Text = "1"
                FrmEdit.LFac.Text = DGV1.Item("Cln_IdFactor", DGV1.CurrentRow.Index).Value
                FrmEdit.ShowDialog()
            End Using

            Me.GetKasriList()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "BtnEdit_Click")
        End Try
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("کسری فاکتور برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GetKasriList()
                Exit Sub
            End If

            If MessageBox.Show("آیا برای حذف کسری فاکتور مورد نظر مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Me.DelKasriFactor(DGV1.Item("Cln_IdFactor", DGV1.CurrentRow.Index).Value)
            Me.GetKasriList()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "BtnDel_Click")
        End Try
    End Sub

    Public Function DelKasriFactor(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            ''''''''''''''''''''''حذف چک
            dta = New SqlDataAdapter("SELECT IDSanad FROM ListKasriFactor WHERE IdFactor=" & IdFac, ConectionBank)
            dta.Fill(ds)

            Using Cmd As New SqlCommand("DELETE FROM  ListKasriFactor  WHERE IDFactor=@IDFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IDFactor", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using

            If Not ds.Rows(0).Item("IDSanad") Is DBNull.Value Then
                Using Cmd As New SqlCommand("DELETE FROM  Moein_People WHERE ID=@ID", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanad")
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            dta.Dispose()
            ds.Dispose()

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "کسری فاکتور", "حذف", " حذف کسری فاکتور فروش : " & IdFac, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "DelKasriFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub FrmListKasriFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmListKasriFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F39")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If

                Try
                    If Access_Form.Substring(12, 1) = 0 Then
                        MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Me.Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End Try
                
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DGV1.Columns("cln_P").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_Kala").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        GetKasriList()
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        RdoAll.Checked = True
        SetButton()
    End Sub

    Private Sub SetButton()
        Try
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnAdd.Enabled = False
                    BtnDel.Enabled = False
                    BtnEdit.Enabled = False
                Else
                    Try
                        If Access_Form.Substring(13, 1) = 0 Then
                            BtnAdd.Enabled = False
                        End If
                        If Access_Form.Substring(14, 1) = 0 Then
                            BtnDel.Enabled = False
                        End If
                        If Access_Form.Substring(15, 1) = 0 Then
                            BtnEdit.Enabled = False
                        End If
                    Catch ex As Exception
                        BtnAdd.Enabled = False
                        BtnDel.Enabled = False
                        BtnEdit.Enabled = False
                    End Try
                    
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKasriList()
        Try
            Dim dt As New DataTable
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT ListKasriFactor.IdFactor, ListKasriFactor.D_date, Define_People.Nam FROM ListKasriFactor INNER JOIN ListFactorSell ON ListKasriFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID", ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV1.AutoGenerateColumns = False
            dv = Nothing
            dv = dt.DefaultView
            'RowCountbank = dv.Count
            DGV1.DataSource = dv
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListKasriFactor", "GetKasriList")
            Me.Close()
        End Try
    End Sub

    Private Sub RdoP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoP.CheckedChanged
        If RdoP.Checked = True Then
            TxtName.Enabled = True
            TxtName.Focus()
            Try
                If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                    dv.RowFilter = ""
                Else
                    dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
                End If

                If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
                
            Catch ex As Exception
                dv.RowFilter = ""
                If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
            End Try
        Else
            TxtName.Text = ""
            TxtName.Enabled = False
        End If
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
        End If
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        If RdoP.Checked = False Then Exit Sub
        Try

            If String.IsNullOrEmpty(TxtName.Text) Then
                dv.RowFilter = ""
            Else
                dv.RowFilter = "Nam='" & TxtName.Text.Trim & "'"
            End If
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
        Catch ex As Exception
            dv.RowFilter = ""
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
        End Try
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            Try
                dv.RowFilter = ""
                If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
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
                If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
            Catch ex As Exception
                dv.RowFilter = ""
                If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
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
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
            
        Catch ex As Exception
            dv.RowFilter = ""
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
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
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
        Catch ex As Exception
            dv.RowFilter = ""
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
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
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
        Catch ex As Exception
            dv.RowFilter = ""
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
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
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
        Catch ex As Exception
            dv.RowFilter = ""
            If DGV1.RowCount <= 0 Then DGV2.DataSource = Nothing
        End Try
    End Sub
End Class