Imports System.Data.SqlClient
Public Class ReportFroshAllVisitor

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

    Private Sub ReportFroshAllUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub ReportFroshAllUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F114")
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
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Me.GetVisitorList()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            If CBool(DGV.Item("Cln_Activ", i).Value) = False Then DGV.Item("Cln_Select", i).Value = True
        Next
    End Sub

    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DGV.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString("رديف", DGV.DefaultCellStyle.Font, b, DGV.Size.Width - 40, 6)
            e.Graphics.DrawString(e.RowIndex + 1, DGV.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV.Size.Width - 40, e.RowBounds.Location.Y)
        End Using
        If CBool(DGV.Item("Cln_Activ", e.RowIndex).Value) = True Then
            DGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If DGV.RowCount <= 0 Then
                MessageBox.Show("ویزیتوری وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("محدوده تاریخ مشخص نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If ChkAzDate.Checked = True Then
                    If String.IsNullOrEmpty(FarsiDate1.ThisText) Then
                        MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkTaDate.Checked = True Then
                    If String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                        MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

            End If

            Dim ListUser As String = ""
            Dim CountUser As Long = 0
            ListUser = " WHERE ("
            For i As Integer = 0 To DGV.RowCount - 1
                If DGV.Item("Cln_Select", i).Value = True Then
                    ListUser &= "ID=" & DGV.Item("Cln_IdP", i).Value & " OR "
                    CountUser += 1
                End If
            Next

            If CountUser = DGV.RowCount Then
                ListUser = ""
            ElseIf CountUser <= 0 Then
                MessageBox.Show("ویزیتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                ListUser = ListUser.Substring(0, ListUser.Length - 4)
                ListUser &= ")"
            End If

            Dim dat As String = ""
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
            Else
                dat = ""
            End If

            If ChkTime.Checked = False Then
                FrmPrint.Str1 = ""
                FrmPrint.State = ""
            Else
                FrmPrint.Str1 = ""
                FrmPrint.State = ""
                If ChkAzDate.Checked = True Then FrmPrint.Str1 = FarsiDate1.ThisText
                If ChkTaDate.Checked = True Then FrmPrint.State = FarsiDate2.ThisText
            End If

            Me.Enabled = False
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "جمع فروش ویزیتورها", "تهیه گزارش", "", "")

            FrmPrint.CHoose = "FROSHALLVISITOR"
            'FrmPrint.PrintSQl = "DECLARE @FroshK float SET @FroshK =(SELECT (Frosh.MonSell-Backfrosh.MonBack-Discount.Darsad) AS EndFrosh FROM (SELECT ISNULL(SUM(Mon),0) As MonSell FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & dat & " )As Frosh,(SELECT ISNULL(SUM(Mon),0) As MonBack FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1 " & dat & " )As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1 " & dat & " And ListFactorSell.Stat =3 AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1 " & dat & " And ListFactorSell.Stat =3 AND Discount >0 )  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1 " & dat & "  AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1 " & dat & "  AND  Discount >0 )) AS AllDiscount) As Discount) SELECT Id,Nam,Frosh,Backfrosh,Discount,(Frosh-Backfrosh-Discount) AS EndFrosh,DarsadEndFrosh=CASE WHEN @FroshK<=0 THEN '0' ELSE REPLACE(ROUND((Frosh-Backfrosh-Discount)*100/@FroshK,2),'.','/') END,CountFactor,CountKala,REPLACE(SumRow ,'.','/') As SumRow,Row=CASE WHEN CountRow<=0 OR CountFactor<=0 THEN '0' ELSE REPLACE(CAST(ROUND(CAST(CountRow As Float) / CountFactor,2) AS Nvarchar(max)) ,'.','/') END,(0) As DelayFactor,(0) As MandehFactor FROM (SELECT Id,Nam ,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 AND IdVisitor =ListUser.Id " & dat & ")As Frosh,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1  AND IdVisitor =ListUser.Id " & dat & ")As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =ListUser.Id And ListFactorSell.Stat =3 AND DarsadMon >0 " & dat & ")  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =ListUser.Id And ListFactorSell.Stat =3 AND Discount >0 " & dat & ")  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =ListUser.Id  AND DarsadMon >0 " & dat & ")  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =ListUser.Id  AND Discount >0 " & dat & ")) AS AllDiscount) As Discount,(SELECT SUM(CC) FROM (SELECT Count(IdFactor) AS CC FROM  ListFactorSell WHERE Activ =1 AND Stat =3 AND IdVisitor =ListUser.Id " & dat & " UNION ALL SELECT Count(IdFactor) * -1 AS CC FROM  ListFactorbackSell WHERE Activ =1  AND IdVisitor =ListUser.Id " & dat & ")AS AllCountFac) As CountFactor,(SELECT SUM(CK) FROM (SELECT COUNT(DISTINCT KalaFactorSell.IdKala) AS CK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor = ListUser.Id " & dat & " )))AS AllCountKala)As CountKala,(SELECT SUM(RK) FROM (SELECT COUNT(KalaFactorSell.IdKala) AS RK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor = ListUser.Id  " & dat & " )))AS AllCountRo)As CountRow,(SELECT SUM(SR) FROM (SELECT ISNULL(SUM(KalaFactorSell.KolCount),0) AS SR FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor = ListUser.Id " & dat & " )))AS AllSumRo)As SumRow  FROM (SELECT Nam, Id FROM Define_Visitor " & ListUser & ")AS ListUser) As AllList"
            FrmPrint.PrintSQl = "DECLARE @FroshK float SET @FroshK =(SELECT (Frosh.MonSell-Backfrosh.MonBack-Discount.Darsad) AS EndFrosh FROM (SELECT ISNULL(SUM(Mon),0) As MonSell FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & dat & " )As Frosh,(SELECT ISNULL(SUM(Mon),0) As MonBack FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1 " & dat & " )As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1 " & dat & " And ListFactorSell.Stat =3 AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1 " & dat & " And ListFactorSell.Stat =3 AND Discount >0 )  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1 " & dat & "  AND DarsadMon >0 )  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1 " & dat & "  AND  Discount >0 )) AS AllDiscount) As Discount) SELECT Id,Nam,Frosh,Backfrosh,Discount,(Frosh-Backfrosh-Discount) AS EndFrosh,DarsadEndFrosh=CASE WHEN @FroshK<=0 THEN '0' ELSE REPLACE(ROUND((Frosh-Backfrosh-Discount)*100/@FroshK,2),'.','/') END,CountFactor,CountKala,REPLACE(SumRow ,'.','/') As SumRow,Row=CASE WHEN CountRow=0 OR CountFactor=0 THEN '0' ELSE REPLACE(CAST(ROUND(CAST(CountRow As Float) / CountFactor,2) AS Nvarchar(max)) ,'.','/') END,(0) As DelayFactor,(0) As MandehFactor FROM (SELECT Id,Nam,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 AND IdVisitor =ListUser.Id " & dat & " )As Frosh,(SELECT  ISNULL(SUM(Mon),0) FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorbackSell.Activ =1  AND IdVisitor =ListUser.Id " & dat & " )As BackFrosh,(SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =ListUser.Id And ListFactorSell.Stat =3 AND DarsadMon >0 " & dat & " )  UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell  WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =ListUser.Id And ListFactorSell.Stat =3 AND Discount >0 " & dat & " )  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =ListUser.Id  AND DarsadMon >0 " & dat & " )  UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell   WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =ListUser.Id  AND Discount >0 " & dat & " )) AS AllDiscount) As Discount,(SELECT SUM(CC) FROM (SELECT Count(IdFactor) AS CC FROM  ListFactorSell WHERE Activ =1 AND Stat =3 AND IdVisitor =ListUser.Id " & dat & "   UNION ALL SELECT Count(IdFactor) * -1 AS CC FROM  ListFactorbackSell WHERE Activ =1  AND IdVisitor =ListUser.Id " & dat & " )AS AllCountFac) As CountFactor,(SELECT SUM(CK) FROM (SELECT COUNT(DISTINCT KalaFactorSell.IdKala) AS CK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor = ListUser.Id " & dat & " )) UNION ALL SELECT COUNT(DISTINCT KalaFactorBackSell.IdKala) *-1 AS CK FROM KalaFactorBackSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorBackSell WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor = ListUser.Id " & dat & " )))AS AllCountKala)As CountKala,(SELECT SUM(RK) FROM (SELECT COUNT(KalaFactorSell.IdKala) AS RK FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor = ListUser.Id " & dat & " )) UNION ALL SELECT COUNT(KalaFactorBackSell.IdKala) * -1 AS RK FROM KalaFactorBackSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorBackSell WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor = ListUser.Id " & dat & " )))AS AllCountRo)As CountRow,(SELECT SUM(SR) FROM (SELECT ISNULL(SUM(KalaFactorSell.KolCount),0) AS SR FROM KalaFactorSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor = ListUser.Id " & dat & " )) UNION ALL SELECT ISNULL(SUM(KalaFactorBackSell.KolCount),0) * -1 AS SR FROM KalaFactorBackSell WHERE IdFactor IN (SELECT IdFactor FROM ListFactorBackSell WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor = ListUser.Id " & dat & " )))AS AllSumRo)As SumRow FROM (SELECT Nam, Id FROM Define_Visitor " & ListUser & ")AS ListUser) As AllList"
            FrmPrint.ShowDialog()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportFroshAllVisitor", "BtnOk_Click")
        End Try
    End Sub

    Private Sub GetVisitorList()
        Try
            Dim ds_User As New DataTable
            Dim dta_User As New SqlDataAdapter()

            ds_User.Clear()
            If Not dta_User Is Nothing Then
                dta_User.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_User = New SqlDataAdapter("SELECT Id, Nam ,Activ FROM Define_Visitor", DataSource)
            dta_User.Fill(ds_User)
            DGV.DataSource = ds_User
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ReportFroshAllVisitor", "GetVisitorList")
        End Try
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "SumFroshVizitor.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetVisitorList()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class