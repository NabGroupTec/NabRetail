<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTraceRate
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtIdName = New System.Windows.Forms.TextBox
        Me.TxtGroup = New System.Windows.Forms.TextBox
        Me.BtnReport = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtVisitor = New System.Windows.Forms.TextBox
        Me.ChkVisitor = New System.Windows.Forms.CheckBox
        Me.TxtIdVisitor = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtUser = New System.Windows.Forms.TextBox
        Me.ChkUser = New System.Windows.Forms.CheckBox
        Me.TxtIdUser = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RdoRas = New System.Windows.Forms.RadioButton
        Me.RdoMon = New System.Windows.Forms.RadioButton
        Me.RdoEndDate = New System.Windows.Forms.RadioButton
        Me.RdoP = New System.Windows.Forms.RadioButton
        Me.RdoFactor = New System.Windows.Forms.RadioButton
        Me.RdoDate = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.ChkAllp = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Cln_NamP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_SelectP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_ActiveP = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChkAllVisitor = New System.Windows.Forms.CheckBox
        Me.ChkAllUser = New System.Windows.Forms.CheckBox
        Me.GroupBox5.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxtName)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.TxtIdName)
        Me.GroupBox5.Controls.Add(Me.TxtGroup)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(323, 67)
        Me.GroupBox5.TabIndex = 74
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "انتخاب کالا"
        '
        'TxtName
        '
        Me.TxtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtName.Location = New System.Drawing.Point(6, 26)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtName.ShortcutsEnabled = False
        Me.TxtName.Size = New System.Drawing.Size(256, 29)
        Me.TxtName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 21)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "نام کالا"
        '
        'TxtIdName
        '
        Me.TxtIdName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdName.Location = New System.Drawing.Point(229, 26)
        Me.TxtIdName.Name = "TxtIdName"
        Me.TxtIdName.ReadOnly = True
        Me.TxtIdName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdName.ShortcutsEnabled = False
        Me.TxtIdName.Size = New System.Drawing.Size(0, 29)
        Me.TxtIdName.TabIndex = 61
        '
        'TxtGroup
        '
        Me.TxtGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGroup.Location = New System.Drawing.Point(189, 26)
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.ReadOnly = True
        Me.TxtGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtGroup.ShortcutsEnabled = False
        Me.TxtGroup.Size = New System.Drawing.Size(0, 29)
        Me.TxtGroup.TabIndex = 62
        '
        'BtnReport
        '
        Me.BtnReport.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnReport.Location = New System.Drawing.Point(12, 489)
        Me.BtnReport.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.Size = New System.Drawing.Size(104, 30)
        Me.BtnReport.TabIndex = 16
        Me.BtnReport.Text = "تهیه گزارش"
        Me.BtnReport.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 527)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(697, 29)
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
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel4.Text = "F2 تهیه گزارش"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(59, 24)
        Me.ToolStripStatusLabel2.Text = "F3 جستجو"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(92, 24)
        Me.ToolStripStatusLabel3.Text = "F4 انتخاب پیشرفته"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTime)
        Me.GroupBox1.Controls.Add(Me.ChkTaDate)
        Me.GroupBox1.Controls.Add(Me.ChkAzDate)
        Me.GroupBox1.Controls.Add(Me.FarsiDate1)
        Me.GroupBox1.Controls.Add(Me.FarsiDate2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(323, 67)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(197, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(109, 25)
        Me.ChkTime.TabIndex = 1
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(115, 28)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 4
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(269, 28)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 2
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(160, 26)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(102, 29)
        Me.FarsiDate1.TabIndex = 3
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(6, 26)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(102, 29)
        Me.FarsiDate2.TabIndex = 5
        Me.FarsiDate2.ThisText = Nothing
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.TxtVisitor)
        Me.GroupBox7.Controls.Add(Me.ChkVisitor)
        Me.GroupBox7.Controls.Add(Me.TxtIdVisitor)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 148)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(323, 68)
        Me.GroupBox7.TabIndex = 86
        Me.GroupBox7.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(270, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 21)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "ویزیتور"
        '
        'TxtVisitor
        '
        Me.TxtVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtVisitor.Enabled = False
        Me.TxtVisitor.Location = New System.Drawing.Point(6, 31)
        Me.TxtVisitor.MaxLength = 18
        Me.TxtVisitor.Name = "TxtVisitor"
        Me.TxtVisitor.ShortcutsEnabled = False
        Me.TxtVisitor.Size = New System.Drawing.Size(256, 29)
        Me.TxtVisitor.TabIndex = 7
        '
        'ChkVisitor
        '
        Me.ChkVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkVisitor.AutoSize = True
        Me.ChkVisitor.Location = New System.Drawing.Point(190, 0)
        Me.ChkVisitor.Name = "ChkVisitor"
        Me.ChkVisitor.Size = New System.Drawing.Size(116, 25)
        Me.ChkVisitor.TabIndex = 6
        Me.ChkVisitor.Text = "محدوديت ویزیتور"
        Me.ChkVisitor.UseVisualStyleBackColor = True
        '
        'TxtIdVisitor
        '
        Me.TxtIdVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdVisitor.Enabled = False
        Me.TxtIdVisitor.Location = New System.Drawing.Point(135, 31)
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
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.TxtUser)
        Me.GroupBox8.Controls.Add(Me.ChkUser)
        Me.GroupBox8.Controls.Add(Me.TxtIdUser)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 222)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox8.Size = New System.Drawing.Size(323, 68)
        Me.GroupBox8.TabIndex = 87
        Me.GroupBox8.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(282, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 21)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "کاربر"
        '
        'TxtUser
        '
        Me.TxtUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUser.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUser.Enabled = False
        Me.TxtUser.Location = New System.Drawing.Point(6, 29)
        Me.TxtUser.MaxLength = 18
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.ShortcutsEnabled = False
        Me.TxtUser.Size = New System.Drawing.Size(256, 29)
        Me.TxtUser.TabIndex = 9
        '
        'ChkUser
        '
        Me.ChkUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkUser.AutoSize = True
        Me.ChkUser.Location = New System.Drawing.Point(199, -2)
        Me.ChkUser.Name = "ChkUser"
        Me.ChkUser.Size = New System.Drawing.Size(107, 25)
        Me.ChkUser.TabIndex = 8
        Me.ChkUser.Text = "محدوديت کاربر"
        Me.ChkUser.UseVisualStyleBackColor = True
        '
        'TxtIdUser
        '
        Me.TxtIdUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdUser.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdUser.Enabled = False
        Me.TxtIdUser.Location = New System.Drawing.Point(135, 29)
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
        Me.GroupBox2.Controls.Add(Me.RdoRas)
        Me.GroupBox2.Controls.Add(Me.RdoMon)
        Me.GroupBox2.Controls.Add(Me.RdoEndDate)
        Me.GroupBox2.Controls.Add(Me.RdoP)
        Me.GroupBox2.Controls.Add(Me.RdoFactor)
        Me.GroupBox2.Controls.Add(Me.RdoDate)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 296)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(323, 91)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "مرتب سازی"
        '
        'RdoRas
        '
        Me.RdoRas.AutoSize = True
        Me.RdoRas.Location = New System.Drawing.Point(8, 55)
        Me.RdoRas.Name = "RdoRas"
        Me.RdoRas.Size = New System.Drawing.Size(82, 25)
        Me.RdoRas.TabIndex = 15
        Me.RdoRas.Text = "راس تسویه"
        Me.RdoRas.UseVisualStyleBackColor = True
        '
        'RdoMon
        '
        Me.RdoMon.AutoSize = True
        Me.RdoMon.Location = New System.Drawing.Point(23, 24)
        Me.RdoMon.Name = "RdoMon"
        Me.RdoMon.Size = New System.Drawing.Size(67, 25)
        Me.RdoMon.TabIndex = 14
        Me.RdoMon.TabStop = True
        Me.RdoMon.Text = "مبلغ کالا"
        Me.RdoMon.UseVisualStyleBackColor = True
        '
        'RdoEndDate
        '
        Me.RdoEndDate.AutoSize = True
        Me.RdoEndDate.Location = New System.Drawing.Point(113, 55)
        Me.RdoEndDate.Name = "RdoEndDate"
        Me.RdoEndDate.Size = New System.Drawing.Size(85, 25)
        Me.RdoEndDate.TabIndex = 13
        Me.RdoEndDate.TabStop = True
        Me.RdoEndDate.Text = "تاریخ تسویه"
        Me.RdoEndDate.UseVisualStyleBackColor = True
        '
        'RdoP
        '
        Me.RdoP.AutoSize = True
        Me.RdoP.Location = New System.Drawing.Point(109, 23)
        Me.RdoP.Name = "RdoP"
        Me.RdoP.Size = New System.Drawing.Size(89, 25)
        Me.RdoP.TabIndex = 12
        Me.RdoP.TabStop = True
        Me.RdoP.Text = "طرف حساب"
        Me.RdoP.UseVisualStyleBackColor = True
        '
        'RdoFactor
        '
        Me.RdoFactor.AutoSize = True
        Me.RdoFactor.Location = New System.Drawing.Point(215, 55)
        Me.RdoFactor.Name = "RdoFactor"
        Me.RdoFactor.Size = New System.Drawing.Size(91, 25)
        Me.RdoFactor.TabIndex = 11
        Me.RdoFactor.Text = "شماره فاکتور"
        Me.RdoFactor.UseVisualStyleBackColor = True
        '
        'RdoDate
        '
        Me.RdoDate.AutoSize = True
        Me.RdoDate.Checked = True
        Me.RdoDate.Location = New System.Drawing.Point(220, 24)
        Me.RdoDate.Name = "RdoDate"
        Me.RdoDate.Size = New System.Drawing.Size(86, 25)
        Me.RdoDate.TabIndex = 10
        Me.RdoDate.TabStop = True
        Me.RdoDate.Text = "تاریخ فاکتور"
        Me.RdoDate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.ChkAllp)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.DGV2)
        Me.GroupBox3.Location = New System.Drawing.Point(341, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(347, 517)
        Me.GroupBox3.TabIndex = 89
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "لیست طرف حساب"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(112, 481)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 30)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "انتخاب پیشرفته"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ChkAllp
        '
        Me.ChkAllp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAllp.AutoSize = True
        Me.ChkAllp.Location = New System.Drawing.Point(6, 485)
        Me.ChkAllp.Name = "ChkAllp"
        Me.ChkAllp.Size = New System.Drawing.Size(84, 25)
        Me.ChkAllp.TabIndex = 19
        Me.ChkAllp.Text = "انتخاب همه"
        Me.ChkAllp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(229, 481)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 30)
        Me.Button1.TabIndex = 17
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_NamP, Me.Cln_IdP, Me.Cln_SelectP, Me.Cln_ActiveP})
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(335, 448)
        Me.DGV2.TabIndex = 20
        '
        'Cln_NamP
        '
        Me.Cln_NamP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_NamP.DataPropertyName = "Nam"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamP.DefaultCellStyle = DataGridViewCellStyle4
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(216, 453)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(102, 25)
        Me.CheckBox1.TabIndex = 90
        Me.CheckBox1.Text = "فقط وعده های "
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"تسویه شده", "تسویه نشده"})
        Me.ComboBox1.Location = New System.Drawing.Point(110, 451)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(106, 29)
        Me.ComboBox1.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 454)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 21)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "نمایش داده شود"
        '
        'ChkAllVisitor
        '
        Me.ChkAllVisitor.AutoSize = True
        Me.ChkAllVisitor.Location = New System.Drawing.Point(36, 393)
        Me.ChkAllVisitor.Name = "ChkAllVisitor"
        Me.ChkAllVisitor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAllVisitor.Size = New System.Drawing.Size(282, 25)
        Me.ChkAllVisitor.TabIndex = 92
        Me.ChkAllVisitor.Text = "جمع وعده تسویه کالا بر حسب ویزیتورها محاسبه شود"
        Me.ChkAllVisitor.UseVisualStyleBackColor = True
        '
        'ChkAllUser
        '
        Me.ChkAllUser.AutoSize = True
        Me.ChkAllUser.Location = New System.Drawing.Point(45, 422)
        Me.ChkAllUser.Name = "ChkAllUser"
        Me.ChkAllUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAllUser.Size = New System.Drawing.Size(273, 25)
        Me.ChkAllUser.TabIndex = 93
        Me.ChkAllUser.Text = "جمع وعده تسویه کالا بر حسب کاربران محاسبه شود"
        Me.ChkAllUser.UseVisualStyleBackColor = True
        '
        'FrmTraceRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 556)
        Me.Controls.Add(Me.ChkAllUser)
        Me.Controls.Add(Me.ChkAllVisitor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnReport)
        Me.Controls.Add(Me.GroupBox5)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmTraceRate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "وعده تسویه کالا"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtIdName As System.Windows.Forms.TextBox
    Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
    Friend WithEvents BtnReport As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtVisitor As System.Windows.Forms.TextBox
    Friend WithEvents ChkVisitor As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdVisitor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents ChkUser As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdUser As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoRas As System.Windows.Forms.RadioButton
    Friend WithEvents RdoMon As System.Windows.Forms.RadioButton
    Friend WithEvents RdoEndDate As System.Windows.Forms.RadioButton
    Friend WithEvents RdoP As System.Windows.Forms.RadioButton
    Friend WithEvents RdoFactor As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDate As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ChkAllp As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Cln_NamP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_SelectP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_ActiveP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkAllVisitor As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAllUser As System.Windows.Forms.CheckBox
End Class
