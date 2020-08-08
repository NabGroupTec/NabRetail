Public Class CreateShortcutSPage
    Private Sub CreateShortcutSPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getallforms(Me)
    End Sub
    Public Sub getallforms(ByVal sender As Object)
        Try

            Dim RowValues As Object() = {"", ""}
            Dim i As Integer = 0
            Dim Forms As New List(Of Form)()
            Dim formType As Type = Type.GetType("System.Windows.Forms.Form")
            For Each t As Type In sender.GetType().Assembly.GetTypes()
                If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then
                    If t.Name = "SplashScreen1" Or t.Name = "LoginForm" Or t.Name = "FrmMain" Or t.Name = "FrmPrint" Or t.Name.ToString.Contains("SMS") Then Continue For
                    DGV.Rows.Add()
                    DGV.Rows(i).Cells(0).Value = t.Name
                    Using frm As Form = ObjectFinder.CreateForm(t.Name)
                        DGV.Rows(i).Cells(1).Value = frm.Text
                    End Using
                    i += 1
                End If
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "CreateShortcutSPage", "getallforms")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Try


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using Cmd As New SqlClient.SqlCommand(String.Format("DELETE FROM ShortcutMenu WHERE IdUser={0}", PublicFunction.Id_User), PublicFunction.ConectionBank)
                Cmd.CommandTimeout = 0
                Cmd.ExecuteNonQuery()
            End Using

            For Each Dg As DataGridViewRow In DGV.Rows
                If (Dg.Cells(2).Value = True) Then
                    Using Cmd As New SqlClient.SqlCommand(String.Format("Insert into ShortcutMenu values('{0}','{1}',1,{2},'','{3}')", Dg.Cells(0).Value, Dg.Cells(1).Value, PublicFunction.Id_User, DateTime.Now.ToShortDateString()), PublicFunction.ConectionBank)
                        Cmd.CommandTimeout = 0
                        Cmd.ExecuteNonQuery()
                    End Using
                End If

            Next

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "CreateShortcutSPage", "BtnOk_Click")
            Me.Close()
        End Try
    End Sub
End Class