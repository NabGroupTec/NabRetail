<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditKala_OneTime
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Button2 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Btnnew = New System.Windows.Forms.Button
        Me.Btnsave = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtKalaDate = New FarsiDate.FarsiDate
        Me.LIdkala = New System.Windows.Forms.Label
        Me.LJoz = New System.Windows.Forms.Label
        Me.LKol = New System.Windows.Forms.Label
        Me.LIdAnbar = New System.Windows.Forms.Label
        Me.cln_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_count = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_b = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_Buy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Anbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_Money = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_CodeAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_DK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_KOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_JOZ = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.Location = New System.Drawing.Point(676, 107)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 30)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "کالای جدید"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cln_type, Me.cln_name, Me.cln_count, Me.cln_b, Me.cln_Buy, Me.Cln_Anbar, Me.cln_Money, Me.Cln_Code, Me.Cln_CodeAnbar, Me.Cln_DK, Me.Cln_KOL, Me.Cln_JOZ})
        Me.DGV1.Location = New System.Drawing.Point(8, 14)
        Me.DGV1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV1.Size = New System.Drawing.Size(846, 88)
        Me.DGV1.TabIndex = 0
        '
        'Btnnew
        '
        Me.Btnnew.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btnnew.Location = New System.Drawing.Point(584, 107)
        Me.Btnnew.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Btnnew.Name = "Btnnew"
        Me.Btnnew.Size = New System.Drawing.Size(86, 30)
        Me.Btnnew.TabIndex = 3
        Me.Btnnew.Text = "انصراف"
        Me.Btnnew.UseVisualStyleBackColor = True
        '
        'Btnsave
        '
        Me.Btnsave.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btnsave.Location = New System.Drawing.Point(768, 107)
        Me.Btnsave.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(86, 30)
        Me.Btnsave.TabIndex = 1
        Me.Btnsave.Text = "ذخيره"
        Me.Btnsave.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 146)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(866, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 50
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(55, 24)
        Me.ToolStripStatusLabel2.Text = "F2 ذخیره"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(75, 24)
        Me.ToolStripStatusLabel3.Text = "F3 کالای جدید"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel4.Text = "F4 انصراف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'LID
        '
        Me.LID.AutoSize = True
        Me.LID.Location = New System.Drawing.Point(12, 112)
        Me.LID.Name = "LID"
        Me.LID.Size = New System.Drawing.Size(0, 21)
        Me.LID.TabIndex = 51
        Me.LID.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "تاریخ ورود کالا"
        '
        'TxtKalaDate
        '
        Me.TxtKalaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtKalaDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtKalaDate.Location = New System.Drawing.Point(8, 108)
        Me.TxtKalaDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtKalaDate.Name = "TxtKalaDate"
        Me.TxtKalaDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtKalaDate.Size = New System.Drawing.Size(74, 29)
        Me.TxtKalaDate.TabIndex = 52
        Me.TxtKalaDate.ThisText = Nothing
        '
        'LIdkala
        '
        Me.LIdkala.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LIdkala.AutoSize = True
        Me.LIdkala.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LIdkala.Location = New System.Drawing.Point(294, 112)
        Me.LIdkala.Name = "LIdkala"
        Me.LIdkala.Size = New System.Drawing.Size(0, 21)
        Me.LIdkala.TabIndex = 54
        Me.LIdkala.Visible = False
        '
        'LJoz
        '
        Me.LJoz.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LJoz.AutoSize = True
        Me.LJoz.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LJoz.Location = New System.Drawing.Point(380, 112)
        Me.LJoz.Name = "LJoz"
        Me.LJoz.Size = New System.Drawing.Size(0, 21)
        Me.LJoz.TabIndex = 55
        Me.LJoz.Visible = False
        '
        'LKol
        '
        Me.LKol.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LKol.AutoSize = True
        Me.LKol.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LKol.Location = New System.Drawing.Point(466, 112)
        Me.LKol.Name = "LKol"
        Me.LKol.Size = New System.Drawing.Size(0, 21)
        Me.LKol.TabIndex = 56
        Me.LKol.Visible = False
        '
        'LIdAnbar
        '
        Me.LIdAnbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LIdAnbar.AutoSize = True
        Me.LIdAnbar.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LIdAnbar.Location = New System.Drawing.Point(212, 112)
        Me.LIdAnbar.Name = "LIdAnbar"
        Me.LIdAnbar.Size = New System.Drawing.Size(0, 21)
        Me.LIdAnbar.TabIndex = 57
        Me.LIdAnbar.Visible = False
        '
        'cln_type
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cln_type.DefaultCellStyle = DataGridViewCellStyle2
        Me.cln_type.HeaderText = "گروه کالا"
        Me.cln_type.Name = "cln_type"
        Me.cln_type.ReadOnly = True
        Me.cln_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_type.Width = 150
        '
        'cln_name
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cln_name.DefaultCellStyle = DataGridViewCellStyle3
        Me.cln_name.HeaderText = "نام كالا"
        Me.cln_name.Name = "cln_name"
        Me.cln_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_name.Width = 183
        '
        'cln_count
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cln_count.DefaultCellStyle = DataGridViewCellStyle4
        Me.cln_count.HeaderText = "تعداد"
        Me.cln_count.MaxInputLength = 10
        Me.cln_count.Name = "cln_count"
        Me.cln_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_count.Width = 80
        '
        'cln_b
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cln_b.DefaultCellStyle = DataGridViewCellStyle5
        Me.cln_b.HeaderText = "نسبت جزء"
        Me.cln_b.MaxInputLength = 10
        Me.cln_b.Name = "cln_b"
        Me.cln_b.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_b.Width = 70
        '
        'cln_Buy
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cln_Buy.DefaultCellStyle = DataGridViewCellStyle6
        Me.cln_Buy.HeaderText = "فی"
        Me.cln_Buy.MaxInputLength = 20
        Me.cln_Buy.Name = "cln_Buy"
        Me.cln_Buy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cln_Anbar
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Anbar.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_Anbar.HeaderText = "انبار"
        Me.Cln_Anbar.Name = "Cln_Anbar"
        Me.Cln_Anbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cln_Money
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cln_Money.DefaultCellStyle = DataGridViewCellStyle8
        Me.cln_Money.HeaderText = "جمع كل مبلغ"
        Me.cln_Money.Name = "cln_Money"
        Me.cln_Money.ReadOnly = True
        Me.cln_Money.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_Money.Width = 120
        '
        'Cln_Code
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Cln_Code.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Code.HeaderText = "کد کالا"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.ReadOnly = True
        Me.Cln_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Code.Visible = False
        '
        'Cln_CodeAnbar
        '
        Me.Cln_CodeAnbar.HeaderText = "کد انبار"
        Me.Cln_CodeAnbar.Name = "Cln_CodeAnbar"
        Me.Cln_CodeAnbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_CodeAnbar.Visible = False
        '
        'Cln_DK
        '
        Me.Cln_DK.HeaderText = "دو واحده"
        Me.Cln_DK.Name = "Cln_DK"
        Me.Cln_DK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_DK.Visible = False
        '
        'Cln_KOL
        '
        Me.Cln_KOL.HeaderText = "کل"
        Me.Cln_KOL.Name = "Cln_KOL"
        Me.Cln_KOL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_KOL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_KOL.Visible = False
        '
        'Cln_JOZ
        '
        Me.Cln_JOZ.HeaderText = "جزء"
        Me.Cln_JOZ.Name = "Cln_JOZ"
        Me.Cln_JOZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JOZ.Visible = False
        '
        'EditKala_OneTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 175)
        Me.Controls.Add(Me.LIdAnbar)
        Me.Controls.Add(Me.LKol)
        Me.Controls.Add(Me.LJoz)
        Me.Controls.Add(Me.LIdkala)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtKalaDate)
        Me.Controls.Add(Me.LID)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Btnnew)
        Me.Controls.Add(Me.Btnsave)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditKala_OneTime"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ویرایش کالای اول دوره"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btnnew As System.Windows.Forms.Button
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtKalaDate As FarsiDate.FarsiDate
    Friend WithEvents LIdkala As System.Windows.Forms.Label
    Friend WithEvents LJoz As System.Windows.Forms.Label
    Friend WithEvents LKol As System.Windows.Forms.Label
    Friend WithEvents LIdAnbar As System.Windows.Forms.Label
    Friend WithEvents cln_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_count As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_Buy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Anbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_Money As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_CodeAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_DK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_KOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JOZ As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
