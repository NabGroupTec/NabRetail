Imports System.Data.SqlClient
Public Class FrmPathChk
    Private Sub getkey(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Jaryan_Chk.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmPathChk_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtChk.Focus()
    End Sub

    Private Sub FrmPathChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub FrmPathChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F94")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
            End If

        End If
        Rdogetchk.Checked = True
        Rdonumchk.Checked = True
    End Sub

    Private Sub Rdogetchk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdogetchk.CheckedChanged
        If Rdogetchk.Checked = True Then
            Lbank.Visible = False
            Cbobank.Visible = False
            If Rdosanad.Checked = True Then
                Lsanad.Visible = True
                Txtsanad.Visible = True
                TxtChk.Visible = False
                Lchk.Visible = False
                Txtsanad.Focus()
            ElseIf Rdonumchk.Checked = True Then
                Lsanad.Visible = False
                Txtsanad.Visible = False
                TxtChk.Visible = True
                Lchk.Visible = True
                TxtChk.Focus()
            End If
        End If
    End Sub

    Private Sub Rdopaychk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdopaychk.CheckedChanged
        If Rdopaychk.Checked = True Then
            If Rdosanad.Checked = True Then
                Lsanad.Visible = True
                Txtsanad.Visible = True
                TxtChk.Visible = False
                Lchk.Visible = False
                Lbank.Visible = False
                cbobank.Visible = False
                Txtsanad.Focus()
            ElseIf Rdonumchk.Checked = True Then
                Lsanad.Visible = False
                Txtsanad.Visible = False
                TxtChk.Visible = True
                Lchk.Visible = True
                Lbank.Visible = True
                cbobank.Visible = True
                TxtChk.Focus()
            End If
        End If
    End Sub

    Private Sub Rdonumchk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdonumchk.CheckedChanged
        If Rdonumchk.Checked = True Then
            Lsanad.Visible = False
            Txtsanad.Visible = False
            TxtChk.Visible = True
            Lchk.Visible = True
            If Rdogetchk.Checked = True Then
                Lbank.Visible = False
                Cbobank.Visible = False
            ElseIf Rdopaychk.Checked = True Then
                Lbank.Visible = True
                Cbobank.Visible = True
            End If
            TxtChk.Focus()
        End If
    End Sub

    Private Sub Rdosanad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdosanad.CheckedChanged
        If Rdosanad.Checked = True Then
            Lsanad.Visible = True
            Txtsanad.Visible = True
            TxtChk.Visible = False
            Lchk.Visible = False
            Lbank.Visible = False
            cbobank.Visible = False
            Txtsanad.Focus()
        End If
    End Sub

    Private Sub Txtsanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtsanad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Txtsanad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtsanad.KeyPress
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

    Private Sub Txtsanad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsanad.TextChanged
        If Not (CheckDigit(Format$(Txtsanad.Text.Replace(",", "")))) Then
            Txtsanad.Text = ""
            Exit Sub
        End If
        Txtsanad.Text = CDbl(Txtsanad.Text)
    End Sub

    Private Sub TxtChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChk.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TxtChk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChk.KeyPress
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

    Private Sub TxtChk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtChk.TextChanged
        If Not (CheckDigit(Format$(TxtChk.Text.Replace(",", "")))) Then
            TxtChk.Text = ""
            Exit Sub
        End If
        TxtChk.Text = CDbl(TxtChk.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Rdonumchk.Checked = True Then
                If String.IsNullOrEmpty(TxtChk.Text.Trim) Then
                    MessageBox.Show("لطفا شماره چک را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtChk.Focus()
                    Exit Sub
                End If
                If Rdopaychk.Checked = True Then
                    If cbobank.Text = "" Or String.IsNullOrEmpty(Txtidbank.Text) Then
                        MessageBox.Show("لطفا بانک را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cbobank.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If Rdosanad.Checked = True Then
                If String.IsNullOrEmpty(Txtsanad.Text.Trim) Then
                    MessageBox.Show("لطفا شماره سند را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Txtsanad.Focus()
                    Exit Sub
                End If
            End If
            Me.Enabled = False
            Dim id As Long = 0
            id = GetId()
            If id <= 0 Then
                MessageBox.Show("سابقه چک با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If

            Dim str As String = ""
            If Rdogetchk.Checked = True Then
                str = " دریافتی "
            ElseIf Rdopaychk.Checked = True Then
                str = " پرداختی "
            ElseIf RdoF.Checked = True Then
                str = " خرج شده "
            End If

            If Rdosanad.Checked = True Then
                str &= "با شماره سند " & Txtsanad.Text
            ElseIf Rdonumchk.Checked = True Then
                str &= "با شماره سریال " & TxtChk.Text
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سابقه چک", "تهیه گزارش", "سابقه چک " & str, "")

            Using FPrint As New FrmPrint
                FPrint.PrintSQl = "SELECT  Chk_State.IdUser,Chk_State.Disc, Stat=Case Chk_State.Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END, Chk_State.D_Date ,Chk_Get_Pay.ID ,[GetDate] ,PayDate ,NumChk ,MoneyChk ,Number_Note As Sanad,Chk_Get_Pay.Disc  AS DiscChk,StateChk=Case Chk_Get_Pay.Current_State  WHEN 0 THEN N'در جریان وصول' WHEN 1 THEN N'وصول شده' WHEN 2 THEN N'برگشتی' WHEN 3 THEN N'تضمینی' WHEN 4 THEN N'برات' ELSE N'نا مشخص' END ,NBank=Case Kind WHEN 0 THEN Chk_Get_Pay.N_Bank WHEN 1 THEN (SELECT  Define_Bank.n_bank FROM Chk_Id INNER JOIN Define_Bank ON Chk_Id.IdBank = Define_Bank.ID WHERE Chk_Id.Id =" & id & ")  ELSE N'نا مشخص' END ,Shobeh=Case Kind WHEN 0 THEN Chk_Get_Pay.Shobeh  WHEN 1 THEN (SELECT  Define_Bank.shobeh  FROM Chk_Id INNER JOIN Define_Bank ON Chk_Id.IdBank = Define_Bank.ID WHERE Chk_Id.Id =" & id & ")  ELSE N'نا مشخص' END ,Number_N=Case Kind WHEN 0 THEN Chk_Get_Pay.Number_N   WHEN 1 THEN (SELECT  Define_Bank.number_n   FROM Chk_Id INNER JOIN Define_Bank ON Chk_Id.IdBank = Define_Bank.ID WHERE Chk_Id.Id =" & id & ")  ELSE N'نا مشخص' END ,OneP=Case WHEN  [TYPE]<=13 AND Kind =0 And (Current_Kind =0 Or Current_Kind =1)  THEN (SELECT  Define_People.Nam FROM  Chk_Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID  WHERE Chk_Id .Id =" & id & ") WHEN   [TYPE]>13 AND Kind =1 AND Current_Kind =1  THEN N'اسناد پرداختی'  WHEN [TYPE]=14 THEN (SELECT N'اموال' + '-' + nam FROM Define_Amval  WHERE Define_Amval .ID =(SELECT IdAmval  FROM Get_Pay_Amval WHERE Id =(SELECT Number_Type  FROM Chk_Get_Pay WHERE Id=" & id & " ))) WHEN [TYPE]=15 THEN (SELECT N'درآمد' + '-' + nam FROM Define_Daramad WHERE Define_Daramad.ID =(SELECT IdDaramad  FROM Chk_Id WHERE Chk_Id .Id = " & id & " )) WHEN [TYPE]=21 THEN (SELECT N'سرمایه' + '-' + nam FROM Define_Sarmayeh  WHERE Define_Sarmayeh .ID =(SELECT IdSarmayeh  FROM Get_Pay_Sarmayeh WHERE Id =(SELECT Number_Type  FROM Chk_Get_Pay WHERE Id=" & id & " ))) WHEN [TYPE]=16 THEN N'هزینه متفرقه' WHEN [TYPE]=17 THEN N'هزینه ف.خرید' WHEN [TYPE]=18 THEN N'صندوق' WHEN [TYPE]=19 THEN N'امور چک' WHEN [TYPE]=20 THEN N'بانک به بانک' ELSE N'نا مشخص' END ,TwoP=Case WHEN  Kind =0 And Current_Kind =0 THEN N'اسناد دریافتی'  WHEN  (Kind =0 Or Kind =1)  And (Current_Kind =1) And Current_Type <=13  THEN (SELECT  Define_People.Nam FROM  Chk_Id INNER JOIN Define_People ON Chk_Id.Current_IdPeople  = Define_People.ID  WHERE Chk_Id .Id =" & id & ") WHEN Current_TYPE=14 THEN (SELECT N'اموال' + '-' + nam FROM Define_Amval  WHERE Define_Amval .ID =(SELECT IdAmval  FROM Get_Pay_Amval WHERE Id =(SELECT Current_Number_Type  FROM Chk_Get_Pay WHERE Id=" & id & " ))) WHEN Current_TYPE=15 THEN N'درآمد' WHEN Current_TYPE=16 THEN N'هزینه متفرقه' WHEN Current_TYPE=17 THEN N'هزینه ف.خرید' WHEN Current_TYPE=18 THEN N'صندوق' WHEN Current_TYPE=19 THEN N'امور چک' WHEN Current_TYPE=20 THEN N'بانک به بانک' WHEN Current_TYPE=21 THEN (SELECT N'سرمایه' + '-' + nam FROM Define_Sarmayeh  WHERE Define_Sarmayeh .ID =(SELECT IdSarmayeh  FROM Get_Pay_Sarmayeh WHERE Id =(SELECT Current_Number_Type  FROM Chk_Get_Pay WHERE Id=" & id & " ))) ELSE N'نا مشخص' END FROM Chk_State,Chk_Get_Pay  WHERE Chk_State.Id=" & id & " AND Chk_Get_Pay .ID =" & id
                FPrint.CHoose = "STATECHK"
                FPrint.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPathChK", "Button1_Click")
            Me.Enabled = True
        End Try
    End Sub
    Private Function GetId() As Long
        Try
            Dim SqlStr As String = ""
            If Rdogetchk.Checked = True And Rdonumchk.Checked = True Then
                SqlStr = "SELECT ID FROM  Chk_Get_Pay WHERE NumChk =" & TxtChk.Text & " AND Kind=0 AND Current_Kind=0"
            ElseIf Rdogetchk.Checked = True And Rdosanad.Checked = True Then
                SqlStr = "SELECT ID FROM  Chk_Get_Pay WHERE Id =" & Txtsanad.Text & " AND Kind=0 AND Current_Kind=0"
            ElseIf Rdopaychk.Checked = True And Rdosanad.Checked = True Then
                SqlStr = "SELECT ID FROM  Chk_Get_Pay WHERE Id =" & Txtsanad.Text & " AND Kind=1 AND Current_Kind=1"
            ElseIf Rdopaychk.Checked = True And Rdonumchk.Checked = True Then
                SqlStr = "SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Chk_Get_Pay.NumChk =" & TxtChk.Text & " AND Chk_Id .IdBank =" & Txtidbank.Text & " AND Kind=1 AND Current_Kind=1"
            ElseIf RdoF.Checked = True And Rdonumchk.Checked = True Then
                SqlStr = "SELECT ID FROM  Chk_Get_Pay WHERE NumChk =" & TxtChk.Text & " AND Kind=0 AND Current_Kind=1"
            ElseIf RdoF.Checked = True And Rdosanad.Checked = True Then
                SqlStr = "SELECT ID FROM  Chk_Get_Pay WHERE Id =" & Txtsanad.Text & " AND Kind=0 AND Current_Kind=1"
            End If
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader
            Using CMD As New SqlCommand(SqlStr, ConectionBank)
                dtr = CMD.ExecuteReader()
                If dtr.HasRows Then
                    dtr.Read()
                    Dim res As Long = dtr("ID")
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return res
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return 0
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPathChK", "GetId")
            Me.Enabled = 0
        End Try
    End Function
    Private Sub RdoF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoF.CheckedChanged
        If RdoF.Checked = True Then
            Lbank.Visible = False
            Cbobank.Visible = False
            If Rdosanad.Checked = True Then
                Lsanad.Visible = True
                Txtsanad.Visible = True
                TxtChk.Visible = False
                Lchk.Visible = False
                Txtsanad.Focus()
            ElseIf Rdonumchk.Checked = True Then
                Lsanad.Visible = False
                Txtsanad.Visible = False
                TxtChk.Visible = True
                Lchk.Visible = True
                TxtChk.Focus()
            End If
        End If
    End Sub

    Private Sub cbobank_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbobank.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
    End Sub

    Private Sub cbobank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbobank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New bank_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.LState.Text = "WHERE State=N'جاری'"
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        cbobank.Focus()
        If IdKala <> 0 Then
            cbobank.Text = Tmp_Namkala
            Txtidbank.Text = IdKala
        Else
            cbobank.Text = ""
            Txtidbank.Text = ""
        End If
    End Sub
End Class