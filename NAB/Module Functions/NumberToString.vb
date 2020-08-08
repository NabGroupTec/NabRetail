Imports System.Globalization
Public Class NumberToString

    Function DateToPersianNonvertor(ByVal dt As Date) As String
        Dim pdt As New PersianCalendar
        Dim str As String
        str = PersianWeekDays(dt)
        str &= pdt.GetDayOfMonth(dt) & " ام "
        str &= PersianMounthName(dt) & " " & " ماه "
        str &= " سال " & pdt.GetYear(dt)
        Return str
    End Function

    Function PersianWeekDays(ByVal dt As Date) As String
        Dim pdt As New PersianCalendar
        Dim str As String = ""
        Select Case pdt.GetDayOfWeek(dt)
            Case DayOfWeek.Saturday
                str = "شنبه "
            Case DayOfWeek.Sunday
                str = "یک شنبه "
            Case DayOfWeek.Monday
                str = "دوشنبه "
            Case DayOfWeek.Tuesday
                str = "سه شنبه "
            Case DayOfWeek.Wednesday
                str = "چهارشنبه "
            Case DayOfWeek.Thursday
                str = " پنج شنبه"
            Case DayOfWeek.Friday
                str = " جمعه"
        End Select
        Return str
    End Function

    Function PersianMounthName(ByVal dt As Date) As String
        Dim pdt As New PersianCalendar
        Dim str As String = ""
        Select Case pdt.GetMonth(dt)
            Case 1
                str = "فروردین"
            Case 2
                str = "اردیبهشت"
            Case 3
                str = "خرداد"
            Case 4
                str = "تیر"
            Case 5
                str = "مرداد"
            Case 6
                str = "شهریور"
            Case 7
                str = "مهر"
            Case 8
                str = "آبان"
            Case 9
                str = "آذر"
            Case 10
                str = "دی"
            Case 11
                str = "بهمن"
            Case 12
                str = "اسفند"
        End Select
        Return str
    End Function

    Function PersianToDateConvertor(ByVal str As String) As String
        Dim year As Integer = str.Remove(4, str.Length - 4)
        Dim str2 As String
        str2 = str.Remove(0, 5)
        If Left(str2, 2).EndsWith("/") Then
            str2 = Left(str2, 1)
        Else
            str2 = Left(str2, 2)
        End If
        Dim str3 As String
        Dim month As Integer = str2
        If Right(str, 2).StartsWith("/") Then
            str3 = Right(str, 1)
        Else
            str3 = Right(str, 2)
        End If
        Dim day As Integer = str3
        Dim cal As New PersianCalendar
        Return cal.ToDateTime(year, month, day, 12, 0, 0, 0, PersianCalendar.PersianEra)
    End Function

    Public Function Num2Str(ByVal Number_input As String) As String
        Dim i, l As Byte
        Dim Number As Long
        Dim harf As String
        For i = 1 To Len(Number_input)
            harf = Mid(Number_input, i, 1)
            If IsNumeric(harf) = True Then Number = Number & harf
        Next
        If Number = 0 Then
            Return "صفر"
        End If
        Dim Flag As Boolean
        Dim s As String
        Dim k(0 To 5) As Long
        s = Str(Number)
        l = Len(s)
        If l > 15 Then
            Return ""
        End If
        For i = 1 To 15 - l
            s = "0" & s
        Next i
        For i = 1 To Int((l / 3) + 0.99)
            k(5 - i + 1) = Val(Mid(s, 3 * (5 - i) + 1, 3))
        Next i
        Flag = False
        s = ""
        For i = 1 To 5
            If k(i) <> 0 Then
                Select Case i
                    Case 1
                        s = s & Three(k(i)) & " تريليون"
                        Flag = True
                    Case 2
                        s = s & IIf(Flag = True, " و ", "") & Three(k(i)) & " ميليارد"
                        Flag = True
                    Case 3
                        s = s & IIf(Flag = True, " و ", "") & Three(k(i)) & " ميليون"
                        Flag = True
                    Case 4
                        s = s & IIf(Flag = True, " و ", "") & Three(k(i)) & " هزار"
                        Flag = True
                    Case 5
                        s = s & IIf(Flag = True, " و ", "") & Three(k(i))
                End Select
            End If
        Next i
        Return s
    End Function
    Private Function Three(ByVal Number As Integer) As String
        Dim s As String = ""
        Dim i, l As Long
        Dim h(0 To 3) As Byte
        l = Len(Trim(Str(Number)))
        If Number = 0 Then
            Return ""
        End If
        If Number = 100 Then
            Return "يكصد"
        End If
        If l = 2 Then h(1) = 0
        If l = 1 Then
            h(1) = 0
            h(2) = 0
        End If
        For i = 1 To l
            h(3 - i + 1) = Mid(Trim(Str(Number)), l - i + 1, 1)
        Next i
        Select Case h(1)
            Case 1
                s = "يكصد"
            Case 2
                s = "دويست"
            Case 3
                s = "سيصد"
            Case 4
                s = "چهارصد"
            Case 5
                s = "پانصد"
            Case 6
                s = "ششصد"
            Case 7
                s = "هفتصد"
            Case 8
                s = "هشتصد"
            Case 9
                s = "نهصد"
        End Select
        Select Case h(2)
            Case 1
                Select Case h(3)
                    Case 0
                        s = s & " و " & "ده"
                    Case 1
                        s = s & " و " & "يازده"
                    Case 2
                        s = s & " و " & "دوازده"
                    Case 3
                        s = s & " و " & "سيزده"
                    Case 4
                        s = s & " و " & "چهارده"
                    Case 5
                        s = s & " و " & "پانزده"
                    Case 6
                        s = s & " و " & "شانزده"
                    Case 7
                        s = s & " و " & "هفده"
                    Case 8
                        s = s & " و " & "هجده"
                    Case 9
                        s = s & " و " & "نوزده"
                End Select
            Case 2
                s = s & " و " & "بيست"
            Case 3
                s = s & " و " & "سي"
            Case 4
                s = s & " و " & "چهل"
            Case 5
                s = s & " و " & "پنجاه"
            Case 6
                s = s & " و " & "شصت"
            Case 7
                s = s & " و " & "هفتاد"
            Case 8
                s = s & " و " & "هشتاد"
            Case 9
                s = s & " و " & "نود"
        End Select
        If h(2) <> 1 Then
            Select Case h(3)
                Case 1
                    s = s & " و " & "يك"
                Case 2
                    s = s & " و " & "دو"
                Case 3
                    s = s & " و " & "سه"
                Case 4
                    s = s & " و " & "چهار"
                Case 5
                    s = s & " و " & "پنج"
                Case 6
                    s = s & " و " & "شش"
                Case 7
                    s = s & " و " & "هفت"
                Case 8
                    s = s & " و " & "هشت"
                Case 9
                    s = s & " و " & "نه"
            End Select
        End If
        s = IIf(l < 3, Right(s, Len(s) - 3), s)
        Return s
    End Function
End Class
