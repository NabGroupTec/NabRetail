Imports System.Data.SqlClient
Imports Ionic.Zip
Imports System.IO
Imports System.ServiceProcess

Public Class FrmBackUp
    Dim ds As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            FD.ShowNewFolderButton = True
            FD.ShowDialog()
            If FD.SelectedPath.ToString <> "" Then
                Dim pp As String = FD.SelectedPath.ToString
                If pp(pp.Length - 1) <> "\" Then pp = pp + "\"
                TxtPathBackup.Text = pp
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button1_Click")
        End Try
    End Sub

    Private Function CreatePath(ByVal path As String) As String
        Try
            Dim t_time As String = GetDate().Replace("/", "-") & "  " & Date.Now.ToLongTimeString.Replace(":", "-")
            If path(path.Length - 1) <> "\" Then
                Directory.CreateDirectory(path + "\" + t_time)
                Return path + "\" + t_time
            Else
                Directory.CreateDirectory(path + t_time)
                Return path + t_time
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If String.IsNullOrEmpty(TxtPathBackup.Text) Then
                MessageBox.Show("مسیر تهیه نسخه پشتیبان را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            If Directory.Exists(TxtPathBackup.Text.Trim) Then
                Dim str_path As String = CreatePath(TxtPathBackup.Text.Trim)
                If String.IsNullOrEmpty(str_path) Then
                    MessageBox.Show("مسیر تهیه نسخه پشتیبان قابل ساختن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True
                    Exit Sub
                End If

                Dim SqlCon As New SqlConnection("Data Source=LocalHost;User ID=Nab_User;Password=q1w2e3r4t5")
                If SqlCon.State <> ConnectionState.Open Then SqlCon.Open()


                Dim dt As New DataTable
                Using CMDSelect As New SqlCommand("SELECT NameEnglish FROM [Manage_Nab].[dbo].[List_Period]", SqlCon)
                    CMDSelect.CommandTimeout = 0
                    dt.Load(CMDSelect.ExecuteReader)
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand(String.Format("BACKUP DATABASE {0} TO DISK = N'{1}\Info{2}.BAK'", dt.Rows(i).Item("NameEnglish"), str_path, dt.Rows(i).Item("NameEnglish").ToString.Replace("DBNab", "")), SqlCon)
                        CMD.CommandTimeout = 0
                        CMD.ExecuteNonQuery()
                    End Using
                Next

                Using CMD As New SqlCommand(String.Format("BACKUP DATABASE Manage_Nab TO DISK = N'{0}\Account.BAK'", str_path), SqlCon)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                If SqlCon.State <> ConnectionState.Closed Then SqlCon.Close()

                '''''''''''''''''''''''''''''''''ZipFolder
                Try
                    Using Ziper As ZipFile = New ZipFile
                        Ziper.AddDirectory(str_path)
                        Ziper.ProvisionalAlternateEncoding = System.Text.Encoding.UTF8
                        Ziper.Save(str_path & ".Nab")
                        Directory.Delete(str_path, True)
                    End Using
                Catch ex As Exception
                    Try
                        Directory.Delete(str_path, True)
                    Catch e2 As Exception

                    End Try
                    MessageBox.Show("مشکلی در ساخت نسخه پشتیبان به وجود آمده است لطفا از درایو غیر ویندوز جهت تهیه نسخه پشتیبان استفاده کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True
                    Exit Sub
                End Try
                '''''''''''''''''''''''''''''''''
                Me.Enabled = True

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "نسخه پشتیبان", "تهیه نسخه پشتیبان", "", "")

                MessageBox.Show("عملیات پشتیبان گیری با موفقیت انجام شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("مسير مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True
            End If
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("بانک اطلاعات در حال استفاده میباشد و فعلا عملیات پشتیبان گیری امکان پذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button2_Click")
            End If
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            OP.ShowDialog()
            If OP.FileName.ToString <> "" Then
                TxtPathRestore.Text = OP.FileName.ToString
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button4_Click")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If String.IsNullOrEmpty(TxtPathRestore.Text) Then
                MessageBox.Show("مسیر بازیابی نسخه پشتیبان را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            If File.Exists(TxtPathRestore.Text) Then
                Dim SqlCon As New SqlConnection("Data Source=LocalHost;User ID=Nab_User;Password=q1w2e3r4t5")
                If SqlCon.State <> ConnectionState.Open Then SqlCon.Open()

                '''''''''''''''''''''''''''''''''''''''''''''''Extract ZipFile
                Try
                    Using zip As ZipFile = ZipFile.Read(TxtPathRestore.Text)
                        Dim eZip As ZipEntry
                        For Each eZip In zip
                            eZip.Extract(TxtPathRestore.Text.Substring(0, TxtPathRestore.Text.Length - 7), ExtractExistingFileAction.OverwriteSilently)
                        Next
                    End Using
                Catch ex1 As Exception
                    MessageBox.Show("مشکلی در بازیابی نسخه پشتیبان به وجود آمده است لطفا از صحت وجود فایل مطمئن شوید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True
                    Exit Sub
                End Try
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using CMD As New SqlCommand(String.Format("USE master RESTORE DATABASE [Manage_Nab] FROM DISK = N'{0}\Account.BAK' WITH REPLACE,MOVE 'Manage_Nab' TO '{1}\Manage_Nab.mdf',MOVE 'Manage_Nab_Log' TO '{2}\Manage_Nab_Log.ldf'", TxtPathRestore.Text.Substring(0, TxtPathRestore.Text.Length - 8), My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath), SqlCon)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                Dim dt As New DataTable

                Using CMDSelect As New SqlCommand("SELECT NameEnglish FROM [Manage_Nab].[dbo].[List_Period]", SqlCon)
                    CMDSelect.CommandTimeout = 0
                    dt.Load(CMDSelect.ExecuteReader)
                End Using

                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("NameEnglish") = "DBNab" And (File.Exists(TxtPathRestore.Text.Substring(0, TxtPathRestore.Text.Length - 7) & "\Info.BAK")) Then
                        Using CMD As New SqlCommand(String.Format("USE master RESTORE DATABASE {0} FROM DISK = N'{1}\Info.BAK' WITH REPLACE,MOVE '{2}' TO '{3}\{4}.mdf',MOVE '{5}_Log' TO '{6}\{7}_Log.ldf'", dt.Rows(i).Item("NameEnglish"), TxtPathRestore.Text.Substring(0, TxtPathRestore.Text.Length - 8), dt.Rows(i).Item("NameEnglish"), My.Application.Info.DirectoryPath, dt.Rows(i).Item("NameEnglish"), dt.Rows(i).Item("NameEnglish"), My.Application.Info.DirectoryPath, dt.Rows(i).Item("NameEnglish")), SqlCon)
                            CMD.CommandTimeout = 0
                            CMD.ExecuteNonQuery()
                        End Using
                    Else
                        Using CMD As New SqlCommand(String.Format("USE master RESTORE DATABASE {0} FROM DISK = N'{1}\Info{2}.BAK' WITH REPLACE,MOVE '{3}' TO '{4}\{5}.mdf',MOVE '{6}_Log' TO '{7}\{8}_Log.ldf'", dt.Rows(i).Item("NameEnglish"), TxtPathRestore.Text.Substring(0, TxtPathRestore.Text.Length - 8), dt.Rows(i).Item("NameEnglish").ToString.Replace("DBNab", ""), dt.Rows(i).Item("NameEnglish"), My.Application.Info.DirectoryPath, dt.Rows(i).Item("NameEnglish"), dt.Rows(i).Item("NameEnglish"), My.Application.Info.DirectoryPath, dt.Rows(i).Item("NameEnglish")), SqlCon)
                            CMD.CommandTimeout = 0
                            CMD.ExecuteNonQuery()
                        End Using
                    End If
                    
                Next

                If SqlCon.State <> ConnectionState.Closed Then SqlCon.Close()

                Try
                    Directory.Delete(TxtPathRestore.Text.Substring(0, TxtPathRestore.Text.Length - 7), True)
                Catch ex As Exception

                End Try
                Me.Enabled = True
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "نسخه پشتیبان", "بازیابی نسخه پشتیبان", "", "")
                MessageBox.Show("عملیات بازیابی با موفقیت انجام شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                QExit = True
                System.Windows.Forms.Application.Restart()
            Else
                MessageBox.Show("فايل پشتيبان پيدا نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show(ex.Message, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'MessageBox.Show("بانک اطلاعات در حال استفاده میباشد و فعلا عملیات بازیابی امکان پذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button3_Click")
            End If
            Me.Enabled = True
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BackUp_Bnk.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(0).Focus = True Then
                If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(1).Focus = True Then
                If Button3.Enabled = True Then Button3_Click(Nothing, Nothing)
            ElseIf TabControl1.TabPages(2).Focus = True Then
                If Button5.Enabled = True Then Button5_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            If TabControl1.TabPages(2).Focus = True Then
                If Not File.Exists(My.Application.Info.DirectoryPath + "\SetBackupService.ini") Then
                    File.Create(My.Application.Info.DirectoryPath + "\SetBackupService.ini")
                    FarsiDate1.Enabled = False
                    FarsiDate2.Enabled = False
                    FarsiDate1.ThisText = GetDate()
                    FarsiDate2.ThisText = GetDate()
                    DT1.Enabled = False
                    DT2.Enabled = False
                Else
                    Dim Robj As New INIFile
                    Dim objstr As String = ""
                    Robj.FileName = My.Application.Info.DirectoryPath + "\SetBackupService.ini"

                    objstr = Robj.GetValue("Week", "Day", "1234567")
                    If objstr.Contains("1") Then Chk1.Checked = True
                    If objstr.Contains("2") Then Chk2.Checked = True
                    If objstr.Contains("3") Then Chk3.Checked = True
                    If objstr.Contains("4") Then Chk4.Checked = True
                    If objstr.Contains("5") Then Chk5.Checked = True
                    If objstr.Contains("6") Then Chk6.Checked = True
                    If objstr.Contains("7") Then Chk7.Checked = True



                    objstr = Robj.GetValue("Date", "Dat1", "none")
                    If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                        ChkAzDate.Checked = False
                    Else
                        ChkAzDate.Checked = True
                        FarsiDate1.ThisText = objstr
                    End If

                    objstr = Robj.GetValue("Date", "Dat2", "none")
                    If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                        ChkTaDate.Checked = False
                    Else
                        ChkTaDate.Checked = True
                        FarsiDate2.ThisText = objstr
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    objstr = Robj.GetValue("Time", "T1", "none")
                    If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                        ChkAzDate.Checked = False
                    Else
                        ChkAzTime.Checked = True
                        DT1.Enabled = True
                        DT1.Value = Date.Now.ToShortDateString + " " + objstr
                    End If

                    objstr = Robj.GetValue("Time", "T2", "none")
                    If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                        ChkTaTime.Checked = False
                    Else
                        ChkTaTime.Checked = True
                        DT2.Enabled = True
                        DT2.Value = Date.Now.ToShortDateString + " " + objstr
                    End If
                    ''''''''''''''''''''''''
                    objstr = Robj.GetValue("Action", "Count", "1")
                    If String.IsNullOrEmpty(objstr) Then
                        Num1.Value = 1
                    Else
                        Num1.Value = objstr
                    End If

                    ''''''''''''''''''''''''
                    objstr = Robj.GetValue("Address", "Path", "C:\")
                    If String.IsNullOrEmpty(objstr) Then
                        TxtAddini.Text = "C:\"
                    Else
                        TxtAddini.Text = objstr
                    End If

                End If
                StateService()
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnLog.Enabled = True Then BtnLog_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmBackUp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ConectionBank.ConnectionString = DataSource
    End Sub

    Private Sub FrmBackUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmBackUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F112")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                    Try

                        Using CMD As New SqlCommand("SELECT TOP 1 BackUpPath FROM Define_Company", ConectionBank)
                            TxtPathBackup.Text = CMD.ExecuteScalar
                            TxtAddini.Text = TxtPathBackup.Text
                        End Using
                    Catch ex As Exception

                    End Try
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    SqlConnection.ClearPool(ConectionBank)
                End If
            End If
        Else
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Try

                Using CMD As New SqlCommand("SELECT TOP 1 BackUpPath FROM Define_Company", ConectionBank)
                    TxtPathBackup.Text = CMD.ExecuteScalar
                    TxtAddini.Text = TxtPathBackup.Text
                End Using
            Catch ex As Exception

            End Try
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            SqlConnection.ClearPool(ConectionBank)
        End If

        If Not File.Exists(My.Application.Info.DirectoryPath + "\SetBackupService.ini") Then
            File.Create(My.Application.Info.DirectoryPath + "\SetBackupService.ini")
            FarsiDate1.Enabled = False
            FarsiDate2.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.ThisText = GetDate()
            DT1.Enabled = False
            DT2.Enabled = False
            Button5.Enabled = True
        Else
            Dim Robj As New INIFile
            Dim objstr As String = ""
            Robj.FileName = My.Application.Info.DirectoryPath + "\SetBackupService.ini"

            objstr = Robj.GetValue("Week", "Day", "1234567")
            If objstr.Contains("1") Then Chk1.Checked = True
            If objstr.Contains("2") Then Chk2.Checked = True
            If objstr.Contains("3") Then Chk3.Checked = True
            If objstr.Contains("4") Then Chk4.Checked = True
            If objstr.Contains("5") Then Chk5.Checked = True
            If objstr.Contains("6") Then Chk6.Checked = True
            If objstr.Contains("7") Then Chk7.Checked = True



            objstr = Robj.GetValue("Date", "Dat1", "none")
            If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                ChkAzDate.Checked = False
            Else
                ChkAzDate.Checked = True
                FarsiDate1.ThisText = objstr
            End If

            objstr = Robj.GetValue("Date", "Dat2", "none")
            If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                ChkTaDate.Checked = False
            Else
                ChkTaDate.Checked = True
                FarsiDate2.ThisText = objstr
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            objstr = Robj.GetValue("Time", "T1", "none")
            If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                ChkAzDate.Checked = False
            Else
                ChkAzTime.Checked = True
                DT1.Enabled = True
                DT1.Value = Date.Now.ToShortDateString + " " + objstr
            End If

            objstr = Robj.GetValue("Time", "T2", "none")
            If UCase(objstr) = "NONE" Or String.IsNullOrEmpty(objstr) Then
                ChkTaTime.Checked = False
            Else
                ChkTaTime.Checked = True
                DT2.Enabled = True
                DT2.Value = Date.Now.ToShortDateString + " " + objstr
            End If
            ''''''''''''''''''''''''
            objstr = Robj.GetValue("Action", "Count", "1")
            If String.IsNullOrEmpty(objstr) Then
                Num1.Value = 1
            Else
                Num1.Value = objstr
            End If

            ''''''''''''''''''''''''
            objstr = Robj.GetValue("Address", "Path", "C:\")
            If String.IsNullOrEmpty(objstr) Then
                TxtAddini.Text = "C:\"
            Else
                TxtAddini.Text = objstr
            End If

            Button5.Enabled = False
        End If
        StateService()

        If AllowEdit < 0 Then
            MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf AllowEdit = 1 Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            BtnInstall.Enabled = False
            BtnUninstall.Enabled = False
            BtnStart.Enabled = False
            BtnStop.Enabled = False
            Button6.Enabled = False
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
        Button5.Enabled = True
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
        Button5.Enabled = True
    End Sub

    Private Sub ChkAzTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzTime.CheckedChanged
        If ChkAzTime.Checked = True Then
            DT1.Value = Date.Now
            DT1.Enabled = True
            DT1.Focus()
        Else
            DT1.Enabled = False
            DT1.Value = Date.Now
        End If
        Button5.Enabled = True
    End Sub

    Private Sub ChkTaTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaTime.CheckedChanged
        If ChkTaTime.Checked = True Then
            DT2.Value = Date.Now
            DT2.Enabled = True
            DT2.Focus()
        Else
            DT2.Enabled = False
            DT2.Value = Date.Now
        End If
        Button5.Enabled = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If Not File.Exists(My.Application.Info.DirectoryPath + "\SetBackupService.ini") Then
                MessageBox.Show("جهت اجرا وجود ندارد " & "SetBackupService.ini" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtAddini.Text) Then
                MessageBox.Show("محل نسخه پشتیبان نامشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not Directory.Exists(TxtAddini.Text) Then
                MessageBox.Show("مسیر تهیه نسخه پشتیبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If


            If Chk1.Checked = False And Chk2.Checked = False And Chk3.Checked = False And Chk4.Checked = False And Chk5.Checked = False And Chk6.Checked = False And Chk7.Checked = False Then
                MessageBox.Show("هیچ روزی از ایام هفته انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    MessageBox.Show("محدوده تاریخ اشتباه است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    FarsiDate1.Focus()
                    Exit Sub
                End If
                If String.IsNullOrEmpty(FarsiDate1.ThisText) Or String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                    MessageBox.Show("محدوده تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkAzTime.Checked = True And ChkTaTime.Checked = True Then
                If DT1.Value > DT2.Value Then
                    MessageBox.Show("محدوده ساعت اشتباه است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DT1.Focus()
                    Exit Sub
                End If
                If String.IsNullOrEmpty(DT1.Value) Or String.IsNullOrEmpty(DT2.Value) Then
                    MessageBox.Show("محدوده ساعت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Dim obj As New INIFile()
            obj.FileName = My.Application.Info.DirectoryPath + "\SetBackupService.ini"
            obj.WriteValue("Week", "Day", IIf(Chk1.Checked = True, "1", "") & If(Chk2.Checked = True, "2", "") & If(Chk3.Checked = True, "3", "") & If(Chk4.Checked = True, "4", "") & If(Chk5.Checked = True, "5", "") & If(Chk6.Checked = True, "6", "") & If(Chk7.Checked = True, "7", ""))
            obj.WriteValue("Date", "Dat1", IIf(ChkAzDate.Checked = True, FarsiDate1.ThisText, "none"))
            obj.WriteValue("Date", "Dat2", IIf(ChkTaDate.Checked = True, FarsiDate2.ThisText, "none"))
            obj.WriteValue("Time", "T1", IIf(ChkAzTime.Checked = True, DT1.Value.ToLongTimeString, "none"))
            obj.WriteValue("Time", "T2", IIf(ChkTaTime.Checked = True, DT2.Value.ToLongTimeString, "none"))
            obj.WriteValue("Action", "Count", Num1.Value)
            obj.WriteValue("Address", "Path", TxtAddini.Text.Trim)
            Button5.Enabled = False
            MessageBox.Show("تغییرات ذخیره شد . جهت اعمال تغییرات باید سرویس راه اندازی مجدد شود", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button5_Click")
        End Try
    End Sub

    Private Sub StateService()
        Try
            Dim myServiceName As String = "ZarrinBackupService"
            Dim status As String = ""
            Dim mySC As ServiceController = Nothing


            mySC = New ServiceController(myServiceName)
            Try
                status = mySC.Status.ToString
            Catch ex As Exception
                LInstal.Text = "سرویس نصب نشده است"
                BtnInstall.Enabled = True
                BtnUninstall.Enabled = False
                BtnInstall.BackgroundImage = My.Resources.Start
                BtnUninstall.BackgroundImage = My.Resources.deError

                LService.Text = "سرویس غیر فعال است"
                BtnStart.Enabled = False
                BtnStop.Enabled = False
                BtnStart.BackgroundImage = My.Resources.DeStart
                BtnStop.BackgroundImage = My.Resources.deError

                Exit Sub
            End Try

            LInstal.Text = "سرویس نصب شده است"
            BtnInstall.Enabled = False
            BtnUninstall.Enabled = True
            BtnInstall.BackgroundImage = My.Resources.DeStart
            BtnUninstall.BackgroundImage = My.Resources._Error

            If mySC.Status.Equals(ServiceControllerStatus.Stopped) Or mySC.Status.Equals(ServiceControllerStatus.StopPending) Then
                LService.Text = "سرویس غیر فعال است"
                BtnStart.Enabled = True
                BtnStop.Enabled = False
                BtnStart.BackgroundImage = My.Resources.Start
                BtnStop.BackgroundImage = My.Resources.deError
            Else
                LService.Text = "سرویس فعال است"
                BtnStart.Enabled = False
                BtnStop.Enabled = True
                BtnStart.BackgroundImage = My.Resources.DeStart
                BtnStop.BackgroundImage = My.Resources._Error
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "StateService")
            LInstal.Text = "سرویس نصب نشده است"
            LService.Text = "سرویس غیر فعال است"
            BtnInstall.Enabled = True
            BtnUninstall.Enabled = False
            BtnInstall.BackgroundImage = My.Resources.Start
            BtnUninstall.BackgroundImage = My.Resources.deError
            BtnStart.Enabled = False
            BtnStop.Enabled = False
            BtnStart.BackgroundImage = My.Resources.DeStart
            BtnStop.BackgroundImage = My.Resources.deError
        End Try
    End Sub

    Private Sub BtnInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInstall.Click
        Try
            If Not File.Exists(My.Application.Info.DirectoryPath + "\SetBackupService.ini") Then
                MessageBox.Show("جهت اجرا وجود ندارد " & "SetBackupService.ini" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Not File.Exists(My.Application.Info.DirectoryPath + "\ZarrinBackupService.exe") Then
                MessageBox.Show("جهت اجرا وجود ندارد " & "ZarrinBackupService.exe" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Button5.Enabled = True Then
                MessageBox.Show("قبل از نصب سرویس تغییرات مربوطه را ذخیره کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim pr As Process
            Dim args As New ProcessStartInfo(Environment.SystemDirectory.ToString.Replace("system32", "") + "Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe")
            With args
                .Arguments = "ZarrinBackupService.exe"
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            pr = Process.Start(args)
            pr.CloseMainWindow()

            System.Threading.Thread.Sleep(3000)

            StateService()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "BtnInstall_Click")
        End Try
    End Sub

    Private Sub BtnUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUninstall.Click
        Try

            If Not File.Exists(My.Application.Info.DirectoryPath + "\ZarrinBackupService.exe") Then
                MessageBox.Show("جهت اجرا وجود ندارد " & "ZarrinBackupService.exe" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim pr As Process
            Dim args As New ProcessStartInfo(Environment.SystemDirectory.ToString.Replace("system32", "") + "Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe")
            With args
                .Arguments = "-u ZarrinBackupService.exe"
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            pr = Process.Start(args)
            pr.CloseMainWindow()

            System.Threading.Thread.Sleep(5000)

            StateService()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "BtnUninstall_Click")
        End Try
    End Sub

    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        If Not File.Exists(My.Application.Info.DirectoryPath + "\SetBackupService.ini") Then
            MessageBox.Show("جهت اجرا وجود ندارد " & "SetBackupService.ini" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Not File.Exists(My.Application.Info.DirectoryPath + "\ZarrinBackupService.exe") Then
            MessageBox.Show("جهت اجرا وجود ندارد " & "ZarrinBackupService.exe" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Button5.Enabled = True Then
            MessageBox.Show("قبل از فعال کردن سرویس تغییرات مربوطه را ذخیره کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim myServiceName As String = "ZarrinBackupService"
        Dim status As String = ""
        Dim mySC As ServiceController = Nothing

        mySC = New ServiceController(myServiceName)
        Try
            status = mySC.Status.ToString
        Catch ex As Exception
            StateService()
            Exit Sub
        End Try
        
        If mySC.Status.Equals(ServiceControllerStatus.Stopped) Or mySC.Status.Equals(ServiceControllerStatus.StopPending) Then
            Try
                mySC.Start()
                mySC.WaitForStatus(ServiceControllerStatus.Running)
            Catch ex As Exception
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "BtnStart_Click")
            End Try
        End If

        StateService()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            FD.ShowNewFolderButton = True
            FD.ShowDialog()
            If FD.SelectedPath.ToString <> "" Then
                Dim pp As String = FD.SelectedPath.ToString
                If pp(pp.Length - 1) <> "\" Then pp = pp + "\"
                TxtAddini.Text = pp
                Button5.Enabled = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button6_Click")
        End Try
    End Sub

    Private Sub Chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Chk2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk2.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Chk3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk3.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Chk4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk4.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Chk5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk5.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Chk6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk6.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Chk7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk7.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        Button5.Enabled = True
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        Button5.Enabled = True
    End Sub

    Private Sub DT1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT1.ValueChanged
        Button5.Enabled = True
    End Sub

    Private Sub DT2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT2.ValueChanged
        Button5.Enabled = True
    End Sub

    Private Sub Num1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num1.ValueChanged
        Button5.Enabled = True
    End Sub

    Private Sub BtnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStop.Click
        Dim myServiceName As String = "ZarrinBackupService"
        Dim status As String = ""
        Dim mySC As ServiceController = Nothing

        mySC = New ServiceController(myServiceName)
        Try
            status = mySC.Status.ToString
        Catch ex As Exception
            StateService()
            Exit Sub
        End Try

        If mySC.Status.Equals(ServiceControllerStatus.Running) Or mySC.Status.Equals(ServiceControllerStatus.StartPending) Or mySC.Status.Equals(ServiceControllerStatus.ContinuePending) Then
            Try
                mySC.Stop()
                mySC.WaitForStatus(ServiceControllerStatus.Stopped)
            Catch ex As Exception
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "BtnStop_Click")
            End Try
        End If

        StateService()
    End Sub

    Private Sub BtnLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLog.Click
        If Not File.Exists(My.Application.Info.DirectoryPath + "\Nab_Log.txt") Then
            MessageBox.Show("جهت نمایش وجود ندارد " & "Nab_Log.txt" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Call Shell(String.Format("notepad.exe {0}\Nab_Log.txt", My.Application.Info.DirectoryPath), AppWinStyle.NormalFocus, False, -1)
    End Sub
End Class