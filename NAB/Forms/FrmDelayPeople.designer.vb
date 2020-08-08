<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDelayPeople
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
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Num = New System.Windows.Forms.NumericUpDown
        Me.ChkFroshChk = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ChkTafkik = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTaDate = New System.Windows.Forms.CheckBox
        Me.ChkAzDate = New System.Windows.Forms.CheckBox
        Me.FarsiDate1 = New FarsiDate.FarsiDate
        Me.FarsiDate2 = New FarsiDate.FarsiDate
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RdoP = New System.Windows.Forms.RadioButton
        Me.RdoC = New System.Windows.Forms.RadioButton
        Me.RdoM = New System.Windows.Forms.RadioButton
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Num, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.GroupBox5.Location = New System.Drawing.Point(341, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(356, 434)
        Me.GroupBox5.TabIndex = 77
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "لیست طرف حساب"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(121, 398)
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
        Me.ChkAllp.Location = New System.Drawing.Point(8, 402)
        Me.ChkAllp.Name = "ChkAllp"
        Me.ChkAllp.Size = New System.Drawing.Size(84, 25)
        Me.ChkAllp.TabIndex = 52
        Me.ChkAllp.Text = "انتخاب همه"
        Me.ChkAllp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(238, 398)
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
        Me.DGV2.Location = New System.Drawing.Point(6, 23)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(344, 370)
        Me.DGV2.TabIndex = 4
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
        Me.Cln_NamP.Width = 251
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(703, 29)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(59, 24)
        Me.ToolStripStatusLabel2.Text = "F3 جستجو"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(92, 24)
        Me.ToolStripStatusLabel4.Text = "F4 انتخاب پیشرفته"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(223, 401)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(111, 30)
        Me.BtnOk.TabIndex = 81
        Me.BtnOk.Text = "تهیه گزارش"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'Num
        '
        Me.Num.BackColor = System.Drawing.SystemColors.Window
        Me.Num.Enabled = False
        Me.Num.Location = New System.Drawing.Point(11, 160)
        Me.Num.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Num.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Num.Name = "Num"
        Me.Num.ReadOnly = True
        Me.Num.Size = New System.Drawing.Size(50, 29)
        Me.Num.TabIndex = 101
        Me.Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Num.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ChkFroshChk
        '
        Me.ChkFroshChk.AutoSize = True
        Me.ChkFroshChk.Checked = True
        Me.ChkFroshChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFroshChk.Location = New System.Drawing.Point(127, 164)
        Me.ChkFroshChk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkFroshChk.Name = "ChkFroshChk"
        Me.ChkFroshChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkFroshChk.Size = New System.Drawing.Size(206, 25)
        Me.ChkFroshChk.TabIndex = 100
        Me.ChkFroshChk.Text = "تاخیر چکهای خرج شده محاسبه گردد."
        Me.ChkFroshChk.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(64, 165)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 21)
        Me.Label11.TabIndex = 102
        Me.Label11.Text = "حداقل تاخیر"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkTafkik
        '
        Me.ChkTafkik.AutoSize = True
        Me.ChkTafkik.Checked = True
        Me.ChkTafkik.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTafkik.Location = New System.Drawing.Point(79, 195)
        Me.ChkTafkik.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkTafkik.Name = "ChkTafkik"
        Me.ChkTafkik.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkTafkik.Size = New System.Drawing.Size(254, 25)
        Me.ChkTafkik.TabIndex = 103
        Me.ChkTafkik.Text = "تفکیک تاخیر مشتریان بر اساس هر طرف حساب"
        Me.ChkTafkik.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTime)
        Me.GroupBox1.Controls.Add(Me.ChkTaDate)
        Me.GroupBox1.Controls.Add(Me.ChkAzDate)
        Me.GroupBox1.Controls.Add(Me.FarsiDate1)
        Me.GroupBox1.Controls.Add(Me.FarsiDate2)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(323, 67)
        Me.GroupBox1.TabIndex = 118
        Me.GroupBox1.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(209, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(109, 25)
        Me.ChkTime.TabIndex = 18
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTaDate
        '
        Me.ChkTaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTaDate.AutoSize = True
        Me.ChkTaDate.Location = New System.Drawing.Point(123, 29)
        Me.ChkTaDate.Name = "ChkTaDate"
        Me.ChkTaDate.Size = New System.Drawing.Size(36, 25)
        Me.ChkTaDate.TabIndex = 21
        Me.ChkTaDate.Text = "تا"
        Me.ChkTaDate.UseVisualStyleBackColor = True
        '
        'ChkAzDate
        '
        Me.ChkAzDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAzDate.AutoSize = True
        Me.ChkAzDate.Location = New System.Drawing.Point(281, 29)
        Me.ChkAzDate.Name = "ChkAzDate"
        Me.ChkAzDate.Size = New System.Drawing.Size(37, 25)
        Me.ChkAzDate.TabIndex = 19
        Me.ChkAzDate.Text = "از"
        Me.ChkAzDate.UseVisualStyleBackColor = True
        '
        'FarsiDate1
        '
        Me.FarsiDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate1.Location = New System.Drawing.Point(163, 27)
        Me.FarsiDate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate1.Name = "FarsiDate1"
        Me.FarsiDate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate1.Size = New System.Drawing.Size(110, 29)
        Me.FarsiDate1.TabIndex = 20
        Me.FarsiDate1.ThisText = Nothing
        '
        'FarsiDate2
        '
        Me.FarsiDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FarsiDate2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDate2.Location = New System.Drawing.Point(9, 27)
        Me.FarsiDate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDate2.Name = "FarsiDate2"
        Me.FarsiDate2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDate2.Size = New System.Drawing.Size(110, 29)
        Me.FarsiDate2.TabIndex = 22
        Me.FarsiDate2.ThisText = Nothing
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdoM)
        Me.GroupBox2.Controls.Add(Me.RdoC)
        Me.GroupBox2.Controls.Add(Me.RdoP)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(323, 74)
        Me.GroupBox2.TabIndex = 119
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "مرتب سازی بر اساس"
        '
        'RdoP
        '
        Me.RdoP.AutoSize = True
        Me.RdoP.Checked = True
        Me.RdoP.Location = New System.Drawing.Point(228, 28)
        Me.RdoP.Name = "RdoP"
        Me.RdoP.Size = New System.Drawing.Size(89, 25)
        Me.RdoP.TabIndex = 120
        Me.RdoP.TabStop = True
        Me.RdoP.Text = "طرف حساب"
        Me.RdoP.UseVisualStyleBackColor = True
        '
        'RdoC
        '
        Me.RdoC.AutoSize = True
        Me.RdoC.Location = New System.Drawing.Point(123, 28)
        Me.RdoC.Name = "RdoC"
        Me.RdoC.Size = New System.Drawing.Size(81, 25)
        Me.RdoC.TabIndex = 121
        Me.RdoC.Text = "تعداد تاخیر"
        Me.RdoC.UseVisualStyleBackColor = True
        '
        'RdoM
        '
        Me.RdoM.AutoSize = True
        Me.RdoM.Location = New System.Drawing.Point(9, 28)
        Me.RdoM.Name = "RdoM"
        Me.RdoM.Size = New System.Drawing.Size(81, 25)
        Me.RdoM.TabIndex = 122
        Me.RdoM.Text = "مدت تاخیر"
        Me.RdoM.UseVisualStyleBackColor = True
        '
        'FrmDelayPeople
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 469)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkTafkik)
        Me.Controls.Add(Me.Num)
        Me.Controls.Add(Me.ChkFroshChk)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmDelayPeople"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش تاخیر مشتریان"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Num, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ChkAllp As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Cln_NamP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_SelectP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_ActiveP As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Num As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkFroshChk As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ChkTafkik As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkTaDate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAzDate As System.Windows.Forms.CheckBox
    Friend WithEvents FarsiDate1 As FarsiDate.FarsiDate
    Friend WithEvents FarsiDate2 As FarsiDate.FarsiDate
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoM As System.Windows.Forms.RadioButton
    Friend WithEvents RdoC As System.Windows.Forms.RadioButton
    Friend WithEvents RdoP As System.Windows.Forms.RadioButton
End Class
