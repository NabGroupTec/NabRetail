Imports System.Data.SqlClient
Imports System.Transactions
Public Class Mobile_FrmFactor
    Dim state, Idfactor, lend, PrintSQl As String
    Dim q, SCost, dkALA, Mojody As Boolean
    Public Kfe As String
    Structure Kasri
        Dim IdKala As Long
        Dim Fe As Double
    End Structure
    Structure KalaDiscount
        Dim Idkala As Double
        Dim Kol As Double
        Dim joz As Double
        Dim Coding As String
        Dim CodeAnbar As Long
        Dim anbar As String
    End Structure
    Public Alldiscount(), Alldiscount2() As KalaDiscount
    Dim ListKasri() As Kasri
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub CalDarsad()
        Try
            If DGV1.Item("cln_name", DGV1.CurrentRow.Index).Value <> "" Then
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("cln_Money", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value) / 100, "###,###")
            End If

        Catch ex As Exception
            DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = 0
            DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = 0
        End Try
    End Sub
    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Try

            If e.ColumnIndex = 2 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If DGV1.Item("Cln_DK", e.RowIndex).Value = True Then
                            For i As Integer = 1 To 9
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 7
                                SendKeys.Send("+{TAB}")
                            Next
                        End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 3 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        For i As Integer = 1 To 7
                            SendKeys.Send("+{TAB}")
                        Next
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 5 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If CmbFac.Text = CmbFac.Items.Item(6) Then
                            For i As Integer = 1 To 4
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 6
                                SendKeys.Send("+{TAB}")
                            Next
                        End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.ColumnIndex = 6 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        If CmbFac.Text = CmbFac.Items.Item(8) Or (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                            For i As Integer = 1 To 2
                                SendKeys.Send("+{TAB}")
                            Next
                        Else
                            For i As Integer = 1 To 4
                                SendKeys.Send("+{TAB}")
                            Next
                        End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        txt_dgv = e.Control
    End Sub
    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    BtnKalaDiscount.Enabled = True
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                        DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                    End If
                    If DGV1.RowCount > 0 Then
                        Txtallmoney.Text = "0"
                        TxtMonFac.Text = "0"
                        For i As Integer = 0 To DGV1.RowCount - 2
                            If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                                Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                            End If
                            If (CheckDigit(DGV1.Item("Cln_DarsadMon", i).Value)) Then
                                TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value.ToString)
                            End If
                        Next i
                        If Txtallmoney.Text.Length > 3 Then
                            Dim money As String = ""
                            money = Txtallmoney.Text.Replace(",", "")
                            Txtallmoney.Text = Format$(Val(money), "###,###,###")
                        End If
                        If TxtMonFac.Text.Length > 3 Then
                            Dim money As String = ""
                            money = TxtMonFac.Text.Replace(",", "")
                            TxtMonFac.Text = Format$(Val(money), "###,###,###")
                        End If
                    Else
                        Txtallmoney.Text = "0"
                        TxtMonFac.Text = "0"
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
            CalculateMoney()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        Try
            If DGV1.Item("Cln_DK", e.RowIndex).Value = False Then
                DGV1.Rows(e.RowIndex).Cells("Cln_JozCount").Style.BackColor = Color.Gainsboro
            Else
                DGV1.Rows(e.RowIndex).Cells("Cln_JozCount").Style.BackColor = Nothing
            End If
            If DGV1.Item("cln_type", e.RowIndex).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", e.RowIndex).Value = "خدمات" Then
                DGV1.Rows(e.RowIndex).Cells("Cln_Anbar").Style.BackColor = Color.Gainsboro
            Else
                DGV1.Rows(e.RowIndex).Cells("Cln_Anbar").Style.BackColor = Nothing
            End If
            If Kfe = "V" Then
                If CDbl(DGV1.Item("Cln_Fe", e.RowIndex).Value) = If(DGV1.Item("Cln_OldFe", e.RowIndex).Value Is DBNull.Value, 0, CDbl(DGV1.Item("Cln_OldFe", e.RowIndex).Value)) Then
                    DGV1.Rows(e.RowIndex).Cells("Cln_Fe").Style.BackColor = Nothing
                Else
                    DGV1.Rows(e.RowIndex).Cells("Cln_Fe").Style.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbFac.KeyDown
        If CmbFac.DroppedDown = False Then
            CmbFac.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtDate.Focus()
        End If
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If TxtName.Enabled = True Then
            If e.KeyCode = Keys.Enter Then TxtName.Focus()
        Else
            If e.KeyCode = Keys.Enter Then TxtSanad.Focus()
        End If
    End Sub

    Private Sub TxtPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPart.KeyDown
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChkPart.Focus()
        End If
    End Sub

    Private Sub FrmFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Rate = 0
        q = False
        LEdit.Text = "0"
        TxtDate.ThisText = GetDate()
        Me.ShowKalafactor()
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Mojody = AreShowMojody()

        LimitMojody()
        Me.CheckLimit()

        BtnDiscount.Enabled = True
        BtnKalaDiscount.Enabled = True
        BtnSCost.Enabled = True
        BtnDiscount.Visible = True
        BtnSCost.Visible = True
        Tooldiscount.Visible = True
        ToolSCost.Visible = True
        BtnKalaDiscount.Visible = True
        BtnSback.Enabled = False
        BtnSback.Visible = False
        ToolSBack.Visible = False
        ToolKalaDiscount.Visible = True
        Me.SetButton()
    End Sub

    Private Sub CheckLimit()
        If LimitDate = True Then TxtDate.Enabled = False
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If LimitMonFac = True Then
            DGV1.Columns("Cln_Fe").ReadOnly = True
            DGV1.Columns("Cln_Fe").DefaultCellStyle.BackColor = Color.Gainsboro
        Else
            DGV1.Columns("Cln_Fe").ReadOnly = False
            DGV1.Columns("Cln_Fe").DefaultCellStyle.BackColor = Nothing
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If LimitHajm = True Then
            DGV1.Columns("Cln_Darsad").ReadOnly = True
            DGV1.Columns("Cln_Darsad").DefaultCellStyle.BackColor = Color.Gainsboro
        Else
            DGV1.Columns("Cln_Darsad").ReadOnly = False
            DGV1.Columns("Cln_Darsad").DefaultCellStyle.BackColor = Nothing
        End If
    End Sub

    Private Sub SetButton()
        Try
            CmbFac.Text = CmbFac.Items.Item(0)
            Access_Form = Get_Access_Form("F143")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    CmbFac.Text = CmbFac.Items.Item(0)
                Else

                    If Access_Form.Substring(5, 1) = 1 And Access_Form.Substring(6, 1) = 0 Then
                        CmbFac.Text = CmbFac.Items.Item(0)
                        CmbFac.Enabled = False
                    End If

                    If Access_Form.Substring(5, 1) = 0 And Access_Form.Substring(6, 1) = 1 Then
                        CmbFac.Text = CmbFac.Items.Item(1)
                        CmbFac.Enabled = False
                    End If

                End If
            Else
                CmbFac.Text = CmbFac.Items.Item(0)
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Factor_Sell.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnServiceKala.Enabled = True Then Call BtnServiceKala_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("هیچ طرف حسابی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FileCustomer
                FCustomer.LState.Text = GetStateFactor(CmbFac.Text)
                FCustomer.Lidname.Text = CLng(TxtIdPeople.Text)
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.CmbFac.Text = CmbFac.Text
                If (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                    FCustomer.LKala.Text = "SERVICE"
                    FCustomer.CmbFac.Enabled = False
                End If
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F7 Then
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FileAllCustomer
                FCustomer.LState.Text = GetStateFactor(CmbFac.Text)
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.CmbFac.Text = CmbFac.Text
                If (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                    FCustomer.LKala.Text = "SERVICE"
                    FCustomer.CmbFac.Enabled = False
                End If
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F8 Then
            If String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Or String.IsNullOrEmpty(TxtIdCityFac.Text.Trim) Then
                MessageBox.Show("هیچ طرف حسابی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                MessageBox.Show("کالای خدماتی جهت گزارش رابطه قیمت کالا در شهرستان مجاز نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FrmKalaCostRelation
                FCustomer.LCity.Text = TxtCity.Text
                FCustomer.LIdCity.Text = TxtIdCityFac.Text
                FCustomer.LKala.Text = DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value & "-" & DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value
                FCustomer.LIdKala.Text = DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F9 Then
            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی جهت گزارش قیمت تمام شده کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش قیمت تمام شده کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش قیمت تمام شده کالاانتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FrmEndCostKala
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F10 Then
            If BtnDiscount.Enabled = True And BtnDiscount.Visible = True Then Call BtnDiscount_Click(Nothing, Nothing)
            If BtnSback.Enabled = True And BtnSback.Visible = True Then Call BtnSback_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            If BtnKalaDiscount.Enabled = True And BtnKalaDiscount.Visible = True Then Call BtnKalaDiscount_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F12 Then
            If BtnSCost.Enabled = True And BtnSCost.Visible = True Then Call BtnSCost_Click(Nothing, Nothing)
        End If
    End Sub
    Private Function OkEnd() As Boolean
        Try
            Using Cmd As New SqlCommand("SELECT DK FROM Define_Kala WHERE Id=@ID", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                        If CBool(Cmd.ExecuteScalar()) <> CBool(DGV1.Item("Cln_DK", i).Value) Then
                            DGV1.Item("Cln_Name", i).Selected = True
                            Return False
                        End If
                        Cmd.Parameters.Clear()
                    End If
                Next i
                Return True
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "OkEnd")
            Return False
        End Try
    End Function
    Private Sub SaveOperation()
        Try
            CalculateAllRowMoney()
            Me.Enabled = False
            If Not ValidSell() Then
                Me.Enabled = True
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''

            If SCost = True And AreQustionForSCost() Then
                If MessageBox.Show("آیا میخواهید قیمت ویژه به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Call BtnSCost_Click(Nothing, Nothing)
                    DGV1.EndEdit()
                End If
            End If

            If q = True And AreQustionForDiscount() Then
                If MessageBox.Show("آیا میخواهید تخفیف حجمی به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Call BtnDiscount_Click(Nothing, Nothing)
                    DGV1.EndEdit()
                End If
            End If

            If dkALA = True And AreQustionForDiscountKala() Then
                If MessageBox.Show("آیا میخواهید جایزه به صورت اتوماتیک اختصاص داده شود؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Call BtnKalaDiscount_Click(Nothing, Nothing)
                    DGV1.EndEdit()
                End If
            End If

            Me.CalculateAllRowMoney()

            ''''''''''''''''''''''''''''''''
            If CmbFac.Text = CmbFac.Items.Item(1) Then
                If Not ValidSell() Then
                    Me.Enabled = True
                    Exit Sub
                End If
                Dim IdFac As Long = Me.SaveFactor(7)
                If IdFac = -1 Then
                    Me.Enabled = True
                    Exit Sub
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور موبایل", "تغییر وضعیت", "تغییر وضعیت فاکتور موبایل :" & LIdFac.Text & " به پیش فاکتور :" & IdFac, "")

                MessageBox.Show("پیش فاکتور فروش به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LEdit.Text = "1"
                Me.Close()
                '''''''''''''''''''''''''''''''''
            ElseIf CmbFac.Text = CmbFac.Items.Item(0) Then
                Using FrmPay As New Mobile_PayFactor
                    If LimitDec = True Then
                        FrmPay.TxtDecMon.Enabled = False
                        FrmPay.TxtDecDarsad.Enabled = False
                    End If
                    If LimitAdd = True Then
                        FrmPay.TxtAddMon.Enabled = False
                        FrmPay.TxtAddDarsad.Enabled = False
                    End If

                    Dim state1 As Long = 0
                    state1 = 3
                    Dim IdFac As Long = Me.SaveFactor(state1)
                    If IdFac = -1 Then
                        Me.Enabled = True
                        Exit Sub
                    End If
                    Idfactor = IdFac
                    state = 3
                    If state1 = 3 Then Rate = RasKalaFac("F", CLng(TxtIdPeople.Text), GetIdGroup(CLng(TxtIdPeople.Text)))
                    FrmPay.TxtFacMon.Text = Txtallmoney.Text.Trim
                    FrmPay.LMandeh.Text = 0
                    FrmPay.TxtLend.Text = CDbl(Txtallmoney.Text.Trim) - CDbl(TxtMonFac.Text.Trim)
                    FrmPay.TxtEndMon.Text = Txtallmoney.Text.Trim
                    FrmPay.TxtDiscountH.Text = TxtMonFac.Text.Trim
                    FrmPay.LName.Text = TxtName.Text
                    FrmPay.LIdname.Text = TxtIdPeople.Text
                    FrmPay.LDate.Text = TxtDate.ThisText
                    FrmPay.LIdFac.Text = IdFac
                    FrmPay.LHandNumber.Text = TxtSanad.Text.Trim
                    FrmPay.LState.Text = state
                    FrmPay.TxtAddDarsad.Text = "0"
                    FrmPay.TxtAddMon.Text = "0"
                    FrmPay.TxtDecDarsad.Text = "0"
                    FrmPay.TxtDecMon.Text = "0"
                    FrmPay.TxtDiscountC.Text = "0"
                    FrmPay.TxtDarDisH.Text = "0"
                    FrmPay.TxtDarDisC.Text = "0"
                    FrmPay.TxtCash.Text = "0"
                    FrmPay.Txtbank.Text = "0"
                    FrmPay.TxtChk.Text = "0"
                    FrmPay.LEdit.Text = "0"
                    FrmPay.LMFac.Text = LIdFac.Text
                    FrmPay.ShowDialog()
                    lend = CDbl(FrmPay.TxtLend.Text)
                    If FrmPay.LOk.Text = "0" Then
                        RoolBackFactor(IdFac, state)
                        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور موبایل", "تغییر وضعیت", " انصراف از شماره فاکتور:" & IdFac, "")
                        Me.Enabled = True
                        Exit Sub
                    End If
                    Dim strfac As String = ""
                    strfac = "فاکتور فروش "

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور موبایل", "تغییر وضعیت", "تغییر وضعیت فاکتور موبایل :" & LIdFac.Text & " به فاکتور فروش:" & IdFac, "")

                    MessageBox.Show(strfac & " به شماره " & IdFac & " ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LEdit.Text = "1"
                    Me.Close()
                End Using
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "SaveOperation")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        BtnSave.Focus()
        DGV1.EndEdit()

        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Or TxtDate.ThisText > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        If CmbFac.Text = "" Then
            MessageBox.Show("نوع فروش را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CmbFac.Focus()
            Exit Sub
        End If
        If BtnDiscount.Enabled = True Then
            q = True
        Else
            q = False
        End If

        If BtnSCost.Enabled = True Then
            SCost = True
        Else
            SCost = False
        End If

        DiscFactor = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", " " & TxtDisc.Text.Trim)

        If BtnKalaDiscount.Enabled = True Then
            dkALA = True
        Else
            dkALA = False
        End If
        Me.SaveOperation()

        CheckLimit()
    End Sub
    
    Private Function SaveFactor(ByVal state As Long) As Long
        Dim sqltransaction As New CommittableTransaction
        Dim IdFac As Long = 0
        Dim ListName As String = "ListFactorSell"
        Dim KalaName As String = "KalaFactorSell"
        
        Try
            If state = 3 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////
                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,Stat,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@Stat,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonPayChk,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(LUser.Text), Id_User, LUser.Text)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = state
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 0
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2

                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If

                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 0
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            ElseIf state = 7 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                ConectionBank.EnlistTransaction(sqltransaction)
                '////////////////////////////////////////

                Using Cmd As New SqlCommand("INSERT INTO " & ListName & "(D_date,IdName,Part,Sanad,IdVisitor,IdUser,Disc,Activ,Stat,MonAdd,MonDec,Discount,Cash,MonHavaleh,DiscHavaleh,MonPayChk,EditFlag) VALUES(@D_date,@IdName,@Part,@Sanad,@IdVisitor,@IdUser,@Disc,@Activ,@Stat,@MonAdd,@MonDec,@Discount,@Cash,@MonHavaleh,@DiscHavaleh,@MonPayChk,@EditFlag);SELECT @@IDENTITY", ConectionBank)
                    Cmd.Parameters.AddWithValue("@D_date", SqlDbType.NVarChar).Value = TxtDate.ThisText.Trim
                    Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(TxtIdPeople.Text.Trim), DBNull.Value, TxtIdPeople.Text)
                    Cmd.Parameters.AddWithValue("@Part", SqlDbType.BigInt).Value = IIf(ChkPart.Checked = True, TxtIdPart.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@Sanad", SqlDbType.NVarChar).Value = TxtSanad.Text.Trim
                    Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IIf(String.IsNullOrEmpty(LUser.Text), Id_User, LUser.Text)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TxtDisc.Text.Trim), "", TxtDisc.Text.Trim)
                    Cmd.Parameters.AddWithValue("@Stat", SqlDbType.Int).Value = state
                    Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                    Cmd.Parameters.AddWithValue("@MonAdd", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonDec", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Discount", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@Cash", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@MonHavaleh", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@DiscHavaleh", SqlDbType.NVarChar).Value = ""
                    Cmd.Parameters.AddWithValue("@MonPayChk", SqlDbType.BigInt).Value = 0
                    Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.BigInt).Value = 1
                    IdFac = Cmd.ExecuteScalar
                End Using

                Using Cmd As New SqlCommand("INSERT INTO " & KalaName & "(IdFactor,IdKala,IdService,KolCount,JozCount,Fe,DarsadDiscount,DarsadMon,Mon,IdAnbar,KalaDisc,Activ) VALUES(@IdFactor,@IdKala,@IdService,@KolCount,@JozCount,@Fe,@DarsadDiscount,@DarsadMon,@Mon,@IdAnbar,@KalaDisc,@Activ)", ConectionBank)
                    For i As Integer = 0 To DGV1.RowCount - 2

                        If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Else
                            Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.Parameters.AddWithValue("@IdService", SqlDbType.BigInt).Value = CLng(DGV1.Item("Cln_Code", i).Value)
                            Cmd.Parameters.AddWithValue("@IdAnbar", SqlDbType.BigInt).Value = DBNull.Value
                        End If

                        Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                        Cmd.Parameters.AddWithValue("@KolCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Cmd.Parameters.AddWithValue("@JozCount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Cmd.Parameters.AddWithValue("@Fe", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Fe", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadDiscount", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                        Cmd.Parameters.AddWithValue("@DarsadMon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                        Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("cln_Money", i).Value)
                        Cmd.Parameters.AddWithValue("@KalaDisc", SqlDbType.NVarChar).Value = IIf((DGV1.Item("Cln_Disc", i).Value Is DBNull.Value Or String.IsNullOrEmpty(DGV1.Item("Cln_Disc", i).Value)), "", DGV1.Item("Cln_Disc", i).Value)
                        Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Int).Value = 1
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Next i
                End Using
                If OkEnd() = False Then
                    sqltransaction.Rollback()
                    sqltransaction.Dispose()
                    MessageBox.Show(" تعریف دو واحده بودن بعضی از کالاها تغییر پیدا کرده است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return -1
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''
                Using Cmd As New SqlCommand("UPDATE  Mobile_ListFactorSell SET [Confirm]=3,Disc=@Disc,IdSell=@IdSell WHERE IdFactor =@IdFactor", ConectionBank)
                    Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = Tmp_String1
                    Cmd.Parameters.AddWithValue("@IdSell", SqlDbType.BigInt).Value = IdFac
                    Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = CLng(LIdFac.Text)
                    Cmd.ExecuteNonQuery()
                End Using
                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac

                '///////////////////////////////////////
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdFac
            End If
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فاکتور قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "SaveFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function
   
    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV1.CurrentCell.ColumnIndex = 1 Or DGV1.CurrentCell.ColumnIndex = 8 Then
                    e.Handled = True
                    Exit Sub
                End If
                BtnDiscount.Enabled = True
                BtnSCost.Enabled = True
                BtnKalaDiscount.Enabled = True
            End If
            If Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False
                DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_OldFe", DGV1.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGV1.UserDeletedRow
        Try
            If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True

            BtnDiscount.Enabled = True
            BtnSCost.Enabled = True
            BtnKalaDiscount.Enabled = True

            If DGV1.RowCount > 0 Then
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                        Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                    End If
                    If (CheckDigit(DGV1.Item("Cln_DarsadMon", i).Value)) Then
                        TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value.ToString)
                    End If
                Next i
                If Txtallmoney.Text.Length > 3 Then
                    Dim money As String = ""
                    money = Txtallmoney.Text.Replace(",", "")
                    Txtallmoney.Text = Format$(Val(money), "###,###,###")
                End If
                If TxtMonFac.Text.Length > 3 Then
                    Dim money As String = ""
                    money = TxtMonFac.Text.Replace(",", "")
                    TxtMonFac.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try

            ''''''''''''گرفتن نام کالا
            If DGV1.CurrentCell.ColumnIndex = 1 Then
                e.Handled = True
                If Mojody = False Then
                    Dim frmlk As New Kala_Anbar_List
                    frmlk.TxtSearch.Text = e.KeyChar()
                    frmlk.ShowDialog()
                Else
                    Dim frmlk As New Kala_Anbar_List_M
                    frmlk.TxtSearch.Text = e.KeyChar()
                    frmlk.ShowDialog()
                End If
                DGV1.Focus()
                If Tmp_Namkala <> "" Then
                    DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = Tmp_OneGroup + " - " + Tmp_TwoGroup
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                    DGV1.Item("Cln_vahed", DGV1.CurrentRow.Index).Value = TmpVahed
                    DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = namAnbar
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Disc", DGV1.CurrentRow.Index).Value = ""
                    DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = IdKala
                    DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = Idanbar
                    DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = DK
                    DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value = DK_KOL
                    DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value = DK_JOZ
                    DGV1.Item("Cln_OldFe", DGV1.CurrentRow.Index).Value = ""

                    DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value = FormatNumber(GetCostFrosh(IdKala, IIf(String.IsNullOrEmpty(TxtIdCityFac.Text), 0, TxtIdCityFac.Text), IIf(String.IsNullOrEmpty(TxtIdPeople.Text), 0, TxtIdPeople.Text)), 0)
                    IIf(String.IsNullOrEmpty(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value)

                    Me.GetMojodyKalaAnbar(IdKala, Idanbar, DGV1.CurrentRow.Index)
                    Me.RefreshMoney(DGV1.CurrentRow.Index)

                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Selected = True
                Else
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Selected = True
                End If
                CalDarsad()
                CalculateMoney()
                Exit Sub
            End If
           
            '''''''''''''''''''''''''''گرفتن نام انبار
            If DGV1.CurrentCell.ColumnIndex = 8 Then
                e.Handled = True
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then Exit Sub
                If DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات" Then Exit Sub
                Dim frmlk As New Anbar_Kala_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.LIdKala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                frmlk.Txtkala.Text = DGV1.Item("Cln_Type", DGV1.CurrentRow.Index).Value & " - " & DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value
                frmlk.ShowDialog()
                DGV1.Focus()
                If Tmp_Namkala <> "" Then
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Value = Tmp_Namkala
                    DGV1.Item("Cln_CodeAnbar", DGV1.CurrentRow.Index).Value = IdKala
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_disc", DGV1.CurrentRow.Index).Selected = True
                Else
                    DGV1.Item("Cln_Anbar", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_disc", DGV1.CurrentRow.Index).Selected = True
                End If
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''کنترل فی
            If DGV1.CurrentCell.ColumnIndex = 5 Then
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then
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
            ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزء
            If DGV1.CurrentCell.ColumnIndex = 3 Or DGV1.CurrentCell.ColumnIndex = 2 Or DGV1.CurrentCell.ColumnIndex = 6 Then
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then
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
                If e.KeyChar = "." Then
                    If InStr(txt_dgv.Text, "/") = False Then
                        e.Handled = False
                        e.KeyChar = "/"
                    End If
                End If
                Exit Sub
            End If
            '''''''''''کنترل شرح
            If DGV1.CurrentCell.ColumnIndex = 10 Then
                If DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = "" Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Me.CalDarsad()
                Exit Sub
            End If
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value = "" Then
                txt_dgv.Clear()
                Me.CalDarsad()
                Exit Sub
            End If
            If DGV1.CurrentCell.ColumnIndex = 5 Then
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
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_KolCOUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value), "###,###")
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                If CmbFac.Text = CmbFac.Items.Item(3) Then BtnDiscount.Enabled = True
            ElseIf DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value) Then DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                    If DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                Try
                    If DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value = 0
                End Try
                If CmbFac.Text = CmbFac.Items.Item(3) Then
                    BtnDiscount.Enabled = True
                    BtnSCost.Enabled = True
                    BtnKalaDiscount.Enabled = True
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End If
                If DGV1.Item("Cln_DK", DGV1.CurrentRow.Index).Value = False Then
                    txt_dgv.Text = 0
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value) * CDbl(DGV1.Item("Cln_KolCOUNT", DGV1.CurrentRow.Index).Value), "###,###")
                Else
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV1.Item("Cln_JOZ", DGV1.CurrentRow.Index).Value)) * CDbl(DGV1.Item("Cln_KOL", DGV1.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value), "###,###")
                End If
                Me.CalDarsad()
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                Try
                    If DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                    ' If DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = "" Then DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value = 0
                End Try
                If CmbFac.Text = CmbFac.Items.Item(3) Then
                    BtnDiscount.Enabled = True
                    BtnSCost.Enabled = True
                    BtnKalaDiscount.Enabled = True
                End If
            ElseIf DGV1.CurrentCell.ColumnIndex = 6 Then
                If Not (CheckDigit(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) > 100 Then txt_dgv.Text = 100
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = Format(CDbl(DGV1.Item("cln_Money", DGV1.CurrentRow.Index).Value) * CDbl(txt_dgv.Text) / 100, "###,###")
                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)

                DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value), 0, DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                If CmbFac.Text = CmbFac.Items.Item(3) Then BtnDiscount.Enabled = True
            ElseIf DGV1.CurrentCell.ColumnIndex = 8 Then
                If DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات" Then
                    txt_dgv.Clear()
                End If
            End If
            If DGV1.RowCount > 0 Then
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
                For i As Integer = 0 To DGV1.RowCount - 2
                    If (CheckDigit(DGV1.Item("Cln_Money", i).Value)) Then
                        Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("Cln_Money", i).Value.ToString)
                    End If
                    If (CheckDigit(DGV1.Item("Cln_DarsadMon", i).Value)) Then
                        TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value.ToString)
                    End If
                Next i
                If Txtallmoney.Text.Length > 3 Then
                    Dim money As String = ""
                    money = Txtallmoney.Text.Replace(",", "")
                    Txtallmoney.Text = Format$(Val(money), "###,###,###")
                End If
                If TxtMonFac.Text.Length > 3 Then
                    Dim money As String = ""
                    money = TxtMonFac.Text.Replace(",", "")
                    TxtMonFac.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                Txtallmoney.Text = "0"
                TxtMonFac.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnServiceKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnServiceKala.Click
        Try
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Dim frmlk As New Service_List
            frmlk.BtnNewP.Enabled = True
            frmlk.ShowDialog()
            DGV1.Focus()
            If Tmp_Namkala <> "" Then
                DGV1.AllowUserToAddRows = False
                DGV1.Rows.Add()
                DGV1.Item("cln_type", DGV1.RowCount - 1).Value = "کالای خدماتی"
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = Tmp_Namkala
                DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_vahed", DGV1.RowCount - 1).Value = "خدمات"
                DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = ""
                DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = 0
                DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = ""
                DGV1.Item("Cln_code", DGV1.RowCount - 1).Value = IdKala
                DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = False
                DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = 1
                DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = 1
                DGV1.Item("Cln_OldFe", DGV1.RowCount - 1).Value = 0
                DGV1.Rows(DGV1.RowCount - 1).Cells("Cln_Anbar").Style.BackColor = Color.Gainsboro
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = False
                DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Selected = True
                DGV1.AllowUserToAddRows = True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnServiceKala_Click")
        End Try
    End Sub
    
    Private Function ValidSell() As Boolean
        Try
            DGV1.EndEdit()
            DGV1.RefreshEdit()
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtName.Text.Trim) Or String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("طرف حساب را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Return False
            End If
            If ChkVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtVisitor.Text.Trim) Or String.IsNullOrEmpty(TxtIdVisitor.Text.Trim) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtVisitor.Focus()
                    Return False
                End If
            End If
            If ChkPart.Checked = True Then
                If String.IsNullOrEmpty(TxtPart.Text.Trim) Or String.IsNullOrEmpty(TxtIdPart.Text.Trim) Then
                    MessageBox.Show("پارت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPart.Focus()
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText.Trim) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Return False
            End If
            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Return False
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Return False
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value < 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Return False
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Return False
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Return False
                    End If
                    If (CDbl(DGV1.Item("Cln_Fe", i).Value) - (CDbl(DGV1.Item("Cln_DarsadMon", i).Value) / (If(CDbl(DGV1.Item("Cln_JozCount", i).Value) <= 0, CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value))))) < GetCostKalaWithDiscount(CLng(DGV1.Item("Cln_code", i).Value), (If(CDbl(DGV1.Item("Cln_JozCount", i).Value) <= 0, CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value))), (If(CDbl(DGV1.Item("Cln_JozCount", i).Value) <= 0, "KOL", "JOZ")), "", "", "True") Then
                        If MessageBox.Show("بهای فروش کالای سطر شماره" & i + 1 & " کمتر از بهای تمام شده است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return False
                    End If

                    If CmbFac.Text = CmbFac.Items(0) Then

                        If Not AreYouNativeKalaAnbar(CLng(DGV1.Item("Cln_code", i).Value), CDbl(DGV1.Item("Cln_KolCount", i).Value), CDbl(DGV1.Item("Cln_JozCount", i).Value), CLng(DGV1.Item("Cln_CodeAnbar", i).Value)) Then
                            If MAnbar = True Then
                                If MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return False
                            Else
                                MessageBox.Show("کالای سطر شماره" & i + 1 & " کمتر از موجودی انبار است و قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return False
                            End If
                        End If
                    End If

                End If
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If
                Next

                If count_Kala > 1 Then
                    If MessageBox.Show("کالای سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return False
                End If
                If count_Service > 1 Then
                    If MessageBox.Show("کالای خدماتی سطر شماره" & i + 1 & " تکراری است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return False
                End If
            Next
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "ValidSell")
            Return False
        End Try
    End Function

    Private Sub ShowKalafactor()
        Try
            Dim QueryInfo As String = "SELECT  Mobile_ListFactorSell.IdName,Define_People.Nam,Define_People.[Address],Define_People.IdCity,Define_Ostan .NamO +'-'+ Define_City .NamCI AS CityNam,Mobile_ListFactorSell.IdVisitor,Mobile_ListFactorSell.IdUser,NamVisit=CASE WHEN  Mobile_ListFactorSell.IdVisitor IS NULL THEN N'' ELSE (SELECT Nam FROM Define_Visitor WHERE Define_Visitor.Id =Mobile_ListFactorSell.IdVisitor) END FROM Mobile_ListFactorSell INNER JOIN Define_People ON Mobile_ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_People .IdOstan =Define_Ostan .Code INNER JOIN Define_City ON Define_People .IdCity =Define_City .Code WHERE Mobile_ListFactorSell.IdFactor =" & CLng(LIdFac.Text)

            Dim dtrInfo As SqlDataReader = Nothing

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    dtrInfo.Read()
                    If Not dtrInfo("IdVisitor") Is DBNull.Value Then
                        ChkVisitor.Checked = True
                        TxtIdVisitor.Text = dtrInfo("IdVisitor")
                        TxtVisitor.Text = dtrInfo("NamVisit")
                    Else
                        ChkVisitor.Checked = False
                        TxtIdVisitor.Text = ""
                        TxtVisitor.Text = ""
                    End If

                    If Not dtrInfo("IdUser") Is DBNull.Value Then
                        LUser.Text = dtrInfo("IdUser")
                    Else
                        LUser.Text = ""
                    End If

                    TxtName.Text = dtrInfo("Nam")
                    TxtIdPeople.Text = dtrInfo("Idname")
                    LDisc.Text = If(dtrInfo("Address") Is DBNull.Value, "", dtrInfo("Address"))
                    TxtCity.Text = dtrInfo("CityNam")
                    TxtIdCityFac.Text = dtrInfo("IdCity")

                    End If
            End Using
            dtrInfo.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '///////////////////////////////////
            Dim QueryKala As String = ""
            If Kfe = "S" Then
                QueryKala = "DECLARE @IdG bigint DECLARE @KindCost bigint SET @IdG =(SELECT  IdG=CASE WHEN ChkIdGroup ='True' THEN  IdGroup ELSE -1 END FROM Define_People WHERE Id=" & TxtIdPeople.Text & ") if (@IdG >0 ) SET @KindCost =(SELECT KindCost FROM Define_Group_P WHERE Id =@IdG) ELSE SET @KindCost=-1 SELECT *,Mon=CASE WHEN JozCount >0 THEN JozCount *Fe ELSE KolCount *Fe END FROM (SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Mobile_KalaFactorSell.IdKala,IdAnbar=(SELECT TOP 1 IdAnbar FROM  KalaFactorSell WHERE IdKala =Mobile_KalaFactorSell.IdKala ORDER BY ID  DESC) ,Mobile_KalaFactorSell.KolCount,Mobile_KalaFactorSell.JozCount,Fe=(SELECT CASE WHEN Fe>0 THEN Fe ELSE (SELECT ISNULL(SUM(Fe),0) As Fe FROM (SELECT TOP 1 Fe FROM (SELECT  Fe,KalaFactorSell.IdFactor  FROM KalaFactorSell WHERE  KalaFactorSell.IdKala =Mobile_KalaFactorSell.IdKala AND KalaFactorSell.Activ =1 AND KalaFactorSell.Fe >0 ) As ListKala INNER JOIN ListFactorSell On ListFactorSell.IdFactor =ListKala .IdFactor ORDER BY D_date  DESC) AS EndCost) END AS Fe FROM (SELECT ISNULL(SUM(Mfe),0) As Fe FROM (SELECT  TOP 1 Mfe=CASE WHEN @KindCost =0 THEN CostSmalKala WHEN @KindCost =1 THEN CostBigKala WHEN @KindCost =2 THEN EndCost ELSE CostBigKala End FROM Define_CostKala WHERE IdCity =" & TxtIdCityFac.Text & " AND IdKala =Mobile_KalaFactorSell.IdKala ORDER BY Id DESC) AS CityFe WHERE Mfe >0 ) AS ListCost) ,DarsadDiscount=0 ,DarsadMon=0 ,KalaDisc=N'',Define_Kala.Nam as NamKala,NamAnbar=(SELECT TOP 1 Define_Anbar.nam FROM KalaFactorSell INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID  WHERE IdKala =Mobile_KalaFactorSell.IdKala ORDER BY KalaFactorSell.ID  DESC),Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  Mobile_ListFactorSell INNER JOIN Mobile_KalaFactorSell ON Mobile_ListFactorSell.IdFactor = Mobile_KalaFactorSell.IdFactor INNER JOIN Define_Kala ON Mobile_KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id  WHERE Mobile_ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & ") AS ListKalaMobile"
            Else
                QueryKala = "DECLARE @IdG bigint DECLARE @KindCost bigint SET @IdG =(SELECT  IdG=CASE WHEN ChkIdGroup ='True' THEN  IdGroup ELSE -1 END FROM Define_People WHERE Id=" & TxtIdPeople.Text & ") if (@IdG >0 ) SET @KindCost =(SELECT KindCost FROM Define_Group_P WHERE Id =@IdG) ELSE SET @KindCost=-1 SELECT *,Mon=CASE WHEN JozCount >0 THEN JozCount *Fe ELSE KolCount *Fe END FROM (SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Mobile_KalaFactorSell.IdKala,ISNULL(Mobile_KalaFactorSell.IdAnbar,(SELECT TOP 1 IdAnbar FROM  KalaFactorSell WHERE IdKala =Mobile_KalaFactorSell.IdKala  ORDER BY ID  DESC)) AS IdAnbar,Mobile_KalaFactorSell.KolCount,Mobile_KalaFactorSell.JozCount,Mobile_KalaFactorSell.Fe,Mobile_KalaFactorSell.OldFe ,Mobile_KalaFactorSell.Discount AS DarsadDiscount ,DarsadMon=0 ,KalaDisc=N'',Define_Kala.Nam as NamKala,ISNULL((SELECT Define_Anbar.nam FROM Define_Anbar WHERE Define_Anbar.ID= Mobile_KalaFactorSell.IdAnbar ),(SELECT TOP 1 Define_Anbar.nam FROM KalaFactorSell INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID  WHERE IdKala =Mobile_KalaFactorSell.IdKala ORDER BY KalaFactorSell.ID  DESC))AS NamAnbar,Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  Mobile_ListFactorSell INNER JOIN Mobile_KalaFactorSell ON Mobile_ListFactorSell.IdFactor = Mobile_KalaFactorSell.IdFactor INNER JOIN Define_Kala ON Mobile_KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id  WHERE Mobile_ListFactorSell.IdFactor =" & CLng(LIdFac.Text) & ") AS ListKalaMobile"
            End If

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryKala, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    DGV1.AllowUserToAddRows = False
                    While dtrInfo.Read
                        DGV1.Rows.Add()
                        DGV1.Item("Cln_Type", DGV1.RowCount - 1).Value = dtrInfo("GroupKala")
                        DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value = dtrInfo("namKala")
                        DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = dtrInfo("KolCount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = dtrInfo("JozCount").ToString.Replace(".", "/")
                        DGV1.Item("Cln_OldKol", DGV1.RowCount - 1).Value = dtrInfo("KolCount")
                        DGV1.Item("Cln_OldJoz", DGV1.RowCount - 1).Value = dtrInfo("JozCount")
                        DGV1.Item("Cln_OldAnbar", DGV1.RowCount - 1).Value = "" 'dtrInfo("IdAnbar")
                        DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = dtrInfo("Vahed")
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = If(dtrInfo("Fe") Is DBNull.Value, 0, If(dtrInfo("Fe").ToString.Length > 3, Format(dtrInfo("Fe"), "###,###"), dtrInfo("Fe")))
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = IIf(dtrInfo("DarsadDiscount") Is DBNull.Value, 0, IIf(dtrInfo("DarsadDiscount") > 100, 100, dtrInfo("DarsadDiscount").ToString.Replace(".", "/")))
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = If(dtrInfo("DarsadMon").ToString.Length > 3, Format(dtrInfo("DarsadMon"), "###,###"), dtrInfo("DarsadMon"))
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = If(dtrInfo("NamAnbar") Is DBNull.Value, "", dtrInfo("NamAnbar"))
                        DGV1.Item("cln_Money", DGV1.RowCount - 1).Value = If(dtrInfo("Mon").ToString.Length > 3, Format(dtrInfo("Mon"), "###,###"), dtrInfo("Mon"))
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = dtrInfo("KalaDisc")
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = dtrInfo("IdKala")
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = If(dtrInfo("IdAnbar") Is DBNull.Value, "", dtrInfo("IdAnbar"))
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dtrInfo("DK")
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dtrInfo("DK_KOL")
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dtrInfo("DK_JOZ")
                        If Kfe = "V" Then
                            DGV1.Item("Cln_OldFe", DGV1.RowCount - 1).Value = If(dtrInfo("OldFe") Is DBNull.Value, 0, dtrInfo("OldFe"))
                        Else
                            DGV1.Item("Cln_OldFe", DGV1.RowCount - 1).Value = 0
                        End If
                    End While
                    DGV1.AllowUserToAddRows = True
                    DGV1.Sort(DGV1.Columns("Cln_Name"), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            '////////////////////////////
           
            Me.CalculateAllRowMoney()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "ShowKalaFactor")
            Me.Close()
        End Try
    End Sub
    Private Sub CalculateMoney()
        Dim allmoney As Double = 0
        Dim alldarsad As Double = 0
        For i As Integer = 0 To DGV1.Rows.Count - 2
            allmoney += If(DGV1.Item("cln_Money", i).Value Is DBNull.Value Or DGV1.Item("cln_Money", i).Value.ToString.Equals(""), 0, CDbl(DGV1.Item("cln_Money", i).Value))
            alldarsad += If(DGV1.Item("Cln_DarsadMon", i).Value Is DBNull.Value Or DGV1.Item("Cln_DarsadMon", i).Value.Equals(""), 0, CDbl(DGV1.Item("Cln_DarsadMon", i).Value))
        Next
        If alldarsad.ToString.Length > 3 Then
            TxtMonFac.Text = Format(alldarsad, "###,###")
        Else
            TxtMonFac.Text = alldarsad
        End If

        If allmoney.ToString.Length > 3 Then
            Txtallmoney.Text = Format(allmoney, "###,###")
        Else
            Txtallmoney.Text = allmoney
        End If
    End Sub

    Private Sub CalculateAllRowMoney()
        Try

            Dim allmoney As Double = 0
            Dim alldarsad As Double = 0
            For i As Integer = 0 To DGV1.Rows.Count - 2
                '///////////////////////////////////////////////

                If DGV1.Item("Cln_DK", i).Value = False Then
                    DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_Fe", i).Value) * If(String.IsNullOrEmpty(DGV1.Item("Cln_KolCOUNT", i).Value), 0, CDbl(DGV1.Item("Cln_KolCOUNT", i).Value)), "###,###")
                Else
                    DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_Fe", i).Value) * If(String.IsNullOrEmpty(DGV1.Item("Cln_JozCOUNT", i).Value), 0, CDbl(DGV1.Item("Cln_JozCOUNT", i).Value)), "###,###")
                End If
                DGV1.Item("Cln_Money", i).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_Money", i).Value), 0, DGV1.Item("Cln_Money", i).Value)
                DGV1.Item("Cln_DarsadMon", i).Value = Format(CDbl(DGV1.Item("cln_Money", i).Value) * CDbl(DGV1.Item("Cln_Darsad", i).Value) / 100, "###,###")
                DGV1.Item("Cln_DarsadMon", i).Value = If(String.IsNullOrEmpty(DGV1.Item("Cln_DarsadMon", i).Value), 0, DGV1.Item("Cln_DarsadMon", i).Value)

                '////////////////////////////////////////////////
                allmoney += CDbl(DGV1.Item("cln_Money", i).Value)
                alldarsad += CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
            Next
            If alldarsad.ToString.Length > 3 Then
                TxtMonFac.Text = Format(alldarsad, "###,###")
            Else
                TxtMonFac.Text = alldarsad
            End If

            If allmoney.ToString.Length > 3 Then
                Txtallmoney.Text = Format(allmoney, "###,###")
            Else
                Txtallmoney.Text = allmoney
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetMojodyKalaAnbar(ByVal Id As Long, ByVal IdAnar As Long, ByVal row As Integer)
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            'Using Cmd As New SqlCommand("SELECT AllKala.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllJozCount)JozCount FROM (SELECT ID FROM Define_Anbar WHERE Id=" & IdAnar & ") AS AllKala", ConectionBank)
            Using Cmd As New SqlCommand("SELECT AllKala.*,(SELECT ROUND(ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0),2) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT  ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL  SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllJozCount)JozCount FROM (SELECT ID FROM Define_Anbar WHERE Id=" & IdAnar & ") AS AllKala", ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    DGV1.Item("Cln_KolCount", row).Value = IIf(dtr("KolCount") > 0, dtr("KolCount").ToString.Replace(".", "/"), 0)
                    DGV1.Item("Cln_JozCount", row).Value = IIf(dtr("JozCount") > 0, dtr("JozCount").ToString.Replace(".", "/"), 0)
                Else
                    DGV1.Item("Cln_KolCount", row).Value = 0
                    DGV1.Item("Cln_JozCount", row).Value = 0
                End If
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFactor", "GetMojodyKalaAnbar")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            DGV1.Item("Cln_KolCount", row).Value = 0
            DGV1.Item("Cln_JozCount", row).Value = 0
        End Try
    End Sub

    Private Sub RefreshMoney(ByVal i As Integer)
        Try
            If DGV1.Item("Cln_DK", i).Value = False Then
                DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_KOL", i).Value) * CDbl(DGV1.Item("Cln_Fe", i).Value), "###,###")
            Else
                DGV1.Item("Cln_Money", i).Value = Format(CDbl(DGV1.Item("Cln_JozCount", i).Value) * CDbl(DGV1.Item("Cln_Fe", i).Value), "###,###")
            End If
            Me.CalDarsad()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "RefreshMoney")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            DGV1.Item("Cln_Money", i).Value = 0
        End Try
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            TxtPart.Enabled = True
            TxtPart.Focus()
        Else
            TxtPart.Enabled = False
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

    Private Sub ChkPart_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPart.GotFocus
        ChkPart.BackColor = Color.LightGray
    End Sub

    Private Sub ChkPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkPart.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ChkPart.Checked = True Then
                TxtPart.Focus()
            Else
                DGV1.Focus()
            End If
        End If
    End Sub

    Private Sub ChkPart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPart.LostFocus
        ChkPart.BackColor = Me.BackColor
    End Sub

    Private Sub TxtPart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPart.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Part_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtPart.Focus()
        If Tmp_Namkala <> "" Then
            TxtPart.Text = Tmp_Namkala
            TxtIdPart.Text = IdKala
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

    Private Sub BtnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscount.Click
        Try
            BtnDiscount.Enabled = False

            If String.IsNullOrEmpty(TxtIdPeople.Text) Then
                MessageBox.Show("طرف حسابی جهت اعمال تخفیف حجمی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If AreYouExistGroup(TxtIdPeople.Text) = False Then
                MessageBox.Show("گروه ویژه ایی برای طرف حساب مورد نظر انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            AutomaticDiscount(TxtIdPeople.Text, CDbl(Txtallmoney.Text))
            If TmpDarsad <= 0 Then
                MessageBox.Show(" تخفیفات حجمی به طرف حساب مورد نظر تعلق نمی گیرد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For i As Integer = 0 To DGV1.RowCount - 2
                Try
                    If CDbl(DGV1.Item("cln_Money", i).Value) > 0 And CDbl(DGV1.Item("Cln_Darsad", i).Value) < 100 Then
                        If Cash = True Then
                            If KalaCash(DGV1.Item("Cln_Code", i).Value, GetIdGroup(TxtIdPeople.Text)) = True Then Continue For
                            DGV1.Item("Cln_Darsad", i).Value = Replace(TmpDarsad + If(flagV > 0, CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", ".")), 0), ".", "/")
                            DGV1.Item("Cln_DarsadMon", i).Value = Format(CDbl(DGV1.Item("cln_Money", i).Value) * (CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))) / 100, "###,###")
                        Else
                            KalaCash(DGV1.Item("Cln_Code", i).Value, GetIdGroup(TxtIdPeople.Text))
                            DGV1.Item("Cln_Darsad", i).Value = Replace(TmpDarsad + If(flagV > 0, CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", ".")), 0), ".", "/")
                            DGV1.Item("Cln_DarsadMon", i).Value = Format(CDbl(DGV1.Item("cln_Money", i).Value) * (CDbl(DGV1.Item("Cln_Darsad", i).Value.ToString.Replace("/", "."))) / 100, "###,###")
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next
            CalculateAllRowMoney()
            BtnDiscount.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnDiscount_Click")
        End Try
    End Sub

    Private Function AreQustionForDiscount() As Boolean
        Try
            If String.IsNullOrEmpty(TxtIdPeople.Text) Then
                Return False
            End If

            If AreYouExistGroup(TxtIdPeople.Text) = False Then
                Return False
            End If

            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            AutomaticDiscount(TxtIdPeople.Text, CDbl(Txtallmoney.Text))
            If TmpDarsad <= 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "AreQustionForDiscount")
            Return False
        End Try
    End Function

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub BtnSback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSback.Click
        Try
            Using frmsback As New SFactor_List
                frmsback.ShowDialog()
                If SFactorArray.Length > 0 Then
                    TxtName.Text = frmsback.TxtPeople.Text
                    TxtIdPeople.Text = frmsback.TxtIdName.Text
                    If Not String.IsNullOrEmpty(frmsback.TxtIdVisitor.Text) Then
                        ChkVisitor.Checked = True
                        TxtIdVisitor.Text = frmsback.TxtIdVisitor.Text
                        TxtVisitor.Text = GetNamVisitor(frmsback.TxtIdVisitor.Text)
                    Else
                        ChkVisitor.Checked = False
                    End If
                    DGV1.AllowUserToAddRows = False
                    For i As Integer = 0 To SFactorArray.Length - 1
                        DGV1.Rows.Add()
                        DGV1.Item("cln_type", DGV1.RowCount - 1).Value = SFactorArray(i).GroupKala
                        DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = SFactorArray(i).NamKala
                        DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = Replace(SFactorArray(i).KolCount, ".", "/")
                        DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = Replace(SFactorArray(i).JozCount, ".", "/")
                        DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = SFactorArray(i).NamVahed
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = IIf(SFactorArray(i).Fe <= 0, 0, FormatNumber(SFactorArray(i).Fe, 0))
                        DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = Replace(SFactorArray(i).DarsadDiscount, ".", "/")
                        DGV1.Item("Cln_DarsadMon", i).Value = IIf(SFactorArray(i).DarsadMon <= 0, 0, FormatNumber(SFactorArray(i).DarsadMon, 0))
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = SFactorArray(i).NamAnbar
                        DGV1.Item("cln_Money", DGV1.RowCount - 1).Value = IIf(SFactorArray(i).Mon <= 0, 0, FormatNumber(SFactorArray(i).Mon, 0))
                        DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = SFactorArray(i).DK
                        DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = SFactorArray(i).DK_KOL
                        DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = SFactorArray(i).DK_JOZ
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = SFactorArray(i).IdKala
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = SFactorArray(i).CodeAnbar
                        DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = ""
                    Next
                    DGV1.AllowUserToAddRows = True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnSback_Click")
        End Try
    End Sub

    Private Sub BtnKalaDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKalaDiscount.Click
        Try
            BtnKalaDiscount.Enabled = False

            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Exit Sub
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Exit Sub
                    End If
                End If
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If
                Next
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Array.Resize(Alldiscount, 0)
            Array.Resize(Alldiscount2, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If CDbl(DGV1.Item("Cln_Fe", i).Value) > 0 And CDbl(DGV1.Item("Cln_Darsad", i).Value) < 100 And Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then

                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).joz += CDbl(DGV1.Item("Cln_JozCount", i).Value)
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).joz = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).CodeAnbar = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Alldiscount(Alldiscount.Length - 1).anbar = DGV1.Item("Cln_Anbar", i).Value
                        Alldiscount(Alldiscount.Length - 1).Coding = GetCoding(CLng(DGV1.Item("Cln_Code", i).Value))
                    End If
                End If
            Next

            flag = False

            For i As Integer = 0 To Alldiscount.Count - 1


                For ai As Integer = 0 To Alldiscount2.Length - 1
                    If (Alldiscount2(ai).Coding = Alldiscount(i).Coding) And (Alldiscount2(ai).Coding <> "" And Alldiscount(i).Coding <> "") Then
                        Alldiscount2(ai).joz += Alldiscount(i).joz
                        Alldiscount2(ai).Kol += Alldiscount(i).Kol
                        flag = True
                        Exit For
                    End If
                    flag = False
                Next
                If flag = False Then
                    Array.Resize(Alldiscount2, Alldiscount2.Length + 1)
                    Alldiscount2(Alldiscount2.Length - 1).Idkala = Alldiscount(i).Idkala
                    Alldiscount2(Alldiscount2.Length - 1).joz = Alldiscount(i).joz
                    Alldiscount2(Alldiscount2.Length - 1).Kol = Alldiscount(i).Kol
                    Alldiscount2(Alldiscount2.Length - 1).CodeAnbar = Alldiscount(i).CodeAnbar
                    Alldiscount2(Alldiscount2.Length - 1).anbar = Alldiscount(i).anbar
                    Alldiscount2(Alldiscount2.Length - 1).Coding = Alldiscount(i).Coding
                End If
            Next
            CalKalaDiscount(Alldiscount2)
            CalculateAllRowMoney()
            BtnKalaDiscount.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnKalaDiscount_Click")
        End Try
    End Sub

    Private Function AreQustionForDiscountKala() As Boolean
        Try
            Array.Resize(Alldiscount, 0)
            Array.Resize(Alldiscount2, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If CDbl(DGV1.Item("Cln_Fe", i).Value) > 0 And CDbl(DGV1.Item("Cln_Darsad", i).Value) < 100 And Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then

                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).joz += CDbl(DGV1.Item("Cln_JozCount", i).Value)
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).joz = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                        Alldiscount(Alldiscount.Length - 1).CodeAnbar = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                        Alldiscount(Alldiscount.Length - 1).anbar = DGV1.Item("Cln_Anbar", i).Value
                        Alldiscount(Alldiscount.Length - 1).Coding = GetCoding(CLng(DGV1.Item("Cln_Code", i).Value))
                    End If
                End If
            Next

            flag = False

            For i As Integer = 0 To Alldiscount.Count - 1

                For ai As Integer = 0 To Alldiscount2.Length - 1
                    If (Alldiscount2(ai).Coding = Alldiscount(i).Coding) And (Alldiscount2(ai).Coding <> "" And Alldiscount(i).Coding <> "") Then
                        Alldiscount2(ai).joz += Alldiscount(i).joz
                        Alldiscount2(ai).Kol += Alldiscount(i).Kol
                        flag = True
                        Exit For
                    End If
                    flag = False
                Next
                If flag = False Then
                    Array.Resize(Alldiscount2, Alldiscount2.Length + 1)
                    Alldiscount2(Alldiscount2.Length - 1).Idkala = Alldiscount(i).Idkala
                    Alldiscount2(Alldiscount2.Length - 1).joz = Alldiscount(i).joz
                    Alldiscount2(Alldiscount2.Length - 1).Kol = Alldiscount(i).Kol
                    Alldiscount2(Alldiscount2.Length - 1).CodeAnbar = Alldiscount(i).CodeAnbar
                    Alldiscount2(Alldiscount2.Length - 1).anbar = Alldiscount(i).anbar
                    Alldiscount2(Alldiscount2.Length - 1).Coding = Alldiscount(i).Coding
                End If
            Next
            Return AreCalKalaDiscount(Alldiscount2)
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnKalaDiscount_Click")
            Return False
        End Try
    End Function
    Private Function GetCoding(ByVal Id As Long) As String
        Try
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using cmd As New SqlCommand("SELECT  ISNULL(Coding,'') As Coding FROM ListKala_Discount WHERE Idkala =" & Id, ConectionBank)
                dtr = cmd.ExecuteReader()
            End Using
            If dtr.HasRows Then
                dtr.Read()
                Dim str As String = ""
                str = dtr("Coding")
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return str
            Else
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return ""
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnKalaDiscount_Click")
            Return ""
        End Try
    End Function
    Private Sub CalKalaDiscount(ByVal ListDiscount() As KalaDiscount)
        Try
            Dim dt As New DataTable
            Dim AFlag As Boolean = False
            For i As Integer = 0 To ListDiscount.Length - 1
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                dt.Clear()
                AFlag = False
                Using cmd As New SqlCommand("SELECT AutoDiscount FROM ListKala_Discount WHERE Idkala =" & ListDiscount(i).Idkala, ConectionBank)
                    AFlag = CBool(cmd.ExecuteScalar)
                End Using

                If AFlag = False Then
                    Using cmd As New SqlCommand("SELECT C_Count=1,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MAX(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                Else
                    Using cmd As New SqlCommand("SELECT C_Count=CASE WHEN KolCount<=" & ListDiscount(i).Kol & " THEN " & ListDiscount(i).Kol & "/KolCount ELSE 0 END,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MIN(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                End If

                If dt.Rows.Count <= 0 Then Continue For
                For j As Integer = 0 To dt.Rows.Count - 1

                    DGV1.AllowUserToAddRows = False
                    DGV1.Rows.Add()
                    '''''''''''''''''''''''''''''''''''
                    DGV1.Item("Cln_type", DGV1.RowCount - 1).Value = dt.Rows(j).Item("GroupKala")
                    DGV1.Item("Cln_name", DGV1.RowCount - 1).Value = dt.Rows(j).Item("NamKala")
                    DGV1.Item("Cln_KolCount", DGV1.RowCount - 1).Value = Replace(dt.Rows(j).Item("Kol") * Fix(dt.Rows(j).Item("C_Count")), ".", "/")
                    DGV1.Item("Cln_JozCount", DGV1.RowCount - 1).Value = Replace(dt.Rows(j).Item("Joz") * Fix(dt.Rows(j).Item("C_Count")), ".", "/")
                    DGV1.Item("Cln_Vahed", DGV1.RowCount - 1).Value = dt.Rows(j).Item("NamVahed")
                    DGV1.Item("Cln_Darsad", DGV1.RowCount - 1).Value = 100

                    If dt.Rows(j).Item("anbar") = 1 Then
                        Dim fe As Double = 0
                        fe = GetCostFrosh(dt.Rows(j).Item("IdKala"), IIf(String.IsNullOrEmpty(TxtIdCityFac.Text), 0, TxtIdCityFac.Text), IIf(String.IsNullOrEmpty(TxtIdPeople.Text), 0, TxtIdPeople.Text))
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = IIf(fe > 0, FormatNumber(fe, 0), 0)
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = If(dt.Rows(j).Item("Joz") > 0, FormatNumber(fe * dt.Rows(j).Item("Joz"), 0), FormatNumber(fe * dt.Rows(j).Item("Kol"), 0))
                        DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = If(dt.Rows(j).Item("Joz") > 0, FormatNumber(fe * dt.Rows(j).Item("Joz"), 0), FormatNumber(fe * dt.Rows(j).Item("Kol"), 0))
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = ListDiscount(i).anbar
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = ListDiscount(i).CodeAnbar
                    Else
                        DGV1.Item("Cln_Fe", DGV1.RowCount - 1).Value = 0
                        DGV1.Item("Cln_DarsadMon", DGV1.RowCount - 1).Value = 100
                        DGV1.Item("Cln_Money", DGV1.RowCount - 1).Value = 0
                        DGV1.Item("Cln_Anbar", DGV1.RowCount - 1).Value = ""
                        DGV1.Item("Cln_CodeAnbar", DGV1.RowCount - 1).Value = ""
                    End If

                    DGV1.Item("Cln_Disc", DGV1.RowCount - 1).Value = "جایزه"
                    DGV1.Item("Cln_code", DGV1.RowCount - 1).Value = dt.Rows(j).Item("IdKala")
                    DGV1.Item("Cln_DK", DGV1.RowCount - 1).Value = dt.Rows(j).Item("DK")
                    DGV1.Item("Cln_KOL", DGV1.RowCount - 1).Value = dt.Rows(j).Item("DK_KOL")
                    DGV1.Item("Cln_JOZ", DGV1.RowCount - 1).Value = dt.Rows(j).Item("DK_JOZ")
                    '''''''''''''''''''''''''''''''''''
                    DGV1.AllowUserToAddRows = True
                Next j
            Next i
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "CalKalaDiscount")
        End Try
    End Sub

    Private Function AreCalKalaDiscount(ByVal ListDiscount() As KalaDiscount) As Boolean
        Try
            Dim dt As New DataTable
            Dim AFlag As Boolean = False
            For i As Integer = 0 To ListDiscount.Length - 1
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                dt.Clear()
                AFlag = False
                Using cmd As New SqlCommand("SELECT AutoDiscount FROM ListKala_Discount WHERE Idkala =" & ListDiscount(i).Idkala, ConectionBank)
                    AFlag = CBool(cmd.ExecuteScalar)
                End Using

                If AFlag = False Then
                    Using cmd As New SqlCommand("SELECT C_Count=1,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MAX(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                Else
                    Using cmd As New SqlCommand("SELECT C_Count=CASE WHEN KolCount<=" & ListDiscount(i).Kol & " THEN " & ListDiscount(i).Kol & "/KolCount ELSE 0 END,anbar ,Idkala ,Kol ,Joz ,DK ,DK_KOL ,DK_JOZ ,NamKala ,Namvahed ,GroupKala  FROM (SELECT KolCount,anbar=1,Idkala ,Kol ,Joz ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,Define_Kala .Nam As NamKala ,Define_Vahed .Nam As Namvahed,Define_OneGroup .NamOne +' - '+ Define_TwoGroup .NamTwo AS GroupKala FROM (SELECT  Kala_Discount.Idkala,KolCount,JozCount,Kol,Joz FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Kala ON Define_Kala .Id =Listkala.Idkala INNER JOIN Define_Vahed ON Define_Vahed .Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo  UNION ALL SELECT KolCount,anbar=0,IdService as IdKala ,Kol ,Joz ,DK='False' ,DK_KOL=1 ,DK_JOZ=1 ,Define_Service .Nam As NamKala ,Namvahed=N'خدمات',GroupKala=N'کالای خدماتی'  FROM (SELECT  Kala_Discount.IdService, KolCount, JozCount, Kol, Joz  FROM  ListKala_Discount INNER JOIN  Kala_Discount ON ListKala_Discount.Idkala = Kala_Discount.IdKalaLink WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & " ) As Listkala INNER JOIN Define_Service  ON Define_Service.Id =Listkala.IdService) As AllKalaList WHERE KolCount =(SELECT  ISNULL(MIN(KolCount),0) As BigId FROM  Kala_Discount  WHERE IdKalaLink =" & ListDiscount(i).Idkala & " AND KolCount <=" & ListDiscount(i).Kol & " AND JozCount <=" & ListDiscount(i).joz & ")", ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                End If

                If dt.Rows.Count <= 0 Then
                    Continue For
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                End If
            Next i

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return False
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "AreCalKalaDiscount")
            Return False
        End Try
    End Function

    Private Sub BtnSCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSCost.Click
        Try
            BtnKalaDiscount.Enabled = False

            If String.IsNullOrEmpty(TxtIdPeople.Text) Then
                MessageBox.Show("طرف حسابی جهت اعمال قیمت ویژه انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtName.Focus()
                Exit Sub
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If AreYouExistGroup(TxtIdPeople.Text) = False Then
                MessageBox.Show("گروه ویژه ایی برای طرف حساب مورد نظر انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Exit Sub
            End If

            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If
            Dim C_Service As Long = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                '//////////////////بررسی نام کالا
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Exit Sub
                End If
                '//////////////////بررسی تعداد کالا
                If DGV1.Item("Cln_DK", i).Value = False Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                Else
                    If String.IsNullOrEmpty(DGV1.Item("Cln_KolCount", i).Value) Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_KolCount", i).Value <= 0 Then
                        MessageBox.Show("تعداد کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_KolCount", i).Selected = True
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(DGV1.Item("Cln_JozCount", i).Value) Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                    If DGV1.Item("Cln_JozCount", i).Value <= 0 Then
                        MessageBox.Show("نسبت جزء کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_JozCount", i).Selected = True
                        Exit Sub
                    End If
                End If
                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    If String.IsNullOrEmpty(DGV1.Item("Cln_Anbar", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_CodeAnbar", i).Value) Then
                        MessageBox.Show("نام انبار در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DGV1.Focus()
                        DGV1.Item("Cln_Anbar", i).Selected = True
                        Exit Sub
                    End If
                End If
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then C_Service += 1
                If C_Service = DGV1.RowCount - 1 Then
                    MessageBox.Show("در فاکتور مورد نظر هیچ کالایی وجود ندارد و فقط از کالای خدماتی استفاده شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                Dim count_Service As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات" Then
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Service += 1
                        End If
                    Else
                        If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                            count_Kala += 1
                        End If
                    End If
                Next
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Array.Resize(Alldiscount, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    End If
                End If
            Next
            CalScost(Alldiscount, GetIdGroup(TxtIdPeople.Text))
            CalculateAllRowMoney()
            BtnSCost.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "BtnSCost_Click")
        End Try
    End Sub

    Private Function AreQustionForSCost() As Boolean
        Try
            Array.Resize(Alldiscount, 0)
            Dim flag As Boolean = False
            For i As Integer = 0 To DGV1.RowCount - 2

                If Not (DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات") Then
                    For ai As Integer = 0 To Alldiscount.Length - 1
                        If Alldiscount(ai).Idkala = CLng(DGV1.Item("Cln_Code", i).Value) Then
                            Alldiscount(ai).Kol += CDbl(DGV1.Item("Cln_KolCount", i).Value)
                            flag = True
                            Exit For
                        End If
                        flag = False
                    Next
                    If flag = False Then
                        Array.Resize(Alldiscount, Alldiscount.Length + 1)
                        Alldiscount(Alldiscount.Length - 1).Idkala = CLng(DGV1.Item("Cln_Code", i).Value)
                        Alldiscount(Alldiscount.Length - 1).Kol = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    End If
                End If
            Next
            Return AreCalScost(Alldiscount, GetIdGroup(TxtIdPeople.Text))
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "AreQustionForSCost")
            Return False
        End Try
    End Function
    Private Sub CalScost(ByVal ListDiscount() As KalaDiscount, ByVal IdGroup As Long)
        Try
            Dim Fe As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            For i As Integer = 0 To ListDiscount.Length - 1
                Fe.Clear()
                Using cmd As New SqlCommand("SELECT ISNULL (MAX(FeKol ),0) as Fe ,ISNULL (MAX(Darsad ),0) as Darsad FROM (SELECT TOP 1 DefineListPromotion.Darsad  ,DefinePromotion.Fe AS FeKol FROM DefineListPromotion INNER JOIN DefinePromotion ON DefineListPromotion.IdLink = DefinePromotion.Id WHERE IdGroup =" & IdGroup & " AND IdKala =" & ListDiscount(i).Idkala & " AND AzKala <=" & ListDiscount(i).Kol & " AND TaKala >=" & ListDiscount(i).Kol & " ORDER BY TaKala DESC ) AS SCost", ConectionBank)
                    Fe.Load(cmd.ExecuteReader)
                End Using
                If Fe.Rows.Count <= 0 Then Continue For
                For j As Integer = 0 To DGV1.RowCount - 2
                    If Not (DGV1.Item("cln_type", j).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", j).Value = "خدمات") Then
                        If DGV1.Item("Cln_Code", j).Value = ListDiscount(i).Idkala Then
                            If Fe.Rows(0).Item("Fe") = 0 And Fe.Rows(0).Item("Darsad") = 0 Then Continue For
                            DGV1.Item("Cln_Fe", j).Value = IIf(Fe.Rows(0).Item("Fe") = 0, 0, FormatNumber(Fe.Rows(0).Item("Fe"), 0))
                            DGV1.Item("Cln_Darsad", j).Value = Fe.Rows(0).Item("Darsad").ToString.Replace(".", "/")
                        End If
                    End If
                Next
            Next i
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "CalSCost")
        End Try
    End Sub
    Private Function AreCalScost(ByVal ListDiscount() As KalaDiscount, ByVal IdGroup As Long) As Boolean
        Try
            Dim Fe As Double = 0
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            For i As Integer = 0 To ListDiscount.Length - 1
                Fe = -1
                Using cmd As New SqlCommand("SELECT ISNULL (SUM(Fe),-1) as Fe FROM (SELECT TOP 1 DefineListPromotion.Fe FROM DefineListPromotion INNER JOIN DefinePromotion ON DefineListPromotion.IdLink = DefinePromotion.Id WHERE IdGroup =" & IdGroup & " AND IdKala =" & ListDiscount(i).Idkala & " AND AzKala <=" & ListDiscount(i).Kol & " AND TaKala >=" & ListDiscount(i).Kol & " ORDER BY TaKala DESC ) AS SCost", ConectionBank)
                    Fe = cmd.ExecuteScalar
                End Using
                If Fe <= -1 Then
                    Continue For
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                End If

            Next i
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return False
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "AreCalScost")
            Return False
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LEdit.Text = "0"
        Me.Close()
    End Sub

    Private Function RasKalaFac(ByVal Kind As String, ByVal IdP As Long, ByVal IdG As Long) As Long
        Try
            Dim str(DGV1.RowCount - 2) As String
            Dim Query As String = ""
            Dim Rate As Long = 0


            For i As Integer = 0 To DGV1.RowCount - 2
                If DGV1.Item("cln_type", i).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", i).Value = "خدمات" Then
                    If Kind = "F" Then
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT Rate FROM  Define_ListKalaRate WHERE IdKalaLink =0 AND IdGroup =0) AS ListRate"
                    Else
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT BRate AS Rate FROM  Define_KalaRate WHERE IdKala =0) AS ListRate"
                    End If
                Else
                    If Kind = "F" Then
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT Rate FROM  Define_ListKalaRate WHERE IdKalaLink =" & CLng(DGV1.Item("Cln_Code", i).Value) & " AND IdGroup =" & IdG & ") AS ListRate"
                    Else
                        str(i) = "SELECT Mon=" & CDbl(DGV1.Item("cln_Money", i).Value) & ",AllMon=" & CDbl(DGV1.Item("cln_Money", i).Value) & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT BRate AS Rate FROM  Define_KalaRate WHERE IdKala =" & CLng(DGV1.Item("Cln_Code", i).Value) & ") AS ListRate"
                    End If
                End If
            Next
            Query = "SELECT ISNULL(SUM(AllMon),0)/ISNULL(SUM(Mon),0) AS Rate FROM("
            For i As Integer = 0 To str.Length - 1
                Query &= str(i) & " UNION ALL "
            Next


            Query = Query.Substring(0, Query.Length - 12) & " ) AS ListMon "


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Query, ConectionBank)
                Rate = cmd.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return Rate
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_FrmFactor", "RasKalaFac")
            Return 0
        End Try
    End Function

    Private Sub CmbFac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFac.SelectedIndexChanged
        CheckLimit()
    End Sub
End Class