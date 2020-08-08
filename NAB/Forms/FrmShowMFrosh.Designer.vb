<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowMFrosh
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
        Dim DGVX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShowMFrosh))
        Dim GridEX1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DGVX = New Janus.Windows.GridEX.GridEX
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX
        Me.Chkostan = New System.Windows.Forms.CheckBox
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGVX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 535)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(891, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 82
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel9.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel9.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'DGVX
        '
        Me.DGVX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.DGVX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.DGVX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVX.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><GroupByBoxInfo>جهت گر" & _
            "وه بندی ستون مورد نظر را به این بخش بکشید</GroupByBoxInfo></LocalizableData>"
        DGVX_DesignTimeLayout.LayoutString = resources.GetString("DGVX_DesignTimeLayout.LayoutString")
        Me.DGVX.DesignTimeLayout = DGVX_DesignTimeLayout
        Me.DGVX.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DGVX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.DGVX.GroupByBoxFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DGVX.GroupByBoxFormatStyle.BackColorGradient = System.Drawing.SystemColors.ActiveCaption
        Me.DGVX.GroupByBoxInfoFormatStyle.BackColorGradient = System.Drawing.SystemColors.ActiveCaption
        Me.DGVX.GroupByBoxVisible = False
        Me.DGVX.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.DGVX.Location = New System.Drawing.Point(381, 12)
        Me.DGVX.Name = "DGVX"
        Me.DGVX.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Blue
        Me.DGVX.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.DGVX.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGVX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition
        Me.DGVX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.DGVX.Size = New System.Drawing.Size(504, 487)
        Me.DGVX.TabIndex = 83
        '
        'GridEX1
        '
        Me.GridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEX1.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><GroupByBoxInfo>جهت گر" & _
            "وه بندی ستون مورد نظر را به این بخش بکشید</GroupByBoxInfo></LocalizableData>"
        GridEX1_DesignTimeLayout.LayoutString = resources.GetString("GridEX1_DesignTimeLayout.LayoutString")
        Me.GridEX1.DesignTimeLayout = GridEX1_DesignTimeLayout
        Me.GridEX1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.GridEX1.GroupByBoxFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GridEX1.GroupByBoxFormatStyle.BackColorGradient = System.Drawing.SystemColors.ActiveCaption
        Me.GridEX1.GroupByBoxInfoFormatStyle.BackColorGradient = System.Drawing.SystemColors.ActiveCaption
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.GridEX1.Location = New System.Drawing.Point(11, 12)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Blue
        Me.GridEX1.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Size = New System.Drawing.Size(369, 487)
        Me.GridEX1.TabIndex = 84
        '
        'Chkostan
        '
        Me.Chkostan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chkostan.AutoSize = True
        Me.Chkostan.Location = New System.Drawing.Point(598, 505)
        Me.Chkostan.Name = "Chkostan"
        Me.Chkostan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chkostan.Size = New System.Drawing.Size(287, 25)
        Me.Chkostan.TabIndex = 85
        Me.Chkostan.Text = "لیست فروش بر حسب استان و شهرستان محاسبه شود "
        Me.Chkostan.UseVisualStyleBackColor = True
        '
        'FrmShowMFrosh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 564)
        Me.Controls.Add(Me.Chkostan)
        Me.Controls.Add(Me.GridEX1)
        Me.Controls.Add(Me.DGVX)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmShowMFrosh"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مدیریت بازار"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGVX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGVX As Janus.Windows.GridEX.GridEX
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents Chkostan As System.Windows.Forms.CheckBox
End Class
