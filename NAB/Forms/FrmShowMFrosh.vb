Imports System.Data.SqlClient

Public Class FrmShowMFrosh
    Public Query As String
    Public PeopleQuery As String
    Public PeopleQuery2 As String
    Dim Tmpostan As String
    Private Sub Getdata()
        Try
            Me.Enabled = False
            Dim Ds As New DataTable
            Ds.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Query, ConectionBank)
                cmd.CommandTimeout = 0
                Ds.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGVX.DataSource = Ds
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowMFrosh", "Getdata")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub FrmShowMFrosh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmShowMFrosh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Getdata()
    End Sub

    Private Sub GetListPeople(ByVal IdOstan As Long, ByVal IdCity As Long, ByVal IdPart As Long)
        Try
            Me.Enabled = False
            Dim Ds As New DataTable

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PeopleQuery & "IdOstan =" & IdOstan & " AND IdCity =" & IdCity & " AND IdPart =" & IdPart & PeopleQuery2 & ") As ListOstan", ConectionBank)
                cmd.CommandTimeout = 0
                Ds.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GridEX1.DataSource = Ds
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowMFrosh", "GetListPeople")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub GetListPeople(ByVal IdOstan As Long)
        Try
            If IdOstan = -1 Then
                GridEX1.DataSource = Nothing
                Exit Sub
            End If

            Me.Enabled = False
            Dim Ds As New DataTable

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PeopleQuery & "IdOstan =" & IdOstan & PeopleQuery2 & ") As ListOstan", ConectionBank)
                cmd.CommandTimeout = 0
                Ds.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GridEX1.DataSource = Ds
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowMFrosh", "GetListPeople")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub GetListPeople(ByVal IdOstan As Long, ByVal IdCity As Long)
        Try
            Me.Enabled = False
            Dim Ds As New DataTable

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PeopleQuery & "IdOstan =" & IdOstan & " AND IdCity =" & IdCity & PeopleQuery2 & ") As ListOstan", ConectionBank)
                cmd.CommandTimeout = 0
                Ds.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GridEX1.DataSource = Ds
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowMFrosh", "GetListPeople")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub DGVX_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVX.SelectionChanged
        GridEX1.DataSource = Nothing

        If Not (DGVX.GetRow().Cells("IdPart").Value Is DBNull.Value Or String.IsNullOrEmpty(DGVX.GetRow().Cells("IdPart").Value)) Then
            GetListPeople(DGVX.GetRow().Cells("IdOstan").Value, DGVX.GetRow().Cells("Idcity").Value, DGVX.GetRow().Cells("IdPart").Value)
        Else
            If Chkostan.Checked = True Then
                If DGVX.GetRow().Group.HeaderCaption = "استان" Then
                    Tmpostan = DGVX.GetRow().GroupCaption.ToString
                    GetListPeople(Me.GetNamOstan(DGVX.GetRow().GroupCaption.ToString))
                ElseIf DGVX.GetRow().Group.HeaderCaption = "شهرستان" Then
                    Me.GetNamCity(Tmpostan, DGVX.GetRow().GroupCaption.ToString)
                    GetListPeople(TxtIdOstan, TxtIdCity)
                End If
            End If
        End If

    End Sub

    Private Function GetNamOstan(ByVal Ostan As String) As Long
        Try

            Dim id As Object = Nothing

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Code  FROM Define_Ostan WHERE NamO=N'" & Ostan & "'", ConectionBank)
                cmd.CommandTimeout = 0
                id = cmd.ExecuteScalar()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return If(id Is DBNull.Value, -1, CLng(id))

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowMFrosh", "GetNamOstan")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Private Sub GetNamCity(ByVal Ostan As String, ByVal City As String)
        Try
            If String.IsNullOrEmpty(Ostan) Or String.IsNullOrEmpty(City) Then
                GridEX1.DataSource = Nothing
                Exit Sub
            End If

            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("SELECT Define_Ostan.Code As IdOstan, Define_City.Code AS IdCity FROM  Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan WHERE NamO =N'" & Ostan & "' AND NamCI =N'" & City & "'", ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using


            If dt.Rows.Count > 0 Then
                TxtIdOstan = dt.Rows(0).Item("IdOstan")
                TxtIdCity = dt.Rows(0).Item("IdCity")
            Else
                Dim Newdt As New DataTable

                Using cmd As New SqlCommand("SELECT Define_Ostan.Code As IdOstan, Define_City.Code AS IdCity FROM  Define_Ostan INNER JOIN Define_City ON Define_Ostan.Code = Define_City.IdOstan WHERE  NamCI =N'" & City & "'", ConectionBank)
                    cmd.CommandTimeout = 0
                    Newdt.Load(cmd.ExecuteReader)
                End Using

                If Newdt.Rows.Count > 0 Then
                    TxtIdOstan = Newdt.Rows(0).Item("IdOstan")
                    TxtIdCity = Newdt.Rows(0).Item("IdCity")
                Else
                    TxtIdOstan = -1
                    TxtIdCity = -1
                End If
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmShowMFrosh", "GetNamCity")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepManageBazar.htm")
        ElseIf e.KeyCode = Keys.F5 Then
            Me.Getdata()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class