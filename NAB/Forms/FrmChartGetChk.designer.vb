<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChartGetChk
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChartGetChk))
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
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
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
        Me.ChkBrat = New System.Windows.Forms.CheckBox
        Me.ChkBargasht = New System.Windows.Forms.CheckBox
        Me.ChkDar = New System.Windows.Forms.CheckBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.RdoAllChk = New System.Windows.Forms.RadioButton
        Me.RdoOnlyChk = New System.Windows.Forms.RadioButton
        Me.ChkOther = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtVisitor = New System.Windows.Forms.TextBox
        Me.ChkVisitor = New System.Windows.Forms.CheckBox
        Me.TxtIdVisitor = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtUser = New System.Windows.Forms.TextBox
        Me.ChkUser = New System.Windows.Forms.CheckBox
        Me.TxtIdUser = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RdoMonth = New System.Windows.Forms.RadioButton
        Me.RdoDay = New System.Windows.Forms.RadioButton
        Me.RdoWeek = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RdoPie = New System.Windows.Forms.RadioButton
        Me.RdoBar = New System.Windows.Forms.RadioButton
        Me.RdoLine = New System.Windows.Forms.RadioButton
        Me.ChkPay = New System.Windows.Forms.CheckBox
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
        Me.GroupBox5.Size = New System.Drawing.Size(347, 658)
        Me.GroupBox5.TabIndex = 77
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "لیست طرف حساب"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(112, 626)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 30)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "انتخاب پیشرفته"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ChkAllp
        '
        Me.ChkAllp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAllp.AutoSize = True
        Me.ChkAllp.Location = New System.Drawing.Point(6, 630)
        Me.ChkAllp.Name = "ChkAllp"
        Me.ChkAllp.Size = New System.Drawing.Size(82, 25)
        Me.ChkAllp.TabIndex = 29
        Me.ChkAllp.Text = "انتخاب همه"
        Me.ChkAllp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(229, 626)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 30)
        Me.Button1.TabIndex = 27
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_NamP, Me.Cln_IdP, Me.Cln_SelectP, Me.Cln_ActiveP})
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(335, 589)
        Me.DGV2.TabIndex = 4
        '
        'Cln_NamP
        '
        Me.Cln_NamP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_NamP.DataPropertyName = "Nam"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamP.DefaultCellStyle = DataGridViewCellStyle6
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 671)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RdoPayDate)
        Me.GroupBox3.Controls.Add(Me.RdoGetDate)
        Me.GroupBox3.Controls.Add(Me.ChkTime)
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 200)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(315, 107)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        '
        'RdoPayDate
        '
        Me.RdoPayDate.AutoSize = True
        Me.RdoPayDate.Enabled = False
        Me.RdoPayDate.Location = New System.Drawing.Point(171, 69)
        Me.RdoPayDate.Name = "RdoPayDate"
        Me.RdoPayDate.Size = New System.Drawing.Size(136, 25)
        Me.RdoPayDate.TabIndex = 18
        Me.RdoPayDate.Text = "بر حسب تاریخ سرسید"
        Me.RdoPayDate.UseVisualStyleBackColor = True
        '
        'RdoGetDate
        '
        Me.RdoGetDate.AutoSize = True
        Me.RdoGetDate.Enabled = False
        Me.RdoGetDate.Location = New System.Drawing.Point(6, 69)
        Me.RdoGetDate.Name = "RdoGetDate"
        Me.RdoGetDate.Size = New System.Drawing.Size(129, 25)
        Me.RdoGetDate.TabIndex = 17
        Me.RdoGetDate.Text = "بر حسب تاریخ صدور"
        Me.RdoGetDate.UseVisualStyleBackColor = True
        '
        'ChkTime
        '
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(199, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(107, 25)
        Me.ChkTime.TabIndex = 12
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
        Me.ChkTaDate.TabIndex = 15
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
        Me.ChkAzDate.TabIndex = 13
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
        Me.FarsiDate1.TabIndex = 14
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
        Me.FarsiDate2.TabIndex = 16
        Me.FarsiDate2.ThisText = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTazmini)
        Me.GroupBox1.Controls.Add(Me.ChkVosol)
        Me.GroupBox1.Controls.Add(Me.ChkBrat)
        Me.GroupBox1.Controls.Add(Me.ChkBargasht)
        Me.GroupBox1.Controls.Add(Me.ChkDar)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(315, 104)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "وضعیت اسناد دریافتی"
        '
        'ChkTazmini
        '
        Me.ChkTazmini.AutoSize = True
        Me.ChkTazmini.Location = New System.Drawing.Point(242, 73)
        Me.ChkTazmini.Name = "ChkTazmini"
        Me.ChkTazmini.Size = New System.Drawing.Size(63, 25)
        Me.ChkTazmini.TabIndex = 11
        Me.ChkTazmini.Text = "تضمینی"
        Me.ChkTazmini.UseVisualStyleBackColor = True
        '
        'ChkVosol
        '
        Me.ChkVosol.AutoSize = True
        Me.ChkVosol.Location = New System.Drawing.Point(61, 51)
        Me.ChkVosol.Name = "ChkVosol"
        Me.ChkVosol.Size = New System.Drawing.Size(80, 25)
        Me.ChkVosol.TabIndex = 13
        Me.ChkVosol.Text = "وصول شده"
        Me.ChkVosol.UseVisualStyleBackColor = True
        '
        'ChkBrat
        '
        Me.ChkBrat.AutoSize = True
        Me.ChkBrat.Location = New System.Drawing.Point(90, 28)
        Me.ChkBrat.Name = "ChkBrat"
        Me.ChkBrat.Size = New System.Drawing.Size(51, 25)
        Me.ChkBrat.TabIndex = 12
        Me.ChkBrat.Text = "برات"
        Me.ChkBrat.UseVisualStyleBackColor = True
        '
        'ChkBargasht
        '
        Me.ChkBargasht.AutoSize = True
        Me.ChkBargasht.Location = New System.Drawing.Point(240, 51)
        Me.ChkBargasht.Name = "ChkBargasht"
        Me.ChkBargasht.Size = New System.Drawing.Size(65, 25)
        Me.ChkBargasht.TabIndex = 10
        Me.ChkBargasht.Text = "برگشتی"
        Me.ChkBargasht.UseVisualStyleBackColor = True
        '
        'ChkDar
        '
        Me.ChkDar.AutoSize = True
        Me.ChkDar.Checked = True
        Me.ChkDar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDar.Location = New System.Drawing.Point(204, 28)
        Me.ChkDar.Name = "ChkDar"
        Me.ChkDar.Size = New System.Drawing.Size(101, 25)
        Me.ChkDar.TabIndex = 9
        Me.ChkDar.Text = "در جریان وصول"
        Me.ChkDar.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(217, 633)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(103, 30)
        Me.BtnOk.TabIndex = 26
        Me.BtnOk.Text = "تهیه گزارش"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RdoAllChk)
        Me.GroupBox6.Controls.Add(Me.RdoOnlyChk)
        Me.GroupBox6.Controls.Add(Me.ChkOther)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 115)
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
        Me.RdoAllChk.TabIndex = 10
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
        Me.RdoOnlyChk.TabIndex = 11
        Me.RdoOnlyChk.Text = "فقط چکهای این بخش نمایش داده شود"
        Me.RdoOnlyChk.UseVisualStyleBackColor = True
        '
        'ChkOther
        '
        Me.ChkOther.AutoSize = True
        Me.ChkOther.Checked = True
        Me.ChkOther.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkOther.Location = New System.Drawing.Point(141, 0)
        Me.ChkOther.Name = "ChkOther"
        Me.ChkOther.Size = New System.Drawing.Size(165, 25)
        Me.ChkOther.TabIndex = 9
        Me.ChkOther.Text = "چکهای درآمد ، اموال ، سرمایه"
        Me.ChkOther.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.TxtVisitor)
        Me.GroupBox7.Controls.Add(Me.ChkVisitor)
        Me.GroupBox7.Controls.Add(Me.TxtIdVisitor)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 389)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(315, 70)
        Me.GroupBox7.TabIndex = 81
        Me.GroupBox7.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(265, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 21)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "ویزیتور"
        '
        'TxtVisitor
        '
        Me.TxtVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtVisitor.Enabled = False
        Me.TxtVisitor.Location = New System.Drawing.Point(6, 31)
        Me.TxtVisitor.MaxLength = 18
        Me.TxtVisitor.Name = "TxtVisitor"
        Me.TxtVisitor.ShortcutsEnabled = False
        Me.TxtVisitor.Size = New System.Drawing.Size(255, 29)
        Me.TxtVisitor.TabIndex = 25
        '
        'ChkVisitor
        '
        Me.ChkVisitor.AutoSize = True
        Me.ChkVisitor.Location = New System.Drawing.Point(192, 0)
        Me.ChkVisitor.Name = "ChkVisitor"
        Me.ChkVisitor.Size = New System.Drawing.Size(114, 25)
        Me.ChkVisitor.TabIndex = 24
        Me.ChkVisitor.Text = "محدوديت ویزیتور"
        Me.ChkVisitor.UseVisualStyleBackColor = True
        '
        'TxtIdVisitor
        '
        Me.TxtIdVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdVisitor.Enabled = False
        Me.TxtIdVisitor.Location = New System.Drawing.Point(127, 31)
        Me.TxtIdVisitor.MaxLength = 18
        Me.TxtIdVisitor.Name = "TxtIdVisitor"
        Me.TxtIdVisitor.ReadOnly = True
        Me.TxtIdVisitor.ShortcutsEnabled = False
        Me.TxtIdVisitor.Size = New System.Drawing.Size(33, 29)
        Me.TxtIdVisitor.TabIndex = 15
        Me.TxtIdVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.TxtUser)
        Me.GroupBox8.Controls.Add(Me.ChkUser)
        Me.GroupBox8.Controls.Add(Me.TxtIdUser)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 313)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox8.Size = New System.Drawing.Size(315, 70)
        Me.GroupBox8.TabIndex = 82
        Me.GroupBox8.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(274, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 21)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "کاربر"
        '
        'TxtUser
        '
        Me.TxtUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUser.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUser.Enabled = False
        Me.TxtUser.Location = New System.Drawing.Point(4, 31)
        Me.TxtUser.MaxLength = 18
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ShortcutsEnabled = False
        Me.TxtUser.Size = New System.Drawing.Size(255, 29)
        Me.TxtUser.TabIndex = 23
        '
        'ChkUser
        '
        Me.ChkUser.AutoSize = True
        Me.ChkUser.Location = New System.Drawing.Point(201, 0)
        Me.ChkUser.Name = "ChkUser"
        Me.ChkUser.Size = New System.Drawing.Size(105, 25)
        Me.ChkUser.TabIndex = 22
        Me.ChkUser.Text = "محدوديت کاربر"
        Me.ChkUser.UseVisualStyleBackColor = True
        '
        'TxtIdUser
        '
        Me.TxtIdUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdUser.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdUser.Enabled = False
        Me.TxtIdUser.Location = New System.Drawing.Point(127, 31)
        Me.TxtIdUser.MaxLength = 18
        Me.TxtIdUser.Name = "TxtIdUser"
        Me.TxtIdUser.ReadOnly = True
        Me.TxtIdUser.ShortcutsEnabled = False
        Me.TxtIdUser.Size = New System.Drawing.Size(33, 29)
        Me.TxtIdUser.TabIndex = 15
        Me.TxtIdUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdoMonth)
        Me.GroupBox2.Controls.Add(Me.RdoDay)
        Me.GroupBox2.Controls.Add(Me.RdoWeek)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 533)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(315, 68)
        Me.GroupBox2.TabIndex = 88
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
        Me.GroupBox4.Location = New System.Drawing.Point(6, 465)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(315, 68)
        Me.GroupBox4.TabIndex = 87
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
        'ChkPay
        '
        Me.ChkPay.AutoSize = True
        Me.ChkPay.Checked = True
        Me.ChkPay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPay.Location = New System.Drawing.Point(137, 605)
        Me.ChkPay.Name = "ChkPay"
        Me.ChkPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkPay.Size = New System.Drawing.Size(174, 25)
        Me.ChkPay.TabIndex = 89
        Me.ChkPay.Text = "چکهای خرج شده محاسبه گردد"
        Me.ChkPay.UseVisualStyleBackColor = True
        '
        'FrmChartGetChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 700)
        Me.Controls.Add(Me.ChkPay)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmChartGetChk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نمودار اسناد دریافتی"
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
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkOther As System.Windows.Forms.CheckBox
    Friend WithEvents RdoAllChk As System.Windows.Forms.RadioButton
    Friend WithEvents RdoOnlyChk As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkVisitor As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtVisitor As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdVisitor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents ChkUser As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdUser As System.Windows.Forms.TextBox
    Friend WithEvents RdoPayDate As System.Windows.Forms.RadioButton
    Friend WithEvents RdoGetDate As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoMonth As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDay As System.Windows.Forms.RadioButton
    Friend WithEvents RdoWeek As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoPie As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBar As System.Windows.Forms.RadioButton
    Friend WithEvents RdoLine As System.Windows.Forms.RadioButton
    Friend WithEvents ChkTazmini As System.Windows.Forms.CheckBox
    Friend WithEvents ChkVosol As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBrat As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBargasht As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPay As System.Windows.Forms.CheckBox
End Class
