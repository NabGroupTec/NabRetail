Imports System.Data.SqlClient
Public Class User_Access
    Dim path As String = ""

    Private Sub User_Access_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub User_Access_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        If Not UCase(NamUser) = "ADMIN" Then
            MessageBox.Show("حق دسترسی به این بخش را دارد Admin فقط کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Me.GetAccess()
    End Sub

    Private Sub GetAccess()
        Me.Enabled = False
        TV.Nodes.Clear()
        Dim dt As New DataTable
        dt.Clear()
        If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

        Using cmd As New SqlCommand("SELECT  Define_User.Nam,User_Access.*  FROM  User_Access INNER JOIN Define_User ON Define_User.Id =User_Access.Id ORDER By User_Access.Id", ConectionBank)
            dt.Load(cmd.ExecuteReader())
        End Using

        If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

        For i As Integer = 0 To dt.Rows.Count - 1
            CreateTree(dt.Rows(i))
        Next i
        Button3.Enabled = False
        Me.Enabled = True
    End Sub
    Private Sub CreateTree(ByVal Row As DataRow)
        Try
            Dim TmpStr As String = ""
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            ''''''''''''''''''''''''''''''''''''''''
            TV.Nodes.Insert(0, "کد " & Row.Item("Id") & " - " & Row.Item("Nam"))
            TV.Nodes(0).Checked = If(Sec.StringDecrypt(Row.Item("F1"), key.CreateDecryptor) = "1", True, False)

            '*******************************   تعاریف

            TV.Nodes(0).Nodes.Insert(1, "Define", "تعاریف")
            TV.Nodes(0).Nodes("Define").Checked = If(Sec.StringDecrypt(Row.Item("F2"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''تعاریف-مناطق

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_City", "مناطق")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Checked = If(Sec.StringDecrypt(Row.Item("F3"), key.CreateDecryptor) = "1", True, False)

            '///////////////////////////////////////////////////////////////
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes.Insert(3, "Define_City_Ostan", "استان")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes.Insert(4, "Define_City_Ostan_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes.Insert(4, "Define_City_Ostan_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes.Insert(4, "Define_City_Ostan_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F4"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes("Define_City_Ostan_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes("Define_City_Ostan_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes("Define_City_Ostan_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            ''''''''''''

            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes.Insert(3, "Define_City_City", "شهرستان")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes.Insert(4, "Define_City_City_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes.Insert(4, "Define_City_City_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes.Insert(4, "Define_City_City_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F5"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes("Define_City_City_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes("Define_City_City_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes("Define_City_City_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            ''''''''''''

            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes.Insert(3, "Define_City_Part", "مسیر")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes.Insert(4, "Define_City_Part_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes.Insert(4, "Define_City_Part_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes.Insert(4, "Define_City_Part_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F6"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes("Define_City_Part_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes("Define_City_Part_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes("Define_City_Part_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-گروهای ویژه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_GroupP", "گروه های ویژه")
            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Nodes.Insert(3, "Define_GroupP_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Nodes.Insert(3, "Define_GroupP_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Nodes.Insert(3, "Define_GroupP_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F7"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Nodes("Define_GroupP_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Nodes("Define_GroupP_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_GroupP").Nodes("Define_GroupP_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            ''''''''''''''''''' تعاریف-طرف حساب موقت

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_TmpPeople", "طرف حساب موقت")
            TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Nodes.Insert(3, "Define_TmpPeople_Ok", "تایید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Nodes.Insert(3, "Define_TmpPeople_Del", "حذف")

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F144"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Nodes("Define_TmpPeople_Ok").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Nodes("Define_TmpPeople_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Nodes("Define_TmpPeople_Ok").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_TmpPeople").Nodes("Define_TmpPeople_Del").Checked = False
            End Try

            '''''''''''''''''''تعاریف-طرف حساب

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_People", "طرف حساب")
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes.Insert(3, "Define_People_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes.Insert(3, "Define_People_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes.Insert(3, "Define_People_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes.Insert(3, "Define_People_Print", "چاپ لیست")
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes.Insert(3, "Define_People_Active", "فعال سازی")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F37"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            Try
                TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Print").Checked = False
            End Try

            Try
                TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Active").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Active").Checked = False
            End Try

            '''''''''''''''''''تعاریف-پارت

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Part", "پارت")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes.Insert(3, "Define_Part_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes.Insert(3, "Define_Part_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes.Insert(3, "Define_Part_Edit", "ویرایش")

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F115"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))

                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Del").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Edit").Checked = False
            End Try

            '''''''''''''''''''تعاریف-مامور توزیع و راننده

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Driver", "مامور توزیع و راننده")
            Try
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Checked = If(Sec.StringDecrypt(Row.Item("F117"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Checked = False
            End Try

            '///////////////////////////////////////////////////////////////
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes.Insert(3, "Define_Driver_R", "مامور توزیع")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes.Insert(4, "Define_Driver_R_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes.Insert(4, "Define_Driver_R_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes.Insert(4, "Define_Driver_R_Edit", "ویرایش")

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F118"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Del").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Edit").Checked = False
            End Try

            ''''''''''''

            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes.Insert(3, "Define_Driver_D", "راننده")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes.Insert(4, "Define_Driver_D_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes.Insert(4, "Define_Driver_D_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes.Insert(4, "Define_Driver_D_Edit", "ویرایش")

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F119"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Del").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Edit").Checked = False
            End Try

            ''''''''''''

            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes.Insert(3, "Define_Driver_Car", "وسیله حمل")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes.Insert(4, "Define_Driver_Car_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes.Insert(4, "Define_Driver_Car_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes.Insert(4, "Define_Driver_Car_Edit", "ویرایش")

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F120"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Del").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Edit").Checked = False
            End Try

            '''''''''''''''''''تعاریف-صندوق

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Box", "صندوق")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Nodes.Insert(3, "Define_Box_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Nodes.Insert(3, "Define_Box_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Nodes.Insert(3, "Define_Box_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F36"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Nodes("Define_Box_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Nodes("Define_Box_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Box").Nodes("Define_Box_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-بانک

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Bank", "بانک")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Nodes.Insert(3, "Define_Bank_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Nodes.Insert(3, "Define_Bank_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Nodes.Insert(3, "Define_Bank_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F35"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Nodes("Define_Bank_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Nodes("Define_Bank_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Bank").Nodes("Define_Bank_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-لیست بانکها

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_OtherBank", "لیست بانکها")
            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Nodes.Insert(3, "Define_OtherBank_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Nodes.Insert(3, "Define_OtherBank_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Nodes.Insert(3, "Define_OtherBank_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F34"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Nodes("Define_OtherBank_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Nodes("Define_OtherBank_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_OtherBank").Nodes("Define_OtherBank_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-دسته چک

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Manage_Chk_Bank", "دسته چک")
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes.Insert(3, "Manage_Chk_Bank_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes.Insert(3, "Manage_Chk_Bank_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes.Insert(3, "Manage_Chk_Bank_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes.Insert(3, "Manage_Chk_Bank_Change", "تغییر وضعیت")
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes.Insert(3, "Manage_Chk_Bank_Print", "چاپ لیست")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F33"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Change").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-سرمایه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Sarmayeh", "سرمایه گذار")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Checked = If(Sec.StringDecrypt(Row.Item("F30"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes.Insert(3, "Define_Sarmayeh_One", "گروه اصلی")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes.Insert(4, "Define_Sarmayeh_One_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes.Insert(4, "Define_Sarmayeh_One_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes.Insert(4, "Define_Sarmayeh_One_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F31"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes("Define_Sarmayeh_One_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes("Define_Sarmayeh_One_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes("Define_Sarmayeh_One_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes.Insert(3, "Define_Sarmayeh_Two", "سرمایه گذار")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes.Insert(4, "Define_Sarmayeh_Two_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes.Insert(4, "Define_Sarmayeh_Two_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes.Insert(4, "Define_Sarmayeh_Two_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F32"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes("Define_Sarmayeh_Two_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes("Define_Sarmayeh_Two_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes("Define_Sarmayeh_Two_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-اموال

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Amval", "اموال")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Checked = If(Sec.StringDecrypt(Row.Item("F27"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes.Insert(3, "Define_Amval_One", "گروه اصلی")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes.Insert(4, "Define_Amval_One_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes.Insert(4, "Define_Amval_One_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes.Insert(4, "Define_Amval_One_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F28"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes("Define_Amval_One_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes("Define_Amval_One_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes("Define_Amval_One_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes.Insert(3, "Define_Amval_Two", "اموال")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes.Insert(4, "Define_Amval_Two_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes.Insert(4, "Define_Amval_Two_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes.Insert(4, "Define_Amval_Two_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F29"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes("Define_Amval_Two_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes("Define_Amval_Two_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes("Define_Amval_Two_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-هزینه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Charge", "هزینه")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Checked = If(Sec.StringDecrypt(Row.Item("F24"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes.Insert(3, "Define_Charge_One", "گروه اصلی")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes.Insert(4, "Define_Charge_One_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes.Insert(4, "Define_Charge_One_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes.Insert(4, "Define_Charge_One_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F25"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes("Define_Charge_One_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes("Define_Charge_One_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes("Define_Charge_One_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes.Insert(3, "Define_Charge_Two", "هزینه")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes.Insert(4, "Define_Charge_Two_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes.Insert(4, "Define_Charge_Two_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes.Insert(4, "Define_Charge_Two_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F26"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes("Define_Charge_Two_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes("Define_Charge_Two_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes("Define_Charge_Two_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-درآمد

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Daramad", "درآمد")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Checked = If(Sec.StringDecrypt(Row.Item("F21"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes.Insert(3, "Define_Daramad_One", "گروه اصلی")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes.Insert(4, "Define_Daramad_One_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes.Insert(4, "Define_Daramad_One_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes.Insert(4, "Define_Daramad_One_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F22"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes("Define_Daramad_One_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes("Define_Daramad_One_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes("Define_Daramad_One_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes.Insert(3, "Define_Daramad_Two", "درآمد")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes.Insert(4, "Define_Daramad_Two_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes.Insert(4, "Define_Daramad_Two_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes.Insert(4, "Define_Daramad_Two_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F23"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes("Define_Daramad_Two_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes("Define_Daramad_Two_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes("Define_Daramad_Two_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-خدمات

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Service", "خدمات")

            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Nodes.Insert(3, "Define_Service_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Nodes.Insert(3, "Define_Service_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Nodes.Insert(3, "Define_Service_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F20"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Nodes("Define_Service_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Nodes("Define_Service_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Service").Nodes("Define_Service_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-ویزیتور

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Visitor", "ویزیتور")

            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Nodes.Insert(3, "Define_Visitor_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Nodes.Insert(3, "Define_Visitor_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Nodes.Insert(3, "Define_Visitor_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F19"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Nodes("Define_Visitor_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Nodes("Define_Visitor_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Visitor").Nodes("Define_Visitor_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-انبار

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Anbar", "انبار")

            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Nodes.Insert(3, "Define_Anbar_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Nodes.Insert(3, "Define_Anbar_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Nodes.Insert(3, "Define_Anbar_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F18"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Nodes("Define_Anbar_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Nodes("Define_Anbar_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Anbar").Nodes("Define_Anbar_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-گروه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Group", "گروه کالا")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Checked = If(Sec.StringDecrypt(Row.Item("F15"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes.Insert(3, "Define_Group_One", "گروه اصلی")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes.Insert(4, "Define_Group_One_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes.Insert(4, "Define_Group_One_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes.Insert(4, "Define_Group_One_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F16"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes("Define_Group_One_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes("Define_Group_One_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes("Define_Group_One_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes.Insert(3, "Define_Group_Two", "گروه فرعی")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes.Insert(4, "Define_Group_Two_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes.Insert(4, "Define_Group_Two_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes.Insert(4, "Define_Group_Two_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F17"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes("Define_Group_Two_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes("Define_Group_Two_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes("Define_Group_Two_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            '''''''''''''''''''تعاریف-واحد شمارش

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Vahed", "واحد شمارش")

            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Nodes.Insert(3, "Define_Vahed_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Nodes.Insert(3, "Define_Vahed_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Nodes.Insert(3, "Define_Vahed_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F14"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Nodes("Define_Vahed_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Nodes("Define_Vahed_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Vahed").Nodes("Define_Vahed_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''تعاریف-کالا

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_Kala", "کالا")

            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Nodes.Insert(3, "Define_Kala_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Nodes.Insert(3, "Define_Kala_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Nodes.Insert(3, "Define_Kala_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F13"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Nodes("Define_Kala_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Nodes("Define_Kala_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Define_Kala").Nodes("Define_Kala_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            '''''''''''''''''''تعاریف-روابط کالا و قیمت در شهرستان

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_KalaCost", "رابطه کالا و قیمت در شهرستان")

            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes.Insert(3, "Define_KalaCost_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes.Insert(3, "Define_KalaCost_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes.Insert(3, "Define_KalaCost_DelCity", "حذف شهرستان")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes.Insert(3, "Define_KalaCost_DelCost", "حذف قیمت")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes.Insert(3, "Define_KalaCost_EditCost", "تغییر قیمت")
            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F123"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_DelCity").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_DelCost").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_EditCost").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_Edit").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_DelCity").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_DelCost").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_EditCost").Checked = False
            End Try

            '''''''''''''''''''تعاریف-روابط کالا و قیمت ویژه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_KalaSCost", " کالا و قیمت ویژه")

            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes.Insert(3, "Define_KalaSCost_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes.Insert(3, "Define_KalaSCost_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes.Insert(3, "Define_KalaSCost_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes.Insert(3, "Define_KalaSCost_Print", "چاپ")
            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F126"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Edit").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Del").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Print").Checked = False
            End Try

            '''''''''''''''''''تعاریف-روابط کالا و جایزه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_KalaDiscount", "رابطه کالا و جایزه")

            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes.Insert(3, "Define_KalaDiscount_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes.Insert(3, "Define_KalaDiscount_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes.Insert(3, "Define_KalaDiscount_Del", "حذف")
            
            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F124"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Edit").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Del").Checked = False
            End Try

            '''''''''''''''''''تعاریف-روابط کالا و وعده تسویه

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_KalaRate", "رابطه کالا و وعده تسویه")

            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes.Insert(3, "Define_KalaRate_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes.Insert(3, "Define_KalaRate_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes.Insert(3, "Define_KalaRate_Del", "حذف")

            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F150"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Edit").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Del").Checked = False
            End Try
            '''''''''''''''''''تعاریف-روابط ویزیتور و فروش هدف

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_VisitGol", " ویزیتور و فروش هدف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes.Insert(3, "Define_VisitGol_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes.Insert(3, "Define_VisitGol_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes.Insert(3, "Define_VisitGol_Del", "حذف")
            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F128"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Edit").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Del").Checked = False
            End Try

            '''''''''''''''''''تعاریف-روابط کاربر و فروش هدف

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Define_UserGol", " کاربر و فروش هدف")
            TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes.Insert(3, "Define_UserGol_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes.Insert(3, "Define_UserGol_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes.Insert(3, "Define_UserGol_Del", "حذف")
            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F149"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Add").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Edit").Checked = False
                TV.Nodes(0).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Del").Checked = False
            End Try

            '''''''''''''''''''تعاریف-اول دوره-کالا

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Kala_OneTime", "موجودی اولیه کالا")

            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes.Insert(3, "Kala_OneTime_Save", "ذخیره")
            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes.Insert(3, "Kala_OneTime_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes.Insert(3, "Kala_OneTime_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes.Insert(3, "Kala_OneTime_Print", "چاپ لیست")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F12"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Save").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Print").Checked = False
            End Try

            '''''''''''''''''''تعاریف-اول دوره-اسناد مالی

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "Check_OnTime", "موجودی اولیه اسناد")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Checked = If(Sec.StringDecrypt(Row.Item("F9"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes.Insert(3, "Check_OnTime_One", "اسناد دریافتی")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes.Insert(4, "Check_OnTime_One_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes.Insert(4, "Check_OnTime_One_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes.Insert(4, "Check_OnTime_One_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes.Insert(4, "Check_OnTime_One_Print", "چاپ")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F10"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Print").Checked = False
            End Try


            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes.Insert(3, "Check_OnTime_Two", "اسناد پرداختی")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes.Insert(4, "Check_OnTime_Two_Add", "جدید")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes.Insert(4, "Check_OnTime_Two_Del", "حذف")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes.Insert(4, "Check_OnTime_Two_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes.Insert(4, "Check_OnTime_Two_Print", "چاپ")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F11"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Print").Checked = False
            End Try

            '''''''''''''''''''تعاریف-تراز اول دوره

            TV.Nodes(0).Nodes("Define").Nodes.Insert(2, "TrazOne", "تراز اول دوره")
            TV.Nodes(0).Nodes("Define").Nodes("TrazOne").Nodes.Insert(3, "TrazOne_Print", "چاپ تراز")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F8"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Define").Nodes("TrazOne").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Define").Nodes("TrazOne").Nodes("TrazOne_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '*************************** عملیات حسابداری
            TV.Nodes(0).Nodes.Insert(1, "Account", "عملیات حسابداری")
            TV.Nodes(0).Nodes("Account").Checked = If(Sec.StringDecrypt(Row.Item("F38"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''عملیات حسابداری-فاکتور

            TV.Nodes(0).Nodes("Account").Nodes.Insert(2, "Factor", "فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_0", "خرید")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_1", "برگشت از خرید")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_2", "خرید امانی")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_3", "فروش")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_4", "برگشت از فروش")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_5", "فروش امانی")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_6", "ضایعات")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_7", "پیش فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_8", "خدمات")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes.Insert(3, "Factor_9", "کسری فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes.Insert(4, "Factor_9_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes.Insert(4, "Factor_9_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes.Insert(4, "Factor_9_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F39"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("Factor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_0").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_1").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_2").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_3").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_4").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_5").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(6, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_6").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(7, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_7").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(8, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_8").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(9, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(10, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(11, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(12, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(13, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Add").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Del").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Edit").Checked = False
            End Try

            '''''''''''''''''''عملیات حسابداری-مدیریت فاکتور سیستم

            TV.Nodes(0).Nodes("Account").Nodes.Insert(2, "ManageFactor", "مدیریت فاکتور سیستم")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_Del", "حذف فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_Show", "ریز فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_Edit", "ویرایش فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_PrintFac", "چاپ فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_PrintAnbar", "چاپ رسید")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_AllPrint", "چاپ متوالی")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_PrintFish", "چاپ فیش")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_SMS", "ارسال SMS")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_Convert", "تبدیل")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes.Insert(3, "ManageFactor_PrintList", "چاپ لیست")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F40"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Show").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintFac").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintAnbar").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintFish").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(6, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_AllPrint").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(7, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_AllPrint").Checked = False
            End Try

            Try
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_SMS").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(8, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_SMS").Checked = False
            End Try

            Try
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Convert").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(9, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Convert").Checked = False
            End Try

            Try
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintList").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(10, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintList").Checked = False
            End Try

            '''''''''''''''''''عملیات حسابداری-مدیریت فاکتور موبایل

            TV.Nodes(0).Nodes("Account").Nodes.Insert(2, "ManageFactorM", "مدیریت فاکتور موبایل")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes.Insert(3, "ManageFactorM_Del", "حذف فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes.Insert(3, "ManageFactorM_Show", "ریز فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes.Insert(3, "ManageFactorM_ChangeFrosh", "تغییر وضعیت به فروش")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes.Insert(3, "ManageFactorM_ChangePish", "تغییر وضعیت به پیش فاکتور")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes.Insert(3, "ManageFactorM_ChangeNo", "تغییر وضعیت به رد")
            TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes.Insert(3, "ManageFactorM_ChangeCur", "تغییر وضعیت به در جریان")

            Try

                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F143"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_Show").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeFrosh").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangePish").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeNo").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeCur").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(6, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_Del").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_Show").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeFrosh").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangePish").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeNo").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeCur").Checked = False
            End Try

            '''''''''''''''''''عملیات حسابداری-مدیریت چک

            TV.Nodes(0).Nodes("Account").Nodes.Insert(2, "ManageChk", "مدیریت چک")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Checked = If(Sec.StringDecrypt(Row.Item("F41"), key.CreateDecryptor) = "1", True, False)


            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes.Insert(3, "ManageChk_Get", "اسناد دریافتی")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes.Insert(4, "ManageChk_Get_Change", "تغییر وضعیت")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes.Insert(4, "ManageChk_Get_Print", "چاپ")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes.Insert(4, "ManageChk_Get_State", "سابقه چک")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes.Insert(4, "ManageChk_Get_Edit", "اصلاح توضیحات")

            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes.Insert(3, "ManageChk_Pay", "اسناد پرداختی")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes.Insert(4, "ManageChk_Pay_Change", "تغییر وضعیت")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes.Insert(4, "ManageChk_Pay_Print", "چاپ")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes.Insert(4, "ManageChk_Pay_State", "سابقه چک")
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes.Insert(4, "ManageChk_Pay_Edit", "اصلاح توضیحات")


            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F42"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_Change").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_State").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F43"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_Change").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_State").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            '''''''''''''''''''عملیات حسابداری-امور روزانه

            TV.Nodes(0).Nodes("Account").Nodes.Insert(2, "DayWork", "امور روزانه")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Checked = If(Sec.StringDecrypt(Row.Item("F44"), key.CreateDecryptor) = "1", True, False)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_Get", "دریافت از طرف حساب")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes.Insert(4, "DayWork_Get_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes.Insert(4, "DayWork_Get_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes.Insert(4, "DayWork_Get_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes.Insert(4, "DayWork_Get_Print", "چاپ")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_Pay", "پرداخت به طرف حساب")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes.Insert(4, "DayWork_Pay_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes.Insert(4, "DayWork_Pay_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes.Insert(4, "DayWork_Pay_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes.Insert(4, "DayWork_Pay_Print", "چاپ")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_PTP", "طرف حساب به طرف حساب")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes.Insert(4, "DayWork_PTP_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes.Insert(4, "DayWork_PTP_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes.Insert(4, "DayWork_PTP_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes.Insert(4, "DayWork_PTP_Print", "چاپ")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_ChargeK", "هزینه فاکتور خرید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes.Insert(4, "DayWork_ChargeK_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes.Insert(4, "DayWork_ChargeK_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes.Insert(4, "DayWork_ChargeK_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes.Insert(4, "DayWork_ChargeK_Print", "چاپ")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_Charge", "هزینه متفرقه")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes.Insert(4, "DayWork_Charge_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes.Insert(4, "DayWork_Charge_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes.Insert(4, "DayWork_Charge_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes.Insert(4, "DayWork_Charge_Print", "چاپ")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_Daramad", "درآمد")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes.Insert(4, "DayWork_Daramad_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes.Insert(4, "DayWork_Daramad_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes.Insert(4, "DayWork_Daramad_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes.Insert(4, "DayWork_Daramad_Print", "چاپ")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_Amval", "اموال")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes.Insert(4, "DayWork_Amval_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes.Insert(4, "DayWork_Amval_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes.Insert(4, "DayWork_Amval_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_Sarmayeh", "سرمایه")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes.Insert(4, "DayWork_Sarmayeh_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes.Insert(4, "DayWork_Sarmayeh_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes.Insert(4, "DayWork_Sarmayeh_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_AddDecBox", "اضافات و کسورات صندوق")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes.Insert(4, "DayWork_AddDecBox_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes.Insert(4, "DayWork_AddDecBox_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes.Insert(4, "DayWork_AddDecBox_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_BoxBox", "صندوق به صندوق")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes.Insert(4, "DayWork_BoxBox_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes.Insert(4, "DayWork_BoxBox_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes.Insert(4, "DayWork_BoxBox_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_AddDecBank", "اضافات و کسورات بانک")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes.Insert(4, "DayWork_AddDecBank_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes.Insert(4, "DayWork_AddDecBank_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes.Insert(4, "DayWork_AddDecBank_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_BankBank", "بانک به بانک")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes.Insert(4, "DayWork_BankBank_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes.Insert(4, "DayWork_BankBank_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes.Insert(4, "DayWork_BankBank_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_BankBox", "انتقالات بانک و صندوق")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes.Insert(4, "DayWork_BankBox_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes.Insert(4, "DayWork_BankBox_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes.Insert(4, "DayWork_BankBox_Edit", "ویرایش")

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes.Insert(3, "DayWork_EditMoein", "اصلاحیه طرف حساب")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes.Insert(4, "DayWork_EditMoein_Add", "جدید")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes.Insert(4, "DayWork_EditMoein_Del", "حذف")
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes.Insert(4, "DayWork_EditMoein_Edit", "ویرایش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F45"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F46"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F47"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F48"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F49"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F50"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F51"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes("DayWork_Amval_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes("DayWork_Amval_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes("DayWork_Amval_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F52"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes("DayWork_Sarmayeh_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes("DayWork_Sarmayeh_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes("DayWork_Sarmayeh_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F53"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes("DayWork_AddDecBox_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes("DayWork_AddDecBox_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes("DayWork_AddDecBox_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F54"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes("DayWork_BoxBox_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes("DayWork_BoxBox_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes("DayWork_BoxBox_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F55"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes("DayWork_AddDecBank_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes("DayWork_AddDecBank_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes("DayWork_AddDecBank_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F56"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes("DayWork_BankBank_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes("DayWork_BankBank_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes("DayWork_BankBank_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))


            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F57"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes("DayWork_BankBox_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes("DayWork_BankBox_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes("DayWork_BankBox_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F151"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Add").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Del").Checked = False
                TV.Nodes(0).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Edit").Checked = False
            End Try
            '*************************** گزارشات انبار
            TV.Nodes(0).Nodes.Insert(1, "Anbar", "گزارشات انبار")
            TV.Nodes(0).Nodes("Anbar").Checked = If(Sec.StringDecrypt(Row.Item("F58"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-انتقالات انبار

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "Translate", "انتقالات انبار")
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes.Insert(3, "Translate_Add", "جدید")
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes.Insert(3, "Translate_Del", "حذف")
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes.Insert(3, "Translate_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes.Insert(3, "Translate_Print", "چاپ لیست")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F59"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Del").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-کاردکس کالا

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "Kardexkala", "کاردکس کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("Kardexkala").Nodes.Insert(3, "Kardexkala_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F60"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("Kardexkala").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("Kardexkala").Nodes("Kardexkala_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-کاردکس انبار

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "KardexAnbar", "کاردکس انبار")
            TV.Nodes(0).Nodes("Anbar").Nodes("KardexAnbar").Nodes.Insert(3, "KardexAnbar_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F61"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("KardexAnbar").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("KardexAnbar").Nodes("KardexAnbar_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-موجودی کالا

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "MojodyKala", "موجودی کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyKala").Nodes.Insert(3, "MojodyKala_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F62"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyKala").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyKala").Nodes("MojodyKala_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-موجودی انبار

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "MojodyAnbar", "موجودی انبار")
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyAnbar").Nodes.Insert(3, "MojodyAnbar_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F63"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyAnbar").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyAnbar").Nodes("MojodyAnbar_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-موجودی ریالی کالا

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "MojodyRKala", "موجودی ریالی کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyRKala").Nodes.Insert(3, "MojodyRKala_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F64"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyRKala").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyRKala").Nodes("MojodyRKala_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-موجودی ریالی انبار

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "MojodyRAnbar", "موجودی ریالی انبار")
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyRAnbar").Nodes.Insert(3, "MojodyRAnbar_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F65"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyRAnbar").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("MojodyRAnbar").Nodes("MojodyRAnbar_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-حداقل نقطه سفارش

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "LowBalance", "حداقل نقطه سفارش")
            TV.Nodes(0).Nodes("Anbar").Nodes("LowBalance").Nodes.Insert(3, "LowBalance_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F66"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("LowBalance").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("LowBalance").Nodes("LowBalance_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-حداکثر نقطه سفارش

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "HightBalance", "حداکثر نقطه سفارش")
            TV.Nodes(0).Nodes("Anbar").Nodes("HightBalance").Nodes.Insert(3, "HightBalance_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F67"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Anbar").Nodes("HightBalance").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Anbar").Nodes("HightBalance").Nodes("HightBalance_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات انبار-تردد کالا

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "BalanceKala", "تردد کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("BalanceKala").Checked = If(Sec.StringDecrypt(Row.Item("F68"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-خرید کالا 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "BuyKala", "خرید کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("BuyKala").Checked = If(Sec.StringDecrypt(Row.Item("F69"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-برگشت از خرید کالا 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "BackBuyKala", "برگشت از خرید کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("BackBuyKala").Checked = If(Sec.StringDecrypt(Row.Item("F70"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-فروش کالا 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "SellKala", "فروش کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("SellKala").Checked = If(Sec.StringDecrypt(Row.Item("F71"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-برگشت از فروش کالا 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "BackSellKala", "برگشت از فروش کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("BackSellKala").Checked = If(Sec.StringDecrypt(Row.Item("F72"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-ضایعات کالا 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "DamageKala", "ضایعات کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("DamageKala").Checked = If(Sec.StringDecrypt(Row.Item("F73"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-خدمات کالا 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "ServiceKala", "خدمات کالا")
            TV.Nodes(0).Nodes("Anbar").Nodes("ServiceKala").Checked = If(Sec.StringDecrypt(Row.Item("F74"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات انبار-تولید بارکد 

            TV.Nodes(0).Nodes("Anbar").Nodes.Insert(2, "BarCodeKala", "تولید بارکد")
            TV.Nodes(0).Nodes("Anbar").Nodes("BarCodeKala").Checked = If(Sec.StringDecrypt(Row.Item("F75"), key.CreateDecryptor) = "1", True, False)


            '*************************** گزارشات طرف حساب
            TV.Nodes(0).Nodes.Insert(1, "People", "گزارشات طرف حساب")
            TV.Nodes(0).Nodes("People").Checked = If(Sec.StringDecrypt(Row.Item("F76"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات طرف حساب-معین طرف حساب

            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Moein_People", "معین طرف حساب")
            TV.Nodes(0).Nodes("People").Nodes("Moein_People").Nodes.Insert(3, "Moein_People_Print", "چاپ گزارش")
            TV.Nodes(0).Nodes("People").Nodes("Moein_People").Nodes.Insert(3, "Moein_People_SMS", "ارسال SMS")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F77"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Moein_People").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("People").Nodes("Moein_People").Nodes("Moein_People_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("People").Nodes("Moein_People").Nodes("Moein_People_SMS").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("People").Nodes("Moein_People").Nodes("Moein_People_SMS").Checked = False
            End Try

            '''''''''''''''''''گزارشات طرف حساب-مالی کالایی طرف حساب

            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Moein_Kala_People", "مالی کالایی طرف حساب")
            TV.Nodes(0).Nodes("People").Nodes("Moein_Kala_People").Nodes.Insert(3, "Moein_Kala_People_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F78"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Moein_Kala_People").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("People").Nodes("Moein_Kala_People").Nodes("Moein_Kala_People_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات طرف حساب-معین صندوق

            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Moein_Box", "معین صندوق")
            TV.Nodes(0).Nodes("People").Nodes("Moein_Box").Nodes.Insert(3, "Moein_Box_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F79"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Moein_Box").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("People").Nodes("Moein_Box").Nodes("Moein_Box_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات طرف حساب-موجودی صندوق

            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Mojody_Box", "موجودی صندوق")
            TV.Nodes(0).Nodes("People").Nodes("Mojody_Box").Nodes.Insert(3, "Mojody_Box_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F80"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Mojody_Box").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("People").Nodes("Mojody_Box").Nodes("Mojody_Box_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات طرف حساب-معین بانک

            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Moein_Bank", "معین بانک")
            TV.Nodes(0).Nodes("People").Nodes("Moein_Bank").Nodes.Insert(3, "Moein_Bank_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F81"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Moein_Bank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("People").Nodes("Moein_Bank").Nodes("Moein_Bank_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات طرف حساب-موجودی بانک

            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Mojody_Bank", "موجودی بانک")
            TV.Nodes(0).Nodes("People").Nodes("Mojody_Bank").Nodes.Insert(3, "Mojody_Bank_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F82"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Mojody_Bank").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("People").Nodes("Mojody_Bank").Nodes("Mojody_Bank_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات طرف حساب-دفتر کل
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Daftar_Kol", "دفتر کل")
            TV.Nodes(0).Nodes("People").Nodes("Daftar_Kol").Nodes.Insert(3, "BtnSMS", "ارسال SMS")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F83"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("People").Nodes("Daftar_Kol").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))

            Try
                TV.Nodes(0).Nodes("People").Nodes("Daftar_Kol").Nodes("BtnSMS").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("People").Nodes("Daftar_Kol").Nodes("BtnSMS").Checked = False
            End Try
            '////////////////////////////////////////////////////////////////////////

            '''''''''''''''''''گزارشات طرف حساب-درصد ریسک
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Darsad_Risk", "درصد ریسک")
            Try
                TV.Nodes(0).Nodes("People").Nodes("Darsad_Risk").Checked = If(Sec.StringDecrypt(Row.Item("F122"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("People").Nodes("Darsad_Risk").Checked = False
            End Try

            '''''''''''''''''''گزارشات طرف حساب-دفتر روزانه
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Daftar_day", "دفتر روزانه")
            TV.Nodes(0).Nodes("People").Nodes("Daftar_day").Checked = If(Sec.StringDecrypt(Row.Item("F84"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات طرف حساب-گزارش هزینه
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Report_Charge", "گزارش هزینه")
            TV.Nodes(0).Nodes("People").Nodes("Report_Charge").Checked = If(Sec.StringDecrypt(Row.Item("F85"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات طرف حساب-گزارش درآمد
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Report_Daramd", "گزارش درآمد")
            TV.Nodes(0).Nodes("People").Nodes("Report_Daramd").Checked = If(Sec.StringDecrypt(Row.Item("F86"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات طرف حساب-گزارش اموال
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Report_Amval", "گزارش اموال")
            TV.Nodes(0).Nodes("People").Nodes("Report_Amval").Checked = If(Sec.StringDecrypt(Row.Item("F87"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات طرف حساب-گزارش سرمایه
            TV.Nodes(0).Nodes("People").Nodes.Insert(2, "Report_sarmayeh", "گزارش سرمایه")
            TV.Nodes(0).Nodes("People").Nodes("Report_sarmayeh").Checked = If(Sec.StringDecrypt(Row.Item("F88"), key.CreateDecryptor) = "1", True, False)

            '*************************** گزارشات مالی
            TV.Nodes(0).Nodes.Insert(1, "Mali", "گزارشات مالی")
            TV.Nodes(0).Nodes("Mali").Checked = If(Sec.StringDecrypt(Row.Item("F89"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مالی-اسناد دریافتی

            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "Report_GetChk", "اسناد دریافتی")
            TV.Nodes(0).Nodes("Mali").Nodes("Report_GetChk").Nodes.Insert(3, "BtnSMS", "ارسال SMS")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F90"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Mali").Nodes("Report_GetChk").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))

            Try
                TV.Nodes(0).Nodes("Mali").Nodes("Report_GetChk").Nodes("BtnSMS").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Mali").Nodes("Report_GetChk").Nodes("BtnSMS").Checked = False
            End Try

            '''''''''''''''''''گزارشات مالی-اسناد پرداختی
            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "Report_PayChk", "اسناد پرداختی")
            TV.Nodes(0).Nodes("Mali").Nodes("Report_PayChk").Checked = If(Sec.StringDecrypt(Row.Item("F91"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مالی-اسناد براتی
            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "Report_BratChk", "اسناد براتی")
            TV.Nodes(0).Nodes("Mali").Nodes("Report_BratChk").Checked = If(Sec.StringDecrypt(Row.Item("F92"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مالی-اطلاع رسانی مالی
            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "Report_InfoChk", "اطلاع رسانی مالی")
            TV.Nodes(0).Nodes("Mali").Nodes("Report_InfoChk").Checked = If(Sec.StringDecrypt(Row.Item("F93"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مالی-سابقه چک
            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "State_InfoChk", "سابقه چک")
            TV.Nodes(0).Nodes("Mali").Nodes("State_InfoChk").Checked = If(Sec.StringDecrypt(Row.Item("F94"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مالی-سود فاکتور

            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "SodFactor", "سود فاکتور")
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Nodes.Insert(3, "SodFactor_Show", "ریز فاکتور")
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Nodes.Insert(3, "SodFactor_Edit", "ویرایش فاکتور")
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Nodes.Insert(3, "SodFactor_Print", "چاپ لیست")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F95"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Nodes("SodFactor_Show").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Nodes("SodFactor_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor").Nodes("SodFactor_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))

            '''''''''''''''''''گزارشات مالی-سود طرف حسابها

            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "SodFactor2", "سود طرف حسابها")
            TV.Nodes(0).Nodes("Mali").Nodes("SodFactor2").Nodes.Insert(3, "SodFactor2_Print", "چاپ لیست")
            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F116"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Mali").Nodes("SodFactor2").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Mali").Nodes("SodFactor2").Nodes("SodFactor2_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Mali").Nodes("SodFactor2").Checked = False
                TV.Nodes(0).Nodes("Mali").Nodes("SodFactor2").Nodes("SodFactor2_Print").Checked = False
            End Try

            '''''''''''''''''''گزارشات مالی-سود و زیان ناخالص
            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "NSod", "سود و زیان ناخالص")
            TV.Nodes(0).Nodes("Mali").Nodes("NSod").Checked = If(Sec.StringDecrypt(Row.Item("F96"), key.CreateDecryptor) = "1", True, False)


            '''''''''''''''''''گزارشات مالی-سود و وزیان خالص

            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "Sod", "سود و زیان خالص")
            TV.Nodes(0).Nodes("Mali").Nodes("Sod").Nodes.Insert(3, "Sod_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F97"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Mali").Nodes("Sod").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Mali").Nodes("Sod").Nodes("Sod_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '''''''''''''''''''گزارشات مالی-تخفیفات

            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "Report_Discount", "گزارش تخفیفات")
            Try
                TV.Nodes(0).Nodes("Mali").Nodes("Report_Discount").Checked = If(Sec.StringDecrypt(Row.Item("F145"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("Mali").Nodes("Report_Discount").Checked = False
            End Try

            '''''''''''''''''''گزارشات مالی-تراز میان دوره

            TV.Nodes(0).Nodes("Mali").Nodes.Insert(2, "TrazTwo", "تراز میان دوره")
            TV.Nodes(0).Nodes("Mali").Nodes("TrazTwo").Nodes.Insert(3, "TrazTwo_Print", "چاپ گزارش")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F98"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Mali").Nodes("TrazTwo").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Mali").Nodes("TrazTwo").Nodes("TrazTwo_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))

            '*************************** گزارشات مدیریتی
            TV.Nodes(0).Nodes.Insert(1, "Manage", "گزارشات مدیریتی")
            TV.Nodes(0).Nodes("Manage").Checked = If(Sec.StringDecrypt(Row.Item("F99"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مدیریتی-خروجی فاکتور

            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "ExitFactor", "خروجی فاکتور")
            TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes.Insert(3, "ExitFactor_Add", "خروجی")
            TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes.Insert(3, "ExitFactor_Edit", "ویرایش")
            TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes.Insert(3, "ExitFactor_DelExit", "حذف خروجی")
            TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes.Insert(3, "ExitFactor_DelFactor", "حذف فاکتور")
            TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes.Insert(3, "ExitFactor_Change", "تغییر ترتیب")

            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F121"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_DelExit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_DelFactor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Change").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))

            Catch ex As Exception
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Checked = False
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Add").Checked = False
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Edit").Checked = False
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_DelExit").Checked = False
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_DelFactor").Checked = False
                TV.Nodes(0).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Change").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیریتی-تیم پخش
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "ControlFactor", "تیم پخش")
            TV.Nodes(0).Nodes("Manage").Nodes("ControlFactor").Checked = If(Sec.StringDecrypt(Row.Item("F100"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مدیریتی-جمع کالای فاکتور
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "SumFactor", "جمع کالای فاکتور")
            TV.Nodes(0).Nodes("Manage").Nodes("SumFactor").Checked = If(Sec.StringDecrypt(Row.Item("F103"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مدیریتی-پیگیری وعده ها

            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "DelayFactor", "پیگیری وعده ها")
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes.Insert(3, "DelayFactor_Add", "تمدید وعده")
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes.Insert(3, "DelayFactor_Tasveh", "تسویه دستی")
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes.Insert(3, "DelayFactor_Edit", "اصلاح توضیحات")
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes.Insert(3, "DelayFactor_Print", "چاپ")
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes.Insert(3, "DelayFactor_SMS", "ارسال SMS")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F104"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Tasveh").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Print").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(4, 1) = "1", True, False))
            Try
                TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_SMS").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(5, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_SMS").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیریتی-وعده تسویه کالا
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "RateFactor", "وعده تسویه کالا")
            Try
                TV.Nodes(0).Nodes("Manage").Nodes("RateFactor").Checked = If(Sec.StringDecrypt(Row.Item("F152"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("Manage").Nodes("RateFactor").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیریتی-پیگیری فروش
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "DelaySell", "پیگیری فروش")
            TV.Nodes(0).Nodes("Manage").Nodes("DelaySell").Checked = If(Sec.StringDecrypt(Row.Item("F105"), key.CreateDecryptor) = "1", True, False)

            ''''''''''''''''''''گزارشات مدیریتی-پیگیری خروجی
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "DelayExit", "پیگیری خروجی")
            Try
                TV.Nodes(0).Nodes("Manage").Nodes("DelayExit").Checked = If(Sec.StringDecrypt(Row.Item("F127"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("Manage").Nodes("DelayExit").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیریتی-تاخیر مشتری
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "Delay", "تاخیر مشتری")
            Try
                TV.Nodes(0).Nodes("Manage").Nodes("Delay").Checked = If(Sec.StringDecrypt(Row.Item("F146"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("Manage").Nodes("Delay").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیریتی-تابلوی قیمت
            TV.Nodes(0).Nodes("Manage").Nodes.Insert(2, "TableCost", "تابلوی قیمت")
            TV.Nodes(0).Nodes("Manage").Nodes("TableCost").Checked = If(Sec.StringDecrypt(Row.Item("F106"), key.CreateDecryptor) = "1", True, False)

            '*************************** گزارشات مدیر فروش
            TV.Nodes(0).Nodes.Insert(1, "ManageFrosh", "گزارشات مدیر فروش")
            Try
                TV.Nodes(0).Nodes("ManageFrosh").Checked = If(Sec.StringDecrypt(Row.Item("F131"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("ManageFrosh").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیر فروش-فروش کاربر
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "FroshUser", "فروش کاربر")
            TV.Nodes(0).Nodes("ManageFrosh").Nodes("FroshUser").Checked = If(Sec.StringDecrypt(Row.Item("F101"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مدیر فروش-فروش ویزیتور
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "FroshVisitor", "فروش ویزیتور")
            TV.Nodes(0).Nodes("ManageFrosh").Nodes("FroshVisitor").Checked = If(Sec.StringDecrypt(Row.Item("F102"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''گزارشات مدیر فروش-جمع فروش کاربران
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "AllFroshUser", "جمع فروش کاربران")
            TV.Nodes(0).Nodes("ManageFrosh").Nodes("AllFroshUser").Checked = If(Row.Item("F113") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F113"), key.CreateDecryptor) = "1", True, False))

            '''''''''''''''''''گزارشات مدیر فروش-جمع فروش ویزیتورها
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "AllFroshVisitor", "جمع فروش ویزیتورها")
            TV.Nodes(0).Nodes("ManageFrosh").Nodes("AllFroshVisitor").Checked = If(Row.Item("F114") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F114"), key.CreateDecryptor) = "1", True, False))
            '''''''''''''''''''گزارشات مدیر فروش-گزارش عملکرد کاربر
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "StateFroshUser", "گزارش عملکرد کاربر")
            Try
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("StateFroshUser").Checked = If(Row.Item("F141") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F141"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("StateFroshUser").Checked = False
            End Try
            '''''''''''''''''''گزارشات مدیر فروش-گزارش عملکرد ویزیتور
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "StateFroshVisitor", "گزارش عملکرد ویزیتور")
            Try
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("StateFroshVisitor").Checked = If(Row.Item("F142") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F142"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("StateFroshVisitor").Checked = False
            End Try
            '''''''''''''''''''گزارشات مدیر فروش-گزارش فروش هدف
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "VisitGol", "فروش هدف")
            Try
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("VisitGol").Checked = If(Row.Item("F129") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F129"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("VisitGol").Checked = False
            End Try
            '''''''''''''''''''گزارشات مدیر فروش-گزارش مسیر مشتریان

            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "PathPeople", "مسیر مشتریان")
            TV.Nodes(0).Nodes("ManageFrosh").Nodes("PathPeople").Nodes.Insert(3, "BtnSMS", "ارسال SMS")

            TmpStr = ""
            TmpStr = Sec.StringDecrypt(Row.Item("F130"), key.CreateDecryptor)

            TV.Nodes(0).Nodes("ManageFrosh").Nodes("PathPeople").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))

            Try
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("PathPeople").Nodes("BtnSMS").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("PathPeople").Nodes("BtnSMS").Checked = False
            End Try

            '''''''''''''''''''گزارشات مدیر فروش-گزارش مدیریت بازار
            TV.Nodes(0).Nodes("ManageFrosh").Nodes.Insert(2, "ManageB", "مدیریت بازار")
            Try
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("ManageB").Checked = If(Row.Item("F132") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F132"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ManageFrosh").Nodes("ManageB").Checked = False
            End Try

            '*************************** گزارشات نموداری
            TV.Nodes(0).Nodes.Insert(1, "ChartReport", "گزارشات نموداری")
            Try
                TV.Nodes(0).Nodes("ChartReport").Checked = If(Sec.StringDecrypt(Row.Item("F133"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Checked = False
            End Try


            '''''''''''''''''''گزارشات نموداری-نمودار فروش بر حسب استان
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChFroshOstan", "نمودار فروش بر حسب استان")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChFroshOstan").Checked = If(Row.Item("F138") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F138"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChFroshOstan").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار فروش بر حسب شهرستان
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChFroshCity", "نمودار فروش بر حسب شهرستان")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChFroshCity").Checked = If(Row.Item("F139") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F139"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChFroshCity").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار فروش بر حسب مسیر
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChFroshPart", "نمودار فروش بر حسب مسیر")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChFroshPart").Checked = If(Row.Item("F140") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F140"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChFroshPart").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار اسناد دریافتی
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChGetChk", "نمودار اسناد دریافتی")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChGetChk").Checked = If(Row.Item("F147") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F147"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChGetChk").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار اسناد پرداختی
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChPayChk", "نمودار اسناد پرداختی")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChPayChk").Checked = If(Row.Item("F148") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F148"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChPayChk").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار هزینه
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChCharge", "نمودار هزینه")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChCharge").Checked = If(Row.Item("F134") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F134"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChCharge").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار درآمد
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChDaramad", "نمودار درآمد")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChDaramad").Checked = If(Row.Item("F135") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F135"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChDaramad").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار اموال
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChAmval", "نمودار اموال")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChAmval").Checked = If(Row.Item("F136") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F136"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChAmval").Checked = False
            End Try

            '''''''''''''''''''گزارشات نموداری-نمودار سرمایه
            TV.Nodes(0).Nodes("ChartReport").Nodes.Insert(2, "ChSarmayeh", "نمودار اموال")
            Try
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChSarmayeh").Checked = If(Row.Item("F137") Is DBNull.Value, False, If(Sec.StringDecrypt(Row.Item("F137"), key.CreateDecryptor) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("ChartReport").Nodes("ChSarmayeh").Checked = False
            End Try
            '*************************** سرویس SMS
            TV.Nodes(0).Nodes.Insert(1, "SMS", "سرویس SMS")
            TV.Nodes(0).Nodes("SMS").Checked = If(Sec.StringDecrypt(Row.Item("F107"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''سرویس SMS-فعال سازی سرویس SMS
            TV.Nodes(0).Nodes("SMS").Nodes.Insert(2, "ActiveSMS", "فعال سازی سرویس SMS")
            TV.Nodes(0).Nodes("SMS").Nodes("ActiveSMS").Checked = If(Sec.StringDecrypt(Row.Item("F108"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''سرویس SMS-ارسال SMS اختصاصی
            TV.Nodes(0).Nodes("SMS").Nodes.Insert(2, "SendOneSMS", "ارسال SMS اختصاصی")
            TV.Nodes(0).Nodes("SMS").Nodes("SendOneSMS").Checked = If(Sec.StringDecrypt(Row.Item("F109"), key.CreateDecryptor) = "1", True, False)

            '''''''''''''''''''سرویس SMS-ارسال SMS عمومی
            TV.Nodes(0).Nodes("SMS").Nodes.Insert(2, "SendGlobalSMS", "ارسال SMS عمومی")
            TV.Nodes(0).Nodes("SMS").Nodes("SendGlobalSMS").Checked = If(Sec.StringDecrypt(Row.Item("F110"), key.CreateDecryptor) = "1", True, False)

            '*******************************   سایر
            TV.Nodes(0).Nodes.Insert(1, "InfoCompany", "مشخصات شرکت")
            TV.Nodes(0).Nodes("InfoCompany").Checked = If(Sec.StringDecrypt(Row.Item("F111"), key.CreateDecryptor) = "1", True, False)
            TV.Nodes(0).Nodes.Insert(1, "Backup", "نسخه پشتیبان")
            TV.Nodes(0).Nodes("Backup").Checked = If(Sec.StringDecrypt(Row.Item("F112"), key.CreateDecryptor) = "1", True, False)
            TV.Nodes(0).Nodes.Insert(1, "Setting", "تنظیمات")
            Try
                TV.Nodes(0).Nodes("Setting").Checked = If(Sec.StringDecrypt(Row.Item("F125"), key.CreateDecryptor) = "1", True, False)
            Catch ex As Exception
                TV.Nodes(0).Nodes("Setting").Checked = False
            End Try

            '''''''''''''''''''مرکز پیام
            TV.Nodes(0).Nodes.Insert(1, "MessageCenter", "مرکز پیام")
            TV.Nodes(0).Nodes("MessageCenter").Nodes.Insert(1, "MessageCenter_Edit", "ویرایش")
            TV.Nodes(0).Nodes("MessageCenter").Nodes.Insert(1, "MessageCenter_Dell", "حذف")
            TV.Nodes(0).Nodes("MessageCenter").Nodes.Insert(1, "MessageCenter_Add", "جدید")
            Try
                TmpStr = ""
                TmpStr = Sec.StringDecrypt(Row.Item("F153"), key.CreateDecryptor)

                TV.Nodes(0).Nodes("MessageCenter").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(0, 1) = "1", True, False))
                TV.Nodes(0).Nodes("MessageCenter").Nodes("MessageCenter_Edit").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(1, 1) = "1", True, False))
                TV.Nodes(0).Nodes("MessageCenter").Nodes("MessageCenter_Dell").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(2, 1) = "1", True, False))
                TV.Nodes(0).Nodes("MessageCenter").Nodes("MessageCenter_Add").Checked = If(String.IsNullOrEmpty(TmpStr), False, If(TmpStr.Substring(3, 1) = "1", True, False))
            Catch ex As Exception
                TV.Nodes(0).Nodes("MessageCenter").Checked = False
                TV.Nodes(0).Nodes("MessageCenter").Nodes("MessageCenter_Edit").Checked = False
                TV.Nodes(0).Nodes("MessageCenter").Nodes("MessageCenter_Dell").Checked = False
                TV.Nodes(0).Nodes("MessageCenter").Nodes("MessageCenter_Add").Checked = False
            End Try
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "CreateTree")
        End Try
    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            Using Frm As New User_List
                Frm.ShowDialog()
                If Tmp_Namkala <> "" Then

                    If UCase(Tmp_Namkala) = "ADMIN" Then
                        MessageBox.Show("قابل تعریف نیست Admin حق دسترسی برای کاربر", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If Not AreYouAdd(IdKala) Then
                        MessageBox.Show("حق دسترسی برای کاربر مورد نظر قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    Using Frmlevel As New User_Access_Level
                        Frmlevel.LEdit.Text = "0"
                        Frmlevel.ShowDialog()
                    End Using
                    Me.GetAccess()
                End If
            End Using
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "BtnOk_Click")
        End Try
    End Sub
    Private Function AreYouAdd(ByVal Id As Long) As Boolean
        Try
            Dim c As Long = 0
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("SELECT Count(Id) FROM  User_Access WHERE Id=" & Id, ConectionBank)
                c = cmd.ExecuteScalar()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If c > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "AreYouAdd")
            Return False
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            If TV.Nodes.Count <= 0 Then
                MessageBox.Show("حق دسترسی برای حذف وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(path) Then
                MessageBox.Show("هیچ کاربری برای حذف انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If path.Contains(TV.PathSeparator) Then path = path.Substring(0, path.IndexOf(TV.PathSeparator))
            If MessageBox.Show("آیا برای حذف حق دسترسی مربوط به " & " { " & path & " } " & " مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            Me.Enabled = False

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("DELETE FROM User_Access WHERE Id=@Id", ConectionBank)
                cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Trim(Replace(path.Substring(0, path.IndexOf("-")), "کد", ""))
                cmd.ExecuteNonQuery()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "حق دسترسی", "حذف", "حذف دسترسی کاربر:" & path, "")

            Me.GetAccess()
            path = String.Empty
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "Button1_Click")
            Me.Enabled = True
        End Try

    End Sub

    Private Sub TV_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV.AfterCheck
        Button3.Enabled = True
    End Sub

    Private Sub TV_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV.AfterSelect
        Try
            path = e.Node.FullPath
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "Level.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If BtnOk.Enabled = True Then BtnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            If Button2.Enabled = True Then Button2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            Me.GetAccess()
        ElseIf e.KeyCode = Keys.F6 Then
            If Button3.Enabled = True Then Button3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            If TV.Nodes.Count <= 0 Then
                MessageBox.Show("کاربری برای تغییر حق دسترسی وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(path) Then
                MessageBox.Show("هیچ کاربری برای حذف انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If path.Contains(TV.PathSeparator) Then path = path.Substring(0, path.IndexOf(TV.PathSeparator))

            Me.Enabled = False

            Using Frmlevel As New User_Access_Level
                Frmlevel.LEdit.Text = "1"
                IdKala = Trim(Replace(path.Substring(0, path.IndexOf("-")), "کد", ""))
                Frmlevel.ShowDialog()
            End Using

            Me.GetAccess()
            
            Me.Enabled = True
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "Button2_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            If TV.Nodes.Count <= 0 Then
                MessageBox.Show("کاربری برای ذخیره تغییرات وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.Enabled = False
            Me.EditAccess()
            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "حق دسترسی", "ذخیره تغییرات", "", "")
            ' Me.GetAccess()
            Me.Enabled = True
            Button3.Enabled = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "Button3_Click")
            Me.Enabled = True
        End Try
    End Sub

    Private Sub EditAccess()
        Try
            If MessageBox.Show("آیا برای تغییر حق دسترسی مطمئن هستید؟", "سئوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.Enabled = False
            Dim key As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim Sec As New Security()
            key.IV = Sec.Kiv
            key.Key = Sec.Kkey
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand("UPDATE  User_Access SET " _
                                       & " F1=@F1,F2=@F2,F3=@F3,F4=@F4,F5=@F5,F6=@F6,F7=@F7,F8=@F8,F9=@F9,F10=@F10,F11=@F11,F12=@F12,F13=@F13,F14=@F14,F15=@F15,F16=@F16,F17=@F17,F18=@F18,F19=@F19,F20=@F20,F21=@F21,F22=@F22,F23=@F23,F24=@F24,F25=@F25,F26=@F26,F27=@F27,F28=@F28,F29=@F29,F30=@F30,F31=@F31,F32=@F32,F33=@F33,F34=@F34,F35=@F35,F36=@F36,F37=@F37," _
                                       & "F38=@F38,F39=@F39,F40=@F40,F41=@F41,F42=@F42,F43=@F43,F44=@F44,F45=@F45,F46=@F46,F47=@F47,F48=@F48,F49=@F49,F50=@F50,F51=@F51,F52=@F52,F53=@F53,F54=@F54,F55=@F55,F56=@F56,F57=@F57,F58=@F58,F59=@F59,F60=@F60,F61=@F61,F62=@F62,F63=@F63,F64=@F64,F65=@F65,F66=@F66,F67=@F67,F68=@F68,F69=@F69,F70=@F70,F71=@F71,F72=@F72,F73=@F73,F74=@F74,F75=@F75," _
                                       & "F76=@F76,F77=@F77,F78=@F78,F79=@F79,F80=@F80,F81=@F81,F82=@F82,F83=@F83,F84=@F84,F85=@F85,F86=@F86,F87=@F87,F88=@F88,F89=@F89,F90=@F90,F91=@F91,F92=@F92,F93=@F93,F94=@F94,F95=@F95,F96=@F96,F97=@F97,F98=@F98,F99=@F99,F100=@F100,F101=@F101,F102=@F102,F103=@F103,F104=@F104,F105=@F105,F106=@F106,F107=@F107,F108=@F108,F109=@F109,F110=@F110,F111=@F111,F112=@F112,F113=@F113,F114=@F114,F115=@F115,F116=@F116,F117=@F117,F118=@F118,F119=@F119,F120=@F120,F121=@F121,F122=@F122,F123=@F123,F124=@F124,F125=@F125,F126=@F126,F127=@F127,F128=@F128,F129=@F129,F130=@F130,F131=@F131,F132=@F132,F133=@F133,F134=@F134,F135=@F135,F136=@F136,F137=@F137,F138=@F138,F139=@F139,F140=@F140,F141=@F141,F142=@F142,F143=@F143,F144=@F144,F145=@F145,F146=@F146,F147=@F147,F148=@F148,F149=@F149,F150=@F150,F151=@F151,F152=@F152,F153=@F153 WHERE Id=@Id", ConectionBank)
                For i As Integer = 0 To TV.Nodes.Count - 1
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Replace(TV.Nodes(i).Text.ToString.Substring(0, TV.Nodes(i).Text.ToString.IndexOf("-")), "کد", "")
                    cmd.Parameters.AddWithValue("@F1", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F1", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F2", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F2", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F3", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F3", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F4", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F4", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F5", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F5", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F6", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F6", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F7", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F7", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F8", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F8", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F9", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F9", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F10", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F10", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F11", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F11", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F12", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F12", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F13", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F13", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F14", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F14", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F15", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F15", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F16", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F16", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F17", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F17", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F18", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F18", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F19", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F19", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F20", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F20", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F21", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F21", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F22", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F22", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F23", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F23", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F24", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F24", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F25", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F25", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F26", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F26", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F27", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F27", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F28", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F28", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F29", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F29", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F30", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F30", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F31", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F31", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F32", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F32", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F33", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F33", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F34", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F34", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F35", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F35", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F36", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F36", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F37", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F37", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F38", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F38", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F39", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F39", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F40", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F40", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F41", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F41", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F42", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F42", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F43", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F43", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F44", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F44", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F45", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F45", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F46", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F46", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F47", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F47", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F48", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F48", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F49", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F49", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F50", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F50", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F51", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F51", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F52", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F52", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F53", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F53", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F54", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F54", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F55", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F55", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F56", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F56", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F57", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F57", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F58", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F58", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F59", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F59", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F60", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F60", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F61", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F61", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F62", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F62", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F63", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F63", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F64", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F64", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F65", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F65", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F66", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F66", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F67", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F67", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F68", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F68", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F69", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F69", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F70", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F70", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F71", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F71", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F72", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F72", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F73", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F73", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F74", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F74", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F75", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F75", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F76", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F76", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F77", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F77", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F78", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F78", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F79", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F79", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F80", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F80", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F81", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F81", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F82", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F82", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F83", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F83", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F84", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F84", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F85", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F85", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F86", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F86", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F87", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F87", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F88", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F88", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F89", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F89", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F90", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F90", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F91", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F91", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F92", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F92", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F93", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F93", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F94", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F94", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F95", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F95", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F96", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F96", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F97", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F97", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F98", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F98", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F99", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F99", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F100", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F100", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F101", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F101", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F102", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F102", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F103", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F103", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F104", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F104", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F105", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F105", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F106", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F106", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F107", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F107", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F108", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F108", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F109", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F109", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F110", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F110", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F111", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F111", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F112", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F112", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F113", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F113", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F114", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F114", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F115", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F115", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F116", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F116", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F117", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F117", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F118", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F118", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F119", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F119", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F120", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F120", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F121", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F121", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F122", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F122", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F123", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F123", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F124", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F124", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F125", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F125", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F126", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F126", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F127", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F127", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F128", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F128", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F129", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F129", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F130", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F130", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F131", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F131", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F132", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F132", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F133", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F133", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F134", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F134", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F135", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F135", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F136", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F136", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F137", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F137", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F138", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F138", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F139", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F139", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F140", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F140", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F141", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F141", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F142", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F142", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F143", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F143", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F144", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F144", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F145", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F145", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F146", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F146", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F147", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F147", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F148", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F148", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F149", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F149", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F150", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F150", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F151", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F151", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F152", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F152", i), key.CreateEncryptor)
                    cmd.Parameters.AddWithValue("@F153", SqlDbType.VarBinary).Value = Sec.StringEncrypt(GetString("F153", i), key.CreateEncryptor)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "User_Access", "EditAccess")
        End Try
    End Sub
    Private Function GetString(ByVal F As String, ByVal i As Integer) As String
        Try
            Dim CodeStr As String = ""

            If F = "F1" Then
                Return If(TV.Nodes(i).Checked = True, "1", "0")
            ElseIf F = "F2" Then
                Return If(TV.Nodes(i).Nodes("Define").Checked = True, "1", "0")
            ElseIf F = "F3" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Checked = True, "1", "0")
            ElseIf F = "F4" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes("Define_City_Ostan_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes("Define_City_Ostan_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Ostan").Nodes("Define_City_Ostan_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F5" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes("Define_City_City_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes("Define_City_City_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_City").Nodes("Define_City_City_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F6" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes("Define_City_Part_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes("Define_City_Part_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_City").Nodes("Define_City_Part").Nodes("Define_City_Part_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F7" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_GroupP").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_GroupP").Nodes("Define_GroupP_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_GroupP").Nodes("Define_GroupP_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_GroupP").Nodes("Define_GroupP_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F8" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("TrazOne").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("TrazOne").Nodes("TrazOne_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F9" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Checked = True, "1", "0")
            ElseIf F = "F10" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_One").Nodes("Check_OnTime_One_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F11" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Check_OnTime").Nodes("Check_OnTime_Two").Nodes("Check_OnTime_Two_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F12" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Kala_OneTime").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Save").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Kala_OneTime").Nodes("Kala_OneTime_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F13" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Kala").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Kala").Nodes("Define_Kala_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Kala").Nodes("Define_Kala_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Kala").Nodes("Define_Kala_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F14" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Vahed").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Vahed").Nodes("Define_Vahed_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Vahed").Nodes("Define_Vahed_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Vahed").Nodes("Define_Vahed_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F15" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Checked = True, "1", "0")
            ElseIf F = "F16" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes("Define_Group_One_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes("Define_Group_One_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_One").Nodes("Define_Group_One_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F17" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes("Define_Group_Two_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes("Define_Group_Two_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Group").Nodes("Define_Group_Two").Nodes("Define_Group_Two_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F18" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Anbar").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Anbar").Nodes("Define_Anbar_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Anbar").Nodes("Define_Anbar_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Anbar").Nodes("Define_Anbar_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F19" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Visitor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Visitor").Nodes("Define_Visitor_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Visitor").Nodes("Define_Visitor_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Visitor").Nodes("Define_Visitor_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F20" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Service").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Service").Nodes("Define_Service_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Service").Nodes("Define_Service_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Service").Nodes("Define_Service_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F21" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Checked = True, "1", "0")
            ElseIf F = "F22" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes("Define_Daramad_One_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes("Define_Daramad_One_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_One").Nodes("Define_Daramad_One_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F23" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes("Define_Daramad_Two_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes("Define_Daramad_Two_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Daramad").Nodes("Define_Daramad_Two").Nodes("Define_Daramad_Two_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F24" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Checked = True, "1", "0")
            ElseIf F = "F25" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes("Define_Charge_One_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes("Define_Charge_One_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_One").Nodes("Define_Charge_One_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F26" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes("Define_Charge_Two_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes("Define_Charge_Two_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Charge").Nodes("Define_Charge_Two").Nodes("Define_Charge_Two_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F27" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Checked = True, "1", "0")
            ElseIf F = "F28" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes("Define_Amval_One_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes("Define_Amval_One_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_One").Nodes("Define_Amval_One_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F29" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes("Define_Amval_Two_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes("Define_Amval_Two_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Amval").Nodes("Define_Amval_Two").Nodes("Define_Amval_Two_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F30" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Checked = True, "1", "0")
            ElseIf F = "F31" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes("Define_Sarmayeh_One_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes("Define_Sarmayeh_One_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_One").Nodes("Define_Sarmayeh_One_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F32" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes("Define_Sarmayeh_Two_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes("Define_Sarmayeh_Two_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Sarmayeh").Nodes("Define_Sarmayeh_Two").Nodes("Define_Sarmayeh_Two_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F33" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Manage_Chk_Bank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Change").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Manage_Chk_Bank").Nodes("Manage_Chk_Bank_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F34" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_OtherBank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_OtherBank").Nodes("Define_OtherBank_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_OtherBank").Nodes("Define_OtherBank_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_OtherBank").Nodes("Define_OtherBank_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F35" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Bank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Bank").Nodes("Define_Bank_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Bank").Nodes("Define_Bank_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Bank").Nodes("Define_Bank_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F36" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Box").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Box").Nodes("Define_Box_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Box").Nodes("Define_Box_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Box").Nodes("Define_Box_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F37" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_People").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Print").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_People").Nodes("Define_People_Active").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F38" Then
                Return If(TV.Nodes(i).Nodes("Account").Checked = True, "1", "0")
            ElseIf F = "F39" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_0").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_1").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_2").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_3").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_4").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_5").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_6").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_7").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_8").Checked = True, "1", "0")
                Try
                    Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Checked = True, "1", "0")
                    Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Add").Checked = True, "1", "0")
                    Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Del").Checked = True, "1", "0")
                    Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("Factor").Nodes("Factor_9").Nodes("Factor_9_Edit").Checked = True, "1", "0")
                    Tmp_Str &= "0"
                Catch ex As Exception
                    Tmp_Str &= "00000"
                End Try

                Return Tmp_Str
            ElseIf F = "F40" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Show").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintFac").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintAnbar").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintFish").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_AllPrint").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_SMS").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_Convert").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactor").Nodes("ManageFactor_PrintList").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F41" Then
                Return If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Checked = True, "1", "0")
            ElseIf F = "F42" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_Change").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_Print").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_State").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Get").Nodes("ManageChk_Get_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F43" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_Change").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_Print").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_State").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageChk").Nodes("ManageChk_Pay").Nodes("ManageChk_Pay_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F44" Then
                Return If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Checked = True, "1", "0")
            ElseIf F = "F45" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Get").Nodes("DayWork_Get_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F46" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Pay").Nodes("DayWork_Pay_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F47" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_PTP").Nodes("DayWork_PTP_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F48" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_ChargeK").Nodes("DayWork_ChargeK_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F49" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Charge").Nodes("DayWork_Charge_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F50" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Daramad").Nodes("DayWork_Daramad_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F51" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes("DayWork_Amval_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes("DayWork_Amval_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Amval").Nodes("DayWork_Amval_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F52" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes("DayWork_Sarmayeh_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes("DayWork_Sarmayeh_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_Sarmayeh").Nodes("DayWork_Sarmayeh_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F53" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes("DayWork_AddDecBox_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes("DayWork_AddDecBox_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBox").Nodes("DayWork_AddDecBox_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F54" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes("DayWork_BoxBox_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes("DayWork_BoxBox_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BoxBox").Nodes("DayWork_BoxBox_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F55" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes("DayWork_AddDecBank_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes("DayWork_AddDecBank_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_AddDecBank").Nodes("DayWork_AddDecBank_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F56" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes("DayWork_BankBank_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes("DayWork_BankBank_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBank").Nodes("DayWork_BankBank_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F57" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes("DayWork_BankBox_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes("DayWork_BankBox_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_BankBox").Nodes("DayWork_BankBox_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F58" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Checked = True, "1", "0")
            ElseIf F = "F59" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("Translate").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("Translate").Nodes("Translate_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F60" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("Kardexkala").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("Kardexkala").Nodes("Kardexkala_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F61" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("KardexAnbar").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("KardexAnbar").Nodes("KardexAnbar_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F62" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyKala").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyKala").Nodes("MojodyKala_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F62" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyKala").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyKala").Nodes("MojodyKala_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F63" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyAnbar").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyAnbar").Nodes("MojodyAnbar_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F64" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyRKala").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyRKala").Nodes("MojodyRKala_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F65" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyRAnbar").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("MojodyRAnbar").Nodes("MojodyRAnbar_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F66" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("LowBalance").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("LowBalance").Nodes("LowBalance_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F67" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Anbar").Nodes("HightBalance").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Anbar").Nodes("HightBalance").Nodes("HightBalance_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F68" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("BalanceKala").Checked = True, "1", "0")
            ElseIf F = "F69" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("BuyKala").Checked = True, "1", "0")
            ElseIf F = "F70" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("BackBuyKala").Checked = True, "1", "0")
            ElseIf F = "F71" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("SellKala").Checked = True, "1", "0")
            ElseIf F = "F72" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("BackSellKala").Checked = True, "1", "0")
            ElseIf F = "F73" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("DamageKala").Checked = True, "1", "0")
            ElseIf F = "F74" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("ServiceKala").Checked = True, "1", "0")
            ElseIf F = "F75" Then
                Return If(TV.Nodes(i).Nodes("Anbar").Nodes("BarCodeKala").Checked = True, "1", "0")
            ElseIf F = "F76" Then
                Return If(TV.Nodes(i).Nodes("People").Checked = True, "1", "0")
            ElseIf F = "F77" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Moein_People").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Moein_People").Nodes("Moein_People_Print").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Moein_People").Nodes("Moein_People_SMS").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F78" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Moein_Kala_People").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Moein_Kala_People").Nodes("Moein_Kala_People_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F79" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Moein_Box").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Moein_Box").Nodes("Moein_Box_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F80" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Mojody_Box").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Mojody_Box").Nodes("Mojody_Box_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F81" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Moein_Bank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Moein_Bank").Nodes("Moein_Bank_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F82" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Mojody_Bank").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Mojody_Bank").Nodes("Mojody_Bank_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F83" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("People").Nodes("Daftar_Kol").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("People").Nodes("Daftar_Kol").Nodes("BtnSMS").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F84" Then
                Return If(TV.Nodes(i).Nodes("People").Nodes("Daftar_day").Checked = True, "1", "0")
            ElseIf F = "F85" Then
                Return If(TV.Nodes(i).Nodes("People").Nodes("Report_Charge").Checked = True, "1", "0")
            ElseIf F = "F86" Then
                Return If(TV.Nodes(i).Nodes("People").Nodes("Report_Daramd").Checked = True, "1", "0")
            ElseIf F = "F87" Then
                Return If(TV.Nodes(i).Nodes("People").Nodes("Report_Amval").Checked = True, "1", "0")
            ElseIf F = "F88" Then
                Return If(TV.Nodes(i).Nodes("People").Nodes("Report_sarmayeh").Checked = True, "1", "0")
            ElseIf F = "F89" Then
                Return If(TV.Nodes(i).Nodes("Mali").Checked = True, "1", "0")
            ElseIf F = "F90" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Mali").Nodes("Report_GetChk").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("Report_GetChk").Nodes("BtnSMS").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F91" Then
                Return If(TV.Nodes(i).Nodes("Mali").Nodes("Report_PayChk").Checked = True, "1", "0")
            ElseIf F = "F92" Then
                Return If(TV.Nodes(i).Nodes("Mali").Nodes("Report_BratChk").Checked = True, "1", "0")
            ElseIf F = "F93" Then
                Return If(TV.Nodes(i).Nodes("Mali").Nodes("Report_InfoChk").Checked = True, "1", "0")
            ElseIf F = "F94" Then
                Return If(TV.Nodes(i).Nodes("Mali").Nodes("State_InfoChk").Checked = True, "1", "0")
            ElseIf F = "F95" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Mali").Nodes("SodFactor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("SodFactor").Nodes("SodFactor_Show").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("SodFactor").Nodes("SodFactor_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("SodFactor").Nodes("SodFactor_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F96" Then
                Return If(TV.Nodes(i).Nodes("Mali").Nodes("NSod").Checked = True, "1", "0")
            ElseIf F = "F97" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Mali").Nodes("Sod").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("Sod").Nodes("Sod_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F98" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Mali").Nodes("TrazTwo").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("TrazTwo").Nodes("TrazTwo_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F99" Then
                Return If(TV.Nodes(i).Nodes("Manage").Checked = True, "1", "0")
            ElseIf F = "F100" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("ControlFactor").Checked = True, "1", "0")
            ElseIf F = "F101" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("FroshUser").Checked = True, "1", "0")
            ElseIf F = "F102" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("FroshVisitor").Checked = True, "1", "0")
            ElseIf F = "F103" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("SumFactor").Checked = True, "1", "0")
            ElseIf F = "F104" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Manage").Nodes("DelayFactor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Tasveh").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_Print").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("DelayFactor").Nodes("DelayFactor_SMS").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F105" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("DelaySell").Checked = True, "1", "0")
            ElseIf F = "F106" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("TableCost").Checked = True, "1", "0")
            ElseIf F = "F107" Then
                Return If(TV.Nodes(i).Nodes("SMS").Checked = True, "1", "0")
            ElseIf F = "F108" Then
                Return If(TV.Nodes(i).Nodes("SMS").Nodes("ActiveSMS").Checked = True, "1", "0")
            ElseIf F = "F109" Then
                Return If(TV.Nodes(i).Nodes("SMS").Nodes("SendOneSMS").Checked = True, "1", "0")
            ElseIf F = "F110" Then
                Return If(TV.Nodes(i).Nodes("SMS").Nodes("SendGlobalSMS").Checked = True, "1", "0")
            ElseIf F = "F111" Then
                Return If(TV.Nodes(i).Nodes("InfoCompany").Checked = True, "1", "0")
            ElseIf F = "F112" Then
                Return If(TV.Nodes(i).Nodes("Backup").Checked = True, "1", "0")
            ElseIf F = "F113" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("AllFroshUser").Checked = True, "1", "0")
            ElseIf F = "F114" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("AllFroshVisitor").Checked = True, "1", "0")
            ElseIf F = "F115" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Part").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Part").Nodes("Define_Part_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F116" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Mali").Nodes("SodFactor2").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Mali").Nodes("SodFactor2").Nodes("SodFactor2_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F117" Then
                Return If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Checked = True, "1", "0")
            ElseIf F = "F118" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_R").Nodes("Define_Driver_R_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F119" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_D").Nodes("Define_Driver_D_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F120" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_Driver").Nodes("Define_Driver_Car").Nodes("Define_Driver_Car_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F121" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Manage").Nodes("ExitFactor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_DelExit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_DelFactor").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Manage").Nodes("ExitFactor").Nodes("ExitFactor_Change").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F122" Then
                Return If(TV.Nodes(i).Nodes("People").Nodes("Darsad_Risk").Checked = True, "1", "0")
            ElseIf F = "F123" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaCost").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_DelCity").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_DelCost").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaCost").Nodes("Define_KalaCost_EditCost").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F124" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaDiscount").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaDiscount").Nodes("Define_KalaDiscount_Del").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F125" Then
                Return If(TV.Nodes(i).Nodes("Setting").Checked = True, "1", "0")
            ElseIf F = "F126" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaSCost").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaSCost").Nodes("Define_KalaSCost_Print").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F127" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("DelayExit").Checked = True, "1", "0")
            ElseIf F = "F128" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_VisitGol").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_VisitGol").Nodes("Define_VisitGol_Del").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F129" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("VisitGol").Checked = True, "1", "0")
            ElseIf F = "F130" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("PathPeople").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("PathPeople").Nodes("BtnSMS").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F131" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Checked = True, "1", "0")
            ElseIf F = "F132" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("ManageB").Checked = True, "1", "0")
            ElseIf F = "F133" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Checked = True, "1", "0")
            ElseIf F = "F134" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChCharge").Checked = True, "1", "0")
            ElseIf F = "F135" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChDaramad").Checked = True, "1", "0")
            ElseIf F = "F136" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChAmval").Checked = True, "1", "0")
            ElseIf F = "F137" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChSarmayeh").Checked = True, "1", "0")
            ElseIf F = "F138" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChFroshOstan").Checked = True, "1", "0")
            ElseIf F = "F139" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChFroshCity").Checked = True, "1", "0")
            ElseIf F = "F140" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChFroshPart").Checked = True, "1", "0")
            ElseIf F = "F141" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("StateFroshUser").Checked = True, "1", "0")
            ElseIf F = "F142" Then
                Return If(TV.Nodes(i).Nodes("ManageFrosh").Nodes("StateFroshVisitor").Checked = True, "1", "0")
            ElseIf F = "F143" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_Show").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeFrosh").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangePish").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeNo").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("ManageFactorM").Nodes("ManageFactorM_ChangeCur").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F144" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_TmpPeople").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_TmpPeople").Nodes("Define_TmpPeople_Ok").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_TmpPeople").Nodes("Define_TmpPeople_Del").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F145" Then
                Return If(TV.Nodes(i).Nodes("Mali").Nodes("Report_Discount").Checked = True, "1", "0")
            ElseIf F = "F146" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("Delay").Checked = True, "1", "0")
            ElseIf F = "F147" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChGetChk").Checked = True, "1", "0")
            ElseIf F = "F148" Then
                Return If(TV.Nodes(i).Nodes("ChartReport").Nodes("ChPayChk").Checked = True, "1", "0")
            ElseIf F = "F149" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_UserGol").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_UserGol").Nodes("Define_UserGol_Del").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F150" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaRate").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Define").Nodes("Define_KalaRate").Nodes("Define_KalaRate_Del").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F151" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Add").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Del").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("Account").Nodes("DayWork").Nodes("DayWork_EditMoein").Nodes("DayWork_EditMoein_Edit").Checked = True, "1", "0")
                Return Tmp_Str
            ElseIf F = "F152" Then
                Return If(TV.Nodes(i).Nodes("Manage").Nodes("RateFactor").Checked = True, "1", "0")
            ElseIf F = "F153" Then
                Dim Tmp_Str As String = ""
                Tmp_Str = If(TV.Nodes(i).Nodes("MessageCenter").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("MessageCenter").Nodes("MessageCenter_Edit").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("MessageCenter").Nodes("MessageCenter_Dell").Checked = True, "1", "0")
                Tmp_Str &= If(TV.Nodes(i).Nodes("MessageCenter").Nodes("MessageCenter_Add").Checked = True, "1", "0")
                Return Tmp_Str
            End If
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class