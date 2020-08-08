Imports System.Data.SqlClient
Imports System.Transactions
Public Class RelationVisitorFrosh_One
    Dim HighMon As String = ""
    Dim HighKala As String = ""
    Public EDIT As Long
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl
    Friend WithEvents txt_dgv2 As New DataGridViewTextBoxEditingControl
    Friend WithEvents txt_dgv3 As New DataGridViewTextBoxEditingControl
    Structure ListGroup
        Dim Group As String
        Dim IdGroup As Long
        Dim Frosh As String
        Dim Darsad As String
    End Structure
    Public AllGroup() As ListGroup
    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Enter Then DGV1.Focus()
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

    Private Sub RelationVisitorFrosh_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If EDIT <> 0 Then
            DGV1.Focus()
        Else
            TxtVisitor.Focus()
        End If
    End Sub

    Private Sub DGV1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Try
            If e.ColumnIndex = 1 Then
                If Not (DGV1.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV1.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV1.RowCount - 1 Then
                        SendKeys.Send("+{TAB}")
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
                    If DGV1.CurrentRow.Index <> DGV1.RowCount - 1 Then
                        For i As Integer = DGV2.RowCount - 2 To 0 Step -1
                            If DGV2.Item("Cln_Row", i).Value = DGV1.CurrentRow.Index Then DGV2.Rows.RemoveAt(i)
                        Next
                        For i As Integer = 0 To DGV2.RowCount - 2
                            If DGV2.Item("Cln_Row", i).Value > DGV1.CurrentRow.Index Then DGV2.Item("Cln_Row", i).Value = CLng(DGV2.Item("Cln_Row", i).Value) - 1
                        Next
                        DGV1.Rows.RemoveAt(DGV1.CurrentRow.Index)
                    Else
                        DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_HightKala", DGV1.CurrentRow.Index).Value = ""
                        DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
                        For i As Integer = DGV2.RowCount - 2 To 0 Step -1
                            If DGV2.Item("Cln_Row", i).Value = DGV1.CurrentRow.Index Then DGV2.Rows.RemoveAt(i)
                        Next
                        For i As Integer = 0 To DGV2.RowCount - 2
                            If DGV2.Item("Cln_Row", i).Value > DGV1.CurrentRow.Index Then DGV2.Item("Cln_Row", i).Value = CLng(DGV2.Item("Cln_Row", i).Value) - 1
                        Next
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        For i As Integer = 0 To DGV2.RowCount - 2
            If DGV2.Item("Cln_Row", i).Value <> e.RowIndex Then
                DGV2.Rows(i).Visible = False
            Else
                DGV2.Rows(i).Visible = True
            End If
        Next
    End Sub

    Private Sub DGV1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowLeave
        If DGV1.CurrentCell.ColumnIndex > 0 Then DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub RelationVisitorFrosh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RelationVisitorFrosh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Cln_Group").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_Group2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If EDIT <> 0 Then
            Try
                Dim id As Long = 0
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim dtr As SqlDataReader = Nothing
                Using cmd As New SqlCommand("SELECT REPLACE(Listkala_OG.Kala,'.','/') As Kala ,Idkala,Listkala_OG.Id, Listkala_OG.Mon, Define_OneGroup.NamOne  As Nam FROM Listkala_OG  INNER JOIN Define_OneGroup ON Listkala_OG.IdKala = Define_OneGroup.Id WHERE IdLinkVisitor =" & EDIT, ConectionBank)
                    dtr = cmd.ExecuteReader
                End Using
                If dtr.HasRows Then
                    DGV1.AllowUserToAddRows = False
                    While dtr.Read
                        DGV1.Rows.Add()
                        DGV1.Item("cln_name", DGV1.RowCount - 1).Value = dtr("Nam")
                        DGV1.Item("Cln_HightMon", DGV1.RowCount - 1).Value = IIf(dtr("Mon") > 0, Format(dtr("Mon"), "###,###"), 0)
                        DGV1.Item("Cln_HightKala", DGV1.RowCount - 1).Value = dtr("Kala")
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = dtr("Idkala")
                        DGV1.Item("Cln_Id", DGV1.RowCount - 1).Value = dtr("Id")
                    End While
                    DGV1.AllowUserToAddRows = True
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim dt As New DataTable
                DGV2.AllowUserToAddRows = False
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                For i As Integer = 0 To DGV1.RowCount - 2
                    dt.Clear()
                    Using cmd As New SqlCommand("SELECT REPLACE(ListDarsad_OG.Frosh,'.','/') As Frosh, REPLACE(ListDarsad_OG.Darsad,'.','/') AS Darsad, Define_Group_P.nam,ListDarsad_OG.IdGroup FROM ListDarsad_OG INNER JOIN Define_Group_P ON ListDarsad_OG.IdGroup = Define_Group_P.Id WHERE IdlinkKala =" & DGV1.Item("Cln_Id", i).Value, ConectionBank)
                        dt.Load(cmd.ExecuteReader)
                    End Using
                    For K As Integer = 0 To dt.Rows.Count - 1
                        DGV2.Rows.Add()
                        DGV2.Item("cln_Ta", DGV2.RowCount - 1).Value = dt.Rows(K).Item("Frosh")
                        DGV2.Item("cln_darsad", DGV2.RowCount - 1).Value = dt.Rows(K).Item("Darsad")
                        DGV2.Item("Cln_Group", DGV2.RowCount - 1).Value = dt.Rows(K).Item("nam")
                        DGV2.Item("Cln_IdGroup", DGV2.RowCount - 1).Value = dt.Rows(K).Item("IdGroup")
                        DGV2.Item("Cln_Row", DGV2.RowCount - 1).Value = i
                    Next K
                Next i
                DGV2.AllowUserToAddRows = True
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                dtr = Nothing
                Using cmd As New SqlCommand("SELECT  REPLACE(ListOrderDarsad_OG.Darsad,'.','/') As Darsad, Define_Group_P.nam,IdGroup FROM ListOrderDarsad_OG INNER JOIN Define_Group_P ON ListOrderDarsad_OG.IdGroup = Define_Group_P.Id WHERE IdLinkVisitor =" & EDIT, ConectionBank)
                    dtr = cmd.ExecuteReader
                End Using
                If dtr.HasRows Then
                    DGV3.AllowUserToAddRows = False
                    While dtr.Read
                        DGV3.Rows.Add()
                        DGV3.Item("Cln_Darsad2", DGV3.RowCount - 1).Value = dtr("Darsad")
                        DGV3.Item("Cln_Group2", DGV3.RowCount - 1).Value = dtr("nam")
                        DGV3.Item("Cln_IdGroup2", DGV3.RowCount - 1).Value = dtr("IdGroup")
                    End While
                    DGV3.AllowUserToAddRows = True
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    'Me.Close()
                End If
                DGV1.Item("Cln_Name", 0).Selected = True
                DGV1.Focus()
            Catch ex As Exception
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationVisitorFrosh_One", "RelationVisitorFrosh_Load")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub txt_dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV1.CurrentCell.ColumnIndex = 1 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                For i As Integer = DGV2.RowCount - 2 To 0 Step -1
                    If DGV2.Item("Cln_Row", i).Value = DGV1.CurrentRow.Index Then DGV2.Rows.RemoveAt(i)
                Next
                For i As Integer = 0 To DGV2.RowCount - 2
                    If DGV2.Item("Cln_Row", i).Value > DGV1.CurrentRow.Index Then DGV2.Item("Cln_Row", i).Value = CLng(DGV2.Item("Cln_Row", i).Value) - 1
                Next
                DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_HightKala", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            ''''''''''''گرفتن نام کالا
            If DGV1.CurrentCell.ColumnIndex = 0 Then
                Dim frmlk As New GroupOne_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
                DGV1.Focus()
                If Tmp_Namkala <> "" Then
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = Tmp_OneGroup
                    DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_HightKala", DGV1.CurrentRow.Index).Value = 0
                    DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = IdKala
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Selected = True
                Else
                    DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Selected = False
                    DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Selected = True
                End If
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''کنترل مبلغ
            If DGV1.CurrentCell.ColumnIndex = 1 Then
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
            End If


            If DGV1.CurrentCell.ColumnIndex = 2 Then
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
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value = "" Then
                txt_dgv.Clear()
                Exit Sub
            End If
            If DGV1.CurrentCell.ColumnIndex = 1 Then
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

            ElseIf DGV1.CurrentCell.ColumnIndex = 2 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub EmptyGridKala()
        Try
            If DGV1.RowCount > 1 Then
                DGV1.Item("Cln_Name", 0).Selected = True
                For i As Integer = DGV1.RowCount - 2 To 0 Step -1
                    DGV1.Rows.RemoveAt(i)
                Next
            Else
                DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_HightKala", DGV1.CurrentRow.Index).Value = ""
                DGV1.Item("Cln_code", DGV1.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyGridKala2()
        Try
            If DGV2.RowCount > 1 Then
                DGV2.Item("Cln_Group", 0).Selected = True
                For i As Integer = DGV2.RowCount - 2 To 0 Step -1
                    DGV2.Rows.RemoveAt(i)
                Next
            Else
                DGV2.Item("Cln_Ta", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Darsad", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_IdGroup", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Row", DGV2.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyGridKala3()
        Try
            If DGV3.RowCount > 1 Then
                DGV3.Item("Cln_Group2", 0).Selected = True
                For i As Integer = DGV3.RowCount - 2 To 0 Step -1
                    DGV3.Rows.RemoveAt(i)
                Next
            Else
                DGV3.Item("Cln_Darsad2", DGV3.CurrentRow.Index).Value = ""
                DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value = ""
                DGV3.Item("Cln_IdGroup2", DGV3.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ByAsliKala.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnDel.Enabled = True Then BtnDel_Click(Nothing, Nothing)
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnAdvance.Enabled = True Then BtnAdvance_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If DGV1.RowCount > 1 And DGV1.Focused = True Then
                If Not (Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "") Then
                    HighMon = DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Value
                    HighKala = DGV1.Item("Cln_HightKala", DGV1.CurrentRow.Index).Value
                End If
            End If
            If DGV2.RowCount > 1 And DGV2.Focused = True Then
                Array.Resize(AllGroup, 0)
                For i As Integer = 0 To DGV2.RowCount - 1
                    If Not (Trim(DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value) = "") And DGV2.Rows(i).Visible = True Then
                        Array.Resize(AllGroup, AllGroup.Length + 1)
                        AllGroup(AllGroup.Length - 1).Group = DGV2.Item("Cln_Group", i).Value
                        AllGroup(AllGroup.Length - 1).IdGroup = DGV2.Item("Cln_IdGroup", i).Value
                        AllGroup(AllGroup.Length - 1).Frosh = DGV2.Item("Cln_Ta", i).Value
                        AllGroup(AllGroup.Length - 1).Darsad = DGV2.Item("Cln_darsad", i).Value
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If HighMon <> "" And HighKala <> "" And DGV1.Focused = True Then
                If Not (Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "") Then
                    DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Value = HighMon
                    DGV1.Item("Cln_HightKala", DGV1.CurrentRow.Index).Value = HighKala
                    If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                        DGV1.Item("Cln_HightMon", DGV1.CurrentRow.Index).Selected = True
                        SendKeys.Send(HighMon)
                    End If
                End If
            End If

            If DGV2.Focused = True And Not (Trim(DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value) = "") Then
                DGV2.AllowUserToAddRows = False
                For i As Integer = 0 To AllGroup.Length - 1
                    DGV2.Rows.Add()
                    DGV2.Item("Cln_Group", DGV2.RowCount - 1).Value = AllGroup(i).Group
                    DGV2.Item("Cln_IdGroup", DGV2.RowCount - 1).Value = AllGroup(i).IdGroup
                    DGV2.Item("Cln_Ta", DGV2.RowCount - 1).Value = AllGroup(i).Frosh
                    DGV2.Item("Cln_darsad", DGV2.RowCount - 1).Value = AllGroup(i).Darsad
                    DGV2.Item("Cln_Row", DGV2.RowCount - 1).Value = DGV1.CurrentRow.Index
                Next
                DGV2.AllowUserToAddRows = True
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If BtnSelect.Enabled = True Then BtnSelect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MessageBox.Show("آيا براي حذف همه گروه کالاهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        Me.EmptyGridKala()
        Me.EmptyGridKala2()
    End Sub

    Private Sub BtnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdvance.Click
        Using FrmAdVance As New GroupOne_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_Select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    DGV1.AllowUserToAddRows = False
                    For i As Integer = 0 To AllSelectKala.Length - 1
                        DGV1.Rows.Add()
                        DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = AllSelectKala(i).IdKala
                        DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value = AllSelectKala(i).OneGroup
                        DGV1.Item("Cln_HightMon", DGV1.RowCount - 1).Value = 0
                        DGV1.Item("Cln_HightKala", DGV1.RowCount - 1).Value = 0
                    Next
                    DGV1.AllowUserToAddRows = True
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV1.Focus()
            Catch ex As Exception
                DGV1.Rows.Clear()
                DGV1.AllowUserToAddRows = True
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If String.IsNullOrEmpty(TxtIdVisitor.Text) Or String.IsNullOrEmpty(TxtVisitor.Text) Then
                MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtVisitor.Focus()
                Exit Sub
            End If

            If DGV1.RowCount <= 1 Then
                MessageBox.Show("هیچ گروه کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Focus()
                Exit Sub
            End If

            If DGV2.RowCount <= 1 Then
                MessageBox.Show("هیچ درصدی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV2.Focus()
                Exit Sub
            End If

            Dim row As Integer = 0
            For i As Integer = 0 To DGV1.RowCount - 2
                For j As Integer = 0 To DGV2.RowCount - 2
                    If DGV2.Item("Cln_Row", j).Value = i Then
                        row += 1
                    End If
                Next
                If row <= 0 Then
                    MessageBox.Show(" درصد در ردیف شماره " & "{" & i + 1 & "}" & " را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Item("Cln_Name", i).Selected = True
                    DGV1.Focus()
                    Exit Sub
                End If
                row = 0
            Next

            If DGV1.Item("Cln_name", DGV1.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت گروه کالا در ردیف شماره " & "{" & DGV1.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV1.Item("Cln_name", DGV1.RowCount - 1).Selected = True
                DGV1.Focus()
                Exit Sub
            End If

            '''''''''''''''''''''''''''''''''''''''''''
            If DGV2.Item("Cln_Group", DGV2.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت درصد در ردیف شماره " & "{" & DGV2.Item("Cln_Row", DGV2.RowCount - 1).Value + 1 & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV2.Item("Cln_Group", DGV2.RowCount - 1).Selected = True
                DGV2.Focus()
                Exit Sub
            End If

            If DGV3.Item("Cln_Group2", DGV3.RowCount - 1).Value <> "" Then
                MessageBox.Show("وضعیت درصد سایر کالاها در ردیف شماره " & "{" & DGV3.RowCount & "}" & "نا مشخص است یا به ان مقدار دهید یا آن را پاک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGV3.Item("Cln_Group2", DGV3.RowCount - 1).Selected = True
                DGV3.Focus()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''
            For i As Integer = 0 To DGV1.RowCount - 2
                If String.IsNullOrEmpty(DGV1.Item("Cln_name", i).Value) Or String.IsNullOrEmpty(DGV1.Item("Cln_code", i).Value) Then
                    MessageBox.Show("نام گروه کالا در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_name", i).Selected = True
                    Exit Sub
                End If

                If CDbl(DGV1.Item("Cln_HightMon", i).Value) = 0 And CDbl(DGV1.Item("Cln_HightKala", i).Value.ToString.Replace("/", ".")) = 0 Then
                    MessageBox.Show("  فروش هدف مبلغ یا فروش هدف حجمی در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Focus()
                    DGV1.Item("Cln_HightMon", i).Selected = True
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                For j As Integer = 0 To DGV1.RowCount - 2
                    If DGV1.Item("Cln_code", i).Value = DGV1.Item("Cln_code", j).Value Then
                        count_Kala += 1
                    End If
                Next
                If count_Kala > 1 Then
                    MessageBox.Show("گروه کالای سطر شماره" & i + 1 & " تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To DGV2.RowCount - 2

                If String.IsNullOrEmpty(DGV2.Item("Cln_Group", i).Value) Or String.IsNullOrEmpty(DGV2.Item("Cln_IdGroup", i).Value) Then
                    MessageBox.Show("نام گروه ویژه در ردیف شماره " & "{" & DGV2.Item("Cln_Row", i).Value + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Item("Cln_name", DGV2.Item("Cln_Row", i).Value).Selected = True
                    DGV2.Focus()
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                For j As Integer = 0 To DGV2.RowCount - 2
                    If (DGV2.Item("Cln_Ta", i).Value = DGV2.Item("Cln_Ta", j).Value) And (DGV2.Item("Cln_IdGroup", i).Value = DGV2.Item("Cln_IdGroup", j).Value) And (DGV2.Item("Cln_Row", i).Value = DGV2.Item("Cln_Row", j).Value) Then
                        count_Kala += 1
                    End If
                Next
                If count_Kala > 1 Then
                    MessageBox.Show("درصد فروش سطر شماره" & DGV2.Item("Cln_Row", i).Value + 1 & " تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV1.Item("Cln_name", DGV2.Item("Cln_Row", i).Value).Selected = True
                    DGV2.Focus()
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To DGV3.RowCount - 2
                If String.IsNullOrEmpty(DGV3.Item("Cln_Group2", i).Value) Or String.IsNullOrEmpty(DGV3.Item("Cln_IdGroup2", i).Value) Then
                    MessageBox.Show("نام گروه ویژه در بخش سایر کالاها در ردیف شماره " & "{" & i + 1 & "}" & "  را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV3.Focus()
                    DGV3.Item("Cln_Group2", i).Selected = True
                    Exit Sub
                End If

                Dim count_Kala As Long = 0
                For j As Integer = 0 To DGV3.RowCount - 2
                    If (DGV3.Item("Cln_IdGroup2", i).Value = DGV3.Item("Cln_IdGroup2", j).Value) Then
                        count_Kala += 1
                    End If
                Next
                If count_Kala > 1 Then
                    MessageBox.Show("درصد فروش در بخش سایر کالاها در سطر شماره" & i + 1 & " تکراری است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next


            Me.Enabled = False
            If EDIT = 0 Then
                If Not AreYouAdd(CLng(TxtIdVisitor.Text)) Then
                    MessageBox.Show("رابطه برای ویزیتور مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
                If SaveList() Then Me.Close()
            Else
                If Not AreYouEdit(CLng(TxtIdVisitor.Text), EDIT) Then
                    MessageBox.Show("رابطه برای ویزیتور مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
                If EditList() Then Me.Close()
            End If
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationVisitorFrosh_One", "BtnSave_Click")
        End Try
    End Sub

    Private Function AreYouAdd(ByVal Idvisitior As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  COUNT(IdVisitor) FROM ListVisitor_OG WHERE IdVisitor =" & Idvisitior, ConectionBank)
                If cmd.ExecuteScalar <= 0 Then
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return False
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationVisitorFrosh_One", "AreYouAdd")
            Return False
        End Try
    End Function

    Private Function AreYouEdit(ByVal NewId As Long, ByVal OldId As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT  COUNT(IdVisitor) FROM ListVisitor_OG WHERE IdVisitor =" & NewId & " AND IdVisitor <> " & OldId, ConectionBank)
                If cmd.ExecuteScalar <= 0 Then
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return False
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationVisitorFrosh_One", "AreYouEdit")
            Return False
        End Try
    End Function

    Private Function SaveList() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim id As Long = 0
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("INSERT INTO ListVisitor_OG(IdVisitor) VALUES(@IdVisitor)", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = CLng(TxtIdVisitor.Text)
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO ListKala_OG(IdKala,Mon,Kala,IdLinkVisitor) VALUES(@IdKala,@Mon,@Kala,@IdLinkVisitor);Select @@IDENTITY", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_HightMon", i).Value)
                    Cmd.Parameters.AddWithValue("@Kala", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_HightKala", i).Value)
                    Cmd.Parameters.AddWithValue("@IdLinkVisitor", SqlDbType.BigInt).Value = CLng(TxtIdVisitor.Text)
                    id = Cmd.ExecuteScalar
                    Cmd.Parameters.Clear()
                    Using CmdDarsad As New SqlCommand("INSERT INTO ListDarsad_OG(Frosh,Darsad,IdLinkKala,IdGroup) VALUES(@Frosh,@Darsad,@IdLinkKala,@IdGroup)", ConectionBank)
                        For j As Integer = 0 To DGV2.RowCount - 2
                            If DGV2.Item("Cln_Row", j).Value = i Then
                                CmdDarsad.Parameters.AddWithValue("@Frosh", SqlDbType.BigInt).Value = CDbl(DGV2.Item("Cln_Ta", j).Value)
                                CmdDarsad.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV2.Item("Cln_Darsad", j).Value)
                                CmdDarsad.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = CLng(DGV2.Item("Cln_IdGroup", j).Value)
                                CmdDarsad.Parameters.AddWithValue("@IdLinkKala", SqlDbType.BigInt).Value = id
                                CmdDarsad.ExecuteNonQuery()
                                CmdDarsad.Parameters.Clear()
                            End If
                        Next j
                    End Using
                Next i
            End Using

            Using CmdODarsad As New SqlCommand("INSERT INTO ListOrderDarsad_OG(IdGroup,Darsad,IdLinkVisitor) VALUES(@IdGroup,@Darsad,@IdLinkVisitor)", ConectionBank)
                For j As Integer = 0 To DGV3.RowCount - 2
                    CmdODarsad.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = CLng(DGV3.Item("Cln_IdGroup2", j).Value)
                    CmdODarsad.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV3.Item("Cln_Darsad2", j).Value)
                    CmdODarsad.Parameters.AddWithValue("@IdLinkVisitor", SqlDbType.BigInt).Value = CLng(TxtIdVisitor.Text)
                    CmdODarsad.ExecuteNonQuery()
                    CmdODarsad.Parameters.Clear()
                Next j
            End Using

            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "رابطه ویزیتور و فروش هدف-گروه اصلی", "جدید", "تعیین فروش هدف ویزیتور :" & TxtVisitor.Text, "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationVisitorFrosh_One", "SaveList")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Function EditList() As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim id As Long = 0
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////

            Using Cmd As New SqlCommand("DELETE FROM ListKala_OG WHERE IdLinkVisitor=@IdVisitor;DELETE FROM  ListOrderDarsad_OG WHERE IdLinkVisitor=@IdVisitor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = EDIT
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("Update ListVisitor_OG SET IdVisitor=@IdVisit WHERE IdVisitor=@IdVisitor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdVisit", SqlDbType.BigInt).Value = CLng(TxtIdVisitor.Text)
                Cmd.Parameters.AddWithValue("@IdVisitor", SqlDbType.BigInt).Value = EDIT
                Cmd.ExecuteNonQuery()
            End Using

            Using Cmd As New SqlCommand("INSERT INTO ListKala_OG(IdKala,Mon,Kala,IdLinkVisitor) VALUES(@IdKala,@Mon,@Kala,@IdLinkVisitor);Select @@IDENTITY", ConectionBank)
                For i As Integer = 0 To DGV1.RowCount - 2
                    Cmd.Parameters.AddWithValue("@IdKala", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_Code", i).Value)
                    Cmd.Parameters.AddWithValue("@Mon", SqlDbType.BigInt).Value = CDbl(DGV1.Item("Cln_HightMon", i).Value)
                    Cmd.Parameters.AddWithValue("@Kala", SqlDbType.Float).Value = CDbl(DGV1.Item("Cln_HightKala", i).Value)
                    Cmd.Parameters.AddWithValue("@IdLinkVisitor", SqlDbType.BigInt).Value = CLng(TxtIdVisitor.Text)
                    id = Cmd.ExecuteScalar
                    Cmd.Parameters.Clear()
                    Using CmdDarsad As New SqlCommand("INSERT INTO ListDarsad_OG(Frosh,Darsad,IdLinkKala,IdGroup) VALUES(@Frosh,@Darsad,@IdLinkKala,@IdGroup)", ConectionBank)
                        For j As Integer = 0 To DGV2.RowCount - 2
                            If DGV2.Item("Cln_Row", j).Value = i Then
                                CmdDarsad.Parameters.AddWithValue("@Frosh", SqlDbType.BigInt).Value = CDbl(DGV2.Item("Cln_Ta", j).Value)
                                CmdDarsad.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV2.Item("Cln_Darsad", j).Value)
                                CmdDarsad.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = CLng(DGV2.Item("Cln_IdGroup", j).Value)
                                CmdDarsad.Parameters.AddWithValue("@IdLinkKala", SqlDbType.BigInt).Value = id
                                CmdDarsad.ExecuteNonQuery()
                                CmdDarsad.Parameters.Clear()
                            End If
                        Next j
                    End Using
                Next i
            End Using

            Using CmdODarsad As New SqlCommand("INSERT INTO ListOrderDarsad_OG(IdGroup,Darsad,IdLinkVisitor) VALUES(@IdGroup,@Darsad,@IdLinkVisitor)", ConectionBank)
                For j As Integer = 0 To DGV3.RowCount - 2
                    CmdODarsad.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = CLng(DGV3.Item("Cln_IdGroup2", j).Value)
                    CmdODarsad.Parameters.AddWithValue("@Darsad", SqlDbType.Float).Value = CDbl(DGV3.Item("Cln_Darsad2", j).Value)
                    CmdODarsad.Parameters.AddWithValue("@IdLinkVisitor", SqlDbType.BigInt).Value = CLng(TxtIdVisitor.Text)
                    CmdODarsad.ExecuteNonQuery()
                    CmdODarsad.Parameters.Clear()
                Next j
            End Using
            '///////////////////////////////////////
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), " رابطه ویزیتور و فروش هدف-گروه اصلی", "ویرایش", If(Tmp_String1 = TxtVisitor.Text, "ویرایش فروش هدف ویزیتور :" & TxtVisitor.Text, "ویرایش فروش هدف ویزیتور :" & Tmp_String1 & " به  " & TxtVisitor.Text), "")

            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ویرایش شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "RelationVisitorFrosh_One", "EditList")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub DGV2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellEndEdit
        Try
            DGV2.Item("Cln_Row", e.RowIndex).Value = DGV1.CurrentRow.Index
            If e.ColumnIndex = 1 Then
                If Not (DGV2.Item(e.ColumnIndex, e.RowIndex).Value Is DBNull.Value) Or DGV2.Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    If e.RowIndex <> DGV2.RowCount - 1 Then
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV2.EditingControlShowing
        txt_dgv2 = e.Control
    End Sub

    Private Sub txt_dgv2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv2.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV2.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value) = "" Or Trim(DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV2.Item("Cln_Ta", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Darsad", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_IdGroup", DGV2.CurrentRow.Index).Value = ""
                DGV2.Item("Cln_Row", DGV2.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv2.KeyPress
        Try
            If DGV2.CurrentCell.ColumnIndex = 0 Then
                If Trim(DGV1.Item("Cln_Name", DGV1.CurrentRow.Index).Value) = "" Then
                    e.Handled = True
                    Exit Sub
                Else
                    Dim frmlk As New Group_List
                    frmlk.TxtSearch.Text = e.KeyChar()
                    frmlk.ShowDialog()
                    DGV2.Focus()
                    If Tmp_Namkala <> "" Then
                        DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value = Tmp_Namkala
                        DGV2.Item("Cln_IdGroup", DGV2.CurrentRow.Index).Value = IdKala
                        DGV2.Item("Cln_Ta", DGV2.CurrentRow.Index).Value = 0
                        DGV2.Item("Cln_Darsad", DGV2.CurrentRow.Index).Value = 0
                        DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Selected = False
                        DGV2.Item("Cln_Ta", DGV2.CurrentRow.Index).Selected = True
                    Else
                        DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Selected = False
                        DGV2.Item("Cln_Ta", DGV2.CurrentRow.Index).Selected = True
                    End If
                End If
            End If

            If DGV2.CurrentCell.ColumnIndex = 1 Or DGV2.CurrentCell.ColumnIndex = 2 Then
                If DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value = "" Then
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
            End If

        Catch ex As Exception

        End Try
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
                        DGV2.Item("Cln_Ta", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_Darsad", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_IdGroup", DGV2.CurrentRow.Index).Value = ""
                        DGV2.Item("Cln_Row", DGV2.CurrentRow.Index).Value = ""
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV2_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.RowLeave
        If DGV2.CurrentCell.ColumnIndex > 0 Then DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv2.TextChanged
        Try
            If DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv2.Clear()
                Exit Sub
            End If
            If DGV2.Item("Cln_Group", DGV2.CurrentRow.Index).Value = "" Then
                txt_dgv2.Clear()
                Exit Sub
            End If

            If Not (CheckDigit(txt_dgv2.Text)) Then
                txt_dgv2.Text = 0
            End If
            If CDbl(txt_dgv2.Text) < 0 Then
                txt_dgv2.Text = 0
            End If
            If DGV2.CurrentCell.ColumnIndex = 2 Then
                If CDbl(txt_dgv2.Text) > 100 Then
                    txt_dgv2.Text = 100
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Using frm As New ListRelationVisit_One
            frm.ShowDialog()
            DGV1.AllowUserToAddRows = False
            For i As Integer = 0 To ListKala.Length - 1
                DGV1.Rows.Add()
                DGV1.Item("Cln_Code", DGV1.RowCount - 1).Value = ListKala(i).Idkala
                DGV1.Item("Cln_Name", DGV1.RowCount - 1).Value = ListKala(i).NamKala
                DGV1.Item("Cln_HightMon", DGV1.RowCount - 1).Value = IIf(CDbl(ListKala(i).Mon) > 0, Format(CDbl(ListKala(i).Mon), "###,###"), 0)
                DGV1.Item("Cln_HightKala", DGV1.RowCount - 1).Value = ListKala(i).Hajm
            Next
            Array.Resize(ListKala, 0)
            DGV1.AllowUserToAddRows = True
            ''''''''''''''''''''''''''''''''''''''''''''''
            DGV2.AllowUserToAddRows = False
            For i As Integer = 0 To ListDarsad.Length - 1
                DGV2.Rows.Add()
                DGV2.Item("cln_Ta", DGV2.RowCount - 1).Value = ListDarsad(i).Frosh
                DGV2.Item("Cln_Darsad", DGV2.RowCount - 1).Value = ListDarsad(i).Darsad
                DGV2.Item("Cln_Group", DGV2.RowCount - 1).Value = ListDarsad(i).Group
                DGV2.Item("Cln_IdGroup", DGV2.RowCount - 1).Value = ListDarsad(i).IdGroup
                DGV2.Item("Cln_Row", DGV2.RowCount - 1).Value = ListDarsad(i).row
            Next
            Array.Resize(ListDarsad, 0)
            DGV2.AllowUserToAddRows = True
            ''''''''''''''''''''''''''''''''''''''''''''''
            DGV3.AllowUserToAddRows = False
            For i As Integer = 0 To ListODarsad.Length - 1
                DGV3.Rows.Add()
                DGV3.Item("Cln_Darsad2", DGV3.RowCount - 1).Value = ListODarsad(i).Darsad
                DGV3.Item("Cln_Group2", DGV3.RowCount - 1).Value = ListODarsad(i).Group
                DGV3.Item("Cln_IdGroup2", DGV3.RowCount - 1).Value = ListODarsad(i).IdGroup
            Next
            Array.Resize(ListODarsad, 0)
            DGV3.AllowUserToAddRows = True
            DGV1.Item("Cln_Name", 0).Selected = True
            DGV1.Focus()
        End Using
    End Sub

    Private Sub DGV3_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV3.EditingControlShowing
        txt_dgv3 = e.Control
    End Sub

    Private Sub DGV3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV3.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
                Case Keys.Delete
                    e.Handled = True
                    If DGV3.CurrentRow.Index <> DGV3.RowCount - 1 Then
                        DGV3.Rows.RemoveAt(DGV3.CurrentRow.Index)
                    Else
                        DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value = ""
                        DGV3.Item("Cln_IdGroup2", DGV3.CurrentRow.Index).Value = ""
                        DGV3.Item("Cln_Darsad2", DGV3.CurrentRow.Index).Value = ""
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV3_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.RowLeave
        If DGV3.CurrentCell.ColumnIndex > 0 Then DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Selected = True
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub txt_dgv3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dgv3.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If DGV3.CurrentCell.ColumnIndex = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
            If Trim(DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value) = "" Then
                e.Handled = True
                DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value = ""
                DGV3.Item("Cln_Darsad2", DGV3.CurrentRow.Index).Value = ""
                DGV3.Item("Cln_IdGroup2", DGV3.CurrentRow.Index).Value = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv3.KeyPress
        Try
            If DGV3.CurrentCell.ColumnIndex = 0 Then
                Dim frmlk As New Group_List
                frmlk.TxtSearch.Text = e.KeyChar()
                frmlk.ShowDialog()
                DGV3.Focus()
                If Tmp_Namkala <> "" Then
                    DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value = Tmp_Namkala
                    DGV3.Item("Cln_IdGroup2", DGV3.CurrentRow.Index).Value = IdKala
                    DGV3.Item("Cln_Darsad2", DGV3.CurrentRow.Index).Value = 0
                    DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Selected = False
                    DGV3.Item("Cln_Darsad2", DGV3.CurrentRow.Index).Selected = True
                Else
                    DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Selected = False
                    DGV3.Item("Cln_Darsad2", DGV3.CurrentRow.Index).Selected = True
                End If
            End If

            If DGV3.CurrentCell.ColumnIndex = 1 Then
                If DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value = "" Then
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
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv3.TextChanged
        Try
            If DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value Is DBNull.Value Then
                txt_dgv3.Clear()
                Exit Sub
            End If
            If DGV3.Item("Cln_Group2", DGV3.CurrentRow.Index).Value = "" Then
                txt_dgv3.Clear()
                Exit Sub
            End If

            If Not (CheckDigit(txt_dgv3.Text)) Then
                txt_dgv3.Text = 0
            End If
            If CDbl(txt_dgv3.Text) < 0 Then
                txt_dgv3.Text = 0
            End If
            If DGV3.CurrentCell.ColumnIndex = 1 Then
                If CDbl(txt_dgv3.Text) > 100 Then
                    txt_dgv3.Text = 100
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("آيا براي حذف همه درصدهای موجود مطمئن هستيد؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        Me.EmptyGridKala3()
    End Sub
End Class