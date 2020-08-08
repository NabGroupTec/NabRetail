Imports System.Data.SqlClient

Public Class Frm_ActivePeopleAddEdit

    Private Sub ChkVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisitor.CheckedChanged
        If ChkVisitor.Checked = True Then
            TxtVisitor.Enabled = True
            TxtVisitor.Focus()
        Else
            TxtVisitor.Enabled = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then CmbState.Focus()
    End Sub

    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        If Tmp_Namkala <> "" Then
            TxtVisitor.Text = Tmp_Namkala
            TxtIdVisitor.Text = IdKala
        Else
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then ChkVisitor.Focus()
    End Sub

    Private Sub CmbState_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbState.KeyDown
        If CmbState.DroppedDown = False Then
            CmbState.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtDisc.Focus()
        End If
    End Sub

    Private Sub ChkVisitor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkVisitor.GotFocus
        ChkVisitor.BackColor = Color.LightGray
    End Sub

    Private Sub ChkVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then CmbState.Focus()
    End Sub

    Private Sub TxtDisc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDisc.KeyDown
        If e.KeyCode = Keys.Enter Then cmdadd.Focus()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If String.IsNullOrEmpty(TxtDate.ThisText) Or TxtDate.ThisText = "" Then
                MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDate.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(CmbState.Text) Then
                MessageBox.Show("وضعیت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbState.Focus()
                Exit Sub
            End If

            If ChkVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtIdVisitor.Text) Or String.IsNullOrEmpty(TxtVisitor.Text) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtVisitor.Focus()
                    Exit Sub
                End If
            End If

            If String.IsNullOrEmpty(TxtDisc.Text) Then
                MessageBox.Show("شرح را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtDisc.Focus()
                Exit Sub
            End If

            Me.Enabled = False
            If String.IsNullOrEmpty(LIdName.Text) Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using cmd As New SqlCommand("INSERT INTO Define_ActivePeople (Dat,IdName,StateActive,IdUser,IdUserEdit,Disc,IdVisitor) VALUES (@Dat,@IdName,@StateActive,@IdUser,@IdUserEdit,@Disc,@IdVisitor)", ConectionBank)
                    cmd.Parameters.AddWithValue("@Dat", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = CLng(TxtIdName.Text)
                    cmd.Parameters.AddWithValue("@StateActive", SqlDbType.Bit).Value = IIf(CmbState.Text = CmbState.Items(0), False, True)
                    cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                    cmd.Parameters.AddWithValue("@IdUserEdit", SqlDbType.BigInt).Value = DBNull.Value
                    cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                    cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    cmd.ExecuteNonQuery()
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Else
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using cmd As New SqlCommand("UPDATE Define_ActivePeople SET Dat=@Dat,StateActive=@StateActive,IdUserEdit=@IdUserEdit,Disc=@Disc,IdVisitor=@IdVisitor WHERE Id=@Id", ConectionBank)
                    cmd.Parameters.AddWithValue("@Dat", SqlDbType.NVarChar).Value = TxtDate.ThisText
                    cmd.Parameters.AddWithValue("@StateActive", SqlDbType.Bit).Value = IIf(CmbState.Text = CmbState.Items(0), False, True)
                    cmd.Parameters.AddWithValue("@IdUserEdit", SqlDbType.BigInt).Value = Id_User
                    cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = TxtDisc.Text.Trim
                    cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = IIf(ChkVisitor.Checked = True, TxtIdVisitor.Text, DBNull.Value)
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = CLng(LIdName.Text)
                    cmd.ExecuteNonQuery()
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End If
            SetActivePeople(TxtIdName.Text)
            Me.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_ActivePeopleAddEdit", "cmdadd_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "E.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_ActivePeopleAddEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Frm_ActivePeopleAddEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Try
            If String.IsNullOrEmpty(LIdName.Text) Then
                TxtDate.ThisText = GetDate()
                CmbState.Text = CmbState.Items(0)
                TxtVisitor.Enabled = False
            Else
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim dtr As SqlDataReader = Nothing
                Using cmd As New SqlCommand("SELECT Define_ActivePeople.Id,Define_ActivePeople.IdVisitor,Define_ActivePeople.Dat,Define_ActivePeople.IdName,Define_ActivePeople.IdUser,Define_ActivePeople.IdUserEdit,Define_ActivePeople.Disc,StatActive=CASE WHEN Define_ActivePeople.StateActive ='True' THEN N'غیر فعال' ELSE N'فعال' END,Visitor=CASE WHEN Define_ActivePeople.IdVisitor IS NULL THEN N'' ELSE (SELECT Nam FROM Define_Visitor WHERE Define_Visitor.Id=Define_ActivePeople.IdVisitor) END FROM Define_ActivePeople WHERE Define_ActivePeople.Id=" & LIdName.Text, ConectionBank)
                    dtr = cmd.ExecuteReader
                End Using
                If dtr.HasRows Then
                    dtr.Read()
                    TxtDate.ThisText = dtr("Dat")
                    If dtr("IdVisitor") Is DBNull.Value Then
                        ChkVisitor.Checked = False
                        TxtVisitor.Enabled = False
                    Else
                        ChkVisitor.Checked = True
                        TxtVisitor.Enabled = True
                        TxtVisitor.Text = dtr("Visitor")
                        TxtIdVisitor.Text = dtr("IdVisitor")
                    End If
                    CmbState.Text = dtr("StatActive")
                    TxtDisc.Text = dtr("Disc")
                    TxtIdName.Text = dtr("IdName")
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Frm_ActivePeopleAddEdit", "Frm_ActivePeopleAddEdit_Load")
            Me.Close()
        End Try
    End Sub

    Private Sub ChkVisitor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkVisitor.LostFocus
        ChkVisitor.BackColor = Me.BackColor
    End Sub
End Class