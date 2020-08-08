Imports System.Data.SqlClient
Public Class ConvertStateFactor
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If RdoOK.Checked = False And RdoNo.Checked = False And RdoCur.Checked = False Then
                MessageBox.Show("تغییر وضعیت فاکتور انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not StateMobileFac(CLng(LState.Text)) Then Exit Sub

            If StateMobile = 0 And RdoCur.Checked = True Then
                MessageBox.Show("فاکتور مورد نظر در حال حاضر در جریان است و به حالت در جریان تغییر وضعیت نمی دهد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If StateMobile = 1 And RdoNo.Checked = True Then
                MessageBox.Show("فاکتور مورد نظر در حال حاضر رد شده است و به حالت رد تغییر وضعیت نمی دهد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If StateMobile = 2 And RdoOK.Checked = True Then
                MessageBox.Show("فاکتور مورد نظر در حال تایید شده است و به حالت تایید تغییر وضعیت نمی دهد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If StateMobile = 3 And RdoOK.Checked = True Then
                MessageBox.Show("فاکتور مورد نظر در حال حاضر به پیش فاکتور تبدیل شده است و به حالت تایید تغییر وضعیت نمی دهد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            If RdoNo.Checked = True Or RdoCur.Checked = True Then
                ChangeStatefactor()
            ElseIf RdoOK.Checked = True Then
                Using FrmF As New Mobile_FrmFactor
                    Tmp_String1 = ComboBox1.Text.Trim
                    FrmF.LIdFac.Text = LState.Text
                    FrmF.Kfe = If(Rdo_System.Checked = True, "S", "V")
                    FrmF.ShowDialog()
                    If FrmF.LEdit.Text = "0" Then Exit Sub
                End Using
            End If

            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateFactor", "BtnOk_Click")
            Me.Close()
        End Try

    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F143")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    RdoOK.Enabled = False
                    RdoNo.Enabled = False
                    RdoCur.Enabled = False

                    RdoOK.Checked = False
                    RdoNo.Checked = False
                    RdoCur.Checked = False
                Else
                    If Access_Form.Substring(5, 1) = 0 And Access_Form.Substring(6, 1) = 0 Then
                        RdoOK.Enabled = False
                        RdoOK.Checked = False
                    End If

                    If Access_Form.Substring(7, 1) = 0 Then
                        RdoNo.Enabled = False
                        RdoNo.Checked = False
                    End If

                    If Access_Form.Substring(8, 1) = 0 Then
                        RdoCur.Enabled = False
                        RdoCur.Checked = False
                    End If
                End If
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub ChangeStatefactor()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE  Mobile_ListFactorSell SET [Confirm]=" & If(RdoNo.Checked = True, 1, 0) & ",Disc=N'" & ComboBox1.Text.Trim & "',IdSell=NULL WHERE IdFactor =" & CLng(LState.Text), ConectionBank)
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور موبایل", "تغییر وضعیت", If(RdoNo.Checked = True, "تغییر وضعیت به رد فاکتور موبایل :", "تغییر وضعیت به در جریان فاکتور موبایل :") & CLng(LState.Text), "")

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ConvertStateFactor", "ChangeStatefactor")
        End Try
    End Sub

    Private Sub ConvertStateFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "FactMobail.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ConvertStateFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If StateMobile = 0 Then
            RdoCur.Enabled = False
            RdoOK.Checked = True
        ElseIf StateMobile = 1 Then
            RdoNo.Enabled = False
            RdoCur.Checked = True
        End If

        Me.SetButton()

        If RdoCur.Checked = False And RdoNo.Checked = False And RdoOK.Checked = False Then
            If RdoCur.Enabled = True Then
                RdoCur.Checked = True
            ElseIf RdoNo.Enabled = True Then
                RdoNo.Checked = True
            ElseIf RdoOK.Enabled = True Then
                RdoOK.Checked = True
            End If
        End If

    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
    End Sub

    Private Sub RdoOK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOK.CheckedChanged
        If RdoOK.Checked = True Then
            Rdo_Visitor.Enabled = True
            Rdo_System.Enabled = True
            Rdo_Visitor.Checked = True
        Else
            Rdo_Visitor.Enabled = False
            Rdo_System.Enabled = False
            Rdo_Visitor.Checked = False
            Rdo_System.Checked = False
        End If
    End Sub
End Class