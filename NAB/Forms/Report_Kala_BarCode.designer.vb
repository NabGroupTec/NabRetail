<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report_Kala_BarCode
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rdo16 = New System.Windows.Forms.RadioButton
        Me.Rdo14 = New System.Windows.Forms.RadioButton
        Me.Rdo12 = New System.Windows.Forms.RadioButton
        Me.Rdo10 = New System.Windows.Forms.RadioButton
        Me.Rdo8 = New System.Windows.Forms.RadioButton
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Num = New System.Windows.Forms.NumericUpDown
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ChkCost = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Num, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(389, 569)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 31)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "تهيه گزارش"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.BtnSearch)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.DGV2)
        Me.GroupBox2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, -2)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(491, 459)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "انتخاب کالا"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(255, 423)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 30)
        Me.Button2.TabIndex = 78
        Me.Button2.Text = "انتخاب پیشرفته"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Location = New System.Drawing.Point(372, 423)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(111, 30)
        Me.BtnSearch.TabIndex = 77
        Me.BtnSearch.Text = "جستجو"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(13, 428)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(77, 25)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "همه کالاها"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Id, Me.Cln_Name, Me.Cln_BarCode, Me.Cln_Select})
        Me.DGV2.Location = New System.Drawing.Point(13, 28)
        Me.DGV2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.Size = New System.Drawing.Size(470, 389)
        Me.DGV2.TabIndex = 1
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Id.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Id.HeaderText = "کد کالا"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Width = 80
        '
        'Cln_Name
        '
        Me.Cln_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Name.DataPropertyName = "Nam"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Name.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Name.HeaderText = "نام کالا"
        Me.Cln_Name.Name = "Cln_Name"
        Me.Cln_Name.ReadOnly = True
        Me.Cln_Name.Width = 177
        '
        'Cln_BarCode
        '
        Me.Cln_BarCode.DataPropertyName = "BarCode"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cln_BarCode.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_BarCode.HeaderText = "بار کد"
        Me.Cln_BarCode.Name = "Cln_BarCode"
        Me.Cln_BarCode.ReadOnly = True
        Me.Cln_BarCode.Width = 130
        '
        'Cln_Select
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle5.NullValue = False
        Me.Cln_Select.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Select.Width = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Rdo16)
        Me.GroupBox1.Controls.Add(Me.Rdo14)
        Me.GroupBox1.Controls.Add(Me.Rdo12)
        Me.GroupBox1.Controls.Add(Me.Rdo10)
        Me.GroupBox1.Controls.Add(Me.Rdo8)
        Me.GroupBox1.Location = New System.Drawing.Point(164, 463)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(333, 69)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "سايز بارکد"
        '
        'Rdo16
        '
        Me.Rdo16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo16.AutoSize = True
        Me.Rdo16.Location = New System.Drawing.Point(7, 27)
        Me.Rdo16.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdo16.Name = "Rdo16"
        Me.Rdo16.Size = New System.Drawing.Size(39, 25)
        Me.Rdo16.TabIndex = 12
        Me.Rdo16.TabStop = True
        Me.Rdo16.Text = "16"
        Me.Rdo16.UseVisualStyleBackColor = True
        '
        'Rdo14
        '
        Me.Rdo14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo14.AutoSize = True
        Me.Rdo14.Location = New System.Drawing.Point(79, 27)
        Me.Rdo14.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdo14.Name = "Rdo14"
        Me.Rdo14.Size = New System.Drawing.Size(37, 25)
        Me.Rdo14.TabIndex = 11
        Me.Rdo14.TabStop = True
        Me.Rdo14.Text = "14"
        Me.Rdo14.UseVisualStyleBackColor = True
        '
        'Rdo12
        '
        Me.Rdo12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo12.AutoSize = True
        Me.Rdo12.Location = New System.Drawing.Point(149, 27)
        Me.Rdo12.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdo12.Name = "Rdo12"
        Me.Rdo12.Size = New System.Drawing.Size(38, 25)
        Me.Rdo12.TabIndex = 10
        Me.Rdo12.TabStop = True
        Me.Rdo12.Text = "12"
        Me.Rdo12.UseVisualStyleBackColor = True
        '
        'Rdo10
        '
        Me.Rdo10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo10.AutoSize = True
        Me.Rdo10.Location = New System.Drawing.Point(222, 27)
        Me.Rdo10.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdo10.Name = "Rdo10"
        Me.Rdo10.Size = New System.Drawing.Size(36, 25)
        Me.Rdo10.TabIndex = 9
        Me.Rdo10.TabStop = True
        Me.Rdo10.Text = "10"
        Me.Rdo10.UseVisualStyleBackColor = True
        '
        'Rdo8
        '
        Me.Rdo8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo8.AutoSize = True
        Me.Rdo8.Checked = True
        Me.Rdo8.Location = New System.Drawing.Point(289, 27)
        Me.Rdo8.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdo8.Name = "Rdo8"
        Me.Rdo8.Size = New System.Drawing.Size(36, 25)
        Me.Rdo8.TabIndex = 8
        Me.Rdo8.TabStop = True
        Me.Rdo8.Text = "8"
        Me.Rdo8.UseVisualStyleBackColor = True
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel3.Text = "F2 تهیه گزارش"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(82, 24)
        Me.ToolStripStatusLabel6.Text = "F3 جستجوی کالا"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel9.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel9.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(92, 24)
        Me.ToolStripStatusLabel8.Text = "F4 انتخاب پیشرفته"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel8, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 603)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(506, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 75
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Num)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 463)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(150, 69)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 21)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "تعداد چاپ"
        '
        'Num
        '
        Me.Num.Enabled = False
        Me.Num.Location = New System.Drawing.Point(11, 27)
        Me.Num.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.Num.Name = "Num"
        Me.Num.Size = New System.Drawing.Size(66, 29)
        Me.Num.TabIndex = 76
        Me.Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Num.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(19, 0)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(126, 25)
        Me.CheckBox1.TabIndex = 79
        Me.CheckBox1.Text = "تعداد چاپ هر بارکد"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ChkCost
        '
        Me.ChkCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCost.AutoSize = True
        Me.ChkCost.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ChkCost.Location = New System.Drawing.Point(320, 538)
        Me.ChkCost.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkCost.Name = "ChkCost"
        Me.ChkCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkCost.Size = New System.Drawing.Size(169, 25)
        Me.ChkCost.TabIndex = 77
        Me.ChkCost.Text = "چاپ قیمت کالا در کنار بارکد"
        Me.ChkCost.UseVisualStyleBackColor = True
        '
        'Report_Kala_BarCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 632)
        Me.Controls.Add(Me.ChkCost)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "Report_Kala_BarCode"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تولید بارکد"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Num, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo8 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo16 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo14 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo12 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo10 As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Num As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCost As System.Windows.Forms.CheckBox
End Class
