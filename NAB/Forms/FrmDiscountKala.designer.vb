<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiscountKala
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtGroup = New System.Windows.Forms.TextBox
        Me.EDIT = New System.Windows.Forms.Label
        Me.Ls = New System.Windows.Forms.Label
        Me.TxtKala = New System.Windows.Forms.TextBox
        Me.TxtIdkala = New System.Windows.Forms.TextBox
        Me.TxtJoz = New System.Windows.Forms.TextBox
        Me.TxtKol = New System.Windows.Forms.TextBox
        Me.ChkDK = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkDiscount = New System.Windows.Forms.CheckBox
        Me.BtnService = New System.Windows.Forms.Button
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_KolCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_JozCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Namkala = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_DKol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_DJoz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Dk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_Kol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_JOZ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdService = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.Lname = New System.Windows.Forms.Label
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
        Me.GroupBox1.Size = New System.Drawing.Size(456, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات کالا"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(392, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 19)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "گروه بندی"
        '
        'TxtGroup
        '
        Me.TxtGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGroup.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtGroup.Location = New System.Drawing.Point(254, 57)
        Me.TxtGroup.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtGroup.MaxLength = 50
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.Size = New System.Drawing.Size(123, 29)
        Me.TxtGroup.TabIndex = 42
        '
        'EDIT
        '
        Me.EDIT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EDIT.AutoSize = True
        Me.EDIT.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDIT.Location = New System.Drawing.Point(425, 3)
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
        Me.Ls.Location = New System.Drawing.Point(404, 31)
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
        Me.TxtKala.Location = New System.Drawing.Point(11, 28)
        Me.TxtKala.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtKala.MaxLength = 50
        Me.TxtKala.Name = "TxtKala"
        Me.TxtKala.Size = New System.Drawing.Size(366, 29)
        Me.TxtKala.TabIndex = 0
        '
        'TxtIdkala
        '
        Me.TxtIdkala.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdkala.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtIdkala.Location = New System.Drawing.Point(254, 28)
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
        Me.TxtJoz.Location = New System.Drawing.Point(142, 28)
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
        Me.TxtKol.Location = New System.Drawing.Point(198, 28)
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
        Me.GroupBox2.Controls.Add(Me.ChkDiscount)
        Me.GroupBox2.Controls.Add(Me.BtnService)
        Me.GroupBox2.Controls.Add(Me.DGV)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(456, 362)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "تخفیفات"
        '
        'ChkDiscount
        '
        Me.ChkDiscount.AutoSize = True
        Me.ChkDiscount.Location = New System.Drawing.Point(234, 329)
        Me.ChkDiscount.Name = "ChkDiscount"
        Me.ChkDiscount.Size = New System.Drawing.Size(208, 25)
        Me.ChkDiscount.TabIndex = 42
        Me.ChkDiscount.Text = "جایزه تصاعدی در فاکتور محاسبه شود"
        Me.ChkDiscount.UseVisualStyleBackColor = True
        '
        'BtnService
        '
        Me.BtnService.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnService.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnService.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnService.Location = New System.Drawing.Point(11, 325)
        Me.BtnService.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnService.Name = "BtnService"
        Me.BtnService.Size = New System.Drawing.Size(99, 30)
        Me.BtnService.TabIndex = 31
        Me.BtnService.Text = "کالای خدماتی"
        Me.BtnService.UseVisualStyleBackColor = True
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_KolCount, Me.Cln_JozCount, Me.Cln_Namkala, Me.Cln_DKol, Me.Cln_DJoz, Me.Cln_Dk, Me.Cln_Kol, Me.Cln_JOZ, Me.Cln_Code, Me.Cln_IdService})
        Me.DGV.Location = New System.Drawing.Point(11, 28)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(433, 292)
        Me.DGV.TabIndex = 28
        '
        'Cln_KolCount
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_KolCount.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_KolCount.HeaderText = "کل"
        Me.Cln_KolCount.Name = "Cln_KolCount"
        Me.Cln_KolCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_KolCount.Width = 60
        '
        'Cln_JozCount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_JozCount.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_JozCount.HeaderText = "جزء"
        Me.Cln_JozCount.Name = "Cln_JozCount"
        Me.Cln_JozCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JozCount.Width = 60
        '
        'Cln_Namkala
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Namkala.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_Namkala.HeaderText = " کالا جهت جایزه"
        Me.Cln_Namkala.Name = "Cln_Namkala"
        Me.Cln_Namkala.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Namkala.Width = 150
        '
        'Cln_DKol
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_DKol.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_DKol.HeaderText = "جایزه کل"
        Me.Cln_DKol.Name = "Cln_DKol"
        Me.Cln_DKol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_DKol.Width = 60
        '
        'Cln_DJoz
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_DJoz.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_DJoz.HeaderText = "جایزه جز"
        Me.Cln_DJoz.Name = "Cln_DJoz"
        Me.Cln_DJoz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_DJoz.Width = 60
        '
        'Cln_Dk
        '
        Me.Cln_Dk.HeaderText = "DK"
        Me.Cln_Dk.Name = "Cln_Dk"
        Me.Cln_Dk.Visible = False
        '
        'Cln_Kol
        '
        Me.Cln_Kol.HeaderText = "DK_KOL"
        Me.Cln_Kol.Name = "Cln_Kol"
        Me.Cln_Kol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Kol.Visible = False
        '
        'Cln_JOZ
        '
        Me.Cln_JOZ.HeaderText = "DK_JOZ"
        Me.Cln_JOZ.Name = "Cln_JOZ"
        Me.Cln_JOZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JOZ.Visible = False
        '
        'Cln_Code
        '
        Me.Cln_Code.HeaderText = "Code"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Code.Visible = False
        '
        'Cln_IdService
        '
        Me.Cln_IdService.HeaderText = "IdService"
        Me.Cln_IdService.Name = "Cln_IdService"
        Me.Cln_IdService.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_IdService.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 512)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(477, 29)
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
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(83, 24)
        Me.ToolStripStatusLabel5.Text = "F4 کالای خدماتی"
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
        Me.BtnSave.Location = New System.Drawing.Point(395, 468)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 39
        Me.BtnSave.Text = "ذخیره"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.Location = New System.Drawing.Point(314, 468)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancel.TabIndex = 40
        Me.BtnCancel.Text = "انصراف"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Lname
        '
        Me.Lname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lname.AutoSize = True
        Me.Lname.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lname.Location = New System.Drawing.Point(11, 67)
        Me.Lname.Name = "Lname"
        Me.Lname.Size = New System.Drawing.Size(0, 19)
        Me.Lname.TabIndex = 44
        Me.Lname.Visible = False
        '
        'FrmDiscountKala
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 541)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmDiscountKala"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "رابطه کالا و جایزه"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents BtnService As System.Windows.Forms.Button
    Friend WithEvents TxtJoz As System.Windows.Forms.TextBox
    Friend WithEvents TxtKol As System.Windows.Forms.TextBox
    Friend WithEvents ChkDK As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EDIT As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
    Friend WithEvents Cln_KolCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JozCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Namkala As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_DKol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_DJoz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Dk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Kol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JOZ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents Lname As System.Windows.Forms.Label
End Class
