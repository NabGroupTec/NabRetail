<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionFormulas
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDateStart = New System.Windows.Forms.TextBox()
        Me.txtFormulNo = New System.Windows.Forms.TextBox()
        Me.txtCountTavazon = New System.Windows.Forms.TextBox()
        Me.txtFormulName = New System.Windows.Forms.TextBox()
        Me.DGVFormulas = New System.Windows.Forms.DataGridView()
        Me.Cln_IdKala = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Sharh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Masraf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Tavlid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_IdVahed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_EndPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCountTavlid = New System.Windows.Forms.TextBox()
        Me.txtCountUnit = New System.Windows.Forms.TextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.DGVFormulas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(876, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "تاریخ معرفی :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "شماره فرمول:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(546, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "توازن تعداد :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(891, 322)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "نام فرمول :"
        '
        'txtDateStart
        '
        Me.txtDateStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateStart.Location = New System.Drawing.Point(670, 13)
        Me.txtDateStart.Name = "txtDateStart"
        Me.txtDateStart.Size = New System.Drawing.Size(200, 30)
        Me.txtDateStart.TabIndex = 1
        '
        'txtFormulNo
        '
        Me.txtFormulNo.Location = New System.Drawing.Point(13, 13)
        Me.txtFormulNo.Name = "txtFormulNo"
        Me.txtFormulNo.Size = New System.Drawing.Size(100, 30)
        Me.txtFormulNo.TabIndex = 5
        '
        'txtCountTavazon
        '
        Me.txtCountTavazon.Location = New System.Drawing.Point(443, 283)
        Me.txtCountTavazon.Name = "txtCountTavazon"
        Me.txtCountTavazon.Size = New System.Drawing.Size(100, 30)
        Me.txtCountTavazon.TabIndex = 6
        '
        'txtFormulName
        '
        Me.txtFormulName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFormulName.Location = New System.Drawing.Point(13, 319)
        Me.txtFormulName.Name = "txtFormulName"
        Me.txtFormulName.Size = New System.Drawing.Size(872, 30)
        Me.txtFormulName.TabIndex = 7
        '
        'DGVFormulas
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DGVFormulas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DGVFormulas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVFormulas.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVFormulas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGVFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVFormulas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_IdKala, Me.Cln_Sharh, Me.Cln_Masraf, Me.Cln_Tavlid, Me.Cln_IdVahed, Me.Cln_Unit, Me.Cln_Stock, Me.Cln_EndPrice})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVFormulas.DefaultCellStyle = DataGridViewCellStyle12
        Me.DGVFormulas.Location = New System.Drawing.Point(13, 57)
        Me.DGVFormulas.Name = "DGVFormulas"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVFormulas.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DGVFormulas.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.DGVFormulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGVFormulas.Size = New System.Drawing.Size(941, 223)
        Me.DGVFormulas.TabIndex = 9
        '
        'Cln_IdKala
        '
        Me.Cln_IdKala.HeaderText = "کد کالا"
        Me.Cln_IdKala.Name = "Cln_IdKala"
        Me.Cln_IdKala.Visible = False
        '
        'Cln_Sharh
        '
        Me.Cln_Sharh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Cln_Sharh.HeaderText = "شرح کالا"
        Me.Cln_Sharh.Name = "Cln_Sharh"
        '
        'Cln_Masraf
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cln_Masraf.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_Masraf.HeaderText = "مصرف"
        Me.Cln_Masraf.Name = "Cln_Masraf"
        '
        'Cln_Tavlid
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Cln_Tavlid.DefaultCellStyle = DataGridViewCellStyle11
        Me.Cln_Tavlid.HeaderText = "تولید"
        Me.Cln_Tavlid.Name = "Cln_Tavlid"
        '
        'Cln_IdVahed
        '
        Me.Cln_IdVahed.HeaderText = "کد واحد"
        Me.Cln_IdVahed.Name = "Cln_IdVahed"
        Me.Cln_IdVahed.Visible = False
        '
        'Cln_Unit
        '
        Me.Cln_Unit.HeaderText = "واحد"
        Me.Cln_Unit.Name = "Cln_Unit"
        '
        'Cln_Stock
        '
        Me.Cln_Stock.HeaderText = "انبار"
        Me.Cln_Stock.Name = "Cln_Stock"
        '
        'Cln_EndPrice
        '
        Me.Cln_EndPrice.HeaderText = "قیمت تمام شده"
        Me.Cln_EndPrice.Name = "Cln_EndPrice"
        Me.Cln_EndPrice.Width = 130
        '
        'txtCountTavlid
        '
        Me.txtCountTavlid.Location = New System.Drawing.Point(344, 283)
        Me.txtCountTavlid.Name = "txtCountTavlid"
        Me.txtCountTavlid.Size = New System.Drawing.Size(100, 30)
        Me.txtCountTavlid.TabIndex = 10
        '
        'txtCountUnit
        '
        Me.txtCountUnit.Location = New System.Drawing.Point(245, 283)
        Me.txtCountUnit.Name = "txtCountUnit"
        Me.txtCountUnit.Size = New System.Drawing.Size(100, 30)
        Me.txtCountUnit.TabIndex = 11
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(167, 361)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(148, 34)
        Me.BtnSave.TabIndex = 12
        Me.BtnSave.Text = "ثبت"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(13, 361)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(148, 34)
        Me.BtnCancel.TabIndex = 13
        Me.BtnCancel.Text = "انصراف"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 401)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(970, 31)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 34
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(65, 26)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(52, 26)
        Me.ToolStripStatusLabel6.Text = "F2ثبت"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(73, 26)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'FrmProductionFormulas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(970, 432)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.txtCountUnit)
        Me.Controls.Add(Me.txtCountTavlid)
        Me.Controls.Add(Me.DGVFormulas)
        Me.Controls.Add(Me.txtFormulName)
        Me.Controls.Add(Me.txtCountTavazon)
        Me.Controls.Add(Me.txtFormulNo)
        Me.Controls.Add(Me.txtDateStart)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductionFormulas"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف فرمول ساخت"
        CType(Me.DGVFormulas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtFormulNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCountTavazon As System.Windows.Forms.TextBox
    Friend WithEvents txtFormulName As System.Windows.Forms.TextBox
    Friend WithEvents DGVFormulas As System.Windows.Forms.DataGridView
    Friend WithEvents txtCountTavlid As System.Windows.Forms.TextBox
    Friend WithEvents txtCountUnit As System.Windows.Forms.TextBox
    Friend WithEvents Cln_IdKala As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Sharh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Masraf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Tavlid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdVahed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_EndPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
End Class
