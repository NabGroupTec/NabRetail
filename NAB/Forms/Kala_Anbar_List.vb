Imports System.Data.SqlClient
Public Class Kala_Anbar_List
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
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
    Private Sub GetKala()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dim sqlstr As String = ""
            If ChkActive.Checked = False Then
                sqlstr = "If (SELECT COUNT(IdUser) FROM Define_UserRAnbar  WHERE IdUser =" & Id_User & " )=0 SELECT AllKalaAnbar.*,KolCount=0,JozCount=0 FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,SetDeActiv,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Id,Define_Kala.Ex_Date,Define_Kala.Nam,Define_Kala.DK ,Define_Kala.DK_JOZ ,Define_Kala.DK_KOL ,Define_Kala.Cashing, Define_OneGroup.NamOne,Define_TwoGroup.NamTwo,Define_Vahed.Nam As Vahed FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed ON Define_Kala.IdVahed = Define_Vahed.Id WHERE Define_Kala.Activ='False') AS AllKala ,Define_Anbar WHERE SetDeActiv='False' ) As AllKalaAnbar ORDER BY NamOne ,NamTwo ,Nam,NamAnbar  else SELECT AllKalaAnbar.*,KolCount=0,JozCount=0 FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Id,Define_Kala.Ex_Date,Define_Kala.Nam,Define_Kala.DK ,Define_Kala.DK_JOZ ,Define_Kala.DK_KOL ,Define_Kala.Cashing, Define_OneGroup.NamOne,Define_TwoGroup.NamTwo,Define_Vahed.Nam As Vahed FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed ON Define_Kala.IdVahed = Define_Vahed.Id WHERE Define_Kala.Activ='False') AS AllKala ,Define_Anbar ) As AllKalaAnbar WHERE Idanbar  in (SELECT IDA   FROM Define_UserRPAnbar   WHERE IdUser =" & Id_User & " ) ORDER BY NamOne ,NamTwo ,Nam,NamAnbar "
            ElseIf ChkActive.Checked = True Then
                sqlstr = "If (SELECT COUNT(IdUser) FROM Define_UserRAnbar  WHERE IdUser =" & Id_User & ")=0 SELECT AllKalaAnbar.*,KolCount=0,JozCount=0  FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,SetDeActiv,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Id,Define_Kala.Ex_Date,Define_Kala.Nam,Define_Kala.DK ,Define_Kala.DK_JOZ ,Define_Kala.DK_KOL ,Define_Kala.Cashing, Define_OneGroup.NamOne,Define_TwoGroup.NamTwo,Define_Vahed.Nam As Vahed FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed ON Define_Kala.IdVahed = Define_Vahed.Id ) AS AllKala ,Define_Anbar WHERE SetDeActiv='False') As AllKalaAnbar ORDER BY NamOne ,NamTwo ,Nam,NamAnbar  else SELECT AllKalaAnbar.*,KolCount=0,JozCount=0 FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Id,Define_Kala.Ex_Date,Define_Kala.Nam,Define_Kala.DK ,Define_Kala.DK_JOZ ,Define_Kala.DK_KOL ,Define_Kala.Cashing, Define_OneGroup.NamOne,Define_TwoGroup.NamTwo,Define_Vahed.Nam As Vahed FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed ON Define_Kala.IdVahed = Define_Vahed.Id ) AS AllKala ,Define_Anbar ) As AllKalaAnbar WHERE Idanbar  in (SELECT IDA   FROM Define_UserRPAnbar   WHERE IdUser =" & Id_User & ") ORDER BY NamOne ,NamTwo ,Nam,NamAnbar "
            End If
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            CmbOne.Items.Clear()
            CmbTwo.Items.Clear()
            For i As Integer = 0 To Ds.Tables("Define_Kala").Rows.Count - 1
                If CmbOne.FindStringExact(Ds.Tables("Define_Kala").Rows(i).Item("NamOne")) = -1 Then
                    CmbOne.Items.Add(Ds.Tables("Define_Kala").Rows(i).Item("NamOne"))
                End If
            Next
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_List", "GetKala")
            Me.Close()
        End Try
    End Sub
    Private Sub GetTwoGroup(ByVal NamG As String)
        Try
            CmbTwo.Items.Clear()
            If String.IsNullOrEmpty(NamG) Then Exit Sub
            Dim dr() As DataRow = Ds.Tables("Define_Kala").Select("NamOne='" & NamG & "'")
            If dr.Length > 0 Then
                For i As Integer = 0 To dr.Length - 1
                    If CmbTwo.FindStringExact(dr(i).Item("NamTwo")) = -1 Then
                        CmbTwo.Items.Add(dr(i).Item("NamTwo"))
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            Me.GetKala()
            TxtSearch.Text = ""
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_List", "RefreshBank")
        End Try
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Down And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = DGV.Rows.Count - 1 Then
                DGV.Item(0, 0).Selected = True
                e.Handled = True
            Else
                DGV.Item(0, DGV.CurrentRow.Index + 1).Selected = True
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Up And DGV.RowCount > 0 Then
            If DGV.CurrentRow.Index = 0 Then
                DGV.Item(0, DGV.Rows.Count - 1).Selected = True
                e.Handled = True
            Else
                DGV.Item(0, DGV.CurrentRow.Index - 1).Selected = True
                e.Handled = True
            End If
        End If
        Me.GetKey(e)
    End Sub

    Private Sub TxtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSearch.KeyPress
        If RdoCode.Checked = True Then
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
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%'"
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%' AND NamTwo Like '" & CmbTwo.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text
                    ElseIf RdoCodeManual.Checked = True Then
                        dv.RowFilter = "Ex_Date Like '" & TxtSearch.Text & "%'"
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = ""
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%'"
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & CmbTwo.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text
                    ElseIf RdoCodeManual.Checked = True Then
                        dv.RowFilter = "Ex_Date Like '%" & TxtSearch.Text & "&'"
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamOne Like '" & CmbOne.Text.Trim & "%'"
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamOne Like '" & CmbOne.Text.Trim & "%' AND NamTwo Like '" & CmbTwo.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text
                    ElseIf RdoCodeManual.Checked = True Then
                        dv.RowFilter = "Ex_Date Like '" & TxtSearch.Text & "%'"
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'"
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamOne Like '%" & CmbOne.Text.Trim & "%'"
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & CmbTwo.Text.Trim & "%'"
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text
                    ElseIf RdoCodeManual.Checked = True Then
                        dv.RowFilter = "Ex_Date Like '%" & TxtSearch.Text & "%'"
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
        If DGV.RowCount > 1 And TxtSearch.Text <> "" Then
            Dim txtdgv, txtk As String
            For i As Integer = 0 To DGV.RowCount - 1
                txtdgv = DGV.Item(0, i).Value.ToString
                txtk = TxtSearch.Text
                If txtdgv.Contains(TxtSearch.Text.Trim) And txtdgv(0).ToString = txtk(0).ToString Then
                    DGV.Item(0, i).Selected = True
                    Exit Sub
                End If
            Next
            DGV.Item(0, 0).Selected = True
            DGV.Item(0, 0).Selected = False
        End If
    End Sub

    Private Sub Kala_List_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtSearch.Focus()
        SendKeys.Send("{End}")
        Dim ss As String = TxtSearch.Text.Trim
        TxtSearch.Text = ""
        TxtSearch.Text = ss
    End Sub

    Private Sub Kala_List_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Kala_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetKala()
        IdKala = 0
        Idanbar = 0
        namAnbar = ""
        DK = False
        DK_JOZ = 0
        DK_KOL = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        TmpVahed = ""
        Cashing = False
        If ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Dim tmp As String = TxtSearch.Text
        Dim def As String = GetDefault("KALA")
        Try
            Select Case def.Substring(0, 1)
                Case "0" : RdoAllKala.Checked = True
                Case "1" : RdoAllKala.Checked = True
                Case "2" : RdoAllKala.Checked = True
                Case "3" : RdoOne.Checked = True
                Case "4" : RdoTwo.Checked = True
                Case "5" : RdoCode.Checked = True
                Case "6" : RdoCodeManual.Checked = True
            End Select
            Select Case def.Substring(1, 1)
                Case "0" : RdoAval.Checked = True
                Case "1" : RdoAll.Checked = True
            End Select
            TxtSearch.Text = tmp
            SendKeys.Send("{END}")
        Catch ex As Exception
            RdoAllKala.Checked = True
            RdoAval.Checked = True
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If ChkAll.Visible = False Then
            If e.KeyCode = Keys.Escape Then
                IdKala = 0
                Idanbar = 0
                namAnbar = ""
                DK = False
                DK_JOZ = 0
                DK_KOL = 0
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                TmpVahed = ""
                Cashing = False
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        IdKala = CLng(DGV.Item("Cln_IdKala", DGV.CurrentRow.Index).Value.ToString)
                        Idanbar = CLng(DGV.Item("Cln_AnbarId", DGV.CurrentRow.Index).Value.ToString)
                        namAnbar = DGV.Item("Cln_AnbarNam", DGV.CurrentRow.Index).Value.ToString
                        Tmp_Namkala = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString
                        Tmp_OneGroup = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString
                        Tmp_TwoGroup = DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                        TmpVahed = DGV.Item("Cln_Vahed", DGV.CurrentRow.Index).Value.ToString
                        Cashing = DGV.Item("Cln_Cashing", DGV.CurrentRow.Index).Value
                        DK = DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value
                        If DK = True Then
                            DK_JOZ = DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value
                            DK_KOL = DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value
                        Else
                            DK_JOZ = 0
                            DK_KOL = 0
                        End If
                        Me.Close()
                    End If
                Catch ex As Exception
                    IdKala = 0
                    Idanbar = 0
                    namAnbar = ""
                    DK = False
                    DK_JOZ = 0
                    DK_KOL = 0
                    Tmp_Namkala = ""
                    Tmp_OneGroup = ""
                    Tmp_TwoGroup = ""
                    TmpVahed = ""
                    Cashing = False
                    Me.Close()
                End Try
            End If
        ElseIf ChkAll.Visible = True Then
            If e.KeyCode = Keys.Escape Then
                Array.Resize(AllSelectKala, 0)
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        Array.Resize(AllSelectKala, 0)
                        For i As Integer = 0 To DGV.RowCount - 1
                            If DGV.Item("Cln_Select", i).Value = True Then
                                Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                                AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV.Item("Cln_OneGroup", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV.Item("Cln_TwoGroup", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdKala", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).CostSkala = 0
                                AllSelectKala(AllSelectKala.Length - 1).CostBkala = 0
                            End If
                        Next
                    End If
                    Me.Close()
                Catch ex As Exception
                    Array.Resize(AllSelectKala, 0)
                    Me.Close()
                End Try
            End If
        End If
        If e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnNewKala.Enabled = True Then Call BtnNewKala_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnExit.Enabled = True Then Call BtnExit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        End If
    End Sub

    Private Sub BtnExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnExit.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAll.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAval.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If ChkAll.Visible = False Then
                If DGV.RowCount > 0 Then
                    IdKala = CLng(DGV.Item("Cln_IdKala", DGV.CurrentRow.Index).Value.ToString)
                    Idanbar = CLng(DGV.Item("Cln_AnbarId", DGV.CurrentRow.Index).Value.ToString)
                    namAnbar = DGV.Item("Cln_AnbarNam", DGV.CurrentRow.Index).Value.ToString
                    Tmp_Namkala = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString
                    Tmp_OneGroup = DGV.Item("Cln_OneGroup", DGV.CurrentRow.Index).Value.ToString
                    Tmp_TwoGroup = DGV.Item("Cln_TwoGroup", DGV.CurrentRow.Index).Value.ToString
                    TmpVahed = DGV.Item("Cln_Vahed", DGV.CurrentRow.Index).Value.ToString
                    Cashing = DGV.Item("Cln_Cashing", DGV.CurrentRow.Index).Value
                    DK = DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value
                    If DK = True Then
                        DK_JOZ = DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value
                        DK_KOL = DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value
                    Else
                        DK_JOZ = 0
                        DK_KOL = 0
                    End If
                End If
            ElseIf ChkAll.Visible = True Then

                If DGV.RowCount > 0 Then
                    Array.Resize(AllSelectKala, 0)
                    For i As Integer = 0 To DGV.RowCount - 1
                        If DGV.Item("Cln_Select", i).Value = True Then
                            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV.Item("Cln_OneGroup", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV.Item("Cln_TwoGroup", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdKala", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).CostSkala = 0
                            AllSelectKala(AllSelectKala.Length - 1).CostBkala = 0
                        End If
                    Next
                    Me.Close()
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            Idanbar = 0
            namAnbar = ""
            DK = False
            DK_JOZ = 0
            DK_KOL = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpVahed = ""
            Cashing = False
            Array.Resize(AllSelectKala, 0)
            Me.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        If ChkAll.Visible = False Then
            IdKala = 0
            Idanbar = 0
            namAnbar = ""
            DK = False
            DK_JOZ = 0
            DK_KOL = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpVahed = ""
            Cashing = False
        ElseIf ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        Me.Close()
    End Sub

    Private Sub RdoOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOne.CheckedChanged
        If RdoOne.Checked = True Then
            CmbOne.Enabled = True
            CmbOne.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOne.Text = ""
            CmbTwo.Text = ""
            CmbOne.Enabled = False
        End If
    End Sub

    Private Sub RdoTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTwo.CheckedChanged
        If RdoTwo.Checked = True Then
            CmbOne.Enabled = True
            CmbTwo.Enabled = True
            CmbOne.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "' AND NamTwo Like '" & CmbTwo.Text.Trim & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & CmbTwo.Text.Trim & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOne.Text = ""
            CmbTwo.Text = ""
            CmbOne.Enabled = False
            CmbTwo.Enabled = False
        End If
    End Sub

    Private Sub RdoAllKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAllKala.CheckedChanged
        If RdoAllKala.Checked = True Then
            CmbOne.Enabled = False
            CmbTwo.Enabled = False
            TxtSearch.Focus()
            Try
                TxtSearch.Text = ""
                dv.RowFilter = ""
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        End If
    End Sub

    Private Sub RdoAval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAval.CheckedChanged
        TxtSearch.Focus()
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        TxtSearch.Focus()
    End Sub

    Private Sub CmbOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOne.KeyDown
        If CmbOne.DroppedDown = False Then
            CmbOne.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbTwo.Focus()
            Exit Sub
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbTwo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbTwo.KeyDown
        If CmbTwo.DroppedDown = False Then
            CmbTwo.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            TxtSearch.Focus()
            Exit Sub
        End If
        Me.GetKey(e)
    End Sub

    Private Sub RdoAllKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAllKala.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoOne.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoTwo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoTwo.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub CmbOne_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOne.LostFocus
        Me.GetTwoGroup(CmbOne.Text.Trim)
    End Sub

    Private Sub CmbOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOne.SelectedIndexChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
            Me.GetTwoGroup(CmbOne.Text.Trim)
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTwo.SelectedIndexChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "' AND NamTwo Like '" & CmbTwo.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & CmbTwo.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbOne_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOne.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbTwo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTwo.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamOne Like '" & CmbOne.Text.Trim & "' AND NamTwo Like '" & CmbTwo.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamOne Like '%" & CmbOne.Text.Trim & "%' AND NamTwo Like '%" & CmbTwo.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If ChkAll.Checked = True Then
            For i As Integer = 0 To DGV.RowCount - 1
                DGV.Item("Cln_Select", i).Value = True
            Next
        ElseIf ChkAll.Checked = False Then
            For i As Integer = 0 To DGV.RowCount - 1
                DGV.Item("Cln_Select", i).Value = False
            Next
        End If
    End Sub

    Private Sub ChkAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkAll.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub BtnNewKala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewKala.Click
        Try
            Fnew = True
            Using Frmkala As New DefineKala
                Frmkala.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kala_List", "BtnNewKala_Click")
        End Try
    End Sub

    Private Sub BtnNewKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnNewKala.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ChkActive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkActive.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ChkActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkActive.CheckedChanged
        Me.Enabled = False
        Me.GetKala()
        Me.Enabled = True
    End Sub

    Private Sub RdoCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCode.CheckedChanged
        If RdoCode.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoCodeManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCodeManual.CheckedChanged
        If RdoCodeManual.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub
End Class