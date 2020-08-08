Public Class INIFile
    Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private mIniFileName As String

    Public Property FileName() As String
        Get
            FileName = mIniFileName
        End Get
        Set(ByVal Value As String)
            If Dir(Value, FileAttribute.Normal) = "" Then
                FileOpen(1, Value, OpenMode.Output)
                FileClose(1)
            End If
            mIniFileName = Value
        End Set
    End Property

    Public Function GetValue(ByVal Section As String, ByVal Key As String, Optional ByVal DefaultValue As String = "") As String
        Try
            Dim Value As String = ""
            Dim retval As String = ""
            Dim x As Short
            retval = New String(Chr(0), 255)
            x = GetPrivateProfileString(Section, Key, DefaultValue, retval, Len(retval), mIniFileName)
            GetValue = Trim(Left(retval, x))
        Catch ex As Exception
            GetValue = DefaultValue
        End Try
    End Function

    Public Function WriteValue(ByVal Section As String, ByVal Key As String, ByVal Value As String) As Boolean
        Try
            Dim x As Short = 0
            x = WritePrivateProfileString(Section, Key, Value, mIniFileName)
            If x <> 0 Then WriteValue = True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllSections() As Collection
        Dim Value, retval As String
        Dim x As Short
        Dim S() As String
        Dim i As Short
        retval = New String(Chr(0), 255)
        x = GetPrivateProfileString(vbNullString, "", "", retval, Len(retval), mIniFileName)
        Value = Trim(Left(retval, x))
        S = Split(Value, Chr(0))
        GetAllSections = New Collection
        With GetAllSections
            For i = LBound(S) To UBound(S)
                If S(i) <> "" Then .Add(S(i))
            Next
        End With
    End Function

    Public Function GetAllKeys(ByVal Section As String) As Collection
        Dim Value, retval As String
        Dim x As Short
        Dim S() As String
        Dim i As Short
        retval = New String(Chr(0), 255)
        x = GetPrivateProfileString(Section, vbNullString, "", retval, Len(retval), mIniFileName)
        Value = Trim(Left(retval, x))
        S = Split(Value, Chr(0))
        GetAllKeys = New Collection
        With GetAllKeys
            For i = LBound(S) To UBound(S)
                If S(i) <> "" Then .Add(S(i))
            Next
        End With
    End Function

    Public Function DeleteSection(ByVal Section As String) As Boolean
        Try
            Dim x As Short
            x = WritePrivateProfileString(Section, vbNullString, "", mIniFileName)
            If x <> 0 Then DeleteSection = True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteKey(ByVal Section As String, ByVal Key As String) As Boolean
        Try
            Dim x As Short
            x = WritePrivateProfileString(Section, Key, vbNullString, mIniFileName)
            If x <> 0 Then DeleteKey = True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
