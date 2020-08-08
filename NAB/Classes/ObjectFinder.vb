Imports System
Imports System.Windows.Forms
Imports System.Reflection

Public Class ObjectFinder
    Public Shared Function CreateObjectInstance(ByVal objectName As String) As Object
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                objectName = String.Format("{0}.{1}", [Assembly].GetEntryAssembly.GetName.Name, objectName)
            End If
            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)
        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj
    End Function

    Public Shared Function CreateForm(ByVal formName As String) As Form
        Return DirectCast(CreateObjectInstance(formName), Form)
    End Function
End Class
