<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Charge_Other
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Btnadd = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Cln_BoxName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_MonBox = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_BoxId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TxtAllMoney = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LPrn = New System.Windows.Forms.Label
        Me.Ledit = New System.Windows.Forms.Label
        Me.LId = New System.Windows.Forms.Label
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel13 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel14 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel15 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel18 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Lsanad = New System.Windows.Forms.Label
        Me.TxtSanad = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btnadd
        '
        Me.Btnadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btnadd.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btnadd.Location = New System.Drawing.Point(500, 416)
        Me.Btnadd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(88, 30)
        Me.Btnadd.TabIndex = 3
        Me.Btnadd.Text = "ثبت"
        Me.Btnadd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(404, 416)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "انصراف"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TxtSanad)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TxtDisc)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.DGV2)
        Me.GroupBox3.Controls.Add(Me.TxtAllMoney)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(576, 402)
        Me.GroupBox3.TabIndex = 58
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "لیست هزینه"
        '
        'TxtDisc
        '
        Me.TxtDisc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDisc.BackColor = System.Drawing.Color.White
        Me.TxtDisc.Location = New System.Drawing.Point(8, 336)
        Me.TxtDisc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDisc.Size = New System.Drawing.Size(492, 29)
        Me.TxtDisc.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(512, 339)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 21)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "توضیحات"
        '
        'DGV2
        '
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_BoxName, Me.Cln_MonBox, Me.Cln_BoxId, Me.Cln_Disc})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV2.DefaultCellStyle = DataGridViewCellStyle17
        Me.DGV2.Location = New System.Drawing.Point(8, 30)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DGV2.Size = New System.Drawing.Size(556, 298)
        Me.DGV2.TabIndex = 0
        '
        'Cln_BoxName
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_BoxName.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_BoxName.HeaderText = "نام هزینه"
        Me.Cln_BoxName.Name = "Cln_BoxName"
        Me.Cln_BoxName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_BoxName.Width = 150
        '
        'Cln_MonBox
        '
        Me.Cln_MonBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_MonBox.DefaultCellStyle = DataGridViewCellStyle15
        Me.Cln_MonBox.HeaderText = "مبلغ"
        Me.Cln_MonBox.Name = "Cln_MonBox"
        Me.Cln_MonBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_MonBox.Width = 120
        '
        'Cln_BoxId
        '
        Me.Cln_BoxId.HeaderText = "کد هزینه"
        Me.Cln_BoxId.Name = "Cln_BoxId"
        Me.Cln_BoxId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_BoxId.Visible = False
        '
        'Cln_Disc
        '
        Me.Cln_Disc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Disc.DefaultCellStyle = DataGridViewCellStyle16
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TxtAllMoney
        '
        Me.TxtAllMoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtAllMoney.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtAllMoney.Location = New System.Drawing.Point(8, 367)
        Me.TxtAllMoney.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtAllMoney.Name = "TxtAllMoney"
        Me.TxtAllMoney.ReadOnly = True
        Me.TxtAllMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAllMoney.Size = New System.Drawing.Size(182, 29)
        Me.TxtAllMoney.TabIndex = 75
        Me.TxtAllMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(198, 370)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 21)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "جمع هزینه"
        '
        'LPrn
        '
        Me.LPrn.AutoSize = True
        Me.LPrn.Location = New System.Drawing.Point(387, 476)
        Me.LPrn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LPrn.Name = "LPrn"
        Me.LPrn.Size = New System.Drawing.Size(0, 21)
        Me.LPrn.TabIndex = 79
        Me.LPrn.Visible = False
        '
        'Ledit
        '
        Me.Ledit.AutoSize = True
        Me.Ledit.Location = New System.Drawing.Point(393, 465)
        Me.Ledit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Ledit.Name = "Ledit"
        Me.Ledit.Size = New System.Drawing.Size(0, 21)
        Me.Ledit.TabIndex = 85
        Me.Ledit.Visible = False
        '
        'LId
        '
        Me.LId.AutoSize = True
        Me.LId.Location = New System.Drawing.Point(495, 58)
        Me.LId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LId.Name = "LId"
        Me.LId.Size = New System.Drawing.Size(0, 21)
        Me.LId.TabIndex = 86
        Me.LId.Visible = False
        '
        'StatusStrip3
        '
        Me.StatusStrip3.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel13, Me.ToolStripStatusLabel14, Me.ToolStripStatusLabel15, Me.ToolStripStatusLabel18})
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 451)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip3.Size = New System.Drawing.Size(601, 29)
        Me.StatusStrip3.SizingGrip = False
        Me.StatusStrip3.TabIndex = 87
        '
        'ToolStripStatusLabel13
        '
        Me.ToolStripStatusLabel13.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel13.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel13.Name = "ToolStripStatusLabel13"
        Me.ToolStripStatusLabel13.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel13.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel14
        '
        Me.ToolStripStatusLabel14.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel14.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel14.Name = "ToolStripStatusLabel14"
        Me.ToolStripStatusLabel14.Size = New System.Drawing.Size(45, 24)
        Me.ToolStripStatusLabel14.Text = "F2 ثبت"
        '
        'ToolStripStatusLabel15
        '
        Me.ToolStripStatusLabel15.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel15.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15"
        Me.ToolStripStatusLabel15.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel15.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel18
        '
        Me.ToolStripStatusLabel18.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel18.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel18.Name = "ToolStripStatusLabel18"
        Me.ToolStripStatusLabel18.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel18.Text = "ESC خروج"
        '
        'Lsanad
        '
        Me.Lsanad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lsanad.AutoSize = True
        Me.Lsanad.Location = New System.Drawing.Point(72, 416)
        Me.Lsanad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lsanad.Name = "Lsanad"
        Me.Lsanad.Size = New System.Drawing.Size(0, 21)
        Me.Lsanad.TabIndex = 93
        Me.Lsanad.Visible = False
        '
        'TxtSanad
        '
        Me.TxtSanad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSanad.BackColor = System.Drawing.Color.White
        Me.TxtSanad.Location = New System.Drawing.Point(329, 367)
        Me.TxtSanad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtSanad.MaxLength = 50
        Me.TxtSanad.Name = "TxtSanad"
        Me.TxtSanad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSanad.Size = New System.Drawing.Size(171, 29)
        Me.TxtSanad.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(502, 370)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 21)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "سند دفتری"
        '
        'Frm_Charge_Other
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 480)
        Me.Controls.Add(Me.Lsanad)
        Me.Controls.Add(Me.StatusStrip3)
        Me.Controls.Add(Me.LId)
        Me.Controls.Add(Me.Ledit)
        Me.Controls.Add(Me.LPrn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btnadd)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "Frm_Charge_Other"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "هزینه"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LPrn As System.Windows.Forms.Label
    Friend WithEvents Ledit As System.Windows.Forms.Label
    Friend WithEvents LId As System.Windows.Forms.Label
    Friend WithEvents TxtAllMoney As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel13 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel14 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel15 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel18 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lsanad As System.Windows.Forms.Label
    Friend WithEvents Cln_BoxName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_MonBox As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_BoxId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtSanad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
