<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrint
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
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Pic1 = New System.Windows.Forms.PictureBox()
        CType(Me.Pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.DisplayBackgroundEdge = False
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 0)
        Me.CRV.Name = "CRV"
        Me.CRV.SelectionFormula = ""
        Me.CRV.ShowCloseButton = False
        Me.CRV.ShowCopyButton = False
        Me.CRV.ShowGroupTreeButton = False
        Me.CRV.ShowLogo = False
        Me.CRV.ShowParameterPanelButton = False
        Me.CRV.Size = New System.Drawing.Size(708, 430)
        Me.CRV.TabIndex = 0
        Me.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CRV.ViewTimeSelectionFormula = ""
        '
        'Pic1
        '
        Me.Pic1.Image = Global.NAB.My.Resources.Resources.preload
        Me.Pic1.Location = New System.Drawing.Point(296, 175)
        Me.Pic1.Name = "Pic1"
        Me.Pic1.Size = New System.Drawing.Size(150, 60)
        Me.Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pic1.TabIndex = 1
        Me.Pic1.TabStop = False
        Me.Pic1.Visible = False
        '
        'FrmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 430)
        Me.Controls.Add(Me.Pic1)
        Me.Controls.Add(Me.CRV)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrint"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "چاپ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Pic1 As System.Windows.Forms.PictureBox
End Class
