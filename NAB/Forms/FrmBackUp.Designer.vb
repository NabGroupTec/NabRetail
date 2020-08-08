<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBackUp
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel10 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel12 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtPathBackup = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel13 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel14 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel15 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TxtPathRestore = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.BtnLog = New System.Windows.Forms.Button()
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel16 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel19 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel20 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel17 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel18 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnUninstall = New System.Windows.Forms.Button()
        Me.BtnInstall = New System.Windows.Forms.Button()
        Me.LService = New System.Windows.Forms.Label()
        Me.LInstal = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Num1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TxtAddini = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DT2 = New System.Windows.Forms.DateTimePicker()
        Me.DT1 = New System.Windows.Forms.DateTimePicker()
        Me.ChkTaTime = New System.Windows.Forms.CheckBox()
        Me.ChkAzTime = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkTaDate = New System.Windows.Forms.CheckBox()
        Me.ChkAzDate = New System.Windows.Forms.CheckBox()
        Me.FarsiDate1 = New FarsiDate.FarsiDate()
        Me.FarsiDate2 = New FarsiDate.FarsiDate()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chk7 = New System.Windows.Forms.CheckBox()
        Me.Chk6 = New System.Windows.Forms.CheckBox()
        Me.Chk5 = New System.Windows.Forms.CheckBox()
        Me.Chk4 = New System.Windows.Forms.CheckBox()
        Me.Chk3 = New System.Windows.Forms.CheckBox()
        Me.Chk2 = New System.Windows.Forms.CheckBox()
        Me.Chk1 = New System.Windows.Forms.CheckBox()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FD = New System.Windows.Forms.FolderBrowserDialog()
        Me.OP = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.StatusStrip3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Num1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(2, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(445, 367)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.TxtPathBackup)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(437, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "تهیه نسخه پشتیبان"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel10, Me.ToolStripStatusLabel11, Me.ToolStripStatusLabel12})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 301)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(431, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 114
        '
        'ToolStripStatusLabel10
        '
        Me.ToolStripStatusLabel10.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel10.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel10.Name = "ToolStripStatusLabel10"
        Me.ToolStripStatusLabel10.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel10.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel11.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(103, 24)
        Me.ToolStripStatusLabel11.Text = "F2 تهیه نسخه پشتیبان"
        '
        'ToolStripStatusLabel12
        '
        Me.ToolStripStatusLabel12.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel12.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel12.Name = "ToolStripStatusLabel12"
        Me.ToolStripStatusLabel12.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel12.Text = "ESC خروج"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(292, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 30)
        Me.Button2.TabIndex = 112
        Me.Button2.Text = "تهیه نسخه پشتیبان"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(386, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 29)
        Me.Button1.TabIndex = 111
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtPathBackup
        '
        Me.TxtPathBackup.BackColor = System.Drawing.Color.White
        Me.TxtPathBackup.Location = New System.Drawing.Point(21, 40)
        Me.TxtPathBackup.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPathBackup.MaxLength = 200
        Me.TxtPathBackup.Name = "TxtPathBackup"
        Me.TxtPathBackup.ReadOnly = True
        Me.TxtPathBackup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPathBackup.Size = New System.Drawing.Size(358, 29)
        Me.TxtPathBackup.TabIndex = 109
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.StatusStrip2)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.TxtPathRestore)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(437, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "بازیابی نسخه پشتیبان"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'StatusStrip2
        '
        Me.StatusStrip2.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel13, Me.ToolStripStatusLabel14, Me.ToolStripStatusLabel15})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 301)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip2.Size = New System.Drawing.Size(431, 29)
        Me.StatusStrip2.SizingGrip = False
        Me.StatusStrip2.TabIndex = 117
        '
        'ToolStripStatusLabel13
        '
        Me.ToolStripStatusLabel13.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel13.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel13.Name = "ToolStripStatusLabel13"
        Me.ToolStripStatusLabel13.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel13.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel14
        '
        Me.ToolStripStatusLabel14.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel14.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel14.Name = "ToolStripStatusLabel14"
        Me.ToolStripStatusLabel14.Size = New System.Drawing.Size(112, 24)
        Me.ToolStripStatusLabel14.Text = "F2 بازیابی نسخه پشتیبان"
        '
        'ToolStripStatusLabel15
        '
        Me.ToolStripStatusLabel15.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel15.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15"
        Me.ToolStripStatusLabel15.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel15.Text = "ESC خروج"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(292, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 30)
        Me.Button3.TabIndex = 115
        Me.Button3.Text = "بازیابی نسخه پشتیبان"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(386, 40)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 29)
        Me.Button4.TabIndex = 114
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtPathRestore
        '
        Me.TxtPathRestore.BackColor = System.Drawing.Color.White
        Me.TxtPathRestore.Location = New System.Drawing.Point(21, 40)
        Me.TxtPathRestore.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPathRestore.MaxLength = 200
        Me.TxtPathRestore.Name = "TxtPathRestore"
        Me.TxtPathRestore.ReadOnly = True
        Me.TxtPathRestore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPathRestore.Size = New System.Drawing.Size(358, 29)
        Me.TxtPathRestore.TabIndex = 113
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.BtnLog)
        Me.TabPage3.Controls.Add(Me.StatusStrip3)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.Button5)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(437, 333)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "پشتیبان گیری اتوماتیک"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'BtnLog
        '
        Me.BtnLog.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnLog.Location = New System.Drawing.Point(8, 17)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(40, 34)
        Me.BtnLog.TabIndex = 120
        Me.BtnLog.Text = "Log"
        Me.BtnLog.UseVisualStyleBackColor = True
        '
        'StatusStrip3
        '
        Me.StatusStrip3.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel16, Me.ToolStripStatusLabel19, Me.ToolStripStatusLabel20, Me.ToolStripStatusLabel17, Me.ToolStripStatusLabel18})
        Me.StatusStrip3.Location = New System.Drawing.Point(3, 301)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip3.Size = New System.Drawing.Size(431, 29)
        Me.StatusStrip3.SizingGrip = False
        Me.StatusStrip3.TabIndex = 117
        '
        'ToolStripStatusLabel16
        '
        Me.ToolStripStatusLabel16.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel16.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel16.Name = "ToolStripStatusLabel16"
        Me.ToolStripStatusLabel16.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel16.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel19
        '
        Me.ToolStripStatusLabel19.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel19.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel19.Name = "ToolStripStatusLabel19"
        Me.ToolStripStatusLabel19.Size = New System.Drawing.Size(55, 24)
        Me.ToolStripStatusLabel19.Text = "F2 ذخیره"
        '
        'ToolStripStatusLabel20
        '
        Me.ToolStripStatusLabel20.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel20.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel20.Name = "ToolStripStatusLabel20"
        Me.ToolStripStatusLabel20.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel20.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel17
        '
        Me.ToolStripStatusLabel17.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel17.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel17.Name = "ToolStripStatusLabel17"
        Me.ToolStripStatusLabel17.Size = New System.Drawing.Size(50, 24)
        Me.ToolStripStatusLabel17.Text = "Log F6"
        '
        'ToolStripStatusLabel18
        '
        Me.ToolStripStatusLabel18.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel18.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel18.Name = "ToolStripStatusLabel18"
        Me.ToolStripStatusLabel18.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel18.Text = "ESC خروج"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BtnStop)
        Me.GroupBox6.Controls.Add(Me.BtnStart)
        Me.GroupBox6.Controls.Add(Me.BtnUninstall)
        Me.GroupBox6.Controls.Add(Me.BtnInstall)
        Me.GroupBox6.Controls.Add(Me.LService)
        Me.GroupBox6.Controls.Add(Me.LInstal)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 214)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox6.Size = New System.Drawing.Size(423, 87)
        Me.GroupBox6.TabIndex = 81
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "وضعیت سرویس"
        '
        'BtnStop
        '
        Me.BtnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnStop.Location = New System.Drawing.Point(378, 51)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(39, 32)
        Me.BtnStop.TabIndex = 125
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnStart.Location = New System.Drawing.Point(340, 51)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(39, 32)
        Me.BtnStart.TabIndex = 124
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnUninstall
        '
        Me.BtnUninstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUninstall.Location = New System.Drawing.Point(378, 20)
        Me.BtnUninstall.Name = "BtnUninstall"
        Me.BtnUninstall.Size = New System.Drawing.Size(39, 32)
        Me.BtnUninstall.TabIndex = 123
        Me.BtnUninstall.UseVisualStyleBackColor = True
        '
        'BtnInstall
        '
        Me.BtnInstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnInstall.Location = New System.Drawing.Point(340, 20)
        Me.BtnInstall.Name = "BtnInstall"
        Me.BtnInstall.Size = New System.Drawing.Size(39, 32)
        Me.BtnInstall.TabIndex = 118
        Me.BtnInstall.UseVisualStyleBackColor = True
        '
        'LService
        '
        Me.LService.Location = New System.Drawing.Point(8, 52)
        Me.LService.Name = "LService"
        Me.LService.Size = New System.Drawing.Size(322, 31)
        Me.LService.TabIndex = 121
        '
        'LInstal
        '
        Me.LInstal.Location = New System.Drawing.Point(8, 20)
        Me.LInstal.Name = "LInstal"
        Me.LInstal.Size = New System.Drawing.Size(326, 31)
        Me.LInstal.TabIndex = 120
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Num1)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 158)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(134, 57)
        Me.GroupBox5.TabIndex = 81
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "پشتیبان گیری(ساعت)"
        '
        'Num1
        '
        Me.Num1.Location = New System.Drawing.Point(6, 19)
        Me.Num1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Num1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Num1.Name = "Num1"
        Me.Num1.Size = New System.Drawing.Size(83, 29)
        Me.Num1.TabIndex = 77
        Me.Num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Num1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button6)
        Me.GroupBox4.Controls.Add(Me.TxtAddini)
        Me.GroupBox4.Location = New System.Drawing.Point(148, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(283, 59)
        Me.GroupBox4.TabIndex = 81
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "محل نسخه پشتیبان"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(237, 20)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 29)
        Me.Button6.TabIndex = 119
        Me.Button6.Text = "..."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtAddini
        '
        Me.TxtAddini.BackColor = System.Drawing.Color.White
        Me.TxtAddini.Location = New System.Drawing.Point(6, 20)
        Me.TxtAddini.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtAddini.MaxLength = 200
        Me.TxtAddini.Name = "TxtAddini"
        Me.TxtAddini.ReadOnly = True
        Me.TxtAddini.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtAddini.Size = New System.Drawing.Size(224, 29)
        Me.TxtAddini.TabIndex = 118
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(47, 17)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(95, 34)
        Me.Button5.TabIndex = 82
        Me.Button5.Text = "ذخیره"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DT2)
        Me.GroupBox2.Controls.Add(Me.DT1)
        Me.GroupBox2.Controls.Add(Me.ChkTaTime)
        Me.GroupBox2.Controls.Add(Me.ChkAzTime)
        Me.GroupBox2.Location = New System.Drawing.Point(148, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(283, 57)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "محدودیت ساعت"
        '
        'DT2
        '
        Me.DT2.CalendarFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DT2.Enabled = False
        Me.DT2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DT2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DT2.Location = New System.Drawing.Point(7, 22)
        Me.DT2.Name = "DT2"
        Me.DT2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DT2.ShowUpDown = True
        Me.DT2.Size = New System.Drawing.Size(97, 22)
        Me.DT2.TabIndex = 74
        Me.DT2.Value = New Date(2011, 9, 4, 9, 45, 0, 0)
        '
        'DT1
        '
        Me.DT1.Enabled = False
        Me.DT1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DT1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DT1.Location = New System.Drawing.Point(146, 22)
        Me.DT1.Name = "DT1"
        Me.DT1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DT1.ShowUpDown = True
        Me.DT1.Size = New System.Drawing.Size(97, 22)
        Me.DT1.TabIndex = 73
        Me.DT1.Value = New Date(2011, 9, 4, 9, 45, 0, 0)
        '
        'ChkTaTime
        '
        Me.ChkTaTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaTime.AutoSize = True
        Me.ChkTaTime.Location = New System.Drawing.Point(105, 23)
        Me.ChkTaTime.Name = "ChkTaTime"
        Me.ChkTaTime.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaTime.TabIndex = 68
        Me.ChkTaTime.Text = "تا"
        Me.ChkTaTime.UseVisualStyleBackColor = True
        '
        'ChkAzTime
        '
        Me.ChkAzTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzTime.AutoSize = True
        Me.ChkAzTime.Location = New System.Drawing.Point(241, 23)
        Me.ChkAzTime.Name = "ChkAzTime"
        Me.ChkAzTime.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzTime.TabIndex = 67
        Me.ChkAzTime.Text = "از"
        Me.ChkAzTime.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkTaDate)
        Me.GroupBox3.Controls.Add(Me.ChkAzDate)
        Me.GroupBox3.Controls.Add(Me.FarsiDate1)
        Me.GroupBox3.Controls.Add(Me.FarsiDate2)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 57)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(134, 102)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "محدودیت تاریخ"
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(92, 62)
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
        Me.ChkAzDate.Location = New System.Drawing.Point(92, 28)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 67
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Enabled = False
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(5, 25)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(84, 29)
        Me.FarsiDate1.TabIndex = 66
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Enabled = False
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(5, 61)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(84, 29)
        Me.FarsiDate2.TabIndex = 65
        Me.FarsiDate2.ThisText = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Chk7)
        Me.GroupBox1.Controls.Add(Me.Chk6)
        Me.GroupBox1.Controls.Add(Me.Chk5)
        Me.GroupBox1.Controls.Add(Me.Chk4)
        Me.GroupBox1.Controls.Add(Me.Chk3)
        Me.GroupBox1.Controls.Add(Me.Chk2)
        Me.GroupBox1.Controls.Add(Me.Chk1)
        Me.GroupBox1.Location = New System.Drawing.Point(148, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(283, 102)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ایام هفته"
        '
        'Chk7
        '
        Me.Chk7.AutoSize = True
        Me.Chk7.Location = New System.Drawing.Point(5, 28)
        Me.Chk7.Name = "Chk7"
        Me.Chk7.Size = New System.Drawing.Size(53, 25)
        Me.Chk7.TabIndex = 6
        Me.Chk7.Text = "جمعه"
        Me.Chk7.UseVisualStyleBackColor = True
        '
        'Chk6
        '
        Me.Chk6.AutoSize = True
        Me.Chk6.Location = New System.Drawing.Point(68, 59)
        Me.Chk6.Name = "Chk6"
        Me.Chk6.Size = New System.Drawing.Size(69, 25)
        Me.Chk6.TabIndex = 5
        Me.Chk6.Text = "پنجشنبه"
        Me.Chk6.UseVisualStyleBackColor = True
        '
        'Chk5
        '
        Me.Chk5.AutoSize = True
        Me.Chk5.Location = New System.Drawing.Point(64, 28)
        Me.Chk5.Name = "Chk5"
        Me.Chk5.Size = New System.Drawing.Size(73, 25)
        Me.Chk5.TabIndex = 4
        Me.Chk5.Text = "چهارشنبه"
        Me.Chk5.UseVisualStyleBackColor = True
        '
        'Chk4
        '
        Me.Chk4.AutoSize = True
        Me.Chk4.Location = New System.Drawing.Point(140, 59)
        Me.Chk4.Name = "Chk4"
        Me.Chk4.Size = New System.Drawing.Size(70, 25)
        Me.Chk4.TabIndex = 3
        Me.Chk4.Text = "سه شنبه"
        Me.Chk4.UseVisualStyleBackColor = True
        '
        'Chk3
        '
        Me.Chk3.AutoSize = True
        Me.Chk3.Location = New System.Drawing.Point(143, 28)
        Me.Chk3.Name = "Chk3"
        Me.Chk3.Size = New System.Drawing.Size(67, 25)
        Me.Chk3.TabIndex = 2
        Me.Chk3.Text = "دو شنبه"
        Me.Chk3.UseVisualStyleBackColor = True
        '
        'Chk2
        '
        Me.Chk2.AutoSize = True
        Me.Chk2.Location = New System.Drawing.Point(216, 59)
        Me.Chk2.Name = "Chk2"
        Me.Chk2.Size = New System.Drawing.Size(62, 25)
        Me.Chk2.TabIndex = 1
        Me.Chk2.Text = "یکشنبه"
        Me.Chk2.UseVisualStyleBackColor = True
        '
        'Chk1
        '
        Me.Chk1.AutoSize = True
        Me.Chk1.Location = New System.Drawing.Point(226, 28)
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Size = New System.Drawing.Size(52, 25)
        Me.Chk1.TabIndex = 0
        Me.Chk1.Text = "شنبه"
        Me.Chk1.UseVisualStyleBackColor = True
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(103, 24)
        Me.ToolStripStatusLabel2.Text = "F2 تهیه نسخه پشتیبان"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
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
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(112, 24)
        Me.ToolStripStatusLabel4.Text = "F2 بازیابی نسخه پشتیبان"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel5.Text = "ESC خروج"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel6.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(112, 24)
        Me.ToolStripStatusLabel7.Text = "F2 بازیابی نسخه پشتیبان"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel9.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel9.Text = "ESC خروج"
        '
        'OP
        '
        Me.OP.Filter = "NAB Files (*.NAB)|*.NAB"
        Me.OP.Title = "بازیابی نسخه پشتیبان"
        '
        'FrmBackUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 370)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBackUp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نسخه پشتیبان"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.Num1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtPathBackup As System.Windows.Forms.TextBox
    Friend WithEvents FD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxtPathRestore As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OP As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Num1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DT2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkTaTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzTime As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Chk7 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk6 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk5 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk4 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk3 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk2 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TxtAddini As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents LInstal As System.Windows.Forms.Label
    Friend WithEvents LService As System.Windows.Forms.Label
    Friend WithEvents BtnInstall As System.Windows.Forms.Button
    Friend WithEvents BtnUninstall As System.Windows.Forms.Button
    Friend WithEvents BtnStop As System.Windows.Forms.Button
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel10 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel12 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel13 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel14 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel15 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel16 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel17 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel18 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel19 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnLog As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel20 As System.Windows.Forms.ToolStripStatusLabel
End Class
