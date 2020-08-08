<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDamage
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ChkAll = New System.Windows.Forms.CheckBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_OneGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_Active = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
        Me.BtnOk = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ChkSum = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RdoKala = New System.Windows.Forms.RadioButton
        Me.RdoMon = New System.Windows.Forms.RadioButton
        Me.Rdodate = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtPart = New System.Windows.Forms.TextBox
        Me.TxtIdPart = New System.Windows.Forms.TextBox
        Me.ChkPart = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAnbarNam = New System.Windows.Forms.TextBox
        Me.ChkAnbar = New System.Windows.Forms.CheckBox
        Me.TxtIdAnbar = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ChkAll)
        Me.GroupBox1.Controls.Add(Me.BtnSearch)
        Me.GroupBox1.Controls.Add(Me.DGV)
        Me.GroupBox1.Location = New System.Drawing.Point(356, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(426, 375)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "لیست کالا"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(191, 339)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 30)
        Me.Button2.TabIndex = 76
        Me.Button2.Text = "انتخاب پیشرفته"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(7, 343)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(84, 25)
        Me.ChkAll.TabIndex = 52
        Me.ChkAll.Text = "انتخاب همه"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Location = New System.Drawing.Point(308, 339)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(111, 30)
        Me.BtnSearch.TabIndex = 75
        Me.BtnSearch.Text = "جستجو"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_OneGroup, Me.Cln_Nam, Me.Cln_Id, Me.Cln_Select, Me.Cln_Active})
        Me.DGV.Location = New System.Drawing.Point(6, 28)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(414, 306)
        Me.DGV.TabIndex = 4
        '
        'Cln_OneGroup
        '
        Me.Cln_OneGroup.DataPropertyName = "GroupKala"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Cln_OneGroup.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_OneGroup.HeaderText = "گروه"
        Me.Cln_OneGroup.Name = "Cln_OneGroup"
        Me.Cln_OneGroup.ReadOnly = True
        Me.Cln_OneGroup.Width = 150
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle15
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkTime)
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 70)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(347, 76)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(231, -2)
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
        Me.ChkTaDate.Location = New System.Drawing.Point(127, 33)
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
        Me.ChkAzDate.Location = New System.Drawing.Point(303, 33)
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
        Me.FarsiDate1.Location = New System.Drawing.Point(188, 31)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(109, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(13, 31)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(109, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(251, 340)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(88, 30)
        Me.BtnOk.TabIndex = 72
        Me.BtnOk.Text = "تهیه گزارش"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel8, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 384)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(789, 29)
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
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(107, 24)
        Me.ToolStripStatusLabel8.Text = "F4 انتخاب پیشرفته کالا"
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
        'ChkSum
        '
        Me.ChkSum.AutoSize = True
        Me.ChkSum.Location = New System.Drawing.Point(19, 310)
        Me.ChkSum.Name = "ChkSum"
        Me.ChkSum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkSum.Size = New System.Drawing.Size(323, 25)
        Me.ChkSum.TabIndex = 76
        Me.ChkSum.Text = "جمع تعداد کالا و میانگین قیمت ضایعات و جمع کل محاسبه شود"
        Me.ChkSum.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RdoKala)
        Me.GroupBox4.Controls.Add(Me.RdoMon)
        Me.GroupBox4.Controls.Add(Me.Rdodate)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(347, 67)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "مرتب سازی بر اساس"
        '
        'RdoKala
        '
        Me.RdoKala.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoKala.AutoSize = True
        Me.RdoKala.Location = New System.Drawing.Point(17, 25)
        Me.RdoKala.Name = "RdoKala"
        Me.RdoKala.Size = New System.Drawing.Size(44, 25)
        Me.RdoKala.TabIndex = 3
        Me.RdoKala.Text = "کالا"
        Me.RdoKala.UseVisualStyleBackColor = True
        '
        'RdoMon
        '
        Me.RdoMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoMon.AutoSize = True
        Me.RdoMon.Location = New System.Drawing.Point(152, 25)
        Me.RdoMon.Name = "RdoMon"
        Me.RdoMon.Size = New System.Drawing.Size(48, 25)
        Me.RdoMon.TabIndex = 2
        Me.RdoMon.Text = "مبلغ"
        Me.RdoMon.UseVisualStyleBackColor = True
        '
        'Rdodate
        '
        Me.Rdodate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdodate.AutoSize = True
        Me.Rdodate.Checked = True
        Me.Rdodate.Location = New System.Drawing.Point(287, 25)
        Me.Rdodate.Name = "Rdodate"
        Me.Rdodate.Size = New System.Drawing.Size(53, 25)
        Me.Rdodate.TabIndex = 0
        Me.Rdodate.TabStop = True
        Me.Rdodate.Text = "تاریخ"
        Me.Rdodate.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtPart)
        Me.GroupBox2.Controls.Add(Me.TxtIdPart)
        Me.GroupBox2.Controls.Add(Me.ChkPart)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(347, 78)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        '
        'TxtPart
        '
        Me.TxtPart.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPart.Enabled = False
        Me.TxtPart.Location = New System.Drawing.Point(6, 33)
        Me.TxtPart.MaxLength = 50
        Me.TxtPart.Name = "TxtPart"
        Me.TxtPart.ShortcutsEnabled = False
        Me.TxtPart.Size = New System.Drawing.Size(279, 29)
        Me.TxtPart.TabIndex = 79
        '
        'TxtIdPart
        '
        Me.TxtIdPart.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdPart.Location = New System.Drawing.Point(218, 33)
        Me.TxtIdPart.MaxLength = 50
        Me.TxtIdPart.Name = "TxtIdPart"
        Me.TxtIdPart.ReadOnly = True
        Me.TxtIdPart.ShortcutsEnabled = False
        Me.TxtIdPart.Size = New System.Drawing.Size(27, 29)
        Me.TxtIdPart.TabIndex = 80
        '
        'ChkPart
        '
        Me.ChkPart.AutoSize = True
        Me.ChkPart.Location = New System.Drawing.Point(233, 0)
        Me.ChkPart.Name = "ChkPart"
        Me.ChkPart.Size = New System.Drawing.Size(107, 25)
        Me.ChkPart.TabIndex = 69
        Me.ChkPart.Text = "محدودیت پارت"
        Me.ChkPart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(291, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 21)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "پارت"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.TxtAnbarNam)
        Me.GroupBox6.Controls.Add(Me.ChkAnbar)
        Me.GroupBox6.Controls.Add(Me.TxtIdAnbar)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 228)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox6.Size = New System.Drawing.Size(347, 75)
        Me.GroupBox6.TabIndex = 89
        Me.GroupBox6.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 21)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "انبار"
        '
        'TxtAnbarNam
        '
        Me.TxtAnbarNam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAnbarNam.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAnbarNam.Enabled = False
        Me.TxtAnbarNam.Location = New System.Drawing.Point(7, 33)
        Me.TxtAnbarNam.Name = "TxtAnbarNam"
        Me.TxtAnbarNam.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAnbarNam.ShortcutsEnabled = False
        Me.TxtAnbarNam.Size = New System.Drawing.Size(281, 29)
        Me.TxtAnbarNam.TabIndex = 66
        '
        'ChkAnbar
        '
        Me.ChkAnbar.AutoSize = True
        Me.ChkAnbar.Location = New System.Drawing.Point(236, 7)
        Me.ChkAnbar.Name = "ChkAnbar"
        Me.ChkAnbar.Size = New System.Drawing.Size(101, 25)
        Me.ChkAnbar.TabIndex = 13
        Me.ChkAnbar.Text = "محدوديت انبار"
        Me.ChkAnbar.UseVisualStyleBackColor = True
        '
        'TxtIdAnbar
        '
        Me.TxtIdAnbar.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdAnbar.Location = New System.Drawing.Point(55, 33)
        Me.TxtIdAnbar.Name = "TxtIdAnbar"
        Me.TxtIdAnbar.ReadOnly = True
        Me.TxtIdAnbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdAnbar.ShortcutsEnabled = False
        Me.TxtIdAnbar.Size = New System.Drawing.Size(52, 29)
        Me.TxtIdAnbar.TabIndex = 68
        Me.TxtIdAnbar.Visible = False
        '
        'ReportDamage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 413)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ChkSum)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "ReportDamage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش ضایعات کالا"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSum As System.Windows.Forms.CheckBox
    Friend WithEvents Cln_OneGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoMon As System.Windows.Forms.RadioButton
    Friend WithEvents Rdodate As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RdoKala As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPart As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdPart As System.Windows.Forms.TextBox
    Friend WithEvents ChkPart As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAnbarNam As System.Windows.Forms.TextBox
    Friend WithEvents ChkAnbar As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdAnbar As System.Windows.Forms.TextBox
End Class
