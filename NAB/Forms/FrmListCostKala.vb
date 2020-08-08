Imports System.Data.SqlClient
Public Class FrmListCostKala

    Private Sub FrmListCostKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmListCostKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F106")
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
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetKala()
        Try
            Dim dv As New DataView
            Dim Ds As New DataSet
            Dim Dta As New SqlDataAdapter()

            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Define_Kala.Ex_Date,Define_Kala.Activ,Define_Kala.Id,Define_Kala.Nam , Define_OneGroup.NamOne +'-'+ Define_TwoGroup.NamTwo As GroupKala FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  Order by NamOne ,NamTwo ,Nam"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmListCostKala", "GetKala")
            Me.Close()
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
        If CBool(DGV.Item("Cln_Active", e.RowIndex).Value) = True Then
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Using FrmAdVance As New Kala_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV.Item("Cln_Id", i).Value Then DGV.Item("Cln_Select", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Ghimat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
            ChkAll.Checked = False
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("کالایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If RdoEndCity.Checked = True Then
            If String.IsNullOrEmpty(CmbOstan.Text) Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbOstan.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(CmbCity.Text) Then
                MessageBox.Show("هیچ شهرستانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbCity.Focus()
                Exit Sub
            End If

        End If

        Me.Enabled = False

        Dim ListKala As String = ""
        Dim CountKala As Long = 0
        ListKala = " WHERE ( "
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                ListKala &= "Define_Kala.Id=" & DGV.Item("Cln_Id", i).Value & " OR "
                CountKala += 1
            End If
        Next
        If CountKala = DGV.RowCount Then
            ListKala = ""
        ElseIf CountKala <= 0 Then
            MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Enabled = True
            Exit Sub
        Else
            ListKala = ListKala.Substring(0, ListKala.Length - 4)
            ListKala &= ")"
        End If

        Dim Mojody As String = ""
        If (RdoEndCity.Checked = True Or RdoMarjin.Checked = True) And ChkShow.Checked = True Then
            Mojody = " WHERE KolCount >0"
        End If

        Dim Sort As String = ""
        If RdoGroup.Checked = True Then
            Sort = " ORDER BY Wgt"
        ElseIf RdoKala.Checked = True Then
            Sort = " ORDER BY Nam"
        ElseIf RdoG.Checked = True Then
            Sort = " ORDER BY GroupKala,Nam"
        ElseIf RdoCost.Checked = True Then
            If RdoEndCity.Checked = True Then
                Sort = " ORDER BY Big ,Small ,EndCost"
            Else
                Sort = " ORDER BY Kol"
            End If
        End If


        Using FPrint As New FrmPrint
            If RdoG.Checked = False Then
                If RdoEndSell.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT  Top 1 Fe FROM(SELECT Fe,D_date  FROM (SELECT  Fe,IdFactor  FROM KalaFactorSell  WHERE  KalaFactorSell.IdKala =ListOnekala.Id   AND  KalaFactorSell.Activ =1 ) As ListKala INNER JOIN ListFactorSell  On ListFactorSell.IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorSell.IdName UNION ALL SELECT   Fe,D_date  FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id )AS EndKala ORDER BY D_date  DESC ),0) AS Kol FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam  FROM Define_Kala INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & ") AS ListOnekala " & Sort
                    FrmPrint.CHoose = "LISTCOSTKALA"
                ElseIf RdoEndCity.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Wgt ,Namfactor ,EndWgt ,Nam ,Big ,Small ,EndCost ,REPLACE(KolCount,'.','/') As KolCount ,REPLACE(JozCount,'.','/') AS JozCount  FROM (SELECT Ex_Date,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT Top 1 CostBigKala FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Big,ISNULL((SELECT Top 1 CostSmalKala  FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Small,ISNULL((SELECT Top 1 EndCost FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS EndCost,ROUND((SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllKolCount),2) As KolCount,ROUND((SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllJozCount),2) AS JozCount FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & " ) AS ListOnekala) As ListAll " & Mojody & Sort
                    If ChkNoMojodi.Checked = False Then
                        FrmPrint.CHoose = "LISTCOSTKALAALL"
                    Else
                        FrmPrint.CHoose = "LISTCOSTKALAALL2"
                    End If
                ElseIf RdoNoFe.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & ") AS ListOnekala " & Sort
                    FrmPrint.CHoose = "LISTCOSTKALANF"
                ElseIf RdoEndCost.Checked = True Then
                    'FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT AVG(EndCost)  FROM (SELECT EndCost=CASE WHEN MonFac =0 or MonCharge =0 THEN Fe2  ELSE ROUND(((((Fe1 * Case  WHEN JozCount <=0 THEN KolCount else JozCount end )*MonCharge)/MonFac))/(Case  WHEN JozCount <=0 THEN KolCount else JozCount end)+Fe2 ,0)  END FROM (SELECT D_date ,IdFactor ,JozCount ,KolCount ,Fe As Fe1,ISNULL((Fe-(DarsadMon /(Case  WHEN JozCount>0 THEN JozCount ELSE KolCount END))),0) AS Fe2 ,(SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =AllK.IdFactor  AND ListFactorCharge.Activ =1) As MonCharge,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =AllK.IdFactor) As MonFac FROM (SELECT TOP 2 * FROM(SELECT KolCount ,JozCount ,Fe,DarsadMon,ListKala.IdFactor ,D_date FROM (SELECT  KalaFactorBuy .KolCount ,KalaFactorBuy .JozCount ,Fe,DarsadMon,KalaFactorBuy .IdFactor  FROM KalaFactorBuy  WHERE  KalaFactorBuy .IdKala =ListOnekala.Id AND KalaFactorBuy .Activ =1 ) As ListKala INNER JOIN ListFactorBuy  On ListFactorBuy .IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBuy .IdName UNION ALL SELECT  Count_Kol As KolCount, Count_Joz As JozCount, Fe,DarsadMon=0,IdFactor=0, D_date FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id  )AS EndKala  ORDER BY D_date   DESC) As AllK) As AllK2) As Allk3),0) AS Kol FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & " ) AS ListOnekala " & Sort
                    FrmPrint.PrintSQl = "SELECT Ex_Date AS Disc,Id AS Wgt,Namfactor,EndWgt,Nam,Kol=CASE WHEN (KOlCount=0 AND JozCount=0) THEN dbo.GetCostCharge(id,(CASE WHEN DK='True' THEN -1 ELSE -1 END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') ELSE dbo.GetCostCharge(id,(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') END FROM (SELECT Ex_Date,Id,DK,Namfactor,EndWgt,Nam,KolCount,JozCount FROM (SELECT Ex_Date,Id,DK,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ROUND(KolCount,2) AS KolCount,ROUND(JozCount,2) As JozCount FROM  (SELECT AllKala.*,(SELECT ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0) FROM (SELECT ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount,(SELECT ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllJozCount)JozCount FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,DK,Define_Kala.Nam FROM Define_Kala INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & ") AS AllKala )As EndData )As AllKalaNfe ) AS AllKalaFe " & Sort
                    FrmPrint.CHoose = "LISTCOSTKALA"
                ElseIf RdoMarjin.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Wgt ,Namfactor ,EndWgt ,Nam ,Big ,Small ,EndCost,EndKol=REPLACE(ROUND(CASE WHEN Big>0 THEN ((EndCost -Big )*100)/Big ELSE 0 END,2),'.','/'),EndJoz=REPLACE(ROUND(CASE WHEN Small>0 THEN ((EndCost -Small )*100)/Small ELSE 0 END,2),'.','/')   FROM (SELECT Ex_Date,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT Top 1 CostBigKala FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Big,ISNULL((SELECT Top 1 CostSmalKala  FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Small,ISNULL((SELECT Top 1 EndCost FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS EndCost,ROUND((SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllKolCount),2) As KolCount,ROUND((SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllJozCount),2) AS JozCount FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & " ) AS ListOnekala) As ListAll " & Mojody & Sort
                    FrmPrint.CHoose = "LISTCOSTKALAMARGIN"
                ElseIf RdoEndSellCost.Checked = True Then
                    'FrmPrint.PrintSQl = "SELECT Disc,Wgt,Namfactor ,EndWgt,Nam,Small,Kol ,EndJoz=Case WHEN Kol =0 THEN '0' ELSE REPLACE(ROUND(100-((Small *100)/Kol),2),'.','/') END,CASE WHEN Kol=0 THEN 0 ELSE Kol-Small END AS Big FROM (SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT AVG(EndCost)  FROM (SELECT EndCost=CASE WHEN MonFac =0 or MonCharge =0 THEN Fe2  ELSE ROUND(((((Fe1 * Case  WHEN JozCount <=0 THEN KolCount else JozCount end )*MonCharge)/MonFac))/(Case  WHEN JozCount <=0 THEN KolCount else JozCount end)+Fe2 ,0)  END FROM (SELECT D_date ,IdFactor ,JozCount ,KolCount ,Fe As Fe1,ISNULL((Fe-(DarsadMon /(Case  WHEN JozCount>0 THEN JozCount ELSE KolCount END))),0) AS Fe2 ,(SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =AllK.IdFactor  AND ListFactorCharge.Activ =1) As MonCharge,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =AllK.IdFactor) As MonFac FROM (SELECT TOP 2 * FROM(SELECT KolCount ,JozCount ,Fe,DarsadMon,ListKala.IdFactor ,D_date FROM (SELECT  KalaFactorBuy .KolCount ,KalaFactorBuy .JozCount ,Fe,DarsadMon,KalaFactorBuy .IdFactor  FROM KalaFactorBuy  WHERE  KalaFactorBuy .IdKala =ListOnekala.Id AND KalaFactorBuy .Activ =1 ) As ListKala INNER JOIN ListFactorBuy  On ListFactorBuy .IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBuy .IdName UNION ALL SELECT  Count_Kol As KolCount, Count_Joz As JozCount, Fe,DarsadMon=0,IdFactor=0, D_date FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id  )AS EndKala  ORDER BY D_date   DESC) As AllK) As AllK2) As Allk3),0) AS Small,ISNULL((SELECT  Top 1 Fe FROM(SELECT Fe,D_date  FROM (SELECT  Fe,IdFactor  FROM KalaFactorSell  WHERE  KalaFactorSell.IdKala =ListOnekala.Id   AND  KalaFactorSell.Activ =1 ) As ListKala INNER JOIN ListFactorSell  On ListFactorSell.IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorSell.IdName UNION ALL SELECT   Fe,D_date  FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id )AS EndKala ORDER BY D_date  DESC ),0) AS Kol FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam  FROM Define_Kala INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & ") AS ListOnekala) AS EndList " & Sort
                    FrmPrint.PrintSQl = "SELECT Disc,Wgt,Namfactor,EndWgt,Nam,Small,Kol,EndJoz=Case WHEN Kol =0 THEN '0' ELSE REPLACE(ROUND(100-((Small *100)/Kol),2),'.','/') END,CASE WHEN Kol=0 THEN 0 ELSE Kol-Small END AS Big  FROM (SELECT Disc,Wgt,Namfactor,EndWgt,Nam,CASE WHEN (KOlCount=0 AND JozCount=0) THEN dbo.GetCostCharge(Wgt,(CASE WHEN DK='True' THEN -1 ELSE -1 END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') ELSE dbo.GetCostCharge(Wgt,(CASE WHEN DK='True' THEN JozCount ELSE KolCount END),(CASE WHEN DK='True' THEN 'JOZ' ELSE 'KOL' END),'','','False') END AS Small,Kol  FROM (SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT  Top 1 Fe FROM(SELECT Fe,D_date  FROM (SELECT  Fe,IdFactor  FROM KalaFactorSell  WHERE  KalaFactorSell.IdKala =ListOnekala.Id   AND  KalaFactorSell.Activ =1 ) As ListKala INNER JOIN ListFactorSell  On ListFactorSell.IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorSell.IdName UNION ALL SELECT   Fe,D_date  FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id )AS EndKala ORDER BY D_date  DESC ),0) AS Kol,ROUND((SELECT ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0) FROM (SELECT ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.id UNION ALL SELECT ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.id) AS AllKolCount),2) AS KolCount,ROUND((SELECT ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.id) AS AllJozCount),2) AS JozCount,DK FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,DK FROM Define_Kala INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed " & ListKala & ") AS ListOnekala) AS EndList) AS ListCom" & Sort
                    FrmPrint.CHoose = "LISTBUYSELLKALA"
                ElseIf RdoPromotion.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT ListKala_Discount.Idkala AS Wgt,Namfactor=CASE WHEN ListKala_Discount.AutoDiscount=0 THEN N'خیر' ELSE N'بله' END,ListKala_Discount.Coding As EndWgt,Define_Kala.Nam ,Define_Kala.Ex_Date As Disc,Kala_Discount.Joz AS EndJoz,Kala_Discount.Kol As EndKol,Kala_Discount.JozCount,Kala_Discount.KolCount,KolStr=(CASE WHEN Kala_Discount.Idkala IS NOT NULL THEN (SELECT Nam  FROM Define_Kala WHERE Id=Kala_Discount.Idkala ) ELSE (SELECT Nam  FROM Define_Service WHERE Id=Kala_Discount.IdService ) END ) FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id INNER JOIN Kala_Discount ON Kala_Discount.IdKalaLink =ListKala_Discount.Idkala " & ListKala & Sort
                    FrmPrint.CHoose = "LISTPROMOTIONKALA"
                End If
            Else
                If RdoEndSell.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT  Top 1 Fe FROM(SELECT Fe,D_date  FROM (SELECT  Fe,IdFactor  FROM KalaFactorSell  WHERE  KalaFactorSell.IdKala =ListOnekala.Id   AND  KalaFactorSell.Activ =1 ) As ListKala INNER JOIN ListFactorSell  On ListFactorSell.IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorSell.IdName UNION ALL SELECT   Fe,D_date  FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id )AS EndKala ORDER BY D_date  DESC ),0) AS Kol FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,Define_OneGroup.NamOne  + '-' + Define_TwoGroup .NamTwo AS GroupKala  FROM Define_Kala INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo " & ListKala & ") AS ListOnekala " & Sort
                    FrmPrint.CHoose = "LISTCOSTKALA"
                ElseIf RdoEndCity.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Wgt ,Namfactor ,EndWgt ,Nam ,Big ,Small ,EndCost ,REPLACE(KolCount,'.','/') As KolCount ,REPLACE(JozCount,'.','/') AS JozCount  FROM (SELECT Ex_Date,GroupKala,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT Top 1 CostBigKala FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Big,ISNULL((SELECT Top 1 CostSmalKala  FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Small,ISNULL((SELECT Top 1 EndCost FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS EndCost,ROUND((SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllKolCount),2) As KolCount,ROUND((SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllJozCount),2) AS JozCount FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,Define_OneGroup.NamOne  + '-' + Define_TwoGroup .NamTwo AS GroupKala  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo " & ListKala & " ) AS ListOnekala) As ListAll " & Mojody & Sort
                    If ChkNoMojodi.Checked = False Then
                        FrmPrint.CHoose = "LISTCOSTKALAALL"
                    Else
                        FrmPrint.CHoose = "LISTCOSTKALAALL2"
                    End If
                ElseIf RdoNoFe.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,Define_OneGroup.NamOne  + '-' + Define_TwoGroup .NamTwo AS GroupKala  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo " & ListKala & ") AS ListOnekala " & Sort
                    FrmPrint.CHoose = "LISTCOSTKALANF"
                ElseIf RdoEndCost.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT AVG(EndCost)  FROM (SELECT EndCost=CASE WHEN MonFac =0 or MonCharge =0 THEN Fe2  ELSE ROUND(((((Fe1 * Case  WHEN JozCount <=0 THEN KolCount else JozCount end )*MonCharge)/MonFac))/(Case  WHEN JozCount <=0 THEN KolCount else JozCount end)+Fe2 ,0)  END FROM (SELECT D_date ,IdFactor ,JozCount ,KolCount ,Fe As Fe1,ISNULL((Fe-(DarsadMon /(Case  WHEN JozCount>0 THEN JozCount ELSE KolCount END))),0) AS Fe2 ,(SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =AllK.IdFactor  AND ListFactorCharge.Activ =1) As MonCharge,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =AllK.IdFactor) As MonFac FROM (SELECT TOP 2 * FROM(SELECT KolCount ,JozCount ,Fe,DarsadMon,ListKala.IdFactor ,D_date FROM (SELECT  KalaFactorBuy .KolCount ,KalaFactorBuy .JozCount ,Fe,DarsadMon,KalaFactorBuy .IdFactor  FROM KalaFactorBuy  WHERE  KalaFactorBuy .IdKala =ListOnekala.Id AND KalaFactorBuy .Activ =1 ) As ListKala INNER JOIN ListFactorBuy  On ListFactorBuy .IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBuy .IdName UNION ALL SELECT  Count_Kol As KolCount, Count_Joz As JozCount, Fe,DarsadMon=0,IdFactor=0, D_date FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id  )AS EndKala  ORDER BY D_date   DESC) As AllK) As AllK2) As Allk3),0) AS Kol FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,Define_OneGroup.NamOne  + '-' + Define_TwoGroup .NamTwo AS GroupKala  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo" & ListKala & " ) AS ListOnekala " & Sort
                    FrmPrint.CHoose = "LISTCOSTKALA"
                ElseIf RdoMarjin.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Ex_Date As Disc,Wgt ,Namfactor ,EndWgt ,Nam ,Big ,Small ,EndCost,EndKol=REPLACE(ROUND(CASE WHEN Big>0 THEN ((EndCost -Big )*100)/Big ELSE 0 END,2),'.','/'),EndJoz=REPLACE(ROUND(CASE WHEN Small>0 THEN ((EndCost -Small )*100)/Small ELSE 0 END,2),'.','/')   FROM (SELECT Ex_Date,GroupKala,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT Top 1 CostBigKala FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Big,ISNULL((SELECT Top 1 CostSmalKala  FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS Small,ISNULL((SELECT Top 1 EndCost FROM Define_CostKala WHERE IdKala=ListOnekala.Id  AND IdCity =" & CmbCity.SelectedValue & "),0) AS EndCost,ROUND((SELECT ISNULL(SUM(AllKolCount.KolCount),0) FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllKolCount),2) As KolCount,ROUND((SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =ListOnekala.Id UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =ListOnekala.Id) AS AllJozCount),2) AS JozCount FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,Define_OneGroup.NamOne  + '-' + Define_TwoGroup .NamTwo AS GroupKala  FROM Define_Kala  INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo " & ListKala & " ) AS ListOnekala) As ListAll " & Mojody & Sort
                    FrmPrint.CHoose = "LISTCOSTKALAMARGIN"
                ElseIf RdoEndSellCost.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT Disc,Wgt,Namfactor ,EndWgt,Nam,Small,Kol ,EndJoz=Case WHEN Kol =0 THEN '0' ELSE REPLACE(ROUND(100-((Small *100)/Kol),2),'.','/') END,CASE WHEN Kol=0 THEN 0 ELSE Kol-Small END AS Big FROM (SELECT GroupKala,Ex_Date As Disc,Id As Wgt,Vahed As Namfactor,REPLACE(Karton,'.','/') As EndWgt,Nam,ISNULL((SELECT AVG(EndCost)  FROM (SELECT EndCost=CASE WHEN MonFac =0 or MonCharge =0 THEN Fe2  ELSE ROUND(((((Fe1 * Case  WHEN JozCount <=0 THEN KolCount else JozCount end )*MonCharge)/MonFac))/(Case  WHEN JozCount <=0 THEN KolCount else JozCount end)+Fe2 ,0)  END FROM (SELECT D_date ,IdFactor ,JozCount ,KolCount ,Fe As Fe1,ISNULL((Fe-(DarsadMon /(Case  WHEN JozCount>0 THEN JozCount ELSE KolCount END))),0) AS Fe2 ,(SELECT  ISNULL(SUM(Mon),0)  FROM  ListFactorCharge INNER JOIN KalaFactorCharge ON ListFactorCharge.Id = KalaFactorCharge.IdSanad WHERE  ListFactorCharge.IdFactor =AllK.IdFactor  AND ListFactorCharge.Activ =1) As MonCharge,(SELECT ISNULL(SUM(Mon),0) FROM KalaFactorBuy WHERE KalaFactorBuy.IdFactor =AllK.IdFactor) As MonFac FROM (SELECT TOP 2 * FROM(SELECT KolCount ,JozCount ,Fe,DarsadMon,ListKala.IdFactor ,D_date FROM (SELECT  KalaFactorBuy .KolCount ,KalaFactorBuy .JozCount ,Fe,DarsadMon,KalaFactorBuy .IdFactor  FROM KalaFactorBuy  WHERE  KalaFactorBuy .IdKala =ListOnekala.Id AND KalaFactorBuy .Activ =1 ) As ListKala INNER JOIN ListFactorBuy  On ListFactorBuy .IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorBuy .IdName UNION ALL SELECT  Count_Kol As KolCount, Count_Joz As JozCount, Fe,DarsadMon=0,IdFactor=0, D_date FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id  )AS EndKala  ORDER BY D_date   DESC) As AllK) As AllK2) As Allk3),0) AS Small,ISNULL((SELECT  Top 1 Fe FROM(SELECT Fe,D_date  FROM (SELECT  Fe,IdFactor  FROM KalaFactorSell  WHERE  KalaFactorSell.IdKala =ListOnekala.Id   AND  KalaFactorSell.Activ =1 ) As ListKala INNER JOIN ListFactorSell  On ListFactorSell.IdFactor =ListKala .IdFactor INNER JOIN Define_People ON Define_People.ID =ListFactorSell.IdName UNION ALL SELECT   Fe,D_date  FROM Define_PrimaryKala WHERE IdKala=ListOnekala.Id )AS EndKala ORDER BY D_date  DESC ),0) AS Kol FROM(SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Vahed .Nam As Vahed ,Karton=CASE DK WHEN 'TRUE' THEN ROUND(dk_joz/(CASE WHEN dk_kol<=0 THEN 1 ELSE dk_kol END),2) ELSE 1 END,Define_Kala.Nam,Define_OneGroup.NamOne  + '-' + Define_TwoGroup .NamTwo AS GroupKala  FROM Define_Kala INNER JOIN Define_Vahed On Define_Vahed.Id =Define_Kala .IdVahed INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala.IdCodeOne INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala.IdCodeTwo " & ListKala & ") AS ListOnekala ) AS EndList " & Sort
                    FrmPrint.CHoose = "LISTBUYSELLKALA"
                ElseIf RdoPromotion.Checked = True Then
                    FrmPrint.PrintSQl = "SELECT ListKala_Discount.Idkala AS Wgt,Namfactor=CASE WHEN ListKala_Discount.AutoDiscount=0 THEN N'خیر' ELSE N'بله' END,ListKala_Discount.Coding As EndWgt,Define_Kala.Nam ,Define_Kala.Ex_Date As Disc,Define_OneGroup.NamOne +'-'+ Define_TwoGroup.NamTwo As GroupKala ,Kala_Discount.Joz AS EndJoz,Kala_Discount.Kol As EndKol,Kala_Discount.JozCount,Kala_Discount.KolCount,KolStr=(CASE WHEN Kala_Discount.Idkala IS NOT NULL THEN (SELECT Nam  FROM Define_Kala WHERE Id=Kala_Discount.Idkala ) ELSE (SELECT Nam  FROM Define_Service WHERE Id=Kala_Discount.IdService ) END ) FROM ListKala_Discount INNER JOIN Define_Kala ON ListKala_Discount.Idkala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Kala_Discount ON Kala_Discount.IdKalaLink =ListKala_Discount.Idkala " & ListKala & Sort
                    FrmPrint.CHoose = "LISTPROMOTIONKALA"
                End If
            End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تابلوی قیمت", "تهيه گزارش", "", "")

                FrmPrint.ShowDialog()
        End Using
        Me.Enabled = True
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub RdoEndCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoEndCity.CheckedChanged
        If RdoEndCity.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            ChkShow.Enabled = True
            ChkNoMojodi.Enabled = True
            Me.Get_Ostan()
            CmbOstan_SelectedIndexChanged(Nothing, Nothing)
            CmbCity_SelectedIndexChanged(Nothing, Nothing)
            CmbOstan.Focus()
        Else
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            ChkShow.Enabled = False
            ChkNoMojodi.Checked = False
            ChkNoMojodi.Enabled = False
            CmbOstan.DataSource = Nothing
            CmbCity.DataSource = Nothing
        End If
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            CmbCity.DataSource = Nothing
            Me.Get_City(CmbOstan.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged

    End Sub
    Private Sub Get_Ostan()
        Try
            Dim Ds_O As New DataTable
            Dim Dta_O As New SqlDataAdapter
            If Not Dta_O Is Nothing Then Dta_O.Dispose()
            Dta_O = New SqlDataAdapter("SELECT Code,NamO FROM Define_Ostan", DataSource)
            Dta_O.Fill(Ds_O)
            CmbOstan.DataSource = Ds_O
            CmbOstan.DisplayMember = "NamO"
            CmbOstan.ValueMember = "Code"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_Ostan")
            Me.Close()
        End Try
    End Sub
    Private Sub Get_City(ByVal Id As Long)
        Try
            Dim Ds_C As New DataTable
            Dim Dta_C As New SqlDataAdapter
            If Not Dta_C Is Nothing Then Dta_C.Dispose()
            Dta_C = New SqlDataAdapter("SELECT Code,NamCi FROM Define_City WHERE IdOstan=" & Id, DataSource)
            Dta_C.Fill(Ds_C)
            CmbCity.DataSource = Ds_C
            CmbCity.DisplayMember = "NamCi"
            CmbCity.ValueMember = "Code"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_City")
            Me.Close()
        End Try
    End Sub

    Private Sub RdoNoFe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoNoFe.CheckedChanged
        If RdoNoFe.Checked = True Then
            If RdoCost.Checked = True Then RdoGroup.Checked = True
            RdoCost.Enabled = False
        Else
            RdoCost.Enabled = True
        End If
    End Sub

    Private Sub RdoMarjin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoMarjin.CheckedChanged
        If RdoMarjin.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            ChkShow.Enabled = True
            If RdoCost.Checked = True Then RdoGroup.Checked = True
            RdoCost.Enabled = False
            Me.Get_Ostan()
            CmbOstan_SelectedIndexChanged(Nothing, Nothing)
            CmbCity_SelectedIndexChanged(Nothing, Nothing)
            CmbOstan.Focus()
        Else
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            ChkShow.Enabled = False
            RdoCost.Enabled = True
            CmbOstan.DataSource = Nothing
            CmbCity.DataSource = Nothing
        End If
    End Sub

    Private Sub RdoPromotion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoPromotion.CheckedChanged
        If RdoPromotion.Checked = True Then
            RdoCost.Enabled = False
            RdoKala.Checked = True
        Else
            RdoCost.Enabled = True
        End If
    End Sub

    Private Sub RdoEndCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoEndCost.CheckedChanged
        If RdoEndCost.Checked = True Then
            RdoG.Enabled = False
            RdoKala.Checked = True
        Else
            RdoG.Enabled = True
        End If
    End Sub

    Private Sub RdoEndSellCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoEndSellCost.CheckedChanged
        If RdoEndCost.Checked = True Then
            RdoG.Enabled = False
            RdoKala.Checked = True
        Else
            RdoG.Enabled = True
        End If
    End Sub
End Class