Imports System.Data.SqlClient

Public Class FrmTraceUser

    Dim ds As New DataSet
    Dim str As String = "SELECT TraceUser.*, Define_User.Nam FROM TraceUser INNER JOIN Define_User ON TraceUser.IdUser = Define_User.Id"
    Dim dta As New SqlDataAdapter(str, DataSource)
    Dim dv As DataView

    Private Sub FrmTraceUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Radyabikarbar.htm")
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub FrmTraceUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        fill_dgv()
        DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub GetForm()
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey


            Dim dsF As New DataSet
            Dim strF As String = "SELECT DISTINCT Form  FROM TraceUser"
            Dim dtaF As New SqlDataAdapter(strF, DataSource)

            dsF.Clear()
            If Not dtaF Is Nothing Then
                dtaF.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaF = New SqlDataAdapter(strF, DataSource)
            dtaF.Fill(dsF, "TraceUser")

            If Not dsF.Tables("TraceUser").Columns.Contains("E_Form") Then dsF.Tables("TraceUser").Columns.Add("E_Form", Type.GetType("System.String"))

            For i As Integer = 0 To dsF.Tables("TraceUser").Rows.Count - 1
                dsF.Tables("TraceUser").Rows(i).Item("E_Form") = Sec.StringDecrypt(dsF.Tables("TraceUser").Rows(i).Item("Form"), key.CreateDecryptor)
            Next

            '''''''''''''''''''''''''''
            ComboBox1.DataSource = dsF.Tables("TraceUser")
            ComboBox1.DisplayMember = "E_Form"
            ComboBox1.ValueMember = "E_Form"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmTraceUser", "GetForm")
            Me.Close()
        End Try
    End Sub

    Private Sub fill_dgv()
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "TraceUser")

            If Not ds.Tables("TraceUser").Columns.Contains("ED_date") Then ds.Tables("TraceUser").Columns.Add("ED_date", Type.GetType("System.String"))
            If Not ds.Tables("TraceUser").Columns.Contains("ET_time") Then ds.Tables("TraceUser").Columns.Add("ET_time", Type.GetType("System.String"))
            If Not ds.Tables("TraceUser").Columns.Contains("E_Action") Then ds.Tables("TraceUser").Columns.Add("E_Action", Type.GetType("System.String"))
            If Not ds.Tables("TraceUser").Columns.Contains("E_Form") Then ds.Tables("TraceUser").Columns.Add("E_Form", Type.GetType("System.String"))
            If Not ds.Tables("TraceUser").Columns.Contains("E_Disc") Then ds.Tables("TraceUser").Columns.Add("E_Disc", Type.GetType("System.String"))
            If Not ds.Tables("TraceUser").Columns.Contains("E_SystemDisc") Then ds.Tables("TraceUser").Columns.Add("E_SystemDisc", Type.GetType("System.String"))

            For i As Integer = 0 To ds.Tables("TraceUser").Rows.Count - 1
                ds.Tables("TraceUser").Rows(i).Item("ED_date") = Sec.StringDecrypt(ds.Tables("TraceUser").Rows(i).Item("D_date"), key.CreateDecryptor)
                ds.Tables("TraceUser").Rows(i).Item("ET_time") = Sec.StringDecrypt(ds.Tables("TraceUser").Rows(i).Item("T_time"), key.CreateDecryptor)
                ds.Tables("TraceUser").Rows(i).Item("E_Action") = Sec.StringDecrypt(ds.Tables("TraceUser").Rows(i).Item("Action"), key.CreateDecryptor)
                ds.Tables("TraceUser").Rows(i).Item("E_Form") = Sec.StringDecrypt(ds.Tables("TraceUser").Rows(i).Item("Form"), key.CreateDecryptor)
                ds.Tables("TraceUser").Rows(i).Item("E_Disc") = If(ds.Tables("TraceUser").Rows(i).Item("Disc") Is DBNull.Value, "", Sec.StringDecrypt(ds.Tables("TraceUser").Rows(i).Item("Disc"), key.CreateDecryptor))
                ds.Tables("TraceUser").Rows(i).Item("E_SystemDisc") = If(ds.Tables("TraceUser").Rows(i).Item("SystemDisc") Is DBNull.Value, "", Sec.StringDecrypt(ds.Tables("TraceUser").Rows(i).Item("SystemDisc"), key.CreateDecryptor))
            Next

            '''''''''''''''''''''''''''

            DGV.AutoGenerateColumns = False
            dv = ds.Tables("TraceUser").DefaultView
            dv.Sort = "ED_Date,ET_Time"
            DGV.DataSource = dv

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmTraceUser", "fill_dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New User_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
        End If
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
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
            Filter()
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = ""
            Filter()
        End If
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
            Filter()
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = ""
            Filter()
        End If
    End Sub

    Private Sub ChkForm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkForm.CheckedChanged
        If ChkForm.Checked = True Then
            ComboBox1.Enabled = True
            GetForm()
        Else
            ComboBox1.Enabled = False
            ComboBox1.DataSource = Nothing
        End If
    End Sub

    Private Sub Filter()
        Try
            If ChkUser.Checked = False And ChkTime.Checked = False And ChkForm.Checked = False Then
                dv.RowFilter = ""
            Else
                Dim User As String = If(ChkUser.Checked = True, "(IDUser=" & If(String.IsNullOrEmpty(TxtIdUser.Text), 0, CLng(TxtIdUser.Text)) & ")", "")
                Dim Form As String = If(ChkForm.Checked = True, "(E_Form='" & ComboBox1.Text & "')", "")
                Dim Dat As String = ""
                If (ChkTime.Checked = True And (ChkAzDate.Checked = True Or ChkTaDate.Checked = True)) Then
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        Dat = "(ED_date>='" & FarsiDate1.ThisText & "' AND ED_date<='" & FarsiDate2.ThisText & "')"
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        Dat = "(ED_date>='" & FarsiDate1.ThisText & "')"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        Dat = "(ED_date<='" & FarsiDate2.ThisText & "')"
                    Else
                        Dat = ""
                    End If
                End If
                dv.RowFilter = User & If(String.IsNullOrEmpty(User), Dat, If(String.IsNullOrEmpty(Dat), "", " AND " & Dat)) & If(String.IsNullOrEmpty(User) And String.IsNullOrEmpty(Dat), Form, If(String.IsNullOrEmpty(Form), "", " AND " & Form))
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub TxtIdUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdUser.TextChanged
        Filter()
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        Filter()
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        Filter()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Filter()
    End Sub

    Private Sub ChkUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkUser.CheckedChanged
        If ChkUser.Checked = True Then
            TxtUser.Text = ""
            TxtIdUser.Text = ""
            TxtUser.Enabled = True
            TxtUser.Focus()
        Else
            TxtUser.Text = ""
            TxtIdUser.Text = ""
            TxtUser.Enabled = False
        End If
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
End Class