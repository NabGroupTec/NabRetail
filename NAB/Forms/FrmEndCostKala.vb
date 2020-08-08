Imports System.Data.SqlClient

Public Class FrmEndCostKala
    Dim d_ds As New DataSet
    Dim d_dta As New SqlDataAdapter

    Private Sub FileCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FileCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        TxtCount.Text = 3
        GetFactor()
        DGV2.Columns("Cln_People").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetFactor()
        Try
            Dim str As String = ""
            str = "SELECT Nam,D_date ,IdFactor ,JozCount ,KolCount ,Fe1 ,Fe2 ,EndCost=CASE WHEN MonFac =0 or MonCharge =0 THEN Fe2  ELSE ROUND(((((Fe1 * Case  WHEN JozCount <=0 THEN KolCount else JozCount end )*MonCharge)/MonFac))/(Case  WHEN JozCount <=0 THEN KolCount else JozCount end)+Fe2 ,0)  END FROM (SELECT Nam,D_date ,IdFactor ,JozCount ,KolCount ,Fe As Fe1,ISNULL((Fe-(DarsadMon /(Case  WHEN JozCount>0 THEN JozCount ELSE KolCount END))),0) AS Fe2 ,(SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =AllK.IdFactor  AND ListFactorCharge.Activ =1) As MonCharge,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =AllK.IdFactor) As MonFac FROM (SELECT TOP " & CLng(TxtCount.Text) & " * FROM(SELECT KolCount ,JozCount ,Fe,DarsadMon,ListKala.IdFactor ,D_date,Nam FROM (SELECT  KalaFactorBuy .KolCount ,KalaFactorBuy .JozCount ,Fe,DarsadMon,KalaFactorBuy .IdFactor  FROM KalaFactorBuy  WHERE  KalaFactorBuy .IdKala =" & CLng(Lidkala.Text) & " AND KalaFactorBuy .Activ =1 ) As ListKala INNER JOIN ListFactorBuy  On ListFactorBuy .IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBuy .IdName UNION ALL SELECT  Count_Kol As KolCount, Count_Joz As JozCount, Fe,DarsadMon=0,IdFactor=0, D_date,Nam=N'موجودی اول دوره' FROM Define_PrimaryKala WHERE IdKala=" & CLng(Lidkala.Text) & " )AS EndKala  ORDER BY D_date   DESC) As AllK) As AllK2"
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
                Tallmonk.Text = 0
                Exit Sub
            End If

            Dim AllEndMon As Double = 0
            Dim AllMon As Double = 0
            Dim Count As Double = 0

            For i As Integer = 0 To DGV2.RowCount - 1
                If CDbl(DGV2.Item("Cln_Joz", i).Value) > 0 Then
                    AllEndMon += CDbl(DGV2.Item("Cln_Joz", i).Value) * CDbl(DGV2.Item("Cln_EndFe", i).Value)
                    AllMon += CDbl(DGV2.Item("Cln_Joz", i).Value) * CDbl(DGV2.Item("Cln_Sell", i).Value)
                    Count += CDbl(DGV2.Item("Cln_Joz", i).Value)
                Else
                    AllEndMon += CDbl(DGV2.Item("Cln_Kol", i).Value) * CDbl(DGV2.Item("Cln_EndFe", i).Value)
                    AllMon += CDbl(DGV2.Item("Cln_Kol", i).Value) * CDbl(DGV2.Item("Cln_Sell", i).Value)
                    Count += CDbl(DGV2.Item("Cln_Kol", i).Value)
                End If
            Next

            If AllEndMon > 0 Then
                Tallmonw.Text = Format(CDbl(AllEndMon / Count), "###,###")
            Else
                Tallmonw.Text = 0
            End If

            If AllMon > 0 Then
                Tallmonk.Text = Format(CDbl(AllMon / Count), "###,###")
            Else
                Tallmonk.Text = 0
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEndCostKala", "GetFactor")
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
        If TxtCount.Text = "" Or Lidkala.Text = "" Then Exit Sub
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

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub
End Class