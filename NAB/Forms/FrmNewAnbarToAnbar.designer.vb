<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewAnbarToAnbar
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtKalaDate = New FarsiDate.FarsiDate
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.Btnsave = New System.Windows.Forms.Button
        Me.LSanad = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.cln_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_count = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_b = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OneAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_TwoAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_CodeOneAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_CodeTwoAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_DK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_KOL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_JOZ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OldKol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OldJoz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OldOneAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OldTwoAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(110, 285)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 21)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "تاریخ انتقال"
        '
        'TxtKalaDate
        '
        Me.TxtKalaDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtKalaDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtKalaDate.Location = New System.Drawing.Point(5, 281)
        Me.TxtKalaDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtKalaDate.Name = "TxtKalaDate"
        Me.TxtKalaDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtKalaDate.Size = New System.Drawing.Size(98, 29)
        Me.TxtKalaDate.TabIndex = 3
        Me.TxtKalaDate.ThisText = Nothing
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 357)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(861, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 50
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
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel3.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(671, 321)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 30)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "انصراف"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Btnsave
        '
        Me.Btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btnsave.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btnsave.Location = New System.Drawing.Point(763, 321)
        Me.Btnsave.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(86, 30)
        Me.Btnsave.TabIndex = 7
        Me.Btnsave.Text = "ثبت"
        Me.Btnsave.UseVisualStyleBackColor = True
        '
        'LSanad
        '
        Me.LSanad.AutoSize = True
        Me.LSanad.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LSanad.Location = New System.Drawing.Point(16, 126)
        Me.LSanad.Name = "LSanad"
        Me.LSanad.Size = New System.Drawing.Size(0, 21)
        Me.LSanad.TabIndex = 58
        Me.LSanad.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.DGV1)
        Me.GroupBox3.Controls.Add(Me.TxtKalaDate)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 1)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(844, 314)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
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
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cln_type, Me.cln_name, Me.cln_count, Me.cln_b, Me.Cln_OneAnbar, Me.Cln_TwoAnbar, Me.Cln_Disc, Me.Cln_Code, Me.Cln_CodeOneAnbar, Me.Cln_CodeTwoAnbar, Me.Cln_DK, Me.Cln_KOL, Me.Cln_JOZ, Me.Cln_OldKol, Me.Cln_OldJoz, Me.Cln_OldOneAnbar, Me.Cln_OldTwoAnbar})
        Me.DGV1.Location = New System.Drawing.Point(5, 22)
        Me.DGV1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV1.Size = New System.Drawing.Size(834, 258)
        Me.DGV1.TabIndex = 0
        '
        'cln_type
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.cln_type.DefaultCellStyle = DataGridViewCellStyle2
        Me.cln_type.HeaderText = "گروه کالا"
        Me.cln_type.Name = "cln_type"
        Me.cln_type.ReadOnly = True
        Me.cln_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_type.Width = 150
        '
        'cln_name
        '
        Me.cln_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cln_name.DefaultCellStyle = DataGridViewCellStyle3
        Me.cln_name.HeaderText = "نام كالا"
        Me.cln_name.Name = "cln_name"
        Me.cln_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_name.Width = 191
        '
        'cln_count
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cln_count.DefaultCellStyle = DataGridViewCellStyle4
        Me.cln_count.HeaderText = "تعداد"
        Me.cln_count.MaxInputLength = 10
        Me.cln_count.Name = "cln_count"
        Me.cln_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_count.Width = 80
        '
        'cln_b
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cln_b.DefaultCellStyle = DataGridViewCellStyle5
        Me.cln_b.HeaderText = "نسبت جزء"
        Me.cln_b.MaxInputLength = 10
        Me.cln_b.Name = "cln_b"
        Me.cln_b.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_b.Width = 70
        '
        'Cln_OneAnbar
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_OneAnbar.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_OneAnbar.HeaderText = "انبار مبداء"
        Me.Cln_OneAnbar.Name = "Cln_OneAnbar"
        Me.Cln_OneAnbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cln_TwoAnbar
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_TwoAnbar.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_TwoAnbar.HeaderText = "انبار مقصد"
        Me.Cln_TwoAnbar.Name = "Cln_TwoAnbar"
        Me.Cln_TwoAnbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cln_Disc
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Disc.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cln_Code
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Cln_Code.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Code.HeaderText = "کد کالا"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Code.Visible = False
        '
        'Cln_CodeOneAnbar
        '
        Me.Cln_CodeOneAnbar.HeaderText = "کد انبار مبدا"
        Me.Cln_CodeOneAnbar.Name = "Cln_CodeOneAnbar"
        Me.Cln_CodeOneAnbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_CodeOneAnbar.Visible = False
        '
        'Cln_CodeTwoAnbar
        '
        Me.Cln_CodeTwoAnbar.HeaderText = "کد انبار مقصد"
        Me.Cln_CodeTwoAnbar.Name = "Cln_CodeTwoAnbar"
        Me.Cln_CodeTwoAnbar.Visible = False
        '
        'Cln_DK
        '
        Me.Cln_DK.HeaderText = "دو واحده"
        Me.Cln_DK.Name = "Cln_DK"
        Me.Cln_DK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_DK.Visible = False
        '
        'Cln_KOL
        '
        Me.Cln_KOL.HeaderText = "کل"
        Me.Cln_KOL.Name = "Cln_KOL"
        Me.Cln_KOL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_KOL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_KOL.Visible = False
        '
        'Cln_JOZ
        '
        Me.Cln_JOZ.HeaderText = "جزء"
        Me.Cln_JOZ.Name = "Cln_JOZ"
        Me.Cln_JOZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JOZ.Visible = False
        '
        'Cln_OldKol
        '
        Me.Cln_OldKol.HeaderText = "OldKol"
        Me.Cln_OldKol.Name = "Cln_OldKol"
        Me.Cln_OldKol.Visible = False
        '
        'Cln_OldJoz
        '
        Me.Cln_OldJoz.HeaderText = "OldJoz"
        Me.Cln_OldJoz.Name = "Cln_OldJoz"
        Me.Cln_OldJoz.Visible = False
        '
        'Cln_OldOneAnbar
        '
        Me.Cln_OldOneAnbar.HeaderText = "OldOneAnbar"
        Me.Cln_OldOneAnbar.Name = "Cln_OldOneAnbar"
        Me.Cln_OldOneAnbar.Visible = False
        '
        'Cln_OldTwoAnbar
        '
        Me.Cln_OldTwoAnbar.HeaderText = "OldTwoAnbar"
        Me.Cln_OldTwoAnbar.Name = "Cln_OldTwoAnbar"
        Me.Cln_OldTwoAnbar.Visible = False
        '
        'FrmNewAnbarToAnbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 386)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LSanad)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Btnsave)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmNewAnbarToAnbar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "انتقالات انبار"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtKalaDate As FarsiDate.FarsiDate
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents LSanad As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents cln_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_count As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OneAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_TwoAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_CodeOneAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_CodeTwoAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_DK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_KOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JOZ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OldKol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OldJoz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OldOneAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OldTwoAnbar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
