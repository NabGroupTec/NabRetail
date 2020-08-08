Imports System.Data.SqlClient
Public Class PeopleMoein_List
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Dim DsG As New DataSet
    Dim DtaG As New SqlDataAdapter()

    Public Condition As String
    Public Condition2 As String

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
    Private Sub GetPeople()
        Try
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            'Dta = New SqlDataAdapter("SELECT Define_People.Nam,Define_People.Tell1 ,Define_People.Tell2,Define_People.[Address] , Define_People.ID, Define_People.IdOstan, Define_People.IdCity, Define_City.NamCI, Define_Ostan.NamO FROM Define_People INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code AND Define_City.IdOstan = Define_Ostan.Code WHERE Define_People.Activ='False'" & Condition, DataSource)
            Dta = New SqlDataAdapter("If (SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User & ")>0 SELECT *,moein=(SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =ListMoein.id AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =ListMoein.id AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=ListMoein.id)As AllOneMoney )As One) FROM (SELECT Define_People.MCode,Define_People.IdGroup,Define_People.NamFac,Define_People.NamCo,Define_People.Nam,Define_People.Tell1 ,Define_People.Tell2,Define_People.[Address] , Define_People.ID, Define_People.IdOstan, Define_People.IdCity, Define_City.NamCI, Define_Ostan.NamO FROM Define_People INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code AND Define_City.IdOstan = Define_Ostan.Code WHERE Id in (SELECT IDP  FROM Define_UserRP WHERE IdUser =" & Id_User & " ) " & Condition & " )As ListMoein else SELECT *,moein=(SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =ListMoein.id AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =ListMoein.id AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=ListMoein.id)As AllOneMoney )As One) FROM (SELECT Define_People.MCode,Define_People.IdGroup,Define_People.NamFac,Define_People.NamCo,Define_People.Nam,Define_People.Tell1 ,Define_People.Tell2,Define_People.[Address] , Define_People.ID, Define_People.IdOstan, Define_People.IdCity, Define_City.NamCI, Define_Ostan.NamO FROM Define_People INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code AND Define_City.IdOstan = Define_Ostan.Code " & Condition & " )As ListMoein", DataSource)
            Dta.Fill(Ds, "Define_People")
            CmbOstan.Items.Clear()
            CmbCity.Items.Clear()
            For i As Integer = 0 To Ds.Tables("Define_People").Rows.Count - 1
                If CmbOstan.FindStringExact(Ds.Tables("Define_People").Rows(i).Item("NamO")) = -1 Then
                    CmbOstan.Items.Add(Ds.Tables("Define_People").Rows(i).Item("NamO"))
                End If
            Next
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_People").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "People_List", "GetPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub GetGroup()
        Try
            DsG.Clear()
            If Not DtaG Is Nothing Then
                DtaG.Dispose()
            End If

            DtaG = New SqlDataAdapter("SELECT nam, Id FROM Define_Group_P", DataSource)
            DtaG.Fill(DsG, "Define_Group_P")

            CmbGroup.DataSource = DsG.Tables("Define_Group_P")
            CmbGroup.DisplayMember = "nam"
            CmbGroup.ValueMember = "Id"

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "People_List", "GetGroup")
            Me.Close()
        End Try
    End Sub

    Private Sub GetTwoGroup(ByVal NamG As String)
        Try
            CmbCity.Items.Clear()
            If String.IsNullOrEmpty(NamG) Then Exit Sub
            Dim dr() As DataRow = Ds.Tables("Define_People").Select("NamO='" & NamG & "'")
            If dr.Length > 0 Then
                For i As Integer = 0 To dr.Length - 1
                    If CmbCity.FindStringExact(dr(i).Item("NamCI")) = -1 Then
                        CmbCity.Items.Add(dr(i).Item("NamCI"))
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            Ds.Clear()
            Dta.Fill(Ds, "Define_People")
            CmbOstan.Items.Clear()
            CmbOstan.Text = ""
            CmbCity.Items.Clear()
            CmbCity.Text = ""
            TxtSearch.Text = ""
            For i As Integer = 0 To Ds.Tables("Define_People").Rows.Count - 1
                If CmbOstan.FindStringExact(Ds.Tables("Define_People").Rows(i).Item("NamO")) = -1 Then
                    CmbOstan.Items.Add(Ds.Tables("Define_People").Rows(i).Item("NamO"))
                End If
            Next
            Me.GetTwoGroup(CmbOstan.Text.Trim)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "People_List", "RefreshBank")
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
            If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> "+" Then
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
        Dim mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                mon = ""
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & " AND moein<=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                mon = " (moein<=" & CDbl(TxtMon2.Text) & ")"
            End If
        Else
            mon = ""
        End If
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = mon
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "MCode Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = mon
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        dv.RowFilter = "MCode Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamO Like '" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "Id =" & x(i) & " OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "MCode ='" & x(i) & "' OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "MCode Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamO Like '%" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "Id =" & x(i) & " OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "MCode ='" & x(i) & "' OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "MCode Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = mon
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
        Me.GetPeople()
        Me.GetGroup()
        IdKala = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        Tmp_String2 = ""
        TmpAddress = ""
        TmpTell1 = ""
        TmpTell2 = ""
        Tmp_String2 = ""
        Tmp_String1 = ""
        If ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        DGV.Columns("Cln_Address").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Dim tmp As String = TxtSearch.Text

        Dim def As String = GetDefault("PEOPLE")
        Try
            Select Case def.Substring(0, 1)
                Case "0" : RdoAllKala.Checked = True
                Case "1" : RdoOne.Checked = True
                Case "2" : RdoTwo.Checked = True
                Case "3" : RdoCode.Checked = True
                Case "4" : RdoTell1.Checked = True
                Case "5" : RdoTell2.Checked = True
                Case "6" : RdoNamfac.Checked = True
                Case "7" : RdoAddress.Checked = True
                Case "8" : RdoMCode.Checked = True
                Case "9" : RdoGroup.Checked = True
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
                Tmp_Namkala = ""
                Tmp_OneGroup = ""
                Tmp_TwoGroup = ""
                TmpAddress = ""
                TmpTell1 = ""
                TmpTell2 = ""
                Tmp_String2 = ""
                Tmp_String1 = ""
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AslaheTarafHesab.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        IdKala = CLng(DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value.ToString)
                        Tmp_Namkala = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString
                        Tmp_OneGroup = DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString
                        Tmp_TwoGroup = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value.ToString
                        TmpAddress = DGV.Item("Cln_Address", DGV.CurrentRow.Index).Value.ToString
                        TmpTell1 = DGV.Item("Cln_Tell1", DGV.CurrentRow.Index).Value.ToString
                        TmpTell2 = DGV.Item("Cln_Tell2", DGV.CurrentRow.Index).Value.ToString
                        Tmp_String2 = DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value
                        Tmp_String1 = If(DGV.Item("Cln_Namfac", DGV.CurrentRow.Index).Value Is DBNull.Value, "", DGV.Item("Cln_Namfac", DGV.CurrentRow.Index).Value)
                        Me.Close()
                    End If
                Catch ex As Exception
                    IdKala = 0
                    Tmp_Namkala = ""
                    Tmp_OneGroup = ""
                    Tmp_TwoGroup = ""
                    TmpAddress = ""
                    TmpTell1 = ""
                    TmpTell2 = ""
                    Tmp_String2 = ""
                    Tmp_String1 = ""
                    Me.Close()
                End Try
            End If
        ElseIf ChkAll.Visible = True Then
            If e.KeyCode = Keys.Escape Then
                Array.Resize(AllSelectKala, 0)
                Me.Close()
            ElseIf e.KeyCode = Keys.F1 Then
                Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "AslaheTarafHesab.htm")
            ElseIf e.KeyCode = Keys.Enter Then
                Try
                    If DGV.RowCount > 0 Then
                        Array.Resize(AllSelectKala, 0)
                        For i As Integer = 0 To DGV.RowCount - 1
                            If DGV.Item("Cln_Select", i).Value = True Then
                                Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                                AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV.Item("Cln_Ostan", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV.Item("Cln_City", i).Value
                                AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
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
            If BtnNewP.Enabled = True Then Call BtnNewP_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnExit.Enabled = True Then Call BtnExit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.RefreshBank()
        ElseIf e.KeyCode = Keys.F6 Then
            If DGV.RowCount > 0 Then
                Using FValue As New FrmValue
                    FValue.LCode.Text = DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value
                    FValue.ShowDialog()
                End Using
            End If
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
                    IdKala = CLng(DGV.Item("Cln_IdP", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_Namkala = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value.ToString
                    Tmp_OneGroup = DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value.ToString
                    Tmp_TwoGroup = DGV.Item("Cln_City", DGV.CurrentRow.Index).Value.ToString
                    TmpAddress = DGV.Item("Cln_Address", DGV.CurrentRow.Index).Value.ToString
                    TmpTell1 = DGV.Item("Cln_Tell1", DGV.CurrentRow.Index).Value.ToString
                    TmpTell2 = DGV.Item("Cln_Tell2", DGV.CurrentRow.Index).Value.ToString
                    Tmp_String2 = DGV.Item("Cln_IdCity", DGV.CurrentRow.Index).Value
                    Tmp_String1 = If(DGV.Item("Cln_Namfac", DGV.CurrentRow.Index).Value Is DBNull.Value, "", DGV.Item("Cln_Namfac", DGV.CurrentRow.Index).Value)
                End If
            ElseIf ChkAll.Visible = True Then

                If DGV.RowCount > 0 Then
                    Array.Resize(AllSelectKala, 0)
                    For i As Integer = 0 To DGV.RowCount - 1
                        If DGV.Item("Cln_Select", i).Value = True Then
                            Array.Resize(AllSelectKala, AllSelectKala.Length + 1)
                            AllSelectKala(AllSelectKala.Length - 1).Namekala = DGV.Item("Cln_Nam", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).OneGroup = DGV.Item("Cln_Ostan", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).TwoGroup = DGV.Item("Cln_City", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).IdKala = DGV.Item("Cln_IdP", i).Value
                            AllSelectKala(AllSelectKala.Length - 1).CostSkala = CDbl(DGV.Item("Cln_Moein", i).Value)
                            AllSelectKala(AllSelectKala.Length - 1).CostBkala = 0
                        End If
                    Next
                    Me.Close()
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpAddress = ""
            TmpTell1 = ""
            TmpTell2 = ""
            Tmp_String2 = ""
            Tmp_String1 = ""
            Array.Resize(AllSelectKala, 0)
            Me.Close()
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        If ChkAll.Visible = False Then
            IdKala = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpAddress = ""
            TmpTell1 = ""
            TmpTell2 = ""
            Tmp_String2 = ""
            Tmp_String1 = ""
        ElseIf ChkAll.Visible = True Then
            Array.Resize(AllSelectKala, 0)
        End If
        Me.Close()
    End Sub

    Private Sub RdoOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOne.CheckedChanged
        If RdoOne.Checked = True Then
            CmbOstan.Enabled = True
            CmbOstan.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOstan.Text = ""
            CmbCity.Text = ""
            CmbOstan.Enabled = False
        End If
    End Sub

    Private Sub RdoTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTwo.CheckedChanged
        If RdoTwo.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbOstan.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%'"
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'"
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbOstan.Text = ""
            CmbCity.Text = ""
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
        End If
    End Sub

    Private Sub RdoAllKala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAllKala.CheckedChanged
        If RdoAllKala.Checked = True Then
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            CmbGroup.Enabled = False
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

    Private Sub CmbOne_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstan.KeyDown
        If CmbOstan.DroppedDown = False Then
            CmbOstan.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbCity.Focus()
            Exit Sub
        End If
        Me.GetKey(e)
    End Sub

    Private Sub CmbTwo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCity.KeyDown
        If CmbCity.DroppedDown = False Then
            CmbCity.DroppedDown = True
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

    Private Sub CmbOne_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstan.LostFocus
        Me.GetTwoGroup(CmbOstan.Text.Trim)
    End Sub

    Private Sub CmbOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Dim mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                mon = ""
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & " AND moein<=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                mon = " (moein<=" & CDbl(TxtMon2.Text) & ")"
            End If
        Else
            mon = ""
        End If

        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
            End If
            Me.GetTwoGroup(CmbOstan.Text.Trim)
        Catch ex As Exception
            dv.RowFilter = mon
        End Try
    End Sub

    Private Sub CmbTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        Dim mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                mon = ""
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & " AND moein<=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                mon = " (moein<=" & CDbl(TxtMon2.Text) & ")"
            End If
        Else
            mon = ""
        End If

        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
            End If
        Catch ex As Exception
            dv.RowFilter = mon
        End Try
    End Sub

    Private Sub CmbOne_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOstan.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub CmbTwo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCity.TextChanged
        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "' AND NamCI Like '" & CmbCity.Text.Trim & "%' AND Nam Like '" & TxtSearch.Text.Trim & "%'"
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%' AND Nam Like '%" & TxtSearch.Text.Trim & "%'"
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

    Private Sub BtnNewP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewP.Click
        Try
            Fnew = True
            Using FrmPeople As New DefinePeople
                FrmPeople.ShowDialog()
            End Using
            Fnew = False
            Me.RefreshBank()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "People_List", "BtnNewP_Click")
        End Try
    End Sub

    Private Sub BtnNewP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnNewP.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCode.CheckedChanged
        If RdoCode.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoTell1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTell1.CheckedChanged
        If RdoTell1.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoTell2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTell2.CheckedChanged
        If RdoTell2.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoNamfac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoNamfac.CheckedChanged
        If RdoNamfac.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoAddress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAddress.CheckedChanged
        If RdoAddress.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoTell1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoTell1.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoTell2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoTell2.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoNamfac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoNamfac.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoAddress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdoAddress.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RdoMCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoMCode.CheckedChanged
        If RdoMCode.Checked = True Then
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
    End Sub

    Private Sub RdoGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoGroup.CheckedChanged
        If RdoGroup.Checked = True Then
            Me.GetGroup()

            CmbGroup.Enabled = True
            CmbGroup.Focus()
            Try
                TxtSearch.Text = ""
                If RdoAval.Checked = True Then
                    dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue
                ElseIf RdoAll.Checked = True Then
                    dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue
                End If
            Catch ex As Exception
                dv.RowFilter = ""
            End Try
        Else
            TxtSearch.Focus()
            CmbGroup.Text = ""
            CmbGroup.Enabled = False
        End If
    End Sub

    Private Sub CmbGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbGroup.SelectedIndexChanged
        Dim mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                mon = ""
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & " AND moein<=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                mon = " (moein<=" & CDbl(TxtMon2.Text) & ")"
            End If
        Else
            mon = ""
        End If

        Try
            If RdoAval.Checked = True Then
                dv.RowFilter = "IdGroup=" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
            ElseIf RdoAll.Checked = True Then
                dv.RowFilter = "IdGroup=" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
            End If
            Me.GetTwoGroup(CmbOstan.Text.Trim)
        Catch ex As Exception
            dv.RowFilter = mon
        End Try
    End Sub

    Private Sub ChKMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKMon.CheckedChanged
        If ChKMon.Checked = True Then
            ChkAzMon.Enabled = True
            ChkTaMon.Enabled = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            TxtMon1.Focus()
        Else
            ChkAzMon.Checked = False
            ChkTaMon.Checked = False
            ChkAzMon.Enabled = False
            ChkTaMon.Enabled = False
            TxtMon1.Enabled = False
            TxtMon2.Enabled = False
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
        End If
        Call TxtSearch_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub ChkAzMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMon.CheckedChanged
        If ChkAzMon.Checked = True Then
            TxtMon1.Text = "0"
            TxtMon1.Enabled = True
            TxtMon1.Focus()
            TxtMon1.SelectAll()
        Else
            TxtMon1.Text = "0"
            TxtMon1.Enabled = False
        End If
        Call TxtSearch_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub ChkTaMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMon.CheckedChanged
        If ChkTaMon.Checked = True Then
            TxtMon2.Text = "0"
            TxtMon2.Enabled = True
            TxtMon2.Focus()
            TxtMon2.SelectAll()
        Else
            TxtMon2.Text = "0"
            TxtMon2.Enabled = False
        End If
        Call TxtSearch_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub TxtMon1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMon2.Focus()
    End Sub

    Private Sub TxtMon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon1.KeyPress
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

    Private Sub TxtMon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon1.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon1.Text.Replace(",", "")))) Then
                TxtMon1.Text = "0"
                TxtMon1.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon1.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon1.Text.Replace(",", ""))
                TxtMon1.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon1.Text = CDbl(TxtMon1.Text)
            End If
        Catch ex As Exception

        End Try
        Dim mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                mon = ""
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & " AND moein<=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                mon = " (moein<=" & CDbl(TxtMon2.Text) & ")"
            End If
        Else
            mon = ""
        End If
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = mon
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "MCode Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = mon
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        dv.RowFilter = "MCode Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamO Like '" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "Id =" & x(i) & " OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "MCode ='" & x(i) & "' OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "MCode Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamO Like '%" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "Id =" & x(i) & " OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "MCode ='" & x(i) & "' OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "MCode Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = mon
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

    Private Sub TxtMon2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon2.KeyPress
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

    Private Sub TxtMon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon2.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon2.Text.Replace(",", "")))) Then
                TxtMon2.Text = "0"
                TxtMon2.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon2.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon2.Text.Replace(",", ""))
                TxtMon2.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon2.Text = CDbl(TxtMon2.Text)
            End If
        Catch ex As Exception

        End Try
        Dim mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                mon = ""
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & " AND moein<=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                mon = " (moein>=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                mon = " (moein<=" & CDbl(TxtMon2.Text) & ")"
            End If
        Else
            mon = ""
        End If
        Try
            If String.IsNullOrEmpty(TxtSearch.Text) Then
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = mon
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "MCode Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = mon
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        dv.RowFilter = "MCode Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                If RdoAval.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamO Like '" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '" & TxtSearch.Text.Trim & "%'  AND NamO Like '" & CmbOstan.Text.Trim & "%' AND NamCI Like '" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "Id =" & x(i) & " OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "MCode ='" & x(i) & "' OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "MCode Like '" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                ElseIf RdoAll.Checked = True Then
                    If RdoAllKala.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoOne.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamO Like '%" & CmbOstan.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTwo.Checked = True Then
                        dv.RowFilter = "Nam Like '%" & TxtSearch.Text.Trim & "%'  AND NamO Like '%" & CmbOstan.Text.Trim & "%' AND NamCI Like '%" & CmbCity.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "Id =" & x(i) & " OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "Id=" & TxtSearch.Text & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoTell1.Checked = True Then
                        dv.RowFilter = "Tell1 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoTell2.Checked = True Then
                        dv.RowFilter = "Tell2 Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoNamfac.Checked = True Then
                        dv.RowFilter = "NamCo Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoAddress.Checked = True Then
                        dv.RowFilter = "Address Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    ElseIf RdoMCode.Checked = True Then
                        If TxtSearch.Text.Contains("+") Then
                            Dim x() As String
                            Dim Con As String = ""
                            x = TxtSearch.Text.Split("+")

                            For i As Integer = 0 To x.Length - 1
                                If Not String.IsNullOrEmpty(x(i)) Then Con &= "MCode ='" & x(i) & "' OR "
                            Next

                            If Not String.IsNullOrEmpty(Con) Then Con = Con.Substring(0, Con.Length - 3)
                            dv.RowFilter = Con & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        Else
                            dv.RowFilter = "MCode Like '%" & TxtSearch.Text.Trim & "%'" & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                        End If
                    ElseIf RdoGroup.Checked = True Then
                        dv.RowFilter = "IdGroup =" & CmbGroup.SelectedValue & If(String.IsNullOrEmpty(mon), "", " AND " & mon)
                    End If
                End If
                DGV.Sort(DGV.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            dv.RowFilter = mon
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
End Class