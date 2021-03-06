﻿Imports System.Data.SqlClient
Public Class FrmReportFroshVisitor

    Dim ds_User As New DataTable
    Dim dta_User As New SqlDataAdapter()

    Private Sub GetVisitorList()
        Try
            ds_User.Clear()
            If Not dta_User Is Nothing Then
                dta_User.Dispose()
            End If
            '''''''''''''''''''''''''''
            dta_User = New SqlDataAdapter("SELECT Id, Nam FROM  Define_Visitor " & If(Chkvisit.Checked = True, "", " WHERE Activ ='False'"), DataSource)
            dta_User.Fill(ds_User)
            CmbBox.DataSource = ds_User
            CmbBox.DisplayMember = "Nam"
            CmbBox.ValueMember = "ID"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportFroshVisitor", "GetVisitorList")
        End Try
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

    Private Sub FrmSodNKhales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmSodNKhales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F102")
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
        Me.GetKala()
        Me.GetVisitorList()
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
            sqlstr = "SELECT Define_Kala.Activ,Define_Kala.Id,Define_Kala.Nam , Define_OneGroup.NamOne +'-'+ Define_TwoGroup.NamTwo As GroupKala FROM Define_Kala INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne  Order by NamOne ,NamTwo ,Nam"
            Dta = New SqlDataAdapter(sqlstr, DataSource)
            Dta.Fill(Ds, "Define_Kala")
            DGV.AutoGenerateColumns = False
            dv = Ds.Tables("Define_Kala").DefaultView
            DGV.DataSource = dv
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmReportFroshVisitor", "GetKala")
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

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DGV.RowCount <= 0 Then
            MessageBox.Show("کالایی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CmbBox.Text = "" Then
            MessageBox.Show("ویزیتوری جهت تهیه گزارش انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CmbBox.Focus()
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
        If ChkPart.Checked = True Then
            If String.IsNullOrEmpty(CmbOstan.Text) Then
                MessageBox.Show("هیچ استانی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbOstan.Focus()
                Exit Sub
            End If
            If ChkCity.Checked = True Then
                If String.IsNullOrEmpty(CmbCity.Text) Then
                    MessageBox.Show("هیچ شهری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbCity.Focus()
                    Exit Sub
                End If
            End If
            If CheckBox2.Checked = True Then
                If String.IsNullOrEmpty(CmbPart.Text) Then
                    MessageBox.Show("هیچ مسیری انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbPart.Focus()
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
        Dim Listpeople As String = ""
        Dim Countpeople As Long = 0
        Listpeople = " AND ("
        For i As Integer = 0 To DGV.RowCount - 1
            If DGV.Item("Cln_Select", i).Value = True Then
                Listpeople &= "IDKala=" & DGV.Item("Cln_Id", i).Value & " OR "
                Countpeople += 1
            End If
        Next

        If Countpeople = DGV.RowCount Then
            Listpeople = ""
        ElseIf Countpeople <= 0 Then
            MessageBox.Show("کالایی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Listpeople = Listpeople.Substring(0, Listpeople.Length - 4)
            Listpeople &= ")"
        End If

        Dim dat As String = ""
        Dim dat2 As String = ""
        If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "' AND D_date<=N'" & FarsiDate2.ThisText & "')"
            dat2 = " AND (ListKasriFactor.D_date>=N'" & FarsiDate1.ThisText & "' AND ListKasriFactor.D_date<=N'" & FarsiDate2.ThisText & "')"
        ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
            dat = " AND (D_date>=N'" & FarsiDate1.ThisText & "')"
            dat2 = " AND (ListKasriFactor.D_date>=N'" & FarsiDate1.ThisText & "')"
        ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
            dat = " AND (D_date<=N'" & FarsiDate2.ThisText & "')"
            dat2 = " AND (ListKasriFactor.D_date<=N'" & FarsiDate2.ThisText & "')"
        Else
            dat = ""
            dat2 = ""
        End If

        Dim Part As String = ""
        Dim Part2 As String = ""
        If ChkPart.Checked = True Then
            Part = "SELECT ID FROM Define_People WHERE "
            Part &= "IdOstan=" & CmbOstan.SelectedValue
            Part &= If(ChkCity.Checked = True, " AND IdCity=" & CmbCity.SelectedValue, "")
            Part &= If(CheckBox2.Checked = True, " AND IdPart=" & CmbPart.SelectedValue, "")
            Part2 = "AND ListFactorBackSell.IdName IN(" & Part & ")"
            Part = "AND ListFactorSell.IdName IN(" & Part & ")"
        End If

        Dim Group As String = ""
        If ChkGroup.Checked = True Then
            Group = " AND (ChkIdGroup ='True' And IdGroup =" & TxtIdGroup.Text & ")"
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

        Tmp_Namkala = CmbBox.Text
        Tmp_Mon = CmbBox.SelectedValue
        Me.Enabled = False

        If CheckBox1.Checked = False Then
            FrmPrint.PrintSQl = "SELECT  ListFactorSell.IdFactor, D_date, Define_People.Nam AS NamP, KolCount, JozCount,FeKol=Case WHEN JozCount <=0 THEN fe  ELSE ROUND(Mon/KolCount,0) END,FeJoz=Case WHEN JozCount >0 THEN Fe ELSE 0 END , Mon, Define_Kala.Nam AS Namkala, Define_OneGroup.NamOne+'-'+ Define_TwoGroup.NamTwo As GroupKala FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & ") " & Listpeople & Group & dat & Part & " ORDER BY D_date ,IdFactor ,NamP,GroupKala ,Namkala "
            FrmPrint.IdFactor = "SELECT ISNULL(SUM(Mon),0) AS Mon FROM  ListFactorBackSell  INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People .ID WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor =" & CmbBox.SelectedValue & ") " & Listpeople & Group & dat & Part2
            FrmPrint.CHoose = "FROSHVISIT1"
        Else
            If ChkDiscount.Checked = True Then
                FrmPrint.PrintSQl = "SELECT  GroupKala , Namkala,KolCount ,JozCount ,FeKol ,FeJoz ,Mon ,ROUND((Mon *100)/Case (SELECT  ISNULL(SUM(Mon),0) AS Mon FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) AND (KalaFactorSell.IdKala =ListKala2 .IdKala) " & dat & Part & " ) WHEN 0 THEN 1 ELSE (SELECT  ISNULL(SUM(Mon),0) AS Mon FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) AND (KalaFactorSell.IdKala =ListKala2 .IdKala)" & dat & Part & ") END,2) As Darsad FROM (SELECT idkala,Namkala ,GroupKala ,ROUND(SUM(KolCount),2) As KolCount ,ROUND(SUM(JozCount),2) AS JozCount ,ROUND(AVG(FeKol),0) As FeKol ,ROUND(AVG(FeJoz),0) As FeJoz ,ISNULL(SUM(Mon),0) As Mon FROM (SELECT  ListFactorSell.IdFactor,IdKala  , D_date, Define_People.Nam AS NamP, KolCount, JozCount,FeKol=Case WHEN JozCount <=0 THEN fe  ELSE ROUND(Mon/KolCount,0) END,FeJoz=Case WHEN JozCount >0 THEN Fe ELSE 0 END , Mon, Define_Kala.Nam AS Namkala, Define_OneGroup.NamOne+'-'+ Define_TwoGroup.NamTwo As GroupKala FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & ")" & Listpeople & Group & dat & Part & ") As ListKala GROUP BY Namkala,GroupKala,IdKala ) As ListKala2 ORDER BY KolCount,JozCount"
                FrmPrint.IdFactor = "SELECT ISNULL(SUM(Mon),0) AS Mon FROM  ListFactorBackSell  INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People .ID WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor =" & CmbBox.SelectedValue & ") " & Listpeople & Group & dat & Part2
                FrmPrint.Lend = "SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND DarsadMon >0) " & Listpeople & Group & dat & Part & " UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND Discount >0) " & Group & dat & Part & "  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & "  AND DarsadMon >0) " & Listpeople & Group & dat & Part2 & " UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID  WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & " AND Discount >0) " & Group & dat & Part2 & " ) AS AllDiscount"
                FrmPrint.Str2 = "SELECT ISNULL(SUM(KalaKasriFactor.Mon-KalaKasriFactor.DarsadMon),0) As Kasri FROM KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor INNER JOIN ListFactorSell ON ListKasriFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE IdVisitor =" & CmbBox.SelectedValue & Replace(Listpeople, "IDKala", "IDR") & Group & dat2 & Part
                FrmPrint.CHoose = "FROSHVISIT2"
            ElseIf CHKP.Checked = True Then
                FrmPrint.PrintSQl = "SELECT  Namp,GroupKala , Namkala,KolCount ,JozCount ,FeKol ,FeJoz ,Mon ,ROUND((Mon *100)/Case (SELECT  ISNULL(SUM(Mon),0) AS Mon FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) AND (KalaFactorSell.IdKala =ListKala2 .IdKala) " & dat & Part & " ) WHEN 0 THEN 1 ELSE (SELECT  ISNULL(SUM(Mon),0) AS Mon FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1) AND (KalaFactorSell.IdKala =ListKala2 .IdKala)" & dat & Part & ") END,2) As Darsad FROM (SELECT NamP,idkala,Namkala ,GroupKala ,ROUND(SUM(KolCount),2) As KolCount ,ROUND(SUM(JozCount),2) AS JozCount ,ROUND(AVG(FeKol),0) As FeKol ,ROUND(AVG(FeJoz),0) As FeJoz ,ISNULL(SUM(Mon),0) As Mon FROM (SELECT  ListFactorSell.IdFactor,IdKala  , D_date, Define_People.Nam AS NamP, KolCount, JozCount,FeKol=Case WHEN JozCount <=0 THEN fe  ELSE ROUND(Mon/KolCount,0) END,FeJoz=Case WHEN JozCount >0 THEN Fe ELSE 0 END , Mon, Define_Kala.Nam AS Namkala, Define_OneGroup.NamOne+'-'+ Define_TwoGroup.NamTwo As GroupKala FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & ")" & Listpeople & Group & dat & Part & ") As ListKala GROUP BY NamP,Namkala,GroupKala,IdKala ) As ListKala2 ORDER BY KolCount,JozCount"
                FrmPrint.IdFactor = "SELECT ISNULL(SUM(Mon),0) AS Mon FROM  ListFactorBackSell  INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People .ID WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor =" & CmbBox.SelectedValue & ") " & Listpeople & Group & dat & Part2
                FrmPrint.Lend = "SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND DarsadMon >0) " & Listpeople & Group & dat & Part & " UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND Discount >0) " & Group & dat & Part & "  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & "  AND DarsadMon >0) " & Listpeople & Group & dat & Part2 & " UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID  WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & " AND Discount >0) " & Group & dat & Part2 & " ) AS AllDiscount"
                FrmPrint.Str2 = "SELECT ISNULL(SUM(KalaKasriFactor.Mon-KalaKasriFactor.DarsadMon),0) As Kasri FROM KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor INNER JOIN ListFactorSell ON ListKasriFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE IdVisitor =" & CmbBox.SelectedValue & Replace(Listpeople, "IDKala", "IDR") & Group & dat2 & Part
                FrmPrint.CHoose = "FROSHVISIT3"
            ElseIf CHKPG.Checked = True Then
                FrmPrint.PrintSQl = "SELECT  Namp,GroupKala ,KolCount ,JozCount ,Mon  FROM (SELECT NamP,GroupKala ,ROUND(SUM(KolCount),2) As KolCount ,ROUND(SUM(JozCount),2) AS JozCount ,ISNULL(SUM(Mon),0) As Mon FROM (SELECT  ListFactorSell.IdFactor,IdKala  , D_date, Define_People.Nam AS NamP, KolCount, JozCount , Mon, Define_Kala.Nam AS Namkala, Define_OneGroup.NamOne+'-'+ Define_TwoGroup.NamTwo As GroupKala FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & ")" & Listpeople & Group & dat & Part & ") As ListKala GROUP BY NamP,GroupKala) As ListKala2 ORDER BY KolCount,JozCount"
                FrmPrint.IdFactor = "SELECT ISNULL(SUM(Mon),0) AS Mon FROM  ListFactorBackSell  INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People .ID WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor =" & CmbBox.SelectedValue & ") " & Listpeople & Group & dat & Part2
                FrmPrint.Lend = "SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND DarsadMon >0) " & Listpeople & Group & dat & Part & " UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND Discount >0) " & Group & dat & Part & "  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & "  AND DarsadMon >0) " & Listpeople & Group & dat & Part2 & " UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID  WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & " AND Discount >0) " & Group & dat & Part2 & " ) AS AllDiscount"
                FrmPrint.Str2 = "SELECT ISNULL(SUM(KalaKasriFactor.Mon-KalaKasriFactor.DarsadMon),0) As Kasri FROM KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor INNER JOIN ListFactorSell ON ListKasriFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE IdVisitor =" & CmbBox.SelectedValue & Replace(Listpeople, "IDKala", "IDR") & Group & dat2 & Part
                FrmPrint.CHoose = "FROSHVISIT4"
            ElseIf ChkG.Checked = True Then
                FrmPrint.PrintSQl = "SELECT  GroupKala ,KolCount ,JozCount ,Mon  FROM (SELECT GroupKala ,ROUND(SUM(KolCount),2) As KolCount ,ROUND(SUM(JozCount),2) AS JozCount ,ISNULL(SUM(Mon),0) As Mon FROM (SELECT  ListFactorSell.IdFactor,IdKala , D_date, KolCount, JozCount , Mon, Define_Kala.Nam AS Namkala, Define_OneGroup.NamOne+'-'+ Define_TwoGroup.NamTwo As GroupKala FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_People ON ListFactorSell .IdName =Define_People .ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne WHERE (ListFactorSell.Stat =3 and ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & ")" & Listpeople & Group & dat & Part & ") As ListKala GROUP BY GroupKala) As ListKala2 ORDER BY KolCount,JozCount"
                FrmPrint.IdFactor = "SELECT ISNULL(SUM(Mon),0) AS Mon FROM  ListFactorBackSell  INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People .ID WHERE (ListFactorBackSell.Activ =1 AND ListFactorBackSell.IdVisitor =" & CmbBox.SelectedValue & ") " & Listpeople & Group & dat & Part2
                FrmPrint.Lend = "SELECT ISNULL(SUM(Darsad),0) As Darsad FROM (SELECT ISNULL(SUM(DarsadMon),0) As Darsad FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND DarsadMon >0) " & Listpeople & Group & dat & Part & " UNION ALL SELECT ISNULL(SUM(Discount),0) As Darsad FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName =Define_People.ID WHERE (ListFactorSell.Activ =1 AND ListFactorSell.IdVisitor =" & CmbBox.SelectedValue & " And ListFactorSell.Stat =3 AND Discount >0) " & Group & dat & Part & "  UNION ALL SELECT ISNULL(SUM(DarsadMon)* -1,0) As Darsad FROM KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell .IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & "  AND DarsadMon >0) " & Listpeople & Group & dat & Part2 & " UNION ALL SELECT ISNULL(SUM(Discount) * -1,0) As Darsad FROM  ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName =Define_People.ID  WHERE (ListFactorBackSell .Activ =1 AND ListFactorBackSell .IdVisitor =" & CmbBox.SelectedValue & " AND Discount >0) " & Group & dat & Part2 & " ) AS AllDiscount"
                FrmPrint.Str2 = "SELECT ISNULL(SUM(KalaKasriFactor.Mon-KalaKasriFactor.DarsadMon),0) As Kasri FROM KalaKasriFactor INNER JOIN ListKasriFactor ON KalaKasriFactor.IdFactor = ListKasriFactor.IdFactor INNER JOIN ListFactorSell ON ListKasriFactor.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName =Define_People .ID WHERE IdVisitor =" & CmbBox.SelectedValue & Replace(Listpeople, "IDKala", "IDR") & Group & dat2 & Part
                FrmPrint.CHoose = "FROSHVISIT5"
            End If
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "فروش ویزیتور", "تهیه گزارش", "گزارش فروش ویزیتور:" & CmbBox.Text, "")

        FrmPrint.ShowDialog()
        Me.Enabled = True
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
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_Seller.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSearch.Enabled = True Then Call BtnSearch_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetKala()
            Me.GetVisitorList()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        If DGV.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV.RowCount - 1
            DGV.Item("Cln_Select", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

    Private Sub CmbBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbBox.KeyDown
        If CmbBox.DroppedDown = False Then
            CmbBox.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            BtnOk.Focus()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ChkDiscount.Enabled = True
            ChkDiscount.Checked = True
            CHKP.Enabled = True
            CHKPG.Enabled = True
            ChkG.Enabled = True
        Else
            ChkDiscount.Enabled = False
            ChkDiscount.Checked = False
            CHKP.Checked = False
            CHKP.Enabled = False
            CHKPG.Enabled = False
            CHKPG.Checked = False
            ChkG.Enabled = False
            ChkG.Checked = False
        End If
    End Sub

    Private Sub ChkPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPart.CheckedChanged
        If ChkPart.Checked = True Then
            CmbOstan.Enabled = True
            CmbCity.Enabled = True
            CmbPart.Enabled = True
            Me.Get_Ostan()
            CmbOstan_SelectedIndexChanged(Nothing, Nothing)
            CmbCity_SelectedIndexChanged(Nothing, Nothing)
            CmbOstan.Focus()
        Else
            CmbOstan.Enabled = False
            CmbCity.Enabled = False
            CmbPart.Enabled = False
            CmbOstan.DataSource = Nothing
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
        End If
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
    Private Sub Get_Part(ByVal IdOstan As Long, ByVal IdCity As Long)
        Try
            Dim Ds_P As New DataTable
            Dim Dta_P As New SqlDataAdapter
            If Not Dta_P Is Nothing Then Dta_P.Dispose()
            Dta_P = New SqlDataAdapter("SELECT Code,NamP FROM Define_Part WHERE IdOstan=" & IdOstan & " AND IdCity=" & IdCity, DataSource)
            Dta_P.Fill(Ds_P)
            CmbPart.DataSource = Ds_P
            CmbPart.DisplayMember = "NamP"
            CmbPart.ValueMember = "Code"
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "Get_Part")
            Me.Close()
        End Try
    End Sub

    Private Sub CmbOstan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOstan.KeyDown
        If CmbOstan.DroppedDown = False Then
            CmbOstan.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbCity.Focus()
        End If
    End Sub

    Private Sub CmbOstan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOstan.SelectedIndexChanged
        Try
            CmbCity.DataSource = Nothing
            CmbPart.DataSource = Nothing
            Me.Get_City(CmbOstan.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCity.KeyDown
        If CmbCity.DroppedDown = False Then
            CmbCity.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            CmbPart.Focus()
        End If
    End Sub

    Private Sub CmbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCity.SelectedIndexChanged
        Try
            CmbPart.DataSource = Nothing
            Me.Get_Part(CmbOstan.SelectedValue, CmbCity.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then BtnOk.Focus()
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

    Private Sub ChkCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCity.CheckedChanged
        If ChkCity.Checked = True Then
            CheckBox2.Enabled = True
        Else
            CheckBox2.Checked = False
            CheckBox2.Enabled = False
        End If
    End Sub

    Private Sub Chkvisit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkvisit.CheckedChanged
        GetVisitorList()
    End Sub
End Class