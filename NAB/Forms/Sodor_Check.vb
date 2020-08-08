Imports System.Data.SqlClient
Imports System.Transactions
Public Class Sodor_Check
    Dim Pay_Ds As New DataSet
    Dim Pay_Dta As New SqlDataAdapter()
    Private Sub PayChk()
        Try
            Pay_Ds.Clear()
            If Not Pay_Dta Is Nothing Then
                Pay_Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dim Str_Sql As String = ""
            If LState.Text = "21" Then
                Str_Sql = "SELECT Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,N'سرمایه -' + Define_Sarmayeh.Nam AS Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh ON Chk_Id.IdSarmayeh = Define_Sarmayeh.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=" & CLng(LState.Text) & " AND Chk_Get_Pay.[Number_Type]=" & CLng(LFac.Text) & " AND Chk_Get_Pay.Kind=1"
            ElseIf LState.Text = "14" Then
                Str_Sql = "SELECT Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,N'اموال -' + Define_Amval.Nam AS Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval ON Chk_Id.IdAmval = Define_Amval.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=" & CLng(LState.Text) & " AND Chk_Get_Pay.[Number_Type]=" & CLng(LFac.Text) & " AND Chk_Get_Pay.Kind=1"
            Else
                If CLng(LIdname.Text) > 0 Then
                    Str_Sql = "SELECT Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Define_People.Nam FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=" & CLng(LState.Text) & " AND Chk_Get_Pay.[Number_Type]=" & CLng(LFac.Text) & " AND Chk_Get_Pay.Kind=1"
                Else
                    If CLng(LIdname.Text) = -16 Then
                        Str_Sql = "SELECT Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Nam=N'هزینه متفرقه' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=" & CLng(LState.Text) & " AND Chk_Get_Pay.[Number_Type]=" & CLng(LFac.Text) & " AND Chk_Get_Pay.Kind=1"
                    End If
                    If CLng(LIdname.Text) = -17 Then
                        Str_Sql = "SELECT Chk_Get_Pay.ID,[GetDate],PayDate,MoneyChk,NumChk,Define_Bank.Shobeh,Define_Bank.N_Bank,Define_Bank.Number_N,Number_Note,Nam=N'هزینه فاکتور خرید' FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=" & CLng(LState.Text) & " AND Chk_Get_Pay.[Number_Type]=" & CLng(LFac.Text) & " AND Chk_Get_Pay.Kind=1"
                    End If
                End If
            End If
            Pay_Dta = New SqlDataAdapter(Str_Sql, DataSource)
            Pay_Dta.Fill(Pay_Ds)
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = Pay_Ds.Tables(0)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "PayChk")
            Me.Close()
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

    Private Sub BtnNewPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewPay.Click
        Try
            Using CheckInfo As New PayCheck_Info
                CheckInfo.CmbTypeChk.Items.Add("در جریان وصول")
                CheckInfo.TxtName.Text = LName.Text
                CheckInfo.TxtIdName.Text = LIdname.Text
                CheckInfo.TxtName.Enabled = False
                CheckInfo.LState.Text = LState.Text
                CheckInfo.LIdFac.Text = LFac.Text
                CheckInfo.LAction.Text = "10"
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "BtnNewPay_Click")
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
            If str = 6 Then DelCheck(DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value)
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "BtnDelPay_Click")
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
            If AreYouEditCheck(DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value) = False Then
                MessageBox.Show("چک پرداختی مورد نظر در حال حاضر قابل ویرایش نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.RefreshBank()
                Exit Sub
            End If
            Using CheckInfo As New PayCheck_Info
                CheckInfo.CmbTypeChk.Items.Add("در جریان وصول")
                CheckInfo.TxtName.Text = LName.Text
                CheckInfo.TxtIdName.Text = LIdname.Text
                CheckInfo.TxtName.Enabled = False
                CheckInfo.LState.Text = LState.Text
                CheckInfo.LIdFac.Text = LFac.Text
                CheckInfo.LAction.Text = "11"
                CheckInfo.LEdit.Text = DGV2.Item("Cln_ID1", DGV2.CurrentRow.Index).Value
                CheckInfo.ShowDialog()
            End Using
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "BtnEditPay_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "CalCulateMoney")
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
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnEditPay.Enabled = True Then Call BtnEditPay_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub Check_Ontime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LADD.Text = "0"
        Me.PayChk()
        Me.CalCulateMoney()
        DGV2.Columns("Cln_People1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub RefreshBank()
        Try
            Pay_Ds.Clear()
            Pay_Dta.Fill(Pay_Ds)
            Me.CalCulateMoney()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Sodor_Check", "RefreshBank")
        End Try
    End Sub

End Class