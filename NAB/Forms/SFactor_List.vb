Imports System.Data.SqlClient

Public Class SFactor_List

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub TxtIDFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIDFac.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
        If e.KeyCode = Keys.Delete Then e.Handled = True
        If e.KeyCode = Keys.Back Then e.Handled = True
    End Sub

    Private Sub TxtIDFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIDFac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Factor_List
        frmlk.str = "SELECT ListFactorSell.IdFactor, ListFactorSell.D_date,ListFactorSell.IdName,ListFactorSell.IdVisitor, Define_People.Nam FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE ListFactorSell.Stat =3 AND ListFactorSell.Activ =1"
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtIDFac.Focus()
        If IdKala <> 0 Then
            ShowKalafactor(IdKala)
            CalculateMoney()
            TxtDate.Text = Tmp_String1
            TxtPeople.Text = Tmp_Namkala
            TxtIdName.Text = Tmp_String2
            TxtIDFac.Text = IdKala
            TxtIdVisitor.Text = Tmp_TwoGroup
        End If
    End Sub


    Private Sub CalculateMoney()
        Dim allmoney As Double = 0
        Dim alldarsad As Double = 0
        For i As Integer = 0 To DGV1.Rows.Count - 1
            allmoney += CDbl(DGV1.Item("cln_Money", i).Value)
            alldarsad += CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
        Next
        If alldarsad.ToString.Length > 3 Then
            TxtMonFac.Text = Format(alldarsad, "###,###")
        Else
            TxtMonFac.Text = alldarsad
        End If

        If allmoney.ToString.Length > 3 Then
            Txtallmoney.Text = Format(allmoney, "###,###")
        Else
            Txtallmoney.Text = allmoney
        End If
    End Sub

    Private Sub FrmKasriFactor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtIDFac.Focus()
    End Sub


    Private Sub FrmKasriFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmKasriFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Array.Resize(SFactorArray, 0)
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BtnSave.Focus()
            DGV1.EndEdit()
            Me.Enabled = False
            '''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(TxtIDFac.Text.Trim) Then
                MessageBox.Show("شماره فاکتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                TxtIDFac.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(Txtallmoney.Text.Trim) Then
                MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            Else
                If CDbl(Txtallmoney.Text) <= 0 Then
                    MessageBox.Show("جمع مبلغ فاکتور صفر است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If

            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ کالایی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If

            Array.Resize(SFactorArray, 0)
            For i As Integer = 0 To DGV1.RowCount - 1
                If CBool(DGV1.Item("Cln_Select", i).Value) = True Then
                    Array.Resize(SFactorArray, SFactorArray.Length + 1)
                    SFactorArray(SFactorArray.Length - 1).GroupKala = DGV1.Item("cln_type", i).Value
                    SFactorArray(SFactorArray.Length - 1).NamKala = DGV1.Item("Cln_name", i).Value
                    SFactorArray(SFactorArray.Length - 1).KolCount = CDbl(DGV1.Item("Cln_KolCount", i).Value)
                    SFactorArray(SFactorArray.Length - 1).JozCount = CDbl(DGV1.Item("Cln_JozCount", i).Value)
                    SFactorArray(SFactorArray.Length - 1).NamVahed = DGV1.Item("Cln_Vahed", i).Value
                    SFactorArray(SFactorArray.Length - 1).Fe = CDbl(DGV1.Item("Cln_Fe", i).Value)
                    SFactorArray(SFactorArray.Length - 1).DarsadDiscount = CDbl(DGV1.Item("Cln_Darsad", i).Value)
                    SFactorArray(SFactorArray.Length - 1).DarsadMon = CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                    SFactorArray(SFactorArray.Length - 1).NamAnbar = DGV1.Item("Cln_Anbar", i).Value
                    SFactorArray(SFactorArray.Length - 1).Mon = CDbl(DGV1.Item("cln_Money", i).Value)
                    SFactorArray(SFactorArray.Length - 1).IdKala = CLng(DGV1.Item("Cln_Code", i).Value)
                    SFactorArray(SFactorArray.Length - 1).DK = CBool(DGV1.Item("Cln_DK", i).Value)
                    SFactorArray(SFactorArray.Length - 1).DK_KOL = CDbl(DGV1.Item("Cln_KOL", i).Value)
                    SFactorArray(SFactorArray.Length - 1).DK_JOZ = CDbl(DGV1.Item("Cln_JOZ", i).Value)
                    SFactorArray(SFactorArray.Length - 1).CodeAnbar = CLng(DGV1.Item("Cln_CodeAnbar", i).Value)
                End If
            Next

            If SFactorArray.Length <= 0 Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If

            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SFactor_List", "BtnSave_Click")
            Me.Enabled = True
        End Try
    End Sub

   
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "BackFrosh.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancle.Enabled = True Then BtnCancle_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ShowKalafactor(ByVal idfac As Long)
        Try
            DGV1.DataSource = Nothing
            Dim ds As New DataSet
            Dim dta As New SqlDataAdapter
            ds.Clear()
            If Not dta Is Nothing Then dta.Dispose()
            dta = New SqlDataAdapter("SELECT  KalaFactorSell.IdKala As Id ,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe,KalaFactorSell.DarsadDiscount , KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.IdAnbar,Define_Anbar.nam  As NamAnbar, Define_Kala.Nam as NamKala,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ , Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id  INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Anbar On KalaFactorSell.IdAnbar =Define_Anbar.ID INNER JOIN Define_Vahed ON Define_Vahed.Id =Define_Kala .IdVahed WHERE ListFactorSell.IdFactor =" & idfac, DataSource)
            dta.Fill(ds)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = ds.Tables(0)
            ChkAll.Checked = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SFactor_List", "ShowKalaFactor")
        End Try
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV1.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV1.RowCount - 1
            DGV1.Item("Cln_Select", i).Value = ChkAll.CheckState
        Next
    End Sub

    Private Sub TxtIDFac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIDFac.TextChanged

    End Sub
End Class