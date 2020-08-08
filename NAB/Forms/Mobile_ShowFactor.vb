Imports System.Data.SqlClient
Public Class Mobile_ShowFactor
    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
        If CDbl(DGV1.Item("Cln_Darsad", e.RowIndex).Value) >= 100 Then
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.SpringGreen
        Else
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Nothing
            DGV1.Rows(e.RowIndex).Cells("cln_type").Style.BackColor = Color.Gainsboro
            DGV1.Rows(e.RowIndex).Cells("Cln_Vahed").Style.BackColor = Color.Gainsboro
            DGV1.Rows(e.RowIndex).Cells("Cln_DarsadMon").Style.BackColor = Color.Gainsboro
            DGV1.Rows(e.RowIndex).Cells("cln_Money").Style.BackColor = Color.Gainsboro
        End If
    End Sub
    Private Sub FrmFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            ShowKalafactor()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "FactMobail.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnShowfactor.Enabled = True Then Call BtnShowfactor_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            Try
              
                If LIdName.Text = "0" Or String.IsNullOrEmpty(LIdName.Text) Then
                    MessageBox.Show("طرف حساب مربوطه تایید نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Me.Enabled = False
                Using FValue As New FrmValue
                    FValue.LCode.Text = LIdName.Text
                    FValue.ShowDialog()
                End Using
                Me.Enabled = True
            Catch ex As Exception
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ShowFactor", "GetKey(F6)")
                Me.Enabled = True
            End Try
        End If
    End Sub
    Private Sub ShowKalafactor()
        Try
            Dim Query As String = ""
            If BtnShowfactor.Text = "نمایش فاکتور فروش" Then
                Query = "SELECT  Mobile_KalaFactorSell.ID,Mobile_KalaFactorSell.IdKala,Mobile_KalaFactorSell.KolCount, Mobile_KalaFactorSell.JozCount,Mobile_KalaFactorSell.Fe,Mobile_KalaFactorSell.Discount AS DarsadDiscount,DarsadMon=0,Mon=0,KalaDisc=N'',Define_Kala.Nam as NamKala,NamAnbar=N'', Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  Mobile_ListFactorSell INNER JOIN Mobile_KalaFactorSell ON Mobile_ListFactorSell.IdFactor = Mobile_KalaFactorSell.IdFactor INNER JOIN Define_Kala ON Mobile_KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE Mobile_ListFactorSell.IdFactor =" & CLng(LState.Text) & " ORDER BY Mobile_KalaFactorSell.ID"
            Else
                Query = "SELECT  KalaFactorSell.ID,KalaFactorSell.IdKala,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor =" & CLng(LFactor.Text) & " UNION ALL SELECT KalaFactorSell.ID,KalaFactorSell.IdService As IdKala,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorSell.ID"
            End If
            Dim ds As New DataSet
            Dim dta As New SqlDataAdapter
            ds.Clear()
            If Not dta Is Nothing Then dta.Dispose()
            dta = New SqlDataAdapter(Query, DataSource)
            dta.Fill(ds)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = ds.Tables(0)
            CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Mobile_ShowFactor", "ShowKalaFactor")
        End Try
    End Sub

    Private Sub ShowFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        ShowKalafactor()
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV1.Sort(DGV1.Columns("Cln_Name"), System.ComponentModel.ListSortDirection.Ascending)
        If LFactor.Text = "0" Or String.IsNullOrEmpty(LFactor.Text) Then BtnShowfactor.Enabled = False
        DGV1.Columns("Cln_DarsadMon").Visible = False
        DGV1.Columns("Cln_Anbar").Visible = False
        DGV1.Columns("cln_Money").Visible = False
        DGV1.Columns("Cln_Disc").Visible = False
        Label6.Visible = False
        Label8.Visible = False
        TxtMonFac.Visible = False
        Txtallmoney.Visible = False
        BtnShowfactor.Text = "نمایش فاکتور فروش"
        ToolFrosh.Text = "F2 نمایش فاکتور فروش"
    End Sub
    Private Sub CalculateMon()
        Try
            TxtMonFac.Text = 0
            Txtallmoney.Text = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("cln_Money", i).Value)
            Next
            If TxtMonFac.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonFac.Text.Replace(",", ""))
                TxtMonFac.Text = Format$(Val(Str), "###,###,###")
            End If
            If Txtallmoney.Text.Length > 3 Then
                Dim Str As String = Format$(Txtallmoney.Text.Replace(",", ""))
                Txtallmoney.Text = Format$(Val(Str), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnShowfactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowfactor.Click
        If BtnShowfactor.Text = "نمایش فاکتور فروش" Then
            DGV1.Columns("Cln_Fe").Visible = True
            DGV1.Columns("Cln_Darsad").Visible = True
            DGV1.Columns("Cln_DarsadMon").Visible = True
            DGV1.Columns("Cln_Anbar").Visible = True
            DGV1.Columns("cln_Money").Visible = True
            DGV1.Columns("Cln_Disc").Visible = True
            Label6.Visible = True
            Label8.Visible = True
            TxtMonFac.Visible = True
            Txtallmoney.Visible = True
            BtnShowfactor.Text = "نمایش فاکتور موبایل"
            ToolFrosh.Text = "F2 نمایش فاکتور موبایل"
        Else
            DGV1.Columns("Cln_DarsadMon").Visible = False
            DGV1.Columns("Cln_Anbar").Visible = False
            DGV1.Columns("cln_Money").Visible = False
            DGV1.Columns("Cln_Disc").Visible = False
            Label6.Visible = False
            Label8.Visible = False
            TxtMonFac.Visible = False
            Txtallmoney.Visible = False
            BtnShowfactor.Text = "نمایش فاکتور فروش"
            ToolFrosh.Text = "F2 نمایش فاکتور فروش"
        End If
        Me.ShowKalafactor()
    End Sub
End Class