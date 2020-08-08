Imports System.Data.SqlClient
Public Class FrmEditKala
    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()
    Friend WithEvents txt_dgv As New DataGridViewTextBoxEditingControl

    Private Sub FrmMojodyKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmMojodyKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.GetKala()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetKala()
        Try
            For i As Integer = 0 To Tmp_DtKala.Rows.Count - 1
                DGV.Rows.Add()
                DGV.Item("Cln_Id", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("Id")
                DGV.Item("Cln_Idanbar", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("Idanbar")
                DGV.Item("Cln_Nam", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("Nam")
                DGV.Item("Cln_AnbarNam", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("NamAnbar")
                DGV.Item("Cln_Kolcount", DGV.RowCount - 1).Value = Replace(Tmp_DtKala.Rows(i).Item("KolCount"), ".", "/")
                DGV.Item("Cln_Jozcount", DGV.RowCount - 1).Value = Replace(Tmp_DtKala.Rows(i).Item("JozCount"), ".", "/")
                DGV.Item("Cln_Fe", DGV.RowCount - 1).Value = IIf(Tmp_DtKala.Rows(i).Item("Fe") <> 0, FormatNumber(Tmp_DtKala.Rows(i).Item("Fe"), 0), 0)
                DGV.Item("Cln_Mon", DGV.RowCount - 1).Value = IIf(Tmp_DtKala.Rows(i).Item("AllMon") <> 0, FormatNumber(Tmp_DtKala.Rows(i).Item("AllMon"), 0), 0)
                DGV.Item("Cln_Active", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("Activ")
                DGV.Item("Cln_DK", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("DK")
                DGV.Item("Cln_Kol", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("DK_KOL")
                DGV.Item("Cln_Joz", DGV.RowCount - 1).Value = Tmp_DtKala.Rows(i).Item("DK_JOZ")
            Next
            Me.CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditKala", "GetKala")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try
            DGV.RefreshEdit()
            For i As Integer = 0 To DGV.RowCount - 1
                If String.IsNullOrEmpty(DGV.Item("Cln_Jozcount", i).Value) Then
                    MessageBox.Show("تعداد جزء در ردیف شماره " & "{" & i + 1 & "}" & "  نا معتبر لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_Jozcount", i).Selected = True
                    Exit Sub
                End If

                If CDbl(DGV.Item("Cln_Jozcount", i).Value) < 0 Then
                    MessageBox.Show("تعداد جزء در ردیف شماره " & "{" & i + 1 & "}" & "  منفی است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_Jozcount", i).Selected = True
                    Exit Sub
                End If

                If String.IsNullOrEmpty(DGV.Item("Cln_KolCount", i).Value) Then
                    MessageBox.Show("تعداد کل در ردیف شماره " & "{" & i + 1 & "}" & "  نا معتبر لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_KolCount", i).Selected = True
                    Exit Sub
                End If

                If CDbl(DGV.Item("Cln_KolCount", i).Value) < 0 Then
                    MessageBox.Show("تعداد کل در ردیف شماره " & "{" & i + 1 & "}" & "  منفی است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_KolCount", i).Selected = True
                    Exit Sub
                End If

                If ((CDbl(DGV.Item("Cln_Jozcount", i).Value) > 0 And CDbl(DGV.Item("Cln_KolCount", i).Value) = 0) Or (CDbl(DGV.Item("Cln_Jozcount", i).Value) = 0 And CDbl(DGV.Item("Cln_KolCount", i).Value) > 0)) And DGV.Item("Cln_DK", i).Value = True Then
                    MessageBox.Show("تعداد کل و جزء در ردیف شماره " & "{" & i + 1 & "}" & "  اشتباه است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_KolCount", i).Selected = True
                    Exit Sub
                End If

                If (CDbl(DGV.Item("Cln_Jozcount", i).Value) > 0 Or CDbl(DGV.Item("Cln_KolCount", i).Value) > 0) And CDbl(DGV.Item("Cln_Fe", i).Value) <= 0 Then
                    MessageBox.Show("مقدار فی در ردیف شماره " & "{" & i + 1 & "}" & "  صفر است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_Fe", i).Selected = True
                    Exit Sub
                End If

                If CDbl(DGV.Item("Cln_Mon", i).Value) < 0 Then
                    MessageBox.Show("جمع مبلغ در ردیف شماره " & "{" & i + 1 & "}" & "  منفی است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGV.Focus()
                    DGV.Item("Cln_Fe", i).Selected = True
                    Exit Sub
                End If
            Next

            Me.Enabled = False
            For i As Integer = 0 To Tmp_DtKala.Rows.Count - 1
                For j As Integer = 0 To DGV.RowCount - 1
                    If Tmp_DtKala.Rows(i).Item("Id") = DGV.Item("Cln_Id", j).Value And Tmp_DtKala.Rows(i).Item("Idanbar") = DGV.Item("Cln_Idanbar", j).Value Then
                        Tmp_DtKala.Rows(i).Item("KolCount") = CDbl(DGV.Item("Cln_KolCount", j).Value.ToString.Replace("/", "."))
                        Tmp_DtKala.Rows(i).Item("JozCount") = CDbl(DGV.Item("Cln_JozCount", j).Value.ToString.Replace("/", "."))
                        Tmp_DtKala.Rows(i).Item("Fe") = CDbl(DGV.Item("Cln_Fe", j).Value)
                        Tmp_DtKala.Rows(i).Item("AllMon") = CDbl(DGV.Item("Cln_Mon", j).Value)
                        Exit For
                    End If
                Next
            Next

            Tmp_DtKala.AcceptChanges()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Activ,Id,Idanbar,DK ,DK_KOL ,DK_JOZ,Nam,NamAnbar ,KolCount ,JozCount,Fe=ROUND(AllMon/(CASE WHEN JozCount<>0 THEN JozCount WHEN KolCount <>0 THEN KolCount ELSE 1 END),0),AllMon FROM (SELECT Activ,Id,Idanbar,DK ,DK_KOL ,DK_JOZ,Nam,NamAnbar ,KolCount ,JozCount,AllMon=CASE WHEN (KOlCount=0 AND JozCount=0) THEN 0 WHEN (JozCount=0 AND KOlCount<>0) THEN ROUND(KolCount * dbo.GetCost(id,KolCount,'KOL','','','False'),0) ELSE ROUND(JozCount * dbo.GetCost(id,JozCount ,'JOZ','','','False'),0) END  FROM (SELECT *  FROM (SELECT AllKalaAnbar.*,(SELECT ROUND(ISNULL(SUM(AllKolCount.KolCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar) AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(AllJozCount.JozCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar) AS AllJozCount)JozCount FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Id,Define_Kala.Nam,Define_Kala.IdCodeOne ,Define_Kala.IdCodeTwo ,Define_Kala.Activ,Define_Kala.DK ,Define_Kala.DK_KOL ,Define_Kala.DK_JOZ  FROM Define_Kala ) AS AllKala ,Define_Anbar ) As AllKalaAnbar) As AllAnbar) As AllAnbar2 ) As AllAnbar3 Order by AllMon", ConectionBank)
                cmd.CommandTimeout = 0
                Tmp_Kala.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            For i As Integer = 0 To Tmp_Kala.Rows.Count - 1
                Dim row() As DataRow = Tmp_DtKala.Select("Id=" & Tmp_Kala.Rows(i).Item("Id") & " AND Idanbar=" & Tmp_Kala.Rows(i).Item("Idanbar"))
                If row.Length > 0 Then
                    If Not (row(0).Item("KolCount") = Tmp_Kala.Rows(i).Item("KolCount") And row(0).Item("JozCount") = Tmp_Kala.Rows(i).Item("JozCount")) Then
                        Array.Resize(ListEditKala, ListEditKala.Length + 1)
                        ListEditKala(ListEditKala.Length - 1).IdKala = Tmp_Kala.Rows(i).Item("Id")
                        ListEditKala(ListEditKala.Length - 1).OKol = Tmp_Kala.Rows(i).Item("KolCount")
                        ListEditKala(ListEditKala.Length - 1).Ojoz = Tmp_Kala.Rows(i).Item("JozCount")
                        ListEditKala(ListEditKala.Length - 1).TKol = row(0).Item("KolCount")
                        ListEditKala(ListEditKala.Length - 1).Tjoz = row(0).Item("JozCount")
                        ListEditKala(ListEditKala.Length - 1).IdAnbar = row(0).Item("Idanbar")
                    End If
                End If
            Next i

            Me.Enabled = True
            Me.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmEditKala", "BtnReport_Click")
            Me.Enabled = True
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "CloseMali.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnCancel.Enabled = True Then BtnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnSearch.Enabled = True Then BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F9 Then
            If MessageBox.Show("آیا برای اصلاح اتوماتیک مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Me.Enabled = False
            For i As Integer = 0 To DGV.RowCount - 1
                If String.IsNullOrEmpty(DGV.Item("Cln_Jozcount", i).Value) Then
                    DGV.Item("Cln_KolCount", i).Value = 0
                    DGV.Item("Cln_Jozcount", i).Value = 0
                    DGV.Item("Cln_Fe", i).Value = 0
                    DGV.Item("Cln_Mon", i).Value = 0
                End If

                If CDbl(DGV.Item("Cln_Jozcount", i).Value) < 0 Then
                    DGV.Item("Cln_KolCount", i).Value = 0
                    DGV.Item("Cln_Jozcount", i).Value = 0
                    DGV.Item("Cln_Fe", i).Value = 0
                    DGV.Item("Cln_Mon", i).Value = 0
                End If

                If String.IsNullOrEmpty(DGV.Item("Cln_KolCount", i).Value) Then
                    DGV.Item("Cln_KolCount", i).Value = 0
                    DGV.Item("Cln_Jozcount", i).Value = 0
                    DGV.Item("Cln_Fe", i).Value = 0
                    DGV.Item("Cln_Mon", i).Value = 0
                End If

                If CDbl(DGV.Item("Cln_KolCount", i).Value) < 0 Then
                    DGV.Item("Cln_KolCount", i).Value = 0
                    DGV.Item("Cln_Jozcount", i).Value = 0
                    DGV.Item("Cln_Fe", i).Value = 0
                    DGV.Item("Cln_Mon", i).Value = 0
                End If

                If ((CDbl(DGV.Item("Cln_Jozcount", i).Value) > 0 And CDbl(DGV.Item("Cln_KolCount", i).Value) = 0) Or (CDbl(DGV.Item("Cln_Jozcount", i).Value) = 0 And CDbl(DGV.Item("Cln_KolCount", i).Value) > 0)) And DGV.Item("Cln_DK", i).Value = True Then
                    DGV.Item("Cln_KolCount", i).Value = 0
                    DGV.Item("Cln_Jozcount", i).Value = 0
                    DGV.Item("Cln_Fe", i).Value = 0
                    DGV.Item("Cln_Mon", i).Value = 0
                End If

                'If (CDbl(DGV.Item("Cln_Jozcount", i).Value) > 0 Or CDbl(DGV.Item("Cln_KolCount", i).Value) > 0) And CDbl(DGV.Item("Cln_Fe", i).Value) <= 0 Then DGV.Item("Cln_Fe", i).Value = 1
            Next
            CalculateMon()
            Me.Enabled = True
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If DGV.RowCount <= 0 Then Exit Sub
        Dim frmlk As New Kala_List
        frmlk.BtnNewKala.Enabled = False
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV.RowCount > 1 Then
                For i As Integer = 0 To DGV.RowCount - 1
                    If DGV.Item("Cln_Id", i).Value = IdKala Then
                        DGV.Item("Cln_Nam", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV.Item("Cln_Nam", 0).Selected = True
                DGV.Item("Cln_Nam", 0).Selected = False
            End If
        End If
    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        CalculateMon()
    End Sub

    Private Sub DGV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGV.EditingControlShowing
        txt_dgv = e.Control
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.RowLeave
        Try
            If DGV.CurrentCell.ColumnIndex > 0 Then DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Selected = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalculateMon()
        TxtAllMon.Text = "0"
        For i As Integer = 0 To DGV.RowCount - 1
            TxtAllMon.Text = CDbl(TxtAllMon.Text) + CDbl(DGV.Item("Cln_Mon", i).Value)
        Next

        Dim str As String
        If TxtAllMon.Text.Length > 3 Then
            str = Format$(TxtAllMon.Text.Replace(",", ""))
            TxtAllMon.Text = Format$(Val(str), "###,###,###")
        Else
            TxtAllMon.Text = CDbl(TxtAllMon.Text)
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub txt_dgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dgv.KeyPress
        Try
            '''''''''''''''''''''''''''''''''''کنترل فی
            If DGV.CurrentCell.ColumnIndex = 5 Then
                If Char.IsNumber(e.KeyChar) = False Then
                    e.Handled = True
                End If
                If e.KeyChar = (vbBack) Then
                    e.Handled = False
                End If
                If e.KeyChar = (vbTab) Then
                    e.Handled = False
                End If
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''کنترل تعداد و نسبت جزء
            If DGV.CurrentCell.ColumnIndex = 3 Or DGV.CurrentCell.ColumnIndex = 4 Then
                If Char.IsNumber(e.KeyChar) = False Then
                    e.Handled = True
                End If
                If e.KeyChar = (vbBack) Then
                    e.Handled = False
                End If
                If e.KeyChar = (vbTab) Then
                    e.Handled = False
                End If
                If e.KeyChar = "." Then
                    If InStr(txt_dgv.Text, "/") = False Then
                        e.Handled = False
                        e.KeyChar = "/"
                    End If
                End If
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dgv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dgv.TextChanged
        Try
            If DGV.CurrentCell.ColumnIndex = 5 Then
                If Not (CheckDigitWithOutpoint(txt_dgv.Text)) Then txt_dgv.Text = 0
                If CDbl(txt_dgv.Text) < 0 Then txt_dgv.Text = 0
                If txt_dgv.Text.Length > 3 Then
                    Dim str As String = ""
                    SendKeys.Send("{end}")
                    str = Format$(txt_dgv.Text.Replace(",", ""))
                    txt_dgv.Text = Format$(Val(str), "###,###,###")
                Else
                    txt_dgv.Text = CDbl(txt_dgv.Text)
                End If
                If DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = False Then
                    DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV.Item("Cln_KolCOUNT", DGV.CurrentRow.Index).Value), "###,###")
                Else
                    DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value), "###,###")
                End If
                DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value), 0, DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value)
            ElseIf DGV.CurrentCell.ColumnIndex = 3 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                End If
                If DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = False Then
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                    DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value), "###,###")
                Else
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value)) * CDbl(DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    If String.IsNullOrEmpty(DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value) Then DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                    DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = Format(CDbl(DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value) * CDbl(DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value), "###,###")
                    If DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = 0
                End If
                DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value), 0, DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value)
                Try
                    If DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV.Item("Cln_JozCount", DGV.CurrentRow.Index).Value = 0
                End Try
            ElseIf DGV.CurrentCell.ColumnIndex = 4 Then
                If Not (CheckDigit(txt_dgv.Text)) Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
                End If
                If CDbl(txt_dgv.Text) < 0 Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
                End If
                If DGV.Item("Cln_DK", DGV.CurrentRow.Index).Value = False Then
                    txt_dgv.Text = 0
                    DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = Format(CDbl(DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value) * CDbl(DGV.Item("Cln_KolCOUNT", DGV.CurrentRow.Index).Value), "###,###")
                Else
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = Format(((CDbl(txt_dgv.Text)) / CDbl(DGV.Item("Cln_JOZ", DGV.CurrentRow.Index).Value)) * CDbl(DGV.Item("Cln_KOL", DGV.CurrentRow.Index).Value), "###.##").ToString.Replace(".", "/")
                    DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = Format(CDbl(txt_dgv.Text) * CDbl(DGV.Item("Cln_Fe", DGV.CurrentRow.Index).Value), "###,###")
                End If
                DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value = If(String.IsNullOrEmpty(DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value), 0, DGV.Item("Cln_Mon", DGV.CurrentRow.Index).Value)
                Try
                    If DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = "" Then DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
                Catch ex As Exception
                    DGV.Item("Cln_KolCount", DGV.CurrentRow.Index).Value = 0
                End Try
            End If

            If DGV.RowCount > 0 Then
                TxtAllMon.Text = "0"
                For i As Integer = 0 To DGV.RowCount - 1
                    If (CheckDigit(DGV.Item("Cln_Mon", i).Value)) Then
                        TxtAllMon.Text = CDbl(TxtAllMon.Text) + CDbl(DGV.Item("Cln_Mon", i).Value.ToString)
                    End If
                Next i
                If TxtAllMon.Text.Length > 3 Then
                    Dim money As String = ""
                    money = TxtAllMon.Text.Replace(",", "")
                    TxtAllMon.Text = Format$(Val(money), "###,###,###")
                End If
            Else
                TxtAllMon.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        If DGV.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        If CDbl(DGV.Item("cln_KolCount", e.RowIndex).Value) < 0 Then
            DGV.Rows(e.RowIndex).Cells("Cln_KolCount").Style.BackColor = Color.Pink
        ElseIf CDbl(DGV.Item("cln_KolCount", e.RowIndex).Value) >= 0 Then
            DGV.Rows(e.RowIndex).Cells("Cln_KolCount").Style.BackColor = Color.White
        End If

        If CDbl(DGV.Item("cln_JozCount", e.RowIndex).Value) < 0 Then
            DGV.Rows(e.RowIndex).Cells("cln_JozCount").Style.BackColor = Color.Pink
        ElseIf CDbl(DGV.Item("cln_JozCount", e.RowIndex).Value) >= 0 Then
            DGV.Rows(e.RowIndex).Cells("cln_JozCount").Style.BackColor = Color.White
        End If
    End Sub
End Class