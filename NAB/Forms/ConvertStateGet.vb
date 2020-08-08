Imports System.Data.SqlClient
Imports System.Transactions
Public Class ConvertStateGet
    Dim Mon, NumChk As Double
    Dim Idbank, oldIdpeople, CurrentIdPeople, Current_Type, Type As Long
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If String.IsNullOrEmpty(DateChk.ThisText) Then
                MessageBox.Show("تاریخ سند را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DateChk.Focus()
                Exit Sub
            End If

            If RdoBrat.Checked = True Then
                If String.IsNullOrEmpty(TxtBratBank.Text) Then
                    MessageBox.Show("لطفا بانک جهت برات را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtBratBank.Focus()
                    Exit Sub
                End If
                If String.IsNullOrEmpty(FarsiDateBrat.ThisText) Then
                    MessageBox.Show("لطفا تاریخ برات چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    FarsiDateBrat.Focus()
                    Exit Sub
                End If
            End If

            Me.Enabled = False
            For i As Integer = 0 To ListChkArray.Length - 1
                If ListChkArray(i).Kind = 0 Then

                    If RdoVosol.Checked = True Then 'وصول چک دریافتی

                        Me.VosolChk(ListChkArray(i).Id, ListChkArray(i).NumChk)

                    ElseIf RdoBargasht.Checked = True Then 'برگشت چک دریافتی

                        If Me.BargashChk(ListChkArray(i).Id, 0) Then TraceUser(Id_User, DateChk.ThisText, CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "برگشت چک دریافتی با سریال " & ListChkArray(i).NumChk, "")

                    ElseIf RdoBrat.Checked = True Then 'برات چک دریافتی

                        If Me.BartChk(ListChkArray(i).Id, CLng(TxtBratID.Text)) Then TraceUser(Id_User, DateChk.ThisText, CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "برات چک دریافتی با سریال " & ListChkArray(i).NumChk & " به بانک :" & TxtBratBank.Text, "")

                    ElseIf RdoDarVosol.Checked = True Then  'در جریان وصول کردن چک دریافتی

                        If Me.ConvertState(ListChkArray(i).Id, 0, 0) Then TraceUser(Id_User, DateChk.ThisText, CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "تغییر وضعیت به حالت در جریان وصول چک دریافتی با سریال " & ListChkArray(i).NumChk, "")

                    End If

                ElseIf ListChkArray(i).Kind = 1 Then

                    If RdoVosol.Checked = True Then 'وصول چک پرداختی

                        If Me.VosolPayChk(ListChkArray(i).Id) Then TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "وصول چک پرداختی با سریال " & ListChkArray(i).NumChk, "")

                    ElseIf RdoBargasht.Checked = True Then  'برگشت چک پرداختی

                        If Me.BargashChk(ListChkArray(i).Id, If(KindState(ListChkArray(i).Id) = 1, 2, 1)) Then TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "برگشت چک پرداختی با سریال " & ListChkArray(i).NumChk, "")

                    ElseIf RdoDarVosol.Checked = True Then  'در جریان وصول کردن چک پرداختی
                        If KindState(ListChkArray(i).Id) = 1 Then
                            If Me.ConvertState(ListChkArray(i).Id, 0, 0) Then TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "تغییر وضعیت به حالت در جریان وصول چک خرج شده با سریال " & ListChkArray(i).NumChk, "")
                        Else
                            If Me.ConvertState(ListChkArray(i).Id, 0, 1) Then TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "تغییر وضعیت به حالت در جریان وصول چک پرداختی با سریال " & ListChkArray(i).NumChk, "")
                        End If
                    End If

                End If
            Next
            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "BtnOk_Click")
            Me.Close()
        End Try

    End Sub

    Private Sub ConvertChkGet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetChk.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Function VosolChk(ByVal Id As Long, ByVal NumChk As String) As Boolean
        Try
            Me.GetInfoChkBrat(Id, 1)
            If Idbank > 0 Then
                If Me.VosolBratChk(Id) Then TraceUser(Id_User, DateChk.ThisText, CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", " وصول چک دریافتی برات شده با سریال " & NumChk, "")
            Else
                Using Vosol As New Vosol_chk
                    Vosol.TxtDateV.Text = DateChk.ThisText
                    Vosol.LId.Text = Id
                    Vosol.ShowDialog()
                End Using
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "VosolChk")
        End Try
    End Function
    Private Function VosolPayChk(ByVal Id As Long) As Boolean
        Try
            If KindState(Id) = -2 Then
                MessageBox.Show("وضعیت چک با سند" & Id & "مشخص نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf KindState(Id) = 0 Then
                If Not VosolChkPayChk(Id) Then
                    MessageBox.Show(" چک با سند" & Id & "وصول نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            ElseIf KindState(Id) = 1 Then
                If Not Me.ConvertState(Id, 1, 0) Then
                    MessageBox.Show(" چک با سند" & Id & "وصول نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "VosolPayChk")
            Return False
        End Try
    End Function
    Private Function KindState(ByVal Id As Long) As Long
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Current_Kind-Kind FROM Chk_Get_Pay WHERE Id=" & Id, ConectionBank)
                Dim res As Long = cmd.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return res
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "KindState")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return -2
        End Try
    End Function
    Private Function ConvertState(ByVal Id As Long, ByVal state As Long, ByVal Kind As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            If Kind = 0 Then
                Using CMD As New SqlCommand("UPDATE Chk_Id SET IdBank=@IdBank WHERE Id=@Id", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = DBNull.Value
                    CMD.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                    CMD.ExecuteNonQuery()
                End Using
            End If

            If GetInfoChk(Id, Kind) = False Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return False
            End If

            Dim dt As New DataTable
            Using CMD As New SqlCommand("SELECT BoxMoein As Sanad,Typ='Box' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND BoxMoein IS Not NULL UNION ALL SELECT BankMoein As Sanad,Typ='Bank' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND BankMoein IS Not NULL UNION ALL SELECT PeopleMoein As Sanad,Typ='People' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND PeopleMoein IS Not NULL", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            If dt.Rows.Count > 0 Then
                Using CMD As New SqlCommand("DELETE FROM Sanad_ChangeChk WHERE IdChk=@IdChk", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = Id
                    CMD.ExecuteNonQuery()
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("DELETE FROM Moein_" & dt.Rows(i).Item("Typ") & " WHERE Id=@ID", ConectionBank)
                        CMD.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(i).Item("Sanad")
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                    End Using
                Next i
            End If
            Using cmd As New SqlCommand("UPDATE  Chk_Get_Pay SET Current_State=" & state & " WHERE Id=" & Id, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@Id ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = DateChk.ThisText
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = state
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text)
                Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر چک قابل تغییر وضعیت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "ConvertState")
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Function VosolChkPayChk(ByVal lid As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            If GetInfoChk(lid, 1) = False Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return False
            End If

            Dim dt As New DataTable
            Using CMD As New SqlCommand("SELECT BoxMoein As Sanad,Typ='Box' FRom Sanad_ChangeChk WHERE IdChk =" & lid & " AND BoxMoein IS Not NULL UNION ALL SELECT BankMoein As Sanad,Typ='Bank' FRom Sanad_ChangeChk WHERE IdChk =" & lid & " AND BankMoein IS Not NULL UNION ALL SELECT PeopleMoein As Sanad,Typ='People' FRom Sanad_ChangeChk WHERE IdChk =" & lid & " AND PeopleMoein IS Not NULL", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            If dt.Rows.Count > 0 Then
                Using CMD As New SqlCommand("DELETE FROM Sanad_ChangeChk WHERE IdChk=@IdChk", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = lid
                    CMD.ExecuteNonQuery()
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("DELETE FROM Moein_" & dt.Rows(i).Item("Typ") & " WHERE Id=@ID", ConectionBank)
                        CMD.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(i).Item("Sanad")
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                    End Using
                Next i
            End If
            Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@BoxMoein,@IdMoein,@PeopleMoein,@DelayChk)", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = DateChk.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "وصول چک به شماره " & NumChk & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = Mon
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = Idbank
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = lid
                Cmd.Parameters.AddWithValue("@BoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@PeopleMoein", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = 0
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Current_State=@Current_State,IdUser=@IdUser WHERE Id=" & lid, ConectionBank)
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@Id ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = lid
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = DateChk.ThisText
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text)
                Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر چک قابل وصول شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "VosolChkPayChk")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function VosolBratChk(ByVal lid As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            If GetInfoChk(lid, 1) = False Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return False
            End If

            Dim dt As New DataTable
            Using CMD As New SqlCommand("SELECT BoxMoein As Sanad,Typ='Box' FRom Sanad_ChangeChk WHERE IdChk =" & lid & " AND BoxMoein IS Not NULL UNION ALL SELECT BankMoein As Sanad,Typ='Bank' FRom Sanad_ChangeChk WHERE IdChk =" & lid & " AND BankMoein IS Not NULL UNION ALL SELECT PeopleMoein As Sanad,Typ='People' FRom Sanad_ChangeChk WHERE IdChk =" & lid & " AND PeopleMoein IS Not NULL", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            If dt.Rows.Count > 0 Then
                Using CMD As New SqlCommand("DELETE FROM Sanad_ChangeChk WHERE IdChk=@IdChk", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = lid
                    CMD.ExecuteNonQuery()
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("DELETE FROM Moein_" & dt.Rows(i).Item("Typ") & " WHERE Id=@ID", ConectionBank)
                        CMD.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(i).Item("Sanad")
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                    End Using
                Next i
            End If
            Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@BoxMoein,@IdMoein,@PeopleMoein,@DelayChk)", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = DateChk.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "وصول چک به شماره " & NumChk & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = Mon
                Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = Idbank
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = lid
                Cmd.Parameters.AddWithValue("@BoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@PeopleMoein", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = 0
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Current_State=@Current_State,IdUser=@IdUser WHERE Id=" & lid, ConectionBank)
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            Using CMD As New SqlCommand("UPDATE Chk_Id SET IdBank=@IdBank WHERE Id=@Id", ConectionBank)
                CMD.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = DBNull.Value
                CMD.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(lid)
                CMD.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@Id ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = lid
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = DateChk.ThisText
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text)
                Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر چک قابل وصول شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "VosolBratChk")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function GetInfoChk(ByVal Id As Long, ByVal Kind As Long) As Boolean
        Try
            Mon = 0
            NumChk = 0
            Idbank = 0
            Dim StrSql As String = ""
            If Kind = 1 Then
                StrSql = "SELECT Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Chk_Id.IdBank FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Chk_Get_Pay.Id=" & Id
            ElseIf Kind = 0 Then
                StrSql = "SELECT Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk FROM Chk_Get_Pay  WHERE Chk_Get_Pay.Id=" & Id
            End If
            Using cmd As New SqlCommand(StrSql, ConectionBank)
                Dim dt2 As New DataTable
                dt2.Load(cmd.ExecuteReader)
                If dt2.Rows.Count > 0 Then
                    Mon = dt2.Rows(0).Item("MoneyChk")
                    NumChk = dt2.Rows(0).Item("NumChk")
                    If Kind = 1 Then Idbank = dt2.Rows(0).Item("IdBank")
                    dt2.Dispose()
                    Return True
                Else
                    dt2.Dispose()
                    Return False
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "GetInfoChk")
            Mon = 0
            NumChk = 0
            Idbank = 0
            Return False
        End Try
    End Function
    Private Function GetInfoChkBack(ByVal Id As Long) As Boolean
        Try
            Mon = 0
            NumChk = 0
            Idbank = 0
            oldIdpeople = 0
            CurrentIdPeople = 0
            Current_Type = 0
            Type = 0
            Using cmd As New SqlCommand("SELECT Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk,Chk_Get_Pay.[Type],Chk_Get_Pay.Current_Type, Chk_Id.IdPeople,Chk_Id.Current_IdPeople   FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Chk_Get_Pay.Id=" & Id, ConectionBank)
                Dim dt2 As New DataTable
                dt2.Load(cmd.ExecuteReader)
                If dt2.Rows.Count > 0 Then
                    Mon = dt2.Rows(0).Item("MoneyChk")
                    NumChk = dt2.Rows(0).Item("NumChk")
                    CurrentIdPeople = If(dt2.Rows(0).Item("Current_IdPeople") Is DBNull.Value, 0, dt2.Rows(0).Item("Current_IdPeople"))
                    oldIdpeople = If(dt2.Rows(0).Item("IdPeople") Is DBNull.Value, 0, dt2.Rows(0).Item("IdPeople"))
                    Current_Type = If(dt2.Rows(0).Item("Current_Type") Is DBNull.Value, 0, dt2.Rows(0).Item("Current_Type"))
                    Type = If(dt2.Rows(0).Item("Type") Is DBNull.Value, 0, dt2.Rows(0).Item("Type"))
                    dt2.Dispose()
                    Return True
                Else
                    dt2.Dispose()
                    Return False
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "GetInfoChkBack")
            Mon = 0
            NumChk = 0
            Idbank = 0
            oldIdpeople = 0
            CurrentIdPeople = 0
            Type = 0
            Return False
        End Try
    End Function

    Private Function GetInfoChkBrat(ByVal Id As Long, ByVal Kind As Long) As Boolean
        Try
            Mon = 0
            NumChk = 0
            Idbank = 0
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Chk_Id.IdBank FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Chk_Get_Pay.Id=" & Id, ConectionBank)
                Dim dt2 As New DataTable
                dt2.Load(cmd.ExecuteReader)
                If dt2.Rows.Count > 0 Then
                    Mon = dt2.Rows(0).Item("MoneyChk")
                    NumChk = dt2.Rows(0).Item("NumChk")
                    If Kind = 1 Then
                        If dt2.Rows(0).Item("IdBank") Is DBNull.Value Then
                            Idbank = 0
                        Else
                            Idbank = dt2.Rows(0).Item("IdBank")
                        End If

                    End If
                    dt2.Dispose()
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    dt2.Dispose()
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "GetInfoChkBrat")
            Mon = 0
            NumChk = 0
            Idbank = 0
            Return False
        End Try
    End Function

    Private Function BargashChk(ByVal Id As Long, ByVal Kind As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            If GetInfoChkBack(Id) = False Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return False
            End If

            Dim Kin As Long = 0

            If Kind = 0 Or Kind = 2 Then
                Kin = 0
            ElseIf Kind = 1 Then
                Kin = 1
            End If

            Dim dt As New DataTable
            Using CMD As New SqlCommand("SELECT BoxMoein As Sanad,Typ='Box' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND BoxMoein IS Not NULL UNION ALL SELECT BankMoein As Sanad,Typ='Bank' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND BankMoein IS Not NULL UNION ALL SELECT PeopleMoein As Sanad,Typ='People' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND PeopleMoein IS Not NULL", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            If dt.Rows.Count > 0 Then
                Using CMD As New SqlCommand("DELETE FROM Sanad_ChangeChk WHERE IdChk=@IdChk", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = Id
                    CMD.ExecuteNonQuery()
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("DELETE FROM Moein_" & dt.Rows(i).Item("Typ") & " WHERE Id=@ID", ConectionBank)
                        CMD.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(i).Item("Sanad")
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                    End Using
                Next i
            End If
            If Kind = 0 Then
                Using CMD As New SqlCommand("UPDATE Chk_Id SET IdBank=@IdBank WHERE Id=@Id", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = DBNull.Value
                    CMD.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                    CMD.ExecuteNonQuery()
                End Using
            End If

            If Kind = 0 Or Kind = 1 Then
                If Current_Type <> 16 And Current_Type <> 17 And (Current_Type <> 15 And Type <> 15) And (Current_Type <> 21 And Type <> 21) And (Current_Type <> 14 And Type <> 14) Then
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IDPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IDPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@BoxMoein,@BankMoein,@IdMoein,@DelayChk)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = DateChk.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "برگشت چک به شماره " & NumChk & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = Mon
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = Kind
                        Cmd.Parameters.AddWithValue("@IDPeople", SqlDbType.BigInt).Value = CurrentIdPeople
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 19
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = Id
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 19
                        Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = Id
                        Cmd.Parameters.AddWithValue("@BoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@BankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = 0
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            ElseIf Kind = 2 Then
                If Current_Type <> 16 And Current_Type <> 17 And (Current_Type <> 15) And (Current_Type <> 21) And (Current_Type <> 14) Then
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IDPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IDPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@BoxMoein,@BankMoein,@IdMoein,@DelayChk)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = DateChk.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "برگشت چک به شماره " & NumChk & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = Mon
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 1
                        Cmd.Parameters.AddWithValue("@IDPeople", SqlDbType.BigInt).Value = CurrentIdPeople
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 19
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = Id
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 19
                        Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = Id
                        Cmd.Parameters.AddWithValue("@BoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@BankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = 0
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
                If Type <> 16 And Type <> 17 And (Type <> 15) And (Type <> 21) And (Type <> 14) Then
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IDPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IDPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);declare @IdMoein bigint SET @IdMoein =(SELECT @@IDENTITY) ; INSERT INTO Sanad_ChangeChk(IdChk,BoxMoein,BankMoein,PeopleMoein,DelayChk) VALUES(@IdChk,@BoxMoein,@BankMoein,@IdMoein,@DelayChk)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = DateChk.ThisText
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "برگشت چک به شماره " & NumChk & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text)
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = Mon
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@IDPeople", SqlDbType.BigInt).Value = oldIdpeople
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 19
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = Id
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 19
                        Cmd.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = Id
                        Cmd.Parameters.AddWithValue("@BoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@BankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@DelayChk", SqlDbType.BigInt).Value = 0
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If

                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Current_State=@Current_State,IdUser=@IdUser WHERE Id=" & Id, ConectionBank)
                    Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 2
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.ExecuteNonQuery()
                End Using

                Using Cmd As New SqlCommand("INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@Id ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = DateChk.ThisText
                    Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 2
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text), "", TxtDisc.Text)
                    Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.ExecuteNonQuery()
                End Using

                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر چک قابل برگشت دادن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "BargashChk")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function BartChk(ByVal Id As Long, ByVal Kind As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            If GetInfoChkBack(Id) = False Then
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return False
            End If


            Dim dt As New DataTable
            Using CMD As New SqlCommand("SELECT BoxMoein As Sanad,Typ='Box' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND BoxMoein IS Not NULL UNION ALL SELECT BankMoein As Sanad,Typ='Bank' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND BankMoein IS Not NULL UNION ALL SELECT PeopleMoein As Sanad,Typ='People' FRom Sanad_ChangeChk WHERE IdChk =" & Id & " AND PeopleMoein IS Not NULL", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            If dt.Rows.Count > 0 Then
                Using CMD As New SqlCommand("DELETE FROM Sanad_ChangeChk WHERE IdChk=@IdChk", ConectionBank)
                    CMD.Parameters.AddWithValue("@IdChk", SqlDbType.BigInt).Value = Id
                    CMD.ExecuteNonQuery()
                End Using
                For i As Integer = 0 To dt.Rows.Count - 1
                    Using CMD As New SqlCommand("DELETE FROM Moein_" & dt.Rows(i).Item("Typ") & " WHERE Id=@ID", ConectionBank)
                        CMD.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = dt.Rows(i).Item("Sanad")
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                    End Using
                Next i
            End If

            Using CMD As New SqlCommand("UPDATE Chk_Id SET IdBank=@IdBank,D_Date=@D_Date WHERE Id=@Id", ConectionBank)
                CMD.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = Kind
                CMD.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = FarsiDateBrat.ThisText
                CMD.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                CMD.ExecuteNonQuery()
            End Using


            Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Current_State=@Current_State,IdUser=@IdUser WHERE Id=" & Id, ConectionBank)
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 4
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@Id ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = DateChk.ThisText
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = 4
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "برات به بانک " & TxtBratBank.Text & " در تاریخ " & FarsiDateBrat.ThisText & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text)
                Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = Kind
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر چک قابل برات شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateGet", "BartChk")
            End If

            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub RdoBrat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBrat.CheckedChanged
        If RdoBrat.Checked = True Then
            GroupBox2.Enabled = True
            FarsiDateBrat.ThisText = GetDate()
            TxtBratBank.Focus()
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub TxtBratBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBratBank.KeyDown
        If e.KeyCode = Keys.Enter Then FarsiDateBrat.Focus()
    End Sub

    Private Sub TxtBratBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBratBank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.LState.Text = ""
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtBratBank.Focus()
        If IdKala <> 0 Then
            TxtBratBank.Text = Tmp_Namkala
            TxtBratID.Text = IdKala
        Else
            TxtBratBank.Text = ""
            TxtBratID.Text = ""
        End If
    End Sub

    Private Sub FarsiDateBrat_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDateBrat.KeyDowned
        If e.KeyCode = Keys.Enter Then
            BtnOk.Focus()
        End If
    End Sub

    Private Sub ConvertStateGet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DateChk.ThisText = GetDate()
        If RdoBrat.Checked = False Then
            GroupBox2.Enabled = False
        Else
            GroupBox2.Enabled = True
        End If
    End Sub
End Class