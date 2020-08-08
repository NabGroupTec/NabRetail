<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportInfoExit
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkExit = New System.Windows.Forms.CheckBox
        Me.TxtExit = New System.Windows.Forms.TextBox
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
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtVisitor = New System.Windows.Forms.TextBox
        Me.ChkVisitor = New System.Windows.Forms.CheckBox
        Me.TxtIdVisitor = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtCar = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkCar = New System.Windows.Forms.CheckBox
        Me.TxtIdCar = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TxtReciver = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtIdRecevier = New System.Windows.Forms.TextBox
        Me.ChkReciver = New System.Windows.Forms.CheckBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnReport = New System.Windows.Forms.Button
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.ChkExit)
        Me.GroupBox4.Controls.Add(Me.TxtExit)
        Me.GroupBox4.Location = New System.Drawing.Point(7, -1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(288, 68)
        Me.GroupBox4.TabIndex = 71
        Me.GroupBox4.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(237, 32)
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
        Me.ChkExit.TabIndex = 0
        Me.ChkExit.Text = "محدودیت خروجی"
        Me.ChkExit.UseVisualStyleBackColor = True
        '
        'TxtExit
        '
        Me.TxtExit.BackColor = System.Drawing.SystemColors.Window
        Me.TxtExit.Enabled = False
        Me.TxtExit.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtExit.Location = New System.Drawing.Point(6, 29)
        Me.TxtExit.MaxLength = 20
        Me.TxtExit.Name = "TxtExit"
        Me.TxtExit.ShortcutsEnabled = False
        Me.TxtExit.Size = New System.Drawing.Size(220, 29)
        Me.TxtExit.TabIndex = 1
        Me.TxtExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkTime)
        Me.GroupBox2.Controls.Add(Me.ChkTaDate)
        Me.GroupBox2.Controls.Add(Me.ChkAzDate)
        Me.GroupBox2.Controls.Add(Me.FarsiDate1)
        Me.GroupBox2.Controls.Add(Me.FarsiDate2)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(288, 68)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(82, -4)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(194, 25)
        Me.ChkTime.TabIndex = 2
        Me.ChkTime.Text = "محدودیت زمانی(بر اساس خروجی)"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Enabled = False
        Me.ChkTaDate.Location = New System.Drawing.Point(92, 31)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 5
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Enabled = False
        Me.ChkAzDate.Location = New System.Drawing.Point(239, 31)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 3
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Enabled = False
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(145, 29)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(81, 29)
        Me.FarsiDate1.TabIndex = 4
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Enabled = False
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(6, 29)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(81, 29)
        Me.FarsiDate2.TabIndex = 6
        Me.FarsiDate2.ThisText = Nothing
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
        Me.GroupBox3.Location = New System.Drawing.Point(7, 140)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(288, 95)
        Me.GroupBox3.TabIndex = 73
        Me.GroupBox3.TabStop = False
        '
        'ChkP
        '
        Me.ChkP.AutoSize = True
        Me.ChkP.Location = New System.Drawing.Point(82, 57)
        Me.ChkP.Name = "ChkP"
        Me.ChkP.Size = New System.Drawing.Size(55, 25)
        Me.ChkP.TabIndex = 11
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
        Me.ChkCity.TabIndex = 9
        Me.ChkCity.Text = "شهر"
        Me.ChkCity.UseVisualStyleBackColor = True
        '
        'ChkPart
        '
        Me.ChkPart.AutoSize = True
        Me.ChkPart.Location = New System.Drawing.Point(164, -2)
        Me.ChkPart.Name = "ChkPart"
        Me.ChkPart.Size = New System.Drawing.Size(112, 25)
        Me.ChkPart.TabIndex = 7
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
        Me.CmbPart.TabIndex = 12
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
        Me.CmbCity.TabIndex = 10
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
        Me.CmbOstan.TabIndex = 8
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
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.TxtVisitor)
        Me.GroupBox7.Controls.Add(Me.ChkVisitor)
        Me.GroupBox7.Controls.Add(Me.TxtIdVisitor)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 241)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(288, 70)
        Me.GroupBox7.TabIndex = 82
        Me.GroupBox7.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 21)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "ویزیتور"
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
        Me.TxtVisitor.Size = New System.Drawing.Size(206, 29)
        Me.TxtVisitor.TabIndex = 14
        '
        'ChkVisitor
        '
        Me.ChkVisitor.AutoSize = True
        Me.ChkVisitor.Location = New System.Drawing.Point(160, 0)
        Me.ChkVisitor.Name = "ChkVisitor"
        Me.ChkVisitor.Size = New System.Drawing.Size(116, 25)
        Me.ChkVisitor.TabIndex = 13
        Me.ChkVisitor.Text = "محدوديت ویزیتور"
        Me.ChkVisitor.UseVisualStyleBackColor = True
        '
        'TxtIdVisitor
        '
        Me.TxtIdVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdVisitor.Enabled = False
        Me.TxtIdVisitor.Location = New System.Drawing.Point(100, 31)
        Me.TxtIdVisitor.MaxLength = 18
        Me.TxtIdVisitor.Name = "TxtIdVisitor"
        Me.TxtIdVisitor.ReadOnly = True
        Me.TxtIdVisitor.ShortcutsEnabled = False
        Me.TxtIdVisitor.Size = New System.Drawing.Size(33, 29)
        Me.TxtIdVisitor.TabIndex = 15
        Me.TxtIdVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtCar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkCar)
        Me.GroupBox1.Controls.Add(Me.TxtIdCar)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 313)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(288, 70)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        '
        'TxtCar
        '
        Me.TxtCar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCar.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCar.Enabled = False
        Me.TxtCar.Location = New System.Drawing.Point(6, 28)
        Me.TxtCar.MaxLength = 20
        Me.TxtCar.Name = "TxtCar"
        Me.TxtCar.ShortcutsEnabled = False
        Me.TxtCar.Size = New System.Drawing.Size(206, 29)
        Me.TxtCar.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(221, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 21)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "وسیله حمل"
        '
        'ChkCar
        '
        Me.ChkCar.AutoSize = True
        Me.ChkCar.Location = New System.Drawing.Point(142, 0)
        Me.ChkCar.Name = "ChkCar"
        Me.ChkCar.Size = New System.Drawing.Size(134, 25)
        Me.ChkCar.TabIndex = 15
        Me.ChkCar.Text = "محدوديت وسیله حمل"
        Me.ChkCar.UseVisualStyleBackColor = True
        '
        'TxtIdCar
        '
        Me.TxtIdCar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdCar.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdCar.Enabled = False
        Me.TxtIdCar.Location = New System.Drawing.Point(140, 28)
        Me.TxtIdCar.MaxLength = 20
        Me.TxtIdCar.Name = "TxtIdCar"
        Me.TxtIdCar.ShortcutsEnabled = False
        Me.TxtIdCar.Size = New System.Drawing.Size(37, 29)
        Me.TxtIdCar.TabIndex = 25
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxtReciver)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.TxtIdRecevier)
        Me.GroupBox5.Controls.Add(Me.ChkReciver)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 387)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(288, 70)
        Me.GroupBox5.TabIndex = 84
        Me.GroupBox5.TabStop = False
        '
        'TxtReciver
        '
        Me.TxtReciver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtReciver.BackColor = System.Drawing.SystemColors.Window
        Me.TxtReciver.Enabled = False
        Me.TxtReciver.Location = New System.Drawing.Point(6, 28)
        Me.TxtReciver.MaxLength = 20
        Me.TxtReciver.Name = "TxtReciver"
        Me.TxtReciver.ShortcutsEnabled = False
        Me.TxtReciver.Size = New System.Drawing.Size(206, 29)
        Me.TxtReciver.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label14.Location = New System.Drawing.Point(216, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 21)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "مامور توزیع"
        '
        'TxtIdRecevier
        '
        Me.TxtIdRecevier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdRecevier.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdRecevier.Enabled = False
        Me.TxtIdRecevier.Location = New System.Drawing.Point(67, 28)
        Me.TxtIdRecevier.MaxLength = 20
        Me.TxtIdRecevier.Name = "TxtIdRecevier"
        Me.TxtIdRecevier.ReadOnly = True
        Me.TxtIdRecevier.ShortcutsEnabled = False
        Me.TxtIdRecevier.Size = New System.Drawing.Size(36, 29)
        Me.TxtIdRecevier.TabIndex = 38
        '
        'ChkReciver
        '
        Me.ChkReciver.AutoSize = True
        Me.ChkReciver.Location = New System.Drawing.Point(140, 0)
        Me.ChkReciver.Name = "ChkReciver"
        Me.ChkReciver.Size = New System.Drawing.Size(136, 25)
        Me.ChkReciver.TabIndex = 17
        Me.ChkReciver.Text = "محدوديت مامور توزیع"
        Me.ChkReciver.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 505)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(304, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 87
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
        'BtnReport
        '
        Me.BtnReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReport.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnReport.Location = New System.Drawing.Point(186, 468)
        Me.BtnReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.Size = New System.Drawing.Size(109, 30)
        Me.BtnReport.TabIndex = 19
        Me.BtnReport.Text = "تهیه گزارش"
        Me.BtnReport.UseVisualStyleBackColor = True
        '
        'FrmReportInfoExit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 534)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnReport)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportInfoExit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "پیگیری خروجی"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkExit As System.Windows.Forms.CheckBox
    Friend WithEvents TxtExit As System.Windows.Forms.TextBox
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
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtVisitor As System.Windows.Forms.TextBox
    Friend WithEvents ChkVisitor As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdVisitor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkCar As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkReciver As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtIdCar As System.Windows.Forms.TextBox
    Friend WithEvents TxtReciver As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtIdRecevier As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnReport As System.Windows.Forms.Button
End Class
