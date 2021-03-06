﻿Imports System.Data.SqlClient
Imports System.Transactions
Public Class ListRelationUser_One

    Dim ds As New DataSet
    Dim str As String = "SELECT  ListUser_OG.IdUser, Define_User.Nam FROM ListUser_OG INNER JOIN Define_User ON ListUser_OG.IdUser = Define_User.Id"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource

    Dim dsD As New DataSet
    Dim strD As String = ""
    Dim dtaD As New SqlDataAdapter()
    Dim bsD As New BindingSource

    Dim dsO As New DataSet
    Dim strO As String = ""
    Dim dtaO As New SqlDataAdapter()
    Dim bsO As New BindingSource

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_DDgv(CLng(DGV1.Item("Cln_Code", e.RowIndex).Value))
        Catch ex As Exception
            DGV2.DataSource = Nothing
        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub DGV3_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.RowEnter
        Try
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV4.DataSource = Nothing
            Fill_KDgv(CLng(DGV3.Item("Cln_IdVisit", e.RowIndex).Value))
            Fill_ODgv(CLng(DGV3.Item("Cln_IdVisit", e.RowIndex).Value))
        Catch ex As Exception
            DGV1.DataSource = Nothing
            DGV2.DataSource = Nothing
            DGV4.DataSource = Nothing
        End Try
    End Sub

    Private Sub Fill_KDgv(ByVal Idvisit As Long)
        Try
            DGV1.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT REPLACE(ListkalaU_OG.Kala,'.','/') As Kala , ListkalaU_OG.Mon,ListkalaU_OG.IdKala,ListkalaU_OG.Id,Define_OneGroup.NamOne As nam FROM ListkalaU_OG INNER JOIN Define_OneGroup  ON ListkalaU_OG.Idkala = Define_OneGroup.Id  WHERE IdLinkUser =" & Idvisit
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "ListkalaU_OG")
            DGV1.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "ListkalaU_OG"
            DGV1.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListRelationUser_One", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub Fill_DDgv(ByVal Idvisit As Long)
        Try
            DGV2.DataSource = Nothing
            dsD.Clear()
            strD = "SELECT REPLACE(ListDarsadU_OG.Frosh,'.','/') As Frosh, REPLACE(ListDarsadU_OG.Darsad,'.','/') AS Darsad, Define_Group_P.nam,ListDarsadU_OG.IdGroup FROM ListDarsadU_OG INNER JOIN Define_Group_P ON ListDarsadU_OG.IdGroup = Define_Group_P.Id WHERE IdlinkKala =" & Idvisit
            If Not dtaD Is Nothing Then
                dtaD.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaD = New SqlDataAdapter(strD, DataSource)
            dtaD.Fill(dsD, "ListDarsadU_OG")
            DGV2.AutoGenerateColumns = False
            bsD.DataSource = dsD
            bsD.DataMember = "ListDarsadU_OG"
            DGV2.DataSource = bsD
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListRelationUser_One", "fill_Ddgv")
            Me.Close()
        End Try
    End Sub

    Private Sub Fill_ODgv(ByVal Idvisit As Long)
        Try
            DGV4.DataSource = Nothing
            dsO.Clear()
            strO = "SELECT  REPLACE(ListOrderDarsadU_OG.Darsad,'.','/') As Darsad, Define_Group_P.nam,IdGroup FROM ListOrderDarsadU_OG INNER JOIN Define_Group_P ON ListOrderDarsadU_OG.IdGroup = Define_Group_P.Id WHERE IdLinkUser =" & Idvisit
            If Not dtaO Is Nothing Then
                dtaO.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaO = New SqlDataAdapter(strO, DataSource)
            dtaO.Fill(dsO, "ListOrderDarsadU_OG")
            DGV4.AutoGenerateColumns = False
            bsO.DataSource = dsO
            bsO.DataMember = "ListOrderDarsadU_OG"
            DGV4.DataSource = bsO
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListRelationUser_One", "Fill_ODgv")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV3.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV3.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV3.DefaultCellStyle.Font, b, DGV3.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV3.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV3.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub RelationListVisitorFrosh_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
    End Sub

    Private Sub RelationListVisitorFrosh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub RelationListVisitorFrosh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Array.Resize(ListKala, 0)
        Array.Resize(ListDarsad, 0)
        Array.Resize(ListODarsad, 0)
        Me.Fill_Dgv()
        DGV1.Columns("cln_type").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns("Cln_NameV").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV4.Columns("Cln_Group2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub Fill_Dgv()
        Try
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "ListUser_OG")
            DGV3.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "ListUser_OG"
            DGV3.DataSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListRelationUser_One", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub RefreshBank()
        Try
            DGV2.DataSource = Nothing
            DGV1.DataSource = Nothing
            ds.Clear()
            dta.Fill(ds, "ListUser_OG")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ListRelationUser_One", "RefreshBank")
            Me.Close()
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ByAsliKalaUser.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSelect.Enabled = True Then BtnSelect_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then BtnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DGV4_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV4.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV4.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV4.DefaultCellStyle.Font, b, DGV4.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV4.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV4.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Array.Resize(ListKala, 0)
        Array.Resize(ListDarsad, 0)
        Array.Resize(ListODarsad, 0)

        For i As Integer = 0 To DGV1.RowCount - 1
            Array.Resize(ListKala, ListKala.Length + 1)
            ListKala(ListKala.Length - 1).NamKala = DGV1.Item("cln_type", i).Value
            ListKala(ListKala.Length - 1).Mon = CDbl(DGV1.Item("Cln_HightMon", i).Value)
            ListKala(ListKala.Length - 1).Hajm = DGV1.Item("Cln_HightKala", i).Value
            ListKala(ListKala.Length - 1).Idkala = DGV1.Item("Cln_Idkala", i).Value
        Next

        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
        Dim dt As New DataTable
        For i As Integer = 0 To DGV1.RowCount - 1
            dt.Clear()
            Using CMD As New SqlCommand("SELECT REPLACE(ListDarsadU_OG.Frosh,'.','/') As Frosh, REPLACE(ListDarsadU_OG.Darsad,'.','/') AS Darsad, Define_Group_P.nam,ListDarsadU_OG.IdGroup FROM ListDarsadU_OG INNER JOIN Define_Group_P ON ListDarsadU_OG.IdGroup = Define_Group_P.Id WHERE IdlinkKala =" & CLng(DGV1.Item("Cln_Code", i).Value), ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            For k As Integer = 0 To dt.Rows.Count - 1
                Array.Resize(ListDarsad, ListDarsad.Length + 1)
                ListDarsad(ListDarsad.Length - 1).Frosh = dt.Rows(k).Item("Frosh")
                ListDarsad(ListDarsad.Length - 1).Darsad = dt.Rows(k).Item("Darsad")
                ListDarsad(ListDarsad.Length - 1).Group = dt.Rows(k).Item("Nam")
                ListDarsad(ListDarsad.Length - 1).IdGroup = dt.Rows(k).Item("IdGroup")
                ListDarsad(ListDarsad.Length - 1).row = i
            Next k
        Next i
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        For i As Integer = 0 To DGV4.RowCount - 1
            Array.Resize(ListODarsad, ListODarsad.Length + 1)
            ListODarsad(ListODarsad.Length - 1).Darsad = DGV4.Item("Cln_Darsad2", i).Value
            ListODarsad(ListODarsad.Length - 1).Group = DGV4.Item("Cln_Group2", i).Value
            ListODarsad(ListODarsad.Length - 1).IdGroup = DGV4.Item("Cln_IdG2", i).Value
        Next
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Array.Resize(ListKala, 0)
        Array.Resize(ListDarsad, 0)
        Array.Resize(ListODarsad, 0)
        Me.Close()
    End Sub
End Class