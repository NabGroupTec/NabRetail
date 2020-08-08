Imports System.Data.SqlClient
Public Class ShowFactor
    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
                    SendKeys.Send("{Tab}")
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV1.RowPostPaint
        If DGV1.RowCount < 1000 Then
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 40, e.RowBounds.Location.Y)
            End Using
        Else
            Using b As SolidBrush = New SolidBrush(DGV1.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString("رديف", DGV1.DefaultCellStyle.Font, b, DGV1.Size.Width - 40, 6)
                e.Graphics.DrawString(e.RowIndex + 1, DGV1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + DGV1.Size.Width - 55, e.RowBounds.Location.Y)
            End Using
        End If
        If CDbl(DGV1.Item("Cln_Darsad", e.RowIndex).Value) >= 100 Then
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.SpringGreen
        Else
            DGV1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Nothing
            DGV1.Rows(e.RowIndex).Cells("cln_type").Style.BackColor = Color.Gainsboro
            DGV1.Rows(e.RowIndex).Cells("Cln_Vahed").Style.BackColor = Color.Gainsboro
            DGV1.Rows(e.RowIndex).Cells("Cln_DarsadMon").Style.BackColor = Color.Gainsboro
            DGV1.Rows(e.RowIndex).Cells("cln_Money").Style.BackColor = Color.Gainsboro
        End If
    End Sub
    Private Sub FrmFactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.GetKey(e)
    End Sub

    Private Sub GetKey(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            ShowKalafactor()
            ShowInfofactor()
        ElseIf e.KeyCode = Keys.F1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\Help.chm", HelpNavigator.Topic, "ManageFact.htm")
        ElseIf e.KeyCode = Keys.F6 Then
            If LState.Text = "6" Then
                MessageBox.Show("سابقه کالا به طرف حساب در فاکتور ضایعات قابل استفاده نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Then
                MessageBox.Show("هیچ طرف حسابی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش سابقه کالا به طرف حساب انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FileCustomer
                FCustomer.LState.Text = LState.Text
                FCustomer.Lidname.Text = CLng(TxtIdPeople.Text)
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.CmbFac.Text = GetTypeFactor(LState.Text)
                If LState.Text = "8" Or (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                    FCustomer.LKala.Text = "SERVICE"
                    FCustomer.CmbFac.Enabled = False
                End If
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F7 Then
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش سابقه کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FileAllCustomer
                FCustomer.LState.Text = LState.Text
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.CmbFac.Text = If(LState.Text = "6", "خرید", GetTypeFactor(LState.Text))
                If LState.Text = "8" Or (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                    FCustomer.LKala.Text = "SERVICE"
                    FCustomer.CmbFac.Enabled = False
                End If
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F8 Then
            If LState.Text = "6" Then
                MessageBox.Show("رابطه قیمت کالا در شهرستان در فاکتور ضایعات قابل استفاده نمی باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TxtIdPeople.Text.Trim) Or String.IsNullOrEmpty(TxtIdCityFac.Text.Trim) Then
                MessageBox.Show("هیچ طرف حسابی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (DGV1.Item("cln_type", DGV1.CurrentRow.Index).Value = "کالای خدماتی" And DGV1.Item("Cln_Vahed", DGV1.CurrentRow.Index).Value = "خدمات") Then
                MessageBox.Show("کالای خدماتی جهت گزارش رابطه قیمت کالا در شهرستان مجاز نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش رابطه قیمت کالا در شهرستان انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FrmKalaCostRelation
                FCustomer.LCity.Text = TxtCity.Text
                FCustomer.LIdCity.Text = TxtIdCityFac.Text
                FCustomer.LKala.Text = DGV1.Item("Cln_type", DGV1.CurrentRow.Index).Value & "-" & DGV1.Item("Cln_name", DGV1.CurrentRow.Index).Value
                FCustomer.LIdKala.Text = DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value
                FCustomer.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.F9 Then
            If DGV1.RowCount <= 0 Then
                MessageBox.Show("هیچ کالایی جهت گزارش قیمت تمام شده کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value Is DBNull.Value Then
                MessageBox.Show("کالایی جهت گزارش قیمت تمام شده کالا انتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If CStr(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value) = "" Then
                    MessageBox.Show("کالایی جهت گزارش قیمت تمام شده کالاانتخاب نشده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            Using FCustomer As New FrmEndCostKala
                FCustomer.Lidkala.Text = CLng(DGV1.Item("Cln_Code", DGV1.CurrentRow.Index).Value)
                FCustomer.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub ShowKalafactor()
        Try
            Dim Query As String = ""
            If LState.Text = "0" Or LState.Text = "2" Then
                Query = "SELECT  KalaFactorBuy.Id,KalaFactorBuy.IdKala,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBuy.IdFactor =" & CLng(LFactor.Text) & " UNION ALL SELECT KalaFactorBuy.Id,KalaFactorBuy.IdService As IdKala,KalaFactorBuy.KolCount, KalaFactorBuy.JozCount, KalaFactorBuy.Fe, KalaFactorBuy.DarsadDiscount, KalaFactorBuy.DarsadMon, KalaFactorBuy.Mon,KalaFactorBuy.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBuy INNER JOIN KalaFactorBuy ON ListFactorBuy.IdFactor = KalaFactorBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBuy.IdService  = Define_Service .ID  WHERE ListFactorBuy.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorBuy.ID"
            ElseIf LState.Text = "1" Then
                Query = "SELECT  KalaFactorBackBuy.Id,KalaFactorBackBuy.IdKala,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Kala ON KalaFactorBackBuy.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackBuy.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackBuy.IdFactor =" & CLng(LFactor.Text) & " UNION ALL SELECT KalaFactorBackBuy.Id,KalaFactorBackBuy.IdService As IdKala,KalaFactorBackBuy.KolCount, KalaFactorBackBuy.JozCount, KalaFactorBackBuy.Fe, KalaFactorBackBuy.DarsadDiscount, KalaFactorBackBuy.DarsadMon, KalaFactorBackBuy.Mon,KalaFactorBackBuy.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackBuy INNER JOIN KalaFactorBackBuy ON ListFactorBackBuy.IdFactor = KalaFactorBackBuy.IdFactor INNER JOIN Define_Service  ON KalaFactorBackBuy.IdService  = Define_Service .ID  WHERE ListFactorBackBuy.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorBackBuy.ID"
            ElseIf LState.Text = "3" Or LState.Text = "5" Or LState.Text = "7" Then
                Query = "SELECT  KalaFactorSell.Id,KalaFactorSell.IdKala,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Kala ON KalaFactorSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorSell.IdFactor =" & CLng(LFactor.Text) & " UNION ALL SELECT KalaFactorSell.Id,KalaFactorSell.IdService As IdKala,KalaFactorSell.KolCount, KalaFactorSell.JozCount, KalaFactorSell.Fe, KalaFactorSell.DarsadDiscount, KalaFactorSell.DarsadMon, KalaFactorSell.Mon,KalaFactorSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorSell INNER JOIN KalaFactorSell ON ListFactorSell.IdFactor = KalaFactorSell.IdFactor INNER JOIN Define_Service  ON KalaFactorSell.IdService  = Define_Service .ID  WHERE ListFactorSell.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorSell.ID"
            ElseIf LState.Text = "4" Then
                Query = "SELECT  KalaFactorBackSell.ID,KalaFactorBackSell.IDkala,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Kala ON KalaFactorBackSell.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorBackSell.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorBackSell.IdFactor =" & CLng(LFactor.Text) & " UNION ALL SELECT KalaFactorBackSell.Id,KalaFactorBackSell.IdService As IdKala,KalaFactorBackSell.KolCount, KalaFactorBackSell.JozCount, KalaFactorBackSell.Fe, KalaFactorBackSell.DarsadDiscount, KalaFactorBackSell.DarsadMon, KalaFactorBackSell.Mon,KalaFactorBackSell.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorBackSell INNER JOIN KalaFactorBackSell ON ListFactorBackSell.IdFactor = KalaFactorBackSell.IdFactor INNER JOIN Define_Service  ON KalaFactorBackSell.IdService  = Define_Service .ID  WHERE ListFactorBackSell.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorBackSell.ID"
            ElseIf LState.Text = "6" Then
                Query = "SELECT  KalaFactorDamage.Id,KalaFactorDamage.IdKala,KalaFactorDamage.KolCount, KalaFactorDamage.JozCount, KalaFactorDamage.Fe, DarsadDiscount=0,DarsadMon=0, KalaFactorDamage.Mon,KalaFactorDamage.KalaDisc, Define_Kala.Nam as NamKala, Define_Anbar.nam AS NamAnbar, Define_OneGroup.NamOne + '-' + Define_TwoGroup.NamTwo as GroupKala,Define_Vahed .Nam As Vahed FROM  ListFactorDamage INNER JOIN KalaFactorDamage ON ListFactorDamage.IdFactor = KalaFactorDamage.IdFactor INNER JOIN Define_Kala ON KalaFactorDamage.IdKala = Define_Kala.Id INNER JOIN Define_Anbar ON KalaFactorDamage.IdAnbar = Define_Anbar.ID INNER JOIN Define_OneGroup ON Define_Kala.IdCodeOne = Define_OneGroup.Id INNER JOIN Define_TwoGroup ON Define_Kala.IdCodeTwo = Define_TwoGroup.Id AND Define_OneGroup.Id = Define_TwoGroup.IdOne INNER JOIN Define_Vahed  ON Define_Kala.IdVahed  = Define_Vahed .Id WHERE ListFactorDamage.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorDamage.Id"
            ElseIf LState.Text = "8" Then
                Query = "SELECT KalaFactorService.Id,KalaFactorService.IdService As Idkala,KalaFactorService.KolCount, JozCount=0, KalaFactorService.Fe, KalaFactorService.DarsadDiscount, KalaFactorService.DarsadMon, KalaFactorService.Mon,KalaFactorService.KalaDisc, Define_Service.Nam as NamKala, NamAnbar='', GroupKala=N'کالای خدماتی',Vahed=N'خدمات' FROM ListFactorService INNER JOIN KalaFactorService ON ListFactorService.IdFactor = KalaFactorService.IdFactor INNER JOIN Define_Service  ON KalaFactorService.IdService  = Define_Service .ID  WHERE ListFactorService.IdFactor =" & CLng(LFactor.Text) & " ORDER BY KalaFactorService.Id"
            End If
            Dim ds As New DataSet
            Dim dta As New SqlDataAdapter
            ds.Clear()
            If Not dta Is Nothing Then dta.Dispose()
            dta = New SqlDataAdapter(Query, DataSource)
            dta.Fill(ds)
            DGV1.AutoGenerateColumns = False
            DGV1.DataSource = ds.Tables(0)
            CalculateMon()
        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ShowFactor", "ShowKalaFactor")
        End Try
    End Sub

    Private Sub ShowInfofactor()
        Try
            Dim QueryInfo As String = ""
            If LState.Text = "0" Or LState.Text = "2" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBuy WHERE  ListFactorBuy.IdFactor =" & CLng(LFactor.Text) & ")  Is NULL BEGIN SELECT  ListFactorBuy.D_date, ListFactorBuy.IdName, ListFactorBuy.Part, ListFactorBuy.Sanad, ListFactorBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorBuy.IdVisitor FROM ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID WHERE   ListFactorBuy.IdFactor =" & CLng(LFactor.Text) & "  END ELSE BEGIN SELECT  ListFactorBuy.D_date, ListFactorBuy.IdName, ListFactorBuy.Part, ListFactorBuy.Sanad, ListFactorBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBuy INNER JOIN Define_People ON ListFactorBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBuy .IdVisitor =Define_Visitor .Id  WHERE  ListFactorBuy.IdFactor =" & CLng(LFactor.Text) & "  END"
            ElseIf LState.Text = "1" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackBuy WHERE  ListFactorBackBuy.IdFactor =" & CLng(LFactor.Text) & ")  Is NULL BEGIN SELECT  ListFactorBackBuy.D_date, ListFactorBackBuy.IdName, ListFactorBackBuy.Part, ListFactorBackBuy.Sanad, ListFactorBackBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorBackBuy.IdVisitor FROM ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID WHERE   ListFactorBackBuy.IdFactor =" & CLng(LFactor.Text) & "  END ELSE BEGIN SELECT  ListFactorBackBuy.D_date, ListFactorBackBuy.IdName, ListFactorBackBuy.Part, ListFactorBackBuy.Sanad, ListFactorBackBuy.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorBackBuy.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackBuy INNER JOIN Define_People ON ListFactorBackBuy.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackBuy .IdVisitor =Define_Visitor .Id  WHERE  ListFactorBackBuy.IdFactor =" & CLng(LFactor.Text) & "  END"
            ElseIf LState.Text = "3" Or LState.Text = "5" Or LState.Text = "7" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorSell WHERE  ListFactorSell.IdFactor =" & CLng(LFactor.Text) & ")  Is NULL BEGIN SELECT  ListFactorSell.D_date, ListFactorSell.IdName, ListFactorSell.Part, ListFactorSell.Sanad, ListFactorSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorSell.IdVisitor FROM ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID WHERE   ListFactorSell.IdFactor =" & CLng(LFactor.Text) & "  END ELSE BEGIN SELECT  ListFactorSell.D_date, ListFactorSell.IdName, ListFactorSell.Part, ListFactorSell.Sanad, ListFactorSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorSell INNER JOIN Define_People ON ListFactorSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorSell .IdVisitor =Define_Visitor .Id  WHERE  ListFactorSell.IdFactor =" & CLng(LFactor.Text) & "  END"
            ElseIf LState.Text = "4" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorBackSell WHERE  ListFactorBackSell.IdFactor =" & CLng(LFactor.Text) & ")  Is NULL BEGIN SELECT  ListFactorBackSell.IdFacSell,ListFactorBackSell.D_date, ListFactorBackSell.IdName, ListFactorBackSell.Part, ListFactorBackSell.Sanad, ListFactorBackSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorBackSell.IdVisitor FROM ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID WHERE   ListFactorBackSell.IdFactor =" & CLng(LFactor.Text) & "  END ELSE BEGIN SELECT  ListFactorBackSell.IdFacSell,ListFactorBackSell.D_date, ListFactorBackSell.IdName, ListFactorBackSell.Part, ListFactorBackSell.Sanad, ListFactorBackSell.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorBackSell.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorBackSell INNER JOIN Define_People ON ListFactorBackSell.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorBackSell .IdVisitor =Define_Visitor .Id  WHERE  ListFactorBackSell.IdFactor =" & CLng(LFactor.Text) & "  END"
            ElseIf LState.Text = "6" Then
                QueryInfo = "SELECT  IdVisitor=NULL,Idname=NULL,[Address]=NULL,ListFactorDamage.D_date, ListFactorDamage.Part, ListFactorDamage.Sanad, ListFactorDamage.Disc,Tell1='',Tell2='' FROM ListFactorDamage  WHERE   ListFactorDamage.IdFactor =" & CLng(LFactor.Text)
            ElseIf LState.Text = "8" Then
                QueryInfo = "If (SELECT IdVisitor FROM ListFactorService WHERE  ListFactorService.IdFactor =" & CLng(LFactor.Text) & ")  Is NULL BEGIN SELECT  ListFactorService.D_date, ListFactorService.IdName, ListFactorService.Part, ListFactorService.Sanad, ListFactorService.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address] ,ListFactorService.IdVisitor FROM ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID WHERE   ListFactorService.IdFactor =" & CLng(LFactor.Text) & "  END ELSE BEGIN SELECT  ListFactorService.D_date, ListFactorService.IdName, ListFactorService.Part, ListFactorService.Sanad, ListFactorService.Disc, Define_People.Nam,Define_People.IdOstan,Define_People.IdCity,ISNULL(Define_People.Tell1,'') AS Tell1,ISNULL(Define_People.Tell2,'') AS Tell2,Define_People.[Address],ListFactorService.IdVisitor,Define_Visitor.Nam as NamVisit FROM   ListFactorService INNER JOIN Define_People ON ListFactorService.IdName = Define_People.ID INNER JOIN Define_Visitor  ON ListFactorService .IdVisitor =Define_Visitor .Id  WHERE  ListFactorService.IdFactor =" & CLng(LFactor.Text) & "  END"
            End If
            Dim dtrInfo As SqlDataReader = Nothing
            If ConectionBank.State <> ConnectionState.Open Then ConectionBank.Open()

            Using SQLComanad As New SqlCommand(QueryInfo, ConectionBank)
                dtrInfo = SQLComanad.ExecuteReader
                If Not dtrInfo.HasRows Then
                    If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
                    Me.Close()
                Else
                    dtrInfo.Read()
                    Txtsanad.Text = If(dtrInfo("Sanad") Is DBNull.Value, "", dtrInfo("Sanad"))
                    Txtdisc.Text = If(dtrInfo("Disc") Is DBNull.Value, "", dtrInfo("Disc"))
                    TxtAdd.Text = If(dtrInfo("Address") Is DBNull.Value, "", dtrInfo("Address")) & IIf(String.IsNullOrEmpty(dtrInfo("Tell1")) And String.IsNullOrEmpty(dtrInfo("Tell2")), "", " تلفن: " & dtrInfo("Tell1") & "-" & dtrInfo("Tell2"))
                    TxtDate.ThisText = dtrInfo("D_Date")
                    If Not (dtrInfo("IdVisitor") Is DBNull.Value) Then
                        TxtIdVisitor.Text = dtrInfo("IdVisitor")
                        TxtVisitor.Text = dtrInfo("NamVisit")
                    Else
                        TxtIdVisitor.Text = ""
                        TxtVisitor.Text = ""
                    End If

                    If Not (dtrInfo("Part") Is DBNull.Value) Then
                        TxtIdPart.Text = Tmp_String2
                        TxtPart.Text = Tmp_String1
                    Else
                        TxtIdPart.Text = ""
                        TxtPart.Text = ""
                    End If

                    If Not (dtrInfo("Idname") Is DBNull.Value) Then
                        TxtName.Text = dtrInfo("Nam")
                        TxtIdPeople.Text = dtrInfo("Idname")
                        TxtIdCityFac.Text = dtrInfo("IdCity")
                    End If
                    If LState.Text = "4" Then
                        If Not (dtrInfo("IdFacSell") Is DBNull.Value) Then
                            TxtIdFactor.Text = dtrInfo("IdFacSell")
                        End If
                    End If
                End If
            End Using
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
        Catch ex As Exception
            If ConectionBank.State <> ConnectionState.Closed Then ConectionBank.Close()
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "ShowFactor", "ShowInfofactor")
            Me.Close()
        End Try
    End Sub

    Private Sub ShowFactor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim theFont As New Font("FontName", 9.0F, FontStyle.Regular)

        For Each theControl As Control In (PublicFunction.GetAllControls(Me))
            theControl.Font = theFont
        Next
        ShowKalafactor()
        ShowInfofactor()
        DGV1.Columns("cln_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub CalculateMon()
        Try
            TxtMonFac.Text = 0
            Txtallmoney.Text = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                TxtMonFac.Text = CDbl(TxtMonFac.Text) + CDbl(DGV1.Item("Cln_DarsadMon", i).Value)
                Txtallmoney.Text = CDbl(Txtallmoney.Text) + CDbl(DGV1.Item("cln_Money", i).Value)
            Next
            If TxtMonFac.Text.Length > 3 Then
                Dim Str As String = Format$(TxtMonFac.Text.Replace(",", ""))
                TxtMonFac.Text = Format$(Val(Str), "###,###,###")
            End If
            If Txtallmoney.Text.Length > 3 Then
                Dim Str As String = Format$(Txtallmoney.Text.Replace(",", ""))
                Txtallmoney.Text = Format$(Val(Str), "###,###,###")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class