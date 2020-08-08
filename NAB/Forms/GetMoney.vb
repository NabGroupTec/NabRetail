Imports System.Data.SqlClient
Imports System.Transactions
Public Class GetMoney
    Dim darsad As Long = 1
    Dim ds_Box As New DataSet
    Dim dta_Box As New SqlDataAdapter()
    Dim dt As New DataTable

    Private Sub GetMoney_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtName.Focus()
    End Sub

    Private Sub PayFactor_Sell_Amani_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnCancle.Enabled = False And LOk.Text = "0" Then
            e.Cancel = True
            Exit Sub
        End If
        If LEdit.Text = "0" Then
            If LOk.Text = "0" And (Not String.IsNullOrEmpty(LIdFac.Text)) And (Not LIdFac.Text = "0") Then
                RoolBackSanad(LIdFac.Text)
            End If
        End If
    End Sub
    Private Function RoolBackSanad(ByVal Idfac As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            Dim ds As New DataSet
            Dim dta As New SqlDataAdapter()
            dta = New SqlDataAdapter("SELECT ID FROM  Chk_Get_Pay WHERE ([Type] =12 ) AND (Number_Type = " & Idfac & ")", DataSource)
            dta.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Using CmdChk As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        CmdChk.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Tables(0).Rows(i).Item(0)
                        CmdChk.ExecuteNonQuery()
                        CmdChk.Parameters.Clear()
                    Next
                End Using
            End If
            ds.Dispose()
            dta.Dispose()
            Using Cmd As New SqlCommand("DELETE FROM Get_Pay_Sanad WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Idfac
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
                MessageBox.Show("اطلاعات سند قابل برگشت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "RoolBackSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub PayFactor_Buy_Amani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub TxtDiscountC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountC.GotFocus
        darsad = 1
        TxtDiscountC.SelectAll()
    End Sub

    Private Sub TxtDiscountC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscountC.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDarCash.Focus()
    End Sub

    Private Sub TxtDiscountC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDiscountC.KeyPress
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

    Private Sub TxtDiscountC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountC.LostFocus
        TxtDarDisC.Text = Math.Round(CDbl(TxtDarDisC.Text), 2)
    End Sub

    Private Sub TxtDiscountC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountC.TextChanged
        If darsad = 1 Then
            Try
                If Not (CheckDigit(Format$(TxtDiscountC.Text.Replace(",", "")))) Then
                    TxtDiscountC.Text = "0"
                    TxtDarDisC.Text = "0"
                    TxtDiscountC.SelectAll()
                    Exit Sub
                End If
                Dim str As String
                If TxtDiscountC.Text.Length > 3 Then
                    SendKeys.Send("{end}")
                    str = Format$(TxtDiscountC.Text.Replace(",", ""))
                    TxtDiscountC.Text = Format$(Val(str), "###,###,###")
                Else
                    TxtDiscountC.Text = CDbl(TxtDiscountC.Text)
                End If
                '//////////////
                If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)

                If GetMonMandeh() <> 0 Then
                    Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / GetMonMandeh())
                    TxtDarDisC.Text = Math.Round(tmp, 2)
                Else
                    TxtDarDisC.Text = 0
                End If

                Me.CalCulateMon()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TxtCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCash.GotFocus
        darsad = 1
        TxtCash.SelectAll()
    End Sub

    Private Sub TxtCash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash.KeyDown
        If e.KeyCode = Keys.Enter Then Txtbank.Focus()
    End Sub

    Private Sub TxtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash.KeyPress
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

    Private Sub TxtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash.TextChanged
        If darsad = 1 Then
            Try
                If Not (CheckDigit(Format$(TxtCash.Text.Replace(",", "")))) Then
                    TxtCash.Text = "0"
                    TxtDarCash.Text = "0"
                    TxtCash.SelectAll()
                    Exit Sub
                End If
                Dim str As String
                If TxtCash.Text.Length > 3 Then
                    SendKeys.Send("{end}")
                    str = Format$(TxtCash.Text.Replace(",", ""))
                    TxtCash.Text = Format$(Val(str), "###,###,###")
                Else
                    TxtCash.Text = CDbl(TxtCash.Text)
                End If
                '//////////////
                If Not TxtDarCash.Text.Trim.Contains(".") Then TxtDarCash.Text = CDbl(TxtDarCash.Text)

                If GetMonMandeh() <> 0 Then
                    Dim tmp As Double = ((CDbl(TxtCash.Text) * 100) / GetMonMandeh())
                    TxtDarCash.Text = Math.Round(tmp, 2)
                Else
                    TxtDarCash.Text = 0
                End If

                Me.CalCulateMon()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Txtbank_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbank.GotFocus
        Txtbank.SelectAll()
    End Sub

    Private Sub Txtbank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbank.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk.Focus()
        If e.KeyCode = Keys.Delete Then
            Txtbank.Text = "0"
            TxtbankName.Clear()
            TxtDiscbank.Clear()
            TxtIdBank.Clear()
        End If
    End Sub

    Private Sub Txtbank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtbank.TextChanged
        Try
            If Not (CheckDigit(Format$(Txtbank.Text.Replace(",", "")))) Then
                Txtbank.Text = "0"
                Txtbank.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If Txtbank.Text.Length > 3 Then
                str = Format$(Txtbank.Text.Replace(",", ""))
                Txtbank.Text = Format$(Val(str), "###,###,###")
            Else
                Txtbank.Text = CDbl(Txtbank.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtChk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtChk.GotFocus
        TxtChk.SelectAll()
    End Sub

    Private Sub TxtChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtChk.Text.Replace(",", "")))) Then
                TxtChk.Text = "0"
                TxtChk.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtChk.Text.Length > 3 Then
                str = Format$(TxtChk.Text.Replace(",", ""))
                TxtChk.Text = Format$(Val(str), "###,###,###")
            Else
                TxtChk.Text = CDbl(TxtChk.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalCulateMon()
        Try
            LMandeh.Text = CDbl(TxtDiscountC.Text) + CDbl(TxtCash.Text) + CDbl(Txtbank.Text) + CDbl(TxtChk.Text)
            If String.IsNullOrEmpty(TxtMoein.Text.Trim) Then
                LLend.Text = "0"
            Else
                If TxtMoein.Text.Contains("بدهکار") Then
                    Dim Mon As Double = CDbl(TxtMoein.Text.Replace("بدهکار", "").Trim) - If(String.IsNullOrEmpty(LMandeh.Text.Trim), 0, CDbl(LMandeh.Text))
                    LLend.Text = IIf(Mon = 0, 0, FormatNumber(Mon, 0))
                ElseIf TxtMoein.Text.Contains("بستانکار") Then
                    Dim Mon As Double = CDbl(TxtMoein.Text.Replace("بستانکار", "").Trim) + If(String.IsNullOrEmpty(LMandeh.Text.Trim), 0, CDbl(LMandeh.Text))
                    LLend.Text = IIf(Mon = 0, 0, FormatNumber(Mon, 0))
                Else
                    LLend.Text = LMandeh.Text
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetMonMandeh() As Double
        Try
            If String.IsNullOrEmpty(TxtMoein.Text.Trim) Then
                Return 0
            Else
                If TxtMoein.Text.Contains("بدهکار") Then
                    Dim Mon As Double = CDbl(TxtMoein.Text.Replace("بدهکار", "").Trim)
                    Return IIf(Mon = 0, 0, FormatNumber(Mon, 0))
                ElseIf TxtMoein.Text.Contains("بستانکار") Then
                    Dim Mon As Double = CDbl(TxtMoein.Text.Replace("بستانکار", "").Trim)
                    Return IIf(Mon = 0, 0, FormatNumber(Mon, 0))
                Else
                    Return CDbl(LMandeh.Text)
                End If
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub LMandeh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LMandeh.TextChanged
        Dim str As String
        If LMandeh.Text.Length > 3 Then
            str = Format$(LMandeh.Text.Replace(",", ""))
            LMandeh.Text = Format$(Val(str), "###,###,###")
        Else
            LMandeh.Text = CDbl(LMandeh.Text)
        End If
    End Sub

    Private Sub BtnHavaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHavaleh.Click
        Try
            Using FrmHavale As New FrmHavalehBank
                If CDbl(Txtbank.Text) > 0 Then
                    FrmHavale.TxtBank.Text = TxtbankName.Text.Trim
                    FrmHavale.TxtIdBank.Text = TxtIdBank.Text.Trim
                    FrmHavale.TxtMon.Text = CDbl(Txtbank.Text)
                Else
                    FrmHavale.TxtMon.Text = "0"
                End If
                FrmHavale.ShowDialog()
                If FrmHavale.LAdd.Text = "0" Then Exit Sub
                TxtbankName.Text = FrmHavale.TxtBank.Text
                TxtIdBank.Text = FrmHavale.TxtIdBank.Text
                Txtbank.Text = CDbl(FrmHavale.TxtMon.Text)
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnHavaleh_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "GetMoney.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnRelation.Enabled = True Then BtnRelation_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If String.IsNullOrEmpty(TxtIdName.Text) Then
                MessageBox.Show("هیچ طرف حسابی جهت نمایش وضعیت مالی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using FValue As New FrmValue
                FValue.LCode.Text = CLng(TxtIdName.Text)
                FValue.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Or TxtDate.ThisText > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Try
            If String.IsNullOrEmpty(TxtIdName.Text) Or String.IsNullOrEmpty(TxtName.Text) Then
                MessageBox.Show("هیچ طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If
            If CDbl(TxtCash.Text) > 0 And CmbBox.Text = "" Then
                MessageBox.Show("صندوقی جهت واریز نقدی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbBox.Focus()
                Exit Sub
            End If

            If CDbl(LMandeh.Text) <= 0 Then
                MessageBox.Show("هیچ مبلغی جهت دریافت تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtDate.ThisText) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Exit Sub
            End If

            If CDbl(LMandeh.Text) < CDbl(LLimit.Text) Then
                MessageBox.Show("جمع پرداختی وعده ها بیشتر از جمع کل سند مربوطه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbBox.Focus()
                Exit Sub
            End If

            If LEdit.Text = "0" Then
                If Savepay() Then
                    LOk.Text = "1"
                    Me.Close()
                End If
            Else
                If Editpay() Then
                    LOk.Text = "1"
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnSave_Click")
        End Try
    End Sub
    Private Function Savepay() As Boolean
        Dim IdDisC As Long = 0
        Dim IdCashBox As Long = 0
        Dim IdCashMoein As Long = 0
        Dim IdBank As Long = 0
        Dim IdBankMoein As Long = 0
        Dim IdChk As Long = 0

        If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
            LIdFac.Text = CreateSanad()
        End If

        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '//////////////////////////////////////////
            '''''''''''''''''''''''''''''Moein_Box
            If CDbl(TxtCash.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = CmbBox.SelectedValue
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdCashBox = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''''''''''''''''Moein_Bank
            If CDbl(Txtbank.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdBank = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''''''''''''''''Moein_People
            ''''''''''''''''DiscountC
            If CDbl(TxtDiscountC.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " تخفیف نقدی بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDisc_DisC.Text), "", " - " & TxtDisc_DisC.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 4
                    IdDisC = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''Cash
            If CDbl(TxtCash.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " دریافت نقدی بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 5
                    IdCashMoein = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''Havaleh
            If CDbl(Txtbank.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ حواله بانکی بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 6
                    IdBankMoein = Cmd.ExecuteScalar
                End Using
            End If
            ''''''''''''''''Chk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ چک بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDisc_Chk.Text), "", " - " & TxtDisc_Chk.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 7
                    IdChk = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''ListSanad
            Using Cmd As New SqlCommand("Update Get_Pay_Sanad SET D_date=@D_date,Idname=@Idname,IdUser=@IdUser,Active=@Active,State=@State,EditFlag=@EditFlag,Discount=@Discount,IdSanadDiscount=@IdSanadDiscount,Cash=@Cash,IdSanadCash=@IdSanadCash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonPayChk=@MonPayChk,MonSellChk=@MonSellChk,IdSanadChk=@IdSanadChk,IdSanadHavaleh=@IdSanadHavaleh,DiscDiscount=@DiscDiscount,DiscChk=@DiscChk,DiscSellChk=@DiscSellChk,IdBoxMoein=@IdBoxMoein,IdBox=@IdBox,IdBankMoein=@IdBankMoein,AllDisc=@AllDisc,DiscCash=@DiscCash,Sanad=@Sanad WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Idname", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                Cmd.Parameters.AddWithValue("@IdSanadDiscount", SqlDbType.BigInt).Value = IIf(IdDisC = 0, DBNull.Value, IdDisC)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@IdSanadCash", SqlDbType.BigInt).Value = IIf(IdCashMoein = 0, DBNull.Value, IdCashMoein)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdBank.Text), DBNull.Value, TxtIdBank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadHavaleh", SqlDbType.BigInt).Value = IIf(IdBankMoein = 0, DBNull.Value, IdBankMoein)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text.Trim
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@IdSanadChk", SqlDbType.BigInt).Value = IIf(IdChk = 0, DBNull.Value, IdChk)
                Cmd.Parameters.AddWithValue("@DiscDiscount", SqlDbType.NVarChar).Value = TxtDisc_DisC.Text
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = ""
                Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text.Trim
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = If(String.IsNullOrEmpty(CmbBox.SelectedValue), DBNull.Value, CmbBox.SelectedValue)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =12 ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("UPDATE Chk_Id SET IdPeople =" & TxtIdName.Text & " WHERE Id IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Type] =12 ) AND (Number_Type = " & LIdFac.Text & "));UPDATE Chk_Id SET Current_IdPeople  =" & TxtIdName.Text & " WHERE (IdBank Is Null)  AND Id IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Type] =12 ) AND (Number_Type = " & LIdFac.Text & "))", ConectionBank)
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            ''''''''''''''''LimitPay
            If LimitListArray.Length > 0 Then
                Using Cmd As New SqlCommand("INSERT INTO PayLimitFrosh (IdSanad,IdFactor,Pay) VALUES(@IdSanad,@IdFactor,@Pay)", ConectionBank)
                    For i As Integer = 0 To LimitListArray.Length - 1
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = LimitListArray(i).IdFactor
                        Cmd.Parameters.AddWithValue("@Pay", SqlDbType.BigInt).Value = LimitListArray(i).Pay
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next
                End Using
            End If
            '//////////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دریافت از طرف حساب", "جدید", "ثبت سند :" & LIdFac.Text & " طرف حساب:" & TxtName.Text & " جمع مبلغ:" & LMandeh.Text & If(CDbl(TxtDiscountC.Text) > 0, " تخفیف:" & TxtDiscountC.Text, "") & If(CDbl(TxtCash.Text) > 0, " نقد:" & TxtCash.Text, "") & If(CDbl(TxtChk.Text) > 0, " چک:" & TxtChk.Text, "") & If(CDbl(Txtbank.Text) > 0, " حواله:" & Txtbank.Text, ""), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات دریافتی قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "Savepay")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function Editpay() As Boolean
        Dim IdDisC As Long = 0
        Dim IdCashBox As Long = 0
        Dim IdCashMoein As Long = 0
        Dim IdBank As Long = 0
        Dim IdBankMoein As Long = 0
        Dim IdChk As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '//////////////////////////////////////////
            '''''''''''''''''''''''''''''Moein_Box
            Dim TmpId As String = If(dt.Rows(0).Item("IdBoxMoein") Is DBNull.Value, "", dt.Rows(0).Item("IdBoxMoein"))
            If CDbl(TxtCash.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_Box SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdBox=@IdBox,IdUser=@IdUser WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = CmbBox.SelectedValue
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    If String.IsNullOrEmpty(TmpId) Then
                        IdCashBox = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdCashBox = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Sanad SET IdBoxMoein=@IdBoxMoein,IdBox=@IdBox WHERE Id=@Id1;DELETE FROM  Moein_Box WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''''''''''''''''Moein_Bank
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdBankMoein") Is DBNull.Value, "", dt.Rows(0).Item("IdBankMoein"))
            If CDbl(Txtbank.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_Bank  SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IDBank=@IDBank,IdUser=@IdUser WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    If String.IsNullOrEmpty(TmpId) Then
                        IdBank = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdBank = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Sanad SET IdBankMoein=@IdBankMoein,IdBankHavaleh=@IdBankHavaleh WHERE Id=@Id1;DELETE FROM  Moein_Bank WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''''''''''''''''Moein_People
            ''''''''''''''''DiscountC
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadDiscount") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadDiscount"))
            If CDbl(TxtDiscountC.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " تخفیف نقدی بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDisc_DisC.Text), "", " - " & TxtDisc_DisC.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 4
                    If String.IsNullOrEmpty(TmpId) Then
                        IdDisC = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdDisC = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Sanad SET IdSanadDiscount=@IdSanadDiscount WHERE Id=@Id1;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadDiscount", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''Cash
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadCash") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadCash"))
            If CDbl(TxtCash.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " دریافت نقدی بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 5
                    If String.IsNullOrEmpty(TmpId) Then
                        IdCashMoein = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdCashMoein = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Sanad SET IdSanadCash=@IdSanadCash WHERE Id=@Id1;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadCash", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''Havaleh
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadHavaleh") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadHavaleh"))
            If CDbl(Txtbank.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ حواله بانکی بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 6
                    If String.IsNullOrEmpty(TmpId) Then
                        IdBankMoein = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdBankMoein = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Sanad SET IdSanadHavaleh=@IdSanadHavaleh WHERE Id=@Id1;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadHavaleh", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            ''''''''''''''''Chk
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadChk") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadChk"))
            If CDbl(TxtChk.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " مبلغ چک بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtSanad.Text.Trim), "", " سند دفتری " & TxtSanad.Text) & If(String.IsNullOrEmpty(TxtDisc_Chk.Text), "", " - " & TxtDisc_Chk.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 12
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 7
                    If String.IsNullOrEmpty(TmpId) Then
                        IdChk = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdChk = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Sanad SET IdSanadChk=@IdSanadChk WHERE Id=@Id1;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadChk", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''Sanad
            Using Cmd As New SqlCommand("Update Get_Pay_Sanad SET D_date=@D_date,IdName=@IdName,AllDisc=@AllDisc,Sanad=@Sanad,IdUser=@IdUser,IdSanadDiscount=@IdSanadDiscount,DiscDiscount=@DiscDiscount,Discount=@Discount,Cash=@Cash,IdSanadCash=@IdSanadCash,IdBoxMoein=@IdBoxMoein,IdBox=@IdBox,DiscCash=@DiscCash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,IdSanadHavaleh=@IdSanadHavaleh,IdBankMoein=@IdBankMoein,MonPayChk=@MonPayChk,IdSanadChk=@IdSanadChk,DiscChk=@DiscChk WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@IdSanadDiscount", SqlDbType.BigInt).Value = IIf(IdDisC = 0, DBNull.Value, IdDisC)
                Cmd.Parameters.AddWithValue("@DiscDiscount", SqlDbType.NVarChar).Value = TxtDisc_DisC.Text
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@IdSanadCash", SqlDbType.BigInt).Value = IIf(IdCashMoein = 0, DBNull.Value, IdCashMoein)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, CmbBox.SelectedValue)
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdBank.Text), DBNull.Value, TxtIdBank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadHavaleh", SqlDbType.BigInt).Value = IIf(IdBankMoein = 0, DBNull.Value, IdBankMoein)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text.Trim
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@IdSanadChk", SqlDbType.BigInt).Value = IIf(IdChk = 0, DBNull.Value, IdChk)
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text.Trim
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Id SET Current_IdPeople  =" & TxtIdName.Text & " WHERE (IdBank Is Null) AND Current_IdPeople=IdPeople AND Id IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Type] =12 ) AND (Number_Type = " & LIdFac.Text & "));UPDATE Chk_Id SET IdPeople =" & TxtIdName.Text & " WHERE Id IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Type] =12 ) AND (Number_Type = " & LIdFac.Text & "));UPDATE Moein_People SET IDPeople =" & TxtIdName.Text & " WHERE T=0 AND ID IN (SELECT PeopleMoein FROM Sanad_ChangeChk  WHERE IdChk IN (SELECT ID FROM  Chk_Get_Pay  WHERE ([Type] =12 ) AND (Number_Type =" & LIdFac.Text & ")))", ConectionBank)
                    Cmd.ExecuteNonQuery()
                End Using

                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =12 ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            ''''''''''''''''LimitPay
            Using Cmd As New SqlCommand("Delete FROM  PayLimitFrosh  WHERE IdSanad=" & CLng(LIdFac.Text), ConectionBank)
                Cmd.ExecuteNonQuery()
            End Using
            If LimitListArray.Length > 0 Then
                Using Cmd As New SqlCommand("INSERT INTO PayLimitFrosh (IdSanad,IdFactor,Pay) VALUES(@IdSanad,@IdFactor,@Pay)", ConectionBank)
                    For i As Integer = 0 To LimitListArray.Length - 1
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = LimitListArray(i).IdFactor
                        Cmd.Parameters.AddWithValue("@Pay", SqlDbType.BigInt).Value = LimitListArray(i).Pay
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next
                End Using
            End If
            '//////////////////////////////////////////

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دریافت از طرف حساب", "ویرایش", "ویرایش سند :" & LIdFac.Text & " طرف حساب:" & TxtName.Text & " جمع مبلغ:" & LMandeh.Text & If(CDbl(TxtDiscountC.Text) > 0, " تخفیف:" & TxtDiscountC.Text, "") & If(CDbl(TxtCash.Text) > 0, " نقد:" & TxtCash.Text, "") & If(CDbl(TxtChk.Text) > 0, " چک:" & TxtChk.Text, "") & If(CDbl(Txtbank.Text) > 0, " حواله:" & Txtbank.Text, ""), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "Editpay")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Try
            LOk.Text = "0"
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnCancle_Click")
        End Try
    End Sub

    Private Sub BtnSodor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSodor.Click
        Try
            If String.IsNullOrEmpty(TxtIdName.Text) Or String.IsNullOrEmpty(TxtName.Text) Then
                MessageBox.Show("هیچ طرف حسابی جهت صدور چک انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using FrmSodor As New Recive_Check
                FrmSodor.LName.Text = TxtName.Text
                FrmSodor.LIdname.Text = TxtIdName.Text
                If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
                    LIdFac.Text = CreateSanad()
                End If
                FrmSodor.LFac.Text = LIdFac.Text
                FrmSodor.LState.Text = 12
                FrmSodor.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtChk.Text = FrmSodor.TxtallmoneyPay.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnSodor_Click")
        End Try
    End Sub

    Private Sub PayFactor_Buy_Amani_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LOk.Text = "0"
        Me.GetBoxList()
        If LEdit.Text = "1" Then
            ChkFactor.Visible = False
            Me.GetInfo()

            '/////////////////////////////
            Dim str As String
            If TxtDiscountC.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtDiscountC.Text.Replace(",", ""))
                TxtDiscountC.Text = Format$(Val(str), "###,###,###")
            Else
                TxtDiscountC.Text = CDbl(TxtDiscountC.Text)
            End If
            '//////////////
            If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)

            If GetMonMandeh() <> 0 Then
                Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / GetMonMandeh())
                TxtDarDisC.Text = Math.Round(tmp, 2)
            Else
                TxtDarDisC.Text = 0
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If TxtCash.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtCash.Text.Replace(",", ""))
                TxtCash.Text = Format$(Val(str), "###,###,###")
            Else
                TxtCash.Text = CDbl(TxtCash.Text)
            End If
            '//////////////
            If Not TxtDarCash.Text.Trim.Contains(".") Then TxtDarCash.Text = CDbl(TxtDarCash.Text)

            If GetMonMandeh() <> 0 Then
                Dim tmp As Double = ((CDbl(TxtCash.Text) * 100) / GetMonMandeh())
                TxtDarCash.Text = Math.Round(tmp, 2)
            Else
                TxtDarCash.Text = 0
            End If

            '/////////////////////////////
        End If
        Me.CalCulateMon()
    End Sub
    Private Function CreateSanad() As Long
        Dim IdSanad As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using Cmd As New SqlCommand("INSERT Get_Pay_Sanad (Active,State,EditFlag,Discount,Cash,MonHavaleh,MonPayChk,MonSellChk) VALUES(@Active,@State,@EditFlag,@Discount,@Cash,@MonHavaleh,@MonPayChk,@MonSellChk);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                IdSanad = Cmd.ExecuteScalar
            End Using
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return IdSanad
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات اولیه سند قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "CreateSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return 0
        End Try
    End Function
    Private Sub GetInfo()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT nam,idname,d_date,discount,idsanaddiscount,cash,idsanadcash,monhavaleh,idbankHavaleh,discHavaleh,MonPayChk,idsanadChk,idsanadHavaleh,DiscChk,DiscDiscount ,discCash,IdBox,IdBoxMoein ,IdBankMoein,AllDisc ,Sanad  FROM (Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.Idname =Define_People.ID  ) WHERE Get_Pay_Sanad.Id =@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                dt.Load(Cmd.ExecuteReader)
                If dt.Rows.Count > 0 Then
                    TxtName.Text = dt.Rows(0).Item("Nam")
                    TxtIdName.Text = dt.Rows(0).Item("Idname")
                    TxtDate.ThisText = dt.Rows(0).Item("D_date")
                    TxtSanad.Text = dt.Rows(0).Item("Sanad")
                    TxtDisc.Text = dt.Rows(0).Item("AllDisc")

                    TxtDiscountC.Text = dt.Rows(0).Item("DisCount")
                    TxtDisc_DisC.Text = dt.Rows(0).Item("DiscDiscount")

                    TxtCash.Text = dt.Rows(0).Item("Cash")
                    TxtDisc_Cash.Text = dt.Rows(0).Item("DiscCash")

                    Txtbank.Text = dt.Rows(0).Item("MonHavaleh")
                    TxtDiscbank.Text = dt.Rows(0).Item("DiscHavaleh")
                    TxtIdBank.Text = If(dt.Rows(0).Item("IdBankHavaleh") Is DBNull.Value, "", dt.Rows(0).Item("IdBankHavaleh"))
                    If Not (dt.Rows(0).Item("IdBankHavaleh") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("IdBankHavaleh")) <> "" Then
                            TxtbankName.Text = GetNamBank(dt.Rows(0).Item("IdBankHavaleh"))
                        End If
                    End If
                    TxtChk.Text = dt.Rows(0).Item("MonPayChk")
                    TxtDisc_Chk.Text = dt.Rows(0).Item("DiscChk")
                    If Not (dt.Rows(0).Item("IdBox") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("IdBox")) <> "" Then
                            CmbBox.SelectedValue = dt.Rows(0).Item("IdBox")
                        End If
                    End If
                    Me.CalCulateMon()
                    ''''''''''''''''''''''''''''''''''''
                    If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
                    Using CmdLimit As New SqlCommand("SELECT IdFactor ,Pay  from PayLimitFrosh WHERE IdSanad =" & CLng(LIdFac.Text), ConectionBank)
                        Dim dtr As SqlDataReader = CmdLimit.ExecuteReader
                        If dtr.HasRows Then
                            Dim sum As Double = 0
                            While dtr.Read
                                Array.Resize(LimitListArray, LimitListArray.Length + 1)
                                LimitListArray(LimitListArray.Length - 1).IdFactor = dtr("IdFactor")
                                LimitListArray(LimitListArray.Length - 1).Pay = dtr("Pay")
                                LimitListArray(LimitListArray.Length - 1).Mon = 0 ' GetBedFac(dtr("IdFactor"))
                                sum += dtr("Pay")
                            End While
                            LLimit.Text = sum
                        End If
                    End Using
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Dim res As Double = GetMoeinPeople(TxtIdName.Text)
                    If res = 0 Then
                        TxtMoein.Text = 0 & "    بی حساب"
                    ElseIf res > 0 Then
                        TxtMoein.Text = FormatNumber(res, 0) & "    بدهکار"
                    ElseIf res < 0 Then
                        TxtMoein.Text = FormatNumber(res * (-1), 0) & "    بستانکار"
                    End If
                    ''''''''''''''''''''''''''''''''''''
                    For i As Integer = 0 To LimitListArray.Length - 1
                        LimitListArray(i).Mon = GetBedFac(LimitListArray(i).IdFactor, "F")
                    Next
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    MessageBox.Show("صورتحساب سند مورد نظر پیدا نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "GetInfo")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try

    End Sub
    Private Sub GetBoxList()
        Try
            ds_Box.Clear()
            If Not dta_Box Is Nothing Then
                dta_Box.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_Box = New SqlDataAdapter("If (SELECT COUNT(IdUser) FROM Define_UserRBox WHERE IdUser =" & Id_User & ")>0 SELECT Define_Box.nam, Define_Box.ID FROM Define_Box INNER JOIN Define_UserRPBox ON Define_Box.ID = Define_UserRPBox.IDB WHERE Define_Box.Id in (SELECT IDB  FROM Define_UserRPBox  WHERE IdUser =" & Id_User & ") AND IdUser =" & Id_User & " ORDER BY Define_UserRPBox.Id  else SELECT ID,nam FROM Define_Box", DataSource)
            dta_Box.Fill(ds_Box, "Define_BOX")
            CmbBox.DataSource = ds_Box.Tables("Define_BOX")
            CmbBox.DisplayMember = "Nam"
            CmbBox.ValueMember = "ID"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "GetBoxList")
        End Try
    End Sub

    Private Sub BtnDiscDisC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscDisC.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_DisC.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_DisC.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnDiscDisC_Click")
        End Try
    End Sub

    Private Sub BtnDiscCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscCash.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_Cash.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_Cash.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnDiscCash_Click")
        End Try
    End Sub

    Private Sub BtnDiscHavaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscHavaleh.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDiscbank.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDiscbank.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnDiscHavaleh_Click")
        End Try
    End Sub

    Private Sub BtnDiscChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscChk.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_Chk.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_Chk.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnDiscChk_Click")
        End Try
    End Sub

    Private Sub BtnBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBox.Click
        Try
            Fnew = True
            Using FrmBox As New DefineBox
                FrmBox.ShowDialog()
            End Using
            Fnew = False
            Me.GetBoxList()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnBox_Click")
        End Try
    End Sub

    Private Sub TxtTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub TxtTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub CmbBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBox.KeyDown
        If CmbBox.DroppedDown = False Then
            CmbBox.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDarDisC.Focus()
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If LimitListArray.Length > 0 Then
            If MessageBox.Show("در صورت تغییر طرف حساب ارتباط با وعده های تعیین شده حذف خواهد شد آیا برای ادامه کار مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Array.Resize(LimitListArray, 0)
            Else
                e.Handled = True
                Exit Sub
            End If
        End If
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            Dim res As Double = GetMoeinPeople(IdKala)
            If res = 0 Then
                TxtMoein.Text = 0 & "    بی حساب"
            ElseIf res > 0 Then
                TxtMoein.Text = FormatNumber(res, 0) & "    بدهکار"
            ElseIf res < 0 Then
                TxtMoein.Text = FormatNumber(res * (-1), 0) & "    بستانکار"
            End If
        Else
            TxtName.Text = ""
            TxtIdName.Text = ""
        End If

        Me.CalCulateMon()
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then CmbBox.Focus()
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
    End Sub

    Private Sub BtnRelation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRelation.Click
        Try
            If String.IsNullOrEmpty(TxtIdName.Text) Or String.IsNullOrEmpty(TxtName.Text) Then
                MessageBox.Show("هیچ طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If CDbl(LMandeh.Text) <= 0 Then
                MessageBox.Show("هیچ مبلغی جهت ارتباط با وعده ها تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using FrmR As New FrmRelationFactor
                FrmR.LMon.Text = CDbl(LMandeh.Text)
                FrmR.LIdname.Text = TxtIdName.Text
                FrmR.LKind.Text = "F"
                FrmR.ShowDialog()
                Dim sum As Double = 0
                For i As Integer = 0 To LimitListArray.Length - 1
                    sum += LimitListArray(i).Pay
                Next
                LLimit.Text = sum
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetMoney", "BtnRelation_Click")
        End Try
    End Sub

    Private Sub MNU_Discount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Discount.Click
        TxtDisc_DisC.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_Cash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Cash.Click
        TxtDisc_Cash.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_Havaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Havaleh.Click
        TxtDiscbank.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_Chk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Chk.Click
        TxtDisc_Chk.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub TxtDarDisC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarDisC.GotFocus
        darsad = 0
        TxtDarDisC.SelectAll()
    End Sub

    Private Sub TxtDarDisC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDarDisC.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDiscountC.Focus()
    End Sub

    Private Sub TxtDarDisC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDarDisC.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Then
            If InStr(TxtDarDisC.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDarDisC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarDisC.LostFocus
        TxtDarDisC.Text = Math.Round(CDbl(TxtDarDisC.Text), 2)
    End Sub

    Private Sub TxtDarDisC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDarDisC.TextChanged
        If darsad = 0 Then
            Try
                If Not (CheckDigit(TxtDarDisC.Text)) Then
                    TxtDarDisC.Text = 0
                    TxtDiscountC.Text = 0
                    TxtDarDisC.SelectAll()
                    Exit Sub
                End If
                If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)
                TxtDiscountC.Text = Format((CDbl(TxtDarDisC.Text) * GetMonMandeh() / 100), "###,###")
                If String.IsNullOrEmpty(TxtDiscountC.Text.Trim) Then TxtDiscountC.Text = "0"
                Me.CalCulateMon()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtDarCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarCash.GotFocus
        darsad = 0
        TxtDarCash.SelectAll()
    End Sub

    Private Sub TxtDarCash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDarCash.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash.Focus()
    End Sub

    Private Sub TxtDarCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDarCash.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Then
            If InStr(TxtDarCash.Text, ".") = False Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub TxtDarCash_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDarCash.LostFocus
        TxtDarCash.Text = Math.Round(CDbl(TxtDarCash.Text), 2)
    End Sub

    Private Sub TxtDarCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDarCash.TextChanged
        If darsad = 0 Then
            Try
                If Not (CheckDigit(TxtDarCash.Text)) Then
                    TxtDarCash.Text = 0
                    TxtCash.Text = 0
                    TxtDarCash.SelectAll()
                    Exit Sub
                End If
                If Not TxtDarCash.Text.Trim.Contains(".") Then TxtDarCash.Text = CDbl(TxtDarCash.Text)
                TxtCash.Text = Format((CDbl(TxtDarCash.Text) * GetMonMandeh() / 100), "###,###")
                If String.IsNullOrEmpty(TxtCash.Text.Trim) Then TxtCash.Text = "0"
                Me.CalCulateMon()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.LostFocus
        Dim str As String
        If TxtDiscountC.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtDiscountC.Text.Replace(",", ""))
            TxtDiscountC.Text = Format$(Val(str), "###,###,###")
        Else
            TxtDiscountC.Text = CDbl(TxtDiscountC.Text)
        End If
        '//////////////
        If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)

        If GetMonMandeh() <> 0 Then
            Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / GetMonMandeh())
            TxtDarDisC.Text = Math.Round(tmp, 2)
        Else
            TxtDarDisC.Text = 0
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If TxtCash.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtCash.Text.Replace(",", ""))
            TxtCash.Text = Format$(Val(str), "###,###,###")
        Else
            TxtCash.Text = CDbl(TxtCash.Text)
        End If
        '//////////////
        If Not TxtDarCash.Text.Trim.Contains(".") Then TxtDarCash.Text = CDbl(TxtDarCash.Text)

        If GetMonMandeh() <> 0 Then
            Dim tmp As Double = ((CDbl(TxtCash.Text) * 100) / GetMonMandeh())
            TxtDarCash.Text = Math.Round(tmp, 2)
        Else
            TxtDarCash.Text = 0
        End If
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged

    End Sub
End Class