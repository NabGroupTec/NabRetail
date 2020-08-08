Imports System.Data.SqlClient
Imports System.Transactions
Public Class Frm_Charge_Other

    Friend WithEvents txt_dgv2 As New DataGridViewTextBoxEditingControl

    Private Sub Frm_Charge_Other_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DGV2.Focus()
    End Sub

    Private Sub Vosol_chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub Vosol_chk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        LPrn.Text = 0
        DGV2.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If Not String.IsNullOrEmpty(Lsanad.Text) Then
            ShowCharge()
        End If
    End Sub
    Private Sub ShowCharge()
        Try
            Dim QueryKala As String = ""
            QueryKala = "SELECT  KalaOtherCharge.IdCharge, KalaOtherCharge.Mon,KalaOtherCharge.CDisc, Define_Charge.nam FROM  KalaOtherCharge INNER JOIN Define_Charge ON KalaOtherCharge.IdCharge = Define_Charge.ID WHERE IdSanad =" & CLng(Lsanad.Text)
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryKala, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    DGV2.AllowUserToAddRows = False
                    While dtrInfo.Read
                        DGV2.Rows.Add()
                        DGV2.Item("Cln_BoxName", DGV2.RowCount - 1).Value = dtrInfo("nam")
                        DGV2.Item("Cln_MonBox", DGV2.RowCount - 1).Value = FormatNumber(dtrInfo("mon"), 0)
                        DGV2.Item("Cln_BoxId", DGV2.RowCount - 1).Value = dtrInfo("IdCharge")
                        DGV2.Item("Cln_Disc", DGV2.RowCount - 1).Value = If(dtrInfo("CDisc") Is DBNull.Value, "", dtrInfo("CDisc"))
                    End While
                    DGV2.AllowUserToAddRows = True
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            CalculateMoney()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Charge_Other", "ShowCharge")
            Me.Close()
        End Try
    End Sub

    Private Sub CalculateMoney()
        Dim allmoney As Double = 0
        For i As Integer = 0 To DGV2.Rows.Count - 2
            allmoney += CDbl(DGV2.Item("Cln_MonBox", i).Value)
        Next
        If allmoney.ToString.Length > 3 Then
            TxtAllMoney.Text = Format(allmoney, "###,###")
        Else
            TxtAllMoney.Text = allmoney
        End If
    End Sub

    Private Sub DGV2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellEndEdit
        If e.ColumnIndex = 1 Then
            If Not (DGV2.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV2.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                If e.RowIndex <> DGV2.RowCount - 1 Then
                    SendKeys.Send("+{TAB}")
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If


        TxtAllMoney.Text = "0"
        If DGV2.RowCount > 0 Then
            For i As Integer = 0 To DGV2.RowCount - 2
                If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV2.EditingControlShowing
        txt_dgv2 = e.Control
    End Sub

    Private Sub DGV2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV2.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV2.CurrentRow.Index <> DGV2.RowCount - 1 Then
                        DGV2.Rows.RemoveAt(DGV2.CurrentRow.Index)
                    Else
                        DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_BoxId", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_Disc", DGV2.CurrentRow.Index).Value = ""
                    End If

                    TxtAllMoney.Text = "0"

                    If DGV2.RowCount > 0 Then
                        For i As Integer = 0 To DGV2.RowCount - 2
                            If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                                TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                            End If
                        Next i
                    End If

                    If TxtAllMoney.Text.Length > 3 Then
                        Dim money As String = ""
                        money = TxtAllMoney.Text.Replace(",", "")
                        TxtAllMoney.Text = Format$(Val(money), "###,###,###")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV2_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.RowLeave
        If DGV2.CurrentCell.ColumnIndex > 0 Then DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Selected = True
        TxtAllMoney.Text = "0"
        If DGV2.RowCount > 0 Then
            For i As Integer = 0 To DGV2.RowCount - 2
                If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                    TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                End If
            Next i
        End If

        If TxtAllMoney.Text.Length > 3 Then
            Dim money As String = ""
            money = TxtAllMoney.Text.Replace(",", "")
            TxtAllMoney.Text = Format$(Val(money), "###,###,###")
        End If
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV2_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV2.UserDeletedRow
        Try
            If DGV2.CurrentCell.ColumnIndex > 0 Then DGV2.Item("Cln_Bank", DGV2.CurrentRow.Index).Selected = True

            TxtAllMoney.Text = "0"

            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 2
                    If (CheckDigit(DGV2.Item("Cln_MonBank", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBank", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv2.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV2.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_MonBox", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_BoxId", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Disc", DGV2.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv2.KeyPress
        If DGV2.CurrentCell.ColumnIndex = 0 Then
            e.Handled = True
            Dim frmlk As New Charge_List
            frmlk.TxtSearch.Text = e.KeyChar()
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV2.Focus()
            If Tmp_Namkala <> "" Then
                DGV2.AllowUserToAddRows = False
                DGV2.Rows.Add()
                DGV2.AllowUserToAddRows = True

                DGV2.Item("Cln_BoxName", DGV2.RowCount - 2).Value = Tmp_Namkala
                DGV2.Item("Cln_MonBox", DGV2.RowCount - 2).Value = 0
                DGV2.Item("Cln_BoxId", DGV2.RowCount - 2).Value = IdKala
                DGV2.Item("Cln_Disc", DGV2.RowCount - 2).Value = ""
                DGV2.Item("Cln_BoxName", DGV2.RowCount - 2).Selected = False
                DGV2.Item("Cln_MonBox", DGV2.RowCount - 2).Selected = True
            End If
            Exit Sub
        End If

        If DGV2.CurrentCell.ColumnIndex = 1 Then
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = "" Then
                e.Handled = True
                Exit Sub
            End If
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = (vbBack) Then
                e.Handled = False
            End If
            If e.KeyChar = (vbTab) Then
                e.Handled = False
            End If
        End If

        If DGV2.CurrentCell.ColumnIndex = 3 Then
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = "" Then
                e.Handled = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            Btnadd.Focus()
            DGV2.EndEdit()

            If String.IsNullOrEmpty(TxtAllMoney.Text.Trim) Then
                MessageBox.Show("جمع هزینه صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CDbl(TxtAllMoney.Text) <= 0 Then
                    MessageBox.Show("جمع هزینه صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If DGV2.Item("Cln_BoxName", DGV2.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت هزینه در ردیف شماره " & "{" & DGV2.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV2.Item("Cln_BoxName", DGV2.RowCount - 1).Selected = True
                DGV2.Focus()
                Exit Sub
            End If
            Array.Resize(ChargeListArray, 0)
            For i As Integer = 0 To DGV2.RowCount - 2
                If String.IsNullOrEmpty(DGV2.Item("Cln_BoxName", i).Value) Or String.IsNullOrEmpty(DGV2.Item("Cln_BoxId", i).Value) Then
                    MessageBox.Show("نام هزینه در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV2.Focus()
                    DGV2.Item("Cln_BoxName", i).Selected = True
                    Exit Sub
                End If
                If DGV2.Item("Cln_MonBox", i).Value <= 0 Then
                    MessageBox.Show("مبلغ ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV2.Focus()
                    DGV2.Item("Cln_Monbox", i).Selected = True
                    Exit Sub
                End If
                Dim count As Long = 0
                For j As Integer = 0 To DGV2.RowCount - 2
                    If DGV2.Item("Cln_BoxId", i).Value = DGV2.Item("Cln_BoxId", j).Value Then count += 1
                Next
                If count > 1 Then
                    If MessageBox.Show("نام هزینه در ردیف شماره " & "{" & i + 1 & "}" & "  تکراری است آیا برای ادامه مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                End If
                Array.Resize(ChargeListArray, ChargeListArray.Length + 1)
                ChargeListArray(ChargeListArray.Length - 1).IdCharge = CLng(DGV2.Item("Cln_BoxId", i).Value)
                ChargeListArray(ChargeListArray.Length - 1).Mon = CDbl(DGV2.Item("Cln_MonBox", i).Value)
                ChargeListArray(ChargeListArray.Length - 1).disc = TxtDisc.Text.Trim
                ChargeListArray(ChargeListArray.Length - 1).sanad = TxtSanad.Text.Trim
                ChargeListArray(ChargeListArray.Length - 1).CDisc = If(DGV2.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV2.Item("Cln_Disc", i).Value), "", DGV2.Item("Cln_Disc", i).Value)
            Next i

            Me.Enabled = False
            If Ledit.Text = "0" Then
                Me.SaveOperation()
            Else
                Me.EditOperation()
            End If
            Me.Enabled = True
        Catch ex As Exception
            Me.Enabled = True
        End Try
    End Sub
    Private Sub EditOperation()
        Me.Enabled = False
        
        Using FrmPay As New Pay_OtherCharge
            If LimitDate = True Then FrmPay.TxtDate.Enabled = False
            FrmPay.LIdFac.Text = CLng(Lsanad.Text)
            FrmPay.TxtFacMon.Text = TxtAllMoney.Text
            FrmPay.LState.Text = 16
            FrmPay.LEdit.Text = "1"
            FrmPay.ShowDialog()
            If FrmPay.LOk.Text = "0" Then
                Me.Enabled = True
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "هزینه", "ویرایش", "ویرایش سند:" & CLng(Lsanad.Text) & " تعداد اقلام هزینه: " & DGV2.RowCount - 1 & " جمع کل هزینه: " & TxtAllMoney.Text, "")

            Me.Close()
        End Using
         
    End Sub
    Private Function SaveCharge() As Long
        Dim sqltransaction As New CommittableTransaction
        Dim IdFac As Long = 0
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO  ListOtherCharge (D_date,IdUser,Disc,Activ,Discount,Cash,MonHavaleh,MonSellChk,MonPayChk,Lend,EditFlag,Sanad) VALUES(@D_date,@IdUser,@Disc,@Activ,@Discount,@Cash,@MonHavaleh,@MonSellChk,@MonPayChk,@Lend,@EditFlag,@Sanad);SELECT @@IDENTITY", ConectionBank)
                Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = GetDate()
                Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(Id_User = 0, DBNull.Value, Id_User)
                Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonSellChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Lend", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 0
                Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                IdFac = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("INSERT INTO KalaOtherCharge (IdSanad,IdCharge,Mon,CDisc) VALUES(@IdSanad,@IdCharge,@Mon,@CDisc)", ConectionBank)
                For i As Integer = 0 To DGV2.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdSanad", SqlDbType.BigInt).Value = IdFac
                    Cmd.Parameters.AddWithValue("@IdCharge", SqlDbType.BigInt).Value = CLng(DGV2.Item("Cln_BoxId", i).Value)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV2.Item("Cln_MonBox", i).Value)
                    Cmd.Parameters.AddWithValue("@CDisc", SqlDbType.NVarChar).Value = If(DGV2.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV2.Item("Cln_Disc", i).Value), "", DGV2.Item("Cln_Disc", i).Value)
                    Cmd.ExecuteNonQuery()
                    Cmd.Parameters.Clear()
                Next i
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return IdFac
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فاکتور هزینه قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Charge_Other", "SaveCharge")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Private Sub txt_dgv2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv2.TextChanged
        Try
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv2.Clear()
                Exit Sub
            End If
            If DGV2.Item("Cln_BoxName", DGV2.CurrentRow.Index).Value = "" Then
                txt_dgv2.Clear()
                Exit Sub
            End If
            If DGV2.CurrentCell.ColumnIndex = 1 Then
                If Not (CheckDigitWithOutpoint(txt_dgv2.Text)) Then txt_dgv2.Text = 0
                If CDbl(txt_dgv2.Text) < 0 Then txt_dgv2.Text = 0
                If txt_dgv2.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv2.Text.Replace(",", ""))
                    txt_dgv2.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv2.Text = CDbl(txt_dgv2.Text)
                End If
            End If

            TxtAllMoney.Text = "0"

            If DGV2.RowCount > 0 Then
                For i As Integer = 0 To DGV2.RowCount - 2
                    If (CheckDigit(DGV2.Item("Cln_MonBox", i).Value)) Then
                        TxtAllMoney.Text = CDbl(TxtAllMoney.Text) + CDbl(DGV2.Item("Cln_MonBox", i).Value.ToString)
                    End If
                Next i
            End If

            If TxtAllMoney.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtAllMoney.Text.Replace(",", "")
                TxtAllMoney.Text = Format$(Val(money), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LPrn.Text = "0"
        Me.Close()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Charge_Other.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Btnadd.Enabled = True Then Btnadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub SaveOperation()
        Try
            Me.Enabled = False
            Using FrmPay As New Pay_OtherCharge
                If LimitDate = True Then FrmPay.TxtDate.Enabled = False
                Dim IdFac As Long = Me.SaveCharge()
                If IdFac = -1 Then
                    Me.Enabled = True
                    Exit Sub
                End If
                FrmPay.TxtFacMon.Text = TxtAllMoney.Text.Trim
                FrmPay.LMandeh.Text = TxtAllMoney.Text.Trim
                FrmPay.TxtLend.Text = "0"
                FrmPay.TxtDate.ThisText = GetDate()
                FrmPay.LIdFac.Text = IdFac
                FrmPay.LState.Text = 16
                FrmPay.TxtDiscountC.Text = "0"
                FrmPay.TxtDarDisC.Text = "0"
                FrmPay.TxtCash.Text = "0"
                FrmPay.Txtbank.Text = "0"
                FrmPay.TxtSellChk.Text = "0"
                FrmPay.TxtChk.Text = "0"
                FrmPay.LEdit.Text = "0"
                FrmPay.Txtname.Enabled = False
                FrmPay.ShowDialog()
                If FrmPay.LOk.Text = "0" Then
                    RoolBackOthrCharge(IdFac, 16)
                    Me.Enabled = True
                    Exit Sub
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "هزینه", "جدید", "ثبت سند:" & IdFac & " تعداد اقلام هزینه: " & DGV2.RowCount - 1 & " جمع کل هزینه: " & TxtAllMoney.Text, "")

            End Using
            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_Charge_Other", "SaveOperation")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Enter Then Btnadd.Focus()
    End Sub
End Class