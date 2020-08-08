<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportStateAllVisitor
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_IdP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_Activ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkAll = New System.Windows.Forms.CheckBox
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
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ChkActiv = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtGroup = New System.Windows.Forms.TextBox
        Me.ChkGroup = New System.Windows.Forms.CheckBox
        Me.TxtIdGroup = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.BtnSelect = New System.Windows.Forms.Button
        Me.BtnSeachCity = New System.Windows.Forms.Button
        Me.ChkAllp = New System.Windows.Forms.CheckBox
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.ChkMasir = New System.Windows.Forms.CheckBox
        Me.Cln_Ostan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_City = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NamP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_SelectP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_IdP, Me.Cln_Nam, Me.Cln_Select, Me.Cln_Activ})
        Me.DGV.Location = New System.Drawing.Point(7, 28)
        Me.DGV.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(317, 312)
        Me.DGV.TabIndex = 4
        '
        'Cln_IdP
        '
        Me.Cln_IdP.DataPropertyName = "Id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_IdP.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_IdP.HeaderText = "کد"
        Me.Cln_IdP.Name = "Cln_IdP"
        Me.Cln_IdP.ReadOnly = True
        Me.Cln_IdP.Width = 60
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Nam.HeaderText = "نام ویزیتور"
        Me.Cln_Nam.Name = "Cln_Nam"
        Me.Cln_Nam.ReadOnly = True
        Me.Cln_Nam.Width = 164
        '
        'Cln_Select
        '
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Select.Width = 50
        '
        'Cln_Activ
        '
        Me.Cln_Activ.DataPropertyName = "Activ"
        Me.Cln_Activ.HeaderText = "Activ"
        Me.Cln_Activ.Name = "Cln_Activ"
        Me.Cln_Activ.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkAll)
        Me.GroupBox1.Controls.Add(Me.DGV)
        Me.GroupBox1.Location = New System.Drawing.Point(7, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(332, 375)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "لیست ویزیتورها"
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(8, 344)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(84, 25)
        Me.ChkAll.TabIndex = 76
        Me.ChkAll.Text = "انتخاب همه"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkTime)
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 379)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(332, 81)
        Me.GroupBox3.TabIndex = 71
        Me.GroupBox3.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(213, 0)
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
        Me.ChkTaDate.Location = New System.Drawing.Point(119, 35)
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
        Me.ChkAzDate.Location = New System.Drawing.Point(284, 35)
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
        Me.FarsiDate1.Location = New System.Drawing.Point(177, 33)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(100, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(12, 33)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(100, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(14, 602)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(109, 30)
        Me.BtnOk.TabIndex = 73
        Me.BtnOk.Text = "تهیه گزارش"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 635)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(781, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 75
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
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel4.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'ChkActiv
        '
        Me.ChkActiv.AutoSize = True
        Me.ChkActiv.Checked = True
        Me.ChkActiv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActiv.Location = New System.Drawing.Point(56, 539)
        Me.ChkActiv.Name = "ChkActiv"
        Me.ChkActiv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkActiv.Size = New System.Drawing.Size(283, 25)
        Me.ChkActiv.TabIndex = 76
        Me.ChkActiv.Text = "طرف حساب غیرفعال  در مسیر ویزیت محاسبه نگردد"
        Me.ChkActiv.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Button1)
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.TxtGroup)
        Me.GroupBox7.Controls.Add(Me.ChkGroup)
        Me.GroupBox7.Controls.Add(Me.TxtIdGroup)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 466)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(332, 67)
        Me.GroupBox7.TabIndex = 77
        Me.GroupBox7.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(5, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 29)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "..."
        Me.ToolTip1.SetToolTip(Me.Button1, "جهت انتخاب چندین گروه از این قسمت استفاده کنید")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(292, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 21)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "گروه"
        '
        'TxtGroup
        '
        Me.TxtGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGroup.BackColor = System.Drawing.SystemColors.Window
        Me.TxtGroup.Enabled = False
        Me.TxtGroup.Location = New System.Drawing.Point(53, 28)
        Me.TxtGroup.MaxLength = 18
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.ShortcutsEnabled = False
        Me.TxtGroup.Size = New System.Drawing.Size(224, 29)
        Me.TxtGroup.TabIndex = 19
        '
        'ChkGroup
        '
        Me.ChkGroup.AutoSize = True
        Me.ChkGroup.Location = New System.Drawing.Point(216, 0)
        Me.ChkGroup.Name = "ChkGroup"
        Me.ChkGroup.Size = New System.Drawing.Size(105, 25)
        Me.ChkGroup.TabIndex = 18
        Me.ChkGroup.Text = "محدوديت گروه"
        Me.ChkGroup.UseVisualStyleBackColor = True
        '
        'TxtIdGroup
        '
        Me.TxtIdGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdGroup.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdGroup.Enabled = False
        Me.TxtIdGroup.Location = New System.Drawing.Point(130, 28)
        Me.TxtIdGroup.MaxLength = 18
        Me.TxtIdGroup.Name = "TxtIdGroup"
        Me.TxtIdGroup.ReadOnly = True
        Me.TxtIdGroup.ShortcutsEnabled = False
        Me.TxtIdGroup.Size = New System.Drawing.Size(37, 29)
        Me.TxtIdGroup.TabIndex = 16
        Me.TxtIdGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(7, 570)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(332, 25)
        Me.CheckBox1.TabIndex = 78
        Me.CheckBox1.Text = "محدودیت گروه و طرف حساب  در مسیر ویزیت تاثیر داده شود"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "راهنمایی"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.ChkMasir)
        Me.GroupBox5.Controls.Add(Me.BtnSelect)
        Me.GroupBox5.Controls.Add(Me.BtnSeachCity)
        Me.GroupBox5.Controls.Add(Me.ChkAllp)
        Me.GroupBox5.Controls.Add(Me.DGV2)
        Me.GroupBox5.Location = New System.Drawing.Point(346, -2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(430, 597)
        Me.GroupBox5.TabIndex = 79
        Me.GroupBox5.TabStop = False
        '
        'BtnSelect
        '
        Me.BtnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelect.Enabled = False
        Me.BtnSelect.Location = New System.Drawing.Point(198, 561)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(111, 30)
        Me.BtnSelect.TabIndex = 80
        Me.BtnSelect.Text = "انتخاب پیشرفته"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'BtnSeachCity
        '
        Me.BtnSeachCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSeachCity.Enabled = False
        Me.BtnSeachCity.Location = New System.Drawing.Point(315, 561)
        Me.BtnSeachCity.Name = "BtnSeachCity"
        Me.BtnSeachCity.Size = New System.Drawing.Size(111, 30)
        Me.BtnSeachCity.TabIndex = 79
        Me.BtnSeachCity.Text = "جستجو"
        Me.BtnSeachCity.UseVisualStyleBackColor = True
        '
        'ChkAllp
        '
        Me.ChkAllp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAllp.AutoSize = True
        Me.ChkAllp.Enabled = False
        Me.ChkAllp.Location = New System.Drawing.Point(6, 565)
        Me.ChkAllp.Name = "ChkAllp"
        Me.ChkAllp.Size = New System.Drawing.Size(84, 25)
        Me.ChkAllp.TabIndex = 52
        Me.ChkAllp.Text = "انتخاب همه"
        Me.ChkAllp.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Ostan, Me.Cln_City, Me.Cln_NamP, Me.Cln_IdM, Me.Cln_SelectP, Me.Cln_Code})
        Me.DGV2.Enabled = False
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(418, 528)
        Me.DGV2.TabIndex = 4
        '
        'ChkMasir
        '
        Me.ChkMasir.AutoSize = True
        Me.ChkMasir.Location = New System.Drawing.Point(319, 2)
        Me.ChkMasir.Name = "ChkMasir"
        Me.ChkMasir.Size = New System.Drawing.Size(91, 25)
        Me.ChkMasir.TabIndex = 77
        Me.ChkMasir.Text = "انتخاب مسیر"
        Me.ChkMasir.UseVisualStyleBackColor = True
        '
        'Cln_Ostan
        '
        Me.Cln_Ostan.DataPropertyName = "NamO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Ostan.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_Ostan.HeaderText = "استان"
        Me.Cln_Ostan.Name = "Cln_Ostan"
        Me.Cln_Ostan.ReadOnly = True
        Me.Cln_Ostan.Width = 115
        '
        'Cln_City
        '
        Me.Cln_City.DataPropertyName = "NamCi"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_City.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_City.HeaderText = "شهرستان"
        Me.Cln_City.Name = "Cln_City"
        Me.Cln_City.ReadOnly = True
        Me.Cln_City.Width = 110
        '
        'Cln_NamP
        '
        Me.Cln_NamP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_NamP.DataPropertyName = "Nam"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamP.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_NamP.HeaderText = "مسیر"
        Me.Cln_NamP.Name = "Cln_NamP"
        Me.Cln_NamP.ReadOnly = True
        '
        'Cln_IdM
        '
        Me.Cln_IdM.DataPropertyName = "Id"
        Me.Cln_IdM.HeaderText = "ID"
        Me.Cln_IdM.Name = "Cln_IdM"
        Me.Cln_IdM.ReadOnly = True
        Me.Cln_IdM.Visible = False
        '
        'Cln_SelectP
        '
        Me.Cln_SelectP.HeaderText = "انتخاب"
        Me.Cln_SelectP.Name = "Cln_SelectP"
        Me.Cln_SelectP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_SelectP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_SelectP.Width = 50
        '
        'Cln_Code
        '
        Me.Cln_Code.DataPropertyName = "Code"
        Me.Cln_Code.HeaderText = "City"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.Visible = False
        '
        'ReportStateAllVisitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 664)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.ChkActiv)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportStateAllVisitor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش عملکرد ویزیتور"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ChkActiv As System.Windows.Forms.CheckBox
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Activ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
    Friend WithEvents ChkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdGroup As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
    Friend WithEvents BtnSeachCity As System.Windows.Forms.Button
    Friend WithEvents ChkAllp As System.Windows.Forms.CheckBox
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents ChkMasir As System.Windows.Forms.CheckBox
    Friend WithEvents Cln_Ostan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NamP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_SelectP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
