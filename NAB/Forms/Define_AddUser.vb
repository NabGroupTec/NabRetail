Imports System.Data.SqlClient
Imports System.Transactions
Public Class Define_AddUser
    Public edt As Integer
    Public str_name As String

    Private Sub Define_AddUser_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Txtname.Focus()
    End Sub
    Private Sub Define_AddUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Function AreYouAdd(ByVal nam As String) As Boolean
        Dim T_ds As New DataSet
        Dim T_str As String = "select nam  from Define_User"
        Dim T_dta As New SqlDataAdapter(T_str, DataSource)
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_User")
        Dim dr() As DataRow = T_ds.Tables("Define_User").Select("nam ='" & nam & "'")
        If dr.Length <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouAddEdit(ByVal nam As String) As Boolean
        Dim T_ds As New DataSet
        Dim T_str As String = "select nam  from Define_User"
        Dim T_dta As New SqlDataAdapter(T_str, DataSource)
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_User")
        Dim dr() As DataRow = T_ds.Tables("Define_User").Select("nam ='" & nam & "'")
        If dr.Length >= 1 Then
            If (dr(0).Item("nam") <> Txtname.Text) Or (dr(0).Item("nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then TxtP.Focus()
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtname.LostFocus
        Dim str As String = ""
        str = Txtname.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        Txtname.Text = str
    End Sub

    Private Sub TxtP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtP.KeyDown
        If e.KeyCode = Keys.Enter Then cmdsave.Focus()
    End Sub

    Private Sub TxtP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtP.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "User.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdsave.Enabled = True Then Call cmdsave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdcan.Enabled = True Then Call cmdcan_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        If Trim(Txtname.Text) = "" Then
            MessageBox.Show("نام کاربر را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txtname.Focus()
            Exit Sub
        End If

        If Trim(TxtP.Text) = "" Then
            MessageBox.Show("کلمه عبور را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtP.Focus()
            Exit Sub
        End If
        Txtname.Text = Txtname.Text.Trim
        '''''''''''''''''''''''''''''''''''''''''''''''
        If edt = 0 Then
            If Not Me.AreYouAdd(Txtname.Text) Then
                MessageBox.Show("کاربر مورد نظر تکراری است لطفا جهت تغيير از ويرايش استفاده كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If Not Me.AreYouAddEdit(Txtname.Text) Then
                MessageBox.Show("کاربر مورد نظر تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If


        If edt = 0 Then
            Me.SaveUser()
        Else
            Me.EditUser()
        End If

    End Sub

    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        Me.Close()
    End Sub
    Private Sub SaveUser()
        Dim sqltransaction As New CommittableTransaction
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            Dim id As Long = 0

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using cmd As New SqlCommand("INSERT INTO Define_User (Nam,TypeImage,Image,Pas,UserLogIn) VALUES(@Nam,@TypeImage,@Image,@Pas,@UserLogIn);SELECT @@IDENTITY", ConectionBank)
                cmd.Parameters.AddWithValue("@Nam", SqlDbType.NVarChar).Value = Txtname.Text.Trim
                cmd.Parameters.AddWithValue("@TypeImage", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = System.Data.SqlTypes.SqlBinary.Null
                cmd.Parameters.AddWithValue("@Pas", SqlDbType.VarBinary).Value = Sec.StringEncrypt(TxtP.Text, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@UserLogIn", SqlDbType.VarBinary).Value = Sec.StringEncrypt("0", key.CreateEncryptor)
                id = cmd.ExecuteScalar
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using cmd As New SqlCommand("INSERT INTO SettingProgram (FactorPaper,TypeFactor,FactorCount,AnbarCount,Get_Pay_Count,FilterKala,TypeKala,FilterP,TypeP,TypeAll,MojodyBox,MojodyBank,MojodyAnbar,S1,S2,S3,S4,S5,S6,S7,S8,S9,S10,S11,S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S22,S23,S24,S25,S26,S27,S28,IdUser,Barcode,IdAnbar,KalaDup,Fish,S32) VALUES (@FactorPaper,@TypeFactor,@FactorCount,@AnbarCount,@Get_Pay_Count,@FilterKala,@TypeKala,@FilterP,@TypeP,@TypeAll,@MojodyBox,@MojodyBank,@MojodyAnbar,@S1,@S2,@S3,@S4,@S5,@S6,@S7,@S8,@S9,@S10,@S11,@S12,@S13,@S14,@S15,@S16,@S17,@S18,@S19,@S20,@S21,@S22,@S23,@S24,@S25,@S26,@S27,@S28,@IdUser,@Barcode,@IdAnbar,@KalaDup,@Fish,@32)", ConectionBank)
                cmd.Parameters.AddWithValue("@FactorPaper", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@TypeFactor", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@FactorCount", SqlDbType.Int).Value = 1
                cmd.Parameters.AddWithValue("@AnbarCount", SqlDbType.Int).Value = 1
                cmd.Parameters.AddWithValue("@Get_Pay_Count", SqlDbType.Int).Value = 1
                cmd.Parameters.AddWithValue("@FilterKala", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@TypeKala", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@FilterP", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@TypeP", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@TypeAll", SqlDbType.Int).Value = 0
                cmd.Parameters.AddWithValue("@MojodyBox", SqlDbType.Bit).Value = ChkMojodyBox.CheckState
                cmd.Parameters.AddWithValue("@MojodyBank", SqlDbType.Bit).Value = ChkMojodyBank.CheckState
                cmd.Parameters.AddWithValue("@MojodyAnbar", SqlDbType.Bit).Value = ChkMojodyAnbar.CheckState
                cmd.Parameters.AddWithValue("@S1", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S2", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S3", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S4", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S5", SqlDbType.NVarChar).Value = 1
                cmd.Parameters.AddWithValue("@S6", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S7", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S8", SqlDbType.NVarChar).Value = If(ChkEdit.Checked = True, NumDayEdit.Value, 0)
                cmd.Parameters.AddWithValue("@S9", SqlDbType.NVarChar).Value = If(ChkDel.Checked = True, NumDayDel.Value, 0)
                cmd.Parameters.AddWithValue("@S10", SqlDbType.NVarChar).Value = ChkMonFac.CheckState
                cmd.Parameters.AddWithValue("@S11", SqlDbType.NVarChar).Value = ChkDec.CheckState
                cmd.Parameters.AddWithValue("@S12", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S13", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S14", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S15", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S16", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S17", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S18", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S19", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S20", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S21", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@S22", SqlDbType.NVarChar).Value = ChkAdd.CheckState
                cmd.Parameters.AddWithValue("@S23", SqlDbType.NVarChar).Value = ChkHajm.CheckState
                cmd.Parameters.AddWithValue("@S24", SqlDbType.NVarChar).Value = ChkPrivate.CheckState
                cmd.Parameters.AddWithValue("@S25", SqlDbType.NVarChar).Value = ChkDate.CheckState
                cmd.Parameters.AddWithValue("@S26", SqlDbType.NVarChar).Value = ChkNoSell.CheckState
                cmd.Parameters.AddWithValue("@S27", SqlDbType.NVarChar).Value = "100100000010"
                cmd.Parameters.AddWithValue("@S28", SqlDbType.NVarChar).Value = 0
                cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = id
                cmd.Parameters.AddWithValue("@Barcode", SqlDbType.Bit).Value = False
                cmd.Parameters.AddWithValue("@Idanbar", SqlDbType.BigInt).Value = DBNull.Value
                cmd.Parameters.AddWithValue("@KalaDup", SqlDbType.Bit).Value = False
                cmd.Parameters.AddWithValue("@Fish", SqlDbType.Bit).Value = False
                cmd.Parameters.AddWithValue("@32", SqlDbType.Bit).Value = Chk_RegeditFactor.CheckState
                cmd.ExecuteNonQuery()
            End Using

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using cmd As New SqlCommand("INSERT INTO Define_Company(CompanyName,IdCompany,TelFax,[Address],Header,Footer,BackUpPath,CompanyImage,IdUser) VALUES ((SELECT TOP 1 CompanyName FROM Define_Company),(SELECT TOP 1 IdCompany FROM Define_Company),(SELECT TOP 1 TelFax FROM Define_Company),(SELECT TOP 1 [Address] FROM Define_Company),(SELECT TOP 1 Header FROM Define_Company),(SELECT TOP 1 Footer FROM Define_Company),(SELECT TOP 1 BackUpPath FROM Define_Company),(SELECT TOP 1 CompanyImage FROM Define_Company),@IdUser)", ConectionBank)
                cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = id
                cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف کاربر", "جدید", "ثبت کاربر : " & Txtname.Text.Trim, "")
            Me.Close()
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()

            If Err.Number = 5 Then
                MessageBox.Show("کاربر انتخابی شما قابل ثبت شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_AddUser", "SaveUser")
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        End Try
    End Sub
    Private Sub EditUser()
        Dim sqltransaction As New CommittableTransaction
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using cmd As New SqlCommand("Update Define_User SET Nam=@Nam,Pas=@Pas WHERE Id=@Id", ConectionBank)
                cmd.Parameters.AddWithValue("@Nam", SqlDbType.NVarChar).Value = Txtname.Text.Trim
                cmd.Parameters.AddWithValue("@Pas", SqlDbType.VarBinary).Value = Sec.StringEncrypt(TxtP.Text, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = edt
                cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using cmd As New SqlCommand("UPDATE SettingProgram SET MojodyBox=@MojodyBox,MojodyBank=@MojodyBank,MojodyAnbar=@MojodyAnbar,S8=@S8,S9=@S9,S10=@S10,S11=@S11,S22=@S22,S23=@S23,S24=@S24,S25=@S25,S26=@S26,S32=@S32 WHERE IdUser=@IdUser", ConectionBank)
                cmd.Parameters.AddWithValue("@MojodyBox", SqlDbType.Bit).Value = ChkMojodyBox.CheckState
                cmd.Parameters.AddWithValue("@MojodyBank", SqlDbType.Bit).Value = ChkMojodyBank.CheckState
                cmd.Parameters.AddWithValue("@MojodyAnbar", SqlDbType.Bit).Value = ChkMojodyAnbar.CheckState
                cmd.Parameters.AddWithValue("@S8", SqlDbType.NVarChar).Value = If(ChkEdit.Checked = True, NumDayEdit.Value, 0)
                cmd.Parameters.AddWithValue("@S9", SqlDbType.NVarChar).Value = If(ChkDel.Checked = True, NumDayDel.Value, 0)
                cmd.Parameters.AddWithValue("@S10", SqlDbType.NVarChar).Value = ChkMonFac.CheckState
                cmd.Parameters.AddWithValue("@S11", SqlDbType.NVarChar).Value = ChkDec.CheckState
                cmd.Parameters.AddWithValue("@S22", SqlDbType.NVarChar).Value = ChkAdd.CheckState
                cmd.Parameters.AddWithValue("@S23", SqlDbType.NVarChar).Value = ChkHajm.CheckState
                cmd.Parameters.AddWithValue("@S24", SqlDbType.NVarChar).Value = ChkPrivate.CheckState
                cmd.Parameters.AddWithValue("@S25", SqlDbType.NVarChar).Value = ChkDate.CheckState
                cmd.Parameters.AddWithValue("@S26", SqlDbType.NVarChar).Value = ChkNoSell.CheckState
                cmd.Parameters.AddWithValue("@S32", SqlDbType.NVarChar).Value = Chk_RegeditFactor.CheckState
                cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = edt
                cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف کاربر", "ویرایش", If(str_name = Txtname.Text, "ویرایش کاربر : " & str_name, "ویرایش کاربر از : " & str_name & " به " & Txtname.Text.Trim), "")
            Me.Close()
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()

            If Err.Number = 5 Then
                MessageBox.Show("کاربر انتخابی شما قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_AddUser", "EditUser")
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        End Try
    End Sub

    Private Sub Define_AddUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next

        If edt > 0 Then GetInfo()
    End Sub
    Private Sub GetInfo()
        Try
            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT MojodyBox,MojodyBank,MojodyAnbar,S8,S9,S10,S11,S22,S23,S24,S25,S26,S32 FROM SettingProgram WHERE IdUser =" & edt, ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("اطلاعات کاربر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            Else
                ChkMojodyBox.Checked = If(dt.Rows(0).Item("MojodyBox") Is DBNull.Value, False, dt.Rows(0).Item("MojodyBox"))
                ChkMojodyBank.Checked = If(dt.Rows(0).Item("MojodyBank") Is DBNull.Value, False, dt.Rows(0).Item("MojodyBank"))
                ChkMojodyAnbar.Checked = If(dt.Rows(0).Item("MojodyAnbar") Is DBNull.Value, False, dt.Rows(0).Item("MojodyAnbar"))
                ChkEdit.Checked = If(dt.Rows(0).Item("S8") Is DBNull.Value, False, dt.Rows(0).Item("S8"))
                If ChkEdit.Checked = True Then NumDayEdit.Value = If(dt.Rows(0).Item("S8") Is DBNull.Value, 0, dt.Rows(0).Item("S8"))
                ChkDel.Checked = If(dt.Rows(0).Item("S9") Is DBNull.Value, False, dt.Rows(0).Item("S9"))
                If ChkDel.Checked = True Then NumDayDel.Value = If(dt.Rows(0).Item("S9") Is DBNull.Value, 0, dt.Rows(0).Item("S9"))
                ChkMonFac.Checked = If(dt.Rows(0).Item("S10") Is DBNull.Value, False, dt.Rows(0).Item("S10"))
                ChkDec.Checked = If(dt.Rows(0).Item("S11") Is DBNull.Value, False, dt.Rows(0).Item("S11"))
                ChkAdd.Checked = If(dt.Rows(0).Item("S22") Is DBNull.Value, False, dt.Rows(0).Item("S22"))
                ChkHajm.Checked = If(dt.Rows(0).Item("S23") Is DBNull.Value, False, dt.Rows(0).Item("S23"))
                ChkPrivate.Checked = If(dt.Rows(0).Item("S24") Is DBNull.Value, False, dt.Rows(0).Item("S24"))
                ChkDate.Checked = If(dt.Rows(0).Item("S25") Is DBNull.Value, False, dt.Rows(0).Item("S25"))
                ChkNoSell.Checked = If(dt.Rows(0).Item("S26") Is DBNull.Value, False, dt.Rows(0).Item("S26"))
                Chk_RegeditFactor.CheckState = If(dt.Rows(0).Item("S32") Is DBNull.Value, False, dt.Rows(0).Item("S32"))
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Define_AddUser", "GetInfo")
        End Try
    End Sub

    Private Sub ChkEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEdit.CheckedChanged
        If ChkEdit.Checked = True Then
            NumDayEdit.Enabled = True
        Else
            NumDayEdit.Value = 1
            NumDayEdit.Enabled = False
        End If
    End Sub

    Private Sub ChkDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDel.CheckedChanged
        If ChkDel.Checked = True Then
            NumDayDel.Enabled = True
        Else
            NumDayDel.Value = 1
            NumDayDel.Enabled = False
        End If
    End Sub
End Class