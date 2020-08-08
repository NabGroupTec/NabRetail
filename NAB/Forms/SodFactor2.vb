Imports System.Data.SqlClient
Public Class SodFactor2
    Dim ds As New DataTable
    Dim dta As New SqlDataAdapter
    Dim dv As New DataView
    Private Sub GetFactor()
        Try
            ds.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(SetQuery, ConectionBank)
                cmd.CommandTimeout = 0
                ds.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            DGV1.AutoGenerateColumns = False
            dv = ds.DefaultView
            DGV1.DataSource = dv
            Me.Calculate()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor2", "GetFactor")
        End Try
    End Sub
    Private Function SetQuery() As String
        Try
            Dim concity As String = ""
            Dim condition As String = ""
            Dim condition2 As String = ""
            Dim condition3 As String = ""
            Dim condition4 As String = ""


            If RdoCity.Checked = True Then
                concity = " AND IdName IN (SELECT ID From Define_People WHERE IdCity =" & TxtIdCity.Text & ") "
            End If


            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    condition &= " AND (D_Date>=N'" & FarsiDate1.ThisText & "' AND D_Date<=N'" & FarsiDate2.ThisText & "')"
                    condition2 = " AND (D_Date>=N'" & FarsiDate1.ThisText & "' AND D_Date<=N'" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    condition &= " AND (D_Date>=N'" & FarsiDate1.ThisText & "')"
                    condition2 = " AND (D_Date>=N'" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    condition &= " AND (D_Date<=N'" & FarsiDate2.ThisText & "')"
                    condition2 = " AND (D_Date<=N'" & FarsiDate2.ThisText & "')"
                End If
            End If

            If RdoVisitor.Checked = True Then
                condition &= " AND (IdVisitor=" & TxtIdVisit.Text & ")"
            End If

            Dim Group As String = ""
            If ChkGroup.Checked = True Then
                Group = "AND IdName IN (SELECT ID From Define_People WHERE ChkIdGroup ='True' And IdGroup =" & TxtIdGroup.Text & ") "
            End If

            If RdoExit.Checked = True Then
                condition3 = " AND ListFactorSell.IdFactor IN (SELECT IdFactor FROM ListExitFactor WHERE IdList =" & TxtExit.Text & ")"
                condition4 = " AND Get_Pay_Sanad.Id IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor IN(SELECT  IdFactor FROM ListExitFactor WHERE IdList =" & TxtExit.Text & "))"
            End If


            If ChkFrosh.Checked = False Then
                Return "SELECT Define_People.Nam,C_Count,MonFac,NSod,DiscountFactor,DiscountGet,(NSod - DiscountFactor-DiscountGet-NSodKF-NSodBF) As Sod,MonBack,MonKasri,Darsad=Case WHEN MonFac<=0 THEN 0 ELSE  ROUND((NSod - DiscountFactor-DiscountGet-NSodKF-NSodBF)*100/MonFac,2) END  FROM(SELECT IdPeople,COUNT(IdPeople) As C_Count,SUM(MonFac) As MonFac ,SUM(NSod) As NSod,SUM(NSodKF) As NSodKF,SUM(DiscountFactor) As DiscountFactor,SUM(MonKasri) AS MonKasri,SUM(DiscountGet) AS DiscountGet ,(SELECT ISNULL (SUM( KalaFactorBackSell.Mon),0) FROM KalaFactorBackSell  WHERE KalaFactorBackSell.IdFactor IN(SELECT IdFactor FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & "))As MonBack,(SELECT ISNULL (SUM(dbo.GetSodFactor(Listback.IdFactor,'BF',Listback.d_Date,'True')),0) FROM (SELECT IdFactor,D_date=(Case When [IdFacSell] IS  NULL THEN D_date ELSE (SELECT D_date From ListFactorSell WHERE ListFactorSell.IdFactor =ListFactorBackSell.IdFacSell) END) FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & ") As Listback) AS NSodBF  FROM ( SELECT  IdPeople ,(SELECT ISNULL(SUM(Mon),0) AS MonFac FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor ) As MonFac,(SELECT ISNULL(SUM(Discount),0) AS DiscountFactor FROM (SELECT  ISNULL(SUM(DarsadMon ),0) AS Discount FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ((Discount +MonDec)-MonAdd)   FROM ListFactorSell WHERE IdFactor =ListFactor.IdFactor) As ListDiscount) As DiscountFactor ,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'F',ListFactor.d_Date,'False')) AS NSod,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'KF',ListFactor.d_Date,'True')) AS NSodKF,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor =ListFactor.IdFactor) As MonKasri,(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListFactor.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As DiscountGet FROM  (SELECT   IdFactor,D_date,IdName As IdPeople  FROM  ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1)" & concity & condition & condition3 & Group & ") As ListFactor) As EndList GROUP By IdPeople) As ListAllSod INNER JOIN Define_People ON Define_People.ID =ListAllSod.IdPeople ORDER BY Nam "
            Else
                If RdoOneGroup.Checked = True Then
                    Return "SELECT Define_People.Nam,C_Count,MonFac,NSod,DiscountFactor,DiscountGet,(NSod - DiscountFactor- DiscountGet-NSodKF-NSodBF) As Sod,MonBack,MonKasri,Group_Kala,IdPeople AS Id,Darsad=Case WHEN MonFac<=0 THEN 0 ELSE  ROUND((NSod - DiscountFactor-DiscountGet-NSodKF-NSodBF)*100/MonFac,2) END  FROM(SELECT IdPeople,COUNT(IdPeople) As C_Count,SUM(MonFac) As MonFac ,SUM(NSod) As NSod,SUM(NSodKF) As NSodKF,SUM(DiscountFactor) As DiscountFactor,SUM(MonKasri) AS MonKasri,SUM(DiscountGet) AS DiscountGet ,MAX(Group_Kala ) As Group_Kala,(SELECT ISNULL (SUM( KalaFactorBackSell.Mon),0) FROM KalaFactorBackSell  WHERE KalaFactorBackSell.IdFactor IN(SELECT IdFactor FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & "))As MonBack,(SELECT ISNULL (SUM(dbo.GetSodFactor(Listback.IdFactor,'BF',Listback.d_Date,'True')),0) FROM (SELECT IdFactor,D_date=(Case When [IdFacSell] IS  NULL THEN D_date ELSE (SELECT D_date From ListFactorSell WHERE ListFactorSell.IdFactor =ListFactorBackSell.IdFacSell) END) FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & ") As Listback) AS NSodBF  FROM ( SELECT  IdPeople,(SELECT ISNULL(SUM(Mon),0) AS MonFac FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor ) As MonFac,(SELECT ISNULL(SUM(Discount),0) AS DiscountFactor FROM (SELECT  ISNULL(SUM(DarsadMon ),0) AS Discount FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ((Discount +MonDec)-MonAdd)   FROM ListFactorSell WHERE IdFactor =ListFactor.IdFactor) As ListDiscount) As DiscountFactor ,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'F',ListFactor.d_Date,'False')) AS NSod,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'KF',ListFactor.d_Date,'True')) AS NSodKF,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor =ListFactor.IdFactor) As MonKasri,(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListFactor.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As DiscountGet,(SELECT COUNT(DISTINCT Define_Kala.IdCodeOne) FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id WHERE KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =IdPeople " & condition2 & " ))) As Group_Kala FROM  (SELECT   IdFactor,D_date ,IdName As IdPeople  FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN  Define_City ON Define_People.IdCity = Define_City.Code WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1)" & concity & condition & condition3 & Group & ") As ListFactor) As EndList GROUP By IdPeople) As ListAllSod INNER JOIN Define_People ON Define_People.ID =ListAllSod.IdPeople ORDER BY Nam "
                ElseIf RdoTwoGroup.Checked = True Then
                    Return "SELECT Define_People.Nam,C_Count,MonFac,NSod,DiscountFactor,DiscountGet,(NSod - DiscountFactor- DiscountGet-NSodKF-NSodBF) As Sod,MonBack,MonKasri,Group_Kala,IdPeople As Id,Darsad=Case WHEN MonFac<=0 THEN 0 ELSE  ROUND((NSod - DiscountFactor-DiscountGet-NSodKF-NSodBF)*100/MonFac,2) END  FROM(SELECT IdPeople,COUNT(IdPeople) As C_Count,SUM(MonFac) As MonFac ,SUM(NSod) As NSod,SUM(NSodKF) As NSodKF,SUM(DiscountFactor) As DiscountFactor,SUM(MonKasri) AS MonKasri,SUM(DiscountGet) AS DiscountGet ,MAX(Group_Kala ) As Group_Kala,(SELECT ISNULL (SUM( KalaFactorBackSell.Mon),0) FROM KalaFactorBackSell  WHERE KalaFactorBackSell.IdFactor IN(SELECT IdFactor FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & "))As MonBack,(SELECT ISNULL (SUM(dbo.GetSodFactor(Listback.IdFactor,'BF',Listback.d_Date,'True')),0) FROM (SELECT IdFactor,D_date=(Case When [IdFacSell] IS  NULL THEN D_date ELSE (SELECT D_date From ListFactorSell WHERE ListFactorSell.IdFactor =ListFactorBackSell.IdFacSell) END) FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & ") As Listback) AS NSodBF  FROM ( SELECT  IdPeople,(SELECT ISNULL(SUM(Mon),0) AS MonFac FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor ) As MonFac,(SELECT ISNULL(SUM(Discount),0) AS DiscountFactor FROM (SELECT  ISNULL(SUM(DarsadMon ),0) AS Discount FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ((Discount +MonDec)-MonAdd)   FROM ListFactorSell WHERE IdFactor =ListFactor.IdFactor) As ListDiscount) As DiscountFactor ,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'F',ListFactor.d_Date,'False')) AS NSod,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'KF',ListFactor.d_Date,'True')) AS NSodKF,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor =ListFactor.IdFactor) As MonKasri,(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListFactor.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As DiscountGet,(SELECT COUNT(DISTINCT Define_Kala.IdCodeTwo) FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id WHERE KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =IdPeople " & condition2 & " ))) As Group_Kala FROM  (SELECT   IdFactor,D_date ,IdName As IdPeople  FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN  Define_City ON Define_People.IdCity = Define_City.Code WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1)" & concity & condition & condition3 & Group & ") As ListFactor) As EndList GROUP By IdPeople) As ListAllSod INNER JOIN Define_People ON Define_People.ID =ListAllSod.IdPeople ORDER BY Nam "
                ElseIf RdoOneCoding.Checked = True Then
                    Return "SELECT Define_People.Nam,C_Count,MonFac,NSod,DiscountFactor,DiscountGet,(NSod - DiscountFactor- DiscountGet-NSodKF-NSodBF) As Sod,MonBack,MonKasri,Group_Kala,IdPeople AS Id,Darsad=Case WHEN MonFac<=0 THEN 0 ELSE  ROUND((NSod - DiscountFactor-DiscountGet-NSodKF-NSodBF)*100/MonFac,2) END  FROM(SELECT IdPeople,COUNT(IdPeople) As C_Count,SUM(MonFac) As MonFac ,SUM(NSod) As NSod,SUM(NSodKF) As NSodKF,SUM(DiscountFactor) As DiscountFactor,SUM(MonKasri) AS MonKasri,SUM(DiscountGet) AS DiscountGet ,MAX(Group_Kala ) As Group_Kala,(SELECT ISNULL (SUM( KalaFactorBackSell.Mon),0) FROM KalaFactorBackSell  WHERE KalaFactorBackSell.IdFactor IN(SELECT IdFactor FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & "))As MonBack,(SELECT ISNULL (SUM(dbo.GetSodFactor(Listback.IdFactor,'BF',Listback.d_Date,'True')),0) FROM (SELECT IdFactor,D_date=(Case When [IdFacSell] IS  NULL THEN D_date ELSE (SELECT D_date From ListFactorSell WHERE ListFactorSell.IdFactor =ListFactorBackSell.IdFacSell) END) FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & ") As Listback) AS NSodBF  FROM ( SELECT  IdPeople,(SELECT ISNULL(SUM(Mon),0) AS MonFac FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor ) As MonFac,(SELECT ISNULL(SUM(Discount),0) AS DiscountFactor FROM (SELECT  ISNULL(SUM(DarsadMon ),0) AS Discount FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ((Discount +MonDec)-MonAdd)   FROM ListFactorSell WHERE IdFactor =ListFactor.IdFactor) As ListDiscount) As DiscountFactor ,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'F',ListFactor.d_Date,'False')) AS NSod,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'KF',ListFactor.d_Date,'True')) AS NSodKF,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor =ListFactor.IdFactor) As MonKasri,(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListFactor.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As DiscountGet,(SELECT COUNT(DISTINCT Define_OneGroup.IdCodeOne) FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id  WHERE Define_OneGroup.IdCodeOne IS NOT NULL AND Define_OneGroup.IdCodeOne<>'' AND KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =IdPeople " & condition2 & "))) As Group_Kala FROM  (SELECT IdFactor,D_date,IdName As IdPeople  FROM  ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1)" & concity & condition & condition3 & Group & ") As ListFactor) As EndList GROUP By IdPeople) As ListAllSod INNER JOIN Define_People ON Define_People.ID =ListAllSod.IdPeople ORDER BY Nam "
                Else
                    Return "SELECT Define_People.Nam,C_Count,MonFac,NSod,DiscountFactor,DiscountGet,(NSod - DiscountFactor- DiscountGet-NSodKF-NSodBF) As Sod,MonBack,MonKasri,Group_Kala,IdPeople As Id,Darsad=Case WHEN MonFac<=0 THEN 0 ELSE  ROUND((NSod - DiscountFactor-DiscountGet-NSodKF-NSodBF)*100/MonFac,2) END  FROM(SELECT IdPeople,COUNT(IdPeople) As C_Count,SUM(MonFac) As MonFac ,SUM(NSod) As NSod,SUM(NSodKF) As NSodKF,SUM(DiscountFactor) As DiscountFactor,SUM(MonKasri) AS MonKasri,SUM(DiscountGet) AS DiscountGet ,MAX(Group_Kala ) As Group_Kala,(SELECT ISNULL (SUM( KalaFactorBackSell.Mon),0) FROM KalaFactorBackSell  WHERE KalaFactorBackSell.IdFactor IN(SELECT IdFactor FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & "))As MonBack,(SELECT ISNULL (SUM(dbo.GetSodFactor(Listback.IdFactor,'BF',Listback.d_Date,'True')),0) FROM (SELECT IdFactor,D_date=(Case When [IdFacSell] IS  NULL THEN D_date ELSE (SELECT D_date From ListFactorSell WHERE ListFactorSell.IdFactor =ListFactorBackSell.IdFacSell) END) FROM  ListFactorBackSell WHERE  ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdName=IdPeople " & condition & ") As Listback) AS NSodBF  FROM ( SELECT  IdPeople,(SELECT ISNULL(SUM(Mon),0) AS MonFac FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor ) As MonFac,(SELECT ISNULL(SUM(Discount),0) AS DiscountFactor FROM (SELECT  ISNULL(SUM(DarsadMon ),0) AS Discount FROM KalaFactorSell WHERE IdFactor =ListFactor.IdFactor UNION ALL SELECT ((Discount +MonDec)-MonAdd)   FROM ListFactorSell WHERE IdFactor =ListFactor.IdFactor) As ListDiscount) As DiscountFactor ,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'F',ListFactor.d_Date,'False')) AS NSod,(SELECT dbo.GetSodFactor(ListFactor.IdFactor,'KF',ListFactor.d_Date,'True')) AS NSodKF,(SELECT ISNULL(SUM(KalaKasriFactor.Mon),0) FROM  KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor WHERE ListKasriFactor.IdFactor =ListFactor.IdFactor) As MonKasri,(SELECT ISNULL(SUM(Discount),0) As Discount FROM Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Get_Pay_Sanad.Active  =1 AND Id IN (SELECT IdSanad FROM (SELECT IdSanad,COUNT(IdSanad ) As C_Count FROM PayLimitFrosh WHERE IdSanad IN (SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =ListFactor.IdFactor) GROUP BY IdSanad) As ListSanad WHERE C_Count =1)) As DiscountGet,(SELECT COUNT(DISTINCT Define_TwoGroup.IdCodeTwo) FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id  WHERE Define_TwoGroup.IdCodeTwo IS NOT NULL AND Define_TwoGroup.IdCodeTwo<>'' AND KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =IdPeople " & condition2 & "))) As Group_Kala FROM  (SELECT IdFactor,D_date,IdName As IdPeople FROM  ListFactorSell  WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1)" & concity & condition & condition3 & Group & ") As ListFactor) As EndList GROUP By IdPeople) As ListAllSod INNER JOIN Define_People ON Define_People.ID =ListAllSod.IdPeople ORDER BY Nam "
                End If
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor2", "SetQuery")
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
        Access_Form = Get_Access_Form("F116")
        If (Access_Form <> "-1") Then
            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    If Access_Form.Substring(3, 1) = 0 Then
                        Button1.Enabled = False
                    End If
                End If
            End If
        End If
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
        DGV1.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub TxtIdFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtIdFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

            If RdoCity.Checked = True Then
                If String.IsNullOrEmpty(TxtCity.Text) Or String.IsNullOrEmpty(TxtIdCity.Text) Then
                    MessageBox.Show("شهرستان را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCity.Focus()
                    Exit Sub
                End If
            End If

            If RdoVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtNameVisit.Text) Or String.IsNullOrEmpty(TxtIdVisit.Text) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNameVisit.Focus()
                    Exit Sub
                End If
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

            If ChkGroup.Checked = True Then
                If String.IsNullOrEmpty(TxtGroup.Text) Or String.IsNullOrEmpty(TxtIdGroup.Text) Then
                    MessageBox.Show("هیچ گروهی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtGroup.Focus()
                    Exit Sub
                End If
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود طرف حسابها", "محاسبه سود", "", "")

            Me.GetFactor()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor2", "BtnShow_Click")
            Me.Enabled = True
            Me.Close()
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

        Try
            If DGV1.Item("cln_Sod", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value < 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value = 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "SodeTarafHesab.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnShow.Enabled = True Then Call BtnShow_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If BtnShow.Enabled = True Then Call BtnShow_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Call Button2_Click(Nothing, Nothing)
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
        Else
            TxtNameVisit.Text = ""
            TxtIdVisit.Text = ""
        End If
    End Sub


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
    Private Sub Calculate()
        Try
            Dim Sod As Double = 0
            Dim DiscountFactor As Double = 0
            Dim NSod As Double = 0
            Dim MonFac As Double = 0
            Dim DiscountGet As Double = 0
            Dim Kosorat As Double = 0
            Dim bargasht As Double = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                Sod += CDbl(DGV1.Item("Cln_Sod", i).Value)
                DiscountFactor += CDbl(DGV1.Item("Column2", i).Value)
                NSod += CDbl(DGV1.Item("Cln_NSod", i).Value)
                MonFac += CDbl(DGV1.Item("Cln_MonFac", i).Value)
                DiscountGet += CDbl(DGV1.Item("Cln_Discount", i).Value)
                Kosorat += CDbl(DGV1.Item("Column3", i).Value)
                bargasht += CDbl(DGV1.Item("Column4", i).Value)
            Next
            TxtSod.Text = FormatNumber(Sod, 0)
            TxtDiscountFac.Text = FormatNumber(DiscountFactor, 0)
            TxtNSOD.Text = FormatNumber(NSod, 0)
            TxtSELL.Text = FormatNumber(MonFac, 0)
            TxtDiscountGet.Text = FormatNumber(DiscountGet, 0)
            TxtKsorat.Text = FormatNumber(Kosorat, 0)
            TxtBarGasht.Text = FormatNumber(bargasht, 0)
            If MonFac <= 0 Then
                TxtDarsad.Text = 0
            Else
                TxtDarsad.Text = Replace(Math.Round(Sod * 100 / MonFac, 2), ".", "/")
            End If
        Catch ex As Exception
            TxtSod.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
            TxtDarsad.Text = 0
        End Try
    End Sub

    Private Sub TxtDiscountFac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountFac.TextChanged
        If Not (CheckDigit(TxtDiscountFac.Text.Replace(",", ""))) Then
            TxtDiscountFac.Text = 0
            If CDbl(TxtDiscountFac.Text.Trim) = 0 Then
                TxtDiscountFac.BackColor = Color.Yellow
            ElseIf CDbl(TxtDiscountFac.Text.Trim) > 0 Then
                TxtDiscountFac.BackColor = Color.White
            ElseIf CDbl(TxtDiscountFac.Text.Trim) < 0 Then
                TxtDiscountFac.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtDiscountFac.Text.Trim) = 0 Then
            TxtDiscountFac.BackColor = Color.Yellow
        ElseIf CDbl(TxtDiscountFac.Text.Trim) > 0 Then
            TxtDiscountFac.BackColor = Color.White
        ElseIf CDbl(TxtDiscountFac.Text.Trim) < 0 Then
            TxtDiscountFac.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtSod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSod.TextChanged
        If Not (CheckDigit(TxtSod.Text.Replace(",", ""))) Then
            TxtSod.Text = 0
            If CDbl(TxtSod.Text.Trim) = 0 Then
                TxtSod.BackColor = Color.Yellow
            ElseIf CDbl(TxtSod.Text.Trim) > 0 Then
                TxtSod.BackColor = Color.White
            ElseIf CDbl(TxtSod.Text.Trim) < 0 Then
                TxtSod.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtSod.Text.Trim) = 0 Then
            TxtSod.BackColor = Color.Yellow
        ElseIf CDbl(TxtSod.Text.Trim) > 0 Then
            TxtSod.BackColor = Color.White
        ElseIf CDbl(TxtSod.Text.Trim) < 0 Then
            TxtSod.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtKsorat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKsorat.TextChanged
        If Not (CheckDigit(TxtKsorat.Text.Replace(",", ""))) Then
            TxtKsorat.Text = 0
            If CDbl(TxtKsorat.Text.Trim) = 0 Then
                TxtKsorat.BackColor = Color.Yellow
            ElseIf CDbl(TxtKsorat.Text.Trim) > 0 Then
                TxtKsorat.BackColor = Color.White
            ElseIf CDbl(TxtKsorat.Text.Trim) < 0 Then
                TxtKsorat.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtKsorat.Text.Trim) = 0 Then
            TxtKsorat.BackColor = Color.Yellow
        ElseIf CDbl(TxtKsorat.Text.Trim) > 0 Then
            TxtKsorat.BackColor = Color.White
        ElseIf CDbl(TxtKsorat.Text.Trim) < 0 Then
            TxtKsorat.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtBarGasht_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBarGasht.TextChanged
        If Not (CheckDigit(TxtBarGasht.Text.Replace(",", ""))) Then
            TxtBarGasht.Text = 0
            If CDbl(TxtBarGasht.Text.Trim) = 0 Then
                TxtBarGasht.BackColor = Color.Yellow
            ElseIf CDbl(TxtBarGasht.Text.Trim) > 0 Then
                TxtBarGasht.BackColor = Color.White
            ElseIf CDbl(TxtBarGasht.Text.Trim) < 0 Then
                TxtBarGasht.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtBarGasht.Text.Trim) = 0 Then
            TxtBarGasht.BackColor = Color.Yellow
        ElseIf CDbl(TxtBarGasht.Text.Trim) > 0 Then
            TxtBarGasht.BackColor = Color.White
        ElseIf CDbl(TxtBarGasht.Text.Trim) < 0 Then
            TxtBarGasht.BackColor = Color.Pink
        End If
    End Sub


    Private Sub TxtCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCity.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCity.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New City_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtCity.Focus()
        If Tmp_Namkala <> "" Then
            TxtCity.Text = Tmp_Namkala
            TxtIdCity.Text = IdKala
        Else
            TxtCity.Text = ""
            TxtIdCity.Text = ""
        End If
    End Sub

    Private Sub DGV1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGV1.RowPrePaint
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

        Try
            If DGV1.Item("cln_Sod", e.RowIndex).Value > 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value < 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf DGV1.Item("cln_Sod", e.RowIndex).Value = 0 Then
                DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("گزارشی جهت چاپ وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Array.Resize(ListDelayPrintArray, 0)
            Dim frosh As String = ""
            If RdoOneGroup.Checked = True Then
                frosh = "فروش جور بر حسب : " & "گروه اصلی"
            ElseIf RdoTwoGroup.Checked = True Then
                frosh = "فروش جور بر حسب : " & "گروه فرعی"
            ElseIf RdoOneCoding.Checked = True Then
                frosh = "فروش جور بر حسب : " & "کدینگ گروه اصلی"
            ElseIf RdoTwoCoding.Checked = True Then
                frosh = "فروش جور بر حسب : " & "کدینگ گروه فرعی"
            End If
            For i As Integer = 0 To DGV1.RowCount - 1
                Array.Resize(ListDelayPrintArray, ListDelayPrintArray.Length + 1)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell1 = DGV1.Item("Column1", i).Value.ToString
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).IdFactor = DGV1.Item("Cln_Idf", i).Value
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tmp = CDbl(DGV1.Item("Cln_MonFac", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).D_Date = If(ChkFrosh.Checked = True, DGV1.Item("Cln_KindFrosh", i).Value, "")
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).EndDate = frosh
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Disc = ""
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Nam2 = ""
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Rate = CDbl(DGV1.Item("Cln_Nsod", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Remain = CDbl(DGV1.Item("Cln_Discount", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).TimeRemain = CDbl(DGV1.Item("cln_Sod", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Mandeh = CDbl(DGV1.Item("Column2", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).T = CDbl(DGV1.Item("Column4", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Tell2 = CDbl(DGV1.Item("Column3", i).Value)
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).Darsad = Replace(DGV1.Item("Cln_Darsad", i).Value, ".", "/")
                ListDelayPrintArray(ListDelayPrintArray.Length - 1).SUMDarsad = TxtDarsad.Text
            Next
            Me.Enabled = False
            If ChkFrosh.Checked = False Then
                FrmPrint.CHoose = "SODPRINT3"
            Else
                FrmPrint.CHoose = "SODPRINT3_1"
            End If

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود طرف حسابها", "چاپ لیست", "", "")
            FrmPrint.ShowDialog()
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SodFactor2", "Button1_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub TxtDiscountGet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountGet.TextChanged
        If Not (CheckDigit(TxtDiscountGet.Text.Replace(",", ""))) Then
            TxtDiscountGet.Text = 0
            If CDbl(TxtDiscountGet.Text.Trim) = 0 Then
                TxtDiscountGet.BackColor = Color.Yellow
            ElseIf CDbl(TxtDiscountGet.Text.Trim) > 0 Then
                TxtDiscountGet.BackColor = Color.White
            ElseIf CDbl(TxtDiscountGet.Text.Trim) < 0 Then
                TxtDiscountGet.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtDiscountGet.Text.Trim) = 0 Then
            TxtDiscountGet.BackColor = Color.Yellow
        ElseIf CDbl(TxtDiscountGet.Text.Trim) > 0 Then
            TxtDiscountGet.BackColor = Color.White
        ElseIf CDbl(TxtDiscountGet.Text.Trim) < 0 Then
            TxtDiscountGet.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtNSOD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNSOD.TextChanged
        If Not (CheckDigit(TxtNSOD.Text.Replace(",", ""))) Then
            TxtNSOD.Text = 0
            If CDbl(TxtNSOD.Text.Trim) = 0 Then
                TxtNSOD.BackColor = Color.Yellow
            ElseIf CDbl(TxtNSOD.Text.Trim) > 0 Then
                TxtNSOD.BackColor = Color.White
            ElseIf CDbl(TxtNSOD.Text.Trim) < 0 Then
                TxtNSOD.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtNSOD.Text.Trim) = 0 Then
            TxtNSOD.BackColor = Color.Yellow
        ElseIf CDbl(TxtNSOD.Text.Trim) > 0 Then
            TxtNSOD.BackColor = Color.White
        ElseIf CDbl(TxtNSOD.Text.Trim) < 0 Then
            TxtNSOD.BackColor = Color.Pink
        End If
    End Sub

    Private Sub TxtSELL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSELL.TextChanged
        If Not (CheckDigit(TxtSELL.Text.Replace(",", ""))) Then
            TxtSELL.Text = 0
            If CDbl(TxtSELL.Text.Trim) = 0 Then
                TxtSELL.BackColor = Color.Yellow
            ElseIf CDbl(TxtSELL.Text.Trim) > 0 Then
                TxtSELL.BackColor = Color.White
            ElseIf CDbl(TxtSELL.Text.Trim) < 0 Then
                TxtSELL.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtSELL.Text.Trim) = 0 Then
            TxtSELL.BackColor = Color.Yellow
        ElseIf CDbl(TxtSELL.Text.Trim) > 0 Then
            TxtSELL.BackColor = Color.White
        ElseIf CDbl(TxtSELL.Text.Trim) < 0 Then
            TxtSELL.BackColor = Color.Pink
        End If
    End Sub

    Private Sub ChkFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFrosh.CheckedChanged
        If ChkFrosh.Checked = True Then
            RdoOneGroup.Enabled = True
            RdoTwoGroup.Enabled = True
            RdoOneCoding.Enabled = True
            RdoTwoCoding.Enabled = True
            RdoTwoGroup.Checked = True
            DGV1.DataSource = Nothing
            TxtSod.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtDarsad.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
            DGV1.Columns("Cln_KindFrosh").Visible = True
            ToolShow.Visible = True
            Button2.Enabled = True
            Button2.Visible = True
        Else
            RdoOneGroup.Enabled = False
            RdoTwoGroup.Enabled = False
            RdoOneCoding.Enabled = False
            RdoTwoCoding.Enabled = False
            DGV1.DataSource = Nothing
            TxtSod.Text = 0
            TxtDarsad.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
            DGV1.Columns("Cln_KindFrosh").Visible = False
            ToolShow.Visible = False
            Button2.Enabled = False
            Button2.Visible = False
        End If
    End Sub

    Private Sub RdoOneGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOneGroup.CheckedChanged
        If RdoOneGroup.Checked = True Then
            DGV1.DataSource = Nothing
            TxtSod.Text = 0
            TxtDarsad.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
        End If
    End Sub

    Private Sub RdoTwoGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTwoGroup.CheckedChanged
        If RdoTwoGroup.Checked = True Then
            DGV1.DataSource = Nothing
            TxtSod.Text = 0
            TxtDarsad.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
        End If
    End Sub

    Private Sub RdoOneCoding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoOneCoding.CheckedChanged
        If RdoOneCoding.Checked = True Then
            DGV1.DataSource = Nothing
            TxtSod.Text = 0
            TxtDarsad.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
        End If
    End Sub

    Private Sub RdoTwoCoding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoTwoCoding.CheckedChanged
        If RdoTwoCoding.Checked = True Then
            DGV1.DataSource = Nothing
            TxtSod.Text = 0
            TxtDarsad.Text = 0
            TxtDiscountFac.Text = 0
            TxtNSOD.Text = 0
            TxtSELL.Text = 0
            TxtDiscountGet.Text = 0
            TxtKsorat.Text = 0
            TxtBarGasht.Text = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ChkFrosh.Checked = True Then
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("اطلاعاتی برای نمایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_KindFrosh", DGV1.CurrentRow.Index).Value <= 0 Then
                MessageBox.Show("اطلاعاتی برای نمایش وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    condition = " AND (D_Date>=N'" & FarsiDate1.ThisText & "' AND D_Date<=N'" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    condition = " AND (D_Date>=N'" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    condition = " AND (D_Date<=N'" & FarsiDate2.ThisText & "')"
                End If
            End If
            Using nf As New FrmListShowKala
                If RdoOneGroup.Checked = True Then
                    nf.DGV.Columns("Cln_NameOne").HeaderText = "گروه اصلی"
                    nf.DGV.Columns("Cln_NameTwo").Visible = False
                    nf.DGV.Columns("Cln_Code").Visible = False
                    nf.Sql_Str = "SELECT DISTINCT Define_OneGroup.NamOne  FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_OneGroup.Id =Define_Kala .IdCodeOne  WHERE KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =" & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value & condition & " ))"
                    nf.Fill = "Cln_NameOne"
                ElseIf RdoTwoGroup.Checked = True Then
                    nf.DGV.Columns("Cln_NameOne").HeaderText = "گروه اصلی"
                    nf.DGV.Columns("Cln_NameTwo").HeaderText = "گروه فرعی"
                    nf.DGV.Columns("Cln_Code").Visible = False
                    nf.Sql_Str = "SELECT DISTINCT Define_TwoGroup.NamTwo ,Define_OneGroup.NamOne FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_TwoGroup ON Define_TwoGroup.Id =Define_Kala .IdCodeTwo INNER JOIN Define_OneGroup  ON Define_OneGroup .Id =Define_Kala .IdCodeOne   WHERE KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =" & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value & condition & " ))"
                    nf.Fill = "Cln_NameTwo"
                ElseIf RdoOneCoding.Checked = True Then
                    nf.DGV.Columns("Cln_Code").HeaderText = "کدینگ گ.اصلی"
                    nf.DGV.Columns("Cln_NameOne").Visible = False
                    nf.DGV.Columns("Cln_NameTwo").Visible = False
                    nf.Sql_Str = "SELECT DISTINCT Define_OneGroup .IdCodeOne  As Code FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup  ON Define_OneGroup.Id =Define_Kala .IdCodeOne  WHERE Define_OneGroup .IdCodeOne IS NOT NULL AND Define_OneGroup .IdCodeOne <>'' AND KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =" & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value & condition & " ))"
                    nf.Fill = "Cln_Code"
                ElseIf RdoTwoCoding.Checked = True Then
                    nf.DGV.Columns("Cln_Code").HeaderText = "کدینگ گ.فرعی"
                    nf.DGV.Columns("Cln_NameOne").Visible = False
                    nf.DGV.Columns("Cln_NameTwo").Visible = False
                    nf.Sql_Str = "SELECT DISTINCT Define_twoGroup .IdCodetwo  As Code FROM KalaFactorSell INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_TwoGroup  ON Define_twoGroup.Id =Define_Kala .IdCodeTwo  WHERE Define_twoGroup .IdCodetwo IS NOT NULL AND Define_twoGroup .IdCodetwo <>'' AND KalaFactorSell.IdFactor IN (SELECT IdFactor FROM ListFactorSell WHERE (ListFactorSell.Stat =3 AND ListFactorSell.Activ =1 AND ListFactorSell.IdName =" & DGV1.Item("Cln_Id", DGV1.CurrentRow.Index).Value & condition & " ))"
                    nf.Fill = "Cln_Code"
                End If

                TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "سود طرف حسابها", "نمایش فروش جور", "نمایش فروش جور طرف حساب:" & DGV1.Item("Column1", DGV1.CurrentRow.Index).Value, "")
                nf.ShowDialog()

            End Using
        End If
    End Sub

    Private Sub RdoExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoExit.CheckedChanged
        If RdoExit.Checked = True Then
            TxtExit.Enabled = True
            TxtExit.Focus()
        Else
            TxtExit.Text = ""
            TxtExit.Enabled = False
        End If
    End Sub

    Private Sub RdoCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCity.CheckedChanged
        If RdoCity.Checked = True Then
            TxtCity.Enabled = True
            TxtCity.Focus()
        Else
            TxtCity.Text = ""
            TxtCity.Enabled = False
        End If
    End Sub

    Private Sub RdoVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoVisitor.CheckedChanged
        If RdoVisitor.Checked = True Then
            TxtNameVisit.Enabled = True
            TxtNameVisit.Focus()
        Else
            TxtNameVisit.Text = ""
            TxtNameVisit.Enabled = False
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

    Private Sub TxtDarsad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDarsad.TextChanged
        If Not (CheckDigit(TxtDarsad.Text.Replace("/", "."))) Then
            TxtDarsad.Text = 0
            If CDbl(TxtDarsad.Text.Trim) = 0 Then
                TxtDarsad.BackColor = Color.Yellow
            ElseIf CDbl(TxtDarsad.Text.Trim) > 0 Then
                TxtDarsad.BackColor = Color.White
            ElseIf CDbl(TxtDarsad.Text.Trim) < 0 Then
                TxtDarsad.BackColor = Color.Pink
            End If
            Exit Sub
        End If
        If CDbl(TxtDarsad.Text.Trim) = 0 Then
            TxtDarsad.BackColor = Color.Yellow
        ElseIf CDbl(TxtDarsad.Text.Trim) > 0 Then
            TxtDarsad.BackColor = Color.White
        ElseIf CDbl(TxtDarsad.Text.Trim) < 0 Then
            TxtDarsad.BackColor = Color.Pink
        End If
    End Sub

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If ChkGroup.Checked = True Then
            TxtGroup.Enabled = True
            TxtGroup.Focus()
        Else
            TxtGroup.Enabled = False
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

    Private Sub TxtGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnShow_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroup.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Group_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtGroup.Focus()
        If Tmp_Namkala <> "" Then
            TxtGroup.Text = Tmp_Namkala
            TxtIdGroup.Text = IdKala
        Else
            TxtGroup.Text = ""
            TxtIdGroup.Text = ""
        End If
    End Sub

End Class