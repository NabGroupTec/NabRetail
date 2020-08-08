Imports System.Data.SqlClient
Imports System.Transactions
Imports System.IO
Module PublicFunction
    Public IdKala, TxtIdOstan, TxtIdCity, DK_KOL, Id_User, Kind_User, OldSanad, CurSanad, Idanbar, Id_Account, AllowEdit, StateMobile, Rate As Long
    Public Fnew, DK, SMS, DeleverSMS, QExit, Cashing, ShowConnect, Cash, MAnbar, MBank, MBox, TmpHajm, TmpKalaCash, LimitMonFac, LimitDec, LimitAdd, LimitHajm, LimitDate, LimitNoSell As Boolean
    Public Tmp_Mon, DK_JOZ, TmpDarsad, TmpDarsadMon, TmpDarsad1, TmpDarsadMon1, TmpDarsad2, flagV As Double
    Public Tmp_Namkala, Tmp_OneGroup, Tmp_TwoGroup, Tmp_String1, Tmp_String2, TmpAddress, TmpTell1, TmpTell2, TmpVahed, NamUser, namAnbar, namAnbar2, Access_Form, Nam_Account, Nam_Period, Id_Period, DiscFactor, tc1, tc2, tc3, Trial As String
    Public DOMAIN As String = ""
    Public TmpGroupName, StrGetChk, StrPayChk, StrMessage, StrLF, StrHF, StrBed, StrBes As String
    Public m_DCW As New DomainConnectWatcher
    Dim NtDisconnect As New NotifyIcon
    Public Tmp_DtBox, Tmp_DtBank, Tmp_DtAmval, Tmp_DtSarmayeh, Tmp_DtKala, Tmp_Kala As New DataTable
    Public DataSource As String = ""
    Public ConectionBank As New SqlClient.SqlConnection()

    Public S32 As Boolean
    '
    Public FontName As String = "IRANSans"
    Public FontSize As Single = 9.0F
    Structure KalaSelect
        Dim Id As Long
        Dim IdKala As Long
        Dim Namekala As String
        Dim CostSkala As Double
        Dim CostBkala As Double
        Dim EndCost As Double
        Dim OneGroup As String
        Dim TwoGroup As String
        Dim str1 As String
        Dim str2 As String
        Dim str3 As String
        Dim str4 As String
    End Structure

    Structure OrderManual
        Dim GroupKala As String
        Dim Nam As String
        Dim MKolStr As String
        Dim MJozStr As String
        Dim SumMKolStr As String
        Dim SumMJozStr As String
        Dim KolStr As String
        Dim JozStr As String
        Dim SumKolStr As String
        Dim SumJozStr As String
        Dim Darsad As String
        Dim SumDarsad As String
        Dim KolOrderWeek As String
        Dim JozOrderWeek As String
        Dim SumKolOrderWeek As String
        Dim SumJozOrderWeek As String
        Dim KolOrderMonth As String
        Dim JozOrderMonth As String
        Dim SumKolOrderMonth As String
        Dim SumJozOrderMonth As String
        Dim KolOrder As String
        Dim JozOrder As String
        Dim SumKolOrder As String
        Dim SumJozOrder As String
        Dim KolOrderDay As String
        Dim SumKolOrderDay As String
        Dim Fe As Double
        Dim AllMon As Double
    End Structure

    Structure LimitList
        Dim IdFactor As Long
        Dim Mon As Double
        Dim Pay As Double
    End Structure
    Structure ChargeList
        Dim IdCharge As Long
        Dim Mon As Double
        Dim disc As String
        Dim CDisc As String
        Dim sanad As String
    End Structure
    Structure ListChk
        Dim Id As Long
        Dim Kind As Long
        Dim State As Long
        Dim NumChk As String
    End Structure
    Structure ListChkPrint
        Dim Id As Long
        Dim Type As String
        Dim nam As String
        Dim GetDate As String
        Dim PayDate As String
        Dim Bank As String
        Dim Shobeh As String
        Dim numchk As Double
        Dim Mon As Double
        Dim StateChk As String
        Dim NumBank As String
        Dim Ras As String
        Dim Tell As String
    End Structure
    Structure ListDelayPrint
        Dim IdFactor As Long
        Dim nam As String
        Dim Tell1 As String
        Dim Tell2 As String
        Dim D_Date As String
        Dim EndDate As String
        Dim TimeRemain As Double
        Dim Rate As Double
        Dim Remain As Double
        Dim Disc As String
        Dim Kind As String
        Dim Nam2 As String
        Dim Tmp As Double
        Dim T As String
        Dim Mandeh As Double
        Dim Darsad As String
        Dim SUMDarsad As String
        Dim Tmp2 As Double
        Dim KindFrosh As String
    End Structure
    Structure KalaFactor
        Dim IdService As Long
        Dim IdKala As Long
        Dim KolCount As Double
        Dim JozCount As Double
        Dim Fe As Double
        Dim DarsadDiscount As Double
        Dim DarsadMon As Double
        Dim Mon As Double
        Dim Disc As String
        Dim CodeAnbar As Long
        Dim DK As Boolean
        Dim DK_KOL As Double
        Dim DK_JOZ As Double
    End Structure
    Structure KalaSFactor
        Dim IdKala As Long
        Dim KolCount As Double
        Dim JozCount As Double
        Dim Fe As Double
        Dim DarsadDiscount As Double
        Dim DarsadMon As Double
        Dim Mon As Double
        Dim CodeAnbar As Long
        Dim NamKala As String
        Dim GroupKala As String
        Dim NamAnbar As String
        Dim NamVahed As String
        Dim DK As Boolean
        Dim DK_KOL As Double
        Dim DK_JOZ As Double
    End Structure
    Structure InfoFactor
        Dim Sanad As String
        Dim Part As String
        Dim D_date As String
        Dim IdName As Long
        Dim IdVisitor As Long
        Dim IdPart As Long
        Dim Disc As String
        Dim IdFactor As Long
    End Structure
    Structure RasChk
        Dim MonChk As Double
        Dim SumChk As Double
    End Structure

    Structure Lkala
        Dim GroupKala As String
        Dim NamKala As String
        Dim Mon As String
        Dim Hajm As String
        Dim Idkala As Long
    End Structure

    Structure LDarsad
        Dim Frosh As String
        Dim Darsad As String
        Dim Group As String
        Dim IdGroup As Long
        Dim row As Long
    End Structure

    Structure LODarsad
        Dim Darsad As String
        Dim Group As String
        Dim IdGroup As Long
    End Structure

    Structure TmpWeek
        Dim Part As String
        Dim Idpart As Long
        Dim Mon As Double
    End Structure

    Structure ListF
        Dim Nam As String
        Dim IdFactor As Long
        Dim NamCi As String
        Dim D_date As String
        Dim MonFac As Double
        Dim Discount As Double
        Dim Discount1 As Double
        Dim AllMonFac As Double
        Dim Cash As Double
        Dim Kasri As Double
        Dim Chk As Double
        Dim Lend As Double
        Dim IdExit As String
    End Structure

    Structure RateKala
        Dim IdVisitor As Long
        Dim IdUser As Long
        Dim Nam As String
        Dim IdFactor As Long
        Dim Mon As Double
        Dim CountRate As Double
        Dim RasFactor As Double
        Dim CRasRate As String
    End Structure

    Structure KalaEdit
        Dim IdKala As Long
        Dim OKol As Double
        Dim Ojoz As Double
        Dim TKol As Double
        Dim Tjoz As Double
        Dim IdAnbar As Long
    End Structure

    Public AllSelectKala() As KalaSelect
    Public FactorArray() As KalaFactor
    Public SFactorArray() As KalaSFactor
    Public InfoFactorArray() As InfoFactor
    Public LimitListArray() As LimitList
    Public ChargeListArray() As ChargeList
    Public ListChkArray() As ListChk
    Public ListChkPrintArray() As ListChkPrint
    Public ListDelayPrintArray() As ListDelayPrint
    Public ListRasChk() As RasChk
    Public ListKala() As Lkala
    Public ListDarsad() As LDarsad
    Public ListODarsad() As LODarsad
    Public ListWeek() As TmpWeek
    Public ListFactor() As ListF
    Public ListRateKala() As RateKala
    Public ListEditKala() As KalaEdit
    Public ListOrderManual() As OrderManual
    Public Function GetAllControls(container As Control, list As List(Of Control)) As List(Of Control)
        For Each c As Control In container.Controls

            If c.Controls.Count > 0 Then
                list = GetAllControls(c, list)
            Else
                list.Add(c)
            End If
        Next

        Return list
    End Function
    Public Function GetAllControls(container As Control) As List(Of Control)
        Return GetAllControls(container, New List(Of Control)())
    End Function
    Public Function CheckDate(ByVal dat As String) As Boolean

        If Not (dat Is DBNull.Value) Then
            If dat.Trim <> "" Then
                If dat.Length = 10 Then
                    If dat.Contains("/") Then
                        If IsNumeric(dat.Replace("/", "")) Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function CheckDigit(ByVal s_Digit As Object) As Boolean
        Try
            If IsNumeric(s_Digit) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CheckDigit")
            Return False
        End Try
    End Function
    Public Function GetDate() As String
        Try
            Dim ps As New Globalization.PersianCalendar()
            Dim y As String = ps.GetYear(DateTime.Now)
            Dim m As String = ps.GetMonth(DateTime.Now)
            Dim d As String = ps.GetDayOfMonth(DateTime.Now)
            If y.Length <= 1 Then y = "0" + y
            If m.Length <= 1 Then m = "0" + m
            If d.Length <= 1 Then d = "0" + d
            Return y & "/" & m & "/" & d
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetDate")
            Return ""
        End Try
    End Function

    Public Function ConvertDate(ByVal dat As String) As String
        Try
            Dim ps As New Globalization.PersianCalendar()
            Dim y As String = ps.GetYear(dat)
            Dim m As String = ps.GetMonth(dat)
            Dim d As String = ps.GetDayOfMonth(dat)
            If y.Length <= 1 Then y = "0" + y
            If m.Length <= 1 Then m = "0" + m
            If d.Length <= 1 Then d = "0" + d
            Return y & "/" & m & "/" & d
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "ConvertDate")
            Return ""
        End Try
    End Function

    Public Function CheckDigitWithOutpoint(ByVal s_Digit As String) As Boolean
        Try
            If IsNumeric(s_Digit) Then
                For i As Integer = 0 To s_Digit.Length - 1
                    If s_Digit(i).ToString = "." Then
                        Return False
                        Exit Function
                    End If
                Next
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CheckDigitWithOutpoint")
            Return False
        End Try
    End Function

    Public Function ADDDAY(ByVal dat As String) As String
        Dim y As String = dat.Substring(0, 4).ToString
        Dim m As String = dat.Substring(5, 2).ToString
        Dim d As String = dat.Substring(8, 2).ToString
        Dim ps As New Globalization.PersianCalendar
        Dim CountDay As Integer = ps.GetDaysInMonth(y, m, 1)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If (1 + CInt(d)) <= CountDay Then
            If m.Length <= 1 Then m = "0" + m
            d = CStr((CInt(d) + 1))
            If d.Length <= 1 Then d = "0" + d
        ElseIf (1 + CInt(d)) > CountDay Then
            If (CInt(m) + 1) <= 12 Then
                m = (CInt(m) + 1)
                If m.Length <= 1 Then m = "0" + m
                d = "01"
            ElseIf (CInt(m) + 1) > 12 Then
                m = "01"
                d = "01"
                y = (CInt(y) + 1)
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Return y & "/" & m & "/" & d
    End Function
    Public Function DECDAY(ByVal dat As String) As String
        Dim y As String = dat.Substring(0, 4).ToString
        Dim m As String = dat.Substring(5, 2).ToString
        Dim d As String = dat.Substring(8, 2).ToString
        Dim ps As New Globalization.PersianCalendar
        Dim CountDay As Integer = ps.GetDaysInMonth(y, m, 1)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If (CInt(d) - 1) >= 1 Then
            If m.Length <= 1 Then m = "0" + m
            d = CStr((CInt(d) - 1))
            If d.Length <= 1 Then d = "0" + d
        ElseIf (CInt(d) - 1) < 1 Then
            If (CInt(m) - 1) >= 1 Then
                m = (CInt(m) - 1)
                If m.Length <= 1 Then m = "0" + m
                d = CountDay
            ElseIf (CInt(m) - 1) < 1 Then
                m = "12"
                d = CountDay
                y = (CInt(y) - 1)
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Return y & "/" & m & "/" & d
    End Function
    Public Function DECMonth(ByVal dat As String) As String
        Dim y As String = dat.Substring(0, 4).ToString
        Dim m As String = dat.Substring(5, 2).ToString
        Dim d As String = dat.Substring(8, 2).ToString
        Dim ps As New Globalization.PersianCalendar
        Dim CountDay As Integer = 0
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If (CInt(m) - 1) >= 1 Then
            m = (CInt(m) - 1)
            If m.Length <= 1 Then m = "0" + m
            CountDay = ps.GetDaysInMonth(y, m, 1)
            If CInt(d) > CountDay Then
                d = CountDay
                If d.Length <= 1 Then d = "0" + d
            End If
        ElseIf (CInt(m) - 1) < 1 Then
            m = "12"
            y = (CInt(y) - 1)
            CountDay = ps.GetDaysInMonth(y, m, 1)
            If CInt(d) > CountDay Then
                d = CountDay
                If d.Length <= 1 Then d = "0" + d
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Return y & "/" & m & "/" & d
    End Function
    Public Function SUBDAY(ByVal dat2 As String, ByVal dat1 As String) As Long
        Try
            Dim y1 As String = dat1.Substring(0, 4).ToString
            Dim m1 As String = dat1.Substring(5, 2).ToString
            Dim d1 As String = dat1.Substring(8, 2).ToString
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim y2 As String = dat2.Substring(0, 4).ToString
            Dim m2 As String = dat2.Substring(5, 2).ToString
            Dim d2 As String = dat2.Substring(8, 2).ToString
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ps As New Globalization.PersianCalendar
            Dim CountDay1 As Integer = ps.GetDaysInMonth(y1, m1, 1)
            Dim CountDay2 As Integer = ps.GetDaysInMonth(y2, m2, 1)

            If dat2 = dat1 Then Return 0

            If dat2 > dat1 Then
                Dim result As Long = 0
                Dim flag As Boolean = True
                Dim tmpdate As String = dat1
                Do While flag
                    tmpdate = ADDDAY(tmpdate)
                    If tmpdate = dat2 Then
                        result += 1
                        flag = False
                    Else
                        result += 1
                        flag = True
                    End If
                Loop
                Return result
            ElseIf dat1 > dat2 Then
                Dim result As Long = 0
                Dim flag As Boolean = True
                Dim tmpdate As String = dat2
                Do While flag
                    tmpdate = ADDDAY(tmpdate)
                    If tmpdate = dat1 Then
                        result -= 1
                        flag = False
                    Else
                        result -= 1
                        flag = True
                    End If
                Loop
                Return result
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Sub GetError(ByVal Err As String, ByVal Frm As String, ByVal Loc As String)
        Using Ferror As New FrmError
            FrmError.TxtError.Text = "نام فرمی که خطا در آن به وجود آمده است" & vbCrLf & Frm & vbCrLf & vbCrLf & "نام بخشی از سورس که خطا در آن به وجود آمده است" & vbCrLf & Loc & vbCrLf & vbCrLf & "متن خطای به وجود آمده" & vbCrLf & Err
            FrmError.ShowDialog()
        End Using
    End Sub
    Public Function GetNumberState(ByVal Str As String) As Long
        If Str = "در جریان وصول" Then
            Return 0
        ElseIf Str = "وصول شده" Then
            Return 1
        ElseIf Str = "برگشتی" Then
            Return 2
        ElseIf Str = "تضمینی" Then
            Return 3
        ElseIf Str = "برات" Then
            Return 4
        End If
    End Function
    Public Function AreYouEditCheck(ByVal Id As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT (SELECT ISNULL(SUM(abs(IdPeople-Current_IdPeople)),0) From Chk_Id WHERE Id=@ID)+ ISNULL(SUM( abs(Kind-Current_Kind )+ abs([State] -Current_State )+ abs(Type_Chk -Current_Type_Chk )+ abs([TYPE]-Current_Type ) + abs(Number_Type -Current_Number_Type )),0) AS Result From Chk_Get_Pay WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                If Cmd.ExecuteScalar <> 0 Then
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return False
                End If
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouEditCheck")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouAddNumberCheck(ByVal Id As Long, ByVal Num As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT Lsh.CoL+GPCHK.COG FROM(SELECT COUNT(Lasheh_Chk.NumChk)as CoL FROM Lasheh_Chk INNER JOIN Define_Chk ON Lasheh_Chk.Id = Define_Chk.Aid WHERE Lasheh_Chk.NumChk=@NUM AND Define_Chk.ID=@Id)as lsh,(SELECT COUNT(Chk_Get_Pay.ID)as COG FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Chk_Get_Pay.Current_State <> 4 AND Chk_Get_Pay.NumChk=@NUM AND Chk_Id.IdBank=@Id) as GPCHK", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Cmd.Parameters.AddWithValue("@NUM", SqlDbType.BigInt).Value = Num
                If Cmd.ExecuteScalar <> 0 Then
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return False
                End If
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouAddNumberCheck")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function GetTimePeople(ByVal Id As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Dim tim As Long = 0
            Using Cmd As New SqlCommand("SELECT rate FROM Define_People WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Id
                tim = Cmd.ExecuteScalar
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return tim
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetTimePeople")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return 0
        End Try
    End Function
    Public Function GetIdBox(ByVal Id As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Dim tim As Long = 0
            Using Cmd As New SqlCommand("SELECT IDBox FROM Moein_Box WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = Id
                tim = Cmd.ExecuteScalar
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return tim
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetIdBox")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return 0
        End Try
    End Function
    Public Function AreYouEditNumberCheck(ByVal Id As Long, ByVal Num As Long, ByVal OldId As Long, ByVal OldNum As Long) As Boolean
        Try
            Dim T_str As String = "SELECT Chk_Get_Pay.NumChk ,Chk_Id.IdBank FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE Chk_Get_Pay.NumChk=" & Num & " AND Chk_Id.IdBank=" & Id & " UNION SELECT Lasheh_Chk.NumChk,Define_Chk.ID As IdBank  FROM Lasheh_Chk INNER JOIN Define_Chk ON Lasheh_Chk.Id = Define_Chk.Aid WHERE Lasheh_Chk.NumChk=" & Num & " AND Define_Chk.ID=" & Id
            Dim T_ds As New DataSet
            Dim T_dta As New System.Data.SqlClient.SqlDataAdapter()
            ''''''''''''''''''''''''''
            T_ds.Clear()
            If Not T_dta Is Nothing Then T_dta.Dispose()
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            T_dta = New System.Data.SqlClient.SqlDataAdapter(T_str, ConectionBank)
            T_dta.Fill(T_ds)
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            If T_ds.Tables(0).Rows.Count <= 0 Then
                Return True
            ElseIf T_ds.Tables(0).Rows.Count > 1 Then
                Return False
            ElseIf T_ds.Tables(0).Rows.Count = 1 Then
                If (T_ds.Tables(0).Rows(0).Item("IdBank") <> Id Or T_ds.Tables(0).Rows(0).Item("IdBank") = OldId) And (T_ds.Tables(0).Rows(0).Item("NumChk") <> Num Or T_ds.Tables(0).Rows(0).Item("NumChk") = OldNum) Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouEditNumberCheck")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function GetStateBank(ByVal Id As Long) As String
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT [State] FROM Define_bank WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Dim str As String = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetStateBank")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function
    Public Function GetStateChk(ByVal Id As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT Current_State FROM Chk_Get_Pay WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Dim str As Long = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetStateChk")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function
    Public Function GetNamBank(ByVal Id As Long) As String
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT N_Bank From Define_Bank WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Dim str As String = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetNamBank")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function
    Public Function GetNamPeolpe(ByVal Id As Long) As String
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT Nam From Define_People WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Dim str As String = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetNamPeolpe")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function
    Public Function GetNamVisitor(ByVal Id As Long) As String
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT Nam FROM Define_Visitor WHERE Id=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id
                Dim str As String = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetNamVisitor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function
    Public Function GetNamCompany() As String
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT CompanyName From Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                Dim str_nam As String = ""
                If dtr.HasRows Then
                    dtr.Read()
                    str_nam = dtr("CompanyName")
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return str_nam
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return ""
                End If

            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetNamCompany")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function

    Public Function GetTellPeople(ByVal Id As Long) As String
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT ISNULL(Tell2,'') As Tell FROM Define_People WHERE ID =" & Id, ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                Dim str_nam As String = ""
                If dtr.HasRows Then
                    dtr.Read()
                    str_nam = dtr("Tell")
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return str_nam
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return ""
                End If

            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetTellPeople")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return ""
        End Try
    End Function

    Public Function GetArmCompany() As Byte()
        Dim byt() As Byte = Nothing
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT CompanyImage From Define_Company", ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                Dim str_nam As String = ""
                If dtr.HasRows Then
                    dtr.Read()
                    byt = dtr("CompanyImage")
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return byt
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return byt
                End If

            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetArmCompany")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return byt
        End Try
    End Function
    Public Function RoolBackFactor(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Try
            RoolFactor(Idfac, State)
            RoolPayChk(Idfac, State)
            RoolSellChk(Idfac, State)
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolBackFactor")
            Return False
        End Try
    End Function

    Public Function RoolBackPishFactor(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Try
            RoolPayChk(Idfac, State)
            RoolSellChk(Idfac, State)
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolBackPishFactor")
            Return False
        End Try
    End Function

    Public Function RoolBackOthrCharge(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Try
            RoolOtherCharge(Idfac, State)
            RoolPayChk(Idfac, State)
            RoolSellChk(Idfac, State)
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolBackOthrCharge")
            Return False
        End Try
    End Function

    Public Function RoolOtherCharge(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("DELETE FROM " & If(State = 16, "ListOtherCharge", "ListFactorCharge") & " WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Idfac
                Cmd.ExecuteNonQuery()
            End Using
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فاکتور هزینه قابل برگشت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolOtherCharge")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function RoolFactor(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Dim ListName As String = ""
        Dim KalaName As String = ""
        If State = 0 Or State = 2 Then
            ListName = "ListFactorBuy"
            KalaName = "KalaFactorBuy"
        ElseIf State = 1 Then
            ListName = "ListFactorBackBuy"
            KalaName = "KalaFactorBackBuy"
        ElseIf State = 3 Or State = 5 Then
            ListName = "ListFactorSell"
            KalaName = "KalaFactorSell"
        ElseIf State = 4 Then
            ListName = "ListFactorBackSell"
            KalaName = "KalaFactorBackSell"
        ElseIf State = 8 Then
            ListName = "ListFactorService"
            KalaName = "KalaFactorService"
        End If
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("DELETE FROM " & ListName & " WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = Idfac
                Cmd.ExecuteNonQuery()
            End Using
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات فاکتور قابل برگشت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolFactor")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function RoolPayChk(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            Dim ds As New DataSet
            Dim dta As New SqlDataAdapter()
            dta = New SqlDataAdapter("SELECT ID FROM  Chk_Get_Pay WHERE ([Type] =" & State & " ) AND (Number_Type = " & Idfac & ")", DataSource)
            dta.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Using CmdChk As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        CmdChk.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Tables(0).Rows(i).Item(0)
                        CmdChk.ExecuteNonQuery()
                        CmdChk.Parameters.Clear()
                    Next
                End Using
            End If
            ds.Dispose()
            dta.Dispose()
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات چکهای پرداختی قابل برگشت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolPayChk")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function RoolSellChk(ByVal Idfac As Long, ByVal State As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction

        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            '////////////////////////////////////////
            Dim ds2 As New DataSet
            ds2.Clear()
            Dim dta2 As New SqlDataAdapter()
            dta2 = New SqlDataAdapter("SELECT ID FROM  Chk_Get_Pay WHERE (Kind=0 AND Current_Kind=1) AND (Current_Type =" & State & " ) AND (Current_Number_Type = " & Idfac & ")", DataSource)
            dta2.Fill(ds2)
            If ds2.Tables(0).Rows.Count > 0 Then
                Using Cmd2 As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=Number_Type,Current_Kind=Kind,Current_Type_Chk=Type_Chk,Activ=@Activ,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId)", ConectionBank)
                    For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        Cmd2.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd2.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds2.Tables(0).Rows(i).Item(0)
                        Cmd2.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd2.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd2.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                        Cmd2.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd2.Parameters.AddWithValue("@Activ", SqlDbType.BigInt).Value = 1
                        Cmd2.ExecuteNonQuery()
                        Cmd2.Parameters.Clear()
                    Next
                End Using
            End If
            ds2.Dispose()
            dta2.Dispose()
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            If Err.Number = 5 Then
                MessageBox.Show("اطلاعات چکهای خرج شده قابل برگشت نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "RoolSellChk")
            End If
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouEditFactor(ByVal IdFac As Long, ByVal State As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim tablename As String = ""
            If State = 0 Or State = 2 Then
                tablename = "ListFactorBuy"
            ElseIf State = 1 Then
                tablename = "ListFactorBackBuy"
            ElseIf State = 3 Or State = 5 Or State = 7 Then
                tablename = "ListFactorSell"
            ElseIf State = 4 Then
                tablename = "ListFactorBackSell"
            ElseIf State = 6 Then
                tablename = "ListFactorDamage"
            ElseIf State = 8 Then
                tablename = "ListFactorService"
            End If
            Using Cmd As New SqlCommand("SELECT EditFlag FROM " & tablename & " WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                Dim str_Res As Long = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                If str_Res = 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouEditFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouEditSanad(ByVal IdFac As Long, ByVal State As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim tablename As String = ""
            If State = 0 Or State = 1 Then
                tablename = "Get_Pay_Sanad"
            ElseIf State = 3 Then
                tablename = "ListFactorCharge"
            ElseIf State = 4 Then
                tablename = "ListOtherCharge"
            ElseIf State = 5 Then
                tablename = "Get_Daramad"
            ElseIf State = 6 Then
                tablename = "Get_Pay_Amval"
            ElseIf State = 7 Then
                tablename = "Get_Pay_Sarmayeh"
            ElseIf State = 13 Then
                tablename = "ListEditMoein"
            End If
            Using Cmd As New SqlCommand("SELECT EditFlag FROM " & tablename & " WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = IdFac
                Dim str_Res As Long = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                If str_Res = 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouEditSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouEditMoein(ByVal IdFac As Long, ByVal State As Long) As Integer
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            Using Cmd As New SqlCommand("SELECT COUNT(Id) FROM ListEditMoein WHERE " & If(State = 4, "IdSCharge =", "IdSDaramad =") & IdFac, ConectionBank)
                Dim str_Res As Long = Cmd.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return str_Res
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouEditMoein")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function
    Public Function SetEditFlagFactor(ByVal IdFac As Long, ByVal State As Long, ByVal FlagEdit As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)

            Dim tablename As String = GetTableNameFactor(State, "LIST")
            Using Cmd As New SqlCommand("UPDATE " & tablename & " SET EditFlag=@EditFlag WHERE IdFactor=@IdFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = FlagEdit
                Cmd.ExecuteNonQuery()
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            End Using
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetEditFlagFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function SetEditFlagSanad(ByVal IdFac As Long, ByVal FlagEdit As Long, ByVal State As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Dim tablename As String = ""
            If State = 0 Or State = 1 Then
                tablename = "Get_Pay_Sanad"
            ElseIf State = 5 Then
                tablename = "Get_Daramad"
            ElseIf State = 6 Then
                tablename = "Get_Pay_Amval"
            ElseIf State = 7 Then
                tablename = "Get_Pay_Sarmayeh"
            ElseIf State = 13 Then
                tablename = "ListEditMoein"
            End If
            Using Cmd As New SqlCommand("UPDATE " & tablename & " SET EditFlag=@EditFlag WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = FlagEdit
                Cmd.ExecuteNonQuery()
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            End Using
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetEditFlagSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function SetEditFlagOtherCharge(ByVal IdFac As Long, ByVal FlagEdit As Long, ByVal state As Long) As Boolean
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            Dim Tablename As String = ""
            If state = 3 Then
                Tablename = "ListFactorCharge"
            ElseIf state = 4 Then
                Tablename = "ListOtherCharge"
            End If
            Using Cmd As New SqlCommand("UPDATE " & Tablename & " SET EditFlag=@EditFlag WHERE Id=@Id", ConectionBank)
                Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = IdFac
                Cmd.Parameters.AddWithValue("@EditFlag", SqlDbType.Int).Value = FlagEdit
                Cmd.ExecuteNonQuery()
                sqltransaction.Commit()
                sqltransaction.Dispose()
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return True
            End Using
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetEditFlagOtherCharge")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouDeleteCheckFactor(ByVal IdFac As Long, ByVal State As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim tmpStat As Long = 0
            If State = 121 Then
                tmpStat = 12
            Else
                tmpStat = State
            End If
            Using SearchCommand As New SqlCommand("SELECT ID,Activ,State,Current_State,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=" & tmpStat & " AND Number_Type=" & IdFac & ") OR (Current_Type=" & tmpStat & " AND Current_Number_Type=" & IdFac & ")", ConectionBank)
                Dim dtr As SqlDataReader = SearchCommand.ExecuteReader
                If dtr.HasRows Then
                    While dtr.Read
                        If dtr("Activ") = 0 Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If dtr("State") <> dtr("Current_State") Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If State = 1 Or State = 3 Or State = 5 Or State = 8 Or State = 12 Or State = 15 Then
                            If dtr("Kind") <> dtr("Current_Kind") Then
                                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                Return False
                            End If
                        End If
                    End While
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouDeleteCheckFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function AreYouDeleteCheckSarmayeh(ByVal IdFac As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim state As Long = -1
            Using cmd As New SqlCommand("SELECT TOP 1 [State] FROM Get_Pay_Sarmayeh WHERE Id =" & IdFac, ConectionBank)
                state = cmd.ExecuteScalar()
            End Using
            Using SearchCommand As New SqlCommand("SELECT ID,Activ,State,Current_State,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=21 AND Number_Type=" & IdFac & ") OR (Current_Type=21 AND Current_Number_Type=" & IdFac & ")", ConectionBank)
                Dim dtr As SqlDataReader = SearchCommand.ExecuteReader
                If dtr.HasRows Then
                    While dtr.Read
                        If dtr("Activ") = 0 Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If dtr("State") <> dtr("Current_State") Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If state = 1 Then
                            If dtr("Kind") <> dtr("Current_Kind") Then
                                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                Return False
                            End If
                        End If
                    End While
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouDeleteCheckSarmayeh")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouDeleteCheckAmval(ByVal IdFac As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim state As Long = -1
            Using cmd As New SqlCommand("SELECT TOP 1 [State] FROM Get_Pay_Amval WHERE Id =" & IdFac, ConectionBank)
                state = cmd.ExecuteScalar()
            End Using
            Using SearchCommand As New SqlCommand("SELECT ID,Activ,State,Current_State,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=14 AND Number_Type=" & IdFac & ") OR (Current_Type=14 AND Current_Number_Type=" & IdFac & ")", ConectionBank)
                Dim dtr As SqlDataReader = SearchCommand.ExecuteReader
                If dtr.HasRows Then
                    While dtr.Read
                        If dtr("Activ") = 0 Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If dtr("State") <> dtr("Current_State") Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If state = 1 Then
                            If dtr("Kind") <> dtr("Current_Kind") Then
                                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                                Return False
                            End If
                        End If
                    End While
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouDeleteCheckAmval")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function AreYouExsitRelation(ByVal IdFac As Long, ByVal State As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using SearchCommand As New SqlCommand("SELECT ISNULL(COUNT(IdFactor),0) As IdFactor FROM  " & If(State = 0, "PayLimitKharid", "PayLimitFrosh") & " WHERE IdFactor =" & IdFac, ConectionBank)
                Dim count As Long = SearchCommand.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                If count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouExsitRelation")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        End Try
    End Function

    Public Function AreYouDeleteCharge(ByVal IdFac As Long, ByVal State As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using SearchCommand As New SqlCommand("SELECT ID,Activ,State,Current_State,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=" & State & " AND Number_Type=" & IdFac & ") OR (Current_Type=" & State & " AND Current_Number_Type=" & IdFac & ")", ConectionBank)
                Dim dtr As SqlDataReader = SearchCommand.ExecuteReader
                If dtr.HasRows Then
                    While dtr.Read
                        If dtr("Activ") = 0 Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                        If dtr("State") <> dtr("Current_State") Then
                            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                            Return False
                        End If
                    End While
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return True
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouDeleteCharge")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function AreYouChargeFactor(ByVal IdFac As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using SearchCommand As New SqlCommand("SELECT  ISNULL(COUNT(IdFactor),0) FROM  ListFactorCharge WHERE IdFactor =" & IdFac, ConectionBank)
                Dim IdCount As Long = SearchCommand.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdCount
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouChargeFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Public Function AreYouKasriFactor(ByVal IdFac As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using SearchCommand As New SqlCommand("SELECT  ISNULL(COUNT(IdFactor),0) FROM  ListKasriFactor WHERE IdFactor =" & IdFac, ConectionBank)
                Dim IdCount As Long = SearchCommand.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdCount
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouKasriFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Public Function AreYouBackFactor(ByVal IdFac As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using SearchCommand As New SqlCommand("SELECT ISNULL(COUNT(IdFacSell),0) FROM  ListFactorBackSell WHERE IdFacSell =" & IdFac, ConectionBank)
                Dim IdCount As Long = SearchCommand.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdCount
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouBackFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Public Function AreYouExitFactor(ByVal IdFac As Long) As Long
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using SearchCommand As New SqlCommand("SELECT ISNULL(COUNT(IdFactor),0) As EFac FROM ListExitFactor WHERE IdFactor =" & IdFac, ConectionBank)
                Dim IdCount As Long = SearchCommand.ExecuteScalar
                If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                Return IdCount
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouExitFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return -1
        End Try
    End Function

    Public Function DelFactor(ByVal IdFac As Long, ByVal state As Long) As Boolean

        Dim str As String = ListKalaFactor(state, IdFac)

        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ''''''''''''''''''''''''''''''''''''''''
            If state = 3 Or state = 7 Then
                Using cmd As New SqlCommand("UPDATE  Mobile_ListFactorSell SET [Confirm]=0,Disc=N'فاکتور حذف شد',IdSell=NULL WHERE IdSell =" & IdFac, ConectionBank)
                    cmd.ExecuteNonQuery()
                End Using
            End If
            ''''''''''''''''''''''''''''''''''''''''

            If state <> 6 And state <> 7 Then
                ''''''''''''''''''''''حذف چک
                dta = New SqlDataAdapter("SELECT ID,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=" & state & " AND Number_Type=" & IdFac & ") OR (Current_Type=" & state & " AND Current_Number_Type=" & IdFac & ")", ConectionBank)
                dta.Fill(ds)
                For i As Integer = 0 To ds.Rows.Count - 1
                    If ds.Rows(i).Item("Kind") = ds.Rows(i).Item("Current_Kind") Then
                        Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                            Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                            Cmd.ExecuteNonQuery()
                        End Using
                    Else
                        Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                            Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                            Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                            Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                            Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                            Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                            Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
                dta.Dispose()
                ds.Dispose()
            End If
            '''''''''''''''''''''حذف فاکتور
            If state <> 6 And state <> 7 Then
                ds.Clear()
                dta = New SqlDataAdapter("SELECT IDSanadAdd,IDSanadDec,IDSanadDiscountH,IDSanadDiscountC,IDSanadCash,IDSanadHavaleh,IDSanadChk,IdBox,IdBank,IDSanadFactor FROM " & GetTableNameFactor(state, "LIST") & " WHERE IdFactor=" & IdFac, ConectionBank)
                dta.Fill(ds)
            End If
            Using Cmd As New SqlCommand("DELETE FROM  " & GetTableNameFactor(state, "LIST") & "  WHERE IDFactor=@IDFactor", ConectionBank)
                Cmd.Parameters.AddWithValue("@IDFactor", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using
            '''''''''''''''''''''حذف معین
            If state <> 6 And state <> 7 Then
                If ds.Rows.Count > 0 Then
                    Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE (ID=@IDSanadAdd OR ID=@IDSanadDec OR ID=@IDSanadDiscountH OR ID=@IDSanadDiscountC OR ID=@IDSanadCash OR ID=@IDSanadHavaleh OR ID=@IDSanadChk OR ID=@IDSanadFactor);DELETE FROM Moein_Bank WHERE (ID=@IDBank);DELETE FROM Moein_Box WHERE (ID=@IdBox)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IDSanadAdd", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadAdd")
                        Cmd.Parameters.AddWithValue("@IDSanadDec", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadDec")
                        Cmd.Parameters.AddWithValue("@IDSanadDiscountH", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadDiscountH")
                        Cmd.Parameters.AddWithValue("@IDSanadDiscountC", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadDiscountC")
                        Cmd.Parameters.AddWithValue("@IDSanadCash", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadCash")
                        Cmd.Parameters.AddWithValue("@IDSanadHavaleh", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadHavaleh")
                        Cmd.Parameters.AddWithValue("@IDSanadChk", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadChk")
                        Cmd.Parameters.AddWithValue("@IDSanadFactor", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadFactor")
                        Cmd.Parameters.AddWithValue("@IdBank", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBank")
                        Cmd.Parameters.AddWithValue("@IdBox", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBox")
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            End If

            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "مدیریت فاکتور", "حذف", "حذف فاکتور " & GetTypeFactor(state) & ":" & IdFac, str)
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DelFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function DelSanad(ByVal IdFac As Long, ByVal state As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ''''''''''''''''''''''حذف چک
            dta = New SqlDataAdapter("SELECT ID,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=" & state & " AND Number_Type=" & IdFac & ") OR (Current_Type=" & state & " AND Current_Number_Type=" & IdFac & ")", ConectionBank)
            dta.Fill(ds)
            For i As Integer = 0 To ds.Rows.Count - 1
                If ds.Rows(i).Item("Kind") = ds.Rows(i).Item("Current_Kind") Then
                    Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                        Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            Next



            dta.Dispose()
            ds.Dispose()
            '''''''''''''''''''''حذف سند
            ds.Clear()
            dta = New SqlDataAdapter("SELECT IDSanadDiscount,IDSanadCash,IDSanadHavaleh,IDSanadChk,IdBoxMoein,IdBankMoein FROM Get_Pay_Sanad WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)
            Using Cmd As New SqlCommand("DELETE FROM  Get_Pay_Sanad  WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using
            '''''''''''''''''''''حذف معین
            If ds.Rows.Count > 0 Then
                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE (ID=@IDSanadDiscount OR ID=@IDSanadCash OR ID=@IDSanadHavaleh OR ID=@IDSanadChk);DELETE FROM Moein_Bank WHERE (ID=@IDBankMoein);DELETE FROM Moein_Box WHERE (ID=@IdBoxMoein)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IDSanadDiscount", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadDiscount")
                    Cmd.Parameters.AddWithValue("@IDSanadCash", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadCash")
                    Cmd.Parameters.AddWithValue("@IDSanadHavaleh", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadHavaleh")
                    Cmd.Parameters.AddWithValue("@IDSanadChk", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadChk")
                    Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBankMoein")
                    Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBoxMoein")
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '''''''''''''''''''''
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DelSanad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function
    Public Function DelSarmayeh(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ''''''''''''''''''''''حذف چک
            dta = New SqlDataAdapter("SELECT ID,Kind,Current_Kind,Type,Number_Type FROM Chk_Get_Pay WHERE (Type=21 AND Number_Type=" & IdFac & ") OR (Current_Type=21 AND Current_Number_Type=" & IdFac & ")", ConectionBank)
            dta.Fill(ds)
            For i As Integer = 0 To ds.Rows.Count - 1
                If ds.Rows(i).Item("Kind") = ds.Rows(i).Item("Current_Kind") Then
                    Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople,Idsarmayeh=@Idsarmayeh  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                        Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@Idsarmayeh", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.ExecuteNonQuery()
                    End Using

                    If ds.Rows(i).Item("Type") = 21 Then
                        Dim Idsarmayeh As Long = 0
                        Using Cmd As New SqlCommand("SELECT  IdSarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=@Id", ConectionBank)
                            Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = ds.Rows(i).Item("Number_Type")
                            Idsarmayeh = Cmd.ExecuteScalar
                        End Using
                        Using Cmd As New SqlCommand("Update Chk_Id SET Idsarmayeh=@Idsarmayeh   WHERE Id=@IDAuto ", ConectionBank)
                            Cmd.Parameters.AddWithValue("@Idsarmayeh", SqlDbType.BigInt).Value = IIf(Idsarmayeh = 0, DBNull.Value, Idsarmayeh)
                            Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                End If
            Next
            dta.Dispose()
            ds.Dispose()
            '''''''''''''''''''''حذف سند
            ds.Clear()
            dta = New SqlDataAdapter("SELECT IDSanadLendP,IdBoxMoein,IdBankMoein FROM Get_Pay_Sarmayeh WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)
            Using Cmd As New SqlCommand("DELETE FROM  Get_Pay_Sarmayeh  WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using
            '''''''''''''''''''''حذف معین
            If ds.Rows.Count > 0 Then
                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE ID=@IDSanadLendP ;DELETE FROM Moein_Bank WHERE ID=@IDBankMoein;DELETE FROM Moein_Box WHERE ID=@IdBoxMoein", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IDSanadLendP", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadLendP")
                    Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBankMoein")
                    Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBoxMoein")
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '''''''''''''''''''''
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DelSarmayeh")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function DelAmval(ByVal IdFac As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ''''''''''''''''''''''حذف چک
            dta = New SqlDataAdapter("SELECT ID,Kind,Current_Kind,Type,Number_Type FROM Chk_Get_Pay WHERE (Type=14 AND Number_Type=" & IdFac & ") OR (Current_Type=14 AND Current_Number_Type=" & IdFac & ")", ConectionBank)
            dta.Fill(ds)
            For i As Integer = 0 To ds.Rows.Count - 1
                If ds.Rows(i).Item("Kind") = ds.Rows(i).Item("Current_Kind") Then
                    Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople,IdAmval=@IdAmval  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                        Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.ExecuteNonQuery()
                    End Using
                    If ds.Rows(i).Item("Type") = 14 Then
                        Dim IdAmval As Long = 0
                        Using Cmd As New SqlCommand("SELECT  IdAmval  FROM Get_Pay_Amval  WHERE Id=@Id", ConectionBank)
                            Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = ds.Rows(i).Item("Number_Type")
                            IdAmval = Cmd.ExecuteScalar
                        End Using
                        Using Cmd As New SqlCommand("Update Chk_Id SET IdAmval=@IdAmval   WHERE Id=@IDAuto ", ConectionBank)
                            Cmd.Parameters.AddWithValue("@IdAmval", SqlDbType.BigInt).Value = IIf(IdAmval = 0, DBNull.Value, IdAmval)
                            Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                End If
            Next
            dta.Dispose()
            ds.Dispose()
            '''''''''''''''''''''حذف سند
            ds.Clear()
            dta = New SqlDataAdapter("SELECT IDSanadLendP,IdBoxMoein,IdBankMoein FROM Get_Pay_Amval WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)
            Using Cmd As New SqlCommand("DELETE FROM  Get_Pay_Amval  WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using
            '''''''''''''''''''''حذف معین
            If ds.Rows.Count > 0 Then
                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE ID=@IDSanadLendP ;DELETE FROM Moein_Bank WHERE ID=@IDBankMoein;DELETE FROM Moein_Box WHERE ID=@IdBoxMoein", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IDSanadLendP", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadLendP")
                    Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBankMoein")
                    Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBoxMoein")
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '''''''''''''''''''''
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DelAmval")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function DelDramad(ByVal IdFac As Long, ByVal state As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ''''''''''''''''''''''حذف چک
            dta = New SqlDataAdapter("SELECT ID,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=" & state & " AND Number_Type=" & IdFac & ") OR (Current_Type=" & state & " AND Current_Number_Type=" & IdFac & ")", ConectionBank)
            dta.Fill(ds)
            For i As Integer = 0 To ds.Rows.Count - 1
                If ds.Rows(i).Item("Kind") = ds.Rows(i).Item("Current_Kind") Then
                    Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                        Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            Next
            dta.Dispose()
            ds.Dispose()
            '''''''''''''''''''''حذف سند
            ds.Clear()
            dta = New SqlDataAdapter("SELECT IDSanadLend,IdBoxMoein,IdBankMoein FROM Get_Daramad WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)
            Using Cmd As New SqlCommand("DELETE FROM  Get_Daramad  WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using
            '''''''''''''''''''''حذف معین
            If ds.Rows.Count > 0 Then
                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE ID=@IDSanadLend ;DELETE FROM Moein_Bank WHERE ID=@IDBankMoein;DELETE FROM Moein_Box WHERE ID=@IdBoxMoein", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IDSanadLend", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadLend")
                    Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBankMoein")
                    Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBoxMoein")
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '''''''''''''''''''''
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DelDramad")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function DelSanadCharge(ByVal IdFac As Long, ByVal state As Long) As Boolean
        Dim ds As New DataTable
        Dim dta As New SqlDataAdapter()
        If Not dta Is Nothing Then dta.Dispose()
        Dim sqltransaction As New CommittableTransaction
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            ConectionBank.EnlistTransaction(sqltransaction)
            ''''''''''''''''''''''حذف چک
            dta = New SqlDataAdapter("SELECT ID,Kind,Current_Kind FROM Chk_Get_Pay WHERE (Type=" & state & " AND Number_Type=" & IdFac & ") OR (Current_Type=" & state & " AND Current_Number_Type=" & IdFac & ")", ConectionBank)
            dta.Fill(ds)
            For i As Integer = 0 To ds.Rows.Count - 1
                If ds.Rows(i).Item("Kind") = ds.Rows(i).Item("Current_Kind") Then
                    Using Cmd As New SqlCommand("DELETE FROM  Chk_state WHERE ID=@ID;DELETE FROM  Chk_Id WHERE ID=@ID;DELETE FROM  Chk_Get_Pay  WHERE ID=@ID;", ConectionBank)
                        Cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using Cmd As New SqlCommand("Update  Chk_Get_Pay SET Current_Type=[Type],Current_Number_Type=[Number_Type],Current_Kind=Kind,Current_Type_Chk=Type_Chk,IdUser=@IdUser WHERE Id=@IDAuto ; Update Chk_Id SET Current_IdPeople=IdPeople  WHERE Id=@IDAuto ; INSERT INTO Chk_State (Id,D_Date,Current_State,Disc,TmpId,IdUser) values(@IDAuto ,@D_Date,@Current_State,@Disc,@TmpId,@IdUser)", ConectionBank)
                        Cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = Id_User
                        Cmd.Parameters.AddWithValue("@IDAuto", SqlDbType.BigInt).Value = ds.Rows(i).Item("Id")
                        Cmd.Parameters.AddWithValue("@D_Date", SqlDbType.BigInt).Value = GetDate()
                        Cmd.Parameters.AddWithValue("@Current_State", SqlDbType.BigInt).Value = 0
                        Cmd.Parameters.AddWithValue("@Disc", SqlDbType.NVarChar).Value = "تغییر وضعیت از خرج شده به اسناد دریافتی"
                        Cmd.Parameters.AddWithValue("@TmpId", SqlDbType.BigInt).Value = DBNull.Value
                        Cmd.ExecuteNonQuery()
                    End Using
                End If
            Next
            dta.Dispose()
            ds.Dispose()
            '''''''''''''''''''''حذف سند
            ds.Clear()
            dta = New SqlDataAdapter("SELECT IDSanadLend,IdBoxMoein,IdBankMoein FROM " & If(state = 16, "ListOtherCharge", "ListFactorCharge") & " WHERE Id=" & IdFac, ConectionBank)
            dta.Fill(ds)
            Using Cmd As New SqlCommand("DELETE FROM  " & If(state = 16, "ListOtherCharge", "ListFactorCharge") & "  WHERE ID=@ID", ConectionBank)
                Cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = IdFac
                Cmd.ExecuteNonQuery()
            End Using
            '''''''''''''''''''''حذف معین
            If ds.Rows.Count > 0 Then
                Using Cmd As New SqlCommand("DELETE FROM Moein_People WHERE (ID=@IDSanadLend);DELETE FROM Moein_Bank WHERE (ID=@IDBankMoein);DELETE FROM Moein_Box WHERE (ID=@IdBoxMoein)", ConectionBank)
                    Cmd.Parameters.AddWithValue("@IDSanadLend", SqlDbType.BigInt).Value = ds.Rows(0).Item("IDSanadLend")
                    Cmd.Parameters.AddWithValue("@IdBankMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBankMoein")
                    Cmd.Parameters.AddWithValue("@IdBoxMoein", SqlDbType.BigInt).Value = ds.Rows(0).Item("IdBoxMoein")
                    Cmd.ExecuteNonQuery()
                End Using
            End If
            '''''''''''''''''''''
            sqltransaction.Commit()
            sqltransaction.Dispose()
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            sqltransaction.Rollback()
            sqltransaction.Dispose()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DelSanadCharge")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function GetStateFactor(ByVal Nam As String) As Long
        Try
            If Nam = "خرید" Then
                Return 0
            ElseIf Nam = "برگشت از خرید" Then
                Return 1
            ElseIf Nam = "خرید امانی" Then
                Return 2
            ElseIf Nam = "فروش" Then
                Return 3
            ElseIf Nam = "برگشت از فروش" Then
                Return 4
            ElseIf Nam = "فروش امانی" Then
                Return 5
            ElseIf Nam = "ضایعات" Then
                Return 6
            ElseIf Nam = "پیش فاکتور" Then
                Return 7
            ElseIf Nam = "خدمات" Then
                Return 8
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetTypeFactor(ByVal state As Long) As String
        Try
            If state = 0 Then
                Return "خرید"
            ElseIf state = 1 Then
                Return "برگشت از خرید"
            ElseIf state = 2 Then
                Return "خرید امانی"
            ElseIf state = 3 Then
                Return "فروش"
            ElseIf state = 4 Then
                Return "برگشت از فروش"
            ElseIf state = 5 Then
                Return "فروش امانی"
            ElseIf state = 6 Then
                Return "ضایعات"
            ElseIf state = 7 Then
                Return "پیش فاکتور"
            ElseIf state = 8 Then
                Return "خدمات"
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GetTableNameFactor(ByVal state As Long, ByVal Kind As String) As String
        Try
            If state = 0 Or state = 2 Then
                If Kind = "LIST" Then
                    Return "ListFactorBuy"
                ElseIf Kind = "KALA" Then
                    Return "KalaFactorBuy"
                End If
            ElseIf state = 1 Then
                If Kind = "LIST" Then
                    Return "ListFactorBackBuy"
                ElseIf Kind = "KALA" Then
                    Return "KalaFactorBackBuy"
                End If
            ElseIf state = 3 Or state = 5 Or state = 7 Then
                If Kind = "LIST" Then
                    Return "ListFactorSell"
                ElseIf Kind = "KALA" Then
                    Return "KalaFactorSell"
                End If
            ElseIf state = 4 Then
                If Kind = "LIST" Then
                    Return "ListFactorBackSell"
                ElseIf Kind = "KALA" Then
                    Return "KalaFactorBackSell"
                End If
            ElseIf state = 6 Then
                If Kind = "LIST" Then
                    Return "ListFactorDamage"
                ElseIf Kind = "KALA" Then
                    Return "KalaFactorDamage"
                End If
            ElseIf state = 8 Then
                If Kind = "LIST" Then
                    Return "ListFactorService"
                ElseIf Kind = "KALA" Then
                    Return "KalaFactorService"
                End If
            End If
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GetMoeinPeople(ByVal Id As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinPeopleId")
            Return 0
        End Try
    End Function

    Public Function GetMoeinPeople(ByVal Id As Long, ByVal Sanad As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0 AND Id<" & Sanad & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1 AND Id<" & Sanad & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinPeopleSanad")
            Return 0
        End Try
    End Function
    Public Function GetMoeinPeople(ByVal Id As Long, ByVal Sanad As Long, ByVal Dat As String, ByVal Type As Long, ByVal Fac As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0  AND D_Date<=N'" & Dat & "' AND Not([Type] =" & Type & " And Number_Type =" & Fac & ") AND NOT (D_Date=N'" & Dat & "' AND Id>" & Sanad & ") ) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1  AND D_Date<=N'" & Dat & "' AND Not([Type] =" & Type & " And Number_Type =" & Fac & ") AND NOT (D_Date=N'" & Dat & "' AND Id>" & Sanad & ")  ) AS Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinPeopleSanadDate")
            Return 0
        End Try
    End Function

    Public Function GetOldTime(ByVal Id As Long, ByVal Sanad As Long, ByVal Dat As String, ByVal Type As Long, ByVal Fac As Long) As String
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT ISNULL(MAX(D_Date),'') As D_Date FROM Moein_People WHERE IDPeople =" & Id & "  AND D_Date<=N'" & Dat & "' AND Not([Type] =" & Type & " And Number_Type =" & Fac & ") AND NOT (D_Date=N'" & Dat & "' AND Id>" & Sanad & ")", ConectionBank)
                Dim Res As String = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetOldTime")
            Return ""
        End Try
    End Function

    Public Function GetMoeinPeopleDate(ByVal Id As Long, ByVal Dat As String, ByVal eq As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0 AND D_Date<" & eq & "'" & Dat & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1 AND D_Date<" & eq & "'" & Dat & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinPeopleDate")
            Return 0
        End Try
    End Function

    Public Function GetMoeinPeopleSanad(ByVal Id As Long, ByVal IDS As String, ByVal eq As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0 AND Id<" & eq & IDS & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1 AND Id<" & eq & IDS & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinPeopleSanad")
            Return 0
        End Try
    End Function

    Public Sub SetMoeinPeopleVarible(ByVal IdFac As Long, ByVal State As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT MAX(ASanad.Sanad) AS Big,MIN(ASanad.Sanad) AS Small,idname FROM (SELECT idsanadDec AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT idsanadAdd AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT IdSanadDiscountH  AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT IdSanadDiscountC  AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT idsanadcash AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT idsanadchk AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT IdSanadHavaleh  AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " UNION SELECT IdSanadFactor  AS Sanad FROM " & GetTableNameFactor(State, "LIST") & " WHERE IdFactor =" & IdFac & " ) As ASanad," & GetTableNameFactor(State, "LIST") & " WHERE " & GetTableNameFactor(State, "LIST") & " .IdFactor =" & IdFac & " GROUP BY IdName", ConectionBank)
                Dim dtr As SqlDataReader = Nothing
                dtr = CMD.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    IdKala = dtr("idname")
                    OldSanad = If(dtr("Small") Is DBNull.Value, 0, dtr("Small"))
                    CurSanad = If(dtr("Big") Is DBNull.Value, 0, dtr("Big"))
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetMoeinPeopleVarible")
        End Try
    End Sub
    Public Sub SetMoeinPeopleVaribleGetpay(ByVal IdFac As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT MAX(ASanad.Sanad) AS Big,MIN(ASanad.Sanad) AS Small,idname FROM (SELECT IdSanadDiscount AS Sanad FROM Get_Pay_Sanad WHERE Id =" & IdFac & " UNION SELECT IdSanadCash AS Sanad FROM Get_Pay_Sanad WHERE Id =" & IdFac & " UNION SELECT IdSanadChk  AS Sanad FROM Get_Pay_Sanad WHERE Id =" & IdFac & " UNION SELECT IdSanadHavaleh  AS Sanad FROM Get_Pay_Sanad WHERE Id =" & IdFac & " ) As ASanad,Get_Pay_Sanad WHERE Get_Pay_Sanad.Id=" & IdFac & " GROUP BY IdName", ConectionBank)
                Dim dtr As SqlDataReader = Nothing
                dtr = CMD.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    IdKala = dtr("idname")
                    OldSanad = dtr("Small")
                    CurSanad = dtr("Big")
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetMoeinPeopleVaribleGetpay")
        End Try
    End Sub
    Public Sub SetMoeinPeopleVariblePTPBed(ByVal IdFac As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT IdSanadBed AS Sanad,IdNameBed FROM Sanad_PTP WHERE Id =" & IdFac, ConectionBank)
                Dim dtr As SqlDataReader = Nothing
                dtr = CMD.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    IdKala = dtr("IdNameBed")
                    OldSanad = dtr("Sanad")
                    CurSanad = dtr("Sanad")
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetMoeinPeopleVariblePTPBed")
        End Try
    End Sub

    Public Sub SetMoeinPeopleVariblePTPBes(ByVal IdFac As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT IdSanadBes AS Sanad,IdNameBes FROM Sanad_PTP WHERE Id =" & IdFac, ConectionBank)
                Dim dtr As SqlDataReader = Nothing
                dtr = CMD.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    IdKala = dtr("IdNameBes")
                    OldSanad = dtr("Sanad")
                    CurSanad = dtr("Sanad")
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetMoeinPeopleVariblePTPBes")
        End Try
    End Sub
    Public Function GetValuePeople(ByVal Id As Long) As Double
        Try
            Dim str As String = "SELECT GChk.GetChk,PChk.PayChk,People .Moein,Rate.GValue ,Rate .GValueMon FROM (SELECT  ISNULL(SUM(MoneyChk),0) As GetChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =0 and (Current_State =0 or Current_State =4)  AND Current_IdPeople =" & Id & ") As GChk,(SELECT  ISNULL(SUM(MoneyChk),0) As PayChk FROM  Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id WHERE   Activ =1 AND Kind =1 and (Current_State =0 )  AND Current_IdPeople =" & Id & ") As PChk,(SELECT SUM(OnMoney+bed+bes) AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_People WHERE IDPeople =" & Id & " AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_People WHERE IDPeople =" & Id & " AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney= CASE [State] WHEN N'بستانکار' THEN Allmoney *(-1) WHEN N'بدهکار' THEN Allmoney Else  0 End FROM Define_People WHERE Id=" & Id & " )As AllOneMoney )As One)AS People,(SELECT GValue=CASE WHEN GroupValue =0 THEN GValue ELSE GroupValue END ,GValueMon=CASE WHEN GroupValue =0 THEN GValueMon ELSE CASE WHEN GroupPeople=1 AND GValue =1 THEN GValueMon ELSE GroupValueMon END END FROM(SELECT Gvalue,GvalueMon,GroupPeople,GroupValue,GroupValueMon From Define_People INNER JOIN Define_Group_P ON Define_Group_P.Id =Define_People.IdGroup WHERE Define_People.ID=" & Id & ") AS GV)As Rate"
            Dim Dtr As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim res As Double = 0
            Using cmd As New SqlCommand(str, ConectionBank)
                Dtr = cmd.ExecuteReader
                If Dtr.HasRows Then
                    Dtr.Read()
                    If Dtr("GValue") = True Then
                        If Dtr("Moein") >= 0 Then
                            res = Dtr("GValueMon") - (Dtr("Moein") + Dtr("GetChk") - (Dtr("PayChk")))
                        Else
                            res = Dtr("GValueMon") + (((Dtr("Moein") * (-1)) + (Dtr("PayChk")) - Dtr("GetChk")))
                        End If
                    Else
                        res = 0.5
                    End If
                Else
                    res = 0.5
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return res
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetValuePeople")
            Return 0.5
        End Try
    End Function
    Public Function GetBedFac(ByVal Idkala As Long, ByVal Kind As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim Sql_Str As String = ""
            If Kind = "F" Then
                Sql_Str = "SELECT LendMon  FROM(SELECT AllFactorSell.*,LendMon=CASE WHEN  (AllFactorSell.MonFac -AllFactorSell.Discount -AllFactorSell.DarsadMon-AllFactorSell.Cash -AllFactorSell.MonHavaleh -AllFactorSell.ChkMon) < 0 THEN 0 Else (AllFactorSell.MonFac -AllFactorSell.Discount -AllFactorSell.DarsadMon-AllFactorSell.Cash -AllFactorSell.MonHavaleh -AllFactorSell.ChkMon)End FROM (SELECT  ListFactorSell.MonAdd,ListFactorSell.MonDec,ListFactorSell.IdName,ListFactorSell.IdFactor,Kind=N'فروش', ListFactorSell.D_date, ListFactorSell.Sanad, ListFactorSell.Part, ListFactorSell.Disc, ListFactorSell.Discount, ListFactorSell.Cash, ListFactorSell.MonHavaleh, (ListFactorSell.MonPayChk) As ChkMon, Define_People.Nam As Pname, Define_User.Nam AS UName,((SELECT ISNULL(SUM(KalaFactorSell.Mon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)+ListFactorSell.MonAdd -ListFactorSell.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorSell.DarsadMon ),0)  FROM KalaFactorSell WHERE IdFactor =ListFactorSell.IdFactor)As DarsadMon FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_User ON ListFactorSell.IdUser = Define_User.Id WHERE ListFactorSell.Activ =1  AND ListFactorSell.Stat =3 AND IdUser <>0)As AllFactorSell)AllSell WHERE (IdFactor=@IdFactor)"
            ElseIf Kind = "K" Then
                Sql_Str = "SELECT LendMon  FROM(SELECT AllFactorBuy.*,LendMon=CASE WHEN  (AllFactorBuy.MonFac -AllFactorBuy.Discount -AllFactorBuy.DarsadMon-AllFactorBuy.Cash -AllFactorBuy.MonHavaleh -AllFactorBuy.ChkMon) < 0 THEN 0 Else (AllFactorBuy.MonFac -AllFactorBuy.Discount -AllFactorBuy.DarsadMon-AllFactorBuy.Cash -AllFactorBuy.MonHavaleh -AllFactorBuy.ChkMon)End FROM (SELECT  ListFactorBuy.MonAdd,ListFactorBuy.MonDec,ListFactorBuy.IdName,ListFactorBuy.IdFactor,Kind=N'خرید', ListFactorBuy.D_date, ListFactorBuy.Sanad, ListFactorBuy.Part, ListFactorBuy.Disc, ListFactorBuy.Discount, ListFactorBuy.Cash, ListFactorBuy.MonHavaleh, (ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) As ChkMon, Define_People.Nam As Pname, Define_User.Nam AS UName,((SELECT ISNULL(SUM(KalaFactorBuy.Mon ),0)  FROM KalaFactorBuy WHERE IdFactor =ListFactorBuy.IdFactor)+ListFactorBuy.MonAdd -ListFactorBuy.MonDec)As MonFac,(SELECT ISNULL(SUM(KalaFactorBuy.DarsadMon ),0)  FROM KalaFactorBuy WHERE IdFactor =ListFactorBuy.IdFactor)As DarsadMon FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_User ON ListFactorBuy.IdUser = Define_User.Id WHERE ListFactorBuy.Activ =1  AND ListFactorBuy.Stat =0 AND IdUser <>0)As AllFactorBuy)AllBuy WHERE (IdFactor=@IdFactor)"
            End If
            Using Cmd As New SqlCommand(Sql_Str, ConectionBank)
                Cmd.Parameters.AddWithValue("@IdFactor", SqlDbType.BigInt).Value = Idkala
                Dim dt As New DataTable
                dt.Clear()
                dt.Load(Cmd.ExecuteReader)
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item("LendMon")
                Else
                    Return 0
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetBedFac")
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return 0
        End Try
    End Function

    Public Sub SetBedBesTableMoein(ByRef Dt As DataTable)
        Try
            Dim Oldmon As Double = 0
            Dim Newmon As Double = 0
            For i As Integer = 0 To Dt.Rows.Count - 1
                If i = 0 Then
                    Oldmon = 0
                Else
                    Oldmon = Dt.Rows(i - 1).Item("Mandeh")
                End If
                Newmon = If(Dt.Rows(i).Item("BedMon") > 0, Dt.Rows(i).Item("BedMon"), Dt.Rows(i).Item("BesMon") * (-1))

                If Dt.Rows(i).Item("BedMon") > 0 And Dt.Rows(i).Item("BesMon") = 0 Then
                    Newmon = Dt.Rows(i).Item("BedMon")
                ElseIf Dt.Rows(i).Item("BedMon") = 0 And Dt.Rows(i).Item("BesMon") > 0 Then
                    Newmon = Dt.Rows(i).Item("BesMon") * (-1)
                ElseIf Dt.Rows(i).Item("BedMon") > 0 And Dt.Rows(i).Item("BesMon") > 0 Then
                    Newmon = Dt.Rows(i).Item("BedMon") + (Dt.Rows(i).Item("BesMon") * (-1))
                End If

                Dt.Rows(i).Item("Mandeh") = Newmon + Oldmon
                Dt.Rows(i).Item("T") = If(Dt.Rows(i).Item("Mandeh") >= 0, "بد", "بس")
            Next
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item("Mandeh") < 0 Then
                    Dt.Rows(i).Item("Mandeh") = Dt.Rows(i).Item("Mandeh") * (-1)
                End If
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetBedBesTableMoein")
        End Try
    End Sub

    Public Sub SetBedBesTableKardex(ByRef Dt As DataTable)
        Try
            Dim OldKol As Double = 0
            Dim OldJoz As Double = 0
            Dim NewKol As Double = 0
            Dim NewJoz As Double = 0
            For i As Integer = 0 To Dt.Rows.Count - 1
                If i = 0 Then
                    OldKol = 0
                    OldJoz = 0
                Else
                    OldKol = Dt.Rows(i - 1).Item("KolMandeh")
                    OldJoz = Dt.Rows(i - 1).Item("JozMandeh")
                End If
                '''''NewKol
                If Dt.Rows(i).Item("InKol") > 0 And Dt.Rows(i).Item("OutKol") = 0 Then
                    NewKol = Dt.Rows(i).Item("InKol")
                ElseIf Dt.Rows(i).Item("InKol") = 0 And Dt.Rows(i).Item("OutKol") > 0 Then
                    NewKol = Dt.Rows(i).Item("OutKol") * (-1)
                ElseIf Dt.Rows(i).Item("InKol") > 0 And Dt.Rows(i).Item("OutKol") > 0 Then
                    NewKol = Dt.Rows(i).Item("InKol") + (Dt.Rows(i).Item("OutKol") * (-1))
                End If
                '''''NewJoz
                If Dt.Rows(i).Item("InJoz") > 0 And Dt.Rows(i).Item("OutJoz") = 0 Then
                    NewJoz = Dt.Rows(i).Item("InJoz")
                ElseIf Dt.Rows(i).Item("InJoz") = 0 And Dt.Rows(i).Item("OutJoz") > 0 Then
                    NewJoz = Dt.Rows(i).Item("OutJoz") * (-1)
                ElseIf Dt.Rows(i).Item("InJoz") > 0 And Dt.Rows(i).Item("OutJoz") > 0 Then
                    NewJoz = Dt.Rows(i).Item("InJoz") + (Dt.Rows(i).Item("OutJoz") * (-1))
                End If
                Dt.Rows(i).Item("KolMandeh") = NewKol + OldKol
                Dt.Rows(i).Item("JozMandeh") = NewJoz + OldJoz
            Next
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetBedBesTableKardex")
        End Try
    End Sub

    Public Function GetMoeinBoxDate(ByVal Id As Long, ByVal Dat As String, ByVal eq As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Box WHERE IDBox =" & Id & " AND T=0 AND D_Date<" & eq & "'" & Dat & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Box WHERE IDBox =" & Id & " AND T=1 AND D_Date<" & eq & "'" & Dat & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Box WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinBoxDate")
            Return 0
        End Try
    End Function
    Public Function GetMoeinBoxSanad(ByVal Id As Long, ByVal IdS As Long, ByVal eq As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Box WHERE IDBox =" & Id & " AND T=0 AND Id<" & eq & IdS & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Box WHERE IDBox =" & Id & " AND T=1 AND Id<" & eq & IdS & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Box WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinBoxSanad")
            Return 0
        End Try
    End Function

    Public Function GetMoeinBox(ByVal Id As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT (SUM(OnMoney+bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_BOX WHERE IDBOX =" & Id & " AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_BOX WHERE IDBOX =" & Id & " AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_box WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinBoxId")
            Return 0
        End Try
    End Function

    Public Function GetMoeinBankDate(ByVal Id As Long, ByVal Dat As String, ByVal eq As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBank =" & Id & " AND T=0 AND D_Date<" & eq & "'" & Dat & "') AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE IDBank =" & Id & " AND T=1 AND D_Date<" & eq & "'" & Dat & "') As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinBankDate")
            Return 0
        End Try
    End Function

    Public Function GetMoeinBankSanad(ByVal Id As Long, ByVal IdS As String, ByVal eq As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT SUM(OnMoney+bed+bes) AS Moein FROM(SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBank =" & Id & " AND T=0 AND Id<" & eq & IdS & ") AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE IDBank =" & Id & " AND T=1 AND Id<" & eq & IdS & ") As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinBankSanad")
            Return 0
        End Try
    End Function

    Public Function GetMoeinBank(ByVal Id As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT (SUM(OnMoney+bed+bes))AS Moein FROM (SELECT ISNULL(SUM(MON),0) AS BED FROM Moein_Bank WHERE IDBank =" & Id & " AND T=0) AS Bed,(SELECT ISNULL(SUM(MON),0)*(-1) AS BES FROM Moein_Bank WHERE IDBank =" & Id & " AND T=1) As Bes,(SELECT ISNULL(SUM(AllOneMoney.Allmoney),0) As OnMoney FROM (SELECT  Allmoney FROM Define_Bank WHERE Id=" & Id & " )As AllOneMoney )As One", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetMoeinBankId")
            Return 0
        End Try
    End Function
    Public Function GetCostKalaWithDiscount(ByVal Id As Long, ByVal Co As Double, ByVal Kind As String, ByVal Dat1 As String, ByVal Dat2 As String, ByVal Discount As String) As Double
        Try
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            'Using CMD As New SqlCommand("SELECT ISNULL(AVG(Fe-(DarsadMon /(Case  WHEN JozCount>0 THEN JozCount ELSE KolCount END))),0) AS Cost FROM (SELECT Top 2 AllKala.* FROM (SELECT   KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe,KalaFactorBuy.DarsadMon, ListFactorBuy.D_date FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 And ListFactorBuy .Activ =1 And ListFactorBuy .Stat  =0) And IdKala =" & Id & " UNION ALL SELECT Count_Kol AS KolCount,Count_Joz As JozCount,Fe,DarsadMon=0,D_date  FROM Define_PrimaryKala WHERE IdKala =" & Id & ")AS AllKala Order by D_date Desc ) As AllTKala", ConectionBank)
            Using CMD As New SqlCommand("SELECT dbo.GetCostCharge(" & Id & "," & Co & ",'" & Kind & "','" & Dat1 & "','" & Dat2 & "','" & Discount & "')", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCostKalaWithDiscount")
            Return 0
        End Try
    End Function

    Public Function AreYouNativeKala(ByVal Id As Long, ByVal Kol As Double, ByVal joz As Double) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT Kol,JOZ  FROM (SELECT ROUND(ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0),2) As KOL  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & ") AS AllKolCount) AS Kol,(SELECT ROUND(ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0),2) As JOZ FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & ") AS AllJozCount ) As JOZ", ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If (dtr("KOL") < Kol) Then 'Or dtr("JOZ") < joz) Then
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        Return False
                    Else
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        Return True
                    End If
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return False
                End If

            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouNativeKala")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function


    Public Function AreYouNativeKalaAnbar(ByVal Id As Long, ByVal Kol As Double, ByVal joz As Double, ByVal IdAnar As Long) As Boolean
        Try
            If (Kol <= 0) Then Return True ' Or joz <= 0) Then Return True

            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Using Cmd As New SqlCommand("SELECT AllKala.*,(SELECT ROUND(ISNULL(SUM(CASE WHEN KolCount>=0 THEN KolCount END),0) + ISNULL(SUM (CASE WHEN KolCount<0 THEN KolCount END),0),2)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID  UNION ALL  SELECT    ISNULL(SUM( Tranlate_Anbar.Kol*(-1)),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Kol),0) AS KolCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllKolCount)KolCount,(SELECT ROUND(ISNULL(SUM(CASE WHEN AllJozCount.JozCount>=0 THEN AllJozCount.JozCount END),0) + ISNULL(SUM (CASE WHEN AllJozCount.JozCount<0 THEN AllJozCount.JozCount END),0),2) FROM (SELECT  ISNULL(SUM(Count_joz),0) AS JozCount FROM  Define_PrimaryKala WHERE IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz *(-1)),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdOneAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( Tranlate_Anbar.Joz ),0) AS JozCount FROM  Tranlate_Anbar WHERE IdKala =" & Id & " AND IdTwoAnbar  =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.JozCount),0) AS JozCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.JozCount),0) AS JozCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.JozCount)*(-1),0) AS JozCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.JozCount)*(-1),0) AS JozCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID UNION ALL SELECT    ISNULL(SUM( KalaFactorDamage.JozCount)*(-1),0) AS JozCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =" & Id & " AND IdAnbar =AllKala .ID) AS AllJozCount)JozCount FROM (SELECT ID FROM Define_Anbar WHERE Id=" & IdAnar & ") AS AllKala", ConectionBank)
                Dim dtr As SqlDataReader = Cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If (dtr("KolCount") < Kol) Then ' Or dtr("JozCount") < joz) Then
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        Return False
                    Else
                        If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                        Return True
                    End If
                Else
                    If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
                    Return False
                End If

            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouNativeKalaAnbar")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function AreYouBackKala(ByVal Id As Long, ByVal idp As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim count As Long = 0
            Using Cmd As New SqlCommand("SELECT Count(IdKala) FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE IdKala =" & Id & " AND IdName =" & idp, ConectionBank)
                count = Cmd.ExecuteScalar
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            If count <= 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouBackKala")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function AreYouExistKalaInFactor(ByVal Id As Long, ByVal idKala As Long) As Boolean
        Try
            If ConectionBank.State = ConnectionState.Closed Then ConectionBank.Open()
            '////////////////////////////////////////
            Dim count As Long = 0
            Using Cmd As New SqlCommand("SELECT Count(IdKala) FROM KalaFactorSell WHERE IdKala =" & idKala & " AND IdFactor =" & Id, ConectionBank)
                count = Cmd.ExecuteScalar
            End Using
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            If count <= 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouExistKalaInFactor")
            If ConectionBank.State = ConnectionState.Open Then ConectionBank.Close()
            Return False
        End Try
    End Function

    Public Function GetCostFrosh(ByVal IdKala As Long, ByVal IdCity As Long, ByVal IdP As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Dim idG As Long = 0
            Using CMD As New SqlCommand("DECLARE @IdG bigint SET @IdG =(SELECT  IdG=CASE WHEN ChkIdGroup ='True' THEN  IdGroup ELSE -1 END FROM Define_People WHERE Id=" & IdP & ") if (@IdG >0 ) SELECT KindCost FROM Define_Group_P WHERE Id =@IdG ELSE SELECT -1", ConectionBank)
                idG = CMD.ExecuteScalar()
            End Using


            Using CMD As New SqlCommand("SELECT CASE WHEN Fe>0 THEN Fe ELSE (SELECT ISNULL(SUM(Fe),0) As Fe FROM (SELECT TOP 1 Fe FROM (SELECT  Fe,KalaFactorSell.IdFactor  FROM KalaFactorSell WHERE  KalaFactorSell.IdKala =" & IdKala & " AND KalaFactorSell.Activ =1 AND KalaFactorSell.Fe >0 ) As ListKala INNER JOIN ListFactorSell On ListFactorSell.IdFactor =ListKala .IdFactor ORDER BY D_date  DESC) AS EndCost) END AS Fe FROM (SELECT ISNULL(SUM(" & If(idG < 0, "CostBigKala", If(idG = 0, "CostSmalKala", If(idG = 1, "CostBigKala", "EndCost"))) & "),0) As Fe FROM (SELECT  TOP 1  " & If(idG < 0, "CostBigKala", If(idG = 0, "CostSmalKala", If(idG = 1, "CostBigKala", "EndCost"))) & "  FROM Define_CostKala WHERE IdCity =" & IdCity & " AND IdKala =" & IdKala & " AND " & If(idG < 0, "CostBigKala", If(idG = 0, "CostSmalKala", If(idG = 1, "CostBigKala", "EndCost"))) & ">0 ORDER BY Id DESC) AS CityFe ) AS ListCost", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCostFrosh")
            Return 0
        End Try
    End Function

    Public Function GetCostFrosh_Barcode(ByVal IdKala As Long, ByVal IdCity As Long, ByVal idp As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            'Using CMD As New SqlCommand("SELECT ISNULL(SUM(Fe),0) As Fe FROM (SELECT Top 1 Fe FROM (SELECT  ISNULL(SUM(EndCost),0) As Fe FROM (SELECT  TOP 1  EndCost  FROM Define_CostKala WHERE IdCity =" & IdCity & " AND IdKala =" & IdKala & " ORDER BY Id DESC) AS CityFe UNION ALL SELECT ISNULL(SUM(Fe),0) As Fe FROM (SELECT TOP 1 Fe FROM (SELECT  Fe,KalaFactorSell.IdFactor  FROM KalaFactorSell WHERE  KalaFactorSell.IdKala =" & IdKala & " AND KalaFactorSell.Activ =1 AND KalaFactorSell.Fe >0 ) As ListKala INNER JOIN ListFactorSell On ListFactorSell.IdFactor =ListKala .IdFactor  ORDER BY D_date  DESC) AS EndCost) As EndFe WHERE Fe>0) As EndCost2", ConectionBank)
            Dim idG As Long = 0
            Using CMD As New SqlCommand("DECLARE @IdG bigint SET @IdG =(SELECT  IdG=CASE WHEN ChkIdGroup ='True' THEN  IdGroup ELSE -1 END FROM Define_People WHERE Id=" & idp & ") if (@IdG >0 ) SELECT KindCost FROM Define_Group_P WHERE Id =@IdG ELSE SELECT -1", ConectionBank)
                idG = CMD.ExecuteScalar()
            End Using


            Using CMD As New SqlCommand("SELECT CASE WHEN Fe>0 THEN Fe ELSE (SELECT ISNULL(SUM(Fe),0) As Fe FROM (SELECT TOP 1 Fe FROM (SELECT  Fe,KalaFactorSell.IdFactor  FROM KalaFactorSell WHERE  KalaFactorSell.IdKala =" & IdKala & " AND KalaFactorSell.Activ =1 AND KalaFactorSell.Fe >0 ) As ListKala INNER JOIN ListFactorSell On ListFactorSell.IdFactor =ListKala .IdFactor ORDER BY D_date  DESC) AS EndCost) END AS Fe FROM (SELECT ISNULL(SUM(" & If(idG < 0, "CostBigKala", If(idG = 0, "CostSmalKala", If(idG = 1, "CostBigKala", "EndCost"))) & "),0) As Fe FROM (SELECT  TOP 1  " & If(idG < 0, "CostBigKala", If(idG = 0, "CostSmalKala", If(idG = 1, "CostBigKala", "EndCost"))) & "  FROM Define_CostKala WHERE IdCity =" & IdCity & " AND IdKala =" & IdKala & " AND " & If(idG < 0, "CostBigKala", If(idG = 0, "CostSmalKala", If(idG = 1, "CostBigKala", "EndCost"))) & ">0 ORDER BY Id DESC) AS CityFe ) AS ListCost", ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCostFrosh_Barcode")
            Return 0
        End Try
    End Function

    Public Function GetCostKharid(ByVal IdKala As Long) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT  Fe FROM (SELECT Fe,ListKala.IdFactor ,D_date FROM (SELECT  KalaFactorBuy.Fe,KalaFactorBuy.IdFactor  FROM KalaFactorBuy WHERE  KalaFactorBuy.IdKala =" & IdKala & " AND KalaFactorBuy.Activ =1 AND KalaFactorBuy.Fe >0 ) As ListKala INNER JOIN ListFactorBuy On ListFactorBuy.IdFactor =ListKala .IdFactor  UNION ALL SELECT   Fe,IdFactor=0, D_date FROM Define_PrimaryKala WHERE IdKala=" & IdKala & ")AS EndKala  ORDER BY D_date ", ConectionBank)
                Dim dtr As SqlDataReader = CMD.ExecuteReader
                If dtr.HasRows Then
                    Dim res As Double = 0
                    Do While dtr.Read
                        res = dtr.Item("Fe")
                    Loop
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return res
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return 0
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCostKharid")
            Return 0
        End Try
    End Function

    Public Function GetAddressWithCity(ByVal Id As Long) As String
        Try
            Dim address As String = ""
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT Define_City.NamCI + '  ' +  ISNULL(Define_People.[Address],'')  FROM Define_People INNER JOIN Define_City ON Define_People.IdCity = Define_City.Code WHERE Id=" & Id, ConectionBank)
                address = CMD.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return address
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetAddressWithCity")
            Return ""
        End Try
    End Function

    Public Function GetCashMonDisc(ByVal Id As Long) As String
        Try
            Dim disc As Double = 0
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT  ISNULL(SUM(Mon-DarsadMon),0) FROM Define_Kala INNER JOIN KalaFactorSell ON Define_Kala.Id = KalaFactorSell.IdKala WHERE  Define_Kala.Cashing ='True' AND IdFactor =" & Id, ConectionBank)
                disc = CMD.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If disc = 0 Then
                Return ""
            Else
                Return "مبلغ نقدی فاکتور " & IIf(CStr(disc).Length < 3, disc, FormatNumber(disc, 0)) & " می باشد"
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCashMonDisc")
            Return ""
        End Try
    End Function
    Public Function GetCashMonDisc2(ByVal Id As Long) As String
        Try
            Dim disc As Double
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT  ISNULL(SUM(Mon-DarsadMon),0) FROM Define_Kala INNER JOIN KalaFactorSell ON Define_Kala.Id = KalaFactorSell.IdKala WHERE  Define_Kala.Cashing ='True' AND IdFactor =" & Id, ConectionBank)
                disc = CMD.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return disc
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCashMonDisc2")
            Return ""
        End Try
    End Function

    Public Function Get_Access_Form(ByVal F As String) As String
        Try
            If UCase(NamUser) = "ADMIN" Then Return "-1"
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            Dim SqlQuery As String = ""
            Dim Str_Return As String = ""

            If F = "F1" Then
                SqlQuery = "SELECT F1 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F2" Then
                SqlQuery = "SELECT F1,F2 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F3" Then
                SqlQuery = "SELECT F1,F2,F3 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F4" Then
                SqlQuery = "SELECT F4 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F5" Then
                SqlQuery = "SELECT F5 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F6" Then
                SqlQuery = "SELECT F6 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F7" Then
                SqlQuery = "SELECT F1,F2,F7 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F8" Then
                SqlQuery = "SELECT F1,F2,F8 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F9" Then
                SqlQuery = "SELECT F1,F2,F9 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F10" Then
                SqlQuery = "SELECT F10 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F11" Then
                SqlQuery = "SELECT F11 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F12" Then
                SqlQuery = "SELECT F1,F2,F12 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F13" Then
                SqlQuery = "SELECT F1,F2,F13 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F14" Then
                SqlQuery = "SELECT F1,F2,F14 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F15" Then
                SqlQuery = "SELECT F1,F2,F15 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F16" Then
                SqlQuery = "SELECT F16 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F17" Then
                SqlQuery = "SELECT F17 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F18" Then
                SqlQuery = "SELECT F1,F2,F18 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F19" Then
                SqlQuery = "SELECT F1,F2,F19 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F20" Then
                SqlQuery = "SELECT F1,F2,F20 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F21" Then
                SqlQuery = "SELECT F1,F2,F21 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F22" Then
                SqlQuery = "SELECT F22 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F23" Then
                SqlQuery = "SELECT F23 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F24" Then
                SqlQuery = "SELECT F1,F2,F24 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F25" Then
                SqlQuery = "SELECT F25 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F26" Then
                SqlQuery = "SELECT F26 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F27" Then
                SqlQuery = "SELECT F1,F2,F27 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F28" Then
                SqlQuery = "SELECT F28 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F29" Then
                SqlQuery = "SELECT F29 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F30" Then
                SqlQuery = "SELECT F1,F2,F30 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F31" Then
                SqlQuery = "SELECT F31 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F32" Then
                SqlQuery = "SELECT F32 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F33" Then
                SqlQuery = "SELECT F1,F2,F33 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F34" Then
                SqlQuery = "SELECT F1,F2,F34 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F35" Then
                SqlQuery = "SELECT F1,F2,F35 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F36" Then
                SqlQuery = "SELECT F1,F2,F36 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F37" Then
                SqlQuery = "SELECT F1,F2,F37 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F38" Then
                SqlQuery = "SELECT F1,F38 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F39" Then
                SqlQuery = "SELECT F1,F38,F39 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F40" Then
                SqlQuery = "SELECT F1,F38,F40 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F41" Then
                SqlQuery = "SELECT F1,F38,F41 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F42" Then
                SqlQuery = "SELECT F42 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F43" Then
                SqlQuery = "SELECT F43 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F44" Then
                SqlQuery = "SELECT F1,F38,F44 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F45" Then
                SqlQuery = "SELECT F45 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F46" Then
                SqlQuery = "SELECT F46 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F47" Then
                SqlQuery = "SELECT F47 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F48" Then
                SqlQuery = "SELECT F48 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F49" Then
                SqlQuery = "SELECT F49 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F50" Then
                SqlQuery = "SELECT F50 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F51" Then
                SqlQuery = "SELECT F51 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F52" Then
                SqlQuery = "SELECT F52 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F53" Then
                SqlQuery = "SELECT F53 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F54" Then
                SqlQuery = "SELECT F54 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F55" Then
                SqlQuery = "SELECT F55 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F56" Then
                SqlQuery = "SELECT F56 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F57" Then
                SqlQuery = "SELECT F57 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F58" Then
                SqlQuery = "SELECT F1,F58 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F59" Then
                SqlQuery = "SELECT F1,F58,F59 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F60" Then
                SqlQuery = "SELECT F1,F58,F60 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F61" Then
                SqlQuery = "SELECT F1,F58,F61 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F62" Then
                SqlQuery = "SELECT F1,F58,F62 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F63" Then
                SqlQuery = "SELECT F1,F58,F63 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F64" Then
                SqlQuery = "SELECT F1,F58,F64 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F65" Then
                SqlQuery = "SELECT F1,F58,F65 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F66" Then
                SqlQuery = "SELECT F1,F58,F66 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F67" Then
                SqlQuery = "SELECT F1,F58,F67 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F68" Then
                SqlQuery = "SELECT F1,F58,F68 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F69" Then
                SqlQuery = "SELECT F1,F58,F69 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F70" Then
                SqlQuery = "SELECT F1,F58,F70 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F71" Then
                SqlQuery = "SELECT F1,F58,F71 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F72" Then
                SqlQuery = "SELECT F1,F58,F72 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F73" Then
                SqlQuery = "SELECT F1,F58,F73 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F74" Then
                SqlQuery = "SELECT F1,F58,F74 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F75" Then
                SqlQuery = "SELECT F1,F58,F75 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F76" Then
                SqlQuery = "SELECT F1,F76 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F77" Then
                SqlQuery = "SELECT F1,F76,F77 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F78" Then
                SqlQuery = "SELECT F1,F76,F78 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F79" Then
                SqlQuery = "SELECT F1,F76,F79 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F80" Then
                SqlQuery = "SELECT F1,F76,F80 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F81" Then
                SqlQuery = "SELECT F1,F76,F81 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F82" Then
                SqlQuery = "SELECT F1,F76,F82 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F83" Then
                SqlQuery = "SELECT F1,F76,F83 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F84" Then
                SqlQuery = "SELECT F1,F76,F84 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F85" Then
                SqlQuery = "SELECT F1,F76,F85 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F86" Then
                SqlQuery = "SELECT F1,F76,F86 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F87" Then
                SqlQuery = "SELECT F1,F76,F87 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F88" Then
                SqlQuery = "SELECT F1,F76,F88 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F89" Then
                SqlQuery = "SELECT F1,F89 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F90" Then
                SqlQuery = "SELECT F1,F89,F90 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F91" Then
                SqlQuery = "SELECT F1,F89,F91 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F92" Then
                SqlQuery = "SELECT F1,F89,F92 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F93" Then
                SqlQuery = "SELECT F1,F89,F93 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F94" Then
                SqlQuery = "SELECT F1,F89,F94 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F95" Then
                SqlQuery = "SELECT F1,F89,F95 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F96" Then
                SqlQuery = "SELECT F1,F89,F96 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F97" Then
                SqlQuery = "SELECT F1,F89,F97 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F98" Then
                SqlQuery = "SELECT F1,F89,F98 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F99" Then
                SqlQuery = "SELECT F1,F99 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F100" Then
                SqlQuery = "SELECT F1,F99,F100 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F101" Then
                SqlQuery = "SELECT F1,F131,F101 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F102" Then
                SqlQuery = "SELECT F1,F131,F102 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F103" Then
                SqlQuery = "SELECT F1,F99,F103 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F104" Then
                SqlQuery = "SELECT F1,F99,F104 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F105" Then
                SqlQuery = "SELECT F1,F99,F105 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F106" Then
                SqlQuery = "SELECT F1,F99,F106 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F107" Then
                SqlQuery = "SELECT F1,F107 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F108" Then
                SqlQuery = "SELECT F1,F107,F108 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F109" Then
                SqlQuery = "SELECT F1,F107,F109 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F110" Then
                SqlQuery = "SELECT F1,F107,F110 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F111" Then
                SqlQuery = "SELECT F1,F111 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F112" Then
                SqlQuery = "SELECT F1,F112 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F113" Then
                SqlQuery = "SELECT F1,F131,F113 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F114" Then
                SqlQuery = "SELECT F1,F131,F114 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F115" Then
                SqlQuery = "SELECT F1,F2,F115 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F116" Then
                SqlQuery = "SELECT F1,F89,F116 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F117" Then
                SqlQuery = "SELECT F1,F2,F117 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F118" Then
                SqlQuery = "SELECT F118 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F119" Then
                SqlQuery = "SELECT F119 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F120" Then
                SqlQuery = "SELECT F120 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F121" Then
                SqlQuery = "SELECT F1,F99,F121 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F122" Then
                SqlQuery = "SELECT F1,F76,F122 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F123" Then
                SqlQuery = "SELECT F1,F2,F123 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F124" Then
                SqlQuery = "SELECT F1,F2,F124 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F125" Then
                SqlQuery = "SELECT F1,F125 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F126" Then
                SqlQuery = "SELECT F1,F2,F126 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F127" Then
                SqlQuery = "SELECT F1,F99,F127 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F128" Then
                SqlQuery = "SELECT F1,F2,F128 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F129" Then
                SqlQuery = "SELECT F1,F99,F129 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F130" Then
                SqlQuery = "SELECT F1,F131,F130 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F132" Then
                SqlQuery = "SELECT F1,F131,F132 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F134" Then
                SqlQuery = "SELECT F1,F133,F134 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F135" Then
                SqlQuery = "SELECT F1,F133,F135 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F136" Then
                SqlQuery = "SELECT F1,F133,F136 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F137" Then
                SqlQuery = "SELECT F1,F133,F137 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F138" Then
                SqlQuery = "SELECT F1,F133,F138 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F139" Then
                SqlQuery = "SELECT F1,F133,F139 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F140" Then
                SqlQuery = "SELECT F1,F133,F140 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F141" Then
                SqlQuery = "SELECT F1,F131,F141 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F142" Then
                SqlQuery = "SELECT F1,F131,F142 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F143" Then
                SqlQuery = "SELECT F1,F38,F143 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F144" Then
                SqlQuery = "SELECT F1,F2,F144 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F145" Then
                SqlQuery = "SELECT F1,F89,F145 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F146" Then
                SqlQuery = "SELECT F1,F99,F146 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F147" Then
                SqlQuery = "SELECT F1,F133,F147 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F148" Then
                SqlQuery = "SELECT F1,F133,F148 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F149" Then
                SqlQuery = "SELECT F1,F2,F149 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F150" Then
                SqlQuery = "SELECT F1,F2,F150 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F151" Then
                SqlQuery = "SELECT F151 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F152" Then
                SqlQuery = "SELECT F1,F99,F152 FROM User_Access WHERE Id=" & Id_User
            ElseIf F = "F153" Then
                SqlQuery = "SELECT F1,F153 FROM User_Access WHERE Id=" & Id_User
            End If
            '''''''''''''''''''''''''''''''''''''''''
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand(SqlQuery, ConectionBank)
                dtr = CMD.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()

                    If F = "F1" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor))
                    ElseIf F = "F2" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor))
                    ElseIf F = "F3" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F3"), key.CreateDecryptor))
                    ElseIf F = "F4" Then
                        Str_Return = Sec.StringDecrypt(dtr("F4"), key.CreateDecryptor)
                    ElseIf F = "F5" Then
                        Str_Return = Sec.StringDecrypt(dtr("F5"), key.CreateDecryptor)
                    ElseIf F = "F6" Then
                        Str_Return = Sec.StringDecrypt(dtr("F6"), key.CreateDecryptor)
                    ElseIf F = "F7" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F7"), key.CreateDecryptor))
                    ElseIf F = "F8" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F8"), key.CreateDecryptor))
                    ElseIf F = "F9" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F9"), key.CreateDecryptor))
                    ElseIf F = "F10" Then
                        Str_Return = Sec.StringDecrypt(dtr("F10"), key.CreateDecryptor)
                    ElseIf F = "F11" Then
                        Str_Return = Sec.StringDecrypt(dtr("F11"), key.CreateDecryptor)
                    ElseIf F = "F12" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F12"), key.CreateDecryptor))
                    ElseIf F = "F13" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F13"), key.CreateDecryptor))
                    ElseIf F = "F14" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F14"), key.CreateDecryptor))
                    ElseIf F = "F15" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F15"), key.CreateDecryptor))
                    ElseIf F = "F16" Then
                        Str_Return = Sec.StringDecrypt(dtr("F16"), key.CreateDecryptor)
                    ElseIf F = "F17" Then
                        Str_Return = Sec.StringDecrypt(dtr("F17"), key.CreateDecryptor)
                    ElseIf F = "F18" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F18"), key.CreateDecryptor))
                    ElseIf F = "F19" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F19"), key.CreateDecryptor))
                    ElseIf F = "F20" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F20"), key.CreateDecryptor))
                    ElseIf F = "F21" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F21"), key.CreateDecryptor))
                    ElseIf F = "F22" Then
                        Str_Return = Sec.StringDecrypt(dtr("F22"), key.CreateDecryptor)
                    ElseIf F = "F23" Then
                        Str_Return = Sec.StringDecrypt(dtr("F23"), key.CreateDecryptor)
                    ElseIf F = "F24" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F24"), key.CreateDecryptor))
                    ElseIf F = "F25" Then
                        Str_Return = Sec.StringDecrypt(dtr("F25"), key.CreateDecryptor)
                    ElseIf F = "F26" Then
                        Str_Return = Sec.StringDecrypt(dtr("F26"), key.CreateDecryptor)
                    ElseIf F = "F27" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F27"), key.CreateDecryptor))
                    ElseIf F = "F28" Then
                        Str_Return = Sec.StringDecrypt(dtr("F28"), key.CreateDecryptor)
                    ElseIf F = "F29" Then
                        Str_Return = Sec.StringDecrypt(dtr("F29"), key.CreateDecryptor)
                    ElseIf F = "F30" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F30"), key.CreateDecryptor))
                    ElseIf F = "F31" Then
                        Str_Return = Sec.StringDecrypt(dtr("F31"), key.CreateDecryptor)
                    ElseIf F = "F32" Then
                        Str_Return = Sec.StringDecrypt(dtr("F32"), key.CreateDecryptor)
                    ElseIf F = "F33" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F33"), key.CreateDecryptor))
                    ElseIf F = "F34" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F34"), key.CreateDecryptor))
                    ElseIf F = "F35" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F35"), key.CreateDecryptor))
                    ElseIf F = "F36" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F36"), key.CreateDecryptor))
                    ElseIf F = "F37" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F37"), key.CreateDecryptor))
                    ElseIf F = "F38" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor))
                    ElseIf F = "F39" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F39"), key.CreateDecryptor))
                    ElseIf F = "F40" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F40"), key.CreateDecryptor))
                    ElseIf F = "F41" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F41"), key.CreateDecryptor))
                    ElseIf F = "F42" Then
                        Str_Return = Sec.StringDecrypt(dtr("F42"), key.CreateDecryptor)
                    ElseIf F = "F43" Then
                        Str_Return = Sec.StringDecrypt(dtr("F43"), key.CreateDecryptor)
                    ElseIf F = "F44" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F44"), key.CreateDecryptor))
                    ElseIf F = "F45" Then
                        Str_Return = Sec.StringDecrypt(dtr("F45"), key.CreateDecryptor)
                    ElseIf F = "F46" Then
                        Str_Return = Sec.StringDecrypt(dtr("F46"), key.CreateDecryptor)
                    ElseIf F = "F47" Then
                        Str_Return = Sec.StringDecrypt(dtr("F47"), key.CreateDecryptor)
                    ElseIf F = "F48" Then
                        Str_Return = Sec.StringDecrypt(dtr("F48"), key.CreateDecryptor)
                    ElseIf F = "F49" Then
                        Str_Return = Sec.StringDecrypt(dtr("F49"), key.CreateDecryptor)
                    ElseIf F = "F50" Then
                        Str_Return = Sec.StringDecrypt(dtr("F50"), key.CreateDecryptor)
                    ElseIf F = "F51" Then
                        Str_Return = Sec.StringDecrypt(dtr("F51"), key.CreateDecryptor)
                    ElseIf F = "F52" Then
                        Str_Return = Sec.StringDecrypt(dtr("F52"), key.CreateDecryptor)
                    ElseIf F = "F53" Then
                        Str_Return = Sec.StringDecrypt(dtr("F53"), key.CreateDecryptor)
                    ElseIf F = "F54" Then
                        Str_Return = Sec.StringDecrypt(dtr("F54"), key.CreateDecryptor)
                    ElseIf F = "F55" Then
                        Str_Return = Sec.StringDecrypt(dtr("F55"), key.CreateDecryptor)
                    ElseIf F = "F56" Then
                        Str_Return = Sec.StringDecrypt(dtr("F56"), key.CreateDecryptor)
                    ElseIf F = "F57" Then
                        Str_Return = Sec.StringDecrypt(dtr("F57"), key.CreateDecryptor)
                    ElseIf F = "F58" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor))
                    ElseIf F = "F59" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F59"), key.CreateDecryptor))
                    ElseIf F = "F60" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F60"), key.CreateDecryptor))
                    ElseIf F = "F61" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F61"), key.CreateDecryptor))
                    ElseIf F = "F62" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F62"), key.CreateDecryptor))
                    ElseIf F = "F63" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F63"), key.CreateDecryptor))
                    ElseIf F = "F64" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F64"), key.CreateDecryptor))
                    ElseIf F = "F65" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F65"), key.CreateDecryptor))
                    ElseIf F = "F66" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F66"), key.CreateDecryptor))
                    ElseIf F = "F67" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F67"), key.CreateDecryptor))
                    ElseIf F = "F68" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F68"), key.CreateDecryptor))
                    ElseIf F = "F69" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F69"), key.CreateDecryptor))
                    ElseIf F = "F70" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F70"), key.CreateDecryptor))
                    ElseIf F = "F71" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F71"), key.CreateDecryptor))
                    ElseIf F = "F72" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F72"), key.CreateDecryptor))
                    ElseIf F = "F73" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F73"), key.CreateDecryptor))
                    ElseIf F = "F74" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F74"), key.CreateDecryptor))
                    ElseIf F = "F75" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F58"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F75"), key.CreateDecryptor))
                    ElseIf F = "F76" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor))
                    ElseIf F = "F77" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F77"), key.CreateDecryptor))
                    ElseIf F = "F78" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F78"), key.CreateDecryptor))
                    ElseIf F = "F79" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F79"), key.CreateDecryptor))
                    ElseIf F = "F80" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F80"), key.CreateDecryptor))
                    ElseIf F = "F81" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F81"), key.CreateDecryptor))
                    ElseIf F = "F82" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F82"), key.CreateDecryptor))
                    ElseIf F = "F83" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F83"), key.CreateDecryptor))
                    ElseIf F = "F84" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F84"), key.CreateDecryptor))
                    ElseIf F = "F85" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F85"), key.CreateDecryptor))
                    ElseIf F = "F86" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F86"), key.CreateDecryptor))
                    ElseIf F = "F87" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F87"), key.CreateDecryptor))
                    ElseIf F = "F88" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F88"), key.CreateDecryptor))
                    ElseIf F = "F89" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor))
                    ElseIf F = "F90" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F90"), key.CreateDecryptor))
                    ElseIf F = "F91" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F91"), key.CreateDecryptor))
                    ElseIf F = "F92" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F92"), key.CreateDecryptor))
                    ElseIf F = "F93" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F93"), key.CreateDecryptor))
                    ElseIf F = "F94" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F94"), key.CreateDecryptor))
                    ElseIf F = "F95" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F95"), key.CreateDecryptor))
                    ElseIf F = "F96" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F96"), key.CreateDecryptor))
                    ElseIf F = "F97" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F97"), key.CreateDecryptor))
                    ElseIf F = "F98" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F98"), key.CreateDecryptor))
                    ElseIf F = "F99" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor))
                    ElseIf F = "F100" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F100"), key.CreateDecryptor))
                    ElseIf F = "F101" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F101"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F102" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F102"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F103" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F103"), key.CreateDecryptor))
                    ElseIf F = "F104" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F104"), key.CreateDecryptor))
                    ElseIf F = "F105" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F105"), key.CreateDecryptor))
                    ElseIf F = "F106" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F106"), key.CreateDecryptor))
                    ElseIf F = "F107" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F107"), key.CreateDecryptor))
                    ElseIf F = "F108" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F107"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F108"), key.CreateDecryptor))
                    ElseIf F = "F109" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F107"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F109"), key.CreateDecryptor))
                    ElseIf F = "F110" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F107"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F110"), key.CreateDecryptor))
                    ElseIf F = "F111" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F111"), key.CreateDecryptor))
                    ElseIf F = "F112" Then
                        Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F112"), key.CreateDecryptor))
                    ElseIf F = "F113" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F113"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F114" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F114"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F115" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F115"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F116" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F116"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F117" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F117"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F118" Then
                        Try
                            Str_Return = Sec.StringDecrypt(dtr("F118"), key.CreateDecryptor)
                        Catch ex As Exception
                            Str_Return = "0000"
                        End Try
                    ElseIf F = "F119" Then
                        Try
                            Str_Return = Sec.StringDecrypt(dtr("F119"), key.CreateDecryptor)
                        Catch ex As Exception
                            Str_Return = "0000"
                        End Try
                    ElseIf F = "F120" Then
                        Try
                            Str_Return = Sec.StringDecrypt(dtr("F120"), key.CreateDecryptor)
                        Catch ex As Exception
                            Str_Return = "0000"
                        End Try
                    ElseIf F = "F121" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F121"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & "000000")
                        End Try
                    ElseIf F = "F122" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F122"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F76"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F123" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F123"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "000000")
                        End Try
                    ElseIf F = "F124" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F124"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "0000")
                        End Try
                    ElseIf F = "F125" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F125"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F126" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F126"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "00000")
                        End Try
                    ElseIf F = "F127" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F127"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F128" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F128"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "0000")
                        End Try
                    ElseIf F = "F129" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F129"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F130" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F130"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F132" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F132"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F134" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F134"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F135" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F135"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F136" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F136"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F137" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F137"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F138" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F138"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F139" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F139"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F140" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F140"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F141" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F141"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F142" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F131"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F142"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F143" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F143"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F38"), key.CreateDecryptor) & "0000000")
                        End Try
                    ElseIf F = "F144" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F144"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "000")
                        End Try
                    ElseIf F = "F145" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F145"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F89"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F146" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F146"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F147" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F147"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F148" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F133"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F148"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "00")
                        End Try
                    ElseIf F = "F149" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F149"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "0000")
                        End Try
                    ElseIf F = "F150" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F150"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F2"), key.CreateDecryptor) & "0000")
                        End Try
                    ElseIf F = "F151" Then
                        Try
                            Str_Return = Sec.StringDecrypt(dtr("F151"), key.CreateDecryptor)
                        Catch ex As Exception
                            Str_Return = "0000"
                        End Try

                    ElseIf F = "F152" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F152"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F99"), key.CreateDecryptor) & "0")
                        End Try
                    ElseIf F = "F153" Then
                        Try
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & Sec.StringDecrypt(dtr("F153"), key.CreateDecryptor))
                        Catch ex As Exception
                            Str_Return = (Sec.StringDecrypt(dtr("F1"), key.CreateDecryptor) & "0000")
                        End Try
                    Else
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        Return ""
                    End If
                End If
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Str_Return
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "Get_Access_Form")
            Return ""
        End Try
    End Function
    Public Function GetCountPrint(ByVal Kind As String) As Long
        Try
            Dim query As String = ""
            If Kind = "FACTOR" Then
                query = "SELECT Top 1 FactorCount AS CC FROM SettingProgram WHERE IdUser=" & Id_User
            ElseIf Kind = "ANBAR" Then
                query = "SELECT Top 1 AnbarCount AS CC FROM SettingProgram WHERE IdUser=" & Id_User
            ElseIf Kind = "GETPAY" Then
                query = "SELECT Top 1 Get_Pay_Count AS CC FROM SettingProgram WHERE IdUser=" & Id_User
            End If
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand(query, ConectionBank)
                Dim dtr As SqlDataReader = CMD.ExecuteReader
                If dtr.HasRows Then
                    Dim res As Long = 1
                    Do While dtr.Read
                        res = dtr.Item("CC")
                    Loop
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return res
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return 1
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCountPrint")
            Return 1
        End Try
    End Function
    Public Function GetKindFactor() As String
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT (Case FactorPaper WHEN 0 THEN N'A4E' WHEN 1 THEN N'EPSON100'  ELSE N'EPSON130' END) + (Case TypeFactor WHEN 0 THEN N'T' WHEN 1 THEN  N'F' WHEN 2 THEN  N'S' WHEN 3 THEN N'P' WHEN 4 THEN N'L' WHEN 5 THEN N'S2' WHEN 6 THEN N'S3' WHEN 7 THEN N'S4' ELSE N'T' END) + (Case S1 WHEN 1 THEN N'' ELSE N'G' END) + (Case S2 WHEN 1 THEN N'' ELSE N'K' END) + (Case S5 WHEN 1 THEN N'B' WHEN 0 THEN N'S' ELSE N'B' END) AS CC FROM SettingProgram WHERE IdUser=" & Id_User, ConectionBank)
                Dim dtr As SqlDataReader = CMD.ExecuteReader
                If dtr.HasRows Then
                    Dim res As String = "A4EFGKB"
                    Do While dtr.Read
                        res = dtr.Item("CC")
                    Loop
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return res
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return "A4EFGKB"
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetKindFactor")
            Return "A4EFGKB"
        End Try
    End Function

    Public Function GetDefault(ByVal Kind As String) As String
        Try
            Dim query As String = ""
            If Kind = "KALA" Then
                query = "SELECT TOP 1 CAST(FilterKala As nvarchar(max)) + CAST(TypeKala As nvarchar(max))  AS CC FROM SettingProgram WHERE IdUser=" & Id_User
            ElseIf Kind = "PEOPLE" Then
                query = "SELECT TOP 1 CAST(FilterP As nvarchar(max)) + CAST(TypeP As nvarchar(max))  AS CC FROM SettingProgram WHERE IdUser=" & Id_User
            ElseIf Kind = "ALL" Then
                query = "SELECT TOP 1 CAST(TypeAll As nvarchar(max))  AS CC FROM SettingProgram WHERE IdUser=" & Id_User
            End If
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand(query, ConectionBank)
                Dim dtr As SqlDataReader = CMD.ExecuteReader
                If dtr.HasRows Then
                    Dim res As String = "00"
                    Do While dtr.Read
                        res = dtr.Item("CC")
                    Loop
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return res
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    If Kind = "KALA" Or Kind = "PEOPLE" Then
                        Return "00"
                    Else
                        Return "0"
                    End If
                End If
            End Using
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetDefault")
            If Kind = "KALA" Or Kind = "PEOPLE" Then
                Return "00"
            Else
                Return "0"
            End If
        End Try
    End Function

    Public Sub CheckNetworkConnect()
        Try
            DOMAIN = String.Format("http://{0}:1433", GetPath())
            m_DCW.Domain = New Uri(DOMAIN)
            AddHandler m_DCW.ConnectChanged, AddressOf DCW_ConnectChanged
            m_DCW.Work = True
            DCW_ConnectChanged(Nothing, Nothing)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CheckNetworkConnect")
        End Try
    End Sub
    Public Sub DCW_ConnectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Not m_DCW.IsConnect Then
                If ShowConnect = True Then
                    FrmMain.Enabled = False
                    NtDisconnect.Text = "خطا در ارتباط با شبکه"
                    NtDisconnect.Icon = My.Resources.SyncCenter
                    NtDisconnect.Visible = True
                    NtDisconnect.ShowBalloonTip(Integer.MaxValue, "خطا در ارتباط با شبکه", "کاربر گرامی به دلیل قطع شدن ارتباط شما با شبکه فعلا ادامه عملیات امکانپذیر نیست.لطفا جهت برقراری ارتباط اقدام نمایید", ToolTipIcon.Warning)
                End If
            Else
                If ShowConnect = True Then
                    FrmMain.Enabled = True
                    NtDisconnect.Icon = Nothing
                    NtDisconnect.Visible = False
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "DCW_ConnectChanged")
        End Try
    End Sub

    Private Function GetPath() As String
        Try
            If Not (File.Exists(UCase("Provider.PTH"))) Then
                File.Create(My.Application.Info.DirectoryPath + "\Provider.PTH")
                Return "127.0.0.1"
            Else
                Dim str As String = ""
                str = File.ReadAllText(My.Application.Info.DirectoryPath + "\Provider.PTH")
                If String.IsNullOrEmpty(str) Then
                    Return "127.0.0.1"
                Else
                    Return str.Substring(0, str.IndexOf(vbCrLf))
                End If
            End If
            
        Catch ex As Exception
            Return "127.0.0.1"
        End Try
    End Function
    Public Function GetExitFac(ByVal Id As Long) As String
        Try
            Dim ListFactor As String = ""
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand("SELECT IdFactor FROM ListExitFactor WHERE IdList =" & Id, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using
            If dtr.HasRows Then
                ListFactor = "AND ListFactorSell.IdFactor IN ("
                While dtr.Read
                    ListFactor &= dtr("IdFactor") & ","
                End While
                ListFactor = ListFactor.Substring(0, ListFactor.Length - 1)
                ListFactor &= ")"
            Else
                ListFactor = "-1"
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return ListFactor
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetExitFac")
            Return "-1"
        End Try
    End Function

    Public Function GetExitFac2(ByVal Id As Long) As String
        Try
            Dim ListFactor As String = ""
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand("SELECT IdFactor FROM ListExitFactor WHERE IdList =" & Id, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using
            If dtr.HasRows Then
                While dtr.Read
                    ListFactor &= dtr("IdFactor") & ","
                End While
                ListFactor = ListFactor.Substring(0, ListFactor.Length - 1)

            Else
                ListFactor = "-1"
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return ListFactor
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetExitFac2")
            Return "-1"
        End Try
    End Function

    Public Function AreYouExistGroup(ByVal Id As Long) As Boolean
        Try
            Dim flag As Boolean = False
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using CMD As New SqlCommand("SELECT ChkIdGroup FROM  Define_People WHERE Id =" & Id, ConectionBank)
                flag = CMD.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return flag
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreYouExistGroup")
            Return False
        End Try
    End Function

    Public Function GetIdGroup(ByVal Id As Long) As Long
        Try
            Dim flag As Long = 0
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using CMD As New SqlCommand("SELECT CASE WHEN COUNT(*)>0 THEN MAX(IdGroup) ELSE 0 END FROM  Define_People WHERE ChkIdGroup ='True' AND Id =" & Id, ConectionBank)
                flag = CMD.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return flag
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetIdGroup")
            Return 0
        End Try
    End Function

    Public Sub AutomaticDiscount(ByVal Id As Long, ByVal Mon As Double)
        Try
            TmpDarsad = 0
            TmpDarsadMon = 0
            TmpGroupName = ""
            Cash = False
            Dim Query As String = ""

            Query = "SELECT  Darsad FROM Define_List_Group_P WHERE LinkId =(SELECT  IdGroup  FROM Define_People WHERE Id=" & Id & " AND ChkIdGroup ='True') AND (" & Mon & ">=AzMon AND " & Mon & "<=TaMon  )"

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Using CMD As New SqlCommand(Query, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                TmpDarsad = dtr("Darsad")
                dtr.Close()
                Using CMD As New SqlCommand("SELECT  HKalaCash FROM Define_Group_P WHERE Id =(SELECT  IdGroup  FROM Define_People WHERE Id=" & Id & " AND ChkIdGroup ='True')", ConectionBank)
                    dtr = CMD.ExecuteReader
                End Using
                If dtr.HasRows Then
                    dtr.Read()
                    Cash = dtr("HKalaCash")
                Else
                    Cash = False
                End If
            Else
                TmpDarsad = -1
            End If
            dtr.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AutomaticDiscount")
        End Try
    End Sub

    Public Function KalaCash(ByVal Id As Long, ByVal IdGroup As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr2 As SqlDataReader = Nothing

            Using CMD As New SqlCommand("SELECT Cashing,CNT=(SELECT COUNT(Id) AS CNT FROM DefinePromotion WHERE IdGroup =" & IdGroup & " AND IdKala =" & Id & ") FROM Define_Kala WHERE Id=" & Id, ConectionBank)
                dtr2 = CMD.ExecuteReader
            End Using

            Dim flag As Boolean = False
            If dtr2.HasRows Then
                dtr2.Read()
                flag = dtr2("Cashing")
                flagV = dtr2("CNT")
            Else
                flag = False
                flagV = 0
            End If

            Return flag
            dtr2.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "KalaCash")
            Return False
        End Try
    End Function

    Public Sub CallDiscountFactor(ByVal Id As Long, ByVal IdFactor As Long)
        Try
            TmpDarsad = 0
            TmpDarsad1 = 0
            TmpHajm = False
            TmpKalaCash = False

            Dim Query As String = ""

            Query = "DECLARE @tbl Table(Mon bigint,DiscountKala bigint,Discount bigint,KalaCashMon bigint) INSERT INTO @tbl (Mon,DiscountKala,Discount,KalaCashMon) (SELECT (Listkala.Mon+ListMon.MonAdd-ListMon.MonDec) AS Mon ,Listkala.DiscountKala,ListMon.Discount,ListKalaCash.KalaCash AS KalaCashMon FROM (SELECT  ISNULL(SUM(Mon),0) AS Mon,ISNULL(SUM(DarsadMon),0) AS DiscountKala FROM KalaFactorSell WHERE IdFactor =" & IdFactor & ") AS Listkala,(SELECT  ISNULL(SUM(MonDec),0) AS MonDec,ISNULL(SUM(MonAdd),0) MonAdd,ISNULL(SUM(Discount),0) Discount FROM ListFactorSell WHERE IdFactor =" & IdFactor & ") As ListMon,(SELECT  ISNULL(SUM(Mon),0) KalaCash FROM Define_Kala INNER JOIN KalaFactorSell ON Define_Kala.Id = KalaFactorSell.IdKala WHERE  Define_Kala.Cashing ='True' AND IdFactor =" & IdFactor & ") As ListKalaCash) SELECT Hajm,KalaCash,CashDiscount=CASE WHEN (((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))>=Cash1 AND ((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))<=Cash2) THEN DCash1   WHEN (((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))>=Cash3 AND ((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))<=Cash4) THEN DCash2 WHEN (((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))>=Cash5 AND ((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))<=Cash6) THEN DCash3 ELSE 0 END ,PelDiscount=CASE WHEN (((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))>=CashP1 AND ((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))<=CashP2) THEN DP1   WHEN (((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))>=CashP3 AND ((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))<=CashP4) THEN DP2 WHEN (((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))>=CashP5 AND ((SELECT MAX(Mon) from @tbl) -(CASE WHEN Hajm='True' THEN ((SELECT (DiscountKala+Discount) from @tbl)) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))<=CashP6) THEN DP3 ELSE 0 END FROM Define_People INNER JOIN Define_Group_P ON Define_People.IdGroup = Define_Group_P.Id WHERE  ChkIdGroup ='True' AND Define_People.ID =" & Id

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Using CMD As New SqlCommand(Query, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                TmpDarsad = dtr("CashDiscount")
                TmpDarsad1 = dtr("PelDiscount")
                TmpHajm = dtr("Hajm")
                TmpKalaCash = dtr("KalaCash")
            Else
                TmpDarsad = 0
                TmpDarsad1 = 0
                TmpHajm = False
                TmpKalaCash = False
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CallDiscountFactor")
            TmpDarsad = 0
            TmpDarsad1 = 0
            TmpHajm = False
            TmpKalaCash = False
        End Try
    End Sub

    Public Sub CallDiscountChkFactor(ByVal Id As Long)
        Try

            Dim Query As String = ""

            Query = "SELECT NumChk1=CASE WHEN  (Chk1 =0 AND Chk2 =0) Then N'-' WHEN  (Chk1=Chk2 AND Chk1 <>0 AND Chk2 <>0) Then N'چک ' + CAST(Chk2 AS nvarchar(max))  + N' روزه' WHEN  (Chk1<Chk2 AND Chk1 <>0 AND Chk2 <>0) Then N'چک ' + CAST(Chk1 AS nvarchar(max)) + N'الی' + CAST(Chk2 AS nvarchar(max))  + N' روزه' ELSE N'نامشخص' END ,D1=CASE WHEN  (Chk1 =0 AND Chk2 =0) Then 0 WHEN  (Chk1=Chk2 AND Chk1 <>0 AND Chk2 <>0) Then DChk1 WHEN  (Chk1<Chk2 AND Chk1 <>0 AND Chk2 <>0) Then DChk1 ELSE 0 END ,NumChk2=CASE WHEN  (Chk3 =0 AND Chk4 =0) Then N'-' WHEN  (Chk3=Chk4 AND Chk3 <>0 AND Chk4 <>0) Then N'چک ' + CAST(Chk4 AS nvarchar(max))  + N' روزه' WHEN  (Chk3<Chk4 AND Chk3 <>0 AND Chk4 <>0) Then N'چک ' + CAST(Chk3 AS nvarchar(max)) + N'الی' + CAST(Chk4 AS nvarchar(max))  + N' روزه' ELSE N'نامشخص' END ,D2=CASE WHEN  (Chk3 =0 AND Chk4 =0) Then 0 WHEN  (Chk3=Chk4 AND Chk3 <>0 AND Chk4 <>0) Then DChk2 WHEN  (Chk3 <Chk4 AND Chk3 <>0 AND Chk4 <>0) Then DChk2 ELSE 0 END ,NumChk3=CASE WHEN  (Chk5 =0 AND Chk6 =0) Then N'-' WHEN  (Chk5=Chk6 AND Chk5 <>0 AND Chk6 <>0) Then N'چک ' + CAST(Chk6 AS nvarchar(max))  + N' روزه' WHEN  (Chk5<Chk6 AND Chk5 <>0 AND Chk6 <>0) Then N'چک ' + CAST(Chk5 AS nvarchar(max)) + N'الی' + CAST(Chk6 AS nvarchar(max))  + N' روزه' ELSE N'نامشخص' END ,D3=CASE WHEN  (Chk5 =0 AND Chk6 =0) Then 0 WHEN  (Chk5=Chk6 AND Chk5 <>0 AND Chk6 <>0) Then DChk3 WHEN  (Chk5 <Chk6 AND Chk5 <>0 AND Chk6 <>0) Then DChk3 ELSE 0 END FROM (SELECT  Chk1, Chk2, Chk3, Chk4, Chk5, Chk6, DChk1, DChk2, DChk3 FROM Define_Group_P WHERE Id =(SELECT IdGroup FROM Define_People WHERE Define_People.ID =" & Id & ")) AS Listg"

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Using CMD As New SqlCommand(Query, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                TmpDarsad = dtr("D1")
                TmpDarsad1 = dtr("D2")
                TmpDarsad2 = dtr("D3")
                tc1 = dtr("NumChk1")
                tc2 = dtr("NumChk2")
                tc3 = dtr("NumChk3")
            Else
                TmpDarsad = 0
                TmpDarsad1 = 0
                TmpDarsad2 = 0
                tc1 = "-"
                tc2 = "-"
                tc3 = "-"
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            TmpDarsad = 0
            TmpDarsad1 = 0
            TmpDarsad2 = 0
            tc1 = "-"
            tc2 = "-"
            tc3 = "-"
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CallDiscountChkFactor")
        End Try
    End Sub

    Public Sub CallDiscountCardFactor(ByVal Id As Long, ByVal IdFactor As Long)
        Try
            TmpDarsad = 0

            Dim Query As String = ""

            Query = "DECLARE @tbl Table(Mon bigint,DiscountKala bigint,Discount bigint,KalaCashMon bigint) INSERT INTO @tbl (Mon,DiscountKala,Discount,KalaCashMon) (SELECT (Listkala.Mon+ListMon.MonAdd-ListMon.MonDec) AS Mon,Listkala.DiscountKala,ListMon.Discount,ListKalaCash.KalaCash AS KalaCashMon FROM (SELECT  ISNULL(SUM(Mon),0) AS Mon,ISNULL(SUM(DarsadMon),0) AS DiscountKala FROM KalaFactorSell WHERE IdFactor =" & IdFactor & ") AS Listkala,(SELECT  ISNULL(SUM(MonDec),0) AS MonDec,ISNULL(SUM(MonAdd),0) MonAdd,ISNULL(SUM(Discount),0) Discount FROM ListFactorSell WHERE IdFactor =" & IdFactor & ") As ListMon,(SELECT  ISNULL(SUM(Mon),0) KalaCash FROM Define_Kala INNER JOIN KalaFactorSell ON Define_Kala.Id = KalaFactorSell.IdKala WHERE  Define_Kala.Cashing ='True' AND IdFactor =" & IdFactor & ") As ListKalaCash) SELECT CardDiscount=Round(DCard*((SELECT MAX(Mon) from @tbl) - (CASE WHEN Hajm='True' THEN (SELECT (DiscountKala+Discount) from @tbl) ELSE 0 END)-(CASE WHEN KalaCash='True' THEN (SELECT MAX(KalaCashMon) from @tbl) ELSE 0 END))/100,0) FROM Define_People INNER JOIN Define_Group_P ON Define_People.IdGroup = Define_Group_P.Id WHERE  ChkIdGroup ='True' AND Define_People.ID =" & Id

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Using CMD As New SqlCommand(Query, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                TmpDarsad = dtr("CardDiscount")
            Else
                TmpDarsad = 0
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CallDiscountCardFactor")
            TmpDarsad = 0
        End Try
    End Sub

    Public Function CallKindFactor(ByVal Id As Long, ByVal Dat As String) As String
        Try

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing

            Using CMD As New SqlCommand("SELECT  KindFrosh,TxtKindFrosh=Case KindFrosh WHEN 0 THEN N'نقدی' WHEN 1 THEN N'چک' WHEN 2 THEN N'نسیه' WHEN 3 THEN N'ترکیبی' ELSE N'نا مشخص' END, ISNULL((SELECT Rate FROM Wanted_Frosh WHERE IdFactor =" & Id & "),0) As rate FROM ListFactorSell WHERE IdFactor =" & Id, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using
            Dim str As String = ""
            If dtr.HasRows Then
                dtr.Read()
                If dtr("KindFrosh") = 1 Or dtr("KindFrosh") = 2 Then

                    If dtr("rate") > 0 Then

                        Dim dat1 As String = Dat
                        For i As Integer = 1 To CInt(dtr("rate"))
                            dat1 = ADDDAY(dat1)
                        Next

                        str = dtr("TxtKindFrosh") & "-" & dtr("rate") & "روزه " & vbCrLf & dat1
                    Else
                        str = dtr("TxtKindFrosh")
                    End If

                Else
                    str = dtr("TxtKindFrosh")
                End If
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return str
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "CallKindFactor")
            Return ""
        End Try
    End Function
    Public Sub SetEndMonKala(ByRef Dataret As DataSetFactor, ByVal id As Long)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable

            Using CMD As New SqlCommand("SELECT IdKala,EndCost FROM Define_CostKala WHERE IdCity IN (SELECT IdCity FROM  Define_People WHERE ID =" & id & ")", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            Dim row() As DataRow = Nothing

            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                row = Nothing
                If Not (Dataret.DataTable1.Rows(i).Item("Idkala") Is DBNull.Value Or Dataret.DataTable1.Rows(i).Item("Idkala").Equals("")) Then
                    row = dt.Select("IdKala=" & Dataret.DataTable1.Rows(i).Item("Idkala"))
                    If row.Length > 0 Then
                        Dataret.DataTable1.Rows(i).Item("PeopleMon") = row(0).Item("EndCost")
                    Else
                        Dataret.DataTable1.Rows(i).Item("PeopleMon") = 0
                    End If
                Else
                    Dataret.DataTable1.Rows(i).Item("PeopleMon") = 0
                End If
            Next i
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetEndMonKala")
        End Try
    End Sub
    Public Sub GetInfoCotrolFactor(ByRef Dataret As DataSetControlFactor)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable
            Dim namfac As String = ""
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                namfac &= Dataret.DataTable1.Rows(i).Item("IdFactor") & ","
            Next
            namfac = namfac.Substring(0, namfac.Length - 1)
            Using CMD As New SqlCommand("SELECT   DISTINCT  Define_City .NamCI AS nam  FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_City ON Define_City.Code =Define_People .IdCity  WHERE IdFactor IN (" & namfac & ")", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            For i As Integer = 0 To dt.Rows.Count - 1
                Tmp_Namkala &= dt.Rows(i).Item("nam") & "،"
            Next
            Tmp_Namkala = Tmp_Namkala.Substring(0, Tmp_Namkala.Length - 1)

            dt.Clear()
            Using CMD As New SqlCommand("SELECT   DISTINCT  Define_Part.NamP as nam FROM  ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Part ON Define_Part.Code =Define_People .IdPart  WHERE IdFactor IN (" & namfac & ")", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            For i As Integer = 0 To dt.Rows.Count - 1
                Tmp_OneGroup &= dt.Rows(i).Item("nam") & "،"
            Next
            Tmp_OneGroup = Tmp_OneGroup.Substring(0, Tmp_OneGroup.Length - 1)
            If Not String.IsNullOrEmpty(Tmp_String1) Then
                dt.Columns.Clear()
                dt.Clear()
                Using CMD As New SqlCommand("SELECT (SELECT Nam FROM Define_Driver WHERE Id=ExitList.IdDriver) AS Driver,(SELECT Nam FROM Define_Reciver  WHERE Id=ExitList.IdRecive) AS Reciver FROM (SELECT IdDriver,IdRecive  FROM ExitFactor WHERE Id=" & CLng(Tmp_String1) & ") As ExitList", ConectionBank)
                    dt.Load(CMD.ExecuteReader)
                End Using
                TmpAddress = If(dt.Rows(0).Item("Driver") Is DBNull.Value, "", dt.Rows(0).Item("Driver"))
                TmpTell1 = If(dt.Rows(0).Item("Reciver") Is DBNull.Value, "", dt.Rows(0).Item("Reciver"))
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetInfoCotrolFactor")
        End Try
    End Sub
    Public Sub GetInfoExitFactor(ByVal Kind As String)
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dt As New DataTable

            Tmp_Namkala = ""
            Tmp_OneGroup = ""
            TmpAddress = ""
            TmpTell1 = ""

            Using CMD As New SqlCommand("SELECT   DISTINCT  Define_City .NamCI AS nam  FROM " & If(Kind = "F", "ListFactorSell", "ListFactorBackSell") & " INNER JOIN Define_People ON " & If(Kind = "F", "ListFactorSell", "ListFactorBackSell") & ".IdName = Define_People.ID INNER JOIN Define_City ON Define_City.Code =Define_People .IdCity  WHERE IdFactor IN (" & Replace(Tmp_String2, "-", ",").Substring(0, Tmp_String2.Length - 1) & ")", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            For i As Integer = 0 To dt.Rows.Count - 1
                Tmp_Namkala &= dt.Rows(i).Item("nam") & "،"
            Next
            Tmp_Namkala = Tmp_Namkala.Substring(0, Tmp_Namkala.Length - 1)

            dt.Clear()
            Using CMD As New SqlCommand("SELECT   DISTINCT  Define_Part.NamP as nam FROM  " & If(Kind = "F", "ListFactorSell", "ListFactorBackSell") & " INNER JOIN Define_People ON " & If(Kind = "F", "ListFactorSell", "ListFactorBackSell") & ".IdName = Define_People.ID INNER JOIN Define_Part ON Define_Part.Code =Define_People .IdPart  WHERE IdFactor IN (" & Replace(Tmp_String2, "-", ",").Substring(0, Tmp_String2.Length - 1) & ")", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using
            For i As Integer = 0 To dt.Rows.Count - 1
                Tmp_OneGroup &= dt.Rows(i).Item("nam") & "،"
            Next

            Tmp_OneGroup = Tmp_OneGroup.Substring(0, Tmp_OneGroup.Length - 1)

            If Not String.IsNullOrEmpty(Tmp_String1) Then
                dt.Columns.Clear()
                dt.Clear()
                Using CMD As New SqlCommand("SELECT (SELECT Nam FROM Define_Driver WHERE Id=ExitList.IdDriver) AS Driver,(SELECT Nam FROM Define_Reciver  WHERE Id=ExitList.IdRecive) AS Reciver FROM (SELECT IdDriver,IdRecive  FROM ExitFactor WHERE Id=" & CLng(Tmp_String1) & ") As ExitList", ConectionBank)
                    dt.Load(CMD.ExecuteReader)
                End Using
                TmpAddress = If(dt.Rows(0).Item("Driver") Is DBNull.Value, "", dt.Rows(0).Item("Driver"))
                TmpTell1 = If(dt.Rows(0).Item("Reciver") Is DBNull.Value, "", dt.Rows(0).Item("Reciver"))
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetInfoExitFactor")
        End Try
    End Sub
    Public Function GetSetBarcode() As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dtr As SqlDataReader = Nothing
            Using CMD As New SqlCommand("SELECT Barcode FROM SettingProgram WHERE IdUser=" & Id_User, ConectionBank)
                dtr = CMD.ExecuteReader
            End Using

            If dtr.HasRows Then
                dtr.Read()
                If dtr("Barcode") = True Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End If

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Return False
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetSetBarcode")
            Return False
        End Try
    End Function

    Public Sub SetActivePeople(ByVal IdName As Long)
        Try
            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT TOP 1 StateActive FROM Define_ActivePeople WHERE IdName =" & IdName & " ORDER BY Dat DESC", ConectionBank)
                dt.Load(CMD.ExecuteReader)
            End Using

            If dt.Rows.Count <= 0 Then
                Using CMD As New SqlCommand("UPDATE Define_People SET Activ='False' WHERE ID =" & IdName, ConectionBank)
                    CMD.ExecuteNonQuery()
                End Using
            Else
                Using CMD As New SqlCommand("UPDATE Define_People SET Activ='" & If(dt.Rows(0).Item(0) = False, "False", "True") & "' WHERE ID =" & IdName, ConectionBank)
                    CMD.ExecuteNonQuery()
                End Using
            End If
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "SetActivePeople")
        End Try
    End Sub
    Public Function AreShowMojody() As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
           
            Using CMD As New SqlCommand("SELECT ISNULL(S7,'0') FROM SettingProgram WHERE IdUser =" & Id_User, ConectionBank)
                If CMD.ExecuteScalar = "1" Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return True
                Else
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Return False
                End If
            End Using

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "AreShowMojody")
            Return False
        End Try
    End Function

    Public Function LimitWork(ByVal Dat As String, ByVal Kind As String) As Boolean
        Dim DT As New DataTable
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using CMD As New SqlCommand("SELECT ISNULL(S8,'0') AS Edit,ISNULL(S9,'0') As Del,dat=(SELECT CAST(YEAR(GETDATE()) AS nvarchar(max)) + '/' + CASE WHEN LEN(MONTH(GETDATE()))=1 THEN  '0' + CAST(MONTH(GETDATE())AS nvarchar(max)) ELSE CAST(MONTH(GETDATE())AS nvarchar(max)) END + '/' + CASE WHEN LEN(DAY(GETDATE()))=1 THEN  '0' + CAST(DAY(GETDATE())AS nvarchar(max)) ELSE CAST(DAY(GETDATE())AS nvarchar(max)) END ) FROM SettingProgram WHERE IdUser=" & Id_User, ConectionBank)
                DT.Load(CMD.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If DT.Rows.Count <= 0 Then
                Return False
            Else
                If Kind = "EDIT" Then
                    If CLng(DT.Rows(0).Item("Edit")) <= 0 Then
                        Return True
                    Else

                        If SUBDAY(ConvertDate(DT.Rows(0).Item("dat")), Dat) >= CLng(DT.Rows(0).Item("Edit")) Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                ElseIf Kind = "DEL" Then
                    If CLng(DT.Rows(0).Item("Del")) <= 0 Then
                        Return True
                    Else
                        If SUBDAY(ConvertDate(DT.Rows(0).Item("dat")), Dat) >= CLng(DT.Rows(0).Item("Del")) Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "LimitWork")
            Return False
        End Try
    End Function

    Public Function StateMobileFac(ByVal Id As Long) As Boolean
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT [Confirm] FROM Mobile_ListFactorSell WHERE IdFactor =" & Id, ConectionBank)
                Dim State As Object
                State = cmd.ExecuteScalar
                If State Is DBNull.Value Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    StateMobile = -1
                    Return False
                Else
                    StateMobile = State
                    If State = 2 Then
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        MessageBox.Show("فاکتور مورد نظر تایید شده است و تغییر وضعیت امکانپذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    ElseIf State = 3 Then
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        MessageBox.Show("فاکتور مورد نظر به پیش فاکتور تبدیل شده است و تغییر وضعیت امکانپذیر نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    Else
                        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                        Return True
                    End If
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "StateMobileFac")
            StateMobile = -1
            Return False
        End Try
    End Function

    Public Sub TraceUser(ByVal IdUser As Long, ByVal D_Date As String, ByVal T_time As String, ByVal Form As String, ByVal Action As String, ByVal Disc As String, ByVal SystemDisc As String)
        Try
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using cmd As New SqlCommand("INSERT INTO TraceUser (IdUser,D_Date,T_Time,Form,[Action],Disc,SystemDisc) VALUES (@IdUser,@D_Date,@T_Time,@Form,@Action,@Disc,@SystemDisc)", ConectionBank)
                cmd.Parameters.AddWithValue("@IdUser", SqlDbType.BigInt).Value = IdUser
                cmd.Parameters.AddWithValue("@D_Date", SqlDbType.VarBinary).Value = Sec.StringEncrypt(D_Date, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@T_Time", SqlDbType.VarBinary).Value = Sec.StringEncrypt(T_time, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Form", SqlDbType.VarBinary).Value = Sec.StringEncrypt(Form, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Action", SqlDbType.VarBinary).Value = Sec.StringEncrypt(Action, key.CreateEncryptor)
                cmd.Parameters.AddWithValue("@Disc", SqlDbType.VarBinary).Value = If(String.IsNullOrEmpty(Disc), System.Data.SqlTypes.SqlBinary.Null, Sec.StringEncrypt(Disc, key.CreateEncryptor))
                cmd.Parameters.AddWithValue("@SystemDisc", SqlDbType.VarBinary).Value = If(String.IsNullOrEmpty(SystemDisc), System.Data.SqlTypes.SqlBinary.Null, Sec.StringEncrypt(SystemDisc, key.CreateEncryptor))
                cmd.ExecuteNonQuery()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "TraceUser")
        End Try

    End Sub

    Public Function ListKalaFactor(ByVal State As Long, ByVal LFactor As Long) As String
        Try
            Dim Query As String = ""
            If State = 0 Or State = 2 Then
                Query = "SELECT  KalaFactorBuy.IdAnbar,KalaFactorBuy.IdKala,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor  WHERE IdService IS NULL AND ListFactorBuy.IdFactor =" & LFactor & " UNION ALL SELECT IdAnbar=0,KalaFactorBuy.IdService As IdKala,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon FROM ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor WHERE IdService IS NOT NULL AND ListFactorBuy.IdFactor =" & LFactor
            ElseIf State = 1 Then
                Query = "SELECT  KalaFactorBackBuy.IdAnbar,KalaFactorBackBuy.IdKala,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor WHERE IdService IS NULL AND ListFactorBackBuy.IdFactor =" & LFactor & " UNION ALL SELECT IdAnbar=0,KalaFactorBackBuy.IdService As IdKala,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon FROM ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor  WHERE IdService IS NOT NULL AND ListFactorBackBuy.IdFactor =" & LFactor
            ElseIf State = 3 Or State = 5 Or State = 7 Then
                Query = "SELECT  KalaFactorSell.IdAnbar,KalaFactorSell.IdKala,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor WHERE IdService IS NULL AND ListFactorSell.IdFactor =" & LFactor & " UNION ALL SELECT IdAnbar=0,KalaFactorSell.IdService As IdKala,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor  WHERE IdService IS NOT NULL AND ListFactorSell.IdFactor =" & LFactor
            ElseIf State = 4 Then
                Query = "SELECT  KalaFactorBackSell.IdAnbar,KalaFactorBackSell.IDkala,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor WHERE IdService IS NULL AND ListFactorBackSell.IdFactor =" & LFactor & " UNION ALL SELECT IdAnbar=0,KalaFactorBackSell.IdService As IdKala,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon FROM ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor  WHERE IdService IS NOT NULL AND ListFactorBackSell.IdFactor =" & LFactor
            ElseIf State = 6 Then
                Query = "SELECT  KalaFactorDamage.IdAnbar,KalaFactorDamage.IdKala,KalaFactorDamage.KolCount, KalaFactorDamage.JozCount, KalaFactorDamage.Fe, DarsadDiscount=0,DarsadMon=0, KalaFactorDamage.Mon FROM  ListFactorDamage INNER JOIN KalaFactorDamage ON ListFactorDamage.IdFactor = KalaFactorDamage.IdFactor  WHERE ListFactorDamage.IdFactor =" & LFactor
            ElseIf State = 8 Then
                Query = "SELECT IdAnbar=0,KalaFactorService.IdService As Idkala,KalaFactorService.KolCount, JozCount=0, KalaFactorService.Fe, KalaFactorService.DarsadDiscount, KalaFactorService.DarsadMon, KalaFactorService.Mon FROM ListFactorService INNER JOIN KalaFactorService ON ListFactorService.IdFactor = KalaFactorService.IdFactor WHERE ListFactorService.IdFactor =" & LFactor
            End If

            Dim dt As New DataTable

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(Query, ConectionBank)
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Dim str As String = ""
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    str &= dt.Rows(i).Item("IdAnbar") & "," & dt.Rows(i).Item("IDkala") & "," & dt.Rows(i).Item("KolCount") & "," & dt.Rows(i).Item("JozCount") & "," & dt.Rows(i).Item("Fe") & "," & dt.Rows(i).Item("DarsadDiscount") & "," & dt.Rows(i).Item("DarsadMon") & "," & dt.Rows(i).Item("Mon") & "-"
                Next
                str = str.Substring(0, str.Length - 1)
                Return str
            Else
                Return ""
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "ListKalaFactor")
            Return ""
        End Try
    End Function
    Public Sub LimitMojody()
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Dim dr As SqlDataReader = Nothing
            Using CMD As New SqlCommand("SELECT ISNULL(MojodyBox,'True') As Box,ISNULL(MojodyBank,'True') As Bank,ISNULL(MojodyAnbar,'True') As Anbar, ISNULL(S10,'0') AS S10,ISNULL(S11,'0') AS S11,ISNULL(S22,'0') AS S22,ISNULL(S23,'0') AS S23,ISNULL(S24,'0') AS S24,ISNULL(S25,'0') AS S25,ISNULL(S26,'0') AS S26 FROM SettingProgram WHERE IdUser =" & Id_User, ConectionBank)
                dr = CMD.ExecuteReader
            End Using
            If dr.HasRows Then
                dr.Read()
                MBank = dr("Bank")
                MBox = dr("Box")
                MAnbar = dr("Anbar")
                LimitMonFac = CBool(dr("S10"))
                LimitDec = CBool(dr("S11"))
                LimitAdd = CBool(dr("S22"))
                LimitHajm = CBool(dr("S23"))
                LimitDate = CBool(dr("S25"))
                LimitNoSell = CBool(dr("S26"))
            Else
                MBank = False
                MBox = False
                MAnbar = False
                LimitMonFac = False
                LimitDec = False
                LimitAdd = False
                LimitHajm = False
                LimitDate = False
                LimitNoSell = False
            End If
            dr.Close()
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "LimitMojody")
            MBank = False
            MBox = False
            MAnbar = False
            LimitMonFac = False
            LimitDec = False
            LimitAdd = False
            LimitHajm = False
            LimitDate = False
            LimitNoSell = False
        End Try
    End Sub

    Public Sub GetInfoSystem()
        Try
            Dim str As String = ""
            StrGetChk = ""
            StrPayChk = ""
            StrMessage = ""
            StrLF = ""
            StrHF = ""
            StrBed = ""
            StrBes = ""

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT ISNULL(S27,'00000000000') AS S27 FROM SettingProgram WHERE IdUser =" & Id_User, ConectionBank)
                str = cmd.ExecuteScalar
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '////////////////////////////محاسبه چک دریافتی
            If Not (str(0).ToString = "0" And str(1).ToString = "0" And str(2).ToString = "0") Then
                Dim dat As String = ""
                Dim Con1 As String = ""
                Dim Con2 As String = ""
                Dim Con3 As String = ""
                ''''''''''''''''''''''''''''''''''''''''
                If str(0).ToString = "1" Then Con1 = "(PayDate ='" & GetDate() & "')"
                ''''''''''''''''''''''''''''''''''''''''
                If str(1).ToString <> "0" Then
                    dat = GetDate()
                    For i As Integer = 1 To CLng(str(1).ToString)
                        dat = DECDAY(dat)
                    Next
                    Con2 = "(PayDate <'" & GetDate() & "' AND PayDate >='" & dat & "')"
                End If
                ''''''''''''''''''''''''''''''''''''''''
                If str(2).ToString <> "0" Then
                    dat = GetDate()
                    For i As Integer = 1 To CLng(str(2).ToString)
                        dat = ADDDAY(dat)
                    Next
                    Con3 = "(PayDate >'" & GetDate() & "' AND PayDate <='" & dat & "')"
                End If
                ''''''''''''''''''''''''''''''''''''''''
                StrGetChk = "SELECT COUNT(Chk_Get_Pay.ID) As GetChk FROM Chk_Get_Pay WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =0) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =0) AND (" & Con1 & If(String.IsNullOrEmpty(Con1), Con2, If(String.IsNullOrEmpty(Con2), "", " OR " & Con2)) & If(String.IsNullOrEmpty(Con1) And String.IsNullOrEmpty(Con2), Con3, If(String.IsNullOrEmpty(Con3), "", " OR " & Con3)) & ")"
            End If

            '////////////////////////////محاسبه چک پرداختی
            If Not (str(3).ToString = "0" And str(4).ToString = "0" And str(5).ToString = "0") Then
                Dim dat As String = ""
                Dim Con1 As String = ""
                Dim Con2 As String = ""
                Dim Con3 As String = ""
                ''''''''''''''''''''''''''''''''''''''''
                If str(3).ToString = "1" Then Con1 = "(PayDate ='" & GetDate() & "')"
                ''''''''''''''''''''''''''''''''''''''''
                If str(4).ToString <> "0" Then
                    dat = GetDate()
                    For i As Integer = 1 To CLng(str(4).ToString)
                        dat = DECDAY(dat)
                    Next
                    Con2 = "(PayDate <'" & GetDate() & "' AND PayDate >='" & dat & "')"
                End If
                ''''''''''''''''''''''''''''''''''''''''
                If str(5).ToString <> "0" Then
                    dat = GetDate()
                    For i As Integer = 1 To CLng(str(5).ToString)
                        dat = ADDDAY(dat)
                    Next
                    Con3 = "(PayDate >'" & GetDate() & "' AND PayDate <='" & dat & "')"
                End If
                ''''''''''''''''''''''''''''''''''''''''
                StrPayChk = "SELECT COUNT(Chk_Get_Pay.ID) As PayChk FROM Chk_Get_Pay WHERE  (Chk_Get_Pay.Kind =1 AND Chk_Get_Pay.Current_Kind =1) AND (Chk_Get_Pay.Activ =1) AND (Chk_Get_Pay.Current_State  =0) AND (" & Con1 & If(String.IsNullOrEmpty(Con1), Con2, If(String.IsNullOrEmpty(Con2), "", " OR " & Con2)) & If(String.IsNullOrEmpty(Con1) And String.IsNullOrEmpty(Con2), Con3, If(String.IsNullOrEmpty(Con3), "", " OR " & Con3)) & ")"
            End If
            '////////////////////////////محاسبه حداقل نقطه سفارش
            If Not (str(6).ToString = "0") Then
                StrLF = "SELECT COUNT(EndData.Id) As LowKala FROM (SELECT AllKala.Id,AllKala.LF_Value,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount FROM (SELECT Define_Kala.Id,Define_Kala.LF_Value FROM Define_Kala  WHERE LF='True' AND Activ ='False') AS AllKala )As EndData WHERE LF_Value >=KolCount"
            End If

            '////////////////////////////محاسبه حداکثر نقطه سفارش
            If Not (str(7).ToString = "0") Then
                StrHF = "SELECT COUNT(EndData.Id) As HightKala FROM (SELECT AllKala.Id,AllKala.HF_Value,(SELECT ISNULL(SUM(AllKolCount.KolCount),0)  FROM (SELECT  ISNULL(SUM(Count_Kol),0) AS KolCount FROM  Define_PrimaryKala WHERE IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBuy.KolCount),0) AS KolCount FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE (KalaFactorBuy.Activ =1 and   ListFactorBuy.Activ =1 and ListFactorBuy.Stat =0) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackSell.KolCount),0) AS KolCount FROM  KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE (KalaFactorBackSell.Activ =1 and   ListFactorBackSell.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorSell.KolCount)*(-1),0) AS KolCount FROM  KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE (KalaFactorSell.Activ =1 and   ListFactorSell.Activ =1 and ListFactorSell.Stat =3) And IdKala =AllKala.id UNION ALL SELECT    ISNULL(SUM( KalaFactorBackBuy.KolCount)*(-1),0) AS KolCount FROM  KalaFactorBackBuy INNER JOIN listFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE (KalaFactorBackBuy.Activ =1 and   listFactorBackBuy.Activ =1 ) And IdKala =AllKala.id UNION ALL SELECT ISNULL(SUM( KalaFactorDamage.KolCount)*(-1),0) AS KolCount FROM  KalaFactorDamage INNER JOIN listFactorDamage ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor WHERE (KalaFactorDamage.Activ =1 and   ListFactorDamage.Activ =1 ) And IdKala =AllKala.id) AS AllKolCount)KolCount FROM (SELECT Define_Kala.Id,Define_Kala.HF_Value FROM Define_Kala  WHERE HF ='True' AND Activ ='False') AS AllKala )As EndData WHERE HF_Value <=KolCount"
            End If

            '////////////////////////////محاسبه وعده بدهکاران
            If Not (str(8).ToString = "0") Then
                StrBed = "SELECT IdFactor,EndData.Rate,MaxNewDate,d_date FROM (SELECT IdFactor,Rate,d_date,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec)-(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor,Wanted_Frosh.Rate,d_date FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor " & If(Kind_User = 0, " WHERE IdUser=" & Id_User, "") & ") As AllTime) As EndData  WHERE  (MonFac -Pay )>0"
            End If

            '////////////////////////////محاسبه وعده بستانکاران
            If Not (str(9).ToString = "0") Then
                StrBes = "SELECT IdFactor,EndData.Rate,MaxNewDate,d_date FROM (SELECT IdFactor,Rate,d_date,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorBuy  WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorBuy  WHERE ListFactorBuy.IdFactor  =AllTime.IdFactor)As MonFac,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitKharid WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitKharid  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk+MonSellChk),0)   FROM ListFactorBuy WHERE IdFactor= AllTime.IdFactor ) As Pay,(SELECT ISNULL(MAX(NewDate),'') FROM TimeKharid WHERE TimeKharid.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Kharid.IdFactor,Wanted_Kharid.Rate,d_date FROM  Wanted_Kharid INNER JOIN ListFactorBuy ON Wanted_Kharid.IdFactor = ListFactorBuy.IdFactor " & If(Kind_User = 0, " WHERE IdUser=" & Id_User, "") & ") As AllTime) As EndData  WHERE  (MonFac -Pay )>0 "
            End If

            '////////////////////////////محاسبه پیام های دریافتی
            If Not (str(10).ToString = "0") Then
                StrMessage = "SELECT COUNT(Id) As GetMessage FROM MessageCenter WHERE Reciver_IdUser =" & Id_User & " AND R_Date <='" & GetDate() & "' AND Chk ='False'"
            End If
        Catch ex As Exception
            StrGetChk = ""
            StrPayChk = ""
            StrMessage = ""
            StrLF = ""
            StrHF = ""
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetInfoSystem")
        End Try
    End Sub
    Public Function GetCostProduction(ByVal IdKala As Long, ByVal Co As Double) As Double
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()



            Using CMD As New SqlCommand(String.Format("SELECT [dbo].[GetCost]({0},{1},N'',N'','True') as EndPrice", IdKala, Co), ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetCostProduction")
            Return 0
        End Try
    End Function

    Public Function GetAreEditOrDelete(ByVal IdF As Integer) As Integer
        Try
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()



            Using CMD As New SqlCommand(String.Format("if (select count(Id) from MeldProduction where id={0})>0 begin select 1 as Ret end else begin select 0 as Ret end", IdF), ConectionBank)
                Dim Res As Double = CMD.ExecuteScalar
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Return Res
            End Using

        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "PublicFunction", "GetAreEditOrDelete")
            Return 0
        End Try
    End Function

End Module
