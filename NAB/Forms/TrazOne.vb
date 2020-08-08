Imports System.Data.SqlClient
Public Class TrazOne
    Private Sub TrazOne_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Button1.Focus()
    End Sub

    Private Sub TrazOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub FrmTraz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F8")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
                If Access_Form.Substring(3, 1) = 0 Then
                    Button1.Enabled = False
                End If
            End If

        End If
        Me.RefreshBank()
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز اول دوره", "نمایش", "", "")
    End Sub

    Private Sub RefreshBank()
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT Box,Bank,MoneyGetChk,Bed,Kala,Amval,MoneyPayChk,Bes,Sarmayeh,(Box+Bank+MoneyGetChk+Bed+Kala+Amval) As daray,(MoneyPayChk+Bes+Sarmayeh) As Pardakht FROM (SELECT ISNULL(SUM(AllMoney),0)AS Box  FROM Define_Box ) as Box,(SELECT ISNULL(SUM(AllMoney),0)AS Bank  FROM Define_Bank)as Bank,(SELECT SUM (MoneyGet) AS MoneyGetChk FROM (SELECT ISNULL(SUM(MoneyChk),0) AS MoneyGet  FROM Chk_Get_Pay WHERE Kind =0 AND Current_Kind =0 AND [Type]=11 AND Number_Type =0  AND Current_State<>3 UNION ALL SELECT ISNULL(SUM(MoneyChk),0) AS MoneyGet  FROM Chk_Get_Pay WHERE Kind =0 AND Current_Kind =1 AND [Type]=11  AND Number_Type =0 AND Current_State<>3 AND Current_Number_Type <>0) AS MoneyGet) as MoneyGetChk,(SELECT ISNULL(SUM(AllMoney),0)AS Bed FROM Define_People WHERE [State]=N'بدهکار') as Bed,(SELECT ISNULL(SUM(Mon),0)AS Kala  FROM Define_PrimaryKala) as Kala,(SELECT ISNULL(SUM(AllMoney),0)AS Amval  FROM Define_Amval) as Amval,(SELECT ISNULL(SUM(MoneyChk),0) AS MoneyPayChk  FROM Chk_Get_Pay WHERE Kind =1 AND [Type]=11 AND Number_Type =0  AND Current_State<>3) as MoneyPayChk,(SELECT ISNULL(SUM(AllMoney),0)AS Bes FROM Define_People WHERE [State]=N'بستانکار') as Bes,(SELECT ISNULL(SUM(AllSarmayeh.AllMoney),0) As Sarmayeh FROM (SELECT  Allmoney= CASE Stat WHEN N'بدهکار' THEN Allmoney *(-1) WHEN N'بستانکار' THEN Allmoney Else  0 End FROM Define_Sarmayeh )As AllSarmayeh)as Sarmayeh", ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    TxtBox.Text = dtr("Box")
                    TxtBank.Text = dtr("Bank")
                    Txtget.Text = dtr("MoneyGetChk")
                    Txtbed.Text = dtr("Bed")
                    Txtkala.Text = dtr("Kala")
                    Txtamval.Text = dtr("Amval")
                    TxtPay.Text = dtr("MoneyPayChk")
                    TxtBes.Text = dtr("bes")
                    Txtsarmaeh.Text = dtr("Sarmayeh")
                    Txtdara.Text = dtr("daray")
                    Txtparda.Text = dtr("Pardakht")
                    Txttraz.Text = dtr("daray") - dtr("Pardakht")
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "RefreshBank")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub TxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBox.TextChanged
        If Not (CheckDigit(TxtBox.Text.Replace(",", ""))) Then
            TxtBox.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBox.Text.Length > 3 Then
            str = Format$(TxtBox.Text.Replace(",", ""))
            TxtBox.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtBank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBank.TextChanged
        If Not (CheckDigit(TxtBank.Text.Replace(",", ""))) Then
            TxtBank.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBank.Text.Length > 3 Then
            str = Format$(TxtBank.Text.Replace(",", ""))
            TxtBank.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtget_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtget.TextChanged
        If Not (CheckDigit(Txtget.Text.Replace(",", ""))) Then
            Txtget.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtget.Text.Length > 3 Then
            str = Format$(Txtget.Text.Replace(",", ""))
            Txtget.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtLastb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtbed.TextChanged
        If Not (CheckDigit(Txtbed.Text.Replace(",", ""))) Then
            Txtbed.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtbed.Text.Length > 3 Then
            str = Format$(Txtbed.Text.Replace(",", ""))
            Txtbed.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPay.TextChanged
        If Not (CheckDigit(TxtPay.Text.Replace(",", ""))) Then
            TxtPay.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtPay.Text.Length > 3 Then
            str = Format$(TxtPay.Text.Replace(",", ""))
            TxtPay.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub TxtLastBes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBes.TextChanged
        If Not (CheckDigit(TxtBes.Text.Replace(",", ""))) Then
            TxtBes.Text = 0
            Exit Sub
        End If
        Dim str As String
        If TxtBes.Text.Length > 3 Then
            str = Format$(TxtBes.Text.Replace(",", ""))
            TxtBes.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtdara_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdara.TextChanged
        If Not (CheckDigit(Txtdara.Text.Replace(",", ""))) Then
            Txtdara.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtdara.Text.Length > 3 Then
            str = Format$(Txtdara.Text.Replace(",", ""))
            Txtdara.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtparda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtparda.TextChanged
        If Not (CheckDigit(Txtparda.Text.Replace(",", ""))) Then
            Txtparda.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtparda.Text.Length > 3 Then
            str = Format$(Txtparda.Text.Replace(",", ""))
            Txtparda.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txttraz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txttraz.TextChanged
        If Not (CheckDigit(Txttraz.Text.Replace(",", ""))) Then
            Txttraz.Text = 0
            If CDbl(Txttraz.Text.Trim) = 0 Then
                Txttraz.BackColor = Color.Yellow
            ElseIf CDbl(Txttraz.Text.Trim) > 0 Then
                Txttraz.BackColor = Color.White
            ElseIf CDbl(Txttraz.Text.Trim) < 0 Then
                Txttraz.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        Dim str As String
        If Txttraz.Text.Length > 3 Then
            str = Format$(Txttraz.Text.Replace(",", ""))
            Txttraz.Text = Format$(Val(str), "###,###,###")
        End If
        If CDbl(Txttraz.Text.Trim) = 0 Then
            Txttraz.BackColor = Color.Yellow
        ElseIf CDbl(Txttraz.Text.Trim) > 0 Then
            Txttraz.BackColor = Color.White
        ElseIf CDbl(Txttraz.Text.Trim) < 0 Then
            Txttraz.BackColor = Color.Pink
        End If
    End Sub

    Private Sub Txtkala_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtkala.TextChanged
        If Not (CheckDigit(Txtkala.Text.Replace(",", ""))) Then
            Txtkala.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtkala.Text.Length > 3 Then
            str = Format$(Txtkala.Text.Replace(",", ""))
            Txtkala.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtamval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtamval.TextChanged
        If Not (CheckDigit(Txtamval.Text.Replace(",", ""))) Then
            Txtamval.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtamval.Text.Length > 3 Then
            str = Format$(Txtamval.Text.Replace(",", ""))
            Txtamval.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Txtsarmaeh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsarmaeh.TextChanged
        If Not (CheckDigit(Txtsarmaeh.Text.Replace(",", ""))) Then
            Txtsarmaeh.Text = 0
            Exit Sub
        End If
        Dim str As String
        If Txtsarmaeh.Text.Length > 3 Then
            str = Format$(Txtsarmaeh.Text.Replace(",", ""))
            Txtsarmaeh.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmPeople As New DefinePeople
                FrmPeople.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "MNU_TPepole_P_Click")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmPeople As New DefinePeople
                FrmPeople.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button9_Click")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmBox As New DefineBox
                FrmBox.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button2_Click")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmBank As New DefineBank
                FrmBank.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button3_Click")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmCheckOne As New Check_Ontime
                FrmCheckOne.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button4_Click")
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmCheckOne As New Check_Ontime
                FrmCheckOne.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button8_Click")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmKalaOne As New Kala_OneTime
                FrmKalaOne.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button6_Click")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using FrmAmval As New DefineAmval
                FrmAmval.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button7_Click")
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Fnew = False
            GroupBox1.Enabled = False
            Using Frmsarmayeh As New DefineSarmayeh
                Frmsarmayeh.ShowDialog()
            End Using
            Me.RefreshBank()
            GroupBox1.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "TrazOne", "Button10_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Close_Aval.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Enabled = False
        Button1.Enabled = False
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تراز اول دوره", "چاپ", "", "")

        Using FrmPrint As New FrmPrint
            'FrmPrint.PrintSQl = "SELECT Box,Bank,MoneyGetChk,Bed,Kala,Amval,MoneyPayChk,Bes,Sarmayeh,(Box+Bank+MoneyGetChk+Bed+Kala+Amval) As daray,(MoneyPayChk+Bes+Sarmayeh) As Pardakht FROM (SELECT ISNULL(SUM(AllMoney),0)AS Box  FROM Define_Box ) as Box,(SELECT ISNULL(SUM(AllMoney),0)AS Bank  FROM Define_Bank)as Bank,(SELECT ISNULL(SUM(MoneyChk),0) AS MoneyGetChk  FROM Chk_Get_Pay WHERE Kind =0 AND [Type]=11 AND Number_Type =0 AND Current_State<>3 ) as MoneyGetChk,(SELECT ISNULL(SUM(AllMoney),0)AS Bed FROM Define_People WHERE [State]=N'بدهکار') as Bed,(SELECT ISNULL(SUM(Mon),0)AS Kala  FROM Define_PrimaryKala) as Kala,(SELECT ISNULL(SUM(AllMoney),0)AS Amval  FROM Define_Amval) as Amval,(SELECT ISNULL(SUM(MoneyChk),0) AS MoneyPayChk  FROM Chk_Get_Pay WHERE Kind =1 AND [Type]=11 AND Number_Type =0  AND Current_State<>3) as MoneyPayChk,(SELECT ISNULL(SUM(AllMoney),0)AS Bes FROM Define_People WHERE [State]=N'بستانکار') as Bes,(SELECT ISNULL(SUM(AllSarmayeh.AllMoney),0) As Sarmayeh FROM (SELECT  Allmoney= CASE Stat WHEN N'بدهکار' THEN Allmoney *(-1) WHEN N'بستانکار' THEN Allmoney Else  0 End FROM Define_Sarmayeh )As AllSarmayeh)as Sarmayeh"
			FrmPrint.PrintSQl = "SELECT Box,Bank,MoneyGetChk,Bed,Kala,Amval,MoneyPayChk,Bes,Sarmayeh,(Box+Bank+MoneyGetChk+Bed+Kala+Amval) As daray,(MoneyPayChk+Bes+Sarmayeh) As Pardakht FROM (SELECT ISNULL(SUM(AllMoney),0)AS Box  FROM Define_Box ) as Box,(SELECT ISNULL(SUM(AllMoney),0)AS Bank  FROM Define_Bank)as Bank,(SELECT SUM (MoneyGet) AS MoneyGetChk FROM (SELECT ISNULL(SUM(MoneyChk),0) AS MoneyGet  FROM Chk_Get_Pay WHERE Kind =0 AND Current_Kind =0 AND [Type]=11 AND Number_Type =0  AND Current_State<>3 UNION ALL SELECT ISNULL(SUM(MoneyChk),0) AS MoneyGet  FROM Chk_Get_Pay WHERE Kind =0 AND Current_Kind =1 AND [Type]=11  AND Number_Type =0 AND Current_State<>3 AND Current_Number_Type <>0) AS MoneyGet) as MoneyGetChk,(SELECT ISNULL(SUM(AllMoney),0)AS Bed FROM Define_People WHERE [State]=N'بدهکار') as Bed,(SELECT ISNULL(SUM(Mon),0)AS Kala  FROM Define_PrimaryKala) as Kala,(SELECT ISNULL(SUM(AllMoney),0)AS Amval  FROM Define_Amval) as Amval,(SELECT ISNULL(SUM(MoneyChk),0) AS MoneyPayChk  FROM Chk_Get_Pay WHERE Kind =1 AND [Type]=11 AND Number_Type =0  AND Current_State<>3) as MoneyPayChk,(SELECT ISNULL(SUM(AllMoney),0)AS Bes FROM Define_People WHERE [State]=N'بستانکار') as Bes,(SELECT ISNULL(SUM(AllSarmayeh.AllMoney),0) As Sarmayeh FROM (SELECT  Allmoney= CASE Stat WHEN N'بدهکار' THEN Allmoney *(-1) WHEN N'بستانکار' THEN Allmoney Else  0 End FROM Define_Sarmayeh )As AllSarmayeh)as Sarmayeh"
            FrmPrint.CHoose = "TRAZ"
            FrmPrint.ShowDialog()
        End Using
        GroupBox1.Enabled = True
        Button1.Enabled = True
    End Sub
End Class