Imports System.Data.SqlClient
Imports System.Transactions
Public Class Check_Ontime
    Dim Get_Ds As New DataSet
    Dim Get_Dta As New SqlDataAdapter()
    Dim Pay_Ds As New DataSet
    Dim Pay_Dta As New SqlDataAdapter()
    Private Sub GetChk()
        Try
            Get_Ds.Clear()
            If Not Get_Dta Is Nothing Then
                Get_Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Get_Dta = New SqlDataAdapter("SELECT k=0,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.Current_Kind=0 UNION ALL SELECT k=0,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.Current_Kind=1 AND  Chk_Get_Pay.Current_Number_Type <>0 UNION ALL SELECT k=1,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,N'اموال- ' + Define_Amval.nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval ON Chk_Id.IdAmval = Define_Amval.ID WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.Current_Kind=0 UNION ALL SELECT k=2,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,N'سرمایه- ' + Define_Sarmayeh.nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh = Define_Sarmayeh.ID WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.Current_Kind=0 UNION ALL SELECT k=3,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,N'درآمد- ' + Define_Daramad.nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad ON Chk_Id.IdDaramad = Define_Daramad.ID WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=0 AND Chk_Get_Pay.Current_Kind=0", DataSource)
            Get_Dta.Fill(Get_Ds)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = Get_Ds.Tables(0)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "GetChk")
            Me.Close()
        End Try
    End Sub
    Private Sub PayChk()
        Try
            Pay_Ds.Clear()
            If Not Pay_Dta Is Nothing Then
                Pay_Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Pay_Dta = New SqlDataAdapter("SELECT k=0,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=1 AND Chk_Get_Pay.Current_Kind =1 UNION ALL SELECT k=1,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,N'اموال- ' + Define_Amval.nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval ON Chk_Id.IdAmval = Define_Amval.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=1 AND Chk_Get_Pay.Current_Kind =1 UNION ALL SELECT k=2,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,N'سرمایه- ' + Define_Sarmayeh.nam As Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.Idsarmayeh = Define_Sarmayeh.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=1 AND Chk_Get_Pay.Current_Kind =1 UNION ALL SELECT k=3,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,N'درآمد- ' + Define_Daramad.nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad ON Chk_Id.IdDaramad = Define_Daramad.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=1 AND Chk_Get_Pay.Current_Kind =1 UNION ALL SELECT k=4,Chk_Get_Pay.ID,PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,N'هزینه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=11 AND Chk_Get_Pay.[Current_Type] =16 AND  Chk_Get_Pay.[Number_Type]=0 AND Chk_Get_Pay.Kind=1 AND Chk_Get_Pay.Current_Kind =1", DataSource)
            Pay_Dta.Fill(Pay_Ds)
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = Pay_Ds.Tables(0)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "PayChk")
            Me.Close()
        End Try
    End Sub
    Private Sub BtnNewGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewGet.Click
        Try
            Using CheckInfo As New GetCheck_Info
                CheckInfo.CmbTypeChk.Items.Add("در جریان وصول")
                CheckInfo.CmbTypeChk.Items.Add("تضمینی")
                CheckInfo.CmbTypeChk.Items.Add("برات")
                CheckInfo.LAction.Text = "00"
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "BtnNewGet_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnDelGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelGet.Click
        Try
           
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هيچ چک دریافتی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد چک دریافتی انتخاب شده حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                DelCheck(DGV1.Item("Cln_ID", DGV1.CurrentRow.Index).Value)
            End If

            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "BtnDelGet_Click")
            Me.RefreshBank()
        End Try
    End Sub
    Private Function DelCheck(ByVal Id As Long) As Boolean
        If AreYouEditCheck(Id) = False Then
            MessageBox.Show("اطلاعات قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Return False
        End If
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

            If TabControl1.TabPages(0).Focus = True Then
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اولیه اسناد دریافتی", "حذف", "حذف چک دریافتی با سریال:" & DGV1.Item("Cln_NumChk", DGV1.CurrentRow.Index).Value & " با مبلغ " & FormatNumber(DGV1.Item("Cln_MoneyChk", DGV1.CurrentRow.Index).Value, 0), "")
            Else
                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اولیه اسناد پرداختی", "حذف", "حذف چک پرداختی با سریال:" & DGV2.Item("Cln_NumChk1", DGV2.CurrentRow.Index).Value & " با مبلغ " & FormatNumber(DGV2.Item("Cln_MoneyChk1", DGV2.CurrentRow.Index).Value, 0), "")
            End If

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل حذف شدن نیست لطفا دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_OneTime", "DelGetCheck")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub BtnEditGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditGet.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هيچ چک دریافتی براي ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            If DGV1.Item("Cln_K", DGV1.CurrentRow.Index).Value = 1 Then
                MessageBox.Show("چک اموال اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf DGV1.Item("Cln_K", DGV1.CurrentRow.Index).Value = 2 Then
                MessageBox.Show("چک سرمایه اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf DGV1.Item("Cln_K", DGV1.CurrentRow.Index).Value = 3 Then
                MessageBox.Show("چک درآمد اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If AreYouEditCheck(DGV1.Item("Cln_ID", DGV1.CurrentRow.Index).Value) = False Then
                MessageBox.Show("چک دریافتی مورد نظر در حال حاضر قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            Using CheckInfo As New GetCheck_Info
                CheckInfo.CmbTypeChk.Items.Add("در جریان وصول")
                CheckInfo.CmbTypeChk.Items.Add("تضمینی")
                CheckInfo.CmbTypeChk.Items.Add("برات")
                CheckInfo.LAction.Text = "01"
                CheckInfo.LEdit.Text = DGV1.Item("Cln_ID", DGV1.CurrentRow.Index).Value
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "BtnEditGet_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnNewPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewPay.Click
        Try
            Using CheckInfo As New PayCheck_Info
                CheckInfo.CmbTypeChk.Items.Add("در جریان وصول")
                CheckInfo.CmbTypeChk.Items.Add("تضمینی")
                CheckInfo.LAction.Text = "00"
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "BtnNewPay_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnDelPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelPay.Click
        Try

            If DGV2.RowCount <= 0 Then
                MessageBox.Show("هيچ چک پرداختی براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد چک پرداختی انتخاب شده حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then
                DelCheck(DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value)
            End If

            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "BtnDelPay_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnEditPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditPay.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("هيچ چک پرداختی براي ویرایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If

            If DGV2.Item("Cln_K1", DGV2.CurrentRow.Index).Value = 1 Then
                MessageBox.Show("چک اموال اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf DGV2.Item("Cln_K1", DGV2.CurrentRow.Index).Value = 2 Then
                MessageBox.Show("چک سرمایه اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf DGV2.Item("Cln_K1", DGV2.CurrentRow.Index).Value = 3 Then
                MessageBox.Show("چک درآمد اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf DGV2.Item("Cln_K1", DGV2.CurrentRow.Index).Value = 4 Then
                MessageBox.Show("چک هزینه اول دوره قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If AreYouEditCheck(DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value) = False Then
                MessageBox.Show("چک پرداختی مورد نظر در حال حاضر قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Using CheckInfo As New PayCheck_Info
                CheckInfo.CmbTypeChk.Items.Add("در جریان وصول")
                CheckInfo.CmbTypeChk.Items.Add("تضمینی")
                CheckInfo.LAction.Text = "01"
                CheckInfo.LEdit.Text = DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "BtnEditPay_Click")
            Me.RefreshBank()
        End Try
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

    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        If DGV2.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub

    Private Sub Check_Ontime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub CalCulateMoney()
        Try
            TxtallmoneyGet.Text = "0"
            TxtallmoneyPay.Text = "0"
            Dim result As Double = 0
            If DGV1.RowCount > 0 Then
                For i As Integer = 0 To DGV1.RowCount - 1
                    result += CDbl(DGV1.Item("Cln_MoneyChk", i).Value)
                Next
                TxtallmoneyGet.Text = Format(result, "###,###")
            End If
            result = 0
            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    result += CDbl(DGV2.Item("Cln_MoneyChk1", i).Value)
                Next
                TxtallmoneyPay.Text = Format(result, "###,###")
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_Ontime", "CalCulateMoney")
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Asnademali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnNewGet.Enabled = True Then Call BtnNewGet_Click(Nothing, Nothing)
            Else
                If BtnNewPay.Enabled = True Then Call BtnNewPay_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnDelGet.Enabled = True Then Call BtnDelGet_Click(Nothing, Nothing)
            Else
                If BtnDelPay.Enabled = True Then Call BtnDelPay_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnEditGet.Enabled = True Then Call BtnEditGet_Click(Nothing, Nothing)
            Else
                If BtnEditPay.Enabled = True Then Call BtnEditPay_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If TabControl1.TabPages(0).Focus = True Then
                If BtnPrintGet.Enabled = True Then Call BtnPrintGet_Click(Nothing, Nothing)
            Else
                If BtnPrintPay.Enabled = True Then Call BtnPrintPay_Click(Nothing, Nothing)
            End If
        End If
    End Sub
    Private Sub Check_Ontime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F9")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
            End If
        End If

        Me.GetChk()
        Me.PayChk()
        Me.CalCulateMoney()
        DGV1.Columns("Cln_People").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_People1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.SetButton()
    End Sub
    Private Sub SetButton()
        Try
            '''''''GetChk
            Access_Form = Get_Access_Form("F10")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnNewGet.Enabled = False
                    BtnDelGet.Enabled = False
                    BtnEditGet.Enabled = False
                    BtnPrintGet.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnNewGet.Enabled = False
                        BtnDelGet.Enabled = False
                        BtnEditGet.Enabled = False
                        BtnPrintGet.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnNewGet.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnDelGet.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnEditGet.Enabled = False
                        End If
                        Try
                            If Access_Form.Substring(4, 1) = 0 Then
                                BtnPrintGet.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnPrintGet.Enabled = False
                        End Try
                    End If
                End If
            End If

            '''''''PayChk
            Access_Form = Get_Access_Form("F11")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnNewPay.Enabled = False
                    BtnDelPay.Enabled = False
                    BtnEditPay.Enabled = False
                    BtnPrintPay.Enabled = False
                Else
                    If Access_Form.Substring(0, 1) = 0 Then
                        BtnNewPay.Enabled = False
                        BtnDelPay.Enabled = False
                        BtnEditPay.Enabled = False
                        BtnPrintPay.Enabled = False
                    Else
                        If Access_Form.Substring(1, 1) = 0 Then
                            BtnNewPay.Enabled = False
                        End If
                        If Access_Form.Substring(2, 1) = 0 Then
                            BtnDelPay.Enabled = False
                        End If
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnEditPay.Enabled = False
                        End If
                        Try
                            If Access_Form.Substring(4, 1) = 0 Then
                                BtnPrintPay.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnPrintPay.Enabled = False
                        End Try
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnNewGet.Enabled = False
                BtnDelGet.Enabled = False
                BtnEditGet.Enabled = False

                BtnNewPay.Enabled = False
                BtnDelPay.Enabled = False
                BtnEditPay.Enabled = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_OnTime", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub RefreshBank()
        Try
            Get_Ds.Clear()
            Get_Dta.Fill(Get_Ds)

            Pay_Ds.Clear()
            Pay_Dta.Fill(Pay_Ds)
            Me.SetButton()
            Me.CalCulateMoney()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_OnTime", "RefreshBank")
        End Try
    End Sub

    Private Sub BtnPrintPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintPay.Click
        Try
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("چکی پرداختی جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Array.Resize(ListChkPrintArray, 0)
            For i As Integer = 0 To DGV2.RowCount - 1
                Array.Resize(ListChkPrintArray, ListChkPrintArray.Length + 1)
                ListChkPrintArray(ListChkPrintArray.Length - 1).Id = DGV2.Item("Cln_ID1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).GetDate = ""
                ListChkPrintArray(ListChkPrintArray.Length - 1).PayDate = DGV2.Item("Cln_PayDate1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).nam = DGV2.Item("Cln_People1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).numchk = DGV2.Item("Cln_NumChk1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Bank = DGV2.Item("Cln_Bank1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Shobeh = DGV2.Item("Cln_Shobeh1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Mon = CDbl(DGV2.Item("Cln_MoneyChk1", i).Value)
                ListChkPrintArray(ListChkPrintArray.Length - 1).NumBank = DGV2.Item("Cln_Number1", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Type = "گزارش اسناد پرداختی اول دوره"
                ListChkPrintArray(ListChkPrintArray.Length - 1).Tell = ""
            Next
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اولیه اسناد پرداختی", "چاپ", "", "")
            Me.Enabled = True
            FrmPrint.CHoose = "CHKONEPRINT"
            FrmPrint.ShowDialog()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_OnTime", "BtnPrintPay_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnPrintGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintGet.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("چکی دریافتی جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Array.Resize(ListChkPrintArray, 0)
            For i As Integer = 0 To DGV1.RowCount - 1
                Array.Resize(ListChkPrintArray, ListChkPrintArray.Length + 1)
                ListChkPrintArray(ListChkPrintArray.Length - 1).Id = DGV1.Item("Cln_ID", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).GetDate = ""
                ListChkPrintArray(ListChkPrintArray.Length - 1).PayDate = DGV1.Item("Cln_PayDate", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).nam = DGV1.Item("Cln_People", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).numchk = DGV1.Item("Cln_NumChk", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Bank = DGV1.Item("Cln_Bank", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Shobeh = DGV1.Item("Cln_Shobeh", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Mon = CDbl(DGV1.Item("Cln_MoneyChk", i).Value)
                ListChkPrintArray(ListChkPrintArray.Length - 1).NumBank = DGV1.Item("Cln_Number", i).Value
                ListChkPrintArray(ListChkPrintArray.Length - 1).Type = "گزارش اسناد دریافتی اول دوره"
                ListChkPrintArray(ListChkPrintArray.Length - 1).Tell = ""
            Next
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی اولیه اسناد دریافتی", "چاپ", "", "")
            Me.Enabled = True
            FrmPrint.CHoose = "CHKONEPRINT"
            FrmPrint.ShowDialog()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Check_OnTime", "BtnPrintGet_Click")
            Me.Enabled = True
        End Try
    End Sub
End Class