Imports System.Data.SqlClient
Public Class FrmRepairUser
    Public id As Long
    Private Sub fill_dgv()
        Try
            Dim ds As New DataSet

            Dim str As String = ""
            If id = 1 Then
                str = "select Id,Nam,UserLogIn from Define_User"
            Else
                str = "select Id,Nam,UserLogIn from Define_User WHERE Id=" & id
            End If
            Dim dta As New SqlDataAdapter(str, DataSource)
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_User")
            '''''''''''''''''''''''''''
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            '''''''''''''''''''''''''''
            ds.Tables("Define_User").Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds.Tables("Define_User").Rows.Count - 1
                ds.Tables("Define_User").Rows(i).Item("LogIn") = Sec.StringDecrypt(ds.Tables("Define_User").Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next
            ''''''''''''''''''''''''''''''''''

            DGV.AutoGenerateColumns = False
            DGV.DataSource = ds.Tables(0)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmRepairUser", "fill_dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmRepairUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmRepairUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        fill_dgv()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            BtnSave.Focus()
            DGV.EndEdit()
           
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("UPDATE Define_User SET UserLogIn=@UserLogIn WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To DGV.RowCount - 1
                    CMD.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt(If(DGV.Item("Cln_LogIn", i).Value Is DBNull.Value, "0", If(DGV.Item("Cln_LogIn", i).Value = False, "0", "1")), key.CreateEncryptor)
                    CMD.Parameters.AddWithValue("@Id", SqlDbType.Bit).Value = CLng(DGV.Item("Cln_Id", i).Value)
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            SqlConnection.ClearPool(ConectionBank)
            Me.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            SqlConnection.ClearPool(ConectionBank)
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmRepairUser", "BtnSave_Click")
        End Try
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
End Class