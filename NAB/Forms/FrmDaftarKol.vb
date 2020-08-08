Imports System.Data.SqlClient
Public Class FrmDaftarKol

    Private Sub ChKMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChKMon.CheckedChanged
        If ChKMon.Checked = True Then
            ChkAzMon.Enabled = True
            ChkTaMon.Enabled = True
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
            ChkAzMon.Checked = True
            ChkTaMon.Checked = True
            TxtMon1.Focus()
        Else
            ChkAzMon.Checked = False
            ChkTaMon.Checked = False
            ChkAzMon.Enabled = False
            ChkTaMon.Enabled = False
            TxtMon1.Enabled = False
            TxtMon2.Enabled = False
            TxtMon1.Text = "0"
            TxtMon2.Text = "0"
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
        If e.KeyCode = Keys.Enter Then TxtMon2.Focus()
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

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If Chkbuyer.Checked = False And Chkseller.Checked = False And Chkother.Checked = False Then
                MessageBox.Show("جهت تهیه گزارش باید حداقل یکی از گزینه های 'نوع طرف حساب'را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Chkbuyer.Checked = True
                Exit Sub
            End If

            If ChKMon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    If (CDbl(TxtMon1.Text) > CDbl(TxtMon2.Text)) Then
                        MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If (CDbl(TxtMon1.Text) = 0 And CDbl(TxtMon2.Text) = 0) Then
                    MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If ChkId.Checked = True Then
                If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                    If (CDbl(TxtId1.Text) > CDbl(TxtId2.Text)) Then
                        MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                If (CDbl(TxtId1.Text) = 0 And CDbl(TxtId2.Text) = 0) Then
                    MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If Chkbed.Checked = False And ChkBes.Checked = False And Chkbe.Checked = False Then
                MessageBox.Show("جهت تهیه گزارش باید حداقل یکی از گزینه های 'ماهیت طرف حساب'را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Chkbed.Checked = True
                Exit Sub
            End If

            If ChkUser.Checked = True Then
                If String.IsNullOrEmpty(TxtUser.Text) Or String.IsNullOrEmpty(TxtIdUser.Text) Then
                    MessageBox.Show("کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtUser.Focus()
                    Exit Sub
                End If
            End If

            If ChkVisitor.Checked = True Then
                If String.IsNullOrEmpty(TxtVisitor.Text) Or String.IsNullOrEmpty(TxtIdVisitor.Text) Then
                    MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtVisitor.Focus()
                    Exit Sub
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
                If ChkP.Checked = True Then
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

            If ChkTime.Checked = True Then
                If String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                    MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Me.Enabled = False

            Dim Sort As String = "ORDER BY " & If(Rdopay.Checked = True, "Mandeh", "Nam")
            If Rdopay.Checked = True Then
                Sort = "ORDER BY Mandeh"
            ElseIf Rdoname.Checked = True Then
                Sort = "ORDER BY Nam"
            ElseIf RdoCode.Checked = True Then
                Sort = "ORDER BY Id"
            End If

            Dim Id As String = ""
            If ChkId.Checked = True Then
                If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                    Id = "( Id >=" & CDbl(TxtId1.Text) & " AND Id <=" & CDbl(TxtId2.Text) & ")"
                ElseIf ChkAzId.Checked = True And ChkTaId.Checked = False Then
                    Id = "( Id >=" & CDbl(TxtId1.Text) & ")"
                ElseIf ChkAzId.Checked = False And ChkTaId.Checked = True Then
                    Id = "( Id <=" & CDbl(TxtId2.Text) & ")"
                End If
            End If

            Dim Part As String = ""
            If ChkPart.Checked = True Then
                Part = "IdOstan=" & CmbOstan.SelectedValue
                Part &= If(ChkCity.Checked = True, " AND IdCity=" & CmbCity.SelectedValue, "")
                Part &= If(ChkP.Checked = True, " AND IdPart=" & CmbPart.SelectedValue, "")
                'Part = "(" & Part & ")"
                Part = "(" & Part & ")" & If(String.IsNullOrEmpty(Id), "", " AND ")
            End If

            Dim Mon As String = ""
            If ChKMon.Checked = True Then
                If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                    Mon = "( Mandeh >=" & CDbl(TxtMon1.Text) & " AND Mandeh <=" & CDbl(TxtMon2.Text) & ")"
                ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                    Mon = "( Mandeh >=" & CDbl(TxtMon1.Text) & ")"
                ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                    Mon = "( Mandeh <=" & CDbl(TxtMon2.Text) & ")"
                End If
                Mon = Mon & If(String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ")
            End If

            Dim Kind As String = ""
            If Not (Chkbed.Checked = True And ChkBes.Checked = True And Chkbe.Checked = True) Then
                Kind = If(ChkBes.Checked = True, "(Mandeh>0 AND T=N'بس')", "")
                Kind &= If(Chkbed.Checked = True, If(ChkBes.Checked = True, " OR (Mandeh>0 AND T=N'بد')", "  (Mandeh>0 AND T=N'بد')"), "")
                Kind &= If(Chkbe.Checked = True, If(ChkBes.Checked = True Or Chkbed.Checked = True, " OR (Mandeh=0)", " (Mandeh=0)"), "")
                Kind = "(" & Kind & ")" & If(String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ")
            End If

            Dim Type As String = ""
            If Not (Chkbuyer.Checked = True And Chkseller.Checked = True And Chkother.Checked = True) Then
                Type = If(Chkbuyer.Checked = True, "(Buyer='True'", "(Buyer='False'")
                Type &= If(Chkseller.Checked = True, " OR Seller='True'", " OR Seller='False'")
                Type &= If(Chkother.Checked = True, " AND Other='True')", " AND Other='False')")
                Type &= If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ")
            End If

            Dim Group As String = ""
            If ChkGroup.Checked = True Then
                Group = " (ChkIdGroup ='True' And IdGroup =" & TxtIdGroup.Text & ")"
                Group &= If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id) And String.IsNullOrEmpty(Type), "", " AND ")
            End If

            Dim User As String = ""
            If ChkUser.Checked = True Then
                User = " WHERE Define_People.ID IN(SELECT DISTINCT IDPeople FROM Moein_People WHERE IdUser =" & CLng(TxtIdUser.Text) & ")"
            End If

            Dim visitor As String = ""
            If ChkVisitor.Checked = True Then
                If ChkUser.Checked = False Then
                    visitor = " WHERE Define_People.ID IN(SELECT DISTINCT Idname FROM ListFactorSell WHERE Activ =1 AND IdVisitor IS NOT NULL AND IdVisitor IN (" & TxtIdVisitor.Text & "))"
                Else
                    visitor = " AND Define_People.ID IN(SELECT DISTINCT Idname FROM ListFactorSell WHERE Activ =1 AND IdVisitor IS NOT NULL AND IdVisitor IN(" & TxtIdVisitor.Text & "))"
                End If
            End If

            Dim dat As String = ""
            If ChkTime.Checked = True Then
                dat = " AND (D_date <=N'" & FarsiDate2.ThisText & "')"
            End If

            If ChkManual.Checked = False Then
                Using FrmPrint As New FrmPrint
                    If ChkOne.Checked = False Then
                        FrmPrint.PrintSQl = "If (SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User & ")=0 SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT   Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID " & dat & ")As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID " & dat & ")As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol " & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " WHERE ") & Group & Type & Kind & Mon & Part & Id & Sort & " else SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID " & dat & ")As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID " & dat & ")As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol WHERE " & Group & Type & Kind & Mon & Part & Id & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ") & " Id in (SELECT IDP  FROM Define_UserRP WHERE IdUser =" & Id_User & " )" & Sort
                        FrmPrint.Str1 = ""
                    Else
                        FrmPrint.PrintSQl = "If (SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User & ")=0 SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT   Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(0)As Bed,(0)As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol " & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " WHERE ") & Group & Type & Kind & Mon & Part & Id & Sort & " else SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(0)As Bed,(0)As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol WHERE " & Group & Type & Kind & Mon & Part & Id & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ") & " Id in (SELECT IDP  FROM Define_UserRP WHERE IdUser =" & Id_User & " )" & Sort
                        FrmPrint.Str1 = "فقط مبلغ اول دوره محاسبه شده است"
                    End If

                    If ChkGroup.Checked = True Then
                        FrmPrint.Str1 &= "    محدودیت گروه: " & TxtGroup.Text
                    End If

                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دفتر کل", "تهیه گزارش", "", "")
                    FrmPrint.CHoose = "DAFTARKOL"
                    FrmPrint.ShowDialog()
                End Using
            Else
                Using FrmM As New FrmDaftarKolManual
                    If ChkOne.Checked = False Then
                        FrmM.Sql = "If (SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User & ")=0 SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT   Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID " & dat & ")As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID " & dat & ")As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol " & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " WHERE ") & Group & Type & Kind & Mon & Part & Id & Sort & " else SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID " & dat & ")As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID " & dat & ")As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol WHERE " & Group & Type & Kind & Mon & Part & Id & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ") & " Id in (SELECT IDP  FROM Define_UserRP WHERE IdUser =" & Id_User & " )" & Sort
                    Else
                        FrmM.Sql = "If (SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User & ")=0 SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT   Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(0)As Bed,(0)As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol " & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " WHERE ") & Group & Type & Kind & Mon & Part & Id & Sort & " else SELECT Addres ,Id,Nam ,BedMon ,BesMon ,T ,Mandeh ,Fix ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Addres,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End, AllKol.Fix ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Fix,Alldata.Mobile ,Alldata.Addres,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam, ISNULL(Define_People.Tell1,'') AS Fix, ISNULL(Define_People.Tell2,'') As Mobile, Define_Ostan.NamO + ' - ' + Define_City.NamCI + ' - ' + Define_Part.NamP + ' - ' + ISNULL(Define_People.[Address],'') As Addres,(0)As Bed,(0)As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & visitor & ")As Alldata)As AllKol) AS DaftarKol WHERE " & Group & Type & Kind & Mon & Part & Id & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ") & " Id in (SELECT IDP  FROM Define_UserRP WHERE IdUser =" & Id_User & " )" & Sort
                    End If
                    TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دفتر کل", "تهیه گزارش", "", "")
                    FrmM.ShowDialog()
                End Using
            End If
            Me.Enabled = True

        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Rep_MoeinKol.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnSave.Enabled = True Then BtnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If BtnSendSMS.Enabled = True Then BtnSendSMS_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmDaftarKol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
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

    Private Sub CmbPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbPart.KeyDown
        If CmbPart.DroppedDown = False Then
            CmbPart.DroppedDown = True
        End If
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub ChkId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkId.CheckedChanged
        If ChkId.Checked = True Then
            ChkAzId.Enabled = True
            ChkTaId.Enabled = True
            TxtId1.Text = "0"
            TxtId2.Text = "0"
            ChkAzId.Checked = True
            ChkTaId.Checked = True
            TxtId1.Focus()
        Else
            ChkAzId.Checked = False
            ChkTaId.Checked = False
            ChkAzId.Enabled = False
            ChkTaId.Enabled = False
            TxtId1.Enabled = False
            TxtId2.Enabled = False
            TxtId1.Text = "0"
            TxtId2.Text = "0"
        End If
    End Sub

    Private Sub TxtId1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtId1.KeyDown
        If e.KeyCode = Keys.Enter Then TxtId2.Focus()
    End Sub

    Private Sub TxtId1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtId1.KeyPress
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

    Private Sub TxtId2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtId2.KeyPress
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

    Private Sub ChkAzId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAzId.CheckedChanged
        If ChkAzId.Checked = True Then
            TxtId1.Text = "0"
            TxtId1.Enabled = True
            TxtId1.Focus()
            TxtId1.SelectAll()
        Else
            TxtId1.Text = "0"
            TxtId1.Enabled = False
        End If
    End Sub

    Private Sub ChkTaId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaId.CheckedChanged
        If ChkTaId.Checked = True Then
            TxtId2.Text = "0"
            TxtId2.Enabled = True
            TxtId2.Focus()
            TxtId2.SelectAll()
        Else
            TxtId2.Text = "0"
            TxtId2.Enabled = False
        End If
    End Sub

    Private Sub FrmDaftarKol_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F83")
        If (Access_Form <> "-1") Then

            If String.IsNullOrEmpty(Access_Form) Then
                MessageBox.Show("حق دسترسی برای شما تعیین نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
            Else
                If Access_Form.Substring(0, 1) = 0 Or Access_Form.Substring(1, 1) = 0 Or Access_Form.Substring(2, 1) = 0 Then
                    MessageBox.Show("حق دسترسی به این بخش برای شما مسدود شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.Close()
                End If

                Try
                    If Access_Form.Substring(3, 1) = 0 Then
                        BtnSendSMS.Enabled = False
                    End If
                Catch ex As Exception
                    BtnSendSMS.Enabled = False
                End Try

            End If
        End If
        FarsiDate2.Enabled = False
        FarsiDate2.ThisText = GetDate()

        Me.UseRelation()
    End Sub

    Private Sub UseRelation()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User, ConectionBank)
                If cmd.ExecuteScalar() > 0 Then ChkUser.Enabled = False
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDaftarKol", "UseRelation")
        End Try
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
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
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

    Private Sub ChkCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCity.CheckedChanged
        If ChkCity.Checked = True Then
            ChkP.Enabled = True
        Else
            ChkP.Checked = False
            ChkP.Enabled = False
        End If
    End Sub

    Private Sub ChkOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOne.CheckedChanged
        If ChkOne.Checked = True Then
            BtnSendSMS.Enabled = False
            ChkTime.Checked = False
            ChkTime.Enabled = False
        Else
            BtnSendSMS.Enabled = True
            ChkTime.Enabled = True
        End If
    End Sub

    Private Sub BtnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendSMS.Click
        If SMS = False Then
            MessageBox.Show("غیر فعال شده است SMS سرویس ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Chkbuyer.Checked = False And Chkseller.Checked = False And Chkother.Checked = False Then
            MessageBox.Show("جهت تهیه گزارش باید حداقل یکی از گزینه های 'نوع طرف حساب'را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Chkbuyer.Checked = True
            Exit Sub
        End If

        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                If (CDbl(TxtMon1.Text) > CDbl(TxtMon2.Text)) Then
                    MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If (CDbl(TxtMon1.Text) = 0 And CDbl(TxtMon2.Text) = 0) Then
                MessageBox.Show("محدوده مبلغ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If ChkId.Checked = True Then
            If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                If (CDbl(TxtId1.Text) > CDbl(TxtId2.Text)) Then
                    MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If (CDbl(TxtId1.Text) = 0 And CDbl(TxtId2.Text) = 0) Then
                MessageBox.Show("محدوده کد اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If Chkbed.Checked = False And ChkBes.Checked = False And Chkbe.Checked = False Then
            MessageBox.Show("جهت تهیه گزارش باید حداقل یکی از گزینه های 'ماهیت طرف حساب'را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Chkbed.Checked = True
            Exit Sub
        End If

        If ChkUser.Checked = True Then
            If String.IsNullOrEmpty(TxtUser.Text) Or String.IsNullOrEmpty(TxtIdUser.Text) Then
                MessageBox.Show("کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtUser.Focus()
                Exit Sub
            End If
        End If

        If ChkVisitor.Checked = True Then
            If String.IsNullOrEmpty(TxtVisitor.Text) Or String.IsNullOrEmpty(TxtIdVisitor.Text) Then
                MessageBox.Show("ویزیتور را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtVisitor.Focus()
                Exit Sub
            End If
        End If

        If ChkTime.Checked = True Then
            If String.IsNullOrEmpty(FarsiDate2.ThisText) Then
                MessageBox.Show("تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
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
            If ChkP.Checked = True Then
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


        Dim Sort As String = "ORDER BY " & If(Rdopay.Checked = True, "Mandeh", "Nam")
        If Rdopay.Checked = True Then
            Sort = "ORDER BY Mandeh"
        ElseIf Rdoname.Checked = True Then
            Sort = "ORDER BY Nam"
        ElseIf RdoCode.Checked = True Then
            Sort = "ORDER BY Id"
        End If

        Dim Id As String = ""
        If ChkId.Checked = True Then
            If ChkAzId.Checked = True And ChkTaId.Checked = True Then
                Id = "( Id >=" & CDbl(TxtId1.Text) & " AND Id <=" & CDbl(TxtId2.Text) & ")"
            ElseIf ChkAzId.Checked = True And ChkTaId.Checked = False Then
                Id = "( Id >=" & CDbl(TxtId1.Text) & ")"
            ElseIf ChkAzId.Checked = False And ChkTaId.Checked = True Then
                Id = "( Id <=" & CDbl(TxtId2.Text) & ")"
            End If
        End If

        Dim Part As String = ""
        If ChkPart.Checked = True Then
            Part = "IdOstan=" & CmbOstan.SelectedValue
            Part &= If(ChkCity.Checked = True, " AND IdCity=" & CmbCity.SelectedValue, "")
            Part &= If(ChkP.Checked = True, " AND IdPart=" & CmbPart.SelectedValue, "")
            'Part = "(" & Part & ")"
            Part = "(" & Part & ")" & If(String.IsNullOrEmpty(Id), "", " AND ")
        End If

        Dim Mon As String = ""
        If ChKMon.Checked = True Then
            If ChkAzMon.Checked = True And ChkTaMon.Checked = True Then
                Mon = "( Mandeh >=" & CDbl(TxtMon1.Text) & " AND Mandeh <=" & CDbl(TxtMon2.Text) & ")"
            ElseIf ChkAzMon.Checked = True And ChkTaMon.Checked = False Then
                Mon = "( Mandeh >=" & CDbl(TxtMon1.Text) & ")"
            ElseIf ChkAzMon.Checked = False And ChkTaMon.Checked = True Then
                Mon = "( Mandeh <=" & CDbl(TxtMon2.Text) & ")"
            End If
            Mon = Mon & If(String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ")
        End If

        Dim Kind As String = ""
        If Not (Chkbed.Checked = True And ChkBes.Checked = True And Chkbe.Checked = True) Then
            Kind = If(ChkBes.Checked = True, "(Mandeh>0 AND T=N'بس')", "")
            Kind &= If(Chkbed.Checked = True, If(ChkBes.Checked = True, " OR (Mandeh>0 AND T=N'بد')", "  (Mandeh>0 AND T=N'بد')"), "")
            Kind &= If(Chkbe.Checked = True, If(ChkBes.Checked = True Or Chkbed.Checked = True, " OR (Mandeh=0)", " (Mandeh=0)"), "")
            Kind = "(" & Kind & ")" & If(String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ")
        End If

        Dim Type As String = ""
        If Not (Chkbuyer.Checked = True And Chkseller.Checked = True And Chkother.Checked = True) Then
            Type = If(Chkbuyer.Checked = True, "(Buyer='True'", "(Buyer='False'")
            Type &= If(Chkseller.Checked = True, " AND Seller='True'", " AND Seller='False'")
            Type &= If(Chkother.Checked = True, " AND Other='True')", " AND Other='False')")
            Type &= If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ")
        End If

        Dim Group As String = ""
        If ChkGroup.Checked = True Then
            Group = " (ChkIdGroup ='True' And IdGroup =" & TxtIdGroup.Text & ")"
            Group &= If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id) And String.IsNullOrEmpty(Type), "", " AND ")
        End If

        Dim User As String = ""
        If ChkUser.Checked = True Then
            User = " WHERE Define_People.ID IN(SELECT DISTINCT IDPeople FROM Moein_People WHERE IdUser =" & CLng(TxtIdUser.Text) & ")"
        End If

        TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "دفتر کل", "SMS ارسال", "", "")
        Using Frms As New SendAllSMS
            Frms.Query = "If (SELECT COUNT(IdUser) FROM Define_UserR WHERE IdUser =" & Id_User & ")=0 SELECT Nam, T ,Mandeh ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End ,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Mobile ,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT   Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam,ISNULL(Define_People.Tell2,'') As Mobile,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & ")As Alldata)As AllKol) AS DaftarKol " & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " WHERE ") & Group & Type & Kind & Mon & Part & Id & Sort & " else SELECT Nam ,T ,Mandeh ,Mobile  FROM (SELECT AllKol.ChkIdGroup ,AllKol.IdGroup,AllKol.IdOstan ,AllKol.IdCity ,AllKol.IdPart,AllKol.Buyer ,AllKol.Seller ,AllKol.Other  ,AllKol.id,AllKol.Nam,AllKol.BedMon ,AllKol.BesMon,T=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN N'بد' WHEN  (AllKol.bedMon-AllKol.BesMon)< 0 THEN N'بس' Else  N'نا' End,Mandeh=Case WHEN (AllKol.bedMon-AllKol.BesMon)>=0 THEN (AllKol.bedMon-AllKol.BesMon) WHEN (AllKol.bedMon-AllKol.BesMon)<0 THEN (AllKol.bedMon-AllKol.BesMon)*(-1) Else 0 End,AllKol.Mobile FROM(SELECT  Alldata.ChkIdGroup ,Alldata.IdGroup,Alldata.IdOstan ,Alldata.IdCity ,Alldata.IdPart,Alldata.Buyer ,Alldata.Seller ,Alldata.Other ,Alldata.ID,Alldata.Nam ,Alldata.Mobile ,BedMon=Case Alldata.[state]  WHEN N'بدهکار' THEN Allmoney +Alldata.Bed Else  Alldata.Bed End ,BesMon=Case Alldata.[state]  WHEN N'بستانکار' THEN Allmoney +Alldata.Bes Else  Alldata.Bes End FROM (SELECT  Define_People.ChkIdGroup ,Define_People.IdGroup,Define_People.IdOstan,Define_People.IdCity ,Define_People.IdPart,Define_People.Buyer ,Define_People.Seller ,Define_People.Other ,Define_People.ID, Define_People.Nam,ISNULL(Define_People.Tell2,'') As Mobile,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=0 AND IDPeople =Define_People .ID )As Bed,(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE  T=1 AND IDPeople =Define_People .ID )As Bes,AllMoney ,[State]  FROM  Define_People INNER JOIN  Define_Ostan ON Define_People.IdOstan = Define_Ostan.Code INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code AND Define_Ostan.Code = Define_City.IdOstan INNER JOIN Define_Part ON Define_People.IdPart = Define_Part.Code AND Define_Ostan.Code = Define_Part.IdOstan AND Define_City.Code = Define_Part.IdCity " & User & ")As Alldata)As AllKol) AS DaftarKol WHERE " & Group & Type & Kind & Mon & Part & Id & If(String.IsNullOrEmpty(Kind) And String.IsNullOrEmpty(Group) And String.IsNullOrEmpty(Type) And String.IsNullOrEmpty(Mon) And String.IsNullOrEmpty(Part) And String.IsNullOrEmpty(Id), "", " AND ") & " Id in (SELECT IDP  FROM Define_UserRP WHERE IdUser =" & Id_User & " )" & Sort
            Frms.ShowDialog()
        End Using
    End Sub

    Private Sub ChkUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkUser.CheckedChanged
        If ChkUser.Checked = True Then
            TxtUser.Enabled = True
            TxtUser.Focus()
        Else
            TxtUser.Enabled = False
            TxtUser.Text = ""
            TxtIdUser.Text = ""
        End If
    End Sub

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New User_List
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtUser.Focus()
        If Tmp_Namkala <> "" Then
            TxtUser.Text = Tmp_Namkala
            TxtIdUser.Text = IdKala
        End If
    End Sub

    Private Sub ChkVisitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVisitor.CheckedChanged
        If ChkVisitor.Checked = True Then
            TxtVisitor.Enabled = True
            TxtVisitor.Focus()
        Else
            TxtVisitor.Enabled = False
            TxtVisitor.Text = ""
            TxtIdVisitor.Text = ""
        End If
    End Sub

    Private Sub TxtVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then BtnSave.Focus()
    End Sub

    Private Sub TxtVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVisitor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        Dim frmlk As New Visitor_List
        frmlk.ChkAll.Visible = True
        frmlk.DGV.Columns("Cln_select").Visible = True
        frmlk.TxtSearch.Text = e.KeyChar()
        frmlk.BtnNewP.Enabled = True
        frmlk.ShowDialog()
        e.Handled = True
        TxtVisitor.Focus()
        Try
            If AllSelectKala.Length > 0 Then
                Dim Id As String = ""
                Dim Nam As String = ""
                For j As Integer = 0 To AllSelectKala.Length - 1
                    Nam &= AllSelectKala(j).Namekala & If(j = AllSelectKala.Length - 1, "", ",")
                    Id &= AllSelectKala(j).IdKala & If(j = AllSelectKala.Length - 1, "", ",")
                Next
                TxtVisitor.Text = Nam
                TxtIdVisitor.Text = Id
                Array.Resize(AllSelectKala, 0)
            Else
                TxtVisitor.Text = ""
                TxtIdVisitor.Text = ""
            End If
        Catch ex As Exception
            Array.Resize(AllSelectKala, 0)
        End Try
    End Sub

    Private Sub ChkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTime.CheckedChanged
        If ChkTime.Checked = True Then
            FarsiDate2.Enabled = True
            FarsiDate2.ThisText = GetDate()
        Else
            FarsiDate2.Enabled = False
        End If
    End Sub

    Private Sub ChkManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkManual.CheckedChanged
        If ChkOne.Checked = True Then
            BtnSendSMS.Enabled = False
        Else
            BtnSendSMS.Enabled = True
        End If
    End Sub

End Class