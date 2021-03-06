Imports System.Data.SqlClient
Imports System.Transactions

Public Class Mobile_AddPeople
    Dim row As Integer
    Dim edt As Integer
    Dim str_name As String
    Dim ds As New DataSet

    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_O As New DataSet
    Dim str_O As String = "select Code,NamO From Define_Ostan"
    Dim dta_O As New SqlDataAdapter(str_O, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_C As New DataSet
    Dim str_C As String = "select Code,NamCI,Idostan From Define_City"
    Dim dta_C As New SqlDataAdapter(str_C, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_P As New DataSet
    Dim str_P As String = "select Code,NamP,IdOstan,IdCity From Define_Part"
    Dim dta_P As New SqlDataAdapter(str_P, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim ds_G As New DataSet
    Dim str_G As String = "select Id,Nam From Define_Group_P"
    Dim dta_G As New SqlDataAdapter(str_G, DataSource)
    ''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub Set_Ostan_City_Part()
        Dim T_str As String = "SELECT     Define_People.ID , NamO, NamCI, NamP FROM  Define_People INNER JOIN Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_People")
        If T_ds.Tables("Define_People").Rows.Count <= 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To ds.Tables("Define_People").Rows.Count - 1
            Dim dr() As DataRow = T_ds.Tables(0).Select("Id=" & ds.Tables("Define_People").Rows(i).Item("ID"))
            If dr.Length > 0 Then
                ds.Tables("Define_People").Rows(i).Item("Ostan") = dr(0).Item("NamO")
                ds.Tables("Define_People").Rows(i).Item("City") = dr(0).Item("NamCI")
                ds.Tables("Define_People").Rows(i).Item("Part") = dr(0).Item("NamP")
            End If
        Next
    End Sub


    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then Txttell1.Focus()
    End Sub

    Private Sub Txttell1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txttell1.KeyDown
        If e.KeyCode = Keys.Enter Then Txtfax.Focus()
    End Sub

    Private Sub Txttell2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txttell2.KeyDown
        If e.KeyCode = Keys.Enter Then Txtfac.Focus()
    End Sub

    Private Sub Txtfax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtfax.KeyDown
        If e.KeyCode = Keys.Enter Then Txttell2.Focus()
    End Sub

    Private Sub Txtadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtadd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Chkbuyer.Focus()
        End If
    End Sub

    Private Sub Fill_Ostan()
        Try
            ds_O.Clear()
            If Not dta_O Is Nothing Then
                dta_O.Dispose()
            End If
            dta_O = New SqlDataAdapter(str_O, DataSource)
            dta_O.Fill(ds_O, "Define_Ostan")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "Fill_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_City()
        Try
            ds_C.Clear()
            If Not dta_C Is Nothing Then
                dta_C.Dispose()
            End If
            dta_C = New SqlDataAdapter(str_C, DataSource)
            dta_C.Fill(ds_C, "Define_City")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "Fill_City")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_Part()
        Try
            ds_P.Clear()
            If Not dta_P Is Nothing Then
                dta_P.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_P = New SqlDataAdapter(str_P, DataSource)
            dta_P.Fill(ds_P, "Define_Part")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "Fill_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_Group()
        Try
            ds_G.Clear()
            If Not dta_G Is Nothing Then
                dta_G.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_G = New SqlDataAdapter(str_G, DataSource)
            dta_G.Fill(ds_G, "Define_Group_P")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "Fill_Group")
            Me.Close()
        End Try
    End Sub

    Private Sub getkey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "TarafTemp.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnAdd.Enabled = True Then BtnAdd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button3.Enabled = True Then Button3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Mobile_AddPeople_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Txtname.Focus()
    End Sub

    Private Sub Define_Define_People_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.getkey(e)
    End Sub
    Private Sub Factory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.Fill_Ostan()
        Me.Fill_City()
        Me.Fill_Part()
        Me.Fill_Group()
        Me.FillOstan()
        Me.FillGroup()
        edt = 0
        CmbState.Text = ""
        CmbState.Text = CmbState.Items(2).ToString
        TxtOstanP.Text = 0
        TxtCityP.Text = 0
        TxtPartP.Text = 0
        TxtGroup.Text = 0
        Txtallmoney.Text = 0

        FillOstan()
        CmbOstanP.Text = Tmp_String1
        TxtOstanP.Text = TxtIdOstan

        FillCity(TxtIdOstan)
        CmbCityP.Text = Tmp_String2
        TxtCityP.Text = TxtIdCity

        FillPart(TxtIdOstan, TxtIdCity)
        CmbPartP.Text = TmpAddress
        TxtPartP.Text = IdKala

        CmbGroup.Text = Tmp_Namkala
        TxtGroup.Text = DK_KOL

    End Sub

    Private Function AreYouAddP(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_People WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_People")
        If T_ds.Tables("Define_People").Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function AreYouEditP(ByVal nam As String) As Boolean
        Dim T_str As String = "select Nam  from Define_People WHERE Nam=N'" & nam & "'"
        Dim T_ds As New DataSet
        Dim T_dta As New SqlDataAdapter()
        '''''''''''''''''''''''''''
        T_ds.Clear()
        If Not T_dta Is Nothing Then
            T_dta.Dispose()
        End If
        '''''''''''''''''''''''''''
        T_dta = New SqlDataAdapter(T_str, DataSource)
        T_dta.Fill(T_ds, "Define_People")
        If T_ds.Tables("Define_People").Rows.Count >= 1 Then
            If (T_ds.Tables("Define_People").Rows(0).Item("Nam") <> Txtname.Text) Or (T_ds.Tables("Define_People").Rows(0).Item("Nam") = str_name) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = "*" Or e.KeyChar = "?" Or e.KeyChar = "؟" Or e.KeyChar = "'" Or e.KeyChar = "|" Then
            e.Handled = True
        End If
    End Sub
    Private Sub Txtname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtname.LostFocus
        Dim str As String = ""
        str = Txtname.Text.Trim
        str = str.Replace("  ", " ")
        str = str.Replace("   ", " ")
        str = str.Replace("    ", " ")
        Txtname.Text = str
    End Sub

    Private Sub Chkbuyer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbuyer.GotFocus
        Chkbuyer.BackColor = Color.LightGray
    End Sub

    Private Sub Chkbuyer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkbuyer.KeyDown
        If e.KeyCode = Keys.Enter Then Chkseller.Focus()
    End Sub

    Private Sub Chkbuyer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkbuyer.LostFocus
        Chkbuyer.BackColor = Me.BackColor
    End Sub

    Private Sub Chkseller_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkseller.GotFocus
        Chkseller.BackColor = Color.LightGray
    End Sub

    Private Sub Chkseller_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkseller.LostFocus
        Chkseller.BackColor = Me.BackColor
    End Sub

    Private Sub Chkseller_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkseller.KeyDown
        If e.KeyCode = Keys.Enter Then Chkother.Focus()
    End Sub

    Private Sub Txtallmoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtallmoney.KeyDown
        If e.KeyCode = Keys.Enter Then CmbOstanP.Focus()
    End Sub

    Private Sub Txtallmoney_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtallmoney.KeyPress
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

    Private Sub Txtallmoney_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtallmoney.TextChanged
        If Not (CheckDigit(Format$(Txtallmoney.Text.Replace(",", "")))) Then
            Txtallmoney.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If Txtallmoney.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(Txtallmoney.Text.Replace(",", ""))
            Txtallmoney.Text = Format$(Val(str), "###,###,###")
        Else
            Txtallmoney.Text = CDbl(Txtallmoney.Text)
        End If
    End Sub

    Private Sub CmbState_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbState.GotFocus
        If CmbState.DroppedDown = False Then CmbState.DroppedDown = True
    End Sub
    Private Sub CmbState_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbState.KeyDown
        If e.KeyCode = Keys.Enter Then Txtallmoney.Focus()
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If CmbState.DroppedDown = False Then CmbState.DroppedDown = True
        End If
    End Sub

    Private Sub Txtdelay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtdelay.KeyDown
        If e.KeyCode = Keys.Enter Then ChkMon.Focus()
    End Sub

    Private Sub Txtdelay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdelay.KeyPress
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

    Private Sub Txtdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdelay.TextChanged
        If Not (CheckDigit(Format$(Txtdelay.Text))) Then Txtdelay.Text = "0"
    End Sub

    Private Sub TxtMoney_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMoney.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtadd.Focus()
        End If
    End Sub

    Private Sub TxtMoney_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoney.KeyPress
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

    Private Sub TxtMoney_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoney.TextChanged
        If Not (CheckDigit(Format$(TxtMoney.Text.Replace(",", "")))) Then
            TxtMoney.Text = "0"
            Exit Sub
        End If
        Dim str As String
        If TxtMoney.Text.Length > 3 Then
            SendKeys.Send("{end}")
            str = Format$(TxtMoney.Text.Replace(",", ""))
            TxtMoney.Text = Format$(Val(str), "###,###,###")
        Else
            TxtMoney.Text = CDbl(TxtMoney.Text)
        End If
    End Sub

    Private Sub ChkMon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMon.GotFocus
        ChkMon.BackColor = Color.LightGray
    End Sub

    Private Sub ChkMon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkMon.KeyDown
        If e.KeyCode = Keys.Enter Then TxtMoney.Focus()
    End Sub

    Private Sub ChkMon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMon.LostFocus
        ChkMon.BackColor = Me.BackColor
    End Sub

    Private Sub Chkother_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkother.GotFocus
        Chkother.BackColor = Color.LightGray
    End Sub

    Private Sub Chkother_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkother.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CmbState.Visible = True Then
                CmbState.Focus()
            Else
                ' cmdsave.Focus()
            End If
        End If

    End Sub

    Private Sub Chkother_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkother.LostFocus
        Chkother.BackColor = Me.BackColor
    End Sub

    Private Sub Chkother_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkother.CheckedChanged
        If Chkother.Checked = True Then
            Chkseller.Checked = False
            Chkbuyer.Checked = False
        End If
    End Sub

    Private Sub Chkseller_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkseller.CheckedChanged
        If Chkseller.Checked = True Then
            Chkother.Checked = False
        End If
    End Sub

    Private Sub Chkbuyer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkbuyer.CheckedChanged
        If Chkbuyer.Checked = True Then
            Chkother.Checked = False
        End If
    End Sub

    Private Sub Txtfac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtfac.KeyDown
        If e.KeyCode = Keys.Enter Then Txtco.Focus()
    End Sub

    Private Sub Txtco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtco.KeyDown
        If e.KeyCode = Keys.Enter Then Txtdelay.Focus()
    End Sub

    Private Sub CmbOstanP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstanP.KeyDown
        If CmbOstanP.DroppedDown = False Then CmbOstanP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbCityP.Focus()
    End Sub

    Private Sub CmbOstanP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstanP.SelectedIndexChanged
        TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
        Me.FillCity(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
        Me.FillPart(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
    End Sub
    Private Sub FillOstan()
        CmbOstanP.Items.Clear()
        For i As Integer = 0 To ds_O.Tables(0).Rows.Count - 1
            CmbOstanP.Items.Add(ds_O.Tables(0).Rows(i).Item("NamO"))
        Next
    End Sub
    Private Sub FillGroup()
        CmbGroup.Items.Clear()
        For i As Integer = 0 To ds_G.Tables(0).Rows.Count - 1
            CmbGroup.Items.Add(ds_G.Tables(0).Rows(i).Item("Nam"))
        Next
    End Sub
    Private Sub FillCity(ByVal idO As Long)
        CmbCityP.Items.Clear()
        For i As Integer = 0 To ds_C.Tables(0).Rows.Count - 1
            If ds_C.Tables(0).Rows(i).Item("IdOstan") = idO Then
                CmbCityP.Items.Add(ds_C.Tables(0).Rows(i).Item("NamCi"))
            End If
        Next
    End Sub
    Private Function GetIdGroup(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_G.Tables(0).Select("Nam ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("ID")
        Else
            Return -1
        End If
    End Function
    Private Function GetIdOstan(ByVal Nam As String) As Long
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("NamO ='" & Nam & "'")
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function
    Private Function GetIdCity(ByVal Nam As String, ByVal idO As String) As Long
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("NamCi ='" & Nam & "' AND IdOstan=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function

    Private Function GetNamOstan(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_O.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamO")
        Else
            Return ""
        End If
    End Function
    Private Function GetNamCity(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_C.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamCi")
        Else
            Return ""
        End If
    End Function
    Private Sub FillPart(ByVal idO As Long, ByVal idCi As Long)
        CmbPartP.Items.Clear()
        For i As Integer = 0 To ds_P.Tables(0).Rows.Count - 1
            If ds_P.Tables(0).Rows(i).Item("IdOstan") = idO And ds_P.Tables(0).Rows(i).Item("IdCity") = idCi Then
                CmbPartP.Items.Add(ds_P.Tables(0).Rows(i).Item("NamP"))
            End If
        Next
    End Sub

    Private Sub CmbCityP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCityP.KeyDown
        If CmbCityP.DroppedDown = False Then CmbCityP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbPartP.Focus()

    End Sub

    Private Sub CmbCityP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCityP.SelectedIndexChanged
        TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
        Me.FillPart(If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
    End Sub

    Private Sub CmbPartP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbPartP.KeyDown
        If CmbPartP.DroppedDown = False Then CmbPartP.DroppedDown = True
        If e.KeyCode = Keys.Enter Then CmbGroup.Focus()
    End Sub

    Private Sub CmbPartP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPartP.SelectedIndexChanged
        TxtPartP.Text = GetIdPart(CmbPartP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
    End Sub
    Private Function GetIdPart(ByVal Nam As String, ByVal idO As String, ByVal idCi As String) As Long
        Dim dr() As DataRow
        dr = ds_P.Tables(0).Select("NamP ='" & Nam & "' AND IdCity=" & idCi & " AND IdOstan=" & idO)
        If dr.Length >= 1 Then
            Return dr(0).Item("Code")
        Else
            Return -1
        End If
    End Function

    Private Function GetNamPart(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_P.Tables(0).Select("Code =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("NamP")
        Else
            Return ""
        End If
    End Function

    Private Function GetNamGroup(ByVal Id As Long) As String
        Dim dr() As DataRow
        dr = ds_G.Tables(0).Select("ID =" & Id)
        If dr.Length >= 1 Then
            Return dr(0).Item("Nam")
        Else
            Return ""
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Fnew = True
            Using FrmCity As New DefineCity
                FrmCity.ShowDialog()
            End Using
            Fnew = False
            ds_O.Clear()
            dta_O.Fill(ds_O, "Define_Ostan")
            ds_C.Clear()
            dta_C.Fill(ds_C, "Define_City")
            ds_P.Clear()
            dta_P.Fill(ds_P, "Define_Part")
            Me.FillOstan()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "Button1_Click")
        End Try
    End Sub

    Private Sub CmbGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbGroup.KeyDown
        If CmbGroup.DroppedDown = False Then CmbGroup.DroppedDown = True
        If e.KeyCode = Keys.Enter Then TxtDate.Focus()
    End Sub

    Private Sub CmbGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbGroup.SelectedIndexChanged
        TxtGroup.Text = GetIdGroup(CmbGroup.Text)
    End Sub

    Private Sub TxtOstanP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOstanP.TextChanged
        'If Not String.IsNullOrEmpty(TxtOstanP.Text.Trim) And cmdadd.Enabled = True Then CmbOstanP.Text = Me.GetNamOstan(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value)
        Try
            'CmbOstanP.Text = Me.GetNamOstan(DGV.Item("Cln_Ostan", DGV.CurrentRow.Index).Value)
            CmbOstanP.Text = Me.GetNamOstan(TxtOstanP.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPartP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPartP.TextChanged
        'If Not String.IsNullOrEmpty(TxtPartP.Text.Trim) And cmdadd.Enabled = True Then CmbPartP.Text = Me.GetNamPart(DGV.Item("Cln_Part", DGV.CurrentRow.Index).Value)
        Try
            'CmbPartP.Text = Me.GetNamPart(DGV.Item("Cln_Part", DGV.CurrentRow.Index).Value)
            CmbPartP.Text = Me.GetNamPart(TxtPartP.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCityP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCityP.TextChanged
        'If Not String.IsNullOrEmpty(TxtCityP.Text.Trim) And cmdadd.Enabled = True Then CmbCityP.Text = Me.GetNamCity(DGV.Item("Cln_City", DGV.CurrentRow.Index).Value)
        Try
            'CmbCityP.Text = Me.GetNamCity(DGV.Item("Cln_City", DGV.CurrentRow.Index).Value)
            CmbCityP.Text = Me.GetNamCity(TxtCityP.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGroup.TextChanged
        Try
            'If Not String.IsNullOrEmpty(TxtGroup.Text.Trim) And cmdadd.Enabled = True Then
            CmbGroup.Text = Me.GetNamGroup(TxtGroup.Text)
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Fnew = True
            Using FrmPeople As New DefineGroupP
                FrmPeople.ShowDialog()
            End Using
            Fnew = False
            Me.Fill_Group()
            Me.FillGroup()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "Button2_Click")
        End Try
    End Sub

    Private Sub TxtDate_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDate.KeyDowned
        If e.KeyCode = Keys.Enter Then BtnAdd.Focus()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If Trim(Txtname.Text) = "" Then
                MessageBox.Show("نام طرف حساب را وارد كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtname.Focus()
                Exit Sub
            End If
            If Chkbuyer.Checked = False And Chkseller.Checked = False And Chkother.Checked = False Then
                MessageBox.Show("لطفا يكي از گزينه هاي خريدار،فروشنده یا سایر را انتخاب كنيد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Chkbuyer.Focus()
                Exit Sub
            End If
            If (CmbState.Text = "بدهکار" Or CmbState.Text = "بستانکار") And (Txtallmoney.Text = 0) Then
                MessageBox.Show("در صورت انتخاب وضعیت به صورت بدهکار یا بستانکار باید مبلغ اول دوره را مشخص کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtallmoney.Focus()
                Exit Sub
            End If
            If (CmbState.Text = "بی حساب") And (Txtallmoney.Text <> 0) Then
                MessageBox.Show("در صورت انتخاب وضعیت به صورت بی حساب باید مبلغ اول دوره صفر باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtallmoney.Text = 0
                Txtallmoney.Focus()
                Exit Sub
            End If
            If CDbl(TxtMoney.Text < 0) Then
                MessageBox.Show("اعتبار منفی قابل قبول نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtMoney.Text = 0
                TxtMoney.Focus()
                Exit Sub
            End If
            If CDbl(Txtdelay.Text < 0) Then
                MessageBox.Show("مدت وعده منفی قابل قبول نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txtdelay.Text = 0
                Txtdelay.Focus()
                Exit Sub
            End If
            TxtGroup.Text = GetIdGroup(CmbGroup.Text)
            TxtOstanP.Text = GetIdOstan(CmbOstanP.Text)
            TxtCityP.Text = GetIdCity(CmbCityP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)))
            TxtPartP.Text = GetIdPart(CmbPartP.Text, If(String.IsNullOrEmpty(TxtOstanP.Text), 0, CLng(TxtOstanP.Text)), If(String.IsNullOrEmpty(TxtCityP.Text), 0, CLng(TxtCityP.Text)))
            If String.IsNullOrEmpty(TxtOstanP.Text.Trim) Or CmbOstanP.Text = "" Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtCityP.Text.Trim) Or CmbCityP.Text = "" Then
                MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCityP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtPartP.Text.Trim) Or CmbPartP.Text = "" Then
                MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbPartP.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtGroup.Text.Trim) Or CmbGroup.Text = "" Then
                MessageBox.Show("هیچ گروه ویژه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbGroup.Focus()
                Exit Sub
            End If
            If TxtOstanP.Text = "-1" Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbOstanP.Focus()
                Exit Sub
            End If
            If TxtCityP.Text = "-1" Then
                MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCityP.Focus()
                Exit Sub
            End If
            If TxtPartP.Text = "-1" Then
                MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbPartP.Focus()
                Exit Sub
            End If
            If TxtGroup.Text = "-1" Then
                MessageBox.Show("هیچ گروه ویژه ای انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbGroup.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtDate.ThisText) Or TxtDate.ThisText = "" Then
                MessageBox.Show("تاریخ معرفی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDate.Focus()
                Exit Sub
            End If

            If Not Me.AreYouAddP(Txtname.Text.Trim) Then
                MessageBox.Show("نام طرف حساب مورد نظر تکراری است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not SavePeople(CLng(LId.Text)) Then Exit Sub
            Me.Close()

        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("طرف حساب انتخابی شما قابل ذخیره شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "cmdsave_Click")
            End If
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Function SavePeople(ByVal Id As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim Idp As Long = 0
        Try

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Using Cmd As New SqlCommand("INSERT INTO Define_People ([Nam],[Tell1],[Tell2],[Fax],[Address],[Buyer],[Seller],[Other],[GValue],[GValueMon],[AllMoney],[State],[Rate],[NamCo],[NamFac],[IdOstan],[IdCity],[IdPart],[Activ],[ChkIdGroup],[IdGroup],[D_Dat],[MCode]) VALUES (@Nam,@Tell1,@Tell2,@Fax,@Address,@Buyer,@Seller,@Other,@GValue,@GValueMon,@AllMoney,@State,@Rate,@NamCo,@NamFac,@IdOstan,@IdCity,@IdPart,@Activ,@ChkIdGroup,@IdGroup,@D_Dat,@MCode); SELECT @@IDENTITY ", ConectionBank)
                Cmd.Parameters.AddWithValue("@Nam", SqlDbType.NVarChar).Value = Txtname.Text.Trim
                Cmd.Parameters.AddWithValue("@Tell1", SqlDbType.NVarChar).Value = Txttell1.Text.Trim
                Cmd.Parameters.AddWithValue("@Tell2", SqlDbType.NVarChar).Value = Txttell2.Text.Trim
                Cmd.Parameters.AddWithValue("@Fax", SqlDbType.NVarChar).Value = Txtfax.Text.Trim
                Cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = Txtadd.Text.Trim
                Cmd.Parameters.AddWithValue("@Buyer", SqlDbType.Bit).Value = Chkbuyer.CheckState
                Cmd.Parameters.AddWithValue("@Seller", SqlDbType.Bit).Value = Chkseller.CheckState
                Cmd.Parameters.AddWithValue("@Other", SqlDbType.Bit).Value = Chkother.CheckState
                Cmd.Parameters.AddWithValue("@GValue", SqlDbType.Bit).Value = ChkMon.CheckState
                Cmd.Parameters.AddWithValue("@GValueMon", SqlDbType.BigInt).Value = CDbl(TxtMoney.Text)
                Cmd.Parameters.AddWithValue("@AllMoney", SqlDbType.BigInt).Value = CDbl(Txtallmoney.Text)
                Cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = CmbState.Text.Trim
                Cmd.Parameters.AddWithValue("@Rate", SqlDbType.BigInt).Value = CLng(Txtdelay.Text)
                Cmd.Parameters.AddWithValue("@NamCo", SqlDbType.NVarChar).Value = Txtco.Text.Trim
                Cmd.Parameters.AddWithValue("@NamFac", SqlDbType.NVarChar).Value = Txtfac.Text.Trim
                Cmd.Parameters.AddWithValue("@IdOstan", SqlDbType.BigInt).Value = CLng(TxtOstanP.Text)
                Cmd.Parameters.AddWithValue("@IdCity", SqlDbType.BigInt).Value = CLng(TxtCityP.Text)
                Cmd.Parameters.AddWithValue("@IdPart", SqlDbType.BigInt).Value = CLng(TxtPartP.Text)
                Cmd.Parameters.AddWithValue("@Activ", SqlDbType.Bit).Value = False
                Cmd.Parameters.AddWithValue("@ChkIdGroup", SqlDbType.Bit).Value = True
                Cmd.Parameters.AddWithValue("@IdGroup", SqlDbType.BigInt).Value = CLng(TxtGroup.Text)
                Cmd.Parameters.AddWithValue("@D_Dat", SqlDbType.NVarChar).Value = TxtDate.ThisText
                Cmd.Parameters.AddWithValue("@MCode", SqlDbType.NVarChar).Value = TxtCode.Text.Trim
                Idp = Cmd.ExecuteScalar
            End Using

            Using Cmd As New SqlCommand("UPDATE Mobile_ListFactorSell SET [Confirm]=0,IdName=@IdName,IdNewPeople=@IdNewPeople WHERE IdNewPeople=" & Id, ConectionBank)
                Cmd.Parameters.AddWithValue("@IdName", SqlDbType.BigInt).Value = Idp
                Cmd.Parameters.AddWithValue("@IdNewPeople", SqlDbType.BigInt).Value = DBNull.Value
                Cmd.ExecuteNonQuery()
            End Using


            Using Cmd As New SqlCommand("DELETE FROM Mobile_NewPeople WHERE Id=" & Id, ConectionBank)
                Cmd.ExecuteNonQuery()
            End Using

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            MessageBox.Show("طرف حساب با کد " & Idp & " در سیستم ثبت شد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تعریف طرف حساب موقت", "تایید", "ثبت طرف حساب موقت :" & Txtname.Text, "")

            Return True

        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات قابل ذخیره شدن نیست لطفا این پنجره را بسته و دوباره امتحان کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_AddPeople", "SavePeople")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Private Sub TxtAdres_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then BtnAdd.Focus()
    End Sub

    Private Sub TxtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then CmbGroup.Focus()
    End Sub
End Class