Imports System.Data.SqlClient
Imports System.Transactions
Public Class Frosh_Check
    Dim Pay_Ds As New DataSet
    Dim Pay_Dta As New SqlDataAdapter()
    Private Sub GetChk()
        Try
            Pay_Ds.Clear()
            If Not Pay_Dta Is Nothing Then
                Pay_Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dim Str_Sql As String = ""
            Str_Sql = "SELECT Chk_Get_Pay.Type,Chk_Get_Pay.Number_Type,Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") UNION ALL SELECT Chk_Get_Pay.Type,Chk_Get_Pay.Number_Type,Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'درآمد' +' - ' + Define_Daramad .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") UNION ALL SELECT Chk_Get_Pay.Type,Chk_Get_Pay.Number_Type,Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'سرمایه' +' - ' + Define_Sarmayeh .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .Idsarmayeh  ELSE (SELECT Idsarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=Number_Type ) END )  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ")) UNION ALL SELECT Chk_Get_Pay.Type,Chk_Get_Pay.Number_Type,Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Shobeh,N_Bank,Number_N,Number_Note,Disc,N'اموال' +' - ' + Define_amval .Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .IdAmval ELSE (SELECT IdAmval FROM Get_Pay_Amval WHERE Id=Number_Type) END ) = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") UNION All  SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .Idsarmayeh  ELSE (SELECT Idsarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=Number_Type ) END ) = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =" & CLng(LState.Text) & ") AND (Chk_Get_Pay.Current_Number_Type =" & CLng(LFac.Text) & ")))"
            
            '''''''''''''''''''''''''''
            Pay_Dta = New SqlDataAdapter(Str_Sql, DataSource)
            Pay_Dta.Fill(Pay_Ds)
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = Pay_Ds.Tables(0)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frosh_Check", "GetChk")
            Me.Close()
        End Try
    End Sub
    Private Function DelCheck(ByVal Id As Long, ByVal Type As Long, ByVal Number_Type As Long) As Boolean
        If GetStateChk(Id) <> 0 Then
            MessageBox.Show("اطلاعات قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.RefreshBank()
            Return False
        End If
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser,Activ=@Activ WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = Id
                Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@Activ", SqlDbType.BigInt).Value = 1
                Cmd.ExecuteNonQuery()
            End Using

            If LState.Text = "14" Then
                Dim IdAmval As Long = 0
                If Type = 14 Then
                    Using Cmd As New SqlCommand("SELECT  IdAmval FROM Get_Pay_Amval WHERE Id=@Id", ConectionBank)
                        Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Number_Type
                        IdAmval = Cmd.ExecuteScalar
                    End Using
                End If

                Using Cmd As New SqlCommand("Update Chk_Id SET IdAmval=@IdAmval   WHERE Id=@IDAuto ", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = IIf(IdAmval = 0, DBNull.Value, IdAmval)
                    Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = Id
                    Cmd.ExecuteNonQuery()
                End Using
            End If

            If LState.Text = "21" Then
                Dim Idsarmayeh As Long = 0
                If Type = 21 Then
                    Using Cmd As New SqlCommand("SELECT  IdSarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=@Id", ConectionBank)
                        Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Number_Type
                        Idsarmayeh = Cmd.ExecuteScalar
                    End Using
                End If
                Using Cmd As New SqlCommand("Update Chk_Id SET Idsarmayeh=@Idsarmayeh   WHERE Id=@IDAuto ", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Idsarmayeh", SqlDbType.BigInt).Value = IIf(Idsarmayeh = 0, DBNull.Value, Idsarmayeh)
                    Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = Id
                    Cmd.ExecuteNonQuery()
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
                MessageBox.Show("اطلاعات قابل حذف شدن نیست لطفا دوباره امتحان کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frosh_Check", "DelGetCheck")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.RefreshBank()
            Return False
        End Try
    End Function

    Private Sub BtnNewPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewPay.Click
        Try
            Using CheckInfo As New Manage_Get_Pay_Chk
                CheckInfo.RdoPay.Enabled = False
                CheckInfo.Rdo1.Enabled = False
                CheckInfo.Rdo2.Enabled = False
                CheckInfo.Rdo3.Enabled = False
                CheckInfo.Rdo4.Enabled = False
                CheckInfo.BtnChange.Visible = False
                CheckInfo.BtnPrint.Visible = False
                CheckInfo.ToolStripStatusLabel2.Visible = False
                CheckInfo.ToolStripStatusLabel3.Visible = False
                If LState.Text = "21" Then
                    CheckInfo.LIdName.Text = "-21"
                    CheckInfo.LAS.Text = LIdname.Text
                ElseIf LState.Text = "14" Then
                    CheckInfo.LIdName.Text = "-14"
                    CheckInfo.LAS.Text = LIdname.Text
                Else
                    CheckInfo.LIdName.Text = LIdname.Text
                End If
                CheckInfo.LState.Text = LState.Text
                CheckInfo.LIdFac.Text = LFac.Text
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frosh_Check", "BtnNewPay_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub BtnDelPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelPay.Click
        Try

            If DGV2.RowCount <= 0 Then
                MessageBox.Show("هيچ چک خرج شده ای براي حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Dim str As String = MessageBox.Show("ايا مي خواهيد چک خرج شده انتخابی حذف شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If str = 6 Then DelCheck(DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value, DGV2.Item("Cln_Type", DGV2.CurrentRow.Index).Value, DGV2.Item("Cln_Number_Type", DGV2.CurrentRow.Index).Value)
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frosh_Check", "BtnDelPay_Click")
            Me.RefreshBank()
        End Try
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub Check_Ontime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub CalCulateMoney()
        Try
            TxtallmoneyPay.Text = "0"
            TxtRasChk.Text = "0"
            Dim result As Double = 0
            Dim count As Double = 0
            Dim C_day As Long = 0
            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    result += CDbl(DGV2.Item("Cln_MoneyChk1", i).Value)
                    C_day = (SUBDAY(DGV2.Item("Cln_PayDate1", i).Value, DGV2.Item("Cln_GetDate", i).Value))
                    count += (If(C_day = 0, 1, C_day) * CDbl(DGV2.Item("Cln_MoneyChk1", i).Value))
                Next
                TxtallmoneyPay.Text = Format(result, "###,###")
                TxtRasChk.Text = Replace(Format$(count / result, "###.##"), ".", "/")
                If UCase(TxtRasChk.Text) = "NAN" Then TxtRasChk.Text = "0"
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frosh_Check", "CalCulateMoney")
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PayMoney.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnNewPay.Enabled = True Then Call BtnNewPay_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnDelPay.Enabled = True Then Call BtnDelPay_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub Check_Ontime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LADD.Text = "0"
        Me.GetChk()
        Me.CalCulateMoney()
        DGV2.Columns("Cln_People1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub RefreshBank()
        Try
            Pay_Ds.Clear()
            Pay_Dta.Fill(Pay_Ds)
            Me.CalCulateMoney()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frosh_Check", "RefreshBank")
        End Try
    End Sub

End Class