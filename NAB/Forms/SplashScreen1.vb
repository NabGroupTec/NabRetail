Imports System.IO
Public NotInheritable Class SplashScreen1

    Private Sub SplashScreen1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Application.DoEvents()
        If Button1.Enabled = True Then
            Call Button1_Click(Nothing, Nothing)
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Shell(System.Windows.Forms.Application.StartupPath + "\DelTempFolder.Bat", AppWinStyle.Hide)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Application.DoEvents()
        Me.Loading()
    End Sub
    Private Sub Loading()
        Application.DoEvents()
        Try
            PB.Visible = True
            PB.Value = 0
            Application.DoEvents()

            ''''''''''''''''''''''''سرویس پیام کوتاه
            If Not (File.Exists(UCase("AxInterop.KYLIXSMSLib.dll"))) Then
                'MessageBox.Show(" جهت اجرا وجود ندارد " & "AxInterop.KYLIXSMSLib.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If

            If Not (File.Exists(UCase("Interop.KYLIXSMSLib.dll"))) Then
                ' MessageBox.Show(" جهت اجرا وجود ندارد " & "Interop.KYLIXSMSLib.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If

            PB.Value += 5
            Application.DoEvents()



            ''''''''''''''''''''''''سایر فایلها
            If Not (File.Exists(UCase("Divelements.SandRibbon.dll"))) Then
                'MessageBox.Show(" جهت اجرا وجود ندارد " & "Divelements.SandRibbon.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If

            If Not (File.Exists(UCase("FarsiDate.dll"))) Then
                'MessageBox.Show(" جهت اجرا وجود ندارد " & "FarsiDate.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If


            If Not (File.Exists(UCase("Ionic.Zip.dll"))) Then
                'MessageBox.Show(" جهت اجرا وجود ندارد " & "Ionic.Zip.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If

            If Not (File.Exists(UCase("Janus.Data.v3.dll"))) Then
                ' MessageBox.Show(" جهت اجرا وجود ندارد " & "Janus.Data.v3.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If


            If Not (File.Exists(UCase("Janus.Windows.Common.v3.dll"))) Then
                'MessageBox.Show(" جهت اجرا وجود ندارد " & "Janus.Windows.Common.v3.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If

            If Not (File.Exists(UCase("Janus.Windows.GridEX.v3.dll"))) Then
                ' MessageBox.Show(" جهت اجرا وجود ندارد " & "Janus.Windows.Common.v3.dll" & " فایل ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            Else
                PB.Value += 1
                Application.DoEvents()
            End If


            'Dim Dataret As New DataSetFactor
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Dataret.DataTable1.AddDataTable1Row(1.0, 2.0, 100, 2.5, 100, 5000, "", "", "", "", "", "", "", "", 12000, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 15000, 3215, 5000, 35200, 5000, 8000, 9000, "", "", "", Nothing, 45000, 65200, "", 16000, 98000, Nothing, "", 65.25, 452.02, 98600, "", 520, "", "", "", "", "", "", 1200, 3500, 8520, 6541, 4563, 987, 159, 7532, 6542, "", "")
            'Application.DoEvents()
            'Try
            '    Dim ret As New CRP_Factor_sell_A4ES4_G
            '    Application.DoEvents()
            '    ret.PrintOptions.PaperSize = Printing.PaperKind.A4
            '    Application.DoEvents()
            '    ret.SetDataSource(Dataret)
            '    Application.DoEvents()
            '    Me.CRP_V.ReportSource = ret
            '    Application.DoEvents()
            'Catch ex As Exception

            'End Try

            PB.Value += 1
            Application.DoEvents()

            Me.Hide()

            Dim FrmL As New LoginForm
            FrmL.Show()

        Catch ex As Exception
            GetError(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "SplashScreen", "Loading")
            End
        End Try
    End Sub
End Class
