Imports System.Data.SqlClient

Public Class FrmFormulasSearch
    Dim ROW As Integer
    Dim ds As New DataSet
    Dim str As String = "SELECT Id,CodeFormul,FormulName,D_Date FROM FormulaMaster"
    Dim dta As New SqlDataAdapter()
    Dim bs As New BindingSource
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dsK As New DataSet
    Dim strK As String = ""
    Dim dtaK As New SqlDataAdapter()
    Dim bsK As New BindingSource

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub DGV_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowEnter
        Try
            DGV2.DataSource = Nothing
            Fill_KDgv(CLng(DGV.Item("Cln_Id", e.RowIndex).Value))
        Catch ex As Exception
            DGV2.DataSource = Nothing
        End Try
    End Sub
    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub Fill_Dgv()
        Try
            DGV.DataSource = Nothing
            DGV2.DataSource = Nothing
            ds.Clear()
            If Not dta Is Nothing Then
                dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta = New SqlDataAdapter(str, DataSource)
            dta.Fill(ds, "FormulaMaster")
            DGV.AutoGenerateColumns = False
            bs.DataSource = ds
            bs.DataMember = "FormulaMaster"
            DGV.DataSource = bs
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFormulasSearch", "fill_dgv")
            Me.Close()
        End Try
    End Sub
    Private Sub Fill_KDgv(ByVal Id As Long)
        Try
            DGV2.DataSource = Nothing
            dsK.Clear()
            strK = "SELECT  Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ,FormulaDetails.Id,FormulaDetails.IdKala ,FormulaDetails.IdAnbar ,FormulaDetails.KolCount ,FormulaDetails.JozCount ,FormulaDetails.IdKala,Kind=CASE WHEN FormulaDetails.Kind=0 THEN N'مصرفی' ELSE N'تولیدی' END,FormulaDetails.Darsad,FormulaDetails.KalaDisc ,Define_Kala.Nam as NamKala ,Define_Anbar.nam AS NamAnbar,Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala ,Define_Vahed .Nam As Vahed FROM  FormulaDetails  INNER JOIN Define_Kala ON FormulaDetails.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON FormulaDetails.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE FormulaDetails.IdFormula = " & Id & " ORDER BY FormulaDetails.Id"
            If Not dtaK Is Nothing Then
                dtaK.Dispose()
            End If
            '''''''''''''''''''''''''''
            dtaK = New SqlDataAdapter(strK, DataSource)
            dtaK.Fill(dsK, "FormulaDetails")
            DGV2.AutoGenerateColumns = False
            bsK.DataSource = dsK
            bsK.DataMember = "FormulaDetails"
            DGV2.DataSource = bsK
        Catch ex As Exception
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmFormulasSearch", "fill_Kdgv")
            Me.Close()
        End Try
    End Sub

    Private Sub FrmFormulasSearch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
    End Sub

    Private Sub FrmFormulasSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmFormulasSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font("IRANSans", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.Fill_Dgv()
        DGV.Columns("Cln_FormulName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        IdKala = 0
        Tmp_Namkala = ""
    End Sub
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            cmdadd.Focus()

            If DGV.RowCount > 0 Then
                IdKala = CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value.ToString)
                Tmp_Namkala = DGV.Item("Cln_FormulName", DGV.CurrentRow.Index).Value.ToString
            Else
                IdKala = 0
                Tmp_Namkala = ""
            End If
            Me.Close()
        Catch ex As Exception
            IdKala = 0
            Tmp_Namkala = ""
            Me.Close()
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        IdKala = 0
        Tmp_Namkala = ""
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Fill_Dgv()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Fill_Dgv()
    End Sub

    Private Sub DGV2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            IdKala = 0
            Tmp_Namkala = ""
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Kalaoghimat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If cmdadd.Enabled = True Then Call cmdadd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If cmdedit.Enabled = True Then Call cmdedit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.Fill_Dgv()
        ElseIf e.KeyCode = Keys.Enter Then
            Try
                If DGV.RowCount > 0 Then
                    IdKala = CLng(DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value.ToString)
                    Tmp_Namkala = DGV.Item("Cln_FormulName", DGV.CurrentRow.Index).Value.ToString
                Else
                    IdKala = 0
                    Tmp_Namkala = ""
                End If
                Me.Close()
            Catch ex As Exception
                IdKala = 0
                Tmp_Namkala = ""
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub BN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub cmdadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdadd.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub cmddel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GetKey(e)
    End Sub

    Private Sub cmdedit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdedit.KeyDown
        Me.GetKey(e)
    End Sub

End Class