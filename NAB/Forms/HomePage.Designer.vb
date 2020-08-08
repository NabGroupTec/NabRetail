Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class HomePage
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Dim NavigationPaneRenderer1 As Microsoft.Dynamics.Framework.UI.WinForms.Controls.NavigationPaneRenderer = New Microsoft.Dynamics.Framework.UI.WinForms.Controls.NavigationPaneRenderer()
        Dim ColorTable1 As Microsoft.Dynamics.Framework.UI.WinForms.Controls.ColorTable = New Microsoft.Dynamics.Framework.UI.WinForms.Controls.ColorTable()
        Me.NavigationPanel = New Microsoft.Dynamics.Framework.UI.WinForms.Controls.NavigationPane()
        Me.SuspendLayout
        '
        'NavigationPanel
        '
        Me.NavigationPanel.AllowDrop = true
        Me.NavigationPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.NavigationPanel.Font = New System.Drawing.Font("IRANSans", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.NavigationPanel.Location = New System.Drawing.Point(785, 0)
        Me.NavigationPanel.Name = "NavigationPanel"
        Me.NavigationPanel.NoPrefix = false
        Me.NavigationPanel.PreferredVisibleTabs = 2147483647
        NavigationPaneRenderer1.ColorTable = ColorTable1
        NavigationPaneRenderer1.NoPrefix = false
        Me.NavigationPanel.Renderer = NavigationPaneRenderer1
        Me.NavigationPanel.ShowFooter = true
        Me.NavigationPanel.Size = New System.Drawing.Size(387, 620)
        Me.NavigationPanel.TabIndex = 5
        '
        'HomePage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1172, 620)
        Me.Controls.Add(Me.NavigationPanel)
        Me.Font = New System.Drawing.Font("IRANSans", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Name = "HomePage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(false)

End Sub

        Friend WithEvents NavigationPanel As Microsoft.Dynamics.Framework.UI.WinForms.Controls.NavigationPane
    End Class
End NameSpace