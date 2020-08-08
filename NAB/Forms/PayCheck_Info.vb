Imports System.Data.SqlClient
Imports System.Transactions
Public Class PayCheck_Info
    Dim T_idbank As Long
    Dim T_NumChk As Double
    Private Sub TxtPayDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtBank.Focus()
    End Sub

    Private Sub TxtPayDate_TextChanging(ByVal sender As Object, ByVal e As String) Handles TxtPayDate.TextChanging
        Try
            If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                LDate.Text = ""
                LTime.Text = "0" & " روز "
            Else
                Dim StringDate As New NumberToString
                LDate.Text = StringDate.DateToPersianNonvertor(StringDate.PersianToDateConvertor(TxtPayDate.ThisText))
                LTime.Text = SUBDAY(TxtPayDate.ThisText, GetDate()) & " روز "
            End If
        Catch ex As Exception
            LDate.Text = ""
        End Try
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
    End Sub

    Private Sub TxtMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TxtMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon.Text.Replace(",", "")))) Then
                TxtMon.Text = "0"
                Exit Sub
            End If
            Dim str As String
            If TxtMon.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon.Text.Replace(",", ""))
                TxtMon.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon.Text = CDbl(TxtMon.Text)
            End If
            Dim s As New NumberToString
            LMon.Text = s.Num2Str(CDbl(TxtMon.Text))
        Catch ex As Exception
            LMon.Text = ""
        End Try
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then TxtMon.Focus()
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
        Else
            TxtName.Text = ""
            TxtIdName.Text = ""
        End If
    End Sub

    Private Sub TxtBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBank.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then TxtNumberChk.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If GroupBox1.Visible = False Then
                If e.KeyCode = Keys.Enter Then cmdsave.Focus()
            Else
                CmbTypeChk.Focus()
            End If
        End If
    End Sub

    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        Me.Close()
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            If CmbTypeChk.Text <> "تضمینی" Then
                If String.IsNullOrEmpty(TxtPayDate.ThisText) Then
                    MessageBox.Show("لطفا تاریخ سر رسید چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPayDate.Focus()
                    Exit Sub
                End If
            Else
                LDate.Text = ""
            End If
            If String.IsNullOrEmpty(TxtBank.Text.Trim) Then
                MessageBox.Show("لطفا نام بانک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBank.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtName.Text.Trim) Then
                MessageBox.Show("لطفا گیرنده چک را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtNumberChk.Text.Trim) Or TxtNumberChk.Text.Trim = "0" Then
                MessageBox.Show("لطفا سریال چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNumberChk.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtMon.Text.Trim) Or TxtMon.Text = "0" Then
                MessageBox.Show("لطفا مبلغ چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMon.Focus()
                Exit Sub
            End If
            TxtDisc.Text = TxtDisc.Text.Trim
            If LAction.Text = "00" Or LAction.Text = "01" Then
                If SaveGetChk(GetDate(), TxtPayDate.ThisText, CDbl(TxtMon.Text), CDbl(TxtNumberChk.Text), 1, 1, "", "", "", TxtDisc.Text.Trim, GetNumberState(CmbTypeChk.Text.Trim), GetNumberState(CmbTypeChk.Text.Trim), 1, 11, 0, 11, 0, TxtSanad.Text.Trim, 10, 10, LAction.Text, If(String.IsNullOrEmpty(TxtIdName.Text.Trim), 0, CLng(TxtIdName.Text.Trim)), If(String.IsNullOrEmpty(TxtIdName.Text.Trim), 0, CLng(TxtIdName.Text.Trim)), If(String.IsNullOrEmpty(TxtIdBank.Text.Trim), 0, CLng(TxtIdBank.Text.Trim)), 0, 0, 0, GetDate(), Id_User) Then

                    If LAction.Text = "01" Then
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اولیه اسناد پرداختی", "ویرایش", If(TxtNumberChk.Text = Tmp_String1 And CDbl(TxtMon.Text) = CDbl(Tmp_String2), "ویرایش چک :" & TxtNumberChk.Text, "ویرایش چک از :" & Tmp_String1 & " با مبلغ " & Tmp_String2 & " به چک " & TxtNumberChk.Text & " با مبلغ" & TxtMon.Text), "")
                    ElseIf LAction.Text = "00" Then
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اولیه اسناد پرداختی", "جدید", "ثبت چک :" & TxtNumberChk.Text & " با مبلغ " & TxtMon.Text, "")
                    End If

                    Me.Close()
                End If
            ElseIf LAction.Text = "10" Or LAction.Text = "11" Then
                If LState.Text = "21" Then 'چکهای سرمایه
                    If SaveGetChk(GetDate(), TxtPayDate.ThisText, CDbl(TxtMon.Text), CDbl(TxtNumberChk.Text), 1, 1, "", "", "", TxtDisc.Text.Trim, GetNumberState(CmbTypeChk.Text.Trim), GetNumberState(CmbTypeChk.Text.Trim), 0, CLng(LState.Text), CLng(LIdFac.Text), CLng(LState.Text), CLng(LIdFac.Text), TxtSanad.Text.Trim, 11, 11, LAction.Text, 0, 0, If(String.IsNullOrEmpty(TxtIdBank.Text.Trim), 0, CLng(TxtIdBank.Text.Trim)), 0, 0, CLng(TxtIdName.Text.Trim), GetDate(), Id_User) Then
                        Me.Close()
                    End If
                ElseIf LState.Text = "14" Then 'چکهای اموال
                    If SaveGetChk(GetDate(), TxtPayDate.ThisText, CDbl(TxtMon.Text), CDbl(TxtNumberChk.Text), 1, 1, "", "", "", TxtDisc.Text.Trim, GetNumberState(CmbTypeChk.Text.Trim), GetNumberState(CmbTypeChk.Text.Trim), 0, CLng(LState.Text), CLng(LIdFac.Text), CLng(LState.Text), CLng(LIdFac.Text), TxtSanad.Text.Trim, 11, 11, LAction.Text, 0, 0, If(String.IsNullOrEmpty(TxtIdBank.Text.Trim), 0, CLng(TxtIdBank.Text.Trim)), CLng(TxtIdName.Text.Trim), 0, 0, GetDate(), Id_User) Then
                        Me.Close()
                    End If
                Else
                    If CLng(TxtIdName.Text) > 0 Then
                        'چکهای پرداخت به طرف حساب
                        If SaveGetChk(GetDate(), TxtPayDate.ThisText, CDbl(TxtMon.Text), CDbl(TxtNumberChk.Text), 1, 1, "", "", "", TxtDisc.Text.Trim, GetNumberState(CmbTypeChk.Text.Trim), GetNumberState(CmbTypeChk.Text.Trim), 0, CLng(LState.Text), CLng(LIdFac.Text), CLng(LState.Text), CLng(LIdFac.Text), TxtSanad.Text.Trim, 10, 10, LAction.Text, If(String.IsNullOrEmpty(TxtIdName.Text.Trim), 0, CLng(TxtIdName.Text.Trim)), If(String.IsNullOrEmpty(TxtIdName.Text.Trim), 0, CLng(TxtIdName.Text.Trim)), If(String.IsNullOrEmpty(TxtIdBank.Text.Trim), 0, CLng(TxtIdBank.Text.Trim)), 0, 0, 0, GetDate(), Id_User) Then
                            Me.Close()
                        End If

                    Else
                        If CLng(TxtIdName.Text) = -16 Or CLng(TxtIdName.Text) = -17 Then 'چکهای هزینه 
                            If SaveGetChk(GetDate(), TxtPayDate.ThisText, CDbl(TxtMon.Text), CDbl(TxtNumberChk.Text), 1, 1, "", "", "", TxtDisc.Text.Trim, GetNumberState(CmbTypeChk.Text.Trim), GetNumberState(CmbTypeChk.Text.Trim), 0, CLng(LState.Text), CLng(LIdFac.Text), CLng(LState.Text), CLng(LIdFac.Text), TxtSanad.Text.Trim, 11, 11, LAction.Text, 0, 0, If(String.IsNullOrEmpty(TxtIdBank.Text.Trim), 0, CLng(TxtIdBank.Text.Trim)), 0, 0, 0, GetDate(), Id_User) Then
                                Me.Close()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayCheck_Info", "cmdsave_Click")
        End Try
    End Sub
    Private Function SaveGetChk(ByVal GetDate As String, ByVal PayDate As String, _
                                ByVal MoneyChk As Double, ByVal NumChk As Double, _
                                ByVal Kind As Long, ByVal Current_Kind As Long, _
                                ByVal Shobeh As String, ByVal N_Bank As String, _
                                ByVal Number_N As String, ByVal Disc As String, _
                                ByVal Current_State As Long, ByVal State As Long, ByVal Active As Integer, _
                                ByVal Type As Long, ByVal Number_Type As Long, _
                                ByVal Current_Type As Long, ByVal Current_Number_Type As Long, _
                                ByVal Number_Note As String, ByVal Type_Chk As Long, _
                                ByVal Current_Type_Chk As Long, ByVal TypeInsert As String, _
                                ByVal IdPeople As Long, ByVal Current_IdPeople As Long, _
                                ByVal IdBank As Long, ByVal IdAmval As Long, _
                                ByVal IdDaramad As Long, ByVal IdSarmayeh As Long, _
                                ByVal BratDate As String, ByVal idUser As Long) As Boolean

        Dim IdChk As Long = 0
        If GetStateBank(IdBank) <> "جاری" Then
            MessageBox.Show("وضعیت چک از جاری به پس انداز تغییر داده شده است و چک قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If TypeInsert = "00" Or TypeInsert = "10" Then
            If AreYouAddNumberCheck(CLng(TxtIdBank.Text), CLng(TxtNumberChk.Text)) = False Then
                MessageBox.Show("شماره چک مورد نظر استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If
        If TypeInsert = "01" Or TypeInsert = "11" Then
            If AreYouEditCheck(CLng(LEdit.Text)) = False Then
                MessageBox.Show("اطلاعات در حال حاضر قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            If AreYouEditNumberCheck(CLng(TxtIdBank.Text), CLng(TxtNumberChk.Text), T_idbank, T_NumChk) = False Then
                MessageBox.Show("شماره چک مورد نظر استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            If TypeInsert = "00" Or TypeInsert = "10" Then
                Using Cmd As New SqlCommand("INSERT INTO Chk_Get_Pay(GetDate,PayDate,MoneyChk,NumChk,Kind,Current_Kind,Shobeh,N_Bank,Number_N,Disc,Current_State,State,Activ,Type,Number_Type,Current_Type,Current_Number_Type,Number_Note,Type_Chk,Current_Type_Chk,IdUser) VALUES(@GetDate,@PayDate,@MoneyChk,@NumChk,@Kind,@Current_Kind,@Shobeh,@N_Bank,@Number_N,@Disc,@Current_State,@State,@Activ,@Type,@Number_Type,@Current_Type,@Current_Number_Type,@Number_Note,@Type_Chk,@Current_Type_Chk,@IdUser); Declare @IdChk bigint =0 SET @IdChk =(SELECT @@IDENTITY) INSERT INTO Chk_Id (Id,IdPeople ,Current_IdPeople ,IdBank ,IdAmval,IdDaramad,IdSarmayeh,D_date) VALUES(@IdChk ,@IdPeople,@Current_IdPeople,@IdBank,@IdAmval,@IdDaramad,@IdSarmayeh,@D_date); INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IdChk ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser);SELECT @IdChk ", ConectionBank)
                    Cmd.Parameters.AddWithValue("@GetDate", SqlDbType.NVarChar).Value = GetDate
                    Cmd.Parameters.AddWithValue("@PayDate", SqlDbType.NVarChar).Value = PayDate
                    Cmd.Parameters.AddWithValue("@MoneyChk", SqlDbType.BigInt).Value = MoneyChk
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = NumChk
                    Cmd.Parameters.AddWithValue("@Kind", SqlDbType.Int).Value = Kind
                    Cmd.Parameters.AddWithValue("@Current_Kind", SqlDbType.Int).Value = Current_Kind
                    Cmd.Parameters.AddWithValue("@Shobeh", SqlDbType.NVarChar).Value = Shobeh
                    Cmd.Parameters.AddWithValue("@N_Bank", SqlDbType.NVarChar).Value = N_Bank
                    Cmd.Parameters.AddWithValue("@Number_N", SqlDbType.NVarChar).Value = Number_N
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = Disc
                    Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = Current_State
                    Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = State
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = Active
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = Type
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = Number_Type
                    Cmd.Parameters.AddWithValue("@Current_Type", SqlDbType.Int).Value = Current_Type
                    Cmd.Parameters.AddWithValue("@Current_Number_Type", SqlDbType.BigInt).Value = Current_Number_Type
                    Cmd.Parameters.AddWithValue("@Number_Note", SqlDbType.NVarChar).Value = Number_Note
                    Cmd.Parameters.AddWithValue("@Type_Chk", SqlDbType.BigInt).Value = Type_Chk
                    Cmd.Parameters.AddWithValue("@Current_Type_Chk", SqlDbType.BigInt).Value = Current_Type_Chk
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = IIf(IdPeople = 0, DBNull.Value, CLng(IdPeople))
                    Cmd.Parameters.AddWithValue("@Current_IdPeople", SqlDbType.BigInt).Value = IIf(Current_IdPeople = 0, DBNull.Value, Current_IdPeople)
                    Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                    Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = IIf(IdAmval = 0, DBNull.Value, IdAmval)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = IIf(IdDaramad = 0, DBNull.Value, IdDaramad)
                    Cmd.Parameters.AddWithValue("@IdSarmayeh", SqlDbType.BigInt).Value = IIf(IdSarmayeh = 0, DBNull.Value, IdSarmayeh)
                    Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = BratDate
                    Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(idUser = 0, DBNull.Value, idUser)
                    IdChk = Cmd.ExecuteScalar
                End Using

            ElseIf TypeInsert = "01" Or TypeInsert = "11" Then
                Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET PayDate=@PayDate,MoneyChk=@MoneyChk,NumChk=@NumChk,Kind=@Kind,Current_Kind=@Current_Kind,Shobeh=@Shobeh,N_Bank=@N_Bank,Number_N=@Number_N,Disc=@Disc,Current_State=@Current_State,State=@State,Activ=@Activ,Type=@Type,Number_Type=@Number_Type,Current_Type=@Current_Type,Current_Number_Type=@Current_Number_Type,Number_Note=@Number_Note,Type_Chk=@Type_Chk,Current_Type_Chk=@Current_Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET IdPeople=@IdPeople ,Current_IdPeople=@Current_IdPeople ,IdBank=@IdBank,IdAmval=@IdAmval,IdDaramad=@IdDaramad,IdSarmayeh=@IdSarmayeh,D_date=@D_date WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@PayDate", SqlDbType.NVarChar).Value = PayDate
                    Cmd.Parameters.AddWithValue("@MoneyChk", SqlDbType.BigInt).Value = MoneyChk
                    Cmd.Parameters.AddWithValue("@NumChk", SqlDbType.BigInt).Value = NumChk
                    Cmd.Parameters.AddWithValue("@Kind", SqlDbType.Int).Value = Kind
                    Cmd.Parameters.AddWithValue("@Current_Kind", SqlDbType.Int).Value = Current_Kind
                    Cmd.Parameters.AddWithValue("@Shobeh", SqlDbType.NVarChar).Value = Shobeh
                    Cmd.Parameters.AddWithValue("@N_Bank", SqlDbType.NVarChar).Value = N_Bank
                    Cmd.Parameters.AddWithValue("@Number_N", SqlDbType.NVarChar).Value = Number_N
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = Disc
                    Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.Int).Value = Current_State
                    Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = State
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = Active
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = Type
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = Number_Type
                    Cmd.Parameters.AddWithValue("@Current_Type", SqlDbType.Int).Value = Current_Type
                    Cmd.Parameters.AddWithValue("@Current_Number_Type", SqlDbType.BigInt).Value = Current_Number_Type
                    Cmd.Parameters.AddWithValue("@Number_Note", SqlDbType.NVarChar).Value = Number_Note
                    Cmd.Parameters.AddWithValue("@Type_Chk", SqlDbType.BigInt).Value = Type_Chk
                    Cmd.Parameters.AddWithValue("@Current_Type_Chk", SqlDbType.BigInt).Value = Current_Type_Chk
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = IIf(IdPeople = 0, DBNull.Value, CLng(IdPeople))
                    Cmd.Parameters.AddWithValue("@Current_IdPeople", SqlDbType.BigInt).Value = IIf(Current_IdPeople = 0, DBNull.Value, Current_IdPeople)
                    Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                    Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = IIf(IdAmval = 0, DBNull.Value, IdAmval)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = IIf(IdDaramad = 0, DBNull.Value, IdDaramad)
                    Cmd.Parameters.AddWithValue("@IdSarmayeh", SqlDbType.BigInt).Value = IIf(IdSarmayeh = 0, DBNull.Value, IdSarmayeh)
                    Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.NVarChar).Value = BratDate
                    Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(idUser = 0, DBNull.Value, idUser)
                    Cmd.Parameters.AddWithValue("@IdAuto", SqlDbType.BigInt).Value = CLng(LEdit.Text)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                End Using
            End If

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("چک انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayCheck_Info", "SaveGetChk")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub CmbTypeChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTypeChk.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdsave.Focus()
        End If
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdsave.Enabled = True Then Call cmdsave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdcan.Enabled = True Then Call cmdcan_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnRas.Enabled = True Then Call BtnRas_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub GetCheck_Info_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub GetCheck_Info_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        TxtPayDate.ThisText = " "
        If LAction.Text = "00" Or LAction.Text = "10" Then
            CmbTypeChk.Text = CmbTypeChk.Items(0)
        ElseIf LAction.Text = "01" Or LAction.Text = "11" Then
            Me.GetInfoCheck(CLng(LEdit.Text))
        End If
    End Sub

    Private Sub GetInfoCheck(ByVal id As Long)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim Str_Sql As String = ""

            If LState.Text = "21" Then
                Str_Sql = "SELECT Chk_Get_Pay.PayDate, Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Define_Bank.Shobeh, Define_Bank.N_Bank, Define_Bank.Number_N,Define_Bank.nam As BankNam , Chk_Get_Pay.Disc,Chk_Get_Pay.[State], Chk_Get_Pay.Number_Note, IdPeople=" & CLng(TxtIdName.Text) & ", Chk_Id.IdBank, Chk_Id.D_date, Nam=N'سرمایه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID = Chk_Id.IdBank WHERE Chk_Get_Pay.ID=@Id"
            ElseIf LState.Text = "14" Then
                Str_Sql = "SELECT Chk_Get_Pay.PayDate, Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Define_Bank.Shobeh, Define_Bank.N_Bank, Define_Bank.Number_N,Define_Bank.nam As BankNam , Chk_Get_Pay.Disc,Chk_Get_Pay.[State], Chk_Get_Pay.Number_Note, IdPeople=" & CLng(TxtIdName.Text) & ", Chk_Id.IdBank, Chk_Id.D_date, Nam=N'اموال' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID = Chk_Id.IdBank WHERE Chk_Get_Pay.ID=@Id"
            Else
                If String.IsNullOrEmpty(TxtIdName.Text) Then
                    Str_Sql = "SELECT Chk_Get_Pay.PayDate, Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Define_Bank.Shobeh, Define_Bank.N_Bank, Define_Bank.Number_N,Define_Bank.nam As BankNam , Chk_Get_Pay.Disc,Chk_Get_Pay.[State], Chk_Get_Pay.Number_Note, Chk_Id.IdPeople, Chk_Id.IdBank, Chk_Id.D_date, Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID = Chk_Id.IdBank WHERE Chk_Get_Pay.ID=@ID"
                Else
                    If CLng(TxtIdName.Text) > 0 Then
                        Str_Sql = "SELECT Chk_Get_Pay.PayDate, Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Define_Bank.Shobeh, Define_Bank.N_Bank, Define_Bank.Number_N,Define_Bank.nam As BankNam , Chk_Get_Pay.Disc,Chk_Get_Pay.[State], Chk_Get_Pay.Number_Note, Chk_Id.IdPeople, Chk_Id.IdBank, Chk_Id.D_date, Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID = Chk_Id.IdBank WHERE Chk_Get_Pay.ID=@ID"
                    Else
                        If CLng(TxtIdName.Text) = -16 Then
                            Str_Sql = "SELECT Chk_Get_Pay.PayDate, Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Define_Bank.Shobeh, Define_Bank.N_Bank, Define_Bank.Number_N,Define_Bank.nam As BankNam , Chk_Get_Pay.Disc,Chk_Get_Pay.[State], Chk_Get_Pay.Number_Note, IdPeople=-16, Chk_Id.IdBank, Chk_Id.D_date, Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID = Chk_Id.IdBank WHERE Chk_Get_Pay.ID=@Id"
                        End If
                        If CLng(TxtIdName.Text) = -17 Then
                            Str_Sql = "SELECT Chk_Get_Pay.PayDate, Chk_Get_Pay.MoneyChk, Chk_Get_Pay.NumChk, Define_Bank.Shobeh, Define_Bank.N_Bank, Define_Bank.Number_N,Define_Bank.nam As BankNam , Chk_Get_Pay.Disc,Chk_Get_Pay.[State], Chk_Get_Pay.Number_Note, IdPeople=-17, Chk_Id.IdBank, Chk_Id.D_date, Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID = Chk_Id.IdBank WHERE Chk_Get_Pay.ID=@Id"
                        End If
                    End If
                End If
            End If
            Using Cmd As New SqlCommand(Str_Sql, ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    TxtPayDate.ThisText = dtr("Paydate")
                    TxtBank.Text = dtr("N_bank")
                    TxtIdBank.Text = dtr("IdBank")
                    '''''''''
                    T_idbank = If(dtr("IdBank") Is DBNull.Value, 0, dtr("IdBank"))
                    T_NumChk = If(dtr("numchk") Is DBNull.Value, 0, dtr("numchk"))
                    '''''''''
                    TxtShobeh.Text = dtr("Shobeh")
                    TxtNumberChk.Text = dtr("numchk")

                    Tmp_String1 = dtr("numchk")

                    TxtName.Text = dtr("nam")
                    TxtIdName.Text = dtr("IdPeople")
                    TxtNumber.Text = dtr("Number_N")
                    TxtNameChk.Text = dtr("BankNam")
                    TxtMon.Text = dtr("MoneyChk")

                    Tmp_String2 = FormatNumber(dtr("MoneyChk"), 0)

                    TxtSanad.Text = If(dtr("Number_Note") Is DBNull.Value, "", dtr("Number_Note"))
                    TxtDisc.Text = If(dtr("Disc") Is DBNull.Value, "", dtr("Disc"))
                    If dtr("State") = 0 Then
                        CmbTypeChk.SelectedIndex = 0
                    ElseIf dtr("State") = 3 Then
                        CmbTypeChk.SelectedIndex = 1
                    End If
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayCheck_Info", "GetInfoCheck")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtNumberChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumberChk.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtName.Enabled = True Then
                TxtName.Focus()
            Else
                TxtMon.Focus()
            End If
        End If
    End Sub

    Private Sub TxtNumberChk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumberChk.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TxtNumberChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumberChk.TextChanged
        If Not (CheckDigit(TxtNumberChk.Text)) Then
            TxtNumberChk.Text = ""
            Exit Sub
        End If
        TxtNumberChk.Text = CDbl(TxtNumberChk.Text.Trim)
    End Sub

    Private Sub TxtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.LState.Text = "WHERE State=N'جاری'"
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtBank.Focus()
        If IdKala <> 0 Then
            TxtBank.Text = Tmp_Namkala
            TxtIdBank.Text = IdKala
            TxtShobeh.Text = Tmp_TwoGroup
            TxtNameChk.Text = Tmp_String1
            TxtNumber.Text = Tmp_OneGroup
        Else
            TxtBank.Text = ""
            TxtIdBank.Text = ""
            TxtShobeh.Text = ""
            TxtNameChk.Text = ""
            TxtNumber.Text = ""
        End If
    End Sub

    Private Sub LTime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LTime.TextChanged
        Try
            Dim res As Long = 0
            res = CLng(LTime.Text.Trim.Replace("روز", ""))
            If res > 0 Then
                LTime.ForeColor = Color.Black
            ElseIf res < 0 Then
                LTime.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRas.Click
        Try
            Using FrmRas As New FrmRasChk
                FrmRas.ShowDialog()
            End Using

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PayCheck_Info", "BtnRas_Click")
        End Try
    End Sub

End Class