Imports System.Data.SqlClient
Imports System.Transactions

Public Class FrmPerority

    Structure TmpRow
        Dim IdFactor As Long
        Dim P As Long
        Dim Nam As String
    End Structure
    Public AllRow() As TmpRow

    Private Sub FrmPerority_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmPerority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        ShowInfoPerority()
        If DGV.Rows.Count <= 0 Then Me.Close()
        DGV.Rows(0).Selected = True
    End Sub

    Private Sub ShowInfoPerority()
        Try
            DGV.Rows.Clear()
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using SQLComanad As New SqlCommand("SELECT ListExitFactor.IdFactor,ListExitFactor.Priority,Define_People.Nam FROM ListExitFactor INNER JOIN ListFactorSell ON ListExitFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE IdList =" & CLng(LSanad.Text) & " ORDER BY ListExitFactor.Priority", ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    While dtrInfo.Read
                        DGV.Rows.Add()
                        DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value = dtrInfo("IdFactor")
                        DGV.Item("Cln_People", DGV.RowCount - 1).Value = dtrInfo("Nam")
                        DGV.Item("Cln_P", DGV.RowCount - 1).Value = dtrInfo("Priority")
                    End While
                End If
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPerority", "ShowInfoPerority")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        Try
            DGV.Rows(e.RowIndex).Selected = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DGV_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEnter
        Try
            DGV.Rows(e.RowIndex).Selected = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUp.Click
        Try
            If DGV.CurrentRow.Index <= 0 Then Exit Sub
            Me.Enabled = False
            Array.Resize(AllRow, 0)

            Array.Resize(AllRow, AllRow.Length + 1)
            AllRow(AllRow.Length - 1).IdFactor = DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value
            AllRow(AllRow.Length - 1).Nam = DGV.Item("Cln_People", DGV.CurrentRow.Index).Value
            AllRow(AllRow.Length - 1).P = DGV.Item("Cln_P", DGV.CurrentRow.Index).Value

            Array.Resize(AllRow, AllRow.Length + 1)
            AllRow(AllRow.Length - 1).IdFactor = DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index - 1).Value
            AllRow(AllRow.Length - 1).Nam = DGV.Item("Cln_People", DGV.CurrentRow.Index - 1).Value
            AllRow(AllRow.Length - 1).P = DGV.Item("Cln_P", DGV.CurrentRow.Index - 1).Value

            DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index - 1).Value = AllRow(AllRow.Length - 2).IdFactor
            DGV.Item("Cln_People", DGV.CurrentRow.Index - 1).Value = AllRow(AllRow.Length - 2).Nam
            DGV.Item("Cln_P", DGV.CurrentRow.Index - 1).Value = AllRow(AllRow.Length - 2).P

            DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = AllRow(AllRow.Length - 1).IdFactor
            DGV.Item("Cln_People", DGV.CurrentRow.Index).Value = AllRow(AllRow.Length - 1).Nam
            DGV.Item("Cln_P", DGV.CurrentRow.Index).Value = AllRow(AllRow.Length - 1).P

            DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index - 1).Selected = True
            DGV.Rows(DGV.CurrentRow.Index).Selected = True

            Me.Enabled = True

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPerority", "BtnUp_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDown.Click
        Try
            If DGV.CurrentRow.Index >= DGV.Rows.Count - 1 Then Exit Sub
            Me.Enabled = False
            Array.Resize(AllRow, 0)

            Array.Resize(AllRow, AllRow.Length + 1)
            AllRow(AllRow.Length - 1).IdFactor = DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value
            AllRow(AllRow.Length - 1).Nam = DGV.Item("Cln_People", DGV.CurrentRow.Index).Value
            AllRow(AllRow.Length - 1).P = DGV.Item("Cln_P", DGV.CurrentRow.Index).Value

            Array.Resize(AllRow, AllRow.Length + 1)
            AllRow(AllRow.Length - 1).IdFactor = DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index + 1).Value
            AllRow(AllRow.Length - 1).Nam = DGV.Item("Cln_People", DGV.CurrentRow.Index + 1).Value
            AllRow(AllRow.Length - 1).P = DGV.Item("Cln_P", DGV.CurrentRow.Index + 1).Value



            DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index + 1).Value = AllRow(AllRow.Length - 2).IdFactor
            DGV.Item("Cln_People", DGV.CurrentRow.Index + 1).Value = AllRow(AllRow.Length - 2).Nam
            DGV.Item("Cln_P", DGV.CurrentRow.Index + 1).Value = AllRow(AllRow.Length - 2).P


            DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = AllRow(AllRow.Length - 1).IdFactor
            DGV.Item("Cln_People", DGV.CurrentRow.Index).Value = AllRow(AllRow.Length - 1).Nam
            DGV.Item("Cln_P", DGV.CurrentRow.Index).Value = AllRow(AllRow.Length - 1).P

            DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index + 1).Selected = True
            DGV.Rows(DGV.CurrentRow.Index).Selected = True

            Me.Enabled = True

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPerority", "BtnDown_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        Me.Enabled = False
        If EditList() Then Me.Close()
        Me.Enabled = True
    End Sub

    Private Function EditList() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("DELETE FROM ListExitFactor WHERE IdList=@IdList", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdList", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO ListExitFactor(IdList,IdFactor,Priority) VALUES(@IdList,@IdFactor,@Priority)", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 1
                    Cmd.Parameters.AddWithValue("@IdList", SqlDbType.BigInt).Value = CLng(LSanad.Text)
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(DGV.Item("Cln_IdFactor", i).Value)
                    Cmd.Parameters.AddWithValue("@Priority", SqlDbType.BigInt).Value = i + 1
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using


            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروجی فاکتور", "تغییر ترتیب", "تغییر ترتیب خروجی شماره :" & CLng(LSanad.Text), "")
            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("تغییر ترتیب قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPerority", "EditList")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "KhrojFact.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            ShowInfoPerority()
        End If
    End Sub

End Class