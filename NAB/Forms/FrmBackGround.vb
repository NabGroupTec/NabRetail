Imports System.Data.SqlClient
Public Class FrmBackGround


    Private Sub RdoDefalut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDefalut.CheckedChanged
        If RdoDefalut.Checked = True Then
            Pic.Image = My.Resources.BackGround
        End If
    End Sub

    Private Sub RdoSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoSelect.CheckedChanged
        If RdoSelect.Checked = True Then
            Pic.Image = Nothing
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            OpenF.ShowDialog()
            If OpenF.FileName <> "" Then
                If Not Pic.Image Is Nothing Then
                    Pic.Image.Dispose()
                End If
                Try

                    Pic.Image = Image.FromFile(OpenF.FileName)
                    Dim f As New System.IO.FileInfo(OpenF.FileName)
                    If f.Length > 300000 Then
                        If MessageBox.Show("تصویر انتخابی شما میتواند باعث سنگین شدن نسخه پشتیبان و اطلاعات شود آیا برای ادامه کار مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Pic.Image = Nothing
                            Exit Sub
                        End If
                    End If

                Catch ex As BadImageFormatException
                    If Not Pic.Image Is Nothing Then
                        Pic.Image.Dispose()
                    End If
                    Pic.Image = Nothing
                    MessageBox.Show("تصویر انتخاب شده نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

            End If
        Catch ex As Exception
            If Not Pic.Image Is Nothing Then
                Pic.Image.Dispose()
            End If
            Pic.Image = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("UPDATE  Define_User SET [Image]=@Image,TypeImage=@TypeImage WHERE Id=@Id", ConectionBank)
                CMD.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id_User
                CMD.Parameters.AddWithValue("@TypeImage", SqlDbType.Int).Value = If(RdoDefalut.Checked = True, 0, 1)
                If Pic.Image Is Nothing Then
                    MessageBox.Show("تصویری را جهت ثبت انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Exit Sub
                Else
                    Dim mstr As New System.IO.MemoryStream
                    Pic.Image.Save(mstr, Imaging.ImageFormat.Jpeg)
                    Dim arrImage As Byte() = mstr.GetBuffer

                    If RdoSelect.Checked = True Then
                        CMD.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = arrImage
                    Else
                        CMD.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = System.Data.SqlTypes.SqlBinary.Null
                    End If
                End If
                CMD.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Me.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackGround", "Btnadd_Click")
        End Try
    End Sub

    Private Sub FrmBackGround_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmBackGround_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        GetImageBackGround()
    End Sub
    Private Sub GetImageBackGround()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand("SELECT [Image], TypeImage FROM Define_User WHERE Id=" & Id_User, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using
            If dtr.HasRows Then
                dtr.Read()

                Dim mstr As New System.IO.MemoryStream()
                Dim byt() As Byte
                If dtr("TypeImage") = 0 Then
                    RdoDefalut.Checked = True
                    Pic.Image = My.Resources.BackGround
                Else
                    RdoSelect.Checked = True
                    byt = dtr("Image")
                    mstr = New System.IO.MemoryStream(byt)
                    Pic.Image = Image.FromStream(mstr)
                End If

            Else
                RdoDefalut.Checked = True
                Pic.Image = My.Resources.BackGround
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            RdoDefalut.Checked = True
            Pic.Image = My.Resources.BackGround
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackGround", "GetImageBackGround")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Private.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnadd.Enabled = True Then Btnadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub
End Class