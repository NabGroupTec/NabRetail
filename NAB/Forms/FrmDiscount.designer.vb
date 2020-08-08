<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiscount
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkFroshAmani = New System.Windows.Forms.CheckBox
        Me.ChkKharidAmani = New System.Windows.Forms.CheckBox
        Me.ChkService = New System.Windows.Forms.CheckBox
        Me.ChkCharge = New System.Windows.Forms.CheckBox
        Me.ChkPay = New System.Windows.Forms.CheckBox
        Me.ChkGet = New System.Windows.Forms.CheckBox
        Me.ChkBackFrosh = New System.Windows.Forms.CheckBox
        Me.ChkFrosh = New System.Windows.Forms.CheckBox
        Me.ChkBackKharid = New System.Windows.Forms.CheckBox
        Me.ChkKharid = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ChkGroup = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RdoSelect = New System.Windows.Forms.RadioButton
        Me.RdoFrosh = New System.Windows.Forms.RadioButton
        Me.RdoBuy = New System.Windows.Forms.RadioButton
        Me.RdoAll = New System.Windows.Forms.RadioButton
        Me.ChkZ = New System.Windows.Forms.CheckBox
        Me.ChkAddDec = New System.Windows.Forms.CheckBox
        Me.ChkOnly = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkFroshAmani)
        Me.GroupBox2.Controls.Add(Me.ChkKharidAmani)
        Me.GroupBox2.Controls.Add(Me.ChkService)
        Me.GroupBox2.Controls.Add(Me.ChkCharge)
        Me.GroupBox2.Controls.Add(Me.ChkPay)
        Me.GroupBox2.Controls.Add(Me.ChkGet)
        Me.GroupBox2.Controls.Add(Me.ChkBackFrosh)
        Me.GroupBox2.Controls.Add(Me.ChkFrosh)
        Me.GroupBox2.Controls.Add(Me.ChkBackKharid)
        Me.GroupBox2.Controls.Add(Me.ChkKharid)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 151)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(442, 144)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "نوع سند تخفیفات"
        '
        'ChkFroshAmani
        '
        Me.ChkFroshAmani.AutoSize = True
        Me.ChkFroshAmani.Checked = True
        Me.ChkFroshAmani.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFroshAmani.Location = New System.Drawing.Point(179, 55)
        Me.ChkFroshAmani.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkFroshAmani.Name = "ChkFroshAmani"
        Me.ChkFroshAmani.Size = New System.Drawing.Size(119, 25)
        Me.ChkFroshAmani.TabIndex = 14
        Me.ChkFroshAmani.Text = "فاکتور فروش امانی"
        Me.ChkFroshAmani.UseVisualStyleBackColor = True
        '
        'ChkKharidAmani
        '
        Me.ChkKharidAmani.AutoSize = True
        Me.ChkKharidAmani.Checked = True
        Me.ChkKharidAmani.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkKharidAmani.Location = New System.Drawing.Point(324, 55)
        Me.ChkKharidAmani.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkKharidAmani.Name = "ChkKharidAmani"
        Me.ChkKharidAmani.Size = New System.Drawing.Size(113, 25)
        Me.ChkKharidAmani.TabIndex = 10
        Me.ChkKharidAmani.Text = "فاکتور خرید امانی"
        Me.ChkKharidAmani.UseVisualStyleBackColor = True
        '
        'ChkService
        '
        Me.ChkService.AutoSize = True
        Me.ChkService.Checked = True
        Me.ChkService.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkService.Location = New System.Drawing.Point(339, 114)
        Me.ChkService.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkService.Name = "ChkService"
        Me.ChkService.Size = New System.Drawing.Size(98, 25)
        Me.ChkService.TabIndex = 12
        Me.ChkService.Text = "فاکتور خدمات"
        Me.ChkService.UseVisualStyleBackColor = True
        '
        'ChkCharge
        '
        Me.ChkCharge.AutoSize = True
        Me.ChkCharge.Checked = True
        Me.ChkCharge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCharge.Location = New System.Drawing.Point(93, 86)
        Me.ChkCharge.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkCharge.Name = "ChkCharge"
        Me.ChkCharge.Size = New System.Drawing.Size(56, 25)
        Me.ChkCharge.TabIndex = 18
        Me.ChkCharge.Text = "هزينه"
        Me.ChkCharge.UseVisualStyleBackColor = True
        '
        'ChkPay
        '
        Me.ChkPay.AutoSize = True
        Me.ChkPay.Checked = True
        Me.ChkPay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPay.Location = New System.Drawing.Point(5, 55)
        Me.ChkPay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkPay.Name = "ChkPay"
        Me.ChkPay.Size = New System.Drawing.Size(144, 25)
        Me.ChkPay.TabIndex = 17
        Me.ChkPay.Text = "پرداخت به طرف حساب"
        Me.ChkPay.UseVisualStyleBackColor = True
        '
        'ChkGet
        '
        Me.ChkGet.AutoSize = True
        Me.ChkGet.Checked = True
        Me.ChkGet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkGet.Location = New System.Drawing.Point(7, 24)
        Me.ChkGet.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkGet.Name = "ChkGet"
        Me.ChkGet.Size = New System.Drawing.Size(142, 25)
        Me.ChkGet.TabIndex = 16
        Me.ChkGet.Text = "دريافت از طرف حساب"
        Me.ChkGet.UseVisualStyleBackColor = True
        '
        'ChkBackFrosh
        '
        Me.ChkBackFrosh.AutoSize = True
        Me.ChkBackFrosh.Checked = True
        Me.ChkBackFrosh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBackFrosh.Location = New System.Drawing.Point(153, 86)
        Me.ChkBackFrosh.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkBackFrosh.Name = "ChkBackFrosh"
        Me.ChkBackFrosh.Size = New System.Drawing.Size(145, 25)
        Me.ChkBackFrosh.TabIndex = 15
        Me.ChkBackFrosh.Text = "فاکتور برگشت از فروش"
        Me.ChkBackFrosh.UseVisualStyleBackColor = True
        '
        'ChkFrosh
        '
        Me.ChkFrosh.AutoSize = True
        Me.ChkFrosh.Checked = True
        Me.ChkFrosh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFrosh.Location = New System.Drawing.Point(205, 24)
        Me.ChkFrosh.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkFrosh.Name = "ChkFrosh"
        Me.ChkFrosh.Size = New System.Drawing.Size(93, 25)
        Me.ChkFrosh.TabIndex = 13
        Me.ChkFrosh.Text = "فاکتور فروش"
        Me.ChkFrosh.UseVisualStyleBackColor = True
        '
        'ChkBackKharid
        '
        Me.ChkBackKharid.AutoSize = True
        Me.ChkBackKharid.Checked = True
        Me.ChkBackKharid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBackKharid.Location = New System.Drawing.Point(298, 86)
        Me.ChkBackKharid.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkBackKharid.Name = "ChkBackKharid"
        Me.ChkBackKharid.Size = New System.Drawing.Size(139, 25)
        Me.ChkBackKharid.TabIndex = 11
        Me.ChkBackKharid.Text = "فاکتور برگشت از خريد"
        Me.ChkBackKharid.UseVisualStyleBackColor = True
        '
        'ChkKharid
        '
        Me.ChkKharid.AutoSize = True
        Me.ChkKharid.Checked = True
        Me.ChkKharid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkKharid.Location = New System.Drawing.Point(350, 24)
        Me.ChkKharid.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkKharid.Name = "ChkKharid"
        Me.ChkKharid.Size = New System.Drawing.Size(87, 25)
        Me.ChkKharid.TabIndex = 9
        Me.ChkKharid.Text = "فاکتور خريد"
        Me.ChkKharid.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(340, 353)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 30)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "تهيه گزارش"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTime)
        Me.GroupBox1.Controls.Add(Me.ChkTaDate)
        Me.GroupBox1.Controls.Add(Me.ChkAzDate)
        Me.GroupBox1.Controls.Add(Me.FarsiDate1)
        Me.GroupBox1.Controls.Add(Me.FarsiDate2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(442, 67)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(321, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(109, 25)
        Me.ChkTime.TabIndex = 0
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(156, 31)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 3
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(352, 29)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 1
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(234, 27)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(116, 29)
        Me.FarsiDate1.TabIndex = 2
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(24, 27)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(125, 29)
        Me.FarsiDate2.TabIndex = 4
        Me.FarsiDate2.ThisText = Nothing
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 386)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(454, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 118
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
        'ChkGroup
        '
        Me.ChkGroup.AutoSize = True
        Me.ChkGroup.Checked = True
        Me.ChkGroup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkGroup.Location = New System.Drawing.Point(248, 320)
        Me.ChkGroup.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkGroup.Name = "ChkGroup"
        Me.ChkGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkGroup.Size = New System.Drawing.Size(196, 25)
        Me.ChkGroup.TabIndex = 22
        Me.ChkGroup.Text = "گزارش بر حسب سرفصل تهیه شود"
        Me.ChkGroup.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RdoSelect)
        Me.GroupBox3.Controls.Add(Me.RdoFrosh)
        Me.GroupBox3.Controls.Add(Me.RdoBuy)
        Me.GroupBox3.Controls.Add(Me.RdoAll)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(442, 67)
        Me.GroupBox3.TabIndex = 118
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "نوع گزارش"
        '
        'RdoSelect
        '
        Me.RdoSelect.AutoSize = True
        Me.RdoSelect.Location = New System.Drawing.Point(24, 27)
        Me.RdoSelect.Name = "RdoSelect"
        Me.RdoSelect.Size = New System.Drawing.Size(61, 25)
        Me.RdoSelect.TabIndex = 8
        Me.RdoSelect.Text = "انتخابی"
        Me.RdoSelect.UseVisualStyleBackColor = True
        '
        'RdoFrosh
        '
        Me.RdoFrosh.AutoSize = True
        Me.RdoFrosh.Location = New System.Drawing.Point(156, 27)
        Me.RdoFrosh.Name = "RdoFrosh"
        Me.RdoFrosh.Size = New System.Drawing.Size(59, 25)
        Me.RdoFrosh.TabIndex = 7
        Me.RdoFrosh.Text = "فروش"
        Me.RdoFrosh.UseVisualStyleBackColor = True
        '
        'RdoBuy
        '
        Me.RdoBuy.AutoSize = True
        Me.RdoBuy.Location = New System.Drawing.Point(270, 27)
        Me.RdoBuy.Name = "RdoBuy"
        Me.RdoBuy.Size = New System.Drawing.Size(53, 25)
        Me.RdoBuy.TabIndex = 6
        Me.RdoBuy.Text = "خرید"
        Me.RdoBuy.UseVisualStyleBackColor = True
        '
        'RdoAll
        '
        Me.RdoAll.AutoSize = True
        Me.RdoAll.Checked = True
        Me.RdoAll.Location = New System.Drawing.Point(383, 27)
        Me.RdoAll.Name = "RdoAll"
        Me.RdoAll.Size = New System.Drawing.Size(47, 25)
        Me.RdoAll.TabIndex = 5
        Me.RdoAll.TabStop = True
        Me.RdoAll.Text = "همه"
        Me.RdoAll.UseVisualStyleBackColor = True
        '
        'ChkZ
        '
        Me.ChkZ.AutoSize = True
        Me.ChkZ.Checked = True
        Me.ChkZ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkZ.Location = New System.Drawing.Point(302, 298)
        Me.ChkZ.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkZ.Name = "ChkZ"
        Me.ChkZ.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkZ.Size = New System.Drawing.Size(142, 25)
        Me.ChkZ.TabIndex = 21
        Me.ChkZ.Text = "عدم نمایش مقادیر صفر"
        Me.ChkZ.UseVisualStyleBackColor = True
        '
        'ChkAddDec
        '
        Me.ChkAddDec.AutoSize = True
        Me.ChkAddDec.Location = New System.Drawing.Point(32, 298)
        Me.ChkAddDec.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkAddDec.Name = "ChkAddDec"
        Me.ChkAddDec.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAddDec.Size = New System.Drawing.Size(185, 25)
        Me.ChkAddDec.TabIndex = 119
        Me.ChkAddDec.Text = "اضافات و کسورات محاسبه گردد"
        Me.ChkAddDec.UseVisualStyleBackColor = True
        '
        'ChkOnly
        '
        Me.ChkOnly.AutoSize = True
        Me.ChkOnly.Enabled = False
        Me.ChkOnly.Location = New System.Drawing.Point(9, 320)
        Me.ChkOnly.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkOnly.Name = "ChkOnly"
        Me.ChkOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkOnly.Size = New System.Drawing.Size(208, 25)
        Me.ChkOnly.TabIndex = 120
        Me.ChkOnly.Text = "فقط اضافات و کسورات محاسبه گردد"
        Me.ChkOnly.UseVisualStyleBackColor = True
        '
        'FrmDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 415)
        Me.Controls.Add(Me.ChkOnly)
        Me.Controls.Add(Me.ChkAddDec)
        Me.Controls.Add(Me.ChkZ)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ChkGroup)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDiscount"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش تخفیفات"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkBackFrosh As System.Windows.Forms.CheckBox
    Friend WithEvents ChkFrosh As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBackKharid As System.Windows.Forms.CheckBox
    Friend WithEvents ChkKharid As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCharge As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPay As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGet As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ChkService As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ChkFroshAmani As System.Windows.Forms.CheckBox
    Friend WithEvents ChkKharidAmani As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoSelect As System.Windows.Forms.RadioButton
    Friend WithEvents RdoFrosh As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBuy As System.Windows.Forms.RadioButton
    Friend WithEvents RdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents ChkZ As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAddDec As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOnly As System.Windows.Forms.CheckBox
End Class
