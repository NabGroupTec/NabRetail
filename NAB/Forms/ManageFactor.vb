Imports System.Data.SqlClient
Public Class ManageFactor
    Dim ds As New DataTable
    Dim dv As New DataView
    Private Sub GetFactor()
        Try
            ds.Clear()
            Dim query As String = SetQuery()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(query, ConectionBank)
                cmd.CommandTimeout = 0
                ds.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV1.AutoGenerateColumns = False
            dv = ds.DefaultView
            dv.Sort = "D_Date,PName,Kind,MonFac,IdFactor"
            DGV1.DataSource = dv
            Me.CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "GetFactor")
        End Try
    End Sub
    Private Function SetQuery() As String
        Try
            Dim condition As String = ""
            Dim conDate As String = ""

            If Rdomon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    condition = " WHERE (MonFac>=" & CDbl(TxtMon1.Text) & " AND MonFac<=" & CDbl(TxtMon2.Text) & ")"
                ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                    condition = " WHERE (MonFac>=" & CDbl(TxtMon1.Text) & ")"
                ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                    condition = " WHERE (MonFac<=" & CDbl(TxtMon2.Text) & ")"
                End If
            ElseIf Rdoid.Checked = True Then
                condition = " WHERE (IdFactor=" & CLng(TxtIdFac.Text) & ")"
            ElseIf RdoExitFactor.Checked = True Then
                condition = " WHERE (IdFactor IN (" & GetExitFac2(CLng(TxtExit.Text)) & "))"
            ElseIf Rdonam.Checked = True Then
                condition = " WHERE (IdName=" & CLng(TxtIdName.Text) & ")"
            ElseIf RdoSanad.Checked = True Then
                condition = " WHERE (Sanad=N'" & TxtSanad.Text & "')"
            ElseIf RdoPart.Checked = True Then
                condition = " WHERE (Part=" & TxtIdPart.Text & ")"
            ElseIf RdoVisit.Checked = True Then
                condition = " WHERE (IdVisitor=" & TxtIdVisit.Text & ")"
            ElseIf RdoUser.Checked = True Then
                condition = " WHERE (IdUser=" & TxtIdUser.Text & ")"
            End If

            If ChkDate.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    conDate = " (D_Date>=N'" & FarsiDate1.ThisText & "' AND D_Date<=N'" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    conDate = " (D_Date>=N'" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    conDate = " (D_Date<=N'" & FarsiDate2.ThisText & "')"
                End If

                If String.IsNullOrEmpty(condition) Then
                    conDate = " WHERE " & conDate
                Else
                    conDate = " AND " & conDate
                End If
            End If

            Dim KHARID As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorBuy.*,LendMon=CASE WHEN  (AllFactorBuy.MonFac -AllFactorBuy.Discount -AllFactorBuy.DarsadMon-AllFactorBuy.Cash -AllFactorBuy.MonHavaleh -AllFactorBuy.ChkMon) < 0 THEN 0 Else (AllFactorBuy.MonFac -AllFactorBuy.Discount -AllFactorBuy.DarsadMon-AllFactorBuy.Cash -AllFactorBuy.MonHavaleh -AllFactorBuy.ChkMon)End FROM (SELECT  ListFactorBuy.MonAdd,ListFactorBuy.MonDec,ListFactorBuy.IdName,ListFactorBuy.IdUser,ListFactorBuy.IdVisitor,ListFactorBuy.IdFactor,Kind=N'خرید', ListFactorBuy.D_date, ListFactorBuy.Sanad, ListFactorBuy.Part, ListFactorBuy.Disc, ListFactorBuy.Discount, ListFactorBuy.Cash, ListFactorBuy.MonHavaleh, (ListFactorBuy.MonSellChk+ ListFactorBuy.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorBuy.Mon ),0)  FROM KalaFactorBuy WHERE IdFactor =ListFactorBuy.IdFactor)+ListFactorBuy.MonAdd -ListFactorBuy.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorBuy.DarsadMon ),0)  FROM KalaFactorBuy WHERE IdFactor =ListFactorBuy.IdFactor)As DarsadMon FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID  WHERE ListFactorBuy.Activ =1  AND ListFactorBuy.Stat =0 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorBuy)AllBuy " & condition & conDate
            Dim BackKHARID As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorBBuy.*,LendMon=CASE WHEN  (AllFactorBBuy.MonFac -AllFactorBBuy.Discount -AllFactorBBuy.DarsadMon-AllFactorBBuy.Cash -AllFactorBBuy.MonHavaleh -AllFactorBBuy.ChkMon) < 0 THEN 0 Else (AllFactorBBuy.MonFac -AllFactorBBuy.Discount -AllFactorBBuy.DarsadMon-AllFactorBBuy.Cash -AllFactorBBuy.MonHavaleh -AllFactorBBuy.ChkMon)End FROM (SELECT  ListFactorBackBuy.MonAdd,ListFactorBackBuy.MonDec,ListFactorBackBuy.IdName,ListFactorBackBuy.IdUser,ListFactorBackBuy.IdVisitor,ListFactorBackBuy.IdFactor,Kind=N'برگشت از خرید', ListFactorBackBuy.D_date, ListFactorBackBuy.Sanad, ListFactorBackBuy.Part, ListFactorBackBuy.Disc, ListFactorBackBuy.Discount, ListFactorBackBuy.Cash, ListFactorBackBuy.MonHavaleh, (ListFactorBackBuy.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorBackBuy.Mon ),0)  FROM KalaFactorBackBuy WHERE IdFactor =ListFactorBackBuy.IdFactor)+ListFactorBackBuy.MonAdd -ListFactorBackBuy.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorBackBuy.DarsadMon ),0)  FROM KalaFactorBackBuy WHERE IdFactor =ListFactorBackBuy.IdFactor)As DarsadMon FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID  WHERE ListFactorBackBuy.Activ =1  AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorBBuy)AllBBuy " & condition & conDate
            Dim AmaniKHARID As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorABuy.*,LendMon=CASE WHEN  (AllFactorABuy.MonFac -AllFactorABuy.Discount -AllFactorABuy.DarsadMon-AllFactorABuy.Cash -AllFactorABuy.MonHavaleh -AllFactorABuy.ChkMon) < 0 THEN 0 Else (AllFactorABuy.MonFac -AllFactorABuy.Discount -AllFactorABuy.DarsadMon-AllFactorABuy.Cash -AllFactorABuy.MonHavaleh -AllFactorABuy.ChkMon)End FROM (SELECT  ListFactorBuy.MonAdd,ListFactorBuy.MonDec,ListFactorBuy.IdName,ListFactorBuy.IdUser,ListFactorBuy.IdVisitor,ListFactorBuy.IdFactor,Kind=N'خرید امانی', ListFactorBuy.D_date, ListFactorBuy.Sanad, ListFactorBuy.Part, ListFactorBuy.Disc, ListFactorBuy.Discount, ListFactorBuy.Cash, ListFactorBuy.MonHavaleh, (ListFactorBuy.MonSellChk+ ListFactorBuy.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorBuy.Mon ),0)  FROM KalaFactorBuy WHERE IdFactor =ListFactorBuy.IdFactor)+ListFactorBuy.MonAdd -ListFactorBuy.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorBuy.DarsadMon ),0)  FROM KalaFactorBuy WHERE IdFactor =ListFactorBuy.IdFactor)As DarsadMon FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1  AND ListFactorBuy.Stat =2 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorABuy)AllABuy " & condition & conDate
            Dim Sell As String = "SELECT IdExit=(SELECT IdList FROM ListExitFactor WHERE IdFactor =AllSell.IdFactor ),IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorSell.*,LendMon=CASE WHEN  (AllFactorSell.MonFac -AllFactorSell.Discount -AllFactorSell.DarsadMon-AllFactorSell.Cash -AllFactorSell.MonHavaleh -AllFactorSell.ChkMon) < 0 THEN 0 Else (AllFactorSell.MonFac -AllFactorSell.Discount -AllFactorSell.DarsadMon-AllFactorSell.Cash -AllFactorSell.MonHavaleh -AllFactorSell.ChkMon)End FROM (SELECT  ListFactorSell.MonAdd,ListFactorSell.MonDec,ListFactorSell.IdName,ListFactorSell.IdUser,ListFactorSell.IdVisitor,ListFactorSell.IdFactor,Kind=N'فروش', ListFactorSell.D_date, ListFactorSell.Sanad, ListFactorSell.Part, ListFactorSell.Disc, ListFactorSell.Discount, ListFactorSell.Cash, ListFactorSell.MonHavaleh, (ListFactorSell.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorSell.Mon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)+ListFactorSell.MonAdd -ListFactorSell.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorSell.DarsadMon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)As DarsadMon FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE ListFactorSell.Activ =1  AND ListFactorSell.Stat =3 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorSell)AllSell " & condition & conDate
            Dim BackSell As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorBSell.*,LendMon=CASE WHEN  (AllFactorBSell.MonFac -AllFactorBSell.Discount -AllFactorBSell.DarsadMon-AllFactorBSell.Cash -AllFactorBSell.MonHavaleh -AllFactorBSell.ChkMon) < 0 THEN 0 Else (AllFactorBSell.MonFac -AllFactorBSell.Discount -AllFactorBSell.DarsadMon-AllFactorBSell.Cash -AllFactorBSell.MonHavaleh -AllFactorBSell.ChkMon)End FROM (SELECT ListFactorBackSell.MonAdd,ListFactorBackSell.MonDec,ListFactorBackSell.IdName,ListFactorBackSell.IdUser,ListFactorBackSell.IdVisitor,ListFactorBackSell.IdFactor,Kind=N'برگشت از فروش', ListFactorBackSell.D_date, ListFactorBackSell.Sanad, ListFactorBackSell.Part, ListFactorBackSell.Disc, ListFactorBackSell.Discount, ListFactorBackSell.Cash, ListFactorBackSell.MonHavaleh, (ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorBackSell.Mon ),0)  FROM KalaFactorBackSell WHERE IdFactor =ListFactorBackSell.IdFactor)+ListFactorBackSell.MonAdd -ListFactorBackSell.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorBackSell.DarsadMon ),0)  FROM KalaFactorBackSell WHERE IdFactor =ListFactorBackSell.IdFactor)As DarsadMon FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID  WHERE ListFactorBackSell.Activ =1 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorBSell)AllBSell " & condition & conDate
            Dim AmaniSell As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorASell.*,LendMon=CASE WHEN  (AllFactorASell.MonFac -AllFactorASell.Discount -AllFactorASell.DarsadMon-AllFactorASell.Cash -AllFactorASell.MonHavaleh -AllFactorASell.ChkMon) < 0 THEN 0 Else (AllFactorASell.MonFac -AllFactorASell.Discount -AllFactorASell.DarsadMon-AllFactorASell.Cash -AllFactorASell.MonHavaleh -AllFactorASell.ChkMon)End FROM (SELECT  ListFactorSell.MonAdd,ListFactorSell.MonDec,ListFactorSell.IdName,ListFactorSell.IdUser,ListFactorSell.IdVisitor,ListFactorSell.IdFactor,Kind=N'فروش امانی', ListFactorSell.D_date, ListFactorSell.Sanad, ListFactorSell.Part, ListFactorSell.Disc, ListFactorSell.Discount, ListFactorSell.Cash, ListFactorSell.MonHavaleh, (ListFactorSell.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorSell.Mon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)+ListFactorSell.MonAdd -ListFactorSell.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorSell.DarsadMon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)As DarsadMon FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID  WHERE ListFactorSell.Activ =1  AND ListFactorSell.Stat =5 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorASell)AllASell " & condition & conDate
            Dim PishSell As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorPSell.*,LendMon=CASE WHEN  (AllFactorPSell.MonFac -AllFactorPSell.Discount -AllFactorPSell.DarsadMon-AllFactorPSell.Cash -AllFactorPSell.MonHavaleh -AllFactorPSell.ChkMon) < 0 THEN 0 Else (AllFactorPSell.MonFac -AllFactorPSell.Discount -AllFactorPSell.DarsadMon-AllFactorPSell.Cash -AllFactorPSell.MonHavaleh -AllFactorPSell.ChkMon)End FROM (SELECT  ListFactorSell.MonAdd,ListFactorSell.MonDec,ListFactorSell.IdName,ListFactorSell.IdUser,ListFactorSell.IdVisitor,ListFactorSell.IdFactor,Kind=N'پیش فاکتور', ListFactorSell.D_date, ListFactorSell.Sanad, ListFactorSell.Part, ListFactorSell.Disc, ListFactorSell.Discount, ListFactorSell.Cash, ListFactorSell.MonHavaleh, (ListFactorSell.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorSell.Mon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)+ListFactorSell.MonAdd -ListFactorSell.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorSell.DarsadMon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)As DarsadMon FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID   WHERE ListFactorSell.Activ =1  AND ListFactorSell.Stat =7 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorPSell)AllPSell " & condition & conDate
            Dim Damage As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT  MonAdd=0,MonDec=0,IdName=0,IdUser,IdVisitor=0,ListFactorDamage.IdFactor,Kind=N'ضایعات', ListFactorDamage.D_date, ListFactorDamage.Sanad, ListFactorDamage.Part , ListFactorDamage.Disc, Discount=0, Cash=0, MonHavaleh=0, ChkMon=0, Pname=N'فاکتور ضایعات',((SELECT ISNULL(SUM(KalaFactorDamage .Mon ),0)as MonFac  FROM KalaFactorDamage WHERE IdFactor =ListFactorDamage.IdFactor))As MonFac,DarsadMon=0,LendMon=0 FROM ListFactorDamage  WHERE ListFactorDamage .Activ =1 AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")AllDamage " & condition & conDate
            Dim Service As String = "SELECT IdExit=NULL,IdName ,IdFactor ,Kind ,D_date ,Sanad ,NamPart=CASE WHEN Part IS NULL THEN N'' ELSE (SELECT nam FROM Define_PartKala WHERE ID=Part ) END,Part ,Disc ,Discount ,Cash ,MonHavaleh ,ChkMon ,Pname ,IdUser,IdVisitor ,DarsadMon ,LendMon ,(MonFac -DarsadMon -Discount ) as MonPayFac,(MonFac-MonAdd +MonDec )As MonFac FROM(SELECT AllFactorService.*,LendMon=CASE WHEN  (AllFactorService.MonFac -AllFactorService.Discount -AllFactorService.DarsadMon-AllFactorService.Cash -AllFactorService.MonHavaleh -AllFactorService.ChkMon) < 0 THEN 0 Else (AllFactorService.MonFac -AllFactorService.Discount -AllFactorService.DarsadMon-AllFactorService.Cash -AllFactorService.MonHavaleh -AllFactorService.ChkMon)End FROM (SELECT ListFactorService.MonAdd,ListFactorService.MonDec,ListFactorService.IdName,ListFactorService.IdUser,ListFactorService.IdVisitor,ListFactorService.IdFactor,Kind=N'خدمات', ListFactorService.D_date, ListFactorService.Sanad, ListFactorService.Part, ListFactorService.Disc, ListFactorService.Discount, ListFactorService.Cash, ListFactorService.MonHavaleh, (ListFactorService.MonPayChk) As ChkMon, Define_People.Nam As Pname,((SELECT ISNULL(SUM(KalaFactorService.Mon ),0)  FROM KalaFactorService WHERE IdFactor =ListFactorService.IdFactor)+ListFactorService.MonAdd -ListFactorService.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorService.DarsadMon ),0)  FROM KalaFactorService WHERE IdFactor =ListFactorService.IdFactor)As DarsadMon FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1  AND IdUser " & If(Kind_User = 0, "=" & Id_User, "<>0") & ")As AllFactorService)AllService " & condition & conDate

            Dim StrSql As String = ""
            If ChkLimit.Checked = True Then
                If CmbFac.Text = CmbFac.Items.Item(0) Then
                    StrSql = KHARID
                ElseIf CmbFac.Text = CmbFac.Items.Item(1) Then
                    StrSql = BackKHARID
                ElseIf CmbFac.Text = CmbFac.Items.Item(2) Then
                    StrSql = AmaniKHARID
                ElseIf CmbFac.Text = CmbFac.Items.Item(3) Then
                    StrSql = Sell
                ElseIf CmbFac.Text = CmbFac.Items.Item(4) Then
                    StrSql = BackSell
                ElseIf CmbFac.Text = CmbFac.Items.Item(5) Then
                    StrSql = AmaniSell
                ElseIf CmbFac.Text = CmbFac.Items.Item(6) Then
                    StrSql = Damage
                ElseIf CmbFac.Text = CmbFac.Items.Item(7) Then
                    StrSql = PishSell
                ElseIf CmbFac.Text = CmbFac.Items.Item(8) Then
                    StrSql = Service
                End If
            Else
                StrSql = KHARID & " UNION ALL " & BackKHARID & " UNION ALL " & AmaniKHARID & " UNION ALL " & Sell & " UNION ALL " & BackSell & " UNION ALL " & AmaniSell & " UNION ALL " & Damage & " UNION ALL " & PishSell & " UNION ALL " & Service
            End If
            Return StrSql
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "SetQuery")
            Me.Close()
            Return ""
        End Try
    End Function

    Private Sub ManageFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub
    Private Sub ManageFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not (String.IsNullOrEmpty(Trial)) Then
            If GetDate() > Trial Then
                MessageBox.Show("اعتبار زمانی استفاده از برنامه به اتمام رسیده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End
            End If
        End If

        Access_Form = Get_Access_Form("F40")
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
        TxtMonFac.Text = 0
        TxtDiscountC.Text = 0
        TxtDiscountH.Text = 0

        DGV1.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetButton()
        If RdoExitFactor.Checked = True Then
            BtnShow_Click(Nothing, Nothing)
            SendKeys.Send("{F9}")
        Else
            CmbFac.Text = CmbFac.Items.Item(0)
            Rdotime.Checked = True
            ChkDate.Checked = True
            Me.GetFactor()
        End If
    End Sub

    Private Sub SetButton()
        Try
            Access_Form = Get_Access_Form("F40")
            If (Access_Form <> "-1") Then
                If String.IsNullOrEmpty(Access_Form) Then
                    BtnDel.Enabled = False
                    Btn_Showfactor.Enabled = False
                    BtnEdit.Enabled = False
                    BtnPrintFac.Enabled = False
                    BtnPrintResed.Enabled = False
                    BtnPrintFish.Enabled = False
                    BtnSendSMS.Enabled = False
                    BtnConvert.Enabled = False
                    BtnPrintList.Enabled = False
                Else
                    If Access_Form.Substring(2, 1) = 0 Then
                        BtnDel.Enabled = False
                        Btn_Showfactor.Enabled = False
                        BtnEdit.Enabled = False
                        BtnPrintFac.Enabled = False
                        BtnPrintResed.Enabled = False
                        BtnPrintFish.Enabled = False
                        BtnSendSMS.Enabled = False
                        BtnConvert.Enabled = False
                        BtnPrintList.Enabled = False
                    Else
                        If Access_Form.Substring(3, 1) = 0 Then
                            BtnDel.Enabled = False
                        End If
                        If Access_Form.Substring(4, 1) = 0 Then
                            Btn_Showfactor.Enabled = False
                        End If
                        If Access_Form.Substring(5, 1) = 0 Then
                            BtnEdit.Enabled = False
                        End If
                        If Access_Form.Substring(6, 1) = 0 Then
                            BtnPrintFac.Enabled = False
                        End If
                        If Access_Form.Substring(7, 1) = 0 Then
                            BtnPrintResed.Enabled = False
                        End If
                        If Access_Form.Substring(8, 1) = 0 Then
                            BtnPrintFish.Enabled = False
                        End If
                        Try
                            If Access_Form.Substring(9, 1) = 0 Then
                                BtnAllPrint.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnAllPrint.Enabled = False
                        End Try

                        Try
                            If Access_Form.Substring(10, 1) = 0 Then
                                BtnSendSMS.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnSendSMS.Enabled = False
                        End Try

                        Try
                            If Access_Form.Substring(11, 1) = 0 Then
                                BtnConvert.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnConvert.Enabled = False
                        End Try

                        Try
                            If Access_Form.Substring(12, 1) = 0 Then
                                BtnPrintList.Enabled = False
                            End If
                        Catch ex As Exception
                            BtnPrintList.Enabled = False
                        End Try

                    End If
                End If
            End If

            If AllowEdit < 0 Then
                MessageBox.Show("وضعیت دوره مالی نا مشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            ElseIf AllowEdit = 1 Then
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                BtnConvert.Enabled = False
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "SetButton")
            Me.Close()
        End Try
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

    Private Sub ChkAzMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzMon.CheckedChanged
        If ChkAzMon.Checked = True Then
            TxtMon1.Text = "0"
            TxtMon1.Enabled = True
            TxtMon1.Focus()
            TxtMon1.SelectAll()
        Else
            TxtMon1.Text = "0"
            TxtMon1.Enabled = False
        End If
    End Sub

    Private Sub ChkTaMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaMon.CheckedChanged
        If ChkTaMon.Checked = True Then
            TxtMon2.Text = "0"
            TxtMon2.Enabled = True
            TxtMon2.Focus()
            TxtMon2.SelectAll()
        Else
            TxtMon2.Text = "0"
            TxtMon2.Enabled = False
        End If
    End Sub

    Private Sub TxtMon1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtMon2.Enabled = True Then
                TxtMon2.Focus()
            Else
                Call BtnShow_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub TxtMon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon1.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TxtMon1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon1.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon1.Text.Replace(",", "")))) Then
                TxtMon1.Text = "0"
                TxtMon1.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon1.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon1.Text.Replace(",", ""))
                TxtMon1.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon1.Text = CDbl(TxtMon1.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMon2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMon2.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtMon2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMon2.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TxtMon2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMon2.TextChanged
        Try
            If Not (CheckDigit(Format$(TxtMon2.Text.Replace(",", "")))) Then
                TxtMon2.Text = "0"
                TxtMon2.SelectAll()
                Exit Sub
            End If
            Dim str As String
            If TxtMon2.Text.Length > 3 Then
                SendKeys.Send("{end}")
                str = Format$(TxtMon2.Text.Replace(",", ""))
                TxtMon2.Text = Format$(Val(str), "###,###,###")
            Else
                TxtMon2.Text = CDbl(TxtMon2.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rdomon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdomon.CheckedChanged
        If Rdomon.Checked = True Then
            ChkAzMon.Visible = True
            ChkTaMon.Visible = True
            TxtMon1.Visible = True
            TxtMon2.Visible = True
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            TxtMon1.Focus()
        Else
            ChkAzMon.Checked = False
            ChkTaMon.Checked = False
            ChkAzMon.Visible = False
            ChkTaMon.Visible = False
            TxtMon1.Visible = False
            TxtMon2.Visible = False
            TxtMon1.Enabled = False
            TxtMon2.Enabled = False
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
        End If
    End Sub

    Private Sub TxtIdFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIdFac.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtIdFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIdFac.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Try

            If Rdoid.Checked = True Then
                If String.IsNullOrEmpty(TxtIdFac.Text) Then
                    MessageBox.Show("شماره فاکتور را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtIdFac.Focus()
                    Exit Sub
                End If
            End If
            If Rdonam.Checked = True Then
                If String.IsNullOrEmpty(Txtname.Text) Or String.IsNullOrEmpty(TxtIdName.Text) Then
                    MessageBox.Show("طرف حساب را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Txtname.Focus()
                    Exit Sub
                End If
            End If
            If RdoVisit.Checked = True Then
                If String.IsNullOrEmpty(TxtNameVisit.Text) Or String.IsNullOrEmpty(TxtIdVisit.Text) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNameVisit.Focus()
                    Exit Sub
                End If
            End If

            If RdoUser.Checked = True Then
                If String.IsNullOrEmpty(TxtUser.Text) Or String.IsNullOrEmpty(TxtIdUser.Text) Then
                    MessageBox.Show("کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtUser.Focus()
                    Exit Sub
                End If
            End If

            If RdoSanad.Checked = True Then
                If String.IsNullOrEmpty(TxtSanad.Text) Then
                    MessageBox.Show("شماره دستی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtSanad.Focus()
                    Exit Sub
                End If
            End If
            If RdoPart.Checked = True Then
                If String.IsNullOrEmpty(TxtPart.Text) Or String.IsNullOrEmpty(TxtIdPart.Text) Then
                    MessageBox.Show("پارت را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPart.Focus()
                    Exit Sub
                End If
            End If
            If ChkDate.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("محدوده تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkAzDate.Checked = True
                    Exit Sub
                End If
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        FarsiDate1.Focus()
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(FarsiDate1.ThisText) Or String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                        MessageBox.Show("تاریخ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
            If Rdomon.Checked = True Then
                If ChkAzMon.Checked = False And ChkTaMon.Checked = False Then
                    MessageBox.Show("محدوده مبلغ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkAzMon.Checked = True
                    Exit Sub
                End If
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    If CDbl(TxtMon1.Text) > CDbl(TxtMon2.Text) Then
                        MessageBox.Show("محدوده مبلغ اشتباه است لطفا آن را اصلاح کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtMon1.Focus()
                        Exit Sub
                    End If
                    If CDbl(TxtMon1.Text) = 0 And CDbl(TxtMon2.Text) = 0 Then
                        MessageBox.Show("مبلغ را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtMon1.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If RdoExitFactor.Checked = True Then
                If String.IsNullOrEmpty(TxtExit.Text) Then
                    MessageBox.Show("شماره خروجی فاکتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtExit.Focus()
                    Exit Sub
                End If
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "نمایش فاکتور", "", "")

            Me.GetFactor()
            Me.Enabled = True
            If DGV1.RowCount > 0 Then
                TPart.Text = DGV1.Item("Cln_part", 0).Value
                TSanad.Text = DGV1.Item("Cln_Sanad", 0).Value
                TxtDisc.Text = DGV1.Item("Cln_disc", 0).Value
            Else
                TPart.Clear()
                TSanad.Clear()
                TxtDisc.Clear()
                TxtMonFac.Text = 0
                TxtDiscountC.Text = 0
                TxtDiscountH.Text = 0
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnShow_Click")
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub Rdoid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdoid.CheckedChanged
        If Rdoid.Checked = True Then
            LFactor.Visible = True
            TxtIdFac.Clear()
            TxtIdFac.Visible = True
            ChkDate.Checked = False
            ChkDate.Enabled = False
            TxtIdFac.Focus()
        Else
            ChkDate.Enabled = True
            LFactor.Visible = False
            TxtIdFac.Visible = False
        End If
    End Sub

    Private Sub Rdonam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdonam.CheckedChanged
        If Rdonam.Checked = True Then
            Lname.Visible = True
            Txtname.Visible = True
            Lname.Visible = True
            Txtname.Clear()
            TxtIdName.Clear()
            Txtname.Focus()
        Else
            Lname.Visible = False
            Txtname.Visible = False
            Lname.Visible = False
        End If
    End Sub

    Private Sub RdoSanad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoSanad.CheckedChanged
        If RdoSanad.Checked = True Then
            LSanad.Visible = True
            TxtSanad.Clear()
            TxtSanad.Visible = True
            TxtSanad.Focus()
        Else
            LSanad.Visible = False
            TxtSanad.Visible = False
        End If
    End Sub

    Private Sub RdoPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoPart.CheckedChanged
        If RdoPart.Checked = True Then
            Lpart.Visible = True
            TxtPart.Clear()
            TxtPart.Visible = True
            TxtPart.Focus()
        Else
            Lpart.Visible = False
            TxtPart.Visible = False
        End If
    End Sub

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtname.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub Txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtname.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New People_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        Txtname.Focus()
        If Tmp_Namkala <> "" Then
            Txtname.Text = Tmp_Namkala
            TxtIdName.Text = IdKala
            Call BtnShow_Click(Nothing, Nothing)
        Else
            Txtname.Text = ""
            TxtIdName.Text = ""
        End If
    End Sub

    Private Sub TxtPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPart.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtSanad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSanad.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub FarsiDate1_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate1.KeyDowned
        If e.KeyCode = Keys.Enter Then
            If FarsiDate2.Enabled = True Then
                FarsiDate2.Focus()
            Else
                Call BtnShow_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub FarsiDate2_KeyDowned(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FarsiDate2.KeyDowned
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        If e.KeyCode = AscW(0) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(1) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.DeepPink
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(2) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Magenta
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(3) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.BlueViolet
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(4) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.DarkTurquoise
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(5) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.SpringGreen
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(6) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Yellow
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(7) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Olive
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(8) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Orange
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = AscW(9) Then
            DGV1.Rows(DGV1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Chocolate
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
            DGV1.Rows(DGV1.CurrentRow.Index).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
        ElseIf e.KeyCode = Keys.Delete Then
            For i As Integer = 0 To DGV1.RowCount - 1
                DGV1.Rows(i).DefaultCellStyle.BackColor = Color.White
                DGV1.Rows(i).Cells("Cln_Idf").Style.BackColor = Color.Gainsboro
                DGV1.Rows(i).Cells("Cln_TypeFac").Style.BackColor = Color.Gainsboro
            Next
        End If
    End Sub

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        Try
            TPart.Text = DGV1.Item("Cln_part", e.RowIndex).Value
            TSanad.Text = DGV1.Item("Cln_Sanad", e.RowIndex).Value
            TxtDisc.Text = DGV1.Item("Cln_disc", e.RowIndex).Value
            Me.SetButton(GetStateFactor(DGV1.Item("Cln_TypeFac", e.RowIndex).Value))
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
    End Sub
    Private Sub CalculateMon()
        Try
            TxtMonFac.Text = 0
            TxtDiscountC.Text = 0
            TxtDiscountH.Text = 0
            TxtPay.Text = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_AllFac", i).Value)
                TxtDiscountC.Text = CDbl(TxtDiscountC.Text) + CDbl(DGV1.Item("Cln_Discount", i).Value)
                TxtDiscountH.Text = CDbl(TxtDiscountH.Text) + CDbl(DGV1.Item("Cln_DiscountC", i).Value)
                TxtPay.Text = CDbl(TxtPay.Text) + CDbl(DGV1.Item("cln_allmon", i).Value)
            Next
            If TxtMonFac.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonFac.Text.Replace(",", ""))
                TxtMonFac.Text = Format$(Val(Str), "###,###,###")
            End If
            If TxtDiscountC.Text.Length > 3 Then
                Dim Str As String = Format$(TxtDiscountC.Text.Replace(",", ""))
                TxtDiscountC.Text = Format$(Val(Str), "###,###,###")
            End If
            If TxtDiscountH.Text.Length > 3 Then
                Dim Str As String = Format$(TxtDiscountH.Text.Replace(",", ""))
                TxtDiscountH.Text = Format$(Val(Str), "###,###,###")
            End If
            If TxtPay.Text.Length > 3 Then
                Dim Str As String = Format$(TxtPay.Text.Replace(",", ""))
                TxtPay.Text = Format$(Val(Str), "###,###,###")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Showfactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Showfactor.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "ریز فاکتور", "نمایش ریز فاکتور " & DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value & ":" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")

            Using frmshow As New ShowFactor
                frmshow.LFactor.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                frmshow.LState.Text = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                frmshow.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "Btn_Showfactor_Click")
        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ManageFact.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnDel.Enabled = True And BtnDel.Visible = True Then Call BtnDel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Btn_Showfactor.Enabled = True And Btn_Showfactor.Visible = True Then Call Btn_Showfactor_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If BtnEdit.Enabled = True And BtnEdit.Visible = True Then Call BtnEdit_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnShow.Enabled = True And BtnShow.Visible = True Then Call BtnShow_Click(Nothing, Nothing)
            SetButton()
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnPrintFac.Enabled = True And BtnPrintFac.Visible = True Then Call BtnPrintFac_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            If BtnPrintResed.Enabled = True And BtnPrintResed.Visible = True Then Call BtnPrintResed_Click(Nothing, Nothing)
            If BtnConvert.Enabled = True And BtnConvert.Visible = True Then Call BtnConvert_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F8 Then
            If BtnPrintFish.Enabled = True And BtnPrintFish.Visible = True Then Call BtnPrintFish_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F9 Then
            If BtnAllPrint.Enabled = True And BtnAllPrint.Visible = True Then Call BtnAllPrint_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F10 Then
            If BtnSendSMS.Enabled = True And BtnSendSMS.Visible = True Then Call BtnSendSMS_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            If BtnPrintList.Enabled = True And BtnPrintList.Visible = True Then Call BtnPrintList_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If LimitWork(DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value, "DEL") = False Then
                MessageBox.Show(" حذف به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("آیا برای حذف فاکتور مورد نظر مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            If Not AreYouEditFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                MessageBox.Show("فاکتور مورد نظر در حال بروز رسانی می باشد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Not (GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 6 Or GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 7) Then
                If Not AreYouDeleteCheckFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                    MessageBox.Show("چکهای مربوط به فاکتور مورد نظر استفاده شده است و فاکتور قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 3 Then
                If AreYouKasriFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value) <> 0 Then
                    MessageBox.Show(" فاکتور مورد نظر دارای کسری فاکتور است و قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If AreYouExitFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value) <> 0 Then
                    MessageBox.Show(" فاکتور مورد نظر در بخش خروجی فاکتور ثبت شده است و قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If AreYouBackFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value) <> 0 Then
                    MessageBox.Show(" فاکتور مورد نظر دارای  فاکتور برگشتی و قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If

            If GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 0 Then
                If AreYouChargeFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value) <> 0 Then
                    MessageBox.Show(" فاکتور مورد نظر دارای هزینه ثبت شده است و قابل حذف نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 0 Or GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 4 Then
                If Not CheckMojodyKala(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then Exit Sub
            End If

            If Not DelFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                MessageBox.Show("فاکتور مورد نظر قابل حذف شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Call BtnShow_Click(Nothing, Nothing)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnDel_Click")
        End Try
    End Sub

    Private Function CheckMojodyKala(ByVal IdFactor As Long, ByVal Type As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable
            Using cmd As New SqlCommand("SELECT JozCount, KolCount, IdKala, IdAnbar FROM " & If(Type = 0, "KalaFactorBuy", If(Type = 4, "KalaFactorBackSell", "KalaFactorSell")) & " WHERE IdKala IS NOT NULL AND IdAnbar IS NOT NULL AND IdFactor =" & IdFactor, ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            LimitMojody()

            For i As Integer = 0 To dt.Rows.Count - 1
                If Not AreYouNativeKalaAnbar(dt.Rows(i).Item("IdKala"), dt.Rows(i).Item("KolCount"), dt.Rows(i).Item("JozCount"), dt.Rows(i).Item("IdAnbar")) Then
                    If MAnbar = True Then
                        If MessageBox.Show("کالا با کد " & dt.Rows(i).Item("IdKala") & " کمتر از موجودی انبار است آیا برای ادامه مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return False
                    Else
                        MessageBox.Show("کالا با کد " & dt.Rows(i).Item("IdKala") & " کمتر از موجودی انبار است و قابل " & If(Type = 7, "تبدیل", "حذف") & " شدن نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            Next i
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "CheckMojodyKala")
            Return False
        End Try
    End Function
    Private Function Raskala(ByVal IdFactor As Long, ByVal IdP As Long, ByVal IdG As Long) As Long
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable
            Using cmd As New SqlCommand("SELECT Mon ,IdKala ,IdService  FROM KalaFactorSell WHERE  IdFactor =" & IdFactor, ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()


            Dim str(dt.Rows.Count - 1) As String
            Dim Query As String = ""
            Dim Rate As Long = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("IdKala") Is DBNull.Value Then
                    str(i) = "SELECT Mon=" & dt.Rows(i).Item("Mon") & ",AllMon=" & dt.Rows(i).Item("Mon") & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT Rate FROM  Define_ListKalaRate WHERE IdKalaLink =0 AND IdGroup =0) AS ListRate"
                Else
                    str(i) = "SELECT Mon=" & dt.Rows(i).Item("Mon") & ",AllMon=" & dt.Rows(i).Item("Mon") & " * CASE WHEN COUNT(0)>0 THEN MAX(Rate) ELSE (SELECT MAX(Rate) FROM Define_People WHERE ID =" & IdP & ") END FROM (SELECT Rate FROM  Define_ListKalaRate WHERE IdKalaLink =" & dt.Rows(i).Item("IdKala") & " AND IdGroup =" & IdG & ") AS ListRate"
                End If
            Next i


            Query = "SELECT ISNULL(SUM(AllMon),0)/ISNULL(SUM(Mon),0) AS Rate FROM("
            For i As Integer = 0 To str.Length - 1
                Query &= str(i) & " UNION ALL "
            Next


            Query = Query.Substring(0, Query.Length - 12) & " ) AS ListMon "


            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Query, ConectionBank)
                Rate = cmd.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Return Rate

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "Raskala")
            Return 0
        End Try
    End Function


    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If LimitWork(DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value, "EDIT") = False Then
                MessageBox.Show(" ویرایش به جهت محدودیت زمانی امکانپذیر نیست ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not AreYouEditFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                MessageBox.Show("فاکتور مورد نظر در حال بروز رسانی می باشد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Not SetEditFlagFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value), 0) Then
                MessageBox.Show("فاکتور مورد نظر به حالت ویرایش تغییر وضعیت نمی دهد لطفا بعدا اقدام کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Fnew = False
            If GetSetBarcode() = False Then
                Using FrmFactor As New FrmFactor
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value))
                    FrmFactor.CmbFac.Enabled = False
                    Tmp_String1 = If(DGV1.Item("Cln_Part", DGV1.CurrentRow.Index).Value Is DBNull.Value, "", DGV1.Item("Cln_Part", DGV1.CurrentRow.Index).Value)
                    Tmp_String2 = If(DGV1.Item("Cln_IdPart", DGV1.CurrentRow.Index).Value Is DBNull.Value, "", DGV1.Item("Cln_IdPart", DGV1.CurrentRow.Index).Value)
                    FrmFactor.LEdit.Text = "1"
                    FrmFactor.LIdFac.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                    FrmFactor.LState.Text = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                    Select Case GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                        Case 0 Or 1 Or 2 Or 6 Or 8 : FrmFactor.ChkVisitor.Enabled = False
                    End Select
                    If Not AreYouDeleteCheckFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                        FrmFactor.TxtName.Enabled = False
                    End If
                    If GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 0 Or GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 3 Then
                        If AreYouExsitRelation(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                            FrmFactor.TxtName.Enabled = False
                        End If
                    End If
                    FrmFactor.ShowDialog()
                    SetEditFlagFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value), 1)
                End Using
            Else
                Using FrmFactor As New FrmFactor_Barcode
                    FrmFactor.CmbFac.Text = FrmFactor.CmbFac.Items.Item(GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value))
                    FrmFactor.CmbFac.Enabled = False
                    Tmp_String1 = If(DGV1.Item("Cln_Part", DGV1.CurrentRow.Index).Value Is DBNull.Value, "", DGV1.Item("Cln_Part", DGV1.CurrentRow.Index).Value)
                    Tmp_String2 = If(DGV1.Item("Cln_IdPart", DGV1.CurrentRow.Index).Value Is DBNull.Value, "", DGV1.Item("Cln_IdPart", DGV1.CurrentRow.Index).Value)
                    FrmFactor.LEdit.Text = "1"
                    FrmFactor.LIdFac.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                    FrmFactor.LState.Text = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                    Select Case GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                        Case 0 Or 1 Or 2 Or 6 Or 8 : FrmFactor.ChkVisitor.Enabled = False
                    End Select
                    If Not AreYouDeleteCheckFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                        FrmFactor.TxtName.Enabled = False
                    End If
                    If GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 0 Or GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) = 3 Then
                        If AreYouExsitRelation(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)) Then
                            FrmFactor.TxtName.Enabled = False
                        End If
                    End If
                    FrmFactor.ShowDialog()
                    SetEditFlagFactor(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value), 1)
                End Using
            End If
            Application.DoEvents()
            Call BtnShow_Click(Nothing, Nothing)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnEdit_Click")
        End Try
    End Sub

    Private Sub BtnPrintFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintFac.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            
            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "چاپ فاکتور", "چاپ فاکتور " & DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value & ":" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")

            Using FrmPrint As New FrmPrint
                Dim state As Long = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                If state = 0 Or state = 2 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.IdService,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBuy.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " UNION ALL SELECT KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.IdService,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBuy.IdService  = Define_Service .ID  WHERE ListFactorBuy.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorBuy.Id "
                ElseIf state = 1 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorBackBuy.Id,KalaFactorBackBuy.IdKala,KalaFactorBackBuy.IdService,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackBuy.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " UNION ALL SELECT KalaFactorBackBuy.Id,KalaFactorBackBuy.Idkala,KalaFactorBackBuy.IdService,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBackBuy.IdService  = Define_Service .ID  WHERE ListFactorBackBuy.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorBackBuy.Id "
                ElseIf state = 3 Or state = 5 Or state = 7 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorSell.Id,KalaFactorSell.IdKala,KalaFactorSell.IdService,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " UNION ALL SELECT KalaFactorSell.Id,KalaFactorSell.Idkala,KalaFactorSell.IdService,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorSell.Id "
                ElseIf state = 4 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorBackSell.Id,KalaFactorBackSell.IdKala,KalaFactorBackSell.IdService,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackSell.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " UNION ALL SELECT KalaFactorBackSell.Id,KalaFactorBackSell.IdKala,KalaFactorBackSell.IdService,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Service.Nam as NamKala,IdManual='', NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Service  ON KalaFactorBackSell.IdService  = Define_Service .ID  WHERE ListFactorBackSell.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorBackSell.Id "
                ElseIf state = 6 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorDamage.Id,KalaFactorDamage.IdKala,IdService=0,KalaFactorDamage.KolCount, KalaFactorDamage.JozCount, KalaFactorDamage.Fe,DarsadDiscount=0,DarsadMon=0, KalaFactorDamage.Mon,KalaFactorDamage.KalaDisc, Define_Kala.Nam as NamKala,IdManual=CASE WHEN (SELECT S3 FROM SettingProgram WHERE SettingProgram.IdUser=" & Id_User & " )=N'1' THEN CAST(Define_Kala.Id AS Nvarchar(max)) ELSE Define_Kala.Ex_Date END, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorDamage INNER JOIN KalaFactorDamage ON ListFactorDamage.IdFactor = KalaFactorDamage.IdFactor INNER JOIN Define_Kala ON KalaFactorDamage.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorDamage.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorDamage.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorDamage.Id "
                ElseIf state = 8 Then
                    FrmPrint.PrintSQl = "SELECT KalaFactorService.Id,IdKala=0,KalaFactorService.IdService ,KalaFactorService.KolCount, JozCount=0, KalaFactorService.Fe, KalaFactorService.DarsadDiscount, KalaFactorService.DarsadMon, KalaFactorService.Mon,KalaFactorService.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorService INNER JOIN KalaFactorService ON ListFactorService.IdFactor = KalaFactorService.IdFactor INNER JOIN Define_Service  ON KalaFactorService.IdService  = Define_Service .ID  WHERE ListFactorService.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorService.Id "
                End If
                FrmPrint.CHoose = "FACTOR"
                FrmPrint.IdFactor = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                FrmPrint.Lend = DGV1.Item("Cln_Lend", DGV1.CurrentRow.Index).Value
                FrmPrint.State = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
                FrmPrint.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnPrintFac_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnPrintResed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintResed.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim state As Long = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
            If state <> 0 And state <> 1 And state <> 3 And state <> 4 Then
                MessageBox.Show("چاپ رسید ویژه فاکتور خرید و فروش و برگشتی می باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "چاپ رسید", "چاپ رسید فاکتور " & DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value & ":" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")

            Using FrmPrint As New FrmPrint
                If state = 0 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorBuy.ID,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorBuy .IdName WHERE ListFactorBuy.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorBuy.ID "
                ElseIf state = 1 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorBackBuy.ID,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorBackBuy .IdName WHERE ListFactorBackBuy.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorBackBuy.ID "
                ElseIf state = 3 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorSell.ID,KalaFactorSell.KolCount, KalaFactorSell.JozCount,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorSell.IdName WHERE ListFactorSell.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorSell.ID "
                ElseIf state = 4 Then
                    FrmPrint.PrintSQl = "SELECT  KalaFactorBackSell.ID,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala, Define_People.Nam As discription ,Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id INNER JOIN Define_People On Define_People .ID =ListFactorBackSell.IdName WHERE ListFactorBackSell.IdFactor =" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value & " Order By KalaFactorBackSell.ID "
                End If
                FrmPrint.CHoose = "RESEIDANBAR"
                FrmPrint.IdFactor = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
                FrmPrint.Lend = DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value
                FrmPrint.Str2 = DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value
                FrmPrint.State = state
                FrmPrint.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnPrintFac_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub BtnPrintFish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintFish.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) <> 3 And GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value) <> 5 Then
                MessageBox.Show("چاپ فیش فقط مربوط به فروش میباشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "چاپ فیش", "چاپ فیش فاکتور " & DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value & ":" & DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, "")




            Dim state As Long = GetStateFactor(DGV1.Item("Cln_TypeFac", DGV1.CurrentRow.Index).Value)
            Dim query As String = ""
            If state = 3 Or state = 5 Then
                query = String.Format("SELECT  PeopleMon=(SELECT ISNULL(EndCost,0) FROM [Define_CostKala] INNER JOIN Define_CityCostkala ON Define_CityCostkala.IdCity =[Define_CostKala].IdCity WHERE IdKala =KalaFactorSell.IdKala  AND Define_CityCostkala.IdCity =(SELECT IdCity FROM Define_People WHERE Id=ListFactorSell.IdName)),KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor ={0} UNION ALL SELECT PeopleMon=0,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor ={1} Order By NamKala ", DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value)
            End If
            Me.FactorFish(query, DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value, state)
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnPrintFac_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub FactorFish(ByVal PrintSQl As String, ByVal IdFactor As Long, ByVal Lend As String, ByVal State As Long)
        Try
            Dim Dataret As New DataSetFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("کالاهای فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            Dim dtrInfo As SqlDataReader

            Dim QueryInfo As String = ""
            If State = "3" Or State = "5" Then
                QueryInfo = String.Format("If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor ={0})  Is NULL BEGIN SELECT  ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk , ListFactorSell.D_date,ListFactorSell.IdUser , ISNULL(ListFactorSell.Disc,'') AS Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorSell.IdVisitor,NamVisit='' FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorSell.IdFactor ={1}  END ELSE BEGIN SELECT  ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk ,ListFactorSell.D_date,ListFactorSell.IdUser, ListFactorSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorSell.IdFactor ={2}  END", CLng(IdFactor), CLng(IdFactor), CLng(IdFactor))
            End If

            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("اطلاعات فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("DiscountC") = dtrInfo("Discount")
                    Dataret.DataTable1.Rows(0).Item("Add") = dtrInfo("MonAdd")
                    Dataret.DataTable1.Rows(0).Item("Dec") = dtrInfo("MonDec")
                    Dataret.DataTable1.Rows(0).Item("PayMon") = dtrInfo("MonAdd") - (dtrInfo("MonDec") + dtrInfo("Discount"))
                End If
            End Using
            dtrInfo.Close()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand("SELECT Top 1 CompanyName FROM Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                SQLComanad.CommandTimeout = 0
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("CompanyName") = dtrInfo("CompanyName")
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dtrInfo.Close()

            Dataret.DataTable1.Rows(0).Item("IdFactor") = IdFactor
            Dataret.DataTable1.Rows(0).Item("D_date") = Lend
            Dim MonRes As Double = 0
            Dim MonEND As Double = 0
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = If(Dataret.DataTable1.Rows(i).Item("JozCount") <> 0, Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/"), Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/"))
                MonRes += Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                Dataret.DataTable1.Rows(0).Item("DiscountC") += Dataret.DataTable1.Rows(i).Item("DarsadMon")
                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    Dataret.DataTable1.Rows(i).Item("FeKol") = Dataret.DataTable1.Rows(i).Item("Fe")
                    Dataret.DataTable1.Rows(i).Item("Fe") = Dataret.DataTable1.Rows(i).Item("Fe")
                Else
                    Dataret.DataTable1.Rows(i).Item("FeKol") = If(Dataret.DataTable1.Rows(i).Item("KolCount") <> 0, Dataret.DataTable1.Rows(i).Item("Mon") / Dataret.DataTable1.Rows(i).Item("KolCount"), 0)
                End If

                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    MonEND += CDbl(Dataret.DataTable1.Rows(i).Item("StrKol").ToString.Replace("/", ".")) * If(Dataret.DataTable1.Rows(i).Item("PeopleMon") Is DBNull.Value, Dataret.DataTable1.Rows(i).Item("Fe"), CDbl(Dataret.DataTable1.Rows(i).Item("PeopleMon")))
                Else
                    MonEND += CDbl(Dataret.DataTable1.Rows(i).Item("StrJoz").ToString.Replace("/", ".")) * If(Dataret.DataTable1.Rows(i).Item("PeopleMon") Is DBNull.Value, Dataret.DataTable1.Rows(i).Item("Fe"), CDbl(Dataret.DataTable1.Rows(i).Item("PeopleMon")))
                End If
            Next
            Dataret.DataTable1.Rows(0).Item("PayMon") = MonRes + Dataret.DataTable1.Rows(0).Item("PayMon")
            Dataret.DataTable1.Rows(0).Item("ENDMon") = MonEND

            Dim ret As New CRP_Factor_Fishprinter
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            ret.PrintToPrinter(1, False, 1, Integer.MaxValue)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "FactorFish")
            Me.Close()
        End Try
    End Sub
    Private Sub SetButton(ByVal Id As Long)
        Try
            BtnPrintFish.Visible = True
            ToolFish.Visible = True

            ToolAllPrint.Visible = True
            BtnAllPrint.Visible = True

            BtnPrintFac.Visible = True
            ToolFac.Visible = True

            BtnPrintResed.Visible = True
            ToolResed.Visible = True

            BtnConvert.Visible = True
            ToolConvert.Visible = True

            BtnSendSMS.Visible = True
            ToolSendSMS.Visible = True

            If Id = 0 Or Id = 1 Or Id = 2 Then
                BtnPrintFish.Visible = False
                ToolFish.Visible = False
                BtnConvert.Visible = False
                ToolConvert.Visible = False
            ElseIf Id = 4 Then
                BtnPrintFish.Visible = False
                ToolFish.Visible = False
                BtnConvert.Visible = False
                ToolConvert.Visible = False
            ElseIf Id = 6 Then
                BtnPrintFish.Visible = False
                ToolFish.Visible = False
                BtnPrintResed.Visible = False
                ToolResed.Visible = False
                BtnConvert.Visible = False
                ToolConvert.Visible = False
            ElseIf Id = 7 Then
                BtnPrintFish.Visible = False
                ToolFish.Visible = False
                BtnPrintResed.Visible = False
                ToolResed.Visible = False
            ElseIf Id = 8 Then
                BtnPrintFish.Visible = False
                ToolFish.Visible = False
                BtnPrintResed.Visible = False
                ToolResed.Visible = False
                BtnConvert.Visible = False
                ToolConvert.Visible = False
            End If
            Me.SetButton()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "SetButton")
            Me.Close()
        End Try
    End Sub

    Private Sub RdoVisit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoVisit.CheckedChanged
        If RdoVisit.Checked = True Then
            LVisit.Visible = True
            TxtNameVisit.Visible = True
            TxtNameVisit.Clear()
            TxtIdVisit.Clear()
            TxtNameVisit.Focus()
        Else
            LVisit.Visible = False
            TxtNameVisit.Visible = False
        End If
    End Sub

    Private Sub TxtNameVisit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNameVisit.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtNameVisit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNameVisit.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtNameVisit.Focus()
        If Tmp_Namkala <> "" Then
            TxtNameVisit.Text = Tmp_Namkala
            TxtIdVisit.Text = IdKala
            Call BtnShow_Click(Nothing, Nothing)
        Else
            TxtNameVisit.Text = ""
            TxtIdVisit.Text = ""
        End If
    End Sub

    Private Sub RdoUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoUser.CheckedChanged
        If RdoUser.Checked = True Then
            LUser.Visible = True
            TxtUser.Visible = True
            TxtUser.Clear()
            TxtIdUser.Clear()
            TxtUser.Focus()
        Else
            LUser.Visible = False
            TxtUser.Visible = False
        End If
    End Sub

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New user_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
            Call BtnShow_Click(Nothing, Nothing)
        Else
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
    End Sub

    Private Sub BtnAllPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllPrint.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
           
            Me.Enabled = False

            Using Pfrm As New FrmAllPrint
                For i As Integer = 0 To DGV1.RowCount - 1
                    Pfrm.DGV1.Rows.Add()
                    Pfrm.DGV1.Item("Cln_Date", Pfrm.DGV1.RowCount - 1).Value = DGV1.Item("Cln_Date", i).Value
                    Pfrm.DGV1.Item("Column1", Pfrm.DGV1.RowCount - 1).Value = DGV1.Item("Column1", i).Value
                    Pfrm.DGV1.Item("Cln_Idf", Pfrm.DGV1.RowCount - 1).Value = DGV1.Item("Cln_Idf", i).Value
                    Pfrm.DGV1.Item("Cln_Lend", Pfrm.DGV1.RowCount - 1).Value = CDbl(DGV1.Item("Cln_Lend", i).Value)
                    Pfrm.DGV1.Item("Cln_TypeFac", Pfrm.DGV1.RowCount - 1).Value = DGV1.Item("Cln_TypeFac", i).Value
                    Pfrm.DGV1.Item("Cln_Select", Pfrm.DGV1.RowCount - 1).Value = True
                Next
                Pfrm.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnAllPrint_Click")
            Me.Enabled = True
        End Try
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
            Call BtnShow_Click(Nothing, Nothing)
        Else
            TxtPart.Text = ""
            TxtIdPart.Text = ""
        End If
    End Sub

    Private Sub TxtExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtExit.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExit.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
        If e.KeyChar = (vbBack) Then
            e.Handled = False
        End If
        If e.KeyChar = (vbTab) Then
            e.Handled = False
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Exit_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.ShowDialog()
        e.Handled = True
        TxtExit.Focus()
        If Tmp_Namkala <> "" Then
            TxtExit.Text = Tmp_Namkala
        End If
    End Sub

    Private Sub TxtExit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExit.TextChanged
        If Not (CheckDigit(TxtExit.Text)) Then
            TxtExit.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub RdoExitFactor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoExitFactor.CheckedChanged
        If RdoExitFactor.Checked = True Then
            ChkLimit.Checked = True
            ChkLimit.Enabled = False
            CmbFac.Text = CmbFac.Items.Item(3)
            CmbFac.Enabled = False
            LExit.Visible = True
            TxtExit.Visible = True
            TxtExit.Clear()
            TxtExit.Focus()
        Else
            ChkLimit.Enabled = True
            ChkLimit.Checked = False
            LExit.Visible = False
            TxtExit.Visible = False
        End If
    End Sub

    Private Sub ChkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDate.CheckedChanged
        If ChkDate.Checked = True Then
            FarsiDate1.Enabled = True
            FarsiDate1.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
            ChkAzDate.Enabled = True
            ChkAzDate.Checked = True
            ChkTaDate.Enabled = True
            ChkTaDate.Checked = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate2.Enabled = False
            ChkAzDate.Enabled = False
            ChkAzDate.Checked = False
            ChkTaDate.Enabled = False
            ChkTaDate.Checked = False
        End If
    End Sub

    Private Sub BtnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendSMS.Click
        If SMS = False Then
            MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If DGV1.Rows.Count <= 0 Then
            MessageBox.Show("هیچ فاکتور فروشی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Array.Resize(ListDelayPrintArray, 0)

        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                If GetStateFactor(DGV1.Item("Cln_TypeFac", i).Value) = 3 Then
                    Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).nam = DGV1.Item("Column1", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).IdFactor = DGV1.Item("Cln_Idf", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell1 = DGV1.Item("Cln_IdName", i).Value
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Mandeh = CDbl(DGV1.Item("cln_allmon", i).Value)
                    ListDelayPrintArray(ListDelayPrintArray.Length - 1).Kind = DGV1.Item("Cln_Date", i).Value
                End If
            Next
        End If

        If ListDelayPrintArray.Length <= 0 Then
            MessageBox.Show("هیچ فاکتور فروشی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "SMS ارسال", "", "")

        Using FrmT As New SendAllSMSFactor
            FrmT.ShowDialog()
        End Using

        Me.Enabled = True

    End Sub

    Private Sub BtnConvert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConvert.Click
        If Not CheckMojodyKala(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, 7) Then Exit Sub
        Using FrmPay As New ConvrtPayFactor
            Rate = Raskala(DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value, DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value, GetIdGroup(DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value))
            Dim IdFac As Long = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
            FrmPay.TxtFacMon.Text = DGV1.Item("Cln_AllFac", DGV1.CurrentRow.Index).Value
            FrmPay.LMandeh.Text = 0
            FrmPay.TxtLend.Text = DGV1.Item("Cln_AllFac", DGV1.CurrentRow.Index).Value - DGV1.Item("Cln_Discount", DGV1.CurrentRow.Index).Value
            FrmPay.TxtEndMon.Text = DGV1.Item("Cln_AllFac", DGV1.CurrentRow.Index).Value
            FrmPay.TxtDiscountH.Text = DGV1.Item("Cln_Discount", DGV1.CurrentRow.Index).Value
            FrmPay.LName.Text = DGV1.Item("Column1", DGV1.CurrentRow.Index).Value
            FrmPay.LIdname.Text = DGV1.Item("Cln_IdName", DGV1.CurrentRow.Index).Value
            FrmPay.LDate.Text = DGV1.Item("Cln_Date", DGV1.CurrentRow.Index).Value
            FrmPay.LIdFac.Text = DGV1.Item("Cln_Idf", DGV1.CurrentRow.Index).Value
            FrmPay.LHandNumber.Text = DGV1.Item("Cln_Sanad", DGV1.CurrentRow.Index).Value
            FrmPay.LState.Text = 3
            FrmPay.TxtAddDarsad.Text = "0"
            FrmPay.TxtAddMon.Text = "0"
            FrmPay.TxtDecDarsad.Text = "0"
            FrmPay.TxtDecMon.Text = "0"
            FrmPay.TxtDiscountC.Text = "0"
            FrmPay.TxtDarDisH.Text = "0"
            FrmPay.TxtDarDisC.Text = "0"
            FrmPay.TxtCash.Text = "0"
            FrmPay.Txtbank.Text = "0"
            FrmPay.TxtChk.Text = "0"
            FrmPay.LEdit.Text = "0"
            FrmPay.ShowDialog()
            If FrmPay.LOk.Text = "0" Then
                RoolBackPishFactor(IdFac, 3)
                Me.Enabled = True
                Exit Sub
            End If
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "تبدیل", "تبدیل پیش فاکتور :" & IdFac & "به فاکتور فروش", "")
        End Using

        Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintList.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ فاکتوری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "چاپ لیست", "", "")

            Array.Resize(ListFactor, 0)
            For i As Integer = 0 To DGV1.RowCount - 1
                Array.Resize(ListFactor, ListFactor.Length + 1)
                ListFactor(ListFactor.Length - 1).Nam = DGV1.Item("Column1", i).Value
                ListFactor(ListFactor.Length - 1).IdFactor = CLng(DGV1.Item("Cln_Idf", i).Value)
                ListFactor(ListFactor.Length - 1).NamCi = DGV1.Item("Cln_TypeFac", i).Value
                ListFactor(ListFactor.Length - 1).D_date = DGV1.Item("Cln_Date", i).Value
                ListFactor(ListFactor.Length - 1).MonFac = CDbl(DGV1.Item("Cln_AllFac", i).Value)
                ListFactor(ListFactor.Length - 1).Discount1 = CDbl(DGV1.Item("Cln_DiscountC", i).Value)
                ListFactor(ListFactor.Length - 1).Discount = CDbl(DGV1.Item("Cln_Discount", i).Value)
                ListFactor(ListFactor.Length - 1).AllMonFac = CDbl(DGV1.Item("cln_allmon", i).Value)
                ListFactor(ListFactor.Length - 1).Cash = CDbl(DGV1.Item("Cln_Cash", i).Value)
                ListFactor(ListFactor.Length - 1).Kasri = CDbl(DGV1.Item("Column3", i).Value)
                ListFactor(ListFactor.Length - 1).Chk = CDbl(DGV1.Item("Cln_Chk", i).Value)
                ListFactor(ListFactor.Length - 1).Lend = CDbl(DGV1.Item("Cln_Lend", i).Value)
                ListFactor(ListFactor.Length - 1).IdExit = If(DGV1.Item("Cln_Exit", i).Value Is DBNull.Value, "", DGV1.Item("Cln_Exit", i).Value)
            Next

            Using FrmPrint As New FrmPrint
                FrmPrint.CHoose = "LISTFACTOR"
                FrmPrint.ShowDialog()
            End Using
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ManageFactor", "BtnPrintList_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub ChkLimit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLimit.CheckedChanged
        If ChkLimit.Checked = True Then
            CmbFac.Enabled = True
        Else
            CmbFac.Enabled = False
        End If
    End Sub

End Class