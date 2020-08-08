Namespace Forms

    Public Class HomePage

        Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim defineTab As New NavigationTab("تعاریف", My.Resources.Anbar15)
            Dim operationTab As New NavigationTab("عملیات حسابداری", My.Resources.Anbar15)
            Dim warehouseReportTab As New NavigationTab("گزارشات انبار", My.Resources.Anbar15)
            Dim accountSideReportTab As New NavigationTab("گزارشات طرف حساب", My.Resources.Anbar15)
            Dim financialReportTab As New NavigationTab("گزارشات مالی", My.Resources.Anbar15)
            Dim managerReportTab As New NavigationTab("گزارشات مدیریتی", My.Resources.Anbar15)
            Dim saleOwnerReportTab As New NavigationTab("گزارشات مدیر فروش", My.Resources.Anbar15)
            Dim dashboardReportTab As New NavigationTab("داشبورد", My.Resources.Anbar15)

            
            NavigationPanel.Tabs.Add(defineTab)
            NavigationPanel.Tabs.Add(operationTab)
            NavigationPanel.Tabs.Add(warehouseReportTab)
            NavigationPanel.Tabs.Add(accountSideReportTab)
            NavigationPanel.Tabs.Add(financialReportTab)
            NavigationPanel.Tabs.Add(managerReportTab)
            NavigationPanel.Tabs.Add(saleOwnerReportTab)
            NavigationPanel.Tabs.Add(dashboardReportTab)
            NavigationPanel.RightToLeft = RightToLeft.Yes

        End Sub

    End Class

End Namespace