Imports System.Data.SqlClient
Imports System.Transactions
Public Class Get_Pay_Amval
    Dim darsad As Long
    Dim ds_Box As New DataSet
    Dim dta_Box As New SqlDataAdapter()
    Dim dt As New DataTable

    Private Sub PayFactor_Buy_Amani_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtS.Focus()
    End Sub

    Private Sub PayFactor_Buy_Amani_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            dta = New SqlDataAdapter("SELECT ID FROM  Chk_Get_Pay WHERE ([Type] =14 ) AND (Number_Type = " & Idfac & ")", DataSource)
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
            Using Cmd As New SqlCommand("DELETE FROM Get_Pay_Sarmayeh WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Idfac
                Cmd.ExecuteNonQuery()
            End Using
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            RoolSellChk(LIdFac.Text, 14)
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات سند قابل برگشت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "RoolBackSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub PayFactor_Buy_Amani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub TxtDiscountC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub TxtCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCash.GotFocus
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
            If RdoName.Checked = True Then
                Txtname.Focus()
            ElseIf RdoCharge.Checked = True Then
                TxtCharge.Focus()
            Else
                TxtDisc.Focus()
            End If
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
                RdoName.Enabled = False
                RdoCharge.Enabled = False
                RdoName.Checked = False
                RdoCharge.Checked = False
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
                RdoName.Enabled = True
                RdoCharge.Enabled = True
                If RdoName.Checked = False And RdoCharge.Checked = False Then
                    RdoName.Checked = True
                End If
            Else
                RdoName.Enabled = False
                RdoCharge.Enabled = False
                RdoName.Checked = False
                RdoCharge.Checked = False
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
            LMandeh.Text = CDbl(TxtCash.Text) + CDbl(Txtbank.Text) + CDbl(TxtSellChk.Text) + CDbl(TxtChk.Text) + CDbl(TxtLend.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtEndMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtIdS.SelectAll()
    End Sub

    Private Sub TxtEndMon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (CheckDigit(Format$(TxtIdS.Text.Replace(",", "")))) Then
            TxtIdS.Text = "0"
            TxtIdS.SelectAll()
            Exit Sub
        End If
        Dim str As String
        If TxtIdS.Text.Length > 3 Then
            str = Format$(TxtIdS.Text.Replace(",", ""))
            TxtIdS.Text = Format$(Val(str), "###,###,###")
        Else
            TxtIdS.Text = CDbl(TxtIdS.Text)
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnHavaleh_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Amval.htm")
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
            If CDbl(LMandeh.Text) <= 0 Then
                MessageBox.Show("هیچ مبلغی تعيين نشده است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCash.Focus()
                Exit Sub
            End If

            If CDbl(TxtCash.Text) > 0 And CmbBox.Text = "" Then
                MessageBox.Show("هیچ صندوقی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbBox.Focus()
                Exit Sub
            End If
            If CDbl(TxtLend.Text) > 0 Then
                If RdoName.Checked = True Then
                    If String.IsNullOrEmpty(Txtname.Text) Or String.IsNullOrEmpty(TxtIdName.Text) Then
                        MessageBox.Show("هیچ طرف حسابی جهت ثبت نسیه انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Txtname.Focus()
                        Exit Sub
                    End If
                End If

                If RdoCharge.Checked = True Then
                    If String.IsNullOrEmpty(TxtCharge.Text) Or String.IsNullOrEmpty(TxtIdCharge.Text) Then
                        MessageBox.Show("هیچ هزینه ای جهت ثبت نسیه انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtCharge.Focus()
                        Exit Sub
                    End If
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnSave_Click")
        End Try
    End Sub
    Private Function Savepay() As Boolean

        If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
            LIdFac.Text = CreateSanad()
        End If

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
                    If RdoDec.Checked = True Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                    Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = CmbBox.SelectedValue
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdCashBox = Cmd.ExecuteScalar
                End Using
            End If

            '''''''''''''''''''''''''''''Moein_Bank
            If CDbl(Txtbank.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_Bank (D_date,disc,mon,T,IDBank,IdUser) VALUES(@D_date,@disc,@mon,@T,@IDBank,@IdUser);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    If RdoDec.Checked = True Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdBank = Cmd.ExecuteScalar
                End Using
            End If

            ''''''''''''''''Lend
            If CDbl(TxtLend.Text) > 0 Then
                If RdoName.Checked = True Then
                    Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                        Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                        If RdoDec.Checked = True Then
                            Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                            Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                        Else
                            Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                            Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                        End If
                        Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                        Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                        Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 14
                        Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                        IdLend = Cmd.ExecuteScalar
                    End Using
                End If
            End If
            '''''''''''''''ListAmval
            Using Cmd As New SqlCommand("Update Get_Pay_Amval SET D_date=@D_date,IdAmval=@IdAmval,IdUser=@IdUser,Active=@Active,State=@State,EditFlag=@EditFlag,Cash=@Cash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonPayChk=@MonPayChk,MonSellChk=@MonSellChk,Lend=@Lend,LendP=@LendP,IdSanadLendP=@IdSanadLendP,LendCharge=@LendCharge,DiscChk=@DiscChk,DiscSellChk=@DiscSellChk,IdBoxMoein=@IdBoxMoein,IdBox=@IdBox,IdBankMoein=@IdBankMoein,AllDisc=@AllDisc,DiscCash=@DiscCash,DiscLend=@DiscLend WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = CDbl(TxtIdS.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = If(RdoDec.Checked = True, 0, 1)
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(CDbl(Txtbank.Text) > 0, TxtIdBank.Text, DBNull.Value)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = CDbl(TxtSellChk.Text)
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                Cmd.Parameters.AddWithValue("@LendP", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdName.Text), DBNull.Value, TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@IdSanadLendP", SqlDbType.BigInt).Value = IIf(IdLend = 0, DBNull.Value, IdLend)
                Cmd.Parameters.AddWithValue("@LendCharge", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdCharge.Text), DBNull.Value, TxtIdCharge.Text)
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text
                Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = TxtDisc_SellChk.Text
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(CDbl(TxtCash.Text) > 0, CmbBox.SelectedValue, DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = TxtDisc.Text
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = TxtDiscLend.Text
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtSellChk.Text) > 0 Or CDbl(TxtChk.Text) > 0 Then
                If CDbl(TxtChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =14) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
                If CDbl(TxtSellChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =14) AND (Current_Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If

                Using Cmd As New SqlCommand("UPDATE  Chk_id SET IdAmval =@IdAmval WHERE Id In(SELECT ID From Chk_Get_Pay WHERE ([Type] =14 OR Current_Type =14 ) AND (Number_Type = " & LIdFac.Text & " OR Current_Number_Type = " & LIdFac.Text & " ))", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = CLng(TxtIdS.Text)
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اموال", "جدید", "ثبت سند :" & LIdFac.Text & " نام اموال:" & TxtS.Text & " جمع مبلغ:" & LMandeh.Text & If(CDbl(TxtCash.Text) > 0, " نقد:" & TxtCash.Text, "") & If((CDbl(TxtChk.Text) + CDbl(TxtSellChk.Text)) > 0, " چک:" & FormatNumber(CDbl(TxtChk.Text) + CDbl(TxtSellChk.Text), 0), "") & If(CDbl(Txtbank.Text) > 0, " حواله:" & Txtbank.Text, "") & If(CDbl(TxtLend.Text) > 0, " نسیه:" & TxtLend.Text, "") & If(String.IsNullOrEmpty(Txtname.Text), "", " طرف حساب:" & Txtname.Text) & If(String.IsNullOrEmpty(TxtCharge.Text), "", " هزینه:" & TxtCharge.Text) & " نوع پرداخت:" & If(RdoAdd.Checked = True, "کاهش اموال", "افزایش اموال"), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "Savepay")
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

                    If RdoDec.Checked = True Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    End If

                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
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
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Amval SET IdBoxMoein=@IdBoxMoein,IdBox=@IdBox WHERE Id=@IdSanad;DELETE FROM  Moein_Box WHERE Id=@ID", ConectionBank)
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
                    If RdoDec.Checked = True Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
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
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Amval SET IdBankMoein=@IdBankMoein WHERE Id=@IdSanad;DELETE FROM  Moein_Bank WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If

            ''''''''''''''''Lend
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadLendP") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadLendP"))
            If CDbl(TxtLend.Text) > 0 And RdoName.Checked = True Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE ID=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    If RdoDec.Checked = True Then
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "پرداخت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                    Else
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت اموال بابت سند  " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                        Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    End If
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 14
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
                    Using Cmd As New SqlCommand("UPDATE Get_Pay_Amval SET IdSanadLendP=@IdSanadLend WHERE Id=@IdSanad;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If

            '''''''''''''''ListSarmayeh
            Using Cmd As New SqlCommand("Update Get_Pay_Amval SET D_date=@D_date,IdAmval=@IdAmval,IdUser=@IdUser,Active=@Active,State=@State,EditFlag=@EditFlag,Cash=@Cash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonPayChk=@MonPayChk,MonSellChk=@MonSellChk,Lend=@Lend,LendP=@LendP,IdSanadLendP=@IdSanadLendP,LendCharge=@LendCharge,DiscChk=@DiscChk,DiscSellChk=@DiscSellChk,IdBoxMoein=@IdBoxMoein,IdBox=@IdBox,IdBankMoein=@IdBankMoein,AllDisc=@AllDisc,DiscCash=@DiscCash,DiscLend=@DiscLend WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = CDbl(TxtIdS.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = If(RdoDec.Checked = True, 0, 1)
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(CDbl(Txtbank.Text) > 0, TxtIdBank.Text, DBNull.Value)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = CDbl(TxtSellChk.Text)
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                Cmd.Parameters.AddWithValue("@LendP", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdName.Text), DBNull.Value, TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@IdSanadLendP", SqlDbType.BigInt).Value = IIf(IdLend = 0, DBNull.Value, IdLend)
                Cmd.Parameters.AddWithValue("@LendCharge", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdCharge.Text), DBNull.Value, TxtIdCharge.Text)
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text
                Cmd.Parameters.AddWithValue("@DiscSellChk", SqlDbType.NVarChar).Value = TxtDisc_SellChk.Text
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = IIf(CDbl(TxtCash.Text) > 0, CmbBox.SelectedValue, DBNull.Value)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = TxtDisc.Text
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text
                Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = TxtDiscLend.Text
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtSellChk.Text) > 0 Or CDbl(TxtChk.Text) > 0 Then
                If CDbl(TxtChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =14) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
                If CDbl(TxtSellChk.Text) > 0 Then
                    Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =14) AND (Current_Number_Type = " & LIdFac.Text & ")", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                        Cmd.ExecuteNonQuery()
                    End Using
                End If

                Using Cmd As New SqlCommand("UPDATE  Chk_id SET IdAmval =@IdAmval WHERE Id In(SELECT ID From Chk_Get_Pay WHERE ([Type] =14 OR Current_Type =14 ) AND (Number_Type = " & LIdFac.Text & " OR Current_Number_Type = " & LIdFac.Text & " ))", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = CLng(TxtIdS.Text)
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "اموال", "ویرایش", "ویرایش سند :" & LIdFac.Text & " نام اموال:" & TxtS.Text & " جمع مبلغ:" & LMandeh.Text & If(CDbl(TxtCash.Text) > 0, " نقد:" & TxtCash.Text, "") & If((CDbl(TxtChk.Text) + CDbl(TxtSellChk.Text)) > 0, " چک:" & FormatNumber(CDbl(TxtChk.Text) + CDbl(TxtSellChk.Text), 0), "") & If(CDbl(Txtbank.Text) > 0, " حواله:" & Txtbank.Text, "") & If(CDbl(TxtLend.Text) > 0, " نسیه:" & TxtLend.Text, "") & If(String.IsNullOrEmpty(Txtname.Text), "", " طرف حساب:" & Txtname.Text) & If(String.IsNullOrEmpty(TxtCharge.Text), "", " هزینه:" & TxtCharge.Text) & " نوع پرداخت:" & If(RdoAdd.Checked = True, "کاهش اموال", "افزایش اموال"), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "Editpay")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnCancle_Click")
        End Try
    End Sub

    Private Sub BtnSodor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSodor.Click
        Try
            If String.IsNullOrEmpty(TxtIdS.Text) Or String.IsNullOrEmpty(TxtS.Text) Then
                MessageBox.Show("هیچ اموالی جهت صدور چک انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If RdoDec.Checked = True Then
                Using FrmSodor As New Sodor_Check
                    FrmSodor.LName.Text = TxtS.Text
                    FrmSodor.LIdname.Text = CLng(TxtIdS.Text)
                    If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
                        LIdFac.Text = CreateSanad()
                    End If
                    FrmSodor.LFac.Text = LIdFac.Text
                    FrmSodor.LState.Text = 14
                    FrmSodor.ShowDialog()
                    If LEdit.Text = "1" Then BtnCancle.Enabled = False
                    TxtChk.Text = FrmSodor.TxtallmoneyPay.Text
                    If CDbl(TxtChk.Text) > 0 Then
                        RdoDec.Enabled = False
                        RdoAdd.Enabled = False
                    Else
                        If LEdit.Text = "0" Then
                            RdoDec.Enabled = True
                            RdoAdd.Enabled = True
                        End If
                    End If
                End Using
            Else
                Using FrmSodor As New Recive_Check
                    FrmSodor.LName.Text = TxtS.Text
                    FrmSodor.LIdname.Text = TxtIdS.Text
                    If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
                        LIdFac.Text = CreateSanad()
                    End If
                    FrmSodor.LFac.Text = LIdFac.Text
                    FrmSodor.LState.Text = 14
                    FrmSodor.ShowDialog()
                    If LEdit.Text = "1" Then BtnCancle.Enabled = False
                    TxtChk.Text = FrmSodor.TxtallmoneyPay.Text
                    If CDbl(TxtChk.Text) > 0 Then
                        RdoDec.Enabled = False
                        RdoAdd.Enabled = False
                    Else
                        If LEdit.Text = "0" Then
                            RdoDec.Enabled = True
                            RdoAdd.Enabled = True
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnSodor_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "GetBoxList")
        End Try
    End Sub

    Private Sub GetInfo()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT  Get_Pay_Amval.[state],D_date,IdAmval,Cash,MonHavaleh, IdBankHavaleh, DiscHavaleh, MonPayChk, MonSellChk, LendP, IdSanadLendP, LendCharge, DiscChk, DiscSellChk,IdBoxMoein, IdBox,IdBankMoein, AllDisc,DiscCash,DiscLend, Lend, nam, NamP=Case WHEN LendP Is NULL THEN N'' ELSE (SELECT Nam From Define_People  WHERE ID =LendP) End, NamCharge=Case WHEN LendCharge  Is NULL THEN N'' ELSE (SELECT Nam From Define_Charge   WHERE ID =LendCharge ) End FROM Get_Pay_Amval INNER JOIN Define_Amval ON Get_Pay_Amval.IdAmval = Define_Amval.ID WHERE Get_Pay_Amval .Id =" & CLng(LIdFac.Text), ConectionBank)
                dt.Load(Cmd.ExecuteReader)
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                If dt.Rows.Count > 0 Then
                    TxtS.Text = dt.Rows(0).Item("nam")
                    TxtIdS.Text = dt.Rows(0).Item("IdAmval")
                    TxtCash.Text = dt.Rows(0).Item("Cash")
                    Txtbank.Text = dt.Rows(0).Item("MonHavaleh")
                    TxtSellChk.Text = dt.Rows(0).Item("MonSellChk")
                    TxtChk.Text = dt.Rows(0).Item("MonPayChk")
                    TxtLend.Text = dt.Rows(0).Item("Lend")
                    TxtDisc_Cash.Text = dt.Rows(0).Item("DiscCash")
                    TxtDiscbank.Text = dt.Rows(0).Item("DiscHavaleh")
                    TxtDisc_SellChk.Text = dt.Rows(0).Item("DiscSellChk")
                    TxtDisc_Chk.Text = dt.Rows(0).Item("DiscChk")
                    TxtDiscLend.Text = dt.Rows(0).Item("DiscLend")
                    TxtDate.ThisText = dt.Rows(0).Item("D_Date")
                    TxtDisc.Text = dt.Rows(0).Item("AllDisc")
                    If CDbl(TxtLend.Text) > 0 Then
                        If Not dt.Rows(0).Item("LendP") Is DBNull.Value Then
                            RdoName.Checked = True
                            TxtIdName.Text = dt.Rows(0).Item("LendP")
                            Txtname.Text = dt.Rows(0).Item("NamP")
                        End If

                        If Not dt.Rows(0).Item("LendCharge") Is DBNull.Value Then
                            RdoCharge.Checked = True
                            TxtIdCharge.Text = dt.Rows(0).Item("LendCharge")
                            TxtCharge.Text = dt.Rows(0).Item("NamCharge")
                        End If

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

                    If dt.Rows(0).Item("State") = 0 Then
                        RdoDec.Checked = True
                        If CDbl(TxtSellChk.Text) > 0 Or CDbl(TxtChk.Text) > 0 Then
                            RdoDec.Enabled = False
                            RdoAdd.Enabled = False
                        Else
                            RdoDec.Enabled = True
                            RdoAdd.Enabled = True
                        End If

                    Else
                        RdoAdd.Checked = True
                        If CDbl(TxtSellChk.Text) > 0 Or CDbl(TxtChk.Text) > 0 Then
                            RdoDec.Enabled = False
                            RdoAdd.Enabled = False
                        Else
                            RdoDec.Enabled = True
                            RdoAdd.Enabled = True
                        End If
                    End If

                    Me.CalCulateMon()
                    If String.IsNullOrEmpty(LMandeh.Text) Then LMandeh.Text = "0"
                Else
                    MessageBox.Show("صورتحساب سند مورد نظر پیدا نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "GetInfo")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try

    End Sub
    Private Sub BtnFroshChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFroshChk.Click
        Try
            If String.IsNullOrEmpty(TxtIdS.Text) Or String.IsNullOrEmpty(TxtS.Text) Then
                MessageBox.Show("هیچ اموالی جهت خرج چک مشتری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using FrmFrosh As New Frosh_Check
                FrmFrosh.LName.Text = TxtS.Text.Trim
                FrmFrosh.LIdname.Text = TxtIdS.Text
                If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
                    LIdFac.Text = CreateSanad()
                End If
                FrmFrosh.LFac.Text = LIdFac.Text
                FrmFrosh.LState.Text = 14
                FrmFrosh.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtSellChk.Text = FrmFrosh.TxtallmoneyPay.Text
                If CDbl(TxtSellChk.Text) > 0 Then
                    RdoDec.Enabled = False
                    RdoAdd.Enabled = False
                Else
                    If LEdit.Text = "0" Then
                        RdoDec.Enabled = True
                        RdoAdd.Enabled = True
                    End If
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnFroshChk_Click")
        End Try
    End Sub

    Private Function CreateSanad() As Long
        Dim IdSanad As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using Cmd As New SqlCommand("INSERT Get_Pay_Amval (Active,State,EditFlag,Cash,MonHavaleh,MonPayChk,MonSellChk,Lend) VALUES(@Active,@State,@EditFlag,@Cash,@MonHavaleh,@MonPayChk,@MonSellChk,@Lend);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@State", SqlDbType.Int).Value = -1
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = 0
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "CreateSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return 0
        End Try
    End Function

    Private Sub BtnDiscCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscCash.Click
        Try
            Using FrmDisc As New FrmDisc
                FrmDisc.TxtDisc.Text = TxtDisc_Cash.Text.Trim
                FrmDisc.ShowDialog()
                If FrmDisc.LAdd.Text = "0" Then Exit Sub
                TxtDisc_Cash.Text = FrmDisc.TxtDisc.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnDiscCash_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnDiscHavaleh_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnDisc_SellChk_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnDiscChk_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnBox_Click")
        End Try
    End Sub

    Private Sub TxtFacMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdS.GotFocus
        TxtIdS.SelectAll()
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Get_Pay_Amval", "BtnDiscLend_Click")
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

    Private Sub TxtS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtS.KeyDown
        If e.KeyCode = Keys.Enter Then TxtCash.Focus()
    End Sub

    Private Sub TxtS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Amval_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        Txtname.Focus()
        If Tmp_Namkala <> "" Then
            TxtS.Text = Tmp_Namkala
            TxtIdS.Text = IdKala
        Else
            TxtS.Text = ""
            TxtIdS.Text = ""
        End If
    End Sub

    Private Sub RdoName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoName.CheckedChanged
        If RdoName.Checked = True Then
            Txtname.Enabled = True
            Txtname.Text = ""
            TxtIdName.Text = ""
        Else
            Txtname.Enabled = False
            Txtname.Text = ""
            TxtIdName.Text = ""
        End If
    End Sub

    Private Sub RdoCharge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCharge.CheckedChanged
        If RdoCharge.Checked = True Then
            TxtCharge.Enabled = True
            TxtCharge.Text = ""
            TxtIdCharge.Text = ""
        Else
            TxtCharge.Enabled = False
            TxtCharge.Text = ""
            TxtIdCharge.Text = ""
        End If
    End Sub

    Private Sub TxtCharge_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCharge.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Charge_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtCharge.Focus()
        If Tmp_Namkala <> "" Then
            TxtCharge.Text = Tmp_Namkala
            TxtIdCharge.Text = IdKala
        Else
            TxtCharge.Text = ""
            TxtIdCharge.Text = ""
        End If
    End Sub


    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub RdoDec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoDec.CheckedChanged
        If RdoDec.Checked = True Then
            BtnDisc_SellChk.Enabled = True
            BtnFroshChk.Enabled = True
        Else
            BtnDisc_SellChk.Enabled = False
            BtnFroshChk.Enabled = False
        End If
    End Sub

    Private Sub MNU_Cash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Cash.Click
        TxtDisc_Cash.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_Havaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Havaleh.Click
        TxtDiscbank.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_FroshChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_FroshChk.Click
        If BtnDisc_SellChk.Enabled = True Then TxtDisc_SellChk.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_Chk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Chk.Click
        TxtDisc_Chk.Text = TxtDisc.Text.Trim
    End Sub

    Private Sub MNU_Lend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Lend.Click
        TxtDiscLend.Text = TxtDisc.Text.Trim
    End Sub
End Class