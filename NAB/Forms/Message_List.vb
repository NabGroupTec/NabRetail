Imports System.Data.SqlClient
Public Class Message_List
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
    Private Sub GetMessageList()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dta = New SqlDataAdapter("SELECT  Id,Sender_IdUser,Sender_IdVisitor,Sender_UNam=(CASE WHEN (Sender_IdUser IS NOT NULL) THEN (SELECT Define_User.Nam FROM Define_User WHERE Define_User.id=Sender_IdUser ) ELSE N'' END),Sender_VNam=(CASE WHEN (Sender_IdVisitor IS NOT NULL) THEN (SELECT Define_Visitor.Nam FROM Define_Visitor WHERE Define_Visitor.id=Sender_IdVisitor) ELSE N'' END),[Subject] FROM MessageCenter WHERE RChk ='True' AND Reciver_IdUser=" & Id_User, DataSource)
            Dta.Fill(Ds, "MessageCenter")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("MessageCenter").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Message_List", "GetMessageList")
            Me.Close()
        End Try
    End Sub

    Private Sub RefreshBank()
        Try
            Ds.Clear()
            Dta.Fill(Ds, "MessageCenter")
            TxtSearch.Text = ""
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Message_List", "RefreshBank")
        End Try
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Down And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = DGV.Rows.Count - 1 Then
                DGV.Item(0, 0).Selected = True
                e.Handled = True
            Else
                DGV.Item(0, DGV.CurrentRow.Index + 1).Selected = True
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Up And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = 0 Then
                DGV.Item(0, DGV.Rows.Count - 1).Selected = True
                e.Handled = True
            Else
                DGV.Item(0, DGV.CurrentRow.Index - 1).Selected = True
                e.Handled = True
            End If
        End If
        Me.GetKey(e)
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                dv.RowFilter = ""
            Else
                dv.RowFilter = "Id =" & TxtSearch.Text.Trim
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
        If DGV.RowCount > 1 And TxtSearch.Text <> "" Then
            Dim txtdgv, txtk As String
            For i As Integer = 0 To DGV.RowCount - 1
                txtdgv = DGV.Item(0, i).Value.ToString
                txtk = TxtSearch.Text
                If txtdgv.Contains(TxtSearch.Text.Trim) And txtdgv(0).ToString = txtk(0).ToString Then
                    DGV.Item(0, i).Selected = True
                    Exit Sub
                End If
            Next
            DGV.Item(0, 0).Selected = True
            DGV.Item(0, 0).Selected = False
        End If
    End Sub

    Private Sub Kala_List_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtSearch.Focus()
        SendKeys.Send("{End}")
        Dim ss As String = TxtSearch.Text.Trim
        TxtSearch.Text = ""
        TxtSearch.Text = ss
    End Sub

    Private Sub Kala_List_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Kala_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetMessageList()
        IdKala = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            IdKala = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.Enter Then
            Try
                If DGV.RowCount > 0 Then
                    IdKala = CLng(DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value.ToString)
                    If Not DGV.Item("Sender_IdUser", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                        Tmp_Namkala = "U"
                        Tmp_OneGroup = DGV.Item("Sender_IdUser", DGV.CurrentRow.Index).Value
                        Tmp_TwoGroup = DGV.Item("Sender_UNam", DGV.CurrentRow.Index).Value
                    Else
                        Tmp_Namkala = "V"
                        Tmp_OneGroup = DGV.Item("Sender_IdVisitor", DGV.CurrentRow.Index).Value
                        Tmp_TwoGroup = DGV.Item("Sender_VNam", DGV.CurrentRow.Index).Value
                    End If
                    Me.Close()
                End If
            Catch ex As Exception
                IdKala = 0
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                Me.Close()
            End Try
        End If
        If e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnExit.Enabled = True Then Call BtnExit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BtnExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnExit.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub RdoAval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If DGV.RowCount > 0 Then
                IdKala = CLng(DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value.ToString)
                If Not DGV.Item("Sender_IdUser", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                    Tmp_Namkala = "U"
                    Tmp_OneGroup = DGV.Item("Sender_IdUser", DGV.CurrentRow.Index).Value
                    Tmp_TwoGroup = DGV.Item("Sender_UNam", DGV.CurrentRow.Index).Value
                Else
                    Tmp_Namkala = "V"
                    Tmp_OneGroup = DGV.Item("Sender_IdVisitor", DGV.CurrentRow.Index).Value
                    Tmp_TwoGroup = DGV.Item("Sender_VNam", DGV.CurrentRow.Index).Value
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            Array.Resize(AllSelectKala, 0)
            Me.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        IdKala = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        Me.Close()
    End Sub

    Private Sub RdoAval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtSearch.Focus()
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtSearch.Focus()
    End Sub

    Private Sub ChkAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub BtnNewP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub
End Class