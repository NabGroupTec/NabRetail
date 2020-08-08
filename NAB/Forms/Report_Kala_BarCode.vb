Imports System.Data.SqlClient
Public Class Report_Kala_BarCode

    Private Sub Report_Kala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        getkey(e)
    End Sub
    Private Sub ReportBuyKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F75")
        If (Access_Form <> "-1") Then
            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
            End If
        End If
        Me.GetKala()
        CheckBox2.Checked = False
        DGV2.Columns("Cln_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub getkey(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "CreatBarcode.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
        End If
    End Sub
    Private Sub GetKala()
        Try
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()

            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Id, Nam, BarCode FROM Define_Kala WHERE Activ ='False' AND BarCode <>N''"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            DGV2.AutoGenerateColumns = False
            DGV2.DataSource = Ds.Tables("Define_Kala")
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportBuy", "GetKala")
            Me.Close()
        End Try
    End Sub
    Private Function GetKalaName(ByVal cadd_k As Long, ByVal cdek_k As Long) As String
        Dim strkala As String = ""
        If cAdd_K = DGV2.RowCount Then
            strkala = ""
        Else
            If cAdd_K <= cDek_K Then
                strkala = " AND ("
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_SelectKala", i).Value = True Then
                        strkala &= " (Kala_Factor.Idkala=" & DGV2.Item("Cln_IdKala", i).Value & " AND Kala_Factor.type='" & DGV2.Item("Cln_GroupKala", i).Value & "')"
                        strkala &= " OR"
                    End If
                Next
                strkala = strkala.Substring(0, strkala.Length - 3)
                strkala &= ")"
            Else
                strkala = " AND ("
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_SelectKala", i).Value = False Then
                        strkala &= " (Kala_Factor.Idkala<>" & DGV2.Item("Cln_IdKala", i).Value & " AND Kala_Factor.type='" & DGV2.Item("Cln_GroupKala", i).Value & "')"
                        strkala &= " OR"
                    End If
                Next
                strkala = strkala.Substring(0, strkala.Length - 3)
                strkala &= ")"
            End If
        End If
        Return strkala
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim c As Integer = 0
            c = 0
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Item("Cln_Select", i).Value = True Then c += 1
            Next
            If c <= 0 Then
                MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Array.Resize(ListODarsad, 0)
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Item("Cln_Select", i).Value = True Then
                    If CheckBox1.Checked = False Then
                        Array.Resize(ListODarsad, ListODarsad.Length + 1)
                        ListODarsad(ListODarsad.Length - 1).Group = DGV2.Item("Cln_Name", i).Value & IIf(ChkCost.Checked = False, "", "  ***  قیمت: " & FormatNumber(GetCostFrosh(DGV2.Item("Cln_Id", i).Value, 0, 0), 0))
                        ListODarsad(ListODarsad.Length - 1).Darsad = "!" & DGV2.Item("Cln_BarCode", i).Value & "!"
                    Else
                        For j As Integer = 0 To Num.Value - 1
                            Array.Resize(ListODarsad, ListODarsad.Length + 1)
                            ListODarsad(ListODarsad.Length - 1).Group = DGV2.Item("Cln_Name", i).Value & IIf(ChkCost.Checked = False, "", "  ***  قیمت: " & FormatNumber(GetCostFrosh(DGV2.Item("Cln_Id", i).Value, 0, 0), 0))
                            ListODarsad(ListODarsad.Length - 1).Darsad = "!" & DGV2.Item("Cln_BarCode", i).Value & "!"
                        Next j
                    End If
                End If
            Next
            Using frmp As New FrmPrint
                If Rdo8.Checked = True Then
                    frmp.CHoose = "BARCODE8"
                ElseIf Rdo10.Checked = True Then
                    frmp.CHoose = "BARCODE10"
                ElseIf Rdo12.Checked = True Then
                    frmp.CHoose = "BARCODE12"
                ElseIf Rdo14.Checked = True Then
                    frmp.CHoose = "BARCODE14"
                ElseIf Rdo16.Checked = True Then
                    frmp.CHoose = "BARCODE16"
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تولید بارکد", "تهیه گزارش", "", "")

                frmp.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If DGV2.RowCount <= 0 Then Exit Sub
        If CheckBox2.Checked = True Then
            For i As Integer = 0 To DGV2.RowCount - 1
                DGV2.Item("Cln_Select", i).Value = True
            Next
        Else
            For i As Integer = 0 To DGV2.RowCount - 1
                DGV2.Item("Cln_Select", i).Value = False
            Next
        End If
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV2.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV2.RowCount > 1 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_Id", i).Value = IdKala Then
                        DGV2.Item("Cln_Name", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV2.Item("Cln_Name", 0).Selected = True
                DGV2.Item("Cln_Name", 0).Selected = False
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Using FrmAdVance As New Kala_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV2.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV2.Item("Cln_Id", i).Value Then DGV2.Item("Cln_Select", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV2.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Num.Enabled = True
        Else
            Num.Enabled = False
        End If
    End Sub
End Class