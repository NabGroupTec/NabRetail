Imports System.Data.SqlClient
Public Class FrmValue

    Private Sub FrmValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub
    Private Sub CalCulate()
        Try
            Me.MonValue(CLng(LCode.Text))
            Me.RasGetChk(CLng(LCode.Text))
            Me.RasPayChk(CLng(LCode.Text))
            Me.RasDelay(CLng(LCode.Text))

            If Chkv.Checked = False Then
                LEndValue.Text = "بدون محدودیت"
            Else
                Dim Tmp As Double = 0
                If discmoein.Text = "بدهکار" Then
                    Tmp = (CDbl(LMoein.Text) + CDbl(LGetChk.Text)) - CDbl(LPayChk.Text)
                    LEndValue.Text = CDbl(LValue.Text) - Tmp
                ElseIf discmoein.Text = "بستانکار" Then
                    Tmp = (CDbl(LMoein.Text) + CDbl(LPayChk.Text)) - CDbl(LGetChk.Text)
                    LEndValue.Text = CDbl(LValue.Text) + Tmp
                End If
                If CDbl(LEndValue.Text.Trim) = 0 Then
                    LEndValue.BackColor = Color.Yellow
                ElseIf CDbl(LEndValue.Text.Trim) > 0 Then
                    LEndValue.BackColor = Color.White
                ElseIf CDbl(LEndValue.Text.Trim) < 0 Then
                    LEndValue.BackColor = Color.Pink
                End If
                If LEndValue.Text.Length > 3 Then
                    Dim str As String
                    str = Format$(LEndValue.Text.Replace(",", ""))
                    LEndValue.Text = Format$(Val(str), "###,###,###")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmValue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Me.CalCulate()
    End Sub
    Private Sub MonValue(ByVal Id As Long)
        Try
            Dim str As String = "SELECT GChk.GetChk,PChk.PayChk,People .Moein,Rate.GValue ,Rate .GValueMon ,C_Count,DelayChk,MoneyChk,(People.BED + CASE WHEN People.OnMoney>0 THEN People.OnMoney ELSE 0 END) AS AllBed FROM (SELECT  ISNULL(SUM(MoneyChk),0) As GetChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0 and (Current_State =0 or Current_State =4)  AND (Current_IdPeople =" & Id & " OR IdPeople =" & Id & ")) As GChk,(SELECT  ISNULL(SUM(MoneyChk),0) As PayChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =1 and (Current_State =0 )  AND Current_IdPeople =" & Id & ") As PChk,(SELECT ISNULL(SUM(OnMoney+bed+bes),0) AS Moein,ISNULL(SUM(Bed),0) AS Bed ,ISNULL(SUM(OnMoney),0) As OnMoney FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One)AS People,(SELECT Gvalue,GvalueMon From Define_People WHERE ID=" & Id & ")As Rate,(SELECT COUNT(*) As C_Count,ISNULL(SUM(DelayChk),0) As DelayChk,ISNULL(SUM(MoneyChk ),0) As MoneyChk  FROM (SELECT  DISTINCT IdChk ,DelayChk,MoneyChk  FROM Sanad_ChangeChk,Chk_Get_Pay WHERE  DelayChk >0 AND  IdChk IN (SELECT  Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Kind =0 and Chk_Get_Pay.Activ =1 AND Idpeople=" & Id & " AND Current_State =1) AND Chk_Get_Pay.ID =IdChk) As ListChk) AS AllListChk"
            Dim Dtr As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(str, ConectionBank)
                Dtr = cmd.ExecuteReader
                If Dtr.HasRows Then
                    Dtr.Read()
                    LGetChk.Text = Dtr("GetChk")
                    discGetChk.Text = "بدهکار"
                    LPayChk.Text = Dtr("PayChk")
                    discpayChk.Text = "بستانکار"
                    LValue.Text = Dtr("GValueMon")
                    Chkv.Checked = CBool(Dtr("GValue"))
                    LMoein.Text = If(Dtr("Moein") < 0, Dtr("Moein") * (-1), Dtr("Moein"))
                    discmoein.Text = If(Dtr("Moein") < 0, "بستانکار", "بدهکار")
                    LSumDelay.Text = Dtr("MoneyChk")
                    LTimeDelay.Text = Dtr("DelayChk")
                    LCountDelay.Text = Dtr("C_Count")
                    If (Dtr("AllBed")) = 0 Then
                        LRisk.Text = "0"
                    Else
                        Dim value As Double = Math.Round(((Dtr("Moein") + Dtr("GetChk") + (Dtr("PayChk") * -1)) * 100) / Dtr("AllBed"), 2) * (-1)
                        LRisk.Text = Replace(value, ".", "/")
                    End If
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If ChkFroshChk.Checked = True Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Dim dt As New DataTable
                Using cmd As New SqlCommand("SELECT Chk_State.Id,MAX(D_Date) As D_date,MAX(Chk_Get_Pay.PayDate) As PayDate,MAX(Chk_Get_Pay.MoneyChk) As MoneyChk,Rate=0 FROM Chk_State INNER JOIN Chk_Get_Pay ON Chk_Get_Pay.ID =Chk_State.Id WHERE Chk_State.Current_State =1 AND Chk_State.Id IN (SELECT  Chk_Get_Pay.ID FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0 AND Current_Kind =1 And Current_State =1  AND (Current_IdPeople =" & Id & " OR IdPeople =" & Id & ")) AND D_Date >PayDate GROUP By Chk_State.Id", ConectionBank)
                    dt.Load(cmd.ExecuteReader)
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                If dt.Rows.Count > 0 Then
                    Dim mon As Double = 0
                    Dim rate As Double = 0
                    dt.Columns("Rate").ReadOnly = False
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dt.Rows(i).Item("Rate") = SUBDAY(dt.Rows(i).Item("D_date"), dt.Rows(i).Item("PayDate"))
                    Next
                    Dim dv As DataView = dt.DefaultView
                    dv.RowFilter = "rate>=" & Num.Value
                    If dv.Count > 0 Then
                        For i As Integer = 0 To dv.Count - 1
                            mon += dv.Item(i).Item("MoneyChk")
                            rate += dv.Item(i).Item("Rate")
                        Next
                        LSumDelay.Text = CLng(LSumDelay.Text) + mon
                        LTimeDelay.Text = CLng(LTimeDelay.Text) + rate
                        LCountDelay.Text = CLng(LCountDelay.Text) + dv.Count
                    End If

                End If
            End If

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmValue", "MonValue")
        End Try
    End Sub

    Private Sub RasGetChk(ByVal Id As Long)
        Try
            Array.Resize(ListRasChk, 0)
            Dim str As String = ""
            If Chk0.Checked = False Then
                str = "SELECT  [GetDate] ,PayDate , MoneyChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0  AND (Current_IdPeople =" & Id & " OR IdPeople =" & Id & ")"
            Else
                str = "SELECT  [GetDate] ,PayDate , MoneyChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0  AND (Current_State =0 or Current_State =4)  AND (Current_IdPeople =" & Id & " OR IdPeople =" & Id & ")"
            End If

            Dim Dtr As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(str, ConectionBank)
                Dtr = cmd.ExecuteReader
                If Dtr.HasRows Then
                    While Dtr.Read()
                        Array.Resize(ListRasChk, ListRasChk.Length + 1)
                        ListRasChk(ListRasChk.Length - 1).MonChk = Dtr("MoneyChk")
                        ListRasChk(ListRasChk.Length - 1).SumChk = Dtr("MoneyChk") * If(SUBDAY(Dtr("PayDate"), Dtr("GetDate")) = 0, 1, SUBDAY(Dtr("PayDate"), Dtr("GetDate")))
                    End While

                    Dim MonChk As Double = 0
                    Dim AllMonChk As Double = 0
                    For i As Integer = 0 To ListRasChk.Length - 1
                        MonChk += ListRasChk(i).MonChk
                        AllMonChk += ListRasChk(i).SumChk
                    Next
                    C_GetChk.Text = ListRasChk.Length
                    RasGetMon.Text = IIf(MonChk = 0, 0, FormatNumber(MonChk, 0))
                    RasGetDay.Text = Replace(Format$(AllMonChk / MonChk, "###.##"), ".", "/")
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmValue", "RasGetChk")
        End Try
    End Sub

    Private Sub RasPayChk(ByVal Id As Long)
        Try
            Array.Resize(ListRasChk, 0)
            Dim str As String = ""
            If Chk0.Checked = False Then
                str = "SELECT  [GetDate] ,PayDate , MoneyChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =1  AND Current_IdPeople =" & Id
            Else
                str = "SELECT  [GetDate] ,PayDate , MoneyChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =1  AND (Current_State =0 )  AND Current_IdPeople =" & Id
            End If

            Dim Dtr As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(str, ConectionBank)
                Dtr = cmd.ExecuteReader
                If Dtr.HasRows Then
                    While Dtr.Read()
                        Array.Resize(ListRasChk, ListRasChk.Length + 1)
                        ListRasChk(ListRasChk.Length - 1).MonChk = Dtr("MoneyChk")
                        ListRasChk(ListRasChk.Length - 1).SumChk = Dtr("MoneyChk") * If(SUBDAY(Dtr("PayDate"), Dtr("GetDate")) = 0, 1, SUBDAY(Dtr("PayDate"), Dtr("GetDate")))
                    End While

                    Dim MonChk As Double = 0
                    Dim AllMonChk As Double = 0
                    For i As Integer = 0 To ListRasChk.Length - 1
                        MonChk += ListRasChk(i).MonChk
                        AllMonChk += ListRasChk(i).SumChk
                    Next
                    C_PayChk.Text = ListRasChk.Length
                    RasPayMon.Text = IIf(MonChk = 0, 0, FormatNumber(MonChk, 0))
                    RasPayDay.Text = Replace(Format$(AllMonChk / MonChk, "###.##"), ".", "/")
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmValue", "RasPayChk")
        End Try
    End Sub

    Private Function CalDate(ByVal Dat As String, ByVal Count As Long, ByVal NewDat As String) As String
        Try
            For i As Integer = 1 To Count
                Dat = ADDDAY(Dat)
            Next
            If String.IsNullOrEmpty(NewDat) Then
                Return Dat
            Else
                If Dat >= NewDat Then
                    Return Dat
                Else
                    Return NewDat
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub RasDelay(ByVal Id As Long)
        Try
            Dim FacLast As Long = 0
            Dim FacNext As Long = 0
            Dim FacMonLast As Double = 0
            Dim FacMonNext As Double = 0
            Dim SumMon As Double = 0
            Dim FacDelay As Long = 0
            Dim RasDelay As Long = 0
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim str As String = "SELECT IdFactor,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec)-(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor ,Wanted_Frosh.Rate,d_date,IdName FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.IdName =" & Id & ") As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName"
            Dim Dt As New DataTable
            Dt.Clear()
            Dt.Columns.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(str, ConectionBank)
                Dt.Load(cmd.ExecuteReader)
                If Dt.Rows.Count > 0 Then
                    If Not Dt.Columns.Contains("EndDate") Then Dt.Columns.Add("EndDate", Type.GetType("System.String"))
                    If Not Dt.Columns.Contains("TimeRemain") Then Dt.Columns.Add("TimeRemain", Type.GetType("System.Int32"))
                    For i As Integer = 0 To Dt.Rows.Count - 1
                        Dt.Rows(i).Item("EndDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                        Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("EndDate"), Dt.Rows(i).Item("D_date"))
                        If Dt.Rows(i).Item("Remain") <= 0 Then
                            Dim tDt As New DataTable
                            tDt.Clear()
                            tDt.Columns.Clear()
                            Using cmdT As New SqlCommand("SELECT TOP 1 D_Date FROM (SELECT D_date FROM Get_Pay_Sanad WHERE Id IN(SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =" & Dt.Rows(i).Item("IdFactor") & ") UNION SELECT D_date FROM ListFactorBackSell WHERE IdFacSell =" & Dt.Rows(i).Item("IdFactor") & " UNION SELECT D_date FROM ListKasriFactor WHERE IdFactor =" & Dt.Rows(i).Item("IdFactor") & ") As ListDat ORDER By D_date DESC", ConectionBank)
                                tDt.Load(cmdT.ExecuteReader)
                            End Using
                            If tDt.Rows.Count <= 0 Then
                                Dt.Rows(i).Item("TimeRemain") = 0
                            Else
                                Dt.Rows(i).Item("TimeRemain") = SUBDAY(Dt.Rows(i).Item("EndDate"), tDt.Rows(0).Item("D_Date"))
                            End If
                        Else
                            Dt.Rows(i).Item("TimeRemain") = SUBDAY(Dt.Rows(i).Item("EndDate"), GetDate())
                        End If
                        '''''''''''''''''''''''''''
                        If Dt.Rows(i).Item("TimeRemain") > 0 And Dt.Rows(i).Item("Remain") > 0 Then
                            FacNext += 1
                            FacMonNext += Dt.Rows(i).Item("Remain")
                            SumMon += Dt.Rows(i).Item("Remain") * Dt.Rows(i).Item("TimeRemain")
                        ElseIf Dt.Rows(i).Item("TimeRemain") <= 0 And Dt.Rows(i).Item("Remain") > 0 Then
                            FacLast += 1
                            FacMonLast += Dt.Rows(i).Item("Remain")
                            SumMon += Dt.Rows(i).Item("Remain") * Dt.Rows(i).Item("TimeRemain")
                        ElseIf Dt.Rows(i).Item("TimeRemain") < 0 And Dt.Rows(i).Item("Remain") <= 0 Then
                            FacDelay += 1
                            RasDelay += (Dt.Rows(i).Item("TimeRemain") * -1)
                        End If
                    Next
                    LFacLast.Text = FacLast
                    LMonLast.Text = IIf(FacMonLast = 0, 0, FormatNumber(FacMonLast, 0))
                    LFacNext.Text = FacNext
                    LMonNext.Text = IIf(FacMonNext = 0, 0, FormatNumber(FacMonNext, 0))
                    LRasTime.Text = IIf((FacMonLast + FacMonNext) <= 0, 0, Math.Round(SumMon / (FacMonLast + FacMonNext), 2).ToString.Replace(".", "/"))
                    LRasMon.Text = IIf((FacMonLast + FacMonNext) = 0, 0, FormatNumber(FacMonLast + FacMonNext, 0))
                    LFacDelay.Text = FacDelay
                    LRasDelay.Text = RasDelay
                Else
                    LFacLast.Text = 0
                    LFacNext.Text = 0
                    LMonLast.Text = 0
                    LMonNext.Text = 0
                    LRasTime.Text = 0
                    LRasMon.Text = 0
                    LFacDelay.Text = 0
                    LRasDelay.Text = 0
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmValue", "RasDelay")
        End Try
    End Sub

    Private Sub LMoein_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LMoein.TextChanged
        If Not (CheckDigit(Format$(LMoein.Text.Replace(",", "")))) Then
            LMoein.Text = "0"
            Exit Sub
        End If
        If LMoein.Text.Length > 3 Then
            Dim str As String
            str = Format$(LMoein.Text.Replace(",", ""))
            LMoein.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub LGetChk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LGetChk.TextChanged
        If Not (CheckDigit(Format$(LGetChk.Text.Replace(",", "")))) Then
            LGetChk.Text = "0"
            Exit Sub
        End If
        If LGetChk.Text.Length > 3 Then
            Dim str As String
            str = Format$(LGetChk.Text.Replace(",", ""))
            LGetChk.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub LPayChk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LPayChk.TextChanged
        If Not (CheckDigit(Format$(LPayChk.Text.Replace(",", "")))) Then
            LPayChk.Text = "0"
            Exit Sub
        End If
        If LPayChk.Text.Length > 3 Then
            Dim str As String
            str = Format$(LPayChk.Text.Replace(",", ""))
            LPayChk.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub LValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LValue.TextChanged
        If Not (CheckDigit(Format$(LValue.Text.Replace(",", "")))) Then
            LValue.Text = "0"
            Exit Sub
        End If
        If LValue.Text.Length > 3 Then
            Dim str As String
            str = Format$(LValue.Text.Replace(",", ""))
            LValue.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub
    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Emkanat.htm")
        ElseIf e.KeyCode = Keys.F5 Then
            Me.CalCulate()
        End If
    End Sub

    Private Sub LSumDelay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LSumDelay.TextChanged
        If Not (CheckDigit(Format$(LSumDelay.Text.Replace(",", "")))) Then
            LSumDelay.Text = "0"
            Exit Sub
        End If
        If LSumDelay.Text.Length > 3 Then
            Dim str As String
            str = Format$(LSumDelay.Text.Replace(",", ""))
            LSumDelay.Text = Format$(Val(str), "###,###,###")
        End If
    End Sub

    Private Sub Chk0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk0.CheckedChanged
        Me.CalCulate()
    End Sub

    Private Sub LRisk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LRisk.TextChanged
        If CDbl(LRisk.Text.Trim) > 0 Then
            LRisk.BackColor = Color.LightGreen
        ElseIf CDbl(LRisk.Text.Trim) < 0 Then
            LRisk.BackColor = Color.Pink
        End If
    End Sub

    Private Sub ChkFroshChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFroshChk.CheckedChanged
        If ChkFroshChk.Checked = True Then
            Num.Enabled = True
        Else
            Num.Enabled = False
        End If
        Me.CalCulate()
    End Sub

    Private Sub Num_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num.ValueChanged
        Me.CalCulate()
    End Sub
End Class