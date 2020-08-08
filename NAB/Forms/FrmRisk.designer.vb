<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRisk
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
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.TxtGroup = New System.Windows.Forms.TextBox
        Me.ChkGroup = New System.Windows.Forms.CheckBox
        Me.TxtIdGroup = New System.Windows.Forms.TextBox
        Me.ChKOther = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtMon4 = New System.Windows.Forms.TextBox
        Me.TxtMon3 = New System.Windows.Forms.TextBox
        Me.ChkTaMon1 = New System.Windows.Forms.CheckBox
        Me.ChkAzMon1 = New System.Windows.Forms.CheckBox
        Me.ChKMon = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TxtMonBed2 = New System.Windows.Forms.TextBox
        Me.TxtMonBed1 = New System.Windows.Forms.TextBox
        Me.ChkTaMonBed = New System.Windows.Forms.CheckBox
        Me.ChkAzMonBed = New System.Windows.Forms.CheckBox
        Me.ChkBedMon = New System.Windows.Forms.CheckBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.TxtMonGet2 = New System.Windows.Forms.TextBox
        Me.TxtMonGet1 = New System.Windows.Forms.TextBox
        Me.ChkTaMonGet = New System.Windows.Forms.CheckBox
        Me.ChkAzMonGet = New System.Windows.Forms.CheckBox
        Me.ChkGet = New System.Windows.Forms.CheckBox
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox3.Location = New System.Drawing.Point(12, 77)
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
        Me.ChkP.Size = New System.Drawing.Size(58, 25)
        Me.ChkP.TabIndex = 10
        Me.ChkP.Text = "منطقه"
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 611)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(304, 29)
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
        Me.BtnSave.Location = New System.Drawing.Point(199, 572)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(97, 30)
        Me.BtnSave.TabIndex = 35
        Me.BtnSave.Text = "تهیه گزارش"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'ChkDay
        '
        Me.ChkDay.AutoSize = True
        Me.ChkDay.Location = New System.Drawing.Point(127, -1)
        Me.ChkDay.Name = "ChkDay"
        Me.ChkDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDay.Size = New System.Drawing.Size(148, 25)
        Me.ChkDay.TabIndex = 12
        Me.ChkDay.Text = "محدوديت درصد ریسک"
        Me.ChkDay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkBes)
        Me.GroupBox2.Controls.Add(Me.Chkbe)
        Me.GroupBox2.Controls.Add(Me.Chkbed)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 3)
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
        Me.TxtMon2.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        Me.TxtMon1.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        Me.ChkAzMon.Location = New System.Drawing.Point(239, 30)
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
        Me.GroupBox4.Location = New System.Drawing.Point(12, 174)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(284, 68)
        Me.GroupBox4.TabIndex = 67
        Me.GroupBox4.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TxtGroup)
        Me.GroupBox7.Controls.Add(Me.ChkGroup)
        Me.GroupBox7.Controls.Add(Me.TxtIdGroup)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 242)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(284, 70)
        Me.GroupBox7.TabIndex = 68
        Me.GroupBox7.TabStop = False
        '
        'TxtGroup
        '
        Me.TxtGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGroup.BackColor = System.Drawing.SystemColors.Window
        Me.TxtGroup.Enabled = False
        Me.TxtGroup.Location = New System.Drawing.Point(8, 28)
        Me.TxtGroup.MaxLength = 18
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.ShortcutsEnabled = False
        Me.TxtGroup.Size = New System.Drawing.Size(219, 29)
        Me.TxtGroup.TabIndex = 18
        '
        'ChkGroup
        '
        Me.ChkGroup.AutoSize = True
        Me.ChkGroup.Location = New System.Drawing.Point(171, 0)
        Me.ChkGroup.Name = "ChkGroup"
        Me.ChkGroup.Size = New System.Drawing.Size(105, 25)
        Me.ChkGroup.TabIndex = 17
        Me.ChkGroup.Text = "محدوديت گروه"
        Me.ChkGroup.UseVisualStyleBackColor = True
        '
        'TxtIdGroup
        '
        Me.TxtIdGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdGroup.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdGroup.Enabled = False
        Me.TxtIdGroup.Location = New System.Drawing.Point(82, 28)
        Me.TxtIdGroup.MaxLength = 18
        Me.TxtIdGroup.Name = "TxtIdGroup"
        Me.TxtIdGroup.ReadOnly = True
        Me.TxtIdGroup.ShortcutsEnabled = False
        Me.TxtIdGroup.Size = New System.Drawing.Size(37, 29)
        Me.TxtIdGroup.TabIndex = 16
        Me.TxtIdGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChKOther
        '
        Me.ChKOther.AutoSize = True
        Me.ChKOther.Checked = True
        Me.ChKOther.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChKOther.Location = New System.Drawing.Point(40, 541)
        Me.ChKOther.Name = "ChKOther"
        Me.ChKOther.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChKOther.Size = New System.Drawing.Size(248, 25)
        Me.ChKOther.TabIndex = 34
        Me.ChKOther.Text = "طرف حساب با ماهیت سایر نمایش داده نشود"
        Me.ChKOther.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtMon4)
        Me.GroupBox1.Controls.Add(Me.TxtMon3)
        Me.GroupBox1.Controls.Add(Me.ChkTaMon1)
        Me.GroupBox1.Controls.Add(Me.ChkAzMon1)
        Me.GroupBox1.Controls.Add(Me.ChKMon)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 313)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(285, 70)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        '
        'TxtMon4
        '
        Me.TxtMon4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMon4.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMon4.Enabled = False
        Me.TxtMon4.Location = New System.Drawing.Point(8, 30)
        Me.TxtMon4.MaxLength = 18
        Me.TxtMon4.Name = "TxtMon4"
        Me.TxtMon4.ShortcutsEnabled = False
        Me.TxtMon4.Size = New System.Drawing.Size(90, 29)
        Me.TxtMon4.TabIndex = 23
        Me.TxtMon4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMon3
        '
        Me.TxtMon3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMon3.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMon3.Enabled = False
        Me.TxtMon3.Location = New System.Drawing.Point(146, 30)
        Me.TxtMon3.MaxLength = 18
        Me.TxtMon3.Name = "TxtMon3"
        Me.TxtMon3.ShortcutsEnabled = False
        Me.TxtMon3.Size = New System.Drawing.Size(81, 29)
        Me.TxtMon3.TabIndex = 21
        Me.TxtMon3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkTaMon1
        '
        Me.ChkTaMon1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaMon1.AutoSize = True
        Me.ChkTaMon1.Enabled = False
        Me.ChkTaMon1.Location = New System.Drawing.Point(104, 34)
        Me.ChkTaMon1.Name = "ChkTaMon1"
        Me.ChkTaMon1.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaMon1.TabIndex = 22
        Me.ChkTaMon1.Text = "تا"
        Me.ChkTaMon1.UseVisualStyleBackColor = True
        '
        'ChkAzMon1
        '
        Me.ChkAzMon1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzMon1.AutoSize = True
        Me.ChkAzMon1.Enabled = False
        Me.ChkAzMon1.Location = New System.Drawing.Point(239, 34)
        Me.ChkAzMon1.Name = "ChkAzMon1"
        Me.ChkAzMon1.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzMon1.TabIndex = 20
        Me.ChkAzMon1.Text = "از"
        Me.ChkAzMon1.UseVisualStyleBackColor = True
        '
        'ChKMon
        '
        Me.ChKMon.AutoSize = True
        Me.ChKMon.Location = New System.Drawing.Point(166, -1)
        Me.ChKMon.Name = "ChKMon"
        Me.ChKMon.Size = New System.Drawing.Size(109, 25)
        Me.ChKMon.TabIndex = 19
        Me.ChKMon.Text = "محدوديت مانده"
        Me.ChKMon.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxtMonBed2)
        Me.GroupBox5.Controls.Add(Me.TxtMonBed1)
        Me.GroupBox5.Controls.Add(Me.ChkTaMonBed)
        Me.GroupBox5.Controls.Add(Me.ChkAzMonBed)
        Me.GroupBox5.Controls.Add(Me.ChkBedMon)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 465)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(285, 70)
        Me.GroupBox5.TabIndex = 82
        Me.GroupBox5.TabStop = False
        '
        'TxtMonBed2
        '
        Me.TxtMonBed2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMonBed2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonBed2.Enabled = False
        Me.TxtMonBed2.Location = New System.Drawing.Point(8, 30)
        Me.TxtMonBed2.MaxLength = 18
        Me.TxtMonBed2.Name = "TxtMonBed2"
        Me.TxtMonBed2.ShortcutsEnabled = False
        Me.TxtMonBed2.Size = New System.Drawing.Size(90, 29)
        Me.TxtMonBed2.TabIndex = 33
        Me.TxtMonBed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMonBed1
        '
        Me.TxtMonBed1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMonBed1.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonBed1.Enabled = False
        Me.TxtMonBed1.Location = New System.Drawing.Point(146, 30)
        Me.TxtMonBed1.MaxLength = 18
        Me.TxtMonBed1.Name = "TxtMonBed1"
        Me.TxtMonBed1.ShortcutsEnabled = False
        Me.TxtMonBed1.Size = New System.Drawing.Size(81, 29)
        Me.TxtMonBed1.TabIndex = 31
        Me.TxtMonBed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkTaMonBed
        '
        Me.ChkTaMonBed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaMonBed.AutoSize = True
        Me.ChkTaMonBed.Enabled = False
        Me.ChkTaMonBed.Location = New System.Drawing.Point(104, 34)
        Me.ChkTaMonBed.Name = "ChkTaMonBed"
        Me.ChkTaMonBed.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaMonBed.TabIndex = 32
        Me.ChkTaMonBed.Text = "تا"
        Me.ChkTaMonBed.UseVisualStyleBackColor = True
        '
        'ChkAzMonBed
        '
        Me.ChkAzMonBed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzMonBed.AutoSize = True
        Me.ChkAzMonBed.Enabled = False
        Me.ChkAzMonBed.Location = New System.Drawing.Point(239, 34)
        Me.ChkAzMonBed.Name = "ChkAzMonBed"
        Me.ChkAzMonBed.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzMonBed.TabIndex = 30
        Me.ChkAzMonBed.Text = "از"
        Me.ChkAzMonBed.UseVisualStyleBackColor = True
        '
        'ChkBedMon
        '
        Me.ChkBedMon.AutoSize = True
        Me.ChkBedMon.Location = New System.Drawing.Point(152, 0)
        Me.ChkBedMon.Name = "ChkBedMon"
        Me.ChkBedMon.Size = New System.Drawing.Size(124, 25)
        Me.ChkBedMon.TabIndex = 29
        Me.ChkBedMon.Text = "محدوديت بدهکاری"
        Me.ChkBedMon.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TxtMonGet2)
        Me.GroupBox6.Controls.Add(Me.TxtMonGet1)
        Me.GroupBox6.Controls.Add(Me.ChkTaMonGet)
        Me.GroupBox6.Controls.Add(Me.ChkAzMonGet)
        Me.GroupBox6.Controls.Add(Me.ChkGet)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 389)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox6.Size = New System.Drawing.Size(285, 70)
        Me.GroupBox6.TabIndex = 82
        Me.GroupBox6.TabStop = False
        '
        'TxtMonGet2
        '
        Me.TxtMonGet2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMonGet2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonGet2.Enabled = False
        Me.TxtMonGet2.Location = New System.Drawing.Point(8, 30)
        Me.TxtMonGet2.MaxLength = 18
        Me.TxtMonGet2.Name = "TxtMonGet2"
        Me.TxtMonGet2.ShortcutsEnabled = False
        Me.TxtMonGet2.Size = New System.Drawing.Size(90, 29)
        Me.TxtMonGet2.TabIndex = 28
        Me.TxtMonGet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMonGet1
        '
        Me.TxtMonGet1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMonGet1.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonGet1.Enabled = False
        Me.TxtMonGet1.Location = New System.Drawing.Point(146, 30)
        Me.TxtMonGet1.MaxLength = 18
        Me.TxtMonGet1.Name = "TxtMonGet1"
        Me.TxtMonGet1.ShortcutsEnabled = False
        Me.TxtMonGet1.Size = New System.Drawing.Size(81, 29)
        Me.TxtMonGet1.TabIndex = 26
        Me.TxtMonGet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkTaMonGet
        '
        Me.ChkTaMonGet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaMonGet.AutoSize = True
        Me.ChkTaMonGet.Enabled = False
        Me.ChkTaMonGet.Location = New System.Drawing.Point(104, 34)
        Me.ChkTaMonGet.Name = "ChkTaMonGet"
        Me.ChkTaMonGet.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaMonGet.TabIndex = 27
        Me.ChkTaMonGet.Text = "تا"
        Me.ChkTaMonGet.UseVisualStyleBackColor = True
        '
        'ChkAzMonGet
        '
        Me.ChkAzMonGet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzMonGet.AutoSize = True
        Me.ChkAzMonGet.Enabled = False
        Me.ChkAzMonGet.Location = New System.Drawing.Point(239, 34)
        Me.ChkAzMonGet.Name = "ChkAzMonGet"
        Me.ChkAzMonGet.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzMonGet.TabIndex = 25
        Me.ChkAzMonGet.Text = "از"
        Me.ChkAzMonGet.UseVisualStyleBackColor = True
        '
        'ChkGet
        '
        Me.ChkGet.AutoSize = True
        Me.ChkGet.Location = New System.Drawing.Point(128, -1)
        Me.ChkGet.Name = "ChkGet"
        Me.ChkGet.Size = New System.Drawing.Size(148, 25)
        Me.ChkGet.TabIndex = 24
        Me.ChkGet.Text = "محدوديت اسناد دریافتی"
        Me.ChkGet.UseVisualStyleBackColor = True
        '
        'FrmRisk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 640)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChKOther)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRisk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش درصد ریسک "
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
    Friend WithEvents ChkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdGroup As System.Windows.Forms.TextBox
    Friend WithEvents ChKOther As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMon4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMon3 As System.Windows.Forms.TextBox
    Friend WithEvents ChkTaMon1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzMon1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChKMon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMonBed2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonBed1 As System.Windows.Forms.TextBox
    Friend WithEvents ChkTaMonBed As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzMonBed As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBedMon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMonGet2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonGet1 As System.Windows.Forms.TextBox
    Friend WithEvents ChkTaMonGet As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzMonGet As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGet As System.Windows.Forms.CheckBox
End Class
