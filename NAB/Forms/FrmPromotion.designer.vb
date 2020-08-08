<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPromotion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Lname = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtGroup = New System.Windows.Forms.TextBox
        Me.TxtIdGroup = New System.Windows.Forms.TextBox
        Me.ChkGroup = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtFe = New System.Windows.Forms.TextBox
        Me.EDIT = New System.Windows.Forms.Label
        Me.Ls = New System.Windows.Forms.Label
        Me.TxtKala = New System.Windows.Forms.TextBox
        Me.TxtIdkala = New System.Windows.Forms.TextBox
        Me.TxtJoz = New System.Windows.Forms.TextBox
        Me.TxtKol = New System.Windows.Forms.TextBox
        Me.ChkDK = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_Az = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Ta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Fe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Darsad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Lname)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtGroup)
        Me.GroupBox1.Controls.Add(Me.TxtIdGroup)
        Me.GroupBox1.Controls.Add(Me.ChkGroup)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtFe)
        Me.GroupBox1.Controls.Add(Me.EDIT)
        Me.GroupBox1.Controls.Add(Me.Ls)
        Me.GroupBox1.Controls.Add(Me.TxtKala)
        Me.GroupBox1.Controls.Add(Me.TxtIdkala)
        Me.GroupBox1.Controls.Add(Me.TxtJoz)
        Me.GroupBox1.Controls.Add(Me.TxtKol)
        Me.GroupBox1.Controls.Add(Me.ChkDK)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(321, 119)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات کالا"
        '
        'Lname
        '
        Me.Lname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lname.AutoSize = True
        Me.Lname.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lname.Location = New System.Drawing.Point(276, 91)
        Me.Lname.Name = "Lname"
        Me.Lname.Size = New System.Drawing.Size(0, 19)
        Me.Lname.TabIndex = 50
        Me.Lname.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(256, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 21)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "نام گروه"
        '
        'TxtGroup
        '
        Me.TxtGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGroup.BackColor = System.Drawing.SystemColors.Window
        Me.TxtGroup.Location = New System.Drawing.Point(157, 58)
        Me.TxtGroup.MaxLength = 18
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.ShortcutsEnabled = False
        Me.TxtGroup.Size = New System.Drawing.Size(93, 29)
        Me.TxtGroup.TabIndex = 1
        '
        'TxtIdGroup
        '
        Me.TxtIdGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdGroup.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdGroup.Enabled = False
        Me.TxtIdGroup.Location = New System.Drawing.Point(206, 58)
        Me.TxtIdGroup.MaxLength = 18
        Me.TxtIdGroup.Name = "TxtIdGroup"
        Me.TxtIdGroup.ReadOnly = True
        Me.TxtIdGroup.ShortcutsEnabled = False
        Me.TxtIdGroup.Size = New System.Drawing.Size(10, 29)
        Me.TxtIdGroup.TabIndex = 47
        Me.TxtIdGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkGroup
        '
        Me.ChkGroup.AutoSize = True
        Me.ChkGroup.Location = New System.Drawing.Point(119, 90)
        Me.ChkGroup.Name = "ChkGroup"
        Me.ChkGroup.Size = New System.Drawing.Size(131, 25)
        Me.ChkGroup.TabIndex = 3
        Me.ChkGroup.Text = "بدون محدودیت گروه"
        Me.ChkGroup.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 19)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "قیمت پایه"
        '
        'TxtFe
        '
        Me.TxtFe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFe.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtFe.Location = New System.Drawing.Point(6, 58)
        Me.TxtFe.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtFe.MaxLength = 20
        Me.TxtFe.Name = "TxtFe"
        Me.TxtFe.Size = New System.Drawing.Size(95, 29)
        Me.TxtFe.TabIndex = 2
        Me.TxtFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EDIT
        '
        Me.EDIT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EDIT.AutoSize = True
        Me.EDIT.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDIT.Location = New System.Drawing.Point(290, 3)
        Me.EDIT.Name = "EDIT"
        Me.EDIT.Size = New System.Drawing.Size(0, 19)
        Me.EDIT.TabIndex = 41
        Me.EDIT.Visible = False
        '
        'Ls
        '
        Me.Ls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ls.AutoSize = True
        Me.Ls.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Ls.Location = New System.Drawing.Point(269, 31)
        Me.Ls.Name = "Ls"
        Me.Ls.Size = New System.Drawing.Size(37, 19)
        Me.Ls.TabIndex = 32
        Me.Ls.Text = "نام کالا"
        '
        'TxtKala
        '
        Me.TxtKala.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtKala.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtKala.Location = New System.Drawing.Point(6, 28)
        Me.TxtKala.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtKala.MaxLength = 50
        Me.TxtKala.Name = "TxtKala"
        Me.TxtKala.Size = New System.Drawing.Size(244, 29)
        Me.TxtKala.TabIndex = 0
        '
        'TxtIdkala
        '
        Me.TxtIdkala.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdkala.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtIdkala.Location = New System.Drawing.Point(119, 28)
        Me.TxtIdkala.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtIdkala.MaxLength = 50
        Me.TxtIdkala.Name = "TxtIdkala"
        Me.TxtIdkala.ReadOnly = True
        Me.TxtIdkala.Size = New System.Drawing.Size(50, 27)
        Me.TxtIdkala.TabIndex = 37
        Me.TxtIdkala.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtJoz
        '
        Me.TxtJoz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtJoz.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtJoz.Location = New System.Drawing.Point(7, 28)
        Me.TxtJoz.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtJoz.MaxLength = 50
        Me.TxtJoz.Name = "TxtJoz"
        Me.TxtJoz.ReadOnly = True
        Me.TxtJoz.Size = New System.Drawing.Size(50, 27)
        Me.TxtJoz.TabIndex = 39
        Me.TxtJoz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtKol
        '
        Me.TxtKol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtKol.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtKol.Location = New System.Drawing.Point(63, 28)
        Me.TxtKol.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtKol.MaxLength = 50
        Me.TxtKol.Name = "TxtKol"
        Me.TxtKol.ReadOnly = True
        Me.TxtKol.Size = New System.Drawing.Size(50, 27)
        Me.TxtKol.TabIndex = 38
        Me.TxtKol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ChkDK
        '
        Me.ChkDK.AutoSize = True
        Me.ChkDK.Location = New System.Drawing.Point(88, 29)
        Me.ChkDK.Name = "ChkDK"
        Me.ChkDK.Size = New System.Drawing.Size(46, 25)
        Me.ChkDK.TabIndex = 40
        Me.ChkDK.Text = "DK"
        Me.ChkDK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DGV)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(321, 290)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "قیمت ویژه"
        '
        'DGV
        '
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Az, Me.Cln_Ta, Me.Cln_Fe, Me.Cln_Darsad})
        Me.DGV.Location = New System.Drawing.Point(11, 28)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(298, 256)
        Me.DGV.TabIndex = 4
        '
        'Cln_Az
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Az.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Az.HeaderText = "از"
        Me.Cln_Az.Name = "Cln_Az"
        Me.Cln_Az.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Az.Width = 60
        '
        'Cln_Ta
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Ta.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Ta.HeaderText = "تا"
        Me.Cln_Ta.Name = "Cln_Ta"
        Me.Cln_Ta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Ta.Width = 60
        '
        'Cln_Fe
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Fe.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_Fe.HeaderText = "قیمت"
        Me.Cln_Fe.Name = "Cln_Fe"
        Me.Cln_Fe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Fe.Width = 80
        '
        'Cln_Darsad
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Darsad.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_Darsad.HeaderText = "درصد"
        Me.Cln_Darsad.Name = "Cln_Darsad"
        Me.Cln_Darsad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Darsad.Width = 55
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 470)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(342, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 41
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
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(260, 430)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "ذخیره"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.Location = New System.Drawing.Point(179, 430)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "انصراف"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrmPromotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 499)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPromotion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "رابطه کالا و قیمت ویژه"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Ls As System.Windows.Forms.Label
    Friend WithEvents TxtKala As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdkala As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtJoz As System.Windows.Forms.TextBox
    Friend WithEvents TxtKol As System.Windows.Forms.TextBox
    Friend WithEvents ChkDK As System.Windows.Forms.CheckBox
    Friend WithEvents EDIT As System.Windows.Forms.Label
    Friend WithEvents ChkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFe As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdGroup As System.Windows.Forms.TextBox
    Friend WithEvents Cln_Az As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Ta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Fe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Darsad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lname As System.Windows.Forms.Label
End Class
