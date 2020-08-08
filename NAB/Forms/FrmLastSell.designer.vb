<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLastSell
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rdodate = New System.Windows.Forms.RadioButton
        Me.Rdopay = New System.Windows.Forms.RadioButton
        Me.Rdoname = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ChkP = New System.Windows.Forms.CheckBox
        Me.ChkCity = New System.Windows.Forms.CheckBox
        Me.ChkPart = New System.Windows.Forms.CheckBox
        Me.CmbPart = New System.Windows.Forms.ComboBox
        Me.CmbCity = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbOstan = New System.Windows.Forms.ComboBox
        Me.TxtOstan = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSave = New System.Windows.Forms.Button
        Me.ChKOther = New System.Windows.Forms.CheckBox
        Me.ChkNoDate = New System.Windows.Forms.CheckBox
        Me.ChkDay = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkBes = New System.Windows.Forms.CheckBox
        Me.Chkbe = New System.Windows.Forms.CheckBox
        Me.Chkbed = New System.Windows.Forms.CheckBox
        Me.TxtMon2 = New System.Windows.Forms.TextBox
        Me.TxtMon1 = New System.Windows.Forms.TextBox
        Me.ChkTaMon = New System.Windows.Forms.CheckBox
        Me.ChkAzMon = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.ChkAll = New System.Windows.Forms.CheckBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_IdP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ChkNoMoein = New System.Windows.Forms.CheckBox
        Me.ChkActive = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rdodate)
        Me.GroupBox1.Controls.Add(Me.Rdopay)
        Me.GroupBox1.Controls.Add(Me.Rdoname)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(284, 72)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مرتب سازی بر اساس"
        '
        'Rdodate
        '
        Me.Rdodate.AutoSize = True
        Me.Rdodate.Location = New System.Drawing.Point(116, 28)
        Me.Rdodate.Name = "Rdodate"
        Me.Rdodate.Size = New System.Drawing.Size(53, 25)
        Me.Rdodate.TabIndex = 1
        Me.Rdodate.Text = "تاریخ"
        Me.Rdodate.UseVisualStyleBackColor = True
        '
        'Rdopay
        '
        Me.Rdopay.AutoSize = True
        Me.Rdopay.Location = New System.Drawing.Point(8, 28)
        Me.Rdopay.Name = "Rdopay"
        Me.Rdopay.Size = New System.Drawing.Size(90, 25)
        Me.Rdopay.TabIndex = 2
        Me.Rdopay.Text = "مانده حساب"
        Me.Rdopay.UseVisualStyleBackColor = True
        '
        'Rdoname
        '
        Me.Rdoname.AutoSize = True
        Me.Rdoname.Checked = True
        Me.Rdoname.Location = New System.Drawing.Point(186, 28)
        Me.Rdoname.Name = "Rdoname"
        Me.Rdoname.Size = New System.Drawing.Size(89, 25)
        Me.Rdoname.TabIndex = 0
        Me.Rdoname.TabStop = True
        Me.Rdoname.Text = "طرف حساب"
        Me.Rdoname.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkP)
        Me.GroupBox3.Controls.Add(Me.ChkCity)
        Me.GroupBox3.Controls.Add(Me.ChkPart)
        Me.GroupBox3.Controls.Add(Me.CmbPart)
        Me.GroupBox3.Controls.Add(Me.CmbCity)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.CmbOstan)
        Me.GroupBox3.Controls.Add(Me.TxtOstan)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(284, 95)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'ChkP
        '
        Me.ChkP.AutoSize = True
        Me.ChkP.Checked = True
        Me.ChkP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkP.Location = New System.Drawing.Point(82, 57)
        Me.ChkP.Name = "ChkP"
        Me.ChkP.Size = New System.Drawing.Size(55, 25)
        Me.ChkP.TabIndex = 10
        Me.ChkP.Text = "مسیر"
        Me.ChkP.UseVisualStyleBackColor = True
        '
        'ChkCity
        '
        Me.ChkCity.AutoSize = True
        Me.ChkCity.Checked = True
        Me.ChkCity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCity.Location = New System.Drawing.Point(227, 56)
        Me.ChkCity.Name = "ChkCity"
        Me.ChkCity.Size = New System.Drawing.Size(49, 25)
        Me.ChkCity.TabIndex = 8
        Me.ChkCity.Text = "شهر"
        Me.ChkCity.UseVisualStyleBackColor = True
        '
        'ChkPart
        '
        Me.ChkPart.AutoSize = True
        Me.ChkPart.Location = New System.Drawing.Point(164, -2)
        Me.ChkPart.Name = "ChkPart"
        Me.ChkPart.Size = New System.Drawing.Size(112, 25)
        Me.ChkPart.TabIndex = 6
        Me.ChkPart.Text = "محدوديت مناطق"
        Me.ChkPart.UseVisualStyleBackColor = True
        '
        'CmbPart
        '
        Me.CmbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPart.Enabled = False
        Me.CmbPart.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.Location = New System.Drawing.Point(6, 55)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbPart.Size = New System.Drawing.Size(76, 29)
        Me.CmbPart.TabIndex = 11
        '
        'CmbCity
        '
        Me.CmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCity.Enabled = False
        Me.CmbCity.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbCity.FormattingEnabled = True
        Me.CmbCity.Location = New System.Drawing.Point(141, 55)
        Me.CmbCity.Name = "CmbCity"
        Me.CmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbCity.Size = New System.Drawing.Size(86, 29)
        Me.CmbCity.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(244, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 21)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "استان"
        '
        'CmbOstan
        '
        Me.CmbOstan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOstan.Enabled = False
        Me.CmbOstan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbOstan.FormattingEnabled = True
        Me.CmbOstan.Location = New System.Drawing.Point(6, 24)
        Me.CmbOstan.Name = "CmbOstan"
        Me.CmbOstan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbOstan.Size = New System.Drawing.Size(221, 29)
        Me.CmbOstan.TabIndex = 7
        '
        'TxtOstan
        '
        Me.TxtOstan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOstan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtOstan.Location = New System.Drawing.Point(127, 24)
        Me.TxtOstan.MaxLength = 30
        Me.TxtOstan.Name = "TxtOstan"
        Me.TxtOstan.Size = New System.Drawing.Size(50, 29)
        Me.TxtOstan.TabIndex = 42
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 485)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(591, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 64
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel2.Text = "F2 تهیه گزارش"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'BtnSave
        '
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(191, 447)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(97, 30)
        Me.BtnSave.TabIndex = 21
        Me.BtnSave.Text = "تهیه گزارش"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'ChKOther
        '
        Me.ChKOther.AutoSize = True
        Me.ChKOther.Checked = True
        Me.ChKOther.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChKOther.Location = New System.Drawing.Point(39, 328)
        Me.ChKOther.Name = "ChKOther"
        Me.ChKOther.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChKOther.Size = New System.Drawing.Size(248, 25)
        Me.ChKOther.TabIndex = 19
        Me.ChKOther.Text = "طرف حساب با ماهیت سایر نمایش داده نشود"
        Me.ChKOther.UseVisualStyleBackColor = True
        '
        'ChkNoDate
        '
        Me.ChkNoDate.AutoSize = True
        Me.ChkNoDate.Checked = True
        Me.ChkNoDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkNoDate.Location = New System.Drawing.Point(28, 389)
        Me.ChkNoDate.Name = "ChkNoDate"
        Me.ChkNoDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkNoDate.Size = New System.Drawing.Size(259, 25)
        Me.ChkNoDate.TabIndex = 20
        Me.ChkNoDate.Text = "طرف حساب های بدون خرید  نمایش داده نشود"
        Me.ChkNoDate.UseVisualStyleBackColor = True
        '
        'ChkDay
        '
        Me.ChkDay.AutoSize = True
        Me.ChkDay.Location = New System.Drawing.Point(145, 0)
        Me.ChkDay.Name = "ChkDay"
        Me.ChkDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDay.Size = New System.Drawing.Size(131, 25)
        Me.ChkDay.TabIndex = 12
        Me.ChkDay.Text = "محدوديت عدم خرید"
        Me.ChkDay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkBes)
        Me.GroupBox2.Controls.Add(Me.Chkbe)
        Me.GroupBox2.Controls.Add(Me.Chkbed)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(284, 68)
        Me.GroupBox2.TabIndex = 66
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ماهيت طرف حساب"
        '
        'ChkBes
        '
        Me.ChkBes.AutoSize = True
        Me.ChkBes.Checked = True
        Me.ChkBes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBes.Location = New System.Drawing.Point(116, 29)
        Me.ChkBes.Name = "ChkBes"
        Me.ChkBes.Size = New System.Drawing.Size(68, 25)
        Me.ChkBes.TabIndex = 4
        Me.ChkBes.Text = "بستانکار"
        Me.ChkBes.UseVisualStyleBackColor = True
        '
        'Chkbe
        '
        Me.Chkbe.AutoSize = True
        Me.Chkbe.Checked = True
        Me.Chkbe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkbe.Location = New System.Drawing.Point(6, 29)
        Me.Chkbe.Name = "Chkbe"
        Me.Chkbe.Size = New System.Drawing.Size(76, 25)
        Me.Chkbe.TabIndex = 5
        Me.Chkbe.Text = "بی حساب"
        Me.Chkbe.UseVisualStyleBackColor = True
        '
        'Chkbed
        '
        Me.Chkbed.AutoSize = True
        Me.Chkbed.Checked = True
        Me.Chkbed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkbed.Location = New System.Drawing.Point(214, 29)
        Me.Chkbed.Name = "Chkbed"
        Me.Chkbed.Size = New System.Drawing.Size(62, 25)
        Me.Chkbed.TabIndex = 3
        Me.Chkbed.Text = "بدهکار"
        Me.Chkbed.UseVisualStyleBackColor = True
        '
        'TxtMon2
        '
        Me.TxtMon2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMon2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMon2.Enabled = False
        Me.TxtMon2.Location = New System.Drawing.Point(8, 28)
        Me.TxtMon2.MaxLength = 18
        Me.TxtMon2.Name = "TxtMon2"
        Me.TxtMon2.ShortcutsEnabled = False
        Me.TxtMon2.Size = New System.Drawing.Size(74, 29)
        Me.TxtMon2.TabIndex = 16
        Me.TxtMon2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMon1
        '
        Me.TxtMon1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMon1.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMon1.Enabled = False
        Me.TxtMon1.Location = New System.Drawing.Point(154, 28)
        Me.TxtMon1.MaxLength = 18
        Me.TxtMon1.Name = "TxtMon1"
        Me.TxtMon1.ShortcutsEnabled = False
        Me.TxtMon1.Size = New System.Drawing.Size(74, 29)
        Me.TxtMon1.TabIndex = 14
        Me.TxtMon1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkTaMon
        '
        Me.ChkTaMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaMon.AutoSize = True
        Me.ChkTaMon.Enabled = False
        Me.ChkTaMon.Location = New System.Drawing.Point(104, 30)
        Me.ChkTaMon.Name = "ChkTaMon"
        Me.ChkTaMon.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaMon.TabIndex = 15
        Me.ChkTaMon.Text = "تا"
        Me.ChkTaMon.UseVisualStyleBackColor = True
        '
        'ChkAzMon
        '
        Me.ChkAzMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzMon.AutoSize = True
        Me.ChkAzMon.Enabled = False
        Me.ChkAzMon.Location = New System.Drawing.Point(238, 30)
        Me.ChkAzMon.Name = "ChkAzMon"
        Me.ChkAzMon.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzMon.TabIndex = 13
        Me.ChkAzMon.Text = "از"
        Me.ChkAzMon.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtMon2)
        Me.GroupBox4.Controls.Add(Me.TxtMon1)
        Me.GroupBox4.Controls.Add(Me.ChkDay)
        Me.GroupBox4.Controls.Add(Me.ChkTaMon)
        Me.GroupBox4.Controls.Add(Me.ChkAzMon)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 254)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(284, 68)
        Me.GroupBox4.TabIndex = 67
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ChkAll)
        Me.GroupBox5.Controls.Add(Me.DGV)
        Me.GroupBox5.Enabled = False
        Me.GroupBox5.Location = New System.Drawing.Point(302, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(284, 466)
        Me.GroupBox5.TabIndex = 69
        Me.GroupBox5.TabStop = False
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(7, 436)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAll.Size = New System.Drawing.Size(48, 25)
        Me.ChkAll.TabIndex = 36
        Me.ChkAll.Text = "همه"
        Me.ChkAll.UseVisualStyleBackColor = True
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Nam, Me.Cln_Select, Me.Cln_IdP})
        Me.DGV.Location = New System.Drawing.Point(6, 31)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(270, 400)
        Me.DGV.TabIndex = 18
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Nam.HeaderText = "نام گروه"
        Me.Cln_Nam.Name = "Cln_Nam"
        Me.Cln_Nam.ReadOnly = True
        Me.Cln_Nam.Width = 177
        '
        'Cln_Select
        '
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Select.Width = 50
        '
        'Cln_IdP
        '
        Me.Cln_IdP.DataPropertyName = "Id"
        Me.Cln_IdP.HeaderText = "ID"
        Me.Cln_IdP.Name = "Cln_IdP"
        Me.Cln_IdP.ReadOnly = True
        Me.Cln_IdP.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(473, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(105, 25)
        Me.CheckBox1.TabIndex = 37
        Me.CheckBox1.Text = "محدوديت گروه"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ChkNoMoein
        '
        Me.ChkNoMoein.AutoSize = True
        Me.ChkNoMoein.Location = New System.Drawing.Point(79, 420)
        Me.ChkNoMoein.Name = "ChkNoMoein"
        Me.ChkNoMoein.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkNoMoein.Size = New System.Drawing.Size(208, 25)
        Me.ChkNoMoein.TabIndex = 70
        Me.ChkNoMoein.Text = "مانده طرف حساب نمایش داده نشود"
        Me.ChkNoMoein.UseVisualStyleBackColor = True
        '
        'ChkActive
        '
        Me.ChkActive.AutoSize = True
        Me.ChkActive.Checked = True
        Me.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActive.Location = New System.Drawing.Point(66, 358)
        Me.ChkActive.Name = "ChkActive"
        Me.ChkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkActive.Size = New System.Drawing.Size(221, 25)
        Me.ChkActive.TabIndex = 71
        Me.ChkActive.Text = "طرف حساب غیر فعال نمایش داده نشود"
        Me.ChkActive.UseVisualStyleBackColor = True
        '
        'FrmLastSell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 514)
        Me.Controls.Add(Me.ChkActive)
        Me.Controls.Add(Me.ChkNoMoein)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ChkNoDate)
        Me.Controls.Add(Me.ChKOther)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLastSell"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش پیگیری فروش"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdopay As System.Windows.Forms.RadioButton
    Friend WithEvents Rdoname As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPart As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbOstan As System.Windows.Forms.ComboBox
    Friend WithEvents TxtOstan As System.Windows.Forms.TextBox
    Friend WithEvents ChkP As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCity As System.Windows.Forms.CheckBox
    Friend WithEvents Rdodate As System.Windows.Forms.RadioButton
    Friend WithEvents ChKOther As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNoDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDay As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkBes As System.Windows.Forms.CheckBox
    Friend WithEvents Chkbe As System.Windows.Forms.CheckBox
    Friend WithEvents Chkbed As System.Windows.Forms.CheckBox
    Friend WithEvents TxtMon2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMon1 As System.Windows.Forms.TextBox
    Friend WithEvents ChkTaMon As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzMon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNoMoein As System.Windows.Forms.CheckBox
    Friend WithEvents ChkActive As System.Windows.Forms.CheckBox
End Class
