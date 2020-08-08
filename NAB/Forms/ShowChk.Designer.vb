<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowChk
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Cln_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdBook = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_payDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_MoneyChk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NumChk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_People = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_State = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txtallmoney = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolDisc = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnEditPay = New System.Windows.Forms.Button
        Me.Cln_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Day = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_CountChK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_MonChk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.DGV1)
        Me.GroupBox4.Controls.Add(Me.DGV2)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(861, 424)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "لیست چک"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_ID, Me.Cln_IdBook, Me.Cln_payDate, Me.Cln_MoneyChk, Me.Cln_NumChk, Me.Cln_People, Me.Cln_State, Me.Cln_Disc})
        Me.DGV1.Location = New System.Drawing.Point(6, 28)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.Size = New System.Drawing.Size(849, 390)
        Me.DGV1.TabIndex = 1
        '
        'Cln_ID
        '
        Me.Cln_ID.DataPropertyName = "id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_ID.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_ID.HeaderText = "سند"
        Me.Cln_ID.Name = "Cln_ID"
        Me.Cln_ID.ReadOnly = True
        Me.Cln_ID.Width = 50
        '
        'Cln_IdBook
        '
        Me.Cln_IdBook.DataPropertyName = "GetDate"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_IdBook.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_IdBook.HeaderText = "تاریخ دریافت"
        Me.Cln_IdBook.Name = "Cln_IdBook"
        Me.Cln_IdBook.ReadOnly = True
        '
        'Cln_payDate
        '
        Me.Cln_payDate.DataPropertyName = "paydate"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_payDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_payDate.HeaderText = "سر رسید"
        Me.Cln_payDate.Name = "Cln_payDate"
        Me.Cln_payDate.ReadOnly = True
        Me.Cln_payDate.Width = 90
        '
        'Cln_MoneyChk
        '
        Me.Cln_MoneyChk.DataPropertyName = "moneychk"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Cln_MoneyChk.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_MoneyChk.HeaderText = "مبلغ چک"
        Me.Cln_MoneyChk.Name = "Cln_MoneyChk"
        Me.Cln_MoneyChk.ReadOnly = True
        Me.Cln_MoneyChk.Width = 80
        '
        'Cln_NumChk
        '
        Me.Cln_NumChk.DataPropertyName = "numchk"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_NumChk.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_NumChk.HeaderText = "سریال"
        Me.Cln_NumChk.Name = "Cln_NumChk"
        Me.Cln_NumChk.ReadOnly = True
        Me.Cln_NumChk.Width = 80
        '
        'Cln_People
        '
        Me.Cln_People.DataPropertyName = "Nam"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_People.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_People.HeaderText = "طرف حساب"
        Me.Cln_People.Name = "Cln_People"
        Me.Cln_People.ReadOnly = True
        Me.Cln_People.Width = 150
        '
        'Cln_State
        '
        Me.Cln_State.DataPropertyName = "Stat"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_State.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_State.HeaderText = "وضعیت"
        Me.Cln_State.Name = "Cln_State"
        Me.Cln_State.ReadOnly = True
        '
        'Cln_Disc
        '
        Me.Cln_Disc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Disc.DataPropertyName = "Disc"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Disc.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.ReadOnly = True
        Me.Cln_Disc.Width = 156
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Date, Me.Cln_Day, Me.Cln_CountChK, Me.Cln_MonChk})
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.Size = New System.Drawing.Size(849, 390)
        Me.DGV2.TabIndex = 2
        Me.DGV2.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 439)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 21)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "جمع‌ چک"
        '
        'Txtallmoney
        '
        Me.Txtallmoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txtallmoney.BackColor = System.Drawing.Color.White
        Me.Txtallmoney.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtallmoney.Location = New System.Drawing.Point(18, 437)
        Me.Txtallmoney.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Txtallmoney.Name = "Txtallmoney"
        Me.Txtallmoney.ReadOnly = True
        Me.Txtallmoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtallmoney.Size = New System.Drawing.Size(208, 29)
        Me.Txtallmoney.TabIndex = 55
        Me.Txtallmoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolDisc, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 471)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(885, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 57
        '
        'ToolDisc
        '
        Me.ToolDisc.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolDisc.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolDisc.Name = "ToolDisc"
        Me.ToolDisc.Size = New System.Drawing.Size(183, 24)
        Me.ToolDisc.Text = "F2 محاسبه مبلغ بر اساس تاریخ سررسید"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'BtnEditPay
        '
        Me.BtnEditPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditPay.Location = New System.Drawing.Point(672, 436)
        Me.BtnEditPay.Name = "BtnEditPay"
        Me.BtnEditPay.Size = New System.Drawing.Size(201, 30)
        Me.BtnEditPay.TabIndex = 58
        Me.BtnEditPay.Text = "محاسبه مبلغ بر اساس تاریخ سررسید"
        Me.BtnEditPay.UseVisualStyleBackColor = True
        '
        'Cln_Date
        '
        Me.Cln_Date.DataPropertyName = "PayDate"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Date.DefaultCellStyle = DataGridViewCellStyle11
        Me.Cln_Date.HeaderText = "سر رسید"
        Me.Cln_Date.Name = "Cln_Date"
        Me.Cln_Date.ReadOnly = True
        Me.Cln_Date.Width = 150
        '
        'Cln_Day
        '
        Me.Cln_Day.DataPropertyName = "Day"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Day.DefaultCellStyle = DataGridViewCellStyle12
        Me.Cln_Day.HeaderText = "روز هفته"
        Me.Cln_Day.Name = "Cln_Day"
        Me.Cln_Day.ReadOnly = True
        '
        'Cln_CountChK
        '
        Me.Cln_CountChK.DataPropertyName = "C_Count"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = "0"
        Me.Cln_CountChK.DefaultCellStyle = DataGridViewCellStyle13
        Me.Cln_CountChK.HeaderText = "تعداد چک"
        Me.Cln_CountChK.Name = "Cln_CountChK"
        Me.Cln_CountChK.ReadOnly = True
        Me.Cln_CountChK.Width = 150
        '
        'Cln_MonChk
        '
        Me.Cln_MonChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_MonChk.DataPropertyName = "MoneyChk"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = "0"
        Me.Cln_MonChk.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_MonChk.HeaderText = "جمع مبلغ چک"
        Me.Cln_MonChk.Name = "Cln_MonChk"
        Me.Cln_MonChk.ReadOnly = True
        Me.Cln_MonChk.Width = 406
        '
        'ShowChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 500)
        Me.Controls.Add(Me.BtnEditPay)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txtallmoney)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "ShowChk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نمایش ریز چک"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txtallmoney As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolDisc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnEditPay As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Cln_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdBook As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_payDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_MoneyChk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NumChk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_People As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_State As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_CountChK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_MonChk As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
