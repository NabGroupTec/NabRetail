Imports System.Data.SqlClient
Imports System.Transactions
Public Class Pay_OtherCharge
    Dim darsad As Long
    Dim ds_Box As New DataSet
    Dim dta_Box As New SqlDataAdapter()
    Dim dt As New DataTable

    Private Sub PayFactor_Buy_Amani_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtDarDisC.Focus()
    End Sub

    Private Sub PayFactor_Buy_Amani_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnCancle.Enabled = False And LOk.Text = "0" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub PayFactor_Buy_Amani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub TxtDiscountC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountC.GotFocus
        darsad = 1
        TxtDiscountC.SelectAll()
    End Sub

    Private Sub TxtDiscountC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDiscountC.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then
                TxtDiscountC.Text += CDbl(LMandeh.Text)
            ElseIf CDbl(LMandeh.Text) = 0 And CDbl(TxtLend.Text) > 0 Then
                TxtDiscountC.Text += CDbl(TxtLend.Text)
                TxtLend.Text = 0
            End If
        End If
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
        If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
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
                Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / CDbl(TxtFacMon.Text))
                TxtDarDisC.Text = Math.Round(tmp, 2)
                If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
                If CDbl(TxtDiscountC.Text) > CDbl(TxtFacMon.Text) Then TxtDiscountC.Text = TxtFacMon.Text
                '//////////////
                Me.CalCulateMon()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCash.GotFocus
        TxtCash.SelectAll()
    End Sub

    Private Sub TxtCash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCash.KeyDown
        If e.KeyCode = Keys.Enter Then Txtbank.Focus()
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then
                TxtCash.Text += CDbl(LMandeh.Text)
            ElseIf CDbl(LMandeh.Text) = 0 And CDbl(TxtLend.Text) > 0 Then
                TxtCash.Text += CDbl(TxtLend.Text)
                TxtLend.Text = 0
            End If
        End If
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
        Try
            If Not (CheckDigit(Format$(TxtCash.Text.Replace(",", "")))) Then
                TxtCash.Text = "0"
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
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtLend_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLend.GotFocus
        TxtLend.SelectAll()
    End Sub

    Private Sub TxtLend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLend.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txtname.Enabled = True Then
                Txtname.Focus()
            Else
                TxtDate.Focus()
            End If
        End If
        If e.KeyCode = Keys.Space Then
            If CDbl(LMandeh.Text) > 0 Then TxtLend.Text += CDbl(LMandeh.Text)
        End If
    End Sub

    Private Sub TxtLend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLend.KeyPress
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

    Private Sub TxtLend_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLend.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtLend.Text.Replace(",", "")))) Then
                TxtLend.Text = "0"
                TxtLend.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtLend.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtLend.Text.Replace(",", ""))
                TxtLend.Text = Format$(Val(str), "###,###,###")
            Else
                TxtLend.Text = CDbl(TxtLend.Text)
            End If

            If CDbl(TxtLend.Text) > 0 Then
                Txtname.Enabled = True
            Else
                Txtname.Enabled = False
            End If

            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtbank_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbank.GotFocus
        Txtbank.SelectAll()
    End Sub

    Private Sub Txtbank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtbank.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSellChk.Focus()
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

    Private Sub TxtSellChk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSellChk.GotFocus
        TxtSellChk.SelectAll()
    End Sub

    Private Sub TxtSellChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSellChk.KeyDown
        If e.KeyCode = Keys.Enter Then TxtChk.Focus()
    End Sub

    Private Sub TxtSellChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSellChk.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtSellChk.Text.Replace(",", "")))) Then
                TxtSellChk.Text = "0"
                TxtSellChk.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtSellChk.Text.Length > 3 Then
                str = Format$(TxtSellChk.Text.Replace(",", ""))
                TxtSellChk.Text = Format$(Val(str), "###,###,###")
            Else
                TxtSellChk.Text = CDbl(TxtSellChk.Text)
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtChk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtChk.GotFocus
        TxtChk.SelectAll()
    End Sub

    Private Sub TxtChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk.KeyDown
        If e.KeyCode = Keys.Enter Then TxtLend.Focus()
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
            LMandeh.Text = CDbl(TxtFacMon.Text) - CDbl(TxtDiscountC.Text) - CDbl(TxtCash.Text) - CDbl(Txtbank.Text) - CDbl(TxtSellChk.Text) - CDbl(TxtChk.Text) - CDbl(TxtLend.Text)
            If CDbl(TxtDiscountC.Text) > 0 Then
                If Not TxtDarDisC.Text.Trim.Contains(".") Then TxtDarDisC.Text = CDbl(TxtDarDisC.Text)
                Dim tmp As Double = ((CDbl(TxtDiscountC.Text) * 100) / CDbl(TxtFacMon.Text))
                TxtDarDisC.Text = Math.Round(tmp, 2)
                If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
                If CDbl(TxtDiscountC.Text) > CDbl(TxtFacMon.Text) Then TxtDiscountC.Text = TxtFacMon.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtEndMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtFacMon.SelectAll()
    End Sub

    Private Sub TxtEndMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (CheckDigit(Format$(TxtFacMon.Text.Replace(",", "")))) Then
            TxtFacMon.Text = "0"
            TxtFacMon.SelectAll()
            Exit Sub
        End If
        Dim str As String
        If TxtFacMon.Text.Length > 3 Then
            str = Format$(TxtFacMon.Text.Replace(",", ""))
            TxtFacMon.Text = Format$(Val(str), "###,###,###")
        Else
            TxtFacMon.Text = CDbl(TxtFacMon.Text)
        End If
    End Sub

    Private Sub LMandeh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LMandeh.TextChanged
        Dim str As String
        If LMandeh.Text.Length > 3 Then
            str = Format$(LMandeh.Text.Replace(",", ""))
            LMandeh.Text = Format$(Val(str), "###,###,###")
        Else
            LMandeh.Text = CDbl(LMandeh.Text)
        End If
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
        If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
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
                If CDbl(TxtDarDisC.Text) > 100 Then TxtDarDisC.Text = 100
                TxtDiscountC.Text = Format((CDbl(TxtDarDisC.Text) * CDbl(TxtFacMon.Text) / 100), "###,###")
                If String.IsNullOrEmpty(TxtDiscountC.Text.Trim) Then TxtDiscountC.Text = "0"
                Dim dar As String = TxtDarDisC.Text 
                If dar(dar.Length -1)<>"." Then me.CalCulateMon()
            Catch ex As Exception
            End Try
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnHavaleh_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Charge_Other.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
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
            If CDbl(LMandeh.Text) <> 0 Then
                MessageBox.Show("وضعيت نحوي پرداخت كل مبلغ تعيين نشده است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtLend.Focus()
                Exit Sub
            End If
            If CDbl(LMandeh.Text) < 0 And CDbl(TxtLend.Text) > 0 Then
                MessageBox.Show("مبلغ نسیه اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtLend.Focus()
                Exit Sub
            End If

            If CDbl(TxtCash.Text) > 0 And CmbBox.Text = "" Then
                MessageBox.Show("صندوقی جهت برداشت نقدی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbBox.Focus()
                Exit Sub
            End If
            If CDbl(TxtLend.Text) > 0 Then
                If String.IsNullOrEmpty(Txtname.Text) Or String.IsNullOrEmpty(TxtIdName.Text) Then
                    MessageBox.Show("هیچ طرف حسابی جهت ثبت نسیه انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Txtname.Focus()
                    Exit Sub
                End If
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnSave_Click")
        End Try
    End Sub
    Private Function Savepay() As Boolean
        Dim IdCashBox As Long = 0
        Dim IdBank As Long = 0
        Dim IdLend As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '//////////////////////////////////////////
            '''''''''''''''''''''''''''''Moein_Box
            If CDbl(TxtCash.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Box (D_date,disc,mon,T,IdBox,IdUser) VALUES(@D_date,@disc,@mon,@T,@IdBox,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت هزینه بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = CmbBox.SelectedValue
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdCashBox = Cmd.ExecuteScalar
                End Using
            End If

            '''''''''''''''''''''''''''''Moein_Bank
            If CDbl(Txtbank.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت هزینه بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdBank = Cmd.ExecuteScalar
                End Using
            End If
            
            ''''''''''''''''Lend
            If CDbl(TxtLend.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت هزینه بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                    Idlend = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''ListFacotr
            Using Cmd As New SqlCommand("Update ListOtherCharge SET Activ=@Activ,EditFlag=@EditFlag,D_date=@D_date,IdName=@IdName,Discount=@Discount,Cash=@Cash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonSellChk=@MonSellChk,MonPayChk=@MonPayChk,Lend=@Lend,IdSanadLend=@IdSanadLend,DiscDisC=@DiscDisC,DiscCash=@DiscCash,DiscSellChk=@DiscSellChk,DiscChk=@DiscChk,IdBox=@IdBox,IdBoxMoein=@IdBoxMoein,IdBanKMoein=@IdBanKMoein,DiscLend=@DiscLend WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(Txtname.Enabled = False, DBNull.Value, TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(CDbl(Txtbank.Text) > 0, TxtIdBank.Text, DBNull.Value)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = CDbl(TxtSellChk.Text)
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = IIf(IdLend = 0, DBNull.Value, IdLend)
                Cmd.Parameters.AddWithValue("@DiscDisC", SqlDbType.NVarChar).Value = TxtDisc_DisC.Text
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = TxtDisc_SellChk.Text
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(CDbl(TxtCash.Text) > 0, CmbBox.SelectedValue, DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = TxtDiscLend.Text
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =" & LState.Text & " ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            If CDbl(TxtSellChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =" & LState.Text & " ) AND (Current_Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات پرداختی قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "Savepay")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function Editpay() As Boolean
        Dim IdCashBox As Long = 0
        Dim IdBank As Long = 0
        Dim IdLend As Long = 0
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
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت هزینه بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
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
                    Using Cmd As New SqlCommand("UPDATE ListOtherCharge SET IdBoxMoein=@IdBoxMoein,IdBox=@IdBox WHERE Id=@IdSanad;DELETE FROM  Moein_Box WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
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
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت هزینه بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
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
                    Using Cmd As New SqlCommand("UPDATE ListOtherCharge SET IdBankMoein=@IdBankMoein WHERE Id=@IdSanad;DELETE FROM  Moein_Bank WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If

            ''''''''''''''''Lend
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadLend") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadLend"))
            If CDbl(TxtLend.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE ID=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت هزینه بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = CLng(LState.Text)
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                    If String.IsNullOrEmpty(TmpId) Then
                        IdLend = Cmd.ExecuteScalar
                    Else
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.ExecuteNonQuery()
                        IdLend = CLng(TmpId)
                    End If
                End Using
            Else
                If Not String.IsNullOrEmpty(TmpId) Then
                    Using Cmd As New SqlCommand("UPDATE ListOtherCharge SET IdSanadLend=@IdSanadLend WHERE Id=@IdSanad;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If

            '''''''''''''''ListCharge

            Using Cmd As New SqlCommand("Update ListOtherCharge SET Sanad=@Sanad,Activ=@Activ,EditFlag=@EditFlag,D_date=@D_date,IdName=@IdName,Discount=@Discount,Cash=@Cash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonSellChk=@MonSellChk,MonPayChk=@MonPayChk,Lend=@Lend,IdSanadLend=@IdSanadLend,DiscDisC=@DiscDisC,DiscCash=@DiscCash,DiscSellChk=@DiscSellChk,DiscChk=@DiscChk,IdBox=@IdBox,IdBoxMoein=@IdBoxMoein,IdBanKMoein=@IdBanKMoein,DiscLend=@DiscLend,Disc=@Disc WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = ChargeListArray(0).sanad
                Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(Txtname.Enabled = False, DBNull.Value, TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = CDbl(TxtDiscountC.Text)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(CDbl(Txtbank.Text) > 0, TxtIdBank.Text, DBNull.Value)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = CDbl(TxtSellChk.Text)
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = IIf(IdLend = 0, DBNull.Value, IdLend)
                Cmd.Parameters.AddWithValue("@DiscDisC", SqlDbType.NVarChar).Value = TxtDisc_DisC.Text
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = TxtDisc_SellChk.Text
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(CDbl(TxtCash.Text) > 0, CmbBox.SelectedValue, DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = TxtDiscLend.Text
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = ChargeListArray(0).disc
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using

            ''''''''''''''''KalaCharge
            Using Cmd As New SqlCommand("DELETE FROM KalaOtherCharge WHERE IdSanad=@IdSanad", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            TmpId = "INSERT INTO KalaOtherCharge (IdSanad,IdCharge,Mon,CDisc) VALUES(@IdSanad,@IdCharge,@Mon,@CDisc)"
            Using Cmd As New SqlCommand(TmpId, ConectionBank)
                For i As Integer = 0 To ChargeListArray.Length - 1
                    Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = ChargeListArray(i).IdCharge
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = ChargeListArray(i).Mon
                    Cmd.Parameters.AddWithValue("@CDisc", SqlDbType.NVarChar).Value = If(ChargeListArray(i).CDisc Is DBNull.Value Or String.IsNullOrEmpty(ChargeListArray(i).CDisc), "", ChargeListArray(i).CDisc)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Or CDbl(TxtSellChk.Text) > 0 Then
                If CDbl(TxtChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =" & LState.Text & " ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
                If CDbl(TxtSellChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =" & LState.Text & " ) AND (Current_Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '//////////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات پرداختی قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "Editpay")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnCancle_Click")
        End Try
    End Sub

    Private Sub BtnSodor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSodor.Click
        Try
            Using FrmSodor As New Sodor_Check
                FrmSodor.LName.Text = "هزینه متفرقه"
                FrmSodor.LIdname.Text = "-16"
                FrmSodor.LFac.Text = LIdFac.Text
                FrmSodor.LState.Text = LState.Text
                FrmSodor.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtChk.Text = FrmSodor.TxtallmoneyPay.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnSodor_Click")
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
            Me.GetInfo()
        Else
            TxtDate.ThisText = GetDate()
        End If
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "GetBoxList")
        End Try
    End Sub

    Private Sub GetInfo()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT   D_date, IdName, Discount, Cash, MonHavaleh, IdBankHavaleh, DiscHavaleh, MonSellChk, MonPayChk, Lend, IdSanadLend, DiscDisC, DiscCash,DiscSellChk, DiscChk, IdBox, IdBoxMoein, IdBanKMoein, DiscLend FROM  ListOtherCharge WHERE ID=" & CLng(LIdFac.Text), ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                dt.Load(Cmd.ExecuteReader)
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                If dt.Rows.Count > 0 Then
                    TxtDarDisC.Text = "0"
                    darsad = 1
                    TxtDiscountC.Text = dt.Rows(0).Item("DisCount")
                    TxtCash.Text = dt.Rows(0).Item("Cash")
                    Txtbank.Text = dt.Rows(0).Item("MonHavaleh")
                    TxtSellChk.Text = dt.Rows(0).Item("MonSellChk")
                    TxtChk.Text = dt.Rows(0).Item("MonPayChk")
                    TxtLend.Text = dt.Rows(0).Item("Lend")
                    TxtDisc_DisC.Text = dt.Rows(0).Item("DiscDisC")
                    TxtDisc_Cash.Text = dt.Rows(0).Item("DiscCash")
                    TxtDiscbank.Text = dt.Rows(0).Item("DiscHavaleh")
                    TxtDisc_SellChk.Text = dt.Rows(0).Item("DiscSellChk")
                    TxtDisc_Chk.Text = dt.Rows(0).Item("DiscChk")
                    TxtDiscLend.Text = dt.Rows(0).Item("DiscLend")
                    TxtDate.ThisText = dt.Rows(0).Item("D_Date")
                    If CDbl(TxtLend.Text) > 0 Then
                        Txtname.Enabled = True
                        TxtIdName.Text = dt.Rows(0).Item("IdName")
                        Txtname.Text = GetNamPeolpe(TxtIdName.Text)
                    Else
                        Txtname.Enabled = False
                        Txtname.Text = ""
                        TxtIdName.Text = ""
                    End If
                    TxtIdBank.Text = If(dt.Rows(0).Item("IdBankHavaleh") Is DBNull.Value, "", dt.Rows(0).Item("IdBankHavaleh"))
                    If Not (dt.Rows(0).Item("IdBankHavaleh") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("IdBankHavaleh")) <> "" Then
                            TxtbankName.Text = GetNamBank(dt.Rows(0).Item("IdBankHavaleh"))
                        End If
                    End If
                    If Not (dt.Rows(0).Item("IdBox") Is DBNull.Value) Then
                        If CStr(dt.Rows(0).Item("IdBox")) <> "" Then
                            CmbBox.SelectedValue = dt.Rows(0).Item("IdBox")
                        End If
                    End If

                    Me.CalCulateMon()
                    If String.IsNullOrEmpty(LMandeh.Text) Then LMandeh.Text = "0"
                    'If CDbl(LMandeh.Text) > 0 Then
                    'TxtLend.Text = LMandeh.Text
                    'Me.CalCulateMon()
                    'End If
                Else
                MessageBox.Show("صورتحساب فاکتور هزینه مورد نظر پیدا نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "GetInfo")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try

    End Sub
    Private Sub BtnFroshChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFroshChk.Click
        Try
            Using FrmFrosh As New Frosh_Check
                FrmFrosh.LName.Text = "هزینه متفرقه"
                FrmFrosh.LIdname.Text = "-16"
                FrmFrosh.LFac.Text = LIdFac.Text
                FrmFrosh.LState.Text = LState.Text
                FrmFrosh.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtSellChk.Text = FrmFrosh.TxtallmoneyPay.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnFroshChk_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnDiscDisC_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnDiscCash_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnDiscHavaleh_Click")
        End Try
    End Sub

    Private Sub BtnDisc_SellChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisc_SellChk.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_SellChk.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_SellChk.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnDisc_SellChk_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnDiscChk_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnBox_Click")
        End Try
    End Sub

    Private Sub TxtFacMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFacMon.GotFocus
        TxtFacMon.SelectAll()
    End Sub


    Private Sub CmbBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBox.KeyDown
        If CmbBox.DroppedDown = False Then
            CmbBox.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub BtnDiscLend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscLend.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDiscLend.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDiscLend.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Pay_OtherCharge", "BtnDiscLend_Click")
        End Try
    End Sub

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        Txtname.Focus()
        If Tmp_Namkala <> "" Then
            Txtname.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
        Else
            Txtname.Text = ""
            TxtIdName.Text = ""
        End If
    End Sub
End Class