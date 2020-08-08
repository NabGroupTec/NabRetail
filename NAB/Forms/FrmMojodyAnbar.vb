Imports System.Data.SqlClient
Public Class FrmMojodyAnbar

    Dim dv As New DataView
    Dim Ds As New DataSet
    Dim Dta As New SqlDataAdapter()

    Private Sub FrmMojodyKala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmMojodyKala_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F63")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                Else
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی انبار", "ورود", "", "")
                End If
                If Access_Form.Substring(3, 1) = 0 Then
                    BtnReport.Enabled = False
                End If
            End If
        Else
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی انبار", "ورود", "", "")
        End If

        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()

        Me.GetKala()
        DGV.Columns("Cln_Nam").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub GetKala()
        Try
            Me.Enabled = False
            Ds.Clear()
            If Not Dta Is Nothing Then
                Dta.Dispose()
            End If
            '''''''''''''''''''''''''''
            Dim Dat As String = ""
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                Dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
            ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                Dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
            ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                Dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
            End If

            Dim sqlstr As String = ""
            sqlstr = "If (SELECT COUNT(IdUser) FROM Define_UserRAnbar  WHERE IdUser =" & Id_User & ")=0 SELECT * FROM (SELECT AllKalaAnbar.*,(SELECT ROUND(ISNULL(SUM(AllKolCount.KolCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & "  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(AllJozCount.JozCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllJozCount)JozCount FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Kala.Nam,Define_Kala.IdCodeOne ,Define_Kala.IdCodeTwo ,Define_Kala.Activ FROM Define_Kala ) AS AllKala ,Define_Anbar ) As AllKalaAnbar) As AllAnbar Order by Nam  else SELECT * FROM(SELECT AllKalaAnbar.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & "  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllJozCount)JozCount FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Ex_Date,Define_Kala.Id,Define_Kala.Nam,Define_Kala.IdCodeOne ,Define_Kala.IdCodeTwo FROM Define_Kala ) AS AllKala ,Define_Anbar ) As AllKalaAnbar WHERE Idanbar  in (SELECT IDA   FROM Define_UserRPAnbar   WHERE IdUser =" & Id_User & ")) As AllAnbar Order by Nam"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMojodyAnbar", "GetKala")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("کالایی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Group As String = ""
        If ChkGroup.Checked = True Then
            If ChkTwoGroup.Checked = True Then
                If String.IsNullOrEmpty(CmbOne.Text) Or String.IsNullOrEmpty(Cmbtwo.Text) Then
                    Group = ""
                Else
                    Group = "IdCodeOne =" & CmbOne.SelectedValue & " and IdCodeTwo =" & Cmbtwo.SelectedValue
                End If
            Else
                If String.IsNullOrEmpty(CmbOne.Text) Then
                    Group = ""
                Else
                    Group = "IdCodeOne =" & CmbOne.SelectedValue
                End If
            End If
        End If

        Dim Mojody As String = ""
        If ChkMojody.Checked = True Then
            If RdoN.Checked = True Then
                Mojody = "ROUND(KolCount,2)<0"
            ElseIf RdoP.Checked = True Then
                Mojody = "ROUND(KolCount,2)>0"
            ElseIf RdoZ.Checked = True Then
                Mojody = "ROUND(KolCount,2)=0"
            End If
            Mojody = IIf(String.IsNullOrEmpty(Group), Mojody, " AND " + Mojody)
        End If

        If ChkTime.Checked = True Then
            If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                MessageBox.Show("هیچ محدوده زمانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                ChkTaDate.Checked = True
                Exit Sub
            End If
            If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                    MessageBox.Show(" محدوده زمانی اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
        End If

        Dim Dat As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            Dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            Dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            Dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
        End If

        Dim anbar As String = ""
        If ChkAnbar.Checked = True Then
            If String.IsNullOrEmpty(CmbAnbar.Text) Then
                anbar = ""
            Else
                anbar = "IdAnbar =" & CmbAnbar.SelectedValue
            End If
            anbar = IIf(String.IsNullOrEmpty(Mojody) And String.IsNullOrEmpty(Group), anbar, " AND " & anbar)
        End If
        Me.Enabled = False

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "موجودی انبار", "چاپ گزارش", "", "")

        Dim sqlstr As String = ""
        sqlstr = "If (SELECT COUNT(IdUser) FROM Define_UserRAnbar  WHERE IdUser =" & Id_User & ")=0 SELECT GroupKala,Id As Wgt,Nam,KolCount As Kol,JozCount As Joz,NamAnbar As AnbarNam FROM (SELECT AllKalaAnbar.*,(SELECT ROUND(ISNULL(SUM(AllKolCount.KolCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & "  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(AllJozCount.JozCount),0),2)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllJozCount)JozCount FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Ex_Date As GroupKala,Define_Kala.Id,Define_Kala.Nam,Define_Kala.IdCodeOne ,Define_Kala.IdCodeTwo FROM Define_Kala ) AS AllKala ,Define_Anbar ) As AllKalaAnbar) As AllAnbar " & If(String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Mojody) And String.IsNullOrEmpty(anbar), "", " WHERE " & Group & Mojody & anbar) & " Order by Nam  else SELECT GroupKala,Id As Wgt,Nam,KolCount As Kol,JozCount As Joz,NamAnbar As AnbarNam FROM(SELECT AllKalaAnbar.*,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & "  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllKolCount)KolCount,(SELECT ISNULL(SUM(AllJozCount.JozCount),0)  FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdOneAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =AllKalaAnbar .ID AND IdTwoAnbar  =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKalaAnbar .ID AND IdAnbar =AllKalaAnbar .IDAnbar " & Dat & ") AS AllJozCount)JozCount FROM (SELECT AllKala.*,Define_Anbar .nam As NamAnbar,Define_Anbar .ID as Idanbar FROM (SELECT Define_Kala.Ex_Date As GroupKala,Define_Kala.Id,Define_Kala.Nam,Define_Kala.IdCodeOne ,Define_Kala.IdCodeTwo FROM Define_Kala ) AS AllKala ,Define_Anbar ) As AllKalaAnbar WHERE Idanbar  in (SELECT IDA   FROM Define_UserRPAnbar   WHERE IdUser =" & Id_User & ")) As AllAnbar " & If(String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Mojody) And String.IsNullOrEmpty(anbar), "", " WHERE " & Group & Mojody & anbar) & " Order by Nam"
        FrmPrint.PrintSQl = sqlstr
        FrmPrint.CHoose = "MOJODYANBAR"
        FrmPrint.ShowDialog()
        Me.Enabled = True
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "MojodiAnbar.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnReport.Enabled = True Then BtnReport_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
        ElseIf e.KeyCode = Keys.F6 Then
            If BtnKardex.Enabled = True Then BtnKardex_Click(Nothing, Nothing)
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

    Private Sub DGV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        Call BtnKardex_Click(Nothing, Nothing)
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

        If CDbl(DGV.Item("cln_KolCount", e.RowIndex).Value) = 0 Then
            DGV.Rows(e.RowIndex).Cells("Cln_KolCount").Style.BackColor = Color.Yellow
        ElseIf CDbl(DGV.Item("cln_KolCount", e.RowIndex).Value) < 0 Then
            DGV.Rows(e.RowIndex).Cells("Cln_KolCount").Style.BackColor = Color.Pink
        ElseIf CDbl(DGV.Item("cln_KolCount", e.RowIndex).Value) > 0 Then
            DGV.Rows(e.RowIndex).Cells("Cln_KolCount").Style.BackColor = Color.White
        End If

        If CDbl(DGV.Item("cln_JozCount", e.RowIndex).Value) = 0 Then
            DGV.Rows(e.RowIndex).Cells("cln_JozCount").Style.BackColor = Color.Yellow
        ElseIf CDbl(DGV.Item("cln_JozCount", e.RowIndex).Value) < 0 Then
            DGV.Rows(e.RowIndex).Cells("cln_JozCount").Style.BackColor = Color.Pink
        ElseIf CDbl(DGV.Item("cln_JozCount", e.RowIndex).Value) > 0 Then
            DGV.Rows(e.RowIndex).Cells("cln_JozCount").Style.BackColor = Color.White
        End If
    End Sub

    Private Sub ChkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If ChkGroup.Checked = True Then
            Me.Get_OneGroup()
            CmbOne_SelectedIndexChanged(Nothing, Nothing)
            Cmbtwo_SelectedIndexChanged(Nothing, Nothing)

            CmbOne.Enabled = True
            Cmbtwo.Enabled = True
            ChkTwoGroup.Enabled = True
            CmbOne.Focus()
        Else
            CmbOne.Enabled = False
            Cmbtwo.Enabled = False
            ChkTwoGroup.Enabled = False
            CmbOne.DataSource = Nothing
            Cmbtwo.DataSource = Nothing
            ChkTwoGroup.Checked = False
        End If
        Me.Setfilter()
    End Sub

    Private Sub Get_OneGroup()
        Try
            Dim Ds_O As New DataTable
            Dim Dta_O As New SqlDataAdapter
            If Not Dta_O Is Nothing Then Dta_O.Dispose()
            Dta_O = New SqlDataAdapter("SELECT Id, NamOne FROM Define_OneGroup", DataSource)
            Dta_O.Fill(Ds_O)
            CmbOne.DataSource = Ds_O
            CmbOne.DisplayMember = "NamOne"
            CmbOne.ValueMember = "Id"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMojodyAnbar", "Get_OneGroup")
            Me.Close()
        End Try
    End Sub

    Private Sub Get_Anbar()
        Try
            Dim Ds_A As New DataTable
            Dim Dta_A As New SqlDataAdapter
            If Not Dta_A Is Nothing Then Dta_A.Dispose()
            Dta_A = New SqlDataAdapter(" If (SELECT COUNT(IdUser) FROM Define_UserRAnbar  WHERE IdUser =" & Id_User & ")=0 SELECT nam, ID FROM  Define_Anbar ELSE SELECT nam, ID FROM  Define_Anbar WHERE Id in (SELECT IDA   FROM Define_UserRPAnbar   WHERE IdUser =" & Id_User & ") ", DataSource)
            Dta_A.Fill(Ds_A)
            CmbAnbar.DataSource = Ds_A
            CmbAnbar.DisplayMember = "Nam"
            CmbAnbar.ValueMember = "Id"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMojodyAnbar", "Get_Anbar")
            Me.Close()
        End Try
    End Sub

    Private Sub Get_TwoGroup(ByVal Id As Long)
        Try
            Dim Ds_C As New DataTable
            Dim Dta_C As New SqlDataAdapter
            If Not Dta_C Is Nothing Then Dta_C.Dispose()
            Dta_C = New SqlDataAdapter("SELECT Id, NamTwo FROM  Define_TwoGroup WHERE IdOne =" & Id, DataSource)
            Dta_C.Fill(Ds_C)
            Cmbtwo.DataSource = Ds_C
            Cmbtwo.DisplayMember = "NamTwo"
            Cmbtwo.ValueMember = "Id"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMojodyAnbar", "Get_TwoGroup")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOne.SelectedIndexChanged
        Try
            If ChkGroup.Checked = True Then
                Cmbtwo.DataSource = Nothing
                Me.Get_TwoGroup(CmbOne.SelectedValue)
                Me.Setfilter()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmbtwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbtwo.SelectedIndexChanged
        If ChkTwoGroup.Checked = True And ChkGroup.Checked = True And Cmbtwo.Enabled = True Then Me.Setfilter()
    End Sub

    Private Sub ChkMojody_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMojody.CheckedChanged
        If ChkMojody.Checked = True Then
            RdoN.Enabled = True
            RdoP.Enabled = True
            RdoZ.Enabled = True
            If RdoP.Checked = False And RdoZ.Checked = False And RdoN.Checked = False Then
                RdoP.Checked = True
            End If
        Else
            RdoN.Enabled = False
            RdoP.Enabled = False
            RdoZ.Enabled = False
        End If
        Me.Setfilter()
    End Sub

    Private Sub ChkTwoGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTwoGroup.CheckedChanged
        If ChkGroup.Checked = True Then Me.Setfilter()
    End Sub

    Private Sub RdoN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoN.CheckedChanged
        If RdoN.Checked = True And ChkMojody.Checked = True Then Me.Setfilter()
    End Sub

    Private Sub RdoZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoZ.CheckedChanged
        If RdoZ.Checked = True And ChkMojody.Checked = True Then Me.Setfilter()
    End Sub

    Private Sub RdoP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoP.CheckedChanged
        If RdoP.Checked = True And ChkMojody.Checked = True Then Me.Setfilter()
    End Sub

    Private Sub ChkAnbar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnbar.CheckedChanged
        If ChkAnbar.Checked = True Then
            Me.Get_Anbar()
            CmbAnbar.Enabled = True
            CmbAnbar_SelectedIndexChanged(Nothing, Nothing)
            CmbAnbar.Focus()
        Else
            CmbAnbar.Enabled = False
            CmbAnbar.DataSource = Nothing
        End If
        Me.Setfilter()
    End Sub

    Private Sub CmbAnbar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAnbar.SelectedIndexChanged
        If ChkAnbar.Checked = True And CmbAnbar.Enabled = True Then Me.Setfilter()
    End Sub

    Private Sub Setfilter()
        Try
            If ChkMojody.Checked = True And ChkGroup.Checked = False And ChkAnbar.Checked = False Then
                dv.RowFilter = If(RdoP.Checked = True, "KolCount>0", If(RdoZ.Checked = True, "KolCount=0", "KolCount<0"))
            ElseIf ChkMojody.Checked = False And ChkGroup.Checked = True And ChkAnbar.Checked = False Then
                dv.RowFilter = "IdCodeOne=" & CmbOne.SelectedValue & If(ChkTwoGroup.Checked = True, " AND IdCodeTwo=" & Cmbtwo.SelectedValue, "")
            ElseIf ChkMojody.Checked = True And ChkGroup.Checked = True And ChkAnbar.Checked = False Then
                dv.RowFilter = If(RdoP.Checked = True, "KolCount>0", If(RdoZ.Checked = True, "KolCount=0", "KolCount<0")) & " AND IdCodeOne=" & CmbOne.SelectedValue & If(ChkTwoGroup.Checked = True, " AND IdCodeTwo=" & Cmbtwo.SelectedValue, "")
            ElseIf ChkMojody.Checked = True And ChkGroup.Checked = False And ChkAnbar.Checked = True Then
                dv.RowFilter = If(RdoP.Checked = True, "KolCount>0", If(RdoZ.Checked = True, "KolCount=0", "KolCount<0")) & " AND IdAnbar=" & CmbAnbar.SelectedValue
            ElseIf ChkMojody.Checked = False And ChkGroup.Checked = True And ChkAnbar.Checked = True Then
                dv.RowFilter = "IdCodeOne=" & CmbOne.SelectedValue & If(ChkTwoGroup.Checked = True, " AND IdCodeTwo=" & Cmbtwo.SelectedValue, "") & " AND IdAnbar=" & CmbAnbar.SelectedValue
            ElseIf ChkMojody.Checked = True And ChkGroup.Checked = True And ChkAnbar.Checked = True Then
                dv.RowFilter = If(RdoP.Checked = True, "KolCount>0", If(RdoZ.Checked = True, "KolCount=0", "KolCount<0")) & " AND IdCodeOne=" & CmbOne.SelectedValue & If(ChkTwoGroup.Checked = True, " AND IdCodeTwo=" & Cmbtwo.SelectedValue, "") & " AND IdAnbar=" & CmbAnbar.SelectedValue
            Else
                dv.RowFilter = ""
            End If
        Catch ex As Exception
            dv.RowFilter = ""
        End Try
    End Sub

    Private Sub BtnKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKardex.Click
        Try
            If DGV.RowCount <= 0 Then Exit Sub
            Using FrmDay As New Kardex_Anbar
                FrmDay.TxtName.Text = DGV.Item("Cln_Nam", DGV.CurrentRow.Index).Value
                FrmDay.TxtIdName.Text = DGV.Item("Cln_Id", DGV.CurrentRow.Index).Value
                FrmDay.TxtIdAnbar.Text = DGV.Item("Cln_IdAnbar", DGV.CurrentRow.Index).Value
                FrmDay.TxtAnbarNam.Text = DGV.Item("Cln_AnbarNam", DGV.CurrentRow.Index).Value
                FrmDay.ShowDialog()
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmMojodyAnbar", "BtnKardex_Click")
        End Try
    End Sub

    Private Sub ChkTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTime.CheckedChanged
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
        If ChkTime.Checked = False Then
            Me.GetKala()
            Me.Setfilter()
        End If
    End Sub

    Private Sub ChkAzDate_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAzDate.CheckedChanged
        If ChkAzDate.Checked = True Then
            FarsiDate1.ThisText = GetDate()
            FarsiDate1.Enabled = True
            FarsiDate1.Focus()
        Else
            FarsiDate1.Enabled = False
            FarsiDate1.ThisText = GetDate()
        End If
        If ChkTime.Checked = True Then
            Me.GetKala()
            Me.Setfilter()
        End If
    End Sub

    Private Sub ChkTaDate_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTaDate.CheckedChanged
        If ChkTaDate.Checked = True Then
            FarsiDate2.ThisText = GetDate()
            FarsiDate2.Enabled = True
            FarsiDate2.Focus()
        Else
            FarsiDate2.Enabled = False
            FarsiDate2.ThisText = GetDate()
        End If

        If ChkTime.Checked = True Then
            Me.GetKala()
            Me.Setfilter()
        End If
    End Sub

    Private Sub FarsiDate1_TextChanging(sender As Object, e As String) Handles FarsiDate1.TextChanging
        If ChkTime.Checked = True Then
            Me.GetKala()
            Me.Setfilter()
        End If
    End Sub

    Private Sub FarsiDate2_TextChanging(sender As Object, e As String) Handles FarsiDate2.TextChanging
        If ChkTime.Checked = True Then
            Me.GetKala()
            Me.Setfilter()
        End If
    End Sub
End Class