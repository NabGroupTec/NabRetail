Imports System.Data.SqlClient

Public Class FileCustomer
    Dim d_ds As New DataSet
    Dim d_dta As New SqlDataAdapter

    Private Sub FileCustomer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        CmbFac.Focus()
    End Sub

    Private Sub FileCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FileCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        TxtCount.Text = 3
        GetFactor()
        DGV2.Columns("Cln_Sell").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetFactor()
        Try
            Dim ListName As String = GetTableNameFactor(CLng(LState.Text), "LIST")
            Dim KalaName As String = GetTableNameFactor(CLng(LState.Text), "KALA")
            Dim str As String = ""
            If LState.Text = "8" Then
                str = "SELECT TOP " & CLng(TxtCount.Text) & " KolCount ,JozCount ,Fe,ListKala.IdFactor ,D_date FROM (SELECT  " & KalaName & ".KolCount ,(0) as JozCount ," & KalaName & ".Fe," & KalaName & ".IdFactor  FROM " & KalaName & " WHERE  " & KalaName & ".IdService  =" & CLng(Lidkala.Text) & " AND " & KalaName & ".Activ =1 ) As ListKala INNER JOIN  " & ListName & " On " & ListName & ".IdFactor =ListKala .IdFactor WHERE " & ListName & " .IdName =" & CLng(Lidname.Text) & " ORDER BY D_date DESC"
            Else
                str = "SELECT TOP " & CLng(TxtCount.Text) & " KolCount ,JozCount ,Fe,ListKala.IdFactor ,D_date FROM (SELECT  " & KalaName & ".KolCount ," & KalaName & ".JozCount ," & KalaName & ".Fe," & KalaName & ".IdFactor  FROM " & KalaName & " WHERE  " & KalaName & If(LKala.Text = "SERVICE", ".IdService=", ".IdKala =") & CLng(Lidkala.Text) & " AND " & KalaName & ".Activ =1 ) As ListKala INNER JOIN " & ListName & " On " & ListName & ".IdFactor =ListKala .IdFactor WHERE " & ListName & ".IdName =" & CLng(Lidname.Text) & " ORDER BY D_date DESC"
            End If
            '''''''''''''''''''''''''''
            d_ds.Clear()
            If Not d_dta Is Nothing Then
                d_dta.Dispose()
            End If
            d_dta = New SqlDataAdapter(str, DataSource)
            d_dta.Fill(d_ds)
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = d_ds.Tables(0)
            DGV2.Sort(DGV2.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            If DGV2.RowCount <= 0 Then
                Tallmonw.Text = 0
                Exit Sub
            End If
            Dim Onemon As Double = 0
            Dim i As Integer = 0
            For i = 0 To DGV2.RowCount - 1
                Onemon += CDbl(DGV2.Item("Cln_Sell", i).Value)
            Next
            If Onemon > 0 Then
                Tallmonw.Text = Format(CDbl(Onemon / i), "###,###")
            Else
                Tallmonw.Text = 0
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FileCustomer", "GetFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub TxtCount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCount.KeyDown
        If e.KeyCode = Keys.Enter Then Call Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCount.KeyPress
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

    Private Sub TxtCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCount.TextChanged
        If Not (CheckDigitWithOutpoint(Format$(TxtCount.Text.Replace(",", "")))) Then
            TxtCount.Text = 3
        Else
            If CLng(TxtCount.Text) <= 0 Then
                TxtCount.Text = 3
            End If
        End If
        Call Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtCount.Text = "" Or LState.Text = "" Or Lidkala.Text = "" Or Lidname.Text = "" Then Exit Sub
        Me.GetFactor()
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Factor_Sell.htm")
        ElseIf e.KeyCode = Keys.F5 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CmbFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbFac.KeyDown
        If CmbFac.DroppedDown = False Then
            CmbFac.DroppedDown = True
        End If
    End Sub

    Private Sub CmbFac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFac.SelectedIndexChanged
        LState.Text = GetStateFactor(CmbFac.Text)
        If TxtCount.Text = "" Or LState.Text = "" Or Lidkala.Text = "" Or Lidname.Text = "" Then
            Tallmonw.Text = "0"
            Exit Sub
        End If
        Me.GetFactor()
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
End Class