﻿Imports System.Data.SqlClient
Imports System.Transactions
Public Class GetDaramad
    Dim darsad As Long = 0
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
            dta = New SqlDataAdapter("SELECT ID FROM  Chk_Get_Pay WHERE ([Type] =15 ) AND (Number_Type = " & Idfac & ")", DataSource)
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
            Using Cmd As New SqlCommand("DELETE FROM Get_Daramad WHERE Id=@Id", ConectionBank)
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "RoolBackSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Private Sub PayFactor_Buy_Amani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
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
            LMandeh.Text = CDbl(TxtCash.Text) + CDbl(Txtbank.Text) + CDbl(TxtChk.Text) + CDbl(TxtLend.Text)
        Catch ex As Exception

        End Try
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnHavaleh_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Daramad.htm")
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
            If String.IsNullOrEmpty(TxtIdName.Text) Or String.IsNullOrEmpty(TxtName.Text) Then
                MessageBox.Show("هیچ درآمدی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If
            If CDbl(TxtCash.Text) > 0 And CmbBox.Text = "" Then
                MessageBox.Show("صندوقی جهت واریز نقدی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbBox.Focus()
                Exit Sub
            End If

            If CDbl(TxtLend.Text) > 0 Then
                If String.IsNullOrEmpty(TxtIdNameP.Text) Or String.IsNullOrEmpty(TxtNamP.Text) Then
                    MessageBox.Show("هیچ طرف حسابی جهت مبلغ نسیه انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNamP.Focus()
                    Exit Sub
                End If
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnSave_Click")
        End Try
    End Sub
    Private Function Savepay() As Boolean
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
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت درآمد بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
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
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت درآمد بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IDBank", SqlDbType.BigInt).Value = CLng(TxtIdBank.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    IdBank = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''''''''''''''''Moein_People
            ''''''''''''''''Lend
            If CDbl(TxtLend.Text) > 0 Then
                Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " درآمد " & TxtName.Text & " بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdNameP.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 15
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
                    IdCashMoein = Cmd.ExecuteScalar
                End Using
            End If
            '''''''''''''''ListSanad
            Using Cmd As New SqlCommand("Update Get_Daramad SET D_date=@D_date,Idname=@Idname,IdUser=@IdUser,Active=@Active,EditFlag=@EditFlag,Lend=@Lend,Cash=@Cash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonPayChk=@MonPayChk,DiscChk=@DiscChk,IdSanadLend=@IdSanadLend,DiscLend=@DiscLend,IdBoxMoein=@IdBoxMoein,IdBox=@IdBox,IdBankMoein=@IdBankMoein,AllDisc=@AllDisc,DiscCash=@DiscCash,IdDaramad=@IdDaramad WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Idname", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdNameP.Text), DBNull.Value, TxtIdNameP.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdBank.Text), DBNull.Value, TxtIdBank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = IIf(IdCashMoein = 0, DBNull.Value, IdCashMoein)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text.Trim
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = TxtDiscLend.Text.Trim
                Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text.Trim
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = If(String.IsNullOrEmpty(CmbBox.SelectedValue), DBNull.Value, CmbBox.SelectedValue)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =15 ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("UPDATE  Chk_id SET IdDaramad =@IdDaramad WHERE Id In(SELECT ID From Chk_Get_Pay WHERE ([Type] =15 ) AND (Number_Type = " & LIdFac.Text & " ))", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "درآمد", "جدید", "ثبت سند :" & LIdFac.Text & " نام درآمد:" & TxtName.Text & " جمع مبلغ:" & LMandeh.Text & If(CDbl(TxtCash.Text) > 0, " نقد:" & TxtCash.Text, "") & If(CDbl(TxtChk.Text) > 0, " چک:" & TxtChk.Text, "") & If(CDbl(Txtbank.Text) > 0, " حواله:" & Txtbank.Text, "") & If(CDbl(TxtLend.Text) > 0, " نسیه:" & TxtLend.Text, "") & If(String.IsNullOrEmpty(TxtNamP.Text), "", " طرف حساب:" & TxtNamP.Text), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات درآمد قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "Savepay")
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
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت درآمد بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDisc_Cash.Text), "", " - " & TxtDisc_Cash.Text.Trim)
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
                    Using Cmd As New SqlCommand("UPDATE Get_Daramad SET IdBoxMoein=@IdBoxMoein,IdBox=@IdBox WHERE Id=@Id1;DELETE FROM  Moein_Box WHERE Id=@ID", ConectionBank)
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
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "دریافت درآمد بابت سند " & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscbank.Text), "", " - " & TxtDiscbank.Text.Trim)
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
                    Using Cmd As New SqlCommand("UPDATE Get_Daramad SET IdBankMoein=@IdBankMoein,IdBankHavaleh=@IdBankHavaleh WHERE Id=@Id1;DELETE FROM  Moein_Bank WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
            '''''''''''''''''''''''''''''Moein_People
            ''''''''''''''''Lend
            TmpId = ""
            TmpId = If(dt.Rows(0).Item("IdSanadLend") Is DBNull.Value, "", dt.Rows(0).Item("IdSanadlend"))
            If CDbl(TxtLend.Text) > 0 Then
                Dim StrTmp As String = ""
                If String.IsNullOrEmpty(TmpId) Then
                    StrTmp = "INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY"
                Else
                    StrTmp = "UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,T=@T,IdPeople=@IdPeople,IdUser=@IdUser,Type=@Type,Number_Type=@Number_Type,Type_Sanad=@Type_Sanad WHERE Id=@Id"
                End If
                Using Cmd As New SqlCommand(StrTmp, ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " درآمد " & TxtName.Text & " بابت سند" & LIdFac.Text & If(String.IsNullOrEmpty(TxtDiscLend.Text), "", " - " & TxtDiscLend.Text.Trim)
                    Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                    Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdNameP.Text)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                    Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 15
                    Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 8
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
                    Using Cmd As New SqlCommand("UPDATE Get_Daramad SET IdSanadLend=@IdSanadLend WHERE Id=@Id1;DELETE FROM  Moein_People WHERE Id=@ID", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(TmpId)
                        Cmd.Parameters.AddWithValue("@Id1", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If
         
            '''''''''''''''Sanad
            Using Cmd As New SqlCommand("Update Get_Daramad SET D_date=@D_date,Idname=@Idname,IdUser=@IdUser,Lend=@Lend,Cash=@Cash,MonHavaleh=@MonHavaleh,IdBankHavaleh=@IdBankHavaleh,DiscHavaleh=@DiscHavaleh,MonPayChk=@MonPayChk,DiscChk=@DiscChk,IdSanadLend=@IdSanadLend,DiscLend=@DiscLend,IdBoxMoein=@IdBoxMoein,IdBox=@IdBox,IdBankMoein=@IdBankMoein,AllDisc=@AllDisc,DiscCash=@DiscCash,IdDaramad=@IdDaramad WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Idname", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdNameP.Text), DBNull.Value, TxtIdNameP.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = CDbl(TxtCash.Text)
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = CDbl(TxtLend.Text)
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = CDbl(Txtbank.Text)
                Cmd.Parameters.AddWithValue("@IdBankHavaleh", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdBank.Text), DBNull.Value, TxtIdBank.Text)
                Cmd.Parameters.AddWithValue("@IdSanadLend", SqlDbType.BigInt).Value = IIf(IdCashMoein = 0, DBNull.Value, IdCashMoein)
                Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = TxtDiscbank.Text.Trim
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = CDbl(TxtChk.Text)
                Cmd.Parameters.AddWithValue("@DiscChk", SqlDbType.NVarChar).Value = TxtDisc_Chk.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscLend", SqlDbType.NVarChar).Value = TxtDiscLend.Text.Trim
                Cmd.Parameters.AddWithValue("@AllDisc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                Cmd.Parameters.AddWithValue("@DiscCash", SqlDbType.NVarChar).Value = TxtDisc_Cash.Text.Trim
                Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = If(String.IsNullOrEmpty(CmbBox.SelectedValue), DBNull.Value, CmbBox.SelectedValue)
                Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = IIf(IdCashBox = 0, DBNull.Value, IdCashBox)
                Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = IIf(IdBank = 0, DBNull.Value, IdBank)
                Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                Cmd.ExecuteNonQuery()
            End Using
            ''''''''''''''''ActiveChk
            If CDbl(TxtChk.Text) > 0 Then
                Using Cmd As New SqlCommand("UPDATE Chk_Get_Pay SET Activ=@Active WHERE ([Type] =15 ) AND (Number_Type = " & LIdFac.Text & ")", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Active", SqlDbType.BigInt).Value = 1
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New SqlCommand("UPDATE  Chk_id SET IdDaramad =@IdDaramad WHERE Id In(SELECT ID From Chk_Get_Pay WHERE ([Type] =15 ) AND (Number_Type = " & LIdFac.Text & " ))", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '//////////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "درآمد", "ویرایش", "ویرایش سند :" & LIdFac.Text & " نام درآمد:" & TxtName.Text & " جمع مبلغ:" & LMandeh.Text & If(CDbl(TxtCash.Text) > 0, " نقد:" & TxtCash.Text, "") & If(CDbl(TxtChk.Text) > 0, " چک:" & TxtChk.Text, "") & If(CDbl(Txtbank.Text) > 0, " حواله:" & Txtbank.Text, "") & If(CDbl(TxtLend.Text) > 0, " نسیه:" & TxtLend.Text, "") & If(String.IsNullOrEmpty(TxtNamP.Text), "", " طرف حساب:" & TxtNamP.Text), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "Editpay")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnCancle_Click")
        End Try
    End Sub

    Private Sub BtnSodor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSodor.Click
        Try
            If String.IsNullOrEmpty(TxtIdName.Text) Or String.IsNullOrEmpty(TxtName.Text) Then
                MessageBox.Show("هیچ درآمدی جهت صدور چک انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using FrmSodor As New Recive_Check
                FrmSodor.LName.Text = "درآمد"
                FrmSodor.LIdname.Text = CLng(TxtIdName.Text)
                If String.IsNullOrEmpty(LIdFac.Text) Or LIdFac.Text = "0" Then
                    LIdFac.Text = CreateSanad()
                End If
                FrmSodor.LFac.Text = LIdFac.Text
                FrmSodor.LState.Text = 15
                FrmSodor.ShowDialog()
                If LEdit.Text = "1" Then BtnCancle.Enabled = False
                TxtChk.Text = FrmSodor.TxtallmoneyPay.Text
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnSodor_Click")
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
        End If
    End Sub
    Private Function CreateSanad() As Long
        Dim IdSanad As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Using Cmd As New SqlCommand("INSERT Get_Daramad (Active,EditFlag,Lend,Cash,MonHavaleh,MonPayChk,IdDaramad) VALUES(@Active,@EditFlag,@Lend,@Cash,@MonHavaleh,@MonPayChk,@IdDaramad);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@Active", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@IdDaramad", SqlDbType.BigInt).Value = TxtIdName.Text
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
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "CreateSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return 0
        End Try
    End Function
    Private Sub GetInfo()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT  Define_Daramad.nam,D_date,Idname, Cash, MonHavaleh,IdBankHavaleh, DiscHavaleh, MonPayChk, DiscChk, Lend,IdSanadLend, DiscLend, IdBoxMoein,IdBox, IdBankMoein,AllDisc, DiscCash,IdDaramad,Namp=Case WHEN Idname is null THEN N'' ELSE (SELECT nam from Define_People WHERE Define_People.Id=Idname ) end FROM  Get_Daramad INNER JOIN Define_Daramad ON Get_Daramad.IdDaramad = Define_Daramad.ID WHERE Get_Daramad .Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                dt.Load(Cmd.ExecuteReader)
                If dt.Rows.Count > 0 Then
                    TxtName.Text = dt.Rows(0).Item("Nam")
                    TxtIdName.Text = dt.Rows(0).Item("IdDaramad")
                    TxtDate.ThisText = dt.Rows(0).Item("D_date")
                    TxtDisc.Text = dt.Rows(0).Item("AllDisc")

                    TxtCash.Text = dt.Rows(0).Item("Cash")
                    TxtDisc_Cash.Text = dt.Rows(0).Item("DiscCash")

                    TxtLend.Text = dt.Rows(0).Item("Lend")
                    TxtDiscLend.Text = dt.Rows(0).Item("DiscLend")

                    If dt.Rows(0).Item("Lend") > 0 Then
                        TxtNamP.Text = dt.Rows(0).Item("NamP")
                        TxtIdNameP.Text = dt.Rows(0).Item("IdName")
                    End If

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
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    MessageBox.Show("صورتحساب سند مورد نظر پیدا نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "GetInfo")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "GetBoxList")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnDiscCash_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnDiscHavaleh_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnDiscChk_Click")
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnBox_Click")
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
        If e.KeyCode = Keys.Enter Then TxtCash.Focus()
    End Sub


    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Daramad_List
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

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then CmbBox.Focus()
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
    End Sub

    Private Sub TxtLend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLend.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtNamP.Enabled = True Then
                TxtNamP.Focus()
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
                TxtNamP.Enabled = True
            Else
                TxtNamP.Enabled = False
            End If
            Me.CalCulateMon()
        Catch ex As Exception

        End Try
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
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "GetDaramad", "BtnDiscLend_Click")
        End Try
    End Sub

    Private Sub TxtNamP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNamP.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtNamP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamP.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtNamP.Focus()
        If Tmp_Namkala <> "" Then
            TxtNamP.Text = Tmp_Namkala
            TxtIdNameP.Text = IdKala
        Else
            TxtNamP.Text = ""
            TxtIdNameP.Text = ""
        End If
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

    Private Sub MNU_Lend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Lend.Click
        TxtDiscLend.Text = TxtDisc.Text.Trim
    End Sub
End Class