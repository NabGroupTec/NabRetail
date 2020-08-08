<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMojodyAnbar
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
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_AnbarNam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_KolCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_JozCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_IdAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnReport = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmbtwo = New System.Windows.Forms.ComboBox()
        Me.CmbOne = New System.Windows.Forms.ComboBox()
        Me.ChkGroup = New System.Windows.Forms.CheckBox()
        Me.ChkTwoGroup = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RdoP = New System.Windows.Forms.RadioButton()
        Me.RdoZ = New System.Windows.Forms.RadioButton()
        Me.RdoN = New System.Windows.Forms.RadioButton()
        Me.ChkMojody = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CmbAnbar = New System.Windows.Forms.ComboBox()
        Me.ChkAnbar = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnKardex = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ChkTime = New System.Windows.Forms.CheckBox()
        Me.ChkTaDate = New System.Windows.Forms.CheckBox()
        Me.ChkAzDate = New System.Windows.Forms.CheckBox()
        Me.FarsiDate1 = New FarsiDate.FarsiDate()
        Me.FarsiDate2 = New FarsiDate.FarsiDate()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Id, Me.Cln_Code, Me.Cln_Nam, Me.Cln_AnbarNam, Me.Cln_KolCount, Me.Cln_JozCount, Me.Cln_Active, Me.Cln_IdAnbar})
        Me.DGV.Location = New System.Drawing.Point(6, 26)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(754, 369)
        Me.DGV.TabIndex = 4
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Id.DefaultCellStyle = DataGridViewCellStyle23
        Me.Cln_Id.HeaderText = "کد"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Width = 80
        '
        'Cln_Code
        '
        Me.Cln_Code.DataPropertyName = "Ex_date"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Code.DefaultCellStyle = DataGridViewCellStyle24
        Me.Cln_Code.HeaderText = "کد دستی"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.ReadOnly = True
        Me.Cln_Code.Width = 90
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle25
        Me.Cln_Nam.HeaderText = "نام کالا"
        Me.Cln_Nam.Name = "Cln_Nam"
        Me.Cln_Nam.ReadOnly = True
        Me.Cln_Nam.Width = 271
        '
        'Cln_AnbarNam
        '
        Me.Cln_AnbarNam.DataPropertyName = "NamAnbar"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_AnbarNam.DefaultCellStyle = DataGridViewCellStyle26
        Me.Cln_AnbarNam.HeaderText = "انبار"
        Me.Cln_AnbarNam.Name = "Cln_AnbarNam"
        Me.Cln_AnbarNam.ReadOnly = True
        '
        'Cln_KolCount
        '
        Me.Cln_KolCount.DataPropertyName = "KolCount"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_KolCount.DefaultCellStyle = DataGridViewCellStyle27
        Me.Cln_KolCount.HeaderText = "تعداد کل"
        Me.Cln_KolCount.Name = "Cln_KolCount"
        Me.Cln_KolCount.ReadOnly = True
        Me.Cln_KolCount.Width = 80
        '
        'Cln_JozCount
        '
        Me.Cln_JozCount.DataPropertyName = "JozCount"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_JozCount.DefaultCellStyle = DataGridViewCellStyle28
        Me.Cln_JozCount.HeaderText = "تعداد جزء"
        Me.Cln_JozCount.Name = "Cln_JozCount"
        Me.Cln_JozCount.ReadOnly = True
        Me.Cln_JozCount.Width = 90
        '
        'Cln_Active
        '
        Me.Cln_Active.DataPropertyName = "Activ"
        Me.Cln_Active.HeaderText = "Active"
        Me.Cln_Active.Name = "Cln_Active"
        Me.Cln_Active.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Active.Visible = False
        '
        'Cln_IdAnbar
        '
        Me.Cln_IdAnbar.DataPropertyName = "Idanbar"
        Me.Cln_IdAnbar.HeaderText = "Idanbar"
        Me.Cln_IdAnbar.Name = "Cln_IdAnbar"
        Me.Cln_IdAnbar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DGV)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(767, 405)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "موجودی انبار"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 62
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(82, 24)
        Me.ToolStripStatusLabel4.Text = "F2 چاپ گزارش"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(59, 24)
        Me.ToolStripStatusLabel3.Text = "F3 جستجو"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel6.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(79, 24)
        Me.ToolStripStatusLabel5.Text = "F6 کاردکس کالا"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(136, 24)
        Me.ToolStripStatusLabel2.Text = "رنگ خاکستری :کالای غیر فعال"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'BtnReport
        '
        Me.BtnReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnReport.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnReport.Location = New System.Drawing.Point(194, 502)
        Me.BtnReport.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.Size = New System.Drawing.Size(86, 30)
        Me.BtnReport.TabIndex = 76
        Me.BtnReport.Text = "چاپ گزارش"
        Me.BtnReport.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(102, 502)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(86, 30)
        Me.BtnSearch.TabIndex = 78
        Me.BtnSearch.Text = "جستجو"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Cmbtwo)
        Me.GroupBox2.Controls.Add(Me.CmbOne)
        Me.GroupBox2.Controls.Add(Me.ChkGroup)
        Me.GroupBox2.Controls.Add(Me.ChkTwoGroup)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(353, 415)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(424, 63)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        '
        'Cmbtwo
        '
        Me.Cmbtwo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmbtwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbtwo.Enabled = False
        Me.Cmbtwo.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Cmbtwo.FormattingEnabled = True
        Me.Cmbtwo.Location = New System.Drawing.Point(6, 21)
        Me.Cmbtwo.Name = "Cmbtwo"
        Me.Cmbtwo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cmbtwo.Size = New System.Drawing.Size(161, 29)
        Me.Cmbtwo.TabIndex = 59
        '
        'CmbOne
        '
        Me.CmbOne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOne.Enabled = False
        Me.CmbOne.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbOne.FormattingEnabled = True
        Me.CmbOne.Location = New System.Drawing.Point(254, 21)
        Me.CmbOne.Name = "CmbOne"
        Me.CmbOne.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbOne.Size = New System.Drawing.Size(101, 29)
        Me.CmbOne.TabIndex = 58
        '
        'ChkGroup
        '
        Me.ChkGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkGroup.AutoSize = True
        Me.ChkGroup.Location = New System.Drawing.Point(316, 0)
        Me.ChkGroup.Name = "ChkGroup"
        Me.ChkGroup.Size = New System.Drawing.Size(99, 23)
        Me.ChkGroup.TabIndex = 57
        Me.ChkGroup.Text = "محدودیت گروه"
        Me.ChkGroup.UseVisualStyleBackColor = True
        '
        'ChkTwoGroup
        '
        Me.ChkTwoGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTwoGroup.AutoSize = True
        Me.ChkTwoGroup.Enabled = False
        Me.ChkTwoGroup.Location = New System.Drawing.Point(171, 24)
        Me.ChkTwoGroup.Name = "ChkTwoGroup"
        Me.ChkTwoGroup.Size = New System.Drawing.Size(77, 23)
        Me.ChkTwoGroup.TabIndex = 56
        Me.ChkTwoGroup.Text = "گروه فرعی"
        Me.ChkTwoGroup.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(355, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 21)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "گروه اصلی"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.RdoP)
        Me.GroupBox3.Controls.Add(Me.RdoZ)
        Me.GroupBox3.Controls.Add(Me.RdoN)
        Me.GroupBox3.Controls.Add(Me.ChkMojody)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 415)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(337, 63)
        Me.GroupBox3.TabIndex = 80
        Me.GroupBox3.TabStop = False
        '
        'RdoP
        '
        Me.RdoP.AutoSize = True
        Me.RdoP.Enabled = False
        Me.RdoP.Location = New System.Drawing.Point(9, 23)
        Me.RdoP.Name = "RdoP"
        Me.RdoP.Size = New System.Drawing.Size(88, 23)
        Me.RdoP.TabIndex = 62
        Me.RdoP.TabStop = True
        Me.RdoP.Text = "موجودی مثبت"
        Me.RdoP.UseVisualStyleBackColor = True
        '
        'RdoZ
        '
        Me.RdoZ.AutoSize = True
        Me.RdoZ.Enabled = False
        Me.RdoZ.Location = New System.Drawing.Point(124, 23)
        Me.RdoZ.Name = "RdoZ"
        Me.RdoZ.Size = New System.Drawing.Size(85, 23)
        Me.RdoZ.TabIndex = 61
        Me.RdoZ.TabStop = True
        Me.RdoZ.Text = "موجودی صفر"
        Me.RdoZ.UseVisualStyleBackColor = True
        '
        'RdoN
        '
        Me.RdoN.AutoSize = True
        Me.RdoN.Enabled = False
        Me.RdoN.Location = New System.Drawing.Point(236, 23)
        Me.RdoN.Name = "RdoN"
        Me.RdoN.Size = New System.Drawing.Size(86, 23)
        Me.RdoN.TabIndex = 60
        Me.RdoN.TabStop = True
        Me.RdoN.Text = "موجودی منفی"
        Me.RdoN.UseVisualStyleBackColor = True
        '
        'ChkMojody
        '
        Me.ChkMojody.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkMojody.AutoSize = True
        Me.ChkMojody.Location = New System.Drawing.Point(210, 0)
        Me.ChkMojody.Name = "ChkMojody"
        Me.ChkMojody.Size = New System.Drawing.Size(112, 23)
        Me.ChkMojody.TabIndex = 58
        Me.ChkMojody.Text = "محدودیت موجودی"
        Me.ChkMojody.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.CmbAnbar)
        Me.GroupBox4.Controls.Add(Me.ChkAnbar)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(564, 478)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(213, 63)
        Me.GroupBox4.TabIndex = 80
        Me.GroupBox4.TabStop = False
        '
        'CmbAnbar
        '
        Me.CmbAnbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAnbar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnbar.Enabled = False
        Me.CmbAnbar.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbAnbar.FormattingEnabled = True
        Me.CmbAnbar.Location = New System.Drawing.Point(6, 24)
        Me.CmbAnbar.Name = "CmbAnbar"
        Me.CmbAnbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbAnbar.Size = New System.Drawing.Size(138, 29)
        Me.CmbAnbar.TabIndex = 58
        '
        'ChkAnbar
        '
        Me.ChkAnbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAnbar.AutoSize = True
        Me.ChkAnbar.Location = New System.Drawing.Point(112, 0)
        Me.ChkAnbar.Name = "ChkAnbar"
        Me.ChkAnbar.Size = New System.Drawing.Size(92, 23)
        Me.ChkAnbar.TabIndex = 57
        Me.ChkAnbar.Text = "محدودیت انبار"
        Me.ChkAnbar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(158, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 21)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "نام انبار"
        '
        'BtnKardex
        '
        Me.BtnKardex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnKardex.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnKardex.Location = New System.Drawing.Point(10, 502)
        Me.BtnKardex.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnKardex.Name = "BtnKardex"
        Me.BtnKardex.Size = New System.Drawing.Size(86, 30)
        Me.BtnKardex.TabIndex = 82
        Me.BtnKardex.Text = "کاردکس کالا"
        Me.BtnKardex.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.ChkTime)
        Me.GroupBox5.Controls.Add(Me.ChkTaDate)
        Me.GroupBox5.Controls.Add(Me.ChkAzDate)
        Me.GroupBox5.Controls.Add(Me.FarsiDate1)
        Me.GroupBox5.Controls.Add(Me.FarsiDate2)
        Me.GroupBox5.Location = New System.Drawing.Point(286, 479)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(272, 62)
        Me.GroupBox5.TabIndex = 83
        Me.GroupBox5.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(166, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(100, 23)
        Me.ChkTime.TabIndex = 69
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(97, 28)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(34, 23)
        Me.ChkTaDate.TabIndex = 68
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(231, 28)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(35, 23)
        Me.ChkAzDate.TabIndex = 67
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(138, 25)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(86, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(4, 25)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(86, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'FrmMojodyAnbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 573)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.BtnKardex)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnReport)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "FrmMojodyAnbar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "موجودی انبار"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnReport As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTwoGroup As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMojody As System.Windows.Forms.CheckBox
    Friend WithEvents Cmbtwo As System.Windows.Forms.ComboBox
    Friend WithEvents CmbOne As System.Windows.Forms.ComboBox
    Friend WithEvents RdoP As System.Windows.Forms.RadioButton
    Friend WithEvents RdoZ As System.Windows.Forms.RadioButton
    Friend WithEvents RdoN As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbAnbar As System.Windows.Forms.ComboBox
    Friend WithEvents ChkAnbar As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnKardex As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_AnbarNam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_KolCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JozCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_IdAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
End Class
