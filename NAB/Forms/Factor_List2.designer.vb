<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Factor_List2
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnOk = New System.Windows.Forms.Button
        Me.TxtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BtnExit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
        Me.RdoDate = New System.Windows.Forms.RadioButton
        Me.RdoAllKala = New System.Windows.Forms.RadioButton
        Me.CmbCity = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbOstan = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtOstan = New System.Windows.Forms.TextBox
        Me.TxtCity = New System.Windows.Forms.TextBox
        Me.RdoTwo = New System.Windows.Forms.RadioButton
        Me.RdoOne = New System.Windows.Forms.RadioButton
        Me.ChkAll = New System.Windows.Forms.CheckBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LIdname = New System.Windows.Forms.Label
        Me.Cln_Idfac = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Ostan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_City = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Part = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(482, 508)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(88, 30)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "انتخاب"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Location = New System.Drawing.Point(28, 115)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSearch.ShortcutsEnabled = False
        Me.TxtSearch.Size = New System.Drawing.Size(383, 29)
        Me.TxtSearch.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(417, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "جستجوی فاکتور"
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Idfac, Me.Cln_Date, Me.Cln_Name, Me.Cln_Ostan, Me.Cln_City, Me.Cln_Part, Me.Cln_Select})
        Me.DGV.Location = New System.Drawing.Point(12, 168)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(558, 335)
        Me.DGV.TabIndex = 3
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(388, 508)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(88, 30)
        Me.BtnExit.TabIndex = 4
        Me.BtnExit.Text = "انصراف"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ChkTaDate)
        Me.GroupBox2.Controls.Add(Me.ChkAzDate)
        Me.GroupBox2.Controls.Add(Me.FarsiDate1)
        Me.GroupBox2.Controls.Add(Me.FarsiDate2)
        Me.GroupBox2.Controls.Add(Me.RdoDate)
        Me.GroupBox2.Controls.Add(Me.RdoAllKala)
        Me.GroupBox2.Controls.Add(Me.CmbCity)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CmbOstan)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TxtOstan)
        Me.GroupBox2.Controls.Add(Me.TxtCity)
        Me.GroupBox2.Controls.Add(Me.RdoTwo)
        Me.GroupBox2.Controls.Add(Me.RdoOne)
        Me.GroupBox2.Controls.Add(Me.TxtSearch)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(558, 157)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "فیلتر اطلاعات"
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Enabled = False
        Me.ChkTaDate.Location = New System.Drawing.Point(160, 86)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 62
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Enabled = False
        Me.ChkAzDate.Location = New System.Drawing.Point(159, 56)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 60
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Enabled = False
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(27, 54)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(125, 29)
        Me.FarsiDate1.TabIndex = 61
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Enabled = False
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(28, 85)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(125, 29)
        Me.FarsiDate2.TabIndex = 63
        Me.FarsiDate2.ThisText = Nothing
        '
        'RdoDate
        '
        Me.RdoDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoDate.AutoSize = True
        Me.RdoDate.Location = New System.Drawing.Point(88, 29)
        Me.RdoDate.Name = "RdoDate"
        Me.RdoDate.Size = New System.Drawing.Size(108, 25)
        Me.RdoDate.TabIndex = 59
        Me.RdoDate.Text = "محدودیت زمانی"
        Me.RdoDate.UseVisualStyleBackColor = True
        '
        'RdoAllKala
        '
        Me.RdoAllKala.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoAllKala.AutoSize = True
        Me.RdoAllKala.Checked = True
        Me.RdoAllKala.Location = New System.Drawing.Point(452, 29)
        Me.RdoAllKala.Name = "RdoAllKala"
        Me.RdoAllKala.Size = New System.Drawing.Size(47, 25)
        Me.RdoAllKala.TabIndex = 58
        Me.RdoAllKala.TabStop = True
        Me.RdoAllKala.Text = "همه"
        Me.RdoAllKala.UseVisualStyleBackColor = True
        '
        'CmbCity
        '
        Me.CmbCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCity.Enabled = False
        Me.CmbCity.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbCity.FormattingEnabled = True
        Me.CmbCity.Location = New System.Drawing.Point(243, 85)
        Me.CmbCity.MaxDropDownItems = 10
        Me.CmbCity.Name = "CmbCity"
        Me.CmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbCity.Size = New System.Drawing.Size(168, 29)
        Me.CmbCity.Sorted = True
        Me.CmbCity.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(449, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 21)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "شهرستان"
        '
        'CmbOstan
        '
        Me.CmbOstan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbOstan.Enabled = False
        Me.CmbOstan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbOstan.FormattingEnabled = True
        Me.CmbOstan.Location = New System.Drawing.Point(243, 54)
        Me.CmbOstan.MaxDropDownItems = 10
        Me.CmbOstan.Name = "CmbOstan"
        Me.CmbOstan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbOstan.Size = New System.Drawing.Size(168, 29)
        Me.CmbOstan.Sorted = True
        Me.CmbOstan.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(467, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 21)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "استان"
        '
        'TxtOstan
        '
        Me.TxtOstan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOstan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtOstan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOstan.Enabled = False
        Me.TxtOstan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtOstan.Location = New System.Drawing.Point(334, 54)
        Me.TxtOstan.MaxLength = 7
        Me.TxtOstan.Name = "TxtOstan"
        Me.TxtOstan.ReadOnly = True
        Me.TxtOstan.ShortcutsEnabled = False
        Me.TxtOstan.Size = New System.Drawing.Size(41, 29)
        Me.TxtOstan.TabIndex = 56
        Me.TxtOstan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCity
        '
        Me.TxtCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCity.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCity.Enabled = False
        Me.TxtCity.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtCity.Location = New System.Drawing.Point(353, 85)
        Me.TxtCity.MaxLength = 7
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.ReadOnly = True
        Me.TxtCity.ShortcutsEnabled = False
        Me.TxtCity.Size = New System.Drawing.Size(41, 29)
        Me.TxtCity.TabIndex = 57
        Me.TxtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RdoTwo
        '
        Me.RdoTwo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoTwo.AutoSize = True
        Me.RdoTwo.Location = New System.Drawing.Point(236, 28)
        Me.RdoTwo.Name = "RdoTwo"
        Me.RdoTwo.Size = New System.Drawing.Size(72, 25)
        Me.RdoTwo.TabIndex = 51
        Me.RdoTwo.Text = "شهرستان"
        Me.RdoTwo.UseVisualStyleBackColor = True
        '
        'RdoOne
        '
        Me.RdoOne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoOne.AutoSize = True
        Me.RdoOne.Location = New System.Drawing.Point(357, 28)
        Me.RdoOne.Name = "RdoOne"
        Me.RdoOne.Size = New System.Drawing.Size(54, 25)
        Me.RdoOne.TabIndex = 50
        Me.RdoOne.Text = "استان"
        Me.RdoOne.UseVisualStyleBackColor = True
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(12, 513)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAll.Size = New System.Drawing.Size(48, 25)
        Me.ChkAll.TabIndex = 35
        Me.ChkAll.Text = "همه"
        Me.ChkAll.UseVisualStyleBackColor = True
        Me.ChkAll.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 542)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(582, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 37
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(56, 24)
        Me.ToolStripStatusLabel2.Text = "F2 انتخاب"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel3.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel5.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'LIdname
        '
        Me.LIdname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LIdname.AutoSize = True
        Me.LIdname.Location = New System.Drawing.Point(599, 35)
        Me.LIdname.Name = "LIdname"
        Me.LIdname.Size = New System.Drawing.Size(0, 21)
        Me.LIdname.TabIndex = 3
        Me.LIdname.Visible = False
        '
        'Cln_Idfac
        '
        Me.Cln_Idfac.DataPropertyName = "IdFactor"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Idfac.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Idfac.HeaderText = "فاکتور"
        Me.Cln_Idfac.Name = "Cln_Idfac"
        Me.Cln_Idfac.ReadOnly = True
        Me.Cln_Idfac.Width = 60
        '
        'Cln_Date
        '
        Me.Cln_Date.DataPropertyName = "D_Date"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Date.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Date.HeaderText = "تاریخ"
        Me.Cln_Date.Name = "Cln_Date"
        Me.Cln_Date.ReadOnly = True
        Me.Cln_Date.Width = 75
        '
        'Cln_Name
        '
        Me.Cln_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Name.DataPropertyName = "Nam"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Name.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_Name.HeaderText = "طرف حساب"
        Me.Cln_Name.Name = "Cln_Name"
        Me.Cln_Name.ReadOnly = True
        Me.Cln_Name.Width = 145
        '
        'Cln_Ostan
        '
        Me.Cln_Ostan.DataPropertyName = "NamO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Ostan.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_Ostan.HeaderText = "استان"
        Me.Cln_Ostan.Name = "Cln_Ostan"
        Me.Cln_Ostan.ReadOnly = True
        Me.Cln_Ostan.Width = 80
        '
        'Cln_City
        '
        Me.Cln_City.DataPropertyName = "NamCI"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_City.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_City.HeaderText = "شهرستان"
        Me.Cln_City.Name = "Cln_City"
        Me.Cln_City.ReadOnly = True
        Me.Cln_City.Width = 80
        '
        'Cln_Part
        '
        Me.Cln_Part.DataPropertyName = "NamP"
        Me.Cln_Part.HeaderText = "مسیر"
        Me.Cln_Part.Name = "Cln_Part"
        Me.Cln_Part.ReadOnly = True
        Me.Cln_Part.Width = 75
        '
        'Cln_Select
        '
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Select.Visible = False
        Me.Cln_Select.Width = 40
        '
        'Factor_List2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 571)
        Me.Controls.Add(Me.LIdname)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "Factor_List2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "لیست انتخاب"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LIdname As System.Windows.Forms.Label
    Friend WithEvents RdoAllKala As System.Windows.Forms.RadioButton
    Friend WithEvents CmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbOstan As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtOstan As System.Windows.Forms.TextBox
    Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    Friend WithEvents RdoTwo As System.Windows.Forms.RadioButton
    Friend WithEvents RdoOne As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDate As System.Windows.Forms.RadioButton
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents Cln_Idfac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Ostan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Part As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
