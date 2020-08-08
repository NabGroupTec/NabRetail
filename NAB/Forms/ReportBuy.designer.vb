<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportBuy
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.ChkAmani = New System.Windows.Forms.CheckBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ChkSum = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RdoKala = New System.Windows.Forms.RadioButton
        Me.RdoMon = New System.Windows.Forms.RadioButton
        Me.RdoP = New System.Windows.Forms.RadioButton
        Me.Rdodate = New System.Windows.Forms.RadioButton
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.ChkAllp = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Cln_NamP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_SelectP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_ActiveP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.RdoGroup = New System.Windows.Forms.RadioButton
        Me.RdoListKala = New System.Windows.Forms.RadioButton
        Me.RdoPeople = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtPart = New System.Windows.Forms.TextBox
        Me.TxtIdPart = New System.Windows.Forms.TextBox
        Me.ChkPart = New System.Windows.Forms.CheckBox
        Me.RdoPeopleGroup = New System.Windows.Forms.RadioButton
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAnbarNam = New System.Windows.Forms.TextBox
        Me.ChkAnbar = New System.Windows.Forms.CheckBox
        Me.TxtIdAnbar = New System.Windows.Forms.TextBox
        Me.Chkdiscount = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Size = New System.Drawing.Size(426, 394)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "لیست کالا"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(191, 358)
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
        Me.ChkAll.Location = New System.Drawing.Point(7, 362)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(84, 25)
        Me.ChkAll.TabIndex = 52
        Me.ChkAll.Text = "انتخاب همه"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Location = New System.Drawing.Point(308, 358)
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_OneGroup, Me.Cln_Nam, Me.Cln_Id, Me.Cln_Select, Me.Cln_Active})
        Me.DGV.Location = New System.Drawing.Point(6, 28)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(414, 325)
        Me.DGV.TabIndex = 4
        '
        'Cln_OneGroup
        '
        Me.Cln_OneGroup.DataPropertyName = "GroupKala"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Cln_OneGroup.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_OneGroup.HeaderText = "گروه"
        Me.Cln_OneGroup.Name = "Cln_OneGroup"
        Me.Cln_OneGroup.ReadOnly = True
        Me.Cln_OneGroup.Width = 150
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle8
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
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ChkTime)
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(514, 403)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(268, 60)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(152, -2)
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
        Me.ChkTaDate.Location = New System.Drawing.Point(95, 26)
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
        Me.ChkAzDate.Location = New System.Drawing.Point(224, 26)
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
        Me.FarsiDate1.Location = New System.Drawing.Point(134, 24)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(89, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(4, 24)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(89, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'ChkAmani
        '
        Me.ChkAmani.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAmani.AutoSize = True
        Me.ChkAmani.Location = New System.Drawing.Point(150, 465)
        Me.ChkAmani.Name = "ChkAmani"
        Me.ChkAmani.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAmani.Size = New System.Drawing.Size(199, 25)
        Me.ChkAmani.TabIndex = 71
        Me.ChkAmani.Text = "فقط فاکتور خرید امانی محاسبه شود"
        Me.ChkAmani.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(694, 539)
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel8, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 571)
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(123, 24)
        Me.ToolStripStatusLabel2.Text = "F4 جستجوی طرف حساب"
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
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(107, 24)
        Me.ToolStripStatusLabel8.Text = "F6 انتخاب پیشرفته کالا"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(148, 24)
        Me.ToolStripStatusLabel4.Text = "F7 انتخاب پیشرفته طرف حساب"
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
        Me.ChkSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkSum.AutoSize = True
        Me.ChkSum.Location = New System.Drawing.Point(38, 504)
        Me.ChkSum.Name = "ChkSum"
        Me.ChkSum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkSum.Size = New System.Drawing.Size(311, 25)
        Me.ChkSum.TabIndex = 76
        Me.ChkSum.Text = "جمع تعداد کالا و میانگین قیمت خرید و جمع کل محاسبه شود"
        Me.ChkSum.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.RdoKala)
        Me.GroupBox4.Controls.Add(Me.RdoMon)
        Me.GroupBox4.Controls.Add(Me.RdoP)
        Me.GroupBox4.Controls.Add(Me.Rdodate)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 403)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(347, 60)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "مرتب سازی بر اساس"
        '
        'RdoKala
        '
        Me.RdoKala.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoKala.AutoSize = True
        Me.RdoKala.Location = New System.Drawing.Point(119, 24)
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
        Me.RdoMon.Location = New System.Drawing.Point(191, 25)
        Me.RdoMon.Name = "RdoMon"
        Me.RdoMon.Size = New System.Drawing.Size(48, 25)
        Me.RdoMon.TabIndex = 2
        Me.RdoMon.Text = "مبلغ"
        Me.RdoMon.UseVisualStyleBackColor = True
        '
        'RdoP
        '
        Me.RdoP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoP.AutoSize = True
        Me.RdoP.Location = New System.Drawing.Point(3, 25)
        Me.RdoP.Name = "RdoP"
        Me.RdoP.Size = New System.Drawing.Size(89, 25)
        Me.RdoP.TabIndex = 1
        Me.RdoP.Text = "طرف حساب"
        Me.RdoP.UseVisualStyleBackColor = True
        '
        'Rdodate
        '
        Me.Rdodate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdodate.AutoSize = True
        Me.Rdodate.Checked = True
        Me.Rdodate.Location = New System.Drawing.Point(259, 25)
        Me.Rdodate.Name = "Rdodate"
        Me.Rdodate.Size = New System.Drawing.Size(81, 25)
        Me.Rdodate.TabIndex = 0
        Me.Rdodate.TabStop = True
        Me.Rdodate.Text = "تاریخ خرید"
        Me.Rdodate.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.ChkAllp)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.DGV2)
        Me.GroupBox5.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(347, 394)
        Me.GroupBox5.TabIndex = 76
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "لیست طرف حساب"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(112, 358)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 30)
        Me.Button3.TabIndex = 77
        Me.Button3.Text = "انتخاب پیشرفته"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ChkAllp
        '
        Me.ChkAllp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAllp.AutoSize = True
        Me.ChkAllp.Location = New System.Drawing.Point(8, 362)
        Me.ChkAllp.Name = "ChkAllp"
        Me.ChkAllp.Size = New System.Drawing.Size(84, 25)
        Me.ChkAllp.TabIndex = 52
        Me.ChkAllp.Text = "انتخاب همه"
        Me.ChkAllp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(229, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 30)
        Me.Button1.TabIndex = 75
        Me.Button1.Text = "جستجو"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_NamP, Me.Cln_IdP, Me.Cln_SelectP, Me.Cln_ActiveP})
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(335, 325)
        Me.DGV2.TabIndex = 4
        '
        'Cln_NamP
        '
        Me.Cln_NamP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_NamP.DataPropertyName = "Nam"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamP.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_NamP.HeaderText = "نام طرف حساب"
        Me.Cln_NamP.Name = "Cln_NamP"
        Me.Cln_NamP.ReadOnly = True
        Me.Cln_NamP.Width = 242
        '
        'Cln_IdP
        '
        Me.Cln_IdP.DataPropertyName = "Id"
        Me.Cln_IdP.HeaderText = "ID"
        Me.Cln_IdP.Name = "Cln_IdP"
        Me.Cln_IdP.ReadOnly = True
        Me.Cln_IdP.Visible = False
        '
        'Cln_SelectP
        '
        Me.Cln_SelectP.HeaderText = "انتخاب"
        Me.Cln_SelectP.Name = "Cln_SelectP"
        Me.Cln_SelectP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_SelectP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_SelectP.Width = 50
        '
        'Cln_ActiveP
        '
        Me.Cln_ActiveP.DataPropertyName = "Activ"
        Me.Cln_ActiveP.HeaderText = "Active"
        Me.Cln_ActiveP.Name = "Cln_ActiveP"
        Me.Cln_ActiveP.Visible = False
        '
        'RdoGroup
        '
        Me.RdoGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RdoGroup.AutoSize = True
        Me.RdoGroup.Location = New System.Drawing.Point(42, 547)
        Me.RdoGroup.Name = "RdoGroup"
        Me.RdoGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoGroup.Size = New System.Drawing.Size(102, 25)
        Me.RdoGroup.TabIndex = 81
        Me.RdoGroup.Text = "به ازای هر گروه"
        Me.RdoGroup.UseVisualStyleBackColor = True
        '
        'RdoListKala
        '
        Me.RdoListKala.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RdoListKala.AutoSize = True
        Me.RdoListKala.Location = New System.Drawing.Point(49, 526)
        Me.RdoListKala.Name = "RdoListKala"
        Me.RdoListKala.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoListKala.Size = New System.Drawing.Size(95, 25)
        Me.RdoListKala.TabIndex = 80
        Me.RdoListKala.Text = "به ازای هر کالا"
        Me.RdoListKala.UseVisualStyleBackColor = True
        '
        'RdoPeople
        '
        Me.RdoPeople.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RdoPeople.AutoSize = True
        Me.RdoPeople.Location = New System.Drawing.Point(157, 526)
        Me.RdoPeople.Name = "RdoPeople"
        Me.RdoPeople.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoPeople.Size = New System.Drawing.Size(164, 25)
        Me.RdoPeople.TabIndex = 79
        Me.RdoPeople.Text = "به ازای هر طرف حساب(کالا)"
        Me.RdoPeople.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TxtPart)
        Me.GroupBox2.Controls.Add(Me.TxtIdPart)
        Me.GroupBox2.Controls.Add(Me.ChkPart)
        Me.GroupBox2.Location = New System.Drawing.Point(356, 403)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(155, 60)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        '
        'TxtPart
        '
        Me.TxtPart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPart.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPart.Enabled = False
        Me.TxtPart.Location = New System.Drawing.Point(6, 24)
        Me.TxtPart.MaxLength = 50
        Me.TxtPart.Name = "TxtPart"
        Me.TxtPart.ShortcutsEnabled = False
        Me.TxtPart.Size = New System.Drawing.Size(143, 29)
        Me.TxtPart.TabIndex = 79
        '
        'TxtIdPart
        '
        Me.TxtIdPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdPart.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdPart.Location = New System.Drawing.Point(99, 24)
        Me.TxtIdPart.MaxLength = 50
        Me.TxtIdPart.Name = "TxtIdPart"
        Me.TxtIdPart.ReadOnly = True
        Me.TxtIdPart.ShortcutsEnabled = False
        Me.TxtIdPart.Size = New System.Drawing.Size(27, 29)
        Me.TxtIdPart.TabIndex = 80
        '
        'ChkPart
        '
        Me.ChkPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkPart.AutoSize = True
        Me.ChkPart.Location = New System.Drawing.Point(42, -2)
        Me.ChkPart.Name = "ChkPart"
        Me.ChkPart.Size = New System.Drawing.Size(107, 25)
        Me.ChkPart.TabIndex = 69
        Me.ChkPart.Text = "محدودیت پارت"
        Me.ChkPart.UseVisualStyleBackColor = True
        '
        'RdoPeopleGroup
        '
        Me.RdoPeopleGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RdoPeopleGroup.AutoSize = True
        Me.RdoPeopleGroup.Location = New System.Drawing.Point(150, 547)
        Me.RdoPeopleGroup.Name = "RdoPeopleGroup"
        Me.RdoPeopleGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoPeopleGroup.Size = New System.Drawing.Size(171, 25)
        Me.RdoPeopleGroup.TabIndex = 83
        Me.RdoPeopleGroup.Text = "به ازای هر طرف حساب(گروه)"
        Me.RdoPeopleGroup.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.TxtAnbarNam)
        Me.GroupBox6.Controls.Add(Me.ChkAnbar)
        Me.GroupBox6.Controls.Add(Me.TxtIdAnbar)
        Me.GroupBox6.Location = New System.Drawing.Point(356, 462)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox6.Size = New System.Drawing.Size(426, 75)
        Me.GroupBox6.TabIndex = 89
        Me.GroupBox6.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(382, 36)
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
        Me.TxtAnbarNam.Size = New System.Drawing.Size(360, 29)
        Me.TxtAnbarNam.TabIndex = 66
        '
        'ChkAnbar
        '
        Me.ChkAnbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAnbar.AutoSize = True
        Me.ChkAnbar.Location = New System.Drawing.Point(315, 7)
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
        'Chkdiscount
        '
        Me.Chkdiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chkdiscount.AutoSize = True
        Me.Chkdiscount.Location = New System.Drawing.Point(132, 484)
        Me.Chkdiscount.Name = "Chkdiscount"
        Me.Chkdiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chkdiscount.Size = New System.Drawing.Size(217, 25)
        Me.Chkdiscount.TabIndex = 90
        Me.Chkdiscount.Text = "فقط کالاهای جایزه دار نمایش داده شود"
        Me.Chkdiscount.UseVisualStyleBackColor = True
        '
        'ReportBuy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 600)
        Me.Controls.Add(Me.Chkdiscount)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.RdoPeopleGroup)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.RdoGroup)
        Me.Controls.Add(Me.RdoListKala)
        Me.Controls.Add(Me.RdoPeople)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ChkSum)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.ChkAmani)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "ReportBuy"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش خرید کالا"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ChkAmani As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
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
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoMon As System.Windows.Forms.RadioButton
    Friend WithEvents RdoP As System.Windows.Forms.RadioButton
    Friend WithEvents Rdodate As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkAllp As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Cln_NamP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_SelectP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_ActiveP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RdoKala As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RdoGroup As System.Windows.Forms.RadioButton
    Friend WithEvents RdoListKala As System.Windows.Forms.RadioButton
    Friend WithEvents RdoPeople As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPart As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdPart As System.Windows.Forms.TextBox
    Friend WithEvents ChkPart As System.Windows.Forms.CheckBox
    Friend WithEvents RdoPeopleGroup As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAnbarNam As System.Windows.Forms.TextBox
    Friend WithEvents ChkAnbar As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdAnbar As System.Windows.Forms.TextBox
    Friend WithEvents Chkdiscount As System.Windows.Forms.CheckBox
End Class
