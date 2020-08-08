<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChartPayChk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChartPayChk))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.ChkAllp = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Cln_NamP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_SelectP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_ActiveP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RdoPayDate = New System.Windows.Forms.RadioButton
        Me.RdoGetDate = New System.Windows.Forms.RadioButton
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkTazmini = New System.Windows.Forms.CheckBox
        Me.ChkVosol = New System.Windows.Forms.CheckBox
        Me.ChkBargasht = New System.Windows.Forms.CheckBox
        Me.ChkDar = New System.Windows.Forms.CheckBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.RdoAllChk = New System.Windows.Forms.RadioButton
        Me.RdoOnlyChk = New System.Windows.Forms.RadioButton
        Me.ChkOther = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBank = New System.Windows.Forms.TextBox
        Me.ChkBank = New System.Windows.Forms.CheckBox
        Me.TxtIdBank = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.RdoAllChkPay = New System.Windows.Forms.RadioButton
        Me.RdoOnlyChkPay = New System.Windows.Forms.RadioButton
        Me.ChkPay = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RdoMonth = New System.Windows.Forms.RadioButton
        Me.RdoDay = New System.Windows.Forms.RadioButton
        Me.RdoWeek = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RdoPie = New System.Windows.Forms.RadioButton
        Me.RdoBar = New System.Windows.Forms.RadioButton
        Me.RdoLine = New System.Windows.Forms.RadioButton
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.ChkAllp)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.DGV2)
        Me.GroupBox5.Location = New System.Drawing.Point(327, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(347, 603)
        Me.GroupBox5.TabIndex = 77
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "لیست طرف حساب"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(112, 567)
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
        Me.ChkAllp.Location = New System.Drawing.Point(8, 571)
        Me.ChkAllp.Name = "ChkAllp"
        Me.ChkAllp.Size = New System.Drawing.Size(82, 25)
        Me.ChkAllp.TabIndex = 52
        Me.ChkAllp.Text = "انتخاب همه"
        Me.ChkAllp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(229, 567)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_NamP, Me.Cln_IdP, Me.Cln_SelectP, Me.Cln_ActiveP})
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(335, 534)
        Me.DGV2.TabIndex = 4
        '
        'Cln_NamP
        '
        Me.Cln_NamP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_NamP.DataPropertyName = "Nam"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamP.DefaultCellStyle = DataGridViewCellStyle2
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 616)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(679, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 78
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(123, 24)
        Me.ToolStripStatusLabel2.Text = "F3 جستجوی طرف حساب"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(148, 24)
        Me.ToolStripStatusLabel4.Text = "F4 انتخاب پیشرفته طرف حساب"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RdoPayDate)
        Me.GroupBox3.Controls.Add(Me.RdoGetDate)
        Me.GroupBox3.Controls.Add(Me.ChkTime)
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 257)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(315, 98)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        '
        'RdoPayDate
        '
        Me.RdoPayDate.AutoSize = True
        Me.RdoPayDate.Enabled = False
        Me.RdoPayDate.Location = New System.Drawing.Point(171, 65)
        Me.RdoPayDate.Name = "RdoPayDate"
        Me.RdoPayDate.Size = New System.Drawing.Size(136, 25)
        Me.RdoPayDate.TabIndex = 71
        Me.RdoPayDate.Text = "بر حسب تاریخ سرسید"
        Me.RdoPayDate.UseVisualStyleBackColor = True
        '
        'RdoGetDate
        '
        Me.RdoGetDate.AutoSize = True
        Me.RdoGetDate.Enabled = False
        Me.RdoGetDate.Location = New System.Drawing.Point(6, 65)
        Me.RdoGetDate.Name = "RdoGetDate"
        Me.RdoGetDate.Size = New System.Drawing.Size(129, 25)
        Me.RdoGetDate.TabIndex = 70
        Me.RdoGetDate.Text = "بر حسب تاریخ صدور"
        Me.RdoGetDate.UseVisualStyleBackColor = True
        '
        'ChkTime
        '
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(199, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(107, 25)
        Me.ChkTime.TabIndex = 69
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(110, 34)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(34, 25)
        Me.ChkTaDate.TabIndex = 68
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(273, 34)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(35, 25)
        Me.ChkAzDate.TabIndex = 67
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(166, 32)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(95, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(6, 32)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(95, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTazmini)
        Me.GroupBox1.Controls.Add(Me.ChkVosol)
        Me.GroupBox1.Controls.Add(Me.ChkBargasht)
        Me.GroupBox1.Controls.Add(Me.ChkDar)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(315, 81)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "وضعیت اسناد دریافتی"
        '
        'ChkTazmini
        '
        Me.ChkTazmini.AutoSize = True
        Me.ChkTazmini.Location = New System.Drawing.Point(79, 26)
        Me.ChkTazmini.Name = "ChkTazmini"
        Me.ChkTazmini.Size = New System.Drawing.Size(63, 25)
        Me.ChkTazmini.TabIndex = 73
        Me.ChkTazmini.Text = "تضمینی"
        Me.ChkTazmini.UseVisualStyleBackColor = True
        '
        'ChkVosol
        '
        Me.ChkVosol.AutoSize = True
        Me.ChkVosol.Location = New System.Drawing.Point(62, 49)
        Me.ChkVosol.Name = "ChkVosol"
        Me.ChkVosol.Size = New System.Drawing.Size(80, 25)
        Me.ChkVosol.TabIndex = 72
        Me.ChkVosol.Text = "وصول شده"
        Me.ChkVosol.UseVisualStyleBackColor = True
        '
        'ChkBargasht
        '
        Me.ChkBargasht.AutoSize = True
        Me.ChkBargasht.Location = New System.Drawing.Point(241, 49)
        Me.ChkBargasht.Name = "ChkBargasht"
        Me.ChkBargasht.Size = New System.Drawing.Size(65, 25)
        Me.ChkBargasht.TabIndex = 70
        Me.ChkBargasht.Text = "برگشتی"
        Me.ChkBargasht.UseVisualStyleBackColor = True
        '
        'ChkDar
        '
        Me.ChkDar.AutoSize = True
        Me.ChkDar.Checked = True
        Me.ChkDar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDar.Location = New System.Drawing.Point(205, 26)
        Me.ChkDar.Name = "ChkDar"
        Me.ChkDar.Size = New System.Drawing.Size(101, 25)
        Me.ChkDar.TabIndex = 69
        Me.ChkDar.Text = "در جریان وصول"
        Me.ChkDar.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(218, 574)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(103, 30)
        Me.BtnOk.TabIndex = 81
        Me.BtnOk.Text = "تهیه گزارش"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RdoAllChk)
        Me.GroupBox6.Controls.Add(Me.RdoOnlyChk)
        Me.GroupBox6.Controls.Add(Me.ChkOther)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 91)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox6.Size = New System.Drawing.Size(315, 82)
        Me.GroupBox6.TabIndex = 80
        Me.GroupBox6.TabStop = False
        '
        'RdoAllChk
        '
        Me.RdoAllChk.AutoSize = True
        Me.RdoAllChk.Checked = True
        Me.RdoAllChk.Enabled = False
        Me.RdoAllChk.Location = New System.Drawing.Point(43, 26)
        Me.RdoAllChk.Name = "RdoAllChk"
        Me.RdoAllChk.Size = New System.Drawing.Size(264, 25)
        Me.RdoAllChk.TabIndex = 85
        Me.RdoAllChk.TabStop = True
        Me.RdoAllChk.Text = "چکهای این بخش همراه سایر چکها نمایش داده شود"
        Me.RdoAllChk.UseVisualStyleBackColor = True
        '
        'RdoOnlyChk
        '
        Me.RdoOnlyChk.AutoSize = True
        Me.RdoOnlyChk.Enabled = False
        Me.RdoOnlyChk.Location = New System.Drawing.Point(98, 48)
        Me.RdoOnlyChk.Name = "RdoOnlyChk"
        Me.RdoOnlyChk.Size = New System.Drawing.Size(209, 25)
        Me.RdoOnlyChk.TabIndex = 84
        Me.RdoOnlyChk.Text = "فقط چکهای این بخش نمایش داده شود"
        Me.RdoOnlyChk.UseVisualStyleBackColor = True
        '
        'ChkOther
        '
        Me.ChkOther.AutoSize = True
        Me.ChkOther.Checked = True
        Me.ChkOther.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkOther.Location = New System.Drawing.Point(146, 0)
        Me.ChkOther.Name = "ChkOther"
        Me.ChkOther.Size = New System.Drawing.Size(160, 25)
        Me.ChkOther.TabIndex = 69
        Me.ChkOther.Text = "چکهای هزینه ، اموال ، سرمایه"
        Me.ChkOther.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.TxtBank)
        Me.GroupBox7.Controls.Add(Me.ChkBank)
        Me.GroupBox7.Controls.Add(Me.TxtIdBank)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 357)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(315, 70)
        Me.GroupBox7.TabIndex = 81
        Me.GroupBox7.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(279, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 21)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "بانک"
        '
        'TxtBank
        '
        Me.TxtBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBank.Enabled = False
        Me.TxtBank.Location = New System.Drawing.Point(6, 28)
        Me.TxtBank.MaxLength = 18
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.ShortcutsEnabled = False
        Me.TxtBank.Size = New System.Drawing.Size(255, 29)
        Me.TxtBank.TabIndex = 10
        '
        'ChkBank
        '
        Me.ChkBank.AutoSize = True
        Me.ChkBank.Location = New System.Drawing.Point(203, -1)
        Me.ChkBank.Name = "ChkBank"
        Me.ChkBank.Size = New System.Drawing.Size(103, 25)
        Me.ChkBank.TabIndex = 8
        Me.ChkBank.Text = "محدوديت بانک"
        Me.ChkBank.UseVisualStyleBackColor = True
        '
        'TxtIdBank
        '
        Me.TxtIdBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdBank.Enabled = False
        Me.TxtIdBank.Location = New System.Drawing.Point(146, 28)
        Me.TxtIdBank.MaxLength = 18
        Me.TxtIdBank.Name = "TxtIdBank"
        Me.TxtIdBank.ReadOnly = True
        Me.TxtIdBank.ShortcutsEnabled = False
        Me.TxtIdBank.Size = New System.Drawing.Size(51, 29)
        Me.TxtIdBank.TabIndex = 11
        Me.TxtIdBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.RdoAllChkPay)
        Me.GroupBox8.Controls.Add(Me.RdoOnlyChkPay)
        Me.GroupBox8.Controls.Add(Me.ChkPay)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 174)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox8.Size = New System.Drawing.Size(315, 82)
        Me.GroupBox8.TabIndex = 86
        Me.GroupBox8.TabStop = False
        '
        'RdoAllChkPay
        '
        Me.RdoAllChkPay.AutoSize = True
        Me.RdoAllChkPay.Enabled = False
        Me.RdoAllChkPay.Location = New System.Drawing.Point(43, 26)
        Me.RdoAllChkPay.Name = "RdoAllChkPay"
        Me.RdoAllChkPay.Size = New System.Drawing.Size(264, 25)
        Me.RdoAllChkPay.TabIndex = 85
        Me.RdoAllChkPay.Text = "چکهای این بخش همراه سایر چکها نمایش داده شود"
        Me.RdoAllChkPay.UseVisualStyleBackColor = True
        '
        'RdoOnlyChkPay
        '
        Me.RdoOnlyChkPay.AutoSize = True
        Me.RdoOnlyChkPay.Enabled = False
        Me.RdoOnlyChkPay.Location = New System.Drawing.Point(98, 48)
        Me.RdoOnlyChkPay.Name = "RdoOnlyChkPay"
        Me.RdoOnlyChkPay.Size = New System.Drawing.Size(209, 25)
        Me.RdoOnlyChkPay.TabIndex = 84
        Me.RdoOnlyChkPay.Text = "فقط چکهای این بخش نمایش داده شود"
        Me.RdoOnlyChkPay.UseVisualStyleBackColor = True
        '
        'ChkPay
        '
        Me.ChkPay.AutoSize = True
        Me.ChkPay.Location = New System.Drawing.Point(200, 0)
        Me.ChkPay.Name = "ChkPay"
        Me.ChkPay.Size = New System.Drawing.Size(106, 25)
        Me.ChkPay.TabIndex = 69
        Me.ChkPay.Text = "چکهای خرج شده"
        Me.ChkPay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdoMonth)
        Me.GroupBox2.Controls.Add(Me.RdoDay)
        Me.GroupBox2.Controls.Add(Me.RdoWeek)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 496)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(315, 68)
        Me.GroupBox2.TabIndex = 90
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "نوع دوره"
        '
        'RdoMonth
        '
        Me.RdoMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoMonth.AutoSize = True
        Me.RdoMonth.Location = New System.Drawing.Point(6, 29)
        Me.RdoMonth.Name = "RdoMonth"
        Me.RdoMonth.Size = New System.Drawing.Size(56, 25)
        Me.RdoMonth.TabIndex = 40
        Me.RdoMonth.Text = "ماهانه"
        Me.RdoMonth.UseVisualStyleBackColor = True
        '
        'RdoDay
        '
        Me.RdoDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoDay.AutoSize = True
        Me.RdoDay.Checked = True
        Me.RdoDay.Location = New System.Drawing.Point(249, 29)
        Me.RdoDay.Name = "RdoDay"
        Me.RdoDay.Size = New System.Drawing.Size(56, 25)
        Me.RdoDay.TabIndex = 39
        Me.RdoDay.TabStop = True
        Me.RdoDay.Text = "روزانه"
        Me.RdoDay.UseVisualStyleBackColor = True
        '
        'RdoWeek
        '
        Me.RdoWeek.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoWeek.AutoSize = True
        Me.RdoWeek.Location = New System.Drawing.Point(130, 29)
        Me.RdoWeek.Name = "RdoWeek"
        Me.RdoWeek.Size = New System.Drawing.Size(56, 25)
        Me.RdoWeek.TabIndex = 38
        Me.RdoWeek.Text = "هفتگی"
        Me.RdoWeek.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RdoPie)
        Me.GroupBox4.Controls.Add(Me.RdoBar)
        Me.GroupBox4.Controls.Add(Me.RdoLine)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 428)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(315, 68)
        Me.GroupBox4.TabIndex = 89
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "نوع نمودار"
        '
        'RdoPie
        '
        Me.RdoPie.Image = Global.NAB.My.Resources.Resources.Pie
        Me.RdoPie.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RdoPie.Location = New System.Drawing.Point(133, 21)
        Me.RdoPie.Name = "RdoPie"
        Me.RdoPie.Size = New System.Drawing.Size(53, 39)
        Me.RdoPie.TabIndex = 5
        Me.RdoPie.UseVisualStyleBackColor = True
        '
        'RdoBar
        '
        Me.RdoBar.Image = Global.NAB.My.Resources.Resources.Bar1
        Me.RdoBar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RdoBar.Location = New System.Drawing.Point(9, 21)
        Me.RdoBar.Name = "RdoBar"
        Me.RdoBar.Size = New System.Drawing.Size(53, 39)
        Me.RdoBar.TabIndex = 4
        Me.RdoBar.UseVisualStyleBackColor = True
        '
        'RdoLine
        '
        Me.RdoLine.Checked = True
        Me.RdoLine.Image = CType(resources.GetObject("RdoLine.Image"), System.Drawing.Image)
        Me.RdoLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RdoLine.Location = New System.Drawing.Point(252, 21)
        Me.RdoLine.Name = "RdoLine"
        Me.RdoLine.Size = New System.Drawing.Size(53, 39)
        Me.RdoLine.TabIndex = 2
        Me.RdoLine.TabStop = True
        Me.RdoLine.UseVisualStyleBackColor = True
        '
        'FrmChartPayChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 645)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmChartPayChk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نمودار اسناد پرداختی"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ChkAllp As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Cln_NamP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_SelectP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_ActiveP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkDar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTazmini As System.Windows.Forms.CheckBox
    Friend WithEvents ChkVosol As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBargasht As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkOther As System.Windows.Forms.CheckBox
    Friend WithEvents RdoAllChk As System.Windows.Forms.RadioButton
    Friend WithEvents RdoOnlyChk As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBank As System.Windows.Forms.TextBox
    Friend WithEvents ChkBank As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdBank As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoAllChkPay As System.Windows.Forms.RadioButton
    Friend WithEvents RdoOnlyChkPay As System.Windows.Forms.RadioButton
    Friend WithEvents ChkPay As System.Windows.Forms.CheckBox
    Friend WithEvents RdoPayDate As System.Windows.Forms.RadioButton
    Friend WithEvents RdoGetDate As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoMonth As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDay As System.Windows.Forms.RadioButton
    Friend WithEvents RdoWeek As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoPie As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBar As System.Windows.Forms.RadioButton
    Friend WithEvents RdoLine As System.Windows.Forms.RadioButton
End Class
