Imports System.Data.SqlClient
Public Class FrmInfoCompony

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Set_Print.htm")
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnadd.Enabled = True Then Btnadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim sql As String = ""
            If String.IsNullOrEmpty(LId.Text) Then
                sql = "INSERT INTO Define_Company(CompanyName,IdCompany,TelFax,Address,Header,Footer,BackUpPath,CompanyImage,IdUser) VALUES(@CompanyName,@IdCompany,@TelFax,@Address,@Header,@Footer,@BackUpPath,@CompanyImage,@IdUser)"
            Else
                sql = "UPDATE  Define_Company SET CompanyName=@CompanyName,IdCompany=@IdCompany,TelFax=@TelFax,Address=@Address,Header=@Header,Footer=@Footer,BackUpPath=@BackUpPath,CompanyImage=@CompanyImage " & If(ChkAdmin.Visible = False Or (ChkAdmin.Visible = True And ChkAdmin.Checked = False), " WHERE IdUser=" & Id_User, "")
            End If
            Using CMD As New SqlCommand(sql, ConectionBank)
                CMD.Parameters.AddWithValue("@CompanyName", SqlDbType.NVarChar).Value = TxtName.Text.Trim
                CMD.Parameters.AddWithValue("@IdCompany", SqlDbType.NVarChar).Value = TxtAdd.Text.Trim
                CMD.Parameters.AddWithValue("@TelFax", SqlDbType.NVarChar).Value = TxtTell.Text.Trim
                CMD.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = TxtAddress.Text.Trim
                CMD.Parameters.AddWithValue("@Header", SqlDbType.NVarChar).Value = TxtHeader.Text.Trim
                CMD.Parameters.AddWithValue("@Footer", SqlDbType.NVarChar).Value = TxtFooter.Text.Trim
                CMD.Parameters.AddWithValue("@BackUpPath", SqlDbType.NVarChar).Value = TxtPath.Text.Trim
                CMD.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                If PicArm.Image Is Nothing Then
                    Dim mstr As New System.IO.MemoryStream
                    PicArm.Image = My.Resources.TmpImage
                    PicArm.Image.Save(mstr, Imaging.ImageFormat.Jpeg)
                    Dim arrImage As Byte() = mstr.GetBuffer
                    CMD.Parameters.AddWithValue("@CompanyImage", SqlDbType.VarBinary).Value = arrImage
                Else
                    Dim mstr As New System.IO.MemoryStream
                    PicArm.Image.Save(mstr, Imaging.ImageFormat.Png)
                    Dim arrImage As Byte() = mstr.GetBuffer
                    CMD.Parameters.AddWithValue("@CompanyImage", SqlDbType.VarBinary).Value = arrImage
                End If
                CMD.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مشخصات شرکت", "ذخیره", "", "")

            Me.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmInfoCompany", "Btnadd_Click")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmInfoCompony_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtName.Focus()
    End Sub

    Private Sub FrmInfoCompony_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub
    Private Sub GetInfo()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand("SELECT TOP 1 * FROM Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using
            If dtr.HasRows Then
                dtr.Read()
                TxtName.Text = If(dtr("CompanyName") Is DBNull.Value, "", dtr("CompanyName"))
                TxtAdd.Text = If(dtr("IdCompany") Is DBNull.Value, "", dtr("IdCompany"))
                TxtTell.Text = If(dtr("TelFax") Is DBNull.Value, "", dtr("TelFax"))
                TxtAddress.Text = If(dtr("Address") Is DBNull.Value, "", dtr("Address"))
                TxtHeader.Text = If(dtr("Header") Is DBNull.Value, "", dtr("Header"))
                TxtFooter.Text = If(dtr("Footer") Is DBNull.Value, "", dtr("Footer"))
                TxtPath.Text = If(dtr("BackUpPath") Is DBNull.Value, "", dtr("BackUpPath"))
                Try
                    Dim mstr As New System.IO.MemoryStream()
                    Dim byt() As Byte
                    byt = dtr("CompanyImage")
                    mstr = New System.IO.MemoryStream(byt)
                    PicArm.Image = Image.FromStream(mstr)
                Catch ex As Exception
                    PicArm.Image = My.Resources.TmpImage
                End Try
                LId.Text = dtr("ID")
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmInfoCompany", "GetInfo")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmInfoCompony_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F111")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    Me.GetInfo()
                End If
            End If
        Else
            Me.GetInfo()
        End If

        If Not UCase(NamUser) = "ADMIN" Then
            ChkAdmin.Checked = False
            ChkAdmin.Visible = False
        Else
            ChkAdmin.Checked = True
            ChkAdmin.Visible = True
        End If
        If Not AreYouServerExit() Then
            Button2.Enabled = False
            TxtPath.Enabled = False
        Else
            Button2.Enabled = True
            TxtPath.Enabled = True
        End If
        If String.IsNullOrEmpty(TxtPath.Text.Trim) Then TxtPath.Text = "C:\"

        If AllowEdit < 0 Then
            MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf AllowEdit = 1 Then
            Btnadd.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
        End If
    End Sub
    Public Function AreYouServerExit() As Boolean
        Try
            Dim Address As String = GetPath()
            If String.IsNullOrEmpty(Address) Then
                Return False
            End If
            If UCase(Address) = "LOCALHOST" Or UCase(Address) = "." Or UCase(Address) = "127.0.0.1" Or UCase(Address) = UCase(System.Net.Dns.GetHostName()) Then
                Return True
            End If
            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
            For i As Integer = 0 To h.AddressList.Length - 1
                If UCase(Address) = h.AddressList.GetValue(i).ToString Then
                    Return True
                End If
            Next

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetPath() As String
        Try
            If Not (System.IO.File.Exists(UCase("Provider.PTH"))) Then
                System.IO.File.Create(My.Application.Info.DirectoryPath + "\Provider.PTH")
                Return "127.0.0.1"
            Else
                Dim str As String = ""
                str = System.IO.File.ReadAllText(My.Application.Info.DirectoryPath + "\Provider.PTH")
                If String.IsNullOrEmpty(str) Then
                    Return "127.0.0.1"
                Else
                    Return str.Substring(0, str.IndexOf(vbCrLf))
                End If
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            FD.ShowNewFolderButton = True
            FD.ShowDialog()
            If FD.SelectedPath.ToString <> "" Then
                Dim pp As String = FD.SelectedPath.ToString
                If pp(pp.Length - 1) <> "\" Then pp = pp + "\"
                TxtPath.Text = pp
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmInfoCompany", "Button2_Click")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            OpenF.ShowDialog()
            If OpenF.FileName <> "" Then
                If Not PicArm.Image Is Nothing Then
                    PicArm.Image.Dispose()
                End If
                Try
                    PicArm.Image = Image.FromFile(OpenF.FileName)
                Catch ex As BadImageFormatException
                    If Not PicArm.Image Is Nothing Then
                        PicArm.Image.Dispose()
                    End If
                    PicArm.Image = Nothing
                    MessageBox.Show("تصویر انتخاب شده نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

            End If
        Catch ex As Exception
            If Not PicArm.Image Is Nothing Then
                PicArm.Image.Dispose()
            End If
            PicArm.Image = Nothing
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Not PicArm.Image Is Nothing Then
                PicArm.Image.Dispose()
            End If
            PicArm.Image = Nothing
        Catch ex As Exception

        End Try
    End Sub
End Class