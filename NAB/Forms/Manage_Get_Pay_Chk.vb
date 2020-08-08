Imports System.Data.SqlClient
Imports System.Transactions
Public Class Manage_Get_Pay_Chk
    Dim GetDs As New DataTable
    Dim GetDta As New SqlDataAdapter
    Dim GetDV As New DataView
    '///////////////////////////////////
    Dim PayDs As New DataTable
    Dim PayDta As New SqlDataAdapter
    Dim PayDV As New DataView
    Dim ref As Boolean = False
    Private Sub ListGetChk(ByVal state As Integer)
        Try
            Me.Enabled = False
            GetDs.Clear()
            If Not GetDs Is Nothing Then
                GetDs.Dispose()
            End If

            Dim str As String = ""
            If state = 4 Then
                str = "SELECT ListChk.Tell ,GetDate ,Kind ,Current_Kind ,ListChk.ID ,PayDate ,MoneyChk ,NumChk ,ListChk.Shobeh ,ListChk.N_Bank ,ListChk.Number_N ,Number_Note ,Disc ,ListChk.Nam,Define_Bank .n_bank +'-' +Define_Bank .number_n  As brat  FROM (SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell,Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ")UNION ALL SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") UNION All SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") UNION All SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") ) AS ListChk INNER JOIN Chk_Id ON Chk_Id .Id=ListChk.ID INNER JOIN Define_Bank ON Define_Bank .ID =Chk_Id.IdBank "
            Else
                str = "SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell,Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ")UNION ALL SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'درآمد' + '-'+ Define_Daramad .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") UNION All SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'سرمایه' + '-'+ Define_Sarmayeh .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") UNION All SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'اموال' + '-'+ Define_Amval .Nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ")"
            End If
            '''''''''''''''''''''''''''
            GetDta = New SqlDataAdapter(str, DataSource)
            GetDta.Fill(GetDs)
            If Not GetDs.Columns.Contains("C_Time") Then GetDs.Columns.Add("C_Time", Type.GetType("System.Double"))
            If Not GetDs.Columns.Contains("C_day") Then GetDs.Columns.Add("C_Day", Type.GetType("System.String"))
            Dim StringDate As New NumberToString
            For i As Integer = 0 To GetDs.Rows.Count - 1
                If Not String.IsNullOrEmpty(GetDs.Rows(i).Item("paydate")) Then
                    GetDs.Rows(i).Item("C_Time") = SUBDAY(GetDs.Rows(i).Item("paydate"), GetDs.Rows(i).Item("GetDate"))
                    GetDs.Rows(i).Item("C_Day") = StringDate.PersianWeekDays(StringDate.PersianToDateConvertor(GetDs.Rows(i).Item("paydate")))
                End If
            Next
            DGV1.AutoGenerateColumns = False
            GetDV = GetDs.DefaultView
            DGV1.DataSource = GetDV
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "ListGetChk")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub
    Private Sub ListPayChk(ByVal state As Integer)
        Try
            Me.Enabled = False
            PayDs.Clear()
            If Not PayDs Is Nothing Then
                PayDs.Dispose()
            End If
            '''''''''''''''''''''''''''
            'PayDta = New SqlDataAdapter("SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ")  UNION  SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ")UNION ALL SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =16)) UNION SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") AND (Chk_Get_Pay.Current_Type =16) UNION SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ")UNION ALL SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =17)) UNION SELECT Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") AND (Chk_Get_Pay.Current_Type =17)", DataSource)
            PayDta = New SqlDataAdapter("SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell,Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") UNION SELECT ISNULL(Define_People.Tell1,'') +'-'+ ISNULL(Define_People.Tell2,'') As Tell,Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") UNION ALL SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =16)) UNION SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") AND (Chk_Get_Pay.Current_Type =16) UNION ALL SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =17)) UNION SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & ") AND (Chk_Get_Pay.Current_Type =17) UNION ALL SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =21)) UNION SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'سرمایه-' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh  = Define_Sarmayeh .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =21)) UNION ALL SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Disc,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval  = Define_Amval .ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id.IdBank  WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =14)) UNION SELECT Tell=N'',Chk_Get_Pay.GetDate,Chk_Get_Pay.Kind,Chk_Get_Pay.Current_Kind,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'اموال-' + Define_Amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval  ON Chk_Id.IdAmval   = Define_Amval  .ID   WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =" & state & " AND (Chk_Get_Pay.Current_Type =14))", DataSource)
            PayDta.Fill(PayDs)
            If Not PayDs.Columns.Contains("C_Time") Then PayDs.Columns.Add("C_Time", Type.GetType("System.Double"))
            If Not PayDs.Columns.Contains("C_day") Then PayDs.Columns.Add("C_Day", Type.GetType("System.String"))
            Dim StringDate As New NumberToString
            For i As Integer = 0 To PayDs.Rows.Count - 1
                If Not String.IsNullOrEmpty(PayDs.Rows(i).Item("paydate")) Then
                    PayDs.Rows(i).Item("C_Time") = SUBDAY(PayDs.Rows(i).Item("paydate"), PayDs.Rows(i).Item("GetDate"))
                    PayDs.Rows(i).Item("C_Day") = StringDate.PersianWeekDays(StringDate.PersianToDateConvertor(PayDs.Rows(i).Item("paydate")))
                End If
            Next

            DGV1.AutoGenerateColumns = False
            PayDV = PayDs.DefaultView
            If ChkShow.Checked = True Then
                PayDV.RowFilter = If(ChkOnly.Checked = False, "", "Kind=0 And Current_Kind=1")
            ElseIf ChkShow.Checked = False Then
                PayDV.RowFilter = "Kind=1 And Current_Kind=1"
            End If
            DGV1.DataSource = PayDV
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "ListPayChk")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub Manage_Get_Pay_Chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub Manage_Get_Pay_Chk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Access_Form = Get_Access_Form("F41")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "ورود", "", "")
                End If
            End If
        Else
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "ورود", "", "")
        End If

        ToolPayDate.Visible = False
        RdoGet.Checked = True
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        ChkAzMon.Enabled = False
        ChkTaMon.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        TxtMon1.Enabled = False
        TxtMon2.Enabled = False
        TxtMon1.Text = "0"
        TxtMon2.Text = "0"
        TxtSChk.Text = "0"
        ChkShow.Enabled = False
        ' ChkShow.Checked = False
        ChkOnly.Enabled = False
        ChkOnly.Checked = False
        DGV1.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Array.Resize(ListChkArray, 0)
        SetButton()

        
    End Sub

    Private Sub SetButton()
        Try
            BtnChange.Enabled = True
            BtnPrint.Enabled = True
            BtnState.Enabled = True
            Button1.Enabled = True
            Access_Form = Get_Access_Form(If(RdoGet.Checked = True, "F42", "F43"))
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnChange.Enabled = False
                    BtnPrint.Enabled = False
                    BtnState.Enabled = False
                    Button1.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnChange.Enabled = False
                        BtnPrint.Enabled = False
                        BtnState.Enabled = False
                        Button1.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnChange.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnPrint.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnState.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            Button1.Enabled = False
                        End If
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnChange.Enabled = False
                Button1.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub RdoGet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoGet.CheckedChanged
        If RdoGet.Checked = True Then
            ref = False
            ChkShow.Enabled = False
            ChkOnly.Enabled = False
            Me.ListGetChk(GetState(Rdo0.Name))
            Rdo0.Checked = True
            If RdoPay.Enabled = True Then Rdo4.Enabled = True
            RdoAll.Checked = True
            GetDV.RowFilter = ""
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
            SetButton()
            ref = True
        End If
    End Sub
    Private Function GetState(ByVal nam As String) As Integer
        Try
            Select Case UCase(nam)
                Case "RDO0" : Return 0
                Case "RDO1" : Return 1
                Case "RDO2" : Return 2
                Case "RDO3" : Return 3
                Case "RDO4" : Return 4
            End Select
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "GetState")
            Return -1
        End Try
    End Function
    Private Sub RdoPay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoPay.CheckedChanged
        If RdoPay.Checked = True Then
            ref = False
            ChkShow.Enabled = True
            'ChkShow.Checked = True
            If ChkShow.Checked = True Then ChkOnly.Enabled = True
            Me.ListPayChk(GetState(Rdo0.Name))
            Rdo0.Checked = True
            Rdo4.Enabled = False
            RdoAll.Checked = True
            PayDV.RowFilter = If(ChkShow.Checked = True, "", "(Kind=1 And Current_Kind=1)")
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
            SetButton()
            ref = True
        End If
    End Sub

    Private Sub Rdodate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdodate.CheckedChanged
        If Rdodate.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If

            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
        Else
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate2.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.ThisText = GetDate()
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub RdoMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoMon.CheckedChanged
        If RdoMon.Checked = True Then
            ChkAzMon.Enabled = True
            ChkTaMon.Enabled = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            '''''''''''''''''''''
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
            '''''''''''''''''''''
        Else
            ChkAzMon.Checked = False
            ChkTaMon.Checked = False
            ChkAzMon.Enabled = False
            ChkTaMon.Enabled = False
            TxtMon1.Enabled = False
            TxtMon2.Enabled = False
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
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
        If Rdodate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND GetDate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND PayDate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If

            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
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
        If Rdodate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND GetDate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND PayDate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If

            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub ChkAzMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMon.CheckedChanged
        If ChkAzMon.Checked = True Then
            TxtMon1.Text = "0"
            TxtMon1.Enabled = True
            TxtMon1.Focus()
            TxtMon1.SelectAll()
        Else
            TxtMon1.Text = "0"
            TxtMon1.Enabled = False
        End If
        If RdoMon.Checked = True Then
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub ChkTaMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMon.CheckedChanged
        If ChkTaMon.Checked = True Then
            TxtMon2.Text = "0"
            TxtMon2.Enabled = True
            TxtMon2.Focus()
            TxtMon2.SelectAll()
        Else
            TxtMon2.Text = "0"
            TxtMon2.Enabled = False
        End If
        If RdoMon.Checked = True Then
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                End If
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                End If
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, "", "(Kind=1 And Current_Kind=1)")
                End If
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub TxtMon1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon2.Focus()
    End Sub

    Private Sub TxtMon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon1.KeyPress
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

    Private Sub TxtMon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon1.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon1.Text.Replace(",", "")))) Then
                TxtMon1.Text = "0"
                TxtMon1.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon1.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon1.Text.Replace(",", ""))
                TxtMon1.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon1.Text = CDbl(TxtMon1.Text)
            End If
            If RdoMon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text)
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text)
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text)
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                Else
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = ""
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                    End If
                End If
            End If
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMon2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon2.KeyPress
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

    Private Sub TxtMon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon2.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon2.Text.Replace(",", "")))) Then
                TxtMon2.Text = "0"
                TxtMon2.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon2.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon2.Text.Replace(",", ""))
                TxtMon2.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon2.Text = CDbl(TxtMon2.Text)
            End If
            If RdoMon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text)
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & " AND moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text)
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = "moneychk>=" & CDbl(TxtMon1.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text)
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = "moneychk<=" & CDbl(TxtMon2.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                Else
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = ""
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                    End If
                End If
            End If
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then FarsiDate2.Focus()
    End Sub

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        CalculateSelectMoney()
    End Sub

    Private Sub DGV1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.GotFocus
        CalculateSelectMoney()
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        Try
            If Not DGV1.Item("Cln_PayDate", e.RowIndex).Value Is DBNull.Value Then
                If DGV1.Item("Cln_PayDate", e.RowIndex).Value = GetDate() Then
                    DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value > GetDate() Then
                    DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value < GetDate() Then
                    DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                End If
            End If

            If DGV1.Item("Cln_Kind", e.RowIndex).Value = 0 And DGV1.Item("Cln_CKind", e.RowIndex).Value = 1 Then
                DGV1.Rows(e.RowIndex).Cells(0).Style.BackColor = Color.SpringGreen
            Else
                DGV1.Rows(e.RowIndex).Cells(0).Style.BackColor = DGV1.Rows(e.RowIndex).Cells(1).Style.BackColor
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChange.Click

        Try
            BtnChange.Focus()
            DGV1.EndEdit()
            Dim c As Integer = 0
            Array.Resize(ListChkArray, 0)
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Select", i).Value = True Then
                        Array.Resize(ListChkArray, ListChkArray.Length + 1)
                        ListChkArray(ListChkArray.Length - 1).Kind = If(RdoGet.Checked = True, 0, 1)
                        ListChkArray(ListChkArray.Length - 1).Id = DGV1.Item("Cln_ID", i).Value
                        ListChkArray(ListChkArray.Length - 1).NumChk = DGV1.Item("Cln_NumChk", i).Value


                        Dim state As String = 0
                        If Rdo0.Checked = True Then
                            state = 0
                        ElseIf Rdo1.Checked = True Then
                            state = 1
                        ElseIf Rdo2.Checked = True Then
                            state = 2
                        ElseIf Rdo3.Checked = True Then
                            state = 3
                        ElseIf Rdo4.Checked = True Then
                            state = 4
                        End If
                        ListChkArray(ListChkArray.Length - 1).State = state
                        c += 1
                    End If
                Next
                If c = 0 Then
                    MessageBox.Show("هیچ چکی برای تغییر وضعیت انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("هیچ چکی برای تغییر وضعیت وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Enabled = False
            If Rdo3.Checked = True Then
                If MessageBox.Show("آیا برای حذف چکهای تضمینی مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                For i As Integer = 0 To ListChkArray.Length - 1
                    Me.DelCheck(ListChkArray(i).Id)
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "تغییر وضعیت", "حذف چک تضمینی" & If(RdoGet.Checked = True, " دریافتی با سریال ", " پرداختی با سریال ") & ListChkArray(i).NumChk, "")
                Next
            Else
                Using FrmConvert As New ConvertStateGet
                    If RdoPay.Checked = True Then
                        FrmConvert.RdoBrat.Enabled = False
                    End If
                    If Rdo0.Checked = True Then
                        FrmConvert.RdoDarVosol.Enabled = False
                        FrmConvert.RdoVosol.Checked = True
                    ElseIf Rdo1.Checked = True Then
                        FrmConvert.RdoVosol.Enabled = False
                        FrmConvert.RdoDarVosol.Checked = True
                    ElseIf Rdo2.Checked = True Then
                        FrmConvert.RdoBargasht.Enabled = False
                        FrmConvert.RdoDarVosol.Checked = True
                    ElseIf Rdo3.Checked = True Then
                        Exit Sub
                    ElseIf Rdo4.Checked = True Then
                        FrmConvert.RdoBrat.Checked = True
                    End If
                    FrmConvert.ShowDialog()
                End Using
            End If
            Me.RefreshBank()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "BtnChange_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Function DelCheck(ByVal Id As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
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
                MessageBox.Show("اطلاعات قابل حذف شدن نیست لطفا دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "DelCheck")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("چکی جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            BtnPrint.Focus()
            DGV1.EndEdit()
            Me.Enabled = False
            Array.Resize(ListChkPrintArray, 0)
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then
                    Array.Resize(ListChkPrintArray, ListChkPrintArray.Length + 1)
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Id = DGV1.Item("Cln_ID", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).GetDate = DGV1.Item("Cln_GetDate", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).PayDate = DGV1.Item("Cln_PayDate", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).nam = DGV1.Item("Cln_People", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).numchk = DGV1.Item("Cln_NumChk", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Bank = DGV1.Item("Cln_Bank", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Shobeh = DGV1.Item("Cln_Shobeh", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Mon = CDbl(DGV1.Item("Cln_MoneyChk", i).Value)
                    ListChkPrintArray(ListChkPrintArray.Length - 1).NumBank = DGV1.Item("Cln_Number", i).Value
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Type = If(RdoGet.Checked = True, "گزارش اسناد دریافتی", "گزارش اسناد پرداختی")
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Ras = TxtRasChk.Text
                    ListChkPrintArray(ListChkPrintArray.Length - 1).Tell = DGV1.Item("Cln_Tell", i).Value

                    If Rdo0.Checked = True Then
                        ListChkPrintArray(ListChkPrintArray.Length - 1).StateChk = "در جریان وصول"
                    ElseIf Rdo1.Checked = True Then
                        ListChkPrintArray(ListChkPrintArray.Length - 1).StateChk = "وصول شده"
                    ElseIf Rdo2.Checked = True Then
                        ListChkPrintArray(ListChkPrintArray.Length - 1).StateChk = "برگشتی"
                    ElseIf Rdo3.Checked = True Then
                        ListChkPrintArray(ListChkPrintArray.Length - 1).StateChk = "تضمینی"
                    ElseIf Rdo4.Checked = True Then
                        ListChkPrintArray(ListChkPrintArray.Length - 1).StateChk = "برات"
                    End If

                End If
            Next
            Me.Enabled = True
            If ListChkPrintArray.Length <= 0 Then
                MessageBox.Show("چکی جهت چاپ انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "چاپ", "چاپ لیست چکهای " & If(RdoGet.Checked = True, " دریافتی ", " پرداختی ") & ListChkPrintArray(ListChkPrintArray.Length - 1).StateChk, "")

            FrmPrint.CHoose = "CHKPRINT"
            FrmPrint.ShowDialog()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "BtnPrint_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Try
            Dim c As Integer = 0
            Dim tmp As Integer = 0
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Select", i).Value = True Then
                        c += 1
                    End If
                Next
                If c <= 0 Then
                    MessageBox.Show("چک یا چکهایی را جهت خرج کردن انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("هیچ چک دریافتی برای انتخاب وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If SelectChk() Then Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "BtnSelect_Click")
        End Try
    End Sub
    Private Function SelectChk() As Boolean
        Dim nam As String = ""
        If CLng(LIdName.Text) = -16 Then
            nam = "هزینه متفرقه"
        ElseIf CLng(LIdName.Text) = -17 Then
            nam = "هزینه ف.خرید " & LIdFac.Text
        ElseIf CLng(LIdName.Text) = -21 Then
            nam = "سرمایه"
        ElseIf CLng(LIdName.Text) = -14 Then
            nam = "اموال"
        ElseIf CLng(LIdName.Text) > 0 Then
            nam = GetNamPeolpe(CLng(LIdName.Text))
        End If

        Dim sqltransaction As New CommittableTransaction
        Try
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then
                    If AreYouEditCheck(DGV1.Item("Cln_ID", DGV1.CurrentRow.Index).Value) = False Then
                        MessageBox.Show("چک دریافتی به سند " & DGV1.Item("Cln_ID", i).Value & " در حال حاضر قابل خرج کردن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            Next
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=@Current_Type,Current_Number_Type=@Current_Number_Type,Current_Kind=@Current_Kind,Current_Type_Chk=@Current_Type_Chk,Activ=@Activ,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=@Current_IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Select", i).Value = True Then
                        Cmd.Parameters.AddWithValue("@Current_Type", SqlDbType.Int).Value = CInt(LState.Text)
                        Cmd.Parameters.AddWithValue("@Current_Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.Parameters.AddWithValue("@Current_Kind", SqlDbType.Int).Value = 1
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = DGV1.Item("Cln_ID", i).Value
                        Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "خرج شده به " & nam
                        Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.BigInt).Value = 0
                        If CLng(LIdName.Text) > 0 Then
                            Cmd.Parameters.AddWithValue("@Current_Type_Chk", SqlDbType.BigInt).Value = 10
                            Cmd.Parameters.AddWithValue("@Current_IdPeople", SqlDbType.BigInt).Value = CLng(LIdName.Text)
                        Else
                            If CLng(LIdName.Text) = -16 Or CLng(LIdName.Text) = -17 Or CLng(LIdName.Text) = -21 Or CLng(LIdName.Text) = -14 Then
                                Cmd.Parameters.AddWithValue("@Current_Type_Chk", SqlDbType.BigInt).Value = 11
                                Cmd.Parameters.AddWithValue("@Current_IdPeople", SqlDbType.BigInt).Value = DBNull.Value

                                ' If CLng(LIdName.Text) = -21 Then
                                ' Cmd.Parameters.AddWithValue("@IdSarmayeh", SqlDbType.BigInt).Value = LAS.Text
                                'Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = DBNull.Value
                                'ElseIf CLng(LIdName.Text) = -14 Then
                                '   Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = LAS.Text
                                '  Cmd.Parameters.AddWithValue("@IdSarmayeh", SqlDbType.BigInt).Value = DBNull.Value
                                'Else
                                '   Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = DBNull.Value
                                '  Cmd.Parameters.AddWithValue("@IdSarmayeh", SqlDbType.BigInt).Value = DBNull.Value
                                'End If

                            End If
                        End If
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    End If
                Next
            End Using

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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "SelectChk")
            End If
            Return False
        End Try
    End Function
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Rdo0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo0.CheckedChanged
        If ref = False Then Exit Sub
        If Rdo0.Checked = True Then
            If RdoGet.Checked = True Then
                Me.ListGetChk(GetState(Rdo0.Name))
            Else
                Me.ListPayChk(GetState(Rdo0.Name))
            End If
            RdoAll.Checked = True
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        End If
    End Sub

    Private Sub Rdo1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo1.CheckedChanged
        If ref = False Then Exit Sub
        If Rdo1.Checked = True Then
            If RdoGet.Checked = True Then
                Me.ListGetChk(GetState(Rdo1.Name))
            Else
                Me.ListPayChk(GetState(Rdo1.Name))
            End If
            RdoAll.Checked = True
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        End If
    End Sub

    Private Sub Rdo2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo2.CheckedChanged
        If ref = False Then Exit Sub
        If Rdo2.Checked = True Then
            If RdoGet.Checked = True Then
                Me.ListGetChk(GetState(Rdo2.Name))
            Else
                Me.ListPayChk(GetState(Rdo2.Name))
            End If
            RdoAll.Checked = True
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        End If
    End Sub

    Private Sub Rdo3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo3.CheckedChanged
        If ref = False Then Exit Sub
        If Rdo3.Checked = True Then
            If RdoGet.Checked = True Then
                Me.ListGetChk(GetState(Rdo3.Name))
            Else
                Me.ListPayChk(GetState(Rdo3.Name))
            End If
            RdoAll.Checked = True
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        End If
    End Sub

    Private Sub Rdo4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo4.CheckedChanged
        If ref = False Then Exit Sub
        If Rdo4.Checked = True Then
            Me.ListGetChk(GetState(Rdo4.Name))
            DGV1.Columns("Cln_Disc").Width = 65
            DGV1.Columns("Cln_shobeh").Width = 60
            DGV1.Columns("Cln_Bank").Width = 70
            DGV1.Columns("Cln_People").Width = 90
            DGV1.Columns("Cln_day").Width = 60
            DGV1.Columns("Cln_Getdate").Width = 70
            DGV1.Columns("Cln_paydate").Width = 70
            DGV1.Columns("Cln_brat").Visible = True
            RdoAll.Checked = True
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        Else
            DGV1.Columns("Cln_brat").Visible = False
            DGV1.Columns("Cln_Disc").Width = 75
            DGV1.Columns("Cln_shobeh").Width = 65
            DGV1.Columns("Cln_Bank").Width = 80
            DGV1.Columns("Cln_People").Width = 100
            DGV1.Columns("Cln_day").Width = 65
            DGV1.Columns("Cln_Getdate").Width = 78
            DGV1.Columns("Cln_paydate").Width = 78
        End If
    End Sub

    Private Sub ChkSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelect.CheckedChanged
        If DGV1.RowCount > 0 Then
            If ChkSelect.Checked = True Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    DGV1.Item("Cln_Select", i).Value = True
                Next
            ElseIf ChkSelect.Checked = False Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    DGV1.Item("Cln_Select", i).Value = False
                Next
            End If
        End If
        CalculateSelectMoney()
    End Sub
    Private Sub CalculateMoney()
        Txtallchk.Text = "0"
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                Txtallchk.Text = CDbl(Txtallchk.Text) + CDbl(DGV1.Item("Cln_MoneyChk", i).Value)
            Next
            If Txtallchk.Text.Length > 3 Then
                Dim str As String
                str = Format$(Txtallchk.Text.Replace(",", ""))
                Txtallchk.Text = Format$(Val(str), "###,###,###")
            Else
                Txtallchk.Text = CDbl(Txtallchk.Text)
            End If
        Else
            Txtallchk.Text = "0"
        End If
    End Sub

    Private Sub CalculateSelectMoney()
        DGV1.EndEdit()
        TxtSChk.Text = "0"
        TxtRasChk.Text = "0"
        Dim count As Double = 0
        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Item("Cln_Select", i).Value = True Then
                    TxtSChk.Text = CDbl(TxtSChk.Text) + CDbl(DGV1.Item("Cln_MoneyChk", i).Value)
                    count += CDbl(DGV1.Item("Cln_MoneyChk", i).Value) * If(CLng(DGV1.Item("Cln_Time", i).Value) = 0, 1, CLng(DGV1.Item("Cln_Time", i).Value))
                End If
            Next
            If TxtSChk.Text.Length > 3 Then
                Dim str As String
                str = Format$(TxtSChk.Text.Replace(",", ""))
                TxtSChk.Text = Format$(Val(str), "###,###,###")
            Else
                TxtSChk.Text = CDbl(TxtSChk.Text)
            End If
            TxtRasChk.Text = Replace(Format$(count / CDbl(TxtSChk.Text), "###.##"), ".", "/")
            If UCase(TxtRasChk.Text) = "NAN" Then TxtRasChk.Text = "0"
        Else
            TxtSChk.Text = "0"
            TxtRasChk.Text = 0
        End If
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            If RdoGet.Checked = True Then
                GetDV.RowFilter = ""
            ElseIf RdoPay.Checked = True Then
                PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", "(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub RdoDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDay.CheckedChanged
        If RdoDay.Checked = True Then
            If RdoGet.Checked = True Then
                GetDV.RowFilter = "PayDate='" & GetDate() & "'"
            ElseIf RdoPay.Checked = True Then
                PayDV.RowFilter = "PayDate='" & GetDate() & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", "AND (Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub RdoLast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoLast.CheckedChanged
        If RdoLast.Checked = True Then
            If RdoGet.Checked = True Then
                GetDV.RowFilter = "PayDate<'" & GetDate() & "'"
            ElseIf RdoPay.Checked = True Then
                PayDV.RowFilter = "PayDate<'" & GetDate() & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub RdoFuture_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoFuture.CheckedChanged
        If RdoFuture.Checked = True Then
            If RdoGet.Checked = True Then
                GetDV.RowFilter = "PayDate>'" & GetDate() & "'"
            ElseIf RdoPay.Checked = True Then
                PayDV.RowFilter = "PayDate>'" & GetDate() & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub FarsiDate1_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate1.TextChanging
        If Rdodate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND GetDate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND PayDate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If

            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub FarsiDate2_TextChanging(ByVal sender As Object, ByVal e As String) Handles FarsiDate2.TextChanging
        If Rdodate.Checked = True Then
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND GetDate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND PayDate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If

            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                If RdoGet.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        GetDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'"
                    ElseIf ToolGetDate.Visible = True Then
                        GetDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'"
                    End If
                ElseIf RdoPay.Checked = True Then
                    If ToolPayDate.Visible = True Then
                        PayDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    ElseIf ToolGetDate.Visible = True Then
                        PayDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                    End If
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetChk.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnChange.Enabled = True Then Call BtnChange_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnPrint.Enabled = True Then Call BtnPrint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnState.Enabled = True Then Call BtnState_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If ToolGetDate.Visible = False Then
                ToolGetDate.Visible = True
                ToolPayDate.Visible = False
            ElseIf ToolPayDate.Visible = False Then
                ToolPayDate.Visible = True
                ToolGetDate.Visible = False
            End If
            If Rdodate.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If RdoGet.Checked = True Then
                        If ToolPayDate.Visible = True Then
                            GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND GetDate<='" & FarsiDate2.ThisText & "'"
                        ElseIf ToolGetDate.Visible = True Then
                            GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND PayDate<='" & FarsiDate2.ThisText & "'"
                        End If
                    ElseIf RdoPay.Checked = True Then
                        If ToolPayDate.Visible = True Then
                            PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "' AND Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                        ElseIf ToolGetDate.Visible = True Then
                            PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "' AND Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                        End If
                    End If

                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    If RdoGet.Checked = True Then
                        If ToolPayDate.Visible = True Then
                            GetDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'"
                        ElseIf ToolGetDate.Visible = True Then
                            GetDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'"
                        End If
                    ElseIf RdoPay.Checked = True Then
                        If ToolPayDate.Visible = True Then
                            PayDV.RowFilter = "Getdate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                        ElseIf ToolGetDate.Visible = True Then
                            PayDV.RowFilter = "Paydate>='" & FarsiDate1.ThisText & "'" & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                        End If
                    End If
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    If RdoGet.Checked = True Then
                        If ToolPayDate.Visible = True Then
                            GetDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'"
                        ElseIf ToolGetDate.Visible = True Then
                            GetDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'"
                        End If
                    ElseIf RdoPay.Checked = True Then
                        If ToolPayDate.Visible = True Then
                            PayDV.RowFilter = "Getdate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                        ElseIf ToolGetDate.Visible = True Then
                            PayDV.RowFilter = "Paydate<='" & FarsiDate2.ThisText & "'" & If(ChkShow.Checked = True, "", " AND(Kind=1 And Current_Kind=1)")
                        End If
                    End If
                Else
                    If RdoGet.Checked = True Then
                        GetDV.RowFilter = ""
                    ElseIf RdoPay.Checked = True Then
                        PayDV.RowFilter = If(ChkShow.Checked = True, "", "(Kind=1 And Current_Kind=1)")
                    End If
                End If
            End If
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        End If
    End Sub
    Private Sub RefreshBank()
        If RdoGet.Checked = True Then
            Me.ListGetChk(GetState(Rdo0.Name))
            Rdo0.Checked = True
            If RdoPay.Enabled = True Then Rdo4.Enabled = True
            RdoAll.Checked = True
            GetDV.RowFilter = ""
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        ElseIf RdoPay.Checked = True Then
            Me.ListPayChk(GetState(Rdo0.Name))
            Rdo0.Checked = True
            Rdo4.Enabled = False
            RdoAll.Checked = True
            PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", "Kind=0 And Current_Kind=1"), "(Kind=1 And Current_Kind=1)")
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        End If
        SetButton()
    End Sub

    Private Sub ChkShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShow.CheckedChanged
        If RdoPay.Checked = True Then
            ChkOnly.Enabled = True
            Me.RefreshBank()
            If ChkShow.Checked = True Then
                ChkOnly.Enabled = True
            Else
                ChkOnly.Enabled = False
                ChkOnly.Checked = False
            End If
        End If
    End Sub

    Private Sub BtnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnState.Click
        Try
            BtnState.Focus()
            DGV1.EndEdit()
            Dim c As Integer = 0
            Dim Id As Long = 0
            Dim chk As String = ""
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Select", i).Value = True Then
                        c += 1
                        Id = DGV1.Item("Cln_ID", i).Value
                        chk = DGV1.Item("Cln_NumChk", i).Value
                    End If
                Next
                If c = 0 Then
                    MessageBox.Show("هیچ چکی جهت گزارش سابقه چک انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If c > 1 Then
                    MessageBox.Show("جهت گزارش سابقه چک بایستی فقط یک چک انتخاب شده باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("هیچ چکی جهت گزارش سابقه چک وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "سابقه چک", "چاپ سابقه چک" & If(RdoGet.Checked = True, " دریافتی با سریال ", " پرداختی با سریال ") & chk, "")

            Using FPrint As New FrmPrint
                FPrint.PrintSQl = "SELECT  Chk_State.IdUser,Chk_State.Disc, Stat=Case Chk_State.Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END, Chk_State.D_Date ,Chk_Get_Pay.ID ,[GetDate] ,PayDate ,NumChk ,MoneyChk ,Number_Note As Sanad,Chk_Get_Pay.Disc  AS DiscChk,StateChk=Case Chk_Get_Pay.Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END ,NBank=Case Kind WHEN 0 THEN Chk_Get_Pay.N_Bank WHEN 1 THEN (SELECT  Define_Bank.n_bank FROM Chk_Id INNER JOIN Define_Bank ON Chk_Id.IdBank = Define_Bank.ID WHERE Chk_Id.Id =" & Id & ")  ELSE N'نا مشخص' END ,Shobeh=Case Kind WHEN 0 THEN Chk_Get_Pay.Shobeh  WHEN 1 THEN (SELECT  Define_Bank.shobeh  FROM Chk_Id INNER JOIN Define_Bank ON Chk_Id.IdBank = Define_Bank.ID WHERE Chk_Id.Id =" & Id & ")  ELSE N'نا مشخص' END ,Number_N=Case Kind WHEN 0 THEN Chk_Get_Pay.Number_N   WHEN 1 THEN (SELECT  Define_Bank.number_n   FROM Chk_Id INNER JOIN Define_Bank ON Chk_Id.IdBank = Define_Bank.ID WHERE Chk_Id.Id =" & Id & ")  ELSE N'نا مشخص' END ,OneP=Case WHEN  [TYPE]<=13 AND Kind =0 And (Current_Kind =0 Or Current_Kind =1)  THEN (SELECT  Define_People.Nam FROM  Chk_Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID  WHERE Chk_Id .Id =" & Id & ") WHEN   [TYPE]>13 AND Kind =1 AND Current_Kind =1  THEN N'اسناد پرداختی'  WHEN [TYPE]=14 THEN (SELECT N'اموال' + '-' + nam FROM Define_Amval  WHERE Define_Amval .ID =(SELECT IdAmval  FROM Get_Pay_Amval WHERE Id =(SELECT Number_Type  FROM Chk_Get_Pay WHERE Id=" & Id & " ))) WHEN [TYPE]=15 THEN (SELECT N'درآمد' + '-' + nam FROM Define_Daramad WHERE Define_Daramad.ID =(SELECT IdDaramad  FROM Chk_Id WHERE Chk_Id .Id = " & Id & " )) WHEN [TYPE]=21 THEN (SELECT N'سرمایه' + '-' + nam FROM Define_Sarmayeh  WHERE Define_Sarmayeh .ID =(SELECT IdSarmayeh  FROM Get_Pay_Sarmayeh WHERE Id =(SELECT Number_Type  FROM Chk_Get_Pay WHERE Id=" & Id & " ))) WHEN [TYPE]=16 THEN N'هزینه متفرقه' WHEN [TYPE]=17 THEN N'هزینه ف.خرید' WHEN [TYPE]=18 THEN N'صندوق' WHEN [TYPE]=19 THEN N'امور چک' WHEN [TYPE]=20 THEN N'بانک به بانک' ELSE N'نا مشخص' END ,TwoP=Case WHEN  Kind =0 And Current_Kind =0 THEN N'اسناد دریافتی'  WHEN  (Kind =0 Or Kind =1)  And (Current_Kind =1) And Current_Type <=13  THEN (SELECT  Define_People.Nam FROM  Chk_Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople  = Define_People.ID  WHERE Chk_Id .Id =" & Id & ") WHEN Current_TYPE=14 THEN (SELECT N'اموال' + '-' + nam FROM Define_Amval  WHERE Define_Amval .ID =(SELECT IdAmval  FROM Get_Pay_Amval WHERE Id =(SELECT Current_Number_Type  FROM Chk_Get_Pay WHERE Id=" & Id & " ))) WHEN Current_TYPE=15 THEN N'درآمد' WHEN Current_TYPE=16 THEN N'هزینه متفرقه' WHEN Current_TYPE=17 THEN N'هزینه ف.خرید' WHEN Current_TYPE=18 THEN N'صندوق' WHEN Current_TYPE=19 THEN N'امور چک' WHEN Current_TYPE=20 THEN N'بانک به بانک' WHEN Current_TYPE=21 THEN (SELECT N'سرمایه' + '-' + nam FROM Define_Sarmayeh  WHERE Define_Sarmayeh .ID =(SELECT IdSarmayeh  FROM Get_Pay_Sarmayeh WHERE Id =(SELECT Current_Number_Type  FROM Chk_Get_Pay WHERE Id=" & Id & " ))) ELSE N'نا مشخص' END FROM Chk_State,Chk_Get_Pay  WHERE Chk_State.Id=" & Id & " AND Chk_Get_Pay .ID =" & Id
                FPrint.CHoose = "STATECHK"
                FPrint.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "BtnState_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim c As Integer = 0
            Dim Id As Long = 0
            Dim chk As String = ""
            Dim Disc As String = ""
            Button1.Focus()
            DGV1.EndEdit()
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    If DGV1.Item("Cln_Select", i).Value = True Then
                        c += 1
                        Id = DGV1.Item("Cln_ID", i).Value
                        chk = DGV1.Item("Cln_NumChk", i).Value
                        Disc = If(DGV1.Item("Cln_Disc", i).Value Is DBNull.Value, "", DGV1.Item("Cln_Disc", i).Value)
                    End If
                Next
                If c = 0 Then
                    MessageBox.Show("هیچ چکی جهت اصلاح توضیحات انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If c > 1 Then
                    MessageBox.Show("جهت اصلاح توضیحات بایستی فقط یک چک انتخاب شده باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("هیچ چکی جهت اصلاح توضیحات وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Using FPrint As New FrmDisc
                FPrint.LState.Text = "CHK"
                FPrint.LIdChk.Text = Id
                FPrint.TxtDisc.Text = Disc
                FPrint.ShowDialog()
                If FPrint.LAdd.Text = "0" Then
                    Me.Enabled = True
                    Exit Sub
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت چک", "اصلاح توضیحات", "اصلاح توضیحات چک" & If(RdoGet.Checked = True, " دریافتی با سریال ", " پرداختی با سریال ") & chk, "")

                RefreshBank()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Get_Pay_Chk", "Button1_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub TxtNumChk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumChk.KeyPress
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

    Private Sub TxtNumChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumChk.TextChanged
        Try
            If String.IsNullOrEmpty(TxtNumChk.Text) Then Exit Sub
            If Not (CheckDigit(Format$(TxtNumChk.Text.Replace(",", "")))) Then
                TxtNumChk.Text = "0"
                TxtNumChk.SelectAll()
                Exit Sub
            End If
            TxtNumChk.Text = CDbl(TxtNumChk.Text)
            If RdoNumChk.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "NumChk=" & CDbl(TxtNumChk.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "NumChk=" & CDbl(TxtNumChk.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", "(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSanad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSanad.KeyPress
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

    Private Sub TxtSanad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSanad.TextChanged
        Try
            If String.IsNullOrEmpty(TxtSanad.Text) Then Exit Sub
            If Not (CheckDigit(Format$(TxtSanad.Text.Replace(",", "")))) Then
                TxtSanad.Text = "0"
                TxtSanad.SelectAll()
                Exit Sub
            End If
            TxtSanad.Text = CLng(TxtSanad.Text)
            If RdoSanad.Checked = True Then
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = "Id=" & CLng(TxtSanad.Text)
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = "Id=" & CLng(TxtSanad.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
                End If
            Else
                If RdoGet.Checked = True Then
                    GetDV.RowFilter = ""
                ElseIf RdoPay.Checked = True Then
                    PayDV.RowFilter = If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", "(Kind=0 And Current_Kind=1)"), "(Kind=1 And Current_Kind=1)")
                End If
            End If
            CalculateMoney()
            ChkSelect.Checked = False
            CalculateSelectMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RdoSanad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoSanad.CheckedChanged
        If RdoSanad.Checked = True Then
            TxtSanad.Enabled = True
            If RdoGet.Checked = True Then
                If Not String.IsNullOrEmpty(TxtSanad.Text) Then GetDV.RowFilter = "Id=" & CLng(TxtSanad.Text)
            ElseIf RdoPay.Checked = True Then
                If Not String.IsNullOrEmpty(TxtSanad.Text) Then PayDV.RowFilter = "Id=" & CLng(TxtSanad.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
            End If
            TxtSanad.Focus()
        Else
            TxtSanad.Enabled = False
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub RdoNumChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoNumChk.CheckedChanged
        If RdoNumChk.Checked = True Then
            TxtNumChk.Enabled = True
            If RdoGet.Checked = True Then
                If Not String.IsNullOrEmpty(TxtNumChk.Text) Then GetDV.RowFilter = "NumChk=" & CDbl(TxtNumChk.Text)
            ElseIf RdoPay.Checked = True Then
                If Not String.IsNullOrEmpty(TxtNumChk.Text) Then PayDV.RowFilter = "NumChk=" & CDbl(TxtNumChk.Text) & If(ChkShow.Checked = True, If(ChkOnly.Checked = False, "", " AND(Kind=0 And Current_Kind=1)"), " AND(Kind=1 And Current_Kind=1)")
            End If
            TxtNumChk.Focus()
        Else
            TxtNumChk.Enabled = False
        End If
        CalculateMoney()
        ChkSelect.Checked = False
        CalculateSelectMoney()
    End Sub

    Private Sub ChkOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOnly.CheckedChanged
        RefreshBank()
    End Sub

    Private Sub DGV1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV1.RowPrePaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        Try
            If Not DGV1.Item("Cln_PayDate", e.RowIndex).Value Is DBNull.Value Then
                If DGV1.Item("Cln_PayDate", e.RowIndex).Value = GetDate() Then
                    DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value > GetDate() Then
                    DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                ElseIf DGV1.Item("Cln_PayDate", e.RowIndex).Value < GetDate() Then
                    DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                End If
            End If

            If DGV1.Item("Cln_Kind", e.RowIndex).Value = 0 And DGV1.Item("Cln_CKind", e.RowIndex).Value = 1 Then
                DGV1.Rows(e.RowIndex).Cells(0).Style.BackColor = Color.SpringGreen
            Else
                DGV1.Rows(e.RowIndex).Cells(0).Style.BackColor = DGV1.Rows(e.RowIndex).Cells(1).Style.BackColor
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.Sorted
        Try
            ChkSelect.Checked = False
        Catch ex As Exception

        End Try
    End Sub
End Class