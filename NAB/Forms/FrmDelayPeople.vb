Imports System.Data.SqlClient
Public Class FrmDelayPeople

    Private Sub ChkAllp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllp.CheckedChanged
        If DGV2.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To DGV2.RowCount - 1
            DGV2.Item("Cln_SelectP", i).Value = ChkAllp.Checked
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV2.RowCount <= 0 Then Exit Sub
        Dim frmlk As New People_List
        frmlk.Condition2 = "1"
        frmlk.ShowDialog()
        If Tmp_Namkala <> "" Then
            If DGV2.RowCount > 1 Then
                For i As Integer = 0 To DGV2.RowCount - 1
                    If DGV2.Item("Cln_IdP", i).Value = IdKala Then
                        DGV2.Item("Cln_NamP", i).Selected = True
                        Exit Sub
                    End If
                Next
                DGV2.Item("Cln_NamP", 0).Selected = True
                DGV2.Item("Cln_NamP", 0).Selected = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Using FrmAdVance As New People_List
            FrmAdVance.ChkAll.Visible = True
            FrmAdVance.Condition2 = "1"
            FrmAdVance.DGV.Columns("Cln_select").Visible = True
            FrmAdVance.ShowDialog()
            Try
                If AllSelectKala.Length > 0 Then
                    For i As Integer = 0 To DGV2.RowCount - 1
                        For j As Integer = 0 To AllSelectKala.Length - 1
                            If AllSelectKala(j).IdKala = DGV2.Item("Cln_IdP", i).Value Then DGV2.Item("Cln_SelectP", i).Value = True
                        Next
                    Next
                    Array.Resize(AllSelectKala, 0)
                End If
                DGV2.Focus()
            Catch ex As Exception
                Array.Resize(AllSelectKala, 0)
            End Try
        End Using
    End Sub

    Private Sub FrmReportGetChk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        GetKey(e)
    End Sub

    Private Sub FrmReportGetChk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F146")
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
        Me.GetPeople()
        DGV2.Columns("Cln_NamP").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
    End Sub

    Private Sub GetPeople()
        Try
            Dim dvP As New DataView
            Dim DsP As New DataSet
            Dim DtaP As New SqlDataAdapter()
            DsP.Clear()
            If Not DtaP Is Nothing Then
                DtaP.Dispose()
            End If
            Dim sqlstr As String = ""
            sqlstr = "SELECT Activ,Id,Nam FROM Define_People Order by Nam"
            DtaP = New SqlDataAdapter(sqlstr, DataSource)
            DtaP.Fill(DsP, "Define_People")
            DGV2.AutoGenerateColumns = False
            dvP = DsP.Tables("Define_People").DefaultView
            DGV2.DataSource = dvP
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayPeople", "GetPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV2.RowPostPaint
        If DGV2.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV2.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV2.DefaultCellStyle.Font, b, DGV2.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV2.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If

        If CBool(DGV2.Item("Cln_ActiveP", e.RowIndex).Value) = True Then
            DGV2.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            BtnOk.Focus()
            If DGV2.RowCount <= 0 Then
                MessageBox.Show("طرف حسابی وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = False And ChkTaDate.Checked = False Then
                    MessageBox.Show("محدوده تاریخ را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    If FarsiDate1.ThisText > FarsiDate2.ThisText Then
                        MessageBox.Show("محدوده تاریخ اشتباه است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If

            Dim condition As String = ""
            If ChkTime.Checked = True Then
                If ChkAzDate.Checked = True And ChkTaDate.Checked = True Then
                    condition = " AND(D_Date >='" & FarsiDate1.ThisText & "' AND D_Date<='" & FarsiDate2.ThisText & "')"
                ElseIf ChkAzDate.Checked = True And ChkTaDate.Checked = False Then
                    condition = " AND(D_Date >='" & FarsiDate1.ThisText & "')"
                ElseIf ChkAzDate.Checked = False And ChkTaDate.Checked = True Then
                    condition = " AND(D_Date <='" & FarsiDate2.ThisText & "')"
                Else
                    MessageBox.Show("شرط تاریخ نامشخص است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Dim ListPeople As String = ""
            Dim CountPeople As Long = 0
            ListPeople = " WHERE ListFactorSell.IdName IN("
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Item("Cln_SelectP", i).Value = True Then
                    ListPeople &= DGV2.Item("Cln_IdP", i).Value & ","
                    CountPeople += 1
                End If
            Next
            If CountPeople <= 0 Then
                MessageBox.Show("طرف حسابی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                ListPeople = ListPeople.Substring(0, ListPeople.Length - 1)
                ListPeople &= ")"
            End If

            Me.Enabled = False

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تاخیر مشتریان", "تهيه گزارش", "", "")

            Me.RasDelay(ListPeople, condition)

            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayPeople", "BtnOk_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepDelaymoshtari.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then Call BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Call Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button3.Enabled = True Then Call Button3_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetPeople()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChkFroshChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFroshChk.CheckedChanged
        If ChkFroshChk.Checked = True Then
            Num.Enabled = True
        Else
            Num.Enabled = False
        End If
    End Sub
    Private Sub RasDelay(ByVal Id As String, ByVal datsql As String)
        Try
            Dim str As String = "SELECT IdFactor,IdName,Nam,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec)-(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor ,Wanted_Frosh.Rate,d_date,IdName FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor " & Id & datsql & ") As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName"
            Dim Dt As New DataTable
            Dt.Clear()
            Dt.Columns.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(str, ConectionBank)
                Dt.Load(cmd.ExecuteReader)
                If Not Dt.Columns.Contains("EndDate") Then Dt.Columns.Add("EndDate", Type.GetType("System.String"))
                If Not Dt.Columns.Contains("TimeRemain") Then Dt.Columns.Add("TimeRemain", Type.GetType("System.Int32"))
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dt.Rows(i).Item("EndDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                    Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("EndDate"), Dt.Rows(i).Item("D_date"))

                    If Dt.Rows(i).Item("Remain") <= 0 Then
                        Dim dat As Object = Nothing

                        Using cmdT As New SqlCommand("SELECT TOP 1 D_Date FROM (SELECT D_date FROM Get_Pay_Sanad WHERE Id IN(SELECT IdSanad FROM PayLimitFrosh WHERE IdFactor =" & Dt.Rows(i).Item("IdFactor") & ") UNION SELECT D_date FROM ListFactorBackSell WHERE IdFacSell =" & Dt.Rows(i).Item("IdFactor") & " UNION SELECT D_date FROM ListKasriFactor WHERE IdFactor =" & Dt.Rows(i).Item("IdFactor") & ") As ListDat ORDER By D_date DESC", ConectionBank)
                            dat = cmdT.ExecuteScalar
                        End Using

                        If dat Is DBNull.Value Then
                            Dt.Rows(i).Item("TimeRemain") = 0
                        Else
                            Dt.Rows(i).Item("TimeRemain") = SUBDAY(Dt.Rows(i).Item("EndDate"), CStr(dat))
                        End If
                    Else
                        Dt.Rows(i).Item("TimeRemain") = SUBDAY(Dt.Rows(i).Item("EndDate"), GetDate())
                    End If
                Next
            End Using

            Dim EndDt As New DataTable
            If Not EndDt.Columns.Contains("Disc") Then EndDt.Columns.Add("Disc", Type.GetType("System.String"))
            If Not EndDt.Columns.Contains("T") Then EndDt.Columns.Add("T", Type.GetType("System.String"))
            If Not EndDt.Columns.Contains("EndT") Then EndDt.Columns.Add("EndT", Type.GetType("System.String"))
            If Not EndDt.Columns.Contains("BesMon") Then EndDt.Columns.Add("BesMon", Type.GetType("System.Double"))
            If Not EndDt.Columns.Contains("IdName") Then EndDt.Columns.Add("IdName", Type.GetType("System.Double"))

            Dim code() As String = Id.Replace(" WHERE ListFactorSell.IdName IN(", "").Replace(")", "").Split(",")

            For i As Integer = 0 To code.Length - 1
                Dim row() As DataRow = Dt.Select("IdName=" & code(i) & " AND TimeRemain < 0 And Remain <= 0")
                For j As Long = 0 To row.Length - 1
                    Dim newrow As DataRow = EndDt.NewRow
                    newrow("Disc") = row(j).Item("Nam")
                    newrow("IdName") = row(j).Item("IdName")
                    newrow("T") = "فاکتور"
                    newrow("EndT") = row(j).Item("IdFactor")
                    newrow("BesMon") = row(j).Item("TimeRemain") * -1
                    EndDt.Rows.Add(newrow)
                Next j
            Next i


            '///////////////////////////////////////////////////
            str = "SELECT DISTINCT  DelayChk,NumChk,Nam,IdPeople  FROM Sanad_ChangeChk,Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Id .Id =Chk_Get_Pay .ID INNER JOIN Define_People ON Define_People.ID =Chk_Id .Current_IdPeople    WHERE  DelayChk >0 AND " & Id.Replace(" WHERE ListFactorSell.IdName ", " IdPeople ") & datsql.Replace("D_Date", "Paydate") & "  AND IdChk IN (SELECT  Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Kind =0 and Chk_Get_Pay.Activ =1  AND Current_State =1) AND Chk_Get_Pay.ID =IdChk "
            Dim Dtr As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(str, ConectionBank)
                Dtr.Load(cmd.ExecuteReader)
                For i As Integer = 0 To code.Length - 1
                    Dim row() As DataRow = Dtr.Select("IdPeople=" & code(i))
                    For j As Long = 0 To row.Length - 1
                        Dim newrow As DataRow = EndDt.NewRow
                        newrow("Disc") = row(j).Item("Nam")
                        newrow("IdName") = row(j).Item("IdPeople")
                        newrow("T") = "چک"
                        newrow("EndT") = row(j).Item("NumChk")
                        newrow("BesMon") = row(j).Item("DelayChk")
                        EndDt.Rows.Add(newrow)
                    Next j
                Next i
            End Using



            If ChkFroshChk.Checked = True Then
                Dim dtFrosh As New DataTable
                Using cmd As New SqlCommand("SELECT  Chk_Get_Pay.NumChk,MAX(Chk_State.D_Date) As D_date,MAX(Chk_Get_Pay.PayDate) As PayDate,IdPeople,Nam,Rate=0 FROM Chk_State INNER JOIN Chk_Get_Pay ON Chk_Get_Pay.ID =Chk_State.Id INNER JOIN Chk_Id ON  Chk_Id.Id =Chk_State.Id INNER JOIN Define_People ON  Define_People.ID =Chk_Id .IdPeople WHERE Chk_State.Current_State =1 AND " & Id.Replace(" WHERE ListFactorSell.IdName ", " IdPeople ") & datsql.Replace("D_Date", "[GetDate]") & "  AND Chk_State.Id IN (SELECT  Chk_Get_Pay.ID FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0 AND Current_Kind =1 And Current_State =1) AND Chk_State.D_Date >PayDate GROUP By Chk_Get_Pay.NumChk,IdPeople,Nam  ", ConectionBank)
                    dtFrosh.Load(cmd.ExecuteReader)
                End Using
                If dtFrosh.Rows.Count > 0 Then
                    dtFrosh.Columns("Rate").ReadOnly = False
                    For i As Integer = 0 To dtFrosh.Rows.Count - 1
                        dtFrosh.Rows(i).Item("Rate") = SUBDAY(dtFrosh.Rows(i).Item("D_date"), dtFrosh.Rows(i).Item("PayDate"))
                    Next

                    For i As Integer = 0 To code.Length - 1
                        Dim row() As DataRow = dtFrosh.Select("IdPeople=" & code(i) & " AND Rate>=" & CLng(Num.Value))
                        For j As Long = 0 To row.Length - 1
                            Dim newrow As DataRow = EndDt.NewRow
                            newrow("Disc") = row(j).Item("Nam")
                            newrow("IdName") = row(j).Item("IdPeople")
                            newrow("T") = "چک خرج شده"
                            newrow("EndT") = row(j).Item("NumChk")
                            newrow("BesMon") = row(j).Item("Rate")
                            EndDt.Rows.Add(newrow)
                        Next j
                    Next i

                End If
            End If
            '///////////////////////////////////////////////////
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If EndDt.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If ChkTafkik.Checked = False Then
                    If RdoP.Checked = True Then
                        FrmPrint.Lend = "RDOP"
                    ElseIf RdoM.Checked = True Then
                        FrmPrint.Lend = "RDOM"
                    ElseIf RdoC.Checked = True Then
                        FrmPrint.Lend = "RDOC"
                    End If
                    FrmPrint.DtMoeinBox = EndDt
                    FrmPrint.CHoose = "DELAY-ALL"
                    FrmPrint.ShowDialog()
                Else
                    Dim EDt As New DataTable
                    If Not EDt.Columns.Contains("Disc") Then EDt.Columns.Add("Disc", Type.GetType("System.String"))
                    If Not EDt.Columns.Contains("BedMon") Then EDt.Columns.Add("BedMon", Type.GetType("System.Double"))
                    If Not EDt.Columns.Contains("BesMon") Then EDt.Columns.Add("BesMon", Type.GetType("System.Double"))
                    If Not EDt.Columns.Contains("IdUser") Then EDt.Columns.Add("IdUser", Type.GetType("System.Double"))
                    If Not EDt.Columns.Contains("Id") Then EDt.Columns.Add("Id", Type.GetType("System.Double"))
                    If Not EDt.Columns.Contains("IdName") Then EDt.Columns.Add("IdName", Type.GetType("System.Double"))
                    If Not EDt.Columns.Contains("EndMandeh") Then EDt.Columns.Add("EndMandeh", Type.GetType("System.Double"))
                    If Not EDt.Columns.Contains("Mandeh") Then EDt.Columns.Add("Mandeh", Type.GetType("System.Double"))

                    Dim flag As Boolean

                    For i As Long = 0 To EndDt.Rows.Count - 1
                        flag = False
                        For j As Long = 0 To EDt.Rows.Count - 1
                            If EDt.Rows(j).Item("IdName") = EndDt.Rows(i).Item("IdName") Then

                                If EndDt.Rows(i).Item("T") = "فاکتور" Then
                                    EDt.Rows(j).Item("BedMon") += 1
                                    EDt.Rows(j).Item("BesMon") += EndDt.Rows(i).Item("BesMon")
                                    EDt.Rows(j).Item("EndMandeh") += 1
                                    EDt.Rows(j).Item("Mandeh") += EndDt.Rows(i).Item("BesMon")
                                Else
                                    EDt.Rows(j).Item("IdUser") += 1
                                    EDt.Rows(j).Item("Id") += EndDt.Rows(i).Item("BesMon")
                                    EDt.Rows(j).Item("EndMandeh") += 1
                                    EDt.Rows(j).Item("Mandeh") += EndDt.Rows(i).Item("BesMon")
                                End If
                                flag = True
                                Exit For
                            End If
                        Next j
                        If flag = False Then
                            Dim newrow As DataRow = EDt.NewRow
                            newrow("Disc") = EndDt.Rows(i).Item("Disc")
                            newrow("IdName") = EndDt.Rows(i).Item("IdName")

                            If EndDt.Rows(i).Item("T") = "فاکتور" Then
                                newrow("BedMon") = 1
                                newrow("BesMon") = EndDt.Rows(i).Item("BesMon")
                                newrow("IdUser") = 0
                                newrow("Id") = 0
                                newrow("EndMandeh") = 1
                                newrow("Mandeh") = EndDt.Rows(i).Item("BesMon")
                            Else
                                newrow("BedMon") = 0
                                newrow("BesMon") = 0
                                newrow("IdUser") = 1
                                newrow("Id") = EndDt.Rows(i).Item("BesMon")
                                newrow("EndMandeh") = 1
                                newrow("Mandeh") = EndDt.Rows(i).Item("BesMon")
                            End If
                            EDt.Rows.Add(newrow)
                        End If
                    Next i
                    If RdoP.Checked = True Then
                        FrmPrint.Lend = "RDOP"
                    ElseIf RdoM.Checked = True Then
                        FrmPrint.Lend = "RDOM"
                    ElseIf RdoC.Checked = True Then
                        FrmPrint.Lend = "RDOC"
                    End If
                    FrmPrint.DtMoeinBox = EDt
                    FrmPrint.CHoose = "DELAY"
                    FrmPrint.ShowDialog()
                End If
            End If

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDelayPeople", "RasDelay")
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

    Private Sub ChkTafkik_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTafkik.CheckedChanged
        If ChkTafkik.Checked = True Then
            RdoC.Enabled = True
        Else
            RdoC.Enabled = False
            RdoP.Checked = True
        End If
    End Sub
End Class