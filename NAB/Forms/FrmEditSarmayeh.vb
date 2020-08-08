Imports System.Data.SqlClient
Public Class FrmEditSarmayeh

    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub DGV_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellClick
        If e.ColumnIndex = 3 Then
            If CDbl(TxtSarmayeh.Text) <> 0 Then
                Using frms As New FrmDivSod
                    frms.TxtSarmayeh.Text = TxtSarmayeh.Text
                    frms.ShowDialog()
                    If Not String.IsNullOrEmpty(frms.LAdd.Text) Then DGV.Item("Cln_NewMandeh", DGV.CurrentRow.Index).Value = IIf(CDbl(DGV.Item("Cln_NewMandeh", DGV.CurrentRow.Index).Value) + CDbl(frms.TxtMon.Text) <> 0, FormatNumber(CDbl(DGV.Item("Cln_NewMandeh", DGV.CurrentRow.Index).Value) + CDbl(frms.TxtMon.Text), 0), 0)
                End Using
                CalculateMon()
            Else
                MessageBox.Show("سرمایه ایی برای تقسیم سود وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        CalculateMon()
    End Sub

    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        Try
            If CDbl(DGV.Item("Cln_MonBax", e.RowIndex).Value) < 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_MonBax").Style.BackColor = Color.Pink
            ElseIf CDbl(DGV.Item("Cln_MonBax", e.RowIndex).Value) = 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_MonBax").Style.BackColor = Color.Yellow
            ElseIf CDbl(DGV.Item("Cln_MonBax", e.RowIndex).Value) > 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_MonBax").Style.BackColor = Color.White
            End If

            If CDbl(DGV.Item("Cln_NewMandeh", e.RowIndex).Value) < 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_NewMandeh").Style.BackColor = Color.Pink
            ElseIf CDbl(DGV.Item("Cln_NewMandeh", e.RowIndex).Value) = 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_NewMandeh").Style.BackColor = Color.Yellow
            ElseIf CDbl(DGV.Item("Cln_NewMandeh", e.RowIndex).Value) > 0 Then
                DGV.Rows(e.RowIndex).Cells("Cln_NewMandeh").Style.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMonBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonBox.TextChanged
        If CDbl(TxtMonBox.Text.Trim) = 0 Then
            TxtMonBox.BackColor = Color.Yellow
        ElseIf CDbl(TxtMonBox.Text.Trim) > 0 Then
            TxtMonBox.BackColor = Color.White
        ElseIf CDbl(TxtMonBox.Text.Trim) < 0 Then
            TxtMonBox.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtMonEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonEdit.TextChanged
        If CDbl(TxtMonEdit.Text.Trim) = 0 Then
            TxtMonEdit.BackColor = Color.Yellow
        ElseIf CDbl(TxtMonEdit.Text.Trim) > 0 Then
            TxtMonEdit.BackColor = Color.White
        ElseIf CDbl(TxtMonEdit.Text.Trim) < 0 Then
            TxtMonEdit.BackColor = Color.Pink
        End If
    End Sub

    Private Sub CalculateMon()
        Try
            TxtMonBox.Text = 0
            TxtMonEdit.Text = 0
            For i As Integer = 0 To DGV.RowCount - 1
                TxtMonBox.Text = CDbl(TxtMonBox.Text) + CDbl(DGV.Item("Cln_MonBax", i).Value)
                TxtMonEdit.Text = CDbl(TxtMonEdit.Text) + CDbl(DGV.Item("Cln_NewMandeh", i).Value)
            Next
            If TxtMonBox.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonBox.Text.Replace(",", ""))
                TxtMonBox.Text = Format$(Val(Str), "###,###,###")
            End If

            If TxtMonEdit.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonEdit.Text.Replace(",", ""))
                TxtMonEdit.Text = Format$(Val(Str), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "CloseMali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnPrint.Enabled = True Then Call BtnPrint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try
            For i As Integer = 0 To Tmp_DtSarmayeh.Rows.Count - 1
                For j As Integer = 0 To DGV.RowCount - 1
                    If Tmp_DtSarmayeh.Rows(i).Item("Id") = DGV.Item("Cln_Id", j).Value Then
                        Tmp_DtSarmayeh.Rows(i).Item("NewMandeh") = CDbl(DGV.Item("Cln_NewMandeh", j).Value)
                        Exit For
                    End If
                Next
            Next
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditSarmayeh", "BtnReport_Click")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmEditBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmEditBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        FillData()
        Traz()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub FillData()
        Try
            For i As Integer = 0 To Tmp_DtSarmayeh.Rows.Count - 1
                DGV.Rows.Add()
                DGV.Item("Cln_Id", DGV.RowCount - 1).Value = Tmp_DtSarmayeh.Rows(i).Item("Id")
                DGV.Item("Cln_Nam", DGV.RowCount - 1).Value = Tmp_DtSarmayeh.Rows(i).Item("Nam")
                DGV.Item("Cln_MonBax", DGV.RowCount - 1).Value = IIf(Tmp_DtSarmayeh.Rows(i).Item("Mandeh") <> 0, FormatNumber(Tmp_DtSarmayeh.Rows(i).Item("Mandeh"), 0), 0)
                DGV.Item("Cln_AddSod", DGV.RowCount - 1).Value = "تقسیم سود"
                DGV.Item("Cln_NewMandeh", DGV.RowCount - 1).Value = IIf(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh") <> 0, FormatNumber(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh"), 0), 0)
            Next
            CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditSarmayeh", "FillData")
            Me.Close()
        End Try
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = (vbBack) Then
                e.Handled = False
            End If
            If e.KeyChar = (vbTab) Then
                e.Handled = False
            End If
            If e.KeyChar = "-" Then
                If InStr(txt_dgv.Text, "-") = False Then
                    e.Handled = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If Not (CheckDigitWithOutpoint(txt_dgv.Text)) Then txt_dgv.Text = 0
            If txt_dgv.Text.Length > 3 Then
                Dim str As String = ""
                SendKeys.Send("{end}")
                str = Format$(txt_dgv.Text.Replace(",", ""))
                txt_dgv.Text = Format$(Val(str), "###,###,###")
            Else
                txt_dgv.Text = CDbl(txt_dgv.Text)
            End If
            CalculateMon()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSarmayeh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSarmayeh.TextChanged
        If TxtSarmayeh.Text.Length > 3 Then
            Dim str As String = ""
            str = Format$(TxtSarmayeh.Text.Replace(",", ""))
            TxtSarmayeh.Text = Format$(Val(str), "###,###,###")
        End If

        If CDbl(TxtSarmayeh.Text.Trim) = 0 Then
            TxtSarmayeh.BackColor = Color.Yellow
        ElseIf CDbl(TxtSarmayeh.Text.Trim) > 0 Then
            TxtSarmayeh.BackColor = Color.White
        ElseIf CDbl(TxtSarmayeh.Text.Trim) < 0 Then
            TxtSarmayeh.BackColor = Color.Pink
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("گزارشی برای چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim dt As New DataTable

        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
        Using cmd As New SqlCommand("SELECT Id,nam,OneMoney,BedMon=(SELECT ISNULL(SUM(BedMon),0) As BedMon FROM (SELECT BedMon=CASE Get_Pay_Sarmayeh.[State]  WHEN 0 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END  FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id AND Define_Sarmayeh.ID =ListSarmayeh.ID)AS AllCharge ) * (-1),BesMon=(SELECT ISNULL(SUM(BesMon),0) As BesMon FROM (SELECT BesMon=CASE Get_Pay_Sarmayeh.[State] WHEN 1 THEN (Cash+ MonHavaleh+ MonPayChk+ MonsellChk+ Lend) ELSE 0 END FROM  Get_Pay_Sarmayeh  INNER JOIN Define_Sarmayeh ON Get_Pay_Sarmayeh .IdSarmayeh  = Define_Sarmayeh .ID INNER JOIN Define_OneSarmayeh  ON Define_Sarmayeh .IdOne = Define_OneSarmayeh .Id AND Define_Sarmayeh.ID =ListSarmayeh.ID  )AS AllCharge ),OneSod=0,SumSod=0,EndSod=0 FROM (SELECT ID ,OneMoney=CASE STAT WHEN N'بدهکار' THEN AllMoney * (-1) WHEN N'بستانکار' THEN AllMoney ELSE AllMoney END ,nam FROM  Define_Sarmayeh) As ListSarmayeh", ConectionBank)
            dt.Load(cmd.ExecuteReader)
        End Using
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        dt.Columns("OneSod").ReadOnly = False
        dt.Columns("SumSod").ReadOnly = False
        dt.Columns("EndSod").ReadOnly = False

        For i As Integer = 0 To dt.Rows.Count - 1
            For j As Integer = 0 To DGV.RowCount - 1
                If dt.Rows(i).Item("Id") = DGV.Item("Cln_Id", j).Value Then
                    dt.Rows(i).Item("OneSod") = (CDbl(DGV.Item("Cln_NewMandeh", j).Value) - CDbl(DGV.Item("Cln_MonBax", j).Value)) * (-1)
                    dt.Rows(i).Item("SumSod") = dt.Rows(i).Item("OneSod") + dt.Rows(i).Item("BesMon")
                    dt.Rows(i).Item("EndSod") = dt.Rows(i).Item("SumSod") + dt.Rows(i).Item("BedMon") + dt.Rows(i).Item("OneMoney")
                    Exit For
                End If
            Next
        Next

        Using frmp As New FrmPrint
            frmp.CHoose = "ENDSARMAYEH"
            frmp.DtS = dt
            frmp.ShowDialog()
        End Using
    End Sub

    Private Sub Traz()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            '''''''''MoeinBox
            Dim TxtBox As Double = 0
            For i As Integer = 0 To Tmp_DtBox.Rows.Count - 1
                TxtBox = CDbl(TxtBox) + CDbl(Tmp_DtBox.Rows(i).Item("NewMandeh"))
            Next

            '''''''''MoeinBank
            Dim TxtBank As Double = "0"
            For i As Integer = 0 To Tmp_DtBank.Rows.Count - 1
                TxtBank = CDbl(TxtBank) + CDbl(Tmp_DtBank.Rows(i).Item("NewMandeh"))
            Next

            '''''''''Kala
            Dim Txtkala As Double = "0"
            For i As Integer = 0 To Tmp_DtKala.Rows.Count - 1
                Txtkala = CDbl(Txtkala) + CDbl(Tmp_DtKala.Rows(i).Item("AllMon"))
            Next

            '''''''''Amval
            Dim Txtamval As Double = "0"
            For i As Integer = 0 To Tmp_DtAmval.Rows.Count - 1
                Txtamval = CDbl(Txtamval) + CDbl(Tmp_DtAmval.Rows(i).Item("NewMandeh"))
            Next

            '''''''''Sarmayeh
            Dim Txtsarmaeh As Double = "0"
            For i As Integer = 0 To Tmp_DtSarmayeh.Rows.Count - 1
                Txtsarmaeh = CDbl(Txtsarmaeh) + CDbl(Tmp_DtSarmayeh.Rows(i).Item("NewMandeh"))
            Next
            Txtsarmaeh = CDbl(Txtsarmaeh) * -1

            '''''''''GetChk
            Dim Txtget As Double = 0
            Using Cmd As New SqlCommand("SELECT  ISNULL(SUM(MoneyChk),0) AS GetChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =0 And Current_State =0 or Current_State =4)", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtget = Cmd.ExecuteScalar()
            End Using

            '''''''''BedMandeh
            Dim Txtbed As Double = 0
            Using Cmd As New SqlCommand("SELECT ISNULL(SUM(Mandeh),0) As BedMandeh   FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol  WHERE Mandeh>=0", ConectionBank)
                Cmd.CommandTimeout = 0
                Txtbed = Cmd.ExecuteScalar()
            End Using

            '''''''''PayChk
            Dim TxtPay As Double = 0
            Using Cmd As New SqlCommand("SELECT  ISNULL(SUM(MoneyChk),0) AS PayChk FROM Chk_Get_Pay WHERE (Activ =1 AND Current_Kind =1 And Current_State =0 ) AND (Current_Kind =Kind)", ConectionBank)
                Cmd.CommandTimeout = 0
                TxtPay = Cmd.ExecuteScalar()
            End Using

            '''''''''BesMandeh
            Dim TxtBes As Double = 0
            Using Cmd As New SqlCommand("SELECT ABS(ISNULL(SUM(Mandeh),0)) As BesMandeh  FROM (SELECT AllKol.id,Mandeh=(AllKol.bedMon-AllKol.BesMon) FROM(SELECT  Alldata.ID,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ID,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People )As Alldata)As AllKol) AS DaftarKol WHERE Mandeh<0", ConectionBank)
                Cmd.CommandTimeout = 0
                TxtBes = Cmd.ExecuteScalar()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Dim Txtdara As Double = 0
            Dim Txtparda As Double = 0
            Dim TxtSod As Double = 0
            Dim Txttraz As Double = 0

            Txtdara = TxtBox + TxtBank + Txtget + Txtbed + Txtkala + Txtamval 'dtr("MoeinBox") + dtr("MoeinBank") + dtr("GetChk") + dtr("BedMandeh") + dtr("Kala") + dtr("Amval")
            Txtparda = TxtPay + TxtBes + Txtsarmaeh
            TxtSod = Txtdara - Txtparda
            Txttraz = Txtdara - (Txtparda + TxtSod)

            TxtSarmayeh.Text = TxtSod

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditSarmayeh", "Traz")
            Me.Close()
        End Try
    End Sub

End Class