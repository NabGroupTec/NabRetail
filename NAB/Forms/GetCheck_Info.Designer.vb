<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetCheck_Info
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
        Me.TxtMon = New System.Windows.Forms.TextBox
        Me.TxtBank = New System.Windows.Forms.TextBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.TxtShobeh = New System.Windows.Forms.TextBox
        Me.TxtPayDate = New FarsiDate.FarsiDate
        Me.TxtNumber = New System.Windows.Forms.TextBox
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmdcan = New System.Windows.Forms.Button
        Me.cmdsave = New System.Windows.Forms.Button
        Me.TxtIdName = New System.Windows.Forms.TextBox
        Me.CmbTypeChk = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBrat = New System.Windows.Forms.Label
        Me.TxtBratBank = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FarsiDateBrat = New FarsiDate.FarsiDate
        Me.LdateBrat = New System.Windows.Forms.Label
        Me.TxtBratID = New System.Windows.Forms.TextBox
        Me.LEdit = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LMon = New System.Windows.Forms.Label
        Me.LDate = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtSanad = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtNumberChk = New System.Windows.Forms.TextBox
        Me.LAction = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LIdFac = New System.Windows.Forms.Label
        Me.LState = New System.Windows.Forms.Label
        Me.LTime = New System.Windows.Forms.Label
        Me.BtnRas = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMon
        '
        Me.TxtMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMon.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMon.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMon.Location = New System.Drawing.Point(71, 210)
        Me.TxtMon.MaxLength = 18
        Me.TxtMon.Name = "TxtMon"
        Me.TxtMon.Size = New System.Drawing.Size(178, 22)
        Me.TxtMon.TabIndex = 6
        Me.TxtMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtBank
        '
        Me.TxtBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBank.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBank.Location = New System.Drawing.Point(183, 32)
        Me.TxtBank.MaxLength = 20
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.ShortcutsEnabled = False
        Me.TxtBank.Size = New System.Drawing.Size(150, 22)
        Me.TxtBank.TabIndex = 1
        Me.TxtBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtName
        '
        Me.TxtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtName.BackColor = System.Drawing.SystemColors.Window
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtName.Location = New System.Drawing.Point(364, 210)
        Me.TxtName.MaxLength = 20
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ShortcutsEnabled = False
        Me.TxtName.Size = New System.Drawing.Size(195, 22)
        Me.TxtName.TabIndex = 4
        Me.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtShobeh
        '
        Me.TxtShobeh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShobeh.BackColor = System.Drawing.SystemColors.Window
        Me.TxtShobeh.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShobeh.Location = New System.Drawing.Point(183, 60)
        Me.TxtShobeh.MaxLength = 20
        Me.TxtShobeh.Name = "TxtShobeh"
        Me.TxtShobeh.Size = New System.Drawing.Size(150, 22)
        Me.TxtShobeh.TabIndex = 2
        Me.TxtShobeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPayDate
        '
        Me.TxtPayDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPayDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPayDate.Location = New System.Drawing.Point(460, 53)
        Me.TxtPayDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPayDate.Name = "TxtPayDate"
        Me.TxtPayDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPayDate.Size = New System.Drawing.Size(147, 29)
        Me.TxtPayDate.TabIndex = 0
        Me.TxtPayDate.ThisText = Nothing
        '
        'TxtNumber
        '
        Me.TxtNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNumber.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumber.Location = New System.Drawing.Point(364, 244)
        Me.TxtNumber.MaxLength = 20
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(195, 22)
        Me.TxtNumber.TabIndex = 5
        Me.TxtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtDisc
        '
        Me.TxtDisc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDisc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDisc.Location = New System.Drawing.Point(12, 284)
        Me.TxtDisc.MaxLength = 150
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.Size = New System.Drawing.Size(237, 22)
        Me.TxtDisc.TabIndex = 8
        Me.TxtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(55, 24)
        Me.ToolStripStatusLabel2.Text = "F2 ذخیره"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel7.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'cmdcan
        '
        Me.cmdcan.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdcan.BackColor = System.Drawing.Color.Transparent
        Me.cmdcan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdcan.Location = New System.Drawing.Point(511, 313)
        Me.cmdcan.Name = "cmdcan"
        Me.cmdcan.Size = New System.Drawing.Size(75, 30)
        Me.cmdcan.TabIndex = 13
        Me.cmdcan.Text = "انصراف"
        Me.cmdcan.UseVisualStyleBackColor = False
        '
        'cmdsave
        '
        Me.cmdsave.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdsave.BackColor = System.Drawing.Color.Transparent
        Me.cmdsave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdsave.Location = New System.Drawing.Point(592, 313)
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.Size = New System.Drawing.Size(75, 30)
        Me.cmdsave.TabIndex = 12
        Me.cmdsave.Text = "ذخيره"
        Me.cmdsave.UseVisualStyleBackColor = False
        '
        'TxtIdName
        '
        Me.TxtIdName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdName.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIdName.Location = New System.Drawing.Point(373, 210)
        Me.TxtIdName.MaxLength = 20
        Me.TxtIdName.Name = "TxtIdName"
        Me.TxtIdName.ReadOnly = True
        Me.TxtIdName.ShortcutsEnabled = False
        Me.TxtIdName.Size = New System.Drawing.Size(82, 22)
        Me.TxtIdName.TabIndex = 34
        Me.TxtIdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbTypeChk
        '
        Me.CmbTypeChk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTypeChk.FormattingEnabled = True
        Me.CmbTypeChk.Location = New System.Drawing.Point(336, 24)
        Me.CmbTypeChk.Name = "CmbTypeChk"
        Me.CmbTypeChk.Size = New System.Drawing.Size(111, 29)
        Me.CmbTypeChk.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(447, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 21)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "نوع چک"
        '
        'LBrat
        '
        Me.LBrat.AutoSize = True
        Me.LBrat.Location = New System.Drawing.Point(259, 27)
        Me.LBrat.Name = "LBrat"
        Me.LBrat.Size = New System.Drawing.Size(73, 21)
        Me.LBrat.TabIndex = 39
        Me.LBrat.Text = "برات به بانک"
        '
        'TxtBratBank
        '
        Me.TxtBratBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBratBank.Location = New System.Drawing.Point(156, 24)
        Me.TxtBratBank.MaxLength = 20
        Me.TxtBratBank.Name = "TxtBratBank"
        Me.TxtBratBank.ShortcutsEnabled = False
        Me.TxtBratBank.Size = New System.Drawing.Size(99, 29)
        Me.TxtBratBank.TabIndex = 10
        Me.TxtBratBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.FarsiDateBrat)
        Me.GroupBox1.Controls.Add(Me.LdateBrat)
        Me.GroupBox1.Controls.Add(Me.TxtBratBank)
        Me.GroupBox1.Controls.Add(Me.CmbTypeChk)
        Me.GroupBox1.Controls.Add(Me.LBrat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtBratID)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 308)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(501, 65)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "سایر اطلاعات"
        '
        'FarsiDateBrat
        '
        Me.FarsiDateBrat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDateBrat.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDateBrat.Location = New System.Drawing.Point(7, 24)
        Me.FarsiDateBrat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDateBrat.Name = "FarsiDateBrat"
        Me.FarsiDateBrat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDateBrat.Size = New System.Drawing.Size(75, 29)
        Me.FarsiDateBrat.TabIndex = 11
        Me.FarsiDateBrat.ThisText = Nothing
        '
        'LdateBrat
        '
        Me.LdateBrat.AutoSize = True
        Me.LdateBrat.Location = New System.Drawing.Point(88, 29)
        Me.LdateBrat.Name = "LdateBrat"
        Me.LdateBrat.Size = New System.Drawing.Size(62, 21)
        Me.LdateBrat.TabIndex = 42
        Me.LdateBrat.Text = "تاریخ برات"
        '
        'TxtBratID
        '
        Me.TxtBratID.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBratID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBratID.Location = New System.Drawing.Point(161, 27)
        Me.TxtBratID.MaxLength = 20
        Me.TxtBratID.Name = "TxtBratID"
        Me.TxtBratID.ReadOnly = True
        Me.TxtBratID.Size = New System.Drawing.Size(94, 22)
        Me.TxtBratID.TabIndex = 43
        Me.TxtBratID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LEdit
        '
        Me.LEdit.AutoSize = True
        Me.LEdit.Location = New System.Drawing.Point(668, 306)
        Me.LEdit.Name = "LEdit"
        Me.LEdit.Size = New System.Drawing.Size(0, 21)
        Me.LEdit.TabIndex = 43
        Me.LEdit.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.Label1.Location = New System.Drawing.Point(255, 284)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "شرح چک"
        '
        'LMon
        '
        Me.LMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LMon.BackColor = System.Drawing.Color.Transparent
        Me.LMon.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.LMon.Location = New System.Drawing.Point(71, 104)
        Me.LMon.Name = "LMon"
        Me.LMon.Size = New System.Drawing.Size(471, 52)
        Me.LMon.TabIndex = 5
        Me.LMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LDate
        '
        Me.LDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LDate.BackColor = System.Drawing.Color.Transparent
        Me.LDate.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.LDate.Location = New System.Drawing.Point(398, 22)
        Me.LDate.Name = "LDate"
        Me.LDate.Size = New System.Drawing.Size(209, 21)
        Me.LDate.TabIndex = 1
        Me.LDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Global.NAB.My.Resources.Resources.Check3
        Me.PictureBox1.Image = Global.NAB.My.Resources.Resources.Check3
        Me.PictureBox1.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(672, 311)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.Label3.Location = New System.Drawing.Point(588, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 21)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "سند دفتری"
        '
        'TxtSanad
        '
        Me.TxtSanad.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSanad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSanad.Location = New System.Drawing.Point(460, 284)
        Me.TxtSanad.MaxLength = 150
        Me.TxtSanad.Name = "TxtSanad"
        Me.TxtSanad.Size = New System.Drawing.Size(99, 22)
        Me.TxtSanad.TabIndex = 7
        Me.TxtSanad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.Label4.Location = New System.Drawing.Point(112, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 21)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "سریال"
        '
        'TxtNumberChk
        '
        Me.TxtNumberChk.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNumberChk.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumberChk.Location = New System.Drawing.Point(7, 60)
        Me.TxtNumberChk.MaxLength = 15
        Me.TxtNumberChk.Name = "TxtNumberChk"
        Me.TxtNumberChk.Size = New System.Drawing.Size(99, 22)
        Me.TxtNumberChk.TabIndex = 3
        Me.TxtNumberChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LAction
        '
        Me.LAction.AutoSize = True
        Me.LAction.ForeColor = System.Drawing.Color.Red
        Me.LAction.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.LAction.Location = New System.Drawing.Point(702, 360)
        Me.LAction.Name = "LAction"
        Me.LAction.Size = New System.Drawing.Size(0, 21)
        Me.LAction.TabIndex = 48
        Me.LAction.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 376)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(672, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 49
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel3.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(55, 24)
        Me.ToolStripStatusLabel4.Text = "F2 ذخیره"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel9.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel9.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(75, 24)
        Me.ToolStripStatusLabel5.Text = "F4 راس گیری"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel6.Text = "ESC خروج"
        '
        'LIdFac
        '
        Me.LIdFac.AutoSize = True
        Me.LIdFac.Location = New System.Drawing.Point(360, 383)
        Me.LIdFac.Name = "LIdFac"
        Me.LIdFac.Size = New System.Drawing.Size(0, 21)
        Me.LIdFac.TabIndex = 44
        Me.LIdFac.Visible = False
        '
        'LState
        '
        Me.LState.AutoSize = True
        Me.LState.Location = New System.Drawing.Point(336, 387)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 50
        Me.LState.Visible = False
        '
        'LTime
        '
        Me.LTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LTime.BackColor = System.Drawing.Color.Transparent
        Me.LTime.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.LTime.Location = New System.Drawing.Point(389, 53)
        Me.LTime.Name = "LTime"
        Me.LTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LTime.Size = New System.Drawing.Size(69, 29)
        Me.LTime.TabIndex = 51
        Me.LTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnRas
        '
        Me.BtnRas.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnRas.BackColor = System.Drawing.Color.Transparent
        Me.BtnRas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRas.Location = New System.Drawing.Point(592, 344)
        Me.BtnRas.Name = "BtnRas"
        Me.BtnRas.Size = New System.Drawing.Size(75, 30)
        Me.BtnRas.TabIndex = 56
        Me.BtnRas.Text = "راس گیری"
        Me.BtnRas.UseVisualStyleBackColor = False
        '
        'GetCheck_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 405)
        Me.Controls.Add(Me.BtnRas)
        Me.Controls.Add(Me.LTime)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.LIdFac)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LAction)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNumberChk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtSanad)
        Me.Controls.Add(Me.LEdit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtIdName)
        Me.Controls.Add(Me.cmdcan)
        Me.Controls.Add(Me.cmdsave)
        Me.Controls.Add(Me.TxtDisc)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.LMon)
        Me.Controls.Add(Me.TxtPayDate)
        Me.Controls.Add(Me.TxtShobeh)
        Me.Controls.Add(Me.TxtBank)
        Me.Controls.Add(Me.TxtMon)
        Me.Controls.Add(Me.LDate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GetCheck_Info"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ثبت چک"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LDate As System.Windows.Forms.Label
    Friend WithEvents TxtMon As System.Windows.Forms.TextBox
    Friend WithEvents TxtBank As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtShobeh As System.Windows.Forms.TextBox
    Friend WithEvents TxtPayDate As FarsiDate.FarsiDate
    Friend WithEvents LMon As System.Windows.Forms.Label
    Friend WithEvents TxtNumber As System.Windows.Forms.TextBox
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdcan As System.Windows.Forms.Button
    Friend WithEvents cmdsave As System.Windows.Forms.Button
    Friend WithEvents TxtIdName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbTypeChk As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBrat As System.Windows.Forms.Label
    Friend WithEvents TxtBratBank As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LdateBrat As System.Windows.Forms.Label
    Friend WithEvents FarsiDateBrat As FarsiDate.FarsiDate
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents TxtBratID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSanad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNumberChk As System.Windows.Forms.TextBox
    Friend WithEvents LAction As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LIdFac As System.Windows.Forms.Label
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents LTime As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnRas As System.Windows.Forms.Button
End Class
