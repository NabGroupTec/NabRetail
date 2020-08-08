Imports Microsoft.Win32

Public Class FrmLanguageSetting

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim regVersion As RegistryKey
            regVersion = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)

            If regVersion Is Nothing Then
                MessageBox.Show("اطلاعات مربوط به ساختار زبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                regVersion.SetValue("iCalendarType", "2")
                regVersion.SetValue("iCountry", "981")
                regVersion.SetValue("iCurrDigits", "2")
                regVersion.SetValue("iCurrency", "2")
                regVersion.SetValue("iDate", "2")
                regVersion.SetValue("iDigits", "2")
                regVersion.SetValue("iFirstDayOfWeek", "5")
                regVersion.SetValue("iFirstWeekOfYear", "0")
                regVersion.SetValue("iLZero", "1")
                regVersion.SetValue("iMeasure", "0")
                regVersion.SetValue("iNegCurr", "1")
                regVersion.SetValue("iNegNumber", "3")
                regVersion.SetValue("iPaperSize", "9")
                regVersion.SetValue("iTime", "0")
                regVersion.SetValue("iTimePrefix", "0")
                regVersion.SetValue("iTLZero", "1")
                regVersion.SetValue("Locale", "00000429")
                regVersion.SetValue("LocaleName", "fa-IR")
                regVersion.SetValue("NumShape", "0")
                regVersion.SetValue("s1159", "ق.ظ")
                regVersion.SetValue("s2359", "ب.ظ")
                regVersion.SetValue("sCountry", "Iran")
                regVersion.SetValue("sCurrency", "ريال")
                regVersion.SetValue("sDate", "/")
                regVersion.SetValue("sDecimal", ".")
                regVersion.SetValue("sGrouping", "3;0")
                regVersion.SetValue("sLanguage", "FAR")
                regVersion.SetValue("sList", ";")
                regVersion.SetValue("sLongDate", "dddd, MMMM dd, yyyy")
                regVersion.SetValue("sMonDecimalSep", "/")
                regVersion.SetValue("sMonGrouping", "3;0")
                regVersion.SetValue("sMonThousandSep", ",")
                regVersion.SetValue("sNativeDigits", "۰۱۲۳۴۵۶۷۸۹")
                regVersion.SetValue("sNegativeSign", "-")
                regVersion.SetValue("sPositiveSign", "")
                regVersion.SetValue("sShortDate", "yyyy/MM/dd")
                regVersion.SetValue("sShortTime", "hh:mm tt")
                regVersion.SetValue("sThousand", ",")
                regVersion.SetValue("sTime", ":")
                regVersion.SetValue("sTimeFormat", "hh:mm:ss tt")
                regVersion.SetValue("sYearMonth", "MMMM, yyyy")
            End If
            regVersion.Close()
            MessageBox.Show("تغییر زبان به فارسی (ایران) انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmLanguageSetting", "Farsi")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim regVersion As RegistryKey
            regVersion = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)

            If regVersion Is Nothing Then
                MessageBox.Show("اطلاعات مربوط به ساختار زبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                regVersion.SetValue("iCalendarType", "2")
                regVersion.SetValue("iCountry", "964")
                regVersion.SetValue("iCurrDigits", "2")
                regVersion.SetValue("iCurrency", "2")
                regVersion.SetValue("iDate", "2")
                regVersion.SetValue("iDigits", "2")
                regVersion.SetValue("iFirstDayOfWeek", "5")
                regVersion.SetValue("iFirstWeekOfYear", "0")
                regVersion.SetValue("iLZero", "1")
                regVersion.SetValue("iMeasure", "0")
                regVersion.SetValue("iNegCurr", "1")
                regVersion.SetValue("iNegNumber", "3")
                regVersion.SetValue("iPaperSize", "9")
                regVersion.SetValue("iTime", "0")
                regVersion.SetValue("iTimePrefix", "0")
                regVersion.SetValue("iTLZero", "1")
                regVersion.SetValue("Locale", "00000801")
                regVersion.SetValue("LocaleName", "ar-IQ")
                regVersion.SetValue("NumShape", "0")
                regVersion.SetValue("s1159", "AM")
                regVersion.SetValue("s2359", "PM")
                regVersion.SetValue("sCountry", "Iraq")
                regVersion.SetValue("sCurrency", "د.ع.‏")
                regVersion.SetValue("sDate", "/")
                regVersion.SetValue("sDecimal", ".")
                regVersion.SetValue("sGrouping", "3;0")
                regVersion.SetValue("sLanguage", "ARI")
                regVersion.SetValue("sList", ";")
                regVersion.SetValue("sLongDate", "dddd, MMMM dd, yyyy")
                regVersion.SetValue("sMonDecimalSep", "/")
                regVersion.SetValue("sMonGrouping", "3;0")
                regVersion.SetValue("sMonThousandSep", ",")
                regVersion.SetValue("sNativeDigits", "۰۱۲۳۴۵۶۷۸۹")
                regVersion.SetValue("sNegativeSign", "-")
                regVersion.SetValue("sPositiveSign", "")
                regVersion.SetValue("sShortDate", "yyyy/MM/dd")
                regVersion.SetValue("sShortTime", "hh:mm tt")
                regVersion.SetValue("sThousand", ",")
                regVersion.SetValue("sTime", ":")
                regVersion.SetValue("sTimeFormat", "hh:mm:ss tt")
                regVersion.SetValue("sYearMonth", "MMMM, yyyy")
            End If
            regVersion.Close()
            MessageBox.Show("تغییر زبان به عربی (عراق) انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmLanguageSetting", "Arabic (Iraq)")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim regVersion As RegistryKey
            regVersion = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)

            If regVersion Is Nothing Then
                MessageBox.Show("اطلاعات مربوط به ساختار زبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                regVersion.SetValue("iCalendarType", "2")
                regVersion.SetValue("iCountry", "962")
                regVersion.SetValue("iCurrDigits", "2")
                regVersion.SetValue("iCurrency", "2")
                regVersion.SetValue("iDate", "2")
                regVersion.SetValue("iDigits", "2")
                regVersion.SetValue("iFirstDayOfWeek", "5")
                regVersion.SetValue("iFirstWeekOfYear", "0")
                regVersion.SetValue("iLZero", "1")
                regVersion.SetValue("iMeasure", "0")
                regVersion.SetValue("iNegCurr", "1")
                regVersion.SetValue("iNegNumber", "3")
                regVersion.SetValue("iPaperSize", "9")
                regVersion.SetValue("iTime", "0")
                regVersion.SetValue("iTimePrefix", "0")
                regVersion.SetValue("iTLZero", "1")
                regVersion.SetValue("Locale", "00002C01")
                regVersion.SetValue("LocaleName", "ar-JO")
                regVersion.SetValue("NumShape", "0")
                regVersion.SetValue("s1159", "AM")
                regVersion.SetValue("s2359", "PM")
                regVersion.SetValue("sCountry", "Jordan")
                regVersion.SetValue("sCurrency", "د.ا.‏")
                regVersion.SetValue("sDate", "/")
                regVersion.SetValue("sDecimal", ".")
                regVersion.SetValue("sGrouping", "3;0")
                regVersion.SetValue("sLanguage", "ARJ")
                regVersion.SetValue("sList", ";")
                regVersion.SetValue("sLongDate", "dddd, MMMM dd, yyyy")
                regVersion.SetValue("sMonDecimalSep", "/")
                regVersion.SetValue("sMonGrouping", "3;0")
                regVersion.SetValue("sMonThousandSep", ",")
                regVersion.SetValue("sNativeDigits", "۰۱۲۳۴۵۶۷۸۹")
                regVersion.SetValue("sNegativeSign", "-")
                regVersion.SetValue("sPositiveSign", "")
                regVersion.SetValue("sShortDate", "yyyy/MM/dd")
                regVersion.SetValue("sShortTime", "hh:mm tt")
                regVersion.SetValue("sThousand", ",")
                regVersion.SetValue("sTime", ":")
                regVersion.SetValue("sTimeFormat", "hh:mm:ss tt")
                regVersion.SetValue("sYearMonth", "MMMM, yyyy")
            End If
            regVersion.Close()
            MessageBox.Show("تغییر زبان به عربی (اردن) انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmLanguageSetting", "Arabic (Jordan)")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim regVersion As RegistryKey
            regVersion = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)

            If regVersion Is Nothing Then
                MessageBox.Show("اطلاعات مربوط به ساختار زبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                regVersion.SetValue("iCalendarType", "2")
                regVersion.SetValue("iCountry", "965")
                regVersion.SetValue("iCurrDigits", "2")
                regVersion.SetValue("iCurrency", "2")
                regVersion.SetValue("iDate", "2")
                regVersion.SetValue("iDigits", "2")
                regVersion.SetValue("iFirstDayOfWeek", "5")
                regVersion.SetValue("iFirstWeekOfYear", "0")
                regVersion.SetValue("iLZero", "1")
                regVersion.SetValue("iMeasure", "0")
                regVersion.SetValue("iNegCurr", "1")
                regVersion.SetValue("iNegNumber", "3")
                regVersion.SetValue("iPaperSize", "9")
                regVersion.SetValue("iTime", "0")
                regVersion.SetValue("iTimePrefix", "0")
                regVersion.SetValue("iTLZero", "1")
                regVersion.SetValue("Locale", "00003401")
                regVersion.SetValue("LocaleName", "ar-KW")
                regVersion.SetValue("NumShape", "0")
                regVersion.SetValue("s1159", "AM")
                regVersion.SetValue("s2359", "PM")
                regVersion.SetValue("sCountry", "Kuwait")
                regVersion.SetValue("sCurrency", "د.ك.‏")
                regVersion.SetValue("sDate", "/")
                regVersion.SetValue("sDecimal", ".")
                regVersion.SetValue("sGrouping", "3;0")
                regVersion.SetValue("sLanguage", "ARK")
                regVersion.SetValue("sList", ";")
                regVersion.SetValue("sLongDate", "dddd, MMMM dd, yyyy")
                regVersion.SetValue("sMonDecimalSep", "/")
                regVersion.SetValue("sMonGrouping", "3;0")
                regVersion.SetValue("sMonThousandSep", ",")
                regVersion.SetValue("sNativeDigits", "۰۱۲۳۴۵۶۷۸۹")
                regVersion.SetValue("sNegativeSign", "-")
                regVersion.SetValue("sPositiveSign", "")
                regVersion.SetValue("sShortDate", "yyyy/MM/dd")
                regVersion.SetValue("sShortTime", "hh:mm tt")
                regVersion.SetValue("sThousand", ",")
                regVersion.SetValue("sTime", ":")
                regVersion.SetValue("sTimeFormat", "hh:mm:ss tt")
                regVersion.SetValue("sYearMonth", "MMMM, yyyy")
            End If
            regVersion.Close()
            MessageBox.Show("تغییر زبان به عربی (کویت) انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmLanguageSetting", "Arabic (Kuwait)")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim regVersion As RegistryKey
            regVersion = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)

            If regVersion Is Nothing Then
                MessageBox.Show("اطلاعات مربوط به ساختار زبان وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                regVersion.SetValue("iCalendarType", "1")
                regVersion.SetValue("iCountry", "1")
                regVersion.SetValue("iCurrDigits", "2")
                regVersion.SetValue("iCurrency", "3")
                regVersion.SetValue("iDate", "2")
                regVersion.SetValue("iDigits", "2")
                regVersion.SetValue("iFirstDayOfWeek", "6")
                regVersion.SetValue("iFirstWeekOfYear", "0")
                regVersion.SetValue("iLZero", "1")
                regVersion.SetValue("iMeasure", "0")
                regVersion.SetValue("iNegCurr", "5")
                regVersion.SetValue("iNegNumber", "1")
                regVersion.SetValue("iPaperSize", "1")
                regVersion.SetValue("iTime", "0")
                regVersion.SetValue("iTimePrefix", "0")
                regVersion.SetValue("iTLZero", "0")
                regVersion.SetValue("Locale", "00000409")
                regVersion.SetValue("LocaleName", "en-US")
                regVersion.SetValue("NumShape", "1")
                regVersion.SetValue("s1159", "AM")
                regVersion.SetValue("s2359", "PM")
                regVersion.SetValue("sCountry", "United States")
                regVersion.SetValue("sCurrency", "$")
                regVersion.SetValue("sDate", "/")
                regVersion.SetValue("sDecimal", ".")
                regVersion.SetValue("sGrouping", "3;0")
                regVersion.SetValue("sLanguage", "ENU")
                regVersion.SetValue("sList", ",")
                regVersion.SetValue("sLongDate", "dddd, MMMM dd, yyyy")
                regVersion.SetValue("sMonDecimalSep", "/")
                regVersion.SetValue("sMonGrouping", "3;0")
                regVersion.SetValue("sMonThousandSep", ",")
                regVersion.SetValue("sNativeDigits", "0123456789")
                regVersion.SetValue("sNegativeSign", "-")
                regVersion.SetValue("sPositiveSign", "")
                regVersion.SetValue("sShortDate", "yyyy/MM/dd")
                regVersion.SetValue("sShortTime", "hh:mm tt")
                regVersion.SetValue("sThousand", ",")
                regVersion.SetValue("sTime", ":")
                regVersion.SetValue("sTimeFormat", "hh:mm:ss tt")
                regVersion.SetValue("sYearMonth", "MMMM, yyyy")
            End If
            regVersion.Close()
            MessageBox.Show("تغییر زبان به انگلیسی (ایالات متحده) انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmLanguageSetting", "English (United States)")
        End Try
    End Sub

    Private Sub FrmLanguageSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
    End Sub
End Class
