Imports System.Data.SqlClient
Imports System.Threading
Public Class FrmPrint
    Public PrintSQl, CHoose, Str1, Str2, State, IdFactor, Lend As String
    Public Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10, Num11, Num12, Num13, Num14, Num15 As Double
    Public DtMoeinPeople As New DataTable
    Public DtDaftarDay As New DataTable
    Public DtMoeinKalaPeople As New DataTable
    Public DtMoeinBox As New DataTable
    Public DtSarmayeh As New DataTable
    Public DtMoeinBank As New DataTable
    Public DtMoeinKardex As New DataTable
    Public DtS As New DataTable
    Public DtTraz As New DataTable
    Public DtDiscount As New DataTable
    Public DtRateFactor As New DataTable
    Public dv As DataView

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub Traz()
        Try
            Dim Dataret As New Traz
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            Dataret.DataTable1.Rows(0).Item("MonTraz") = Dataret.DataTable1.Rows(0).Item("daray") - Dataret.DataTable1.Rows(0).Item("Pardakht")
            Dataret.DataTable1.Rows(0).Item("D_Date") = GetDate()
            Dim ret As New CRP_Traz
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Traz")
            Me.Close()
        End Try
    End Sub

    Private Sub TrazTwo()
        Try
            Dim Dataret As New Traz
            Dataret.Clear()
            Dataret.DataTable1.AddDataTable1Row(Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10, Num11, Num12, GetDate, Num13)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            If UCase(CHoose) = "TRAZTWO" Then
                Dim ret As New CRP_TrazT
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
            ElseIf UCase(CHoose) = "TRAZEND" Then
                Dim ret As New CRP_TrazET
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
            End If
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "TrazTwo")
            Me.Close()
        End Try
    End Sub
    Private Sub Traz_2_4()
        Try

            If Not DtTraz.Columns.Contains("PrintDat") Then DtTraz.Columns.Add("PrintDat", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            DtTraz.Rows(0).Item("PrintDat") = GetDate()
            If UCase(CHoose) = "TRAZ4" Then
                Dim ret As New CRP_Traz4Column
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DtTraz)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                Dim ret As New CRP_Traz2Column
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DtTraz)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Traz_2_4")
            Me.Close()
        End Try
    End Sub
    Private Sub Factor()
        Try
            Dim Dataret As New DataSetFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("کالاهای فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            Dim Kind As String = GetKindFactor()
            If State = "3" Then
                If Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim count As Long = 0
                    If Dataret.DataTable1.Rows.Count <= 20 Then
                        count = 20 - Dataret.DataTable1.Rows.Count
                    Else
                        count = 20 - (Dataret.DataTable1.Rows.Count Mod 20)
                    End If
                    Dim x() As Byte = Nothing
                    Dataret.DataTable1.Columns("Id").AllowDBNull = True
                    For i As Integer = 0 To count - 1
                        Dataret.DataTable1.AddDataTable1Row(0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", "", "", x, 0, 0, "", 0, 0, x, "", 0, 0, 0, "", 0, "0", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                    Next
                End If
            End If
            '//////////////////////////////////////////
            Dim QueryInfo As String = ""
            If State = "0" Or State = "2" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBuy WHERE  ListFactorBuy.IdFactor =" & CLng(IdFactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBuy.IdName AS CodeP,ListFactorBuy.MonAdd ,ListFactorBuy.MonDec ,ListFactorBuy.Discount ,ListFactorBuy.Cash ,ListFactorBuy.MonHavaleh ,(ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) AS MonPayChk , ListFactorBuy.D_date,ListFactorBuy.IdUser , ISNULL(ListFactorBuy.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBuy.IdVisitor,NamVisit='' FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBuy.IdFactor =" & CLng(IdFactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBuy.IdName AS CodeP,ListFactorBuy.MonAdd ,ListFactorBuy.MonDec ,ListFactorBuy.Discount ,ListFactorBuy.Cash ,ListFactorBuy.MonHavaleh ,(ListFactorBuy.MonPayChk+ListFactorBuy.MonSellChk ) AS MonPayChk ,ListFactorBuy.D_date,ListFactorBuy.IdUser, ListFactorBuy.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBuy .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBuy.IdFactor =" & CLng(IdFactor) & "  END"
            ElseIf State = "1" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackBuy WHERE  ListFactorBackBuy.IdFactor =" & CLng(IdFactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackBuy.IdName AS CodeP,ListFactorBackBuy.MonAdd ,ListFactorBackBuy.MonDec ,ListFactorBackBuy.Discount ,ListFactorBackBuy.Cash ,ListFactorBackBuy.MonHavaleh ,ListFactorBackBuy.MonPayChk , ListFactorBackBuy.D_date,ListFactorBackBuy.IdUser , ISNULL(ListFactorBackBuy.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBackBuy.IdVisitor,NamVisit='' FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBackBuy.IdFactor =" & CLng(IdFactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackBuy.IdName AS CodeP,ListFactorBackBuy.MonAdd ,ListFactorBackBuy.MonDec ,ListFactorBackBuy.Discount ,ListFactorBackBuy.Cash ,ListFactorBackBuy.MonHavaleh ,ListFactorBackBuy.MonPayChk ,ListFactorBackBuy.D_date,ListFactorBackBuy.IdUser, ListFactorBackBuy.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBackBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackBuy .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBackBuy.IdFactor =" & CLng(IdFactor) & "  END"
            ElseIf State = "3" Or State = "5" Or State = "7" Then
                QueryInfo = "Declare @itbl table(DriverNam  Nvarchar(max),IdExit Nvarchar(max)) INSERT INTO @itbl SELECT Nam AS DriverNam,IdExit  FROM(SELECT ListExitFactor.IdFactor, ExitFactor.Id AS IdExit, ExitFactor.IdDriver FROM ListExitFactor INNER JOIN ExitFactor ON ListExitFactor.IdList = ExitFactor.Id WHERE ListExitFactor.IdFactor=" & CLng(IdFactor) & ") AS EFactor INNER JOIN Define_Driver ON EFactor.IdDriver =Define_Driver.Id If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor =" & CLng(IdFactor) & ")  Is NULL BEGIN SELECT IdExit=(SELECT ISNULL(MAX(IdExit),'') FROM @itbl),DriverNam=(SELECT ISNULL(MAX(DriverNam),'') FROM @itbl),ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk , ListFactorSell.D_date,ListFactorSell.IdUser , ISNULL(ListFactorSell.Disc,'') AS Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorSell.IdVisitor,NamVisit='' FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorSell.IdFactor =" & CLng(IdFactor) & "  END ELSE BEGIN SELECT IdExit=(SELECT ISNULL(MAX(IdExit),'') FROM @itbl),DriverNam=(SELECT ISNULL(MAX(DriverNam),'') FROM @itbl),ListFactorSell.IdName AS CodeP,ListFactorSell.MonAdd ,ListFactorSell.MonDec ,ListFactorSell.Discount ,ListFactorSell.Cash ,ListFactorSell.MonHavaleh ,ListFactorSell.MonPayChk ,ListFactorSell.D_date,ListFactorSell.IdUser, ListFactorSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorSell.IdFactor =" & CLng(IdFactor) & " END"
            ElseIf State = "4" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackSell WHERE  ListFactorBackSell.IdFactor =" & CLng(IdFactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackSell.IdName AS CodeP,ListFactorBackSell.MonAdd ,ListFactorBackSell.MonDec ,ListFactorBackSell.Discount ,ListFactorBackSell.Cash ,ListFactorBackSell.MonHavaleh ,(ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk ) AS MonPayChk , ListFactorBackSell.D_date,ListFactorBackSell.IdUser , ISNULL(ListFactorBackSell.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorBackSell.IdVisitor,NamVisit='' FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorBackSell.IdFactor =" & CLng(IdFactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorBackSell.IdName AS CodeP,ListFactorBackSell.MonAdd ,ListFactorBackSell.MonDec ,ListFactorBackSell.Discount ,ListFactorBackSell.Cash ,ListFactorBackSell.MonHavaleh ,(ListFactorBackSell.MonPayChk+ListFactorBackSell.MonSellChk ) AS MonPayChk ,ListFactorBackSell.D_date,ListFactorBackSell.IdUser, ListFactorBackSell.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorBackSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackSell .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorBackSell.IdFactor =" & CLng(IdFactor) & "  END"
            ElseIf State = "6" Then
                QueryInfo = "SELECT  IdExit=N'',DriverNam=N'',CodeP=0,MonAdd=0,MonDec=0,Discount=0,Cash=0,MonHavaleh=0,MonPayChk=0,ListFactorDamage.D_date,ListFactorDamage.IdUser ,ISNULL(ListFactorDamage.Disc,'') AS Disc, Nam='',[Address]='',Tell='',NamO='' ,NamCI='',NamP='' ,IdVisitor=0,NamVisit='' FROM ListFactorDamage WHERE ListFactorDamage.IdFactor =" & CLng(IdFactor)
            ElseIf State = "8" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorService WHERE  ListFactorService.IdFactor =" & CLng(IdFactor) & ")  Is NULL BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorService.IdName AS CodeP,ListFactorService.MonAdd ,ListFactorService.MonDec ,ListFactorService.Discount ,ListFactorService.Cash ,ListFactorService.MonHavaleh ,ListFactorService.MonPayChk , ListFactorService.D_date,ListFactorService.IdUser , ISNULL(ListFactorService.Disc,'') As Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP  ,ListFactorService.IdVisitor,NamVisit='' FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart  WHERE   ListFactorService.IdFactor =" & CLng(IdFactor) & "  END ELSE BEGIN SELECT  IdExit=N'',DriverNam=N'',ListFactorService.IdName AS CodeP,ListFactorService.MonAdd ,ListFactorService.MonDec ,ListFactorService.Discount ,ListFactorService.Cash ,ListFactorService.MonHavaleh ,ListFactorService.MonPayChk ,ListFactorService.D_date,ListFactorService.IdUser, ListFactorService.Disc, ISNULL(Define_People.NamFac,'')+ ' ' + Define_People.Nam As Nam,Define_People.[Address],(ISNULL(Define_People.Tell1,'') + ' - ' + ISNULL(Define_People.Tell2,'')) As Tell ,Define_Ostan.NamO ,Define_City .NamCI ,Define_Part .NamP ,ListFactorService.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorService .IdVisitor =Define_Visitor .Id  INNER JOIN Define_Ostan ON Define_Ostan.Code =Define_People .IdOstan INNER JOIN Define_City ON Define_City .Code =Define_People .IdCity INNER JOIN Define_Part ON Define_Part .Code =Define_People .IdPart WHERE  ListFactorService.IdFactor =" & CLng(IdFactor) & "  END"
            End If
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    MessageBox.Show("اطلاعات فاکتور مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("IdExit") = dtrInfo("IdExit")
                    Dataret.DataTable1.Rows(0).Item("DriverNam") = dtrInfo("DriverNam")
                    Dataret.DataTable1.Rows(0).Item("CodeP") = dtrInfo("CodeP")
                    Dataret.DataTable1.Rows(0).Item("d_Date") = dtrInfo("d_date")
                    Dataret.DataTable1.Rows(0).Item("IdFactor") = CLng(IdFactor)
                    Dataret.DataTable1.Rows(0).Item("People") = dtrInfo("Nam")
                    Dataret.DataTable1.Rows(0).Item("Ostan") = dtrInfo("NamO")
                    Dataret.DataTable1.Rows(0).Item("City") = dtrInfo("NamCI")
                    Dataret.DataTable1.Rows(0).Item("Part") = dtrInfo("NamP")
                    Dataret.DataTable1.Rows(0).Item("Address") = dtrInfo("Address")
                    Dataret.DataTable1.Rows(0).Item("Tell") = dtrInfo("Tell")
                    Dataret.DataTable1.Rows(0).Item("Visit") = dtrInfo("NamVisit")
                    Dataret.DataTable1.Rows(0).Item("Acount") = dtrInfo("IdUser")
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") = dtrInfo("Disc")
                    Dataret.DataTable1.Rows(0).Item("Cash") = dtrInfo("Cash")
                    Dataret.DataTable1.Rows(0).Item("DiscountC") = dtrInfo("Discount")
                    Dataret.DataTable1.Rows(0).Item("Chk") = dtrInfo("MonPayChk")
                    Dataret.DataTable1.Rows(0).Item("Add") = dtrInfo("MonAdd")
                    Dataret.DataTable1.Rows(0).Item("Dec") = dtrInfo("MonDec")
                    Dataret.DataTable1.Rows(0).Item("HBank") = dtrInfo("MonHavaleh")
                    Dataret.DataTable1.Rows(0).Item("Lend") = CDbl(Lend)
                    Dataret.DataTable1.Rows(0).Item("PayMon") = dtrInfo("MonAdd") - (dtrInfo("MonDec") + dtrInfo("Discount"))
                    Select Case CLng(State)
                        Case 0 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خرید"
                        Case 1 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "برگشت از خرید"
                        Case 2 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خرید امانی"
                        Case 3 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور فروش"
                        Case 4 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "برگشت از فروش"
                        Case 5 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور فروش امانی"
                        Case 6 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور ضایعات"
                        Case 7 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "پیش فاکتور"
                        Case 8 : Dataret.DataTable1.Rows(0).Item("TypeFac") = "فاکتور خدمات"
                    End Select
                End If
            End Using
            dtrInfo.Close()
            Using SQLComanad As New SqlCommand("SELECT Top 1 CompanyName ,TelFax as CompanyTell,[Address] as CompanyAddress,Header ,Footer,CompanyImage  FROM Define_Company WHERE IdUser=" & Id_User, ConectionBank)
                SQLComanad.CommandTimeout = 0
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Else
                    dtrInfo.Read()
                    Dataret.DataTable1.Rows(0).Item("CompanyName") = dtrInfo("CompanyName")
                    Dataret.DataTable1.Rows(0).Item("CompanyAddress") = dtrInfo("CompanyAddress")
                    Dataret.DataTable1.Rows(0).Item("CompanyTell") = dtrInfo("CompanyTell")
                    Dataret.DataTable1.Rows(0).Item("Header") = dtrInfo("Header")
                    Dataret.DataTable1.Rows(0).Item("Footer") = dtrInfo("Footer")
                    Try
                        Dataret.DataTable1.Rows(0).Item("ImageFactor") = dtrInfo("CompanyImage")
                    Catch ex As Exception

                    End Try
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            dtrInfo.Close()
            '///////////////////////////////////////////////////
            Dim MonRes As Double = 0
            Dim discount As Double = 0
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrDarsad") = Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("AllMoney") = Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                MonRes += Dataret.DataTable1.Rows(i).Item("Mon") - Dataret.DataTable1.Rows(i).Item("DarsadMon")
                discount += Dataret.DataTable1.Rows(i).Item("DarsadMon")
                If Dataret.DataTable1.Rows(i).Item("JozCount") <= 0 Then
                    Dataret.DataTable1.Rows(i).Item("FeKol") = Dataret.DataTable1.Rows(i).Item("Fe")
                    'Dataret.DataTable1.Rows(i).Item("Fe") = 0
                Else
                    Dataret.DataTable1.Rows(i).Item("FeKol") = If(Dataret.DataTable1.Rows(i).Item("KolCount") <> 0, Dataret.DataTable1.Rows(i).Item("Mon") / Dataret.DataTable1.Rows(i).Item("KolCount"), 0)
                End If
                Dataret.DataTable1.Rows(i).Item("Vahed") &= " " & Dataret.DataTable1.Rows(i).Item("KalaDisc")
            Next
            Dataret.DataTable1.Rows(0).Item("PayMon") = MonRes + Dataret.DataTable1.Rows(0).Item("PayMon")

            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") = "توضیحات فاکتور : " & If(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc"))
            ''''''''''''''''''''''''MoeinFactor
            If CLng(State) <> 7 And CLng(State) <> 6 Then
                OldSanad = 0
                CurSanad = 0
                IdKala = 0
                SetMoeinPeopleVarible(CLng(IdFactor), CLng(State))
                Dataret.DataTable1.Rows(0).Item("OldMoein") = GetMoeinPeople(IdKala, OldSanad, Dataret.DataTable1.Rows(0).Item("d_Date"), CLng(State), CLng(IdFactor))
                Dataret.DataTable1.Rows(0).Item("Moein") = If(CLng(State) = 0 Or CLng(State) = 2 Or CLng(State) = 4, Dataret.DataTable1.Rows(0).Item("OldMoein") - Dataret.DataTable1.Rows(0).Item("PayMon") + Dataret.DataTable1.Rows(0).Item("Cash") + Dataret.DataTable1.Rows(0).Item("Chk") + Dataret.DataTable1.Rows(0).Item("HBank"), Dataret.DataTable1.Rows(0).Item("OldMoein") + Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("Cash") - Dataret.DataTable1.Rows(0).Item("Chk") - Dataret.DataTable1.Rows(0).Item("HBank"))
                Dim Tmpdate As String = GetOldTime(IdKala, OldSanad, Dataret.DataTable1.Rows(0).Item("d_Date"), CLng(State), CLng(IdFactor))
                If Not String.IsNullOrEmpty(Tmpdate) Then
                    Dim T As Long = SUBDAY(Dataret.DataTable1.Rows(0).Item("d_Date"), Tmpdate)
                    If Kind.Contains("A4ES3") Or Kind.Contains("A4ES4") Then
                        If T <> 0 Then
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = "مانده قبلی در تاریخ" & Tmpdate & " معادل" & T & " روز می باشد"
                        Else
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                        End If
                    Else
                        If T <> 0 Then
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") &= If(Not String.IsNullOrEmpty(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc")), " . ", "") & "مانده قبلی در تاریخ" & Tmpdate & " معادل" & T & " روز می باشد"
                        Else
                            Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                        End If
                    End If
                Else
                    If Kind.Contains("A4ES3") Then
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = "مـانـده قــبــلـی"
                    Else
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc2") = ""
                    End If
                End If
                If State = 3 Then
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc") &= If(Not String.IsNullOrEmpty(Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Disc")), " . ", "") & GetCashMonDisc(CLng(IdFactor))
                End If
                If Dataret.DataTable1.Rows(0).Item("Moein") < 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str((Dataret.DataTable1.Rows(0).Item("Moein") * -1)) & "-بستانکار"
                ElseIf Dataret.DataTable1.Rows(0).Item("Moein") = 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str(0) & "-بی حساب"
                ElseIf Dataret.DataTable1.Rows(0).Item("Moein") > 0 Then
                    Dim s As New NumberToString
                    Dataret.DataTable1.Rows(0).Item("StrMoein") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("Moein")) & "-بدهکار"
                End If
            End If
            '//////////////////////////////////////////
            If (State = "3" Or State = "5") And (Kind.Contains("A4ES") Or Kind.Contains("A4ES2") Or Kind.Contains("A4ES4") Or Kind.Contains("EPSON100S") Or Kind.Contains("EPSON130S") Or Kind.Contains("A4ES3")) Then
                CallDiscountFactor(Dataret.DataTable1.Rows(0).Item("CodeP"), Dataret.DataTable1.Rows(0).Item("IdFactor"))
                Dim dec As Double = GetCashMonDisc2(CLng(IdFactor))
                Dataret.DataTable1.Rows(0).Item("CashDiscount") = Math.Round((TmpDarsad * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2)
                Dataret.DataTable1.Rows(0).Item("PelDiscount") = Math.Round((TmpDarsad1 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2)
                Dataret.DataTable1.Rows(0).Item("EndMon") = Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("PelDiscount") - Dataret.DataTable1.Rows(0).Item("CashDiscount")
                Dataret.DataTable1.Rows(0).Item("KindFrosh") = CallKindFactor(Dataret.DataTable1.Rows(0).Item("IdFactor"), Dataret.DataTable1.Rows(0).Item("d_Date"))
                If (Kind.Contains("A4ES2") Or Kind.Contains("A4ES3") Or Kind.Contains("A4ES4")) Then
                    If Kind.Contains("A4ES3") Or Kind.Contains("A4ES4") Then
                        CallDiscountChkFactor(Dataret.DataTable1.Rows(0).Item("CodeP"))
                        Dataret.DataTable1.Rows(0).Item("TChk1") = tc1
                        Dataret.DataTable1.Rows(0).Item("TChk2") = tc2
                        Dataret.DataTable1.Rows(0).Item("TChk3") = tc3
                        Dataret.DataTable1.Rows(0).Item("MonChk1") = If(TmpDarsad <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(0).Item("MonChk2") = If(TmpDarsad1 <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad1 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(0).Item("MonChk3") = If(TmpDarsad2 <= 0, 0, Dataret.DataTable1.Rows(0).Item("PayMon") - Math.Round((TmpDarsad2 * (Dataret.DataTable1.Rows(0).Item("PayMon") + If(TmpHajm = True, 0, discount) - If(TmpKalaCash = True, dec, 0))) / 100, 2))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndCashMon") = Dataret.DataTable1.Rows(0).Item("EndMon") + Dataret.DataTable1.Rows(0).Item("OldMoein")
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk1Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk1") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk1") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk2Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk2") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk2") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                        Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndChk3Mon") = If(Dataret.DataTable1.Rows(0).Item("MonChk3") = 0, 0, Dataret.DataTable1.Rows(0).Item("MonChk3") + Dataret.DataTable1.Rows(0).Item("OldMoein"))
                    End If
                    If Kind.Contains("A4ES4") Then
                        CallDiscountCardFactor(Dataret.DataTable1.Rows(0).Item("CodeP"), Dataret.DataTable1.Rows(0).Item("IdFactor"))
                        Dataret.DataTable1.Rows(0).Item("CardDiscount") = TmpDarsad
                        Dataret.DataTable1.Rows(0).Item("CardCash") = Dataret.DataTable1.Rows(0).Item("PayMon") - Dataret.DataTable1.Rows(0).Item("CardDiscount")
                        SetEndMonKala(Dataret, Dataret.DataTable1.Rows(0).Item("CodeP"))
                    End If
                Else
                    SetEndMonKala(Dataret, Dataret.DataTable1.Rows(0).Item("CodeP"))
                End If
            Else
                Dataret.DataTable1.Rows(0).Item("CashDiscount") = 0
                Dataret.DataTable1.Rows(0).Item("PelDiscount") = 0
                Dataret.DataTable1.Rows(0).Item("EndMon") = Dataret.DataTable1.Rows(0).Item("PayMon")
                Dataret.DataTable1.Rows(0).Item("KindFrosh") = ""
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndCashMon") = 0
            End If
            '//////////////////////////////////////////
            If CLng(State) = 3 Or CLng(State) = 4 Or CLng(State) = 5 Then

                ''''''''''''''''''نوع فروشگاهی A4 کاغذ
                If Kind = "A4EFGKB" Then
                    Dim ret As New CRP_Factor_sell_A4EF_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGKS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKB" Then
                    Dim ret As New CRP_Factor_sell_A4EF
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGB" Then
                    Dim ret As New CRP_Factor_sell_A4EF_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGS" Then
                    Dim ret As New CRP_Factor_sell_A4EF_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع توزیعی A4 کاغذ
                ElseIf Kind = "A4ETGKB" Then
                    Dim ret As New CRP_Factor_sell_A4ET_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETGKS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETKB" Then
                    Dim ret As New CRP_Factor_sell_A4ET
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETKS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETGB" Then
                    Dim ret As New CRP_Factor_sell_A4ET_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETGS" Then
                    Dim ret As New CRP_Factor_sell_A4ET_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع پخش سراسرس A4 کاغذ
                ElseIf Kind = "A4ESGKB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ESGKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ESKB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ESKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ESGB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ESGS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                    ''''''''''''''''''نوع توزیعی 2 A4 کاغذ
                ElseIf Kind = "A4ES2GKB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES2GKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES2KB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES2KS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES2GB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES2GS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES2_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If

                    ''''''''''''''''''نوع توزیعی 3 A4 کاغذ
                ElseIf Kind = "A4ES3GKB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES3GKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES3KB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES3KS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES3GB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES3GS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES3_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If

                    ''''''''''''''''''نوع توزیعی 4 A4 کاغذ
                ElseIf Kind = "A4ES4GKB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES4GKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_G_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES4KB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES4KS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES4GB" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "A4ES4GS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_A4ES4_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_A4ET_K_s
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If

                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_sell_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_sell_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_sell_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_sell_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Then
                    Dim ret As New CRP_Factor_sell_Epson100F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    ''''''''''''''''''نوع توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Then
                    Dim ret As New CRP_Factor_sell_Epson100T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع پخش سراسری EPSON100 کاغذ
                ElseIf Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson100S_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                    ''''''''''''''''''نوع فاکتور آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    If CLng(State) = 3 Then
                        Dim ret As New CRP_Factor_sell_Epson100P
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson100T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If

                    ''''''''''''''''''نوع فروشگاهی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Then
                    Dim ret As New CRP_Factor_sell_Epson130F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    ''''''''''''''''''نوع توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Then
                    Dim ret As New CRP_Factor_sell_Epson130T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T_G
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                ElseIf Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    If CLng(State) = 3 Or CLng(State) = 5 Then
                        Dim ret As New CRP_Factor_sell_Epson130S_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_Factor_sell_Epson130T_K
                        ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                        Application.DoEvents()
                        ret.SetDataSource(Dataret)
                        CRV.ReportSource = ret
                    End If
                End If
            ElseIf State = 0 Or State = 1 Or State = 2 Then
                ''''''''''''''''''نوع فروشگاهی A4 کاغذ
                If Kind = "A4EFGKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGB" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGS" Then
                    Dim ret As New CRP_Factor_Buy_A4EF_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                ElseIf Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_Buy_A4ET_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Buy_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    '''''''''''''''''' نوع توزیعی و پخش سراسری و آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson100T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130F_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    ''''''''''''''''''نوع توزیعی و پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Buy_Epson130T_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                End If
            ElseIf State = 7 Then
                ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_PishSell_A4E_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_PishSell_A4EL_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی و پخش سرایری و توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson100_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی و پخش سراسری و توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Pishsell_Epson130_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                End If
            ElseIf State = 8 Then
                ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و توزیعی 2و3و4 A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Then
                    Dim ret As New CRP_Factor_Service_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Then
                    Dim ret As New CRP_Factor_Service_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Then
                    Dim ret As New CRP_Factor_Service_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Then
                    Dim ret As New CRP_Factor_Service_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    ''''''''''''''''''نوع فروشگاهی ساده A4 کاغذ
                ElseIf Kind = "A4ELGKB" Or Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Service_A4EL_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELGKS" Or Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Service_A4EL_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Service_A4EL
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Service_A4EL_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی و پخش سرایری و توزیعی EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100FGB" Or Kind = "EPSON100TGB" Or Kind = "EPSON100SGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Service_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Service_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی و پخش سراسری و توزیعی EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Or Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Service_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Service_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                End If

            ElseIf State = 6 Then
                '''''''''''''''''' نوع فروشگاهی و پخش سراسری و توزیعی 1,2,3,4 و فروشگاهی ساده A4 کاغذ
                If Kind = "A4EFGKB" Or Kind = "A4ETGKB" Or Kind = "A4ESGKB" Or Kind = "A4ES2GKB" Or Kind = "A4ES3GKB" Or Kind = "A4ES4GKB" Or Kind = "A4ELGKB" Then
                    Dim ret As New CRP_Factor_Damage_A4E_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGKS" Or Kind = "A4ETGKS" Or Kind = "A4ESGKS" Or Kind = "A4ES2GKS" Or Kind = "A4ES3GKS" Or Kind = "A4ES4GKS" Or Kind = "A4ELGKS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_G_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKB" Or Kind = "A4ETKB" Or Kind = "A4ESKB" Or Kind = "A4ES2KB" Or Kind = "A4ES3KB" Or Kind = "A4ES4KB" Or Kind = "A4ELKB" Then
                    Dim ret As New CRP_Factor_Damage_A4E
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFKS" Or Kind = "A4ETKS" Or Kind = "A4ESKS" Or Kind = "A4ES2KS" Or Kind = "A4ES3KS" Or Kind = "A4ES4KS" Or Kind = "A4ELKS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGB" Or Kind = "A4ETGB" Or Kind = "A4ESGB" Or Kind = "A4ES2GB" Or Kind = "A4ES3GB" Or Kind = "A4ES4GB" Or Kind = "A4ELGB" Then
                    Dim ret As New CRP_Factor_Damage_A4E_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "A4EFGS" Or Kind = "A4ETGS" Or Kind = "A4ESGS" Or Kind = "A4ES2GS" Or Kind = "A4ES3GS" Or Kind = "A4ES4GS" Or Kind = "A4ELGS" Then
                    Dim ret As New CRP_Factor_Damage_A4E_K_s
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع فروشگاهی و توزیعی و پخش سراسری و آماده EPSON100 کاغذ
                ElseIf Kind = "EPSON100FGKB" Or Kind = "EPSON100FGKS" Or Kind = "EPSON100TGKB" Or Kind = "EPSON100TGKS" Or Kind = "EPSON100SGKB" Or Kind = "EPSON100SGKS" Or Kind = "EPSON100PS" Or Kind = "EPSON100PB" Or Kind = "EPSON100PGKB" Or Kind = "EPSON100PGKS" Or Kind = "EPSON100PKS" Or Kind = "EPSON100PKB" Or Kind = "EPSON100PGB" Or Kind = "EPSON100PGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FKB" Or Kind = "EPSON100FKS" Or Kind = "EPSON100TKB" Or Kind = "EPSON100TKS" Or Kind = "EPSON100SKB" Or Kind = "EPSON100SKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON100FGB" Or Kind = "EPSON100FGS" Or Kind = "EPSON100TGB" Or Kind = "EPSON100TGS" Or Kind = "EPSON100SGB" Or Kind = "EPSON100SGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson100_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Letter
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret

                    ''''''''''''''''''نوع توزیعی و پخش سراسری EPSON130 کاغذ
                ElseIf Kind = "EPSON130FGKB" Or Kind = "EPSON130FGKS" Or Kind = "EPSON130TGKB" Or Kind = "EPSON130TGKS" Or Kind = "EPSON130SGKB" Or Kind = "EPSON130SGKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130_G
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FKB" Or Kind = "EPSON130FKS" Or Kind = "EPSON130TKB" Or Kind = "EPSON130TKS" Or Kind = "EPSON130SKB" Or Kind = "EPSON130SKS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                ElseIf Kind = "EPSON130FGB" Or Kind = "EPSON130FGS" Or Kind = "EPSON130TGB" Or Kind = "EPSON130TGS" Or Kind = "EPSON130SGB" Or Kind = "EPSON130SGS" Then
                    Dim ret As New CRP_Factor_Damage_Epson130_K
                    ret.PrintOptions.PaperSize = Printing.PaperKind.Standard10x11
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                End If

            End If
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Factor")
            Me.Close()
        End Try
    End Sub


    Private Sub ResedAnbar()
        Try
            Dim Dataret As New DataSetAnbar
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("کالاهای رسید مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            Dataret.DataTable1.Rows(0).Item("IdFactor") = CLng(IdFactor)
            Dataret.DataTable1.Rows(0).Item("D_date") = Lend
            Dataret.DataTable1.Rows(0).Item("TypeFac") = Str2
            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("StrKol") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("StrJoz") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(i).Item("Vahed") &= " " & Dataret.DataTable1.Rows(i).Item("KalaDisc")
            Next
            Dim ret As New CRP_Resid_Anbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ResedAnbar")
            Me.Close()
        End Try
    End Sub
    Private Sub SodorChk()
        Try
            Dim Dataret As New SodorChk
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.Chk_Get_Pay.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.Chk_Get_Pay)
            'Application.DoEvents()
            'End Using
            '''''''''''''''''''''''''''''
            For i As Long = Num1 To Num2
                Dim dr() As DataRow = Dataret.Chk_Get_Pay.Select("NumChk=" & i)
                If dr.Length <= 0 Then
                    Dim row As DataRow = Dataret.Chk_Get_Pay.NewRow
                    row.Item("NumChk") = i
                    row.Item("MoneyChk") = 0
                    row.Item("State") = "استفاده نشده"
                    Dataret.Chk_Get_Pay.Rows.Add(row)
                    Application.DoEvents()
                End If
            Next i
            If Dataret.Chk_Get_Pay.Rows.Count > 0 Then Dataret.Chk_Get_Pay.Rows(0).Item("BankName") = Str1
            Dim ret As New CRP_SodorChk
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SodorChk")
            Me.Close()
        End Try
    End Sub

    Private Sub DaftarKol()
        Try
            Dim Dataret As New DataSetDaftarKol
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            Dim BedMon As Long = 0
            Dim BesMon As Long = 0
            Dim ret As New CRP_Report_Daftar_Kol
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("Kind") = Str1
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    BedMon += Dataret.DataTable1.Rows(i).Item("BedMon")
                    BesMon += Dataret.DataTable1.Rows(i).Item("BesMon")
                Next
                If BedMon - BesMon >= 0 Then
                    Dataret.DataTable1.Rows(0).Item("EndMandeh") = BedMon - BesMon
                    Dataret.DataTable1.Rows(0).Item("EndT") = "بد"
                ElseIf BedMon - BesMon < 0 Then
                    Dataret.DataTable1.Rows(0).Item("EndMandeh") = (BedMon - BesMon) * (-1)
                    Dataret.DataTable1.Rows(0).Item("EndT") = "بس"
                End If
                Dataret.DataTable1.Rows(0).Item("D_date") = GetDate()
            Else
                MessageBox.Show("طرف حسابی با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            '''''''''''''''''''''''''''''

            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DaftarKol")
            Me.Close()
        End Try
    End Sub

    Private Sub DelaySell()
        Try
            Dim dv As New DataView
            Dim Dataret As New DataSetDaftarKol
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()


            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("BesMon") = If(Dataret.DataTable1.Rows(i).Item("D_Date") Is DBNull.Value, 0, SUBDAY(GetDate, Dataret.DataTable1.Rows(i).Item("D_Date")))
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                dv = Dataret.DataTable1.DefaultView
                If Num1 <> -1 Or Num2 <> -1 Then
                    If Num1 <> -1 And Num2 <> -1 Then
                        dv.RowFilter = "BesMon>=" & CLng(Num1) & " AND BesMon<=" & CLng(Num2)
                    ElseIf Num1 <> -1 And Num2 = -1 Then
                        dv.RowFilter = "BesMon>=" & CLng(Num1)
                    ElseIf Num1 = -1 And Num2 <> -1 Then
                        dv.RowFilter = "BesMon<=" & CLng(Num2)
                    Else
                        dv.RowFilter = ""
                    End If
                End If
                If dv.Count > 0 Then
                    Dim Bed As Double = 0
                    Dim Bes As Double = 0
                    For i As Integer = 0 To dv.Count - 1
                        If dv.Item(i).Item("T") = "بد" Then
                            Bed += CDbl(dv.Item(i).Item("Mandeh"))
                        ElseIf dv.Item(i).Item("T") = "بس" Then
                            Bes += CDbl(dv.Item(i).Item("Mandeh"))
                        End If
                    Next
                    dv.Item(dv.Count - 1).Item("EndMandeh") = If((Bed - Bes) > 0, (Bed - Bes), (Bed - Bes) * (-1))
                    dv.Item(dv.Count - 1).Item("EndT") = If((Bed - Bes) > 0, "بد", "بس")

                    If UCase(CHoose) = "ENDSELL" Then
                        Dim ret As New CRP_EndSell
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(dv)
                        Me.CRV.ReportSource = ret
                    Else
                        Dim ret As New CRP_NoEndSell
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(dv)
                        Me.CRV.ReportSource = ret
                    End If

                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                Else
                    MessageBox.Show("گزارشی با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                MessageBox.Show("گزارشی با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            '''''''''''''''''''''''''''''
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DelaySell")
            Me.Close()
        End Try
    End Sub

    Private Sub DarsadRisk()
        Try
            Dim dv As New DataView
            Dim Dataret As New DataSetDaftarKol
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Columns("Darsad").ReadOnly = False
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("Darsad") = Math.Round(If(Dataret.DataTable1.Rows(i).Item("BedMon") <> 0, ((Dataret.DataTable1.Rows(i).Item("BedMon") - Dataret.DataTable1.Rows(i).Item("BesMon") + Dataret.DataTable1.Rows(i).Item("GetChk") - Dataret.DataTable1.Rows(i).Item("PayChk")) * 100) / Dataret.DataTable1.Rows(i).Item("BedMon"), 0), 2) * (-1)
                    Dataret.DataTable1.Rows(i).Item("D_date") = Replace(Dataret.DataTable1.Rows(i).Item("Darsad"), ".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                dv = Dataret.DataTable1.DefaultView

                If Num1 <> -1 Or Num2 <> -1 Then
                    If Num1 <> -1 And Num2 <> -1 Then
                        dv.RowFilter = "Darsad>=" & CDbl(Num1) & " AND Darsad<=" & CDbl(Num2)
                    ElseIf Num1 <> -1 And Num2 = -1 Then
                        dv.RowFilter = "Darsad>=" & CDbl(Num1)
                    ElseIf Num1 = -1 And Num2 <> -1 Then
                        dv.RowFilter = "Darsad<=" & CDbl(Num2)
                    Else
                        dv.RowFilter = ""
                    End If
                End If

                If dv.Count > 0 Then
                    Dim Bed As Double = 0
                    Dim Bes As Double = 0
                    For i As Integer = 0 To dv.Count - 1
                        If dv.Item(i).Item("T") = "بد" Then
                            Bed += CDbl(dv.Item(i).Item("Mandeh"))
                        ElseIf dv.Item(i).Item("T") = "بس" Then
                            Bes += CDbl(dv.Item(i).Item("Mandeh"))
                        End If
                    Next
                    dv.Item(0).Item("PrintDat") = GetDate()
                    dv.Item(dv.Count - 1).Item("EndMandeh") = If((Bed - Bes) > 0, (Bed - Bes), (Bed - Bes) * (-1))
                    dv.Item(dv.Count - 1).Item("EndT") = If((Bed - Bes) > 0, "بد", "بس")
                    dv.Sort = "Darsad"
                    Dim ret As New CRP_DarsakRisk
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(dv)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                Else
                    MessageBox.Show("گزارشی با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                MessageBox.Show("گزارشی با مشخصات مورد نظر وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            '''''''''''''''''''''''''''''
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DarsadRisk")
            Me.Close()
        End Try
    End Sub

    Private Sub MoeinPeople()
        Try
            If Not DtMoeinPeople.Columns.Contains("PrintDat") Then DtMoeinPeople.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtMoeinPeople.Columns.Contains("nam") Then DtMoeinPeople.Columns.Add("nam", Type.GetType("System.String"))
            If Not DtMoeinPeople.Columns.Contains("Dat1") Then DtMoeinPeople.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtMoeinPeople.Columns.Contains("Dat2") Then DtMoeinPeople.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtMoeinPeople.Columns.Contains("EndT") Then DtMoeinPeople.Columns.Add("EndT", Type.GetType("System.String"))
            If Not DtMoeinPeople.Columns.Contains("Endmandeh") Then DtMoeinPeople.Columns.Add("Endmandeh", Type.GetType("System.Double"))
            If Not DtMoeinPeople.Columns.Contains("Companyname") Then DtMoeinPeople.Columns.Add("Companyname", Type.GetType("System.String"))
            If Not DtMoeinPeople.Columns.Contains("StrSum") Then DtMoeinPeople.Columns.Add("StrSum", Type.GetType("System.String"))

            '''''''''''''''''''''''''''''''''''''

            DtMoeinPeople.Rows(0).Item("PrintDat") = GetDate()
            DtMoeinPeople.Rows(0).Item("nam") = Tmp_Namkala
            DtMoeinPeople.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtMoeinPeople.Rows(0).Item("Dat2") = Tmp_TwoGroup
            DtMoeinPeople.Rows(0).Item("Companyname") = GetNamCompany()
            DtMoeinPeople.Rows(0).Item("StrSum") = Str2
            DtMoeinPeople.Rows(DtMoeinPeople.Rows.Count - 1).Item("EndT") = Tmp_String1
            DtMoeinPeople.Rows(DtMoeinPeople.Rows.Count - 1).Item("Endmandeh") = Tmp_Mon
            Dim ret As New CRP_Report_Moin_TarrafHesab
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtMoeinPeople)
            ret.SetParameterValue("Adres", Lend)
            ret.SetParameterValue("Tell", IdFactor)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MoeinPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub DaftarDay()
        Try
            If Not DtDaftarDay.Columns.Contains("PrintDat") Then DtDaftarDay.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtDaftarDay.Columns.Contains("Dat1") Then DtDaftarDay.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtDaftarDay.Columns.Contains("Dat2") Then DtDaftarDay.Columns.Add("Dat2", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            DtDaftarDay.Rows(0).Item("PrintDat") = GetDate()
            DtDaftarDay.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtDaftarDay.Rows(0).Item("Dat2") = Tmp_TwoGroup
            
            Dim ret As New CRP_Report_DaftarDay
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtDaftarDay)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DaftarDay")
            Me.Close()
        End Try
    End Sub

    Private Sub MoeinKalaPeople()
        Try
            If Not DtMoeinKalaPeople.Columns.Contains("PrintDat") Then DtMoeinKalaPeople.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtMoeinKalaPeople.Columns.Contains("nam") Then DtMoeinKalaPeople.Columns.Add("nam", Type.GetType("System.String"))
            If Not DtMoeinKalaPeople.Columns.Contains("Dat1") Then DtMoeinKalaPeople.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtMoeinKalaPeople.Columns.Contains("Dat2") Then DtMoeinKalaPeople.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtMoeinKalaPeople.Columns.Contains("EndT") Then DtMoeinKalaPeople.Columns.Add("EndT", Type.GetType("System.String"))
            If Not DtMoeinKalaPeople.Columns.Contains("Endmandeh") Then DtMoeinKalaPeople.Columns.Add("Endmandeh", Type.GetType("System.Double"))
            If Not DtMoeinKalaPeople.Columns.Contains("Companyname") Then DtMoeinKalaPeople.Columns.Add("Companyname", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            DtMoeinKalaPeople.Rows(0).Item("PrintDat") = GetDate()
            DtMoeinKalaPeople.Rows(0).Item("nam") = Tmp_Namkala
            DtMoeinKalaPeople.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtMoeinKalaPeople.Rows(0).Item("Dat2") = Tmp_TwoGroup
            DtMoeinKalaPeople.Rows(0).Item("Companyname") = GetNamCompany()
            DtMoeinKalaPeople.Rows(DtMoeinKalaPeople.Rows.Count - 1).Item("EndT") = Tmp_String1
            DtMoeinKalaPeople.Rows(DtMoeinKalaPeople.Rows.Count - 1).Item("Endmandeh") = Tmp_Mon
            Dim ret As New CRP_Report_Maly_Kalaee
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtMoeinKalaPeople)
            ret.SetParameterValue("Adres", Lend)
            ret.SetParameterValue("Tell", IdFactor)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MoeinKalaPeople")
            Me.Close()
        End Try
    End Sub
    Private Sub MoeinBox()
        Try
            If Not DtMoeinBox.Columns.Contains("PrintDat") Then DtMoeinBox.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtMoeinBox.Columns.Contains("nam") Then DtMoeinBox.Columns.Add("nam", Type.GetType("System.String"))
            If Not DtMoeinBox.Columns.Contains("Dat1") Then DtMoeinBox.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtMoeinBox.Columns.Contains("Dat2") Then DtMoeinBox.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtMoeinBox.Columns.Contains("EndT") Then DtMoeinBox.Columns.Add("EndT", Type.GetType("System.String"))
            If Not DtMoeinBox.Columns.Contains("Endmandeh") Then DtMoeinBox.Columns.Add("Endmandeh", Type.GetType("System.Double"))
            '''''''''''''''''''''''''''''''''''''
            DtMoeinBox.Rows(0).Item("PrintDat") = GetDate()
            DtMoeinBox.Rows(0).Item("nam") = Tmp_Namkala
            DtMoeinBox.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtMoeinBox.Rows(0).Item("Dat2") = Tmp_TwoGroup
            DtMoeinBox.Rows(DtMoeinBox.Rows.Count - 1).Item("EndT") = Tmp_String1
            DtMoeinBox.Rows(DtMoeinBox.Rows.Count - 1).Item("Endmandeh") = Tmp_Mon
            Dim ret As New CRP_Report_Moin_Box
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtMoeinBox)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MoeinBox")
            Me.Close()
        End Try
    End Sub
    Private Sub MoeinBank()
        Try
            If Not DtMoeinBank.Columns.Contains("PrintDat") Then DtMoeinBank.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtMoeinBank.Columns.Contains("nam") Then DtMoeinBank.Columns.Add("nam", Type.GetType("System.String"))
            If Not DtMoeinBank.Columns.Contains("Dat1") Then DtMoeinBank.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtMoeinBank.Columns.Contains("Dat2") Then DtMoeinBank.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtMoeinBank.Columns.Contains("EndT") Then DtMoeinBank.Columns.Add("EndT", Type.GetType("System.String"))
            If Not DtMoeinBank.Columns.Contains("N_Account") Then DtMoeinBank.Columns.Add("N_Account", Type.GetType("System.String"))
            If Not DtMoeinBank.Columns.Contains("Endmandeh") Then DtMoeinBank.Columns.Add("Endmandeh", Type.GetType("System.Double"))
            '''''''''''''''''''''''''''''''''''''
            DtMoeinBank.Rows(0).Item("PrintDat") = GetDate()
            DtMoeinBank.Rows(0).Item("nam") = Tmp_Namkala
            DtMoeinBank.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtMoeinBank.Rows(0).Item("Dat2") = Tmp_TwoGroup
            DtMoeinBank.Rows(0).Item("N_Account") = TmpAddress
            DtMoeinBank.Rows(DtMoeinBank.Rows.Count - 1).Item("EndT") = Tmp_String1
            DtMoeinBank.Rows(DtMoeinBank.Rows.Count - 1).Item("Endmandeh") = Tmp_Mon
            Dim ret As New CRP_Report_Moin_Bank
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtMoeinBank)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MoeinBank")
            Me.Close()
        End Try
    End Sub
    Private Sub KardexKala()
        Try
            If Not DtMoeinKardex.Columns.Contains("PrintDat") Then DtMoeinKardex.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("nam") Then DtMoeinKardex.Columns.Add("nam", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("Dat1") Then DtMoeinKardex.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("Dat2") Then DtMoeinKardex.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndKol") Then DtMoeinKardex.Columns.Add("EndKol", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndJoz") Then DtMoeinKardex.Columns.Add("EndJoz", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("InKolStr") Then DtMoeinKardex.Columns.Add("InKolStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("InJozStr") Then DtMoeinKardex.Columns.Add("InJozStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("OutKolStr") Then DtMoeinKardex.Columns.Add("OutKolStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("OutJozStr") Then DtMoeinKardex.Columns.Add("OutJozStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("KolStr") Then DtMoeinKardex.Columns.Add("KolStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("JozStr") Then DtMoeinKardex.Columns.Add("JozStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndInKol") Then DtMoeinKardex.Columns.Add("EndInKol", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndInJoz") Then DtMoeinKardex.Columns.Add("EndInJoz", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndOutKol") Then DtMoeinKardex.Columns.Add("EndOutKol", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndOutJoz") Then DtMoeinKardex.Columns.Add("EndOutJoz", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("SumDarsad") Then DtMoeinKardex.Columns.Add("SumDarsad", Type.GetType("System.Double"))
            If Not DtMoeinKardex.Columns.Contains("InDiscountMon") Then DtMoeinKardex.Columns.Add("InDiscountMon", Type.GetType("System.Double"))
            If Not DtMoeinKardex.Columns.Contains("InKolDiscount") Then DtMoeinKardex.Columns.Add("InKolDiscount", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("InJozDiscount") Then DtMoeinKardex.Columns.Add("InJozDiscount", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("OutDiscountMon") Then DtMoeinKardex.Columns.Add("OutDiscountMon", Type.GetType("System.Double"))
            If Not DtMoeinKardex.Columns.Contains("OutKolDiscount") Then DtMoeinKardex.Columns.Add("OutKolDiscount", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("OutJozDiscount") Then DtMoeinKardex.Columns.Add("OutJozDiscount", Type.GetType("System.String"))

            '''''''''''''''''''''''''''''''''''''
            DtMoeinKardex.Rows(0).Item("PrintDat") = GetDate()
            DtMoeinKardex.Rows(0).Item("nam") = Tmp_Namkala
            DtMoeinKardex.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtMoeinKardex.Rows(0).Item("Dat2") = Tmp_TwoGroup
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndInKol") = Tmp_String1
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndInJoz") = TmpAddress
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndOutKol") = TmpVahed
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndOutJoz") = Tmp_String2
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndKol") = TmpTell1
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndJoz") = TmpTell2
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("SumDarsad") = Tmp_Mon
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("InDiscountMon") = tc1
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("InKolDiscount") = tc2
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("InJozDiscount") = tc3
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("OutDiscountMon") = namAnbar
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("OutKolDiscount") = namAnbar2
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("OutJozDiscount") = DiscFactor

            For i As Integer = 0 To DtMoeinKardex.Rows.Count - 1
                DtMoeinKardex.Rows(i).Item("InKolStr") = DtMoeinKardex.Rows(i).Item("InKol").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("InJozStr") = DtMoeinKardex.Rows(i).Item("InJoz").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("OutKolStr") = DtMoeinKardex.Rows(i).Item("OutKol").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("OutJozStr") = DtMoeinKardex.Rows(i).Item("OutJoz").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("KolStr") = DtMoeinKardex.Rows(i).Item("KolMandeh").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("JozStr") = DtMoeinKardex.Rows(i).Item("JozMandeh").ToString.Replace(".", "/")
            Next
            Dim ret As New CRP_Report_Kardex_Kala
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtMoeinKardex)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "KardexKala")
            Me.Close()
        End Try
    End Sub

    Private Sub KardexAnbar()
        Try
            If Not DtMoeinKardex.Columns.Contains("PrintDat") Then DtMoeinKardex.Columns.Add("PrintDat", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("nam") Then DtMoeinKardex.Columns.Add("nam", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("Dat1") Then DtMoeinKardex.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("Dat2") Then DtMoeinKardex.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndKol") Then DtMoeinKardex.Columns.Add("EndKol", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndJoz") Then DtMoeinKardex.Columns.Add("EndJoz", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("InKolStr") Then DtMoeinKardex.Columns.Add("InKolStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("InJozStr") Then DtMoeinKardex.Columns.Add("InJozStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("OutKolStr") Then DtMoeinKardex.Columns.Add("OutKolStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("OutJozStr") Then DtMoeinKardex.Columns.Add("OutJozStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("KolStr") Then DtMoeinKardex.Columns.Add("KolStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("JozStr") Then DtMoeinKardex.Columns.Add("JozStr", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndInKol") Then DtMoeinKardex.Columns.Add("EndInKol", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndInJoz") Then DtMoeinKardex.Columns.Add("EndInJoz", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndOutKol") Then DtMoeinKardex.Columns.Add("EndOutKol", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("EndOutJoz") Then DtMoeinKardex.Columns.Add("EndOutJoz", Type.GetType("System.String"))
            If Not DtMoeinKardex.Columns.Contains("NamAnbar") Then DtMoeinKardex.Columns.Add("NamAnbar", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            DtMoeinKardex.Rows(0).Item("PrintDat") = GetDate()
            DtMoeinKardex.Rows(0).Item("nam") = Tmp_Namkala
            DtMoeinKardex.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtMoeinKardex.Rows(0).Item("Dat2") = Tmp_TwoGroup
            DtMoeinKardex.Rows(0).Item("NamAnbar") = namAnbar2
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndInKol") = Tmp_String1
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndInJoz") = TmpAddress
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndOutKol") = TmpVahed
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndOutJoz") = Tmp_String2
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndKol") = TmpTell1
            DtMoeinKardex.Rows(DtMoeinKardex.Rows.Count - 1).Item("EndJoz") = TmpTell2
            For i As Integer = 0 To DtMoeinKardex.Rows.Count - 1
                DtMoeinKardex.Rows(i).Item("InKolStr") = DtMoeinKardex.Rows(i).Item("InKol").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("InJozStr") = DtMoeinKardex.Rows(i).Item("InJoz").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("OutKolStr") = DtMoeinKardex.Rows(i).Item("OutKol").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("OutJozStr") = DtMoeinKardex.Rows(i).Item("OutJoz").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("KolStr") = DtMoeinKardex.Rows(i).Item("KolMandeh").ToString.Replace(".", "/")
                DtMoeinKardex.Rows(i).Item("JozStr") = DtMoeinKardex.Rows(i).Item("JozMandeh").ToString.Replace(".", "/")
            Next
            Dim ret As New CRP_Report_Kardex_Anbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(DtMoeinKardex)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "KardexAnbar")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyKala()
        Try
            Dim Dataret As New DataSetMojodyKala
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolStr") = Dataret.DataTable1.Rows(i).Item("Kol").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozStr") = Dataret.DataTable1.Rows(i).Item("Joz").ToString.Replace(".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
            End If
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Mojodi_Kala
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyKala")
            Me.Close()
        End Try
    End Sub

    Private Sub Low_Hight_Mojody()
        Try
            Dim Dataret As New DataSetLow_Hight
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.DataTable1)
            'Application.DoEvents()
            'End Using
            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolStr") = Dataret.DataTable1.Rows(i).Item("Kol").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozStr") = Dataret.DataTable1.Rows(i).Item("Joz").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("Low_HightStr") = Dataret.DataTable1.Rows(i).Item("Low_Hight").ToString.Replace(".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("TypeSanad") = If(CHoose = "LOWMOJODY", "گزارش حداقل نقطه سفارش", "گزارش حداکثر نقطه سفارش")
            End If
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Mojodi_LOW_Hight_Kala
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Low_Hight_Mojody")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyKalaAnbar()
        Try
            Dim Dataret As New DataSetMojodyAnbar
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolStr") = Dataret.DataTable1.Rows(i).Item("Kol").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozStr") = Dataret.DataTable1.Rows(i).Item("Joz").ToString.Replace(".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
            End If
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Mojodi_KalaAnbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyKalaAnbar")
            Me.Close()
        End Try
    End Sub

    Private Sub ChkPrint()
        Try
            Dim Dataret As New DataSetChk
           
            For i As Integer = 0 To ListChkPrintArray.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListChkPrintArray(i).Id, ListChkPrintArray(i).nam, ListChkPrintArray(i).GetDate, ListChkPrintArray(i).PayDate, ListChkPrintArray(i).Bank, ListChkPrintArray(i).Shobeh, ListChkPrintArray(i).numchk, ListChkPrintArray(i).Mon, ListChkPrintArray(i).StateChk, GetDate(), ListChkPrintArray(0).Type, ListChkPrintArray(i).NumBank, SUBDAY(ListChkPrintArray(i).PayDate, ListChkPrintArray(i).GetDate), ListChkPrintArray(i).Ras, ListChkPrintArray(i).Tell)
            Next
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Chk
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ChkPrint")
            Me.Close()
        End Try
    End Sub

    Private Sub ChkOnePrint()
        Try
            Dim Dataret As New DataSetChk

            For i As Integer = 0 To ListChkPrintArray.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListChkPrintArray(i).Id, ListChkPrintArray(i).nam, ListChkPrintArray(i).GetDate, ListChkPrintArray(i).PayDate, ListChkPrintArray(i).Bank, ListChkPrintArray(i).Shobeh, ListChkPrintArray(i).numchk, ListChkPrintArray(i).Mon, ListChkPrintArray(i).StateChk, GetDate(), ListChkPrintArray(0).Type, ListChkPrintArray(i).NumBank, SUBDAY(ListChkPrintArray(i).PayDate, ListChkPrintArray(i).GetDate), ListChkPrintArray(i).Ras, ListChkPrintArray(i).Tell)
            Next
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_OneChk
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ChkOnePrint")
            Me.Close()
        End Try
    End Sub

    Private Sub DelayPrint()
        Try
            Dim Dataret As New DataSetDelay

            For i As Integer = 0 To ListDelayPrintArray.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListDelayPrintArray(i).IdFactor, ListDelayPrintArray(i).nam, ListDelayPrintArray(i).Tell1, ListDelayPrintArray(i).Tell2, ListDelayPrintArray(i).D_Date, ListDelayPrintArray(i).EndDate, ListDelayPrintArray(i).TimeRemain, ListDelayPrintArray(i).Remain, ListDelayPrintArray(i).Disc, ListDelayPrintArray(i).Rate, ListDelayPrintArray(i).Kind, ListDelayPrintArray(i).Nam2, GetDate(), Math.Abs(Tmp_Mon), ListDelayPrintArray(i).T, ListDelayPrintArray(i).Mandeh, ListDelayPrintArray(i).Tmp2, 0, If(Tmp_Mon < 0, "بس", "بد"), ListDelayPrintArray(i).KindFrosh)
            Next
            '''''''''''''''''''''''''''''
            If UCase(CHoose) = "DELAYPRINT" Then
                Dim ret As New CRP_Report_Delay
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
            Else
                Dim ret As New CRP_Report_Delay2
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
            End If
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DelayPrint")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyMoneyKala()
        Try
            Dim Dataret As New DataSetMojodyMoney
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolStr") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozStr") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintStr") = GetDate()
            End If
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Mojodi_Money_Kala
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyMoneyKala")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyMoneyAnbar()
        Try
            Dim Dataret As New DataSetMojodyMoney
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolStr") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozStr") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintStr") = GetDate()
            End If
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Mojodi_Money_Anbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyMoneyAnbar")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyOneAnbar()
        Try
            Dim Dataret As New DataSetMojodyMoney
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolStr") = Dataret.DataTable1.Rows(i).Item("KolStr").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozStr") = Dataret.DataTable1.Rows(i).Item("JozStr").ToString.Replace(".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintStr") = GetDate()
            End If
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Mojodi_One_Anbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyOneAnbar")
            Me.Close()
        End Try
    End Sub

    Private Sub NSODALL()
        Try
            Dim Dataret As New DataSetNSod
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.DataTable1)
            'Application.DoEvents()
            'End Using

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارش سود و زیان ناخالص با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dim alldarsad As Double = 0
                Dim Fdarsad As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    alldarsad += CDbl(Dataret.DataTable1.Rows(i).Item("Darsad"))
                    Fdarsad += CDbl(Dataret.DataTable1.Rows(i).Item("DFrosh").ToString.Replace("/", "."))
                    Dataret.DataTable1.Rows(i).Item("Darsad") = Replace(Dataret.DataTable1.Rows(i).Item("Darsad"), ".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("EndDarsad") = (Format((alldarsad / Dataret.DataTable1.Rows.Count), "###.##")).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("AFrosh") = (Format((Fdarsad / Dataret.DataTable1.Rows.Count), "###.##")).ToString.Replace(".", "/")
                Dim ret As New CRP_Report_Sod_And_Zyan_Nakhales
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "NSODALL")
            Me.Close()
        End Try
    End Sub

    Private Sub NSODALL2()
        Try
            Dim Dataret As New DataSetNSod
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.DataTable1)
            'Application.DoEvents()
            'End Using
            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارش سود و زیان ناخالص با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dim alldarsad As Double = 0
                Dim Fdarsad As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    alldarsad += CDbl(Dataret.DataTable1.Rows(i).Item("Darsad"))
                    Fdarsad += CDbl(Dataret.DataTable1.Rows(i).Item("DFrosh").ToString.Replace("/", "."))
                    Dataret.DataTable1.Rows(i).Item("Darsad") = Replace(Dataret.DataTable1.Rows(i).Item("Darsad"), ".", "/")
                Next
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("EndDarsad") = (Format((alldarsad / Dataret.DataTable1.Rows.Count), "###.##")).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("AFrosh") = (Format((Fdarsad / Dataret.DataTable1.Rows.Count), "###.##")).ToString.Replace(".", "/")
                Dim ret As New CRP_Report_Sod_And_Zyan_Nakhales2
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "NSODALL2")
            Me.Close()
        End Try
    End Sub

    Private Sub Getpay()
        Try
            Dim Dataret As New DataSetGetPay
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            If Not Dataret.DataTable1.Columns.Contains("TypeSanad") Then Dataret.DataTable1.Columns.Add("TypeSanad", Type.GetType("System.String"))
            If Not Dataret.DataTable1.Columns.Contains("DiscMon") Then Dataret.DataTable1.Columns.Add("DiscMon", Type.GetType("System.String"))
            If Not Dataret.DataTable1.Columns.Contains("OldMoein") Then Dataret.DataTable1.Columns.Add("OldMoein", Type.GetType("System.Double"))
            If Not Dataret.DataTable1.Columns.Contains("NewMoein") Then Dataret.DataTable1.Columns.Add("NewMoein", Type.GetType("System.Double"))
            '''''''''''''''''''''''''''''''''''''
            Dataret.DataTable1.Rows(0).Item("TypeSanad") = If(Dataret.DataTable1.Rows(0).Item("State") = 0, "رسید دریافت از طرف حساب", "رسید پرداخت به طرف حساب")
            Dim s As New NumberToString
            Dataret.DataTable1.Rows(0).Item("DiscMon") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("AllMon"))
            Dataret.DataTable1.Rows(0).Item("Disc") = "توضیحات : " & If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc"))
            '//////////////////////////////////////////
            OldSanad = 0
            CurSanad = 0
            IdKala = 0
            SetMoeinPeopleVaribleGetpay(Dataret.DataTable1.Rows(0).Item("IdSanad"))
            Dataret.DataTable1.Rows(0).Item("OldMoein") = GetMoeinPeople(IdKala, OldSanad)
            Dataret.DataTable1.Rows(0).Item("NewMoein") = GetMoeinPeople(IdKala, CurSanad + 1)
            If Dataret.DataTable1.Rows(0).Item("Chk") <= 0 Then
                Dim ret As New CRP_Resid_Pardakht_TarrafHesab
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                If Dataret.DataTable1.Rows(0).Item("State") = 0 Then
                    Dim dt As New DataTable
                    If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                    Using cmd As New SqlCommand("SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N As ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.[Number_Type]=" & Dataret.DataTable1.Rows(0).Item("IdSanad") & " AND Chk_Get_Pay.Kind=0", ConectionBank)
                        cmd.CommandTimeout = 0
                        dt.Load(cmd.ExecuteReader)
                    End Using
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Dataret.DataTable1.Rows(0).Item("ChkDate") = dt.Rows(0).Item("ChkDate")
                    Dataret.DataTable1.Rows(0).Item("ChkS") = dt.Rows(0).Item("ChkS")
                    Dataret.DataTable1.Rows(0).Item("ChkMon") = dt.Rows(0).Item("ChkMon")
                    Dataret.DataTable1.Rows(0).Item("ChkBank") = dt.Rows(0).Item("ChkBank")
                    Dataret.DataTable1.Rows(0).Item("ChkNum") = dt.Rows(0).Item("ChkNum")
                    Dataret.DataTable1.Rows(0).Item("shobeh") = dt.Rows(0).Item("shobeh")
                    For i As Integer = 1 To dt.Rows.Count - 1
                        Dataret.DataTable1.AddDataTable1Row(If(Dataret.DataTable1.Rows(0).Item("CompanyOnfo") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyOnfo")), If(Dataret.DataTable1.Rows(0).Item("CompanyNam") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyNam")), If(Dataret.DataTable1.Rows(0).Item("HeaderText") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("HeaderText")), Dataret.DataTable1.Rows(0).Item("D_date"), Dataret.DataTable1.Rows(0).Item("IdSanad"), Dataret.DataTable1.Rows(0).Item("TypeSanad"), Dataret.DataTable1.Rows(0).Item("Nam"), If(Dataret.DataTable1.Rows(0).Item("Tell") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Tell")), If(Dataret.DataTable1.Rows(0).Item("Addres") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Addres")), Dataret.DataTable1.Rows(0).Item("AllMon"), Dataret.DataTable1.Rows(0).Item("DiscMon"), Dataret.DataTable1.Rows(0).Item("Cash"), Dataret.DataTable1.Rows(0).Item("Chk"), Dataret.DataTable1.Rows(0).Item("Havaleh"), Dataret.DataTable1.Rows(0).Item("Discount"), Dataret.DataTable1.Rows(0).Item("OldMoein"), Dataret.DataTable1.Rows(0).Item("NewMoein"), If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc")), Dataret.DataTable1.Rows(0).Item("ImageFactor"), dt.Rows(i).Item("ChkDate"), dt.Rows(i).Item("Chks"), dt.Rows(i).Item("ChkMon"), dt.Rows(i).Item("ChkBank"), dt.Rows(i).Item("ChkNum"), Dataret.DataTable1.Rows(0).Item("State"), dt.Rows(i).Item("shobeh"))
                    Next
                Else
                    Dim dt As New DataTable
                    If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                    Using cmd As New SqlCommand("SELECT DISTINCT * FROM(SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,Define_Bank.N_Bank As ChkBank,Define_Bank.Number_N AS ChkNum,Define_Bank.Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Bank ON Define_Bank.ID =Chk_Id .IdBank  WHERE Chk_Get_Pay.[Type]=12 AND Chk_Get_Pay.[Number_Type]=" & Dataret.DataTable1.Rows(0).Item("IdSanad") & " AND Chk_Get_Pay.Kind=1 UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .Idsarmayeh  ELSE (SELECT Idsarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=Number_Type ) END )  = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ")) UNION ALL SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N AS ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Amval   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .IdAmval ELSE (SELECT IdAmval FROM Get_Pay_Amval WHERE Id=Number_Type) END ) = Define_Amval .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION All SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Sarmayeh   ON (CASE WHEN (Kind =0 AND Current_Kind =0) OR (Kind =1 AND Current_Kind =1) THEN Chk_Id .Idsarmayeh  ELSE (SELECT Idsarmayeh  FROM Get_Pay_Sarmayeh  WHERE Id=Number_Type ) END ) = Define_Sarmayeh .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") AND Chk_Get_Pay .ID NOT IN (SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_People ON Chk_Id.IdPeople = Define_People.ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ") UNION ALL SELECT Chk_Get_Pay.ID FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id INNER JOIN Define_Daramad  ON Chk_Id.IdDaramad  = Define_Daramad .ID WHERE  (Chk_Get_Pay.Kind =0 AND Chk_Get_Pay.Current_Kind =1)  AND (Chk_Get_Pay.Current_Type =12) AND (Chk_Get_Pay.Current_Number_Type =" & Dataret.DataTable1.Rows(0).Item("IdSanad") & ")))) As AllChk", ConectionBank)
                        cmd.CommandTimeout = 0
                        dt.Load(cmd.ExecuteReader)
                    End Using
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Dataret.DataTable1.Rows(0).Item("ChkDate") = dt.Rows(0).Item("ChkDate")
                    Dataret.DataTable1.Rows(0).Item("ChkS") = dt.Rows(0).Item("ChkS")
                    Dataret.DataTable1.Rows(0).Item("ChkMon") = dt.Rows(0).Item("ChkMon")
                    Dataret.DataTable1.Rows(0).Item("ChkBank") = dt.Rows(0).Item("ChkBank")
                    Dataret.DataTable1.Rows(0).Item("ChkNum") = dt.Rows(0).Item("ChkNum")
                    Dataret.DataTable1.Rows(0).Item("shobeh") = dt.Rows(0).Item("shobeh")
                    For i As Integer = 1 To dt.Rows.Count - 1
                        Dataret.DataTable1.AddDataTable1Row(If(Dataret.DataTable1.Rows(0).Item("CompanyOnfo") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyOnfo")), If(Dataret.DataTable1.Rows(0).Item("CompanyNam") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyNam")), If(Dataret.DataTable1.Rows(0).Item("HeaderText") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("HeaderText")), Dataret.DataTable1.Rows(0).Item("D_date"), Dataret.DataTable1.Rows(0).Item("IdSanad"), Dataret.DataTable1.Rows(0).Item("TypeSanad"), Dataret.DataTable1.Rows(0).Item("Nam"), If(Dataret.DataTable1.Rows(0).Item("Tell") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Tell")), If(Dataret.DataTable1.Rows(0).Item("Addres") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Addres")), Dataret.DataTable1.Rows(0).Item("AllMon"), Dataret.DataTable1.Rows(0).Item("DiscMon"), Dataret.DataTable1.Rows(0).Item("Cash"), Dataret.DataTable1.Rows(0).Item("Chk"), Dataret.DataTable1.Rows(0).Item("Havaleh"), Dataret.DataTable1.Rows(0).Item("Discount"), Dataret.DataTable1.Rows(0).Item("OldMoein"), Dataret.DataTable1.Rows(0).Item("NewMoein"), If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc")), Dataret.DataTable1.Rows(0).Item("ImageFactor"), dt.Rows(i).Item("ChkDate"), dt.Rows(i).Item("Chks"), dt.Rows(i).Item("ChkMon"), dt.Rows(i).Item("ChkBank"), dt.Rows(i).Item("ChkNum"), Dataret.DataTable1.Rows(0).Item("State"), dt.Rows(i).Item("shobeh"))
                    Next
                End If

                Dim ret As New CRP_Resid_Pardakht_TarrafHesab2
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Getpay")
            Me.Close()
        End Try
    End Sub

    Private Sub Daramad()
        Try
            Dim Dataret As New DataSetGetPay
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            If Not Dataret.DataTable1.Columns.Contains("DiscMon") Then Dataret.DataTable1.Columns.Add("DiscMon", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            Dim s As New NumberToString
            Dataret.DataTable1.Rows(0).Item("DiscMon") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("AllMon"))
            Dataret.DataTable1.Rows(0).Item("Disc") = "توضیحات : " & If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc"))
            '//////////////////////////////////////////
            If Dataret.DataTable1.Rows(0).Item("Chk") <= 0 Then
                Dim ret As New CRP_Resid_Daramad
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                Dim dt As New DataTable
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using cmd As New SqlCommand("SELECT PayDate As ChkDate,MoneyChk As ChkMon,NumChk As ChkS,N_Bank As ChkBank,Number_N As ChkNum,Shobeh FROM Chk_Get_Pay INNER JOIN Chk_Id ON Chk_Get_Pay.ID = Chk_Id.Id  WHERE Chk_Get_Pay.[Type]=15 AND Chk_Get_Pay.[Number_Type]=" & Dataret.DataTable1.Rows(0).Item("IdSanad") & " AND Chk_Get_Pay.Kind=0", ConectionBank)
                    cmd.CommandTimeout = 0
                    dt.Load(cmd.ExecuteReader)
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Dataret.DataTable1.Rows(0).Item("ChkDate") = dt.Rows(0).Item("ChkDate")
                Dataret.DataTable1.Rows(0).Item("ChkS") = dt.Rows(0).Item("ChkS")
                Dataret.DataTable1.Rows(0).Item("ChkMon") = dt.Rows(0).Item("ChkMon")
                Dataret.DataTable1.Rows(0).Item("ChkBank") = dt.Rows(0).Item("ChkBank")
                Dataret.DataTable1.Rows(0).Item("ChkNum") = dt.Rows(0).Item("ChkNum")
                Dataret.DataTable1.Rows(0).Item("shobeh") = dt.Rows(0).Item("shobeh")
                For i As Integer = 1 To dt.Rows.Count - 1
                    Dataret.DataTable1.AddDataTable1Row(If(Dataret.DataTable1.Rows(0).Item("CompanyOnfo") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyOnfo")), If(Dataret.DataTable1.Rows(0).Item("CompanyNam") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("CompanyNam")), If(Dataret.DataTable1.Rows(0).Item("HeaderText") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("HeaderText")), Dataret.DataTable1.Rows(0).Item("D_date"), Dataret.DataTable1.Rows(0).Item("IdSanad"), Dataret.DataTable1.Rows(0).Item("TypeSanad"), Dataret.DataTable1.Rows(0).Item("Nam"), If(Dataret.DataTable1.Rows(0).Item("Tell") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Tell")), If(Dataret.DataTable1.Rows(0).Item("Addres") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Addres")), Dataret.DataTable1.Rows(0).Item("AllMon"), Dataret.DataTable1.Rows(0).Item("DiscMon"), Dataret.DataTable1.Rows(0).Item("Cash"), Dataret.DataTable1.Rows(0).Item("Chk"), Dataret.DataTable1.Rows(0).Item("Havaleh"), Dataret.DataTable1.Rows(0).Item("Discount"), Dataret.DataTable1.Rows(0).Item("OldMoein"), Dataret.DataTable1.Rows(0).Item("NewMoein"), If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc")), Dataret.DataTable1.Rows(0).Item("ImageFactor"), dt.Rows(i).Item("ChkDate"), dt.Rows(i).Item("Chks"), dt.Rows(i).Item("ChkMon"), dt.Rows(i).Item("ChkBank"), dt.Rows(i).Item("ChkNum"), Dataret.DataTable1.Rows(0).Item("State"), dt.Rows(i).Item("shobeh"))
                Next
                Dim ret As New CRP_Resid_Daramad2
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Daramad")
            Me.Close()
        End Try
    End Sub

    Private Sub KharidCharge()
        Try
            Dim Dataret As New DataSetGetPay
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            If Not Dataret.DataTable1.Columns.Contains("DiscMon") Then Dataret.DataTable1.Columns.Add("DiscMon", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            Dim s As New NumberToString
            Dataret.DataTable1.Rows(0).Item("DiscMon") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("AllMon"))
            Dataret.DataTable1.Rows(0).Item("Disc") = "توضیحات : " & If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc"))
            '//////////////////////////////////////////
            Dim ret As New CRP_Resid_KharidCharge
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "KharidCharge")
            Me.Close()
        End Try
    End Sub

    Private Sub OtherCharge()
        Try
            Dim Dataret As New DataSetGetPay
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                Exit Sub
            End If
            If Not Dataret.DataTable1.Columns.Contains("DiscMon") Then Dataret.DataTable1.Columns.Add("DiscMon", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            Dim s As New NumberToString
            Dataret.DataTable1.Rows(0).Item("DiscMon") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("AllMon"))
            Dataret.DataTable1.Rows(0).Item("Disc") = "توضیحات : " & If(Dataret.DataTable1.Rows(0).Item("Disc") Is DBNull.Value, "", Dataret.DataTable1.Rows(0).Item("Disc"))
            '//////////////////////////////////////////
            Dim ret As New CRP_Resid_OtherCharge
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "OtherCharge")
            Me.Close()
        End Try
    End Sub

    Private Sub PTP()
        Try
            Dim Dataret As New DataSetPTP
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If Dataret.DataTable1.Rows.Count <= 0 Then
                Me.Close()
            End If
            If Not Dataret.DataTable1.Columns.Contains("DiscMon") Then Dataret.DataTable1.Columns.Add("DiscMon", Type.GetType("System.String"))
            If Not Dataret.DataTable1.Columns.Contains("BedOldMoein") Then Dataret.DataTable1.Columns.Add("BedOldMoein", Type.GetType("System.Double"))
            If Not Dataret.DataTable1.Columns.Contains("BedNewMoein") Then Dataret.DataTable1.Columns.Add("BedNewMoein", Type.GetType("System.Double"))
            If Not Dataret.DataTable1.Columns.Contains("BesOldMoein") Then Dataret.DataTable1.Columns.Add("BesOldMoein", Type.GetType("System.Double"))
            If Not Dataret.DataTable1.Columns.Contains("BesNewMoein") Then Dataret.DataTable1.Columns.Add("BesNewMoein", Type.GetType("System.Double"))
            '''''''''''''''''''''''''''''''''''''
            Dim s As New NumberToString
            Dataret.DataTable1.Rows(0).Item("DiscMon") = s.Num2Str(Dataret.DataTable1.Rows(0).Item("AllMon"))
            '//////////////////////////////////////////
            OldSanad = 0
            CurSanad = 0
            IdKala = 0
            SetMoeinPeopleVariblePTPBed(Dataret.DataTable1.Rows(0).Item("IdSanad"))
            Dataret.DataTable1.Rows(0).Item("BedOldMoein") = GetMoeinPeople(IdKala, OldSanad)
            Dataret.DataTable1.Rows(0).Item("BedNewMoein") = GetMoeinPeople(IdKala, CurSanad + 1)

            OldSanad = 0
            CurSanad = 0
            IdKala = 0
            SetMoeinPeopleVariblePTPBes(Dataret.DataTable1.Rows(0).Item("IdSanad"))
            Dataret.DataTable1.Rows(0).Item("BesOldMoein") = GetMoeinPeople(IdKala, OldSanad)
            Dataret.DataTable1.Rows(0).Item("BesNewMoein") = GetMoeinPeople(IdKala, CurSanad + 1)

            Dim ret As New CRP_Resid_TarafHesab_Be_TarrafHesab
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "PTP")
            Me.Close()
        End Try
    End Sub

    Private Sub Charge()
        Try
            Dim Dataret As New DataSetCharge
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                If Not Dataret.DataTable1.Columns.Contains("Title") Then Dataret.DataTable1.Columns.Add("Title", Type.GetType("System.String"))
                If Not Dataret.DataTable1.Columns.Contains("Dat1") Then Dataret.DataTable1.Columns.Add("Dat1", Type.GetType("System.String"))
                If Not Dataret.DataTable1.Columns.Contains("Dat2") Then Dataret.DataTable1.Columns.Add("Dat2", Type.GetType("System.String"))
                If Not Dataret.DataTable1.Columns.Contains("PrintDat") Then Dataret.DataTable1.Columns.Add("PrintDat", Type.GetType("System.String"))
                If UCase(CHoose) = "CHARGE" Then
                    Dataret.DataTable1.Rows(0).Item("Title") = "گزارش هزینه"
                    Dataret.DataTable1.Rows(0).Item("Part") = "پارت : " & Lend
                ElseIf UCase(CHoose) = "DARAMAD" Then
                    Dataret.DataTable1.Rows(0).Item("Title") = "گزارش درآمد"
                End If
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("dat2") = State
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                '''''''''''''''''''''''''''''''''''''
                SetBedBesTableMoein(Dataret.DataTable1)
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndMon") = Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Mandeh")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndT") = Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("T")
                '''''''''''''''''''''''''''''''''''''''
                Dim ret As New CRP_Report_Hazineh
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Charge")
            Me.Close()
        End Try
    End Sub
    Private Sub SumCharge()
        Try
            Dim Dataret As New DataSetCharge
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                If Not Dataret.DataTable1.Columns.Contains("Title") Then Dataret.DataTable1.Columns.Add("Title", Type.GetType("System.String"))
                If Not Dataret.DataTable1.Columns.Contains("Dat1") Then Dataret.DataTable1.Columns.Add("Dat1", Type.GetType("System.String"))
                If Not Dataret.DataTable1.Columns.Contains("Dat2") Then Dataret.DataTable1.Columns.Add("Dat2", Type.GetType("System.String"))
                If Not Dataret.DataTable1.Columns.Contains("PrintDat") Then Dataret.DataTable1.Columns.Add("PrintDat", Type.GetType("System.String"))

                If UCase(CHoose) = "SUMCHARGE" Then
                    Dataret.DataTable1.Rows(0).Item("Title") = "گزارش جمع هزینه"
                    Dataret.DataTable1.Rows(0).Item("Part") = "پارت : " & Lend
                ElseIf UCase(CHoose) = "SUMDARAMAD" Then
                    Dataret.DataTable1.Rows(0).Item("Title") = "گزارش جمع درآمد"
                End If
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("dat2") = State
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                '''''''''''''''''''''''''''''''''''''
                SetBedBesTableMoein(Dataret.DataTable1)
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndMon") = Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Mandeh")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndT") = Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("T")
                '''''''''''''''''''''''''''''''''''''''
                Dim ret As New CRP_Report_SUMHazineh
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SumCharge")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyBank()
        Try
            Dim Dataret As New DataSetMojodyBank
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.DataTable1)
            'Application.DoEvents()
            'End Using

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndT") = State
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndMandeh") = CDbl(Str1)
                Dim ret As New CRP_Report_hesabe_banky
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyBank")
            Me.Close()
        End Try
    End Sub

    Private Sub MojodyBox()
        Try
            Dim Dataret As New DataSetMojodyBank
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.DataTable1)
            'Application.DoEvents()
            'End Using
            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndT") = State
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndMandeh") = CDbl(Str1)
                Dim ret As New CRP_Report_hesabe_Box
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "MojodyBank")
            Me.Close()
        End Try
    End Sub

    Private Sub StateChk()
        Try
            Dim Dataret As New DataSetStateChk
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            'Using dbDA As New System.Data.SqlClient.SqlDataAdapter(PrintSQl, DataSource)
            'dbDA.Fill(Dataret.DataTable1)
            'Application.DoEvents()
            'End Using

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                If Not Dataret.DataTable1.Columns.Contains("PrintDat") Then Dataret.DataTable1.Columns.Add("PrintDat", Type.GetType("System.String"))
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                ''''''''''''''''''''''''''''''''''''''
                Dim ret As New CRP_State_Chk
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "StateChk")
            Me.Close()
        End Try
    End Sub
    Private Sub BuySell()
        Try
            Dim Dataret As New DataSetReportBuySell
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                If UCase(CHoose) = "REPORTBUY" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش خرید کالا"
                ElseIf UCase(CHoose) = "REPORTABUY" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش خرید امانی کالا"
                ElseIf UCase(CHoose) = "REPORTSELL" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش فروش کالا"
                ElseIf UCase(CHoose) = "REPORTASELL" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش فروش امانی کالا"
                ElseIf UCase(CHoose) = "REPORTBACKBUY" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش برگشت از خرید کالا"
                ElseIf UCase(CHoose) = "REPORTBACKSELL" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش برگشت از فروش کالا"
                End If
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Part") = Lend
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim kol As Double = 0
                Dim joz As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    kol += Dataret.DataTable1.Rows(i).Item("KolCount")
                    Dataret.DataTable1.Rows(i).Item("JozCount") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    joz += Dataret.DataTable1.Rows(i).Item("JozCount")
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndKol") = kol.ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndJoz") = joz.ToString.Replace(".", "/")
                Dim ret As New CRP_Report_Kharid_Kala
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "BuySell")
            Me.Close()
        End Try
    End Sub

    Private Sub ReportService()
        Try
            Dim Dataret As New DataSetReportBuySell
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش خدمات"
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Part") = Lend
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim kol As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    kol += Dataret.DataTable1.Rows(i).Item("KolCount")
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndKol") = kol.ToString.Replace(".", "/")
                Dim ret As New CRP_Report_Service_Kala
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportService")
            Me.Close()
        End Try
    End Sub


    Private Sub ReportDamage()
        Try
            Dim Dataret As New DataSetReportBuySell
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش ضایعات کالا"
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("Part") = Lend
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim kol As Double = 0
                Dim joz As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    kol += Dataret.DataTable1.Rows(i).Item("KolCount")
                    Dataret.DataTable1.Rows(i).Item("JozCount") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    joz += Dataret.DataTable1.Rows(i).Item("JozCount")
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndKol") = kol.ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndJoz") = joz.ToString.Replace(".", "/")
                Dim ret As New CRP_Report_Damge_Kala
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportDamage")
            Me.Close()
        End Try
    End Sub

    Private Sub ReportSUMDamage()
        Try
            Dim Dataret As New DataSetReportBuySell
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع ضایعات کالا"
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("Part") = Lend
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim kol As Double = 0
                Dim joz As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    kol += Dataret.DataTable1.Rows(i).Item("KolCount")
                    Dataret.DataTable1.Rows(i).Item("JozCount") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    joz += Dataret.DataTable1.Rows(i).Item("JozCount")
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndKol") = kol.ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndJoz") = joz.ToString.Replace(".", "/")
                Dim ret As New CRP_Report_SUM_Damge_Kala
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportSUMDamage")
            Me.Close()
        End Try
    End Sub

    Private Sub ReportControlFactor()
        Try
            Dim Dataret As New DataSetControlFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                GetInfoCotrolFactor(Dataret)
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("D_Date") = GetNamCompany()
                Dataret.DataTable1.Rows(0).Item("IdUser") = Id_User
                Dataret.DataTable1.Rows(0).Item("IdExit") = Tmp_String1
                Dataret.DataTable1.Rows(0).Item("City") = Tmp_Namkala
                Dataret.DataTable1.Rows(0).Item("Part") = Tmp_OneGroup
                Dataret.DataTable1.Rows(0).Item("Driver") = TmpAddress & TmpGroupName
                Dataret.DataTable1.Rows(0).Item("Reciver") = TmpTell1
                Dataret.DataTable1.Rows(0).Item("Visitor") = Tmp_TwoGroup
                Dataret.DataTable1.Rows(0).Item("User") = Tmp_String2
                Dataret.DataTable1.Rows(0).Item("CountFac") = Dataret.DataTable1.Rows.Count
                If UCase(CHoose) = "CONTROLFACTOR" Then
                    Dim ret As New CRP_ControMali
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                Else
                    Dim ret As New CRP_ControMali2
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                End If
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportControlFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub ReportSUMService()
        Try
            Dim Dataret As New DataSetReportBuySell
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خدمات"
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("Part") = Lend
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim kol As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    kol += Dataret.DataTable1.Rows(i).Item("KolCount")
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndKol") = kol.ToString.Replace(".", "/")
                Dim ret As New CRP_Report_SUM_Service_Kala
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportSUMService")
            Me.Close()
        End Try
    End Sub

    Private Sub SUMBuySell()
        Try
            Dim Dataret As New DataSetReportBuySell
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                If UCase(CHoose) = "SUMREPORTBUY" Or UCase(CHoose) = "SUMREPORTBUYPGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خرید کالا به ازای هر طرف حساب"
                ElseIf UCase(CHoose) = "SUMREPORTABUY" Or UCase(CHoose) = "SUMREPORTABUYPGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خرید امانی کالا به ازای هر طرف حساب"
                ElseIf UCase(CHoose) = "SUMREPORTSELL" Or UCase(CHoose) = "SUMREPORTSELLPGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع فروش کالا به ازای هر طرف حساب"
                ElseIf UCase(CHoose) = "SUMREPORTASELL" Or UCase(CHoose) = "SUMREPORTASELLPGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع فروش امانی کالا به ازای هر طرف حساب"
                ElseIf UCase(CHoose) = "SUMREPORTBACKBUY" Or UCase(CHoose) = "SUMREPORTBACKBUYPGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع برگشت از خرید کالا به ازای هر طرف حساب"
                ElseIf UCase(CHoose) = "SUMREPORTBACKSELL" Or UCase(CHoose) = "SUMREPORTBACKSELLPGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع برگشت از فروش کالا به ازای هر طرف حساب"
                ElseIf UCase(CHoose) = "SUMREPORTBUYKALA" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خرید کالا به ازای هر کالا"
                ElseIf UCase(CHoose) = "SUMREPORTABUYKALA" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خرید امانی کالا به ازای هر کالا"
                ElseIf UCase(CHoose) = "SUMREPORTSELLKALA" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع فروش کالا به ازای هر کالا"
                ElseIf UCase(CHoose) = "SUMREPORTASELLKALA" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع فروش امانی کالا به ازای هر کالا"
                ElseIf UCase(CHoose) = "SUMREPORTBACKBUYKALA" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع برگشت از خرید کالا به ازای هر کالا"
                ElseIf UCase(CHoose) = "SUMREPORTBACKSELLKALA" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع برگشت از فروش کالا به ازای هر کالا"
                ElseIf UCase(CHoose) = "SUMREPORTBUYGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خرید کالا به ازای هر گروه"
                ElseIf UCase(CHoose) = "SUMREPORTABUYGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع خرید امانی کالا به ازای هر گروه"
                ElseIf UCase(CHoose) = "SUMREPORTSELLGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع فروش کالا به ازای هر گروه"
                ElseIf UCase(CHoose) = "SUMREPORTASELLGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع فروش امانی کالا به ازای هر گروه"
                ElseIf UCase(CHoose) = "SUMREPORTBACKBUYGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع برگشت از خرید کالا به ازای هر گروه"
                ElseIf UCase(CHoose) = "SUMREPORTBACKSELLGROUP" Then
                    Dataret.DataTable1.Rows(0).Item("TypeReport") = "گزارش جمع برگشت از فروش کالا به ازای هر گروه"
                End If
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Part") = Lend
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim kol As Double = 0
                Dim joz As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    kol += Dataret.DataTable1.Rows(i).Item("KolCount")
                    Dataret.DataTable1.Rows(i).Item("JozCount") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    joz += Dataret.DataTable1.Rows(i).Item("JozCount")
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndKol") = kol.ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndJoz") = joz.ToString.Replace(".", "/")
                If UCase(CHoose) = "SUMREPORTBUY" Or UCase(CHoose) = "SUMREPORTABUY" Or UCase(CHoose) = "SUMREPORTSELL" Or UCase(CHoose) = "SUMREPORTASELL" Or UCase(CHoose) = "SUMREPORTBACKBUY" Or UCase(CHoose) = "SUMREPORTBACKSELL" Then
                    Dim ret As New CRP_Report_SUMKharid_Kala
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "SUMREPORTBUYKALA" Or UCase(CHoose) = "SUMREPORTABUYKALA" Or UCase(CHoose) = "SUMREPORTSELLKALA" Or UCase(CHoose) = "SUMREPORTASELLKALA" Or UCase(CHoose) = "SUMREPORTBACKBUYKALA" Or UCase(CHoose) = "SUMREPORTBACKSELLKALA" Then
                    Dim ret As New CRP_Report_SUMKharid_Kala2
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "SUMREPORTSELLPGROUP" Or UCase(CHoose) = "SUMREPORTASELLPGROUP" Or UCase(CHoose) = "SUMREPORTBUYPGROUP" Or UCase(CHoose) = "SUMREPORTABUYPGROUP" Or UCase(CHoose) = "SUMREPORTBACKBUYPGROUP" Or UCase(CHoose) = "SUMREPORTBACKSELLPGROUP" Then
                    Dim ret As New CRP_Report_SUMKharid_Kala4
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                Else
                    Dim ret As New CRP_Report_SUMKharid_Kala3
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SUMBuySell")
            Me.Close()
        End Try
    End Sub

    Private Sub BalanceKala()
        Try
            Dim Dataret As New DataSetMojodyMoney
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            Dim dv As DataView
            dv = Dataret.DataTable1.DefaultView

            If Num1 <> -1 Or Num2 <> -1 Then
                If Num1 <> -1 And Num2 <> -1 Then
                    dv.RowFilter = "DarsadNum>=" & CDbl(Num1) & " AND DarsadNum<=" & CDbl(Num2)
                    dv.Sort = "DarsadNum"
                ElseIf Num1 <> -1 And Num2 = -1 Then
                    dv.RowFilter = "DarsadNum>=" & CDbl(Num1)
                    dv.Sort = "DarsadNum"
                ElseIf Num1 = -1 And Num2 <> -1 Then
                    dv.RowFilter = "DarsadNum<=" & CDbl(Num2)
                    dv.Sort = "DarsadNum"
                Else
                    dv.RowFilter = ""
                End If
            End If

            If dv.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintStr") = GetDate()
                Dataret.DataTable1.Rows(0).Item("NamAnbar") = Tmp_OneGroup
                Dim SumMkolStr As Double = 0
                Dim SumMJozStr As Double = 0
                Dim SumKolStr As Double = 0
                Dim SumJozStr As Double = 0
                Dim SumKolOrderDay As Double = 0
                Dim SumJozOrderDay As Double = 0
                Dim SumKolOrderWeek As Double = 0
                Dim SumJozOrderWeek As Double = 0
                Dim SumKolOrderMonth As Double = 0
                Dim SumJozOrderMonth As Double = 0
                Dim SumKolOrder3Month As Double = 0
                Dim SumJozOrder3Month As Double = 0

                Dim SumKolOrder As Double = 0
                Dim SumJozOrder As Double = 0

                For i As Integer = 0 To dv.Count - 1
                    SumMkolStr += IIf(dv.Item(i).Item("MkolStr") Is DBNull.Value, 0, Replace(dv.Item(i).Item("MkolStr"), ".", "/"))
                    SumMJozStr += IIf(dv.Item(i).Item("MJozStr") Is DBNull.Value, 0, Replace(dv.Item(i).Item("MJozStr"), ".", "/"))
                    SumKolStr += IIf(dv.Item(i).Item("KolStr") Is DBNull.Value, 0, Replace(dv.Item(i).Item("KolStr"), ".", "/"))
                    SumJozStr += IIf(dv.Item(i).Item("JozStr") Is DBNull.Value, 0, Replace(dv.Item(i).Item("JozStr"), ".", "/"))
                    If UCase(CHoose) = "BALANCEKALAORDER" Then
                        SumKolOrderDay += IIf(dv.Item(i).Item("KolOrderDay") Is DBNull.Value, 0, Replace(dv.Item(i).Item("KolOrderDay"), ".", "/"))
                        SumJozOrderDay += IIf(dv.Item(i).Item("JozOrderDay") Is DBNull.Value, 0, Replace(dv.Item(i).Item("JozOrderDay"), ".", "/"))
                        SumKolOrderWeek += IIf(dv.Item(i).Item("KolOrderWeek") Is DBNull.Value, 0, Replace(dv.Item(i).Item("KolOrderWeek"), ".", "/"))
                        SumJozOrderWeek += IIf(dv.Item(i).Item("JozOrderWeek") Is DBNull.Value, 0, Replace(dv.Item(i).Item("JozOrderWeek"), ".", "/"))
                        SumKolOrderMonth += IIf(dv.Item(i).Item("KolOrderMonth") Is DBNull.Value, 0, Replace(dv.Item(i).Item("KolOrderMonth"), ".", "/"))
                        SumJozOrderMonth += IIf(dv.Item(i).Item("JozOrderMonth") Is DBNull.Value, 0, Replace(dv.Item(i).Item("JozOrderMonth"), ".", "/"))
                        SumKolOrder3Month += IIf(dv.Item(i).Item("KolOrder3Month") Is DBNull.Value, 0, Replace(dv.Item(i).Item("KolOrder3Month"), ".", "/"))
                        SumJozOrder3Month += IIf(dv.Item(i).Item("JozOrder3Month") Is DBNull.Value, 0, Replace(dv.Item(i).Item("JozOrder3Month"), ".", "/"))
                        SumKolOrder += IIf(dv.Item(i).Item("KolOrder") Is DBNull.Value, 0, Replace(dv.Item(i).Item("KolOrder"), ".", "/"))
                        SumJozOrder += IIf(dv.Item(i).Item("JozOrder") Is DBNull.Value, 0, Replace(dv.Item(i).Item("JozOrder"), ".", "/"))
                    End If
                Next
                dv.Item(0).Item("SUMMkolStr") = Replace(SumMkolStr, ".", "/")
                dv.Item(0).Item("SUMMJozStr") = Replace(SumMJozStr, ".", "/")
                dv.Item(0).Item("SUMKolStr") = Replace(SumKolStr, ".", "/")
                dv.Item(0).Item("SUMJozStr") = Replace(SumJozStr, ".", "/")
                dv.Item(0).Item("SUMKolOrderDay") = Replace(SumKolOrderDay, ".", "/")
                dv.Item(0).Item("SUMJozOrderDay") = Replace(SumJozOrderDay, ".", "/")
                dv.Item(0).Item("SUMKolOrderWeek") = Replace(SumKolOrderWeek, ".", "/")
                dv.Item(0).Item("SUMJozOrderWeek") = Replace(SumJozOrderWeek, ".", "/")
                dv.Item(0).Item("SUMKolOrderMonth") = Replace(SumKolOrderMonth, ".", "/")
                dv.Item(0).Item("SUMJozOrderMonth") = Replace(SumJozOrderMonth, ".", "/")
                dv.Item(0).Item("SUMKolOrder3Month") = Replace(SumKolOrder3Month, ".", "/")
                dv.Item(0).Item("SUMJozOrder3Month") = Replace(SumJozOrder3Month, ".", "/")
                dv.Item(0).Item("SUMKolOrder") = Replace(SumKolOrder, ".", "/")
                dv.Item(0).Item("SUMJozOrder") = Replace(SumJozOrder, ".", "/")
                dv.Item(0).Item("SUMJozOrder") = Replace(SumJozOrder, ".", "/")
                dv.Item(0).Item("SUMDarsad") = "-"

                If UCase(CHoose) = "BALANCEKALA" Then
                    Dim ret As New CRP_Report_Balance_Kala
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(dv)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "BALANCEKALAORDER" Then
                    Dim ret As New CRP_Report_Balance_KalaOrder
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(dv)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                End If
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "BalanceKala")
            Me.Close()
        End Try
    End Sub

    Private Sub BalanceKalaM()
        Try
            Dim Dataret As New DataSetMojodyMoney
            Dataret.Clear()

            For i As Integer = 0 To ListOrderManual.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListOrderManual(i).Nam, ListOrderManual(i).GroupKala, 0, 0, ListOrderManual(i).Fe, ListOrderManual(i).AllMon, ListOrderManual(i).KolStr, ListOrderManual(i).JozStr, GetDate, Tmp_OneGroup, ListOrderManual(i).MKolStr, ListOrderManual(i).MJozStr, ListOrderManual(i).KolOrder, ListOrderManual(i).JozOrder, ListOrderManual(i).KolOrderDay, "", ListOrderManual(i).KolOrderWeek, ListOrderManual(i).JozOrderWeek, ListOrderManual(i).KolOrderMonth, ListOrderManual(i).JozOrderMonth, "", "", ListOrderManual(i).SumMKolStr, ListOrderManual(i).SumMJozStr, ListOrderManual(i).SumKolStr, ListOrderManual(i).SumJozStr, ListOrderManual(i).SumKolOrderDay, "", ListOrderManual(i).SumKolOrderWeek, ListOrderManual(i).SumJozOrderWeek, ListOrderManual(i).SumKolOrderMonth, ListOrderManual(i).SumJozOrderMonth, "", "", ListOrderManual(i).SumKolOrder, ListOrderManual(i).SumJozOrder, ListOrderManual(i).Darsad, ListOrderManual(i).SumDarsad)
            Next

            Dim ret As New CRP_Report_Balance_KalaOrderM
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "BalanceKalaM")
            Me.Close()
        End Try
    End Sub

    Private Sub FroshUser()
        Try
            Dim Dataret As New DataSetFroshUser
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("NamUser") = Tmp_Namkala
                Dataret.DataTable1.Rows(0).Item("IdUser") = Tmp_Mon

                If UCase(CHoose) = "FROSHUSER1" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش فروش کاربر"
                ElseIf UCase(CHoose) = "FROSHVISIT1" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش فروش ویزیتور"
                End If

                Dim allmon As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozCount") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    allmon += Dataret.DataTable1.Rows(i).Item("Mon")
                Next
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using CMD As New SqlCommand(IdFactor, ConectionBank)
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("BackMon") = CMD.ExecuteScalar
                End Using
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndMon") = allmon - Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("BackMon")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim ret As New CRP_Report_FroshUser
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                CRV.ReportSource = ret
                Application.DoEvents()
                FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FroshUser")
            Me.Close()
        End Try
    End Sub

    Private Sub FroshUser2()
        Try
            Dim Dataret As New DataSetFroshUser
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()


            If Dataret.DataTable1.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(0).Item("Dat2") = State
                Dataret.DataTable1.Rows(0).Item("NamUser") = Tmp_Namkala
                Dataret.DataTable1.Rows(0).Item("IdUser") = Tmp_Mon

                If UCase(CHoose) = "FROSHUSER2" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش کاربر بر حسب کالا"
                ElseIf UCase(CHoose) = "FROSHUSER3" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش کاربر به ازای هر شخص بر حسب کالا"
                ElseIf UCase(CHoose) = "FROSHUSER4" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش کاربر به ازای هر شخص بر حسب گروه"
                ElseIf UCase(CHoose) = "FROSHUSER5" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش کاربر بر حسب گروه"


                ElseIf UCase(CHoose) = "FROSHVISIT2" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش ویزیتور بر حسب کالا"
                ElseIf UCase(CHoose) = "FROSHVISIT3" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش ویزیتور به ازای هر شخص بر حسب کالا"
                ElseIf UCase(CHoose) = "FROSHVISIT4" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش ویزیتور به ازای هر شخص بر حسب گروه"
                ElseIf UCase(CHoose) = "FROSHVISIT5" Then
                    Dataret.DataTable1.Rows(0).Item("TypeR") = "گزارش جمع فروش ویزیتور بر حسب گروه"
                End If

                Dim allmon As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("KolCount") = Dataret.DataTable1.Rows(i).Item("KolCount").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("JozCount") = Dataret.DataTable1.Rows(i).Item("JozCount").ToString.Replace(".", "/")
                    Dataret.DataTable1.Rows(i).Item("Darsad") = Dataret.DataTable1.Rows(i).Item("Darsad").ToString.Replace(".", "/")
                    allmon += Dataret.DataTable1.Rows(i).Item("Mon")
                Next
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                Using CMD As New SqlCommand(IdFactor, ConectionBank)
                    CMD.CommandTimeout = 0
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("BackMon") = CMD.ExecuteScalar
                End Using

                Using CMD As New SqlCommand(Lend, ConectionBank)
                    CMD.CommandTimeout = 0
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Discount") = CMD.ExecuteScalar
                End Using

                Using CMD As New SqlCommand(Str2, ConectionBank)
                    CMD.CommandTimeout = 0
                    Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Kasri") = CMD.ExecuteScalar
                End Using

                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndMon") = allmon - Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("BackMon") - Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Kasri") - Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Discount")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''

                If UCase(CHoose) = "FROSHUSER2" Or UCase(CHoose) = "FROSHVISIT2" Then
                    Dim ret As New CRP_Report_FroshUser2
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "FROSHUSER3" Or UCase(CHoose) = "FROSHVISIT3" Then
                    Dim ret As New CRP_Report_FroshUser3
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "FROSHUSER4" Or UCase(CHoose) = "FROSHVISIT4" Then
                    Dim ret As New CRP_Report_FroshUser4
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "FROSHUSER5" Or UCase(CHoose) = "FROSHVISIT5" Then
                    Dim ret As New CRP_Report_FroshUser5
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                End If
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FroshUser2")
            Me.Close()
        End Try
    End Sub

    Private Sub Sarmayeh_Amval()
        Try
            DtSarmayeh.Clear()
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                DtSarmayeh.Load(cmd.ExecuteReader)
            End Using
            If DtSarmayeh.Rows.Count > 0 Then
                If Not DtSarmayeh.Columns.Contains("PrintDat") Then DtSarmayeh.Columns.Add("PrintDat", Type.GetType("System.String"))
                If Not DtSarmayeh.Columns.Contains("Dat1") Then DtSarmayeh.Columns.Add("Dat1", Type.GetType("System.String"))
                If Not DtSarmayeh.Columns.Contains("Dat2") Then DtSarmayeh.Columns.Add("Dat2", Type.GetType("System.String"))
                If Not DtSarmayeh.Columns.Contains("Title") Then DtSarmayeh.Columns.Add("Title", Type.GetType("System.String"))
                If Not DtSarmayeh.Columns.Contains("EndT") Then DtSarmayeh.Columns.Add("EndT", Type.GetType("System.String"))
                If Not DtSarmayeh.Columns.Contains("EndMon") Then DtSarmayeh.Columns.Add("EndMon", Type.GetType("System.Double"))
                '''''''''''''''''''''''''''''''''''''
                DtSarmayeh.Rows(0).Item("PrintDat") = GetDate()
                DtSarmayeh.Rows(0).Item("Dat1") = Str1
                DtSarmayeh.Rows(0).Item("Dat2") = State

                If UCase(CHoose) = "SARMAYEH" Then
                    DtSarmayeh.Rows(0).Item("Title") = "گزارش سرمایه"
                ElseIf UCase(CHoose) = "AMVAL" Then
                    DtSarmayeh.Rows(0).Item("Title") = "گزارش اموال"
                ElseIf UCase(CHoose) = "SUMSARMAYEH" Then
                    DtSarmayeh.Rows(0).Item("Title") = "گزارش جمع سرمایه"
                ElseIf UCase(CHoose) = "SUMAMVAL" Then
                    DtSarmayeh.Rows(0).Item("Title") = "گزارش جمع اموال"
                End If

                DtSarmayeh.Columns("Mandeh").ReadOnly = False
                DtSarmayeh.Columns("T").ReadOnly = False
                SetBedBesTableMoein(DtSarmayeh)

                DtSarmayeh.Rows(DtSarmayeh.Rows.Count - 1).Item("EndT") = DtSarmayeh.Rows(DtSarmayeh.Rows.Count - 1).Item("T")
                DtSarmayeh.Rows(DtSarmayeh.Rows.Count - 1).Item("EndMon") = DtSarmayeh.Rows(DtSarmayeh.Rows.Count - 1).Item("Mandeh")

                If UCase(CHoose) = "SARMAYEH" Or UCase(CHoose) = "AMVAL" Then
                    Dim ret As New CRP_Report_Sarmayeh
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(DtSarmayeh)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf UCase(CHoose) = "SUMSARMAYEH" Or UCase(CHoose) = "SUMAMVAL" Then
                    Dim ret As New CRP_Report_SUMSarmayeh
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(DtSarmayeh)
                    CRV.ReportSource = ret
                    Application.DoEvents()
                    FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                End If

            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Sarmayeh_Amval")
            Me.Close()
        End Try
    End Sub

    Private Sub SumKalaFactor()
        Try
            Dim Dataret As New DataSetExitFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Namfactor") = Tmp_OneGroup
                Dataret.DataTable1.Rows(0).Item("IdExit") = Tmp_String1
                Dataret.DataTable1.Rows(0).Item("IdUser") = Id_User
                Dim w As Double = 0
                Dim joz2 As Double = 0

                '//////////////////////////////////////////
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    w += CDbl(Dataret.DataTable1.Rows(i).Item("Wgt").ToString.Replace("/", "."))
                    If Dataret.DataTable1.Rows(i).Item("DK") = True Then
                        Dataret.DataTable1.Rows(i).Item("kol") = Fix(Dataret.DataTable1.Rows(i).Item("Joz") / Dataret.DataTable1.Rows(i).Item("DK_JOZ"))
                        Dim a As Double = (Dataret.DataTable1.Rows(i).Item("Joz") / Dataret.DataTable1.Rows(i).Item("DK_JOZ")) - Dataret.DataTable1.Rows(i).Item("kol")
                        Dataret.DataTable1.Rows(i).Item("Joz2") = Replace(Math.Round((a * Dataret.DataTable1.Rows(i).Item("joz")) / (Dataret.DataTable1.Rows(i).Item("Joz") / Dataret.DataTable1.Rows(i).Item("DK_JOZ"))), ".", "/")
                    Else
                        Dim a As Double = Dataret.DataTable1.Rows(i).Item("Kol") - Fix(Dataret.DataTable1.Rows(i).Item("kol"))
                        Dataret.DataTable1.Rows(i).Item("kol") = Fix(Dataret.DataTable1.Rows(i).Item("kol"))
                        Dataret.DataTable1.Rows(i).Item("Joz2") = Replace(a, ".", "/")
                    End If
                    joz2 += CDbl(Dataret.DataTable1.Rows(i).Item("Joz2").ToString.Replace("/", "."))
                Next
                '//////////////////////////////////////////
                'For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                '    w += CDbl(Dataret.DataTable1.Rows(i).Item("Wgt").ToString.Replace("/", "."))
                '    If Dataret.DataTable1.Rows(i).Item("kol").ToString.Contains(".") Then
                '        Dim a As Double = (CDbl(Dataret.DataTable1.Rows(i).Item("kol")) - Fix(Dataret.DataTable1.Rows(i).Item("kol")))
                '        If Dataret.DataTable1.Rows(i).Item("DK") = True Then
                '            Dataret.DataTable1.Rows(i).Item("Joz2") = Replace(Math.Round((a * Dataret.DataTable1.Rows(i).Item("joz")) / Dataret.DataTable1.Rows(i).Item("Kol")), ".", "/")
                '        Else
                '            Dataret.DataTable1.Rows(i).Item("Joz2") = Replace(Math.Round((a * Dataret.DataTable1.Rows(i).Item("joz")) / Dataret.DataTable1.Rows(i).Item("Kol")), ".", "/")
                '        End If
                '    Else
                '        Dataret.DataTable1.Rows(i).Item("Joz2") = 0
                '    End If
                '    joz2 += CDbl(Dataret.DataTable1.Rows(i).Item("Joz2").ToString.Replace("/", "."))
                '    Dataret.DataTable1.Rows(i).Item("kol") = Fix(Dataret.DataTable1.Rows(i).Item("kol"))
                'Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndJoz2") = Replace(joz2, ".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("EndWgt") = Replace(w, ".", "/")
                GetInfoExitFactor(Lend)
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("City") = Tmp_Namkala
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Part") = Tmp_OneGroup
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Driver") = TmpAddress
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("Reciver") = TmpTell1

                If UCase(CHoose) = "SUMFACTOR" Then
                    Dim ret As New CRP_Report_SumFactor
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                Else
                    Dim ret As New CRP_Report_SumFactor2
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                End If
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SumKalaFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub SOD()
        Try
            Dim Dataret As New DataSetSod
            Dataret.Clear()
            Dataret.DataTable1.AddDataTable1Row(Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10, Num11, Num12, Num13, Num14, Num15, GetNamCompany(), Tmp_String1)
            Dim ret As New CRP_Sod
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SOD")
            Me.Close()
        End Try
    End Sub

    Private Sub TranslateAnbar()
        Try
            Dim Dataret As New DataSetDelay

            For i As Integer = 0 To ListDelayPrintArray.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListDelayPrintArray(i).IdFactor, ListDelayPrintArray(i).nam, ListDelayPrintArray(i).Tell1, ListDelayPrintArray(i).Tell2, ListDelayPrintArray(i).D_Date, ListDelayPrintArray(i).EndDate, ListDelayPrintArray(i).TimeRemain, ListDelayPrintArray(i).Remain, ListDelayPrintArray(i).Disc, ListDelayPrintArray(i).Rate, ListDelayPrintArray(i).Kind, ListDelayPrintArray(i).Nam2, GetDate(), 0, "", 0, 0, 0, "", "")
            Next
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_Report_Translate_Anbar
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "TranslateAnbar")
            Me.Close()
        End Try
    End Sub

    Private Sub SodFactor()
        Try
            Dim Dataret As New DataSetDelay

            For i As Integer = 0 To ListDelayPrintArray.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListDelayPrintArray(i).IdFactor, ListDelayPrintArray(i).nam, ListDelayPrintArray(i).Tell1, ListDelayPrintArray(i).Tell2, ListDelayPrintArray(i).D_Date, ListDelayPrintArray(i).EndDate, ListDelayPrintArray(i).TimeRemain, ListDelayPrintArray(i).Remain, ListDelayPrintArray(i).Disc, ListDelayPrintArray(i).Rate, ListDelayPrintArray(i).Kind, ListDelayPrintArray(i).Nam2, GetDate(), ListDelayPrintArray(i).Tmp, "", 0, 0, 0, "", "")
            Next
            '''''''''''''''''''''''''''''
            If UCase(CHoose) = "SODPRINT1" Then
                Dim ret As New CRP_Report_ListSod_Factor
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                Dim ret As New CRP_Report_ListSod_Factor2
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SodFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub SodFactor2()
        Try
            Dim Dataret As New DataSetDelay

            For i As Integer = 0 To ListDelayPrintArray.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListDelayPrintArray(i).IdFactor, ListDelayPrintArray(i).D_Date, ListDelayPrintArray(i).Tell1, "", ListDelayPrintArray(i).EndDate, "", ListDelayPrintArray(i).TimeRemain, ListDelayPrintArray(i).Remain, "", ListDelayPrintArray(i).Rate, ListDelayPrintArray(i).SUMDarsad, "", GetDate(), ListDelayPrintArray(i).Tmp, ListDelayPrintArray(i).Darsad, ListDelayPrintArray(i).Mandeh, ListDelayPrintArray(i).Tell2, ListDelayPrintArray(i).T, "", "")
            Next
            '''''''''''''''''''''''''''''
            If UCase(CHoose) = "SODPRINT3" Then
                Dim ret As New CRP_Report_ListSod_Factor3
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                Dim ret As New CRP_Report_ListSod_Factor3_1
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SodFactor2")
            Me.Close()
        End Try
    End Sub
    Private Sub ReportChk()
        Try
            Dim Dataret As New DataSetChk
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            ''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Type") = Str1

                Dim MonChk As Double = 0
                Dim AllMonChk As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dataret.DataTable1.Rows(i).Item("C_day") = SUBDAY(Dataret.DataTable1.Rows(i).Item("PayDate"), Dataret.DataTable1.Rows(i).Item("GetDate"))
                    MonChk += Dataret.DataTable1.Rows(i).Item("Mon")
                    AllMonChk += Dataret.DataTable1.Rows(i).Item("Mon") * Dataret.DataTable1.Rows(i).Item("C_day")
                Next
                Dim ras As String = ""
                ras = Replace(Format$(AllMonChk / MonChk, "###.##"), ".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("RasChk") = IIf(UCase(ras) = "NAN", 0, ras)
                '''''''''''''''''''''''''''''
                Dim ret As New CRP_Report_Chk
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportChk")
            Me.Close()
        End Try
    End Sub

    Private Sub ReportBratChk()
        Try
            Dim Dataret As New DataSetBratChk
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                '''''''''''''''''''''''''''''
                Dim ret As New CRP_Report_Asnad_Barati
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportBratChk")
            Me.Close()
        End Try
    End Sub

    Private Sub ReportListCostKala()
        Try
            Dim Dataret As New DataSetMojodyKala
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                '''''''''''''''''''''''''''''
                If CHoose = "LISTCOSTKALA" Then
                    Dim ret As New CRP_Report_ListCost
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf CHoose = "LISTCOSTKALAALL" Then
                    Dim ret As New CRP_Report_ListCost3
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf CHoose = "LISTCOSTKALAALL2" Then
                    Dim ret As New CRP_Report_ListCost3_1
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf CHoose = "LISTCOSTKALAMARGIN" Then
                    Dim ret As New CRP_Report_ListCost4
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf CHoose = "LISTBUYSELLKALA" Then
                    Dim ret As New CRP_Report_ListCost5
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                ElseIf CHoose = "LISTPROMOTIONKALA" Then
                    Dim ret As New CRP_Report_ListCost6
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                Else
                    Dim ret As New CRP_Report_ListCost2
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                End If

            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ReportListCostKala")
            Me.Close()
        End Try
    End Sub


    Private Sub FroshAllUser()
        Try
            Dim Dataret As New DataSetFroshAllUser
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using

            Dim Dt As New DataTable
            Using cm As New SqlCommand("SELECT IdUser,[Delay],Rate,MaxNewDate ,D_date ,Remain FROM (SELECT IdUser ,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,IdUser,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor) -(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date,IdName,IdUser  FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor ) As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName )As ListDelay WHERE Remain >0", ConectionBank)
                cm.CommandTimeout = 0
                Dt.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dt.Rows.Count > 0 Then
                Dt.Columns("MaxNewDate").ReadOnly = False
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dt.Rows(i).Item("MaxNewDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                    Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("MaxNewDate"), GetDate())
                Next

                Dim DarsadMandeh As Double = 0
                Dim DarsadEndFrosh As Double = 0
                Dim DarsadDelay As Double = 0
                Dim DarsadBack As Double = 0
                Dim DarsadDiscount As Double = 0
                Dim Rw As Double = 0
                Dim RC As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim row() As DataRow = Nothing
                    Dim row1() As DataRow = Nothing
                    If Not String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND (MaxNewDate<='" & State & "')")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND (MaxNewDate>='" & Str1 & "')")
                    ElseIf String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & State & "'")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & State & "'")
                    ElseIf Not String.IsNullOrEmpty(Str1) And String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & Str1 & "'")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & Str1 & "'")
                    Else
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0")
                    End If
                    If row.Length > 0 Then
                        For j As Integer = 0 To row.Length - 1
                            Dataret.DataTable1.Rows(i).Item("DelayFactor") += row(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("DelayFactor") = 0
                    End If
                    If row1.Length > 0 Then
                        For j As Integer = 0 To row1.Length - 1
                            Dataret.DataTable1.Rows(i).Item("MandehFactor") += row1(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("MandehFactor") = 0
                    End If

                    Dataret.DataTable1.Rows(i).Item("DarsadMandeh") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("MandehFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDelay") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("DelayFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadBack") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("BackFrosh") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDiscount") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("Discount") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))

                    DarsadMandeh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadMandeh").ToString.Replace("/", "."))
                    DarsadDelay += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDelay").ToString.Replace("/", "."))
                    DarsadBack += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadBack").ToString.Replace("/", "."))
                    DarsadDiscount += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace("/", "."))
                    Rw += CDbl(Dataret.DataTable1.Rows(i).Item("ROW").ToString.Replace("/", "."))
                    RC += CDbl(Dataret.DataTable1.Rows(i).Item("SUMROW").ToString.Replace("/", "."))
                    DarsadEndFrosh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadEndFrosh").ToString.Replace("/", "."))
                Next
                Dataret.DataTable1.Rows(0).Item("SUMDarsadMandeh") = IIf(DarsadMandeh <= 0, 0, Math.Round(DarsadMandeh / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDelay") = IIf(DarsadDelay <= 0, 0, Math.Round(DarsadDelay / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadBack") = IIf(DarsadBack <= 0, 0, Math.Round(DarsadBack / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDiscount") = IIf(DarsadDiscount <= 0, 0, Math.Round(DarsadDiscount / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("AVGROW") = Math.Round(Rw / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("AllSUMROW") = (RC).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("SUMDarsadEndFrosh") = (DarsadEndFrosh).ToString.Replace(".", "/")
            End If
            Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
            Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
            Dataret.DataTable1.Rows(0).Item("Dat2") = State
            Dataret.DataTable1.Rows(0).Item("Kind") = "گزارش جمع فروش کاربران"
            Dim ret As New CRP_Report_FroshAllUser
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FroshAllUser")
            Me.Close()
        End Try
    End Sub

    Private Sub FroshStateUser()
        Try
            Dim Dataret As New DataSetFroshAllUser
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using

            Dim Dt As New DataTable
            Using cm As New SqlCommand("SELECT IdUser,[Delay],Rate,MaxNewDate ,D_date ,Remain FROM (SELECT IdUser ,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,IdUser,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor) -(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date,IdName,IdUser  FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor ) As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName )As ListDelay WHERE Remain >0", ConectionBank)
                cm.CommandTimeout = 0
                Dt.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            Dim DtP As New DataTable
            Using cm As New SqlCommand(Lend, ConectionBank)
                cm.CommandTimeout = 0
                DtP.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dt.Rows.Count > 0 Then
                Dt.Columns("MaxNewDate").ReadOnly = False
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dt.Rows(i).Item("MaxNewDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                    Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("MaxNewDate"), GetDate())
                Next

                Dim DarsadMandeh As Double = 0
                Dim DarsadEndFrosh As Double = 0
                Dim DarsadDelay As Double = 0
                Dim DarsadBack As Double = 0
                Dim DarsadDiscount As Double = 0
                Dim Rw As Double = 0
                Dim RC As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim row() As DataRow = Nothing
                    Dim row1() As DataRow = Nothing
                    If Not String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND (MaxNewDate<='" & State & "')")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND (MaxNewDate>='" & Str1 & "')")
                    ElseIf String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & State & "'")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & State & "'")
                    ElseIf Not String.IsNullOrEmpty(Str1) And String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & Str1 & "'")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & Str1 & "'")
                    Else
                        row = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0")
                        row1 = Dt.Select("IdUser=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0")
                    End If
                    If row.Length > 0 Then
                        For j As Integer = 0 To row.Length - 1
                            Dataret.DataTable1.Rows(i).Item("DelayFactor") += row(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("DelayFactor") = 0
                    End If
                    If row1.Length > 0 Then
                        For j As Integer = 0 To row1.Length - 1
                            Dataret.DataTable1.Rows(i).Item("MandehFactor") += row1(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("MandehFactor") = 0
                    End If

                    Dataret.DataTable1.Rows(i).Item("DarsadMandeh") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("MandehFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDelay") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("DelayFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadBack") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("BackFrosh") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDiscount") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("Discount") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))

                    DarsadMandeh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadMandeh").ToString.Replace("/", "."))
                    DarsadDelay += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDelay").ToString.Replace("/", "."))
                    DarsadBack += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadBack").ToString.Replace("/", "."))
                    DarsadDiscount += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace("/", "."))
                    Rw += CDbl(Dataret.DataTable1.Rows(i).Item("ROW").ToString.Replace("/", "."))
                    RC += CDbl(Dataret.DataTable1.Rows(i).Item("SUMROW").ToString.Replace("/", "."))
                    DarsadEndFrosh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadEndFrosh").ToString.Replace("/", "."))
                Next
                Dataret.DataTable1.Rows(0).Item("SUMDarsadMandeh") = IIf(DarsadMandeh <= 0, 0, Math.Round(DarsadMandeh / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDelay") = IIf(DarsadDelay <= 0, 0, Math.Round(DarsadDelay / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadBack") = IIf(DarsadBack <= 0, 0, Math.Round(DarsadBack / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDiscount") = IIf(DarsadDiscount <= 0, 0, Math.Round(DarsadDiscount / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("AVGROW") = Math.Round(Rw / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("AllSUMROW") = (RC).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("SUMDarsadEndFrosh") = (DarsadEndFrosh).ToString.Replace(".", "/")
            End If

            If DtP.Rows.Count > 0 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim count As Long = 0
                    For j As Integer = 0 To DtP.Rows.Count - 1
                        Using CMD As New SqlCommand("Select Top 1 IdUser FROM ListFactorSell WHERE Activ =1 and Stat =3 AND IdName =" & DtP.Rows(j).Item("IdName") & " AND D_date =N'" & DtP.Rows(j).Item("D_Date") & "'  ORDER By IdFactor", ConectionBank)
                            Dim idv As Object = CMD.ExecuteScalar
                            If Not (idv Is DBNull.Value) Then
                                If CType(idv, Long) = Dataret.DataTable1.Rows(i).Item("Id") Then count += 1
                            End If
                        End Using
                    Next
                    Dataret.DataTable1.Rows(i).Item("CVisit") = count
                Next
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End If

            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(i).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(i).Item("Dat2") = State
                Dataret.DataTable1.Rows(i).Item("Kind") = "گزارش عملکرد کاربران"
                Dataret.DataTable1.Rows(i).Item("DarsadVisit") = IIf(Dataret.DataTable1.Rows(i).Item("AllVisit") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("PVisit") * 100 / Dataret.DataTable1.Rows(i).Item("AllVisit"), 2).ToString.Replace(".", "/"))
            Next

            Dim ret As New CRP_Report_FroshStateUser
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FroshStateUser")
            Me.Close()
        End Try
    End Sub

    Private Sub FroshAllVisitor()
        Try
            Dim Dataret As New DataSetFroshAllUser
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using

            Dim Dt As New DataTable
            Using cm As New SqlCommand("SELECT IdVisitor,[Delay],Rate,MaxNewDate ,D_date ,Remain FROM (SELECT IdVisitor ,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,IdVisitor ,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date,IdName,IdVisitor  FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor ) As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName )As ListDelay WHERE Remain >0", ConectionBank)
                cm.CommandTimeout = 0
                Dt.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If Dt.Rows.Count > 0 Then
                Dt.Columns("MaxNewDate").ReadOnly = False
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dt.Rows(i).Item("MaxNewDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                    Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("MaxNewDate"), GetDate())
                Next

                Dim DarsadEndFrosh As Double = 0
                Dim DarsadMandeh As Double = 0
                Dim DarsadDelay As Double = 0
                Dim DarsadBack As Double = 0
                Dim DarsadDiscount As Double = 0
                Dim Rw As Double = 0
                Dim RC As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim row() As DataRow = Nothing
                    Dim row1() As DataRow = Nothing
                    If Not String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND (MaxNewDate<='" & State & "')")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND (MaxNewDate>='" & Str1 & "')")
                    ElseIf String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & State & "'")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & State & "'")
                    ElseIf Not String.IsNullOrEmpty(Str1) And String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & Str1 & "'")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & Str1 & "'")
                    Else
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0")
                    End If
                    If row.Length > 0 Then
                        For j As Integer = 0 To row.Length - 1
                            Dataret.DataTable1.Rows(i).Item("DelayFactor") += row(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("DelayFactor") = 0
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''
                    If row1.Length > 0 Then
                        For j As Integer = 0 To row1.Length - 1
                            Dataret.DataTable1.Rows(i).Item("MandehFactor") += row1(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("MandehFactor") = 0
                    End If
                    Dataret.DataTable1.Rows(i).Item("DarsadMandeh") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("MandehFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDelay") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("DelayFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadBack") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("BackFrosh") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDiscount") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("Discount") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    DarsadMandeh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadMandeh").ToString.Replace("/", "."))
                    DarsadDelay += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDelay").ToString.Replace("/", "."))
                    DarsadBack += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadBack").ToString.Replace("/", "."))
                    DarsadDiscount += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace("/", "."))
                    Rw += CDbl(Dataret.DataTable1.Rows(i).Item("ROW").ToString.Replace("/", "."))
                    RC += CDbl(Dataret.DataTable1.Rows(i).Item("SUMROW").ToString.Replace("/", "."))
                    DarsadEndFrosh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadEndFrosh").ToString.Replace("/", "."))
                Next
                Dataret.DataTable1.Rows(0).Item("SUMDarsadMandeh") = IIf(DarsadMandeh <= 0, 0, Math.Round(DarsadMandeh / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDelay") = IIf(DarsadDelay <= 0, 0, Math.Round(DarsadDelay / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadBack") = IIf(DarsadBack <= 0, 0, Math.Round(DarsadBack / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDiscount") = IIf(DarsadDiscount <= 0, 0, Math.Round(DarsadDiscount / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("AVGROW") = Math.Round(Rw / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("AllSUMROW") = (RC).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("SUMDarsadEndFrosh") = (DarsadEndFrosh).ToString.Replace(".", "/")
            End If
            Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
            Dataret.DataTable1.Rows(0).Item("Dat1") = Str1
            Dataret.DataTable1.Rows(0).Item("Dat2") = State
            Dataret.DataTable1.Rows(0).Item("Kind") = "گزارش جمع فروش ویزیتورها"
            Dim ret As New CRP_Report_FroshAllUser
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FroshAllVisitor")
            Me.Close()
        End Try
    End Sub

    Private Sub FroshStateVisitor()
        Try
            Dim Dataret As New DataSetFroshAllUser
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using

            Dim Dt As New DataTable
            Using cm As New SqlCommand("SELECT IdVisitor,[Delay],Rate,MaxNewDate ,D_date ,Remain FROM (SELECT IdVisitor ,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,IdVisitor ,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date,IdName,IdVisitor  FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor ) As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName )As ListDelay WHERE Remain >0", ConectionBank)
                cm.CommandTimeout = 0
                Dt.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            Dim DtP As New DataTable
            Using cm As New SqlCommand(Lend, ConectionBank)
                cm.CommandTimeout = 0
                DtP.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            If Dt.Rows.Count > 0 Then
                Dt.Columns("MaxNewDate").ReadOnly = False
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dt.Rows(i).Item("MaxNewDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                    Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("MaxNewDate"), GetDate())
                Next

                Dim DarsadEndFrosh As Double = 0
                Dim DarsadMandeh As Double = 0
                Dim DarsadDelay As Double = 0
                Dim DarsadBack As Double = 0
                Dim DarsadDiscount As Double = 0
                Dim Rw As Double = 0
                Dim RC As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim row() As DataRow = Nothing
                    Dim row1() As DataRow = Nothing
                    If Not String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND (MaxNewDate<='" & State & "')")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND (MaxNewDate>='" & Str1 & "')")
                    ElseIf String.IsNullOrEmpty(Str1) And Not String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & State & "'")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & State & "'")
                    ElseIf Not String.IsNullOrEmpty(Str1) And String.IsNullOrEmpty(State) Then
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0 AND  MaxNewDate<='" & Str1 & "'")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0 AND  MaxNewDate>='" & Str1 & "'")
                    Else
                        row = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0")
                        row1 = Dt.Select("IdVisitor=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate>0")
                    End If
                    If row.Length > 0 Then
                        For j As Integer = 0 To row.Length - 1
                            Dataret.DataTable1.Rows(i).Item("DelayFactor") += row(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("DelayFactor") = 0
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''
                    If row1.Length > 0 Then
                        For j As Integer = 0 To row1.Length - 1
                            Dataret.DataTable1.Rows(i).Item("MandehFactor") += row1(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("MandehFactor") = 0
                    End If
                    Dataret.DataTable1.Rows(i).Item("DarsadMandeh") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("MandehFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDelay") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("DelayFactor") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadBack") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("BackFrosh") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    Dataret.DataTable1.Rows(i).Item("DarsadDiscount") = IIf(Dataret.DataTable1.Rows(i).Item("EndFrosh") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("Discount") * 100 / Dataret.DataTable1.Rows(i).Item("EndFrosh"), 2).ToString.Replace(".", "/"))
                    DarsadMandeh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadMandeh").ToString.Replace("/", "."))
                    DarsadDelay += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDelay").ToString.Replace("/", "."))
                    DarsadBack += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadBack").ToString.Replace("/", "."))
                    DarsadDiscount += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadDiscount").ToString.Replace("/", "."))
                    Rw += CDbl(Dataret.DataTable1.Rows(i).Item("ROW").ToString.Replace("/", "."))
                    RC += CDbl(Dataret.DataTable1.Rows(i).Item("SUMROW").ToString.Replace("/", "."))
                    DarsadEndFrosh += CDbl(Dataret.DataTable1.Rows(i).Item("DarsadEndFrosh").ToString.Replace("/", "."))
                Next
                Dataret.DataTable1.Rows(0).Item("SUMDarsadMandeh") = IIf(DarsadMandeh <= 0, 0, Math.Round(DarsadMandeh / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDelay") = IIf(DarsadDelay <= 0, 0, Math.Round(DarsadDelay / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadBack") = IIf(DarsadBack <= 0, 0, Math.Round(DarsadBack / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("SUMDarsadDiscount") = IIf(DarsadDiscount <= 0, 0, Math.Round(DarsadDiscount / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/"))
                Dataret.DataTable1.Rows(0).Item("AVGROW") = Math.Round(Rw / Dataret.DataTable1.Rows.Count, 2).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("AllSUMROW") = (RC).ToString.Replace(".", "/")
                Dataret.DataTable1.Rows(0).Item("SUMDarsadEndFrosh") = (DarsadEndFrosh).ToString.Replace(".", "/")
            End If

            If DtP.Rows.Count > 0 Then
                If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim count As Long = 0
                    For j As Integer = 0 To DtP.Rows.Count - 1
                        Using CMD As New SqlCommand("Select Top 1 IdVisitor FROM ListFactorSell WHERE Activ =1 and Stat =3 AND IdName =" & DtP.Rows(j).Item("IdName") & " AND D_date =N'" & DtP.Rows(j).Item("D_Date") & "'  ORDER By IdFactor", ConectionBank)
                            Dim idv As Object = CMD.ExecuteScalar
                            If Not (idv Is DBNull.Value) Then
                                If CType(idv, Long) = Dataret.DataTable1.Rows(i).Item("Id") Then count += 1
                            End If
                        End Using
                    Next
                    Dataret.DataTable1.Rows(i).Item("CVisit") = count
                Next
                If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            End If

            For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                Dataret.DataTable1.Rows(i).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(i).Item("Dat1") = Str1
                Dataret.DataTable1.Rows(i).Item("Dat2") = State
                Dataret.DataTable1.Rows(i).Item("Kind") = "گزارش عملکرد ویزیتور"
                Dataret.DataTable1.Rows(i).Item("DarsadVisit") = IIf(Dataret.DataTable1.Rows(i).Item("AllVisit") <= 0, 0, Math.Round(Dataret.DataTable1.Rows(i).Item("PVisit") * 100 / Dataret.DataTable1.Rows(i).Item("AllVisit"), 2).ToString.Replace(".", "/"))
            Next

            Dim ret As New CRP_Report_FroshStateUser
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FroshStateVisitor")
            Me.Close()
        End Try
    End Sub

    Private Sub ListPeople()
        Try
            Dim Dataret As New DataSetListPeople
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                
                Dim ret As New CRP_ListPeople
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ListPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub SCost()
        Try
            Dim Dataret As New DataSetSCost
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dim ret As New CRP_SCost
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "SCost")
            Me.Close()
        End Try
    End Sub

    Private Sub ChartDayCharge()
        Try
            Dim Dataret As New DataSetCharge
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                If UCase(CHoose) = "CHART-WEEKCHARGE" Then
                    Array.Resize(ListWeek, 0)
                    Array.Resize(ListWeek, 4)
                    '''''''''''''
                    ListWeek(0).Part = "هفته اول"
                    ListWeek(0).Mon = 0
                    '''''''''''''
                    ListWeek(1).Part = "هفته دوم"
                    ListWeek(1).Mon = 0
                    '''''''''''''
                    ListWeek(2).Part = "هفته سوم"
                    ListWeek(2).Mon = 0
                    '''''''''''''
                    ListWeek(3).Part = "هفته چهارم"
                    ListWeek(3).Mon = 0

                    For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                        If Dataret.DataTable1.Rows(i).Item("T").ToString.Contains("/") Then
                            Dim Day() As String = Dataret.DataTable1.Rows(i).Item("T").ToString.Split("/")
                            If CLng(Day(2)) >= 1 And CLng(Day(2)) <= 7 Then
                                ListWeek(0).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                            ElseIf CLng(Day(2)) >= 8 And CLng(Day(2)) <= 14 Then
                                ListWeek(1).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                            ElseIf CLng(Day(2)) >= 15 And CLng(Day(2)) <= 21 Then
                                ListWeek(2).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                            ElseIf CLng(Day(2)) >= 22 And CLng(Day(2)) <= 31 Then
                                ListWeek(3).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                            End If
                        Else
                            ListWeek(0).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                        End If
                    Next
                    Dataret.DataTable1.Clear()
                    For i As Integer = 0 To ListWeek.Length - 1
                        Dataret.DataTable1.AddDataTable1Row("", "", "", 0, 0, ListWeek(i).Mon, ListWeek(i).Part, "", "", "", "", 0, "")
                    Next
                ElseIf UCase(CHoose) = "CHART-MONTHCHARGE" Then
                    Array.Resize(ListWeek, 0)
                    Array.Resize(ListWeek, 12)
                    '''''''''''''
                    ListWeek(0).Part = "فروردین"
                    ListWeek(0).Mon = 0
                    '''''''''''''
                    ListWeek(1).Part = "اردیبهشت"
                    ListWeek(1).Mon = 0
                    '''''''''''''
                    ListWeek(2).Part = "خرداد"
                    ListWeek(2).Mon = 0
                    '''''''''''''
                    ListWeek(3).Part = "تیر"
                    ListWeek(3).Mon = 0
                    '''''''''''''
                    ListWeek(4).Part = "مرداد"
                    ListWeek(4).Mon = 0
                    '''''''''''''
                    ListWeek(5).Part = "شهریور"
                    ListWeek(5).Mon = 0
                    '''''''''''''
                    ListWeek(6).Part = "مهر"
                    ListWeek(6).Mon = 0
                    '''''''''''''
                    ListWeek(7).Part = "آبان"
                    ListWeek(7).Mon = 0
                    '''''''''''''
                    ListWeek(8).Part = "آذر"
                    ListWeek(8).Mon = 0
                    '''''''''''''
                    ListWeek(9).Part = "دی"
                    ListWeek(9).Mon = 0
                    '''''''''''''
                    ListWeek(10).Part = "بهمن"
                    ListWeek(10).Mon = 0
                    '''''''''''''
                    ListWeek(11).Part = "اسفند"
                    ListWeek(11).Mon = 0

                    For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                        If Dataret.DataTable1.Rows(i).Item("T").ToString.Contains("/") Then
                            Dim Day() As String = Dataret.DataTable1.Rows(i).Item("T").ToString.Split("/")
                            If CLng(Day(1)) = 1 Then
                                ListWeek(0).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 2 Then
                                ListWeek(1).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 3 Then
                                ListWeek(2).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 4 Then
                                ListWeek(3).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 5 Then
                                ListWeek(4).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 6 Then
                                ListWeek(5).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 7 Then
                                ListWeek(6).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 8 Then
                                ListWeek(7).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 9 Then
                                ListWeek(8).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 10 Then
                                ListWeek(9).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 11 Then
                                ListWeek(10).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))

                            ElseIf CLng(Day(1)) = 12 Then
                                ListWeek(11).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                            End If
                        Else
                            ListWeek(0).Mon += CDbl(Dataret.DataTable1.Rows(i).Item("Mandeh"))
                        End If
                    Next
                    Dataret.DataTable1.Clear()
                    For i As Integer = 0 To ListWeek.Length - 1
                        Dataret.DataTable1.AddDataTable1Row("", "", "", 0, 0, ListWeek(i).Mon, ListWeek(i).Part, "", "", "", "", 0, "")
                    Next
                ElseIf UCase(CHoose) = "CHART-DAYCHARGE" Then

                    For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                        IIf(Dataret.DataTable1.Rows(i).Item("T").ToString.Contains("/"), Dataret.DataTable1.Rows(i).Item("T") = Dataret.DataTable1.Rows(i).Item("T").ToString.Remove(0, 2), Dataret.DataTable1.Rows(i).Item("T"))
                    Next
                End If

                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("NamCharge") = Str1
                Dataret.DataTable1.Rows(0).Item("Title") = Str2
                Dataret.DataTable1.Rows(0).Item("Dat1") = State
                Dataret.DataTable1.Rows(0).Item("Dat2") = IdFactor
                If Lend = "PIE" Then
                    Dim ret As New CRP_Chart_dayCharge_Pie
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                ElseIf Lend = "LINE" Then
                    Dim ret As New CRP_Chart_dayCharge_Line
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                ElseIf Lend = "BAR" Then
                    Dim ret As New CRP_Chart_dayCharge_Bar
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                End If
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ChartDayCharge")
            Me.Close()
        End Try
    End Sub

    Private Sub ChartFrosh()
        Try
            Dim Dataret As New DataSetCharge
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("NamCharge") = Str1
                Dataret.DataTable1.Rows(0).Item("Title") = Str2
                Dataret.DataTable1.Rows(0).Item("Dat1") = State
                Dataret.DataTable1.Rows(0).Item("Dat2") = IdFactor
                If Lend = "PIE" Then
                    Dim ret As New CRP_Chart_dayCharge_Pie
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                ElseIf Lend = "LINE" Then
                    Dim ret As New CRP_Chart_dayCharge_Line
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                ElseIf Lend = "BAR" Then
                    Dim ret As New CRP_Chart_dayCharge_Bar
                    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                    Application.DoEvents()
                    ret.SetDataSource(Dataret)
                    Me.CRV.ReportSource = ret
                End If
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "ChartFrosh")
            Me.Close()
        End Try
    End Sub

    Private Sub DelayExit()
        Try
            Dim Dataret As New DataSetDelayExit
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Comp") = GetNamCompany()
                Dataret.DataTable1.Rows(0).Item("AzDate") = Tmp_String1
                Dataret.DataTable1.Rows(0).Item("TaDate") = Tmp_String2
                Dataret.DataTable1.Rows(0).Item("City") = Tmp_Namkala
                Dataret.DataTable1.Rows(0).Item("Visitor") = Tmp_OneGroup
                Dataret.DataTable1.Rows(0).Item("Car") = Tmp_TwoGroup
                Dataret.DataTable1.Rows(0).Item("Reciver") = TmpAddress
                Dim wight As Double = 0
                Dim discount As Double = 0
                Dim cash As Double = 0
                Dim chk As Double = 0
                Dim Lend As Double = 0

                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    wight += Dataret.DataTable1.Rows(i).Item("WFactor")
                    discount += CDbl(Dataret.DataTable1.Rows(i).Item("SD_Discount").ToString.Replace("/", "."))
                    cash += CDbl(Dataret.DataTable1.Rows(i).Item("SD_cash").ToString.Replace("/", "."))
                    chk += CDbl(Dataret.DataTable1.Rows(i).Item("SD_Chk").ToString.Replace("/", "."))
                    Lend += CDbl(Dataret.DataTable1.Rows(i).Item("SD_Lend").ToString.Replace("/", "."))
                Next
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("ESWFactor") = Replace(wight, ".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("ESD_Discount") = Replace(Math.Round(discount / Dataret.DataTable1.Rows.Count, 2), ".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("ESD_cash") = Replace(Math.Round(cash / Dataret.DataTable1.Rows.Count, 2), ".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("ESD_Chk") = Replace(Math.Round(chk / Dataret.DataTable1.Rows.Count, 2), ".", "/")
                Dataret.DataTable1.Rows(Dataret.DataTable1.Rows.Count - 1).Item("ESD_Lend") = Replace(Math.Round(Lend / Dataret.DataTable1.Rows.Count, 2), ".", "/")
                Dim ret As New CRP_DelayExit
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DelayExit")
            Me.Close()
        End Try
    End Sub

    Private Sub PathPeople()
        Try
            Dim Dataret As New DataSetPathPeople
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using

            '''''''''''''''''''''''''''''
            Dim Dt As New DataTable
            Using cm As New SqlCommand("SELECT IdName,[Delay],Rate,MaxNewDate ,D_date ,Remain FROM (SELECT IdName,Define_People.Rate AS [Delay],EndData.Rate,MaxNewDate,d_date ,(MonFac -Pay ) AS Remain FROM (SELECT IdFactor,IdName,Rate,d_date ,(SELECT ((SELECT  ISNULL(SUM(Mon)- SUM(DarsadMon),0) FROM KalaFactorSell WHERE IdFactor =AllTime.IdFactor  ) +MonAdd -MonDec) As MonFac FROM  ListFactorSell WHERE ListFactorSell.IdFactor =AllTime.IdFactor) -(SELECT ISNULL(SUM(Mon)- SUM(DarsadMon),0) AS Kasri FROM KalaKasriFactor WHERE KalaKasriFactor.IdFactor =AllTime.IdFactor)-(SELECT ISNULL(SUM(KalaFactorBackSell.Mon)- SUM(KalaFactorBackSell.DarsadMon)- SUM(ListFactorBackSell.Discount)-SUM(ListFactorBackSell.MonDec)+SUM(ListFactorBackSell.MonAdd),0) As Back FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor =ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 AND IdFacSell =AllTime.IdFactor ) As MonFac ,(SELECT ISNULL(SUM(pay),0)  FROM PayLimitFrosh  WHERE IdFactor =AllTime.IdFactor  ) + (SELECT ISNULL(SUM(pay),0)  FROM AddPayLimitFrosh  WHERE IdFactor =AllTime.IdFactor   ) + (SELECT ISNULL((Discount +Cash+MonHavaleh +MonPayChk),0) FROM ListFactorSell WHERE IdFactor= AllTime.IdFactor ) As Pay ,(SELECT ISNULL(MAX(NewDate),'') FROM TimeFrosh WHERE TimeFrosh.IdFactor=AllTime.IdFactor ) As MaxNewDate FROM (SELECT Wanted_Frosh.IdFactor , Wanted_Frosh.Rate,d_date,IdName  FROM  Wanted_Frosh INNER JOIN ListFactorSell ON Wanted_Frosh.IdFactor = ListFactorSell.IdFactor ) As AllTime) As EndData INNER JOIN Define_People ON Define_People.ID =IdName )As ListDelay WHERE Remain >0", ConectionBank)
                cm.CommandTimeout = 0
                Dt.Load(cm.ExecuteReader)
                Application.DoEvents()
            End Using

            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If Dt.Rows.Count > 0 Then
                Dt.Columns("MaxNewDate").ReadOnly = False
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dt.Rows(i).Item("MaxNewDate") = CalDate(Dt.Rows(i).Item("D_date"), Dt.Rows(i).Item("Rate"), Dt.Rows(i).Item("MaxNewDate"))
                    Dt.Rows(i).Item("Rate") = SUBDAY(Dt.Rows(i).Item("MaxNewDate"), GetDate())
                Next
                Dataret.DataTable1.Columns("DelayMon").ReadOnly = False
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    Dim row() As DataRow = Nothing
                    row = Dt.Select("IdName=" & Dataret.DataTable1.Rows(i).Item("Id") & " AND Rate<=0")
                    If row.Length > 0 Then
                        For j As Integer = 0 To row.Length - 1
                            Dataret.DataTable1.Rows(i).Item("DelayMon") += row(j).Item("Remain")
                        Next
                    Else
                        Dataret.DataTable1.Rows(i).Item("DelayMon") = 0
                    End If
                Next

            End If
            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dataret.DataTable1.Rows(0).Item("PrintDat") = GetDate()
                Dataret.DataTable1.Rows(0).Item("Comp") = GetNamCompany()
                Dataret.DataTable1.Rows(0).Item("Dat1") = Tmp_String1
                Dataret.DataTable1.Rows(0).Item("Dat2") = Tmp_String2
                Dataret.DataTable1.Rows(0).Item("Path") = Tmp_Namkala
                Dataret.DataTable1.Rows(0).Item("Visitor") = Tmp_OneGroup

                Dim ret As New CRP_PathPeople
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            Else
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "PathPeople")
            Me.Close()
        End Try
    End Sub

    Private Sub Barcode()
        Try
            Dim Dataret As New DataSetDelay
            For i As Integer = 0 To ListODarsad.Length - 1
                Dataret.DataTable1.AddDataTable1Row(0, ListODarsad(i).Group, ListODarsad(i).Darsad, "", "", "", 0, 0, "", 0, "", "", "", 0, "", 0, 0, 0, "", "")
            Next
            '''''''''''''''''''''''''''''
            If UCase(CHoose) = "BARCODE8" Then
                Dim ret As New CRP_BarCode8
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "BARCODE10" Then
                Dim ret As New CRP_BarCode10
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "BARCODE12" Then
                Dim ret As New CRP_BarCode12
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "BARCODE14" Then
                Dim ret As New CRP_BarCode14
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "BARCODE16" Then
                Dim ret As New CRP_BarCode16
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(Dataret)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Barcode")
            Me.Close()
        End Try
    End Sub

    Private Sub GoalVisitor()
        Try
            Dim dt As New DataTable
            Dim Dataret As New DataSetGoalFrosh
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            dt.Clear()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            Dim Kind As String = ""
            If UCase(CHoose) = "GOALONE" Or UCase(CHoose) = "GOALONE_HAJM" Or UCase(CHoose) = "GOALONE_MON" Or UCase(CHoose) = "GOALONE_G" Or UCase(CHoose) = "GOALONE_G_HAJM" Or UCase(CHoose) = "GOALONE_G_MON" Then
                Kind = "گزارش فروش هدف-گروه اصلی"
            ElseIf UCase(CHoose) = "GOALTWO" Or UCase(CHoose) = "GOALTWO_HAJM" Or UCase(CHoose) = "GOALTWO_MON" Or UCase(CHoose) = "GOALTWO_G" Or UCase(CHoose) = "GOALTWO_G_HAJM" Or UCase(CHoose) = "GOALTWO_G_MON" Then
                Kind = "گزارش فروش هدف-گروه فرعی"
            ElseIf UCase(CHoose) = "GOALKALA" Or UCase(CHoose) = "GOALKALA_HAJM" Or UCase(CHoose) = "GOALKALA_MON" Or UCase(CHoose) = "GOALKALA_G" Or UCase(CHoose) = "GOALKALA_G_HAJM" Or UCase(CHoose) = "GOALKALA_G_MON" Then
                Kind = "گزارش فروش هدف-کالا"
            End If
            Dataret.DataTable2.AddDataTable2Row("", "", "", "", If(dt.Rows(0).Item("MonFrosh") Is DBNull.Value, 0, dt.Rows(0).Item("MonFrosh")), Replace(dt.Rows(0).Item("KolFrosh"), ".", "/"), If(dt.Rows(0).Item("MonBack") Is DBNull.Value, 0, dt.Rows(0).Item("MonBack")), Replace(dt.Rows(0).Item("KolBack"), ".", "/"), If(dt.Rows(0).Item("MonKasri") Is DBNull.Value, 0, dt.Rows(0).Item("MonKasri")), Replace(dt.Rows(0).Item("KolKari"), ".", "/"), If(dt.Rows(0).Item("EndMon") Is DBNull.Value, 0, dt.Rows(0).Item("EndMon")), Replace(dt.Rows(0).Item("EndKol"), ".", "/"), If(dt.Rows(0).Item("Discount") Is DBNull.Value, 0, dt.Rows(0).Item("Discount")), GetDate, "نام ویزیتور : " & Tmp_Namkala & If(String.IsNullOrEmpty(Str1) And String.IsNullOrEmpty(State), "", "               محدودیت زمانی : " & If(String.IsNullOrEmpty(Str1), "", " از تاریخ:" & Str1) & If(String.IsNullOrEmpty(State), "", " تا تاریخ:" & State)), Kind, If(dt.Rows(0).Item("FixMon") Is DBNull.Value, 0, dt.Rows(0).Item("FixMon")), 0)
            '''''''''''''''''''''''''''''
            dt.Columns.Clear()
            dt.Clear()
            Using cmd As New SqlCommand(Lend, ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dataret.DataTable1.AddDataTable1Row(dt.Rows(i).Item("GroupKala"), If(dt.Rows(i).Item("Mon") Is DBNull.Value, 0, dt.Rows(i).Item("Mon")), Replace(dt.Rows(i).Item("Kala"), ".", "/"), If(UCase(CHoose) = "GOALONE" Or UCase(CHoose) = "GOALONE_HAJM" Or UCase(CHoose) = "GOALONE_MON" Or UCase(CHoose) = "GOALTWO" Or UCase(CHoose) = "GOALTWO_HAJM" Or UCase(CHoose) = "GOALTWO_MON" Or UCase(CHoose) = "GOALKALA" Or UCase(CHoose) = "GOALKALA_HAJM" Or UCase(CHoose) = "GOALKALA_MON", dt.Rows(i).Item("GroupNam"), ""), If(dt.Rows(i).Item("FroshK") Is DBNull.Value, 0, dt.Rows(i).Item("FroshK")), Replace(dt.Rows(i).Item("KolCountK"), ".", "/"), Replace(dt.Rows(i).Item("DarsadFrosh"), ".", "/"), Replace(dt.Rows(i).Item("DarsadPorsant"), ".", "/"), If(dt.Rows(i).Item("MonPorsant") Is DBNull.Value, 0, dt.Rows(i).Item("MonPorsant")))
                Next
            End If
            '''''''''''''''''''''''''''''
            dt.Columns.Clear()
            dt.Clear()
            Using cmd As New SqlCommand(IdFactor, ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dataret.DataTable1.AddDataTable1Row("", 0, "0", If(UCase(CHoose) = "GOALONE" Or UCase(CHoose) = "GOALONE_HAJM" Or UCase(CHoose) = "GOALONE_MON" Or UCase(CHoose) = "GOALTWO" Or UCase(CHoose) = "GOALTWO_HAJM" Or UCase(CHoose) = "GOALTWO_MON" Or UCase(CHoose) = "GOALKALA" Or UCase(CHoose) = "GOALKALA_HAJM" Or UCase(CHoose) = "GOALKALA_MON", dt.Rows(i).Item("Nam"), "سایر گروهها"), If(dt.Rows(i).Item("FroshK") Is DBNull.Value, 0, dt.Rows(i).Item("FroshK")), If(dt.Rows(i).Item("KolCountK") Is DBNull.Value, "0", Replace(dt.Rows(i).Item("KolCountK"), ".", "/")), "-", If(dt.Rows(i).Item("Darsad") Is DBNull.Value, "0", Replace(dt.Rows(i).Item("Darsad"), ".", "/")), If(dt.Rows(i).Item("Porsant") Is DBNull.Value, 0, dt.Rows(i).Item("Porsant")))
                Next
            End If
            '''''''''''''''''''''''''''''
            Dim DRet As New DataSetGoalFrosh
            If Str2 = "1" Then
                Dim row() As DataRow = Nothing
                row = Dataret.DataTable1.Select("MonPorsant>0")
                For i As Integer = 0 To row.Length - 1
                    DRet.DataTable1.ImportRow(row(i))
                Next

                Dim row1() As DataRow = Nothing
                row1 = Dataret.DataTable2.Select("Kind<>''")
                For i As Integer = 0 To row1.Length - 1
                    DRet.DataTable2.ImportRow(row1(i))
                Next
            Else
                DRet = Dataret
            End If

            Dim Kala As Double = 0
            Dim KolCountK As Double = 0
            Dim DarsadFrosh As Double = 0
            Dim DarsadPorsant As Double = 0
            Dim MonPorsant As Double = 0

            For i As Integer = 0 To DRet.DataTable1.Rows.Count - 1
                Kala += If(DRet.DataTable1.Rows(i).Item("Kala").Equals("") Or DRet.DataTable1.Rows(i).Item("Kala").Equals("-"), 0, CDbl(Replace(DRet.DataTable1.Rows(i).Item("Kala"), ".", "/")))
                KolCountK += If(DRet.DataTable1.Rows(i).Item("KolCountK").Equals("") Or DRet.DataTable1.Rows(i).Item("KolCountK").Equals("-"), 0, CDbl(Replace(DRet.DataTable1.Rows(i).Item("KolCountK"), ".", "/")))
                DarsadFrosh += If(DRet.DataTable1.Rows(i).Item("DarsadFrosh").Equals("") Or DRet.DataTable1.Rows(i).Item("DarsadFrosh").Equals("-"), 0, CDbl(Replace(DRet.DataTable1.Rows(i).Item("DarsadFrosh"), ".", "/")))
                DarsadPorsant += If(DRet.DataTable1.Rows(i).Item("DarsadPorsant").Equals("") Or DRet.DataTable1.Rows(i).Item("DarsadPorsant").Equals("-"), 0, CDbl(Replace(DRet.DataTable1.Rows(i).Item("DarsadPorsant"), ".", "/")))
                MonPorsant += If(DRet.DataTable1.Rows(i).Item("MonPorsant") Is DBNull.Value, 0, DRet.DataTable1.Rows(i).Item("MonPorsant"))
            Next
            DRet.DataTable2.Rows(0).Item("EndKala") = Replace(Kala, ".", "/")
            DRet.DataTable2.Rows(0).Item("EndKolCountK") = Replace(KolCountK, ".", "/")
            DRet.DataTable2.Rows(0).Item("EndDarsadFrosh") = Replace(Math.Round(DarsadFrosh / DRet.DataTable1.Rows.Count, 2), ".", "/")
            DRet.DataTable2.Rows(0).Item("EndDarsadPorsant") = Replace(Math.Round(DarsadPorsant / DRet.DataTable1.Rows.Count, 2), ".", "/")
            DRet.DataTable2.Rows(0).Item("AllEndMon") = MonPorsant + DRet.DataTable2.Rows(0).Item("FixMon")
            '''''''''''''''''''''''''''''
            If UCase(CHoose) = "GOALONE" Then
                Dim ret As New CRP_Goal_Two
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALTWO" Then
                Dim ret As New CRP_Goal_Two
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALKALA" Then
                Dim ret As New CRP_Goal_Two
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALONE_G" Then
                Dim ret As New CRP_Goal_Two_G
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALTWO_G" Then
                Dim ret As New CRP_Goal_Two_G
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALKALA_G" Then
                Dim ret As New CRP_Goal_Two_G
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALONE_HAJM" Then
                Dim ret As New CRP_Goal_Two_Hajm
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALONE_MON" Then
                Dim ret As New CRP_Goal_Two_Mon
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALONE_G_HAJM" Then
                Dim ret As New CRP_Goal_Two_G_Hajm
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALONE_G_MON" Then
                Dim ret As New CRP_Goal_Two_G_Mon
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALTWO_HAJM" Then
                Dim ret As New CRP_Goal_Two_Hajm
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALTWO_MON" Then
                Dim ret As New CRP_Goal_Two_Mon
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALTWO_G_HAJM" Then
                Dim ret As New CRP_Goal_Two_G_Hajm
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALTWO_G_MON" Then
                Dim ret As New CRP_Goal_Two_G_Mon
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALKALA_HAJM" Then
                Dim ret As New CRP_Goal_Two_Hajm
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALKALA_MON" Then
                Dim ret As New CRP_Goal_Two_Mon
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALKALA_G_HAJM" Then
                Dim ret As New CRP_Goal_Two_G_Hajm
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "GOALKALA_G_MON" Then
                Dim ret As New CRP_Goal_Two_G_Mon
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DRet)
                Me.CRV.ReportSource = ret
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False

            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "GoalVisitor")
            Me.Close()
        End Try
    End Sub

    Private Sub EndSarmayeh()
        Try
            Dim Dataret As New DataSetEndSarmayeh
            For i As Integer = 0 To DtS.Rows.Count - 1
                Dataret.DataTable1.AddDataTable1Row(DtS.Rows(i).Item("Nam"), GetDate(), DtS.Rows(i).Item("OneMoney"), DtS.Rows(i).Item("BedMon"), DtS.Rows(i).Item("BesMon"), DtS.Rows(i).Item("OneSod"), DtS.Rows(i).Item("SumSod"), DtS.Rows(i).Item("EndSod"))
            Next
            '''''''''''''''''''''''''''''
            Dim ret As New CRP_EndSarmayeh
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "EndSarmayeh")
            Me.Close()
        End Try
    End Sub

    Private Sub Discount()
        Try
            If Not DtDiscount.Columns.Contains("Disc") Then DtDiscount.Columns.Add("Disc", Type.GetType("System.String"))
            If Not DtDiscount.Columns.Contains("BedMon") Then DtDiscount.Columns.Add("BedMon", Type.GetType("System.Double"))
            If Not DtDiscount.Columns.Contains("BesMon") Then DtDiscount.Columns.Add("BesMon", Type.GetType("System.Double"))
            If Not DtDiscount.Columns.Contains("Dat1") Then DtDiscount.Columns.Add("Dat1", Type.GetType("System.String"))
            If Not DtDiscount.Columns.Contains("Dat2") Then DtDiscount.Columns.Add("Dat2", Type.GetType("System.String"))
            If Not DtDiscount.Columns.Contains("PrintDat") Then DtDiscount.Columns.Add("PrintDat", Type.GetType("System.String"))
            '''''''''''''''''''''''''''''''''''''
            DtDiscount.Rows(0).Item("PrintDat") = GetDate()
            DtDiscount.Rows(0).Item("Dat1") = Tmp_OneGroup
            DtDiscount.Rows(0).Item("Dat2") = Tmp_TwoGroup

            If UCase(CHoose) = "DISCOUNT" Then
                Dim ret As New CRP_Report_Discount
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DtDiscount)
                CRV.ReportSource = ret
            ElseIf UCase(CHoose) = "DISCOUNTALL" Then
                Dim ret As New CRP_Report_DiscountAll
                ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                Application.DoEvents()
                ret.SetDataSource(DtDiscount)
                CRV.ReportSource = ret
            End If

            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Discount")
            Me.Close()
        End Try
    End Sub

    Private Sub DelayAll()
        Try
            If Not DtMoeinBox.Columns.Contains("PrintDat") Then DtMoeinBox.Columns.Add("PrintDat", Type.GetType("System.String"))
            Dim dv As DataView = DtMoeinBox.DefaultView
            If Lend = "RDOP" Then
                dv.Sort = "Disc"
            ElseIf Lend = "RDOM" Then
                dv.Sort = "BesMon"
            End If
            dv.Item(0).Item("PrintDat") = GetDate()
            Dim ret As New CRP_DelayPeople
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(dv)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "DelayAll")
            Me.Close()
        End Try
    End Sub

    Private Sub Delay()
        Try
            If Not DtMoeinBox.Columns.Contains("PrintDat") Then DtMoeinBox.Columns.Add("PrintDat", Type.GetType("System.String"))
            DtMoeinBox.Rows(0).Item("PrintDat") = GetDate()
            Dim dv As DataView = DtMoeinBox.DefaultView
            If Lend = "RDOP" Then
                dv.Sort = "Disc"
            ElseIf Lend = "RDOM" Then
                dv.Sort = "Mandeh"
            ElseIf Lend = "RDOC" Then
                dv.Sort = "EndMandeh"
            End If
            dv.Item(0).Item("PrintDat") = GetDate()
            Dim ret As New CRP_DelayPeople2
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(dv)
            CRV.ReportSource = ret
            Application.DoEvents()
            FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "Delay")
            Me.Close()
        End Try
    End Sub

    Private Sub PrintListFactor()
        Try
            Dim Dataret As New DataSetControlFactor

            For i As Integer = 0 To ListFactor.Length - 1
                Dataret.DataTable1.AddDataTable1Row(ListFactor(i).IdFactor, ListFactor(i).Nam, ListFactor(i).NamCi, ListFactor(i).MonFac, GetDate(), 0, ListFactor(i).D_date, 0, ListFactor(i).Discount, ListFactor(i).AllMonFac, 0, "", "", "", "", "", 0, ListFactor(i).Discount1, ListFactor(i).Cash, ListFactor(i).Chk, ListFactor(i).Kasri, 0, "", "", "", "", ListFactor(i).Lend, "", ListFactor(i).IdExit, "", "")
            Next

            Dim ret As New CRP_ListFactor
            ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            Application.DoEvents()
            ret.SetDataSource(Dataret)
            Me.CRV.ReportSource = ret
            Application.DoEvents()
            Me.FormatReportViewer()
            Application.DoEvents()
            Pic1.Visible = False

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "PrintListFactor")
            Me.Close()
        End Try
    End Sub

    Private Sub RateFactor()
        Try
            Dim Dataret As New DataSetRateFactor
            Dataret.Clear()

            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(PrintSQl, ConectionBank)
                cmd.CommandTimeout = 0
                Dataret.DataTable1.Load(cmd.ExecuteReader)
                Application.DoEvents()
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            '''''''''''''''''''''''''''''
            If Dataret.DataTable1.Rows.Count > 0 Then
                Dim rate As Double = 0
                For i As Integer = 0 To Dataret.DataTable1.Rows.Count - 1
                    If String.IsNullOrEmpty(Dataret.DataTable1.Rows(i).Item("EndDate")) Then
                        rate = Math.Round(SUBDAY(GetDate, Dataret.DataTable1.Rows(i).Item("D_date")), 2)
                        Dataret.DataTable1.Rows(i).Item("CRasRate") = If(rate = 0, 1, rate).ToString.Replace(".", "/")
                        Dataret.DataTable1.Rows(i).Item("TRas") = CDbl(Dataret.DataTable1.Rows(i).Item("CRasRate").ToString.Replace("/", "."))
                    Else
                        Dim BigMon As Double = 0
                        Dim SmallMon As Double = 0

                        Dim str() As String = Dataret.DataTable1.Rows(i).Item("RasRate").ToString.Split(";")
                        For j As Integer = 0 To str.Length - 1
                            If Not (String.IsNullOrEmpty(str(j))) Then
                                Dim lstr() As String = str(j).Split(",")
                                SmallMon += lstr(1)
                                rate = SUBDAY(lstr(0), Dataret.DataTable1.Rows(i).Item("D_date"))
                                BigMon += lstr(1) * If(rate = 0, 1, rate)
                            End If
                        Next

                        rate = Math.Round(BigMon / If(SmallMon = 0, BigMon, SmallMon), 2)
                        Dataret.DataTable1.Rows(i).Item("CRasRate") = If(rate = 0, 1, rate).ToString.Replace(".", "/")
                        Dataret.DataTable1.Rows(i).Item("TRas") = CDbl(Dataret.DataTable1.Rows(i).Item("CRasRate").ToString.Replace("/", "."))
                    End If
                Next

                dv = Dataret.DataTable1.DefaultView
                dv.RowFilter = TmpTell1
                If dv.Count <= 0 Then
                    MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    If UCase(CHoose) = "RATEFACTORVISITOR" Then
                        Array.Resize(ListRateKala, 0)
                        Dim flag As Boolean = False
                        For i As Integer = 0 To dv.Count - 1
                            For j As Integer = 0 To ListRateKala.Length - 1
                                If ListRateKala(j).IdVisitor = If(dv.Item(i).Item("IdVisitor") Is DBNull.Value, 0, dv.Item(i).Item("IdVisitor")) Then
                                    ListRateKala(j).IdFactor += 1
                                    ListRateKala(j).Mon += dv.Item(i).Item("Mon")
                                    ListRateKala(j).CountRate += dv.Item(i).Item("CountRate")
                                    ListRateKala(j).RasFactor += dv.Item(i).Item("TRas")
                                    flag = True
                                    Exit For
                                End If
                                flag = False
                            Next
                            If flag = False Then
                                Array.Resize(ListRateKala, ListRateKala.Length + 1)
                                ListRateKala(ListRateKala.Length - 1).IdVisitor = If(dv.Item(i).Item("IdVisitor") Is DBNull.Value, 0, dv.Item(i).Item("IdVisitor"))
                                ListRateKala(ListRateKala.Length - 1).Nam = dv.Item(i).Item("NamV")
                                ListRateKala(ListRateKala.Length - 1).IdFactor = 1
                                ListRateKala(ListRateKala.Length - 1).CountRate = dv.Item(i).Item("CountRate")
                                ListRateKala(ListRateKala.Length - 1).Mon = dv.Item(i).Item("Mon")
                                ListRateKala(ListRateKala.Length - 1).RasFactor = dv.Item(i).Item("TRas")
                            End If
                        Next
                        Dataret.Clear()
                        For i As Integer = 0 To ListRateKala.Length - 1
                            Dataret.DataTable1.AddDataTable1Row("", "", "", "", "", "", ListRateKala(i).IdFactor, ListRateKala(i).Nam, ListRateKala(i).Mon, "", "", ListRateKala(i).CountRate, ListRateKala(i).RasFactor, Math.Round(ListRateKala(i).RasFactor / ListRateKala(i).IdFactor, 2).ToString.Replace(".", "/"), "", "", Math.Round(ListRateKala(i).RasFactor / ListRateKala(i).IdFactor, 2), ListRateKala(i).IdVisitor, ListRateKala(i).IdUser, "", "")
                        Next
                        dv = Nothing
                        dv = Dataret.DataTable1.DefaultView
                    End If

                    If UCase(CHoose) = "RATEFACTORUSER" Then
                        Array.Resize(ListRateKala, 0)
                        Dim flag As Boolean = False
                        For i As Integer = 0 To dv.Count - 1
                            For j As Integer = 0 To ListRateKala.Length - 1
                                If ListRateKala(j).IdVisitor = If(dv.Item(i).Item("IdUser") Is DBNull.Value, 0, dv.Item(i).Item("IdUser")) Then
                                    ListRateKala(j).IdFactor += 1
                                    ListRateKala(j).Mon += dv.Item(i).Item("Mon")
                                    ListRateKala(j).CountRate += dv.Item(i).Item("CountRate")
                                    ListRateKala(j).RasFactor += dv.Item(i).Item("TRas")
                                    flag = True
                                    Exit For
                                End If
                                flag = False
                            Next
                            If flag = False Then
                                Array.Resize(ListRateKala, ListRateKala.Length + 1)
                                ListRateKala(ListRateKala.Length - 1).IdVisitor = If(dv.Item(i).Item("IdUser") Is DBNull.Value, 0, dv.Item(i).Item("IdUser"))
                                ListRateKala(ListRateKala.Length - 1).Nam = dv.Item(i).Item("NamU")
                                ListRateKala(ListRateKala.Length - 1).IdFactor = 1
                                ListRateKala(ListRateKala.Length - 1).CountRate = dv.Item(i).Item("CountRate")
                                ListRateKala(ListRateKala.Length - 1).Mon = dv.Item(i).Item("Mon")
                                ListRateKala(ListRateKala.Length - 1).RasFactor = dv.Item(i).Item("TRas")
                            End If
                        Next
                        Dataret.Clear()
                        For i As Integer = 0 To ListRateKala.Length - 1
                            Dataret.DataTable1.AddDataTable1Row("", "", "", "", "", "", ListRateKala(i).IdFactor, ListRateKala(i).Nam, ListRateKala(i).Mon, "", "", ListRateKala(i).CountRate, ListRateKala(i).RasFactor, Math.Round(ListRateKala(i).RasFactor / ListRateKala(i).IdFactor, 2).ToString.Replace(".", "/"), "", "", Math.Round(ListRateKala(i).RasFactor / ListRateKala(i).IdFactor, 2), ListRateKala(i).IdVisitor, ListRateKala(i).IdUser, "", "")
                        Next
                        dv = Nothing
                        dv = Dataret.DataTable1.DefaultView
                    End If


                    dv.Sort = TmpGroupName
                    dv.Item(0).Item("PrintDate") = GetDate()
                    dv.Item(0).Item("User") = TmpAddress
                    dv.Item(0).Item("Visitor") = Tmp_TwoGroup
                    dv.Item(0).Item("GroupKala") = Tmp_OneGroup
                    dv.Item(0).Item("NamKala") = Tmp_Namkala
                    dv.Item(0).Item("Dat1") = Tmp_String1
                    dv.Item(0).Item("Dat2") = Tmp_String2

                    If UCase(CHoose) = "RATEFACTOR" Then
                        Dim ret As New CRP_TraceRate
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(dv)
                        Me.CRV.ReportSource = ret
                    ElseIf UCase(CHoose) = "RATEFACTORVISITOR" Or UCase(CHoose) = "RATEFACTORUSER" Then
                        Dim ret As New CRP_TraceRate2
                        ret.PrintOptions.PaperSize = Printing.PaperKind.A4
                        Application.DoEvents()
                        ret.SetDataSource(dv)
                        Me.CRV.ReportSource = ret
                    End If

                    Application.DoEvents()
                    Me.FormatReportViewer()
                    Application.DoEvents()
                    Pic1.Visible = False
                    End If
            Else
                    MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "RateFactor")
            Me.Close()
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

    Private Sub FrmPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Pic1.Visible = True

            If UCase(CHoose) = "TRAZ" Then
                Traz()
            ElseIf UCase(CHoose) = "SODORCHK" Then
                SodorChk()
            ElseIf UCase(CHoose) = "FACTOR" Then
                Factor()
            ElseIf UCase(CHoose) = "RESEIDANBAR" Then
                ResedAnbar()
            ElseIf UCase(CHoose) = "DAFTARKOL" Then
                DaftarKol()
            ElseIf UCase(CHoose) = "MOEINPEOPLE" Then
                MoeinPeople()
            ElseIf UCase(CHoose) = "MOEINKALAPEOPLE" Then
                MoeinKalaPeople()
            ElseIf UCase(CHoose) = "MOEINBOX" Then
                MoeinBox()
            ElseIf UCase(CHoose) = "MOEINBANK" Then
                MoeinBank()
            ElseIf UCase(CHoose) = "MOJODYKALA" Then
                MojodyKala()
            ElseIf UCase(CHoose) = "MOJODYANBAR" Then
                MojodyKalaAnbar()
            ElseIf UCase(CHoose) = "KARDEXKALA" Then
                KardexKala()
            ElseIf UCase(CHoose) = "KARDEXANBAR" Then
                KardexAnbar()
            ElseIf UCase(CHoose) = "MOJODYMONEYKALA" Then
                MojodyMoneyKala()
            ElseIf UCase(CHoose) = "MOJODYMONEYANBAR" Then
                MojodyMoneyAnbar()
            ElseIf UCase(CHoose) = "CHKPRINT" Then
                ChkPrint()
            ElseIf UCase(CHoose) = "CHKONEPRINT" Then
                ChkOnePrint()
            ElseIf UCase(CHoose) = "NSOD1" Then
                NSODALL()
            ElseIf UCase(CHoose) = "NSOD2" Then
                NSODALL2()
            ElseIf UCase(CHoose) = "RESEDGETPAY" Then
                Getpay()
            ElseIf UCase(CHoose) = "RESEDPTP" Then
                PTP()
            ElseIf UCase(CHoose) = "CHARGE" Or UCase(CHoose) = "DARAMAD" Then
                Charge()
            ElseIf UCase(CHoose) = "SUMCHARGE" Or UCase(CHoose) = "SUMDARAMAD" Then
                SumCharge()
            ElseIf UCase(CHoose) = "MOJODYBANK" Then
                MojodyBank()
            ElseIf UCase(CHoose) = "MOJODYBOX" Then
                MojodyBox()
            ElseIf UCase(CHoose) = "STATECHK" Then
                StateChk()
            ElseIf UCase(CHoose) = "LOWMOJODY" Or UCase(CHoose) = "HIGHTMOJODY" Then
                Low_Hight_Mojody()
            ElseIf UCase(CHoose) = "REPORTBUY" Or UCase(CHoose) = "REPORTABUY" Or UCase(CHoose) = "REPORTSELL" Or UCase(CHoose) = "REPORTASELL" Or UCase(CHoose) = "REPORTBACKBUY" Or UCase(CHoose) = "REPORTBACKSELL" Then
                BuySell()
            ElseIf UCase(CHoose) = "SUMREPORTBUY" Or UCase(CHoose) = "SUMREPORTABUY" Or UCase(CHoose) = "SUMREPORTSELL" Or UCase(CHoose) = "SUMREPORTASELL" Or UCase(CHoose) = "SUMREPORTBACKBUY" Or UCase(CHoose) = "SUMREPORTBACKSELL" Or UCase(CHoose) = "SUMREPORTBUYKALA" Or UCase(CHoose) = "SUMREPORTABUYKALA" Or UCase(CHoose) = "SUMREPORTSELLKALA" Or UCase(CHoose) = "SUMREPORTASELLKALA" Or UCase(CHoose) = "SUMREPORTBACKBUYKALA" Or UCase(CHoose) = "SUMREPORTBACKSELLKALA" Or UCase(CHoose) = "SUMREPORTBACKSELLGROUP" Or UCase(CHoose) = "SUMREPORTBUYGROUP" Or UCase(CHoose) = "SUMREPORTABUYGROUP" Or UCase(CHoose) = "SUMREPORTSELLGROUP" Or UCase(CHoose) = "SUMREPORTASELLGROUP" Or UCase(CHoose) = "SUMREPORTBACKBUYGROUP" Or UCase(CHoose) = "SUMREPORTBACKSELLGROUP" Or UCase(CHoose) = "SUMREPORTSELLPGROUP" Or UCase(CHoose) = "SUMREPORTASELLPGROUP" Or UCase(CHoose) = "SUMREPORTBUYPGROUP" Or UCase(CHoose) = "SUMREPORTABUYPGROUP" Or UCase(CHoose) = "SUMREPORTBACKBUYPGROUP" Or UCase(CHoose) = "SUMREPORTBACKSELLPGROUP" Then
                SUMBuySell()
            ElseIf UCase(CHoose) = "REPORTSERVICE" Then
                ReportService()
            ElseIf UCase(CHoose) = "SUMREPORTSERVICE" Then
                ReportSUMService()
            ElseIf UCase(CHoose) = "REPORTDAMAGE" Then
                ReportDamage()
            ElseIf UCase(CHoose) = "SUMREPORTDAMAGE" Then
                ReportSUMDamage()
            ElseIf UCase(CHoose) = "CONTROLFACTOR" Or UCase(CHoose) = "CONTROLFACTOR2" Then
                ReportControlFactor()
            ElseIf UCase(CHoose) = "BALANCEKALA" Or UCase(CHoose) = "BALANCEKALAORDER" Then
                BalanceKala()
            ElseIf UCase(CHoose) = "FROSHUSER1" Or UCase(CHoose) = "FROSHVISIT1" Then
                FroshUser()
            ElseIf UCase(CHoose) = "FROSHUSER2" Or UCase(CHoose) = "FROSHUSER3" Or UCase(CHoose) = "FROSHUSER4" Or UCase(CHoose) = "FROSHUSER5" Or UCase(CHoose) = "FROSHVISIT2" Or UCase(CHoose) = "FROSHVISIT3" Or UCase(CHoose) = "FROSHVISIT4" Or UCase(CHoose) = "FROSHVISIT5" Then
                FroshUser2()
            ElseIf UCase(CHoose) = "SARMAYEH" Or UCase(CHoose) = "SUMSARMAYEH" Or UCase(CHoose) = "AMVAL" Or UCase(CHoose) = "SUMAMVAL" Then
                Sarmayeh_Amval()
            ElseIf UCase(CHoose) = "SUMFACTOR" Or UCase(CHoose) = "SUMFACTOR2" Then
                SumKalaFactor()
            ElseIf UCase(CHoose) = "DELAYPRINT" Or UCase(CHoose) = "DELAYPRINT2" Then
                DelayPrint()
            ElseIf UCase(CHoose) = "SODKHALES" Then
                SOD()
            ElseIf UCase(CHoose) = "TRANSALTEANBAR" Then
                TranslateAnbar()
            ElseIf UCase(CHoose) = "SODPRINT1" Or UCase(CHoose) = "SODPRINT2" Then
                SodFactor()
            ElseIf UCase(CHoose) = "SODPRINT3" Or UCase(CHoose) = "SODPRINT3_1" Then
                SodFactor2()
            ElseIf UCase(CHoose) = "REPORTGETCHK" Or UCase(CHoose) = "REPORTPAYCHK" Then
                ReportChk()
            ElseIf UCase(CHoose) = "REPORTBRATCHK" Then
                ReportBratChk()
            ElseIf UCase(CHoose) = "TRAZTWO" Or UCase(CHoose) = "TRAZEND" Then
                TrazTwo()
            ElseIf UCase(CHoose) = "ENDSELL" Or UCase(CHoose) = "NOENDSELL" Then
                DelaySell()
            ElseIf UCase(CHoose) = "DAFTARDAY" Then
                DaftarDay()
            ElseIf UCase(CHoose) = "LISTCOSTKALA" Or UCase(CHoose) = "LISTCOSTKALANF" Or UCase(CHoose) = "LISTCOSTKALAALL" Or UCase(CHoose) = "LISTCOSTKALAALL2" Or UCase(CHoose) = "LISTCOSTKALAMARGIN" Or UCase(CHoose) = "LISTBUYSELLKALA" Or UCase(CHoose) = "LISTPROMOTIONKALA" Then
                ReportListCostKala()
            ElseIf UCase(CHoose) = "FROSHALLUSER" Then
                FroshAllUser()
            ElseIf UCase(CHoose) = "FROSHALLVISITOR" Then
                FroshAllVisitor()
            ElseIf UCase(CHoose) = "LISTPEOPLE" Then
                ListPeople()
            ElseIf UCase(CHoose) = "TRAZ4" Or UCase(CHoose) = "TRAZ2" Then
                Traz_2_4()
            ElseIf UCase(CHoose) = "DARSADRISK" Then
                DarsadRisk()
            ElseIf UCase(CHoose) = "KALAONE" Then
                MojodyOneAnbar()
            ElseIf UCase(CHoose) = "SCOST" Then
                SCost()
            ElseIf UCase(CHoose) = "DELAYEXIT" Then
                DelayExit()
            ElseIf UCase(CHoose) = "PATHPEOPLE" Then
                Me.PathPeople()
            ElseIf UCase(CHoose) = "SODBANK" Then
                Application.DoEvents()
                Me.FormatReportViewer()
                Application.DoEvents()
                Pic1.Visible = False
            ElseIf UCase(CHoose) = "BARCODE8" Or UCase(CHoose) = "BARCODE10" Or UCase(CHoose) = "BARCODE12" Or UCase(CHoose) = "BARCODE14" Or UCase(CHoose) = "BARCODE16" Then
                Me.Barcode()
            ElseIf UCase(CHoose) = "GOALONE" Or UCase(CHoose) = "GOALONE_HAJM" Or UCase(CHoose) = "GOALONE_MON" Or UCase(CHoose) = "GOALONE_G" Or UCase(CHoose) = "GOALONE_G_HAJM" Or UCase(CHoose) = "GOALONE_G_MON" Or UCase(CHoose) = "GOALTWO" Or UCase(CHoose) = "GOALTWO_HAJM" Or UCase(CHoose) = "GOALTWO_MON" Or UCase(CHoose) = "GOALTWO_G" Or UCase(CHoose) = "GOALTWO_G_HAJM" Or UCase(CHoose) = "GOALTWO_G_MON" Or UCase(CHoose) = "GOALKALA" Or UCase(CHoose) = "GOALKALA_HAJM" Or UCase(CHoose) = "GOALKALA_MON" Or UCase(CHoose) = "GOALKALA_G" Or UCase(CHoose) = "GOALKALA_G_HAJM" Or UCase(CHoose) = "GOALKALA_G_MON" Then
                GoalVisitor()
            ElseIf UCase(CHoose) = "RESEDDARAMAD" Then
                Me.Daramad()
            ElseIf UCase(CHoose) = "RESEDKHARIDCHARGE" Then
                Me.KharidCharge()
            ElseIf UCase(CHoose) = "RESEDOTHERCHARGE" Then
                Me.OtherCharge()
            ElseIf UCase(CHoose) = "CHART-DAYCHARGE" Or UCase(CHoose) = "CHART-WEEKCHARGE" Or UCase(CHoose) = "CHART-MONTHCHARGE" Or UCase(CHoose) = "CHART-CHARGE" Then
                Me.ChartDayCharge()
            ElseIf UCase(CHoose) = "ENDSARMAYEH" Then
                Me.EndSarmayeh()
            ElseIf UCase(CHoose) = "CHARTFROSH-OSTAN" Then
                Me.ChartFrosh()
            ElseIf UCase(CHoose) = "FROSHSTATEVISITOR" Then
                Me.FroshStateVisitor()
            ElseIf UCase(CHoose) = "FROSHSTATEUSER" Then
                FroshStateUser()
            ElseIf UCase(CHoose) = "DISCOUNT" Or UCase(CHoose) = "DISCOUNTALL" Then
                Me.Discount()
            ElseIf UCase(CHoose) = "DELAY-ALL" Then
                Me.DelayAll()
            ElseIf UCase(CHoose) = "DELAY" Then
                Me.Delay()
            ElseIf UCase(CHoose) = "LISTFACTOR" Then
                Me.PrintListFactor()
            ElseIf UCase(CHoose) = "RATEFACTOR" Or UCase(CHoose) = "RATEFACTORUSER" Or UCase(CHoose) = "RATEFACTORVISITOR" Then
                Me.RateFactor()
            ElseIf UCase(CHoose) = "BALANCEKALAORDERM" Then
                Me.BalanceKalaM()
            End If
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmPrint", "FrmPrint_Load")
            Me.Close()
        End Try
    End Sub
    Private Sub FormatReportViewer()
        Try
            Dim thisObj As Object
            Dim MyPageView As CrystalDecisions.Windows.Forms.PageView
            Dim tcontrol As TabControl
            For Each thisObj In CRV.Controls
                Select Case UCase(thisObj.GetType.Name)
                    Case "PAGEVIEW"
                        MyPageView = CType(thisObj, CrystalDecisions.Windows.Forms.PageView)
                        tcontrol = CType(MyPageView.Controls(0), TabControl)
                        With tcontrol
                            If .TabPages.Count > 0 Then
                                With .TabPages(0)
                                    .Text = "نرم افزار حسابداری ناب"
                                End With
                            End If
                        End With
                End Select
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmPrint_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            Dim x As Long = 0
            Dim y As Long = 0
            x = Me.Width
            y = Me.Height
            Pic1.Location = New Point((x / 2) - (Pic1.Width / 2), (y / 2.5) + 60)
        Catch ex As Exception

        End Try
    End Sub
End Class