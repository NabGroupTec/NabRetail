Imports System.Data.SqlClient
Imports System.Transactions
Public Class Mobile_ListPeople

    Private Sub Fill_Dgv()
        Try
            Dim dt As New DataTable

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT ListNP.Id,ListNP.Tell1,ListNP.Tell2,ListNP.D_Date,ListNP.Adres,ListNP.T_Time,ListNP.IdGroup,ListNP.IdOstan,ListNP.IdCity,ListNP.IdPart,ListNP.Nam,ListNP.IdVisitor,ListNP.IdUser,Define_Ostan.NamO,Define_City.NamCI,Define_Part.NamP,Define_Group_P.nam AS GroupNam FROM (SELECT Id,Tell1,Tell2,D_Date,Adres,T_Time,IdGroup,IdOstan=(SELECT IdOstan FROM Define_Part WHERE Define_Part.Code =IdPart),IdCity =(SELECT IdCity FROM Define_Part WHERE Define_Part.Code =IdPart),IdPart,Nam,IdVisitor,IdUser FROM Mobile_NewPeople ) As ListNP INNER JOIN Define_Ostan ON ListNP.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON ListNP.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON ListNP.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity INNER JOIN Define_Group_P ON ListNP.IdGroup = Define_Group_P.Id", ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ListPeople", "Fill_Dgv")
            Me.Close()
        End Try
    End Sub

    Private Sub Mobile_ListPeople_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Mobile_ListPeople_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F144")
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

        Me.Fill_Dgv()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.SetButton()
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F144")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnOk.Enabled = False
                    BtnDel.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        BtnOk.Enabled = False
                        BtnDel.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnOk.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            BtnDel.Enabled = False
                        End If
                        
                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnOk.Enabled = False
                BtnDel.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ListPeople", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "TarafTemp.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnDel.Enabled = True Then BtnDel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("طرف حسابی برای تایید وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Fill_Dgv()
                Exit Sub
            End If

            Using Frmadd As New Mobile_AddPeople
                Frmadd.LId.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                Frmadd.Txtname.Text = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value
                Frmadd.Txttell1.Text = DGV.Item("Cln_Tell1", DGV.CurrentRow.Index).Value
                Frmadd.Txtfax.Text = ""
                Frmadd.Txttell2.Text = DGV.Item("Cln_Tell2", DGV.CurrentRow.Index).Value
                Frmadd.Txtadd.Text = ""
                Frmadd.Txtadd.Text = DGV.Item("Cln_Adres", DGV.CurrentRow.Index).Value
                Frmadd.Txtfac.Text = ""
                Frmadd.Txtco.Text = ""
                Frmadd.Txtdelay.Text = 0
                Frmadd.ChkMon.Checked = False
                Frmadd.TxtMoney.Text = 0
                Frmadd.Chkbuyer.Checked = True
                Frmadd.Chkseller.Checked = False
                Frmadd.Chkother.Checked = False
                Frmadd.TxtDate.ThisText = DGV.Item("Cln_date", DGV.CurrentRow.Index).Value

                Tmp_String1 = DGV.Item("Cln_NamO", DGV.CurrentRow.Index).Value
                Tmp_String2 = DGV.Item("Cln_NamCI", DGV.CurrentRow.Index).Value
                TmpAddress = DGV.Item("Cln_NamP", DGV.CurrentRow.Index).Value

                TxtIdOstan = DGV.Item("Cln_IdOstan", DGV.CurrentRow.Index).Value
                TxtIdCity = DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value
                IdKala = DGV.Item("Cln_IdPart", DGV.CurrentRow.Index).Value

                Tmp_Namkala = DGV.Item("Cln_groupnam", DGV.CurrentRow.Index).Value
                DK_KOL = DGV.Item("Cln_IdGroup", DGV.CurrentRow.Index).Value

                Frmadd.ShowDialog()
                Fill_Dgv()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ListPeople", "BtnOk_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("طرف حسابی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Fill_Dgv()
                Exit Sub
            End If

            If MessageBox.Show("آیا برای حذف طرف حساب مورد نظر مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("DELETE FROM Mobile_NewPeople WHERE Id=" & DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value, ConectionBank)
                cmd.ExecuteNonQuery()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف طرف حساب موقت", "حذف", "حذف طرف حساب موقت :" & DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value, "")
            Fill_Dgv()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ListPeople", "BtnDel_Click")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
    End Sub
End Class