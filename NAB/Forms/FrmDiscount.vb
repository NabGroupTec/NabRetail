Imports System.Data.SqlClient
Public Class FrmDiscount

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
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

            If ChkKharid.Checked = False And ChkKharidAmani.Checked = False And ChkBackKharid.Checked = False And ChkService.Checked = False And ChkFrosh.Checked = False And ChkFroshAmani.Checked = False And ChkBackFrosh.Checked = False And ChkGet.Checked = False And ChkPay.Checked = False And ChkCharge.Checked = False Then
                MessageBox.Show("هیچ سندی انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
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

            Dim CKharid As String = ""
            Dim CBackKharid As String = ""
            Dim CKharidAmani As String = ""
            Dim CFrosh As String = ""
            Dim CBackFrosh As String = ""
            Dim CFroshAmani As String = ""
            Dim CService As String = ""
            Dim CGet As String = ""
            Dim CPay As String = ""
            Dim Charge As String = ""
            Dim add As String = ""
            Dim dec As String = ""

            Dim sql As String = ""
            If ChkGroup.Checked = True Then
                If ChkAddDec.Checked = False Then
                    CKharid = If(ChkKharid.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور خرید',ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور خرید',ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM  ListFactorBuy WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " UNION ALL ")
                    CBackKharid = If(ChkBackKharid.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور برگشت از خرید',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM  KalaFactorBackBuy  INNER JOIN ListFactorBackBuy  ON KalaFactorBackBuy .IdFactor = ListFactorBackBuy .IdFactor WHERE  ListFactorBackBuy .Activ =1 " & condition & " UNION ALL  SELECT Disc=N'تخفیفات نقدی فاکتور برگشت از خرید',BesMon=0,ISNULL(SUM(Discount),0) As BedMon FROM  ListFactorBackBuy  WHERE  ListFactorBackBuy .Activ =1 " & condition & " UNION ALL ")
                    CKharidAmani = If(ChkKharidAmani.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور خرید امانی',ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM  KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور خرید امانی',ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM  ListFactorBuy WHERE  ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL ")
                    CFrosh = If(ChkFrosh.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور فروش',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell .IdFactor = ListFactorSell .IdFactor WHERE  ListFactorSell .Activ =1 AND ListFactorSell .Stat =3 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور فروش',BesMon=0,ISNULL(SUM(Discount),0) As BedMon FROM  ListFactorSell WHERE  ListFactorSell.Activ =1 AND ListFactorSell .Stat =3 " & condition & " UNION ALL ")
                    CBackFrosh = If(ChkBackFrosh.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور برگشت از فروش',ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM  KalaFactorBackSell  INNER JOIN ListFactorBackSell  ON KalaFactorBackSell .IdFactor = ListFactorBackSell.IdFactor WHERE  ListFactorBackSell .Activ =1  " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور برگشت از فروش',ISNULL(SUM(Discount),0) AS BesMon,BedMon=0 FROM  ListFactorBackSell WHERE ListFactorBackSell.Activ =1  " & condition & " UNION ALL ")
                    CFroshAmani = If(ChkFroshAmani.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور فروش امانی',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM  KalaFactorSell  INNER JOIN ListFactorSell  ON KalaFactorSell .IdFactor = ListFactorSell .IdFactor WHERE  ListFactorSell .Activ =1 AND ListFactorSell .Stat =5 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور فروش امانی',BesMon=0,ISNULL(SUM(Discount),0) As BedMon FROM  ListFactorSell WHERE  ListFactorSell.Activ =1 AND ListFactorSell .Stat =5 " & condition & " UNION ALL ")
                    CService = If(ChkService.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور خدمات',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM  KalaFactorService  INNER JOIN ListFactorService  ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE  ListFactorService.Activ =1 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور خدمات',BesMon=0,ISNULL(SUM(Discount),0) As BedMon FROM  ListFactorService WHERE  ListFactorService.Activ =1 " & condition & " UNION ALL ")
                    CGet = If(ChkGet.Checked = False, "", "SELECT  Disc=N'تخفیفات دریافت از طرف حساب',BesMon=0,ISNULL(SUM(Discount),0) AS BedMon FROM  Get_Pay_Sanad WHERE [State] =0 AND Active =1 " & condition & " UNION ALL ")
                    CPay = If(ChkPay.Checked = False, "", "SELECT  Disc=N'تخفیفات پرداخت به طرف حساب',ISNULL(SUM(Discount),0) AS BesMon,BedMon=0 FROM  Get_Pay_Sanad WHERE [State] =1 AND Active =1 " & condition & " UNION ALL ")
                    Charge = If(ChkCharge.Checked = False, "", "SELECT Disc=N'تخفیفات هزینه فاکتور خرید',BesMon=0,ISNULL(SUM(Discount),0) As BedMon FROM ListFactorCharge WHERE Activ =1 " & condition & " UNION ALL SELECT Disc=N'تخفیفات هزینه متفرقه',BesMon=0,ISNULL(SUM(Discount),0) As BedMon FROM ListOtherCharge  WHERE Activ =1 " & condition & " UNION ALL ")
                    sql = CKharid & CKharidAmani & CBackKharid & CFrosh & CFroshAmani & CBackFrosh & CService & CGet & CPay & Charge
                    sql = sql.Substring(0, sql.Length - 10)
                Else
                    If ChkOnly.Checked = False Then
                        CKharid = If(ChkKharid.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور خرید' , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور خرید',ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBuy WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور خرید',BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور خرید',ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM  ListFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " UNION ALL ")
                        CBackKharid = If(ChkBackKharid.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور برگشت از خرید',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor WHERE ListFactorBackBuy.Activ =1 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور برگشت از خرید',BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorBackBuy WHERE ListFactorBackBuy.Activ =1 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور برگشت از خرید',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM  ListFactorBackBuy WHERE ListFactorBackBuy.Activ =1 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور برگشت از خرید',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM  ListFactorBackBuy WHERE ListFactorBackBuy.Activ =1 " & condition & " UNION ALL ")
                        CKharidAmani = If(ChkKharidAmani.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور خرید امانی', ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور خریدامانی' ,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM  ListFactorBuy WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور خریدامانی',BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM  ListFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور خریدامانی',ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM  ListFactorBuy WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL ")
                        CFrosh = If(ChkFrosh.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور فروش',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور فروش',BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور فروش',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور فروش',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " UNION ALL ")
                        CBackFrosh = If(ChkBackFrosh.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور برگشت از فروش',ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor WHERE ListFactorBackSell.Activ =1 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور برگشت از فروش' ,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBackSell WHERE ListFactorBackSell.Activ =1 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور برگشت از فروش',BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBackSell WHERE ListFactorBackSell.Activ =1 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور برگشت از فروش',ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM  ListFactorBackSell WHERE ListFactorBackSell.Activ =1 " & condition & " UNION ALL ")
                        CFroshAmani = If(ChkFroshAmani.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور فروش امانی',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور فروش امانی' ,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور فروش امانی',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور فروش امانی',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " UNION ALL ")
                        CService = If(ChkService.Checked = False, "", "SELECT Disc=N'تخفیفات حجمی فاکتور خدمات',BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorService INNER JOIN ListFactorService ON KalaFactorService.IdFactor = ListFactorService.IdFactor WHERE ListFactorService.Activ =1 " & condition & " UNION ALL SELECT Disc=N'تخفیفات نقدی فاکتور خدمات',BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM ListFactorService WHERE ListFactorService.Activ =1 " & condition & " UNION ALL SELECT Disc=N'اضافات فاکتور خدمات',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM ListFactorService WHERE ListFactorService.Activ =1 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور خدمات',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM ListFactorService WHERE ListFactorService.Activ =1 " & condition & " UNION ALL ")
                        CGet = If(ChkGet.Checked = False, "", "SELECT Disc=N'تخفیفات دریافت از طرف حساب',BesMon=0,ISNULL(SUM(Discount),0) AS BedMon FROM  Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =0 AND Active =1 " & condition & " UNION ALL ")
                        CPay = If(ChkPay.Checked = False, "", "SELECT Disc=N'تخفیفات پرداخت به طرف حساب',ISNULL(SUM(Discount),0) AS BesMon,BedMon=0 FROM  Get_Pay_Sanad WHERE Get_Pay_Sanad.[State] =1 AND Active =1 " & condition & " UNION ALL ")
                        Charge = If(ChkCharge.Checked = False, "", "SELECT Disc=N'تخفیفات هزینه فاکتور خرید',ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM ListFactorCharge WHERE Activ =1 " & condition & " UNION ALL SELECT Disc=N'تخفیفات هزینه متفرقه',ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM ListOtherCharge WHERE Activ =1 " & condition & " UNION ALL ")
                        add = "SELECT Disc=N'اضافات صندوق ',ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBox WHERE Flag =0 " & condition & " UNION ALL SELECT Disc=N'اضافات بانک ',ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBank WHERE Flag =0 " & condition & "  UNION ALL "
                        dec = "SELECT Disc=N'کسورات صندوق ',BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBox  WHERE Flag =1 " & condition & " UNION ALL SELECT Disc=N'کسورات بانک ',BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBank WHERE Flag =1 " & condition & " UNION ALL "
                        sql = CKharid & CKharidAmani & CBackKharid & CFrosh & CFroshAmani & CBackFrosh & CService & CGet & CPay & Charge & add & dec
                        sql = sql.Substring(0, sql.Length - 10)
                    Else
                        CKharid = If(ChkKharid.Checked = False, "", "SELECT Disc=N'اضافات فاکتور خرید',BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور خرید',ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM  ListFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " UNION ALL ")
                        CBackKharid = If(ChkBackKharid.Checked = False, "", "SELECT Disc=N'اضافات فاکتور برگشت از خرید',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM  ListFactorBackBuy WHERE ListFactorBackBuy.Activ =1 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور برگشت از خرید',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM  ListFactorBackBuy WHERE ListFactorBackBuy.Activ =1 " & condition & " UNION ALL ")
                        CKharidAmani = If(ChkKharidAmani.Checked = False, "", "SELECT Disc=N'اضافات فاکتور خریدامانی',BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM  ListFactorBuy  WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور خریدامانی',ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM  ListFactorBuy WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " UNION ALL ")
                        CFrosh = If(ChkFrosh.Checked = False, "", "SELECT Disc=N'اضافات فاکتور فروش',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور فروش',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " UNION ALL ")
                        CBackFrosh = If(ChkBackFrosh.Checked = False, "", "SELECT Disc=N'اضافات فاکتور برگشت از فروش',BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBackSell WHERE ListFactorBackSell.Activ =1 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور برگشت از فروش',ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM  ListFactorBackSell WHERE ListFactorBackSell.Activ =1 " & condition & " UNION ALL ")
                        CFroshAmani = If(ChkFroshAmani.Checked = False, "", "SELECT Disc=N'اضافات فاکتور فروش امانی',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM  ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور فروش امانی',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorSell WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " UNION ALL ")
                        CService = If(ChkService.Checked = False, "", "SELECT Disc=N'اضافات فاکتور خدمات',ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM ListFactorService WHERE ListFactorService.Activ =1 " & condition & " UNION ALL SELECT Disc=N'کسورات فاکتور خدمات',BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM ListFactorService WHERE ListFactorService.Activ =1 " & condition & " UNION ALL ")
                        CGet = ""
                        CPay = ""
                        Charge = ""
                        add = "SELECT Disc=N'اضافات صندوق ',ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBox WHERE Flag =0 " & condition & " UNION ALL SELECT Disc=N'اضافات بانک ',ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBank WHERE Flag =0 " & condition & "  UNION ALL "
                        dec = "SELECT Disc=N'کسورات صندوق ',BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBox  WHERE Flag =1 " & condition & " UNION ALL SELECT Disc=N'کسورات بانک ',BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBank WHERE Flag =1 " & condition & " UNION ALL "
                        sql = CKharid & CKharidAmani & CBackKharid & CFrosh & CFroshAmani & CBackFrosh & CService & CGet & CPay & Charge & add & dec
                        sql = sql.Substring(0, sql.Length - 10)
                    End If
                End If
            Else
                If ChkAddDec.Checked = False Then
                    CKharid = If(ChkKharid.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور خرید' + CAST(ListFactorBuy.IdFactor AS Nvarchar(max)) + '-' + Nam , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " GROUP BY  ListFactorBuy.D_date, Define_People.Nam, ListFactorBuy.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CBackKharid = If(ChkBackKharid.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور برگشت از خرید' + CAST(ListFactorBackBuy.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  ListFactorBackBuy.D_date, Define_People.Nam, ListFactorBackBuy.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور برگشت از خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CKharidAmani = If(ChkKharidAmani.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور خرید امانی' + CAST(ListFactorBuy.IdFactor AS Nvarchar(max)) + '-' + Nam , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  ListFactorBuy.D_date, Define_People.Nam, ListFactorBuy.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور خریدامانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CFrosh = If(ChkFrosh.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور فروش' + CAST(ListFactorSell.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  ListFactorSell.D_date, Define_People.Nam, ListFactorSell.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CBackFrosh = If(ChkBackFrosh.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور برگشت از فروش' + CAST(ListFactorBackSell.IdFactor AS Nvarchar(max)) + '-' + Nam , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  ListFactorBackSell.D_date, Define_People.Nam, ListFactorBackSell.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور برگشت از فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CFroshAmani = If(ChkFroshAmani.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور فروش امانی' + CAST(ListFactorSell.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  ListFactorSell.D_date, Define_People.Nam, ListFactorSell.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور فروش امانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CService = If(ChkService.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور خدمات' + CAST(ListFactorService.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorService INNER JOIN ListFactorService ON KalaFactorService.IdFactor = ListFactorService.IdFactor INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  ListFactorService.D_date, Define_People.Nam, ListFactorService.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور خدمات' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                    CGet = If(ChkGet.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات دریافت از طرف حساب'+ CAST(Get_Pay_Sanad.Id AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(Discount),0) AS BedMon FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.Idname = Define_People.ID WHERE Get_Pay_Sanad.[State] =0 AND Active =1 " & condition & " GROUP BY D_date ,Get_Pay_Sanad.Id,Nam UNION ALL ")
                    CPay = If(ChkPay.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات پرداخت به طرف حساب'+ CAST(Get_Pay_Sanad.Id AS Nvarchar(max)) + '-' + Nam ,ISNULL(SUM(Discount),0) AS BesMon,BedMon=0 FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.Idname = Define_People.ID WHERE Get_Pay_Sanad.[State] =1 AND Active =1 " & condition & " GROUP BY D_date ,Get_Pay_Sanad.Id,Nam UNION ALL ")
                    Charge = If(ChkCharge.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات هزینه فاکتور خرید' + CAST(IdFactor As nvarchar(max)) ,ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM ListFactorCharge WHERE Activ =1 " & condition & " GROUP BY D_date ,IdFactor  UNION ALL SELECT D_date,Disc=N'تخفیفات هزینه متفرقه' + CAST(Id As nvarchar(max)) ,ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM ListOtherCharge WHERE Activ =1 " & condition & " GROUP BY D_date ,Id UNION ALL")
                    add = ""
                    dec = ""
                Else
                    If ChkOnly.Checked = False Then
                        CKharid = If(ChkKharid.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور خرید' + CAST(ListFactorBuy.IdFactor AS Nvarchar(max)) + '-' + Nam , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " GROUP BY  ListFactorBuy.D_date, Define_People.Nam, ListFactorBuy.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CBackKharid = If(ChkBackKharid.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور برگشت از خرید' + CAST(ListFactorBackBuy.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorBackBuy INNER JOIN ListFactorBackBuy ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  ListFactorBackBuy.D_date, Define_People.Nam, ListFactorBackBuy.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور برگشت از خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور برگشت از خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor  UNION ALL SELECT D_date,Disc=N'کسورات فاکتور برگشت از خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor  UNION ALL ")
                        CKharidAmani = If(ChkKharidAmani.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور خرید امانی' + CAST(ListFactorBuy.IdFactor AS Nvarchar(max)) + '-' + Nam , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBuy INNER JOIN ListFactorBuy ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  ListFactorBuy.D_date, Define_People.Nam, ListFactorBuy.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور خریدامانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور خریدامانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور خریدامانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CFrosh = If(ChkFrosh.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور فروش' + CAST(ListFactorSell.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  ListFactorSell.D_date, Define_People.Nam, ListFactorSell.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CBackFrosh = If(ChkBackFrosh.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور برگشت از فروش' + CAST(ListFactorBackSell.IdFactor AS Nvarchar(max)) + '-' + Nam , ISNULL(SUM(DarsadMon),0) As BesMon,BedMon=0 FROM KalaFactorBackSell INNER JOIN ListFactorBackSell ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  ListFactorBackSell.D_date, Define_People.Nam, ListFactorBackSell.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور برگشت از فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(Discount),0)As BesMon,BedMon=0 FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور برگشت از فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور برگشت از فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CFroshAmani = If(ChkFroshAmani.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور فروش امانی' + CAST(ListFactorSell.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorSell INNER JOIN ListFactorSell ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  ListFactorSell.D_date, Define_People.Nam, ListFactorSell.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور فروش امانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور فروش امانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور فروش امانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CService = If(ChkService.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات حجمی فاکتور خدمات' + CAST(ListFactorService.IdFactor AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(DarsadMon),0) As BedMon FROM KalaFactorService INNER JOIN ListFactorService ON KalaFactorService.IdFactor = ListFactorService.IdFactor INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  ListFactorService.D_date, Define_People.Nam, ListFactorService.IdFactor UNION ALL SELECT D_date,Disc=N'تخفیفات نقدی فاکتور خدمات' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(Discount),0)As BedMon FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'اضافات فاکتور خدمات' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور خدمات' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CGet = If(ChkGet.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات دریافت از طرف حساب'+ CAST(Get_Pay_Sanad.Id AS Nvarchar(max)) + '-' + Nam ,BesMon=0,ISNULL(SUM(Discount),0) AS BedMon FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.Idname = Define_People.ID WHERE Get_Pay_Sanad.[State] =0 AND Active =1 " & condition & " GROUP BY D_date ,Get_Pay_Sanad.Id,Nam UNION ALL ")
                        CPay = If(ChkPay.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات پرداخت به طرف حساب'+ CAST(Get_Pay_Sanad.Id AS Nvarchar(max)) + '-' + Nam ,ISNULL(SUM(Discount),0) AS BesMon,BedMon=0 FROM  Get_Pay_Sanad INNER JOIN Define_People ON Get_Pay_Sanad.Idname = Define_People.ID WHERE Get_Pay_Sanad.[State] =1 AND Active =1 " & condition & " GROUP BY D_date ,Get_Pay_Sanad.Id,Nam UNION ALL ")
                        Charge = If(ChkCharge.Checked = False, "", "SELECT D_date,Disc=N'تخفیفات هزینه فاکتور خرید' + CAST(IdFactor As nvarchar(max)) ,ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM ListFactorCharge WHERE Activ =1 " & condition & " GROUP BY D_date ,IdFactor  UNION ALL SELECT D_date,Disc=N'تخفیفات هزینه متفرقه' + CAST(Id As nvarchar(max)) ,ISNULL(SUM(Discount),0) As BesMon,BedMon=0 FROM ListOtherCharge WHERE Activ =1 " & condition & " GROUP BY D_date ,Id UNION ALL ")
                        add = "SELECT D_Date,Disc=N'اضافات صندوق ' + Nam +'-'+ CAST(Sanad_AddDecBox.Id As nvarchar(max)) ,ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBox INNER JOIN Define_Box ON Sanad_AddDecBox.IdBox = Define_Box.ID WHERE Flag =0 " & condition & " GROUP BY  D_date,Sanad_AddDecBox.Id ,nam  UNION ALL SELECT D_Date,Disc=N'اضافات بانک ' + n_bank +'-'+ CAST(Sanad_AddDecBank.Id As nvarchar(max)),ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBank INNER JOIN Define_Bank ON Sanad_AddDecBank.IdBank = Define_Bank.ID WHERE Flag =0 " & condition & " GROUP BY  D_date,Sanad_AddDecBank.Id ,n_bank UNION ALL "
                        dec = "SELECT D_Date,Disc=N'کسورات صندوق ' + Nam +'-'+ CAST(Sanad_AddDecBox.Id As nvarchar(max)) ,BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBox INNER JOIN Define_Box ON Sanad_AddDecBox.IdBox = Define_Box.ID WHERE Flag =1 " & condition & " GROUP BY  D_date,Sanad_AddDecBox.Id ,nam  UNION ALL SELECT D_Date,Disc=N'کسورات بانک ' + n_bank +'-'+ CAST(Sanad_AddDecBank.Id As nvarchar(max)),BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBank INNER JOIN Define_Bank ON Sanad_AddDecBank.IdBank = Define_Bank.ID WHERE Flag =1 " & condition & " GROUP BY  D_date,Sanad_AddDecBank.Id ,n_bank UNION ALL "
                    Else
                        CKharid = If(ChkKharid.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =0  " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CBackKharid = If(ChkBackKharid.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور برگشت از خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor  UNION ALL SELECT D_date,Disc=N'کسورات فاکتور برگشت از خرید' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE ListFactorBackBuy.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor  UNION ALL ")
                        CKharidAmani = If(ChkKharidAmani.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور خریدامانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور خریدامانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE ListFactorBuy.Activ =1 AND ListFactorBuy.Stat =2 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CFrosh = If(ChkFrosh.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =3 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CBackFrosh = If(ChkBackFrosh.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور برگشت از فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonAdd),0)As BedMon FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور برگشت از فروش' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonDec),0)As BesMon,BedMon=0 FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE ListFactorBackSell.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CFroshAmani = If(ChkFroshAmani.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور فروش امانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور فروش امانی' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE ListFactorSell.Activ =1 AND ListFactorSell.Stat =5 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CService = If(ChkService.Checked = False, "", "SELECT D_date,Disc=N'اضافات فاکتور خدمات' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,ISNULL(SUM(MonAdd),0)As BesMon,BedMon=0 FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL SELECT D_date,Disc=N'کسورات فاکتور خدمات' + CAST(IdFactor AS Nvarchar(max)) + '-' + Nam,BesMon=0,ISNULL(SUM(MonDec),0)As BedMon FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE ListFactorService.Activ =1 " & condition & " GROUP BY  D_date,Nam,IdFactor UNION ALL ")
                        CGet = ""
                        CPay = ""
                        Charge = ""
                        add = "SELECT D_Date,Disc=N'اضافات صندوق ' + Nam +'-'+ CAST(Sanad_AddDecBox.Id As nvarchar(max)) ,ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBox INNER JOIN Define_Box ON Sanad_AddDecBox.IdBox = Define_Box.ID WHERE Flag =0 " & condition & " GROUP BY  D_date,Sanad_AddDecBox.Id ,nam  UNION ALL SELECT D_Date,Disc=N'اضافات بانک ' + n_bank +'-'+ CAST(Sanad_AddDecBank.Id As nvarchar(max)),ISNULL(SUM(Mon),0) As BesMon,BedMon=0 FROM Sanad_AddDecBank INNER JOIN Define_Bank ON Sanad_AddDecBank.IdBank = Define_Bank.ID WHERE Flag =0 " & condition & " GROUP BY  D_date,Sanad_AddDecBank.Id ,n_bank UNION ALL "
                        dec = "SELECT D_Date,Disc=N'کسورات صندوق ' + Nam +'-'+ CAST(Sanad_AddDecBox.Id As nvarchar(max)) ,BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBox INNER JOIN Define_Box ON Sanad_AddDecBox.IdBox = Define_Box.ID WHERE Flag =1 " & condition & " GROUP BY  D_date,Sanad_AddDecBox.Id ,nam  UNION ALL SELECT D_Date,Disc=N'کسورات بانک ' + n_bank +'-'+ CAST(Sanad_AddDecBank.Id As nvarchar(max)),BesMon=0,ISNULL(SUM(Mon),0) As BedMon FROM Sanad_AddDecBank INNER JOIN Define_Bank ON Sanad_AddDecBank.IdBank = Define_Bank.ID WHERE Flag =1 " & condition & " GROUP BY  D_date,Sanad_AddDecBank.Id ,n_bank UNION ALL "
                    End If
                End If

                sql = CKharid & CKharidAmani & CBackKharid & CFrosh & CFroshAmani & CBackFrosh & CService & CGet & CPay & Charge & add & dec
                sql = sql.Substring(0, sql.Length - 10)
                sql = sql & " ORDER BY D_Date,Disc"
            End If


            Me.Enabled = False

            Dim dt As New DataTable
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()
            Using cmd As New SqlCommand(sql, ConectionBank)
                cmd.CommandTimeout = 0
                dt.Load(cmd.ExecuteReader)
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()

            If ChkZ.Checked = True Then
                For i As Long = dt.Rows.Count - 1 To 0 Step -1
                    If (dt.Rows(i).Item("BesMon") = 0 And dt.Rows(i).Item("BedMon") = 0) Then
                        dt.Rows(i).Delete()
                    End If
                Next
                dt.AcceptChanges()
            End If

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("گزارشی با مشخصات فوق وجود ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Enabled = True
                Exit Sub
            End If


            TraceUser(Id_User, GetDate(), CStr(Date.Now.ToLongTimeString), "تخفیفات", "تهیه گزارش", "", "")

            Using FrmP As New FrmPrint
                FrmP.CHoose = If(ChkGroup.Checked = True, "DISCOUNT", "DISCOUNTALL")
                FrmP.DtDiscount = dt
                Tmp_OneGroup = If(ChkAzDate.Checked = True, FarsiDate1.ThisText, "")
                Tmp_TwoGroup = If(ChkTaDate.Checked = True, FarsiDate2.ThisText, "")
                FrmP.ShowDialog()
            End Using
            Me.Enabled = True

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "FrmDiscount", "Button1_Click")
        End Try

    End Sub

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

    Private Sub FrmDaftarDay_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Button1.Focus()
    End Sub

    Private Sub FrmDaftarDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub FrmDaftarDay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim theFont As New Font(FontName, FontSize, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        Access_Form = Get_Access_Form("F145")
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
        ChkAzDate.Enabled = False
        ChkTaDate.Enabled = False
        FarsiDate1.Enabled = False
        FarsiDate2.Enabled = False
        FarsiDate1.ThisText = GetDate()
        FarsiDate2.ThisText = GetDate()
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "RepTakhfifat.htm")
        ElseIf e.KeyCode = Keys.F2 Then
            If Button1.Enabled = True Then Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub RdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAll.CheckedChanged
        If RdoAll.Checked = True Then
            GroupBox2.Enabled = False
            ChkKharid.Checked = True
            ChkKharidAmani.Checked = True
            ChkBackKharid.Checked = True
            ChkService.Checked = True
            ChkFrosh.Checked = True
            ChkFroshAmani.Checked = True
            ChkBackFrosh.Checked = True
            ChkGet.Checked = True
            ChkPay.Checked = True
            ChkCharge.Checked = True
        End If
    End Sub

    Private Sub RdoBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBuy.CheckedChanged
        If RdoBuy.Checked = True Then
            GroupBox2.Enabled = False
            ChkKharid.Checked = True
            ChkKharidAmani.Checked = True
            ChkBackKharid.Checked = False
            ChkService.Checked = False
            ChkFrosh.Checked = False
            ChkFroshAmani.Checked = False
            ChkBackFrosh.Checked = True
            ChkGet.Checked = False
            ChkPay.Checked = True
            ChkCharge.Checked = False
        End If
    End Sub

    Private Sub RdoFrosh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoFrosh.CheckedChanged
        If RdoFrosh.Checked = True Then
            GroupBox2.Enabled = False
            ChkKharid.Checked = False
            ChkKharidAmani.Checked = False
            ChkBackKharid.Checked = True
            ChkService.Checked = True
            ChkFrosh.Checked = True
            ChkFroshAmani.Checked = True
            ChkBackFrosh.Checked = False
            ChkGet.Checked = True
            ChkPay.Checked = False
            ChkCharge.Checked = True
        End If
    End Sub

    Private Sub RdoSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoSelect.CheckedChanged
        If RdoSelect.Checked = True Then
            GroupBox2.Enabled = True
        End If
    End Sub

    Private Sub ChkAddDec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAddDec.CheckedChanged
        If ChkAddDec.Checked = True Then
            ChkOnly.Enabled = True
        Else
            ChkOnly.Checked = False
            ChkOnly.Enabled = False
        End If
    End Sub
End Class