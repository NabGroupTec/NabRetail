Imports System.Data.SqlClient
Public Class FrmRelationFactor
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV.CurrentRow.Index <> DGV.RowCount - 1 Then
                        DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
                    Else
                        DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = ""
                        DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = ""
                        DGV.Item("Cln_Pay", DGV.CurrentRow.Index).Value = ""
                    End If
                    If DGV.RowCount > 0 Then
                        TxtMonPay.Text = "0"
                        For i As Integer = 0 To DGV.RowCount - 2
                            If (CheckDigit(DGV.Item("Cln_Pay", i).Value)) Then
                                TxtMonPay.Text = CDbl(TxtMonPay.Text) + CDbl(DGV.Item("Cln_Pay", i).Value.ToString)
                            End If
                        Next i
                        If TxtMonPay.Text.Length > 3 Then
                            Dim money As String = ""
                            money = TxtMonPay.Text.Replace(",", "")
                            TxtMonPay.Text = Format$(Val(money), "###,###,###")
                        End If
                    Else
                        TxtMonPay.Text = "0"
                    End If
                    Me.Caculate()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Selected = True
        If DGV.RowCount > 0 Then
            TxtMonPay.Text = "0"
            For i As Integer = 0 To DGV.RowCount - 2
                If (CheckDigit(DGV.Item("Cln_Pay", i).Value)) Then
                    TxtMonPay.Text = CDbl(TxtMonPay.Text) + CDbl(DGV.Item("Cln_Pay", i).Value.ToString)
                End If
            Next i
            If TxtMonPay.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtMonPay.Text.Replace(",", "")
                TxtMonPay.Text = Format$(Val(money), "###,###,###")
            End If
        Else
            TxtMonPay.Text = "0"
        End If
        Me.Caculate()
    End Sub
    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV.UserDeletedRow
        If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Selected = True
        If DGV.RowCount > 0 Then
            TxtMonPay.Text = "0"
            For i As Integer = 0 To DGV.RowCount - 2
                If (CheckDigit(DGV.Item("Cln_Pay", i).Value)) Then
                    TxtMonPay.Text = CDbl(TxtMonPay.Text) + CDbl(DGV.Item("Cln_Pay", i).Value.ToString)
                End If
            Next i
            If TxtMonPay.Text.Length > 3 Then
                Dim money As String = ""
                money = TxtMonPay.Text.Replace(",", "")
                TxtMonPay.Text = Format$(Val(money), "###,###,###")
            End If
        Else
            TxtMonPay.Text = "0"
        End If
        Me.Caculate()
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = ""
                DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value = ""
                Exit Sub
            End If
            If e.KeyCode = Keys.Space Then
                If DGV.CurrentCell.ColumnIndex = 2 Then
                    If Not String.IsNullOrEmpty(TxtMandeh.Text.Trim) Then
                        If CDbl(TxtMandeh.Text) > 0 Then
                            If CDbl(TxtMandeh.Text) <= DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value Then
                                DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value = FormatNumber(CDbl(TxtMandeh.Text), 0)
                                IIf(String.IsNullOrEmpty(DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value), 0, DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value)
                            Else
                                DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value = FormatNumber(CDbl(DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value), 0)
                                IIf(String.IsNullOrEmpty(DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value), 0, DGV.Item("Cln_pay", DGV.CurrentRow.Index).Value)
                            End If
                            SendKeys.Send("{ENTER}")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        ''''''''''''گرفتن شماره فاکتور
        If DGV.CurrentCell.ColumnIndex = 0 Then
            ' e.Handled = True
            Dim frmlk As New LimitFactor_List
            frmlk.TxtSearch.Text = e.KeyChar()
            If LKind.Text = "F" Then
                'frmlk.StrSQL = "SELECT IdFactor ,Rate,d_date ,MonFac ,Pay ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,Rate,d_date,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell  WHERE ListFactorSell.IdFactor =AllTime.IdFactor)As MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0)   FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay FROM (SELECT Wanted_Frosh.IdFactor, Wanted_Frosh.Rate,d_date FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.IdName=" & CLng(LIdname.Text) & ") As AllTime) As EndData"
                frmlk.StrSQL = "SELECT IdFactor,EndData.Rate,MaxNewDate,d_date ,MonFac ,Pay ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor) -(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date  FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.IdName=" & CLng(LIdname.Text) & " ) As AllTime) As EndData"
            ElseIf LKind.Text = "K" Then
                'frmlk.StrSQL = "SELECT IdFactor ,Rate,d_date ,MonFac ,Pay ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,Rate,d_date,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorBuy WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorBuy  WHERE ListFactorBuy.IdFactor =AllTime.IdFactor)As MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitKharid WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk+MonSellChk),0)   FROM ListFactorBuy WHERE IdFactor= AllTime.IdFactor ) As Pay FROM (SELECT Wanted_Kharid.IdFactor, Wanted_Kharid.Rate,d_date FROM  Wanted_Kharid INNER JOIN ListFactorBuy ON Wanted_Kharid.IdFactor = ListFactorBuy.IdFactor WHERE ListFactorBuy.IdName=" & CLng(LIdname.Text) & ") As AllTime) As EndData"
                frmlk.StrSQL = "SELECT IdFactor,EndData.Rate,MaxNewDate,d_date ,MonFac ,Pay ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorBuy  WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorBuy  WHERE ListFactorBuy.IdFactor =AllTime.IdFactor)As MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitKharid WHERE IdFactor =AllTime.IdFactor  )+ (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitKharid  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk+MonSellChk),0)   FROM ListFactorBuy WHERE IdFactor= AllTime.IdFactor ) As Pay,(SELECT ISNULL(MAX(NewDate),'') FROM TimeKharid WHERE TimeKharid.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Kharid.IdFactor, Wanted_Kharid.Rate,d_date FROM  Wanted_Kharid INNER JOIN ListFactorBuy ON Wanted_Kharid.IdFactor = ListFactorBuy.IdFactor WHERE ListFactorBuy.IdName=" & CLng(LIdname.Text) & ") As AllTime) As EndData "
            End If
            frmlk.ShowDialog()
            DGV.Focus()
            If IdKala <> 0 Then
                DGV.AllowUserToAddRows = False
                DGV.Rows.Add()
                DGV.AllowUserToAddRows = True
                DGV.Item("Cln_IdFactor", DGV.RowCount - 2).Value = IdKala
                DGV.Item("Cln_Mon", DGV.RowCount - 2).Value = If(Tmp_Mon < 0, 0, Tmp_Mon)
                DGV.Item("Cln_Pay", DGV.RowCount - 2).Value = 0
                DGV.Item("Cln_IdFactor", DGV.RowCount - 2).Selected = False
                DGV.Item("Cln_Pay", DGV.RowCount - 2).Selected = True

            Else
                DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Selected = False
                DGV.Item("Cln_Pay", DGV.CurrentRow.Index).Selected = True
            End If
            Exit Sub
        End If
            '''''''''''''''''''''''''''''''''''کنترل پرداخت
            If DGV.CurrentCell.ColumnIndex = 2 Then
                If CStr(DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value) = "" Then
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
                Exit Sub
            End If
    End Sub
   
    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV.Item("Cln_IdFactor", DGV.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigitWithOutpoint(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If
            End If

            If DGV.RowCount > 0 Then
                TxtMonPay.Text = "0"
                For i As Integer = 0 To DGV.RowCount - 2
                    If (CheckDigit(DGV.Item("Cln_Pay", i).Value)) Then
                        TxtMonPay.Text = CDbl(TxtMonPay.Text) + CDbl(DGV.Item("Cln_Pay", i).Value.ToString)
                    End If
                Next i
                If TxtMonPay.Text.Length > 3 Then
                    Dim money As String = ""
                    money = TxtMonPay.Text.Replace(",", "")
                    TxtMonPay.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                TxtMonPay.Text = "0"
            End If
            Me.Caculate()
        Catch ex As Exception

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
        End If
    End Sub

    Private Sub FrmRelationFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BtnSave.Focus()
            DGV.EndEdit()
            If CStr(DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value) <> "" Then
                MessageBox.Show("وضعیت فاکتور در ردیف شماره " & "{" & DGV.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Selected = True
                DGV.Focus()
                Exit Sub
            End If
            For i As Integer = 0 To DGV.RowCount - 2
                If Trim(DGV.Item("Cln_IdFactor", i).Value) = "" Then
                    MessageBox.Show(" وضعيت سطر شماره" & "{ " & i + 1 & " }" & "  معلوم نيست يا به آن مقدار بدهيد يا آن را پاك كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If Trim(DGV.Item("Cln_Pay", i).Value) = "" Or DGV.Item("Cln_Pay", i).Value = 0 Then
                    MessageBox.Show(" مبلغ پرداختی سطر شماره" & "{ " & i + 1 & " }" & "  صفر است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If CDbl(DGV.Item("Cln_Pay", i).Value) > CDbl(DGV.Item("Cln_Mon", i).Value) Then
                    MessageBox.Show(" مبلغ پرداختی سطر شماره" & "{ " & i + 1 & " }" & "  بیشتر از بدهی فاکتور است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Counter As Long = 0
                For j As Integer = 0 To DGV.RowCount - 2
                    If CLng(DGV.Item("Cln_IdFactor", i).Value) = CLng(DGV.Item("Cln_IdFactor", j).Value) Then
                        Counter += 1
                    End If
                    If Counter > 1 Then
                        MessageBox.Show(" شماره فاکتور سطر شماره" & "{ " & i + 1 & " }" & "  تکراری است لطفا آن را اصلاح كنيد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Next
            Next
            If CDbl(LMon.Text) < CDbl(TxtMonPay.Text) Then
                MessageBox.Show("جمع پرداختی بیشتر از جمع کل سند مربوطه است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Array.Resize(LimitListArray, 0)
            For i As Integer = 0 To DGV.RowCount - 2
                Array.Resize(LimitListArray, LimitListArray.Length + 1)
                LimitListArray(LimitListArray.Length - 1).IdFactor = DGV.Item("Cln_IdFactor", i).Value
                LimitListArray(LimitListArray.Length - 1).Mon = CDbl(DGV.Item("Cln_Mon", i).Value)
                LimitListArray(LimitListArray.Length - 1).Pay = CDbl(DGV.Item("Cln_Pay", i).Value)
            Next
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmRelationFactor", "BtnSave_Click")
        End Try
    End Sub

    Private Sub FrmRelationFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Try
            If LimitListArray.Length > 0 Then
                TxtMonPay.Text = "0"
                DGV.AllowUserToAddRows = False
                For i As Integer = 0 To LimitListArray.Length - 1
                    DGV.Rows.Add()
                    DGV.Item("Cln_IdFactor", DGV.RowCount - 1).Value = LimitListArray(i).IdFactor
                    DGV.Item("Cln_Mon", DGV.RowCount - 1).Value = FormatNumber(LimitListArray(i).Mon, 0)
                    DGV.Item("Cln_Pay", DGV.RowCount - 1).Value = FormatNumber(LimitListArray(i).Pay, 0)
                Next
                DGV.AllowUserToAddRows = True
            Else
                TxtMonPay.Text = "0"
                TxtMandeh.Text = "0"
            End If
            Caculate()
            DGV.Columns("Cln_pay").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Caculate()
        Try
            Dim res As Double = 0
            For i As Integer = 0 To DGV.RowCount - 1
                res = res + CDbl(DGV.Item("Cln_Pay", i).Value)
            Next
            TxtMonPay.Text = res
            TxtMandeh.Text = CDbl(LMon.Text) - res

            Dim str As String

            If TxtMonPay.Text.Length > 3 Then
                str = Format$(TxtMonPay.Text.Replace(",", ""))
                TxtMonPay.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMonPay.Text = CDbl(TxtMonPay.Text)
            End If

            If TxtMandeh.Text.Length > 3 Then
                str = Format$(TxtMandeh.Text.Replace(",", ""))
                TxtMandeh.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMandeh.Text = CDbl(TxtMandeh.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMandeh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMandeh.TextChanged
        If String.IsNullOrEmpty(TxtMandeh.Text.Trim) Then
            TxtMandeh.BackColor = Color.Yellow
        ElseIf CDbl(TxtMandeh.Text.Trim) = 0 Then
            TxtMandeh.BackColor = Color.Yellow
        ElseIf CDbl(TxtMandeh.Text.Trim) > 0 Then
            TxtMandeh.BackColor = Color.White
        ElseIf CDbl(TxtMandeh.Text.Trim) < 0 Then
            TxtMandeh.BackColor = Color.Pink
        End If
    End Sub
End Class