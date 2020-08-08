<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBankTBank
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txtchkmon = New System.Windows.Forms.TextBox
        Me.TxtNumChk = New System.Windows.Forms.TextBox
        Me.Chk = New System.Windows.Forms.CheckBox
        Me.TxtBank = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPayDate = New FarsiDate.FarsiDate
        Me.TxtDiscBank = New System.Windows.Forms.TextBox
        Me.TxtIdbank = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtAllMoney = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Cln_Bank = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_MonBank = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_BankId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel13 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel14 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel15 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel18 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Btnadd = New System.Windows.Forms.Button
        Me.LEdit = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LSanad = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txtchkmon)
        Me.GroupBox1.Controls.Add(Me.TxtNumChk)
        Me.GroupBox1.Controls.Add(Me.Chk)
        Me.GroupBox1.Controls.Add(Me.TxtBank)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPayDate)
        Me.GroupBox1.Controls.Add(Me.TxtDiscBank)
        Me.GroupBox1.Controls.Add(Me.TxtIdbank)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(417, 138)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بانک بستانکار"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(126, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 21)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "مبلغ انتقال"
        '
        'Txtchkmon
        '
        Me.Txtchkmon.Location = New System.Drawing.Point(7, 32)
        Me.Txtchkmon.MaxLength = 20
        Me.Txtchkmon.Name = "Txtchkmon"
        Me.Txtchkmon.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtchkmon.ShortcutsEnabled = False
        Me.Txtchkmon.Size = New System.Drawing.Size(109, 29)
        Me.Txtchkmon.TabIndex = 2
        Me.Txtchkmon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNumChk
        '
        Me.TxtNumChk.Location = New System.Drawing.Point(202, 62)
        Me.TxtNumChk.MaxLength = 15
        Me.TxtNumChk.Name = "TxtNumChk"
        Me.TxtNumChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNumChk.ShortcutsEnabled = False
        Me.TxtNumChk.Size = New System.Drawing.Size(142, 29)
        Me.TxtNumChk.TabIndex = 4
        Me.TxtNumChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chk
        '
        Me.Chk.AutoSize = True
        Me.Chk.Location = New System.Drawing.Point(355, 61)
        Me.Chk.Name = "Chk"
        Me.Chk.Size = New System.Drawing.Size(48, 25)
        Me.Chk.TabIndex = 3
        Me.Chk.Text = "چک"
        Me.Chk.UseVisualStyleBackColor = True
        '
        'TxtBank
        '
        Me.TxtBank.Location = New System.Drawing.Point(202, 32)
        Me.TxtBank.MaxLength = 100
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBank.ShortcutsEnabled = False
        Me.TxtBank.Size = New System.Drawing.Size(142, 29)
        Me.TxtBank.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(357, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 21)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "نام بانک"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(347, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 21)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "توضیحات"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(123, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 21)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "تاریخ"
        '
        'TxtPayDate
        '
        Me.TxtPayDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPayDate.Location = New System.Drawing.Point(7, 61)
        Me.TxtPayDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPayDate.Name = "TxtPayDate"
        Me.TxtPayDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPayDate.Size = New System.Drawing.Size(109, 29)
        Me.TxtPayDate.TabIndex = 5
        Me.TxtPayDate.ThisText = Nothing
        '
        'TxtDiscBank
        '
        Me.TxtDiscBank.BackColor = System.Drawing.Color.White
        Me.TxtDiscBank.Location = New System.Drawing.Point(7, 92)
        Me.TxtDiscBank.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDiscBank.MaxLength = 200
        Me.TxtDiscBank.Name = "TxtDiscBank"
        Me.TxtDiscBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscBank.Size = New System.Drawing.Size(337, 29)
        Me.TxtDiscBank.TabIndex = 6
        '
        'TxtIdbank
        '
        Me.TxtIdbank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdbank.Location = New System.Drawing.Point(277, 32)
        Me.TxtIdbank.Name = "TxtIdbank"
        Me.TxtIdbank.ReadOnly = True
        Me.TxtIdbank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdbank.ShortcutsEnabled = False
        Me.TxtIdbank.Size = New System.Drawing.Size(52, 29)
        Me.TxtIdbank.TabIndex = 71
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtAllMoney)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DGV1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 145)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(417, 270)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بانک بدهکار"
        '
        'TxtAllMoney
        '
        Me.TxtAllMoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtAllMoney.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtAllMoney.Location = New System.Drawing.Point(7, 233)
        Me.TxtAllMoney.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtAllMoney.Name = "TxtAllMoney"
        Me.TxtAllMoney.ReadOnly = True
        Me.TxtAllMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAllMoney.Size = New System.Drawing.Size(182, 29)
        Me.TxtAllMoney.TabIndex = 10
        Me.TxtAllMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 235)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 21)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "جمع مبلغ"
        '
        'DGV1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Bank, Me.Cln_MonBank, Me.Cln_BankId, Me.Cln_Disc})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGV1.Location = New System.Drawing.Point(7, 28)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV1.Size = New System.Drawing.Size(396, 197)
        Me.DGV1.TabIndex = 7
        '
        'Cln_Bank
        '
        Me.Cln_Bank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Bank.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Bank.HeaderText = "بانک"
        Me.Cln_Bank.Name = "Cln_Bank"
        Me.Cln_Bank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Bank.Width = 133
        '
        'Cln_MonBank
        '
        Me.Cln_MonBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_MonBank.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_MonBank.HeaderText = "واریزی به بانک"
        Me.Cln_MonBank.Name = "Cln_MonBank"
        Me.Cln_MonBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_MonBank.Width = 120
        '
        'Cln_BankId
        '
        Me.Cln_BankId.HeaderText = "کد بانک"
        Me.Cln_BankId.Name = "Cln_BankId"
        Me.Cln_BankId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_BankId.Visible = False
        '
        'Cln_Disc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Disc.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.MaxInputLength = 200
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'StatusStrip3
        '
        Me.StatusStrip3.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel13, Me.ToolStripStatusLabel14, Me.ToolStripStatusLabel15, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel18})
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip3.Size = New System.Drawing.Size(434, 29)
        Me.StatusStrip3.SizingGrip = False
        Me.StatusStrip3.TabIndex = 97
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
        Me.ToolStripStatusLabel14.Size = New System.Drawing.Size(45, 24)
        Me.ToolStripStatusLabel14.Text = "F2 ثبت"
        '
        'ToolStripStatusLabel15
        '
        Me.ToolStripStatusLabel15.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel15.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15"
        Me.ToolStripStatusLabel15.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel15.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(140, 24)
        Me.ToolStripStatusLabel1.Text = "SpaceBar محاسبه باقیمانده"
        '
        'ToolStripStatusLabel18
        '
        Me.ToolStripStatusLabel18.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel18.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel18.Name = "ToolStripStatusLabel18"
        Me.ToolStripStatusLabel18.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel18.Text = "ESC خروج"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(245, 423)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "انصراف"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btnadd
        '
        Me.Btnadd.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btnadd.Location = New System.Drawing.Point(341, 423)
        Me.Btnadd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(88, 30)
        Me.Btnadd.TabIndex = 8
        Me.Btnadd.Text = "ثبت"
        Me.Btnadd.UseVisualStyleBackColor = True
        '
        'LEdit
        '
        Me.LEdit.AutoSize = True
        Me.LEdit.Location = New System.Drawing.Point(19, 396)
        Me.LEdit.Name = "LEdit"
        Me.LEdit.Size = New System.Drawing.Size(0, 21)
        Me.LEdit.TabIndex = 74
        Me.LEdit.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(207, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 21)
        Me.Label6.TabIndex = 98
        Me.Label6.Visible = False
        '
        'LSanad
        '
        Me.LSanad.AutoSize = True
        Me.LSanad.Location = New System.Drawing.Point(150, 391)
        Me.LSanad.Name = "LSanad"
        Me.LSanad.Size = New System.Drawing.Size(0, 21)
        Me.LSanad.TabIndex = 99
        Me.LSanad.Visible = False
        '
        'FrmBankTBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 491)
        Me.Controls.Add(Me.LSanad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LEdit)
        Me.Controls.Add(Me.StatusStrip3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btnadd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBankTBank"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بانک به بانک"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBank As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPayDate As FarsiDate.FarsiDate
    Friend WithEvents TxtIdbank As System.Windows.Forms.TextBox
    Friend WithEvents TxtDiscBank As System.Windows.Forms.TextBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAllMoney As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel13 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel14 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel15 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel18 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents TxtNumChk As System.Windows.Forms.TextBox
    Friend WithEvents Chk As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txtchkmon As System.Windows.Forms.TextBox
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LSanad As System.Windows.Forms.Label
    Friend WithEvents Cln_Bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_MonBank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_BankId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
