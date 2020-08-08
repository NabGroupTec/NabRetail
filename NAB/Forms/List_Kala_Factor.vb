Imports System.Data.SqlClient
Public Class List_Kala_Factor

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
    End Sub

    Private Sub List_Kala_Factor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DGV1.Focus()
    End Sub
    Private Sub FrmFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "DecFactor.htm")
        ElseIf e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Enter Then
            If BtnOk.Enabled = True Then BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnExit.Enabled = True Then BtnExit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            ShowKalafactor()
        End If
    End Sub

    Private Sub ShowKalafactor()
        Try
            Dim ds As New DataSet
            Dim dta As New SqlDataAdapter
            ds.Clear()
            If Not dta Is Nothing Then dta.Dispose()
            dta = New SqlDataAdapter("SELECT  KalaFactorSell.IdKala As Id ,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe,KalaFactorSell.DarsadDiscount , KalaFactorSell.DarsadMon, KalaFactorSell.Mon, Define_Kala.Nam as NamKala,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ , Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id  INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  WHERE ListFactorSell.IdFactor =" & CLng(LFactor.Text), DataSource)
            dta.Fill(ds)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = ds.Tables(0)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "List_kala_Factor", "ShowKalaFactor")
        End Try
    End Sub

    Private Sub ShowFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        IdKala = 0
        DK = False
        DK_JOZ = 0
        DK_KOL = 0
        Tmp_Namkala = ""
        Tmp_OneGroup = ""
        Tmp_TwoGroup = ""
        TmpVahed = ""
        Tmp_String1 = ""
        Tmp_String2 = ""
        TmpTell1 = ""
        TmpTell2 = ""
        ShowKalafactor()
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV1.Sort(DGV1.Columns("Cln_Name"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
   
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try

            If DGV1.RowCount > 0 Then
                IdKala = CLng(DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value.ToString)
                Tmp_Namkala = DGV1.Item("cln_name", DGV1.CurrentRow.Index).Value.ToString
                Tmp_OneGroup = DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value.ToString
                Tmp_Mon = CDbl(DGV1.Item("Cln_Money", DGV1.CurrentRow.Index).Value)
                Tmp_String1 = CDbl(DGV1.Item("Cln_DarsadMon", DGV1.CurrentRow.Index).Value)
                Tmp_String2 = CDbl(DGV1.Item("Cln_Fe", DGV1.CurrentRow.Index).Value)
                TmpTell1 = CDbl(Replace(DGV1.Item("Cln_KolCount", DGV1.CurrentRow.Index).Value, "/", "."))
                TmpTell2 = CDbl(Replace(DGV1.Item("Cln_JozCount", DGV1.CurrentRow.Index).Value, "/", "."))
                Tmp_TwoGroup = CDbl(Replace(DGV1.Item("Cln_Darsad", DGV1.CurrentRow.Index).Value, "/", "."))
                DK = DGV1.Item("Cln_Dk", DGV1.CurrentRow.Index).Value
                If DK = True Then
                    DK_JOZ = DGV1.Item("Cln_Joz", DGV1.CurrentRow.Index).Value
                    DK_KOL = DGV1.Item("Cln_Kol", DGV1.CurrentRow.Index).Value
                Else
                    DK_JOZ = 0
                    DK_KOL = 0
                End If
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            DK = False
            DK_JOZ = 0
            DK_KOL = 0
            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            Tmp_TwoGroup = ""
            TmpVahed = ""
            Tmp_String1 = ""
            Tmp_String2 = ""
            TmpTell1 = ""
            TmpTell2 = ""
            Me.Close()
        End Try
    End Sub
End Class