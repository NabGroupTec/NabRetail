<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Define_AddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Define_AddUser))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtP = New System.Windows.Forms.TextBox()
        Me.Txtname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTypeImage = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.NumDayDel = New System.Windows.Forms.NumericUpDown()
        Me.ChkDel = New System.Windows.Forms.CheckBox()
        Me.ChkEdit = New System.Windows.Forms.CheckBox()
        Me.NumDayEdit = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChkMojodyAnbar = New System.Windows.Forms.CheckBox()
        Me.ChkMojodyBank = New System.Windows.Forms.CheckBox()
        Me.ChkMojodyBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkPrivate = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkNoSell = New System.Windows.Forms.CheckBox()
        Me.ChkAdd = New System.Windows.Forms.CheckBox()
        Me.ChkDec = New System.Windows.Forms.CheckBox()
        Me.ChkMonFac = New System.Windows.Forms.CheckBox()
        Me.ChkHajm = New System.Windows.Forms.CheckBox()
        Me.ChkDate = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdcan = New System.Windows.Forms.Button()
        Me.cmdsave = New System.Windows.Forms.Button()
        Me.Chk_RegeditFactor = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.NumDayDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumDayEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TxtP)
        Me.GroupBox2.Controls.Add(Me.Txtname)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtTypeImage)
        Me.GroupBox2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(363, 96)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "مشخصات کاربر"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(298, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "کلمه عبور"
        '
        'TxtP
        '
        Me.TxtP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtP.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtP.Location = New System.Drawing.Point(19, 56)
        Me.TxtP.MaxLength = 20
        Me.TxtP.Name = "TxtP"
        Me.TxtP.Size = New System.Drawing.Size(260, 29)
        Me.TxtP.TabIndex = 1
        '
        'Txtname
        '
        Me.Txtname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtname.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtname.Location = New System.Drawing.Point(19, 26)
        Me.Txtname.MaxLength = 45
        Me.Txtname.Name = "Txtname"
        Me.Txtname.Size = New System.Drawing.Size(260, 29)
        Me.Txtname.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(302, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "نام کاربر"
        '
        'TxtTypeImage
        '
        Me.TxtTypeImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTypeImage.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtTypeImage.Location = New System.Drawing.Point(175, 56)
        Me.TxtTypeImage.MaxLength = 45
        Me.TxtTypeImage.Name = "TxtTypeImage"
        Me.TxtTypeImage.ReadOnly = True
        Me.TxtTypeImage.Size = New System.Drawing.Size(34, 29)
        Me.TxtTypeImage.TabIndex = 25
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.NumDayDel)
        Me.GroupBox8.Controls.Add(Me.ChkDel)
        Me.GroupBox8.Controls.Add(Me.ChkEdit)
        Me.GroupBox8.Controls.Add(Me.NumDayEdit)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox8.Size = New System.Drawing.Size(363, 67)
        Me.GroupBox8.TabIndex = 21
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "محدودیت زمانی"
        '
        'NumDayDel
        '
        Me.NumDayDel.Enabled = False
        Me.NumDayDel.Location = New System.Drawing.Point(11, 31)
        Me.NumDayDel.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.NumDayDel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumDayDel.Name = "NumDayDel"
        Me.NumDayDel.Size = New System.Drawing.Size(41, 29)
        Me.NumDayDel.TabIndex = 5
        Me.NumDayDel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumDayDel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ChkDel
        '
        Me.ChkDel.AutoSize = True
        Me.ChkDel.Location = New System.Drawing.Point(58, 32)
        Me.ChkDel.Name = "ChkDel"
        Me.ChkDel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDel.Size = New System.Drawing.Size(109, 25)
        Me.ChkDel.TabIndex = 4
        Me.ChkDel.Text = "محدودیت حذف"
        Me.ChkDel.UseVisualStyleBackColor = True
        '
        'ChkEdit
        '
        Me.ChkEdit.AutoSize = True
        Me.ChkEdit.Location = New System.Drawing.Point(237, 32)
        Me.ChkEdit.Name = "ChkEdit"
        Me.ChkEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkEdit.Size = New System.Drawing.Size(117, 25)
        Me.ChkEdit.TabIndex = 2
        Me.ChkEdit.Text = "محدودیت ویرایش"
        Me.ChkEdit.UseVisualStyleBackColor = True
        '
        'NumDayEdit
        '
        Me.NumDayEdit.Enabled = False
        Me.NumDayEdit.Location = New System.Drawing.Point(193, 31)
        Me.NumDayEdit.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.NumDayEdit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumDayEdit.Name = "NumDayEdit"
        Me.NumDayEdit.Size = New System.Drawing.Size(41, 29)
        Me.NumDayEdit.TabIndex = 3
        Me.NumDayEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumDayEdit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(19, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label11.Size = New System.Drawing.Size(338, 47)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "نکته : اجازه ثبت موجودی منفی برای گزینه های بالا باعث  محاسبه اشتباه سود و زیان خ" & _
    "واهد شد"
        '
        'ChkMojodyAnbar
        '
        Me.ChkMojodyAnbar.AutoSize = True
        Me.ChkMojodyAnbar.Checked = True
        Me.ChkMojodyAnbar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMojodyAnbar.Location = New System.Drawing.Point(145, 78)
        Me.ChkMojodyAnbar.Name = "ChkMojodyAnbar"
        Me.ChkMojodyAnbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkMojodyAnbar.Size = New System.Drawing.Size(209, 25)
        Me.ChkMojodyAnbar.TabIndex = 15
        Me.ChkMojodyAnbar.Text = "اجازه موجودی منفی برای موجودی انبار"
        Me.ChkMojodyAnbar.UseVisualStyleBackColor = True
        '
        'ChkMojodyBank
        '
        Me.ChkMojodyBank.AutoSize = True
        Me.ChkMojodyBank.Checked = True
        Me.ChkMojodyBank.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMojodyBank.Enabled = False
        Me.ChkMojodyBank.Location = New System.Drawing.Point(148, 52)
        Me.ChkMojodyBank.Name = "ChkMojodyBank"
        Me.ChkMojodyBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkMojodyBank.Size = New System.Drawing.Size(206, 25)
        Me.ChkMojodyBank.TabIndex = 14
        Me.ChkMojodyBank.Text = "اجازه موجودی منفی برای حساب بانک"
        Me.ChkMojodyBank.UseVisualStyleBackColor = True
        '
        'ChkMojodyBox
        '
        Me.ChkMojodyBox.AutoSize = True
        Me.ChkMojodyBox.Checked = True
        Me.ChkMojodyBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMojodyBox.Enabled = False
        Me.ChkMojodyBox.Location = New System.Drawing.Point(135, 26)
        Me.ChkMojodyBox.Name = "ChkMojodyBox"
        Me.ChkMojodyBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkMojodyBox.Size = New System.Drawing.Size(219, 25)
        Me.ChkMojodyBox.TabIndex = 13
        Me.ChkMojodyBox.Text = "اجازه موجودی منفی برای حساب صندوق"
        Me.ChkMojodyBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkMojodyBox)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.ChkMojodyBank)
        Me.GroupBox1.Controls.Add(Me.ChkMojodyAnbar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 380)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(363, 159)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "کنترل موجودی"
        '
        'ChkPrivate
        '
        Me.ChkPrivate.AutoSize = True
        Me.ChkPrivate.Location = New System.Drawing.Point(6, 56)
        Me.ChkPrivate.Name = "ChkPrivate"
        Me.ChkPrivate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkPrivate.Size = New System.Drawing.Size(190, 25)
        Me.ChkPrivate.TabIndex = 10
        Me.ChkPrivate.Text = "عدم نمایش سندهای سایر کاربران"
        Me.ChkPrivate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Chk_RegeditFactor)
        Me.GroupBox3.Controls.Add(Me.ChkNoSell)
        Me.GroupBox3.Controls.Add(Me.ChkAdd)
        Me.GroupBox3.Controls.Add(Me.ChkPrivate)
        Me.GroupBox3.Controls.Add(Me.ChkDec)
        Me.GroupBox3.Controls.Add(Me.ChkMonFac)
        Me.GroupBox3.Controls.Add(Me.ChkHajm)
        Me.GroupBox3.Controls.Add(Me.ChkDate)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 187)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(363, 187)
        Me.GroupBox3.TabIndex = 71
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "کنترل موجودی"
        '
        'ChkNoSell
        '
        Me.ChkNoSell.AutoSize = True
        Me.ChkNoSell.Location = New System.Drawing.Point(18, 118)
        Me.ChkNoSell.Name = "ChkNoSell"
        Me.ChkNoSell.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkNoSell.Size = New System.Drawing.Size(336, 25)
        Me.ChkNoSell.TabIndex = 12
        Me.ChkNoSell.Text = "عدم فروش به مشتریانی که سطح اعتبارشان به اتمام رسیده است"
        Me.ChkNoSell.UseVisualStyleBackColor = True
        '
        'ChkAdd
        '
        Me.ChkAdd.AutoSize = True
        Me.ChkAdd.Location = New System.Drawing.Point(206, 87)
        Me.ChkAdd.Name = "ChkAdd"
        Me.ChkAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAdd.Size = New System.Drawing.Size(148, 25)
        Me.ChkAdd.TabIndex = 8
        Me.ChkAdd.Text = "عدم تغییر اضافات فاکتور"
        Me.ChkAdd.UseVisualStyleBackColor = True
        '
        'ChkDec
        '
        Me.ChkDec.AutoSize = True
        Me.ChkDec.Location = New System.Drawing.Point(201, 56)
        Me.ChkDec.Name = "ChkDec"
        Me.ChkDec.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDec.Size = New System.Drawing.Size(153, 25)
        Me.ChkDec.TabIndex = 7
        Me.ChkDec.Text = "عدم تغییر کسورات فاکتور"
        Me.ChkDec.UseVisualStyleBackColor = True
        '
        'ChkMonFac
        '
        Me.ChkMonFac.AutoSize = True
        Me.ChkMonFac.Location = New System.Drawing.Point(214, 27)
        Me.ChkMonFac.Name = "ChkMonFac"
        Me.ChkMonFac.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkMonFac.Size = New System.Drawing.Size(140, 25)
        Me.ChkMonFac.TabIndex = 6
        Me.ChkMonFac.Text = "عدم تغییر قیمت فاکتور"
        Me.ChkMonFac.UseVisualStyleBackColor = True
        '
        'ChkHajm
        '
        Me.ChkHajm.AutoSize = True
        Me.ChkHajm.Location = New System.Drawing.Point(11, 25)
        Me.ChkHajm.Name = "ChkHajm"
        Me.ChkHajm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkHajm.Size = New System.Drawing.Size(185, 25)
        Me.ChkHajm.TabIndex = 9
        Me.ChkHajm.Text = "عدم تغییر تخفیفات حجمی فاکتور"
        Me.ChkHajm.UseVisualStyleBackColor = True
        '
        'ChkDate
        '
        Me.ChkDate.AutoSize = True
        Me.ChkDate.Location = New System.Drawing.Point(64, 87)
        Me.ChkDate.Name = "ChkDate"
        Me.ChkDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDate.Size = New System.Drawing.Size(132, 25)
        Me.ChkDate.TabIndex = 11
        Me.ChkDate.Text = "عدم تغییر تاریخ اسناد"
        Me.ChkDate.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 578)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(384, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 72
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(45, 24)
        Me.ToolStripStatusLabel2.Text = "F2 ثبت"
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
        Me.cmdcan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdcan.Location = New System.Drawing.Point(219, 545)
        Me.cmdcan.Name = "cmdcan"
        Me.cmdcan.Size = New System.Drawing.Size(75, 30)
        Me.cmdcan.TabIndex = 17
        Me.cmdcan.Text = "انصراف"
        Me.cmdcan.UseVisualStyleBackColor = True
        '
        'cmdsave
        '
        Me.cmdsave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdsave.Location = New System.Drawing.Point(300, 545)
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.Size = New System.Drawing.Size(75, 30)
        Me.cmdsave.TabIndex = 16
        Me.cmdsave.Text = "ثبت"
        Me.cmdsave.UseVisualStyleBackColor = True
        '
        'Chk_RegeditFactor
        '
        Me.Chk_RegeditFactor.AutoSize = True
        Me.Chk_RegeditFactor.Location = New System.Drawing.Point(85, 149)
        Me.Chk_RegeditFactor.Name = "Chk_RegeditFactor"
        Me.Chk_RegeditFactor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_RegeditFactor.Size = New System.Drawing.Size(269, 25)
        Me.Chk_RegeditFactor.TabIndex = 13
        Me.Chk_RegeditFactor.Text = "اجازه صدور فاکتور به مشتریان دارای مانده حساب"
        Me.Chk_RegeditFactor.UseVisualStyleBackColor = True
        '
        'Define_AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 607)
        Me.Controls.Add(Me.cmdcan)
        Me.Controls.Add(Me.cmdsave)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Define_AddUser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف کاربر"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.NumDayDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumDayEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtP As System.Windows.Forms.TextBox
    Friend WithEvents Txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTypeImage As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkDel As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEdit As System.Windows.Forms.CheckBox
    Friend WithEvents NumDayEdit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ChkMojodyAnbar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMojodyBank As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMojodyBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPrivate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkAdd As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDec As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMonFac As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkHajm As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNoSell As System.Windows.Forms.CheckBox
    Friend WithEvents NumDayDel As System.Windows.Forms.NumericUpDown
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdcan As System.Windows.Forms.Button
    Friend WithEvents cmdsave As System.Windows.Forms.Button
    Friend WithEvents Chk_RegeditFactor As System.Windows.Forms.CheckBox
End Class
