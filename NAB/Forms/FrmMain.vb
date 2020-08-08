Imports System.Data.SqlClient
Imports System.IO
Imports Ionic.Zip
Public Class FrmMain
    Public Tim As Date = Now
    Private Sub MNU_Taref_City_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Taref_City.Click
        Try
            Fnew = False
            Using FrmCity As New DefineCity
                FrmCity.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Taref_City_Click")
        End Try
    End Sub

    Private Sub MNU_TBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TBox.Click
        Try
            Fnew = False
            Using FrmBox As New DefineBox
                FrmBox.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TBox_Click")
        End Try
    End Sub

    Private Sub MNU_TSarmayeh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TSarmayeh.Click
        Try
            Fnew = False
            Using Frmsarmayeh As New DefineSarmayeh
                Frmsarmayeh.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TSarmayeh_Click")
        End Try
    End Sub

    Private Sub MNU_TAmval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TAmval.Click
        Try
            Fnew = False
            Using FrmAmval As New DefineAmval
                FrmAmval.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TAmval_Click")
        End Try
    End Sub

    Private Sub MNU_TCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TCharge.Click
        Try
            Fnew = False
            Using FrmCharge As New DefineCharge
                FrmCharge.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TCharge_Click")
        End Try
    End Sub

    Private Sub MNU_TDaramad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TDaramad.Click
        Try
            Fnew = False
            Using Frmdaramad As New DefineDaramad
                Frmdaramad.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TDaramad_Click")
        End Try
    End Sub

    Private Sub MNU_TGroupKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TGroupKala.Click
        Try
            Fnew = False
            Using FrmGroup As New DefineGroup
                FrmGroup.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TGroupKala_Click")
        End Try
    End Sub

    Private Sub MNU_TVahed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TVahed.Click
        Try
            Fnew = False
            Using FrmVahed As New DefineDefine_Vahed
                FrmVahed.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TVahed_Click")
        End Try
    End Sub

    Private Sub MNU_TKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TKala.Click
        Try
            Fnew = False
            Using Frmkala As New DefineKala
                Frmkala.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TKala_Click")
        End Try
    End Sub

    Private Sub MNU_TAnbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TAnbar.Click
        Try
            Fnew = False
            Using FrmAnbar As New DefineAnbar
                FrmAnbar.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TAnbar_Click")
        End Try
    End Sub

    Private Sub MNU_Service_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Service.Click
        Try
            Fnew = False
            Using FrmSRV As New DefineService
                FrmSRV.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Service_Click")
        End Try
    End Sub

    Private Sub BtnCity_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCity.Activate
        Call MNU_Taref_City_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Activate
        Call Define_User_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonChunk4_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonChunk4.Activate

    End Sub

    Private Sub BtnAnbar_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnbar.Activate
        Call MNU_TAnbar_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnGroup_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGroup.Activate
        Call MNU_TGroupKala_Click(Nothing, Nothing)
    End Sub

    Private Sub Button7_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Activate
        Call MNU_TVahed_Click(Nothing, Nothing)
    End Sub

    Private Sub Button2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Activate
        Call MNU_TKala_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnPeople_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPeople.Activate
        Call MNU_TPepole_P_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnBox_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBox.Activate
        Call MNU_TBox_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnBank_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBank.Activate
        Call MNU_TBANK_BANK_Click(Nothing, Nothing)
    End Sub

    Private Sub Btnsarmayeh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsarmayeh.Activate
        Call MNU_TSarmayeh_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnAmval_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAmval.Activate
        Call MNU_TAmval_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnCharge_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCharge.Activate
        Call MNU_TCharge_Click(Nothing, Nothing)
    End Sub

    Private Sub Btndaramad_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndaramad.Activate
        Call MNU_TDaramad_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnService_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnService.Activate
        Call MNU_Service_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
    End Sub

    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
        Dim Sec As New Security()
        key.IV = Sec.Kiv
        key.Key = Sec.Kkey

        If QExit = False Then

            If Not AreYouServerExit() Then
                If MessageBox.Show("آیا برای خروج از برنامه مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If

                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using CMD As New SqlCommand("Update Define_User Set UserLogIn=@UserLogIn WHERE Id=" & Id_User, ConectionBank)
                    CMD.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt("0", key.CreateEncryptor)
                    CMD.ExecuteNonQuery()
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروج", "خروج", "", "")

                SqlConnection.ClearPool(ConectionBank)

                End
            Else
                Dim backPath As String = ""
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Try

                    Using CMD As New SqlCommand("SELECT TOP 1 BackUpPath FROM Define_Company Where IdUser=" & Id_User, ConectionBank)
                        backPath = CMD.ExecuteScalar
                        If String.IsNullOrEmpty(backPath) Then backPath = "C:\"
                    End Using
                Catch ex As Exception
                    backPath = "C:\"
                End Try
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                SqlConnection.ClearPool(ConectionBank)

                Dim result As DialogResult = MessageBox.Show("آيا مي خواهيد از اطلاعات برنامه نسخه پشتيبان بگيرد؟" & vbCrLf & "محل پشتيبان: " & backPath, "سئوال", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If result = DialogResult.Cancel Then
                    e.Cancel = True
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    Try
                        Me.Enabled = False
                        If Directory.Exists(backPath) Then
                            Dim str_path As String = CreatePath(backPath)
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
                                Using CMD As New SqlCommand("BACKUP DATABASE " & dt.Rows(i).Item("NameEnglish") & " TO DISK = N'" & str_path & "\Info" & dt.Rows(i).Item("NameEnglish").ToString.Replace("DBNab", "") & ".BAK'", SqlCon)
                                    CMD.CommandTimeout = 0
                                    CMD.ExecuteNonQuery()
                                End Using
                            Next

                            Using CMD As New SqlCommand("BACKUP DATABASE Manage_Nab TO DISK = N'" & str_path & "\Account.BAK'", SqlCon)
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

                            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروج", "خروج", "", "")
                            Me.Enabled = True

                            MessageBox.Show("عملیات پشتیبان گیری با موفقیت انجام شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else
                            MessageBox.Show("مسير مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Enabled = True
                            e.Cancel = True
                            Exit Sub
                        End If
                    Catch ex As Exception
                        If Err.Number = 5 Then
                            MessageBox.Show("بانک اطلاعات در حال استفاده میباشد و فعلا عملیات پشتیبان گیری امکان پذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmBackUp", "Button2_Click")
                        End If
                        e.Cancel = True
                        Me.Enabled = True
                        Exit Sub
                    End Try

                End If
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروج", "خروج", "", "")
            End If

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("Update Define_User Set UserLogIn=@UserLogIn WHERE Id=" & Id_User, ConectionBank)
                CMD.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt("0", key.CreateEncryptor)
                CMD.ExecuteNonQuery()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            System.Data.SqlClient.SqlConnection.ClearPool(ConectionBank)
            End
        Else
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using CMD As New SqlCommand("Update Define_User Set UserLogIn=@UserLogIn WHERE Id=" & Id_User, ConectionBank)
                CMD.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt("0", key.CreateEncryptor)
                CMD.ExecuteNonQuery()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            System.Data.SqlClient.SqlConnection.ClearPool(ConectionBank)
        End If

    End Sub

    Private Function CreatePath(ByVal path As String) As String
        Try
            Dim t_time As String = String.Format("{0}  {1}", GetDate().Replace("/", "-"), Date.Now.ToLongTimeString.Replace(":", "-"))
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

    Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then Call Ribbon1_HelpRequested(Nothing, Nothing)
        If e.KeyCode = Keys.F2 Then Call MainMenuItem2_Activate(Nothing, Nothing)
        If (e.KeyCode = Keys.F12) Then
            Dim C As New CreateShortcutSPage
            C.ShowDialog()
        End If
    End Sub

    Private Sub MNU_TBANK_BANK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TBANK_BANK.Click
        Try
            Fnew = False
            Using FrmBank As New DefineBank
                FrmBank.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TBank_Click")
        End Try
    End Sub

    Private Sub MenuBank_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBank.Activate
        Call MNU_TBANK_BANK_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_TBANK_OTHER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TBANK_OTHER.Click
        Try
            Fnew = False
            Using FrmBank As New DefineOtherBank
                FrmBank.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TBANK_OTHER_Click")
        End Try
    End Sub

    Private Sub MenuBankOther_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBankOther.Activate
        Call MNU_TBANK_OTHER_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_TPepole_P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TPepole_P.Click
        Try
            Fnew = False
            Using FrmPeople As New DefinePeople
                FrmPeople.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TPepole_P_Click")
        End Try
    End Sub

    Private Sub MenuPeople_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPeople.Activate
        Call MNU_TPepole_P_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_TPepole_Group_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TPepole_Group.Click
        Try
            Fnew = False
            Using FrmPeople As New DefineGroupP
                FrmPeople.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TPepole_Group_Click")
        End Try
    End Sub

    Private Sub MenuGroup_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuGroup.Activate
        Call MNU_TPepole_Group_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_OneTraz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_OneTraz.Click
        Try
            Fnew = False
            Using FrmTraz As New TrazOne
                FrmTraz.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_OneTraz_Click")
        End Try
    End Sub

    Private Sub MenuChkOne_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuChkOne.Activate
        Call ToolStripMenuItem9_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuKalaone_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuKalaone.Activate
        Call ToolStripMenuItem8_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnChkMon_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChkMon.Activate
        Call MNU_OneTraz_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Try
            Fnew = False
            Using FrmKalaOne As New Kala_OneTime
                FrmKalaOne.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaOne_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Try
            Fnew = False
            Using FrmCheckOne As New Check_Ontime
                FrmCheckOne.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ChkeOne_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_CHKSodor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_CHKSodor.Click
        Try
            Fnew = False
            Using FrmManageCheck As New Manage_Chk_Bank
                FrmManageCheck.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_CHKSodor_Click")
        End Try
    End Sub

    Private Sub MenuChkBank_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuChkBank.Activate
        Call MNU_CHKSodor_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Buy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Buy.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(0)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(0)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Buy_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_backBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_backBuy.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(1)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(1)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_backBuy_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_BuyAmani_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_BuyAmani.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(2)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(2)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_BuyAmani_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_SELL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SELL.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(3)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(3)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SELL_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_BackSell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_BackSell.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(4)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(4)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_BackSell_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_SellAmani_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SellAmani.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(5)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(5)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SellAmani_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_PishSell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_PishSell.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(7)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(7)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_PishSell_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub BtnPishSell_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPishSell.Activate
        Call MNU_PishSell_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_ServiceFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ServiceFac.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(8)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(8)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ServiceFac_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub BtnServiceFac_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnServiceFac.Activate
        Call MNU_ServiceFac_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuUser_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUser.Activate
        Call Define_User_Click(Nothing, Nothing)
    End Sub

    Private Sub Define_User_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Define_User.Click
        Try
            Fnew = False
            Using FrmUser As New DefineUser
                FrmUser.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_User_Click")
        End Try
    End Sub

    Private Sub MNU_Visit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Visit.Click
        Try
            Fnew = False
            Using FrmUser As New DefineVisitor
                FrmUser.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Visit_Click")
        End Try
    End Sub

    Private Sub MenuVisit_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVisit.Activate
        Call MNU_Visit_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "کاربر:" & NamUser & "  " & Nam_Account & " : " & Nam_Period
        ShowConnect = True
        SMS = False
        DeleverSMS = False
        QExit = False
        MBank = False
        MBox = False
        MAnbar = False
        GetPublicSetting()
        If Not AreYouServerExit() Then DCW_ConnectChanged(Nothing, Nothing)
        RunInfoSysytem()
    End Sub

    Private Sub MNU_NEWSarfasl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_NEWSarfasl.Click
        Try
            Fnew = False
            Using FrmFactor As New DefineOtherSarFasl
                FrmFactor.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_NEWSarfasl_Click")
        End Try
    End Sub

    Private Sub BtnGetMoney_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetMoney.Activate
        Call MNU_GetMoney_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnPayMoney_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPayMoney.Activate
        Call MNU_PayMoney_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnPTP_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPTP.Activate
        Call MNU_PTP_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnChargeFactor_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChargeFactor.Activate
        Call MNU_WORK_KharidCharge_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnChargeOther_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChargeOther.Activate
        Call MNU_WORK_OtherCharge_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_GetMoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_GetMoney.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(0)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_GetMoney_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_PayMoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_PayMoney.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(1)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_PayMoney_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_PTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_PTP.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(2)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_PTP_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_WORK_OtherCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_WORK_OtherCharge.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(4)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_WORK_OtherCharge_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_WORK_KharidCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_WORK_KharidCharge.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(3)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_WORK_KharidCharge_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_WORK_EditBankBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_WORK_EditBankBox.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(12)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_WORK_EditBankBox_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MenuItem8_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Activate
        Call MNU_WORK_EditBankBox_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuKharid_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuKharid.Activate
        Call MNU_Buy_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuBBUY_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBBUY.Activate
        Call MNU_backBuy_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuBAmani_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBAmani.Activate
        Call MNU_BuyAmani_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuSell_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSell.Activate
        Call MNU_SELL_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuBack_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBack.Activate
        Call MNU_BackSell_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuASell_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuASell.Activate
        Call MNU_SellAmani_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Manage_Chk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Manage_Chk.Click
        Try
            Fnew = False
            Using Frmchk As New Manage_Get_Pay_Chk
                Frmchk.BtnSelect.Enabled = False
                Frmchk.BtnCancel.Enabled = False
                Frmchk.ToolStripStatusLabel6.Visible = False
                Frmchk.ToolStripStatusLabel4.Visible = False
                Frmchk.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Manage_Chk_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub BtnChk_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChk.Activate
        Call MNU_Manage_Chk_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_MoeinPeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MoeinPeople.Click
        Try
            Fnew = False
            Using FrmMoein As New Moein_People
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MoeinPeople_Click")
        End Try
    End Sub

    Private Sub MNU_MoeinBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MoeinBox.Click
        Try
            Fnew = False
            Using FrmMoein As New Moein_BOX
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MoeinBox_Click")
        End Try
    End Sub

    Private Sub MNU_MoeinBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MoeinBank.Click
        Try
            Fnew = False
            Using FrmMoein As New Moein_Bank
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MoeinBank_Click")
        End Try
    End Sub

    Private Sub BtnMpeople_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMpeople.Activate
        Call MNU_MoeinPeople_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnMBox_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMBox.Activate
        Call MNU_MoeinBox_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnMBank_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMBank.Activate
        Call MNU_MoeinBank_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DaftarKol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DaftarKol.Click
        Try
            Fnew = False
            Using FrmMoein As New FrmDaftarKol
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DaftarKol_Click")
        End Try
    End Sub

    Private Sub BtnDaftrKol_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDaftrKol.Activate
        Call MNU_DaftarKol_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnMkalapEople_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMkalapEople.Activate
        Call MNU_MaliKala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_MaliKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MaliKala.Click
        Try
            Fnew = False
            Using FrmMoein As New Moein_KalaPeople
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MaliKala_Click")
        End Try
    End Sub

    Private Sub BtnDaramad2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDaramad2.Activate
        Call MNU_DaramadDay_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnAmval2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAmval2.Activate
        Call MNU_Amvalday_Click(Nothing, Nothing)
    End Sub

    Private Sub Button5_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Activate
        Call MNU_SarmayehDay_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DaramadDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DaramadDay.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(5)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DaramadDay_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_Amvalday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Amvalday.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(6)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Amvalday_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_SarmayehDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SarmayehDay.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(7)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SarmayehDay_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub mnu_tranferkala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_tranferkala.Click
        Try
            Using FrmDay As New FrmAnbarToAnbar
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "mnu_tranferkala_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub BtnTAnbar_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTAnbar.Activate
        Call mnu_tranferkala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_PTF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_PTF.Click
        Try
            Using FrmPTF As New DefinePTF
                FrmPTF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_PTF_Click")
        End Try
    End Sub

    Private Sub MPTF_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MPTF.Activate
        Call MNU_PTF_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_UTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_UTB.Click
        Try
            Using FrmPTF As New DefineUTB
                FrmPTF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_UTB_Click")
        End Try
    End Sub

    Private Sub M_UTB_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M_UTB.Activate
        Call MNU_UTB_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_UTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_UTA.Click
        Try
            Using FrmPTF As New DefineUTA
                FrmPTF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_UTA_Click")
        End Try
    End Sub

    Private Sub M_UTA_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M_UTA.Activate
        Call MNU_UTA_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_ADD_DEC_Box_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ADD_DEC_Box.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(8)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ADD_DEC_Box_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_BOXtBOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_BOXtBOX.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(9)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_BOXtBOX_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_ADD_DEC_Bank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ADD_DEC_Bank.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(10)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ADD_DEC_Bank_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_BANKtBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_BANKtBank.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(11)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_BANKtBank_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub Menu_ADDDECBOX_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_ADDDECBOX.Activate
        Call MNU_ADD_DEC_Box_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Activate
        Call MNU_BOXtBOX_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem3_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Activate
        Call MNU_ADD_DEC_Bank_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem4_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Activate
        Call MNU_BANKtBank_Click(Nothing, Nothing)
    End Sub

    Private Sub MNUKardex_Kala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUKardex_Kala.Click
        Try
            Using FrmDay As New Kardex_Kala
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNUKardex_Kala_Click")
        End Try
    End Sub

    Private Sub MenuItem1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Activate
        Call MNUKardex_Kala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNUMojody_Kala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUMojody_Kala.Click
        Try
            Using FrmDay As New FrmMojodyKala
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNUMojody_Kala_Click")
        End Try
    End Sub

    Private Sub MenuItem9_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Activate
        Call MNUMojody_Kala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_KalaMoney_Kala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KalaMoney_Kala.Click
        Try
            Using FrmDay As New FrmMojodyMoneyKala
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaMoney_Kala_Click")
        End Try
    End Sub

    Private Sub MenuItem11_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Activate
        Call MNU_KalaMoney_Kala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNu_SodNKhales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNu_SodNKhales.Click
        Try
            Using FrmDay As New FrmSodNKhales
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNu_SodNKhales_Click")
        End Try
    End Sub

    Private Sub MNUMojody_Anbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUMojody_Anbar.Click
        Try
            Using FrmDay As New FrmMojodyAnbar
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNUMojody_Anbar_Click")
        End Try
    End Sub

    Private Sub MenuItem10_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Activate
        Call MNUMojody_Anbar_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_KalaMoney_Anbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KalaMoney_Anbar.Click
        Try
            Using FrmDay As New FrmMojodyMoneyAnbar
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaMoney_Anbar_Click")
        End Try
    End Sub

    Private Sub MenuItem12_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Activate
        Call MNU_KalaMoney_Anbar_Click(Nothing, Nothing)
    End Sub

    Private Sub MNUKardex_Anbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUKardex_Anbar.Click
        Try
            Using FrmDay As New Kardex_Anbar
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNUKardex_Anbar_Click")
        End Try
    End Sub

    Private Sub MenuItem5_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Activate
        Call MNUKardex_Anbar_Click(Nothing, Nothing)
    End Sub

    Private Sub Mnu_ReportCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_ReportCharge.Click
        Try
            Using FrmDay As New FrmReport_Charge
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "Mnu_ReportCharge_Click")
        End Try
    End Sub

    Private Sub Button16_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Activate
        Call Mnu_ReportCharge_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_StateChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_StateChk.Click
        Try
            Using FrmDay As New FrmInfoStateMoney
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_StateChk_Click")
        End Try
    End Sub

    Private Sub MNU_MojodyBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MojodyBox.Click
        Try
            Using FrmDay As New FrmMojodyBox
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MojodyBox_Click")
        End Try
    End Sub

    Private Sub MNU_MojodyBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MojodyBank.Click
        Try
            Using FrmDay As New FrmMojodyBank
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MojodyBank_Click")
        End Try
    End Sub

    Private Sub Button20_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Activate
        Call MNU_MojodyBox_Click(Nothing, Nothing)
    End Sub

    Private Sub Button21_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Activate
        Call MNU_MojodyBank_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_State_CHk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_State_CHk.Click
        Try
            Using FrmDay As New FrmPathChk
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_State_CHk")
        End Try
    End Sub

    Private Sub Button23_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Activate
        Call MNU_BalanceKala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Anbar_Buy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Anbar_Buy.Click
        Try
            Using FrmDay As New ReportBuy
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Anbar_Buy_Click")
        End Try
    End Sub

    Private Sub Button9_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Activate
        Call MNU_Anbar_Buy_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Anbar_Sell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Anbar_Sell.Click
        Try
            Using FrmDay As New ReportSell
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Anbar_Sell_Click")
        End Try
    End Sub

    Private Sub Button11_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Activate
        Call MNU_Anbar_Sell_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Anbar_BackBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Anbar_BackBuy.Click
        Try
            Using FrmDay As New ReportBackBuy
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Anbar_BackBuy_Click")
        End Try
    End Sub

    Private Sub Button10_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Activate
        Call MNU_Anbar_BackBuy_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Anbar_BackSell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Anbar_BackSell.Click
        Try
            Using FrmDay As New ReportBackSell
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Anbar_BackSell_Click")
        End Try
    End Sub

    Private Sub Button12_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Activate
        Call MNU_Anbar_BackSell_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Anbar_Service_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Anbar_Service.Click
        Try
            Using FrmDay As New ReportService
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Anbar_Service_Click")
        End Try
    End Sub

    Private Sub Button14_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Activate
        Call MNU_Anbar_Service_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Anbar_Damage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Anbar_Damage.Click
        Try
            Using FrmDay As New ReportDamage
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Anbar_Damage_Click")
        End Try
    End Sub

    Private Sub Button13_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Activate
        Call MNU_Anbar_Damage_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Manage_ControlFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Manage_ControlFactor.Click
        Try
            Using FrmDay As New FrmControMali
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Manage_ControlFactor_Click")
        End Try
    End Sub

    Private Sub MNU_LOWMojody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_LOWMojody.Click
        Try
            Using FrmDay As New FrmLowMojodyKala
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_LOWMojody_Click")
        End Try
    End Sub

    Private Sub MNU_HightMojody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_HightMojody.Click
        Try
            Using FrmDay As New FrmHightMojodyKala
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_HightMojody_Click")
        End Try
    End Sub

    Private Sub MenuItem13_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Activate
        Call MNU_LOWMojody_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem14_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Activate
        Call MNU_HightMojody_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_BalanceKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_BalanceKala.Click
        Try
            Using FrmDay As New FrmBalanceKala
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_BalanceKala_Click")
        End Try
    End Sub

    Private Sub MNU_ActivSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ActivSMS.Click
        Try
            If SMS = False Then
                Try
                    ActiveSMS.Show()
                Catch ex As Exception

                End Try

            Else
                Try
                    ActiveSMS.Show()
                    ActiveSMS.WindowState = FormWindowState.Normal
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ActivSMS_Click")
        End Try
    End Sub

    Private Sub MNU_ONESendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ONESendSMS.Click
        Try
            If SMS = False Then
                MessageBox.Show("فعال نشده است SMS سرویس", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim NewFrm As New SeneSMS
            NewFrm.ShowDialog()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ONESendSMS_Click")
        End Try
    End Sub

    Private Sub MNU_MultiSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MultiSendSMS.Click
        Try
            If SMS = False Then
                MessageBox.Show("فعال نشده است SMS سرویس", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim NewFrm As New SendGlobalSMS
            NewFrm.Show()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MultiSendSMS_Click")
        End Try
    End Sub

    Private Sub Button17_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Activate
        Call MNU_Dramad_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Dramad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Dramad.Click
        Try
            Using FrmDay As New FrmReport_Daramad
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Dramad_Click")
        End Try
    End Sub

    Private Sub Button27_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Activate
        Call MNU_StateChk_Click(Nothing, Nothing)
    End Sub

    Private Sub Button28_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Activate
        Call MNU_State_CHk_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Sarmayeh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Sarmayeh.Click
        Try
            Using FrmDay As New FrmReport_Sarmaeh
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Sarmayeh_Click")
        End Try
    End Sub

    Private Sub Button19_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Activate
        Call MNU_Sarmayeh_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_SumKalaFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SumKalaFac.Click
        Try
            Using FrmDay As New FrmSumKalaFactor
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SumKalaFac_Click")
        End Try
    End Sub

    Private Sub MNU_ReportAmval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ReportAmval.Click
        Try
            Using FrmDay As New FrmReport_Amval
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ReportAmval_Click")
        End Try
    End Sub

    Private Sub Button18_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Activate
        Call MNU_ReportAmval_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_SodKhales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SodKhales.Click
        Try
            Using FrmDay As New ReportsodKha
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SodKhales_Click")
        End Try
    End Sub

    Private Sub ApplicationMenu1_Exit(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplicationMenu1.Exit
        Me.Close()
    End Sub

    Private Sub MainMenuItem1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem1.Activate
        Try
            Using FrmDay As New FrmInfoCompony
                If Not AreYouServerExit() Then FrmDay.Button2.Enabled = False
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem1_Activate")
        End Try
    End Sub

    Private Sub MainMenuItem2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem2.Activate
        Try
            If AreYouServer() Then
                Using FrmDay As New FrmBackUp
                    FrmDay.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem2_Activate")
        End Try
    End Sub
    Public Function AreYouServer() As Boolean
        Try
            Dim Address As String = GetPath()
            If String.IsNullOrEmpty(Address) Then
                MessageBox.Show("آدرس سرور تشخیص داده نشده لطفا از برنامه خارج شده و دوباره امتحان کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

            MessageBox.Show("نسخه پشتیبان فقط در سیستم سرور قابل انجام است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function

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

    Private Sub ApplicationMenu1_ShowOptions(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplicationMenu1.ShowOptions
        Try
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "خروج", "تعویض کاربر", "", "")
            QExit = True
            System.Windows.Forms.Application.Restart()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MNU_DelayFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DelayFactor.Click
        Try
            Using FrmDay As New FrmDelayFactor
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DelayFactor_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub Button30_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Activate
        Call MNu_SodNKhales_Click(Nothing, Nothing)
    End Sub

    Private Sub Button31_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Activate
        Call MNU_SodKhales_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_REPORTGetChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_REPORTGetChk.Click
        Try
            Using FrmDay As New FrmReportGetChk
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_REPORTGetChk_Click")
        End Try
    End Sub

    Private Sub Button24_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Activate
        Call MNU_REPORTGetChk_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_REPORTPayChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_REPORTPayChk.Click
        Try
            Using FrmDay As New FrmReportPayChk
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_REPORTPayChk_Click")
        End Try
    End Sub

    Private Sub Button25_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Activate
        Call MNU_REPORTPayChk_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_ReportBratChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ReportBratChk.Click
        Try
            Using FrmDay As New FrmReportBratChk
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ReportBratChk_Click")
        End Try
    End Sub

    Private Sub Button26_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Activate
        Call MNU_ReportBratChk_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DelaySell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DelaySell.Click
        Try
            Using FrmDay As New FrmLastSell
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DelaySell_Click")
        End Try
    End Sub

    Private Sub MNU_DaftarDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DaftarDay.Click
        Try
            Using FrmDay As New FrmDaftarDay
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DaftarDay_Click")
        End Try
    End Sub

    Private Sub Button33_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Activate
        Call MNU_DaftarDay_Click(Nothing, Nothing)
    End Sub

    Private Sub MainMenuItem3_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem3.Activate
        Try
            Using Frms As New RepairSanad
                Frms.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem3_Activate")
        End Try
    End Sub

    Private Sub MNU_ListCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ListCost.Click
        Try
            Using Frms As New FrmListCostKala
                Frms.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ListCost_Click")
        End Try
    End Sub

    Private Sub MainMenuItem4_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem4.Activate
        Try
            Using Frms As New User_Access
                Frms.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem4_Activate")
        End Try
    End Sub

    Private Sub Button34_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Activate
        Call MNU_Manage_ControlFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button39_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Activate
        Call MNU_DelaySell_Click(Nothing, Nothing)
    End Sub

    Private Sub Button40_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Activate
        Call MNU_ListCost_Click(Nothing, Nothing)
    End Sub

    Private Sub Ribbon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon1.Click

    End Sub

    Private Sub Ribbon1_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles Ribbon1.HelpRequested
        Try
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "راهنمای نرم افزار", "راهنمای نرم افزار", "", "")
            If File.Exists(System.Windows.Forms.Application.StartupPath + "\Help.chm") Then
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "\Help.chm")
            Else
                MessageBox.Show("فایل راهنمای برنامه وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "Ribbon_HelpRequested")
        End Try
    End Sub

    Private Sub MainMenuItem6_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem6.Activate
        Call Ribbon1_HelpRequested(Nothing, Nothing)
    End Sub

    Private Sub MainMenuItem5_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem5.Activate
        Try
            Using Frms As New FrmSetting
                Frms.ShowDialog()
                GetPublicSetting()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem5_Activate")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub Button43_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Activate
        Try
            Shell("CALC.EXE")
        Catch ex As Exception
            MessageBox.Show("ماشین حساب سیستم در دسترس نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button44_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Activate
        Try
            Using FrmRas As New FrmRasChk
                FrmRas.ShowDialog()
            End Using

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "BtnRas_Click")
        End Try
    End Sub

    Private Sub Button45_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Activate
        Try
            Using FrmB As New FrmBackGround
                FrmB.ShowDialog()
            End Using
            GetPublicSetting()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "FrmBackGround")
        End Try
    End Sub

    Private Sub GetPublicSetting()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Try
                Using CMD As New SqlCommand("SELECT [Image], TypeImage,Barcode,S32 FROM Define_User INNER JOIN SettingProgram ON SettingProgram.IdUser =Define_User.Id  WHERE Define_User.Id=" & Id_User, ConectionBank)
                    CMD.CommandTimeout = 0
                    dtr = CMD.ExecuteReader
                End Using
                If dtr.HasRows Then
                    dtr.Read()

                    Dim mstr As New System.IO.MemoryStream()
                    Dim byt() As Byte
                    If dtr("TypeImage") = 0 Then
                        Me.Pic.BackgroundImage = My.Resources.BackGround
                    Else
                        byt = dtr("Image")
                        mstr = New System.IO.MemoryStream(byt)
                        Me.Pic.BackgroundImage = Image.FromStream(mstr)
                    End If
                    'Load S32
                    If dtr("S32") = 0 Then
                        S32 = False
                    Else
                        S32 = True
                    End If
                    '
                    If dtr("Barcode") = True Then

                        BtnBuy.Image = My.Resources.Buy_b
                        MenuKharid.Image = My.Resources.Buy_b

                        ''''''''''''''''''''''''''''''''
                        MenuBBUY.Image = My.Resources.BackBuy_b

                        ''''''''''''''''''''''''''''''''
                        MenuBAmani.Image = My.Resources.BuyAmani_b

                        ''''''''''''''''''''''''''''''''
                        BtnSell.Image = My.Resources.Sell_b
                        MenuSell.Image = My.Resources.Sell_b

                        ''''''''''''''''''''''''''''''''
                        MenuBack.Image = My.Resources.SellBack_b

                        ''''''''''''''''''''''''''''''''
                        MenuASell.Image = My.Resources.SellAmani_b

                        ''''''''''''''''''''''''''''''''
                        BtnDamage.Image = My.Resources.Damage_b
                        MenuItem15.Image = My.Resources.Damage_b

                        ''''''''''''''''''''''''''''''''
                        BtnPishSell.Image = My.Resources.PishSell_b
                    Else
                        BtnBuy.Image = My.Resources.Buy
                        MenuKharid.Image = My.Resources.Buy

                        ''''''''''''''''''''''''''''''''
                        MenuBBUY.Image = My.Resources.BackBuy

                        ''''''''''''''''''''''''''''''''
                        MenuBAmani.Image = My.Resources.BuyAmani

                        ''''''''''''''''''''''''''''''''
                        BtnSell.Image = My.Resources.Sell
                        MenuSell.Image = My.Resources.Sell

                        ''''''''''''''''''''''''''''''''
                        MenuBack.Image = My.Resources.SellBack

                        ''''''''''''''''''''''''''''''''
                        MenuASell.Image = My.Resources.SellAmani

                        ''''''''''''''''''''''''''''''''
                        BtnDamage.Image = My.Resources.Damage
                        MenuItem15.Image = My.Resources.Damage

                        ''''''''''''''''''''''''''''''''
                        BtnPishSell.Image = My.Resources.PishSell
                    End If

                Else
                    Me.Pic.BackgroundImage = My.Resources.BackGround
                End If
                dtr.Close()

            Catch ex As Exception
                dtr.Close()
                Me.BackgroundImage = My.Resources.BackGround
            End Try

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "GetPublicSetting")
        End Try
    End Sub

    Private Sub MNU_damage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_damage1.Click
        Try
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(6)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(6)
                    FrmFactor.LEdit.Text = "0"
                    FrmFactor.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_damage1_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_KasriFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KasriFactor.Click
        Try
            Using FrmListKasri As New FrmListKasriFactor
                FrmListKasri.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KasriFactor_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MenuItem16_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Activate
        Call MNU_KasriFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem15_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Activate
        Call MNU_damage1_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_UserFrosh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MNU_TwoTraz_T_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TwoTraz_T.Click
        Try
            Using FrmDay As New TrazTwo
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TwoTraz_Click")
        End Try
    End Sub

    Private Sub MNU_TrazTwo_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TrazTwo_4.Click
        Try
            Using FrmDay As New Traz4Column
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TrazTwo_4_Click")
        End Try
    End Sub

    Private Sub MenuItem19_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Activate
        Call MNU_TwoTraz_T_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem22_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Activate
        Call MNU_TrazTwo_4_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_TrazTwo_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TrazTwo_2.Click
        Try
            Using FrmDay As New Traz2Column
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TrazTwo_4_Click")
        End Try
    End Sub

    Private Sub MenuItem21_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem21.Activate
        Call MNU_TrazTwo_2_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DefinePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DefinePart.Click
        Try
            Using FrmDay As New DefinePart
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DefinePart_Click")
        End Try
    End Sub

    Private Sub MenuItem20_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Activate
        Call MNU_DefinePart_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem23_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Activate
        Call MNU_SODFACTOR1_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_SODFACTOR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SODFACTOR1.Click
        Try
            Using FrmDay As New SodFactor
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SODFACTOR1_Click")
        End Try
    End Sub

    Private Sub MNU_SODFACTOR2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SODFACTOR2.Click
        Try
            Using FrmDay As New SodFactor2
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SODFACTOR2_Click")
        End Try
    End Sub

    Private Sub MenuItem24_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Activate
        Call MNU_SODFACTOR2_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_ExitFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ExitFactor.Click
        Try
            Using FrmExit As New FrmExitFactor
                FrmExit.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ExitFactor_Click")
        End Try
    End Sub

    Private Sub Button46_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Activate
        Call MNU_ExitFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Driver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Driver.Click
        Try
            Fnew = False
            Using FrmMoein As New Define_Driver
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Driver_Click")
        End Try
    End Sub

    Private Sub MenuItem25_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Activate
        Call MNU_Driver_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem26_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem26.Activate
        Call MNU_KalaAndCostCity_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_KalaAndCostCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KalaAndCostCity.Click
        Try
            Fnew = False
            Using FrmMoein As New DefineCostKala
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaAndCostCity_Click")
        End Try
    End Sub

    Private Sub MNU_KalaDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KalaDiscount.Click
        Try
            Fnew = False
            Using FrmMoein As New DefineKalaDiscount
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaDiscount_Click")
        End Try
    End Sub

    Private Sub MenuItem28_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Activate
        Call MNU_KalaDiscount_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DarsadRisk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DarsadRisk.Click
        Try
            Fnew = False
            Using FrmMoein As New FrmRisk
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DarsadRisk_Click")
        End Try
    End Sub

    Private Sub Button47_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Activate
        Call MNU_DarsadRisk_Click(Nothing, Nothing)
    End Sub

    Private Sub HLink_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{F2}")
    End Sub

    Private Sub MNU_Promotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Promotion.Click
        Try
            Using FrmMoein As New FrmListPromotion
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Promotion_Click")
        End Try
    End Sub

    Private Sub MenuItem27_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem27.Activate
        Call MNU_Promotion_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DelayExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DelayExit.Click
        Try
            Using FrmMoein As New FrmReportInfoExit
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DelayExit_Click")
        End Try
    End Sub

    Private Sub Button48_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Activate
        Call MNU_DelayExit_Click(Nothing, Nothing)
    End Sub

    Private Sub Button50_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Activate
        Try
            Using FrmRas As New FrmSodBanki
                FrmRas.ShowDialog()
            End Using

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "SodBanki_Click")
        End Try
    End Sub

    Private Sub MNU_KalaBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KalaBarcode.Click
        Try
            Using FrmRVF As New Report_Kala_BarCode
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaBarcode_Click")
        End Try
    End Sub

    Private Sub Button15_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Activate
        Call MNU_KalaBarcode_Click(Nothing, Nothing)
    End Sub

    Private Sub Mnu_ReportFroshUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_ReportFroshUser.Click
        Try
            Using FrmDay As New FrmReportFroshUser
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "Mnu_ReportFroshUser_Click")
        End Try
    End Sub

    Private Sub Mnu_ReportFroshVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_ReportFroshVisitor.Click
        Try
            Using FrmDay As New FrmReportFroshVisitor
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "Mnu_ReportFroshVisitor_Click")
        End Try
    End Sub

    Private Sub MNU_ReportFroshAllUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ReportFroshAllUser.Click
        Try
            Using Frms As New ReportFroshAllUser
                Frms.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ReportFroshAllUser_Click")
        End Try
    End Sub

    Private Sub MNU_ReportFroshAllVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ReportFroshAllVisitor.Click
        Try
            Using Frms As New ReportFroshAllVisitor
                Frms.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ReportFroshAllVisitor_Click")
        End Try
    End Sub

    Private Sub MNU_ReportPathPeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ReportPathPeople.Click
        Try
            Using FrmPathP As New FrmPathPeople
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ReportPathPeople_Click")
        End Try
    End Sub

    Private Sub Button51_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Activate
        Call Mnu_ReportFroshUser_Click(Nothing, Nothing)
    End Sub

    Private Sub Button52_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Activate
        Call Mnu_ReportFroshVisitor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button53_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button53.Activate
        Call MNU_ReportFroshAllUser_Click(Nothing, Nothing)
    End Sub

    Private Sub Button54_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button54.Activate
        Call MNU_ReportFroshAllVisitor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button55_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button55.Activate
        Call MNU_ReportPathPeople_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_Goal_Visitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Goal_Visitor.Click
        Try
            Using FrmPathP As New FrmGoalVisitor
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Goal_Visitor_Click")
        End Try
    End Sub

    Private Sub Button35_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Activate
        Call MNU_Goal_Visitor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button38_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Activate
        Call MNU_DelayFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button37_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Activate
        Call MNU_SumKalaFac_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_manageBazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_manageBazar.Click
        Try
            Using FrmPathP As New FrmManageFrosh
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_manageBazar_Click")
        End Try
    End Sub

    Private Sub Button36_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Activate
        Call MNU_manageBazar_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_CHART_CHARGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_CHART_CHARGE.Click
        Try
            Using FrmPathP As New FrmChart_Charge
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_CHART_CHARGE_Click")
        End Try
    End Sub

    Private Sub MNU_CHART_DARAMAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_CHART_DARAMAD.Click
        Try
            Using FrmPathP As New FrmChart_Daramad
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_CHART_DARAMAD_Click")
        End Try
    End Sub

    Private Sub MNU_CHART_AMVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_CHART_AMVAL.Click
        Try
            Using FrmPathP As New FrmChart_Amval
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_CHART_AMVAL_Click")
        End Try
    End Sub

    Private Sub MNU_CHART_SARMAYEH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_CHART_SARMAYEH.Click
        Try
            Using FrmPathP As New FrmChart_Sarmayeh
                FrmPathP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_CHART_SARMAYEH_Click")
        End Try
    End Sub

    Private Sub Button41_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Activate
        Call MNU_CHART_CHARGE_Click(Nothing, Nothing)
    End Sub

    Private Sub Button42_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Activate
        Call MNU_CHART_DARAMAD_Click(Nothing, Nothing)
    End Sub

    Private Sub Button49_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Activate
        Call MNU_CHART_AMVAL_Click(Nothing, Nothing)
    End Sub

    Private Sub Button56_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button56.Activate
        Call MNU_CHART_SARMAYEH_Click(Nothing, Nothing)
    End Sub

    Private Sub MainMenuItem7_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem7.Activate
        Try
            If Not UCase(NamUser) = "ADMIN" Then
                MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If AreYouServerExit() Then
                Using Frms As New FrmEndAccounting
                    Frms.ShowDialog()
                End Using
            Else
                MessageBox.Show("بستن دوره مالی فقط در سیستم سرور قابل انجام است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem7_Activate")
        End Try
    End Sub

    Private Sub FrmChartFroshOstan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrmChartFroshOstan.Click
        Using FrmChartF As New FrmChartFroshOstan
            FrmChartF.ShowDialog()
        End Using
    End Sub

    Private Sub MenuItem31_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem31.Activate
        Call FrmChartFroshOstan_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmChartFroshCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrmChartFroshCity.Click
        Using FrmChartFC As New FrmChartFroshCity
            FrmChartFC.ShowDialog()
        End Using
    End Sub

    Private Sub FrmChartFroshPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrmChartFroshPart.Click
        Using FrmChartFP As New FrmChartFroshPart
            FrmChartFP.ShowDialog()
        End Using
    End Sub

    Private Sub MenuItem32_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem32.Activate
        Call FrmChartFroshCity_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem33_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem33.Activate
        Call FrmChartFroshPart_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_StateUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_StateUser.Click
        Using FrmStateAllU As New ReportFroshStateUser
            FrmStateAllU.ShowDialog()
        End Using
    End Sub

    Private Sub MNU_StateVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_StateVisitor.Click
        Using FrmStateAllV As New ReportStateAllVisitor
            FrmStateAllV.ShowDialog()
        End Using
    End Sub

    Private Sub Button59_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button59.Activate
        Call MNU_StateVisitor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button58_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button58.Activate
        Call MNU_StateUser_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_SManageFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_SManageFactor.Click
        Try
            Fnew = False
            Using FrmFactor As New ManageFactor
                FrmFactor.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_SManageFactor_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_MoManageFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_MoManageFactor.Click
        Try
            Fnew = False
            Using FrmFactor As New Mobile_ManageFactor
                FrmFactor.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_MoManageFactor_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MenuItem34_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem34.Activate
        Call MNU_SManageFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem35_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem35.Activate
        Call MNU_MoManageFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_TmpPeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TmpPeople.Click
        Try
            Fnew = False
            Using FrmFactor As New Mobile_ListPeople
                FrmFactor.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TmpPeople_Click")
        End Try
    End Sub

    Private Sub MenuItem36_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem36.Activate
        Call MNU_TmpPeople_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_ReportDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ReportDiscount.Click
        Try
            Using FrmDis As New FrmDiscount
                FrmDis.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ReportDiscount_Click")
        End Try
    End Sub

    Private Sub Button60_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button60.Activate
        Call MNU_ReportDiscount_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_DelayPeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_DelayPeople.Click
        Try
            Using FrmDP As New FrmDelayPeople
                FrmDP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_DelayPeople_Click")
        End Try
    End Sub

    Private Sub Button61_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button61.Activate
        Call MNU_DelayPeople_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_ChartGetChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ChartGetChk.Click
        Try
            Using FrmDP As New FrmChartGetChk
                FrmDP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ChartGetChk_Click")
        End Try
    End Sub

    Private Sub MNU_ChartPayChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ChartPayChk.Click
        Try
            Using FrmDP As New FrmChartPayChk
                FrmDP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_ChartPayChk_Click")
        End Try
    End Sub

    Private Sub MenuItem37_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem37.Activate
        Call MNU_ChartGetChk_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem38_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem38.Activate
        Call MNU_ChartPayChk_Click(Nothing, Nothing)
    End Sub

    Private Sub MainMenuItem8_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem8.Activate
        Try
            If Not UCase(NamUser) = "ADMIN" Then
                MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Using FrmDP As New FrmTraceUser
                FrmDP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem8_Activate")
        End Try
    End Sub

    Private Sub MNU_Visitor_OneGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Visitor_OneGroup.Click
        Try
            Using FrmRVF As New RelationListVisitorFrosh_One
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Visitor_OneGroup_Click")
        End Try
    End Sub

    Private Sub MNU_Visitor_TwoGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Visitor_TwoGroup.Click
        Try
            Using FrmRVF As New RelationListVisitorFrosh_Two
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Visitor_TwoGroup_Click")
        End Try
    End Sub

    Private Sub MNU_Visitor_Kala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Visitor_Kala.Click
        Try
            Using FrmRVF As New RelationListVisitorFrosh
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Visitor_Kala_Click")
        End Try
    End Sub

    Private Sub MNU_User_OneGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_User_OneGroup.Click
        Try
            Using FrmRVF As New RelationListUserFrosh_One
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_User_OneGroup_Click")
        End Try
    End Sub

    Private Sub MNU_User_TwoGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_User_TwoGroup.Click
        Try
            Using FrmRVF As New RelationListUserFrosh_Two
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_User_TwoGroup_Click")
        End Try
    End Sub

    Private Sub MNU_User_Kala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_User_Kala.Click
        Try
            Using FrmRVF As New RelationListUserFrosh
                FrmRVF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_User_Kala_Click")
        End Try
    End Sub

    Private Sub MenuItem42_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem42.Activate
        Call MNU_Visitor_OneGroup_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem43_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem43.Activate
        Call MNU_Visitor_TwoGroup_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem44_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem44.Activate
        Call MNU_Visitor_Kala_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem17_Activate_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Activate
        Call MNU_User_OneGroup_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem18_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Activate
        Call MNU_User_TwoGroup_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem29_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem29.Activate
        Call MNU_User_Kala_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_KalaRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_KalaRate.Click
        Try
            Fnew = False
            Using FrmMoein As New DefineKalaRate
                FrmMoein.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_KalaRate_Click")
        End Try
    End Sub

    Private Sub MenuItem30_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Activate
        Call MNU_KalaRate_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem45_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem45.Activate
        Call MNU_EditMoein_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_EditMoein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_EditMoein.Click
        Try
            Using FrmDay As New FrmGetPay
                FrmDay.CmbSanad.Text = FrmDay.CmbSanad.Items(13)
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_EditMoein_Click")
        End Try
        RunInfoSysytem()
    End Sub

    Private Sub MNU_TraceKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_TraceKala.Click
        Try
            Using FrmDay As New FrmTraceRate
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TraceKala_Click")
        End Try
    End Sub

    Private Sub Button63_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button63.Activate
        Call MNU_TraceKala_Click(Nothing, Nothing)
    End Sub

    Private Sub MainMenuItem9_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuItem9.Activate
        Try
            Using FrmDP As New FrmMessageCenter
                FrmDP.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MainMenuItem9_Activate")
        End Try
        RunInfoSysytem()
    End Sub
    Private Sub RunInfoSysytem()
        Try
            LGetChk.Visible = False
            LPayChk.Visible = False
            LMessage.Visible = False
            LLF.Visible = False
            LHF.Visible = False
            LBed.Visible = False
            LBes.Visible = False
            GetInfoSystem()
            If Not (String.IsNullOrEmpty(StrBed) And String.IsNullOrEmpty(StrBes)) And BW2.IsBusy = False Then BW2.RunWorkerAsync()
            If Not (String.IsNullOrEmpty(StrLF) And String.IsNullOrEmpty(StrHF)) And BW1.IsBusy = False Then BW1.RunWorkerAsync()
            If Not (String.IsNullOrEmpty(StrGetChk) And String.IsNullOrEmpty(StrPayChk) And BW.IsBusy = False And String.IsNullOrEmpty(StrMessage)) Then BW.RunWorkerAsync()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "RunInfoSysytem")
        End Try
    End Sub

    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        LGetChk.Visible = False
        LPayChk.Visible = False
        LMessage.Visible = False
        Dim newcon As New SqlConnection(DataSource)
        Try
            If newcon.State <> ConnectionState.Open Then newcon.Open()
            '''''''''''''''''''''''چک دریافتی
            If Not (String.IsNullOrEmpty(StrGetChk)) Then
                Dim CChk As Long = 0
                Using cmd As New SqlCommand(StrGetChk, newcon)
                    cmd.CommandTimeout = 0
                    CChk = cmd.ExecuteScalar()
                End Using
                If CChk > 0 Then
                    LGetChk.Text = "چک دریافتی (" & CChk & ")"
                    LGetChk.Visible = True
                End If
            End If

            '''''''''''''''''''''''چک پرداختی
            If Not (String.IsNullOrEmpty(StrPayChk)) Then
                Dim CChk As Long = 0
                Using cmd As New SqlCommand(StrPayChk, newcon)
                    cmd.CommandTimeout = 0
                    CChk = cmd.ExecuteScalar()
                End Using
                If CChk > 0 Then
                    LPayChk.Text = "چک پرداختی (" & CChk & ")"
                    LPayChk.Visible = True
                End If
            End If

            '''''''''''''''''''''''پیام دریافتی
            If Not (String.IsNullOrEmpty(StrMessage)) Then
                Dim CChk As Long = 0
                Using cmd As New SqlCommand(StrMessage, newcon)
                    cmd.CommandTimeout = 0
                    CChk = cmd.ExecuteScalar()
                End Using
                If CChk > 0 Then
                    LMessage.Text = "پیام دریافتی (" & CChk & ")"
                    LMessage.Visible = True
                End If
            End If
            If newcon.State <> ConnectionState.Closed Then newcon.Close()
        Catch ex As Exception
            If newcon.State <> ConnectionState.Closed Then newcon.Close()
            'GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "BW_DoWork")
        End Try
    End Sub

    Private Sub BW1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW1.DoWork
        LLF.Visible = False
        LHF.Visible = False
        Dim newcon2 As New SqlConnection(DataSource)

        Try
            If newcon2.State <> ConnectionState.Open Then newcon2.Open()
            '''''''''''''''''''''''حداقل نقطه سفارش
            If Not (String.IsNullOrEmpty(StrLF)) Then
                Dim CChk As Long = 0
                Using cmd As New SqlCommand(StrLF, newcon2)
                    cmd.CommandTimeout = 0
                    CChk = cmd.ExecuteScalar()
                End Using
                If CChk > 0 Then
                    LLF.Text = "حداقل نقطه سفارش (" & CChk & ")"
                    LLF.Visible = True
                End If
            End If

            '''''''''''''''''''''''حداکثر نقطه سفارش
            If Not (String.IsNullOrEmpty(StrHF)) Then
                Dim CChk As Long = 0
                Using cmd As New SqlCommand(StrHF, newcon2)
                    cmd.CommandTimeout = 0
                    CChk = cmd.ExecuteScalar()
                End Using
                If CChk > 0 Then
                    LHF.Text = "حداکثر نقطه سفارش (" & CChk & ")"
                    LHF.Visible = True
                End If
            End If

            If newcon2.State <> ConnectionState.Closed Then newcon2.Close()

        Catch ex As Exception
            If newcon2.State <> ConnectionState.Closed Then newcon2.Close()
            'GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "BW1_DoWork")
        End Try
    End Sub

    Private Sub BW2_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW2.DoWork
        LBed.Visible = False
        LBes.Visible = False
        Dim newcon3 As New SqlConnection(DataSource)

        Try
            If newcon3.State <> ConnectionState.Open Then newcon3.Open()
            '''''''''''''''''''''''وعده بدهکاران
            If Not (String.IsNullOrEmpty(StrBed)) Then
                Dim CChk As Long = 0
                Dim dt As New DataTable
                Dim dv As DataView
                Using cmd As New SqlCommand(StrBed, newcon3)
                    cmd.CommandTimeout = 0
                    dt.Load(cmd.ExecuteReader())
                End Using
                '/////////////////
                If Not dt.Columns.Contains("EndDate") Then dt.Columns.Add("EndDate", Type.GetType("System.String"))
                If Not dt.Columns.Contains("TimeRemain") Then dt.Columns.Add("TimeRemain", Type.GetType("System.Int32"))
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item("EndDate") = CalDate(dt.Rows(i).Item("D_date"), dt.Rows(i).Item("Rate"), dt.Rows(i).Item("MaxNewDate"))
                    dt.Rows(i).Item("TimeRemain") = SUBDAY(dt.Rows(i).Item("EndDate"), GetDate())
                Next
                dv = dt.DefaultView
                dv.RowFilter = "TimeRemain=0"
                CChk = dv.Count
                '/////////////////
                If CChk > 0 Then
                    LBed.Text = "وعده بدهکاران (" & CChk & ")"
                    LBed.Visible = True
                End If
            End If

            '''''''''''''''''''''''وعده بستانکاران
            If Not (String.IsNullOrEmpty(StrBes)) Then
                Dim CChk As Long = 0
                Dim dt As New DataTable
                Dim dv As DataView
                Using cmd As New SqlCommand(StrBes, newcon3)
                    cmd.CommandTimeout = 0
                    dt.Load(cmd.ExecuteReader())
                End Using
                '/////////////////
                If Not dt.Columns.Contains("EndDate") Then dt.Columns.Add("EndDate", Type.GetType("System.String"))
                If Not dt.Columns.Contains("TimeRemain") Then dt.Columns.Add("TimeRemain", Type.GetType("System.Int32"))
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item("EndDate") = CalDate(dt.Rows(i).Item("D_date"), dt.Rows(i).Item("Rate"), dt.Rows(i).Item("MaxNewDate"))
                    dt.Rows(i).Item("TimeRemain") = SUBDAY(dt.Rows(i).Item("EndDate"), GetDate())
                Next
                dv = dt.DefaultView
                dv.RowFilter = "TimeRemain=0"
                CChk = dv.Count
                '/////////////////
                If CChk > 0 Then
                    LBes.Text = "وعده بستانکاران (" & CChk & ")"
                    LBes.Visible = True
                End If
            End If

            If newcon3.State <> ConnectionState.Closed Then newcon3.Close()

        Catch ex As Exception
            If newcon3.State <> ConnectionState.Closed Then newcon3.Close()
            ' GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "BW2_DoWork")
        End Try
    End Sub

    Private Function CalDate(ByVal Dat As String, ByVal Count As Long, ByVal NewDat As String) As String
        Try
            For i As Integer = 1 To Count
                Dat = ADDDAY(Dat)
            Next
            If String.IsNullOrEmpty(NewDat) Then
                Return Dat
            Else
                If Dat >= NewDat Then
                    Return Dat
                Else
                    Return NewDat
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub LGetChk_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LGetChk.Activate
        Call MNU_Manage_Chk_Click(Nothing, Nothing)
    End Sub

    Private Sub LPayChk_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LPayChk.Activate
        Call MNU_Manage_Chk_Click(Nothing, Nothing)
    End Sub

    Private Sub LMessage_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LMessage.Activate
        Call MainMenuItem9_Activate(Nothing, Nothing)
    End Sub

    Private Sub LLF_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLF.Activate
        Call MNU_LOWMojody_Click(Nothing, Nothing)
    End Sub

    Private Sub LHF_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LHF.Activate
        Call MNU_HightMojody_Click(Nothing, Nothing)
    End Sub

    Private Sub LBed_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBed.Activate
        Call MNU_DelayFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub LBes_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBes.Activate
        Call MNU_DelayFactor_Click(Nothing, Nothing)
    End Sub

    Private Sub Button64_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button64.Activate
        ''Process.Start("http://www.Nab-System.com")
        'Using frm As New CreateShortcutSPage
        'frm.ShowDialog()
        'End Using
    End Sub

    Private Sub Button65_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button65.Activate
        Try
            Using FrmB As New FrmLanguageSetting
                FrmB.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "FrmLanguageSetting")
        End Try
    End Sub

    Private Sub MNU_Mobile_Click(sender As Object, e As EventArgs) Handles MNU_Mobile.Click
        Try
            Using FrmB As New Frm_Mobile_Imei
                FrmB.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_Mobile_Click")
        End Try
    End Sub

    Private Sub MenuItem46_Activate(sender As Object, e As EventArgs) Handles MenuItem46.Activate
        Call MNU_Mobile_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_VTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_VTP.Click
        Try
            Using FrmB As New DefineVTP
                FrmB.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_VTP_Click")
        End Try
    End Sub

    Private Sub MenuItem47_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem47.Activate
        Call MNU_VTP_Click(Nothing, Nothing)
    End Sub

    Private Sub MNU_TolidFormul_Click(sender As Object, e As EventArgs) Handles MNU_TolidFormul.Click
        Try
            Using FrmPTF As New FrmFormulasList
                FrmPTF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "MNU_TolidFormul_Click")
        End Try
    End Sub

    Private Sub Button66_Activate(sender As Object, e As EventArgs) Handles Button66.Activate
        Call MNU_TolidFormul_Click(Nothing, Nothing)
    End Sub

    Private Sub Mnu_Production_Click(sender As Object, e As EventArgs) Handles Mnu_Production.Click
        Try
            Using FrmPTF As New FrmMeldProduction
                FrmPTF.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMain", "Mnu_Production_Click")
        End Try
    End Sub

    Private Sub Button67_Activate(sender As Object, e As EventArgs) Handles Button67.Activate
        Call Mnu_Production_Click(Nothing, Nothing)
    End Sub
End Class
