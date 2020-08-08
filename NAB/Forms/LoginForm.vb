Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class LoginForm

    Dim ds As New DataTable
    Dim dta As New SqlDataAdapter
    Dim dsP As New DataTable
    Dim dtaP As New SqlDataAdapter
    Dim idu As Long
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Function SetDataSource(ByVal server As String) As String
        Return String.Format("Data Source= {0};Initial Catalog={1};User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0", server, CmbPeriod.SelectedValue)
    End Function

    Private Sub LoginForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtAddress.Focus()
    End Sub

    Private Sub LoginForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub LoginForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SetTitle()
            Dim myCulture As New Globalization.CultureInfo("fa-IR")
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCulture)
            GetPath("GET")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetPath(ByVal typ As String)
        Try
            If typ = "GET" Then
                If Not (File.Exists(UCase("Provider.PTH"))) Then
                    File.Create(My.Application.Info.DirectoryPath + "\Provider.PTH")
                    TxtAddress.Text = "127.0.0.1"
                Else
                    Dim str As String = ""
                    str = File.ReadAllText(My.Application.Info.DirectoryPath + "\Provider.PTH")
                    If String.IsNullOrEmpty(str) Then
                        TxtAddress.Text = "127.0.0.1"
                    Else
                        TxtAddress.Text = str.Substring(0, str.IndexOf(vbCrLf))
                    End If
                End If
            Else
                If Not (File.Exists(UCase("Provider.PTH"))) Then
                    File.Create(My.Application.Info.DirectoryPath + "\Provider.PTH")
                    File.WriteAllText(My.Application.Info.DirectoryPath + "\Provider.PTH", TxtAddress.Text.Trim & vbCrLf)
                Else
                    File.WriteAllText(My.Application.Info.DirectoryPath + "\Provider.PTH", TxtAddress.Text.Trim & vbCrLf)
                End If
            End If
        Catch ex As Exception

        End Try

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

    Private Function AreYouLoging(ByVal User As String, ByVal Pass As String) As Boolean
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            Dim ds_U As New DataTable
            ds_U.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Define_User.Id,Nam,Pas,UserLogIn,S24,[Version]=(SELECT [Version] FROM DB_Info),AllowAdd=(SELECT [AllowAdd] FROM DB_Info) FROM Define_User  INNER JOIN SettingProgram ON SettingProgram.IdUser =Define_User.Id WHERE Nam =@Nam", ConectionBank)
                cmd.Parameters.AddWithValue("@Nam", SqlDbType.NVarChar).Value = User
                cmd.CommandTimeout = 0
                ds_U.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ds_U.Columns.Add("P", Type.GetType("System.String"))
            ds_U.Columns.Add("LogIn", Type.GetType("System.Int32"))

            For i As Integer = 0 To ds_U.Rows.Count - 1
                ds_U.Rows(i).Item("P") = Sec.StringDecrypt(ds_U.Rows(i).Item("Pas"), key.CreateDecryptor)
                ds_U.Rows(i).Item("LogIn") = Sec.StringDecrypt(ds_U.Rows(i).Item("UserLogIn"), key.CreateDecryptor)
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim row() As DataRow = ds_U.Select(String.Format("Nam='{0}' AND P='{1}'", User, Pass))

            If row.Length <= 0 Then
                MessageBox.Show("کاربری با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
                'ElseIf row(0).Item("LogIn") >= 1 Then
                'MessageBox.Show("کاربر مورد نظر قبلا وارد سیستم شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return False
            Else

                If Sec.StringDecrypt(ds_U.Rows(0).Item("Version"), key.CreateDecryptor) <> "6.15" Then
                    MessageBox.Show(String.Format("نسخه حسابداری با نسخه بانک اطلاعاتی همخوانی ندارد{0}نسخه حسابداری: 6.15{0}نسخه بانک اطلاعاتی: {1}", vbCrLf, Sec.StringDecrypt(ds_U.Rows(0).Item("Version"), key.CreateDecryptor)), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If

                Dim rowLogIn() As DataRow = ds_U.Select("LogIn>=" & 1)
                Tmp_Mon = rowLogIn.Length

                ' If String.IsNullOrEmpty(Trial) Then
                'Using LSecurity As New LauncherNetwork.LauncherNetworkControl
                'If Not (LSecurity.NtCounter(TxtAddress.Text.Trim) > Tmp_Mon) Then
                'MessageBox.Show("شما اجازه ورود ندارید.در این نسخه حداکثر  " & LSecurity.NtCounter(TxtAddress.Text.Trim) & " کاربر اجازه ورود دارند", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return False
                'End If
                'End Using
                'Else
                If GetDate() > Trial Then
                    MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return False
                End If
                'End If

                Nam_Account = CmbAccount.Text
                Id_Account = CmbAccount.SelectedValue

                Nam_Period = CmbPeriod.Text
                Id_Period = CmbPeriod.SelectedValue

                Id_User = row(0).Item("Id")
                NamUser = row(0).Item("Nam")
                AllowEdit = Sec.StringDecrypt(ds_U.Rows(0).Item("AllowAdd"), key.CreateDecryptor)

                If row(0).Item("S24") <= 0 Then
                    Kind_User = 2
                Else
                    Kind_User = 0
                End If

                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using CMD As New SqlCommand("Update Define_User Set UserLogIn=@UserLogIn WHERE Id=" & Id_User, ConectionBank)
                    CMD.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt("1", key.CreateEncryptor)
                    CMD.CommandTimeout = 0
                    CMD.ExecuteNonQuery()
                End Using

                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                SqlConnection.ClearPool(ConectionBank)
                Return True
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            SqlConnection.ClearPool(ConectionBank)
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LoginForm", "AreYouLoging")
            Return False
        End Try
    End Function

    Private Function AreYouLoging2(ByVal User As String, ByVal Pass As String) As Boolean
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ds_U As New DataTable
            ds_U.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(String.Format("SELECT Id,Nam,Pas FROM Define_User WHERE Nam =N'{0}'", User), ConectionBank)
                cmd.CommandTimeout = 0
                ds_U.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ds_U.Columns.Add("P", Type.GetType("System.String"))

            For i As Integer = 0 To ds_U.Rows.Count - 1
                ds_U.Rows(i).Item("P") = Sec.StringDecrypt(ds_U.Rows(i).Item("Pas"), key.CreateDecryptor)
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim row() As DataRow = ds_U.Select(String.Format("Nam='{0}' AND P='{1}'", User, Pass))

            If row.Length <= 0 Then
                MessageBox.Show("کاربری با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            idu = row(0).Item("Id")
            Return True
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            SqlConnection.ClearPool(ConectionBank)
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LoginForm", "AreYouLoging2")
            Return False
        End Try
    End Function

    Private Sub BtnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConnect.Click
        If BtnConnect.Text = "اتصال" Then
            If String.IsNullOrEmpty(TxtAddress.Text.Trim) Then
                MessageBox.Show("آدرس سرور را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtAddress.Focus()
                Exit Sub
            End If
            BtnConnect.Text = ""
            BtnConnect.Image = My.Resources.progress
            Application.DoEvents()
            TxtAddress.Enabled = False

            Try
                Dim sourec As String = String.Format("Data Source={0};User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0", TxtAddress.Text.Trim)
                If ConnectionTest(sourec) Then
                    '''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(Trial) Then
                        'Using LSecurity As New LauncherNetwork.LauncherNetworkControl
                        'If Not (Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(LSecurity.Run(TxtAddress.Text.Trim), ChrW(177), ""), ChrW(74), ChrW(110)), ChrW(71), ChrW(101)), ChrW(76), ChrW(100)), ChrW(77), ChrW(97)), ChrW(89), ChrW(107)), ChrW(66), ChrW(117)), ChrW(83), ChrW(114)), ChrW(76), ChrW(100))) = (ChrW(110) & ChrW(101) & ChrW(100) & ChrW(97) & ChrW(107) & ChrW(117) & ChrW(114) & ChrW(100)) Then
                        MessageBox.Show("اعتبار زمانی استفاده از برنامه تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        BtnConnect.Text = "اتصال"
                        BtnConnect.Image = Nothing
                        TxtAddress.Enabled = True
                        GroupBox1.Enabled = False
                        GroupBox3.Enabled = False
                        BtnOk.Enabled = False
                        Exit Sub
                        'End If
                        'End Using
                    Else
                        If GetDate() > Trial Then
                            MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            BtnConnect.Text = "اتصال"
                            BtnConnect.Image = Nothing
                            TxtAddress.Enabled = True
                            GroupBox1.Enabled = False
                            GroupBox3.Enabled = False
                            BtnOk.Enabled = False
                            My.Settings("Trial") = ""
                            My.Settings.Save()
                            Me.SetTitle()
                            Exit Sub
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''
                    BtnConnect.Text = "اتصال"
                    BtnConnect.Image = Nothing
                    GroupBox2.Enabled = False
                    GroupBox1.Enabled = True
                    GroupBox3.Enabled = True
                    BtnOk.Enabled = True

                    ShowConnect = False
                    If Not AreYouServerExit() Then CheckNetworkConnect()
                    Me.GetListAccounting()
                    If CmbAccount.Items.Count > 0 Then
                        Me.GetListPeriod(CmbAccount.SelectedValue)
                    End If
                    TxtUser.Focus()
                Else
                    BtnConnect.Text = "اتصال"
                    BtnConnect.Image = Nothing
                    TxtAddress.Enabled = True
                    GroupBox1.Enabled = False
                    GroupBox3.Enabled = False
                    BtnOk.Enabled = False
                    MessageBox.Show("ارتباط با سرور مورد نظر برقرار نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LoginForm", "BtnConnect_Click")
                BtnConnect.Text = "اتصال"
                BtnConnect.Image = Nothing
                TxtAddress.Enabled = True
                GroupBox1.Enabled = False
                GroupBox3.Enabled = False
                BtnOk.Enabled = False
                MessageBox.Show("ارتباط با سرور مورد نظر برقرار نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            BtnConnect.Text = "اتصال"
            BtnConnect.Image = Nothing
            TxtAddress.Enabled = True
            GroupBox1.Enabled = False
            GroupBox3.Enabled = False
            BtnOk.Enabled = False
        End If
    End Sub

    Private Function ConnectionTest(ByVal Con_Str As String) As Boolean
        Try
            Application.DoEvents()
            Dim dbconect As New SqlConnection(Con_Str)
            Application.DoEvents()
            dbconect.Open()
            Application.DoEvents()
            Using sqlcom As New SqlCommand("SELECT name FROM sysdatabases", dbconect)
                sqlcom.CommandTimeout = 0
                Dim dtr As SqlDataReader = Nothing
                dtr = sqlcom.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    While dtr.Read
                        If UCase(dtr("name")) = "MANAGE_NAB" Then
                            dbconect.Close()
                            SqlConnection.ClearPool(dbconect)
                            dbconect.Dispose()
                            Return True
                        End If
                    End While
                    dbconect.Close()
                    SqlConnection.ClearPool(dbconect)
                    dbconect.Dispose()
                    Return False
                Else
                    dbconect.Close()
                    SqlConnection.ClearPool(dbconect)
                    dbconect.Dispose()
                    Return False
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub GetListAccounting()
        Try
            Dim ConString As String = String.Format("Data Source={0};Initial Catalog=Manage_Nab;User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0", TxtAddress.Text.Trim)
            ds.Clear()
            Dim sqlcon As New SqlConnection(ConString)
            sqlcon.Open()
            Using CMD As New SqlCommand("SELECT List_Accounting.Id, List_Accounting.NameFarsi FROM List_Accounting ", sqlcon)
                CMD.CommandTimeout = 0
                ds.Load(CMD.ExecuteReader)
            End Using
            sqlcon.Close()
            SqlConnection.ClearPool(sqlcon)
            sqlcon.Dispose()

            CmbAccount.DataSource = ds
            CmbAccount.DisplayMember = "NameFarsi"
            CmbAccount.ValueMember = "ID"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LoginForm", "GetListAccounting")
        End Try
    End Sub

    Private Sub GetListPeriod(ByVal Id As Long)
        Try
            Dim ConString As String = String.Format("Data Source={0};Initial Catalog=Manage_Nab;User ID=" & PublicFunction.UserDB & ";Password=" & PublicFunction.PasswordDB & ";Connection Timeout=0", TxtAddress.Text.Trim)
            dsP.Clear()
            Dim sqlcon As New SqlConnection(ConString)
            sqlcon.Open()
            Using CMD As New SqlCommand(String.Format("SELECT  NameEnglish,PeriodName FROM  List_Period WHERE (Id = {0}) ORDER BY AutoId DESC ", Id), sqlcon)
                CMD.CommandTimeout = 0
                dsP.Load(CMD.ExecuteReader)
            End Using
            sqlcon.Close()
            SqlConnection.ClearPool(sqlcon)
            sqlcon.Dispose()
            CmbPeriod.DataSource = dsP
            CmbPeriod.DisplayMember = "PeriodName"
            CmbPeriod.ValueMember = "NameEnglish"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "LoginForm", "GetListPeriod")
        End Try
    End Sub

    Private Sub CmbAccount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
        If e.KeyCode = Keys.Enter Then
            CmbPeriod.Focus()
        End If
    End Sub

    Private Sub CmbAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Try
            Me.GetListPeriod(CmbAccount.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
        If e.KeyCode = Keys.Enter Then
            TxtUser.Focus()
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnConnect.Enabled = True Then BtnConnect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnOk.Enabled = True Then BtnOk_Click(Nothing, Nothing)
        ElseIf e.Control = True And e.KeyCode = Keys.T Then
            Using frm As New FrmActiveTrial
                frm.ShowDialog()
            End Using
            SetTitle()
        End If
    End Sub

    Private Function GetMD5Open(ByVal strToOpen As Byte()) As String
        Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
        Dim Sec As New Security()
        key.IV = Sec.Kiv
        key.Key = Sec.Kkey
        Return Sec.StringDecrypt(strToOpen, key.CreateDecryptor)
    End Function

    Private Function StrToByteArray(ByVal str As String) As Byte()
        Dim x() As String = str.Split(".")
        Dim x1(x.Length - 1) As Byte
        Try
            For i As Integer = 0 To x.Length - 1
                x1(i) = CByte(x(i))
            Next
            Return x1
        Catch ex As Exception
            MessageBox.Show("شماره سریال نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Trial = ""
            Return x1
        End Try
    End Function

    Private Sub GetTrial()
        Try

            Dim x() As String = My.Settings("Trial").Split("-")
            If Not (x.Length <> 3) Then
                x(0) = x(0).Substring(0, x(0).Length - 1)
                x(1) = x(1).Substring(0, x(1).Length - 1)
                x(2) = x(2).Substring(0, x(2).Length - 1)
                Dim dat As String = String.Format("{0}/{1}/{2}", GetMD5Open(StrToByteArray(x(1))), GetMD5Open(StrToByteArray(x(2))), GetMD5Open(StrToByteArray(x(0))))
                If CheckDate(dat) = False Then
                    MessageBox.Show("شماره سریال نا معتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Trial = ""
                Else
                    If dat < GetDate() Then
                        MessageBox.Show("شماره سریال منسوخ شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Trial = ""
                    Else
                        Trial = dat
                    End If
                End If
            Else
                Trial = ""
            End If
        Catch ex As Exception
            Trial = ""
        End Try
    End Sub

    Private Sub SetTitle()
        GetTrial()
        Dim version() As String
        version = Assembly.GetEntryAssembly().GetName().Version.ToString().Split(".")
        Dim newVersion = version(0) & "." & version(1) & "." & version(2)
        If Trial = "" Then
            lblVer.Text = newVersion
        Else
            lblVer.Text = String.Format("اعتبار تا : {0} Version : {1}", Trial, newVersion)
        End If
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Application.Exit()
    End Sub

    Private Sub TxtAddress_TextChanged(sender As Object, e As EventArgs) Handles TxtAddress.TextChanged

    End Sub

    Private Sub TxtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnConnect_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnShowPass_Click(sender As Object, e As EventArgs) Handles BtnShowPass.Click
        If BtnShowPass.Symbol = "f06e" Then
            BtnShowPass.Symbol = "f070"
            TxtPass.UseSystemPasswordChar = False
        End If
        If BtnShowPass.Symbol = "f070" Then
            BtnShowPass.Symbol = "f06e"
            TxtPass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TxtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnOk_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        TxtUser.Text = TxtUser.Text.Replace("*", "").Replace("?", "").Replace("؟", "").Replace("'", "").Replace("|", "")
        TxtPass.Text = TxtPass.Text.Replace("*", "").Replace("?", "").Replace("؟", "").Replace("'", "").Replace("|", "")

        If String.IsNullOrEmpty(TxtUser.Text.Trim) Then
            MessageBox.Show("نام کاربری را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtUser.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(CmbAccount.Text) Or String.IsNullOrEmpty(CmbPeriod.Text) Then
            MessageBox.Show("اطلاعات دفتر حسابداری وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If
        If String.IsNullOrEmpty(CmbPeriod.Text) Then
            MessageBox.Show("اطلاعات دوره مالی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

        DataSource = Me.SetDataSource(TxtAddress.Text.Trim)
        ConectionBank.ConnectionString = DataSource
        Me.Enabled = False
        If AreYouLoging(TxtUser.Text.Trim, TxtPass.Text.Trim) = False Then
            Me.Enabled = True
            Exit Sub
        End If
        Me.GetPath("SAVE")

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "ورود به سیستم", "ورود", "", "")

        ' Dim Theme As Integer = PublicFunction.GetTheme()
        Me.Enabled = True

        'If Theme = 1 Then
        Dim mfrm As New FrmMain
        Me.Hide()
        mfrm.Show()
        'Else
        '    'Todo Change This Target Page
        '    Dim mfrm As New FrmMain
        '    Me.Hide()
        '    mfrm.Show()
        'End If

    End Sub

    Private Sub TxtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPass.Focus()
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

End Class