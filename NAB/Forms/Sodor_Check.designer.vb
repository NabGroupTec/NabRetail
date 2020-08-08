<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sodor_Check
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
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtallmoneyPay = New System.Windows.Forms.TextBox
        Me.BtnDelPay = New System.Windows.Forms.Button
        Me.BtnEditPay = New System.Windows.Forms.Button
        Me.BtnNewPay = New System.Windows.Forms.Button
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel13 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel14 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel15 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel16 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel18 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LADD = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LIdname = New System.Windows.Forms.Label
        Me.LName = New System.Windows.Forms.Label
        Me.LFac = New System.Windows.Forms.Label
        Me.LState = New System.Windows.Forms.Label
        Me.TxtRasChk = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cln_ID1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdBook1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_PayDate1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_MoneyChk1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NumChk1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_People1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Bank1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Shobeh1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Number1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_GetDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_ID1, Me.Cln_IdBook1, Me.Cln_PayDate1, Me.Cln_MoneyChk1, Me.Cln_NumChk1, Me.Cln_People1, Me.Cln_Bank1, Me.Cln_Shobeh1, Me.Cln_Number1, Me.Cln_GetDate})
        Me.DGV2.Location = New System.Drawing.Point(6, 21)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(802, 384)
        Me.DGV2.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(240, 423)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 21)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "جمع‌كل‌مبلغ"
        '
        'TxtallmoneyPay
        '
        Me.TxtallmoneyPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtallmoneyPay.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtallmoneyPay.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtallmoneyPay.Location = New System.Drawing.Point(16, 421)
        Me.TxtallmoneyPay.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtallmoneyPay.Name = "TxtallmoneyPay"
        Me.TxtallmoneyPay.ReadOnly = True
        Me.TxtallmoneyPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtallmoneyPay.Size = New System.Drawing.Size(218, 29)
        Me.TxtallmoneyPay.TabIndex = 50
        Me.TxtallmoneyPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnDelPay
        '
        Me.BtnDelPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelPay.Location = New System.Drawing.Point(636, 418)
        Me.BtnDelPay.Name = "BtnDelPay"
        Me.BtnDelPay.Size = New System.Drawing.Size(88, 30)
        Me.BtnDelPay.TabIndex = 49
        Me.BtnDelPay.Text = "حذف"
        Me.BtnDelPay.UseVisualStyleBackColor = True
        '
        'BtnEditPay
        '
        Me.BtnEditPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditPay.Location = New System.Drawing.Point(542, 418)
        Me.BtnEditPay.Name = "BtnEditPay"
        Me.BtnEditPay.Size = New System.Drawing.Size(88, 30)
        Me.BtnEditPay.TabIndex = 47
        Me.BtnEditPay.Text = "ویرایش"
        Me.BtnEditPay.UseVisualStyleBackColor = True
        '
        'BtnNewPay
        '
        Me.BtnNewPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNewPay.Location = New System.Drawing.Point(730, 418)
        Me.BtnNewPay.Name = "BtnNewPay"
        Me.BtnNewPay.Size = New System.Drawing.Size(88, 30)
        Me.BtnNewPay.TabIndex = 46
        Me.BtnNewPay.Text = "جدید"
        Me.BtnNewPay.UseVisualStyleBackColor = True
        '
        'StatusStrip3
        '
        Me.StatusStrip3.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel13, Me.ToolStripStatusLabel14, Me.ToolStripStatusLabel15, Me.ToolStripStatusLabel16, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel18})
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 451)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip3.Size = New System.Drawing.Size(839, 29)
        Me.StatusStrip3.SizingGrip = False
        Me.StatusStrip3.TabIndex = 53
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
        Me.ToolStripStatusLabel14.Size = New System.Drawing.Size(52, 24)
        Me.ToolStripStatusLabel14.Text = "F2 جدید"
        '
        'ToolStripStatusLabel15
        '
        Me.ToolStripStatusLabel15.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel15.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15"
        Me.ToolStripStatusLabel15.Size = New System.Drawing.Size(52, 24)
        Me.ToolStripStatusLabel15.Text = "F3 حذف"
        '
        'ToolStripStatusLabel16
        '
        Me.ToolStripStatusLabel16.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel16.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel16.Name = "ToolStripStatusLabel16"
        Me.ToolStripStatusLabel16.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel16.Text = "F4 ویرایش"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel1.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel18
        '
        Me.ToolStripStatusLabel18.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel18.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel18.Name = "ToolStripStatusLabel18"
        Me.ToolStripStatusLabel18.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel18.Text = "ESC خروج"
        '
        'LADD
        '
        Me.LADD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LADD.AutoSize = True
        Me.LADD.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LADD.Location = New System.Drawing.Point(332, 353)
        Me.LADD.Name = "LADD"
        Me.LADD.Size = New System.Drawing.Size(0, 21)
        Me.LADD.TabIndex = 55
        Me.LADD.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DGV2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(817, 411)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        '
        'LIdname
        '
        Me.LIdname.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LIdname.AutoSize = True
        Me.LIdname.Location = New System.Drawing.Point(240, 423)
        Me.LIdname.Name = "LIdname"
        Me.LIdname.Size = New System.Drawing.Size(0, 21)
        Me.LIdname.TabIndex = 78
        Me.LIdname.Visible = False
        '
        'LName
        '
        Me.LName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LName.AutoSize = True
        Me.LName.Location = New System.Drawing.Point(228, 418)
        Me.LName.Name = "LName"
        Me.LName.Size = New System.Drawing.Size(0, 21)
        Me.LName.TabIndex = 77
        Me.LName.Visible = False
        '
        'LFac
        '
        Me.LFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LFac.AutoSize = True
        Me.LFac.Location = New System.Drawing.Point(264, 415)
        Me.LFac.Name = "LFac"
        Me.LFac.Size = New System.Drawing.Size(0, 21)
        Me.LFac.TabIndex = 79
        Me.LFac.Visible = False
        '
        'LState
        '
        Me.LState.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LState.AutoSize = True
        Me.LState.Location = New System.Drawing.Point(351, 415)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 80
        Me.LState.Visible = False
        '
        'TxtRasChk
        '
        Me.TxtRasChk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtRasChk.BackColor = System.Drawing.SystemColors.Control
        Me.TxtRasChk.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtRasChk.Location = New System.Drawing.Point(309, 421)
        Me.TxtRasChk.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtRasChk.MaxLength = 16
        Me.TxtRasChk.Name = "TxtRasChk"
        Me.TxtRasChk.ReadOnly = True
        Me.TxtRasChk.ShortcutsEnabled = False
        Me.TxtRasChk.Size = New System.Drawing.Size(74, 29)
        Me.TxtRasChk.TabIndex = 96
        Me.TxtRasChk.Text = "0"
        Me.TxtRasChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(389, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 21)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "راس گیری"
        '
        'Cln_ID1
        '
        Me.Cln_ID1.DataPropertyName = "ID"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_ID1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_ID1.HeaderText = "سند"
        Me.Cln_ID1.Name = "Cln_ID1"
        Me.Cln_ID1.ReadOnly = True
        Me.Cln_ID1.Width = 50
        '
        'Cln_IdBook1
        '
        Me.Cln_IdBook1.DataPropertyName = "Number_Note"
        Me.Cln_IdBook1.HeaderText = "سند دفتری"
        Me.Cln_IdBook1.Name = "Cln_IdBook1"
        Me.Cln_IdBook1.ReadOnly = True
        Me.Cln_IdBook1.Width = 95
        '
        'Cln_PayDate1
        '
        Me.Cln_PayDate1.DataPropertyName = "PayDate"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_PayDate1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_PayDate1.HeaderText = "سر رسید"
        Me.Cln_PayDate1.Name = "Cln_PayDate1"
        Me.Cln_PayDate1.ReadOnly = True
        Me.Cln_PayDate1.Width = 90
        '
        'Cln_MoneyChk1
        '
        Me.Cln_MoneyChk1.DataPropertyName = "MoneyChk"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Cln_MoneyChk1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_MoneyChk1.HeaderText = "مبلغ چک"
        Me.Cln_MoneyChk1.Name = "Cln_MoneyChk1"
        Me.Cln_MoneyChk1.ReadOnly = True
        Me.Cln_MoneyChk1.Width = 80
        '
        'Cln_NumChk1
        '
        Me.Cln_NumChk1.DataPropertyName = "NumChk"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_NumChk1.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_NumChk1.HeaderText = "سریال"
        Me.Cln_NumChk1.Name = "Cln_NumChk1"
        Me.Cln_NumChk1.ReadOnly = True
        Me.Cln_NumChk1.Width = 80
        '
        'Cln_People1
        '
        Me.Cln_People1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_People1.DataPropertyName = "Nam"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_People1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_People1.HeaderText = "طرف حساب"
        Me.Cln_People1.Name = "Cln_People1"
        Me.Cln_People1.ReadOnly = True
        Me.Cln_People1.Width = 114
        '
        'Cln_Bank1
        '
        Me.Cln_Bank1.DataPropertyName = "N_Bank"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Bank1.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_Bank1.HeaderText = "بانک"
        Me.Cln_Bank1.Name = "Cln_Bank1"
        Me.Cln_Bank1.ReadOnly = True
        Me.Cln_Bank1.Width = 80
        '
        'Cln_Shobeh1
        '
        Me.Cln_Shobeh1.DataPropertyName = "Shobeh"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Shobeh1.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_Shobeh1.HeaderText = "شعبه"
        Me.Cln_Shobeh1.Name = "Cln_Shobeh1"
        Me.Cln_Shobeh1.ReadOnly = True
        Me.Cln_Shobeh1.Width = 70
        '
        'Cln_Number1
        '
        Me.Cln_Number1.DataPropertyName = "Number_N"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Number1.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Number1.HeaderText = "شماره حساب"
        Me.Cln_Number1.Name = "Cln_Number1"
        Me.Cln_Number1.ReadOnly = True
        '
        'Cln_GetDate
        '
        Me.Cln_GetDate.DataPropertyName = "GetDate"
        Me.Cln_GetDate.HeaderText = "تاریخ صدور"
        Me.Cln_GetDate.Name = "Cln_GetDate"
        Me.Cln_GetDate.ReadOnly = True
        Me.Cln_GetDate.Visible = False
        '
        'Sodor_Check
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 480)
        Me.Controls.Add(Me.TxtRasChk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.TxtallmoneyPay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LFac)
        Me.Controls.Add(Me.LIdname)
        Me.Controls.Add(Me.BtnDelPay)
        Me.Controls.Add(Me.LName)
        Me.Controls.Add(Me.BtnEditPay)
        Me.Controls.Add(Me.LADD)
        Me.Controls.Add(Me.BtnNewPay)
        Me.Controls.Add(Me.StatusStrip3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "Sodor_Check"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "صدور چک پرداختی"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtallmoneyPay As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelPay As System.Windows.Forms.Button
    Friend WithEvents BtnEditPay As System.Windows.Forms.Button
    Friend WithEvents BtnNewPay As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel13 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel14 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel15 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel16 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel18 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LADD As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LIdname As System.Windows.Forms.Label
    Friend WithEvents LName As System.Windows.Forms.Label
    Friend WithEvents LFac As System.Windows.Forms.Label
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents TxtRasChk As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cln_ID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdBook1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_PayDate1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_MoneyChk1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NumChk1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_People1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Bank1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Shobeh1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Number1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_GetDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
