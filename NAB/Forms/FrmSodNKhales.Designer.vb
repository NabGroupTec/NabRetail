﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSodNKhales
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.ChkActive = New System.Windows.Forms.CheckBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Cln_OneGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_Active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkZ = New System.Windows.Forms.CheckBox()
        Me.ChkZyan = New System.Windows.Forms.CheckBox()
        Me.ChkSod = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkTime = New System.Windows.Forms.CheckBox()
        Me.ChkTaDate = New System.Windows.Forms.CheckBox()
        Me.ChkAzDate = New System.Windows.Forms.CheckBox()
        Me.FarsiDate1 = New FarsiDate.FarsiDate()
        Me.FarsiDate2 = New FarsiDate.FarsiDate()
        Me.ChkDiscount = New System.Windows.Forms.CheckBox()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ChkNo = New System.Windows.Forms.CheckBox()
        Me.ChkGroup = New System.Windows.Forms.CheckBox()
        Me.RdoOne = New System.Windows.Forms.RadioButton()
        Me.RdoTwo = New System.Windows.Forms.RadioButton()
        Me.ChkCharge = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ChkAll)
        Me.GroupBox1.Controls.Add(Me.BtnSearch)
        Me.GroupBox1.Controls.Add(Me.ChkActive)
        Me.GroupBox1.Controls.Add(Me.DGV)
        Me.GroupBox1.Location = New System.Drawing.Point(246, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(426, 420)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "لیست کالا"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(193, 385)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 30)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "جستجوی پیشرفته"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(6, 385)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(84, 25)
        Me.ChkAll.TabIndex = 52
        Me.ChkAll.Text = "انتخاب همه"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Location = New System.Drawing.Point(310, 385)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(111, 30)
        Me.BtnSearch.TabIndex = 75
        Me.BtnSearch.Text = "جستجوی کالا"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'ChkActive
        '
        Me.ChkActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkActive.AutoSize = True
        Me.ChkActive.Checked = True
        Me.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActive.Location = New System.Drawing.Point(227, 19)
        Me.ChkActive.Name = "ChkActive"
        Me.ChkActive.Size = New System.Drawing.Size(190, 25)
        Me.ChkActive.TabIndex = 51
        Me.ChkActive.Text = "کالاهای غیر فعال نمایش داده شود"
        Me.ChkActive.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_OneGroup, Me.Cln_Nam, Me.Cln_Id, Me.Cln_Select, Me.Cln_Active})
        Me.DGV.Location = New System.Drawing.Point(6, 50)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(414, 329)
        Me.DGV.TabIndex = 4
        '
        'Cln_OneGroup
        '
        Me.Cln_OneGroup.DataPropertyName = "GroupKala"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Cln_OneGroup.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_OneGroup.HeaderText = "گروه"
        Me.Cln_OneGroup.Name = "Cln_OneGroup"
        Me.Cln_OneGroup.ReadOnly = True
        Me.Cln_OneGroup.Width = 150
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Nam.HeaderText = "نام کالا"
        Me.Cln_Nam.Name = "Cln_Nam"
        Me.Cln_Nam.ReadOnly = True
        Me.Cln_Nam.Width = 170
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        Me.Cln_Id.HeaderText = "ID"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Visible = False
        '
        'Cln_Select
        '
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Select.Width = 50
        '
        'Cln_Active
        '
        Me.Cln_Active.DataPropertyName = "Activ"
        Me.Cln_Active.HeaderText = "Active"
        Me.Cln_Active.Name = "Cln_Active"
        Me.Cln_Active.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkZ)
        Me.GroupBox2.Controls.Add(Me.ChkZyan)
        Me.GroupBox2.Controls.Add(Me.ChkSod)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(228, 83)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "نوع سود ناخالص"
        '
        'ChkZ
        '
        Me.ChkZ.AutoSize = True
        Me.ChkZ.Checked = True
        Me.ChkZ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkZ.Location = New System.Drawing.Point(6, 34)
        Me.ChkZ.Name = "ChkZ"
        Me.ChkZ.Size = New System.Drawing.Size(50, 25)
        Me.ChkZ.TabIndex = 8
        Me.ChkZ.Text = "صفر"
        Me.ChkZ.UseVisualStyleBackColor = True
        '
        'ChkZyan
        '
        Me.ChkZyan.AutoSize = True
        Me.ChkZyan.Checked = True
        Me.ChkZyan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkZyan.Location = New System.Drawing.Point(88, 34)
        Me.ChkZyan.Name = "ChkZyan"
        Me.ChkZyan.Size = New System.Drawing.Size(50, 25)
        Me.ChkZyan.TabIndex = 7
        Me.ChkZyan.Text = "زیان"
        Me.ChkZyan.UseVisualStyleBackColor = True
        '
        'ChkSod
        '
        Me.ChkSod.AutoSize = True
        Me.ChkSod.Checked = True
        Me.ChkSod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSod.Location = New System.Drawing.Point(168, 34)
        Me.ChkSod.Name = "ChkSod"
        Me.ChkSod.Size = New System.Drawing.Size(50, 25)
        Me.ChkSod.TabIndex = 6
        Me.ChkSod.Text = "سود"
        Me.ChkSod.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkTime)
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(228, 113)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(109, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(109, 25)
        Me.ChkTime.TabIndex = 69
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(182, 67)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 68
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(181, 36)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 67
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(26, 34)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(148, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(26, 65)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(148, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'ChkDiscount
        '
        Me.ChkDiscount.AutoSize = True
        Me.ChkDiscount.Checked = True
        Me.ChkDiscount.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDiscount.Location = New System.Drawing.Point(19, 221)
        Me.ChkDiscount.Name = "ChkDiscount"
        Me.ChkDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDiscount.Size = New System.Drawing.Size(211, 25)
        Me.ChkDiscount.TabIndex = 71
        Me.ChkDiscount.Text = "تخفیفات حجمی فاکتور  تاثیر داده شود"
        Me.ChkDiscount.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(119, 384)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(111, 30)
        Me.BtnOk.TabIndex = 72
        Me.BtnOk.Text = "تهیه گزارش"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 427)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(677, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 74
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(103, 24)
        Me.ToolStripStatusLabel2.Text = "F4 جستجوی پیشرفته"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel4.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(133, 24)
        Me.ToolStripStatusLabel5.Text = "رنگ خاکستری:کالای غیر فعال"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'ChkNo
        '
        Me.ChkNo.AutoSize = True
        Me.ChkNo.Location = New System.Drawing.Point(38, 283)
        Me.ChkNo.Name = "ChkNo"
        Me.ChkNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkNo.Size = New System.Drawing.Size(192, 25)
        Me.ChkNo.TabIndex = 76
        Me.ChkNo.Text = "عدم نمایش کالاهای استفاده نشده"
        Me.ChkNo.UseVisualStyleBackColor = True
        '
        'ChkGroup
        '
        Me.ChkGroup.AutoSize = True
        Me.ChkGroup.Location = New System.Drawing.Point(45, 314)
        Me.ChkGroup.Name = "ChkGroup"
        Me.ChkGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkGroup.Size = New System.Drawing.Size(185, 25)
        Me.ChkGroup.TabIndex = 77
        Me.ChkGroup.Text = "تفکیک سود و زیان بر اساس گروه"
        Me.ChkGroup.UseVisualStyleBackColor = True
        '
        'RdoOne
        '
        Me.RdoOne.AutoSize = True
        Me.RdoOne.Enabled = False
        Me.RdoOne.Location = New System.Drawing.Point(127, 341)
        Me.RdoOne.Name = "RdoOne"
        Me.RdoOne.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoOne.Size = New System.Drawing.Size(78, 25)
        Me.RdoOne.TabIndex = 78
        Me.RdoOne.TabStop = True
        Me.RdoOne.Text = "گروه اصلی"
        Me.RdoOne.UseVisualStyleBackColor = True
        '
        'RdoTwo
        '
        Me.RdoTwo.AutoSize = True
        Me.RdoTwo.Enabled = False
        Me.RdoTwo.Location = New System.Drawing.Point(41, 341)
        Me.RdoTwo.Name = "RdoTwo"
        Me.RdoTwo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoTwo.Size = New System.Drawing.Size(80, 25)
        Me.RdoTwo.TabIndex = 79
        Me.RdoTwo.TabStop = True
        Me.RdoTwo.Text = "گروه فرعی"
        Me.RdoTwo.UseVisualStyleBackColor = True
        '
        'ChkCharge
        '
        Me.ChkCharge.AutoSize = True
        Me.ChkCharge.Checked = True
        Me.ChkCharge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCharge.Location = New System.Drawing.Point(40, 252)
        Me.ChkCharge.Name = "ChkCharge"
        Me.ChkCharge.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkCharge.Size = New System.Drawing.Size(190, 25)
        Me.ChkCharge.TabIndex = 80
        Me.ChkCharge.Text = "هزینه فاکتور خرید تاثیر داده شود"
        Me.ChkCharge.UseVisualStyleBackColor = True
        '
        'FrmSodNKhales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 456)
        Me.Controls.Add(Me.ChkCharge)
        Me.Controls.Add(Me.RdoTwo)
        Me.Controls.Add(Me.RdoOne)
        Me.Controls.Add(Me.ChkGroup)
        Me.Controls.Add(Me.ChkNo)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.ChkDiscount)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmSodNKhales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سود و زیان ناخالص"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkZyan As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSod As System.Windows.Forms.CheckBox
    Friend WithEvents ChkZ As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents ChkDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ChkActive As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNo As System.Windows.Forms.CheckBox
    Friend WithEvents Cln_OneGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ChkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents RdoOne As System.Windows.Forms.RadioButton
    Friend WithEvents RdoTwo As System.Windows.Forms.RadioButton
    Friend WithEvents ChkCharge As System.Windows.Forms.CheckBox
End Class
