Imports System.Data.SqlClient
Public Class SetChkBank

    Private Sub BtnCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCan.Click
        Me.Close()
    End Sub

    Private Sub Cmbtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbtype.GotFocus
        If Cmbtype.DroppedDown = False Then Cmbtype.DroppedDown = True
    End Sub

    Private Sub Cmbtype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbtype.KeyDown
        If e.KeyCode = Keys.Enter Then Txtmon1.Focus()
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If Cmbtype.DroppedDown = False Then Cmbtype.DroppedDown = True
        End If
        Me.getkey(e)
    End Sub

    Private Sub Cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbtype.SelectedIndexChanged
        Try
            If Cmbtype.Text <> "" Then
                If Txtmon1.Text = "" Then Txtmon1.Text = 0
                Txtmon2.Text = IIf(Txtmon1.Text = "", CDbl(Cmbtype.Text) - 1, CDbl(Txtmon1.Text) + CDbl(Cmbtype.Text) - 1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtmon1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmon1.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
        Me.getkey(e)
    End Sub

    Private Sub Txtmon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmon1.KeyPress
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

    Private Sub Txtmon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtmon1.TextChanged
        Try

            If Txtmon1.Text = "" Then Txtmon1.Text = 0
            If Txtmon2.Text = "" Then Txtmon2.Text = 0
            If Not (CheckDigit(Format$(Txtmon1.Text.Replace(",", "")))) Then
                Txtmon1.Text = 0
            End If
            Txtmon2.Text = IIf(Txtmon1.Text = "", CDbl(Cmbtype.Text) - 1, CDbl(Txtmon1.Text) + CDbl(Cmbtype.Text) - 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try

            If Cmbtype.Text = "" Then
                MessageBox.Show("نوع دسته چک راانتخاب كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cmbtype.Focus()
                Exit Sub
            End If
            If Trim(Txtmon2.Text) = "" Then
                MessageBox.Show("شماره چک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtmon2.Focus()
                Exit Sub
            End If
            If Txtmon2.Text <= 0 Then
                MessageBox.Show("شماره چک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtmon2.Focus()
                Exit Sub
            End If
            If Trim(Txtmon1.Text) = "" Then
                MessageBox.Show("شماره چک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtmon1.Focus()
                Exit Sub
            End If
            If CDbl(Txtmon1.Text) <= 0 Then
                MessageBox.Show("شماره چک نامعتبر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtmon1.Focus()
                Exit Sub
            End If
            Txtmon2.Text = CDbl(Txtmon1.Text) + CDbl(Cmbtype.Text) - 1
            '///////////////////////////////////////////////////////////////
            If CLng(Ledit.Text) = 0 Then
                If Not Me.AreYouAdd(CDbl(Txtmon1.Text), CDbl(Txtmon2.Text), CLng(LID.Text)) Then Exit Sub
                If MessageBox.Show("آیا برای ذخیره دسته چک مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                If SaveChk(CLng(LID.Text)) Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف دسته چک", "جدید", "بانک :" & LName.Text & " از شماره: " & Txtmon1.Text & " تا " & Txtmon2.Text, "")
                    Me.Close()
                End If
            ElseIf CLng(Ledit.Text) <> 0 Then
                If Not Me.AreYouEdit(CDbl(Txtmon1.Text), CDbl(Txtmon2.Text), CLng(LID.Text), CLng(Ledit.Text)) Then Exit Sub
                If MessageBox.Show("آیا برای ذخیره تغییرات مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                If EditChk(CLng(Ledit.Text)) Then
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف دسته چک", "ویرایش", "بانک :" & LName.Text & " از شماره: " & Txtmon1.Text & " تا " & Txtmon2.Text, "")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SetChkBank", "BtnSave_Click")
        End Try
    End Sub
    Private Function AreYouAdd(ByVal vl1 As Double, ByVal vl2 As Double, ByVal idb As Long) As Boolean
        Try
            Dim ds As New DataSet
            Dim str As String = "SELECT num1,num2 FROM Define_Chk WHERE (((" & vl1 & " Between num1 and num2) OR (" & vl2 & " Between num1 and num2)) AND Id=" & idb & ")"
            Dim dta As New SqlDataAdapter()
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_chk")
            If ds.Tables("Define_chk").Rows.Count > 0 Then
                MessageBox.Show("محدوده انتخابی شما نامعتبر است زبرا قبلا تعدادی از شمارههای آن در دسته چک دیگری ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SetChkBank", "AreYouAdd")
            Return False
        End Try
    End Function
    Private Function AreYouEdit(ByVal vl1 As Double, ByVal vl2 As Double, ByVal idb As Long, ByVal id As Long) As Boolean
        Try
            Dim ds As New DataSet
            Dim str As String = "SELECT num1,num2 FROM Define_Chk WHERE (((" & vl1 & " Between num1 and num2) OR (" & vl2 & " Between num1 and num2)) AND Id=" & idb & " And Aid<>" & id & ")"
            Dim dta As New SqlDataAdapter(str, DataSource)
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "Define_chk")
            If ds.Tables("Define_chk").Rows.Count > 0 Then
                MessageBox.Show("محدوده انتخابی شما نامعتبر است زبرا قبلا تعدادی از شمارههای آن در دسته چک دیگری ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SetChkBank", "AreYouEdit")
            Return False
        End Try
    End Function
    Private Function SaveChk(ByVal idb As Long) As Boolean
        Try
            Dim StrSelect As String = ""
            StrSelect = "INSERT INTO Define_Chk (Id,Num1,Num2,State) VALUES(" & CLng(idb) & "," & CLng(Txtmon1.Text.Trim) & "," & CLng(Txtmon2.Text.Trim) & "," & CLng(Cmbtype.Text) & ")"
            Dim CmdInsert As SqlCommand = New SqlCommand(StrSelect, ConectionBank)
            CmdInsert.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("دسته چک انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SetChkBank", "SaveChk")
            End If
            Return False
        End Try
    End Function
    Private Function EditChk(ByVal idb As Long) As Boolean
        Try
            If Me.GetCountstateForDel(CLng(Txtmon1.Text.Trim), CLng(Txtmon2.Text.Trim), CLng(LID.Text)) > 0 Then
                MessageBox.Show("دسته چک مورد نظر استفاده شده است و عملیات ویرایش بر روی آن قابل انجام نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            Dim StrSelect As String = ""
            StrSelect = "UPDATE Define_Chk SET Num1=" & CLng(Txtmon1.Text.Trim) & ",Num2=" & Txtmon2.Text.Trim & ",State=" & CLng(Cmbtype.Text) & " WHERE (((Define_Chk.[Aid])=" & idb & "))"
            Dim CmdInsert As SqlCommand = New SqlCommand(StrSelect, ConectionBank)
            CmdInsert.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("دسته چک انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SetChkBank", "EditChk")
            End If
            Return False
        End Try
    End Function
    Private Function GetCountstateForDel(ByVal NumChk1 As Double, ByVal NumChk2 As Double, ByVal Idbank As Long) As Long
        Try
            Using CMD As New SqlCommand("SELECT COUNT(Chk_Get_Pay.NumChk) as CountChk FROM Chk_Id INNER JOIN Chk_Get_Pay ON Chk_Id.Id = Chk_Get_Pay.ID WHERE (Current_Kind =1 AND Kind =1)  AND (IdBank =" & Idbank & ") AND (NumChk Between " & NumChk1 & " AND " & NumChk2 & ")", ConectionBank)
                Dim Res As Long = 1
                Res = CMD.ExecuteScalar
                Return Res
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Manage_Chk_Bank", "GetCountstateForDel")
            Return 1
        End Try
    End Function
    Private Sub SetChkBank_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Cmbtype.Focus()
    End Sub
    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Define_Bank.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then Call BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCan.Enabled = True Then Call BtnCan_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetChkBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub BtnCan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCan.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub BtnSave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnSave.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub Txtmon2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtmon2.KeyDown
        Me.getkey(e)
    End Sub

    Private Sub SetChkBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next

    End Sub
End Class