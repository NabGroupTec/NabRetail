﻿Imports System.Data.SqlClient
Public Class Kardex_Anbar
    Dim dt As New DataTable
    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            ChkAzDate.Enabled = True
            ChkTaDate.Enabled = True
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = True
            ChkTaDate.Checked = True
        Else
            ChkAzDate.Enabled = False
            ChkTaDate.Enabled = False
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Checked = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub Moein_People_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtName.Focus()
    End Sub

    Private Sub Moein_People_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Moein_People_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F61")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If
                If Access_Form.Substring(3, 1) = 0 Then
                    BtnReport.Enabled = False
                End If
            End If

        End If
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        DGV.Columns("Cln_Disc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        If Not String.IsNullOrEmpty(TxtIdName.Text.Trim) And Not String.IsNullOrEmpty(TxtName.Text.Trim) And Not String.IsNullOrEmpty(TxtIdAnbar.Text.Trim) And Not String.IsNullOrEmpty(TxtAnbarNam.Text.Trim) Then
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV.KeyDown
        If e.KeyCode = AscW(0) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(1) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.DeepPink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(2) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Magenta
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(3) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.BlueViolet
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(4) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.DarkTurquoise
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(5) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(6) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Yellow
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(7) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Olive
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(8) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Orange
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(9) Then
            DGV.Rows(DGV.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Chocolate
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
            DGV.Rows(DGV.CurrentRow.Index).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = Keys.Delete Then
            For i As Integer = 0 To DGV.RowCount - 1
                DGV.Rows(i).DefaultCellStyle.BackColor = Color.White
                DGV.Rows(i).Cells("Cln_InKOL").Style.BackColor = Color.SpringGreen
                DGV.Rows(i).Cells("Cln_InJoz").Style.BackColor = Color.SpringGreen
                DGV.Rows(i).Cells("Cln_OutKOL").Style.BackColor = Color.Pink
                DGV.Rows(i).Cells("Cln_OutJoz").Style.BackColor = Color.Pink
                DGV.Rows(i).Cells("Cln_KolMandeh").Style.BackColor = Color.Gainsboro
                DGV.Rows(i).Cells("Cln_JozMandeh").Style.BackColor = Color.Gainsboro
            Next
        End If
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
    End Sub

    Private Sub ChkAzDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkAzDate.Checked = True Then
            FarsiDate1.ThisText = GetDate()
            FarsiDate1.Enabled = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
        End If
    End Sub

    Private Sub ChkTaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
        End If
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then BtnReport.Focus()
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Kala_Anbar_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            Me.Enabled = False
            TxtName.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            TxtIdAnbar.Text = Idanbar
            TxtAnbarNam.Text = namAnbar
            TxtGroup.Text = Tmp_OneGroup + "-" + Tmp_TwoGroup
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetMoein(ByVal id As Long, ByVal idAnbar As Long, ByVal Part As String)
        Try
            Dim Sql_Str As String = ""
            If ChkPart.Checked = False Then
                If ChkTime.Checked = False Then
                    Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0 End,InJoz=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND( KalaFactorBuy .IdAnbar =" & idAnbar & ") UNION ALL SELECT   Pre=2, KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1)  AND( KalaFactorBackBuy .IdKala =" & id & ") AND( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND( KalaFactorSell .IdAnbar =" & idAnbar & ") UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND( KalaFactorBackSell .IdAnbar =" & idAnbar & ") UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND( KalaFactorDamage .IdAnbar =" & idAnbar & ") UNION ALL SELECT   Pre=0,Fe,Iduser ,IdAnbar, Count_Kol As Kol, Count_Joz As Joz, D_date,Disc=N'موجودی اول دوره' FROM  Define_PrimaryKala WHERE IdKala =" & id & " AND (IdAnbar =" & idAnbar & ") UNION ALL SELECT Pre=6,Fe=0,IdUser,IdTwoAnbar  As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdtwoAnbar  =" & idAnbar & " UNION ALL SELECT Pre=7,Fe=0,IdUser,IdOneAnbar As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdOneAnbar   =" & idAnbar & ")As AllKala Order by AllKala.D_date ,AllKala.Pre"
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End ,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End ,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End ,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=2, KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND ( KalaFactorDamage .IdKala =" & id & ") AND (KalaFactorDamage.IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=0,Fe,Iduser ,IdAnbar, Count_Kol As Kol, Count_Joz As Joz, D_date,Disc=N'موجودی اول دوره' FROM  Define_PrimaryKala WHERE IdKala =" & id & "AND (IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT Pre=6,Fe=0,IdUser,IdTwoAnbar  As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdtwoAnbar  =" & idAnbar & " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT Pre=7,Fe=0,IdUser,IdOneAnbar As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdOneAnbar   =" & idAnbar & " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') )As AllKala  UNION ALL SELECT Pre=0,AVG(Fe) As Fe,IdUser=-1 ,IdAnbar=0 ,D_date=N'' ,Disc=N'موجودی تا قبل از  " & FarsiDate1.ThisText & "',SUM(InKOl) AS InKol,SUM(InJoz) AS InJoz,SUM(OutKOl) AS OutKol,SUM(OutJoz ) AS OutJoz,KolMandeh ,JozMandeh  FROM (SELECT InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 Or Pre=6 THEN SUM(Kol) Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 Or Pre=6  THEN SUM(Joz)   Else 0  End ,OutKol=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 Or Pre=7  THEN SUM(Kol)  Else 0  End  ,OutJoz=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 Or Pre=7 THEN SUM(Joz)  Else 0   End ,KolMandeh=0.0,JozMandeh=0.0,Fe FROM (SELECT   Pre=1,KalaFactorBuy.Fe,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor  WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=2,KalaFactorBackBuy.Fe,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor  WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor  WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor  WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=0,Fe, Count_Kol As Kol, Count_Joz As Joz, D_date FROM  Define_PrimaryKala WHERE IdKala =" & id & " AND (IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT Pre=6,Fe=0,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date  FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdtwoAnbar  =" & idAnbar & " AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT Pre=7,Fe=0,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date  FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdOneAnbar =" & idAnbar & " AND (D_date<N'" & FarsiDate1.ThisText & "') )As AllKala GROUP BY Pre,Fe )AS AllSum GROUP BY KolMandeh ,JozMandeh  Order by AllKala.D_date ,AllKala.Pre "
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End ,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End ,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End ,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=2, KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "')  UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=0,Fe,Iduser ,IdAnbar, Count_Kol As Kol, Count_Joz As Joz, D_date,Disc=N'موجودی اول دوره' FROM  Define_PrimaryKala WHERE IdKala =" & id & " AND (IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT Pre=6,Fe=0,IdUser,IdTwoAnbar  As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdtwoAnbar  =" & idAnbar & " AND (D_date>=N'" & FarsiDate1.ThisText & "') UNION ALL SELECT Pre=7,Fe=0,IdUser,IdOneAnbar As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdOneAnbar   =" & idAnbar & " AND (D_date>=N'" & FarsiDate1.ThisText & "') )As AllKala  UNION ALL SELECT Pre=0,AVG(Fe) As Fe,IdUser=-1 ,IdAnbar=0 ,D_date=N'' ,Disc=N'موجودی تا قبل از  " & FarsiDate1.ThisText & "',SUM(InKOl) AS InKol,SUM(InJoz) AS InJoz,SUM(OutKOl) AS OutKol,SUM(OutJoz ) AS OutJoz,KolMandeh ,JozMandeh  FROM (SELECT InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN SUM(Kol) Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6  THEN SUM(Joz)   Else 0  End ,OutKol=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7   THEN SUM(Kol)  Else 0  End  ,OutJoz=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7  THEN SUM(Joz)  Else 0   End ,KolMandeh=0.0,JozMandeh=0.0,Fe FROM (SELECT   Pre=1,KalaFactorBuy.Fe,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor  WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=2,KalaFactorBackBuy.Fe,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor  WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor  WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor  WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT   Pre=0,Fe, Count_Kol As Kol, Count_Joz As Joz, D_date FROM  Define_PrimaryKala WHERE IdKala =" & id & " AND (IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT Pre=6,Fe=0,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date  FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdtwoAnbar  =" & idAnbar & " AND (D_date<N'" & FarsiDate1.ThisText & "') UNION ALL SELECT Pre=7,Fe=0,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date  FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdOneAnbar   =" & idAnbar & " AND (D_date<N'" & FarsiDate1.ThisText & "'))As AllKala GROUP BY Pre,Fe )AS AllSum GROUP BY KolMandeh ,JozMandeh  Order by AllKala.D_date ,AllKala.Pre"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0  End ,InJoz=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End ,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End ,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End ,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=2,KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ")  AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ")  AND (D_date<=N'" & FarsiDate2.ThisText & "')UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT   Pre=0,Fe,Iduser ,IdAnbar, Count_Kol As Kol, Count_Joz As Joz, D_date,Disc=N'موجودی اول دوره' FROM  Define_PrimaryKala WHERE IdKala =" & id & " AND (IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT Pre=6,Fe=0,IdUser,IdTwoAnbar  As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdtwoAnbar  =" & idAnbar & " AND (D_date<=N'" & FarsiDate2.ThisText & "') UNION ALL SELECT Pre=7,Fe=0,IdUser,IdOneAnbar As IdAnbar,Tranlate_Anbar.Kol AS Kol,Tranlate_Anbar.joz AS Joz,D_date ,N'انتقالات انبار بابت سند' +  Cast(Tranlate_Anbar.Id  As NvarChar(max)) As Disc FROM  Tranlate_Anbar WHERE IdKala =" & id & " AND IdOneAnbar   =" & idAnbar & " AND (D_date<=N'" & FarsiDate2.ThisText & "') )As AllKala Order by AllKala.D_date ,AllKala.Pre "
                    End If
                End If
            Else
                If ChkTime.Checked = False Then
                    Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0 End,InJoz=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND( KalaFactorBuy .IdAnbar =" & idAnbar & ") " & Part & "  UNION ALL SELECT   Pre=2, KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1)  AND( KalaFactorBackBuy .IdKala =" & id & ") AND( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") " & Part & " UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND( KalaFactorSell .IdAnbar =" & idAnbar & ") " & Part & " UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND( KalaFactorBackSell .IdAnbar =" & idAnbar & ") " & Part & " UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND( KalaFactorDamage .IdAnbar =" & idAnbar & ") " & Part & ")As AllKala Order by AllKala.D_date ,AllKala.Pre"
                Else
                    If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                        Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End ,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End ,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End ,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=2, KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND ( KalaFactorDamage .IdKala =" & id & ") AND (KalaFactorDamage.IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " )As AllKala  UNION ALL SELECT Pre=0,AVG(Fe) As Fe,IdUser=-1 ,IdAnbar=0 ,D_date=N'' ,Disc=N'موجودی تا قبل از  " & FarsiDate1.ThisText & "',SUM(InKOl) AS InKol,SUM(InJoz) AS InJoz,SUM(OutKOl) AS OutKol,SUM(OutJoz ) AS OutJoz,KolMandeh ,JozMandeh  FROM (SELECT InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 Or Pre=6 THEN SUM(Kol) Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 Or Pre=6  THEN SUM(Joz)   Else 0  End ,OutKol=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 Or Pre=7  THEN SUM(Kol)  Else 0  End  ,OutJoz=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 Or Pre=7 THEN SUM(Joz)  Else 0   End ,KolMandeh=0.0,JozMandeh=0.0,Fe FROM (SELECT   Pre=1,KalaFactorBuy.Fe,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor  WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=2,KalaFactorBackBuy.Fe,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor  WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor  WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor  WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " )As AllKala GROUP BY Pre,Fe )AS AllSum GROUP BY KolMandeh ,JozMandeh  Order by AllKala.D_date ,AllKala.Pre "
                    ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                        Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End ,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End ,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End ,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=2, KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date>=N'" & FarsiDate1.ThisText & "') " & Part & " )As AllKala  UNION ALL SELECT Pre=0,AVG(Fe) As Fe,IdUser=-1 ,IdAnbar=0 ,D_date=N'' ,Disc=N'موجودی تا قبل از  " & FarsiDate1.ThisText & "',SUM(InKOl) AS InKol,SUM(InJoz) AS InJoz,SUM(OutKOl) AS OutKol,SUM(OutJoz ) AS OutJoz,KolMandeh ,JozMandeh  FROM (SELECT InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN SUM(Kol) Else 0 End ,InJoz=Case  WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6  THEN SUM(Joz)   Else 0  End ,OutKol=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7   THEN SUM(Kol)  Else 0  End  ,OutJoz=Case  WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7  THEN SUM(Joz)  Else 0   End ,KolMandeh=0.0,JozMandeh=0.0,Fe FROM (SELECT   Pre=1,KalaFactorBuy.Fe,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor  WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=2,KalaFactorBackBuy.Fe,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor  WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ") AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor  WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor  WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & " UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date<N'" & FarsiDate1.ThisText & "') " & Part & ")As AllKala GROUP BY Pre,Fe )AS AllSum GROUP BY KolMandeh ,JozMandeh  Order by AllKala.D_date ,AllKala.Pre"
                    ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                        Sql_Str = "SELECT Pre,Fe,IdUser ,IdAnbar ,D_date ,Disc ,InKol=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Kol Else 0  End ,InJoz=Case WHEN Pre=0 OR Pre=1 OR Pre=4 OR Pre=6 THEN Joz Else 0 End ,OutKol=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Kol Else 0 End ,OutJoz=Case WHEN Pre=2 OR Pre=3 OR Pre=5 OR Pre=7 THEN Joz Else 0 End ,KolMandeh=0.0,JozMandeh=0.0 FROM (SELECT   Pre=1,KalaFactorBuy.Fe,ListFactorBuy.IdUser, KalaFactorBuy.IdAnbar,KalaFactorBuy.KolCount As Kol, KalaFactorBuy.JozCount As Joz, ListFactorBuy.D_date,Define_People .Nam + N' -- فاکتور خرید ' +  Cast(ListFactorBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBuy .IdName WHERE (KalaFactorBuy .Activ =1 and ListFactorBuy .Activ =1) AND (ListFactorBuy.Stat =0) AND( KalaFactorBuy .IdKala =" & id & ") AND ( KalaFactorBuy .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=2,KalaFactorBackBuy.Fe,ListFactorBackBuy.IdUser, KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.KolCount As Kol, KalaFactorBackBuy.JozCount As Joz, ListFactorBackBuy.D_date,Define_People .Nam + N' -- ف.برگشت از خرید ' +  Cast(ListFactorBackBuy .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackBuy .IdName WHERE (KalaFactorBackBuy .Activ =1 and ListFactorBackBuy .Activ =1) AND ( KalaFactorBackBuy .IdKala =" & id & ")  AND ( KalaFactorBackBuy .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=3,KalaFactorSell.Fe,ListFactorSell.IdUser, KalaFactorSell.IdAnbar,KalaFactorSell.KolCount As Kol, KalaFactorSell.JozCount As Joz, ListFactorSell.D_date,Define_People .Nam + N' -- فاکتور فروش ' +  Cast(ListFactorSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorSell .IdName WHERE (KalaFactorSell .Activ =1 and ListFactorSell .Activ =1) AND (ListFactorSell.Stat =3) AND( KalaFactorSell .IdKala =" & id & ") AND ( KalaFactorSell .IdAnbar =" & idAnbar & ")  AND (D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=4,KalaFactorBackSell.Fe,ListFactorBackSell.IdUser, KalaFactorBackSell.IdAnbar,KalaFactorBackSell.KolCount As Kol, KalaFactorBackSell.JozCount As Joz, ListFactorBackSell.D_date,Define_People .Nam + N' -- ف.برگشت از فروش ' +  Cast(ListFactorBackSell .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People  ON Define_People.ID =ListFactorBackSell .IdName WHERE (KalaFactorBackSell .Activ =1 and ListFactorBackSell .Activ =1) AND ( KalaFactorBackSell .IdKala =" & id & ") AND ( KalaFactorBackSell .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') " & Part & " UNION ALL SELECT   Pre=5,KalaFactorDamage.Fe,ListFactorDamage .IdUser, KalaFactorDamage.IdAnbar,KalaFactorDamage.KolCount As Kol, KalaFactorDamage.JozCount As Joz, ListFactorDamage.D_date, N' فاکتور ضایعات ' +  Cast(ListFactorDamage .IdFactor As NvarChar(max)) As Disc FROM  KalaFactorDamage INNER JOIN ListFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor  WHERE (KalaFactorDamage .Activ =1 and ListFactorDamage .Activ =1) AND( KalaFactorDamage .IdKala =" & id & ") AND ( KalaFactorDamage .IdAnbar =" & idAnbar & ") AND (D_date<=N'" & FarsiDate2.ThisText & "') " & Part & ")As AllKala Order by AllKala.D_date ,AllKala.Pre "
                    End If
                End If
            End If
            dt.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand(Sql_Str, ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            dt.Columns("KolMandeh").ReadOnly = False
            dt.Columns("JozMandeh").ReadOnly = False
            SetBedBesTableKardex(dt)
            DGV.DataSource = Nothing
            DGV.AutoGenerateColumns = False
            DGV.DataSource = dt
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kardex_kala", "SetMoein")
            Me.Close()
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Kartex_Anbar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnMoein.Enabled = True Then Call BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnReport.Enabled = True Then Call BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Call BtnMoein_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub RefreshBank()
        Try
            Dim Part As String = ""
            If ChkPart.Checked = True Then
                Part = " AND (Part =" & TxtIdPart.Text & ")"
            End If

            If String.IsNullOrEmpty(TxtIdName.Text) Then Exit Sub
            Me.Enabled = False
            Me.SetMoein(TxtIdName.Text, TxtIdAnbar.Text, Part)
            Dim InKOl As Double = 0
            Dim InJoz As Double = 0
            Dim OutKOl As Double = 0
            Dim OutJoz As Double = 0
            Dim KOlMandeh As Double = 0
            Dim JozMandeh As Double = 0
            For i As Integer = 0 To DGV.RowCount - 1
                InKOl += CDbl(DGV.Item("Cln_InKol", i).Value)
                InJoz += CDbl(DGV.Item("Cln_InJoz", i).Value)
                OutKOl += CDbl(DGV.Item("Cln_OutKol", i).Value)
                OutJoz += CDbl(DGV.Item("Cln_OutJoz", i).Value)
            Next
            If DGV.RowCount > 0 Then
                KOlMandeh = CDbl(DGV.Item("Cln_KolMandeh", DGV.RowCount - 1).Value)
                JozMandeh = CDbl(DGV.Item("Cln_JozMandeh", DGV.RowCount - 1).Value)
            Else
                KOlMandeh = 0
                JozMandeh = 0
            End If
            TxtInKol.Text = InKOl.ToString.Replace(".", "/")
            TxtInJoz.Text = InJoz.ToString.Replace(".", "/")
            TxtOutKol.Text = OutKOl.ToString.Replace(".", "/")
            TxtOutJoz.Text = OutJoz.ToString.Replace(".", "/")
            TxtKolMandeh.Text = KOlMandeh.ToString.Replace(".", "/")
            TxtJozMandeh.Text = JozMandeh.ToString.Replace(".", "/")

            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Kardex_kala", "RefreshBank")
            Me.Close()
        End Try
    End Sub
    Private Sub BtnMoein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoein.Click
        If String.IsNullOrEmpty(TxtIdName.Text.Trim) Or String.IsNullOrEmpty(TxtName.Text.Trim) Then
            MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtIdAnbar.Text.Trim) Or String.IsNullOrEmpty(TxtAnbarNam.Text.Trim) Then
            MessageBox.Show("هیچ انباری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtAnbarNam.Focus()
            Exit Sub
        End If

        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkTaDate.Checked = True
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    MessageBox.Show(" محدوده زمانی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If ChkPart.Checked = True Then
            If String.IsNullOrEmpty(TxtIdPart.Text) Or String.IsNullOrEmpty(TxtPart.Text) Then
                MessageBox.Show("پارت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPart.Focus()
                Exit Sub
            End If
        End If

        Me.RefreshBank()

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "کاردکس انبار", "نمایش کاردکس", "نمایش کاردکس کالای :" & TxtName.Text & " در انبار: " & TxtAnbarNam.Text, "")

    End Sub
    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If String.IsNullOrEmpty(TxtIdName.Text.Trim) Or String.IsNullOrEmpty(TxtName.Text.Trim) Then
            MessageBox.Show("هیچ کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtIdAnbar.Text.Trim) Or String.IsNullOrEmpty(TxtAnbarNam.Text.Trim) Then
            MessageBox.Show("هیچ انباری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtAnbarNam.Focus()
            Exit Sub
        End If

        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkTaDate.Checked = True
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    MessageBox.Show(" محدوده زمانی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        If ChkPart.Checked = True Then
            If String.IsNullOrEmpty(TxtIdPart.Text) Or String.IsNullOrEmpty(TxtPart.Text) Then
                MessageBox.Show("پارت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPart.Focus()
                Exit Sub
            End If
        End If

        Me.RefreshBank()

        If DGV.RowCount <= 0 Then
            TxtName.Focus()
            Exit Sub
        End If
        FrmPrint.DtMoeinKardex = dt
        Tmp_Namkala = TxtGroup.Text + "-" + TxtName.Text.Trim
        TmpTell1 = TxtKolMandeh.Text
        TmpTell2 = TxtJozMandeh.Text
        Tmp_String1 = TxtInKol.Text
        TmpAddress = TxtInJoz.Text
        TmpVahed = TxtOutKol.Text
        Tmp_String2 = TxtOutJoz.Text
        namAnbar2 = TxtAnbarNam.Text
        If ChkTime.Checked = False Then
            Tmp_OneGroup = ""
            If ChkPart.Checked = False Then
                Tmp_TwoGroup = ""
            Else
                Tmp_TwoGroup = "      " & " پارت:" & TxtPart.Text
            End If
        Else
            Tmp_OneGroup = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
            If ChkPart.Checked = False Then
                Tmp_TwoGroup = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
            Else
                Tmp_TwoGroup = If(ChkTaDate.Checked = True, FarsiDate2.ThisText & "      " & " پارت:" & TxtPart.Text, "      " & " پارت:" & TxtPart.Text)
            End If
        End If
        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "کاردکس انبار", "چاپ گزارش", "چاپ گزارش کاردکس کالای :" & TxtName.Text & " در انبار: " & TxtAnbarNam.Text, "")
        FrmPrint.CHoose = "KARDEXANBAR"
        FrmPrint.ShowDialog()
    End Sub

    Private Sub TxtAnbarNam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAnbarNam.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If String.IsNullOrEmpty(TxtIdName.Text) Or String.IsNullOrEmpty(TxtName.Text) Then
            MessageBox.Show("قبل از انتخاب انبار، کالا را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim frmlk As New Anbar_Kala_List
        frmlk.LIdKala.Text = TxtIdName.Text
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtName.Focus()
        If Tmp_Namkala <> "" Then
            Me.Enabled = False
            TxtIdAnbar.Text = IdKala
            TxtAnbarNam.Text = Tmp_Namkala
            Call BtnMoein_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            TxtPart.Enabled = True
            TxtPart.Focus()
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
            TxtPart.Enabled = False
        End If
    End Sub

    Private Sub TxtPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPart.KeyDown
        If e.KeyCode = Keys.Enter Then BtnMoein_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtPart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPart.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Part_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtPart.Focus()
        If Tmp_Namkala <> "" Then
            TxtPart.Text = Tmp_Namkala
            TxtIdPart.Text = IdKala
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

End Class