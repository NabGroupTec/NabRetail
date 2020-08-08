<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayCheck_Info
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
        Me.TxtPayDate = New FarsiDate.FarsiDate
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmdcan = New System.Windows.Forms.Button
        Me.cmdsave = New System.Windows.Forms.Button
        Me.TxtIdName = New System.Windows.Forms.TextBox
        Me.CmbTypeChk = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
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
        Me.TxtNumber = New System.Windows.Forms.Label
        Me.TxtNameChk = New System.Windows.Forms.Label
        Me.TxtShobeh = New System.Windows.Forms.Label
        Me.TxtIdBank = New System.Windows.Forms.TextBox
        Me.LState = New System.Windows.Forms.Label
        Me.LIdFac = New System.Windows.Forms.Label
        Me.LTime = New System.Windows.Forms.Label
        Me.BtnRas = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TxtBank.Location = New System.Drawing.Point(183, 35)
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
        Me.TxtName.Location = New System.Drawing.Point(129, 168)
        Me.TxtName.MaxLength = 20
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ShortcutsEnabled = False
        Me.TxtName.Size = New System.Drawing.Size(478, 22)
        Me.TxtName.TabIndex = 4
        Me.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'TxtDisc
        '
        Me.TxtDisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDisc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDisc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDisc.Location = New System.Drawing.Point(12, 284)
        Me.TxtDisc.MaxLength = 150
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.Size = New System.Drawing.Size(237, 22)
        Me.TxtDisc.TabIndex = 8
        Me.TxtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 373)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(672, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 31
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
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(75, 24)
        Me.ToolStripStatusLabel3.Text = "F4 راس گیری"
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
        Me.cmdcan.Location = New System.Drawing.Point(511, 326)
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
        Me.cmdsave.Location = New System.Drawing.Point(592, 326)
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
        Me.TxtIdName.Location = New System.Drawing.Point(419, 168)
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
        Me.CmbTypeChk.Location = New System.Drawing.Point(16, 19)
        Me.CmbTypeChk.Name = "CmbTypeChk"
        Me.CmbTypeChk.Size = New System.Drawing.Size(120, 29)
        Me.CmbTypeChk.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 21)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "نوع چک"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CmbTypeChk)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 309)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(229, 62)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "سایر اطلاعات"
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
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.TxtSanad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.LAction.Location = New System.Drawing.Point(671, 348)
        Me.LAction.Name = "LAction"
        Me.LAction.Size = New System.Drawing.Size(0, 21)
        Me.LAction.TabIndex = 48
        Me.LAction.Visible = False
        '
        'TxtNumber
        '
        Me.TxtNumber.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.TxtNumber.Location = New System.Drawing.Point(339, 249)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(220, 21)
        Me.TxtNumber.TabIndex = 44
        Me.TxtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtNameChk
        '
        Me.TxtNameChk.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.TxtNameChk.Location = New System.Drawing.Point(339, 211)
        Me.TxtNameChk.Name = "TxtNameChk"
        Me.TxtNameChk.Size = New System.Drawing.Size(220, 21)
        Me.TxtNameChk.TabIndex = 49
        Me.TxtNameChk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtShobeh
        '
        Me.TxtShobeh.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.TxtShobeh.Location = New System.Drawing.Point(183, 60)
        Me.TxtShobeh.Name = "TxtShobeh"
        Me.TxtShobeh.Size = New System.Drawing.Size(150, 21)
        Me.TxtShobeh.TabIndex = 50
        Me.TxtShobeh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtIdBank
        '
        Me.TxtIdBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdBank.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIdBank.Location = New System.Drawing.Point(229, 32)
        Me.TxtIdBank.MaxLength = 20
        Me.TxtIdBank.Name = "TxtIdBank"
        Me.TxtIdBank.ReadOnly = True
        Me.TxtIdBank.Size = New System.Drawing.Size(81, 22)
        Me.TxtIdBank.TabIndex = 51
        Me.TxtIdBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LState
        '
        Me.LState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LState.AutoSize = True
        Me.LState.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.LState.Location = New System.Drawing.Point(267, 352)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 52
        Me.LState.Visible = False
        '
        'LIdFac
        '
        Me.LIdFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LIdFac.AutoSize = True
        Me.LIdFac.Image = Global.NAB.My.Resources.Resources.BackGroundCheck
        Me.LIdFac.Location = New System.Drawing.Point(249, 352)
        Me.LIdFac.Name = "LIdFac"
        Me.LIdFac.Size = New System.Drawing.Size(0, 21)
        Me.LIdFac.TabIndex = 53
        Me.LIdFac.Visible = False
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
        Me.LTime.TabIndex = 54
        Me.LTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnRas
        '
        Me.BtnRas.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnRas.BackColor = System.Drawing.Color.Transparent
        Me.BtnRas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRas.Location = New System.Drawing.Point(430, 326)
        Me.BtnRas.Name = "BtnRas"
        Me.BtnRas.Size = New System.Drawing.Size(75, 30)
        Me.BtnRas.TabIndex = 55
        Me.BtnRas.Text = "راس گیری"
        Me.BtnRas.UseVisualStyleBackColor = False
        '
        'PayCheck_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 402)
        Me.Controls.Add(Me.BtnRas)
        Me.Controls.Add(Me.LTime)
        Me.Controls.Add(Me.LIdFac)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.TxtShobeh)
        Me.Controls.Add(Me.TxtNameChk)
        Me.Controls.Add(Me.TxtNumber)
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
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtDisc)
        Me.Controls.Add(Me.LMon)
        Me.Controls.Add(Me.TxtPayDate)
        Me.Controls.Add(Me.TxtBank)
        Me.Controls.Add(Me.TxtMon)
        Me.Controls.Add(Me.LDate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtIdBank)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PayCheck_Info"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ثبت چک"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LDate As System.Windows.Forms.Label
    Friend WithEvents TxtMon As System.Windows.Forms.TextBox
    Friend WithEvents TxtBank As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtPayDate As FarsiDate.FarsiDate
    Friend WithEvents LMon As System.Windows.Forms.Label
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSanad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNumberChk As System.Windows.Forms.TextBox
    Friend WithEvents LAction As System.Windows.Forms.Label
    Friend WithEvents TxtNumber As System.Windows.Forms.Label
    Friend WithEvents TxtNameChk As System.Windows.Forms.Label
    Friend WithEvents TxtShobeh As System.Windows.Forms.Label
    Friend WithEvents TxtIdBank As System.Windows.Forms.TextBox
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents LIdFac As System.Windows.Forms.Label
    Friend WithEvents LTime As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnRas As System.Windows.Forms.Button
End Class
