Public Class Security
    Protected k_iv() As Byte = {110, 2, 40, 7, 58, 14, 114, 5}
    Protected k_key() As Byte = {255, 110, 78, 3, 0, 12, 124, 1}

    ReadOnly Property Kiv() As Byte()
        Get
            Return k_iv
        End Get
    End Property
    ReadOnly Property Kkey() As Byte()
        Get
            Return k_key
        End Get
    End Property

    Public Function StringEncrypt(ByVal txt As String, ByVal key As System.Security.Cryptography.ICryptoTransform) As Byte()
        Using _
                memoutput As New System.IO.MemoryStream, _
                cstrm As New System.Security.Cryptography.CryptoStream(memoutput, key, System.Security.Cryptography.CryptoStreamMode.Write), _
                writer As New System.IO.StreamWriter(cstrm)
            writer.Write(txt)
            writer.Close()
            cstrm.Close()
            Return memoutput.ToArray
        End Using
    End Function

    Public Function StringDecrypt(ByVal cryptodata() As Byte, ByVal key As System.Security.Cryptography.ICryptoTransform) As String
        Using _
            meminput As New System.IO.MemoryStream(cryptodata), _
            cstrm As New System.Security.Cryptography.CryptoStream(meminput, key, System.Security.Cryptography.CryptoStreamMode.Read), _
            reader As New System.IO.StreamReader(cstrm)
            Return reader.ReadToEnd
        End Using
    End Function
End Class
