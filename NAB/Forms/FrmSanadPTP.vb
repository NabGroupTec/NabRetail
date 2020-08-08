Imports System.Data.SqlClient
Imports System.Transactions
Public Class FrmSanadPTP
    Dim dt As New DataTable
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click

        Try
            If String.IsNullOrEmpty(TxtNameBed.Text) Or String.IsNullOrEmpty(TxtIdBed.Text) Then
                MessageBox.Show("طرف حساب بدهکار را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNameBed.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtNameBes.Text) Or String.IsNullOrEmpty(TxtIdBes.Text) Then
                MessageBox.Show("طرف حساب بستانکار را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNameBes.Focus()
                Exit Sub
            End If

            If CDbl(TxtMon.Text) <= 0 Then
                MessageBox.Show("مبلغ انتقال را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMon.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TxtDate.ThisText) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Exit Sub
            End If
            If LEdit.Text = "0" Then
                If Me.SaveSanad Then Me.Close()
            Else
                If Me.EditSanad Then Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSanadPTP", "cmdadd_Click")
        End Try
    End Sub

    Private Function SaveSanad() As Boolean
        Dim IdSanad As Long = 0
        Dim IdBes As Long = 0
        Dim IdBed As Long = 0
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '''''''''''Sanad
            Using Cmd As New SqlCommand("INSERT INTO Sanad_PTP (IdNameBed,IdNameBes,IdUser,Disc,D_date,Mon,IdSanadBed,IdSanadBes) VALUES(@IdNameBed,@IdNameBes,@IdUser,@Disc,@D_date,@Mon,@IdSanadBed,@IdSanadBes);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdNameBed", SqlDbType.BigInt).Value = CLng(TxtIdBed.Text)
                Cmd.Parameters.AddWithValue("@IdNameBes", SqlDbType.BigInt).Value = CLng(TxtIdBes.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@IdSanadBed", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.Parameters.AddWithValue("@IdSanadBes", SqlDbType.BigInt).Value = DBNull.Value
                IdSanad = Cmd.ExecuteScalar
            End Using

            ''''''''''Moein Bed
            Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " انتقال حساب بابت سند" & IdSanad & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdBed.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 13
                Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = IdSanad
                Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 9
                IdBed = Cmd.ExecuteScalar
            End Using

            ''''''''''Moein Bes
            Using Cmd As New SqlCommand("INSERT Moein_People (D_date,disc,mon,T,IdPeople,IdUser,Type,Number_Type,Type_Sanad) VALUES(@D_date,@disc,@mon,@T,@IdPeople,@IdUser,@Type,@Number_Type,@Type_Sanad);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " انتقال حساب بابت سند" & IdSanad & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@T", SqlDbType.Int).Value = 1
                Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdBes.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Type", SqlDbType.BigInt).Value = 13
                Cmd.Parameters.AddWithValue("@Number_Type", SqlDbType.BigInt).Value = IdSanad
                Cmd.Parameters.AddWithValue("@Type_Sanad", SqlDbType.BigInt).Value = 9
                IdBes = Cmd.ExecuteScalar
            End Using

            '''''''''''Update Sanad
            Using Cmd As New SqlCommand("UPDATE Sanad_PTP SET IdSanadBed=@IdSanadBed,IdSanadBes=@IdSanadBes WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdSanadBed", SqlDbType.BigInt).Value = IdBed
                Cmd.Parameters.AddWithValue("@IdSanadBes", SqlDbType.BigInt).Value = IdBes
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = IdSanad
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "طرف حساب به طرف حساب", "جدید", "ثبت سند :" & IdSanad & " بدهکار:" & TxtNameBed.Text & " بستانکار:" & TxtNameBes.Text & " مبلغ انتقال:" & TxtMon.Text, "")
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSanadPTP", "SaveSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditSanad() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            '''''''''''Sanad
            Using Cmd As New SqlCommand("UPDATE  Sanad_PTP SET IdNameBed=@IdNameBed,IdNameBes=@IdNameBes,IdUser=@IdUser,Disc=@Disc,D_date=@D_date,Mon=@Mon WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdNameBed", SqlDbType.BigInt).Value = CLng(TxtIdBed.Text)
                Cmd.Parameters.AddWithValue("@IdNameBes", SqlDbType.BigInt).Value = CLng(TxtIdBes.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdSanad.Text)
                Cmd.ExecuteNonQuery()
            End Using

            ''''''''''Moein Bed
            Using Cmd As New SqlCommand("UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,IdPeople=@IdPeople,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " انتقال حساب بابت سند" & CLng(LIdSanad.Text) & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdBed.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = dt.Rows(0).Item("IdSanadBed")
                Cmd.ExecuteNonQuery()
            End Using

            ''''''''''Moein Bes
            Using Cmd As New SqlCommand("UPDATE Moein_People SET D_date=@D_date,disc=@disc,mon=@mon,IdPeople=@IdPeople,IdUser=@IdUser WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = " انتقال حساب بابت سند" & CLng(LIdSanad.Text) & If(String.IsNullOrEmpty(TxtDisc.Text), "", " - " & TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@mon", SqlDbType.BigInt).Value = CDbl(TxtMon.Text)
                Cmd.Parameters.AddWithValue("@IdPeople", SqlDbType.BigInt).Value = CLng(TxtIdBes.Text)
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = dt.Rows(0).Item("IdSanadBes")
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "طرف حساب به طرف حساب", "ویرایش", "ویرایش سند :" & CLng(LIdSanad.Text) & " بدهکار:" & TxtNameBed.Text & " بستانکار:" & TxtNameBes.Text & " مبلغ انتقال:" & TxtMon.Text, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("در حال حاضر سند قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSanadPTP", "EditSanad")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "PToP.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then BtnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmSanadPTP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub TxtNameBed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameBed.KeyDown
        If e.KeyCode = Keys.Enter Then TxtNameBes.Focus()
    End Sub

    Private Sub TxtNameBed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameBed.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtNameBed.Focus()
        If IdKala <> 0 Then
            TxtNameBed.Text = Tmp_Namkala
            TxtIdBed.Text = IdKala
        End If
    End Sub

    Private Sub TxtNameBes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameBes.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon.Focus()
    End Sub

    Private Sub TxtNameBes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameBes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtNameBes.Focus()
        If IdKala <> 0 Then
            TxtNameBes.Text = Tmp_Namkala
            TxtIdBes.Text = IdKala
        End If
    End Sub

    Private Sub TxtMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
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
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then TxtDisc.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then cmdadd.Focus()
    End Sub

    Private Sub GetInfoSanad(ByVal id As Long)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim Str_Sql As String = ""
            Str_Sql = "SELECT Allsanad.Id,Allsanad.IdSanadBed ,Allsanad.IdSanadBes ,Allsanad.IdNameBed,Allsanad.IdNameBes ,Allsanad.D_date ,Allsanad.Disc ,Allsanad.Mon ,Allsanad.BedNam ,nam As BesNam  FROM (SELECT   Sanad_PTP.Id,Sanad_PTP.IdSanadBed ,Sanad_PTP.IdSanadBes ,Sanad_PTP.IdNameBed ,Sanad_PTP.IdNameBes  , Sanad_PTP.Disc, Sanad_PTP.D_date, Sanad_PTP.Mon, Define_People.Nam As BedNam FROM Sanad_PTP INNER JOIN Define_People ON Sanad_PTP.IdNameBed = Define_People.ID WHERE Sanad_PTP.Id=@Id)AS AllSanad INNER JOIN Define_People ON AllSanad .IdNameBes  = Define_People.ID"
            Using Cmd As New SqlCommand(Str_Sql, ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = id
                dt.Load(Cmd.ExecuteReader)
                 If dt.Rows.Count > 0 Then
                    TxtNameBed.Text = dt.Rows(0).Item("BedNam")
                    TxtIdBed.Text = dt.Rows(0).Item("IdNameBed")
                    TxtNameBes.Text = dt.Rows(0).Item("BesNam")
                    TxtIdBes.Text = dt.Rows(0).Item("IdNameBes")
                    TxtMon.Text = dt.Rows(0).Item("Mon")
                    TxtDate.ThisText = dt.Rows(0).Item("D_date")
                    TxtDisc.Text = dt.Rows(0).Item("Disc")
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmSanadPTP", "GetInfoSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub FrmSanadPTP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If LEdit.Text = "1" Then Me.GetInfoSanad(CLng(LIdSanad.Text))
    End Sub
End Class