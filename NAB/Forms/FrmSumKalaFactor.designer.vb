<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSumKalaFactor
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnReport = New System.Windows.Forms.Button
        Me.TxtFac2 = New System.Windows.Forms.TextBox
        Me.TxtFac1 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkTaFactor = New System.Windows.Forms.CheckBox
        Me.ChKfactor = New System.Windows.Forms.CheckBox
        Me.ChkAzFactor = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
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
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ChkAll = New System.Windows.Forms.CheckBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_Fac = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_People = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.RdoKala = New System.Windows.Forms.RadioButton
        Me.RdoGroup = New System.Windows.Forms.RadioButton
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkExit = New System.Windows.Forms.CheckBox
        Me.TxtExit = New System.Windows.Forms.TextBox
        Me.ChkW = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.RdoFrosh = New System.Windows.Forms.RadioButton
        Me.RdoBack = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnReport
        '
        Me.BtnReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReport.Location = New System.Drawing.Point(624, 505)
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.Size = New System.Drawing.Size(87, 31)
        Me.BtnReport.TabIndex = 19
        Me.BtnReport.Text = "لیست فاکتور"
        Me.BtnReport.UseVisualStyleBackColor = True
        '
        'TxtFac2
        '
        Me.TxtFac2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtFac2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtFac2.Location = New System.Drawing.Point(6, 35)
        Me.TxtFac2.MaxLength = 8
        Me.TxtFac2.Name = "TxtFac2"
        Me.TxtFac2.Size = New System.Drawing.Size(81, 29)
        Me.TxtFac2.TabIndex = 4
        Me.TxtFac2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtFac1
        '
        Me.TxtFac1.BackColor = System.Drawing.SystemColors.Window
        Me.TxtFac1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtFac1.Location = New System.Drawing.Point(145, 35)
        Me.TxtFac1.MaxLength = 8
        Me.TxtFac1.Name = "TxtFac1"
        Me.TxtFac1.Size = New System.Drawing.Size(81, 29)
        Me.TxtFac1.TabIndex = 2
        Me.TxtFac1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ChkTaFactor)
        Me.GroupBox1.Controls.Add(Me.ChKfactor)
        Me.GroupBox1.Controls.Add(Me.ChkAzFactor)
        Me.GroupBox1.Controls.Add(Me.TxtFac2)
        Me.GroupBox1.Controls.Add(Me.TxtFac1)
        Me.GroupBox1.Location = New System.Drawing.Point(423, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(288, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ChkTaFactor
        '
        Me.ChkTaFactor.AutoSize = True
        Me.ChkTaFactor.Location = New System.Drawing.Point(92, 37)
        Me.ChkTaFactor.Name = "ChkTaFactor"
        Me.ChkTaFactor.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaFactor.TabIndex = 3
        Me.ChkTaFactor.Text = "تا"
        Me.ChkTaFactor.UseVisualStyleBackColor = True
        '
        'ChKfactor
        '
        Me.ChKfactor.AutoSize = True
        Me.ChKfactor.Location = New System.Drawing.Point(164, 0)
        Me.ChKfactor.Name = "ChKfactor"
        Me.ChKfactor.Size = New System.Drawing.Size(112, 25)
        Me.ChKfactor.TabIndex = 0
        Me.ChKfactor.Text = "محدودیت فاکتور"
        Me.ChKfactor.UseVisualStyleBackColor = True
        '
        'ChkAzFactor
        '
        Me.ChkAzFactor.AutoSize = True
        Me.ChkAzFactor.Location = New System.Drawing.Point(239, 37)
        Me.ChkAzFactor.Name = "ChkAzFactor"
        Me.ChkAzFactor.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzFactor.TabIndex = 1
        Me.ChkAzFactor.Text = "از"
        Me.ChkAzFactor.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ChkTime)
        Me.GroupBox2.Controls.Add(Me.ChkTaDate)
        Me.GroupBox2.Controls.Add(Me.ChkAzDate)
        Me.GroupBox2.Controls.Add(Me.FarsiDate1)
        Me.GroupBox2.Controls.Add(Me.FarsiDate2)
        Me.GroupBox2.Location = New System.Drawing.Point(423, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(288, 81)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(167, -4)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(109, 25)
        Me.ChkTime.TabIndex = 5
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(92, 31)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 8
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(239, 31)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 6
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(145, 29)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(81, 29)
        Me.FarsiDate1.TabIndex = 7
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(6, 29)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(81, 29)
        Me.FarsiDate2.TabIndex = 9
        Me.FarsiDate2.ThisText = Nothing
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ChkP)
        Me.GroupBox3.Controls.Add(Me.ChkCity)
        Me.GroupBox3.Controls.Add(Me.ChkPart)
        Me.GroupBox3.Controls.Add(Me.CmbPart)
        Me.GroupBox3.Controls.Add(Me.CmbCity)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.CmbOstan)
        Me.GroupBox3.Controls.Add(Me.TxtOstan)
        Me.GroupBox3.Location = New System.Drawing.Point(423, 296)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(288, 95)
        Me.GroupBox3.TabIndex = 71
        Me.GroupBox3.TabStop = False
        '
        'ChkP
        '
        Me.ChkP.AutoSize = True
        Me.ChkP.Location = New System.Drawing.Point(82, 57)
        Me.ChkP.Name = "ChkP"
        Me.ChkP.Size = New System.Drawing.Size(55, 25)
        Me.ChkP.TabIndex = 14
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
        Me.ChkCity.TabIndex = 12
        Me.ChkCity.Text = "شهر"
        Me.ChkCity.UseVisualStyleBackColor = True
        '
        'ChkPart
        '
        Me.ChkPart.AutoSize = True
        Me.ChkPart.Location = New System.Drawing.Point(164, -2)
        Me.ChkPart.Name = "ChkPart"
        Me.ChkPart.Size = New System.Drawing.Size(112, 25)
        Me.ChkPart.TabIndex = 10
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
        Me.CmbPart.TabIndex = 15
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
        Me.CmbCity.TabIndex = 13
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
        Me.CmbOstan.TabIndex = 11
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 544)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(721, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 72
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
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(82, 24)
        Me.ToolStripStatusLabel3.Text = "F2 لیست فاکتور"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel2.Text = "F3 تهیه گزارش"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.ChkAll)
        Me.GroupBox4.Controls.Add(Me.DGV)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(412, 538)
        Me.GroupBox4.TabIndex = 73
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "لیست فاکتور فروش"
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(10, 509)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(48, 25)
        Me.ChkAll.TabIndex = 43
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
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Fac, Me.Cln_date, Me.Cln_People, Me.Cln_Select})
        Me.DGV.Location = New System.Drawing.Point(6, 25)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(400, 478)
        Me.DGV.TabIndex = 21
        '
        'Cln_Fac
        '
        Me.Cln_Fac.DataPropertyName = "IdFactor"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Fac.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_Fac.HeaderText = "فاکتور"
        Me.Cln_Fac.Name = "Cln_Fac"
        Me.Cln_Fac.ReadOnly = True
        Me.Cln_Fac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Fac.Width = 60
        '
        'Cln_date
        '
        Me.Cln_date.DataPropertyName = "D_date"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_date.DefaultCellStyle = DataGridViewCellStyle15
        Me.Cln_date.HeaderText = "تاریخ"
        Me.Cln_date.Name = "Cln_date"
        Me.Cln_date.ReadOnly = True
        Me.Cln_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_date.Width = 75
        '
        'Cln_People
        '
        Me.Cln_People.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_People.DataPropertyName = "Nam"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_People.DefaultCellStyle = DataGridViewCellStyle16
        Me.Cln_People.HeaderText = "طرف حساب"
        Me.Cln_People.Name = "Cln_People"
        Me.Cln_People.ReadOnly = True
        Me.Cln_People.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_People.Width = 172
        '
        'Cln_Select
        '
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Width = 50
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(531, 505)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 31)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "تهیه گزارش"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.RdoKala)
        Me.GroupBox5.Controls.Add(Me.RdoGroup)
        Me.GroupBox5.Location = New System.Drawing.Point(423, 60)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(288, 59)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "مرتب سازی"
        '
        'RdoKala
        '
        Me.RdoKala.AutoSize = True
        Me.RdoKala.Location = New System.Drawing.Point(84, 21)
        Me.RdoKala.Name = "RdoKala"
        Me.RdoKala.Size = New System.Drawing.Size(44, 25)
        Me.RdoKala.TabIndex = 1
        Me.RdoKala.Text = "کالا"
        Me.RdoKala.UseVisualStyleBackColor = True
        '
        'RdoGroup
        '
        Me.RdoGroup.AutoSize = True
        Me.RdoGroup.Checked = True
        Me.RdoGroup.Location = New System.Drawing.Point(234, 21)
        Me.RdoGroup.Name = "RdoGroup"
        Me.RdoGroup.Size = New System.Drawing.Size(42, 25)
        Me.RdoGroup.TabIndex = 0
        Me.RdoGroup.TabStop = True
        Me.RdoGroup.Text = "کد"
        Me.RdoGroup.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.ChkExit)
        Me.GroupBox6.Controls.Add(Me.TxtExit)
        Me.GroupBox6.Location = New System.Drawing.Point(423, 390)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox6.Size = New System.Drawing.Size(288, 81)
        Me.GroupBox6.TabIndex = 75
        Me.GroupBox6.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(237, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 21)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "خروجی"
        '
        'ChkExit
        '
        Me.ChkExit.AutoSize = True
        Me.ChkExit.Location = New System.Drawing.Point(161, 4)
        Me.ChkExit.Name = "ChkExit"
        Me.ChkExit.Size = New System.Drawing.Size(115, 25)
        Me.ChkExit.TabIndex = 16
        Me.ChkExit.Text = "محدودیت خروجی"
        Me.ChkExit.UseVisualStyleBackColor = True
        '
        'TxtExit
        '
        Me.TxtExit.BackColor = System.Drawing.SystemColors.Window
        Me.TxtExit.Enabled = False
        Me.TxtExit.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtExit.Location = New System.Drawing.Point(6, 35)
        Me.TxtExit.MaxLength = 20
        Me.TxtExit.Name = "TxtExit"
        Me.TxtExit.ShortcutsEnabled = False
        Me.TxtExit.Size = New System.Drawing.Size(220, 29)
        Me.TxtExit.TabIndex = 17
        Me.TxtExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkW
        '
        Me.ChkW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkW.AutoSize = True
        Me.ChkW.Checked = True
        Me.ChkW.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkW.Location = New System.Drawing.Point(569, 476)
        Me.ChkW.Name = "ChkW"
        Me.ChkW.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkW.Size = New System.Drawing.Size(130, 25)
        Me.ChkW.TabIndex = 18
        Me.ChkW.Text = "وزن کالا محاسبه شود"
        Me.ChkW.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.RdoFrosh)
        Me.GroupBox7.Controls.Add(Me.RdoBack)
        Me.GroupBox7.Location = New System.Drawing.Point(423, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(288, 59)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "خروجی بر حسب"
        '
        'RdoFrosh
        '
        Me.RdoFrosh.AutoSize = True
        Me.RdoFrosh.Checked = True
        Me.RdoFrosh.Location = New System.Drawing.Point(217, 21)
        Me.RdoFrosh.Name = "RdoFrosh"
        Me.RdoFrosh.Size = New System.Drawing.Size(59, 25)
        Me.RdoFrosh.TabIndex = 1
        Me.RdoFrosh.TabStop = True
        Me.RdoFrosh.Text = "فروش"
        Me.RdoFrosh.UseVisualStyleBackColor = True
        '
        'RdoBack
        '
        Me.RdoBack.AutoSize = True
        Me.RdoBack.Location = New System.Drawing.Point(17, 21)
        Me.RdoBack.Name = "RdoBack"
        Me.RdoBack.Size = New System.Drawing.Size(111, 25)
        Me.RdoBack.TabIndex = 0
        Me.RdoBack.Text = "برگشت از فروش"
        Me.RdoBack.UseVisualStyleBackColor = True
        '
        'FrmSumKalaFactor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 573)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.ChkW)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnReport)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmSumKalaFactor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش جمع کالای فاکتور"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnReport As System.Windows.Forms.Button
    Friend WithEvents TxtFac2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtFac1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChKfactor As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaFactor As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzFactor As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkP As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCity As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPart As System.Windows.Forms.CheckBox
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbOstan As System.Windows.Forms.ComboBox
    Friend WithEvents TxtOstan As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoKala As System.Windows.Forms.RadioButton
    Friend WithEvents RdoGroup As System.Windows.Forms.RadioButton
    Friend WithEvents Cln_Fac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_People As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkExit As System.Windows.Forms.CheckBox
    Friend WithEvents TxtExit As System.Windows.Forms.TextBox
    Friend WithEvents ChkW As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoFrosh As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBack As System.Windows.Forms.RadioButton
End Class
